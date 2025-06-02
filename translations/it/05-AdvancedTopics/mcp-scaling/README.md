<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:54:23+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "it"
}
-->
## مقیاس‌پذیری عمودی و بهینه‌سازی منابع

مقیاس‌پذیری عمودی بر بهینه‌سازی یک نمونه سرور MCP تمرکز دارد تا بتواند درخواست‌های بیشتری را به‌طور کارآمد مدیریت کند. این کار با تنظیم دقیق پیکربندی‌ها، استفاده از الگوریتم‌های بهینه و مدیریت مؤثر منابع انجام می‌شود. به‌عنوان مثال، می‌توانید تنظیمات thread pool، زمان‌ انتظار درخواست‌ها و محدودیت‌های حافظه را برای بهبود عملکرد تغییر دهید.

بیایید نگاهی به نمونه‌ای بیندازیم که چگونه می‌توان یک سرور MCP را برای مقیاس‌پذیری عمودی و مدیریت منابع بهینه کرد.

## معماری توزیع‌شده

معماری‌های توزیع‌شده شامل چندین گره MCP است که با هم کار می‌کنند تا درخواست‌ها را مدیریت کنند، منابع را به اشتراک بگذارند و افزونگی فراهم کنند. این رویکرد با اجازه دادن به گره‌ها برای ارتباط و هماهنگی از طریق یک سیستم توزیع‌شده، مقیاس‌پذیری و تحمل خطا را افزایش می‌دهد.

بیایید نمونه‌ای را بررسی کنیم که چگونه می‌توان معماری سرور MCP توزیع‌شده را با استفاده از Redis برای هماهنگی پیاده‌سازی کرد.

## مرحله بعد

- [Security](../mcp-security/README.md)

**Avvertenza**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali fraintendimenti o interpretazioni errate derivanti dall’uso di questa traduzione.