<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T21:55:26+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "br"
}
-->
# Añs da Adopterezhioù Goude

## Kentañ Taol

Ar lezenn-mañ a sellet ouzh penaos an adopterezhioù kentañ o deus implijet ar Model Context Protocol (MCP) evit seveniñ problemoù gwirion ha kas ar c'helenn e pleustr er c'hiltoù. Dre stadioù resis hag obererezhioù pratik, e welit penaos MCP a ro ur frammoù unvan, sur ha lieskour evit an integradur AI — o stagañ modeloù yezh bras, ostilhoù, ha roadennoù embregerezh e-barzh un doare. E kasit da vezañ gouest da sevel ha dizhañ diskoulmoù war MCP, deskit eus patromoù stank implijout hag an doareoù gwellañ evit lakaat MCP e pleustr e produioù. Ar lezenn a zispleg ivez ar modoù nevez, an dazont, hag ar c'hinnigioù digor evit sikour ac'hanoc'h chom war-raok er bed MCP hag e hec'h evolu.

## Palioù ar Goulennoù

- Analis ar stummoù MCP implijet er vuhez gwir e meur a di
- Dizhañ ha sevel arventennoù klok war MCP
- Merkañ ha studiañ ar modoù nevez ha dazont ar teknoloji MCP
- Implijout ar reolennoù gwellañ e stummoù sevel gwirion

## Stummoù MCP er Vuhez Gwir

### Stumm 1 : Otoemglev Kinnig Gwerzh Kliantoù Embregerezh

Ur c'horporadeg bedeliet en deus lakaet e pleustr ur diskoulm war MCP evit unvaniekaat an darempredoù AI er servijoù skoazell d'ar c'hliantoù. Dre-se e oa bet aes dezho:

- Krouiñ ur skeudenn unvan evit meur a frammoù LLM
- Merkañ ar stummoù prompt e-keñver departamantoù
- Sevel kontroloù surentez ha kenderc'hel an talvoudegezhioù
- Gouzout cheñch etre modeloù AI disheñvel hervez ar c'houlzad

**Implij teknik:**  
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

**Disoc'hoù:** 30% nebeutaat ar c'hostez modeloù, 45% gwellañ e kresk ar respontoù, ha kresk e kenderc'hel an talvoudegezhioù war bed ar c'horporadeg.

### Stumm 2 : Sikour Dizoloiñ yec'hed

Ur provijer yec'hed a lakaet e pleustr ur strujerezh MCP evit stagañ meur a model AI medisin dreistordinal, o mirout an titouroù kuzhet eus ar paciented:

- Gouzout cheñch hep sikenniñ etre modeloù medisin hollek ha kenderc'hel
- Kontrolioù prevezded ha daolenn ar c'hinnigoù start
- Stagañ gant ar sistemoù EHR (Electronic Health Record) a-vremañ
- Merkañ ar stummoù prompt evit ar yezh medisin

**Implij teknik:**  
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

**Disoc'hoù:** Gwellañ ar c'hinnig d'ar medisin, kenderc'hel hollek an adheriñ da HIPAA, ha disoc'h bras e cheñch ar c'hemm etre sistemoù.

### Stumm 3 : Analis Risk er Servijoù Moneiz

Ur bank a implije MCP evit unvaniekaat o doareoù analyz risk er departamantoù disheñvel:

- Krouiñ ur skeudenn unvan evit modeloù risk krediñ, goulloù fraud, ha risk moneiz
- Sevel kontroloù start evit ar gounid hag ar stummoù modeloù
- Gwiriañ an holl c'hinnig AI
- Kenderc'hel ur furmad roadennoù stank e meur a sistemoù

**Implij teknik:**  
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

**Disoc'hoù:** Kresk e kenderc'hel an talvoudegezhioù, 40% buanoc'h evit lakaat modeloù e pleustr, ha gwellañ ar furmad risk e departamantoù.

### Stumm 4 : Microsoft Playwright MCP Server evit Otoemglev ar Porched

Microsoft en deus krouet [ar servijer Playwright MCP](https://github.com/microsoft/playwright-mcp) evit merañ ar porched web e doare sur ha unvan gant Model Context Protocol. Ar solutenn-mañ a ro d'agent AI ha LLM da ober gant ar porched web e doare meret, gouest da heuliañ ha kas war-raok traoù — evit testennoù web automatet, tapout roadennoù, ha reizhañ prosesoù komplek.

- Diskouez a ra galloudoù otoemglev ar porched (mont en-dro, leuniañ furmoù, tapout skeudennoù, hag all) evel ostilhoù MCP
- Sevel kontroloù start hag ur sandboks evit mirout an implijoù
- Kinnig daolenn daolenn audit evit an holl obererezhioù
- Stagañ gant Azure OpenAI hag ar re all evit automatisañ dre agentoù

**Implij teknik:**  
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

**Disoc'hoù:**  
- Otoemglev sur war ar porched evit agentoù AI ha LLM  
- Disoc'hoù bras war ar c'hoantoù testennoù ha gwellañ ar c'hemm  
- Frammoù dibar ha lieskour evit stagañ ostilhoù browser e lec'hioù embregerezh

**Kemmoù:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Stumm 5 : Azure MCP – Model Context Protocol evit an embregerezh evel servij

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) zo implijadenn embregerezh ha renablet eus Model Context Protocol gant Microsoft, savet evit kinnig servijoù MCP lieskour, sur ha kenderc'hel evel servij en arroud. Azure MCP a ro d'ar skipailhoù an tu da lakaat e pleustr, merañ, ha stagañ servijoù MCP gant servijoù Azure AI, roadennoù ha surentez, o diskenn al labour ha buanaat ar mont war-raok en AI.

- Hosting servijer MCP kempennet a-wechoù gant skalerezh, mererezh, ha surentez
- Stagañ orin gant Azure OpenAI, Azure AI Search, hag ar re all
- Kemmoù gwirioù embregerezh dre Microsoft Entra ID
- Stagañ ostilhoù a-boutin, templadoù prompt, ha kinnigourien roadennoù
- Kenderc'hel an talvoudegezhioù surentez ha renabl evit embregerezh

**Implij teknik:**  
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

**Disoc'hoù:**  
- Diskenn buanoc'h evit raktresoù AI embregerezh gant ur servijer MCP prest da implijout  
- Simplañ ar stummoù stagañ modeloù LLM, ostilhoù, ha roadennoù embregerezh  
- Kresk surentez, gweladenniñ, ha efedusted labour evit ar c'hargoù MCP

**Kemmoù:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Stumm 6 : NLWeb  
MCP (Model Context Protocol) zo ur protokol o tont er-maez evit ar chatbot ha sikourerien AI evit ober gant ostilhoù. Pep implijer NLWeb zo ivez ur servijer MCP, hag e kaver un doare kreñv, ask, da c'houlenn ur goulenn en yezh naturel war ur lec'hienn. Ar respont kaset en-dro a implije schema.org, ur yezh a vez implijet kalz evit deskrivañ roadennoù web. A-benn ar fin, MCP a zo NLWeb evel ma vez Http evit HTML. NLWeb a staga protokoloù, furmad schema.org, ha kod sampl evit sikour an tiadoù da grouiñ an dra-se buan, o reiñ plijadur d'an dud dre an interfezoù komz ha d'ar roboted dre darempredoù natur.

Div elfenn disheñvel zo er NLWeb:  
- Ur protokol simpl evit kregiñ, evit kevreañ gant ur lec'hienn en yezh naturel ha furmad, o implijout json ha schema.org evit ar respont. Sellit ouzh an teulioù REST API evit muioc'h a ditouroù.  
- Implij simpl eus (1) o implijout ar marc'hadenn a-vremañ, evit lec'hioù a c'heller diskouez evel rolloù (produioù, resis, lec'hioù da welout, kemmoù, hag all). E-giz-se, gant ostilhoù UI, e c'hell an tiadoù kinnig interfezoù komz evit o roadennoù. Sellit ouzh an teulioù Life of a chat query evit gouzout penaos e vez graet-se.

**Kemmoù:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## Obererezhioù Praktikel

### Obererezh 1 : Sevel ur servijer MCP evit meur a frammoù

**Pal:** Krouiñ ur servijer MCP a c'hell kas ar gouladoù da meur a frammoù model AI hervez meizad resis.

**Reolennoù:**  
- Stagañ gant tri frammoù modeloù disheñvel (da skouer OpenAI, Anthropic, modeloù lec'hel)  
- Implijout ur mod routañ hervez an titouroù er goulenn  
- Krouiñ ur sistem kempenn evit mererezh ar c'hrededennioù  
- Ouzhpennañ cacherezh evit gwellañ ar produiñ ha disoc'hoù  
- Sevel ur postel sklaer evit mererezh ar c'hempennadennoù

**Dizoloadur:**  
1. Krouiñ ar servijer MCP diazezet  
2. Implijout adaptoù provijer evit pep servij model AI  
3. Sevel al leurenn routañ hervez an titouroù goulennet  
4. Ouzhpennañ mekanikoù cacherezh evit ar gouladoù ampart  
5. Krouiñ ar postel mererezh  
6. Gwiriañ gant meur a stumm goulenn

**Technologiezhioù:** Python (pe .NET/Java), Redis evit cacherezh, ha ur frammoù web simpl evit ar postel.

### Obererezh 2 : Sistem Mererezh Prompt Embregerezh

**Pal:** Sevel ur sistem war MCP evit mererezh, stummañ, ha lakaat e pleustr templadoù prompt e-barzh ur skipailh.

**Reolennoù:**  
- Krouiñ ur c'hentelad kentañ evit templadoù prompt  
- Implijout stummañ ha raktresoù goulenn digas  
- Sevel ar galloudoù testañ gant samploù  
- Staliañ kontroloù gwirioù hervez rolioù  
- Krouiñ ur API evit kavout ha lakaat e pleustr templadoù

**Dizoloadur:**  
1. Dizhañ ar skeudenn roadennoù evit ar stummad  
2. Krouiñ ar API kreñv evit obererezhioù CRUD  
3. Implijout ar sistem stummañ  
4. Sevel ar raktresoù goulenn digas  
5. Krouiñ ar frammoù testañ  
6. Krouiñ ur web simpl evit mererezh  
7. Stagañ gant servijer MCP

**Technologiezhioù:** Diwallit ar frammoù backend, diazezer roadennoù SQL pe NoSQL, ha frammoù frontend evit ar mererezh.

### Obererezh 3 : Pladenn Genadurel Kontennoù war MCP

**Pal:** Sevel ur pladenn da genadurel kontennoù o implijout MCP evit kinnig disoc'hoù stabil war meur a stumm kontennoù.

**Reolennoù:**  
- Stagañ meur a furmad kontennoù (postoù blog, media sokial, skridoù marc'had)  
- Implijout generadur war templadoù gant goulennoù personelaet  
- Krouiñ ur sistem enklask ha respont d'ar kontennoù  
- Heuliañ ar perzhioù kontennoù  
- Stagañ stummañ ha dreuzkas kontennoù

**Dizoloadur:**  
1. Diazezañ an MCP client  
2. Krouiñ templadoù evit meur a stumm kontennoù  
3. Sevel ar pipeline generadur  
4. Implijout ar sistem enklask  
5. Krouiñ ar sistem heuliañ metrikoù  
6. Krouiñ ur interfez implijer evit mererezh templadoù ha generadur

**Technologiezhioù:** Ho yezh programmadur hag ur frammoù web ha diazezer roadennoù.

## Dazont ar Teknologie MCP

### Modoù Nevez

1. **MCP Multi-Modad**  
   - Kresk ar MCP evit urzhiataoù skeudenn, son, ha video  
   - Krouiñ galloudoù resonnañ er modadoù disheñvel  
   - Furmad prompt unvan evit modadoù disheñvel

2. **Strujerezh MCP Fedet**  
   - Rouedad MCP distroet evit stagañ roadennoù etre skipailhoù  
   - Protokoloù unvan evit mererezh modeloù sur  
   - Teknikoù prevezded evit ar c'hemennoù

3. **MCP Marchoù**  
   - Eveloù evit rannañ ha monetizañ templadoù ha plugeinoù MCP  
   - Gwiriañ kalite ha sertifikañ  
   - Stagañ gant marchoù modeloù

4. **MCP evit Edge Computing**  
   - Adaptañ MCP evit an dispozitivoù serret gant arc'hant  
   - Protokoloù optimet evit lec'hioù niverus  
   - Implijioù MCP spesial evit IoT

5. **Kembrañ Regulel**  
   - Krouiñ estajoù MCP evit kenderc'hel an talvoudegezhioù regulel  
   - Daolenn audit unvan ha skeudennoù displeg  
   - Stagañ gant ar freuzioù mererezh AI

### Diskoulmoù MCP gant Microsoft

Microsoft ha Azure o deus krouet meur a c'hinnigioù digor evit sikour ar c'hodourien da implijout MCP e meur a stumm:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Servijer MCP evit Playwright evit otoemglev ha testennoù browser  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Implijadenn servijer MCP OneDrive evit testennoù lec'hel ha kemmoù kevredigezhel  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Un toullad protokoloù digor ha ostilhoù evit kreñvaat ar bed AI Web

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) - Samploù, ostilhoù, ha kinnigioù evit sevel ha stagañ servijoù MCP war Azure e meur a yezh  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Servijoù MCP evit ar mererezh gwirioù hervez ar spesifikadur Model Context Protocol  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Pajenn da lakaat e pleustr servijoù MCP war Azure Functions  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Templet start evit sevel ha lakaat e pleustr servijoù MCP war Azure Functions gant Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Templet start evit .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Templet start evit TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management evel porzh AI evit servijoù MCP gant Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Experimentoù APIM ❤️ AI, o stagañ Azure OpenAI ha AI Foundry

Ar re-mañ a ginnig meur a implijadenn, templetennoù, ha kinnigioù evit ober gant Model Context Protocol e meur a yezh hag er servijoù Azure. Gant implijadenn eus servijoù diazezet betek gwirioù ha stummoù embregerezh.

#### Dielladur Kinnigioù MCP

Ar [dielladur MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) e lec'h micherel MCP Microsoft a ginnig un toullad samploù, templadoù prompt, ha deskrivadurioù ostilhoù evit ar servijoù MCP. An dielladur-mañ a sikouro ar c'hodourien da kregiñ buan gant MCP dre an elfennoù dibar ha patromoù gwellañ evit:

- **Templadoù Prompt:** Templadoù prest da implij evit doareoù AI boutin, a c'hell bezañ adimplijet evit ho servijoù MCP.  
- **Deskrivadurioù Ostilhoù:** Skemadoù ha metadonneoù sampl evit unvaniekaat ar stummoù ostilhoù war MCP.  
- **Samploù Roadennoù:** Deskrivadurioù sampl evit stagañ gant data, APIoù, ha servijoù all e-barzh MCP.  
- **Implijadenn Referens:**
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Exercícios

1. Analise um dos estudos de caso e proponha uma abordagem alternativa de implementação.
2. Escolha uma das ideias de projeto e crie uma especificação técnica detalhada.
3. Pesquise um setor que não foi abordado nos estudos de caso e descreva como o MCP poderia resolver seus desafios específicos.
4. Explore uma das direções futuras e crie um conceito para uma nova extensão do MCP que a suporte.

Próximo: [Best Practices](../08-BestPractices/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.