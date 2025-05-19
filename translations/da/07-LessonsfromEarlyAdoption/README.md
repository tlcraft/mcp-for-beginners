<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T22:06:09+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "da"
}
-->
# Læringer fra tidlige brugere

## Oversigt

Denne lektion undersøger, hvordan tidlige brugere har udnyttet Model Context Protocol (MCP) til at løse virkelige udfordringer og drive innovation på tværs af brancher. Gennem detaljerede casestudier og praktiske projekter vil du se, hvordan MCP muliggør standardiseret, sikker og skalerbar AI-integration—der forbinder store sprogmodeller, værktøjer og virksomhedens data i en samlet ramme. Du får praktisk erfaring med at designe og bygge MCP-baserede løsninger, lærer af gennemprøvede implementeringsmønstre og opdager bedste praksis til at implementere MCP i produktionsmiljøer. Lektionen fremhæver også nye tendenser, fremtidige retninger og open source-ressourcer, der hjælper dig med at være på forkant med MCP-teknologien og dens udviklende økosystem.

## Læringsmål

- Analysere virkelige MCP-implementeringer på tværs af forskellige brancher  
- Designe og bygge komplette MCP-baserede applikationer  
- Udforske nye tendenser og fremtidige retninger inden for MCP-teknologi  
- Anvende bedste praksis i faktiske udviklingsscenarier  

## Virkelige MCP-implementeringer

### Casestudie 1: Automatisering af Enterprise Kundesupport

En multinational virksomhed implementerede en MCP-baseret løsning for at standardisere AI-interaktioner på tværs af deres kundesupportsystemer. Dette gjorde det muligt for dem at:

- Skabe et samlet interface for flere LLM-udbydere  
- Opretholde ensartet promptstyring på tværs af afdelinger  
- Implementere robuste sikkerheds- og compliance-kontroller  
- Let skifte mellem forskellige AI-modeller baseret på specifikke behov  

**Teknisk implementering:**  
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

**Resultater:** 30% reduktion i modelomkostninger, 45% forbedring i svartidens konsistens og styrket compliance på tværs af globale operationer.

### Casestudie 2: Diagnostisk Assistent i Sundhedssektoren

En sundhedsudbyder udviklede en MCP-infrastruktur til at integrere flere specialiserede medicinske AI-modeller, samtidig med at følsomme patientdata blev beskyttet:

- Problemfri skift mellem generalist- og specialistmedicinske modeller  
- Strenge privatlivskontroller og revisionsspor  
- Integration med eksisterende Electronic Health Record (EHR)-systemer  
- Ensartet promptudformning for medicinsk terminologi  

**Teknisk implementering:**  
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

**Resultater:** Forbedrede diagnostiske forslag til læger samtidig med fuld HIPAA-overholdelse og betydelig reduktion i kontekstskift mellem systemer.

### Casestudie 3: Risikostyring i Finansielle Tjenester

En finansiel institution implementerede MCP for at standardisere deres risikostyringsprocesser på tværs af forskellige afdelinger:

- Skabte et samlet interface for kreditrisiko, bedrageridetektion og investeringsrisikomodeller  
- Implementerede strenge adgangskontroller og modelversionering  
- Sikrede auditabilitet af alle AI-anbefalinger  
- Opretholdt ensartet dataformat på tværs af forskellige systemer  

**Teknisk implementering:**  
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

**Resultater:** Forbedret regulatorisk compliance, 40% hurtigere udrulningscyklusser for modeller og øget konsistens i risikovurdering på tværs af afdelinger.

### Casestudie 4: Microsoft Playwright MCP Server til Browserautomatisering

Microsoft udviklede [Playwright MCP server](https://github.com/microsoft/playwright-mcp) for at muliggøre sikker, standardiseret browserautomatisering via Model Context Protocol. Denne løsning giver AI-agenter og LLM’er mulighed for at interagere med webbrowsere på en kontrolleret, auditerbar og udvidelsesvenlig måde—hvilket muliggør brugsscenarier som automatiseret webtest, dataudtræk og end-to-end workflows.

- Eksponerer browserautomatiseringsfunktioner (navigation, formularudfyldning, screenshot-optagelse osv.) som MCP-værktøjer  
- Implementerer strenge adgangskontroller og sandboxing for at forhindre uautoriserede handlinger  
- Leverer detaljerede revisionslogfiler for alle browserinteraktioner  
- Understøtter integration med Azure OpenAI og andre LLM-udbydere til agentstyret automatisering  

**Teknisk implementering:**  
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

**Resultater:**  
- Muliggjorde sikker, programmerbar browserautomatisering for AI-agenter og LLM’er  
- Reducerede manuelt testarbejde og forbedrede testdækningen for webapplikationer  
- Leverede en genanvendelig, udvidelsesvenlig ramme til browserbaseret værktøjsintegration i virksomhedsmiljøer  

**Referencer:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### Casestudie 5: Azure MCP – Enterprise-klasse Model Context Protocol som en Service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) er Microsofts administrerede, enterprise-klasse implementering af Model Context Protocol, designet til at tilbyde skalerbare, sikre og compliant MCP-serverfunktioner som en cloud-service. Azure MCP gør det muligt for organisationer hurtigt at udrulle, administrere og integrere MCP-servere med Azure AI, data og sikkerhedstjenester, hvilket reducerer driftsomkostninger og fremskynder AI-adoption.

- Fuldt administreret MCP-serverhosting med indbygget skalering, overvågning og sikkerhed  
- Native integration med Azure OpenAI, Azure AI Search og andre Azure-tjenester  
- Enterprise-autentificering og autorisation via Microsoft Entra ID  
- Understøttelse af brugerdefinerede værktøjer, promptskabeloner og ressourceforbindelser  
- Overholdelse af enterprise sikkerheds- og regulatoriske krav  

**Teknisk implementering:**  
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

**Resultater:**  
- Forkortet time-to-value for enterprise AI-projekter ved at tilbyde en klar-til-brug, compliant MCP-serverplatform  
- Forenklet integration af LLM’er, værktøjer og virksomhedsdatakilder  
- Forbedret sikkerhed, observabilitet og driftseffektivitet for MCP-arbejdsbelastninger  

**Referencer:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## Casestudie 6: NLWeb  
MCP (Model Context Protocol) er et nyt protokol til chatbots og AI-assistenter til at interagere med værktøjer. Hver NLWeb-instans er også en MCP-server, som understøtter en kernefunktion, ask, der bruges til at stille et spørgsmål til et websted på naturligt sprog. Det returnerede svar benytter schema.org, et udbredt vokabularium til beskrivelse af webdata. Løst sagt er MCP for NLWeb, hvad Http er for HTML. NLWeb kombinerer protokoller, Schema.org-formater og eksempel-kode for at hjælpe websteder med hurtigt at skabe disse endpoints, hvilket gavner både mennesker via samtalegrænseflader og maskiner via naturlig agent-til-agent-interaktion.

Der er to distinkte komponenter i NLWeb.  
- En protokol, meget enkel at starte med, til at interagere med et websted på naturligt sprog og et format, der udnytter json og schema.org til det returnerede svar. Se dokumentationen om REST API for flere detaljer.  
- En ligetil implementering af (1), som udnytter eksisterende markup for websteder, der kan abstraheres som lister af elementer (produkter, opskrifter, attraktioner, anmeldelser osv.). Sammen med et sæt brugergrænsefladewidgets kan websteder nemt tilbyde samtalegrænseflader til deres indhold. Se dokumentationen om Life of a chat query for flere detaljer om, hvordan det fungerer.  

**Referencer:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

## Praktiske Projekter

### Projekt 1: Byg en Multi-Provider MCP Server

**Mål:** Opret en MCP-server, der kan rute forespørgsler til flere AI-modeludbydere baseret på specifikke kriterier.

**Krav:**  
- Understøt mindst tre forskellige modeludbydere (f.eks. OpenAI, Anthropic, lokale modeller)  
- Implementer en routingmekanisme baseret på metadata i forespørgsler  
- Opret et konfigurationssystem til håndtering af udbyderlegitimationsoplysninger  
- Tilføj caching for at optimere ydeevne og omkostninger  
- Byg et simpelt dashboard til overvågning af brug  

**Implementeringstrin:**  
1. Opsæt den grundlæggende MCP-serverinfrastruktur  
2. Implementer udbyderadaptere for hver AI-modeltjeneste  
3. Skab routinglogikken baseret på forespørgselsattributter  
4. Tilføj cachingmekanismer for hyppige forespørgsler  
5. Udvikl overvågningsdashboardet  
6. Test med forskellige forespørgselsmønstre  

**Teknologier:** Vælg mellem Python (.NET/Java/Python efter eget valg), Redis til caching og et simpelt webframework til dashboardet.

### Projekt 2: Enterprise Prompt Management System

**Mål:** Udvikl et MCP-baseret system til håndtering, versionering og udrulning af promptskabeloner på tværs af en organisation.

**Krav:**  
- Opret et centraliseret lager for promptskabeloner  
- Implementer versionering og godkendelsesarbejdsgange  
- Byg testfunktioner for skabeloner med prøveinput  
- Udvikl rollebaserede adgangskontroller  
- Opret en API til skabelonhentning og udrulning  

**Implementeringstrin:**  
1. Design databaseskemaet til lagring af skabeloner  
2. Opret kerne-API’en til CRUD-operationer på skabeloner  
3. Implementer versionsstyringssystemet  
4. Byg godkendelsesarbejdsgangen  
5. Udvikl testframeworket  
6. Opret en simpel webgrænseflade til administration  
7. Integrer med en MCP-server  

**Teknologier:** Valgfrit backend-framework, SQL eller NoSQL database og et frontend-framework til administrationsgrænsefladen.

### Projekt 3: MCP-baseret Platform til Indholdsgenerering

**Mål:** Byg en platform til indholdsgenerering, der udnytter MCP til at levere konsistente resultater på tværs af forskellige indholdstyper.

**Krav:**  
- Understøt flere indholdsformater (blogindlæg, sociale medier, marketingtekst)  
- Implementer skabelonbaseret generering med tilpasningsmuligheder  
- Opret et system til indholdsrevision og feedback  
- Spor indholdsperformance-målinger  
- Understøt versionering og iteration af indhold  

**Implementeringstrin:**  
1. Opsæt MCP-klientinfrastrukturen  
2. Opret skabeloner til forskellige indholdstyper  
3. Byg indholdsgenereringspipeline  
4. Implementer revisionssystemet  
5. Udvikl system til måling af performance  
6. Opret brugergrænseflade til skabelonstyring og indholdsgenerering  

**Teknologier:** Valgt programmeringssprog, webframework og databasesystem.

## Fremtidige Retninger for MCP Teknologi

### Nye Tendenser

1. **Multi-Modalt MCP**  
   - Udvidelse af MCP til at standardisere interaktioner med billed-, lyd- og videomodeller  
   - Udvikling af tværmodal ræsonnering  
   - Standardiserede promptformater for forskellige modaliteter  

2. **Federeret MCP Infrastruktur**  
   - Distribuerede MCP-netværk, der kan dele ressourcer på tværs af organisationer  
   - Standardiserede protokoller til sikker modeldeling  
   - Privatlivsbevarende beregningsteknikker  

3. **MCP Markedspladser**  
   - Økosystemer til deling og monetarisering af MCP-skabeloner og plugins  
   - Kvalitetssikring og certificeringsprocesser  
   - Integration med modelmarkedspladser  

4. **MCP til Edge Computing**  
   - Tilpasning af MCP-standarder til ressourcebegrænsede edge-enheder  
   - Optimerede protokoller til lavbåndbredde-miljøer  
   - Specialiserede MCP-implementeringer til IoT-økosystemer  

5. **Regulatoriske Rammer**  
   - Udvikling af MCP-udvidelser til regulatorisk compliance  
   - Standardiserede revisionsspor og forklaringsgrænseflader  
   - Integration med nye AI-styringsrammer  

### MCP Løsninger fra Microsoft

Microsoft og Azure har udviklet flere open source-repositorier for at hjælpe udviklere med at implementere MCP i forskellige scenarier:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – En Playwright MCP-server til browserautomatisering og test  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – En OneDrive MCP-serverimplementering til lokal test og community-bidrag  
3. [NLWeb](https://github.com/microsoft/NlWeb) – NLWeb er en samling af åbne protokoller og tilknyttede open source-værktøjer. Hovedfokus er at etablere et fundamentalt lag for AI Web  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) – Links til eksempler, værktøjer og ressourcer til at bygge og integrere MCP-servere på Azure med flere sprog  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Reference MCP-servere, der demonstrerer autentificering med den aktuelle Model Context Protocol-specifikation  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Landingsside for Remote MCP Server-implementeringer i Azure Functions med links til sprog-specifikke repos  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Quickstart-skabelon til at bygge og udrulle brugerdefinerede remote MCP-servere med Azure Functions i Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Quickstart-skabelon til at bygge og udrulle brugerdefinerede remote MCP-servere med Azure Functions i .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Quickstart-skabelon til at bygge og udrulle brugerdefinerede remote MCP-servere med Azure Functions i TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management som AI Gateway til Remote MCP-servere med Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – APIM ❤️ AI-eksperimenter inklusive MCP-funktioner, integration med Azure OpenAI og AI Foundry  

Disse repositorier tilbyder forskellige implementeringer, skabeloner og ressourcer til arbejde med Model Context Protocol på tværs af forskellige programmeringssprog og Azure-tjenester. De dækker en række brugsscenarier fra grundlæggende serverimplementeringer til autentificering, cloud-udrulning og enterprise-integration.

#### MCP Ressourcedirektorium

[MCP Resources directory](https://github.com/microsoft/mcp/tree/main/Resources) i den officielle Microsoft MCP-repository tilbyder en kurateret samling af eksempler på ressourcer, promptskabeloner og værktøjsdefinitioner til brug med Model Context Protocol-servere. Dette bibliotek er designet til at hjælpe udviklere hurtigt i gang med MCP ved at tilbyde genanvendelige byggesten og bedste praksis-eksempler til:

- **Promptskabeloner:** Klar-til-brug promptskabeloner til almindelige AI-opgaver og scenarier, som kan tilpasses til dine egne MCP-serverimplementeringer.  
- **Værktøjsdefinitioner:** Eksempelværktøjsskemaer og metadata til at standardisere værktøjsintegration og kald på tværs af MCP-servere.  
- **Ressourceeksempler:** Eksempeldefinitioner til at forbinde datakilder, API’er og eksterne tjenester inden for MCP-rammen.  
- **Referenceimplementeringer:** Praktiske eksempler, der viser, hvordan man strukturerer og organiserer ressourcer, prompts og værktøjer i virkelige MCP-projekter.  

Disse ressourcer fremskynder udviklingen, fremmer standardisering og sikrer bedste praksis ved opbygning og implementering af MCP-baserede løsninger.

#### MCP Ressourcedirektorium  
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  

### Forskningsmuligheder

- Effektive teknikker til promptoptimering inden for MCP-rammer  
- Sikkerhedsmodeller for multi-tenant MCP-udrulninger  
- Ydelsesmålinger på tværs af forskellige MCP-implementeringer  
- Formelle verifikationsmetoder for MCP-servere  

## Konklusion

Model Context Protocol (MCP) former hurtigt fremtiden for
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Øvelser

1. Analyser et af casestudierne og foreslå en alternativ implementeringsmetode.
2. Vælg en af projektidéerne og udarbejd en detaljeret teknisk specifikation.
3. Undersøg en branche, der ikke er dækket i casestudierne, og skitser, hvordan MCP kunne løse dens specifikke udfordringer.
4. Udforsk en af fremtidige retninger og skab et koncept for en ny MCP-udvidelse, der kan understøtte den.

Næste: [Best Practices](../08-BestPractices/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.