<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-07-14T02:02:45+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "tr"
}
-->
## Örnek: Finansal Analiz için Root Context Uygulaması

Bu örnekte, bir finansal analiz oturumu için root context oluşturacağız ve birden fazla etkileşim boyunca durumu nasıl koruyacağımızı göstereceğiz.

## Örnek: Root Context Yönetimi

Root context'leri etkili bir şekilde yönetmek, konuşma geçmişi ve durumu korumak için çok önemlidir. Aşağıda root context yönetiminin nasıl uygulanacağına dair bir örnek bulunmaktadır.

## Çok Turlu Yardım için Root Context

Bu örnekte, çok turlu yardım oturumu için bir root context oluşturacağız ve birden fazla etkileşim boyunca durumu nasıl koruyacağımızı göstereceğiz.

## Root Context En İyi Uygulamaları

Root context'leri etkili bir şekilde yönetmek için bazı en iyi uygulamalar şunlardır:

- **Odaklanmış Context'ler Oluşturun**: Farklı konuşma amaçları veya alanları için ayrı root context'ler oluşturarak netliği koruyun.

- **Süre Sonu Politikaları Belirleyin**: Depolamayı yönetmek ve veri saklama politikalarına uymak için eski context'leri arşivleme veya silme politikaları uygulayın.

- **İlgili Meta Verileri Saklayın**: Konuşma hakkında ileride faydalı olabilecek önemli bilgileri saklamak için context meta verilerini kullanın.

- **Context ID'lerini Tutarlı Kullanın**: Bir context oluşturulduktan sonra, sürekliliği sağlamak için tüm ilgili isteklerde aynı ID'yi kullanın.

- **Özetler Oluşturun**: Context büyüdüğünde, önemli bilgileri yakalamak ve context boyutunu yönetmek için özetler oluşturmayı düşünün.

- **Erişim Kontrolü Uygulayın**: Çok kullanıcılı sistemlerde, konuşma context'lerinin gizliliği ve güvenliği için uygun erişim kontrolleri uygulayın.

- **Context Sınırlamalarını Yönetin**: Context boyutu sınırlamalarının farkında olun ve çok uzun konuşmalar için stratejiler geliştirin.

- **Tamamlandığında Arşivleyin**: Konuşmalar tamamlandığında, kaynakları serbest bırakmak ve konuşma geçmişini korumak için context'leri arşivleyin.

## Sonraki Adımlar

- [5.5 Routing](../mcp-routing/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.