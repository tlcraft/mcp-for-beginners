<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T16:21:19+00:00",
  "source_file": "changelog.md",
  "language_code": "tr"
}
-->
# Değişiklik Günlüğü: Yeni Başlayanlar için MCP Müfredatı

Bu belge, Yeni Başlayanlar için Model Context Protocol (MCP) müfredatında yapılan tüm önemli değişikliklerin kaydını tutar. Değişiklikler ters kronolojik sırayla (en yeni değişiklikler önce) belgelenmiştir.

## 29 Eylül 2025

### MCP Sunucu Veritabanı Entegrasyonu Laboratuvarları - Kapsamlı Uygulamalı Öğrenme Yolu

#### 11-MCPServerHandsOnLabs - Yeni Tam Veritabanı Entegrasyonu Müfredatı
- **Tam 13-Laboratuvar Öğrenme Yolu**: PostgreSQL veritabanı entegrasyonu ile üretime hazır MCP sunucuları oluşturmak için kapsamlı uygulamalı müfredat eklendi
  - **Gerçek Dünya Uygulaması**: Kurumsal düzeyde desenleri gösteren Zava Retail analitik kullanım senaryosu
  - **Yapılandırılmış Öğrenme İlerlemesi**:
    - **Laboratuvarlar 00-03: Temeller** - Giriş, Çekirdek Mimari, Güvenlik ve Çoklu Kiracılık, Ortam Kurulumu
    - **Laboratuvarlar 04-06: MCP Sunucusunu Oluşturma** - Veritabanı Tasarımı ve Şeması, MCP Sunucu Uygulaması, Araç Geliştirme  
    - **Laboratuvarlar 07-09: Gelişmiş Özellikler** - Semantik Arama Entegrasyonu, Test ve Hata Ayıklama, VS Code Entegrasyonu
    - **Laboratuvarlar 10-12: Üretim ve En İyi Uygulamalar** - Dağıtım Stratejileri, İzleme ve Görünürlük, En İyi Uygulamalar ve Optimizasyon
  - **Kurumsal Teknolojiler**: FastMCP çerçevesi, pgvector ile PostgreSQL, Azure OpenAI gömüleri, Azure Container Apps, Application Insights
  - **Gelişmiş Özellikler**: Satır Düzeyi Güvenlik (RLS), semantik arama, çoklu kiracı veri erişimi, vektör gömüleri, gerçek zamanlı izleme

#### Terminoloji Standartlaştırma - Modülden Laboratuvara Dönüşüm
- **Kapsamlı Dokümantasyon Güncellemesi**: 11-MCPServerHandsOnLabs içindeki tüm README dosyaları sistematik olarak "Modül" terminolojisinden "Laboratuvar" terminolojisine güncellendi
  - **Bölüm Başlıkları**: Tüm 13 laboratuvarda "Bu Modül Ne İçeriyor" başlıkları "Bu Laboratuvar Ne İçeriyor" olarak güncellendi
  - **İçerik Açıklaması**: "Bu modül şunları sağlar..." ifadeleri "Bu laboratuvar şunları sağlar..." olarak değiştirildi
  - **Öğrenme Hedefleri**: "Bu modülün sonunda..." ifadeleri "Bu laboratuvarın sonunda..." olarak güncellendi
  - **Navigasyon Bağlantıları**: Tüm "Modül XX:" referansları "Laboratuvar XX:" olarak çapraz referanslarda ve navigasyonda dönüştürüldü
  - **Tamamlama Takibi**: "Bu modülü tamamladıktan sonra..." ifadeleri "Bu laboratuvarı tamamladıktan sonra..." olarak güncellendi
  - **Teknik Referanslar Korundu**: Yapılandırma dosyalarındaki Python modül referansları korundu (ör. `"module": "mcp_server.main"`)

#### Çalışma Kılavuzu Geliştirmesi (study_guide.md)
- **Görsel Müfredat Haritası**: "11. Veritabanı Entegrasyonu Laboratuvarları" bölümünü içeren yeni kapsamlı laboratuvar yapısı görselleştirmesi eklendi
- **Depo Yapısı**: On ana bölümden on bir ana bölüme güncellendi ve 11-MCPServerHandsOnLabs detaylı açıklaması eklendi
- **Öğrenme Yolu Rehberliği**: 00-11 bölümlerini kapsayan navigasyon talimatları geliştirildi
- **Teknoloji Kapsamı**: FastMCP, PostgreSQL, Azure hizmetleri entegrasyonu detayları eklendi
- **Öğrenme Çıktıları**: Üretime hazır sunucu geliştirme, veritabanı entegrasyonu desenleri ve kurumsal güvenlik vurgulandı

#### Ana README Yapı Geliştirmesi
- **Laboratuvar Tabanlı Terminoloji**: 11-MCPServerHandsOnLabs içindeki ana README.md dosyası "Laboratuvar" yapısını tutarlı bir şekilde kullanacak şekilde güncellendi
- **Öğrenme Yolu Organizasyonu**: Temel kavramlardan gelişmiş uygulamaya ve üretim dağıtımına kadar net ilerleme
- **Gerçek Dünya Odaklı**: Uygulamalı, pratik öğrenme ile kurumsal düzeyde desenler ve teknolojiler vurgulandı

### Dokümantasyon Kalitesi ve Tutarlılık İyileştirmeleri
- **Uygulamalı Öğrenme Vurgusu**: Dokümantasyon boyunca pratik, laboratuvar tabanlı yaklaşım güçlendirildi
- **Kurumsal Desenler Odaklı**: Üretime hazır uygulamalar ve kurumsal güvenlik hususları vurgulandı
- **Teknoloji Entegrasyonu**: Modern Azure hizmetleri ve yapay zeka entegrasyon desenlerinin kapsamlı kapsanması
- **Öğrenme İlerlemesi**: Temel kavramlardan üretim dağıtımına kadar net, yapılandırılmış yol

## 26 Eylül 2025

### Vaka Çalışmaları Geliştirmesi - GitHub MCP Registry Entegrasyonu

#### Vaka Çalışmaları (09-CaseStudy/) - Ekosistem Geliştirme Odaklı
- **README.md**: GitHub MCP Registry vaka çalışması ile kapsamlı genişleme
  - **GitHub MCP Registry Vaka Çalışması**: GitHub'ın MCP Registry lansmanını inceleyen yeni kapsamlı vaka çalışması
    - **Sorun Analizi**: Parçalanmış MCP sunucu keşfi ve dağıtım zorluklarının detaylı incelemesi
    - **Çözüm Mimarisi**: Tek tıklamayla VS Code kurulumu ile GitHub'ın merkezi kayıt yaklaşımı
    - **İş Etkisi**: Geliştirici onboarding ve üretkenlikte ölçülebilir iyileştirmeler
    - **Stratejik Değer**: Modüler ajan dağıtımı ve çapraz araç uyumluluğu odaklı
    - **Ekosistem Geliştirme**: Ajanik entegrasyon için temel platform olarak konumlandırma
  - **Geliştirilmiş Vaka Çalışması Yapısı**: Tüm yedi vaka çalışması tutarlı formatlama ve kapsamlı açıklamalarla güncellendi
    - Azure AI Seyahat Ajanları: Çoklu ajan orkestrasyonu vurgusu
    - Azure DevOps Entegrasyonu: İş akışı otomasyonu odaklı
    - Gerçek Zamanlı Dokümantasyon Alma: Python konsol istemcisi uygulaması
    - Etkileşimli Çalışma Planı Oluşturucu: Chainlit konuşma web uygulaması
    - Editör İçi Dokümantasyon: VS Code ve GitHub Copilot entegrasyonu
    - Azure API Yönetimi: Kurumsal API entegrasyon desenleri
    - GitHub MCP Registry: Ekosistem geliştirme ve topluluk platformu
  - **Kapsamlı Sonuç**: Yedi vaka çalışmasını kapsayan çoklu MCP uygulama boyutlarını vurgulayan sonuç bölümü yeniden yazıldı
    - Kurumsal Entegrasyon, Çoklu Ajan Orkestrasyonu, Geliştirici Üretkenliği
    - Ekosistem Geliştirme, Eğitim Uygulamaları kategorizasyonu
    - Mimari desenler, uygulama stratejileri ve en iyi uygulamalar hakkında geliştirilmiş içgörüler
    - MCP'nin olgun, üretime hazır bir protokol olarak vurgulanması

#### Çalışma Kılavuzu Güncellemeleri (study_guide.md)
- **Görsel Müfredat Haritası**: Vaka Çalışmaları bölümüne GitHub MCP Registry eklemek için mindmap güncellendi
- **Vaka Çalışmaları Açıklaması**: Genel açıklamalardan yedi kapsamlı vaka çalışmasının detaylı dökümüne geliştirildi
- **Depo Yapısı**: Onuncu bölüm, spesifik uygulama detaylarıyla kapsamlı vaka çalışması kapsamını yansıtacak şekilde güncellendi
- **Değişiklik Günlüğü Entegrasyonu**: GitHub MCP Registry eklemesi ve vaka çalışması geliştirmelerini belgeleyen 26 Eylül 2025 girişini ekledi
- **Tarih Güncellemeleri**: En son revizyonu yansıtmak için alt bilgi zaman damgası güncellendi (26 Eylül 2025)

### Dokümantasyon Kalitesi İyileştirmeleri
- **Tutarlılık Geliştirmesi**: Tüm yedi örnek arasında vaka çalışması formatlama ve yapı standartlaştırıldı
- **Kapsamlı Kapsama**: Vaka çalışmaları artık kurumsal, geliştirici üretkenliği ve ekosistem geliştirme senaryolarını kapsıyor
- **Stratejik Konumlandırma**: MCP'nin ajanik sistem dağıtımı için temel platform olarak geliştirilmiş odak
- **Kaynak Entegrasyonu**: GitHub MCP Registry bağlantısını içerecek şekilde ek kaynaklar güncellendi

## 15 Eylül 2025

### Gelişmiş Konular Genişletmesi - Özel Taşıma Mekanizmaları ve Bağlam Mühendisliği

#### MCP Özel Taşıma Mekanizmaları (05-AdvancedTopics/mcp-transport/) - Yeni Gelişmiş Uygulama Rehberi
- **README.md**: Özel MCP taşıma mekanizmaları için tam uygulama rehberi
  - **Azure Event Grid Taşıma Mekanizması**: Kapsamlı sunucusuz olay odaklı taşıma uygulaması
    - Azure Functions entegrasyonu ile C#, TypeScript ve Python örnekleri
    - Ölçeklenebilir MCP çözümleri için olay odaklı mimari desenler
    - Webhook alıcıları ve push tabanlı mesaj işleme
  - **Azure Event Hubs Taşıma Mekanizması**: Yüksek verimli akış taşıma uygulaması
    - Düşük gecikmeli senaryolar için gerçek zamanlı akış yetenekleri
    - Bölümleme stratejileri ve kontrol noktası yönetimi
    - Mesaj gruplama ve performans optimizasyonu
  - **Kurumsal Entegrasyon Desenleri**: Üretime hazır mimari örnekler
    - Birden fazla Azure Functions arasında dağıtılmış MCP işleme
    - Birden fazla taşıma türünü birleştiren hibrit taşıma mimarileri
    - Mesaj dayanıklılığı, güvenilirlik ve hata işleme stratejileri
  - **Güvenlik ve İzleme**: Azure Key Vault entegrasyonu ve görünürlük desenleri
    - Yönetilen kimlik doğrulama ve en az ayrıcalık erişimi
    - Application Insights telemetri ve performans izleme
    - Devre kesiciler ve hata toleransı desenleri
  - **Test Çerçeveleri**: Özel taşıma mekanizmaları için kapsamlı test stratejileri
    - Test doubles ve mocking çerçeveleri ile birim testi
    - Azure Test Containers ile entegrasyon testi
    - Performans ve yük testi hususları

#### Bağlam Mühendisliği (05-AdvancedTopics/mcp-contextengineering/) - Gelişen Yapay Zeka Disiplini
- **README.md**: Bağlam mühendisliği alanının kapsamlı keşfi
  - **Temel İlkeler**: Tam bağlam paylaşımı, eylem karar farkındalığı ve bağlam penceresi yönetimi
  - **MCP Protokol Uyumu**: MCP tasarımının bağlam mühendisliği zorluklarını nasıl ele aldığı
    - Bağlam penceresi sınırlamaları ve aşamalı yükleme stratejileri
    - Alaka belirleme ve dinamik bağlam alma
    - Çok modlu bağlam işleme ve güvenlik hususları
  - **Uygulama Yaklaşımları**: Tek iş parçacıklı ve çoklu ajan mimarileri
    - Bağlam parçalama ve önceliklendirme teknikleri
    - Aşamalı bağlam yükleme ve sıkıştırma stratejileri
    - Katmanlı bağlam yaklaşımları ve alma optimizasyonu
  - **Ölçüm Çerçevesi**: Bağlam etkinliğini değerlendirmek için gelişen metrikler
    - Girdi verimliliği, performans, kalite ve kullanıcı deneyimi hususları
    - Bağlam optimizasyonu için deneysel yaklaşımlar
    - Hata analizi ve iyileştirme metodolojileri

#### Müfredat Navigasyon Güncellemeleri (README.md)
- **Geliştirilmiş Modül Yapısı**: Yeni gelişmiş konuları içerecek şekilde müfredat tablosu güncellendi
  - Bağlam Mühendisliği (5.14) ve Özel Taşıma Mekanizmaları (5.15) girişleri eklendi
  - Tüm modüller arasında tutarlı formatlama ve navigasyon bağlantıları
  - Mevcut içerik kapsamını yansıtacak şekilde açıklamalar güncellendi

### Dizin Yapısı İyileştirmeleri
- **Adlandırma Standartlaştırması**: "mcp transport" "mcp-transport" olarak yeniden adlandırıldı, diğer gelişmiş konu klasörleriyle tutarlılık sağlandı
- **İçerik Organizasyonu**: Tüm 05-AdvancedTopics klasörleri artık tutarlı adlandırma desenini takip ediyor (mcp-[konu])

### Dokümantasyon Kalitesi Geliştirmeleri
- **MCP Spesifikasyonu Uyumu**: Tüm yeni içerik mevcut MCP Spesifikasyonu 2025-06-18 referanslarını içeriyor
- **Çok Dilli Örnekler**: C#, TypeScript ve Python'da kapsamlı kod örnekleri
- **Kurumsal Odak**: Üretime hazır desenler ve Azure bulut entegrasyonu boyunca
- **Görsel Dokümantasyon**: Mimari ve akış görselleştirmesi için Mermaid diyagramları

## 18 Ağustos 2025

### Dokümantasyon Kapsamlı Güncellemesi - MCP 2025-06-18 Standartları

#### MCP Güvenlik En İyi Uygulamaları (02-Security/) - Tam Modernizasyon
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: MCP Spesifikasyonu 2025-06-18 ile uyumlu olarak tamamen yeniden yazıldı
  - **Zorunlu Gereksinimler**: Resmi spesifikasyondan açıkça belirtilmiş MUST/MUST NOT gereksinimleri, net görsel göstergelerle eklendi
  - **12 Temel Güvenlik Uygulaması**: 15 maddelik listeden kapsamlı güvenlik alanlarına yeniden yapılandırıldı
    - Harici kimlik sağlayıcı entegrasyonu ile Token Güvenliği ve Kimlik Doğrulama
    - Kriptografik gereksinimlerle Oturum Yönetimi ve Taşıma Güvenliği
    - Microsoft Prompt Shields entegrasyonu ile Yapay Zeka Özel Tehdit Koruması
    - En az ayrıcalık ilkesiyle Erişim Kontrolü ve İzinler
    - Azure Content Safety entegrasyonu ile İçerik Güvenliği ve İzleme
    - Kapsamlı bileşen doğrulaması ile Tedarik Zinciri Güvenliği
    - PKCE uygulaması ile OAuth Güvenliği ve Karışık Vekil Önleme
    - Otomatik yeteneklerle Olay Yanıtı ve Kurtarma
    - Düzenleyici uyum ile Uyumluluk ve Yönetim
    - Sıfır güven mimarisi ile Gelişmiş Güvenlik Kontrolleri
    - Kapsamlı çözümlerle Microsoft Güvenlik Ekosistemi Entegrasyonu
    - Uyarlanabilir uygulamalarla Sürekli Güvenlik Evrimi
  - **Microsoft Güvenlik Çözümleri**: Prompt Shields, Azure Content Safety, Entra ID ve GitHub Advanced Security için geliştirilmiş entegrasyon rehberi
  - **Uygulama Kaynakları**: Resmi MCP Dokümantasyonu, Microsoft Güvenlik Çözümleri, Güvenlik Standartları ve Uygulama Rehberleri olarak kategorize edilmiş kapsamlı kaynak bağlantıları

#### Gelişmiş Güvenlik Kontrolleri (02-Security/) - Kurumsal Uygulama
- **MCP-SECURITY-CONTROLS-2025.md**: Kurumsal düzeyde güvenlik çerçevesiyle tamamen yeniden düzenlendi
  - **9 Kapsamlı Güvenlik Alanı**: Temel kontrollerden detaylı kurumsal çerçeveye genişletildi
    - Microsoft Entra ID entegrasyonu ile Gelişmiş Kimlik Doğrulama ve Yetkilendirme
    - Kapsamlı doğrulama ile Token Güvenliği ve Passthrough Önleme Kontrolleri
    - Oturum Güvenliği Kontrolleri ile ele geçirme önleme
    - Prompt enjeksiyonu ve araç zehirlenmesi önleme ile Yapay Zeka Özel Güvenlik Kontrolleri
    - OAuth proxy güvenliği ile Karışık Vekil Saldırısı Önleme
    - Araç Çalıştırma Güvenliği ile sandboxing ve izolasyon
    - Bağımlılık doğrulaması ile Tedarik Zinciri Güvenlik Kontrolleri

- **Görsel Göstergeler**: Zorunlu gereksinimler ile önerilen uygulamaların net bir şekilde işaretlenmesi

#### Temel Kavramlar (01-CoreConcepts/) - Tam Modernizasyon
- **Protokol Sürüm Güncellemesi**: Mevcut MCP Spesifikasyonu 2025-06-18'e referans olacak şekilde tarih tabanlı sürümleme (YYYY-MM-DD formatında) güncellendi
- **Mimari İyileştirme**: MCP mimari desenlerini yansıtacak şekilde Hostlar, İstemciler ve Sunucuların açıklamaları geliştirildi
  - Hostlar artık birden fazla MCP istemci bağlantısını koordine eden yapay zeka uygulamaları olarak tanımlandı
  - İstemciler, bir sunucu ile birebir ilişkiyi sürdüren protokol bağlayıcıları olarak tanımlandı
  - Sunucular, yerel ve uzak dağıtım senaryolarıyla geliştirildi
- **İlkel Yapılandırma**: Sunucu ve istemci ilkel yapılarında tamamen yeniden düzenleme yapıldı
  - Sunucu İlkel Yapıları: Kaynaklar (veri kaynakları), İstekler (şablonlar), Araçlar (çalıştırılabilir fonksiyonlar) detaylı açıklamalar ve örneklerle birlikte
  - İstemci İlkel Yapıları: Örnekleme (LLM tamamlama), Bilgi Toplama (kullanıcı girdisi), Günlükleme (hata ayıklama/izleme)
  - Mevcut keşif (`*/list`), alma (`*/get`) ve çalıştırma (`*/call`) yöntem desenleriyle güncellendi
- **Protokol Mimarisi**: İki katmanlı mimari modeli tanıtıldı
  - Veri Katmanı: JSON-RPC 2.0 temeli ile yaşam döngüsü yönetimi ve ilkel yapılar
  - Taşıma Katmanı: STDIO (yerel) ve Streamable HTTP ile SSE (uzaktan) taşıma mekanizmaları
- **Güvenlik Çerçevesi**: Kullanıcı onayı, veri gizliliği koruması, araç çalıştırma güvenliği ve taşıma katmanı güvenliği gibi kapsamlı güvenlik ilkeleri
- **İletişim Desenleri**: Başlatma, keşif, çalıştırma ve bildirim akışlarını gösteren protokol mesajları güncellendi
- **Kod Örnekleri**: Mevcut MCP SDK desenlerini yansıtacak şekilde çok dilli örnekler (.NET, Java, Python, JavaScript) yenilendi

#### Güvenlik (02-Security/) - Kapsamlı Güvenlik Yenilemesi  
- **Standartlara Uyum**: MCP Spesifikasyonu 2025-06-18 güvenlik gereksinimleriyle tam uyum sağlandı
- **Kimlik Doğrulama Evrimi**: Özel OAuth sunucularından Microsoft Entra ID gibi harici kimlik sağlayıcılarına delege edilen kimlik doğrulama evrimi belgelenmiştir
- **Yapay Zeka Özel Tehdit Analizi**: Modern yapay zeka saldırı vektörlerini kapsayan geliştirilmiş içerik
  - Gerçek dünya örnekleriyle detaylı istek enjeksiyonu saldırı senaryoları
  - Araç zehirleme mekanizmaları ve "halı çekme" saldırı desenleri
  - Bağlam penceresi zehirleme ve model karışıklığı saldırıları
- **Microsoft Yapay Zeka Güvenlik Çözümleri**: Microsoft güvenlik ekosisteminin kapsamlı bir şekilde ele alınması
  - Gelişmiş algılama, vurgulama ve ayırıcı tekniklerle AI İstek Kalkanları
  - Azure İçerik Güvenliği entegrasyon desenleri
  - Tedarik zinciri koruması için GitHub Gelişmiş Güvenlik
- **Gelişmiş Tehdit Azaltma**: Detaylı güvenlik kontrolleri
  - MCP'ye özgü saldırı senaryoları ve kriptografik oturum kimliği gereksinimleriyle oturum ele geçirme
  - MCP proxy senaryolarında açık onay gereksinimleriyle karışık vekil sorunları
  - Zorunlu doğrulama kontrolleriyle token geçişi açıkları
- **Tedarik Zinciri Güvenliği**: Temel modeller, gömme hizmetleri, bağlam sağlayıcılar ve üçüncü taraf API'leri dahil olmak üzere genişletilmiş yapay zeka tedarik zinciri kapsamı
- **Temel Güvenlik**: Sıfır güven mimarisi ve Microsoft güvenlik ekosistemi dahil olmak üzere kurumsal güvenlik desenleriyle geliştirilmiş entegrasyon
- **Kaynak Organizasyonu**: Türüne göre kategorize edilmiş kapsamlı kaynak bağlantıları (Resmi Belgeler, Standartlar, Araştırma, Microsoft Çözümleri, Uygulama Kılavuzları)

### Dokümantasyon Kalitesi İyileştirmeleri
- **Yapılandırılmış Öğrenme Hedefleri**: Belirli, uygulanabilir sonuçlarla geliştirilmiş öğrenme hedefleri
- **Çapraz Referanslar**: İlgili güvenlik ve temel kavram konuları arasında bağlantılar eklendi
- **Güncel Bilgiler**: Tüm tarih referansları ve spesifikasyon bağlantıları güncel standartlara göre güncellendi
- **Uygulama Rehberliği**: Her iki bölümde de belirli, uygulanabilir uygulama yönergeleri eklendi

## 16 Temmuz 2025

### README ve Navigasyon İyileştirmeleri
- README.md dosyasındaki müfredat navigasyonu tamamen yeniden tasarlandı
- `<details>` etiketleri daha erişilebilir tablo tabanlı formatla değiştirildi
- Yeni "alternative_layouts" klasöründe alternatif düzen seçenekleri oluşturuldu
- Kart tabanlı, sekmeli ve akordeon tarzı navigasyon örnekleri eklendi
- Depo yapısı bölümü en son dosyaları içerecek şekilde güncellendi
- "Bu Müfredat Nasıl Kullanılır" bölümüne net önerilerle geliştirmeler yapıldı
- MCP spesifikasyon bağlantıları doğru URL'lere yönlendirecek şekilde güncellendi
- Müfredat yapısına Bağlam Mühendisliği bölümü (5.14) eklendi

### Çalışma Kılavuzu Güncellemeleri
- Çalışma kılavuzu mevcut depo yapısına uygun şekilde tamamen revize edildi
- MCP İstemcileri ve Araçları ile Popüler MCP Sunucuları için yeni bölümler eklendi
- Görsel Müfredat Haritası tüm konuları doğru bir şekilde yansıtacak şekilde güncellendi
- İleri Düzey Konuların açıklamaları tüm özel alanları kapsayacak şekilde geliştirildi
- Vaka Çalışmaları bölümü gerçek örnekleri yansıtacak şekilde güncellendi
- Bu kapsamlı değişiklik günlüğü eklendi

### Topluluk Katkıları (06-CommunityContributions/)
- Görüntü oluşturma için MCP sunucuları hakkında detaylı bilgiler eklendi
- VSCode'da Claude kullanımı hakkında kapsamlı bir bölüm eklendi
- Cline terminal istemcisi kurulum ve kullanım talimatları eklendi
- MCP istemci bölümü tüm popüler istemci seçeneklerini içerecek şekilde güncellendi
- Daha doğru kod örnekleriyle katkı örnekleri geliştirildi

### İleri Düzey Konular (05-AdvancedTopics/)
- Tüm özel konu klasörleri tutarlı adlandırma ile düzenlendi
- Bağlam mühendisliği materyalleri ve örnekleri eklendi
- Foundry ajan entegrasyonu dokümantasyonu eklendi
- Entra ID güvenlik entegrasyonu dokümantasyonu geliştirildi

## 11 Haziran 2025

### İlk Oluşturma
- MCP için Başlangıç Müfredatı'nın ilk versiyonu yayınlandı
- Tüm 10 ana bölüm için temel yapı oluşturuldu
- Navigasyon için Görsel Müfredat Haritası uygulandı
- Birden fazla programlama dilinde ilk örnek projeler eklendi

### Başlangıç (03-GettingStarted/)
- İlk sunucu uygulama örnekleri oluşturuldu
- İstemci geliştirme rehberliği eklendi
- LLM istemci entegrasyonu talimatları dahil edildi
- VS Code entegrasyonu dokümantasyonu eklendi
- Sunucu Gönderilen Olaylar (SSE) sunucu örnekleri uygulandı

### Temel Kavramlar (01-CoreConcepts/)
- İstemci-sunucu mimarisi hakkında detaylı açıklamalar eklendi
- Ana protokol bileşenleri hakkında dokümantasyon oluşturuldu
- MCP'deki mesajlaşma desenleri belgelenmiştir

## 23 Mayıs 2025

### Depo Yapısı
- Temel klasör yapısıyla depo başlatıldı
- Her ana bölüm için README dosyaları oluşturuldu
- Çeviri altyapısı kuruldu
- Görsel varlıklar ve diyagramlar eklendi

### Dokümantasyon
- Müfredat genel görünümü ile ilk README.md oluşturuldu
- CODE_OF_CONDUCT.md ve SECURITY.md eklendi
- Yardım alma rehberliği ile SUPPORT.md kuruldu
- İlk çalışma kılavuzu yapısı oluşturuldu

## 15 Nisan 2025

### Planlama ve Çerçeve
- MCP için Başlangıç Müfredatı için ilk planlama yapıldı
- Öğrenme hedefleri ve hedef kitle tanımlandı
- Müfredatın 10 bölümlük yapısı tasarlandı
- Örnekler ve vaka çalışmaları için kavramsal çerçeve geliştirildi
- Anahtar kavramlar için ilk prototip örnekler oluşturuldu

---

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalar için sorumluluk kabul edilmez.