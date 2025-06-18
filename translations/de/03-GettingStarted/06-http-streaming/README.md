<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:31:56+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "de"
}
-->
# HTTPS-Streaming mit Model Context Protocol (MCP)

Dieses Kapitel bietet eine umfassende Anleitung zur Implementierung von sicherem, skalierbarem und Echtzeit-Streaming mit dem Model Context Protocol (MCP) über HTTPS. Es behandelt die Motivation für Streaming, die verfügbaren Transportmechanismen, die Umsetzung von streambarem HTTP in MCP, Sicherheitsbest Practices, die Migration von SSE und praktische Hinweise zum Erstellen eigener Streaming-MCP-Anwendungen.

## Transportmechanismen und Streaming in MCP

Dieser Abschnitt untersucht die verschiedenen in MCP verfügbaren Transportmechanismen und deren Rolle bei der Ermöglichung von Streaming-Funktionen für die Echtzeitkommunikation zwischen Clients und Servern.

### Was ist ein Transportmechanismus?

Ein Transportmechanismus definiert, wie Daten zwischen Client und Server ausgetauscht werden. MCP unterstützt mehrere Transporttypen, um unterschiedlichen Umgebungen und Anforderungen gerecht zu werden:

- **stdio**: Standard Ein-/Ausgabe, geeignet für lokale und CLI-basierte Tools. Einfach, aber nicht für Web oder Cloud geeignet.
- **SSE (Server-Sent Events)**: Ermöglicht es Servern, Echtzeit-Updates über HTTP an Clients zu senden. Gut für Web-UIs, aber begrenzt in Skalierbarkeit und Flexibilität.
- **Streamable HTTP**: Moderner HTTP-basierter Streaming-Transport, unterstützt Benachrichtigungen und bessere Skalierbarkeit. Empfohlen für die meisten Produktions- und Cloud-Szenarien.

### Vergleichstabelle

Werfen Sie einen Blick auf die folgende Vergleichstabelle, um die Unterschiede zwischen diesen Transportmechanismen zu verstehen:

| Transport         | Echtzeit-Updates | Streaming | Skalierbarkeit | Anwendungsfall         |
|-------------------|------------------|-----------|---------------|-----------------------|
| stdio             | Nein             | Nein      | Niedrig       | Lokale CLI-Tools      |
| SSE               | Ja               | Ja        | Mittel        | Web, Echtzeit-Updates |
| Streamable HTTP   | Ja               | Ja        | Hoch          | Cloud, Multi-Client   |

> **Tipp:** Die Wahl des richtigen Transports beeinflusst Leistung, Skalierbarkeit und Benutzererlebnis. **Streamable HTTP** wird für moderne, skalierbare und cloudfähige Anwendungen empfohlen.

Beachten Sie die Transports stdio und SSE, die in den vorherigen Kapiteln vorgestellt wurden, und dass in diesem Kapitel Streamable HTTP behandelt wird.

## Streaming: Konzepte und Motivation

Das Verständnis der grundlegenden Konzepte und der Motivation hinter Streaming ist entscheidend für die Umsetzung effektiver Echtzeit-Kommunikationssysteme.

**Streaming** ist eine Technik in der Netzwerkprogrammierung, die es ermöglicht, Daten in kleinen, handhabbaren Stücken oder als Ereignisfolge zu senden und zu empfangen, anstatt auf eine vollständige Antwort zu warten. Dies ist besonders nützlich für:

- Große Dateien oder Datensätze.
- Echtzeit-Updates (z.B. Chat, Fortschrittsanzeigen).
- Lang laufende Berechnungen, bei denen der Nutzer informiert bleiben soll.

Das sollten Sie über Streaming auf hoher Ebene wissen:

- Daten werden schrittweise geliefert, nicht auf einmal.
- Der Client kann Daten verarbeiten, sobald sie eintreffen.
- Verringert die wahrgenommene Latenz und verbessert das Nutzererlebnis.

### Warum Streaming verwenden?

Die Gründe für die Nutzung von Streaming sind:

- Nutzer erhalten sofort Feedback, nicht erst am Ende.
- Ermöglicht Echtzeitanwendungen und reaktionsfähige UIs.
- Effizientere Nutzung von Netzwerk- und Rechenressourcen.

### Einfaches Beispiel: HTTP-Streaming Server & Client

Hier ein einfaches Beispiel, wie Streaming umgesetzt werden kann:

<details>
<summary>Python</summary>

**Server (Python, mit FastAPI und StreamingResponse):**
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

**Client (Python, mit requests):**
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

Dieses Beispiel zeigt, wie ein Server eine Reihe von Nachrichten an den Client sendet, sobald sie verfügbar sind, anstatt auf alle Nachrichten zu warten.

**Funktionsweise:**
- Der Server liefert jede Nachricht, sobald sie bereitsteht.
- Der Client empfängt und gibt jede Datenportion sofort aus.

**Voraussetzungen:**
- Der Server muss eine Streaming-Antwort verwenden (z.B. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Server (Java, mit Spring Boot und Server-Sent Events):**

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

**Client (Java, mit Spring WebFlux WebClient):**

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

**Hinweise zur Java-Implementierung:**
- Verwendet den reaktiven Stack von Spring Boot mit `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) im Vergleich zur Wahl von Streaming via MCP.

- **Für einfache Streaming-Anforderungen:** Klassisches HTTP-Streaming ist einfacher umzusetzen und für grundlegende Streaming-Bedürfnisse ausreichend.

- **Für komplexe, interaktive Anwendungen:** MCP-Streaming bietet einen strukturierteren Ansatz mit reichhaltigeren Metadaten und einer Trennung zwischen Benachrichtigungen und Endergebnissen.

- **Für KI-Anwendungen:** Das Benachrichtigungssystem von MCP ist besonders nützlich für lang laufende KI-Aufgaben, bei denen Nutzer über den Fortschritt informiert werden sollen.

## Streaming in MCP

Sie haben bisher Empfehlungen und Vergleiche zwischen klassischem Streaming und Streaming in MCP gesehen. Nun gehen wir ins Detail, wie Sie Streaming in MCP genau nutzen können.

Das Verständnis, wie Streaming im MCP-Framework funktioniert, ist entscheidend, um reaktionsfähige Anwendungen zu bauen, die während lang andauernder Operationen Echtzeit-Feedback an Nutzer liefern.

Im MCP geht es beim Streaming nicht darum, die Hauptantwort in Teilen zu senden, sondern **Benachrichtigungen** an den Client zu schicken, während ein Tool eine Anfrage verarbeitet. Diese Benachrichtigungen können Fortschrittsupdates, Logs oder andere Ereignisse enthalten.

### Wie funktioniert das?

Das Hauptergebnis wird weiterhin als einzelne Antwort gesendet. Benachrichtigungen können jedoch während der Verarbeitung als separate Nachrichten verschickt werden und so den Client in Echtzeit aktualisieren. Der Client muss in der Lage sein, diese Benachrichtigungen zu verarbeiten und anzuzeigen.

## Was ist eine Benachrichtigung?

Wir haben „Benachrichtigung“ erwähnt – was bedeutet das im Kontext von MCP?

Eine Benachrichtigung ist eine Nachricht, die vom Server an den Client gesendet wird, um über Fortschritt, Status oder andere Ereignisse während einer lang laufenden Operation zu informieren. Benachrichtigungen verbessern Transparenz und Nutzererlebnis.

Beispielsweise soll ein Client eine Benachrichtigung senden, sobald der initiale Handshake mit dem Server abgeschlossen ist.

Eine Benachrichtigung sieht als JSON-Nachricht folgendermaßen aus:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Benachrichtigungen gehören in MCP zu einem Thema, das als ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) bezeichnet wird.

Damit Logging funktioniert, muss der Server es als Feature/Fähigkeit aktivieren, so:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Je nach verwendetem SDK ist Logging möglicherweise standardmäßig aktiviert, oder es muss explizit in der Serverkonfiguration eingeschaltet werden.

Es gibt verschiedene Arten von Benachrichtigungen:

| Level     | Beschreibung                   | Beispielanwendung               |
|-----------|-------------------------------|--------------------------------|
| debug     | Detaillierte Debug-Information | Funktionsaufruf/-rückkehr       |
| info      | Allgemeine Informationsmeldungen | Fortschrittsupdates             |
| notice    | Normale, aber bedeutende Ereignisse | Konfigurationsänderungen        |
| warning   | Warnungen                      | Verwendung veralteter Features  |
| error     | Fehlerbedingungen              | Fehler bei Operationen          |
| critical  | Kritische Bedingungen          | Systemkomponenten-Ausfälle      |
| alert     | Sofortiges Handeln erforderlich | Datenkorruption erkannt         |
| emergency | System ist unbrauchbar         | Totalausfall des Systems        |

## Benachrichtigungen in MCP implementieren

Um Benachrichtigungen in MCP umzusetzen, müssen sowohl Server- als auch Client-Seite so eingerichtet sein, dass sie Echtzeit-Updates verarbeiten. So kann Ihre Anwendung während lang andauernder Operationen sofortiges Feedback an Nutzer geben.

### Serverseitig: Benachrichtigungen senden

Beginnen wir mit der Serverseite. In MCP definieren Sie Tools, die während der Verarbeitung von Anfragen Benachrichtigungen senden können. Der Server nutzt das Kontextobjekt (meist `ctx`), um Nachrichten an den Client zu senden.

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

Im obigen Beispiel verwendet die `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` Transport:

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

In diesem .NET-Beispiel wird die Methode `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` genutzt, um Informationsnachrichten zu senden.

Um Benachrichtigungen in Ihrem .NET MCP-Server zu aktivieren, stellen Sie sicher, dass Sie einen Streaming-Transport verwenden:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Clientseitig: Benachrichtigungen empfangen

Der Client muss einen Nachrichten-Handler implementieren, der Benachrichtigungen verarbeitet und anzeigt, sobald sie eintreffen.

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

Im obigen Code verwendet der `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` Nachrichten-Handler, um eingehende Benachrichtigungen zu verarbeiten.

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

In diesem .NET-Beispiel verwendet der Client `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) und implementiert einen Nachrichten-Handler, um Benachrichtigungen zu verarbeiten.

## Fortschritts-Benachrichtigungen & Szenarien

Dieser Abschnitt erklärt das Konzept von Fortschritts-Benachrichtigungen in MCP, warum sie wichtig sind und wie man sie mit Streamable HTTP umsetzt. Außerdem gibt es eine praktische Aufgabe zur Vertiefung.

Fortschritts-Benachrichtigungen sind Echtzeit-Nachrichten, die vom Server während lang andauernder Operationen an den Client gesendet werden. Anstatt auf den Abschluss des gesamten Prozesses zu warten, hält der Server den Client über den aktuellen Status auf dem Laufenden. Das erhöht Transparenz, Nutzererlebnis und erleichtert das Debugging.

**Beispiel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Warum Fortschritts-Benachrichtigungen verwenden?

Fortschritts-Benachrichtigungen sind aus mehreren Gründen wichtig:

- **Besseres Nutzererlebnis:** Nutzer sehen Updates während des Fortschritts, nicht nur am Ende.
- **Echtzeit-Feedback:** Clients können Fortschrittsbalken oder Logs anzeigen, wodurch die App reaktionsschneller wirkt.
- **Einfacheres Debugging und Monitoring:** Entwickler und Nutzer können sehen, wo ein Prozess langsam ist oder hängt.

### Wie Fortschritts-Benachrichtigungen implementieren?

So setzen Sie Fortschritts-Benachrichtigungen in MCP um:

- **Auf dem Server:** Verwenden Sie `ctx.info()` or `ctx.log()`, um Benachrichtigungen zu senden, während einzelne Elemente verarbeitet werden. So erhält der Client Nachrichten vor dem Hauptergebnis.
- **Auf dem Client:** Implementieren Sie einen Nachrichten-Handler, der Benachrichtigungen empfängt und anzeigt. Dieser unterscheidet zwischen Benachrichtigungen und dem Endergebnis.

**Server-Beispiel:**

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

**Client-Beispiel:**

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

## Sicherheitsaspekte

Beim Implementieren von MCP-Servern mit HTTP-basierten Transporten ist Sicherheit ein zentrales Thema, das sorgfältige Beachtung verschiedener Angriffsvektoren und Schutzmechanismen erfordert.

### Überblick

Sicherheit ist entscheidend, wenn MCP-Server über HTTP exponiert werden. Streamable HTTP bringt neue Angriffsflächen mit sich und erfordert eine sorgfältige Konfiguration.

### Wichtige Punkte
- **Origin-Header-Validierung:** Validieren Sie stets den `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` anstelle des SSE-Clients.
3. **Implementieren Sie einen Nachrichten-Handler** im Client, um Benachrichtigungen zu verarbeiten.
4. **Testen Sie die Kompatibilität** mit bestehenden Tools und Workflows.

### Kompatibilität erhalten

Es wird empfohlen, während der Migration die Kompatibilität mit bestehenden SSE-Clients zu bewahren. Folgende Strategien sind möglich:

- Sie können sowohl SSE als auch Streamable HTTP unterstützen, indem Sie beide Transporte auf unterschiedlichen Endpunkten anbieten.
- Migrieren Sie Clients schrittweise zum neuen Transport.

### Herausforderungen

Beachten Sie bei der Migration folgende Herausforderungen:

- Sicherstellen, dass alle Clients aktualisiert werden.
- Umgang mit Unterschieden in der Zustellung von Benachrichtigungen.

### Aufgabe: Erstellen Sie Ihre eigene Streaming-MCP-App

**Szenario:**
Erstellen Sie einen MCP-Server und -Client, bei dem der Server eine Liste von Elementen (z.B. Dateien oder Dokumente) verarbeitet und für jedes verarbeitete Element eine Benachrichtigung sendet. Der Client soll jede Benachrichtigung anzeigen, sobald sie ankommt.

**Schritte:**

1. Implementieren Sie ein Server-Tool, das eine Liste verarbeitet und für jedes Element Benachrichtigungen sendet.
2. Implementieren Sie einen Client mit einem Nachrichten-Handler, der Benachrichtigungen in Echtzeit anzeigt.
3. Testen Sie Ihre Implementierung, indem Sie Server und Client ausführen und die Benachrichtigungen beobachten.

[Lösung](./solution/README.md)

## Weiterführende Literatur & Ausblick

Um Ihre Reise mit MCP-Streaming fortzusetzen und Ihr Wissen zu vertiefen, bietet dieser Abschnitt zusätzliche Ressourcen und empfohlene nächste Schritte für den Bau fortgeschrittener Anwendungen.

### Weiterführende Literatur

- [Microsoft: Einführung in HTTP-Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Was kommt als Nächstes?

- Versuchen Sie, komplexere MCP-Tools zu entwickeln, die Streaming für Echtzeit-Analysen, Chat oder kollaboratives Bearbeiten nutzen.
- Erkunden Sie die Integration von MCP-Streaming mit Frontend-Frameworks (React, Vue etc.) für Live-UI-Updates.
- Nächstes Thema: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.