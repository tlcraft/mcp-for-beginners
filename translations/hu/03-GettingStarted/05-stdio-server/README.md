<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:42:52+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "hu"
}
-->
# MCP szerver stdio transzporttal

> **⚠️ Fontos frissítés**: Az MCP specifikáció 2025-06-18-tól kezdődően a különálló SSE (Server-Sent Events) transzport **elavultnak** minősült, és helyette a "Streamable HTTP" transzportot vezették be. Az aktuális MCP specifikáció két elsődleges transzport mechanizmust határoz meg:
> 1. **stdio** - Standard bemenet/kimenet (helyi szerverekhez ajánlott)
> 2. **Streamable HTTP** - Távoli szerverekhez, amelyek belsőleg SSE-t használhatnak
>
> Ez a lecke frissítve lett, hogy a **stdio transzportra** összpontosítson, amely a legtöbb MCP szerver implementációhoz ajánlott megközelítés.

A stdio transzport lehetővé teszi az MCP szerverek számára, hogy standard bemeneti és kimeneti adatfolyamokon keresztül kommunikáljanak a kliensekkel. Ez az MCP specifikáció jelenlegi leggyakrabban használt és ajánlott transzport mechanizmusa, amely egyszerű és hatékony módot biztosít MCP szerverek létrehozására, amelyek könnyen integrálhatók különböző kliensalkalmazásokkal.

## Áttekintés

Ez a lecke bemutatja, hogyan építsünk és használjunk MCP szervereket stdio transzporttal.

## Tanulási célok

A lecke végére képes leszel:

- MCP szervert építeni stdio transzporttal.
- MCP szervert hibakeresni az Inspector segítségével.
- MCP szervert használni a Visual Studio Code-ban.
- Megérteni az aktuális MCP transzport mechanizmusokat, és hogy miért ajánlott a stdio.

## stdio transzport - Hogyan működik

A stdio transzport az MCP specifikáció (2025-06-18) által támogatott két transzport típus egyike. Így működik:

- **Egyszerű kommunikáció**: A szerver JSON-RPC üzeneteket olvas a standard bemenetről (`stdin`), és üzeneteket küld a standard kimenetre (`stdout`).
- **Folyamat-alapú**: A kliens alfolyamatként indítja el az MCP szervert.
- **Üzenetformátum**: Az üzenetek egyedi JSON-RPC kérések, értesítések vagy válaszok, amelyeket új sorok határolnak.
- **Naplózás**: A szerver UTF-8 karakterláncokat írhat a standard hibára (`stderr`) naplózási célból.

### Kulcsfontosságú követelmények:
- Az üzeneteket ÚJ SOROKKAL kell határolni, és NEM tartalmazhatnak beágyazott új sorokat.
- A szerver NEM írhat semmit az `stdout`-ra, ami nem érvényes MCP üzenet.
- A kliens NEM írhat semmit a szerver `stdin`-jére, ami nem érvényes MCP üzenet.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

A fenti kódban:

- Importáljuk a `Server` osztályt és a `StdioServerTransport`-ot az MCP SDK-ból.
- Létrehozunk egy szerver példányt alapkonfigurációval és képességekkel.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

A fenti kódban:

- Létrehozunk egy szerver példányt az MCP SDK használatával.
- Eszközöket definiálunk dekorátorokkal.
- A `stdio_server` kontextuskezelőt használjuk a transzport kezelésére.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

A fő különbség az SSE-hez képest, hogy a stdio szerverek:

- Nem igényelnek webszerver beállítást vagy HTTP végpontokat.
- A kliens alfolyamatként indítja őket.
- `stdin`/`stdout` adatfolyamokon keresztül kommunikálnak.
- Egyszerűbbek implementálni és hibakeresni.

## Gyakorlat: stdio szerver létrehozása

A szerver létrehozásához két dolgot kell szem előtt tartanunk:

- Webszervert kell használnunk a kapcsolódási pontok és üzenetek kitettségéhez.

## Labor: Egyszerű MCP stdio szerver létrehozása

Ebben a laborban egy egyszerű MCP szervert hozunk létre az ajánlott stdio transzport használatával. Ez a szerver olyan eszközöket fog biztosítani, amelyeket a kliensek a Model Context Protocol segítségével hívhatnak meg.

### Előfeltételek

- Python 3.8 vagy újabb
- MCP Python SDK: `pip install mcp`
- Alapvető ismeretek az aszinkron programozásról

Kezdjük el az első MCP stdio szerverünk létrehozását:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## Fő különbségek az elavult SSE megközelítéshez képest

**Stdio transzport (jelenlegi szabvány):**
- Egyszerű alfolyamat modell - a kliens gyermekfolyamatként indítja a szervert.
- Kommunikáció `stdin`/`stdout`-on keresztül JSON-RPC üzenetekkel.
- Nem szükséges HTTP szerver beállítása.
- Jobb teljesítmény és biztonság.
- Könnyebb hibakeresés és fejlesztés.

**SSE transzport (elavult 2025-06-18-tól):**
- HTTP szervert igényelt SSE végpontokkal.
- Bonyolultabb beállítás webszerver infrastruktúrával.
- További biztonsági megfontolások HTTP végpontokhoz.
- Mostantól a Streamable HTTP váltja fel webalapú forgatókönyvekhez.

### Szerver létrehozása stdio transzporttal

A stdio szerver létrehozásához a következő lépéseket kell követnünk:

1. **Szükséges könyvtárak importálása** - Az MCP szerver komponensek és a stdio transzport szükségesek.
2. **Szerver példány létrehozása** - A szerver képességeinek meghatározása.
3. **Eszközök definiálása** - A biztosítani kívánt funkcionalitás hozzáadása.
4. **Transzport beállítása** - A stdio kommunikáció konfigurálása.
5. **Szerver futtatása** - A szerver indítása és az üzenetek kezelése.

Lépésről lépésre építsük fel:

### 1. lépés: Alap stdio szerver létrehozása

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### 2. lépés: További eszközök hozzáadása

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### 3. lépés: A szerver futtatása

Mentsd el a kódot `server.py` néven, és futtasd a parancssorból:

```bash
python server.py
```

A szerver elindul, és várja a bemenetet a `stdin`-ről. JSON-RPC üzenetekkel kommunikál a stdio transzporton keresztül.

### 4. lépés: Tesztelés az Inspectorral

A szerver teszteléséhez használd az MCP Inspectort:

1. Telepítsd az Inspectort: `npx @modelcontextprotocol/inspector`
2. Futtasd az Inspectort, és mutass rá a szerveredre.
3. Teszteld az általad létrehozott eszközöket.

### Mit kell látnod

Ha a szerver helyesen indul, a következőket kell látnod:
- A szerver képességei megjelennek az Inspectorban.
- Az eszközök elérhetők tesztelésre.
- Sikeres JSON-RPC üzenetváltások.
- Az eszközök válaszai megjelennek a felületen.

### Gyakori problémák és megoldások

**A szerver nem indul el:**
- Ellenőrizd, hogy minden függőség telepítve van: `pip install mcp`.
- Ellenőrizd a Python szintaxist és behúzásokat.
- Nézd meg a konzolban megjelenő hibaüzeneteket.

**Az eszközök nem jelennek meg:**
- Győződj meg róla, hogy a `@server.tool()` dekorátorok jelen vannak.
- Ellenőrizd, hogy az eszközfüggvények a `main()` előtt vannak definiálva.
- Ellenőrizd, hogy a szerver megfelelően van konfigurálva.

**Kapcsolódási problémák:**
- Győződj meg róla, hogy a szerver helyesen használja a stdio transzportot.
- Ellenőrizd, hogy más folyamatok nem zavarják-e a működést.
- Ellenőrizd az Inspector parancsszintaxisát.

## Feladat

Próbálj meg több képességet hozzáadni a szerveredhez. Például, használd [ezt az oldalt](https://api.chucknorris.io/), hogy hozzáadj egy eszközt, amely API-t hív. Te döntöd el, hogyan nézzen ki a szerver. Jó szórakozást!

---

**Felelősségkizárás**:  
Ezt a dokumentumot az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítószolgáltatás segítségével fordítottuk le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.