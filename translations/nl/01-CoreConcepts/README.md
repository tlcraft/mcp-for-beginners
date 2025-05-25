<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T21:55:20+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "nl"
}
-->
# 📖 MCP Kernconcepten: Beheersing van het Model Context Protocol voor AI-integratie

Het Model Context Protocol (MCP) is een krachtig, gestandaardiseerd raamwerk dat de communicatie tussen Large Language Models (LLM's) en externe tools, applicaties en databronnen optimaliseert. Deze SEO-geoptimaliseerde gids leidt je door de kernconcepten van MCP, zodat je de client-serverarchitectuur, essentiële componenten, communicatiemechanismen en beste implementatiepraktijken begrijpt.

## Overzicht

Deze les behandelt de fundamentele architectuur en componenten die het Model Context Protocol (MCP) ecosysteem vormen. Je leert over de client-serverarchitectuur, de belangrijkste componenten en de communicatiemechanismen die MCP-interacties mogelijk maken.

## 👩‍🎓 Belangrijkste Leerdoelen

Aan het einde van deze les:

- Begrijp je de MCP client-serverarchitectuur.
- Kun je de rollen en verantwoordelijkheden van Hosts, Clients en Servers identificeren.
- Analyseer je de kernkenmerken die MCP een flexibele integratielaag maken.
- Leer je hoe informatie binnen het MCP-ecosysteem stroomt.
- Krijg je praktische inzichten via codevoorbeelden in .NET, Java, Python en JavaScript.

## 🔎 MCP Architectuur: Een Diepere Kijk

Het MCP-ecosysteem is opgebouwd rond een client-servermodel. Deze modulaire structuur maakt het mogelijk dat AI-toepassingen efficiënt communiceren met tools, databases, API’s en contextuele bronnen. Laten we deze architectuur opdelen in de kerncomponenten.

### 1. Hosts

Binnen het Model Context Protocol (MCP) spelen Hosts een cruciale rol als de primaire interface waarmee gebruikers met het protocol communiceren. Hosts zijn applicaties of omgevingen die verbinding maken met MCP-servers om toegang te krijgen tot data, tools en prompts. Voorbeelden van Hosts zijn geïntegreerde ontwikkelomgevingen (IDEs) zoals Visual Studio Code, AI-tools zoals Claude Desktop, of op maat gemaakte agents voor specifieke taken.

**Hosts** zijn LLM-applicaties die verbindingen initiëren. Ze:

- Voeren AI-modellen uit of interageren ermee om antwoorden te genereren.
- Starten verbindingen met MCP-servers.
- Beheren het gesprek en de gebruikersinterface.
- Controleren permissies en beveiligingsbeperkingen.
- Verwerken gebruikersconsent voor datadeling en tooluitvoering.

### 2. Clients

Clients zijn essentiële componenten die de interactie tussen Hosts en MCP-servers faciliteren. Ze fungeren als tussenpersonen, waardoor Hosts toegang krijgen tot de functionaliteiten van MCP-servers. Ze zorgen voor soepele communicatie en efficiënte gegevensuitwisseling binnen de MCP-architectuur.

**Clients** zijn connectors binnen de hostapplicatie. Ze:

- Versturen verzoeken naar servers met prompts/instructies.
- Onderhandelen over mogelijkheden met servers.
- Beheren tooluitvoeringsverzoeken vanuit modellen.
- Verwerken en tonen antwoorden aan gebruikers.

### 3. Servers

Servers zijn verantwoordelijk voor het afhandelen van verzoeken van MCP-clients en het leveren van passende antwoorden. Ze beheren diverse operaties zoals data-opvraging, tooluitvoering en promptgeneratie. Servers zorgen ervoor dat de communicatie tussen clients en Hosts efficiënt en betrouwbaar verloopt, waarbij de integriteit van het interactieproces behouden blijft.

**Servers** zijn diensten die context en mogelijkheden bieden. Ze:

- Registreren beschikbare functies (resources, prompts, tools).
- Ontvangen en voeren toolaanroepen van de client uit.
- Bieden contextuele informatie om modelantwoorden te verbeteren.
- Sturen outputs terug naar de client.
- Beheren de status over interacties heen indien nodig.

Servers kunnen door iedereen worden ontwikkeld om modelmogelijkheden uit te breiden met gespecialiseerde functionaliteit.

### 4. Server Features

Servers binnen het Model Context Protocol (MCP) bieden fundamentele bouwstenen die rijke interacties tussen clients, hosts en taalmodellen mogelijk maken. Deze features zijn ontworpen om de capaciteiten van MCP te vergroten door gestructureerde context, tools en prompts aan te bieden.

MCP-servers kunnen een of meer van de volgende features bieden:

#### 📑 Resources

Resources binnen het Model Context Protocol (MCP) omvatten diverse soorten context en data die door gebruikers of AI-modellen kunnen worden gebruikt. Dit zijn onder andere:

- **Contextuele Data**: Informatie en context die gebruikers of AI-modellen kunnen inzetten voor besluitvorming en taakuitvoering.
- **Kennisbanken en Documentenrepositories**: Verzameling van gestructureerde en ongestructureerde data, zoals artikelen, handleidingen en onderzoeksrapporten, die waardevolle inzichten bieden.
- **Lokale Bestanden en Databases**: Data die lokaal op apparaten of binnen databases is opgeslagen, toegankelijk voor verwerking en analyse.
- **API’s en Webservices**: Externe interfaces en diensten die extra data en functionaliteiten bieden, waardoor integratie met diverse online bronnen en tools mogelijk is.

Een voorbeeld van een resource kan een databaseschema of een bestand zijn dat op deze manier benaderd kan worden:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts binnen het Model Context Protocol (MCP) omvatten verschillende vooraf gedefinieerde sjablonen en interactiepatronen die workflows stroomlijnen en communicatie verbeteren. Dit zijn onder andere:

- **Vooraf gestructureerde Berichten en Workflows**: Vooraf opgezette berichten en processen die gebruikers begeleiden bij specifieke taken en interacties.
- **Vooraf gedefinieerde Interactiepatronen**: Gestandaardiseerde reeksen acties en reacties die consistente en efficiënte communicatie bevorderen.
- **Gespecialiseerde Gesprekssjablonen**: Aanpasbare sjablonen gericht op specifieke soorten gesprekken, die relevante en contextueel passende interacties waarborgen.

Een prompttemplate kan er als volgt uitzien:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Tools binnen het Model Context Protocol (MCP) zijn functies die het AI-model kan uitvoeren om specifieke taken uit te voeren. Deze tools zijn ontworpen om de mogelijkheden van het AI-model uit te breiden door gestructureerde en betrouwbare operaties aan te bieden. Belangrijke aspecten zijn:

- **Functies die het AI-model kan uitvoeren**: Tools zijn uitvoerbare functies die het AI-model kan aanroepen om diverse taken te volbrengen.
- **Unieke Naam en Beschrijving**: Elke tool heeft een unieke naam en een gedetailleerde beschrijving die het doel en de functionaliteit uitlegt.
- **Parameters en Outputs**: Tools accepteren specifieke parameters en geven gestructureerde resultaten terug, wat zorgt voor consistente en voorspelbare uitkomsten.
- **Discrete Functies**: Tools voeren afzonderlijke functies uit, zoals web searches, berekeningen en databasequeries.

Een voorbeeld van een tool kan er zo uitzien:

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Client Features

In het Model Context Protocol (MCP) bieden clients verschillende belangrijke features aan servers, waarmee de algehele functionaliteit en interactie binnen het protocol worden verbeterd. Een van de opvallende features is Sampling.

### 👉 Sampling

- **Server-geïnitieerde Agentgedragingen**: Clients maken het mogelijk dat servers specifieke acties of gedragingen autonoom starten, wat de dynamische mogelijkheden van het systeem vergroot.
- **Recursieve LLM-interacties**: Deze feature maakt recursieve interacties met grote taalmodellen (LLM's) mogelijk, waardoor complexere en iteratieve taakverwerking wordt ondersteund.
- **Aanvragen van Extra Modelcompleties**: Servers kunnen aanvullende voltooingen van het model opvragen, zodat de antwoorden grondig en contextueel relevant zijn.

## Informatiestroom in MCP

Het Model Context Protocol (MCP) definieert een gestructureerde informatiestroom tussen hosts, clients, servers en modellen. Het begrijpen van deze stroom helpt om te zien hoe gebruikersverzoeken worden verwerkt en hoe externe tools en data in modelantwoorden worden geïntegreerd.

- **Host Initieert Verbinding**  
  De hostapplicatie (zoals een IDE of chatinterface) maakt verbinding met een MCP-server, meestal via STDIO, WebSocket of een andere ondersteunde transportlaag.

- **Mogelijkheden Onderhandelen**  
  De client (ingebed in de host) en de server wisselen informatie uit over hun ondersteunde features, tools, resources en protocolversies. Zo begrijpen beide partijen welke mogelijkheden beschikbaar zijn voor de sessie.

- **Gebruikersverzoek**  
  De gebruiker communiceert met de host (bijvoorbeeld door een prompt of commando in te voeren). De host verzamelt deze input en geeft deze door aan de client voor verwerking.

- **Gebruik van Resource of Tool**  
  - De client kan extra context of resources opvragen bij de server (zoals bestanden, database-items of kennisbankartikelen) om het begrip van het model te verrijken.  
  - Als het model bepaalt dat een tool nodig is (bijvoorbeeld om data op te halen, een berekening te maken of een API aan te roepen), stuurt de client een tool-aanroepverzoek naar de server, met de naam van de tool en de parameters.

- **Server Uitvoering**  
  De server ontvangt het resource- of toolverzoek, voert de benodigde operaties uit (zoals een functie aanroepen, database query uitvoeren of bestand ophalen) en retourneert de resultaten aan de client in een gestructureerd formaat.

- **Genereren van Antwoord**  
  De client integreert de antwoorden van de server (resource data, tool outputs, etc.) in de lopende modelinteractie. Het model gebruikt deze informatie om een uitgebreid en contextueel passend antwoord te genereren.

- **Resultaatpresentatie**  
  De host ontvangt de uiteindelijke output van de client en toont deze aan de gebruiker, vaak inclusief zowel de gegenereerde tekst van het model als eventuele resultaten van tooluitvoeringen of resource-opzoekingen.

Deze stroom maakt het mogelijk dat MCP geavanceerde, interactieve en contextbewuste AI-toepassingen ondersteunt door modellen naadloos te verbinden met externe tools en databronnen.

## Protocol Details

MCP (Model Context Protocol) is gebouwd bovenop [JSON-RPC 2.0](https://www.jsonrpc.org/), wat een gestandaardiseerd, taal-onafhankelijk berichtformaat biedt voor communicatie tussen hosts, clients en servers. Deze basis maakt betrouwbare, gestructureerde en uitbreidbare interacties over verschillende platforms en programmeertalen mogelijk.

### Belangrijke Protocol Features

MCP breidt JSON-RPC 2.0 uit met extra conventies voor toolaanroepen, resource-toegang en promptbeheer. Het ondersteunt meerdere transportlagen (STDIO, WebSocket, SSE) en maakt veilige, uitbreidbare en taal-onafhankelijke communicatie tussen componenten mogelijk.

#### 🧢 Basisprotocol

- **JSON-RPC Berichtformaat**: Alle verzoeken en antwoorden gebruiken de JSON-RPC 2.0-specificatie, wat zorgt voor een consistente structuur voor method calls, parameters, resultaten en foutafhandeling.
- **Stateful Verbindingen**: MCP-sessies behouden status over meerdere verzoeken, wat voortdurende gesprekken, contextopbouw en resourcebeheer ondersteunt.
- **Mogelijkheden Onderhandeling**: Tijdens het opzetten van de verbinding wisselen clients en servers informatie uit over ondersteunde features, protocolversies, beschikbare tools en resources. Zo begrijpen beide partijen elkaars mogelijkheden en kunnen ze zich aanpassen.

#### ➕ Extra Hulpmiddelen

Hieronder enkele extra hulpmiddelen en protocoluitbreidingen die MCP biedt om de ontwikkelaarservaring te verbeteren en geavanceerde scenario’s mogelijk te maken:

- **Configuratieopties**: MCP maakt dynamische configuratie van sessieparameters mogelijk, zoals toolpermissies, resource-toegang en modelinstellingen, afgestemd op elke interactie.
- **Voortgangsbewaking**: Langdurige operaties kunnen voortgangsupdates geven, wat zorgt voor responsieve gebruikersinterfaces en een betere gebruikerservaring tijdens complexe taken.
- **Annuleren van Verzoeken**: Clients kunnen lopende verzoeken annuleren, zodat gebruikers operaties kunnen stoppen die niet langer nodig zijn of te lang duren.
- **Foutmelding**: Gestandaardiseerde foutberichten en codes helpen bij het diagnosticeren van problemen, het netjes afhandelen van fouten en het bieden van bruikbare feedback aan gebruikers en ontwikkelaars.
- **Logging**: Zowel clients als servers kunnen gestructureerde logs genereren voor auditing, debugging en monitoring van protocolinteracties.

Door gebruik te maken van deze protocolfeatures zorgt MCP voor robuuste, veilige en flexibele communicatie tussen taalmodellen en externe tools of databronnen.

### 🔐 Beveiligingsoverwegingen

MCP-implementaties dienen enkele belangrijke beveiligingsprincipes te volgen om veilige en betrouwbare interacties te garanderen:

- **Gebruikersconsent en Controle**: Gebruikers moeten expliciete toestemming geven voordat data wordt benaderd of acties worden uitgevoerd. Ze moeten duidelijke controle hebben over welke data wordt gedeeld en welke handelingen zijn toegestaan, ondersteund door intuïtieve gebruikersinterfaces voor het beoordelen en goedkeuren van activiteiten.

- **Dataprivacy**: Gebruikersdata mag alleen worden blootgesteld met expliciete toestemming en moet worden beschermd met passende toegangscontrole. MCP-implementaties moeten onbevoegde datatransmissie voorkomen en waarborgen dat privacy tijdens alle interacties wordt gehandhaafd.

- **Toolveiligheid**: Voor het aanroepen van een tool is expliciete gebruikersconsent vereist. Gebruikers moeten duidelijk begrijpen wat elke tool doet, en er moeten robuuste beveiligingsgrenzen zijn om onbedoelde of onveilige tooluitvoering te voorkomen.

Door deze principes te volgen, zorgt MCP ervoor dat gebruikersvertrouwen, privacy en veiligheid behouden blijven bij alle protocolinteracties.

## Codevoorbeelden: Kerncomponenten

Hieronder vind je codevoorbeelden in verschillende populaire programmeertalen die laten zien hoe je belangrijke MCP-servercomponenten en tools kunt implementeren.

### .NET Voorbeeld: Een Eenvoudige MCP Server met Tools

Een praktisch .NET-voorbeeld dat laat zien hoe je een eenvoudige MCP-server met aangepaste tools implementeert. Dit voorbeeld toont hoe je tools definieert en registreert, verzoeken afhandelt en de server verbindt via het Model Context Protocol.

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### Java Voorbeeld: MCP Servercomponenten

Dit voorbeeld toont dezelfde MCP-server en toolregistratie als het .NET-voorbeeld hierboven, maar dan geïmplementeerd in Java.

```java
import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Weather MCP Server")
            .version("1.0.0")
            .build();
            
        // Register a weather tool
        server.registerTool(McpToolDefinition.builder("weatherTool")
            .description("Gets current weather for a location")
            .parameter("location", String.class)
            .execute((ToolExecutionContext ctx) -> {
                String location = ctx.getParameter("location", String.class);
                
                // Get weather data (simplified)
                WeatherData data = getWeatherData(location);
                
                // Return formatted response
                return ToolResponse.content(
                    String.format("Temperature: %.1f°F, Conditions: %s, Location: %s", 
                    data.getTemperature(), 
                    data.getConditions(), 
                    data.getLocation())
                );
            })
            .build());
        
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Weather MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
    
    private static WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    public WeatherData(double temperature, String conditions, String location) {
        this.temperature = temperature;
        this.conditions = conditions;
        this.location = location;
    }
    
    public double getTemperature() {
        return temperature;
    }
    
    public String getConditions() {
        return conditions;
    }
    
    public String getLocation() {
        return location;
    }
}
```

### Python Voorbeeld: Een MCP Server Bouwen

In dit voorbeeld laten we zien hoe je een MCP-server in Python bouwt. Je ziet ook twee verschillende manieren om tools te creëren.

```python
#!/usr/bin/env python3
import asyncio
from mcp.server.fastmcp import FastMCP
from mcp.server.transports.stdio import serve_stdio

# Create a FastMCP server
mcp = FastMCP(
    name="Weather MCP Server",
    version="1.0.0"
)

@mcp.tool()
def get_weather(location: str) -> dict:
    """Gets current weather for a location."""
    # This would normally call a weather API
    # Simplified for demonstration
    return {
        "temperature": 72.5,
        "conditions": "Sunny",
        "location": location
    }

# Alternative approach using a class
class WeatherTools:
    @mcp.tool()
    def forecast(self, location: str, days: int = 1) -> dict:
        """Gets weather forecast for a location for the specified number of days."""
        # This would normally call a weather API forecast endpoint
        # Simplified for demonstration
        return {
            "location": location,
            "forecast": [
                {"day": i+1, "temperature": 70 + i, "conditions": "Partly Cloudy"}
                for i in range(days)
            ]
        }

# Initialize class for its methods to be registered as tools
weather_tools = WeatherTools()

if __name__ == "__main__":
    # Start the server with stdio transport
    print("Weather MCP Server starting...")
    asyncio.run(serve_stdio(mcp))
```

### JavaScript Voorbeeld: Een MCP Server Maken

Dit voorbeeld laat zien hoe je een MCP-server in JavaScript maakt en twee weergerelateerde tools registreert.

```javascript
// Using the official Model Context Protocol SDK
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod"; // For parameter validation

// Create an MCP server
const server = new McpServer({
  name: "Weather MCP Server",
  version: "1.0.0"
});

// Define a weather tool
server.tool(
  "weatherTool",
  {
    location: z.string().describe("The location to get weather for")
  },
  async ({ location }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const weatherData = await getWeatherData(location);
    
    return {
      content: [
        { 
          type: "text", 
          text: `Temperature: ${weatherData.temperature}°F, Conditions: ${weatherData.conditions}, Location: ${weatherData.location}` 
        }
      ]
    };
  }
);

// Define a forecast tool
server.tool(
  "forecastTool",
  {
    location: z.string(),
    days: z.number().default(3).describe("Number of days for forecast")
  },
  async ({ location, days }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const forecast = await getForecastData(location, days);
    
    return {
      content: [
        { 
          type: "text", 
          text: `${days}-day forecast for ${location}: ${JSON.stringify(forecast)}` 
        }
      ]
    };
  }
);

// Helper functions
async function getWeatherData(location) {
  // Simulate API call
  return {
    temperature: 72.5,
    conditions: "Sunny",
    location: location
  };
}

async function getForecastData(location, days) {
  // Simulate API call
  return Array.from({ length: days }, (_, i) => ({
    day: i + 1,
    temperature: 70 + Math.floor(Math.random() * 10),
    conditions: i % 2 === 0 ? "Sunny" : "Partly Cloudy"
  }));
}

// Connect the server using stdio transport
const transport = new StdioServerTransport();
server.connect(transport).catch(console.error);

console.log("Weather MCP Server started");
```

Dit JavaScript-voorbeeld demonstreert hoe je een MCP-client maakt die verbinding maakt met een server, een prompt verstuurt en het antwoord verwerkt, inclusief eventuele uitgevoerde toolaanroepen.

## Beveiliging en Autorisatie

MCP bevat verschillende ingebouwde concepten en mechanismen voor het beheren van beveiliging en autorisatie binnen het protocol:

1. **Tool Toestemmingscontrole**:  
   Clients kunnen specificeren welke tools een model mag gebruiken tijdens een sessie. Dit zorgt ervoor dat alleen expliciet geautoriseerde tools toegankelijk zijn, wat het risico op onbedoelde of onveilige acties vermindert. Permissies kunnen dynamisch worden ingesteld op basis van gebruikersvoorkeuren, organisatorische beleidsregels of de context van de interactie.

2. **Authenticatie**:  
   Servers kunnen authenticatie vereisen voordat toegang wordt verleend tot tools, resources of gevoelige operaties. Dit kan via API-sleutels, OAuth-tokens of andere authenticatieschema’s. Goede authenticatie zorgt ervoor dat alleen vertrouwde clients en gebruikers servermogelijkheden kunnen aanroepen.

3. **Validatie**:  
   Parametervalidatie wordt afgedwongen voor alle toolaanroepen. Elke tool definieert de verwachte types, formaten en beperkingen voor zijn parameters, en de server valideert inkomende verzoeken hierop. Dit voorkomt dat onjuiste of kwaadaardige input de toolimplementaties bereikt en helpt de integriteit van operaties te waarborgen.

4. **Rate Limiting**:  
   Om misbruik te voorkomen en eerlijk gebruik van serverresources te garanderen, kunnen MCP-servers rate limiting toepassen voor toolaanroepen en resource-toegang. Rate limits kunnen per gebruiker, per sessie of globaal worden ingesteld en beschermen tegen denial-of-service-aanvallen of overmatig gebruik.

Door deze mechanismen te combineren, biedt MCP een veilige basis voor het integreren van taalmodellen met externe tools en databronnen, terwijl gebruikers en ontwikkelaars gedetailleerde controle krijgen over toegang en gebruik.

## Protocolberichten

MCP-communicatie gebruikt gestructureerde JSON-berichten om duidelijke en betrouwbare interacties tussen clients, servers en modellen te faciliteren. De belangrijkste berichttypen zijn:

- **Clientverzoek**  
  Wordt van client naar server gestuurd en bevat meestal:  
  - De prompt of opdracht van de gebruiker  
  - Gespreksgeschiedenis voor context  
  - Toolconfiguratie en permissies  
  - Eventuele extra metadata of sessie-informatie

- **Modelantwoord**  
  Wordt door het model (via de client) teruggegeven en bevat:  
  - Gegeneerde tekst of voltooiing op basis van prompt en context  
  - Optionele toolaanwijzingen als het model bepaalt dat een tool moet worden aangeroepen  
  - Verwijzingen naar resources of extra context indien nodig

- **Toolverzoek**  
  Wordt van client naar server gestuurd wanneer een tool moet worden uitgevoerd. Dit bericht bevat:  
  - De naam van de aan te roepen tool  
  - Parameters die de tool nodig heeft (gevalideerd volgens de toolschema)  
  - Contextuele informatie of identificatoren om het verzoek te volgen

- **Toolantwoord**  
  Wordt door de server teruggestuurd na uitvoering van een tool. Dit bericht biedt:  
  - De resultaten van de tooluitvoering (gestructureerde data of inhoud)  
  - Eventuele fouten of statusinformatie als de toolaanroep mislukt is  
  - Optioneel extra metadata of logs gerelateerd aan de uitvoering

Deze gestructureerde berichten zorgen ervoor dat elke stap in de MCP-werkstroom expliciet, traceerbaar en uitbreidbaar is, en ondersteunen geavanceerde scenario’s zoals multi-turn gesprekken, tool chaining en robuuste foutafhandeling.

## Belangrijkste Punten

- MCP gebruikt een client-serverarchitectuur om modellen te verbinden met externe mogelijkheden  
- Het ecosysteem bestaat uit clients, hosts, servers, tools en databronnen  
- Communicatie kan via STDIO, SSE of WebSockets verlopen  
- Tools zijn de fundamentele functionele eenheden die aan modellen worden aangeboden  
- Gestructureerde communicatieprotocollen zorgen voor consistente interacties

## Oefening

Ontwerp een eenvoudige MCP-tool die nuttig zou zijn in jouw vakgebied. Bepaal:  
1. Hoe de tool zou heten  
2. Welke parameters het accepteert  
3. Welke output het

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de originele taal dient als de gezaghebbende bron te worden beschouwd. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.