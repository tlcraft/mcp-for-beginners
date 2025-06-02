<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:00:46+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "de"
}
-->
# Lektion: Aufbau eines Web Search MCP Servers

Dieses Kapitel zeigt, wie man einen praxisnahen KI-Agenten erstellt, der externe APIs integriert, verschiedene Datentypen verarbeitet, Fehler handhabt und mehrere Werkzeuge orchestriert – alles in einem produktionsreifen Format. Du wirst sehen:

- **Integration externer APIs mit Authentifizierung**
- **Umgang mit unterschiedlichen Datentypen von mehreren Endpunkten**
- **Robuste Fehlerbehandlung und Protokollierungsstrategien**
- **Multi-Tool-Orchestrierung in einem einzigen Server**

Am Ende hast du praktische Erfahrung mit Mustern und Best Practices, die für fortgeschrittene KI- und LLM-basierte Anwendungen unerlässlich sind.

## Einführung

In dieser Lektion lernst du, wie man einen fortgeschrittenen MCP-Server und -Client baut, der LLM-Fähigkeiten mit Echtzeit-Webdaten über SerpAPI erweitert. Dies ist eine wichtige Fähigkeit zur Entwicklung dynamischer KI-Agenten, die aktuelle Informationen aus dem Web abrufen können.

## Lernziele

Am Ende dieser Lektion wirst du in der Lage sein:

- Externe APIs (wie SerpAPI) sicher in einen MCP-Server zu integrieren
- Mehrere Werkzeuge für Web-, Nachrichten-, Produktsuche und Q&A zu implementieren
- Strukturierte Daten für die Nutzung durch LLMs zu parsen und zu formatieren
- Fehler zu behandeln und API-Rate-Limits effektiv zu managen
- Sowohl automatisierte als auch interaktive MCP-Clients zu bauen und zu testen

## Web Search MCP Server

Dieser Abschnitt stellt die Architektur und Funktionen des Web Search MCP Servers vor. Du siehst, wie FastMCP und SerpAPI zusammen genutzt werden, um LLM-Fähigkeiten mit Echtzeit-Webdaten zu erweitern.

### Überblick

Diese Implementierung umfasst vier Werkzeuge, die die Fähigkeit von MCP zeigen, vielfältige, externe API-gesteuerte Aufgaben sicher und effizient zu bewältigen:

- **general_search**: Für allgemeine Web-Ergebnisse
- **news_search**: Für aktuelle Schlagzeilen
- **product_search**: Für E-Commerce-Daten
- **qna**: Für Frage-und-Antwort-Snippets

### Funktionen
- **Code-Beispiele**: Sprachspezifische Codeblöcke für Python (leicht auf andere Sprachen erweiterbar) mit einklappbaren Abschnitten für bessere Übersicht

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

Bevor du den Client startest, ist es hilfreich zu verstehen, was der Server macht. Die [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Hier ein kurzes Beispiel, wie der Server ein Tool definiert und registriert:

<details>  
<summary>Python Server</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **Integration externer APIs**: Zeigt sicheren Umgang mit API-Schlüsseln und externen Anfragen
- **Parsing strukturierter Daten**: Demonstriert, wie API-Antworten in LLM-freundliche Formate umgewandelt werden
- **Fehlerbehandlung**: Robuste Fehlerbehandlung mit angemessener Protokollierung
- **Interaktiver Client**: Beinhaltet sowohl automatisierte Tests als auch einen interaktiven Modus zum Testen
- **Kontextmanagement**: Nutzt MCP Context für Logging und Nachverfolgung von Anfragen

## Voraussetzungen

Bevor du beginnst, stelle sicher, dass deine Umgebung richtig eingerichtet ist, indem du folgende Schritte befolgst. So werden alle Abhängigkeiten installiert und deine API-Schlüssel korrekt konfiguriert für eine reibungslose Entwicklung und Tests.

- Python 3.8 oder höher
- SerpAPI API-Schlüssel (Registrierung unter [SerpAPI](https://serpapi.com/) – kostenlose Stufe verfügbar)

## Installation

Um loszulegen, richte deine Umgebung wie folgt ein:

1. Installiere die Abhängigkeiten mit uv (empfohlen) oder pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Erstelle eine `.env`-Datei im Projektverzeichnis mit deinem SerpAPI-Schlüssel:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Verwendung

Der Web Search MCP Server ist die zentrale Komponente, die Werkzeuge für Web-, Nachrichten-, Produktsuche und Q&A über die Integration mit SerpAPI bereitstellt. Er verarbeitet eingehende Anfragen, verwaltet API-Aufrufe, parst Antworten und liefert strukturierte Ergebnisse an den Client zurück.

Die vollständige Implementierung findest du in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Server starten

Um den MCP-Server zu starten, verwende folgenden Befehl:

```bash
python server.py
```

Der Server läuft dann als stdio-basierter MCP-Server, mit dem der Client direkt verbinden kann.

### Client-Modi

Der Client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Client ausführen

Um die automatisierten Tests auszuführen (dies startet den Server automatisch):

```bash
python client.py
```

Oder im interaktiven Modus starten:

```bash
python client.py --interactive
```

### Testen mit verschiedenen Methoden

Es gibt mehrere Möglichkeiten, die vom Server bereitgestellten Werkzeuge zu testen und mit ihnen zu interagieren, je nach Bedarf und Workflow.

#### Eigene Testskripte mit dem MCP Python SDK schreiben

Du kannst auch eigene Testskripte mit dem MCP Python SDK erstellen:

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

In diesem Zusammenhang bedeutet „Testskript“ ein eigenes Python-Programm, das du schreibst, um als Client für den MCP-Server zu fungieren. Statt ein formaler Unit-Test zu sein, erlaubt dir dieses Skript, programmatisch eine Verbindung zum Server herzustellen, beliebige Werkzeuge mit selbst gewählten Parametern aufzurufen und die Ergebnisse zu prüfen. Dieser Ansatz eignet sich besonders für:
- Prototyping und Experimentieren mit Werkzeugaufrufen
- Validierung der Serverantworten auf unterschiedliche Eingaben
- Automatisierung wiederholter Werkzeugaufrufe
- Aufbau eigener Workflows oder Integrationen auf Basis des MCP-Servers

Mit Testskripten kannst du neue Anfragen schnell ausprobieren, das Verhalten von Werkzeugen debuggen oder als Ausgangspunkt für weitergehende Automatisierungen nutzen. Unten findest du ein Beispiel, wie du das MCP Python SDK für ein solches Skript verwendest:

## Werkzeugbeschreibungen

Du kannst die folgenden vom Server bereitgestellten Werkzeuge nutzen, um verschiedene Arten von Suchen und Anfragen durchzuführen. Jedes Werkzeug wird mit seinen Parametern und Beispielanwendungen beschrieben.

Dieser Abschnitt gibt Details zu jedem verfügbaren Werkzeug und dessen Parametern.

### general_search

Führt eine allgemeine Websuche durch und liefert formatierte Ergebnisse zurück.

**So rufst du dieses Werkzeug auf:**

Du kannst `general_search` aus deinem eigenen Skript mit dem MCP Python SDK aufrufen oder interaktiv mit dem Inspector oder im interaktiven Client-Modus. Hier ein Codebeispiel mit dem SDK:

<details>
<summary>Python Beispiel</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

Alternativ wähle im interaktiven Modus `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Die Suchanfrage

**Beispielanfrage:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Sucht nach aktuellen Nachrichtenartikeln zu einer Anfrage.

**So rufst du dieses Werkzeug auf:**

Du kannst `news_search` aus deinem eigenen Skript mit dem MCP Python SDK aufrufen oder interaktiv mit dem Inspector oder im interaktiven Client-Modus. Hier ein Codebeispiel mit dem SDK:

<details>
<summary>Python Beispiel</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

Alternativ wähle im interaktiven Modus `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Die Suchanfrage

**Beispielanfrage:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Sucht nach Produkten, die zu einer Anfrage passen.

**So rufst du dieses Werkzeug auf:**

Du kannst `product_search` aus deinem eigenen Skript mit dem MCP Python SDK aufrufen oder interaktiv mit dem Inspector oder im interaktiven Client-Modus. Hier ein Codebeispiel mit dem SDK:

<details>
<summary>Python Beispiel</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

Alternativ wähle im interaktiven Modus `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Die Produktsuche

**Beispielanfrage:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Gibt direkte Antworten auf Fragen aus Suchmaschinen zurück.

**So rufst du dieses Werkzeug auf:**

Du kannst `qna` aus deinem eigenen Skript mit dem MCP Python SDK aufrufen oder interaktiv mit dem Inspector oder im interaktiven Client-Modus. Hier ein Codebeispiel mit dem SDK:

<details>
<summary>Python Beispiel</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

Alternativ wähle im interaktiven Modus `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Die Frage, zu der eine Antwort gefunden werden soll

**Beispielanfrage:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Code-Details

Dieser Abschnitt enthält Codeausschnitte und Verweise zu Server- und Client-Implementierungen.

<details>
<summary>Python</summary>

Siehe [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) für vollständige Implementierungsdetails.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Fortgeschrittene Konzepte in dieser Lektion

Bevor du mit dem Aufbau beginnst, hier einige wichtige fortgeschrittene Konzepte, die im gesamten Kapitel vorkommen. Ihr Verständnis hilft dir, besser folgen zu können, auch wenn du neu in diesen Themen bist:

- **Multi-Tool-Orchestrierung**: Bedeutet, dass mehrere verschiedene Werkzeuge (wie Websuche, Nachrichtensuche, Produktsuche und Q&A) innerhalb eines einzigen MCP-Servers laufen. So kann dein Server verschiedene Aufgaben gleichzeitig bearbeiten, nicht nur eine.
- **Umgang mit API-Rate-Limits**: Viele externe APIs (wie SerpAPI) begrenzen, wie viele Anfragen du in einem bestimmten Zeitraum stellen kannst. Gute Programme prüfen diese Limits und gehen damit geschickt um, damit deine Anwendung nicht abstürzt, wenn ein Limit erreicht ist.
- **Parsing strukturierter Daten**: API-Antworten sind oft komplex und verschachtelt. Dieses Konzept beschreibt, wie man diese Antworten in saubere, einfach zu nutzende Formate umwandelt, die für LLMs oder andere Programme gut geeignet sind.
- **Fehlerbehandlung und Wiederherstellung**: Manchmal läuft etwas schief – vielleicht fällt das Netzwerk aus oder die API liefert unerwartete Daten. Fehlerbehandlung bedeutet, dass dein Code diese Probleme abfangen kann und trotzdem hilfreiche Rückmeldungen gibt, statt abzustürzen.
- **Parametervalidierung**: Dabei wird überprüft, ob alle Eingaben zu deinen Werkzeugen korrekt und sicher sind. Das umfasst das Setzen von Standardwerten und die Sicherstellung der richtigen Datentypen, was Fehler und Missverständnisse verhindert.

Dieser Abschnitt hilft dir, häufige Probleme zu erkennen und zu lösen, die beim Arbeiten mit dem Web Search MCP Server auftreten können. Wenn du auf Fehler oder unerwartetes Verhalten stößt, findest du hier oft schnelle Lösungen, bevor du weitere Hilfe suchst.

## Fehlerbehebung

Beim Arbeiten mit dem Web Search MCP Server kann es gelegentlich zu Problemen kommen – das ist normal bei der Entwicklung mit externen APIs und neuen Werkzeugen. Dieser Abschnitt bietet praktische Lösungen für die häufigsten Probleme, damit du schnell wieder weiterarbeiten kannst. Wenn ein Fehler auftritt, starte hier: Die folgenden Tipps behandeln die häufigsten Fehler, die Nutzer erleben, und lösen viele Probleme ohne zusätzlichen Aufwand.

### Häufige Probleme

Hier sind einige der häufigsten Probleme, auf die Nutzer stoßen, mit klaren Erklärungen und Schritten zur Behebung:

1. **Fehlender SERPAPI_KEY in der .env-Datei**
   - Wenn du die Fehlermeldung `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` erhältst, erstelle oder überprüfe deine `.env`-Datei. Wenn dein Schlüssel korrekt ist, aber der Fehler weiterhin auftritt, prüfe, ob dein kostenloses Kontingent bereits aufgebraucht ist.

### Debug-Modus

Standardmäßig protokolliert die App nur wichtige Informationen. Wenn du mehr Details über die Abläufe sehen möchtest (z. B. zur Diagnose schwieriger Probleme), kannst du den DEBUG-Modus aktivieren. Dieser zeigt deutlich mehr zu jedem Schritt, den die App durchläuft.

**Beispiel: Normale Ausgabe**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Beispiel: DEBUG-Ausgabe**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Beachte, dass der DEBUG-Modus zusätzliche Zeilen zu HTTP-Anfragen, Antworten und anderen internen Details enthält. Das ist sehr hilfreich zur Fehlersuche.

Um den DEBUG-Modus zu aktivieren, setze das Logging-Level auf DEBUG am Anfang deiner `client.py` or `server.py`:

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## Was kommt als Nächstes

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Verwendung dieser Übersetzung entstehen.