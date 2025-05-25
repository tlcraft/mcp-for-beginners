<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:38:43+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

> [!NOTE]
> این نمونه فرض می‌کند که شما از یک نمونه GitHub Codespaces استفاده می‌کنید. اگر می‌خواهید این را به‌صورت محلی اجرا کنید، باید یک توکن دسترسی شخصی در GitHub تنظیم کنید.

## نصب کتابخانه‌ها

```sh
dotnet restore
```

باید کتابخانه‌های زیر را نصب کند: Azure AI Inference، Azure Identity، Microsoft.Extension، Model.Hosting، ModelContextProtocol

## اجرا

```sh 
dotnet run
```

باید خروجی مشابه زیر را مشاهده کنید:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

بخش زیادی از خروجی فقط اشکال‌زدایی است اما آنچه مهم است این است که شما ابزارهایی را از سرور MCP فهرست می‌کنید، آنها را به ابزارهای LLM تبدیل می‌کنید و در نهایت به پاسخ مشتری MCP "Sum 6" می‌رسید.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما در قبال هرگونه سوء تفاهم یا تفسیر نادرست ناشی از استفاده از این ترجمه مسئولیتی نداریم.