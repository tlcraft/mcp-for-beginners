<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T17:25:56+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "no"
}
-->
# 📖 MCP Kjernebegreper: Mestre Model Context Protocol for AI-integrasjon

Model Context Protocol (MCP) er et kraftig, standardisert rammeverk som optimaliserer kommunikasjonen mellom store språkmodeller (LLMs) og eksterne verktøy, applikasjoner og datakilder. Denne SEO-optimaliserte guiden tar deg gjennom kjernebegrepene i MCP, og sikrer at du forstår klient-server-arkitekturen, viktige komponenter, kommunikasjonsmekanismer og beste praksis for implementering.

## Oversikt

Denne leksjonen utforsker den grunnleggende arkitekturen og komponentene som utgjør Model Context Protocol (MCP)-økosystemet. Du vil lære om klient-server-arkitekturen, nøkkelkomponenter og kommunikasjonsmekanismer som driver MCP-interaksjoner.

## 👩‍🎓 Viktige læringsmål

Etter denne leksjonen vil du:

- Forstå MCP klient-server-arkitektur.
- Identifisere roller og ansvar for Hosts, Clients og Servers.
- Analysere kjernefunksjonene som gjør MCP til et fleksibelt integrasjonslag.
- Lære hvordan informasjon flyter innen MCP-økosystemet.
- Få praktisk innsikt gjennom kodeeksempler i .NET, Java, Python og JavaScript.

## 🔎 MCP-arkitektur: En grundigere titt

MCP-økosystemet er bygget på en klient-server-modell. Denne modulære strukturen gjør det mulig for AI-applikasjoner å samhandle effektivt med verktøy, databaser, API-er og kontekstuelle ressurser. La oss bryte ned denne arkitekturen i dens kjernekomponenter.

### 1. Hosts

I Model Context Protocol (MCP) spiller Hosts en avgjørende rolle som hovedgrensesnittet brukere benytter for å interagere med protokollen. Hosts er applikasjoner eller miljøer som initierer tilkoblinger til MCP-servere for å få tilgang til data, verktøy og prompts. Eksempler på Hosts inkluderer integrerte utviklingsmiljøer (IDEer) som Visual Studio Code, AI-verktøy som Claude Desktop, eller egendefinerte agenter utviklet for spesifikke oppgaver.

**Hosts** er LLM-applikasjoner som starter tilkoblinger. De:

- Utfører eller samhandler med AI-modeller for å generere svar.
- Initierer tilkoblinger til MCP-servere.
- Styrer samtaleflyt og brukergrensesnitt.
- Kontrollerer tillatelser og sikkerhetsbegrensninger.
- Håndterer brukerens samtykke for datadeling og verktøyutførelse.

### 2. Clients

Clients er viktige komponenter som legger til rette for interaksjonen mellom Hosts og MCP-servere. Clients fungerer som mellomledd, slik at Hosts kan få tilgang til og bruke funksjonaliteten som MCP-servere tilbyr. De spiller en avgjørende rolle i å sikre smidig kommunikasjon og effektiv datautveksling innen MCP-arkitekturen.

**Clients** er koblinger inne i host-applikasjonen. De:

- Sender forespørsler til servere med prompts/instruksjoner.
- Forhandler kapasiteter med servere.
- Håndterer forespørsler om verktøyutførelse fra modeller.
- Behandler og viser svar til brukere.

### 3. Servers

Servers er ansvarlige for å håndtere forespørsler fra MCP-klienter og gi passende svar. De administrerer ulike operasjoner som datainnhenting, verktøyutførelse og promptgenerering. Servers sørger for at kommunikasjonen mellom klienter og Hosts er effektiv og pålitelig, og opprettholder integriteten i interaksjonsprosessen.

**Servers** er tjenester som tilbyr kontekst og funksjonalitet. De:

- Registrerer tilgjengelige funksjoner (ressurser, prompts, verktøy).
- Mottar og utfører verktøysanrop fra klienten.
- Gir kontekstuell informasjon for å forbedre modellens svar.
- Returnerer resultater tilbake til klienten.
- Opprettholder tilstand over interaksjoner når det er nødvendig.

Servers kan utvikles av hvem som helst for å utvide modellens funksjonalitet med spesialisert funksjonalitet.

### 4. Serverfunksjoner

Servere i Model Context Protocol (MCP) tilbyr grunnleggende byggeklosser som muliggjør rike interaksjoner mellom klienter, hosts og språkmodeller. Disse funksjonene er designet for å forbedre MCPs muligheter ved å tilby strukturert kontekst, verktøy og prompts.

MCP-servere kan tilby noen av følgende funksjoner:

#### 📑 Ressurser

Ressurser i Model Context Protocol (MCP) omfatter ulike typer kontekst og data som brukere eller AI-modeller kan benytte. Disse inkluderer:

- **Kontekstuell data**: Informasjon og kontekst som brukere eller AI-modeller kan bruke til beslutningstaking og oppgaveutførelse.
- **Kunnskapsbaser og dokumentarkiver**: Samlinger av strukturert og ustrukturert data, som artikler, manualer og forskningsartikler, som gir verdifulle innsikter og informasjon.
- **Lokale filer og databaser**: Data lagret lokalt på enheter eller i databaser, tilgjengelig for behandling og analyse.
- **API-er og webtjenester**: Eksterne grensesnitt og tjenester som tilbyr ekstra data og funksjonalitet, og muliggjør integrasjon med ulike nettressurser og verktøy.

Et eksempel på en ressurs kan være et databaseskjema eller en fil som kan aksesseres slik:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts i Model Context Protocol (MCP) inkluderer ulike forhåndsdefinerte maler og interaksjonsmønstre designet for å effektivisere brukerarbeidsflyter og forbedre kommunikasjonen. Disse inkluderer:

- **Malerte meldinger og arbeidsflyter**: Forhåndsstrukturerte meldinger og prosesser som guider brukere gjennom spesifikke oppgaver og interaksjoner.
- **Forhåndsdefinerte interaksjonsmønstre**: Standardiserte sekvenser av handlinger og svar som legger til rette for konsistent og effektiv kommunikasjon.
- **Spesialiserte samtalemaler**: Tilpassbare maler skreddersydd for spesifikke samtaletypetyper, som sikrer relevante og kontekstuelt passende interaksjoner.

En promptmal kan se slik ut:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Verktøy

Verktøy i Model Context Protocol (MCP) er funksjoner som AI-modellen kan utføre for å løse spesifikke oppgaver. Disse verktøyene er designet for å forbedre AI-modellens evner ved å tilby strukturerte og pålitelige operasjoner. Viktige aspekter inkluderer:

- **Funksjoner som AI-modellen kan utføre**: Verktøy er kjørbare funksjoner som AI-modellen kan påkalle for å utføre ulike oppgaver.
- **Unikt navn og beskrivelse**: Hvert verktøy har et distinkt navn og en detaljert beskrivelse som forklarer formålet og funksjonaliteten.
- **Parametere og utdata**: Verktøy aksepterer spesifikke parametere og returnerer strukturerte utdata, noe som sikrer konsistente og forutsigbare resultater.
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

I Model Context Protocol (MCP) tilbyr klienter flere nøkkelfunksjoner til servere, som forbedrer protokollens samlede funksjonalitet og interaksjon. En av de mest bemerkelsesverdige funksjonene er Sampling.

### 👉 Sampling

- **Server-initierte agentiske handlinger**: Klienter gjør det mulig for servere å initiere spesifikke handlinger eller atferd autonomt, noe som øker systemets dynamiske muligheter.
- **Rekursive LLM-interaksjoner**: Denne funksjonen tillater rekursive interaksjoner med store språkmodeller (LLMs), og muliggjør mer komplekse og iterative oppgavebehandlinger.
- **Forespørsel om flere modellkompletteringer**: Servere kan be om flere fullføringer fra modellen, slik at svarene blir grundige og kontekstuelt relevante.

## Informasjonsflyt i MCP

Model Context Protocol (MCP) definerer en strukturert informasjonsflyt mellom hosts, clients, servers og modeller. Å forstå denne flyten hjelper med å klargjøre hvordan brukerforespørsler behandles og hvordan eksterne verktøy og data integreres i modelsvar.

- **Host initierer tilkobling**  
  Host-applikasjonen (som et IDE eller chattegrensesnitt) etablerer en tilkobling til en MCP-server, vanligvis via STDIO, WebSocket eller annen støttet transport.

- **Kapasitetsforhandling**  
  Klienten (innebygd i hosten) og serveren utveksler informasjon om hvilke funksjoner, verktøy, ressurser og protokollversjoner de støtter. Dette sikrer at begge parter forstår hvilke muligheter som er tilgjengelige for økten.

- **Brukerforespørsel**  
  Brukeren interagerer med hosten (f.eks. skriver inn en prompt eller kommando). Hosten samler inn denne inputen og sender den til klienten for behandling.

- **Bruk av ressurs eller verktøy**  
  - Klienten kan be om ekstra kontekst eller ressurser fra serveren (som filer, databaseoppføringer eller artikler fra kunnskapsbaser) for å berike modellens forståelse.
  - Hvis modellen avgjør at et verktøy er nødvendig (f.eks. for å hente data, utføre en beregning eller kalle et API), sender klienten en verktøysanropsforespørsel til serveren, med spesifisering av verktøyets navn og parametere.

- **Serverutførelse**  
  Serveren mottar ressurs- eller verktøyforespørselen, utfører nødvendige operasjoner (som å kjøre en funksjon, hente data fra en database eller hente en fil), og returnerer resultatene til klienten i et strukturert format.

- **Svargenerering**  
  Klienten integrerer serverens svar (ressursdata, verktøyutdata osv.) i den pågående modellinteraksjonen. Modellen bruker denne informasjonen for å generere et omfattende og kontekstuelt relevant svar.

- **Resultatpresentasjon**  
  Hosten mottar det endelige resultatet fra klienten og viser det til brukeren, ofte med både modellens genererte tekst og eventuelle resultater fra verktøyutførelser eller ressursoppslag.

Denne flyten gjør at MCP kan støtte avanserte, interaktive og kontekstbevisste AI-applikasjoner ved sømløst å koble modeller med eksterne verktøy og datakilder.

## Protokolldetaljer

MCP (Model Context Protocol) bygger på [JSON-RPC 2.0](https://www.jsonrpc.org/), og tilbyr et standardisert, språkagnostisk meldingsformat for kommunikasjon mellom hosts, clients og servers. Dette fundamentet muliggjør pålitelige, strukturerte og utvidbare interaksjoner på tvers av ulike plattformer og programmeringsspråk.

### Viktige protokollfunksjoner

MCP utvider JSON-RPC 2.0 med ekstra konvensjoner for verktøysanrop, ressursaksess og prompthåndtering. Det støtter flere transportlag (STDIO, WebSocket, SSE) og muliggjør sikker, utvidbar og språkagnostisk kommunikasjon mellom komponenter.

#### 🧢 Grunnprotokoll

- **JSON-RPC meldingsformat**: Alle forespørsler og svar følger JSON-RPC 2.0-spesifikasjonen, som sikrer konsistent struktur for metodekall, parametere, resultater og feilhåndtering.
- **Stateful tilkoblinger**: MCP-økter opprettholder tilstand over flere forespørsler, og støtter pågående samtaler, kontekstakkumulering og ressursadministrasjon.
- **Kapasitetsforhandling**: Under tilkoblingsoppsett utveksler klienter og servere informasjon om støttede funksjoner, protokollversjoner, tilgjengelige verktøy og ressurser. Dette sikrer at begge parter forstår hverandres muligheter og kan tilpasse seg.

#### ➕ Ekstra verktøy

Nedenfor er noen ekstra verktøy og protokollutvidelser MCP tilbyr for å forbedre utvikleropplevelsen og muliggjøre avanserte scenarier:

- **Konfigurasjonsvalg**: MCP tillater dynamisk konfigurering av øktparametere, som verktøytillatelser, ressursadgang og modellinnstillinger, tilpasset hver interaksjon.
- **Fremdriftssporing**: Langvarige operasjoner kan rapportere fremdriftsoppdateringer, noe som gir responsive brukergrensesnitt og bedre brukeropplevelse under komplekse oppgaver.
- **Avbrytelse av forespørsler**: Klienter kan avbryte pågående forespørsler, slik at brukere kan stoppe operasjoner som ikke lenger er nødvendige eller tar for lang tid.
- **Feilrapportering**: Standardiserte feilmeldinger og koder hjelper med å diagnostisere problemer, håndtere feil på en ryddig måte og gi brukere og utviklere nyttig tilbakemelding.
- **Logging**: Både klienter og servere kan sende strukturerte logger for revisjon, feilsøking og overvåking av protokollinteraksjoner.

Ved å utnytte disse protokollfunksjonene sikrer MCP robust, sikker og fleksibel kommunikasjon mellom språkmodeller og eksterne verktøy eller datakilder.

### 🔐 Sikkerhetshensyn

MCP-implementasjoner bør følge flere viktige sikkerhetsprinsipper for å sikre trygge og pålitelige interaksjoner:

- **Brukersamtykke og kontroll**: Brukere må gi eksplisitt samtykke før data aksesseres eller operasjoner utføres. De bør ha klar kontroll over hva som deles og hvilke handlinger som godkjennes, støttet av intuitive brukergrensesnitt for gjennomgang og godkjenning.

- **Dataprivacy**: Brukerdata skal kun eksponeres med eksplisitt samtykke og beskyttes med passende tilgangskontroller. MCP-implementasjoner må forhindre uautorisert datatransmisjon og sikre at personvern opprettholdes gjennom alle interaksjoner.

- **Verktøysikkerhet**: Før noe verktøy kalles opp, kreves eksplisitt brukersamtykke. Brukere bør ha en klar forståelse av hver verktøys funksjon, og robuste sikkerhetsgrenser må håndheves for å forhindre utilsiktet eller usikker verktøyutførelse.

Ved å følge disse prinsippene sikrer MCP at brukertillit, personvern og sikkerhet opprettholdes i alle protokollinteraksjoner.

## Kodeeksempler: Nøkkelkomponenter

Nedenfor finner du kodeeksempler i flere populære programmeringsspråk som illustrerer hvordan man implementerer sentrale MCP-serverkomponenter og verktøy.

### .NET-eksempel: Lage en enkel MCP-server med verktøy

Her er et praktisk .NET-kodeeksempel som viser hvordan man implementerer en enkel MCP-server med egendefinerte verktøy. Eksemplet viser hvordan man definerer og registrerer verktøy, håndterer forespørsler og kobler til serveren via Model Context Protocol.

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

Dette eksemplet demonstrerer samme MCP-server og verktøyregistrering som .NET-eksemplet over, men implementert i Java.

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

I dette eksemplet viser vi hvordan man bygger en MCP-server i Python. Du får også se to ulike måter å lage verktøy på.

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

### JavaScript-eksempel: Lage en MCP-server

Dette eksemplet viser MCP-serveropprettelse i JavaScript og hvordan man registrerer to værrelaterte verktøy.

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

Dette JavaScript-eksemplet viser hvordan man lager en MCP-klient som kobler til en server, sender en prompt og behandler svaret, inkludert eventuelle verktøysanrop som ble gjort.

## Sikkerhet og autorisasjon

MCP inkluderer flere innebygde konsepter og mekanismer for å håndtere sikkerhet og autorisasjon gjennom hele protokollen:

1. **Verktøytillatelseskontroll**:  
  Klienter kan spesifisere hvilke verktøy en modell har lov til å bruke i løpet av en økt. Dette sikrer at kun eksplisitt autoriserte verktøy er tilgjengelige, og reduserer risikoen for utilsiktede eller usikre operasjoner. Tillatelser kan konfigureres dynamisk basert på brukerpreferanser, organisasjonspolicyer eller konteksten for interaksjonen.

2. **Autentisering**:  
  Servere kan kreve autentisering før de gir tilgang til verktøy, ressurser eller sensitive operasjoner. Dette kan innebære API-nøkler, OAuth-tokens eller andre autentiseringsmetoder. Korrekt autentisering sikrer at kun betrodde klienter og brukere kan påkalle serverfunksjonalitet.

3. **Validering**:  
  Parameter-validering håndheves for alle verktøysanrop. Hvert verktøy definerer forventede typer, formater og begrensninger for sine parametere, og serveren validerer innkommende forespørsler deretter. Dette forhindrer feilaktig eller ondsinnet input i å nå verktøyimplementasjonene og bidrar til å opprettholde operasjonenes integritet.

4. **Rate

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår fra bruk av denne oversettelsen.