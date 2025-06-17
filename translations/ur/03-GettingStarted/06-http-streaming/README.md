<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T21:55:22+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ur"
}
-->
# HTTPS اسٹریمنگ ماڈل کانٹیکسٹ پروٹوکول (MCP) کے ساتھ

یہ باب ماڈل کانٹیکسٹ پروٹوکول (MCP) کے ذریعے HTTPS استعمال کرتے ہوئے محفوظ، توسیع پذیر، اور حقیقی وقت کی اسٹریمنگ کو نافذ کرنے کے لیے جامع رہنمائی فراہم کرتا ہے۔ اس میں اسٹریمنگ کی تحریک، دستیاب ٹرانسپورٹ میکانزم، MCP میں اسٹریمنگ HTTP کو کیسے نافذ کیا جائے، سیکیورٹی کی بہترین مشقیں، SSE سے مائیگریشن، اور اپنے اسٹریمنگ MCP ایپلیکیشنز بنانے کے لیے عملی رہنمائی شامل ہے۔

## MCP میں ٹرانسپورٹ میکانزم اور اسٹریمنگ

یہ سیکشن MCP میں دستیاب مختلف ٹرانسپورٹ میکانزم اور کلائنٹس اور سرورز کے درمیان حقیقی وقت کے مواصلات کے لیے اسٹریمنگ کی صلاحیتوں کو فعال کرنے میں ان کے کردار کا جائزہ لیتا ہے۔

### ٹرانسپورٹ میکانزم کیا ہے؟

ٹرانسپورٹ میکانزم یہ طے کرتا ہے کہ کلائنٹ اور سرور کے درمیان ڈیٹا کیسے تبادلہ کیا جاتا ہے۔ MCP مختلف ماحول اور ضروریات کے مطابق متعدد ٹرانسپورٹ اقسام کو سپورٹ کرتا ہے:

- **stdio**: اسٹینڈرڈ ان پٹ/آؤٹ پٹ، جو لوکل اور CLI پر مبنی ٹولز کے لیے موزوں ہے۔ سادہ لیکن ویب یا کلاؤڈ کے لیے مناسب نہیں۔
- **SSE (سرور سینٹ ایونٹس)**: سرورز کو HTTP کے ذریعے کلائنٹس کو حقیقی وقت کی اپڈیٹس بھیجنے کی اجازت دیتا ہے۔ ویب یوزر انٹرفیس کے لیے اچھا، لیکن توسیع پذیری اور لچک میں محدود۔
- **Streamable HTTP**: جدید HTTP پر مبنی اسٹریمنگ ٹرانسپورٹ، نوٹیفیکیشنز اور بہتر توسیع پذیری کی حمایت کرتا ہے۔ زیادہ تر پروڈکشن اور کلاؤڈ کے منظرناموں کے لیے تجویز کیا جاتا ہے۔

### موازنہ جدول

مندرجہ ذیل موازنہ جدول دیکھیں تاکہ ان ٹرانسپورٹ میکانزم کے درمیان فرق کو سمجھ سکیں:

| ٹرانسپورٹ         | حقیقی وقت کی اپڈیٹس | اسٹریمنگ | توسیع پذیری | استعمال کا کیس                |
|-------------------|--------------------|-----------|-------------|------------------------------|
| stdio             | نہیں               | نہیں      | کم          | لوکل CLI ٹولز                |
| SSE               | ہاں                | ہاں       | درمیانہ    | ویب، حقیقی وقت کی اپڈیٹس     |
| Streamable HTTP   | ہاں                | ہاں       | زیادہ       | کلاؤڈ، ملٹی کلائنٹ           |

> **Tip:** درست ٹرانسپورٹ کا انتخاب کارکردگی، توسیع پذیری، اور صارف کے تجربے پر اثر انداز ہوتا ہے۔ جدید، توسیع پذیر، اور کلاؤڈ کے لیے تیار ایپلیکیشنز کے لیے **Streamable HTTP** کی سفارش کی جاتی ہے۔

نوٹ کریں کہ stdio اور SSE ٹرانسپورٹس جو آپ کو پچھلے ابواب میں دکھائے گئے تھے، اور اس باب میں جس ٹرانسپورٹ پر بات کی گئی ہے وہ Streamable HTTP ہے۔

## اسٹریمنگ: تصورات اور محرکات

اسٹریمنگ کے بنیادی تصورات اور محرکات کو سمجھنا مؤثر حقیقی وقت کے مواصلاتی نظام بنانے کے لیے ضروری ہے۔

**اسٹریمنگ** نیٹ ورک پروگرامنگ کی ایک تکنیک ہے جو ڈیٹا کو چھوٹے، قابلِ انتظام حصوں میں یا ایونٹس کی ترتیب کے طور پر بھیجنے اور وصول کرنے کی اجازت دیتی ہے، بجائے اس کے کہ پورا جواب تیار ہونے تک انتظار کیا جائے۔ یہ خاص طور پر مفید ہے:

- بڑے فائلز یا ڈیٹا سیٹس کے لیے۔
- حقیقی وقت کی اپڈیٹس (مثلاً چیٹ، پروگریس بارز) کے لیے۔
- طویل دورانیے کے کمپیوٹیشنز جہاں آپ صارف کو باخبر رکھنا چاہتے ہیں۔

یہاں اسٹریمنگ کے بارے میں آپ کو اعلیٰ سطح پر جاننے کی ضرورت ہے:

- ڈیٹا تدریجی طور پر پہنچایا جاتا ہے، تمام ایک ساتھ نہیں۔
- کلائنٹ ڈیٹا کو جیسے ہی وصول کرے پراسیس کر سکتا ہے۔
- محسوس شدہ تاخیر کو کم کرتا ہے اور صارف کے تجربے کو بہتر بناتا ہے۔

### اسٹریمنگ کیوں استعمال کریں؟

اسٹریمنگ کے استعمال کی وجوہات درج ذیل ہیں:

- صارفین کو فوری فیڈبیک ملتا ہے، صرف آخر میں نہیں۔
- حقیقی وقت کی ایپلیکیشنز اور ردعمل دینے والے یوزر انٹرفیس کو فعال کرتا ہے۔
- نیٹ ورک اور کمپیوٹ وسائل کا زیادہ مؤثر استعمال۔

### سادہ مثال: HTTP اسٹریمنگ سرور اور کلائنٹ

یہاں ایک سادہ مثال ہے کہ اسٹریمنگ کو کیسے نافذ کیا جا سکتا ہے:

<details>
<summary>Python</summary>

**سرور (Python، FastAPI اور StreamingResponse استعمال کرتے ہوئے):**
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

**کلائنٹ (Python، requests استعمال کرتے ہوئے):**
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

یہ مثال سرور کی طرف سے کلائنٹ کو میسجز کی ایک سیریز بھیجنے کا مظاہرہ کرتی ہے جیسے ہی وہ دستیاب ہوتے ہیں، بجائے اس کے کہ تمام میسجز کے تیار ہونے کا انتظار کیا جائے۔

**یہ کیسے کام کرتا ہے:**
- سرور ہر میسج کو جیسے ہی تیار ہو جاری کرتا ہے۔
- کلائنٹ ہر حصہ وصول کر کے پرنٹ کرتا ہے۔

**ضروریات:**
- سرور کو اسٹریمنگ رسپانس استعمال کرنا چاہیے (مثلاً `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) بجائے MCP کے ذریعے اسٹریمنگ کا انتخاب کرنے کے۔

- **سادہ اسٹریمنگ کی ضرورتوں کے لیے:** کلاسیکی HTTP اسٹریمنگ کو نافذ کرنا آسان ہے اور بنیادی اسٹریمنگ کے لیے کافی ہے۔

- **پیچیدہ، انٹرایکٹو ایپلیکیشنز کے لیے:** MCP اسٹریمنگ ایک زیادہ منظم طریقہ فراہم کرتا ہے جس میں زیادہ تفصیلی میٹا ڈیٹا اور نوٹیفیکیشنز اور آخری نتائج کے درمیان علیحدگی ہوتی ہے۔

- **AI ایپلیکیشنز کے لیے:** MCP کا نوٹیفیکیشن سسٹم طویل مدتی AI کاموں کے لیے خاص طور پر مفید ہے جہاں آپ صارفین کو پیش رفت سے باخبر رکھنا چاہتے ہیں۔

## MCP میں اسٹریمنگ

ٹھیک ہے، اب تک آپ نے کلاسیکی اسٹریمنگ اور MCP میں اسٹریمنگ کے درمیان کچھ سفارشات اور موازنہ دیکھا ہے۔ آئیے تفصیل سے جانتے ہیں کہ آپ MCP میں اسٹریمنگ کو کیسے استعمال کر سکتے ہیں۔

MCP فریم ورک کے اندر اسٹریمنگ کیسے کام کرتی ہے یہ سمجھنا ضروری ہے تاکہ آپ ایسی ایپلیکیشنز بنا سکیں جو طویل عمل کے دوران صارف کو حقیقی وقت کا فیڈبیک فراہم کریں۔

MCP میں، اسٹریمنگ کا مطلب بنیادی جواب کو ٹکڑوں میں بھیجنا نہیں بلکہ درخواست کے عمل کے دوران کلائنٹ کو **نوٹیفیکیشنز** بھیجنا ہے۔ یہ نوٹیفیکیشنز پیش رفت کی اپڈیٹس، لاگز، یا دیگر ایونٹس ہو سکتے ہیں۔

### یہ کیسے کام کرتا ہے

بنیادی نتیجہ اب بھی ایک ہی رسپانس کے طور پر بھیجا جاتا ہے۔ تاہم، نوٹیفیکیشنز کو عملدرآمد کے دوران الگ میسجز کی صورت میں بھیجا جا سکتا ہے تاکہ کلائنٹ کو حقیقی وقت میں اپڈیٹ کیا جا سکے۔ کلائنٹ کو ان نوٹیفیکیشنز کو ہینڈل اور ڈسپلے کرنے کے قابل ہونا چاہیے۔

## نوٹیفیکیشن کیا ہے؟

ہم نے "نوٹیفیکیشن" کا ذکر کیا، MCP کے سیاق و سباق میں اس کا کیا مطلب ہے؟

نوٹیفیکیشن ایک پیغام ہوتا ہے جو سرور کی طرف سے کلائنٹ کو بھیجا جاتا ہے تاکہ طویل عمل کے دوران پیش رفت، حیثیت، یا دیگر واقعات کے بارے میں آگاہ کیا جا سکے۔ نوٹیفیکیشنز شفافیت اور صارف کے تجربے کو بہتر بناتے ہیں۔

مثال کے طور پر، ایک کلائنٹ کو سرور کے ساتھ ابتدائی ہینڈشیک مکمل ہونے کے بعد نوٹیفیکیشن بھیجنی ہوتی ہے۔

نوٹیفیکیشن JSON پیغام کی شکل میں کچھ یوں نظر آتی ہے:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

نوٹیفیکیشنز MCP میں ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) کے موضوع سے تعلق رکھتی ہیں۔

لاگنگ کو فعال کرنے کے لیے سرور کو اسے فیچر/صلاحیت کے طور پر یوں فعال کرنا پڑتا ہے:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> استعمال شدہ SDK کے مطابق، لاگنگ ڈیفالٹ میں فعال ہو سکتی ہے، یا آپ کو اسے سرور کی کنفیگریشن میں واضح طور پر فعال کرنا پڑے گا۔

نوٹیفیکیشنز کی مختلف اقسام ہیں:

| سطح       | وضاحت                         | مثال کا استعمال                  |
|-----------|------------------------------|---------------------------------|
| debug     | تفصیلی ڈیبگنگ معلومات        | فنکشن کے داخلے/خروج کے پوائنٹس  |
| info      | عمومی معلوماتی پیغامات       | آپریشن کی پیش رفت کی اپڈیٹس      |
| notice    | معمول کے مگر اہم واقعات       | کنفیگریشن میں تبدیلیاں           |
| warning   | وارننگ کی حالتیں             | پرانی خصوصیات کا استعمال        |
| error     | غلطی کی حالتیں               | آپریشن کی ناکامیاں              |
| critical  | سنگین حالتیں                 | سسٹم کے اجزاء کی ناکامیاں        |
| alert     | فوری کارروائی ضروری ہے       | ڈیٹا کرپشن کا پتہ چلنا          |
| emergency | سسٹم ناقابل استعمال ہے       | مکمل سسٹم فیلیر                 |

## MCP میں نوٹیفیکیشنز کا نفاذ

MCP میں نوٹیفیکیشنز نافذ کرنے کے لیے، آپ کو سرور اور کلائنٹ دونوں طرف حقیقی وقت کی اپڈیٹس سنبھالنے کے لیے ترتیب دینا ہوگا۔ اس سے آپ کی ایپلیکیشن طویل عمل کے دوران صارفین کو فوری فیڈبیک فراہم کر سکتی ہے۔

### سرور سائیڈ: نوٹیفیکیشنز بھیجنا

آئیے سرور سائیڈ سے شروع کرتے ہیں۔ MCP میں، آپ ایسے ٹولز کی تعریف کرتے ہیں جو درخواستوں کو پروسیس کرتے ہوئے نوٹیفیکیشنز بھیج سکتے ہیں۔ سرور کلائنٹ کو پیغامات بھیجنے کے لیے عام طور پر `ctx` نامی کانٹیکسٹ آبجیکٹ استعمال کرتا ہے۔

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

### کلائنٹ سائیڈ: نوٹیفیکیشنز وصول کرنا

کلائنٹ کو ایک میسج ہینڈلر نافذ کرنا چاہیے جو نوٹیفیکیشنز کو وصول کر کے پراسیس اور ڈسپلے کرے۔

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

پچھلے کوڈ میں، `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) اور آپ کا کلائنٹ نوٹیفیکیشنز کو پراسیس کرنے کے لیے ایک میسج ہینڈلر نافذ کرتا ہے۔

## پیش رفت کی نوٹیفیکیشنز اور منظرنامے

یہ سیکشن MCP میں پیش رفت کی نوٹیفیکیشنز کے تصور، ان کی اہمیت، اور Streamable HTTP استعمال کرتے ہوئے انہیں کیسے نافذ کیا جائے، کی وضاحت کرتا ہے۔ آپ کو اپنی سمجھ بوجھ کو مضبوط کرنے کے لیے ایک عملی مشق بھی ملے گی۔

پیش رفت کی نوٹیفیکیشنز وہ حقیقی وقت کے پیغامات ہیں جو سرور طویل عمل کے دوران کلائنٹ کو بھیجتا ہے۔ پورے عمل کے ختم ہونے کا انتظار کرنے کے بجائے، سرور کلائنٹ کو موجودہ صورتحال سے باخبر رکھتا ہے۔ اس سے شفافیت، صارف کا تجربہ بہتر ہوتا ہے، اور ڈیبگنگ آسان ہو جاتی ہے۔

**مثال:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### پیش رفت کی نوٹیفیکیشنز کیوں استعمال کریں؟

پیش رفت کی نوٹیفیکیشنز کئی وجوہات کی بنا پر ضروری ہیں:

- **بہتر صارف تجربہ:** صارفین کام کی پیش رفت کو دیکھتے ہیں، صرف آخر میں نہیں۔
- **حقیقی وقت کا فیڈبیک:** کلائنٹس پروگریس بارز یا لاگز دکھا سکتے ہیں، جس سے ایپلیکیشن زیادہ ردعمل دکھاتی ہے۔
- **آسان ڈیبگنگ اور مانیٹرنگ:** ڈویلپرز اور صارفین دیکھ سکتے ہیں کہ عمل کہاں سست یا رکا ہوا ہے۔

### پیش رفت کی نوٹیفیکیشنز کیسے نافذ کریں

یہاں MCP میں پیش رفت کی نوٹیفیکیشنز کو نافذ کرنے کا طریقہ ہے:

- **سرور پر:** `ctx.info()` or `ctx.log()` استعمال کریں تاکہ ہر آئٹم کے پراسیس ہوتے ہی نوٹیفیکیشن بھیجی جائے۔ یہ بنیادی نتیجہ تیار ہونے سے پہلے کلائنٹ کو پیغام بھیجتا ہے۔
- **کلائنٹ پر:** ایک میسج ہینڈلر نافذ کریں جو نوٹیفیکیشنز کو سن کر انہیں ڈسپلے کرے۔ یہ ہینڈلر نوٹیفیکیشنز اور آخری نتیجہ میں فرق کرتا ہے۔

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

جب MCP سرورز کو HTTP پر مبنی ٹرانسپورٹس کے ساتھ نافذ کیا جاتا ہے تو سیکیورٹی ایک نہایت اہم مسئلہ بن جاتی ہے جس کے لیے متعدد حملوں اور حفاظتی میکانزم پر دھیان دینا ضروری ہے۔

### جائزہ

HTTP پر MCP سرورز کو ظاہر کرتے وقت سیکیورٹی انتہائی اہم ہے۔ Streamable HTTP نئے حملوں کے امکانات پیدا کرتا ہے اور محتاط کنفیگریشن کا تقاضا کرتا ہے۔

### اہم نکات
- **Origin ہیڈر کی تصدیق:** ہمیشہ `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` کی تصدیق کریں، SSE کلائنٹ کے بجائے۔
3. **کلائنٹ میں میسج ہینڈلر نافذ کریں** تاکہ نوٹیفیکیشنز کو پراسیس کیا جا سکے۔
4. **موجودہ ٹولز اور ورک فلو کے ساتھ مطابقت کی جانچ کریں۔**

### مطابقت کو برقرار رکھنا

مائیگریشن کے دوران موجودہ SSE کلائنٹس کے ساتھ مطابقت برقرار رکھنا تجویز کیا جاتا ہے۔ یہاں کچھ حکمت عملیاں ہیں:

- آپ دونوں SSE اور Streamable HTTP کو مختلف اینڈپوائنٹس پر چلا کر سپورٹ کر سکتے ہیں۔
- کلائنٹس کو نئے ٹرانسپورٹ پر آہستہ آہستہ منتقل کریں۔

### چیلنجز

مائیگریشن کے دوران درج ذیل چیلنجز کا حل یقینی بنائیں:

- تمام کلائنٹس کو اپ ڈیٹ کرنا
- نوٹیفیکیشن ڈیلیوری میں فرق کو سنبھالنا

### مشق: اپنی اسٹریمنگ MCP ایپ بنائیں

**منظرنامہ:**
ایک MCP سرور اور کلائنٹ بنائیں جہاں سرور آئٹمز کی فہرست (مثلاً فائلز یا دستاویزات) کو پروسیس کرے اور ہر پراسیس شدہ آئٹم کے لیے نوٹیفیکیشن بھیجے۔ کلائنٹ کو ہر نوٹیفیکیشن کو جیسے ہی ملے دکھانا چاہیے۔

**اقدامات:**

1. ایک سرور ٹول نافذ کریں جو فہرست کو پروسیس کرے اور ہر آئٹم کے لیے نوٹیفیکیشنز بھیجے۔
2. ایک کلائنٹ نافذ کریں جس میں میسج ہینڈلر ہو جو نوٹیفیکیشنز کو حقیقی وقت میں دکھائے۔
3. اپنے نفاذ کو سرور اور کلائنٹ دونوں کو چلانے کے ذریعے آزمائیں اور نوٹیفیکیشنز کا مشاہدہ کریں۔

[Solution](./solution/README.md)

## مزید مطالعہ اور آگے کیا؟

اپنی MCP اسٹریمنگ کی سفر جاری رکھنے اور اپنے علم کو بڑھانے کے لیے، یہ سیکشن اضافی وسائل اور زیادہ پیچیدہ ایپلیکیشنز بنانے کے لیے اگلے اقدامات فراہم کرتا ہے۔

### مزید مطالعہ

- [Microsoft: HTTP اسٹریمنگ کا تعارف](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core میں CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: اسٹریمنگ ر

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تعبیر کی ذمہ داری ہم پر عائد نہیں ہوتی۔