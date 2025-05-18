<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:07:25+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

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

زمانی که سرور متصل شد:

- سعی کنید ابزارها را لیست کنید و `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build` را اجرا کنید.

- در یک ترمینال جداگانه فرمان زیر را اجرا کنید:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    این تمام ابزارهای موجود در سرور را لیست خواهد کرد. باید خروجی زیر را ببینید:

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

- یک نوع ابزار را با تایپ کردن فرمان زیر فراخوانی کنید:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

باید خروجی زیر را ببینید:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> معمولاً اجرای بازرس در حالت CLI بسیار سریع‌تر از مرورگر است.
> بیشتر درباره بازرس [اینجا](https://github.com/modelcontextprotocol/inspector) بخوانید.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌ها باشند. سند اصلی به زبان اصلی باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حساس، ترجمه انسانی حرفه‌ای توصیه می‌شود. ما مسئولیت هیچ‌گونه سوء تفاهم یا تفسیر نادرست ناشی از استفاده از این ترجمه را بر عهده نمی‌گیریم.