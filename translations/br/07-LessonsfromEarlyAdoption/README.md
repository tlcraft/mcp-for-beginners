<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-29T20:19:44+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "br"
}
-->
# Lesons di Adopteurs Daou

## Overvieu

Ar lezenn-mañ e studia penaos ar c’hentañ adopterien o deus implijet ar Model Context Protocol (MCP) evit displegañ traoù gwirion ha kas da benn arloadoù nevez e meur a brofesion. Dre studiadennoù resis ha raktresoù pratik e vo diskouezet penaos MCP a ro ur frammoù unanet, sur ha lieskour evit keñveriañ ar modeloù bras, ar benvezoù ha roadennoù embregerezh. Emañ ar lezenn da reiñ d’an implijerien an donedigezh da sevel hag aozañ diskoulmoù war MCP, da zeskiñ patromoù implijout en-dro, ha da ziskouez ar gwellañ pratikoù evit lakaat MCP e servij en endroioù produiñ. Ar lezenn a ginnig ivez treuzfurmadurioù nevez, hentadennoù da zont, ha servijoù digor evit ma vo an implijerien war an hent gant teknologiezh MCP hag e gevredigezh o tremen.

## Palioù deskiñ

- Analis ar gwir implijadennoù MCP e meur a brofesion
- Sevel ha deskiñ ar raktresoù klok war MCP
- Studia ar trendoù nevez ha hentadennoù da zont e teknologiezh MCP
- Implij ar gwellañ pratikoù e stummoù diabarzh gwirion

## Implijadennoù Gwirion MCP

### Studiadenn 1 : Aotrouniezh Embregerezh evit Awtonomi Kargañ Gwezh

Ur c’horporerezh liesbroadel en deus krouet ur diskoulm war MCP evit urzhiañ ar c’hinnig AI e servijoù kargañ gwezh. Dre-se e c’haller :

- Krouiñ ur stumm unanet evit meur a leverer LLM
- Merañ ar gemmlec’h promptoù e-keñver ar departamantoù
- Implijout ur sistem sur ha emzalc’hus
- Kemmout aes etre modeloù AI disheñvel hervez ar ezhommoù

**Implij teknikel :**  
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

**Disoc’hoù :** 30% bihanoc’h e kostez ar modeloù, 45% gwellaat e pep seurt respontoù, ha gwellaat ar c’hendalc’h en ur bed ledan.

### Studiadenn 2 : Sikour Da Digeriñ Diagnostikoù Yec’hedel

Ur servijer yec’hedel en deus sevel ur servij MCP evit kevreañ meur a model AI medisinel spesializet, gant an dalc’h sur a-benn m’emañ roadennoù eus an dud dizoloet :

- Kemmout hep spert etre modeloù medisinel hollek ha spesializet
- Merañ reolennoù prevezded ha trailoù audit
- Kevreañ gant ar servijoù Electronic Health Record (EHR) a vez implijet
- Urzhiañ promptoù evit termenologiezh medisinel

**Implij teknikel :**  
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

**Disoc’hoù :** Gwellaat ar c’hinnig diagnostikoù evit ar medisinierien gant dalc’h evit HIPAA, ha bihanoc’h e kemmoù etre ar servijoù.

### Studiadenn 3 : Merañ Riskloù e Servijoù Finansel

Ur servijer arc’hant en deus implijet MCP evit urzhiañ ar prosesoù merañ riskloù e meur a departamant :

- Krouiñ ur stumm unanet evit modeloù riskloù kred, goulennoù froud, ha riskloù investidigezh
- Implij reolennoù digor evit mont da-heul ha verzionoù ar modeloù
- Gwareziñ audit evit an holl c’hinnig AI
- Merañ urzh ar roadennoù e meur a sistemoù

**Implij teknikel :**  
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

**Disoc’hoù :** Gwellaat kendalc’h ar reolennoù, 40% buanoc’h e lakaat modeloù da vont en-dro, ha gwellaat ar mererezh riskloù e meur a departamant.

### Studiadenn 4 : Microsoft Playwright MCP Server evit Awtonomi Browser

Microsoft en deus krouet ar [Playwright MCP server](https://github.com/microsoft/playwright-mcp) evit kinnig awtonomi browser sur ha standardet dre Model Context Protocol. Ar diskoulm-mañ a ro d’agents AI ha LLM da gemer perzh e levrioù web e doare kontrollet, audit ha lieskour, evit ober traoù evel testennoù web awtomatek, tapout roadennoù, ha reizhañ ar c’hourioù evit bout en-dro.

- Diskouez a ra galloudoù awtonomi browser (kenlabour, leuniañ furmoù, tapout skeudennoù, hag all) evel ostilhoù MCP
- Implij reolennoù strizh ha sandbox evit mirout diogelder
- Kinnig logoù audit resis evit an holl labourioù browser
- Sokialaat gant Azure OpenAI ha levererien LLM all evit awtonomi da-heul agents

**Implij teknikel :**  
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

**Disoc’hoù :**  
- Kinnig awtonomi browser sur ha programat evit agents AI ha LLM  
- Lakaat ar c’houlennoù testennoù da vont muioc’h ha gwellaat ar c’houverture testennoù web  
- Kinnig ur frammoù adimplijet ha lieskour evit kevreañ ostilhoù browser e servijoù embregerezh  

**Tachennioù :**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Studiadenn 5 : Azure MCP – Model Context Protocol evel Servij Embregerezh

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) zo implijadur embregerezh Microsoft evit Model Context Protocol, krouet evit kinnig servijoù MCP sur, lieskour ha stag evel servij e kloued. Azure MCP a ro d’ar c’horporadoù an tu da lakaat en-dro ha merañ servijoù MCP gant Azure AI, roadennoù ha servijoù surentez, evit bihanaat ar c’hudennoù labour ha buanaat implij AI.

- Hosting servij MCP meret a-fet hollek gant scaladur, mererezh ha surentez
- Kevreañ naturel gant Azure OpenAI, Azure AI Search, ha servijoù Azure all
- Aotrenadur embregerezh dre Microsoft Entra ID
- Sikour evit ostilhoù kevreet, templadoù prompt, ha kevreañ anavezadurioù
- Dalc’h surentez embregerezh ha reolennoù

**Implij teknikel :**  
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

**Disoc’hoù :**  
- Bihanat amzer da implij raktresoù AI embregerezh dre ur servij MCP stag ha prest da implijout  
- Simplaat kevreañ modeloù LLM, ostilhoù, ha roadennoù embregerezh  
- Gwellaat surentez, gwelet e pleustr, ha efedusted labour evit MCP  

**Tachennioù :**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Studiadenn 6 : NLWeb  
MCP (Model Context Protocol) zo ur protokol nevez evit ober gant ostilhoù gant chatbot ha sikourerien AI. Pep implij NLWeb zo ivez ur servij MCP, a ginnig ur metod diazez, ask, evit goulenn goulennoù e yezh naturel war ur lec’hienn web. Ar respont a vez savet war-bouez schema.org, ur yezh gant kalz implij evit deskrivañ roadennoù web. E-giz-se, MCP zo evel NLWeb e-pad ma vez Http evit HTML. NLWeb a c’hall kevreañ protokoloù, formadoù schema.org, ha kod skouer evit sikour lec’hioù da sevel an endroù-se buan, evit ma vo aes d’an dud dre ar c’hinnig diazezet ha d’ar mignoned dre emdroadur agent-eke.

Div elfenn zo e NLWeb :  
- Ur protokol simpl evit ober gant ur lec’hienn e yezh naturel, ha ur furmad evit ar respont gant json ha schema.org. Sellit ouzh an dokumentadur REST API evit muioc’h a ditouroù.  
- Implij simpl eus (1) o implijout marc’hadenn a vez kavet a-raok, evit lec’hioù a c’hall bezañ diskoulmet evel rolloù a draoù (produioù, resis, lec’hioù da zistagañ, adlodoù...). Dre ur roll ostilhoù evit ar user interface, e c’hall ar lec’hioù kinnig interfeisioù kevrinus evit o roadennoù. Sellit ouzh an dokumentadur Life of a chat query evit kompren penaos e vez graet an traoù.

**Tachennioù :**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Studiadenn 7 : MCP evit Foundry – Kevreañ Azure AI Agents

Servijoù Azure AI Foundry MCP a diskouez penaos e c’haller implijout MCP evit urzhiañ ha merañ agents AI hag o labourioù e servijoù embregerezh. Dre kevreañ MCP gant Azure AI Foundry, e c’haller urzhiañ ar c’hoariadoù agent, implijout mererezh labourioù Foundry, ha mirout an implijoù sur ha lieskour. Ar se a ro tu da prototipiañ buan, mont da-heul kreñv, ha kevreañ hep emzalc’h gant servijoù Azure AI. An dielfennañ-se a sikouro an dielfennourien da sevel, lakaat en-dro, ha mont da-heul kourioù agents, ha ro da skipailhoù IT urzh ha compliance gwelloc’h. Ar diskoulm a zo talvoudus evit embregerezhioù a fell dezho buanaat implij AI ha merañ ar prosesoù komplex.

**Tachennioù :**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Studiadenn 8 : Foundry MCP Playground – Amprouiñ ha Prototipiñ

Ar Foundry MCP Playground a ginnig ur servij prest da implij evit amprouiñ servijoù MCP ha kevreañ gant Azure AI Foundry. An implijerien a c’hall buan prototipiañ, testenniñ, ha gwerzhañ modeloù AI ha labourioù agents gant an azasadennoù eus Azure AI Foundry Catalog ha Labs. Ar playground a simplia ar c’hrouidigezh, a ginnig raktresoù skouer, ha a sikouro ar c’henlabour evit mont war-raok hep ret bezañ surentez lies. Talvoudus evit skipailhoù a fell dezho gwiriekat ideoù, reiñ da c’houzout an disoc’hoù, ha buanaat an deskiñ hep implij eus ur stumm diazez. Dre bihanat an tizh da implij, ar playground a sikouro da grouiñ arloadoù nevez ha reiñ nerzh d’ar gevredigezh.

**Tachennioù :**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Raktresoù Praktikel

### Raktres 1 : Sevel ur Servij MCP Gant Mervelourioù Disheñvel

**Pal :** Krouiñ ur servij MCP a c’hall kas goulenn da meur a leverer model AI hervez ar c’hriterioù.

**Ezhommoù :**  
- Sikour tri leverer modeloù disheñvel (da skouer OpenAI, Anthropic, modeloù lec’hel)  
- Implij ur mekaniz routing hervez an titouroù goulennet  
- Krouiñ ur sistem konfignañ evit mererezh kredentialoù  
- Ouzhpenn caching evit optimiñ ar perzh ha kostez  
- Sevel ur dashboard simpl evit mont da-heul ar pleustr

**Diverrañ ar raktres :**  
1. Krouiñ an enklask diazez servij MCP  
2. Sevel adapteroù leverer evit pep servij model AI  
3. Krouiñ an logik routing hervez ar c’harterioù goulennet  
4. Ouzhpenn caching evit ar c’houlennou a zo kenkoulz  
5. Sevel ur dashboard evit mont da-heul ar pleustr  
6. Klask gant disheñvel patromoù goulenn

**Technologiezhioù :** Python (.NET/Java/Python hervez ho kinnig), Redis evit caching, ha ur frammoù web simpl evit ar dashboard.

### Raktres 2 : Sistem Mererezh Prompt Embregerezh

**Pal :** Sevel ur sistem war MCP evit merañ, verzionañ, ha lakaat en-dro templadoù prompt dre ur c’hontrol hollek.

**Ezhommoù :**  
- Krouiñ ur c’havlec’h kendiviz evit templadoù prompt  
- Implij verzionañ ha labourioù aotreet evit ar promptoù  
- Krouiñ tu testañ templadoù gant enbannoù skouer  
- Sevel reolennoù digor hervez rolloù  
- Krouiñ ur API evit adkavout ha lakaat en-dro templadoù

**Diverrañ ar raktres :**  
1. Deskiñ ar schem ma vez staget ar templadoù  
2. Krouiñ ar c’hore API evit CRUD templadoù  
3. Implij ar sistem verzionañ  
4. Sevel ar labourioù aotreet  
5. Krouiñ ur frammoù testañ  
6. Krouiñ ur interfeis web simpl evit merañ  
7. Kevreañ gant ur servij MCP

**Technologiezhioù :** Ho dibab evit ar frammoù backend, bazaennoù SQL pe NoSQL, ha frammoù frontend evit ar mererezh.

### Raktres 3 : Platfom Sevel Kontennoù war MCP

**Pal :** Sevel ur platfom evit sevel kontennoù a implij MCP evit gounid respontoù emsaver hervez meur a seurt kontennoù.

**Ezhommoù :**  
- Sikour meur a furmad kontennoù (postoù blog, media sokial, kinnig marc’had)  
- Implij generadur war-bouez templadoù gant tu da aozañ  
- Krouiñ ur sistem adkavout ha respont kontennoù  
- Mont da-heul ar perzh kontennoù  
- Sikour verzionañ ha adimplij kontennoù

**Diverrañ ar raktres :**  
1. Krouiñ an enklask MCP client  
2. Sevel templadoù evit seurt kontennoù disheñvel  
3. Krouiñ ar pipeline generadur kontennoù  
4. Implij ar sistem adkavout  
5. Krouiñ ar sistem mont da-heul metrikoù  
6. Krouiñ ur interfeis implijer evit merañ templadoù ha sevel kontennoù

**Technologiezhioù :** Ho yezh programmañ a garit, frammoù web, ha bazaennoù roadennoù.

## Hentadennoù da Zont evit Teknologiezh MCP

### Trendoù Nevez

1. **MCP Multi-Modal**  
   - Ledaniañ MCP evit urzhiañ ar c’hoariadoù gant modeloù skeudennoù, sonerezh, ha video  
   - Krouiñ galloudoù resisañ etre modadoù disheñvel  
   - Formadoù prompt standard evit modadoù disheñvel

2. **MCP Kevredigezh Federet**  
   - Resevelloù MCP distaol da rannañ arc’hant etre kevredigezhioù  
   - Protokoloù stag evit rannañ modeloù sur  
   - Teknikoù obererezh prevez

3. **Marchadoù MCP**  
   - Kevredigezhioù evit rannañ ha gwerzhañ templadoù MCP ha pluginioù  
   - Prosesoù kontrol kalitezh ha sertifikañsoù  
   - Kevreañ gant marc’hadoù modeloù

4. **MCP evit Edge Computing**  
   - Adkempenn MCP evit arventennoù gant kontroloù kenkoulz  
   - Protokoloù optimaet evit lec’hioù gant berzh internet bihan  
   - Implij MCP spesial evit IoT

5. **Stummoù Reolennañ**  
   - Krouiñ MCP evit kemer e kont ar reolennoù  
   - Trail audit ha interfeisioù displegañ standard  
   - Kevreañ gant frammoù renerezh AI nevez

### Diskoulmoù MCP gant Microsoft

Microsoft ha Azure en deus krouet meur a repo digor evit sikour an dielfennourien da implij MCP e meur a doare :

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Servij MCP Playwright evit awtonomi browser ha testennoù  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Implijadur servij MCP OneDrive evit testennoù lec’hel ha kevredigezh  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Ur c’havlec’h protokoloù digor ha ostilhoù digor, evit krouiñ ur bazenn evit Web AI  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) - Skouerioù, ost
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

1. Analise um dos estudos de caso e proponha uma abordagem alternativa de implementação.
2. Escolha uma das ideias de projeto e crie uma especificação técnica detalhada.
3. Pesquise um setor que não tenha sido abordado nos estudos de caso e descreva como o MCP poderia resolver seus desafios específicos.
4. Explore uma das direções futuras e crie um conceito para uma nova extensão MCP que a suporte.

Próximo: [Best Practices](../08-BestPractices/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.