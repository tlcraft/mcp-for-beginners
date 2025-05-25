<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:53:04+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

این نمونه شامل داشتن یک LLM در سمت مشتری است. برای اجرای این نمونه، نیاز دارید که آن را در یک Codespaces اجرا کنید یا یک توکن دسترسی شخصی در GitHub تنظیم کنید.

## -1- نصب وابستگی‌ها

```bash
npm install
```

## -3- اجرای سرور

```bash
npm run build
```

## -4- اجرای مشتری

```sh
npm run client
```

شما باید نتیجه‌ای مشابه زیر ببینید:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل خطاها یا نادرستی‌ها باشند. سند اصلی به زبان اصلی باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه انسانی حرفه‌ای توصیه می‌شود. ما مسئولیت هیچ‌گونه سوء تفاهم یا تفسیر نادرستی که از استفاده از این ترجمه ناشی شود را نمی‌پذیریم.