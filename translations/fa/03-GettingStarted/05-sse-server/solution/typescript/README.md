<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:18:32+00:00",
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

با اجرای سرور در یک ترمینال، ترمینال دیگری باز کنید و دستور زیر را اجرا کنید:

```bash
npm run inspector
```

این باید یک وب‌سرور با رابط کاربری گرافیکی راه‌اندازی کند که به شما امکان می‌دهد نمونه را آزمایش کنید.

پس از اتصال سرور:

- سعی کنید ابزارها را فهرست کنید و دستور `add` را با آرگومان‌های ۲ و ۴ اجرا کنید، باید عدد ۶ را در نتیجه ببینید.
- به بخش resources و resource template بروید و "greeting" را فراخوانی کنید، یک نام وارد کنید و باید پیامی با نام وارد شده مشاهده کنید.

### آزمایش در حالت CLI

ابزاری که اجرا کردید در واقع یک برنامه Node.js است و `mcp dev` یک پوشش برای آن است.

- سرور را با دستور `npm run build` راه‌اندازی کنید.

- در ترمینال جداگانه دستور زیر را اجرا کنید:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    این دستور تمام ابزارهای موجود در سرور را فهرست می‌کند. باید خروجی زیر را ببینید:

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

- برای فراخوانی یک نوع ابزار، دستور زیر را تایپ کنید:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

باید خروجی زیر را مشاهده کنید:

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
> معمولاً اجرای inspector در حالت CLI سریع‌تر از اجرای آن در مرورگر است.
> برای اطلاعات بیشتر درباره inspector اینجا را بخوانید [here](https://github.com/modelcontextprotocol/inspector).

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.