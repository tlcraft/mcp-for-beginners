<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:19:10+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "fa"
}
-->
### -2- ایجاد پروژه

حالا که SDK خود را نصب کرده‌اید، بیایید پروژه‌ای بسازیم:

### -3- ایجاد فایل‌های پروژه

### -4- نوشتن کد سرور

### -5- اضافه کردن یک ابزار و یک منبع

با اضافه کردن کد زیر، یک ابزار و یک منبع اضافه کنید:

### -6- کد نهایی

بیایید آخرین کدی که نیاز داریم تا سرور شروع به کار کند را اضافه کنیم:

### -7- آزمایش سرور

سرور را با دستور زیر اجرا کنید:

### -8- اجرا با استفاده از Inspector

Inspector یک ابزار عالی است که می‌تواند سرور شما را راه‌اندازی کند و به شما اجازه می‌دهد با آن تعامل داشته باشید تا مطمئن شوید که کار می‌کند. بیایید آن را راه‌اندازی کنیم:

> [!NOTE]
> ممکن است در فیلد "command" متفاوت به نظر برسد چون دستور اجرای سرور با runtime خاص شما را نشان می‌دهد.

شما باید رابط کاربری زیر را ببینید:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fa.png)

1. با انتخاب دکمه Connect به سرور متصل شوید  
   پس از اتصال به سرور، باید موارد زیر را مشاهده کنید:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.fa.png)

2. "Tools" و سپس "listTools" را انتخاب کنید، باید گزینه "Add" ظاهر شود، "Add" را انتخاب کرده و مقادیر پارامترها را وارد کنید.

   باید پاسخ زیر را ببینید، یعنی نتیجه اجرای ابزار "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.fa.png)

تبریک! شما موفق شدید اولین سرور خود را ایجاد و اجرا کنید!

### SDKهای رسمی

MCP SDKهای رسمی برای چندین زبان ارائه می‌دهد:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - نگهداری شده با همکاری مایکروسافت  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - نگهداری شده با همکاری Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - پیاده‌سازی رسمی TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - پیاده‌سازی رسمی Python  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - پیاده‌سازی رسمی Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - نگهداری شده با همکاری Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - پیاده‌سازی رسمی Rust  

## نکات کلیدی

- راه‌اندازی محیط توسعه MCP با SDKهای مخصوص زبان به سادگی انجام می‌شود  
- ساخت سرورهای MCP شامل ایجاد و ثبت ابزارها با اسکیمای مشخص است  
- آزمایش و اشکال‌زدایی برای پیاده‌سازی‌های قابل اعتماد MCP ضروری است  

## نمونه‌ها

- [ماشین حساب Java](../samples/java/calculator/README.md)  
- [ماشین حساب .Net](../../../../03-GettingStarted/samples/csharp)  
- [ماشین حساب JavaScript](../samples/javascript/README.md)  
- [ماشین حساب TypeScript](../samples/typescript/README.md)  
- [ماشین حساب Python](../../../../03-GettingStarted/samples/python)  

## تمرین

یک سرور ساده MCP با یک ابزار دلخواه بسازید:  
1. ابزار را به زبان مورد علاقه‌تان (.NET، Java، Python یا JavaScript) پیاده‌سازی کنید.  
2. پارامترهای ورودی و مقادیر بازگشتی را تعریف کنید.  
3. ابزار inspector را اجرا کنید تا مطمئن شوید سرور طبق انتظار کار می‌کند.  
4. پیاده‌سازی را با ورودی‌های مختلف آزمایش کنید.  

## راه‌حل

[راه‌حل](./solution/README.md)  

## منابع اضافی

- [ساخت Agentها با استفاده از Model Context Protocol در Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [MCP راه دور با Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [Agent MCP OpenAI در .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## ادامه مسیر

بعدی: [شروع کار با کلاینت‌های MCP](/03-GettingStarted/02-client/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی اشتباهات یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا برداشت نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.