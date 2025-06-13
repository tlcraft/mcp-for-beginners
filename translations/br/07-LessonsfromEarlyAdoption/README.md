<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:08:23+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "br"
}
-->
# Aroudennoù gant ar Gentañ Implijerien

## Kinnig

Ar c'henemglev-mañ a ginnig penaos ar gentañ implijerien en deus implijet ar Model Context Protocol (MCP) evit diskoulmañ traoù en un doare gwirion ha ma lakaat ar c'hiz-se da sevel nevezentiñ e meur a vugalezh. Dre studioù case resis ha raktresoù da vat, e welit penaos MCP a ro an tu da enporzhiañ un doare stank, sur ha lieskement evit enkorniñ AI—kenlabourat modeloù yezh bras, ostilhoù, ha roadennoù embregerezh e-barzh ur frammoù unanet. E profitz a zegas plijadur e sevel ha krouiñ diskoulmoù diazezet war MCP, deskiñ eus patromoù implijout sur ha kavout ar reizhder evit lakaat MCP e pleustr e lec'hioù produiñ. Ar c'henemglev a zispleg ivez ar raktresoù nevez, ar reizhiadoù da zont, ha raktresoù digor-skrid evit ma chomit war-raok er bed teknologiezh MCP hag e he c'hroazenn o vont war-raok.

## Palioù deskiñ

- Analiserezh eus implijadennoù MCP e gwir vuhez e meur a vugalezh
- Sevel ha krouiñ arloadoù komplek diazezet war MCP
- Dizoloiñ reizhiadoù nevez ha raktresoù da zont en teknologiezh MCP
- Implijout ar reizhderioù gwell e reolennoù gwirion da vat

## Implijadennoù MCP e gwir vuhez

### Stud case 1 : Avielhadeg Kargerezh Armerzh Embregerezh

Ur gevredigezh bedel en deus lakaet e pleustr ur diskoulm MCP da gemer e kont ar c'hemmou AI e-barzh o sistemoù skoazell d'ar c'hustomerien. Ar pezh a roas dezho da:

- Krouiñ ur reizhiad unanet evit meur a roadoù LLM
- Dalc'her ur mennozh stank war al lañs prompts e meur a adalek
- Implijout kontroloù sur ha padus evit ar surentez ha compliance
- Dont a-benn da cheñch aes etre modeloù AI disheñvel hervez ezhommoù resis

**Implijout teknikel :**  
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

**Disoc'hoù :** 30% disoc'h er c'hostezh modeloù, 45% gwellañ en unaniezh ar respontoù, ha padusoc'h compliance e meur a c'hontroloù bedel.

### Stud case 2 : Sikour Diagnostik Yec'hed

Ur servijer yec'hed en deus krouet ur stummadur MCP evit enkorniñ meur a model AI medisinel spesializet ha suraat e chom ar roadennoù kuzhet gant evezhiadennoù kalonek :

- Cheñch hep distruj eus modeloù medisinel hollek ha spesializet
- Kontroloù padus war an tu kuzhet ha skriturioù audit
- Enkorniñ gant ar sistemoù EHR (Electronic Health Record) kentañ
- Ezhomm eus prompt engineering konsist war ar gerioù medisinel

**Implijout teknikel :**  
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

**Disoc'hoù :** Gwellañ ar c'hinnig diagnostikel evit ar medisinierien ha chom hep bezañ distro war ar reolennoù HIPAA, ha disoc'h bras er cheñch etre sistemoù.

### Stud case 3 : Anañskourez Risk Servijoù Finañs

Ur servijer finañs en deus lakaet MCP da gemer e kont o raktresoù anañs risk e meur a adalek :

- Krouiñ ur reizhiad unanet evit risk krediñ, klask fraud, ha risk investiñ
- Implijout kontroloù gwell war ar gweladennoù ha stummoù modeloù
- Suraat audit evit an holl argasoù AI
- Dalc'her ur furmad roadennoù konsist e meur a vugalezh

**Implijout teknikel :**  
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

**Disoc'hoù :** Gwellañ compliance, 40% buanoc'h e sevel modeloù, ha gwellañ an unaniezh anañs risk e meur a adalek.

### Stud case 4 : Microsoft Playwright MCP Server evit Avielhadeg Merdeer

Microsoft en deus krouet ar [Playwright MCP server](https://github.com/microsoft/playwright-mcp) evit ma vefe aes ha sur sevel avielhadeg merdeer dre Model Context Protocol. Ar diskoulm-mañ a ro tu d’agentennoù AI hag LLM da labourat gant merdeerioù web e un doare kontrollet, auditus, ha ledan – evit ober traoù evel testennoù web automatiset, dastumadeg roadennoù, ha raktresoù diouzh penn da benn.

- Diskouez a ra talvoudegezhioù avielhadeg merdeer (merdeerezh, leuniañ furmad, tapout skeudennoù, hag all) evel ostilhoù MCP
- Implijout kontroloù sur ha sandbox evit mirout diouzh oberioù direizh
- Ro ur roll audit resis evit an holl obererezhioù merdeer
- Skignet gant Azure OpenAI ha roadoù LLM all evit avielhadeg dre agentennoù

**Implijout teknikel :**  
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

**Disoc'hoù :**  
- Kavet e oa surentez evit avielhadeg merdeer programmataet evit agentennoù AI ha LLM  
- Disoc'hoù bras evit ar c'hinnig testennoù da vat ha gwellañ ar c'houvroù testennoù evit ar c'hinnigoù web  
- Ro ur frammoù diboell ha ledan evit enkorniñ ostilhoù merdeer e lec'hioù embregerezh  

**Tud all :**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### Stud case 5 : Azure MCP – Model Context Protocol evel Servij Embregerezh

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) zo implijadenn Microsoft evit MCP evel ur servij cloud embregerezh, sur, ha lieskement. Azure MCP a ro tu d’ar gevredigezhioù da lakaat e pleustr, merañ, ha krouiñ servijoù MCP gant Azure AI, roadennoù, ha servijoù surentez, evit lemel an arc’hant war an implij ha buanaat ar gweladenn AI.

- Hosting servij MCP leun a gemer perzh e kalz a ventiloù, mont war-raok, ha surentez
- Enkorniñ naturel gant Azure OpenAI, Azure AI Search, ha servijoù Azure all
- Adkavout ar gwirioù gant Microsoft Entra ID
- Kemer perzh evit ostilhoù personelaet, templadoù prompt, ha kevread roadennoù
- Compliance gant ar reolennoù surentez embregerezh ha reolennoù

**Implijout teknikel :**  
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

**Disoc'hoù :**  
- Disoc'h bras e-pad an diskoulm AI embregerezh dre ur servij MCP prest da implijout ha compliance  
- Simplaat an enkorniñ etre LLM, ostilhoù, ha roadennoù embregerezh  
- Gwellañ surentez, gweladennoù, ha efedusted operadelezh evit ar c’hargadoù MCP  

**Tud all :**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## Stud case 6 : NLWeb

MCP (Model Context Protocol) zo ur protokol nevez evit Chatbots hag alies AI da labourat gant ostilhoù. Pep implij NLWeb zo ivez ur servij MCP, hag en deus ur metodaenn kreñv, ask, evit goulenn ur goulenn e yezh naturel war ur lec’hienn web. Ar respont a gas a implij schema.org, ur yezh a vez implijet kalz evit deskrivañ roadennoù web. E gwirionez, MCP zo NLWeb evel ma vez HTTP evit HTML. NLWeb a gemer perzh da glokañ protokoloù, furmad schema.org, ha kod skeudennet evit ma vefe aes da lec’hioù krouiñ an arloadoù-se, evit ma vo talvoudus evit an dud dre ar spered kontañ hag evit ar c'hiz-se dre labour agent-en-agent naturel.

Emañ daou elfenn distinct e NLWeb.  
- Ur protokol, simpl evit kregiñ, evit keñveriañ gant ur lec’hienn e yezh naturel ha furmad a implij json ha schema.org evit ar respont. Sell ouzh an titouroù REST API evit muioc'h.  
- Implijout aes eus (1) o implijout al liammoù a vez graet dindan ur furmad listenn (produioù, resis, lec’hioù da welout, enklaskoù, hag all). Gant ur strollad widget UI, e c’hall an dud kinnig un arloañ kontañ evit o roadennoù. Sell ouzh an titouroù Life of a chat query evit muioc’h.  

**Tud all :**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### Stud case 7 : MCP evit Foundry – Enkorniñ Agentennoù Azure AI

Servijoù Azure AI Foundry MCP a zispleg penaos MCP a c’hall bezañ implijet evit mererezh ha kempenn agentennoù AI ha raktresoù e lec’hioù embregerezh. Dre enkorniñ MCP gant Azure AI Foundry, e c’hall ar gevredigezhioù stankaat ar c’hemmou etre agentennoù, implijout mererezh raktresoù Foundry, ha suraat implijadennoù lieskement ha sur. Ar mod-se a ro tu da sevel prototipioù buan, mont war-raok e kelaouiñ, ha kinnig enkorniñ aes gant servijoù Azure AI, o skoazellañ senarioù anavezet evel mererezh gouiziekaat ha barzhoniezh agentennoù. Ar c’hodourien a profi eus ur reizhiad unanet evit sevel, kas war-raok, ha kelaouiñ pipeline agentennoù, ha skipailhoù IT a c’hall gwellañ surentez, compliance, ha buanoc’h en o labour. Ar diskoulm-mañ a zo mat evit embregerezhioù a fell dezho buanaat an implij AI ha mirout o kontroll war ar raktresoù diazez gant agentennoù.

**Tud all :**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### Stud case 8 : Foundry MCP Playground – Amprouiñ ha Prototypañ

Foundry MCP Playground a ginnig ur lec’h prest da implij evit amprouiñ servijoù MCP ha enkorniñ Azure AI Foundry. Ar c’hodourien a c’hall buan sevel prototipioù, testenniñ, ha skoueriañ modeloù AI ha raktresoù agentennoù en implijant an Azure AI Foundry Catalog ha Labs. Ar playground a simplaat ar stummadur, a ro skeudennoù raktres, ha skoazellañ kevrinoù evit sevel, evit ma vefe aes dizoloiñ ar reizhderioù gwell ha senarioù nevez hep bezañ talvoudus. Kavet eo talvoudus evit skipailhoù a fell dezho gwirianañ soñjoù, rannañ amprouadennoù, ha buanaat ar c'hendivizoù hep ezhomm eus un arloañ pinvidik. Dre lakaat an dachenn da vat aes da implij, ar playground a skoazell da sevel nevezentiñ ha kemmoù gant ar gumuniezh MCP ha Azure AI Foundry.

**Tud all :**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

### Stud case 9 : Microsoft Docs MCP Server - Deskiñ ha Meurzhiañ

Microsoft Docs MCP Server a implij Model Context Protocol (MCP) evit kinnig d’ar c’hiz-se AI mont war an hent en amzer real d’an titouroù resis Microsoft. E gwirionez e ra enklask semantik war titouroù teknikel Microsoft resis.

**Tud all :**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)  

## Raktresoù da vat

### Raktres 1 : Sevel ur Servij MCP gant meur a road

**Pal :** Krouiñ ur servij MCP a c’hall reizhañ ar gouladoù da meur a road model AI hervez ezhommoù resis.

**Ezhommoù :**  
- Skoret e vo da skouer tri road model disheñvel (da skouer OpenAI, Anthropic, modeloù lec’hel)  
- Implijout ur mekanikoù reizhañ hervez ar metadonneoù goulennet  
- Krouiñ ur sistem kempenn evit merañ ar c’hredadoù roadoù  
- Ouzhpennañ caching evit gwellañ ar performans ha disoc’h  
- Sevel ur dashboard simpl evit kelaouiñ an implij  

**Kemmañ :**  
1. Sevel ar servij MCP diazez  
2. Implijout adapteroù roadoù evit pep servij model AI  
3. Krouiñ ar reizhiad hervez ar metadonneoù goulennet  
4. Ouzhpennañ caching evit gouladoù mouezh  
5. Sevel ar dashboard kelaouiñ  
6. Ober testennoù gant meur a c’hemm gouladoù  

**Technologiezhioù :** Python (.NET/Java/Python hervez ho karet), Redis evit caching, ha ur frammoù web simpl evit ar dashboard.

### Raktres 2 : Sistêm mererezh prompt embregerezh

**Pal :** Sevel ur sistem MCP evit merañ, kempenn, ha kas da benn templadoù prompt e-barzh ur gevredigezh.

**Ezhommoù :**  
- Krouiñ ur c’hontroladenn stank evit templadoù prompt  
- Implijout kempenn ha raktresoù kelennadurel evit derc'hel ar reizhder  
- Sevel ar galloudoù testennoù gant kemmoù skouer  
- Krouiñ kontroloù gwirioù war rolioù  
- Krouiñ ur API evit tapout ha kas da benn templadoù  

**Kemmañ :**  
1. Displegañ an arc’hwel evit staliañ templadoù  
2. Krouiñ API kreñv evit ober emdroadurioù CRUD  
3. Implijout ar sistem kempenn  
4. Sevel ar raktres kelennadurel  
5. Krouiñ ar sistem testennoù  
6. Sevel ur interfac’h web simpl evit mererezh  
7. Enkorniñ gant ur servij MCP  

**Technologiezhioù :** Ho keuz eus ar frammoù backend, diazezer SQL pe NoSQL, ha frammoù frontend evit ar mennozhioù mererezh.

### Raktres 3 : Platennad krouiñ roadennoù diazezet war MCP

**Pal :** Sevel ur platennad krouiñ roadennoù a implij MCP evit kinnig disoc’hoù stank e meur a furmad roadennoù.

**Ezhommoù :**  
- Skoret e vo meur a furmad roadennoù (postelloù blog, kevelerezh war ar rouedadoù sokial, testenn marketing)  
- Implijout generadur diazezet war templadoù gant tu da bersonalizañ  
- Krouiñ ur sistem adlenn ha kelaouiñ roadennoù  
- Heuliañ ar perzh roadennoù  
- Skoret e vo kempenn ha iteradur roadennoù  

**Kemmañ :**  
1. Sevel ar c’hreizenn MCP client  
2. Krouiñ templadoù evit meur a furmad roadennoù  
3. Sevel ar pipeline krouiñ roadennoù  
4. Implijout ar sistem adlenn  
5. Krouiñ ar sistem heuliañ metrik  
6. Krouiñ ur interfac’h implijer evit mererezh templadoù ha krouiñ roadennoù  

**Technologiezhioù :** Ho yezh programmañ a garit, ur frammoù web, ha diazezer roadennoù.

## Raktresoù da zont evit teknologiezh MCP

### Reizhiadoù nevez

1. **MCP multimodal**  
   - Ledaniañ MCP evit stankaat ar c’hemmou gant modeloù skeudennoù, sonerezh, ha video  
   - Sevel galloudoù reasoning dre modoù disheñvel  
   - Furmad prompt stank evit meur a mod

2. **Stummadur federel MCP**  
   - Rouedadoù MCP skedet evit rannañ ar c’huzulioù etre kevredigezhioù  
   - Protokoloù stank evit rannañ modeloù  
   - Teknikoù kevatal evit gwareziñ roadennoù kuzhet

3. **Marcheoù MCP**  
   - Kevredigezhioù evit rannañ ha monetizañ templadoù MCP ha plugins  
   - Prozesoù war an eztaol hag ar sertifiadur  
   - Enkorniñ gant marcheoù modeloù

4. **MCP evit Edge Computing**  
   - Adaptañ MCP evit an deviceoù nevesaet gant
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

## Exercícios

1. Analise um dos estudos de caso e proponha uma abordagem alternativa para a implementação.
2. Escolha uma das ideias de projeto e crie uma especificação técnica detalhada.
3. Pesquise um setor que não foi abordado nos estudos de caso e descreva como o MCP poderia solucionar seus desafios específicos.
4. Explore uma das direções futuras e crie um conceito para uma nova extensão MCP que a suporte.

Próximo: [Best Practices](../08-BestPractices/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.