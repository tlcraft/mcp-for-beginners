<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T07:04:27+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hr"
}
-->
# 📖 MCP Osnovni koncepti: Ovladavanje Model Context Protocolom za AI integraciju

Model Context Protocol (MCP) je moćan, standardiziran okvir koji optimizira komunikaciju između velikih jezičnih modela (LLM) i vanjskih alata, aplikacija i izvora podataka. Ovaj SEO-optimiziran vodič će vas provesti kroz osnovne koncepte MCP-a, osiguravajući da razumijete njegovu klijent-server arhitekturu, ključne komponente, mehaniku komunikacije i najbolje prakse implementacije.

## Pregled

Ova lekcija istražuje temeljnu arhitekturu i komponente koje čine ekosustav Model Context Protocol (MCP). Naučit ćete o klijent-server arhitekturi, ključnim komponentama i komunikacijskim mehanizmima koji pokreću MCP interakcije.

## 👩‍🎓 Ključni ciljevi učenja

Do kraja ove lekcije, vi ćete:

- Razumjeti MCP klijent-server arhitekturu.
- Identificirati uloge i odgovornosti domaćina, klijenata i servera.
- Analizirati osnovne značajke koje MCP čine fleksibilnim slojem integracije.
- Naučiti kako informacije teku unutar MCP ekosustava.
- Steći praktične uvide kroz primjere koda u .NET, Java, Python i JavaScript.

## 🔎 MCP Arhitektura: Dublji pogled

MCP ekosustav je izgrađen na klijent-server modelu. Ova modularna struktura omogućava AI aplikacijama da učinkovito komuniciraju s alatima, bazama podataka, API-ima i kontekstualnim resursima. Razdvojimo ovu arhitekturu na njezine osnovne komponente.

### 1. Domaćini

U Model Context Protocolu (MCP), domaćini igraju ključnu ulogu kao primarno sučelje putem kojeg korisnici komuniciraju s protokolom. Domaćini su aplikacije ili okruženja koja započinju veze s MCP serverima kako bi pristupili podacima, alatima i upitima. Primjeri domaćina uključuju integrirana razvojna okruženja (IDE) poput Visual Studio Code, AI alate poput Claude Desktop ili prilagođene agente dizajnirane za specifične zadatke.

**Domaćini** su LLM aplikacije koje započinju veze. Oni:

- Izvršavaju ili komuniciraju s AI modelima za generiranje odgovora.
- Započinju veze s MCP serverima.
- Upravljaju tokom razgovora i korisničkim sučeljem.
- Kontroliraju dozvole i sigurnosna ograničenja.
- Rukovode korisničkim pristankom za dijeljenje podataka i izvršavanje alata.

### 2. Klijenti

Klijenti su bitne komponente koje olakšavaju interakciju između domaćina i MCP servera. Klijenti djeluju kao posrednici, omogućavajući domaćinima pristup i korištenje funkcionalnosti koje pružaju MCP serveri. Oni igraju ključnu ulogu u osiguravanju glatke komunikacije i učinkovitog razmjenjivanja podataka unutar MCP arhitekture.

**Klijenti** su konektori unutar aplikacije domaćina. Oni:

- Šalju zahtjeve serverima s upitima/instrukcijama.
- Pregovaraju o mogućnostima sa serverima.
- Upravljaju zahtjevima za izvršavanje alata iz modela.
- Procesuiraju i prikazuju odgovore korisnicima.

### 3. Serveri

Serveri su odgovorni za rukovanje zahtjevima od MCP klijenata i pružanje odgovarajućih odgovora. Upravljaju raznim operacijama kao što su dohvaćanje podataka, izvršavanje alata i generiranje upita. Serveri osiguravaju da komunikacija između klijenata i domaćina bude učinkovita i pouzdana, održavajući integritet procesa interakcije.

**Serveri** su usluge koje pružaju kontekst i mogućnosti. Oni:

- Registriraju dostupne značajke (resurse, upite, alate)
- Primaju i izvršavaju pozive alata od klijenta
- Pružaju kontekstualne informacije za poboljšanje odgovora modela
- Vraćaju rezultate natrag klijentu
- Održavaju stanje kroz interakcije kada je potrebno

Servere može razviti bilo tko kako bi proširio sposobnosti modela specijaliziranim funkcionalnostima.

### 4. Značajke servera

Serveri u Model Context Protocolu (MCP) pružaju temeljne gradivne blokove koji omogućuju bogate interakcije između klijenata, domaćina i jezičnih modela. Te značajke su dizajnirane da poboljšaju sposobnosti MCP-a nudeći strukturirani kontekst, alate i upite.

MCP serveri mogu ponuditi bilo koju od sljedećih značajki:

#### 📑 Resursi

Resursi u Model Context Protocolu (MCP) obuhvaćaju razne vrste konteksta i podataka koje korisnici ili AI modeli mogu koristiti. To uključuje:

- **Kontekstualni podaci**: Informacije i kontekst koje korisnici ili AI modeli mogu koristiti za donošenje odluka i izvršavanje zadataka.
- **Baze znanja i repozitoriji dokumenata**: Zbirke strukturiranih i nestrukturiranih podataka, kao što su članci, priručnici i istraživački radovi, koji pružaju vrijedne uvide i informacije.
- **Lokalne datoteke i baze podataka**: Podaci pohranjeni lokalno na uređajima ili unutar baza podataka, dostupni za obradu i analizu.
- **API-ji i web usluge**: Vanjska sučelja i usluge koje nude dodatne podatke i funkcionalnosti, omogućujući integraciju s raznim online resursima i alatima.

Primjer resursa može biti shema baze podataka ili datoteka koja se može pristupiti na sljedeći način:

```text
file://log.txt
database://schema
```

### 🤖 Upiti

Upiti u Model Context Protocolu (MCP) uključuju razne unaprijed definirane predloške i obrasce interakcije dizajnirane za optimiziranje korisničkih tijekova rada i poboljšanje komunikacije. To uključuje:

- **Predloške poruka i tijekova rada**: Unaprijed strukturirane poruke i procesi koji vode korisnike kroz specifične zadatke i interakcije.
- **Unaprijed definirani obrasci interakcije**: Standardizirani slijedovi akcija i odgovora koji olakšavaju dosljednu i učinkovitu komunikaciju.
- **Specijalizirani predlošci razgovora**: Prilagodljivi predlošci prilagođeni za specifične vrste razgovora, osiguravajući relevantne i kontekstualno prikladne interakcije.

Predložak upita može izgledati ovako:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Alati

Alati u Model Context Protocolu (MCP) su funkcije koje AI model može izvršiti za obavljanje specifičnih zadataka. Ti su alati dizajnirani da poboljšaju sposobnosti AI modela pružanjem strukturiranih i pouzdanih operacija. Ključni aspekti uključuju:

- **Funkcije za izvršenje AI modela**: Alati su izvršne funkcije koje AI model može pozvati za obavljanje raznih zadataka.
- **Jedinstveni naziv i opis**: Svaki alat ima jedinstveno ime i detaljan opis koji objašnjava njegovu svrhu i funkcionalnost.
- **Parametri i izlazi**: Alati prihvaćaju specifične parametre i vraćaju strukturirane izlaze, osiguravajući dosljedne i predvidljive rezultate.
- **Diskretne funkcije**: Alati obavljaju diskretne funkcije kao što su pretraživanje weba, izračuni i upiti baze podataka.

Primjer alata može izgledati ovako:

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

## Značajke klijenata

U Model Context Protocolu (MCP), klijenti nude nekoliko ključnih značajki serverima, poboljšavajući ukupnu funkcionalnost i interakciju unutar protokola. Jedna od značajnih značajki je uzorkovanje.

### 👉 Uzorkovanje

- **Serverom inicirana agentna ponašanja**: Klijenti omogućuju serverima da autonomno pokreću specifične akcije ili ponašanja, poboljšavajući dinamičke sposobnosti sustava.
- **Rekurzivne LLM interakcije**: Ova značajka omogućuje rekurzivne interakcije s velikim jezičnim modelima (LLM), omogućujući složeniju i iterativnu obradu zadataka.
- **Zahtjev za dodatnim modelskim završetcima**: Serveri mogu zatražiti dodatne završetke od modela, osiguravajući da su odgovori temeljiti i kontekstualno relevantni.

## Tok informacija u MCP-u

Model Context Protocol (MCP) definira strukturirani tok informacija između domaćina, klijenata, servera i modela. Razumijevanje ovog toka pomaže razjasniti kako se korisnički zahtjevi obrađuju i kako se vanjski alati i podaci integriraju u odgovore modela.

- **Domaćin inicira vezu**  
  Aplikacija domaćina (kao što je IDE ili sučelje za chat) uspostavlja vezu s MCP serverom, obično putem STDIO, WebSocket ili drugog podržanog transporta.

- **Pregovaranje o sposobnostima**  
  Klijent (ugrađen u domaćina) i server razmjenjuju informacije o svojim podržanim značajkama, alatima, resursima i verzijama protokola. Ovo osigurava da obje strane razumiju koje su sposobnosti dostupne za sesiju.

- **Korisnički zahtjev**  
  Korisnik komunicira s domaćinom (npr. unosi upit ili naredbu). Domaćin prikuplja ovaj unos i prosljeđuje ga klijentu na obradu.

- **Korištenje resursa ili alata**  
  - Klijent može zatražiti dodatni kontekst ili resurse od servera (kao što su datoteke, unosi u bazu podataka ili članci iz baze znanja) kako bi obogatio razumijevanje modela.
  - Ako model utvrdi da je potreban alat (npr. za dohvaćanje podataka, izvođenje izračuna ili pozivanje API-ja), klijent šalje zahtjev za pozivanje alata serveru, specificirajući naziv alata i parametre.

- **Izvršenje servera**  
  Server prima zahtjev za resursom ili alatom, izvršava potrebne operacije (kao što je pokretanje funkcije, upit baze podataka ili dohvaćanje datoteke) i vraća rezultate klijentu u strukturiranom formatu.

- **Generiranje odgovora**  
  Klijent integrira odgovore servera (podatke o resursima, izlaze alata itd.) u tekuću interakciju modela. Model koristi ove informacije za generiranje sveobuhvatnog i kontekstualno relevantnog odgovora.

- **Prikaz rezultata**  
  Domaćin prima konačni izlaz od klijenta i predstavlja ga korisniku, često uključujući i generirani tekst modela i sve rezultate iz izvršenja alata ili pretraživanja resursa.

Ovaj tok omogućuje MCP-u podršku naprednim, interaktivnim i kontekstualno svjesnim AI aplikacijama spajanjem modela s vanjskim alatima i izvorima podataka.

## Detalji protokola

MCP (Model Context Protocol) je izgrađen na [JSON-RPC 2.0](https://www.jsonrpc.org/), pružajući standardiziran, jezično neovisan format poruka za komunikaciju između domaćina, klijenata i servera. Ovaj temelj omogućuje pouzdane, strukturirane i proširive interakcije na različitim platformama i programskim jezicima.

### Ključne značajke protokola

MCP proširuje JSON-RPC 2.0 dodatnim konvencijama za pozivanje alata, pristup resursima i upravljanje upitima. Podržava više slojeva transporta (STDIO, WebSocket, SSE) i omogućuje sigurnu, proširivu i jezično neovisnu komunikaciju između komponenti.

#### 🧢 Osnovni protokol

- **JSON-RPC format poruka**: Svi zahtjevi i odgovori koriste specifikaciju JSON-RPC 2.0, osiguravajući dosljednu strukturu za pozive metoda, parametre, rezultate i rukovanje greškama.
- **Stanje veza**: MCP sesije održavaju stanje kroz više zahtjeva, podržavajući tekuće razgovore, akumulaciju konteksta i upravljanje resursima.
- **Pregovaranje o sposobnostima**: Tijekom postavljanja veze, klijenti i serveri razmjenjuju informacije o podržanim značajkama, verzijama protokola, dostupnim alatima i resursima. Ovo osigurava da obje strane razumiju sposobnosti jedne druge i mogu se prilagoditi.

#### ➕ Dodatne pogodnosti

U nastavku su navedene neke dodatne pogodnosti i proširenja protokola koje MCP pruža za poboljšanje iskustva razvijatelja i omogućavanje naprednih scenarija:

- **Opcije konfiguracije**: MCP omogućuje dinamičku konfiguraciju parametara sesije, kao što su dozvole za alate, pristup resursima i postavke modela, prilagođene svakoj interakciji.
- **Praćenje napretka**: Operacije koje traju dulje mogu izvještavati o ažuriranjima napretka, omogućujući odgovorna korisnička sučelja i bolje korisničko iskustvo tijekom složenih zadataka.
- **Otkazivanje zahtjeva**: Klijenti mogu otkazati zahtjeve koji su u tijeku, omogućujući korisnicima da prekinu operacije koje više nisu potrebne ili predugo traju.
- **Izvještavanje o greškama**: Standardizirane poruke o greškama i kodovi pomažu u dijagnosticiranju problema, rukovanju neuspjesima i pružanju korisnih povratnih informacija korisnicima i razvijateljima.
- **Zapisivanje**: I klijenti i serveri mogu emitirati strukturirane zapise za reviziju, otklanjanje grešaka i praćenje interakcija protokola.

Korištenjem ovih značajki protokola, MCP osigurava robusnu, sigurnu i fleksibilnu komunikaciju između jezičnih modela i vanjskih alata ili izvora podataka.

### 🔐 Sigurnosni aspekti

MCP implementacije trebale bi se pridržavati nekoliko ključnih sigurnosnih principa kako bi se osigurale sigurne i pouzdane interakcije:

- **Korisnički pristanak i kontrola**: Korisnici moraju dati eksplicitan pristanak prije nego što se pristupi bilo kojim podacima ili se izvrše operacije. Trebali bi imati jasnu kontrolu nad time koji se podaci dijele i koje su radnje autorizirane, uz podršku intuitivnih korisničkih sučelja za pregled i odobravanje aktivnosti.

- **Privatnost podataka**: Korisnički podaci trebaju biti izloženi samo uz eksplicitan pristanak i moraju biti zaštićeni odgovarajućim kontrolama pristupa. MCP implementacije moraju štititi od neovlaštenog prijenosa podataka i osigurati da privatnost bude održana tijekom svih interakcija.

- **Sigurnost alata**: Prije pozivanja bilo kojeg alata, potreban je eksplicitan korisnički pristanak. Korisnici trebaju imati jasno razumijevanje funkcionalnosti svakog alata, a moraju se provoditi robusne sigurnosne granice kako bi se spriječilo nenamjerno ili nesigurno izvršenje alata.

Pridržavajući se ovih principa, MCP osigurava da se povjerenje korisnika, privatnost i sigurnost održavaju kroz sve interakcije protokola.

## Primjeri koda: Ključne komponente

U nastavku su primjeri koda u nekoliko popularnih programskih jezika koji ilustriraju kako implementirati ključne MCP server komponente i alate.

### .NET Primjer: Kreiranje jednostavnog MCP servera s alatima

Evo praktičnog .NET primjera koda koji pokazuje kako implementirati jednostavan MCP server s prilagođenim alatima. Ovaj primjer prikazuje kako definirati i registrirati alate, rukovati zahtjevima i povezati server koristeći Model Context Protocol.

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

### Java Primjer: Komponente MCP servera

Ovaj primjer pokazuje isti MCP server i registraciju alata kao u gore navedenom .NET primjeru, ali implementiran u Javi.

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

### Python Primjer: Izgradnja MCP servera

U ovom primjeru pokazujemo kako izgraditi MCP server u Pythonu. Također su prikazana dva različita načina za kreiranje alata.

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

### JavaScript Primjer: Kreiranje MCP servera

Ovaj primjer pokazuje kreiranje MCP servera u JavaScriptu i prikazuje kako registrirati dva alata povezana s vremenom.

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

Ovaj JavaScript primjer pokazuje kako stvoriti MCP klijent koji se povezuje na server, šalje upit i obrađuje odgovor uključujući sve pozive alata koji su izvršeni.

## Sigurn

**Izjava o odricanju odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako se trudimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati mjerodavnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne odgovaramo za nesporazume ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.