<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T22:10:36+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tl"
}
-->
# Mga Aral mula sa mga Maagang Gumamit

## Pangkalahatang Pagsusuri

Tinutuklas ng araling ito kung paano ginamit ng mga maagang gumamit ang Model Context Protocol (MCP) upang lutasin ang mga totoong suliranin at magpasulong ng inobasyon sa iba't ibang industriya. Sa pamamagitan ng mga detalyadong pag-aaral ng kaso at praktikal na mga proyekto, makikita mo kung paano pinapadali ng MCP ang standardisadong, ligtas, at nasusukat na integrasyon ng AI—na nag-uugnay sa malalaking language model, mga tool, at datos ng negosyo sa isang pinag-isang balangkas. Makakakuha ka ng praktikal na karanasan sa pagdidisenyo at paggawa ng mga solusyong nakabase sa MCP, matututo mula sa mga napatunayang pattern ng implementasyon, at matutuklasan ang mga pinakamahuhusay na pamamaraan para sa pag-deploy ng MCP sa mga production environment. Binibigyang-diin din ng aralin ang mga umuusbong na uso, mga direksyon sa hinaharap, at mga open-source na mapagkukunan upang matulungan kang manatiling nangunguna sa teknolohiya ng MCP at sa patuloy nitong pag-unlad.

## Mga Layunin sa Pagkatuto

- Suriin ang mga totoong implementasyon ng MCP sa iba't ibang industriya  
- Magdisenyo at bumuo ng kumpletong mga aplikasyon na nakabase sa MCP  
- Tuklasin ang mga umuusbong na uso at mga direksyon sa hinaharap sa teknolohiya ng MCP  
- Ilapat ang mga pinakamahusay na kasanayan sa aktwal na mga sitwasyon sa pag-develop  

## Mga Totoong Implementasyon ng MCP

### Pag-aaral ng Kaso 1: Enterprise Customer Support Automation

Isang multinasyonal na korporasyon ang nagpatupad ng solusyong nakabase sa MCP upang i-standardize ang AI interactions sa kanilang mga customer support system. Pinayagan nito silang:

- Gumawa ng pinag-isang interface para sa maraming LLM provider  
- Panatilihin ang pare-parehong pamamahala ng prompt sa iba't ibang departamento  
- Magpatupad ng matibay na seguridad at mga kontrol sa pagsunod  
- Madaling magpalit-palit sa pagitan ng iba't ibang AI model ayon sa partikular na pangangailangan  

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

**Mga Resulta:** 30% bawas sa gastos ng modelo, 45% pagbuti sa konsistensi ng tugon, at pinahusay na pagsunod sa mga patakaran sa buong pandaigdigang operasyon.

### Pag-aaral ng Kaso 2: Healthcare Diagnostic Assistant

Isang healthcare provider ang bumuo ng MCP infrastructure upang pagsamahin ang maraming espesyalistang medikal na AI model habang pinananatiling protektado ang sensitibong datos ng pasyente:

- Walang patid na paglipat sa pagitan ng generalist at specialist na medikal na mga modelo  
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

**Mga Resulta:** Pinahusay na mga mungkahi sa diagnosis para sa mga doktor habang nananatiling ganap na sumusunod sa HIPAA at malaking pagbawas sa paglipat-lipat ng konteksto sa pagitan ng mga sistema.

### Pag-aaral ng Kaso 3: Financial Services Risk Analysis

Isang institusyong pinansyal ang nagpatupad ng MCP upang i-standardize ang kanilang mga proseso ng risk analysis sa iba't ibang departamento:

- Gumawa ng pinag-isang interface para sa credit risk, fraud detection, at investment risk models  
- Nagpatupad ng mahigpit na access controls at model versioning  
- Tiniyak ang auditability ng lahat ng rekomendasyon ng AI  
- Pinanatili ang pare-parehong format ng datos sa magkakaibang sistema  

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

**Mga Resulta:** Pinahusay na pagsunod sa regulasyon, 40% mas mabilis na mga cycle ng deployment ng modelo, at mas mahusay na konsistensi sa pagsusuri ng panganib sa mga departamento.

### Pag-aaral ng Kaso 4: Microsoft Playwright MCP Server para sa Browser Automation

Binuo ng Microsoft ang [Playwright MCP server](https://github.com/microsoft/playwright-mcp) upang paganahin ang ligtas at standardisadong browser automation gamit ang Model Context Protocol. Pinapayagan ng solusyong ito ang mga AI agent at LLM na makipag-ugnayan sa mga web browser sa isang kontrolado, na-audit, at pinalawak na paraan—na nagbibigay-daan sa mga use case tulad ng automated web testing, data extraction, at end-to-end workflows.

- Inilalantad ang mga kakayahan sa browser automation (navigation, pag-fill ng form, pagkuha ng screenshot, atbp.) bilang MCP tools  
- Nagpatupad ng mahigpit na access controls at sandboxing upang maiwasan ang hindi awtorisadong aksyon  
- Nagbibigay ng detalyadong audit logs para sa lahat ng browser interactions  
- Sinusuportahan ang integrasyon sa Azure OpenAI at iba pang LLM provider para sa agent-driven automation  

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
- Nagbigay-daan sa ligtas at programmatic browser automation para sa AI agent at LLM  
- Nabawasan ang manual testing effort at pinabuti ang test coverage para sa web applications  
- Nagbigay ng reusable at extensible na framework para sa browser-based tool integration sa mga enterprise environment  

**Mga Sanggunian:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Pag-aaral ng Kaso 5: Azure MCP – Enterprise-Grade Model Context Protocol bilang Serbisyo

Ang Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ay managed, enterprise-grade na implementasyon ng Model Context Protocol mula sa Microsoft, na idinisenyo upang magbigay ng scalable, secure, at compliant MCP server capabilities bilang cloud service. Pinapahintulutan ng Azure MCP ang mga organisasyon na mabilis na mag-deploy, mag-manage, at mag-integrate ng MCP servers sa Azure AI, data, at security services, na nagpapababa ng operational overhead at nagpapabilis ng AI adoption.

- Fully managed MCP server hosting na may built-in scaling, monitoring, at security  
- Native integration sa Azure OpenAI, Azure AI Search, at iba pang Azure services  
- Enterprise authentication at authorization gamit ang Microsoft Entra ID  
- Suporta para sa custom tools, prompt templates, at resource connectors  
- Pagsunod sa mga enterprise security at regulatory requirements  

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
- Pinabilis ang time-to-value para sa mga enterprise AI project sa pamamagitan ng pagbibigay ng ready-to-use at compliant na MCP server platform  
- Pinadali ang integrasyon ng LLMs, tools, at enterprise data sources  
- Pinahusay ang seguridad, obserbabilidad, at operational efficiency para sa mga MCP workload  

**Mga Sanggunian:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Pag-aaral ng Kaso 6: NLWeb

Ang MCP (Model Context Protocol) ay isang umuusbong na protocol para sa Chatbots at AI assistant upang makipag-ugnayan sa mga tool. Bawat NLWeb instance ay isang MCP server din, na sumusuporta sa isang pangunahing method, ang ask, na ginagamit upang magtanong sa isang website gamit ang natural na wika. Ang tugon na ibinabalik ay gumagamit ng schema.org, isang malawakang ginagamit na bokabularyo para ilarawan ang web data. Sa madaling salita, ang MCP ay para sa NLWeb tulad ng Http ay para sa HTML. Pinagsasama ng NLWeb ang mga protocol, Schema.org formats, at sample code upang tulungan ang mga site na mabilis na makagawa ng mga endpoint na ito, na kapaki-pakinabang sa parehong tao sa pamamagitan ng conversational interfaces at makina sa pamamagitan ng natural agent-to-agent interaction.

May dalawang pangunahing bahagi ang NLWeb.  
- Isang protocol, napakasimple sa simula, para makipag-interface sa isang site gamit ang natural na wika at isang format na gumagamit ng json at schema.org para sa tugon. Tingnan ang dokumentasyon sa REST API para sa karagdagang detalye.  
- Isang tuwirang implementasyon ng (1) na gumagamit ng umiiral na markup, para sa mga site na maaaring i-abstract bilang mga listahan ng mga item (produkto, recipe, atraksyon, review, atbp.). Kasama ng isang set ng mga user interface widget, madaling makapagbigay ang mga site ng conversational interface sa kanilang nilalaman. Tingnan ang dokumentasyon sa Life of a chat query para sa higit pang detalye kung paano ito gumagana.

**Mga Sanggunian:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Pag-aaral ng Kaso 7: MCP para sa Foundry – Pagsasama ng Azure AI Agents

Ipinapakita ng Azure AI Foundry MCP servers kung paano magagamit ang MCP upang i-orchestrate at pamahalaan ang AI agents at workflows sa mga enterprise environment. Sa pamamagitan ng pagsasama ng MCP sa Azure AI Foundry, maaaring i-standardize ng mga organisasyon ang agent interactions, gamitin ang workflow management ng Foundry, at matiyak ang ligtas at scalable na deployment. Pinapahintulutan ng paraan na ito ang mabilis na prototyping, matibay na monitoring, at seamless integration sa Azure AI services, na sumusuporta sa mga advanced na senaryo tulad ng knowledge management at agent evaluation. Nakikinabang ang mga developer mula sa isang pinag-isang interface para sa pagbuo, pag-deploy, at pag-monitor ng agent pipelines, habang ang IT teams naman ay nakakakuha ng pinahusay na seguridad, pagsunod, at operational efficiency. Ang solusyon ay perpekto para sa mga enterprise na naghahangad na pabilisin ang AI adoption at mapanatili ang kontrol sa kumplikadong mga proseso na pinapatakbo ng mga agent.

**Mga Sanggunian:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Pag-aaral ng Kaso 8: Foundry MCP Playground – Eksperimento at Prototyping

Nagbibigay ang Foundry MCP Playground ng handang-gamitin na kapaligiran para sa pag-eksperimento sa MCP servers at Azure AI Foundry integrations. Maaaring mabilis na mag-prototype, mag-test, at mag-evaluate ng AI models at agent workflows ang mga developer gamit ang mga resources mula sa Azure AI Foundry Catalog at Labs. Pinapasimple ng playground ang setup, nagbibigay ng mga sample project, at sumusuporta sa kolaboratibong pag-develop, kaya madaling tuklasin ang mga pinakamahusay na kasanayan at bagong senaryo nang may minimal na overhead. Lalo na itong kapaki-pakinabang para sa mga team na nais patunayan ang mga ideya, magbahagi ng mga eksperimento, at pabilisin ang pagkatuto nang hindi kailangan ng kumplikadong imprastruktura. Sa pamamagitan ng pagpapababa ng hadlang sa pagsisimula, tinutulungan ng playground na pasiglahin ang inobasyon at kontribusyon ng komunidad sa MCP at Azure AI Foundry ecosystem.

**Mga Sanggunian:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Mga Hands-on na Proyekto

### Proyekto 1: Gumawa ng Multi-Provider MCP Server

**Layunin:** Gumawa ng MCP server na maaaring mag-route ng mga request sa iba't ibang AI model provider base sa partikular na mga pamantayan.

**Mga Kinakailangan:**  
- Suportahan ang hindi bababa sa tatlong iba't ibang model provider (hal. OpenAI, Anthropic, lokal na mga modelo)  
- Magpatupad ng routing mechanism base sa metadata ng request  
- Gumawa ng configuration system para sa pamamahala ng provider credentials  
- Magdagdag ng caching para mapabuti ang performance at bawasan ang gastos  
- Bumuo ng simpleng dashboard para sa pag-monitor ng paggamit  

**Mga Hakbang sa Implementasyon:**  
1. I-set up ang pangunahing MCP server infrastructure  
2. Magpatupad ng provider adapters para sa bawat AI model service  
3. Gumawa ng routing logic base sa mga attribute ng request  
4. Magdagdag ng caching mechanism para sa mga madalas na request  
5. Bumuo ng monitoring dashboard  
6. Subukan gamit ang iba't ibang pattern ng request  

**Mga Teknolohiya:** Pumili mula sa Python (.NET/Java/Python ayon sa iyong gusto), Redis para sa caching, at isang simpleng web framework para sa dashboard.

### Proyekto 2: Enterprise Prompt Management System

**Layunin:** Bumuo ng MCP-based na sistema para sa pamamahala, versioning, at pag-deploy ng prompt templates sa buong organisasyon.

**Mga Kinakailangan:**  
- Gumawa ng sentralisadong repository para sa mga prompt template  
- Magpatupad ng versioning at approval workflow  
- Bumuo ng kakayahan para sa template testing gamit ang sample inputs  
- Mag-develop ng role-based access control  
- Gumawa ng API para sa retrieval at deployment ng mga template  

**Mga Hakbang sa Implementasyon:**  
1. Disenyuhin ang database schema para sa pag-iimbak ng template  
2. Gumawa ng core API para sa CRUD operations ng template  
3. Magpatupad ng versioning system  
4. Bumuo ng approval workflow  
5. Mag-develop ng testing framework  
6. Gumawa ng simpleng web interface para sa pamamahala  
7. I-integrate sa isang MCP server  

**Mga Teknolohiya:** Pumili ng backend framework, SQL o NoSQL database, at frontend framework para sa management interface.

### Proyekto 3: MCP-Based Content Generation Platform

**Layunin:** Gumawa ng content generation platform na gumagamit ng MCP upang magbigay ng pare-parehong resulta sa iba't ibang uri ng nilalaman.

**Mga Kinakailangan:**  
- Suportahan ang maraming format ng nilalaman (blog posts, social media, marketing copy)  
- Magpatupad ng template-based generation na may mga opsyon para sa customization  
- Gumawa ng sistema para sa content review at feedback  
- Subaybayan ang mga performance metric ng nilalaman  
- Suportahan ang content versioning at iteration  

**Mga Hakbang sa Implementasyon:**  
1. I-set up ang MCP client infrastructure  
2. Gumawa ng mga template para sa iba't ibang uri ng nilalaman  
3. Bumuo ng content generation pipeline  
4. Magpatupad ng review system  
5. Mag-develop ng metrics tracking system  
6. Gumawa ng user interface para sa template management at content generation  

**Mga Teknolohiya:** Pumili ng paboritong programming language, web framework, at database system.

## Mga Direksyon sa Hinaharap para sa Teknolohiya ng MCP

### Mga Umuusbong na Uso

1. **Multi-Modal MCP**  
   - Pagpapalawak ng MCP upang i-standardize ang interactions sa mga image, audio, at video model  
   - Pag-develop ng cross-modal reasoning capabilities  
   - Standardized prompt formats para sa iba't ibang modality  

2. **Federated MCP Infrastructure**  
   - Distributed MCP networks na maaaring magbahagi ng resources sa pagitan ng mga organisasyon  
   - Standardized protocols para sa secure na pag-share ng mga modelo  
   - Mga teknik para sa privacy-preserving computation  

3. **MCP Marketplaces**  
   - Ecosystem para sa pag-share at monetization ng MCP templates at plugins  
   - Quality assurance at certification processes  
   - Integrasyon sa mga model marketplaces  

4. **MCP para sa Edge Computing**  
   - Pag-aangkop ng MCP standards para sa mga resource-constrained na edge device  
   - Optimized protocols para sa low-bandwidth na mga environment  
   - Espesyal na implementasyon ng MCP para sa IoT ecosystem  

5. **Regulatory Frameworks**  
   - Pag-develop ng MCP extensions para sa regulatory compliance  
   - Standardized audit trails at explainability interfaces  
   - Integrasyon sa mga umuusbong na AI governance framework  

### Mga Solusyon ng MCP mula sa Microsoft

Nag-develop ang Microsoft at Azure ng ilang open-source repositories upang tulungan ang mga developer na mag-implement ng MCP sa iba't ibang senaryo:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP server para sa browser automation at testing  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP server implementation para sa lokal na testing at community contribution  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Koleksyon ng open protocols at kaugnay na open source tools na nakatuon sa pagtatatag ng pundamental na layer para sa AI Web  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) - Mga sample, tool, at resources para sa paggawa at integrasyon ng MCP servers sa Azure gamit ang iba't ibang lengguwahe  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Reference MCP servers na nagpapakita ng authentication gamit ang kasalukuyang Model Context Protocol specification  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Landing page para sa Remote MCP Server implementations sa Azure Functions na may mga link sa mga language-specific repo  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Quickstart template para sa paggawa at pag-deploy ng custom remote MCP servers gamit ang Azure Functions sa Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Quickstart template para sa paggawa at pag-deploy ng custom remote MCP servers gamit ang Azure Functions sa .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Quickstart template para sa paggawa at pag-deploy ng custom remote MCP servers gamit ang Azure Functions sa TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote
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

## Mga Ehersisyo

1. Suriin ang isa sa mga case study at magmungkahi ng alternatibong paraan ng pagpapatupad.
2. Pumili ng isa sa mga ideya ng proyekto at gumawa ng detalyadong teknikal na espesipikasyon.
3. Mag-research ng industriya na hindi sakop sa mga case study at ilahad kung paano matutugunan ng MCP ang mga partikular nitong hamon.
4. Tuklasin ang isa sa mga hinaharap na direksyon at gumawa ng konsepto para sa bagong extension ng MCP upang suportahan ito.

Susunod: [Best Practices](../08-BestPractices/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat aming sinisikap ang pagiging tumpak, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.