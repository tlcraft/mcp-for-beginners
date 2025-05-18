<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:26:16+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "nl"
}
-->
# Lessen van Vroege Adoptanten

## Overzicht

Deze les onderzoekt hoe vroege adoptanten het Model Context Protocol (MCP) hebben benut om echte uitdagingen op te lossen en innovatie in verschillende industrieën te stimuleren. Door middel van gedetailleerde casestudies en praktische projecten zie je hoe MCP gestandaardiseerde, veilige en schaalbare AI-integratie mogelijk maakt—door grote taalmodellen, tools en bedrijfsdata in een verenigd kader te verbinden. Je krijgt praktische ervaring in het ontwerpen en bouwen van op MCP gebaseerde oplossingen, leert van bewezen implementatiepatronen en ontdekt best practices voor het inzetten van MCP in productieomgevingen. De les benadrukt ook opkomende trends, toekomstige richtingen en open-source bronnen om je te helpen aan de top van MCP-technologie en het zich ontwikkelende ecosysteem te blijven.

## Leerdoelen

- Analyseer echte MCP-implementaties in verschillende industrieën
- Ontwerp en bouw complete op MCP gebaseerde applicaties
- Onderzoek opkomende trends en toekomstige richtingen in MCP-technologie
- Pas best practices toe in daadwerkelijke ontwikkelscenario's

## Echte MCP-implementaties

### Casestudy 1: Automatisering van Klantenservice voor Ondernemingen

Een multinationale onderneming implementeerde een op MCP gebaseerde oplossing om AI-interacties te standaardiseren binnen hun klantenservicesystemen. Dit stelde hen in staat om:

- Een uniforme interface te creëren voor meerdere LLM-providers
- Consistente promptbeheer te handhaven binnen afdelingen
- Robuuste beveiligings- en nalevingscontroles te implementeren
- Eenvoudig te schakelen tussen verschillende AI-modellen op basis van specifieke behoeften

**Technische Implementatie:**
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

**Resultaten:** 30% vermindering in modelkosten, 45% verbetering in consistentie van reacties, en verbeterde naleving wereldwijd.

### Casestudy 2: Diagnostische Assistent voor de Gezondheidszorg

Een zorgverlener ontwikkelde een MCP-infrastructuur om meerdere gespecialiseerde medische AI-modellen te integreren, terwijl gevoelige patiëntgegevens beschermd bleven:

- Naadloos schakelen tussen algemene en specialistische medische modellen
- Strikte privacycontroles en audit trails
- Integratie met bestaande Elektronische Gezondheidsdossiers (EHR) systemen
- Consistente promptengineering voor medische terminologie

**Technische Implementatie:**
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

**Resultaten:** Verbeterde diagnostische suggesties voor artsen terwijl volledige HIPAA-naleving werd gehandhaafd en significante vermindering in contextwisseling tussen systemen.

### Casestudy 3: Risicoanalyse in Financiële Diensten

Een financiële instelling implementeerde MCP om hun risicoanalyseprocessen te standaardiseren binnen verschillende afdelingen:

- Een uniforme interface gecreëerd voor kredietrisico-, fraudedetectie- en investeringsrisicomodellen
- Strikte toegangscontroles en modelversiebeheer geïmplementeerd
- Auditbaarheid van alle AI-aanbevelingen gewaarborgd
- Consistente gegevensformatering gehandhaafd binnen diverse systemen

**Technische Implementatie:**
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

**Resultaten:** Verbeterde naleving van regelgeving, 40% snellere modelimplementatiecycli, en verbeterde consistentie van risicoanalyse binnen afdelingen.

### Casestudy 4: Microsoft Playwright MCP Server voor Browserautomatisering

Microsoft ontwikkelde de [Playwright MCP server](https://github.com/microsoft/playwright-mcp) om veilige, gestandaardiseerde browserautomatisering mogelijk te maken via het Model Context Protocol. Deze oplossing stelt AI-agenten en LLM's in staat om op een gecontroleerde, auditbare en uitbreidbare manier met webbrowsers te communiceren—mogelijk makend voor gebruiksscenario's zoals geautomatiseerd webtesten, gegevensextractie en end-to-end workflows.

- Biedt browserautomatiseringsmogelijkheden (navigatie, formulierinvulling, schermafbeeldingen, enz.) als MCP-tools
- Implementeert strikte toegangscontroles en sandboxing om ongeautoriseerde acties te voorkomen
- Biedt gedetailleerde auditlogs voor alle browserinteracties
- Ondersteunt integratie met Azure OpenAI en andere LLM-providers voor agentgestuurde automatisering

**Technische Implementatie:**
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
- Veilige, programmatische browserautomatisering mogelijk gemaakt voor AI-agenten en LLM's
- Verminderde handmatige testinspanning en verbeterde testdekking voor webapplicaties
- Een herbruikbaar, uitbreidbaar kader geboden voor integratie van browsergebaseerde tools in bedrijfsomgevingen

**Referenties:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Microsoft AI en Automatiseringsoplossingen](https://azure.microsoft.com/en-us/products/ai-services/)

### Casestudy 5: Azure MCP – Enterprise-Grade Model Context Protocol als een Service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) is Microsoft’s beheerde, enterprise-grade implementatie van het Model Context Protocol, ontworpen om schaalbare, veilige en conforme MCP-servercapaciteiten als een clouddienst te bieden. Azure MCP stelt organisaties in staat om snel MCP-servers te implementeren, beheren en integreren met Azure AI-, data- en beveiligingsdiensten, waardoor operationele overhead wordt verminderd en AI-adoptie wordt versneld.

- Volledig beheerde MCP-serverhosting met ingebouwde schaalbaarheid, monitoring en beveiliging
- Native integratie met Azure OpenAI, Azure AI Search en andere Azure-diensten
- Enterprise-authenticatie en -autorisatie via Microsoft Entra ID
- Ondersteuning voor aangepaste tools, prompttemplates en resourceconnectors
- Naleving van bedrijfsbeveiliging en regelgevingsvereisten

**Technische Implementatie:**
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
- Verminderde time-to-value voor enterprise AI-projecten door een kant-en-klare, conforme MCP-serverplatform te bieden
- Vereenvoudigde integratie van LLM's, tools en bedrijfsdatabronnen
- Verbeterde beveiliging, zichtbaarheid en operationele efficiëntie voor MCP-werkbelastingen

**Referenties:**  
- [Azure MCP Documentatie](https://aka.ms/azmcp)
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Praktische Projecten

### Project 1: Bouw een Multi-Provider MCP Server

**Doelstelling:** Creëer een MCP-server die verzoeken kan routeren naar meerdere AI-modelproviders op basis van specifieke criteria.

**Vereisten:**
- Ondersteun ten minste drie verschillende modelproviders (bijv. OpenAI, Anthropic, lokale modellen)
- Implementeer een routeringsmechanisme op basis van verzoekmetadata
- Maak een configuratiesysteem voor het beheren van providerreferenties
- Voeg caching toe om prestaties en kosten te optimaliseren
- Bouw een eenvoudig dashboard voor het monitoren van gebruik

**Implementatiestappen:**
1. Stel de basis MCP-serverinfrastructuur in
2. Implementeer provideradapters voor elke AI-modelservice
3. Creëer de routeringslogica op basis van verzoekkenmerken
4. Voeg cachingmechanismen toe voor frequente verzoeken
5. Ontwikkel het monitoringsdashboard
6. Test met verschillende verzoekpatronen

**Technologieën:** Kies uit Python (.NET/Java/Python gebaseerd op je voorkeur), Redis voor caching, en een eenvoudig webframework voor het dashboard.

### Project 2: Enterprise Prompt Management Systeem

**Doelstelling:** Ontwikkel een op MCP gebaseerd systeem voor het beheren, versiebeheer en implementeren van prompttemplates binnen een organisatie.

**Vereisten:**
- Maak een gecentraliseerde repository voor prompttemplates
- Implementeer versiebeheer en goedkeuringsworkflows
- Bouw template testmogelijkheden met voorbeeldinvoer
- Ontwikkel rolgebaseerde toegangscontroles
- Creëer een API voor template-opvraging en implementatie

**Implementatiestappen:**
1. Ontwerp het databaseschema voor templatestorage
2. Creëer de core API voor template CRUD-operaties
3. Implementeer het versiebeheersysteem
4. Bouw de goedkeuringsworkflow
5. Ontwikkel het testframework
6. Creëer een eenvoudige webinterface voor beheer
7. Integreer met een MCP-server

**Technologieën:** Je keuze van backend framework, SQL of NoSQL database, en een frontend framework voor de beheerinterface.

### Project 3: Op MCP Gebaseerd Contentgeneratie Platform

**Doelstelling:** Bouw een contentgeneratieplatform dat MCP benut om consistente resultaten te bieden voor verschillende contenttypen.

**Vereisten:**
- Ondersteun meerdere contentformaten (blogposts, sociale media, marketingtekst)
- Implementeer template-gebaseerde generatie met aanpassingsopties
- Creëer een content review- en feedbacksysteem
- Volg contentprestatiemetrics
- Ondersteun contentversiebeheer en iteratie

**Implementatiestappen:**
1. Stel de MCP-clientinfrastructuur in
2. Creëer templates voor verschillende contenttypen
3. Bouw de contentgeneratiepijplijn
4. Implementeer het reviewsysteem
5. Ontwikkel het metrics volgsysteem
6. Creëer een gebruikersinterface voor templatebeheer en contentgeneratie

**Technologieën:** Je voorkeursprogrammeertaal, webframework, en databasesysteem.

## Toekomstige Richtingen voor MCP Technologie

### Opkomende Trends

1. **Multi-Modale MCP**
   - Uitbreiding van MCP om interacties met beeld-, audio- en videomodellen te standaardiseren
   - Ontwikkeling van cross-modale redeneercapaciteiten
   - Gestandaardiseerde promptformaten voor verschillende modaliteiten

2. **Federated MCP Infrastructuur**
   - Gedistribueerde MCP-netwerken die middelen kunnen delen tussen organisaties
   - Gestandaardiseerde protocollen voor veilige modeldeling
   - Privacybehoudende computatietechnieken

3. **MCP Marktplaatsen**
   - Ecosystemen voor het delen en monetiseren van MCP-templates en plugins
   - Kwaliteitsborging en certificeringsprocessen
   - Integratie met modelmarktplaatsen

4. **MCP voor Edge Computing**
   - Aanpassing van MCP-standaarden voor hulpbronbeperkte edge-apparaten
   - Geoptimaliseerde protocollen voor omgevingen met lage bandbreedte
   - Gespecialiseerde MCP-implementaties voor IoT-ecosystemen

5. **Regelgevingskaders**
   - Ontwikkeling van MCP-extensies voor naleving van regelgeving
   - Gestandaardiseerde audit trails en uitlegbaarheidsinterfaces
   - Integratie met opkomende AI-governance frameworks

### MCP Oplossingen van Microsoft 

Microsoft en Azure hebben verschillende open-source repositories ontwikkeld om ontwikkelaars te helpen MCP in verschillende scenario's te implementeren:

#### Microsoft Organisatie
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Een Playwright MCP-server voor browserautomatisering en testen
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Een OneDrive MCP-serverimplementatie voor lokale tests en communitybijdrage

#### Azure-Samples Organisatie
1. [mcp](https://github.com/Azure-Samples/mcp) - Links naar voorbeelden, tools en bronnen voor het bouwen en integreren van MCP-servers op Azure met meerdere talen
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Referentie MCP-servers die authenticatie demonstreren met de huidige Model Context Protocol-specificatie
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Landingspagina voor Remote MCP Server-implementaties in Azure Functions met links naar taal-specifieke repos
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Quickstart template voor het bouwen en implementeren van aangepaste remote MCP-servers met Azure Functions met Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Quickstart template voor het bouwen en implementeren van aangepaste remote MCP-servers met Azure Functions met .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Quickstart template voor het bouwen en implementeren van aangepaste remote MCP-servers met Azure Functions met TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management als AI Gateway naar Remote MCP-servers met Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI-experimenten inclusief MCP-capaciteiten, integratie met Azure OpenAI en AI Foundry

Deze repositories bieden verschillende implementaties, templates en bronnen voor het werken met het Model Context Protocol in verschillende programmeertalen en Azure-diensten. Ze dekken een reeks gebruiksscenario's van basisserverimplementaties tot authenticatie, clouduitrol en enterprise-integratiescenario's.

#### MCP Resources Directory

De [MCP Resources directory](https://github.com/microsoft/mcp/tree/main/Resources) in de officiële Microsoft MCP-repository biedt een zorgvuldig samengestelde verzameling voorbeeldbronnen, prompttemplates en tooldefinities voor gebruik met Model Context Protocol-servers. Deze directory is ontworpen om ontwikkelaars snel aan de slag te helpen met MCP door herbruikbare bouwstenen en best-practice voorbeelden te bieden voor:

- **Prompt Templates:** Kant-en-klare prompttemplates voor veelvoorkomende AI-taken en scenario's, die kunnen worden aangepast voor je eigen MCP-serverimplementaties.
- **Tool Definitions:** Voorbeeldtoolschema's en metadata om toolintegratie en -aanroep te standaardiseren binnen verschillende MCP-servers.
- **Resource Samples:** Voorbeeldresource-definities voor het verbinden met dat bronnen, API's en externe diensten binnen het MCP-kader.
- **Reference Implementations:** Praktische voorbeelden die laten zien hoe resources, prompts en tools gestructureerd en georganiseerd kunnen worden in echte MCP-projecten.

Deze bronnen versnellen de ontwikkeling, bevorderen standaardisatie en helpen best practices te waarborgen bij het bouwen en implementeren van op MCP gebaseerde oplossingen.

#### MCP Resources Directory
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Onderzoeksmogelijkheden

- Efficiënte promptoptimalisatietechnieken binnen MCP-kaders
- Beveiligingsmodellen voor multi-tenant MCP-implementaties
- Prestatiebenchmarking tussen verschillende MCP-implementaties
- Formele verificatiemethoden voor MCP-servers

## Conclusie

Het Model Context Protocol (MCP) vormt snel de toekomst van gestandaardiseerde, veilige en interoperabele AI-integratie in verschillende industrieën. Door de casestudies en praktische projecten in deze les heb je gezien hoe vroege adoptanten—waaronder Microsoft en Azure—MCP benutten om echte uitdagingen op te lossen, AI-adoptie te versnellen en naleving, beveiliging en schaalbaarheid te waarborgen. MCP's modulaire aanpak stelt organisaties in staat om grote taalmodellen, tools en bedrijfsdata in een verenigd, auditbaar kader te verbinden. Terwijl MCP blijft evolueren, zal betrokken blijven bij de gemeenschap, open-source bronnen verkennen en best practices toepassen cruciaal zijn voor het bouwen van robuuste, toekomstbestendige AI-oplossingen.

## Aanvullende Bronnen

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
- [Microsoft AI en Automatiseringsoplossingen](https://azure.microsoft.com/en-us/products/ai-services/)

## Oefeningen

1. Analyseer een van de casestudy's en stel een alternatieve implementatiebenadering voor.
2. Kies een van de projectideeën en maak een gedetailleerde technische specificatie.
3. Onderzoek een industrie die niet in de casestudy's is behandeld en schets hoe MCP zijn specifieke uitdagingen zou kunnen aanpakken.
4. Verken een van de toekomstige richtingen en maak een concept voor een nieuwe MCP-extensie om deze te ondersteunen.

Volgende: [Best Practices](../08-BestPractices/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons best doen voor nauwkeurigheid, willen we u erop wijzen dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. We zijn niet aansprakelijk voor misverstanden of misinterpretaties die voortvloeien uit het gebruik van deze vertaling.