<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:02:42+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "it"
}
-->
# HTTPS Streaming con Model Context Protocol (MCP)

Questo capitolo offre una guida completa per implementare uno streaming sicuro, scalabile e in tempo reale con il Model Context Protocol (MCP) utilizzando HTTPS. Copre la motivazione dello streaming, i meccanismi di trasporto disponibili, come implementare HTTP streamable in MCP, le migliori pratiche di sicurezza, la migrazione da SSE e indicazioni pratiche per costruire le tue applicazioni MCP streaming.

## Meccanismi di Trasporto e Streaming in MCP

Questa sezione esplora i diversi meccanismi di trasporto disponibili in MCP e il loro ruolo nell’abilitare capacità di streaming per la comunicazione in tempo reale tra client e server.

### Cos’è un Meccanismo di Trasporto?

Un meccanismo di trasporto definisce come i dati vengono scambiati tra client e server. MCP supporta diversi tipi di trasporto per adattarsi a differenti ambienti e requisiti:

- **stdio**: input/output standard, adatto per strumenti locali e CLI. Semplice ma non adatto per web o cloud.
- **SSE (Server-Sent Events)**: permette ai server di inviare aggiornamenti in tempo reale ai client tramite HTTP. Buono per interfacce web, ma limitato in scalabilità e flessibilità.
- **Streamable HTTP**: trasporto streaming basato su HTTP moderno, supporta notifiche e migliore scalabilità. Raccomandato per la maggior parte degli scenari di produzione e cloud.

### Tabella di Confronto

Dai un’occhiata alla tabella di confronto qui sotto per capire le differenze tra questi meccanismi di trasporto:

| Trasporto         | Aggiornamenti in Tempo Reale | Streaming | Scalabilità | Caso d'Uso               |
|-------------------|------------------------------|-----------|-------------|--------------------------|
| stdio             | No                           | No        | Bassa       | Strumenti CLI locali      |
| SSE               | Sì                           | Sì        | Media       | Web, aggiornamenti in tempo reale |
| Streamable HTTP   | Sì                           | Sì        | Alta        | Cloud, multi-client      |

> **Tip:** La scelta del trasporto giusto influenza performance, scalabilità ed esperienza utente. **Streamable HTTP** è raccomandato per applicazioni moderne, scalabili e pronte per il cloud.

Nota i trasporti stdio e SSE mostrati nei capitoli precedenti e come in questo capitolo viene trattato lo streamable HTTP.

## Streaming: Concetti e Motivazioni

Comprendere i concetti fondamentali e le motivazioni dietro lo streaming è essenziale per implementare sistemi di comunicazione in tempo reale efficaci.

**Streaming** è una tecnica nella programmazione di rete che permette di inviare e ricevere dati in piccoli blocchi gestibili o come una sequenza di eventi, invece di aspettare che l’intera risposta sia pronta. Questo è particolarmente utile per:

- File o dataset di grandi dimensioni.
- Aggiornamenti in tempo reale (es. chat, barre di progresso).
- Calcoli a lunga durata in cui si vuole tenere informato l’utente.

Ecco cosa devi sapere sullo streaming a livello generale:

- I dati vengono consegnati progressivamente, non tutti insieme.
- Il client può elaborare i dati man mano che arrivano.
- Riduce la latenza percepita e migliora l’esperienza utente.

### Perché usare lo streaming?

Le ragioni per usare lo streaming sono le seguenti:

- Gli utenti ricevono feedback immediato, non solo alla fine
- Permette applicazioni in tempo reale e interfacce reattive
- Utilizzo più efficiente delle risorse di rete e calcolo

### Esempio Semplice: Server & Client HTTP Streaming

Ecco un esempio semplice di come può essere implementato lo streaming:

<details>
<summary>Python</summary>

**Server (Python, con FastAPI e StreamingResponse):**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**Client (Python, con requests):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

Questo esempio mostra un server che invia una serie di messaggi al client non appena sono disponibili, invece di aspettare che tutti i messaggi siano pronti.

**Come funziona:**
- Il server invia ogni messaggio appena è pronto.
- Il client riceve e stampa ogni blocco man mano che arriva.

**Requisiti:**
- Il server deve utilizzare una risposta streaming (es. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, con Spring Boot e Server-Sent Events):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**Client (Java, con Spring WebFlux WebClient):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Note sull’implementazione Java:**
- Usa lo stack reattivo di Spring Boot con `Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) rispetto alla scelta dello streaming via MCP.

- **Per esigenze di streaming semplici:** Lo streaming HTTP classico è più semplice da implementare e sufficiente per esigenze base.

- **Per applicazioni complesse e interattive:** Lo streaming MCP offre un approccio più strutturato con metadati più ricchi e separazione tra notifiche e risultati finali.

- **Per applicazioni AI:** Il sistema di notifiche MCP è particolarmente utile per task AI a lunga durata in cui si vuole tenere l’utente aggiornato sul progresso.

## Streaming in MCP

Bene, hai visto alcune raccomandazioni e confronti finora tra streaming classico e streaming in MCP. Vediamo nel dettaglio come puoi sfruttare lo streaming in MCP.

Comprendere come funziona lo streaming all’interno del framework MCP è fondamentale per costruire applicazioni reattive che forniscano feedback in tempo reale agli utenti durante operazioni a lunga durata.

In MCP, lo streaming non riguarda l’invio della risposta principale a blocchi, ma l’invio di **notifiche** al client mentre uno strumento elabora una richiesta. Queste notifiche possono includere aggiornamenti di progresso, log o altri eventi.

### Come funziona

Il risultato principale viene comunque inviato come una singola risposta. Tuttavia, le notifiche possono essere inviate come messaggi separati durante l’elaborazione, aggiornando così il client in tempo reale. Il client deve essere in grado di gestire e mostrare queste notifiche.

## Cos’è una Notifica?

Abbiamo detto "Notifica", cosa significa nel contesto MCP?

Una notifica è un messaggio inviato dal server al client per informare su progresso, stato o altri eventi durante un’operazione a lunga durata. Le notifiche migliorano trasparenza ed esperienza utente.

Ad esempio, un client dovrebbe inviare una notifica una volta che il handshake iniziale con il server è stato effettuato.

Una notifica appare così come messaggio JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Le notifiche appartengono a un topic in MCP chiamato ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Per far funzionare il logging, il server deve abilitarlo come feature/capabilità in questo modo:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> A seconda dell’SDK utilizzato, il logging potrebbe essere abilitato di default, oppure potrebbe essere necessario abilitarlo esplicitamente nella configurazione del server.

Esistono diversi tipi di notifiche:

| Livello    | Descrizione                    | Caso d’Uso Esempio            |
|------------|-------------------------------|------------------------------|
| debug      | Informazioni dettagliate di debug | Punti di ingresso/uscita funzione |
| info       | Messaggi informativi generali | Aggiornamenti di progresso   |
| notice     | Eventi normali ma significativi | Modifiche di configurazione  |
| warning    | Condizioni di avviso           | Uso di funzionalità deprecate |
| error      | Condizioni di errore           | Fallimenti operativi         |
| critical   | Condizioni critiche            | Guasti di componenti di sistema |
| alert      | Azione immediata richiesta     | Rilevamento di corruzione dati |
| emergency  | Sistema inutilizzabile         | Guasto completo del sistema  |

## Implementare le Notifiche in MCP

Per implementare le notifiche in MCP, devi configurare sia il server che il client per gestire aggiornamenti in tempo reale. Questo permette alla tua applicazione di fornire feedback immediato agli utenti durante operazioni a lunga durata.

### Lato Server: Invio delle Notifiche

Iniziamo dal lato server. In MCP, definisci strumenti che possono inviare notifiche mentre elaborano richieste. Il server usa l’oggetto context (di solito `ctx`) per inviare messaggi al client.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

Nell’esempio precedente, il trasporto `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

In questo esempio .NET, il metodo `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` viene usato per inviare messaggi informativi.

Per abilitare le notifiche nel tuo server MCP .NET, assicurati di usare un trasporto streaming:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Lato Client: Ricezione delle Notifiche

Il client deve implementare un gestore di messaggi per elaborare e mostrare le notifiche appena arrivano.

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

Nel codice precedente, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` gestisce le notifiche in arrivo.

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

In questo esempio .NET, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) e il client implementano un gestore di messaggi per elaborare le notifiche.

## Notifiche di Progresso & Scenari

Questa sezione spiega il concetto di notifiche di progresso in MCP, perché sono importanti e come implementarle usando Streamable HTTP. Troverai anche un esercizio pratico per consolidare la tua comprensione.

Le notifiche di progresso sono messaggi in tempo reale inviati dal server al client durante operazioni a lunga durata. Invece di aspettare che tutto finisca, il server tiene aggiornato il client sullo stato attuale. Questo migliora trasparenza, esperienza utente e facilita il debug.

**Esempio:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Perché usare le notifiche di progresso?

Le notifiche di progresso sono essenziali per diversi motivi:

- **Migliore esperienza utente:** Gli utenti vedono aggiornamenti mentre il lavoro procede, non solo alla fine.
- **Feedback in tempo reale:** I client possono mostrare barre di progresso o log, rendendo l’app più reattiva.
- **Debug e monitoraggio facilitati:** Sviluppatori e utenti possono capire dove un processo è lento o bloccato.

### Come implementare le notifiche di progresso

Ecco come implementare notifiche di progresso in MCP:

- **Sul server:** Usa `ctx.info()` or `ctx.log()` per inviare notifiche mentre ogni elemento viene elaborato. Questo invia un messaggio al client prima che il risultato principale sia pronto.
- **Sul client:** Implementa un gestore di messaggi che ascolta e mostra le notifiche appena arrivano. Questo gestore distingue tra notifiche e risultato finale.

**Esempio Server:**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**Esempio Client:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## Considerazioni sulla Sicurezza

Quando si implementano server MCP con trasporti basati su HTTP, la sicurezza diventa una preoccupazione fondamentale che richiede attenzione a molteplici vettori di attacco e meccanismi di protezione.

### Panoramica

La sicurezza è critica quando si espongono server MCP su HTTP. Streamable HTTP introduce nuove superfici di attacco e richiede configurazioni attente.

### Punti Chiave
- **Validazione dell’Header Origin**: Valida sempre l’header `Origin` per evitare richieste da origini non autorizzate.
- **Usa HTTPS**: Assicurati che tutte le comunicazioni avvengano su HTTPS per proteggere i dati in transito.
- **Autenticazione e Autorizzazione**: Implementa meccanismi robusti per autenticare e autorizzare client e utenti.
- **Gestione degli Errori**: Tratta con cura gli errori per non esporre informazioni sensibili.
- **Rate Limiting e Protezioni Anti-DDoS**: Proteggi il server da attacchi di tipo denial-of-service.
- **Logging Sicuro**: Monitora e registra gli eventi di sicurezza per analisi e auditing.

### Mantenere la Compatibilità

Si raccomanda di mantenere la compatibilità con i client SSE esistenti durante il processo di migrazione. Ecco alcune strategie:

- Puoi supportare sia SSE che Streamable HTTP eseguendo entrambi i trasporti su endpoint diversi.
- Migra gradualmente i client al nuovo trasporto.

### Sfide

Assicurati di affrontare le seguenti sfide durante la migrazione:

- Garantire che tutti i client siano aggiornati
- Gestire le differenze nella consegna delle notifiche

### Esercizio: Costruisci la Tua App MCP Streaming

**Scenario:**
Costruisci un server e un client MCP dove il server elabora una lista di elementi (es. file o documenti) e invia una notifica per ogni elemento processato. Il client deve mostrare ogni notifica appena arriva.

**Passi:**

1. Implementa uno strumento server che elabora una lista e invia notifiche per ogni elemento.
2. Implementa un client con un gestore di messaggi per mostrare le notifiche in tempo reale.
3. Testa la tua implementazione eseguendo sia server che client e osserva le notifiche.

[Solution](./solution/README.md)

## Ulteriori Letture & Cosa Fare Dopo?

Per continuare il tuo percorso con lo streaming MCP e ampliare le tue conoscenze, questa sezione fornisce risorse aggiuntive e suggerimenti per costruire applicazioni più avanzate.

### Ulteriori Letture

- [Microsoft: Introduzione allo Streaming HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Cosa Fare Dopo?

- Prova a costruire strumenti MCP più avanzati che usano lo streaming per analytics in tempo reale, chat o editing collaborativo.
- Esplora l’integrazione dello streaming MCP con framework frontend (React, Vue, ecc.) per aggiornamenti UI live.
- Successivo: [Utilizzo del Toolkit AI per VSCode](../07-aitk/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di considerare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale effettuata da un traduttore umano. Non ci assumiamo responsabilità per eventuali incomprensioni o interpretazioni errate derivanti dall’uso di questa traduzione.