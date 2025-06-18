<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:15:53+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
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

## -3- آزمایش نمونه

قبل از اجرای دستور زیر، یک ترمینال جداگانه باز کنید (اطمینان حاصل کنید که سرور هنوز در حال اجرا است).

وقتی سرور در یک ترمینال در حال اجرا است، ترمینال دیگری باز کرده و دستور زیر را اجرا کنید:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

این باید یک وب سرور با رابط کاربری بصری راه‌اندازی کند که به شما امکان می‌دهد نمونه را آزمایش کنید.

> اطمینان حاصل کنید که **Streamable HTTP** به عنوان نوع انتقال انتخاب شده است، و آدرس URL برابر با `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add` است، با آرگومان‌های ۲ و ۴، باید عدد ۶ را در نتیجه ببینید.
- به بخش resources و resource template بروید و "greeting" را فراخوانی کنید، یک نام وارد کنید و باید پیامی با همان نام دریافت کنید.

### آزمایش در حالت CLI

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

برای فراخوانی یک ابزار، تایپ کنید:

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
> معمولاً اجرای inspector در حالت CLI بسیار سریع‌تر از اجرای آن در مرورگر است.
> برای اطلاعات بیشتر درباره inspector اینجا را مطالعه کنید: [here](https://github.com/modelcontextprotocol/inspector).

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوء تفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.