<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:23:47+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "nl"
}
-->
# 📖 MCP Kernconcepten: De Model Context Protocol beheersen voor AI-integratie

Het Model Context Protocol (MCP) is een krachtig, gestandaardiseerd kader dat de communicatie tussen Large Language Models (LLM’s) en externe tools, applicaties en databronnen optimaliseert. Deze SEO-geoptimaliseerde gids leidt je door de kernconcepten van MCP, zodat je de client-serverarchitectuur, essentiële componenten, communicatiemechanismen en best practices voor implementatie begrijpt.

## Overzicht

Deze les behandelt de fundamentele architectuur en componenten die het Model Context Protocol (MCP) ecosysteem vormen. Je leert over de client-serverarchitectuur, de belangrijkste onderdelen en de communicatieprocessen die MCP-interacties mogelijk maken.

## 👩‍🎓 Belangrijkste Leerdoelen

Aan het einde van deze les zul je:

- De MCP client-serverarchitectuur begrijpen.
- De rollen en verantwoordelijkheden van Hosts, Clients en Servers herkennen.
- De kernfuncties analyseren die MCP tot een flexibele integratielaag maken.
- Leren hoe informatie binnen het MCP-ecosysteem stroomt.
- Praktische inzichten opdoen via codevoorbeelden in .NET, Java, Python en JavaScript.

## 🔎 MCP Architectuur: Een Diepere Kijk

Het MCP-ecosysteem is gebaseerd op een client-servermodel. Deze modulaire structuur maakt het mogelijk dat AI-applicaties efficiënt communiceren met tools, databases, API’s en contextuele bronnen. Laten we deze architectuur opsplitsen in de kerncomponenten.

### 1. Hosts

In het Model Context Protocol (MCP) spelen Hosts een cruciale rol als de primaire interface waarmee gebruikers met het protocol communiceren. Hosts zijn applicaties of omgevingen die verbindingen initiëren met MCP-servers om toegang te krijgen tot data, tools en prompts. Voorbeelden van Hosts zijn geïntegreerde ontwikkelomgevingen (IDE’s) zoals Visual Studio Code, AI-tools zoals Claude Desktop, of op maat gemaakte agents voor specifieke taken.

**Hosts** zijn LLM-applicaties die verbindingen starten. Zij:

- Voeren AI-modellen uit of interacteren hiermee om antwoorden te genereren.
- Initiëren verbindingen met MCP-servers.
- Beheren de gespreksstroom en gebruikersinterface.
- Controleren permissies en beveiligingsbeperkingen.
- Regelen gebruikersconsent voor data delen en tooluitvoering.

### 2. Clients

Clients zijn essentiële componenten die de interactie tussen Hosts en MCP-servers mogelijk maken. Clients fungeren als tussenpersonen, waardoor Hosts toegang krijgen tot en gebruik kunnen maken van de functionaliteiten van MCP-servers. Zij spelen een belangrijke rol in het garanderen van soepele communicatie en efficiënte gegevensuitwisseling binnen de MCP-architectuur.

**Clients** zijn connectors binnen de hostapplicatie. Zij:

- Versturen verzoeken naar servers met prompts/instructies.
- Onderhandelen over mogelijkheden met servers.
- Beheren tooluitvoeringsverzoeken vanuit modellen.
- Verwerken en tonen reacties aan gebruikers.

### 3. Servers

Servers zijn verantwoordelijk voor het afhandelen van verzoeken van MCP-clients en het geven van passende antwoorden. Ze beheren diverse operaties zoals data ophalen, tooluitvoering en promptgeneratie. Servers zorgen ervoor dat de communicatie tussen clients en Hosts efficiënt en betrouwbaar verloopt, waarbij de integriteit van het interactieproces wordt gewaarborgd.

**Servers** zijn services die context en functionaliteiten bieden. Zij:

- Registreren beschikbare functies (resources, prompts, tools).
- Ontvangen en voeren tool-aanroepen van de client uit.
- Bieden contextuele informatie om modelantwoorden te verbeteren.
- Geven outputs terug aan de client.
- Behouden de status over interacties heen indien nodig.

Servers kunnen door iedereen ontwikkeld worden om modelmogelijkheden uit te breiden met gespecialiseerde functionaliteit.

### 4. Serverfuncties

Servers in het Model Context Protocol (MCP) bieden fundamentele bouwstenen die rijke interacties mogelijk maken tussen clients, hosts en taalmodellen. Deze functies zijn ontworpen om de mogelijkheden van MCP te vergroten door gestructureerde context, tools en prompts aan te bieden.

MCP-servers kunnen een of meerdere van de volgende functies bieden:

#### 📑 Resources

Resources in het Model Context Protocol (MCP) omvatten verschillende soorten context en data die door gebruikers of AI-modellen kunnen worden gebruikt. Dit zijn onder andere:

- **Contextuele Data**: Informatie en context die gebruikers of AI-modellen kunnen inzetten voor besluitvorming en taakuitvoering.
- **Kennisbanken en Documentenarchieven**: Verzameling van gestructureerde en ongestructureerde data, zoals artikelen, handleidingen en onderzoeksrapporten, die waardevolle inzichten bieden.
- **Lokale Bestanden en Databases**: Data die lokaal op apparaten of in databases is opgeslagen, toegankelijk voor verwerking en analyse.
- **API’s en Webservices**: Externe interfaces en services die extra data en functionaliteiten bieden, waardoor integratie met diverse online bronnen en tools mogelijk is.

Een voorbeeld van een resource kan een databaseschema of een bestand zijn dat zo toegankelijk is:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts in het Model Context Protocol (MCP) omvatten diverse vooraf gedefinieerde sjablonen en interactiepatronen die ontworpen zijn om gebruikersworkflows te stroomlijnen en communicatie te verbeteren. Deze zijn onder andere:

- **Gestructureerde Berichten en Workflows**: Vooraf opgestelde berichten en processen die gebruikers door specifieke taken en interacties leiden.
- **Vooraf Gedefinieerde Interactiepatronen**: Gestandaardiseerde reeksen acties en reacties die consistente en efficiënte communicatie bevorderen.
- **Gespecialiseerde Gesprekssjablonen**: Aanpasbare sjablonen die zijn afgestemd op specifieke gesprekstypen, voor relevante en contextueel passende interacties.

Een promptsjabloon kan er bijvoorbeeld zo uitzien:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Tools in het Model Context Protocol (MCP) zijn functies die het AI-model kan uitvoeren om specifieke taken te voltooien. Deze tools zijn bedoeld om de mogelijkheden van het AI-model uit te breiden door gestructureerde en betrouwbare handelingen te bieden. Belangrijke kenmerken zijn:

- **Functies die het AI-model kan uitvoeren**: Tools zijn uitvoerbare functies die het AI-model kan aanroepen om taken uit te voeren.
- **Unieke Naam en Beschrijving**: Elke tool heeft een unieke naam en een gedetailleerde omschrijving van het doel en de functionaliteit.
- **Parameters en Outputs**: Tools accepteren specifieke parameters en leveren gestructureerde outputs, wat zorgt voor consistente en voorspelbare resultaten.
- **Discrete Functies**: Tools voeren afzonderlijke functies uit zoals webzoekopdrachten, berekeningen en databasequery’s.

Een voorbeeldtool kan er als volgt uitzien:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Clientfuncties

In het Model Context Protocol (MCP) bieden clients verschillende belangrijke functies aan servers, die de algehele functionaliteit en interactie binnen het protocol verbeteren. Een opvallende functie is Sampling.

### 👉 Sampling

- **Door de Server Geïnitieerde Agentgedragingen**: Clients maken het mogelijk dat servers specifieke acties of gedragingen autonoom starten, wat de dynamische mogelijkheden van het systeem vergroot.
- **Recursieve LLM-interacties**: Deze functie maakt recursieve interacties met grote taalmodellen (LLM’s) mogelijk, waardoor complexere en iteratieve verwerking van taken mogelijk is.
- **Aanvragen van Extra Modelcompleties**: Servers kunnen extra aanvullingen van het model aanvragen, zodat de antwoorden volledig en contextueel relevant zijn.

## Informatiestroom in MCP

Het Model Context Protocol (MCP) definieert een gestructureerde informatiestroom tussen hosts, clients, servers en modellen. Het begrijpen van deze stroom verduidelijkt hoe gebruikersverzoeken worden verwerkt en hoe externe tools en data worden geïntegreerd in modelantwoorden.

- **Host initieert verbinding**  
  De hostapplicatie (zoals een IDE of chatinterface) maakt verbinding met een MCP-server, meestal via STDIO, WebSocket of een andere ondersteunde transportlaag.

- **Capabiliteitenonderhandeling**  
  De client (ingebed in de host) en de server wisselen informatie uit over de ondersteunde functies, tools, resources en protocolversies. Dit zorgt ervoor dat beide kanten weten welke mogelijkheden beschikbaar zijn voor de sessie.

- **Gebruikersverzoek**  
  De gebruiker interageert met de host (bijvoorbeeld door een prompt of commando in te voeren). De host verzamelt deze input en geeft deze door aan de client voor verwerking.

- **Gebruik van resource of tool**  
  - De client kan extra context of resources opvragen bij de server (zoals bestanden, database-invoer of kennisbankartikelen) om het begrip van het model te verrijken.
  - Als het model bepaalt dat een tool nodig is (bijvoorbeeld om data op te halen, een berekening uit te voeren of een API aan te roepen), stuurt de client een tool-aanroepverzoek naar de server, met vermelding van de toolnaam en parameters.

- **Serveruitvoering**  
  De server ontvangt het resource- of toolverzoek, voert de benodigde operaties uit (zoals het draaien van een functie, queryen van een database of ophalen van een bestand) en geeft de resultaten gestructureerd terug aan de client.

- **Genereren van reactie**  
  De client verwerkt de antwoorden van de server (resourcegegevens, tooloutputs, etc.) in de lopende modelinteractie. Het model gebruikt deze informatie om een uitgebreid en contextueel relevant antwoord te genereren.

- **Resultaatpresentatie**  
  De host ontvangt de uiteindelijke output van de client en toont deze aan de gebruiker, vaak inclusief zowel de door het model gegenereerde tekst als eventuele resultaten van tooluitvoeringen of resource-opzoekingen.

Deze stroom maakt het mogelijk dat MCP geavanceerde, interactieve en contextbewuste AI-applicaties ondersteunt door modellen naadloos te verbinden met externe tools en databronnen.

## Protocoldetails

MCP (Model Context Protocol) is gebouwd bovenop [JSON-RPC 2.0](https://www.jsonrpc.org/), en biedt een gestandaardiseerd, taal-onafhankelijk berichtformaat voor communicatie tussen hosts, clients en servers. Deze basis maakt betrouwbare, gestructureerde en uitbreidbare interacties over diverse platforms en programmeertalen mogelijk.

### Belangrijke Protocolkenmerken

MCP breidt JSON-RPC 2.0 uit met extra conventies voor toolaanroepen, resource-toegang en promptbeheer. Het ondersteunt meerdere transportlagen (STDIO, WebSocket, SSE) en maakt veilige, uitbreidbare en taal-onafhankelijke communicatie tussen componenten mogelijk.

#### 🧢 Basisprotocol

- **JSON-RPC Berichtformaat**: Alle verzoeken en antwoorden gebruiken de JSON-RPC 2.0-specificatie, wat zorgt voor een consistente structuur voor method-aanroepen, parameters, resultaten en foutafhandeling.
- **Stateful Verbindingen**: MCP-sessies behouden status over meerdere verzoeken, waardoor voortdurende gesprekken, contextopbouw en resourcebeheer mogelijk zijn.
- **Capabiliteitenonderhandeling**: Tijdens het opzetten van de verbinding wisselen clients en servers informatie uit over ondersteunde functies, protocolversies, beschikbare tools en resources. Dit zorgt ervoor dat beide kanten elkaars mogelijkheden begrijpen en zich daarop kunnen aanpassen.

#### ➕ Extra Hulpmiddelen

Hieronder enkele extra hulpmiddelen en protocoluitbreidingen die MCP biedt om de ontwikkelaarservaring te verbeteren en geavanceerde scenario’s mogelijk te maken:

- **Configuratieopties**: MCP maakt dynamische configuratie van sessieparameters mogelijk, zoals tooltoestemmingen, resource-toegang en modelinstellingen, afgestemd op elke interactie.
- **Voortgangsrapportage**: Langdurige operaties kunnen voortgangsupdates geven, wat zorgt voor responsieve gebruikersinterfaces en een betere gebruikerservaring bij complexe taken.
- **Annuleren van Verzoeken**: Clients kunnen lopende verzoeken annuleren, waardoor gebruikers operaties kunnen onderbreken die niet langer nodig zijn of te lang duren.
- **Foutmeldingen**: Gestandaardiseerde foutberichten en codes helpen bij het diagnosticeren van problemen, het afhandelen van fouten en het bieden van bruikbare feedback aan gebruikers en ontwikkelaars.
- **Logging**: Zowel clients als servers kunnen gestructureerde logs genereren voor audit, debugging en monitoring van protocolinteracties.

Door gebruik te maken van deze protocolfuncties zorgt MCP voor robuuste, veilige en flexibele communicatie tussen taalmodellen en externe tools of databronnen.

### 🔐 Beveiligingsoverwegingen

Implementaties van MCP dienen een aantal belangrijke beveiligingsprincipes te volgen om veilige en betrouwbare interacties te waarborgen:

- **Gebruikersconsent en Controle**: Gebruikers moeten expliciet toestemming geven voordat data wordt geraadpleegd of acties worden uitgevoerd. Ze moeten duidelijke controle hebben over welke data gedeeld wordt en welke handelingen zijn toegestaan, ondersteund door intuïtieve gebruikersinterfaces voor het bekijken en goedkeuren van activiteiten.

- **Dataprivacy**: Gebruikersdata mag alleen met expliciete toestemming worden gedeeld en moet beschermd worden door passende toegangscontroles. MCP-implementaties moeten ongeautoriseerde datatransmissie voorkomen en zorgen dat privacy gedurende alle interacties gewaarborgd blijft.

- **Toolveiligheid**: Voor het aanroepen van tools is expliciete gebruikersconsent vereist. Gebruikers moeten duidelijk begrijpen wat elke tool doet, en er moeten robuuste beveiligingsgrenzen zijn om onbedoelde of onveilige tooluitvoering te voorkomen.

Door deze principes te volgen zorgt MCP ervoor dat vertrouwen, privacy en veiligheid van gebruikers behouden blijven bij alle protocolinteracties.

## Codevoorbeelden: Kerncomponenten

Hieronder staan codevoorbeelden in verschillende populaire programmeertalen die laten zien hoe je belangrijke MCP-servercomponenten en tools kunt implementeren.

### .NET Voorbeeld: Een Eenvoudige MCP Server met Tools Maken

Hier is een praktisch .NET-codevoorbeeld dat demonstreert hoe je een eenvoudige MCP-server met aangepaste tools kunt implementeren. Dit voorbeeld laat zien hoe je tools definieert en registreert, verzoeken afhandelt en de server verbindt via het Model Context Protocol.

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

Dit voorbeeld laat dezelfde MCP-server en toolregistratie zien als het .NET-voorbeeld hierboven, maar dan geïmplementeerd in Java.

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

In dit voorbeeld tonen we hoe je een MCP-server in Python bouwt. Ook laten we twee verschillende manieren zien om tools te maken.

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

Dit voorbeeld toont de creatie van een MCP-server in JavaScript en hoe je twee tools registreert die met het weer te maken hebben.

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

Dit JavaScript-voorbeeld laat zien hoe je een MCP-client maakt die verbinding maakt met een server, een prompt verstuurt en de reactie verwerkt, inclusief eventuele uitgevoerde tool-aanroepen.

## Beveiliging en Autorisatie

MCP bevat verschillende ingebouwde concepten en mechanismen voor het beheren van beveiliging en autorisatie binnen het protocol:

1. **Tooltoestemmingscontrole**  
   Clients kunnen specificeren welke tools een model mag gebruiken tijdens een sessie. Dit zorgt ervoor dat alleen expliciet geautoriseerde tools toegankelijk zijn, wat het risico op onbedoelde of onveilige handelingen vermindert. Toestemmingen kunnen dynamisch worden ingesteld op basis van gebruikersvoorkeuren, beleidsregels of de context van de interactie.

2. **Authenticatie**  
   Servers kunnen authenticatie vereisen voordat toegang wordt verleend tot tools, resources of gevoelige operaties. Dit kan API-sleutels, OAuth-tokens of andere authenticatieschema’s omvatten. Goede authenticatie zorgt ervoor dat alleen vertrouwde clients en gebruikers serverfunctionaliteiten kunnen aanroepen.

3. **Validatie**  
   Parametervalidatie wordt afgedwongen voor alle toolaanroepen. Elke tool definieert de verwachte types, formaten en beperkingen voor zijn parameters, en de server valideert inkomende verzoeken hiertegen. Dit voorkomt dat foutieve of kwaadaardige input de toolimplementaties bereikt en helpt de integriteit van operaties te behouden.

4. **Rate Limiting**  
   Om misbruik te voorkomen en eerlijk gebruik van serverbronnen te garanderen, kunnen MCP-servers rate limiting toepassen voor toolaanroepen en resource-toegang. Limieten kunnen per gebruiker, per sessie of globaal worden ingesteld en beschermen tegen denial-of-service-aanvallen of overmatig gebruik.

Door deze mechanismen te combineren biedt MCP een veilige basis voor het integreren van taalmodellen met externe tools en databronnen, terwijl gebruikers en ontwikkelaars fijne controle hebben over toegang en gebruik.

## Protocolberichten

MCP-communicatie gebruikt gestructureerde JSON-berichten om duidelijke en betrouwbare interacties tussen clients, servers en modellen te faciliteren. De belangrijkste berichttypen zijn:

- **Clientverzoek**  
  Wordt vanuit de client naar de server gestuurd en bevat meestal:  
  - De prompt of het commando van de gebruiker  
  - Gespreksgeschiedenis voor context  
  - Toolconfiguratie en toestemmingen  
  - Eventuele extra metadata of sessie-informatie

- **Modelantwoord**  
  Wordt teruggegeven door het model (via de client) en bevat:  
  - De gegenereerde tekst of voltooiing op basis van prompt en context  
  - Optionele tool-aanroep instructies als het model bepaalt dat een tool moet worden gebruikt  
  - Verwijzingen naar resources of extra context indien nodig

- **Toolverzoek**  
  Wordt vanuit de client naar de server gestuurd wanneer een tool uitgevoerd moet worden. Dit bericht bevat:  
  - De naam van de aan te roepen tool  
  - Parameters die door de tool vereist zijn (gevalideerd volgens het toolschema)  
  - Contextuele informatie of identifiers voor het volgen van het verzoek

- **Toolantwoord**  
  Wordt door de server teruggegeven na het uitvoeren van een tool. Dit bericht bevat:  
  - De resultaten van de tooluitvoering (gestructureerde data of inhoud)  
  - Eventuele fouten of statusinformatie als de toolaanroep is mislukt  
  - Optioneel extra metadata of logs gerelateerd aan de uitvoering

Deze gestructureerde berichten zorgen ervoor dat elke stap in de MCP-werkstroom expliciet, traceerbaar en uitbreidbaar is, en ondersteunen geavanceerde scenario’s zoals multi-turn gesprekken, ketenen van tools en robuuste foutafhandeling.

## Belangrijkste Punten

- MCP gebruikt een client-serverarchitectuur om modellen te verbinden met externe mogelijkheden  
- Het ecosysteem bestaat uit clients, hosts, servers, tools en databronnen  
- Communicatie kan plaatsvinden via STDIO, SSE of WebSockets  
- Tools zijn de fundamentele functionele eenheden die aan modellen worden aangeboden  
- Gestructureerde communicatieprotocollen zorgen voor consistente interacties

## Oefening

Ontwerp een eenvoudige MCP-tool die nuttig zou zijn in jouw vakgebied

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal geldt als de gezaghebbende bron. Voor belangrijke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.