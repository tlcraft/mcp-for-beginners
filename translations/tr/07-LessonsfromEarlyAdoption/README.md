<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T21:27:12+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tr"
}
-->
# Erken Benimseyenlerden Dersler

## Genel Bakış

Bu ders, erken benimseyenlerin Model Context Protocol (MCP) kullanarak gerçek dünya problemlerini nasıl çözdüğünü ve sektörler genelinde yeniliği nasıl teşvik ettiğini inceliyor. Detaylı vaka çalışmaları ve uygulamalı projeler aracılığıyla, MCP'nin büyük dil modelleri, araçlar ve kurumsal verileri tek bir çatı altında standart, güvenli ve ölçeklenebilir şekilde entegre etmeyi nasıl sağladığını göreceksiniz. MCP tabanlı çözümler tasarlama ve geliştirme konusunda pratik deneyim kazanacak, kanıtlanmış uygulama kalıplarından öğrenecek ve MCP'nin üretim ortamlarında konuşlandırılması için en iyi uygulamaları keşfedeceksiniz. Ders ayrıca ortaya çıkan trendleri, gelecekteki yönelimleri ve açık kaynak kaynakları vurgulayarak MCP teknolojisi ve gelişen ekosisteminde önde kalmanıza yardımcı olacak.

## Öğrenme Hedefleri

- Farklı sektörlerdeki gerçek dünya MCP uygulamalarını analiz etmek  
- Tamamlanmış MCP tabanlı uygulamalar tasarlayıp geliştirmek  
- MCP teknolojisindeki yeni trendleri ve gelecekteki yönelimleri keşfetmek  
- Gerçek geliştirme senaryolarında en iyi uygulamaları uygulamak  

## Gerçek Dünya MCP Uygulamaları

### Vaka Çalışması 1: Kurumsal Müşteri Destek Otomasyonu

Çok uluslu bir şirket, müşteri destek sistemlerinde AI etkileşimlerini standartlaştırmak için MCP tabanlı bir çözüm uyguladı. Bu sayede:

- Birden fazla LLM sağlayıcısı için birleşik bir arayüz oluşturuldu  
- Departmanlar arasında tutarlı prompt yönetimi sağlandı  
- Güçlü güvenlik ve uyumluluk kontrolleri uygulandı  
- Belirli ihtiyaçlara göre farklı AI modelleri arasında kolay geçiş yapıldı  

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

### Vaka Çalışması 2: Sağlık Tanı Asistanı

Bir sağlık hizmeti sağlayıcısı, birden fazla uzmanlaşmış tıbbi AI modelini entegre etmek ve hassas hasta verilerini korumak için MCP altyapısı geliştirdi:

- Genel ve uzman tıbbi modeller arasında kesintisiz geçiş  
- Katı gizlilik kontrolleri ve denetim kayıtları  
- Mevcut Elektronik Sağlık Kayıtları (EHR) sistemleri ile entegrasyon  
- Tıbbi terminoloji için tutarlı prompt mühendisliği  

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

**Sonuçlar:** Hekimler için tanı önerilerinde iyileşme, tam HIPAA uyumluluğu ve sistemler arası bağlam geçişlerinde önemli azalma.

### Vaka Çalışması 3: Finansal Hizmetlerde Risk Analizi

Bir finans kurumu, farklı departmanlar arasında risk analiz süreçlerini standartlaştırmak için MCP uyguladı:

- Kredi riski, dolandırıcılık tespiti ve yatırım riski modelleri için birleşik arayüz oluşturuldu  
- Katı erişim kontrolleri ve model versiyonlama uygulandı  
- Tüm AI önerilerinin denetlenebilirliği sağlandı  
- Farklı sistemler arasında tutarlı veri formatlama korundu  

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

**Sonuçlar:** Artırılmış düzenleyici uyumluluk, %40 daha hızlı model dağıtım döngüleri ve departmanlar arası risk değerlendirme tutarlılığında iyileşme.

### Vaka Çalışması 4: Microsoft Playwright MCP Sunucusu ile Tarayıcı Otomasyonu

Microsoft, Model Context Protocol üzerinden güvenli, standartlaştırılmış tarayıcı otomasyonu sağlamak için [Playwright MCP sunucusunu](https://github.com/microsoft/playwright-mcp) geliştirdi. Bu çözüm, AI ajanları ve LLM'lerin web tarayıcılarıyla kontrollü, denetlenebilir ve genişletilebilir şekilde etkileşim kurmasını sağlar—otomatik web testi, veri çıkarımı ve uçtan uca iş akışları gibi kullanım senaryolarını mümkün kılar.

- Tarayıcı otomasyon yeteneklerini (navigasyon, form doldurma, ekran görüntüsü alma vb.) MCP araçları olarak sunar  
- Yetkisiz işlemleri önlemek için katı erişim kontrolleri ve sandbox uygulaması yapar  
- Tüm tarayıcı etkileşimleri için ayrıntılı denetim kayıtları sağlar  
- Azure OpenAI ve diğer LLM sağlayıcıları ile ajan destekli otomasyon entegrasyonunu destekler  

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
- AI ajanları ve LLM'ler için güvenli, programlı tarayıcı otomasyonu sağlandı  
- Manuel test çabaları azaldı ve web uygulamalarında test kapsamı arttı  
- Kurumsal ortamlar için tarayıcı tabanlı araç entegrasyonu konusunda yeniden kullanılabilir, genişletilebilir bir çerçeve sunuldu  

**Referanslar:**  
- [Playwright MCP Server GitHub Deposu](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI ve Otomasyon Çözümleri](https://azure.microsoft.com/en-us/products/ai-services/)

### Vaka Çalışması 5: Azure MCP – Kurumsal Düzeyde Hizmet Olarak Model Context Protocol

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)), Microsoft’un Model Context Protocol’ün yönetilen, kurumsal düzeyde uygulaması olup, ölçeklenebilir, güvenli ve uyumlu MCP sunucu yeteneklerini bulut hizmeti olarak sunar. Azure MCP, kuruluşların MCP sunucularını Azure AI, veri ve güvenlik servisleriyle hızla dağıtmasına, yönetmesine ve entegre etmesine olanak tanır; operasyonel yükü azaltır ve AI benimsemesini hızlandırır.

- Yerleşik ölçeklendirme, izleme ve güvenlik ile tamamen yönetilen MCP sunucu barındırma  
- Azure OpenAI, Azure AI Search ve diğer Azure servisleri ile yerel entegrasyon  
- Microsoft Entra ID üzerinden kurumsal kimlik doğrulama ve yetkilendirme  
- Özel araçlar, prompt şablonları ve kaynak bağlayıcıları desteği  
- Kurumsal güvenlik ve düzenleyici gereksinimlere uyum  

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
- Kurumsal AI projeleri için hazır, uyumlu MCP sunucu platformu sağlayarak değer elde etme süresini kısalttı  
- LLM'ler, araçlar ve kurumsal veri kaynaklarının entegrasyonunu basitleştirdi  
- MCP iş yüklerinde güvenlik, gözlemlenebilirlik ve operasyonel verimliliği artırdı  

**Referanslar:**  
- [Azure MCP Dokümantasyonu](https://aka.ms/azmcp)  
- [Azure AI Servisleri](https://azure.microsoft.com/en-us/products/ai-services/)

## Vaka Çalışması 6: NLWeb  
MCP (Model Context Protocol), chatbotlar ve AI asistanlarının araçlarla etkileşim kurması için ortaya çıkan bir protokoldür. Her NLWeb örneği aynı zamanda bir MCP sunucusudur ve doğal dilde bir web sitesine soru sormak için kullanılan tek bir temel yöntem olan ask metodunu destekler. Dönen yanıt, web verilerini tanımlamak için yaygın kullanılan schema.org sözlüğünü kullanır. Kabaca MCP, NLWeb’in HTTP’nin HTML’ye olan ilişkisi gibidir. NLWeb, protokolleri, Schema.org formatlarını ve örnek kodları birleştirerek sitelerin bu uç noktaları hızlıca oluşturmasına yardımcı olur; bu da hem insanlar için konuşma arayüzleri hem de makineler için doğal ajanlar arası etkileşim sağlar.

NLWeb’in iki ayrı bileşeni vardır.  
- Bir site ile doğal dilde arayüz oluşturmak için çok basit bir protokol ve dönen yanıt için json ve schema.org formatını kullanan bir yapı. Daha fazla detay için REST API dokümantasyonuna bakınız.  
- (1) in basit bir uygulaması; ürünler, tarifler, gezilecek yerler, yorumlar gibi liste olarak soyutlanabilen siteler için mevcut işaretlemeyi kullanır. Bir dizi kullanıcı arayüzü bileşeni ile siteler içeriklerine kolayca konuşma arayüzleri sağlayabilir. Nasıl çalıştığı hakkında daha fazla bilgi için Life of a chat query dokümantasyonuna bakınız.  

**Referanslar:**  
- [Azure MCP Dokümantasyonu](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Vaka Çalışması 7: Foundry için MCP – Azure AI Ajanlarının Entegrasyonu

Azure AI Foundry MCP sunucuları, MCP’nin kurumsal ortamlarda AI ajanları ve iş akışlarını düzenlemek ve yönetmek için nasıl kullanılabileceğini gösterir. MCP’yi Azure AI Foundry ile entegre ederek, kuruluşlar ajan etkileşimlerini standartlaştırabilir, Foundry’nin iş akışı yönetimini kullanabilir ve güvenli, ölçeklenebilir dağıtımlar sağlayabilir. Bu yaklaşım hızlı prototipleme, sağlam izleme ve Azure AI servisleriyle kesintisiz entegrasyon sunar; bilgi yönetimi ve ajan değerlendirmesi gibi gelişmiş senaryoları destekler. Geliştiriciler, ajan boru hatlarını oluşturma, dağıtma ve izleme için birleşik bir arayüzden faydalanırken, BT ekipleri gelişmiş güvenlik, uyumluluk ve operasyonel verimlilik kazanır. Çözüm, AI benimsemesini hızlandırmak ve karmaşık ajan tabanlı süreçler üzerinde kontrol sağlamak isteyen kurumlar için idealdir.

**Referanslar:**  
- [MCP Foundry GitHub Deposu](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Azure AI Ajanlarının MCP ile Entegrasyonu (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Vaka Çalışması 8: Foundry MCP Playground – Deney ve Prototip Oluşturma

Foundry MCP Playground, MCP sunucuları ve Azure AI Foundry entegrasyonlarıyla denemeler yapmak için kullanıma hazır bir ortam sunar. Geliştiriciler, Azure AI Foundry Kataloğu ve Laboratuvarlarından kaynakları kullanarak AI modelleri ve ajan iş akışlarını hızla prototipleyebilir, test edebilir ve değerlendirebilir. Playground, kurulum sürecini kolaylaştırır, örnek projeler sunar ve iş birliğine dayalı geliştirmeyi destekler; böylece minimum yükle en iyi uygulamaları ve yeni senaryoları keşfetmek kolaylaşır. Özellikle fikir doğrulamak, deney paylaşmak ve öğrenmeyi hızlandırmak isteyen ekipler için faydalıdır. Giriş engelini düşürerek MCP ve Azure AI Foundry ekosisteminde yenilik ve topluluk katkılarını teşvik eder.

**Referanslar:**  
- [Foundry MCP Playground GitHub Deposu](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Uygulamalı Projeler

### Proje 1: Çok Sağlayıcılı MCP Sunucusu Oluşturma

**Amaç:** Belirli kriterlere göre istekleri birden fazla AI model sağlayıcısına yönlendirebilen bir MCP sunucusu oluşturmak.

**Gereksinimler:**  
- En az üç farklı model sağlayıcısını desteklemek (örneğin OpenAI, Anthropic, yerel modeller)  
- İstek meta verilerine dayalı yönlendirme mekanizması uygulamak  
- Sağlayıcı kimlik bilgilerini yönetmek için yapılandırma sistemi oluşturmak  
- Performans ve maliyet optimizasyonu için önbellekleme eklemek  
- Kullanım izleme için basit bir gösterge paneli geliştirmek  

**Uygulama Adımları:**  
1. Temel MCP sunucu altyapısını kurmak  
2. Her AI model servisi için sağlayıcı adaptörleri uygulamak  
3. İstek özelliklerine göre yönlendirme mantığını oluşturmak  
4. Sık istekler için önbellekleme mekanizmaları eklemek  
5. İzleme gösterge panelini geliştirmek  
6. Farklı istek desenleri ile test etmek  

**Teknolojiler:** Tercihinize göre Python (.NET/Java/Python), önbellekleme için Redis ve gösterge paneli için basit bir web çerçevesi.

### Proje 2: Kurumsal Prompt Yönetim Sistemi

**Amaç:** Kuruluş genelinde prompt şablonlarını yönetmek, sürümlemek ve dağıtmak için MCP tabanlı bir sistem geliştirmek.

**Gereksinimler:**  
- Prompt şablonları için merkezi bir depo oluşturmak  
- Sürümleme ve onay iş akışları uygulamak  
- Örnek girdilerle şablon test etme yetenekleri geliştirmek  
- Rol tabanlı erişim kontrolleri oluşturmak  
- Şablon alımı ve dağıtımı için API geliştirmek  

**Uygulama Adımları:**  
1. Şablon depolama için veritabanı şeması tasarlamak  
2. Şablon CRUD işlemleri için temel API oluşturmak  
3. Sürümleme sistemini uygulamak  
4. Onay iş akışını oluşturmak  
5. Test çerçevesini geliştirmek  
6. Yönetim için basit bir web arayüzü oluşturmak  
7. MCP sunucusuyla entegrasyon sağlamak  

**Teknolojiler:** Tercihinize göre backend çerçevesi, SQL veya NoSQL veritabanı ve yönetim arayüzü için frontend çerçevesi.

### Proje 3: MCP Tabanlı İçerik Üretim Platformu

**Amaç:** MCP kullanarak farklı içerik türlerinde tutarlı sonuçlar sunan bir içerik üretim platformu oluşturmak.

**Gereksinimler:**  
- Blog yazıları, sosyal medya, pazarlama metni gibi çeşitli içerik formatlarını desteklemek  
- Özelleştirme seçenekleriyle şablon tabanlı üretim uygulamak  
- İçerik inceleme ve geri bildirim sistemi oluşturmak  
- İçerik performans metriklerini takip etmek  
- İçerik sürümleme ve yineleme desteği sağlamak  

**Uygulama Adımları:**  
1. MCP istemci altyapısını kurmak  
2. Farklı içerik türleri için şablonlar oluşturmak  
3. İçerik üretim hattını geliştirmek  
4. İnceleme sistemini uygulamak  
5. Metrik takip sistemini geliştirmek  
6. Şablon yönetimi ve içerik üretimi için kullanıcı arayüzü oluşturmak  

**Teknolojiler:** Tercih ettiğiniz programlama dili, web çerçevesi ve veritabanı sistemi.

## MCP Teknolojisi İçin Gelecek Yönelimler

### Ortaya Çıkan Trendler

1. **Çok Modlu MCP**  
   - Görüntü, ses ve video modelleriyle etkileşimlerin standartlaştırılması  
   - Modlar arası akıl yürütme yeteneklerinin geliştirilmesi  
   - Farklı modlar için standart prompt formatları  

2. **Federated MCP Altyapısı**  
   - Kuruluşlar arasında kaynak paylaşabilen dağıtık MCP ağları  
   - Güvenli model paylaşımı için standart protokoller  
   - Gizliliği koruyan hesaplama teknikleri  

3. **MCP Pazar Yerleri**  
   - MCP şablonları ve eklentilerinin paylaşımı ve paraya dönüştürülmesi için ekosistemler  
   - Kalite güvencesi ve sertifikasyon süreçleri  
   - Model pazar yerleri ile entegrasyon  

4. **Edge Bilişim İçin MCP**  
   - Kaynak kısıtlı uç cihazlar için MCP standartlarının uyarlanması  
   - Düşük bant genişliği ortamları için optimize protokoller  
   - IoT ekosistemleri için özel MCP uygulamaları  

5. **Düzenleyici Çerçeveler**  
   - Düzenleyici uyumluluk için MCP genişletmelerinin geliştirilmesi  
   - Standart denetim kayıtları ve açıklanabilirlik arayüzleri  
   - Ortaya çıkan AI yönetişim çerçeveleri ile entegrasyon  

### Microsoft’tan MCP Çözümleri

Microsoft ve Azure, geliştiricilerin çeşitli senaryolarda MCP uygulamalarını gerçekleştirmesine yardımcı olmak için birçok açık kaynak deposu geliştirdi:

#### Microsoft Organizasyonu  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Tarayıcı otomasyonu ve testi için Playwright MCP sunucusu  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Yerel test ve topluluk katkısı için OneDrive MCP sunucu uygulaması  
3. [NLWeb](https://github.com/microsoft/NlWeb) - AI Web için temel katman oluşturmayı amaçlayan açık protokoller ve araçlar koleksiyonu  

#### Azure-Samples Organizasyonu  
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure’da MCP sunucuları oluşturmak ve entegre etmek için örnekler, araçlar ve kaynaklar  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Mevcut Model Context Protocol spesifikasyonu ile kimlik doğrulama gösteren referans MCP sunucuları  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions üzerinde Remote MCP Sunucu uygulamaları için başlangıç sayfası  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure Functions ile Python kullanarak özel Remote MCP sunucuları oluşturma ve dağıtma şablonu  
5. [remote-mcp-functions-dotnet
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Alıştırmalar

1. Vaka çalışmalarından birini analiz edin ve alternatif bir uygulama yaklaşımı önerin.
2. Proje fikirlerinden birini seçin ve detaylı bir teknik spesifikasyon oluşturun.
3. Vaka çalışmalarında ele alınmayan bir sektörü araştırın ve MCP’nin bu sektörün özel zorluklarını nasıl çözebileceğini özetleyin.
4. Gelecekteki yönlerden birini inceleyin ve bunu destekleyecek yeni bir MCP eklentisi için bir konsept oluşturun.

Sonraki: [Best Practices](../08-BestPractices/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.