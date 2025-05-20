<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T18:18:59+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sr"
}
-->
# 📖 MCP Osnovni Koncepti: Savladavanje Model Context Protocol-a za AI Integraciju

Model Context Protocol (MCP) je moćan, standardizovan okvir koji optimizuje komunikaciju između velikih jezičkih modela (LLM) i eksternih alata, aplikacija i izvora podataka. Ovaj SEO-optimizovani vodič će vas provesti kroz osnovne koncepte MCP-a, obezbeđujući da razumete njegovu klijent-server arhitekturu, ključne komponente, mehanizme komunikacije i najbolje prakse implementacije.

## Pregled

Ova lekcija istražuje osnovnu arhitekturu i komponente koje čine Model Context Protocol (MCP) ekosistem. Naučićete o klijent-server arhitekturi, ključnim komponentama i mehanizmima komunikacije koji pokreću MCP interakcije.

## 👩‍🎓 Ključni Ciljevi Učenja

Do kraja ove lekcije, moći ćete da:

- Razumete MCP klijent-server arhitekturu.
- Identifikujete uloge i odgovornosti Hostova, Klijenata i Servera.
- Analizirate osnovne funkcije koje čine MCP fleksibilnim slojem za integraciju.
- Naučite kako informacije teku unutar MCP ekosistema.
- Steknete praktične uvide kroz primere koda u .NET, Java, Python i JavaScript.

## 🔎 MCP Arhitektura: Detaljniji Pogled

MCP ekosistem je zasnovan na klijent-server modelu. Ova modularna struktura omogućava AI aplikacijama da efikasno komuniciraju sa alatima, bazama podataka, API-jima i kontekstualnim resursima. Hajde da razložimo ovu arhitekturu na njene osnovne komponente.

### 1. Hosts

U Model Context Protocol-u (MCP), Hosts igraju ključnu ulogu kao primarni interfejs kroz koji korisnici komuniciraju sa protokolom. Hosts su aplikacije ili okruženja koja uspostavljaju veze sa MCP serverima da bi pristupili podacima, alatima i promptovima. Primeri Hosts su integrisana razvojna okruženja (IDE) poput Visual Studio Code, AI alati kao što je Claude Desktop ili prilagođeni agenti dizajnirani za specifične zadatke.

**Hosts** su LLM aplikacije koje uspostavljaju veze. Oni:

- Izvršavaju ili komuniciraju sa AI modelima da generišu odgovore.
- Iniciraju veze sa MCP serverima.
- Upravljaju tokom konverzacije i korisničkim interfejsom.
- Kontrolišu dozvole i bezbednosne ograničenja.
- Rukovode korisničkim pristankom za deljenje podataka i izvršavanje alata.

### 2. Klijenti

Klijenti su ključne komponente koje olakšavaju interakciju između Hosts i MCP servera. Klijenti deluju kao posrednici, omogućavajući Hosts da pristupe i koriste funkcionalnosti koje pružaju MCP serveri. Oni igraju važnu ulogu u obezbeđivanju glatke komunikacije i efikasne razmene podataka unutar MCP arhitekture.

**Klijenti** su konektori unutar host aplikacije. Oni:

- Šalju zahteve serverima sa promptovima/instrukcijama.
- Pregovaraju o mogućnostima sa serverima.
- Upravljaju zahtevima za izvršavanje alata od strane modela.
- Procesuiraju i prikazuju odgovore korisnicima.

### 3. Serveri

Serveri su odgovorni za obradu zahteva od MCP klijenata i pružanje odgovarajućih odgovora. Oni upravljaju različitim operacijama kao što su preuzimanje podataka, izvršavanje alata i generisanje promptova. Serveri obezbeđuju da komunikacija između klijenata i Hosts bude efikasna i pouzdana, održavajući integritet procesa interakcije.

**Serveri** su servisi koji pružaju kontekst i mogućnosti. Oni:

- Registruju dostupne funkcije (resurse, promptove, alate).
- Primaju i izvršavaju pozive alata od klijenta.
- Pružaju kontekstualne informacije za poboljšanje odgovora modela.
- Vraćaju rezultate nazad klijentu.
- Održavaju stanje tokom interakcija kada je potrebno.

Servere može razviti bilo ko da proširi mogućnosti modela specijalizovanom funkcionalnošću.

### 4. Funkcije Servera

Serveri u Model Context Protocol-u (MCP) pružaju osnovne gradivne blokove koji omogućavaju bogate interakcije između klijenata, hostova i jezičkih modela. Ove funkcije su dizajnirane da unaprede mogućnosti MCP-a nudeći strukturirani kontekst, alate i promptove.

MCP serveri mogu ponuditi bilo koju od sledećih funkcija:

#### 📑 Resursi

Resursi u Model Context Protocol-u (MCP) obuhvataju različite vrste konteksta i podataka koje korisnici ili AI modeli mogu koristiti. To uključuje:

- **Kontekstualne podatke**: Informacije i kontekst koje korisnici ili AI modeli mogu iskoristiti za donošenje odluka i izvršavanje zadataka.
- **Baze znanja i repozitorijume dokumenata**: Kolekcije strukturiranih i nestrukturiranih podataka, poput članaka, priručnika i istraživačkih radova, koje pružaju vredne uvide i informacije.
- **Lokalne fajlove i baze podataka**: Podatke sačuvane lokalno na uređajima ili u bazama podataka, dostupne za obradu i analizu.
- **API-je i web servise**: Eksterne interfejse i servise koji nude dodatne podatke i funkcionalnosti, omogućavajući integraciju sa različitim online resursima i alatima.

Primer resursa može biti šema baze podataka ili fajl kojem se može pristupiti na sledeći način:

```text
file://log.txt
database://schema
```

### 🤖 Promptovi

Promptovi u Model Context Protocol-u (MCP) uključuju različite unapred definisane šablone i obrasce interakcije dizajnirane da pojednostave korisničke tokove rada i unaprede komunikaciju. To uključuje:

- **Šablonske poruke i tokove rada**: Unapred strukturisane poruke i procesi koji vode korisnike kroz specifične zadatke i interakcije.
- **Unapred definisani obrasci interakcije**: Standardizovane sekvence akcija i odgovora koje omogućavaju doslednu i efikasnu komunikaciju.
- **Specijalizovani šabloni za razgovore**: Prilagodljivi šabloni namenjeni za određene tipove razgovora, obezbeđujući relevantne i kontekstualno prikladne interakcije.

Primer šablona prompta može izgledati ovako:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Alati

Alati u Model Context Protocol-u (MCP) su funkcije koje AI model može izvršavati da bi obavio specifične zadatke. Ovi alati su dizajnirani da unaprede mogućnosti AI modela pružajući strukturirane i pouzdane operacije. Ključni aspekti uključuju:

- **Funkcije koje AI model može izvršavati**: Alati su izvršne funkcije koje AI model može pozvati da obavi razne zadatke.
- **Jedinstveno ime i opis**: Svaki alat ima jedinstveno ime i detaljan opis koji objašnjava njegovu svrhu i funkcionalnost.
- **Parametri i izlazi**: Alati prihvataju specifične parametre i vraćaju strukturirane izlaze, obezbeđujući dosledne i predvidive rezultate.
- **Diskretne funkcije**: Alati obavljaju diskretne funkcije kao što su pretraga na internetu, proračuni i upiti baza podataka.

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

## Funkcije Klijenta

U Model Context Protocol-u (MCP), klijenti nude nekoliko ključnih funkcija serverima, unapređujući ukupnu funkcionalnost i interakciju unutar protokola. Jedna od značajnih funkcija je Sampling.

### 👉 Sampling

- **Server-Inicirane Agentne Akcije**: Klijenti omogućavaju serverima da autonomno iniciraju specifične akcije ili ponašanja, unapređujući dinamičke mogućnosti sistema.
- **Rekurzivne LLM Interakcije**: Ova funkcija omogućava rekurzivne interakcije sa velikim jezičkim modelima (LLM), omogućavajući složeniju i iterativnu obradu zadataka.
- **Zahtevanje Dodatnih Završetaka Modela**: Serveri mogu zahtevati dodatne završetke od modela, osiguravajući da su odgovori sveobuhvatni i kontekstualno relevantni.

## Tok Informacija u MCP-u

Model Context Protocol (MCP) definiše strukturisan tok informacija između hostova, klijenata, servera i modela. Razumevanje ovog toka pomaže da se razjasni kako se korisnički zahtevi obrađuju i kako se eksterni alati i podaci integrišu u odgovore modela.

- **Host Inicira Vezu**  
  Host aplikacija (kao što je IDE ili chat interfejs) uspostavlja vezu sa MCP serverom, obično putem STDIO, WebSocket-a ili drugog podržanog transporta.

- **Pregovaranje o Mogućnostima**  
  Klijent (ugrađen u host) i server razmenjuju informacije o podržanim funkcijama, alatima, resursima i verzijama protokola. Ovo osigurava da obe strane razumeju koje su mogućnosti dostupne za sesiju.

- **Korisnički Zahtev**  
  Korisnik komunicira sa hostom (npr. unosi prompt ili komandu). Host prikuplja ovaj unos i prosleđuje ga klijentu na obradu.

- **Korišćenje Resursa ili Alata**  
  - Klijent može zatražiti dodatni kontekst ili resurse od servera (kao što su fajlovi, unosi u bazi podataka ili članci iz baze znanja) da obogati razumevanje modela.
  - Ako model proceni da je potreban alat (npr. za preuzimanje podataka, izvršavanje proračuna ili pozivanje API-ja), klijent šalje zahtev za poziv alata serveru, navodeći ime alata i parametre.

- **Izvršenje na Serveru**  
  Server prima zahtev za resurs ili alat, izvršava potrebne operacije (kao što su pokretanje funkcije, upit baze podataka ili preuzimanje fajla) i vraća rezultate klijentu u strukturisanom formatu.

- **Generisanje Odgovora**  
  Klijent integriše odgovore servera (podatke resursa, izlaze alata itd.) u tekuću interakciju sa modelom. Model koristi ove informacije da generiše sveobuhvatan i kontekstualno relevantan odgovor.

- **Prikaz Rezultata**  
  Host prima finalni izlaz od klijenta i prikazuje ga korisniku, često uključujući i generisani tekst modela kao i rezultate izvršenja alata ili pretrage resursa.

Ovaj tok omogućava MCP-u da podrži napredne, interaktivne i kontekstualno svesne AI aplikacije besprekornim povezivanjem modela sa eksternim alatima i izvorima podataka.

## Detalji Protokola

MCP (Model Context Protocol) je izgrađen na vrhu [JSON-RPC 2.0](https://www.jsonrpc.org/), pružajući standardizovani, jezički nezavisni format poruka za komunikaciju između hostova, klijenata i servera. Ova osnova omogućava pouzdane, strukturisane i proširive interakcije na različitim platformama i programskim jezicima.

### Ključne Funkcije Protokola

MCP proširuje JSON-RPC 2.0 dodatnim konvencijama za pozivanje alata, pristup resursima i upravljanje promptovima. Podržava višestruke transportne slojeve (STDIO, WebSocket, SSE) i omogućava sigurnu, proširivu i jezički nezavisnu komunikaciju između komponenti.

#### 🧢 Osnovni Protokol

- **JSON-RPC Format Poruka**: Svi zahtevi i odgovori koriste JSON-RPC 2.0 specifikaciju, obezbeđujući doslednu strukturu za pozive metoda, parametre, rezultate i obradu grešaka.
- **Stanja Veza**: MCP sesije održavaju stanje kroz više zahteva, podržavajući tekuće razgovore, akumulaciju konteksta i upravljanje resursima.
- **Pregovaranje o Mogućnostima**: Tokom uspostavljanja veze, klijenti i serveri razmenjuju informacije o podržanim funkcijama, verzijama protokola, dostupnim alatima i resursima. Ovo osigurava da obe strane razumeju mogućnosti jedna druge i mogu se prilagoditi.

#### ➕ Dodatni Alati

Ispod su neki dodatni alati i proširenja protokola koje MCP pruža za unapređenje iskustva programera i omogućavanje naprednih scenarija:

- **Opcije Konfiguracije**: MCP omogućava dinamičku konfiguraciju parametara sesije, kao što su dozvole za alate, pristup resursima i podešavanja modela, prilagođene svakoj interakciji.
- **Praćenje Napretka**: Operacije koje traju duže mogu izveštavati o napretku, omogućavajući responzivne korisničke interfejse i bolje korisničko iskustvo tokom složenih zadataka.
- **Otkazivanje Zahteva**: Klijenti mogu otkazati aktivne zahteve, dozvoljavajući korisnicima da prekinu operacije koje više nisu potrebne ili traju predugo.
- **Izveštavanje o Greškama**: Standardizovane poruke o greškama i kodovi pomažu u dijagnostikovanju problema, elegantnom upravljanju greškama i pružanju korisnih povratnih informacija korisnicima i programerima.
- **Logovanje**: I klijenti i serveri mogu emitovati strukturisane zapise za reviziju, debagovanje i praćenje interakcija protokola.

Korišćenjem ovih funkcija protokola, MCP osigurava robusnu, sigurnu i fleksibilnu komunikaciju između jezičkih modela i eksternih alata ili izvora podataka.

### 🔐 Bezbednosni Aspekti

Implementacije MCP-a treba da se pridržavaju nekoliko ključnih bezbednosnih principa kako bi osigurale sigurne i pouzdane interakcije:

- **Korisnički Pristanak i Kontrola**: Korisnici moraju dati izričit pristanak pre nego što bilo koji podaci budu pristupljeni ili operacije izvršene. Trebalo bi da imaju jasnu kontrolu nad time koji se podaci dele i koje akcije su autorizovane, podržano intuitivnim korisničkim interfejsima za pregled i odobravanje aktivnosti.

- **Privatnost Podataka**: Korisnički podaci smeju biti otkriveni samo uz izričit pristanak i moraju biti zaštićeni odgovarajućim kontrolama pristupa. Implementacije MCP-a moraju sprečiti neovlašćeni prenos podataka i obezbediti da privatnost bude održana tokom svih interakcija.

- **Bezbednost Alata**: Pre pozivanja bilo kog alata, potreban je izričit korisnički pristanak. Korisnici treba da jasno razumeju funkcionalnost svakog alata, a stroge bezbednosne granice moraju biti primenjene da se spreči neželjeno ili nesigurno izvršavanje alata.

Pridržavanjem ovih principa, MCP osigurava da poverenje korisnika, privatnost i bezbednost budu očuvani kroz sve interakcije protokola.

## Primeri Koda: Ključne Komponente

Ispod su primeri koda u nekoliko popularnih programskih jezika koji ilustruju kako implementirati ključne MCP server komponente i alate.

### .NET Primer: Kreiranje Jednostavnog MCP Servera sa Alatima

Evo praktičnog .NET primera koda koji pokazuje kako implementirati jednostavan MCP server sa prilagođenim alatima. Ovaj primer demonstrira kako definisati i registrovati alate, obrađivati zahteve i povezati server koristeći Model Context Protocol.

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

U ovom primeru pokazujemo kako izgraditi MCP server u Pythonu. Takođe su prikazana dva različita načina za kreiranje alata.

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

Ovaj JavaScript primer demonstrira kako kreirati MCP klijenta koji se povezuje na server, šalje prompt i obrađuje odgovor uključujući i sve pozive alata koji su izvršeni.

## Bezbednost i Autorizacija

MCP uključuje nekoliko ugrađenih koncepata i mehanizama za upravljanje bezbednošću i autorizacijom kroz ceo protokol:

1. **Kontrola Dozvola za Alate**:  
  Klijenti mogu precizirati koje alate model

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI prevodilačke usluge [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo tačnosti, imajte na umu da automatski prevodi mogu sadržavati greške ili netačnosti. Izvorni dokument na njegovom izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja proizašla iz korišćenja ovog prevoda.