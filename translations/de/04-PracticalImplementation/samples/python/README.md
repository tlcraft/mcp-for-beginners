<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:27:16+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "de"
}
-->
# Model Context Protocol (MCP) Python-Implementierung

Dieses Repository enthält eine Python-Implementierung des Model Context Protocol (MCP) und zeigt, wie man sowohl eine Server- als auch eine Client-Anwendung erstellt, die über den MCP-Standard kommunizieren.

## Überblick

Die MCP-Implementierung besteht aus zwei Hauptkomponenten:

1. **MCP Server (`server.py`)** – Ein Server, der bereitstellt:
   - **Tools**: Funktionen, die remote aufgerufen werden können
   - **Resources**: Daten, die abgerufen werden können
   - **Prompts**: Vorlagen zur Erstellung von Eingabeaufforderungen für Sprachmodelle

2. **MCP Client (`client.py`)** – Eine Client-Anwendung, die sich mit dem Server verbindet und dessen Funktionen nutzt

## Funktionen

Diese Implementierung zeigt mehrere wichtige MCP-Funktionen:

### Tools
- `completion` – Erzeugt Textvervollständigungen von KI-Modellen (simuliert)
- `add` – Ein einfacher Taschenrechner, der zwei Zahlen addiert

### Resources
- `models://` – Liefert Informationen über verfügbare KI-Modelle
- `greeting://{name}` – Gibt eine personalisierte Begrüßung für einen angegebenen Namen zurück

### Prompts
- `review_code` – Erstellt eine Eingabeaufforderung zur Code-Überprüfung

## Installation

Um diese MCP-Implementierung zu verwenden, installieren Sie die benötigten Pakete:

```powershell
pip install mcp-server mcp-client
```

## Server und Client starten

### Server starten

Starten Sie den Server in einem Terminalfenster:

```powershell
python server.py
```

Der Server kann auch im Entwicklungsmodus mit dem MCP CLI ausgeführt werden:

```powershell
mcp dev server.py
```

Oder in Claude Desktop installiert werden (falls verfügbar):

```powershell
mcp install server.py
```

### Client ausführen

Starten Sie den Client in einem anderen Terminalfenster:

```powershell
python client.py
```

Dies verbindet den Client mit dem Server und demonstriert alle verfügbaren Funktionen.

### Client-Nutzung

Der Client (`client.py`) zeigt alle MCP-Fähigkeiten:

```powershell
python client.py
```

Dies stellt die Verbindung zum Server her und nutzt alle Funktionen, einschließlich Tools, Resources und Prompts. Die Ausgabe zeigt:

1. Ergebnis des Taschenrechners (5 + 7 = 12)
2. Antwort des Completion-Tools auf „What is the meaning of life?“
3. Liste der verfügbaren KI-Modelle
4. Personalisierte Begrüßung für „MCP Explorer“
5. Vorlage für die Code-Review-Eingabeaufforderung

## Implementierungsdetails

Der Server wird mit der `FastMCP` API implementiert, die hochrangige Abstraktionen zur Definition von MCP-Diensten bietet. Hier ein vereinfachtes Beispiel, wie Tools definiert werden:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

Der Client verwendet die MCP-Client-Bibliothek, um sich zu verbinden und den Server aufzurufen:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Mehr erfahren

Weitere Informationen zum MCP finden Sie unter: https://modelcontextprotocol.io/

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.