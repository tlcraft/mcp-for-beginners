<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T19:27:28+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "hu"
}
-->
# Lesson: Web Search MCP szerver építése

Ez a fejezet bemutatja, hogyan készítsünk egy valós AI ügynököt, amely külső API-kkal integrálódik, különféle adatokat kezel, hibákat kezel, és több eszközt koordinál – mindezt éles környezetre kész formában. Megismerheted:

- **Hitelesítést igénylő külső API-k integrációja**
- **Különféle adat típusok kezelése több végponton keresztül**
- **Robosztus hibakezelési és naplózási stratégiák**
- **Több eszköz egy szerveren belüli összehangolása**

A végére gyakorlati tapasztalatot szerzel olyan mintákkal és bevált gyakorlatokkal, amelyek elengedhetetlenek a fejlett AI és LLM-alapú alkalmazásokhoz.

## Bevezetés

Ebben a leckében megtanulod, hogyan építs egy fejlett MCP szervert és klienst, amely valós idejű webes adatokkal bővíti az LLM képességeit a SerpAPI segítségével. Ez kritikus készség dinamikus AI ügynökök fejlesztéséhez, amelyek naprakész információkat tudnak lekérni a webről.

## Tanulási célok

A lecke végére képes leszel:

- Biztonságosan integrálni külső API-kat (például SerpAPI-t) egy MCP szerverbe
- Több eszközt megvalósítani webes, hírek, termékkereséshez és kérdés-válasz funkciókhoz
- Strukturált adatokat feldolgozni és formázni LLM számára
- Hatékonyan kezelni hibákat és API-korlátozásokat
- Automatikus és interaktív MCP klienseket építeni és tesztelni

## Web Search MCP szerver

Ebben a részben megismerkedsz a Web Search MCP szerver architektúrájával és funkcióival. Megtudhatod, hogyan használja a FastMCP és SerpAPI kombinációját az LLM képességek valós idejű webes adatokkal való bővítésére.

### Áttekintés

Ez a megvalósítás négy eszközt tartalmaz, amelyek bemutatják az MCP képességét, hogy biztonságosan és hatékonyan kezeljen különféle, külső API-k által vezérelt feladatokat:

- **general_search**: Általános webes kereséshez
- **news_search**: Legfrissebb hírekhez
- **product_search**: E-kereskedelmi adatok lekéréséhez
- **qna**: Kérdés-válasz részletekhez

### Funkciók
- **Kódpéldák**: Nyelvspecifikus kódrészletek Pythonhoz (könnyen bővíthető más nyelvekre), összecsukható szekciókban a könnyebb áttekinthetőségért

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

A kliens futtatása előtt hasznos megérteni, mit csinál a szerver. A [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Itt egy rövid példa arra, hogyan definiál és regisztrál egy eszközt a szerver:

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

- **Külső API integráció**: Biztonságos API kulcs és külső kérések kezelése
- **Strukturált adat feldolgozás**: API válaszok LLM-barát formátumba alakítása
- **Hibakezelés**: Robosztus hibakezelés megfelelő naplózással
- **Interaktív kliens**: Automatikus tesztek és interaktív mód a teszteléshez
- **Kontekstus menedzsment**: MCP Context használata naplózáshoz és kéréskövetéshez

## Előfeltételek

Mielőtt elkezdenéd, győződj meg róla, hogy a környezeted megfelelően van beállítva az alábbi lépések szerint. Ez biztosítja, hogy minden függőség telepítve legyen, és az API kulcsaid helyesen legyenek konfigurálva a zökkenőmentes fejlesztéshez és teszteléshez.

- Python 3.8 vagy újabb
- SerpAPI API kulcs (Regisztrálj a [SerpAPI](https://serpapi.com/) oldalon – ingyenes csomag elérhető)

## Telepítés

A kezdéshez kövesd az alábbi lépéseket a környezet beállításához:

1. Telepítsd a függőségeket uv (ajánlott) vagy pip használatával:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Hozz létre egy `.env` fájlt a projekt gyökerében a SerpAPI kulcsoddal:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Használat

A Web Search MCP szerver a központi komponens, amely eszközöket tesz elérhetővé webes, hírek, termékkereséshez és kérdés-válasz funkciókhoz a SerpAPI integrációjával. Kezeli a bejövő kéréseket, API hívásokat, feldolgozza a válaszokat, és strukturált eredményeket ad vissza a kliensnek.

A teljes megvalósítást megtalálod a [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) fájlban.

### Szerver indítása

Az MCP szerver indításához használd a következő parancsot:

```bash
python server.py
```

A szerver stdio alapú MCP szerverként fut, amelyhez a kliens közvetlenül csatlakozhat.

### Kliens módok

A kliens a (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Kliens futtatása

Az automatikus tesztek futtatásához (ez automatikusan elindítja a szervert):

```bash
python client.py
```

Vagy indítsd interaktív módban:

```bash
python client.py --interactive
```

### Tesztelés különböző módokon

Számos módon tesztelheted és használhatod az eszközöket, attól függően, mire van szükséged és hogyan dolgozol.

#### Egyedi teszt szkriptek írása az MCP Python SDK-val

Saját teszt szkripteket is írhatsz az MCP Python SDK segítségével:

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

Ebben az esetben a "teszt szkript" egy olyan egyedi Python program, amelyet kliensként írsz az MCP szerverhez. Ez nem egy formális egységteszt, hanem egy programozott módja, hogy csatlakozz a szerverhez, bármelyik eszközt meghívd a kívánt paraméterekkel, és megvizsgáld az eredményeket. Ez hasznos:

- Prototípus készítéshez és kísérletezéshez eszköz hívásokkal
- Ellenőrizni, hogyan reagál a szerver különböző bemenetekre
- Ismétlődő eszköz hívások automatizálásához
- Saját munkafolyamatok vagy integrációk építéséhez az MCP szerverre alapozva

Teszt szkriptekkel gyorsan kipróbálhatsz új lekérdezéseket, hibakereshetsz, vagy akár fejlettebb automatizálás kiindulópontjaként is használhatod. Az alábbi példa bemutatja, hogyan használd az MCP Python SDK-t ilyen szkript létrehozásához:

## Eszközök leírása

Az alábbi eszközöket használhatod a szerver által nyújtott különböző keresési és lekérdezési feladatokhoz. Mindegyik eszközt leírjuk a paramétereivel és példákkal.

Ez a rész részletesen bemutatja az elérhető eszközöket és paramétereiket.

### general_search

Általános webes keresést végez, és formázott eredményeket ad vissza.

**Hogyan hívd meg ezt az eszközt:**

A `general_search`-t meghívhatod saját szkriptedből az MCP Python SDK-val, vagy interaktívan az Inspector vagy az interaktív kliens mód segítségével. Íme egy példa a SDK használatára:

<details>
<summary>Python példa</summary>

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

Interaktív módban válaszd a `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): A keresési lekérdezés paramétert

**Példa kérés:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Friss hírek keresése egy adott lekérdezés alapján.

**Hogyan hívd meg ezt az eszközt:**

A `news_search`-t meghívhatod saját szkriptedből az MCP Python SDK-val, vagy interaktívan az Inspector vagy az interaktív kliens mód segítségével. Íme egy példa a SDK használatára:

<details>
<summary>Python példa</summary>

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

Interaktív módban válaszd a `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): A keresési lekérdezés paramétert

**Példa kérés:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Termékek keresése egy lekérdezés alapján.

**Hogyan hívd meg ezt az eszközt:**

A `product_search`-t meghívhatod saját szkriptedből az MCP Python SDK-val, vagy interaktívan az Inspector vagy az interaktív kliens mód segítségével. Íme egy példa a SDK használatára:

<details>
<summary>Python példa</summary>

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

Interaktív módban válaszd a `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): A termék keresési lekérdezés paramétert

**Példa kérés:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Közvetlen válaszokat ad kérdésekre keresőmotorokból.

**Hogyan hívd meg ezt az eszközt:**

A `qna`-t meghívhatod saját szkriptedből az MCP Python SDK-val, vagy interaktívan az Inspector vagy az interaktív kliens mód segítségével. Íme egy példa a SDK használatára:

<details>
<summary>Python példa</summary>

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

Interaktív módban válaszd a `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): A válasz keresendő kérdés paramétert

**Példa kérés:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Kód részletek

Ez a rész kódrészleteket és hivatkozásokat tartalmaz a szerver és kliens megvalósításához.

<details>
<summary>Python</summary>

A teljes megvalósítást lásd a [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) fájlban.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Haladó fogalmak ebben a leckében

Mielőtt elkezdenéd az építést, itt van néhány fontos haladó fogalom, amelyek végigkísérik ezt a fejezetet. Ezek megértése segít, hogy könnyebben kövesd a tartalmat, még ha újak is számodra:

- **Több eszköz összehangolása**: Ez azt jelenti, hogy több különböző eszközt (pl. webes keresés, hírek keresése, termékkeresés, kérdés-válasz) futtatsz egyetlen MCP szerveren belül. Ez lehetővé teszi, hogy a szerver többféle feladatot is ellásson, ne csak egyet.
- **API-korlátozások kezelése**: Sok külső API (például SerpAPI) korlátozza, hogy mennyi kérést küldhetsz egy adott idő alatt. A jó kód ellenőrzi ezeket a korlátokat, és szépen kezeli őket, hogy az alkalmazás ne omoljon össze, ha eléri a limitet.
- **Strukturált adat feldolgozás**: Az API válaszok gyakran összetettek és beágyazottak. Ez a fogalom arra utal, hogy ezeket a válaszokat tiszta, könnyen használható formátumba alakítjuk, amelyek barátságosak az LLM-ek vagy más programok számára.
- **Hibajavítás**: Néha valami elromlik – például a hálózat megszakad, vagy az API nem adja vissza a várt adatot. A hibajavítás azt jelenti, hogy a kód kezeli ezeket a problémákat, és hasznos visszajelzést ad, ahelyett, hogy összeomlana.
- **Paraméter ellenőrzés**: Ez arról szól, hogy megbizonyosodunk arról, hogy az eszközeinkhez adott bemenetek helyesek és biztonságosak. Ez magában foglalja az alapértelmezett értékek beállítását és a típusok ellenőrzését, ami segít elkerülni hibákat és félreértéseket.

Ez a rész segít diagnosztizálni és megoldani a Web Search MCP szerverrel kapcsolatos gyakori problémákat. Ha hibába ütközöl vagy váratlan viselkedést tapasztalsz, ez a hibakeresési szakasz a leggyakoribb problémákra kínál megoldásokat. Nézd át ezeket a tippeket, mielőtt további segítséget kérnél – gyakran gyorsan megoldják a gondokat.

## Hibakeresés

A Web Search MCP szerver használata során időnként előfordulhatnak problémák – ez normális, amikor külső API-kkal és új eszközökkel dolgozol. Ez a rész gyakorlati megoldásokat kínál a leggyakoribb problémákra, hogy gyorsan visszatérhess a munkához. Ha hibát tapasztalsz, innen érdemes kezdeni: az alábbi tippek a leggyakoribb felhasználói problémákat célozzák, és sok esetben extra segítség nélkül is megoldják a gondokat.

### Gyakori problémák

Az alábbiakban néhány leggyakoribb hiba és azok magyarázata, valamint a megoldási lépések találhatók:

1. **Hiányzó SERPAPI_KEY a .env fájlban**
   - Ha az alábbi hibaüzenetet látod: `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``, ellenőrizd, hogy van-e `.env` fájlod, és abban helyesen szerepel-e a SERPAPI_KEY. Ha a kulcs helyes, de mégis ezt az üzenetet kapod, ellenőrizd, hogy a szabad csomagod nem merült-e ki.

### Hibakeresési mód

Alapértelmezés szerint az alkalmazás csak a fontos információkat naplózza. Ha részletesebben szeretnéd látni, mi történik (például bonyolultabb hibák diagnosztizálásához), engedélyezheted a DEBUG módot. Ez sokkal több részletet mutat meg minden lépésről.

**Példa: Normál kimenet**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Példa: DEBUG kimenet**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Figyeld meg, hogy a DEBUG mód extra sorokat tartalmaz HTTP kérésekről, válaszokról és más belső részletekről. Ez nagyon hasznos lehet hibakereséskor.

A DEBUG mód engedélyezéséhez állítsd a naplózási szintet DEBUG-ra a `client.py` or `server.py` elején:

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

## Mi következik

- [6. Közösségi hozzájárulások](../../06-CommunityContributions/README.md)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár igyekszünk pontos fordítást biztosítani, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén javasolt szakmai, emberi fordítást igénybe venni. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.