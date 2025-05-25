<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T22:46:31+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sl"
}
-->
# 📖 MCP Core Concepts: Mastering the Model Context Protocol for AI Integration

Model Context Protocol (MCP) je močan, standardiziran okvir, ki optimizira komunikacijo med velikimi jezikovnimi modeli (LLM) in zunanjimi orodji, aplikacijami ter podatkovnimi viri. Ta SEO-optimiziran vodič vas bo popeljal skozi osnovne koncepte MCP, da boste razumeli njegovo klient-strežniško arhitekturo, ključne komponente, mehanizme komunikacije in najboljše prakse za implementacijo.

## Pregled

Ta lekcija raziskuje osnovno arhitekturo in komponente, ki sestavljajo ekosistem Model Context Protocol (MCP). Spoznali boste klient-strežniško arhitekturo, ključne komponente in komunikacijske mehanizme, ki poganjajo interakcije MCP.

## 👩‍🎓 Ključni cilji učenja

Ob koncu te lekcije boste:

- Razumeli MCP klient-strežniško arhitekturo.
- Prepoznali vloge in odgovornosti Hosts, Clients in Servers.
- Analizirali glavne značilnosti, ki MCP naredijo prilagodljivo integracijsko plast.
- Spoznali, kako poteka pretok informacij znotraj MCP ekosistema.
- Pridobili praktične vpoglede preko primerov kode v .NET, Javi, Pythonu in JavaScriptu.

## 🔎 MCP Arhitektura: Pogled od blizu

Ekosistem MCP temelji na klient-strežniškem modelu. Ta modularna struktura omogoča AI aplikacijam učinkovito interakcijo z orodji, bazami podatkov, API-ji in kontekstualnimi viri. Razdelimo to arhitekturo na ključne komponente.

### 1. Hosts

V Model Context Protocol (MCP) imajo Hosts ključno vlogo kot primarni vmesnik, preko katerega uporabniki komunicirajo s protokolom. Hosts so aplikacije ali okolja, ki vzpostavijo povezave z MCP strežniki za dostop do podatkov, orodij in pozivov. Primeri Hosts so integrirana razvojna okolja (IDE) kot Visual Studio Code, AI orodja kot Claude Desktop ali po meri izdelani agenti za specifične naloge.

**Hosts** so LLM aplikacije, ki vzpostavljajo povezave. Njihove naloge so:

- Izvajanje ali interakcija z AI modeli za generiranje odgovorov.
- Vzpostavljanje povezav z MCP strežniki.
- Upravljanje poteka pogovora in uporabniškega vmesnika.
- Nadzor dovoljenj in varnostnih omejitev.
- Upravljanje uporabniškega soglasja za deljenje podatkov in izvajanje orodij.

### 2. Clients

Clients so ključne komponente, ki olajšajo interakcijo med Hosts in MCP strežniki. Delujejo kot posredniki, ki omogočajo Hostom dostop in uporabo funkcionalnosti MCP strežnikov. Igrajo pomembno vlogo pri zagotavljanju nemotenega komuniciranja in učinkovite izmenjave podatkov v MCP arhitekturi.

**Clients** so konektorji znotraj host aplikacije. Njihove naloge so:

- Pošiljanje zahtev strežnikom s pozivi/instrukcijami.
- Pogajanje o zmožnostih s strežniki.
- Upravljanje zahtev za izvajanje orodij s strani modelov.
- Obdelava in prikaz odgovorov uporabnikom.

### 3. Servers

Servers so odgovorni za obdelavo zahtev MCP klientov in zagotavljanje ustreznih odgovorov. Upravljajo različne operacije, kot so pridobivanje podatkov, izvajanje orodij in generiranje pozivov. Servers zagotavljajo, da je komunikacija med klienti in Hosts učinkovita in zanesljiva ter ohranjajo integriteto procesa interakcije.

**Servers** so storitve, ki zagotavljajo kontekst in zmožnosti. Njihove naloge so:

- Registracija razpoložljivih funkcij (viri, pozivi, orodja).
- Sprejem in izvajanje klicev orodij od klienta.
- Zagotavljanje kontekstualnih informacij za izboljšanje odgovorov modela.
- Vračanje rezultatov klientu.
- Ohranjanje stanja med interakcijami, če je potrebno.

Servers lahko razvije kdorkoli, da razširi zmogljivosti modela s specializirano funkcionalnostjo.

### 4. Lastnosti strežnikov

Strežniki v Model Context Protocol (MCP) nudijo osnovne gradnike, ki omogočajo bogate interakcije med klienti, hosti in jezikovnimi modeli. Te lastnosti so zasnovane za izboljšanje zmogljivosti MCP z zagotavljanjem strukturiranega konteksta, orodij in pozivov.

MCP strežniki lahko nudijo katerokoli od naslednjih funkcij:

#### 📑 Viri

Viri v Model Context Protocol (MCP) zajemajo različne vrste konteksta in podatkov, ki jih lahko uporabijo uporabniki ali AI modeli. Ti vključujejo:

- **Kontekstualni podatki**: Informacije in kontekst, ki jih uporabniki ali AI modeli lahko uporabijo za odločanje in izvedbo nalog.
- **Baze znanja in zbirke dokumentov**: Zbirke strukturiranih in nestrukturiranih podatkov, kot so članki, priročniki in raziskovalni dokumenti, ki nudijo dragocene vpoglede in informacije.
- **Lokalne datoteke in baze podatkov**: Podatki, shranjeni lokalno na napravah ali v bazah podatkov, dostopni za obdelavo in analizo.
- **API-ji in spletne storitve**: Zunanji vmesniki in storitve, ki nudijo dodatne podatke in funkcionalnosti ter omogočajo integracijo z različnimi spletnimi viri in orodji.

Primer vira je lahko shema baze podatkov ali datoteka, do katere dostopate takole:

```text
file://log.txt
database://schema
```

### 🤖 Pozivi

Pozivi v Model Context Protocol (MCP) vključujejo različne vnaprej določene predloge in vzorce interakcije, ki poenostavljajo uporabniške delovne tokove in izboljšajo komunikacijo. Ti vključujejo:

- **Predstrukturirana sporočila in delovni tokovi**: Vnaprej oblikovana sporočila in procesi, ki vodijo uporabnike skozi specifične naloge in interakcije.
- **Vnaprej določeni vzorci interakcije**: Standardizirani zaporedji dejanj in odgovorov, ki omogočajo dosledno in učinkovito komunikacijo.
- **Specializirane predloge pogovorov**: Prilagodljive predloge, namenjene specifičnim vrstam pogovorov, ki zagotavljajo relevantne in kontekstualno primerne interakcije.

Predloga poziva je lahko videti takole:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Orodja

Orodja v Model Context Protocol (MCP) so funkcije, ki jih lahko AI model izvede za opravljanje specifičnih nalog. Ta orodja so zasnovana za izboljšanje zmogljivosti AI modela z zagotavljanjem strukturiranih in zanesljivih operacij. Ključni vidiki vključujejo:

- **Funkcije za izvedbo AI modela**: Orodja so izvršljive funkcije, ki jih AI model lahko pokliče za izvedbo različnih nalog.
- **Edinstveno ime in opis**: Vsako orodje ima jasno ime in podroben opis, ki pojasnjuje njegov namen in funkcionalnost.
- **Parametri in rezultati**: Orodja sprejemajo določene parametre in vračajo strukturirane rezultate, kar zagotavlja dosledne in predvidljive izide.
- **Diskretne funkcije**: Orodja opravljajo ločene funkcije, kot so spletno iskanje, izračuni in poizvedbe v bazah podatkov.

Primer orodja je lahko videti takole:

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

## Lastnosti klientov

V Model Context Protocol (MCP) klienti strežnikom nudijo več ključnih funkcij, ki izboljšujejo celotno funkcionalnost in interakcijo znotraj protokola. Ena izmed pomembnih funkcij je Sampling.

### 👉 Sampling

- **Agentne vedenjske akcije, ki jih sproži strežnik**: Klienti omogočajo strežnikom, da samostojno sprožijo določena dejanja ali vedenja, kar povečuje dinamične zmogljivosti sistema.
- **Rekurzivne interakcije z LLM**: Ta funkcija omogoča rekurzivne interakcije z velikimi jezikovnimi modeli, kar omogoča bolj zapleteno in iterativno obdelavo nalog.
- **Zahteva po dodatnih zaključkih modela**: Strežniki lahko zahtevajo dodatne zaključke od modela, da so odgovori celoviti in kontekstualno ustrezni.

## Pretok informacij v MCP

Model Context Protocol (MCP) določa strukturiran pretok informacij med hosti, klienti, strežniki in modeli. Razumevanje tega pretoka pomaga razjasniti, kako se uporabniške zahteve obdelujejo in kako se zunanji podatki ter orodja vključujejo v odgovore modela.

- **Host vzpostavi povezavo**  
  Host aplikacija (npr. IDE ali klepetalni vmesnik) vzpostavi povezavo z MCP strežnikom, običajno preko STDIO, WebSocket ali drugega podprt transporta.

- **Pogajanje o zmožnostih**  
  Klient (vgrajen v host) in strežnik si izmenjata informacije o podprtih funkcijah, orodjih, virih in različicah protokola. Tako obe strani razumeta, katere zmožnosti so na voljo za sejo.

- **Uporabniška zahteva**  
  Uporabnik komunicira z hostom (npr. vnese poziv ali ukaz). Host zbere ta vhod in ga posreduje klientu za obdelavo.

- **Uporaba vira ali orodja**  
  - Klient lahko zahteva dodatni kontekst ali vire od strežnika (kot so datoteke, vnosi v bazi ali članki iz baze znanja), da obogati razumevanje modela.
  - Če model presodi, da je potrebno orodje (npr. za pridobivanje podatkov, izračun ali klic API-ja), klient pošlje strežniku zahtevo za izvedbo orodja, pri čemer navede ime orodja in parametre.

- **Izvedba strežnika**  
  Strežnik prejme zahtevo za vir ali orodje, izvede potrebne operacije (kot so izvajanje funkcije, poizvedba v bazi ali pridobivanje datoteke) in vrne rezultate klientu v strukturirani obliki.

- **Generiranje odgovora**  
  Klient integrira strežnikove odgovore (podatke vira, izhode orodij itd.) v tekočo interakcijo z modelom. Model uporabi te informacije za generiranje celovitega in kontekstualno ustreznega odgovora.

- **Prikaz rezultata**  
  Host prejme končni izhod od klienta in ga prikaže uporabniku, pogosto vključujoč tako generirano besedilo modela kot tudi rezultate izvajanja orodij ali iskanja po virih.

Ta tok omogoča MCP, da podpira napredne, interaktivne in kontekstualno ozaveščene AI aplikacije z brezhibno povezavo modelov z zunanjimi orodji in podatkovnimi viri.

## Podrobnosti protokola

MCP (Model Context Protocol) temelji na [JSON-RPC 2.0](https://www.jsonrpc.org/), ki zagotavlja standardiziran, jezikovno neodvisen format sporočil za komunikacijo med hosti, klienti in strežniki. Ta osnova omogoča zanesljive, strukturirane in razširljive interakcije preko različnih platform in programskih jezikov.

### Ključne lastnosti protokola

MCP širi JSON-RPC 2.0 z dodatnimi konvencijami za klic orodij, dostop do virov in upravljanje pozivov. Podpira več transportnih plasti (STDIO, WebSocket, SSE) ter omogoča varno, razširljivo in jezikovno neodvisno komunikacijo med komponentami.

#### 🧢 Osnovni protokol

- **JSON-RPC format sporočil**: Vse zahteve in odgovori uporabljajo specifikacijo JSON-RPC 2.0, kar zagotavlja dosledno strukturo za klice metod, parametre, rezultate in obravnavo napak.
- **Stanje povezav**: MCP seje ohranjajo stanje čez več zahtev, podpirajo tekoče pogovore, kopičenje konteksta in upravljanje virov.
- **Pogajanje o zmožnostih**: Med vzpostavitvijo povezave si klienti in strežniki izmenjajo informacije o podprtih funkcijah, različicah protokola, razpoložljivih orodjih in virih. Tako obe strani razumejo zmogljivosti in se lahko prilagodijo.

#### ➕ Dodatna orodja

Spodaj so dodatna orodja in razširitve protokola, ki jih MCP ponuja za izboljšanje izkušnje razvijalcev in omogočanje naprednih scenarijev:

- **Možnosti konfiguracije**: MCP omogoča dinamično konfiguracijo parametrov seje, kot so dovoljenja za orodja, dostop do virov in nastavitve modela, prilagojene vsaki interakciji.
- **Sledenje napredku**: Dolgotrajne operacije lahko poročajo o napredku, kar omogoča odzivne uporabniške vmesnike in boljšo uporabniško izkušnjo med kompleksnimi nalogami.
- **Preklic zahtev**: Klienti lahko prekličejo tekoče zahteve, kar uporabnikom omogoča prekinitev operacij, ki niso več potrebne ali trajajo predolgo.
- **Poročanje o napakah**: Standardizirana sporočila o napakah in kode pomagajo diagnosticirati težave, obravnavati napake brez prekinitev in nuditi uporabne povratne informacije uporabnikom in razvijalcem.
- **Zapisovanje**: Tako klienti kot strežniki lahko oddajajo strukturirane zapise za revizijo, odpravljanje napak in nadzor interakcij protokola.

Z uporabo teh funkcij MCP zagotavlja robustno, varno in prilagodljivo komunikacijo med jezikovnimi modeli in zunanjimi orodji ali podatkovnimi viri.

### 🔐 Varnostni vidiki

Implementacije MCP bi morale slediti več ključnim varnostnim načelom, da zagotovijo varne in zanesljive interakcije:

- **Uporabniško soglasje in nadzor**: Uporabniki morajo izrecno dati soglasje, preden se dostopajo podatki ali izvajajo operacije. Morajo imeti jasen nadzor nad tem, kateri podatki se delijo in katere akcije so odobrene, podprto z intuitivnimi uporabniškimi vmesniki za pregled in potrditev dejavnosti.

- **Zasebnost podatkov**: Uporabniški podatki naj bodo dostopni le z izrecnim soglasjem in zaščiteni z ustreznimi dostopnimi kontrolami. Implementacije MCP morajo preprečiti nepooblaščen prenos podatkov in zagotoviti ohranjanje zasebnosti skozi vse interakcije.

- **Varnost orodij**: Pred klicem kateregakoli orodja je potrebno izrecno uporabniško soglasje. Uporabniki morajo jasno razumeti funkcionalnost vsakega orodja, hkrati pa morajo biti vzpostavljene robustne varnostne meje, ki preprečujejo nenamerno ali nevarno izvajanje orodij.

S spoštovanjem teh načel MCP zagotavlja, da je zaupanje uporabnikov, zasebnost in varnost ohranjena skozi vse interakcije protokola.

## Primeri kode: ključne komponente

Spodaj so primeri kode v več priljubljenih programskih jezikih, ki prikazujejo, kako implementirati ključne MCP strežniške komponente in orodja.

### .NET primer: Ustvarjanje preprostega MCP strežnika z orodji

Tukaj je praktičen .NET primer kode, ki prikazuje, kako implementirati preprost MCP strežnik s po meri izdelanimi orodji. Primer prikazuje, kako definirati in registrirati orodja, obdelovati zahteve in povezati strežnik z Model Context Protocol.

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

### Java primer: MCP strežniške komponente

Ta primer prikazuje enak MCP strežnik in registracijo orodij kot zgornji .NET primer, vendar izvedeno v Javi.

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

### Python primer: Izgradnja MCP strežnika

V tem primeru pokažemo, kako zgraditi MCP strežnik v Pythonu. Prikazana sta tudi dva različna načina ustvarjanja orodij.

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

### JavaScript primer: Ustvarjanje MCP strežnika

Ta primer prikazuje ustvarjanje MCP strežnika v JavaScriptu in registracijo dveh orodij, povezanih z vremenskimi podatki.

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

Ta JavaScript primer prikazuje, kako ustvariti MCP klienta, ki se poveže s strežnikom, pošlje poziv in obdela odgovor, vključno z vsemi opravljenimi klici orodij.

## Varnost in pooblastila

MCP vključuje več vgrajenih konceptov in mehanizmov za upravljanje varnosti in pooblastil skozi celoten protokol:

1. **Nadzor dovoljenj za orodja**  


**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.