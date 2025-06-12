<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:49:36+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "da"
}
-->
# Lesson: Bygning af en Web Search MCP Server

Dette kapitel viser, hvordan man bygger en AI-agent til den virkelige verden, som integrerer med eksterne API’er, håndterer forskellige datatyper, styrer fejl og koordinerer flere værktøjer — alt sammen i et produktionsklart format. Du vil se:

- **Integration med eksterne API’er, der kræver autentifikation**
- **Håndtering af forskellige datatyper fra flere endpoints**
- **Robust fejlhåndtering og logningsstrategier**
- **Multi-værktøjs orkestrering i en enkelt server**

Ved slutningen vil du have praktisk erfaring med mønstre og bedste praksis, som er essentielle for avancerede AI- og LLM-drevne applikationer.

## Introduktion

I denne lektion lærer du, hvordan du bygger en avanceret MCP-server og klient, som udvider LLM-funktionalitet med realtidsdata fra nettet ved hjælp af SerpAPI. Dette er en vigtig færdighed til at udvikle dynamiske AI-agenter, der kan tilgå opdateret information fra nettet.

## Læringsmål

Ved slutningen af denne lektion vil du kunne:

- Integrere eksterne API’er (som SerpAPI) sikkert i en MCP-server
- Implementere flere værktøjer til web-, nyheds-, produkt-søgning og Q&A
- Parse og formatere strukturerede data til LLM-forbrug
- Håndtere fejl og styre API-ratelimits effektivt
- Bygge og teste både automatiserede og interaktive MCP-klienter

## Web Search MCP Server

Denne sektion introducerer arkitekturen og funktionerne i Web Search MCP Server. Du vil se, hvordan FastMCP og SerpAPI bruges sammen til at udvide LLM-funktionalitet med realtidsdata fra nettet.

### Oversigt

Denne implementering indeholder fire værktøjer, som viser MCP’s evne til sikkert og effektivt at håndtere forskellige opgaver drevet af eksterne API’er:

- **general_search**: Til brede webresultater
- **news_search**: Til nylige overskrifter
- **product_search**: Til e-handelsdata
- **qna**: Til spørgsmål-og-svar uddrag

### Funktioner
- **Kodeeksempler**: Indeholder sprog-specifikke kodeblokke for Python (og nemt udvideligt til andre sprog) med sammenklappelige sektioner for overskuelighed

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

Før du kører klienten, er det nyttigt at forstå, hvad serveren gør. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Her er et kort eksempel på, hvordan serveren definerer og registrerer et værktøj:

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

- **Integration med eksternt API**: Viser sikker håndtering af API-nøgler og eksterne forespørgsler
- **Parsing af strukturerede data**: Viser, hvordan API-svar omdannes til LLM-venlige formater
- **Fejlhåndtering**: Robust fejlhåndtering med passende logning
- **Interaktiv klient**: Indeholder både automatiserede tests og en interaktiv tilstand til test
- **Context Management**: Udnytter MCP Context til logning og sporing af forespørgsler

## Forudsætninger

Før du går i gang, skal du sikre dig, at dit miljø er korrekt opsat ved at følge disse trin. Det sikrer, at alle afhængigheder er installeret, og at dine API-nøgler er konfigureret korrekt til problemfri udvikling og test.

- Python 3.8 eller nyere
- SerpAPI API-nøgle (Tilmeld dig på [SerpAPI](https://serpapi.com/) - gratis niveau tilgængeligt)

## Installation

For at komme i gang, følg disse trin for at opsætte dit miljø:

1. Installer afhængigheder med uv (anbefalet) eller pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Opret en `.env`-fil i projektets rod med din SerpAPI-nøgle:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Brug

Web Search MCP Server er den centrale komponent, der eksponerer værktøjer til web-, nyheds-, produkt-søgning og Q&A ved at integrere med SerpAPI. Den håndterer indkommende forespørgsler, styrer API-kald, parser svar og returnerer strukturerede resultater til klienten.

Du kan gennemgå den fulde implementering i [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Kør serveren

For at starte MCP-serveren, brug følgende kommando:

```bash
python server.py
```

Serveren kører som en stdio-baseret MCP-server, som klienten kan forbinde til direkte.

### Klienttilstande

Klienten (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Kør klienten

For at køre de automatiserede tests (det starter automatisk serveren):

```bash
python client.py
```

Eller kør i interaktiv tilstand:

```bash
python client.py --interactive
```

### Test med forskellige metoder

Der findes flere måder at teste og interagere med de værktøjer, serveren tilbyder, afhængigt af dine behov og arbejdsgange.

#### Skriv brugerdefinerede test-scripts med MCP Python SDK
Du kan også bygge dine egne test-scripts ved hjælp af MCP Python SDK:

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

I denne sammenhæng betyder et "test-script" et brugerdefineret Python-program, du skriver for at agere som klient til MCP-serveren. I stedet for at være en formel enhedstest, lader dette script dig programmere en forbindelse til serveren, kalde dens værktøjer med valgte parametre og inspicere resultaterne. Denne tilgang er nyttig til:
- Prototyping og eksperimentering med værktøjskald
- Validering af, hvordan serveren reagerer på forskellige input
- Automatisering af gentagne værktøjskald
- Opbygning af dine egne arbejdsgange eller integrationer ovenpå MCP-serveren

Du kan bruge test-scripts til hurtigt at prøve nye forespørgsler, debugge værktøjers opførsel eller som udgangspunkt for mere avanceret automatisering. Nedenfor er et eksempel på, hvordan man bruger MCP Python SDK til at lave sådan et script:

## Værktøjsbeskrivelser

Du kan bruge følgende værktøjer, som serveren stiller til rådighed, til at udføre forskellige typer søgninger og forespørgsler. Hvert værktøj beskrives nedenfor med dets parametre og eksempler på brug.

Denne sektion giver detaljer om hvert tilgængeligt værktøj og deres parametre.

### general_search

Udfører en generel web-søgning og returnerer formaterede resultater.

**Sådan kalder du dette værktøj:**

Du kan kalde `general_search` fra dit eget script ved hjælp af MCP Python SDK eller interaktivt via Inspector eller den interaktive klienttilstand. Her er et kodeeksempel med SDK:

<details>
<summary>Python Eksempel</summary>

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

Alternativt, i interaktiv tilstand, vælg `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Søgeforespørgslen

**Eksempel på forespørgsel:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Søger efter nylige nyhedsartikler relateret til en forespørgsel.

**Sådan kalder du dette værktøj:**

Du kan kalde `news_search` fra dit eget script med MCP Python SDK eller interaktivt via Inspector eller den interaktive klienttilstand. Her er et kodeeksempel med SDK:

<details>
<summary>Python Eksempel</summary>

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

Alternativt, i interaktiv tilstand, vælg `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Søgeforespørgslen

**Eksempel på forespørgsel:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Søger efter produkter, der matcher en forespørgsel.

**Sådan kalder du dette værktøj:**

Du kan kalde `product_search` fra dit eget script med MCP Python SDK eller interaktivt via Inspector eller den interaktive klienttilstand. Her er et kodeeksempel med SDK:

<details>
<summary>Python Eksempel</summary>

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

Alternativt, i interaktiv tilstand, vælg `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Produkt-søgeforespørgslen

**Eksempel på forespørgsel:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Får direkte svar på spørgsmål fra søgemaskiner.

**Sådan kalder du dette værktøj:**

Du kan kalde `qna` fra dit eget script med MCP Python SDK eller interaktivt via Inspector eller den interaktive klienttilstand. Her er et kodeeksempel med SDK:

<details>
<summary>Python Eksempel</summary>

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

Alternativt, i interaktiv tilstand, vælg `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Spørgsmålet, der skal findes svar på

**Eksempel på forespørgsel:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Kodedetaljer

Denne sektion giver kodeeksempler og referencer til server- og klientimplementeringer.

<details>
<summary>Python</summary>

Se [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) for fulde implementeringsdetaljer.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Avancerede koncepter i denne lektion

Før du begynder at bygge, er her nogle vigtige avancerede koncepter, som vil optræde gennem hele kapitlet. At forstå disse hjælper dig med at følge med, selv hvis du er ny til dem:

- **Multi-værktøjs orkestrering**: Det betyder at køre flere forskellige værktøjer (som web-søgning, nyhedssøgning, produktsøgning og Q&A) inden for en enkelt MCP-server. Det gør det muligt for din server at håndtere en bred vifte af opgaver, ikke bare én.
- **Håndtering af API-rate limits**: Mange eksterne API’er (som SerpAPI) begrænser, hvor mange forespørgsler du kan sende inden for en bestemt tid. God kode tjekker for disse begrænsninger og håndterer dem pænt, så din app ikke går ned, hvis du rammer en grænse.
- **Parsing af strukturerede data**: API-svar er ofte komplekse og indlejrede. Dette koncept handler om at omdanne disse svar til rene, let anvendelige formater, som er venlige for LLM’er eller andre programmer.
- **Fejlgenopretning**: Nogle gange går ting galt — måske netværket fejler, eller API’et returnerer ikke det forventede. Fejlgenopretning betyder, at din kode kan håndtere disse problemer og stadig give brugbar feedback i stedet for at crashe.
- **Parameter-validering**: Det handler om at sikre, at alle input til dine værktøjer er korrekte og sikre at bruge. Det inkluderer at sætte standardværdier og sikre, at typerne er rigtige, hvilket hjælper med at forhindre fejl og forvirring.

Denne sektion hjælper dig med at diagnosticere og løse almindelige problemer, du kan støde på, når du arbejder med Web Search MCP Server. Hvis du oplever fejl eller uventet adfærd, giver denne fejlsøgningssektion løsninger på de mest almindelige problemer. Gennemgå disse tips, før du søger yderligere hjælp — de løser ofte problemer hurtigt.

## Fejlsøgning

Når du arbejder med Web Search MCP Server, kan du af og til støde på problemer — det er normalt, når man udvikler med eksterne API’er og nye værktøjer. Denne sektion giver praktiske løsninger på de mest almindelige problemer, så du hurtigt kan komme tilbage på sporet. Hvis du får en fejl, start her: tipsene nedenfor tager fat på de problemer, som de fleste brugere møder, og kan ofte løse dit problem uden yderligere hjælp.

### Almindelige problemer

Nedenfor er nogle af de mest hyppige problemer, brugere støder på, med klare forklaringer og trin til at løse dem:

1. **Manglende SERPAPI_KEY i .env-filen**
   - Hvis du ser fejlen `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` filen om nødvendigt. Hvis din nøgle er korrekt, men du stadig får denne fejl, så tjek, om din gratis kvote er opbrugt.

### Debug-tilstand

Som standard logger appen kun vigtig information. Hvis du vil se flere detaljer om, hvad der sker (for eksempel for at diagnosticere svære problemer), kan du aktivere DEBUG-tilstand. Det viser meget mere om hvert trin, appen tager.

**Eksempel: Normal output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Eksempel: DEBUG output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Bemærk, hvordan DEBUG-tilstand inkluderer ekstra linjer om HTTP-forespørgsler, svar og andre interne detaljer. Det kan være meget hjælpsomt til fejlsøgning.

For at aktivere DEBUG-tilstand, sæt logningsniveauet til DEBUG øverst i din `client.py` or `server.py`:

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

## Hvad er det næste

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.