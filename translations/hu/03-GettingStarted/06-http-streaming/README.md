<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:51:35+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hu"
}
-->
# HTTPS Streaming a Model Context Protocol (MCP) segítségével

Ez a fejezet átfogó útmutatót nyújt a biztonságos, skálázható és valós idejű streaming megvalósításához a Model Context Protocol (MCP) használatával HTTPS-en keresztül. Bemutatja a streaming motivációját, a rendelkezésre álló szállítási mechanizmusokat, hogyan valósítható meg streamelhető HTTP az MCP-ben, a biztonsági legjobb gyakorlatokat, az SSE-ről való átállást, valamint gyakorlati útmutatót saját streaming MCP alkalmazások építéséhez.

## Szállítási mechanizmusok és streaming az MCP-ben

Ebben a szakaszban megvizsgáljuk az MCP-ben elérhető különböző szállítási mechanizmusokat, és azok szerepét a kliens és szerver közötti valós idejű kommunikáció streaming képességeinek biztosításában.

### Mi az a szállítási mechanizmus?

A szállítási mechanizmus meghatározza, hogyan cserélődnek az adatok a kliens és a szerver között. Az MCP többféle szállítási típust támogat, hogy különböző környezetekhez és igényekhez igazodjon:

- **stdio**: Standard bemenet/kimenet, helyi és parancssoros eszközökhöz ideális. Egyszerű, de nem alkalmas web vagy felhő alapú használatra.
- **SSE (Server-Sent Events)**: Lehetővé teszi, hogy a szerver valós idejű frissítéseket küldjön HTTP-n keresztül a kliensnek. Jó webes felületekhez, de korlátozott a skálázhatósága és rugalmassága.
- **Streamable HTTP**: Modern HTTP-alapú streaming szállítás, támogatja az értesítéseket és jobb skálázhatóságot kínál. Ajánlott a legtöbb gyártási és felhőalapú környezetben.

### Összehasonlító táblázat

Nézd meg az alábbi összehasonlító táblázatot, hogy megértsd a különbségeket ezek között a szállítási mechanizmusok között:

| Szállítási mód    | Valós idejű frissítések | Streaming | Skálázhatóság | Használati eset          |
|-------------------|------------------------|-----------|---------------|-------------------------|
| stdio             | Nem                    | Nem       | Alacsony      | Helyi CLI eszközök      |
| SSE               | Igen                   | Igen      | Közepes       | Web, valós idejű frissítések |
| Streamable HTTP   | Igen                   | Igen      | Magas         | Felhő, több kliens      |

> **Tip:** A megfelelő szállítási mód kiválasztása hatással van a teljesítményre, skálázhatóságra és a felhasználói élményre. A **Streamable HTTP** ajánlott modern, skálázható és felhőbarát alkalmazásokhoz.

Vedd észre a stdio és SSE szállításokat, amiket az előző fejezetekben bemutattunk, és hogy ebben a fejezetben a streamelhető HTTP a központi szállítási mód.

## Streaming: Fogalmak és motiváció

Az alapvető streaming fogalmak és motivációk megértése elengedhetetlen hatékony valós idejű kommunikációs rendszerek megvalósításához.

A **streaming** egy hálózati programozási technika, amely lehetővé teszi az adatok kis, kezelhető darabokban vagy eseménysorozatként történő küldését és fogadását, nem pedig az egész válasz egyszerre történő megvárását. Ez különösen hasznos:

- Nagy fájlok vagy adathalmazok esetén.
- Valós idejű frissítésekhez (pl. chat, folyamatjelző sávok).
- Hosszú futású számításoknál, amikor szeretnéd a felhasználót folyamatosan tájékoztatni.

Íme, amit a streamingről magas szinten tudni érdemes:

- Az adatok fokozatosan érkeznek, nem egyszerre.
- A kliens képes feldolgozni az adatokat érkezéskor.
- Csökkenti az észlelt késleltetést és javítja a felhasználói élményt.

### Miért érdemes streaminget használni?

A streaming használatának okai a következők:

- A felhasználók azonnali visszajelzést kapnak, nem csak a végén.
- Lehetővé teszi valós idejű alkalmazások és reszponzív felületek létrehozását.
- Hatékonyabb hálózati és számítási erőforrás-kihasználás.

### Egyszerű példa: HTTP streaming szerver és kliens

Íme egy egyszerű példa arra, hogyan valósítható meg a streaming:

<details>
<summary>Python</summary>

**Szerver (Python, FastAPI és StreamingResponse használatával):**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**Kliens (Python, requests könyvtárral):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

Ez a példa azt mutatja be, hogy a szerver egy sor üzenetet küld a kliensnek, amint azok elérhetővé válnak, ahelyett, hogy megvárná az összes üzenet elkészülését.

**Hogyan működik:**
- A szerver minden üzenetet azonnal továbbít, amint az elkészül.
- A kliens fogadja és kiírja az érkező darabokat.

**Követelmények:**
- A szervernek streaming választ kell használnia (pl. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`), nem csak MCP streaming választ.

- **Egyszerű streaming igényekhez:** A klasszikus HTTP streaming könnyebben megvalósítható és elegendő az alapvető igényekhez.

- **Komplex, interaktív alkalmazásokhoz:** Az MCP streaming strukturáltabb megközelítést kínál, gazdagabb metaadatokkal, és elkülöníti az értesítéseket a végső eredménytől.

- **AI alkalmazásokhoz:** Az MCP értesítési rendszere különösen hasznos hosszú futású AI feladatoknál, ahol fontos a felhasználók folyamatos tájékoztatása.

## Streaming az MCP-ben

Tehát eddig láttál ajánlásokat és összehasonlításokat a klasszikus streaming és az MCP streaming között. Most nézzük meg részletesen, hogyan használhatod ki a streaminget az MCP-ben.

Fontos megérteni, hogyan működik a streaming az MCP keretrendszeren belül, hogy olyan reszponzív alkalmazásokat építhess, amelyek valós idejű visszajelzést adnak a felhasználóknak hosszú futású műveletek során.

Az MCP-ben a streaming nem arról szól, hogy a fő választ darabokban küldjük, hanem arról, hogy **értesítéseket** küldünk a kliensnek, miközben egy eszköz feldolgoz egy kérést. Ezek az értesítések tartalmazhatnak előrehaladási frissítéseket, naplókat vagy egyéb eseményeket.

### Hogyan működik?

A fő eredmény továbbra is egyetlen válaszként érkezik. Az értesítések azonban külön üzenetként küldhetők a feldolgozás alatt, így valós időben frissítik a klienst. A kliensnek képesnek kell lennie kezelni és megjeleníteni ezeket az értesítéseket.

## Mi az az értesítés?

Mondtuk, hogy "értesítés" – mit jelent ez az MCP kontextusában?

Az értesítés egy olyan üzenet, amelyet a szerver küld a kliensnek, hogy tájékoztassa a folyamatban lévő hosszú futású művelet előrehaladásáról, állapotáról vagy egyéb eseményekről. Az értesítések növelik az átláthatóságot és javítják a felhasználói élményt.

Például a kliensnek értesítést kell küldenie, amint az első kézfogás a szerverrel megtörtént.

Egy értesítés így néz ki JSON üzenetként:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Az értesítések az MCP-ben egy témához tartoznak, amit ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) néven ismerünk.

A naplózás működéséhez a szervernek engedélyeznie kell ezt a funkciót/képességet, például így:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Az SDK-tól függően a naplózás alapértelmezetten engedélyezett lehet, vagy explicit módon be kell kapcsolni a szerver konfigurációjában.

Különböző értesítés típusok vannak:

| Szint      | Leírás                        | Például használat            |
|------------|-------------------------------|-----------------------------|
| debug      | Részletes hibakeresési információk | Függvény belépési/kilépési pontok |
| info       | Általános információs üzenetek | Művelet előrehaladási frissítések |
| notice     | Normál, de jelentős események  | Konfigurációs változások     |
| warning    | Figyelmeztető állapotok        | Elavult funkció használata   |
| error      | Hibás állapotok                | Művelet sikertelenségei      |
| critical   | Kritikus állapotok             | Rendszerkomponens hibák      |
| alert      | Azonnali beavatkozás szükséges | Adatkárosodás észlelése      |
| emergency  | A rendszer használhatatlan     | Teljes rendszerleállás       |

## Értesítések megvalósítása az MCP-ben

Az MCP értesítések megvalósításához be kell állítanod a szerver és a kliens oldalt is, hogy kezelni tudják a valós idejű frissítéseket. Ez lehetővé teszi, hogy az alkalmazásod azonnali visszajelzést adjon a felhasználóknak hosszú futású műveletek alatt.

### Szerver oldal: Értesítések küldése

Kezdjük a szerver oldallal. Az MCP-ben olyan eszközöket definiálsz, amelyek képesek értesítéseket küldeni a kérések feldolgozása közben. A szerver a context objektumot (általában `ctx`) használja az üzenetek kliens felé küldésére.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

A fenti példában a `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` szállítási mód használata:

```python
mcp.run(transport="streamable-http")
```

</details>

### Kliens oldal: Értesítések fogadása

A kliensnek implementálnia kell egy üzenetkezelőt, amely feldolgozza és megjeleníti az értesítéseket, amint azok megérkeznek.

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

A fenti kódban a `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`-hoz hasonlóan a kliensed üzenetkezelőt valósít meg az értesítések feldolgozására.

## Előrehaladási értesítések és forgatókönyvek

Ez a szakasz elmagyarázza az előrehaladási értesítések fogalmát az MCP-ben, miért fontosak, és hogyan valósíthatók meg Streamable HTTP segítségével. Találsz egy gyakorlati feladatot is a megértés elmélyítésére.

Az előrehaladási értesítések valós idejű üzenetek, amelyeket a szerver küld a kliensnek hosszú futású műveletek alatt. Ahelyett, hogy megvárnánk a teljes folyamat befejezését, a szerver folyamatosan tájékoztatja a klienst az aktuális állapotról. Ez növeli az átláthatóságot, javítja a felhasználói élményt, és megkönnyíti a hibakeresést.

**Példa:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Miért használjunk előrehaladási értesítéseket?

Az előrehaladási értesítések fontosak több okból is:

- **Jobb felhasználói élmény:** A felhasználók folyamatosan látják a frissítéseket, nem csak a végén.
- **Valós idejű visszajelzés:** A kliensek megjeleníthetnek folyamatjelző sávokat vagy naplókat, így az alkalmazás reszponzívabbnak tűnik.
- **Könnyebb hibakeresés és monitorozás:** A fejlesztők és a felhasználók láthatják, hol lassulhat vagy akad el egy folyamat.

### Hogyan valósítsuk meg az előrehaladási értesítéseket?

Így valósíthatod meg az előrehaladási értesítéseket az MCP-ben:

- **Szerver oldalon:** Használd a `ctx.info()` or `ctx.log()` metódusokat, hogy értesítéseket küldj minden egyes feldolgozott elemről. Ezek az üzenetek a fő eredmény előtt érkeznek.
- **Kliens oldalon:** Implementálj egy üzenetkezelőt, amely figyeli és megjeleníti az értesítéseket érkezésük szerint. Ez az üzenetkezelő megkülönbözteti az értesítéseket és a végső eredményt.

**Szerver példa:**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**Kliens példa:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## Biztonsági szempontok

Az MCP szerverek HTTP-alapú szállításokkal történő megvalósításakor a biztonság kiemelten fontos, és alapos figyelmet igényel többféle támadási felület és védekezési mechanizmus tekintetében.

### Áttekintés

A biztonság kritikus, amikor MCP szervereket teszünk elérhetővé HTTP-n keresztül. A Streamable HTTP új támadási felületeket hoz létre, ezért gondos konfiguráció szükséges.

### Kulcspontok
- **Origin fejléc ellenőrzése**: Mindig ellenőrizd az `Origin` fejlécet, hogy csak megbízható források férhessenek hozzá.
- **Hitelesítés és jogosultságkezelés**: Alkalmazz megfelelő autentikációs és autorizációs mechanizmusokat.
- **Titkosítás**: Mindig használj HTTPS-t az adatok biztonságos továbbításához.
- **Input validáció**: Gondoskodj róla, hogy a bemeneti adatokat mindig ellenőrizd és tisztítsd.
- **Rate limiting és védelem a DoS támadások ellen**: Alkalmazz korlátozásokat a túlterhelés megakadályozására.

### Kompatibilitás fenntartása

Ajánlott megtartani az SSE kliens kompatibilitást az átállás során. Néhány stratégia:

- Támogathatod egyszerre az SSE-t és a Streamable HTTP-t különböző végpontokon.
- Fokozatosan migrálhatod a klienseket az új szállítási módra.

### Kihívások

Az átállás során figyelj az alábbi kihívásokra:

- Biztosítani, hogy minden kliens frissüljön.
- Kezelni az értesítések kézbesítésében lévő különbségeket.

### Feladat: Építsd meg saját streaming MCP alkalmazásod

**Forgatókönyv:**
Építs egy MCP szervert és klienst, ahol a szerver feldolgoz egy elemlistát (például fájlokat vagy dokumentumokat), és minden feldolgozott elemről értesítést küld. A kliens valós időben jelenítse meg az értesítéseket.

**Lépések:**

1. Valósíts meg egy szerver eszközt, amely feldolgozza az elemlistát és értesítéseket küld minden elemről.
2. Valósíts meg egy klienst üzenetkezelővel, amely valós időben megjeleníti az értesítéseket.
3. Teszteld az implementációdat úgy, hogy egyszerre futtatod a szervert

**Felelősségkizárás**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.