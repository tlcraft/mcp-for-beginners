<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:13:07+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tr"
}
-->
# Erken Benimseyenlerden Dersler

## Genel Bakış

Bu ders, erken benimseyenlerin Model Context Protocol (MCP) kullanarak gerçek dünya sorunlarını nasıl çözdüğünü ve sektörler arası inovasyonu nasıl hızlandırdığını inceliyor. Ayrıntılı vaka çalışmaları ve uygulamalı projeler aracılığıyla, MCP'nin büyük dil modelleri, araçlar ve kurumsal verileri tek bir çatı altında standart, güvenli ve ölçeklenebilir şekilde entegre etmeyi nasıl sağladığını göreceksiniz. MCP tabanlı çözümler tasarlama ve inşa etme konusunda pratik deneyim kazanacak, kanıtlanmış uygulama kalıplarından öğrenecek ve MCP'nin üretim ortamlarında dağıtımı için en iyi uygulamaları keşfedeceksiniz. Ders ayrıca ortaya çıkan trendleri, gelecekteki yönelimleri ve açık kaynak kaynaklarını vurgulayarak MCP teknolojisi ve gelişen ekosisteminde öncü olmanıza yardımcı olacak.

## Öğrenme Hedefleri

- Farklı sektörlerdeki gerçek dünya MCP uygulamalarını analiz etmek  
- Tamamlanmış MCP tabanlı uygulamalar tasarlamak ve geliştirmek  
- MCP teknolojisindeki yeni trendleri ve gelecekteki yönelimleri keşfetmek  
- Gerçek geliştirme senaryolarında en iyi uygulamaları uygulamak  

## Gerçek Dünya MCP Uygulamaları

### Vaka Çalışması 1: Kurumsal Müşteri Destek Otomasyonu

Çok uluslu bir şirket, müşteri destek sistemlerinde AI etkileşimlerini standartlaştırmak için MCP tabanlı bir çözüm uyguladı. Bu sayede:

- Birden çok LLM sağlayıcısı için birleşik bir arayüz oluşturuldu  
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

**Sonuçlar:** Model maliyetlerinde %30 azalma, yanıt tutarlılığında %45 iyileşme ve küresel operasyonlarda geliştirilmiş uyumluluk.

### Vaka Çalışması 2: Sağlık Tanı Asistanı

Bir sağlık sağlayıcısı, birden fazla uzmanlaşmış tıbbi AI modelini entegre etmek için MCP altyapısı geliştirdi ve hassas hasta verilerinin korunmasını sağladı:

- Genel ve uzman tıbbi modeller arasında kesintisiz geçiş  
- Katı gizlilik kontrolleri ve denetim izleri  
- Mevcut Elektronik Sağlık Kayıtları (EHR) sistemleriyle entegrasyon  
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

**Sonuçlar:** Hekimler için iyileştirilmiş tanı önerileri, tam HIPAA uyumluluğu ve sistemler arası bağlam değiştirme süresinde önemli azalma.

### Vaka Çalışması 3: Finansal Hizmetlerde Risk Analizi

Bir finans kurumu, farklı departmanlarda risk analiz süreçlerini standartlaştırmak için MCP uyguladı:

- Kredi riski, dolandırıcılık tespiti ve yatırım riski modelleri için birleşik arayüz oluşturuldu  
- Katı erişim kontrolleri ve model versiyonlaması uygulandı  
- Tüm AI önerilerinin denetlenebilirliği sağlandı  
- Farklı sistemlerde tutarlı veri formatlama korundu  

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

**Sonuçlar:** Geliştirilmiş düzenleyici uyumluluk, %40 daha hızlı model dağıtım döngüleri ve departmanlar arası risk değerlendirme tutarlılığında iyileşme.

### Vaka Çalışması 4: Microsoft Playwright MCP Sunucusu ile Tarayıcı Otomasyonu

Microsoft, Model Context Protocol aracılığıyla güvenli ve standartlaştırılmış tarayıcı otomasyonunu mümkün kılan [Playwright MCP sunucusunu](https://github.com/microsoft/playwright-mcp) geliştirdi. Bu çözüm, AI ajanlarının ve LLM'lerin web tarayıcılarıyla kontrollü, denetlenebilir ve genişletilebilir şekilde etkileşim kurmasını sağlıyor; otomatik web testi, veri çıkarımı ve uçtan uca iş akışları gibi kullanım senaryolarını destekliyor.

- Tarayıcı otomasyon yeteneklerini (navigasyon, form doldurma, ekran görüntüsü alma vb.) MCP araçları olarak sunar  
- Yetkisiz işlemleri önlemek için katı erişim kontrolleri ve sandboxing uygular  
- Tüm tarayıcı etkileşimleri için ayrıntılı denetim kayıtları sağlar  
- Azure OpenAI ve diğer LLM sağlayıcılarıyla entegrasyonu destekler  

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
- AI ajanları ve LLM'ler için güvenli, programatik tarayıcı otomasyonu sağlandı  
- Manuel test çabaları azaldı ve web uygulamaları için test kapsamı arttı  
- Kurumsal ortamlarda tarayıcı tabanlı araç entegrasyonu için yeniden kullanılabilir, genişletilebilir bir çerçeve sunuldu  

**Referanslar:**  
- [Playwright MCP Server GitHub Deposu](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI ve Otomasyon Çözümleri](https://azure.microsoft.com/en-us/products/ai-services/)

### Vaka Çalışması 5: Azure MCP – Kurumsal Düzeyde Model Context Protocol Hizmeti

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)), Microsoft’un Model Context Protocol’ün yönetilen, kurumsal düzeyde uygulaması olup, ölçeklenebilir, güvenli ve uyumlu MCP sunucu özelliklerini bulut hizmeti olarak sunar. Azure MCP, kuruluşların MCP sunucularını hızla dağıtmasını, yönetmesini ve Azure AI, veri ve güvenlik hizmetleriyle entegre etmesini sağlar; operasyonel yükü azaltır ve AI benimsemesini hızlandırır.

- Yerleşik ölçeklendirme, izleme ve güvenlik özellikleriyle tam yönetilen MCP sunucu barındırma  
- Azure OpenAI, Azure AI Search ve diğer Azure hizmetleriyle doğal entegrasyon  
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
- Kurumsal AI projelerinde değer yaratma süresini kısalttı, kullanıma hazır ve uyumlu MCP sunucu platformu sağladı  
- LLM’ler, araçlar ve kurumsal veri kaynaklarının entegrasyonunu kolaylaştırdı  
- MCP iş yüklerinde güvenlik, gözlemlenebilirlik ve operasyonel verimliliği artırdı  

**Referanslar:**  
- [Azure MCP Dokümantasyonu](https://aka.ms/azmcp)  
- [Azure AI Hizmetleri](https://azure.microsoft.com/en-us/products/ai-services/)

## Vaka Çalışması 6: NLWeb

MCP (Model Context Protocol), Chatbotlar ve AI asistanlarının araçlarla etkileşim kurması için gelişmekte olan bir protokoldür. Her NLWeb örneği aynı zamanda bir MCP sunucusudur ve bir çekirdek yöntem olan ask'i destekler; bu yöntem, bir web sitesine doğal dilde soru sormak için kullanılır. Dönen yanıt, web verilerini tanımlamak için yaygın kullanılan bir sözlük olan schema.org'u kullanır. Basitçe söylemek gerekirse, MCP, NLWeb'in Http'nin HTML'ye olduğu gibi konumundadır. NLWeb, protokolleri, Schema.org formatlarını ve örnek kodları birleştirerek sitelerin bu uç noktaları hızlıca oluşturmasına yardımcı olur; bu, hem insanlara konuşma arayüzleriyle hem de makineler arasında doğal ajanlar arası etkileşimle fayda sağlar.

NLWeb'in iki ayrı bileşeni vardır:  
- Bir protokol, başlangıçta çok basit, bir site ile doğal dilde arayüz kurmak ve dönen cevabı json ve schema.org kullanarak formatlamak. REST API dokümantasyonuna bakınız.  
- (1) numaralı protokolün basit bir uygulaması, mevcut işaretlemeyi kullanan ve ürünler, tarifler, gezilecek yerler, incelemeler gibi liste şeklinde soyutlanabilen siteler için. Kullanıcı arayüzü widget setiyle birlikte, siteler içeriklerine kolayca konuşma arayüzleri sunabilir. Bu nasıl çalışır hakkında daha fazla bilgi için Life of a chat query dokümantasyonuna bakınız.  

**Referanslar:**  
- [Azure MCP Dokümantasyonu](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Vaka Çalışması 7: Foundry için MCP – Azure AI Ajanlarının Entegrasyonu

Azure AI Foundry MCP sunucuları, MCP'nin kurumsal ortamlarda AI ajanları ve iş akışlarını koordine etmek ve yönetmek için nasıl kullanılabileceğini gösterir. MCP'nin Azure AI Foundry ile entegrasyonu sayesinde, kuruluşlar ajan etkileşimlerini standartlaştırabilir, Foundry'nin iş akışı yönetimini kullanabilir ve güvenli, ölçeklenebilir dağıtımlar sağlayabilir. Bu yaklaşım hızlı prototipleme, sağlam izleme ve Azure AI hizmetleriyle sorunsuz entegrasyon sunar; bilgi yönetimi ve ajan değerlendirmesi gibi gelişmiş senaryoları destekler. Geliştiriciler, ajan boru hatlarını oluşturmak, dağıtmak ve izlemek için birleşik bir arayüzden yararlanırken, BT ekipleri güvenlik, uyumluluk ve operasyonel verimlilikte iyileşme elde eder. Bu çözüm, AI benimsemesini hızlandırmak ve karmaşık ajan tabanlı süreçler üzerinde kontrol sağlamak isteyen işletmeler için idealdir.

**Referanslar:**  
- [MCP Foundry GitHub Deposu](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Azure AI Ajanlarının MCP ile Entegrasyonu (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Vaka Çalışması 8: Foundry MCP Playground – Deney ve Prototipleme

Foundry MCP Playground, MCP sunucuları ve Azure AI Foundry entegrasyonlarıyla denemeler yapmak için kullanıma hazır bir ortam sunar. Geliştiriciler, Azure AI Foundry Kataloğu ve Laboratuvarlarından kaynakları kullanarak AI modelleri ve ajan iş akışlarını hızlıca prototipleyebilir, test edebilir ve değerlendirebilir. Playground, kurulumu kolaylaştırır, örnek projeler sağlar ve iş birliğine dayalı geliştirmeyi destekler; böylece en iyi uygulamaları ve yeni senaryoları minimum yükle keşfetmek kolaylaşır. Özellikle fikir doğrulama, deney paylaşımı ve öğrenme hızlandırma amacıyla altyapı karmaşıklığı olmadan ekipler için faydalıdır. Giriş engelini düşürerek, MCP ve Azure AI Foundry ekosisteminde yenilik ve topluluk katkılarını teşvik eder.

**Referanslar:**  
- [Foundry MCP Playground GitHub Deposu](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Vaka Çalışması 9: Microsoft Docs MCP Sunucusu – Öğrenme ve Yetenek Geliştirme

Microsoft Docs MCP Sunucusu, AI asistanlarına resmi Microsoft dokümantasyonuna gerçek zamanlı erişim sağlayan Model Context Protocol (MCP) sunucusunu uygular. Microsoft resmi teknik dokümantasyonuna karşı anlamsal arama yapar.

**Referanslar:**  
- [Microsoft Learn Docs MCP Sunucusu](https://github.com/MicrosoftDocs/mcp)

## Uygulamalı Projeler

### Proje 1: Çok Sağlayıcılı MCP Sunucusu Oluşturma

**Amaç:** Belirli kriterlere göre istekleri birden fazla AI model sağlayıcısına yönlendirebilen bir MCP sunucusu oluşturmak.

**Gereksinimler:**  
- En az üç farklı model sağlayıcısını desteklemek (örneğin OpenAI, Anthropic, yerel modeller)  
- İstek meta verilerine dayalı yönlendirme mekanizması uygulamak  
- Sağlayıcı kimlik bilgilerini yönetmek için bir yapılandırma sistemi oluşturmak  
- Performans ve maliyet optimizasyonu için önbellekleme eklemek  
- Kullanım izleme için basit bir gösterge paneli oluşturmak  

**Uygulama Adımları:**  
1. Temel MCP sunucu altyapısını kurmak  
2. Her AI model servisi için sağlayıcı adaptörlerini uygulamak  
3. İstek özelliklerine dayalı yönlendirme mantığını oluşturmak  
4. Sık istekler için önbellekleme mekanizmaları eklemek  
5. İzleme panosunu geliştirmek  
6. Çeşitli istek desenleriyle test etmek  

**Teknolojiler:** Tercihinize göre Python (.NET/Java/Python), önbellekleme için Redis ve gösterge paneli için basit bir web framework.

### Proje 2: Kurumsal Prompt Yönetim Sistemi

**Amaç:** Kuruluş genelinde prompt şablonlarını yönetmek, versiyonlamak ve dağıtmak için MCP tabanlı bir sistem geliştirmek.

**Gereksinimler:**  
- Prompt şablonları için merkezi bir depo oluşturmak  
- Versiyonlama ve onay iş akışları uygulamak  
- Örnek girdilerle şablon test yetenekleri geliştirmek  
- Rol tabanlı erişim kontrolleri oluşturmak  
- Şablon alma ve dağıtımı için bir API oluşturmak  

**Uygulama Adımları:**  
1. Şablon depolama için veritabanı şeması tasarlamak  
2. Şablon CRUD işlemleri için temel API’yi oluşturmak  
3. Versiyonlama sistemini uygulamak  
4. Onay iş akışını geliştirmek  
5. Test çerçevesini oluşturmak  
6. Yönetim için basit bir web arayüzü geliştirmek  
7. MCP sunucusuyla entegrasyon sağlamak  

**Teknolojiler:** Tercih ettiğiniz backend framework, SQL veya NoSQL veritabanı ve yönetim arayüzü için frontend framework.

### Proje 3: MCP Tabanlı İçerik Üretim Platformu

**Amaç:** MCP kullanarak farklı içerik türlerinde tutarlı sonuçlar veren bir içerik üretim platformu oluşturmak.

**Gereksinimler:**  
- Blog yazıları, sosyal medya ve pazarlama metinleri gibi çoklu içerik formatlarını desteklemek  
- Özelleştirme seçenekleriyle şablon tabanlı üretim uygulamak  
- İçerik inceleme ve geri bildirim sistemi oluşturmak  
- İçerik performans metriklerini takip etmek  
- İçerik versiyonlama ve yineleme desteği sağlamak  

**Uygulama Adımları:**  
1. MCP istemci altyapısını kurmak  
2. Farklı içerik türleri için şablonlar oluşturmak  
3. İçerik üretim hattını kurmak  
4. İnceleme sistemini uygulamak  
5. Metrik takip sistemini geliştirmek  
6. Şablon yönetimi ve içerik üretimi için kullanıcı arayüzü oluşturmak  

**Teknolojiler:** Tercih ettiğiniz programlama dili, web framework ve veritabanı sistemi.

## MCP Teknolojisi İçin Gelecek Yönelimler

### Ortaya Çıkan Trendler

1. **Çok Modlu MCP**  
   - Görüntü, ses ve video modelleriyle etkileşimleri standartlaştırmak için MCP’nin genişletilmesi  
   - Modlar arası akıl yürütme yeteneklerinin geliştirilmesi  
   - Farklı modlar için standart prompt formatları  

2. **Federasyonlu MCP Altyapısı**  
   - Kuruluşlar arasında kaynak paylaşabilen dağıtık MCP ağları  
   - Güvenli model paylaşımı için standart protokoller  
   - Gizliliği koruyan hesaplama teknikleri  

3. **MCP Pazar Yerleri**  
   - MCP şablonları ve eklentilerinin paylaşımı ve gelir elde edilmesi için ekosistemler  
   - Kalite güvencesi ve sertifikasyon süreçleri  
   - Model pazarlarıyla entegrasyon  

4. **Edge Computing İçin MCP**  
   - Kaynak kısıtlı uç cihazlar için MCP standartlarının uyarlanması  
   - Düşük bant genişliği ortamları için optimize protokoller  
   - IoT ekosistemleri için özel MCP uygulamaları  

5. **Düzenleyici Çerçeveler**  
   - Düzenleyici uyumluluk için MCP uzantılarının geliştirilmesi  
   - Standart denetim izleri ve açıklanabilirlik arayüzleri  
   - Ortaya çıkan AI yönetişim çerçeveleriyle entegrasyon  

### Microsoft’tan MCP Çözümleri

Microsoft ve Azure, geliştiricilerin çeşitli senaryolarda MCP uygulamalarını hayata geçirmesine yardımcı olmak için birçok açık kaynak depo geliştirdi:

#### Microsoft Organizasyonu  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Tarayıcı otomasyonu ve testi için Playwright MCP sunucusu  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Yerel test ve topluluk katkısı için OneDrive MCP sunucu uygulaması  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Açık protokoller ve araçlardan oluşan koleksiyon; AI Web için temel katman oluşturmayı hedefler  

#### Azure-Samples Organizasyonu  
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure üzerinde MCP sunucuları oluşturma ve entegre etme için örnekler, araçlar ve kaynaklar  
2. [mcp-auth-servers](https://github.com/A
- [MCP Topluluğu ve Dokümantasyonu](https://modelcontextprotocol.io/introduction)
- [Azure MCP Dokümantasyonu](https://aka.ms/azmcp)
- [Playwright MCP Server GitHub Deposu](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Sunucuları (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Fonksiyonları (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Fonksiyonları Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Fonksiyonları .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Fonksiyonları TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Fonksiyonları Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI ve Otomasyon Çözümleri](https://azure.microsoft.com/en-us/products/ai-services/)

## Alıştırmalar

1. Vaka çalışmalarından birini analiz edin ve alternatif bir uygulama yaklaşımı önerin.
2. Proje fikirlerinden birini seçin ve detaylı bir teknik spesifikasyon oluşturun.
3. Vaka çalışmalarında yer almayan bir sektörü araştırın ve MCP’nin bu sektörün özel zorluklarını nasıl çözebileceğini özetleyin.
4. Gelecekteki yönlerden birini inceleyin ve bunu destekleyecek yeni bir MCP uzantısı için bir konsept oluşturun.

Sonraki: [En İyi Uygulamalar](../08-BestPractices/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda oluşabilecek herhangi bir yanlış anlama veya yorum hatasından sorumlu değiliz.