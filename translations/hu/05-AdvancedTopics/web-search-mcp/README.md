<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T16:15:34+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "hu"
}
-->
# Lesson: Web Search MCP szerver építése

Ez a fejezet bemutatja, hogyan építsünk egy valós AI ügynököt, amely külső API-kkal integrálódik, különféle adatokat kezel, hibákat kezel, és több eszközt koordinál – mindezt éles környezetben használható formában. Megismerheted:

- **Hitelesítést igénylő külső API-k integrálása**
- **Különböző adat típusok kezelése több végponton keresztül**
- **Robosztus hibakezelési és naplózási stratégiák**
- **Több eszköz egy szerveren belüli koordinálása**

A végére gyakorlati tapasztalatot szerzel az olyan mintákkal és bevált gyakorlatokkal, amelyek elengedhetetlenek fejlett AI és LLM-alapú alkalmazásokhoz.

## Bevezetés

Ebben a leckében megtanulod, hogyan építs egy fejlett MCP szervert és klienst, amely az LLM képességeit valós idejű webes adatokkal bővíti a SerpAPI segítségével. Ez kulcsfontosságú készség dinamikus AI ügynökök fejlesztéséhez, amelyek naprakész információkat tudnak lekérni az internetről.

## Tanulási célok

A lecke végére képes leszel:

- Biztonságosan integrálni külső API-kat (például SerpAPI) egy MCP szerverbe
- Több eszközt megvalósítani web-, hírek-, termékkereséshez és kérdés-válasz funkcióhoz
- Feldolgozni és formázni a strukturált adatokat az LLM számára
- Hatékonyan kezelni a hibákat és az API-k lekérési korlátait
- Felépíteni és tesztelni automatizált és interaktív MCP klienseket

## Web Search MCP szerver

Ebben a részben bemutatjuk a Web Search MCP szerver architektúráját és funkcióit. Meglátod, hogyan használja a FastMCP és a SerpAPI együtt az LLM képességeinek valós idejű webes adatokkal való bővítésére.

### Áttekintés

Ez a megvalósítás négy eszközt tartalmaz, amelyek bemutatják, hogy az MCP hogyan kezeli biztonságosan és hatékonyan a különböző, külső API-alapú feladatokat:

- **general_search**: Általános webes kereséshez
- **news_search**: Friss hírek kereséséhez
- **product_search**: E-kereskedelmi adatok kereséséhez
- **qna**: Kérdés-válasz részletekhez

### Funkciók
- **Kódpéldák**: Nyelvspecifikus kódblokkok Pythonhoz (könnyen bővíthető más nyelvekre is), összecsukható szakaszokkal a jobb áttekinthetőségért

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

A kliens futtatása előtt érdemes megérteni, mit csinál a szerver. A [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Íme egy rövid példa arra, hogyan definiál és regisztrál egy eszközt a szerver:

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

- **Külső API integráció**: Biztonságos API kulcs kezelés és külső kérések bemutatása
- **Strukturált adat feldolgozás**: API válaszok LLM-barát formátumba alakítása
- **Hibakezelés**: Robosztus hibakezelés megfelelő naplózással
- **Interaktív kliens**: Automatizált teszteket és interaktív módot is tartalmaz a teszteléshez
- **Kontekstuskezelés**: MCP Context használata naplózáshoz és kéréskövetéshez

## Előfeltételek

Mielőtt elkezdenéd, győződj meg róla, hogy a környezeted megfelelően van beállítva az alábbi lépések követésével. Ez biztosítja, hogy minden függőség telepítve legyen és az API kulcsaid helyesen legyenek konfigurálva a zökkenőmentes fejlesztéshez és teszteléshez.

- Python 3.8 vagy újabb
- SerpAPI API kulcs (Regisztráció a [SerpAPI](https://serpapi.com/) oldalon – ingyenes csomag elérhető)

## Telepítés

Az induláshoz kövesd az alábbi lépéseket a környezet beállításához:

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

A Web Search MCP Server az a központi komponens, amely eszközöket biztosít webes, hír-, termékkereséshez és kérdés-válasz funkcióhoz a SerpAPI integrálásával. Kezeli a bejövő kéréseket, az API hívásokat, feldolgozza a válaszokat és strukturált eredményeket ad vissza a kliensnek.

A teljes megvalósítást megtalálod a [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) fájlban.

### A szerver indítása

Az MCP szerver indításához használd a következő parancsot:

```bash
python server.py
```

A szerver stdio-alapú MCP szerverként fog futni, amelyhez a kliens közvetlenül csatlakozhat.

### Kliens módok

A kliens (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### A kliens futtatása

Automatizált tesztek futtatásához (ez automatikusan elindítja a szervert):

```bash
python client.py
```

Vagy interaktív módban:

```bash
python client.py --interactive
```

### Tesztelés különböző módokon

Számos módja van az eszközök tesztelésének és interakciójának a szerverrel, az igényeidtől és munkafolyamatodtól függően.

#### Egyedi teszt szkriptek írása az MCP Python SDK-val
Saját teszt szkripteket is készíthetsz az MCP Python SDK segítségével:

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

Ebben az esetben a "teszt szkript" egy egyedi Python program, amelyet kliensként írsz az MCP szerverhez. Nem formális egységteszt, hanem egy olyan szkript, amely programozottan kapcsolódik a szerverhez, meghív bármelyik eszközt tetszőleges paraméterekkel, és ellenőrzi az eredményeket. Ez a megközelítés hasznos:

- Eszközhívások prototípus készítéséhez és kísérletezéshez
- A szerver válaszainak érvényesítéséhez különböző bemenetekre
- Ismétlődő eszközhívások automatizálásához
- Saját munkafolyamatok vagy integrációk építéséhez az MCP szerver fölött

Teszt szkriptekkel gyorsan kipróbálhatsz új lekérdezéseket, hibakereshetsz, vagy akár haladóbb automatizálási megoldásokat is építhetsz. Az alábbi példa bemutatja, hogyan használhatod az MCP Python SDK-t ilyen szkript készítéséhez:

## Eszközleírások

Az alábbi eszközöket használhatod a szerver által biztosított különféle keresésekhez és lekérdezésekhez. Minden eszköz leírása tartalmazza a paramétereket és példákat a használatra.

Ez a rész részletes információkat nyújt az elérhető eszközökről és azok paramétereiről.

### general_search

Általános webes keresést végez és formázott eredményeket ad vissza.

**Hogyan hívd meg ezt az eszközt:**

A `general_search` eszközt meghívhatod saját szkriptedből az MCP Python SDK-val, vagy interaktív módon az Inspector vagy az interaktív kliens használatával. Íme egy kód példa az SDK-val:

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

Alternatívaként interaktív módban válaszd a `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): A keresési lekérdezés paramétert

**Példa kérés:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Friss hírek keresése egy adott lekérdezéshez kapcsolódóan.

**Hogyan hívd meg ezt az eszközt:**

A `news_search` eszközt meghívhatod saját szkriptedből az MCP Python SDK-val, vagy interaktív módon az Inspector vagy az interaktív kliens használatával. Íme egy kód példa az SDK-val:

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

Alternatívaként interaktív módban válaszd a `news_search` from the menu and enter your query when prompted.

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

**Hogyan hívd meg ezt az eszközt:**

A `product_search` eszközt meghívhatod saját szkriptedből az MCP Python SDK-val, vagy interaktív módon az Inspector vagy az interaktív kliens használatával. Íme egy kód példa az SDK-val:

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

Alternatívaként interaktív módban válaszd a `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): A termékkeresési lekérdezés paramétert

**Példa kérés:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Közvetlen válaszokat ad keresőmotorokból származó kérdésekre.

**Hogyan hívd meg ezt az eszközt:**

A `qna` eszközt meghívhatod saját szkriptedből az MCP Python SDK-val, vagy interaktív módon az Inspector vagy az interaktív kliens használatával. Íme egy kód példa az SDK-val:

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

Alternatívaként interaktív módban válaszd a `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): A megválaszolandó kérdés paramétert

**Példa kérés:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Kód részletek

Ez a rész kód részleteket és hivatkozásokat tartalmaz a szerver és kliens megvalósításához.

<details>
<summary>Python</summary>

A teljes megvalósítás részletei a [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) fájlokban találhatók.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Fejlett fogalmak ebben a leckében

Mielőtt elkezdenéd az építést, itt van néhány fontos fejlett fogalom, amelyek végigvonulnak ezen a fejezeten. Ezek megértése segít követni az anyagot, még ha újak is számodra:

- **Több eszköz koordinációja**: Ez azt jelenti, hogy egyetlen MCP szerveren belül több különböző eszköz fut (például webes keresés, hírek keresése, termékkeresés és kérdés-válasz). Így a szerver többféle feladatot is képes ellátni, nem csak egyet.
- **API lekérési korlátok kezelése**: Sok külső API (például SerpAPI) korlátozza, hogy mennyi kérést lehet egy adott idő alatt küldeni. A jó kód ellenőrzi ezeket a korlátokat és megfelelően kezeli őket, hogy az alkalmazás ne omoljon össze, ha eléri a limitet.
- **Strukturált adat feldolgozás**: Az API válaszok gyakran összetettek és többszintűek. Ez a fogalom arról szól, hogyan alakítsuk ezeket a válaszokat tiszta, könnyen használható formátumokká, amelyek barátságosak az LLM-ek vagy más programok számára.
- **Hibakezelés és helyreállítás**: Néha problémák adódnak – például hálózati hiba vagy az API nem a várt választ adja. A hibakezelés azt jelenti, hogy a kód képes kezelni ezeket a problémákat, és hasznos visszajelzést ad, ahelyett, hogy összeomlana.
- **Paraméter validáció**: Ez arról szól, hogy ellenőrizzük, hogy az eszközeid bemenetei helyesek és biztonságosak legyenek. Ide tartozik az alapértelmezett értékek beállítása és a típusellenőrzés, ami segít megelőzni hibákat és félreértéseket.

Ez a rész segít diagnosztizálni és megoldani a leggyakoribb problémákat, amelyekkel a Web Search MCP szerver használata közben találkozhatsz. Ha hibába vagy váratlan viselkedésbe ütközöl, ez a hibakeresési rész a leggyakoribb problémákra ad megoldást. Érdemes ezeket átnézni, mielőtt további segítséget kérnél – sok esetben gyors megoldást nyújtanak.

## Hibakeresés

A Web Search MCP szerver használata közben előfordulhatnak problémák – ez teljesen normális, amikor külső API-kkal és új eszközökkel dolgozol. Ez a rész gyakorlati megoldásokat kínál a leggyakoribb gondokra, hogy gyorsan visszatérhess a munkához. Ha hibát tapasztalsz, innen érdemes indítani: az alábbi tippek a legtöbb felhasználó által tapasztalt problémákat fedik le, és gyakran megoldják a gondot külön segítség nélkül.

### Gyakori problémák

Az alábbiakban a leggyakoribb problémák és azok tiszta magyarázata, valamint a megoldási lépések találhatók:

1. **Hiányzó SERPAPI_KEY a .env fájlban**
   - Ha a következő hibát látod: `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` fájl létrehozása szükséges. Ha a kulcsod helyes, de még mindig ezt a hibát kapod, ellenőrizd, hogy az ingyenes csomagod nem merült-e ki.

### Hibakereső mód

Alapértelmezés szerint az alkalmazás csak a fontos információkat naplózza. Ha szeretnél részletesebb információkat látni (például nehéz hibák diagnosztizálásához), engedélyezheted a DEBUG módot. Ez sokkal több részletet mutat meg az alkalmazás lépéseiről.

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

Látható, hogy a DEBUG mód extra sorokat tartalmaz az HTTP kérésekről, válaszokról és egyéb belső részletekről. Ez nagyon hasznos lehet a hibakeresés során.

A DEBUG mód bekapcsolásához állítsd a naplózási szintet DEBUG-ra a `client.py` or `server.py` fájl tetején:

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

- [5.10 Valós idejű streaming](../mcp-realtimestreaming/README.md)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordítószolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár az pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.