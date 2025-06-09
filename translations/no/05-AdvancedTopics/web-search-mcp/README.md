<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T19:11:27+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "no"
}
-->
# Lesson: Bygge en Web Search MCP-server

Dette kapittelet viser hvordan du bygger en ekte AI-agent som integreres med eksterne API-er, håndterer ulike datatyper, administrerer feil, og orkestrerer flere verktøy – alt i en produksjonsklar løsning. Du vil se:

- **Integrasjon med eksterne API-er som krever autentisering**
- **Håndtering av ulike datatyper fra flere endepunkter**
- **Robust feilhåndtering og loggstrategier**
- **Orkestrering av flere verktøy i én server**

Mot slutten vil du ha praktisk erfaring med mønstre og beste praksis som er essensielle for avanserte AI- og LLM-drevne applikasjoner.

## Introduksjon

I denne leksjonen lærer du å bygge en avansert MCP-server og klient som utvider LLM-funksjonalitet med sanntids webdata ved hjelp av SerpAPI. Dette er en viktig ferdighet for å utvikle dynamiske AI-agenter som kan hente oppdatert informasjon fra nettet.

## Læringsmål

Etter denne leksjonen vil du kunne:

- Integrere eksterne API-er (som SerpAPI) sikkert i en MCP-server
- Implementere flere verktøy for web-, nyhets-, produkt-søk og spørsmål/svar
- Tolke og formatere strukturert data for LLM-bruk
- Håndtere feil og administrere API-ratebegrensninger effektivt
- Bygge og teste både automatiserte og interaktive MCP-klienter

## Web Search MCP-server

Denne seksjonen introduserer arkitekturen og funksjonene til Web Search MCP-serveren. Du vil se hvordan FastMCP og SerpAPI brukes sammen for å utvide LLM-funksjoner med sanntids webdata.

### Oversikt

Denne implementasjonen har fire verktøy som viser MCPs evne til å håndtere varierte, eksternt API-drevne oppgaver sikkert og effektivt:

- **general_search**: For brede webresultater
- **news_search**: For ferske nyhetssaker
- **product_search**: For e-handelsdata
- **qna**: For spørsmål-og-svar utdrag

### Funksjoner
- **Kodeeksempler**: Inkluderer språkspesifikke kodeblokker for Python (og lett utvidbare til andre språk) med sammenleggbare seksjoner for oversiktlighet

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

Før du kjører klienten, er det nyttig å forstå hva serveren gjør. Se [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Her er et kort eksempel på hvordan serveren definerer og registrerer et verktøy:

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

- **Integrasjon med eksternt API**: Viser sikker håndtering av API-nøkler og eksterne forespørsler
- **Tolkning av strukturert data**: Viser hvordan API-responser transformeres til LLM-vennlige formater
- **Feilhåndtering**: Robust håndtering av feil med passende logging
- **Interaktiv klient**: Inkluderer både automatiserte tester og en interaktiv modus for testing
- **Kontekststyring**: Bruker MCP Context for logging og sporing av forespørsler

## Forutsetninger

Før du begynner, sørg for at miljøet ditt er satt opp riktig ved å følge disse trinnene. Dette sikrer at alle avhengigheter er installert og at API-nøklene dine er konfigurert korrekt for sømløs utvikling og testing.

- Python 3.8 eller nyere
- SerpAPI API-nøkkel (Registrer deg på [SerpAPI](https://serpapi.com/) – gratis nivå tilgjengelig)

## Installasjon

For å komme i gang, følg disse stegene for å sette opp miljøet ditt:

1. Installer avhengigheter med uv (anbefalt) eller pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Lag en `.env`-fil i prosjektets rotmappe med din SerpAPI-nøkkel:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Bruk

Web Search MCP-serveren er kjernen som eksponerer verktøy for web-, nyhets-, produkt-søk og spørsmål/svar ved å integrere med SerpAPI. Den håndterer innkommende forespørsler, styrer API-kall, tolker svar, og returnerer strukturerte resultater til klienten.

Du kan se hele implementasjonen i [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Kjøre serveren

For å starte MCP-serveren, bruk denne kommandoen:

```bash
python server.py
```

Serveren kjører som en stdio-basert MCP-server som klienten kan koble seg direkte til.

### Klientmoduser

Klienten (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Kjøre klienten

For å kjøre automatiserte tester (dette starter automatisk serveren):

```bash
python client.py
```

Eller kjør i interaktiv modus:

```bash
python client.py --interactive
```

### Testing med ulike metoder

Det finnes flere måter å teste og samhandle med verktøyene serveren tilbyr, avhengig av dine behov og arbeidsflyt.

#### Skrive egne testskript med MCP Python SDK
Du kan også lage dine egne testskript ved hjelp av MCP Python SDK:

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

I denne sammenhengen betyr "testskript" et tilpasset Python-program du skriver for å fungere som klient til MCP-serveren. I stedet for å være en formell enhetstest, lar dette skriptet deg programmere tilkobling til serveren, kalle verktøy med egne parametere, og undersøke resultatene. Denne tilnærmingen er nyttig for:
- Prototyping og eksperimentering med verktøysamtaler
- Validere hvordan serveren reagerer på ulike input
- Automatisere gjentatte verktøysamtaler
- Bygge egne arbeidsflyter eller integrasjoner på toppen av MCP-serveren

Du kan bruke testskript for raskt å prøve ut nye søk, feilsøke verktøyadferd, eller som utgangspunkt for mer avansert automatisering. Under er et eksempel på hvordan du bruker MCP Python SDK til å lage et slikt skript:

## Verktøybeskrivelser

Du kan bruke følgende verktøy som serveren tilbyr for å utføre forskjellige typer søk og spørringer. Hvert verktøy er beskrevet nedenfor med parametere og eksempelbruk.

Denne seksjonen gir detaljer om hvert tilgjengelig verktøy og deres parametere.

### general_search

Utfører et generelt web-søk og returnerer formaterte resultater.

**Hvordan bruke dette verktøyet:**

Du kan kalle `general_search` fra ditt eget skript ved hjelp av MCP Python SDK, eller interaktivt via Inspector eller den interaktive klientmodusen. Her er et kodeeksempel med SDK:

<details>
<summary>Python-eksempel</summary>

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

Alternativt, i interaktiv modus, velg `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Søkeordet

**Eksempel på forespørsel:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Søker etter ferske nyhetsartikler relatert til en søkefrase.

**Hvordan bruke dette verktøyet:**

Du kan kalle `news_search` fra ditt eget skript med MCP Python SDK, eller interaktivt via Inspector eller den interaktive klientmodusen. Her er et kodeeksempel med SDK:

<details>
<summary>Python-eksempel</summary>

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

Alternativt, i interaktiv modus, velg `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Søkeordet

**Eksempel på forespørsel:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Søker etter produkter som matcher en søkefrase.

**Hvordan bruke dette verktøyet:**

Du kan kalle `product_search` fra ditt eget skript med MCP Python SDK, eller interaktivt via Inspector eller den interaktive klientmodusen. Her er et kodeeksempel med SDK:

<details>
<summary>Python-eksempel</summary>

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

Alternativt, i interaktiv modus, velg `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Produktsøk-frasen

**Eksempel på forespørsel:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Henter direkte svar på spørsmål fra søkemotorer.

**Hvordan bruke dette verktøyet:**

Du kan kalle `qna` fra ditt eget skript med MCP Python SDK, eller interaktivt via Inspector eller den interaktive klientmodusen. Her er et kodeeksempel med SDK:

<details>
<summary>Python-eksempel</summary>

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

Alternativt, i interaktiv modus, velg `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Spørsmålet du ønsker svar på

**Eksempel på forespørsel:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Kodedetaljer

Denne seksjonen gir kodeutdrag og referanser for server- og klientimplementasjonene.

<details>
<summary>Python</summary>

Se [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) for fullstendige implementasjonsdetaljer.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Avanserte konsepter i denne leksjonen

Før du begynner å bygge, her er noen viktige avanserte konsepter som dukker opp gjennom kapittelet. Å forstå disse hjelper deg å følge med, selv om du er ny på dem:

- **Orkestrering av flere verktøy**: Dette betyr at flere ulike verktøy (som web-søk, nyhetssøk, produktsøk og Q&A) kjører i én MCP-server. Det gjør at serveren kan håndtere mange typer oppgaver, ikke bare én.
- **Håndtering av API-ratebegrensninger**: Mange eksterne API-er (som SerpAPI) begrenser hvor mange forespørsler du kan sende på en gitt tid. God kode sjekker disse begrensningene og håndterer dem smidig, så appen ikke krasjer om du når grensen.
- **Tolkning av strukturert data**: API-svar er ofte komplekse og nestede. Dette handler om å gjøre disse svarene om til rene, lettbrukte formater som passer for LLM eller andre programmer.
- **Feilgjenoppretting**: Noen ganger går noe galt – kanskje nettverket feiler, eller API-et svarer ikke som forventet. Feilgjenoppretting betyr at koden kan håndtere disse problemene og fortsatt gi nyttig tilbakemelding, i stedet for å krasje.
- **Validering av parametere**: Dette handler om å sjekke at alle input til verktøyene dine er riktige og trygge å bruke. Det inkluderer å sette standardverdier og sikre at typene stemmer, noe som hjelper å unngå feil og forvirring.

Denne seksjonen hjelper deg å diagnostisere og løse vanlige problemer du kan støte på når du jobber med Web Search MCP-serveren. Hvis du møter feil eller uventet oppførsel, gir denne feilsøkingsdelen løsninger på de vanligste problemene. Gå gjennom disse tipsene før du søker videre hjelp – de løser ofte problemene raskt.

## Feilsøking

Når du jobber med Web Search MCP-serveren, kan du av og til møte problemer – dette er normalt når man utvikler med eksterne API-er og nye verktøy. Denne seksjonen gir praktiske løsninger på de vanligste problemene, slik at du raskt kan komme tilbake på sporet. Hvis du får en feil, start her: tipsene under tar for seg problemer flest brukere møter og løser ofte problemene uten ekstra hjelp.

### Vanlige problemer

Nedenfor er noen av de mest vanlige problemene brukere møter, med klare forklaringer og hvordan du løser dem:

1. **Manglende SERPAPI_KEY i .env-fil**
   - Hvis du får feilen `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `, opprett `.env`-filen om nødvendig. Hvis nøkkelen er riktig, men du fortsatt ser feilen, sjekk om gratisnivået ditt har brukt opp kvoten.

### Feilsøkingsmodus

Som standard logger appen bare viktig informasjon. Hvis du vil se flere detaljer om hva som skjer (for eksempel for å feilsøke vanskelige problemer), kan du aktivere DEBUG-modus. Dette viser mye mer om hvert steg appen tar.

**Eksempel: Normal utdata**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Eksempel: DEBUG-utdata**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Legg merke til at DEBUG-modus inkluderer ekstra linjer om HTTP-forespørsler, svar og andre interne detaljer. Dette kan være svært nyttig ved feilsøking.

For å aktivere DEBUG-modus, sett loggnivået til DEBUG øverst i `client.py` or `server.py`:

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

## Hva skjer videre

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på det opprinnelige språket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.