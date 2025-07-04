<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "355b12a5970c5c9e6db0bee970c751ba",
  "translation_date": "2025-07-04T17:53:49+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "nl"
}
-->
# 📖 MCP Kernconcepten: Beheersing van het Model Context Protocol voor AI-integratie

Het [Model Context Protocol (MCP)](https://github.com/modelcontextprotocol) is een krachtig, gestandaardiseerd raamwerk dat de communicatie tussen Large Language Models (LLM's) en externe tools, applicaties en databronnen optimaliseert. Deze SEO-geoptimaliseerde gids neemt je mee door de kernconcepten van MCP, zodat je de client-serverarchitectuur, essentiële componenten, communicatiemechanismen en implementatiebest practices begrijpt.

## Overzicht

Deze les behandelt de fundamentele architectuur en componenten die het Model Context Protocol (MCP) ecosysteem vormen. Je leert over de client-serverarchitectuur, de belangrijkste componenten en de communicatiemechanismen die MCP-interacties aandrijven.

## 👩‍🎓 Belangrijkste Leerdoelen

Aan het einde van deze les zul je:

- De MCP client-serverarchitectuur begrijpen.
- De rollen en verantwoordelijkheden van Hosts, Clients en Servers kunnen identificeren.
- De kernfuncties analyseren die MCP tot een flexibele integratielaag maken.
- Leren hoe informatie binnen het MCP-ecosysteem stroomt.
- Praktische inzichten opdoen via codevoorbeelden in .NET, Java, Python en JavaScript.

## 🔎 MCP Architectuur: Een Diepere Kijk

Het MCP-ecosysteem is gebouwd op een client-servermodel. Deze modulaire structuur stelt AI-toepassingen in staat efficiënt te communiceren met tools, databases, API’s en contextuele bronnen. Laten we deze architectuur opdelen in de kerncomponenten.

In de kern volgt MCP een client-serverarchitectuur waarbij een hostapplicatie verbinding kan maken met meerdere servers:

```mermaid
flowchart LR
    subgraph "Your Computer"
        Host["Host with MCP VScode, IDEs, Tools)"]
        S1["MCP Server A"]
        S2["MCP Server B"]
        S3["MCP Server C"]
        Host <-->|"MCP Protocol"| S1
        Host <-->|"MCP Protocol"| S2
        Host <-->|"MCP Protocol"| S3
        S1 <--> D1[("Local\Data Source A")]
        S2 <--> D2[("Local\Data Source B")]
    end
    subgraph "Internet"
        S3 <-->|"Web APIs"| D3[("Remote\Services")]
    end
```

- **MCP Hosts**: Programma’s zoals VSCode, Claude Desktop, IDE’s of AI-tools die via MCP toegang willen tot data
- **MCP Clients**: Protocolclients die 1:1-verbindingen onderhouden met servers
- **MCP Servers**: Lichtgewicht programma’s die elk specifieke functionaliteiten aanbieden via het gestandaardiseerde Model Context Protocol
- **Lokale Databronnen**: Bestanden, databases en services op je computer die MCP-servers veilig kunnen benaderen
- **Externe Services**: Externe systemen die via internet beschikbaar zijn en waar MCP-servers via API’s verbinding mee kunnen maken.

Het MCP-protocol is een evoluerende standaard; de laatste updates vind je in de [protocolspecificatie](https://modelcontextprotocol.io/specification/2025-06-18/)

### 1. Hosts

In het Model Context Protocol (MCP) spelen Hosts een cruciale rol als de primaire interface waarmee gebruikers met het protocol communiceren. Hosts zijn applicaties of omgevingen die verbindingen met MCP-servers initiëren om toegang te krijgen tot data, tools en prompts. Voorbeelden van Hosts zijn geïntegreerde ontwikkelomgevingen (IDE’s) zoals Visual Studio Code, AI-tools zoals Claude Desktop, of op maat gemaakte agents voor specifieke taken.

**Hosts** zijn LLM-applicaties die verbindingen starten. Ze:

- Voeren AI-modellen uit of interacteren ermee om antwoorden te genereren.
- Initiëren verbindingen met MCP-servers.
- Beheren het gesprek en de gebruikersinterface.
- Controleren permissies en beveiligingsbeperkingen.
- Behandelen gebruikersconsent voor datadeling en tooluitvoering.

### 2. Clients

Clients zijn essentiële componenten die de interactie tussen Hosts en MCP-servers mogelijk maken. Clients fungeren als tussenpersonen, waardoor Hosts de functionaliteiten van MCP-servers kunnen gebruiken. Ze zorgen voor soepele communicatie en efficiënte gegevensuitwisseling binnen de MCP-architectuur.

**Clients** zijn connectors binnen de hostapplicatie. Ze:

- Versturen verzoeken naar servers met prompts/instructies.
- Onderhandelen over mogelijkheden met servers.
- Beheren tooluitvoeringsverzoeken vanuit modellen.
- Verwerken en tonen antwoorden aan gebruikers.

### 3. Servers

Servers zijn verantwoordelijk voor het afhandelen van verzoeken van MCP-clients en het leveren van passende antwoorden. Ze beheren diverse operaties zoals data-opvraging, tooluitvoering en promptgeneratie. Servers zorgen ervoor dat de communicatie tussen clients en Hosts efficiënt en betrouwbaar verloopt, waarbij de integriteit van het interactieproces behouden blijft.

**Servers** zijn services die context en functionaliteiten bieden. Ze:

- Registreren beschikbare features (resources, prompts, tools)
- Ontvangen en voeren toolaanroepen van de client uit
- Bieden contextuele informatie om modelantwoorden te verbeteren
- Sturen outputs terug naar de client
- Behouden de status over interacties heen indien nodig

Servers kunnen door iedereen ontwikkeld worden om modelmogelijkheden uit te breiden met gespecialiseerde functionaliteit.

### 4. Server Features

Servers in het Model Context Protocol (MCP) bieden fundamentele bouwstenen die rijke interacties tussen clients, hosts en taalmodellen mogelijk maken. Deze features zijn ontworpen om de mogelijkheden van MCP te vergroten door gestructureerde context, tools en prompts aan te bieden.

MCP-servers kunnen een of meer van de volgende features aanbieden:

#### 📑 Resources

Resources in het Model Context Protocol (MCP) omvatten verschillende soorten context en data die door gebruikers of AI-modellen kunnen worden gebruikt. Dit zijn onder andere:

- **Contextuele Data**: Informatie en context die gebruikers of AI-modellen kunnen inzetten voor besluitvorming en taakuitvoering.
- **Kennisbanken en Documentenarchieven**: Verzameling van gestructureerde en ongestructureerde data, zoals artikelen, handleidingen en onderzoeksrapporten, die waardevolle inzichten bieden.
- **Lokale Bestanden en Databases**: Data die lokaal op apparaten of in databases is opgeslagen en toegankelijk is voor verwerking en analyse.
- **API’s en Webservices**: Externe interfaces en services die extra data en functionaliteiten bieden, waardoor integratie met diverse online bronnen en tools mogelijk is.

Een voorbeeld van een resource kan een databaseschema of een bestand zijn dat als volgt benaderd kan worden:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts in het Model Context Protocol (MCP) omvatten diverse vooraf gedefinieerde sjablonen en interactiepatronen die ontworpen zijn om gebruikersworkflows te stroomlijnen en communicatie te verbeteren. Dit zijn onder andere:

- **Vooraf gestructureerde berichten en workflows**: Vooraf opgezette berichten en processen die gebruikers begeleiden bij specifieke taken en interacties.
- **Vooraf gedefinieerde interactiepatronen**: Gestandaardiseerde reeksen acties en reacties die consistente en efficiënte communicatie bevorderen.
- **Gespecialiseerde gespreksjablonen**: Aanpasbare sjablonen die zijn afgestemd op specifieke gesprekstypen, voor relevante en contextueel passende interacties.

Een prompttemplate kan er als volgt uitzien:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Tools in het Model Context Protocol (MCP) zijn functies die het AI-model kan uitvoeren om specifieke taken te volbrengen. Deze tools zijn ontworpen om de mogelijkheden van het AI-model te vergroten door gestructureerde en betrouwbare operaties te bieden. Belangrijke aspecten zijn:

- **Functies die het AI-model kan uitvoeren**: Tools zijn uitvoerbare functies die het AI-model kan aanroepen om diverse taken uit te voeren.
- **Unieke naam en beschrijving**: Elke tool heeft een unieke naam en een gedetailleerde beschrijving die het doel en de functionaliteit uitlegt.
- **Parameters en outputs**: Tools accepteren specifieke parameters en leveren gestructureerde outputs, wat zorgt voor consistente en voorspelbare resultaten.
- **Discrete functies**: Tools voeren afzonderlijke functies uit zoals webzoekopdrachten, berekeningen en databasequeries.

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

In het Model Context Protocol (MCP) bieden clients verschillende belangrijke features aan servers, die de algehele functionaliteit en interactie binnen het protocol verbeteren. Een opvallende feature is Sampling.

### 👉 Sampling

- **Server-geïnitieerde agentgedragingen**: Clients stellen servers in staat om specifieke acties of gedragingen autonoom te starten, wat de dynamische mogelijkheden van het systeem vergroot.
- **Recursieve LLM-interacties**: Deze feature maakt recursieve interacties met grote taalmodellen (LLM’s) mogelijk, waardoor complexere en iteratieve taakverwerking kan plaatsvinden.
- **Aanvragen van extra modelcompleties**: Servers kunnen extra aanvullingen van het model opvragen, zodat de antwoorden grondig en contextueel relevant zijn.

## Informatiestroom in MCP

Het Model Context Protocol (MCP) definieert een gestructureerde informatiestroom tussen hosts, clients, servers en modellen. Het begrijpen van deze stroom verduidelijkt hoe gebruikersverzoeken worden verwerkt en hoe externe tools en data worden geïntegreerd in modelantwoorden.

- **Host initieert verbinding**  
  De hostapplicatie (zoals een IDE of chatinterface) maakt verbinding met een MCP-server, meestal via STDIO, WebSocket of een andere ondersteunde transportlaag.

- **Capabiliteitenonderhandeling**  
  De client (ingebed in de host) en de server wisselen informatie uit over hun ondersteunde features, tools, resources en protocolversies. Dit zorgt ervoor dat beide partijen weten welke mogelijkheden beschikbaar zijn voor de sessie.

- **Gebruikersverzoek**  
  De gebruiker interageert met de host (bijvoorbeeld door een prompt of commando in te voeren). De host verzamelt deze input en geeft deze door aan de client voor verwerking.

- **Gebruik van resource of tool**  
  - De client kan extra context of resources opvragen bij de server (zoals bestanden, database-items of kennisbankartikelen) om het begrip van het model te verrijken.
  - Als het model bepaalt dat een tool nodig is (bijvoorbeeld om data op te halen, een berekening uit te voeren of een API aan te roepen), stuurt de client een toolaanroep naar de server, met de naam van de tool en parameters.

- **Serveruitvoering**  
  De server ontvangt het resource- of toolverzoek, voert de benodigde operaties uit (zoals het draaien van een functie, queryen van een database of ophalen van een bestand) en stuurt de resultaten in een gestructureerd formaat terug naar de client.

- **Genereren van antwoord**  
  De client verwerkt de antwoorden van de server (resourcegegevens, tooloutputs, etc.) in de lopende modelinteractie. Het model gebruikt deze informatie om een uitgebreid en contextueel passend antwoord te genereren.

- **Resultaatpresentatie**  
  De host ontvangt de uiteindelijke output van de client en toont deze aan de gebruiker, vaak inclusief zowel de door het model gegenereerde tekst als eventuele resultaten van tooluitvoeringen of resource-opvragingen.

Deze stroom maakt het MCP mogelijk om geavanceerde, interactieve en contextbewuste AI-toepassingen te ondersteunen door modellen naadloos te verbinden met externe tools en databronnen.

## Protocoldetails

MCP (Model Context Protocol) is gebouwd bovenop [JSON-RPC 2.0](https://www.jsonrpc.org/), en biedt een gestandaardiseerd, taalonafhankelijk berichtformaat voor communicatie tussen hosts, clients en servers. Deze basis maakt betrouwbare, gestructureerde en uitbreidbare interacties mogelijk over diverse platforms en programmeertalen heen.

### Belangrijke Protocolfeatures

MCP breidt JSON-RPC 2.0 uit met extra conventies voor toolaanroepen, resource-toegang en promptbeheer. Het ondersteunt meerdere transportlagen (STDIO, WebSocket, SSE) en maakt veilige, uitbreidbare en taalonafhankelijke communicatie tussen componenten mogelijk.

#### 🧢 Basisprotocol

- **JSON-RPC berichtformaat**: Alle verzoeken en antwoorden gebruiken de JSON-RPC 2.0-specificatie, wat zorgt voor een consistente structuur voor method calls, parameters, resultaten en foutafhandeling.
- **Stateful verbindingen**: MCP-sessies behouden status over meerdere verzoeken heen, wat gesprekken, contextopbouw en resourcebeheer ondersteunt.
- **Capabiliteitenonderhandeling**: Tijdens het opzetten van de verbinding wisselen clients en servers informatie uit over ondersteunde features, protocolversies, beschikbare tools en resources. Dit zorgt dat beide partijen elkaars mogelijkheden begrijpen en zich kunnen aanpassen.

#### ➕ Extra hulpmiddelen

Hieronder enkele extra hulpmiddelen en protocoluitbreidingen die MCP biedt om de ontwikkelaarservaring te verbeteren en geavanceerde scenario’s mogelijk te maken:

- **Configuratieopties**: MCP maakt dynamische configuratie van sessieparameters mogelijk, zoals toolpermissies, resource-toegang en modelinstellingen, afgestemd op elke interactie.
- **Voortgangsbewaking**: Langdurige operaties kunnen voortgangsupdates rapporteren, wat zorgt voor responsieve gebruikersinterfaces en een betere gebruikerservaring bij complexe taken.
- **Annuleren van verzoeken**: Clients kunnen lopende verzoeken annuleren, zodat gebruikers operaties kunnen onderbreken die niet langer nodig zijn of te lang duren.
- **Foutrapportage**: Gestandaardiseerde foutmeldingen en codes helpen bij het diagnosticeren van problemen, het netjes afhandelen van fouten en het geven van bruikbare feedback aan gebruikers en ontwikkelaars.
- **Logging**: Zowel clients als servers kunnen gestructureerde logs genereren voor auditing, debugging en monitoring van protocolinteracties.

Door gebruik te maken van deze protocolfeatures zorgt MCP voor robuuste, veilige en flexibele communicatie tussen taalmodellen en externe tools of databronnen.

### 🔐 Beveiligingsoverwegingen

MCP-implementaties dienen zich te houden aan enkele belangrijke beveiligingsprincipes om veilige en betrouwbare interacties te waarborgen:

- **Gebruikersconsent en controle**: Gebruikers moeten expliciet toestemming geven voordat data wordt benaderd of operaties worden uitgevoerd. Ze moeten duidelijke controle hebben over welke data gedeeld wordt en welke acties zijn toegestaan, ondersteund door intuïtieve gebruikersinterfaces voor het beoordelen en goedkeuren van activiteiten.

- **Dataprivacy**: Gebruikersdata mag alleen met expliciete toestemming worden blootgesteld en moet beschermd worden door passende toegangscontroles. MCP-implementaties moeten ongeautoriseerde datatransmissie voorkomen en privacy gedurende alle interacties waarborgen.

- **Toolveiligheid**: Voor het aanroepen van een tool is expliciete gebruikersconsent vereist. Gebruikers moeten duidelijk begrijpen wat elke tool doet, en er moeten robuuste beveiligingsgrenzen zijn om onbedoelde of onveilige tooluitvoering te voorkomen.

Door deze principes te volgen, zorgt MCP ervoor dat gebruikersvertrouwen, privacy en veiligheid behouden blijven in alle protocolinteracties.

## Codevoorbeelden: Kerncomponenten

Hieronder vind je codevoorbeelden in verschillende populaire programmeertalen die laten zien hoe je belangrijke MCP-servercomponenten en tools kunt implementeren.

### .NET Voorbeeld: Een Eenvoudige MCP Server met Tools Maken

Hier is een praktisch .NET-codevoorbeeld dat laat zien hoe je een eenvoudige MCP-server met aangepaste tools implementeert. Dit voorbeeld toont hoe je tools definieert en registreert, verzoeken afhandelt en de server verbindt via het Model Context Protocol.

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

In dit voorbeeld laten we zien hoe je een MCP-server bouwt in Python. Je ziet ook twee verschillende manieren om tools te maken.

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

# Instantiate the class to register its tools
weather_tools = WeatherTools()

# Start the server using stdio transport
if __name__ == "__main__":
    asyncio.run(serve_stdio(mcp))
```

### JavaScript Voorbeeld: Een MCP Server Maken

Dit voorbeeld laat zien hoe je een MCP-server maakt in JavaScript en hoe je twee weergerelateerde tools registreert.

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

Dit JavaScript-voorbeeld demonstreert hoe je een MCP-client maakt die verbinding maakt met een server, een prompt verstuurt en het antwoord verwerkt, inclusief eventuele toolaanroepen die zijn gedaan.

## Beveiliging en Autorisatie
MCP bevat verschillende ingebouwde concepten en mechanismen voor het beheren van beveiliging en autorisatie binnen het protocol:

1. **Tool Permission Control**:  
  Clients kunnen aangeven welke tools een model mag gebruiken tijdens een sessie. Dit zorgt ervoor dat alleen expliciet geautoriseerde tools toegankelijk zijn, wat het risico op onbedoelde of onveilige handelingen vermindert. Rechten kunnen dynamisch worden ingesteld op basis van gebruikersvoorkeuren, organisatiebeleid of de context van de interactie.

2. **Authenticatie**:  
  Servers kunnen authenticatie vereisen voordat toegang wordt verleend tot tools, bronnen of gevoelige handelingen. Dit kan bijvoorbeeld via API-sleutels, OAuth-tokens of andere authenticatieschema’s. Goede authenticatie zorgt ervoor dat alleen vertrouwde clients en gebruikers server-side functionaliteiten kunnen aanroepen.

3. **Validatie**:  
  Parametervalidatie wordt afgedwongen voor alle tool-aanroepen. Elke tool definieert de verwachte types, formaten en beperkingen voor zijn parameters, en de server valideert binnenkomende verzoeken hierop. Dit voorkomt dat foutieve of kwaadaardige input de tool-implementaties bereikt en helpt de integriteit van de handelingen te waarborgen.

4. **Rate Limiting**:  
  Om misbruik te voorkomen en eerlijk gebruik van serverbronnen te garanderen, kunnen MCP-servers rate limiting toepassen op tool-aanroepen en toegang tot bronnen. Rate limits kunnen per gebruiker, per sessie of globaal worden ingesteld en beschermen tegen denial-of-service aanvallen of overmatig gebruik van resources.

Door deze mechanismen te combineren biedt MCP een veilige basis voor het integreren van taalmodellen met externe tools en databronnen, terwijl gebruikers en ontwikkelaars gedetailleerde controle krijgen over toegang en gebruik.

## Protocolberichten

MCP-communicatie gebruikt gestructureerde JSON-berichten om duidelijke en betrouwbare interacties tussen clients, servers en modellen mogelijk te maken. De belangrijkste berichttypen zijn:

- **Client Request**  
  Verzonden van client naar server, dit bericht bevat meestal:
  - De prompt of opdracht van de gebruiker
  - Gespreksgeschiedenis voor context
  - Toolconfiguratie en rechten
  - Eventuele extra metadata of sessie-informatie

- **Model Response**  
  Teruggegeven door het model (via de client), dit bericht bevat:
  - Gegeneerde tekst of voltooiing op basis van de prompt en context
  - Optionele instructies voor tool-aanroepen als het model bepaalt dat een tool moet worden gebruikt
  - Verwijzingen naar bronnen of extra context indien nodig

- **Tool Request**  
  Verzonden van client naar server wanneer een tool uitgevoerd moet worden. Dit bericht bevat:
  - De naam van de aan te roepen tool
  - Parameters die de tool nodig heeft (gevalideerd volgens het schema van de tool)
  - Contextuele informatie of identificatoren om het verzoek te volgen

- **Tool Response**  
  Teruggegeven door de server na het uitvoeren van een tool. Dit bericht bevat:
  - De resultaten van de tool-uitvoering (gestructureerde data of inhoud)
  - Eventuele fouten of statusinformatie als de tool-aanroep is mislukt
  - Optioneel extra metadata of logs gerelateerd aan de uitvoering

Deze gestructureerde berichten zorgen ervoor dat elke stap in de MCP-werkstroom expliciet, traceerbaar en uitbreidbaar is, en ondersteunen geavanceerde scenario’s zoals meerstapsgesprekken, tool chaining en robuuste foutafhandeling.

## Belangrijkste punten

- MCP gebruikt een client-serverarchitectuur om modellen te verbinden met externe functionaliteiten
- Het ecosysteem bestaat uit clients, hosts, servers, tools en databronnen
- Communicatie kan plaatsvinden via STDIO, SSE of WebSockets
- Tools zijn de fundamentele functionele eenheden die aan modellen worden aangeboden
- Gestructureerde communicatieprotocollen zorgen voor consistente interacties

## Oefening

Ontwerp een eenvoudige MCP-tool die nuttig zou zijn in jouw vakgebied. Definieer:
1. Hoe de tool zou heten
2. Welke parameters de tool zou accepteren
3. Welke output de tool zou teruggeven
4. Hoe een model deze tool zou kunnen gebruiken om gebruikersproblemen op te lossen


---

## Wat volgt

Volgende: [Hoofdstuk 2: Security](../02-Security/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.