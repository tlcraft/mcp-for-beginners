<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T01:50:48+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "tr"
}
-->
# En Son MCP Güvenlik Kontrolleri - Temmuz 2025 Güncellemesi

Model Context Protocol (MCP) gelişmeye devam ederken, güvenlik kritik bir öncelik olmaya devam ediyor. Bu belge, Temmuz 2025 itibarıyla MCP'nin güvenli bir şekilde uygulanması için en son güvenlik kontrolleri ve en iyi uygulamaları özetlemektedir.

## Kimlik Doğrulama ve Yetkilendirme

### OAuth 2.0 Delegasyon Desteği

MCP spesifikasyonundaki son güncellemeler, MCP sunucularının kullanıcı kimlik doğrulamasını Microsoft Entra ID gibi harici hizmetlere devretmesine olanak tanıyor. Bu, güvenlik duruşunu önemli ölçüde iyileştirir:

1. **Özel Kimlik Doğrulama Uygulamasını Ortadan Kaldırma**: Özel kimlik doğrulama kodundaki güvenlik açıkları riskini azaltır  
2. **Köklü Kimlik Sağlayıcılarından Yararlanma**: Kurumsal düzeyde güvenlik özelliklerinden faydalanır  
3. **Kimlik Yönetimini Merkezileştirme**: Kullanıcı yaşam döngüsü yönetimini ve erişim kontrolünü basitleştirir  

## Token Geçişinin Önlenmesi

MCP Yetkilendirme Spesifikasyonu, güvenlik kontrollerinin atlatılmasını ve hesap verebilirlik sorunlarını önlemek için token geçişine kesinlikle izin vermez.

### Temel Gereksinimler

1. **MCP sunucuları kendileri için verilmemiş tokenları KABUL ETMEMELİDİR**: Tüm tokenların doğru audience (hedef kitle) iddiasına sahip olduğunu doğrulayın  
2. **Doğru token doğrulaması uygulayın**: Issuer (verici), audience (hedef kitle), expiration (son kullanma) ve signature (imza) kontrollerini yapın  
3. **Ayrı token verme kullanın**: Mevcut tokenları geçiş yapmak yerine, alt hizmetler için yeni tokenlar verin  

## Güvenli Oturum Yönetimi

Oturum kaçırma ve sabitleme saldırılarını önlemek için aşağıdaki kontrolleri uygulayın:

1. **Güvenli, deterministik olmayan oturum kimlikleri kullanın**: Kriptografik olarak güvenli rastgele sayı üreteçleri ile oluşturulmalı  
2. **Oturumları kullanıcı kimliği ile bağlayın**: Oturum kimliklerini kullanıcıya özgü bilgilerle birleştirin  
3. **Doğru oturum rotasyonu uygulayın**: Kimlik doğrulama değişiklikleri veya ayrıcalık yükseltmeleri sonrası  
4. **Uygun oturum zaman aşımı ayarları yapın**: Güvenlik ile kullanıcı deneyimi arasında denge kurun  

## Araç Çalıştırma Sandboxing’i

Yanal hareketi önlemek ve olası ihlalleri sınırlamak için:

1. **Araç çalıştırma ortamlarını izole edin**: Konteynerler veya ayrı süreçler kullanın  
2. **Kaynak sınırları uygulayın**: Kaynak tükenmesi saldırılarını engelleyin  
3. **En az ayrıcalık erişimi uygulayın**: Sadece gerekli izinleri verin  
4. **Çalıştırma kalıplarını izleyin**: Anormal davranışları tespit edin  

## Araç Tanımı Koruması

Araç zehirlenmesini önlemek için:

1. **Araç tanımlarını kullanmadan önce doğrulayın**: Kötü niyetli talimatlar veya uygunsuz kalıplar için kontrol edin  
2. **Bütünlük doğrulaması kullanın**: Yetkisiz değişiklikleri tespit etmek için araç tanımlarını hashleyin veya imzalayın  
3. **Değişiklik izleme uygulayın**: Araç meta verilerindeki beklenmedik değişikliklerde uyarı verin  
4. **Araç tanımlarını sürüm kontrolü altında tutun**: Değişiklikleri takip edin ve gerekirse geri almayı sağlayın  

Bu kontroller, MCP uygulamaları için sağlam bir güvenlik duruşu oluşturmak üzere birlikte çalışır; yapay zeka destekli sistemlerin benzersiz zorluklarını ele alırken güçlü geleneksel güvenlik uygulamalarını da korur.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.