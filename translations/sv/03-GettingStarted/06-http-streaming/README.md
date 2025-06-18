<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:11:03+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sv"
}
-->
# HTTPS Streaming med Model Context Protocol (MCP)

Det här kapitlet ger en omfattande guide för att implementera säker, skalbar och realtidsströmning med Model Context Protocol (MCP) över HTTPS. Det täcker motivationen för streaming, tillgängliga transportmekanismer, hur man implementerar streambar HTTP i MCP, säkerhetsrutiner, migrering från SSE och praktiska råd för att bygga egna streaming-MCP-applikationer.

## Transportmekanismer och Streaming i MCP

Denna sektion utforskar de olika transportmekanismer som finns i MCP och deras roll för att möjliggöra streamingfunktioner för realtidskommunikation mellan klienter och servrar.

### Vad är en transportmekanism?

En transportmekanism definierar hur data utbyts mellan klient och server. MCP stöder flera typer av transporter för att passa olika miljöer och behov:

- **stdio**: Standard in-/utmatning, lämplig för lokala och CLI-baserade verktyg. Enkel men inte lämplig för webben eller molnet.
- **SSE (Server-Sent Events)**: Tillåter servrar att skicka realtidsuppdateringar till klienter över HTTP. Bra för webbgränssnitt, men begränsad i skalbarhet och flexibilitet.
- **Streamable HTTP**: Modern HTTP-baserad streamingtransport som stödjer notifieringar och bättre skalbarhet. Rekommenderas för de flesta produktions- och molnscenarier.

### Jämförelsetabell

Ta en titt på jämförelsetabellen nedan för att förstå skillnaderna mellan dessa transportmekanismer:

| Transport         | Realtidsuppdateringar | Streaming | Skalbarhet | Användningsområde          |
|-------------------|-----------------------|-----------|------------|---------------------------|
| stdio             | Nej                   | Nej       | Låg        | Lokala CLI-verktyg        |
| SSE               | Ja                    | Ja        | Medel      | Webb, realtidsuppdateringar|
| Streamable HTTP   | Ja                    | Ja        | Hög        | Moln, multi-klient        |

> **Tip:** Valet av rätt transport påverkar prestanda, skalbarhet och användarupplevelse. **Streamable HTTP** rekommenderas för moderna, skalbara och molnanpassade applikationer.

Observera transporterna stdio och SSE som visades i tidigare kapitel och hur streambar HTTP är den transport som behandlas i detta kapitel.

## Streaming: Koncept och Motivation

Att förstå grundläggande koncept och motivation bakom streaming är avgörande för att implementera effektiva realtidskommunikationssystem.

**Streaming** är en teknik inom nätverksprogrammering som tillåter data att skickas och tas emot i små, hanterbara delar eller som en sekvens av händelser, istället för att vänta på att hela svaret ska vara färdigt. Detta är särskilt användbart för:

- Stora filer eller datamängder.
- Realtidsuppdateringar (t.ex. chatt, progressionsindikatorer).
- Långvariga beräkningar där du vill hålla användaren informerad.

Här är vad du behöver veta om streaming på en övergripande nivå:

- Data levereras successivt, inte allt på en gång.
- Klienten kan bearbeta data allt eftersom det anländer.
- Minskar upplevd fördröjning och förbättrar användarupplevelsen.

### Varför använda streaming?

Anledningarna till att använda streaming är följande:

- Användare får omedelbar återkoppling, inte bara i slutet.
- Möjliggör realtidsapplikationer och responsiva användargränssnitt.
- Effektivare användning av nätverks- och beräkningsresurser.

### Enkelt exempel: HTTP Streaming Server & Klient

Här är ett enkelt exempel på hur streaming kan implementeras:

<details>
<summary>Python</summary>

**Server (Python, med FastAPI och StreamingResponse):**
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

Detta exempel visar en server som skickar en serie meddelanden till klienten när de blir tillgängliga, istället för att vänta på att alla meddelanden ska vara färdiga.

**Hur det fungerar:**
- Servern levererar varje meddelande när det är klart.
- Klienten tar emot och skriver ut varje del så fort den anländer.

**Krav:**
- Servern måste använda en streamad respons (t.ex. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, med Spring Boot och Server-Sent Events):**

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

**Noteringar om Java-implementering:**
- Använder Spring Boots reaktiva stack med `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) jämfört med att välja streaming via MCP.

- **För enkla streamingbehov:** Klassisk HTTP-streaming är enklare att implementera och räcker för grundläggande streaming.

- **För komplexa, interaktiva applikationer:** MCP-streaming ger en mer strukturerad metod med rikare metadata och separation mellan notifieringar och slutresultat.

- **För AI-applikationer:** MCP:s notifieringssystem är särskilt användbart för långvariga AI-uppgifter där du vill hålla användare informerade om framsteg.

## Streaming i MCP

Ok, du har sett några rekommendationer och jämförelser hittills om skillnaden mellan klassisk streaming och streaming i MCP. Nu går vi in på detalj om hur du kan utnyttja streaming i MCP.

Att förstå hur streaming fungerar inom MCP-ramverket är avgörande för att bygga responsiva applikationer som ger realtidsåterkoppling till användare under långvariga operationer.

I MCP handlar streaming inte om att skicka huvudsvaret i delar, utan om att skicka **notifieringar** till klienten medan ett verktyg bearbetar en förfrågan. Dessa notifieringar kan innehålla statusuppdateringar, loggar eller andra händelser.

### Hur det fungerar

Huvudresultatet skickas fortfarande som ett enda svar. Däremot kan notifieringar skickas som separata meddelanden under bearbetningen och därmed uppdatera klienten i realtid. Klienten måste kunna hantera och visa dessa notifieringar.

## Vad är en notifiering?

Vi nämnde "Notifiering", vad betyder det i MCP-sammanhang?

En notifiering är ett meddelande som skickas från servern till klienten för att informera om framsteg, status eller andra händelser under en långvarig operation. Notifieringar ökar transparensen och förbättrar användarupplevelsen.

Till exempel ska en klient skicka en notifiering när den initiala handskakningen med servern har genomförts.

En notifiering ser ut så här som ett JSON-meddelande:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifieringar hör till ett ämne i MCP som kallas ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

För att få logging att fungera måste servern aktivera det som en funktion/kapacitet på detta sätt:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Beroende på vilken SDK som används kan logging vara aktiverat som standard, eller så kan du behöva aktivera det explicit i serverkonfigurationen.

Det finns olika typer av notifieringar:

| Nivå      | Beskrivning                   | Exempel på användningsfall        |
|-----------|-------------------------------|----------------------------------|
| debug     | Detaljerad felsökningsinformation | Funktionens start- och slutpunkter |
| info      | Allmänna informationsmeddelanden | Uppdateringar om operationens framsteg |
| notice    | Normala men viktiga händelser   | Konfigurationsändringar           |
| warning   | Varningsförhållanden            | Användning av föråldrad funktion  |
| error     | Fel                            | Fel i operationer                 |
| critical  | Kritiska förhållanden           | Fel i systemkomponenter           |
| alert     | Åtgärd måste vidtas omedelbart | Upptäckt datakorruption           |
| emergency | Systemet är oanvändbart         | Total systemkrasch                |

## Implementera notifieringar i MCP

För att implementera notifieringar i MCP behöver du konfigurera både server- och klientsidan för att hantera realtidsuppdateringar. Detta gör att din applikation kan ge omedelbar återkoppling till användare under långvariga operationer.

### Serversida: Skicka notifieringar

Vi börjar med serversidan. I MCP definierar du verktyg som kan skicka notifieringar medan de bearbetar förfrågningar. Servern använder kontextobjektet (vanligtvis `ctx`) för att skicka meddelanden till klienten.

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

I det föregående exemplet används `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`-transporten:

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

I detta .NET-exempel används metoden `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` för att skicka informationsmeddelanden.

För att aktivera notifieringar i din .NET MCP-server, se till att du använder en streamingtransport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Klientsida: Ta emot notifieringar

Klienten måste implementera en meddelandehanterare för att bearbeta och visa notifieringar när de anländer.

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

I koden ovan används `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` för att hantera inkommande notifieringar.

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

I detta .NET-exempel används `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) och din klient implementerar en meddelandehanterare för att bearbeta notifieringar.

## Progressnotifieringar & Scenarier

Denna sektion förklarar konceptet med progressnotifieringar i MCP, varför de är viktiga och hur man implementerar dem med Streamable HTTP. Du hittar också en praktisk uppgift för att stärka din förståelse.

Progressnotifieringar är realtidsmeddelanden som skickas från servern till klienten under långvariga operationer. Istället för att vänta på att hela processen ska bli klar håller servern klienten uppdaterad om aktuell status. Detta förbättrar transparens, användarupplevelse och gör felsökning enklare.

**Exempel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Varför använda progressnotifieringar?

Progressnotifieringar är viktiga av flera skäl:

- **Bättre användarupplevelse:** Användare ser uppdateringar under arbetets gång, inte bara i slutet.
- **Realtidsåterkoppling:** Klienter kan visa progressindikatorer eller loggar, vilket gör appen mer responsiv.
- **Enklare felsökning och övervakning:** Utvecklare och användare kan se var en process kan vara långsam eller fastna.

### Hur implementera progressnotifieringar

Så här kan du implementera progressnotifieringar i MCP:

- **På servern:** Använd `ctx.info()` or `ctx.log()` för att skicka notifieringar när varje objekt behandlas. Detta skickar meddelanden till klienten innan huvudresultatet är klart.
- **På klienten:** Implementera en meddelandehanterare som lyssnar efter och visar notifieringar när de anländer. Denna hanterare skiljer på notifieringar och slutresultatet.

**Serverexempel:**

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

**Klientexempel:**

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

## Säkerhetsaspekter

När du implementerar MCP-servrar med HTTP-baserade transporter blir säkerheten en avgörande fråga som kräver noggrann uppmärksamhet på flera angreppsytor och skyddsmekanismer.

### Översikt

Säkerhet är kritiskt när MCP-servrar exponeras över HTTP. Streamable HTTP introducerar nya angreppsytor och kräver noggrann konfiguration.

### Viktiga punkter
- **Validering av Origin-headern**: Validera alltid `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` istället för SSE-klient.
3. **Implementera en meddelandehanterare** i klienten för att bearbeta notifieringar.
4. **Testa kompatibilitet** med befintliga verktyg och arbetsflöden.

### Behålla kompatibilitet

Det rekommenderas att behålla kompatibilitet med befintliga SSE-klienter under migreringsprocessen. Här är några strategier:

- Du kan stödja både SSE och Streamable HTTP genom att köra båda transporterna på olika endpoints.
- Migrera klienter successivt till den nya transporten.

### Utmaningar

Se till att hantera följande utmaningar under migreringen:

- Säkerställa att alla klienter uppdateras
- Hantera skillnader i leverans av notifieringar

### Uppgift: Bygg din egen streaming-MCP-app

**Scenario:**
Bygg en MCP-server och klient där servern bearbetar en lista med objekt (t.ex. filer eller dokument) och skickar en notifiering för varje objekt som bearbetas. Klienten ska visa varje notifiering när den anländer.

**Steg:**

1. Implementera ett serververktyg som bearbetar en lista och skickar notifieringar för varje objekt.
2. Implementera en klient med en meddelandehanterare som visar notifieringar i realtid.
3. Testa din implementation genom att köra både server och klient och observera notifieringarna.

[Lösning](./solution/README.md)

## Vidare läsning & Vad händer härnäst?

För att fortsätta din resa med MCP-streaming och utöka din kunskap, ger denna sektion ytterligare resurser och förslag på nästa steg för att bygga mer avancerade applikationer.

### Vidare läsning

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Vad händer härnäst?

- Försök bygga mer avancerade MCP-verktyg som använder streaming för realtidsanalys, chatt eller samredigering.
- Utforska integration av MCP-streaming med frontend-ramverk (React, Vue, etc.) för liveuppdateringar i användargränssnittet.
- Nästa: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess ursprungliga språk ska betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår vid användning av denna översättning.