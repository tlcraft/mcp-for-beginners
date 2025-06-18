<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:36:12+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "fa"
}
-->
# پخش HTTPS با پروتکل مدل کانتکست (MCP)

این فصل راهنمای جامعی برای پیاده‌سازی پخش امن، مقیاس‌پذیر و بلادرنگ با استفاده از پروتکل مدل کانتکست (MCP) از طریق HTTPS ارائه می‌دهد. این فصل به دلایل استفاده از پخش، مکانیزم‌های انتقال موجود، نحوه پیاده‌سازی HTTP قابل پخش در MCP، بهترین روش‌های امنیتی، مهاجرت از SSE و راهنمایی‌های عملی برای ساخت برنامه‌های MCP پخش‌شونده می‌پردازد.

## مکانیزم‌های انتقال و پخش در MCP

این بخش به بررسی مکانیزم‌های انتقال مختلف در MCP و نقش آن‌ها در فعال‌سازی قابلیت‌های پخش برای ارتباط بلادرنگ بین کلاینت‌ها و سرورها می‌پردازد.

### مکانیزم انتقال چیست؟

مکانیزم انتقال تعیین می‌کند داده‌ها چگونه بین کلاینت و سرور رد و بدل می‌شوند. MCP از چند نوع مکانیزم انتقال پشتیبانی می‌کند تا با محیط‌ها و نیازهای مختلف سازگار باشد:

- **stdio**: ورودی/خروجی استاندارد، مناسب برای ابزارهای محلی و مبتنی بر خط فرمان. ساده اما مناسب وب یا فضای ابری نیست.
- **SSE (رویدادهای ارسال شده از سرور)**: اجازه می‌دهد سرورها به‌روزرسانی‌های بلادرنگ را از طریق HTTP به کلاینت‌ها ارسال کنند. برای رابط‌های وب خوب است، اما در مقیاس‌پذیری و انعطاف‌پذیری محدود است.
- **HTTP قابل پخش**: انتقال مبتنی بر HTTP مدرن برای پخش، با پشتیبانی از اعلان‌ها و مقیاس‌پذیری بهتر. برای اکثر سناریوهای تولید و فضای ابری توصیه می‌شود.

### جدول مقایسه

برای درک تفاوت‌های بین این مکانیزم‌های انتقال، جدول زیر را مشاهده کنید:

| مکانیزم انتقال   | به‌روزرسانی بلادرنگ | پخش     | مقیاس‌پذیری | مورد استفاده               |
|------------------|---------------------|---------|-------------|----------------------------|
| stdio            | خیر                 | خیر     | پایین      | ابزارهای خط فرمان محلی     |
| SSE              | بله                 | بله     | متوسط      | وب، به‌روزرسانی‌های بلادرنگ|
| HTTP قابل پخش    | بله                 | بله     | بالا       | فضای ابری، چند کلاینت     |

> **نکته:** انتخاب مکانیزم انتقال مناسب بر عملکرد، مقیاس‌پذیری و تجربه کاربری تاثیرگذار است. برای برنامه‌های مدرن، مقیاس‌پذیر و آماده فضای ابری، **HTTP قابل پخش** توصیه می‌شود.

به مکانیزم‌های stdio و SSE که در فصل‌های قبلی معرفی شدند توجه کنید و اینکه HTTP قابل پخش مکانیزمی است که در این فصل به آن پرداخته شده است.

## پخش: مفاهیم و انگیزه

درک مفاهیم پایه و انگیزه‌های پشت پخش برای پیاده‌سازی سیستم‌های ارتباط بلادرنگ مؤثر ضروری است.

**پخش** تکنیکی در برنامه‌نویسی شبکه است که اجازه می‌دهد داده‌ها به صورت بخش‌های کوچک و قابل مدیریت یا به شکل توالی رویدادها ارسال و دریافت شوند، به جای اینکه منتظر بمانیم کل پاسخ آماده شود. این روش به‌ویژه برای موارد زیر مفید است:

- فایل‌ها یا مجموعه داده‌های بزرگ
- به‌روزرسانی‌های بلادرنگ (مثلاً چت، نوار پیشرفت)
- محاسبات طولانی‌مدت که می‌خواهید کاربر را در جریان قرار دهید

در سطح کلی باید بدانید:

- داده‌ها به تدریج ارسال می‌شوند، نه همه به یکباره.
- کلاینت می‌تواند داده‌ها را به محض دریافت پردازش کند.
- باعث کاهش تأخیر ادراکی و بهبود تجربه کاربری می‌شود.

### چرا از پخش استفاده کنیم؟

دلایل استفاده از پخش عبارتند از:

- کاربران فوراً بازخورد دریافت می‌کنند، نه فقط در پایان
- امکان ساخت برنامه‌های بلادرنگ و رابط‌های کاربری پاسخگو را فراهم می‌کند
- استفاده بهینه‌تر از منابع شبکه و محاسبات

### مثال ساده: سرور و کلاینت پخش HTTP

در اینجا یک مثال ساده از نحوه پیاده‌سازی پخش آورده شده است:

<details>
<summary>پایتون</summary>

**سرور (پایتون، با استفاده از FastAPI و StreamingResponse):**
<details>
<summary>پایتون</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**کلاینت (پایتون، با استفاده از requests):**
<details>
<summary>پایتون</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

این مثال نشان می‌دهد سرور چگونه یک سری پیام را به کلاینت ارسال می‌کند به محض اینکه آماده شدند، به جای اینکه منتظر بماند همه پیام‌ها آماده شوند.

**نحوه کار:**
- سرور هر پیام را به محض آماده شدن ارسال می‌کند.
- کلاینت هر بخش را به محض دریافت چاپ می‌کند.

**نیازمندی‌ها:**
- سرور باید از پاسخ پخش‌شونده استفاده کند (مثلاً `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>جاوا</summary>

**سرور (جاوا، با استفاده از Spring Boot و Server-Sent Events):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**کلاینت (جاوا، با استفاده از Spring WebFlux WebClient):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**یادداشت‌های پیاده‌سازی جاوا:**
- از استک واکنشی Spring Boot با `Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) استفاده می‌کند و به جای انتخاب پخش از طریق MCP، این روش را به کار می‌برد.

- **برای نیازهای ساده پخش:** پخش کلاسیک HTTP ساده‌تر است و برای نیازهای پایه کافی است.

- **برای برنامه‌های پیچیده و تعاملی:** پخش MCP رویکرد ساختارمندتری با متادیتای غنی‌تر و تفکیک اعلان‌ها از نتایج نهایی ارائه می‌دهد.

- **برای برنامه‌های هوش مصنوعی:** سیستم اعلان MCP به ویژه برای وظایف طولانی‌مدت AI که می‌خواهید کاربران را از پیشرفت مطلع کنید، بسیار مفید است.

## پخش در MCP

خب، تاکنون توصیه‌ها و مقایسه‌هایی درباره تفاوت بین پخش کلاسیک و پخش در MCP دیدید. حالا دقیق‌تر بررسی می‌کنیم که چگونه می‌توانید از پخش در MCP بهره ببرید.

درک نحوه کار پخش در چارچوب MCP برای ساخت برنامه‌های پاسخگو که بازخورد بلادرنگ به کاربران در طول عملیات طولانی ارائه می‌دهند ضروری است.

در MCP، پخش به معنی ارسال پاسخ اصلی به صورت بخش‌بخش نیست، بلکه ارسال **اعلان‌ها** به کلاینت در حین پردازش درخواست توسط ابزار است. این اعلان‌ها می‌توانند شامل به‌روزرسانی پیشرفت، لاگ‌ها یا رویدادهای دیگر باشند.

### نحوه کار

نتیجه اصلی همچنان به صورت یک پاسخ واحد ارسال می‌شود. با این حال، اعلان‌ها می‌توانند به صورت پیام‌های جداگانه در طول پردازش ارسال شده و کلاینت را به صورت بلادرنگ به‌روزرسانی کنند. کلاینت باید قادر به پردازش و نمایش این اعلان‌ها باشد.

## اعلان چیست؟

گفتیم "اعلان"، این در زمینه MCP یعنی چه؟

اعلان پیامی است که از سرور به کلاینت ارسال می‌شود تا درباره پیشرفت، وضعیت یا رویدادهای دیگر در طول یک عملیات طولانی‌مدت اطلاع‌رسانی کند. اعلان‌ها شفافیت و تجربه کاربری را بهبود می‌بخشند.

مثلاً کلاینت باید یک اعلان ارسال کند زمانی که دست دادن اولیه با سرور انجام شده است.

یک اعلان به صورت پیام JSON به شکل زیر است:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

اعلان‌ها به موضوعی در MCP تعلق دارند که به آن ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) گفته می‌شود.

برای فعال کردن لاگینگ، سرور باید آن را به عنوان یک ویژگی/قابلیت فعال کند، به این صورت:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> بسته به SDK مورد استفاده، ممکن است لاگینگ به صورت پیش‌فرض فعال باشد یا لازم باشد به صورت صریح در پیکربندی سرور فعال شود.

انواع مختلف اعلان‌ها عبارتند از:

| سطح       | توضیح                        | مثال کاربردی                 |
|-----------|-----------------------------|-----------------------------|
| debug     | اطلاعات دقیق اشکال‌زدایی    | نقاط ورود/خروج توابع        |
| info      | پیام‌های اطلاعاتی عمومی     | به‌روزرسانی پیشرفت عملیات  |
| notice    | رویدادهای عادی اما مهم     | تغییرات پیکربندی           |
| warning   | شرایط هشدار                 | استفاده از قابلیت منسوخ شده|
| error     | شرایط خطا                  | شکست عملیات                |
| critical  | شرایط بحرانی               | خرابی اجزای سیستم          |
| alert     | نیاز به اقدام فوری          | تشخیص خرابی داده‌ها         |
| emergency | سیستم غیرقابل استفاده      | خرابی کامل سیستم           |

## پیاده‌سازی اعلان‌ها در MCP

برای پیاده‌سازی اعلان‌ها در MCP باید هر دو سمت سرور و کلاینت را برای مدیریت به‌روزرسانی‌های بلادرنگ آماده کنید. این کار به برنامه شما امکان می‌دهد در طول عملیات طولانی‌مدت بازخورد فوری به کاربران ارائه دهد.

### سمت سرور: ارسال اعلان‌ها

از سمت سرور شروع کنیم. در MCP، ابزارهایی تعریف می‌کنید که می‌توانند هنگام پردازش درخواست‌ها اعلان ارسال کنند. سرور از شیء context (معمولاً `ctx`) برای ارسال پیام به کلاینت استفاده می‌کند.

<details>
<summary>پایتون</summary>

<details>
<summary>پایتون</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

در مثال بالا، متد `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` استفاده شده است.

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

در این مثال .NET، متد `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` برای ارسال پیام‌های اطلاعاتی به کار رفته است.

برای فعال کردن اعلان‌ها در سرور MCP مبتنی بر .NET، مطمئن شوید که از مکانیزم انتقال پخش‌شونده استفاده می‌کنید:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### سمت کلاینت: دریافت اعلان‌ها

کلاینت باید یک هندلر پیام پیاده‌سازی کند تا اعلان‌ها را هنگام دریافت پردازش و نمایش دهد.

<details>
<summary>پایتون</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

در کد بالا، `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` برای پردازش اعلان‌های دریافتی به کار رفته است.

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

در این مثال .NET، `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` استفاده شده و کلاینت هندلر پیام را برای پردازش اعلان‌ها پیاده‌سازی کرده است.

## اعلان‌های پیشرفت و سناریوها

این بخش مفهوم اعلان‌های پیشرفت در MCP، اهمیت آن‌ها و نحوه پیاده‌سازی با استفاده از HTTP قابل پخش را توضیح می‌دهد. همچنین یک تمرین عملی برای تقویت درک شما ارائه شده است.

اعلان‌های پیشرفت پیام‌های بلادرنگی هستند که از سرور به کلاینت در طول عملیات طولانی‌مدت ارسال می‌شوند. به جای اینکه منتظر بمانیم کل فرایند تمام شود، سرور کلاینت را از وضعیت فعلی مطلع می‌کند. این کار شفافیت، تجربه کاربری و اشکال‌زدایی را بهبود می‌بخشد.

**مثال:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### چرا از اعلان‌های پیشرفت استفاده کنیم؟

اعلان‌های پیشرفت به دلایل زیر ضروری هستند:

- **تجربه کاربری بهتر:** کاربران به محض پیشرفت کار، به‌روزرسانی‌ها را می‌بینند، نه فقط در پایان.
- **بازخورد بلادرنگ:** کلاینت‌ها می‌توانند نوار پیشرفت یا لاگ‌ها را نمایش دهند و برنامه پاسخگو به نظر برسد.
- **اشکال‌زدایی و نظارت آسان‌تر:** توسعه‌دهندگان و کاربران می‌توانند ببینند فرآیند کجا کند یا متوقف شده است.

### چگونه اعلان‌های پیشرفت را پیاده‌سازی کنیم

نحوه پیاده‌سازی اعلان‌های پیشرفت در MCP به شرح زیر است:

- **سمت سرور:** از `ctx.info()` or `ctx.log()` برای ارسال اعلان‌ها در حین پردازش هر آیتم استفاده کنید. این پیام‌ها قبل از آماده شدن نتیجه اصلی به کلاینت ارسال می‌شوند.
- **سمت کلاینت:** هندلری برای پیام‌ها پیاده‌سازی کنید که اعلان‌ها را هنگام رسیدن دریافت و نمایش دهد. این هندلر باید بین اعلان‌ها و نتیجه نهایی تمایز قائل شود.

**مثال سرور:**

<details>
<summary>پایتون</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**مثال کلاینت:**

<details>
<summary>پایتون</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## ملاحظات امنیتی

هنگام پیاده‌سازی سرورهای MCP با انتقال‌های مبتنی بر HTTP، امنیت اهمیت بالایی پیدا می‌کند و نیازمند توجه دقیق به چندین بردار حمله و مکانیزم‌های حفاظتی است.

### مرور کلی

امنیت هنگام ارائه سرورهای MCP از طریق HTTP حیاتی است. HTTP قابل پخش سطوح جدیدی از آسیب‌پذیری‌ها را ایجاد می‌کند و نیازمند پیکربندی دقیق است.

### نکات کلیدی
- **اعتبارسنجی هدر Origin:** همیشه هدر `Origin` را اعتبارسنجی کنید تا اطمینان حاصل شود درخواست‌ها از منابع مجاز می‌آیند.
- **استفاده از HTTPS:** برای جلوگیری از حملات میانی، ارتباطات باید از طریق HTTPS برقرار شود.
- **محدود کردن دسترسی:** دسترسی به سرور باید محدود به کلاینت‌ها و دامنه‌های مورد اعتماد باشد.
- **کنترل نرخ درخواست:** برای جلوگیری از حملات انکار سرویس (DoS)، نرخ درخواست‌ها باید کنترل شود.
- **مانیتورینگ و لاگینگ:** فعالیت‌های مشکوک باید ثبت و نظارت شوند.

### حفظ سازگاری

در فرآیند مهاجرت، توصیه می‌شود سازگاری با کلاینت‌های SSE موجود حفظ شود. راهکارهای زیر پیشنهاد می‌شود:

- می‌توانید هم SSE و هم HTTP قابل پخش را روی نقاط انتهایی مختلف اجرا کنید.
- به تدریج کلاینت‌ها را به مکانیزم جدید منتقل کنید.

### چالش‌ها

در طول مهاجرت باید به موارد زیر توجه کنید:

- اطمینان از به‌روزرسانی همه کلاینت‌ها
- مدیریت تفاوت‌های تحویل اعلان‌ها

### تمرین: ساخت برنامه MCP پخش‌شونده خودتان

**سناریو:**
یک سرور و کلاینت MCP بسازید که سرور فهرستی از آیتم‌ها (مثلاً فایل‌ها یا اسناد) را پردازش کند و برای هر آیتم پردازش‌شده یک اعلان ارسال کند. کلاینت باید هر اعلان را هنگام دریافت نمایش دهد.

**مراحل:**

1. ابزار سرور را پیاده‌سازی کنید که فهرستی را پردازش کرده و برای هر آیتم اعلان ارسال کند.
2. کلاینتی پیاده‌سازی کنید که هندلر پیام داشته باشد و اعلان‌ها را به صورت بلادرنگ نمایش دهد.
3. با اجرای سرور و کلاینت، پیاده‌سازی خود را تست کنید و اعلان‌ها را مشاهده کنید.

[راه‌حل](./solution/README.md)

## مطالعه بیشتر و گام بعدی؟

برای ادامه مسیر خود با پخش MCP و گسترش دانش، این بخش منابع اضافی و گام‌های پیشنهادی بعدی برای ساخت برنامه‌های پیشرفته‌تر را ارائه می‌دهد.

### مطالعه بیشتر

- [Microsoft: مقدمه‌ای بر پخش HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: رویدادهای ارسال شده از سرور (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS در ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: درخواست‌های پخش‌شونده](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### گام بعدی؟

- تلاش کنید ابزارهای MCP پیشرفته‌تری بسازید که از پخش برای تحلیل‌های بلادرنگ، چت یا ویرایش مشترک استفاده کنند.
- ادغام پخش MCP با فریم‌ورک‌های فرانت‌اند (React، Vue و غیره) برای به‌روزرسانی‌های زنده رابط کاربری را بررسی کنید.
- گام بعدی: [استفاده از جعبه‌ابزار هوش مصنوعی برای VSCode](../07-aitk/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان اصلی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نمی‌باشیم.