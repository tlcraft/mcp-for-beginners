<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "88b863a69b4f18b15e82da358ffd3489",
  "translation_date": "2025-08-21T13:54:22+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "sl"
}
-->
# MCP Osnovni Pojmi: Obvladovanje Protokola Modelskega Konteksta za Integracijo AI

[![MCP Osnovni Pojmi](../../../translated_images/02.8203e26c6fb5a797f38a10012061013ec66c95bb3260f6c9cfd2bf74b00860e1.sl.png)](https://youtu.be/earDzWGtE84)

_(Kliknite zgornjo sliko za ogled videa te lekcije)_

[Model Context Protocol (MCP)](https://github.com/modelcontextprotocol) je zmogljiv, standardiziran okvir, ki optimizira komunikacijo med velikimi jezikovnimi modeli (LLM) in zunanjimi orodji, aplikacijami ter viri podatkov. Ta vodnik vas bo popeljal skozi osnovne koncepte MCP. Spoznali boste njegovo arhitekturo odjemalec-strežnik, ključne komponente, mehanizme komunikacije in najboljše prakse implementacije.

- **Izrecno soglasje uporabnika**: Vsi dostopi do podatkov in operacije zahtevajo izrecno odobritev uporabnika pred izvedbo. Uporabniki morajo jasno razumeti, kateri podatki bodo dostopani in katere akcije bodo izvedene, z natančnim nadzorom dovoljenj in avtorizacij.

- **Zaščita zasebnosti podatkov**: Podatki uporabnika so razkriti le z izrecnim soglasjem in morajo biti zaščiteni z robustnimi kontrolami dostopa skozi celoten življenjski cikel interakcije. Implementacije morajo preprečiti nepooblaščeno prenašanje podatkov in vzdrževati stroge meje zasebnosti.

- **Varnost izvajanja orodij**: Vsak klic orodja zahteva izrecno soglasje uporabnika z jasnim razumevanjem funkcionalnosti orodja, parametrov in možnih posledic. Robustne varnostne meje morajo preprečiti nenamerno, nevarno ali zlonamerno izvajanje orodij.

- **Varnost transportne plasti**: Vsi komunikacijski kanali morajo uporabljati ustrezne mehanizme šifriranja in avtentikacije. Oddaljene povezave morajo implementirati varne transportne protokole in ustrezno upravljanje poverilnic.

#### Smernice za implementacijo:

- **Upravljanje dovoljenj**: Implementirajte natančne sisteme dovoljenj, ki uporabnikom omogočajo nadzor nad tem, kateri strežniki, orodja in viri so dostopni.
- **Avtentikacija in avtorizacija**: Uporabljajte varne metode avtentikacije (OAuth, API ključi) z ustreznim upravljanjem in potekom veljavnosti žetonov.
- **Validacija vhodnih podatkov**: Validirajte vse parametre in vhodne podatke glede na definirane sheme, da preprečite napade z vnosom.
- **Revizijski zapisi**: Vzdržujte obsežne zapise vseh operacij za varnostno spremljanje in skladnost.

## Pregled

Ta lekcija raziskuje temeljno arhitekturo in komponente, ki sestavljajo ekosistem Model Context Protocol (MCP). Spoznali boste arhitekturo odjemalec-strežnik, ključne komponente in mehanizme komunikacije, ki poganjajo MCP interakcije.

## Ključni učni cilji

Do konca te lekcije boste:

- Razumeli arhitekturo MCP odjemalec-strežnik.
- Prepoznali vloge in odgovornosti gostiteljev, odjemalcev in strežnikov.
- Analizirali ključne značilnosti, zaradi katerih je MCP prilagodljiv sloj za integracijo.
- Spoznali, kako informacije tečejo znotraj ekosistema MCP.
- Pridobili praktične vpoglede skozi primere kode v .NET, Java, Python in JavaScript.

## MCP Arhitektura: Pogled v globino

Ekosistem MCP temelji na modelu odjemalec-strežnik. Ta modularna struktura omogoča AI aplikacijam učinkovito interakcijo z orodji, bazami podatkov, API-ji in kontekstualnimi viri. Razčlenimo to arhitekturo na njene osnovne komponente.

V svojem jedru MCP sledi arhitekturi odjemalec-strežnik, kjer se gostiteljska aplikacija lahko poveže z več strežniki:

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

- **MCP Gostitelji**: Programi, kot so VSCode, Claude Desktop, IDE-ji ali AI orodja, ki želijo dostopati do podatkov prek MCP.
- **MCP Odjemalci**: Protokolni odjemalci, ki vzdržujejo 1:1 povezave s strežniki.
- **MCP Strežniki**: Lahki programi, ki vsak izpostavljajo specifične zmogljivosti prek standardiziranega Model Context Protocol.
- **Lokalni viri podatkov**: Datoteke, baze podatkov in storitve na vašem računalniku, do katerih lahko MCP strežniki varno dostopajo.
- **Oddaljene storitve**: Zunanji sistemi, dostopni prek interneta, s katerimi se MCP strežniki lahko povežejo prek API-jev.

Protokol MCP je razvijajoči se standard, ki uporablja datumsko različico (format YYYY-MM-DD). Trenutna različica protokola je **2025-06-18**. Najnovejše posodobitve specifikacije protokola si lahko ogledate na [specifikacija protokola](https://modelcontextprotocol.io/specification/2025-06-18/).

### 1. Gostitelji

V Model Context Protocol (MCP) so **Gostitelji** AI aplikacije, ki služijo kot primarni vmesnik, prek katerega uporabniki komunicirajo s protokolom. Gostitelji usklajujejo in upravljajo povezave z več MCP strežniki z ustvarjanjem namenskih MCP odjemalcev za vsako povezavo s strežnikom. Primeri gostiteljev vključujejo:

- **AI aplikacije**: Claude Desktop, Visual Studio Code, Claude Code.
- **Razvojna okolja**: IDE-ji in urejevalniki kode z integracijo MCP.
- **Prilagojene aplikacije**: Namenska AI orodja in agenti.

**Gostitelji** so aplikacije, ki usklajujejo interakcije z AI modeli. Njihove naloge vključujejo:

- **Orkestracija AI modelov**: Izvajanje ali interakcija z LLM-ji za generiranje odgovorov in usklajevanje AI delovnih tokov.
- **Upravljanje povezav odjemalcev**: Ustvarjanje in vzdrževanje enega MCP odjemalca na povezavo s strežnikom.
- **Nadzor uporabniškega vmesnika**: Upravljanje poteka pogovora, interakcij z uporabnikom in predstavitve odgovorov.
- **Izvajanje varnosti**: Nadzor dovoljenj, varnostnih omejitev in avtentikacije.
- **Upravljanje soglasja uporabnika**: Upravljanje odobritev uporabnika za deljenje podatkov in izvajanje orodij.

### 2. Odjemalci

**Odjemalci** so ključne komponente, ki vzdržujejo namensko povezavo ena-na-ena med gostitelji in MCP strežniki. Vsak MCP odjemalec je ustvarjen s strani gostitelja za povezavo s specifičnim MCP strežnikom, kar zagotavlja organizirane in varne komunikacijske kanale. Več odjemalcev omogoča gostiteljem hkratno povezovanje z več strežniki.

Naloge **odjemalcev** vključujejo:

- **Komunikacija protokola**: Pošiljanje JSON-RPC 2.0 zahtevkov strežnikom z navodili in pozivi.
- **Pogajanje zmogljivosti**: Pogajanje o podprtih funkcijah in različicah protokola s strežniki med inicializacijo.
- **Izvajanje orodij**: Upravljanje zahtev za izvajanje orodij in obdelava odgovorov.
- **Posodobitve v realnem času**: Upravljanje obvestil in posodobitev v realnem času s strani strežnikov.
- **Obdelava odgovorov**: Obdelava in formatiranje odgovorov strežnikov za prikaz uporabnikom.

### 3. Strežniki

**Strežniki** so programi, ki zagotavljajo kontekst, orodja in zmogljivosti MCP odjemalcem. Lahko se izvajajo lokalno (na istem računalniku kot gostitelj) ali oddaljeno (na zunanjih platformah) in so odgovorni za obdelavo zahtevkov odjemalcev ter zagotavljanje strukturiranih odgovorov. Strežniki izpostavljajo specifične funkcionalnosti prek standardiziranega Model Context Protocol.

Naloge **strežnikov** vključujejo:

- **Registracija funkcij**: Registracija in izpostavljanje razpoložljivih primitivov (virov, pozivov, orodij) odjemalcem.
- **Obdelava zahtevkov**: Sprejemanje in izvajanje klicev orodij, zahtevkov za vire in pozive od odjemalcev.
- **Zagotavljanje konteksta**: Zagotavljanje kontekstualnih informacij in podatkov za izboljšanje odgovorov modela.
- **Upravljanje stanja**: Vzdrževanje stanja seje in obravnava interakcij s stanjem, kadar je to potrebno.
- **Obvestila v realnem času**: Pošiljanje obvestil o spremembah zmogljivosti in posodobitvah povezanih odjemalcev.

Strežnike lahko razvije kdorkoli za razširitev zmogljivosti modela s specializirano funkcionalnostjo, podpirajo pa tako lokalne kot oddaljene scenarije uvajanja.

### 4. Primitivi strežnika

Strežniki v Model Context Protocol (MCP) zagotavljajo tri osnovne **primitive**, ki določajo temeljne gradnike za bogate interakcije med odjemalci, gostitelji in jezikovnimi modeli. Te primitive določajo vrste kontekstualnih informacij in dejanj, ki so na voljo prek protokola.

MCP strežniki lahko izpostavijo katerokoli kombinacijo naslednjih treh osnovnih primitivov:

#### Viri

**Viri** so podatkovni viri, ki zagotavljajo kontekstualne informacije AI aplikacijam. Predstavljajo statično ali dinamično vsebino, ki lahko izboljša razumevanje in odločanje modela:

- **Kontekstualni podatki**: Strukturirane informacije in kontekst za porabo AI modela.
- **Baze znanja**: Repozitoriji dokumentov, članki, priročniki in raziskovalni članki.
- **Lokalni viri podatkov**: Datoteke, baze podatkov in informacije lokalnega sistema.
- **Zunanji podatki**: Odzivi API-jev, spletne storitve in podatki oddaljenih sistemov.
- **Dinamična vsebina**: Podatki v realnem času, ki se posodabljajo glede na zunanje pogoje.

Viri so identificirani z URI-ji in podpirajo odkrivanje prek metod `resources/list` in pridobivanje prek `resources/read`:

```text
file://documents/project-spec.md
database://production/users/schema
api://weather/current
```

#### Pozivi

**Pozivi** so ponovno uporabne predloge, ki pomagajo strukturirati interakcije z jezikovnimi modeli. Omogočajo standardizirane vzorce interakcij in predloge delovnih tokov:

- **Interakcije na osnovi predlog**: Vnaprej strukturirana sporočila in začetki pogovorov.
- **Predloge delovnih tokov**: Standardizirani zaporedji za običajne naloge in interakcije.
- **Primeri za učenje**: Predloge na osnovi primerov za navodila modelu.
- **Sistemski pozivi**: Temeljni pozivi, ki določajo vedenje in kontekst modela.
- **Dinamične predloge**: Parametrizirani pozivi, prilagojeni specifičnim kontekstom.

Pozivi podpirajo zamenjavo spremenljivk in jih je mogoče odkriti prek `prompts/list` ter pridobiti z `prompts/get`:

```markdown
Generate a {{task_type}} for {{product}} targeting {{audience}} with the following requirements: {{requirements}}
```

#### Orodja

**Orodja** so izvedljive funkcije, ki jih lahko AI modeli pokličejo za izvajanje specifičnih dejanj. Predstavljajo "glagole" ekosistema MCP, ki omogočajo modelom interakcijo z zunanjimi sistemi:

- **Izvedljive funkcije**: Diskretne operacije, ki jih modeli lahko pokličejo s specifičnimi parametri.
- **Integracija zunanjih sistemov**: Klici API-jev, poizvedbe v bazah podatkov, operacije z datotekami, izračuni.
- **Edinstvena identiteta**: Vsako orodje ima edinstveno ime, opis in shemo parametrov.
- **Strukturiran vhod/izhod**: Orodja sprejemajo validirane parametre in vračajo strukturirane, tipizirane odgovore.
- **Zmogljivosti dejanj**: Omogočajo modelom izvajanje dejanj v resničnem svetu in pridobivanje živih podatkov.

Orodja so definirana z JSON shemo za validacijo parametrov, odkrita prek `tools/list` in izvedena prek `tools/call`:

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

## Primitivi odjemalcev

V Model Context Protocol (MCP) lahko **odjemalci** izpostavijo primitive, ki omogočajo strežnikom zahtevanje dodatnih zmogljivosti od gostiteljske aplikacije. Ti primitivni na strani odjemalca omogočajo bogatejše, bolj interaktivne implementacije strežnikov, ki lahko dostopajo do zmogljivosti AI modelov in interakcij z uporabniki.

### Vzorčenje

**Vzorčenje** omogoča strežnikom zahtevanje dopolnitev jezikovnega modela iz AI aplikacije odjemalca. Ta primitiv omogoča strežnikom dostop do zmogljivosti LLM brez lastnih odvisnosti od modelov:

- **Dostop neodvisen od modela**: Strežniki lahko zahtevajo dopolnitve brez vključevanja SDK-jev LLM ali upravljanja dostopa do modela.
- **AI na pobudo strežnika**: Omogoča strežnikom avtonomno generiranje vsebine z uporabo AI modela odjemalca.
- **Rekurzivne interakcije LLM**: Podpira kompleksne scenarije, kjer strežniki potrebujejo pomoč AI za obdelavo.
- **Generiranje dinamične vsebine**: Omogoča strežnikom ustvarjanje kontekstualnih odgovorov z uporabo modela gostitelja.

Vzorčenje se sproži prek metode `sampling/complete`, kjer strežniki pošljejo zahteve za dopolnitev odjemalcem.

### Elicitacija

**Elicitacija** omogoča strežnikom zahtevanje dodatnih informacij ali potrditve od uporabnikov prek vmesnika odjemalca:

- **Zahteve za vnos uporabnika**: Strežniki lahko zahtevajo dodatne informacije, kadar so potrebne za izvajanje orodij.
- **Potrditveni dialogi**: Zahteva uporabniško odobritev za občutljive ali vplivne operacije.
- **Interaktivni delovni tokovi**: Omogoča strežnikom ustvarjanje korak-po-korak interakcij z uporabnikom.
- **Zbiranje dinamičnih parametrov**: Zbiranje manjkajočih ali neobveznih parametrov med izvajanjem orodij.

Zahteve za elicitacijo se izvajajo z metodo `elicitation/request` za zbiranje uporabniškega vnosa prek vmesnika odjemalca.

### Beleženje

**Beleženje** omogoča strežnikom pošiljanje strukturiranih dnevniških sporočil odjemalcem za odpravljanje napak, spremljanje in operativno preglednost:

- **Podpora za odpravljanje napak**: Omogoča strežnikom zagotavljanje podrobnih dnevnikov izvajanja za odpravljanje težav.
- **Operativno spremljanje**: Pošiljanje posodobitev stanja in meritev zmogljivosti odjemalcem.
- **Poročanje o napakah**: Zagotavljanje podrobnega konteksta napak in diagnostičnih informacij.
- **Revizijske sledi**: Ustvarjanje obsežnih dnevnikov operacij in odločitev strežnika.

Dnevniška sporočila se pošiljajo odjemalcem za zagotavljanje preglednosti operacij strežnika in olajšanje odpravljanja napak.

## Tok informacij v MCP

Model Context Protocol (MCP) definira strukturiran tok informacij med gostitelji, odjemalci, strežniki in modeli. Razumevanje tega toka pomaga pojasniti, kako se obdelujejo uporabniške zahteve in kako se zunanja orodja ter podatki integrirajo v odgovore modela.

- **Gostitelj vzpostavi povezavo**  
  Gostiteljska aplikacija (kot je IDE ali vmesnik za klepet) vzpostavi povezavo z MCP strežnikom, običajno prek STDIO, WebSocket ali drugega podprtega transporta.

- **Pogajanje zmogljivosti**  
  Odjemalec (vgrajen v gostitelja) in strežnik izmenjata informacije o svojih podprtih funkcijah, orodjih, virih in različicah protokola. To zagotavlja, da obe strani razumeta, katere zmogljivosti so na voljo za sejo.

- **Uporabniška zahteva**  
  Uporabnik komunicira z gostiteljem (npr. vnese poziv ali ukaz). Gostitelj zbere ta vnos in ga posreduje odjemalcu v obdelavo.

-
- **JSON-RPC 2.0 protokol**: Vsa komunikacija uporablja standardiziran format sporočil JSON-RPC 2.0 za klice metod, odgovore in obvestila  
- **Upravljanje življenjskega cikla**: Obvladuje inicializacijo povezave, pogajanje o zmogljivostih in zaključevanje sej med odjemalci in strežniki  
- **Osnovne funkcije strežnika**: Omogoča strežnikom zagotavljanje osnovne funkcionalnosti prek orodij, virov in pozivov  
- **Osnovne funkcije odjemalca**: Omogoča strežnikom zahtevanje vzorčenja iz LLM-jev, pridobivanje uporabniškega vnosa in pošiljanje dnevniških sporočil  
- **Obvestila v realnem času**: Podpira asinhrona obvestila za dinamične posodobitve brez potrebe po stalnem preverjanju  

#### Ključne značilnosti:

- **Pogajanje o različici protokola**: Uporablja datumsko različico (YYYY-MM-DD) za zagotavljanje združljivosti  
- **Odkritje zmogljivosti**: Odjemalci in strežniki med inicializacijo izmenjajo informacije o podprtih funkcijah  
- **Seje z ohranjanjem stanja**: Ohranja stanje povezave skozi več interakcij za kontinuiteto konteksta  

### Transportna plast

**Transportna plast** upravlja komunikacijske kanale, oblikovanje sporočil in avtentikacijo med udeleženci MCP:

#### Podprti transportni mehanizmi:

1. **STDIO transport**:
   - Uporablja standardne tokove vhod/izhod za neposredno komunikacijo med procesi  
   - Optimalno za lokalne procese na istem računalniku brez omrežne obremenitve  
   - Pogosto uporabljeno za lokalne implementacije MCP strežnikov  

2. **Streamable HTTP transport**:
   - Uporablja HTTP POST za sporočila odjemalec-strežnik  
   - Opcijsko Server-Sent Events (SSE) za pretakanje sporočil strežnik-odjemalec  
   - Omogoča komunikacijo z oddaljenimi strežniki prek omrežij  
   - Podpira standardno avtentikacijo HTTP (žetoni, API ključi, prilagojene glave)  
   - MCP priporoča OAuth za varno avtentikacijo na osnovi žetonov  

#### Abstrakcija transporta:

Transportna plast abstrahira podrobnosti komunikacije od podatkovne plasti, kar omogoča uporabo istega formata sporočil JSON-RPC 2.0 pri vseh transportnih mehanizmih. Ta abstrakcija omogoča aplikacijam brezhibno preklapljanje med lokalnimi in oddaljenimi strežniki.

### Varnostni vidiki

Implementacije MCP morajo upoštevati več ključnih varnostnih načel za zagotavljanje varnih, zaupanja vrednih in zaščitenih interakcij pri vseh operacijah protokola:

- **Uporabniško soglasje in nadzor**: Uporabniki morajo podati izrecno soglasje, preden se dostopa do podatkov ali izvedejo operacije. Imeli naj bi jasen nadzor nad tem, kateri podatki se delijo in katere akcije so odobrene, podprto z intuitivnimi uporabniškimi vmesniki za pregled in odobritev dejavnosti.  

- **Zasebnost podatkov**: Uporabniški podatki se smejo razkriti le z izrecnim soglasjem in morajo biti zaščiteni z ustreznimi kontrolami dostopa. Implementacije MCP morajo preprečiti nepooblaščeno prenašanje podatkov in zagotoviti, da je zasebnost ohranjena skozi vse interakcije.  

- **Varnost orodij**: Pred uporabo katerega koli orodja je potrebno izrecno soglasje uporabnika. Uporabniki morajo jasno razumeti funkcionalnost vsakega orodja, hkrati pa je treba uvesti robustne varnostne meje za preprečevanje nenamernih ali nevarnih izvedb orodij.  

Z upoštevanjem teh varnostnih načel MCP zagotavlja zaupanje uporabnikov, zaščito zasebnosti in varnost pri vseh interakcijah protokola, hkrati pa omogoča zmogljive integracije umetne inteligence.

## Primeri kode: Ključne komponente

Spodaj so primeri kode v več priljubljenih programskih jezikih, ki prikazujejo, kako implementirati ključne komponente in orodja MCP strežnika.

### Primer .NET: Ustvarjanje preprostega MCP strežnika z orodji

Tukaj je praktičen primer kode v .NET, ki prikazuje, kako implementirati preprost MCP strežnik s prilagojenimi orodji. Primer prikazuje, kako definirati in registrirati orodja, obdelati zahteve in povezati strežnik z Model Context Protocol.

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

### Primer Java: Komponente MCP strežnika

Ta primer prikazuje enak MCP strežnik in registracijo orodij kot zgornji primer v .NET, vendar implementiran v Javi.

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

### Primer Python: Gradnja MCP strežnika

V tem primeru je prikazano, kako zgraditi MCP strežnik v Pythonu. Prikazani sta tudi dve različni metodi za ustvarjanje orodij.

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

### Primer JavaScript: Ustvarjanje MCP strežnika

Ta primer prikazuje ustvarjanje MCP strežnika v JavaScriptu in kako registrirati dve orodji, povezani z vremenom.

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

Ta primer JavaScript prikazuje, kako ustvariti MCP odjemalca, ki se poveže s strežnikom, pošlje poziv in obdela odgovor, vključno z morebitnimi izvedenimi klici orodij.

## Varnost in avtentikacija

MCP vključuje več vgrajenih konceptov in mehanizmov za upravljanje varnosti in avtentikacije skozi celoten protokol:

1. **Nadzor dovoljenj za orodja**:  
   Odjemalci lahko določijo, katera orodja lahko model uporablja med sejo. To zagotavlja, da so dostopna le izrecno odobrena orodja, kar zmanjšuje tveganje nenamernih ali nevarnih operacij. Dovoljenja je mogoče dinamično konfigurirati glede na uporabniške preference, organizacijske politike ali kontekst interakcije.  

2. **Avtentikacija**:  
   Strežniki lahko zahtevajo avtentikacijo, preden omogočijo dostop do orodij, virov ali občutljivih operacij. To lahko vključuje API ključe, OAuth žetone ali druge sheme avtentikacije. Pravilna avtentikacija zagotavlja, da lahko strežniške zmogljivosti uporabljajo le zaupanja vredni odjemalci in uporabniki.  

3. **Validacija**:  
   Za vse klice orodij se izvaja validacija parametrov. Vsako orodje definira pričakovane tipe, formate in omejitve za svoje parametre, strežnik pa ustrezno validira dohodne zahteve. To preprečuje, da bi napačni ali zlonamerni vnosi dosegli implementacije orodij, in pomaga ohranjati integriteto operacij.  

4. **Omejevanje hitrosti**:  
   Za preprečevanje zlorab in zagotavljanje pravične uporabe strežniških virov lahko MCP strežniki izvajajo omejevanje hitrosti za klice orodij in dostop do virov. Omejitve hitrosti je mogoče uporabiti na uporabnika, sejo ali globalno in pomagajo zaščititi pred napadi zavrnitve storitve ali prekomerno porabo virov.  

S kombinacijo teh mehanizmov MCP zagotavlja varno osnovo za integracijo jezikovnih modelov z zunanjimi orodji in viri podatkov, hkrati pa uporabnikom in razvijalcem omogoča natančen nadzor nad dostopom in uporabo.

## Sporočila protokola in potek komunikacije

Komunikacija MCP uporablja strukturirana sporočila **JSON-RPC 2.0** za omogočanje jasnih in zanesljivih interakcij med gostitelji, odjemalci in strežniki. Protokol definira specifične vzorce sporočil za različne vrste operacij:

### Osnovne vrste sporočil:

#### **Inicializacijska sporočila**
- **`initialize` zahteva**: Ustanovi povezavo in se pogaja o različici protokola ter zmogljivostih  
- **`initialize` odgovor**: Potrdi podprte funkcije in informacije o strežniku  
- **`notifications/initialized`**: Signalizira, da je inicializacija zaključena in seja pripravljena  

#### **Sporočila za odkritje**
- **`tools/list` zahteva**: Odkrije razpoložljiva orodja na strežniku  
- **`resources/list` zahteva**: Prikaže razpoložljive vire (podatkovne vire)  
- **`prompts/list` zahteva**: Pridobi razpoložljive predloge pozivov  

#### **Izvedbena sporočila**  
- **`tools/call` zahteva**: Izvede določeno orodje z danimi parametri  
- **`resources/read` zahteva**: Pridobi vsebino iz določenega vira  
- **`prompts/get` zahteva**: Pridobi predlogo poziva z opcijskimi parametri  

#### **Sporočila na strani odjemalca**
- **`sampling/complete` zahteva**: Strežnik zahteva dokončanje LLM od odjemalca  
- **`elicitation/request`**: Strežnik zahteva uporabniški vnos prek vmesnika odjemalca  
- **Dnevniška sporočila**: Strežnik pošlje strukturirana dnevniška sporočila odjemalcu  

#### **Obvestilna sporočila**
- **`notifications/tools/list_changed`**: Strežnik obvesti odjemalca o spremembah orodij  
- **`notifications/resources/list_changed`**: Strežnik obvesti odjemalca o spremembah virov  
- **`notifications/prompts/list_changed`**: Strežnik obvesti odjemalca o spremembah pozivov  

### Struktura sporočil:

Vsa sporočila MCP sledijo formatu JSON-RPC 2.0 z:  
- **Zahtevami**: Vključujejo `id`, `method` in opcijske `params`  
- **Odgovori**: Vključujejo `id` in bodisi `result` bodisi `error`  
- **Obvestili**: Vključujejo `method` in opcijske `params` (brez `id` ali pričakovanega odgovora)  

Ta strukturirana komunikacija zagotavlja zanesljive, sledljive in razširljive interakcije, ki podpirajo napredne scenarije, kot so posodobitve v realnem času, veriženje orodij in robustno obvladovanje napak.

## Ključne točke

- **Arhitektura**: MCP uporablja arhitekturo odjemalec-strežnik, kjer gostitelji upravljajo več povezav odjemalcev s strežniki  
- **Udeleženci**: Ekosistem vključuje gostitelje (AI aplikacije), odjemalce (povezovalnike protokola) in strežnike (ponudnike zmogljivosti)  
- **Transportni mehanizmi**: Komunikacija podpira STDIO (lokalno) in Streamable HTTP z opcijskim SSE (oddaljeno)  
- **Osnovne funkcije**: Strežniki izpostavljajo orodja (izvedljive funkcije), vire (podatkovne vire) in pozive (predloge)  
- **Osnovne funkcije odjemalca**: Strežniki lahko zahtevajo vzorčenje (LLM dokončanja), pridobivanje vnosa (uporabniški vnos) in beleženje od odjemalcev  
- **Osnova protokola**: Zgrajen na JSON-RPC 2.0 z datumsko različico (trenutna: 2025-06-18)  
- **Zmožnosti v realnem času**: Podpira obvestila za dinamične posodobitve in sinhronizacijo v realnem času  
- **Varnost na prvem mestu**: Izrecno soglasje uporabnika, zaščita zasebnosti podatkov in varen transport so osnovne zahteve  

## Vaja

Oblikujte preprosto MCP orodje, ki bi bilo uporabno na vašem področju. Določite:  
1. Kako bi se orodje imenovalo  
2. Katere parametre bi sprejemalo  
3. Kakšen izhod bi vračalo  
4. Kako bi model lahko uporabil to orodje za reševanje uporabniških težav  

---

## Kaj sledi

Naprej: [Poglavje 2: Varnost](../02-Security/README.md)

**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovno človeško prevajanje. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.