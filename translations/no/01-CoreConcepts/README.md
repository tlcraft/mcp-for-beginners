<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a6a7bcb289c024a91289e0444cb370b",
  "translation_date": "2025-08-18T15:31:56+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "no"
}
-->
# MCP Kjernekonsepter: Mestre Model Context Protocol for AI-integrasjon

[![MCP Kjernekonsepter](../../../translated_images/02.8203e26c6fb5a797f38a10012061013ec66c95bb3260f6c9cfd2bf74b00860e1.no.png)](https://youtu.be/earDzWGtE84)

_(Klikk på bildet over for å se videoen til denne leksjonen)_

[Model Context Protocol (MCP)](https://gi- **Eksplisitt brukersamtykke**: All tilgang til data og operasjoner krever eksplisitt godkjenning fra brukeren før utførelse. Brukeren må tydelig forstå hvilke data som vil bli brukt og hvilke handlinger som vil bli utført, med detaljert kontroll over tillatelser og autorisasjoner.

- **Beskyttelse av personvern**: Brukerdata eksponeres kun med eksplisitt samtykke og må beskyttes med robuste tilgangskontroller gjennom hele interaksjonslivssyklusen. Implementasjoner må forhindre uautorisert datatransmisjon og opprettholde strenge personvernbegrensninger.

- **Sikkerhet ved verktøyutførelse**: Hver verktøyaktivering krever eksplisitt brukersamtykke med klar forståelse av verktøyets funksjonalitet, parametere og potensielle konsekvenser. Robuste sikkerhetsgrenser må forhindre utilsiktet, usikker eller ondsinnet bruk av verktøy.

- **Sikkerhet i transportlaget**: Alle kommunikasjonskanaler bør bruke passende kryptering og autentiseringsmekanismer. Eksterne tilkoblinger bør implementere sikre transportprotokoller og riktig håndtering av legitimasjon.

#### Retningslinjer for implementering:

- **Tillatelseshåndtering**: Implementer detaljerte tillatelsessystemer som lar brukere kontrollere hvilke servere, verktøy og ressurser som er tilgjengelige  
- **Autentisering og autorisasjon**: Bruk sikre autentiseringsmetoder (OAuth, API-nøkler) med riktig håndtering av token og utløp  
- **Validering av inndata**: Valider alle parametere og data i henhold til definerte skjemaer for å forhindre injeksjonsangrep  
- **Revisjonslogging**: Oppretthold omfattende logger over alle operasjoner for sikkerhetsovervåking og samsvar  

[Model Context Protocol (MCP)](https://modelcontextprotocol.io/specification/2025-06-18/) er et kraftig, standardisert rammeverk som optimaliserer kommunikasjon mellom store språkmodeller (LLMs) og eksterne verktøy, applikasjoner og datakilder. Denne veiledningen vil lede deg gjennom MCPs kjernekonsepter, slik at du forstår dens klient-server-arkitektur, essensielle komponenter, kommunikasjonsmekanismer og beste praksis for implementering.

## Oversikt

Denne leksjonen utforsker den grunnleggende arkitekturen og komponentene som utgjør Model Context Protocol (MCP)-økosystemet. Du vil lære om klient-server-arkitekturen, nøkkelkomponentene og kommunikasjonsmekanismene som driver MCP-interaksjoner.

## Viktige læringsmål

Ved slutten av denne leksjonen vil du:

- Forstå MCPs klient-server-arkitektur.
- Identifisere roller og ansvar for Hosts, Clients og Servers.
- Analysere kjernefunksjonene som gjør MCP til et fleksibelt integrasjonslag.
- Lære hvordan informasjon flyter innenfor MCP-økosystemet.
- Få praktisk innsikt gjennom kodeeksempler i .NET, Java, Python og JavaScript.

## MCP-arkitektur: En dypere titt

MCP-økosystemet er bygget på en klient-server-modell. Denne modulære strukturen gjør det mulig for AI-applikasjoner å effektivt samhandle med verktøy, databaser, API-er og kontekstuelle ressurser. La oss bryte ned denne arkitekturen i dens kjernekomponenter.

I kjernen følger MCP en klient-server-arkitektur der en vertsapplikasjon kan koble til flere servere:

```mermaid
flowchart LR
    subgraph "Your Computer"
        Host["Host with MCP (Visual Studio, VS Code, IDEs, Tools)"]
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
- **MCP Servers**: Lettvektsprogrammer som hver eksponerer spesifikke funksjoner gjennom den standardiserte Model Context Protocol  
- **Lokale datakilder**: Datamaskinens filer, databaser og tjenester som MCP-servere kan få sikker tilgang til  
- **Eksterne tjenester**: Systemer tilgjengelige over internett som MCP-servere kan koble til via API-er  

MCP-protokollen er en utviklende standard som bruker dato-basert versjonering (YYYY-MM-DD-format). Den nåværende protokollversjonen er **2025-06-18**. Du kan se de siste oppdateringene til [protokollspesifikasjonen](https://modelcontextprotocol.io/specification/2025-06-18/).

### 1. Hosts

I Model Context Protocol (MCP) er **Hosts** AI-applikasjoner som fungerer som det primære grensesnittet der brukere interagerer med protokollen. Hosts koordinerer og administrerer tilkoblinger til flere MCP-servere ved å opprette dedikerte MCP-klienter for hver servertilkobling. Eksempler på Hosts inkluderer:

- **AI-applikasjoner**: Claude Desktop, Visual Studio Code, Claude Code  
- **Utviklingsmiljøer**: IDE-er og kodeeditorer med MCP-integrasjon  
- **Tilpassede applikasjoner**: Spesialbygde AI-agenter og verktøy  

**Hosts** er applikasjoner som koordinerer AI-modellinteraksjoner. De:

- **Orkestrerer AI-modeller**: Utfører eller interagerer med LLM-er for å generere svar og koordinere AI-arbeidsflyter  
- **Administrerer klienttilkoblinger**: Oppretter og vedlikeholder én MCP-klient per MCP-servertilkobling  
- **Kontrollerer brukergrensesnittet**: Håndterer samtaleflyt, brukerinteraksjoner og presentasjon av svar  
- **Håndhever sikkerhet**: Kontrollerer tillatelser, sikkerhetsbegrensninger og autentisering  
- **Håndterer brukersamtykke**: Administrerer brukerens godkjenning for datadeling og verktøyutførelse  

### 2. Clients

**Clients** er essensielle komponenter som opprettholder dedikerte én-til-én-tilkoblinger mellom Hosts og MCP-servere. Hver MCP-klient opprettes av Host for å koble til en spesifikk MCP-server, og sikrer organiserte og sikre kommunikasjonskanaler. Flere klienter gjør det mulig for Hosts å koble til flere servere samtidig.

**Clients** er koblingskomponenter i vertsapplikasjonen. De:

- **Protokollkommunikasjon**: Sender JSON-RPC 2.0-forespørsler til servere med instruksjoner og forespørsler  
- **Forhandlingskapasitet**: Forhandler støttede funksjoner og protokollversjoner med servere under initialisering  
- **Verktøyutførelse**: Administrerer forespørsler om verktøyutførelse fra modeller og behandler svar  
- **Sanntidsoppdateringer**: Håndterer varsler og sanntidsoppdateringer fra servere  
- **Svarbehandling**: Behandler og formaterer serversvar for visning til brukere  

### 3. Servers

**Servers** er programmer som gir kontekst, verktøy og funksjoner til MCP-klienter. De kan kjøre lokalt (på samme maskin som Host) eller eksternt (på eksterne plattformer), og er ansvarlige for å håndtere klientforespørsler og gi strukturerte svar. Servere eksponerer spesifikke funksjoner gjennom den standardiserte Model Context Protocol.

**Servers** er tjenester som gir kontekst og funksjoner. De:

- **Funksjonsregistrering**: Registrerer og eksponerer tilgjengelige primitive funksjoner (ressurser, forespørsler, verktøy) til klienter  
- **Forespørselsbehandling**: Mottar og utfører verktøyanrop, ressursforespørsler og forespørsler fra klienter  
- **Kontekstlevering**: Gir kontekstuell informasjon og data for å forbedre modellens svar  
- **Tilstandshåndtering**: Opprettholder sesjonstilstand og håndterer tilstandsbaserte interaksjoner når nødvendig  
- **Sanntidsvarsler**: Sender varsler om endringer og oppdateringer til tilkoblede klienter  

Servere kan utvikles av hvem som helst for å utvide modellens funksjoner med spesialisert funksjonalitet, og de støtter både lokale og eksterne distribusjonsscenarier.

### 4. Serverprimitiver

Servere i Model Context Protocol (MCP) tilbyr tre kjerne**primitiver** som definerer de grunnleggende byggeklossene for rike interaksjoner mellom klienter, Hosts og språkmodeller. Disse primitivene spesifiserer typene kontekstuell informasjon og handlinger som er tilgjengelige gjennom protokollen.

MCP-servere kan eksponere en hvilken som helst kombinasjon av følgende tre kjerneprimitiver:

#### Ressurser

**Ressurser** er datakilder som gir kontekstuell informasjon til AI-applikasjoner. De representerer statisk eller dynamisk innhold som kan forbedre modellens forståelse og beslutningstaking:

- **Kontekstuelle data**: Strukturert informasjon og kontekst for AI-modellens bruk  
- **Kunnskapsbaser**: Dokumentarkiver, artikler, manualer og forskningsartikler  
- **Lokale datakilder**: Filer, databaser og lokal systeminformasjon  
- **Eksterne data**: API-responser, webtjenester og eksterne systemdata  
- **Dynamisk innhold**: Sanntidsdata som oppdateres basert på eksterne forhold  

Ressurser identifiseres med URI-er og støtter oppdagelse gjennom `resources/list` og henting gjennom `resources/read`-metoder:

```text
file://documents/project-spec.md
database://production/users/schema
api://weather/current
```

#### Forespørsler

**Forespørsler** er gjenbrukbare maler som hjelper med å strukturere interaksjoner med språkmodeller. De gir standardiserte interaksjonsmønstre og malbaserte arbeidsflyter:

- **Malbaserte interaksjoner**: Forhåndsstrukturerte meldinger og samtalestartere  
- **Arbeidsflytmaler**: Standardiserte sekvenser for vanlige oppgaver og interaksjoner  
- **Few-shot-eksempler**: Eksempelbaserte maler for modellinstruksjon  
- **Systemforespørsler**: Grunnleggende forespørsler som definerer modellens oppførsel og kontekst  
- **Dynamiske maler**: Parameteriserte forespørsler som tilpasses spesifikke kontekster  

Forespørsler støtter variabel substitusjon og kan oppdages via `prompts/list` og hentes med `prompts/get`:

```markdown
Generate a {{task_type}} for {{product}} targeting {{audience}} with the following requirements: {{requirements}}
```

#### Verktøy

**Verktøy** er kjørbare funksjoner som AI-modeller kan påkalle for å utføre spesifikke handlinger. De representerer "verbene" i MCP-økosystemet, og gjør det mulig for modeller å samhandle med eksterne systemer:

- **Kjørbare funksjoner**: Diskrete operasjoner som modeller kan påkalle med spesifikke parametere  
- **Integrasjon med eksterne systemer**: API-anrop, databaseforespørsler, filoperasjoner, beregninger  
- **Unik identitet**: Hvert verktøy har et distinkt navn, beskrivelse og parameterskjema  
- **Strukturert I/O**: Verktøy aksepterer validerte parametere og returnerer strukturerte, typede svar  
- **Handlingskapasitet**: Gjør det mulig for modeller å utføre reelle handlinger og hente sanntidsdata  

Verktøy defineres med JSON Schema for parametervalidation og oppdages gjennom `tools/list` og utføres via `tools/call`:

```typescript
server.tool(
  "search_products", 
  {
    query: z.string().describe("Search query for products"),
    category: z.string().optional().describe("Product category filter"),
    max_results: z.number().default(10).describe("Maximum results to return")
  }, 
  async (params) => {
    // Execute search and return structured results
    return await productService.search(params);
  }
);
```

...
- **Livssyklusadministrasjon**: Håndterer opprettelse av tilkoblinger, forhandling av funksjonalitet og avslutning av økter mellom klienter og servere  
- **Serverprimitiver**: Gjør det mulig for servere å tilby kjernefunksjonalitet gjennom verktøy, ressurser og maler  
- **Klientprimitiver**: Gjør det mulig for servere å be om prøvetaking fra LLM-er, innhente brukerinput og sende loggmeldinger  
- **Sanntidsvarsler**: Støtter asynkrone varsler for dynamiske oppdateringer uten behov for polling  

#### Nøkkelfunksjoner:

- **Forhandling av protokollversjon**: Bruker datobasert versjonering (ÅÅÅÅ-MM-DD) for å sikre kompatibilitet  
- **Funksjonsoppdagelse**: Klienter og servere utveksler informasjon om støttede funksjoner under oppstart  
- **Tilstandsfulle økter**: Opprettholder tilkoblingstilstand på tvers av flere interaksjoner for å sikre kontekstens kontinuitet  

### Transportlag

**Transportlaget** administrerer kommunikasjonskanaler, meldingstrukturering og autentisering mellom MCP-deltakere:

#### Støttede transportmekanismer:

1. **STDIO-transport**:
   - Bruker standard inn-/utstrømmer for direkte prosesskommunikasjon  
   - Optimalt for lokale prosesser på samme maskin uten nettverksbelastning  
   - Vanlig brukt for lokale MCP-serverimplementasjoner  

2. **Streambar HTTP-transport**:
   - Bruker HTTP POST for meldinger fra klient til server  
   - Valgfri Server-Sent Events (SSE) for strømming fra server til klient  
   - Muliggjør kommunikasjon med eksterne servere over nettverk  
   - Støtter standard HTTP-autentisering (bearer tokens, API-nøkler, egendefinerte overskrifter)  
   - MCP anbefaler OAuth for sikker tokenbasert autentisering  

#### Transportabstraksjon:

Transportlaget abstraherer kommunikasjonsdetaljer fra datalaget, slik at samme JSON-RPC 2.0-meldingsformat kan brukes på tvers av alle transportmekanismer. Denne abstraksjonen gjør det mulig for applikasjoner å bytte sømløst mellom lokale og eksterne servere.

### Sikkerhetshensyn

MCP-implementasjoner må følge flere kritiske sikkerhetsprinsipper for å sikre trygge, pålitelige og sikre interaksjoner på tvers av alle protokolloperasjoner:

- **Brukersamtykke og kontroll**: Brukere må gi eksplisitt samtykke før data blir aksessert eller operasjoner utføres. De bør ha klar kontroll over hvilke data som deles og hvilke handlinger som er autorisert, støttet av intuitive brukergrensesnitt for gjennomgang og godkjenning av aktiviteter.  

- **Datapersonvern**: Brukerdata skal kun eksponeres med eksplisitt samtykke og må beskyttes med passende tilgangskontroller. MCP-implementasjoner må forhindre uautorisert datatransmisjon og sikre at personvernet opprettholdes gjennom alle interaksjoner.  

- **Verktøysikkerhet**: Før et verktøy aktiveres, kreves eksplisitt brukersamtykke. Brukere bør ha en klar forståelse av hvert verktøys funksjonalitet, og robuste sikkerhetsgrenser må håndheves for å forhindre utilsiktet eller usikker bruk av verktøy.  

Ved å følge disse sikkerhetsprinsippene sikrer MCP at brukertillit, personvern og sikkerhet opprettholdes på tvers av alle protokollinteraksjoner, samtidig som kraftige AI-integrasjoner muliggjøres.

## Eksempler på kode: Nøkkelkomponenter

Nedenfor er kodeeksempler i flere populære programmeringsspråk som viser hvordan man implementerer sentrale MCP-serverkomponenter og verktøy.

### .NET-eksempel: Opprette en enkel MCP-server med verktøy

Her er et praktisk .NET-eksempel som viser hvordan man implementerer en enkel MCP-server med egendefinerte verktøy. Eksemplet viser hvordan man definerer og registrerer verktøy, håndterer forespørsler og kobler til serveren ved hjelp av Model Context Protocol.

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

Dette eksemplet viser samme MCP-server og verktøyregistrering som i .NET-eksemplet ovenfor, men implementert i Java.

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

I dette eksemplet viser vi hvordan man bygger en MCP-server i Python. Du får også se to forskjellige måter å opprette verktøy på.

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

### JavaScript-eksempel: Opprette en MCP-server

Dette eksemplet viser hvordan man oppretter en MCP-server i JavaScript og registrerer to værrelaterte verktøy.

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

Dette JavaScript-eksemplet demonstrerer hvordan man oppretter en MCP-klient som kobler til en server, sender en prompt og behandler responsen, inkludert eventuelle verktøykall som ble utført.

## Sikkerhet og autorisasjon

MCP inkluderer flere innebygde konsepter og mekanismer for å håndtere sikkerhet og autorisasjon gjennom hele protokollen:

1. **Kontroll av verktøytillatelser**:  
   Klienter kan spesifisere hvilke verktøy en modell har lov til å bruke under en økt. Dette sikrer at kun eksplisitt autoriserte verktøy er tilgjengelige, og reduserer risikoen for utilsiktede eller usikre operasjoner. Tillatelser kan konfigureres dynamisk basert på brukerpreferanser, organisasjonspolicyer eller konteksten for interaksjonen.  

2. **Autentisering**:  
   Servere kan kreve autentisering før tilgang gis til verktøy, ressurser eller sensitive operasjoner. Dette kan innebære API-nøkler, OAuth-tokens eller andre autentiseringsmetoder. Riktig autentisering sikrer at kun pålitelige klienter og brukere kan benytte serverens funksjonalitet.  

3. **Validering**:  
   Parametervalidering håndheves for alle verktøykall. Hvert verktøy definerer forventede typer, formater og begrensninger for sine parametere, og serveren validerer innkommende forespørsler deretter. Dette forhindrer feilformede eller ondsinnede inndata fra å nå verktøyimplementasjoner og bidrar til å opprettholde operasjonenes integritet.  

4. **Begrensning av forespørsler**:  
   For å forhindre misbruk og sikre rettferdig bruk av serverressurser, kan MCP-servere implementere begrensning av forespørsler for verktøykall og ressursbruk. Begrensninger kan anvendes per bruker, per økt eller globalt, og bidrar til å beskytte mot tjenestenektangrep eller overdreven ressursbruk.  

Ved å kombinere disse mekanismene gir MCP et sikkert grunnlag for å integrere språkmodeller med eksterne verktøy og datakilder, samtidig som brukere og utviklere får detaljert kontroll over tilgang og bruk.

## Protokollmeldinger og kommunikasjonsflyt

MCP-kommunikasjon bruker strukturerte **JSON-RPC 2.0**-meldinger for å legge til rette for klare og pålitelige interaksjoner mellom verter, klienter og servere. Protokollen definerer spesifikke meldingsmønstre for ulike typer operasjoner:

### Kjerne meldingstyper:

#### **Initialiseringsmeldinger**
- **`initialize` Request**: Etablerer tilkobling og forhandler protokollversjon og funksjonalitet  
- **`initialize` Response**: Bekrefter støttede funksjoner og serverinformasjon  
- **`notifications/initialized`**: Signalerer at initialiseringen er fullført og økten er klar  

#### **Oppdagelsesmeldinger**
- **`tools/list` Request**: Oppdager tilgjengelige verktøy fra serveren  
- **`resources/list` Request**: Lister tilgjengelige ressurser (datakilder)  
- **`prompts/list` Request**: Henter tilgjengelige maler  

#### **Utførelsesmeldinger**  
- **`tools/call` Request**: Utfører et spesifikt verktøy med oppgitte parametere  
- **`resources/read` Request**: Henter innhold fra en spesifikk ressurs  
- **`prompts/get` Request**: Henter en mal med valgfrie parametere  

#### **Klientmeldinger**
- **`sampling/complete` Request**: Serveren ber om LLM-fullføring fra klienten  
- **`elicitation/request`**: Serveren ber om brukerinput via klientgrensesnittet  
- **Loggmeldinger**: Serveren sender strukturerte loggmeldinger til klienten  

#### **Varslingsmeldinger**
- **`notifications/tools/list_changed`**: Serveren varsler klienten om endringer i verktøy  
- **`notifications/resources/list_changed`**: Serveren varsler klienten om endringer i ressurser  
- **`notifications/prompts/list_changed`**: Serveren varsler klienten om endringer i maler  

### Meldingsstruktur:

Alle MCP-meldinger følger JSON-RPC 2.0-formatet med:  
- **Forespørselsmeldinger**: Inkluderer `id`, `method` og valgfrie `params`  
- **Svarmeldinger**: Inkluderer `id` og enten `result` eller `error`  
- **Varslingsmeldinger**: Inkluderer `method` og valgfrie `params` (ingen `id` eller svar forventet)  

Denne strukturerte kommunikasjonen sikrer pålitelige, sporbare og utvidbare interaksjoner som støtter avanserte scenarier som sanntidsoppdateringer, verktøykjeding og robust feilhåndtering.

## Viktige punkter

- **Arkitektur**: MCP bruker en klient-server-arkitektur der verter håndterer flere klienttilkoblinger til servere  
- **Deltakere**: Økosystemet inkluderer verter (AI-applikasjoner), klienter (protokolltilkoblere) og servere (funksjonalitetsleverandører)  
- **Transportmekanismer**: Kommunikasjon støtter STDIO (lokalt) og Streambar HTTP med valgfri SSE (eksternt)  
- **Kjerneprimitiver**: Servere eksponerer verktøy (kjørbare funksjoner), ressurser (datakilder) og maler (templates)  
- **Klientprimitiver**: Servere kan be om prøvetaking (LLM-fullføringer), innhenting (brukerinput) og logging fra klienter  
- **Protokollgrunnlag**: Bygget på JSON-RPC 2.0 med datobasert versjonering (nåværende: 2025-06-18)  
- **Sanntidsfunksjonalitet**: Støtter varsler for dynamiske oppdateringer og sanntidssynkronisering  
- **Sikkerhet først**: Eksplisitt brukersamtykke, beskyttelse av personvern og sikker transport er kjernekrav  

## Øvelse

Design et enkelt MCP-verktøy som ville vært nyttig i ditt fagområde. Definer:  
1. Hva verktøyet skal hete  
2. Hvilke parametere det skal akseptere  
3. Hvilket output det skal returnere  
4. Hvordan en modell kan bruke dette verktøyet for å løse brukerproblemer  

---

## Hva skjer videre

Neste: [Kapittel 2: Sikkerhet](../02-Security/README.md)  

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.