<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-13T16:48:01+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "tr"
}
-->
# Güvenlik En İyi Uygulamaları

Model Context Protocol (MCP) kullanmak, yapay zeka destekli uygulamalara güçlü yeni yetenekler kazandırırken, geleneksel yazılım risklerinin ötesine geçen benzersiz güvenlik zorluklarını da beraberinde getirir. Güvenli kodlama, en az ayrıcalık ve tedarik zinciri güvenliği gibi yerleşik endişelerin yanı sıra, MCP ve yapay zeka iş yükleri prompt enjeksiyonu, araç zehirlenmesi ve dinamik araç değişikliği gibi yeni tehditlerle karşı karşıyadır. Bu riskler uygun şekilde yönetilmezse veri sızıntısı, gizlilik ihlalleri ve istenmeyen sistem davranışlarına yol açabilir.

Bu ders, MCP ile ilişkili en önemli güvenlik risklerini—kimlik doğrulama, yetkilendirme, aşırı izinler, dolaylı prompt enjeksiyonu ve tedarik zinciri zayıflıkları dahil—inceler ve bunları azaltmak için uygulanabilir kontroller ve en iyi uygulamalar sunar. Ayrıca, MCP uygulamanızı güçlendirmek için Microsoft çözümleri olan Prompt Shields, Azure Content Safety ve GitHub Advanced Security’nin nasıl kullanılacağını öğreneceksiniz. Bu kontrolleri anlayıp uygulayarak, bir güvenlik ihlalinin olasılığını önemli ölçüde azaltabilir ve yapay zeka sistemlerinizin sağlam ve güvenilir kalmasını sağlayabilirsiniz.

# Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Model Context Protocol (MCP) tarafından getirilen benzersiz güvenlik risklerini, prompt enjeksiyonu, araç zehirlenmesi, aşırı izinler ve tedarik zinciri zayıflıkları dahil olmak üzere tanımlamak ve açıklamak.
- MCP güvenlik riskleri için sağlam kimlik doğrulama, en az ayrıcalık, güvenli token yönetimi ve tedarik zinciri doğrulaması gibi etkili azaltıcı kontrolleri tanımlamak ve uygulamak.
- MCP ve yapay zeka iş yüklerini korumak için Prompt Shields, Azure Content Safety ve GitHub Advanced Security gibi Microsoft çözümlerini anlamak ve kullanmak.
- Araç meta verilerinin doğrulanmasının, dinamik değişikliklerin izlenmesinin ve dolaylı prompt enjeksiyonu saldırılarına karşı savunmanın önemini kavramak.
- Güvenli kodlama, sunucu sertleştirme ve sıfır güven mimarisi gibi yerleşik güvenlik en iyi uygulamalarını MCP uygulamanıza entegre ederek güvenlik ihlallerinin olasılığını ve etkisini azaltmak.

# MCP güvenlik kontrolleri

Önemli kaynaklara erişimi olan her sistemin dolaylı güvenlik zorlukları vardır. Güvenlik zorlukları genellikle temel güvenlik kontrolleri ve kavramlarının doğru uygulanmasıyla ele alınabilir. MCP henüz yeni tanımlandığı için, spesifikasyon hızla değişmekte ve protokol geliştikçe güvenlik kontrolleri olgunlaşacaktır. Sonunda, bu kontroller kurumsal ve yerleşik güvenlik mimarileri ve en iyi uygulamalarla daha iyi entegrasyon sağlayacaktır.

[Microsoft Digital Defense Report](https://aka.ms/mddr) raporunda yayımlanan araştırmaya göre, bildirilen ihlallerin %98’i sağlam güvenlik hijyeni ile önlenebilir ve herhangi bir ihlale karşı en iyi koruma, temel güvenlik hijyeninizi, güvenli kodlama en iyi uygulamalarını ve tedarik zinciri güvenliğini doğru yapmaktır — zaten bildiğimiz bu denenmiş ve test edilmiş uygulamalar güvenlik riskini azaltmada en büyük etkiye sahiptir.

MCP’yi benimserken güvenlik risklerini ele almaya başlayabileceğiniz bazı yolları inceleyelim.

> **Not:** Aşağıdaki bilgiler **29 Mayıs 2025** tarihi itibarıyla doğrudur. MCP protokolü sürekli gelişmektedir ve gelecekteki uygulamalar yeni kimlik doğrulama desenleri ve kontroller getirebilir. En güncel bilgiler ve rehberlik için her zaman [MCP Spesifikasyonu](https://spec.modelcontextprotocol.io/), resmi [MCP GitHub deposu](https://github.com/modelcontextprotocol) ve [güvenlik en iyi uygulama sayfası](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices) kaynaklarına başvurun.

### Sorun Tanımı  
Orijinal MCP spesifikasyonu, geliştiricilerin kendi kimlik doğrulama sunucularını yazacaklarını varsaydı. Bu, OAuth ve ilgili güvenlik kısıtlamaları hakkında bilgi gerektiriyordu. MCP sunucuları, kullanıcı kimlik doğrulamasını doğrudan yöneten OAuth 2.0 Yetkilendirme Sunucuları olarak hareket etti; Microsoft Entra ID gibi harici bir hizmete devretmediler. **26 Nisan 2025** itibarıyla MCP spesifikasyonundaki bir güncelleme, MCP sunucularının kullanıcı kimlik doğrulamasını harici bir hizmete devretmesine izin vermektedir.

### Riskler
- MCP sunucusundaki yanlış yapılandırılmış yetkilendirme mantığı, hassas verilerin açığa çıkmasına ve yanlış uygulanmış erişim kontrollerine yol açabilir.
- Yerel MCP sunucusunda OAuth token hırsızlığı. Token çalınırsa, MCP sunucusunu taklit etmek ve token’ın ait olduğu hizmetten kaynaklara ve verilere erişmek için kullanılabilir.

#### Token Geçişi
Token geçişi, yetkilendirme spesifikasyonunda açıkça yasaktır çünkü şu güvenlik risklerini beraberinde getirir:

#### Güvenlik Kontrolü Atlatma
MCP Sunucusu veya alt API’ler, token hedef kitlesi veya diğer kimlik bilgisi kısıtlamalarına bağlı olarak hız sınırlaması, istek doğrulama veya trafik izleme gibi önemli güvenlik kontrolleri uygulayabilir. İstemciler, MCP sunucusunun tokenları doğru şekilde doğrulamadan veya tokenların doğru hizmet için verildiğinden emin olmadan doğrudan alt API’lerle token kullanabilirse, bu kontroller atlanır.

#### Hesap Verebilirlik ve Denetim Sorunları
MCP Sunucusu, istemciler yukarı akışta verilen erişim tokenı ile çağrı yaptığında MCP İstemcilerini tanımlayamaz veya ayırt edemez; bu token MCP Sunucusu için opak olabilir.  
Alt Kaynak Sunucusunun günlükleri, tokenları ileten MCP sunucusu yerine farklı bir kaynaktan ve farklı bir kimlikle gelen istekler olarak görünebilir.  
Her iki faktör de olay incelemesini, kontrolleri ve denetimi zorlaştırır.  
MCP Sunucusu, tokenların iddialarını (örneğin roller, ayrıcalıklar veya hedef kitle) veya diğer meta verileri doğrulamadan tokenları geçirirse, çalınmış tokena sahip kötü niyetli bir aktör sunucuyu veri sızıntısı için vekil olarak kullanabilir.

#### Güven Sınırı Sorunları
Alt Kaynak Sunucusu belirli varlıklara güven verir. Bu güven, köken veya istemci davranış kalıpları hakkında varsayımları içerebilir. Bu güven sınırının kırılması beklenmeyen sorunlara yol açabilir.  
Token, uygun doğrulama olmadan birden fazla hizmet tarafından kabul edilirse, bir hizmeti ele geçiren saldırgan tokenı diğer bağlı hizmetlere erişmek için kullanabilir.

#### Gelecekte Uyumluluk Riski
Bugün MCP Sunucusu “saf bir vekil” olarak başlasa bile, ileride güvenlik kontrolleri eklemesi gerekebilir. Doğru token hedef kitle ayrımıyla başlamak, güvenlik modelinin gelişmesini kolaylaştırır.

### Azaltıcı Kontroller

**MCP sunucuları, açıkça MCP sunucusu için verilmemiş tokenları kabul ETMEMELİDİR**

- **Yetkilendirme Mantığını Gözden Geçirin ve Sertleştirin:** MCP sunucunuzun yetkilendirme uygulamasını dikkatlice denetleyin; yalnızca amaçlanan kullanıcılar ve istemcilerin hassas kaynaklara erişebildiğinden emin olun. Pratik rehberlik için [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ve [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/) kaynaklarına bakabilirsiniz.
- **Güvenli Token Uygulamalarını Zorunlu Kılın:** Erişim tokenlarının kötüye kullanımını önlemek ve token tekrar oynatma veya hırsızlık riskini azaltmak için [Microsoft’un token doğrulama ve ömür süresi en iyi uygulamalarını](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) takip edin.
- **Token Depolamayı Koruyun:** Tokenları her zaman güvenli şekilde depolayın ve hem dinlenme hem de iletim sırasında şifreleme kullanın. Uygulama ipuçları için [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) videosuna göz atabilirsiniz.

# MCP sunucuları için aşırı izinler

### Sorun Tanımı  
MCP sunucularına eriştikleri hizmet/kaynak üzerinde aşırı izinler verilmiş olabilir. Örneğin, bir AI satış uygulamasının parçası olan bir MCP sunucusu, kurumsal veri deposuna bağlanıyorsa, yalnızca satış verilerine erişim izni olmalı, depodaki tüm dosyalara erişim hakkı olmamalıdır. En az ayrıcalık ilkesi (en eski güvenlik ilkelerinden biri) gereği, hiçbir kaynak, yürütmesi gereken görevler için gerekli olandan fazla izin almamalıdır. AI bu alanda esnek olabilmesi için gereken izinlerin tam olarak tanımlanması zor olduğundan ekstra zorluk yaratır.

### Riskler  
- Aşırı izin verilmesi, MCP sunucusunun erişmemesi gereken verilerin sızdırılmasına veya değiştirilmesine izin verebilir. Bu, veriler kişisel tanımlayıcı bilgi (PII) ise gizlilik sorunu da oluşturabilir.

### Azaltıcı Kontroller  
- **En Az Ayrıcalık İlkesini Uygulayın:** MCP sunucusuna yalnızca gerekli görevleri yerine getirmesi için minimum izinleri verin. Bu izinleri düzenli olarak gözden geçirin ve ihtiyaçtan fazla olmadığından emin olun. Detaylı rehberlik için [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) sayfasına bakabilirsiniz.
- **Rol Tabanlı Erişim Kontrolü (RBAC) Kullanın:** MCP sunucusuna, belirli kaynaklar ve işlemlerle sıkı şekilde sınırlandırılmış roller atayın; geniş veya gereksiz izinlerden kaçının.
- **İzinleri İzleyin ve Denetleyin:** İzin kullanımını sürekli izleyin ve erişim günlüklerini denetleyerek aşırı veya kullanılmayan ayrıcalıkları hızlıca tespit edip düzeltin.

# Dolaylı prompt enjeksiyonu saldırıları

### Sorun Tanımı

Kötü niyetli veya ele geçirilmiş MCP sunucuları, müşteri verilerini açığa çıkararak veya istenmeyen işlemleri mümkün kılarak önemli riskler oluşturabilir. Bu riskler özellikle AI ve MCP tabanlı iş yüklerinde geçerlidir:

- **Prompt Enjeksiyonu Saldırıları:** Saldırganlar, yapay zeka sisteminin istenmeyen işlemler yapmasına veya hassas verileri sızdırmasına neden olan kötü niyetli talimatları promptlara veya dış içeriklere gömer. Daha fazla bilgi: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Araç Zehirlenmesi:** Saldırganlar, AI davranışını etkilemek için araç meta verilerini (örneğin açıklamalar veya parametreler) manipüle eder; bu, güvenlik kontrollerini atlatmaya veya veri sızdırmaya yol açabilir. Detaylar: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Çapraz Alan Prompt Enjeksiyonu:** Kötü niyetli talimatlar, belgeler, web sayfaları veya e-postalara gömülür ve AI tarafından işlenerek veri sızıntısı veya manipülasyona neden olur.
- **Dinamik Araç Değişikliği (Rug Pulls):** Araç tanımları, kullanıcı onayından sonra değiştirilebilir ve kullanıcı farkında olmadan yeni kötü niyetli davranışlar eklenebilir.

Bu zayıflıklar, MCP sunucuları ve araçlarını ortamınıza entegre ederken sağlam doğrulama, izleme ve güvenlik kontrollerine ihtiyaç olduğunu gösterir. Daha derin bilgi için yukarıdaki bağlantılara bakabilirsiniz.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.tr.png)

**Dolaylı Prompt Enjeksiyonu** (diğer adıyla çapraz alan prompt enjeksiyonu veya XPIA), Model Context Protocol (MCP) kullananlar da dahil olmak üzere üretken yapay zeka sistemlerinde kritik bir zafiyettir. Bu saldırıda, kötü niyetli talimatlar dış içeriklere—belgeler, web sayfaları veya e-postalar gibi—gizlenir. AI sistemi bu içeriği işlerken, gömülü talimatları meşru kullanıcı komutları olarak yorumlayabilir ve veri sızıntısı, zararlı içerik üretimi veya kullanıcı etkileşimlerinin manipülasyonu gibi istenmeyen sonuçlar doğurabilir. Ayrıntılı açıklama ve gerçek dünya örnekleri için [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/) sayfasına bakabilirsiniz.

Bu saldırının özellikle tehlikeli bir türü **Araç Zehirlenmesi**dir. Burada saldırganlar, MCP araçlarının meta verilerine (örneğin araç açıklamaları veya parametreleri) kötü niyetli talimatlar enjekte eder. Büyük dil modelleri (LLM’ler) hangi araçları çağıracaklarına karar verirken bu meta verilere güvendiğinden, manipüle edilmiş açıklamalar modeli yetkisiz araç çağrılarını gerçekleştirmeye veya güvenlik kontrollerini atlamaya ikna edebilir. Bu manipülasyonlar genellikle son kullanıcılar tarafından görünmez, ancak AI sistemi tarafından yorumlanır ve uygulanır. Bu risk, araç tanımlarının kullanıcı onayından sonra değiştirilebildiği barındırılan MCP sunucu ortamlarında daha da artar; bu durum bazen "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" olarak adlandırılır. Böyle durumlarda, önceden güvenli olan bir araç daha sonra kullanıcı haberi olmadan veri sızdırma veya sistem davranışını değiştirme gibi kötü niyetli işlemler yapmak üzere değiştirilebilir. Bu saldırı vektörü hakkında daha fazla bilgi için [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks) sayfasına bakabilirsiniz.

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.tr.png)

## Riskler  
İstenmeyen AI işlemleri, veri sızıntısı ve gizlilik ihlalleri gibi çeşitli güvenlik riskleri taşır.

### Azaltıcı Kontroller  
### Dolaylı Prompt Enjeksiyonu saldırılarına karşı koruma için prompt shields kullanımı
-----------------------------------------------------------------------------

**AI Prompt Shields**, Microsoft tarafından doğrudan ve dolaylı prompt enjeksiyonu saldırılarına karşı geliştirilmiş bir çözümdür. Şu yollarla yardımcı olur:

1.  **Tespit ve Filtreleme:** Prompt Shields, belgeler, web sayfaları veya e-postalar gibi dış içeriklere gömülü kötü niyetli talimatları tespit etmek ve filtrelemek için gelişmiş makine öğrenimi algoritmaları ve doğal dil işleme kullanır.
    
2.  **Spotlighting:** Bu teknik, AI sisteminin geçerli sistem talimatları ile potansiyel olarak güvenilmez dış girdileri ayırt etmesine yardımcı olur. Girdi metnini modele daha alakalı hale getirecek şekilde dönüştürerek, Spotlighting AI’nın kötü niyetli talimatları daha iyi tanımasını ve görmezden gelmesini sağlar.
    
3.  **Sınırlandırıcılar ve Veri İşaretleme:** Sistem mesajına eklenen sınırlandırıcılar, girdi metninin yerini açıkça belirtir ve AI sisteminin kullanıcı girdilerini potansiyel zararlı dış içerikten ayırmasını sağlar. Veri işaretleme, güvenilir ve güvenilmez verilerin sınırlarını vurgulamak için özel işaretler kullanarak bu kavramı genişletir.
    
4.  **Sürekli İzleme ve Güncellemeler:** Microsoft, Prompt Shields’i yeni ve gelişen tehditlere karşı sürekli izler ve günceller. Bu proaktif yaklaşım, savunmaların en son saldırı tekniklerine karşı etkili kalmasını sağlar.
    
5. **Azure Content Safety ile Entegrasyon:** Prompt Shields, Azure AI Content Safety paketinin bir parçasıdır ve AI uygulamalarında jailbreak girişimleri, zararlı içerik ve diğer güvenlik risklerini tespit etmek için ek araçlar sunar.

AI prompt shields hakkında daha fazla bilgi için [Prompt Shields dokümantasyonuna](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) bakabilirsiniz.

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.tr.png)

### Tedarik zinciri güvenliği
Tedarik zinciri güvenliği, yapay zeka çağında temel olmaya devam ediyor, ancak tedarik zincirinizin kapsamı genişledi. Geleneksel kod paketlerine ek olarak, artık temel modeller, gömme servisleri, bağlam sağlayıcıları ve üçüncü taraf API’ler dahil olmak üzere tüm yapay zeka ile ilgili bileşenleri titizlikle doğrulamanız ve izlemeniz gerekiyor. Bunların her biri, doğru yönetilmezse güvenlik açıkları veya riskler oluşturabilir.

**Yapay zeka ve MCP için temel tedarik zinciri güvenliği uygulamaları:**
- **Tüm bileşenleri entegrasyondan önce doğrulayın:** Bu sadece açık kaynak kütüphanelerle sınırlı değil, aynı zamanda yapay zeka modelleri, veri kaynakları ve dış API’leri de kapsar. Her zaman köken, lisanslama ve bilinen güvenlik açıklarını kontrol edin.
- **Güvenli dağıtım hatları oluşturun:** Sorunları erken tespit etmek için entegre güvenlik taraması içeren otomatik CI/CD hatları kullanın. Üretime yalnızca güvenilir artefaktların dağıtıldığından emin olun.
- **Sürekli izleme ve denetim yapın:** Modeller ve veri servisleri dahil tüm bağımlılıklar için sürekli izleme uygulayarak yeni güvenlik açıkları veya tedarik zinciri saldırılarını tespit edin.
- **En az ayrıcalık ve erişim kontrolleri uygulayın:** MCP sunucunuzun çalışması için gerekli olan modeller, veriler ve servislere erişimi sınırlandırın.
- **Tehditlere hızlı yanıt verin:** İhlal tespit edilirse, zarar görmüş bileşenlerin yamalanması veya değiştirilmesi ve gizli anahtarların ya da kimlik bilgilerinin yenilenmesi için bir süreç oluşturun.

[GitHub Advanced Security](https://github.com/security/advanced-security), gizli anahtar taraması, bağımlılık taraması ve CodeQL analizi gibi özellikler sunar. Bu araçlar, ekiplerin hem kod hem de yapay zeka tedarik zinciri bileşenlerindeki güvenlik açıklarını tespit edip azaltmalarına yardımcı olmak için [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) ve [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) ile entegre olur.

Microsoft ayrıca tüm ürünleri için kapsamlı tedarik zinciri güvenliği uygulamalarını dahili olarak uygular. Daha fazlasını [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/) adresinde öğrenebilirsiniz.


# MCP uygulamanızın güvenlik duruşunu güçlendirecek yerleşik güvenlik en iyi uygulamaları

Her MCP uygulaması, üzerine inşa edildiği kuruluş ortamının mevcut güvenlik duruşunu devralır; bu nedenle MCP’yi genel yapay zeka sistemlerinizin bir bileşeni olarak değerlendirirken, mevcut genel güvenlik duruşunuzu güçlendirmeyi düşünmeniz önerilir. Aşağıdaki yerleşik güvenlik kontrolleri özellikle önemlidir:

- Yapay zeka uygulamanızda güvenli kodlama en iyi uygulamaları — [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559) gibi tehditlere karşı koruma, gizli anahtarlar ve tokenlar için güvenli kasalar kullanımı, tüm uygulama bileşenleri arasında uçtan uca güvenli iletişim sağlanması vb.
- Sunucu sertleştirme — mümkün olduğunda MFA kullanımı, yamaların güncel tutulması, erişim için sunucunun üçüncü taraf kimlik sağlayıcı ile entegrasyonu vb.
- Cihazlar, altyapı ve uygulamaların yamalarla güncel tutulması
- Güvenlik izleme — yapay zeka uygulamasının (MCP istemci/sunucuları dahil) günlüklerinin toplanması ve merkezi bir SIEM’e gönderilerek anormal aktivitelerin tespiti
- Sıfır güven mimarisi — yapay zeka uygulaması ele geçirilse bile yatay hareketi en aza indirmek için bileşenlerin ağ ve kimlik kontrolleriyle mantıksal olarak izole edilmesi.

# Önemli Noktalar

- Güvenlik temelleri kritik olmaya devam ediyor: Güvenli kodlama, en az ayrıcalık, tedarik zinciri doğrulaması ve sürekli izleme MCP ve yapay zeka iş yükleri için vazgeçilmezdir.
- MCP, prompt enjeksiyonu, araç zehirlenmesi ve aşırı izinler gibi hem geleneksel hem de yapay zekaya özgü kontroller gerektiren yeni riskler getirir.
- Güçlü kimlik doğrulama, yetkilendirme ve token yönetimi uygulayın; mümkünse Microsoft Entra ID gibi dış kimlik sağlayıcılarını kullanın.
- Dolaylı prompt enjeksiyonu ve araç zehirlenmesine karşı, araç meta verilerini doğrulayarak, dinamik değişiklikleri izleyerek ve Microsoft Prompt Shields gibi çözümler kullanarak koruma sağlayın.
- Yapay zeka tedarik zincirinizdeki tüm bileşenlere — modeller, gömme servisleri ve bağlam sağlayıcılar dahil — kod bağımlılıkları kadar titizlikle yaklaşın.
- Gelişen MCP spesifikasyonlarını takip edin ve güvenli standartların şekillenmesine katkıda bulunun.

# Ek Kaynaklar

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Sonraki

Sonraki: [Bölüm 3: Başlarken](../03-GettingStarted/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.