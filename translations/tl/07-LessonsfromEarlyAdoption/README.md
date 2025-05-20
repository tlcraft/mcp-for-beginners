<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T17:49:09+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "tl"
}
-->
# Mga Aral mula sa mga Maagang Gumamit

## Pangkalahatang-ideya

Tinutuklas ng araling ito kung paano ginamit ng mga maagang gumagamit ang Model Context Protocol (MCP) upang lutasin ang mga totoong hamon at pasiglahin ang inobasyon sa iba't ibang industriya. Sa pamamagitan ng mga detalyadong pag-aaral ng kaso at mga praktikal na proyekto, makikita mo kung paano pinapagana ng MCP ang standardisadong, ligtas, at nasusukat na integrasyon ng AI—na nag-uugnay sa malalaking language model, mga tool, at datos ng negosyo sa isang pinag-isang balangkas. Makakakuha ka ng praktikal na karanasan sa pagdidisenyo at paggawa ng mga solusyong nakabase sa MCP, matututo mula sa mga napatunayang pattern ng implementasyon, at matutuklasan ang mga pinakamahuhusay na gawi sa pag-deploy ng MCP sa mga production environment. Binibigyang-diin din ng aralin ang mga umuusbong na trend, mga direksyon sa hinaharap, at mga open-source na mapagkukunan upang matulungan kang manatiling nangunguna sa teknolohiya ng MCP at ang patuloy nitong pag-unlad.

## Mga Layunin sa Pagkatuto

- Suriin ang mga totoong implementasyon ng MCP sa iba't ibang industriya  
- Magdisenyo at bumuo ng kumpletong aplikasyon na nakabase sa MCP  
- Tuklasin ang mga umuusbong na trend at mga direksyon sa hinaharap sa teknolohiya ng MCP  
- Ipatupad ang mga pinakamahuhusay na gawi sa aktwal na mga senaryo ng pag-unlad  

## Mga Totoong Implementasyon ng MCP

### Pag-aaral ng Kaso 1: Enterprise Customer Support Automation

Isang multinasyunal na korporasyon ang nagpatupad ng solusyong nakabase sa MCP upang gawing standard ang AI interactions sa kanilang mga customer support system. Pinayagan sila nitong:

- Gumawa ng pinag-isang interface para sa maraming LLM provider  
- Panatilihin ang pare-parehong pamamahala ng prompt sa iba't ibang departamento  
- Magpatupad ng matibay na seguridad at kontrol sa pagsunod  
- Madaling makalipat-lipat sa iba't ibang AI model ayon sa partikular na pangangailangan  

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

**Mga Resulta:** 30% bawas sa gastos ng modelo, 45% pagbuti sa consistency ng tugon, at pinahusay na pagsunod sa buong operasyon ng mundo.

### Pag-aaral ng Kaso 2: Healthcare Diagnostic Assistant

Isang healthcare provider ang gumawa ng MCP infrastructure upang pagsamahin ang maraming espesyal na medikal na AI model habang tinitiyak na protektado ang sensitibong datos ng pasyente:

- Walang patid na paglilipat sa pagitan ng generalist at specialist na medikal na modelo  
- Mahigpit na kontrol sa privacy at audit trails  
- Integrasyon sa umiiral na Electronic Health Record (EHR) system  
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

**Mga Resulta:** Pinabuting mga suhestiyon sa diagnosis para sa mga doktor habang nananatiling ganap na sumusunod sa HIPAA at malaking bawas sa paglipat-lipat ng konteksto sa pagitan ng mga sistema.

### Pag-aaral ng Kaso 3: Financial Services Risk Analysis

Isang institusyong pinansyal ang nagpatupad ng MCP upang gawing standard ang kanilang mga proseso sa risk analysis sa iba't ibang departamento:

- Nilikha ang isang pinag-isang interface para sa credit risk, fraud detection, at investment risk models  
- Nagpatupad ng mahigpit na access control at versioning ng modelo  
- Tiniyak ang auditability ng lahat ng rekomendasyon ng AI  
- Pinanatili ang consistent na data formatting sa magkakaibang sistema  

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

**Mga Resulta:** Pinahusay na pagsunod sa regulasyon, 40% mas mabilis na deployment cycle ng modelo, at pinabuting consistency sa risk assessment sa buong departamento.

### Pag-aaral ng Kaso 4: Microsoft Playwright MCP Server para sa Browser Automation

Binuo ng Microsoft ang [Playwright MCP server](https://github.com/microsoft/playwright-mcp) upang payagan ang secure at standardized na browser automation gamit ang Model Context Protocol. Pinapayagan ng solusyong ito ang AI agents at LLMs na makipag-ugnayan sa mga web browser sa isang kontrolado, auditable, at extensible na paraan—nagbibigay-daan sa mga use case tulad ng automated web testing, data extraction, at end-to-end workflows.

- Inilalantad ang mga kakayahan sa browser automation (navigation, pag-fill ng form, pagkuha ng screenshot, atbp.) bilang MCP tools  
- Nagpapatupad ng mahigpit na access control at sandboxing para maiwasan ang hindi awtorisadong aksyon  
- Nagbibigay ng detalyadong audit logs para sa lahat ng interaksyon sa browser  
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
- Pinagana ang secure at programmatic na browser automation para sa AI agents at LLMs  
- Nabawasan ang manu-manong pagsubok at napabuti ang test coverage para sa mga web application  
- Nagbigay ng reusable at extensible na framework para sa browser-based tool integration sa enterprise environment  

**Mga Sanggunian:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### Pag-aaral ng Kaso 5: Azure MCP – Enterprise-Grade Model Context Protocol bilang Serbisyo

Ang Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ay ang managed, enterprise-grade na implementasyon ng Microsoft ng Model Context Protocol, na idinisenyo upang magbigay ng scalable, secure, at compliant na MCP server capabilities bilang isang cloud service. Pinapayagan ng Azure MCP ang mga organisasyon na mabilis na mag-deploy, mag-manage, at mag-integrate ng MCP server sa Azure AI, data, at security services, na nagpapababa ng operational overhead at nagpapabilis ng AI adoption.

- Fully managed na MCP server hosting na may built-in scaling, monitoring, at security  
- Native na integrasyon sa Azure OpenAI, Azure AI Search, at iba pang Azure services  
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
- Pinababa ang time-to-value para sa enterprise AI projects sa pamamagitan ng paghahatid ng ready-to-use, compliant MCP server platform  
- Pinadali ang integrasyon ng LLMs, tools, at enterprise data sources  
- Pinahusay ang seguridad, observability, at operational efficiency para sa MCP workloads  

**Mga Sanggunian:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## Pag-aaral ng Kaso 6: NLWeb

Ang MCP (Model Context Protocol) ay isang umuusbong na protocol para sa mga Chatbot at AI assistant upang makipag-ugnayan sa mga tool. Bawat instance ng NLWeb ay isang MCP server din, na sumusuporta sa isang pangunahing pamamaraan, ang ask, na ginagamit upang magtanong sa isang website gamit ang natural na wika. Ang ibinalik na sagot ay gumagamit ng schema.org, isang malawakang ginagamit na bokabularyo para ilarawan ang web data. Sa madaling salita, ang MCP ay parang NLWeb gaya ng Http sa HTML. Pinagsasama ng NLWeb ang mga protocol, schema.org na format, at mga sample code upang matulungan ang mga site na mabilis na makalikha ng mga endpoint na ito, na kapaki-pakinabang para sa mga tao sa pamamagitan ng conversational interfaces at para sa mga makina sa pamamagitan ng natural na agent-to-agent interaction.

May dalawang pangunahing bahagi ang NLWeb:  
- Isang protocol, na napakasimple sa simula, para makipag-interface sa isang site gamit ang natural na wika at isang format na gumagamit ng json at schema.org para sa sagot. Tingnan ang dokumentasyon sa REST API para sa karagdagang detalye.  
- Isang diretso na implementasyon ng (1) na gumagamit ng umiiral na markup, para sa mga site na maaaring i-abstract bilang listahan ng mga item (produkto, recipe, atraksyon, review, atbp.). Kasama ang mga user interface widget, madali para sa mga site na magbigay ng conversational interface sa kanilang nilalaman. Tingnan ang dokumentasyon sa Life of a chat query para sa karagdagang detalye kung paano ito gumagana.  

**Mga Sanggunian:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### Pag-aaral ng Kaso 7: MCP para sa Foundry – Pagsasama ng Azure AI Agents

Ipinapakita ng Azure AI Foundry MCP servers kung paano magagamit ang MCP upang i-orchestrate at pamahalaan ang AI agents at workflows sa enterprise environment. Sa pamamagitan ng pagsasama ng MCP sa Azure AI Foundry, maaaring gawing standard ang mga agent interaction, gamitin ang workflow management ng Foundry, at tiyakin ang secure at scalable na deployment. Pinapahintulutan nito ang mabilis na prototyping, matibay na monitoring, at seamless na integrasyon sa Azure AI services, na sumusuporta sa mga advanced na senaryo tulad ng knowledge management at agent evaluation. Nakikinabang ang mga developer sa isang pinag-isang interface para sa paggawa, pag-deploy, at pag-monitor ng mga agent pipeline, habang nakakakuha ang IT teams ng pinahusay na seguridad, pagsunod, at operational efficiency. Ang solusyon ay perpekto para sa mga enterprise na nais pabilisin ang AI adoption at panatilihin ang kontrol sa mga komplikadong proseso na pinapagana ng mga agent.

**Mga Sanggunian:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### Pag-aaral ng Kaso 8: Foundry MCP Playground – Eksperimentasyon at Prototyping

Nagbibigay ang Foundry MCP Playground ng isang ready-to-use na kapaligiran para sa pag-eksperimento sa MCP servers at Azure AI Foundry integrations. Maaaring mabilis na mag-prototype, mag-test, at mag-evaluate ng mga AI model at agent workflow ang mga developer gamit ang mga resources mula sa Azure AI Foundry Catalog at Labs. Pinapadali ng playground ang setup, nagbibigay ng mga sample na proyekto, at sumusuporta sa kolaboratibong pag-develop, kaya madaling tuklasin ang mga pinakamahuhusay na gawi at mga bagong senaryo na may minimal na abala. Partikular itong kapaki-pakinabang para sa mga team na nais patunayan ang mga ideya, magbahagi ng eksperimento, at pabilisin ang pagkatuto nang hindi nangangailangan ng kumplikadong imprastraktura. Sa pamamagitan ng pagpapababa ng hadlang sa pagsisimula, tinutulungan ng playground na pasiglahin ang inobasyon at kontribusyon ng komunidad sa MCP at Azure AI Foundry ecosystem.

**Mga Sanggunian:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

## Mga Praktikal na Proyekto

### Proyekto 1: Gumawa ng Multi-Provider MCP Server

**Layunin:** Lumikha ng MCP server na maaaring mag-route ng mga request sa iba't ibang AI model provider base sa partikular na mga criteria.

**Mga Kinakailangan:**  
- Suportahan ang hindi bababa sa tatlong magkakaibang provider ng modelo (hal., OpenAI, Anthropic, lokal na mga modelo)  
- Magpatupad ng routing mechanism base sa metadata ng request  
- Gumawa ng configuration system para sa pamamahala ng credentials ng provider  
- Magdagdag ng caching para sa pag-optimize ng performance at gastos  
- Bumuo ng simpleng dashboard para sa pag-monitor ng paggamit  

**Mga Hakbang sa Implementasyon:**  
1. I-set up ang basic MCP server infrastructure  
2. Ipatupad ang provider adapters para sa bawat AI model service  
3. Gumawa ng routing logic base sa mga attribute ng request  
4. Magdagdag ng caching mechanism para sa madalas na request  
5. Bumuo ng monitoring dashboard  
6. Subukan gamit ang iba't ibang pattern ng request  

**Mga Teknolohiya:** Pumili mula sa Python (.NET/Java/Python ayon sa iyong gusto), Redis para sa caching, at isang simpleng web framework para sa dashboard.

### Proyekto 2: Enterprise Prompt Management System

**Layunin:** Bumuo ng MCP-based na sistema para sa pamamahala, versioning, at pag-deploy ng mga prompt template sa buong organisasyon.

**Mga Kinakailangan:**  
- Gumawa ng sentralisadong repository para sa mga prompt template  
- Ipatupad ang versioning at approval workflow  
- Bumuo ng kakayahan sa pag-test ng template gamit ang sample inputs  
- Mag-develop ng role-based access control  
- Gumawa ng API para sa retrieval at deployment ng template  

**Mga Hakbang sa Implementasyon:**  
1. Disenyo ng database schema para sa storage ng template  
2. Gumawa ng core API para sa CRUD operations ng template  
3. Ipatupad ang versioning system  
4. Bumuo ng approval workflow  
5. Mag-develop ng testing framework  
6. Gumawa ng simpleng web interface para sa pamamahala  
7. I-integrate sa MCP server  

**Mga Teknolohiya:** Piliin ang backend framework, SQL o NoSQL database, at frontend framework para sa management interface ayon sa gusto mo.

### Proyekto 3: MCP-Based Content Generation Platform

**Layunin:** Bumuo ng content generation platform na gumagamit ng MCP para magbigay ng consistent na resulta sa iba't ibang uri ng nilalaman.

**Mga Kinakailangan:**  
- Suportahan ang maraming content format (blog posts, social media, marketing copy)  
- Ipatupad ang template-based generation na may customization options  
- Gumawa ng content review at feedback system  
- Subaybayan ang performance metrics ng content  
- Suportahan ang content versioning at iteration  

**Mga Hakbang sa Implementasyon:**  
1. I-set up ang MCP client infrastructure  
2. Gumawa ng mga template para sa iba't ibang content type  
3. Bumuo ng content generation pipeline  
4. Ipatupad ang review system  
5. Mag-develop ng metrics tracking system  
6. Gumawa ng user interface para sa template management at content generation  

**Mga Teknolohiya:** Piliin ang paborito mong programming language, web framework, at database system.

## Mga Hinaharap na Direksyon para sa Teknolohiya ng MCP

### Mga Umuusbong na Trend

1. **Multi-Modal MCP**  
   - Pagpapalawak ng MCP para gawing standard ang interaksyon sa mga image, audio, at video model  
   - Pag-develop ng cross-modal reasoning capabilities  
   - Standardisadong prompt format para sa iba't ibang modality  

2. **Federated MCP Infrastructure**  
   - Distributed MCP network na maaaring magbahagi ng resources sa pagitan ng mga organisasyon  
   - Standardisadong protocol para sa secure na pagbabahagi ng modelo  
   - Mga teknik para sa privacy-preserving computation  

3. **MCP Marketplaces**  
   - Ecosystem para sa pagbabahagi at monetization ng MCP templates at plugins  
   - Proseso ng quality assurance at certification  
   - Integrasyon sa mga model marketplace  

4. **MCP para sa Edge Computing**  
   - Adaptasyon ng MCP standards para sa mga resource-constrained na edge device  
   - Optimized na protocol para sa low-bandwidth na environment  
   - Espesyal na implementasyon ng MCP para sa IoT ecosystem  

5. **Regulatory Frameworks**  
   - Pag-develop ng MCP extension para sa regulatory compliance  
   - Standardisadong audit trails at explainability interface  
   - Integrasyon sa mga umuusbong na AI governance framework  

### Mga Solusyon ng MCP mula sa Microsoft

Nag-develop ang Microsoft at Azure ng ilang open-source repository upang tulungan ang mga developer na mag-implementa ng MCP sa iba't ibang senaryo:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP server para sa browser automation at testing  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP server implementation para sa local testing at community contribution  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Koleksyon ng open protocols at kaugnay na open source tools, nakatuon sa foundational layer para sa AI Web  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) - Mga sample, tools, at resources para sa pagbuo at integrasyon ng MCP server sa Azure gamit ang iba't ibang wika  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Reference MCP servers na nagpapakita ng authentication gamit ang kasalukuyang Model Context Protocol specification  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Landing page para sa Remote MCP Server implementations sa Azure Functions na may mga link sa mga language-specific na repo  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Quickstart template para sa paggawa at pag-deploy ng custom remote MCP server gamit ang Azure Functions at Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Quickstart template para sa paggawa at pag-deploy ng custom remote MCP server gamit ang Azure Functions at .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Quickstart template para sa paggawa at pag-deploy ng custom remote MCP server gamit ang Azure Functions at TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management bilang AI Gateway sa Remote MCP server gamit ang Python  
8. [AI-Gateway](https://github
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
3. Mag-research ng industriya na hindi sakop sa mga case study at ilahad kung paano matutugunan ng MCP ang mga partikular na hamon nito.
4. Tuklasin ang isa sa mga hinaharap na direksyon at gumawa ng konsepto para sa bagong MCP extension upang suportahan ito.

Susunod: [Best Practices](../08-BestPractices/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang likas na wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaintindihan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.