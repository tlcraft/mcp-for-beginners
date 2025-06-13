<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:34:32+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ms"
}
-->
عالی، برای مرحله بعدی، بیایید قابلیت‌های سرور را فهرست کنیم.

### -2 فهرست کردن قابلیت‌های سرور

حالا به سرور متصل می‌شویم و قابلیت‌های آن را درخواست می‌کنیم:

### -3 تبدیل قابلیت‌های سرور به ابزارهای LLM

گام بعدی پس از فهرست کردن قابلیت‌های سرور، تبدیل آنها به فرمتی است که LLM بتواند بفهمد. وقتی این کار را انجام دادیم، می‌توانیم این قابلیت‌ها را به عنوان ابزار به LLM خود ارائه دهیم.

عالی، حالا آماده‌ایم تا درخواست‌های کاربر را مدیریت کنیم، پس بیایید این قسمت را پیاده‌سازی کنیم.

### -4 مدیریت درخواست پرامپت کاربر

در این بخش از کد، درخواست‌های کاربر را مدیریت خواهیم کرد.

عالی، انجامش دادی!

## تمرین

کد تمرین را بردار و سرور را با ابزارهای بیشتری توسعه بده. سپس یک کلاینت با LLM بساز، مانند تمرین، و آن را با پرامپت‌های مختلف تست کن تا مطمئن شوی تمام ابزارهای سرور به صورت داینامیک فراخوانی می‌شوند. این روش ساخت کلاینت باعث می‌شود تجربه کاربری بسیار بهتری داشته باشی، چون کاربران می‌توانند با استفاده از پرامپت‌ها به جای دستورات دقیق کلاینت، تعامل کنند و از وجود هر سرور MCP بی‌خبر باشند.

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

## مرحله بعد

- مرحله بعد: [استفاده از سرور با Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.