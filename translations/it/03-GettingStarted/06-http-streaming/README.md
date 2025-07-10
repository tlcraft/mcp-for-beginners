<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-10T16:08:35+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "it"
}
-->
# HTTPS Streaming con Model Context Protocol (MCP)

Questo capitolo fornisce una guida completa per implementare lo streaming sicuro, scalabile e in tempo reale con il Model Context Protocol (MCP) utilizzando HTTPS. Copre la motivazione dello streaming, i meccanismi di trasporto disponibili, come implementare HTTP streamable in MCP, le migliori pratiche di sicurezza, la migrazione da SSE e indicazioni pratiche per costruire le tue applicazioni MCP con streaming.

## Meccanismi di Trasporto e Streaming in MCP

Questa sezione esplora i diversi meccanismi di trasporto disponibili in MCP e il loro ruolo nell’abilitare funzionalità di streaming per la comunicazione in tempo reale tra client e server.

### Cos’è un Meccanismo di Trasporto?

Un meccanismo di trasporto definisce come i dati vengono scambiati tra client e server. MCP supporta diversi tipi di trasporto per adattarsi a vari ambienti e requisiti:

- **stdio**: input/output standard, adatto per strumenti locali e CLI. Semplice ma non adatto per web o cloud.
- **SSE (Server-Sent Events)**: permette ai server di inviare aggiornamenti in tempo reale ai client tramite HTTP. Buono per interfacce web, ma limitato in scalabilità e flessibilità.
- **Streamable HTTP**: trasporto di streaming moderno basato su HTTP, supporta notifiche e migliore scalabilità. Raccomandato per la maggior parte degli scenari di produzione e cloud.

### Tabella di Confronto

Dai un’occhiata alla tabella di confronto qui sotto per capire le differenze tra questi meccanismi di trasporto:

| Trasporto         | Aggiornamenti in tempo reale | Streaming | Scalabilità | Caso d’uso               |
|-------------------|-----------------------------|-----------|-------------|-------------------------|
| stdio             | No                          | No        | Bassa       | Strumenti CLI locali     |
| SSE               | Sì                          | Sì        | Media       | Web, aggiornamenti real-time |
| Streamable HTTP   | Sì                          | Sì        | Alta        | Cloud, multi-client     |

> **Tip:** La scelta del trasporto giusto influisce su prestazioni, scalabilità ed esperienza utente. **Streamable HTTP** è raccomandato per applicazioni moderne, scalabili e pronte per il cloud.

Nota i trasporti stdio e SSE mostrati nei capitoli precedenti e come lo streamable HTTP sia il trasporto trattato in questo capitolo.

## Streaming: Concetti e Motivazioni

Comprendere i concetti fondamentali e le motivazioni dietro lo streaming è essenziale per implementare sistemi di comunicazione in tempo reale efficaci.

**Streaming** è una tecnica nella programmazione di rete che permette di inviare e ricevere dati in piccoli blocchi gestibili o come una sequenza di eventi, invece di aspettare che tutta la risposta sia pronta. Questo è particolarmente utile per:

- File o dataset di grandi dimensioni.
- Aggiornamenti in tempo reale (es. chat, barre di progresso).
- Calcoli di lunga durata in cui si vuole tenere informato l’utente.

Ecco cosa devi sapere sullo streaming a livello generale:

- I dati vengono consegnati progressivamente, non tutti insieme.
- Il client può elaborare i dati man mano che arrivano.
- Riduce la latenza percepita e migliora l’esperienza utente.

### Perché usare lo streaming?

Le ragioni per usare lo streaming sono le seguenti:

- Gli utenti ricevono feedback immediato, non solo alla fine
- Permette applicazioni in tempo reale e interfacce reattive
- Uso più efficiente delle risorse di rete e calcolo

### Esempio Semplice: Server e Client HTTP Streaming

Ecco un esempio semplice di come si può implementare lo streaming:

<details>
<summary>Python</summary>

**Server (Python, usando FastAPI e StreamingResponse):**
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

**Client (Python, usando requests):**
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

Questo esempio mostra un server che invia una serie di messaggi al client man mano che diventano disponibili, invece di aspettare che tutti i messaggi siano pronti.

**Come funziona:**
- Il server invia ogni messaggio appena è pronto.
- Il client riceve e stampa ogni blocco appena arriva.

**Requisiti:**
- Il server deve usare una risposta in streaming (es. `StreamingResponse` in FastAPI).
- Il client deve processare la risposta come stream (`stream=True` in requests).
- Il Content-Type è solitamente `text/event-stream` o `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, usando Spring Boot e Server-Sent Events):**

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

**Client (Java, usando Spring WebFlux WebClient):**

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
- Usa lo stack reattivo di Spring Boot con `Flux` per lo streaming
- `ServerSentEvent` fornisce streaming di eventi strutturati con tipi di evento
- `WebClient` con `bodyToFlux()` abilita il consumo reattivo dello streaming
- `delayElements()` simula il tempo di elaborazione tra eventi
- Gli eventi possono avere tipi (`info`, `result`) per una migliore gestione client

</details>

### Confronto: Streaming Classico vs Streaming MCP

Le differenze tra come funziona lo streaming in modo "classico" rispetto a MCP possono essere rappresentate così:

| Caratteristica         | Streaming HTTP Classico         | Streaming MCP (Notifiche)         |
|-----------------------|--------------------------------|----------------------------------|
| Risposta principale   | Chunked                        | Singola, alla fine               |
| Aggiornamenti di progresso | Inviati come blocchi di dati | Inviati come notifiche           |
| Requisiti client      | Deve processare lo stream      | Deve implementare un gestore messaggi |
| Caso d’uso            | File grandi, stream di token AI | Progresso, log, feedback in tempo reale |

### Differenze Chiave Osservate

Inoltre, ecco alcune differenze chiave:

- **Schema di comunicazione:**
   - Streaming HTTP classico: usa semplice chunked transfer encoding per inviare dati a blocchi
   - Streaming MCP: usa un sistema strutturato di notifiche con protocollo JSON-RPC

- **Formato del messaggio:**
   - HTTP classico: blocchi di testo semplice con newline
   - MCP: oggetti strutturati LoggingMessageNotification con metadati

- **Implementazione client:**
   - HTTP classico: client semplice che processa risposte in streaming
   - MCP: client più sofisticato con gestore messaggi per elaborare diversi tipi di messaggi

- **Aggiornamenti di progresso:**
   - HTTP classico: il progresso fa parte dello stream principale di risposta
   - MCP: il progresso è inviato tramite messaggi di notifica separati mentre la risposta principale arriva alla fine

### Raccomandazioni

Ci sono alcune indicazioni che consigliamo quando si tratta di scegliere tra implementare lo streaming classico (come l’endpoint mostrato sopra usando `/stream`) o scegliere lo streaming tramite MCP.

- **Per esigenze di streaming semplici:** lo streaming HTTP classico è più semplice da implementare e sufficiente per esigenze di base.

- **Per applicazioni complesse e interattive:** lo streaming MCP offre un approccio più strutturato con metadati più ricchi e separazione tra notifiche e risultati finali.

- **Per applicazioni AI:** il sistema di notifiche MCP è particolarmente utile per task AI di lunga durata in cui si vuole tenere informati gli utenti sul progresso.

## Streaming in MCP

Ok, hai visto alcune raccomandazioni e confronti finora sulla differenza tra streaming classico e streaming in MCP. Vediamo nel dettaglio come puoi sfruttare lo streaming in MCP.

Capire come funziona lo streaming all’interno del framework MCP è essenziale per costruire applicazioni reattive che forniscano feedback in tempo reale agli utenti durante operazioni di lunga durata.

In MCP, lo streaming non riguarda l’invio della risposta principale a blocchi, ma l’invio di **notifiche** al client mentre uno strumento elabora una richiesta. Queste notifiche possono includere aggiornamenti di progresso, log o altri eventi.

### Come funziona

Il risultato principale viene comunque inviato come risposta singola. Tuttavia, le notifiche possono essere inviate come messaggi separati durante l’elaborazione e aggiornare così il client in tempo reale. Il client deve essere in grado di gestire e mostrare queste notifiche.

## Cos’è una Notifica?

Abbiamo detto "Notifica", cosa significa nel contesto di MCP?

Una notifica è un messaggio inviato dal server al client per informare su progresso, stato o altri eventi durante un’operazione di lunga durata. Le notifiche migliorano trasparenza ed esperienza utente.

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

Per far funzionare il logging, il server deve abilitarlo come feature/capability così:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> A seconda dell’SDK usato, il logging potrebbe essere abilitato di default, oppure potrebbe essere necessario abilitarlo esplicitamente nella configurazione del server.

Esistono diversi tipi di notifiche:

| Livello    | Descrizione                    | Esempio di utilizzo            |
|------------|-------------------------------|-------------------------------|
| debug      | Informazioni dettagliate di debug | Punti di ingresso/uscita funzione |
| info       | Messaggi informativi generali | Aggiornamenti di progresso    |
| notice     | Eventi normali ma significativi | Cambiamenti di configurazione |
| warning    | Condizioni di avviso           | Uso di funzionalità deprecate |
| error      | Condizioni di errore           | Fallimenti di operazioni      |
| critical   | Condizioni critiche            | Guasti di componenti di sistema |
| alert      | Azione da intraprendere immediatamente | Rilevata corruzione dati    |
| emergency  | Sistema inutilizzabile         | Guasto completo del sistema   |

## Implementare le Notifiche in MCP

Per implementare le notifiche in MCP, devi configurare sia il server che il client per gestire aggiornamenti in tempo reale. Questo permette alla tua applicazione di fornire feedback immediato agli utenti durante operazioni di lunga durata.

### Lato server: Invio delle Notifiche

Iniziamo dal lato server. In MCP, definisci strumenti che possono inviare notifiche mentre elaborano le richieste. Il server usa l’oggetto context (di solito `ctx`) per inviare messaggi al client.

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

Nell’esempio precedente, lo strumento `process_files` invia tre notifiche al client mentre elabora ogni file. Il metodo `ctx.info()` viene usato per inviare messaggi informativi.

</details>

Inoltre, per abilitare le notifiche, assicurati che il server usi un trasporto in streaming (come `streamable-http`) e che il client implementi un gestore messaggi per processare le notifiche. Ecco come configurare il server per usare il trasporto `streamable-http`:

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

In questo esempio .NET, lo strumento `ProcessFiles` è decorato con l’attributo `Tool` e invia tre notifiche al client mentre elabora ogni file. Il metodo `ctx.Info()` viene usato per inviare messaggi informativi.

Per abilitare le notifiche nel tuo server MCP .NET, assicurati di usare un trasporto in streaming:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Lato client: Ricezione delle Notifiche

Il client deve implementare un gestore messaggi per processare e mostrare le notifiche appena arrivano.

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

Nel codice precedente, la funzione `message_handler` verifica se il messaggio in arrivo è una notifica. Se lo è, stampa la notifica; altrimenti la processa come messaggio server normale. Nota anche come `ClientSession` venga inizializzato con `message_handler` per gestire le notifiche in arrivo.

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

In questo esempio .NET, la funzione `MessageHandler` verifica se il messaggio in arrivo è una notifica. Se lo è, stampa la notifica; altrimenti la processa come messaggio server normale. `ClientSession` viene inizializzato con il gestore messaggi tramite `ClientSessionOptions`.

</details>

Per abilitare le notifiche, assicurati che il server usi un trasporto in streaming (come `streamable-http`) e che il client implementi un gestore messaggi per processare le notifiche.

## Notifiche di Progresso & Scenari

Questa sezione spiega il concetto di notifiche di progresso in MCP, perché sono importanti e come implementarle usando Streamable HTTP. Troverai anche un esercizio pratico per rafforzare la comprensione.

Le notifiche di progresso sono messaggi in tempo reale inviati dal server al client durante operazioni di lunga durata. Invece di aspettare che l’intero processo finisca, il server tiene aggiornato il client sullo stato corrente. Questo migliora trasparenza, esperienza utente e facilita il debug.

**Esempio:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Perché usare le notifiche di progresso?

Le notifiche di progresso sono essenziali per diversi motivi:

- **Migliore esperienza utente:** gli utenti vedono aggiornamenti mentre il lavoro procede, non solo alla fine.
- **Feedback in tempo reale:** i client possono mostrare barre di progresso o log, rendendo l’app più reattiva.
- **Debug e monitoraggio più semplici:** sviluppatori e utenti possono vedere dove un processo è lento o bloccato.

### Come implementare le notifiche di progresso

Ecco come implementare le notifiche di progresso in MCP:

- **Sul server:** usa `ctx.info()` o `ctx.log()` per inviare notifiche mentre ogni elemento viene processato. Questo invia un messaggio al client prima che il risultato principale sia pronto.
- **Sul client:** implementa un gestore messaggi che ascolta e mostra le notifiche appena arrivano. Questo gestore distingue tra notifiche e risultato finale.

**Esempio Server:**

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

Quando si implementano server MCP con trasporti basati su HTTP, la sicurezza diventa una preoccupazione fondamentale che richiede un’attenzione accurata a molteplici vettori di attacco e meccanismi di protezione.

### Panoramica

La sicurezza è cruciale quando si espongono server MCP tramite HTTP. Streamable HTTP introduce nuove superfici di attacco e richiede una configurazione attenta.

### Punti Chiave
- **Validazione dell’Header Origin**: Verificare sempre l’header `Origin` per prevenire attacchi di DNS rebinding.
- **Binding su Localhost**: Per lo sviluppo locale, associare i server a `localhost` per evitare di esporli a internet pubblico.
- **Autenticazione**: Implementare l’autenticazione (es. API key, OAuth) per le distribuzioni in produzione.
- **CORS**: Configurare le politiche di Cross-Origin Resource Sharing (CORS) per limitare l’accesso.
- **HTTPS**: Usare HTTPS in produzione per criptare il traffico.

### Best Practice
- Non fidarsi mai delle richieste in ingresso senza una valida verifica.
- Registrare e monitorare tutti gli accessi e gli errori.
- Aggiornare regolarmente le dipendenze per correggere vulnerabilità di sicurezza.

### Sfide
- Bilanciare la sicurezza con la facilità di sviluppo
- Garantire la compatibilità con diversi ambienti client


## Aggiornamento da SSE a Streamable HTTP

Per le applicazioni che attualmente utilizzano Server-Sent Events (SSE), migrare a Streamable HTTP offre funzionalità migliorate e una maggiore sostenibilità a lungo termine per le implementazioni MCP.

### Perché Aggiornare?

Ci sono due motivi principali per passare da SSE a Streamable HTTP:

- Streamable HTTP offre migliore scalabilità, compatibilità e supporto più ricco per le notifiche rispetto a SSE.
- È il trasporto raccomandato per le nuove applicazioni MCP.

### Passaggi per la Migrazione

Ecco come migrare da SSE a Streamable HTTP nelle tue applicazioni MCP:

- **Aggiorna il codice server** per usare `transport="streamable-http"` in `mcp.run()`.
- **Aggiorna il codice client** per usare `streamablehttp_client` invece del client SSE.
- **Implementa un gestore di messaggi** nel client per elaborare le notifiche.
- **Testa la compatibilità** con gli strumenti e i flussi di lavoro esistenti.

### Mantenere la Compatibilità

Si consiglia di mantenere la compatibilità con i client SSE esistenti durante la migrazione. Ecco alcune strategie:

- Puoi supportare sia SSE che Streamable HTTP eseguendo entrambi i trasporti su endpoint diversi.
- Migrare gradualmente i client al nuovo trasporto.

### Sfide

Assicurati di affrontare le seguenti sfide durante la migrazione:

- Garantire che tutti i client vengano aggiornati
- Gestire le differenze nella consegna delle notifiche

## Considerazioni sulla Sicurezza

La sicurezza deve essere una priorità assoluta quando si implementa qualsiasi server, specialmente utilizzando trasporti basati su HTTP come Streamable HTTP in MCP.

Quando si implementano server MCP con trasporti basati su HTTP, la sicurezza diventa una preoccupazione fondamentale che richiede un’attenzione accurata a molteplici vettori di attacco e meccanismi di protezione.

### Panoramica

La sicurezza è cruciale quando si espongono server MCP tramite HTTP. Streamable HTTP introduce nuove superfici di attacco e richiede una configurazione attenta.

Ecco alcune considerazioni chiave sulla sicurezza:

- **Validazione dell’Header Origin**: Verificare sempre l’header `Origin` per prevenire attacchi di DNS rebinding.
- **Binding su Localhost**: Per lo sviluppo locale, associare i server a `localhost` per evitare di esporli a internet pubblico.
- **Autenticazione**: Implementare l’autenticazione (es. API key, OAuth) per le distribuzioni in produzione.
- **CORS**: Configurare le politiche di Cross-Origin Resource Sharing (CORS) per limitare l’accesso.
- **HTTPS**: Usare HTTPS in produzione per criptare il traffico.

### Best Practice

Inoltre, ecco alcune best practice da seguire quando si implementa la sicurezza nel server di streaming MCP:

- Non fidarsi mai delle richieste in ingresso senza una valida verifica.
- Registrare e monitorare tutti gli accessi e gli errori.
- Aggiornare regolarmente le dipendenze per correggere vulnerabilità di sicurezza.

### Sfide

Affronterai alcune sfide implementando la sicurezza nei server di streaming MCP:

- Bilanciare la sicurezza con la facilità di sviluppo
- Garantire la compatibilità con diversi ambienti client

### Esercizio: Costruisci la Tua App MCP in Streaming

**Scenario:**  
Costruisci un server e un client MCP dove il server elabora una lista di elementi (es. file o documenti) e invia una notifica per ogni elemento elaborato. Il client deve mostrare ogni notifica non appena arriva.

**Passaggi:**

1. Implementa uno strumento server che elabora una lista e invia notifiche per ogni elemento.
2. Implementa un client con un gestore di messaggi per mostrare le notifiche in tempo reale.
3. Testa la tua implementazione eseguendo sia server che client e osserva le notifiche.

[Solution](./solution/README.md)

## Ulteriori Letture & Cosa Fare Dopo?

Per proseguire il tuo percorso con lo streaming MCP e ampliare le tue conoscenze, questa sezione offre risorse aggiuntive e suggerimenti per costruire applicazioni più avanzate.

### Ulteriori Letture

- [Microsoft: Introduzione allo Streaming HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Cosa Fare Dopo?

- Prova a costruire strumenti MCP più avanzati che usano lo streaming per analisi in tempo reale, chat o editing collaborativo.
- Esplora l’integrazione dello streaming MCP con framework frontend (React, Vue, ecc.) per aggiornamenti UI live.
- Prossimo: [Utilizzo del Toolkit AI per VSCode](../07-aitk/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.