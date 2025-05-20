<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T17:01:55+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tr"
}
-->
# Erken Benimseyenlerden Dersler

## Genel Bakış

Bu ders, erken benimseyenlerin Model Context Protocol (MCP)’ü nasıl kullanarak gerçek dünya sorunlarını çözdüğünü ve sektörlerde inovasyonu nasıl yönlendirdiğini inceliyor. Detaylı vaka analizleri ve uygulamalı projeler aracılığıyla, MCP’nin standartlaştırılmış, güvenli ve ölçeklenebilir yapay zeka entegrasyonunu nasıl mümkün kıldığını göreceksiniz—büyük dil modelleri, araçlar ve kurumsal verileri tek bir çatı altında birleştiriyor. MCP tabanlı çözümler tasarlama ve inşa etme konusunda pratik deneyim kazanacak, kanıtlanmış uygulama örüntülerinden öğrenecek ve MCP’nin üretim ortamlarında dağıtımı için en iyi uygulamaları keşfedeceksiniz. Ders ayrıca ortaya çıkan trendleri, gelecekteki yönelimleri ve açık kaynak kaynaklarını vurgulayarak MCP teknolojisi ve gelişen ekosisteminin ön saflarında kalmanıza yardımcı olur.

## Öğrenme Hedefleri

- Farklı sektörlerde gerçek dünya MCP uygulamalarını analiz etmek
- Tamamlanmış MCP tabanlı uygulamalar tasarlamak ve geliştirmek
- MCP teknolojisindeki yeni trendleri ve gelecekteki yönelimleri keşfetmek
- Gerçek geliştirme senaryolarında en iyi uygulamaları uygulamak

## Gerçek Dünya MCP Uygulamaları

### Vaka Çalışması 1: Kurumsal Müşteri Destek Otomasyonu

Çok uluslu bir şirket, müşteri destek sistemleri genelinde yapay zeka etkileşimlerini standartlaştırmak için MCP tabanlı bir çözüm uyguladı. Bu sayede:

- Birden çok LLM sağlayıcısı için birleşik bir arayüz oluşturdu
- Bölümler arasında tutarlı prompt yönetimi sağladı
- Güçlü güvenlik ve uyumluluk kontrolleri uyguladı
- Belirli ihtiyaçlara göre farklı yapay zeka modelleri arasında kolayca geçiş yaptı

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

**Sonuçlar:** Model maliyetlerinde %30 azalma, yanıt tutarlılığında %45 iyileşme ve küresel operasyonlarda gelişmiş uyumluluk.

### Vaka Çalışması 2: Sağlık Hizmetleri Tanı Asistanı

Bir sağlık hizmeti sağlayıcısı, birden çok uzmanlaşmış tıbbi yapay zeka modelini entegre etmek ve hassas hasta verilerinin korunmasını sağlamak için MCP altyapısı geliştirdi:

- Genel ve uzman tıbbi modeller arasında sorunsuz geçiş
- Sıkı gizlilik kontrolleri ve denetim izleri
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
- Sıkı erişim kontrolleri ve model versiyonlaması uyguladı
- Tüm yapay zeka önerilerinin denetlenebilirliğini sağladı
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

**Sonuçlar:** Artan düzenleyici uyumluluk, model dağıtım döngülerinde %40 hızlanma ve departmanlar arasında gelişmiş risk değerlendirme tutarlılığı.

### Vaka Çalışması 4: Microsoft Playwright MCP Sunucusu ile Tarayıcı Otomasyonu

Microsoft, Model Context Protocol aracılığıyla güvenli ve standartlaştırılmış tarayıcı otomasyonu sağlamak için [Playwright MCP sunucusunu](https://github.com/microsoft/playwright-mcp) geliştirdi. Bu çözüm, yapay zeka ajanlarının ve LLM’lerin web tarayıcıları ile kontrollü, denetlenebilir ve genişletilebilir şekilde etkileşim kurmasını sağlar—otomatik web testi, veri çıkarımı ve uçtan uca iş akışları gibi kullanım senaryolarını mümkün kılar.

- Tarayıcı otomasyon yeteneklerini (navigasyon, form doldurma, ekran görüntüsü alma vb.) MCP araçları olarak sunar
- Yetkisiz işlemleri engellemek için sıkı erişim kontrolleri ve sandboxing uygular
- Tüm tarayıcı etkileşimleri için detaylı denetim kayıtları sağlar
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
- Yapay zeka ajanları ve LLM’ler için güvenli, programatik tarayıcı otomasyonu sağlandı  
- Manuel test çabaları azaldı ve web uygulamalarında test kapsamı iyileşti  
- Kurumsal ortamlarda tarayıcı tabanlı araç entegrasyonu için yeniden kullanılabilir, genişletilebilir bir çerçeve sunuldu

**Referanslar:**  
- [Playwright MCP Server GitHub Deposu](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI ve Otomasyon Çözümleri](https://azure.microsoft.com/en-us/products/ai-services/)

### Vaka Çalışması 5: Azure MCP – Kurumsal Düzeyde Hizmet Olarak Model Context Protocol

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)), Model Context Protocol’ün Microsoft tarafından yönetilen, kurumsal düzeydeki uygulamasıdır ve ölçeklenebilir, güvenli ve uyumlu MCP sunucu yeteneklerini bulut hizmeti olarak sunar. Azure MCP, kuruluşların MCP sunucularını Azure AI, veri ve güvenlik hizmetleriyle hızla dağıtmasına, yönetmesine ve entegre etmesine olanak tanır; operasyonel yükü azaltır ve yapay zeka benimsemesini hızlandırır.

- Yerleşik ölçeklendirme, izleme ve güvenlik özellikleriyle tam yönetilen MCP sunucu barındırma  
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
- Kurumsal yapay zeka projeleri için kullanıma hazır, uyumlu MCP sunucu platformu sağlayarak değer elde etme süresini kısalttı  
- LLM’ler, araçlar ve kurumsal veri kaynaklarının entegrasyonunu basitleştirdi  
- MCP iş yüklerinde güvenlik, gözlemlenebilirlik ve operasyonel verimliliği artırdı

**Referanslar:**  
- [Azure MCP Dokümantasyonu](https://aka.ms/azmcp)  
- [Azure AI Hizmetleri](https://azure.microsoft.com/en-us/products/ai-services/)

## Vaka Çalışması 6: NLWeb

MCP (Model Context Protocol), sohbet botları ve yapay zeka asistanlarının araçlarla etkileşimini sağlayan gelişmekte olan bir protokoldür. Her NLWeb örneği aynı zamanda bir MCP sunucusudur ve doğal dilde bir web sitesine soru sormak için kullanılan ask adlı tek bir temel yöntemi destekler. Dönen yanıt, web verilerini tanımlamak için yaygın olarak kullanılan schema.org sözlüğünü kullanır. Basitçe söylemek gerekirse, MCP, NLWeb neyse, Http de HTML’dir. NLWeb, protokolleri, Schema.org formatlarını ve örnek kodları bir araya getirerek sitelerin bu uç noktaları hızla oluşturmasına yardımcı olur; bu da hem insanlar için sohbet arayüzleri hem de makineler için doğal ajanlar arası etkileşim sağlar.

NLWeb’in iki ayrı bileşeni vardır.  
- Birincisi, doğal dilde bir site ile arayüz oluşturmak için çok basit bir protokol ve dönen yanıt için json ve schema.org kullanan bir format. Daha fazla detay için REST API dokümantasyonuna bakınız.  
- İkincisi, (1) numaralı protokolün, ürünler, tarifler, gezilecek yerler, incelemeler gibi liste şeklinde soyutlanabilen sitelerde mevcut işaretlemeyi kullanan basit bir uygulaması. Kullanıcı arayüzü widget seti ile birlikte, siteler içeriklerine kolayca sohbet arayüzleri sunabilir. Bu mekanizmanın nasıl çalıştığı hakkında daha fazla bilgi için Life of a chat query dokümantasyonuna bakınız.

**Referanslar:**  
- [Azure MCP Dokümantasyonu](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Vaka Çalışması 7: Foundry için MCP – Azure AI Ajanlarının Entegrasyonu

Azure AI Foundry MCP sunucuları, MCP’nin kurumsal ortamlarda yapay zeka ajanlarını ve iş akışlarını koordine etmek ve yönetmek için nasıl kullanılabileceğini gösterir. MCP’yi Azure AI Foundry ile entegre ederek, kuruluşlar ajan etkileşimlerini standartlaştırabilir, Foundry’nin iş akışı yönetiminden faydalanabilir ve güvenli, ölçeklenebilir dağıtımları garanti edebilir. Bu yaklaşım hızlı prototipleme, sağlam izleme ve Azure AI hizmetleriyle sorunsuz entegrasyon sağlar; bilgi yönetimi ve ajan değerlendirmesi gibi gelişmiş senaryoları destekler. Geliştiriciler, ajan boru hatları oluşturma, dağıtma ve izleme için birleşik bir arayüzden faydalanırken, BT ekipleri gelişmiş güvenlik, uyumluluk ve operasyonel verimlilik kazanır. Bu çözüm, yapay zeka benimsemesini hızlandırmak ve karmaşık ajan odaklı süreçler üzerinde kontrol sağlamak isteyen işletmeler için idealdir.

**Referanslar:**  
- [MCP Foundry GitHub Deposu](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Azure AI Ajanlarının MCP ile Entegrasyonu (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Vaka Çalışması 8: Foundry MCP Playground – Deney ve Prototipleme

Foundry MCP Playground, MCP sunucuları ve Azure AI Foundry entegrasyonlarıyla denemeler yapmak için kullanıma hazır bir ortam sunar. Geliştiriciler, Azure AI Foundry Kataloğu ve Laboratuvarlarından kaynakları kullanarak yapay zeka modelleri ve ajan iş akışlarını hızla prototipleyebilir, test edebilir ve değerlendirebilir. Playground, kurulumu kolaylaştırır, örnek projeler sağlar ve işbirlikçi geliştirmeyi destekler; böylece en iyi uygulamaları ve yeni senaryoları minimum yükle keşfetmek kolaylaşır. Özellikle fikirleri doğrulamak, deneyleri paylaşmak ve karmaşık altyapı gerektirmeden öğrenmeyi hızlandırmak isteyen ekipler için faydalıdır. Giriş engelini düşürerek MCP ve Azure AI Foundry ekosisteminde inovasyonu ve topluluk katkılarını teşvik eder.

**Referanslar:**  
- [Foundry MCP Playground GitHub Deposu](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Uygulamalı Projeler

### Proje 1: Çok Sağlayıcılı MCP Sunucusu Oluşturma

**Amaç:** Belirli kriterlere göre istekleri birden fazla yapay zeka modeli sağlayıcısına yönlendirebilen bir MCP sunucusu oluşturmak.

**Gereksinimler:**  
- En az üç farklı model sağlayıcısını desteklemek (örneğin OpenAI, Anthropic, yerel modeller)  
- İstek meta verilerine dayalı yönlendirme mekanizması uygulamak  
- Sağlayıcı kimlik bilgilerini yönetmek için yapılandırma sistemi oluşturmak  
- Performans ve maliyet optimizasyonu için önbellekleme eklemek  
- Kullanım takibi için basit bir gösterge paneli geliştirmek

**Uygulama Adımları:**  
1. Temel MCP sunucu altyapısını kurmak  
2. Her yapay zeka modeli servisi için sağlayıcı adaptörleri geliştirmek  
3. İstek özelliklerine göre yönlendirme mantığını oluşturmak  
4. Sık kullanılan istekler için önbellekleme mekanizmaları eklemek  
5. İzleme gösterge panelini geliştirmek  
6. Çeşitli istek kalıplarıyla test etmek

**Teknolojiler:** Tercihinize göre Python (.NET/Java/Python), önbellekleme için Redis ve gösterge paneli için basit bir web çatısı seçebilirsiniz.

### Proje 2: Kurumsal Prompt Yönetim Sistemi

**Amaç:** Kuruluş genelinde prompt şablonlarını yönetmek, versiyonlamak ve dağıtmak için MCP tabanlı bir sistem geliştirmek.

**Gereksinimler:**  
- Prompt şablonları için merkezi bir depo oluşturmak  
- Versiyonlama ve onay iş akışları uygulamak  
- Örnek girdilerle şablon test etme yetenekleri geliştirmek  
- Rol tabanlı erişim kontrolleri oluşturmak  
- Şablonların alınması ve dağıtımı için API geliştirmek

**Uygulama Adımları:**  
1. Şablon depolama için veritabanı şeması tasarlamak  
2. Şablon CRUD işlemleri için temel API’yi oluşturmak  
3. Versiyonlama sistemini uygulamak  
4. Onay iş akışını geliştirmek  
5. Test çerçevesini oluşturmak  
6. Yönetim için basit bir web arayüzü geliştirmek  
7. MCP sunucusuyla entegrasyon yapmak

**Teknolojiler:** Tercih ettiğiniz backend çerçevesi, SQL veya NoSQL veritabanı ve yönetim arayüzü için frontend çerçevesi kullanabilirsiniz.

### Proje 3: MCP Tabanlı İçerik Üretim Platformu

**Amaç:** Farklı içerik türlerinde tutarlı sonuçlar sağlayan MCP tabanlı bir içerik üretim platformu oluşturmak.

**Gereksinimler:**  
- Birden fazla içerik formatını desteklemek (blog yazıları, sosyal medya, pazarlama metni)  
- Özelleştirme seçenekleriyle şablon tabanlı üretim uygulamak  
- İçerik inceleme ve geri bildirim sistemi oluşturmak  
- İçerik performans metriklerini takip etmek  
- İçerik versiyonlama ve iterasyonunu desteklemek

**Uygulama Adımları:**  
1. MCP istemci altyapısını kurmak  
2. Farklı içerik türleri için şablonlar oluşturmak  
3. İçerik üretim hattını geliştirmek  
4. İnceleme sistemini uygulamak  
5. Metrik takip sistemini geliştirmek  
6. Şablon yönetimi ve içerik üretimi için kullanıcı arayüzü oluşturmak

**Teknolojiler:** Tercih ettiğiniz programlama dili, web çatısı ve veritabanı sistemi kullanılabilir.

## MCP Teknolojisi İçin Gelecek Yönelimler

### Ortaya Çıkan Trendler

1. **Çok Modlu MCP**  
   - Görüntü, ses ve video modelleriyle etkileşimleri standartlaştırmak için MCP’nin genişletilmesi  
   - Modlar arası akıl yürütme yeteneklerinin geliştirilmesi  
   - Farklı modaliteler için standart prompt formatları  

2. **Federated MCP Altyapısı**  
   - Kuruluşlar arasında kaynak paylaşabilen dağıtık MCP ağları  
   - Güvenli model paylaşımı için standart protokoller  
   - Gizliliği koruyan hesaplama teknikleri  

3. **MCP Pazaryerleri**  
   - MCP şablonları ve eklentilerinin paylaşımı ve gelir elde edilmesi için ekosistemler  
   - Kalite güvencesi ve sertifikasyon süreçleri  
   - Model pazaryerleri ile entegrasyon  

4. **MCP Kenar Bilişim İçin**  
   - Kaynak kısıtlı kenar cihazlar için MCP standartlarının uyarlanması  
   - Düşük bant genişliği ortamları için optimize protokoller  
   - Nesnelerin interneti (IoT) ekosistemleri için özel MCP uygulamaları  

5. **Düzenleyici Çerçeveler**  
   - Düzenleyici uyumluluk için MCP uzantılarının geliştirilmesi  
   - Standart denetim izleri ve açıklanabilirlik arayüzleri  
   - Gelişmekte olan yapay zeka yönetişim çerçeveleriyle entegrasyon

### Microsoft’tan MCP Çözümleri

Microsoft ve Azure, geliştiricilerin çeşitli senaryolarda MCP uygulamalarını kolaylaştırmak için birçok açık kaynak depo geliştirdi:

#### Microsoft Organizasyonu  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Tarayıcı otomasyonu ve testi için Playwright MCP sunucusu  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Yerel test ve topluluk katkısı için OneDrive MCP sunucu uygulaması  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Açık protokoller ve ilgili açık kaynak araçlar koleksiyonu; AI Web için temel katman oluşturmayı hedefler  

#### Azure-Samples Organizasyonu  
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure üzerinde çoklu dillerle MCP sunucuları oluşturma ve entegre etme için örnekler, araçlar ve kaynaklar  
2. [mcp-auth-servers](https
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
2. Proje fikirlerinden birini seçin ve detaylı bir teknik şartname oluşturun.
3. Vaka çalışmalarında yer almayan bir sektörü araştırın ve MCP'nin bu sektörün özel zorluklarını nasıl çözebileceğini özetleyin.
4. Gelecekteki yönlerden birini inceleyin ve bunu destekleyecek yeni bir MCP uzantısı için bir konsept oluşturun.

Sonraki: [Best Practices](../08-BestPractices/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.