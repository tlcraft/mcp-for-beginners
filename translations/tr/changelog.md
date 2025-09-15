<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:11:47+00:00",
  "source_file": "changelog.md",
  "language_code": "tr"
}
-->
# Değişiklik Günlüğü: Yeni Başlayanlar için MCP Müfredatı

Bu belge, Model Context Protocol (MCP) için Yeni Başlayanlar müfredatında yapılan tüm önemli değişikliklerin kaydını tutar. Değişiklikler, ters kronolojik sırayla (en yeni değişiklikler önce) belgelenmiştir.

## 15 Eylül 2025

### Gelişmiş Konular Genişletmesi - Özel Taşıma Mekanizmaları ve Bağlam Mühendisliği

#### MCP Özel Taşıma Mekanizmaları (05-AdvancedTopics/mcp-transport/) - Yeni Gelişmiş Uygulama Kılavuzu
- **README.md**: Özel MCP taşıma mekanizmaları için eksiksiz uygulama kılavuzu
  - **Azure Event Grid Taşıma Mekanizması**: Kapsamlı sunucusuz olay odaklı taşıma mekanizması uygulaması
    - Azure Functions entegrasyonu ile C#, TypeScript ve Python örnekleri
    - Ölçeklenebilir MCP çözümleri için olay odaklı mimari desenler
    - Webhook alıcıları ve itme tabanlı mesaj işleme
  - **Azure Event Hubs Taşıma Mekanizması**: Yüksek verimli akış taşıma mekanizması uygulaması
    - Düşük gecikme senaryoları için gerçek zamanlı akış yetenekleri
    - Bölümlendirme stratejileri ve kontrol noktası yönetimi
    - Mesaj gruplama ve performans optimizasyonu
  - **Kurumsal Entegrasyon Desenleri**: Üretime hazır mimari örnekler
    - Birden fazla Azure Functions arasında dağıtılmış MCP işleme
    - Birden fazla taşıma türünü birleştiren hibrit taşıma mimarileri
    - Mesaj dayanıklılığı, güvenilirlik ve hata işleme stratejileri
  - **Güvenlik ve İzleme**: Azure Key Vault entegrasyonu ve gözlemlenebilirlik desenleri
    - Yönetilen kimlik doğrulama ve en az ayrıcalıklı erişim
    - Application Insights telemetri ve performans izleme
    - Devre kesiciler ve hata toleransı desenleri
  - **Test Çerçeveleri**: Özel taşıma mekanizmaları için kapsamlı test stratejileri
    - Test doubles ve mocking çerçeveleri ile birim testi
    - Azure Test Containers ile entegrasyon testi
    - Performans ve yük testi değerlendirmeleri

#### Bağlam Mühendisliği (05-AdvancedTopics/mcp-contextengineering/) - Gelişen AI Disiplini
- **README.md**: Bağlam mühendisliğini gelişen bir alan olarak kapsamlı bir şekilde keşfetme
  - **Temel İlkeler**: Tam bağlam paylaşımı, eylem karar farkındalığı ve bağlam pencere yönetimi
  - **MCP Protokol Uyumu**: MCP tasarımının bağlam mühendisliği zorluklarını nasıl ele aldığı
    - Bağlam pencere sınırlamaları ve aşamalı yükleme stratejileri
    - Alaka belirleme ve dinamik bağlam alma
    - Çok modlu bağlam işleme ve güvenlik değerlendirmeleri
  - **Uygulama Yaklaşımları**: Tek iş parçacıklı ve çoklu ajan mimarileri
    - Bağlam parçalama ve önceliklendirme teknikleri
    - Aşamalı bağlam yükleme ve sıkıştırma stratejileri
    - Katmanlı bağlam yaklaşımları ve alma optimizasyonu
  - **Ölçüm Çerçevesi**: Bağlam etkinliğini değerlendirmek için gelişen metrikler
    - Girdi verimliliği, performans, kalite ve kullanıcı deneyimi değerlendirmeleri
    - Bağlam optimizasyonu için deneysel yaklaşımlar
    - Hata analizi ve iyileştirme metodolojileri

#### Müfredat Navigasyon Güncellemeleri (README.md)
- **Geliştirilmiş Modül Yapısı**: Yeni gelişmiş konuları içerecek şekilde güncellenmiş müfredat tablosu
  - Bağlam Mühendisliği (5.14) ve Özel Taşıma Mekanizmaları (5.15) girişleri eklendi
  - Tüm modüller arasında tutarlı formatlama ve navigasyon bağlantıları
  - Mevcut içerik kapsamını yansıtacak şekilde güncellenmiş açıklamalar

### Dizin Yapısı İyileştirmeleri
- **Adlandırma Standartlaştırması**: "mcp transport" klasörü, diğer gelişmiş konu klasörleriyle tutarlılık sağlamak için "mcp-transport" olarak yeniden adlandırıldı
- **İçerik Organizasyonu**: Tüm 05-AdvancedTopics klasörleri artık tutarlı bir adlandırma düzenini takip ediyor (mcp-[konu])

### Dokümantasyon Kalitesi İyileştirmeleri
- **MCP Spesifikasyon Uyumu**: Tüm yeni içerik, mevcut MCP Spesifikasyonu 2025-06-18'e referans veriyor
- **Çok Dilli Örnekler**: C#, TypeScript ve Python'da kapsamlı kod örnekleri
- **Kurumsal Odak**: Üretime hazır desenler ve Azure bulut entegrasyonu
- **Görsel Dokümantasyon**: Mimari ve akış görselleştirme için Mermaid diyagramları

## 18 Ağustos 2025

### Dokümantasyon Kapsamlı Güncellemesi - MCP 2025-06-18 Standartları

#### MCP Güvenlik En İyi Uygulamaları (02-Security/) - Tam Modernizasyon
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Resmi spesifikasyondan açıkça belirtilmiş MUST/MUST NOT gereksinimleri içeren tam yeniden yazım
  - **12 Temel Güvenlik Uygulaması**: 15 maddelik listeden kapsamlı güvenlik alanlarına yeniden yapılandırıldı
    - Token Güvenliği ve Kimlik Doğrulama ile harici kimlik sağlayıcı entegrasyonu
    - Oturum Yönetimi ve Taşıma Güvenliği ile kriptografik gereksinimler
    - AI-Specifik Tehdit Koruması ile Microsoft Prompt Shields entegrasyonu
    - Erişim Kontrolü ve İzinler ile en az ayrıcalık ilkesi
    - İçerik Güvenliği ve İzleme ile Azure Content Safety entegrasyonu
    - Tedarik Zinciri Güvenliği ile kapsamlı bileşen doğrulama
    - OAuth Güvenliği ve Confused Deputy Önleme ile PKCE uygulaması
    - Olay Yanıtı ve Kurtarma ile otomatik yetenekler
    - Uyumluluk ve Yönetim ile düzenleyici uyum
    - Gelişmiş Güvenlik Kontrolleri ile sıfır güven mimarisi
    - Microsoft Güvenlik Ekosistemi Entegrasyonu ile kapsamlı çözümler
    - Sürekli Güvenlik Evrimi ile uyarlanabilir uygulamalar
  - **Microsoft Güvenlik Çözümleri**: Prompt Shields, Azure Content Safety, Entra ID ve GitHub Advanced Security için geliştirilmiş entegrasyon rehberi
  - **Uygulama Kaynakları**: Resmi MCP Dokümantasyonu, Microsoft Güvenlik Çözümleri, Güvenlik Standartları ve Uygulama Kılavuzları olarak kategorize edilmiş kapsamlı kaynak bağlantıları

#### Gelişmiş Güvenlik Kontrolleri (02-Security/) - Kurumsal Uygulama
- **MCP-SECURITY-CONTROLS-2025.md**: Temel kontrollerden detaylı kurumsal çerçeveye genişletilmiş tam yeniden yazım
  - **9 Kapsamlı Güvenlik Alanı**: Gelişmiş kimlik doğrulama ve yetkilendirme, oturum güvenliği, AI tehdit koruması gibi detaylı kurumsal çerçeve
  - **Uygulama Örnekleri**: Detaylı YAML yapılandırma blokları ve kod örnekleri eklendi
  - **Microsoft Çözümleri Entegrasyonu**: Azure güvenlik hizmetleri, GitHub Advanced Security ve kurumsal kimlik yönetimi kapsamlı şekilde ele alındı

#### Gelişmiş Konular Güvenlik (05-AdvancedTopics/mcp-security/) - Üretime Hazır Uygulama
- **README.md**: Kurumsal güvenlik uygulaması için tam yeniden yazım
  - **Mevcut Spesifikasyon Uyumu**: MCP Spesifikasyonu 2025-06-18'e güncellendi
  - **Gelişmiş Kimlik Doğrulama**: Microsoft Entra ID entegrasyonu ile kapsamlı .NET ve Java Spring Security örnekleri
  - **AI Güvenlik Entegrasyonu**: Microsoft Prompt Shields ve Azure Content Safety uygulaması ile detaylı Python örnekleri
  - **Gelişmiş Tehdit Azaltma**: PKCE ve kullanıcı onayı doğrulama gibi detaylı uygulama örnekleri
  - **Kurumsal Güvenlik Entegrasyonu**: Azure Application Insights izleme, tehdit algılama hatları ve tedarik zinciri güvenliği
  - **Uygulama Kontrol Listesi**: Microsoft güvenlik ekosistemi avantajları ile açıkça belirtilmiş zorunlu ve önerilen güvenlik kontrolleri

### Dokümantasyon Kalitesi ve Standart Uyumu
- **Spesifikasyon Referansları**: Tüm referanslar mevcut MCP Spesifikasyonu 2025-06-18'e güncellendi
- **Microsoft Güvenlik Ekosistemi**: Tüm güvenlik dokümantasyonu boyunca geliştirilmiş entegrasyon rehberi
- **Pratik Uygulama**: .NET, Java ve Python'da detaylı kod örnekleri ile kurumsal desenler eklendi
- **Kaynak Organizasyonu**: Resmi dokümantasyon, güvenlik standartları ve uygulama kılavuzları olarak kapsamlı kategorize edilmiş kaynak bağlantıları
- **Görsel Göstergeler**: Zorunlu gereksinimler ve önerilen uygulamalar için açık işaretleme

## 16 Temmuz 2025

### README ve Navigasyon İyileştirmeleri
- README.md'de müfredat navigasyonu tamamen yeniden tasarlandı
- `<details>` etiketleri daha erişilebilir tablo tabanlı formatla değiştirildi
- Yeni "alternative_layouts" klasöründe alternatif düzen seçenekleri oluşturuldu
- Kart tabanlı, sekmeli ve akordeon tarzı navigasyon örnekleri eklendi
- En son dosyaları içerecek şekilde depo yapısı bölümü güncellendi
- "Bu Müfredat Nasıl Kullanılır" bölümüne net öneriler eklendi
- MCP spesifikasyon bağlantıları doğru URL'lere yönlendirildi
- Müfredat yapısına Bağlam Mühendisliği bölümü (5.14) eklendi

### Çalışma Kılavuzu Güncellemeleri
- Çalışma kılavuzu, mevcut depo yapısına uyacak şekilde tamamen revize edildi
- MCP İstemcileri ve Araçları ile Popüler MCP Sunucuları için yeni bölümler eklendi
- Görsel Müfredat Haritası tüm konuları doğru şekilde yansıtacak şekilde güncellendi
- Gelişmiş Konular açıklamaları tüm özel alanları kapsayacak şekilde geliştirildi
- Gerçek örnekleri yansıtacak şekilde Vaka Çalışmaları bölümü güncellendi
- Bu kapsamlı değişiklik günlüğü eklendi

### Topluluk Katkıları (06-CommunityContributions/)
- Görüntü oluşturma için MCP sunucuları hakkında detaylı bilgiler eklendi
- VSCode'da Claude kullanımı hakkında kapsamlı bir bölüm eklendi
- Cline terminal istemcisi kurulum ve kullanım talimatları eklendi
- MCP istemci bölümü tüm popüler istemci seçeneklerini içerecek şekilde güncellendi
- Daha doğru kod örnekleriyle katkı örnekleri geliştirildi

### Gelişmiş Konular (05-AdvancedTopics/)
- Tüm özel konu klasörleri tutarlı bir adlandırma ile düzenlendi
- Bağlam mühendisliği materyalleri ve örnekleri eklendi
- Foundry ajan entegrasyonu dokümantasyonu eklendi
- Entra ID güvenlik entegrasyonu dokümantasyonu geliştirildi

## 11 Haziran 2025

### İlk Oluşturma
- Yeni Başlayanlar için MCP müfredatının ilk versiyonu yayınlandı
- Tüm 10 ana bölüm için temel yapı oluşturuldu
- Navigasyon için Görsel Müfredat Haritası uygulandı
- Birden fazla programlama dilinde örnek projeler eklendi

### Başlangıç (03-GettingStarted/)
- İlk sunucu uygulama örnekleri oluşturuldu
- İstemci geliştirme rehberi eklendi
- LLM istemci entegrasyon talimatları eklendi
- VS Code entegrasyon dokümantasyonu eklendi
- Server-Sent Events (SSE) sunucu örnekleri uygulandı

### Temel Kavramlar (01-CoreConcepts/)
- İstemci-sunucu mimarisi hakkında detaylı açıklamalar eklendi
- Anahtar protokol bileşenleri hakkında dokümantasyon oluşturuldu
- MCP'deki mesajlaşma desenleri belgelenmiştir

## 23 Mayıs 2025

### Depo Yapısı
- Temel klasör yapısı ile depo başlatıldı
- Her ana bölüm için README dosyaları oluşturuldu
- Çeviri altyapısı kuruldu
- Görsel varlıklar ve diyagramlar eklendi

### Dokümantasyon
- Müfredat genel görünümü ile ilk README.md oluşturuldu
- CODE_OF_CONDUCT.md ve SECURITY.md eklendi
- SUPPORT.md ile yardım alma rehberi oluşturuldu
- İlk çalışma kılavuzu yapısı oluşturuldu

## 15 Nisan 2025

### Planlama ve Çerçeve
- Yeni Başlayanlar için MCP müfredatı için ilk planlama yapıldı
- Öğrenme hedefleri ve hedef kitle tanımlandı
- Müfredatın 10 bölümlük yapısı tasarlandı
- Örnekler ve vaka çalışmaları için kavramsal çerçeve geliştirildi
- Anahtar kavramlar için ilk prototip örnekler oluşturuldu

---

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Belgenin orijinal dilindeki hali, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.