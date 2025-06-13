<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:29:35+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tl"
}
-->
# Mga Aral mula sa mga Maagang Gumamit

## Pangkalahatang-ideya

Tinutuklas ng araling ito kung paano ginamit ng mga maagang gumamit ang Model Context Protocol (MCP) upang lutasin ang mga totoong suliranin at pasiglahin ang inobasyon sa iba't ibang industriya. Sa pamamagitan ng detalyadong mga case study at mga praktikal na proyekto, makikita mo kung paano pinapagana ng MCP ang standardisadong, ligtas, at scalable na integrasyon ng AI—pinag-uugnay ang malalaking language model, mga tool, at datos ng negosyo sa isang pinag-isang balangkas. Magkakaroon ka ng praktikal na karanasan sa pagdisenyo at paggawa ng mga solusyong batay sa MCP, matututo mula sa mga subok na pattern ng implementasyon, at matutuklasan ang mga pinakamahusay na gawain para sa pag-deploy ng MCP sa mga production na kapaligiran. Binibigyang-diin din ng aralin ang mga umuusbong na trend, mga hinaharap na direksyon, at mga open-source na mapagkukunan upang matulungan kang manatiling nangunguna sa teknolohiya ng MCP at sa patuloy nitong pag-unlad na ecosystem.

## Mga Layunin sa Pagkatuto

- Suriin ang mga totoong implementasyon ng MCP sa iba't ibang industriya  
- Magdisenyo at bumuo ng kumpletong mga aplikasyon batay sa MCP  
- Tuklasin ang mga umuusbong na trend at mga hinaharap na direksyon sa teknolohiya ng MCP  
- Ipatupad ang mga pinakamahusay na gawain sa aktwal na mga sitwasyon sa pag-develop  

## Mga Totoong Implementasyon ng MCP

### Case Study 1: Automasyon ng Enterprise Customer Support

Isang multinasyonal na korporasyon ang nagpatupad ng solusyong batay sa MCP upang i-standardize ang AI interactions sa kanilang mga sistema ng customer support. Pinayagan nito silang:

- Lumikha ng pinag-isang interface para sa maraming LLM providers  
- Panatilihin ang pare-parehong pamamahala ng prompt sa iba't ibang departamento  
- Magpatupad ng matibay na seguridad at mga kontrol sa pagsunod  
- Madaling lumipat sa pagitan ng iba't ibang AI models base sa partikular na pangangailangan  

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

**Mga Resulta:** 30% bawas sa gastos ng modelo, 45% pagbuti sa konsistensi ng tugon, at pinahusay na pagsunod sa mga pandaigdigang operasyon.

### Case Study 2: Healthcare Diagnostic Assistant

Isang healthcare provider ang bumuo ng MCP infrastructure upang pagsamahin ang maraming espesyal na medikal na AI models habang sinisigurong protektado ang sensitibong datos ng pasyente:

- Walang patid na paglipat sa pagitan ng generalist at specialist na medikal na mga modelo  
- Mahigpit na mga kontrol sa privacy at audit trails  
- Integrasyon sa umiiral na Electronic Health Record (EHR) systems  
- Konsistenteng prompt engineering para sa terminolohiyang medikal  

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

**Mga Resulta:** Pinahusay na mga suhestiyon sa diagnosis para sa mga doktor habang nananatiling ganap na sumusunod sa HIPAA at malaking pagbawas sa context-switching sa pagitan ng mga sistema.

### Case Study 3: Pagsusuri ng Panganib sa Serbisyong Pinansyal

Isang institusyong pinansyal ang nagpatupad ng MCP upang i-standardize ang kanilang mga proseso ng pagsusuri ng panganib sa iba't ibang departamento:

- Lumikha ng pinag-isang interface para sa credit risk, fraud detection, at investment risk models  
- Nagpatupad ng mahigpit na access controls at model versioning  
- Sinigurado ang auditability ng lahat ng AI recommendations  
- Pinanatili ang pare-parehong data formatting sa magkakaibang sistema  

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

**Mga Resulta:** Pinahusay na pagsunod sa regulasyon, 40% mas mabilis na mga cycle ng deployment ng modelo, at pinabuting konsistensi ng pagsusuri ng panganib sa mga departamento.

### Case Study 4: Microsoft Playwright MCP Server para sa Browser Automation

Binuo ng Microsoft ang [Playwright MCP server](https://github.com/microsoft/playwright-mcp) upang paganahin ang ligtas at standardisadong browser automation gamit ang Model Context Protocol. Pinapayagan ng solusyong ito ang AI agents at LLMs na makipag-ugnayan sa mga web browser sa isang kontrolado, auditable, at extensible na paraan—na sumusuporta sa mga kaso tulad ng automated web testing, data extraction, at end-to-end workflows.

- Ipinapakita ang mga kakayahan ng browser automation (navigation, pag-fill ng form, pagkuha ng screenshot, atbp.) bilang MCP tools  
- Nagpapatupad ng mahigpit na access controls at sandboxing para pigilan ang hindi awtorisadong mga aksyon  
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
- Bawasan ang manual testing effort at pagbutihin ang test coverage para sa web applications  
- Nag-alok ng reusable at extensible na balangkas para sa integrasyon ng mga browser-based na tool sa mga enterprise environment  

**Mga Sanggunian:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Case Study 5: Azure MCP – Enterprise-Grade Model Context Protocol bilang Serbisyo

Ang Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ay ang managed, enterprise-grade na implementasyon ng Microsoft ng Model Context Protocol, na dinisenyo upang magbigay ng scalable, secure, at compliant na MCP server capabilities bilang isang cloud service. Pinapahintulutan ng Azure MCP ang mga organisasyon na mabilis na mag-deploy, mag-manage, at mag-integrate ng MCP servers kasama ang Azure AI, data, at security services, na nagpapababa ng operational overhead at nagpapabilis ng AI adoption.

- Ganap na managed MCP server hosting na may built-in scaling, monitoring, at security  
- Native integration sa Azure OpenAI, Azure AI Search, at iba pang Azure services  
- Enterprise authentication at authorization gamit ang Microsoft Entra ID  
- Suporta para sa custom tools, prompt templates, at resource connectors  
- Pagsunod sa enterprise security at regulatory requirements  

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
- Pinababa ang time-to-value para sa mga enterprise AI projects sa pamamagitan ng pagbibigay ng ready-to-use, compliant MCP server platform  
- Pinadali ang integrasyon ng LLMs, tools, at enterprise data sources  
- Pinahusay ang seguridad, observability, at operational efficiency para sa mga MCP workloads  

**Mga Sanggunian:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Case Study 6: NLWeb  
Ang MCP (Model Context Protocol) ay isang umuusbong na protocol para sa Chatbots at AI assistants upang makipag-ugnayan sa mga tool. Bawat NLWeb instance ay isang MCP server din, na sumusuporta sa isang pangunahing metodo, ang ask, na ginagamit upang magtanong sa isang website gamit ang natural na wika. Ang tugon ay gumagamit ng schema.org, isang malawakang gamit na bokabularyo para sa paglalarawan ng web data. Sa madaling salita, ang MCP ay parang NLWeb tulad ng Http ay sa HTML. Pinagsasama ng NLWeb ang mga protocol, Schema.org formats, at sample code upang matulungan ang mga site na mabilis na makalikha ng mga endpoints na ito, na nakikinabang sa parehong mga tao sa pamamagitan ng conversational interfaces at mga makina sa pamamagitan ng natural na agent-to-agent na interaksyon.

May dalawang natatanging bahagi ang NLWeb:  
- Isang protocol, napakasimple sa simula, upang makipag-interface sa isang site gamit ang natural na wika at isang format, gamit ang json at schema.org para sa ibinalik na sagot. Tingnan ang dokumentasyon sa REST API para sa karagdagang detalye.  
- Isang diretso na implementasyon ng (1) na gumagamit ng umiiral na markup, para sa mga site na maaaring i-abstract bilang mga listahan ng mga item (produkto, resipe, atraksyon, review, atbp.). Kasama ng isang set ng mga user interface widgets, madaling makapagbigay ang mga site ng conversational interfaces para sa kanilang nilalaman. Tingnan ang dokumentasyon sa Life of a chat query para sa karagdagang detalye kung paano ito gumagana.

**Mga Sanggunian:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Case Study 7: MCP para sa Foundry – Integrasyon ng Azure AI Agents

Ipinapakita ng Azure AI Foundry MCP servers kung paano magagamit ang MCP upang i-orchestrate at pamahalaan ang mga AI agents at workflows sa mga enterprise environment. Sa pamamagitan ng integrasyon ng MCP sa Azure AI Foundry, maaaring i-standardize ng mga organisasyon ang agent interactions, gamitin ang workflow management ng Foundry, at tiyakin ang ligtas at scalable na deployment. Pinapadali ng paraang ito ang mabilisang prototyping, matibay na monitoring, at seamless na integrasyon sa Azure AI services, sumusuporta sa mga advanced na scenario tulad ng knowledge management at agent evaluation. Nakikinabang ang mga developer mula sa pinag-isang interface para sa pagbuo, pag-deploy, at pag-monitor ng agent pipelines, habang nakakamit ng IT teams ang pinahusay na seguridad, pagsunod, at operational efficiency. Ang solusyon ay perpekto para sa mga enterprise na nais pabilisin ang AI adoption at mapanatili ang kontrol sa mga kumplikadong proseso na pinapagana ng mga agent.

**Mga Sanggunian:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Case Study 8: Foundry MCP Playground – Eksperimento at Prototyping

Nagbibigay ang Foundry MCP Playground ng handang gamitin na kapaligiran para sa eksperimento sa MCP servers at integrasyon ng Azure AI Foundry. Mabilis na makakapag-prototype, makakapagsubok, at makakapag-evaluate ang mga developer ng AI models at agent workflows gamit ang mga resources mula sa Azure AI Foundry Catalog at Labs. Pinapadali ng playground ang setup, nagbibigay ng mga sample project, at sumusuporta sa kolaboratibong pag-develop, kaya madaling tuklasin ang mga pinakamahusay na gawain at bagong scenario na may minimal na overhead. Lalo itong kapaki-pakinabang para sa mga team na gustong patunayan ang mga ideya, magbahagi ng mga eksperimento, at pabilisin ang pagkatuto nang hindi kailangan ng komplikadong imprastraktura. Sa pamamagitan ng pagpapababa ng hadlang sa pagsisimula, tinutulungan ng playground na paunlarin ang inobasyon at mga kontribusyon ng komunidad sa MCP at Azure AI Foundry ecosystem.

**Mga Sanggunian:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Case Study 9: Microsoft Docs MCP Server - Pagkatuto at Pagsasanay

Ang Microsoft Docs MCP Server ay nagpapatupad ng Model Context Protocol (MCP) server na nagbibigay sa mga AI assistant ng real-time na access sa opisyal na dokumentasyon ng Microsoft. Nagsasagawa ng semantic search laban sa opisyal na teknikal na dokumentasyon ng Microsoft.

**Mga Sanggunian:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Mga Praktikal na Proyekto

### Proyekto 1: Gumawa ng Multi-Provider MCP Server

**Layunin:** Lumikha ng MCP server na kayang mag-route ng mga request sa iba't ibang AI model providers base sa partikular na mga pamantayan.

**Mga Kinakailangan:**  
- Suportahan ang hindi bababa sa tatlong magkakaibang model providers (hal. OpenAI, Anthropic, lokal na mga modelo)  
- Magpatupad ng routing mechanism base sa metadata ng request  
- Gumawa ng configuration system para sa pamamahala ng mga kredensyal ng provider  
- Magdagdag ng caching para mapabuti ang performance at bawasan ang gastos  
- Bumuo ng simpleng dashboard para sa pag-monitor ng paggamit  

**Mga Hakbang sa Implementasyon:**  
1. I-set up ang basic na MCP server infrastructure  
2. Ipatupad ang provider adapters para sa bawat AI model service  
3. Gumawa ng routing logic base sa mga attribute ng request  
4. Magdagdag ng caching mechanisms para sa madalas na request  
5. Bumuo ng monitoring dashboard  
6. Subukan gamit ang iba't ibang pattern ng request  

**Mga Teknolohiya:** Pumili mula sa Python (.NET/Java/Python ayon sa iyong gusto), Redis para sa caching, at isang simpleng web framework para sa dashboard.

### Proyekto 2: Enterprise Prompt Management System

**Layunin:** Bumuo ng MCP-based system para sa pamamahala, versioning, at pag-deploy ng mga prompt template sa buong organisasyon.

**Mga Kinakailangan:**  
- Lumikha ng sentralisadong repository para sa mga prompt template  
- Magpatupad ng versioning at approval workflows  
- Bumuo ng kakayahan sa pag-test ng mga template gamit ang sample inputs  
- Mag-develop ng role-based access controls  
- Gumawa ng API para sa pagkuha at pag-deploy ng mga template  

**Mga Hakbang sa Implementasyon:**  
1. Disenyuhin ang database schema para sa pag-iimbak ng template  
2. Gumawa ng core API para sa CRUD operations ng template  
3. Ipatupad ang versioning system  
4. Bumuo ng approval workflow  
5. I-develop ang testing framework  
6. Gumawa ng simpleng web interface para sa pamamahala  
7. I-integrate sa isang MCP server  

**Mga Teknolohiya:** Piliin ang backend framework, SQL o NoSQL database, at frontend framework para sa management interface.

### Proyekto 3: MCP-Based Content Generation Platform

**Layunin:** Bumuo ng content generation platform na gumagamit ng MCP upang magbigay ng pare-parehong resulta sa iba't ibang uri ng content.

**Mga Kinakailangan:**  
- Suportahan ang maraming content format (blog posts, social media, marketing copy)  
- Magpatupad ng template-based generation na may customization options  
- Gumawa ng content review at feedback system  
- Subaybayan ang mga metrics ng performance ng content  
- Suportahan ang content versioning at iteration  

**Mga Hakbang sa Implementasyon:**  
1. I-set up ang MCP client infrastructure  
2. Gumawa ng mga template para sa iba't ibang content type  
3. Bumuo ng content generation pipeline  
4. Ipatupad ang review system  
5. I-develop ang metrics tracking system  
6. Gumawa ng user interface para sa template management at content generation  

**Mga Teknolohiya:** Ang iyong paboritong programming language, web framework, at database system.

## Mga Hinaharap na Direksyon para sa Teknolohiya ng MCP

### Mga Umuusbong na Trend

1. **Multi-Modal MCP**  
   - Pagpapalawak ng MCP upang i-standardize ang interaksyon sa mga image, audio, at video models  
   - Pag-develop ng cross-modal reasoning capabilities  
   - Standardisadong prompt formats para sa iba't ibang modality  

2. **Federated MCP Infrastructure**  
   - Distributed MCP networks na maaaring magbahagi ng resources sa pagitan ng mga organisasyon  
   - Standardisadong mga protocol para sa secure na pagbabahagi ng mga modelo  
   - Mga teknik para sa privacy-preserving computation  

3. **MCP Marketplaces**  
   - Ecosystems para sa pagbabahagi at monetization ng MCP templates at plugins  
   - Mga proseso para sa quality assurance at certification  
   - Integrasyon sa mga model marketplaces  

4. **MCP para sa Edge Computing**  
   - Pag-aangkop ng MCP standards para sa mga resource-constrained edge devices  
   - Optimized na mga protocol para sa low-bandwidth na mga kapaligiran  
   - Espesyal na mga implementasyon ng MCP para sa IoT ecosystems  

5. **Regulatory Frameworks**  
   - Pag-develop ng MCP extensions para sa pagsunod sa regulasyon  
   - Standardisadong audit trails at explainability interfaces  
   - Integrasyon sa mga umuusbong na AI governance frameworks  

### Mga Solusyon ng MCP mula sa Microsoft

Nag-develop ang Microsoft at Azure ng ilang open-source repositories upang tulungan ang mga developer na magpatupad ng MCP sa iba't ibang scenario:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP server para sa browser automation at testing  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP server implementation para sa lokal na testing at community contribution  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Koleksyon ng open protocols at kaugnay na open source tools, na nakatuon sa pagtatatag ng foundational layer para sa AI Web  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) - Mga link sa mga sample, tool, at resources para sa paggawa at integrasyon ng MCP servers sa Azure gamit ang iba't ibang lengguwahe  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Reference MCP servers na nagpapakita ng authentication gamit ang kasalukuyang Model Context Protocol specification  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Landing page para sa Remote MCP Server implementations sa Azure Functions na may mga link sa mga language-specific repos  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Quickstart template para sa paggawa at pag-deploy ng custom remote MCP servers gamit ang Azure Functions at Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples
- [MCP Community & Documentation](https://modelcontextprotocol.io/introduction)
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
3. Mag-research ng isang industriya na hindi sakop sa mga case study at ilarawan kung paano matutugunan ng MCP ang mga partikular na hamon nito.
4. Tuklasin ang isa sa mga hinaharap na direksyon at gumawa ng konsepto para sa bagong extension ng MCP upang suportahan ito.

Susunod: [Best Practices](../08-BestPractices/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong salin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng salin na ito.