<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:19:41+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "de"
}
-->
# Lektion: Aufbau eines Web Search MCP Servers

Dieses Kapitel zeigt, wie man einen praxisnahen KI-Agenten erstellt, der externe APIs integriert, verschiedene Datentypen verarbeitet, Fehler handhabt und mehrere Tools orchestriert – alles in einem produktionsreifen Format. Du wirst sehen:

- **Integration externer APIs mit Authentifizierung**
- **Verarbeitung unterschiedlicher Datentypen von mehreren Endpunkten**
- **Robuste Fehlerbehandlung und Logging-Strategien**
- **Orchestrierung mehrerer Tools in einem einzigen Server**

Am Ende hast du praktische Erfahrungen mit Mustern und Best Practices, die für fortgeschrittene KI- und LLM-basierte Anwendungen unerlässlich sind.

## Einführung

In dieser Lektion lernst du, wie man einen fortgeschrittenen MCP-Server und -Client baut, der LLM-Fähigkeiten mit Echtzeit-Webdaten über SerpAPI erweitert. Das ist eine wichtige Fähigkeit, um dynamische KI-Agenten zu entwickeln, die auf aktuelle Informationen aus dem Web zugreifen können.

## Lernziele

Am Ende dieser Lektion wirst du in der Lage sein:

- Externe APIs (wie SerpAPI) sicher in einen MCP-Server zu integrieren
- Mehrere Tools für Web-, Nachrichten-, Produktsuche und Q&A zu implementieren
- Strukturierte Daten für die LLM-Verarbeitung zu parsen und zu formatieren
- Fehler zu behandeln und API-Rate-Limits effektiv zu managen
- Sowohl automatisierte als auch interaktive MCP-Clients zu bauen und zu testen

## Web Search MCP Server

Dieser Abschnitt stellt die Architektur und Funktionen des Web Search MCP Servers vor. Du siehst, wie FastMCP und SerpAPI zusammen genutzt werden, um LLM-Fähigkeiten mit Echtzeit-Webdaten zu erweitern.

### Überblick

Diese Implementierung umfasst vier Tools, die die Fähigkeit von MCP zeigen, vielfältige, externe API-getriebene Aufgaben sicher und effizient zu bearbeiten:

- **general_search**: Für allgemeine Web-Ergebnisse
- **news_search**: Für aktuelle Schlagzeilen
- **product_search**: Für E-Commerce-Daten
- **qna**: Für Frage-und-Antwort-Schnipsel

### Funktionen
- **Codebeispiele**: Enthält sprachspezifische Codeblöcke für Python (und leicht erweiterbar auf andere Sprachen) mit ausklappbaren Abschnitten zur besseren Übersicht

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
- **Strukturierte Datenverarbeitung**: Verwandelt API-Antworten in LLM-freundliche Formate
- **Fehlerbehandlung**: Robuste Fehlerbehandlung mit passendem Logging
- **Interaktiver Client**: Beinhaltet automatisierte Tests und einen interaktiven Modus zum Testen
- **Kontextmanagement**: Nutzt MCP Context für Logging und Nachverfolgung von Anfragen

## Voraussetzungen

Bevor du startest, stelle sicher, dass deine Umgebung richtig eingerichtet ist, indem du diese Schritte befolgst. So sind alle Abhängigkeiten installiert und deine API-Schlüssel korrekt konfiguriert für eine reibungslose Entwicklung und Tests.

- Python 3.8 oder höher
- SerpAPI API-Schlüssel (Registrierung unter [SerpAPI](https://serpapi.com/) – kostenlose Stufe verfügbar)

## Installation

Um loszulegen, folge diesen Schritten, um deine Umgebung einzurichten:

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

## Nutzung

Der Web Search MCP Server ist die zentrale Komponente, die Tools für Web-, Nachrichten-, Produktsuche und Q&A über die Integration mit SerpAPI bereitstellt. Er verarbeitet eingehende Anfragen, steuert API-Aufrufe, parst Antworten und liefert strukturierte Ergebnisse an den Client zurück.

Die vollständige Implementierung findest du in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Server starten

Um den MCP-Server zu starten, verwende folgenden Befehl:

```bash
python server.py
```

Der Server läuft als stdio-basierter MCP-Server, zu dem der Client direkt eine Verbindung herstellen kann.

### Client-Modi

Der Client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Client ausführen

Um automatisierte Tests zu starten (dies startet automatisch den Server):

```bash
python client.py
```

Oder im interaktiven Modus ausführen:

```bash
python client.py --interactive
```

### Tests mit verschiedenen Methoden

Je nach Bedarf und Workflow gibt es verschiedene Möglichkeiten, die vom Server bereitgestellten Tools zu testen und zu nutzen.

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

In diesem Zusammenhang bedeutet ein "Testskript" ein eigenes Python-Programm, das du schreibst, um als Client für den MCP-Server zu fungieren. Anstatt ein formaler Unit-Test zu sein, erlaubt dir dieses Skript, programmatisch eine Verbindung zum Server herzustellen, eines der Tools mit selbstgewählten Parametern aufzurufen und die Ergebnisse zu prüfen. Diese Methode ist nützlich für:
- Prototyping und Experimentieren mit Tool-Aufrufen
- Validierung der Serverantworten auf verschiedene Eingaben
- Automatisierung wiederholter Tool-Aufrufe
- Aufbau eigener Workflows oder Integrationen auf Basis des MCP-Servers

Mit Testskripten kannst du neue Abfragen schnell ausprobieren, das Verhalten von Tools debuggen oder als Ausgangspunkt für komplexere Automatisierungen verwenden. Nachfolgend ein Beispiel, wie man mit dem MCP Python SDK ein solches Skript erstellt:

## Tool-Beschreibungen

Du kannst die folgenden Tools nutzen, die vom Server bereitgestellt werden, um verschiedene Such- und Abfragearten durchzuführen. Jedes Tool wird unten mit seinen Parametern und Beispielanwendungen beschrieben.

Dieser Abschnitt liefert Details zu jedem verfügbaren Tool und dessen Parametern.

### general_search

Führt eine allgemeine Websuche durch und liefert formatierte Ergebnisse zurück.

**So rufst du dieses Tool auf:**

Du kannst `general_search` aus deinem eigenen Skript mit dem MCP Python SDK aufrufen oder interaktiv über den Inspector oder den interaktiven Client-Modus. Hier ein Codebeispiel mit dem SDK:

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

**So rufst du dieses Tool auf:**

Du kannst `news_search` aus deinem eigenen Skript mit dem MCP Python SDK aufrufen oder interaktiv über den Inspector oder den interaktiven Client-Modus. Hier ein Codebeispiel mit dem SDK:

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

**So rufst du dieses Tool auf:**

Du kannst `product_search` aus deinem eigenen Skript mit dem MCP Python SDK aufrufen oder interaktiv über den Inspector oder den interaktiven Client-Modus. Hier ein Codebeispiel mit dem SDK:

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

**So rufst du dieses Tool auf:**

Du kannst `qna` aus deinem eigenen Skript mit dem MCP Python SDK aufrufen oder interaktiv über den Inspector oder den interaktiven Client-Modus. Hier ein Codebeispiel mit dem SDK:

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

Dieser Abschnitt bietet Codeausschnitte und Verweise zu den Server- und Client-Implementierungen.

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

Bevor du mit dem Aufbau beginnst, hier einige wichtige fortgeschrittene Konzepte, die im Kapitel immer wieder auftauchen. Ihr Verständnis hilft dir, besser folgen zu können, auch wenn du sie noch nicht kennst:

- **Multi-Tool-Orchestrierung**: Bedeutet, mehrere verschiedene Tools (wie Websuche, Nachrichtensuche, Produktsuche und Q&A) in einem einzigen MCP-Server auszuführen. So kann dein Server eine Vielzahl von Aufgaben bearbeiten, nicht nur eine.
- **Umgang mit API-Rate-Limits**: Viele externe APIs (wie SerpAPI) begrenzen, wie viele Anfragen du in einem bestimmten Zeitraum machen kannst. Guter Code prüft diese Limits und behandelt sie elegant, damit deine Anwendung nicht abstürzt, wenn du das Limit erreichst.
- **Strukturierte Datenverarbeitung**: API-Antworten sind oft komplex und verschachtelt. Dieses Konzept beschreibt, wie man diese Antworten in saubere, leicht nutzbare Formate umwandelt, die für LLMs oder andere Programme geeignet sind.
- **Fehlerbehebung**: Manchmal läuft etwas schief – vielleicht fällt das Netzwerk aus oder die API liefert unerwartete Ergebnisse. Fehlerbehebung bedeutet, dass dein Code diese Probleme handhaben kann und trotzdem nützliche Rückmeldungen gibt, statt abzustürzen.
- **Parameter-Validierung**: Hierbei wird geprüft, ob alle Eingaben zu deinen Tools korrekt und sicher sind. Dazu gehört das Setzen von Standardwerten und die Sicherstellung der richtigen Datentypen, was Bugs und Verwirrung vorbeugt.

Dieser Abschnitt hilft dir, häufige Probleme zu erkennen und zu lösen, die beim Arbeiten mit dem Web Search MCP Server auftreten können. Wenn du auf Fehler oder unerwartetes Verhalten stößt, findest du hier Lösungen für die häufigsten Probleme. Schau dir diese Tipps an, bevor du weitere Hilfe suchst – sie lösen oft Probleme schnell.

## Fehlerbehebung

Beim Arbeiten mit dem Web Search MCP Server kann es gelegentlich zu Problemen kommen – das ist normal bei der Entwicklung mit externen APIs und neuen Tools. Dieser Abschnitt bietet praktische Lösungen für die häufigsten Probleme, damit du schnell wieder weiterarbeiten kannst. Wenn ein Fehler auftritt, beginne hier: Die Tipps unten behandeln die häufigsten Fehler, mit denen Nutzer konfrontiert sind, und können dein Problem oft ohne weitere Hilfe lösen.

### Häufige Probleme

Hier sind einige der häufigsten Probleme, auf die Nutzer stoßen, mit klaren Erklärungen und Schritten zur Behebung:

1. **Fehlender SERPAPI_KEY in der .env-Datei**
   - Wenn du den Fehler `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` erhältst, erstelle eine `.env`-Datei, falls noch nicht vorhanden. Wenn dein Schlüssel korrekt ist, der Fehler aber weiterhin erscheint, prüfe, ob dein kostenloses Kontingent bereits aufgebraucht ist.

### Debug-Modus

Standardmäßig protokolliert die App nur wichtige Informationen. Wenn du mehr Details darüber sehen möchtest, was passiert (zum Beispiel zur Diagnose schwieriger Probleme), kannst du den DEBUG-Modus aktivieren. Dieser zeigt dir deutlich mehr zu jedem Schritt, den die App durchläuft.

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

Beachte, dass der DEBUG-Modus zusätzliche Zeilen zu HTTP-Anfragen, Antworten und anderen internen Details enthält. Das ist sehr hilfreich bei der Fehlersuche.

Um den DEBUG-Modus zu aktivieren, setze das Logging-Level auf DEBUG oben in deiner `client.py` or `server.py`:

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
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.