<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:44:03+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "da"
}
-->
# HTTPS Streaming med Model Context Protocol (MCP)

Dette kapitel giver en omfattende vejledning til at implementere sikker, skalerbar og realtids streaming med Model Context Protocol (MCP) ved brug af HTTPS. Det dækker motivationen for streaming, tilgængelige transportmekanismer, hvordan man implementerer streambar HTTP i MCP, bedste sikkerhedspraksis, migrering fra SSE samt praktisk vejledning til at bygge dine egne streaming MCP-applikationer.

## Transportmekanismer og Streaming i MCP

Denne sektion undersøger de forskellige transportmekanismer, der er tilgængelige i MCP, og deres rolle i at muliggøre streamingfunktioner til realtidskommunikation mellem klienter og servere.

### Hvad er en Transportmekanisme?

En transportmekanisme definerer, hvordan data udveksles mellem klient og server. MCP understøtter flere transporttyper for at passe til forskellige miljøer og behov:

- **stdio**: Standard input/output, egnet til lokale og CLI-baserede værktøjer. Simpelt, men ikke egnet til web eller cloud.
- **SSE (Server-Sent Events)**: Tillader servere at sende realtidsopdateringer til klienter over HTTP. Godt til web-brugerflader, men begrænset i skalerbarhed og fleksibilitet.
- **Streamable HTTP**: Moderne HTTP-baseret streamingtransport, som understøtter notifikationer og bedre skalerbarhed. Anbefales til de fleste produktions- og cloud-scenarier.

### Sammenligningstabel

Se nedenstående sammenligningstabel for at forstå forskellene mellem disse transportmekanismer:

| Transport         | Realtidsopdateringer | Streaming | Skalerbarhed | Anvendelsestilfælde         |
|-------------------|----------------------|-----------|--------------|-----------------------------|
| stdio             | Nej                  | Nej       | Lav          | Lokale CLI-værktøjer        |
| SSE               | Ja                   | Ja        | Middel       | Web, realtidsopdateringer   |
| Streamable HTTP   | Ja                   | Ja        | Høj          | Cloud, multi-klient         |

> **Tip:** Valget af transport påvirker ydeevne, skalerbarhed og brugeroplevelse. **Streamable HTTP** anbefales til moderne, skalerbare og cloud-klare applikationer.

Bemærk transporterne stdio og SSE, som du så i de tidligere kapitler, og hvordan streambar HTTP er den transport, der dækkes i dette kapitel.

## Streaming: Begreber og Motivation

At forstå de grundlæggende begreber og motivationen bag streaming er essentielt for at implementere effektive realtidskommunikationssystemer.

**Streaming** er en teknik inden for netværksprogrammering, der tillader data at blive sendt og modtaget i små, håndterbare bidder eller som en sekvens af hændelser, i stedet for at vente på, at hele svaret er klar. Dette er især nyttigt for:

- Store filer eller datasæt.
- Realtidsopdateringer (f.eks. chat, fremdriftsindikatorer).
- Langvarige beregninger, hvor man ønsker at holde brugeren informeret.

Her er hvad du skal vide om streaming på et overordnet plan:

- Data leveres løbende, ikke alt på én gang.
- Klienten kan behandle data, efterhånden som det ankommer.
- Reducerer opfattet ventetid og forbedrer brugeroplevelsen.

### Hvorfor bruge streaming?

Årsagerne til at bruge streaming er følgende:

- Brugere får feedback med det samme, ikke kun til sidst
- Muliggør realtidsapplikationer og responsive brugerflader
- Mere effektiv udnyttelse af netværks- og computerressourcer

### Simpelt eksempel: HTTP Streaming Server & Client

Her er et simpelt eksempel på, hvordan streaming kan implementeres:

<details>
<summary>Python</summary>

**Server (Python, bruger FastAPI og StreamingResponse):**
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

**Client (Python, bruger requests):**
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

Dette eksempel viser en server, der sender en række beskeder til klienten, efterhånden som de bliver tilgængelige, i stedet for at vente på, at alle beskeder er klar.

**Sådan fungerer det:**
- Serveren leverer hver besked, når den er klar.
- Klienten modtager og printer hver del, efterhånden som den ankommer.

**Krav:**
- Serveren skal bruge en streaming-respons (f.eks. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) fremfor at vælge streaming via MCP.

- **Til simple streamingbehov:** Klassisk HTTP streaming er nemmere at implementere og tilstrækkeligt til grundlæggende streaming.

- **Til komplekse, interaktive applikationer:** MCP streaming giver en mere struktureret tilgang med rigere metadata og adskillelse mellem notifikationer og endelige resultater.

- **Til AI-applikationer:** MCP’s notifikationssystem er særligt nyttigt til langvarige AI-opgaver, hvor man ønsker at holde brugerne opdaterede om fremskridt.

## Streaming i MCP

Ok, så du har set nogle anbefalinger og sammenligninger indtil videre om forskellen mellem klassisk streaming og streaming i MCP. Lad os gå i dybden med, hvordan du præcist kan udnytte streaming i MCP.

At forstå, hvordan streaming fungerer inden for MCP-rammen, er afgørende for at bygge responsive applikationer, der giver realtidsfeedback til brugere under langvarige operationer.

I MCP handler streaming ikke om at sende hovedsvaret i bidder, men om at sende **notifikationer** til klienten, mens et værktøj behandler en anmodning. Disse notifikationer kan inkludere statusopdateringer, logs eller andre hændelser.

### Sådan fungerer det

Hovedresultatet sendes stadig som ét samlet svar. Notifikationer kan dog sendes som separate beskeder under behandlingen og dermed opdatere klienten i realtid. Klienten skal kunne håndtere og vise disse notifikationer.

## Hvad er en Notifikation?

Vi sagde "Notifikation" – hvad betyder det i MCP-sammenhæng?

En notifikation er en besked sendt fra serveren til klienten for at informere om fremskridt, status eller andre hændelser under en langvarig operation. Notifikationer øger gennemsigtighed og forbedrer brugeroplevelsen.

For eksempel skal en klient sende en notifikation, når den indledende håndtryk med serveren er gennemført.

En notifikation ser således ud som en JSON-besked:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifikationer hører til et emne i MCP kaldet ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

For at få logging til at fungere, skal serveren aktivere det som en feature/kapabilitet på denne måde:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Afhængigt af den anvendte SDK kan logging være aktiveret som standard, eller du skal eksplicit aktivere det i din serverkonfiguration.

Der findes forskellige typer notifikationer:

| Niveau     | Beskrivelse                   | Eksempel på anvendelse        |
|------------|------------------------------|-------------------------------|
| debug      | Detaljeret debugging-info    | Funktioners start-/slutpunkter|
| info       | Generelle informationsbeskeder| Opdateringer om operationens fremdrift |
| notice     | Normale, men væsentlige hændelser | Ændringer i konfiguration     |
| warning    | Advarsler                    | Brug af forældede funktioner  |
| error      | Fejltilstande                | Fejl i operationer            |
| critical   | Kritiske tilstande           | Systemkomponentfejl           |
| alert      | Handling skal foretages straks| Data korruption opdaget       |
| emergency  | Systemet er ubrugeligt       | Fuldstændig systemnedbrud     |

## Implementering af Notifikationer i MCP

For at implementere notifikationer i MCP skal du konfigurere både server- og klientsiden til at håndtere realtidsopdateringer. Dette gør det muligt for din applikation at give øjeblikkelig feedback til brugere under langvarige operationer.

### Server-side: Afsendelse af Notifikationer

Lad os starte med serversiden. I MCP definerer du værktøjer, der kan sende notifikationer, mens de behandler anmodninger. Serveren bruger kontekstobjektet (typisk `ctx`) til at sende beskeder til klienten.

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

I det forrige eksempel bruger `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transporten:

```python
mcp.run(transport="streamable-http")
```

</details>

### Client-side: Modtagelse af Notifikationer

Klienten skal implementere en beskedbehandler til at bearbejde og vise notifikationer, efterhånden som de ankommer.

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

I den foregående kode bruger `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) din klient en beskedbehandler til at håndtere notifikationer.

## Fremskridtsnotifikationer & Scenarier

Denne sektion forklarer begrebet fremskridtsnotifikationer i MCP, hvorfor de er vigtige, og hvordan man implementerer dem ved hjælp af Streamable HTTP. Du finder også en praktisk opgave til at styrke din forståelse.

Fremskridtsnotifikationer er realtidsbeskeder sendt fra serveren til klienten under langvarige operationer. I stedet for at vente på, at hele processen er færdig, holder serveren klienten opdateret om den aktuelle status. Dette øger gennemsigtigheden, forbedrer brugeroplevelsen og gør fejlfinding lettere.

**Eksempel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Hvorfor bruge fremskridtsnotifikationer?

Fremskridtsnotifikationer er vigtige af flere grunde:

- **Bedre brugeroplevelse:** Brugerne ser opdateringer løbende, ikke kun til sidst.
- **Realtidsfeedback:** Klienter kan vise fremdriftsindikatorer eller logs, hvilket gør appen mere responsiv.
- **Nemmere fejlfinding og overvågning:** Udviklere og brugere kan se, hvor en proces måske går langsomt eller sidder fast.

### Sådan implementeres fremskridtsnotifikationer

Sådan kan du implementere fremskridtsnotifikationer i MCP:

- **På serveren:** Brug `ctx.info()` or `ctx.log()` til at sende notifikationer, efterhånden som hvert element behandles. Dette sender en besked til klienten, inden hovedresultatet er klart.
- **På klienten:** Implementer en beskedbehandler, der lytter efter og viser notifikationer, efterhånden som de ankommer. Denne håndtering skelner mellem notifikationer og det endelige resultat.

**Server-eksempel:**

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

**Klient-eksempel:**

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

## Sikkerhedsovervejelser

Når man implementerer MCP-servere med HTTP-baserede transporter, bliver sikkerhed en altafgørende faktor, som kræver omhyggelig opmærksomhed på flere angrebsoverflader og beskyttelsesmekanismer.

### Oversigt

Sikkerhed er kritisk, når MCP-servere eksponeres over HTTP. Streamable HTTP introducerer nye angrebsoverflader og kræver nøje konfiguration.

### Vigtige punkter
- **Validering af Origin-header:** Sørg altid for at validere `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` i stedet for SSE-klient.
3. **Implementer en beskedbehandler** i klienten til at håndtere notifikationer.
4. **Test for kompatibilitet** med eksisterende værktøjer og arbejdsgange.

### Opretholdelse af kompatibilitet

Det anbefales at bevare kompatibilitet med eksisterende SSE-klienter under migreringsprocessen. Her er nogle strategier:

- Du kan understøtte både SSE og Streamable HTTP ved at køre begge transporttyper på forskellige endepunkter.
- Migrer klienter gradvist til den nye transport.

### Udfordringer

Sørg for at håndtere følgende udfordringer under migreringen:

- Sikre at alle klienter opdateres
- Håndtere forskelle i levering af notifikationer

### Opgave: Byg din egen streaming MCP-app

**Scenarie:**
Byg en MCP-server og klient, hvor serveren behandler en liste af elementer (f.eks. filer eller dokumenter) og sender en notifikation for hvert behandlede element. Klienten skal vise hver notifikation, efterhånden som den modtages.

**Trin:**

1. Implementer et serverværktøj, der behandler en liste og sender notifikationer for hvert element.
2. Implementer en klient med en beskedbehandler, der viser notifikationer i realtid.
3. Test din implementering ved at køre både server og klient, og observer notifikationerne.

[Løsning](./solution/README.md)

## Yderligere læsning & Hvad nu?

For at fortsætte din rejse med MCP streaming og udvide din viden giver denne sektion yderligere ressourcer og foreslåede næste skridt til at bygge mere avancerede applikationer.

### Yderligere læsning

- [Microsoft: Introduktion til HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS i ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Hvad nu?

- Prøv at bygge mere avancerede MCP-værktøjer, der bruger streaming til realtidsanalyse, chat eller samarbejdende redigering.
- Udforsk integration af MCP streaming med frontend-rammer (React, Vue osv.) for live UI-opdateringer.
- Næste: [Udnyttelse af AI Toolkit til VSCode](../07-aitk/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.