<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:19:31+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "da"
}
-->
# Lessons from Early Adopters

## Oversigt

Denne lektion undersøger, hvordan tidlige brugere har udnyttet Model Context Protocol (MCP) til at løse virkelige udfordringer og drive innovation på tværs af brancher. Gennem detaljerede casestudier og praktiske projekter vil du se, hvordan MCP muliggør standardiseret, sikker og skalerbar AI-integration—der forbinder store sprogmodeller, værktøjer og virksomhedens data i en samlet ramme. Du får praktisk erfaring med at designe og bygge MCP-baserede løsninger, lærer af gennemprøvede implementeringsmønstre og opdager bedste praksis for udrulning af MCP i produktionsmiljøer. Lektionen fremhæver også nye tendenser, fremtidige retninger og open source-ressourcer, som hjælper dig med at være på forkant med MCP-teknologi og dets udviklende økosystem.

## Læringsmål

- Analysere virkelige MCP-implementeringer på tværs af forskellige brancher  
- Designe og bygge komplette MCP-baserede applikationer  
- Udforske nye tendenser og fremtidige retninger inden for MCP-teknologi  
- Anvende bedste praksis i konkrete udviklingsscenarier  

## Virkelige MCP-implementeringer

### Case Study 1: Automatisering af kundesupport i virksomheder

En multinational virksomhed implementerede en MCP-baseret løsning for at standardisere AI-interaktioner på tværs af deres kundesupportsystemer. Dette gjorde det muligt for dem at:

- Skabe en samlet grænseflade til flere LLM-udbydere  
- Opretholde ensartet promptstyring på tværs af afdelinger  
- Implementere robuste sikkerheds- og compliance-kontroller  
- Nem skift mellem forskellige AI-modeller baseret på specifikke behov  

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

**Resultater:** 30% reduktion i modelomkostninger, 45% forbedring i responsens konsistens og øget compliance på tværs af globale operationer.

### Case Study 2: Diagnostisk assistent i sundhedssektoren

En sundhedsudbyder udviklede en MCP-infrastruktur til at integrere flere specialiserede medicinske AI-modeller, samtidig med at følsomme patientdata blev beskyttet:

- Problemfri skift mellem generalist- og specialistmodeller  
- Strenge privatlivskontroller og revisionsspor  
- Integration med eksisterende Electronic Health Record (EHR)-systemer  
- Ensartet promptengineering for medicinsk terminologi  

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

**Resultater:** Forbedrede diagnostiske forslag til læger, samtidig med fuld HIPAA-overholdelse og betydelig reduktion i kontekstskift mellem systemer.

### Case Study 3: Risikoanalyse i finanssektoren

En finansiel institution implementerede MCP for at standardisere deres risikoanalyseprocesser på tværs af afdelinger:

- Skabte en samlet grænseflade for kreditrisiko, bedrageri og investeringsrisikomodeller  
- Implementerede strenge adgangskontroller og versionsstyring af modeller  
- Sikrede revisionsspor for alle AI-anbefalinger  
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

### Case Study 4: Microsoft Playwright MCP Server til browserautomatisering

Microsoft udviklede [Playwright MCP server](https://github.com/microsoft/playwright-mcp) for at muliggøre sikker, standardiseret browserautomatisering via Model Context Protocol. Denne løsning gør det muligt for AI-agenter og LLM’er at interagere med webbrowsere på en kontrolleret, reviderbar og udvidelig måde—med anvendelser som automatiseret webtest, dataudtræk og end-to-end workflows.

- Eksponerer browserautomatiseringsfunktioner (navigation, formularudfyldning, skærmbilleder mv.) som MCP-værktøjer  
- Implementerer strenge adgangskontroller og sandkassemiljø for at forhindre uautoriserede handlinger  
- Leverer detaljerede revisionslogfiler for alle browserinteraktioner  
- Understøtter integration med Azure OpenAI og andre LLM-udbydere til agentdrevet automatisering  

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
- Muliggjorde sikker, programmatisk browserautomatisering for AI-agenter og LLM’er  
- Reducerede manuelt testarbejde og forbedrede testdækningen for webapplikationer  
- Tilvejebragte en genanvendelig, udvidelig ramme for browserbaseret værktøjsintegration i virksomhedsmiljøer  

**Referencer:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### Case Study 5: Azure MCP – Enterprise-grade Model Context Protocol som en tjeneste

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) er Microsofts administrerede, enterprise-grade implementering af Model Context Protocol, designet til at levere skalerbare, sikre og compliant MCP-serverfunktioner som en cloud-tjeneste. Azure MCP gør det muligt for organisationer hurtigt at udrulle, administrere og integrere MCP-servere med Azure AI, data og sikkerhedstjenester, hvilket reducerer driftsomkostninger og fremskynder AI-adoption.

- Fuldt administreret MCP-serverhosting med indbygget skalering, overvågning og sikkerhed  
- Indbygget integration med Azure OpenAI, Azure AI Search og andre Azure-tjenester  
- Enterprise-godkendelse og autorisation via Microsoft Entra ID  
- Understøttelse af brugerdefinerede værktøjer, promptskabeloner og ressourceforbindelser  
- Overholdelse af virksomhedens sikkerheds- og regulatoriske krav  

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
- Reducerede time-to-value for enterprise AI-projekter ved at tilbyde en klar til brug, compliant MCP-serverplatform  
- Forenklet integration af LLM’er, værktøjer og virksomhedens datakilder  
- Forbedret sikkerhed, observabilitet og operationel effektivitet for MCP-arbejdsmængder  

**Referencer:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## Case Study 6: NLWeb  
MCP (Model Context Protocol) er et nyt protokol til chatbots og AI-assistenter til at interagere med værktøjer. Hver NLWeb-instans er også en MCP-server, som understøtter én kerne-metode, ask, der bruges til at stille et spørgsmål til et website i naturligt sprog. Det returnerede svar udnytter schema.org, et bredt anvendt vokabularium til at beskrive webdata. Kort sagt er MCP til NLWeb, hvad HTTP er for HTML. NLWeb kombinerer protokoller, schema.org-formater og eksempel-kode for at hjælpe sites med hurtigt at skabe disse endpoints, hvilket gavner både mennesker gennem konversationsgrænseflader og maskiner gennem naturlig agent-til-agent interaktion.

Der er to adskilte komponenter i NLWeb:  
- En protokol, som er meget enkel at starte med, til at interagere med et site i naturligt sprog og et format, der udnytter json og schema.org til det returnerede svar. Se dokumentationen om REST API for flere detaljer.  
- En ligetil implementering af (1), der udnytter eksisterende markup til sites, der kan abstraheres som lister over elementer (produkter, opskrifter, attraktioner, anmeldelser mv.). Sammen med en række brugerfladewidgets kan sites nemt tilbyde konversationsgrænseflader til deres indhold. Se dokumentationen om Life of a chat query for mere info om, hvordan det fungerer.  

**Referencer:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### Case Study 7: MCP for Foundry – Integration af Azure AI-agenter

Azure AI Foundry MCP-servere demonstrerer, hvordan MCP kan bruges til at orkestrere og administrere AI-agenter og workflows i virksomhedsmiljøer. Ved at integrere MCP med Azure AI Foundry kan organisationer standardisere agentinteraktioner, udnytte Foundrys workflow management og sikre sikre, skalerbare udrulninger. Denne tilgang muliggør hurtig prototyping, robust overvågning og sømløs integration med Azure AI-tjenester, hvilket understøtter avancerede scenarier som vidensstyring og agentvurdering. Udviklere får en samlet grænseflade til at bygge, udrulle og overvåge agentpipelines, mens IT-teams opnår bedre sikkerhed, compliance og operationel effektivitet. Løsningen er ideel for virksomheder, der ønsker at accelerere AI-adoption og bevare kontrol over komplekse agentdrevne processer.

**Referencer:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### Case Study 8: Foundry MCP Playground – Eksperimenter og prototyping

Foundry MCP Playground tilbyder et klar-til-brug miljø til eksperimenter med MCP-servere og Azure AI Foundry-integrationer. Udviklere kan hurtigt prototype, teste og evaluere AI-modeller og agentworkflows ved hjælp af ressourcer fra Azure AI Foundry Catalog og Labs. Playgrounden forenkler opsætning, tilbyder eksempler på projekter og understøtter samarbejdsudvikling, hvilket gør det nemt at udforske bedste praksis og nye scenarier med minimal indsats. Den er især nyttig for teams, der ønsker at validere idéer, dele eksperimenter og accelerere læring uden behov for kompleks infrastruktur. Ved at sænke adgangsbarrieren fremmer playgrounden innovation og bidrag i MCP- og Azure AI Foundry-økosystemet.

**Referencer:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

### Case Study 9: Microsoft Docs MCP Server – Læring og kompetenceudvikling  
Microsoft Docs MCP Server implementerer Model Context Protocol (MCP) serveren, der giver AI-assistenter adgang i realtid til officiel Microsoft-dokumentation. Udfører semantisk søgning mod Microsofts officielle tekniske dokumentation.

**Referencer:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)  

## Praktiske projekter

### Projekt 1: Byg en MCP-server med flere udbydere

**Mål:** Opret en MCP-server, der kan dirigere forespørgsler til flere AI-modeludbydere baseret på specifikke kriterier.

**Krav:**  
- Understøt mindst tre forskellige modeludbydere (fx OpenAI, Anthropic, lokale modeller)  
- Implementer en routing-mekanisme baseret på metadata i forespørgsler  
- Opret et konfigurationssystem til håndtering af udbyderlegitimationsoplysninger  
- Tilføj caching for at optimere ydeevne og omkostninger  
- Byg et simpelt dashboard til overvågning af brug  

**Implementeringstrin:**  
1. Opsæt grundlæggende MCP-serverinfrastruktur  
2. Implementer adaptere for hver AI-modeltjeneste  
3. Skab routinglogik baseret på forespørgselsattributter  
4. Tilføj caching-mekanismer til hyppige forespørgsler  
5. Udvikl overvågningsdashboard  
6. Test med forskellige forespørgselsmønstre  

**Teknologier:** Vælg blandt Python (.NET/Java/Python efter præference), Redis til caching og et simpelt webframework til dashboard.

### Projekt 2: Enterprise Prompt Management System

**Mål:** Udvikl et MCP-baseret system til håndtering, versionsstyring og udrulning af promptskabeloner på tværs af en organisation.

**Krav:**  
- Opret et centralt lager for promptskabeloner  
- Implementer versionsstyring og godkendelsesworkflow  
- Byg testfunktioner til skabeloner med eksempelinput  
- Udvikl rollebaserede adgangskontroller  
- Opret et API til hentning og udrulning af skabeloner  

**Implementeringstrin:**  
1. Design databaseskema til lagring af skabeloner  
2. Opret kerne-API til CRUD-operationer på skabeloner  
3. Implementer versionsstyringssystem  
4. Byg godkendelsesworkflow  
5. Udvikl testframework  
6. Opret en simpel webgrænseflade til administration  
7. Integrer med en MCP-server  

**Teknologier:** Valgfrit backend-framework, SQL eller NoSQL database og frontend-framework til administrationsgrænseflade.

### Projekt 3: MCP-baseret platform til indholdsgenerering

**Mål:** Byg en platform til indholdsgenerering, der udnytter MCP til at levere konsistente resultater på tværs af forskellige indholdstyper.

**Krav:**  
- Understøt flere indholdsformater (blogindlæg, sociale medier, marketingtekster)  
- Implementer skabelonbaseret generering med tilpasningsmuligheder  
- Opret et system til indholdsrevision og feedback  
- Spor indholdsperformance-metrikker  
- Understøt versionsstyring og iteration af indhold  

**Implementeringstrin:**  
1. Opsæt MCP-klientinfrastruktur  
2. Opret skabeloner til forskellige indholdstyper  
3. Byg indholdsgenereringspipeline  
4. Implementer revisionssystem  
5. Udvikl system til metriksporing  
6. Skab brugerflade til skabelonstyring og indholdsgenerering  

**Teknologier:** Valgt programmeringssprog, webframework og databasesystem.

## Fremtidige retninger for MCP-teknologi

### Nye tendenser

1. **Multi-modal MCP**  
   - Udvidelse af MCP til at standardisere interaktioner med billed-, lyd- og videomodeller  
   - Udvikling af tværmodal ræsonnering  
   - Standardiserede promptformater til forskellige modaliteter  

2. **Federeret MCP-infrastruktur**  
   - Distribuerede MCP-netværk, der kan dele ressourcer på tværs af organisationer  
   - Standardiserede protokoller for sikker modeldeling  
   - Privatlivsbeskyttende beregningsteknikker  

3. **MCP-markedspladser**  
   - Økosystemer til deling og kommercialisering af MCP-skabeloner og plugins  
   - Kvalitetssikring og certificeringsprocesser  
   - Integration med modelmarkedspladser  

4. **MCP til edge computing**  
   - Tilpasning af MCP-standarder til ressourcestærkt begrænsede edge-enheder  
   - Optimerede protokoller til lav båndbredde  
   - Specialiserede MCP-implementeringer til IoT-økosystemer  

5. **Regulatoriske rammer**  
   - Udvikling af MCP-udvidelser til regulatorisk compliance  
   - Standardiserede revisionsspor og forklaringsgrænseflader  
   - Integration med nye AI-styringsrammer  

### MCP-løsninger fra Microsoft

Microsoft og Azure har udviklet flere open source-repositorier for at hjælpe udviklere med at implementere MCP i forskellige scenarier:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – En Playwright MCP-server til browserautomatisering og test  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – En OneDrive MCP-serverimplementering til lokal test og community-bidrag  
3. [NLWeb](https://github.com/microsoft/NlWeb) – Samling af åbne protokoller og tilhørende open source-værktøjer med fokus på et fundament for AI Web  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) – Links til eksempler, værktøjer og ressourcer til at bygge og integrere MCP-servere på Azure med flere sprog  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Reference MCP-servere, der demonstrerer autentifikation med den aktuelle Model Context Protocol-specifikation  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Landing page for Remote MCP Server-implementeringer i Azure Functions med links til sprog-specifikke repos  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Quickstart-template til at bygge og udrulle tilpassede remote MCP-servere med Azure Functions i Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Quickstart-template til at bygge og udrulle tilpassede remote MCP-servere med Azure Functions i .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Quickstart-template til at bygge og udrulle tilpassede remote MCP-servere med Azure Functions i TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management som AI Gateway til Remote MCP-servere ved brug af Python  
8. [AI-Gateway](https://github.com/Azure-Samples
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

## Øvelser

1. Analyser et af case-studierne og foreslå en alternativ implementeringsmetode.
2. Vælg en af projektidéerne og udarbejd en detaljeret teknisk specifikation.
3. Undersøg en branche, der ikke er dækket i case-studierne, og skitser hvordan MCP kunne løse dens specifikke udfordringer.
4. Udforsk en af de fremtidige retninger og skab et koncept for en ny MCP-udvidelse til at understøtte den.

Næste: [Best Practices](../08-BestPractices/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiske oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.