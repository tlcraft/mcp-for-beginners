<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:00:02+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "ar"
}
-->
# تشغيل هذا المثال

إليك كيفية تشغيل خادم وبائع HTTP التقليدي للبث، بالإضافة إلى خادم وبائع MCP للبث باستخدام Python.

### نظرة عامة

- ستقوم بإعداد خادم MCP يبث إشعارات التقدم إلى العميل أثناء معالجة العناصر.
- سيعرض العميل كل إشعار في الوقت الفعلي.
- يغطي هذا الدليل المتطلبات الأساسية، والإعداد، والتشغيل، واستكشاف الأخطاء وإصلاحها.

### المتطلبات الأساسية

- Python 3.9 أو أحدث
- حزمة `mcp` الخاصة بـ Python (قم بالتثبيت باستخدام `pip install mcp`)

### التثبيت والإعداد

1. استنسخ المستودع أو قم بتنزيل ملفات الحل.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **إنشاء وتفعيل بيئة افتراضية (موصى به):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **تثبيت التبعيات المطلوبة:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### الملفات

- **الخادم:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **العميل:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### تشغيل خادم البث HTTP التقليدي

1. انتقل إلى دليل الحل:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. ابدأ خادم البث HTTP التقليدي:

   ```pwsh
   python server.py
   ```

3. سيبدأ الخادم ويعرض:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### تشغيل عميل البث HTTP التقليدي

1. افتح نافذة طرفية جديدة (فعّل نفس البيئة الافتراضية والدليل):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. يجب أن ترى الرسائل المتدفقة مطبوعة بالتسلسل:

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

### تشغيل خادم بث MCP

1. انتقل إلى دليل الحل:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. ابدأ خادم MCP مع نقل streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. سيبدأ الخادم ويعرض:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### تشغيل عميل بث MCP

1. افتح نافذة طرفية جديدة (فعّل نفس البيئة الافتراضية والدليل):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. يجب أن ترى الإشعارات مطبوعة في الوقت الفعلي أثناء معالجة الخادم لكل عنصر:
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

### خطوات التنفيذ الرئيسية

1. **إنشاء خادم MCP باستخدام FastMCP.**
2. **تعريف أداة تعالج قائمة وترسل إشعارات باستخدام `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` للعمليات غير المتزامنة.**
- تعامل دائمًا مع الاستثناءات في كل من الخادم والعميل لضمان المتانة.
- اختبر مع عدة عملاء لملاحظة التحديثات في الوقت الفعلي.
- إذا واجهت أخطاء، تحقق من إصدار Python الخاص بك وتأكد من تثبيت جميع التبعيات.

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق والمعتمد. للمعلومات الحساسة أو الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ناتج عن استخدام هذه الترجمة.