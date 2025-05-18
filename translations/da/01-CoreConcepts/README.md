<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:42:28+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "da"
}
-->
# 📖 MCP Core Concepts: Mestring af Model Context Protocol til AI-integration

Model Context Protocol (MCP) er en kraftfuld, standardiseret ramme, der optimerer kommunikationen mellem store sprogmodeller (LLMs) og eksterne værktøjer, applikationer og datakilder. Denne SEO-optimerede guide vil føre dig gennem de centrale begreber i MCP, så du forstår dens klient-server-arkitektur, essentielle komponenter, kommunikationsmekanik og bedste praksis for implementering.

## Oversigt

Denne lektion udforsker den grundlæggende arkitektur og komponenter, der udgør Model Context Protocol (MCP) økosystemet. Du vil lære om klient-server-arkitekturen, nøglekomponenter og kommunikationsmekanismer, der driver MCP-interaktioner.

## 👩‍🎓 Vigtige læringsmål

Ved slutningen af denne lektion vil du:

- Forstå MCP klient-server arkitekturen.
- Identificere roller og ansvar for værter, klienter og servere.
- Analysere de kernefunktioner, der gør MCP til et fleksibelt integrationslag.
- Lære, hvordan information flyder inden for MCP-økosystemet.
- Få praktiske indsigter gennem kodeeksempler i .NET, Java, Python og JavaScript.

## 🔎 MCP Arkitektur: Et dybere kig

MCP-økosystemet er bygget på en klient-server-model. Denne modulære struktur gør det muligt for AI-applikationer at interagere effektivt med værktøjer, databaser, API'er og kontekstuelle ressourcer. Lad os nedbryde denne arkitektur i dens kernekomponenter.

### 1. Værter

I Model Context Protocol (MCP) spiller værter en afgørende rolle som den primære grænseflade, hvorigennem brugere interagerer med protokollen. Værter er applikationer eller miljøer, der initierer forbindelser med MCP-servere for at få adgang til data, værktøjer og prompts. Eksempler på værter inkluderer integrerede udviklingsmiljøer (IDEs) som Visual Studio Code, AI-værktøjer som Claude Desktop, eller specialbyggede agenter designet til specifikke opgaver.

**Værter** er LLM-applikationer, der initierer forbindelser. De:

- Udfører eller interagerer med AI-modeller for at generere svar.
- Initierer forbindelser med MCP-servere.
- Administrerer samtaleflow og brugergrænseflade.
- Kontrollerer tilladelses- og sikkerhedsbegrænsninger.
- Håndterer brugerens samtykke til datadeling og værktøjseksekvering.

### 2. Klienter

Klienter er essentielle komponenter, der letter interaktionen mellem værter og MCP-servere. Klienter fungerer som mellemled, der gør det muligt for værter at få adgang til og udnytte de funktionaliteter, som MCP-servere tilbyder. De spiller en afgørende rolle i at sikre glat kommunikation og effektiv dataudveksling inden for MCP-arkitekturen.

**Klienter** er forbindelser inden for værtsapplikationen. De:

- Sender anmodninger til servere med prompts/instruktioner.
- Forhandler kapaciteter med servere.
- Administrerer værktøjseksekveringsanmodninger fra modeller.
- Behandler og viser svar til brugere.

### 3. Servere

Servere er ansvarlige for at håndtere anmodninger fra MCP-klienter og give passende svar. De administrerer forskellige operationer som datahentning, værktøjseksekvering og promptgenerering. Servere sikrer, at kommunikationen mellem klienter og værter er effektiv og pålidelig, og opretholder integriteten af interaktionsprocessen.

**Servere** er tjenester, der leverer kontekst og kapaciteter. De:

- Registrerer tilgængelige funktioner (ressourcer, prompts, værktøjer)
- Modtager og udfører værktøjskald fra klienten
- Leverer kontekstuel information for at forbedre modelsvar
- Returnerer output tilbage til klienten
- Opretholder tilstand på tværs af interaktioner, når det er nødvendigt

Servere kan udvikles af enhver for at udvide modelkapaciteter med specialiseret funktionalitet.

### 4. Serverfunktioner

Servere i Model Context Protocol (MCP) leverer fundamentale byggesten, der muliggør rige interaktioner mellem klienter, værter og sprogmodeller. Disse funktioner er designet til at forbedre MCP's kapaciteter ved at tilbyde struktureret kontekst, værktøjer og prompts.

MCP-servere kan tilbyde enhver af følgende funktioner:

#### 📑 Ressourcer

Ressourcer i Model Context Protocol (MCP) omfatter forskellige typer kontekst og data, der kan udnyttes af brugere eller AI-modeller. Disse inkluderer:

- **Kontekstuelle data**: Information og kontekst, som brugere eller AI-modeller kan anvende til beslutningstagning og opgaveudførelse.
- **Vidensbaser og dokumentrepositorier**: Samlinger af strukturerede og ustrukturerede data, såsom artikler, manualer og forskningspapirer, der giver værdifuld indsigt og information.
- **Lokale filer og databaser**: Data, der er lagret lokalt på enheder eller inden for databaser, tilgængelige til behandling og analyse.
- **API'er og webtjenester**: Eksterne grænseflader og tjenester, der tilbyder yderligere data og funktionaliteter, hvilket muliggør integration med forskellige online ressourcer og værktøjer.

Et eksempel på en ressource kan være en databaseskema eller en fil, der kan tilgås på følgende måde:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts i Model Context Protocol (MCP) inkluderer forskellige foruddefinerede skabeloner og interaktionsmønstre designet til at strømline brugerarbejdsgange og forbedre kommunikationen. Disse inkluderer:

- **Skabelonmeddelelser og arbejdsgange**: Forstrukturerede meddelelser og processer, der guider brugere gennem specifikke opgaver og interaktioner.
- **Foruddefinerede interaktionsmønstre**: Standardiserede sekvenser af handlinger og svar, der letter konsistent og effektiv kommunikation.
- **Specialiserede samtaleskabeloner**: Tilpasselige skabeloner skræddersyet til specifikke typer samtaler, der sikrer relevante og kontekstuelt passende interaktioner.

En promptskabelon kan se sådan ud:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Værktøjer

Værktøjer i Model Context Protocol (MCP) er funktioner, som AI-modellen kan udføre for at udføre specifikke opgaver. Disse værktøjer er designet til at forbedre AI-modellens kapaciteter ved at tilbyde strukturerede og pålidelige operationer. Vigtige aspekter inkluderer:

- **Funktioner til AI-modellen at udføre**: Værktøjer er eksekverbare funktioner, som AI-modellen kan påkalde for at udføre forskellige opgaver.
- **Unikt navn og beskrivelse**: Hvert værktøj har et særskilt navn og en detaljeret beskrivelse, der forklarer dets formål og funktionalitet.
- **Parametre og output**: Værktøjer accepterer specifikke parametre og returnerer strukturerede output, hvilket sikrer konsistente og forudsigelige resultater.
- **Diskrete funktioner**: Værktøjer udfører diskrete funktioner såsom websøgninger, beregninger og databaseforespørgsler.

Et eksempelværktøj kan se sådan ud:

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

## Klientfunktioner

I Model Context Protocol (MCP) tilbyder klienter flere nøglefunktioner til servere, hvilket forbedrer den samlede funktionalitet og interaktion inden for protokollen. En af de bemærkelsesværdige funktioner er Sampling.

### 👉 Sampling

- **Server-initierede agentiske adfærd**: Klienter gør det muligt for servere at initiere specifikke handlinger eller adfærd autonomt, hvilket forbedrer systemets dynamiske kapaciteter.
- **Rekursive LLM-interaktioner**: Denne funktion muliggør rekursive interaktioner med store sprogmodeller (LLMs), hvilket gør det muligt at udføre mere komplekse og iterative behandlinger af opgaver.
- **Anmodning om yderligere modelkompletteringer**: Servere kan anmode om yderligere kompletteringer fra modellen, hvilket sikrer, at svarene er grundige og kontekstuelt relevante.

## Informationsflow i MCP

Model Context Protocol (MCP) definerer et struktureret flow af information mellem værter, klienter, servere og modeller. Forståelse af dette flow hjælper med at klarlægge, hvordan brugerforespørgsler behandles, og hvordan eksterne værktøjer og data integreres i modelsvar.

- **Vært initierer forbindelse**  
  Værtsapplikationen (såsom en IDE eller chatgrænseflade) etablerer en forbindelse til en MCP-server, typisk via STDIO, WebSocket eller en anden understøttet transport.

- **Kapacitetsforhandling**  
  Klienten (indbygget i værten) og serveren udveksler information om deres understøttede funktioner, værktøjer, ressourcer og protokolversioner. Dette sikrer, at begge parter forstår, hvilke kapaciteter der er tilgængelige for sessionen.

- **Brugeranmodning**  
  Brugeren interagerer med værten (f.eks. indtaster en prompt eller kommando). Værten samler denne input og sender den til klienten til behandling.

- **Ressource- eller værktøjsbrug**  
  - Klienten kan anmode om yderligere kontekst eller ressourcer fra serveren (såsom filer, databaseposter eller vidensbaseartikler) for at berige modellens forståelse.
  - Hvis modellen bestemmer, at et værktøj er nødvendigt (f.eks. for at hente data, udføre en beregning eller kalde en API), sender klienten en værktøjskaldsanmodning til serveren, der specificerer værktøjets navn og parametre.

- **Servereksekvering**  
  Serveren modtager ressource- eller værktøjsanmodningen, udfører de nødvendige operationer (såsom at køre en funktion, forespørge en database eller hente en fil) og returnerer resultaterne til klienten i et struktureret format.

- **Svargenerering**  
  Klienten integrerer serverens svar (ressourcedata, værktøjsoutput osv.) i den igangværende modelinteraktion. Modellen bruger denne information til at generere et omfattende og kontekstuelt relevant svar.

- **Resultatpræsentation**  
  Værten modtager det endelige output fra klienten og præsenterer det for brugeren, ofte inklusive både modellens genererede tekst og eventuelle resultater fra værktøjseksekveringer eller ressourceopslag.

Dette flow gør det muligt for MCP at understøtte avancerede, interaktive og kontekstbevidste AI-applikationer ved problemfrit at forbinde modeller med eksterne værktøjer og datakilder.

## Protokoldetaljer

MCP (Model Context Protocol) er bygget oven på [JSON-RPC 2.0](https://www.jsonrpc.org/), hvilket giver et standardiseret, sprog-agnostisk meddelelsesformat til kommunikation mellem værter, klienter og servere. Denne grundlag muliggør pålidelige, strukturerede og udvidelige interaktioner på tværs af forskellige platforme og programmeringssprog.

### Nøgleprotokol-funktioner

MCP udvider JSON-RPC 2.0 med yderligere konventioner for værktøjskald, ressourceadgang og promptstyring. Det understøtter flere transportlag (STDIO, WebSocket, SSE) og muliggør sikker, udvidelig og sprog-agnostisk kommunikation mellem komponenter.

#### 🧢 Basisprotokol

- **JSON-RPC meddelelsesformat**: Alle anmodninger og svar bruger JSON-RPC 2.0-specifikationen, hvilket sikrer en konsistent struktur for metodekald, parametre, resultater og fejlhåndtering.
- **Stateful forbindelser**: MCP-sessioner opretholder tilstand på tværs af flere anmodninger, understøtter igangværende samtaler, kontekstakkumulering og ressourceadministration.
- **Kapacitetsforhandling**: Under forbindelsesopsætning udveksler klienter og servere information om understøttede funktioner, protokolversioner, tilgængelige værktøjer og ressourcer. Dette sikrer, at begge parter forstår hinandens kapaciteter og kan tilpasse sig derefter.

#### ➕ Yderligere værktøjer

Nedenfor er nogle yderligere værktøjer og protokolludvidelser, som MCP tilbyder for at forbedre udvikleroplevelsen og muliggøre avancerede scenarier:

- **Konfigurationsmuligheder**: MCP tillader dynamisk konfiguration af sessionsparametre, såsom værktøjstilladelser, ressourceadgang og modelindstillinger, skræddersyet til hver interaktion.
- **Fremskridtsopfølgning**: Langvarige operationer kan rapportere fremskridtsopdateringer, hvilket muliggør responsive brugergrænseflader og bedre brugeroplevelse under komplekse opgaver.
- **Anmodningsannullering**: Klienter kan annullere igangværende anmodninger, hvilket giver brugere mulighed for at afbryde operationer, der ikke længere er nødvendige eller tager for lang tid.
- **Fejlrapportering**: Standardiserede fejlmeddelelser og koder hjælper med at diagnosticere problemer, håndtere fejl yndefuldt og give brugere og udviklere handlingsrettet feedback.
- **Logning**: Både klienter og servere kan udsende strukturerede logs til revision, fejlfinding og overvågning af protokolinteraktioner.

Ved at udnytte disse protokolfunktioner sikrer MCP robust, sikker og fleksibel kommunikation mellem sprogmodeller og eksterne værktøjer eller datakilder.

### 🔐 Sikkerhedsovervejelser

MCP-implementeringer bør overholde flere nøgleprincipper for sikkerhed for at sikre sikre og pålidelige interaktioner:

- **Brugersamtykke og kontrol**: Brugere skal give eksplicit samtykke, før nogen data tilgås eller operationer udføres. De bør have klar kontrol over, hvilke data der deles, og hvilke handlinger der er autoriseret, understøttet af intuitive brugergrænseflader til gennemgang og godkendelse af aktiviteter.

- **Databeskyttelse**: Brugerdata bør kun eksponeres med eksplicit samtykke og skal beskyttes af passende adgangskontroller. MCP-implementeringer skal beskytte mod uautoriseret dataoverførsel og sikre, at privatliv opretholdes gennem alle interaktioner.

- **Værktøjssikkerhed**: Før der påkaldes et værktøj, kræves eksplicit brugersamtykke. Brugere bør have en klar forståelse af hvert værktøjs funktionalitet, og robuste sikkerhedsgrænser skal håndhæves for at forhindre utilsigtet eller usikker værktøjseksekvering.

Ved at følge disse principper sikrer MCP, at brugerens tillid, privatliv og sikkerhed opretholdes på tværs af alle protokolinteraktioner.

## Kodeeksempler: Nøglekomponenter

Nedenfor er kodeeksempler i flere populære programmeringssprog, der illustrerer, hvordan man implementerer nøgle MCP-serverkomponenter og værktøjer.

### .NET Eksempel: Oprettelse af en simpel MCP-server med værktøjer

Her er et praktisk .NET kodeeksempel, der demonstrerer, hvordan man implementerer en simpel MCP-server med brugerdefinerede værktøjer. Dette eksempel viser, hvordan man definerer og registrerer værktøjer, håndterer anmodninger og forbinder serveren ved hjælp af Model Context Protocol.

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

### Java Eksempel: MCP Server Komponenter

Dette eksempel demonstrerer den samme MCP-server og værktøjsregistrering som .NET-eksemplet ovenfor, men implementeret i Java.

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

I dette eksempel viser vi, hvordan man bygger en MCP-server i Python. Du bliver også vist to forskellige måder at oprette værktøjer på.

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

### JavaScript Eksempel: Oprettelse af en MCP-server

Dette eksempel viser MCP-serveroprettelse i JavaScript og viser, hvordan man registrerer to værktøjer relateret til vejret.

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

Dette JavaScript-eksempel demonstrerer, hvordan man opretter en MCP-klient, der forbinder til en server, sender en prompt og behandler svaret inklusive eventuelle værktøjskald, der blev foretaget.

## Sikkerhed og autorisation

MCP inkluderer flere indbyggede begreber og mekanismer til styring af sikkerhed og autorisation gennem protokollen:

1. **Værktøjstilladelseskontrol**:  
  Klienter kan specificere, hvilke værktøjer en model har lov til at bruge under en session. Dette sikrer, at kun eksplicit autoriserede værktøjer er tilgængelige, hvilket reducerer risikoen for utilsigtede eller usikre operationer. Tilladelser kan konfigureres dynamisk baseret på brugerpræferencer, organisatoriske politikker eller interaktionens kontekst.

2. **Autentifikation**:  
  Servere kan kræve autentifikation, før der gives adgang til

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for misforståelser eller fejltolkninger, der måtte opstå ved brug af denne oversættelse.