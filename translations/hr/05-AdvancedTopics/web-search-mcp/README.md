<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T16:31:16+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "hr"
}
-->
# Lekcija: Izgradnja Web Search MCP Servera

Ovo poglavlje pokazuje kako izgraditi stvarnog AI agenta koji se integrira s vanjskim API-jima, rukuje različitim vrstama podataka, upravlja greškama i koordinira više alata—sve u proizvodno spremnom formatu. Vidjet ćete:

- **Integraciju s vanjskim API-jima koji zahtijevaju autentifikaciju**
- **Rukovanje različitim vrstama podataka s više krajnjih točaka**
- **Robusne strategije za rukovanje greškama i logiranje**
- **Orkestraciju više alata u jednom serveru**

Na kraju ćete imati praktično iskustvo s obrascima i najboljim praksama koje su ključne za napredne AI i LLM-pokretane aplikacije.

## Uvod

U ovoj lekciji naučit ćete kako izgraditi napredni MCP server i klijenta koji proširuju LLM mogućnosti s podacima u stvarnom vremenu koristeći SerpAPI. Ovo je ključna vještina za razvoj dinamičnih AI agenata koji mogu pristupiti ažuriranim informacijama s weba.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Sigurno integrirati vanjske API-je (poput SerpAPI) u MCP server
- Implementirati više alata za pretraživanje weba, vijesti, proizvoda i pitanja i odgovora
- Parsirati i formatirati strukturirane podatke za LLM
- Učinkovito upravljati greškama i ograničenjima API-ja
- Izgraditi i testirati automatizirane i interaktivne MCP klijente

## Web Search MCP Server

Ovaj dio uvodi arhitekturu i značajke Web Search MCP Servera. Vidjet ćete kako se FastMCP i SerpAPI koriste zajedno za proširenje LLM mogućnosti s podacima u stvarnom vremenu.

### Pregled

Ova implementacija sadrži četiri alata koji pokazuju MCP-ovu sposobnost da sigurno i učinkovito rukuje raznolikim zadacima pokretanim vanjskim API-jima:

- **general_search**: Za široke rezultate pretraživanja weba
- **news_search**: Za najnovije vijesti
- **product_search**: Za podatke o e-trgovini
- **qna**: Za isječke pitanja i odgovora

### Značajke
- **Primjeri koda**: Uključuje jezične blokove koda za Python (i lako proširive na druge jezike) koristeći sažimajuće sekcije radi jasnoće

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

Prije pokretanja klijenta, korisno je razumjeti što server radi. Pogledajte [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Evo kratkog primjera kako server definira i registrira alat:

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

- **Integracija vanjskog API-ja**: Pokazuje sigurno rukovanje API ključevima i vanjskim zahtjevima
- **Parsiranje strukturiranih podataka**: Prikazuje kako transformirati odgovore API-ja u formate prilagođene LLM-u
- **Rukovanje greškama**: Robusno upravljanje greškama s prikladnim logiranjem
- **Interaktivni klijent**: Uključuje automatizirane testove i interaktivni način rada za testiranje
- **Upravljanje kontekstom**: Koristi MCP Context za logiranje i praćenje zahtjeva

## Preduvjeti

Prije početka, provjerite da je vaše okruženje pravilno postavljeno slijedeći ove korake. To će osigurati da su sve ovisnosti instalirane i da su vaši API ključevi ispravno konfigurirani za nesmetan razvoj i testiranje.

- Python 3.8 ili noviji
- SerpAPI API ključ (registrirajte se na [SerpAPI](https://serpapi.com/) - dostupna je besplatna razina)

## Instalacija

Za početak, slijedite ove korake za postavljanje okruženja:

1. Instalirajte ovisnosti koristeći uv (preporučeno) ili pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Kreirajte `.env` datoteku u korijenu projekta s vašim SerpAPI ključem:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Korištenje

Web Search MCP Server je ključna komponenta koja izlaže alate za pretraživanje weba, vijesti, proizvoda i Q&A integracijom sa SerpAPI-jem. Rukuje dolaznim zahtjevima, upravlja API pozivima, parsira odgovore i vraća strukturirane rezultate klijentu.

Puni kod možete pregledati u [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Pokretanje servera

Za pokretanje MCP servera koristite sljedeću naredbu:

```bash
python server.py
```

Server će raditi kao stdio-bazirani MCP server na koji se klijent može izravno povezati.

### Načini rada klijenta

Klijent (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Pokretanje klijenta

Za pokretanje automatiziranih testova (ovo će automatski pokrenuti server):

```bash
python client.py
```

Ili pokrenite u interaktivnom načinu:

```bash
python client.py --interactive
```

### Testiranje različitim metodama

Postoji nekoliko načina za testiranje i interakciju s alatima koje server pruža, ovisno o vašim potrebama i radnom tijeku.

#### Pisanje prilagođenih testnih skripti s MCP Python SDK-om
Također možete izgraditi vlastite testne skripte koristeći MCP Python SDK:

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

U ovom kontekstu, "testna skripta" znači prilagođeni Python program koji pišete da djeluje kao klijent MCP servera. Umjesto formalnog jedinicnog testa, ova skripta vam omogućuje programatsko povezivanje sa serverom, pozivanje bilo kojeg od njegovih alata s parametrima koje odaberete i pregled rezultata. Ovaj pristup je koristan za:
- Prototipiranje i eksperimentiranje s pozivima alata
- Provjeru kako server reagira na različite ulaze
- Automatizaciju ponovljenih poziva alata
- Izgradnju vlastitih radnih tijekova ili integracija na vrhu MCP servera

Možete koristiti testne skripte za brzo isprobavanje novih upita, otklanjanje pogrešaka u ponašanju alata ili čak kao polaznu točku za napredniju automatizaciju. Ispod je primjer kako koristiti MCP Python SDK za kreiranje takve skripte:

## Opisi alata

Možete koristiti sljedeće alate koje server pruža za izvođenje različitih vrsta pretraživanja i upita. Svaki alat je opisan s parametrima i primjerom korištenja.

Ovaj dio daje detalje o svakom dostupnom alatu i njihovim parametrima.

### general_search

Izvodi opće pretraživanje weba i vraća formatirane rezultate.

**Kako pozvati ovaj alat:**

Možete pozvati `general_search` iz vlastite skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspector ili interaktivni način rada klijenta. Evo primjera koda koristeći SDK:

<details>
<summary>Python primjer</summary>

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

Alternativno, u interaktivnom načinu odaberite `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Upit za pretraživanje

**Primjer zahtjeva:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Pretražuje najnovije vijesti povezane s upitom.

**Kako pozvati ovaj alat:**

Možete pozvati `news_search` iz vlastite skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspector ili interaktivni način rada klijenta. Evo primjera koda koristeći SDK:

<details>
<summary>Python primjer</summary>

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

Alternativno, u interaktivnom načinu odaberite `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Upit za pretraživanje

**Primjer zahtjeva:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Pretražuje proizvode koji odgovaraju upitu.

**Kako pozvati ovaj alat:**

Možete pozvati `product_search` iz vlastite skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspector ili interaktivni način rada klijenta. Evo primjera koda koristeći SDK:

<details>
<summary>Python primjer</summary>

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

Alternativno, u interaktivnom načinu odaberite `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Upit za pretraživanje proizvoda

**Primjer zahtjeva:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Daje izravne odgovore na pitanja iz tražilica.

**Kako pozvati ovaj alat:**

Možete pozvati `qna` iz vlastite skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspector ili interaktivni način rada klijenta. Evo primjera koda koristeći SDK:

<details>
<summary>Python primjer</summary>

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

Alternativno, u interaktivnom načinu odaberite `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Pitanje za koje tražite odgovor

**Primjer zahtjeva:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Detalji koda

Ovaj dio pruža isječke koda i reference za implementacije servera i klijenta.

<details>
<summary>Python</summary>

Pogledajte [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) za potpune detalje implementacije.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Napredni koncepti u ovoj lekciji

Prije nego što počnete graditi, ovdje su neki važni napredni koncepti koji će se pojavljivati kroz cijelo poglavlje. Razumijevanje ovih pomoći će vam da lakše pratite, čak i ako su vam novi:

- **Orkestracija više alata**: To znači pokretanje nekoliko različitih alata (kao što su web pretraživanje, pretraživanje vijesti, pretraživanje proizvoda i Q&A) unutar jednog MCP servera. To omogućava vašem serveru da rukuje različitim zadacima, ne samo jednim.
- **Upravljanje ograničenjem API-ja**: Mnogi vanjski API-ji (kao SerpAPI) ograničavaju koliko zahtjeva možete poslati u određenom vremenu. Dobar kod provjerava ta ograničenja i lijepo ih rješava, tako da vaša aplikacija ne pukne ako dosegnete limit.
- **Parsiranje strukturiranih podataka**: Odgovori API-ja često su složeni i ugniježđeni. Ovaj koncept se odnosi na pretvaranje tih odgovora u čiste, jednostavne formate koji su pogodni za LLM ili druge programe.
- **Oporavak od grešaka**: Ponekad stvari krenu po zlu—mreža može pasti ili API ne vrati očekivani rezultat. Oporavak od grešaka znači da vaš kod može rukovati tim problemima i dati korisne povratne informacije, umjesto da se sruši.
- **Validacija parametara**: Radi se o provjeri jesu li svi ulazi u vaše alate ispravni i sigurni za korištenje. Uključuje postavljanje zadane vrijednosti i provjeru tipova, što pomaže spriječiti greške i nesporazume.

Ovaj dio pomoći će vam da dijagnosticirate i riješite česte probleme na koje možete naići dok radite s Web Search MCP Serverom. Ako naiđete na greške ili neočekivano ponašanje, ovaj dio s rješenjima nudi odgovore na najčešće probleme. Pregledajte ove savjete prije traženja dodatne pomoći—često brzo rješavaju problem.

## Rješavanje problema

Pri radu s Web Search MCP Serverom, povremeno se mogu pojaviti problemi—što je normalno kod razvoja s vanjskim API-jima i novim alatima. Ovaj dio nudi praktična rješenja za najčešće probleme, kako biste brzo nastavili dalje. Ako naiđete na grešku, počnite ovdje: savjeti u nastavku pokrivaju probleme koje većina korisnika susreće i često mogu riješiti vaš problem bez dodatne pomoći.

### Česti problemi

Ispod su neki od najčešćih problema koje korisnici susreću, zajedno s jasnim objašnjenjima i koracima za njihovo rješavanje:

1. **Nedostaje SERPAPI_KEY u .env datoteci**
   - Ako vidite grešku `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` datoteku po potrebi. Ako je vaš ključ ispravan, ali još uvijek vidite ovu grešku, provjerite nije li vam istekao kvota za besplatnu razinu.

### Debug način rada

Po defaultu, aplikacija logira samo važne informacije. Ako želite vidjeti više detalja o tome što se događa (npr. za dijagnosticiranje složenijih problema), možete uključiti DEBUG način rada. To će vam prikazati puno više informacija o svakom koraku koji aplikacija poduzima.

**Primjer: Normalni ispis**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Primjer: DEBUG ispis**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Primijetite kako DEBUG način uključuje dodatne linije o HTTP zahtjevima, odgovorima i drugim internim detaljima. Ovo može biti vrlo korisno za rješavanje problema.

Za uključivanje DEBUG načina, postavite razinu logiranja na DEBUG na vrhu vašeg `client.py` or `server.py`:

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

## Što slijedi

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.