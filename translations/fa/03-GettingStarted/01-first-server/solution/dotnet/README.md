<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:48:38+00:00",
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

وقتی سرور در یک ترمینال در حال اجرا است، یک ترمینال دیگر باز کنید و دستور زیر را اجرا کنید:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

این باید یک وب‌سرور با رابط کاربری گرافیکی راه‌اندازی کند که به شما امکان می‌دهد نمونه را تست کنید.

وقتی سرور متصل شد:

- سعی کنید ابزارها را لیست کنید و دستور `add` را با آرگومان‌های ۲ و ۴ اجرا کنید، باید نتیجه ۶ را ببینید.
- به بخش resources و resource template بروید و "greeting" را فراخوانی کنید، یک نام وارد کنید و باید پیامی با نام وارد شده مشاهده کنید.

### تست در حالت CLI

می‌توانید مستقیماً در حالت CLI با اجرای دستور زیر آن را راه‌اندازی کنید:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

این دستور تمام ابزارهای موجود در سرور را لیست می‌کند. باید خروجی زیر را ببینید:

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

باید خروجی زیر را مشاهده کنید:

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
> معمولاً اجرای inspector در حالت CLI خیلی سریع‌تر از اجرای آن در مرورگر است.
> برای اطلاعات بیشتر درباره inspector اینجا را بخوانید [here](https://github.com/modelcontextprotocol/inspector).

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه ماشینی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی اشتباهات یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، توصیه می‌شود از ترجمه حرفه‌ای انسانی استفاده شود. ما مسئول هیچ گونه سوءتفاهم یا برداشت نادرستی که ناشی از استفاده از این ترجمه باشد، نیستیم.