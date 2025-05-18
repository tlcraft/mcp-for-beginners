<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:36:45+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sr"
}
-->
# 📖 MCP Osnovni Koncepti: Savladavanje Model Context Protocol za AI Integraciju

Model Context Protocol (MCP) je moćan, standardizovani okvir koji optimizuje komunikaciju između velikih jezičkih modela (LLM) i eksternih alata, aplikacija i izvora podataka. Ovaj SEO-optimizovani vodič će vas provesti kroz osnovne koncepte MCP-a, osiguravajući da razumete njegovu klijent-server arhitekturu, ključne komponente, mehanizme komunikacije i najbolje prakse implementacije.

## Pregled

Ova lekcija istražuje osnovnu arhitekturu i komponente koje čine Model Context Protocol (MCP) ekosistem. Naučićete o klijent-server arhitekturi, ključnim komponentama i mehanizmima komunikacije koji pokreću MCP interakcije.

## 👩‍🎓 Ključni Ciljevi Učenja

Do kraja ove lekcije, bićete u stanju da:

- Razumete MCP klijent-server arhitekturu.
- Identifikujete uloge i odgovornosti Hosts, Clients i Servers.
- Analizirate osnovne karakteristike koje čine MCP fleksibilnim slojem za integraciju.
- Naučite kako informacije teku unutar MCP ekosistema.
- Steknete praktične uvide kroz primere koda u .NET, Java, Python i JavaScript.

## 🔎 MCP Arhitektura: Detaljniji Pogled

MCP ekosistem je izgrađen na klijent-server modelu. Ova modularna struktura omogućava AI aplikacijama efikasnu interakciju sa alatima, bazama podataka, API-jima i kontekstualnim resursima. Hajde da razložimo ovu arhitekturu na njene osnovne komponente.

### 1. Hosts

U Model Context Protocol-u (MCP), Hosts igraju ključnu ulogu kao primarni interfejs kroz koji korisnici komuniciraju sa protokolom. Hosts su aplikacije ili okruženja koja iniciraju konekcije sa MCP serverima kako bi pristupili podacima, alatima i promptovima. Primeri Hosts uključuju integrisana razvojna okruženja (IDE) poput Visual Studio Code, AI alate poput Claude Desktop ili specijalno razvijene agente za određene zadatke.

**Hosts** su LLM aplikacije koje pokreću konekcije. Oni:

- Izvršavaju ili komuniciraju sa AI modelima radi generisanja odgovora.
- Iniciraju konekcije sa MCP serverima.
- Upravljaju tokom razgovora i korisničkim interfejsom.
- Kontrolišu dozvole i sigurnosne restrikcije.
- Rukovode korisničkim pristankom za deljenje podataka i izvršavanje alata.

### 2. Clients

Clients su ključne komponente koje olakšavaju interakciju između Hosts i MCP servera. Clients deluju kao posrednici, omogućavajući Hosts pristup i korišćenje funkcionalnosti koje pružaju MCP serveri. Imaju važnu ulogu u obezbeđivanju glatke komunikacije i efikasne razmene podataka unutar MCP arhitekture.

**Clients** su konektori unutar host aplikacije. Oni:

- Šalju zahteve serverima sa promptovima/instrukcijama.
- Pregovaraju o mogućnostima sa serverima.
- Upravljaju zahtevima za izvršenje alata od modela.
- Procesuiraju i prikazuju odgovore korisnicima.

### 3. Servers

Servers su odgovorni za obradu zahteva MCP klijenata i pružanje odgovarajućih odgovora. Oni upravljaju različitim operacijama kao što su dohvat podataka, izvršavanje alata i generisanje promptova. Servers obezbeđuju da komunikacija između klijenata i Hosts bude efikasna i pouzdana, održavajući integritet procesa interakcije.

**Servers** su servisi koji pružaju kontekst i mogućnosti. Oni:

- Registruju dostupne funkcije (resurse, promptove, alate)
- Primaju i izvršavaju pozive alata od klijenta
- Pružaju kontekstualne informacije za poboljšanje odgovora modela
- Vraćaju rezultate nazad klijentu
- Održavaju stanje tokom interakcija kada je potrebno

Servere može razviti bilo ko ko želi da proširi mogućnosti modela specijalizovanom funkcionalnošću.

### 4. Server Features

Serveri u Model Context Protocol-u (MCP) pružaju osnovne gradivne blokove koji omogućavaju bogate interakcije između klijenata, hostova i jezičkih modela. Ove funkcije su dizajnirane da unaprede mogućnosti MCP-a nudeći strukturirani kontekst, alate i promptove.

MCP serveri mogu nuditi bilo koju od sledećih funkcija:

#### 📑 Resursi

Resursi u Model Context Protocol-u (MCP) obuhvataju različite tipove konteksta i podataka koje korisnici ili AI modeli mogu koristiti. To uključuje:

- **Kontekstualne podatke**: Informacije i kontekst koje korisnici ili AI modeli mogu iskoristiti za donošenje odluka i izvršavanje zadataka.
- **Baze znanja i repozitorijume dokumenata**: Kolekcije strukturiranih i nestrukturiranih podataka, kao što su članci, priručnici i istraživački radovi, koji pružaju vredne uvide i informacije.
- **Lokalne fajlove i baze podataka**: Podatke sačuvane lokalno na uređajima ili unutar baza podataka, dostupne za obradu i analizu.
- **API-je i web servise**: Eksterne interfejse i servise koji nude dodatne podatke i funkcionalnosti, omogućavajući integraciju sa različitim online resursima i alatima.

Primer resursa može biti šema baze podataka ili fajl kojem se pristupa ovako:

```text
file://log.txt
database://schema
```

### 🤖 Promptovi

Promptovi u Model Context Protocol-u (MCP) uključuju različite unapred definisane šablone i obrasce interakcije dizajnirane da pojednostave korisničke tokove rada i unaprede komunikaciju. To uključuje:

- **Šablonske poruke i tokove rada**: Prestrukturirane poruke i procesi koji vode korisnike kroz specifične zadatke i interakcije.
- **Unapred definisani obrasci interakcije**: Standardizovani nizovi akcija i odgovora koji omogućavaju doslednu i efikasnu komunikaciju.
- **Specijalizovani šabloni za razgovore**: Prilagodljivi šabloni namenjeni za specifične tipove razgovora, osiguravajući relevantne i kontekstualno odgovarajuće interakcije.

Šablon prompta može izgledati ovako:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Alati

Alati u Model Context Protocol-u (MCP) su funkcije koje AI model može izvršiti da bi obavio određene zadatke. Ovi alati su dizajnirani da unaprede sposobnosti AI modela pružajući strukturisane i pouzdane operacije. Ključni aspekti uključuju:

- **Funkcije koje AI model može izvršiti**: Alati su izvršne funkcije koje AI model može pozvati za obavljanje različitih zadataka.
- **Jedinstveno ime i opis**: Svaki alat ima jedinstveno ime i detaljan opis koji objašnjava njegovu svrhu i funkcionalnost.
- **Parametre i izlaze**: Alati prihvataju specifične parametre i vraćaju strukturirane izlaze, osiguravajući dosledne i predvidive rezultate.
- **Diskretne funkcije**: Alati obavljaju diskretne funkcije kao što su pretraga na webu, proračuni i upiti baza podataka.

Primer alata može izgledati ovako:

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

## Klijentske Funkcije

U Model Context Protocol-u (MCP), klijenti nude nekoliko ključnih funkcija serverima, poboljšavajući ukupnu funkcionalnost i interakciju unutar protokola. Jedna od značajnih funkcija je Sampling.

### 👉 Sampling

- **Server-inicirane agentne radnje**: Klijenti omogućavaju serverima da autonomno iniciraju specifične akcije ili ponašanja, čime se povećavaju dinamičke mogućnosti sistema.
- **Rekurzivne LLM interakcije**: Ova funkcija omogućava rekurzivne interakcije sa velikim jezičkim modelima (LLM), omogućavajući složeniju i iterativnu obradu zadataka.
- **Zahtev za dodatnim završecima modela**: Serveri mogu tražiti dodatne završetke od modela, osiguravajući da su odgovori detaljni i kontekstualno relevantni.

## Tok Informacija u MCP

Model Context Protocol (MCP) definiše strukturisan tok informacija između hostova, klijenata, servera i modela. Razumevanje ovog toka pomaže da se razjasni kako se korisnički zahtevi obrađuju i kako se eksterni alati i podaci integrišu u odgovore modela.

- **Host inicira konekciju**  
  Host aplikacija (kao što je IDE ili chat interfejs) uspostavlja vezu sa MCP serverom, obično preko STDIO, WebSocket ili nekog drugog podržanog transporta.

- **Pregovaranje o mogućnostima**  
  Klijent (ugrađen u host) i server razmenjuju informacije o podržanim funkcijama, alatima, resursima i verzijama protokola. Ovo osigurava da obe strane razumeju koje mogućnosti su dostupne za sesiju.

- **Korisnički zahtev**  
  Korisnik komunicira sa hostom (npr. unosi prompt ili komandu). Host prikuplja ovaj unos i prosleđuje ga klijentu na obradu.

- **Korišćenje resursa ili alata**  
  - Klijent može zatražiti dodatni kontekst ili resurse od servera (kao što su fajlovi, unosi u bazu podataka ili članci iz baze znanja) da obogati razumevanje modela.
  - Ako model proceni da je potreban alat (npr. za dohvat podataka, izvođenje proračuna ili pozivanje API-ja), klijent šalje zahtev za poziv alata serveru, navodeći ime alata i parametre.

- **Izvršenje na serveru**  
  Server prima zahtev za resurs ili alat, izvršava neophodne operacije (kao što su pokretanje funkcije, upit u bazu podataka ili dohvat fajla) i vraća rezultate klijentu u strukturisanom formatu.

- **Generisanje odgovora**  
  Klijent integriše odgovore servera (podatke o resursima, izlaze alata itd.) u tekuću interakciju sa modelom. Model koristi ove informacije da generiše sveobuhvatan i kontekstualno relevantan odgovor.

- **Prikaz rezultata**  
  Host prima konačni izlaz od klijenta i prikazuje ga korisniku, često uključujući i generisani tekst modela i rezultate izvršenja alata ili pretrage resursa.

Ovaj tok omogućava MCP-u da podrži napredne, interaktivne i kontekstualno svesne AI aplikacije besprekornim povezivanjem modela sa eksternim alatima i izvorima podataka.

## Detalji Protokola

MCP (Model Context Protocol) je izgrađen na vrhu [JSON-RPC 2.0](https://www.jsonrpc.org/), pružajući standardizovani, jezički nezavisan format poruka za komunikaciju između hostova, klijenata i servera. Ova osnova omogućava pouzdane, strukturisane i proširive interakcije na različitim platformama i programskim jezicima.

### Ključne Karakteristike Protokola

MCP proširuje JSON-RPC 2.0 dodatnim konvencijama za pozivanje alata, pristup resursima i upravljanje promptovima. Podržava više transportnih slojeva (STDIO, WebSocket, SSE) i omogućava sigurnu, proširivu i jezički nezavisnu komunikaciju između komponenti.

#### 🧢 Osnovni Protokol

- **JSON-RPC format poruka**: Svi zahtevi i odgovori koriste JSON-RPC 2.0 specifikaciju, obezbeđujući doslednu strukturu za pozive metoda, parametre, rezultate i obradu grešaka.
- **Stanja konekcija**: MCP sesije održavaju stanje kroz više zahteva, podržavajući kontinuirane razgovore, akumulaciju konteksta i upravljanje resursima.
- **Pregovaranje o mogućnostima**: Tokom uspostavljanja veze, klijenti i serveri razmenjuju informacije o podržanim funkcijama, verzijama protokola, dostupnim alatima i resursima. Ovo osigurava da obe strane razumeju mogućnosti jedna druge i mogu se prilagoditi.

#### ➕ Dodatne Korisnosti

Ispod su neke dodatne funkcionalnosti i proširenja protokola koje MCP pruža za poboljšanje iskustva programera i omogućavanje naprednih scenarija:

- **Opcije konfiguracije**: MCP omogućava dinamičku konfiguraciju parametara sesije, kao što su dozvole za alate, pristup resursima i podešavanja modela, prilagođene za svaku interakciju.
- **Praćenje napretka**: Operacije koje traju duže mogu izveštavati o napretku, omogućavajući responzivne korisničke interfejse i bolje korisničko iskustvo tokom složenih zadataka.
- **Otkazivanje zahteva**: Klijenti mogu otkazati u toku zahteve, omogućavajući korisnicima da prekinu operacije koje više nisu potrebne ili traju predugo.
- **Izveštavanje o greškama**: Standardizovane poruke o greškama i kodovi pomažu u dijagnostikovanju problema, rukovanju neuspesima na elegantan način i pružanju korisnih povratnih informacija korisnicima i programerima.
- **Logovanje**: I klijenti i serveri mogu emitovati strukturisane logove za reviziju, debagovanje i praćenje interakcija protokola.

Korišćenjem ovih karakteristika, MCP obezbeđuje robusnu, sigurnu i fleksibilnu komunikaciju između jezičkih modela i eksternih alata ili izvora podataka.

### 🔐 Bezbednosne Preporuke

Implementacije MCP-a treba da se pridržavaju nekoliko ključnih principa bezbednosti kako bi obezbedile sigurne i pouzdane interakcije:

- **Korisnički pristanak i kontrola**: Korisnici moraju dati eksplicitan pristanak pre nego što bilo koji podaci budu pristupljeni ili izvršene operacije. Trebalo bi da imaju jasnu kontrolu nad time koji se podaci dele i koje akcije su odobrene, podržano intuitivnim korisničkim interfejsima za pregled i odobravanje aktivnosti.

- **Privatnost podataka**: Korisnički podaci smeju biti izloženi samo uz eksplicitan pristanak i moraju biti zaštićeni odgovarajućim kontrolama pristupa. Implementacije MCP-a moraju sprečiti neovlašćeni prenos podataka i osigurati da privatnost bude očuvana tokom svih interakcija.

- **Bezbednost alata**: Pre pozivanja bilo kog alata neophodan je eksplicitan korisnički pristanak. Korisnici treba da budu jasno upoznati sa funkcionalnošću svakog alata, a robustne sigurnosne granice moraju biti sprovedene da bi se sprečilo neplanirano ili nesigurno izvršavanje alata.

Pridržavanjem ovih principa, MCP osigurava da poverenje korisnika, privatnost i bezbednost budu očuvani u svim interakcijama protokola.

## Primeri Koda: Ključne Komponente

Ispod su primeri koda u nekoliko popularnih programskih jezika koji ilustruju kako implementirati ključne MCP server komponente i alate.

### .NET Primer: Kreiranje Jednostavnog MCP Servera sa Alatima

Evo praktičnog primera u .NET-u koji pokazuje kako implementirati jednostavan MCP server sa prilagođenim alatima. Ovaj primer prikazuje kako definisati i registrovati alate, obrađivati zahteve i povezati server koristeći Model Context Protocol.

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

### Java Primer: MCP Server Komponente

Ovaj primer demonstrira isti MCP server i registraciju alata kao i .NET primer iznad, ali implementiran u Javi.

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

U ovom primeru pokazujemo kako napraviti MCP server u Pythonu. Takođe su prikazana dva različita načina za kreiranje alata.

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

Ovaj primer prikazuje kreiranje MCP servera u JavaScript-u i pokazuje kako registrovati dva alata vezana za vremensku prognozu.

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

Ovaj JavaScript primer demonstrira kako kreirati MCP klijenta koji se povezuje na server, šalje prompt i procesuira odgovor uključujući sve pozive alata koji su napravljeni.

## Bezbednost i Autorizacija

MCP uključuje nekoliko ugrađenih koncepata i mehanizama za upravljanje bezbednošću i autorizacijom tokom celog protokola:

1. **Kontrola dozvola za alate**  
   Klijenti mogu specificirati koje alate model sme da koristi tokom sesije. Ovo osigurava da su dostupni samo eksplicitno autorizovani alati, smanjujući rizik od neželjenih ili nesig

**Ограничење одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, молимо имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетом. За критичне информације препоручује се професионални превод од стране људског преводиоца. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала коришћењем овог превода.