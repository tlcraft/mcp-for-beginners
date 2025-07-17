<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "40b1bbffdb8ce6812bf6e701cad876b6",
  "translation_date": "2025-07-17T18:55:27+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "nl"
}
-->
# HTTPS Streaming met Model Context Protocol (MCP)

Dit hoofdstuk biedt een uitgebreide handleiding voor het implementeren van veilige, schaalbare en realtime streaming met het Model Context Protocol (MCP) via HTTPS. Het behandelt de motivatie voor streaming, de beschikbare transportmechanismen, hoe je streamable HTTP in MCP implementeert, beveiligingsrichtlijnen, migratie van SSE, en praktische tips voor het bouwen van je eigen streaming MCP-applicaties.

## Transportmechanismen en Streaming in MCP

Deze sectie onderzoekt de verschillende transportmechanismen die beschikbaar zijn in MCP en hun rol bij het mogelijk maken van streamingfunctionaliteit voor realtime communicatie tussen clients en servers.

### Wat is een Transportmechanisme?

Een transportmechanisme bepaalt hoe data wordt uitgewisseld tussen client en server. MCP ondersteunt meerdere transporttypes om aan verschillende omgevingen en eisen te voldoen:

- **stdio**: Standaard input/output, geschikt voor lokale en CLI-gebaseerde tools. Eenvoudig, maar niet geschikt voor web of cloud.
- **SSE (Server-Sent Events)**: Hiermee kunnen servers realtime updates naar clients pushen via HTTP. Goed voor web-UI’s, maar beperkt in schaalbaarheid en flexibiliteit.
- **Streamable HTTP**: Moderne HTTP-gebaseerde streaming transport, ondersteunt notificaties en betere schaalbaarheid. Aanbevolen voor de meeste productie- en cloudscenario’s.

### Vergelijkingstabel

Bekijk de onderstaande vergelijkingstabel om de verschillen tussen deze transportmechanismen te begrijpen:

| Transport         | Realtime Updates | Streaming | Schaalbaarheid | Gebruikssituatie          |
|-------------------|------------------|-----------|----------------|--------------------------|
| stdio             | Nee              | Nee       | Laag           | Lokale CLI-tools         |
| SSE               | Ja               | Ja        | Gemiddeld      | Web, realtime updates    |
| Streamable HTTP   | Ja               | Ja        | Hoog           | Cloud, multi-client      |

> **Tip:** De keuze van het juiste transport beïnvloedt prestaties, schaalbaarheid en gebruikerservaring. **Streamable HTTP** wordt aanbevolen voor moderne, schaalbare en cloudklare applicaties.

Let op de transports stdio en SSE die in eerdere hoofdstukken zijn besproken en hoe streamable HTTP het transport is dat in dit hoofdstuk wordt behandeld.

## Streaming: Concepten en Motivatie

Het begrijpen van de fundamentele concepten en motivaties achter streaming is essentieel voor het implementeren van effectieve realtime communicatiesystemen.

**Streaming** is een techniek in netwerkprogrammering waarbij data in kleine, beheersbare stukjes of als een reeks gebeurtenissen wordt verzonden en ontvangen, in plaats van te wachten tot een volledige respons klaar is. Dit is vooral nuttig voor:

- Grote bestanden of datasets.
- Realtime updates (bijv. chat, voortgangsbalken).
- Langdurige berekeningen waarbij je de gebruiker op de hoogte wilt houden.

Dit is wat je op hoofdlijnen moet weten over streaming:

- Data wordt geleidelijk geleverd, niet in één keer.
- De client kan data verwerken zodra deze binnenkomt.
- Vermindert waargenomen vertraging en verbetert de gebruikerservaring.

### Waarom streaming gebruiken?

De redenen om streaming te gebruiken zijn:

- Gebruikers krijgen direct feedback, niet pas aan het einde.
- Maakt realtime applicaties en responsieve UI’s mogelijk.
- Efficiënter gebruik van netwerk- en rekenmiddelen.

### Eenvoudig Voorbeeld: HTTP Streaming Server & Client

Hier is een eenvoudig voorbeeld van hoe streaming geïmplementeerd kan worden:

## Python

**Server (Python, met FastAPI en StreamingResponse):**

### Python

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


**Client (Python, met requests):**

### Python

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```


Dit voorbeeld laat zien hoe een server een reeks berichten naar de client stuurt zodra ze beschikbaar zijn, in plaats van te wachten tot alle berichten klaar zijn.

**Hoe het werkt:**
- De server levert elk bericht zodra het klaar is.
- De client ontvangt en print elk stukje zodra het binnenkomt.

**Vereisten:**
- De server moet een streaming response gebruiken (bijv. `StreamingResponse` in FastAPI).
- De client moet de response als stream verwerken (`stream=True` in requests).
- Content-Type is meestal `text/event-stream` of `application/octet-stream`.

## Java

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

**Java Implementatie Opmerkingen:**
- Gebruikt Spring Boot’s reactieve stack met `Flux` voor streaming
- `ServerSentEvent` biedt gestructureerde event streaming met event types
- `WebClient` met `bodyToFlux()` maakt reactieve streaming consumptie mogelijk
- `delayElements()` simuleert verwerkingstijd tussen events
- Events kunnen types hebben (`info`, `result`) voor betere clientafhandeling

### Vergelijking: Klassieke Streaming vs MCP Streaming

De verschillen tussen klassieke streaming en streaming in MCP kunnen als volgt worden weergegeven:

| Kenmerk                | Klassieke HTTP Streaming       | MCP Streaming (Notificaties)       |
|------------------------|-------------------------------|-----------------------------------|
| Hoofdrespons            | Chunked                       | Enkelvoudig, aan het einde        |
| Voortgangsupdates      | Verzonden als data chunks     | Verzonden als notificaties        |
| Clientvereisten        | Moet stream verwerken         | Moet message handler implementeren|
| Gebruikssituatie       | Grote bestanden, AI token streams | Voortgang, logs, realtime feedback |

### Belangrijkste Verschillen

Daarnaast zijn er enkele belangrijke verschillen:

- **Communicatiepatroon:**
   - Klassieke HTTP streaming: gebruikt eenvoudige chunked transfer encoding om data in stukken te verzenden
   - MCP streaming: gebruikt een gestructureerd notificatiesysteem met JSON-RPC protocol

- **Berichtformaat:**
   - Klassieke HTTP: platte tekst chunks met nieuwe regels
   - MCP: gestructureerde LoggingMessageNotification objecten met metadata

- **Clientimplementatie:**
   - Klassieke HTTP: eenvoudige client die streaming responses verwerkt
   - MCP: geavanceerdere client met een message handler om verschillende soorten berichten te verwerken

- **Voortgangsupdates:**
   - Klassieke HTTP: voortgang maakt deel uit van de hoofdrespons stream
   - MCP: voortgang wordt via aparte notificatieberichten gestuurd terwijl de hoofdrespons aan het einde komt

### Aanbevelingen

Er zijn enkele aanbevelingen bij het kiezen tussen klassieke streaming (zoals het endpoint `/stream` dat we eerder lieten zien) en streaming via MCP:

- **Voor eenvoudige streamingbehoeften:** Klassieke HTTP streaming is eenvoudiger te implementeren en voldoende voor basis streaming.

- **Voor complexe, interactieve applicaties:** MCP streaming biedt een meer gestructureerde aanpak met rijkere metadata en scheiding tussen notificaties en eindresultaten.

- **Voor AI-toepassingen:** Het notificatiesysteem van MCP is bijzonder nuttig voor langdurige AI-taken waarbij je gebruikers op de hoogte wilt houden van de voortgang.

## Streaming in MCP

Je hebt nu enkele aanbevelingen en vergelijkingen gezien over het verschil tussen klassieke streaming en streaming in MCP. Laten we nu in detail bekijken hoe je streaming in MCP kunt benutten.

Begrijpen hoe streaming werkt binnen het MCP-framework is essentieel voor het bouwen van responsieve applicaties die realtime feedback geven aan gebruikers tijdens langdurige processen.

In MCP gaat streaming niet over het versturen van de hoofdrespons in stukjes, maar over het sturen van **notificaties** naar de client terwijl een tool een verzoek verwerkt. Deze notificaties kunnen voortgangsupdates, logs of andere gebeurtenissen bevatten.

### Hoe werkt het?

Het hoofdresultaat wordt nog steeds als één enkele respons verzonden. Notificaties kunnen echter als aparte berichten tijdens de verwerking worden gestuurd, waardoor de client realtime wordt bijgewerkt. De client moet deze notificaties kunnen verwerken en weergeven.

## Wat is een Notificatie?

We zeiden “Notificatie”, wat betekent dat in de context van MCP?

Een notificatie is een bericht dat van de server naar de client wordt gestuurd om te informeren over voortgang, status of andere gebeurtenissen tijdens een langdurige operatie. Notificaties verbeteren transparantie en gebruikerservaring.

Bijvoorbeeld, een client moet een notificatie sturen zodra de initiële handshake met de server is voltooid.

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

Notificaties horen bij een topic in MCP dat ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) wordt genoemd.

Om logging te laten werken, moet de server het als feature/capability inschakelen, zoals hieronder:

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

| Niveau     | Beschrijving                  | Voorbeeld Gebruikssituatie       |
|------------|------------------------------|---------------------------------|
| debug      | Gedetailleerde debug-informatie | Functie in- en uitgangspunten  |
| info       | Algemene informatieve berichten | Voortgangsupdates van operatie |
| notice     | Normale maar belangrijke gebeurtenissen | Configuratie wijzigingen    |
| warning    | Waarschuwingscondities         | Gebruik van verouderde functies  |
| error      | Foutcondities                 | Mislukkingen in operaties       |
| critical   | Kritieke condities            | Falen van systeemcomponenten    |
| alert      | Directe actie vereist         | Gegevenscorruptie gedetecteerd  |
| emergency  | Systeem is onbruikbaar        | Volledig systeemfalen           |

## Notificaties Implementeren in MCP

Om notificaties in MCP te implementeren, moet je zowel de server- als clientzijde instellen om realtime updates te verwerken. Dit stelt je applicatie in staat om gebruikers direct feedback te geven tijdens langdurige processen.

### Serverzijde: Notificaties Verzenden

Laten we beginnen met de serverzijde. In MCP definieer je tools die notificaties kunnen sturen tijdens het verwerken van verzoeken. De server gebruikt het contextobject (meestal `ctx`) om berichten naar de client te sturen.

### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

In het bovenstaande voorbeeld stuurt de `process_files` tool drie notificaties naar de client terwijl elk bestand wordt verwerkt. De `ctx.info()` methode wordt gebruikt om informatieve berichten te verzenden.

Daarnaast, om notificaties mogelijk te maken, moet je server een streaming transport gebruiken (zoals `streamable-http`) en moet je client een message handler implementeren om notificaties te verwerken. Zo stel je de server in om het `streamable-http` transport te gebruiken:

```python
mcp.run(transport="streamable-http")
```

### .NET

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

In dit .NET voorbeeld is de `ProcessFiles` tool gemarkeerd met het `Tool` attribuut en stuurt drie notificaties naar de client tijdens het verwerken van bestanden. De `ctx.Info()` methode wordt gebruikt voor informatieve berichten.

Om notificaties in je .NET MCP-server te activeren, zorg dat je een streaming transport gebruikt:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

### Clientzijde: Notificaties Ontvangen

De client moet een message handler implementeren om notificaties te verwerken en weer te geven zodra ze binnenkomen.

### Python

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

In bovenstaande code controleert de `message_handler` functie of het binnenkomende bericht een notificatie is. Zo ja, dan wordt de notificatie geprint; anders wordt het als een regulier serverbericht verwerkt. Let ook op hoe de `ClientSession` wordt geïnitialiseerd met de `message_handler` om inkomende notificaties te verwerken.

### .NET

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

In dit .NET voorbeeld controleert de `MessageHandler` functie of het binnenkomende bericht een notificatie is. Zo ja, dan wordt de notificatie geprint; anders wordt het als een regulier serverbericht verwerkt. De `ClientSession` wordt geïnitialiseerd met de message handler via de `ClientSessionOptions`.

Om notificaties te activeren, zorg dat je server een streaming transport gebruikt (zoals `streamable-http`) en dat je client een message handler implementeert om notificaties te verwerken.

## Voortgangsnotificaties & Scenario’s

Deze sectie legt het concept van voortgangsnotificaties in MCP uit, waarom ze belangrijk zijn en hoe je ze implementeert met Streamable HTTP. Ook vind je een praktische opdracht om je begrip te versterken.

Voortgangsnotificaties zijn realtime berichten die van de server naar de client worden gestuurd tijdens langdurige processen. In plaats van te wachten tot het hele proces klaar is, houdt de server de client op de hoogte van de huidige status. Dit verbetert transparantie, gebruikerservaring en maakt debugging eenvoudiger.

**Voorbeeld:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Waarom Voortgangsnotificaties Gebruiken?

Voortgangsnotificaties zijn om verschillende redenen essentieel:

- **Betere gebruikerservaring:** Gebruikers zien updates terwijl het werk vordert, niet alleen aan het einde.
- **Realtime feedback:** Clients kunnen voortgangsbalken of logs tonen, waardoor de app responsief aanvoelt.
- **Eenvoudiger debuggen en monitoren:** Ontwikkelaars en gebruikers zien waar een proces traag is of vastloopt.

### Hoe Voortgangsnotificaties Implementeren

Zo implementeer je voortgangsnotificaties in MCP:

- **Op de server:** Gebruik `ctx.info()` of `ctx.log()` om notificaties te sturen terwijl elk item wordt verwerkt. Dit stuurt een bericht naar de client vóór het hoofdresultaat klaar is.
- **Op de client:** Implementeer een message handler die notificaties opvangt en weergeeft zodra ze binnenkomen. Deze handler onderscheidt notificaties van het eindresultaat.

**Servervoorbeeld:**

## Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```


**Clientvoorbeeld:**

### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```


## Beveiligingsoverwegingen

Bij het implementeren van MCP-servers met HTTP-gebaseerde transports wordt beveiliging een cruciale factor die aandacht vereist voor meerdere aanvalsvectoren en beschermingsmechanismen.

### Overzicht

Beveiliging is essentieel bij het blootstellen van MCP-servers via HTTP. Streamable HTTP introduceert nieuwe aanvalsvlakken en vereist zorgvuldige configuratie.

### Belangrijke Punten
- **Validatie van Origin-header:** Valideer altijd de `Origin` header om DNS rebinding-aanvallen te voorkomen.
- **Binding aan localhost:** Voor lokale ontwikkeling bind servers aan `localhost` om blootstelling aan het publieke internet te vermijden.
- **Authenticatie:** Implementeer authenticatie (bijv. API-sleutels, OAuth) voor productieomgevingen.
- **CORS:** Configureer Cross-Origin Resource Sharing (CORS) beleid om toegang te beperken.
- **HTTPS:** Gebruik HTTPS in productie om verkeer te versleutelen.

### Best Practices
- Vertrouw nooit op binnenkomende verzoeken zonder validatie.
- Log en monitor alle toegang en fouten.
- Werk afhankelijkheden regelmatig bij om beveiligingslekken te dichten.

### Uitdagingen
- Balanceren tussen beveiliging en ontwikkelgemak
- Zorgen voor compatibiliteit met diverse clientomgevingen

## Upgraden van SSE naar Streamable HTTP

Voor applicaties die momenteel Server-Sent Events (SSE) gebruiken, biedt migratie naar Streamable HTTP verbeterde mogelijkheden en betere duurzaamheid op lange termijn voor je MCP-implementaties.
### Waarom upgraden?

Er zijn twee belangrijke redenen om te upgraden van SSE naar Streamable HTTP:

- Streamable HTTP biedt betere schaalbaarheid, compatibiliteit en uitgebreidere notificatie-ondersteuning dan SSE.
- Het is de aanbevolen transportmethode voor nieuwe MCP-applicaties.

### Migratiestappen

Zo kun je migreren van SSE naar Streamable HTTP in je MCP-applicaties:

- **Werk de servercode bij** om `transport="streamable-http"` te gebruiken in `mcp.run()`.
- **Werk de clientcode bij** om `streamablehttp_client` te gebruiken in plaats van de SSE-client.
- **Implementeer een message handler** in de client om notificaties te verwerken.
- **Test de compatibiliteit** met bestaande tools en workflows.

### Compatibiliteit behouden

Het is aan te raden om tijdens het migratieproces compatibiliteit met bestaande SSE-clients te behouden. Hier zijn enkele strategieën:

- Je kunt zowel SSE als Streamable HTTP ondersteunen door beide transports op verschillende endpoints te draaien.
- Migreer clients geleidelijk naar de nieuwe transportmethode.

### Uitdagingen

Zorg dat je de volgende uitdagingen aanpakt tijdens de migratie:

- Zeker stellen dat alle clients worden bijgewerkt
- Omgaan met verschillen in notificatiebezorging

## Beveiligingsoverwegingen

Beveiliging moet een topprioriteit zijn bij het implementeren van elke server, vooral bij het gebruik van HTTP-gebaseerde transports zoals Streamable HTTP in MCP.

Bij het implementeren van MCP-servers met HTTP-gebaseerde transports is beveiliging een cruciale factor die zorgvuldige aandacht vereist voor verschillende aanvalsvectoren en beschermingsmechanismen.

### Overzicht

Beveiliging is essentieel bij het blootstellen van MCP-servers via HTTP. Streamable HTTP introduceert nieuwe aanvalsvlakken en vereist een zorgvuldige configuratie.

Hier zijn enkele belangrijke beveiligingsoverwegingen:

- **Validatie van de Origin-header**: Valideer altijd de `Origin`-header om DNS-rebinding-aanvallen te voorkomen.
- **Binding aan localhost**: Voor lokale ontwikkeling, bind servers aan `localhost` om te voorkomen dat ze publiek toegankelijk zijn.
- **Authenticatie**: Implementeer authenticatie (bijv. API-sleutels, OAuth) voor productieomgevingen.
- **CORS**: Stel Cross-Origin Resource Sharing (CORS) policies in om toegang te beperken.
- **HTTPS**: Gebruik HTTPS in productie om het verkeer te versleutelen.

### Best practices

Daarnaast zijn hier enkele best practices voor het implementeren van beveiliging in je MCP streaming server:

- Vertrouw nooit op binnenkomende verzoeken zonder validatie.
- Log en monitor alle toegang en fouten.
- Werk afhankelijkheden regelmatig bij om beveiligingslekken te dichten.

### Uitdagingen

Je zult enkele uitdagingen tegenkomen bij het implementeren van beveiliging in MCP streaming servers:

- De balans vinden tussen beveiliging en ontwikkelgemak
- Compatibiliteit waarborgen met verschillende clientomgevingen

### Opdracht: Bouw je eigen streaming MCP-app

**Scenario:**  
Bouw een MCP-server en client waarbij de server een lijst met items (bijv. bestanden of documenten) verwerkt en voor elk verwerkt item een notificatie verstuurt. De client moet elke notificatie direct tonen zodra deze binnenkomt.

**Stappen:**

1. Implementeer een servertool die een lijst verwerkt en voor elk item notificaties verstuurt.  
2. Implementeer een client met een message handler die notificaties realtime toont.  
3. Test je implementatie door zowel server als client te draaien en de notificaties te observeren.

[Solution](./solution/README.md)

## Verder lezen & wat nu?

Om je reis met MCP streaming voort te zetten en je kennis uit te breiden, biedt deze sectie extra bronnen en suggesties voor de volgende stappen om geavanceerdere applicaties te bouwen.

### Verder lezen

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)  
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)  
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)  
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)  

### Wat nu?

- Probeer meer geavanceerde MCP-tools te bouwen die streaming gebruiken voor realtime analytics, chat of collaboratief bewerken.  
- Verken het integreren van MCP streaming met frontend frameworks (React, Vue, etc.) voor live UI-updates.  
- Volgende: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.