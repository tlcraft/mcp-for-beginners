<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T22:38:56+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sr"
}
-->
# 📖 MCP Osnovni Koncepti: Savladavanje Model Context Protocol-a za AI Integraciju

Model Context Protocol (MCP) je moćan, standardizovani okvir koji optimizuje komunikaciju između velikih jezičkih modela (LLM) i eksternih alata, aplikacija i izvora podataka. Ovaj SEO-optimizovani vodič vodiće vas kroz osnovne koncepte MCP-a, obezbeđujući da razumete njegovu klijent-server arhitekturu, ključne komponente, mehanizme komunikacije i najbolje prakse implementacije.

## Pregled

Ova lekcija istražuje osnovnu arhitekturu i komponente koje čine MCP ekosistem. Naučićete o klijent-server arhitekturi, ključnim komponentama i mehanizmima komunikacije koji pokreću MCP interakcije.

## 👩‍🎓 Ključni Ciljevi Učenja

Na kraju ove lekcije, bićete u stanju da:

- Razumete MCP klijent-server arhitekturu.
- Identifikujete uloge i odgovornosti Hostova, Klijenata i Servera.
- Analizirate osnovne karakteristike koje čine MCP fleksibilnim slojem za integraciju.
- Naučite kako informacije teku unutar MCP ekosistema.
- Steknete praktične uvide kroz primere koda u .NET, Java, Python i JavaScript.

## 🔎 MCP Arhitektura: Detaljniji Pogled

MCP ekosistem je izgrađen na modelu klijent-server. Ova modularna struktura omogućava AI aplikacijama efikasnu interakciju sa alatima, bazama podataka, API-jima i kontekstualnim resursima. Hajde da razložimo ovu arhitekturu na njene osnovne komponente.

### 1. Hostovi

U Model Context Protocol-u (MCP), Hostovi igraju ključnu ulogu kao primarni interfejs preko kojeg korisnici komuniciraju sa protokolom. Hostovi su aplikacije ili okruženja koja uspostavljaju veze sa MCP serverima radi pristupa podacima, alatima i promptovima. Primeri Hostova uključuju integrisana razvojna okruženja (IDE) poput Visual Studio Code-a, AI alate kao što je Claude Desktop, ili prilagođene agente dizajnirane za specifične zadatke.

**Hostovi** su LLM aplikacije koje pokreću veze. Oni:

- Izvršavaju ili komuniciraju sa AI modelima da generišu odgovore.
- Iniciraju veze sa MCP serverima.
- Upravljaju tokom konverzacije i korisničkim interfejsom.
- Kontrolišu dozvole i bezbednosna ograničenja.
- Rukovode korisničkim saglasnostima za deljenje podataka i izvršavanje alata.

### 2. Klijenti

Klijenti su ključne komponente koje olakšavaju interakciju između Hostova i MCP servera. Klijenti deluju kao posrednici, omogućavajući Hostovima pristup i korišćenje funkcionalnosti koje pružaju MCP serveri. Oni igraju važnu ulogu u obezbeđivanju glatke komunikacije i efikasne razmene podataka unutar MCP arhitekture.

**Klijenti** su konektori unutar host aplikacije. Oni:

- Šalju zahteve serverima sa promptovima/instrukcijama.
- Pregovaraju o mogućnostima sa serverima.
- Upravljaju zahtevima za izvršavanje alata od strane modela.
- Procesuiraju i prikazuju odgovore korisnicima.

### 3. Serveri

Serveri su odgovorni za obradu zahteva MCP klijenata i pružanje odgovarajućih odgovora. Oni upravljaju različitim operacijama kao što su preuzimanje podataka, izvršavanje alata i generisanje promptova. Serveri osiguravaju da je komunikacija između klijenata i Hostova efikasna i pouzdana, održavajući integritet procesa interakcije.

**Serveri** su servisi koji pružaju kontekst i mogućnosti. Oni:

- Registruju dostupne funkcije (resurse, promptove, alate).
- Primaju i izvršavaju pozive alata od klijenta.
- Pružaju kontekstualne informacije za poboljšanje odgovora modela.
- Vraćaju rezultate nazad klijentu.
- Održavaju stanje tokom interakcija kada je potrebno.

Servere može razviti bilo ko, kako bi proširio mogućnosti modela specijalizovanim funkcionalnostima.

### 4. Funkcije Servera

Serveri u Model Context Protocol-u (MCP) pružaju osnovne gradivne blokove koji omogućavaju bogate interakcije između klijenata, hostova i jezičkih modela. Ove funkcije su dizajnirane da unaprede mogućnosti MCP-a nudeći strukturirani kontekst, alate i promptove.

MCP serveri mogu nuditi bilo koju od sledećih funkcija:

#### 📑 Resursi

Resursi u Model Context Protocol-u (MCP) obuhvataju različite vrste konteksta i podataka koje korisnici ili AI modeli mogu koristiti. To uključuje:

- **Kontekstualni Podaci**: Informacije i kontekst koje korisnici ili AI modeli mogu iskoristiti za donošenje odluka i izvršavanje zadataka.
- **Baze Znanja i Repozitorijumi Dokumenata**: Kolekcije strukturiranih i nestrukturiranih podataka, poput članaka, priručnika i istraživačkih radova, koje pružaju vredne uvide i informacije.
- **Lokalne Datoteke i Baze Podataka**: Podaci koji se čuvaju lokalno na uređajima ili unutar baza podataka, dostupni za obradu i analizu.
- **API-ji i Veb Servisi**: Eksterni interfejsi i servisi koji nude dodatne podatke i funkcionalnosti, omogućavajući integraciju sa različitim onlajn resursima i alatima.

Primer resursa može biti šema baze podataka ili datoteka kojoj se može pristupiti na sledeći način:

```text
file://log.txt
database://schema
```

### 🤖 Promptovi

Promptovi u Model Context Protocol-u (MCP) uključuju različite unapred definisane šablone i obrasce interakcije dizajnirane da pojednostave korisničke tokove rada i unaprede komunikaciju. To uključuje:

- **Šablonizovane Poruke i Tokovi Rada**: Unapred strukturisane poruke i procesi koji vode korisnike kroz specifične zadatke i interakcije.
- **Unapred Definisani Obrasci Interakcije**: Standardizovani nizovi akcija i odgovora koji olakšavaju doslednu i efikasnu komunikaciju.
- **Specijalizovani Šabloni Razgovora**: Prilagodljivi šabloni namenjeni specifičnim vrstama razgovora, obezbeđujući relevantne i kontekstualno prikladne interakcije.

Primer šablona prompta može izgledati ovako:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Alati

Alati u Model Context Protocol-u (MCP) su funkcije koje AI model može izvršavati da bi obavio određene zadatke. Ovi alati su dizajnirani da unaprede mogućnosti AI modela pružajući strukturisane i pouzdane operacije. Ključni aspekti uključuju:

- **Funkcije koje AI model može izvršavati**: Alati su izvršne funkcije koje AI model može pozvati da obavi različite zadatke.
- **Jedinstveno Ime i Opis**: Svaki alat ima jedinstveno ime i detaljan opis koji objašnjava njegovu svrhu i funkcionalnost.
- **Parametri i Izlazi**: Alati prihvataju specifične parametre i vraćaju strukturisane rezultate, obezbeđujući dosledne i predvidive ishode.
- **Diskretne Funkcije**: Alati obavljaju diskretne funkcije poput pretrage na internetu, proračuna i upita u bazu podataka.

Primer alata može izgledati ovako:

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

## Funkcije Klijenata

U Model Context Protocol-u (MCP), klijenti nude nekoliko ključnih funkcija serverima, poboljšavajući ukupnu funkcionalnost i interakciju unutar protokola. Jedna od značajnih funkcija je Sampling.

### 👉 Sampling

- **Agentna Ponašanja Inicirana od Servera**: Klijenti omogućavaju serverima da autonomno pokreću specifične akcije ili ponašanja, unapređujući dinamičke mogućnosti sistema.
- **Rekurzivne LLM Interakcije**: Ova funkcija omogućava rekurzivne interakcije sa velikim jezičkim modelima (LLM), dozvoljavajući složeniju i iterativnu obradu zadataka.
- **Zahtevanje Dodatnih Završetaka Modela**: Serveri mogu zahtevati dodatne završetke od modela, osiguravajući da su odgovori detaljni i kontekstualno relevantni.

## Tok Informacija u MCP-u

Model Context Protocol (MCP) definiše strukturiran tok informacija između hostova, klijenata, servera i modela. Razumevanje ovog toka pomaže da se razjasni kako se korisnički zahtevi obrađuju i kako se eksterni alati i podaci integrišu u odgovore modela.

- **Host Inicira Vezu**  
  Host aplikacija (poput IDE-a ili interfejsa za chat) uspostavlja vezu sa MCP serverom, obično preko STDIO, WebSocket-a ili drugog podržanog transporta.

- **Pregovaranje o Mogućnostima**  
  Klijent (ugrađen u host) i server razmenjuju informacije o podržanim funkcijama, alatima, resursima i verzijama protokola. Ovo osigurava da obe strane razumeju koje mogućnosti su dostupne za sesiju.

- **Korisnički Zahtev**  
  Korisnik komunicira sa hostom (npr. unosi prompt ili komandu). Host prikuplja ovaj unos i prosleđuje ga klijentu na obradu.

- **Korišćenje Resursa ili Alata**  
  - Klijent može zahtevati dodatni kontekst ili resurse od servera (kao što su fajlovi, unosi u bazu podataka ili članci iz baze znanja) da obogati razumevanje modela.
  - Ako model zaključi da je potreban alat (npr. da preuzme podatke, izvrši proračun ili pozove API), klijent šalje zahtev za poziv alata serveru, navodeći ime alata i parametre.

- **Izvršenje na Serveru**  
  Server prima zahtev za resurs ili alat, izvršava potrebne operacije (kao što su pokretanje funkcije, upit u bazu podataka ili preuzimanje fajla) i vraća rezultate klijentu u strukturiranom formatu.

- **Generisanje Odgovora**  
  Klijent integriše odgovore servera (podatke resursa, izlaze alata itd.) u tekuću interakciju modela. Model koristi ove informacije da generiše sveobuhvatan i kontekstualno relevantan odgovor.

- **Prikaz Rezultata**  
  Host prima konačni izlaz od klijenta i prikazuje ga korisniku, često uključujući i generisani tekst modela kao i rezultate izvršenja alata ili pretrage resursa.

Ovaj tok omogućava MCP-u da podrži napredne, interaktivne i kontekstualno svesne AI aplikacije besprekornim povezivanjem modela sa eksternim alatima i izvorima podataka.

## Detalji Protokola

MCP (Model Context Protocol) je izgrađen na vrhu [JSON-RPC 2.0](https://www.jsonrpc.org/), pružajući standardizovani, jezički nezavisni format poruka za komunikaciju između hostova, klijenata i servera. Ova osnova omogućava pouzdane, strukturirane i proširive interakcije na različitim platformama i programskim jezicima.

### Ključne Karakteristike Protokola

MCP proširuje JSON-RPC 2.0 dodatnim konvencijama za pozivanje alata, pristup resursima i upravljanje promptovima. Podržava više transportnih slojeva (STDIO, WebSocket, SSE) i omogućava sigurnu, proširivu i jezički nezavisnu komunikaciju između komponenti.

#### 🧢 Osnovni Protokol

- **JSON-RPC Format Poruka**: Svi zahtevi i odgovori koriste JSON-RPC 2.0 specifikaciju, obezbeđujući doslednu strukturu za pozive metoda, parametre, rezultate i obradu grešaka.
- **Veze sa Očuvanjem Stanja**: MCP sesije održavaju stanje kroz više zahteva, podržavajući tekuće konverzacije, akumulaciju konteksta i upravljanje resursima.
- **Pregovaranje o Mogućnostima**: Tokom uspostavljanja veze, klijenti i serveri razmenjuju informacije o podržanim funkcijama, verzijama protokola, dostupnim alatima i resursima. Ovo osigurava da obe strane razumeju mogućnosti jedna druge i mogu se prilagoditi.

#### ➕ Dodatni Alati

Ispod su neki dodatni alati i proširenja protokola koje MCP pruža za poboljšanje iskustva programera i omogućavanje naprednih scenarija:

- **Opcije Konfiguracije**: MCP dozvoljava dinamičku konfiguraciju parametara sesije, kao što su dozvole za alate, pristup resursima i podešavanja modela, prilagođene svakoj interakciji.
- **Praćenje Napretka**: Operacije koje traju duže mogu izveštavati o napretku, omogućavajući responzivne korisničke interfejse i bolje korisničko iskustvo tokom složenih zadataka.
- **Otkaživanje Zahteva**: Klijenti mogu otkazati zahteve u toku, dozvoljavajući korisnicima da prekinu operacije koje više nisu potrebne ili predugo traju.
- **Izveštavanje o Greškama**: Standardizovane poruke o greškama i kodovi pomažu u dijagnostici problema, elegantnom rukovanju neuspesima i pružanju korisnih povratnih informacija korisnicima i programerima.
- **Logovanje**: I klijenti i serveri mogu emitovati strukturisane logove za reviziju, debagovanje i praćenje interakcija protokola.

Korišćenjem ovih karakteristika, MCP osigurava robusnu, sigurnu i fleksibilnu komunikaciju između jezičkih modela i eksternih alata ili izvora podataka.

### 🔐 Bezbednosne Preporuke

Implementacije MCP-a treba da se pridržavaju nekoliko ključnih bezbednosnih principa kako bi osigurale sigurne i pouzdane interakcije:

- **Korisnička Saglasnost i Kontrola**: Korisnici moraju dati izričitu saglasnost pre nego što bilo koji podaci budu pristupljeni ili operacije izvršene. Trebalo bi da imaju jasan uvid u to koji se podaci dele i koje su akcije odobrene, uz intuitivne korisničke interfejse za pregled i odobravanje aktivnosti.

- **Privatnost Podataka**: Korisnički podaci treba da budu dostupni samo uz izričitu saglasnost i moraju biti zaštićeni odgovarajućim kontrolama pristupa. Implementacije MCP-a moraju sprečiti neovlašćeni prenos podataka i osigurati da privatnost bude očuvana tokom svih interakcija.

- **Sigurnost Alata**: Pre pozivanja bilo kog alata, potrebna je izričita korisnička saglasnost. Korisnici treba jasno da razumeju funkcionalnost svakog alata, a robustne sigurnosne granice moraju biti sprovedene kako bi se sprečilo neželjeno ili nesigurno izvršavanje alata.

Pridržavajući se ovih principa, MCP osigurava poverenje korisnika, privatnost i bezbednost tokom svih interakcija u okviru protokola.

## Primeri Koda: Ključne Komponente

Ispod su primeri koda u nekoliko popularnih programskih jezika koji ilustruju kako implementirati ključne MCP serverske komponente i alate.

### .NET Primer: Kreiranje Jednostavnog MCP Servera sa Alatima

Praktičan primer u .NET-u koji pokazuje kako implementirati jednostavan MCP server sa prilagođenim alatima. Ovaj primer demonstrira definisanje i registraciju alata, obradu zahteva i povezivanje servera koristeći Model Context Protocol.

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

### Java Primer: MCP Serverske Komponente

Ovaj primer prikazuje isti MCP server i registraciju alata kao .NET primer gore, ali implementiran u Javi.

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

### Python Primer: Izgradnja MCP Servera

U ovom primeru pokazujemo kako izgraditi MCP server u Pythonu. Takođe su prikazana dva različita načina kreiranja alata.

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

### JavaScript Primer: Kreiranje MCP Servera

Ovaj primer prikazuje kreiranje MCP servera u JavaScript-u i kako registrovati dva alata vezana za vremensku prognozu.

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

Ovaj JavaScript primer pokazuje kako kreirati MCP klijenta koji se povezuje na server, šalje prompt i obrađuje odgovor uključujući i pozive alata koji su izvršeni.

## Bezbednost i Autorizacija

MCP uključuje nekoliko ugrađenih koncepata i mehanizama za upravljanje bezbednošću i autorizacijom kroz ceo protokol:

1. **Kontrola Dozvol

**Ограничење одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако настојимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне тумачења настала употребом овог превода.