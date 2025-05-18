<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:06:45+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

## -1- نصب وابستگی‌ها

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- اجرای نمونه

```bash
dotnet run
```

## -4- آزمایش نمونه

با اجرای سرور در یک ترمینال، یک ترمینال دیگر باز کنید و دستور زیر را اجرا کنید:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

این باید یک وب سرور با رابط بصری راه‌اندازی کند که به شما اجازه می‌دهد نمونه را آزمایش کنید.

وقتی سرور متصل شد:

- سعی کنید ابزارها را فهرست کنید و `add` را با آرگومان‌های 2 و 4 اجرا کنید، باید نتیجه 6 را مشاهده کنید.
- به منابع و قالب منابع بروید و "greeting" را فراخوانی کنید، نامی را وارد کنید و باید سلامی با نامی که وارد کرده‌اید مشاهده کنید.

### آزمایش در حالت CLI

می‌توانید آن را مستقیماً در حالت CLI با اجرای دستور زیر راه‌اندازی کنید:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

این تمام ابزارهای موجود در سرور را فهرست خواهد کرد. باید خروجی زیر را مشاهده کنید:

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
> معمولاً اجرای بازرس در حالت CLI سریع‌تر از مرورگر است.
> درباره بازرس [اینجا](https://github.com/modelcontextprotocol/inspector) بیشتر بخوانید.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئولیتی در قبال سوءتفاهم‌ها یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.