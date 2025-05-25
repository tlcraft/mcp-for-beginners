<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:00:23+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

توصیه می‌شود `uv` را نصب کنید، اما الزامی نیست. به [دستورالعمل‌ها](https://docs.astral.sh/uv/#highlights) مراجعه کنید.

## -0- ایجاد یک محیط مجازی

```bash
python -m venv venv
```

## -1- فعال‌سازی محیط مجازی

```bash
venv\Scrips\activate
```

## -2- نصب وابستگی‌ها

```bash
pip install "mcp[cli]"
```

## -3- اجرای نمونه

```bash
mcp run server.py
```

## -4- تست نمونه

با اجرای سرور در یک ترمینال، ترمینال دیگری را باز کنید و فرمان زیر را اجرا کنید:

```bash
mcp dev server.py
```

این باید یک وب سرور با رابط بصری راه‌اندازی کند که به شما اجازه می‌دهد نمونه را تست کنید.

پس از اتصال سرور:

- سعی کنید ابزارها را فهرست کنید و `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` یک wrapper دور آن است.

می‌توانید آن را مستقیماً در حالت CLI با اجرای فرمان زیر راه‌اندازی کنید:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

این همه ابزارهای موجود در سرور را فهرست خواهد کرد. باید خروجی زیر را ببینید:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

برای فراخوانی یک ابزار تایپ کنید:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

باید خروجی زیر را ببینید:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> معمولاً اجرای ispector در حالت CLI بسیار سریع‌تر از مرورگر است.
> اطلاعات بیشتر درباره inspector را [اینجا](https://github.com/modelcontextprotocol/inspector) بخوانید.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل خطاها یا نادقتی‌ها باشند. سند اصلی به زبان بومی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه انسانی حرفه‌ای توصیه می‌شود. ما مسئولیتی در قبال هرگونه سوء تفاهم یا تفسیر نادرست ناشی از استفاده از این ترجمه نداریم.