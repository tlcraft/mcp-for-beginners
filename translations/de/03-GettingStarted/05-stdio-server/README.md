<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:17:15+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "de"
}
-->
# MCP-Server mit stdio-Transport

> **⚠️ Wichtige Aktualisierung**: Ab der MCP-Spezifikation vom 18.06.2025 wurde der eigenständige SSE-Transport (Server-Sent Events) **veraltet** und durch den "Streamable HTTP"-Transport ersetzt. Die aktuelle MCP-Spezifikation definiert zwei primäre Transportmechanismen:
> 1. **stdio** – Standard-Ein-/Ausgabe (empfohlen für lokale Server)
> 2. **Streamable HTTP** – Für Remote-Server, die intern SSE verwenden können
>
> Diese Lektion wurde aktualisiert, um sich auf den **stdio-Transport** zu konzentrieren, der für die meisten MCP-Server-Implementierungen der empfohlene Ansatz ist.

Der stdio-Transport ermöglicht es MCP-Servern, über Standard-Ein- und -Ausgabeströme mit Clients zu kommunizieren. Dies ist der am häufigsten verwendete und empfohlene Transportmechanismus in der aktuellen MCP-Spezifikation, da er eine einfache und effiziente Möglichkeit bietet, MCP-Server zu erstellen, die problemlos in verschiedene Client-Anwendungen integriert werden können.

## Überblick

Diese Lektion behandelt, wie MCP-Server mit dem stdio-Transport erstellt und genutzt werden können.

## Lernziele

Am Ende dieser Lektion wirst du in der Lage sein:

- Einen MCP-Server mit dem stdio-Transport zu erstellen.
- Einen MCP-Server mit dem Inspector zu debuggen.
- Einen MCP-Server mit Visual Studio Code zu nutzen.
- Die aktuellen MCP-Transportmechanismen zu verstehen und zu wissen, warum stdio empfohlen wird.

## stdio-Transport – Funktionsweise

Der stdio-Transport ist einer von zwei unterstützten Transporttypen in der aktuellen MCP-Spezifikation (18.06.2025). So funktioniert er:

- **Einfache Kommunikation**: Der Server liest JSON-RPC-Nachrichten von der Standard-Eingabe (`stdin`) und sendet Nachrichten an die Standard-Ausgabe (`stdout`).
- **Prozessbasiert**: Der Client startet den MCP-Server als Unterprozess.
- **Nachrichtenformat**: Nachrichten sind einzelne JSON-RPC-Anfragen, Benachrichtigungen oder Antworten, die durch Zeilenumbrüche getrennt sind.
- **Protokollierung**: Der Server KANN UTF-8-Zeichenfolgen zur Standard-Fehlerausgabe (`stderr`) für Protokollierungszwecke schreiben.

### Wichtige Anforderungen:
- Nachrichten MÜSSEN durch Zeilenumbrüche getrennt sein und DÜRFEN KEINE eingebetteten Zeilenumbrüche enthalten.
- Der Server DARF NICHTS an `stdout` schreiben, das keine gültige MCP-Nachricht ist.
- Der Client DARF NICHTS an die `stdin` des Servers schreiben, das keine gültige MCP-Nachricht ist.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

Im obigen Code:

- Importieren wir die `Server`-Klasse und `StdioServerTransport` aus dem MCP-SDK.
- Erstellen wir eine Serverinstanz mit grundlegender Konfiguration und Fähigkeiten.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

Im obigen Code:

- Erstellen wir eine Serverinstanz mit dem MCP-SDK.
- Definieren wir Tools mithilfe von Dekoratoren.
- Verwenden wir den `stdio_server`-Kontextmanager, um den Transport zu verwalten.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

Der Hauptunterschied zu SSE besteht darin, dass stdio-Server:

- Keine Webserver-Einrichtung oder HTTP-Endpunkte erfordern.
- Als Unterprozesse vom Client gestartet werden.
- Über stdin/stdout-Ströme kommunizieren.
- Einfacher zu implementieren und zu debuggen sind.

## Übung: Erstellen eines stdio-Servers

Um unseren Server zu erstellen, müssen wir zwei Dinge beachten:

- Wir müssen einen Webserver verwenden, um Endpunkte für Verbindungen und Nachrichten bereitzustellen.

## Labor: Erstellen eines einfachen MCP-stdio-Servers

In diesem Labor erstellen wir einen einfachen MCP-Server mit dem empfohlenen stdio-Transport. Dieser Server wird Tools bereitstellen, die Clients mithilfe des Standard-Model-Context-Protokolls aufrufen können.

### Voraussetzungen

- Python 3.8 oder höher
- MCP Python SDK: `pip install mcp`
- Grundlegendes Verständnis von asynchroner Programmierung

Beginnen wir mit der Erstellung unseres ersten MCP-stdio-Servers:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## Wichtige Unterschiede zum veralteten SSE-Ansatz

**Stdio-Transport (aktueller Standard):**
- Einfaches Unterprozessmodell – Client startet Server als Kindprozess.
- Kommunikation über stdin/stdout mit JSON-RPC-Nachrichten.
- Keine HTTP-Server-Einrichtung erforderlich.
- Bessere Leistung und Sicherheit.
- Einfacheres Debugging und Entwicklung.

**SSE-Transport (veraltet seit MCP 18.06.2025):**
- Erforderte HTTP-Server mit SSE-Endpunkten.
- Komplexere Einrichtung mit Webserver-Infrastruktur.
- Zusätzliche Sicherheitsüberlegungen für HTTP-Endpunkte.
- Jetzt durch Streamable HTTP für webbasierte Szenarien ersetzt.

### Erstellen eines Servers mit stdio-Transport

Um unseren stdio-Server zu erstellen, müssen wir:

1. **Die erforderlichen Bibliotheken importieren** – Wir benötigen die MCP-Serverkomponenten und den stdio-Transport.
2. **Eine Serverinstanz erstellen** – Den Server mit seinen Fähigkeiten definieren.
3. **Tools definieren** – Die Funktionalität hinzufügen, die wir bereitstellen möchten.
4. **Den Transport einrichten** – Die stdio-Kommunikation konfigurieren.
5. **Den Server starten** – Den Server starten und Nachrichten verarbeiten.

Lass uns dies Schritt für Schritt umsetzen:

### Schritt 1: Einen einfachen stdio-Server erstellen

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### Schritt 2: Weitere Tools hinzufügen

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### Schritt 3: Den Server ausführen

Speichere den Code als `server.py` und führe ihn über die Befehlszeile aus:

```bash
python server.py
```

Der Server startet und wartet auf Eingaben über stdin. Er kommuniziert über JSON-RPC-Nachrichten über den stdio-Transport.

### Schritt 4: Testen mit dem Inspector

Du kannst deinen Server mit dem MCP Inspector testen:

1. Installiere den Inspector: `npx @modelcontextprotocol/inspector`
2. Starte den Inspector und verweise auf deinen Server.
3. Teste die erstellten Tools.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```

### Was du sehen solltest

Wenn dein Server korrekt gestartet wurde, solltest du Folgendes sehen:
- Serverfähigkeiten, die im Inspector aufgelistet sind.
- Tools, die zum Testen verfügbar sind.
- Erfolgreiche JSON-RPC-Nachrichtenaustausche.
- Tool-Antworten, die in der Benutzeroberfläche angezeigt werden.

### Häufige Probleme und Lösungen

**Server startet nicht:**
- Überprüfe, ob alle Abhängigkeiten installiert sind: `pip install mcp`.
- Verifiziere die Python-Syntax und Einrückungen.
- Suche nach Fehlermeldungen in der Konsole.

**Tools werden nicht angezeigt:**
- Stelle sicher, dass `@server.tool()`-Dekoratoren vorhanden sind.
- Überprüfe, ob Tool-Funktionen vor `main()` definiert sind.
- Verifiziere, dass der Server korrekt konfiguriert ist.

**Verbindungsprobleme:**
- Stelle sicher, dass der Server den stdio-Transport korrekt verwendet.
- Überprüfe, ob keine anderen Prozesse stören.
- Verifiziere die Syntax des Inspector-Befehls.

## Aufgabe

Versuche, deinen Server mit weiteren Fähigkeiten auszustatten. Sieh dir [diese Seite](https://api.chucknorris.io/) an, um beispielsweise ein Tool hinzuzufügen, das eine API aufruft. Du entscheidest, wie der Server aussehen soll. Viel Spaß :)

## Lösung

[Solution](./solution/README.md) Hier ist eine mögliche Lösung mit funktionierendem Code.

## Wichtige Erkenntnisse

Die wichtigsten Erkenntnisse aus diesem Kapitel sind:

- Der stdio-Transport ist der empfohlene Mechanismus für lokale MCP-Server.
- Stdio-Transport ermöglicht nahtlose Kommunikation zwischen MCP-Servern und Clients über Standard-Ein- und -Ausgabeströme.
- Du kannst sowohl den Inspector als auch Visual Studio Code verwenden, um stdio-Server direkt zu nutzen, was Debugging und Integration erleichtert.

## Beispiele

- [Java-Rechner](../samples/java/calculator/README.md)
- [.Net-Rechner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript-Rechner](../samples/javascript/README.md)
- [TypeScript-Rechner](../samples/typescript/README.md)
- [Python-Rechner](../../../../03-GettingStarted/samples/python) 

## Zusätzliche Ressourcen

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Was kommt als Nächstes?

## Nächste Schritte

Nachdem du gelernt hast, wie man MCP-Server mit dem stdio-Transport erstellt, kannst du dich mit fortgeschrittenen Themen beschäftigen:

- **Weiter**: [HTTP-Streaming mit MCP (Streamable HTTP)](../06-http-streaming/README.md) – Erfahre mehr über den anderen unterstützten Transportmechanismus für Remote-Server.
- **Fortgeschritten**: [MCP-Sicherheitsbest-Practices](../../02-Security/README.md) – Implementiere Sicherheit in deinen MCP-Servern.
- **Produktion**: [Bereitstellungsstrategien](../09-deployment/README.md) – Setze deine Server für den Produktionseinsatz ein.

## Zusätzliche Ressourcen

- [MCP-Spezifikation 18.06.2025](https://spec.modelcontextprotocol.io/specification/) – Offizielle Spezifikation.
- [MCP-SDK-Dokumentation](https://github.com/modelcontextprotocol/sdk) – SDK-Referenzen für alle Sprachen.
- [Community-Beispiele](../../06-CommunityContributions/README.md) – Weitere Serverbeispiele aus der Community.

---

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, weisen wir darauf hin, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache sollte als maßgebliche Quelle betrachtet werden. Für kritische Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.