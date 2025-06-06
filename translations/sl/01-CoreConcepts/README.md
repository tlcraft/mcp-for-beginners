<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:53:36+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sl"
}
-->
# 📖 MCP Core Concepts: Mestrevanje Model Context Protocol za AI Integracijo

Model Context Protocol (MCP) je močan, standardiziran okvir, ki optimizira komunikacijo med velikimi jezikovnimi modeli (LLM) in zunanjimi orodji, aplikacijami ter podatkovnimi viri. Ta SEO-optimiziran vodič vas bo popeljal skozi osnovne koncepte MCP, da boste razumeli njegovo klient-strežniško arhitekturo, ključne komponente, mehanizme komunikacije in najboljše prakse implementacije.

## Pregled

Ta lekcija raziskuje temeljno arhitekturo in komponente, ki sestavljajo MCP ekosistem. Naučili se boste o klient-strežniški arhitekturi, ključnih elementih in komunikacijskih mehanizmih, ki poganjajo MCP interakcije.

## 👩‍🎓 Ključni cilji učenja

Ob koncu te lekcije boste:

- Razumeli MCP klient-strežniško arhitekturo.
- Prepoznali vloge in odgovornosti Hostov, Klientov in Strežnikov.
- Analizirali osnovne funkcije, ki naredijo MCP fleksibilno integracijsko plast.
- Spoznali, kako poteka pretok informacij znotraj MCP ekosistema.
- Pridobili praktične vpoglede preko primerov kode v .NET, Javi, Pythonu in JavaScriptu.

## 🔎 MCP Arhitektura: Podrobnejši pogled

MCP ekosistem temelji na klient-strežniškem modelu. Ta modularna struktura omogoča AI aplikacijam učinkovito interakcijo z orodji, bazami podatkov, API-ji in kontekstualnimi viri. Razčlenimo to arhitekturo na njene osnovne komponente.

### 1. Hosti

V Model Context Protocolu (MCP) imajo Hosti ključno vlogo kot glavni vmesnik, preko katerega uporabniki komunicirajo s protokolom. Hosti so aplikacije ali okolja, ki vzpostavljajo povezave s MCP strežniki za dostop do podatkov, orodij in pozivov. Primeri Hostov so integrirana razvojna okolja (IDE) kot Visual Studio Code, AI orodja kot Claude Desktop ali po meri izdelani agenti za specifične naloge.

**Hosti** so LLM aplikacije, ki vzpostavljajo povezave. Oni:

- Izvajajo ali sodelujejo z AI modeli za generiranje odgovorov.
- Vzpostavljajo povezave z MCP strežniki.
- Upravljajo tok pogovora in uporabniški vmesnik.
- Nadzorujejo dovoljenja in varnostne omejitve.
- Upravljajo uporabniško soglasje za deljenje podatkov in izvajanje orodij.

### 2. Klienti

Klienti so ključni elementi, ki omogočajo interakcijo med Hosti in MCP strežniki. Delujejo kot posredniki, ki Hostom omogočajo dostop in uporabo funkcionalnosti MCP strežnikov. Imajo pomembno vlogo pri zagotavljanju nemotenega komuniciranja in učinkovite izmenjave podatkov znotraj MCP arhitekture.

**Klienti** so povezovalci znotraj host aplikacije. Oni:

- Pošiljajo zahteve strežnikom s pozivi/instrukcijami.
- Pogajajo se o zmogljivostih s strežniki.
- Upravljajo zahteve za izvajanje orodij iz modelov.
- Obdelujejo in prikazujejo odgovore uporabnikom.

### 3. Strežniki

Strežniki so odgovorni za obdelavo zahtev od MCP klientov in zagotavljanje ustreznih odgovorov. Upravljajo različne operacije, kot so pridobivanje podatkov, izvajanje orodij in generiranje pozivov. Strežniki zagotavljajo, da je komunikacija med klienti in Hosti učinkovita in zanesljiva ter ohranjajo integriteto procesa interakcije.

**Strežniki** so storitve, ki zagotavljajo kontekst in zmogljivosti. Oni:

- Registrirajo razpoložljive funkcije (viri, pozivi, orodja)
- Prejemajo in izvajajo klice orodij od klienta
- Zagotavljajo kontekstualne informacije za izboljšanje odgovorov modela
- Vračajo izhode nazaj klientu
- Po potrebi ohranjajo stanje med interakcijami

Strežnike lahko razvije kdorkoli, da razširi zmogljivosti modela s specializirano funkcionalnostjo.

### 4. Funkcije strežnika

Strežniki v Model Context Protocolu (MCP) zagotavljajo temeljne gradnike, ki omogočajo bogate interakcije med klienti, hosti in jezikovnimi modeli. Te funkcije so zasnovane za izboljšanje zmogljivosti MCP z zagotavljanjem strukturiranega konteksta, orodij in pozivov.

MCP strežniki lahko ponudijo katerokoli od naslednjih funkcij:

#### 📑 Viri

Viri v Model Context Protocolu (MCP) zajemajo različne vrste konteksta in podatkov, ki jih lahko uporabljajo uporabniki ali AI modeli. Ti vključujejo:

- **Kontekstualni podatki**: Informacije in kontekst, ki jih uporabniki ali AI modeli lahko uporabijo za odločanje in izvedbo nalog.
- **Baze znanja in zbirke dokumentov**: Zbirke strukturiranih in nestrukturiranih podatkov, kot so članki, priročniki in raziskovalni dokumenti, ki nudijo dragocene vpoglede in informacije.
- **Lokalne datoteke in baze podatkov**: Podatki, shranjeni lokalno na napravah ali v bazah podatkov, dostopni za obdelavo in analizo.
- **API-ji in spletne storitve**: Zunanji vmesniki in storitve, ki nudijo dodatne podatke in funkcionalnosti, omogočajo integracijo z različnimi spletnimi viri in orodji.

Primer vira je lahko shema baze podatkov ali datoteka, do katere dostopamo takole:

```text
file://log.txt
database://schema
```

### 🤖 Pozivi

Pozivi v Model Context Protocolu (MCP) vključujejo različne vnaprej določene predloge in vzorce interakcij, zasnovane za poenostavitev uporabniških delovnih tokov in izboljšanje komunikacije. Ti vključujejo:

- **Predloge sporočil in delovnih tokov**: Vnaprej strukturirana sporočila in procesi, ki vodijo uporabnike skozi specifične naloge in interakcije.
- **Vnaprej določeni vzorci interakcij**: Standardizirani zaporedji dejanj in odgovorov, ki omogočajo konsistentno in učinkovito komunikacijo.
- **Specializirane predloge pogovorov**: Prilagodljive predloge, namenjene specifičnim vrstam pogovorov, ki zagotavljajo relevantne in kontekstualno primerne interakcije.

Predloga poziva je lahko videti takole:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Orodja

Orodja v Model Context Protocolu (MCP) so funkcije, ki jih lahko AI model izvede za opravljanje specifičnih nalog. Ta orodja so zasnovana za izboljšanje zmogljivosti AI modela z zagotavljanjem strukturiranih in zanesljivih operacij. Ključni vidiki vključujejo:

- **Funkcije, ki jih AI model lahko izvede**: Orodja so izvršljive funkcije, ki jih AI model lahko pokliče za izvedbo različnih nalog.
- **Edinstveno ime in opis**: Vsako orodje ima svoje ime in podroben opis, ki pojasnjuje njegov namen in funkcionalnost.
- **Parametri in izhodi**: Orodja sprejemajo določene parametre in vračajo strukturirane rezultate, kar zagotavlja dosledne in predvidljive izide.
- **Diskretne funkcije**: Orodja izvajajo ločene funkcije, kot so spletna iskanja, izračuni in poizvedbe v bazah podatkov.

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

## Funkcije klienta

V Model Context Protocolu (MCP) klienti strežnikom nudijo več ključnih funkcij, ki izboljšujejo splošno funkcionalnost in interakcijo znotraj protokola. Ena izmed pomembnih funkcij je Sampling.

### 👉 Sampling

- **Agentna vedenja, ki jih sproži strežnik**: Klienti omogočajo strežnikom, da samostojno sprožijo določena dejanja ali vedenja, kar izboljšuje dinamične zmogljivosti sistema.
- **Rekurzivne LLM interakcije**: Ta funkcija omogoča rekurzivne interakcije z velikimi jezikovnimi modeli (LLM), kar omogoča bolj kompleksno in iterativno obdelavo nalog.
- **Zahteva po dodatnih zaključkih modela**: Strežniki lahko zahtevajo dodatne zaključke od modela, da zagotovijo temeljite in kontekstualno ustrezne odgovore.

## Pretok informacij v MCP

Model Context Protocol (MCP) definira strukturiran pretok informacij med hosti, klienti, strežniki in modeli. Razumevanje tega pretoka pomaga razjasniti, kako se uporabniške zahteve obdelujejo in kako se zunanja orodja ter podatki integrirajo v odzive modela.

- **Host vzpostavi povezavo**  
  Host aplikacija (kot IDE ali klepetalni vmesnik) vzpostavi povezavo z MCP strežnikom, običajno preko STDIO, WebSocket ali druge podprte povezave.

- **Pogajanje o zmogljivostih**  
  Klient (vgrajen v host) in strežnik si izmenjata informacije o podprtih funkcijah, orodjih, virih in verzijah protokola. To zagotavlja, da obe strani razumeta, katere zmogljivosti so na voljo za sejo.

- **Uporabniška zahteva**  
  Uporabnik komunicira z hostom (npr. vnese poziv ali ukaz). Host zbere ta vhod in ga posreduje klientu v obdelavo.

- **Uporaba vira ali orodja**  
  - Klient lahko zahteva dodatni kontekst ali vire od strežnika (kot so datoteke, vnosi v bazi ali članki iz baze znanja) za bogatenje razumevanja modela.  
  - Če model ugotovi, da je potrebno orodje (npr. za pridobivanje podatkov, izvedbo izračuna ali klic API-ja), klient pošlje zahtevo za izvedbo orodja strežniku, pri čemer navede ime orodja in parametre.

- **Izvedba strežnika**  
  Strežnik prejme zahtevo za vir ali orodje, izvede potrebne operacije (kot je izvajanje funkcije, poizvedba v bazi ali pridobivanje datoteke) in vrne rezultate klientu v strukturirani obliki.

- **Generiranje odgovora**  
  Klient integrira odgovore strežnika (podatke virov, izhode orodij itd.) v tekočo interakcijo z modelom. Model uporabi te informacije za ustvarjanje celovitega in kontekstualno ustreznega odgovora.

- **Prikaz rezultata**  
  Host prejme končni izhod od klienta in ga predstavi uporabniku, pogosto vključno z generiranim besedilom modela in rezultati izvedbe orodij ali iskanja virov.

Ta pretok omogoča MCP podporo naprednim, interaktivnim in kontekstualno ozaveščenim AI aplikacijam z nemoteno povezavo modelov z zunanjimi orodji in podatkovnimi viri.

## Podrobnosti protokola

MCP (Model Context Protocol) temelji na [JSON-RPC 2.0](https://www.jsonrpc.org/), ki zagotavlja standardiziran, jezikovno neodvisen format sporočil za komunikacijo med hosti, klienti in strežniki. Ta osnova omogoča zanesljive, strukturirane in razširljive interakcije na različnih platformah in programskih jezikih.

### Ključne lastnosti protokola

MCP razširja JSON-RPC 2.0 z dodatnimi konvencijami za klic orodij, dostop do virov in upravljanje pozivov. Podpira več transportnih slojev (STDIO, WebSocket, SSE) in omogoča varno, razširljivo in jezikovno neodvisno komunikacijo med komponentami.

#### 🧢 Osnovni protokol

- **JSON-RPC format sporočil**: Vse zahteve in odgovori uporabljajo specifikacijo JSON-RPC 2.0, kar zagotavlja dosledno strukturo za klice metod, parametre, rezultate in obravnavo napak.
- **Stanje povezav**: MCP seje ohranjajo stanje med več zahtevami, podpirajo tekoče pogovore, kopičenje konteksta in upravljanje virov.
- **Pogajanje o zmogljivostih**: Med vzpostavitvijo povezave si klienti in strežniki izmenjajo informacije o podprtih funkcijah, verzijah protokola, razpoložljivih orodjih in virih. To zagotavlja, da obe strani razumeta zmogljivosti drug drugega in se lahko ustrezno prilagodita.

#### ➕ Dodatna orodja

Spodaj so nekatere dodatne funkcije in razširitve protokola, ki jih MCP nudi za izboljšanje izkušnje razvijalcev in omogočanje naprednih scenarijev:

- **Konfiguracijske možnosti**: MCP omogoča dinamično konfiguracijo parametrov seje, kot so dovoljenja za orodja, dostop do virov in nastavitve modela, prilagojene za vsako interakcijo.
- **Sledenje napredku**: Dolgotrajne operacije lahko poročajo o napredku, kar omogoča odzivne uporabniške vmesnike in boljšo uporabniško izkušnjo pri kompleksnih nalogah.
- **Preklic zahtev**: Klienti lahko prekličejo aktivne zahteve, kar uporabnikom omogoča prekinitev operacij, ki niso več potrebne ali trajajo predolgo.
- **Poročanje o napakah**: Standardizirana sporočila o napakah in kode pomagajo diagnosticirati težave, obravnavati neuspehe na eleganten način in nuditi uporabne povratne informacije uporabnikom in razvijalcem.
- **Dnevniški zapisi**: Tako klienti kot strežniki lahko ustvarjajo strukturirane dnevnike za revizijo, odpravljanje napak in spremljanje interakcij protokola.

Z uporabo teh funkcij MCP zagotavlja robustno, varno in prilagodljivo komunikacijo med jezikovnimi modeli in zunanjimi orodji ali podatkovnimi viri.

### 🔐 Varnostni vidiki

Implementacije MCP naj upoštevajo več ključnih varnostnih načel za zagotovitev varnih in zaupanja vrednih interakcij:

- **Uporabniško soglasje in nadzor**: Uporabniki morajo dati izrecno soglasje, preden se dostopajo podatki ali izvajajo operacije. Morajo imeti jasen nadzor nad tem, kateri podatki se delijo in katere akcije so odobrene, podprto z intuitivnimi uporabniškimi vmesniki za pregled in odobritev dejavnosti.

- **Zasebnost podatkov**: Uporabniški podatki naj bodo izpostavljeni le z izrecnim soglasjem in zaščiteni z ustreznimi dostopnimi kontrolami. Implementacije MCP morajo preprečiti nepooblaščeno prenos podatkov in zagotoviti ohranjanje zasebnosti skozi vse interakcije.

- **Varnost orodij**: Pred klicem kateregakoli orodja je potrebna izrecna uporabniška privolitev. Uporabniki naj jasno razumejo funkcionalnost posameznega orodja, hkrati pa morajo biti vzpostavljene robustne varnostne meje, ki preprečujejo nenamerno ali nevarno izvajanje orodij.

S spoštovanjem teh načel MCP zagotavlja, da so uporabniško zaupanje, zasebnost in varnost ohranjeni v vseh interakcijah protokola.

## Primeri kode: Ključne komponente

Spodaj so primeri kode v več priljubljenih programskih jezikih, ki prikazujejo, kako implementirati ključne MCP strežniške komponente in orodja.

### Primer v .NET: Ustvarjanje preprostega MCP strežnika z orodji

Tukaj je praktičen primer kode v .NET, ki prikazuje, kako implementirati preprost MCP strežnik s prilagojenimi orodji. Primer prikazuje, kako definirati in registrirati orodja, obdelovati zahteve in povezati strežnik z uporabo Model Context Protocola.

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

### Primer v Javi: MCP strežniške komponente

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

### Primer v Pythonu: Izgradnja MCP strežnika

V tem primeru prikazujemo, kako zgraditi MCP strežnik v Pythonu. Prikazani sta tudi dva različna načina za ustvarjanje orodij.

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

### Primer v JavaScriptu: Ustvarjanje MCP strežnika

Ta primer prikazuje ustvarjanje MCP strežnika v JavaScriptu in kako registrirati dve orodji povezani z vremensko napovedjo.

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

Ta primer JavaScript kode prikazuje, kako ustvariti MCP klienta, ki se poveže s strežnikom, po

**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve AI prevajanja [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za kakršne koli nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.