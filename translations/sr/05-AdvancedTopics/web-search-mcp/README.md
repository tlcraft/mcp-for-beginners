<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T16:29:00+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "sr"
}
-->
# Lekcija: Izgradnja Web Search MCP Servera

Ovo poglavlje pokazuje kako napraviti pravog AI agenta koji se integriše sa spoljnim API-jima, rukuje različitim tipovima podataka, upravlja greškama i koordinira više alata — sve u formatu spremnom za produkciju. Videćete:

- **Integraciju sa spoljnim API-jima koji zahtevaju autentifikaciju**
- **Rukovanje različitim tipovima podataka sa više krajnjih tačaka**
- **Robusne strategije za upravljanje greškama i logovanje**
- **Orkestraciju više alata unutar jednog servera**

Na kraju, steći ćete praktično iskustvo sa obrascima i najboljim praksama koje su ključne za napredne AI i LLM aplikacije.

## Uvod

U ovoj lekciji naučićete kako da napravite napredni MCP server i klijent koji proširuju LLM mogućnosti koristeći realne podatke sa interneta preko SerpAPI-ja. Ovo je ključna veština za razvoj dinamičnih AI agenata koji mogu pristupati ažurnim informacijama sa weba.

## Ciljevi učenja

Na kraju ove lekcije bićete u stanju da:

- Sigurno integrišete spoljne API-je (kao što je SerpAPI) u MCP server
- Implementirate više alata za pretragu weba, vesti, proizvoda i pitanja i odgovora
- Parsirate i formatirate strukturirane podatke za upotrebu sa LLM-om
- Efikasno upravljate greškama i limitima API poziva
- Pravite i testirate kako automatizovane, tako i interaktivne MCP klijente

## Web Search MCP Server

Ovaj deo uvodi arhitekturu i funkcionalnosti Web Search MCP Servera. Videćete kako se FastMCP i SerpAPI koriste zajedno da prošire LLM mogućnosti sa realnim web podacima.

### Pregled

Ova implementacija sadrži četiri alata koji prikazuju MCP sposobnost da sigurno i efikasno rukuje raznovrsnim zadacima vođenim spoljnim API-jima:

- **general_search**: Za široke web rezultate
- **news_search**: Za najnovije vesti
- **product_search**: Za podatke o proizvodima u e-trgovini
- **qna**: Za isječke pitanja i odgovora

### Funkcionalnosti
- **Primeri koda**: Uključuje jezički specifične blokove koda za Python (i lako se može proširiti na druge jezike) koristeći sklapanje sekcija radi preglednosti

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

Pre nego što pokrenete klijenta, korisno je razumeti šta server radi. Pogledajte [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Evo kratkog primera kako server definiše i registruje alat:

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

- **Integracija spoljnog API-ja**: Pokazuje sigurno rukovanje API ključevima i spoljnim zahtevima
- **Parsiranje strukturiranih podataka**: Prikazuje kako se API odgovori pretvaraju u formate pogodne za LLM
- **Upravljanje greškama**: Robusno rukovanje greškama sa adekvatnim logovanjem
- **Interaktivni klijent**: Uključuje automatizovane testove i interaktivni režim za testiranje
- **Upravljanje kontekstom**: Koristi MCP Context za logovanje i praćenje zahteva

## Preduslovi

Pre nego što počnete, proverite da li je vaše okruženje pravilno podešeno prateći sledeće korake. Ovo će osigurati da su sve zavisnosti instalirane i da su vaši API ključevi ispravno konfigurirani za nesmetan razvoj i testiranje.

- Python 3.8 ili noviji
- SerpAPI API ključ (Registrujte se na [SerpAPI](https://serpapi.com/) - dostupan je besplatni nivo)

## Instalacija

Da biste započeli, pratite sledeće korake za podešavanje okruženja:

1. Instalirajte zavisnosti koristeći uv (preporučeno) ili pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Kreirajte `.env` fajl u root direktorijumu projekta sa vašim SerpAPI ključem:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Upotreba

Web Search MCP Server je ključna komponenta koja izlaže alate za pretragu weba, vesti, proizvoda i pitanja i odgovora integracijom sa SerpAPI-jem. On prima zahteve, upravlja API pozivima, parsira odgovore i vraća strukturirane rezultate klijentu.

Kompletan kod možete pregledati u [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Pokretanje servera

Da biste pokrenuli MCP server, koristite sledeću komandu:

```bash
python server.py
```

Server će raditi kao stdio-bazirani MCP server kome se klijent može direktno povezati.

### Režimi rada klijenta

Klijent (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Pokretanje klijenta

Da biste pokrenuli automatizovane testove (ovo će automatski startovati server):

```bash
python client.py
```

Ili pokrenite u interaktivnom režimu:

```bash
python client.py --interactive
```

### Testiranje različitim metodama

Postoji nekoliko načina da testirate i komunicirate sa alatima koje server pruža, u zavisnosti od vaših potreba i radnog toka.

#### Pisanje prilagođenih test skripti koristeći MCP Python SDK
Takođe možete praviti sopstvene test skripte koristeći MCP Python SDK:

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

U ovom kontekstu, "test skripta" znači prilagođeni Python program koji pišete da bi delovao kao klijent MCP servera. Umesto formalnog jedinicnog testa, ova skripta vam omogućava da programatski povežete sa serverom, pozovete bilo koji od njegovih alata sa parametrima po izboru i pregledate rezultate. Ovaj pristup je koristan za:
- Prototipizaciju i eksperimentisanje sa pozivima alata
- Validaciju kako server reaguje na različite ulaze
- Automatizaciju ponovljenih poziva alata
- Pravljenje sopstvenih tokova rada ili integracija na vrhu MCP servera

Test skripte možete koristiti da brzo isprobate nove upite, otklonite greške u ponašanju alata ili čak kao polaznu tačku za napredniju automatizaciju. Ispod je primer kako koristiti MCP Python SDK za kreiranje takve skripte:

## Opisi alata

Možete koristiti sledeće alate koje server pruža za različite vrste pretraga i upita. Svaki alat je opisan sa parametrima i primerom upotrebe.

Ovaj deo daje detalje o svakom dostupnom alatu i njihovim parametrima.

### general_search

Obavlja opštu web pretragu i vraća formatirane rezultate.

**Kako pozvati ovaj alat:**

Možete pozvati `general_search` iz svoje skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspector ili interaktivni režim klijenta. Evo primera koda koristeći SDK:

<details>
<summary>Python primer</summary>

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

Alternativno, u interaktivnom režimu izaberite `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Upit za pretragu

**Primer zahteva:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Pretražuje najnovije vesti vezane za upit.

**Kako pozvati ovaj alat:**

Možete pozvati `news_search` iz svoje skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspector ili interaktivni režim klijenta. Evo primera koda koristeći SDK:

<details>
<summary>Python primer</summary>

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

Alternativno, u interaktivnom režimu izaberite `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Upit za pretragu

**Primer zahteva:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Pretražuje proizvode koji odgovaraju upitu.

**Kako pozvati ovaj alat:**

Možete pozvati `product_search` iz svoje skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspector ili interaktivni režim klijenta. Evo primera koda koristeći SDK:

<details>
<summary>Python primer</summary>

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

Alternativno, u interaktivnom režimu izaberite `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Upit za pretragu proizvoda

**Primer zahteva:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Daje direktne odgovore na pitanja iz pretraživača.

**Kako pozvati ovaj alat:**

Možete pozvati `qna` iz svoje skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspector ili interaktivni režim klijenta. Evo primera koda koristeći SDK:

<details>
<summary>Python primer</summary>

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

Alternativno, u interaktivnom režimu izaberite `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Pitanje za koje tražite odgovor

**Primer zahteva:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Detalji koda

Ovaj deo pruža isečke koda i reference za implementacije servera i klijenta.

<details>
<summary>Python</summary>

Pogledajte [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) za kompletne detalje implementacije.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Napredni koncepti u ovoj lekciji

Pre nego što počnete sa izgradnjom, evo nekoliko važnih naprednih koncepata koji će se pojavljivati kroz ovo poglavlje. Razumevanje ovih pomoći će vam da pratite, čak i ako vam nisu poznati:

- **Orkestracija više alata**: To znači da u jednom MCP serveru pokrećete više različitih alata (kao što su web pretraga, pretraga vesti, pretraga proizvoda i pitanja i odgovori). Ovo omogućava serveru da rukuje različitim zadacima, ne samo jednim.
- **Upravljanje limitima API poziva**: Mnogi spoljašnji API-ji (kao SerpAPI) ograničavaju koliko zahteva možete poslati u određenom vremenu. Dobar kod proverava te limite i upravlja njima na način da aplikacija ne pukne ako se limit dostigne.
- **Parsiranje strukturiranih podataka**: Odgovori API-ja su često složeni i ugnježdeni. Ovaj koncept se odnosi na pretvaranje tih odgovora u čiste, lako upotrebljive formate koji su pogodni za LLM ili druge programe.
- **Oporavak od grešaka**: Ponekad nešto krene po zlu — možda mreža zakaže ili API ne vrati očekivane podatke. Oporavak od grešaka znači da vaš kod može da se nosi sa tim problemima i da i dalje daje korisne povratne informacije, umesto da se sruši.
- **Validacija parametara**: Ovo znači proveru da li su svi ulazi za vaše alate ispravni i bezbedni za upotrebu. Uključuje postavljanje podrazumevanih vrednosti i proveru tipova, što pomaže u sprečavanju grešaka i zabune.

Ovaj deo će vam pomoći da dijagnostikujete i rešite česte probleme na koje možete naići dok radite sa Web Search MCP Serverom. Ako naiđete na greške ili neočekivano ponašanje, ovaj odeljak za rešavanje problema nudi rešenja za najčešće poteškoće. Pregledajte ove savete pre nego što tražite dodatnu pomoć — često brzo rešavaju problem.

## Rešavanje problema

Tokom rada sa Web Search MCP Serverom, povremeno možete naići na probleme — to je normalno pri razvoju sa spoljnim API-jima i novim alatima. Ovaj odeljak daje praktična rešenja za najčešće probleme, kako biste brzo nastavili sa radom. Ako se pojavi greška, počnite ovde: saveti ispod pokrivaju probleme sa kojima se većina korisnika susreće i često mogu rešiti vaš problem bez dodatne pomoći.

### Česti problemi

Ispod su neki od najčešćih problema sa kojima se korisnici susreću, zajedno sa jasnim objašnjenjima i koracima za rešavanje:

1. **Nedostaje SERPAPI_KEY u .env fajlu**
   - Ako vidite grešku `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` fajl ako je potrebno. Ako je vaš ključ ispravan, ali i dalje dobijate ovu grešku, proverite da li vam je besplatni nivo potrošen.

### Debug režim

Po defaultu, aplikacija loguje samo važne informacije. Ako želite da vidite više detalja o tome šta se dešava (na primer, da dijagnostikujete komplikovane probleme), možete uključiti DEBUG režim. Ovo će vam pokazati mnogo više o svakom koraku koji aplikacija preduzima.

**Primer: Normalan izlaz**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Primer: DEBUG izlaz**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Primetite kako DEBUG režim uključuje dodatne linije o HTTP zahtevima, odgovorima i drugim internim detaljima. Ovo može biti veoma korisno za rešavanje problema.

Da biste uključili DEBUG režim, podesite nivo logovanja na DEBUG na početku vašeg `client.py` or `server.py`:

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

## Šta sledi

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне тумачења настала употребом овог превода.