<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:28:22+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ro"
}
-->
# Streaming HTTPS cu Model Context Protocol (MCP)

Acest capitol oferă un ghid complet pentru implementarea streaming-ului securizat, scalabil și în timp real folosind Model Context Protocol (MCP) prin HTTPS. Sunt acoperite motivația pentru streaming, mecanismele de transport disponibile, cum să implementezi HTTP streamabil în MCP, cele mai bune practici de securitate, migrarea de la SSE și îndrumări practice pentru construirea propriilor aplicații MCP cu streaming.

## Mecanisme de Transport și Streaming în MCP

Această secțiune explorează diferitele mecanisme de transport disponibile în MCP și rolul lor în activarea capabilităților de streaming pentru comunicarea în timp real între clienți și servere.

### Ce este un Mecanism de Transport?

Un mecanism de transport definește modul în care datele sunt schimbate între client și server. MCP suportă mai multe tipuri de transport pentru a se potrivi cu diferite medii și cerințe:

- **stdio**: Intrare/ieșire standard, potrivit pentru unelte locale și bazate pe linia de comandă. Simplu, dar nepotrivit pentru web sau cloud.
- **SSE (Server-Sent Events)**: Permite serverelor să trimită actualizări în timp real către clienți prin HTTP. Bun pentru interfețe web, dar limitat în scalabilitate și flexibilitate.
- **Streamable HTTP**: Transport modern bazat pe HTTP pentru streaming, suportând notificări și o scalabilitate mai bună. Recomandat pentru majoritatea scenariilor de producție și cloud.

### Tabel de Comparare

Consultați tabelul de mai jos pentru a înțelege diferențele dintre aceste mecanisme de transport:

| Transport         | Actualizări în timp real | Streaming | Scalabilitate | Caz de utilizare         |
|-------------------|--------------------------|-----------|---------------|-------------------------|
| stdio             | Nu                       | Nu        | Scăzut        | Unelte CLI locale       |
| SSE               | Da                       | Da        | Mediu         | Web, actualizări în timp real |
| Streamable HTTP   | Da                       | Da        | Ridicat       | Cloud, multi-client     |

> **Tip:** Alegerea transportului potrivit influențează performanța, scalabilitatea și experiența utilizatorului. **Streamable HTTP** este recomandat pentru aplicații moderne, scalabile și pregătite pentru cloud.

Rețineți transporturile stdio și SSE prezentate în capitolele anterioare și cum Streamable HTTP este transportul abordat în acest capitol.

## Streaming: Concepte și Motivație

Înțelegerea conceptelor fundamentale și a motivațiilor din spatele streaming-ului este esențială pentru implementarea unor sisteme eficiente de comunicare în timp real.

**Streaming-ul** este o tehnică în programarea de rețea care permite trimiterea și primirea datelor în bucăți mici, gestionabile sau ca o succesiune de evenimente, în loc să se aștepte un răspuns complet. Acest lucru este util mai ales pentru:

- Fișiere sau seturi de date mari.
- Actualizări în timp real (de ex. chat, bare de progres).
- Computații de durată lungă în care dorești să ții utilizatorul informat.

Iată ce trebuie să știi despre streaming la nivel înalt:

- Datele sunt livrate progresiv, nu toate odată.
- Clientul poate procesa datele pe măsură ce sosesc.
- Reduce latența percepută și îmbunătățește experiența utilizatorului.

### De ce să folosești streaming?

Motivele pentru utilizarea streaming-ului sunt următoarele:

- Utilizatorii primesc feedback imediat, nu doar la final
- Permite aplicații în timp real și interfețe responsive
- Utilizare mai eficientă a resurselor de rețea și calcul

### Exemplu Simplu: Server și Client HTTP Streaming

Iată un exemplu simplu despre cum poate fi implementat streaming-ul:

<details>
<summary>Python</summary>

**Server (Python, folosind FastAPI și StreamingResponse):**
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

**Client (Python, folosind requests):**
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

Acest exemplu demonstrează un server care trimite o serie de mesaje către client pe măsură ce acestea devin disponibile, în loc să aștepte ca toate mesajele să fie gata.

**Cum funcționează:**
- Serverul transmite fiecare mesaj pe măsură ce este pregătit.
- Clientul primește și afișează fiecare fragment pe măsură ce sosește.

**Cerințe:**
- Serverul trebuie să folosească un răspuns de tip streaming (ex. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) în loc să aleagă streaming prin MCP.

- **Pentru nevoi simple de streaming:** Streaming-ul HTTP clasic este mai simplu de implementat și suficient pentru nevoi de bază.

- **Pentru aplicații complexe, interactive:** Streaming-ul MCP oferă o abordare mai structurată cu metadate mai bogate și separarea între notificări și rezultatul final.

- **Pentru aplicații AI:** Sistemul de notificări MCP este deosebit de util pentru sarcini AI de durată, unde dorești să ții utilizatorii informați despre progres.

## Streaming în MCP

Bine, ai văzut deja recomandări și comparații privind diferența dintre streaming-ul clasic și cel în MCP. Hai să detaliem exact cum poți folosi streaming-ul în MCP.

Înțelegerea modului în care streaming-ul funcționează în cadrul MCP este esențială pentru construirea de aplicații responsive care oferă feedback în timp real utilizatorilor în timpul operațiunilor de durată.

În MCP, streaming-ul nu înseamnă trimiterea răspunsului principal în bucăți, ci trimiterea de **notificări** către client în timp ce un instrument procesează o cerere. Aceste notificări pot include actualizări de progres, loguri sau alte evenimente.

### Cum funcționează

Rezultatul principal este trimis tot ca un singur răspuns. Totuși, notificările pot fi trimise ca mesaje separate în timpul procesării și astfel actualizează clientul în timp real. Clientul trebuie să poată gestiona și afișa aceste notificări.

## Ce este o Notificare?

Am menționat „Notificare”, ce înseamnă asta în contextul MCP?

O notificare este un mesaj trimis de la server către client pentru a informa despre progres, stare sau alte evenimente în timpul unei operațiuni de durată. Notificările îmbunătățesc transparența și experiența utilizatorului.

De exemplu, clientul trebuie să trimită o notificare odată ce s-a realizat handshake-ul inițial cu serverul.

O notificare arată astfel ca un mesaj JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notificările aparțin unui subiect în MCP numit ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Pentru ca logging-ul să funcționeze, serverul trebuie să îl activeze ca funcționalitate/capabilitate astfel:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> În funcție de SDK-ul folosit, logging-ul poate fi activat implicit sau poate fi necesar să îl activezi explicit în configurația serverului.

Există diferite tipuri de notificări:

| Nivel     | Descriere                     | Exemplu de Utilizare           |
|-----------|-------------------------------|-------------------------------|
| debug     | Informații detaliate de depanare | Puncte de intrare/ieșire în funcții |
| info      | Mesaje informaționale generale | Actualizări de progres         |
| notice    | Evenimente normale, dar semnificative | Schimbări de configurație     |
| warning   | Condiții de avertizare         | Utilizare funcționalitate depreciată |
| error     | Condiții de eroare             | Eșecuri în operațiuni         |
| critical  | Condiții critice               | Defecțiuni în componentele sistemului |
| alert     | Acțiune necesară imediat       | Detectare corupție de date    |
| emergency | Sistemul este inutilizabil     | Defecțiune completă a sistemului |

## Implementarea Notificărilor în MCP

Pentru a implementa notificările în MCP, trebuie să configurezi atât partea de server, cât și pe cea de client pentru a gestiona actualizările în timp real. Astfel, aplicația ta poate oferi feedback imediat utilizatorilor în timpul operațiunilor de durată.

### Partea de server: Trimiterea Notificărilor

Să începem cu partea de server. În MCP, definești unelte care pot trimite notificări în timp ce procesează cereri. Serverul folosește obiectul context (de obicei `ctx`) pentru a trimite mesaje către client.

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

În exemplul anterior, funcția `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` folosește transportul:

```python
mcp.run(transport="streamable-http")
```

</details>

### Partea de client: Primirea Notificărilor

Clientul trebuie să implementeze un handler de mesaje pentru a procesa și afișa notificările pe măsură ce sosesc.

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

În codul de mai sus, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` și clientul tău implementează un handler pentru a procesa notificările.

## Notificări de Progres & Scenarii

Această secțiune explică conceptul de notificări de progres în MCP, de ce sunt importante și cum să le implementezi folosind Streamable HTTP. Vei găsi și un exercițiu practic pentru a-ți consolida cunoștințele.

Notificările de progres sunt mesaje în timp real trimise de server către client în timpul operațiunilor de durată. În loc să aștepte finalizarea întregului proces, serverul ține clientul la curent cu stadiul curent. Acest lucru îmbunătățește transparența, experiența utilizatorului și facilitează depanarea.

**Exemplu:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### De ce să folosești notificările de progres?

Notificările de progres sunt esențiale din mai multe motive:

- **Experiență mai bună pentru utilizator:** Utilizatorii văd actualizări pe măsură ce munca avansează, nu doar la final.
- **Feedback în timp real:** Clienții pot afișa bare de progres sau loguri, făcând aplicația să pară mai receptivă.
- **Depanare și monitorizare mai ușoară:** Dezvoltatorii și utilizatorii pot vedea unde un proces este lent sau blocat.

### Cum să implementezi notificările de progres

Iată cum poți implementa notificările de progres în MCP:

- **Pe server:** Folosește `ctx.info()` or `ctx.log()` pentru a trimite notificări pe măsură ce fiecare element este procesat. Aceasta trimite un mesaj clientului înainte ca rezultatul principal să fie gata.
- **Pe client:** Implementează un handler de mesaje care ascultă și afișează notificările pe măsură ce sosesc. Acest handler face distincția între notificări și rezultatul final.

**Exemplu server:**

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

**Exemplu client:**

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

## Considerații de Securitate

Atunci când implementezi servere MCP cu transporturi bazate pe HTTP, securitatea devine o preocupare esențială care necesită atenție atentă asupra mai multor vectori de atac și mecanisme de protecție.

### Prezentare generală

Securitatea este critică atunci când expui servere MCP prin HTTP. Streamable HTTP introduce noi suprafețe de atac și necesită configurare atentă.

### Puncte cheie
- **Validarea antetului Origin**: Verifică întotdeauna antetul `Origin` pentru a te asigura că cererile provin din surse de încredere.
- **Utilizează HTTPS**: Asigură comunicațiile pentru a preveni interceptarea datelor.
- **Autentificare și autorizare**: Implementează mecanisme adecvate pentru a controla accesul.
- **Rate limiting**: Protejează serverul de atacuri de tip DoS.
- **Monitorizare și logare**: Urmărește activitatea pentru detectarea comportamentului anormal.

### Menținerea Compatibilității

Este recomandat să menții compatibilitatea cu clienții SSE existenți în timpul procesului de migrare. Iată câteva strategii:

- Poți suporta atât SSE, cât și Streamable HTTP rulând ambele transporturi pe endpoint-uri diferite.
- Migrează treptat clienții către noul transport.

### Provocări

Asigură-te că abordezi următoarele provocări în timpul migrării:

- Asigurarea actualizării tuturor clienților
- Gestionarea diferențelor în livrarea notificărilor

### Exercițiu: Construiește propria aplicație MCP cu streaming

**Scenariu:**
Construiește un server MCP și un client în care serverul procesează o listă de elemente (ex. fișiere sau documente) și trimite o notificare pentru fiecare element procesat. Clientul trebuie să afișeze fiecare notificare pe măsură ce sosește.

**Pași:**

1. Implementează un instrument server care procesează o listă și trimite notificări pentru fiecare element.
2. Implementează un client cu un handler de mesaje care afișează notificările în timp real.
3. Testează implementarea rulând atât serverul, cât și clientul, și observă notificările.

[Solution](./solution/README.md)

## Lecturi suplimentare și ce urmează?

Pentru a continua călătoria ta cu streaming-ul MCP și a-ți extinde cunoștințele, această secțiune oferă resurse suplimentare și pași sugerați pentru construirea unor aplicații mai avansate.

### Lecturi suplimentare

- [Microsoft: Introducere în HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS în ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Ce urmează?

- Încearcă să construiești unelte MCP mai avansate care folosesc streaming pentru analize în timp real, chat sau editare colaborativă.
- Explorează integrarea streaming-ului MCP cu framework-uri frontend (React, Vue etc.) pentru actualizări live ale interfeței.
- Următorul pas: [Utilizarea AI Toolkit pentru VSCode](../07-aitk/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un traducător uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.