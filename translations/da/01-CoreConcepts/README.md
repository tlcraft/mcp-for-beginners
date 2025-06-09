<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:30:26+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "da"
}
-->
# 📖 MCP Core Concepts: At mestre Model Context Protocol for AI-integration

Model Context Protocol (MCP) er en kraftfuld, standardiseret ramme, der optimerer kommunikationen mellem Large Language Models (LLMs) og eksterne værktøjer, applikationer og datakilder. Denne SEO-optimerede guide tager dig igennem de grundlæggende koncepter i MCP og sikrer, at du forstår dens klient-server arkitektur, centrale komponenter, kommunikationsmekanismer og bedste implementeringspraksis.

## Oversigt

Denne lektion undersøger den grundlæggende arkitektur og de komponenter, der udgør Model Context Protocol (MCP) økosystemet. Du vil lære om klient-server arkitekturen, nøglekomponenter og kommunikationsmekanismer, der driver MCP-interaktioner.

## 👩‍🎓 Centrale læringsmål

Når du er færdig med denne lektion, vil du:

- Forstå MCP's klient-server arkitektur.
- Identificere roller og ansvar for Hosts, Clients og Servers.
- Analysere de centrale funktioner, der gør MCP til et fleksibelt integrationslag.
- Lære hvordan information flyder inden for MCP-økosystemet.
- Få praktisk indsigt gennem kodeeksempler i .NET, Java, Python og JavaScript.

## 🔎 MCP Arkitektur: Et dybere kig

MCP-økosystemet er bygget på en klient-server model. Denne modulære struktur gør det muligt for AI-applikationer effektivt at interagere med værktøjer, databaser, API'er og kontekstuelle ressourcer. Lad os gennemgå denne arkitektur i dens kernekomponenter.

### 1. Hosts

I Model Context Protocol (MCP) spiller Hosts en afgørende rolle som det primære interface, hvorigennem brugere interagerer med protokollen. Hosts er applikationer eller miljøer, der initierer forbindelser til MCP-servere for at få adgang til data, værktøjer og prompts. Eksempler på Hosts inkluderer integrerede udviklingsmiljøer (IDEs) som Visual Studio Code, AI-værktøjer som Claude Desktop eller specialbyggede agenter designet til specifikke opgaver.

**Hosts** er LLM-applikationer, der starter forbindelser. De:

- Udfører eller interagerer med AI-modeller for at generere svar.
- Initierer forbindelser med MCP-servere.
- Styrer samtaleforløbet og brugergrænsefladen.
- Kontrollerer tilladelser og sikkerhedsbegrænsninger.
- Håndterer brugerens samtykke til datadeling og værktøjsudførelse.

### 2. Clients

Clients er væsentlige komponenter, der faciliterer interaktionen mellem Hosts og MCP-servere. Clients fungerer som mellemled, der gør det muligt for Hosts at tilgå og anvende funktionaliteter leveret af MCP-servere. De spiller en vigtig rolle i at sikre smidig kommunikation og effektiv dataudveksling i MCP-arkitekturen.

**Clients** er forbindelser inden for host-applikationen. De:

- Sender forespørgsler til servere med prompts/instruktioner.
- Forhandler kapabiliteter med servere.
- Håndterer anmodninger om værktøjsudførelse fra modeller.
- Behandler og viser svar til brugerne.

### 3. Servers

Servers er ansvarlige for at håndtere forespørgsler fra MCP-klienter og levere passende svar. De administrerer forskellige operationer som datahentning, værktøjsudførelse og promptgenerering. Servers sikrer, at kommunikationen mellem clients og Hosts er effektiv og pålidelig, og opretholder integriteten af interaktionsprocessen.

**Servers** er services, der leverer kontekst og funktionaliteter. De:

- Registrerer tilgængelige funktioner (ressourcer, prompts, værktøjer).
- Modtager og udfører værktøjskald fra klienten.
- Leverer kontekstuel information for at forbedre modelrespons.
- Returnerer output til klienten.
- Vedligeholder tilstand på tværs af interaktioner, når det er nødvendigt.

Servers kan udvikles af alle for at udvide modellens funktionaliteter med specialiseret funktionalitet.

### 4. Server Features

Servers i Model Context Protocol (MCP) leverer grundlæggende byggesten, der muliggør rige interaktioner mellem clients, hosts og sprogmodeller. Disse funktioner er designet til at forbedre MCP’s kapabiliteter ved at tilbyde struktureret kontekst, værktøjer og prompts.

MCP-servers kan tilbyde en eller flere af følgende funktioner:

#### 📑 Resources

Ressourcer i Model Context Protocol (MCP) omfatter forskellige typer kontekst og data, som brugere eller AI-modeller kan bruge. Disse inkluderer:

- **Kontekstuelle data**: Information og kontekst, som brugere eller AI-modeller kan anvende til beslutningstagning og opgaveudførelse.
- **Vidensbaser og dokumentarkiver**: Samlinger af strukturerede og ustrukturerede data, såsom artikler, manualer og forskningspapirer, der giver værdifuld indsigt og information.
- **Lokale filer og databaser**: Data gemt lokalt på enheder eller i databaser, tilgængelige til behandling og analyse.
- **API’er og webservices**: Eksterne interfaces og services, der tilbyder yderligere data og funktionaliteter, hvilket muliggør integration med forskellige online ressourcer og værktøjer.

Et eksempel på en resource kan være et databaseskema eller en fil, der kan tilgås således:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts i Model Context Protocol (MCP) inkluderer forskellige foruddefinerede skabeloner og interaktionsmønstre designet til at strømline brugerflows og forbedre kommunikationen. Disse inkluderer:

- **Skabelonbeskeder og workflows**: Forstrukturerede beskeder og processer, der guider brugere gennem specifikke opgaver og interaktioner.
- **Foruddefinerede interaktionsmønstre**: Standardiserede sekvenser af handlinger og svar, der sikrer konsekvent og effektiv kommunikation.
- **Specialiserede samtaleskabeloner**: Tilpassede skabeloner, der er målrettet specifikke samtaletyper for at sikre relevante og kontekstuelle interaktioner.

En promptskabelon kan se sådan ud:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Værktøjer i Model Context Protocol (MCP) er funktioner, som AI-modellen kan udføre for at løse specifikke opgaver. Disse værktøjer er designet til at udvide AI-modellens kapabiliteter ved at tilbyde strukturerede og pålidelige operationer. Nøglepunkter inkluderer:

- **Funktioner, som AI-modellen kan udføre**: Værktøjer er eksekverbare funktioner, som AI-modellen kan kalde for at udføre forskellige opgaver.
- **Unikt navn og beskrivelse**: Hvert værktøj har et unikt navn og en detaljeret beskrivelse, der forklarer formål og funktionalitet.
- **Parametre og output**: Værktøjer modtager specifikke parametre og returnerer strukturerede output, hvilket sikrer konsistente og forudsigelige resultater.
- **Diskrete funktioner**: Værktøjer udfører specifikke funktioner som web-søgninger, beregninger og databaseforespørgsler.

Et eksempel på et værktøj kan se sådan ud:

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

I Model Context Protocol (MCP) tilbyder clients flere nøglefunktioner til servers, der forbedrer den samlede funktionalitet og interaktion i protokollen. En af de bemærkelsesværdige funktioner er Sampling.

### 👉 Sampling

- **Server-initierede agentbaserede handlinger**: Clients muliggør, at servers kan initiere specifikke handlinger eller adfærd autonomt, hvilket øger systemets dynamiske kapabiliteter.
- **Rekursive LLM-interaktioner**: Denne funktion tillader rekursive interaktioner med store sprogmodeller (LLMs), hvilket muliggør mere komplekse og iterative opgavebehandlinger.
- **Anmodning om yderligere modelkompletteringer**: Servers kan anmode om ekstra fuldførelser fra modellen for at sikre, at svarene er grundige og kontekstuelt relevante.

## Informationsflow i MCP

Model Context Protocol (MCP) definerer et struktureret informationsflow mellem hosts, clients, servers og modeller. At forstå dette flow hjælper med at klarlægge, hvordan brugerforespørgsler behandles, og hvordan eksterne værktøjer og data integreres i modelrespons.

- **Host initierer forbindelse**  
  Host-applikationen (f.eks. et IDE eller chat-interface) etablerer en forbindelse til en MCP-server, typisk via STDIO, WebSocket eller en anden understøttet transport.

- **Kapabilitetsforhandling**  
  Clienten (indlejret i hosten) og serveren udveksler information om deres understøttede funktioner, værktøjer, ressourcer og protokolversioner. Dette sikrer, at begge parter forstår, hvilke kapabiliteter der er tilgængelige i sessionen.

- **Brugerforespørgsel**  
  Brugeren interagerer med hosten (f.eks. ved at indtaste en prompt eller kommando). Hosten indsamler input og sender det videre til clienten til behandling.

- **Brug af ressourcer eller værktøj**  
  - Clienten kan anmode om yderligere kontekst eller ressourcer fra serveren (såsom filer, databaseposter eller vidensbaseartikler) for at berige modellens forståelse.
  - Hvis modellen vurderer, at et værktøj er nødvendigt (f.eks. til at hente data, udføre en beregning eller kalde en API), sender clienten en anmodning om værktøjskald til serveren, hvor værktøjets navn og parametre specificeres.

- **Serverudførelse**  
  Serveren modtager ressource- eller værktøjsanmodningen, udfører de nødvendige operationer (som at køre en funktion, forespørge en database eller hente en fil) og returnerer resultaterne til clienten i et struktureret format.

- **Responsgenerering**  
  Clienten integrerer serverens svar (ressourcedata, værktøjsoutput osv.) i den igangværende modelinteraktion. Modellen bruger denne information til at generere et omfattende og kontekstuelt relevant svar.

- **Resultatpræsentation**  
  Hosten modtager det endelige output fra clienten og præsenterer det for brugeren, ofte med både den genererede tekst fra modellen og eventuelle resultater fra værktøjsudførelser eller ressourcelookups.

Dette flow gør det muligt for MCP at understøtte avancerede, interaktive og kontekstbevidste AI-applikationer ved sømløst at forbinde modeller med eksterne værktøjer og datakilder.

## Protokol Detaljer

MCP (Model Context Protocol) er bygget oven på [JSON-RPC 2.0](https://www.jsonrpc.org/), hvilket giver et standardiseret, sprogagnostisk beskedformat til kommunikation mellem hosts, clients og servers. Dette fundament muliggør pålidelige, strukturerede og udvidelige interaktioner på tværs af forskellige platforme og programmeringssprog.

### Centrale Protokolfunktioner

MCP udvider JSON-RPC 2.0 med yderligere konventioner for værktøjskald, ressourceadgang og promptstyring. Det understøtter flere transportlag (STDIO, WebSocket, SSE) og muliggør sikker, udvidelig og sprogagnostisk kommunikation mellem komponenter.

#### 🧢 Grundprotokol

- **JSON-RPC beskedformat**: Alle forespørgsler og svar følger JSON-RPC 2.0 specifikationen, hvilket sikrer en ensartet struktur for metodekald, parametre, resultater og fejlbehandling.
- **Stateful forbindelser**: MCP-sessioner opretholder tilstand på tværs af flere forespørgsler, hvilket understøtter løbende samtaler, kontekstakkumulering og ressourcehåndtering.
- **Kapabilitetsforhandling**: Under forbindelseopsætning udveksler clients og servers information om understøttede funktioner, protokolversioner, tilgængelige værktøjer og ressourcer. Dette sikrer, at begge parter forstår hinandens kapabiliteter og kan tilpasse sig.

#### ➕ Yderligere hjælpefunktioner

Her er nogle ekstra hjælpefunktioner og protokoludvidelser, som MCP tilbyder for at forbedre udvikleroplevelsen og muliggøre avancerede scenarier:

- **Konfigurationsmuligheder**: MCP tillader dynamisk konfiguration af sessionparametre, såsom værktøjstilladelser, ressourceadgang og modelindstillinger, tilpasset hver interaktion.
- **Progressionssporing**: Langvarige operationer kan rapportere statusopdateringer, hvilket muliggør responsive brugerflader og bedre brugeroplevelse under komplekse opgaver.
- **Annullering af forespørgsler**: Clients kan afbryde igangværende forespørgsler, så brugere kan stoppe operationer, der ikke længere er nødvendige eller tager for lang tid.
- **Fejlrapportering**: Standardiserede fejlbeskeder og -koder hjælper med fejlfinding, håndtering af fejl på en elegant måde og giver brugbare tilbagemeldinger til brugere og udviklere.
- **Logning**: Både clients og servers kan udsende strukturerede logs til revision, fejlfinding og overvågning af protokolinteraktioner.

Ved at udnytte disse protokolfunktioner sikrer MCP robust, sikker og fleksibel kommunikation mellem sprogmodeller og eksterne værktøjer eller datakilder.

### 🔐 Sikkerhedsovervejelser

MCP-implementeringer bør følge flere nøgleprincipper for sikkerhed for at sikre sikre og pålidelige interaktioner:

- **Brugersamtykke og kontrol**: Brugere skal give eksplicit samtykke, før data tilgås eller operationer udføres. De bør have klar kontrol over, hvilke data der deles, og hvilke handlinger der godkendes, understøttet af intuitive brugergrænseflader til gennemgang og godkendelse.

- **Databeskyttelse**: Brugerdata må kun deles med eksplicit samtykke og skal beskyttes af passende adgangskontroller. MCP-implementeringer skal forhindre uautoriseret datatransmission og sikre, at privatliv opretholdes i alle interaktioner.

- **Værktøjssikkerhed**: Før et værktøj kaldes, kræves eksplicit brugersamtykke. Brugere skal have en klar forståelse af hvert værktøjs funktionalitet, og der skal håndhæves robuste sikkerhedsgrænser for at forhindre utilsigtet eller usikker værktøjsudførelse.

Ved at følge disse principper sikrer MCP, at brugerens tillid, privatliv og sikkerhed opretholdes gennem alle protokolinteraktioner.

## Kodeeksempler: Centrale komponenter

Nedenfor er kodeeksempler i flere populære programmeringssprog, der illustrerer, hvordan man implementerer centrale MCP-serverkomponenter og værktøjer.

### .NET Eksempel: Oprettelse af en simpel MCP-server med værktøjer

Her er et praktisk .NET kodeeksempel, der viser, hvordan man implementerer en simpel MCP-server med brugerdefinerede værktøjer. Eksemplet demonstrerer, hvordan man definerer og registrerer værktøjer, håndterer forespørgsler og forbinder serveren via Model Context Protocol.

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

### Java Eksempel: MCP-serverkomponenter

Dette eksempel viser den samme MCP-server og værktøjsregistrering som .NET-eksemplet ovenfor, men implementeret i Java.

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

### Python Eksempel: Bygning af en MCP-server

I dette eksempel viser vi, hvordan man bygger en MCP-server i Python. Du får også vist to forskellige måder at oprette værktøjer på.

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

### JavaScript Eksempel: Oprettelse af en MCP-server

Dette eksempel viser oprettelse af MCP-server i JavaScript og hvordan man registrerer to vejrrelaterede værktøjer.

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

Dette JavaScript-eksempel demonstrerer, hvordan man opretter en MCP-client, der forbinder til en server, sender en prompt og behandler svaret, inklusive eventuelle værktøjskald, der blev foretaget.

## Sikkerhed og autorisation

MCP inkluderer flere indbyggede koncepter og mekanismer til håndtering af sikkerhed og autorisation i hele protokollen:

1. **Kontrol af værktøjstilladelser**  
   Clients kan specificere, hvilke værktøjer en model må bruge under en session. Det sikrer, at kun eksplicit autoriserede værktøjer er tilgængelige, hvilket mindsker risikoen for utilsigtede eller usikre handlinger. Tilladelser kan konfigureres dynamisk baseret på brugerpræferencer, organisatoriske politikker eller konteksten for interaktionen.

2. **Autentifikation**  
   Servers kan kræve autentifikation, før adgang gives til værktøjer, ressourcer eller følsomme operationer. Dette kan involvere API-nøgler, OAuth-tokens eller andre autentifikationsmetoder. Korrekt autentifikation sikrer, at kun betroede clients og brugere kan kalde serverfunktionaliteter.

3. **Validering**  
   Parameter-validering håndhæves for alle værktøjskald. Hvert værktøj definerer forventede typer, formater og begrænsninger for sine parametre, og serveren validerer indkommende forespørgsler i overensstemmelse hermed. Dette forhind

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.