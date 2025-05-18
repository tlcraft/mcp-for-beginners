<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:39:24+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sl"
}
-->
# 📖 MCP Core Concepts: Mastering the Model Context Protocol for AI Integration

Model Context Protocol (MCP) je močan, standardiziran okvir, ki optimizira komunikacijo med velikimi jezikovnimi modeli (LLM) in zunanjimi orodji, aplikacijami ter podatkovnimi viri. Ta SEO-optimiziran vodič te bo popeljal skozi osnovne koncepte MCP, da boš razumel njegovo klient-strežniško arhitekturo, ključne komponente, mehanizme komunikacije in najboljše prakse implementacije.

## Pregled

Ta lekcija raziskuje osnovno arhitekturo in komponente, ki sestavljajo MCP ekosistem. Spoznal boš klient-strežniško arhitekturo, ključne komponente in komunikacijske mehanizme, ki omogočajo MCP interakcije.

## 👩‍🎓 Ključni cilji učenja

Na koncu te lekcije boš:

- Razumel MCP klient-strežniško arhitekturo.
- Prepoznal vloge in odgovornosti Hostov, Klientov in Strežnikov.
- Analiziral osnovne lastnosti, ki MCP naredijo prilagodljivo integracijsko plast.
- Naučil se, kako poteka pretok informacij znotraj MCP ekosistema.
- Pridobil praktične vpoglede preko primerov kode v .NET, Java, Python in JavaScript.

## 🔎 MCP arhitektura: Podrobnejši pogled

MCP ekosistem temelji na klient-strežniškem modelu. Ta modularna struktura omogoča AI aplikacijam učinkovito interakcijo z orodji, podatkovnimi bazami, API-ji in kontekstualnimi viri. Razdelimo to arhitekturo na njene osnovne komponente.

### 1. Hosti

V Model Context Protocolu (MCP) imajo Hosti ključno vlogo kot primarni vmesnik, preko katerega uporabniki komunicirajo s protokolom. Hosti so aplikacije ali okolja, ki vzpostavijo povezave s MCP strežniki za dostop do podatkov, orodij in pozivov. Primeri Hostov so integrirana razvojna okolja (IDE), kot je Visual Studio Code, AI orodja kot Claude Desktop ali po meri izdelani agenti za specifične naloge.

**Hosti** so LLM aplikacije, ki vzpostavljajo povezave. Oni:

- Izvajajo ali sodelujejo z AI modeli za generiranje odgovorov.
- Začnejo povezave s MCP strežniki.
- Upravljajo potek pogovora in uporabniški vmesnik.
- Nadzorujejo dovoljenja in varnostne omejitve.
- Urejajo uporabniški pristanek za deljenje podatkov in izvajanje orodij.

### 2. Klienti

Klienti so ključne komponente, ki olajšajo interakcijo med Hosti in MCP strežniki. Delujejo kot posredniki, ki omogočajo Hostom dostop in uporabo funkcionalnosti MCP strežnikov. Imajo pomembno vlogo pri zagotavljanju gladke komunikacije in učinkovite izmenjave podatkov znotraj MCP arhitekture.

**Klienti** so konektorji znotraj host aplikacije. Oni:

- Pošiljajo zahteve strežnikom s pozivi/instrukcijami.
- Pogajajo zmogljivosti s strežniki.
- Upravljajo zahteve modelov za izvajanje orodij.
- Procesirajo in prikazujejo odgovore uporabnikom.

### 3. Strežniki

Strežniki so odgovorni za obdelavo zahtev MCP klientov in zagotavljanje ustreznih odgovorov. Upravljajo različne operacije, kot so pridobivanje podatkov, izvajanje orodij in generiranje pozivov. Strežniki zagotavljajo učinkovito in zanesljivo komunikacijo med klienti in Hosti ter ohranjajo integriteto procesa interakcije.

**Strežniki** so storitve, ki zagotavljajo kontekst in zmogljivosti. Oni:

- Registrirajo razpoložljive funkcije (viri, pozivi, orodja)
- Sprejemajo in izvajajo klice orodij od klienta
- Zagotavljajo kontekstualne informacije za izboljšanje odgovorov modela
- Vračajo rezultate nazaj klientu
- Po potrebi ohranjajo stanje med interakcijami

Strežnike lahko razvije kdorkoli, da razširi zmogljivosti modela s specializiranimi funkcionalnostmi.

### 4. Funkcije strežnika

Strežniki v Model Context Protocolu (MCP) nudijo osnovne gradnike, ki omogočajo bogate interakcije med klienti, hosti in jezikovnimi modeli. Te funkcije so zasnovane za izboljšanje zmogljivosti MCP z zagotavljanjem strukturiranega konteksta, orodij in pozivov.

MCP strežniki lahko ponudijo katerokoli od naslednjih funkcij:

#### 📑 Viri

Viri v Model Context Protocolu (MCP) zajemajo različne vrste konteksta in podatkov, ki jih lahko uporabniki ali AI modeli uporabijo. Ti vključujejo:

- **Kontekstualni podatki**: Informacije in kontekst, ki jih uporabniki ali AI modeli lahko izkoristijo za odločanje in izvajanje nalog.
- **Znanstvene baze in zbirke dokumentov**: Zbirke strukturiranih in nestrukturiranih podatkov, kot so članki, priročniki in raziskovalni prispevki, ki nudijo dragocene vpoglede in informacije.
- **Lokalne datoteke in baze podatkov**: Podatki, shranjeni lokalno na napravah ali znotraj baz podatkov, dostopni za obdelavo in analizo.
- **API-ji in spletne storitve**: Zunanji vmesniki in storitve, ki nudijo dodatne podatke in funkcionalnosti ter omogočajo integracijo z različnimi spletnimi viri in orodji.

Primer vira je lahko shema baze podatkov ali datoteka, ki ji lahko dostopaš takole:

```text
file://log.txt
database://schema
```

### 🤖 Pozivi

Pozivi v Model Context Protocolu (MCP) vključujejo različne vnaprej določene predloge in vzorce interakcij, zasnovane za poenostavitev uporabniških potekov in izboljšanje komunikacije. Ti vključujejo:

- **Predstrukturirana sporočila in poteki dela**: Vnaprej oblikovana sporočila in procesi, ki vodijo uporabnike skozi specifične naloge in interakcije.
- **Vnaprej določeni vzorci interakcij**: Standardizirani zaporedji dejanj in odgovorov, ki omogočajo dosledno in učinkovito komunikacijo.
- **Specializirane predloge pogovorov**: Prilagodljive predloge, namenjene določenim vrstam pogovorov, ki zagotavljajo relevantne in kontekstualno primerne interakcije.

Predloga poziva je lahko videti takole:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Orodja

Orodja v Model Context Protocolu (MCP) so funkcije, ki jih lahko AI model izvede za opravljanje specifičnih nalog. Ta orodja so zasnovana za izboljšanje zmogljivosti AI modela z zagotavljanjem strukturiranih in zanesljivih operacij. Ključni vidiki vključujejo:

- **Funkcije, ki jih AI model lahko izvede**: Orodja so izvršljive funkcije, ki jih AI model lahko pokliče za izvedbo različnih nalog.
- **Edinstveno ime in opis**: Vsako orodje ima edinstveno ime in podroben opis, ki pojasnjuje njegov namen in funkcionalnost.
- **Parametri in rezultati**: Orodja sprejemajo specifične parametre in vračajo strukturirane rezultate, kar zagotavlja dosledne in predvidljive izide.
- **Diskretne funkcije**: Orodja opravljajo posamezne funkcije, kot so spletna iskanja, izračuni in poizvedbe v bazah podatkov.

Primer orodja je lahko videti takole:

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

## Funkcije klienta

V Model Context Protocolu (MCP) klienti strežnikom ponujajo več ključnih funkcij, ki izboljšujejo celotno funkcionalnost in interakcijo znotraj protokola. Ena izmed pomembnih funkcij je Sampling.

### 👉 Sampling

- **Strežniško iniciirane agentne obnašanja**: Klienti omogočajo strežnikom, da samostojno sprožijo določena dejanja ali vedenja, kar povečuje dinamične zmogljivosti sistema.
- **Rekurzivne interakcije z LLM**: Ta funkcija omogoča rekurzivne interakcije z velikimi jezikovnimi modeli (LLM), kar omogoča kompleksnejšo in iterativno obdelavo nalog.
- **Zahtevanje dodatnih zaključkov modela**: Strežniki lahko zahtevajo dodatne zaključke modela, s čimer zagotavljajo celovite in kontekstualno ustrezne odgovore.

## Pretok informacij v MCP

Model Context Protocol (MCP) definira strukturiran pretok informacij med hosti, klienti, strežniki in modeli. Razumevanje tega pretoka pomaga razjasniti, kako se obdelujejo uporabniške zahteve in kako se zunanji podatki ter orodja integrirajo v odgovore modela.

- **Host vzpostavi povezavo**  
  Host aplikacija (kot IDE ali klepetalni vmesnik) vzpostavi povezavo s MCP strežnikom, običajno preko STDIO, WebSocket ali drugega podprtega transporta.

- **Pogajanje zmogljivosti**  
  Klient (vgrajen v host) in strežnik si izmenjata informacije o podprtih funkcijah, orodjih, virih in verzijah protokola. To zagotavlja, da obe strani razumeta razpoložljive zmogljivosti za sejo.

- **Uporabniška zahteva**  
  Uporabnik komunicira z hostom (npr. vnese poziv ali ukaz). Host zbere ta vhod in ga posreduje klientu v obdelavo.

- **Uporaba vira ali orodja**  
  - Klient lahko zahteva dodatni kontekst ali vire od strežnika (kot so datoteke, vnosi v bazi ali članki iz znanstvene baze), da obogati razumevanje modela.
  - Če model ugotovi, da je potrebno orodje (npr. za pridobitev podatkov, izračun ali klic API-ja), klient pošlje zahtevo za klic orodja strežniku, s podanim imenom orodja in parametri.

- **Izvajanje strežnika**  
  Strežnik prejme zahtevo za vir ali orodje, izvede potrebne operacije (kot so zagon funkcije, poizvedba v bazi ali pridobitev datoteke) in vrne rezultate klientu v strukturirani obliki.

- **Generiranje odgovora**  
  Klient integrira odgovore strežnika (podatki vira, izhodi orodij itd.) v tekočo interakcijo z modelom. Model uporabi te informacije za ustvarjanje celovitega in kontekstualno ustreznega odgovora.

- **Predstavitev rezultata**  
  Host prejme končni izhod od klienta in ga prikaže uporabniku, pogosto vključujoč tako besedilo, ki ga je ustvaril model, kot tudi rezultate izvajanja orodij ali iskanja po virih.

Ta potek omogoča MCP podporo naprednim, interaktivnim in kontekstualno zavednim AI aplikacijam z nemoteno povezavo modelov z zunanjimi orodji in podatkovnimi viri.

## Podrobnosti protokola

MCP (Model Context Protocol) temelji na [JSON-RPC 2.0](https://www.jsonrpc.org/), ki zagotavlja standardiziran, jezikovno neodvisen format sporočil za komunikacijo med hosti, klienti in strežniki. Ta osnova omogoča zanesljive, strukturirane in razširljive interakcije na različnih platformah in programskih jezikih.

### Ključne funkcije protokola

MCP razširja JSON-RPC 2.0 z dodatnimi konvencijami za klic orodij, dostop do virov in upravljanje pozivov. Podpira več transportnih slojev (STDIO, WebSocket, SSE) ter omogoča varno, razširljivo in jezikovno neodvisno komunikacijo med komponentami.

#### 🧢 Osnovni protokol

- **JSON-RPC format sporočil**: Vse zahteve in odgovori uporabljajo specifikacijo JSON-RPC 2.0, kar zagotavlja dosledno strukturo za klice metod, parametre, rezultate in obravnavo napak.
- **Stanje povezav**: MCP seje ohranjajo stanje skozi več zahtev, podpirajo tekoče pogovore, akumulacijo konteksta in upravljanje virov.
- **Pogajanje zmogljivosti**: Med vzpostavitvijo povezave si klient in strežnik izmenjata informacije o podprtih funkcijah, verzijah protokola, razpoložljivih orodjih in virih. To zagotavlja, da obe strani razumeta zmogljivosti druga druge in se lahko prilagodita.

#### ➕ Dodatna orodja

Spodaj so nekatera dodatna orodja in razširitve protokola, ki jih MCP nudi za izboljšanje izkušenj razvijalcev in omogočanje naprednih scenarijev:

- **Konfiguracijske možnosti**: MCP omogoča dinamično konfiguracijo parametrov seje, kot so dovoljenja za orodja, dostop do virov in nastavitve modela, prilagojene vsaki interakciji.
- **Sledenje napredku**: Dolgotrajne operacije lahko poročajo o napredku, kar omogoča odzivne uporabniške vmesnike in boljšo uporabniško izkušnjo pri kompleksnih nalogah.
- **Preklic zahtev**: Klienti lahko prekličejo v teku zahtevke, kar uporabnikom omogoča prekinitev operacij, ki niso več potrebne ali trajajo predolgo.
- **Poročanje napak**: Standardizirana sporočila o napakah in kode pomagajo diagnosticirati težave, obravnavati napake elegantno in nuditi uporabne povratne informacije uporabnikom in razvijalcem.
- **Dnevnik**: Tako klienti kot strežniki lahko oddajajo strukturirane dnevnike za revizijo, odpravljanje napak in spremljanje interakcij protokola.

Z izkoriščanjem teh funkcij protokola MCP zagotavlja robustno, varno in prilagodljivo komunikacijo med jezikovnimi modeli ter zunanjimi orodji ali podatkovnimi viri.

### 🔐 Varnostni vidiki

Implementacije MCP bi morale upoštevati več ključnih varnostnih načel, da zagotovijo varne in zaupanja vredne interakcije:

- **Uporabniški pristanek in nadzor**: Uporabniki morajo dati izrecno privolitev, preden se dostopajo podatki ali izvajajo operacije. Morajo imeti jasen nadzor nad tem, kateri podatki se delijo in katere akcije so odobrene, podprto z intuitivnimi uporabniškimi vmesniki za pregledovanje in odobritev aktivnosti.

- **Zasebnost podatkov**: Uporabniški podatki naj bodo razkriti le z izrecnim pristankom in zaščiteni z ustreznimi nadzori dostopa. Implementacije MCP morajo preprečevati nepooblaščen prenos podatkov in zagotavljati varstvo zasebnosti skozi vse interakcije.

- **Varnost orodij**: Pred klicem kateregakoli orodja je potreben izrecen uporabniški pristanek. Uporabniki morajo imeti jasno razumevanje funkcionalnosti vsakega orodja, hkrati pa morajo biti vzpostavljene robustne varnostne meje, da se prepreči nenamerno ali nevarno izvajanje orodij.

Sledenje tem načelom zagotavlja, da MCP ohranja zaupanje uporabnikov, zasebnost in varnost v vseh interakcijah protokola.

## Primeri kode: Ključne komponente

Spodaj so primeri kode v več priljubljenih programskih jezikih, ki prikazujejo, kako implementirati ključne MCP strežniške komponente in orodja.

### .NET primer: Ustvarjanje preprostega MCP strežnika z orodji

Tukaj je praktičen primer kode v .NET, ki prikazuje, kako implementirati preprost MCP strežnik s po meri izdelanimi orodji. Primer prikazuje, kako definirati in registrirati orodja, obdelovati zahteve ter povezati strežnik z Model Context Protocolom.

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

Ta primer prikazuje enak MCP strežnik in registracijo orodij kot zgornji .NET primer, vendar implementiran v Javi.

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

V tem primeru pokažemo, kako zgraditi MCP strežnik v Pythonu. Prav tako so prikazane dve različni poti za ustvarjanje orodij.

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

Ta primer prikazuje ustvarjanje MCP strežnika v JavaScriptu in registracijo dveh orodij, povezanih z vremensko napovedjo.

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

Ta JavaScript primer prikazuje, kako ustvariti MCP klienta, ki se poveže na strežnik, pošlje poziv in obdela odgovor, vključno z vsemi klici orodij, ki so bili izvedeni.



**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.