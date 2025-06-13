<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:35:04+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ur"
}
-->
# HTTPS سٹریمنگ ود ماڈل کانٹیکسٹ پروٹوکول (MCP)

یہ باب HTTPS کے ذریعے ماڈل کانٹیکسٹ پروٹوکول (MCP) کے ساتھ محفوظ، قابل توسیع، اور حقیقی وقت کی سٹریمنگ کو نافذ کرنے کے لیے جامع رہنمائی فراہم کرتا ہے۔ اس میں سٹریمنگ کی تحریک، دستیاب ٹرانسپورٹ میکانزم، MCP میں اسٹریم ایبل HTTP کو کیسے نافذ کیا جائے، سیکیورٹی کی بہترین مشقیں، SSE سے مائیگریشن، اور اپنے خود کے سٹریمنگ MCP ایپلیکیشنز بنانے کی عملی رہنمائی شامل ہے۔

## MCP میں ٹرانسپورٹ میکانزم اور سٹریمنگ

یہ سیکشن MCP میں دستیاب مختلف ٹرانسپورٹ میکانزم اور کلائنٹس اور سرورز کے درمیان حقیقی وقت کی مواصلات کے لیے سٹریمنگ صلاحیتوں کو فعال کرنے میں ان کے کردار کو دریافت کرتا ہے۔

### ٹرانسپورٹ میکانزم کیا ہے؟

ٹرانسپورٹ میکانزم یہ تعین کرتا ہے کہ کلائنٹ اور سرور کے درمیان ڈیٹا کیسے تبادلہ ہوتا ہے۔ MCP مختلف ماحول اور ضروریات کے مطابق متعدد ٹرانسپورٹ اقسام کی حمایت کرتا ہے:

- **stdio**: معیاری ان پٹ/آؤٹ پٹ، مقامی اور CLI پر مبنی ٹولز کے لیے موزوں۔ سادہ لیکن ویب یا کلاؤڈ کے لیے موزوں نہیں۔
- **SSE (سرور-سینٹ ایونٹس)**: سرورز کو HTTP پر کلائنٹس کو حقیقی وقت کی اپ ڈیٹس بھیجنے کی اجازت دیتا ہے۔ ویب یوزر انٹرفیس کے لیے اچھا، لیکن توسیع پذیری اور لچک میں محدود۔
- **Streamable HTTP**: جدید HTTP پر مبنی سٹریمنگ ٹرانسپورٹ، نوٹیفیکیشنز اور بہتر توسیع پذیری کی حمایت کرتا ہے۔ زیادہ تر پروڈکشن اور کلاؤڈ کے منظرناموں کے لیے تجویز کیا جاتا ہے۔

### موازنہ جدول

نیچے دیے گئے موازنہ جدول کو دیکھیں تاکہ ان ٹرانسپورٹ میکانزم کے درمیان فرق کو سمجھ سکیں:

| Transport         | حقیقی وقت کی اپ ڈیٹس | سٹریمنگ | توسیع پذیری | استعمال کا کیس            |
|-------------------|--------------------|---------|-------------|--------------------------|
| stdio             | نہیں               | نہیں    | کم          | مقامی CLI ٹولز           |
| SSE               | ہاں                | ہاں     | درمیانہ     | ویب، حقیقی وقت کی اپ ڈیٹس |
| Streamable HTTP   | ہاں                | ہاں     | زیادہ       | کلاؤڈ، کثیر کلائنٹ      |

> **Tip:** درست ٹرانسپورٹ کا انتخاب کارکردگی، توسیع پذیری، اور صارف کے تجربے پر اثر ڈالتا ہے۔ جدید، قابل توسیع، اور کلاؤڈ کے لیے تیار ایپلیکیشنز کے لیے **Streamable HTTP** تجویز کیا جاتا ہے۔

پچھلے ابواب میں دکھائے گئے stdio اور SSE ٹرانسپورٹس پر غور کریں اور دیکھیں کہ اس باب میں اسٹریم ایبل HTTP ٹرانسپورٹ کا احاطہ کیا گیا ہے۔

## سٹریمنگ: تصورات اور محرکات

سٹریمنگ کے بنیادی تصورات اور محرکات کو سمجھنا موثر حقیقی وقت کی مواصلات کے نظام کو نافذ کرنے کے لیے ضروری ہے۔

**سٹریمنگ** نیٹ ورک پروگرامنگ میں ایک تکنیک ہے جو ڈیٹا کو چھوٹے، قابل انتظام حصوں میں یا ایونٹس کی ترتیب کے طور پر بھیجنے اور وصول کرنے کی اجازت دیتی ہے، بجائے اس کے کہ پورا جواب مکمل ہونے کا انتظار کیا جائے۔ یہ خاص طور پر مفید ہے:

- بڑے فائلز یا ڈیٹاسیٹس کے لیے۔
- حقیقی وقت کی اپ ڈیٹس (مثلاً چیٹ، پروگریس بار) کے لیے۔
- طویل مدتی حسابات جہاں آپ صارف کو مطلع رکھنا چاہتے ہیں۔

یہاں سٹریمنگ کے بارے میں آپ کو اعلی سطح پر جاننا چاہیے:

- ڈیٹا بتدریج فراہم کیا جاتا ہے، ایک ساتھ نہیں۔
- کلائنٹ ڈیٹا کو جیسے ہی وصول کرے پراسیس کر سکتا ہے۔
- محسوس شدہ تاخیر کو کم کرتا ہے اور صارف کے تجربے کو بہتر بناتا ہے۔

### سٹریمنگ کیوں استعمال کریں؟

سٹریمنگ استعمال کرنے کی وجوہات درج ذیل ہیں:

- صارفین کو فوری فیڈ بیک ملتا ہے، صرف آخر میں نہیں۔
- حقیقی وقت کی ایپلیکیشنز اور جوابی یوزر انٹرفیس کو فعال کرتا ہے۔
- نیٹ ورک اور کمپیوٹ وسائل کا زیادہ مؤثر استعمال۔

### سادہ مثال: HTTP سٹریمنگ سرور اور کلائنٹ

یہاں ایک سادہ مثال ہے کہ سٹریمنگ کو کیسے نافذ کیا جا سکتا ہے:

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

یہ مثال دکھاتی ہے کہ سرور کس طرح دستیاب ہوتے ہی کلائنٹ کو پیغامات بھیجتا ہے، بجائے اس کے کہ تمام پیغامات تیار ہونے کا انتظار کرے۔

**یہ کیسے کام کرتا ہے:**
- سرور ہر پیغام کو جیسے ہی تیار ہو اسے بھیجتا ہے۔
- کلائنٹ ہر حصہ کو وصول کر کے پرنٹ کرتا ہے۔

**ضروریات:**
- سرور کو سٹریمنگ ریسپانس استعمال کرنا چاہیے (مثلاً `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) بجائے MCP کے ذریعے سٹریمنگ منتخب کرنے کے۔

- **سادہ سٹریمنگ ضروریات کے لیے:** کلاسک HTTP سٹریمنگ نافذ کرنا آسان اور بنیادی سٹریمنگ ضروریات کے لیے کافی ہے۔

- **پیچیدہ، انٹرایکٹو ایپلیکیشنز کے لیے:** MCP سٹریمنگ زیادہ ساختہ طریقہ فراہم کرتا ہے جس میں امیر میٹا ڈیٹا اور نوٹیفیکیشنز اور حتمی نتائج کے درمیان تفریق ہوتی ہے۔

- **AI ایپلیکیشنز کے لیے:** MCP کا نوٹیفیکیشن سسٹم طویل مدتی AI کاموں کے لیے خاص طور پر مفید ہے جہاں آپ صارفین کو پیش رفت سے آگاہ رکھنا چاہتے ہیں۔

## MCP میں سٹریمنگ

تو، آپ نے اب تک کلاسیکی سٹریمنگ اور MCP میں سٹریمنگ کے فرق پر کچھ سفارشات اور موازنہ دیکھ لیے ہیں۔ آئیے تفصیل سے جانتے ہیں کہ آپ MCP میں سٹریمنگ کا کیسے فائدہ اٹھا سکتے ہیں۔

MCP فریم ورک کے اندر سٹریمنگ کیسے کام کرتی ہے یہ سمجھنا ضروری ہے تاکہ آپ جوابی ایپلیکیشنز بنا سکیں جو طویل چلنے والے آپریشنز کے دوران صارفین کو حقیقی وقت میں فیڈ بیک فراہم کریں۔

MCP میں، سٹریمنگ کا مطلب مرکزی جواب کو حصوں میں بھیجنا نہیں بلکہ جب کوئی ٹول درخواست پر کام کر رہا ہو تو کلائنٹ کو **نوٹیفیکیشنز** بھیجنا ہوتا ہے۔ یہ نوٹیفیکیشنز پیش رفت کی اپ ڈیٹس، لاگز، یا دیگر ایونٹس شامل ہو سکتے ہیں۔

### یہ کیسے کام کرتا ہے

مرکزی نتیجہ اب بھی ایک ہی جواب کے طور پر بھیجا جاتا ہے۔ تاہم، پروسیسنگ کے دوران نوٹیفیکیشنز کو الگ پیغامات کے طور پر بھیجا جا سکتا ہے اور اس طرح کلائنٹ کو حقیقی وقت میں اپ ڈیٹ کیا جا سکتا ہے۔ کلائنٹ کو ان نوٹیفیکیشنز کو ہینڈل اور دکھانے کے قابل ہونا چاہیے۔

## نوٹیفیکیشن کیا ہے؟

ہم نے "نوٹیفیکیشن" کہا، MCP کے سیاق و سباق میں اس کا کیا مطلب ہے؟

نوٹیفیکیشن ایک پیغام ہے جو سرور سے کلائنٹ کو بھیجا جاتا ہے تاکہ طویل چلنے والے آپریشن کے دوران پیش رفت، حیثیت، یا دیگر ایونٹس کے بارے میں آگاہ کیا جا سکے۔ نوٹیفیکیشنز شفافیت اور صارف کے تجربے کو بہتر بناتی ہیں۔

مثال کے طور پر، کلائنٹ کو سرور کے ساتھ ابتدائی ہینڈشیک مکمل ہونے کے بعد ایک نوٹیفیکیشن بھیجنی چاہیے۔

نوٹیفیکیشن ایک JSON پیغام کی طرح دکھائی دیتی ہے:

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

لاگنگ کو کام کرنے کے لیے، سرور کو اسے ایک فیچر/صلاحیت کے طور پر فعال کرنا پڑتا ہے جیسا کہ درج ذیل ہے:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> استعمال شدہ SDK پر منحصر ہے، لاگنگ ممکنہ طور پر پہلے سے فعال ہو سکتی ہے، یا آپ کو اپنے سرور کی ترتیب میں اسے واضح طور پر فعال کرنا پڑے گا۔

نوٹیفیکیشنز کی مختلف اقسام ہیں:

| سطح       | وضاحت                         | استعمال کی مثال                |
|-----------|------------------------------|-------------------------------|
| debug     | تفصیلی ڈیبگنگ معلومات       | فنکشن کے داخلے/خروج کے پوائنٹس |
| info      | عمومی معلوماتی پیغامات       | آپریشن کی پیش رفت کی اپ ڈیٹس    |
| notice    | معمول کے لیکن اہم ایونٹس      | کنفیگریشن کی تبدیلیاں          |
| warning   | وارننگ کی حالتیں             | منسوخ شدہ فیچر کا استعمال       |
| error     | خرابی کی حالتیں              | آپریشن کی ناکامیاں             |
| critical  | سنگین حالتیں                | سسٹم کمپونینٹ کی ناکامیاں      |
| alert     | فوری کارروائی ضروری ہے        | ڈیٹا کرپشن کا پتہ چلنا          |
| emergency | سسٹم ناقابل استعمال ہے       | مکمل سسٹم ناکامی               |

## MCP میں نوٹیفیکیشنز کا نفاذ

MCP میں نوٹیفیکیشنز کو نافذ کرنے کے لیے، آپ کو سرور اور کلائنٹ دونوں طرف حقیقی وقت کی اپ ڈیٹس کو ہینڈل کرنے کے لیے سیٹ اپ کرنا ہوگا۔ اس سے آپ کی ایپلیکیشن طویل چلنے والے آپریشنز کے دوران صارفین کو فوری فیڈ بیک فراہم کر سکتی ہے۔

### سرور سائیڈ: نوٹیفیکیشنز بھیجنا

آئیے سرور سائیڈ سے شروع کرتے ہیں۔ MCP میں، آپ ایسے ٹولز کی تعریف کرتے ہیں جو درخواستوں پر کام کرتے ہوئے نوٹیفیکیشنز بھیج سکتے ہیں۔ سرور کلائنٹ کو پیغامات بھیجنے کے لیے کانٹیکسٹ آبجیکٹ (عام طور پر `ctx`) استعمال کرتا ہے۔

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

کلائنٹ کو ایک پیغام ہینڈلر نافذ کرنا چاہیے جو نوٹیفیکیشنز کو وصول کرے اور جیسے ہی آئیں دکھائے۔

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) اور آپ کا کلائنٹ نوٹیفیکیشنز کو ہینڈل کرنے والا پیغام ہینڈلر نافذ کرتا ہے۔

## پیش رفت کی نوٹیفیکیشنز اور منظرنامے

یہ سیکشن MCP میں پیش رفت کی نوٹیفیکیشنز کے تصور، ان کی اہمیت، اور Streamable HTTP استعمال کرتے ہوئے ان کے نفاذ کی وضاحت کرتا ہے۔ آپ کو اپنی سمجھ کو مضبوط کرنے کے لیے ایک عملی اسائنمنٹ بھی ملے گا۔

پیش رفت کی نوٹیفیکیشنز طویل چلنے والے آپریشنز کے دوران سرور سے کلائنٹ کو بھیجے جانے والے حقیقی وقت کے پیغامات ہیں۔ پورے عمل کے ختم ہونے کا انتظار کرنے کے بجائے، سرور کلائنٹ کو موجودہ حیثیت سے آگاہ رکھتا ہے۔ یہ شفافیت، صارف کے تجربے کو بہتر بناتا ہے، اور ڈیبگنگ کو آسان بناتا ہے۔

**مثال:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### پیش رفت کی نوٹیفیکیشنز کیوں استعمال کریں؟

پیش رفت کی نوٹیفیکیشنز کئی وجوہات کی بنا پر ضروری ہیں:

- **بہتر صارف کا تجربہ:** صارفین کام کی پیش رفت کو دیکھتے ہیں، صرف آخر میں نہیں۔
- **حقیقی وقت کا فیڈ بیک:** کلائنٹس پروگریس بارز یا لاگز دکھا سکتے ہیں، جس سے ایپ زیادہ جوابی محسوس ہوتی ہے۔
- **آسان ڈیبگنگ اور نگرانی:** ڈویلپرز اور صارفین دیکھ سکتے ہیں کہ عمل کہاں سست یا رکا ہوا ہے۔

### پیش رفت کی نوٹیفیکیشنز کو کیسے نافذ کریں

یہاں بتایا گیا ہے کہ آپ MCP میں پیش رفت کی نوٹیفیکیشنز کو کیسے نافذ کر سکتے ہیں:

- **سرور پر:** ہر آئٹم کی پروسیسنگ کے دوران `ctx.info()` or `ctx.log()` استعمال کریں تاکہ نوٹیفیکیشنز بھیجی جا سکیں۔ یہ مرکزی نتیجہ تیار ہونے سے پہلے کلائنٹ کو پیغام بھیجتا ہے۔
- **کلائنٹ پر:** ایک پیغام ہینڈلر نافذ کریں جو نوٹیفیکیشنز کو سن کر جیسے ہی آئیں دکھائے۔ یہ ہینڈلر نوٹیفیکیشنز اور حتمی نتیجہ کے درمیان فرق کرتا ہے۔

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

## سیکیورٹی کے تحفظات

جب MCP سرورز کو HTTP پر مبنی ٹرانسپورٹس کے ساتھ نافذ کیا جاتا ہے تو سیکیورٹی ایک انتہائی اہم مسئلہ بن جاتا ہے جس میں متعدد حملوں کے راستوں اور حفاظتی طریقوں پر غور کرنا ضروری ہوتا ہے۔

### جائزہ

HTTP پر MCP سرورز کو ظاہر کرتے وقت سیکیورٹی بہت اہم ہے۔ Streamable HTTP نئے حملوں کے امکانات پیدا کرتا ہے اور محتاط ترتیب کا تقاضا کرتا ہے۔

### کلیدی نکات
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
2. **Update client code** to use `streamablehttp_client` کی تصدیق کریں نہ کہ SSE کلائنٹ کی۔
3. **کلائنٹ میں پیغام ہینڈلر نافذ کریں** تاکہ نوٹیفیکیشنز کو پراسیس کیا جا سکے۔
4. **موجودہ ٹولز اور ورک فلو کے ساتھ مطابقت کی جانچ کریں**۔

### مطابقت برقرار رکھنا

مائیگریشن کے دوران موجودہ SSE کلائنٹس کے ساتھ مطابقت برقرار رکھنا تجویز کیا جاتا ہے۔ یہاں کچھ حکمت عملیاں ہیں:

- آپ SSE اور Streamable HTTP دونوں کی حمایت کر سکتے ہیں اور دونوں ٹرانسپورٹس کو مختلف اینڈپوائنٹس پر چلا سکتے ہیں۔
- کلائنٹس کو نئے ٹرانسپورٹ کی طرف بتدریج منتقل کریں۔

### چیلنجز

مائیگریشن کے دوران درج ذیل چیلنجز کو یقینی بنائیں:

- تمام کلائنٹس کی اپ ڈیٹ ہونا
- نوٹیفیکیشن کی ترسیل میں فرق کو سنبھالنا

### اسائنمنٹ: اپنا سٹریمنگ MCP ایپ بنائیں

**منظرنامہ:**
ایک MCP سرور اور کلائنٹ بنائیں جہاں سرور آئٹمز کی فہرست (مثلاً فائلیں یا دستاویزات) کو پروسیس کرے اور ہر پروسیس کیے گئے آئٹم کے لیے نوٹیفیکیشن بھیجے۔ کلائنٹ کو چاہیے کہ ہر نوٹیفیکیشن کو جیسے ہی وصول ہو دکھائے۔

**اقدامات:**

1. ایک سرور ٹول نافذ کریں جو فہرست کو پروسیس کرے اور ہر آئٹم کے لیے نوٹیفیکیشن بھیجے۔
2. ایک کلائنٹ نافذ کریں جس میں پیغام ہینڈلر ہو جو نوٹیفیکیشنز کو حقیقی وقت میں دکھائے۔
3. اپنی نفاذ کی جانچ کریں، سرور اور کلائنٹ دونوں کو چلائیں، اور نوٹیفیکیشنز کا مشاہدہ کریں۔

[Solution](./solution/README.md)

## مزید مطالعہ اور آگے کیا؟

اپنے MCP سٹریمنگ کے سفر کو جاری رکھنے اور اپنے علم کو بڑھانے کے لیے، یہ سیکشن اضافی وسائل اور مزید پیچیدہ ایپلیکیشنز بنانے کے لیے تجویز کردہ اگلے اقدامات فراہم کرتا ہے۔

### مزید مطالعہ

- [Microsoft: HTTP Streaming کا تعارف](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core میں CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.read

**انتباہ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تعبیر کے ذمہ دار نہیں ہیں۔