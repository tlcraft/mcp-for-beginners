<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:32:49+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "hu"
}
-->
# Model Context Protocol (MCP) Python implementáció

Ez a tároló egy Python implementációt tartalmaz a Model Context Protocol (MCP) számára, bemutatva, hogyan lehet létrehozni egy szerver és egy kliens alkalmazást, amelyek az MCP szabvány szerint kommunikálnak.

## Áttekintés

Az MCP implementáció két fő komponensből áll:

1. **MCP Server (`server.py`)** – Egy szerver, amely elérhetővé teszi:
   - **Tools**: Távolról hívható függvények
   - **Resources**: Lekérdezhető adatok
   - **Prompts**: Nyelvi modellekhez generált prompt sablonok

2. **MCP Client (`client.py`)** – Egy kliens alkalmazás, amely kapcsolódik a szerverhez és használja annak funkcióit

## Funkciók

Ez az implementáció több kulcsfontosságú MCP funkciót mutat be:

### Tools
- `completion` – Szöveg kiegészítések generálása AI modellektől (szimulált)
- `add` – Egyszerű kalkulátor, amely két számot ad össze

### Resources
- `models://` – Információk visszaadása az elérhető AI modellekről
- `greeting://{name}` – Személyre szabott üdvözlés egy adott névhez

### Prompts
- `review_code` – Prompt generálása kód átvizsgáláshoz

## Telepítés

Az MCP implementáció használatához telepítsd a szükséges csomagokat:

```powershell
pip install mcp-server mcp-client
```

## A szerver és kliens indítása

### Szerver indítása

Indítsd el a szervert egy terminál ablakban:

```powershell
python server.py
```

A szerver fejlesztői módban is futtatható az MCP CLI segítségével:

```powershell
mcp dev server.py
```

Vagy telepíthető a Claude Desktopba (ha elérhető):

```powershell
mcp install server.py
```

### Kliens futtatása

Indítsd el a klienst egy másik terminál ablakban:

```powershell
python client.py
```

Ez kapcsolódik a szerverhez és bemutatja az összes elérhető funkciót.

### Kliens használata

A kliens (`client.py`) bemutatja az MCP összes képességét:

```powershell
python client.py
```

Ez kapcsolódik a szerverhez, és használja az összes funkciót, beleértve az eszközöket, erőforrásokat és promptokat. A kimenet a következőket mutatja:

1. Kalkulátor eszköz eredménye (5 + 7 = 12)
2. Kiegészítő eszköz válasza a "Mi az élet értelme?" kérdésre
3. Az elérhető AI modellek listája
4. Személyre szabott üdvözlés "MCP Explorer" számára
5. Kód átvizsgálási prompt sablon

## Megvalósítás részletei

A szerver a `FastMCP` API-t használja, amely magas szintű absztrakciókat biztosít MCP szolgáltatások definiálásához. Íme egy egyszerűsített példa arra, hogyan definiálhatók az eszközök:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

A kliens az MCP kliens könyvtárat használja a szerverhez való kapcsolódáshoz és hívásokhoz:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## További információk

További részletekért az MCP-ről látogass el ide: https://modelcontextprotocol.io/

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.