<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:00:10+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

یہاں بتایا گیا ہے کہ Python استعمال کرتے ہوئے کلاسک HTTP اسٹریمنگ سرور اور کلائنٹ، نیز MCP اسٹریمنگ سرور اور کلائنٹ کو کیسے چلایا جائے۔

### جائزہ

- آپ ایک MCP سرور قائم کریں گے جو آئٹمز کو پروسیس کرتے ہوئے کلائنٹ کو پیش رفت کی اطلاعات بھیجے گا۔
- کلائنٹ ہر اطلاع کو حقیقی وقت میں دکھائے گا۔
- یہ رہنما شرائط، ترتیب، چلانے، اور مسائل کے حل کا احاطہ کرتا ہے۔

### شرائط

- Python 3.9 یا اس سے جدید
- `mcp` Python پیکج (انسٹال کرنے کے لیے `pip install mcp` استعمال کریں)

### تنصیب اور ترتیب

1. ریپوزیٹری کلون کریں یا حل کی فائلیں ڈاؤن لوڈ کریں۔

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **ایک ورچوئل ماحول بنائیں اور فعال کریں (تجویز کردہ):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **ضروری انحصار انسٹال کریں:**

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

3. سرور شروع ہوگا اور یہ دکھائے گا:

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

2. آپ کو سلسلہ وار پرنٹ شدہ اسٹریمنگ پیغامات دیکھنے کو ملیں گے:

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
3. سرور شروع ہوگا اور یہ دکھائے گا:
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
2. آپ کو ہر آئٹم کی پروسیسنگ کے دوران حقیقی وقت میں پرنٹ شدہ اطلاعات نظر آئیں گی:
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

### اہم عملدرآمد کے اقدامات

1. **FastMCP استعمال کرتے ہوئے MCP سرور بنائیں۔**
2. **ایک ٹول تعریف کریں جو فہرست کو پروسیس کرے اور `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` استعمال کرتے ہوئے اطلاعات بھیجے تاکہ بلاکنگ سے بچا جا سکے۔**
- مضبوطی کے لیے سرور اور کلائنٹ دونوں میں ہمیشہ استثناءات کو ہینڈل کریں۔
- حقیقی وقت کی اپ ڈیٹس دیکھنے کے لیے متعدد کلائنٹس کے ساتھ ٹیسٹ کریں۔
- اگر آپ کو غلطیاں ملیں تو اپنے Python ورژن اور تمام انحصار کی تنصیب کو چیک کریں۔

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا کمی بیشی ہو سکتی ہے۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔