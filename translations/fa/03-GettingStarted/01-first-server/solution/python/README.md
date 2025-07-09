<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T22:56:48+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

توصیه می‌شود `uv` را نصب کنید اما اجباری نیست، راهنمایی‌ها را در [instructions](https://docs.astral.sh/uv/#highlights) ببینید

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

با اجرای سرور در یک ترمینال، ترمینال دیگری باز کنید و دستور زیر را اجرا کنید:

```bash
mcp dev server.py
```

این باید یک وب‌سرور با رابط کاربری گرافیکی راه‌اندازی کند که به شما امکان تست نمونه را می‌دهد.

وقتی سرور متصل شد:

- سعی کنید ابزارها را لیست کنید و دستور `add` را با آرگومان‌های ۲ و ۴ اجرا کنید، باید عدد ۶ را در نتیجه ببینید.

- به بخش resources و resource template بروید و تابع get_greeting را فراخوانی کنید، یک نام وارد کنید و باید پیامی با نام وارد شده مشاهده کنید.

### تست در حالت CLI

ابزاری که اجرا کردید در واقع یک برنامه Node.js است و `mcp dev` یک پوشش برای آن است.

می‌توانید آن را مستقیماً در حالت CLI با اجرای دستور زیر راه‌اندازی کنید:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

این دستور تمام ابزارهای موجود در سرور را لیست می‌کند. باید خروجی زیر را ببینید:

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

باید خروجی زیر را مشاهده کنید:

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
> معمولاً اجرای inspector در حالت CLI بسیار سریع‌تر از اجرای آن در مرورگر است.
> برای اطلاعات بیشتر درباره inspector اینجا را بخوانید [here](https://github.com/modelcontextprotocol/inspector).

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.