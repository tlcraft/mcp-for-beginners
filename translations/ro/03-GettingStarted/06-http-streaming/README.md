<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:53:40+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ro"
}
-->
# HTTPS Streaming cu Model Context Protocol (MCP)

Acest capitol oferă un ghid complet pentru implementarea streaming-ului securizat, scalabil și în timp real cu Model Context Protocol (MCP) folosind HTTPS. Sunt acoperite motivația pentru streaming, mecanismele de transport disponibile, modul de implementare a HTTP-ului streamabil în MCP, bune practici de securitate, migrarea de la SSE și ghiduri practice pentru construirea propriilor aplicații MCP cu streaming.

## Mecanisme de Transport și Streaming în MCP

Această secțiune explorează diferitele mecanisme de transport disponibile în MCP și rolul lor în activarea capacităților de streaming pentru comunicarea în timp real între clienți și servere.

### Ce este un Mecanism de Transport?

Un mecanism de transport definește modul în care datele sunt schimbate între client și server. MCP suportă mai multe tipuri de transport pentru a se potrivi diferitelor medii și cerințe:

- **stdio**: Intrare/ieșire standard, potrivit pentru unelte locale și bazate pe CLI. Simplu, dar nu potrivit pentru web sau cloud.
- **SSE (Server-Sent Events)**: Permite serverelor să trimită actualizări în timp real către clienți prin HTTP. Bun pentru interfețe web, dar limitat în scalabilitate și flexibilitate.
- **Streamable HTTP**: Transport modern bazat pe HTTP pentru streaming, care suportă notificări și o scalabilitate mai bună. Recomandat pentru majoritatea scenariilor de producție și cloud.

### Tabel de Comparare

Uitați-vă la tabelul de comparare de mai jos pentru a înțelege diferențele dintre aceste mecanisme de transport:

| Transport         | Actualizări în timp real | Streaming | Scalabilitate | Caz de utilizare          |
|-------------------|--------------------------|-----------|---------------|---------------------------|
| stdio             | Nu                       | Nu        | Scăzut       | Unelte CLI locale         |
| SSE               | Da                       | Da        | Mediu        | Web, actualizări în timp real |
| Streamable HTTP   | Da                       | Da        | Ridicat      | Cloud, multi-client       |

> **Tip:** Alegerea transportului potrivit influențează performanța, scalabilitatea și experiența utilizatorului. **Streamable HTTP** este recomandat pentru aplicații moderne, scalabile și pregătite pentru cloud.

Rețineți transporturile stdio și SSE prezentate în capitolele anterioare și faptul că în acest capitol este abordat transportul streamable HTTP.

## Streaming: Concepte și Motivație

Înțelegerea conceptelor fundamentale și a motivațiilor din spatele streaming-ului este esențială pentru implementarea unor sisteme eficiente de comunicare în timp real.

**Streaming-ul** este o tehnică în programarea de rețea care permite trimiterea și primirea datelor în bucăți mici, gestionabile sau ca o secvență de evenimente, în loc să se aștepte ca întregul răspuns să fie gata. Aceasta este utilă în special pentru:

- Fișiere sau seturi de date mari.
- Actualizări în timp real (ex. chat, bare de progres).
- Calculuri de durată lungă în care dorești să menții utilizatorul informat.

Iată ce trebuie să știi despre streaming la un nivel general:

- Datele sunt livrate progresiv, nu toate odată.
- Clientul poate procesa datele pe măsură ce sosesc.
- Reduce latența percepută și îmbunătățește experiența utilizatorului.

### De ce să folosești streaming?

Motivele pentru a folosi streaming sunt următoarele:

- Utilizatorii primesc feedback imediat, nu doar la final.
- Permite aplicații în timp real și interfețe responsabile.
- Folosește mai eficient resursele de rețea și calcul.

### Exemplu Simplu: Server & Client HTTP Streaming

Iată un exemplu simplu de implementare a streaming-ului:

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

Acest exemplu demonstrează un server care trimite o serie de mesaje către client pe măsură ce devin disponibile, în loc să aștepte ca toate mesajele să fie gata.

**Cum funcționează:**
- Serverul transmite fiecare mesaj pe măsură ce este gata.
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) în loc să aleagă streaming-ul prin MCP.

- **Pentru nevoi simple de streaming:** Streaming-ul HTTP clasic este mai simplu de implementat și suficient pentru cerințe de bază.

- **Pentru aplicații complexe, interactive:** Streaming-ul MCP oferă o abordare mai structurată, cu metadate mai bogate și separarea notificărilor de rezultatele finale.

- **Pentru aplicații AI:** Sistemul de notificări MCP este util în special pentru sarcini AI de durată lungă, unde dorești să ții utilizatorii informați despre progres.

## Streaming în MCP

Ok, ai văzut până acum recomandări și comparații între streaming-ul clasic și cel în MCP. Hai să vedem în detaliu cum poți valorifica streaming-ul în MCP.

Înțelegerea modului în care funcționează streaming-ul în cadrul MCP este esențială pentru a construi aplicații responsive care oferă feedback în timp real utilizatorilor în timpul operațiunilor de durată.

În MCP, streaming-ul nu înseamnă trimiterea răspunsului principal în bucăți, ci trimiterea de **notificări** către client în timp ce un instrument procesează o cerere. Aceste notificări pot include actualizări de progres, loguri sau alte evenimente.

### Cum funcționează

Rezultatul principal este trimis tot ca un răspuns unic. Totuși, notificările pot fi trimise ca mesaje separate în timpul procesării și astfel pot actualiza clientul în timp real. Clientul trebuie să poată gestiona și afișa aceste notificări.

## Ce este o Notificare?

Am menționat „Notificare”, ce înseamnă asta în contextul MCP?

O notificare este un mesaj trimis de server către client pentru a informa despre progres, stare sau alte evenimente în timpul unei operațiuni de durată lungă. Notificările sporesc transparența și experiența utilizatorului.

De exemplu, un client trebuie să trimită o notificare odată ce s-a realizat handshake-ul inițial cu serverul.

O notificare arată astfel ca mesaj JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notificările aparțin unui topic în MCP denumit ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Pentru a activa logging-ul, serverul trebuie să-l activeze ca funcționalitate/capabilitate astfel:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> În funcție de SDK-ul folosit, logging-ul poate fi activat implicit sau poate fi necesară activarea explicită în configurația serverului.

Există diferite tipuri de notificări:

| Nivel     | Descriere                     | Exemplu de utilizare             |
|-----------|-------------------------------|---------------------------------|
| debug     | Informații detaliate pentru depanare | Puncte de intrare/ieșire în funcții |
| info      | Mesaje informaționale generale | Actualizări de progres           |
| notice    | Evenimente normale, dar importante | Modificări de configurare        |
| warning   | Condiții de avertizare         | Utilizare de funcționalități depreciate |
| error     | Condiții de eroare             | Eșecuri în operațiuni            |
| critical  | Condiții critice               | Defecțiuni ale componentelor sistemului |
| alert     | Acțiune imediată necesară      | Detectare corupție de date       |
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

În exemplul precedent, transportul `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`:

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

În codul de mai sus, handler-ul `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` este implementat pentru a procesa notificările.

## Notificări de Progres & Scenarii

Această secțiune explică conceptul de notificări de progres în MCP, de ce sunt importante și cum să le implementezi folosind Streamable HTTP. Vei găsi și o sarcină practică pentru a-ți consolida înțelegerea.

Notificările de progres sunt mesaje în timp real trimise de server către client în timpul operațiunilor de durată. În loc să aștepte finalizarea întregului proces, serverul menține clientul informat despre starea curentă. Aceasta îmbunătățește transparența, experiența utilizatorului și facilitează depanarea.

**Exemplu:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### De ce să folosești notificări de progres?

Notificările de progres sunt esențiale din mai multe motive:

- **Experiență mai bună pentru utilizator:** Utilizatorii văd actualizări pe măsură ce lucrul progresează, nu doar la final.
- **Feedback în timp real:** Clienții pot afișa bare de progres sau loguri, făcând aplicația să pară mai receptivă.
- **Depanare și monitorizare mai ușoară:** Dezvoltatorii și utilizatorii pot vedea unde un proces este lent sau blocat.

### Cum să implementezi notificările de progres

Iată cum poți implementa notificările de progres în MCP:

- **Pe server:** Folosește `ctx.info()` or `ctx.log()` pentru a trimite notificări pe măsură ce fiecare element este procesat. Acest lucru trimite un mesaj clientului înainte ca rezultatul principal să fie gata.
- **Pe client:** Implementează un handler de mesaje care ascultă și afișează notificările pe măsură ce sosesc. Acest handler face diferența între notificări și rezultatul final.

**Exemplu Server:**

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

**Exemplu Client:**

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

Atunci când implementezi servere MCP cu transporturi bazate pe HTTP, securitatea devine o preocupare majoră care necesită atenție la multiple vectori de atac și mecanisme de protecție.

### Prezentare generală

Securitatea este critică când expui servere MCP prin HTTP. Streamable HTTP introduce noi suprafețe de atac și necesită configurare atentă.

### Puncte cheie
- **Validarea antetului Origin**: Validează întotdeauna `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` în locul clientului SSE.
3. **Implementează un handler de mesaje** în client pentru procesarea notificărilor.
4. **Testează compatibilitatea** cu uneltele și fluxurile de lucru existente.

### Menținerea Compatibilității

Este recomandat să menții compatibilitatea cu clienții SSE existenți pe durata procesului de migrare. Iată câteva strategii:

- Poți suporta atât SSE cât și Streamable HTTP rulând ambele transporturi pe endpoint-uri diferite.
- Migrează treptat clienții către noul transport.

### Provocări

Asigură-te că abordezi următoarele provocări în timpul migrației:

- Actualizarea tuturor clienților
- Gestionarea diferențelor în livrarea notificărilor

### Sarcină: Construiește-ți propria aplicație MCP cu streaming

**Scenariu:**
Construiește un server și un client MCP unde serverul procesează o listă de elemente (ex. fișiere sau documente) și trimite o notificare pentru fiecare element procesat. Clientul trebuie să afișeze fiecare notificare pe măsură ce sosește.

**Pași:**

1. Implementează un instrument server care procesează o listă și trimite notificări pentru fiecare element.
2. Implementează un client cu un handler de mesaje care afișează notificările în timp real.
3. Testează implementarea rulând serverul și clientul și observă notificările.

[Solution](./solution/README.md)

## Lecturi Suplimentare & Ce Urmează?

Pentru a continua călătoria ta cu streaming-ul MCP și a-ți extinde cunoștințele, această secțiune oferă resurse suplimentare și pași sugerați pentru construirea unor aplicații mai avansate.

### Lecturi suplimentare

- [Microsoft: Introducere în HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS în ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Ce urmează?

- Încearcă să construiești unelte MCP mai avansate care folosesc streaming pentru analize în timp real, chat sau editare colaborativă.
- Explorează integrarea streaming-ului MCP cu framework-uri frontend (React, Vue etc.) pentru actualizări live ale UI-ului.
- Următorul pas: [Utilizarea AI Toolkit pentru VSCode](../07-aitk/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să țineți cont că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea ca urmare a utilizării acestei traduceri.