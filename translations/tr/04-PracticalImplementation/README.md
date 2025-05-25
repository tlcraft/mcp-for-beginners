<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:51:04+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "tr"
}
-->
# Pratik Uygulama

Pratik uygulama, Model Bağlam Protokolü'nün (MCP) gücünün somut hale geldiği yerdir. MCP'nin teorisini ve mimarisini anlamak önemli olsa da, gerçek değer, bu kavramları gerçek dünya problemlerini çözen çözümler oluşturmak, test etmek ve dağıtmak için uyguladığınızda ortaya çıkar. Bu bölüm, kavramsal bilgi ile uygulamalı geliştirme arasındaki boşluğu doldurarak MCP tabanlı uygulamaları hayata geçirme sürecinde size rehberlik eder.

İster akıllı asistanlar geliştiriyor, ister iş akışlarına yapay zekayı entegre ediyor, ister veri işleme için özel araçlar inşa ediyor olun, MCP esnek bir temel sunar. Dil bağımsız tasarımı ve popüler programlama dilleri için resmi SDK'ları ile geniş bir geliştirici yelpazesine erişilebilir kılar. Bu SDK'ları kullanarak, çözümlerinizi farklı platformlar ve ortamlar arasında hızla prototipleştirip, yineleyip ölçeklendirebilirsiniz.

Aşağıdaki bölümlerde, MCP'yi C#, Java, TypeScript, JavaScript ve Python'da nasıl uygulayacağınızı gösteren pratik örnekler, örnek kodlar ve dağıtım stratejileri bulacaksınız. Ayrıca MCP sunucularınızı nasıl hata ayıklayıp test edeceğinizi, API'ları yöneteceğinizi ve çözümleri Azure kullanarak buluta nasıl dağıtacağınızı öğreneceksiniz. Bu uygulamalı kaynaklar, öğrenme sürecinizi hızlandırmak ve sağlam, üretime hazır MCP uygulamaları oluşturma konusunda kendinize güvenmenizi sağlamak için tasarlanmıştır.

## Genel Bakış

Bu ders, MCP uygulamasının pratik yönlerine odaklanmaktadır ve birden fazla programlama dili üzerinde MCP uygulamasını inceleyeceğiz. C#, Java, TypeScript, JavaScript ve Python'da MCP SDK'larını kullanarak sağlam uygulamalar geliştirmeyi, MCP sunucularını hata ayıklamayı ve test etmeyi, yeniden kullanılabilir kaynaklar, istemler ve araçlar oluşturmayı keşfedeceğiz.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:
- Çeşitli programlama dillerinde resmi SDK'ları kullanarak MCP çözümleri uygulamak
- MCP sunucularını sistematik olarak hata ayıklamak ve test etmek
- Sunucu özellikleri oluşturmak ve kullanmak (Kaynaklar, İstemler ve Araçlar)
- Karmaşık görevler için etkili MCP iş akışları tasarlamak
- MCP uygulamalarını performans ve güvenilirlik açısından optimize etmek

## Resmi SDK Kaynakları

Model Bağlam Protokolü, birden fazla dil için resmi SDK'lar sunar:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK'ları ile Çalışmak

Bu bölüm, birden fazla programlama dili üzerinde MCP'yi uygulama konusunda pratik örnekler sunar. `samples` dizininde dil bazında organize edilmiş örnek kodlar bulabilirsiniz.

### Mevcut Örnekler

Depo, aşağıdaki dillerde örnek uygulamalar içerir:

- C#
- Java
- TypeScript
- JavaScript
- Python

Her örnek, belirli bir dil ve ekosistem için temel MCP kavramlarını ve uygulama desenlerini gösterir.

## Temel Sunucu Özellikleri

MCP sunucuları, bu özelliklerin herhangi bir kombinasyonunu uygulayabilir:

### Kaynaklar
Kaynaklar, kullanıcı veya AI modelinin kullanması için bağlam ve veri sağlar:
- Doküman depoları
- Bilgi tabanları
- Yapılandırılmış veri kaynakları
- Dosya sistemleri

### İstemler
İstemler, kullanıcılar için şablonlu mesajlar ve iş akışlarıdır:
- Önceden tanımlanmış konuşma şablonları
- Rehberli etkileşim desenleri
- Uzmanlaşmış diyalog yapıları

### Araçlar
Araçlar, AI modelinin çalıştırması gereken işlevlerdir:
- Veri işleme yardımcıları
- Harici API entegrasyonları
- Hesaplama yetenekleri
- Arama işlevselliği

## Örnek Uygulamalar: C#

Resmi C# SDK deposu, MCP'nin farklı yönlerini gösteren birkaç örnek uygulama içerir:

- **Temel MCP İstemcisi**: MCP istemcisi oluşturma ve araçları çağırma konusunda basit bir örnek
- **Temel MCP Sunucusu**: Temel araç kaydı ile minimal sunucu uygulaması
- **Gelişmiş MCP Sunucusu**: Araç kaydı, kimlik doğrulama ve hata yönetimi ile tam özellikli sunucu
- **ASP.NET Entegrasyonu**: ASP.NET Core ile entegrasyonu gösteren örnekler
- **Araç Uygulama Desenleri**: Farklı karmaşıklık seviyelerinde araç uygulama desenleri

MCP C# SDK önizleme aşamasındadır ve API'ler değişebilir. SDK geliştikçe bu blogu sürekli güncelleyeceğiz.

### Temel Özellikler
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- İlk [MCP Sunucunuzu](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) oluşturma.

Tam C# uygulama örnekleri için, [resmi C# SDK örnekleri deposunu](https://github.com/modelcontextprotocol/csharp-sdk) ziyaret edin.

## Örnek Uygulama: Java Uygulaması

Java SDK, kurumsal düzeyde özelliklerle sağlam MCP uygulama seçenekleri sunar.

### Temel Özellikler

- Spring Framework entegrasyonu
- Güçlü tür güvenliği
- Reaktif programlama desteği
- Kapsamlı hata yönetimi

Tam bir Java uygulama örneği için, örnekler dizininde [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) dosyasına bakın.

## Örnek Uygulama: JavaScript Uygulaması

JavaScript SDK, MCP uygulaması için hafif ve esnek bir yaklaşım sunar.

### Temel Özellikler

- Node.js ve tarayıcı desteği
- Promise tabanlı API
- Express ve diğer çerçevelerle kolay entegrasyon
- Akış için WebSocket desteği

Tam bir JavaScript uygulama örneği için, örnekler dizininde [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) dosyasına bakın.

## Örnek Uygulama: Python Uygulaması

Python SDK, MCP uygulaması için mükemmel ML çerçeve entegrasyonları ile Pythonik bir yaklaşım sunar.

### Temel Özellikler

- asyncio ile Async/await desteği
- Flask ve FastAPI entegrasyonu
- Basit araç kaydı
- Popüler ML kütüphaneleri ile yerel entegrasyon

Tam bir Python uygulama örneği için, örnekler dizininde [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) dosyasına bakın.

## API Yönetimi

Azure API Yönetimi, MCP Sunucularını nasıl güvence altına alabileceğimize dair harika bir çözümdür. Fikir, MCP Sunucunuzun önüne bir Azure API Yönetimi örneği yerleştirmek ve oran sınırlama, belirteç yönetimi, izleme, yük dengeleme, güvenlik gibi muhtemelen isteyeceğiniz özellikleri onun yönetmesine izin vermektir.

### Azure Örneği

İşte tam da bunu yapan bir Azure Örneği, yani [bir MCP Sunucusu oluşturmak ve Azure API Yönetimi ile güvence altına almak](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Aşağıdaki görselde yetkilendirme akışının nasıl gerçekleştiğini görün:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Önceki görselde, aşağıdakiler gerçekleşir:

- Kimlik Doğrulama/Yetkilendirme Microsoft Entra kullanılarak gerçekleşir.
- Azure API Yönetimi bir geçit görevi görür ve trafiği yönlendirmek ve yönetmek için politikalar kullanır.
- Azure Monitor, daha fazla analiz için tüm istekleri kaydeder.

#### Yetkilendirme Akışı

Yetkilendirme akışına daha ayrıntılı bakalım:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP Yetkilendirme Spesifikasyonu

[MCP Yetkilendirme spesifikasyonu](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) hakkında daha fazla bilgi edinin.

## Uzak MCP Sunucusunu Azure'a Dağıtma

Daha önce bahsettiğimiz örneği dağıtabileceğimizi görelim:

1. Depoyu klonlayın

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. `Microsoft.App`'ı kaydedin ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` bir süre sonra kaydın tamamlanıp tamamlanmadığını kontrol etmek için.

2. API yönetim hizmetini, işlev uygulamasını (kod ile) ve diğer gerekli Azure kaynaklarını sağlamak için bu [azd](https://aka.ms/azd) komutunu çalıştırın

    ```shell
    azd up
    ```

    Bu komutlar tüm bulut kaynaklarını Azure'a dağıtmalıdır.

### Sunucunuzu MCP Inspector ile Test Etme

1. **Yeni bir terminal penceresinde**, MCP Inspector'ı yükleyin ve çalıştırın

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Uygulama tarafından gösterilen URL'den MCP Inspector web uygulamasını yüklemek için CTRL tıklayın (örneğin, http://127.0.0.1:6274/#resources)
1. Taşıma türünü `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` olarak ayarlayın ve **Bağlan**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Araçları Listele**. Bir araca tıklayın ve **Aracı Çalıştır**.  

Tüm adımlar başarılı olduysa, artık MCP sunucusuna bağlı olmalı ve bir aracı çağırabilmiş olmalısınız.

## Azure için MCP Sunucuları 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Bu depo setleri, Azure Functions kullanarak Python, C# .NET veya Node/TypeScript ile özel uzak MCP (Model Bağlam Protokolü) sunucuları oluşturmak ve dağıtmak için hızlı başlangıç şablonlarıdır.

Örnekler, geliştiricilerin aşağıdakileri yapmasına olanak tanıyan eksiksiz bir çözüm sunar:

- Yerel olarak oluşturma ve çalıştırma: Yerel bir makinede MCP sunucusu geliştirme ve hata ayıklama
- Azure'a dağıtma: Basit bir azd up komutuyla buluta kolayca dağıtma
- İstemcilerden bağlanma: VS Code'un Copilot ajan modu ve MCP Inspector aracı dahil olmak üzere çeşitli istemcilerden MCP sunucusuna bağlanma

### Temel Özellikler:

- Tasarım gereği güvenlik: MCP sunucusu anahtarlar ve HTTPS kullanılarak güvence altına alınır
- Kimlik doğrulama seçenekleri: Yerleşik kimlik doğrulama ve/veya API Yönetimi kullanarak OAuth desteği
- Ağ izolasyonu: Azure Sanal Ağları (VNET) kullanarak ağ izolasyonu sağlar
- Sunucusuz mimari: Ölçeklenebilir, olay tabanlı yürütme için Azure Functions kullanır
- Yerel geliştirme: Kapsamlı yerel geliştirme ve hata ayıklama desteği
- Basit dağıtım: Azure'a dağıtım sürecini kolaylaştırır

Depo, üretime hazır bir MCP sunucusu uygulamasıyla hızlı bir şekilde başlamanızı sağlamak için gerekli tüm yapılandırma dosyalarını, kaynak kodunu ve altyapı tanımlarını içerir.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python ile Azure Functions kullanarak MCP'nin örnek uygulaması

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET ile Azure Functions kullanarak MCP'nin örnek uygulaması

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript ile Azure Functions kullanarak MCP'nin örnek uygulaması.

## Temel Çıkarımlar

- MCP SDK'ları, sağlam MCP çözümleri uygulamak için dil bazlı araçlar sağlar
- Hata ayıklama ve test süreci, güvenilir MCP uygulamaları için kritik öneme sahiptir
- Yeniden kullanılabilir istem şablonları, tutarlı AI etkileşimlerini mümkün kılar
- İyi tasarlanmış iş akışları, birden fazla aracı kullanarak karmaşık görevleri organize edebilir
- MCP çözümlerini uygulamak, güvenlik, performans ve hata yönetimi konularını dikkate almayı gerektirir

## Alıştırma

Kendi alanınızdaki gerçek bir sorunu ele alan pratik bir MCP iş akışı tasarlayın:

1. Bu sorunu çözmek için faydalı olacak 3-4 araç belirleyin
2. Bu araçların nasıl etkileşime girdiğini gösteren bir iş akışı diyagramı oluşturun
3. Tercih ettiğiniz dili kullanarak araçlardan birinin temel bir sürümünü uygulayın
4. Modelin aracınızı etkili bir şekilde kullanmasına yardımcı olacak bir istem şablonu oluşturun

## Ek Kaynaklar

---

Sonraki: [Gelişmiş Konular](../05-AdvancedTopics/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çabalasak da, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Orijinal belgenin kendi dilindeki hali yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.