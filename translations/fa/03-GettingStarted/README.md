<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:18:40+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "fa"
}
-->
## شروع کار

این بخش شامل چندین درس است:

- **-1- اولین سرور شما**، در این درس اول، یاد می‌گیرید چگونه اولین سرور خود را ایجاد کنید و با ابزار inspector آن را بررسی کنید، روشی ارزشمند برای تست و دیباگ سرور شما، [به درس](/03-GettingStarted/01-first-server/README.md)

- **-2- کلاینت**، در این درس، یاد می‌گیرید چگونه یک کلاینت بنویسید که بتواند به سرور شما متصل شود، [به درس](/03-GettingStarted/02-client/README.md)

- **-3- کلاینت با LLM**، روشی بهتر برای نوشتن کلاینت این است که یک LLM به آن اضافه کنید تا بتواند با سرور شما "مذاکره" کند که چه کاری انجام دهد، [به درس](/03-GettingStarted/03-llm-client/README.md)

- **-4- استفاده از حالت GitHub Copilot Agent سرور در Visual Studio Code**. در اینجا، به اجرای MCP Server خود از داخل Visual Studio Code می‌پردازیم، [به درس](/03-GettingStarted/04-vscode/README.md)

- **-5- استفاده از SSE (Server Sent Events)** SSE یک استاندارد برای پخش جریان داده از سرور به کلاینت است که اجازه می‌دهد سرورها به‌روزرسانی‌های لحظه‌ای را از طریق HTTP به کلاینت‌ها ارسال کنند، [به درس](/03-GettingStarted/05-sse-server/README.md)

- **-6- استفاده از AI Toolkit برای VSCode** برای مصرف و تست کلاینت‌ها و سرورهای MCP شما، [به درس](/03-GettingStarted/06-aitk/README.md)

- **-7- تست**. در این بخش به‌ویژه تمرکز می‌کنیم که چگونه می‌توانیم سرور و کلاینت خود را به روش‌های مختلف تست کنیم، [به درس](/03-GettingStarted/07-testing/README.md)

- **-8- استقرار**. این فصل به روش‌های مختلف استقرار راه‌حل‌های MCP شما می‌پردازد، [به درس](/03-GettingStarted/08-deployment/README.md)


پروتکل مدل کانتکست (MCP) یک پروتکل باز است که استانداردسازی می‌کند چگونه برنامه‌ها کانتکست را به LLMها ارائه دهند. MCP را می‌توان مثل یک پورت USB-C برای برنامه‌های هوش مصنوعی در نظر گرفت – راهی استاندارد برای اتصال مدل‌های هوش مصنوعی به منابع داده و ابزارهای مختلف فراهم می‌کند.

## اهداف یادگیری

تا پایان این درس، شما قادر خواهید بود:

- راه‌اندازی محیط‌های توسعه برای MCP در C#، Java، Python، TypeScript و JavaScript
- ساخت و استقرار سرورهای پایه MCP با ویژگی‌های سفارشی (منابع، پرامپت‌ها و ابزارها)
- ایجاد برنامه‌های میزبان که به سرورهای MCP متصل می‌شوند
- تست و دیباگ پیاده‌سازی‌های MCP
- درک چالش‌های رایج راه‌اندازی و راه‌حل‌های آن‌ها
- اتصال پیاده‌سازی‌های MCP خود به سرویس‌های محبوب LLM

## راه‌اندازی محیط MCP شما

قبل از شروع به کار با MCP، مهم است که محیط توسعه خود را آماده کرده و جریان کاری پایه را درک کنید. این بخش شما را در مراحل اولیه راه‌اندازی همراهی می‌کند تا شروعی روان با MCP داشته باشید.

### پیش‌نیازها

قبل از شروع توسعه MCP، مطمئن شوید که دارید:

- **محیط توسعه**: برای زبان انتخابی شما (C#، Java، Python، TypeScript یا JavaScript)
- **IDE/ویرایشگر**: Visual Studio، Visual Studio Code، IntelliJ، Eclipse، PyCharm یا هر ویرایشگر کد مدرن دیگری
- **مدیر بسته‌ها**: NuGet، Maven/Gradle، pip یا npm/yarn
- **کلیدهای API**: برای هر سرویس هوش مصنوعی که قصد استفاده در برنامه‌های میزبان خود را دارید


### SDKهای رسمی

در فصل‌های بعدی، راه‌حل‌هایی را با استفاده از Python، TypeScript، Java و .NET خواهید دید. اینجا همه SDKهای رسمی پشتیبانی شده آمده است.

MCP SDKهای رسمی برای چندین زبان ارائه می‌دهد:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - نگهداری شده با همکاری مایکروسافت
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - نگهداری شده با همکاری Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - پیاده‌سازی رسمی TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - پیاده‌سازی رسمی Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - پیاده‌سازی رسمی Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - نگهداری شده با همکاری Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - پیاده‌سازی رسمی Rust

## نکات کلیدی

- راه‌اندازی محیط توسعه MCP با SDKهای مخصوص هر زبان ساده است
- ساخت سرورهای MCP شامل ایجاد و ثبت ابزارها با اسکیمای واضح است
- کلاینت‌های MCP به سرورها و مدل‌ها متصل می‌شوند تا قابلیت‌های گسترده‌تر را بهره‌برداری کنند
- تست و دیباگ برای پیاده‌سازی‌های قابل اطمینان MCP ضروری است
- گزینه‌های استقرار از توسعه محلی تا راه‌حل‌های ابری متنوع است

## تمرین

ما مجموعه‌ای از نمونه‌ها داریم که مکمل تمرین‌هایی هستند که در همه فصل‌های این بخش خواهید دید. علاوه بر این، هر فصل تمرین‌ها و تکالیف مخصوص به خود را دارد.

- [ماشین حساب Java](./samples/java/calculator/README.md)
- [ماشین حساب .Net](../../../03-GettingStarted/samples/csharp)
- [ماشین حساب JavaScript](./samples/javascript/README.md)
- [ماشین حساب TypeScript](./samples/typescript/README.md)
- [ماشین حساب Python](../../../03-GettingStarted/samples/python)

## منابع اضافی

- [ساخت Agentها با استفاده از Model Context Protocol در Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP راه دور با Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agent MCP OpenAI در .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## مرحله بعدی

بعدی: [ایجاد اولین سرور MCP خود](/03-GettingStarted/01-first-server/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، توصیه می‌شود از ترجمه حرفه‌ای انسانی استفاده شود. ما مسئول هیچ گونه سوءتفاهم یا برداشت نادرستی که ناشی از استفاده از این ترجمه باشد، نیستیم.