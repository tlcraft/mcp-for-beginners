<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:34:17+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "nl"
}
-->
# 📖 MCP Kernconcepten: Het Model Context Protocol beheersen voor AI-integratie

Het Model Context Protocol (MCP) is een krachtig, gestandaardiseerd kader dat de communicatie tussen Large Language Models (LLM's) en externe tools, applicaties en databronnen optimaliseert. Deze SEO-geoptimaliseerde gids leidt je door de kernconcepten van MCP, zodat je de client-serverarchitectuur, essentiële componenten, communicatiemechanismen en implementatiebest practices begrijpt.

## Overzicht

Deze les behandelt de fundamentele architectuur en componenten die het Model Context Protocol (MCP) ecosysteem vormen. Je leert over de client-serverarchitectuur, de belangrijkste onderdelen en de communicatiemechanismen die MCP-interacties mogelijk maken.

## 👩‍🎓 Belangrijkste leerdoelen

Aan het einde van deze les zul je:

- De MCP client-serverarchitectuur begrijpen.
- De rollen en verantwoordelijkheden van Hosts, Clients en Servers kunnen benoemen.
- De kernfuncties analyseren die MCP tot een flexibele integratielaag maken.
- Begrijpen hoe informatie binnen het MCP-ecosysteem stroomt.
- Praktische inzichten opdoen via codevoorbeelden in .NET, Java, Python en JavaScript.

## 🔎 MCP Architectuur: Een diepere blik

Het MCP-ecosysteem is gebouwd op een client-servermodel. Deze modulaire structuur stelt AI-toepassingen in staat efficiënt te communiceren met tools, databases, API’s en contextuele bronnen. Laten we deze architectuur opdelen in de kerncomponenten.

### 1. Hosts

In het Model Context Protocol (MCP) spelen Hosts een cruciale rol als de primaire interface waarlangs gebruikers met het protocol communiceren. Hosts zijn applicaties of omgevingen die verbinding maken met MCP-servers om toegang te krijgen tot data, tools en prompts. Voorbeelden van Hosts zijn geïntegreerde ontwikkelomgevingen (IDE’s) zoals Visual Studio Code, AI-tools zoals Claude Desktop, of op maat gemaakte agents voor specifieke taken.

**Hosts** zijn LLM-applicaties die verbindingen initiëren. Zij:

- Voeren AI-modellen uit of communiceren ermee om antwoorden te genereren.
- Starten verbindingen met MCP-servers.
- Beheren de gespreksstroom en gebruikersinterface.
- Controleren machtigingen en beveiligingsbeperkingen.
- Verwerken gebruikersconsent voor het delen van data en het uitvoeren van tools.

### 2. Clients

Clients zijn essentiële componenten die de interactie tussen Hosts en MCP-servers faciliteren. Clients fungeren als tussenpersonen, waardoor Hosts de functionaliteiten van MCP-servers kunnen gebruiken. Ze zorgen voor soepele communicatie en efficiënte gegevensuitwisseling binnen de MCP-architectuur.

**Clients** zijn connectors binnen de hostapplicatie. Zij:

- Versturen verzoeken naar servers met prompts/instructies.
- Onderhandelen over mogelijkheden met servers.
- Beheren verzoeken voor tooluitvoering vanuit modellen.
- Verwerken en tonen reacties aan gebruikers.

### 3. Servers

Servers zijn verantwoordelijk voor het afhandelen van verzoeken van MCP-clients en het leveren van passende antwoorden. Ze beheren verschillende taken zoals data ophalen, tooluitvoering en promptgeneratie. Servers zorgen ervoor dat de communicatie tussen clients en Hosts efficiënt en betrouwbaar verloopt, en bewaken de integriteit van het interactieproces.

**Servers** zijn services die context en functionaliteiten bieden. Zij:

- Registreren beschikbare functies (resources, prompts, tools).
- Ontvangen en voeren toolaanroepen van de client uit.
- Bieden contextuele informatie om modelantwoorden te verbeteren.
- Sturen output terug naar de client.
- Onderhouden de status gedurende interacties indien nodig.

Servers kunnen door iedereen worden ontwikkeld om modelmogelijkheden uit te breiden met gespecialiseerde functionaliteit.

### 4. Serverfuncties

Servers binnen het Model Context Protocol (MCP) bieden fundamentele bouwstenen die rijke interacties tussen clients, hosts en taalmodellen mogelijk maken. Deze functies zijn ontworpen om de mogelijkheden van MCP te vergroten door gestructureerde context, tools en prompts aan te bieden.

MCP-servers kunnen een of meer van de volgende functies leveren:

#### 📑 Resources

Resources in het Model Context Protocol (MCP) omvatten diverse soorten context en data die gebruikers of AI-modellen kunnen gebruiken. Dit zijn onder andere:

- **Contextuele data**: Informatie en context die gebruikers of AI-modellen kunnen inzetten voor besluitvorming en taakuitvoering.
- **Kennisbanken en documentrepositories**: Verzameling van gestructureerde en ongestructureerde data, zoals artikelen, handleidingen en onderzoeksrapporten, die waardevolle inzichten bieden.
- **Lokale bestanden en databases**: Data die lokaal op apparaten of in databases is opgeslagen en toegankelijk is voor verwerking en analyse.
- **API’s en webservices**: Externe interfaces en diensten die extra data en functionaliteiten bieden, waardoor integratie met diverse online bronnen en tools mogelijk is.

Een voorbeeld van een resource kan een databaseschema of een bestand zijn dat op deze manier toegankelijk is:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts in het Model Context Protocol (MCP) omvatten diverse vooraf gedefinieerde sjablonen en interactiepatronen die workflows stroomlijnen en communicatie verbeteren. Dit zijn onder andere:

- **Vooraf gestructureerde berichten en workflows**: Vooraf opgestelde berichten en processen die gebruikers begeleiden bij specifieke taken en interacties.
- **Vooraf gedefinieerde interactiepatronen**: Gestandaardiseerde reeksen acties en reacties die consistente en efficiënte communicatie bevorderen.
- **Gespecialiseerde gespreksjablonen**: Aanpasbare sjablonen voor specifieke gesprekstypen, die zorgen voor relevante en contextueel passende interacties.

Een promptsjabloon kan er als volgt uitzien:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Tools in het Model Context Protocol (MCP) zijn functies die het AI-model kan uitvoeren om specifieke taken te volbrengen. Deze tools zijn ontworpen om de mogelijkheden van het AI-model uit te breiden door gestructureerde en betrouwbare operaties te bieden. Belangrijke kenmerken zijn:

- **Functies die het AI-model kan uitvoeren**: Tools zijn uitvoerbare functies die het AI-model kan aanroepen om verschillende taken uit te voeren.
- **Unieke naam en omschrijving**: Elke tool heeft een duidelijke naam en een uitgebreide beschrijving die het doel en de functionaliteit uitlegt.
- **Parameters en outputs**: Tools accepteren specifieke parameters en leveren gestructureerde resultaten, wat zorgt voor consistente en voorspelbare uitkomsten.
- **Afgebakende functies**: Tools voeren discrete taken uit, zoals webzoekopdrachten, berekeningen en databasequery’s.

Een voorbeeld van een tool kan er als volgt uitzien:

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

## Clientfuncties

In het Model Context Protocol (MCP) bieden clients verschillende belangrijke functies aan servers, waarmee de functionaliteit en interactie binnen het protocol worden verbeterd. Een opvallende functie is Sampling.

### 👉 Sampling

- **Server-geïnitieerde agentgedragingen**: Clients maken het mogelijk dat servers specifieke acties of gedragingen autonoom starten, wat de dynamische mogelijkheden van het systeem vergroot.
- **Recursieve LLM-interacties**: Deze functie maakt recursieve interacties met grote taalmodellen (LLM’s) mogelijk, waardoor complexere en iteratieve taakverwerking kan plaatsvinden.
- **Aanvragen van extra modelcompletions**: Servers kunnen extra antwoorden van het model opvragen, zodat de reacties volledig en contextueel relevant zijn.

## Informatiestroom in MCP

Het Model Context Protocol (MCP) definieert een gestructureerde informatiestroom tussen hosts, clients, servers en modellen. Inzicht in deze stroom verduidelijkt hoe gebruikersverzoeken worden verwerkt en hoe externe tools en data worden geïntegreerd in modelantwoorden.

- **Host start verbinding**  
  De hostapplicatie (zoals een IDE of chatinterface) maakt verbinding met een MCP-server, meestal via STDIO, WebSocket of een andere ondersteunde transportlaag.

- **Capaciteiten onderhandelen**  
  De client (ingebed in de host) en de server wisselen informatie uit over hun ondersteunde functies, tools, resources en protocolversies. Dit zorgt ervoor dat beide partijen weten welke mogelijkheden beschikbaar zijn voor de sessie.

- **Gebruikersverzoek**  
  De gebruiker communiceert met de host (bijvoorbeeld door een prompt of commando in te voeren). De host verzamelt deze input en geeft deze door aan de client voor verwerking.

- **Gebruik van resource of tool**  
  - De client kan extra context of resources opvragen bij de server (zoals bestanden, database-items of kennisbankartikelen) om het begrip van het model te verrijken.
  - Als het model bepaalt dat een tool nodig is (bijvoorbeeld om data op te halen, een berekening uit te voeren of een API aan te roepen), stuurt de client een tool-aanroepverzoek naar de server, inclusief de toolnaam en parameters.

- **Serveruitvoering**  
  De server ontvangt het resource- of toolverzoek, voert de benodigde acties uit (zoals een functie draaien, een database queryen of een bestand ophalen) en stuurt de resultaten in een gestructureerd formaat terug naar de client.

- **Antwoordgeneratie**  
  De client verwerkt de reacties van de server (resourcegegevens, tooloutputs, etc.) in de lopende modelinteractie. Het model gebruikt deze informatie om een volledig en contextueel passend antwoord te genereren.

- **Resultaatpresentatie**  
  De host ontvangt de uiteindelijke output van de client en toont deze aan de gebruiker, vaak met zowel de door het model gegenereerde tekst als eventuele resultaten van tooluitvoeringen of resource-opzoekingen.

Deze stroom maakt het MCP mogelijk om geavanceerde, interactieve en contextbewuste AI-toepassingen te ondersteunen door modellen naadloos te verbinden met externe tools en databronnen.

## Protocoldetails

MCP (Model Context Protocol) is gebouwd bovenop [JSON-RPC 2.0](https://www.jsonrpc.org/), wat een gestandaardiseerd, taalonafhankelijk berichtformaat biedt voor communicatie tussen hosts, clients en servers. Deze basis maakt betrouwbare, gestructureerde en uitbreidbare interacties mogelijk op diverse platforms en programmeertalen.

### Belangrijke protocolkenmerken

MCP breidt JSON-RPC 2.0 uit met extra conventies voor toolaanroepen, resource-toegang en promptbeheer. Het ondersteunt meerdere transportlagen (STDIO, WebSocket, SSE) en maakt veilige, uitbreidbare en taalagnostische communicatie tussen componenten mogelijk.

#### 🧢 Basisprotocol

- **JSON-RPC berichtformaat**: Alle verzoeken en antwoorden volgen de JSON-RPC 2.0-specificatie, wat zorgt voor een consistente structuur voor method calls, parameters, resultaten en foutafhandeling.
- **Stateful verbindingen**: MCP-sessies behouden status over meerdere verzoeken heen, wat voortdurende gesprekken, contextopbouw en resourcebeheer ondersteunt.
- **Capaciteitenonderhandeling**: Tijdens het opzetten van de verbinding wisselen clients en servers informatie uit over ondersteunde functies, protocolversies, beschikbare tools en resources. Dit zorgt ervoor dat beide kanten elkaars mogelijkheden begrijpen en zich kunnen aanpassen.

#### ➕ Extra hulpmiddelen

Hieronder enkele extra hulpmiddelen en protocoluitbreidingen die MCP biedt om de ontwikkelaarservaring te verbeteren en geavanceerde scenario’s mogelijk te maken:

- **Configuratieopties**: MCP maakt dynamische configuratie van sessieparameters mogelijk, zoals toolmachtigingen, resource-toegang en modelinstellingen, afgestemd op elke interactie.
- **Voortgangsrapportage**: Langdurige operaties kunnen voortgangsupdates versturen, wat zorgt voor responsieve gebruikersinterfaces en een betere gebruikerservaring bij complexe taken.
- **Annuleren van verzoeken**: Clients kunnen lopende verzoeken annuleren, waardoor gebruikers operaties kunnen stoppen die niet meer nodig zijn of te lang duren.
- **Foutrapportage**: Gestandaardiseerde foutmeldingen en codes helpen bij het diagnosticeren van problemen, het netjes afhandelen van fouten en het bieden van bruikbare feedback aan gebruikers en ontwikkelaars.
- **Logging**: Zowel clients als servers kunnen gestructureerde logs genereren voor auditing, debugging en monitoring van protocolinteracties.

Door gebruik te maken van deze protocolkenmerken zorgt MCP voor robuuste, veilige en flexibele communicatie tussen taalmodellen en externe tools of databronnen.

### 🔐 Beveiligingsoverwegingen

MCP-implementaties dienen verschillende belangrijke beveiligingsprincipes te volgen om veilige en betrouwbare interacties te waarborgen:

- **Gebruikersconsent en controle**: Gebruikers moeten expliciet toestemming geven voordat data wordt benaderd of acties worden uitgevoerd. Ze moeten duidelijk controle hebben over welke data gedeeld wordt en welke handelingen zijn toegestaan, ondersteund door intuïtieve interfaces om activiteiten te beoordelen en goed te keuren.

- **Dataprivacy**: Gebruikersdata mag alleen met expliciete toestemming worden gedeeld en moet beschermd worden door passende toegangscontrole. MCP-implementaties moeten ongeautoriseerde datatransmissie voorkomen en privacy gedurende alle interacties waarborgen.

- **Toolveiligheid**: Voor het aanroepen van tools is expliciete gebruikersgoedkeuring vereist. Gebruikers moeten duidelijk begrijpen wat elke tool doet, en er moeten robuuste beveiligingsgrenzen zijn om ongewenste of onveilige tooluitvoering te voorkomen.

Door deze principes te volgen, zorgt MCP ervoor dat gebruikersvertrouwen, privacy en veiligheid behouden blijven in alle protocolinteracties.

## Codevoorbeelden: Kerncomponenten

Hieronder vind je codevoorbeelden in verschillende populaire programmeertalen die laten zien hoe je belangrijke MCP-servercomponenten en tools implementeert.

### .NET Voorbeeld: Een eenvoudige MCP-server met tools maken

Hier is een praktisch .NET-codevoorbeeld waarin wordt getoond hoe je een eenvoudige MCP-server met aangepaste tools implementeert. Dit voorbeeld laat zien hoe je tools definieert en registreert, verzoeken afhandelt en de server koppelt via het Model Context Protocol.

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

### Java Voorbeeld: MCP-servercomponenten

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

### Python Voorbeeld: Een MCP-server bouwen

In dit voorbeeld laten we zien hoe je een MCP-server bouwt in Python. Ook tonen we twee verschillende manieren om tools te maken.

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

### JavaScript Voorbeeld: Een MCP-server maken

Dit voorbeeld laat zien hoe je een MCP-server creëert in JavaScript en hoe je twee weergerelateerde tools registreert.

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

Dit JavaScript-voorbeeld laat zien hoe je een MCP-client maakt die verbinding maakt met een server, een prompt verstuurt en de reactie verwerkt, inclusief eventuele tool-aanroepen.

## Beveiliging en autorisatie

MCP bevat verschillende ingebouwde concepten en mechanismen om beveiliging en autorisatie binnen het protocol te beheren:

1. **Toolmachtigingsbeheer**  
  Clients kunnen aangeven welke tools een model tijdens een sessie mag gebruiken. Dit zorgt ervoor dat alleen expliciet geautoriseerde tools toegankelijk zijn, wat het risico op onbedoelde of onveilige acties vermindert. Machtigingen kunnen dynamisch worden ingesteld op basis van gebruikersvoorkeuren, organisatorisch beleid of de context van de interactie.

2. **Authenticatie**  
  Servers kunnen authenticatie vereisen voordat toegang wordt verleend tot tools, resources of gevoelige operaties. Dit kan API-sleutels, OAuth-tokens of andere authenticatieschema’s omvatten. Goede authenticatie zorgt ervoor dat alleen vertrouwde clients en gebruikers servermogelijkheden kunnen aanroepen.

3. **Validatie**  
  Parametervalidatie wordt afgedwongen bij alle toolaanroepen. Elke tool definieert de verwachte types, formaten en beperkingen voor zijn parameters, en de server valideert inkomende verzoeken dienovereenkomstig. Dit voorkomt dat foutieve of kwaadaardige input de toolimplementaties bereikt en helpt de integriteit van operaties te waarborgen.

4. **Rate limiting**  
  Om misbruik te voorkomen en eerlijke verdeling van serverbronnen te garanderen, kunnen MCP-servers rate limiting toepassen op toolaanroepen en resource-toegang. Limieten kunnen per gebruiker, sessie of globaal worden ingesteld en beschermen tegen denial-of-service-aanvallen of overmatig resourcegebruik.

Door deze mechanismen te combineren, biedt MCP een veilige basis voor het integreren van taalmodellen met externe tools en databronnen, terwijl gebruikers en ontwikkelaars fijnmazige controle krijgen over toegang en gebruik.

## Protocolberichten

MCP-communicatie maakt gebruik van gestructureerde JSON-berichten om heldere en betrouwbare interacties tussen clients, servers en modellen mogelijk te maken. De belangrijkste berichttypen zijn:

- **Clientverzoek**  
  Verstuurt de client naar de server en bevat meestal:
  - De prompt of het commando van de gebruiker
  - Gespreksgeschiedenis voor context
  - Toolconfiguratie en machtigingen
  - Eventuele extra metadata of sessie-informatie

- **Modelantwoord**  
  Wordt door het model (via de client) teruggegeven en bevat:
  - Tekst of completion gegenereerd op basis van prompt en context
  - Optionele instructies voor toolaanroepen als het model een tool wil gebruiken
  - Verwijzingen naar resources of extra context indien nodig

- **Toolverzoek**  
  Verstuurt de client naar de server wanneer een tool uitgevoerd moet worden. Dit bericht bevat:
  - De naam van de aan te roepen tool
  - Parameters die de tool nodig heeft (gevalideerd tegen het toolschema)
  - Contextuele informatie of identifiers voor het volgen van het verzoek

- **Toolantwoord**  
  Wordt door de server teruggestuurd na het uitvoeren van een tool. Dit bericht bevat:
  - De resultaten van de tooluitvoering (gestructureerde data of content)
  - Eventuele fouten of statusinformatie als de toolaanroep mislukte
  - Optioneel extra metadata of logs over de uitvoering

Deze gestructureerde berichten zorgen ervoor dat elke stap in de MCP-werkstroom expliciet, traceerbaar en uitbreidbaar is, en ondersteunen geavanceerde scenario’s zoals meertrapsgesprekken, toolketens en robuuste foutafhandeling.

## Belangrijkste punten

- MCP gebruikt een client-serverarchitectuur om modellen met externe functionaliteiten te verbinden
- Het ecosysteem bestaat uit clients, hosts, servers, tools en databronnen
- Communicatie kan via STDIO, SSE of WebSockets plaatsvinden
- Tools zijn de fundamentele functionele eenheden die aan modellen worden aangeboden
- Gestructureerde communicatieprotocollen zorgen voor consistente interacties

## Oefening

Ontwerp een eenvoudige MCP-tool die nuttig zou zijn in jouw vakgebied. Definieer:

1. Hoe de tool zou heten  
2. Welke parameters de tool accepteert  
3. Welke output de tool teruggeeft  
4. Hoe een model deze tool zou kunnen gebruiken om gebruikersproblemen op te lossen

---

## Wat volgt

Volgende: [Hoofdstuk 

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.