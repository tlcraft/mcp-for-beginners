<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-12T23:49:01+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "tr"
}
-->
## Dağıtık Mimari

Dağıtık mimariler, istekleri işlemek, kaynakları paylaşmak ve yedeklilik sağlamak için bir arada çalışan birden fazla MCP düğümünü içerir. Bu yaklaşım, düğümlerin bir dağıtık sistem üzerinden iletişim kurup koordinasyon sağlamasına olanak tanıyarak ölçeklenebilirliği ve hata toleransını artırır.

Koordinasyon için Redis kullanarak dağıtık bir MCP sunucu mimarisi nasıl uygulanır, buna bir örnek inceleyelim.

## Sırada ne var

- [5.8 Güvenlik](../mcp-security/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek herhangi bir yanlış anlama veya yanlış yorumdan sorumlu değiliz.