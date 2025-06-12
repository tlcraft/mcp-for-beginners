<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T21:57:01+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "fa"
}
-->
## شروع کار

این بخش شامل چندین درس است:

- **1 اولین سرور شما**، در این درس اول، یاد می‌گیرید چگونه اولین سرور خود را ایجاد کنید و با استفاده از ابزار inspector آن را بررسی کنید، روشی ارزشمند برای تست و اشکال‌زدایی سرور شما، [به درس](/03-GettingStarted/01-first-server/README.md)

- **2 کلاینت**، در این درس، نحوه نوشتن کلاینتی که بتواند به سرور شما متصل شود را یاد می‌گیرید، [به درس](/03-GettingStarted/02-client/README.md)

- **3 کلاینت با LLM**، روشی حتی بهتر برای نوشتن کلاینت، اضافه کردن یک LLM به آن است تا بتواند با سرور شما "مذاکره" کند که چه کاری انجام دهد، [به درس](/03-GettingStarted/03-llm-client/README.md)

- **4 استفاده از حالت GitHub Copilot Agent سرور در Visual Studio Code**. در اینجا، به اجرای MCP Server خود از داخل Visual Studio Code می‌پردازیم، [به درس](/03-GettingStarted/04-vscode/README.md)

- **5 استفاده از SSE (Server Sent Events)** SSE استانداردی برای پخش اطلاعات از سرور به کلاینت است که به سرورها اجازه می‌دهد به‌روزرسانی‌های زمان واقعی را از طریق HTTP به کلاینت‌ها ارسال کنند، [به درس](/03-GettingStarted/05-sse-server/README.md)

- **6 پخش HTTP با MCP (Streamable HTTP)**. درباره پخش مدرن HTTP، اعلان‌های پیشرفت، و نحوه پیاده‌سازی سرورها و کلاینت‌های MCP مقیاس‌پذیر و زمان واقعی با استفاده از Streamable HTTP بیاموزید. [به درس](/03-GettingStarted/06-http-streaming/README.md)

- **7 استفاده از AI Toolkit برای VSCode** برای استفاده و تست کلاینت‌ها و سرورهای MCP شما [به درس](/03-GettingStarted/07-aitk/README.md)

- **8 تست**. در این بخش به ویژه تمرکز می‌کنیم که چگونه می‌توانیم سرور و کلاینت خود را به روش‌های مختلف تست کنیم، [به درس](/03-GettingStarted/08-testing/README.md)

- **9 استقرار**. این فصل به بررسی روش‌های مختلف استقرار راهکارهای MCP شما می‌پردازد، [به درس](/03-GettingStarted/09-deployment/README.md)

پروتکل Model Context (MCP) یک پروتکل باز است که استانداردسازی می‌کند چگونه برنامه‌ها به LLMها زمینه ارائه می‌دهند. MCP را مانند یک پورت USB-C برای برنامه‌های هوش مصنوعی در نظر بگیرید - راهی استاندارد برای اتصال مدل‌های هوش مصنوعی به منابع داده و ابزارهای مختلف فراهم می‌کند.

## اهداف یادگیری

تا پایان این درس، قادر خواهید بود:

- راه‌اندازی محیط‌های توسعه برای MCP در C#، Java، Python، TypeScript و JavaScript
- ساخت و استقرار سرورهای پایه MCP با ویژگی‌های سفارشی (منابع، درخواست‌ها و ابزارها)
- ایجاد برنامه‌های میزبان که به سرورهای MCP متصل می‌شوند
- تست و اشکال‌زدایی پیاده‌سازی‌های MCP
- درک چالش‌های رایج در راه‌اندازی و راه‌حل‌های آن‌ها
- اتصال پیاده‌سازی‌های MCP خود به سرویس‌های محبوب LLM

## راه‌اندازی محیط MCP شما

قبل از شروع کار با MCP، مهم است که محیط توسعه خود را آماده کنید و جریان کاری پایه را درک کنید. این بخش شما را در مراحل اولیه راه‌اندازی برای شروع روان با MCP راهنمایی می‌کند.

### پیش‌نیازها

قبل از ورود به توسعه MCP، مطمئن شوید که:

- **محیط توسعه**: برای زبان انتخابی شما (C#، Java، Python، TypeScript یا JavaScript)
- **IDE/ویرایشگر**: Visual Studio، Visual Studio Code، IntelliJ، Eclipse، PyCharm یا هر ویرایشگر کد مدرن دیگر
- **مدیر بسته‌ها**: NuGet، Maven/Gradle، pip یا npm/yarn
- **کلیدهای API**: برای هر سرویس هوش مصنوعی که قصد دارید در برنامه‌های میزبان خود استفاده کنید

### SDKهای رسمی

در فصل‌های آینده، راه‌حل‌هایی را با استفاده از Python، TypeScript، Java و .NET خواهید دید. در اینجا تمام SDKهای رسمی پشتیبانی شده آورده شده‌اند.

MCP SDKهای رسمی برای چند زبان ارائه می‌دهد:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - با همکاری مایکروسافت نگهداری می‌شود
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - با همکاری Spring AI نگهداری می‌شود
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - پیاده‌سازی رسمی TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - پیاده‌سازی رسمی Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - پیاده‌سازی رسمی Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - با همکاری Loopwork AI نگهداری می‌شود
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - پیاده‌سازی رسمی Rust

## نکات کلیدی

- راه‌اندازی محیط توسعه MCP با SDKهای مخصوص زبان ساده است
- ساخت سرورهای MCP شامل ایجاد و ثبت ابزارها با طرح‌های واضح است
- کلاینت‌های MCP به سرورها و مدل‌ها متصل می‌شوند تا قابلیت‌های گسترش یافته را بهره‌مند شوند
- تست و اشکال‌زدایی برای پیاده‌سازی‌های قابل اعتماد MCP ضروری است
- گزینه‌های استقرار از توسعه محلی تا راه‌حل‌های مبتنی بر ابر متنوع است

## تمرین

ما مجموعه‌ای از نمونه‌ها داریم که تمرین‌های تمام فصل‌های این بخش را تکمیل می‌کنند. علاوه بر این، هر فصل تمرین‌ها و تکالیف مخصوص به خود را دارد.

- [ماشین حساب جاوا](./samples/java/calculator/README.md)
- [ماشین حساب .Net](../../../03-GettingStarted/samples/csharp)
- [ماشین حساب جاوااسکریپت](./samples/javascript/README.md)
- [ماشین حساب تایپ‌اسکریپت](./samples/typescript/README.md)
- [ماشین حساب پایتون](../../../03-GettingStarted/samples/python)

## منابع اضافی

- [ساخت Agentها با استفاده از Model Context Protocol در Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP از راه دور با Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agent MCP OpenAI برای .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## مرحله بعد

بعدی: [ایجاد اولین سرور MCP خود](/03-GettingStarted/01-first-server/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی اشتباهات یا نواقص باشند. سند اصلی به زبان بومی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.