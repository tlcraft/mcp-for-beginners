<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T17:41:51+00:00",
  "source_file": "changelog.md",
  "language_code": "tr"
}
-->
# Değişiklik Günlüğü: Yeni Başlayanlar için MCP Müfredatı

Bu belge, Model Context Protocol (MCP) için Yeni Başlayanlar müfredatında yapılan tüm önemli değişikliklerin kaydını tutar. Değişiklikler, kronolojik olarak ters sırada (en yeni değişiklikler önce) belgelenmiştir.

## 18 Ağustos 2025

### Belgelerin Kapsamlı Güncellemesi - MCP 2025-06-18 Standartları

#### MCP Güvenlik En İyi Uygulamaları (02-Security/) - Tam Modernizasyon
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: MCP Spesifikasyonu 2025-06-18 ile uyumlu olarak tamamen yeniden yazıldı
  - **Zorunlu Gereksinimler**: Resmi spesifikasyondan açıkça belirtilmiş MUST/MUST NOT gereksinimleri, net görsel göstergelerle eklendi
  - **12 Temel Güvenlik Uygulaması**: 15 maddelik listeden kapsamlı güvenlik alanlarına yeniden yapılandırıldı
    - Harici kimlik sağlayıcı entegrasyonu ile Token Güvenliği ve Kimlik Doğrulama
    - Kriptografik gereksinimlerle Oturum Yönetimi ve Taşıma Güvenliği
    - Microsoft Prompt Shields entegrasyonu ile AI-Specifik Tehdit Koruması
    - En az ayrıcalık ilkesiyle Erişim Kontrolü ve İzinler
    - Azure Content Safety entegrasyonu ile İçerik Güvenliği ve İzleme
    - Kapsamlı bileşen doğrulama ile Tedarik Zinciri Güvenliği
    - PKCE uygulaması ile OAuth Güvenliği ve Karışık Vekil Önleme
    - Otomatik yeteneklerle Olay Müdahalesi ve Kurtarma
    - Düzenleyici uyum ile Uyumluluk ve Yönetim
    - Sıfır güven mimarisi ile Gelişmiş Güvenlik Kontrolleri
    - Kapsamlı çözümlerle Microsoft Güvenlik Ekosistemi Entegrasyonu
    - Uyarlanabilir uygulamalarla Sürekli Güvenlik Gelişimi
  - **Microsoft Güvenlik Çözümleri**: Prompt Shields, Azure Content Safety, Entra ID ve GitHub Advanced Security için geliştirilmiş entegrasyon rehberliği
  - **Uygulama Kaynakları**: Resmi MCP Belgeleri, Microsoft Güvenlik Çözümleri, Güvenlik Standartları ve Uygulama Kılavuzları olarak kategorize edilmiş kapsamlı kaynak bağlantıları

#### Gelişmiş Güvenlik Kontrolleri (02-Security/) - Kurumsal Uygulama
- **MCP-SECURITY-CONTROLS-2025.md**: Kurumsal düzeyde güvenlik çerçevesi ile tamamen yeniden düzenlendi
  - **9 Kapsamlı Güvenlik Alanı**: Temel kontrollerden ayrıntılı kurumsal çerçeveye genişletildi
    - Microsoft Entra ID entegrasyonu ile Gelişmiş Kimlik Doğrulama ve Yetkilendirme
    - Kapsamlı doğrulama ile Token Güvenliği ve Passthrough Önleme Kontrolleri
    - Oturum Güvenliği Kontrolleri ile ele geçirme önleme
    - Prompt enjeksiyonu ve araç zehirlenmesi önleme ile AI-Specifik Güvenlik Kontrolleri
    - OAuth proxy güvenliği ile Karışık Vekil Saldırısı Önleme
    - Sandboxing ve izolasyon ile Araç Çalıştırma Güvenliği
    - Bağımlılık doğrulama ile Tedarik Zinciri Güvenlik Kontrolleri
    - SIEM entegrasyonu ile İzleme ve Tespit Kontrolleri
    - Otomatik yeteneklerle Olay Müdahalesi ve Kurtarma
  - **Uygulama Örnekleri**: Ayrıntılı YAML yapılandırma blokları ve kod örnekleri eklendi
  - **Microsoft Çözümleri Entegrasyonu**: Azure güvenlik hizmetleri, GitHub Advanced Security ve kurumsal kimlik yönetimi kapsamlı şekilde ele alındı

#### Gelişmiş Konular Güvenliği (05-AdvancedTopics/mcp-security/) - Üretime Hazır Uygulama
- **README.md**: Kurumsal güvenlik uygulaması için tamamen yeniden yazıldı
  - **Mevcut Spesifikasyon Uyumu**: MCP Spesifikasyonu 2025-06-18 ile güncellendi ve zorunlu güvenlik gereksinimleri eklendi
  - **Gelişmiş Kimlik Doğrulama**: Microsoft Entra ID entegrasyonu ile kapsamlı .NET ve Java Spring Security örnekleri
  - **AI Güvenlik Entegrasyonu**: Microsoft Prompt Shields ve Azure Content Safety uygulaması ile ayrıntılı Python örnekleri
  - **Gelişmiş Tehdit Azaltma**: Kapsamlı uygulama örnekleri
    - PKCE ve kullanıcı onayı doğrulaması ile Karışık Vekil Saldırısı Önleme
    - Hedef doğrulama ve güvenli token yönetimi ile Token Passthrough Önleme
    - Kriptografik bağlama ve davranış analizi ile Oturum Ele Geçirme Önleme
  - **Kurumsal Güvenlik Entegrasyonu**: Azure Application Insights izleme, tehdit algılama hatları ve tedarik zinciri güvenliği
  - **Uygulama Kontrol Listesi**: Microsoft güvenlik ekosistemi avantajları ile net zorunlu ve önerilen güvenlik kontrolleri

### Belge Kalitesi ve Standartlara Uyum
- **Spesifikasyon Referansları**: Tüm referanslar MCP Spesifikasyonu 2025-06-18 ile güncellendi
- **Microsoft Güvenlik Ekosistemi**: Tüm güvenlik belgelerinde geliştirilmiş entegrasyon rehberliği
- **Pratik Uygulama**: .NET, Java ve Python'da ayrıntılı kod örnekleri ile kurumsal desenler eklendi
- **Kaynak Organizasyonu**: Resmi belgeler, güvenlik standartları ve uygulama kılavuzları kapsamlı şekilde kategorize edildi
- **Görsel Göstergeler**: Zorunlu gereksinimler ve önerilen uygulamalar net şekilde işaretlendi

#### Temel Kavramlar (01-CoreConcepts/) - Tam Modernizasyon
- **Protokol Versiyon Güncellemesi**: Mevcut MCP Spesifikasyonu 2025-06-18'e referans verildi ve tarih bazlı versiyonlama (YYYY-MM-DD formatı) eklendi
- **Mimari İyileştirme**: Mevcut MCP mimari desenlerini yansıtacak şekilde Hostlar, İstemciler ve Sunucuların tanımları geliştirildi
  - Hostlar artık birden fazla MCP istemci bağlantısını koordine eden AI uygulamaları olarak açıkça tanımlandı
  - İstemciler, bir sunucu ile birebir ilişkiyi sürdüren protokol bağlayıcıları olarak tanımlandı
  - Sunucular, yerel ve uzak dağıtım senaryoları ile geliştirildi
- **İlkel Yapılandırma**: Sunucu ve istemci ilkel öğeleri tamamen yeniden düzenlendi
  - Sunucu İlkel Öğeleri: Kaynaklar (veri kaynakları), Prompts (şablonlar), Araçlar (çalıştırılabilir işlevler) ile ayrıntılı açıklamalar ve örnekler
  - İstemci İlkel Öğeleri: Örnekleme (LLM tamamlama), Elicitation (kullanıcı girdisi), Logging (hata ayıklama/izleme)
  - Mevcut keşif (`*/list`), alma (`*/get`) ve çalıştırma (`*/call`) yöntem desenleri ile güncellendi
- **Protokol Mimarisi**: İki katmanlı mimari modeli tanıtıldı
  - Veri Katmanı: JSON-RPC 2.0 temeli ile yaşam döngüsü yönetimi ve ilkel öğeler
  - Taşıma Katmanı: STDIO (yerel) ve Streamable HTTP ile SSE (uzak) taşıma mekanizmaları
- **Güvenlik Çerçevesi**: Açık kullanıcı onayı, veri gizliliği koruması, araç çalıştırma güvenliği ve taşıma katmanı güvenliği dahil kapsamlı güvenlik ilkeleri
- **İletişim Desenleri**: Başlatma, keşif, çalıştırma ve bildirim akışlarını gösteren protokol mesajları güncellendi
- **Kod Örnekleri**: Mevcut MCP SDK desenlerini yansıtacak şekilde çoklu dil örnekleri (.NET, Java, Python, JavaScript) yenilendi

#### Güvenlik (02-Security/) - Kapsamlı Güvenlik Yeniden Düzenlemesi  
- **Standartlara Uyum**: MCP Spesifikasyonu 2025-06-18 güvenlik gereksinimleri ile tam uyum
- **Kimlik Doğrulama Gelişimi**: Özel OAuth sunucularından harici kimlik sağlayıcı delegasyonuna (Microsoft Entra ID) geçiş belgelenmiştir
- **AI-Specifik Tehdit Analizi**: Modern AI saldırı vektörlerinin kapsamlı analizi
  - Gerçek dünya örnekleriyle ayrıntılı prompt enjeksiyonu saldırı senaryoları
  - Araç zehirlenmesi mekanizmaları ve "rug pull" saldırı desenleri
  - Bağlam penceresi zehirlenmesi ve model karışıklığı saldırıları
- **Microsoft AI Güvenlik Çözümleri**: Microsoft güvenlik ekosisteminin kapsamlı ele alınması
  - Gelişmiş tespit, vurgulama ve ayırıcı tekniklerle AI Prompt Shields
  - Azure Content Safety entegrasyon desenleri
  - Tedarik zinciri koruması için GitHub Advanced Security
- **Gelişmiş Tehdit Azaltma**: Ayrıntılı güvenlik kontrolleri
  - MCP'ye özgü saldırı senaryoları ve kriptografik oturum kimliği gereksinimleri ile oturum ele geçirme
  - MCP proxy senaryolarında açık onay gereksinimleri ile karışık vekil sorunları
  - Zorunlu doğrulama kontrolleri ile token passthrough açıkları
- **Tedarik Zinciri Güvenliği**: Temel modeller, gömme hizmetleri, bağlam sağlayıcılar ve üçüncü taraf API'ler dahil genişletilmiş AI tedarik zinciri kapsamı
- **Temel Güvenlik**: Sıfır güven mimarisi ve Microsoft güvenlik ekosistemi dahil kurumsal güvenlik desenleri ile geliştirilmiş entegrasyon
- **Kaynak Organizasyonu**: Resmi Belgeler, Standartlar, Araştırma, Microsoft Çözümleri ve Uygulama Kılavuzları olarak kategorize edilmiş kapsamlı kaynak bağlantıları

### Belge Kalitesi İyileştirmeleri
- **Yapılandırılmış Öğrenme Hedefleri**: Belirli, uygulanabilir sonuçlarla geliştirilmiş öğrenme hedefleri
- **Çapraz Referanslar**: İlgili güvenlik ve temel kavram konuları arasında bağlantılar eklendi
- **Güncel Bilgiler**: Tüm tarih referansları ve spesifikasyon bağlantıları güncel standartlara göre güncellendi
- **Uygulama Rehberliği**: Her iki bölümde de belirli, uygulanabilir uygulama yönergeleri eklendi

## 16 Temmuz 2025

### README ve Navigasyon İyileştirmeleri
- README.md'de müfredat navigasyonu tamamen yeniden tasarlandı
- `<details>` etiketleri daha erişilebilir tablo tabanlı formatla değiştirildi
- Yeni "alternative_layouts" klasöründe alternatif düzen seçenekleri oluşturuldu
- Kart tabanlı, sekmeli ve akordeon tarzı navigasyon örnekleri eklendi
- En son dosyaları içerecek şekilde depo yapısı bölümü güncellendi
- "Bu Müfredat Nasıl Kullanılır" bölümüne net öneriler eklendi
- MCP spesifikasyon bağlantıları doğru URL'lere yönlendirildi
- Müfredat yapısına Context Engineering bölümü (5.14) eklendi

### Çalışma Kılavuzu Güncellemeleri
- Çalışma kılavuzu, mevcut depo yapısına uyacak şekilde tamamen revize edildi
- MCP İstemcileri ve Araçları ile Popüler MCP Sunucuları için yeni bölümler eklendi
- Görsel Müfredat Haritası tüm konuları doğru şekilde yansıtacak şekilde güncellendi
- Gelişmiş Konular açıklamaları tüm özel alanları kapsayacak şekilde geliştirildi
- Gerçek örnekleri yansıtacak şekilde Vaka Çalışmaları bölümü güncellendi
- Bu kapsamlı değişiklik günlüğü eklendi

### Topluluk Katkıları (06-CommunityContributions/)
- Görüntü oluşturma için MCP sunucuları hakkında ayrıntılı bilgiler eklendi
- VSCode'da Claude kullanımı için kapsamlı bir bölüm eklendi
- Cline terminal istemcisi kurulum ve kullanım talimatları eklendi
- MCP istemci bölümü tüm popüler istemci seçeneklerini içerecek şekilde güncellendi
- Daha doğru kod örnekleriyle katkı örnekleri geliştirildi

### Gelişmiş Konular (05-AdvancedTopics/)
- Tüm özel konu klasörleri tutarlı adlandırma ile düzenlendi
- Context engineering materyalleri ve örnekleri eklendi
- Foundry ajan entegrasyonu belgeleri eklendi
- Entra ID güvenlik entegrasyonu belgeleri geliştirildi

## 11 Haziran 2025

### İlk Oluşturma
- Yeni Başlayanlar için MCP müfredatının ilk sürümü yayınlandı
- Tüm 10 ana bölüm için temel yapı oluşturuldu
- Navigasyon için Görsel Müfredat Haritası uygulandı
- Birden fazla programlama dilinde ilk örnek projeler eklendi

### Başlarken (03-GettingStarted/)
- İlk sunucu uygulama örnekleri oluşturuldu
- İstemci geliştirme rehberliği eklendi
- LLM istemci entegrasyon talimatları eklendi
- VS Code entegrasyon belgeleri eklendi
- Server-Sent Events (SSE) sunucu örnekleri uygulandı

### Temel Kavramlar (01-CoreConcepts/)
- İstemci-sunucu mimarisi hakkında ayrıntılı açıklamalar eklendi
- Anahtar protokol bileşenleri hakkında belgeler oluşturuldu
- MCP'deki mesajlaşma desenleri belgelenmiştir

## 23 Mayıs 2025

### Depo Yapısı
- Temel klasör yapısı ile depo başlatıldı
- Her ana bölüm için README dosyaları oluşturuldu
- Çeviri altyapısı kuruldu
- Görsel varlıklar ve diyagramlar eklendi

### Belgeler
- Müfredat genel görünümü ile ilk README.md oluşturuldu
- CODE_OF_CONDUCT.md ve SECURITY.md eklendi
- Yardım alma rehberliği ile SUPPORT.md kuruldu
- İlk çalışma kılavuzu yapısı oluşturuldu

## 15 Nisan 2025

### Planlama ve Çerçeve
- Yeni Başlayanlar için MCP müfredatı için ilk planlama yapıldı
- Öğrenme hedefleri ve hedef kitle tanımlandı
- Müfredatın 10 bölümlük yapısı tasarlandı
- Örnekler ve vaka çalışmaları için kavramsal çerçeve geliştirildi
- Anahtar kavramlar için ilk prototip örnekler oluşturuldu

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalar için sorumluluk kabul etmiyoruz.