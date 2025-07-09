<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-09T21:56:58+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

## -1- نصب وابستگی‌ها

```bash
dotnet restore
```

## -3- اجرای نمونه


```bash
dotnet run
```

## -4- تست نمونه

با اجرای سرور در یک ترمینال، یک ترمینال دیگر باز کنید و دستور زیر را اجرا کنید:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

این باید یک وب‌سرور با رابط کاربری گرافیکی راه‌اندازی کند که به شما امکان می‌دهد نمونه را تست کنید.

پس از اتصال سرور:

- سعی کنید ابزارها را فهرست کنید و دستور `add` را با آرگومان‌های ۲ و ۴ اجرا کنید، باید عدد ۶ را در نتیجه ببینید.
- به بخش resources و resource template بروید و "greeting" را فراخوانی کنید، یک نام وارد کنید و باید یک پیام خوش‌آمدگویی با نام وارد شده ببینید.

### تست در حالت CLI

می‌توانید مستقیماً در حالت CLI با اجرای دستور زیر آن را راه‌اندازی کنید:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

این دستور تمام ابزارهای موجود در سرور را فهرست می‌کند. باید خروجی زیر را ببینید:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

برای فراخوانی یک ابزار تایپ کنید:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

باید خروجی زیر را ببینید:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> معمولاً اجرای inspector در حالت CLI سریع‌تر از مرورگر است.
> برای اطلاعات بیشتر درباره inspector اینجا را بخوانید [here](https://github.com/modelcontextprotocol/inspector).

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.