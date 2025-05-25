<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:53:15+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

## -1- نصب وابستگی‌ها

```bash
dotnet run
```

## -2- اجرای نمونه

```bash
dotnet run
```

## -3- آزمایش نمونه

قبل از اجرای دستورات زیر، یک ترمینال جداگانه باز کنید (اطمینان حاصل کنید که سرور همچنان در حال اجرا است).

با اجرای سرور در یک ترمینال، یک ترمینال دیگر باز کنید و دستور زیر را اجرا کنید:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

این باید یک سرور وب با رابط بصری راه‌اندازی کند که به شما امکان آزمایش نمونه را می‌دهد.

پس از اتصال سرور:

- سعی کنید ابزارها را لیست کنید و `add` را با آرگومان‌های 2 و 4 اجرا کنید، باید عدد 6 را در نتیجه ببینید.
- به منابع و قالب منابع بروید و "greeting" را فراخوانی کنید، نامی وارد کنید و باید یک خوش‌آمدگویی با نامی که وارد کرده‌اید ببینید.

### آزمایش در حالت CLI

می‌توانید آن را مستقیماً در حالت CLI با اجرای دستور زیر راه‌اندازی کنید:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

این تمام ابزارهای موجود در سرور را لیست می‌کند. باید خروجی زیر را ببینید:

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
> معمولاً اجرای بازرس در حالت CLI بسیار سریع‌تر از مرورگر است.
> اطلاعات بیشتر درباره بازرس را [اینجا](https://github.com/modelcontextprotocol/inspector) بخوانید.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌ها باشند. سند اصلی به زبان مادری باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئولیتی در قبال سوء تفاهم یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.