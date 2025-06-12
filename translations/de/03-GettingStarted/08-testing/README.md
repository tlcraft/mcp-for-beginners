<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-12T22:24:18+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "de"
}
-->
## Testen und Debuggen

Bevor Sie mit dem Testen Ihres MCP-Servers beginnen, ist es wichtig, die verfügbaren Werkzeuge und bewährten Methoden zum Debuggen zu verstehen. Effektives Testen stellt sicher, dass Ihr Server wie erwartet funktioniert und hilft Ihnen, Probleme schnell zu erkennen und zu beheben. Der folgende Abschnitt beschreibt empfohlene Ansätze zur Validierung Ihrer MCP-Implementierung.

## Überblick

Diese Lektion behandelt, wie Sie den richtigen Testansatz und das effektivste Testwerkzeug auswählen.

## Lernziele

Am Ende dieser Lektion können Sie:

- Verschiedene Testansätze beschreiben.
- Unterschiedliche Werkzeuge nutzen, um Ihren Code effektiv zu testen.

## Testen von MCP-Servern

MCP stellt Werkzeuge zur Verfügung, die Ihnen beim Testen und Debuggen Ihrer Server helfen:

- **MCP Inspector**: Ein Kommandozeilenwerkzeug, das sowohl als CLI-Tool als auch als visuelles Tool genutzt werden kann.
- **Manuelles Testen**: Sie können ein Tool wie curl verwenden, um Webanfragen zu stellen, aber jedes Tool, das HTTP ausführen kann, ist geeignet.
- **Unit Testing**: Es ist möglich, Ihr bevorzugtes Testframework zu verwenden, um die Funktionen von Server und Client zu testen.

### Verwendung von MCP Inspector

Wir haben die Nutzung dieses Tools in früheren Lektionen beschrieben, aber hier eine kurze Übersicht. Es ist ein in Node.js gebautes Tool, das Sie durch Aufruf der ausführbaren Datei `npx` verwenden können. Diese lädt das Tool temporär herunter und installiert es, und räumt nach der Ausführung Ihrer Anfrage wieder auf.

Der [MCP Inspector](https://github.com/modelcontextprotocol/inspector) hilft Ihnen dabei:

- **Serverfähigkeiten entdecken**: Automatische Erkennung verfügbarer Ressourcen, Werkzeuge und Eingabeaufforderungen
- **Ausführung von Werkzeugen testen**: Verschiedene Parameter ausprobieren und Antworten in Echtzeit sehen
- **Server-Metadaten anzeigen**: Serverinformationen, Schemata und Konfigurationen prüfen

Eine typische Ausführung des Tools sieht so aus:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Der obige Befehl startet einen MCP und seine visuelle Oberfläche und öffnet eine lokale Weboberfläche in Ihrem Browser. Sie sehen ein Dashboard mit Ihren registrierten MCP-Servern, deren verfügbaren Werkzeugen, Ressourcen und Eingabeaufforderungen. Die Oberfläche ermöglicht es Ihnen, die Ausführung von Werkzeugen interaktiv zu testen, Server-Metadaten zu inspizieren und Echtzeit-Antworten anzuzeigen, was die Validierung und das Debuggen Ihrer MCP-Serverimplementierungen erleichtert.

So könnte das aussehen: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.de.png)

Sie können das Tool auch im CLI-Modus ausführen, indem Sie das Attribut `--cli` hinzufügen. Hier ein Beispiel, wie das Tool im "CLI"-Modus ausgeführt wird, das alle Werkzeuge auf dem Server auflistet:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuelles Testen

Neben dem Einsatz des Inspector-Tools zum Testen der Serverfähigkeiten können Sie auch einen Client verwenden, der HTTP unterstützt, wie zum Beispiel curl.

Mit curl können Sie MCP-Server direkt über HTTP-Anfragen testen:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Wie Sie am obigen Beispiel mit curl sehen, verwenden Sie eine POST-Anfrage, um ein Werkzeug mit einer Nutzlast aufzurufen, die den Namen des Werkzeugs und dessen Parameter enthält. Wählen Sie den Ansatz, der für Sie am besten passt. CLI-Tools sind in der Regel schneller zu bedienen und lassen sich gut skripten, was in CI/CD-Umgebungen hilfreich sein kann.

### Unit Testing

Erstellen Sie Unit-Tests für Ihre Werkzeuge und Ressourcen, um sicherzustellen, dass sie wie erwartet funktionieren. Hier ein Beispiel für Testcode.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

Der obenstehende Code macht Folgendes:

- Nutzt das pytest-Framework, mit dem Sie Tests als Funktionen erstellen und assert-Anweisungen verwenden können.
- Erstellt einen MCP-Server mit zwei verschiedenen Werkzeugen.
- Verwendet die `assert`-Anweisung, um sicherzustellen, dass bestimmte Bedingungen erfüllt sind.

Sehen Sie sich die [vollständige Datei hier](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py) an.

Mit der obigen Datei können Sie Ihren eigenen Server testen, um sicherzustellen, dass die Fähigkeiten wie vorgesehen erstellt werden.

Alle wichtigen SDKs enthalten ähnliche Testabschnitte, sodass Sie diese an Ihre bevorzugte Laufzeitumgebung anpassen können.

## Beispiele

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Zusätzliche Ressourcen

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Was kommt als Nächstes

- Nächster Schritt: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.