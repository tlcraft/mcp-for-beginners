<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T15:36:02+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "tr"
}
-->
# MCP'de İleri Konular

Bu bölüm, Model Context Protocol (MCP) uygulamasında çok modlu entegrasyon, ölçeklenebilirlik, güvenlik en iyi uygulamaları ve kurumsal entegrasyon gibi bir dizi ileri konuyu kapsamak için hazırlanmıştır. Bu konular, modern yapay zeka sistemlerinin gereksinimlerini karşılayabilen sağlam ve üretime hazır MCP uygulamaları geliştirmek için kritik öneme sahiptir.

## Genel Bakış

Bu ders, Model Context Protocol uygulamasında çok modlu entegrasyon, ölçeklenebilirlik, güvenlik en iyi uygulamaları ve kurumsal entegrasyon gibi ileri kavramları inceler. Bu konular, kurumsal ortamlarda karmaşık gereksinimleri karşılayabilen üretim kalitesinde MCP uygulamaları oluşturmak için gereklidir.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- MCP çerçeveleri içinde çok modlu yetenekleri uygulamak
- Yüksek talep senaryoları için ölçeklenebilir MCP mimarileri tasarlamak
- MCP'nin güvenlik prensipleriyle uyumlu güvenlik en iyi uygulamalarını uygulamak
- MCP'yi kurumsal yapay zeka sistemleri ve çerçeveleri ile entegre etmek
- Üretim ortamlarında performans ve güvenilirliği optimize etmek

## Dersler ve Örnek Projeler

| Bağlantı | Başlık | Açıklama |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Azure ile Entegrasyon | MCP Sunucunuzu Azure üzerinde nasıl entegre edeceğinizi öğrenin |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Çok Modlu Örnekler | Ses, görüntü ve çok modlu yanıtlar için örnekler |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | MCP ile OAuth2'yi hem Yetkilendirme hem de Kaynak Sunucusu olarak gösteren minimal Spring Boot uygulaması. Güvenli token verme, korumalı uç noktalar, Azure Container Apps dağıtımı ve API Yönetimi entegrasyonunu gösterir. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contextler | Root context hakkında daha fazla bilgi edinin ve nasıl uygulanacağını öğrenin |
| [5.5 Routing](./mcp-routing/README.md) | Yönlendirme | Farklı yönlendirme türlerini öğrenin |
| [5.6 Sampling](./mcp-sampling/README.md) | Örnekleme | Örnekleme ile nasıl çalışılacağını öğrenin |
| [5.7 Scaling](./mcp-scaling/README.md) | Ölçeklendirme | Ölçeklendirme hakkında bilgi edinin |
| [5.8 Security](./mcp-security/README.md) | Güvenlik | MCP Sunucunuzu güvence altına alın |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Arama MCP | SerpAPI ile gerçek zamanlı web, haber, ürün araması ve Soru-Cevap entegrasyonu yapan Python MCP sunucu ve istemcisi. Çoklu araç orkestrasyonu, harici API entegrasyonu ve sağlam hata yönetimi gösterir. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Akış | Gerçek zamanlı veri akışı, işletmelerin ve uygulamaların hızlı kararlar almak için anında bilgiye erişim ihtiyacının arttığı günümüz veri odaklı dünyasında vazgeçilmez hale gelmiştir. |

## Ek Kaynaklar

İleri MCP konuları hakkında en güncel bilgi için bakınız:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Önemli Noktalar

- Çok modlu MCP uygulamaları, yapay zekanın metin işleme dışındaki yeteneklerini genişletir
- Ölçeklenebilirlik, kurumsal dağıtımlar için esastır ve yatay ve dikey ölçeklendirme ile ele alınabilir
- Kapsamlı güvenlik önlemleri verileri korur ve uygun erişim kontrolünü sağlar
- Azure OpenAI ve Microsoft AI Foundry gibi platformlarla kurumsal entegrasyon, MCP yeteneklerini artırır
- İleri MCP uygulamaları optimize edilmiş mimariler ve dikkatli kaynak yönetimi ile fayda sağlar

## Alıştırma

Belirli bir kullanım durumu için kurumsal düzeyde bir MCP uygulaması tasarlayın:

1. Kullanım durumunuz için çok modlu gereksinimleri belirleyin
2. Hassas verileri korumak için gerekli güvenlik kontrollerini sıralayın
3. Değişken yükleri karşılayabilecek ölçeklenebilir bir mimari tasarlayın
4. Kurumsal yapay zeka sistemleriyle entegrasyon noktalarını planlayın
5. Olası performans darboğazlarını ve çözüm stratejilerini belgeleyin

## Ek Kaynaklar

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Sonraki Adım

- [5.1 MCP Integration](./mcp-integration/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorumlamalardan sorumlu değiliz.