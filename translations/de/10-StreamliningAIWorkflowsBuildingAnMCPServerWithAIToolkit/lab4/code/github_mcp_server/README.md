<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:01:08+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "de"
}
-->
# Weather MCP Server

Dies ist ein Beispiel für einen MCP Server in Python, der Wetter-Tools mit simulierten Antworten implementiert. Er kann als Vorlage für deinen eigenen MCP Server verwendet werden. Folgende Funktionen sind enthalten:

- **Weather Tool**: Ein Tool, das simulierte Wetterinformationen basierend auf dem angegebenen Ort bereitstellt.
- **Git Clone Tool**: Ein Tool, das ein Git-Repository in einen angegebenen Ordner klont.
- **VS Code Open Tool**: Ein Tool, das einen Ordner in VS Code oder VS Code Insiders öffnet.
- **Connect to Agent Builder**: Eine Funktion, mit der du den MCP Server mit dem Agent Builder zum Testen und Debuggen verbinden kannst.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Eine Funktion, die das Debuggen des MCP Servers mit dem MCP Inspector ermöglicht.

## Einstieg mit der Weather MCP Server Vorlage

> **Voraussetzungen**
>
> Um den MCP Server auf deinem lokalen Entwicklungsrechner auszuführen, benötigst du:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (Benötigt für git_clone_repo Tool)
> - [VS Code](https://code.visualstudio.com/) oder [VS Code Insiders](https://code.visualstudio.com/insiders/) (Benötigt für open_in_vscode Tool)
> - (*Optional - falls du uv bevorzugst*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Umgebung vorbereiten

Es gibt zwei Möglichkeiten, die Umgebung für dieses Projekt einzurichten. Du kannst je nach Vorliebe eine davon wählen.

> Hinweis: Lade VSCode oder das Terminal neu, um sicherzustellen, dass nach der Erstellung der virtuellen Umgebung der Python-Interpreter der virtuellen Umgebung verwendet wird.

| Vorgehensweise | Schritte |
| -------------- | -------- |
| Verwendung von `uv` | 1. Erstelle die virtuelle Umgebung: `uv venv` <br>2. Führe den VSCode-Befehl "***Python: Select Interpreter***" aus und wähle den Python-Interpreter der erstellten virtuellen Umgebung aus <br>3. Installiere die Abhängigkeiten (einschließlich der Entwicklungsabhängigkeiten): `uv pip install -r pyproject.toml --extra dev` |
| Verwendung von `pip` | 1. Erstelle die virtuelle Umgebung: `python -m venv .venv` <br>2. Führe den VSCode-Befehl "***Python: Select Interpreter***" aus und wähle den Python-Interpreter der erstellten virtuellen Umgebung aus<br>3. Installiere die Abhängigkeiten (einschließlich der Entwicklungsabhängigkeiten): `pip install -e .[dev]` |

Nachdem die Umgebung eingerichtet ist, kannst du den Server auf deinem lokalen Entwicklungsrechner über den Agent Builder als MCP Client starten:
1. Öffne das Debug-Panel in VS Code. Wähle `Debug in Agent Builder` aus oder drücke `F5`, um das Debugging des MCP Servers zu starten.
2. Nutze den AI Toolkit Agent Builder, um den Server mit [diesem Prompt](../../../../../../../../../../../open_prompt_builder) zu testen. Der Server wird automatisch mit dem Agent Builder verbunden.
3. Klicke `Run`, um den Server mit dem Prompt zu testen.

**Herzlichen Glückwunsch**! Du hast den Weather MCP Server erfolgreich auf deinem lokalen Entwicklungsrechner über den Agent Builder als MCP Client ausgeführt.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Inhalt der Vorlage

| Ordner / Datei | Inhalt                                     |
| -------------- | ------------------------------------------ |
| `.vscode`    | VSCode-Dateien für das Debugging          |
| `.aitk`      | Konfigurationen für AI Toolkit             |
| `src`        | Quellcode für den Weather MCP Server       |

## So debuggt man den Weather MCP Server

> Hinweise:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) ist ein visuelles Entwickler-Tool zum Testen und Debuggen von MCP Servern.
> - Alle Debugging-Modi unterstützen Breakpoints, sodass du Haltepunkte im Code der Tool-Implementierung setzen kannst.

## Verfügbare Tools

### Weather Tool
Das `get_weather` Tool liefert simulierte Wetterinformationen für einen angegebenen Ort.

| Parameter | Typ | Beschreibung |
| --------- | --- | ------------ |
| `location` | string | Ort, für den die Wetterdaten abgefragt werden (z.B. Stadtname, Bundesland oder Koordinaten) |

### Git Clone Tool
Das `git_clone_repo` Tool klont ein Git-Repository in einen angegebenen Ordner.

| Parameter | Typ | Beschreibung |
| --------- | --- | ------------ |
| `repo_url` | string | URL des Git-Repositories, das geklont werden soll |
| `target_folder` | string | Pfad zum Ordner, in den das Repository geklont werden soll |

Das Tool gibt ein JSON-Objekt zurück mit:
- `success`: Boolean, der angibt, ob der Vorgang erfolgreich war
- `target_folder` oder `error`: Pfad des geklonten Repositories oder eine Fehlermeldung

### VS Code Open Tool
Das `open_in_vscode` Tool öffnet einen Ordner in der VS Code oder VS Code Insiders Anwendung.

| Parameter | Typ | Beschreibung |
| --------- | --- | ------------ |
| `folder_path` | string | Pfad zum zu öffnenden Ordner |
| `use_insiders` | boolean (optional) | Ob VS Code Insiders anstelle der regulären VS Code Version verwendet werden soll |

Das Tool gibt ein JSON-Objekt zurück mit:
- `success`: Boolean, der angibt, ob der Vorgang erfolgreich war
- `message` oder `error`: Eine Bestätigungsmeldung oder eine Fehlermeldung

## Debug-Modus | Beschreibung | Schritte zum Debuggen |
| ---------- | ----------- | --------------------- |
| Agent Builder | Debugge den MCP Server im Agent Builder über AI Toolkit. | 1. Öffne das Debug-Panel in VS Code. Wähle `Debug in Agent Builder` und drücke `F5`, um das Debugging des MCP Servers zu starten.<br>2. Nutze den AI Toolkit Agent Builder, um den Server mit [diesem Prompt](../../../../../../../../../../../open_prompt_builder) zu testen. Der Server wird automatisch mit dem Agent Builder verbunden.<br>3. Klicke `Run`, um den Server mit dem Prompt zu testen. |
| MCP Inspector | Debugge den MCP Server mit dem MCP Inspector. | 1. Installiere [Node.js](https://nodejs.org/)<br> 2. Richte den Inspector ein: `cd inspector` && `npm install` <br> 3. Öffne das Debug-Panel in VS Code. Wähle `Debug SSE in Inspector (Edge)` oder `Debug SSE in Inspector (Chrome)`. Drücke F5, um das Debugging zu starten.<br> 4. Wenn der MCP Inspector im Browser startet, klicke auf die `Connect` Schaltfläche, um diesen MCP Server zu verbinden.<br> 5. Danach kannst du `List Tools`, ein Tool auswählen, Parameter eingeben und `Run Tool`, um deinen Servercode zu debuggen.<br> |

## Standardports und Anpassungen

| Debug-Modus | Ports | Definitionen | Anpassungen | Hinweis |
| ----------- | ----- | ------------ | ----------- | ------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Bearbeite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json), um die Ports zu ändern. | N/A |
| MCP Inspector | 3001 (Server); 5173 und 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Bearbeite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json), um die Ports zu ändern. | N/A |

## Feedback

Falls du Feedback oder Vorschläge zu dieser Vorlage hast, öffne bitte ein Issue im [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Originalsprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.