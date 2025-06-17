<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:09:29+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "it"
}
-->
# HTTPS Streaming con Model Context Protocol (MCP)

Questo capitolo offre una guida completa per implementare streaming sicuro, scalabile e in tempo reale con il Model Context Protocol (MCP) usando HTTPS. Copre la motivazione dello streaming, i meccanismi di trasporto disponibili, come implementare HTTP streamable in MCP, le best practice di sicurezza, la migrazione da SSE e indicazioni pratiche per costruire le tue applicazioni MCP streaming.

## Meccanismi di Trasporto e Streaming in MCP

Questa sezione esplora i diversi meccanismi di trasporto disponibili in MCP e il loro ruolo nell'abilitare funzionalità di streaming per la comunicazione in tempo reale tra client e server.

### Cos’è un Meccanismo di Trasporto?

Un meccanismo di trasporto definisce come i dati vengono scambiati tra client e server. MCP supporta diversi tipi di trasporto per adattarsi a vari ambienti e requisiti:

- **stdio**: input/output standard, adatto per strumenti locali e basati su CLI. Semplice ma non adatto per il web o il cloud.
- **SSE (Server-Sent Events)**: permette ai server di inviare aggiornamenti in tempo reale ai client tramite HTTP. Buono per interfacce web, ma limitato in scalabilità e flessibilità.
- **Streamable HTTP**: trasporto di streaming moderno basato su HTTP, supporta notifiche e migliore scalabilità. Raccomandato per la maggior parte degli scenari di produzione e cloud.

### Tabella di Confronto

Dai un’occhiata alla tabella di confronto qui sotto per capire le differenze tra questi meccanismi di trasporto:

| Trasporto        | Aggiornamenti in tempo reale | Streaming | Scalabilità | Caso d’uso               |
|------------------|-----------------------------|-----------|-------------|--------------------------|
| stdio            | No                          | No        | Bassa       | Strumenti CLI locali      |
| SSE              | Sì                          | Sì        | Media       | Web, aggiornamenti in tempo reale |
| Streamable HTTP  | Sì                          | Sì        | Alta        | Cloud, multi-client      |

> **Tip:** Scegliere il trasporto giusto influisce su prestazioni, scalabilità ed esperienza utente. **Streamable HTTP** è consigliato per applicazioni moderne, scalabili e pronte per il cloud.

Nota i trasporti stdio e SSE mostrati nei capitoli precedenti e come Streamable HTTP sia il trasporto trattato in questo capitolo.

## Streaming: Concetti e Motivazioni

Comprendere i concetti fondamentali e le motivazioni dietro lo streaming è essenziale per implementare sistemi di comunicazione in tempo reale efficaci.

**Streaming** è una tecnica nella programmazione di rete che permette di inviare e ricevere dati in piccoli blocchi gestibili o come sequenze di eventi, invece di aspettare che tutta la risposta sia pronta. Questo è particolarmente utile per:

- File o dataset di grandi dimensioni.
- Aggiornamenti in tempo reale (es. chat, barre di progresso).
- Computazioni a lunga durata dove si vuole tenere informato l’utente.

Ecco cosa devi sapere sullo streaming a grandi linee:

- I dati vengono consegnati progressivamente, non tutti insieme.
- Il client può elaborare i dati man mano che arrivano.
- Riduce la latenza percepita e migliora l’esperienza utente.

### Perché usare lo streaming?

I motivi per utilizzare lo streaming sono:

- Gli utenti ricevono feedback immediati, non solo alla fine.
- Abilita applicazioni in tempo reale e interfacce reattive.
- Uso più efficiente delle risorse di rete e calcolo.

### Esempio Semplice: Server & Client HTTP Streaming

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

Questo esempio mostra un server che invia una serie di messaggi al client non appena sono disponibili, invece di aspettare che tutti i messaggi siano pronti.

**Come funziona:**
- Il server invia ogni messaggio appena è pronto.
- Il client riceve e stampa ogni blocco appena arriva.

**Requisiti:**
- Il server deve usare una risposta di streaming (es. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) invece di scegliere lo streaming tramite MCP.

- **Per esigenze di streaming semplici:** lo streaming HTTP classico è più semplice da implementare e sufficiente per bisogni di base.

- **Per applicazioni complesse e interattive:** lo streaming MCP offre un approccio più strutturato con metadati più ricchi e separazione tra notifiche e risultati finali.

- **Per applicazioni AI:** il sistema di notifiche MCP è particolarmente utile per task AI a lunga durata dove si vuole tenere informati gli utenti sul progresso.

## Streaming in MCP

Bene, hai visto alcune raccomandazioni e confronti finora tra lo streaming classico e lo streaming in MCP. Vediamo nel dettaglio come puoi sfruttare lo streaming in MCP.

Comprendere come funziona lo streaming all’interno del framework MCP è essenziale per costruire applicazioni reattive che forniscano feedback in tempo reale durante operazioni a lunga durata.

In MCP, lo streaming non riguarda l’invio della risposta principale a pezzi, ma l’invio di **notifiche** al client mentre uno strumento elabora una richiesta. Queste notifiche possono includere aggiornamenti di progresso, log o altri eventi.

### Come funziona

Il risultato principale viene comunque inviato come una singola risposta. Tuttavia, le notifiche possono essere inviate come messaggi separati durante l’elaborazione e aggiornare così il client in tempo reale. Il client deve essere in grado di gestire e mostrare queste notifiche.

## Cos’è una Notifica?

Abbiamo detto "Notifica", cosa significa nel contesto di MCP?

Una notifica è un messaggio inviato dal server al client per informare su progresso, stato o altri eventi durante un’operazione a lunga durata. Le notifiche migliorano trasparenza ed esperienza utente.

Ad esempio, un client dovrebbe inviare una notifica una volta stabilito il collegamento iniziale con il server.

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

Per far funzionare il logging, il server deve abilitarlo come feature/capacità così:

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

| Livello    | Descrizione                   | Caso d’uso esempio             |
|------------|------------------------------|-------------------------------|
| debug      | Informazioni dettagliate di debug | Punti di ingresso/uscita funzione |
| info       | Messaggi informativi generali | Aggiornamenti di progresso    |
| notice     | Eventi normali ma significativi | Cambiamenti di configurazione |
| warning    | Condizioni di avvertimento    | Uso di funzionalità deprecate |
| error      | Condizioni di errore          | Fallimenti di operazioni       |
| critical   | Condizioni critiche           | Fallimenti di componenti di sistema |
| alert      | Azione da intraprendere immediatamente | Rilevata corruzione dati     |
| emergency  | Sistema inutilizzabile        | Fallimento completo del sistema |

## Implementare le Notifiche in MCP

Per implementare notifiche in MCP, devi configurare sia il lato server che il client per gestire aggiornamenti in tempo reale. Questo permette all’applicazione di fornire feedback immediati durante operazioni a lunga durata.

### Lato server: Invio Notifiche

Partiamo dal lato server. In MCP definisci strumenti che possono inviare notifiche mentre elaborano richieste. Il server usa l’oggetto context (di solito `ctx`) per inviare messaggi al client.

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

### Lato client: Ricezione Notifiche

Il client deve implementare un handler dei messaggi per processare e mostrare le notifiche man mano che arrivano.

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

Nel codice precedente, il `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) e il tuo client implementa un handler per processare le notifiche.

## Notifiche di Progresso & Scenari

Questa sezione spiega il concetto di notifiche di progresso in MCP, perché sono importanti e come implementarle usando Streamable HTTP. Troverai anche un esercizio pratico per consolidare la comprensione.

Le notifiche di progresso sono messaggi in tempo reale inviati dal server al client durante operazioni a lunga durata. Invece di aspettare che tutto il processo finisca, il server mantiene aggiornato il client sullo stato attuale. Questo migliora trasparenza, esperienza utente e facilita il debug.

**Esempio:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Perché usare notifiche di progresso?

Le notifiche di progresso sono essenziali per diversi motivi:

- **Migliore esperienza utente:** gli utenti vedono aggiornamenti mentre il lavoro procede, non solo alla fine.
- **Feedback in tempo reale:** i client possono mostrare barre di progresso o log, rendendo l’app più reattiva.
- **Debug e monitoraggio facilitati:** sviluppatori e utenti possono vedere dove un processo è lento o bloccato.

### Come implementare notifiche di progresso

Ecco come implementare notifiche di progresso in MCP:

- **Sul server:** usa `ctx.info()` or `ctx.log()` per inviare notifiche mentre ogni elemento viene processato. Questo manda un messaggio al client prima che il risultato principale sia pronto.
- **Sul client:** implementa un handler dei messaggi che ascolta e mostra le notifiche appena arrivano. Questo handler distingue tra notifiche e risultato finale.

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

La sicurezza è critica quando si espongono server MCP via HTTP. Streamable HTTP introduce nuove superfici di attacco e richiede configurazioni attente.

### Punti Chiave
- **Validazione dell’Header Origin**: valida sempre l’header `Origin` per evitare richieste cross-site non autorizzate.
- **Autenticazione e autorizzazione**: assicurati che solo client autorizzati possano accedere alle risorse.
- **Protezione contro attacchi DoS**: implementa limiti e controlli per prevenire sovraccarichi.
- **Configurazione HTTPS corretta**: usa certificati validi e protocolli sicuri.
- **Aggiornamenti regolari**: mantieni server e librerie aggiornati per correggere vulnerabilità note.

### Mantenere la Compatibilità

È consigliato mantenere la compatibilità con i client SSE esistenti durante il processo di migrazione. Ecco alcune strategie:

- Puoi supportare sia SSE che Streamable HTTP eseguendo entrambi i trasporti su endpoint diversi.
- Migra gradualmente i client al nuovo trasporto.

### Sfide

Assicurati di affrontare le seguenti sfide durante la migrazione:

- Garantire che tutti i client siano aggiornati.
- Gestire le differenze nella consegna delle notifiche.

### Esercizio: Costruisci la Tua App MCP Streaming

**Scenario:**
Costruisci un server e un client MCP dove il server processa una lista di elementi (es. file o documenti) e invia una notifica per ogni elemento processato. Il client deve mostrare ogni notifica appena arriva.

**Passi:**

1. Implementa uno strumento server che processa una lista e invia notifiche per ogni elemento.
2. Implementa un client con un handler dei messaggi per mostrare le notifiche in tempo reale.
3. Testa la tua implementazione eseguendo sia server che client, e osserva le notifiche.

[Solution](./solution/README.md)

## Ulteriori Letture & Prossimi Passi

Per continuare il tuo percorso con lo streaming MCP e ampliare le tue conoscenze, questa sezione fornisce risorse aggiuntive e suggerimenti per costruire applicazioni più avanzate.

### Ulteriori Letture

- [Microsoft: Introduzione allo Streaming HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Prossimi Passi

- Prova a costruire strumenti MCP più avanzati che usino lo streaming per analisi in tempo reale, chat o editing collaborativo.
- Esplora l’integrazione dello streaming MCP con framework frontend (React, Vue, ecc.) per aggiornamenti UI live.
- Prossimo: [Utilizzo AI Toolkit per VSCode](../07-aitk/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua originale deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un traduttore umano. Non ci assumiamo alcuna responsabilità per eventuali incomprensioni o interpretazioni errate derivanti dall’uso di questa traduzione.