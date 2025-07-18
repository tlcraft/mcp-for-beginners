<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6755bc4f6d0293ce6c49cfc5efba0d8e",
  "translation_date": "2025-07-18T09:58:19+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "da"
}
-->
# 🌟 Læringer fra Tidlige Brugere

## 🎯 Hvad Dette Modul Dækker

Dette modul undersøger, hvordan rigtige organisationer og udviklere udnytter Model Context Protocol (MCP) til at løse reelle udfordringer og drive innovation. Gennem detaljerede casestudier og praktiske eksempler vil du opdage, hvordan MCP muliggør sikker, skalerbar AI-integration, der forbinder sprogmodeller, værktøjer og virksomhedens data.

### Case Study 5: Azure MCP – Enterprise-Grade Model Context Protocol som en Service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) er Microsofts administrerede, enterprise-grade implementering af Model Context Protocol, designet til at levere skalerbare, sikre og compliant MCP-serverfunktioner som en cloud-tjeneste. Denne omfattende suite inkluderer flere specialiserede MCP-servere til forskellige Azure-tjenester og scenarier.

> **🎯 Produktionsklare Værktøjer**
> 
> Dette casestudie repræsenterer flere produktionsklare MCP-servere! Lær om Azure MCP Server og andre Azure-integrerede servere i vores [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#2--azure-mcp-server).

**Nøglefunktioner:**
- Fuldt administreret MCP-serverhosting med indbygget skalering, overvågning og sikkerhed
- Naturlig integration med Azure OpenAI, Azure AI Search og andre Azure-tjenester
- Enterprise-godkendelse og autorisation via Microsoft Entra ID
- Understøttelse af brugerdefinerede værktøjer, promptskabeloner og ressourceforbindelser
- Overholdelse af virksomhedens sikkerheds- og regulatoriske krav
- 15+ specialiserede Azure serviceforbindelser inklusive database, overvågning og lagring

**Azure MCP Server Funktioner:**
- **Ressourcestyring**: Fuld livscyklusstyring af Azure-ressourcer
- **Databaseforbindelser**: Direkte adgang til Azure Database for PostgreSQL og SQL Server
- **Azure Monitor**: KQL-drevet loganalyse og operationelle indsigter
- **Godkendelse**: DefaultAzureCredential og managed identity mønstre
- **Lagringstjenester**: Blob Storage, Queue Storage og Table Storage operationer
- **Container Services**: Azure Container Apps, Container Instances og AKS-styring

### 📚 Se MCP i Aktion

Vil du se disse principper anvendt i produktionsklare værktøjer? Tjek vores [**10 Microsoft MCP Servers That Are Transforming Developer Productivity**](microsoft-mcp-servers.md), som viser rigtige Microsoft MCP-servere, du kan bruge i dag.

## Oversigt

Denne lektion udforsker, hvordan tidlige brugere har udnyttet Model Context Protocol (MCP) til at løse virkelige udfordringer og drive innovation på tværs af brancher. Gennem detaljerede casestudier og praktiske projekter vil du se, hvordan MCP muliggør standardiseret, sikker og skalerbar AI-integration – der forbinder store sprogmodeller, værktøjer og virksomhedens data i en samlet ramme. Du får praktisk erfaring med at designe og bygge MCP-baserede løsninger, lærer af gennemprøvede implementeringsmønstre og opdager bedste praksis for udrulning af MCP i produktionsmiljøer. Lektionen fremhæver også nye tendenser, fremtidige retninger og open source-ressourcer, der hjælper dig med at holde dig på forkant med MCP-teknologien og dens udviklende økosystem.

## Læringsmål

- Analysere virkelige MCP-implementeringer på tværs af forskellige brancher
- Designe og bygge komplette MCP-baserede applikationer
- Udforske nye tendenser og fremtidige retninger inden for MCP-teknologi
- Anvende bedste praksis i faktiske udviklingsscenarier

## Virkelige MCP-Implementeringer

### Case Study 1: Enterprise Kundesupport Automation

En multinational virksomhed implementerede en MCP-baseret løsning for at standardisere AI-interaktioner på tværs af deres kundesupportsystemer. Dette gjorde det muligt for dem at:

- Skabe en samlet grænseflade for flere LLM-udbydere
- Opretholde ensartet promptstyring på tværs af afdelinger
- Implementere robuste sikkerheds- og compliance-kontroller
- Let skifte mellem forskellige AI-modeller baseret på specifikke behov

**Teknisk Implementering:**  
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

### Case Study 2: Sundhedssektor Diagnostisk Assistent

En sundhedsudbyder udviklede en MCP-infrastruktur til at integrere flere specialiserede medicinske AI-modeller, samtidig med at følsomme patientdata blev beskyttet:

- Problemfri skift mellem generalist- og specialistmedicinske modeller
- Strenge privatlivskontroller og revisionsspor
- Integration med eksisterende Elektroniske Patientjournaler (EHR)
- Ensartet prompt-engineering for medicinsk terminologi

**Teknisk Implementering:**  
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

### Case Study 3: Finansielle Tjenester Risikoanalyse

En finansiel institution implementerede MCP for at standardisere deres risikoanalyseprocesser på tværs af forskellige afdelinger:

- Skabte en samlet grænseflade for kreditrisiko, bedrageridetektion og investeringsrisikomodeller
- Implementerede strenge adgangskontroller og modelversionering
- Sikrede revisionsspor for alle AI-anbefalinger
- Opretholdt ensartet dataformat på tværs af forskellige systemer

**Teknisk Implementering:**  
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

**Resultater:** Forbedret regulatorisk compliance, 40% hurtigere modeludrulningscyklusser og øget konsistens i risikovurdering på tværs af afdelinger.

### Case Study 4: Microsoft Playwright MCP Server til Browserautomation

Microsoft udviklede [Playwright MCP serveren](https://github.com/microsoft/playwright-mcp) for at muliggøre sikker, standardiseret browserautomation gennem Model Context Protocol. Denne produktionsklare server tillader AI-agenter og LLM’er at interagere med webbrowsere på en kontrolleret, reviderbar og udvidelsesvenlig måde – hvilket muliggør brugsscenarier som automatiseret webtest, dataudtræk og end-to-end workflows.

> **🎯 Produktionsklart Værktøj**
> 
> Dette casestudie viser en rigtig MCP-server, du kan bruge i dag! Lær mere om Playwright MCP Server og 9 andre produktionsklare Microsoft MCP-servere i vores [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#8--playwright-mcp-server).

**Nøglefunktioner:**
- Eksponerer browserautomationsfunktioner (navigation, formularudfyldning, skærmbilledeoptagelse osv.) som MCP-værktøjer
- Implementerer strenge adgangskontroller og sandboxing for at forhindre uautoriserede handlinger
- Leverer detaljerede revisionslogfiler for alle browserinteraktioner
- Understøtter integration med Azure OpenAI og andre LLM-udbydere til agentdrevet automation
- Driver GitHub Copilots Coding Agent med webbrowserfunktioner

**Teknisk Implementering:**  
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
- Muliggjorde sikker, programmatisk browserautomation for AI-agenter og LLM’er  
- Reducerede manuel testindsats og forbedrede testdækning for webapplikationer  
- Leverede en genanvendelig, udvidelsesvenlig ramme for browserbaseret værktøjsintegration i virksomhedsmiljøer  
- Driver GitHub Copilots webbrowserfunktioner

**Referencer:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Case Study 5: Azure MCP – Enterprise-Grade Model Context Protocol som en Service

Azure MCP Server ([https://aka.ms/azmcp](https://aka.ms/azmcp)) er Microsofts administrerede, enterprise-grade implementering af Model Context Protocol, designet til at levere skalerbare, sikre og compliant MCP-serverfunktioner som en cloud-tjeneste. Azure MCP gør det muligt for organisationer hurtigt at udrulle, administrere og integrere MCP-servere med Azure AI, data og sikkerhedstjenester, hvilket reducerer driftsomkostninger og fremskynder AI-adoption.

> **🎯 Produktionsklart Værktøj**
> 
> Dette er en rigtig MCP-server, du kan bruge i dag! Lær mere om Azure AI Foundry MCP Server i vores [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md).

- Fuldt administreret MCP-serverhosting med indbygget skalering, overvågning og sikkerhed  
- Naturlig integration med Azure OpenAI, Azure AI Search og andre Azure-tjenester  
- Enterprise-godkendelse og autorisation via Microsoft Entra ID  
- Understøttelse af brugerdefinerede værktøjer, promptskabeloner og ressourceforbindelser  
- Overholdelse af virksomhedens sikkerheds- og regulatoriske krav

**Teknisk Implementering:**  
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
- Reduceret time-to-value for enterprise AI-projekter ved at tilbyde en klar-til-brug, compliant MCP-serverplatform  
- Forenklet integration af LLM’er, værktøjer og virksomhedens datakilder  
- Forbedret sikkerhed, observabilitet og operationel effektivitet for MCP-arbejdsbelastninger  
- Forbedret kodekvalitet med Azure SDK bedste praksis og aktuelle godkendelsesmønstre

**Referencer:**  
- [Azure MCP Dokumentation](https://aka.ms/azmcp)  
- [Azure MCP Server GitHub Repository](https://github.com/Azure/azure-mcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

### Case Study 6: NLWeb – Natural Language Web Interface Protocol

NLWeb repræsenterer Microsofts vision for at etablere et fundamentalt lag for AI Web. Hver NLWeb-instans er også en MCP-server, som understøtter én kerne-metode, `ask`, der bruges til at stille et website et spørgsmål på naturligt sprog. Det returnerede svar benytter schema.org, et bredt anvendt vokabularium til beskrivelse af webdata. Løst sagt er MCP for NLWeb, hvad HTTP er for HTML.

**Nøglefunktioner:**
- **Protokollag**: En simpel protokol til at interagere med websites på naturligt sprog  
- **Schema.org Format**: Udnytter JSON og schema.org til strukturerede, maskinlæsbare svar  
- **Community Implementering**: Enkel implementering for sites, der kan abstraheres som lister af elementer (produkter, opskrifter, attraktioner, anmeldelser osv.)  
- **UI Widgets**: Forudbyggede brugergrænsefladekomponenter til konversationelle interfaces

**Arkitekturkomponenter:**
1. **Protokol**: Simpel REST API til naturlige sprogforespørgsler til websites  
2. **Implementering**: Udnytter eksisterende markup og sitestruktur til automatiserede svar  
3. **UI Widgets**: Klar-til-brug komponenter til integration af konversationelle interfaces

**Fordele:**
- Muliggør både menneske-til-site og agent-til-agent interaktion  
- Leverer strukturerede datasvar, som AI-systemer nemt kan behandle  
- Hurtig udrulning for sites med listebaserede indholdsstrukturer  
- Standardiseret tilgang til at gøre websites AI-tilgængelige

**Resultater:**
- Etablerede fundament for AI-web interaktionsstandarder  
- Forenklet oprettelse af konversationelle interfaces for indholdssites  
- Forbedret opdagelighed og tilgængelighed af webindhold for AI-systemer  
- Fremmet interoperabilitet mellem forskellige AI-agenter og webtjenester

**Referencer:**  
- [NLWeb GitHub Repository](https://github.com/microsoft/NlWeb)  
- [NLWeb Dokumentation](https://github.com/microsoft/NlWeb)

### Case Study 7: Azure AI Foundry MCP Server – Enterprise AI Agent Integration

Azure AI Foundry MCP-servere demonstrerer, hvordan MCP kan bruges til at orkestrere og styre AI-agenter og workflows i virksomhedsmiljøer. Ved at integrere MCP med Azure AI Foundry kan organisationer standardisere agentinteraktioner, udnytte Foundrys workflow-styring og sikre sikre, skalerbare udrulninger.

> **🎯 Produktionsklart Værktøj**
> 
> Dette er en rigtig MCP-server, du kan bruge i dag! Lær mere om Azure AI Foundry MCP Server i vores [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server).

**Nøglefunktioner:**
- Omfattende adgang til Azures AI-økosystem, inklusive modelkataloger og udrulningsstyring  
- Videnindeksering med Azure AI Search til RAG-applikationer  
- Evalueringsværktøjer til AI-modelpræstation og kvalitetssikring  
- Integration med Azure AI Foundry Catalog og Labs til banebrydende forskningsmodeller  
- Agentstyring og evalueringsfunktioner til produktionsscenarier

**Resultater:**
- Hurtig prototyping og robust overvågning af AI-agent workflows  
- Problemfri integration med Azure AI-tjenester til avancerede scenarier  
- En samlet grænseflade til at bygge, udrulle og overvåge agent pipelines  
- Forbedret sikkerhed, compliance og operationel effektivitet for virksomheder  
- Accelereret AI-adoption samtidig med kontrol over komplekse agentdrevne processer

**Referencer:**  
- [Azure AI Foundry MCP Server GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrering af Azure AI Agenter med MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Case Study 8: Foundry MCP Playground – Eksperimentering og Prototyping

Foundry MCP Playground tilbyder et klar-til-brug miljø til eksperimenter med MCP-servere og Azure AI Foundry-integrationer. Udviklere kan hurtigt prototype, teste og evaluere AI-modeller og agent workflows ved hjælp af ressourcer fra Azure AI Foundry Catalog og Labs. Playgrounden forenkler opsætning, leverer eksempler og understøtter samarbejdsudvikling, hvilket gør det nemt at udforske bedste praksis og nye scenarier med minimal indsats. Det er især nyttigt for teams, der ønsker at validere idéer, dele eksperimenter og accelerere læring uden behov for kompleks infrastruktur. Ved at sænke adgangsbarrieren fremmer playgrounden innovation og fællesskabsbidrag i MCP- og Azure AI Foundry-økosystemet.

**Referencer:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Case Study 9: Microsoft Learn Docs MCP Server – AI-Drevet Dokumentationsadgang

Microsoft Learn Docs MCP Server er en cloud-hostet tjeneste, der giver AI-assistenter realtidsadgang til officiel Microsoft-dokumentation via Model Context Protocol. Denne produktionsklare server forbinder til det omfattende Microsoft Learn-økosystem og muliggør semantisk søgning på tværs af alle officielle Microsoft-kilder.
> **🎯 Produktionsklar Værktøj**
> 
> Dette er en ægte MCP-server, du kan bruge i dag! Læs mere om Microsoft Learn Docs MCP Server i vores [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server).
**Nøglefunktioner:**
- Realtidsadgang til officiel Microsoft-dokumentation, Azure-dokumenter og Microsoft 365-dokumentation
- Avancerede semantiske søgefunktioner, der forstår kontekst og hensigt
- Altid opdaterede oplysninger, da Microsoft Learn-indhold publiceres løbende
- Omfattende dækning på tværs af Microsoft Learn, Azure-dokumentation og Microsoft 365-kilder
- Returnerer op til 10 kvalitetsindholdsstykker med artikeltitler og URL’er

**Hvorfor det er vigtigt:**
- Løser problemet med "forældet AI-viden" for Microsoft-teknologier
- Sikrer, at AI-assistenter har adgang til de nyeste .NET, C#, Azure og Microsoft 365-funktioner
- Leverer autoritativ, førstepartsinformation for præcis kodegenerering
- Uundværlig for udviklere, der arbejder med hurtigt udviklende Microsoft-teknologier

**Resultater:**
- Markant forbedret nøjagtighed af AI-genereret kode til Microsoft-teknologier
- Mindre tid brugt på at søge efter aktuel dokumentation og bedste praksis
- Øget udviklerproduktivitet med kontekstbevidst dokumentationshentning
- Problemfri integration i udviklingsarbejdsgange uden at forlade IDE’en

**Referencer:**
- [Microsoft Learn Docs MCP Server GitHub Repository](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn Documentation](https://learn.microsoft.com/)

## Praktiske Projekter

### Projekt 1: Byg en Multi-Provider MCP Server

**Mål:** Opret en MCP-server, der kan dirigere forespørgsler til flere AI-modeludbydere baseret på specifikke kriterier.

**Krav:**
- Understøt mindst tre forskellige modeludbydere (f.eks. OpenAI, Anthropic, lokale modeller)
- Implementer en routing-mekanisme baseret på metadata i forespørgsler
- Opret et konfigurationssystem til håndtering af udbyderlegitimationsoplysninger
- Tilføj caching for at optimere ydeevne og omkostninger
- Byg et simpelt dashboard til overvågning af brug

**Implementeringstrin:**
1. Opsæt grundlæggende MCP-serverinfrastruktur
2. Implementer adaptere til hver AI-modeltjeneste
3. Opret routing-logik baseret på forespørgselsattributter
4. Tilføj caching-mekanismer til hyppige forespørgsler
5. Udvikl overvågningsdashboardet
6. Test med forskellige forespørgselsmønstre

**Teknologier:** Vælg mellem Python (.NET/Java/Python efter eget valg), Redis til caching og et simpelt webframework til dashboardet.

### Projekt 2: Enterprise Prompt Management System

**Mål:** Udvikl et MCP-baseret system til at administrere, versionere og implementere promptskabeloner på tværs af en organisation.

**Krav:**
- Opret et centraliseret lager til promptskabeloner
- Implementer versionering og godkendelsesarbejdsgange
- Byg testmuligheder for skabeloner med prøveinput
- Udvikl rollebaserede adgangskontroller
- Opret en API til hentning og implementering af skabeloner

**Implementeringstrin:**
1. Design databaseskema til lagring af skabeloner
2. Opret kerne-API til CRUD-operationer på skabeloner
3. Implementer versionsstyringssystemet
4. Byg godkendelsesarbejdsgangen
5. Udvikl testframeworket
6. Opret en simpel webgrænseflade til administration
7. Integrer med en MCP-server

**Teknologier:** Valgfrit backend-framework, SQL- eller NoSQL-database og et frontend-framework til administrationsgrænsefladen.

### Projekt 3: MCP-baseret Indholdsgenereringsplatform

**Mål:** Byg en platform til indholdsgenerering, der bruger MCP til at levere konsistente resultater på tværs af forskellige indholdstyper.

**Krav:**
- Understøt flere indholdsformater (blogindlæg, sociale medier, marketingtekst)
- Implementer skabelonbaseret generering med tilpasningsmuligheder
- Opret et system til indholdsrevision og feedback
- Spor indholdsperformance-målinger
- Understøt versionering og iteration af indhold

**Implementeringstrin:**
1. Opsæt MCP-klientinfrastruktur
2. Opret skabeloner til forskellige indholdstyper
3. Byg indholdsgenereringspipeline
4. Implementer revisionssystemet
5. Udvikl system til måling af performance
6. Opret brugergrænseflade til skabelonadministration og indholdsgenerering

**Teknologier:** Valgfrit programmeringssprog, webframework og databasesystem.

## Fremtidige Retninger for MCP Teknologi

### Nye Tendenser

1. **Multi-Modal MCP**
   - Udvidelse af MCP til at standardisere interaktioner med billed-, lyd- og videomodeller
   - Udvikling af tværmodal ræsonnering
   - Standardiserede promptformater til forskellige modaliteter

2. **Federeret MCP Infrastruktur**
   - Distribuerede MCP-netværk, der kan dele ressourcer på tværs af organisationer
   - Standardiserede protokoller til sikker deling af modeller
   - Privatlivsbevarende beregningsteknikker

3. **MCP Markedspladser**
   - Økosystemer til deling og monetarisering af MCP-skabeloner og plugins
   - Kvalitetssikring og certificeringsprocesser
   - Integration med modelmarkedspladser

4. **MCP til Edge Computing**
   - Tilpasning af MCP-standarder til ressourcestærkt begrænsede edge-enheder
   - Optimerede protokoller til lavbåndbredde-miljøer
   - Specialiserede MCP-implementeringer til IoT-økosystemer

5. **Regulatoriske Rammer**
   - Udvikling af MCP-udvidelser til overholdelse af regler
   - Standardiserede revisionsspor og forklaringsgrænseflader
   - Integration med nye AI-styringsrammer

### MCP-løsninger fra Microsoft

Microsoft og Azure har udviklet flere open source-repositorier for at hjælpe udviklere med at implementere MCP i forskellige scenarier:

#### Microsoft Organization
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - En Playwright MCP-server til browserautomatisering og test
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - En OneDrive MCP-serverimplementering til lokal test og community-bidrag
3. [NLWeb](https://github.com/microsoft/NlWeb) - NLWeb er en samling af åbne protokoller og tilhørende open source-værktøjer. Fokus er at etablere et fundamentalt lag for AI Web

#### Azure-Samples Organization
1. [mcp](https://github.com/Azure-Samples/mcp) - Links til eksempler, værktøjer og ressourcer til at bygge og integrere MCP-servere på Azure med flere sprog
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Reference MCP-servere, der demonstrerer autentificering med den nuværende Model Context Protocol-specifikation
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Landingsside for Remote MCP Server-implementeringer i Azure Functions med links til sprog-specifikke repos
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Quickstart-skabelon til at bygge og implementere brugerdefinerede remote MCP-servere med Azure Functions i Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Quickstart-skabelon til at bygge og implementere brugerdefinerede remote MCP-servere med Azure Functions i .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Quickstart-skabelon til at bygge og implementere brugerdefinerede remote MCP-servere med Azure Functions i TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management som AI Gateway til Remote MCP-servere med Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI-eksperimenter inklusive MCP-funktioner, integration med Azure OpenAI og AI Foundry

Disse repositorier tilbyder forskellige implementeringer, skabeloner og ressourcer til arbejde med Model Context Protocol på tværs af programmeringssprog og Azure-tjenester. De dækker en bred vifte af anvendelsestilfælde fra grundlæggende serverimplementeringer til autentificering, cloud-udrulning og enterprise-integration.

#### MCP Resources Directory

[Resources-mappen](https://github.com/microsoft/mcp/tree/main/Resources) i den officielle Microsoft MCP-repository indeholder en kurateret samling af eksempler på ressourcer, promptskabeloner og værktøjsdefinitioner til brug med Model Context Protocol-servere. Denne mappe er designet til at hjælpe udviklere hurtigt i gang med MCP ved at tilbyde genanvendelige byggesten og bedste praksis-eksempler for:

- **Promptskabeloner:** Klar-til-brug promptskabeloner til almindelige AI-opgaver og scenarier, som kan tilpasses til dine egne MCP-serverimplementeringer.
- **Værktøjsdefinitioner:** Eksempelværktøjsskemaer og metadata til standardisering af værktøjsintegration og kald på tværs af forskellige MCP-servere.
- **Ressourceeksempler:** Eksempeldefinitioner til tilslutning af datakilder, API’er og eksterne tjenester inden for MCP-rammen.
- **Referenceimplementeringer:** Praktiske eksempler, der viser, hvordan man strukturerer og organiserer ressourcer, prompts og værktøjer i virkelige MCP-projekter.

Disse ressourcer fremskynder udviklingen, fremmer standardisering og hjælper med at sikre bedste praksis ved opbygning og udrulning af MCP-baserede løsninger.

#### MCP Resources Directory
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Forskningsmuligheder

- Effektive teknikker til promptoptimering inden for MCP-rammer
- Sikkerhedsmodeller for multi-tenant MCP-udrulninger
- Ydelsesmålinger på tværs af forskellige MCP-implementeringer
- Formelle verifikationsmetoder for MCP-servere

## Konklusion

Model Context Protocol (MCP) former hurtigt fremtiden for standardiseret, sikker og interoperabel AI-integration på tværs af brancher. Gennem casestudierne og de praktiske projekter i denne lektion har du set, hvordan tidlige brugere – herunder Microsoft og Azure – udnytter MCP til at løse virkelige udfordringer, fremskynde AI-adoption og sikre overholdelse, sikkerhed og skalerbarhed. MCP’s modulære tilgang gør det muligt for organisationer at forbinde store sprogmodeller, værktøjer og virksomhedens data i en samlet, reviderbar ramme. Efterhånden som MCP udvikler sig, vil det være afgørende at engagere sig i fællesskabet, udforske open source-ressourcer og anvende bedste praksis for at bygge robuste, fremtidssikrede AI-løsninger.

## Yderligere Ressourcer

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)
- [MCP Resources Directory (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)
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

1. Analyser et af casestudierne og foreslå en alternativ implementeringstilgang.
2. Vælg en af projektidéerne og udarbejd en detaljeret teknisk specifikation.
3. Undersøg en branche, der ikke er dækket i casestudierne, og skitser, hvordan MCP kan løse dens specifikke udfordringer.
4. Udforsk en af de fremtidige retninger og skab et koncept for en ny MCP-udvidelse til at understøtte den.

Næste: [Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.