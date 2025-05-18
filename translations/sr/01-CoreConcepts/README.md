<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T07:02:55+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sr"
}
-->
# 📖 MCP Osnovni Koncepti: Savladavanje Protokola Konteksta Modela za Integraciju AI

Protokol Konteksta Modela (MCP) je moćan, standardizovan okvir koji optimizuje komunikaciju između Velikih Jezičkih Modela (LLM) i eksternih alata, aplikacija i izvora podataka. Ovaj SEO-optimizovan vodič će vas provesti kroz osnovne koncepte MCP-a, osiguravajući da razumete njegovu klijent-server arhitekturu, ključne komponente, mehanizme komunikacije i najbolje prakse implementacije.

## Pregled

Ova lekcija istražuje osnovnu arhitekturu i komponente koje čine ekosistem Protokola Konteksta Modela (MCP). Naučićete o klijent-server arhitekturi, ključnim komponentama i mehanizmima komunikacije koji pokreću MCP interakcije.

## 👩‍🎓 Ključni Ciljevi Učenja

Do kraja ove lekcije, vi ćete:

- Razumeti MCP klijent-server arhitekturu.
- Identifikovati uloge i odgovornosti Domaćina, Klijenata i Servera.
- Analizirati osnovne karakteristike koje čine MCP fleksibilnim slojem integracije.
- Naučiti kako informacije teku unutar MCP ekosistema.
- Steći praktične uvide kroz primere koda u .NET, Java, Python i JavaScript.

## 🔎 MCP Arhitektura: Dublji Pogled

MCP ekosistem je izgrađen na klijent-server modelu. Ova modularna struktura omogućava AI aplikacijama da efikasno komuniciraju sa alatima, bazama podataka, API-ima i kontekstualnim resursima. Hajde da razložimo ovu arhitekturu na njene osnovne komponente.

### 1. Domaćini

U Protokolu Konteksta Modela (MCP), Domaćini igraju ključnu ulogu kao primarni interfejs kroz koji korisnici komuniciraju sa protokolom. Domaćini su aplikacije ili okruženja koja iniciraju veze sa MCP serverima kako bi pristupili podacima, alatima i podsticajima. Primeri Domaćina uključuju integrisana razvojna okruženja (IDE) kao što je Visual Studio Code, AI alati kao što je Claude Desktop, ili posebno dizajnirani agenti za specifične zadatke.

**Domaćini** su LLM aplikacije koje iniciraju veze. Oni:

- Izvršavaju ili komuniciraju sa AI modelima za generisanje odgovora.
- Iniciraju veze sa MCP serverima.
- Upravljaju tokom razgovora i korisničkim interfejsom.
- Kontrolišu dozvole i sigurnosna ograničenja.
- Rukovode korisničkim pristankom za deljenje podataka i izvršavanje alata.

### 2. Klijenti

Klijenti su ključne komponente koje olakšavaju interakciju između Domaćina i MCP servera. Klijenti deluju kao posrednici, omogućavajući Domaćinima da pristupe i koriste funkcionalnosti koje pružaju MCP serveri. Oni igraju ključnu ulogu u osiguravanju glatke komunikacije i efikasne razmene podataka unutar MCP arhitekture.

**Klijenti** su konektori unutar aplikacije domaćina. Oni:

- Šalju zahteve serverima sa podsticajima/instrukcijama.
- Pregovaraju o mogućnostima sa serverima.
- Upravljaju zahtevima za izvršavanje alata iz modela.
- Procesuiraju i prikazuju odgovore korisnicima.

### 3. Serveri

Serveri su odgovorni za obradu zahteva MCP klijenata i pružanje odgovarajućih odgovora. Oni upravljaju raznim operacijama kao što su preuzimanje podataka, izvršavanje alata i generisanje podsticaja. Serveri osiguravaju da je komunikacija između klijenata i Domaćina efikasna i pouzdana, održavajući integritet procesa interakcije.

**Serveri** su usluge koje pružaju kontekst i mogućnosti. Oni:

- Registruju dostupne funkcije (resurse, podsticaje, alate)
- Primaju i izvršavaju pozive alata od klijenta
- Pružaju kontekstualne informacije za poboljšanje odgovora modela
- Vraćaju rezultate nazad klijentu
- Održavaju stanje kroz interakcije kada je to potrebno

Serveri mogu biti razvijeni od strane bilo koga kako bi proširili mogućnosti modela sa specijalizovanom funkcionalnošću.

### 4. Karakteristike Servera

Serveri u Protokolu Konteksta Modela (MCP) pružaju osnovne gradivne blokove koji omogućavaju bogate interakcije između klijenata, domaćina i jezičkih modela. Ove karakteristike su dizajnirane da poboljšaju mogućnosti MCP-a pružajući strukturirani kontekst, alate i podsticaje.

MCP serveri mogu ponuditi bilo koju od sledećih karakteristika:

#### 📑 Resursi

Resursi u Protokolu Konteksta Modela (MCP) obuhvataju razne vrste konteksta i podataka koje korisnici ili AI modeli mogu koristiti. Ovo uključuje:

- **Kontekstualni Podaci**: Informacije i kontekst koje korisnici ili AI modeli mogu iskoristiti za donošenje odluka i izvršavanje zadataka.
- **Baze Znanja i Repozitorijumi Dokumenata**: Kolekcije strukturiranih i nestrukturiranih podataka, kao što su članci, priručnici i istraživački radovi, koje pružaju vredne uvide i informacije.
- **Lokalne Datoteke i Baze Podataka**: Podaci pohranjeni lokalno na uređajima ili unutar baza podataka, dostupni za obradu i analizu.
- **API-ji i Web Usluge**: Eksterni interfejsi i usluge koje nude dodatne podatke i funkcionalnosti, omogućavajući integraciju sa raznim online resursima i alatima.

Primer resursa može biti šema baze podataka ili datoteka koja se može pristupiti ovako:

```text
file://log.txt
database://schema
```

### 🤖 Podsticaji

Podsticaji u Protokolu Konteksta Modela (MCP) uključuju razne unapred definisane šablone i obrasce interakcije dizajnirane da pojednostave korisničke tokove rada i poboljšaju komunikaciju. Ovo uključuje:

- **Šablonirane Poruke i Tokove Rada**: Unapred strukturirane poruke i procesi koji vode korisnike kroz specifične zadatke i interakcije.
- **Unapred Definisani Obrasci Interakcije**: Standardizovane sekvence akcija i odgovora koje olakšavaju konzistentnu i efikasnu komunikaciju.
- **Specijalizovani Šabloni Razgovora**: Prilagodljivi šabloni prilagođeni za specifične tipove razgovora, osiguravajući relevantne i kontekstualno odgovarajuće interakcije.

Šablon podsticaja može izgledati ovako:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Alati

Alati u Protokolu Konteksta Modela (MCP) su funkcije koje AI model može izvršiti kako bi obavio specifične zadatke. Ovi alati su dizajnirani da poboljšaju sposobnosti AI modela pružanjem strukturiranih i pouzdanih operacija. Ključni aspekti uključuju:

- **Funkcije za Izvršavanje od Strane AI Modela**: Alati su izvršne funkcije koje AI model može pozvati kako bi obavio razne zadatke.
- **Jedinstveno Ime i Opis**: Svaki alat ima jedinstveno ime i detaljan opis koji objašnjava njegovu svrhu i funkcionalnost.
- **Parametri i Rezultati**: Alati prihvataju specifične parametre i vraćaju strukturirane rezultate, osiguravajući konzistentne i predvidive rezultate.
- **Diskretne Funkcije**: Alati obavljaju diskretne funkcije kao što su pretrage interneta, proračuni i upiti baza podataka.

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

## Karakteristike Klijenta

U Protokolu Konteksta Modela (MCP), klijenti nude nekoliko ključnih karakteristika serverima, poboljšavajući ukupnu funkcionalnost i interakciju unutar protokola. Jedna od značajnih karakteristika je Uzorkovanje.

### 👉 Uzorkovanje

- **Server-Inicirani Agentički Obrasci Ponašanja**: Klijenti omogućavaju serverima da autonomno iniciraju specifične akcije ili ponašanja, poboljšavajući dinamičke sposobnosti sistema.
- **Rekurzivne LLM Interakcije**: Ova karakteristika omogućava rekurzivne interakcije sa velikim jezičkim modelima (LLM), omogućavajući složeniju i iterativnu obradu zadataka.
- **Zahtevanje Dodatnih Dopuna Modela**: Serveri mogu zatražiti dodatne dopune od modela, osiguravajući da su odgovori temeljni i kontekstualno relevantni.

## Tok Informacija u MCP-u

Protokol Konteksta Modela (MCP) definiše strukturirani tok informacija između domaćina, klijenata, servera i modela. Razumevanje ovog toka pomaže u pojašnjavanju kako se korisnički zahtevi obrađuju i kako se eksterni alati i podaci integrišu u odgovore modela.

- **Domaćin Inicira Vezu**  
  Aplikacija domaćin (kao što je IDE ili chat interfejs) uspostavlja vezu sa MCP serverom, obično putem STDIO, WebSocket-a ili drugog podržanog transporta.

- **Pregovaranje o Sposobnostima**  
  Klijent (ugrađen u domaćina) i server razmenjuju informacije o svojim podržanim karakteristikama, alatima, resursima i verzijama protokola. Ovo osigurava da obe strane razumeju koje su mogućnosti dostupne za sesiju.

- **Korisnički Zahtev**  
  Korisnik komunicira sa domaćinom (npr. unosi podsticaj ili komandu). Domaćin prikuplja ovaj unos i prosleđuje ga klijentu na obradu.

- **Korišćenje Resursa ili Alata**  
  - Klijent može zatražiti dodatni kontekst ili resurse od servera (kao što su datoteke, unosi baze podataka ili članci baze znanja) kako bi obogatio razumevanje modela.
  - Ako model utvrdi da je potreban alat (npr. za preuzimanje podataka, izvršenje proračuna ili pozivanje API-ja), klijent šalje zahtev za pozivanje alata serveru, navodeći ime alata i parametre.

- **Izvršenje Servera**  
  Server prima zahtev za resurs ili alat, izvršava potrebne operacije (kao što su pokretanje funkcije, ispitivanje baze podataka ili preuzimanje datoteke) i vraća rezultate klijentu u strukturiranom formatu.

- **Generisanje Odgovora**  
  Klijent integriše odgovore servera (podatke o resursima, izlaze alata itd.) u tekuću interakciju modela. Model koristi ove informacije za generisanje sveobuhvatnog i kontekstualno relevantnog odgovora.

- **Prezentacija Rezultata**  
  Domaćin prima konačni izlaz od klijenta i predstavlja ga korisniku, često uključujući i generisani tekst modela i sve rezultate iz izvršenja alata ili pretrage resursa.

Ovaj tok omogućava MCP-u da podrži napredne, interaktivne i kontekstualno svesne AI aplikacije spajanjem modela sa eksternim alatima i izvorima podataka.

## Detalji Protokola

MCP (Protokol Konteksta Modela) je izgrađen na vrhu [JSON-RPC 2.0](https://www.jsonrpc.org/), pružajući standardizovan, jezički agnostičan format poruka za komunikaciju između domaćina, klijenata i servera. Ova osnova omogućava pouzdane, strukturirane i proširive interakcije na različitim platformama i programskim jezicima.

### Ključne Karakteristike Protokola

MCP proširuje JSON-RPC 2.0 dodatnim konvencijama za pozivanje alata, pristup resursima i upravljanje podsticajima. Podržava više slojeva transporta (STDIO, WebSocket, SSE) i omogućava sigurnu, proširivu i jezički agnostičnu komunikaciju između komponenti.

#### 🧢 Osnovni Protokol

- **JSON-RPC Format Poruka**: Svi zahtevi i odgovori koriste JSON-RPC 2.0 specifikaciju, osiguravajući konzistentnu strukturu za pozive metoda, parametre, rezultate i rukovanje greškama.
- **Stalne Veze**: MCP sesije održavaju stanje kroz više zahteva, podržavajući tekuće razgovore, akumulaciju konteksta i upravljanje resursima.
- **Pregovaranje o Sposobnostima**: Tokom postavljanja veze, klijenti i serveri razmenjuju informacije o podržanim karakteristikama, verzijama protokola, dostupnim alatima i resursima. Ovo osigurava da obe strane razumeju mogućnosti jedna druge i mogu se prilagoditi u skladu s tim.

#### ➕ Dodatne Usluge

Ispod su neke dodatne usluge i proširenja protokola koje MCP pruža kako bi poboljšao iskustvo programera i omogućio napredne scenarije:

- **Opcije Konfiguracije**: MCP omogućava dinamičku konfiguraciju parametara sesije, kao što su dozvole alata, pristup resursima i postavke modela, prilagođene svakoj interakciji.
- **Praćenje Napretka**: Operacije koje dugo traju mogu prijaviti ažuriranja o napretku, omogućavajući responzivne korisničke interfejse i bolje korisničko iskustvo tokom složenih zadataka.
- **Otkazivanje Zahteva**: Klijenti mogu otkazati zahteve u toku, omogućavajući korisnicima da prekinu operacije koje više nisu potrebne ili traju predugo.
- **Izveštavanje o Greškama**: Standardizovane poruke o greškama i kodovi pomažu u dijagnostikovanju problema, rukovanju neuspesima na graciozan način i pružanju korisnih povratnih informacija korisnicima i programerima.
- **Logovanje**: I klijenti i serveri mogu emitovati strukturirane logove za reviziju, otklanjanje grešaka i praćenje interakcija protokola.

Korišćenjem ovih karakteristika protokola, MCP osigurava robusnu, sigurnu i fleksibilnu komunikaciju između jezičkih modela i eksternih alata ili izvora podataka.

### 🔐 Razmatranja o Sigurnosti

Implementacije MCP-a treba da se pridržavaju nekoliko ključnih sigurnosnih principa kako bi se osigurale sigurne i pouzdane interakcije:

- **Pristanak i Kontrola Korisnika**: Korisnici moraju dati eksplicitan pristanak pre nego što se bilo koji podaci pristupe ili operacije izvrše. Oni treba da imaju jasnu kontrolu nad time koji podaci se dele i koje akcije su odobrene, podržane intuitivnim korisničkim interfejsima za pregled i odobravanje aktivnosti.

- **Privatnost Podataka**: Korisnički podaci treba da budu izloženi samo uz eksplicitan pristanak i moraju biti zaštićeni odgovarajućim kontrolama pristupa. Implementacije MCP-a moraju zaštititi od neovlašćenog prenosa podataka i osigurati da se privatnost održava kroz sve interakcije.

- **Sigurnost Alata**: Pre pozivanja bilo kog alata, potreban je eksplicitan pristanak korisnika. Korisnici treba da imaju jasno razumevanje funkcionalnosti svakog alata, a robusne sigurnosne granice moraju biti sprovedene kako bi se sprečilo nenamerno ili nesigurno izvršavanje alata.

Prateći ove principe, MCP osigurava da poverenje korisnika, privatnost i sigurnost budu očuvani kroz sve interakcije protokola.

## Primeri Koda: Ključne Komponente

Ispod su primeri koda u nekoliko popularnih programskih jezika koji ilustruju kako implementirati ključne MCP server komponente i alate.

### .NET Primer: Kreiranje Jednostavnog MCP Servera sa Alatima

Evo praktičnog .NET primera koda koji demonstrira kako implementirati jednostavan MCP server sa prilagođenim alatima. Ovaj primer prikazuje kako definisati i registrovati alate, rukovati zahtevima i povezati server koristeći Protokol Konteksta Modela.

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

Ovaj primer demonstrira isti MCP server i registraciju alata kao u .NET primeru iznad, ali implementiran u Javi.

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

U ovom primeru pokazujemo kako izgraditi MCP server u Python-u. Takođe se pokazuju dva različita načina za kreiranje alata.

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

O

**Одрицање одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да будемо прецизни, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитативним извором. За критичне информације, препоручује се професионални људски превод. Не сносимо одговорност за било каква погрешна тумачења или погрешна схватања која произилазе из коришћења овог превода.