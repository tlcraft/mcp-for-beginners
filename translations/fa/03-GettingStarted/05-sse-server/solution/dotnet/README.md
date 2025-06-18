<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:48:46+00:00",
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

قبل از اجرای دستور زیر، یک ترمینال جداگانه باز کنید (اطمینان حاصل کنید که سرور هنوز در حال اجراست).

با اجرای سرور در یک ترمینال، ترمینال دیگری باز کرده و دستور زیر را اجرا کنید:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

این باید یک وب‌سرور با رابط کاربری گرافیکی راه‌اندازی کند که به شما اجازه می‌دهد نمونه را تست کنید.

> مطمئن شوید که **SSE** به عنوان نوع انتقال انتخاب شده است، و URL برابر با `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add` باشد، با آرگومان‌های ۲ و ۴، باید عدد ۶ را در نتیجه ببینید.
- به بخش resources و resource template بروید و "greeting" را فراخوانی کنید، یک نام وارد کنید و باید پیامی با نام وارد شده مشاهده کنید.

### تست در حالت CLI

می‌توانید مستقیماً در حالت CLI با اجرای دستور زیر آن را راه‌اندازی کنید:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

این دستور تمام ابزارهای موجود در سرور را لیست می‌کند. باید خروجی زیر را ببینید:

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
> معمولاً اجرای inspector در حالت CLI بسیار سریع‌تر از مرورگر است.
> برای اطلاعات بیشتر درباره inspector اینجا را بخوانید [here](https://github.com/modelcontextprotocol/inspector).

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی اشتباهات یا نادرستی‌هایی باشند. سند اصلی به زبان مادری خود به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که ناشی از استفاده از این ترجمه باشد، نیستیم.