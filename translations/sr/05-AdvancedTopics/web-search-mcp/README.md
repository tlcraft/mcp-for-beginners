<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T19:36:51+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "sr"
}
-->
# Lekcija: Izgradnja MCP servera za pretragu na webu

Ovo poglavlje prikazuje kako napraviti pravog AI agenta koji se integriše sa eksternim API-jima, rukuje različitim tipovima podataka, upravlja greškama i koordinira više alata — sve u formatu spremnom za produkciju. Videćete:

- **Integraciju sa eksternim API-jima koji zahtevaju autentifikaciju**
- **Rukovanje različitim tipovima podataka sa više izvora**
- **Robusne strategije za upravljanje greškama i logovanje**
- **Orkestraciju više alata u jednom serveru**

Na kraju, steći ćete praktično iskustvo sa obrascima i najboljim praksama koje su ključne za napredne AI i LLM aplikacije.

## Uvod

U ovoj lekciji naučićete kako da napravite napredni MCP server i klijenta koji proširuju LLM mogućnosti sa podacima sa interneta u realnom vremenu koristeći SerpAPI. Ovo je ključna veština za razvoj dinamičnih AI agenata koji mogu pristupiti najnovijim informacijama sa weba.

## Ciljevi učenja

Na kraju ove lekcije moći ćete da:

- Sigurno integrišete spoljne API-je (kao što je SerpAPI) u MCP server
- Implementirate više alata za pretragu weba, vesti, proizvoda i Q&A
- Parsirate i formatirate strukturirane podatke za LLM
- Efikasno rukujete greškama i upravljate ograničenjima API-ja
- Pravite i testirate automatizovane i interaktivne MCP klijente

## MCP server za pretragu na webu

Ovaj deo uvodi arhitekturu i funkcije MCP servera za pretragu na webu. Videćete kako se FastMCP i SerpAPI koriste zajedno da prošire LLM mogućnosti sa podacima sa interneta u realnom vremenu.

### Pregled

Implementacija sadrži četiri alata koja prikazuju sposobnost MCP-a da sigurno i efikasno rukuje raznovrsnim zadacima pokretanim eksternim API-jima:

- **general_search**: Za široke web rezultate
- **news_search**: Za najnovije naslove
- **product_search**: Za podatke o proizvodima iz e-trgovine
- **qna**: Za pitanja i odgovore

### Karakteristike
- **Primeri koda**: Uključuje blokove koda specifične za Python (i lako se može proširiti na druge jezike) sa sklopivim sekcijama radi preglednosti

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

Pre nego što pokrenete klijenta, korisno je razumeti šta server radi. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

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

- **Integracija eksternih API-ja**: Prikazuje sigurno rukovanje API ključevima i spoljnim zahtevima
- **Parsiranje strukturiranih podataka**: Pokazuje kako se API odgovori transformišu u formate pogodne za LLM
- **Upravljanje greškama**: Robusno rukovanje greškama sa odgovarajućim logovanjem
- **Interaktivni klijent**: Uključuje automatizovane testove i interaktivni režim za testiranje
- **Upravljanje kontekstom**: Koristi MCP Context za logovanje i praćenje zahteva

## Preduslovi

Pre nego što počnete, proverite da li je vaše okruženje pravilno podešeno prateći sledeće korake. Ovo će osigurati da su sve zavisnosti instalirane i da su vaši API ključevi pravilno konfigurisani za nesmetan razvoj i testiranje.

- Python 3.8 ili noviji
- SerpAPI API ključ (Registrujte se na [SerpAPI](https://serpapi.com/) - dostupan je besplatni nivo)

## Instalacija

Da biste započeli, sledite ove korake za podešavanje okruženja:

1. Instalirajte zavisnosti koristeći uv (preporučeno) ili pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Kreirajte `.env` fajl u korenu projekta sa vašim SerpAPI ključem:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Upotreba

MCP server za pretragu na webu je osnovni deo koji izlaže alate za pretragu weba, vesti, proizvoda i Q&A integracijom sa SerpAPI-jem. On prima zahteve, upravlja API pozivima, parsira odgovore i vraća strukturirane rezultate klijentu.

Puni kod možete pogledati u [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Pokretanje servera

Da biste pokrenuli MCP server, koristite sledeću komandu:

```bash
python server.py
```

Server će raditi kao stdio baziran MCP server kojem se klijent može direktno povezati.

### Režimi rada klijenta

Klijent (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Pokretanje klijenta

Za pokretanje automatizovanih testova (ovo će automatski pokrenuti server):

```bash
python client.py
```

Ili pokrenite u interaktivnom režimu:

```bash
python client.py --interactive
```

### Testiranje različitim metodama

Postoji nekoliko načina da testirate i komunicirate sa alatima koje server nudi, u zavisnosti od vaših potreba i radnog toka.

#### Pisanje prilagođenih test skripti sa MCP Python SDK-om
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

U ovom kontekstu, "test skripta" znači prilagođeni Python program koji pišete da biste delovali kao klijent MCP serveru. Umesto formalnog jedinicnog testa, ova skripta vam omogućava da programatski povežete sa serverom, pozovete bilo koji od njegovih alata sa parametrima po izboru i pregledate rezultate. Ovaj pristup je koristan za:
- Prototipizaciju i eksperimentisanje sa pozivima alata
- Validaciju kako server reaguje na različite ulaze
- Automatizaciju ponovljenih poziva alata
- Izgradnju sopstvenih radnih tokova ili integracija na vrhu MCP servera

Test skripte možete koristiti da brzo isprobate nove upite, debagujete ponašanje alata ili čak kao polaznu tačku za napredniju automatizaciju. Ispod je primer kako koristiti MCP Python SDK za kreiranje takve skripte:

## Opisi alata

Možete koristiti sledeće alate koje server pruža za različite vrste pretraga i upita. Svaki alat je opisan sa svojim parametrima i primerom upotrebe.

Ovaj deo daje detalje o svakom dostupnom alatu i njegovim parametrima.

### general_search

Izvodi opštu pretragu na webu i vraća formatirane rezultate.

**Kako pozvati ovaj alat:**

Možete pozvati `general_search` iz svoje skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspektor ili interaktivni režim klijenta. Evo primera koda koristeći SDK:

<details>
<summary>Primer u Pythonu</summary>

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

Alternativno, u interaktivnom režimu, izaberite `general_search` from the menu and enter your query when prompted.

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

Možete pozvati `news_search` iz svoje skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspektor ili interaktivni režim klijenta. Evo primera koda koristeći SDK:

<details>
<summary>Primer u Pythonu</summary>

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

Alternativno, u interaktivnom režimu, izaberite `news_search` from the menu and enter your query when prompted.

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

Možete pozvati `product_search` iz svoje skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspektor ili interaktivni režim klijenta. Evo primera koda koristeći SDK:

<details>
<summary>Primer u Pythonu</summary>

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

Alternativno, u interaktivnom režimu, izaberite `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Upit za pretragu proizvoda

**Primer zahteva:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Daje direktne odgovore na pitanja sa pretraživača.

**Kako pozvati ovaj alat:**

Možete pozvati `qna` iz svoje skripte koristeći MCP Python SDK, ili interaktivno koristeći Inspektor ili interaktivni režim klijenta. Evo primera koda koristeći SDK:

<details>
<summary>Primer u Pythonu</summary>

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

Alternativno, u interaktivnom režimu, izaberite `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Pitanje na koje tražite odgovor

**Primer zahteva:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Detalji koda

Ovaj deo pruža isječke koda i reference za implementacije servera i klijenta.

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

Pre nego što počnete sa izgradnjom, evo nekoliko važnih naprednih koncepata koji će se pojavljivati kroz ovo poglavlje. Razumevanje ovih pomoći će vam da lakše pratite, čak i ako su vam novi:

- **Orkestracija više alata**: Ovo znači da u jednom MCP serveru pokrećete više različitih alata (kao što su pretraga weba, vesti, proizvoda i Q&A). To omogućava serveru da rukuje raznovrsnim zadacima, ne samo jednim.
- **Upravljanje ograničenjima API-ja**: Mnogi eksterni API-ji (kao SerpAPI) ograničavaju koliko zahteva možete poslati u određenom vremenu. Dobar kod proverava ta ograničenja i rukuje njima na odgovarajući način, tako da aplikacija ne prestane sa radom ako dostignete limit.
- **Parsiranje strukturiranih podataka**: Odgovori API-ja su često složeni i ugnježdeni. Ovaj koncept se odnosi na pretvaranje tih odgovora u čiste, lako upotrebljive formate koji su pogodni za LLM ili druge programe.
- **Oporavak od grešaka**: Ponekad stvari krenu po zlu — možda mreža zakaže, ili API ne vrati očekivane podatke. Oporavak od grešaka znači da vaš kod može da se nosi sa tim problemima i da i dalje daje korisne povratne informacije, umesto da se sruši.
- **Validacija parametara**: Ovo znači proveru da li su svi ulazi za vaše alate ispravni i bezbedni za upotrebu. Uključuje postavljanje podrazumevanih vrednosti i proveru tipova, što pomaže u sprečavanju grešaka i zabune.

Ovaj deo će vam pomoći da dijagnostikujete i rešite česte probleme na koje možete naići dok radite sa MCP serverom za pretragu na webu. Ako naiđete na greške ili neočekivano ponašanje, ovaj odeljak sa savetima pruža rešenja za najčešće probleme. Pregledajte ove savete pre nego što potražite dodatnu pomoć — često brzo rešavaju problem.

## Rešavanje problema

Prilikom rada sa MCP serverom za pretragu na webu, povremeno možete naići na probleme — to je normalno prilikom razvoja sa eksternim API-jima i novim alatima. Ovaj deo pruža praktična rešenja za najčešće probleme, kako biste se brzo vratili na pravi put. Ako naiđete na grešku, počnite ovde: sledeći saveti pokrivaju probleme sa kojima se većina korisnika susreće i često mogu rešiti vaš problem bez dodatne pomoći.

### Česti problemi

Ispod su neki od najčešćih problema sa kojima se korisnici susreću, zajedno sa jasnim objašnjenjima i koracima za rešavanje:

1. **Nedostaje SERPAPI_KEY u .env fajlu**
   - Ako vidite grešku `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `, proverite da li imate `.env` fajl sa vašim ključem. Ako je ključ ispravan, a greška se i dalje pojavljuje, proverite da li vam je istekao besplatni nivo kvote.

### Debug režim

Po defaultu, aplikacija loguje samo važne informacije. Ako želite da vidite više detalja o tome šta se dešava (na primer, da biste dijagnostikovali komplikovane probleme), možete uključiti DEBUG režim. On će prikazati mnogo više o svakom koraku koji aplikacija preduzima.

**Primer: Normalni izlaz**
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

Da biste uključili DEBUG režim, podesite nivo logovanja na DEBUG na vrhu vašeg `client.py` or `server.py`:

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

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI prevodilačke usluge [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo tačnosti, imajte na umu da automatski prevodi mogu sadržati greške ili netačnosti. Originalni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja mogu proisteći iz korišćenja ovog prevoda.