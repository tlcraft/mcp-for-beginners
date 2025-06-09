<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T19:15:02+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "nl"
}
-->
# Les: Een Web Search MCP Server bouwen

Dit hoofdstuk laat zien hoe je een echte AI-agent bouwt die integreert met externe API's, verschillende datatypes verwerkt, fouten afhandelt en meerdere tools coördineert—allemaal in een productieklare vorm. Je leert onder andere:

- **Integratie met externe API's die authenticatie vereisen**
- **Omgaan met diverse datatypes van meerdere eindpunten**
- **Robuuste foutafhandeling en logstrategieën**
- **Coördinatie van meerdere tools in één server**

Aan het einde heb je praktische ervaring met patronen en best practices die essentieel zijn voor geavanceerde AI- en LLM-gestuurde toepassingen.

## Introductie

In deze les leer je hoe je een geavanceerde MCP-server en client bouwt die LLM-capaciteiten uitbreidt met real-time webdata via SerpAPI. Dit is een belangrijke vaardigheid voor het ontwikkelen van dynamische AI-agenten die toegang hebben tot actuele informatie van het web.

## Leerdoelen

Aan het einde van deze les kun je:

- Externe API's (zoals SerpAPI) veilig integreren in een MCP-server
- Meerdere tools implementeren voor web-, nieuws-, productzoekopdrachten en Q&A
- Gestructureerde data parseren en formatteren voor LLM-gebruik
- Fouten afhandelen en API-ratelimieten effectief beheren
- Zowel geautomatiseerde als interactieve MCP-clients bouwen en testen

## Web Search MCP Server

In dit gedeelte wordt de architectuur en functionaliteit van de Web Search MCP Server geïntroduceerd. Je ziet hoe FastMCP en SerpAPI samenwerken om LLM-capaciteiten uit te breiden met real-time webdata.

### Overzicht

Deze implementatie bevat vier tools die laten zien hoe MCP diverse, door externe API’s aangedreven taken veilig en efficiënt kan uitvoeren:

- **general_search**: Voor brede webresultaten
- **news_search**: Voor recente nieuwsberichten
- **product_search**: Voor e-commerce data
- **qna**: Voor vraag-en-antwoordfragmenten

### Kenmerken
- **Codevoorbeelden**: Bevat taal-specifieke codeblokken voor Python (en eenvoudig uit te breiden naar andere talen) met inklapbare secties voor overzichtelijkheid

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

Voordat je de client start, is het handig om te begrijpen wat de server doet. De [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Hier is een kort voorbeeld van hoe de server een tool definieert en registreert:

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

- **Integratie met externe API's**: Laat zien hoe API-sleutels en externe verzoeken veilig worden behandeld
- **Parseren van gestructureerde data**: Toont hoe API-antwoorden worden omgezet naar formaten die geschikt zijn voor LLM
- **Foutafhandeling**: Robuuste foutafhandeling met passende logging
- **Interactieve client**: Bevat zowel geautomatiseerde tests als een interactieve modus voor testen
- **Contextbeheer**: Maakt gebruik van MCP Context voor logging en het bijhouden van verzoeken

## Vereisten

Voordat je begint, zorg dat je omgeving goed is ingesteld door de volgende stappen te volgen. Dit zorgt ervoor dat alle afhankelijkheden geïnstalleerd zijn en je API-sleutels correct geconfigureerd zijn voor een soepele ontwikkeling en testing.

- Python 3.8 of hoger
- SerpAPI API-sleutel (Meld je aan bij [SerpAPI](https://serpapi.com/) - gratis tier beschikbaar)

## Installatie

Volg deze stappen om je omgeving op te zetten:

1. Installeer afhankelijkheden met uv (aanbevolen) of pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Maak een `.env`-bestand aan in de hoofdmap van het project met je SerpAPI-sleutel:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Gebruik

De Web Search MCP Server is het kernonderdeel dat tools aanbiedt voor web-, nieuws-, productzoekopdrachten en Q&A door integratie met SerpAPI. Het verwerkt binnenkomende verzoeken, beheert API-aanroepen, parseert antwoorden en geeft gestructureerde resultaten terug aan de client.

Je kunt de volledige implementatie bekijken in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### De server starten

Start de MCP-server met het volgende commando:

```bash
python server.py
```

De server draait dan als een stdio-gebaseerde MCP-server waar de client direct mee kan verbinden.

### Client-modi

De client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### De client starten

Om de geautomatiseerde tests uit te voeren (deze starten automatisch de server):

```bash
python client.py
```

Of start in interactieve modus:

```bash
python client.py --interactive
```

### Testen met verschillende methoden

Er zijn meerdere manieren om de door de server aangeboden tools te testen en te gebruiken, afhankelijk van je behoeften en werkwijze.

#### Eigen testscripts schrijven met de MCP Python SDK
Je kunt ook eigen testscripts maken met de MCP Python SDK:

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

In deze context betekent een "testscripts" een eigen Python-programma dat je schrijft om als client voor de MCP-server te fungeren. In plaats van een formele unittests, kun je met dit script programmatisch verbinding maken met de server, een van de tools aanroepen met zelfgekozen parameters en de resultaten bekijken. Dit is handig voor:
- Prototypen en experimenteren met tool-aanroepen
- Controleren hoe de server reageert op verschillende inputs
- Automatiseren van herhaalde tool-aanroepen
- Eigen workflows of integraties bouwen bovenop de MCP-server

Je kunt testscripts gebruiken om snel nieuwe zoekopdrachten uit te proberen, tool-gedrag te debuggen of als startpunt voor geavanceerdere automatisering. Hieronder een voorbeeld van het gebruik van de MCP Python SDK om zo’n script te maken:

## Toolbeschrijvingen

Je kunt de volgende tools gebruiken die door de server worden aangeboden om verschillende soorten zoekopdrachten en queries uit te voeren. Elke tool wordt hieronder beschreven met zijn parameters en voorbeeldgebruik.

Dit gedeelte geeft details over elke beschikbare tool en hun parameters.

### general_search

Voert een algemene webzoekopdracht uit en geeft geformatteerde resultaten terug.

**Hoe roep je deze tool aan:**

Je kunt `general_search` aanroepen vanuit je eigen script met de MCP Python SDK, of interactief via de Inspector of de interactieve clientmodus. Hier is een codevoorbeeld met de SDK:

<details>
<summary>Python Voorbeeld</summary>

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

Of selecteer in de interactieve modus `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): De zoekopdracht

**Voorbeeldverzoek:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Zoekt naar recente nieuwsartikelen gerelateerd aan een zoekopdracht.

**Hoe roep je deze tool aan:**

Je kunt `news_search` aanroepen vanuit je eigen script met de MCP Python SDK, of interactief via de Inspector of de interactieve clientmodus. Hier is een codevoorbeeld met de SDK:

<details>
<summary>Python Voorbeeld</summary>

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

Of selecteer in de interactieve modus `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): De zoekopdracht

**Voorbeeldverzoek:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Zoekt naar producten die overeenkomen met een zoekopdracht.

**Hoe roep je deze tool aan:**

Je kunt `product_search` aanroepen vanuit je eigen script met de MCP Python SDK, of interactief via de Inspector of de interactieve clientmodus. Hier is een codevoorbeeld met de SDK:

<details>
<summary>Python Voorbeeld</summary>

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

Of selecteer in de interactieve modus `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): De productzoekopdracht

**Voorbeeldverzoek:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Geeft directe antwoorden op vragen vanuit zoekmachines.

**Hoe roep je deze tool aan:**

Je kunt `qna` aanroepen vanuit je eigen script met de MCP Python SDK, of interactief via de Inspector of de interactieve clientmodus. Hier is een codevoorbeeld met de SDK:

<details>
<summary>Python Voorbeeld</summary>

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

Of selecteer in de interactieve modus `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): De vraag waarvoor je een antwoord zoekt

**Voorbeeldverzoek:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Code details

Dit gedeelte bevat codefragmenten en verwijzingen voor de server- en clientimplementaties.

<details>
<summary>Python</summary>

Zie [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) voor de volledige implementatie.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Geavanceerde concepten in deze les

Voordat je begint met bouwen, zijn hier enkele belangrijke geavanceerde concepten die door dit hoofdstuk heen terugkomen. Begrip hiervan helpt je om de les beter te volgen, ook als je ze nog niet eerder hebt gebruikt:

- **Multi-tool Orchestratie**: Dit betekent dat je meerdere verschillende tools (zoals websearch, nieuwssearch, productsearch en Q&A) binnen één MCP-server draait. Hierdoor kan je server verschillende taken tegelijk aan, niet maar één.
- **API Ratelimiet Afhandeling**: Veel externe API's (zoals SerpAPI) beperken hoeveel verzoeken je in een bepaalde tijd kunt doen. Goede code controleert deze limieten en gaat er netjes mee om, zodat je app niet crasht als je de limiet bereikt.
- **Parseren van Gestructureerde Data**: API-antwoorden zijn vaak complex en genest. Dit concept gaat over het omzetten van die antwoorden naar schone, makkelijk te gebruiken formaten die vriendelijk zijn voor LLMs of andere programma's.
- **Foutherstel**: Soms gaat er iets mis—misschien valt het netwerk uit, of geeft de API niet het verwachte antwoord. Foutherstel betekent dat je code deze problemen kan opvangen en toch bruikbare feedback geeft, in plaats van te crashen.
- **Parameter Validatie**: Dit betekent dat je controleert of alle invoer naar je tools correct en veilig is. Dit omvat het instellen van standaardwaarden en het controleren van types, wat helpt bugs en verwarring te voorkomen.

## Problemen oplossen

Dit gedeelte helpt je bij het diagnosticeren en oplossen van veelvoorkomende problemen die je kunt tegenkomen bij het werken met de Web Search MCP Server. Als je fouten of onverwacht gedrag ervaart, biedt deze troubleshooting-sectie oplossingen voor de meest voorkomende problemen. Bekijk deze tips eerst—ze lossen vaak problemen snel op zonder dat je extra hulp nodig hebt.

### Veelvoorkomende problemen

Hieronder staan enkele van de meest voorkomende problemen waar gebruikers tegenaan lopen, met duidelijke uitleg en stappen om ze op te lossen:

1. **Ontbrekende SERPAPI_KEY in .env bestand**
   - Als je de foutmelding `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` krijgt, maak dan het `.env` bestand aan of vul het in. Als je sleutel klopt maar de fout blijft, controleer dan of je gratis tier nog niet op is.

### Debugmodus

Standaard logt de app alleen belangrijke informatie. Wil je meer details zien over wat er gebeurt (bijvoorbeeld om lastige problemen te onderzoeken), dan kun je de DEBUG-modus inschakelen. Dit toont veel meer over elke stap die de app neemt.

**Voorbeeld: Normale output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Voorbeeld: DEBUG output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Let op dat DEBUG-modus extra regels toont over HTTP-verzoeken, antwoorden en andere interne details. Dit kan erg handig zijn bij het oplossen van problemen.

Om DEBUG-modus in te schakelen, zet je het logniveau op DEBUG bovenaan je `client.py` or `server.py`:

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

## Wat nu?

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor belangrijke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.