<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:17:13+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

یہاں بتایا گیا ہے کہ کلاسک HTTP اسٹریمنگ سرور اور کلائنٹ کو کیسے چلایا جائے، نیز MCP اسٹریمنگ سرور اور کلائنٹ کو Python کے ذریعے کیسے چلایا جائے۔

### جائزہ

- آپ ایک MCP سرور قائم کریں گے جو آئٹمز کو پروسیس کرتے ہوئے کلائنٹ کو پیش رفت کی اطلاعات بھیجے گا۔
- کلائنٹ ہر اطلاع کو حقیقی وقت میں دکھائے گا۔
- یہ رہنما شرائط، سیٹ اپ، چلانے اور مسائل کے حل کا احاطہ کرتا ہے۔

### شرائط

- Python 3.9 یا اس سے جدید ورژن
- `mcp` Python پیکیج (انسٹال کرنے کے لیے `pip install mcp` استعمال کریں)

### انسٹالیشن اور سیٹ اپ

1. ریپوزیٹری کلون کریں یا حل کی فائلیں ڈاؤن لوڈ کریں۔

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **ایک ورچوئل ماحول بنائیں اور اسے فعال کریں (تجویز کردہ):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **ضروری انحصارات انسٹال کریں:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### فائلیں

- **سرور:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **کلائنٹ:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### کلاسک HTTP اسٹریمنگ سرور چلانا

1. حل کی ڈائریکٹری میں جائیں:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. کلاسک HTTP اسٹریمنگ سرور شروع کریں:

   ```pwsh
   python server.py
   ```

3. سرور شروع ہو کر یہ دکھائے گا:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### کلاسک HTTP اسٹریمنگ کلائنٹ چلانا

1. نیا ٹرمینل کھولیں (اسی ورچوئل ماحول اور ڈائریکٹری کو فعال کریں):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. آپ کو سلسلہ وار اسٹریمنگ پیغامات نظر آئیں گے:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### MCP اسٹریمنگ سرور چلانا

1. حل کی ڈائریکٹری میں جائیں:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. streamable-http ٹرانسپورٹ کے ساتھ MCP سرور شروع کریں:
   ```pwsh
   python server.py mcp
   ```
3. سرور شروع ہو کر یہ دکھائے گا:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP اسٹریمنگ کلائنٹ چلانا

1. نیا ٹرمینل کھولیں (اسی ورچوئل ماحول اور ڈائریکٹری کو فعال کریں):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. آپ کو ہر آئٹم کی پروسیسنگ کے دوران حقیقی وقت میں اطلاعات نظر آئیں گی:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### اہم نفاذی اقدامات

1. **FastMCP کا استعمال کرتے ہوئے MCP سرور بنائیں۔**
2. **ایک ٹول ڈیفائن کریں جو فہرست کو پروسیس کرے اور `ctx.info()` یا `ctx.log()` کے ذریعے اطلاعات بھیجے۔**
3. **سرور کو `transport="streamable-http"` کے ساتھ چلائیں۔**
4. **ایک کلائنٹ بنائیں جس میں پیغام ہینڈلر ہو تاکہ اطلاعات کو پہنچتے ہی دکھایا جا سکے۔**

### کوڈ کا جائزہ
- سرور async فنکشنز اور MCP کانٹیکسٹ کا استعمال کرتے ہوئے پیش رفت کی اپڈیٹس بھیجتا ہے۔
- کلائنٹ ایک async پیغام ہینڈلر نافذ کرتا ہے جو اطلاعات اور حتمی نتیجہ پرنٹ کرتا ہے۔

### تجاویز اور مسائل کا حل

- غیر بلاکنگ آپریشنز کے لیے `async/await` استعمال کریں۔
- سرور اور کلائنٹ دونوں میں استثنائی حالات کو ہمیشہ ہینڈل کریں تاکہ مضبوطی برقرار رہے۔
- حقیقی وقت کی اپڈیٹس دیکھنے کے لیے متعدد کلائنٹس کے ساتھ ٹیسٹ کریں۔
- اگر آپ کو غلطیاں ملیں تو اپنے Python ورژن اور تمام انحصارات کی تنصیب چیک کریں۔

**دستخطی دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔