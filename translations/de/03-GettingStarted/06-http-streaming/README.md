<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "40b1bbffdb8ce6812bf6e701cad876b6",
  "translation_date": "2025-07-17T17:24:52+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "de"
}
-->
# HTTPS-Streaming mit dem Model Context Protocol (MCP)

Dieses Kapitel bietet eine umfassende Anleitung zur Implementierung von sicherem, skalierbarem und Echtzeit-Streaming mit dem Model Context Protocol (MCP) über HTTPS. Es behandelt die Motivation für Streaming, die verfügbaren Transportmechanismen, wie man streamfähiges HTTP in MCP implementiert, Sicherheitsbest Practices, die Migration von SSE und praktische Hinweise zum Erstellen eigener Streaming-MCP-Anwendungen.

## Transportmechanismen und Streaming in MCP

Dieser Abschnitt untersucht die verschiedenen in MCP verfügbaren Transportmechanismen und ihre Rolle bei der Ermöglichung von Streaming-Funktionalitäten für die Echtzeitkommunikation zwischen Clients und Servern.

### Was ist ein Transportmechanismus?

Ein Transportmechanismus definiert, wie Daten zwischen Client und Server ausgetauscht werden. MCP unterstützt mehrere Transporttypen, um unterschiedlichen Umgebungen und Anforderungen gerecht zu werden:

- **stdio**: Standard Ein-/Ausgabe, geeignet für lokale und CLI-basierte Tools. Einfach, aber nicht für Web oder Cloud geeignet.
- **SSE (Server-Sent Events)**: Ermöglicht es Servern, Echtzeit-Updates über HTTP an Clients zu senden. Gut für Web-UIs, aber begrenzt in Skalierbarkeit und Flexibilität.
- **Streamable HTTP**: Moderner, HTTP-basierter Streaming-Transport, der Benachrichtigungen und bessere Skalierbarkeit unterstützt. Empfohlen für die meisten Produktions- und Cloud-Szenarien.

### Vergleichstabelle

Werfen Sie einen Blick auf die folgende Vergleichstabelle, um die Unterschiede zwischen diesen Transportmechanismen zu verstehen:

| Transport         | Echtzeit-Updates | Streaming | Skalierbarkeit | Anwendungsfall          |
|-------------------|------------------|-----------|---------------|------------------------|
| stdio             | Nein             | Nein      | Gering        | Lokale CLI-Tools       |
| SSE               | Ja               | Ja        | Mittel        | Web, Echtzeit-Updates  |
| Streamable HTTP   | Ja               | Ja        | Hoch          | Cloud, Multi-Client    |

> **Tipp:** Die Wahl des richtigen Transports beeinflusst Leistung, Skalierbarkeit und Benutzererlebnis. **Streamable HTTP** wird für moderne, skalierbare und cloudfähige Anwendungen empfohlen.

Beachten Sie die Transports stdio und SSE, die in den vorherigen Kapiteln vorgestellt wurden, und wie streamfähiges HTTP der Transport ist, der in diesem Kapitel behandelt wird.

## Streaming: Konzepte und Motivation

Das Verständnis der grundlegenden Konzepte und Motivationen hinter Streaming ist entscheidend für die Implementierung effektiver Echtzeit-Kommunikationssysteme.

**Streaming** ist eine Technik in der Netzwerkprogrammierung, die es ermöglicht, Daten in kleinen, handhabbaren Stücken oder als Ereignisfolge zu senden und zu empfangen, anstatt auf eine vollständige Antwort zu warten. Dies ist besonders nützlich für:

- Große Dateien oder Datensätze.
- Echtzeit-Updates (z. B. Chat, Fortschrittsanzeigen).
- Lang laufende Berechnungen, bei denen der Nutzer informiert bleiben soll.

Hier die wichtigsten Punkte zum Streaming auf einen Blick:

- Daten werden schrittweise geliefert, nicht auf einmal.
- Der Client kann Daten verarbeiten, sobald sie eintreffen.
- Verringert wahrgenommene Latenz und verbessert das Benutzererlebnis.

### Warum Streaming verwenden?

Die Gründe für Streaming sind folgende:

- Nutzer erhalten sofort Feedback, nicht erst am Ende.
- Ermöglicht Echtzeitanwendungen und reaktionsfähige UIs.
- Effizientere Nutzung von Netzwerk- und Rechenressourcen.

### Einfaches Beispiel: HTTP-Streaming-Server & Client

Hier ein einfaches Beispiel, wie Streaming implementiert werden kann:

## Python

**Server (Python, mit FastAPI und StreamingResponse):**

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


**Client (Python, mit requests):**

### Python

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```


Dieses Beispiel zeigt, wie ein Server eine Reihe von Nachrichten an den Client sendet, sobald sie verfügbar sind, anstatt auf alle Nachrichten zu warten.

**Funktionsweise:**
- Der Server liefert jede Nachricht, sobald sie bereit ist.
- Der Client empfängt und gibt jeden Datenblock aus, sobald er ankommt.

**Voraussetzungen:**
- Der Server muss eine Streaming-Antwort verwenden (z. B. `StreamingResponse` in FastAPI).
- Der Client muss die Antwort als Stream verarbeiten (`stream=True` in requests).
- Content-Type ist üblicherweise `text/event-stream` oder `application/octet-stream`.

## Java

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

**Anmerkungen zur Java-Implementierung:**
- Verwendet Spring Boots reaktiven Stack mit `Flux` für Streaming
- `ServerSentEvent` bietet strukturiertes Event-Streaming mit Event-Typen
- `WebClient` mit `bodyToFlux()` ermöglicht reaktive Streaming-Verarbeitung
- `delayElements()` simuliert Verarbeitungszeit zwischen Events
- Events können Typen (`info`, `result`) haben für bessere Client-Verarbeitung

### Vergleich: Klassisches Streaming vs. MCP-Streaming

Die Unterschiede zwischen klassischem Streaming und Streaming in MCP lassen sich folgendermaßen darstellen:

| Merkmal               | Klassisches HTTP-Streaming      | MCP-Streaming (Benachrichtigungen) |
|-----------------------|--------------------------------|-----------------------------------|
| Hauptantwort          | Chunked                        | Einmalig, am Ende                 |
| Fortschritts-Updates  | Werden als Datenblöcke gesendet | Werden als Benachrichtigungen gesendet |
| Client-Anforderungen  | Muss Stream verarbeiten         | Muss Nachrichten-Handler implementieren |
| Anwendungsfall        | Große Dateien, AI-Token-Streams | Fortschritt, Logs, Echtzeit-Feedback |

### Wichtige Unterschiede

Zusätzlich hier einige zentrale Unterschiede:

- **Kommunikationsmuster:**
   - Klassisches HTTP-Streaming: Verwendet einfache Chunked-Transfer-Codierung, um Daten in Blöcken zu senden
   - MCP-Streaming: Nutzt ein strukturiertes Benachrichtigungssystem mit JSON-RPC-Protokoll

- **Nachrichtenformat:**
   - Klassisches HTTP: Reiner Text mit Zeilenumbrüchen
   - MCP: Strukturierte LoggingMessageNotification-Objekte mit Metadaten

- **Client-Implementierung:**
   - Klassisches HTTP: Einfacher Client, der Streaming-Antworten verarbeitet
   - MCP: Komplexerer Client mit Nachrichten-Handler zur Verarbeitung verschiedener Nachrichtentypen

- **Fortschritts-Updates:**
   - Klassisches HTTP: Fortschritt ist Teil des Hauptantwort-Streams
   - MCP: Fortschritt wird über separate Benachrichtigungen gesendet, während die Hauptantwort am Ende kommt

### Empfehlungen

Folgendes empfehlen wir bei der Wahl zwischen klassischem Streaming (wie im Beispiel mit `/stream`) und Streaming via MCP:

- **Für einfache Streaming-Anforderungen:** Klassisches HTTP-Streaming ist einfacher umzusetzen und für grundlegende Streaming-Bedürfnisse ausreichend.

- **Für komplexe, interaktive Anwendungen:** MCP-Streaming bietet einen strukturierteren Ansatz mit reichhaltigeren Metadaten und Trennung zwischen Benachrichtigungen und Endergebnissen.

- **Für KI-Anwendungen:** Das Benachrichtigungssystem von MCP ist besonders nützlich für lang laufende KI-Aufgaben, bei denen Nutzer über Fortschritte informiert werden sollen.

## Streaming in MCP

Sie haben nun einige Empfehlungen und Vergleiche zum Unterschied zwischen klassischem Streaming und MCP-Streaming gesehen. Nun gehen wir ins Detail, wie Sie Streaming in MCP nutzen können.

Das Verständnis, wie Streaming im MCP-Framework funktioniert, ist entscheidend, um reaktionsfähige Anwendungen zu bauen, die Nutzern während lang laufender Operationen Echtzeit-Feedback geben.

Im MCP geht es beim Streaming nicht darum, die Hauptantwort in Blöcken zu senden, sondern **Benachrichtigungen** an den Client zu schicken, während ein Tool eine Anfrage verarbeitet. Diese Benachrichtigungen können Fortschrittsupdates, Logs oder andere Ereignisse enthalten.

### Wie funktioniert das?

Das Hauptergebnis wird weiterhin als einzelne Antwort gesendet. Benachrichtigungen können jedoch während der Verarbeitung als separate Nachrichten gesendet werden und so den Client in Echtzeit informieren. Der Client muss in der Lage sein, diese Benachrichtigungen zu verarbeiten und anzuzeigen.

## Was ist eine Benachrichtigung?

Wir sprachen von „Benachrichtigung“ – was bedeutet das im Kontext von MCP?

Eine Benachrichtigung ist eine Nachricht, die vom Server an den Client gesendet wird, um über Fortschritt, Status oder andere Ereignisse während einer lang laufenden Operation zu informieren. Benachrichtigungen erhöhen Transparenz und verbessern das Nutzererlebnis.

Beispielsweise soll ein Client eine Benachrichtigung senden, sobald der initiale Handshake mit dem Server erfolgt ist.

Eine Benachrichtigung sieht als JSON-Nachricht so aus:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Benachrichtigungen gehören zu einem Thema in MCP, das als ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) bezeichnet wird.

Damit Logging funktioniert, muss der Server es als Feature/Fähigkeit aktivieren, etwa so:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Je nach verwendetem SDK ist Logging möglicherweise standardmäßig aktiviert oder muss explizit in der Serverkonfiguration eingeschaltet werden.

Es gibt verschiedene Arten von Benachrichtigungen:

| Level     | Beschreibung                  | Beispielanwendung             |
|-----------|------------------------------|------------------------------|
| debug     | Detaillierte Debug-Informationen | Funktionsaufruf/-rückkehr    |
| info      | Allgemeine Informationsmeldungen | Fortschrittsupdates          |
| notice    | Normale, aber bedeutende Ereignisse | Konfigurationsänderungen     |
| warning   | Warnungen                    | Nutzung veralteter Features  |
| error     | Fehlerbedingungen            | Fehlgeschlagene Operationen  |
| critical  | Kritische Bedingungen        | Ausfälle von Systemkomponenten |
| alert     | Sofortiges Handeln erforderlich | Datenkorruption erkannt     |
| emergency | System ist nicht nutzbar     | Komplettausfall des Systems  |

## Benachrichtigungen in MCP implementieren

Um Benachrichtigungen in MCP zu implementieren, müssen sowohl Server- als auch Client-Seite für Echtzeit-Updates eingerichtet werden. So kann Ihre Anwendung Nutzern während lang laufender Operationen sofortiges Feedback geben.

### Serverseitig: Benachrichtigungen senden

Beginnen wir mit der Serverseite. In MCP definieren Sie Tools, die während der Verarbeitung von Anfragen Benachrichtigungen senden können. Der Server verwendet das Kontextobjekt (meist `ctx`), um Nachrichten an den Client zu schicken.

### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

Im obigen Beispiel sendet das Tool `process_files` drei Benachrichtigungen an den Client, während es jede Datei verarbeitet. Die Methode `ctx.info()` wird verwendet, um Informationsmeldungen zu senden.

Zusätzlich muss Ihr Server einen Streaming-Transport (z. B. `streamable-http`) verwenden und Ihr Client einen Nachrichten-Handler implementieren, der Benachrichtigungen verarbeitet. So richten Sie den Server auf den `streamable-http`-Transport ein:

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

In diesem .NET-Beispiel ist das Tool `ProcessFiles` mit dem `Tool`-Attribut versehen und sendet drei Benachrichtigungen an den Client, während es jede Datei verarbeitet. Die Methode `ctx.Info()` wird verwendet, um Informationsmeldungen zu senden.

Um Benachrichtigungen in Ihrem .NET MCP-Server zu aktivieren, stellen Sie sicher, dass Sie einen Streaming-Transport verwenden:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

### Clientseitig: Benachrichtigungen empfangen

Der Client muss einen Nachrichten-Handler implementieren, der Benachrichtigungen verarbeitet und anzeigt, sobald sie eintreffen.

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

Im obigen Code prüft die Funktion `message_handler`, ob die eingehende Nachricht eine Benachrichtigung ist. Falls ja, wird sie ausgegeben; andernfalls wird sie als reguläre Servernachricht verarbeitet. Beachten Sie auch, wie die `ClientSession` mit dem `message_handler` initialisiert wird, um eingehende Benachrichtigungen zu verarbeiten.

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

In diesem .NET-Beispiel prüft die Funktion `MessageHandler`, ob die eingehende Nachricht eine Benachrichtigung ist. Falls ja, wird sie ausgegeben; andernfalls wird sie als reguläre Servernachricht verarbeitet. Die `ClientSession` wird über die `ClientSessionOptions` mit dem Nachrichten-Handler initialisiert.

Um Benachrichtigungen zu ermöglichen, stellen Sie sicher, dass Ihr Server einen Streaming-Transport (wie `streamable-http`) verwendet und Ihr Client einen Nachrichten-Handler implementiert.

## Fortschrittsbenachrichtigungen & Szenarien

Dieser Abschnitt erklärt das Konzept der Fortschrittsbenachrichtigungen in MCP, warum sie wichtig sind und wie man sie mit Streamable HTTP implementiert. Außerdem finden Sie eine praktische Aufgabe zur Vertiefung.

Fortschrittsbenachrichtigungen sind Echtzeit-Nachrichten, die vom Server während lang laufender Operationen an den Client gesendet werden. Anstatt auf das Ende des gesamten Prozesses zu warten, hält der Server den Client über den aktuellen Status auf dem Laufenden. Das erhöht Transparenz, verbessert das Nutzererlebnis und erleichtert das Debugging.

**Beispiel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Warum Fortschrittsbenachrichtigungen verwenden?

Fortschrittsbenachrichtigungen sind aus mehreren Gründen wichtig:

- **Besseres Nutzererlebnis:** Nutzer sehen Updates während der Arbeit, nicht nur am Ende.
- **Echtzeit-Feedback:** Clients können Fortschrittsbalken oder Logs anzeigen, was die App reaktionsschneller wirken lässt.
- **Einfacheres Debugging und Monitoring:** Entwickler und Nutzer sehen, wo ein Prozess langsam ist oder hängt.

### Wie Fortschrittsbenachrichtigungen implementieren?

So implementieren Sie Fortschrittsbenachrichtigungen in MCP:

- **Serverseitig:** Verwenden Sie `ctx.info()` oder `ctx.log()`, um Benachrichtigungen zu senden, sobald ein Element verarbeitet wurde. So erhält der Client Nachrichten vor dem Hauptergebnis.
- **Clientseitig:** Implementieren Sie einen Nachrichten-Handler, der Benachrichtigungen empfängt und anzeigt. Dieser unterscheidet zwischen Benachrichtigungen und dem Endergebnis.

**Server-Beispiel:**

## Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```


**Client-Beispiel:**

### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```


## Sicherheitsaspekte

Bei der Implementierung von MCP-Servern mit HTTP-basierten Transporten ist Sicherheit ein zentrales Thema, das sorgfältige Beachtung verschiedener Angriffsvektoren und Schutzmechanismen erfordert.

### Überblick

Sicherheit ist entscheidend, wenn MCP-Server über HTTP exponiert werden. Streamable HTTP bringt neue Angriffsflächen mit sich und erfordert eine sorgfältige Konfiguration.

### Wichtige Punkte
- **Validierung des Origin-Headers:** Validieren Sie immer den `Origin`-Header, um DNS-Rebinding-Angriffe zu verhindern.
- **Bindung an localhost:** Für lokale Entwicklung sollten Server an `localhost` gebunden werden, um öffentliche Zugriffe zu vermeiden.
- **Authentifizierung:** Implementieren Sie Authentifizierung (z. B. API-Schlüssel, OAuth) für Produktionsumgebungen.
- **CORS:** Konfigurieren Sie Cross-Origin Resource Sharing (CORS)-Richtlinien, um den Zugriff einzuschränken.
- **HTTPS:** Verwenden Sie HTTPS in der Produktion, um den Datenverkehr zu verschlüsseln.

### Best Practices
- Vertrauen Sie eingehenden Anfragen niemals ohne Validierung.
- Protokollieren und überwachen Sie alle Zugriffe und Fehler.
- Aktualisieren Sie regelmäßig Abhängigkeiten, um Sicherheitslücken zu schließen.

### Herausforderungen
- Balance zwischen Sicherheit und einfacher Entwicklung
- Sicherstellung der Kompatibilität mit verschiedenen Client-Umgebungen

## Umstieg von SSE auf Streamable HTTP

Für Anwendungen, die derzeit Server-Sent Events (SSE) verwenden, bietet die Migration zu Streamable HTTP erweiterte Möglichkeiten und eine bessere langfristige Nachhaltigkeit für Ihre MCP-Implementierungen.
### Warum upgraden?

Es gibt zwei überzeugende Gründe, von SSE auf Streamable HTTP umzusteigen:

- Streamable HTTP bietet bessere Skalierbarkeit, Kompatibilität und umfangreichere Benachrichtigungsfunktionen als SSE.
- Es ist der empfohlene Transport für neue MCP-Anwendungen.

### Migrationsschritte

So können Sie in Ihren MCP-Anwendungen von SSE auf Streamable HTTP migrieren:

- **Servercode aktualisieren**, um `transport="streamable-http"` in `mcp.run()` zu verwenden.
- **Clientcode aktualisieren**, um `streamablehttp_client` anstelle des SSE-Clients zu nutzen.
- **Einen Nachrichten-Handler implementieren**, der Benachrichtigungen im Client verarbeitet.
- **Kompatibilität testen** mit bestehenden Tools und Workflows.

### Kompatibilität erhalten

Es wird empfohlen, während des Migrationsprozesses die Kompatibilität mit bestehenden SSE-Clients beizubehalten. Hier einige Strategien:

- Sie können sowohl SSE als auch Streamable HTTP unterstützen, indem Sie beide Transports an unterschiedlichen Endpunkten betreiben.
- Migrieren Sie die Clients schrittweise auf den neuen Transport.

### Herausforderungen

Achten Sie während der Migration auf folgende Herausforderungen:

- Sicherstellen, dass alle Clients aktualisiert werden
- Umgang mit Unterschieden bei der Zustellung von Benachrichtigungen

## Sicherheitsaspekte

Sicherheit sollte bei der Implementierung eines Servers oberste Priorität haben, insbesondere bei der Verwendung von HTTP-basierten Transporten wie Streamable HTTP in MCP.

Bei der Implementierung von MCP-Servern mit HTTP-basierten Transporten ist Sicherheit ein zentrales Thema, das sorgfältige Beachtung verschiedener Angriffsvektoren und Schutzmechanismen erfordert.

### Überblick

Sicherheit ist entscheidend, wenn MCP-Server über HTTP zugänglich gemacht werden. Streamable HTTP bringt neue Angriffsflächen mit sich und erfordert eine sorgfältige Konfiguration.

Hier einige wichtige Sicherheitsaspekte:

- **Validierung des Origin-Headers**: Validieren Sie stets den `Origin`-Header, um DNS-Rebinding-Angriffe zu verhindern.
- **Bindung an localhost**: Für die lokale Entwicklung sollten Server an `localhost` gebunden werden, um eine öffentliche Zugänglichkeit zu vermeiden.
- **Authentifizierung**: Implementieren Sie für den Produktionseinsatz eine Authentifizierung (z. B. API-Schlüssel, OAuth).
- **CORS**: Konfigurieren Sie Cross-Origin Resource Sharing (CORS)-Richtlinien, um den Zugriff einzuschränken.
- **HTTPS**: Verwenden Sie in der Produktion HTTPS, um den Datenverkehr zu verschlüsseln.

### Best Practices

Zusätzlich hier einige bewährte Vorgehensweisen für die Sicherheit Ihres MCP-Streaming-Servers:

- Vertrauen Sie eingehenden Anfragen niemals ohne Validierung.
- Protokollieren und überwachen Sie alle Zugriffe und Fehler.
- Aktualisieren Sie regelmäßig Abhängigkeiten, um Sicherheitslücken zu schließen.

### Herausforderungen

Bei der Implementierung von Sicherheit in MCP-Streaming-Servern werden Sie auf folgende Herausforderungen stoßen:

- Die Balance zwischen Sicherheit und einfacher Entwicklung finden
- Kompatibilität mit verschiedenen Client-Umgebungen sicherstellen

### Aufgabe: Erstellen Sie Ihre eigene Streaming-MCP-App

**Szenario:**  
Erstellen Sie einen MCP-Server und -Client, bei dem der Server eine Liste von Elementen (z. B. Dateien oder Dokumente) verarbeitet und für jedes verarbeitete Element eine Benachrichtigung sendet. Der Client soll jede Benachrichtigung sofort anzeigen.

**Schritte:**

1. Implementieren Sie ein Server-Tool, das eine Liste verarbeitet und für jedes Element Benachrichtigungen sendet.  
2. Implementieren Sie einen Client mit einem Nachrichten-Handler, der Benachrichtigungen in Echtzeit anzeigt.  
3. Testen Sie Ihre Implementierung, indem Sie Server und Client ausführen und die Benachrichtigungen beobachten.

[Solution](./solution/README.md)

## Weiterführende Literatur & Wie geht es weiter?

Um Ihre Reise mit MCP-Streaming fortzusetzen und Ihr Wissen zu vertiefen, bietet dieser Abschnitt zusätzliche Ressourcen und empfohlene nächste Schritte zum Erstellen fortgeschrittener Anwendungen.

### Weiterführende Literatur

- [Microsoft: Einführung in HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)  
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)  
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)  
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)  

### Wie geht es weiter?

- Versuchen Sie, fortgeschrittenere MCP-Tools zu entwickeln, die Streaming für Echtzeitanalysen, Chat oder kollaboratives Bearbeiten nutzen.  
- Erkunden Sie die Integration von MCP-Streaming mit Frontend-Frameworks (React, Vue usw.) für Live-UI-Updates.  
- Nächster Schritt: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.