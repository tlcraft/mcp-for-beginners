<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:30:50+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tl"
}
-->
# Mga Aral mula sa mga Maagang Tagapagpatibay

## Pangkalahatang-ideya

Ang leksyong ito ay sumasaliksik kung paano nagamit ng mga maagang tagapagpatibay ang Model Context Protocol (MCP) upang malutas ang mga tunay na hamon at pasiglahin ang inobasyon sa iba't ibang industriya. Sa pamamagitan ng detalyadong pag-aaral ng kaso at mga proyektong may aktwal na karanasan, makikita mo kung paano nagbibigay-daan ang MCP sa standardized, secure, at scalable na AI integration—pagkonekta sa malalaking language model, mga tool, at enterprise data sa isang pinagsama-samang balangkas. Makakakuha ka ng praktikal na karanasan sa pagdidisenyo at pagbuo ng mga solusyong batay sa MCP, matututo mula sa mga napatunayang pattern ng pagpapatupad, at matutuklasan ang pinakamahusay na mga kasanayan para sa pag-deploy ng MCP sa mga production environment. Ang leksyon ay nagbibigay-diin din sa mga umuusbong na trend, mga direksyon sa hinaharap, at mga open-source na mapagkukunan upang makatulong sa iyong pananatili sa unahan ng teknolohiyang MCP at ang umuusbong na ekosistema nito.

## Mga Layunin sa Pagkatuto

- Suriin ang mga tunay na implementasyon ng MCP sa iba't ibang industriya
- Magdisenyo at bumuo ng kumpletong mga aplikasyon na batay sa MCP
- Galugarin ang mga umuusbong na trend at mga direksyon sa hinaharap sa teknolohiyang MCP
- Ipatupad ang pinakamahusay na mga kasanayan sa aktwal na mga senaryo ng pag-unlad

## Mga Tunay na Implementasyon ng MCP

### Pag-aaral ng Kaso 1: Awtomasyon ng Suporta sa Customer ng Enterprise

Isang multinasyunal na korporasyon ang nagpatupad ng solusyong batay sa MCP upang i-standardize ang mga pakikipag-ugnayan ng AI sa kanilang mga sistema ng suporta sa customer. Pinayagan silang:

- Lumikha ng isang pinagsama-samang interface para sa maraming LLM provider
- Panatilihin ang pare-parehong pamamahala ng prompt sa iba't ibang departamento
- Magpatupad ng matatag na mga kontrol sa seguridad at pagsunod
- Madaling lumipat sa pagitan ng iba't ibang modelo ng AI batay sa tiyak na mga pangangailangan

**Teknikal na Implementasyon:**
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

**Mga Resulta:** 30% na pagbawas sa gastos ng modelo, 45% na pagpapabuti sa pagkakapare-pareho ng tugon, at pinahusay na pagsunod sa pandaigdigang operasyon.

### Pag-aaral ng Kaso 2: Katulong sa Diyagnostiko ng Pangangalaga sa Kalusugan

Isang tagapagbigay ng pangangalaga sa kalusugan ang bumuo ng imprastraktura ng MCP upang isama ang maraming dalubhasang medikal na AI model habang tinitiyak na protektado ang sensitibong datos ng pasyente:

- Walang putol na paglipat sa pagitan ng mga generalist at specialist na medikal na modelo
- Mahigpit na mga kontrol sa privacy at mga audit trail
- Pagsasama sa umiiral na mga sistema ng Electronic Health Record (EHR)
- Pare-parehong prompt engineering para sa medikal na terminolohiya

**Teknikal na Implementasyon:**
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

**Mga Resulta:** Pinahusay na mga mungkahi sa diyagnostiko para sa mga doktor habang pinapanatili ang buong pagsunod sa HIPAA at makabuluhang pagbawas sa paglipat ng konteksto sa pagitan ng mga sistema.

### Pag-aaral ng Kaso 3: Pagsusuri ng Panganib sa Serbisyong Pinansyal

Isang institusyong pinansyal ang nagpatupad ng MCP upang i-standardize ang kanilang mga proseso ng pagsusuri ng panganib sa iba't ibang departamento:

- Lumikha ng isang pinagsama-samang interface para sa mga modelo ng panganib sa kredito, pagtuklas ng pandaraya, at panganib sa pamumuhunan
- Nagpatupad ng mahigpit na mga kontrol sa pag-access at bersyon ng modelo
- Tiniyak ang auditability ng lahat ng rekomendasyon ng AI
- Pinanatili ang pare-parehong pag-format ng datos sa magkakaibang mga sistema

**Teknikal na Implementasyon:**
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

**Mga Resulta:** Pinahusay na pagsunod sa regulasyon, 40% na mas mabilis na mga siklo ng pag-deploy ng modelo, at pinahusay na pagkakapare-pareho ng pagsusuri ng panganib sa mga departamento.

### Pag-aaral ng Kaso 4: Microsoft Playwright MCP Server para sa Awtomasyon ng Browser

Ang Microsoft ay bumuo ng [Playwright MCP server](https://github.com/microsoft/playwright-mcp) upang paganahin ang secure, standardized na awtomasyon ng browser sa pamamagitan ng Model Context Protocol. Ang solusyong ito ay nagpapahintulot sa mga AI agent at LLM na makipag-ugnayan sa mga web browser sa isang kontrolado, ma-audit, at extensible na paraan—na nagbibigay-daan sa mga kaso ng paggamit tulad ng automated web testing, data extraction, at end-to-end workflows.

- Naglalantad ng mga kakayahan sa awtomasyon ng browser (navigation, form filling, screenshot capture, atbp.) bilang mga tool ng MCP
- Nagpapatupad ng mahigpit na mga kontrol sa pag-access at sandboxing upang maiwasan ang hindi awtorisadong mga aksyon
- Nagbibigay ng detalyadong mga audit log para sa lahat ng pakikipag-ugnayan sa browser
- Sinusuportahan ang pagsasama sa Azure OpenAI at iba pang mga LLM provider para sa automation na pinapatakbo ng agent

**Teknikal na Implementasyon:**
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

**Mga Resulta:**  
- Pinagana ang secure, programmatic na awtomasyon ng browser para sa mga AI agent at LLM
- Bawasan ang manu-manong pagsusumikap sa pagsubok at pinahusay na saklaw ng pagsubok para sa mga web application
- Nagbigay ng reusable, extensible na balangkas para sa integrasyon ng tool na nakabase sa browser sa mga kapaligiran ng enterprise

**Mga Sanggunian:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Pag-aaral ng Kaso 5: Azure MCP – Enterprise-Grade Model Context Protocol bilang Serbisyo

Ang Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ay ang managed, enterprise-grade na implementasyon ng Microsoft ng Model Context Protocol, na idinisenyo upang magbigay ng scalable, secure, at compliant na kakayahan ng MCP server bilang isang cloud service. Pinapagana ng Azure MCP ang mga organisasyon na mabilis na mag-deploy, pamahalaan, at isama ang mga MCP server sa Azure AI, data, at mga serbisyo ng seguridad, na binabawasan ang operational overhead at pinapabilis ang pag-aampon ng AI.

- Fully managed na hosting ng MCP server na may built-in na scaling, monitoring, at security
- Native na integrasyon sa Azure OpenAI, Azure AI Search, at iba pang mga serbisyo ng Azure
- Enterprise authentication at authorization sa pamamagitan ng Microsoft Entra ID
- Suporta para sa mga custom na tool, prompt template, at resource connector
- Pagsunod sa seguridad ng enterprise at mga kinakailangan sa regulasyon

**Teknikal na Implementasyon:**
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

**Mga Resulta:**  
- Bawasan ang oras-to-value para sa mga proyekto ng enterprise AI sa pamamagitan ng pagbibigay ng ready-to-use, compliant na platform ng MCP server
- Pinadali ang integrasyon ng mga LLM, tool, at mga pinagkukunan ng datos ng enterprise
- Pinahusay na seguridad, observability, at operational efficiency para sa mga workload ng MCP

**Mga Sanggunian:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Mga Proyektong Hands-on

### Proyekto 1: Bumuo ng Multi-Provider MCP Server

**Layunin:** Lumikha ng MCP server na maaaring mag-route ng mga kahilingan sa maraming AI model provider batay sa tiyak na pamantayan.

**Mga Kinakailangan:**
- Suportahan ang hindi bababa sa tatlong iba't ibang model provider (hal. OpenAI, Anthropic, lokal na mga modelo)
- Magpatupad ng routing mechanism batay sa metadata ng kahilingan
- Lumikha ng configuration system para sa pamamahala ng mga kredensyal ng provider
- Magdagdag ng caching upang i-optimize ang performance at mga gastos
- Bumuo ng simpleng dashboard para sa pagsubaybay sa paggamit

**Mga Hakbang sa Implementasyon:**
1. I-set up ang pangunahing imprastraktura ng MCP server
2. Magpatupad ng mga provider adapter para sa bawat serbisyo ng AI model
3. Lumikha ng routing logic batay sa mga attribute ng kahilingan
4. Magdagdag ng mga caching mechanism para sa mga madalas na kahilingan
5. Bumuo ng monitoring dashboard
6. Subukan gamit ang iba't ibang pattern ng kahilingan

**Mga Teknolohiya:** Pumili mula sa Python (.NET/Java/Python batay sa iyong kagustuhan), Redis para sa caching, at simpleng web framework para sa dashboard.

### Proyekto 2: Enterprise Prompt Management System

**Layunin:** Bumuo ng sistemang batay sa MCP para sa pamamahala, bersyon, at pag-deploy ng mga prompt template sa buong organisasyon.

**Mga Kinakailangan:**
- Lumikha ng centralized repository para sa mga prompt template
- Magpatupad ng mga workflow ng bersyon at pag-apruba
- Bumuo ng mga kakayahan sa pagsubok ng template gamit ang mga sample na input
- Bumuo ng mga kontrol sa pag-access na batay sa tungkulin
- Lumikha ng API para sa pagkuha at pag-deploy ng template

**Mga Hakbang sa Implementasyon:**
1. Idisenyo ang database schema para sa imbakan ng template
2. Lumikha ng core API para sa mga operasyon ng template CRUD
3. Magpatupad ng sistema ng bersyon
4. Bumuo ng workflow ng pag-apruba
5. Bumuo ng framework sa pagsubok
6. Lumikha ng simpleng web interface para sa pamamahala
7. Isama sa isang MCP server

**Mga Teknolohiya:** Ang iyong piniling backend framework, SQL o NoSQL database, at frontend framework para sa interface ng pamamahala.

### Proyekto 3: MCP-Based Content Generation Platform

**Layunin:** Bumuo ng content generation platform na gumagamit ng MCP upang magbigay ng pare-parehong resulta sa iba't ibang uri ng nilalaman.

**Mga Kinakailangan:**
- Suportahan ang maraming format ng nilalaman (blog post, social media, marketing copy)
- Magpatupad ng template-based na pagbuo na may mga opsyon sa pagpapasadya
- Lumikha ng sistema ng pagsusuri at feedback ng nilalaman
- Subaybayan ang mga sukatan ng pagganap ng nilalaman
- Suportahan ang pag-bersyon at pag-ulit ng nilalaman

**Mga Hakbang sa Implementasyon:**
1. I-set up ang imprastraktura ng MCP client
2. Lumikha ng mga template para sa iba't ibang uri ng nilalaman
3. Bumuo ng pipeline ng pagbuo ng nilalaman
4. Magpatupad ng sistema ng pagsusuri
5. Bumuo ng sistema ng pagsubaybay sa mga sukatan
6. Lumikha ng user interface para sa pamamahala ng template at pagbuo ng nilalaman

**Mga Teknolohiya:** Ang iyong piniling programming language, web framework, at sistema ng database.

## Mga Direksyon sa Hinaharap para sa Teknolohiyang MCP

### Mga Umuusbong na Trend

1. **Multi-Modal MCP**
   - Pagpapalawak ng MCP upang i-standardize ang mga pakikipag-ugnayan sa mga modelo ng imahe, audio, at video
   - Pagbuo ng cross-modal reasoning capabilities
   - Standardized na mga format ng prompt para sa iba't ibang modalities

2. **Federated MCP Infrastructure**
   - Distributed na mga network ng MCP na maaaring magbahagi ng mga mapagkukunan sa mga organisasyon
   - Standardized na mga protocol para sa secure na pagbabahagi ng modelo
   - Mga teknik sa privacy-preserving computation

3. **MCP Marketplaces**
   - Mga ekosistema para sa pagbabahagi at pag-monetize ng mga template at plugin ng MCP
   - Mga proseso ng pagtiyak ng kalidad at sertipikasyon
   - Pagsasama sa mga marketplace ng modelo

4. **MCP para sa Edge Computing**
   - Pag-angkop ng mga pamantayan ng MCP para sa mga resource-constrained na edge device
   - Mga optimized na protocol para sa mga low-bandwidth na kapaligiran
   - Mga espesyal na implementasyon ng MCP para sa mga ekosistema ng IoT

5. **Regulatory Frameworks**
   - Pagbuo ng mga extension ng MCP para sa pagsunod sa regulasyon
   - Standardized na mga audit trail at explainability interface
   - Pagsasama sa mga umuusbong na balangkas ng pamamahala ng AI

### Mga Solusyon ng MCP mula sa Microsoft

Ang Microsoft at Azure ay bumuo ng ilang open-source na repository upang matulungan ang mga developer na ipatupad ang MCP sa iba't ibang senaryo:

#### Microsoft Organization
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Isang Playwright MCP server para sa awtomasyon at pagsubok ng browser
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Isang OneDrive MCP server na implementasyon para sa lokal na pagsubok at kontribusyon ng komunidad

#### Azure-Samples Organization
1. [mcp](https://github.com/Azure-Samples/mcp) - Mga link sa mga sample, tool, at mapagkukunan para sa pagbuo at pagsasama ng mga MCP server sa Azure gamit ang maraming wika
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Mga reference na MCP server na nagpapakita ng authentication gamit ang kasalukuyang Model Context Protocol na detalye
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Landing page para sa mga implementasyon ng Remote MCP Server sa Azure Functions na may mga link sa language-specific na repos
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Quickstart template para sa pagbuo at pag-deploy ng custom na remote MCP servers gamit ang Azure Functions sa Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Quickstart template para sa pagbuo at pag-deploy ng custom na remote MCP servers gamit ang Azure Functions sa .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Quickstart template para sa pagbuo at pag-deploy ng custom na remote MCP servers gamit ang Azure Functions sa TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management bilang AI Gateway sa Remote MCP servers gamit ang Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI experiments kabilang ang mga kakayahan ng MCP, pagsasama sa Azure OpenAI at AI Foundry

Ang mga repository na ito ay nagbibigay ng iba't ibang implementasyon, template, at mapagkukunan para sa pagtatrabaho sa Model Context Protocol sa iba't ibang programming languages at mga serbisyo ng Azure. Sinasaklaw nila ang hanay ng mga kaso ng paggamit mula sa pangunahing implementasyon ng server hanggang sa authentication, cloud deployment, at mga senaryo ng integrasyon ng enterprise.

#### Direktoryo ng Mga Mapagkukunan ng MCP

Ang [MCP Resources directory](https://github.com/microsoft/mcp/tree/main/Resources) sa opisyal na Microsoft MCP repository ay nagbibigay ng curated na koleksyon ng mga sample na mapagkukunan, prompt template, at mga kahulugan ng tool para sa paggamit sa mga Model Context Protocol server. Ang direktoryong ito ay idinisenyo upang matulungan ang mga developer na mabilis na makapagsimula sa MCP sa pamamagitan ng pag-aalok ng reusable na mga bloke ng gusali at mga halimbawa ng pinakamahusay na kasanayan para sa:

- **Prompt Templates:** Mga handa nang gamitin na prompt template para sa mga karaniwang gawain at senaryo ng AI, na maaaring iakma para sa iyong sariling mga implementasyon ng MCP server.
- **Mga Kahulugan ng Tool:** Mga halimbawa ng tool schemas at metadata upang i-standardize ang integrasyon ng tool at pagtawag sa iba't ibang mga MCP server.
- **Mga Sample na Mapagkukunan:** Mga halimbawa ng kahulugan ng mapagkukunan para sa pagkonekta sa mga pinagkukunan ng datos, mga API, at panlabas na serbisyo sa loob ng balangkas ng MCP.
- **Mga Implementasyon ng Sanggunian:** Mga praktikal na halimbawa na nagpapakita kung paano i-istruktura at ayusin ang mga mapagkukunan, prompt, at tool sa mga tunay na proyekto ng MCP.

Ang mga mapagkukunang ito ay nagpapabilis ng pag-unlad, nagtataguyod ng standardisasyon, at tumutulong na matiyak ang pinakamahusay na mga kasanayan kapag bumubuo at nagde-deploy ng mga solusyong batay sa MCP.

#### Direktoryo ng Mga Mapagkukunan ng MCP
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Mga Pagkakataon sa Pananaliksik

- Mahusay na mga teknik sa pag-optimize ng prompt sa loob ng mga balangkas ng MCP
- Mga modelo ng seguridad para sa multi-tenant na mga deployment ng MCP
- Pag-benchmark ng pagganap sa iba't ibang implementasyon ng MCP
- Mga pormal na paraan ng pag-verify para sa mga MCP server


- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Mga Ehersisyo

1. Suriin ang isa sa mga case study at magmungkahi ng alternatibong paraan ng pagpapatupad.
2. Pumili ng isa sa mga ideya ng proyekto at gumawa ng detalyadong teknikal na espesipikasyon.
3. Mag-research sa isang industriya na hindi sakop sa mga case study at ilarawan kung paano matutugunan ng MCP ang mga partikular nitong hamon.
4. Tuklasin ang isa sa mga direksyon sa hinaharap at lumikha ng konsepto para sa bagong MCP extension upang suportahan ito.

Susunod: [Pinakamahusay na Kasanayan](../08-BestPractices/README.md)

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama't pinagsisikapan namin ang kawastuhan, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga error o pagkakamali. Ang orihinal na dokumento sa sariling wika nito ay dapat ituring na mapagkakatiwalaang mapagkukunan. Para sa kritikal na impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Kami ay hindi mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.