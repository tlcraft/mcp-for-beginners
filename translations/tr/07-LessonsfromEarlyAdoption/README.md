<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6755bc4f6d0293ce6c49cfc5efba0d8e",
  "translation_date": "2025-07-18T09:48:11+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tr"
}
-->
# 🌟 Erken Benimseyenlerden Dersler

## 🎯 Bu Modül Neleri Kapsar

Bu modül, gerçek organizasyonların ve geliştiricilerin Model Context Protocol (MCP)’ü nasıl kullanarak gerçek zorlukları çözdüğünü ve yeniliği nasıl hızlandırdığını inceliyor. Detaylı vaka çalışmaları ve uygulamalı projeler aracılığıyla, MCP’nin dil modelleri, araçlar ve kurumsal verileri güvenli ve ölçeklenebilir şekilde nasıl entegre ettiğini keşfedeceksiniz.

### Vaka Çalışması 5: Azure MCP – Kurumsal Düzeyde Model Context Protocol Hizmeti

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)), Microsoft’un yönetilen, kurumsal düzeyde Model Context Protocol uygulamasıdır ve ölçeklenebilir, güvenli ve uyumlu MCP sunucu yeteneklerini bulut hizmeti olarak sunmak üzere tasarlanmıştır. Bu kapsamlı paket, farklı Azure hizmetleri ve senaryoları için birden fazla özel MCP sunucusunu içerir.

> **🎯 Üretime Hazır Araçlar**
> 
> Bu vaka çalışması, birden fazla üretime hazır MCP sunucusunu temsil eder! Azure MCP Sunucusu ve diğer Azure ile entegre sunucular hakkında daha fazla bilgi için [**Microsoft MCP Sunucuları Kılavuzumuza**](microsoft-mcp-servers.md#2--azure-mcp-server) göz atın.

**Temel Özellikler:**
- Yerleşik ölçeklendirme, izleme ve güvenlik ile tam yönetilen MCP sunucu barındırma
- Azure OpenAI, Azure AI Search ve diğer Azure hizmetleri ile yerel entegrasyon
- Microsoft Entra ID üzerinden kurumsal kimlik doğrulama ve yetkilendirme
- Özel araçlar, prompt şablonları ve kaynak bağlayıcıları desteği
- Kurumsal güvenlik ve düzenleyici gereksinimlere uyum
- Veritabanı, izleme ve depolama dahil 15+ özel Azure hizmet bağlayıcısı

**Azure MCP Sunucu Yetkinlikleri:**
- **Kaynak Yönetimi**: Tam Azure kaynak yaşam döngüsü yönetimi
- **Veritabanı Bağlayıcıları**: Azure Database for PostgreSQL ve SQL Server’a doğrudan erişim
- **Azure Monitor**: KQL destekli günlük analizi ve operasyonel içgörüler
- **Kimlik Doğrulama**: DefaultAzureCredential ve yönetilen kimlik desenleri
- **Depolama Hizmetleri**: Blob Storage, Queue Storage ve Table Storage işlemleri
- **Konteyner Hizmetleri**: Azure Container Apps, Container Instances ve AKS yönetimi

### 📚 MCP’yi Uygulamada Görün

Bu prensiplerin üretime hazır araçlarda nasıl uygulandığını görmek ister misiniz? Bugün kullanabileceğiniz gerçek Microsoft MCP sunucularını gösteren [**Geliştirici Verimliliğini Dönüştüren 10 Microsoft MCP Sunucusu**](microsoft-mcp-servers.md) rehberimize göz atın.

## Genel Bakış

Bu ders, erken benimseyenlerin Model Context Protocol (MCP)’ü kullanarak gerçek dünya sorunlarını nasıl çözdüğünü ve sektörlerde yeniliği nasıl hızlandırdığını inceliyor. Detaylı vaka çalışmaları ve uygulamalı projelerle, MCP’nin büyük dil modelleri, araçlar ve kurumsal verileri tek bir çatı altında standart, güvenli ve ölçeklenebilir şekilde nasıl entegre ettiğini göreceksiniz. MCP tabanlı çözümler tasarlama ve inşa etme konusunda pratik deneyim kazanacak, kanıtlanmış uygulama desenlerinden öğrenecek ve MCP’yi üretim ortamlarında dağıtmak için en iyi uygulamaları keşfedeceksiniz. Ders ayrıca ortaya çıkan trendleri, gelecekteki yönelimleri ve açık kaynak kaynaklarını vurgulayarak MCP teknolojisi ve gelişen ekosisteminde öncü kalmanıza yardımcı olur.

## Öğrenme Hedefleri

- Farklı sektörlerde gerçek MCP uygulamalarını analiz etmek
- Tam MCP tabanlı uygulamalar tasarlamak ve geliştirmek
- MCP teknolojisindeki yeni trendleri ve gelecekteki yönelimleri keşfetmek
- Gerçek geliştirme senaryolarında en iyi uygulamaları uygulamak

## Gerçek Dünya MCP Uygulamaları

### Vaka Çalışması 1: Kurumsal Müşteri Destek Otomasyonu

Çok uluslu bir şirket, müşteri destek sistemlerinde AI etkileşimlerini standartlaştırmak için MCP tabanlı bir çözüm uyguladı. Bu sayede:

- Birden fazla LLM sağlayıcısı için birleşik bir arayüz oluşturdu
- Departmanlar arasında tutarlı prompt yönetimi sağladı
- Güçlü güvenlik ve uyumluluk kontrolleri uyguladı
- Belirli ihtiyaçlara göre farklı AI modelleri arasında kolayca geçiş yaptı

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

### Vaka Çalışması 2: Sağlık Hizmetleri Tanı Asistanı

Bir sağlık sağlayıcısı, birden fazla uzmanlaşmış tıbbi AI modelini entegre etmek için MCP altyapısı geliştirdi ve hassas hasta verilerinin korunmasını sağladı:

- Genel ve uzman tıbbi modeller arasında sorunsuz geçiş
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

**Sonuçlar:** Hekimler için geliştirilmiş tanı önerileri, tam HIPAA uyumluluğu ve sistemler arası bağlam değiştirme süresinde önemli azalma.

### Vaka Çalışması 3: Finansal Hizmetlerde Risk Analizi

Bir finans kurumu, farklı departmanlarda risk analiz süreçlerini standartlaştırmak için MCP uyguladı:

- Kredi riski, dolandırıcılık tespiti ve yatırım riski modelleri için birleşik arayüz oluşturdu
- Katı erişim kontrolleri ve model sürüm yönetimi uyguladı
- Tüm AI önerilerinin denetlenebilirliğini sağladı
- Farklı sistemler arasında tutarlı veri formatlaması sağladı

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

**Sonuçlar:** Düzenleyici uyumda iyileşme, model dağıtım döngülerinde %40 hızlanma ve departmanlar arası risk değerlendirme tutarlılığında artış.

### Vaka Çalışması 4: Microsoft Playwright MCP Sunucusu ile Tarayıcı Otomasyonu

Microsoft, Model Context Protocol aracılığıyla güvenli ve standartlaştırılmış tarayıcı otomasyonu sağlamak için [Playwright MCP sunucusunu](https://github.com/microsoft/playwright-mcp) geliştirdi. Bu üretime hazır sunucu, AI ajanlarının ve LLM’lerin web tarayıcılarıyla kontrollü, denetlenebilir ve genişletilebilir şekilde etkileşim kurmasını sağlar; otomatik web testi, veri çıkarımı ve uçtan uca iş akışları gibi kullanım senaryolarını mümkün kılar.

> **🎯 Üretime Hazır Araç**
> 
> Bu vaka çalışması, bugün kullanabileceğiniz gerçek bir MCP sunucusunu gösteriyor! Playwright MCP Sunucusu ve diğer 9 üretime hazır Microsoft MCP sunucusu hakkında daha fazla bilgi için [**Microsoft MCP Sunucuları Kılavuzumuza**](microsoft-mcp-servers.md#8--playwright-mcp-server) bakabilirsiniz.

**Temel Özellikler:**
- Tarayıcı otomasyon yeteneklerini (navigasyon, form doldurma, ekran görüntüsü alma vb.) MCP araçları olarak sunar
- Yetkisiz işlemleri önlemek için sıkı erişim kontrolleri ve sandbox uygulaması yapar
- Tüm tarayıcı etkileşimleri için ayrıntılı denetim günlükleri sağlar
- Azure OpenAI ve diğer LLM sağlayıcıları ile ajan destekli otomasyon entegrasyonunu destekler
- GitHub Copilot’un Kodlama Ajanı’na web tarama yetenekleri kazandırır

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
- AI ajanları ve LLM’ler için güvenli, programatik tarayıcı otomasyonu sağladı  
- Manuel test çabasını azalttı ve web uygulamaları için test kapsamını artırdı  
- Kurumsal ortamlarda tarayıcı tabanlı araç entegrasyonu için yeniden kullanılabilir, genişletilebilir bir çerçeve sundu  
- GitHub Copilot’un web tarama yeteneklerini destekledi

**Referanslar:**  
- [Playwright MCP Sunucusu GitHub Deposu](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI ve Otomasyon Çözümleri](https://azure.microsoft.com/en-us/products/ai-services/)

### Vaka Çalışması 5: Azure MCP – Kurumsal Düzeyde Model Context Protocol Hizmeti

Azure MCP Sunucusu ([https://aka.ms/azmcp](https://aka.ms/azmcp)), Microsoft’un yönetilen, kurumsal düzeyde Model Context Protocol uygulamasıdır ve ölçeklenebilir, güvenli ve uyumlu MCP sunucu yeteneklerini bulut hizmeti olarak sunmak üzere tasarlanmıştır. Azure MCP, organizasyonların MCP sunucularını Azure AI, veri ve güvenlik hizmetleriyle hızla dağıtmasını, yönetmesini ve entegre etmesini sağlar; operasyonel yükü azaltır ve AI benimsemesini hızlandırır.

> **🎯 Üretime Hazır Araç**
> 
> Bugün kullanabileceğiniz gerçek bir MCP sunucusudur! Azure AI Foundry MCP Sunucusu hakkında daha fazla bilgi için [**Microsoft MCP Sunucuları Kılavuzumuza**](microsoft-mcp-servers.md) bakabilirsiniz.

- Yerleşik ölçeklendirme, izleme ve güvenlik ile tam yönetilen MCP sunucu barındırma  
- Azure OpenAI, Azure AI Search ve diğer Azure hizmetleri ile yerel entegrasyon  
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
- Kurumsal AI projeleri için kullanıma hazır, uyumlu MCP sunucu platformu sağlayarak değer elde etme süresini kısalttı  
- LLM’ler, araçlar ve kurumsal veri kaynaklarının entegrasyonunu basitleştirdi  
- MCP iş yükleri için güvenlik, gözlemlenebilirlik ve operasyonel verimliliği artırdı  
- Azure SDK en iyi uygulamaları ve güncel kimlik doğrulama desenleri ile kod kalitesini iyileştirdi

**Referanslar:**  
- [Azure MCP Dokümantasyonu](https://aka.ms/azmcp)  
- [Azure MCP Sunucusu GitHub Deposu](https://github.com/Azure/azure-mcp)  
- [Azure AI Hizmetleri](https://azure.microsoft.com/en-us/products/ai-services/)

### Vaka Çalışması 6: NLWeb – Doğal Dil Web Arayüz Protokolü

NLWeb, Microsoft’un AI Web için temel bir katman oluşturma vizyonunu temsil eder. Her NLWeb örneği aynı zamanda bir MCP sunucusudur ve doğal dilde bir web sitesine soru sormak için kullanılan `ask` adlı tek bir temel yöntemi destekler. Dönen yanıt, web verilerini tanımlamak için yaygın kullanılan schema.org sözlüğünü kullanır. Basitçe söylemek gerekirse, MCP, NLWeb için HTTP’nin HTML olması gibidir.

**Temel Özellikler:**
- **Protokol Katmanı**: Web siteleriyle doğal dilde etkileşim için basit bir protokol  
- **Schema.org Formatı**: Yapılandırılmış, makine tarafından okunabilir yanıtlar için JSON ve schema.org kullanımı  
- **Topluluk Uygulaması**: Ürünler, tarifler, gezilecek yerler, yorumlar gibi öğe listeleri olarak soyutlanabilen siteler için kolay uygulama  
- **UI Bileşenleri**: Konuşma arayüzleri için önceden hazırlanmış kullanıcı arayüzü bileşenleri  

**Mimari Bileşenler:**
1. **Protokol**: Web sitelerine doğal dil sorguları için basit REST API  
2. **Uygulama**: Otomatik yanıtlar için mevcut işaretleme ve site yapısını kullanır  
3. **UI Bileşenleri**: Konuşma arayüzlerinin entegrasyonu için hazır bileşenler  

**Faydalar:**
- Hem insan-siteler hem de ajanlar arası etkileşimi mümkün kılar  
- AI sistemlerinin kolayca işleyebileceği yapılandırılmış veri yanıtları sağlar  
- Liste tabanlı içerik yapısına sahip siteler için hızlı dağıtım  
- Web sitelerini AI erişimine açmak için standartlaştırılmış yaklaşım  

**Sonuçlar:**
- AI-web etkileşim standartları için temel oluşturdu  
- İçerik siteleri için konuşma arayüzlerinin oluşturulmasını kolaylaştırdı  
- AI sistemleri için web içeriğinin keşfedilebilirliğini ve erişilebilirliğini artırdı  
- Farklı AI ajanları ve web servisleri arasında birlikte çalışabilirliği teşvik etti  

**Referanslar:**  
- [NLWeb GitHub Deposu](https://github.com/microsoft/NlWeb)  
- [NLWeb Dokümantasyonu](https://github.com/microsoft/NlWeb)

### Vaka Çalışması 7: Azure AI Foundry MCP Sunucusu – Kurumsal AI Ajan Entegrasyonu

Azure AI Foundry MCP sunucuları, MCP’nin kurumsal ortamlarda AI ajanlarını ve iş akışlarını nasıl düzenleyip yönetebileceğini gösterir. MCP’yi Azure AI Foundry ile entegre ederek, organizasyonlar ajan etkileşimlerini standartlaştırabilir, Foundry’nin iş akışı yönetimini kullanabilir ve güvenli, ölçeklenebilir dağıtımlar sağlayabilir.

> **🎯 Üretime Hazır Araç**
> 
> Bugün kullanabileceğiniz gerçek bir MCP sunucusudur! Azure AI Foundry MCP Sunucusu hakkında daha fazla bilgi için [**Microsoft MCP Sunucuları Kılavuzumuza**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server) bakabilirsiniz.

**Temel Özellikler:**
- Model katalogları ve dağıtım yönetimi dahil Azure’un AI ekosistemine kapsamlı erişim  
- RAG uygulamaları için Azure AI Search ile bilgi indeksleme  
- AI model performansı ve kalite güvencesi için değerlendirme araçları  
- En yeni araştırma modelleri için Azure AI Foundry Catalog ve Labs entegrasyonu  
- Üretim senaryoları için ajan yönetimi ve değerlendirme yetenekleri  

**Sonuçlar:**
- AI ajan iş akışlarının hızlı prototiplenmesi ve sağlam izlenmesi  
- Gelişmiş senaryolar için Azure AI hizmetleriyle sorunsuz entegrasyon  
- Ajan hatları oluşturma, dağıtma ve izleme için birleşik arayüz  
- Kurumsal güvenlik, uyumluluk ve operasyonel verimlilikte iyileşme  
- Karmaşık ajan tabanlı süreçler üzerinde kontrol sağlarken AI benimsemesini hızlandırma  

**Referanslar:**  
- [Azure AI Foundry MCP Sunucusu GitHub Deposu](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Azure AI Ajanlarının MCP ile Entegrasyonu (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Vaka Çalışması 8: Foundry MCP Playground – Deney ve Prototipleme

Foundry MCP Playground, MCP sunucuları ve Azure AI Foundry entegrasyonlarıyla denemeler yapmak için kullanıma hazır bir ortam sunar. Geliştiriciler, Azure AI Foundry Catalog ve Labs kaynaklarını kullanarak AI modellerini ve ajan iş akışlarını hızlıca prototipleyip test edebilir, değerlendirebilir. Playground, kurulum sürecini kolaylaştırır, örnek projeler sağlar ve iş birliğine dayalı geliştirmeyi destekler; böylece en iyi uygulamaları ve yeni senaryoları minimum çabayla keşfetmek mümkün olur. Özellikle fikir doğrulama, deney paylaşımı ve öğrenme hızlandırma amacıyla altyapı karmaşıklığı olmadan ekipler için faydalıdır. Giriş engelini düşürerek MCP ve Azure AI Foundry ekosisteminde yenilik ve topluluk katkılarını teşvik eder.

**Referanslar:**  
- [Foundry MCP Playground GitHub Deposu](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Vaka Çalışması 9: Microsoft Learn Docs MCP Sunucusu – AI Destekli Dokümantasyon Erişimi

Microsoft Learn Docs MCP Sunucusu, Model Context Protocol aracılığıyla AI asistanlarına resmi Microsoft dokümantasyonuna gerçek zamanlı erişim sağlayan bulut tabanlı bir hizmettir. Bu üretime hazır sunucu, kapsamlı Microsoft Learn ekosistemiyle bağlantı kurar ve tüm resmi Microsoft kaynaklarında anlamsal arama yapılmasına olanak tanır.
> **🎯 Üretime Hazır Araç**
> 
> Bugün kullanabileceğiniz gerçek bir MCP sunucusu! Microsoft Learn Docs MCP Sunucusu hakkında daha fazla bilgi için [**Microsoft MCP Sunucuları Rehberimiz**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server) sayfasına göz atın.
**Temel Özellikler:**
- Resmi Microsoft dokümantasyonuna, Azure dokümanlarına ve Microsoft 365 dokümantasyonuna gerçek zamanlı erişim
- Bağlamı ve amacı anlayan gelişmiş anlamsal arama yetenekleri
- Microsoft Learn içeriği yayınlandıkça her zaman güncel bilgi
- Microsoft Learn, Azure dokümantasyonu ve Microsoft 365 kaynakları arasında kapsamlı kapsama
- Makale başlıkları ve URL’lerle birlikte 10’a kadar yüksek kaliteli içerik parçası döndürür

**Neden Kritik:**
- Microsoft teknolojileri için "güncellenmemiş yapay zeka bilgisi" sorununu çözer
- Yapay zeka asistanlarının en son .NET, C#, Azure ve Microsoft 365 özelliklerine erişimini sağlar
- Doğru kod üretimi için yetkili, birinci taraf bilgi sunar
- Hızla gelişen Microsoft teknolojileriyle çalışan geliştiriciler için vazgeçilmezdir

**Sonuçlar:**
- Microsoft teknolojileri için yapay zeka tarafından üretilen kodun doğruluğunda büyük iyileşme
- Güncel dokümantasyon ve en iyi uygulamaları arama süresinde azalma
- Bağlam farkındalığına sahip dokümantasyon erişimi ile geliştirici verimliliğinde artış
- IDE’den çıkmadan geliştirme iş akışlarına sorunsuz entegrasyon

**Referanslar:**
- [Microsoft Learn Docs MCP Server GitHub Repository](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn Documentation](https://learn.microsoft.com/)

## Uygulamalı Projeler

### Proje 1: Çok Sağlayıcılı MCP Sunucusu Oluşturma

**Amaç:** Belirli kriterlere göre istekleri birden fazla yapay zeka model sağlayıcısına yönlendirebilen bir MCP sunucusu oluşturmak.

**Gereksinimler:**
- En az üç farklı model sağlayıcısını desteklemek (örneğin OpenAI, Anthropic, yerel modeller)
- İstek meta verilerine dayalı yönlendirme mekanizması uygulamak
- Sağlayıcı kimlik bilgilerini yönetmek için bir yapılandırma sistemi oluşturmak
- Performans ve maliyet optimizasyonu için önbellekleme eklemek
- Kullanım takibi için basit bir kontrol paneli oluşturmak

**Uygulama Adımları:**
1. Temel MCP sunucu altyapısını kurmak
2. Her yapay zeka model servisi için sağlayıcı adaptörleri uygulamak
3. İstek özelliklerine dayalı yönlendirme mantığını oluşturmak
4. Sık yapılan istekler için önbellekleme mekanizmaları eklemek
5. İzleme kontrol panelini geliştirmek
6. Çeşitli istek desenleriyle test etmek

**Teknolojiler:** Tercihinize göre Python (.NET/Java/Python), önbellekleme için Redis ve kontrol paneli için basit bir web framework’ü seçebilirsiniz.

### Proje 2: Kurumsal Prompt Yönetim Sistemi

**Amaç:** Bir organizasyon genelinde prompt şablonlarını yönetmek, versiyonlamak ve dağıtmak için MCP tabanlı bir sistem geliştirmek.

**Gereksinimler:**
- Prompt şablonları için merkezi bir depo oluşturmak
- Versiyonlama ve onay iş akışları uygulamak
- Örnek girdilerle şablon test etme yetenekleri geliştirmek
- Rol tabanlı erişim kontrolleri oluşturmak
- Şablonların alınması ve dağıtımı için bir API oluşturmak

**Uygulama Adımları:**
1. Şablon depolama için veritabanı şemasını tasarlamak
2. Şablon CRUD işlemleri için temel API’yi oluşturmak
3. Versiyonlama sistemini uygulamak
4. Onay iş akışını geliştirmek
5. Test çerçevesini oluşturmak
6. Yönetim için basit bir web arayüzü geliştirmek
7. MCP sunucusuyla entegrasyon sağlamak

**Teknolojiler:** Tercihinize göre backend framework, SQL veya NoSQL veritabanı ve yönetim arayüzü için frontend framework seçebilirsiniz.

### Proje 3: MCP Tabanlı İçerik Üretim Platformu

**Amaç:** MCP’yi kullanarak farklı içerik türlerinde tutarlı sonuçlar sunan bir içerik üretim platformu oluşturmak.

**Gereksinimler:**
- Birden fazla içerik formatını desteklemek (blog yazıları, sosyal medya, pazarlama metinleri)
- Özelleştirme seçenekleriyle şablon tabanlı üretim uygulamak
- İçerik inceleme ve geri bildirim sistemi oluşturmak
- İçerik performans metriklerini takip etmek
- İçerik versiyonlama ve iterasyon desteği sağlamak

**Uygulama Adımları:**
1. MCP istemci altyapısını kurmak
2. Farklı içerik türleri için şablonlar oluşturmak
3. İçerik üretim hattını geliştirmek
4. İnceleme sistemini uygulamak
5. Metrik takip sistemini geliştirmek
6. Şablon yönetimi ve içerik üretimi için kullanıcı arayüzü oluşturmak

**Teknolojiler:** Tercih ettiğiniz programlama dili, web framework ve veritabanı sistemi.

## MCP Teknolojisi İçin Gelecek Yönelimler

### Ortaya Çıkan Trendler

1. **Çok Modlu MCP**
   - MCP’nin görüntü, ses ve video modelleriyle etkileşimleri standartlaştıracak şekilde genişletilmesi
   - Modlar arası akıl yürütme yeteneklerinin geliştirilmesi
   - Farklı modaliteler için standartlaştırılmış prompt formatları

2. **Federated MCP Altyapısı**
   - Kuruluşlar arasında kaynak paylaşabilen dağıtık MCP ağları
   - Güvenli model paylaşımı için standart protokoller
   - Gizliliği koruyan hesaplama teknikleri

3. **MCP Pazar Yerleri**
   - MCP şablonları ve eklentilerinin paylaşımı ve gelir elde edilmesi için ekosistemler
   - Kalite güvencesi ve sertifikasyon süreçleri
   - Model pazar yerleriyle entegrasyon

4. **Edge Computing için MCP**
   - Kaynak kısıtlı uç cihazlar için MCP standartlarının uyarlanması
   - Düşük bant genişliği ortamları için optimize edilmiş protokoller
   - IoT ekosistemleri için özel MCP uygulamaları

5. **Düzenleyici Çerçeveler**
   - Düzenleyici uyumluluk için MCP uzantılarının geliştirilmesi
   - Standartlaştırılmış denetim kayıtları ve açıklanabilirlik arayüzleri
   - Gelişmekte olan yapay zeka yönetişim çerçeveleriyle entegrasyon

### Microsoft’tan MCP Çözümleri

Microsoft ve Azure, geliştiricilerin farklı senaryolarda MCP uygulamalarını kolaylaştırmak için çeşitli açık kaynak depolar geliştirdi:

#### Microsoft Organization
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Tarayıcı otomasyonu ve test için Playwright MCP sunucusu
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Yerel test ve topluluk katkısı için OneDrive MCP sunucu uygulaması
3. [NLWeb](https://github.com/microsoft/NlWeb) - Açık protokoller ve ilgili açık kaynak araçlardan oluşan bir koleksiyon. Ana odak noktası AI Web için temel katman oluşturmak

#### Azure-Samples Organization
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure üzerinde çoklu dillerle MCP sunucuları oluşturma ve entegre etme için örnekler, araçlar ve kaynaklar
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Mevcut Model Context Protocol spesifikasyonuyla kimlik doğrulamayı gösteren referans MCP sunucuları
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions içinde Uzaktan MCP Sunucu uygulamaları için açılış sayfası ve dil bazlı repoların bağlantıları
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure Functions ile Python kullanarak özel uzaktan MCP sunucuları oluşturma ve dağıtma için hızlı başlangıç şablonu
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Azure Functions ile .NET/C# kullanarak özel uzaktan MCP sunucuları oluşturma ve dağıtma için hızlı başlangıç şablonu
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Azure Functions ile TypeScript kullanarak özel uzaktan MCP sunucuları oluşturma ve dağıtma için hızlı başlangıç şablonu
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Python kullanarak Azure API Yönetimi’ni Uzaktan MCP sunucularına AI Geçidi olarak kullanma
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - MCP yeteneklerini içeren APIM ❤️ AI deneyleri, Azure OpenAI ve AI Foundry ile entegrasyon

Bu depolar, Model Context Protocol ile çalışmak için farklı programlama dilleri ve Azure servislerinde çeşitli uygulamalar, şablonlar ve kaynaklar sunar. Temel sunucu uygulamalarından kimlik doğrulama, bulut dağıtımı ve kurumsal entegrasyon senaryolarına kadar geniş bir kullanım alanını kapsar.

#### MCP Kaynaklar Dizini

Resmi Microsoft MCP deposundaki [MCP Resources dizini](https://github.com/microsoft/mcp/tree/main/Resources), Model Context Protocol sunucularıyla kullanılmak üzere örnek kaynaklar, prompt şablonları ve araç tanımlamalarından oluşan özenle seçilmiş bir koleksiyon sunar. Bu dizin, geliştiricilerin MCP ile hızlı başlamasına yardımcı olmak için yeniden kullanılabilir yapı taşları ve en iyi uygulama örnekleri sağlar:

- **Prompt Şablonları:** Yaygın yapay zeka görevleri ve senaryoları için hazır prompt şablonları, kendi MCP sunucu uygulamalarınıza uyarlanabilir.
- **Araç Tanımları:** Farklı MCP sunucuları arasında araç entegrasyonu ve çağrısını standartlaştırmak için örnek araç şemaları ve meta veriler.
- **Kaynak Örnekleri:** MCP çerçevesinde veri kaynakları, API’ler ve dış servislerle bağlantı için örnek kaynak tanımlamaları.
- **Referans Uygulamalar:** Gerçek dünya MCP projelerinde kaynaklar, promptlar ve araçların nasıl yapılandırılıp organize edileceğini gösteren pratik örnekler.

Bu kaynaklar geliştirmeyi hızlandırır, standartlaşmayı teşvik eder ve MCP tabanlı çözümler oluştururken en iyi uygulamaların uygulanmasına yardımcı olur.

#### MCP Kaynaklar Dizini
- [MCP Resources (Örnek Promptlar, Araçlar ve Kaynak Tanımları)](https://github.com/microsoft/mcp/tree/main/Resources)

### Araştırma Fırsatları

- MCP çerçevelerinde verimli prompt optimizasyon teknikleri
- Çok kiracılı MCP dağıtımları için güvenlik modelleri
- Farklı MCP uygulamalarında performans kıyaslamaları
- MCP sunucuları için formal doğrulama yöntemleri

## Sonuç

Model Context Protocol (MCP), endüstriler arasında standart, güvenli ve birlikte çalışabilir yapay zeka entegrasyonunun geleceğini hızla şekillendiriyor. Bu derste yer alan vaka çalışmaları ve uygulamalı projeler aracılığıyla, Microsoft ve Azure gibi erken benimseyenlerin MCP’yi gerçek dünya sorunlarını çözmek, yapay zeka benimsemesini hızlandırmak ve uyumluluk, güvenlik ile ölçeklenebilirliği sağlamak için nasıl kullandığını gördünüz. MCP’nin modüler yaklaşımı, kuruluşların büyük dil modellerini, araçları ve kurumsal verileri birleşik, denetlenebilir bir çerçevede bağlamasına olanak tanır. MCP gelişmeye devam ettikçe, toplulukla etkileşimde kalmak, açık kaynak kaynakları keşfetmek ve en iyi uygulamaları uygulamak, sağlam ve geleceğe hazır yapay zeka çözümleri oluşturmanın anahtarı olacaktır.

## Ek Kaynaklar

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)
- [Azure AI Ajanlarını MCP ile Entegre Etme (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)
- [MCP Resources Directory (Örnek Promptlar, Araçlar ve Kaynak Tanımları)](https://github.com/microsoft/mcp/tree/main/Resources)
- [MCP Topluluğu ve Dokümantasyonu](https://modelcontextprotocol.io/introduction)
- [Azure MCP Dokümantasyonu](https://aka.ms/azmcp)
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
- [Microsoft AI ve Otomasyon Çözümleri](https://azure.microsoft.com/en-us/products/ai-services/)

## Alıştırmalar

1. Vaka çalışmalarından birini analiz edin ve alternatif bir uygulama yaklaşımı önerin.
2. Proje fikirlerinden birini seçip ayrıntılı teknik bir spesifikasyon oluşturun.
3. Vaka çalışmalarında yer almayan bir sektörü araştırın ve MCP’nin o sektörün özel zorluklarını nasıl çözebileceğini özetleyin.
4. Gelecek yönelimlerden birini keşfedin ve desteklemek için yeni bir MCP uzantısı konsepti oluşturun.

Sonraki: [Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.