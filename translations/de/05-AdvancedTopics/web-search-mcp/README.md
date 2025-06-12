<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T14:38:06+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "de"
}
-->
# Lektion: Aufbau eines Web Search MCP Servers

Dieses Kapitel zeigt, wie man einen realen KI-Agenten entwickelt, der externe APIs integriert, verschiedene Datentypen verarbeitet, Fehler handhabt und mehrere Werkzeuge orchestriert – alles in einem produktionsreifen Format. Du wirst sehen:

- **Integration mit externen APIs, die Authentifizierung erfordern**
- **Umgang mit unterschiedlichen Datentypen von mehreren Endpunkten**
- **Robuste Fehlerbehandlung und Protokollierungsstrategien**
- **Multi-Tool-Orchestrierung in einem einzigen Server**

Am Ende hast du praktische Erfahrungen mit Mustern und Best Practices, die für fortgeschrittene KI- und LLM-basierte Anwendungen unerlässlich sind.

## Einführung

In dieser Lektion lernst du, wie man einen fortschrittlichen MCP-Server und -Client baut, der LLM-Fähigkeiten mit Echtzeit-Webdaten über SerpAPI erweitert. Dies ist eine wichtige Fähigkeit zur Entwicklung dynamischer KI-Agenten, die auf aktuelle Informationen aus dem Web zugreifen können.

## Lernziele

Am Ende dieser Lektion wirst du in der Lage sein:

- Externe APIs (wie SerpAPI) sicher in einen MCP-Server zu integrieren
- Mehrere Werkzeuge für Web-, Nachrichten-, Produktsuche und Q&A zu implementieren
- Strukturierte Daten für die Nutzung durch LLMs zu parsen und zu formatieren
- Fehler zu handhaben und API-Rate-Limits effektiv zu verwalten
- Automatisierte und interaktive MCP-Clients zu bauen und zu testen

## Web Search MCP Server

Dieser Abschnitt stellt die Architektur und Funktionen des Web Search MCP Servers vor. Du wirst sehen, wie FastMCP und SerpAPI zusammen genutzt werden, um LLM-Fähigkeiten mit Echtzeit-Webdaten zu erweitern.

### Überblick

Diese Implementierung beinhaltet vier Werkzeuge, die die Fähigkeit von MCP zeigen, verschiedene, externe API-getriebene Aufgaben sicher und effizient zu bewältigen:

- **general_search**: Für allgemeine Web-Ergebnisse
- **news_search**: Für aktuelle Nachrichtenüberschriften
- **product_search**: Für E-Commerce-Daten
- **qna**: Für Frage-Antwort-Schnipsel

### Funktionen
- **Codebeispiele**: Enthält sprachspezifische Codeblöcke für Python (und lässt sich leicht auf andere Sprachen erweitern) mit einklappbaren Abschnitten für bessere Übersicht

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

Hier ein kurzes Beispiel, wie der Server ein Werkzeug definiert und registriert:

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

- **Externe API-Integration**: Zeigt sicheren Umgang mit API-Schlüsseln und externen Anfragen
- **Strukturierte Datenverarbeitung**: Veranschaulicht, wie API-Antworten in LLM-freundliche Formate umgewandelt werden
- **Fehlerbehandlung**: Robuste Fehlerbehandlung mit angemessener Protokollierung
- **Interaktiver Client**: Enthält sowohl automatisierte Tests als auch einen interaktiven Modus zum Testen
- **Kontextmanagement**: Nutzt MCP Context für Protokollierung und Nachverfolgung von Anfragen

## Voraussetzungen

Bevor du beginnst, stelle sicher, dass deine Umgebung richtig eingerichtet ist, indem du die folgenden Schritte befolgst. So wird sichergestellt, dass alle Abhängigkeiten installiert sind und deine API-Schlüssel korrekt konfiguriert sind, um eine reibungslose Entwicklung und Tests zu ermöglichen.

- Python 3.8 oder höher
- SerpAPI API-Schlüssel (Registriere dich bei [SerpAPI](https://serpapi.com/) – kostenlose Stufe verfügbar)

## Installation

Um loszulegen, folge diesen Schritten, um deine Umgebung einzurichten:

1. Installiere die Abhängigkeiten mit uv (empfohlen) oder pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Erstelle eine `.env`-Datei im Projektstammverzeichnis mit deinem SerpAPI-Schlüssel:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Verwendung

Der Web Search MCP Server ist die zentrale Komponente, die Werkzeuge für Web-, Nachrichten-, Produktsuche und Q&A bereitstellt, indem er SerpAPI integriert. Er verarbeitet eingehende Anfragen, verwaltet API-Aufrufe, parst Antworten und liefert strukturierte Ergebnisse an den Client zurück.

Die vollständige Implementierung findest du in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Server starten

Um den MCP-Server zu starten, verwende folgenden Befehl:

```bash
python server.py
```

Der Server läuft als stdio-basierter MCP-Server, mit dem der Client direkt verbinden kann.

### Client-Modi

Der Client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Client starten

Um die automatisierten Tests auszuführen (dies startet den Server automatisch):

```bash
python client.py
```

Oder im interaktiven Modus starten:

```bash
python client.py --interactive
```

### Testen mit verschiedenen Methoden

Es gibt verschiedene Möglichkeiten, die vom Server bereitgestellten Werkzeuge zu testen und zu nutzen, je nach deinen Bedürfnissen und Arbeitsabläufen.

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

In diesem Zusammenhang bedeutet „Testskript“ ein eigenes Python-Programm, das du schreibst, um als Client für den MCP-Server zu agieren. Anstatt ein formaler Unit-Test zu sein, erlaubt dir dieses Skript, programmatisch eine Verbindung zum Server herzustellen, beliebige Werkzeuge mit selbst gewählten Parametern aufzurufen und die Ergebnisse zu prüfen. Dieser Ansatz ist nützlich für:
- Prototyping und Experimentieren mit Werkzeugaufrufen
- Validierung, wie der Server auf unterschiedliche Eingaben reagiert
- Automatisierung wiederholter Werkzeugaufrufe
- Aufbau eigener Workflows oder Integrationen auf Basis des MCP-Servers

Du kannst Testskripte verwenden, um neue Abfragen schnell auszuprobieren, das Verhalten von Werkzeugen zu debuggen oder als Ausgangspunkt für komplexere Automatisierungen. Unten findest du ein Beispiel, wie du das MCP Python SDK für ein solches Skript nutzt:

## Werkzeugbeschreibungen

Die folgenden Werkzeuge, die der Server bereitstellt, kannst du verwenden, um verschiedene Arten von Suchen und Abfragen durchzuführen. Jedes Werkzeug wird unten mit seinen Parametern und Beispielanwendungen beschrieben.

Dieser Abschnitt liefert Details zu jedem verfügbaren Werkzeug und dessen Parametern.

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
- `query` (string): Die Produktsuche-Anfrage

**Beispielanfrage:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Erhält direkte Antworten auf Fragen von Suchmaschinen.

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
- `question` (string): Die Frage, auf die eine Antwort gefunden werden soll

**Beispielanfrage:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Code-Details

Dieser Abschnitt liefert Codeausschnitte und Referenzen für die Server- und Client-Implementierungen.

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

Bevor du mit dem Aufbau beginnst, hier einige wichtige fortgeschrittene Konzepte, die im Verlauf dieses Kapitels auftauchen werden. Das Verständnis dieser hilft dir, besser folgen zu können, auch wenn du neu damit bist:

- **Multi-Tool-Orchestrierung**: Das bedeutet, mehrere verschiedene Werkzeuge (wie Websuche, Nachrichtensuche, Produktsuche und Q&A) in einem einzigen MCP-Server laufen zu lassen. So kann dein Server verschiedene Aufgaben gleichzeitig bearbeiten, nicht nur eine.
- **API-Rate-Limit-Handhabung**: Viele externe APIs (wie SerpAPI) begrenzen, wie viele Anfragen du in einer bestimmten Zeit machen kannst. Guter Code prüft diese Limits und behandelt sie elegant, damit deine App nicht abstürzt, wenn du ein Limit erreichst.
- **Strukturierte Datenverarbeitung**: API-Antworten sind oft komplex und verschachtelt. Dieses Konzept dreht sich darum, diese Antworten in saubere, einfach zu nutzende Formate umzuwandeln, die für LLMs oder andere Programme geeignet sind.
- **Fehlerbehebung**: Manchmal läuft etwas schief – vielleicht fällt das Netzwerk aus oder die API liefert nicht die erwarteten Daten. Fehlerbehebung bedeutet, dass dein Code solche Probleme abfangen kann und trotzdem nützliches Feedback gibt, anstatt abzustürzen.
- **Parametervalidierung**: Dabei geht es darum, sicherzustellen, dass alle Eingaben für deine Werkzeuge korrekt und sicher sind. Das umfasst das Setzen von Standardwerten und die Prüfung der Typen, was hilft, Fehler und Verwirrung zu vermeiden.

Dieser Abschnitt hilft dir, häufige Probleme zu erkennen und zu lösen, die beim Arbeiten mit dem Web Search MCP Server auftreten können. Wenn du auf Fehler oder unerwartetes Verhalten stößt, findest du hier Lösungen für die häufigsten Probleme. Schau dir diese Tipps an, bevor du weitere Hilfe suchst – oft lassen sich Probleme so schnell beheben.

## Fehlerbehebung

Beim Arbeiten mit dem Web Search MCP Server kann es gelegentlich zu Problemen kommen – das ist normal bei der Entwicklung mit externen APIs und neuen Werkzeugen. Dieser Abschnitt bietet praktische Lösungen für die häufigsten Probleme, damit du schnell wieder weiterarbeiten kannst. Wenn du auf einen Fehler stößt, beginne hier: Die folgenden Tipps behandeln die Probleme, die die meisten Nutzer haben, und können dein Problem oft ohne zusätzliche Hilfe lösen.

### Häufige Probleme

Nachfolgend einige der häufigsten Probleme, auf die Nutzer stoßen, mit klaren Erklärungen und Schritten zur Behebung:

1. **Fehlender SERPAPI_KEY in der .env-Datei**
   - Wenn du den Fehler `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` erhältst, überprüfe, ob du eine `.env`-Datei mit deinem API-Schlüssel angelegt hast. Wenn dein Schlüssel korrekt ist, der Fehler aber weiterhin erscheint, prüfe, ob dein kostenloses Kontingent aufgebraucht ist.

### Debug-Modus

Standardmäßig protokolliert die App nur wichtige Informationen. Wenn du mehr Details über den Ablauf sehen möchtest (z. B. zur Diagnose schwieriger Probleme), kannst du den DEBUG-Modus aktivieren. Dadurch werden viel mehr Informationen zu jedem Schritt angezeigt.

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

Beachte, dass der DEBUG-Modus zusätzliche Zeilen zu HTTP-Anfragen, Antworten und anderen internen Details enthält. Das kann sehr hilfreich bei der Fehlersuche sein.

Um den DEBUG-Modus zu aktivieren, setze das Protokollierungslevel auf DEBUG am Anfang deiner `client.py` or `server.py`:

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

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache gilt als maßgebliche Quelle. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.