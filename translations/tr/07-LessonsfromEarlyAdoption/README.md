<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:18:20+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tr"
}
-->
# Erken Benimseyenlerden Alınan Dersler

## Genel Bakış

Bu ders, erken benimseyenlerin Model Context Protocol (MCP) kullanarak gerçek dünya sorunlarını nasıl çözdüğünü ve endüstrilerde yeniliği nasıl yönlendirdiğini inceliyor. Ayrıntılı vaka incelemeleri ve uygulamalı projeler aracılığıyla MCP'nin büyük dil modellerini, araçları ve kurumsal verileri tek bir çerçevede birleştirerek standart, güvenli ve ölçeklenebilir AI entegrasyonunu nasıl sağladığını göreceksiniz. MCP tabanlı çözümler tasarlama ve inşa etme konusunda pratik deneyim kazanacak, kanıtlanmış uygulama modellerinden öğrenecek ve MCP'yi üretim ortamlarında dağıtmanın en iyi uygulamalarını keşfedeceksiniz. Ders ayrıca MCP teknolojisinin ve gelişen ekosisteminin ön saflarında kalmanıza yardımcı olacak yeni eğilimleri, gelecek yönleri ve açık kaynak kaynaklarını vurguluyor.

## Öğrenme Hedefleri

- Farklı endüstrilerdeki gerçek dünya MCP uygulamalarını analiz etme
- Tam MCP tabanlı uygulamalar tasarlama ve inşa etme
- MCP teknolojisindeki yeni eğilimleri ve gelecek yönlerini keşfetme
- Gerçek geliştirme senaryolarında en iyi uygulamaları uygulama

## Gerçek Dünya MCP Uygulamaları

### Vaka Çalışması 1: Kurumsal Müşteri Destek Otomasyonu

Bir çok uluslu şirket, müşteri destek sistemleri arasında AI etkileşimlerini standartlaştırmak için MCP tabanlı bir çözüm uyguladı. Bu onlara şunları sağladı:

- Birden fazla LLM sağlayıcısı için birleşik bir arayüz oluşturma
- Departmanlar arasında tutarlı talimat yönetimi sağlama
- Güçlü güvenlik ve uyumluluk kontrolleri uygulama
- Belirli ihtiyaçlara göre farklı AI modelleri arasında kolay geçiş yapma

**Teknik Uygulama:**
```python
# Python MCP server implementation for customer support
import logging
import asyncio
from modelcontextprotocol import create_server, ServerConfig
from modelcontextprotocol.server import MCPServer
from modelcontextprotocol.transports import create_http_transport
from modelcontextprotocol.resources import ResourceDefinition
from modelcontextprotocol.prompts import PromptDefinition
from modelcontextprotocol.tool import ToolDefinition

# Configure logging
logging.basicConfig(level=logging.INFO)

async def main():
    # Create server configuration
    config = ServerConfig(
        name="Enterprise Customer Support Server",
        version="1.0.0",
        description="MCP server for handling customer support inquiries"
    )
    
    # Initialize MCP server
    server = create_server(config)
    
    # Register knowledge base resources
    server.resources.register(
        ResourceDefinition(
            name="customer_kb",
            description="Customer knowledge base documentation"
        ),
        lambda params: get_customer_documentation(params)
    )
    
    # Register prompt templates
    server.prompts.register(
        PromptDefinition(
            name="support_template",
            description="Templates for customer support responses"
        ),
        lambda params: get_support_templates(params)
    )
    
    # Register support tools
    server.tools.register(
        ToolDefinition(
            name="ticketing",
            description="Create and update support tickets"
        ),
        handle_ticketing_operations
    )
    
    # Start server with HTTP transport
    transport = create_http_transport(port=8080)
    await server.run(transport)

if __name__ == "__main__":
    asyncio.run(main())
```

**Sonuçlar:** Model maliyetlerinde %30 azalma, yanıt tutarlılığında %45 iyileşme ve küresel operasyonlarda artırılmış uyumluluk.

### Vaka Çalışması 2: Sağlık Tanı Yardımcısı

Bir sağlık hizmeti sağlayıcısı, hassas hasta verilerinin korunmasını sağlarken birden fazla uzmanlaşmış tıbbi AI modelini entegre etmek için MCP altyapısı geliştirdi:

- Genel ve uzman tıbbi modeller arasında sorunsuz geçiş
- Katı gizlilik kontrolleri ve denetim izleri
- Mevcut Elektronik Sağlık Kaydı (EHR) sistemleriyle entegrasyon
- Tıbbi terminoloji için tutarlı talimat mühendisliği

**Teknik Uygulama:**
```csharp
// C# MCP host application implementation in healthcare application
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.SDK.Client;
using ModelContextProtocol.SDK.Security;
using ModelContextProtocol.SDK.Resources;

public class DiagnosticAssistant
{
    private readonly MCPHostClient _mcpClient;
    private readonly PatientContext _patientContext;
    
    public DiagnosticAssistant(PatientContext patientContext)
    {
        _patientContext = patientContext;
        
        // Configure MCP client with healthcare-specific settings
        var clientOptions = new ClientOptions
        {
            Name = "Healthcare Diagnostic Assistant",
            Version = "1.0.0",
            Security = new SecurityOptions
            {
                Encryption = EncryptionLevel.Medical,
                AuditEnabled = true
            }
        };
        
        _mcpClient = new MCPHostClientBuilder()
            .WithOptions(clientOptions)
            .WithTransport(new HttpTransport("https://healthcare-mcp.example.org"))
            .WithAuthentication(new HIPAACompliantAuthProvider())
            .Build();
    }
    
    public async Task<DiagnosticSuggestion> GetDiagnosticAssistance(
        string symptoms, string patientHistory)
    {
        // Create request with appropriate resources and tool access
        var resourceRequest = new ResourceRequest
        {
            Name = "patient_records",
            Parameters = new Dictionary<string, object>
            {
                ["patientId"] = _patientContext.PatientId,
                ["requestingProvider"] = _patientContext.ProviderId
            }
        };
        
        // Request diagnostic assistance using appropriate prompt
        var response = await _mcpClient.SendPromptRequestAsync(
            promptName: "diagnostic_assistance",
            parameters: new Dictionary<string, object>
            {
                ["symptoms"] = symptoms,
                patientHistory = patientHistory,
                relevantGuidelines = _patientContext.GetRelevantGuidelines()
            });
            
        return DiagnosticSuggestion.FromMCPResponse(response);
    }
}
```

**Sonuçlar:** Tam HIPAA uyumluluğu sağlarken doktorlar için geliştirilmiş tanı önerileri ve sistemler arasında bağlam değiştirmede önemli azalma.

### Vaka Çalışması 3: Finansal Hizmetler Risk Analizi

Bir finans kurumu, farklı departmanlarda risk analiz süreçlerini standartlaştırmak için MCP uyguladı:

- Kredi riski, dolandırıcılık tespiti ve yatırım risk modelleri için birleşik bir arayüz oluşturdu
- Katı erişim kontrolleri ve model sürümleme uyguladı
- Tüm AI önerilerinin denetlenebilirliğini sağladı
- Çeşitli sistemler arasında tutarlı veri formatlamasını korudu

**Teknik Uygulama:**
```java
// Java MCP server for financial risk assessment
import org.mcp.server.*;
import org.mcp.security.*;

public class FinancialRiskMCPServer {
    public static void main(String[] args) {
        // Create MCP server with financial compliance features
        MCPServer server = new MCPServerBuilder()
            .withModelProviders(
                new ModelProvider("risk-assessment-primary", new AzureOpenAIProvider()),
                new ModelProvider("risk-assessment-audit", new LocalLlamaProvider())
            )
            .withPromptTemplateDirectory("./compliance/templates")
            .withAccessControls(new SOCCompliantAccessControl())
            .withDataEncryption(EncryptionStandard.FINANCIAL_GRADE)
            .withVersionControl(true)
            .withAuditLogging(new DatabaseAuditLogger())
            .build();
            
        server.addRequestValidator(new FinancialDataValidator());
        server.addResponseFilter(new PII_RedactionFilter());
        
        server.start(9000);
        
        System.out.println("Financial Risk MCP Server running on port 9000");
    }
}
```

**Sonuçlar:** Artırılmış düzenleyici uyumluluk, %40 daha hızlı model dağıtım döngüleri ve departmanlar arasında geliştirilmiş risk değerlendirme tutarlılığı.

### Vaka Çalışması 4: Microsoft Playwright MCP Sunucusu ile Tarayıcı Otomasyonu

Microsoft, Model Context Protocol aracılığıyla güvenli ve standartlaştırılmış tarayıcı otomasyonunu sağlamak için [Playwright MCP sunucusunu](https://github.com/microsoft/playwright-mcp) geliştirdi. Bu çözüm, AI ajanları ve LLM'lerin web tarayıcılarıyla kontrol edilen, denetlenebilir ve genişletilebilir bir şekilde etkileşimde bulunmasına olanak tanır—otomatik web testi, veri çıkarımı ve uçtan uca iş akışları gibi kullanım durumlarını mümkün kılar.

- Tarayıcı otomasyon yeteneklerini (navigasyon, form doldurma, ekran görüntüsü alma vb.) MCP araçları olarak sunar
- Yetkisiz işlemleri önlemek için katı erişim kontrolleri ve sandboxing uygular
- Tüm tarayıcı etkileşimleri için ayrıntılı denetim günlükleri sağlar
- Ajan odaklı otomasyon için Azure OpenAI ve diğer LLM sağlayıcılarıyla entegrasyonu destekler

**Teknik Uygulama:**
```typescript
// TypeScript: Registering Playwright browser automation tools in an MCP server
import { createServer, ToolDefinition } from 'modelcontextprotocol';
import { launch } from 'playwright';

const server = createServer({
  name: 'Playwright MCP Server',
  version: '1.0.0',
  description: 'MCP server for browser automation using Playwright'
});

// Register a tool for navigating to a URL and capturing a screenshot
server.tools.register(
  new ToolDefinition({
    name: 'navigate_and_screenshot',
    description: 'Navigate to a URL and capture a screenshot',
    parameters: {
      url: { type: 'string', description: 'The URL to visit' }
    }
  }),
  async ({ url }) => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto(url);
    const screenshot = await page.screenshot();
    await browser.close();
    return { screenshot };
  }
);

// Start the MCP server
server.listen(8080);
```

**Sonuçlar:**  
- AI ajanları ve LLM'ler için güvenli, programlanabilir tarayıcı otomasyonu sağlandı
- Web uygulamaları için manuel test çabası azaltıldı ve test kapsamı artırıldı
- Kurumsal ortamlarda tarayıcı tabanlı araç entegrasyonu için yeniden kullanılabilir, genişletilebilir bir çerçeve sağlandı

**Referanslar:**  
- [Playwright MCP Sunucu GitHub Deposu](https://github.com/microsoft/playwright-mcp)
- [Microsoft AI ve Otomasyon Çözümleri](https://azure.microsoft.com/en-us/products/ai-services/)

### Vaka Çalışması 5: Azure MCP – Hizmet Olarak Kurumsal Düzeyde Model Context Protocol

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)), Microsoft'un ölçeklenebilir, güvenli ve uyumlu MCP sunucu yeteneklerini bulut hizmeti olarak sağlayan yönetilen, kurumsal düzeyde Model Context Protocol uygulamasıdır. Azure MCP, kuruluşların MCP sunucularını Azure AI, veri ve güvenlik hizmetleri ile hızla dağıtmasını, yönetmesini ve entegre etmesini sağlayarak operasyonel yükü azaltır ve AI benimsemesini hızlandırır.

- Ölçekleme, izleme ve güvenlik ile yerleşik yönetilen MCP sunucu barındırma
- Azure OpenAI, Azure AI Arama ve diğer Azure hizmetleri ile yerel entegrasyon
- Microsoft Entra ID aracılığıyla kurumsal kimlik doğrulama ve yetkilendirme
- Özel araçlar, talimat şablonları ve kaynak bağlayıcıları için destek
- Kurumsal güvenlik ve düzenleyici gerekliliklere uyumluluk

**Teknik Uygulama:**
```yaml
# Example: Azure MCP server deployment configuration (YAML)
apiVersion: mcp.microsoft.com/v1
kind: McpServer
metadata:
  name: enterprise-mcp-server
spec:
  modelProviders:
    - name: azure-openai
      type: AzureOpenAI
      endpoint: https://<your-openai-resource>.openai.azure.com/
      apiKeySecret: <your-azure-keyvault-secret>
  tools:
    - name: document_search
      type: AzureAISearch
      endpoint: https://<your-search-resource>.search.windows.net/
      apiKeySecret: <your-azure-keyvault-secret>
  authentication:
    type: EntraID
    tenantId: <your-tenant-id>
  monitoring:
    enabled: true
    logAnalyticsWorkspace: <your-log-analytics-id>
```

**Sonuçlar:**  
- Kurumsal AI projeleri için değer kazanma süresi, hazır kullanıma uygun, uyumlu MCP sunucu platformu sağlayarak azaltıldı
- LLM'lerin, araçların ve kurumsal veri kaynaklarının entegrasyonu basitleştirildi
- MCP iş yükleri için artırılmış güvenlik, gözlemlenebilirlik ve operasyonel verimlilik

**Referanslar:**  
- [Azure MCP Dokümantasyonu](https://aka.ms/azmcp)
- [Azure AI Hizmetleri](https://azure.microsoft.com/en-us/products/ai-services/)

## Uygulamalı Projeler

### Proje 1: Çok Sağlayıcılı MCP Sunucusu Oluşturma

**Amaç:** Belirli kriterlere göre birden fazla AI model sağlayıcısına istekleri yönlendirebilen bir MCP sunucusu oluşturun.

**Gereksinimler:**
- En az üç farklı model sağlayıcısını destekleme (örneğin, OpenAI, Anthropic, yerel modeller)
- İstek meta verilerine dayalı bir yönlendirme mekanizması uygulama
- Sağlayıcı kimlik bilgilerini yönetmek için bir yapılandırma sistemi oluşturma
- Performansı ve maliyetleri optimize etmek için önbellekleme ekleme
- Kullanımı izlemek için basit bir kontrol paneli oluşturma

**Uygulama Adımları:**
1. Temel MCP sunucu altyapısını kurun
2. Her AI model hizmeti için sağlayıcı adaptörlerini uygulayın
3. İstek özelliklerine dayalı yönlendirme mantığını oluşturun
4. Sık istekler için önbellekleme mekanizmalarını ekleyin
5. İzleme kontrol panelini geliştirin
6. Çeşitli istek kalıpları ile test edin

**Teknolojiler:** Tercihinize göre Python (.NET/Java/Python), önbellekleme için Redis ve kontrol paneli için basit bir web çerçevesi seçin.

### Proje 2: Kurumsal Talimat Yönetim Sistemi

**Amaç:** Bir organizasyon genelinde talimat şablonlarını yönetmek, sürümlemek ve dağıtmak için MCP tabanlı bir sistem geliştirin.

**Gereksinimler:**
- Talimat şablonları için merkezi bir depo oluşturma
- Sürümleme ve onay iş akışlarını uygulama
- Örnek girişlerle şablon test etme yetenekleri oluşturma
- Rol tabanlı erişim kontrolleri geliştirme
- Şablon alma ve dağıtımı için bir API oluşturma

**Uygulama Adımları:**
1. Şablon depolama için veritabanı şemasını tasarlayın
2. Şablon CRUD işlemleri için temel API'yi oluşturun
3. Sürümleme sistemini uygulayın
4. Onay iş akışını oluşturun
5. Test çerçevesini geliştirin
6. Yönetim için basit bir web arayüzü oluşturun
7. Bir MCP sunucusuyla entegre edin

**Teknolojiler:** Arka uç çerçevesi, SQL veya NoSQL veritabanı ve yönetim arayüzü için bir ön uç çerçevesi seçiminize göre.

### Proje 3: MCP Tabanlı İçerik Üretim Platformu

**Amaç:** Farklı içerik türleri arasında tutarlı sonuçlar sağlamak için MCP'yi kullanan bir içerik üretim platformu oluşturun.

**Gereksinimler:**
- Birden fazla içerik formatını destekleme (blog yazıları, sosyal medya, pazarlama metni)
- Özelleştirme seçenekleri ile şablon tabanlı üretim uygulama
- İçerik inceleme ve geri bildirim sistemi oluşturma
- İçerik performans metriklerini izleme
- İçerik sürümleme ve iterasyon destekleme

**Uygulama Adımları:**
1. MCP istemci altyapısını kurun
2. Farklı içerik türleri için şablonlar oluşturun
3. İçerik üretim hattını oluşturun
4. İnceleme sistemini uygulayın
5. Metrik izleme sistemini geliştirin
6. Şablon yönetimi ve içerik üretimi için bir kullanıcı arayüzü oluşturun

**Teknolojiler:** Tercih ettiğiniz programlama dili, web çerçevesi ve veritabanı sistemi.

## MCP Teknolojisi İçin Gelecek Yönler

### Yeni Eğilimler

1. **Çok Modlu MCP**
   - MCP'nin görüntü, ses ve video modelleri ile etkileşimleri standartlaştırmak için genişletilmesi
   - Çapraz modal akıl yürütme yeteneklerinin geliştirilmesi
   - Farklı modaliteler için standartlaştırılmış talimat formatları

2. **Federasyon MCP Altyapısı**
   - Kuruluşlar arasında kaynakları paylaşabilen dağıtılmış MCP ağları
   - Güvenli model paylaşımı için standartlaştırılmış protokoller
   - Gizlilik koruyucu hesaplama teknikleri

3. **MCP Pazaryerleri**
   - MCP şablonları ve eklentilerini paylaşmak ve paraya çevirmek için ekosistemler
   - Kalite güvence ve sertifikasyon süreçleri
   - Model pazaryerleri ile entegrasyon

4. **Kenar Bilişim için MCP**
   - Kaynak sınırlı kenar cihazlar için MCP standartlarının uyarlanması
   - Düşük bant genişliği ortamları için optimize edilmiş protokoller
   - IoT ekosistemleri için özel MCP uygulamaları

5. **Düzenleyici Çerçeveler**
   - Düzenleyici uyumluluk için MCP uzantılarının geliştirilmesi
   - Standartlaştırılmış denetim izleri ve açıklanabilirlik arayüzleri
   - Gelişmekte olan AI yönetim çerçeveleri ile entegrasyon

### Microsoft'tan MCP Çözümleri

Microsoft ve Azure, geliştiricilerin çeşitli senaryolarda MCP'yi uygulamalarına yardımcı olmak için birkaç açık kaynak deposu geliştirdi:

#### Microsoft Organizasyonu
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Tarayıcı otomasyonu ve test için Playwright MCP sunucusu
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Yerel test ve topluluk katkısı için OneDrive MCP sunucu uygulaması

#### Azure-Samples Organizasyonu
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure üzerinde MCP sunucuları oluşturmak ve entegre etmek için örnekler, araçlar ve kaynaklar bağlantıları
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Mevcut Model Context Protocol spesifikasyonu ile kimlik doğrulamasını gösteren referans MCP sunucuları
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions'ta Remote MCP Sunucu uygulamaları için dil spesifik repo bağlantıları ile iniş sayfası
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python kullanarak özel remote MCP sunucuları oluşturmak ve dağıtmak için hızlı başlangıç şablonu
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - .NET/C# kullanarak özel remote MCP sunucuları oluşturmak ve dağıtmak için hızlı başlangıç şablonu
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - TypeScript kullanarak özel remote MCP sunucuları oluşturmak ve dağıtmak için hızlı başlangıç şablonu
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Python kullanarak Remote MCP sunucularına AI Gateway olarak Azure API Yönetimi
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - MCP yeteneklerini içeren APIM ❤️ AI deneyleri, Azure OpenAI ve AI Foundry ile entegrasyon

Bu depolar, farklı programlama dilleri ve Azure hizmetleri üzerinde Model Context Protocol ile çalışma için çeşitli uygulamalar, şablonlar ve kaynaklar sağlar. Temel sunucu uygulamalarından kimlik doğrulama, bulut dağıtımı ve kurumsal entegrasyon senaryolarına kadar bir dizi kullanım durumunu kapsarlar.

#### MCP Kaynaklar Dizini

Resmi Microsoft MCP deposundaki [MCP Kaynaklar dizini](https://github.com/microsoft/mcp/tree/main/Resources), Model Context Protocol sunucularıyla kullanılmak üzere örnek kaynaklar, talimat şablonları ve araç tanımları içeren küratörlü bir koleksiyon sağlar. Bu dizin, geliştiricilerin MCP ile hızla başlamalarına yardımcı olmak için yeniden kullanılabilir yapı taşları ve en iyi uygulama örnekleri sunar:

- **Talimat Şablonları:** Kendi MCP sunucu uygulamalarınız için uyarlanabilecek yaygın AI görevleri ve senaryoları için hazır kullanıma uygun talimat şablonları.
- **Araç Tanımları:** Farklı MCP sunucuları arasında araç entegrasyonu ve çağrımını standartlaştırmak için örnek araç şemaları ve meta verileri.
- **Kaynak Örnekleri:** MCP çerçevesi içinde veri kaynaklarına, API'lere ve harici hizmetlere bağlanmak için örnek kaynak tanımları.
- **Referans Uygulamalar:** Gerçek dünya MCP projelerinde kaynakları, talimatları ve araçları nasıl yapılandırıp organize edeceğinizi gösteren pratik örnekler.

Bu kaynaklar, geliştirmeyi hızlandırır, standartlaşmayı teşvik eder ve MCP tabanlı çözümler oluştururken ve dağıtırken en iyi uygulamaların sağlanmasına yardımcı olur.

#### MCP Kaynaklar Dizini
- [MCP Kaynaklar (Örnek Talimatlar, Araçlar ve Kaynak Tanımları)](https://github.com/microsoft/mcp/tree/main/Resources)

### Araştırma Fırsatları

- MCP çerçeveleri içinde etkili talimat optimizasyon teknikleri
- Çok kiracılı MCP dağıtımları için güvenlik modelleri
- Farklı MCP uygulamaları arasında performans karşılaştırması
- MCP sunucuları için resmi doğrulama yöntemleri

## Sonuç

Model Context Protocol (MCP), endüstrilerde standart, güvenli ve birlikte çalışabilir AI entegrasyonunun geleceğini hızla şekillendiriyor. Bu dersteki vaka çalışmaları ve uygulamalı projeler aracılığıyla, Microsoft ve Azure dahil olmak üzere erken benimseyenlerin MCP'yi gerçek dünya zorluklarını çözmek, AI benimsemesini hızlandırmak ve uyumluluk, güvenlik ve ölçeklenebilirlik sağlamak için nasıl kullandığını gördünüz. MCP'nin modüler yaklaşımı, kuruluşların büyük dil modellerini, araçları ve kurumsal verileri birleşik, denetlenebilir bir çerçevede bağlamasına olanak tanır. MCP gelişmeye devam ettikçe, toplulukla etkileşimde bulunmak, açık kaynak kaynaklarını keşfetmek ve en iyi uygulamaları uygulamak, sağlam, geleceğe hazır AI çözümleri oluşturmanın anahtarı olacaktır.

## Ek Kaynaklar

- [MCP GitHub Deposu (Microsoft)](https://github.com/microsoft/mcp)
- [MCP Kaynaklar Dizini (Örnek Tal
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI ve Otomasyon Çözümleri](https://azure.microsoft.com/en-us/products/ai-services/)

## Alıştırmalar

1. Vaka çalışmalarından birini analiz edin ve alternatif bir uygulama yaklaşımı önerin.
2. Proje fikirlerinden birini seçin ve ayrıntılı bir teknik özellik oluşturun.
3. Vaka çalışmalarında ele alınmayan bir sektörü araştırın ve MCP'nin bu sektördeki özel zorlukları nasıl ele alabileceğini özetleyin.
4. Gelecek yönlerinden birini keşfedin ve bunu destekleyecek yeni bir MCP uzantısı için bir konsept oluşturun.

Sonraki: [En İyi Uygulamalar](../08-BestPractices/README.md)

**Feragatname**:  
Bu belge, [Co-op Translator](https://github.com/Azure/co-op-translator) adlı AI çeviri hizmeti kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belgenin kendi dilindeki hali yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından doğabilecek yanlış anlama veya yanlış yorumlamalardan sorumlu değiliz.