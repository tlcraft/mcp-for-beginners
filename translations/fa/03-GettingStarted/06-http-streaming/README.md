<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-12T22:18:03+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "fa"
}
-->
# HTTPS استریمینگ با پروتکل Model Context (MCP)

این فصل راهنمای جامعی برای پیاده‌سازی استریمینگ امن، مقیاس‌پذیر و بلادرنگ با استفاده از پروتکل Model Context (MCP) از طریق HTTPS ارائه می‌دهد. در این فصل به دلایل استفاده از استریمینگ، مکانیزم‌های حمل‌ونقل موجود، نحوه پیاده‌سازی HTTP قابل استریم در MCP، بهترین شیوه‌های امنیتی، مهاجرت از SSE و راهنمای عملی برای ساخت برنامه‌های استریمینگ MCP پرداخته شده است.

## مکانیزم‌های حمل‌ونقل و استریمینگ در MCP

در این بخش، مکانیزم‌های مختلف حمل‌ونقل موجود در MCP و نقش آن‌ها در فعال‌سازی قابلیت‌های استریمینگ برای ارتباط بلادرنگ بین کلاینت‌ها و سرورها بررسی می‌شود.

### مکانیزم حمل‌ونقل چیست؟

مکانیزم حمل‌ونقل مشخص می‌کند داده‌ها چگونه بین کلاینت و سرور رد و بدل می‌شوند. MCP از چند نوع حمل‌ونقل پشتیبانی می‌کند تا با محیط‌ها و نیازهای مختلف سازگار باشد:

- **stdio**: ورودی/خروجی استاندارد، مناسب برای ابزارهای محلی و مبتنی بر خط فرمان. ساده اما مناسب وب یا فضای ابری نیست.
- **SSE (Server-Sent Events)**: به سرورها اجازه می‌دهد به‌روزرسانی‌های بلادرنگ را از طریق HTTP به کلاینت‌ها ارسال کنند. برای رابط‌های وب خوب است اما در مقیاس‌پذیری و انعطاف محدود است.
- **Streamable HTTP**: حمل‌ونقل استریمینگ مبتنی بر HTTP مدرن که از اعلان‌ها و مقیاس‌پذیری بهتر پشتیبانی می‌کند. برای بیشتر سناریوهای تولید و ابری توصیه می‌شود.

### جدول مقایسه

برای درک تفاوت‌های این مکانیزم‌های حمل‌ونقل، جدول زیر را ببینید:

| حمل‌ونقل          | به‌روزرسانی بلادرنگ | استریمینگ | مقیاس‌پذیری | مورد استفاده              |
|-------------------|----------------------|-----------|-------------|--------------------------|
| stdio             | خیر                  | خیر       | کم          | ابزارهای خط فرمان محلی    |
| SSE               | بله                  | بله       | متوسط       | وب، به‌روزرسانی بلادرنگ |
| Streamable HTTP   | بله                  | بله       | بالا        | فضای ابری، چند کلاینت    |

> **نکته:** انتخاب مکانیزم حمل‌ونقل مناسب بر عملکرد، مقیاس‌پذیری و تجربه کاربری تأثیر می‌گذارد. **Streamable HTTP** برای برنامه‌های مدرن، مقیاس‌پذیر و آماده فضای ابری توصیه می‌شود.

مکانیزم‌های stdio و SSE که در فصل‌های قبلی معرفی شدند را به یاد داشته باشید و اکنون می‌بینید که Streamable HTTP مکانیزنی است که در این فصل پوشش داده شده است.

## استریمینگ: مفاهیم و انگیزه

درک مفاهیم بنیادی و انگیزه‌های پشت استریمینگ برای پیاده‌سازی سیستم‌های ارتباط بلادرنگ مؤثر ضروری است.

**استریمینگ** تکنیکی در برنامه‌نویسی شبکه است که اجازه می‌دهد داده‌ها به صورت بخش‌های کوچک و قابل مدیریت یا به شکل توالی رویدادها ارسال و دریافت شوند، به جای اینکه منتظر بمانیم کل پاسخ آماده شود. این روش به‌ویژه برای موارد زیر مفید است:

- فایل‌ها یا داده‌های بزرگ.
- به‌روزرسانی‌های بلادرنگ (مثل چت، نوارهای پیشرفت).
- محاسبات طولانی که می‌خواهید کاربر را در جریان پیشرفت قرار دهید.

در سطح کلی، این نکات را درباره استریمینگ باید بدانید:

- داده‌ها به تدریج ارسال می‌شوند، نه یکجا.
- کلاینت می‌تواند داده‌ها را به محض رسیدن پردازش کند.
- کاهش تأخیر درک‌شده و بهبود تجربه کاربری.

### چرا از استریمینگ استفاده کنیم؟

دلایل استفاده از استریمینگ عبارتند از:

- کاربران فوراً بازخورد می‌گیرند، نه فقط در پایان کار.
- امکان ساخت برنامه‌های بلادرنگ و رابط‌های کاربری پاسخگو را فراهم می‌کند.
- استفاده بهینه‌تر از منابع شبکه و محاسباتی.

### مثال ساده: سرور و کلاینت استریمینگ HTTP

در اینجا یک مثال ساده از نحوه پیاده‌سازی استریمینگ آورده شده است:

<details>
<summary>Python</summary>

**سرور (Python، با استفاده از FastAPI و StreamingResponse):**
<details>
<summary>Python</summary>

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

**کلاینت (Python، با استفاده از requests):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

این مثال نشان می‌دهد که سرور چگونه به جای منتظر ماندن برای آماده شدن همه پیام‌ها، پیام‌ها را به محض آماده شدن به کلاینت ارسال می‌کند.

**نحوه کار:**
- سرور هر پیام را به محض آماده شدن ارسال می‌کند.
- کلاینت هر بخش را هنگام دریافت چاپ می‌کند.

**نیازمندی‌ها:**
- سرور باید از پاسخ استریمینگ استفاده کند (مثلاً `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) به جای انتخاب استریمینگ از طریق MCP.

- **برای نیازهای ساده استریمینگ:** استریمینگ کلاسیک HTTP ساده‌تر است و برای نیازهای پایه کافی است.

- **برای برنامه‌های پیچیده و تعاملی:** استریمینگ MCP رویکرد ساختاریافته‌تری با متادیتای غنی‌تر و تفکیک بین اعلان‌ها و نتایج نهایی ارائه می‌دهد.

- **برای برنامه‌های هوش مصنوعی:** سیستم اعلان MCP به‌ویژه برای وظایف طولانی AI که می‌خواهید کاربران را از پیشرفت مطلع کنید، مفید است.

## استریمینگ در MCP

خب، تا اینجا برخی توصیه‌ها و مقایسه‌ها درباره تفاوت استریمینگ کلاسیک و استریمینگ در MCP دیدید. حالا به طور دقیق‌تر بررسی می‌کنیم که چگونه می‌توانید استریمینگ را در MCP به کار ببرید.

درک نحوه کار استریمینگ در چارچوب MCP برای ساخت برنامه‌های پاسخگو که بازخورد بلادرنگ به کاربران در طول عملیات طولانی ارائه می‌دهند، ضروری است.

در MCP، استریمینگ به معنی ارسال پاسخ اصلی به صورت بخش‌بخش نیست، بلکه به معنی ارسال **اعلان‌ها** به کلاینت در حالی است که یک ابزار در حال پردازش درخواست است. این اعلان‌ها می‌توانند شامل به‌روزرسانی پیشرفت، لاگ‌ها یا رویدادهای دیگر باشند.

### نحوه کار

نتیجه اصلی همچنان به صورت یک پاسخ واحد ارسال می‌شود. با این حال، اعلان‌ها می‌توانند به عنوان پیام‌های جداگانه در حین پردازش ارسال شده و کلاینت را به صورت بلادرنگ به‌روزرسانی کنند. کلاینت باید قادر باشد این اعلان‌ها را دریافت و نمایش دهد.

## اعلان چیست؟

گفتیم "اعلان"، این در زمینه MCP یعنی چه؟

اعلان پیامی است که از سرور به کلاینت ارسال می‌شود تا درباره پیشرفت، وضعیت یا رویدادهای دیگر در طول یک عملیات طولانی اطلاع دهد. اعلان‌ها شفافیت و تجربه کاربری را بهبود می‌بخشند.

برای مثال، کلاینت باید پس از انجام دست دادن اولیه با سرور یک اعلان ارسال کند.

یک اعلان به شکل پیام JSON به این صورت است:

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

برای فعال کردن لاگینگ، سرور باید آن را به عنوان یک ویژگی/قابلیت فعال کند، به این شکل:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> بسته به SDK استفاده‌شده، ممکن است لاگینگ به صورت پیش‌فرض فعال باشد یا لازم باشد به طور صریح در پیکربندی سرور فعال شود.

انواع مختلفی از اعلان‌ها وجود دارد:

| سطح        | توضیح                         | مثال کاربردی                   |
|------------|------------------------------|-------------------------------|
| debug      | اطلاعات دقیق اشکال‌زدایی      | نقاط ورود/خروج توابع          |
| info       | پیام‌های اطلاعاتی عمومی       | به‌روزرسانی پیشرفت عملیات    |
| notice     | رویدادهای معمول ولی مهم      | تغییرات پیکربندی              |
| warning    | شرایط هشدار                  | استفاده از قابلیت منسوخ‌شده   |
| error      | شرایط خطا                    | شکست عملیات                  |
| critical   | شرایط بحرانی                | خرابی اجزای سیستم            |
| alert      | نیاز به اقدام فوری           | شناسایی خرابی داده‌ها         |
| emergency  | سیستم غیرقابل استفاده       | خرابی کامل سیستم             |

## پیاده‌سازی اعلان‌ها در MCP

برای پیاده‌سازی اعلان‌ها در MCP باید سمت سرور و کلاینت را طوری تنظیم کنید که به‌روزرسانی‌های بلادرنگ را مدیریت کنند. این امکان را به برنامه شما می‌دهد که در طول عملیات طولانی بازخورد فوری به کاربران ارائه دهد.

### سمت سرور: ارسال اعلان‌ها

بیایید از سمت سرور شروع کنیم. در MCP شما ابزارهایی تعریف می‌کنید که هنگام پردازش درخواست‌ها می‌توانند اعلان ارسال کنند. سرور از شیء context (معمولاً `ctx`) برای ارسال پیام‌ها به کلاینت استفاده می‌کند.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

در مثال بالا، `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` حمل‌ونقل:

```python
mcp.run(transport="streamable-http")
```

</details>

### سمت کلاینت: دریافت اعلان‌ها

کلاینت باید یک هندلر پیام پیاده‌سازی کند تا اعلان‌ها را هنگام رسیدن پردازش و نمایش دهد.

<details>
<summary>Python</summary>

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

در کد بالا، `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) و کلاینت شما هندلری برای پردازش اعلان‌ها پیاده‌سازی می‌کند.

## اعلان‌های پیشرفت و سناریوها

این بخش مفهوم اعلان‌های پیشرفت در MCP، اهمیت آن‌ها و نحوه پیاده‌سازی با استفاده از Streamable HTTP را توضیح می‌دهد. همچنین یک تمرین عملی برای تثبیت یادگیری ارائه شده است.

اعلان‌های پیشرفت پیام‌های بلادرنگی هستند که از سرور به کلاینت در طول عملیات طولانی ارسال می‌شوند. به جای انتظار برای پایان کل فرآیند، سرور کلاینت را از وضعیت جاری مطلع نگه می‌دارد. این کار شفافیت، تجربه کاربری و اشکال‌زدایی را بهبود می‌بخشد.

**مثال:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### چرا از اعلان‌های پیشرفت استفاده کنیم؟

اعلان‌های پیشرفت به دلایل زیر اهمیت دارند:

- **تجربه کاربری بهتر:** کاربران به محض پیشرفت کار، به‌روزرسانی‌ها را می‌بینند، نه فقط در پایان.
- **بازخورد بلادرنگ:** کلاینت‌ها می‌توانند نوارهای پیشرفت یا لاگ‌ها را نمایش دهند و برنامه را پاسخگو جلوه دهند.
- **اشکال‌زدایی و نظارت آسان‌تر:** توسعه‌دهندگان و کاربران می‌توانند ببینند فرآیند کجا ممکن است کند یا گیر کرده باشد.

### نحوه پیاده‌سازی اعلان‌های پیشرفت

در اینجا نحوه پیاده‌سازی اعلان‌های پیشرفت در MCP آمده است:

- **در سرور:** از `ctx.info()` or `ctx.log()` برای ارسال اعلان‌ها به محض پردازش هر آیتم استفاده کنید. این پیام‌ها قبل از آماده شدن نتیجه اصلی به کلاینت ارسال می‌شوند.
- **در کلاینت:** یک هندلر پیام پیاده‌سازی کنید که به اعلان‌ها گوش داده و آن‌ها را هنگام رسیدن نمایش دهد. این هندلر باید بین اعلان‌ها و نتیجه نهایی تمایز قائل شود.

**مثال سرور:**

<details>
<summary>Python</summary>

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
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## ملاحظات امنیتی

هنگام پیاده‌سازی سرورهای MCP با حمل‌ونقل‌های مبتنی بر HTTP، امنیت به یک نگرانی حیاتی تبدیل می‌شود که نیازمند توجه دقیق به چندین بردار حمله و مکانیزم‌های حفاظتی است.

### مرور کلی

امنیت هنگام در معرض قرار دادن سرورهای MCP از طریق HTTP بسیار مهم است. Streamable HTTP سطوح حمله جدیدی ایجاد می‌کند و نیازمند پیکربندی دقیق است.

### نکات کلیدی
- **اعتبارسنجی هدر Origin**: همیشه مقدار `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` را اعتبارسنجی کنید، نه کلاینت SSE.
3. **پیاده‌سازی هندلر پیام** در کلاینت برای پردازش اعلان‌ها.
4. **آزمایش سازگاری** با ابزارها و گردش‌های کاری موجود.

### حفظ سازگاری

توصیه می‌شود در طول فرآیند مهاجرت، سازگاری با کلاینت‌های SSE موجود حفظ شود. چند استراتژی عبارتند از:

- می‌توانید هر دو SSE و Streamable HTTP را با اجرای هر دو مکانیزم روی نقاط انتهایی مختلف پشتیبانی کنید.
- به تدریج کلاینت‌ها را به حمل‌ونقل جدید منتقل کنید.

### چالش‌ها

در طول مهاجرت باید به این چالش‌ها رسیدگی کنید:

- اطمینان از به‌روزرسانی همه کلاینت‌ها
- مدیریت تفاوت‌ها در نحوه تحویل اعلان‌ها

### تمرین: ساخت اپلیکیشن استریمینگ MCP خودتان

**سناریو:**
یک سرور و کلاینت MCP بسازید که سرور فهرستی از آیتم‌ها (مثلاً فایل‌ها یا اسناد) را پردازش کرده و برای هر آیتم پردازش‌شده یک اعلان ارسال کند. کلاینت باید هر اعلان را به محض رسیدن نمایش دهد.

**مراحل:**

1. ابزار سرور را پیاده‌سازی کنید که فهرستی را پردازش کرده و برای هر آیتم اعلان ارسال کند.
2. کلاینتی پیاده‌سازی کنید که با هندلر پیام اعلان‌ها را بلادرنگ نمایش دهد.
3. پیاده‌سازی خود را با اجرای هم‌زمان سرور و کلاینت تست کنید و اعلان‌ها را مشاهده نمایید.

[Solution](./solution/README.md)

## مطالعه بیشتر و گام‌های بعدی

برای ادامه مسیر یادگیری استریمینگ MCP و گسترش دانش خود، این بخش منابع اضافی و گام‌های پیشنهادی بعدی برای ساخت برنامه‌های پیشرفته‌تر ارائه می‌دهد.

### مطالعه بیشتر

- [Microsoft: معرفی استریمینگ HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS در ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: درخواست‌های استریمینگ](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### گام بعدی؟

- سعی کنید ابزارهای MCP پیشرفته‌تری بسازید که از استریمینگ برای تحلیل‌های بلادرنگ، چت یا ویرایش تعاملی استفاده کنند.
- بررسی کنید چگونه می‌توان استریمینگ MCP را با فریم‌ورک‌های فرانت‌اند (مثل React، Vue و غیره) برای به‌روزرسانی‌های زنده رابط کاربری ترکیب کرد.
- گام بعدی: [استفاده از AI Toolkit برای VSCode](../07-aitk/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان مادری خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما در قبال هرگونه سوءتفاهم یا تفسیر نادرست ناشی از استفاده از این ترجمه مسئولیتی نداریم.