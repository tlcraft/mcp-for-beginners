<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:34:55+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "it"
}
-->
# 📖 Concetti Core MCP: Padroneggiare il Protocollo del Contesto del Modello per l'Integrazione AI

Il Protocollo del Contesto del Modello (MCP) è un potente framework standardizzato che ottimizza la comunicazione tra i Modelli di Linguaggio di Grandi Dimensioni (LLM) e strumenti, applicazioni e fonti di dati esterni. Questa guida ottimizzata per SEO ti guiderà attraverso i concetti fondamentali di MCP, assicurandoti di comprendere la sua architettura client-server, i componenti essenziali, le meccaniche di comunicazione e le migliori pratiche di implementazione.

## Panoramica

Questa lezione esplora l'architettura fondamentale e i componenti che costituiscono l'ecosistema del Protocollo del Contesto del Modello (MCP). Imparerai l'architettura client-server, i componenti chiave e i meccanismi di comunicazione che alimentano le interazioni MCP.

## 👩‍🎓 Obiettivi Chiave di Apprendimento

Alla fine di questa lezione, sarai in grado di:

- Comprendere l'architettura client-server MCP.
- Identificare ruoli e responsabilità di Host, Client e Server.
- Analizzare le caratteristiche principali che rendono MCP uno strato di integrazione flessibile.
- Imparare come l'informazione fluisce all'interno dell'ecosistema MCP.
- Acquisire intuizioni pratiche attraverso esempi di codice in .NET, Java, Python e JavaScript.

## 🔎 Architettura MCP: Uno Sguardo Approfondito

L'ecosistema MCP è costruito su un modello client-server. Questa struttura modulare consente alle applicazioni AI di interagire con strumenti, database, API e risorse contestuali in modo efficiente. Scomponiamo questa architettura nei suoi componenti principali.

### 1. Host

Nel Protocollo del Contesto del Modello (MCP), gli Host giocano un ruolo cruciale come interfaccia principale attraverso cui gli utenti interagiscono con il protocollo. Gli Host sono applicazioni o ambienti che avviano connessioni con server MCP per accedere a dati, strumenti e prompt. Esempi di Host includono ambienti di sviluppo integrati (IDE) come Visual Studio Code, strumenti AI come Claude Desktop, o agenti personalizzati progettati per compiti specifici.

**Host** sono applicazioni LLM che avviano connessioni. Essi:

- Eseguono o interagiscono con modelli AI per generare risposte.
- Avviano connessioni con server MCP.
- Gestiscono il flusso della conversazione e l'interfaccia utente.
- Controllano permessi e vincoli di sicurezza.
- Gestiscono il consenso dell'utente per la condivisione dei dati e l'esecuzione degli strumenti.

### 2. Client

I Client sono componenti essenziali che facilitano l'interazione tra Host e server MCP. I Client agiscono come intermediari, consentendo agli Host di accedere e utilizzare le funzionalità fornite dai server MCP. Essi giocano un ruolo cruciale nell'assicurare una comunicazione fluida e uno scambio di dati efficiente all'interno dell'architettura MCP.

**Client** sono connettori all'interno dell'applicazione host. Essi:

- Inviamo richieste ai server con prompt/istruzioni.
- Negoziano capacità con i server.
- Gestiscono richieste di esecuzione di strumenti dai modelli.
- Processano e visualizzano risposte agli utenti.

### 3. Server

I Server sono responsabili della gestione delle richieste dei client MCP e della fornitura di risposte appropriate. Gestiscono varie operazioni come il recupero dei dati, l'esecuzione degli strumenti e la generazione dei prompt. I Server assicurano che la comunicazione tra client e Host sia efficiente e affidabile, mantenendo l'integrità del processo di interazione.

**Server** sono servizi che forniscono contesto e capacità. Essi:

- Registrano le funzionalità disponibili (risorse, prompt, strumenti)
- Ricevono ed eseguono chiamate di strumenti dal client
- Forniscono informazioni contestuali per migliorare le risposte del modello
- Restituiscono output al client
- Mantengono lo stato tra le interazioni quando necessario

I Server possono essere sviluppati da chiunque per estendere le capacità del modello con funzionalità specializzate.

### 4. Funzionalità del Server

I Server nel Protocollo del Contesto del Modello (MCP) forniscono blocchi fondamentali che abilitano interazioni ricche tra client, host e modelli di linguaggio. Queste funzionalità sono progettate per migliorare le capacità di MCP offrendo contesto strutturato, strumenti e prompt.

I server MCP possono offrire qualsiasi delle seguenti funzionalità:

#### 📑 Risorse

Le risorse nel Protocollo del Contesto del Modello (MCP) comprendono vari tipi di contesto e dati che possono essere utilizzati dagli utenti o dai modelli AI. Questi includono:

- **Dati Contestuali**: Informazioni e contesto che gli utenti o i modelli AI possono sfruttare per prendere decisioni e eseguire compiti.
- **Basi di Conoscenza e Repositori di Documenti**: Collezioni di dati strutturati e non strutturati, come articoli, manuali e documenti di ricerca, che forniscono preziose intuizioni e informazioni.
- **File Locali e Database**: Dati archiviati localmente su dispositivi o all'interno di database, accessibili per elaborazione e analisi.
- **API e Servizi Web**: Interfacce e servizi esterni che offrono dati e funzionalità aggiuntive, consentendo l'integrazione con varie risorse e strumenti online.

Un esempio di risorsa può essere uno schema di database o un file che può essere accessibile come segue:

```text
file://log.txt
database://schema
```

### 🤖 Prompt

I prompt nel Protocollo del Contesto del Modello (MCP) includono vari modelli predefiniti e schemi di interazione progettati per semplificare i flussi di lavoro degli utenti e migliorare la comunicazione. Questi includono:

- **Messaggi e Flussi di Lavoro Modellati**: Messaggi e processi pre-strutturati che guidano gli utenti attraverso compiti e interazioni specifici.
- **Schemi di Interazione Pre-definiti**: Sequenze standardizzate di azioni e risposte che facilitano una comunicazione coerente ed efficiente.
- **Modelli di Conversazione Specializzati**: Modelli personalizzabili progettati per tipi specifici di conversazioni, assicurando interazioni pertinenti e contestualmente appropriate.

Un modello di prompt può apparire come segue:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Strumenti

Gli strumenti nel Protocollo del Contesto del Modello (MCP) sono funzioni che il modello AI può eseguire per svolgere compiti specifici. Questi strumenti sono progettati per migliorare le capacità del modello AI fornendo operazioni strutturate e affidabili. Gli aspetti chiave includono:

- **Funzioni che il Modello AI Può Eseguire**: Gli strumenti sono funzioni eseguibili che il modello AI può invocare per svolgere vari compiti.
- **Nome Unico e Descrizione**: Ogni strumento ha un nome distinto e una descrizione dettagliata che spiega il suo scopo e funzionalità.
- **Parametri e Output**: Gli strumenti accettano parametri specifici e restituiscono output strutturati, garantendo risultati coerenti e prevedibili.
- **Funzioni Discrete**: Gli strumenti eseguono funzioni discrete come ricerche web, calcoli e interrogazioni di database.

Un esempio di strumento potrebbe apparire come segue:

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

## Funzionalità del Client

Nel Protocollo del Contesto del Modello (MCP), i client offrono diverse funzionalità chiave ai server, migliorando la funzionalità complessiva e l'interazione all'interno del protocollo. Una delle caratteristiche notevoli è il Campionamento.

### 👉 Campionamento

- **Comportamenti Agentici Iniziati dal Server**: I client consentono ai server di avviare azioni o comportamenti specifici autonomamente, migliorando le capacità dinamiche del sistema.
- **Interazioni Ricorsive LLM**: Questa funzionalità consente interazioni ricorsive con modelli di linguaggio di grandi dimensioni (LLM), abilitando una elaborazione più complessa e iterativa dei compiti.
- **Richiesta di Completamenti Aggiuntivi del Modello**: I server possono richiedere completamenti aggiuntivi dal modello, assicurando che le risposte siano complete e contestualmente pertinenti.

## Flusso di Informazioni in MCP

Il Protocollo del Contesto del Modello (MCP) definisce un flusso strutturato di informazioni tra host, client, server e modelli. Comprendere questo flusso aiuta a chiarire come le richieste degli utenti vengono elaborate e come gli strumenti e i dati esterni sono integrati nelle risposte del modello.

- **Host Inizia Connessione**  
  L'applicazione host (come un IDE o un'interfaccia chat) stabilisce una connessione a un server MCP, tipicamente tramite STDIO, WebSocket, o un altro trasporto supportato.

- **Negoziazione delle Capacità**  
  Il client (incorporato nell'host) e il server scambiano informazioni sulle loro funzionalità supportate, strumenti, risorse e versioni del protocollo. Questo assicura che entrambe le parti comprendano quali capacità sono disponibili per la sessione.

- **Richiesta Utente**  
  L'utente interagisce con l'host (ad esempio, inserisce un prompt o un comando). L'host raccoglie questo input e lo passa al client per l'elaborazione.

- **Uso di Risorse o Strumenti**  
  - Il client può richiedere al server contesto o risorse aggiuntive (come file, voci di database o articoli di basi di conoscenza) per arricchire la comprensione del modello.
  - Se il modello determina che è necessario uno strumento (ad esempio, per recuperare dati, eseguire un calcolo o chiamare un'API), il client invia una richiesta di invocazione dello strumento al server, specificando il nome dello strumento e i parametri.

- **Esecuzione del Server**  
  Il server riceve la richiesta di risorsa o strumento, esegue le operazioni necessarie (come eseguire una funzione, interrogare un database o recuperare un file), e restituisce i risultati al client in un formato strutturato.

- **Generazione della Risposta**  
  Il client integra le risposte del server (dati delle risorse, output degli strumenti, ecc.) nell'interazione del modello in corso. Il modello utilizza queste informazioni per generare una risposta completa e contestualmente pertinente.

- **Presentazione del Risultato**  
  L'host riceve l'output finale dal client e lo presenta all'utente, spesso includendo sia il testo generato dal modello che eventuali risultati delle esecuzioni degli strumenti o delle ricerche di risorse.

Questo flusso consente a MCP di supportare applicazioni AI avanzate, interattive e consapevoli del contesto, collegando senza soluzione di continuità modelli con strumenti e fonti di dati esterni.

## Dettagli del Protocollo

MCP (Model Context Protocol) è costruito sopra [JSON-RPC 2.0](https://www.jsonrpc.org/), fornendo un formato di messaggio standardizzato e indipendente dal linguaggio per la comunicazione tra host, client e server. Questa base consente interazioni affidabili, strutturate ed estensibili attraverso piattaforme e linguaggi di programmazione diversi.

### Caratteristiche Chiave del Protocollo

MCP estende JSON-RPC 2.0 con convenzioni aggiuntive per l'invocazione di strumenti, l'accesso alle risorse e la gestione dei prompt. Supporta più livelli di trasporto (STDIO, WebSocket, SSE) e abilita una comunicazione sicura, estensibile e indipendente dal linguaggio tra i componenti.

#### 🧢 Protocollo Base

- **Formato di Messaggio JSON-RPC**: Tutte le richieste e risposte utilizzano la specifica JSON-RPC 2.0, garantendo una struttura coerente per chiamate di metodo, parametri, risultati e gestione degli errori.
- **Connessioni Stateful**: Le sessioni MCP mantengono lo stato attraverso richieste multiple, supportando conversazioni in corso, accumulo di contesto e gestione delle risorse.
- **Negoziazione delle Capacità**: Durante la configurazione della connessione, client e server scambiano informazioni sulle funzionalità supportate, versioni del protocollo, strumenti disponibili e risorse. Questo assicura che entrambe le parti comprendano le capacità dell'altra e possano adattarsi di conseguenza.

#### ➕ Utilità Aggiuntive

Di seguito sono riportate alcune utilità aggiuntive ed estensioni del protocollo che MCP fornisce per migliorare l'esperienza dello sviluppatore e abilitare scenari avanzati:

- **Opzioni di Configurazione**: MCP consente la configurazione dinamica dei parametri di sessione, come permessi degli strumenti, accesso alle risorse e impostazioni del modello, personalizzate per ogni interazione.
- **Tracciamento del Progresso**: Le operazioni di lunga durata possono riportare aggiornamenti sul progresso, abilitando interfacce utente reattive e una migliore esperienza utente durante compiti complessi.
- **Cancellazione della Richiesta**: I client possono cancellare richieste in corso, consentendo agli utenti di interrompere operazioni che non sono più necessarie o che richiedono troppo tempo.
- **Segnalazione degli Errori**: Messaggi di errore e codici standardizzati aiutano a diagnosticare problemi, gestire i fallimenti in modo elegante e fornire feedback attuabili agli utenti e agli sviluppatori.
- **Registrazione**: Sia i client che i server possono emettere registri strutturati per auditing, debug e monitoraggio delle interazioni del protocollo.

Sfruttando queste caratteristiche del protocollo, MCP garantisce una comunicazione robusta, sicura e flessibile tra modelli di linguaggio e strumenti o fonti di dati esterni.

### 🔐 Considerazioni sulla Sicurezza

Le implementazioni MCP devono aderire a diversi principi chiave di sicurezza per garantire interazioni sicure e affidabili:

- **Consenso e Controllo dell'Utente**: Gli utenti devono fornire consenso esplicito prima che qualsiasi dato sia accessibile o operazioni siano eseguite. Devono avere un controllo chiaro su quali dati vengono condivisi e quali azioni sono autorizzate, supportate da interfacce utente intuitive per la revisione e l'approvazione delle attività.

- **Privacy dei Dati**: I dati degli utenti devono essere esposti solo con consenso esplicito e devono essere protetti da controlli di accesso appropriati. Le implementazioni MCP devono salvaguardare contro trasmissioni di dati non autorizzate e garantire che la privacy sia mantenuta in tutte le interazioni.

- **Sicurezza degli Strumenti**: Prima di invocare qualsiasi strumento, è richiesto il consenso esplicito dell'utente. Gli utenti devono avere una chiara comprensione della funzionalità di ciascun strumento, e devono essere applicati confini di sicurezza robusti per prevenire l'esecuzione involontaria o non sicura degli strumenti.

Seguendo questi principi, MCP garantisce che fiducia, privacy e sicurezza degli utenti siano mantenute in tutte le interazioni del protocollo.

## Esempi di Codice: Componenti Chiave

Di seguito sono riportati esempi di codice in diversi linguaggi di programmazione popolari che illustrano come implementare componenti chiave del server MCP e strumenti.

### Esempio .NET: Creare un Semplice Server MCP con Strumenti

Ecco un esempio pratico di codice .NET che dimostra come implementare un semplice server MCP con strumenti personalizzati. Questo esempio mostra come definire e registrare strumenti, gestire richieste e connettere il server utilizzando il Protocollo del Contesto del Modello.

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

### Esempio Java: Componenti del Server MCP

Questo esempio dimostra lo stesso server MCP e la registrazione degli strumenti dell'esempio .NET sopra, ma implementato in Java.

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

### Esempio Python: Costruire un Server MCP

In questo esempio mostriamo come costruire un server MCP in Python. Vengono mostrati anche due modi diversi per creare strumenti.

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

### Esempio JavaScript: Creare un Server MCP

Questo esempio mostra la creazione di un server MCP in JavaScript e mostra come registrare due strumenti relativi al meteo.

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

Questo esempio JavaScript dimostra come creare un client MCP che si connette a un server, invia un prompt e elabora la risposta, inclusi eventuali richiami di strumenti effettuati.

## Sicurezza e Autorizzazione

MCP include diversi concetti e meccanismi integrati per gestire la sicurezza e l'autorizzazione in tutto il protocollo:

1. **Controllo dei Permessi degli Strumenti**:  
   I client possono specificare quali strumenti un modello è autorizzato a utilizzare durante una sessione. Questo garantisce che solo gli strumenti esplicitamente autorizzati siano accessibili, riducendo il rischio di operazioni involontarie o non sicure. I permessi possono essere configurati dinamicamente in base alle preferenze dell'utente, alle politiche organizzative o al contesto dell'interazione.

2. **Autenticazione**:  
   I server possono richiedere l'autenticazione prima di concedere accesso a strumenti, risorse o operazioni sensibili. Questo può coinvolgere chiavi API, token OAuth o altri schemi di autenticazione. Una corretta autenticazione garantisce che solo client e utenti fidati possano invocare capacità lato server.

3. **Validazione**:  
   La validazione dei parametri è applicata per tutte le invocazioni di strumenti. Ogni strumento definisce i tipi, i formati e i vincoli attesi per i suoi parametri, e il server valida le richieste in arrivo di conseguenza. Questo previene input mal

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall'uso di questa traduzione.