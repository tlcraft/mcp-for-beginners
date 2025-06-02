<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:23:45+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "hu"
}
-->
# Lesson: Web Search MCP szerver építése


Ez a fejezet bemutatja, hogyan építhetünk valós környezetben működő AI ügynököt, amely külső API-kkal integrálódik, különféle adattípusokat kezel, hibákat kezel, és több eszközt koordinál – mindezt éles környezetben használható formában. Megismerheted:

- **Külső, hitelesítést igénylő API-k integrálása**
- **Különböző adattípusok kezelése több végpontról**
- **Robosztus hibakezelési és naplózási stratégiák**
- **Több eszköz összehangolása egyetlen szerveren belül**

A végére gyakorlati tapasztalatot szerzel az olyan mintákkal és bevált gyakorlatokkal, amelyek elengedhetetlenek fejlett AI és LLM-alapú alkalmazásokhoz.

## Bevezetés

Ebben a leckében megtanulod, hogyan építs egy fejlett MCP szervert és klienst, amely a SerpAPI segítségével valós idejű webes adatokkal bővíti az LLM képességeit. Ez kulcsfontosságú készség dinamikus AI ügynökök fejlesztéséhez, amelyek naprakész információkat tudnak lekérni a webről.

## Tanulási célok

A lecke végére képes leszel:

- Biztonságosan integrálni külső API-kat (például SerpAPI-t) egy MCP szerverbe
- Több eszközt megvalósítani web-, hírek-, termékkereséshez és kérdés-válasz funkcióhoz
- Strukturált adatokat feldolgozni és formázni LLM fogyasztásra
- Hatékonyan kezelni hibákat és API-korlátozásokat
- Automatizált és interaktív MCP klienseket építeni és tesztelni

## Web Search MCP szerver

Ebben a részben bemutatjuk a Web Search MCP szerver architektúráját és funkcióit. Meglátod, hogyan használja a FastMCP és a SerpAPI együtt az LLM képességek valós idejű webes adatokkal való bővítésére.

### Áttekintés

Ez a megvalósítás négy eszközt tartalmaz, amelyek bemutatják az MCP képességét arra, hogy különféle, külső API-alapú feladatokat biztonságosan és hatékonyan kezeljen:

- **general_search**: Általános webes kereséshez
- **news_search**: Legfrissebb hírekhez
- **product_search**: E-kereskedelmi adatokhoz
- **qna**: Kérdés-válasz részletekhez

### Funkciók
- **Kód példák**: Nyelvspecifikus kódrészletek Pythonban (és könnyen bővíthető más nyelvekre), összehajtható szakaszokkal az átláthatóság érdekében

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

Íme egy rövid példa arra, hogyan definiál és regisztrál egy eszközt a szerver:

<details>  
<summary>Python szerver</summary> 

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

- **Külső API integráció**: Biztonságos API kulcs kezelés és külső kérések bemutatása
- **Strukturált adatfeldolgozás**: Az API válaszok LLM-barát formátumba alakítása
- **Hibakezelés**: Robosztus hibakezelés megfelelő naplózással
- **Interaktív kliens**: Tartalmaz automatizált teszteket és interaktív módot is
- **Kontextuskezelés**: MCP Context használata naplózáshoz és kérések nyomon követéséhez

## Előfeltételek

Mielőtt elkezdenéd, győződj meg róla, hogy a környezeted megfelelően be van állítva az alábbi lépések követésével. Ez biztosítja, hogy minden függőség telepítve legyen, és az API kulcsaid helyesen legyenek konfigurálva a zavartalan fejlesztéshez és teszteléshez.

- Python 3.8 vagy újabb
- SerpAPI API kulcs (Regisztrálj a [SerpAPI](https://serpapi.com/) oldalon – ingyenes csomag elérhető)

## Telepítés

A környezet beállításához kövesd az alábbi lépéseket:

1. Telepítsd a függőségeket uv-vel (ajánlott) vagy pip-pel:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Hozz létre egy `.env` fájlt a projekt gyökérkönyvtárában a SerpAPI kulcsoddal:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Használat

A Web Search MCP szerver az a központi komponens, amely eszközöket kínál web-, hír-, termékkereséshez és kérdés-válasz funkcióhoz a SerpAPI integrálásával. Kezeli a bejövő kéréseket, API hívásokat, feldolgozza a válaszokat, és strukturált eredményeket küld vissza a kliensnek.

A teljes megvalósítást megtekintheted a [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) fájlban.

### A szerver indítása

Az MCP szerver elindításához használd a következő parancsot:

```bash
python server.py
```

A szerver stdio-alapú MCP szerverként fut, amelyhez a kliens közvetlenül csatlakozhat.

### Kliens módok

A kliens (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### A kliens futtatása

Az automatizált tesztek futtatásához (ez automatikusan elindítja a szervert):

```bash
python client.py
```

Vagy futtasd interaktív módban:

```bash
python client.py --interactive
```

### Tesztelés különböző módokon

Számos módja van a szerver eszközeinek tesztelésére és használatára, az igényeid és munkafolyamatod szerint.

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

Ebben az esetben a "teszt szkript" egy olyan egyedi Python program, amelyet kliensként írsz az MCP szerverhez való kapcsolódáshoz. Nem formális egységteszt, hanem egy olyan eszköz, amellyel programozottan hívhatod a szerver eszközeit a kívánt paraméterekkel, és ellenőrizheted az eredményeket. Ez hasznos:

- Prototípus készítéshez és kísérletezéshez az eszköz hívásokkal
- A szerver válaszainak validálásához különböző bemenetekre
- Ismétlődő hívások automatizálásához
- Saját munkafolyamatok vagy integrációk építéséhez az MCP szerverre építve

A teszt szkriptek gyorsan kipróbálhatnak új lekérdezéseket, hibakeresésre is alkalmasak, vagy akár kiindulópontként szolgálhatnak fejlettebb automatizáláshoz. Lentebb egy példa arra, hogyan használhatod az MCP Python SDK-t ilyen szkript készítéséhez:

## Eszközök leírása

A szerver által biztosított eszközöket különböző keresések és lekérdezések végrehajtására használhatod. Az alábbiakban részletezzük az egyes eszközöket, paramétereiket és használati példáikat.

Ebben a szakaszban részletes információkat találsz az elérhető eszközökről és azok paramétereiről.

### general_search

Általános webes keresést végez, és formázott eredményeket ad vissza.

**Az eszköz hívása:**

A `general_search` eszközt meghívhatod saját szkriptből az MCP Python SDK-val, vagy interaktívan az Inspectorral vagy az interaktív kliens módban. Íme egy kód példa az SDK használatával:

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

Friss hírek keresése egy adott lekérdezéshez.

**Az eszköz hívása:**

A `news_search` eszközt meghívhatod saját szkriptből az MCP Python SDK-val, vagy interaktívan az Inspectorral vagy az interaktív kliens módban. Íme egy kód példa az SDK használatával:

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

Termékek keresése egy adott lekérdezés alapján.

**Az eszköz hívása:**

A `product_search` eszközt meghívhatod saját szkriptből az MCP Python SDK-val, vagy interaktívan az Inspectorral vagy az interaktív kliens módban. Íme egy kód példa az SDK használatával:

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
- `query` (string): A termékkeresési lekérdezés paramétert

**Példa kérés:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Közvetlen válaszokat ad kérdésekre keresőmotorok alapján.

**Az eszköz hívása:**

A `qna` eszközt meghívhatod saját szkriptből az MCP Python SDK-val, vagy interaktívan az Inspectorral vagy az interaktív kliens módban. Íme egy kód példa az SDK használatával:

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
- `question` (string): A válasz keresett kérdés paramétert

**Példa kérés:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Kód részletek

Ebben a szakaszban kódrészleteket és hivatkozásokat találsz a szerver és kliens megvalósításához.

<details>
<summary>Python</summary>

Teljes megvalósítás a [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) fájlokban.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Fejlett fogalmak ebben a leckében

Mielőtt elkezdenéd az építést, itt van néhány fontos fejlett fogalom, amelyek végigvonulnak ezen a fejezeten. Ezek megértése segít követni a tartalmat, még ha újak is számodra:

- **Több eszköz összehangolása**: Ez azt jelenti, hogy egyetlen MCP szerveren több különböző eszköz (például webes keresés, hírek keresése, termékkeresés és kérdés-válasz) fut egyszerre. Ez lehetővé teszi, hogy a szerver sokféle feladatot kezeljen, ne csak egyet.
- **API-korlátozások kezelése**: Sok külső API (például SerpAPI) korlátozza, hogy mennyi kérést küldhetsz egy adott idő alatt. A jó kód ellenőrzi ezeket a korlátokat és megfelelően kezeli őket, hogy az alkalmazás ne omoljon össze, ha eléri a limitet.
- **Strukturált adatfeldolgozás**: Az API válaszok gyakran összetettek és többszintűek. Ez a fogalom arról szól, hogyan alakítsuk ezeket a válaszokat tiszta, könnyen használható formátumokká, amelyek barátságosak az LLM-ek vagy más programok számára.
- **Hibahelyreállítás**: Néha valami elromlik – például hálózati hiba vagy az API nem a várt választ adja. A hibahelyreállítás azt jelenti, hogy a kódod kezeli ezeket a problémákat, és hasznos visszajelzést ad, ahelyett hogy összeomlana.
- **Paraméter validáció**: Ez arról szól, hogy ellenőrizd, minden bemenet helyes és biztonságos legyen az eszközeid számára. Ide tartozik az alapértelmezett értékek beállítása és a típusellenőrzés, ami segít elkerülni a hibákat és félreértéseket.

Ez a szakasz segít diagnosztizálni és megoldani a Web Search MCP szerverrel kapcsolatos gyakori problémákat. Ha hibába ütközöl vagy váratlan viselkedést tapasztalsz, ez a hibakeresési rész a leggyakoribb problémákra kínál megoldásokat. Nézd át ezeket a tippeket, mielőtt további segítséget kérnél – gyakran gyorsan megoldják a gondokat.

## Hibakeresés

A Web Search MCP szerver használata közben előfordulhatnak problémák – ez normális a külső API-k és új eszközök fejlesztése során. Ez a rész gyakorlati megoldásokat kínál a leggyakoribb problémákra, hogy gyorsan visszatérhess a munkához. Ha hibába ütközöl, innen érdemes indítani: az alábbi tippek a legtöbb felhasználó által tapasztalt problémákat fedik le, és sokszor megoldják a gondot további segítség nélkül.

### Gyakori problémák

Az alábbiakban néhány gyakori probléma és a megoldási lépések:

1. **Hiányzó SERPAPI_KEY a .env fájlban**
   - Ha a `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` hibaüzenetet látod, ellenőrizd, hogy létrehoztad-e a `.env` fájlt a szükséges kulccsal. Ha a kulcs helyes, de a hiba továbbra is fennáll, ellenőrizd, hogy az ingyenes csomagod nem merült-e ki.

### Hibakeresési mód

Alapértelmezés szerint az alkalmazás csak a fontos információkat naplózza. Ha részletesebben szeretnéd látni, mi történik (például bonyolult hibák diagnosztizálásához), engedélyezheted a DEBUG módot. Ez sokkal több információt mutat minden lépésről.

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

A DEBUG mód engedélyezéséhez állítsd a naplózási szintet DEBUG-ra a `client.py` or `server.py` fájl tetején:

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
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén javasolt szakmai emberi fordítást igénybe venni. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.