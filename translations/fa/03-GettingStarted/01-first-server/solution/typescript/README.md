<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:21:03+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

توصیه می‌شود که `uv` را نصب کنید، اما این الزام نیست، به [دستورالعمل‌ها](https://docs.astral.sh/uv/#highlights) مراجعه کنید.

## -1- نصب وابستگی‌ها

```bash
npm install
```

## -3- اجرای نمونه

```bash
npm run build
```

## -4- آزمایش نمونه

با اجرای سرور در یک ترمینال، یک ترمینال دیگر باز کنید و فرمان زیر را اجرا کنید:

```bash
npm run inspector
```

این باید یک سرور وب با یک رابط بصری راه‌اندازی کند که به شما اجازه می‌دهد نمونه را آزمایش کنید.

وقتی سرور متصل شد:

- سعی کنید ابزارها را لیست کنید و `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` یک بسته‌بندی‌کننده اطراف آن است.

می‌توانید آن را به طور مستقیم در حالت CLI با اجرای فرمان زیر راه‌اندازی کنید:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> معمولاً اجرای بازرس در حالت CLI بسیار سریع‌تر از مرورگر است.
> درباره بازرس بیشتر بخوانید [اینجا](https://github.com/modelcontextprotocol/inspector).

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً آگاه باشید که ترجمه‌های خودکار ممکن است حاوی اشتباهات یا نادرستی‌ها باشند. سند اصلی به زبان مادری خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حساس، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئولیتی در قبال سوء تفاهم‌ها یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.