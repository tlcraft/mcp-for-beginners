<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b3b4a6ad10c3c0edbf7fa7cfa0ec496b",
  "translation_date": "2025-07-02T07:19:34+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "no"
}
-->
# 📖 MCP Kjernebegreper: Mestre Model Context Protocol for AI-integrasjon

[Model Context Protocol (MCP)](https://github.com/modelcontextprotocol) er en kraftfull, standardisert ramme som optimaliserer kommunikasjonen mellom store språkmodeller (LLMs) og eksterne verktøy, applikasjoner og datakilder. Denne SEO-optimaliserte guiden tar deg gjennom kjernebegrepene i MCP, og sikrer at du forstår klient-server-arkitekturen, viktige komponenter, kommunikasjonsmekanismer og beste praksis for implementering.

## Oversikt

Denne leksjonen utforsker grunnleggende arkitektur og komponenter som utgjør Model Context Protocol (MCP)-økosystemet. Du vil lære om klient-server-arkitekturen, nøkkelkomponenter og kommunikasjonsmekanismer som driver MCP-interaksjoner.

## 👩‍🎓 Viktige læringsmål

Etter denne leksjonen vil du:

- Forstå MCP klient-server-arkitektur.
- Identifisere roller og ansvar for Hosts, Clients og Servers.
- Analysere kjernefunksjoner som gjør MCP til et fleksibelt integrasjonslag.
- Lære hvordan informasjon flyter innen MCP-økosystemet.
- Få praktisk innsikt gjennom kodeeksempler i .NET, Java, Python og JavaScript.

## 🔎 MCP Arkitektur: En nærmere titt

MCP-økosystemet er bygget på en klient-server-modell. Denne modulære strukturen lar AI-applikasjoner effektivt samhandle med verktøy, databaser, API-er og kontekstuelle ressurser. La oss dele opp arkitekturen i dens kjernekomponenter.

I kjernen følger MCP en klient-server-arkitektur der en host-applikasjon kan koble til flere servere:

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

- **MCP Hosts**: Programmer som VSCode, Claude Desktop, IDE-er eller AI-verktøy som ønsker tilgang til data via MCP
- **MCP Clients**: Protokollklienter som opprettholder 1:1-tilkoblinger med servere
- **MCP Servers**: Lettvektsprogrammer som hver tilbyr spesifikke funksjoner gjennom den standardiserte Model Context Protocol
- **Lokale datakilder**: Filene, databasene og tjenestene på din datamaskin som MCP-servere kan få sikker tilgang til
- **Eksterne tjenester**: Systemer tilgjengelig over internett som MCP-servere kan koble til via API-er.

MCP-protokollen er en standard i utvikling, og du kan se de siste oppdateringene i [protokollspesifikasjonen](https://modelcontextprotocol.io/specification/2025-06-18/)

### 1. Hosts

I Model Context Protocol (MCP) spiller Hosts en avgjørende rolle som hovedgrensesnittet brukere interagerer gjennom med protokollen. Hosts er applikasjoner eller miljøer som initierer tilkoblinger til MCP-servere for å få tilgang til data, verktøy og prompts. Eksempler på Hosts inkluderer integrerte utviklingsmiljøer (IDE-er) som Visual Studio Code, AI-verktøy som Claude Desktop, eller spesialbygde agenter designet for bestemte oppgaver.

**Hosts** er LLM-applikasjoner som starter tilkoblinger. De:

- Kjører eller samhandler med AI-modeller for å generere svar.
- Initierer tilkoblinger til MCP-servere.
- Styrer samtaleflyten og brukergrensesnittet.
- Kontrollerer tillatelser og sikkerhetsbegrensninger.
- Håndterer brukerens samtykke for datadeling og verktøykjøring.

### 2. Clients

Clients er essensielle komponenter som muliggjør samspillet mellom Hosts og MCP-servere. Clients fungerer som mellomledd, og gir Hosts tilgang til og utnyttelse av funksjonaliteten som MCP-servere tilbyr. De spiller en viktig rolle for å sikre smidig kommunikasjon og effektiv datautveksling i MCP-arkitekturen.

**Clients** er koblinger inne i host-applikasjonen. De:

- Sender forespørsler til servere med prompts/instruksjoner.
- Forhandler om funksjonalitet med servere.
- Håndterer forespørsler om verktøykjøring fra modeller.
- Behandler og viser svar til brukerne.

### 3. Servers

Servers har ansvar for å håndtere forespørsler fra MCP-klienter og gi passende svar. De styrer ulike operasjoner som datainnhenting, verktøykjøring og promptgenerering. Servere sørger for at kommunikasjonen mellom klienter og Hosts er effektiv og pålitelig, samtidig som de opprettholder integriteten i samhandlingen.

**Servers** er tjenester som tilbyr kontekst og funksjonalitet. De:

- Registrerer tilgjengelige funksjoner (ressurser, prompts, verktøy)
- Mottar og utfører verktøykall fra klienten
- Gir kontekstuell informasjon for å forbedre modellens svar
- Returnerer resultater til klienten
- Opprettholder tilstand på tvers av interaksjoner når det trengs

Servere kan utvikles av hvem som helst for å utvide modellens funksjonalitet med spesialisert funksjonalitet.

### 4. Serverfunksjoner

Servere i Model Context Protocol (MCP) tilbyr grunnleggende byggesteiner som muliggjør rike interaksjoner mellom klienter, hosts og språkmodeller. Disse funksjonene er designet for å forbedre MCPs kapasiteter ved å tilby strukturert kontekst, verktøy og prompts.

MCP-servere kan tilby noen av følgende funksjoner:

#### 📑 Ressurser

Ressurser i Model Context Protocol (MCP) omfatter ulike typer kontekst og data som kan brukes av brukere eller AI-modeller. Disse inkluderer:

- **Kontekstuell data**: Informasjon og kontekst som brukere eller AI-modeller kan bruke for beslutningstaking og oppgaveutførelse.
- **Kunnskapsbaser og dokumentarkiver**: Samlinger av strukturert og ustrukturert data, som artikler, manualer og forskningsartikler, som gir verdifulle innsikter og informasjon.
- **Lokale filer og databaser**: Data lagret lokalt på enheter eller i databaser, tilgjengelig for behandling og analyse.
- **API-er og webtjenester**: Eksterne grensesnitt og tjenester som tilbyr ekstra data og funksjonalitet, og muliggjør integrasjon med ulike nettbaserte ressurser og verktøy.

Et eksempel på en ressurs kan være et databaseskjema eller en fil som kan aksesseres slik:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts i Model Context Protocol (MCP) inkluderer ulike forhåndsdefinerte maler og interaksjonsmønstre designet for å effektivisere brukerarbeidsflyter og forbedre kommunikasjon. Disse inkluderer:

- **Malerte meldinger og arbeidsflyter**: Forhåndsstrukturerte meldinger og prosesser som guider brukere gjennom spesifikke oppgaver og interaksjoner.
- **Forhåndsdefinerte interaksjonsmønstre**: Standardiserte sekvenser av handlinger og svar som legger til rette for konsistent og effektiv kommunikasjon.
- **Spesialiserte samtalemaler**: Tilpassbare maler skreddersydd for spesifikke typer samtaler, som sikrer relevante og kontekstuelt passende interaksjoner.

En promptmal kan se slik ut:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Verktøy

Verktøy i Model Context Protocol (MCP) er funksjoner som AI-modellen kan kjøre for å utføre spesifikke oppgaver. Disse verktøyene er designet for å forbedre AI-modellens evner ved å tilby strukturerte og pålitelige operasjoner. Viktige aspekter inkluderer:

- **Funksjoner for AI-modellen å kjøre**: Verktøy er kjørbare funksjoner som AI-modellen kan påkalle for å utføre ulike oppgaver.
- **Unikt navn og beskrivelse**: Hvert verktøy har et distinkt navn og en detaljert beskrivelse som forklarer formålet og funksjonaliteten.
- **Parametere og utdata**: Verktøy aksepterer spesifikke parametere og returnerer strukturerte resultater, noe som sikrer konsistente og forutsigbare utfall.
- **Diskrete funksjoner**: Verktøy utfører separate funksjoner som nettsøk, beregninger og databaseforespørsler.

Et eksempel på et verktøy kan se slik ut:

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

## Klientfunksjoner

I Model Context Protocol (MCP) tilbyr klienter flere nøkkelfunksjoner til servere, som forbedrer den samlede funksjonaliteten og samhandlingen innen protokollen. En av de mest bemerkelsesverdige funksjonene er Sampling.

### 👉 Sampling

- **Server-initierte agentiske handlinger**: Klienter gjør det mulig for servere å initiere spesifikke handlinger eller atferd autonomt, noe som øker systemets dynamiske kapasiteter.
- **Rekursiv LLM-interaksjon**: Denne funksjonen tillater rekursive interaksjoner med store språkmodeller (LLMs), som muliggjør mer komplekse og iterative oppgavebehandlinger.
- **Forespørsel om flere modellutfall**: Servere kan be om flere utføringer fra modellen for å sikre at svarene er grundige og kontekstuelt relevante.

## Informasjonsflyt i MCP

Model Context Protocol (MCP) definerer en strukturert flyt av informasjon mellom hosts, clients, servers og modeller. Å forstå denne flyten hjelper med å klargjøre hvordan brukerforespørsler behandles og hvordan eksterne verktøy og data integreres i modelsvar.

- **Host initierer tilkobling**  
  Host-applikasjonen (som en IDE eller chat-grensesnitt) etablerer en tilkobling til en MCP-server, vanligvis via STDIO, WebSocket eller en annen støttet transport.

- **Forhandling av funksjonalitet**  
  Klienten (innebygd i host) og serveren utveksler informasjon om hvilke funksjoner, verktøy, ressurser og protokollversjoner de støtter. Dette sikrer at begge parter forstår hvilke muligheter som er tilgjengelige for økten.

- **Brukerforespørsel**  
  Brukeren interagerer med host (f.eks. skriver inn en prompt eller kommando). Host samler inn denne inputen og sender den videre til klienten for behandling.

- **Bruk av ressurs eller verktøy**  
  - Klienten kan be om ekstra kontekst eller ressurser fra serveren (som filer, databaseoppføringer eller kunnskapsartikler) for å berike modellens forståelse.  
  - Hvis modellen avgjør at et verktøy trengs (f.eks. for å hente data, utføre en beregning eller kalle et API), sender klienten en forespørsel om verktøykall til serveren, med angivelse av verktøynavn og parametere.

- **Serverutførelse**  
  Serveren mottar ressurs- eller verktøyforespørselen, utfører nødvendige operasjoner (som å kjøre en funksjon, spørring i database eller hente en fil), og returnerer resultatene til klienten i et strukturert format.

- **Svargenerering**  
  Klienten integrerer serverens svar (ressursdata, verktøyresultater osv.) i den pågående modellinteraksjonen. Modellen bruker denne informasjonen til å generere et omfattende og kontekstuelt relevant svar.

- **Resultatpresentasjon**  
  Host mottar det endelige resultatet fra klienten og viser det til brukeren, ofte inkludert både modellens genererte tekst og eventuelle resultater fra verktøykjøringer eller ressursoppslag.

Denne flyten gjør det mulig for MCP å støtte avanserte, interaktive og kontekstbevisste AI-applikasjoner ved sømløst å koble modeller med eksterne verktøy og datakilder.

## Protokolldetaljer

MCP (Model Context Protocol) er bygget på toppen av [JSON-RPC 2.0](https://www.jsonrpc.org/), og tilbyr et standardisert, språkagnostisk meldingsformat for kommunikasjon mellom hosts, clients og servers. Dette grunnlaget muliggjør pålitelig, strukturert og utvidbar samhandling på tvers av ulike plattformer og programmeringsspråk.

### Viktige protokollfunksjoner

MCP utvider JSON-RPC 2.0 med ekstra konvensjoner for verktøykall, ressursaksess og prompthåndtering. Den støtter flere transportlag (STDIO, WebSocket, SSE) og muliggjør sikker, utvidbar og språkagnostisk kommunikasjon mellom komponenter.

#### 🧢 Grunnleggende protokoll

- **JSON-RPC meldingsformat**: Alle forespørsler og svar følger JSON-RPC 2.0-spesifikasjonen, som sikrer konsistent struktur for metodekall, parametere, resultater og feilbehandling.
- **Tilstandsholdte tilkoblinger**: MCP-økter opprettholder tilstand over flere forespørsler, og støtter pågående samtaler, akkumulering av kontekst og ressursadministrasjon.
- **Forhandling av funksjonalitet**: Under tilkoblingsoppsett utveksler klienter og servere informasjon om støttede funksjoner, protokollversjoner, tilgjengelige verktøy og ressurser. Dette sikrer at begge parter forstår hverandres kapasiteter og kan tilpasse seg deretter.

#### ➕ Tilleggsverktøy

Nedenfor er noen ekstra verktøy og protokollutvidelser som MCP tilbyr for å forbedre utvikleropplevelsen og muliggjøre avanserte scenarier:

- **Konfigurasjonsmuligheter**: MCP tillater dynamisk konfigurasjon av øktparametere, som verktøytillatelser, ressursaksess og modellinnstillinger, tilpasset hver interaksjon.
- **Fremdriftssporing**: Langvarige operasjoner kan rapportere fremdriftsoppdateringer, noe som muliggjør responsive brukergrensesnitt og bedre brukeropplevelse under komplekse oppgaver.
- **Avbryting av forespørsler**: Klienter kan avbryte pågående forespørsler, slik at brukere kan stoppe operasjoner som ikke lenger er nødvendige eller som tar for lang tid.
- **Feilmelding**: Standardiserte feilmeldinger og koder hjelper med å diagnostisere problemer, håndtere feil på en ryddig måte og gi brukere og utviklere handlingsrettet tilbakemelding.
- **Logging**: Både klienter og servere kan sende strukturerte logger for revisjon, feilsøking og overvåkning av protokollinteraksjoner.

Ved å utnytte disse protokollfunksjonene sikrer MCP robust, sikker og fleksibel kommunikasjon mellom språkmodeller og eksterne verktøy eller datakilder.

### 🔐 Sikkerhetshensyn

MCP-implementasjoner bør følge flere viktige sikkerhetsprinsipper for å sikre trygge og pålitelige interaksjoner:

- **Brukersamtykke og kontroll**: Brukere må gi eksplisitt samtykke før noen data blir aksessert eller operasjoner utført. De bør ha tydelig kontroll over hva som deles og hvilke handlinger som er autorisert, støttet av intuitive brukergrensesnitt for gjennomgang og godkjenning.

- **Dataprivacy**: Brukerdata skal kun eksponeres med eksplisitt samtykke og må beskyttes med passende tilgangskontroller. MCP-implementasjoner må forhindre uautorisert datatransmisjon og sikre at personvern opprettholdes gjennom alle interaksjoner.

- **Verktøysikkerhet**: Før noen verktøy kalles, kreves eksplisitt brukersamtykke. Brukere bør ha klar forståelse av hvert verktøys funksjonalitet, og robuste sikkerhetsgrenser må håndheves for å forhindre utilsiktet eller usikker kjøring.

Ved å følge disse prinsippene sikrer MCP at brukertillit, personvern og sikkerhet opprettholdes i alle protokollinteraksjoner.

## Kodeeksempler: Nøkkelkomponenter

Nedenfor finner du kodeeksempler i flere populære programmeringsspråk som illustrerer hvordan man implementerer sentrale MCP-serverkomponenter og verktøy.

### .NET-eksempel: Lage en enkel MCP-server med verktøy

Her er et praktisk .NET-kodeeksempel som viser hvordan man implementerer en enkel MCP-server med egendefinerte verktøy. Eksemplet demonstrerer hvordan man definerer og registrerer verktøy, håndterer forespørsler og kobler serveren ved hjelp av Model Context Protocol.

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

### Java-eksempel: MCP-serverkomponenter

Dette eksempelet viser samme MCP-server og verktøyregistrering som .NET-eksemplet over, men implementert i Java.

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

### Python-eksempel: Bygge en MCP-server

I dette eksempelet viser vi hvordan man bygger en MCP-server i Python. Du får også se to forskjellige måter å lage verktøy på.

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

### JavaScript-eksempel: Lage en MCP-server

Dette eksempelet viser MCP-serveropprettelse i JavaScript og hvordan man registrerer to værrelaterte verktøy.

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

Dette JavaScript-eksemplet demonstrerer hvordan man lager en MCP-klient som kobler til en server, sender en prompt og behandler svaret inkludert eventuelle verktøykall som ble gjort.

## Sikkerhet og autorisasjon

MCP inkluderer flere innebygde konsepter og mekanismer for å håndtere sikkerhet og autorisasjon gjennom hele protokollen:

1. **Kontroll av verktøytillatelser**:  
  Klienter kan spesifisere hvilke verktøy en modell har lov til å bruke i løpet av en økt

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på dets originale språk skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.