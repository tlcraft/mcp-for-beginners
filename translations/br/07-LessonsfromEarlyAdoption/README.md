<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T21:16:51+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "br"
}
-->
# Dersioù gant ar Reizh-Eñvorennoù Kentañ

## Kementad

Ar c'hentañ ders-mañ a dizolo penaos ar reizh-eñvorennoù kentañ en deus implijet ar Model Context Protocol (MCP) evit diskoulmañ kudennoù gwirion ha kas ar c'hemm e meur a diaraezh. Dre studiadennoù resis ha raktresoù yalc'hadus, e welit penaos MCP a laka da sevel un emglev-stur, sur ha lieskempenn evit kevreañ ar modêloù yezh bras, ar c'hizellerien ha roadennoù embregerezh en ur c'hadenn unvan. Gouzout a rez penaos krouiñ ha sevel diskoulmoù diazezet war MCP, deskiñ eus patromoù en implijadur gwiriekaet, ha kavout ar modoù gwellañ da lakaat MCP e produiñ. Ar c'hentañ ders a zispleg ivez an trendoù o tont, an hentadoù da heul, hag an danvez digor evit sikour ac'hanoc'h chom e penn-kentañ teknologiezh MCP hag e ekosistem o tremen.

## Palioù ar C'hoant deskiñ

- Anañliziñ implijadurioù MCP gwirion e meur a diaraezh
- Krouiñ ha sevel arventennoù hollek diazezet war MCP
- Dizoloiñ trendoù nevez ha hentadoù da heul e teknologiezh MCP
- Implijout ar modoù gwellañ e stummoù gwirioù

## Implijadurioù MCP Gwirion

### Studiañ Evezhiañ 1 : Otoamatizadur Gwezhadur Kliant Embregerezh

Ur c'horporerezh bras etrebroadel en deus lakaet en plas ur diskoulm diazezet war MCP evit stardañ ar c'hemmerezh AI e-barzh o systemoù skoazell d'ar c'hliant. Se a roas dezho da:

- Krouiñ ur meziant unvan evit meur a roñser LLM
- Dalc'hañ ur mererezh promptoù peurbad e-keñver ar rannvroioù
- Implijout kevreier surentez ha kemmoù
- Ober aes ar c'hemmoù etre modêloù AI disheñvel hervez ezhommoù resis

**Implijadur teknikel :**  
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

**Disoc'hoù :** 30% nebeutaat er gwiroù modêl, 45% gwellaat e kevrener ar respontoù, ha surentez kenkoulz ha kreñv e-barzh an obererezh bedel.

### Studiañ Evezhiañ 2 : Sikour Diagnostek Yec'hed

Ur servijer yec'hed en deus sevel ur stummad MCP evit kevreañ meur a modêl AI medisinel spesializet o suraat miret daveoù kuzhet eus ar pazient:

- Kemm aes etre modêloù medisinel hollek ha spesializet
- Kontroloù prevezded kreñv ha trailoù auditoù
- Kevreañ gant ar sistemoù Elektronikel Rekord Yec'hed (EHR) a-vremañ
- Mererezh promptoù kevrus evit termenologiezh medisinel

**Implijadur teknikel :**  
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

**Disoc'hoù :** Gwellaat an diskoulmoù diagnostek evit an dremmweladennoù o klask mont en-dro hep kollet compliance HIPAA ha nebeutaat kalz ar c'hemmoù kontekst etre ar sistemoù.

### Studiañ Evezhiañ 3 : Analis Risk Gervelerezh

Ur servijer gervelerezh en deus lakaet MCP en-dro evit stardañ o modoù analis risk e meur a rannvro:

- Krouiñ ur meziant unvan evit modêloù risk kred, distaolerezh ha risk investisement
- Implijout kontroloù aes da ziskar ha versonoù modêl
- Surentez audit evit an holl argemmoù AI
- Dalc'h ar c'hemmoù roadennoù e meur a sistem disheñvel

**Implijadur teknikel :**  
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

**Disoc'hoù :** Kreñvaat compliance reoliek, 40% buanoc'h e mizioù lakaat modêlioù e plas, ha gwellaat kevreder an analis risk e meur a rannvro.

### Studiañ Evezhiañ 4 : Microsoft Playwright MCP Server evit Otoamatizadur Brwzher

Microsoft en deus sevel [Playwright MCP server](https://github.com/microsoft/playwright-mcp) evit degas ur servij browser automation sur, stardet ha standardizet dre Model Context Protocol. Diskoulm-mañ a ro d'agentennoù AI ha LLM da gemer perzh e browserioù web e mod kontrolliet, audit ha lieskempennet—hag a ro tu da ober traoù evel testennoù web otoamatet, distaolañ roadennoù ha labourioù di-barzh an endro.

- Diskouez a ra tu da otoamatizadur browser (mont war-raok, leuniañ furmoù, kemer skeudennoù, hag all) evel amzalc'h MCP
- Implij kontroloù kreñv ha sandbox evit pellaat obererezhioù divedi
- Kinnig logoù audit resis evit an holl obererezhioù browser
- Stur enporzhiañ gant Azure OpenAI ha roñserien LLM all evit otoamatizadur dre agentennoù

**Implijadur teknikel :**  
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
- Degaset ur servij browser automation sur ha programat evit agentennoù AI ha LLM  
- Nevezeet an enklask testoù manuel ha gwellaat diabarzh an testennoù evit ar raktresoù web  
- Kinniget ur c'hemennad nevez ha lieskempennet evit enporzhiañ amzalc'hioù browser e diaraezhoù bras

**Kementadioù :**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Studiañ Evezhiañ 5 : Azure MCP – Model Context Protocol evit Embregerezhioù evel Servij

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) zo implijadenn Microsoft evit Model Context Protocol a-vicher, karget a servijoù MCP sur, lieskempennet ha kemmet evel servij e gloued. Azure MCP a ro tu d'ar strolladoù lakaat e plas, merañ ha kevreañ servijoù MCP gant servijoù Azure AI, roadennoù ha surentez, o lakaat an aferoù da vont aesoc'h ha mont war-raok ar implij AI.

- Hosting servijer MCP bet meret ken pell, gant skalerezh, mererezh ha surentez enno
- Kevreañ naturel gant Azure OpenAI, Azure AI Search ha servijoù Azure all
- Adkavet anavezet ha goulennet dre Microsoft Entra ID
- Gwareziñ amzalc'hioù, templetennoù prompt ha kornadoù roadennoù personelaet
- Compliance gant surentez embregerezh ha reolennoù

**Implijadur teknikel :**  
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
- Nevezeet an amzer da gaout sikour evit raktresoù AI embregerezh dre ur platform MCP prest da implijout  
- Simpliceet an enklask da kevreañ LLM, amzalc'hioù ha micherioù roadennoù  
- Gwellaat surentez, gwelet ha efedusted operasional evit labourioù MCP

**Kementadioù :**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Studiañ Evezhiañ 6 : NLWeb  
MCP (Model Context Protocol) zo ur protokol nevez evit ar chatbotioù hag alies AI da gemer perzh gant amzalc'hioù. Pep implij NLWeb zo ivez ur servijer MCP, a skoazell un doare pennañ, ask, evit gouzout traoù diwar ur lec'hienn e yezh naturel. Ar respont a vez goulennet a implij schema.org, ur yezh bras evit deskrivañ roadennoù web. E gwirionez, MCP a zo evel NLWeb evel ma'z eo Http evit HTML. NLWeb a kever protokoloù, furmoù schema.org ha kod skouer evit sikour lec'hiennoù da grouiñ an dornad-mañ, o reiñ tu da dud dre kevrinoù konversiñ ha da mignoned dre darempredoù agent-agent naturel.

Emañ NLWeb o deus daou elfenn disheñvel.  
- Ur protokol simpl evit kevreañ gant ur lec'hienn e yezh naturel ha furmad, o implij json ha schema.org evit ar respont. Gwelet an dokumentadur REST API evit muioc'h a ditouroù.  
- Ur implijadur aes a (1) o implij an dilennad kentelioù evit lec'hiennoù a c'hall bezañ diskarget evel rolloù traoù (produioù, resis, lec'hioù da welout, adlennadennoù, ha kement-se). Gant ur roll widgetoù, lec'hiennoù a c'hall aes kinnig kevrinoù konversiñ evit o roadennoù. Gwelet an dokumentadur Life of a chat query evit muioc'h a ditouroù diwar-benn ar mod-se.

**Kementadioù :**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Studiañ Evezhiañ 7 : MCP evit Foundry – Kevreañ Agentennoù Azure AI

Servijoù MCP Azure AI Foundry a laka da verkañ ha merañ agentennoù AI ha labourioù e diaraezhoù embregerezh. Dre kevreañ MCP gant Azure AI Foundry, ar strolladoù a c'hall stardañ an darempredoù etre agentennoù, implijout merañ labourioù Foundry ha suraat lakaadennoù sur ha lieskempennet. Ar steuñv-mañ a ro tu da bropotipañ buan, merañ kreñv ha kevreañ hep gwall live gant servijoù Azure AI, o skoazellañ senarioù uhel evel merañ anavezidigezh ha klaskad agentennoù. An diavaez a ro ur meziant unvan evit sevel, lakaat e plas ha merañ pipelineoù agentennoù, ha skipailhoù IT a gav surentez gwelloc'h, compliance ha efedusted obererezh. Diskoulm mat evit embregerezhioù o klask mont war-raok ar implij AI ha mirout ar sterederezh war raktresoù kevrener agentennoù.

**Kementadioù :**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Studiañ Evezhiañ 8 : Foundry MCP Playground – Amprouiñ ha Prototipañ

Foundry MCP Playground a ro ur steuñv prest da implij evit klaskañ servijoù MCP ha kevreañ gant Azure AI Foundry. An diavaez a ro tu d'ar c'hrouerien da bropotipañ, testenniñ ha klask an modêloù AI ha labourioù agent dre an danvez eus Azure AI Foundry Catalog ha Labs. Ar playground a aesaat ar staliañ, a ginnig raktresoù skouer ha skoazellañ an diorren en un doare kevredet, evit dizoloiñ ar modoù gwellañ ha senarioù nevez hep kalz a stumm. Gant an trec'h-se e skoazell ar skipailhoù da wiriañ o mennozhioù, rann an amprouadennoù ha buanaat ar c'hlaskadur hep ret bezañ gant ur stummad kreñv.

**Kementadioù :**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Raktresoù Yalc'hadus

### Raktres 1 : Sevel ur Servijer MCP Multi-Roñser

**Pal :** Krouiñ ur servijer MCP a c'hall rannañ ar gouladoù da meur a roñser modêl AI hervez ar c'henvreoù resis.

**Ezhommoù :**  
- Stur da benn tri roñser modêl disheñvel (da skouer OpenAI, Anthropic, modêloù lec'hel)  
- Implij ur mekanik rannañ hervez an titouroù goulennet  
- Krouiñ ur sistem kempenn evit merañ ar c'hevennoù roñserien  
- Ouzhpennañ ur system kach evit gwellaat ar perzhioù hag ar gwiroù  
- Sevel ur meziant obererezh evit mererezh ar implij

**Droad an implij :**  
1. Staliañ an enklask servijer MCP diazez  
2. Sevel amzalc'hiennoù roñser evit pep servij modêl AI  
3. Krouiñ an lojeiz rannañ hervez ar c'hodenn goulennet  
4. Ouzhpennañ mekanikoù kach evit ar gouladoù kenkoulz  
5. Sevel ar meziant obererezh  
6. Ober ar c'hinnig gant meur a stumm gouladoù

**Technologiezhioù :** Dibabit etre Python (.NET/Java/Python hervez ho karet), Redis evit kach, ha ur frammoù web simpl evit ar meziant obererezh.

### Raktres 2 : Sistem Mererezh Prompt Embregerezh

**Pal :** Sevel ur sistem diazezet war MCP evit merañ, versonañ ha lakaat en implij templetennoù prompt e-barzh ur strollad.

**Ezhommoù :**  
- Krouiñ ur c'hazenn kentañ evit templetennoù prompt  
- Implij versonañ ha treuzkas ar gefridi  
- Sevel tu da amprouiñ templeteoù gant enporzhioù skouer  
- Krouiñ kontroloù digoust dre rolloù  
- Krouiñ ur API evit kavout ha lakaat en implij templeteoù

**Droad an implij :**  
1. Deskiñ ar skeulenn roadennoù evit ar stor prompt  
2. Sevel API diazez evit obererezhioù CRUD war templeteoù  
3. Implij an doare versonañ  
4. Sevel ar gefrid treuzkas  
5. Krouiñ ar frammoù amprouiñ  
6. Sevel ur meziant web simpl evit merañ  
7. Kevreañ gant ur servijer MCP

**Technologiezhioù :** Dibabit ho frammoù backend, roadennoù SQL pe NoSQL, ha frammoù frontend evit an diavaez.

### Raktres 3 : Platform Krouiñ Kontennoù diazezet war MCP

**Pal :** Sevel ur platform evit krouiñ kontennoù a implij MCP evit ober disoc'hoù kevredet e meur a stumm kontennoù.

**Ezhommoù :**  
- Stur da benn meur a furmad kontennoù (postezoù bloaz, media sokial, kopioù marc'hadourezh)  
- Implij krouiñ diazezet war templeteoù gant tu da personnalizañ  
- Krouiñ ur sistem diskoulm ha respont kontennoù  
- Heuliañ metricoù perzhioù kontennoù  
- Stur versonañ ha kemmoù kontennoù

**Droad an implij :**  
1. Staliañ an enklask klijent MCP  
2. Krouiñ templeteoù evit meur a furmad kontennoù  
3. Sevel an hent krouiñ kontennoù  
4. Implij ar sistem diskoulm  
5. Krouiñ an hent heuliañ metricoù  
6. Sevel ur kevrinoù evit merañ templeteoù ha krouiñ kontennoù

**Technologiezhioù :** Ho yezh programañ a garit, frammoù web, ha sistem roadennoù.

## Hentadoù Da Heul evit Teknologiezh MCP

### Trendoù O Tont

1. **MCP Multi-Moded**  
   - Diabarzh MCP evit stardañ darempredoù gant modêloù skeudenn, son, ha video  
   - Krouiñ tu da ober reasoning dre modoù disheñvel  
   - Furmoù prompt standard evit modadoù disheñvel

2. **Stummad MCP Federet**  
   - Rouedadoù MCP distaol a c'hall rannañ danvez etre strolladoù  
   - Protokoloù standard evit rannañ modêloù sur  
   - Teknikoù kempouez evit prevezded

3. **MCP Marchadoù**  
   - Ekosistem evit rannañ ha monetizañ templeteoù ha pluginioù MCP  
   - Prozesoù gwiriek ha sertifikañ  
   - Kevreañ gant marchadoù modêloù

4. **MCP evit Edge Computing**  
   - Adaptañ MCP evit an dielloù e-barzh an disoc'hoù resis  
   - Protokoloù optimet evit lec'hioù gant bann-droad izel  
   - Implijadurioù MCP spesel evit IoT

5. **Fremoù Reoliek**  
   - Krouiñ estajoù MCP evit compliance reoliek  
   - Trailoù audit standard ha darempredoù deskrivadur  
   - Kevreañ gant frammoù renabl AI o tont

### Diskoulmoù MCP gant Microsoft

Microsoft ha Azure en
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
2. Escolha uma das ideias de projeto e elabore uma especificação técnica detalhada.
3. Pesquise um setor que não tenha sido abordado nos estudos de caso e descreva como o MCP poderia solucionar seus desafios específicos.
4. Explore uma das direções futuras e crie um conceito para uma nova extensão MCP que a suporte.

Próximo: [Best Practices](../08-BestPractices/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, por favor, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.