<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T22:16:39+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tl"
}
-->
# Mga Aral mula sa mga Maagang Gumamit

## Pangkalahatang Pagsusuri

Tinutuklas ng araling ito kung paano ginamit ng mga maagang gumamit ang Model Context Protocol (MCP) upang lutasin ang mga totoong suliranin at pasiglahin ang inobasyon sa iba't ibang industriya. Sa pamamagitan ng mga detalyadong pag-aaral ng kaso at praktikal na proyekto, makikita mo kung paano pinapadali ng MCP ang standardisadong, ligtas, at nasuskalang integrasyon ng AI—na nag-uugnay sa malalaking language model, mga kasangkapan, at datos ng negosyo sa isang pinag-isang sistema. Makakakuha ka ng praktikal na karanasan sa pagdidisenyo at paggawa ng mga solusyong batay sa MCP, matututo mula sa mga napatunayang paraan ng implementasyon, at matutuklasan ang mga pinakamahusay na gawain para sa pag-deploy ng MCP sa mga production environment. Binibigyang-diin din ng aralin ang mga umuusbong na uso, mga direksyon sa hinaharap, at mga open-source na mapagkukunan upang matulungan kang manatiling nangunguna sa teknolohiya ng MCP at sa patuloy nitong pag-unlad.

## Mga Layunin sa Pagkatuto

- Suriin ang mga totoong implementasyon ng MCP sa iba't ibang industriya
- Magdisenyo at bumuo ng kumpletong mga aplikasyon na batay sa MCP
- Tuklasin ang mga umuusbong na uso at mga hinaharap na direksyon sa teknolohiya ng MCP
- Ipatupad ang mga pinakamahusay na gawain sa aktwal na mga senaryo ng pag-develop

## Mga Totoong Implementasyon ng MCP

### Pag-aaral ng Kaso 1: Enterprise Customer Support Automation

Isang multinasyunal na korporasyon ang nagpatupad ng solusyong batay sa MCP upang gawing standard ang mga AI interaction sa kanilang mga sistema ng customer support. Dahil dito, nagawa nilang:

- Lumikha ng pinag-isang interface para sa iba't ibang LLM provider
- Panatilihin ang pare-parehong pamamahala ng prompt sa buong departamento
- Magpatupad ng matibay na seguridad at pagsunod sa regulasyon
- Madaling makalipat-lipat sa iba't ibang AI model batay sa partikular na pangangailangan

**Technical Implementation:**  
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

**Mga Resulta:** 30% na pagbaba sa gastos sa model, 45% na pagbuti sa consistency ng tugon, at pinahusay na pagsunod sa regulasyon sa buong operasyon sa buong mundo.

### Pag-aaral ng Kaso 2: Healthcare Diagnostic Assistant

Isang healthcare provider ang bumuo ng MCP infrastructure upang pagsamahin ang iba't ibang espesyal na medikal na AI model habang pinoprotektahan ang sensitibong datos ng pasyente:

- Madaling paglipat sa pagitan ng generalist at specialist na medikal na mga modelo
- Mahigpit na kontrol sa privacy at audit trails
- Integrasyon sa umiiral na Electronic Health Record (EHR) systems
- Pare-parehong prompt engineering para sa medikal na terminolohiya

**Technical Implementation:**  
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

**Mga Resulta:** Pinahusay na mga suhestiyon sa diagnosis para sa mga doktor habang nananatiling ganap na sumusunod sa HIPAA at malaking pagbabawas sa context-switching sa pagitan ng mga sistema.

### Pag-aaral ng Kaso 3: Financial Services Risk Analysis

Isang institusyong pinansyal ang nagpatupad ng MCP upang gawing standard ang kanilang mga proseso ng risk analysis sa iba't ibang departamento:

- Lumikha ng pinag-isang interface para sa credit risk, fraud detection, at investment risk models
- Nagpatupad ng mahigpit na access controls at versioning ng mga modelo
- Tiniyak ang auditability ng lahat ng rekomendasyon ng AI
- Pinanatili ang consistent na data formatting sa iba't ibang sistema

**Technical Implementation:**  
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

**Mga Resulta:** Pinahusay na pagsunod sa regulasyon, 40% na mas mabilis na deployment cycles ng modelo, at pinabuting consistency sa risk assessment sa buong departamento.

### Pag-aaral ng Kaso 4: Microsoft Playwright MCP Server para sa Browser Automation

Binuo ng Microsoft ang [Playwright MCP server](https://github.com/microsoft/playwright-mcp) upang paganahin ang ligtas at standardisadong browser automation gamit ang Model Context Protocol. Pinapayagan ng solusyong ito ang AI agents at LLMs na makipag-ugnayan sa mga web browser sa kontrolado, auditable, at extensible na paraan—na sumusuporta sa mga gamit tulad ng automated web testing, data extraction, at end-to-end workflows.

- Inilalantad ang mga kakayahan sa browser automation (navigation, pag-fill ng form, pagkuha ng screenshot, atbp.) bilang mga MCP tools
- Nagpapatupad ng mahigpit na access controls at sandboxing para pigilan ang hindi awtorisadong aksyon
- Nagbibigay ng detalyadong audit logs para sa lahat ng browser interactions
- Sumusuporta sa integrasyon sa Azure OpenAI at iba pang LLM providers para sa agent-driven automation

**Technical Implementation:**  
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
- Nagbigay-daan sa ligtas at programmatic na browser automation para sa AI agents at LLMs  
- Nabawasan ang manu-manong testing effort at napabuti ang test coverage para sa mga web application  
- Nagbigay ng reusable at extensible na framework para sa integrasyon ng mga browser-based tool sa mga enterprise environment

**Mga Sanggunian:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Pag-aaral ng Kaso 5: Azure MCP – Enterprise-Grade Model Context Protocol bilang Serbisyo

Ang Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ay ang managed, enterprise-grade na implementasyon ng Model Context Protocol ng Microsoft, na idinisenyo upang magbigay ng scalable, secure, at compliant na MCP server capabilities bilang cloud service. Pinapayagan ng Azure MCP ang mga organisasyon na mabilis na mag-deploy, mag-manage, at mag-integrate ng MCP servers sa Azure AI, data, at security services, na nagpapababa ng operational overhead at nagpapabilis ng AI adoption.

- Ganap na managed na MCP server hosting na may built-in scaling, monitoring, at security
- Native na integrasyon sa Azure OpenAI, Azure AI Search, at iba pang Azure services
- Enterprise authentication at authorization gamit ang Microsoft Entra ID
- Suporta para sa custom tools, prompt templates, at resource connectors
- Pagsunod sa mga pangangailangan sa seguridad at regulasyon ng enterprise

**Technical Implementation:**  
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
- Pinabilis ang time-to-value para sa mga enterprise AI project sa pamamagitan ng pagbibigay ng handa nang gamitin, compliant na MCP server platform  
- Pinadali ang integrasyon ng LLMs, tools, at mga pinagkukunan ng datos ng enterprise  
- Pinahusay ang seguridad, obserbabilidad, at operational efficiency para sa MCP workloads

**Mga Sanggunian:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Pag-aaral ng Kaso 6: NLWeb

Ang MCP (Model Context Protocol) ay isang umuusbong na protocol para sa mga chatbot at AI assistant upang makipag-ugnayan sa mga tool. Bawat NLWeb instance ay isang MCP server din, na sumusuporta sa isang pangunahing method, ang ask, na ginagamit upang magtanong sa isang website gamit ang natural na wika. Ang tugon ay gumagamit ng schema.org, isang malawakang ginagamit na bokabularyo para ilarawan ang web data. Sa madaling salita, ang MCP ay parang NLWeb tulad ng Http sa HTML. Pinagsasama ng NLWeb ang mga protocol, format ng Schema.org, at mga sample code upang matulungan ang mga site na mabilis na makalikha ng mga endpoint na ito, na kapaki-pakinabang para sa mga tao sa pamamagitan ng conversational interfaces at para sa mga makina sa natural na agent-to-agent interaction.

May dalawang pangunahing bahagi ang NLWeb:  
- Isang protocol, na napakasimple bilang panimula, upang makipag-interface sa isang site gamit ang natural na wika at isang format, gamit ang json at schema.org para sa ibinabalik na sagot. Tingnan ang dokumentasyon sa REST API para sa karagdagang detalye.  
- Isang direktang implementasyon ng (1) na gumagamit ng umiiral na markup, para sa mga site na maaaring i-abstract bilang listahan ng mga item (produkto, recipe, atraksyon, review, atbp.). Kasama ang mga user interface widgets, madaling makapagbigay ang mga site ng conversational interfaces para sa kanilang nilalaman. Tingnan ang dokumentasyon sa Life of a chat query para sa karagdagang paliwanag kung paano ito gumagana.

**Mga Sanggunian:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## Mga Hands-on na Proyekto

### Proyekto 1: Gumawa ng Multi-Provider MCP Server

**Layunin:** Lumikha ng MCP server na kayang mag-route ng mga request sa iba't ibang AI model provider batay sa partikular na pamantayan.

**Mga Kinakailangan:**  
- Suportahan ang hindi bababa sa tatlong magkakaibang provider ng modelo (hal. OpenAI, Anthropic, lokal na mga modelo)  
- Magpatupad ng routing mechanism batay sa metadata ng request  
- Gumawa ng configuration system para sa pamamahala ng mga kredensyal ng provider  
- Magdagdag ng caching para mapabuti ang performance at mabawasan ang gastos  
- Bumuo ng simpleng dashboard para sa pag-monitor ng paggamit

**Mga Hakbang sa Implementasyon:**  
1. I-set up ang pangunahing MCP server infrastructure  
2. I-implementa ang provider adapters para sa bawat AI model service  
3. Gumawa ng routing logic batay sa mga attribute ng request  
4. Magdagdag ng caching mechanisms para sa madalas na mga request  
5. Bumuo ng monitoring dashboard  
6. Subukan gamit ang iba't ibang pattern ng request

**Mga Teknolohiya:** Pumili mula sa Python (.NET/Java/Python ayon sa iyong gusto), Redis para sa caching, at simpleng web framework para sa dashboard.

### Proyekto 2: Enterprise Prompt Management System

**Layunin:** Bumuo ng MCP-based system para sa pamamahala, versioning, at pag-deploy ng mga prompt template sa buong organisasyon.

**Mga Kinakailangan:**  
- Gumawa ng sentralisadong repository para sa mga prompt template  
- Magpatupad ng versioning at approval workflows  
- Bumuo ng kakayahan para sa testing ng template gamit ang mga sample input  
- Mag-develop ng role-based access controls  
- Gumawa ng API para sa retrieval at deployment ng mga template

**Mga Hakbang sa Implementasyon:**  
1. Disenyo ng database schema para sa pag-iimbak ng template  
2. Gumawa ng core API para sa CRUD operations ng template  
3. I-implementa ang versioning system  
4. Bumuo ng approval workflow  
5. Mag-develop ng testing framework  
6. Gumawa ng simpleng web interface para sa pamamahala  
7. I-integrate sa MCP server

**Mga Teknolohiya:** Anumang backend framework ang gusto mo, SQL o NoSQL na database, at frontend framework para sa management interface.

### Proyekto 3: MCP-Based Content Generation Platform

**Layunin:** Gumawa ng content generation platform na gumagamit ng MCP para magbigay ng consistent na resulta sa iba't ibang uri ng nilalaman.

**Mga Kinakailangan:**  
- Suportahan ang iba't ibang content format (blog posts, social media, marketing copy)  
- Magpatupad ng template-based generation na may mga customization option  
- Gumawa ng content review at feedback system  
- Subaybayan ang mga metric ng performance ng nilalaman  
- Suportahan ang versioning at iteration ng content

**Mga Hakbang sa Implementasyon:**  
1. I-set up ang MCP client infrastructure  
2. Gumawa ng mga template para sa iba't ibang uri ng content  
3. Bumuo ng content generation pipeline  
4. I-implementa ang review system  
5. Mag-develop ng metrics tracking system  
6. Gumawa ng user interface para sa pamamahala ng template at content generation

**Mga Teknolohiya:** Anumang programming language, web framework, at database system ang gusto mo.

## Mga Hinaharap na Direksyon para sa Teknolohiya ng MCP

### Mga Umuusbong na Uso

1. **Multi-Modal MCP**  
   - Pagpapalawak ng MCP upang gawing standard ang interaksyon sa mga image, audio, at video model  
   - Pagbuo ng cross-modal reasoning capabilities  
   - Standardisadong prompt format para sa iba't ibang modality

2. **Federated MCP Infrastructure**  
   - Distributed MCP network na kayang magbahagi ng resources sa iba't ibang organisasyon  
   - Standardisadong protocol para sa secure na pagbabahagi ng modelo  
   - Mga teknik para sa privacy-preserving computation

3. **MCP Marketplaces**  
   - Ecosystem para sa pagbabahagi at monetization ng MCP templates at plugins  
   - Quality assurance at certification processes  
   - Integrasyon sa mga model marketplace

4. **MCP para sa Edge Computing**  
   - Adaptasyon ng MCP standards para sa mga resource-constrained na edge device  
   - Optimized protocol para sa low-bandwidth na kapaligiran  
   - Espesyal na implementasyon ng MCP para sa IoT ecosystem

5. **Regulatory Frameworks**  
   - Pagbuo ng MCP extension para sa pagsunod sa regulasyon  
   - Standardisadong audit trails at explainability interfaces  
   - Integrasyon sa mga umuusbong na AI governance framework

### Mga Solusyon ng MCP mula sa Microsoft

Nakabuo ang Microsoft at Azure ng ilang open-source na repository upang tulungan ang mga developer na mag-implementa ng MCP sa iba't ibang senaryo:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP server para sa browser automation at testing  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP server implementation para sa local testing at community contribution  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Koleksyon ng open protocol at kaugnay na open source tools na nakatuon sa pagtatatag ng foundational layer para sa AI Web

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) - Mga sample, tools, at resources para sa paggawa at integrasyon ng MCP server sa Azure gamit ang iba't ibang wika  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Reference MCP server na nagpapakita ng authentication gamit ang kasalukuyang Model Context Protocol spec  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Landing page para sa Remote MCP Server implementations sa Azure Functions na may mga link sa language-specific repos  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Quickstart template para sa paggawa at pag-deploy ng custom remote MCP servers gamit ang Azure Functions at Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Quickstart template para sa paggawa at pag-deploy ng custom remote MCP servers gamit ang Azure Functions at .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Quickstart template para sa paggawa at pag-deploy ng custom remote MCP servers gamit ang Azure Functions at TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management bilang AI Gateway sa Remote MCP servers gamit ang Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI experiments kabilang ang MCP capabilities, integrasyon sa Azure OpenAI at AI Foundry

Nagbibigay ang mga repository na ito ng iba't ibang implementasyon, template, at resources para sa pagtatrabaho gamit ang Model Context Protocol sa iba't ibang programming language at Azure services. Saklaw nila ang mga gamit mula sa basic server implementations hanggang sa authentication, cloud deployment, at enterprise integration.

#### MCP Resources Directory

Ang [MCP Resources directory](https://github.com/microsoft/mcp/tree/main/Resources) sa opisyal na Microsoft MCP repository ay naglalaman ng curated na koleksyon ng mga sample resource, prompt template, at tool definition para gamitin sa Model Context Protocol servers. Dinisenyo ang direktoryong ito upang tulungan ang mga developer na mabilis makapagsimula sa MCP sa pamamagitan ng pagbibigay ng reusable building blocks at mga halimbawa ng pinakamahusay na gawain para sa:

- **Prompt Templates:** Handang gamitin na mga prompt template para sa mga karaniwang AI task at senaryo, na maaaring iangkop para sa sarili mong MCP server implementation.  
- **Tool Definitions:** Mga halimbawa ng tool schema at metadata upang gawing standard ang integrasyon at pagtawag ng mga tool sa iba't ibang MCP server.  
- **Resource Samples:** Mga halimbawa ng resource definition para sa pagkonekta sa mga data source, API, at external service sa loob ng MCP framework.  
- **Reference Implementations:** Praktikal na mga sample na nagpapakita kung paano istraktura at ayusin ang mga resource, prompt, at tool sa mga totoong proyekto ng MCP.

Pinapabilis ng mga resources na ito ang pag-develop, pinapalaganap ang standardisasyon, at tumutulong na masiguro ang pinakamahusay na gawain sa paggawa at pag-deploy ng mga solusyong batay sa MCP.

#### MCP Resources Directory  
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Mga Oportunidad sa Pananaliksik

- Epektibong mga teknik sa prompt optimization sa loob ng MCP framework  
- Mga security model para sa multi-tenant MCP deployment  
- Performance benchmarking sa iba't ibang implementasyon ng MCP  
- Formal verification methods para sa MCP servers

## Konklusyon

Ang Model Context Protocol (MCP) ay mabilis na humuhubog sa hinaharap ng standardisadong, ligtas, at interoperable na integrasyon ng AI sa iba't ibang industriya. Sa pamamagitan ng mga pag-aaral ng kaso at hands-on na proyekto sa araling ito, nakita mo
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Mga Ehersisyo

1. Suriin ang isa sa mga case study at magmungkahi ng alternatibong paraan ng pagpapatupad.
2. Pumili ng isa sa mga ideya ng proyekto at gumawa ng detalyadong teknikal na espesipikasyon.
3. Mag-research ng industriya na hindi sakop ng mga case study at ilarawan kung paano matutugunan ng MCP ang mga partikular nitong hamon.
4. Tuklasin ang isa sa mga hinaharap na direksyon at bumuo ng konsepto para sa bagong MCP extension upang suportahan ito.

Susunod: [Best Practices](../08-BestPractices/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kaming maging tumpak, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pinagmulan ng katotohanan. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.