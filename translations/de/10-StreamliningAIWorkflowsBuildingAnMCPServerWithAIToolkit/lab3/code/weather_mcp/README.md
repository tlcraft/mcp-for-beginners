<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:22:08+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "de"
}
-->
# Weather MCP Server

Dies ist ein Beispiel für einen MCP-Server in Python, der Wettertools mit simulierten Antworten implementiert. Er kann als Grundlage für Ihren eigenen MCP-Server verwendet werden. Folgende Funktionen sind enthalten:

- **Weather Tool**: Ein Tool, das simulierte Wetterinformationen basierend auf dem angegebenen Standort bereitstellt.
- **Verbindung zum Agent Builder**: Eine Funktion, mit der Sie den MCP-Server zum Testen und Debuggen mit dem Agent Builder verbinden können.
- **Debuggen mit dem [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Eine Funktion, mit der Sie den MCP-Server mit dem MCP Inspector debuggen können.

## Erste Schritte mit der Weather MCP Server-Vorlage

> **Voraussetzungen**
>
> Um den MCP-Server auf Ihrem lokalen Entwicklungsrechner auszuführen, benötigen Sie:
>
> - [Python](https://www.python.org/)
> - (*Optional – falls Sie uv bevorzugen*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Umgebung vorbereiten

Es gibt zwei Möglichkeiten, die Umgebung für dieses Projekt einzurichten. Sie können je nach Vorliebe eine davon wählen.

> Hinweis: Starten Sie VSCode oder das Terminal neu, damit nach der Erstellung der virtuellen Umgebung das Python der virtuellen Umgebung verwendet wird.

| Vorgehensweise | Schritte |
| -------------- | -------- |
| Verwendung von `uv` | 1. Erstellen Sie eine virtuelle Umgebung: `uv venv` <br>2. Führen Sie den VSCode-Befehl "***Python: Select Interpreter***" aus und wählen Sie das Python der erstellten virtuellen Umgebung aus<br>3. Installieren Sie die Abhängigkeiten (einschließlich der Entwicklungsabhängigkeiten): `uv pip install -r pyproject.toml --extra dev` |
| Verwendung von `pip` | 1. Erstellen Sie eine virtuelle Umgebung: `python -m venv .venv` <br>2. Führen Sie den VSCode-Befehl "***Python: Select Interpreter***" aus und wählen Sie das Python der erstellten virtuellen Umgebung aus<br>3. Installieren Sie die Abhängigkeiten (einschließlich der Entwicklungsabhängigkeiten): `pip install -e .[dev]` |

Nach dem Einrichten der Umgebung können Sie den Server auf Ihrem lokalen Entwicklungsrechner über den Agent Builder als MCP-Client starten:
1. Öffnen Sie das Debug-Panel in VS Code. Wählen Sie `Debug in Agent Builder` aus oder drücken Sie `F5`, um das Debugging des MCP-Servers zu starten.
2. Verwenden Sie den AI Toolkit Agent Builder, um den Server mit [diesem Prompt](../../../../../../../../../../../open_prompt_builder) zu testen. Der Server wird automatisch mit dem Agent Builder verbunden.
3. Klicken Sie auf `Run`, um den Server mit dem Prompt zu testen.

**Herzlichen Glückwunsch**! Sie haben den Weather MCP Server erfolgreich auf Ihrem lokalen Entwicklungsrechner über den Agent Builder als MCP-Client ausgeführt.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Inhalt der Vorlage

| Ordner / Datei | Inhalt                                     |
| -------------- | ----------------------------------------- |
| `.vscode`    | VSCode-Dateien zum Debuggen                |
| `.aitk`   | Konfigurationen für AI Toolkit             |
| `src`   | Quellcode für den Weather MCP Server       |

## So debuggen Sie den Weather MCP Server

> Hinweise:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) ist ein visuelles Entwickler-Tool zum Testen und Debuggen von MCP-Servern.
> - Alle Debug-Modi unterstützen Breakpoints, sodass Sie Haltepunkte im Code der Tool-Implementierung setzen können.

| Debug-Modus | Beschreibung | Schritte zum Debuggen |
| ----------- | ------------ | --------------------- |
| Agent Builder | Debuggen des MCP-Servers im Agent Builder über AI Toolkit. | 1. Öffnen Sie das Debug-Panel in VS Code. Wählen Sie `Debug in Agent Builder` aus und drücken Sie `F5`, um das Debugging des MCP-Servers zu starten.<br>2. Verwenden Sie den AI Toolkit Agent Builder, um den Server mit [diesem Prompt](../../../../../../../../../../../open_prompt_builder) zu testen. Der Server wird automatisch mit dem Agent Builder verbunden.<br>3. Klicken Sie auf `Run`, um den Server mit dem Prompt zu testen. |
| MCP Inspector | Debuggen des MCP-Servers mit dem MCP Inspector. | 1. Installieren Sie [Node.js](https://nodejs.org/)<br>2. Richten Sie den Inspector ein: `cd inspector` && `npm install` <br>3. Öffnen Sie das Debug-Panel in VS Code. Wählen Sie `Debug SSE in Inspector (Edge)` oder `Debug SSE in Inspector (Chrome)` aus. Drücken Sie F5, um das Debugging zu starten.<br>4. Wenn der MCP Inspector im Browser startet, klicken Sie auf die `Connect`-Schaltfläche, um diesen MCP-Server zu verbinden.<br>5. Danach können Sie `List Tools`, ein Tool auswählen, Parameter eingeben und `Run Tool`, um Ihren Server-Code zu debuggen.<br> |

## Standardports und Anpassungen

| Debug-Modus | Ports | Definitionen | Anpassungen | Hinweis |
| ----------- | ----- | ------------ | ----------- | ------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Bearbeiten Sie [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json), um die oben genannten Ports zu ändern. | N/A |
| MCP Inspector | 3001 (Server); 5173 und 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Bearbeiten Sie [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json), um die oben genannten Ports zu ändern. | N/A |

## Feedback

Wenn Sie Feedback oder Vorschläge zu dieser Vorlage haben, öffnen Sie bitte ein Issue im [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit/issues).

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.