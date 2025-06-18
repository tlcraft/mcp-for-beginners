<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:13:18+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "no"
}
-->
# HTTPS Streaming med Model Context Protocol (MCP)

Dette kapitlet gir en grundig veiledning for å implementere sikker, skalerbar og sanntids streaming med Model Context Protocol (MCP) ved bruk av HTTPS. Det dekker motivasjonen for streaming, tilgjengelige transportmekanismer, hvordan man implementerer streambar HTTP i MCP, sikkerhetsanbefalinger, migrasjon fra SSE, og praktiske råd for å bygge egne streaming MCP-applikasjoner.

## Transportmekanismer og streaming i MCP

Denne delen utforsker de ulike transportmekanismene som finnes i MCP og deres rolle i å muliggjøre streaming for sanntidskommunikasjon mellom klienter og servere.

### Hva er en transportmekanisme?

En transportmekanisme definerer hvordan data utveksles mellom klient og server. MCP støtter flere transporttyper for å passe til ulike miljøer og behov:

- **stdio**: Standard input/output, egnet for lokale og CLI-baserte verktøy. Enkelt, men ikke egnet for web eller sky.
- **SSE (Server-Sent Events)**: Lar servere sende sanntidsoppdateringer til klienter over HTTP. Bra for webgrensesnitt, men begrenset i skalerbarhet og fleksibilitet.
- **Streamable HTTP**: Moderne HTTP-basert streamingtransport, støtter varsler og bedre skalerbarhet. Anbefales for de fleste produksjons- og skyløsninger.

### Sammenligningstabell

Se på tabellen under for å forstå forskjellene mellom disse transportmekanismene:

| Transport         | Sanntidsoppdateringer | Streaming | Skalerbarhet | Bruksområde              |
|-------------------|-----------------------|-----------|--------------|--------------------------|
| stdio             | Nei                   | Nei       | Lav          | Lokale CLI-verktøy       |
| SSE               | Ja                    | Ja        | Middels      | Web, sanntidsoppdateringer |
| Streamable HTTP   | Ja                    | Ja        | Høy          | Sky, flere klienter      |

> **Tip:** Valg av riktig transport påvirker ytelse, skalerbarhet og brukeropplevelse. **Streamable HTTP** anbefales for moderne, skalerbare og sky-klare applikasjoner.

Merk transportene stdio og SSE som du ble vist i tidligere kapitler, og hvordan streambar HTTP er transporten som dekkes i dette kapitlet.

## Streaming: Konsepter og motivasjon

Å forstå grunnleggende konsepter og motivasjonen bak streaming er viktig for å implementere effektive sanntidskommunikasjonssystemer.

**Streaming** er en teknikk innen nettverksprogrammering som lar data sendes og mottas i små, håndterbare deler eller som en sekvens av hendelser, i stedet for å vente på at hele svaret skal være klart. Dette er spesielt nyttig for:

- Store filer eller datasett.
- Sanntidsoppdateringer (f.eks. chat, fremdriftsindikatorer).
- Langvarige beregninger hvor du vil holde brukeren informert.

Her er det viktigste å vite om streaming på et overordnet nivå:

- Data leveres gradvis, ikke alt på en gang.
- Klienten kan behandle data etter hvert som det kommer.
- Reduserer opplevd ventetid og forbedrer brukeropplevelsen.

### Hvorfor bruke streaming?

Årsakene til å bruke streaming er følgende:

- Brukere får umiddelbar tilbakemelding, ikke bare til slutt
- Muliggjør sanntidsapplikasjoner og responsive brukergrensesnitt
- Mer effektiv bruk av nettverk og ressurser

### Enkelt eksempel: HTTP streaming server og klient

Her er et enkelt eksempel på hvordan streaming kan implementeres:

<details>
<summary>Python</summary>

**Server (Python, bruker FastAPI og StreamingResponse):**
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

**Klient (Python, bruker requests):**
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

Dette eksemplet viser en server som sender en serie meldinger til klienten etter hvert som de blir tilgjengelige, i stedet for å vente på at alle meldingene er klare.

**Hvordan det fungerer:**
- Serveren sender hver melding etter hvert som den er klar.
- Klienten mottar og skriver ut hver del så snart den kommer.

**Krav:**
- Serveren må bruke en streamingrespons (f.eks. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, bruker Spring Boot og Server-Sent Events):**

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

**Klient (Java, bruker Spring WebFlux WebClient):**

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

**Notater om Java-implementering:**
- Bruker Spring Boot sin reaktive stack med `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) kontra å velge streaming via MCP.

- **For enkle streamingbehov:** Klassisk HTTP-streaming er enklere å implementere og tilstrekkelig for grunnleggende streaming.

- **For komplekse, interaktive applikasjoner:** MCP-streaming gir en mer strukturert tilnærming med rikere metadata og separasjon mellom varsler og endelige resultater.

- **For AI-applikasjoner:** MCP sitt varslingssystem er spesielt nyttig for langvarige AI-oppgaver hvor man ønsker å holde brukerne informert om fremdrift.

## Streaming i MCP

Ok, så du har sett noen anbefalinger og sammenligninger så langt om forskjellen mellom klassisk streaming og streaming i MCP. La oss gå i detalj på hvordan du kan utnytte streaming i MCP.

Å forstå hvordan streaming fungerer innen MCP-rammeverket er essensielt for å bygge responsive applikasjoner som gir sanntids tilbakemelding til brukere under langvarige operasjoner.

I MCP handler streaming ikke om å sende hovedsvaret i biter, men om å sende **varsler** til klienten mens et verktøy behandler en forespørsel. Disse varslene kan inkludere fremdriftsoppdateringer, logger eller andre hendelser.

### Hvordan det fungerer

Hovedresultatet sendes fortsatt som ett enkelt svar. Varsler kan derimot sendes som separate meldinger under behandlingen, og oppdatere klienten i sanntid. Klienten må kunne håndtere og vise disse varslene.

## Hva er et varsel?

Vi nevnte "varsel" – hva betyr det i MCP-sammenheng?

Et varsel er en melding sendt fra server til klient for å informere om fremdrift, status eller andre hendelser under en langvarig operasjon. Varsler øker åpenhet og forbedrer brukeropplevelsen.

For eksempel skal en klient sende et varsel når den innledende håndtrykk-prosessen med serveren er fullført.

Et varsel ser slik ut som en JSON-melding:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Varsler tilhører et tema i MCP kalt ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

For å få logging til å fungere, må serveren aktivere det som en funksjon/kapabilitet slik:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Avhengig av SDK som brukes, kan logging være aktivert som standard, eller du må eksplisitt aktivere det i serverkonfigurasjonen.

Det finnes ulike typer varsler:

| Nivå      | Beskrivelse                   | Eksempel på bruk               |
|-----------|------------------------------|-------------------------------|
| debug     | Detaljert feilsøkingsinfo    | Funksjonsinngang/utgang       |
| info      | Generelle informasjonsmeldinger | Oppdateringer om fremdrift    |
| notice    | Normale, men viktige hendelser | Konfigurasjonsendringer       |
| warning   | Advarsler                    | Bruk av foreldet funksjon     |
| error     | Feil                        | Operasjonsfeil                |
| critical  | Kritiske feil                | Systemkomponentfeil           |
| alert     | Umiddelbar handling kreves  | Datakorrupt oppdaget          |
| emergency | Systemet er ubrukelig       | Fullstendig systemsvikt       |

## Implementering av varsler i MCP

For å implementere varsler i MCP må du sette opp både server- og klientsiden for å håndtere sanntidsoppdateringer. Dette lar applikasjonen gi umiddelbar tilbakemelding til brukere under langvarige operasjoner.

### Server-side: Sende varsler

La oss starte med serversiden. I MCP definerer du verktøy som kan sende varsler mens de behandler forespørsler. Serveren bruker kontekstobjektet (vanligvis `ctx`) for å sende meldinger til klienten.

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

I eksemplet over bruker `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

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

I dette .NET-eksemplet brukes metoden `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` for å sende informasjonsmeldinger.

For å aktivere varsler i din .NET MCP-server, sørg for å bruke en streaming-transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Klient-side: Mottak av varsler

Klienten må implementere en meldingsbehandler som prosesserer og viser varsler etter hvert som de kommer.

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

I koden over bruker `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` for å håndtere innkommende varsler.

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

I dette .NET-eksemplet bruker `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) og klienten implementerer en meldingsbehandler for å håndtere varsler.

## Fremdriftsvarsler og scenarier

Denne delen forklarer konseptet med fremdriftsvarsler i MCP, hvorfor de er viktige, og hvordan de implementeres med Streamable HTTP. Du finner også en praktisk oppgave for å styrke forståelsen.

Fremdriftsvarsler er sanntidsmeldinger sendt fra server til klient under langvarige operasjoner. I stedet for å vente på at hele prosessen skal fullføres, holder serveren klienten oppdatert om status. Dette gir bedre åpenhet, brukeropplevelse og gjør feilsøking enklere.

**Eksempel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Hvorfor bruke fremdriftsvarsler?

Fremdriftsvarsler er viktige av flere grunner:

- **Bedre brukeropplevelse:** Brukere ser oppdateringer mens arbeidet pågår, ikke bare til slutt.
- **Sanntids tilbakemelding:** Klienter kan vise fremdriftsindikatorer eller logger, som gjør appen mer responsiv.
- **Enklere feilsøking og overvåking:** Utviklere og brukere kan se hvor en prosess eventuelt er treg eller står fast.

### Hvordan implementere fremdriftsvarsler

Slik kan du implementere fremdriftsvarsler i MCP:

- **På serveren:** Bruk `ctx.info()` or `ctx.log()` for å sende varsler etter hvert som hvert element behandles. Dette sender meldinger til klienten før hovedresultatet er klart.
- **På klienten:** Implementer en meldingsbehandler som lytter etter og viser varsler etter hvert som de kommer. Denne skiller mellom varsler og det endelige resultatet.

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

## Sikkerhetshensyn

Når man implementerer MCP-servere med HTTP-baserte transporter, blir sikkerhet en avgjørende faktor som krever nøye vurdering av ulike angrepsvektorer og beskyttelsesmekanismer.

### Oversikt

Sikkerhet er kritisk når MCP-servere eksponeres over HTTP. Streamable HTTP introduserer nye angrepsflater og krever nøye konfigurasjon.

### Viktige punkter
- **Validering av Origin-header**: Alltid valider `Origin` header to prevent DNS rebinding attacks.
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
3. **Implementer en meldingsbehandler** i klienten for å håndtere varsler.
4. **Test for kompatibilitet** med eksisterende verktøy og arbeidsflyter.

### Opprettholde kompatibilitet

Det anbefales å opprettholde kompatibilitet med eksisterende SSE-klienter under migreringsprosessen. Her er noen strategier:

- Du kan støtte både SSE og Streamable HTTP ved å kjøre begge transportene på forskjellige endepunkter.
- Migrer klienter gradvis til den nye transporten.

### Utfordringer

Sørg for å håndtere følgende utfordringer under migrasjon:

- Sikre at alle klienter oppdateres
- Håndtere forskjeller i levering av varsler

### Oppgave: Bygg din egen streaming MCP-app

**Scenario:**
Bygg en MCP-server og klient hvor serveren behandler en liste med elementer (f.eks. filer eller dokumenter) og sender et varsel for hvert behandlede element. Klienten skal vise hvert varsel så snart det kommer.

**Steg:**

1. Implementer et serververktøy som behandler en liste og sender varsler for hvert element.
2. Implementer en klient med en meldingsbehandler som viser varsler i sanntid.
3. Test implementasjonen ved å kjøre både server og klient, og observer varslene.

[Løsning](./solution/README.md)

## Videre lesning og hva nå?

For å fortsette reisen med MCP-streaming og utvide kunnskapen, gir denne delen flere ressurser og forslag til neste steg for å bygge mer avanserte applikasjoner.

### Videre lesning

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Hva nå?

- Prøv å bygge mer avanserte MCP-verktøy som bruker streaming for sanntidsanalyse, chat eller samarbeidende redigering.
- Utforsk integrasjon av MCP-streaming med frontend-rammeverk (React, Vue, osv.) for live UI-oppdateringer.
- Neste: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på dets opprinnelige språk skal betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.