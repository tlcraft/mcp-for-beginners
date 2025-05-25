<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:08:17+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "tr"
}
-->
# Güvenlik En İyi Uygulamaları

Model Context Protocol (MCP) benimsemek, yapay zeka odaklı uygulamalara güçlü yeni yetenekler kazandırır, ancak geleneksel yazılım risklerinin ötesinde benzersiz güvenlik zorluklarını da beraberinde getirir. Güvenli kodlama, en az ayrıcalık ve tedarik zinciri güvenliği gibi yerleşik endişelere ek olarak, MCP ve AI iş yükleri, prompt enjeksiyonu, araç zehirlenmesi ve dinamik araç değişikliği gibi yeni tehditlerle karşı karşıyadır. Bu riskler, uygun şekilde yönetilmezse veri sızdırma, gizlilik ihlalleri ve istenmeyen sistem davranışlarına yol açabilir.

Bu ders, MCP ile ilişkili en önemli güvenlik risklerini—kimlik doğrulama, yetkilendirme, aşırı izinler, dolaylı prompt enjeksiyonu ve tedarik zinciri zayıflıkları dahil—inceler ve bunları azaltmak için uygulanabilir kontroller ve en iyi uygulamalar sunar. Ayrıca Prompt Shields, Azure Content Safety ve GitHub Advanced Security gibi Microsoft çözümlerini kullanarak MCP uygulamanızı nasıl güçlendirebileceğinizi öğreneceksiniz. Bu kontrolleri anlayıp uygulayarak, bir güvenlik ihlalinin olasılığını önemli ölçüde azaltabilir ve AI sistemlerinizin sağlam ve güvenilir kalmasını sağlayabilirsiniz.

# Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Model Context Protocol (MCP) tarafından getirilen benzersiz güvenlik risklerini, prompt enjeksiyonu, araç zehirlenmesi, aşırı izinler ve tedarik zinciri zayıflıkları dahil olmak üzere tanımlamak ve açıklamak.
- MCP güvenlik riskleri için sağlam kimlik doğrulama, en az ayrıcalık, güvenli token yönetimi ve tedarik zinciri doğrulaması gibi etkili azaltıcı kontrolleri tanımlamak ve uygulamak.
- MCP ve AI iş yüklerini korumak için Prompt Shields, Azure Content Safety ve GitHub Advanced Security gibi Microsoft çözümlerini anlamak ve kullanmak.
- Araç meta verilerini doğrulamanın, dinamik değişiklikleri izlemenin ve dolaylı prompt enjeksiyonu saldırılarına karşı savunmanın önemini kavramak.
- MCP uygulamanıza güvenli kodlama, sunucu sertleştirme ve sıfır güven mimarisi gibi yerleşik güvenlik en iyi uygulamalarını entegre ederek güvenlik ihlallerinin olasılığını ve etkisini azaltmak.

# MCP güvenlik kontrolleri

Önemli kaynaklara erişimi olan her sistemin doğal olarak güvenlik zorlukları vardır. Güvenlik zorlukları genellikle temel güvenlik kontrollerinin ve kavramlarının doğru uygulanmasıyla ele alınabilir. MCP henüz yeni tanımlandığı için spesifikasyon hızla değişmekte ve protokol geliştikçe güvenlik kontrolleri olgunlaşarak kurumsal ve yerleşik güvenlik mimarileri ve en iyi uygulamalarla daha iyi entegrasyon sağlayacaktır.

[Microsoft Digital Defense Report](https://aka.ms/mddr)’da yayınlanan araştırma, bildirilen ihlallerin %98’inin sağlam güvenlik hijyeni ile önlenebileceğini ve herhangi bir ihlale karşı en iyi korumanın temel güvenlik hijyeni, güvenli kodlama en iyi uygulamaları ve tedarik zinciri güvenliğini doğru uygulamak olduğunu belirtmektedir — zaten bildiğimiz ve test edilmiş bu uygulamalar, güvenlik riskini azaltmada en büyük etkiyi yaratmaya devam etmektedir.

MCP benimserken güvenlik risklerini ele almaya başlamanın bazı yollarına bakalım.

# MCP sunucu kimlik doğrulaması (MCP uygulamanız 26 Nisan 2025’ten önceyse)

> **Note:** Aşağıdaki bilgiler 26 Nisan 2025 itibarıyla doğrudur. MCP protokolü sürekli gelişmektedir ve gelecekteki uygulamalar yeni kimlik doğrulama kalıpları ve kontroller getirebilir. En güncel bilgiler ve rehberlik için her zaman [MCP Specification](https://spec.modelcontextprotocol.io/) ve resmi [MCP GitHub repository](https://github.com/modelcontextprotocol) sayfalarına bakınız.

### Sorun tanımı  
Orijinal MCP spesifikasyonu, geliştiricilerin kendi kimlik doğrulama sunucularını yazacaklarını varsayıyordu. Bu, OAuth ve ilgili güvenlik kısıtlamaları hakkında bilgi gerektiriyordu. MCP sunucuları, kullanıcı kimlik doğrulamasını doğrudan yöneterek OAuth 2.0 Yetkilendirme Sunucusu olarak hareket etti; bu işlem Microsoft Entra ID gibi dış bir hizmete devredilmedi. 26 Nisan 2025 itibarıyla MCP spesifikasyonunda yapılan bir güncelleme, MCP sunucularının kullanıcı kimlik doğrulamasını dış bir hizmete devretmesine izin vermektedir.

### Riskler
- MCP sunucusundaki yanlış yapılandırılmış yetkilendirme mantığı, hassas veri sızıntısına ve hatalı erişim kontrollerine yol açabilir.
- Yerel MCP sunucusunda OAuth token hırsızlığı. Token çalınırsa, MCP sunucusunu taklit etmek ve token’ın ait olduğu hizmetten kaynaklara ve verilere erişmek için kullanılabilir.

### Azaltıcı kontroller
- **Yetkilendirme Mantığını Gözden Geçirin ve Sertleştirin:** MCP sunucunuzun yetkilendirme uygulamasını dikkatlice denetleyin; yalnızca amaçlanan kullanıcılar ve istemcilerin hassas kaynaklara erişebildiğinden emin olun. Pratik rehberlik için [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ve [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/) sayfalarına bakınız.
- **Güvenli Token Uygulamalarını Zorunlu Kılın:** Erişim tokenlarının kötüye kullanımını önlemek ve token tekrar oynatma veya hırsızlık riskini azaltmak için [Microsoft’un token doğrulama ve yaşam süresi en iyi uygulamalarını](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) takip edin.
- **Token Depolamayı Koruyun:** Tokenları her zaman güvenli şekilde depolayın ve hem dinlenirken hem iletim sırasında şifreleme kullanarak koruyun. Uygulama ipuçları için [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) kaynağına bakabilirsiniz.

# MCP sunucuları için aşırı izinler

### Sorun tanımı  
MCP sunucularına eriştikleri hizmet/kaynak üzerinde aşırı izinler verilmiş olabilir. Örneğin, bir AI satış uygulamasının parçası olan bir MCP sunucusunun, kurumsal veri deposuna bağlanırken yalnızca satış verilerine erişimi olmalı, depodaki tüm dosyalara erişim hakkı olmamalıdır. En az ayrıcalık prensibine (en eski güvenlik prensiplerinden biri) göre, hiçbir kaynak, yerine getirmesi gereken görevler için gerekli olandan fazla izne sahip olmamalıdır. AI bu alanda esneklik sağlamak istediği için, gereken tam izinlerin tanımlanması zorlaşmaktadır.

### Riskler  
- Aşırı izin verilmesi, MCP sunucusunun erişmemesi gereken verilere sızdırma veya değiştirme yapmasına olanak tanıyabilir. Bu, veriler kişisel tanımlayıcı bilgiler (PII) içeriyorsa gizlilik sorunu da olabilir.

### Azaltıcı kontroller
- **En Az Ayrıcalık Prensibini Uygulayın:** MCP sunucusuna yalnızca gerekli görevleri yerine getirmek için minimum izinleri verin. Bu izinleri düzenli olarak gözden geçirin ve ihtiyaçtan fazla olmadığından emin olun. Detaylı rehber için [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) sayfasına bakınız.
- **Rol Tabanlı Erişim Kontrolü (RBAC) Kullanın:** MCP sunucusuna, belirli kaynaklar ve işlemlerle sıkı şekilde sınırlandırılmış roller atayın; geniş veya gereksiz izinlerden kaçının.
- **İzinleri İzleyin ve Denetleyin:** İzin kullanımını sürekli izleyin ve aşırı veya kullanılmayan ayrıcalıkları tespit edip hızlıca düzeltmek için erişim günlüklerini denetleyin.

# Dolaylı prompt enjeksiyonu saldırıları

### Sorun tanımı

Kötü niyetli veya ele geçirilmiş MCP sunucuları, müşteri verilerini açığa çıkarma veya istenmeyen işlemleri tetikleme riski taşır. Bu riskler özellikle AI ve MCP tabanlı iş yüklerinde önemlidir:

- **Prompt Enjeksiyonu Saldırıları:** Saldırganlar, yapay zeka sisteminin istenmeyen işlemler yapmasına veya hassas verileri sızdırmasına neden olan kötü amaçlı komutları promptlara veya dış içeriklere gömer. Detaylı bilgi: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Araç Zehirlenmesi:** Saldırganlar, AI davranışını etkilemek için araç meta verilerini (açıklamalar veya parametreler gibi) manipüle eder, böylece güvenlik kontrollerini aşabilir veya veri sızdırabilir. Ayrıntılar: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Çapraz Alan Prompt Enjeksiyonu:** Kötü amaçlı komutlar, belgeler, web sayfaları veya e-postalar içine gömülür ve AI tarafından işlenerek veri sızıntısı veya manipülasyona yol açar.
- **Dinamik Araç Değişikliği (Rug Pulls):** Kullanıcı onayından sonra araç tanımları değiştirilebilir, bu da kullanıcının farkında olmadan yeni kötü amaçlı davranışların sisteme girmesine neden olur.

Bu zayıflıklar, MCP sunucuları ve araçlarını ortamınıza entegre ederken sağlam doğrulama, izleme ve güvenlik kontrollerinin gerekliliğini ortaya koymaktadır. Daha derin bilgi için yukarıdaki bağlantılara bakınız.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.tr.png)

**Dolaylı Prompt Enjeksiyonu** (diğer adıyla çapraz alan prompt enjeksiyonu veya XPIA), Model Context Protocol (MCP) kullanan jeneratif AI sistemlerinde kritik bir güvenlik açığıdır. Bu saldırıda, kötü niyetli talimatlar belgeler, web sayfaları veya e-postalar gibi dış içeriklerin içine gizlenir. AI sistemi bu içeriği işlediğinde, gömülü talimatları meşru kullanıcı komutları olarak yorumlayabilir; bu da veri sızıntısı, zararlı içerik üretimi veya kullanıcı etkileşimlerinin manipülasyonu gibi istenmeyen sonuçlara yol açar. Ayrıntılı açıklama ve gerçek dünya örnekleri için [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/) sayfasına bakınız.

Bu saldırının özellikle tehlikeli bir biçimi **Araç Zehirlenmesi**dir. Burada saldırganlar MCP araçlarının meta verilerine (örneğin araç açıklamaları veya parametreler) kötü amaçlı talimatlar enjekte eder. Büyük dil modelleri (LLM’ler) hangi araçları çağıracaklarına karar verirken bu meta verilere güvendiğinden, ele geçirilmiş açıklamalar modeli yetkisiz araç çağrılarını yapmaya veya güvenlik kontrollerini atlamaya yönlendirebilir. Bu manipülasyonlar kullanıcılar tarafından genellikle görünmez, ancak AI sistemi tarafından yorumlanıp işlenir. Bu risk, kullanıcı onayından sonra araç tanımlarının değiştirilebildiği barındırılan MCP sunucu ortamlarında artar; bu duruma bazen "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" denir. Böyle durumlarda, önceden güvenli olan bir araç daha sonra kullanıcı farkında olmadan veri sızdırma veya sistem davranışını değiştirme gibi kötü amaçlı işlemler yapmak üzere değiştirilebilir. Bu saldırı vektörü hakkında daha fazla bilgi için [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks) sayfasına bakınız.

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.tr.png)

## Riskler
İstenmeyen AI işlemleri, veri sızdırma ve gizlilik ihlalleri gibi çeşitli güvenlik riskleri oluşturur.

### Azaltıcı kontroller
### Dolaylı Prompt Enjeksiyonu saldırılarına karşı koruma için prompt shields kullanımı
-----------------------------------------------------------------------------

**AI Prompt Shields**, Microsoft tarafından doğrudan ve dolaylı prompt enjeksiyonu saldırılarına karşı koruma amacıyla geliştirilmiş bir çözümdür. Şu yollarla yardımcı olur:

1.  **Tespit ve Filtreleme:** Prompt Shields, gelişmiş makine öğrenimi algoritmaları ve doğal dil işleme teknikleri kullanarak, belgeler, web sayfaları veya e-postalar gibi dış içeriklere gömülü kötü amaçlı talimatları tespit eder ve filtreler.
    
2.  **Spotlighting:** Bu teknik, AI sisteminin geçerli sistem talimatları ile potansiyel olarak güvenilmez dış girdiler arasındaki ayrımı yapmasına yardımcı olur. Girdi metnini modele daha alakalı hale getirecek şekilde dönüştürerek, AI’nın kötü amaçlı talimatları daha iyi tanımasını ve yok saymasını sağlar.
    
3.  **Sınırlandırıcılar ve Veri İşaretleme:** Sistem mesajında sınırlandırıcılar kullanmak, AI sisteminin kullanıcı girdilerini potansiyel zararlı dış içerikten ayırmasını sağlar. Veri işaretleme ise güvenilir ve güvenilmeyen verinin sınırlarını özel işaretçilerle vurgulayarak bu kavramı genişletir.
    
4.  **Sürekli İzleme ve Güncellemeler:** Microsoft, yeni ve gelişen tehditlere karşı Prompt Shields’i sürekli izler ve günceller. Bu proaktif yaklaşım, savunmaların en son saldırı tekniklerine karşı etkili kalmasını sağlar.
    
5. **Azure Content Safety ile Entegrasyon:** Prompt Shields, Azure AI Content Safety paketinin bir parçasıdır ve jailbreak tespitleri, zararlı içerik ve AI uygulamalarındaki diğer güvenlik risklerini tespit için ek araçlar sunar.

AI prompt shields hakkında daha fazla bilgiyi [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) sayfasında bulabilirsiniz.

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.tr.png)

### Tedarik zinciri güvenliği

Tedarik zinciri güvenliği AI çağında da temel önemdedir, ancak tedarik zincirinizin kapsamı genişlemiştir. Geleneksel kod paketlerine ek olarak, temel modeller, gömme servisleri, bağlam sağlayıcıları ve üçüncü taraf API’ler dahil tüm AI ile ilgili bileşenleri titizlikle doğrulamanız ve izlemeniz gerekir. Bunların her biri uygun yönetilmezse zayıflıklar veya riskler doğurabilir.

**AI ve MCP için temel tedarik zinciri güvenliği uygulamaları:**
- **Tüm bileşenleri entegrasyondan önce doğrulayın:** Sadece açık kaynak kütüphaneler değil, aynı zamanda AI modelleri, veri kaynakları ve dış API’ler de dahil olmak üzere. Kaynak, lisans ve bilinen zayıflıklar mutlaka kontrol edilmelidir.
- **Güvenli dağıtım hatları oluşturun:** Otomatik CI/CD hatları kullanarak güvenlik taramalarını entegre edin ve sorunları erken aşamada yakalayın. Sadece güvenilir artefaktların üretime dağıtıldığından emin olun.
- **Sürekli izleme ve denetim uygulayın:** Modeller ve veri servisleri dahil tüm bağımlılıkların sürekli izlenmesini sağlayarak yeni zayıflıkları veya tedarik zinciri saldırılarını tespit edin.
- **En az ayrıcalık ve erişim kontrolleri uygulayın:** MCP sunucunuzun çalışması için sadece gerekli modellere, verilere ve servislere erişim izni verin.
- **Tehditlere hızlı yanıt verin:** Ele geçirilmiş bileşenleri yamalama veya değiştirme süreçlerine sahip olun; ihlal tespit edilirse gizli anahtarları veya kimlik bilgilerini rotasyon yapın.

[GitHub Advanced Security](https://github.com/security/advanced-security), gizli anahtar taraması, bağımlılık taraması ve CodeQL analizi gibi özellikler sunar. Bu araçlar, hem kod hem de AI tedarik zinciri bileşenlerindeki zayıflıkları tespit edip azaltmak için [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) ve [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) ile entegre çalışır.

Microsoft ayrıca tüm ürünlerinde kapsamlı tedarik zinciri güvenliği uygulamaları uygular. Detaylar için [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/) sayfasına bakabilirsiniz.

# MCP uygulamanızın güvenlik duruşunu güçlendirecek yerleşik güvenlik en iyi uygulamaları

Her MCP uygulaması, üzerine inşa edildiği organizasyon ortamının mevcut güvenlik duruşunu devralır; bu nedenle MCP’nin genel AI sistemlerinizin bir bileşeni olarak güvenliğini değerlendirirken mevcut güvenlik duruşunuzu güçlendirmeyi düşünmeniz önerilir. Aşağıdaki yerleşik güvenlik kontrolleri özellikle önemlidir:

- AI uygulamanızda güvenli kodlama
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Microsoft'te Yazılım Tedarik Zincirini Güvenceye Alma Yolculuğu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [En Az Ayrıcalıklı Erişimi Güvenli Hale Getirme (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Token Doğrulama ve Ömrü İçin En İyi Uygulamalar](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Güvenli Token Depolama ve Tokenları Şifreleme (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [MCP için Yetkilendirme Geçidi Olarak Azure API Yönetimi](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Sunucularında Kimlik Doğrulama için Microsoft Entra ID Kullanımı](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Sonraki

Sonraki: [Bölüm 3: Başlarken](/03-GettingStarted/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilindeki haliyle yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek herhangi bir yanlış anlama veya yanlış yorumdan sorumlu değiliz.