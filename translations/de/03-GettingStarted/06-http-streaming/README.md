<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T21:52:37+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "de"
}
-->
# HTTPS-Streaming mit dem Model Context Protocol (MCP)

Dieses Kapitel bietet eine umfassende Anleitung zur Implementierung von sicherem, skalierbarem und Echtzeit-Streaming mit dem Model Context Protocol (MCP) über HTTPS. Es behandelt die Motivation für Streaming, die verfügbaren Transportmechanismen, wie man streamfähiges HTTP in MCP implementiert, Sicherheitsbest Practices, die Migration von SSE sowie praktische Hinweise zum Erstellen eigener Streaming-MCP-Anwendungen.

## Transportmechanismen und Streaming in MCP

Dieser Abschnitt beleuchtet die verschiedenen in MCP verfügbaren Transportmechanismen und deren Rolle bei der Ermöglichung von Streaming-Funktionalitäten für die Echtzeitkommunikation zwischen Clients und Servern.

### Was ist ein Transportmechanismus?

Ein Transportmechanismus definiert, wie Daten zwischen Client und Server ausgetauscht werden. MCP unterstützt mehrere Transporttypen, um unterschiedlichen Umgebungen und Anforderungen gerecht zu werden:

- **stdio**: Standard Ein-/Ausgabe, geeignet für lokale und CLI-basierte Tools. Einfach, aber nicht für Web oder Cloud geeignet.
- **SSE (Server-Sent Events)**: Ermöglicht es Servern, Echtzeit-Updates über HTTP an Clients zu senden. Gut für Web-UIs, aber begrenzt in Skalierbarkeit und Flexibilität.
- **Streamable HTTP**: Moderner HTTP-basierter Streaming-Transport, unterstützt Benachrichtigungen und bessere Skalierbarkeit. Empfohlen für die meisten Produktions- und Cloud-Szenarien.

### Vergleichstabelle

Werfen Sie einen Blick auf die folgende Vergleichstabelle, um die Unterschiede zwischen diesen Transportmechanismen zu verstehen:

| Transport         | Echtzeit-Updates | Streaming | Skalierbarkeit | Anwendungsfall          |
|-------------------|------------------|-----------|---------------|------------------------|
| stdio             | Nein             | Nein      | Niedrig       | Lokale CLI-Tools       |
| SSE               | Ja               | Ja        | Mittel        | Web, Echtzeit-Updates  |
| Streamable HTTP   | Ja               | Ja        | Hoch          | Cloud, Multi-Client    |

> **Tipp:** Die Wahl des richtigen Transports beeinflusst Leistung, Skalierbarkeit und Benutzererlebnis. **Streamable HTTP** wird für moderne, skalierbare und cloudfähige Anwendungen empfohlen.

Beachten Sie die Transports stdio und SSE, die in den vorherigen Kapiteln vorgestellt wurden, und wie streamfähiges HTTP der Transport ist, der in diesem Kapitel behandelt wird.

## Streaming: Konzepte und Motivation

Das Verständnis der grundlegenden Konzepte und der Motivation hinter Streaming ist entscheidend für die Umsetzung effektiver Echtzeit-Kommunikationssysteme.

**Streaming** ist eine Technik in der Netzwerkprogrammierung, die es erlaubt, Daten in kleinen, handhabbaren Teilen oder als eine Folge von Ereignissen zu senden und zu empfangen, anstatt auf die vollständige Antwort zu warten. Dies ist besonders nützlich für:

- Große Dateien oder Datensätze.
- Echtzeit-Updates (z. B. Chat, Fortschrittsanzeigen).
- Lang laufende Berechnungen, bei denen der Benutzer informiert bleiben soll.

Das sollten Sie auf hoher Ebene über Streaming wissen:

- Daten werden schrittweise geliefert, nicht auf einmal.
- Der Client kann Daten verarbeiten, sobald sie eintreffen.
- Verringert wahrgenommene Latenz und verbessert das Benutzererlebnis.

### Warum Streaming verwenden?

Die Gründe für den Einsatz von Streaming sind folgende:

- Nutzer erhalten sofort Feedback, nicht erst am Ende.
- Ermöglicht Echtzeitanwendungen und reaktionsfähige UIs.
- Effizientere Nutzung von Netzwerk- und Rechenressourcen.

### Einfaches Beispiel: HTTP-Streaming-Server & Client

Hier ein einfaches Beispiel, wie Streaming implementiert werden kann:

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

Dieses Beispiel zeigt, wie ein Server eine Reihe von Nachrichten an den Client sendet, sobald sie verfügbar sind, anstatt auf alle Nachrichten gleichzeitig zu warten.

**Funktionsweise:**
- Der Server liefert jede Nachricht, sobald sie bereit ist.
- Der Client empfängt und gibt jeden Datenblock aus, sobald er ankommt.

**Anforderungen:**
- Der Server muss eine Streaming-Antwort verwenden (z. B. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`), anstatt Streaming über MCP zu wählen.

- **Für einfache Streaming-Anforderungen:** Klassisches HTTP-Streaming ist einfacher zu implementieren und für grundlegende Streaming-Bedürfnisse ausreichend.

- **Für komplexe, interaktive Anwendungen:** MCP-Streaming bietet einen strukturierteren Ansatz mit reichhaltigeren Metadaten und Trennung zwischen Benachrichtigungen und Endergebnissen.

- **Für KI-Anwendungen:** Das Benachrichtigungssystem von MCP ist besonders nützlich für lang laufende KI-Aufgaben, bei denen Nutzer über den Fortschritt informiert werden sollen.

## Streaming in MCP

Sie haben bisher einige Empfehlungen und Vergleiche zur klassischen Streaming-Methode und Streaming in MCP gesehen. Nun schauen wir uns genau an, wie Sie Streaming in MCP nutzen können.

Das Verständnis, wie Streaming innerhalb des MCP-Frameworks funktioniert, ist entscheidend, um reaktionsfähige Anwendungen zu erstellen, die Nutzern während lang laufender Prozesse Echtzeit-Feedback geben.

Im MCP geht es beim Streaming nicht darum, die Hauptantwort in Teilen zu senden, sondern **Benachrichtigungen** an den Client zu schicken, während ein Tool eine Anfrage verarbeitet. Diese Benachrichtigungen können Fortschritts-Updates, Logs oder andere Ereignisse enthalten.

### Wie funktioniert das?

Das Hauptergebnis wird weiterhin als einzelne Antwort gesendet. Benachrichtigungen können jedoch als separate Nachrichten während der Verarbeitung gesendet werden und so den Client in Echtzeit aktualisieren. Der Client muss in der Lage sein, diese Benachrichtigungen zu verarbeiten und anzuzeigen.

## Was ist eine Benachrichtigung?

Wir sprachen von „Benachrichtigung“ – was bedeutet das im Kontext von MCP?

Eine Benachrichtigung ist eine Nachricht, die vom Server an den Client gesendet wird, um über Fortschritt, Status oder andere Ereignisse während einer lang laufenden Operation zu informieren. Benachrichtigungen erhöhen die Transparenz und verbessern das Nutzererlebnis.

Zum Beispiel soll ein Client eine Benachrichtigung senden, sobald der initiale Handshake mit dem Server abgeschlossen ist.

Eine Benachrichtigung sieht als JSON-Nachricht etwa so aus:

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

Damit Logging funktioniert, muss der Server es als Feature/Fähigkeit aktivieren, zum Beispiel so:

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

| Level     | Beschreibung                  | Beispiel-Anwendungsfall          |
|-----------|------------------------------|---------------------------------|
| debug     | Detaillierte Debug-Informationen | Funktionsaufruf/-rückkehr       |
| info      | Allgemeine Informationsmeldungen | Fortschrittsupdates             |
| notice    | Normale, aber wichtige Ereignisse | Konfigurationsänderungen        |
| warning   | Warnhinweise                  | Nutzung veralteter Funktionen    |
| error     | Fehlerbedingungen            | Fehler bei Operationen           |
| critical  | Kritische Bedingungen         | Ausfall von Systemkomponenten    |
| alert     | Sofortiges Handeln erforderlich | Datenkorruption erkannt          |
| emergency | System ist nicht nutzbar      | Komplettausfall des Systems      |

## Benachrichtigungen in MCP implementieren

Um Benachrichtigungen in MCP zu implementieren, müssen Sie sowohl Server- als auch Client-Seite so einrichten, dass sie Echtzeit-Updates verarbeiten können. So kann Ihre Anwendung den Nutzern während lang laufender Vorgänge sofortiges Feedback geben.

### Serverseitig: Benachrichtigungen senden

Beginnen wir mit der Serverseite. In MCP definieren Sie Tools, die während der Verarbeitung von Anfragen Benachrichtigungen senden können. Der Server verwendet das Kontextobjekt (meist `ctx`), um Nachrichten an den Client zu schicken.

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

Im obigen Beispiel nutzt `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` den Transport:

```python
mcp.run(transport="streamable-http")
```

</details>

### Clientseitig: Benachrichtigungen empfangen

Der Client muss einen Nachrichten-Handler implementieren, um Benachrichtigungen zu verarbeiten und anzuzeigen, sobald sie eintreffen.

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

Im obigen Code implementiert `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` einen Nachrichten-Handler, der Benachrichtigungen verarbeitet.

## Fortschritts-Benachrichtigungen & Szenarien

Dieser Abschnitt erklärt das Konzept der Fortschritts-Benachrichtigungen in MCP, warum sie wichtig sind und wie man sie mit Streamable HTTP implementiert. Außerdem gibt es eine praktische Aufgabe zur Vertiefung.

Fortschritts-Benachrichtigungen sind Echtzeit-Nachrichten, die vom Server während lang laufender Operationen an den Client gesendet werden. Anstatt auf den Abschluss des gesamten Prozesses zu warten, hält der Server den Client über den aktuellen Status auf dem Laufenden. Das erhöht Transparenz, verbessert das Nutzererlebnis und erleichtert das Debugging.

**Beispiel:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Warum Fortschritts-Benachrichtigungen verwenden?

Fortschritts-Benachrichtigungen sind aus mehreren Gründen wichtig:

- **Besseres Nutzererlebnis:** Nutzer sehen Updates während der Arbeit, nicht erst am Ende.
- **Echtzeit-Feedback:** Clients können Fortschrittsbalken oder Logs anzeigen, was die App reaktionsfähiger macht.
- **Einfacheres Debugging und Monitoring:** Entwickler und Nutzer sehen, wo ein Prozess langsam ist oder hängt.

### Wie implementiert man Fortschritts-Benachrichtigungen?

So implementieren Sie Fortschritts-Benachrichtigungen in MCP:

- **Serverseitig:** Verwenden Sie `ctx.info()` bzw. `ctx.log()`, um Benachrichtigungen zu senden, sobald ein Element verarbeitet wurde. So erhält der Client Nachrichten vor dem Hauptergebnis.
- **Clientseitig:** Implementieren Sie einen Nachrichten-Handler, der Benachrichtigungen empfängt und anzeigt. Dieser unterscheidet zwischen Benachrichtigungen und dem Endergebnis.

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

Beim Implementieren von MCP-Servern mit HTTP-basierten Transporten wird Sicherheit zu einem zentralen Thema, das sorgfältige Beachtung verschiedener Angriffsvektoren und Schutzmechanismen erfordert.

### Überblick

Sicherheit ist entscheidend, wenn MCP-Server über HTTP zugänglich gemacht werden. Streamable HTTP bringt neue Angriffsflächen mit sich und erfordert eine sorgfältige Konfiguration.

### Wichtige Punkte
- **Validierung des Origin-Headers:** Überprüfen Sie immer den `Origin`-Header, um unerwünschte Zugriffe zu verhindern.
- **Authentifizierung und Autorisierung:** Stellen Sie sicher, dass nur berechtigte Clients Zugriff erhalten.
- **TLS/HTTPS verwenden:** Alle Verbindungen sollten verschlüsselt sein.
- **Eingabevalidierung:** Validieren Sie alle eingehenden Daten, um Injection-Angriffe zu vermeiden.
- **Timeouts und Ressourcenlimits:** Verhindern Sie Denial-of-Service-Angriffe durch angemessene Limits.
- **Logging und Monitoring:** Erfassen Sie sicherheitsrelevante Ereignisse und überwachen Sie den Betrieb.

### Kompatibilität bewahren

Es wird empfohlen, während der Migration die Kompatibilität mit bestehenden SSE-Clients aufrechtzuerhalten. Folgende Strategien sind möglich:

- Sie können sowohl SSE als auch Streamable HTTP unterstützen, indem beide Transports auf unterschiedlichen Endpunkten betrieben werden.
- Schrittweise Migration der Clients auf den neuen Transport.

### Herausforderungen

Achten Sie während der Migration auf folgende Herausforderungen:

- Sicherstellen, dass alle Clients aktualisiert werden.
- Umgang mit Unterschieden in der Benachrichtigungszustellung.

### Aufgabe: Erstellen Sie Ihre eigene Streaming-MCP-App

**Szenario:**  
Erstellen Sie einen MCP-Server und -Client, bei dem der Server eine Liste von Elementen (z. B. Dateien oder Dokumente) verarbeitet und für jedes verarbeitete Element eine Benachrichtigung sendet. Der Client soll jede Benachrichtigung sofort anzeigen.

**Schritte:**

1. Implementieren Sie ein Server-Tool, das eine Liste verarbeitet und für jedes Element Benachrichtigungen sendet.
2. Implementieren Sie einen Client mit einem Nachrichten-Handler, der Benachrichtigungen in Echtzeit anzeigt.
3. Testen Sie Ihre Implementierung, indem Sie Server und Client starten und die Benachrichtigungen beobachten.

[Lösung](./solution/README.md)

## Weiterführende Literatur & Wie geht es weiter?

Um Ihre Reise mit MCP-Streaming fortzusetzen und Ihr Wissen zu erweitern, bietet dieser Abschnitt zusätzliche Ressourcen und empfohlene nächste Schritte zum Erstellen fortgeschrittener Anwendungen.

### Weiterführende Literatur

- [Microsoft: Einführung in HTTP-Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Wie geht es weiter?

- Versuchen Sie, komplexere MCP-Tools zu bauen, die Streaming für Echtzeitanalysen, Chat oder kollaboratives Bearbeiten nutzen.
- Erkunden Sie die Integration von MCP-Streaming mit Frontend-Frameworks (React, Vue etc.) für Live-UI-Updates.
- Als nächstes: [Nutzung des AI Toolkits für VSCode](../07-aitk/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.