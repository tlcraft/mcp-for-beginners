<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T17:31:22+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "nl"
}
-->
# Lessen van vroege gebruikers

## Overzicht

Deze les onderzoekt hoe vroege gebruikers het Model Context Protocol (MCP) hebben ingezet om echte problemen op te lossen en innovatie in verschillende sectoren te stimuleren. Door middel van gedetailleerde casestudies en praktische projecten zie je hoe MCP gestandaardiseerde, veilige en schaalbare AI-integratie mogelijk maakt—door grote taalmodellen, tools en bedrijfsdata te verbinden binnen één uniform kader. Je krijgt praktische ervaring met het ontwerpen en bouwen van MCP-gebaseerde oplossingen, leert van bewezen implementatiepatronen en ontdekt best practices voor het uitrollen van MCP in productieomgevingen. De les belicht ook opkomende trends, toekomstige richtingen en open-source bronnen die je helpen voorop te blijven lopen in de ontwikkeling van MCP-technologie en het groeiende ecosysteem.

## Leerdoelen

- Analyseer MCP-implementaties uit de praktijk in verschillende sectoren  
- Ontwerp en bouw volledige MCP-gebaseerde applicaties  
- Verken opkomende trends en toekomstige ontwikkelingen in MCP-technologie  
- Pas best practices toe in echte ontwikkelscenario’s  

## MCP-implementaties uit de praktijk

### Casestudy 1: Automatisering van klantenservice in ondernemingen

Een multinational implementeerde een MCP-gebaseerde oplossing om AI-interacties binnen hun klantenservicesystemen te standaardiseren. Hierdoor konden ze:

- Eén uniforme interface creëren voor meerdere LLM-aanbieders  
- Consistent promptbeheer behouden over verschillende afdelingen  
- Robuuste beveiligings- en compliancecontroles implementeren  
- Gemakkelijk wisselen tussen verschillende AI-modellen op basis van specifieke behoeften  

**Technische implementatie:**  
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

**Resultaten:** 30% kostenreductie voor modellen, 45% verbetering in responsconsistentie en verbeterde naleving van regels binnen wereldwijde operaties.

### Casestudy 2: Diagnostische assistent in de gezondheidszorg

Een zorgverlener ontwikkelde een MCP-infrastructuur om meerdere gespecialiseerde medische AI-modellen te integreren, terwijl gevoelige patiëntgegevens beschermd bleven:

- Naadloos schakelen tussen algemene en specialistische medische modellen  
- Strikte privacycontroles en auditlogs  
- Integratie met bestaande Elektronische Patiënten Dossiers (EPD)  
- Consistente prompt engineering voor medische terminologie  

**Technische implementatie:**  
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

**Resultaten:** Verbeterde diagnostische suggesties voor artsen, volledige HIPAA-compliance en aanzienlijke vermindering van contextwisselingen tussen systemen.

### Casestudy 3: Risicoanalyse in financiële dienstverlening

Een financiële instelling gebruikte MCP om hun risicoanalyseprocessen over verschillende afdelingen te standaardiseren:

- Eén uniforme interface voor kredietrisico, fraude-detectie en investeringsrisicomodellen  
- Strikte toegangscontrole en versiebeheer van modellen  
- Zorgde voor auditbaarheid van alle AI-aanbevelingen  
- Consistente dataformattering over diverse systemen  

**Technische implementatie:**  
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

**Resultaten:** Verbeterde naleving van regelgeving, 40% snellere implementatiecycli van modellen en betere consistentie in risicobeoordelingen tussen afdelingen.

### Casestudy 4: Microsoft Playwright MCP-server voor browserautomatisering

Microsoft ontwikkelde de [Playwright MCP-server](https://github.com/microsoft/playwright-mcp) om veilige, gestandaardiseerde browserautomatisering mogelijk te maken via het Model Context Protocol. Deze oplossing stelt AI-agenten en LLM’s in staat om op een gecontroleerde, controleerbare en uitbreidbare manier met webbrowsers te communiceren—voor toepassingen zoals geautomatiseerd webtesten, data-extractie en end-to-end workflows.

- Biedt browserautomatiseringsmogelijkheden (navigatie, formulierinvoer, screenshot maken, etc.) aan als MCP-tools  
- Implementeert strikte toegangscontrole en sandboxing om onbevoegde acties te voorkomen  
- Levert gedetailleerde auditlogs van alle browserinteracties  
- Ondersteunt integratie met Azure OpenAI en andere LLM-aanbieders voor agentgestuurde automatisering  

**Technische implementatie:**  
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

**Resultaten:**  
- Mogelijkheid tot veilige, programmatische browserautomatisering voor AI-agenten en LLM’s  
- Verminderde handmatige testinspanning en verbeterde testdekking voor webapplicaties  
- Een herbruikbaar, uitbreidbaar framework voor browsergebaseerde toolintegratie in bedrijfsomgevingen  

**Referenties:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Casestudy 5: Azure MCP – Enterprise-grade Model Context Protocol als service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) is Microsofts beheerde, enterprise-grade implementatie van het Model Context Protocol, ontworpen om schaalbare, veilige en conforme MCP-serverfunctionaliteit als cloudservice te bieden. Azure MCP stelt organisaties in staat om snel MCP-servers te implementeren, beheren en integreren met Azure AI, data en beveiligingsdiensten, waardoor operationele lasten afnemen en AI-adoptie versnelt.

- Volledig beheerde hosting van MCP-servers met ingebouwde schaalbaarheid, monitoring en beveiliging  
- Natuurlijke integratie met Azure OpenAI, Azure AI Search en andere Azure-diensten  
- Enterprise-authenticatie en autorisatie via Microsoft Entra ID  
- Ondersteuning voor aangepaste tools, prompttemplates en resource connectors  
- Voldoet aan enterprise beveiligings- en regelgevingsvereisten  

**Technische implementatie:**  
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

**Resultaten:**  
- Verkorte time-to-value voor enterprise AI-projecten door een kant-en-klaar, compliant MCP-serverplatform te bieden  
- Vereenvoudigde integratie van LLM’s, tools en bedrijfsdatabronnen  
- Verbeterde beveiliging, observeerbaarheid en operationele efficiëntie voor MCP workloads  

**Referenties:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Casestudy 6: NLWeb

MCP (Model Context Protocol) is een opkomend protocol voor chatbots en AI-assistenten om met tools te communiceren. Elke NLWeb-instantie is ook een MCP-server die één kernmethode ondersteunt, ask, waarmee een website een vraag in natuurlijke taal kan worden gesteld. Het teruggegeven antwoord maakt gebruik van schema.org, een veelgebruikte vocabulaire voor het beschrijven van webdata. Vrij vertaald is MCP voor NLWeb wat HTTP is voor HTML. NLWeb combineert protocollen, Schema.org-formaten en voorbeeldcode om sites te helpen snel deze eindpunten te creëren, wat zowel mensen via conversatie-interfaces als machines via natuurlijke agent-tot-agent interactie ten goede komt.

NLWeb bestaat uit twee duidelijke componenten:  
- Een protocol, eenvoudig te beginnen, om via natuurlijke taal met een site te communiceren en een formaat dat json en schema.org gebruikt voor het antwoord. Zie de documentatie over de REST API voor meer details.  
- Een eenvoudige implementatie van (1) die bestaande markup benut, voor sites die kunnen worden geabstraheerd als lijsten met items (producten, recepten, attracties, recensies, etc.). Samen met een set gebruikersinterface-widgets kunnen sites gemakkelijk conversatie-interfaces voor hun content aanbieden. Zie de documentatie over Life of a chat query voor meer uitleg over de werking.  

**Referenties:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Casestudy 7: MCP voor Foundry – Integratie van Azure AI-agenten

Azure AI Foundry MCP-servers tonen aan hoe MCP gebruikt kan worden om AI-agenten en workflows in bedrijfsomgevingen te orkestreren en beheren. Door MCP te integreren met Azure AI Foundry kunnen organisaties agentinteracties standaardiseren, gebruikmaken van Foundry’s workflowbeheer en zorgen voor veilige, schaalbare implementaties. Deze aanpak maakt snelle prototyping, robuuste monitoring en naadloze integratie met Azure AI-diensten mogelijk, en ondersteunt geavanceerde scenario’s zoals kennisbeheer en agentevaluatie. Ontwikkelaars profiteren van een uniforme interface voor het bouwen, implementeren en monitoren van agentpijplijnen, terwijl IT-teams verbeterde beveiliging, compliance en operationele efficiëntie krijgen. De oplossing is ideaal voor bedrijven die AI-adoptie willen versnellen en controle willen houden over complexe agentgestuurde processen.

**Referenties:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Casestudy 8: Foundry MCP Playground – Experimenteren en prototypen

De Foundry MCP Playground biedt een kant-en-klare omgeving om te experimenteren met MCP-servers en Azure AI Foundry-integraties. Ontwikkelaars kunnen snel AI-modellen en agentworkflows prototypen, testen en evalueren met resources uit de Azure AI Foundry Catalog en Labs. De playground vereenvoudigt de setup, biedt voorbeeldprojecten en ondersteunt samenwerking, waardoor het makkelijk is best practices en nieuwe scenario’s te verkennen met minimale overhead. Het is vooral nuttig voor teams die ideeën willen valideren, experimenten willen delen en het leerproces willen versnellen zonder complexe infrastructuur. Door de instapdrempel te verlagen, stimuleert de playground innovatie en community-bijdragen binnen het MCP- en Azure AI Foundry-ecosysteem.

**Referenties:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Hands-on projecten

### Project 1: Bouw een MCP-server met meerdere providers

**Doel:** Maak een MCP-server die verzoeken kan routeren naar verschillende AI-modelproviders op basis van specifieke criteria.

**Vereisten:**  
- Ondersteuning voor minimaal drie verschillende modelproviders (bijv. OpenAI, Anthropic, lokale modellen)  
- Implementeer een routeringsmechanisme gebaseerd op metadata van verzoeken  
- Maak een configuratiesysteem voor het beheren van provider-credentials  
- Voeg caching toe om prestaties en kosten te optimaliseren  
- Bouw een eenvoudig dashboard voor het monitoren van gebruik  

**Stappen voor implementatie:**  
1. Zet de basisinfrastructuur van de MCP-server op  
2. Implementeer provider-adapters voor elke AI-modelservice  
3. Maak de routeringslogica op basis van verzoekattributen  
4. Voeg cachingmechanismen toe voor frequente verzoeken  
5. Ontwikkel het monitoringsdashboard  
6. Test met verschillende verzoekpatronen  

**Technologieën:** Kies uit Python (.NET/Java/Python naar voorkeur), Redis voor caching en een eenvoudig webframework voor het dashboard.

### Project 2: Enterprise Prompt Management System

**Doel:** Ontwikkel een MCP-gebaseerd systeem voor het beheren, versioneren en uitrollen van prompttemplates binnen een organisatie.

**Vereisten:**  
- Creëer een gecentraliseerde opslagplaats voor prompttemplates  
- Implementeer versiebeheer en goedkeuringsworkflows  
- Bouw testmogelijkheden voor templates met voorbeeldinputs  
- Ontwikkel rolgebaseerde toegangscontrole  
- Maak een API voor het ophalen en uitrollen van templates  

**Stappen voor implementatie:**  
1. Ontwerp het databaseschema voor templateopslag  
2. Maak de core API voor CRUD-operaties op templates  
3. Implementeer het versiebeheersysteem  
4. Bouw de goedkeuringsworkflow  
5. Ontwikkel het testframework  
6. Maak een eenvoudige webinterface voor beheer  
7. Integreer met een MCP-server  

**Technologieën:** Keuze van backendframework, SQL of NoSQL database, en een frontendframework voor de beheersinterface.

### Project 3: MCP-gebaseerd contentgeneratieplatform

**Doel:** Bouw een platform voor contentgeneratie dat MCP gebruikt om consistente resultaten te leveren voor verschillende contenttypes.

**Vereisten:**  
- Ondersteuning voor meerdere contentformaten (blogposts, social media, marketingteksten)  
- Implementeer template-gebaseerde generatie met aanpassingsmogelijkheden  
- Creëer een systeem voor contentreview en feedback  
- Volg prestatiegegevens van content  
- Ondersteun contentversiebeheer en iteratie  

**Stappen voor implementatie:**  
1. Zet de MCP-clientinfrastructuur op  
2. Maak templates voor verschillende contenttypes  
3. Bouw de contentgeneratiepijplijn  
4. Implementeer het reviewsysteem  
5. Ontwikkel het metrics tracking systeem  
6. Maak een gebruikersinterface voor templatebeheer en contentgeneratie  

**Technologieën:** Je favoriete programmeertaal, webframework en databasesysteem.

## Toekomstige richtingen voor MCP-technologie

### Opkomende trends

1. **Multi-modale MCP**  
   - Uitbreiding van MCP om interacties met beeld-, audio- en videomodellen te standaardiseren  
   - Ontwikkeling van cross-modale redeneercapaciteiten  
   - Gestandaardiseerde promptformaten voor verschillende modaliteiten  

2. **Federated MCP-infrastructuur**  
   - Gedistribueerde MCP-netwerken die middelen kunnen delen tussen organisaties  
   - Gestandaardiseerde protocollen voor veilige modeluitwisseling  
   - Privacybewarende rekenmethoden  

3. **MCP-marktplaatsen**  
   - Ecosystemen voor het delen en monetariseren van MCP-templates en plugins  
   - Kwaliteitsborging en certificeringsprocessen  
   - Integratie met modelmarktplaatsen  

4. **MCP voor edge computing**  
   - Aanpassing van MCP-standaarden voor apparaten met beperkte resources aan de edge  
   - Geoptimaliseerde protocollen voor omgevingen met lage bandbreedte  
   - Gespecialiseerde MCP-implementaties voor IoT-ecosystemen  

5. **Regelgevingskaders**  
   - Ontwikkeling van MCP-uitbreidingen voor naleving van regelgeving  
   - Gestandaardiseerde auditlogs en verklaringsinterfaces  
   - Integratie met opkomende AI-governancekaders  

### MCP-oplossingen van Microsoft

Microsoft en Azure hebben verschillende open-source repositories ontwikkeld om ontwikkelaars te helpen MCP in diverse scenario’s te implementeren:

#### Microsoft-organisatie  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Een Playwright MCP-server voor browserautomatisering en testen  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – Een OneDrive MCP-serverimplementatie voor lokaal testen en communitybijdragen  
3. [NLWeb](https://github.com/microsoft/NlWeb) – NLWeb is een verzameling open protocollen en bijbehorende open-source tools, gericht op het leggen van een fundamentele laag voor het AI-web  

#### Azure-Samples organisatie  
1. [mcp](https://github.com/Azure-Samples/mcp) – Links naar voorbeelden, tools en resources voor het bouwen en integreren van MCP-servers op Azure in verschillende talen  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Referentie MCP-servers die authenticatie demonstreren volgens de huidige Model Context Protocol-specificatie  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Startpagina voor Remote MCP-serverimplementaties in Azure Functions met links naar taalspecifieke repositories  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Quickstart-template voor het bouwen en uitrollen van aangepaste remote MCP-servers met Azure Functions in Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Quickstart-template voor het bouwen en uitrollen van aangepaste remote MCP-servers met Azure Functions in .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Quickstart-template voor het bouwen en uitrollen van aangepaste remote MCP-servers met Azure Functions in TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management als AI Gateway naar Remote MCP-servers met Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – APIM ❤️ AI-experimenten inclusief MCP-functionaliteiten, integratie met Azure OpenAI en AI Foundry  

Deze repositories bieden diverse implementaties, templates en resources voor het werken met het Model Context Protocol in verschillende programmeertalen en Azure-diensten. Ze bestrijken uiteenlopende use cases van basisserverimplementaties tot authenticatie, clouddeployment en enterprise-integraties.

#### MCP Resources Directory

De [MCP Resources directory](https://github.com/microsoft/mcp/tree/main/Resources) in de officiële Microsoft MCP-repository bevat een samengestelde verzameling voorbeeldresources, prompttemplates en tooldefinities voor gebruik met Model Context Protocol-servers. Deze directory helpt ontwikkelaars snel aan de slag te gaan met MCP door herbruikbare bouwstenen en best-practice voorbeelden te bieden voor:

- **Prompt Templates:** Klaar-voor-gebruik prompttemplates voor veelvoorkomende AI-taken en scenario’s, aanpasbaar voor eigen MCP-serverimplementaties  
- **Tool Definitions:** Voorbeeldschemas en metadata om toolintegratie en aanroep te standaardiseren over verschillende MCP-servers  
- **Resource Samples:** Voorbeelden van resource-definities voor verbinding met databronnen, API’s en externe diensten binnen het MCP-kader  
- **Reference Implementations:** Praktische voorbeelden die laten zien hoe resources, prompts en tools gestructureerd en georganiseerd kunnen worden in echte MCP-projecten  

Deze bronnen versnellen ontwikkeling, bevorderen standaardisatie en helpen best practices te waarborgen bij het bouwen en uitrollen van MCP-gebaseerde oplossingen.

#### MCP Resources Directory  
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Onderzoeksmogelijkheden

- Efficiënte promptoptimalisatietechnieken binnen MCP-frameworks  
- Beveiligingsmodellen voor multi-tenant MCP-implementaties  
- Prestatiebenchmarks van verschillende MCP-implementaties  
- Formele verificatiemethoden voor MCP-servers  

## Conclusie

Het Model Context Protocol (MCP) vormt snel de toekomst van gestandaardiseerde, veilige en interoperabele AI-integratie in diverse sectoren. Door de casestudies en hands-on projecten in deze les heb je gezien hoe vroege gebruikers—waaronder Microsoft en Azure—MCP inzetten om echte problemen op te lossen, AI-adoptie te
- [Azure MCP Documentatie](https://aka.ms/azmcp)
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

## Oefeningen

1. Analyseer een van de casestudy's en stel een alternatieve implementatie-aanpak voor.
2. Kies een van de projectideeën en maak een gedetailleerde technische specificatie.
3. Onderzoek een sector die niet behandeld wordt in de casestudy's en schets hoe MCP de specifieke uitdagingen ervan kan aanpakken.
4. Verken een van de toekomstige richtingen en ontwikkel een concept voor een nieuwe MCP-extensie om deze te ondersteunen.

Volgende: [Best Practices](../08-BestPractices/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.