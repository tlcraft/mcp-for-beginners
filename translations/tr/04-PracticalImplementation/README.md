<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:14:25+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "tr"
}
-->
# Pratik Uygulama

Pratik uygulama, Model Context Protocol (MCP) gücünün somut hale geldiği yerdir. MCP’nin teorisini ve mimarisini anlamak önemli olsa da, gerçek değer bu kavramları gerçek dünya problemlerini çözen çözümler geliştirmek, test etmek ve dağıtmak için kullandığınızda ortaya çıkar. Bu bölüm, kavramsal bilgi ile uygulamalı geliştirme arasındaki boşluğu kapatarak MCP tabanlı uygulamaları hayata geçirme sürecinde size rehberlik eder.

İster akıllı asistanlar geliştiriyor, ister AI’yı iş akışlarına entegre ediyor ya da veri işleme için özel araçlar oluşturuyor olun, MCP esnek bir temel sunar. Dil bağımsız tasarımı ve popüler programlama dilleri için resmi SDK’ları sayesinde geniş bir geliştirici kitlesine erişilebilir. Bu SDK’ları kullanarak çözümlerinizi farklı platformlar ve ortamlarda hızlıca prototipleyebilir, yineleyebilir ve ölçeklendirebilirsiniz.

Aşağıdaki bölümlerde, MCP’yi C#, Java, TypeScript, JavaScript ve Python’da nasıl uygulayacağınıza dair pratik örnekler, örnek kodlar ve dağıtım stratejileri bulacaksınız. Ayrıca MCP sunucularınızı nasıl hata ayıklayacağınızı ve test edeceğinizi, API’leri nasıl yöneteceğinizi ve çözümleri Azure kullanarak buluta nasıl dağıtacağınızı öğreneceksiniz. Bu uygulamalı kaynaklar, öğrenmenizi hızlandırmak ve sağlam, üretime hazır MCP uygulamaları geliştirmenize güvenle yardımcı olmak için tasarlanmıştır.

## Genel Bakış

Bu ders, MCP uygulamasının birden fazla programlama dilinde pratik yönlerine odaklanır. C#, Java, TypeScript, JavaScript ve Python’da MCP SDK’larını kullanarak sağlam uygulamalar geliştirmeyi, MCP sunucularını hata ayıklamayı ve test etmeyi, yeniden kullanılabilir kaynaklar, promptlar ve araçlar oluşturmayı keşfedeceğiz.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:
- Resmi SDK’ları kullanarak çeşitli programlama dillerinde MCP çözümleri uygulamak
- MCP sunucularını sistematik olarak hata ayıklamak ve test etmek
- Sunucu özellikleri (Kaynaklar, Promptlar ve Araçlar) oluşturmak ve kullanmak
- Karmaşık görevler için etkili MCP iş akışları tasarlamak
- MCP uygulamalarını performans ve güvenilirlik açısından optimize etmek

## Resmi SDK Kaynakları

Model Context Protocol, birden fazla dil için resmi SDK’lar sunar:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK’ları ile Çalışmak

Bu bölüm, MCP’yi birden fazla programlama dilinde uygulamaya yönelik pratik örnekler sunar. Örnek kodları `samples` dizininde, dile göre organize edilmiş şekilde bulabilirsiniz.

### Mevcut Örnekler

Depoda aşağıdaki dillerde [örnek uygulamalar](../../../04-PracticalImplementation/samples) bulunmaktadır:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Her örnek, ilgili dil ve ekosistem için temel MCP kavramlarını ve uygulama kalıplarını gösterir.

## Temel Sunucu Özellikleri

MCP sunucuları aşağıdaki özelliklerin herhangi bir kombinasyonunu uygulayabilir:

### Kaynaklar  
Kaynaklar, kullanıcı veya AI modelinin kullanması için bağlam ve veri sağlar:  
- Doküman depoları  
- Bilgi tabanları  
- Yapılandırılmış veri kaynakları  
- Dosya sistemleri  

### Promptlar  
Promptlar, kullanıcılar için şablonlanmış mesajlar ve iş akışlarıdır:  
- Önceden tanımlanmış konuşma şablonları  
- Yönlendirilmiş etkileşim kalıpları  
- Özelleşmiş diyalog yapıları  

### Araçlar  
Araçlar, AI modelinin çalıştırabileceği fonksiyonlardır:  
- Veri işleme yardımcıları  
- Harici API entegrasyonları  
- Hesaplama yetenekleri  
- Arama fonksiyonları  

## Örnek Uygulamalar: C#

Resmi C# SDK deposu, MCP’nin farklı yönlerini gösteren çeşitli örnek uygulamalar içerir:

- **Temel MCP İstemcisi**: MCP istemcisi oluşturmayı ve araçları çağırmayı gösteren basit örnek  
- **Temel MCP Sunucusu**: Basit araç kaydı ile minimal sunucu uygulaması  
- **Gelişmiş MCP Sunucusu**: Araç kaydı, kimlik doğrulama ve hata yönetimi içeren tam özellikli sunucu  
- **ASP.NET Entegrasyonu**: ASP.NET Core ile entegrasyon örnekleri  
- **Araç Uygulama Kalıpları**: Farklı karmaşıklık seviyelerinde araç uygulama kalıpları  

MCP C# SDK önizleme aşamasındadır ve API’lerde değişiklik olabilir. SDK geliştikçe bu blogu sürekli güncelleyeceğiz.

### Öne Çıkan Özellikler  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)  
- [İlk MCP Sunucunuzu oluşturma](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

Tam C# uygulama örnekleri için [resmi C# SDK örnek deposunu](https://github.com/modelcontextprotocol/csharp-sdk) ziyaret edin.

## Örnek Uygulama: Java Uygulaması

Java SDK, kurumsal düzeyde özelliklerle güçlü MCP uygulama seçenekleri sunar.

### Öne Çıkan Özellikler

- Spring Framework entegrasyonu  
- Güçlü tip güvenliği  
- Reaktif programlama desteği  
- Kapsamlı hata yönetimi  

Tam Java uygulama örneği için örnekler dizinindeki [Java örneğine](samples/java/containerapp/README.md) bakabilirsiniz.

## Örnek Uygulama: JavaScript Uygulaması

JavaScript SDK, MCP uygulaması için hafif ve esnek bir yaklaşım sunar.

### Öne Çıkan Özellikler

- Node.js ve tarayıcı desteği  
- Promise tabanlı API  
- Express ve diğer frameworklerle kolay entegrasyon  
- Akış için WebSocket desteği  

Tam JavaScript uygulama örneği için örnekler dizinindeki [JavaScript örneğine](samples/javascript/README.md) bakabilirsiniz.

## Örnek Uygulama: Python Uygulaması

Python SDK, MCP uygulaması için Python’a özgü bir yaklaşım ve mükemmel ML framework entegrasyonları sunar.

### Öne Çıkan Özellikler

- asyncio ile async/await desteği  
- FastAPI entegrasyonu  
- Basit araç kaydı  
- Popüler ML kütüphaneleri ile yerel entegrasyon  

Tam Python uygulama örneği için örnekler dizinindeki [Python örneğine](samples/python/README.md) bakabilirsiniz.

## API Yönetimi

Azure API Management, MCP Sunucularını nasıl güvence altına alabileceğimiz konusunda harika bir çözümdür. Fikir, MCP Sunucunuzun önüne bir Azure API Management örneği koymak ve aşağıdaki gibi özellikleri onun yönetmesine izin vermektir:

- hız sınırlaması  
- token yönetimi  
- izleme  
- yük dengeleme  
- güvenlik  

### Azure Örneği

İşte tam olarak bunu yapan bir Azure Örneği, yani [bir MCP Sunucusu oluşturup Azure API Management ile güvence altına alma](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Yetkilendirme akışının aşağıdaki görselde nasıl gerçekleştiğini görün:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Yukarıdaki görselde şu işlemler gerçekleşir:

- Kimlik doğrulama/Yetkilendirme Microsoft Entra kullanılarak yapılır.  
- Azure API Management bir geçit görevi görür ve trafiği yönlendirmek ve yönetmek için politikalar kullanır.  
- Azure Monitor, tüm istekleri daha fazla analiz için kaydeder.  

#### Yetkilendirme akışı

Yetkilendirme akışına daha yakından bakalım:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP yetkilendirme spesifikasyonu

[MCP Yetkilendirme spesifikasyonu](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) hakkında daha fazla bilgi edinin.

## Uzaktan MCP Sunucusunu Azure’a Dağıtma

Daha önce bahsettiğimiz örneği dağıtıp dağıtamayacağımıza bakalım:

1. Depoyu klonlayın

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. `Microsoft.App` kaynak sağlayıcısını kaydedin.  
    * Azure CLI kullanıyorsanız, `az provider register --namespace Microsoft.App --wait` komutunu çalıştırın.  
    * Azure PowerShell kullanıyorsanız, `Register-AzResourceProvider -ProviderNamespace Microsoft.App` komutunu çalıştırın. Ardından kaydın tamamlanıp tamamlanmadığını kontrol etmek için bir süre sonra `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` komutunu çalıştırın.

2. API yönetim servisi, fonksiyon uygulaması (kod ile) ve diğer gerekli Azure kaynaklarını sağlamak için şu [azd](https://aka.ms/azd) komutunu çalıştırın:

    ```shell
    azd up
    ```

    Bu komutlar Azure üzerinde tüm bulut kaynaklarını dağıtmalıdır.

### MCP Inspector ile sunucunuzu test etme

1. **Yeni bir terminal penceresinde**, MCP Inspector’ı yükleyip çalıştırın:

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Aşağıdakine benzer bir arayüz görmelisiniz:

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png) 

1. Uygulamanın gösterdiği URL’den (örneğin http://127.0.0.1:6274/#resources) MCP Inspector web uygulamasını CTRL tıklayarak açın  
1. Taşıma türünü `SSE` olarak ayarlayın  
1. `azd up` komutundan sonra gösterilen çalışan API Management SSE uç noktasını URL olarak ayarlayın ve **Bağlan**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Araçları Listele**. Bir araca tıklayın ve **Aracı Çalıştır**.  

Eğer tüm adımlar doğru çalıştıysa, artık MCP sunucusuna bağlısınız ve bir aracı çağırabilmiş olmalısınız.

## Azure için MCP sunucuları

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Bu depo seti, Python, C# .NET veya Node/TypeScript kullanarak Azure Functions ile özel uzak MCP (Model Context Protocol) sunucuları oluşturmak ve dağıtmak için hızlı başlangıç şablonlarıdır.

Örnekler, geliştiricilerin şunları yapmasını sağlar:

- Yerel olarak oluşturma ve çalıştırma: MCP sunucusunu yerel makinede geliştirme ve hata ayıklama  
- Azure’a dağıtma: Basit bir azd up komutuyla buluta kolayca dağıtım  
- İstemcilerden bağlanma: VS Code’un Copilot agent modu ve MCP Inspector aracı dahil çeşitli istemcilerden MCP sunucusuna bağlanma  

### Öne Çıkan Özellikler:

- Tasarım gereği güvenlik: MCP sunucusu anahtarlar ve HTTPS ile güvence altına alınmıştır  
- Kimlik doğrulama seçenekleri: Dahili kimlik doğrulama ve/veya API Management kullanarak OAuth desteği  
- Ağ izolasyonu: Azure Sanal Ağları (VNET) kullanarak ağ izolasyonu sağlar  
- Sunucusuz mimari: Ölçeklenebilir, olay odaklı yürütme için Azure Functions kullanır  
- Yerel geliştirme: Kapsamlı yerel geliştirme ve hata ayıklama desteği  
- Basit dağıtım: Azure’a kolaylaştırılmış dağıtım süreci  

Depo, üretime hazır bir MCP sunucu uygulamasıyla hızlıca başlamanız için gerekli tüm yapılandırma dosyalarını, kaynak kodu ve altyapı tanımlarını içerir.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python ile Azure Functions kullanarak MCP örnek uygulaması  
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET ile Azure Functions kullanarak MCP örnek uygulaması  
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript ile Azure Functions kullanarak MCP örnek uygulaması  

## Önemli Noktalar

- MCP SDK’ları, sağlam MCP çözümleri uygulamak için dil bazlı araçlar sağlar  
- Hata ayıklama ve test süreci, güvenilir MCP uygulamaları için kritiktir  
- Yeniden kullanılabilir prompt şablonları tutarlı AI etkileşimleri sağlar  
- İyi tasarlanmış iş akışları, birden fazla aracı kullanarak karmaşık görevleri düzenleyebilir  
- MCP çözümleri uygularken güvenlik, performans ve hata yönetimi dikkate alınmalıdır  

## Alıştırma

Alanınızdaki gerçek bir problemi ele alan pratik bir MCP iş akışı tasarlayın:

1. Bu problemi çözmek için faydalı olabilecek 3-4 araç belirleyin  
2. Bu araçların nasıl etkileşime girdiğini gösteren bir iş akışı diyagramı oluşturun  
3. Tercih ettiğiniz dilde araçlardan birinin temel bir versiyonunu uygulayın  
4. Modelin aracınızı etkili kullanmasına yardımcı olacak bir prompt şablonu oluşturun  

## Ek Kaynaklar


---

Sonraki: [Gelişmiş Konular](../05-AdvancedTopics/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.