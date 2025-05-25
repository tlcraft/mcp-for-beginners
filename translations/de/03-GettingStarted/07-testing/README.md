<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-16T15:22:49+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "de"
}
-->
## Testen und Debuggen

Bevor Sie mit dem Testen Ihres MCP-Servers beginnen, ist es wichtig, die verfügbaren Werkzeuge und bewährten Methoden zum Debuggen zu verstehen. Effektives Testen stellt sicher, dass Ihr Server wie erwartet funktioniert und hilft Ihnen, Probleme schnell zu erkennen und zu beheben. Der folgende Abschnitt beschreibt empfohlene Vorgehensweisen zur Validierung Ihrer MCP-Implementierung.

## Überblick

Diese Lektion behandelt, wie Sie den richtigen Testansatz und das effektivste Testwerkzeug auswählen.

## Lernziele

Am Ende dieser Lektion werden Sie in der Lage sein:

- Verschiedene Ansätze zum Testen zu beschreiben.
- Unterschiedliche Werkzeuge zu nutzen, um Ihren Code effektiv zu testen.

## Testen von MCP-Servern

MCP stellt Werkzeuge zur Verfügung, die Ihnen beim Testen und Debuggen Ihrer Server helfen:

- **MCP Inspector**: Ein Kommandozeilenwerkzeug, das sowohl als CLI-Tool als auch als visuelles Tool verwendet werden kann.
- **Manuelles Testen**: Sie können ein Tool wie curl verwenden, um Webanfragen auszuführen, aber jedes Tool, das HTTP unterstützt, ist geeignet.
- **Unit-Testing**: Es ist möglich, Ihr bevorzugtes Testframework zu verwenden, um die Funktionen von Server und Client zu testen.

### Verwendung des MCP Inspectors

Wir haben die Nutzung dieses Werkzeugs in vorherigen Lektionen beschrieben, aber hier eine kurze Übersicht. Es handelt sich um ein in Node.js entwickeltes Tool, das Sie über die ausführbare Datei `npx` starten können. Diese lädt das Tool temporär herunter, installiert es und räumt nach Ausführung Ihrer Anfrage wieder auf.

Der [MCP Inspector](https://github.com/modelcontextprotocol/inspector) hilft Ihnen dabei:

- **Serverfähigkeiten entdecken**: Automatische Erkennung verfügbarer Ressourcen, Werkzeuge und Eingabeaufforderungen
- **Ausführung von Werkzeugen testen**: Verschiedene Parameter ausprobieren und Antworten in Echtzeit ansehen
- **Server-Metadaten anzeigen**: Serverinformationen, Schemata und Konfigurationen prüfen

Ein typischer Ablauf mit dem Tool sieht folgendermaßen aus:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Der obige Befehl startet einen MCP-Server mit der visuellen Oberfläche und öffnet eine lokale Weboberfläche im Browser. Sie sehen ein Dashboard, das Ihre registrierten MCP-Server, deren verfügbare Werkzeuge, Ressourcen und Eingabeaufforderungen anzeigt. Die Oberfläche ermöglicht es Ihnen, Werkzeugausführungen interaktiv zu testen, Server-Metadaten zu inspizieren und Echtzeitantworten zu betrachten, was die Validierung und das Debuggen Ihrer MCP-Server-Implementierungen erleichtert.

So könnte es aussehen: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.de.png)

Sie können das Tool auch im CLI-Modus ausführen, indem Sie das Attribut `--cli` hinzufügen. Hier ein Beispiel für den "CLI"-Modus, der alle Werkzeuge auf dem Server auflistet:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuelles Testen

Neben der Verwendung des Inspector-Tools zur Prüfung der Serverfähigkeiten ist ein ähnlicher Ansatz, einen Client zu verwenden, der HTTP unterstützt, beispielsweise curl.

Mit curl können Sie MCP-Server direkt über HTTP-Anfragen testen:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Wie Sie an dem obigen Beispiel mit curl sehen, verwenden Sie eine POST-Anfrage, um ein Werkzeug mit einer Nutzlast aufzurufen, die den Namen des Werkzeugs und dessen Parameter enthält. Wählen Sie den Ansatz, der für Sie am besten passt. CLI-Tools sind in der Regel schneller zu bedienen und lassen sich gut skripten, was in CI/CD-Umgebungen von Vorteil sein kann.

### Unit-Testing

Erstellen Sie Unit-Tests für Ihre Werkzeuge und Ressourcen, um sicherzustellen, dass sie wie erwartet funktionieren. Hier ein Beispielcode für Tests:

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

Der obige Code macht Folgendes:

- Nutzt das pytest-Framework, mit dem Sie Tests als Funktionen erstellen und assert-Anweisungen verwenden können.
- Erstellt einen MCP-Server mit zwei verschiedenen Werkzeugen.
- Verwendet die `assert`-Anweisung, um sicherzustellen, dass bestimmte Bedingungen erfüllt sind.

Sehen Sie sich die [vollständige Datei hier](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py) an.

Anhand dieser Datei können Sie Ihren eigenen Server testen, um sicherzustellen, dass die Fähigkeiten korrekt erstellt werden.

Alle großen SDKs enthalten ähnliche Testabschnitte, sodass Sie diese an Ihre bevorzugte Laufzeitumgebung anpassen können.

## Beispiele

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Zusätzliche Ressourcen

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Was kommt als Nächstes

- Weiter: [Deployment](/03-GettingStarted/08-deployment/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ausgangssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.