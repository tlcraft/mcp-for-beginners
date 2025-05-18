<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:46:11+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "nl"
}
-->
# 📖 MCP Kernconcepten: Beheersing van het Model Context Protocol voor AI-integratie

Het Model Context Protocol (MCP) is een krachtig, gestandaardiseerd kader dat de communicatie tussen Grote Taalmodellen (LLMs) en externe tools, applicaties en databronnen optimaliseert. Deze SEO-geoptimaliseerde gids leidt je door de kernconcepten van MCP, zodat je de client-serverarchitectuur, essentiële componenten, communicatiemechanismen en implementatiebest practices begrijpt.

## Overzicht

Deze les verkent de fundamentele architectuur en componenten die het Model Context Protocol (MCP) ecosysteem vormen. Je leert over de client-serverarchitectuur, belangrijke componenten en communicatiemechanismen die MCP-interacties aandrijven.

## 👩‍🎓 Belangrijke Leerdoelen

Aan het einde van deze les zul je:

- De MCP client-serverarchitectuur begrijpen.
- Rollen en verantwoordelijkheden van Hosts, Clients en Servers identificeren.
- De kernkenmerken analyseren die MCP een flexibel integratielaag maken.
- Leren hoe informatie stroomt binnen het MCP ecosysteem.
- Praktische inzichten verwerven door middel van codevoorbeelden in .NET, Java, Python en JavaScript.

## 🔎 MCP Architectuur: Een Dieper Inzicht

Het MCP ecosysteem is gebouwd op een client-servermodel. Deze modulaire structuur stelt AI-applicaties in staat om efficiënt te communiceren met tools, databases, API's en contextuele bronnen. Laten we deze architectuur opdelen in zijn kerncomponenten.

### 1. Hosts

In het Model Context Protocol (MCP) spelen Hosts een cruciale rol als de primaire interface waarmee gebruikers met het protocol communiceren. Hosts zijn applicaties of omgevingen die verbindingen initiëren met MCP-servers om toegang te krijgen tot data, tools en prompts. Voorbeelden van Hosts zijn geïntegreerde ontwikkelomgevingen (IDEs) zoals Visual Studio Code, AI-tools zoals Claude Desktop, of speciaal gebouwde agents voor specifieke taken.

**Hosts** zijn LLM-applicaties die verbindingen initiëren. Ze:

- Voeren uit of interacteren met AI-modellen om reacties te genereren.
- Initiëren verbindingen met MCP-servers.
- Beheren de gespreksstroom en gebruikersinterface.
- Controleren permissies en beveiligingsbeperkingen.
- Behandelen gebruikersconsent voor gegevensdeling en tooluitvoering.

### 2. Clients

Clients zijn essentiële componenten die de interactie tussen Hosts en MCP-servers faciliteren. Clients fungeren als tussenpersonen, waardoor Hosts toegang krijgen tot en gebruik kunnen maken van de functionaliteiten die door MCP-servers worden geboden. Ze spelen een cruciale rol in het waarborgen van soepele communicatie en efficiënte gegevensuitwisseling binnen de MCP-architectuur.

**Clients** zijn connectoren binnen de hostapplicatie. Ze:

- Verzenden verzoeken naar servers met prompts/instructies.
- Onderhandelen over mogelijkheden met servers.
- Beheren tooluitvoeringsverzoeken van modellen.
- Verwerken en tonen reacties aan gebruikers.

### 3. Servers

Servers zijn verantwoordelijk voor het afhandelen van verzoeken van MCP-clients en het bieden van passende reacties. Ze beheren verschillende operaties zoals gegevensopvraging, tooluitvoering en promptgeneratie. Servers zorgen ervoor dat de communicatie tussen clients en Hosts efficiënt en betrouwbaar is, waarbij de integriteit van het interactieproces wordt behouden.

**Servers** zijn diensten die context en mogelijkheden bieden. Ze:

- Registreren beschikbare functies (bronnen, prompts, tools)
- Ontvangen en voeren tooloproepen uit van de client
- Bieden contextuele informatie om modelreacties te verbeteren
- Geven outputs terug aan de client
- Behouden de staat over interacties indien nodig

Servers kunnen door iedereen worden ontwikkeld om modelmogelijkheden uit te breiden met gespecialiseerde functionaliteit.

### 4. Serverfuncties

Servers in het Model Context Protocol (MCP) bieden fundamentele bouwstenen die rijke interacties tussen clients, hosts en taalmodellen mogelijk maken. Deze functies zijn ontworpen om de mogelijkheden van MCP te verbeteren door gestructureerde context, tools en prompts aan te bieden.

MCP-servers kunnen een van de volgende functies bieden:

#### 📑 Bronnen

Bronnen in het Model Context Protocol (MCP) omvatten verschillende soorten context en data die door gebruikers of AI-modellen kunnen worden gebruikt. Deze omvatten:

- **Contextuele Data**: Informatie en context die gebruikers of AI-modellen kunnen benutten voor besluitvorming en taakuitvoering.
- **Kennisbanken en Documentenarchieven**: Collecties van gestructureerde en ongestructureerde data, zoals artikelen, handleidingen en onderzoeksdocumenten, die waardevolle inzichten en informatie bieden.
- **Lokale Bestanden en Databases**: Data opgeslagen lokaal op apparaten of binnen databases, toegankelijk voor verwerking en analyse.
- **API's en Webdiensten**: Externe interfaces en diensten die aanvullende data en functionaliteiten bieden, waardoor integratie met verschillende online bronnen en tools mogelijk is.

Een voorbeeld van een bron kan een databaseschema of een bestand zijn dat als volgt toegankelijk is:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts in het Model Context Protocol (MCP) omvatten verschillende vooraf gedefinieerde sjablonen en interactiepatronen die zijn ontworpen om gebruikersworkflows te stroomlijnen en communicatie te verbeteren. Deze omvatten:

- **Gesjabloneerde Berichten en Workflows**: Vooraf gestructureerde berichten en processen die gebruikers door specifieke taken en interacties leiden.
- **Vooraf Gedefinieerde Interactiepatronen**: Gestandaardiseerde reeksen van acties en reacties die consistente en efficiënte communicatie vergemakkelijken.
- **Gespecialiseerde Gesprekssjablonen**: Aanpasbare sjablonen op maat voor specifieke soorten gesprekken, waardoor relevante en contextueel passende interacties worden verzekerd.

Een promptsjabloon kan er als volgt uitzien:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Tools in het Model Context Protocol (MCP) zijn functies die het AI-model kan uitvoeren om specifieke taken uit te voeren. Deze tools zijn ontworpen om de mogelijkheden van het AI-model te verbeteren door gestructureerde en betrouwbare operaties te bieden. Belangrijke aspecten zijn:

- **Functies voor het AI-model om uit te voeren**: Tools zijn uitvoerbare functies die het AI-model kan aanroepen om verschillende taken uit te voeren.
- **Unieke Naam en Beschrijving**: Elke tool heeft een unieke naam en een gedetailleerde beschrijving die het doel en de functionaliteit ervan uitlegt.
- **Parameters en Outputs**: Tools accepteren specifieke parameters en geven gestructureerde outputs terug, wat consistente en voorspelbare resultaten verzekert.
- **Discrete Functies**: Tools voeren discrete functies uit zoals webzoekopdrachten, berekeningen en databasequeries.

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

In het Model Context Protocol (MCP) bieden clients verschillende belangrijke functies aan servers, waardoor de algehele functionaliteit en interactie binnen het protocol wordt verbeterd. Een van de opmerkelijke functies is Sampling.

### 👉 Sampling

- **Server-geïnitieerde Agentgedragingen**: Clients stellen servers in staat om specifieke acties of gedragingen autonoom te initiëren, waardoor de dynamische mogelijkheden van het systeem worden verbeterd.
- **Recursieve LLM-interacties**: Deze functie maakt recursieve interacties met grote taalmodellen (LLMs) mogelijk, waardoor meer complexe en iteratieve verwerking van taken mogelijk wordt.
- **Aanvullende Modelvoltooiingen aanvragen**: Servers kunnen aanvullende voltooiingen van het model aanvragen, zodat de reacties grondig en contextueel relevant zijn.

## Informatiedoorstroming in MCP

Het Model Context Protocol (MCP) definieert een gestructureerde stroom van informatie tussen hosts, clients, servers en modellen. Het begrijpen van deze stroom helpt om duidelijkheid te scheppen over hoe gebruikersverzoeken worden verwerkt en hoe externe tools en data worden geïntegreerd in modelreacties.

- **Host Initieert Verbinding**  
  De hostapplicatie (zoals een IDE of chatinterface) stelt een verbinding met een MCP-server in, meestal via STDIO, WebSocket of een andere ondersteunde transportlaag.

- **Capaciteitsonderhandeling**  
  De client (ingebed in de host) en de server wisselen informatie uit over hun ondersteunde functies, tools, bronnen en protocolversies. Dit zorgt ervoor dat beide partijen begrijpen welke mogelijkheden beschikbaar zijn voor de sessie.

- **Gebruikersverzoek**  
  De gebruiker interageert met de host (bijv. voert een prompt of commando in). De host verzamelt deze invoer en geeft deze door aan de client voor verwerking.

- **Gebruik van Bron of Tool**  
  - De client kan aanvullende context of bronnen van de server aanvragen (zoals bestanden, database-invoer of kennisbankartikelen) om het begrip van het model te verrijken.
  - Als het model bepaalt dat een tool nodig is (bijv. om data op te halen, een berekening uit te voeren of een API aan te roepen), stuurt de client een tooloproepverzoek naar de server, waarbij de toolnaam en parameters worden gespecificeerd.

- **Serveruitvoering**  
  De server ontvangt het bron- of toolverzoek, voert de benodigde operaties uit (zoals het uitvoeren van een functie, het opvragen van een database of het ophalen van een bestand) en retourneert de resultaten aan de client in een gestructureerd formaat.

- **Reactiegeneratie**  
  De client integreert de reacties van de server (brondata, tooloutputs, enz.) in de lopende modelinteractie. Het model gebruikt deze informatie om een uitgebreide en contextueel relevante reactie te genereren.

- **Resultaatpresentatie**  
  De host ontvangt de uiteindelijke output van de client en presenteert deze aan de gebruiker, vaak inclusief zowel de door het model gegenereerde tekst als eventuele resultaten van tooluitvoeringen of bronopzoekingen.

Deze stroom stelt MCP in staat om geavanceerde, interactieve en contextbewuste AI-applicaties te ondersteunen door modellen naadloos te verbinden met externe tools en databronnen.

## Protocoldetails

MCP (Model Context Protocol) is gebouwd bovenop [JSON-RPC 2.0](https://www.jsonrpc.org/), wat een gestandaardiseerd, taalonafhankelijk berichtformaat biedt voor communicatie tussen hosts, clients en servers. Deze basis stelt betrouwbare, gestructureerde en uitbreidbare interacties mogelijk over diverse platforms en programmeertalen.

### Belangrijke Protocolfuncties

MCP breidt JSON-RPC 2.0 uit met aanvullende conventies voor tooloproep, bronaccess en promptbeheer. Het ondersteunt meerdere transportlagen (STDIO, WebSocket, SSE) en maakt veilige, uitbreidbare en taalonafhankelijke communicatie tussen componenten mogelijk.

#### 🧢 Basisprotocol

- **JSON-RPC Berichtformaat**: Alle verzoeken en reacties gebruiken de JSON-RPC 2.0 specificatie, wat een consistente structuur verzekert voor methodeoproepen, parameters, resultaten en foutafhandeling.
- **Stateful Verbindingen**: MCP-sessies behouden de staat over meerdere verzoeken, ondersteunen lopende gesprekken, contextaccumulatie en bronbeheer.
- **Capaciteitsonderhandeling**: Tijdens de verbindingopstelling wisselen clients en servers informatie uit over ondersteunde functies, protocolversies, beschikbare tools en bronnen. Dit zorgt ervoor dat beide partijen elkaars mogelijkheden begrijpen en zich dienovereenkomstig kunnen aanpassen.

#### ➕ Aanvullende Hulpmiddelen

Hieronder staan enkele aanvullende hulpmiddelen en protocolextensies die MCP biedt om de ontwikkelaarservaring te verbeteren en geavanceerde scenario's mogelijk te maken:

- **Configuratieopties**: MCP staat dynamische configuratie van sessieparameters toe, zoals toolpermissies, bronaccess en modelinstellingen, afgestemd op elke interactie.
- **Voortgangsrapportage**: Langdurige operaties kunnen voortgangsupdates rapporteren, wat responsieve gebruikersinterfaces en betere gebruikerservaringen tijdens complexe taken mogelijk maakt.
- **Verzoekannulering**: Clients kunnen in-flight verzoeken annuleren, waardoor gebruikers operaties kunnen onderbreken die niet langer nodig zijn of te lang duren.
- **Foutrapportage**: Gestandaardiseerde foutberichten en codes helpen bij het diagnosticeren van problemen, het gracieus afhandelen van fouten en het bieden van actiegerichte feedback aan gebruikers en ontwikkelaars.
- **Logging**: Zowel clients als servers kunnen gestructureerde logs uitsturen voor auditing, debugging en monitoring van protocolinteracties.

Door gebruik te maken van deze protocolfuncties, zorgt MCP voor robuuste, veilige en flexibele communicatie tussen taalmodellen en externe tools of databronnen.

### 🔐 Veiligheidsoverwegingen

MCP-implementaties moeten zich houden aan verschillende belangrijke veiligheidsprincipes om veilige en betrouwbare interacties te garanderen:

- **Gebruikersconsent en Controle**: Gebruikers moeten expliciet toestemming geven voordat gegevens worden opgevraagd of operaties worden uitgevoerd. Ze moeten duidelijke controle hebben over welke gegevens worden gedeeld en welke acties zijn toegestaan, ondersteund door intuïtieve gebruikersinterfaces voor het bekijken en goedkeuren van activiteiten.

- **Gegevensprivacy**: Gebruikersgegevens mogen alleen worden blootgesteld met expliciete toestemming en moeten worden beschermd door passende toegangscontroles. MCP-implementaties moeten zich beschermen tegen ongeautoriseerde gegevensoverdracht en ervoor zorgen dat privacy wordt gehandhaafd tijdens alle interacties.

- **Toolveiligheid**: Voordat een tool wordt aangeroepen, is expliciete gebruikersconsent vereist. Gebruikers moeten een duidelijk begrip hebben van de functionaliteit van elke tool, en robuuste beveiligingsgrenzen moeten worden gehandhaafd om onbedoelde of onveilige tooluitvoering te voorkomen.

Door deze principes te volgen, zorgt MCP ervoor dat gebruikersvertrouwen, privacy en veiligheid worden gehandhaafd in alle protocolinteracties.

## Codevoorbeelden: Belangrijke Componenten

Hieronder staan codevoorbeelden in verschillende populaire programmeertalen die illustreren hoe je belangrijke MCP-servercomponenten en tools implementeert.

### .NET Voorbeeld: Een Eenvoudige MCP-server maken met Tools

Hier is een praktisch .NET codevoorbeeld dat demonstreert hoe je een eenvoudige MCP-server met aangepaste tools implementeert. Dit voorbeeld laat zien hoe je tools definieert en registreert, verzoeken afhandelt en de server verbindt met behulp van het Model Context Protocol.

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

Dit voorbeeld demonstreert dezelfde MCP-server en toolregistratie als het .NET voorbeeld hierboven, maar geïmplementeerd in Java.

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

### Python Voorbeeld: Een MCP-server Bouwen

In dit voorbeeld laten we zien hoe je een MCP-server in Python bouwt. Er worden ook twee verschillende manieren getoond om tools te maken.

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

### JavaScript Voorbeeld: Een MCP-server Maken

Dit voorbeeld toont MCP-servercreatie in JavaScript en laat zien hoe je twee tools registreert die gerelateerd zijn aan het weer.

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

Dit JavaScript voorbeeld demonstreert hoe je een MCP-client maakt die verbinding maakt met een server, een prompt verzendt en de reactie verwerkt inclusief eventuele tooloproepen die zijn gedaan.

## Veiligheid en Autorisatie

MCP omvat verschillende ingebouwde concepten en mechanismen voor het beheren van veiligheid en autorisatie door het hele protocol:

1. **Tool Permission Control**:  
  Clients kunnen specificeren welke tools een model tijdens een sessie mag gebruiken. Dit zorgt ervoor dat alleen expliciet geautoriseerde tools toegankelijk zijn, waardoor het risico van onbedoelde of onveilige operaties wordt verminderd. Permissies kunnen dynamisch worden geconfigureerd op basis van gebruikersvoorkeuren, organisatorische beleidsregels of de context van de interactie.

2. **Authenticatie**:  
  Servers kunnen authenticatie vereisen voordat toegang wordt verleend tot tools, bronnen of gevoelige operaties. Dit kan API-sleutels, OAuth-tokens of andere authenticatieschema's omvatten. Juiste authenticatie zorgt ervoor dat alleen vertrouwde clients en gebruikers server-side mogelijkheden kunnen aanroepen.

3. **Validatie**:  
  Parameter validatie wordt afgedwongen voor alle tooloproepen. Elke tool definieert de verwachte types, formaten en beperkingen voor zijn parameters, en de server valideert inkomende verzoeken dienovereenkomstig. Dit voorkomt dat slecht gevormde of kwaadaardige invoer toolimplementaties bereikt en helpt de integriteit van operaties te behouden.

4. **Rate Limiting**:  
  Om misbruik te voorkomen en eerlijk gebruik van serverbronnen te verzekeren, kunnen MCP-servers rate limiting implementeren voor tooloproepen en bronaccess. Rate limits kunnen per gebruiker, per sessie of globaal worden toegepast en helpen beschermen tegen denial-of-service aanvallen of overmatig verbruik van middelen.

Door deze mechanismen te combineren, biedt MCP een veilige basis voor het integreren van taalmodellen met externe tools en databronnen, terwijl gebruikers en ontwikkelaars fijne controle krijgen over toegang en gebruik.

## Protocolberichten

MCP-communicatie gebruikt gestructureerde JSON-berichten om duidelijke en betrouwbare interacties tussen clients, servers en modellen te vergemakkelijken. De belangrijkste berichttypen zijn:

- **Clientverzoek**  
  Verzonden van de client naar de server, bevat dit bericht meestal:
  - De gebruikersprompt of het commando
  - Gesprekshistorie voor context
  - Toolconfiguratie en permissies
  - Eventuele aanvullende metadata of sessie-informatie

- **Modelreactie**  
  Teruggegeven door het model (via de client), bevat dit bericht:
  - Gegenereerde tekst of voltooiing op basis van de prompt en context
  - Optionele tooloproepinstructies als het model bepaalt dat een tool moet worden aangeroepen
  - Verwijzingen naar bronnen of aanvullende context indien nodig

- **Toolverzoek**  
  Verzonden van de client naar de server wanneer een tool moet worden uitgevoerd. Dit bericht bevat:
  - De naam van de tool die moet worden aangeroepen
  - Parameters die door de tool nodig zijn (gevalideerd tegen het schema van de tool)
  - Contextuele informatie of identificatoren voor het volgen van het verzoek

- **Toolreactie**  
  Teruggegeven door de server na het uitvoeren van een tool. Dit bericht biedt:
  - De resultaten van de tooluitvoering (gestructureerde data of inhoud)
  - Eventuele fouten of statusinformatie als de tooloproep is mislukt
  - Optioneel, aanvullende metadata of logs gerelateerd aan de uitvoering

Deze gestructureerde berichten zorgen ervoor dat elke stap in de MCP-workflow expliciet, traceerbaar en uitbreidbaar is, wat geavanceerde scenario's ondersteunt zoals meerledige gesprekken, toolketening en robuuste foutafhandeling.

## Belangrijke Inzichten

- MCP gebruikt een client-serverarchitectuur om modellen te verbinden met externe mogelijkheden
- Het ecosysteem bestaat uit clients, hosts,

**Disclaimer**:
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.