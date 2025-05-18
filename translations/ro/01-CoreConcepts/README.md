<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:34:24+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "ro"
}
-->
# 📖 MCP Core Concepts: Stăpânirea Model Context Protocol pentru Integrarea AI

Model Context Protocol (MCP) este un cadru puternic și standardizat care optimizează comunicarea între Modelele Mari de Limbaj (LLM-uri) și unelte externe, aplicații și surse de date. Acest ghid optimizat pentru SEO te va conduce prin conceptele de bază ale MCP, asigurându-te că înțelegi arhitectura client-server, componentele esențiale, mecanismele de comunicare și bunele practici de implementare.

## Prezentare generală

Această lecție explorează arhitectura fundamentală și componentele care alcătuiesc ecosistemul Model Context Protocol (MCP). Vei învăța despre arhitectura client-server, componentele cheie și mecanismele de comunicare care susțin interacțiunile MCP.

## 👩‍🎓 Obiective cheie de învățare

La finalul acestei lecții, vei putea:

- Înțelege arhitectura client-server a MCP.
- Identifica rolurile și responsabilitățile Hosts, Clients și Servers.
- Analiza caracteristicile principale care fac din MCP un strat flexibil de integrare.
- Înțelege cum circulă informația în cadrul ecosistemului MCP.
- Obține perspective practice prin exemple de cod în .NET, Java, Python și JavaScript.

## 🔎 Arhitectura MCP: O privire mai detaliată

Ecosistemul MCP este construit pe un model client-server. Această structură modulară permite aplicațiilor AI să interacționeze eficient cu unelte, baze de date, API-uri și resurse contextuale. Hai să descompunem această arhitectură în componentele sale de bază.

### 1. Hosts

În Model Context Protocol (MCP), Hosts joacă un rol crucial ca interfața principală prin care utilizatorii interacționează cu protocolul. Hosts sunt aplicații sau medii care inițiază conexiuni cu serverele MCP pentru a accesa date, unelte și prompturi. Exemple de Hosts includ medii integrate de dezvoltare (IDE-uri) precum Visual Studio Code, unelte AI ca Claude Desktop sau agenți personalizați creați pentru sarcini specifice.

**Hosts** sunt aplicații LLM care inițiază conexiuni. Ele:

- Execută sau interacționează cu modelele AI pentru a genera răspunsuri.
- Inițiază conexiuni cu serverele MCP.
- Gestionează fluxul conversației și interfața cu utilizatorul.
- Controlează permisiunile și restricțiile de securitate.
- Gestionează consimțământul utilizatorului pentru partajarea datelor și execuția uneltelor.

### 2. Clients

Clients sunt componente esențiale care facilitează interacțiunea dintre Hosts și serverele MCP. Clients acționează ca intermediari, permițând Hosts să acceseze și să utilizeze funcționalitățile oferite de serverele MCP. Ei joacă un rol important în asigurarea unei comunicări fluide și schimbului eficient de date în arhitectura MCP.

**Clients** sunt conectori în cadrul aplicației host. Ei:

- Trimit cereri către servere cu prompturi/instrucțiuni.
- Negociază capabilitățile cu serverele.
- Gestionează cererile de execuție a uneltelor venite din partea modelelor.
- Procesează și afișează răspunsurile către utilizatori.

### 3. Servers

Servers sunt responsabili de gestionarea cererilor venite de la clienții MCP și de furnizarea răspunsurilor corespunzătoare. Ei administrează diverse operațiuni precum recuperarea de date, execuția uneltelor și generarea prompturilor. Servers asigură o comunicare eficientă și fiabilă între clients și hosts, menținând integritatea procesului de interacțiune.

**Servers** sunt servicii care oferă context și capabilități. Ei:

- Înregistrează funcționalitățile disponibile (resurse, prompturi, unelte)
- Primesc și execută apeluri către unelte din partea clientului
- Oferă informații contextuale pentru a îmbunătăți răspunsurile modelului
- Returnează rezultatele înapoi către client
- Mențin starea pe parcursul interacțiunilor, când este necesar

Servers pot fi dezvoltate de oricine pentru a extinde capabilitățile modelului cu funcționalități specializate.

### 4. Caracteristici ale Serverului

Serverele din Model Context Protocol (MCP) oferă blocuri fundamentale care permit interacțiuni bogate între clients, hosts și modelele de limbaj. Aceste caracteristici sunt concepute pentru a îmbunătăți capabilitățile MCP prin oferirea de context structurat, unelte și prompturi.

Serverele MCP pot oferi oricare dintre următoarele caracteristici:

#### 📑 Resurse

Resursele în Model Context Protocol (MCP) cuprind diverse tipuri de context și date care pot fi utilizate de utilizatori sau modele AI. Acestea includ:

- **Date contextuale**: Informații și context pe care utilizatorii sau modelele AI le pot folosi pentru luarea deciziilor și executarea sarcinilor.
- **Baze de cunoștințe și depozite de documente**: Colecții de date structurate și nestructurate, precum articole, manuale și lucrări de cercetare, care oferă informații valoroase.
- **Fișiere locale și baze de date**: Date stocate local pe dispozitive sau în baze de date, accesibile pentru procesare și analiză.
- **API-uri și servicii web**: Interfețe și servicii externe care oferă date și funcționalități suplimentare, facilitând integrarea cu diverse resurse și unelte online.

Un exemplu de resursă poate fi un schelet de bază de date sau un fișier accesat astfel:

```text
file://log.txt
database://schema
```

### 🤖 Prompturi

Prompturile în Model Context Protocol (MCP) includ diverse șabloane predefinite și modele de interacțiune concepute pentru a simplifica fluxurile de lucru ale utilizatorilor și a îmbunătăți comunicarea. Acestea includ:

- **Mesaje și fluxuri de lucru șablonate**: Mesaje și procese pre-structurate care ghidează utilizatorii prin sarcini și interacțiuni specifice.
- **Modele predefinite de interacțiune**: Secvențe standardizate de acțiuni și răspunsuri care facilitează o comunicare consistentă și eficientă.
- **Șabloane specializate pentru conversații**: Șabloane personalizabile pentru tipuri specifice de conversații, asigurând interacțiuni relevante și contextuale.

Un șablon de prompt poate arăta astfel:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Unelte

Uneltele în Model Context Protocol (MCP) sunt funcții pe care modelul AI le poate executa pentru a îndeplini sarcini specifice. Aceste unelte sunt concepute pentru a extinde capabilitățile modelului AI prin oferirea de operațiuni structurate și fiabile. Aspectele cheie includ:

- **Funcții pentru modelul AI de executat**: Uneltele sunt funcții executabile pe care modelul AI le poate invoca pentru a realiza diverse sarcini.
- **Nume și descriere unice**: Fiecare unealtă are un nume distinct și o descriere detaliată care explică scopul și funcționalitatea sa.
- **Parametri și rezultate**: Uneltele acceptă parametri specifici și returnează rezultate structurate, asigurând rezultate consistente și previzibile.
- **Funcții discrete**: Uneltele realizează funcții discrete, precum căutări web, calcule sau interogări în baze de date.

Un exemplu de unealtă ar putea arăta astfel:

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

## Caracteristici ale Clientului

În Model Context Protocol (MCP), clients oferă mai multe caracteristici cheie serverelor, îmbunătățind funcționalitatea generală și interacțiunea în cadrul protocolului. Una dintre caracteristicile notabile este Sampling.

### 👉 Sampling

- **Comportamente agentice inițiate de server**: Clients permit serverelor să inițieze acțiuni sau comportamente specifice autonom, sporind capabilitățile dinamice ale sistemului.
- **Interacțiuni recursive cu LLM-uri**: Această caracteristică permite interacțiuni recursive cu modelele mari de limbaj (LLM-uri), facilitând procesări mai complexe și iterative ale sarcinilor.
- **Solicitarea completărilor suplimentare ale modelului**: Serverele pot solicita completări adiționale de la model, asigurând răspunsuri detaliate și relevante contextual.

## Fluxul informației în MCP

Model Context Protocol (MCP) definește un flux structurat de informații între hosts, clients, servers și modele. Înțelegerea acestui flux ajută la clarificarea modului în care cererile utilizatorilor sunt procesate și cum uneltele externe și datele sunt integrate în răspunsurile modelului.

- **Host inițiază conexiunea**  
  Aplicația host (cum ar fi un IDE sau o interfață de chat) stabilește o conexiune către un server MCP, de obicei prin STDIO, WebSocket sau un alt transport suportat.

- **Negocierea capabilităților**  
  Clientul (încorporat în host) și serverul schimbă informații despre funcționalitățile, uneltele, resursele și versiunile protocolului suportate. Acest lucru asigură că ambele părți înțeleg ce capabilități sunt disponibile pentru sesiune.

- **Cererea utilizatorului**  
  Utilizatorul interacționează cu host-ul (ex. introduce un prompt sau o comandă). Host-ul colectează această intrare și o transmite clientului pentru procesare.

- **Utilizarea resurselor sau uneltelor**  
  - Clientul poate solicita context sau resurse suplimentare de la server (cum ar fi fișiere, înregistrări din baze de date sau articole din baze de cunoștințe) pentru a îmbogăți înțelegerea modelului.
  - Dacă modelul decide că este necesară o unealtă (ex. pentru a prelua date, efectua un calcul sau apela un API), clientul trimite o cerere de invocare a uneltei către server, specificând numele uneltei și parametrii.

- **Execuția serverului**  
  Serverul primește cererea pentru resursă sau unealtă, execută operațiunile necesare (ex. rulează o funcție, interoghează o bază de date sau recuperează un fișier) și returnează rezultatele către client într-un format structurat.

- **Generarea răspunsului**  
  Clientul integrează răspunsurile serverului (date de resurse, rezultate ale uneltelor etc.) în interacțiunea curentă cu modelul. Modelul folosește aceste informații pentru a genera un răspuns complet și relevant contextual.

- **Prezentarea rezultatului**  
  Host-ul primește rezultatul final de la client și îl afișează utilizatorului, incluzând adesea atât textul generat de model, cât și orice rezultate ale execuțiilor uneltelor sau căutărilor de resurse.

Acest flux permite MCP să susțină aplicații AI avansate, interactive și conștiente de context, conectând fără întreruperi modelele cu unelte externe și surse de date.

## Detalii despre protocol

MCP (Model Context Protocol) este construit peste [JSON-RPC 2.0](https://www.jsonrpc.org/), oferind un format standardizat și independent de limbaj pentru comunicarea între hosts, clients și servers. Această fundație permite interacțiuni fiabile, structurate și extensibile pe diverse platforme și limbaje de programare.

### Caracteristici cheie ale protocolului

MCP extinde JSON-RPC 2.0 cu convenții suplimentare pentru invocarea uneltelor, accesul la resurse și gestionarea prompturilor. Suportă mai multe straturi de transport (STDIO, WebSocket, SSE) și permite o comunicare sigură, extensibilă și independentă de limbaj între componente.

#### 🧢 Protocol de bază

- **Formatul mesajelor JSON-RPC**: Toate cererile și răspunsurile folosesc specificația JSON-RPC 2.0, asigurând o structură consistentă pentru apeluri de metode, parametri, rezultate și gestionarea erorilor.
- **Conexiuni cu stare**: Sesiunile MCP mențin starea pe parcursul mai multor cereri, susținând conversații continue, acumularea contextului și gestionarea resurselor.
- **Negocierea capabilităților**: În timpul configurării conexiunii, clients și servers schimbă informații despre funcționalitățile suportate, versiunile protocolului, uneltele și resursele disponibile. Acest lucru asigură că ambele părți înțeleg capabilitățile celuilalt și pot adapta corespunzător.

#### ➕ Utilitare suplimentare

Mai jos sunt câteva utilitare și extensii de protocol pe care MCP le oferă pentru a îmbunătăți experiența dezvoltatorului și a permite scenarii avansate:

- **Opțiuni de configurare**: MCP permite configurarea dinamică a parametrilor sesiunii, cum ar fi permisiunile uneltelor, accesul la resurse și setările modelului, adaptate fiecărei interacțiuni.
- **Monitorizarea progresului**: Operațiunile de durată pot raporta actualizări de progres, facilitând interfețe responsabile și o experiență mai bună pentru utilizator în timpul sarcinilor complexe.
- **Anularea cererilor**: Clients pot anula cereri aflate în desfășurare, permițând utilizatorilor să întrerupă operațiuni care nu mai sunt necesare sau durează prea mult.
- **Raportarea erorilor**: Mesajele și codurile de eroare standardizate ajută la diagnosticarea problemelor, gestionarea elegantă a eșecurilor și oferă feedback util utilizatorilor și dezvoltatorilor.
- **Logare**: Atât clients, cât și servers pot emite jurnale structurate pentru audit, depanare și monitorizarea interacțiunilor protocolului.

Prin valorificarea acestor caracteristici, MCP asigură o comunicare robustă, sigură și flexibilă între modelele de limbaj și uneltele sau sursele de date externe.

### 🔐 Considerații de securitate

Implementările MCP ar trebui să respecte câteva principii cheie de securitate pentru a asigura interacțiuni sigure și de încredere:

- **Consimțământul și controlul utilizatorului**: Utilizatorii trebuie să ofere consimțământ explicit înainte ca orice date să fie accesate sau operațiuni să fie efectuate. Ei trebuie să aibă control clar asupra datelor partajate și a acțiunilor autorizate, sprijiniți de interfețe intuitive pentru revizuirea și aprobarea activităților.

- **Confidențialitatea datelor**: Datele utilizatorilor trebuie expuse doar cu consimțământ explicit și protejate prin controale adecvate de acces. Implementările MCP trebuie să prevină transmiterea neautorizată a datelor și să asigure păstrarea confidențialității în toate interacțiunile.

- **Siguranța uneltelor**: Înainte de a invoca orice unealtă, este necesar consimțământul explicit al utilizatorului. Utilizatorii trebuie să înțeleagă clar funcționalitatea fiecărei unelte, iar limite de securitate robuste trebuie aplicate pentru a preveni execuția neintenționată sau nesigură a uneltelor.

Respectând aceste principii, MCP asigură că încrederea, confidențialitatea și siguranța utilizatorilor sunt menținute pe tot parcursul interacțiunilor protocolului.

## Exemple de cod: Componente cheie

Mai jos sunt exemple de cod în mai multe limbaje populare care ilustrează cum să implementezi componente cheie ale unui server MCP și unelte.

### Exemplu .NET: Crearea unui server MCP simplu cu unelte

Iată un exemplu practic în .NET care demonstrează cum să implementezi un server MCP simplu cu unelte personalizate. Exemplul arată cum să definești și să înregistrezi unelte, să gestionezi cererile și să conectezi serverul folosind Model Context Protocol.

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

### Exemplu Java: Componente server MCP

Acest exemplu demonstrează același server MCP și înregistrarea uneltelor ca în exemplul .NET de mai sus, dar implementat în Java.

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

### Exemplu Python: Construirea unui server MCP

În acest exemplu arătăm cum să construiești un server MCP în Python. Sunt prezentate două moduri diferite de a crea unelte.

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

### Exemplu JavaScript: Crearea unui server MCP

Acest exemplu arată crearea unui server MCP în JavaScript și cum să înregistrezi două unelte legate de vreme.

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

Acest exemplu JavaScript demonstrează cum să creezi un client MCP care se conectează la un server, trimite un prompt și procesează răspunsul, inclusiv orice apeluri către unelte care au fost făcute.

## Securitate și autorizare

MCP include mai multe concepte și mecanisme integrate pentru gestionarea securității și autorizării pe parcursul protocolului:

1. **Controlul permisiunilor pentru unelte**  
  Clients pot specifica ce unelte poate folosi un model în timpul unei

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.