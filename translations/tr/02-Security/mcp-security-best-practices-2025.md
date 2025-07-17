<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T01:58:10+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "tr"
}
-->
# MCP Güvenlik En İyi Uygulamaları - Temmuz 2025 Güncellemesi

## MCP Uygulamaları için Kapsamlı Güvenlik En İyi Uygulamaları

MCP sunucularıyla çalışırken, verilerinizi, altyapınızı ve kullanıcılarınızı korumak için aşağıdaki güvenlik en iyi uygulamalarını takip edin:

1. **Girdi Doğrulama**: Enjeksiyon saldırılarını ve karışıklık sorunlarını önlemek için girdileri her zaman doğrulayın ve temizleyin.
   - Tüm araç parametreleri için sıkı doğrulama uygulayın
   - İsteklerin beklenen formatlara uygunluğunu sağlamak için şema doğrulaması kullanın
   - İşleme almadan önce potansiyel zararlı içerikleri filtreleyin

2. **Erişim Kontrolü**: MCP sunucunuz için ince ayarlı izinlerle uygun kimlik doğrulama ve yetkilendirme uygulayın.
   - Microsoft Entra ID gibi tanınmış kimlik sağlayıcılarla OAuth 2.0 kullanın
   - MCP araçları için rol tabanlı erişim kontrolü (RBAC) uygulayın
   - Mevcut çözümler varken özel kimlik doğrulama uygulamayın

3. **Güvenli İletişim**: MCP sunucunuzla tüm iletişimlerde HTTPS/TLS kullanın ve hassas veriler için ek şifreleme eklemeyi düşünün.
   - Mümkünse TLS 1.3 yapılandırın
   - Kritik bağlantılar için sertifika pinleme uygulayın
   - Sertifikaları düzenli olarak değiştirin ve geçerliliklerini doğrulayın

4. **Oran Sınırlaması**: Kötüye kullanımı, DoS saldırılarını önlemek ve kaynak tüketimini yönetmek için oran sınırlaması uygulayın.
   - Beklenen kullanım desenlerine göre uygun istek sınırları belirleyin
   - Aşırı isteklerde kademeli yanıtlar uygulayın
   - Kimlik doğrulama durumuna göre kullanıcı bazlı oran sınırlamaları düşünün

5. **Kayıt ve İzleme**: MCP sunucunuzu şüpheli faaliyetlere karşı izleyin ve kapsamlı denetim kayıtları oluşturun.
   - Tüm kimlik doğrulama denemelerini ve araç çağrılarını kaydedin
   - Şüpheli desenler için gerçek zamanlı uyarı sistemi kurun
   - Kayıtların güvenli şekilde saklandığından ve değiştirilemediğinden emin olun

6. **Güvenli Depolama**: Hassas verileri ve kimlik bilgilerini uygun şifreleme ile koruyun.
   - Tüm gizli bilgiler için anahtar kasaları veya güvenli kimlik bilgisi depoları kullanın
   - Hassas veriler için alan düzeyinde şifreleme uygulayın
   - Şifreleme anahtarlarını ve kimlik bilgilerini düzenli olarak değiştirin

7. **Token Yönetimi**: Tüm model girdileri ve çıktılarında token geçişi açıklarını önlemek için doğrulama ve temizleme yapın.
   - Audience claim’lerine dayalı token doğrulaması uygulayın
   - MCP sunucunuz için açıkça verilmemiş tokenları asla kabul etmeyin
   - Token ömrü yönetimi ve rotasyonunu doğru şekilde uygulayın

8. **Oturum Yönetimi**: Oturum kaçırma ve sabitleme saldırılarını önlemek için güvenli oturum yönetimi uygulayın.
   - Güvenli, tahmin edilemez oturum kimlikleri kullanın
   - Oturumları kullanıcıya özgü bilgilerle bağlayın
   - Oturum süresi dolumu ve rotasyonunu doğru şekilde yönetin

9. **Araç Çalıştırma Sandboxing’i**: Araç çalıştırmalarını izole ortamlarda yaparak ele geçirilme durumunda yan hareketleri engelleyin.
   - Araç çalıştırma için konteyner izolasyonu uygulayın
   - Kaynak tükenme saldırılarını önlemek için kaynak sınırları koyun
   - Farklı güvenlik alanları için ayrı çalışma bağlamları kullanın

10. **Düzenli Güvenlik Denetimleri**: MCP uygulamalarınız ve bağımlılıklarınız için periyodik güvenlik incelemeleri yapın.
    - Düzenli penetrasyon testleri planlayın
    - Güvenlik açıklarını tespit etmek için otomatik tarama araçları kullanın
    - Bilinen güvenlik sorunlarını gidermek için bağımlılıkları güncel tutun

11. **İçerik Güvenliği Filtreleme**: Hem girdiler hem de çıktılar için içerik güvenliği filtreleri uygulayın.
    - Zararlı içeriği tespit etmek için Azure Content Safety veya benzeri servisler kullanın
    - Prompt enjeksiyonunu önlemek için prompt shield teknikleri uygulayın
    - Oluşturulan içeriği potansiyel hassas veri sızıntısı açısından tarayın

12. **Tedarik Zinciri Güvenliği**: AI tedarik zincirinizdeki tüm bileşenlerin bütünlüğünü ve doğruluğunu doğrulayın.
    - İmzalı paketler kullanın ve imzaları doğrulayın
    - Yazılım malzeme listesi (SBOM) analizini uygulayın
    - Bağımlılıklardaki kötü amaçlı güncellemeleri izleyin

13. **Araç Tanımı Koruması**: Araç tanımları ve meta verilerini güvence altına alarak araç zehirlenmesini önleyin.
    - Araç tanımlarını kullanmadan önce doğrulayın
    - Araç meta verilerindeki beklenmedik değişiklikleri izleyin
    - Araç tanımları için bütünlük kontrolleri uygulayın

14. **Dinamik Çalışma Zamanı İzleme**: MCP sunucularının ve araçların çalışma zamanı davranışlarını izleyin.
    - Anormallikleri tespit etmek için davranış analizi uygulayın
    - Beklenmeyen çalışma desenleri için uyarı sistemi kurun
    - Çalışma zamanı uygulama kendini koruma (RASP) teknikleri kullanın

15. **En Az Ayrıcalık İlkesi**: MCP sunucularının ve araçların sadece gerekli minimum izinlerle çalışmasını sağlayın.
    - Her işlem için sadece gerekli izinleri verin
    - İzin kullanımını düzenli olarak gözden geçirin ve denetleyin
    - Yönetim fonksiyonları için zamanında erişim (just-in-time) uygulayın

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.