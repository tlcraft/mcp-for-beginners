<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:19:59+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "it"
}
-->
Great, برای مرحله بعدی، بیایید قابلیت‌های سرور را فهرست کنیم.

### -2 فهرست کردن قابلیت‌های سرور

حالا به سرور متصل می‌شویم و قابلیت‌های آن را درخواست می‌کنیم:

### -3- تبدیل قابلیت‌های سرور به ابزارهای LLM

گام بعدی پس از فهرست کردن قابلیت‌های سرور، تبدیل آن‌ها به فرمتی است که LLM بتواند آن را درک کند. پس از انجام این کار، می‌توانیم این قابلیت‌ها را به عنوان ابزارهایی برای LLM خود فراهم کنیم.

عالی است، حالا که آماده‌ایم تا درخواست‌های کاربر را مدیریت کنیم، بیایید این بخش را پیاده‌سازی کنیم.

### -4- مدیریت درخواست‌های پرامپت کاربر

در این بخش از کد، درخواست‌های کاربر را مدیریت خواهیم کرد.

عالی بود، شما موفق شدید!

## تمرین

کد تمرین را بردارید و سرور را با ابزارهای بیشتری گسترش دهید. سپس یک کلاینت با LLM بسازید، همانطور که در تمرین انجام دادیم، و آن را با پرامپت‌های مختلف آزمایش کنید تا مطمئن شوید همه ابزارهای سرور شما به صورت داینامیک فراخوانی می‌شوند. این روش ساخت کلاینت باعث می‌شود که کاربر نهایی تجربه کاربری بسیار خوبی داشته باشد، زیرا می‌تواند به جای دستورات دقیق کلاینت، از پرامپت‌ها استفاده کند و از فراخوانی هر سرور MCP بی‌اطلاع باشد.

## راه حل

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## نکات کلیدی

- افزودن LLM به کلاینت شما راه بهتری برای تعامل کاربران با سرورهای MCP فراهم می‌کند.
- باید پاسخ سرور MCP را به فرمتی تبدیل کنید که LLM بتواند آن را درک کند.

## نمونه‌ها

- [ماشین حساب جاوا](../samples/java/calculator/README.md)
- [ماشین حساب .Net](../../../../03-GettingStarted/samples/csharp)
- [ماشین حساب جاوااسکریپت](../samples/javascript/README.md)
- [ماشین حساب تایپ‌اسکریپت](../samples/typescript/README.md)
- [ماشین حساب پایتون](../../../../03-GettingStarted/samples/python)

## منابع اضافی

## گام بعدی

- بعدی: [مصرف یک سرور با استفاده از Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Avvertenza**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale umana. Non ci assumiamo alcuna responsabilità per eventuali fraintendimenti o interpretazioni errate derivanti dall’uso di questa traduzione.