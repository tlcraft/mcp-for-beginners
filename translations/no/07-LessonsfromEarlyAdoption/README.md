<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T21:47:36+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "no"
}
-->
# Leksjoner fra Tidlige Adopterere

## Oversikt

Denne leksjonen utforsker hvordan tidlige adopterere har brukt Model Context Protocol (MCP) for å løse reelle utfordringer og drive innovasjon på tvers av bransjer. Gjennom detaljerte casestudier og praktiske prosjekter vil du se hvordan MCP muliggjør standardisert, sikker og skalerbar AI-integrasjon—ved å koble store språkmodeller, verktøy og bedriftsdata i en samlet ramme. Du vil få praktisk erfaring med å designe og bygge MCP-baserte løsninger, lære av velprøvde implementeringsmønstre, og oppdage beste praksis for produksjonssetting av MCP. Leksjonen fremhever også nye trender, fremtidige retninger og åpne ressurser for å hjelpe deg å holde deg i fronten av MCP-teknologien og dens økosystem i utvikling.

## Læringsmål

- Analysere reelle MCP-implementeringer på tvers av ulike bransjer  
- Designe og bygge komplette MCP-baserte applikasjoner  
- Utforske nye trender og fremtidige retninger innen MCP-teknologi  
- Anvende beste praksis i faktiske utviklingsscenarier  

## Reelle MCP-implementeringer

### Casestudie 1: Automatisering av bedriftskundestøtte

Et multinasjonalt selskap implementerte en MCP-basert løsning for å standardisere AI-interaksjoner på tvers av deres kundestøttesystemer. Dette gjorde det mulig å:

- Lage et samlet grensesnitt for flere LLM-leverandører  
- Opprettholde konsekvent promptstyring på tvers av avdelinger  
- Implementere robuste sikkerhets- og samsvarskontroller  
- Enkel bytte mellom ulike AI-modeller basert på spesifikke behov  

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

**Resultater:** 30 % reduksjon i modellkostnader, 45 % forbedring i responssammenheng, og bedre samsvar på tvers av globale operasjoner.

### Casestudie 2: Helsediagnostisk assistent

En helsetjenesteleverandør utviklet en MCP-infrastruktur for å integrere flere spesialiserte medisinske AI-modeller samtidig som sensitiv pasientdata ble beskyttet:

- Sømløst bytte mellom generelle og spesialiserte medisinske modeller  
- Strenge personvernkontroller og revisjonsspor  
- Integrasjon med eksisterende Elektroniske Pasientjournaler (EHR)  
- Konsistent promptutforming for medisinsk terminologi  

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

**Resultater:** Forbedrede diagnostiske forslag for leger med full HIPAA-kompatibilitet og betydelig reduksjon i kontekstbytte mellom systemer.

### Casestudie 3: Risikoanalyse i finanssektoren

En finansinstitusjon implementerte MCP for å standardisere risikoprosesser på tvers av ulike avdelinger:

- Laget et samlet grensesnitt for kreditt-, svindel- og investeringsrisikomodeller  
- Innført strenge tilgangskontroller og modellversjonering  
- Sikret sporbarhet for alle AI-anbefalinger  
- Opprettholdt konsistent dataformat på tvers av systemer  

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

**Resultater:** Bedret regulatorisk samsvar, 40 % raskere modellutrullingssykluser, og økt konsistens i risikovurderinger.

### Casestudie 4: Microsoft Playwright MCP-server for nettleserautomatisering

Microsoft utviklet [Playwright MCP-serveren](https://github.com/microsoft/playwright-mcp) for å muliggjøre sikker og standardisert nettleserautomatisering via Model Context Protocol. Løsningen lar AI-agenter og LLM-er samhandle med nettlesere på en kontrollert, reviderbar og utvidbar måte—som muliggjør automatisert webtesting, datautvinning og ende-til-ende arbeidsflyter.

- Eksponerer nettleserautomatiseringsfunksjoner (navigasjon, skjemautfylling, skjermbildeopptak osv.) som MCP-verktøy  
- Implementerer strenge tilgangskontroller og sandkasse for å forhindre uautorisert aktivitet  
- Tilbyr detaljerte revisjonslogger for alle nettleserinteraksjoner  
- Støtter integrasjon med Azure OpenAI og andre LLM-leverandører for agentstyrt automatisering  

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
- Muliggjorde sikker, programmert nettleserautomatisering for AI-agenter og LLM-er  
- Reduserte manuelt testarbeid og økte testdekning for webapplikasjoner  
- Tilbød et gjenbrukbart og utvidbart rammeverk for nettleserbasert verktøyintegrasjon i bedriftsmiljøer  

**Referanser:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Casestudie 5: Azure MCP – Bedriftsklasse Model Context Protocol som en tjeneste

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) er Microsofts administrerte, bedriftsklare implementering av Model Context Protocol, designet for å tilby skalerbare, sikre og samsvarende MCP-serverkapasiteter som en skybasert tjeneste. Azure MCP gjør det mulig for organisasjoner å raskt distribuere, administrere og integrere MCP-servere med Azure AI, data og sikkerhetstjenester, noe som reduserer driftskostnader og akselererer AI-adopsjon.

- Fullt administrert MCP-serverhosting med innebygd skalering, overvåking og sikkerhet  
- Nativ integrasjon med Azure OpenAI, Azure AI Search og andre Azure-tjenester  
- Bedriftsautentisering og autorisasjon via Microsoft Entra ID  
- Støtte for tilpassede verktøy, promptmaler og ressurskoblinger  
- Samsvar med bedriftskrav til sikkerhet og regelverk  

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
- Redusert tid til verdi for bedrifts-AI-prosjekter ved å tilby en klar-til-bruk, samsvarende MCP-serverplattform  
- Forenklet integrasjon av LLM-er, verktøy og bedriftsdatasystemer  
- Forbedret sikkerhet, observabilitet og driftsmessig effektivitet for MCP-arbeidsbelastninger  

**Referanser:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Casestudie 6: NLWeb  
MCP (Model Context Protocol) er en ny protokoll for chatboter og AI-assistenter til å samhandle med verktøy. Hver NLWeb-instans er også en MCP-server som støtter én kjernefunksjon, ask, som brukes for å stille et nettsted et spørsmål på naturlig språk. Svaret bruker schema.org, et mye brukt vokabular for å beskrive webdata. Enkelt sagt er MCP for NLWeb det samme som Http er for HTML. NLWeb kombinerer protokoller, Schema.org-formater og eksempelkode for å hjelpe nettsteder å raskt lage slike endepunkter, som gagner både mennesker gjennom samtalegrensesnitt og maskiner gjennom naturlig agent-til-agent-interaksjon.

NLWeb består av to distinkte komponenter:  
- En protokoll, enkel å komme i gang med, for å kommunisere med et nettsted på naturlig språk og et format som bruker json og schema.org for svaret. Se dokumentasjonen for REST API for mer informasjon.  
- En enkel implementering av (1) som utnytter eksisterende markup for nettsteder som kan abstraheres som lister av elementer (produkter, oppskrifter, attraksjoner, anmeldelser osv.). Sammen med et sett brukergrensesnitt-widgets kan nettsteder enkelt tilby samtalegrensesnitt til innholdet sitt. Se dokumentasjonen om Life of a chat query for mer informasjon om hvordan dette fungerer.

**Referanser:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Casestudie 7: MCP for Foundry – Integrering av Azure AI-agenter

Azure AI Foundry MCP-servere viser hvordan MCP kan brukes til å orkestrere og administrere AI-agenter og arbeidsflyter i bedriftsmiljøer. Ved å integrere MCP med Azure AI Foundry kan organisasjoner standardisere agentinteraksjoner, utnytte Foundrys arbeidsflytshåndtering, og sikre sikre, skalerbare distribusjoner. Denne tilnærmingen muliggjør rask prototyping, robust overvåking og sømløs integrasjon med Azure AI-tjenester, og støtter avanserte scenarier som kunnskapsstyring og agentvurdering. Utviklere får et samlet grensesnitt for bygging, distribusjon og overvåking av agent-pipelines, mens IT-team får bedre sikkerhet, samsvar og driftsmessig effektivitet. Løsningen er ideell for bedrifter som ønsker å akselerere AI-adopsjon og beholde kontroll over komplekse agentdrevne prosesser.

**Referanser:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Casestudie 8: Foundry MCP Playground – Eksperimentering og prototyping

Foundry MCP Playground tilbyr et klart-til-bruk-miljø for å eksperimentere med MCP-servere og Azure AI Foundry-integrasjoner. Utviklere kan raskt prototype, teste og evaluere AI-modeller og agentarbeidsflyter ved hjelp av ressurser fra Azure AI Foundry-katalogen og Labs. Playgrounden forenkler oppsett, tilbyr eksempelsprosjekter og støtter samarbeidende utvikling, noe som gjør det enkelt å utforske beste praksis og nye scenarier med minimal innsats. Den er spesielt nyttig for team som ønsker å validere ideer, dele eksperimenter og akselerere læring uten behov for kompleks infrastruktur. Ved å senke inngangsbarrieren bidrar playgrounden til innovasjon og fellesskapsbidrag i MCP- og Azure AI Foundry-økosystemet.

**Referanser:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Praktiske Prosjekter

### Prosjekt 1: Bygg en MCP-server med flere leverandører

**Mål:** Lag en MCP-server som kan rute forespørsler til flere AI-modellleverandører basert på bestemte kriterier.

**Krav:**  
- Støtte minst tre forskjellige modellleverandører (f.eks. OpenAI, Anthropic, lokale modeller)  
- Implementere en rutemekanisme basert på forespørselsmetadata  
- Lage et konfigurasjonssystem for håndtering av leverandørlegitimasjon  
- Legge til caching for å optimalisere ytelse og kostnader  
- Bygge et enkelt dashbord for overvåking av bruk  

**Implementeringstrinn:**  
1. Sett opp grunnleggende MCP-serverinfrastruktur  
2. Implementer adaptere for hver AI-modelltjeneste  
3. Lag rutelogikken basert på forespørselsattributter  
4. Legg til caching for hyppige forespørsler  
5. Utvikle overvåkingsdashbordet  
6. Test med ulike forespørselsmønstre  

**Teknologier:** Velg mellom Python (.NET/Java/Python etter eget valg), Redis for caching og et enkelt web-rammeverk for dashbordet.

### Prosjekt 2: Bedriftsstyringssystem for prompt

**Mål:** Utvikle et MCP-basert system for å administrere, versjonere og distribuere promptmaler på tvers av en organisasjon.

**Krav:**  
- Lag et sentralisert depot for promptmaler  
- Implementer versjonering og godkjenningsarbeidsflyter  
- Bygg testmuligheter for maler med eksempler på input  
- Utvikle rollebaserte tilgangskontroller  
- Lag en API for henting og distribusjon av maler  

**Implementeringstrinn:**  
1. Design databaseskjema for lagring av maler  
2. Lag kjerne-API for CRUD-operasjoner på maler  
3. Implementer versjonssystemet  
4. Bygg godkjenningsarbeidsflyten  
5. Utvikle test-rammeverket  
6. Lag et enkelt webgrensesnitt for administrasjon  
7. Integrer med en MCP-server  

**Teknologier:** Valgfritt backend-rammeverk, SQL eller NoSQL database, og frontend-rammeverk for administrasjonsgrensesnittet.

### Prosjekt 3: MCP-basert plattform for innholdsgenerering

**Mål:** Bygg en innholdsgenereringsplattform som bruker MCP for å levere konsistente resultater på tvers av ulike innholdstyper.

**Krav:**  
- Støtte flere innholdsformater (blogginnlegg, sosiale medier, markedsføringstekster)  
- Implementere malbasert generering med tilpasningsmuligheter  
- Lage et system for innholdsreview og tilbakemelding  
- Spore ytelsesmetrikker for innhold  
- Støtte versjonering og iterasjon av innhold  

**Implementeringstrinn:**  
1. Sett opp MCP-klientinfrastruktur  
2. Lag maler for ulike innholdstyper  
3. Bygg genereringspipelinjen  
4. Implementer review-systemet  
5. Utvikle system for metrikksporing  
6. Lag brukergrensesnitt for maladministrasjon og innholdsgenerering  

**Teknologier:** Valgt programmeringsspråk, web-rammeverk og databasesystem.

## Fremtidige Retninger for MCP-teknologi

### Nye Trender

1. **Multi-modalt MCP**  
   - Utvidelse av MCP for å standardisere interaksjoner med bilde-, lyd- og videomodeller  
   - Utvikling av tverrmodale resonneringsmuligheter  
   - Standardiserte promptformater for ulike modaliteter  

2. **Føderert MCP-infrastruktur**  
   - Distribuerte MCP-nettverk som kan dele ressurser på tvers av organisasjoner  
   - Standardiserte protokoller for sikker deling av modeller  
   - Personvernbevarende beregningsteknikker  

3. **MCP-markedsplasser**  
   - Økosystemer for deling og inntektsgenerering av MCP-maler og plugins  
   - Kvalitetssikring og sertifiseringsprosesser  
   - Integrasjon med modellmarkedsplasser  

4. **MCP for edge computing**  
   - Tilpasning av MCP-standarder for ressursbegrensede edge-enheter  
   - Optimaliserte protokoller for lavbåndbredde-miljøer  
   - Spesialiserte MCP-implementeringer for IoT-økosystemer  

5. **Regulatoriske rammeverk**  
   - Utvikling av MCP-utvidelser for regelverkssamsvar  
   - Standardiserte revisjonsspor og forklaringsgrensesnitt  
   - Integrasjon med fremvoksende AI-styringsrammeverk  

### MCP-løsninger fra Microsoft

Microsoft og Azure har utviklet flere åpne repositorier for å hjelpe utviklere med å implementere MCP i ulike scenarier:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – En Playwright MCP-server for nettleserautomatisering og testing  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – En OneDrive MCP-serverimplementering for lokal testing og fellesskapsbidrag  
3. [NLWeb](https://github.com/microsoft/NlWeb) – NLWeb er en samling åpne protokoller og tilhørende open source-verktøy med fokus på å etablere et fundament for AI Web  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) – Lenker til eksempler, verktøy og ressurser for å bygge og integrere MCP-servere på Azure med flere språk  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Referanse MCP-servere som demonstrerer autentisering med gjeldende Model Context Protocol-spesifikasjon  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Landingsside for Remote MCP Server-implementeringer i Azure Functions med lenker til språkspesifikke repos  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Hurtigstartmal for bygging og distribusjon av tilpassede Remote MCP-servere med Azure Functions i Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Hurtigstartmal for bygging og distribusjon av tilpassede Remote MCP-servere med Azure Functions i .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Hurtigstartmal for bygging og distribusjon av tilpassede Remote MCP-servere med Azure Functions i TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management som AI-gateway til Remote MCP-servere med Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – APIM ❤️ AI-eksperimenter inkludert MCP-funksjonalitet, integrert med Azure OpenAI og AI Foundry  

Disse repositoriene tilbyr ulike implementeringer, maler og ressurser for arbeid med Model Context Protocol på t
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

1. Analyser en av casestudiene og foreslå en alternativ implementeringsmetode.
2. Velg en av prosjektidéene og lag en detaljert teknisk spesifikasjon.
3. Undersøk en bransje som ikke er dekket i casestudiene, og skisser hvordan MCP kan løse dens spesifikke utfordringer.
4. Utforsk en av fremtidige retninger og lag et konsept for en ny MCP-utvidelse som støtter dette.

Neste: [Best Practices](../08-BestPractices/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på det opprinnelige språket bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår fra bruk av denne oversettelsen.