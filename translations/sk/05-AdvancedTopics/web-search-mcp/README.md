<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T19:31:17+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "sk"
}
-->
# Lesson: Vytváranie MCP servera pre webové vyhľadávanie

Táto kapitola ukazuje, ako vytvoriť reálneho AI agenta, ktorý integruje externé API, spracováva rôzne typy dát, rieši chyby a koordinuje viacero nástrojov – to všetko v produkčne pripravenom formáte. Uvidíte:

- **Integráciu s externými API vyžadujúcimi autentifikáciu**
- **Spracovanie rôznych dátových typov z viacerých endpointov**
- **Robustné riešenie chýb a stratégie logovania**
- **Koordináciu viacerých nástrojov v jednom serveri**

Na konci budete mať praktické skúsenosti s patternmi a osvedčenými postupmi, ktoré sú nevyhnutné pre pokročilé AI a LLM aplikácie.

## Úvod

V tejto lekcii sa naučíte, ako vytvoriť pokročilý MCP server a klienta, ktorý rozširuje schopnosti LLM o dáta z webu v reálnom čase pomocou SerpAPI. Toto je kľúčová zručnosť pre vývoj dynamických AI agentov, ktorí dokážu pristupovať k aktuálnym informáciám z webu.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Bezpečne integrovať externé API (napr. SerpAPI) do MCP servera
- Implementovať viacero nástrojov pre webové, spravodajské, produktové vyhľadávanie a Q&A
- Parsovať a formátovať štruktúrované dáta pre LLM
- Efektívne riešiť chyby a spravovať limity API volaní
- Vytvárať a testovať automatizovaných aj interaktívnych MCP klientov

## Web Search MCP Server

Táto sekcia predstavuje architektúru a funkcie Web Search MCP Servera. Uvidíte, ako FastMCP a SerpAPI spolupracujú na rozšírení schopností LLM o dáta z webu v reálnom čase.

### Prehľad

Táto implementácia obsahuje štyri nástroje, ktoré demonštrujú schopnosť MCP bezpečne a efektívne spracovať rôznorodé úlohy založené na externých API:

- **general_search**: Pre široké výsledky z webu
- **news_search**: Pre najnovšie správy
- **product_search**: Pre e-commerce dáta
- **qna**: Pre otázky a odpovede

### Funkcie
- **Príklady kódu**: Obsahuje jazykovo špecifické bloky pre Python (a ľahko rozšíriteľné na iné jazyky) s možnosťou zbalenia pre prehľadnosť

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

Tu je krátky príklad, ako server definuje a registruje nástroj:

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

- **Integrácia externého API**: Ukazuje bezpečné spracovanie API kľúčov a externých požiadaviek
- **Parsovanie štruktúrovaných dát**: Ukazuje, ako transformovať odpovede API do formátov vhodných pre LLM
- **Riešenie chýb**: Robustné spracovanie chýb s adekvátnym logovaním
- **Interaktívny klient**: Obsahuje automatizované testy aj interaktívny režim na testovanie
- **Správa kontextu**: Využíva MCP Context pre logovanie a sledovanie požiadaviek

## Predpoklady

Pred začatím si overte, že máte správne nastavené prostredie podľa týchto krokov. Tým zabezpečíte, že všetky závislosti sú nainštalované a API kľúče sú správne nakonfigurované pre plynulý vývoj a testovanie.

- Python 3.8 alebo novší
- SerpAPI API kľúč (Registrácia na [SerpAPI](https://serpapi.com/) – dostupná aj bezplatná úroveň)

## Inštalácia

Na začiatok postupujte podľa týchto krokov pre nastavenie prostredia:

1. Nainštalujte závislosti pomocou uv (odporúčané) alebo pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Vytvorte `.env` súbor v koreňovom adresári projektu so svojím SerpAPI kľúčom:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Použitie

Web Search MCP Server je jadro, ktoré poskytuje nástroje pre vyhľadávanie na webe, správy, produktové vyhľadávanie a Q&A integráciou so SerpAPI. Spracováva prichádzajúce požiadavky, riadi volania API, parsuje odpovede a vracia štruktúrované výsledky klientovi.

Celú implementáciu nájdete v [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Spustenie servera

Pre spustenie MCP servera použite nasledujúci príkaz:

```bash
python server.py
```

Server bude bežať ako stdio-based MCP server, ku ktorému sa klient môže priamo pripojiť.

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

Existuje niekoľko možností, ako testovať a pracovať s nástrojmi poskytovanými serverom podľa vašich potrieb a pracovného toku.

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

V tomto kontexte „testovací skript“ znamená vlastný Python program, ktorý píšete ako klienta pre MCP server. Namiesto formálneho unit testu tento skript umožňuje programovo sa pripojiť k serveru, volať jeho nástroje s vybranými parametrami a kontrolovať výsledky. Tento prístup je užitočný pre:
- Prototypovanie a experimentovanie s volaniami nástrojov
- Overovanie, ako server reaguje na rôzne vstupy
- Automatizáciu opakovaných volaní nástrojov
- Vytváranie vlastných workflow alebo integrácií nad MCP serverom

Testovacie skripty môžete použiť na rýchle vyskúšanie nových dotazov, ladenie správania nástrojov alebo ako východiskový bod pre pokročilejšiu automatizáciu. Nižšie je príklad použitia MCP Python SDK na vytvorenie takéhoto skriptu:

## Popisy nástrojov

Môžete použiť nasledujúce nástroje poskytované serverom na vykonávanie rôznych typov vyhľadávania a dopytov. Každý nástroj je popísaný spolu s jeho parametrami a príkladmi použitia.

Táto sekcia obsahuje podrobnosti o jednotlivých dostupných nástrojoch a ich parametroch.

### general_search

Vykonáva všeobecné webové vyhľadávanie a vracia naformátované výsledky.

**Ako volať tento nástroj:**

`general_search` môžete volať z vlastného skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

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

Alternatívne v interaktívnom režime vyberte `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Vyhľadávací dotaz

**Príklad požiadavky:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Vyhľadáva najnovšie správy súvisiace s dotazom.

**Ako volať tento nástroj:**

`news_search` môžete volať z vlastného skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

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

Alternatívne v interaktívnom režime vyberte `news_search` from the menu and enter your query when prompted.

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

`product_search` môžete volať z vlastného skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

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

Alternatívne v interaktívnom režime vyberte `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Dotaz na vyhľadávanie produktu

**Príklad požiadavky:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Získava priame odpovede na otázky z vyhľadávačov.

**Ako volať tento nástroj:**

`qna` môžete volať z vlastného skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

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

Alternatívne v interaktívnom režime vyberte `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Otázka, na ktorú chcete nájsť odpoveď

**Príklad požiadavky:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Detaily kódu

Táto sekcia obsahuje úryvky kódu a odkazy na implementácie servera a klienta.

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

Pred začiatkom vývoja si prejdeme niekoľko dôležitých pokročilých konceptov, ktoré sa budú v celej kapitole objavovať. Ich pochopenie vám pomôže lepšie sledovať obsah, aj keď s nimi ešte nemáte skúsenosti:

- **Koordinácia viacerých nástrojov**: Znamená to spúšťanie viacerých rôznych nástrojov (napr. webové vyhľadávanie, správy, produktové vyhľadávanie a Q&A) v jednom MCP serveri. Umožňuje serveru zvládať rôzne úlohy, nielen jednu.
- **Riešenie limitov API volaní**: Mnohé externé API (napr. SerpAPI) obmedzujú počet požiadaviek za určitý čas. Kvalitný kód tieto limity kontroluje a spracováva ich šetrne, aby aplikácia neprestala fungovať pri dosiahnutí limitu.
- **Parsovanie štruktúrovaných dát**: Odpovede API sú často zložité a vnorené. Tento koncept znamená pretransformovanie týchto odpovedí do čistých a ľahko použiteľných formátov vhodných pre LLM alebo iné programy.
- **Obnova po chybe**: Niekedy sa niečo pokazí – napríklad sieť zlyhá alebo API nevráti očakávané dáta. Obnova po chybe znamená, že kód tieto problémy zvládne a poskytne užitočné informácie namiesto pádu aplikácie.
- **Validácia parametrov**: Znamená overovanie, že všetky vstupy do nástrojov sú správne a bezpečné na použitie. Zahŕňa nastavenie predvolených hodnôt a kontrolu typov, čo pomáha predchádzať chybám a nejasnostiam.

Táto sekcia vám pomôže diagnostikovať a vyriešiť bežné problémy, ktoré môžete stretnúť pri práci s Web Search MCP Serverom. Ak narazíte na chyby alebo neočakávané správanie, táto sekcia poskytuje riešenia najčastejších problémov. Prezrite si tieto tipy predtým, než požiadate o ďalšiu pomoc – často rýchlo vyriešia problém.

## Riešenie problémov

Pri práci s Web Search MCP Serverom sa občas môžu vyskytnúť problémy – to je bežné pri vývoji s externými API a novými nástrojmi. Táto sekcia ponúka praktické riešenia najčastejších problémov, aby ste sa mohli rýchlo vrátiť k práci. Ak narazíte na chybu, začnite tu: tipy nižšie riešia problémy, s ktorými sa stretáva väčšina používateľov, a často vyriešia váš problém bez potreby ďalšej pomoci.

### Bežné problémy

Nižšie sú uvedené niektoré z najčastejších problémov používateľov spolu s jasným vysvetlením a krokmi na ich vyriešenie:

1. **Chýbajúci SERPAPI_KEY v .env súbore**
   - Ak sa zobrazí chyba `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` súbor vytvorte, ak ešte neexistuje. Ak je kľúč správny, no chyba pretrváva, skontrolujte, či vám nevypršal limit bezplatnej úrovne.

### Režim ladenia (Debug Mode)

Štandardne aplikácia loguje iba dôležité informácie. Ak chcete vidieť viac detailov o tom, čo sa deje (napríklad pre diagnostiku zložitejších problémov), môžete zapnúť režim DEBUG. Ten zobrazí oveľa viac informácií o každom kroku aplikácie.

**Príklad: bežný výstup**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Príklad: výstup v režime DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Všimnite si, že režim DEBUG obsahuje ďalšie riadky o HTTP požiadavkách, odpovediach a iných interných detailoch. To môže byť veľmi užitočné pri riešení problémov.

Pre zapnutie režimu DEBUG nastavte úroveň logovania na DEBUG v hornej časti `client.py` or `server.py`:

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

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, majte prosím na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.