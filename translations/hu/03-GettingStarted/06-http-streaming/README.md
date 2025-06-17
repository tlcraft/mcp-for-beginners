<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:24:36+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hu"
}
-->
# HTTPS Streaming a Model Context Protocol (MCP) segítségével

Ez a fejezet átfogó útmutatást nyújt a biztonságos, skálázható és valós idejű streaming megvalósításához a Model Context Protocol (MCP) használatával HTTPS-en keresztül. Bemutatja a streaming motivációját, a rendelkezésre álló szállítási mechanizmusokat, a streamelhető HTTP megvalósítását MCP-ben, a biztonsági legjobb gyakorlatokat, az SSE-ről való migrációt, valamint gyakorlati útmutatást saját streaming MCP alkalmazások építéséhez.

## Szállítási mechanizmusok és streaming az MCP-ben

Ebben a szakaszban megvizsgáljuk az MCP-ben elérhető különböző szállítási mechanizmusokat és azok szerepét a valós idejű kommunikáció streaming képességeinek biztosításában a kliens és szerver között.

### Mi az a szállítási mechanizmus?

A szállítási mechanizmus meghatározza, hogyan cserélődnek az adatok a kliens és a szerver között. Az MCP többféle szállítási típust támogat, hogy különböző környezetekhez és igényekhez igazodjon:

- **stdio**: Standard bemenet/kimenet, helyi és parancssoros eszközökhöz alkalmas. Egyszerű, de nem web vagy felhő környezethez.
- **SSE (Server-Sent Events)**: Lehetővé teszi a szerverek számára, hogy valós idejű frissítéseket küldjenek HTTP-n keresztül a klienseknek. Jó webes felhasználói felületekhez, de korlátozott skálázhatóság és rugalmasság jellemzi.
- **Streamable HTTP**: Modern, HTTP-alapú streaming szállítás, támogatja az értesítéseket és jobb skálázhatóságot nyújt. Ajánlott a legtöbb éles és felhő alapú forgatókönyvhöz.

### Összehasonlító táblázat

Nézze meg az alábbi táblázatot, hogy megértse a különbségeket a szállítási mechanizmusok között:

| Szállítás          | Valós idejű frissítések | Streaming | Skálázhatóság | Használati eset           |
|--------------------|------------------------|-----------|---------------|--------------------------|
| stdio              | Nem                    | Nem       | Alacsony      | Helyi CLI eszközök       |
| SSE                | Igen                   | Igen      | Közepes       | Web, valós idejű frissítések |
| Streamable HTTP    | Igen                   | Igen      | Magas         | Felhő, több kliens       |

> **Tip:** A megfelelő szállítási mechanizmus kiválasztása befolyásolja a teljesítményt, skálázhatóságot és a felhasználói élményt. A **Streamable HTTP** ajánlott modern, skálázható és felhőre kész alkalmazásokhoz.

Vegye észre az előző fejezetekben bemutatott stdio és SSE szállításokat, és hogy ebben a fejezetben a streamelhető HTTP szállításról van szó.

## Streaming: Fogalmak és motiváció

A streaming alapvető fogalmainak és motivációinak megértése elengedhetetlen a hatékony valós idejű kommunikációs rendszerek megvalósításához.

A **streaming** egy hálózati programozási technika, amely lehetővé teszi az adatok kis, kezelhető darabokban vagy eseménysorozatként történő küldését és fogadását, ahelyett, hogy az egész válasz elkészülésére várnánk. Ez különösen hasznos:

- Nagy fájlok vagy adathalmazok esetén.
- Valós idejű frissítésekhez (pl. chat, folyamatjelző sávok).
- Hosszú ideig futó számításoknál, amikor folyamatosan tájékoztatni szeretnénk a felhasználót.

Íme, amit érdemes tudni a streamingről magas szinten:

- Az adatok fokozatosan érkeznek, nem egyszerre.
- A kliens feldolgozhatja az adatokat érkezésük pillanatában.
- Csökkenti az érzékelt késleltetést és javítja a felhasználói élményt.

### Miért érdemes streaminget használni?

A streaming használatának okai a következők:

- A felhasználók azonnali visszajelzést kapnak, nem csak a végén.
- Lehetővé teszi a valós idejű alkalmazásokat és reagáló felhasználói felületeket.
- Hatékonyabb hálózati és számítási erőforrás-használat.

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

Ez a példa bemutatja, hogy a szerver egy sor üzenetet küld a kliensnek, ahogy azok elérhetővé válnak, nem várva meg az összes üzenet elkészülését.

**Hogyan működik:**
- A szerver minden üzenetet akkor küld, amikor az elkészül.
- A kliens fogadja és kiírja az érkező adatdarabokat.

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`), nem csak az MCP streaming kiválasztásával.

- **Egyszerű streaming esetén:** A klasszikus HTTP streaming könnyebben megvalósítható és elegendő az alapvető igényekhez.

- **Összetett, interaktív alkalmazásokhoz:** Az MCP streaming strukturáltabb megközelítést kínál, gazdagabb metaadatokkal és különválasztva az értesítéseket a végső eredménytől.

- **AI alkalmazásokhoz:** Az MCP értesítési rendszere különösen hasznos hosszú ideig futó AI feladatoknál, ahol folyamatosan tájékoztatni szeretnénk a felhasználókat a folyamat állapotáról.

## Streaming az MCP-ben

Rendben, eddig láttál néhány ajánlást és összehasonlítást a klasszikus streaming és az MCP streaming között. Most nézzük meg részletesen, hogyan használhatod ki a streaming előnyeit az MCP-ben.

Az MCP keretrendszerben a streaming nem arról szól, hogy a fő választ darabokban küldjük, hanem arról, hogy **értesítéseket** küldünk a kliensnek, miközben egy eszköz feldolgozza a kérést. Ezek az értesítések tartalmazhatnak előrehaladási frissítéseket, naplókat vagy egyéb eseményeket.

### Hogyan működik?

A fő eredmény továbbra is egyetlen válaszként érkezik. Azonban az értesítések külön üzenetként küldhetők a feldolgozás során, így valós időben frissítik a klienst. A kliensnek képesnek kell lennie kezelni és megjeleníteni ezeket az értesítéseket.

## Mi az az értesítés?

Mondtuk, hogy "értesítés" – mit jelent ez az MCP kontextusában?

Az értesítés egy üzenet, amit a szerver küld a kliensnek, hogy tájékoztassa a folyamat állapotáról, előrehaladásáról vagy egyéb eseményekről egy hosszú ideig tartó művelet során. Az értesítések növelik az átláthatóságot és javítják a felhasználói élményt.

Például a kliensnek értesítést kell küldenie, miután megtörtént az első kézfogás a szerverrel.

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

A naplózás működéséhez a szervernek engedélyeznie kell ezt a funkciót/képességet az alábbi módon:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Az SDK-tól függően a naplózás alapértelmezés szerint engedélyezett lehet, vagy explicit módon kell bekapcsolni a szerver konfigurációjában.

Különböző típusú értesítések léteznek:

| Szint      | Leírás                        | Példa használati eset          |
|------------|------------------------------|-------------------------------|
| debug      | Részletes hibakeresési információk | Függvény belépési/kilépési pontok |
| info       | Általános tájékoztató üzenetek | Művelet előrehaladásának frissítése |
| notice     | Normál, de jelentős események | Konfigurációs változások       |
| warning    | Figyelmeztető állapotok       | Elavult funkció használata     |
| error      | Hibás állapotok               | Művelet sikertelensége         |
| critical   | Kritikus állapotok            | Rendszerkomponens meghibásodás |
| alert      | Azonnali beavatkozás szükséges | Adatkorrupt állapot észlelése  |
| emergency  | A rendszer használhatatlan    | Teljes rendszerösszeomlás      |

## Értesítések megvalósítása az MCP-ben

Az MCP-ben az értesítések megvalósításához mind a szerver, mind a kliens oldalon fel kell készülni a valós idejű frissítések kezelésére. Ez lehetővé teszi, hogy alkalmazásod azonnali visszajelzést adjon a felhasználóknak hosszú ideig tartó műveletek közben.

### Szerver oldali: Értesítések küldése

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

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` szállítás használata:

```python
mcp.run(transport="streamable-http")
```

</details>

### Kliens oldali: Értesítések fogadása

A kliensnek meg kell valósítania egy üzenetkezelőt, amely feldolgozza és megjeleníti az értesítéseket érkezésük pillanatában.

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` használatos, és a kliens megvalósít egy üzenetkezelőt az értesítések feldolgozására.

## Előrehaladási értesítések és forgatókönyvek

Ez a szakasz bemutatja az előrehaladási értesítések fogalmát az MCP-ben, miért fontosak, és hogyan lehet őket megvalósítani Streamable HTTP segítségével. Találsz itt egy gyakorlati feladatot is, hogy elmélyítsd a tudásodat.

Az előrehaladási értesítések valós idejű üzenetek, amelyeket a szerver küld a kliensnek hosszú ideig tartó műveletek közben. Ahelyett, hogy a folyamat végéig várnánk, a szerver folyamatosan tájékoztatja a klienst az aktuális állapotról. Ez növeli az átláthatóságot, javítja a felhasználói élményt, és megkönnyíti a hibakeresést.

**Példa:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Miért használjunk előrehaladási értesítéseket?

Az előrehaladási értesítések több okból is fontosak:

- **Jobb felhasználói élmény:** A felhasználók látják a frissítéseket a munka előrehaladtával, nem csak a végén.
- **Valós idejű visszajelzés:** A kliensek megjeleníthetnek folyamatjelző sávokat vagy naplókat, így az alkalmazás reagálónak tűnik.
- **Könnyebb hibakeresés és monitorozás:** Fejlesztők és felhasználók láthatják, hol lassul vagy akad el egy folyamat.

### Hogyan valósítsuk meg az előrehaladási értesítéseket?

Így lehet megvalósítani az előrehaladási értesítéseket az MCP-ben:

- **Szerveren:** Használd a `ctx.info()` or `ctx.log()` metódusokat, hogy minden feldolgozott elemről értesítést küldj. Ez az üzenet a fő eredmény elkészülte előtt érkezik.
- **Kliensen:** Valósíts meg egy üzenetkezelőt, amely figyeli és megjeleníti az értesítéseket, amint azok megérkeznek. Ez a kezelő megkülönbözteti az értesítéseket a végső eredménytől.

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

## Biztonsági megfontolások

HTTP-alapú szállításokkal működő MCP szerverek megvalósításakor a biztonság kiemelten fontos, többféle támadási felület és védekezési mechanizmus alapos figyelembevételét igényli.

### Áttekintés

A biztonság kritikus, amikor MCP szervereket teszünk elérhetővé HTTP-n keresztül. A Streamable HTTP új támadási felületeket nyit meg, ezért gondos konfiguráció szükséges.

### Főbb pontok
- **Origin fejléc ellenőrzése**: Mindig ellenőrizd a `Origin` fejlécet, hogy csak megbízható források férjenek hozzá.
- **Hitelesítés és engedélyezés**: Biztosítsd, hogy csak jogosult kliensek tudjanak csatlakozni.
- **Titkosítás használata**: Mindig HTTPS-t használj az adatok védelmére.
- **Üzenetkezelő megvalósítása**: A kliens oldalon valósíts meg egy kezelőt az értesítések feldolgozására.
- **Kompatibilitás tesztelése**: Ellenőrizd, hogy az új megoldás kompatibilis legyen a meglévő eszközökkel és munkafolyamatokkal.

### Kompatibilitás megőrzése

Ajánlott a migráció során fenntartani a kompatibilitást a meglévő SSE kliensekkel. Néhány stratégia:

- Támogathatod mind az SSE, mind a Streamable HTTP szállítást különböző végpontokon.
- Fokozatosan migrálhatod a klienseket az új szállításra.

### Kihívások

A migráció során figyelni kell a következőkre:

- Minden kliens frissítésének biztosítása.
- Az értesítések kézbesítésének eltéréseinek kezelése.

### Feladat: Építsd meg saját streaming MCP alkalmazásodat

**Forgatókönyv:**
Építs egy MCP szervert és klienst, ahol a szerver egy lista elemeit (pl. fájlokat vagy dokumentumokat) dolgozza fel, és minden feldolgozott elemről értesítést küld. A kliens valós időben jelenítse meg az értesítéseket.

**Lépések:**

1. Készíts egy szerver oldali eszközt, amely feldolgoz egy listát és értesítéseket küld minden elem feldolgozásáról.
2. Készíts egy kliens oldali üzenetkezelőt, amely megjeleníti az értesítéseket valós időben.
3. Teszteld a megvalósítást úgy, hogy egyszerre futtatod a szervert és a klienst, és figyeled az értesítéseket.

[Megoldás](./solution/README.md)

## További olvasmányok és követ

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.