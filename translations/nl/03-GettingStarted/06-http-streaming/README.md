<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:16:57+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "nl"
}
-->
# HTTPS Streaming met Model Context Protocol (MCP)

Dit hoofdstuk biedt een uitgebreide gids voor het implementeren van veilige, schaalbare en realtime streaming met het Model Context Protocol (MCP) via HTTPS. Het behandelt de motivatie achter streaming, de beschikbare transportmechanismen, hoe je streamable HTTP in MCP implementeert, beveiligingsrichtlijnen, migratie van SSE en praktische tips voor het bouwen van je eigen streaming MCP-applicaties.

## Transportmechanismen en Streaming in MCP

Deze sectie onderzoekt de verschillende transportmechanismen die beschikbaar zijn in MCP en hun rol bij het mogelijk maken van streamingfunctionaliteiten voor realtime communicatie tussen clients en servers.

### Wat is een Transportmechanisme?

Een transportmechanisme bepaalt hoe data wordt uitgewisseld tussen client en server. MCP ondersteunt meerdere transporttypes die passen bij verschillende omgevingen en eisen:

- **stdio**: Standaard input/output, geschikt voor lokale en CLI-gebaseerde tools. Simpel maar niet geschikt voor web of cloud.
- **SSE (Server-Sent Events)**: Hiermee kunnen servers realtime updates naar clients pushen via HTTP. Goed voor web-UI’s, maar beperkt in schaalbaarheid en flexibiliteit.
- **Streamable HTTP**: Modern, HTTP-gebaseerd streamingtransport, ondersteunt notificaties en betere schaalbaarheid. Aanbevolen voor de meeste productie- en cloudscenario’s.

### Vergelijkingstabel

Bekijk de onderstaande vergelijkingstabel om de verschillen tussen deze transportmechanismen te begrijpen:

| Transport         | Realtime Updates | Streaming | Schaalbaarheid | Gebruikssituatie         |
|-------------------|------------------|-----------|----------------|-------------------------|
| stdio             | Nee              | Nee       | Laag           | Lokale CLI-tools        |
| SSE               | Ja               | Ja        | Gemiddeld      | Web, realtime updates   |
| Streamable HTTP   | Ja               | Ja        | Hoog           | Cloud, multi-client     |

> **Tip:** De keuze van het juiste transport beïnvloedt prestaties, schaalbaarheid en gebruikerservaring. **Streamable HTTP** wordt aanbevolen voor moderne, schaalbare en cloudklare applicaties.

Let op de transports stdio en SSE die in eerdere hoofdstukken zijn besproken en dat streamable HTTP het transport is dat in dit hoofdstuk wordt behandeld.

## Streaming: Concepten en Motivatie

Het begrijpen van de basisconcepten en motivaties achter streaming is essentieel voor het implementeren van effectieve realtime communicatiesystemen.

**Streaming** is een techniek in netwerkprogrammering waarbij data in kleine, beheersbare stukken of als een reeks gebeurtenissen wordt verzonden en ontvangen, in plaats van te wachten tot een volledige respons klaar is. Dit is vooral nuttig voor:

- Grote bestanden of datasets.
- Realtime updates (bijv. chat, voortgangsbalken).
- Langdurige berekeningen waarbij je de gebruiker op de hoogte wilt houden.

Dit is wat je op hoofdlijnen moet weten over streaming:

- Data wordt geleidelijk geleverd, niet in één keer.
- De client kan data verwerken zodra deze binnenkomt.
- Vermindert de waargenomen latency en verbetert de gebruikerservaring.

### Waarom streaming gebruiken?

De redenen om streaming te gebruiken zijn:

- Gebruikers krijgen direct feedback, niet alleen aan het einde.
- Maakt realtime applicaties en responsieve UI’s mogelijk.
- Efficiënter gebruik van netwerk- en rekencapaciteit.

### Eenvoudig Voorbeeld: HTTP Streaming Server & Client

Hier is een eenvoudig voorbeeld van hoe streaming geïmplementeerd kan worden:

<details>
<summary>Python</summary>

**Server (Python, met FastAPI en StreamingResponse):**
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

**Client (Python, met requests):**
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

Dit voorbeeld laat zien hoe een server een reeks berichten naar de client stuurt zodra ze beschikbaar zijn, in plaats van te wachten tot alle berichten klaar zijn.

**Hoe werkt het:**
- De server levert elk bericht zodra het gereed is.
- De client ontvangt en print elk deel zodra het binnenkomt.

**Vereisten:**
- De server moet een streaming response gebruiken (bijv. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, met Spring Boot en Server-Sent Events):**

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

**Client (Java, met Spring WebFlux WebClient):**

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

**Notities bij Java-implementatie:**
- Maakt gebruik van Spring Boot’s reactieve stack met `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) versus streaming via MCP.

- **Voor eenvoudige streamingbehoeften:** Klassieke HTTP streaming is eenvoudiger te implementeren en voldoende voor basis streaming.

- **Voor complexe, interactieve applicaties:** MCP streaming biedt een meer gestructureerde aanpak met rijkere metadata en scheiding tussen notificaties en eindresultaten.

- **Voor AI-toepassingen:** Het notificatiesysteem van MCP is vooral handig voor langdurige AI-taken waarbij je gebruikers op de hoogte wilt houden van de voortgang.

## Streaming in MCP

Je hebt nu enkele aanbevelingen en vergelijkingen gezien over het verschil tussen klassieke streaming en streaming in MCP. Laten we nu in detail bekijken hoe je streaming in MCP kunt gebruiken.

Begrijpen hoe streaming binnen het MCP-framework werkt is essentieel voor het bouwen van responsieve applicaties die realtime feedback geven aan gebruikers tijdens langdurige bewerkingen.

In MCP gaat streaming niet om het verzenden van de hoofdrespons in stukken, maar om het sturen van **notificaties** naar de client terwijl een tool een verzoek verwerkt. Deze notificaties kunnen voortgangsupdates, logs of andere gebeurtenissen bevatten.

### Hoe werkt het

Het hoofdresultaat wordt nog steeds als één enkele respons gestuurd. Notificaties kunnen echter als aparte berichten worden verzonden tijdens de verwerking, waardoor de client realtime wordt bijgewerkt. De client moet in staat zijn deze notificaties te verwerken en weer te geven.

## Wat is een Notificatie?

We zeiden “Notificatie”, wat betekent dat precies binnen MCP?

Een notificatie is een bericht dat de server naar de client stuurt om te informeren over voortgang, status of andere gebeurtenissen tijdens een langdurige operatie. Notificaties verhogen de transparantie en verbeteren de gebruikerservaring.

Bijvoorbeeld, een client moet een notificatie sturen zodra de eerste handshake met de server is gemaakt.

Een notificatie ziet er als volgt uit als JSON-bericht:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notificaties behoren tot een topic in MCP dat ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) wordt genoemd.

Om logging te laten werken, moet de server het inschakelen als feature/capability zoals hieronder:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Afhankelijk van de gebruikte SDK kan logging standaard ingeschakeld zijn, of moet je het expliciet aanzetten in je serverconfiguratie.

Er zijn verschillende soorten notificaties:

| Niveau    | Beschrijving                  | Voorbeeld Gebruikssituatie    |
|-----------|------------------------------|-------------------------------|
| debug     | Gedetailleerde debug-informatie | Functie-in- en uitgangspunten |
| info      | Algemene informatieve berichten | Voortgangsupdates             |
| notice    | Normale maar belangrijke gebeurtenissen | Configuratiewijzigingen       |
| warning   | Waarschuwingen                | Gebruik van verouderde functies |
| error     | Foutcondities                | Foutmeldingen bij bewerkingen  |
| critical  | Kritieke condities           | Fouten in systeemcomponenten   |
| alert     | Directe actie vereist        | Geconstateerde datacorruptie   |
| emergency | Systeem onbruikbaar          | Volledige systeemuitval        |

## Notificaties Implementeren in MCP

Om notificaties in MCP te implementeren, moet je zowel de server- als clientzijde instellen om realtime updates te verwerken. Zo kan je applicatie directe feedback geven aan gebruikers tijdens langdurige bewerkingen.

### Serverzijde: Notificaties Verzenden

Laten we beginnen bij de serverkant. In MCP definieer je tools die notificaties kunnen versturen tijdens het verwerken van verzoeken. De server gebruikt het contextobject (meestal `ctx`) om berichten naar de client te sturen.

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

In het voorgaande voorbeeld wordt `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport gebruikt:

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

In dit .NET-voorbeeld wordt de `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` methode gebruikt om informatieve berichten te verzenden.

Zorg ervoor dat je voor notificaties in je .NET MCP-server een streaming transport gebruikt:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Clientzijde: Notificaties Ontvangen

De client moet een message handler implementeren om notificaties te verwerken en weer te geven zodra ze binnenkomen.

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

In bovenstaande code wordt `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` gebruikt om binnenkomende notificaties af te handelen.

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

In dit .NET-voorbeeld wordt `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` gebruikt en implementeert de client een message handler om notificaties te verwerken.

## Voortgangsnotificaties & Scenario’s

Deze sectie legt het concept voortgangsnotificaties in MCP uit, waarom ze belangrijk zijn en hoe je ze implementeert met Streamable HTTP. Ook vind je een praktische opdracht om je begrip te versterken.

Voortgangsnotificaties zijn realtime berichten die de server naar de client stuurt tijdens langdurige bewerkingen. In plaats van te wachten tot het hele proces klaar is, houdt de server de client op de hoogte van de huidige status. Dit verhoogt transparantie, verbetert de gebruikerservaring en maakt debugging makkelijker.

**Voorbeeld:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Waarom voortgangsnotificaties gebruiken?

Voortgangsnotificaties zijn om meerdere redenen belangrijk:

- **Betere gebruikerservaring:** Gebruikers zien updates tijdens het werk, niet alleen aan het einde.
- **Realtime feedback:** Clients kunnen voortgangsbalken of logs tonen, waardoor de app responsief aanvoelt.
- **Makkelijker debuggen en monitoren:** Ontwikkelaars en gebruikers zien waar een proces traag is of vastloopt.

### Hoe voortgangsnotificaties implementeren

Zo implementeer je voortgangsnotificaties in MCP:

- **Aan de serverkant:** Gebruik `ctx.info()` or `ctx.log()` om notificaties te sturen zodra een item verwerkt is. Dit verstuurt een bericht naar de client vóór het hoofdresultaat klaar is.
- **Aan de clientkant:** Implementeer een message handler die luistert naar en notificaties toont zodra ze binnenkomen. Deze handler maakt onderscheid tussen notificaties en het eindresultaat.

**Servervoorbeeld:**

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

**Clientvoorbeeld:**

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

## Beveiligingsoverwegingen

Bij het implementeren van MCP-servers met HTTP-gebaseerde transports is beveiliging een topprioriteit die aandacht vereist voor verschillende aanvalsvectoren en beschermingsmechanismen.

### Overzicht

Beveiliging is cruciaal bij het blootstellen van MCP-servers via HTTP. Streamable HTTP introduceert nieuwe aanvalsvlakken en vereist zorgvuldige configuratie.

### Belangrijke Punten
- **Validatie van de Origin Header**: Valideer altijd de `Origin` header om te voorkomen dat ongeautoriseerde bronnen verbinding maken.
- **Gebruik HTTPS**: Zorg dat alle communicatie via HTTPS verloopt om afluisteren en manipulatie te voorkomen.
- **Authenticatie en Autorisatie**: Implementeer geschikte authenticatie- en autorisatiemechanismen om toegang te beperken.
- **Rate Limiting**: Beperk het aantal verzoeken om misbruik en DoS-aanvallen te voorkomen.
- **Inputvalidatie**: Controleer en valideer alle binnenkomende data om injectie-aanvallen te vermijden.

### Compatibiliteit Behouden

Het is aan te raden om tijdens de migratie compatibiliteit met bestaande SSE-clients te behouden. Enkele strategieën:

- Ondersteun zowel SSE als Streamable HTTP door beide transports op verschillende endpoints te draaien.
- Migreer clients geleidelijk naar het nieuwe transport.

### Uitdagingen

Houd rekening met de volgende uitdagingen tijdens migratie:

- Zorgen dat alle clients worden bijgewerkt.
- Omgaan met verschillen in notificatieaflevering.

### Opdracht: Bouw je eigen Streaming MCP-app

**Scenario:**
Bouw een MCP-server en client waarbij de server een lijst met items (bijv. bestanden of documenten) verwerkt en voor elk verwerkt item een notificatie stuurt. De client toont elke notificatie zodra deze binnenkomt.

**Stappen:**

1. Implementeer een servertool die een lijst verwerkt en notificaties verstuurt voor elk item.
2. Implementeer een client met een message handler die notificaties realtime toont.
3. Test je implementatie door zowel server als client te draaien en observeer de notificaties.

[Oplossing](./solution/README.md)

## Verder Lezen & Wat Nu?

Om je reis met MCP-streaming voort te zetten en je kennis uit te breiden, biedt deze sectie extra bronnen en suggesties voor de volgende stappen bij het bouwen van meer geavanceerde applicaties.

### Verder Lezen

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Wat Nu?

- Probeer meer geavanceerde MCP-tools te bouwen die streaming gebruiken voor realtime analytics, chat of collaboratieve bewerking.
- Verken het integreren van MCP-streaming met frontend-frameworks (React, Vue, etc.) voor live UI-updates.
- Volgende: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.