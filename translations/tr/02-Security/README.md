<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T01:33:01+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "tr"
}
-->
# Güvenlik En İyi Uygulamaları

Model Context Protocol (MCP) kullanmak, yapay zeka destekli uygulamalara güçlü yeni yetenekler kazandırırken, geleneksel yazılım risklerinin ötesine geçen benzersiz güvenlik zorluklarını da beraberinde getirir. Güvenli kodlama, en az ayrıcalık ve tedarik zinciri güvenliği gibi yerleşik endişelerin yanı sıra, MCP ve yapay zeka iş yükleri; prompt enjeksiyonu, araç zehirlenmesi, dinamik araç değişikliği, oturum kaçırma, confused deputy saldırıları ve token geçişi açıkları gibi yeni tehditlerle karşı karşıyadır. Bu riskler uygun şekilde yönetilmezse veri sızıntısı, gizlilik ihlalleri ve istenmeyen sistem davranışlarına yol açabilir.

Bu ders, MCP ile ilişkili en önemli güvenlik risklerini—kimlik doğrulama, yetkilendirme, aşırı izinler, dolaylı prompt enjeksiyonu, oturum güvenliği, confused deputy sorunları, token geçişi açıkları ve tedarik zinciri açıkları dahil—inceler ve bunları azaltmak için uygulanabilir kontroller ve en iyi uygulamalar sunar. Ayrıca, MCP uygulamanızı güçlendirmek için Microsoft çözümleri olan Prompt Shields, Azure Content Safety ve GitHub Advanced Security gibi araçları nasıl kullanacağınızı öğreneceksiniz. Bu kontrolleri anlayıp uygulayarak, güvenlik ihlali olasılığını önemli ölçüde azaltabilir ve yapay zeka sistemlerinizin sağlam ve güvenilir kalmasını sağlayabilirsiniz.

# Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Model Context Protocol (MCP) tarafından getirilen benzersiz güvenlik risklerini tanımlamak ve açıklamak; bunlar arasında prompt enjeksiyonu, araç zehirlenmesi, aşırı izinler, oturum kaçırma, confused deputy sorunları, token geçişi açıkları ve tedarik zinciri açıkları yer alır.
- MCP güvenlik riskleri için etkili azaltıcı kontrolleri tanımlamak ve uygulamak; bunlar arasında sağlam kimlik doğrulama, en az ayrıcalık, güvenli token yönetimi, oturum güvenliği kontrolleri ve tedarik zinciri doğrulaması bulunur.
- MCP ve yapay zeka iş yüklerini korumak için Microsoft çözümleri olan Prompt Shields, Azure Content Safety ve GitHub Advanced Security’yi anlamak ve kullanmak.
- Araç meta verilerinin doğrulanmasının, dinamik değişikliklerin izlenmesinin, dolaylı prompt enjeksiyonu saldırılarına karşı savunmanın ve oturum kaçırmanın önlenmesinin önemini kavramak.
- MCP uygulamanıza güvenli kodlama, sunucu sertleştirme ve sıfır güven mimarisi gibi yerleşik güvenlik en iyi uygulamalarını entegre ederek güvenlik ihlallerinin olasılığını ve etkisini azaltmak.

# MCP güvenlik kontrolleri

Önemli kaynaklara erişimi olan her sistemin dolaylı güvenlik zorlukları vardır. Güvenlik zorlukları genellikle temel güvenlik kontrolleri ve kavramlarının doğru uygulanmasıyla ele alınabilir. MCP henüz yeni tanımlandığı için, spesifikasyon hızla değişmekte ve protokol geliştikçe evrimleşmektedir. Sonunda içindeki güvenlik kontrolleri olgunlaşacak ve kurumsal ve yerleşik güvenlik mimarileri ile en iyi uygulamalarla daha iyi entegrasyon sağlanacaktır.

[Microsoft Digital Defense Report](https://aka.ms/mddr) raporunda yayımlanan araştırmaya göre, bildirilen ihlallerin %98’i sağlam güvenlik hijyeni ile önlenebilir. Herhangi bir ihlale karşı en iyi koruma, temel güvenlik hijyeninizi, güvenli kodlama en iyi uygulamalarını ve tedarik zinciri güvenliğini doğru yapmaktır — zaten bildiğimiz ve test edilmiş bu uygulamalar güvenlik riskini azaltmada en büyük etkiye sahiptir.

MCP’yi benimserken güvenlik risklerini ele almaya başlayabileceğiniz bazı yolları inceleyelim.

> **Note:** Aşağıdaki bilgiler **29 Mayıs 2025** tarihi itibarıyla doğrudur. MCP protokolü sürekli gelişmektedir ve gelecekteki uygulamalar yeni kimlik doğrulama desenleri ve kontrolleri getirebilir. En güncel bilgiler ve rehberlik için her zaman [MCP Specification](https://spec.modelcontextprotocol.io/), resmi [MCP GitHub deposu](https://github.com/modelcontextprotocol) ve [güvenlik en iyi uygulama sayfası](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices) kaynaklarına başvurun.

### Sorun tanımı  
Orijinal MCP spesifikasyonu, geliştiricilerin kendi kimlik doğrulama sunucularını yazacaklarını varsaydı. Bu, OAuth ve ilgili güvenlik kısıtlamaları hakkında bilgi gerektiriyordu. MCP sunucuları, kullanıcı kimlik doğrulamasını doğrudan yöneten OAuth 2.0 Yetkilendirme Sunucuları olarak hareket etti; bu işlem Microsoft Entra ID gibi harici bir hizmete devredilmedi. **26 Nisan 2025** itibarıyla MCP spesifikasyonundaki bir güncelleme, MCP sunucularının kullanıcı kimlik doğrulamasını harici bir hizmete devretmesine izin vermektedir.

### Riskler
- MCP sunucusundaki yanlış yapılandırılmış yetkilendirme mantığı, hassas verilerin açığa çıkmasına ve yanlış uygulanmış erişim kontrollerine yol açabilir.
- Yerel MCP sunucusunda OAuth token hırsızlığı. Token çalınırsa, MCP sunucusunu taklit etmek ve OAuth token’ının ait olduğu hizmetten kaynaklara ve verilere erişmek için kullanılabilir.

#### Token Geçişi
Token geçişi, yetkilendirme spesifikasyonunda açıkça yasaklanmıştır çünkü bir dizi güvenlik riskini beraberinde getirir:

#### Güvenlik Kontrolü Atlatma
MCP Sunucusu veya alt API’ler, token hedef kitlesi veya diğer kimlik bilgisi kısıtlamalarına bağlı olarak rate limiting, istek doğrulama veya trafik izleme gibi önemli güvenlik kontrolleri uygulayabilir. İstemciler, MCP sunucusunun tokenları doğru şekilde doğrulamadan veya tokenların doğru hizmet için verildiğinden emin olmadan doğrudan alt API’lerle token kullanabilirse, bu kontroller atlanır.

#### Hesap Verebilirlik ve Denetim Sorunları
MCP Sunucusu, istemciler yukarı akışta verilen ve MCP Sunucusu için opak olabilecek erişim tokenlarıyla çağrı yaptığında MCP İstemcilerini tanımlayamaz veya ayırt edemez.  
Alt Kaynak Sunucusunun günlükleri, tokenları gerçekten ileten MCP sunucusu yerine farklı bir kaynaktan ve farklı bir kimlikten geliyormuş gibi görünen istekleri gösterebilir.  
Her iki faktör de olay incelemesini, kontrolleri ve denetimi zorlaştırır.  
MCP Sunucusu, tokenların iddialarını (örneğin roller, ayrıcalıklar veya hedef kitle) veya diğer meta verileri doğrulamadan tokenları geçirirse, çalınmış bir tokena sahip kötü niyetli bir aktör sunucuyu veri sızıntısı için vekil olarak kullanabilir.

#### Güven Sınırı Sorunları
Alt Kaynak Sunucusu belirli varlıklara güven verir. Bu güven, köken veya istemci davranış kalıpları hakkında varsayımları içerebilir. Bu güven sınırının kırılması beklenmeyen sorunlara yol açabilir.  
Token, uygun doğrulama olmadan birden fazla hizmet tarafından kabul edilirse, bir hizmeti ele geçiren saldırgan tokenı diğer bağlı hizmetlere erişmek için kullanabilir.

#### Gelecekte Uyumluluk Riski
Bugün MCP Sunucusu "saf bir vekil" olarak başlasa bile, ileride güvenlik kontrolleri eklemesi gerekebilir. Doğru token hedef kitle ayrımıyla başlamak, güvenlik modelinin gelişmesini kolaylaştırır.

### Azaltıcı kontroller

**MCP sunucuları, açıkça MCP sunucusu için verilmemiş herhangi bir tokenı kabul ETMEMELİDİR**

- **Yetkilendirme Mantığını Gözden Geçirin ve Sertleştirin:** MCP sunucunuzun yetkilendirme uygulamasını dikkatlice denetleyin; yalnızca amaçlanan kullanıcılar ve istemcilerin hassas kaynaklara erişebildiğinden emin olun. Pratik rehberlik için [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ve [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/) kaynaklarına bakabilirsiniz.
- **Güvenli Token Uygulamalarını Zorunlu Kılın:** Erişim tokenlarının kötüye kullanımını önlemek ve token tekrar oynatma veya hırsızlık riskini azaltmak için [Microsoft’un token doğrulama ve ömrü ile ilgili en iyi uygulamalarını](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) takip edin.
- **Token Depolamayı Koruyun:** Tokenları her zaman güvenli şekilde depolayın ve hem dinlenme hem de iletim sırasında şifreleme kullanın. Uygulama ipuçları için [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) videosuna göz atabilirsiniz.

# MCP sunucuları için aşırı izinler

### Sorun tanımı  
MCP sunucularına eriştikleri hizmet/kaynaç için aşırı izinler verilmiş olabilir. Örneğin, bir AI satış uygulamasının parçası olan ve kurumsal veri deposuna bağlanan bir MCP sunucusu, yalnızca satış verilerine erişim izni almalı, depodaki tüm dosyalara erişim hakkı olmamalıdır. En az ayrıcalık ilkesi (en eski güvenlik ilkelerinden biri) gereği, hiçbir kaynak, kendisinden beklenen görevleri yerine getirmek için gereken izinlerin üzerinde izinlere sahip olmamalıdır. AI bu alanda esnek olabilmesi için gereken kesin izinleri tanımlamak zor olduğundan ekstra zorluk yaratır.

### Riskler  
- Aşırı izin verilmesi, MCP sunucusunun erişmemesi gereken verilerin sızdırılmasına veya değiştirilmesine izin verebilir. Bu, veriler kişisel tanımlayıcı bilgi (PII) ise gizlilik sorunu da oluşturabilir.

### Azaltıcı kontroller  
- **En Az Ayrıcalık İlkesini Uygulayın:** MCP sunucusuna yalnızca gerekli görevleri yerine getirmek için minimum izinleri verin. Bu izinleri düzenli olarak gözden geçirin ve güncelleyin, böylece gereğinden fazla izin verilmemiş olsun. Detaylı rehberlik için [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) sayfasına bakabilirsiniz.
- **Rol Tabanlı Erişim Kontrolü (RBAC) Kullanın:** MCP sunucusuna, belirli kaynaklar ve işlemlerle sıkı şekilde sınırlandırılmış roller atayın; geniş veya gereksiz izinlerden kaçının.
- **İzinleri İzleyin ve Denetleyin:** İzin kullanımını sürekli izleyin ve erişim günlüklerini denetleyerek aşırı veya kullanılmayan ayrıcalıkları hızlıca tespit edip düzeltin.

# Dolaylı prompt enjeksiyonu saldırıları

### Sorun tanımı

Kötü niyetli veya ele geçirilmiş MCP sunucuları, müşteri verilerini açığa çıkararak veya istenmeyen işlemleri mümkün kılarak önemli riskler oluşturabilir. Bu riskler özellikle AI ve MCP tabanlı iş yüklerinde geçerlidir:

- **Prompt Enjeksiyonu Saldırıları:** Saldırganlar, promptlara veya dış içeriklere kötü niyetli talimatlar gömer; bu da AI sisteminin istenmeyen işlemler yapmasına veya hassas verileri sızdırmasına neden olur. Daha fazla bilgi: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Araç Zehirlenmesi:** Saldırganlar, AI davranışını etkilemek için araç meta verilerini (örneğin açıklamalar veya parametreler) manipüle eder; bu, güvenlik kontrollerini atlatmaya veya veri sızdırmaya yol açabilir. Detaylar: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Çapraz Alan Prompt Enjeksiyonu:** Kötü niyetli talimatlar, belgeler, web sayfaları veya e-postalar içine gömülür ve AI tarafından işlenerek veri sızıntısı veya manipülasyona neden olur.
- **Dinamik Araç Değişikliği (Rug Pulls):** Araç tanımları, kullanıcı onayından sonra değiştirilebilir; bu da kullanıcının haberi olmadan yeni kötü niyetli davranışların ortaya çıkmasına yol açar.

Bu açıklar, MCP sunucuları ve araçlarını ortamınıza entegre ederken sağlam doğrulama, izleme ve güvenlik kontrollerine ihtiyaç olduğunu gösterir. Daha derin bilgi için yukarıdaki bağlantılara bakabilirsiniz.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.tr.png)

**Dolaylı Prompt Enjeksiyonu** (diğer adıyla çapraz alan prompt enjeksiyonu veya XPIA), Model Context Protocol (MCP) kullanan jeneratif AI sistemlerinde kritik bir güvenlik açığıdır. Bu saldırıda, kötü niyetli talimatlar dış içeriklerin içine gizlenir—örneğin belgeler, web sayfaları veya e-postalar. AI sistemi bu içeriği işlediğinde, gömülü talimatları meşru kullanıcı komutları olarak yorumlayabilir ve veri sızıntısı, zararlı içerik üretimi veya kullanıcı etkileşimlerinin manipülasyonu gibi istenmeyen sonuçlar doğurabilir. Ayrıntılı açıklama ve gerçek dünya örnekleri için [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/) kaynağına bakabilirsiniz.

Bu saldırının özellikle tehlikeli bir türü **Araç Zehirlenmesi**dir. Burada saldırganlar, MCP araçlarının meta verilerine (örneğin araç açıklamaları veya parametreleri) kötü niyetli talimatlar enjekte eder. Büyük dil modelleri (LLM’ler) hangi araçları çağıracaklarına karar verirken bu meta verilere güvendiğinden, manipüle edilmiş açıklamalar modeli yetkisiz araç çağrılarını yapmaya veya güvenlik kontrollerini atlamaya yönlendirebilir. Bu manipülasyonlar genellikle son kullanıcılar tarafından görünmez, ancak AI sistemi tarafından yorumlanıp uygulanabilir. Bu risk, kullanıcı onayından sonra araç tanımlarının değiştirilebildiği barındırılan MCP sunucu ortamlarında daha da artar; bu durum bazen "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" olarak adlandırılır. Böyle durumlarda, önceden güvenli olan bir araç daha sonra kullanıcının haberi olmadan veri sızdırma veya sistem davranışını değiştirme gibi kötü niyetli işlemler yapmak üzere değiştirilebilir. Bu saldırı vektörü hakkında daha fazla bilgi için [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks) kaynağına bakabilirsiniz.

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.tr.png)

## Riskler  
İstenmeyen AI işlemleri, veri sızıntısı ve gizlilik ihlalleri gibi çeşitli güvenlik riskleri taşır.

### Azaltıcı kontroller  
### Dolaylı Prompt Enjeksiyonu saldırılarına karşı koruma için prompt shields kullanımı
-----------------------------------------------------------------------------

**AI Prompt Shields**, Microsoft tarafından doğrudan ve dolaylı prompt enjeksiyonu saldırılarına karşı koruma sağlamak için geliştirilmiş bir çözümdür. Aşağıdaki yollarla yardımcı olur:

1.  **Tespit ve Filtreleme:** Prompt Shields, gelişmiş makine öğrenimi algoritmaları ve doğal dil işleme teknikleri kullanarak belgeler, web sayfaları veya e-postalar gibi dış içeriklere gömülü kötü niyetli talimatları tespit eder ve filtreler.
    
2.  **Spotlighting:** Bu teknik, AI sisteminin geçerli sistem talimatları ile potansiyel olarak güvenilmez dış girdiler arasındaki farkı ayırt etmesine yardımcı olur. Girdi metnini modele daha alakalı hale getirecek şekilde dönüştürerek, Spotlighting AI’nın kötü niyetli talimatları daha iyi tanımasını ve görmezden gelmesini sağlar.
    
3.  **Sınırlandırıcılar ve Veri İşaretleme:** Sistem mesajına eklenen sınırlandırıcılar, girdi metninin yerini açıkça belirtir ve AI sisteminin kullanıcı girdilerini potansiyel olarak zararlı dış içerikten ayırmasını sağlar. Veri işaretleme, güvenilir ve güvenilmez verilerin sınırlarını vurgulamak için özel işaretler kullanarak bu kavramı genişletir.
    
4.  **Sürekli İzleme ve Güncellemeler:** Microsoft, Prompt Shields’i yeni ve gelişen tehditlere karşı sürekli izler ve günceller. Bu proaktif yaklaşım, savunmaların en son saldırı tekniklerine karşı etkili kalmasını sağlar.
    
5. **Azure Content Safety ile Entegrasyon:** Prompt Shields, Azure AI Content Safety paketinin bir parçasıdır ve AI uygulamalarında jailbreak denemeleri, zararlı içerik ve diğer güvenlik risklerini tespit etmek için ek araçlar sunar.

AI prompt shields hakkında daha fazla bilgi için [Prompt Shields dokümantasyonuna](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) bakabilirsiniz.

![prompt-shield-lg-204
Confused deputy problemi, bir MCP sunucusunun MCP istemcileri ile üçüncü taraf API'ler arasında vekil (proxy) olarak hareket ettiği durumlarda ortaya çıkan bir güvenlik açığıdır. Bu zafiyet, MCP sunucusunun üçüncü taraf yetkilendirme sunucusuyla dinamik istemci kaydı desteği olmayan statik bir istemci kimliği kullanarak kimlik doğrulaması yapması durumunda kötüye kullanılabilir.

### Riskler

- **Çerez tabanlı onay atlatma**: Kullanıcı daha önce MCP proxy sunucusu üzerinden kimlik doğrulaması yaptıysa, üçüncü taraf yetkilendirme sunucusu kullanıcının tarayıcısına bir onay çerezi koyabilir. Bir saldırgan, daha sonra kullanıcıya kötü amaçlı bir yönlendirme URI'si içeren kötü niyetli bir yetkilendirme isteğiyle hazırlanmış bir bağlantı göndererek bunu suistimal edebilir.
- **Yetkilendirme kodu hırsızlığı**: Kullanıcı kötü amaçlı bağlantıya tıkladığında, üçüncü taraf yetkilendirme sunucusu mevcut çerez nedeniyle onay ekranını atlayabilir ve yetkilendirme kodu saldırganın sunucusuna yönlendirilebilir.
- **Yetkisiz API erişimi**: Saldırgan, çalınan yetkilendirme kodunu erişim belirteçleriyle değiş tokuş ederek kullanıcıyı taklit edebilir ve üçüncü taraf API'ye açık onay olmadan erişebilir.

### Önleyici kontroller

- **Açık onay gereksinimleri**: Statik istemci kimlikleri kullanan MCP proxy sunucuları, üçüncü taraf yetkilendirme sunucularına iletmeden önce her dinamik olarak kaydedilen istemci için kullanıcı onayı **ALMALIDIR**.
- **Doğru OAuth uygulaması**: Yetkilendirme isteklerinde kod zorlama (PKCE) kullanımı dahil olmak üzere OAuth 2.1 güvenlik en iyi uygulamalarını takip edin, böylece yakalama saldırıları önlenir.
- **İstemci doğrulaması**: Kötü niyetli aktörlerin suistimalini önlemek için yönlendirme URI'ları ve istemci kimliklerinin sıkı doğrulamasını uygulayın.


# Token Passthrough Zafiyetleri

### Problem tanımı

"Token passthrough" (belirteç geçişi), bir MCP sunucusunun, MCP istemcisinden aldığı belirteçlerin kendisine doğru şekilde verilmiş olduğunu doğrulamadan kabul etmesi ve ardından bu belirteçleri alt API'lere "geçirmesi" anti-paternidir. Bu uygulama, MCP yetkilendirme spesifikasyonunu açıkça ihlal eder ve ciddi güvenlik riskleri doğurur.

### Riskler

- **Güvenlik kontrolü atlatma**: İstemciler, belirteçleri uygun doğrulama olmadan doğrudan alt API'lerle kullanabilirse, hız sınırlaması, istek doğrulaması veya trafik izleme gibi önemli güvenlik kontrollerini atlayabilirler.
- **Hesap verebilirlik ve denetim sorunları**: MCP sunucusu, istemciler yukarı akışta verilen erişim belirteçlerini kullandığında MCP istemcilerini tanımlamakta veya ayırt etmekte zorlanır, bu da olay incelemesi ve denetimi zorlaştırır.
- **Veri sızdırma**: Belirteçler uygun iddia doğrulaması olmadan geçerse, çalınan bir belirtece sahip kötü niyetli bir aktör, sunucuyu veri sızdırma için vekil olarak kullanabilir.
- **Güven sınırı ihlalleri**: Alt kaynak sunucuları, belirli varlıklara köken veya davranış kalıplarına dayalı güven verir. Bu güven sınırının kırılması beklenmeyen güvenlik sorunlarına yol açabilir.
- **Çoklu hizmet belirteci kötüye kullanımı**: Belirteçler uygun doğrulama olmadan birden fazla hizmet tarafından kabul edilirse, bir hizmeti ele geçiren saldırgan, belirteci diğer bağlı hizmetlere erişmek için kullanabilir.

### Önleyici kontroller

- **Belirteç doğrulama**: MCP sunucuları, kendileri için açıkça verilmemiş belirteçleri **KABUL ETMEMELİDİR**.
- **Hedef kitle doğrulaması**: Belirteçlerin MCP sunucusunun kimliğiyle eşleşen doğru hedef kitle (audience) iddiasına sahip olduğunu her zaman doğrulayın.
- **Doğru belirteç yaşam döngüsü yönetimi**: Belirteç hırsızlığı ve kötüye kullanım riskini azaltmak için kısa ömürlü erişim belirteçleri ve uygun belirteç döndürme uygulayın.


# Oturum Kaçırma

### Problem tanımı

Oturum kaçırma, bir istemciye sunucu tarafından verilen oturum kimliğinin yetkisiz bir tarafça ele geçirilip kullanılmasıyla, orijinal istemciyi taklit ederek yetkisiz işlemler yapılması saldırı vektörüdür. Bu durum, özellikle MCP isteklerini işleyen durum bilgisi tutan HTTP sunucularında endişe vericidir.

### Riskler

- **Oturum Kaçırma İstek Enjeksiyonu**: Oturum kimliğini ele geçiren saldırgan, istemcinin bağlı olduğu sunucuyla oturum durumunu paylaşan başka bir sunucuya kötü amaçlı olaylar gönderebilir; bu da zararlı işlemlere veya hassas verilere erişime yol açabilir.
- **Oturum Kaçırma Taklidi**: Çalınan oturum kimliğiyle saldırgan, kimlik doğrulamayı atlayarak doğrudan MCP sunucusuna çağrılar yapabilir ve meşru kullanıcı gibi işlem görebilir.
- **Tehlikeye Giren Devam Ettirilebilir Akışlar**: Sunucu yeniden teslimat/devam ettirilebilir akışları destekliyorsa, saldırgan isteği erken sonlandırabilir ve orijinal istemci tarafından daha sonra potansiyel olarak kötü amaçlı içerikle devam ettirilmesine neden olabilir.

### Önleyici kontroller

- **Yetkilendirme doğrulaması**: Yetkilendirme uygulayan MCP sunucuları, tüm gelen istekleri doğrulamalı ve kimlik doğrulama için oturum kullanmamalıdır.
- **Güvenli oturum kimlikleri**: MCP sunucuları, güvenli rastgele sayı üreteçleriyle oluşturulmuş, tahmin edilemez ve ardışık olmayan oturum kimlikleri kullanmalıdır.
- **Kullanıcıya özgü oturum bağlama**: MCP sunucuları, oturum kimliklerini yetkili kullanıcıya özgü bilgilerle (örneğin dahili kullanıcı kimliği) birleştirerek bağlamalıdır; örneğin `<user_id>:<session_id>` formatında.
- **Oturum süresi sonu**: Oturum kimliği ele geçirilirse risk penceresini sınırlamak için uygun oturum süresi sonu ve döndürme uygulayın.
- **İletim güvenliği**: Oturum kimliği yakalanmasını önlemek için tüm iletişimde her zaman HTTPS kullanın.


# Tedarik Zinciri Güvenliği

Tedarik zinciri güvenliği, yapay zeka çağında temel olmaya devam etmektedir, ancak tedarik zincirinizin kapsamı genişlemiştir. Geleneksel kod paketlerine ek olarak, temel modeller, gömme servisleri, bağlam sağlayıcıları ve üçüncü taraf API'ler dahil olmak üzere tüm AI ile ilgili bileşenleri titizlikle doğrulamanız ve izlemeniz gerekir. Bunların her biri uygun yönetilmezse zafiyet veya risk oluşturabilir.

**AI ve MCP için temel tedarik zinciri güvenliği uygulamaları:**
- **Tüm bileşenleri entegrasyondan önce doğrulayın:** Bu sadece açık kaynak kütüphaneleri değil, aynı zamanda AI modelleri, veri kaynakları ve dış API'leri de kapsar. Her zaman köken, lisanslama ve bilinen zafiyetleri kontrol edin.
- **Güvenli dağıtım hatları sürdürün:** Sorunları erken yakalamak için entegre güvenlik taraması içeren otomatik CI/CD hatları kullanın. Sadece güvenilir yapıtların üretime dağıtıldığından emin olun.
- **Sürekli izleme ve denetim yapın:** Modeller ve veri servisleri dahil tüm bağımlılıklar için sürekli izleme uygulayarak yeni zafiyetleri veya tedarik zinciri saldırılarını tespit edin.
- **Asgari ayrıcalık ve erişim kontrolleri uygulayın:** MCP sunucunuzun çalışması için gerekli olan modeller, veri ve servislere erişimi sınırlandırın.
- **Tehditlere hızlı yanıt verin:** İhlal tespit edilirse, tehlikeye giren bileşenleri yamalama veya değiştirme ve gizli bilgileri/dizinleri döndürme süreçlerine sahip olun.

[GitHub Advanced Security](https://github.com/security/advanced-security), gizli tarama, bağımlılık taraması ve CodeQL analizi gibi özellikler sunar. Bu araçlar, ekiplerin hem kod hem de AI tedarik zinciri bileşenlerindeki zafiyetleri tanımlayıp azaltmasına yardımcı olmak için [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) ve [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) ile entegre olur.

Microsoft ayrıca tüm ürünler için kapsamlı tedarik zinciri güvenliği uygulamalarını dahili olarak yürütmektedir. Daha fazla bilgi için [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/) sayfasını inceleyebilirsiniz.


# MCP uygulamanızın güvenlik duruşunu güçlendirecek yerleşik güvenlik en iyi uygulamaları

Her MCP uygulaması, üzerine inşa edildiği kuruluş ortamının mevcut güvenlik duruşunu devralır; bu nedenle MCP'yi genel AI sistemlerinizin bir bileşeni olarak değerlendirirken, mevcut genel güvenlik duruşunuzu güçlendirmeyi düşünmeniz önerilir. Aşağıdaki yerleşik güvenlik kontrolleri özellikle önemlidir:

- AI uygulamanızda güvenli kodlama en iyi uygulamaları — [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559) gibi tehditlere karşı koruma, gizli bilgiler ve belirteçler için güvenli kasalar kullanımı, tüm uygulama bileşenleri arasında uçtan uca güvenli iletişim sağlama vb.
- Sunucu sertleştirme — mümkünse MFA kullanımı, yamaların güncel tutulması, erişim için üçüncü taraf kimlik sağlayıcı entegrasyonu vb.
- Cihazlar, altyapı ve uygulamaların yamalarla güncel tutulması
- Güvenlik izleme — AI uygulaması (MCP istemci/sunucuları dahil) için günlük kaydı ve izleme uygulaması ve bu günlüklerin merkezi bir SIEM'e gönderilerek anormal aktivitelerin tespiti
- Sıfır güven mimarisi — AI uygulaması ele geçirilse bile yatay hareketi en aza indirmek için bileşenlerin ağ ve kimlik kontrolleriyle mantıksal olarak izole edilmesi.

# Önemli Noktalar

- Güvenlik temelleri kritik olmaya devam ediyor: Güvenli kodlama, asgari ayrıcalık, tedarik zinciri doğrulaması ve sürekli izleme MCP ve AI iş yükleri için esastır.
- MCP, prompt enjeksiyonu, araç zehirlenmesi, oturum kaçırma, confused deputy problemleri, token passthrough zafiyetleri ve aşırı izinler gibi yeni riskler getirir; bunlar hem geleneksel hem de AI'ya özgü kontroller gerektirir.
- Güçlü kimlik doğrulama, yetkilendirme ve belirteç yönetimi uygulayın; mümkünse Microsoft Entra ID gibi dış kimlik sağlayıcılarını kullanın.
- Dolaylı prompt enjeksiyonu ve araç zehirlenmesine karşı, araç meta verilerini doğrulayarak, dinamik değişiklikleri izleyerek ve Microsoft Prompt Shields gibi çözümler kullanarak korunun.
- Güvenli oturum yönetimi uygulayın; tahmin edilemez oturum kimlikleri kullanın, oturumları kullanıcı kimliklerine bağlayın ve kimlik doğrulama için asla oturum kullanmayın.
- Confused deputy saldırılarını önlemek için her dinamik olarak kaydedilen istemci için açık kullanıcı onayı isteyin ve doğru OAuth güvenlik uygulamalarını hayata geçirin.
- Token passthrough zafiyetlerinden kaçının; MCP sunucularının yalnızca kendileri için açıkça verilmiş belirteçleri kabul ettiğinden ve belirteç iddialarını uygun şekilde doğruladığından emin olun.
- AI tedarik zincirinizdeki tüm bileşenlere — modeller, gömme servisleri ve bağlam sağlayıcılar dahil — kod bağımlılıklarıyla aynı titizlikle yaklaşın.
- Gelişen MCP spesifikasyonlarını takip edin ve güvenli standartların şekillenmesine katkıda bulunun.

# Ek Kaynaklar

## Dış Kaynaklar
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
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
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Ek Güvenlik Belgeleri

Daha ayrıntılı güvenlik rehberliği için aşağıdaki belgelere bakabilirsiniz:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - MCP uygulamaları için kapsamlı güvenlik en iyi uygulamaları listesi
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Azure Content Safety'nin MCP sunucularıyla entegrasyon örnekleri
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - MCP dağıtımlarını güvence altına almak için en son güvenlik kontrolleri ve teknikleri
- [MCP Best Practices](./mcp-best-practices.md) - MCP güvenliği için hızlı başvuru rehberi

### Sonraki

Sonraki: [Bölüm 3: Başlarken](../03-GettingStarted/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi ana dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.