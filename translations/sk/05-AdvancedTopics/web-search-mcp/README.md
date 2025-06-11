<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T16:21:08+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "sk"
}
-->
# Lekcia: Vytvorenie MCP servera pre webové vyhľadávanie

Táto kapitola ukazuje, ako vytvoriť reálneho AI agenta, ktorý integruje externé API, spracováva rôzne typy dát, zvláda chyby a koordinuje viacero nástrojov – to všetko vo formáte pripravenom na produkciu. Uvidíte:

- **Integráciu s externými API vyžadujúcimi autentifikáciu**
- **Spracovanie rôznych typov dát z viacerých endpointov**
- **Robustné riešenie chýb a stratégie logovania**
- **Koordináciu viacerých nástrojov v jednom serveri**

Na konci budete mať praktické skúsenosti s vzormi a osvedčenými postupmi, ktoré sú kľúčové pre pokročilé AI a LLM aplikácie.

## Úvod

V tejto lekcii sa naučíte, ako vytvoriť pokročilý MCP server a klienta, ktorý rozširuje schopnosti LLM o dáta z webu v reálnom čase pomocou SerpAPI. Táto zručnosť je kľúčová pre vývoj dynamických AI agentov, ktorí majú prístup k aktuálnym informáciám z internetu.

## Ciele učenia

Na konci tejto lekcie budete vedieť:

- Bezpečne integrovať externé API (napr. SerpAPI) do MCP servera
- Implementovať viacero nástrojov pre vyhľadávanie na webe, v správach, produktoch a pre Q&A
- Parsovať a formátovať štruktúrované dáta pre LLM
- Efektívne riešiť chyby a spravovať limity API
- Vytvárať a testovať automatizovaných aj interaktívnych MCP klientov

## Web Search MCP Server

Táto časť predstavuje architektúru a funkcie Web Search MCP servera. Uvidíte, ako FastMCP a SerpAPI spolupracujú na rozšírení schopností LLM o dáta z webu v reálnom čase.

### Prehľad

Táto implementácia obsahuje štyri nástroje, ktoré demonštrujú schopnosť MCP bezpečne a efektívne spracovať rôznorodé úlohy založené na externých API:

- **general_search**: Pre všeobecné webové výsledky
- **news_search**: Pre aktuálne správy
- **product_search**: Pre e-commerce dáta
- **qna**: Pre otázky a odpovede

### Funkcie
- **Príklady kódu**: Obsahuje jazykovo špecifické bloky kódu pre Python (a ľahko rozšíriteľné na iné jazyky) s kolapsovateľnými sekciami pre lepšiu prehľadnosť

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

Pred spustením klienta je užitočné pochopiť, čo server robí. Pozrite si [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Tu je stručný príklad, ako server definuje a registruje nástroj:

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

- **Integrácia externého API**: Ukazuje bezpečné zaobchádzanie s API kľúčmi a externými požiadavkami
- **Parsovanie štruktúrovaných dát**: Ukazuje, ako pretransformovať odpovede API do formátu vhodného pre LLM
- **Riešenie chýb**: Robustné riešenie chýb s adekvátnym logovaním
- **Interaktívny klient**: Obsahuje automatizované testy aj interaktívny režim na testovanie
- **Správa kontextu**: Využíva MCP Context na logovanie a sledovanie požiadaviek

## Predpoklady

Pred začatím si uistite, že máte správne nastavené prostredie podľa týchto krokov. Zabezpečí to, že všetky závislosti sú nainštalované a API kľúče správne nakonfigurované pre bezproblémový vývoj a testovanie.

- Python 3.8 alebo novší
- SerpAPI API kľúč (zaregistrujte sa na [SerpAPI](https://serpapi.com/) – dostupná je aj bezplatná vrstva)

## Inštalácia

Na začiatok postupujte podľa týchto krokov na nastavenie prostredia:

1. Nainštalujte závislosti pomocou uv (odporúčané) alebo pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Vytvorte `.env` súbor v koreňovom adresári projektu s vaším SerpAPI kľúčom:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Použitie

Web Search MCP Server je jadrom, ktoré sprístupňuje nástroje pre webové, spravodajské, produktové vyhľadávanie a Q&A integráciou so SerpAPI. Spracováva prichádzajúce požiadavky, riadi volania API, parsuje odpovede a vracia štruktúrované výsledky klientovi.

Celú implementáciu nájdete v [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Spustenie servera

Na spustenie MCP servera použite tento príkaz:

```bash
python server.py
```

Server pobieha ako stdio-based MCP server, ku ktorému sa klient môže priamo pripojiť.

### Režimy klienta

Klient (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Spustenie klienta

Na spustenie automatizovaných testov (tým sa automaticky spustí aj server):

```bash
python client.py
```

Alebo spustite interaktívny režim:

```bash
python client.py --interactive
```

### Testovanie rôznymi spôsobmi

Existuje niekoľko možností, ako testovať a interagovať s nástrojmi servera podľa vašich potrieb a pracovného toku.

#### Písanie vlastných testovacích skriptov s MCP Python SDK
Môžete si tiež vytvoriť vlastné testovacie skripty pomocou MCP Python SDK:

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

V tomto kontexte „testovací skript“ znamená vlastný Python program, ktorý píšete ako klienta MCP servera. Namiesto formálneho unit testu tento skript umožňuje programaticky sa pripojiť k serveru, volať jeho nástroje s parametrami podľa vlastného výberu a skúmať výsledky. Tento prístup je užitočný pre:
- Prototypovanie a experimentovanie s volaniami nástrojov
- Overovanie reakcií servera na rôzne vstupy
- Automatizáciu opakovaných volaní nástrojov
- Vytváranie vlastných pracovných tokov alebo integrácií nad MCP serverom

Testovacie skripty môžete použiť na rýchle skúšanie nových dopytov, ladenie správania nástrojov alebo ako východiskový bod pre pokročilejšiu automatizáciu. Nižšie je príklad, ako použiť MCP Python SDK na vytvorenie takéhoto skriptu:

## Popisy nástrojov

Môžete použiť nasledujúce nástroje poskytované serverom na vykonávanie rôznych typov vyhľadávaní a dotazov. Každý nástroj je popísaný spolu s parametrami a príkladmi použitia.

Táto sekcia poskytuje detaily o dostupných nástrojoch a ich parametroch.

### general_search

Vykonáva všeobecné webové vyhľadávanie a vracia formátované výsledky.

**Ako volať tento nástroj:**

`general_search` môžete volať zo svojho skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

<details>
<summary>Python príklad</summary>

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

Prípadne v interaktívnom režime vyberte `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Vyhľadávací dotaz

**Príklad požiadavky:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Vyhľadáva aktuálne spravodajské články súvisiace s dotazom.

**Ako volať tento nástroj:**

`news_search` môžete volať zo svojho skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

<details>
<summary>Python príklad</summary>

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

Prípadne v interaktívnom režime vyberte `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Vyhľadávací dotaz

**Príklad požiadavky:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Vyhľadáva produkty zodpovedajúce dotazu.

**Ako volať tento nástroj:**

`product_search` môžete volať zo svojho skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

<details>
<summary>Python príklad</summary>

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

Prípadne v interaktívnom režime vyberte `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Vyhľadávací dotaz na produkt

**Príklad požiadavky:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Získava priame odpovede na otázky z vyhľadávačov.

**Ako volať tento nástroj:**

`qna` môžete volať zo svojho skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

<details>
<summary>Python príklad</summary>

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

Prípadne v interaktívnom režime vyberte `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Otázka, na ktorú chcete nájsť odpoveď

**Príklad požiadavky:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Detaily kódu

Táto sekcia poskytuje úryvky kódu a odkazy na implementácie servera a klienta.

<details>
<summary>Python</summary>

Pozrite si [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) pre kompletné detaily implementácie.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Pokročilé koncepty v tejto lekcii

Predtým, než začnete s vývojom, tu je niekoľko dôležitých pokročilých konceptov, ktoré sa v tejto kapitole objavia. Ich pochopenie vám pomôže lepšie sledovať obsah, aj keď ste s nimi zatiaľ nepracovali:

- **Koordinácia viacerých nástrojov**: Znamená to spúšťať niekoľko rôznych nástrojov (napr. webové vyhľadávanie, správy, produkty a Q&A) v rámci jedného MCP servera. Umožňuje to serveru spracovávať rôzne úlohy, nielen jednu.
- **Riešenie limitov API**: Mnohé externé API (napr. SerpAPI) obmedzujú počet požiadaviek za určitý čas. Kvalitný kód tieto limity kontroluje a zvláda ich elegantne, aby aplikácia neprestala fungovať, ak limit dosiahnete.
- **Parsovanie štruktúrovaných dát**: Odpovede API sú často zložité a vnorené. Tento koncept znamená premeniť ich na čisté a ľahko použiteľné formáty vhodné pre LLM alebo iné programy.
- **Obnova po chybe**: Niekedy sa niečo pokazí – napríklad zlyhá sieť alebo API nevráti očakávané dáta. Obnova po chybe znamená, že váš kód dokáže tieto problémy zvládnuť a stále poskytnúť užitočnú spätnú väzbu namiesto pádu aplikácie.
- **Validácia parametrov**: Znamená to overiť, že všetky vstupy do vašich nástrojov sú správne a bezpečné na použitie. Zahŕňa nastavenie predvolených hodnôt a kontrolu typov, čo pomáha predchádzať chybám a nejasnostiam.

Táto sekcia vám pomôže diagnostikovať a vyriešiť bežné problémy, na ktoré môžete naraziť pri práci s Web Search MCP Serverom. Ak narazíte na chyby alebo neočakávané správanie, táto sekcia poskytuje riešenia najčastejších problémov. Prezrite si tieto tipy predtým, než požiadate o ďalšiu pomoc – často vyriešia problém rýchlo.

## Riešenie problémov

Pri práci s Web Search MCP Serverom sa občas môžete stretnúť s problémami – je to bežné pri vývoji s externými API a novými nástrojmi. Táto sekcia ponúka praktické riešenia najčastejších problémov, aby ste sa mohli rýchlo vrátiť k práci. Ak narazíte na chybu, začnite tu: tipy nižšie sa venujú problémom, s ktorými sa stretáva väčšina používateľov, a často vám pomôžu vyriešiť problém bez ďalšej pomoci.

### Bežné problémy

Nižšie sú niektoré z najčastejších problémov, s ktorými sa používatelia stretávajú, spolu s jasnými vysvetleniami a krokmi na ich vyriešenie:

1. **Chýbajúci SERPAPI_KEY v .env súbore**
   - Ak sa vám zobrazí chyba `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``, vytvorte `.env` súbor, ak ešte neexistuje. Ak máte kľúč správny, ale chyba pretrváva, skontrolujte, či vám nevypršal bezplatný limit.

### Režim ladenia (Debug Mode)

Štandardne aplikácia loguje len dôležité informácie. Ak chcete vidieť viac detailov o tom, čo sa deje (napríklad na diagnostiku zložitých problémov), môžete zapnúť režim DEBUG. Zobrazí vám to podrobnejšie informácie o každom kroku, ktorý aplikácia vykonáva.

**Príklad: bežný výstup**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Príklad: DEBUG výstup**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Všimnite si, že režim DEBUG obsahuje ďalšie riadky o HTTP požiadavkách, odpovediach a ďalších interných detailoch. To môže byť veľmi užitočné pri riešení problémov.

Na zapnutie režimu DEBUG nastavte úroveň logovania na DEBUG v hornej časti `client.py` or `server.py`:

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

## Čo ďalej

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.