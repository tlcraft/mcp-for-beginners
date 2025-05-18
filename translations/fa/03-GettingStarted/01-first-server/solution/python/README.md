<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:13:57+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

توصیه می‌شود که `uv` را نصب کنید، اما ضروری نیست، [دستورالعمل‌ها](https://docs.astral.sh/uv/#highlights) را ببینید

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

با اجرای سرور در یک ترمینال، یک ترمینال دیگر باز کنید و دستور زیر را اجرا کنید:

```bash
mcp dev server.py
```

این باید یک وب سرور با یک رابط بصری راه‌اندازی کند که به شما امکان تست نمونه را می‌دهد.

وقتی سرور متصل شد:

- سعی کنید ابزارها را لیست کنید و `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` یک بسته‌بندی اطراف آن است.

می‌توانید آن را به طور مستقیم در حالت CLI با اجرای دستور زیر راه‌اندازی کنید:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

این تمام ابزارهای موجود در سرور را لیست خواهد کرد. شما باید خروجی زیر را ببینید:

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

شما باید خروجی زیر را ببینید:

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
> معمولاً اجرای بازرسی در حالت CLI بسیار سریع‌تر از مرورگر است.
> اطلاعات بیشتر درباره بازرسی [اینجا](https://github.com/modelcontextprotocol/inspector) بخوانید.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌ها باشند. سند اصلی به زبان مادری آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما در قبال هرگونه سوءتفاهم یا تفسیر نادرست ناشی از استفاده از این ترجمه مسئولیتی نداریم.