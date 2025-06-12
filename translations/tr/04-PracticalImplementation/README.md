<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:13:34+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "tr"
}
-->
# Pratik Uygulama

Pratik uygulama, Model Context Protocol'ün (MCP) gücünün somut hale geldiği yerdir. MCP'nin teorisini ve mimarisini anlamak önemli olsa da, gerçek değer, bu kavramları gerçek dünya problemlerini çözen çözümler oluşturmak, test etmek ve dağıtmak için kullandığınızda ortaya çıkar. Bu bölüm, kavramsal bilgi ile uygulamalı geliştirme arasındaki boşluğu kapatarak, MCP tabanlı uygulamaları hayata geçirme sürecinde size rehberlik eder.

İster akıllı asistanlar geliştiriyor olun, ister yapay zekayı iş akışlarına entegre ediyor ya da veri işleme için özel araçlar oluşturuyor olun, MCP esnek bir temel sağlar. Dil bağımsız tasarımı ve popüler programlama dilleri için resmi SDK'ları, geniş bir geliştirici kitlesine erişim imkanı sunar. Bu SDK'ları kullanarak çözümlerinizi farklı platformlar ve ortamlar arasında hızlıca prototipleyebilir, yineleyebilir ve ölçeklendirebilirsiniz.

Aşağıdaki bölümlerde, MCP'nin C#, Java, TypeScript, JavaScript ve Python'da nasıl uygulanacağını gösteren pratik örnekler, örnek kodlar ve dağıtım stratejileri bulacaksınız. Ayrıca MCP sunucularınızı nasıl hata ayıklayacağınızı ve test edeceğinizi, API'leri nasıl yöneteceğinizi ve Azure kullanarak çözümleri buluta nasıl dağıtacağınızı öğreneceksiniz. Bu uygulamalı kaynaklar, öğrenmenizi hızlandırmak ve sağlam, üretime hazır MCP uygulamaları oluşturmanızı sağlamak için tasarlanmıştır.

## Genel Bakış

Bu ders, MCP uygulamasının birden çok programlama diliyle ilgili pratik yönlerine odaklanır. C#, Java, TypeScript, JavaScript ve Python'da MCP SDK'larını kullanarak sağlam uygulamalar geliştirme, MCP sunucularını hata ayıklama ve test etme ile yeniden kullanılabilir kaynaklar, istemler ve araçlar oluşturmayı keşfedeceğiz.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:
- Resmi SDK'ları kullanarak çeşitli programlama dillerinde MCP çözümleri uygulamak
- MCP sunucularını sistematik şekilde hata ayıklamak ve test etmek
- Sunucu özellikleri (Kaynaklar, İstemler ve Araçlar) oluşturmak ve kullanmak
- Karmaşık görevler için etkili MCP iş akışları tasarlamak
- MCP uygulamalarını performans ve güvenilirlik açısından optimize etmek

## Resmi SDK Kaynakları

Model Context Protocol, birçok dil için resmi SDK'lar sunar:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK'ları ile Çalışmak

Bu bölüm, MCP'nin birden çok programlama dilinde uygulanmasına dair pratik örnekler sunar. Dil bazında organize edilmiş örnek kodları `samples` dizininde bulabilirsiniz.

### Mevcut Örnekler

Depoda aşağıdaki dillerde örnek uygulamalar yer almaktadır:

- C#
- Java
- TypeScript
- JavaScript
- Python

Her örnek, ilgili dil ve ekosistem için temel MCP kavramlarını ve uygulama kalıplarını göstermektedir.

## Temel Sunucu Özellikleri

MCP sunucuları aşağıdaki özelliklerin herhangi bir kombinasyonunu uygulayabilir:

### Kaynaklar  
Kaynaklar, kullanıcı veya yapay zeka modelinin kullanması için bağlam ve veri sağlar:  
- Doküman depoları  
- Bilgi tabanları  
- Yapılandırılmış veri kaynakları  
- Dosya sistemleri  

### İstemler  
İstemler, kullanıcılar için şablonlanmış mesajlar ve iş akışlarıdır:  
- Önceden tanımlanmış konuşma şablonları  
- Yönlendirilmiş etkileşim kalıpları  
- Özelleşmiş diyalog yapıları  

### Araçlar  
Araçlar, yapay zeka modelinin çalıştırabileceği fonksiyonlardır:  
- Veri işleme araçları  
- Harici API entegrasyonları  
- Hesaplama yetenekleri  
- Arama fonksiyonları  

## Örnek Uygulamalar: C#

Resmi C# SDK deposu, MCP'nin farklı yönlerini gösteren birkaç örnek uygulama içerir:

- **Temel MCP İstemcisi**: MCP istemcisi oluşturmayı ve araçları çağırmayı gösteren basit örnek  
- **Temel MCP Sunucusu**: Basit araç kaydı ile minimal sunucu uygulaması  
- **Gelişmiş MCP Sunucusu**: Araç kaydı, kimlik doğrulama ve hata yönetimi içeren tam özellikli sunucu  
- **ASP.NET Entegrasyonu**: ASP.NET Core ile entegrasyonu gösteren örnekler  
- **Araç Uygulama Kalıpları**: Farklı karmaşıklık seviyelerinde araç uygulama kalıpları  

MCP C# SDK'sı önizleme aşamasındadır ve API'lerde değişiklik olabilir. SDK geliştikçe bu blogu sürekli güncelleyeceğiz.

### Temel Özellikler  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)  

- [İlk MCP Sunucunuzu oluşturma](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Tam C# uygulama örnekleri için [resmi C# SDK örnekleri deposunu](https://github.com/modelcontextprotocol/csharp-sdk) ziyaret edin.

## Örnek Uygulama: Java Uygulaması

Java SDK, kurumsal düzeyde özelliklerle sağlam MCP uygulama seçenekleri sunar.

### Temel Özellikler

- Spring Framework entegrasyonu  
- Güçlü tür güvenliği  
- Reaktif programlama desteği  
- Kapsamlı hata yönetimi  

Tam bir Java uygulama örneği için samples dizinindeki [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) dosyasına bakabilirsiniz.

## Örnek Uygulama: JavaScript Uygulaması

JavaScript SDK, MCP uygulaması için hafif ve esnek bir yaklaşım sağlar.

### Temel Özellikler

- Node.js ve tarayıcı desteği  
- Promise tabanlı API  
- Express ve diğer frameworklerle kolay entegrasyon  
- Akış için WebSocket desteği  

Tam bir JavaScript uygulama örneği için samples dizinindeki [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) dosyasına bakabilirsiniz.

## Örnek Uygulama: Python Uygulaması

Python SDK, mükemmel ML framework entegrasyonlarıyla Python tarzı bir MCP uygulaması sunar.

### Temel Özellikler

- asyncio ile async/await desteği  
- Flask ve FastAPI entegrasyonu  
- Basit araç kaydı  
- Popüler ML kütüphaneleri ile yerel entegrasyon  

Tam bir Python uygulama örneği için samples dizinindeki [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) dosyasına bakabilirsiniz.

## API Yönetimi

Azure API Yönetimi, MCP Sunucularını nasıl güvence altına alabileceğimiz için mükemmel bir çözümdür. Fikir, MCP Sunucunuzun önüne bir Azure API Yönetimi örneği koymak ve aşağıdaki gibi özellikleri yönetmesini sağlamaktır:

- hız sınırlandırma  
- token yönetimi  
- izleme  
- yük dengeleme  
- güvenlik  

### Azure Örneği

İşte tam olarak bunu yapan bir Azure Örneği, yani [bir MCP Sunucusu oluşturup Azure API Yönetimi ile güvence altına alma](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Yetkilendirme akışının aşağıdaki görselde nasıl gerçekleştiğini görebilirsiniz:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Önceki görselde şunlar gerçekleşir:

- Kimlik doğrulama/Yetkilendirme Microsoft Entra kullanılarak yapılır.  
- Azure API Yönetimi, bir geçit görevi görür ve trafiği yönlendirmek ve yönetmek için politikalar kullanır.  
- Azure Monitor, tüm istekleri daha fazla analiz için kaydeder.  

#### Yetkilendirme akışı

Yetkilendirme akışına daha ayrıntılı bakalım:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP yetkilendirme spesifikasyonu

[MCP Yetkilendirme spesifikasyonu](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) hakkında daha fazla bilgi edinin.

## Uzak MCP Sunucusunu Azure'a Dağıtma

Daha önce bahsettiğimiz örneği dağıtıp dağıtamayacağımıza bakalım:

1. Depoyu klonlayın

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` sağlayıcısını kaydedin ve kaydın tamamlanıp tamamlanmadığını kontrol edin:

    `` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

3. Bu [azd](https://aka.ms/azd) komutunu çalıştırarak API yönetimi servisini, işlev uygulamasını (kod ile) ve diğer gerekli Azure kaynaklarını oluşturun:

    ```shell
    azd up
    ```

    Bu komut, tüm bulut kaynaklarını Azure üzerinde dağıtmalıdır.

### MCP Inspector ile Sunucunuzu Test Etme

1. **Yeni bir terminal penceresinde**, MCP Inspector'ı yükleyip çalıştırın:

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Aşağıdakine benzer bir arayüz görmelisiniz:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tr.png) 

2. Uygulamanın gösterdiği URL'den (örneğin http://127.0.0.1:6274/#resources) MCP Inspector web uygulamasını CTRL tıklayarak açın.  
3. Taşıma türünü `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` olarak ayarlayın ve **Bağlan**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Araçları Listele**. Bir araca tıklayın ve **Aracı Çalıştır**.  

Eğer tüm adımlar doğru yapıldıysa, artık MCP sunucusuna bağlanmış ve bir aracı çağırabilmiş olmalısınız.

## Azure için MCP Sunucuları

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Bu depo seti, Python, C# .NET veya Node/TypeScript kullanarak Azure Functions ile özel uzak MCP (Model Context Protocol) sunucuları oluşturmak ve dağıtmak için hızlı başlangıç şablonlarıdır.

Örnekler, geliştiricilere tam bir çözüm sunar ve şunları yapmanızı sağlar:

- Yerelde oluşturma ve çalıştırma: MCP sunucusunu yerel makinede geliştirme ve hata ayıklama  
- Azure'a dağıtım: Basit bir azd up komutuyla buluta kolayca dağıtım  
- İstemcilerden bağlanma: VS Code Copilot ajan modu ve MCP Inspector aracı dahil olmak üzere çeşitli istemcilerden MCP sunucusuna bağlanma  

### Temel Özellikler:

- Tasarım gereği güvenlik: MCP sunucusu anahtarlar ve HTTPS kullanılarak korunur  
- Kimlik doğrulama seçenekleri: Dahili kimlik doğrulama ve/veya API Yönetimi ile OAuth desteği  
- Ağ izolasyonu: Azure Sanal Ağları (VNET) kullanarak ağ izolasyonu sağlar  
- Sunucusuz mimari: Ölçeklenebilir, olay odaklı yürütme için Azure Functions kullanır  
- Yerel geliştirme: Kapsamlı yerel geliştirme ve hata ayıklama desteği  
- Basit dağıtım: Azure'a kolay dağıtım süreci  

Depo, üretime hazır bir MCP sunucu uygulamasıyla hızlı başlamanız için gerekli tüm yapılandırma dosyalarını, kaynak kodunu ve altyapı tanımlarını içerir.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python ile Azure Functions kullanarak MCP örnek uygulaması  

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET ile Azure Functions kullanarak MCP örnek uygulaması  

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript ile Azure Functions kullanarak MCP örnek uygulaması  

## Önemli Noktalar

- MCP SDK'ları, sağlam MCP çözümleri uygulamak için dil bazlı araçlar sağlar  
- Hata ayıklama ve test süreci, güvenilir MCP uygulamaları için kritiktir  
- Yeniden kullanılabilir istem şablonları, tutarlı yapay zeka etkileşimleri sağlar  
- İyi tasarlanmış iş akışları, birden çok araç kullanarak karmaşık görevleri koordine eder  
- MCP çözümlerini uygularken güvenlik, performans ve hata yönetimi göz önünde bulundurulmalıdır  

## Alıştırma

Alanınızdaki gerçek bir problemi ele alan pratik bir MCP iş akışı tasarlayın:

1. Bu problemi çözmek için faydalı olabilecek 3-4 araç belirleyin  
2. Bu araçların nasıl etkileşime girdiğini gösteren bir iş akışı diyagramı oluşturun  
3. Tercih ettiğiniz dilde araçlardan birinin temel bir versiyonunu uygulayın  
4. Modelin aracınızı etkili kullanmasına yardımcı olacak bir istem şablonu oluşturun  

## Ek Kaynaklar


---

Sonraki: [Gelişmiş Konular](../05-AdvancedTopics/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.