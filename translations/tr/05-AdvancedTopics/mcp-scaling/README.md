<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-07-14T02:30:17+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "tr"
}
-->
## Dağıtık Mimari

Dağıtık mimariler, birden fazla MCP düğümünün birlikte çalışarak istekleri karşılaması, kaynakları paylaşması ve yedeklilik sağlamasıdır. Bu yaklaşım, düğümlerin dağıtık bir sistem aracılığıyla iletişim kurup koordinasyon sağlamasına olanak tanıyarak ölçeklenebilirliği ve hata toleransını artırır.

Redis kullanarak koordinasyon sağlanan dağıtık bir MCP sunucu mimarisi nasıl uygulanır, buna bir örnekle bakalım.

## Sonraki Adımlar

- [5.8 Güvenlik](../mcp-security/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.