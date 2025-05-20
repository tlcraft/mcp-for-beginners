<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T17:32:14+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "nl"
}
-->
# 📖 MCP Kernconcepten: Beheersing van het Model Context Protocol voor AI-integratie

Het Model Context Protocol (MCP) is een krachtig, gestandaardiseerd raamwerk dat de communicatie tussen Large Language Models (LLM's) en externe tools, applicaties en databronnen optimaliseert. Deze SEO-geoptimaliseerde gids neemt je mee door de kernconcepten van MCP, zodat je het client-servermodel, de essentiële componenten, communicatieprocessen en beste implementatiepraktijken begrijpt.

## Overzicht

Deze les behandelt de fundamentele architectuur en componenten die het Model Context Protocol (MCP) ecosysteem vormen. Je leert over de client-serverarchitectuur, belangrijke onderdelen en communicatiemechanismen die MCP-interacties mogelijk maken.

## 👩‍🎓 Belangrijkste Leerdoelen

Aan het einde van deze les:

- Begrijp je de MCP client-serverarchitectuur.
- Kun je de rollen en verantwoordelijkheden van Hosts, Clients en Servers benoemen.
- Analyseer je de kernkenmerken die MCP tot een flexibele integratielaag maken.
- Leer je hoe informatie binnen het MCP-ecosysteem stroomt.
- Krijg je praktische inzichten via codevoorbeelden in .NET, Java, Python en JavaScript.

## 🔎 MCP Architectuur: Een Diepere Kijk

Het MCP-ecosysteem is gebaseerd op een client-servermodel. Deze modulaire structuur maakt het mogelijk dat AI-applicaties efficiënt communiceren met tools, databases, API’s en contextuele bronnen. Laten we deze architectuur opsplitsen in de kerncomponenten.

### 1. Hosts

In het Model Context Protocol (MCP) spelen Hosts een cruciale rol als de primaire interface waarlangs gebruikers met het protocol communiceren. Hosts zijn applicaties of omgevingen die verbinding maken met MCP-servers om toegang te krijgen tot data, tools en prompts. Voorbeelden van Hosts zijn geïntegreerde ontwikkelomgevingen (IDE's) zoals Visual Studio Code, AI-tools zoals Claude Desktop, of op maat gemaakte agents voor specifieke taken.

**Hosts** zijn LLM-applicaties die verbindingen initiëren. Ze:

- Voeren AI-modellen uit of interacteren hiermee om antwoorden te genereren.
- Starten verbindingen met MCP-servers.
- Beheren het gesprek en de gebruikersinterface.
- Controleren permissies en beveiligingsregels.
- Verwerken gebruikerstoestemming voor datadeling en tooluitvoering.

### 2. Clients

Clients zijn essentiële componenten die de interactie tussen Hosts en MCP-servers mogelijk maken. Clients fungeren als tussenpersonen, zodat Hosts de functionaliteiten van MCP-servers kunnen gebruiken. Ze zorgen voor soepele communicatie en efficiënte data-uitwisseling binnen de MCP-architectuur.

**Clients** zijn connectors binnen de hostapplicatie. Ze:

- Versturen verzoeken naar servers met prompts/instructies.
- Onderhandelen over mogelijkheden met servers.
- Beheren tooluitvoeringsverzoeken van modellen.
- Verwerken en tonen antwoorden aan gebruikers.

### 3. Servers

Servers zijn verantwoordelijk voor het afhandelen van verzoeken van MCP-clients en het leveren van passende antwoorden. Ze beheren diverse operaties zoals het ophalen van data, uitvoeren van tools en genereren van prompts. Servers zorgen ervoor dat de communicatie tussen clients en Hosts efficiënt en betrouwbaar verloopt, waarbij de integriteit van het proces behouden blijft.

**Servers** zijn diensten die context en mogelijkheden bieden. Ze:

- Registreren beschikbare functies (resources, prompts, tools).
- Ontvangen en voeren toolaanroepen van de client uit.
- Bieden contextuele informatie om modelantwoorden te verbeteren.
- Sturen outputs terug naar de client.
- Behouden indien nodig de status tussen interacties.

Servers kunnen door iedereen ontwikkeld worden om de modelmogelijkheden uit te breiden met gespecialiseerde functionaliteit.

### 4. Server Features

Servers binnen het Model Context Protocol (MCP) bieden fundamentele bouwstenen die rijke interacties tussen clients, hosts en taalmodellen mogelijk maken. Deze features versterken MCP door gestructureerde context, tools en prompts aan te bieden.

MCP-servers kunnen een of meer van de volgende features bieden:

#### 📑 Resources

Resources in MCP omvatten verschillende soorten context en data die door gebruikers of AI-modellen gebruikt kunnen worden. Dit zijn onder andere:

- **Contextuele Data**: Informatie en context die gebruikers of AI-modellen kunnen benutten voor besluitvorming en taakuitvoering.
- **Kennisbases en Documentenarchieven**: Verzameling van gestructureerde en ongestructureerde data, zoals artikelen, handleidingen en onderzoeksrapporten die waardevolle inzichten bieden.
- **Lokale Bestanden en Databases**: Data die lokaal op apparaten of in databases opgeslagen is, toegankelijk voor verwerking en analyse.
- **API’s en Webservices**: Externe interfaces en diensten die extra data en functionaliteiten leveren, waardoor integratie met diverse online bronnen en tools mogelijk is.

Een voorbeeld van een resource kan een databaseschema of een bestand zijn dat als volgt benaderd wordt:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts in MCP omvatten verschillende vooraf gedefinieerde sjablonen en interactiepatronen die workflows stroomlijnen en communicatie verbeteren. Deze omvatten:

- **Vooraf Opgestelde Berichten en Workflows**: Gestructureerde berichten en processen die gebruikers begeleiden bij specifieke taken en interacties.
- **Vooraf Gedefinieerde Interactiepatronen**: Gestandaardiseerde reeksen van acties en reacties die consistente en efficiënte communicatie mogelijk maken.
- **Gespecialiseerde Gesprekssjablonen**: Aanpasbare sjablonen voor specifieke gesprekstypen, die zorgen voor relevante en contextueel passende interacties.

Een prompt-sjabloon kan er als volgt uitzien:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Tools in MCP zijn functies die het AI-model kan uitvoeren om specifieke taken te voltooien. Deze tools vergroten de mogelijkheden van het AI-model door gestructureerde en betrouwbare operaties te bieden. Belangrijke aspecten zijn:

- **Functies die het AI-model kan uitvoeren**: Tools zijn uitvoerbare functies die het model kan aanroepen om diverse taken uit te voeren.
- **Unieke Naam en Beschrijving**: Elke tool heeft een duidelijke naam en een uitgebreide beschrijving van de functionaliteit.
- **Parameters en Outputs**: Tools accepteren specifieke parameters en leveren gestructureerde outputs, wat zorgt voor consistente en voorspelbare resultaten.
- **Afgebakende Functies**: Tools voeren discrete functies uit zoals webzoekopdrachten, berekeningen en databasequeries.

Een voorbeeldtool kan er als volgt uitzien:

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

In MCP bieden clients verschillende belangrijke functies aan servers, die de algehele functionaliteit en interactie binnen het protocol verbeteren. Een opvallende feature is Sampling.

### 👉 Sampling

- **Server-geïnitieerde Agentgedragingen**: Clients maken het mogelijk dat servers specifieke acties of gedragingen autonoom starten, wat de dynamische capaciteiten van het systeem versterkt.
- **Recursieve LLM-interacties**: Deze feature ondersteunt recursieve interacties met grote taalmodellen, waardoor complexere en iteratieve taakverwerking mogelijk is.
- **Aanvragen van Extra Modelcompletions**: Servers kunnen extra completions van het model opvragen, zodat antwoorden grondiger en contextueel relevanter zijn.

## Informatiestroom in MCP

Het Model Context Protocol (MCP) definieert een gestructureerde informatiestroom tussen hosts, clients, servers en modellen. Inzicht in deze stroom verduidelijkt hoe gebruikersverzoeken worden verwerkt en hoe externe tools en data in modelantwoorden worden geïntegreerd.

- **Host Start Verbinding**  
  De hostapplicatie (zoals een IDE of chatinterface) maakt verbinding met een MCP-server, meestal via STDIO, WebSocket of een andere ondersteunde transportlaag.

- **Onderhandeling van Mogelijkheden**  
  De client (ingebed in de host) en server wisselen informatie uit over ondersteunde features, tools, resources en protocolversies. Dit zorgt ervoor dat beide partijen weten welke mogelijkheden beschikbaar zijn tijdens de sessie.

- **Gebruikersverzoek**  
  De gebruiker voert een prompt of commando in bij de host. De host verzamelt deze input en stuurt deze door naar de client voor verwerking.

- **Gebruik van Resource of Tool**  
  - De client kan extra context of resources opvragen bij de server (zoals bestanden, database-items of kennisartikelen) om het model beter te informeren.
  - Als het model bepaalt dat een tool nodig is (bijvoorbeeld om data op te halen, een berekening uit te voeren of een API aan te roepen), stuurt de client een toolaanroep naar de server met de naam en parameters van de tool.

- **Serveruitvoering**  
  De server ontvangt het resource- of toolverzoek, voert de benodigde operaties uit (zoals een functie draaien, database bevragen of bestand ophalen) en stuurt de resultaten in een gestructureerd formaat terug naar de client.

- **Genereren van Antwoord**  
  De client verwerkt de serverrespons (resource data, tooloutputs, etc.) in de lopende modelinteractie. Het model gebruikt deze informatie om een volledig en contextueel passend antwoord te genereren.

- **Resultaat Presentatie**  
  De host ontvangt de uiteindelijke output van de client en toont deze aan de gebruiker, vaak inclusief zowel de door het model gegenereerde tekst als eventuele resultaten van tooluitvoeringen of resource-zoekopdrachten.

Deze stroom maakt het mogelijk dat MCP geavanceerde, interactieve en contextbewuste AI-toepassingen ondersteunt door modellen naadloos te verbinden met externe tools en databronnen.

## Protocol Details

MCP (Model Context Protocol) is gebouwd bovenop [JSON-RPC 2.0](https://www.jsonrpc.org/), wat een gestandaardiseerd, taalonafhankelijk berichtformaat biedt voor communicatie tussen hosts, clients en servers. Deze basis zorgt voor betrouwbare, gestructureerde en uitbreidbare interacties over verschillende platforms en programmeertalen heen.

### Belangrijke Protocolkenmerken

MCP breidt JSON-RPC 2.0 uit met extra conventies voor toolaanroepen, resource-toegang en promptbeheer. Het ondersteunt meerdere transportlagen (STDIO, WebSocket, SSE) en maakt veilige, uitbreidbare en taalonafhankelijke communicatie tussen componenten mogelijk.

#### 🧢 Basisprotocol

- **JSON-RPC Berichtformaat**: Alle verzoeken en antwoorden gebruiken de JSON-RPC 2.0-specificatie, wat zorgt voor een consistente structuur voor method calls, parameters, resultaten en foutafhandeling.
- **Stateful Verbindingen**: MCP-sessies behouden status over meerdere verzoeken heen, wat gesprekken, contextopbouw en resourcebeheer ondersteunt.
- **Onderhandeling van Mogelijkheden**: Tijdens het opzetten van de verbinding wisselen clients en servers informatie uit over ondersteunde features, protocolversies, beschikbare tools en resources. Dit zorgt dat beide kanten elkaars mogelijkheden begrijpen en zich kunnen aanpassen.

#### ➕ Extra Hulpmiddelen

Hieronder enkele extra hulpmiddelen en protocoluitbreidingen die MCP biedt om de ontwikkelaarservaring te verbeteren en geavanceerde scenario’s mogelijk te maken:

- **Configuratieopties**: MCP maakt dynamische configuratie van sessieparameters mogelijk, zoals toolpermissies, resource-toegang en modelinstellingen, afgestemd op elke interactie.
- **Voortgangsbewaking**: Langdurige operaties kunnen voortgangsupdates rapporteren, wat zorgt voor responsieve gebruikersinterfaces en betere gebruikerservaring bij complexe taken.
- **Annuleren van Verzoeken**: Clients kunnen lopende verzoeken annuleren, zodat gebruikers operaties kunnen stoppen die niet meer nodig zijn of te lang duren.
- **Foutrapportage**: Gestandaardiseerde foutmeldingen en codes helpen bij het diagnosticeren van problemen, zorgen voor nette foutafhandeling en geven bruikbare feedback aan gebruikers en ontwikkelaars.
- **Logging**: Zowel clients als servers kunnen gestructureerde logs genereren voor auditing, debugging en monitoring van protocolinteracties.

Door gebruik te maken van deze protocolfeatures zorgt MCP voor robuuste, veilige en flexibele communicatie tussen taalmodellen en externe tools of databronnen.

### 🔐 Beveiligingsoverwegingen

MCP-implementaties dienen een aantal belangrijke beveiligingsprincipes te volgen om veilige en betrouwbare interacties te waarborgen:

- **Gebruikerstoestemming en Controle**: Gebruikers moeten expliciet toestemming geven voordat data wordt geraadpleegd of operaties worden uitgevoerd. Ze moeten duidelijk controle hebben over welke data gedeeld wordt en welke acties toegestaan zijn, ondersteund door intuïtieve interfaces om activiteiten te beoordelen en goed te keuren.

- **Dataprivacy**: Gebruikersdata mag alleen met expliciete toestemming gedeeld worden en moet beschermd worden met passende toegangscontroles. MCP-implementaties moeten onbevoegde datatransmissie voorkomen en privacy tijdens alle interacties waarborgen.

- **Veiligheid van Tools**: Voor het aanroepen van tools is altijd expliciete gebruikersgoedkeuring nodig. Gebruikers moeten helder inzicht hebben in wat elke tool doet en er moeten strenge beveiligingsgrenzen zijn om ongewenste of onveilige tooluitvoering te voorkomen.

Door deze principes te volgen, zorgt MCP ervoor dat vertrouwen, privacy en veiligheid van gebruikers tijdens alle protocolinteracties behouden blijven.

## Codevoorbeelden: Kerncomponenten

Hieronder staan codevoorbeelden in verschillende populaire programmeertalen die laten zien hoe je belangrijke MCP-servercomponenten en tools implementeert.

### .NET Voorbeeld: Een Eenvoudige MCP Server met Tools Maken

Een praktisch .NET-codevoorbeeld dat laat zien hoe je een eenvoudige MCP-server met aangepaste tools maakt. Dit voorbeeld toont hoe je tools definieert en registreert, verzoeken afhandelt en de server verbindt via het Model Context Protocol.

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

In dit voorbeeld tonen we hoe je een MCP-server bouwt in Python. Er worden ook twee verschillende manieren getoond om tools te creëren.

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

Dit voorbeeld toont het maken van een MCP-server in JavaScript en hoe je twee weergerelateerde tools registreert.

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

Dit JavaScript-voorbeeld laat zien hoe je een MCP-client maakt die verbinding maakt met een server, een prompt verstuurt en het antwoord verwerkt, inclusief eventuele toolaanroepen.

## Beveiliging en Autorisatie

MCP bevat verschillende ingebouwde concepten en mechanismen voor het beheren van beveiliging en autorisatie binnen het protocol:

1. **Tooltoegangscontrole**  
   Clients kunnen specificeren welke tools een model mag gebruiken tijdens een sessie. Dit zorgt ervoor dat alleen expliciet geautoriseerde tools toegankelijk zijn, wat het risico op ongewenste of onveilige acties verkleint. Permissies kunnen dynamisch worden ingesteld op basis van gebruikersvoorkeuren, beleidsregels of de context van de interactie.

2. **Authenticatie**  
   Servers kunnen authenticatie vereisen voordat toegang wordt verleend tot tools, resources of gevoelige operaties. Dit kan via API-sleutels, OAuth-tokens of andere authenticatieschema’s. Goede authenticatie garandeert dat alleen vertrouwde clients en gebruikers servermogelijkheden kunnen aanroepen.

3. **Validatie**  
   Parametervalidatie is verplicht voor alle toolaanroepen. Elke tool definieert de verwachte types, formaten en beperkingen van parameters, en de server valideert inkomende verzoeken hierop. Dit voorkomt dat onjuiste of kwaadaardige input bij tools terechtkomt en helpt de integriteit van operaties te behouden.

4. **Rate Limiting**  
   Om misbruik te voorkomen en eerlijk gebruik van serverresources te garanderen, kunnen MCP-servers rate limiting toepassen op toolaanroepen en resource-toegang. Limieten kunnen per gebruiker, sessie of globaal worden ingesteld en beschermen tegen denial-of-service-aanvallen of overmatig resourcegebruik.

Door deze mechanismen te combineren, biedt MCP een veilige basis voor integratie van taalmodellen met externe tools en databronnen, terwijl gebruikers en ontwikkelaars fijne controle krijgen over toegang en gebruik.

## Protocolberichten

MCP-communicatie gebruikt gestructureerde JSON-berichten om duidelijke en betrouwbare interacties tussen clients, servers en modellen te faciliteren. De belangrijkste berichttypen zijn:

- **Clientverzoek**  
  Verstuurd van client naar server, dit bericht bevat meestal:  
  - De prompt of opdracht van de gebruiker  
  - Gespreksgeschiedenis voor context  
  - Toolconfiguratie en permissies  
  - Eventuele extra metadata of sessie-informatie

- **Modelantwoord**  
  Teruggegeven door het model (via de client), dit bericht bevat:  
  - Gegeneerde tekst of completion op basis van prompt en context  
  - Optioneel toolaanroepinstructies als het model een tool wil gebruiken  
  - Verwijzingen naar resources of extra context indien nodig

- **Toolverzoek**  
  Verstuurd van client naar server wanneer een tool uitgevoerd moet worden. Dit bericht bevat:  
  - De naam van de aan te roepen tool  
  - Parameters die de tool nodig heeft (gevalideerd volgens het toolschema)  
  - Contextuele informatie of identificaties voor het volgen van het verzoek

- **Toolantwoord**  
  Teruggegeven door de server na uitvoering van een tool. Dit bericht bevat:  
  - De resultaten van de tooluitvoering (gestructureerde data of inhoud)  
  - Eventuele fouten of statusinformatie als de toolaanroep mislukte  
  - Optioneel extra metadata of logs gerelateerd aan de uitvoering

Deze gestructureerde berichten zorgen ervoor dat elke stap in de MCP-werkstroom expliciet, traceerbaar en uitbreidbaar is, wat geavanceerde scenario’s zoals meerlagige gesprekken, tool chaining en robuuste foutafhandeling ondersteunt.

## Belangrijkste Punten

- MCP gebruikt een client-serverarchitectuur om modellen te verbinden met externe mogelijkheden
- Het ecosysteem bestaat uit clients, hosts, servers, tools en databronnen
- Communicatie kan via STDIO, SSE of WebSockets verlopen
- Tools zijn de fundamentele functionele eenheden die aan modellen worden aangeboden
- Gestructureerde communicatieprotocollen zorgen voor consistente interacties

## Oefening

Ontwerp een eenvoudige MCP-tool die nuttig zou zijn in jouw vakgebied. Definieer:  
1. Hoe de tool heet  
2. Welke parameters de tool accepteert  
3. Welke output de tool teruggeeft  
4. Hoe een model deze tool zou kunnen gebruiken om gebruikersproblemen op te lossen

---

## Wat volgt

Volgende: [Hoofdstuk 2: Beveiliging](/02-Security/readme.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onjuistheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor belangrijke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.