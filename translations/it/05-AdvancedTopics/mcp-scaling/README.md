<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-12T23:44:47+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "it"
}
-->
## معماری توزیع شده

معماری‌های توزیع شده شامل چندین گره MCP هستند که با هم همکاری می‌کنند تا درخواست‌ها را پردازش کنند، منابع را به اشتراک بگذارند و افزونگی فراهم کنند. این رویکرد با اجازه دادن به گره‌ها برای ارتباط و هماهنگی از طریق یک سیستم توزیع شده، مقیاس‌پذیری و تحمل خطا را افزایش می‌دهد.

بیایید به مثالی از نحوه پیاده‌سازی معماری سرور MCP توزیع شده با استفاده از Redis برای هماهنگی نگاهی بیندازیم.

## مرحله بعدی چیست

- [5.8 امنیت](../mcp-security/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.