<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:26:20+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "tr"
}
-->
## Sistem Mimarisi

Bu proje, kullanıcı istemlerini Model Context Protocol (MCP) aracılığıyla bir hesap makinesi hizmetine iletmeden önce içerik güvenliği kontrolü yapan bir web uygulamasını gösterir.

### Nasıl Çalışır

1. **Kullanıcı Girişi**: Kullanıcı, web arayüzüne bir hesaplama istemi girer
2. **İçerik Güvenliği Taraması (Giriş)**: İstem, Azure İçerik Güvenliği API'si tarafından analiz edilir
3. **Güvenlik Kararı (Giriş)**:
   - İçerik güvenliyse (tüm kategorilerde şiddet < 2), hesap makinesine iletilir
   - İçerik potansiyel olarak zararlı olarak işaretlenirse, işlem durur ve bir uyarı döndürülür
4. **Hesap Makinesi Entegrasyonu**: Güvenli içerik, MCP hesap makinesi sunucusuyla iletişim kuran LangChain4j tarafından işlenir
5. **İçerik Güvenliği Taraması (Çıkış)**: Bot'un yanıtı Azure İçerik Güvenliği API'si tarafından analiz edilir
6. **Güvenlik Kararı (Çıkış)**:
   - Bot yanıtı güvenliyse, kullanıcıya gösterilir
   - Bot yanıtı potansiyel olarak zararlı olarak işaretlenirse, bir uyarı ile değiştirilir
7. **Yanıt**: Sonuçlar (güvenliyse) kullanıcıya her iki güvenlik analiziyle birlikte gösterilir

## Hesap Makinesi Hizmetleriyle Model Context Protocol (MCP) Kullanımı

Bu proje, LangChain4j'den hesap makinesi MCP hizmetlerini çağırmak için Model Context Protocol (MCP) kullanımını gösterir. Uygulama, hesap makinesi işlemleri sağlamak için 8080 portunda çalışan yerel bir MCP sunucusu kullanır.

### Azure İçerik Güvenliği Hizmetini Ayarlama

İçerik güvenliği özelliklerini kullanmadan önce bir Azure İçerik Güvenliği hizmet kaynağı oluşturmanız gerekir:

1. [Azure Portal](https://portal.azure.com)'a giriş yapın
2. "Kaynak oluştur" seçeneğine tıklayın ve "İçerik Güvenliği" arayın
3. "İçerik Güvenliği" seçin ve "Oluştur" butonuna tıklayın
4. Kaynağınız için benzersiz bir ad girin
5. Aboneliğinizi ve kaynak grubunuzu seçin (veya yeni bir tane oluşturun)
6. Desteklenen bir bölge seçin (detaylar için [Bölge kullanılabilirliğine](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) bakın)
7. Uygun bir fiyatlandırma katmanı seçin
8. Kaynağı dağıtmak için "Oluştur" butonuna tıklayın
9. Dağıtım tamamlandığında, "Kaynağa git" seçeneğine tıklayın
10. Sol panelde, "Kaynak Yönetimi" altında, "Anahtarlar ve Uç Nokta" seçeneğini seçin
11. Sonraki adımda kullanmak üzere anahtarlardan birini ve uç nokta URL'sini kopyalayın

### Ortam Değişkenlerini Yapılandırma

GitHub modelleri kimlik doğrulaması için `GITHUB_TOKEN` ortam değişkenini ayarlayın:
```sh
export GITHUB_TOKEN=<your_github_token>
```

İçerik güvenliği özellikleri için şunları ayarlayın:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Bu ortam değişkenleri, uygulamanın Azure İçerik Güvenliği hizmeti ile kimlik doğrulaması yapması için kullanılır. Bu değişkenler ayarlanmazsa, uygulama gösterim amacıyla yer tutucu değerler kullanır, ancak içerik güvenliği özellikleri düzgün çalışmaz.

### Hesap Makinesi MCP Sunucusunu Başlatma

İstemciyi çalıştırmadan önce, localhost:8080'de SSE modunda hesap makinesi MCP sunucusunu başlatmanız gerekir.

## Proje Tanımı

Bu proje, LangChain4j ile Model Context Protocol (MCP) entegrasyonunu ve hesap makinesi hizmetlerini çağırmayı gösterir. Ana özellikler şunlardır:

- Temel matematik işlemleri için bir hesap makinesi hizmetine MCP kullanarak bağlanma
- Hem kullanıcı istemlerinde hem de bot yanıtlarında çift katmanlı içerik güvenliği kontrolü
- LangChain4j aracılığıyla GitHub'ın gpt-4.1-nano modeli ile entegrasyon
- MCP taşımacılığı için Sunucu Tarafından Gönderilen Olaylar (SSE) kullanımı

## İçerik Güvenliği Entegrasyonu

Proje, hem kullanıcı girişlerinin hem de sistem yanıtlarının zararlı içerikten arındırılmış olmasını sağlamak için kapsamlı içerik güvenliği özellikleri içerir:

1. **Giriş Taraması**: Tüm kullanıcı istemleri, nefret söylemi, şiddet, kendine zarar verme ve cinsel içerik gibi zararlı içerik kategorileri için analiz edilir.

2. **Çıkış Taraması**: Potansiyel olarak sansürsüz modeller kullanıldığında bile, sistem tüm üretilen yanıtları kullanıcıya göstermeden önce aynı içerik güvenliği filtrelerinden geçirir.

Bu çift katmanlı yaklaşım, hangi AI modeli kullanılırsa kullanılsın sistemin güvenli kalmasını sağlar, kullanıcıları hem zararlı girdilerden hem de potansiyel olarak sorunlu AI tarafından üretilen çıktılardan korur.

## Web İstemcisi

Uygulama, kullanıcıların İçerik Güvenliği Hesaplayıcı sistemle etkileşime girmesine olanak tanıyan kullanıcı dostu bir web arayüzü içerir:

### Web Arayüzü Özellikleri

- Hesaplama istemleri girmek için basit, sezgisel form
- Çift katmanlı içerik güvenliği doğrulaması (giriş ve çıkış)
- İstem ve yanıt güvenliği hakkında gerçek zamanlı geri bildirim
- Kolay yorumlama için renk kodlu güvenlik göstergeleri
- Çeşitli cihazlarda çalışan temiz, duyarlı tasarım
- Kullanıcılara rehberlik edecek örnek güvenli istemler

### Web İstemcisini Kullanma

1. Uygulamayı başlatın:
   ```sh
   mvn spring-boot:run
   ```

2. Tarayıcınızı açın ve `http://localhost:8087` adresine gidin

3. Sağlanan metin alanına bir hesaplama istemi girin (örneğin, "24.5 ve 17.3'ün toplamını hesapla")

4. İsteğinizi işlemek için "Gönder" butonuna tıklayın

5. Sonuçları görüntüleyin, bunlar şunları içerecektir:
   - İsteminizin içerik güvenliği analizi
   - Hesaplanan sonuç (istem güvenliyse)
   - Bot'un yanıtının içerik güvenliği analizi
   - Girdi veya çıktı işaretlendiyse herhangi bir güvenlik uyarısı

Web istemcisi, içerik güvenliği doğrulama süreçlerinin her ikisini de otomatik olarak yönetir ve hangi AI modeli kullanılırsa kullanılsın tüm etkileşimlerin güvenli ve uygun olmasını sağlar.

**Feragatname**:
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çaba sarf etsek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalar konusunda sorumluluk kabul etmiyoruz.