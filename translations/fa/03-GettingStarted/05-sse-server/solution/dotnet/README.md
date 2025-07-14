<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-07-13T20:08:04+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

## -1- نصب وابستگی‌ها

```bash
dotnet restore
```

## -2- اجرای نمونه

```bash
dotnet run
```

## -3- تست نمونه

قبل از اجرای دستور زیر، یک ترمینال جداگانه باز کنید (مطمئن شوید که سرور هنوز در حال اجرا است).

با اجرای سرور در یک ترمینال، ترمینال دیگری باز کنید و دستور زیر را اجرا کنید:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

این باید یک وب‌سرور با رابط کاربری گرافیکی راه‌اندازی کند که به شما امکان می‌دهد نمونه را تست کنید.

> مطمئن شوید که **SSE** به عنوان نوع انتقال انتخاب شده است و آدرس URL برابر با `http://localhost:3001/sse` باشد.

پس از اتصال سرور:

- سعی کنید ابزارها را فهرست کنید و دستور `add` را با آرگومان‌های ۲ و ۴ اجرا کنید، باید عدد ۶ را در نتیجه ببینید.
- به بخش منابع و قالب منابع بروید و "greeting" را فراخوانی کنید، یک نام وارد کنید و باید پیامی با نام وارد شده مشاهده کنید.

### تست در حالت CLI

می‌توانید مستقیماً در حالت CLI با اجرای دستور زیر آن را راه‌اندازی کنید:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

این دستور تمام ابزارهای موجود در سرور را فهرست می‌کند. باید خروجی زیر را ببینید:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
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
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> معمولاً اجرای inspector در حالت CLI سریع‌تر از مرورگر است.
> برای اطلاعات بیشتر درباره inspector اینجا را بخوانید [here](https://github.com/modelcontextprotocol/inspector).

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.