<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:22:41+00:00",
  "source_file": "changelog.md",
  "language_code": "tr"
}
-->
# Değişiklik Günlüğü: Yeni Başlayanlar için MCP Müfredatı

Bu belge, Model Context Protocol (MCP) için Yeni Başlayanlar müfredatında yapılan tüm önemli değişikliklerin kaydını tutar. Değişiklikler, kronolojik olarak ters sırada (en yeni değişiklikler önce) belgelenmiştir.

## 26 Eylül 2025

### Vaka Çalışmaları Geliştirmesi - GitHub MCP Registry Entegrasyonu

#### Vaka Çalışmaları (09-CaseStudy/) - Ekosistem Geliştirme Odaklı
- **README.md**: GitHub MCP Registry vaka çalışması ile kapsamlı bir genişleme
  - **GitHub MCP Registry Vaka Çalışması**: GitHub'ın Eylül 2025'teki MCP Registry lansmanını inceleyen yeni kapsamlı vaka çalışması
    - **Sorun Analizi**: Parçalanmış MCP sunucu keşfi ve dağıtım zorluklarının detaylı incelemesi
    - **Çözüm Mimarisi**: GitHub'ın merkezi kayıt yaklaşımı ve tek tıkla VS Code kurulumu
    - **İş Etkisi**: Geliştirici onboarding ve üretkenlikte ölçülebilir iyileştirmeler
    - **Stratejik Değer**: Modüler ajan dağıtımı ve araçlar arası birlikte çalışabilirlik odaklı
    - **Ekosistem Geliştirme**: Ajanik entegrasyon için temel platform olarak konumlandırma
  - **Geliştirilmiş Vaka Çalışması Yapısı**: Tüm yedi vaka çalışması, tutarlı formatlama ve kapsamlı açıklamalarla güncellendi
    - Azure AI Seyahat Ajanları: Çoklu ajan orkestrasyonu vurgusu
    - Azure DevOps Entegrasyonu: İş akışı otomasyonu odaklı
    - Gerçek Zamanlı Dokümantasyon Erişimi: Python konsol istemcisi uygulaması
    - Etkileşimli Çalışma Planı Oluşturucu: Chainlit konuşma web uygulaması
    - Editör İçi Dokümantasyon: VS Code ve GitHub Copilot entegrasyonu
    - Azure API Yönetimi: Kurumsal API entegrasyon desenleri
    - GitHub MCP Registry: Ekosistem geliştirme ve topluluk platformu
  - **Kapsamlı Sonuç**: Yedi vaka çalışmasını kapsayan ve çeşitli MCP uygulama boyutlarını vurgulayan yeniden yazılmış sonuç bölümü
    - Kurumsal Entegrasyon, Çoklu Ajan Orkestrasyonu, Geliştirici Üretkenliği
    - Ekosistem Geliştirme, Eğitim Uygulamaları kategorileri
    - Mimari desenler, uygulama stratejileri ve en iyi uygulamalar hakkında geliştirilmiş içgörüler
    - MCP'nin olgun, üretime hazır bir protokol olarak vurgulanması

#### Çalışma Kılavuzu Güncellemeleri (study_guide.md)
- **Görsel Müfredat Haritası**: Vaka Çalışmaları bölümüne GitHub MCP Registry eklemek için güncellendi
- **Vaka Çalışmaları Açıklaması**: Genel açıklamalardan yedi kapsamlı vaka çalışmasının detaylı bir dökümüne geliştirildi
- **Depo Yapısı**: 10. bölüm, kapsamlı vaka çalışması kapsamını ve belirli uygulama detaylarını yansıtacak şekilde güncellendi
- **Değişiklik Günlüğü Entegrasyonu**: GitHub MCP Registry eklemesi ve vaka çalışması geliştirmelerini belgeleyen 26 Eylül 2025 girişini ekledi
- **Tarih Güncellemeleri**: Son revizyonu yansıtmak için alt bilgi zaman damgası güncellendi (26 Eylül 2025)

### Dokümantasyon Kalitesi İyileştirmeleri
- **Tutarlılık Geliştirmesi**: Tüm yedi örnek arasında vaka çalışması formatlama ve yapısı standartlaştırıldı
- **Kapsamlı Kapsama**: Vaka çalışmaları artık kurumsal, geliştirici üretkenliği ve ekosistem geliştirme senaryolarını kapsıyor
- **Stratejik Konumlandırma**: MCP'nin ajanik sistem dağıtımı için temel platform olarak geliştirilmiş odak noktası
- **Kaynak Entegrasyonu**: Ek kaynaklar GitHub MCP Registry bağlantısını içerecek şekilde güncellendi

## 15 Eylül 2025

### İleri Konular Genişletmesi - Özel Taşıma Mekanizmaları ve Bağlam Mühendisliği

#### MCP Özel Taşıma Mekanizmaları (05-AdvancedTopics/mcp-transport/) - Yeni İleri Seviye Uygulama Kılavuzu
- **README.md**: Özel MCP taşıma mekanizmaları için tam uygulama kılavuzu
  - **Azure Event Grid Taşıma Mekanizması**: Kapsamlı sunucusuz olay odaklı taşıma uygulaması
    - Azure Functions entegrasyonu ile C#, TypeScript ve Python örnekleri
    - Ölçeklenebilir MCP çözümleri için olay odaklı mimari desenler
    - Webhook alıcıları ve itme tabanlı mesaj işleme
  - **Azure Event Hubs Taşıma Mekanizması**: Yüksek verimli akış taşıma uygulaması
    - Düşük gecikmeli senaryolar için gerçek zamanlı akış yetenekleri
    - Bölümlendirme stratejileri ve kontrol noktası yönetimi
    - Mesaj gruplama ve performans optimizasyonu
  - **Kurumsal Entegrasyon Desenleri**: Üretime hazır mimari örnekler
    - Birden fazla Azure Functions arasında dağıtılmış MCP işleme
    - Birden fazla taşıma türünü birleştiren hibrit taşıma mimarileri
    - Mesaj dayanıklılığı, güvenilirlik ve hata işleme stratejileri
  - **Güvenlik ve İzleme**: Azure Key Vault entegrasyonu ve gözlemlenebilirlik desenleri
    - Yönetilen kimlik doğrulama ve en az ayrıcalık erişimi
    - Application Insights telemetri ve performans izleme
    - Devre kesiciler ve hata toleransı desenleri
  - **Test Çerçeveleri**: Özel taşıma mekanizmaları için kapsamlı test stratejileri
    - Test doubles ve mocking çerçeveleri ile birim testi
    - Azure Test Containers ile entegrasyon testi
    - Performans ve yük testi değerlendirmeleri

#### Bağlam Mühendisliği (05-AdvancedTopics/mcp-contextengineering/) - Gelişen AI Disiplini
- **README.md**: Bağlam mühendisliğini gelişen bir alan olarak kapsamlı bir şekilde keşfetme
  - **Temel İlkeler**: Tam bağlam paylaşımı, eylem karar farkındalığı ve bağlam penceresi yönetimi
  - **MCP Protokol Uyumu**: MCP tasarımının bağlam mühendisliği zorluklarını nasıl ele aldığı
    - Bağlam penceresi sınırlamaları ve aşamalı yükleme stratejileri
    - Alaka belirleme ve dinamik bağlam erişimi
    - Çok modlu bağlam işleme ve güvenlik değerlendirmeleri
  - **Uygulama Yaklaşımları**: Tek iş parçacıklı ve çoklu ajan mimarileri
    - Bağlam parçalama ve önceliklendirme teknikleri
    - Aşamalı bağlam yükleme ve sıkıştırma stratejileri
    - Katmanlı bağlam yaklaşımları ve erişim optimizasyonu
  - **Ölçüm Çerçevesi**: Bağlam etkinliğini değerlendirmek için gelişen metrikler
    - Girdi verimliliği, performans, kalite ve kullanıcı deneyimi değerlendirmeleri
    - Bağlam optimizasyonu için deneysel yaklaşımlar
    - Hata analizi ve iyileştirme metodolojileri

#### Müfredat Navigasyonu Güncellemeleri (README.md)
- **Geliştirilmiş Modül Yapısı**: Yeni ileri konuları içerecek şekilde müfredat tablosu güncellendi
  - Bağlam Mühendisliği (5.14) ve Özel Taşıma Mekanizmaları (5.15) girişleri eklendi
  - Tüm modüller arasında tutarlı formatlama ve navigasyon bağlantıları
  - Mevcut içerik kapsamını yansıtacak şekilde açıklamalar güncellendi

### Dizin Yapısı İyileştirmeleri
- **Adlandırma Standartlaştırması**: "mcp transport" dizini, diğer ileri konu klasörleriyle tutarlılık için "mcp-transport" olarak yeniden adlandırıldı
- **İçerik Organizasyonu**: Tüm 05-AdvancedTopics klasörleri artık tutarlı bir adlandırma düzenini takip ediyor (mcp-[konu])

### Dokümantasyon Kalitesi İyileştirmeleri
- **MCP Spesifikasyon Uyumu**: Tüm yeni içerik, mevcut MCP Spesifikasyonu 2025-06-18'e referans veriyor
- **Çok Dilli Örnekler**: C#, TypeScript ve Python'da kapsamlı kod örnekleri
- **Kurumsal Odak**: Üretime hazır desenler ve Azure bulut entegrasyonu
- **Görsel Dokümantasyon**: Mimari ve akış görselleştirme için Mermaid diyagramları

## 18 Ağustos 2025

### Dokümantasyon Kapsamlı Güncellemesi - MCP 2025-06-18 Standartları

#### MCP Güvenlik En İyi Uygulamaları (02-Security/) - Tam Modernizasyon
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: MCP Spesifikasyonu 2025-06-18 ile uyumlu olarak tamamen yeniden yazıldı
  - **Zorunlu Gereksinimler**: Resmi spesifikasyondan açıkça belirtilmiş MUST/MUST NOT gereksinimleri, net görsel göstergelerle eklendi
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
- **MCP-SECURITY-CONTROLS-2025.md**: Kurumsal düzeyde güvenlik çerçevesi ile tamamen yeniden düzenlendi
  - **9 Kapsamlı Güvenlik Alanı**: Temel kontrollerden detaylı kurumsal çerçeveye genişletildi
    - Gelişmiş Kimlik Doğrulama ve Yetkilendirme ile Microsoft Entra ID entegrasyonu
    - Token Güvenliği ve Anti-Passthrough Kontrolleri ile kapsamlı doğrulama
    - Oturum Güvenliği Kontrolleri ile ele geçirme önleme
    - AI-Specifik Güvenlik Kontrolleri ile prompt enjeksiyonu ve araç zehirlenmesi önleme
    - Confused Deputy Saldırı Önleme ile OAuth proxy güvenliği
    - Araç Çalıştırma Güvenliği ile sandboxing ve izolasyon
    - Tedarik Zinciri Güvenlik Kontrolleri ile bağımlılık doğrulama
    - İzleme ve Algılama Kontrolleri ile SIEM entegrasyonu
    - Olay Yanıtı ve Kurtarma ile otomatik yetenekler
  - **Uygulama Örnekleri**: Detaylı YAML yapılandırma blokları ve kod örnekleri eklendi
  - **Microsoft Çözümleri Entegrasyonu**: Azure güvenlik hizmetleri, GitHub Advanced Security ve kurumsal kimlik yönetimi kapsamlı bir şekilde ele alındı

#### İleri Konular Güvenlik (05-AdvancedTopics/mcp-security/) - Üretime Hazır Uygulama
- **README.md**: Kurumsal güvenlik uygulaması için tamamen yeniden yazıldı
  - **Mevcut Spesifikasyon Uyumu**: MCP Spesifikasyonu 2025-06-18'e güncellendi ve zorunlu güvenlik gereksinimleri eklendi
  - **Gelişmiş Kimlik Doğrulama**: Microsoft Entra ID entegrasyonu ile kapsamlı .NET ve Java Spring Security örnekleri
  - **AI Güvenlik Entegrasyonu**: Microsoft Prompt Shields ve Azure Content Safety uygulaması ile detaylı Python örnekleri
  - **Gelişmiş Tehdit Azaltma**: Kapsamlı uygulama örnekleri
    - Confused Deputy Saldırı Önleme ile PKCE ve kullanıcı onayı doğrulama
    - Token Passthrough Önleme ile hedef doğrulama ve güvenli token yönetimi
    - Oturum Ele Geçirme Önleme ile kriptografik bağlama ve davranış analizi
  - **Kurumsal Güvenlik Entegrasyonu**: Azure Application Insights izleme, tehdit algılama boru hatları ve tedarik zinciri güvenliği
  - **Uygulama Kontrol Listesi**: Microsoft güvenlik ekosistemi avantajları ile açık zorunlu ve önerilen güvenlik kontrolleri

### Dokümantasyon Kalitesi ve Standart Uyumu
- **Spesifikasyon Referansları**: Tüm referanslar mevcut MCP Spesifikasyonu 2025-06-18'e güncellendi
- **Microsoft Güvenlik Ekosistemi**: Tüm güvenlik dokümantasyonu boyunca geliştirilmiş entegrasyon rehberi
- **Pratik Uygulama**: .NET, Java ve Python'da detaylı kod örnekleri ile kurumsal desenler eklendi
- **Kaynak Organizasyonu**: Resmi dokümantasyon, güvenlik standartları ve uygulama kılavuzlarının kapsamlı kategorizasyonu
- **Görsel Göstergeler**: Zorunlu gereksinimler ve önerilen uygulamalar için net işaretleme

#### Temel Kavramlar (01-CoreConcepts/) - Tam Modernizasyon
- **Protokol Versiyon Güncellemesi**: Mevcut MCP Spesifikasyonu 2025-06-18'e referans verildi ve tarih tabanlı versiyonlama (YYYY-MM-DD formatı) eklendi
- **Mimari İyileştirme**: Mevcut MCP mimari desenlerini yansıtacak şekilde Hostlar, İstemciler ve Sunucular açıklamaları geliştirildi
  - Hostlar artık birden fazla MCP istemci bağlantısını koordine eden AI uygulamaları olarak açıkça tanımlandı
  - İstemciler, bir sunucu ile bire bir ilişkiyi sürdüren protokol bağlayıcıları olarak tanımlandı
  - Sunucular, yerel ve uzak dağıtım senaryoları ile geliştirildi
- **İlkel Yeniden Yapılandırma**: Sunucu ve istemci ilkel öğelerinin tamamen yeniden düzenlenmesi
  - Sunucu İlkel Öğeleri: Kaynaklar (veri kaynakları), Prompts (şablonlar), Araçlar (çalıştırılabilir işlevler) ile detaylı açıklamalar ve örnekler
  - İstemci İlkel Öğeleri: Sampling (LLM tamamlama), Elicitation (kullanıcı girişi), Logging (hata ayıklama/izleme)
  - Mevcut keşif (`*/list`), erişim (`*/get`) ve yürütme (`*/call`) yöntem desenleri ile güncellendi
- **Protokol Mimarisi**: İki katmanlı mimari modeli tanıtıldı
  - Veri Katmanı: JSON-RPC 2.0 temeli ile yaşam döngüsü yönetimi ve ilkel öğeler
  - Taşıma Katmanı: STDIO (yerel) ve Streamable HTTP ile SSE (uzak) taşıma mekanizmaları
- **Güvenlik Çerçevesi**: Açık kullanıcı onayı, veri gizliliği koruması, araç çalıştırma güvenliği ve taşıma katmanı güvenliği dahil kapsamlı güvenlik ilkeleri
- **İletişim Desenleri**: Başlatma, keşif, yürütme ve bildirim akışlarını gösteren protokol mesajları güncellendi
- **Kod Örnekleri**: Mevcut MCP SDK desenlerini yansıtacak şekilde çok dilli örnekler (.NET, Java, Python, JavaScript) yenilendi

#### Güvenlik (02-Security/) - Kapsamlı Güvenlik Yeniden Düzenlemesi  
- **Standart Uyumu**: MCP Spesifikasyonu 2025-06-18 güvenlik gereksinimleri ile tam uyum
- **Kimlik Doğrulama Evrimi**: Özel OAuth sunucularından harici kimlik sağlayıcı
- `<details>` etiketlerini daha erişilebilir bir tablo tabanlı formatla değiştirdim
- Yeni "alternative_layouts" klasöründe alternatif düzen seçenekleri oluşturdum
- Kart tabanlı, sekmeli ve akordeon tarzı gezinme örnekleri ekledim
- Depo yapısı bölümünü en son dosyaları içerecek şekilde güncelledim
- "Bu Müfredat Nasıl Kullanılır" bölümünü net önerilerle geliştirdim
- MCP spesifikasyon bağlantılarını doğru URL'lere yönlendirdim
- Müfredat yapısına "Bağlam Mühendisliği" bölümü (5.14) ekledim

### Çalışma Kılavuzu Güncellemeleri
- Çalışma kılavuzunu mevcut depo yapısına uygun şekilde tamamen revize ettim
- MCP İstemcileri ve Araçları ile Popüler MCP Sunucuları için yeni bölümler ekledim
- Görsel Müfredat Haritasını tüm konuları doğru şekilde yansıtacak şekilde güncelledim
- İleri Düzey Konuların açıklamalarını tüm özel alanları kapsayacak şekilde geliştirdim
- Vaka Çalışmaları bölümünü gerçek örneklerle güncelledim
- Bu kapsamlı değişiklik günlüğünü ekledim

### Topluluk Katkıları (06-CommunityContributions/)
- Görüntü oluşturma için MCP sunucuları hakkında ayrıntılı bilgiler ekledim
- VSCode'da Claude kullanımı hakkında kapsamlı bir bölüm ekledim
- Cline terminal istemcisi kurulum ve kullanım talimatlarını ekledim
- MCP istemci bölümünü tüm popüler istemci seçeneklerini içerecek şekilde güncelledim
- Katkı örneklerini daha doğru kod örnekleriyle geliştirdim

### İleri Düzey Konular (05-AdvancedTopics/)
- Tüm özel konu klasörlerini tutarlı bir adlandırma ile düzenledim
- Bağlam mühendisliği materyalleri ve örnekleri ekledim
- Foundry ajan entegrasyonu dokümantasyonu ekledim
- Entra ID güvenlik entegrasyonu dokümantasyonunu geliştirdim

## 11 Haziran 2025

### İlk Oluşturma
- MCP for Beginners müfredatının ilk versiyonunu yayınladım
- Tüm 10 ana bölüm için temel yapıyı oluşturdum
- Gezinme için Görsel Müfredat Haritasını uyguladım
- Birden fazla programlama dilinde başlangıç projeleri ekledim

### Başlarken (03-GettingStarted/)
- İlk sunucu uygulama örneklerini oluşturdum
- İstemci geliştirme rehberi ekledim
- LLM istemci entegrasyonu talimatlarını dahil ettim
- VS Code entegrasyonu dokümantasyonu ekledim
- Server-Sent Events (SSE) sunucu örneklerini uyguladım

### Temel Kavramlar (01-CoreConcepts/)
- İstemci-sunucu mimarisi hakkında ayrıntılı açıklamalar ekledim
- Ana protokol bileşenleri hakkında dokümantasyon oluşturdum
- MCP'deki mesajlaşma desenlerini belgeledim

## 23 Mayıs 2025

### Depo Yapısı
- Temel klasör yapısıyla depoyu başlattım
- Her ana bölüm için README dosyaları oluşturdum
- Çeviri altyapısını kurdum
- Görsel varlıklar ve diyagramlar ekledim

### Dokümantasyon
- Müfredat genel görünümü ile ilk README.md dosyasını oluşturdum
- CODE_OF_CONDUCT.md ve SECURITY.md dosyalarını ekledim
- Yardım alma rehberi ile SUPPORT.md dosyasını kurdum
- Ön çalışma kılavuzu yapısını oluşturdum

## 15 Nisan 2025

### Planlama ve Çerçeve
- MCP for Beginners müfredatı için ilk planlama
- Öğrenme hedeflerini ve hedef kitleyi tanımladım
- Müfredatın 10 bölümlük yapısını tasarladım
- Örnekler ve vaka çalışmaları için kavramsal çerçeve geliştirdim
- Anahtar kavramlar için ilk prototip örnekleri oluşturdum

---

