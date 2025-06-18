<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:38:10+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ur"
}
-->
# HTTPS اسٹریمِنگ ود ماڈل کانٹیکسٹ پروٹوکول (MCP)

یہ باب HTTPS کے ذریعے ماڈل کانٹیکسٹ پروٹوکول (MCP) کے ساتھ محفوظ، قابل توسیع، اور حقیقی وقت کی اسٹریمِنگ کو نافذ کرنے کے لیے جامع رہنمائی فراہم کرتا ہے۔ اس میں اسٹریمِنگ کی ترغیب، دستیاب ٹرانسپورٹ میکانزم، MCP میں اسٹریم ایبل HTTP کو کیسے نافذ کیا جائے، سیکیورٹی کی بہترین مشقیں، SSE سے مائگریشن، اور اپنے اسٹریمِنگ MCP ایپلیکیشنز بنانے کے عملی مشورے شامل ہیں۔

## MCP میں ٹرانسپورٹ میکانزم اور اسٹریمِنگ

اس حصے میں MCP میں دستیاب مختلف ٹرانسپورٹ میکانزم اور ان کا کلائنٹس اور سرورز کے درمیان حقیقی وقت کی بات چیت کے لیے اسٹریمِنگ کی صلاحیتیں فراہم کرنے میں کردار کا جائزہ لیا گیا ہے۔

### ٹرانسپورٹ میکانزم کیا ہے؟

ٹرانسپورٹ میکانزم اس بات کی وضاحت کرتا ہے کہ ڈیٹا کلائنٹ اور سرور کے درمیان کیسے تبادلہ کیا جاتا ہے۔ MCP مختلف ماحول اور ضروریات کے مطابق متعدد ٹرانسپورٹ اقسام کی حمایت کرتا ہے:

- **stdio**: معیاری ان پٹ/آؤٹ پٹ، مقامی اور CLI پر مبنی ٹولز کے لیے موزوں۔ آسان مگر ویب یا کلاؤڈ کے لیے مناسب نہیں۔
- **SSE (سرور-سینٹ ایونٹس)**: سرورز کو HTTP کے ذریعے کلائنٹس کو حقیقی وقت کی تازہ کاری بھیجنے کی اجازت دیتا ہے۔ ویب UIs کے لیے اچھا ہے، لیکن اسکیل ایبلیٹی اور لچک میں محدود ہے۔
- **Streamable HTTP**: جدید HTTP پر مبنی اسٹریمِنگ ٹرانسپورٹ، نوٹیفیکیشنز اور بہتر اسکیل ایبلیٹی کی حمایت کرتا ہے۔ زیادہ تر پروڈکشن اور کلاؤڈ حالات کے لیے سفارش کی جاتی ہے۔

### موازنہ جدول

ذیل میں موازنہ جدول دیکھیں تاکہ ان ٹرانسپورٹ میکانزمز کے درمیان فرق کو سمجھ سکیں:

| ٹرانسپورٹ          | حقیقی وقت کی تازہ کاری | اسٹریمِنگ | اسکیل ایبلیٹی | استعمال کا کیس              |
|---------------------|-----------------------|-----------|--------------|----------------------------|
| stdio               | نہیں                  | نہیں      | کم           | مقامی CLI ٹولز             |
| SSE                 | ہاں                   | ہاں       | درمیانہ      | ویب، حقیقی وقت کی تازہ کاری|
| Streamable HTTP     | ہاں                   | ہاں       | زیادہ        | کلاؤڈ، ملٹی کلائنٹ         |

> **Tip:** صحیح ٹرانسپورٹ کا انتخاب کارکردگی، اسکیل ایبلیٹی، اور صارف کے تجربے پر اثر انداز ہوتا ہے۔ جدید، قابل توسیع، اور کلاؤڈ کے لیے تیار ایپلیکیشنز کے لیے **Streamable HTTP** کی سفارش کی جاتی ہے۔

پچھلے ابواب میں دکھائے گئے stdio اور SSE ٹرانسپورٹس کو نوٹ کریں اور دیکھیں کہ اس باب میں اسٹریم ایبل HTTP کو کور کیا گیا ہے۔

## اسٹریمِنگ: تصورات اور ترغیب

اسٹریمِنگ کے بنیادی تصورات اور محرکات کو سمجھنا مؤثر حقیقی وقت کی بات چیت کے نظام بنانے کے لیے ضروری ہے۔

**اسٹریمِنگ** نیٹ ورک پروگرامنگ کی ایک تکنیک ہے جو ڈیٹا کو چھوٹے، قابل انتظام حصوں یا ایونٹس کی ترتیب کے طور پر بھیجنے اور وصول کرنے کی اجازت دیتی ہے، بجائے اس کے کہ پورا جواب مکمل ہونے کا انتظار کیا جائے۔ یہ خاص طور پر مفید ہے:

- بڑے فائلز یا ڈیٹا سیٹس کے لیے۔
- حقیقی وقت کی تازہ کاریوں کے لیے (مثلاً چیٹ، پروگریس بارز)۔
- طویل مدتی حسابات جہاں آپ صارف کو معلومات دیتے رہنا چاہتے ہیں۔

یہاں اسٹریمِنگ کے بارے میں اعلی سطح پر جاننے والی باتیں ہیں:

- ڈیٹا بتدریج پہنچایا جاتا ہے، ایک ساتھ نہیں۔
- کلائنٹ ڈیٹا کو جیسے ہی پہنچتا ہے پراسیس کر سکتا ہے۔
- محسوس شدہ تاخیر کو کم کرتا ہے اور صارف کے تجربے کو بہتر بناتا ہے۔

### اسٹریمِنگ کیوں استعمال کریں؟

اسٹریمِنگ استعمال کرنے کی وجوہات درج ذیل ہیں:

- صارفین کو فوری فیڈبیک ملتا ہے، نہ کہ صرف آخر میں۔
- حقیقی وقت کی ایپلیکیشنز اور ردعمل دینے والی UIs ممکن بناتا ہے۔
- نیٹ ورک اور کمپیوٹ وسائل کا زیادہ مؤثر استعمال۔

### آسان مثال: HTTP اسٹریمِنگ سرور اور کلائنٹ

یہاں ایک آسان مثال ہے کہ اسٹریمِنگ کیسے نافذ کی جا سکتی ہے:

<details>
<summary>Python</summary>

**سرور (Python، FastAPI اور StreamingResponse کا استعمال):**
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

**کلائنٹ (Python، requests کا استعمال):**
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

یہ مثال دکھاتی ہے کہ سرور پیغامات کی ایک سیریز کلائنٹ کو بھیج رہا ہے جیسے ہی وہ دستیاب ہوتے ہیں، بجائے اس کے کہ تمام پیغامات کی تیاری کا انتظار کرے۔

**کام کرنے کا طریقہ:**
- سرور ہر پیغام کو جیسے ہی تیار ہو پیش کرتا ہے۔
- کلائنٹ ہر حصے کو وصول کر کے پرنٹ کرتا ہے۔

**ضروریات:**
- سرور کو اسٹریمِنگ ریسپانس استعمال کرنا چاہیے (مثلاً `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`۔

</details>

<details>
<summary>Java</summary>

**سرور (Java، Spring Boot اور Server-Sent Events کا استعمال):**

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

**کلائنٹ (Java، Spring WebFlux WebClient کا استعمال):**

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

**Java نفاذ کے نوٹس:**
- Spring Boot کے reactive stack کا استعمال کرتا ہے جیسے `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) بمقابلہ MCP کے ذریعے اسٹریمِنگ کا انتخاب۔

- **سادہ اسٹریمِنگ کے لیے:** کلاسک HTTP اسٹریمِنگ آسان اور بنیادی ضروریات کے لیے کافی ہے۔

- **پیچیدہ، تعاملی ایپلیکیشنز کے لیے:** MCP اسٹریمِنگ زیادہ منظم طریقہ فراہم کرتا ہے، جس میں زیادہ میٹا ڈیٹا اور نوٹیفیکیشنز اور حتمی نتائج کے درمیان علیحدگی شامل ہے۔

- **AI ایپلیکیشنز کے لیے:** MCP کا نوٹیفیکیشن سسٹم طویل مدتی AI کاموں کے لیے خاص طور پر مفید ہے جہاں آپ صارفین کو پیش رفت سے آگاہ رکھنا چاہتے ہیں۔

## MCP میں اسٹریمِنگ

ٹھیک ہے، آپ نے اب تک کلاسیکی اسٹریمِنگ اور MCP میں اسٹریمِنگ کے فرق پر کچھ سفارشات اور موازنہ دیکھا ہے۔ آئیے تفصیل سے جانتے ہیں کہ آپ MCP میں اسٹریمِنگ کو کیسے استعمال کر سکتے ہیں۔

MCP فریم ورک میں اسٹریمِنگ کے کام کرنے کے طریقے کو سمجھنا ایسے ردعمل دینے والے ایپلیکیشنز بنانے کے لیے ضروری ہے جو طویل مدتی آپریشنز کے دوران صارفین کو حقیقی وقت کی معلومات فراہم کریں۔

MCP میں اسٹریمِنگ کا مطلب یہ نہیں کہ مرکزی جواب کو ٹکڑوں میں بھیجا جائے، بلکہ اس کا مطلب ہے کہ کلائنٹ کو نوٹیفیکیشنز بھیجی جائیں جب کوئی ٹول درخواست پر کام کر رہا ہو۔ یہ نوٹیفیکیشنز پیش رفت کی تازہ کاری، لاگز، یا دیگر ایونٹس ہو سکتے ہیں۔

### یہ کیسے کام کرتا ہے

مرکزی نتیجہ اب بھی ایک واحد جواب کے طور پر بھیجا جاتا ہے۔ تاہم، پروسیسنگ کے دوران نوٹیفیکیشنز کو علیحدہ پیغامات کے طور پر بھیجا جا سکتا ہے تاکہ کلائنٹ کو حقیقی وقت میں اپ ڈیٹ کیا جا سکے۔ کلائنٹ کو یہ نوٹیفیکیشنز سنبھالنے اور دکھانے کے قابل ہونا چاہیے۔

## نوٹیفیکیشن کیا ہے؟

ہم نے "نوٹیفیکیشن" کہا، MCP کے سیاق و سباق میں اس کا کیا مطلب ہے؟

نوٹیفیکیشن ایک پیغام ہے جو سرور سے کلائنٹ کو بھیجا جاتا ہے تاکہ طویل مدتی آپریشن کے دوران پیش رفت، حیثیت، یا دیگر ایونٹس کے بارے میں آگاہ کرے۔ نوٹیفیکیشنز شفافیت اور صارف کے تجربے کو بہتر بناتی ہیں۔

مثال کے طور پر، کلائنٹ کو ایک نوٹیفیکیشن بھیجنی چاہیے جب سرور کے ساتھ ابتدائی ہینڈشیک مکمل ہو جائے۔

نوٹیفیکیشن JSON پیغام کی صورت میں کچھ اس طرح نظر آتی ہے:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

نوٹیفیکیشنز MCP میں ایک موضوع سے تعلق رکھتی ہیں جسے ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) کہا جاتا ہے۔

لاگنگ کو فعال کرنے کے لیے، سرور کو اسے فیچر/صلاحیت کے طور پر فعال کرنا ہوتا ہے جیسا کہ درج ذیل ہے:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> استعمال ہونے والے SDK کے مطابق، لاگنگ ڈیفالٹ کے طور پر فعال ہو سکتی ہے، یا آپ کو سرور کی کنفیگریشن میں اسے واضح طور پر فعال کرنا پڑ سکتا ہے۔

نوٹیفیکیشنز کی مختلف اقسام ہیں:

| سطح        | وضاحت                          | استعمال کی مثال                |
|------------|-------------------------------|------------------------------|
| debug      | تفصیلی ڈیبگ معلومات           | فنکشن کے داخلے/خروج پوائنٹس  |
| info       | عمومی معلوماتی پیغامات       | آپریشن کی پیش رفت کی تازہ کاری|
| notice     | معمولی مگر اہم واقعات          | کنفیگریشن کی تبدیلیاں        |
| warning    | انتباہی حالتیں                 | پرانی خصوصیات کا استعمال    |
| error      | خرابی کی حالتیں                | آپریشن کی ناکامیاں           |
| critical   | سنگین حالتیں                  | سسٹم کے اجزاء کی ناکامیاں    |
| alert      | فوری کارروائی کی ضرورت          | ڈیٹا کرپشن کا پتہ چلنا       |
| emergency  | سسٹم ناقابل استعمال            | مکمل سسٹم فیل ہونا           |

## MCP میں نوٹیفیکیشنز کا نفاذ

MCP میں نوٹیفیکیشنز نافذ کرنے کے لیے، آپ کو سرور اور کلائنٹ دونوں طرف حقیقی وقت کی تازہ کاریوں کو سنبھالنے کے لیے ترتیب دینا ہوگا۔ اس سے آپ کی ایپلیکیشن طویل آپریشنز کے دوران صارفین کو فوری فیڈبیک فراہم کر سکتی ہے۔

### سرور سائیڈ: نوٹیفیکیشنز بھیجنا

آئیے سرور کی جانب سے شروع کرتے ہیں۔ MCP میں، آپ ایسے ٹولز تعریف کرتے ہیں جو درخواستوں پر کام کرتے ہوئے نوٹیفیکیشنز بھیج سکتے ہیں۔ سرور کنٹیکسٹ آبجیکٹ (عام طور پر `ctx`) استعمال کرتا ہے تاکہ کلائنٹ کو پیغامات بھیجے جا سکیں۔

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

پچھلی مثال میں، `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ٹرانسپورٹ:

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

اس .NET مثال میں، `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` طریقہ معلوماتی پیغامات بھیجنے کے لیے استعمال ہوتا ہے۔

اپنے .NET MCP سرور میں نوٹیفیکیشنز کو فعال کرنے کے لیے، یقینی بنائیں کہ آپ اسٹریمِنگ ٹرانسپورٹ استعمال کر رہے ہیں:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### کلائنٹ سائیڈ: نوٹیفیکیشنز وصول کرنا

کلائنٹ کو ایک میسج ہینڈلر نافذ کرنا ہوگا جو نوٹیفیکیشنز کو وصول کر کے ظاہر کرے۔

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

پچھلے کوڈ میں، `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` آنے والی نوٹیفیکیشنز کو سنبھالنے کے لیے استعمال ہوتا ہے۔

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

اس .NET مثال میں، `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` استعمال ہوتا ہے اور آپ کا کلائنٹ نوٹیفیکیشنز کو پراسیس کرنے کے لیے میسج ہینڈلر نافذ کرتا ہے۔

## پیش رفت کی نوٹیفیکیشنز اور منظرنامے

یہ سیکشن MCP میں پیش رفت کی نوٹیفیکیشنز کے تصور، ان کی اہمیت، اور Streamable HTTP کے ذریعے ان کے نفاذ کی وضاحت کرتا ہے۔ آپ کو اپنی سمجھ کو مضبوط کرنے کے لیے ایک عملی مشق بھی ملے گی۔

پیش رفت کی نوٹیفیکیشنز وہ حقیقی وقت کے پیغامات ہیں جو سرور طویل آپریشنز کے دوران کلائنٹ کو بھیجتا ہے۔ پورے عمل کے مکمل ہونے کا انتظار کرنے کے بجائے، سرور کلائنٹ کو موجودہ حیثیت سے آگاہ رکھتا ہے۔ اس سے شفافیت، صارف کے تجربے میں بہتری، اور ڈیبگنگ آسان ہوتی ہے۔

**مثال:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### پیش رفت کی نوٹیفیکیشنز کیوں استعمال کریں؟

پیش رفت کی نوٹیفیکیشنز کئی وجوہات کی بنا پر ضروری ہیں:

- **بہتر صارف تجربہ:** صارفین کام کی پیش رفت کو دیکھتے ہیں، نہ کہ صرف آخر میں۔
- **حقیقی وقت کا فیڈبیک:** کلائنٹس پروگریس بارز یا لاگز دکھا سکتے ہیں، جس سے ایپلیکیشن زیادہ ردعمل دینے والی محسوس ہوتی ہے۔
- **آسان ڈیبگنگ اور نگرانی:** ڈویلپرز اور صارفین دیکھ سکتے ہیں کہ عمل کہاں سست یا رکا ہوا ہے۔

### پیش رفت کی نوٹیفیکیشنز کیسے نافذ کریں

یہاں MCP میں پیش رفت کی نوٹیفیکیشنز نافذ کرنے کا طریقہ ہے:

- **سرور پر:** `ctx.info()` or `ctx.log()` استعمال کریں تاکہ ہر آئٹم کے پراسیس ہوتے وقت نوٹیفیکیشن بھیجی جا سکے۔ یہ مرکزی نتیجہ تیار ہونے سے پہلے کلائنٹ کو پیغام بھیجتا ہے۔
- **کلائنٹ پر:** ایک میسج ہینڈلر نافذ کریں جو نوٹیفیکیشنز کو سنتا اور دکھاتا ہے۔ یہ ہینڈلر نوٹیفیکیشنز اور حتمی نتیجہ میں فرق کرتا ہے۔

**سرور کی مثال:**

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

**کلائنٹ کی مثال:**

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

## سیکیورٹی کے پہلو

جب MCP سرورز کو HTTP پر مبنی ٹرانسپورٹس کے ساتھ نافذ کیا جاتا ہے، تو سیکیورٹی ایک اہم مسئلہ بن جاتی ہے جس کے لیے متعدد حملوں کے راستوں اور حفاظتی تدابیر پر غور کرنا ضروری ہوتا ہے۔

### جائزہ

HTTP پر MCP سرورز کو ظاہر کرتے وقت سیکیورٹی انتہائی اہم ہے۔ Streamable HTTP نئے حملے کے راستے متعارف کراتا ہے اور محتاط ترتیب کا متقاضی ہے۔

### اہم نکات
- **Origin Header کی تصدیق:** ہمیشہ `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` کی تصدیق کریں بجائے SSE کلائنٹ کے۔
3. **کلائنٹ میں میسج ہینڈلر نافذ کریں** تاکہ نوٹیفیکیشنز کو پراسیس کیا جا سکے۔
4. **موجودہ ٹولز اور ورک فلو کے ساتھ مطابقت کی جانچ کریں۔**

### مطابقت برقرار رکھنا

مائگریشن کے دوران موجودہ SSE کلائنٹس کے ساتھ مطابقت برقرار رکھنا تجویز کیا جاتا ہے۔ یہاں کچھ حکمت عملی ہیں:

- آپ دونوں SSE اور Streamable HTTP کو مختلف اینڈ پوائنٹس پر چلا کر دونوں کی حمایت کر سکتے ہیں۔
- کلائنٹس کو نئے ٹرانسپورٹ کی طرف آہستہ آہستہ منتقل کریں۔

### چیلنجز

مائگریشن کے دوران درج ذیل چیلنجز کا حل یقینی بنائیں:

- تمام کلائنٹس کو اپ ڈیٹ کرنا
- نوٹیفیکیشن کی ترسیل میں فرق کو سنبھالنا

### مشق: اپنی اسٹریمِنگ MCP ایپ بنائیں

**منظرنامہ:**
ایک MCP سرور اور کلائنٹ بنائیں جہاں سرور اشیاء کی فہرست (مثلاً فائلیں یا دستاویزات) کو پراسیس کرے اور ہر پراسیس شدہ آئٹم کے لیے نوٹیفیکیشن بھیجے۔ کلائنٹ کو چاہیے کہ وہ ہر نوٹیفیکیشن کو جیسے ہی پہنچے دکھائے۔

**قدم:**

1. ایک سرور ٹول نافذ کریں جو فہرست کو پراسیس کرے اور ہر آئٹم کے لیے نوٹیفیکیشنز بھیجے۔
2. ایک کلائنٹ نافذ کریں جس میں نوٹیفیکیشنز دکھانے کے لیے میسج ہینڈلر ہو۔
3. اپنے نفاذ کو سرور اور کلائنٹ دونوں چلانے کے ذریعے آزمائیں اور نوٹیفیک

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہِ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جائے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر نہیں ہوگی۔