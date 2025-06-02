<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:17:19+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "da"
}
-->
# Lesson: Bygning af en Web Search MCP Server


Dette kapitel viser, hvordan man bygger en AI-agent til virkelige anvendelser, som integrerer eksterne API'er, håndterer forskellige datatyper, styrer fejl og orkestrerer flere værktøjer — alt sammen i et produktionsklart format. Du vil se:

- **Integration med eksterne API'er, der kræver autentificering**
- **Håndtering af forskellige datatyper fra flere endpoints**
- **Robust fejlhåndtering og logningsstrategier**
- **Multi-værktøjs orkestrering i en enkelt server**

Når du er færdig, har du praktisk erfaring med mønstre og bedste praksis, der er essentielle for avancerede AI- og LLM-drevne applikationer.

## Introduktion

I denne lektion lærer du at bygge en avanceret MCP-server og klient, som udvider LLM’s kapaciteter med realtidsdata fra nettet ved hjælp af SerpAPI. Dette er en vigtig færdighed til at udvikle dynamiske AI-agenter, der kan hente opdateret information fra internettet.

## Læringsmål

Når du er færdig med denne lektion, vil du kunne:

- Integrere eksterne API’er (som SerpAPI) sikkert i en MCP-server
- Implementere flere værktøjer til web-, nyheds-, produkt-søgning og Q&A
- Parse og formatere strukturerede data til LLM-forbrug
- Håndtere fejl og styre API-ratelimits effektivt
- Bygge og teste både automatiserede og interaktive MCP-klienter

## Web Search MCP Server

Dette afsnit introducerer arkitekturen og funktionerne i Web Search MCP Server. Du vil se, hvordan FastMCP og SerpAPI bruges sammen til at udvide LLM’s kapaciteter med realtidsdata fra nettet.

### Oversigt

Denne implementering indeholder fire værktøjer, der demonstrerer MCP’s evne til sikkert og effektivt at håndtere forskellige, eksternt API-drevne opgaver:

- **general_search**: Til brede websøgninger
- **news_search**: Til seneste nyheder
- **product_search**: Til e-handelsdata
- **qna**: Til spørgsmål-og-svar uddrag

### Funktioner
- **Kodeeksempler**: Indeholder sprog-specifikke kodeblokke for Python (og let udvidelige til andre sprog) med sammenklappelige sektioner for overskuelighed

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

Før du kører klienten, er det nyttigt at forstå, hvad serveren gør. Se [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

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

- **Integration med eksterne API’er**: Viser sikker håndtering af API-nøgler og eksterne forespørgsler
- **Parsing af strukturerede data**: Viser, hvordan API-svar omdannes til LLM-venlige formater
- **Fejlhåndtering**: Robust fejlhåndtering med passende logning
- **Interaktiv klient**: Indeholder både automatiserede tests og en interaktiv tilstand til testning
- **Kontekststyring**: Udnytter MCP Context til logning og sporing af forespørgsler

## Forudsætninger

Før du går i gang, skal du sikre dig, at dit miljø er korrekt sat op ved at følge disse trin. Det sikrer, at alle afhængigheder er installeret, og at dine API-nøgler er konfigureret korrekt til problemfri udvikling og test.

- Python 3.8 eller nyere
- SerpAPI API-nøgle (Tilmeld dig på [SerpAPI](https://serpapi.com/) - gratis niveau tilgængeligt)

## Installation

For at komme i gang, følg disse trin for at sætte dit miljø op:

1. Installer afhængigheder ved hjælp af uv (anbefalet) eller pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Opret en `.env`-fil i projektets rodmappe med din SerpAPI-nøgle:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Brug

Web Search MCP Server er den centrale komponent, der eksponerer værktøjer til web-, nyheds-, produkt-søgning og Q&A ved at integrere med SerpAPI. Den håndterer indkommende forespørgsler, styrer API-kald, parser svar og returnerer strukturerede resultater til klienten.

Du kan gennemgå hele implementeringen i [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Kørsel af Serveren

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

### Kørsel af Klienten

For at køre automatiserede tests (det starter automatisk serveren):

```bash
python client.py
```

Eller kør i interaktiv tilstand:

```bash
python client.py --interactive
```

### Test med forskellige metoder

Der er flere måder at teste og interagere med de værktøjer, serveren tilbyder, afhængigt af dine behov og arbejdsflow.

#### Skrive egne test-scripts med MCP Python SDK
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


I denne sammenhæng betyder en "test-script" et brugerdefineret Python-program, du skriver for at fungere som klient til MCP-serveren. I stedet for en formel enhedstest, lader dette script dig programmere forbindelse til serveren, kalde dens værktøjer med valgte parametre og inspicere resultaterne. Denne tilgang er nyttig til:
- Prototyping og eksperimentering med værktøjskald
- Validering af, hvordan serveren reagerer på forskellige input
- Automatisering af gentagne værktøjskald
- Opbygning af egne workflows eller integrationer ovenpå MCP-serveren

Du kan bruge test-scripts til hurtigt at prøve nye forespørgsler, debugge værktøjsadfærd eller som udgangspunkt for mere avanceret automatisering. Nedenfor er et eksempel på, hvordan du bruger MCP Python SDK til at lave et sådant script:

## Beskrivelser af værktøjer

Du kan bruge følgende værktøjer, som serveren stiller til rådighed, til at udføre forskellige typer søgninger og forespørgsler. Hvert værktøj beskrives herunder med dets parametre og eksempler på brug.


Dette afsnit giver detaljer om hvert tilgængeligt værktøj og deres parametre.

### general_search

Udfører en generel websøgning og returnerer formaterede resultater.

**Sådan kalder du dette værktøj:**

Du kan kalde `general_search` fra dit eget script med MCP Python SDK eller interaktivt via Inspector eller den interaktive klienttilstand. Her er et kodeeksempel med SDK:

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

Dette afsnit indeholder kodeeksempler og referencer til server- og klientimplementeringerne.

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

Før du går i gang med at bygge, er her nogle vigtige avancerede koncepter, der vil optræde gennem hele kapitlet. At forstå disse hjælper dig med at følge med, selv hvis du er ny til dem:

- **Multi-værktøjs orkestrering**: Det betyder at køre flere forskellige værktøjer (som websøgning, nyhedssøgning, produktsøgning og Q&A) i en enkelt MCP-server. Det giver din server mulighed for at håndtere en række forskellige opgaver, ikke kun én.
- **Håndtering af API-ratelimits**: Mange eksterne API’er (som SerpAPI) begrænser, hvor mange forespørgsler du kan sende inden for en bestemt tid. God kode tjekker for disse begrænsninger og håndterer dem pænt, så din app ikke går ned, hvis du rammer en grænse.
- **Parsing af strukturerede data**: API-svar er ofte komplekse og indlejrede. Dette koncept handler om at omdanne disse svar til rene, let anvendelige formater, som er venlige for LLM’er eller andre programmer.
- **Fejlgenopretning**: Nogle gange går ting galt — måske fejler netværket, eller API’et returnerer ikke det forventede. Fejlgenopretning betyder, at din kode kan håndtere disse problemer og stadig give nyttig feedback i stedet for at crashe.
- **Parameter-validering**: Dette handler om at sikre, at alle input til dine værktøjer er korrekte og sikre at bruge. Det inkluderer at sætte standardværdier og sikre, at typerne er rigtige, hvilket hjælper med at undgå fejl og forvirring.

Dette afsnit hjælper dig med at diagnosticere og løse almindelige problemer, du kan støde på, mens du arbejder med Web Search MCP Server. Hvis du oplever fejl eller uventet opførsel, giver dette fejlfindingafsnit løsninger på de mest almindelige problemer. Gennemgå disse tips før du søger yderligere hjælp — de løser ofte problemer hurtigt.

## Fejlfinding

Når du arbejder med Web Search MCP Server, kan du af og til støde på problemer — det er normalt, når man udvikler med eksterne API’er og nye værktøjer. Dette afsnit giver praktiske løsninger på de mest almindelige problemer, så du hurtigt kan komme videre. Hvis du støder på en fejl, start her: nedenstående tips adresserer de problemer, som de fleste brugere møder, og kan ofte løse dit problem uden ekstra hjælp.

### Almindelige problemer

Her er nogle af de mest hyppige problemer, brugere støder på, sammen med klare forklaringer og trin til at løse dem:

1. **Mangler SERPAPI_KEY i .env-filen**
   - Hvis du ser fejlen `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` filen, opret den om nødvendigt. Hvis din nøgle er korrekt, men du stadig får denne fejl, så tjek om din gratis kvote er opbrugt.

### Debug-tilstand

Som standard logger appen kun vigtig information. Hvis du vil se flere detaljer om, hvad der sker (f.eks. for at diagnosticere vanskelige problemer), kan du aktivere DEBUG-tilstand. Det vil vise meget mere om hvert trin, appen tager.

**Eksempel: Normal output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Eksempel: DEBUG-output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Bemærk, hvordan DEBUG-tilstand inkluderer ekstra linjer om HTTP-forespørgsler, svar og andre interne detaljer. Det kan være meget hjælpsomt til fejlfinding.

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

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.