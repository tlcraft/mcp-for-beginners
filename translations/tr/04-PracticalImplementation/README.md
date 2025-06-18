<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:06:29+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "tr"
}
-->
# Pratik Uygulama

Pratik uygulama, Model Context Protocol (MCP) gücünün somut hale geldiği yerdir. MCP'nin teorisini ve mimarisini anlamak önemli olsa da, gerçek değer bu kavramları kullanarak gerçek dünyadaki sorunları çözen çözümler inşa etmek, test etmek ve dağıtmakla ortaya çıkar. Bu bölüm, kavramsal bilgi ile uygulamalı geliştirme arasındaki boşluğu kapatarak, MCP tabanlı uygulamaları hayata geçirme sürecinde size rehberlik eder.

Akıllı asistanlar geliştiriyor, AI'yı iş akışlarına entegre ediyor ya da veri işleme için özel araçlar oluşturuyor olun, MCP esnek bir temel sağlar. Dil bağımsız tasarımı ve popüler programlama dilleri için resmi SDK'ları sayesinde geniş bir geliştirici kitlesi tarafından erişilebilir. Bu SDK'ları kullanarak çözümlerinizi hızlıca prototipleyebilir, yineleyebilir ve farklı platformlar ile ortamlarda ölçeklendirebilirsiniz.

Aşağıdaki bölümlerde, MCP'yi C#, Java, TypeScript, JavaScript ve Python’da nasıl uygulayacağınıza dair pratik örnekler, örnek kodlar ve dağıtım stratejileri bulacaksınız. Ayrıca MCP sunucularınızı nasıl hata ayıklayacağınızı ve test edeceğinizi, API’leri nasıl yöneteceğinizi ve çözümleri Azure kullanarak buluta nasıl dağıtacağınızı öğreneceksiniz. Bu uygulamalı kaynaklar, öğrenme sürecinizi hızlandırmak ve sağlam, üretime hazır MCP uygulamaları oluşturmanızı güvenle sağlamanız için tasarlanmıştır.

## Genel Bakış

Bu ders, MCP uygulamasının pratik yönlerine, birden fazla programlama dili üzerinden odaklanır. C#, Java, TypeScript, JavaScript ve Python’da MCP SDK’larını kullanarak sağlam uygulamalar geliştirmeyi, MCP sunucularını hata ayıklamayı ve test etmeyi, yeniden kullanılabilir kaynaklar, istemler ve araçlar oluşturmayı keşfedeceğiz.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:
- Resmi SDK’ları kullanarak çeşitli programlama dillerinde MCP çözümleri uygulamak
- MCP sunucularını sistematik olarak hata ayıklamak ve test etmek
- Sunucu özellikleri (Kaynaklar, İstemler ve Araçlar) oluşturup kullanmak
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

Bu bölüm, MCP’nin birden fazla programlama dilinde nasıl uygulanacağına dair pratik örnekler sunar. Dil bazında düzenlenmiş örnek kodları `samples` dizininde bulabilirsiniz.

### Mevcut Örnekler

Depoda aşağıdaki dillerde [örnek uygulamalar](../../../04-PracticalImplementation/samples) yer almaktadır:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Her örnek, o dile ve ekosisteme özgü temel MCP kavramları ve uygulama desenlerini göstermektedir.

## Temel Sunucu Özellikleri

MCP sunucuları aşağıdaki özelliklerin herhangi bir kombinasyonunu uygulayabilir:

### Kaynaklar  
Kaynaklar, kullanıcı veya AI modelinin kullanması için bağlam ve veri sağlar:  
- Doküman depoları  
- Bilgi tabanları  
- Yapılandırılmış veri kaynakları  
- Dosya sistemleri  

### İstemler  
İstemler, kullanıcılar için şablonlanmış mesajlar ve iş akışlarıdır:  
- Önceden tanımlanmış konuşma şablonları  
- Yönlendirilmiş etkileşim desenleri  
- Özel diyalog yapıları  

### Araçlar  
Araçlar, AI modelinin çalıştırabileceği fonksiyonlardır:  
- Veri işleme yardımcıları  
- Harici API entegrasyonları  
- Hesaplama yetenekleri  
- Arama fonksiyonelliği  

## Örnek Uygulamalar: C#

Resmi C# SDK deposu, MCP’nin farklı yönlerini gösteren çeşitli örnek uygulamalar içerir:

- **Temel MCP İstemcisi**: MCP istemcisi oluşturmayı ve araçları çağırmayı gösteren basit örnek  
- **Temel MCP Sunucusu**: Basit araç kaydı ile minimal sunucu uygulaması  
- **Gelişmiş MCP Sunucusu**: Araç kaydı, kimlik doğrulama ve hata yönetimi içeren tam özellikli sunucu  
- **ASP.NET Entegrasyonu**: ASP.NET Core ile entegrasyonu gösteren örnekler  
- **Araç Uygulama Desenleri**: Farklı karmaşıklık seviyelerinde araç uygulama desenleri  

MCP C# SDK önizlemededir ve API’lerde değişiklikler olabilir. SDK geliştikçe bu blogu sürekli güncelleyeceğiz.

### Önemli Özellikler  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- [İlk MCP Sunucunuzu oluşturma](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Tam C# uygulama örnekleri için [resmi C# SDK örnek deposunu](https://github.com/modelcontextprotocol/csharp-sdk) ziyaret edin.

## Örnek Uygulama: Java Uygulaması

Java SDK, kurumsal düzeyde özelliklere sahip sağlam MCP uygulama seçenekleri sunar.

### Önemli Özellikler

- Spring Framework entegrasyonu  
- Güçlü tür güvenliği  
- Reaktif programlama desteği  
- Kapsamlı hata yönetimi  

Tam Java uygulama örneği için örnek dizinindeki [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) dosyasına bakın.

## Örnek Uygulama: JavaScript Uygulaması

JavaScript SDK, MCP uygulaması için hafif ve esnek bir yaklaşım sunar.

### Önemli Özellikler

- Node.js ve tarayıcı desteği  
- Promise tabanlı API  
- Express ve diğer frameworklerle kolay entegrasyon  
- Akış için WebSocket desteği  

Tam JavaScript uygulama örneği için örnek dizinindeki [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) dosyasına bakın.

## Örnek Uygulama: Python Uygulaması

Python SDK, mükemmel ML framework entegrasyonlarıyla Python’a özgü bir MCP uygulaması sunar.

### Önemli Özellikler

- asyncio ile async/await desteği  
- Flask ve FastAPI entegrasyonu  
- Basit araç kaydı  
- Popüler ML kütüphaneleri ile yerel entegrasyon  

Tam Python uygulama örneği için örnek dizinindeki [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) dosyasına bakın.

## API Yönetimi

Azure API Management, MCP Sunucularını nasıl güvenceye alabileceğimiz konusunda harika bir çözümdür. Fikir, MCP Sunucunuzun önüne bir Azure API Management örneği koymak ve şu gibi ihtiyaç duyabileceğiniz özellikleri onun yönetmesine izin vermektir:

- oran sınırlaması  
- token yönetimi  
- izleme  
- yük dengeleme  
- güvenlik  

### Azure Örneği

İşte tam olarak bunu yapan bir Azure Örneği, yani [bir MCP Sunucusu oluşturup Azure API Management ile güvenceye alma](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Yetkilendirme akışının nasıl gerçekleştiğini aşağıdaki görselde görebilirsiniz:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Yukarıdaki görselde şu işlemler gerçekleşir:

- Kimlik doğrulama/Yetkilendirme Microsoft Entra kullanılarak yapılır.  
- Azure API Management bir ağ geçidi görevi görür ve trafiği yönlendirmek ve yönetmek için politikalar kullanır.  
- Azure Monitor tüm istekleri analiz için kaydeder.  

#### Yetkilendirme Akışı

Yetkilendirme akışına daha yakından bakalım:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP Yetkilendirme Spesifikasyonu

[MCP Yetkilendirme spesifikasyonu](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) hakkında daha fazla bilgi edinin.

## Uzaktan MCP Sunucusunu Azure’a Dağıtma

Daha önce bahsettiğimiz örneği dağıtıp dağıtamayacağımıza bakalım:

1. Depoyu klonlayın

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` sağlayıcısını kaydedin

    ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState

    Kayıt tamamlandıktan sonra durumu kontrol edin.

3. Bu [azd](https://aka.ms/azd) komutunu çalıştırarak API yönetimi servisini, fonksiyon uygulamasını (kod ile) ve diğer gerekli Azure kaynaklarını oluşturun

    ```shell
    azd up
    ```

    Bu komut, Azure’da tüm bulut kaynaklarını dağıtmalıdır.

### MCP Inspector ile Sunucunuzu Test Etme

1. **Yeni bir terminal penceresinde**, MCP Inspector’u kurup çalıştırın

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Aşağıdaki gibi bir arayüz görmelisiniz:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tr.png) 

2. Uygulamanın gösterdiği URL’den MCP Inspector web uygulamasını CTRL tıklayarak açın (örneğin http://127.0.0.1:6274/#resources)  
3. Taşıma türünü `SSE` olarak ayarlayın ve **Bağlan**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Araçları Listele**. Bir araca tıklayın ve **Aracı Çalıştır**.  

Eğer tüm adımlar doğru çalıştıysa, şimdi MCP sunucusuna bağlandınız ve bir aracı çağırabildiniz demektir.

## Azure için MCP Sunucuları

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Bu depo seti, Python, C# .NET veya Node/TypeScript kullanarak Azure Functions ile özel uzak MCP (Model Context Protocol) sunucuları oluşturmak ve dağıtmak için hızlı başlangıç şablonudur.

Örnekler, geliştiricilerin:

- Yerelde geliştirme ve çalıştırma: MCP sunucusunu yerel makinede geliştirme ve hata ayıklama  
- Azure’a dağıtım: Basit bir azd up komutuyla buluta kolayca dağıtım  
- İstemcilerden bağlanma: VS Code’un Copilot ajan modu ve MCP Inspector aracı dahil çeşitli istemcilerden MCP sunucusuna bağlanma  

özelliklerini sağlamasına olanak tanır.

### Önemli Özellikler:

- Tasarım gereği güvenlik: MCP sunucusu anahtarlar ve HTTPS ile güvence altına alınmıştır  
- Kimlik doğrulama seçenekleri: Dahili kimlik doğrulama ve/veya API Yönetimi kullanarak OAuth desteği  
- Ağ izolasyonu: Azure Sanal Ağlar (VNET) ile ağ izolasyonu imkanı  
- Sunucusuz mimari: Ölçeklenebilir, olay odaklı yürütme için Azure Functions kullanımı  
- Yerel geliştirme: Kapsamlı yerel geliştirme ve hata ayıklama desteği  
- Basit dağıtım: Azure’a kolaylaştırılmış dağıtım süreci  

Depo, üretime hazır MCP sunucu uygulaması geliştirmeye hızlı başlamanız için gerekli tüm yapılandırma dosyalarını, kaynak kodu ve altyapı tanımlarını içerir.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python ile Azure Functions kullanarak MCP örnek uygulaması  
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET ile Azure Functions kullanarak MCP örnek uygulaması  
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript ile Azure Functions kullanarak MCP örnek uygulaması  

## Temel Çıkarımlar

- MCP SDK’ları, sağlam MCP çözümleri uygulamak için dile özgü araçlar sağlar  
- Hata ayıklama ve test süreci, güvenilir MCP uygulamaları için kritiktir  
- Yeniden kullanılabilir istem şablonları, tutarlı AI etkileşimleri sağlar  
- İyi tasarlanmış iş akışları, birden fazla araç kullanarak karmaşık görevleri düzenleyebilir  
- MCP çözümleri uygularken güvenlik, performans ve hata yönetimi göz önünde bulundurulmalıdır  

## Alıştırma

Kendi alanınızdaki gerçek bir problemi ele alan pratik bir MCP iş akışı tasarlayın:

1. Bu problemi çözmek için faydalı olacak 3-4 aracı belirleyin  
2. Bu araçların nasıl etkileşime girdiğini gösteren bir iş akışı diyagramı oluşturun  
3. Tercih ettiğiniz dilde araçlardan birinin temel bir versiyonunu uygulayın  
4. Modelin aracınızı etkili kullanmasına yardımcı olacak bir istem şablonu oluşturun  

## Ek Kaynaklar


---

Sonraki: [Gelişmiş Konular](../05-AdvancedTopics/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek herhangi bir yanlış anlama veya yanlış yorumdan sorumlu değiliz.