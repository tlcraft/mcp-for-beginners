<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:17:55+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "tr"
}
-->
# Güvenlik En İyi Uygulamaları

Model Context Protocol (MCP) benimsenmesi, yapay zeka destekli uygulamalara güçlü yeni yetenekler kazandırırken, geleneksel yazılım risklerinin ötesine geçen benzersiz güvenlik zorluklarını da beraberinde getirir. Güvenli kodlama, en az ayrıcalık ve tedarik zinciri güvenliği gibi yerleşik endişelerin yanı sıra, MCP ve yapay zeka iş yükleri prompt enjeksiyonu, araç zehirlenmesi ve dinamik araç değişikliği gibi yeni tehditlerle karşı karşıyadır. Bu riskler uygun şekilde yönetilmezse veri sızıntısı, gizlilik ihlalleri ve istenmeyen sistem davranışlarına yol açabilir.

Bu ders, MCP ile ilişkili en önemli güvenlik risklerini—kimlik doğrulama, yetkilendirme, aşırı izinler, dolaylı prompt enjeksiyonu ve tedarik zinciri zayıflıkları dahil—inceleyerek bunları azaltmak için uygulanabilir kontroller ve en iyi uygulamalar sunar. Ayrıca MCP uygulamanızı güçlendirmek için Microsoft çözümleri olan Prompt Shields, Azure Content Safety ve GitHub Advanced Security'nin nasıl kullanılacağını öğreneceksiniz. Bu kontrolleri anlayıp uygulayarak, bir güvenlik ihlalinin olasılığını önemli ölçüde azaltabilir ve yapay zeka sistemlerinizin sağlam ve güvenilir kalmasını sağlayabilirsiniz.

# Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Model Context Protocol (MCP) tarafından getirilen benzersiz güvenlik risklerini, prompt enjeksiyonu, araç zehirlenmesi, aşırı izinler ve tedarik zinciri zayıflıkları dahil olmak üzere tanımlamak ve açıklamak.
- MCP güvenlik riskleri için sağlam kimlik doğrulama, en az ayrıcalık, güvenli token yönetimi ve tedarik zinciri doğrulaması gibi etkili azaltıcı kontrolleri tanımlamak ve uygulamak.
- MCP ve yapay zeka iş yüklerini korumak için Prompt Shields, Azure Content Safety ve GitHub Advanced Security gibi Microsoft çözümlerini anlamak ve kullanmak.
- Araç meta verilerini doğrulamanın, dinamik değişiklikleri izlemenin ve dolaylı prompt enjeksiyonu saldırılarına karşı savunmanın önemini kavramak.
- MCP uygulamanıza güvenli kodlama, sunucu sertleştirme ve sıfır güven mimarisi gibi yerleşik güvenlik en iyi uygulamalarını entegre ederek güvenlik ihlallerinin olasılığını ve etkisini azaltmak.

# MCP güvenlik kontrolleri

Önemli kaynaklara erişimi olan her sistemin dolaylı güvenlik zorlukları vardır. Güvenlik zorlukları genellikle temel güvenlik kontrolleri ve kavramlarının doğru uygulanmasıyla ele alınabilir. MCP yeni tanımlandığı için, spesifikasyon çok hızlı değişmekte ve protokol geliştikçe güvenlik kontrolleri olgunlaşarak kurumsal ve yerleşik güvenlik mimarileri ile en iyi uygulamalarla daha iyi entegrasyon sağlayacaktır.

[Microsoft Digital Defense Report](https://aka.ms/mddr) raporunda, bildirilen ihlallerin %98’inin sağlam güvenlik hijyeni ile önlenebileceği belirtilmektedir ve herhangi bir ihlale karşı en iyi koruma, temel güvenlik hijyeninizi, güvenli kodlama en iyi uygulamalarını ve tedarik zinciri güvenliğini doğru yapmaktır — zaten bildiğimiz bu denenmiş ve test edilmiş uygulamalar güvenlik riskini azaltmada en büyük etkiye sahiptir.

MCP’yi benimserken güvenlik risklerini ele almaya başlayabileceğiniz bazı yöntemlere bakalım.

> **Not:** Aşağıdaki bilgiler **29 Mayıs 2025** itibarıyla doğrudur. MCP protokolü sürekli gelişmektedir ve gelecekteki uygulamalar yeni kimlik doğrulama kalıpları ve kontroller getirebilir. En son güncellemeler ve rehberlik için her zaman [MCP Specification](https://spec.modelcontextprotocol.io/), resmi [MCP GitHub repository](https://github.com/modelcontextprotocol) ve [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices) sayfalarına bakınız.

### Sorun bildirimi  
Orijinal MCP spesifikasyonu, geliştiricilerin kendi kimlik doğrulama sunucularını yazacağını varsayıyordu. Bu, OAuth ve ilgili güvenlik kısıtlamaları hakkında bilgi gerektiriyordu. MCP sunucuları, Microsoft Entra ID gibi harici bir hizmete devretmek yerine kullanıcı kimlik doğrulamasını doğrudan yöneten OAuth 2.0 Yetkilendirme Sunucuları olarak hareket etti. **26 Nisan 2025** itibarıyla MCP spesifikasyonundaki bir güncelleme, MCP sunucularının kullanıcı kimlik doğrulamasını harici bir hizmete devretmesine izin vermektedir.

### Riskler
- MCP sunucusundaki yanlış yapılandırılmış yetkilendirme mantığı hassas veri sızıntısına ve yanlış uygulanmış erişim kontrollerine yol açabilir.
- Yerel MCP sunucusunda OAuth token hırsızlığı. Çalınması durumunda, token MCP sunucusunu taklit etmek ve token’ın ait olduğu hizmetten kaynaklara ve verilere erişmek için kullanılabilir.

#### Token Geçişi
Token geçişi, yetkilendirme spesifikasyonunda açıkça yasaktır çünkü şu güvenlik risklerini beraberinde getirir:

#### Güvenlik Kontrolü Atlatma
MCP Sunucusu veya aşağı akış API’leri, token hedef kitlesi veya diğer kimlik bilgisi kısıtlamalarına bağlı olarak hız sınırlama, istek doğrulama veya trafik izleme gibi önemli güvenlik kontrolleri uygulayabilir. İstemciler tokenları MCP sunucusunun doğru şekilde doğrulaması veya tokenların doğru hizmet için verildiğinden emin olması olmadan doğrudan aşağı akış API’leri ile kullanırsa, bu kontrolleri atlamış olurlar.

#### Hesap Verebilirlik ve Denetim İzleme Sorunları
MCP Sunucusu, istemciler yukarı akışta verilmiş erişim tokenı ile çağrı yaptığında MCP İstemcilerini tanımlayamaz veya ayırt edemez.  
Aşağı akış Kaynak Sunucusunun günlükleri, isteklerin tokenları ileten MCP sunucusu yerine farklı bir kaynaktan ve kimlikten geliyormuş gibi görünebilir.  
Her iki faktör de olay araştırmasını, kontrolleri ve denetimi zorlaştırır.  
MCP Sunucusu tokenların iddialarını (örneğin roller, ayrıcalıklar veya hedef kitle) veya diğer meta verilerini doğrulamadan tokenları geçirirse, çalınmış tokena sahip kötü niyetli bir aktör sunucuyu veri sızıntısı için vekil olarak kullanabilir.

#### Güven Sınırı Sorunları
Aşağı akış Kaynak Sunucusu belirli varlıklara güven verir. Bu güven, köken veya istemci davranış kalıpları hakkında varsayımlar içerebilir. Bu güven sınırının kırılması beklenmedik sorunlara yol açabilir.  
Token, uygun doğrulama olmadan birden fazla hizmet tarafından kabul edilirse, bir hizmeti ele geçiren saldırgan tokenı diğer bağlı hizmetlere erişmek için kullanabilir.

#### Gelecekte Uyumluluk Riski
Bugün MCP Sunucusu “saf bir vekil” olarak başlasa bile, ileride güvenlik kontrolleri eklemesi gerekebilir. Doğru token hedef kitle ayrımıyla başlamak, güvenlik modelinin gelişmesini kolaylaştırır.

### Azaltıcı kontroller

**MCP sunucuları, açıkça MCP sunucusu için verilmemiş tokenları KABUL ETMEMELİDİR**

- **Yetkilendirme Mantığını Gözden Geçirin ve Sertleştirin:** MCP sunucunuzun yetkilendirme uygulamasını dikkatle denetleyin, yalnızca amaçlanan kullanıcıların ve istemcilerin hassas kaynaklara erişebilmesini sağlayın. Pratik rehberlik için [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ve [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/) adreslerine bakabilirsiniz.
- **Güvenli Token Uygulamalarını Zorunlu Kılın:** Token kötüye kullanımını önlemek ve token tekrar oynatma veya hırsızlık riskini azaltmak için [Microsoft’un token doğrulama ve ömür en iyi uygulamalarını](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) takip edin.
- **Token Depolamayı Koruyun:** Tokenları her zaman güvenli bir şekilde saklayın ve hem dinlenme hem de aktarım sırasında şifreleme kullanın. Uygulama ipuçları için [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) kaynağına bakınız.

# MCP sunucuları için aşırı izinler

### Sorun bildirimi  
MCP sunucularına eriştikleri hizmet/kaynak üzerinde aşırı izinler verilmiş olabilir. Örneğin, kurumsal bir veri deposuna bağlanan bir AI satış uygulamasının parçası olan MCP sunucusu, satış verilerine erişimle sınırlandırılmalı ve depodaki tüm dosyalara erişim izni verilmemelidir. En az ayrıcalık prensibine (en eski güvenlik prensiplerinden biri) dayanarak, hiçbir kaynağın, yürütmesi gereken görevler için gerekenin üzerinde izinlere sahip olmaması gerekir. Yapay zeka bu alanda esnek olmasını sağlamak için gereken kesin izinleri tanımlamayı zorlaştırdığı için ek bir zorluk yaratır.

### Riskler  
- Aşırı izinler, MCP sunucusunun erişmemesi gereken verilerin sızdırılması veya değiştirilmesine olanak tanıyabilir. Bu, veriler kişisel olarak tanımlanabilir bilgiler (PII) içeriyorsa gizlilik sorunlarına da yol açabilir.

### Azaltıcı kontroller  
- **En Az Ayrıcalık Prensibini Uygulayın:** MCP sunucusuna yalnızca gerekli görevleri yerine getirmek için minimum izinleri verin. Bu izinleri düzenli olarak gözden geçirip güncelleyerek gereksiz izinlerin önüne geçin. Ayrıntılı rehberlik için [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) adresine bakınız.  
- **Rol Tabanlı Erişim Kontrolü (RBAC) Kullanın:** MCP sunucusuna, belirli kaynaklar ve işlemlerle sıkı şekilde sınırlandırılmış roller atayın; geniş veya gereksiz izinlerden kaçının.  
- **İzinleri İzleyin ve Denetleyin:** İzin kullanımını sürekli izleyin ve aşırı ya da kullanılmayan ayrıcalıkları tespit etmek için erişim günlüklerini denetleyin.

# Dolaylı prompt enjeksiyonu saldırıları

### Sorun bildirimi

Kötü niyetli veya ele geçirilmiş MCP sunucuları, müşteri verilerini açığa çıkararak veya istenmeyen işlemlere izin vererek önemli riskler yaratabilir. Bu riskler özellikle yapay zeka ve MCP tabanlı iş yüklerinde geçerlidir:

- **Prompt Enjeksiyonu Saldırıları:** Saldırganlar, yapay zeka sisteminin istenmeyen eylemler gerçekleştirmesine veya hassas verileri sızdırmasına yol açan kötü niyetli talimatları promptlara veya dış içeriklere gömer. Daha fazla bilgi: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)  
- **Araç Zehirlenmesi:** Saldırganlar, yapay zekanın davranışını etkilemek için araç meta verilerini (açıklamalar veya parametreler gibi) manipüle eder; bu, güvenlik kontrollerinin atlatılmasına veya veri sızıntısına neden olabilir. Detaylar: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)  
- **Çapraz Alan Prompt Enjeksiyonu:** Kötü niyetli talimatlar, belgeler, web sayfaları veya e-postalar içine gömülür ve yapay zeka tarafından işlenerek veri sızıntısı veya manipülasyona yol açar.  
- **Dinamik Araç Değişikliği (Rug Pulls):** Kullanıcı onayından sonra araç tanımları değiştirilebilir, böylece kullanıcı farkında olmadan yeni kötü niyetli davranışlar eklenebilir.

Bu zayıflıklar, MCP sunucularını ve araçları ortamınıza entegre ederken sağlam doğrulama, izleme ve güvenlik kontrollerine ihtiyaç olduğunu vurgular. Daha derin bilgi için yukarıdaki bağlantılara bakabilirsiniz.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.tr.png)

**Dolaylı Prompt Enjeksiyonu** (aynı zamanda çapraz alan prompt enjeksiyonu veya XPIA olarak da bilinir), Model Context Protocol (MCP) kullanan jeneratif yapay zeka sistemlerinde kritik bir zayıflıktır. Bu saldırıda, kötü niyetli talimatlar dış içeriklerin içine—örneğin belgeler, web sayfaları veya e-postalar—gizlenir. Yapay zeka bu içeriği işlerken gömülü talimatları geçerli kullanıcı komutları olarak yorumlayabilir; bu da veri sızıntısı, zararlı içerik üretimi veya kullanıcı etkileşimlerinin manipülasyonu gibi istenmeyen sonuçlara yol açar. Ayrıntılı açıklama ve gerçek dünya örnekleri için [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/) sayfasına bakınız.

Bu saldırının özellikle tehlikeli bir türü **Araç Zehirlenmesi**dir. Burada saldırganlar, MCP araçlarının meta verilerine (araç açıklamaları veya parametreler gibi) kötü niyetli talimatlar enjekte eder. Büyük dil modelleri (LLM’ler) hangi araçların çağrılacağına karar verirken bu meta verilere güvendiği için, ele geçirilmiş açıklamalar modeli yetkisiz araç çağrılarını gerçekleştirmeye veya güvenlik kontrollerini atlamaya yönlendirebilir. Bu manipülasyonlar genellikle son kullanıcılar tarafından görünmez, ancak yapay zeka sistemi tarafından yorumlanır ve uygulanır. Bu risk, kullanıcı onayından sonra araç tanımlarının değiştirilebildiği barındırılan MCP sunucu ortamlarında daha da artar—buna bazen "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" denir. Bu durumda, önceden güvenli olan bir araç daha sonra kullanıcı farkında olmadan veri sızdırmak veya sistem davranışını değiştirmek gibi kötü niyetli işlemler yapmak üzere değiştirilebilir. Bu saldırı vektörü hakkında daha fazla bilgi için [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks) sayfasına bakınız.

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.tr.png)

## Riskler  
İstenmeyen yapay zeka eylemleri, veri sızıntısı ve gizlilik ihlalleri gibi çeşitli güvenlik riskleri doğurur.

### Azaltıcı kontroller  
### Dolaylı Prompt Enjeksiyonu saldırılarına karşı koruma için prompt shields kullanımı
-----------------------------------------------------------------------------

**AI Prompt Shields**, Microsoft tarafından doğrudan ve dolaylı prompt enjeksiyonu saldırılarına karşı savunma için geliştirilmiş bir çözümdür. Şu yollarla yardımcı olur:

1.  **Tespit ve Filtreleme:** Prompt Shields, gelişmiş makine öğrenimi algoritmaları ve doğal dil işleme teknikleri kullanarak belgeler, web sayfaları veya e-postalar gibi dış içeriklere gömülü kötü niyetli talimatları tespit eder ve filtreler.
    
2.  **Spotlighting:** Bu teknik, yapay zekanın geçerli sistem talimatları ile potansiyel olarak güvenilmez dış girdiler arasındaki ayrımı yapmasına yardımcı olur. Girdi metnini modele daha alakalı hale getirecek şekilde dönüştürerek, yapay zekanın kötü niyetli talimatları daha iyi tanımasını ve görmezden gelmesini sağlar.
    
3.  **Sınırlayıcılar ve Veri İşaretleme:** Sistem mesajına eklenen sınırlayıcılar, giriş metninin konumunu açıkça belirtir; bu sayede yapay zeka kullanıcı girdileri ile potansiyel zararlı dış içerikleri ayırt edebilir. Veri işaretleme, güvenilir ve güvensiz verinin sınırlarını vurgulamak için özel işaretler kullanarak bu kavramı genişletir.
    
4.  **Sürekli İzleme ve Güncellemeler:** Microsoft, Prompt Shields’i yeni ve gelişen tehditlere karşı sürekli izler ve günceller. Bu proaktif yaklaşım, savunmaların en yeni saldırı tekniklerine karşı etkili kalmasını sağlar.
    
5. **Azure Content Safety ile Entegrasyon:** Prompt Shields, Azure AI Content Safety paketinin bir parçasıdır ve bu paket, yapay zeka uygulamalarında jailbreak girişimlerini, zararlı içerikleri ve diğer güvenlik risklerini tespit etmek için ek araçlar sağlar.

AI prompt shields hakkında daha fazla bilgi için [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) sayfasını inceleyebilirsiniz.

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.tr.png)

### Tedarik zinciri güvenliği

Tedarik zinciri güvenliği yapay zeka çağında da temel olmaya devam etmekle birlikte, tedarik zincirinizin kapsamı genişlemiştir. Geleneksel kod paketlerine ek olarak, temel modeller, gömme servisleri, bağ
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Microsoft'te Yazılım Tedarik Zincirini Güvence Altına Alma Yolculuğu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [En Az Ayrıcalıklı Erişimi Güvence Altına Alma (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Token Doğrulama ve Ömür Süresi İçin En İyi Uygulamalar](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Güvenli Token Depolama ve Token’ları Şifreleme (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Yönetimi MCP için Yetkilendirme Geçidi Olarak](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Güvenlik En İyi Uygulamaları](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Sunucularında Kimlik Doğrulama için Microsoft Entra ID Kullanımı](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Sonraki

Sonraki: [Bölüm 3: Başlarken](/03-GettingStarted/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.