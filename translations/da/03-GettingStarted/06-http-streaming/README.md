<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:12:26+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "da"
}
-->
# HTTPS Streaming med Model Context Protocol (MCP)

Dette kapitel giver en omfattende vejledning i at implementere sikker, skalerbar og realtids streaming med Model Context Protocol (MCP) ved hjælp af HTTPS. Det dækker motivationen for streaming, de tilgængelige transportmekanismer, hvordan man implementerer streambar HTTP i MCP, sikkerhedspraksis, migration fra SSE og praktisk vejledning til at bygge dine egne streaming MCP-applikationer.

## Transportmekanismer og streaming i MCP

Dette afsnit undersøger de forskellige transportmekanismer, der er tilgængelige i MCP, og deres rolle i at muliggøre streamingfunktioner til realtidskommunikation mellem klienter og servere.

### Hvad er en transportmekanisme?

En transportmekanisme definerer, hvordan data udveksles mellem klient og server. MCP understøtter flere transporttyper, der passer til forskellige miljøer og behov:

- **stdio**: Standard input/output, velegnet til lokale og CLI-baserede værktøjer. Simpelt, men ikke egnet til web eller cloud.
- **SSE (Server-Sent Events)**: Gør det muligt for servere at sende realtidsopdateringer til klienter over HTTP. Godt til web-UI’er, men begrænset i skalerbarhed og fleksibilitet.
- **Streamable HTTP**: Moderne HTTP-baseret streamingtransport, der understøtter notifikationer og bedre skalerbarhed. Anbefales til de fleste produktions- og cloudscenarier.

### Sammenligningstabel

Se nedenstående tabel for at forstå forskellene mellem disse transportmekanismer:

| Transport         | Realtidsopdateringer | Streaming | Skalerbarhed | Anvendelsestilfælde     |
|-------------------|----------------------|-----------|--------------|-------------------------|
| stdio             | Nej                  | Nej       | Lav          | Lokale CLI-værktøjer    |
| SSE               | Ja                   | Ja        | Middel       | Web, realtidsopdateringer |
| Streamable HTTP   | Ja                   | Ja        | Høj          | Cloud, multi-klient     |

> **Tip:** Valg af den rette transport påvirker ydeevne, skalerbarhed og brugeroplevelse. **Streamable HTTP** anbefales til moderne, skalerbare og cloud-klare applikationer.

Bemærk transporterne stdio og SSE, som du blev præsenteret for i de tidligere kapitler, og hvordan streambar HTTP er den transport, der dækkes i dette kapitel.

## Streaming: Begreber og motivation

Det er vigtigt at forstå de grundlæggende begreber og motivationen bag streaming for at kunne implementere effektive realtidskommunikationssystemer.

**Streaming** er en teknik inden for netværksprogrammering, der tillader data at blive sendt og modtaget i små, håndterbare bidder eller som en række hændelser, i stedet for at vente på, at hele svaret er klar. Dette er særligt nyttigt til:

- Store filer eller datasæt.
- Realtidsopdateringer (f.eks. chat, statusbjælker).
- Langvarige beregninger, hvor man ønsker at holde brugeren informeret.

Her er hvad du skal vide om streaming på et overordnet plan:

- Data leveres løbende, ikke alt på én gang.
- Klienten kan behandle data, efterhånden som det modtages.
- Reducerer oplevet ventetid og forbedrer brugeroplevelsen.

### Hvorfor bruge streaming?

Årsagerne til at bruge streaming er:

- Brugere får feedback med det samme, ikke kun til sidst.
- Muliggør realtidsapplikationer og responsive brugergrænseflader.
- Mere effektiv udnyttelse af netværks- og computerressourcer.

### Simpelt eksempel: HTTP Streaming Server & Klient

Her er et simpelt eksempel på, hvordan streaming kan implementeres:

<details>
<summary>Python</summary>

**Server (Python, med FastAPI og StreamingResponse):**
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

**Klient (Python, med requests):**
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
- Klienten modtager og udskriver hver del, når den ankommer.

**Krav:**
- Serveren skal bruge en streaming-respons (f.eks. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Server (Java, med Spring Boot og Server-Sent Events):**

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

**Klient (Java, med Spring WebFlux WebClient):**

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

**Noter om Java-implementering:**
- Bruger Spring Boots reaktive stack med `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) kontra valg af streaming via MCP.

- **Til simple streamingbehov:** Klassisk HTTP-streaming er nemmere at implementere og tilstrækkeligt til basale streamingbehov.

- **Til komplekse, interaktive applikationer:** MCP-streaming giver en mere struktureret tilgang med rigere metadata og adskillelse mellem notifikationer og endelige resultater.

- **Til AI-applikationer:** MCP’s notifikationssystem er særligt nyttigt til langvarige AI-opgaver, hvor man ønsker at holde brugerne opdateret om fremdriften.

## Streaming i MCP

Ok, så du har set nogle anbefalinger og sammenligninger indtil nu om forskellen mellem klassisk streaming og streaming i MCP. Lad os gå i detaljer med, hvordan du præcist kan udnytte streaming i MCP.

Det er vigtigt at forstå, hvordan streaming fungerer inden for MCP-rammen for at bygge responsive applikationer, der giver realtidsfeedback til brugere under langvarige processer.

I MCP handler streaming ikke om at sende hovedsvaret i bidder, men om at sende **notifikationer** til klienten, mens et værktøj behandler en forespørgsel. Disse notifikationer kan indeholde statusopdateringer, logs eller andre hændelser.

### Sådan fungerer det

Hovedresultatet sendes stadig som et enkelt svar. Dog kan notifikationer sendes som separate beskeder under behandlingen og dermed opdatere klienten i realtid. Klienten skal kunne håndtere og vise disse notifikationer.

## Hvad er en notifikation?

Vi nævnte "notifikation" – hvad betyder det i MCP-kontekst?

En notifikation er en besked sendt fra serveren til klienten for at informere om fremdrift, status eller andre hændelser under en langvarig operation. Notifikationer øger gennemsigtighed og forbedrer brugeroplevelsen.

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

Notifikationer tilhører et emne i MCP kaldet ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

For at få logging til at fungere, skal serveren aktivere det som en feature/evne på denne måde:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Afhængigt af hvilken SDK der bruges, kan logging være aktiveret som standard, eller du skal eksplicit aktivere det i din serverkonfiguration.

Der findes forskellige typer notifikationer:

| Niveau    | Beskrivelse                  | Eksempel på brug             |
|-----------|-----------------------------|-----------------------------|
| debug     | Detaljeret fejlsøgningsinfo | Funktionsindgang/udgang      |
| info      | Generelle informationsbeskeder | Opdateringer om fremdrift    |
| notice    | Almindelige, men vigtige hændelser | Ændringer i konfiguration    |
| warning   | Advarsler                   | Brug af forældede funktioner |
| error     | Fejltilstande               | Fejl i operationer           |
| critical  | Kritiske tilstande          | Systemkomponentfejl          |
| alert     | Handling skal udføres straks | Data korruption opdaget      |
| emergency | Systemet er ubrugeligt      | Total systemfejl             |

## Implementering af notifikationer i MCP

For at implementere notifikationer i MCP skal du konfigurere både server- og klientsiden til at håndtere realtidsopdateringer. Det giver din applikation mulighed for at give øjeblikkelig feedback til brugere under langvarige operationer.

### Server-side: Afsendelse af notifikationer

Lad os starte med serversiden. I MCP definerer du værktøjer, der kan sende notifikationer under behandlingen af forespørgsler. Serveren bruger kontekstobjektet (typisk `ctx`) til at sende beskeder til klienten.

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

I det foregående eksempel bruger `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transporten:

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

I dette .NET-eksempel bruges metoden `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` til at sende informationsbeskeder.

For at aktivere notifikationer i din .NET MCP-server, skal du sikre, at du bruger en streamingtransport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Klient-side: Modtagelse af notifikationer

Klienten skal implementere en beskedbehandler til at behandle og vise notifikationer, efterhånden som de modtages.

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

I koden ovenfor bruges `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` til at håndtere indkommende notifikationer.

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

I dette .NET-eksempel implementerer klienten en beskedbehandler til at behandle notifikationer ved hjælp af `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`.

## Fremdriftsnotifikationer & scenarier

Dette afsnit forklarer begrebet fremdriftsnotifikationer i MCP, hvorfor de er vigtige, og hvordan man implementerer dem med Streamable HTTP. Du finder også en praktisk opgave til at styrke din forståelse.

Fremdriftsnotifikationer er realtidsbeskeder sendt fra server til klient under langvarige operationer. I stedet for at vente på, at hele processen er færdig, holder serveren klienten opdateret om den aktuelle status. Dette øger gennemsigtighed, forbedrer brugeroplevelsen og gør fejlfinding nemmere.

**Eksempel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Hvorfor bruge fremdriftsnotifikationer?

Fremdriftsnotifikationer er vigtige af flere grunde:

- **Bedre brugeroplevelse:** Brugerne ser opdateringer løbende, ikke kun til sidst.
- **Realtidsfeedback:** Klienter kan vise statusbjælker eller logs, hvilket gør appen mere responsiv.
- **Nemmere fejlfinding og overvågning:** Udviklere og brugere kan se, hvor en proces eventuelt er langsom eller hænger.

### Sådan implementeres fremdriftsnotifikationer

Sådan kan du implementere fremdriftsnotifikationer i MCP:

- **På serveren:** Brug `ctx.info()` or `ctx.log()` til at sende notifikationer, efterhånden som hvert element behandles. Dette sender beskeder til klienten, inden hovedresultatet er klar.
- **På klienten:** Implementer en beskedbehandler, der lytter efter og viser notifikationer, efterhånden som de modtages. Denne handler skelner mellem notifikationer og det endelige resultat.

**Servereksempel:**

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

**Klienteksempel:**

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

Når man implementerer MCP-servere med HTTP-baserede transport, bliver sikkerhed en altafgørende faktor, der kræver opmærksomhed på flere angrebsvinkler og beskyttelsesmekanismer.

### Oversigt

Sikkerhed er kritisk, når MCP-servere eksponeres over HTTP. Streamable HTTP introducerer nye angrebsoverflader og kræver omhyggelig konfiguration.

### Nøglepunkter
- **Validering af Origin-header:** Valider altid `Origin`-headeren for at forhindre CORS-relaterede angreb.
- **Brug HTTPS:** Sørg for, at al kommunikation foregår over sikre forbindelser.
- **Autentificering og autorisation:** Implementer passende sikkerhedsforanstaltninger for at beskytte adgang.
- **Begrænsning af ressourcer:** Beskyt serveren mod overbelastning og DoS-angreb ved hjælp af rate limiting.
- **Hold software opdateret:** Sørg for, at alle komponenter er opdaterede med de nyeste sikkerhedsrettelser.

### Vedligeholdelse af kompatibilitet

Det anbefales at bevare kompatibilitet med eksisterende SSE-klienter under migrationsprocessen. Her er nogle strategier:

- Du kan understøtte både SSE og Streamable HTTP ved at køre begge transporttyper på forskellige endpoints.
- Migrer klienter gradvist til den nye transport.

### Udfordringer

Sørg for at håndtere følgende udfordringer under migrationen:

- At alle klienter bliver opdateret.
- Håndtering af forskelle i levering af notifikationer.

### Opgave: Byg din egen streaming MCP-app

**Scenarie:**
Byg en MCP-server og klient, hvor serveren behandler en liste af elementer (f.eks. filer eller dokumenter) og sender en notifikation for hvert behandlede element. Klienten skal vise hver notifikation, efterhånden som den modtages.

**Trin:**

1. Implementer et serverværktøj, der behandler en liste og sender notifikationer for hvert element.
2. Implementer en klient med en beskedbehandler, der viser notifikationer i realtid.
3. Test din implementering ved at køre både server og klient og observere notifikationerne.

[Løsning](./solution/README.md)

## Yderligere læsning & hvad nu?

For at fortsætte din rejse med MCP-streaming og udvide din viden, giver dette afsnit ekstra ressourcer og forslag til næste skridt i opbygningen af mere avancerede applikationer.

### Yderligere læsning

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Hvad nu?

- Prøv at bygge mere avancerede MCP-værktøjer, der bruger streaming til realtidsanalyse, chat eller samarbejdende redigering.
- Undersøg integration af MCP-streaming med frontend-rammer (React, Vue osv.) for live UI-opdateringer.
- Næste: [Udnyttelse af AI Toolkit for VSCode](../07-aitk/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.