<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:27:09+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "fa"
}
-->
### -2- ایجاد پروژه

حالا که SDK خود را نصب کرده‌اید، بیایید پروژه‌ای ایجاد کنیم:

### -3- ایجاد فایل‌های پروژه

### -4- نوشتن کد سرور

### -5- افزودن یک ابزار و یک منبع

با افزودن کد زیر، یک ابزار و یک منبع اضافه کنید:

### -6- کد نهایی

بیایید آخرین کدی را که برای راه‌اندازی سرور نیاز داریم اضافه کنیم:

### -7- تست سرور

سرور را با دستور زیر راه‌اندازی کنید:

### -8- اجرا با استفاده از Inspector

Inspector ابزاری عالی است که می‌تواند سرور شما را راه‌اندازی کند و به شما اجازه می‌دهد با آن تعامل داشته باشید تا مطمئن شوید که به درستی کار می‌کند. بیایید آن را اجرا کنیم:

> [!NOTE]
> ممکن است در فیلد "command" متفاوت به نظر برسد چون شامل دستور اجرای سرور با runtime خاص شماست.

شما باید رابط کاربری زیر را ببینید:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fa.png)

1. با انتخاب دکمه Connect به سرور متصل شوید  
   پس از اتصال به سرور، باید تصویر زیر را ببینید:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.fa.png)

2. "Tools" و سپس "listTools" را انتخاب کنید، باید گزینه "Add" ظاهر شود، "Add" را انتخاب کرده و مقادیر پارامترها را وارد کنید.

   باید پاسخ زیر را ببینید، یعنی نتیجه‌ای از ابزار "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.fa.png)

تبریک! شما موفق شدید اولین سرور خود را ایجاد و اجرا کنید!

### SDKهای رسمی

MCP SDKهای رسمی برای چند زبان ارائه می‌دهد:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - نگهداری شده با همکاری مایکروسافت  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - نگهداری شده با همکاری Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - پیاده‌سازی رسمی TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - پیاده‌سازی رسمی Python  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - پیاده‌سازی رسمی Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - نگهداری شده با همکاری Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - پیاده‌سازی رسمی Rust  

## نکات کلیدی

- راه‌اندازی محیط توسعه MCP با SDKهای مخصوص زبان‌ها ساده است  
- ساخت سرورهای MCP شامل ایجاد و ثبت ابزارها با اسکیمای واضح است  
- تست و اشکال‌زدایی برای پیاده‌سازی‌های قابل اطمینان MCP ضروری است  

## نمونه‌ها

- [ماشین حساب جاوا](../samples/java/calculator/README.md)  
- [ماشین حساب .Net](../../../../03-GettingStarted/samples/csharp)  
- [ماشین حساب جاوااسکریپت](../samples/javascript/README.md)  
- [ماشین حساب تایپ‌اسکریپت](../samples/typescript/README.md)  
- [ماشین حساب پایتون](../../../../03-GettingStarted/samples/python)  

## تمرین

یک سرور ساده MCP با ابزاری که خودتان انتخاب می‌کنید بسازید:  
1. ابزار را در زبان مورد علاقه خود پیاده‌سازی کنید (.NET، Java، Python یا JavaScript).  
2. پارامترهای ورودی و مقادیر بازگشتی را تعریف کنید.  
3. ابزار inspector را اجرا کنید تا مطمئن شوید سرور به درستی کار می‌کند.  
4. پیاده‌سازی را با ورودی‌های مختلف تست کنید.  

## راه‌حل

[راه‌حل](./solution/README.md)

## منابع اضافی

- [مخزن GitHub MCP](https://github.com/microsoft/mcp-for-beginners)

## گام بعدی

بعدی: [شروع کار با کلاینت‌های MCP](/03-GettingStarted/02-client/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه ماشینی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطا یا نادرستی باشند. سند اصلی به زبان بومی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا برداشت نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.