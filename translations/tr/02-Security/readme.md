<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:28:31+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "tr"
}
-->
# Güvenlik En İyi Uygulamaları

Model Context Protocol (MCP) benimsenmesi, AI destekli uygulamalara güçlü yeni yetenekler kazandırırken, aynı zamanda geleneksel yazılım risklerinin ötesine geçen benzersiz güvenlik zorlukları da getirir. Güvenli kodlama, en az ayrıcalık ve tedarik zinciri güvenliği gibi yerleşik endişelere ek olarak, MCP ve AI iş yükleri, prompt enjeksiyonu, araç zehirlenmesi ve dinamik araç değişikliği gibi yeni tehditlerle karşı karşıya kalır. Bu riskler, uygun şekilde yönetilmezse veri sızdırılması, gizlilik ihlalleri ve istenmeyen sistem davranışlarına yol açabilir.

Bu ders, MCP ile ilişkili en önemli güvenlik risklerini—kimlik doğrulama, yetkilendirme, aşırı izinler, dolaylı prompt enjeksiyonu ve tedarik zinciri açıkları dahil—araştırır ve bunları azaltmak için uygulanabilir kontroller ve en iyi uygulamalar sunar. Ayrıca, MCP uygulamanızı güçlendirmek için Prompt Shields, Azure İçerik Güvenliği ve GitHub Gelişmiş Güvenlik gibi Microsoft çözümlerinden nasıl yararlanacağınızı öğreneceksiniz. Bu kontrolleri anlayarak ve uygulayarak, güvenlik ihlali olasılığını önemli ölçüde azaltabilir ve AI sistemlerinizin sağlam ve güvenilir kalmasını sağlayabilirsiniz.

# Öğrenme Hedefleri

Bu dersin sonunda:

- Model Context Protocol (MCP) tarafından tanıtılan benzersiz güvenlik risklerini, prompt enjeksiyonu, araç zehirlenmesi, aşırı izinler ve tedarik zinciri açıkları dahil olmak üzere tanımlayabilir ve açıklayabilirsiniz.
- MCP güvenlik riskleri için güçlü kimlik doğrulama, en az ayrıcalık, güvenli belirteç yönetimi ve tedarik zinciri doğrulaması gibi etkili azaltma kontrollerini tanımlayabilir ve uygulayabilirsiniz.
- MCP ve AI iş yüklerini korumak için Prompt Shields, Azure İçerik Güvenliği ve GitHub Gelişmiş Güvenlik gibi Microsoft çözümlerinden nasıl yararlanacağınızı anlayabilirsiniz.
- Araç meta verilerini doğrulamanın, dinamik değişiklikleri izlemenin ve dolaylı prompt enjeksiyonu saldırılarına karşı savunmanın önemini tanıyabilirsiniz.
- Güvenli kodlama, sunucu sertleştirme ve sıfır güven mimarisi gibi yerleşik güvenlik en iyi uygulamalarını MCP uygulamanıza entegre ederek güvenlik ihlallerinin olasılığını ve etkisini azaltabilirsiniz.

# MCP güvenlik kontrolleri

Önemli kaynaklara erişimi olan herhangi bir sistem, ima edilen güvenlik zorluklarına sahiptir. Güvenlik zorlukları genellikle temel güvenlik kontrollerinin ve kavramlarının doğru uygulanmasıyla ele alınabilir. MCP henüz yeni tanımlandığından, spesifikasyon çok hızlı bir şekilde değişiyor ve protokol geliştikçe değişiyor. Sonunda içindeki güvenlik kontrolleri olgunlaşacak, kurumsal ve yerleşik güvenlik mimarileri ve en iyi uygulamalarla daha iyi bir entegrasyona olanak tanıyacaktır.

[Microsoft Dijital Savunma Raporu](https://aka.ms/mddr)'nda yayınlanan araştırma, bildirilen ihlallerin %98'inin sağlam güvenlik hijyeni ile önlenebileceğini ve herhangi bir türdeki ihlale karşı en iyi korumanın, temel güvenlik hijyeninizi, güvenli kodlama en iyi uygulamalarınızı ve tedarik zinciri güvenliğinizi doğru bir şekilde elde etmek olduğunu belirtmektedir—zaten bildiğimiz ve denediğimiz uygulamalar hala güvenlik riskini azaltmada en büyük etkiyi yaratmaktadır.

MCP'yi benimserken güvenlik risklerini ele almaya başlamanın bazı yollarına bakalım.

# MCP sunucu kimlik doğrulaması (MCP uygulamanız 26 Nisan 2025'ten önceyse)

> **Not:** Aşağıdaki bilgiler 26 Nisan 2025 itibarıyla doğrudur. MCP protokolü sürekli olarak gelişiyor ve gelecekteki uygulamalar yeni kimlik doğrulama modelleri ve kontrolleri tanıtabilir. En son güncellemeler ve rehberlik için her zaman [MCP Spesifikasyonu](https://spec.modelcontextprotocol.io/) ve resmi [MCP GitHub deposuna](https://github.com/modelcontextprotocol) başvurun.

### Sorun ifadesi
Orijinal MCP spesifikasyonu, geliştiricilerin kendi kimlik doğrulama sunucularını yazacağını varsaydı. Bu, OAuth ve ilgili güvenlik kısıtlamaları hakkında bilgi gerektiriyordu. MCP sunucuları, OAuth 2.0 Yetkilendirme Sunucuları olarak hareket ederek, gerekli kullanıcı kimlik doğrulamasını doğrudan yönetiyordu, bu işlemi Microsoft Entra ID gibi harici bir hizmete devretmek yerine. 26 Nisan 2025 itibarıyla, MCP spesifikasyonuna yapılan bir güncelleme, MCP sunucularının kullanıcı kimlik doğrulamasını harici bir hizmete devretmesine izin veriyor.

### Riskler
- MCP sunucusundaki yanlış yapılandırılmış yetkilendirme mantığı, hassas veri ifşasına ve yanlış uygulanan erişim kontrollerine yol açabilir.
- Yerel MCP sunucusundaki OAuth belirteci hırsızlığı. Eğer çalınırsa, belirteç, MCP sunucusunu taklit etmek ve OAuth belirtecinin ait olduğu hizmetten kaynaklara ve verilere erişmek için kullanılabilir.

### Azaltıcı kontroller
- **Yetkilendirme Mantığını İnceleyin ve Güçlendirin:** MCP sunucunuzun yetkilendirme uygulamasını dikkatlice denetleyin, yalnızca amaçlanan kullanıcıların ve istemcilerin hassas kaynaklara erişebilmesini sağlayın. Pratik rehberlik için [Azure API Yönetimi MCP Sunucuları için Kimlik Doğrulama Geçidi | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ve [Microsoft Entra ID ile MCP Sunucuları ile Oturum Açma - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/) bakınız.
- **Güvenli Belirteç Uygulamalarını Uygulayın:** Erişim belirteçlerinin kötüye kullanımını önlemek ve belirteç tekrarı veya hırsızlığı riskini azaltmak için [Microsoft'un belirteç doğrulama ve ömrü için en iyi uygulamalarını](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) takip edin.
- **Belirteç Depolamasını Koruyun:** Belirteçleri her zaman güvenli bir şekilde saklayın ve bunları dinlenme ve aktarım sırasında korumak için şifreleme kullanın. Uygulama ipuçları için [Güvenli belirteç depolama ve belirteçleri şifreleme kullanın](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) bakınız.

# MCP sunucuları için aşırı izinler

### Sorun ifadesi
MCP sunucularına, eriştikleri hizmet/kaynağa aşırı izinler verilmiş olabilir. Örneğin, bir kurumsal veri deposuna bağlanan bir AI satış uygulamasının parçası olan bir MCP sunucusu, satış verilerine erişim iznine sahip olmalı ve depodaki tüm dosyalara erişim izni verilmemelidir. En eski güvenlik ilkelerinden biri olan en az ayrıcalık ilkesine geri dönerek, hiçbir kaynağın, amaçlandığı görevleri yerine getirmesi için gereken izinlerden fazlasına sahip olmaması gerekir. AI, bu alanda artan bir zorluk sunar çünkü esnek olmasını sağlamak için, gereken izinleri tam olarak tanımlamak zor olabilir.

### Riskler
- Aşırı izinler verilmesi, MCP sunucusunun erişmesi amaçlanmayan verilerin sızdırılmasına veya değiştirilmesine olanak tanıyabilir. Bu, verilerin kişisel tanımlanabilir bilgi (PII) olması durumunda bir gizlilik sorunu da olabilir.

### Azaltıcı kontroller
- **En Az Ayrıcalık İlkesini Uygulayın:** MCP sunucusuna yalnızca gerekli görevleri yerine getirmesi için gereken minimum izinleri verin. Bu izinleri düzenli olarak gözden geçirin ve güncelleyin, gerektiğinden fazla olmadıklarından emin olun. Ayrıntılı rehberlik için [Güvenli en az ayrıcalıklı erişim](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) bakınız.
- **Rol Tabanlı Erişim Kontrolü (RBAC) Kullanın:** MCP sunucusuna belirli kaynaklar ve eylemler için sıkı bir şekilde tanımlanmış roller atayın, geniş veya gereksiz izinlerden kaçının.
- **İzinleri İzleyin ve Denetleyin:** İzin kullanımını sürekli izleyin ve erişim günlüklerini denetleyin, aşırı veya kullanılmayan ayrıcalıkları hızlı bir şekilde tespit edip düzeltin.

# Dolaylı prompt enjeksiyonu saldırıları

### Sorun ifadesi

Kötü niyetli veya tehlikeye atılmış MCP sunucuları, müşteri verilerini ifşa ederek veya istenmeyen eylemleri etkinleştirerek önemli riskler oluşturabilir. Bu riskler, özellikle AI ve MCP tabanlı iş yüklerinde geçerlidir, burada:

- **Prompt Enjeksiyon Saldırıları**: Saldırganlar, AI sisteminin istenmeyen eylemler gerçekleştirmesine veya hassas verileri sızdırmasına neden olan promptlara veya harici içeriğe kötü niyetli talimatlar yerleştirir. Daha fazla bilgi için: [Prompt Enjeksiyonu](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Araç Zehirlenmesi**: Saldırganlar, AI'nın davranışını etkilemek için araç meta verilerini (açıklamalar veya parametreler gibi) manipüle eder, potansiyel olarak güvenlik kontrollerini atlatabilir veya veri sızdırabilir. Ayrıntılar: [Araç Zehirlenmesi](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Alanlar Arası Prompt Enjeksiyonu**: Kötü niyetli talimatlar, belgeler, web sayfaları veya e-postalar gibi içeriklere yerleştirilir ve AI tarafından işlendiğinde veri sızıntısı veya manipülasyonuna yol açar.
- **Dinamik Araç Değişikliği (Halı Çekme)**: Araç tanımları, kullanıcı onayından sonra değiştirilebilir, kullanıcı farkında olmadan yeni kötü niyetli davranışlar tanıtılabilir.

Bu güvenlik açıkları, MCP sunucularını ve araçlarını çevrenize entegre ederken sağlam doğrulama, izleme ve güvenlik kontrollerine duyulan ihtiyacı vurgular. Daha derinlemesine bir inceleme için yukarıdaki bağlantılı referanslara bakın.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.tr.png)

**Dolaylı Prompt Enjeksiyonu** (alanlar arası prompt enjeksiyonu veya XPIA olarak da bilinir), Model Context Protocol (MCP) kullananlar da dahil olmak üzere üretken AI sistemlerinde kritik bir güvenlik açığıdır. Bu saldırıda, kötü niyetli talimatlar, belgeler, web sayfaları veya e-postalar gibi harici içeriklere gizlenir. AI sistemi bu içeriği işlediğinde, gömülü talimatları meşru kullanıcı komutları olarak yorumlayabilir, bu da veri sızıntısı, zararlı içerik üretimi veya kullanıcı etkileşimlerinin manipülasyonu gibi istenmeyen eylemlerle sonuçlanabilir. Ayrıntılı bir açıklama ve gerçek dünya örnekleri için [Prompt Enjeksiyonu](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/) bakınız.

Bu saldırının özellikle tehlikeli bir biçimi **Araç Zehirlenmesi**dir. Burada, saldırganlar MCP araçlarının meta verilerine (araç açıklamaları veya parametreleri gibi) kötü niyetli talimatlar enjekte eder. Büyük dil modelleri (LLM'ler), hangi araçları çağıracaklarına karar vermek için bu meta verilere güvendiğinden, tehlikeye atılmış açıklamalar, modeli yetkisiz araç çağrıları gerçekleştirmesi veya güvenlik kontrollerini atlatması için kandırabilir. Bu manipülasyonlar genellikle son kullanıcılar için görünmezdir ancak AI sistemi tarafından yorumlanabilir ve uygulanabilir. Bu risk, kullanıcı onayından sonra araç tanımlarının güncellenebileceği barındırılan MCP sunucu ortamlarında artar—bazen "[halı çekme](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" olarak adlandırılan bir senaryo. Böyle durumlarda, daha önce güvenli olan bir araç daha sonra veri sızdırmak veya sistem davranışını değiştirmek gibi kötü niyetli eylemler gerçekleştirmek üzere değiştirilebilir, kullanıcı haberi olmadan. Bu saldırı vektörü hakkında daha fazla bilgi için [Araç Zehirlenmesi](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks) bakınız.

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.tr.png)

## Riskler
İstenmeyen AI eylemleri, veri sızdırılması ve gizlilik ihlalleri dahil olmak üzere çeşitli güvenlik riskleri sunar.

### Azaltıcı kontroller
### Dolaylı Prompt Enjeksiyonu saldırılarına karşı korumak için prompt kalkanlarını kullanma

**AI Prompt Shields**, hem doğrudan hem de dolaylı prompt enjeksiyonu saldırılarına karşı savunma sağlamak için Microsoft tarafından geliştirilen bir çözümdür. Şu yollarla yardımcı olurlar:

1.  **Tespit ve Filtreleme**: Prompt Shields, belgeler, web sayfaları veya e-postalar gibi harici içeriklere gömülü kötü niyetli talimatları tespit etmek ve filtrelemek için gelişmiş makine öğrenme algoritmaları ve doğal dil işleme kullanır.
    
2.  **Spotlighting**: Bu teknik, AI sisteminin geçerli sistem talimatları ile potansiyel olarak güvenilmez harici girdiler arasında ayrım yapmasına yardımcı olur. Girdi metnini modele daha uygun hale getiren bir şekilde dönüştürerek, Spotlighting AI'nın kötü niyetli talimatları daha iyi tanımlayıp göz ardı etmesini sağlar.
    
3.  **Ayırıcılar ve Veri İşaretleme**: Sistem mesajında ayırıcılar eklemek, girdi metninin konumunu açıkça belirtir ve AI sisteminin kullanıcı girdilerini potansiyel olarak zararlı harici içerikten ayırmasını sağlar. Veri işaretleme, güvenilir ve güvenilmez verilerin sınırlarını vurgulamak için özel işaretler kullanarak bu kavramı genişletir.
    
4.  **Sürekli İzleme ve Güncellemeler**: Microsoft, yeni ve gelişen tehditlere karşı Prompt Shields'ı sürekli olarak izler ve günceller. Bu proaktif yaklaşım, savunmaların en son saldırı tekniklerine karşı etkili kalmasını sağlar.
    
5. **Azure İçerik Güvenliği ile Entegrasyon:** Prompt Shields, AI uygulamalarında jailbreak girişimlerini, zararlı içerikleri ve diğer güvenlik risklerini tespit etmek için ek araçlar sağlayan daha geniş Azure AI İçerik Güvenliği paketinin bir parçasıdır.

AI prompt kalkanları hakkında daha fazla bilgi edinebilirsiniz: [Prompt Shields dokümantasyonu](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.tr.png)

### Tedarik zinciri güvenliği

Tedarik zinciri güvenliği, AI çağında temel olmaya devam ediyor, ancak tedarik zincirinizin kapsamı genişledi. Geleneksel kod paketlerine ek olarak, artık temel modeller, gömme hizmetleri, bağlam sağlayıcılar ve üçüncü taraf API'ler dahil olmak üzere tüm AI ile ilgili bileşenleri titizlikle doğrulamanız ve izlemeniz gerekiyor. Bunların her biri, uygun şekilde yönetilmezse güvenlik açıkları veya riskler oluşturabilir.

**AI ve MCP için temel tedarik zinciri güvenliği uygulamaları:**
- **Entegrasyondan önce tüm bileşenleri doğrulayın:** Bu sadece açık kaynak kütüphaneleri değil, aynı zamanda AI modelleri, veri kaynakları ve harici API'ler için de geçerlidir. Her zaman köken, lisanslama ve bilinen güvenlik açıklarını kontrol edin.
- **Güvenli dağıtım hatları koruyun:** Sorunları erken yakalamak için entegre güvenlik taramaları ile otomatik CI/CD hatları kullanın. Yalnızca güvenilir eserlerin üretime dağıtıldığından emin olun.
- **Sürekli izleme ve denetim yapın:** Modeller ve veri hizmetleri dahil olmak üzere tüm bağımlılıkları izlemek için sürekli izleme uygulayın, yeni güvenlik açıklarını veya tedarik zinciri saldırılarını tespit edin.
- **En az ayrıcalık ve erişim kontrollerini uygulayın:** Modeller, veriler ve hizmetlere erişimi yalnızca MCP sunucunuzun işlev görmesi için gerekli olanla sınırlayın.
- **Tehditlere hızlı yanıt verin:** Tehlikeye atılmış bileşenleri yamalama veya değiştirme ve bir ihlal tespit edilirse sırları veya kimlik bilgilerini döndürme için bir süreç oluşturun.

[GitHub Gelişmiş Güvenlik](https://github.com/security/advanced-security), gizli tarama, bağımlılık tarama ve CodeQL analizi gibi özellikler sağlar. Bu araçlar, [Azure DevOps](https://azure.microsoft.com/en-us
- [OWASP LLM'ler için İlk 10](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Gelişmiş Güvenlik](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Microsoft'ta Yazılım Tedarik Zincirini Güvenli Hale Getirme Yolculuğu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Güvenli En Az Ayrıcalıklı Erişim (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Token Doğrulama ve Ömrü için En İyi Uygulamalar](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Güvenli Token Depolama Kullanımı ve Tokenları Şifreleme (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [MCP için Kimlik Doğrulama Geçidi olarak Azure API Yönetimi](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Sunucuları ile Kimlik Doğrulama için Microsoft Entra ID Kullanımı](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Sonraki

Sonraki: [Bölüm 3: Başlangıç](/03-GettingStarted/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Belgenin orijinal diliyle yazılmış hali yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlama veya yanlış yorumlamalardan sorumlu değiliz.