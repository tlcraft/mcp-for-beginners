<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-09T22:27:13+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "fa"
}
-->
## شروع کار

این بخش شامل چندین درس است:

- **1 سرور اول شما**، در این درس اول، یاد می‌گیرید چگونه اولین سرور خود را بسازید و با ابزار inspector آن را بررسی کنید، روشی ارزشمند برای تست و اشکال‌زدایی سرور شما، [به درس](01-first-server/README.md)

- **2 کلاینت**، در این درس یاد می‌گیرید چگونه یک کلاینت بنویسید که بتواند به سرور شما متصل شود، [به درس](02-client/README.md)

- **3 کلاینت با LLM**، روشی بهتر برای نوشتن کلاینت اضافه کردن یک LLM به آن است تا بتواند با سرور شما "مذاکره" کند که چه کاری انجام دهد، [به درس](03-llm-client/README.md)

- **4 استفاده از حالت GitHub Copilot Agent سرور در Visual Studio Code**. در اینجا، به اجرای سرور MCP خود از داخل Visual Studio Code می‌پردازیم، [به درس](04-vscode/README.md)

- **5 استفاده از SSE (Server Sent Events)** SSE استانداردی برای پخش داده از سرور به کلاینت است که به سرورها اجازه می‌دهد به‌روزرسانی‌های لحظه‌ای را از طریق HTTP به کلاینت‌ها ارسال کنند، [به درس](05-sse-server/README.md)

- **6 پخش HTTP با MCP (Streamable HTTP)**. درباره پخش مدرن HTTP، اعلان‌های پیشرفت و نحوه پیاده‌سازی سرورها و کلاینت‌های MCP مقیاس‌پذیر و بلادرنگ با استفاده از Streamable HTTP بیاموزید، [به درس](06-http-streaming/README.md)

- **7 استفاده از AI Toolkit برای VSCode** برای مصرف و تست کلاینت‌ها و سرورهای MCP شما، [به درس](07-aitk/README.md)

- **8 تست**. در اینجا به ویژه تمرکز می‌کنیم که چگونه می‌توانیم سرور و کلاینت خود را به روش‌های مختلف تست کنیم، [به درس](08-testing/README.md)

- **9 استقرار**. این فصل به روش‌های مختلف استقرار راه‌حل‌های MCP شما می‌پردازد، [به درس](09-deployment/README.md)


پروتکل مدل کانتکست (MCP) یک پروتکل باز است که استانداردسازی نحوه ارائه کانتکست به LLMها توسط برنامه‌ها را فراهم می‌کند. MCP را مانند یک پورت USB-C برای برنامه‌های هوش مصنوعی در نظر بگیرید - روشی استاندارد برای اتصال مدل‌های هوش مصنوعی به منابع داده و ابزارهای مختلف.

## اهداف یادگیری

تا پایان این درس، شما قادر خواهید بود:

- راه‌اندازی محیط‌های توسعه برای MCP در C#، Java، Python، TypeScript و JavaScript
- ساخت و استقرار سرورهای پایه MCP با ویژگی‌های سفارشی (منابع، پرامپت‌ها و ابزارها)
- ایجاد برنامه‌های میزبان که به سرورهای MCP متصل می‌شوند
- تست و اشکال‌زدایی پیاده‌سازی‌های MCP
- درک چالش‌های رایج راه‌اندازی و راه‌حل‌های آن‌ها
- اتصال پیاده‌سازی‌های MCP خود به سرویس‌های محبوب LLM

## راه‌اندازی محیط MCP شما

قبل از شروع کار با MCP، مهم است که محیط توسعه خود را آماده کنید و جریان کاری پایه را درک کنید. این بخش شما را در مراحل اولیه راه‌اندازی برای شروعی روان با MCP راهنمایی می‌کند.

### پیش‌نیازها

قبل از شروع توسعه MCP، مطمئن شوید که دارید:

- **محیط توسعه**: برای زبان انتخابی شما (C#، Java، Python، TypeScript یا JavaScript)
- **IDE/ویرایشگر**: Visual Studio، Visual Studio Code، IntelliJ، Eclipse، PyCharm یا هر ویرایشگر کد مدرن دیگر
- **مدیران بسته**: NuGet، Maven/Gradle، pip یا npm/yarn
- **کلیدهای API**: برای هر سرویس هوش مصنوعی که قصد استفاده در برنامه‌های میزبان خود را دارید

### SDKهای رسمی

در فصل‌های بعدی، راه‌حل‌هایی را خواهید دید که با استفاده از Python، TypeScript، Java و .NET ساخته شده‌اند. در اینجا همه SDKهای رسمی پشتیبانی شده آمده است.

MCP SDKهای رسمی برای چند زبان ارائه می‌دهد:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - با همکاری مایکروسافت نگهداری می‌شود
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - با همکاری Spring AI نگهداری می‌شود
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - پیاده‌سازی رسمی TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - پیاده‌سازی رسمی Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - پیاده‌سازی رسمی Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - با همکاری Loopwork AI نگهداری می‌شود
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - پیاده‌سازی رسمی Rust

## نکات کلیدی

- راه‌اندازی محیط توسعه MCP با SDKهای مخصوص زبان بسیار ساده است
- ساخت سرورهای MCP شامل ایجاد و ثبت ابزارها با اسکیمای واضح است
- کلاینت‌های MCP به سرورها و مدل‌ها متصل می‌شوند تا قابلیت‌های گسترده‌تری را بهره‌مند شوند
- تست و اشکال‌زدایی برای پیاده‌سازی‌های قابل اعتماد MCP ضروری است
- گزینه‌های استقرار از توسعه محلی تا راه‌حل‌های مبتنی بر ابر متغیر است

## تمرین

ما مجموعه‌ای از نمونه‌ها داریم که تمرین‌های تمام فصل‌های این بخش را تکمیل می‌کند. علاوه بر این، هر فصل تمرین‌ها و تکالیف خاص خود را دارد.

- [ماشین حساب Java](./samples/java/calculator/README.md)
- [ماشین حساب .Net](../../../03-GettingStarted/samples/csharp)
- [ماشین حساب JavaScript](./samples/javascript/README.md)
- [ماشین حساب TypeScript](./samples/typescript/README.md)
- [ماشین حساب Python](../../../03-GettingStarted/samples/python)

## منابع اضافی

- [ساخت Agentها با استفاده از Model Context Protocol در Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP از راه دور با Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agent MCP OpenAI در .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## مرحله بعد

بعدی: [ساخت اولین سرور MCP شما](01-first-server/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.