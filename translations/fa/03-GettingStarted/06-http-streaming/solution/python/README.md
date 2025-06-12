<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-12T22:22:01+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

در اینجا نحوه اجرای سرور و کلاینت استریمینگ HTTP کلاسیک و همچنین سرور و کلاینت استریمینگ MCP با استفاده از Python آورده شده است.

### مرور کلی

- شما یک سرور MCP راه‌اندازی خواهید کرد که اعلان‌های پیشرفت را به کلاینت هنگام پردازش آیتم‌ها ارسال می‌کند.
- کلاینت هر اعلان را به صورت زنده نمایش خواهد داد.
- این راهنما شامل پیش‌نیازها، راه‌اندازی، اجرا و عیب‌یابی است.

### پیش‌نیازها

- Python 3.9 یا نسخه‌های جدیدتر
- بسته `mcp` Python (نصب با `pip install mcp`)

### نصب و راه‌اندازی

1. مخزن را کلون کنید یا فایل‌های راه‌حل را دانلود کنید.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **یک محیط مجازی ایجاد و فعال کنید (توصیه شده):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **وابستگی‌های مورد نیاز را نصب کنید:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### فایل‌ها

- **سرور:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **کلاینت:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### اجرای سرور استریمینگ HTTP کلاسیک

1. به دایرکتوری راه‌حل بروید:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. سرور استریمینگ HTTP کلاسیک را شروع کنید:

   ```pwsh
   python server.py
   ```

3. سرور شروع به کار می‌کند و نمایش می‌دهد:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### اجرای کلاینت استریمینگ HTTP کلاسیک

1. یک ترمینال جدید باز کنید (همان محیط مجازی و دایرکتوری را فعال کنید):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. باید پیام‌های استریم شده را به ترتیب مشاهده کنید:

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

### اجرای سرور استریمینگ MCP

1. به دایرکتوری راه‌حل بروید:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. سرور MCP را با انتقال streamable-http شروع کنید:
   ```pwsh
   python server.py mcp
   ```
3. سرور شروع به کار می‌کند و نمایش می‌دهد:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### اجرای کلاینت استریمینگ MCP

1. یک ترمینال جدید باز کنید (همان محیط مجازی و دایرکتوری را فعال کنید):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. باید اعلان‌ها را به صورت زنده هنگام پردازش هر آیتم توسط سرور مشاهده کنید:
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

### مراحل کلیدی پیاده‌سازی

1. **سرور MCP را با استفاده از FastMCP ایجاد کنید.**
2. **ابزاری تعریف کنید که لیستی را پردازش کرده و اعلان‌ها را با استفاده از `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` برای عملیات غیرمسدودکننده ارسال کند.**
- همیشه در هر دو سرور و کلاینت استثناها را مدیریت کنید تا برنامه پایدار باشد.
- با چندین کلاینت تست کنید تا به‌روزرسانی‌های زنده را مشاهده کنید.
- اگر با خطا مواجه شدید، نسخه Python خود را بررسی کرده و مطمئن شوید همه وابستگی‌ها نصب شده‌اند.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی اشتباهات یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا برداشت نادرستی که ناشی از استفاده از این ترجمه باشد، نیستیم.