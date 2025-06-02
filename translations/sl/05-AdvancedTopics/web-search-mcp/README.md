<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:28:53+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "sl"
}
-->
# Lesson: Gradnja Web Search MCP strežnika

Ta poglavje prikazuje, kako zgraditi resničnega AI agenta, ki se poveže z zunanjimi API-ji, obravnava različne vrste podatkov, upravlja napake in usklajuje več orodij – vse v produkcijsko pripravljenem formatu. Videli boste:

- **Integracija z zunanjimi API-ji, ki zahtevajo avtentikacijo**
- **Obravnava različnih vrst podatkov z več končnih točk**
- **Robustne strategije za upravljanje napak in beleženje**
- **Usklajevanje več orodij v enem strežniku**

Na koncu boste pridobili praktične izkušnje s vzorci in najboljšimi praksami, ki so ključne za napredne AI in LLM-podprte aplikacije.

## Uvod

V tej lekciji se boste naučili, kako zgraditi napreden MCP strežnik in odjemalca, ki razširjata zmogljivosti LLM z uporabo spletnih podatkov v realnem času preko SerpAPI. To je ključna veščina za razvoj dinamičnih AI agentov, ki dostopajo do aktualnih informacij s spleta.

## Cilji učenja

Do konca te lekcije boste znali:

- Varnostno integrirati zunanje API-je (kot je SerpAPI) v MCP strežnik
- Implementirati več orodij za spletno, novičarsko, produktno iskanje in vprašanja-odgovore
- Parsirati in oblikovati strukturirane podatke za uporabo z LLM
- Učinkovito upravljati napake in omejitve hitrosti API-ja
- Zgraditi in testirati tako avtomatizirane kot interaktivne MCP odjemalce

## Web Search MCP strežnik

Ta del predstavlja arhitekturo in funkcionalnosti Web Search MCP strežnika. Videli boste, kako FastMCP in SerpAPI skupaj razširjata zmogljivosti LLM z realnimi spletnimi podatki.

### Pregled

Implementacija vključuje štiri orodja, ki prikazujejo sposobnost MCP za varno in učinkovito upravljanje različnih zunanjih API-jev:

- **general_search**: za široke spletne rezultate
- **news_search**: za najnovejše naslove novic
- **product_search**: za podatke iz e-trgovine
- **qna**: za kratke odgovore na vprašanja

### Funkcionalnosti
- **Primeri kode**: Vključeni so jezikovno specifični blok kode za Python (z možnostjo enostavne razširitve na druge jezike) z zložljivimi razdelki za preglednost

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

Pred zagonom odjemalca je koristno razumeti, kaj strežnik počne. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Tukaj je kratek primer, kako strežnik definira in registrira orodje:

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

- **Integracija zunanjega API-ja**: prikazuje varno upravljanje API ključev in zunanjih zahtevkov
- **Parsiranje strukturiranih podatkov**: prikazuje, kako spremeniti odgovore API-ja v formate, prijazne za LLM
- **Upravljanje napak**: robustno upravljanje napak z ustreznim beleženjem
- **Interaktivni odjemalec**: vključuje tako avtomatizirane teste kot interaktivni način za testiranje
- **Upravljanje konteksta**: uporablja MCP Context za beleženje in sledenje zahtevkom

## Predpogoji

Pred začetkom poskrbite, da imate okolje pravilno nastavljeno z naslednjimi koraki. Tako boste zagotovili, da so vse odvisnosti nameščene in da so vaši API ključi pravilno konfigurirani za nemoten razvoj in testiranje.

- Python 3.8 ali novejši
- SerpAPI API ključ (prijavite se na [SerpAPI](https://serpapi.com/) - na voljo brezplačna različica)

## Namestitev

Za začetek sledite tem korakom za nastavitev okolja:

1. Namestite odvisnosti z uv (priporočeno) ali pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. V korenski mapi projekta ustvarite datoteko `.env` s svojim SerpAPI ključem:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Uporaba

Web Search MCP strežnik je osrednji del, ki izpostavlja orodja za spletno, novičarsko, produktno iskanje in Q&A z integracijo SerpAPI. Obravnava dohodne zahteve, upravlja API klice, parsira odgovore in vrača strukturirane rezultate odjemalcu.

Celotno implementacijo si lahko ogledate v [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Zagon strežnika

Za zagon MCP strežnika uporabite naslednji ukaz:

```bash
python server.py
```

Strežnik bo tekel kot stdio MCP strežnik, s katerim se lahko odjemalec poveže neposredno.

### Načini odjemalca

Odjemalec (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Zagon odjemalca

Za zagon avtomatiziranih testov (to bo samodejno zagnalo strežnik):

```bash
python client.py
```

Ali pa v interaktivnem načinu:

```bash
python client.py --interactive
```

### Testiranje z različnimi metodami

Obstaja več načinov za testiranje in interakcijo z orodji, ki jih strežnik ponuja, odvisno od vaših potreb in delovnega toka.

#### Pisanje lastnih testnih skript z MCP Python SDK
Lahko tudi ustvarite svoje testne skripte z uporabo MCP Python SDK:

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

V tem kontekstu "testna skripta" pomeni lasten Python program, ki ga napišete kot odjemalca MCP strežnika. Namesto formalnega enotnega testa ta skripta omogoča programatično povezavo s strežnikom, klic katerega koli orodja z izbranimi parametri in pregled rezultatov. Ta pristop je uporaben za:
- Prototipiranje in eksperimentiranje s klici orodij
- Preverjanje odziva strežnika na različne vhodne podatke
- Avtomatizacijo ponavljajočih se klicev orodij
- Gradnjo lastnih potekov dela ali integracij na vrhu MCP strežnika

Testne skripte lahko uporabite za hitro preizkušanje novih poizvedb, odpravljanje napak orodij ali kot izhodišče za bolj napredno avtomatizacijo. Spodaj je primer uporabe MCP Python SDK za ustvarjanje take skripte:

## Opisi orodij

Za izvajanje različnih vrst iskanj in poizvedb lahko uporabite naslednja orodja, ki jih strežnik ponuja. Vsako orodje je opisano spodaj z njegovimi parametri in primeri uporabe.

Ta del ponuja podrobnosti o posameznih orodjih in njihovih parametrih.

### general_search

Izvede splošno spletno iskanje in vrne oblikovane rezultate.

**Kako klicati to orodje:**

`general_search` lahko pokličete iz svoje skripte z MCP Python SDK ali interaktivno preko Inspectorja ali interaktivnega načina odjemalca. Tukaj je primer kode z uporabo SDK:

<details>
<summary>Primer v Pythonu</summary>

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

Alternativno, v interaktivnem načinu izberite `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): iskalni poizvedek

**Primer zahteve:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Išče nedavne novičarske članke, povezane s poizvedbo.

**Kako klicati to orodje:**

`news_search` lahko pokličete iz svoje skripte z MCP Python SDK ali interaktivno preko Inspectorja ali interaktivnega načina odjemalca. Tukaj je primer kode z uporabo SDK:

<details>
<summary>Primer v Pythonu</summary>

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

Alternativno, v interaktivnem načinu izberite `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): iskalni poizvedek

**Primer zahteve:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Išče izdelke, ki ustrezajo poizvedbi.

**Kako klicati to orodje:**

`product_search` lahko pokličete iz svoje skripte z MCP Python SDK ali interaktivno preko Inspectorja ali interaktivnega načina odjemalca. Tukaj je primer kode z uporabo SDK:

<details>
<summary>Primer v Pythonu</summary>

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

Alternativno, v interaktivnem načinu izberite `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): iskalni poizvedek za izdelke

**Primer zahteve:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Pridobi neposredne odgovore na vprašanja iz iskalnikov.

**Kako klicati to orodje:**

`qna` lahko pokličete iz svoje skripte z MCP Python SDK ali interaktivno preko Inspectorja ali interaktivnega načina odjemalca. Tukaj je primer kode z uporabo SDK:

<details>
<summary>Primer v Pythonu</summary>

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

Alternativno, v interaktivnem načinu izberite `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): vprašanje, na katerega želite odgovor

**Primer zahteve:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Podrobnosti kode

Ta del ponuja izseke kode in reference za implementacije strežnika in odjemalca.

<details>
<summary>Python</summary>

Poglejte [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) za celotne podrobnosti implementacije.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Napredni koncepti v tej lekciji

Preden začnete z gradnjo, je tukaj nekaj pomembnih naprednih konceptov, ki se bodo pojavljali skozi to poglavje. Razumevanje teh vam bo pomagalo slediti, tudi če so vam novi:

- **Usklajevanje več orodij**: pomeni, da v enem MCP strežniku poganjate več različnih orodij (kot so spletno iskanje, novičarsko iskanje, iskanje izdelkov in Q&A). To omogoča vašemu strežniku, da obravnava različne naloge, ne le eno.
- **Upravljanje omejitev hitrosti API-ja**: mnogi zunanji API-ji (kot SerpAPI) omejujejo, koliko zahtev lahko naredite v določenem času. Dobra koda preverja te omejitve in jih obravnava na primeren način, da aplikacija ne pade, če presežete limit.
- **Parsiranje strukturiranih podatkov**: odgovori API-jev so pogosto kompleksni in gnezdeni. Ta koncept pomeni pretvorbo teh odgovorov v čiste, enostavne formate, prijazne za LLM ali druge programe.
- **Obnavljanje po napakah**: včasih gre kaj narobe – morda omrežje ne deluje ali API ne vrne pričakovanih podatkov. Obnavljanje po napakah pomeni, da vaša koda zna te težave obravnavati in še vedno dati uporabne povratne informacije, namesto da bi padla.
- **Preverjanje parametrov**: pomeni, da preverite, ali so vsi vhodi v vaša orodja pravilni in varni za uporabo. Vključuje nastavljanje privzetih vrednosti in preverjanje tipov, kar pomaga preprečiti napake in zmedo.

Ta del vam bo pomagal diagnosticirati in rešiti pogoste težave, s katerimi se lahko srečate pri delu z Web Search MCP strežnikom. Če naletite na napake ali nepričakovano vedenje, ta razdelek ponuja rešitve za najpogostejše težave. Preden poiščete dodatno pomoč, si oglejte te nasvete – pogosto hitro odpravijo težave.

## Odpravljanje težav

Pri delu z Web Search MCP strežnikom se lahko občasno pojavijo težave – to je normalno pri razvoju z zunanjimi API-ji in novimi orodji. Ta del ponuja praktične rešitve za najpogostejše težave, da boste hitro spet na pravi poti. Če naletite na napako, začnite tukaj: spodnji nasveti naslovijo težave, s katerimi se večina uporabnikov srečuje, in pogosto rešijo problem brez dodatne pomoči.

### Pogoste težave

Spodaj so najpogostejši problemi, s katerimi se srečujejo uporabniki, skupaj s pojasnili in koraki za rešitev:

1. **Manjkajoči SERPAPI_KEY v datoteki .env**
   - Če vidite napako `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` datoteko, jo ustvarite, če je še ni. Če je ključ pravilen, a napaka ostaja, preverite, ali ste porabili kvoto brezplačnega paketa.

### Način za odpravljanje napak (Debug mode)

Privzeto aplikacija beleži samo pomembne informacije. Če želite videti več podrobnosti o dogajanju (na primer za lažje diagnosticiranje težav), lahko omogočite način DEBUG. Ta vam bo prikazal veliko več o vsakem koraku, ki ga aplikacija izvaja.

**Primer: običajen izpis**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Primer: izpis v načinu DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Opazite, da način DEBUG vključuje dodatne vrstice o HTTP zahtevah, odgovorih in drugih notranjih podrobnostih. To je lahko zelo koristno pri odpravljanju težav.

Za omogočanje načina DEBUG nastavite nivo beleženja na DEBUG na vrhu vaše datoteke `client.py` or `server.py`:

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

## Kaj sledi

- [6. Prispevki skupnosti](../../06-CommunityContributions/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatski prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.