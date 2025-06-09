<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:47:19+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "ro"
}
-->
# 📖 MCP Core Concepts: Stăpânirea Model Context Protocol pentru Integrarea AI

Model Context Protocol (MCP) este un cadru puternic și standardizat care optimizează comunicarea între Modelele Mari de Limbaj (LLM-uri) și uneltele externe, aplicațiile și sursele de date. Acest ghid optimizat SEO te va parcurge prin conceptele de bază ale MCP, asigurându-te că înțelegi arhitectura client-server, componentele esențiale, mecanismele de comunicare și cele mai bune practici de implementare.

## Prezentare generală

Această lecție explorează arhitectura fundamentală și componentele care alcătuiesc ecosistemul Model Context Protocol (MCP). Vei învăța despre arhitectura client-server, componentele cheie și mecanismele de comunicare care alimentează interacțiunile MCP.

## 👩‍🎓 Obiective cheie de învățare

La finalul acestei lecții, vei:

- Înțelege arhitectura client-server MCP.
- Identifica rolurile și responsabilitățile Hosts, Clients și Servers.
- Analiza caracteristicile de bază care fac din MCP un strat flexibil de integrare.
- Înțelege cum circulă informația în cadrul ecosistemului MCP.
- Obține perspective practice prin exemple de cod în .NET, Java, Python și JavaScript.

## 🔎 Arhitectura MCP: O privire detaliată

Ecosistemul MCP este construit pe un model client-server. Această structură modulară permite aplicațiilor AI să interacționeze eficient cu unelte, baze de date, API-uri și resurse contextuale. Hai să descompunem această arhitectură în componentele sale de bază.

### 1. Hosts

În Model Context Protocol (MCP), Hosts joacă un rol esențial ca interfața principală prin care utilizatorii interacționează cu protocolul. Hosts sunt aplicații sau medii care inițiază conexiuni cu serverele MCP pentru a accesa date, unelte și prompturi. Exemple de Hosts includ medii integrate de dezvoltare (IDE-uri) precum Visual Studio Code, unelte AI ca Claude Desktop sau agenți personalizați creați pentru sarcini specifice.

**Hosts** sunt aplicații LLM care inițiază conexiuni. Ele:

- Execută sau interacționează cu modelele AI pentru a genera răspunsuri.
- Inițiază conexiuni cu serverele MCP.
- Gestionează fluxul conversației și interfața cu utilizatorul.
- Controlează permisiunile și constrângerile de securitate.
- Gestionează consimțământul utilizatorului pentru partajarea datelor și execuția uneltelor.

### 2. Clients

Clients sunt componente esențiale care facilitează interacțiunea între Hosts și serverele MCP. Clients acționează ca intermediari, permițând Hosts să acceseze și să utilizeze funcționalitățile oferite de serverele MCP. Ei joacă un rol crucial în asigurarea unei comunicări fluide și schimb eficient de date în arhitectura MCP.

**Clients** sunt conectori în cadrul aplicației host. Ei:

- Trimit cereri către servere cu prompturi/instrucțiuni.
- Negociază capabilitățile cu serverele.
- Gestionează cererile de execuție a uneltelor venite de la modele.
- Procesează și afișează răspunsurile utilizatorilor.

### 3. Servers

Servers sunt responsabili de gestionarea cererilor venite de la clienții MCP și oferirea răspunsurilor corespunzătoare. Ei administrează diverse operațiuni precum extragerea de date, execuția uneltelor și generarea de prompturi. Servers asigură o comunicare eficientă și fiabilă între clients și Hosts, menținând integritatea procesului de interacțiune.

**Servers** sunt servicii care oferă context și capabilități. Ei:

- Înregistrează funcționalitățile disponibile (resurse, prompturi, unelte).
- Primesc și execută apeluri către unelte de la client.
- Oferă informații contextuale pentru a îmbunătăți răspunsurile modelului.
- Returnează rezultatele către client.
- Mențin starea pe parcursul interacțiunilor, când este necesar.

Servers pot fi dezvoltate de oricine pentru a extinde capabilitățile modelului cu funcționalități specializate.

### 4. Caracteristici ale Serverului

Serverele din Model Context Protocol (MCP) oferă blocuri fundamentale care permit interacțiuni bogate între clients, hosts și modelele de limbaj. Aceste caracteristici sunt concepute pentru a spori capabilitățile MCP prin oferirea de context structurat, unelte și prompturi.

Serverele MCP pot oferi oricare dintre următoarele caracteristici:

#### 📑 Resurse

Resursele în Model Context Protocol (MCP) cuprind diverse tipuri de context și date care pot fi utilizate de utilizatori sau modele AI. Acestea includ:

- **Date contextuale**: Informații și context pe care utilizatorii sau modelele AI le pot folosi pentru luarea deciziilor și executarea sarcinilor.
- **Baze de cunoștințe și depozite de documente**: Colecții de date structurate și nestructurate, cum ar fi articole, manuale și lucrări de cercetare, care oferă informații valoroase.
- **Fișiere locale și baze de date**: Date stocate local pe dispozitive sau în baze de date, accesibile pentru procesare și analiză.
- **API-uri și servicii web**: Interfețe și servicii externe care oferă date și funcționalități suplimentare, permițând integrarea cu diverse resurse și unelte online.

Un exemplu de resursă poate fi un schelet de bază de date sau un fișier accesibil astfel:

```text
file://log.txt
database://schema
```

### 🤖 Prompturi

Prompturile în Model Context Protocol (MCP) includ diverse șabloane predefinite și modele de interacțiune concepute pentru a eficientiza fluxurile de lucru ale utilizatorilor și a îmbunătăți comunicarea. Acestea includ:

- **Mesaje și fluxuri de lucru șablon**: Mesaje și procese pre-structurate care ghidează utilizatorii prin sarcini și interacțiuni specifice.
- **Modele de interacțiune predefinite**: Secvențe standardizate de acțiuni și răspunsuri care facilitează o comunicare consecventă și eficientă.
- **Șabloane specializate de conversație**: Șabloane personalizabile, adaptate pentru tipuri specifice de conversații, asigurând interacțiuni relevante și contextuale.

Un șablon de prompt poate arăta astfel:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Unelte

Uneltele în Model Context Protocol (MCP) sunt funcții pe care modelul AI le poate executa pentru a îndeplini sarcini specifice. Aceste unelte sunt concepute pentru a spori capabilitățile modelului AI prin furnizarea unor operațiuni structurate și de încredere. Aspecte cheie includ:

- **Funcții pe care modelul AI le poate executa**: Uneltele sunt funcții executabile pe care modelul AI le poate invoca pentru a îndeplini diverse sarcini.
- **Nume unic și descriere**: Fiecare unealtă are un nume distinct și o descriere detaliată care explică scopul și funcționalitatea sa.
- **Parametri și rezultate**: Uneltele acceptă parametri specifici și returnează rezultate structurate, asigurând rezultate consecvente și previzibile.
- **Funcții discrete**: Uneltele realizează funcții discrete, cum ar fi căutări web, calcule sau interogări în baze de date.

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

## Caracteristici ale Clientului

În Model Context Protocol (MCP), clients oferă mai multe caracteristici cheie serverelor, sporind funcționalitatea generală și interacțiunea în cadrul protocolului. Una dintre caracteristicile notabile este Sampling.

### 👉 Sampling

- **Comportamente agentice inițiate de server**: Clients permit serverelor să inițieze acțiuni sau comportamente specifice autonom, sporind capabilitățile dinamice ale sistemului.
- **Interacțiuni recursive cu LLM-uri**: Această caracteristică permite interacțiuni recursive cu modelele mari de limbaj (LLM-uri), facilitând procesări mai complexe și iterative ale sarcinilor.
- **Solicitarea de completări suplimentare ale modelului**: Serverele pot cere completări suplimentare de la model, asigurând răspunsuri detaliate și relevante contextual.

## Fluxul informației în MCP

Model Context Protocol (MCP) definește un flux structurat al informației între hosts, clients, servers și modele. Înțelegerea acestui flux ajută la clarificarea modului în care sunt procesate cererile utilizatorilor și cum sunt integrate uneltele externe și datele în răspunsurile modelului.

- **Host inițiază conexiunea**  
  Aplicația host (precum un IDE sau o interfață de chat) stabilește o conexiune către un server MCP, de obicei prin STDIO, WebSocket sau un alt transport suportat.

- **Negocierea capabilităților**  
  Clientul (încorporat în host) și serverul schimbă informații despre funcționalitățile, uneltele, resursele și versiunile protocolului suportate. Acest lucru asigură că ambele părți înțeleg ce capabilități sunt disponibile pentru sesiune.

- **Cererea utilizatorului**  
  Utilizatorul interacționează cu host-ul (de exemplu, introduce un prompt sau o comandă). Host-ul colectează această intrare și o transmite clientului pentru procesare.

- **Utilizarea resurselor sau uneltelor**  
  - Clientul poate solicita context suplimentar sau resurse de la server (cum ar fi fișiere, înregistrări din baze de date sau articole din baze de cunoștințe) pentru a îmbogăți înțelegerea modelului.
  - Dacă modelul decide că este necesară o unealtă (de exemplu, pentru a prelua date, a efectua un calcul sau a apela un API), clientul trimite o cerere de invocare a uneltei către server, specificând numele uneltei și parametrii.

- **Execuția pe server**  
  Serverul primește cererea pentru resurse sau unelte, execută operațiile necesare (cum ar fi rularea unei funcții, interogarea unei baze de date sau recuperarea unui fișier) și returnează rezultatele către client într-un format structurat.

- **Generarea răspunsului**  
  Clientul integrează răspunsurile serverului (datele resursei, rezultatele uneltelor etc.) în interacțiunea curentă cu modelul. Modelul folosește aceste informații pentru a genera un răspuns complet și relevant contextual.

- **Prezentarea rezultatului**  
  Host-ul primește rezultatul final de la client și îl prezintă utilizatorului, adesea incluzând atât textul generat de model, cât și orice rezultate provenite din execuția uneltelor sau interogarea resurselor.

Acest flux permite MCP să susțină aplicații AI avansate, interactive și conștiente de context, conectând fără probleme modelele cu unelte și surse externe de date.

## Detalii Protocol

MCP (Model Context Protocol) este construit peste [JSON-RPC 2.0](https://www.jsonrpc.org/), oferind un format standardizat și independent de limbaj pentru comunicarea între hosts, clients și servers. Această bază permite interacțiuni fiabile, structurate și extensibile pe diverse platforme și limbaje de programare.

### Caracteristici cheie ale protocolului

MCP extinde JSON-RPC 2.0 cu convenții suplimentare pentru invocarea uneltelor, accesul la resurse și gestionarea prompturilor. Suportă multiple straturi de transport (STDIO, WebSocket, SSE) și permite o comunicare securizată, extensibilă și independentă de limbaj între componente.

#### 🧢 Protocol de bază

- **Formatul mesajelor JSON-RPC**: Toate cererile și răspunsurile folosesc specificația JSON-RPC 2.0, asigurând o structură consecventă pentru apeluri de metode, parametri, rezultate și tratarea erorilor.
- **Conexiuni stateful**: Sesiunile MCP mențin starea pe durata mai multor cereri, susținând conversații continue, acumularea contextului și gestionarea resurselor.
- **Negocierea capabilităților**: În timpul stabilirii conexiunii, clients și servers schimbă informații despre funcționalitățile suportate, versiunile protocolului, uneltele și resursele disponibile. Astfel, ambele părți înțeleg capabilitățile celuilalt și se pot adapta.

#### ➕ Utilitare suplimentare

Mai jos sunt câteva utilitare și extensii ale protocolului pe care MCP le oferă pentru a îmbunătăți experiența dezvoltatorilor și a permite scenarii avansate:

- **Opțiuni de configurare**: MCP permite configurarea dinamică a parametrilor sesiunii, cum ar fi permisiunile uneltelor, accesul la resurse și setările modelului, adaptate fiecărei interacțiuni.
- **Monitorizarea progresului**: Operațiunile de durată lungă pot raporta actualizări de progres, permițând interfețe responsive și o experiență mai bună în timpul sarcinilor complexe.
- **Anularea cererilor**: Clients pot anula cererile aflate în curs, permițând utilizatorilor să întrerupă operațiunile care nu mai sunt necesare sau care durează prea mult.
- **Raportarea erorilor**: Mesaje și coduri de eroare standardizate ajută la diagnosticarea problemelor, gestionarea elegantă a eșecurilor și oferirea de feedback util utilizatorilor și dezvoltatorilor.
- **Jurnalizare**: Atât clients, cât și servers pot emite jurnale structurate pentru audit, depanare și monitorizarea interacțiunilor protocolului.

Prin utilizarea acestor caracteristici, MCP asigură o comunicare robustă, sigură și flexibilă între modelele de limbaj și uneltele sau sursele externe de date.

### 🔐 Considerații de securitate

Implementările MCP trebuie să respecte câteva principii cheie de securitate pentru a asigura interacțiuni sigure și de încredere:

- **Consimțământul și controlul utilizatorului**: Utilizatorii trebuie să ofere consimțământ explicit înainte ca orice date să fie accesate sau operațiuni să fie efectuate. Ei trebuie să aibă un control clar asupra datelor partajate și a acțiunilor autorizate, sprijinit de interfețe intuitive pentru revizuirea și aprobarea activităților.

- **Confidențialitatea datelor**: Datele utilizatorilor trebuie expuse doar cu consimțământ explicit și protejate prin controale adecvate de acces. Implementările MCP trebuie să prevină transmiterea neautorizată a datelor și să asigure păstrarea confidențialității în toate interacțiunile.

- **Siguranța uneltelor**: Înainte de invocarea oricărei unelte, este necesar consimțământul explicit al utilizatorului. Utilizatorii trebuie să înțeleagă clar funcționalitatea fiecărei unelte, iar limitele de securitate robuste trebuie aplicate pentru a preveni execuția neintenționată sau nesigură a uneltelor.

Respectând aceste principii, MCP asigură menținerea încrederii, confidențialității și siguranței utilizatorilor în toate interacțiunile protocolului.

## Exemple de cod: Componente cheie

Mai jos sunt exemple de cod în câteva limbaje populare care ilustrează cum să implementezi componente cheie ale serverului MCP și unelte.

### Exemplu .NET: Crearea unui server MCP simplu cu unelte

Iată un exemplu practic în .NET care demonstrează cum să implementezi un server MCP simplu cu unelte personalizate. Acest exemplu arată cum să definești și să înregistrezi unelte, să gestionezi cererile și să conectezi serverul folosind Model Context Protocol.

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

Acest exemplu arată același server MCP și înregistrare a uneltelor ca exemplul .NET de mai sus, dar implementat în Java.

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

În acest exemplu demonstrăm cum să construiești un server MCP în Python. Sunt prezentate două moduri diferite de a crea unelte.

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

1. **Controlul permisiunilor uneltelor**:  
  Clienții pot specifica ce unelte poate folosi un model

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original, în limba sa nativă, trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.