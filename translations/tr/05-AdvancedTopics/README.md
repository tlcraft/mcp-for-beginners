<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:01:38+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "tr"
}
-->
# MCP'de İleri Konular

Bu bölüm, Model Context Protocol (MCP) uygulamasında çok modlu entegrasyon, ölçeklenebilirlik, güvenlik en iyi uygulamaları ve kurumsal entegrasyon gibi bir dizi ileri konuyu ele almayı amaçlamaktadır. Bu konular, modern yapay zeka sistemlerinin gereksinimlerini karşılayabilen sağlam ve üretime hazır MCP uygulamaları geliştirmek için çok önemlidir.

## Genel Bakış

Bu ders, Model Context Protocol uygulamasında çok modlu entegrasyon, ölçeklenebilirlik, güvenlik en iyi uygulamaları ve kurumsal entegrasyona odaklanarak ileri kavramları inceler. Bu konular, kurumsal ortamlarda karmaşık gereksinimleri karşılayabilen üretim kalitesinde MCP uygulamaları oluşturmak için gereklidir.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- MCP çerçeveleri içinde çok modlu yetenekleri uygulamak
- Yüksek talep senaryoları için ölçeklenebilir MCP mimarileri tasarlamak
- MCP’nin güvenlik prensiplerine uygun güvenlik en iyi uygulamalarını uygulamak
- MCP’yi kurumsal yapay zeka sistemleri ve çerçeveleri ile entegre etmek
- Üretim ortamlarında performans ve güvenilirliği optimize etmek

## Dersler ve Örnek Projeler

| Link | Başlık | Açıklama |
|------|--------|----------|
| [5.1 Azure ile Entegrasyon](./mcp-integration/README.md) | Azure ile Entegrasyon | MCP Sunucunuzu Azure üzerinde nasıl entegre edeceğinizi öğrenin |
| [5.2 Çok Modlu Örnek](./mcp-multi-modality/README.md) | MCP Çok Modlu Örnekler | Ses, görüntü ve çok modlu yanıtlar için örnekler |
| [5.3 MCP OAuth2 Örneği](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | MCP ile OAuth2’yi hem Yetkilendirme hem de Kaynak Sunucusu olarak gösteren minimal Spring Boot uygulaması. Güvenli token dağıtımı, korumalı uç noktalar, Azure Container Apps dağıtımı ve API Yönetimi entegrasyonunu gösterir. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contextler | Root context hakkında daha fazla bilgi edinin ve nasıl uygulanacağını öğrenin |
| [5.5 Yönlendirme](./mcp-routing/README.md) | Yönlendirme | Farklı yönlendirme türlerini öğrenin |
| [5.6 Örnekleme](./mcp-sampling/README.md) | Örnekleme | Örnekleme ile nasıl çalışılacağını öğrenin |
| [5.7 Ölçeklendirme](./mcp-scaling/README.md) | Ölçeklendirme | Ölçeklendirme hakkında bilgi edinin |
| [5.8 Güvenlik](./mcp-security/README.md) | Güvenlik | MCP Sunucunuzu güvence altına alın |
| [5.9 Web Arama Örneği](./web-search-mcp/README.md) | Web Arama MCP | Python MCP sunucusu ve istemcisi, SerpAPI ile gerçek zamanlı web, haber, ürün araması ve Soru-Cevap entegrasyonu sağlar. Çoklu araç orkestrasyonu, dış API entegrasyonu ve sağlam hata yönetimi gösterir. |

## Ek Kaynaklar

İleri MCP konuları hakkında en güncel bilgi için bakınız:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Önemli Noktalar

- Çok modlu MCP uygulamaları, yapay zekanın metin işleme dışındaki yeteneklerini genişletir
- Ölçeklenebilirlik, kurumsal dağıtımlar için kritik olup yatay ve dikey ölçeklendirme ile ele alınabilir
- Kapsamlı güvenlik önlemleri, verileri korur ve uygun erişim kontrolünü sağlar
- Azure OpenAI ve Microsoft AI Foundry gibi platformlarla kurumsal entegrasyon, MCP yeteneklerini artırır
- İleri MCP uygulamaları, optimize mimariler ve dikkatli kaynak yönetimi ile avantaj sağlar

## Alıştırma

Belirli bir kullanım senaryosu için kurumsal düzeyde bir MCP uygulaması tasarlayın:

1. Kullanım senaryonuz için çok modlu gereksinimleri belirleyin
2. Hassas verileri korumak için gerekli güvenlik kontrollerini tasarlayın
3. Değişken yükleri karşılayabilecek ölçeklenebilir bir mimari oluşturun
4. Kurumsal yapay zeka sistemleri ile entegrasyon noktalarını planlayın
5. Olası performans darboğazlarını ve çözüm stratejilerini belgeleyin

## Ek Kaynaklar

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Sonraki Adım

- [5.1 MCP Entegrasyonu](./mcp-integration/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba sarf etsek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı nedeniyle ortaya çıkabilecek yanlış anlamalar veya yorum farklılıklarından sorumlu değiliz.