<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "355b12a5970c5c9e6db0bee970c751ba",
  "translation_date": "2025-07-13T16:07:07+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sv"
}
-->
# 📖 MCP Core Concepts: Bemästra Model Context Protocol för AI-integration

[Model Context Protocol (MCP)](https://github.com/modelcontextprotocol) är ett kraftfullt, standardiserat ramverk som optimerar kommunikationen mellan stora språkmodeller (LLM) och externa verktyg, applikationer och datakällor. Denna SEO-optimerade guide tar dig igenom MCP:s kärnkoncept och säkerställer att du förstår dess klient-server-arkitektur, viktiga komponenter, kommunikationsmekanik och bästa praxis för implementering.

## Översikt

Denna lektion utforskar den grundläggande arkitekturen och komponenterna som utgör Model Context Protocol (MCP)-ekosystemet. Du kommer att lära dig om klient-server-arkitekturen, nyckelkomponenter och kommunikationsmekanismer som driver MCP-interaktioner.

## 👩‍🎓 Viktiga lärandemål

I slutet av denna lektion kommer du att:

- Förstå MCP:s klient-server-arkitektur.
- Identifiera roller och ansvar för Hosts, Clients och Servers.
- Analysera de kärnfunktioner som gör MCP till ett flexibelt integrationslager.
- Lära dig hur information flödar inom MCP-ekosystemet.
- Få praktiska insikter genom kodexempel i .NET, Java, Python och JavaScript.

## 🔎 MCP-arkitektur: En djupare titt

MCP-ekosystemet bygger på en klient-server-modell. Denna modulära struktur gör det möjligt för AI-applikationer att effektivt interagera med verktyg, databaser, API:er och kontextuella resurser. Låt oss bryta ner denna arkitektur i dess kärnkomponenter.

I grunden följer MCP en klient-server-arkitektur där en host-applikation kan ansluta till flera servrar:

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

- **MCP Hosts**: Program som VSCode, Claude Desktop, IDE:er eller AI-verktyg som vill få tillgång till data via MCP
- **MCP Clients**: Protokollklienter som upprätthåller 1:1-anslutningar med servrar
- **MCP Servers**: Lättviktiga program som var och en exponerar specifika funktioner genom det standardiserade Model Context Protocol
- **Lokala datakällor**: Din dators filer, databaser och tjänster som MCP-servrar kan komma åt på ett säkert sätt
- **Fjärrtjänster**: Externa system tillgängliga över internet som MCP-servrar kan ansluta till via API:er.

MCP-protokollet är en pågående standard, du kan se de senaste uppdateringarna i [protokollspecificeringen](https://modelcontextprotocol.io/specification/2025-06-18/)

### 1. Hosts

I Model Context Protocol (MCP) spelar Hosts en avgörande roll som den primära gränssnittet genom vilket användare interagerar med protokollet. Hosts är applikationer eller miljöer som initierar anslutningar med MCP-servrar för att få tillgång till data, verktyg och prompts. Exempel på Hosts inkluderar integrerade utvecklingsmiljöer (IDE:er) som Visual Studio Code, AI-verktyg som Claude Desktop eller specialbyggda agenter för specifika uppgifter.

**Hosts** är LLM-applikationer som initierar anslutningar. De:

- Kör eller interagerar med AI-modeller för att generera svar.
- Initierar anslutningar med MCP-servrar.
- Hanterar konversationsflödet och användargränssnittet.
- Kontrollerar behörigheter och säkerhetsbegränsningar.
- Hanterar användarens samtycke för datadelning och verktygsexekvering.

### 2. Clients

Clients är viktiga komponenter som underlättar interaktionen mellan Hosts och MCP-servrar. Clients fungerar som mellanhänder och gör det möjligt för Hosts att få tillgång till och använda funktionaliteter som MCP-servrar tillhandahåller. De spelar en avgörande roll för att säkerställa smidig kommunikation och effektiv datautbyte inom MCP-arkitekturen.

**Clients** är kopplingar inom host-applikationen. De:

- Skickar förfrågningar till servrar med prompts/instruktioner.
- Förhandlar om funktioner med servrar.
- Hanterar verktygsexekveringsförfrågningar från modeller.
- Bearbetar och visar svar till användare.

### 3. Servers

Servers ansvarar för att hantera förfrågningar från MCP-klienter och ge lämpliga svar. De hanterar olika operationer som datahämtning, verktygsexekvering och promptgenerering. Servrar säkerställer att kommunikationen mellan klienter och Hosts är effektiv och pålitlig, och upprätthåller integriteten i interaktionsprocessen.

**Servers** är tjänster som tillhandahåller kontext och funktioner. De:

- Registrerar tillgängliga funktioner (resurser, prompts, verktyg)
- Tar emot och utför verktygsanrop från klienten
- Tillhandahåller kontextuell information för att förbättra modellens svar
- Returnerar resultat tillbaka till klienten
- Behåller tillstånd över interaktioner vid behov

Servrar kan utvecklas av vem som helst för att utöka modellens kapabiliteter med specialiserad funktionalitet.

### 4. Serverfunktioner

Servrar i Model Context Protocol (MCP) tillhandahåller grundläggande byggstenar som möjliggör rika interaktioner mellan klienter, hosts och språkmodeller. Dessa funktioner är utformade för att förbättra MCP:s kapabiliteter genom att erbjuda strukturerad kontext, verktyg och prompts.

MCP-servrar kan erbjuda någon av följande funktioner:

#### 📑 Resurser

Resurser i Model Context Protocol (MCP) omfattar olika typer av kontext och data som kan användas av användare eller AI-modeller. Dessa inkluderar:

- **Kontextuell data**: Information och kontext som användare eller AI-modeller kan använda för beslutsfattande och uppgiftsutförande.
- **Kunskapsbaser och dokumentarkiv**: Samlingar av strukturerad och ostrukturerad data, såsom artiklar, manualer och forskningspapper, som ger värdefulla insikter och information.
- **Lokala filer och databaser**: Data som lagras lokalt på enheter eller i databaser, tillgängliga för bearbetning och analys.
- **API:er och webbtjänster**: Externa gränssnitt och tjänster som erbjuder ytterligare data och funktioner, vilket möjliggör integration med olika online-resurser och verktyg.

Ett exempel på en resurs kan vara ett databasschema eller en fil som kan nås på följande sätt:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts i Model Context Protocol (MCP) inkluderar olika fördefinierade mallar och interaktionsmönster som är utformade för att effektivisera användarflöden och förbättra kommunikationen. Dessa inkluderar:

- **Mallade meddelanden och arbetsflöden**: Förstrukturerade meddelanden och processer som vägleder användare genom specifika uppgifter och interaktioner.
- **Fördefinierade interaktionsmönster**: Standardiserade sekvenser av åtgärder och svar som underlättar konsekvent och effektiv kommunikation.
- **Specialiserade konversationsmallar**: Anpassningsbara mallar skräddarsydda för specifika typer av samtal, vilket säkerställer relevanta och kontextuellt passande interaktioner.

En promptmall kan se ut så här:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Verktyg

Verktyg i Model Context Protocol (MCP) är funktioner som AI-modellen kan köra för att utföra specifika uppgifter. Dessa verktyg är utformade för att förbättra AI-modellens kapabiliteter genom att erbjuda strukturerade och pålitliga operationer. Viktiga aspekter inkluderar:

- **Funktioner som AI-modellen kan köra**: Verktyg är exekverbara funktioner som AI-modellen kan anropa för att utföra olika uppgifter.
- **Unikt namn och beskrivning**: Varje verktyg har ett distinkt namn och en detaljerad beskrivning som förklarar dess syfte och funktionalitet.
- **Parametrar och utdata**: Verktyg tar emot specifika parametrar och returnerar strukturerade resultat, vilket säkerställer konsekventa och förutsägbara utfall.
- **Diskreta funktioner**: Verktyg utför avgränsade funktioner som webbsökningar, beräkningar och databasfrågor.

Ett exempel på ett verktyg kan se ut så här:

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

## Klientfunktioner

I Model Context Protocol (MCP) erbjuder klienter flera viktiga funktioner till servrar, vilket förbättrar den övergripande funktionaliteten och interaktionen inom protokollet. En av de mest framträdande funktionerna är Sampling.

### 👉 Sampling

- **Serverinitierade agentiska beteenden**: Klienter möjliggör för servrar att initiera specifika åtgärder eller beteenden autonomt, vilket förbättrar systemets dynamiska kapabiliteter.
- **Rekursiva LLM-interaktioner**: Denna funktion tillåter rekursiva interaktioner med stora språkmodeller (LLM), vilket möjliggör mer komplex och iterativ bearbetning av uppgifter.
- **Begäran om ytterligare modellkompletteringar**: Servrar kan begära ytterligare svar från modellen för att säkerställa att svaren är grundliga och kontextuellt relevanta.

## Informationsflöde i MCP

Model Context Protocol (MCP) definierar ett strukturerat informationsflöde mellan hosts, clients, servrar och modeller. Att förstå detta flöde hjälper till att klargöra hur användarförfrågningar bearbetas och hur externa verktyg och data integreras i modellsvar.

- **Host initierar anslutning**  
  Host-applikationen (t.ex. en IDE eller chattgränssnitt) etablerar en anslutning till en MCP-server, vanligtvis via STDIO, WebSocket eller annan stödjad transport.

- **Funktionförhandling**  
  Klienten (inbäddad i hosten) och servern utbyter information om sina stödda funktioner, verktyg, resurser och protokollversioner. Detta säkerställer att båda parter förstår vilka kapabiliteter som finns tillgängliga för sessionen.

- **Användarförfrågan**  
  Användaren interagerar med hosten (t.ex. anger en prompt eller ett kommando). Hosten samlar in denna input och skickar den till klienten för bearbetning.

- **Användning av resurs eller verktyg**  
  - Klienten kan begära ytterligare kontext eller resurser från servern (såsom filer, databasposter eller artiklar från kunskapsbas) för att berika modellens förståelse.  
  - Om modellen bedömer att ett verktyg behövs (t.ex. för att hämta data, utföra en beräkning eller anropa ett API), skickar klienten en verktygsanropsförfrågan till servern med verktygets namn och parametrar.

- **Serverexekvering**  
  Servern tar emot resurs- eller verktygsförfrågan, utför nödvändiga operationer (som att köra en funktion, fråga en databas eller hämta en fil) och returnerar resultaten till klienten i ett strukturerat format.

- **Svarsgenerering**  
  Klienten integrerar serverns svar (resursdata, verktygsutdata etc.) i den pågående modellinteraktionen. Modellen använder denna information för att generera ett omfattande och kontextuellt relevant svar.

- **Resultatpresentation**  
  Hosten tar emot det slutgiltiga resultatet från klienten och presenterar det för användaren, ofta inklusive både modellens genererade text och eventuella resultat från verktygsexekveringar eller resursuppslag.

Detta flöde möjliggör att MCP kan stödja avancerade, interaktiva och kontextmedvetna AI-applikationer genom att sömlöst koppla modeller till externa verktyg och datakällor.

## Protokolldetaljer

MCP (Model Context Protocol) bygger på [JSON-RPC 2.0](https://www.jsonrpc.org/), vilket ger ett standardiserat, språkoberoende meddelandeformat för kommunikation mellan hosts, clients och servrar. Denna grund möjliggör pålitliga, strukturerade och utbyggbara interaktioner över olika plattformar och programmeringsspråk.

### Viktiga protokollfunktioner

MCP utökar JSON-RPC 2.0 med ytterligare konventioner för verktygsanrop, resursåtkomst och prompthantering. Det stödjer flera transportlager (STDIO, WebSocket, SSE) och möjliggör säker, utbyggbar och språkoberoende kommunikation mellan komponenter.

#### 🧢 Basprotokoll

- **JSON-RPC-meddelandformat**: Alla förfrågningar och svar följer JSON-RPC 2.0-specifikationen, vilket säkerställer konsekvent struktur för metodanrop, parametrar, resultat och felhantering.
- **Stateful-anslutningar**: MCP-sessioner behåller tillstånd över flera förfrågningar, vilket stödjer pågående konversationer, kontextackumulering och resursförvaltning.
- **Funktionförhandling**: Under anslutningsuppbyggnad utbyter klienter och servrar information om stödda funktioner, protokollversioner, tillgängliga verktyg och resurser. Detta säkerställer att båda parter förstår varandras kapabiliteter och kan anpassa sig därefter.

#### ➕ Ytterligare verktyg

Nedan följer några extra verktyg och protokollförlängningar som MCP erbjuder för att förbättra utvecklarupplevelsen och möjliggöra avancerade scenarier:

- **Konfigurationsalternativ**: MCP tillåter dynamisk konfiguration av sessionsparametrar, såsom verktygstillstånd, resursåtkomst och modellinställningar, anpassade för varje interaktion.
- **Framstegsspårning**: Långvariga operationer kan rapportera framsteg, vilket möjliggör responsiva användargränssnitt och bättre användarupplevelse vid komplexa uppgifter.
- **Avbrytande av förfrågningar**: Klienter kan avbryta pågående förfrågningar, vilket låter användare stoppa operationer som inte längre behövs eller tar för lång tid.
- **Felrapportering**: Standardiserade felmeddelanden och koder hjälper till att diagnostisera problem, hantera fel smidigt och ge användbar återkoppling till användare och utvecklare.
- **Loggning**: Både klienter och servrar kan generera strukturerade loggar för revision, felsökning och övervakning av protokollinteraktioner.

Genom att utnyttja dessa protokollfunktioner säkerställer MCP robust, säker och flexibel kommunikation mellan språkmodeller och externa verktyg eller datakällor.

### 🔐 Säkerhetsaspekter

MCP-implementationer bör följa flera viktiga säkerhetsprinciper för att garantera säkra och pålitliga interaktioner:

- **Användarsamtycke och kontroll**: Användare måste ge uttryckligt samtycke innan någon data nås eller operationer utförs. De ska ha tydlig kontroll över vilken data som delas och vilka åtgärder som godkänns, understödda av intuitiva användargränssnitt för granskning och godkännande.

- **Datasekretess**: Användardata ska endast exponeras med uttryckligt samtycke och måste skyddas med lämpliga åtkomstkontroller. MCP-implementationer måste skydda mot obehörig datatransmission och säkerställa att sekretess upprätthålls i alla interaktioner.

- **Verktygssäkerhet**: Innan något verktyg anropas krävs uttryckligt användarsamtycke. Användare ska ha en klar förståelse för varje verktygs funktionalitet, och robusta säkerhetsgränser måste upprätthållas för att förhindra oavsiktlig eller osäker verktygsexekvering.

Genom att följa dessa principer säkerställer MCP att användarnas förtroende, integritet och säkerhet upprätthålls i alla protokollinteraktioner.

## Kodexempel: Nyckelkomponenter

Nedan följer kodexempel i flera populära programmeringsspråk som illustrerar hur man implementerar viktiga MCP-serverkomponenter och verktyg.

### .NET-exempel: Skapa en enkel MCP-server med verktyg

Här är ett praktiskt .NET-kodexempel som visar hur man implementerar en enkel MCP-server med anpassade verktyg. Exemplet visar hur man definierar och registrerar verktyg, hanterar förfrågningar och ansluter servern med Model Context Protocol.

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

### Java-exempel: MCP-serverkomponenter

Detta exempel visar samma MCP-server och verktygsregistrering som .NET-exemplet ovan, men implementerat i Java.

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

### Python-exempel: Bygga en MCP-server

I detta exempel visar vi hur man bygger en MCP-server i Python. Du får också se två olika sätt att skapa verktyg.

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

### JavaScript-exempel: Skapa en MCP-server

Detta exempel visar skapandet av en MCP-server i JavaScript och hur man registrerar två väderrelaterade verktyg.

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

Detta JavaScript-exempel visar hur man skapar en MCP-klient som ans
MCP inkluderar flera inbyggda koncept och mekanismer för att hantera säkerhet och auktorisering genom hela protokollet:

1. **Verktygstillståndskontroll**:  
  Klienter kan specificera vilka verktyg en modell får använda under en session. Detta säkerställer att endast uttryckligen auktoriserade verktyg är tillgängliga, vilket minskar risken för oavsiktliga eller osäkra operationer. Behörigheter kan konfigureras dynamiskt baserat på användarpreferenser, organisationspolicyer eller interaktionskontext.

2. **Autentisering**:  
  Servrar kan kräva autentisering innan åtkomst ges till verktyg, resurser eller känsliga operationer. Detta kan innebära API-nycklar, OAuth-token eller andra autentiseringsmetoder. Korrekt autentisering säkerställer att endast betrodda klienter och användare kan anropa serverfunktioner.

3. **Validering**:  
  Parameterkontroll tillämpas för alla verktygsanrop. Varje verktyg definierar förväntade typer, format och begränsningar för sina parametrar, och servern validerar inkommande förfrågningar därefter. Detta förhindrar att felaktig eller skadlig input når verktygsimplementationerna och hjälper till att upprätthålla operationernas integritet.

4. **Begränsning av anropstakt (Rate Limiting)**:  
  För att förhindra missbruk och säkerställa rättvis användning av serverresurser kan MCP-servrar införa begränsningar för hur ofta verktyg kan anropas och resurser nås. Begränsningar kan tillämpas per användare, per session eller globalt, och hjälper till att skydda mot överbelastningsattacker eller överdriven resursförbrukning.

Genom att kombinera dessa mekanismer erbjuder MCP en säker grund för att integrera språkmodeller med externa verktyg och datakällor, samtidigt som användare och utvecklare får detaljerad kontroll över åtkomst och användning.

## Protokollmeddelanden

MCP-kommunikation använder strukturerade JSON-meddelanden för att möjliggöra tydliga och pålitliga interaktioner mellan klienter, servrar och modeller. De huvudsakliga meddelandetyperna inkluderar:

- **Client Request**  
  Skickas från klienten till servern och innehåller vanligtvis:
  - Användarens prompt eller kommando
  - Konversationshistorik för kontext
  - Verktygskonfiguration och behörigheter
  - Eventuell ytterligare metadata eller sessionsinformation

- **Model Response**  
  Returneras av modellen (via klienten) och innehåller:
  - Genererad text eller svar baserat på prompt och kontext
  - Valfria instruktioner för verktygsanrop om modellen bedömer att ett verktyg ska användas
  - Referenser till resurser eller ytterligare kontext vid behov

- **Tool Request**  
  Skickas från klienten till servern när ett verktyg ska köras. Detta meddelande innehåller:
  - Namnet på verktyget som ska anropas
  - Parametrar som krävs av verktyget (validerade mot verktygets schema)
  - Kontextuell information eller identifierare för att spåra förfrågan

- **Tool Response**  
  Returneras av servern efter att ett verktyg har körts. Detta meddelande innehåller:
  - Resultatet av verktygets körning (strukturerad data eller innehåll)
  - Eventuella fel eller statusinformation om verktygsanropet misslyckades
  - Valfritt ytterligare metadata eller loggar relaterade till körningen

Dessa strukturerade meddelanden säkerställer att varje steg i MCP-arbetsflödet är tydligt, spårbart och utbyggbart, vilket stödjer avancerade scenarier som flerstegs-konversationer, kedjning av verktyg och robust felhantering.

## Viktiga punkter

- MCP använder en klient-server-arkitektur för att koppla modeller till externa funktioner
- Ekosystemet består av klienter, värdar, servrar, verktyg och datakällor
- Kommunikation kan ske via STDIO, SSE eller WebSockets
- Verktyg är de grundläggande funktionella enheterna som exponeras för modeller
- Strukturerade kommunikationsprotokoll säkerställer konsekventa interaktioner

## Övning

Designa ett enkelt MCP-verktyg som skulle vara användbart inom ditt område. Definiera:
1. Vad verktyget skulle heta
2. Vilka parametrar det skulle acceptera
3. Vilket resultat det skulle returnera
4. Hur en modell skulle kunna använda detta verktyg för att lösa användarproblem


---

## Vad händer härnäst

Nästa: [Chapter 2: Security](../02-Security/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.