<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T22:30:39+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "ro"
}
-->
# 📖 MCP Core Concepts: Stăpânirea Model Context Protocol pentru integrarea AI

Model Context Protocol (MCP) este un cadru standardizat și puternic care optimizează comunicarea între Modelele Mari de Limbaj (LLM-uri) și unelte, aplicații și surse externe de date. Acest ghid optimizat SEO te va conduce prin conceptele de bază ale MCP, asigurându-te că înțelegi arhitectura client-server, componentele esențiale, mecanismele de comunicare și bunele practici de implementare.

## Prezentare generală

Această lecție explorează arhitectura fundamentală și componentele care formează ecosistemul Model Context Protocol (MCP). Vei învăța despre arhitectura client-server, componentele cheie și mecanismele de comunicare care alimentează interacțiunile MCP.

## 👩‍🎓 Obiective cheie de învățare

La finalul acestei lecții, vei:

- Înțelege arhitectura client-server MCP.
- Identifica rolurile și responsabilitățile Host-urilor, Client-ilor și Server-elor.
- Analiza caracteristicile principale care fac MCP un strat flexibil de integrare.
- Înțelege fluxul informațiilor în ecosistemul MCP.
- Obține perspective practice prin exemple de cod în .NET, Java, Python și JavaScript.

## 🔎 Arhitectura MCP: O privire mai detaliată

Ecosistemul MCP este construit pe un model client-server. Această structură modulară permite aplicațiilor AI să interacționeze eficient cu unelte, baze de date, API-uri și resurse contextuale. Hai să descompunem această arhitectură în componentele sale esențiale.

### 1. Hosts

În Model Context Protocol (MCP), Host-urile joacă un rol crucial ca interfața principală prin care utilizatorii interacționează cu protocolul. Host-urile sunt aplicații sau medii care inițiază conexiuni cu serverele MCP pentru a accesa date, unelte și prompturi. Exemple de Host-uri includ medii integrate de dezvoltare (IDE-uri) precum Visual Studio Code, unelte AI precum Claude Desktop sau agenți personalizați creați pentru sarcini specifice.

**Host-urile** sunt aplicații LLM care inițiază conexiuni. Ele:

- Execută sau interacționează cu modelele AI pentru a genera răspunsuri.
- Inițiază conexiuni cu serverele MCP.
- Gestionează fluxul conversației și interfața cu utilizatorul.
- Controlează permisiunile și restricțiile de securitate.
- Se ocupă de consimțământul utilizatorului pentru partajarea datelor și executarea uneltelor.

### 2. Clients

Client-ii sunt componente esențiale care facilitează interacțiunea între Host-uri și serverele MCP. Client-ii acționează ca intermediari, permițând Host-urilor să acceseze și să utilizeze funcționalitățile oferite de serverele MCP. Ei joacă un rol important în asigurarea unei comunicări fluide și schimbului eficient de date în cadrul arhitecturii MCP.

**Client-ii** sunt conectori în cadrul aplicației host. Ei:

- Trimit cereri către servere cu prompturi/instrucțiuni.
- Negociază capabilitățile cu serverele.
- Gestionează cererile de executare a uneltelor din partea modelelor.
- Procesează și afișează răspunsurile către utilizatori.

### 3. Servers

Server-ele sunt responsabile pentru gestionarea cererilor venite de la client-ii MCP și oferirea răspunsurilor adecvate. Ele administrează diverse operațiuni precum recuperarea datelor, executarea uneltelor și generarea de prompturi. Server-ele asigură că comunicarea între client și Host este eficientă și fiabilă, menținând integritatea procesului de interacțiune.

**Server-ele** sunt servicii care oferă context și capabilități. Ele:

- Înregistrează funcționalitățile disponibile (resurse, prompturi, unelte).
- Primesc și execută apeluri către unelte din partea clientului.
- Oferă informații contextuale pentru a îmbunătăți răspunsurile modelului.
- Returnează rezultatele înapoi către client.
- Mențin starea pe parcursul interacțiunilor când este necesar.

Server-ele pot fi dezvoltate de oricine pentru a extinde capabilitățile modelului cu funcționalități specializate.

### 4. Server Features

Server-ele din Model Context Protocol (MCP) oferă blocuri fundamentale care permit interacțiuni complexe între client, host și modelele de limbaj. Aceste funcționalități sunt concepute pentru a îmbunătăți capabilitățile MCP prin oferirea de context structurat, unelte și prompturi.

Server-ele MCP pot oferi oricare dintre următoarele funcții:

#### 📑 Resurse

Resursele în Model Context Protocol (MCP) cuprind diverse tipuri de context și date care pot fi utilizate de utilizatori sau modele AI. Acestea includ:

- **Date contextuale**: Informații și context pe care utilizatorii sau modelele AI le pot folosi pentru luarea deciziilor și executarea sarcinilor.
- **Baze de cunoștințe și depozite de documente**: Colecții de date structurate și nestructurate, precum articole, manuale și lucrări de cercetare, care oferă informații valoroase.
- **Fișiere locale și baze de date**: Date stocate local pe dispozitive sau în baze de date, accesibile pentru procesare și analiză.
- **API-uri și servicii web**: Interfețe externe și servicii care oferă date și funcționalități suplimentare, permițând integrarea cu diverse resurse și unelte online.

Un exemplu de resursă poate fi un schelet de bază de date sau un fișier accesibil astfel:

```text
file://log.txt
database://schema
```

### 🤖 Prompturi

Prompturile în Model Context Protocol (MCP) includ diverse șabloane predefinite și modele de interacțiune concepute pentru a eficientiza fluxurile de lucru ale utilizatorilor și a îmbunătăți comunicarea. Acestea includ:

- **Mesaje și fluxuri de lucru șablonate**: Mesaje și procese pre-structurate care ghidează utilizatorii prin sarcini și interacțiuni specifice.
- **Modele predefinite de interacțiune**: Secvențe standardizate de acțiuni și răspunsuri care facilitează o comunicare consecventă și eficientă.
- **Șabloane specializate pentru conversații**: Șabloane personalizabile adaptate pentru tipuri specifice de conversații, asigurând interacțiuni relevante și contextuale.

Un șablon de prompt poate arăta astfel:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Unelte

Uneltele în Model Context Protocol (MCP) sunt funcții pe care modelul AI le poate executa pentru a îndeplini sarcini specifice. Aceste unelte sunt concepute pentru a extinde capabilitățile modelului AI prin oferirea de operațiuni structurate și fiabile. Aspectele cheie includ:

- **Funcții pe care modelul AI le poate executa**: Uneltele sunt funcții executabile pe care modelul AI le poate invoca pentru a realiza diverse sarcini.
- **Nume și descriere unice**: Fiecare unealtă are un nume distinct și o descriere detaliată care explică scopul și funcționalitatea acesteia.
- **Parametri și rezultate**: Uneltele acceptă parametri specifici și returnează rezultate structurate, asigurând rezultate consistente și previzibile.
- **Funcții discrete**: Uneltele efectuează funcții separate precum căutări pe web, calcule sau interogări în baze de date.

Un exemplu de unealtă ar putea arăta astfel:

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

## Funcții Client

În Model Context Protocol (MCP), client-ii oferă mai multe funcții cheie serverelor, îmbunătățind funcționalitatea și interacțiunea generală în cadrul protocolului. Una dintre funcțiile notabile este Sampling.

### 👉 Sampling

- **Comportamente agentice inițiate de server**: Client-ii permit serverelor să inițieze acțiuni sau comportamente autonome specifice, sporind capabilitățile dinamice ale sistemului.
- **Interacțiuni recursive cu LLM-uri**: Această funcție permite interacțiuni recursive cu modelele mari de limbaj, facilitând procesarea mai complexă și iterativă a sarcinilor.
- **Solicitarea de completări suplimentare ale modelului**: Server-ele pot solicita completări suplimentare de la model, asigurând răspunsuri detaliate și contextuale.

## Fluxul informației în MCP

Model Context Protocol (MCP) definește un flux structurat al informației între host-uri, client-i, server-e și modele. Înțelegerea acestui flux ajută la clarificarea modului în care sunt procesate cererile utilizatorilor și cum sunt integrate uneltele și datele externe în răspunsurile modelului.

- **Host-ul inițiază conexiunea**  
  Aplicația host (cum ar fi un IDE sau o interfață de chat) stabilește o conexiune cu un server MCP, de obicei prin STDIO, WebSocket sau un alt transport suportat.

- **Negocierea capabilităților**  
  Client-ul (încorporat în host) și server-ul schimbă informații despre funcționalitățile, uneltele, resursele și versiunile protocolului suportate. Aceasta asigură că ambele părți înțeleg ce capabilități sunt disponibile pentru sesiune.

- **Cererea utilizatorului**  
  Utilizatorul interacționează cu host-ul (de exemplu, introduce un prompt sau o comandă). Host-ul colectează această intrare și o transmite clientului pentru procesare.

- **Utilizarea resurselor sau uneltelor**  
  - Client-ul poate solicita context suplimentar sau resurse de la server (cum ar fi fișiere, înregistrări din baze de date sau articole din baze de cunoștințe) pentru a îmbogăți înțelegerea modelului.
  - Dacă modelul determină că este necesară o unealtă (de exemplu, pentru a prelua date, a efectua un calcul sau a apela un API), client-ul trimite o cerere de invocare a uneltei către server, specificând numele uneltei și parametrii.

- **Executarea pe server**  
  Server-ul primește cererea de resurse sau unealtă, execută operațiunile necesare (cum ar fi rularea unei funcții, interogarea unei baze de date sau recuperarea unui fișier) și returnează rezultatele către client într-un format structurat.

- **Generarea răspunsului**  
  Client-ul integrează răspunsurile server-ului (date de resurse, rezultate ale uneltelor etc.) în interacțiunea continuă cu modelul. Modelul folosește aceste informații pentru a genera un răspuns cuprinzător și relevant din punct de vedere contextual.

- **Prezentarea rezultatului**  
  Host-ul primește rezultatul final de la client și îl afișează utilizatorului, incluzând adesea atât textul generat de model, cât și orice rezultate provenite din execuția uneltelor sau căutări de resurse.

Acest flux permite MCP să susțină aplicații AI avansate, interactive și conștiente de context, conectând fără probleme modelele cu unelte și surse externe de date.

## Detalii despre protocol

MCP (Model Context Protocol) este construit peste [JSON-RPC 2.0](https://www.jsonrpc.org/), oferind un format standardizat, independent de limbaj, pentru comunicarea între host-uri, client-i și server-e. Această fundație permite interacțiuni fiabile, structurate și extensibile pe diverse platforme și limbaje de programare.

### Caracteristici cheie ale protocolului

MCP extinde JSON-RPC 2.0 cu convenții suplimentare pentru invocarea uneltelor, accesul la resurse și gestionarea prompturilor. Suportă mai multe straturi de transport (STDIO, WebSocket, SSE) și permite comunicare securizată, extensibilă și independentă de limbaj între componente.

#### 🧢 Protocol de bază

- **Formatul mesajelor JSON-RPC**: Toate cererile și răspunsurile folosesc specificația JSON-RPC 2.0, asigurând o structură consecventă pentru apelurile de metode, parametri, rezultate și gestionarea erorilor.
- **Conexiuni cu stare**: Sesiunile MCP mențin starea pe parcursul mai multor cereri, susținând conversații continue, acumularea de context și gestionarea resurselor.
- **Negocierea capabilităților**: În timpul stabilirii conexiunii, client-ii și server-ele schimbă informații despre funcționalitățile suportate, versiunile protocolului, uneltele și resursele disponibile. Aceasta asigură că ambele părți înțeleg capabilitățile celuilalt și se pot adapta în consecință.

#### ➕ Utilitare suplimentare

Mai jos sunt câteva utilitare și extensii de protocol pe care MCP le oferă pentru a îmbunătăți experiența dezvoltatorilor și a permite scenarii avansate:

- **Opțiuni de configurare**: MCP permite configurarea dinamică a parametrilor sesiunii, cum ar fi permisiunile uneltelor, accesul la resurse și setările modelului, adaptate fiecărei interacțiuni.
- **Urmărirea progresului**: Operațiunile de durată lungă pot raporta actualizări de progres, permițând interfețe responsive și o experiență mai bună pentru utilizator în timpul sarcinilor complexe.
- **Anularea cererilor**: Client-ii pot anula cererile aflate în curs, permițând utilizatorilor să întrerupă operațiuni care nu mai sunt necesare sau durează prea mult.
- **Raportarea erorilor**: Mesaje și coduri de eroare standardizate ajută la diagnosticarea problemelor, gestionarea grațioasă a eșecurilor și oferirea de feedback util utilizatorilor și dezvoltatorilor.
- **Jurnalizare**: Atât client-ii, cât și server-ele pot emite jurnale structurate pentru audit, depanare și monitorizarea interacțiunilor protocolului.

Prin valorificarea acestor caracteristici, MCP asigură o comunicare robustă, sigură și flexibilă între modelele de limbaj și uneltele sau sursele externe de date.

### 🔐 Considerații de securitate

Implementările MCP trebuie să respecte câteva principii cheie de securitate pentru a asigura interacțiuni sigure și de încredere:

- **Consimțământul și controlul utilizatorului**: Utilizatorii trebuie să ofere consimțământ explicit înainte ca orice date să fie accesate sau operațiuni să fie efectuate. Ei trebuie să aibă control clar asupra datelor partajate și acțiunilor autorizate, susținut de interfețe intuitive pentru revizuirea și aprobarea activităților.

- **Confidențialitatea datelor**: Datele utilizatorilor trebuie să fie expuse doar cu consimțământ explicit și protejate prin controale adecvate de acces. Implementările MCP trebuie să prevină transmiterea neautorizată a datelor și să asigure păstrarea confidențialității pe tot parcursul interacțiunilor.

- **Siguranța uneltelor**: Înainte de invocarea oricărei unelte, este necesar consimțământ explicit din partea utilizatorului. Utilizatorii trebuie să înțeleagă clar funcționalitatea fiecărei unelte, iar limitele de securitate robuste trebuie aplicate pentru a preveni execuția neintenționată sau nesigură a uneltelor.

Respectând aceste principii, MCP asigură menținerea încrederii, confidențialității și siguranței utilizatorilor în toate interacțiunile protocolului.

## Exemple de cod: Componente cheie

Mai jos sunt exemple de cod în mai multe limbaje populare care ilustrează cum să implementezi componente cheie ale unui server MCP și unelte.

### Exemplu .NET: Crearea unui server MCP simplu cu unelte

Iată un exemplu practic în .NET care demonstrează cum să implementezi un server MCP simplu cu unelte personalizate. Acest exemplu arată cum să definești și să înregistrezi unelte, să gestionezi cereri și să conectezi server-ul folosind Model Context Protocol.

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

MCP include mai multe concepte și mecan

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea ca urmare a utilizării acestei traduceri.