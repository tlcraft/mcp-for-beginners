<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:26:09+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hu"
}
-->
# HTTPS Streaming a Model Context Protocol-lal (MCP)

Ez a fejezet átfogó útmutatót nyújt a biztonságos, skálázható és valós idejű streaming megvalósításához a Model Context Protocol (MCP) használatával HTTPS-en keresztül. Bemutatja a streaming motivációját, a rendelkezésre álló szállítási mechanizmusokat, a streamelhető HTTP megvalósítását MCP-ben, a biztonsági legjobb gyakorlatokat, az SSE-ről való migrációt, valamint gyakorlati útmutatót saját streaming MCP alkalmazások építéséhez.

## Szállítási mechanizmusok és streaming az MCP-ben

Ebben a szakaszban áttekintjük az MCP-ben elérhető különböző szállítási mechanizmusokat és azok szerepét a valós idejű kommunikáció streaming képességeinek biztosításában kliens és szerver között.

### Mi az a szállítási mechanizmus?

A szállítási mechanizmus meghatározza, hogyan cserélődnek az adatok a kliens és a szerver között. Az MCP többféle szállítási típust támogat, hogy különböző környezetekhez és igényekhez igazodjon:

- **stdio**: Standard bemenet/kimenet, helyi és parancssoros eszközökhöz ideális. Egyszerű, de nem alkalmas webes vagy felhő alapú használatra.
- **SSE (Server-Sent Events)**: Lehetővé teszi a szerverek számára, hogy valós idejű frissítéseket küldjenek a klienseknek HTTP-n keresztül. Jó webes felületekhez, de korlátozott skálázhatóságú és rugalmasságú.
- **Streamable HTTP**: Modern, HTTP-alapú streaming szállítás, támogatja az értesítéseket és jobb skálázhatóságot. Ajánlott a legtöbb éles és felhőalapú környezethez.

### Összehasonlító táblázat

Nézd meg az alábbi összehasonlító táblázatot, hogy megértsd a különbségeket ezek között a szállítási mechanizmusok között:

| Szállítás          | Valós idejű frissítések | Streaming | Skálázhatóság | Felhasználási eset       |
|--------------------|------------------------|-----------|---------------|-------------------------|
| stdio              | Nem                    | Nem       | Alacsony      | Helyi parancssori eszközök |
| SSE                | Igen                   | Igen      | Közepes       | Web, valós idejű frissítések |
| Streamable HTTP    | Igen                   | Igen      | Magas         | Felhő, több kliens      |

> **Tip:** A megfelelő szállítási mód kiválasztása befolyásolja a teljesítményt, skálázhatóságot és a felhasználói élményt. A **Streamable HTTP** ajánlott modern, skálázható és felhőbarát alkalmazásokhoz.

Vedd észre a stdio és SSE szállításokat, amelyeket az előző fejezetekben bemutattunk, és hogy ebben a fejezetben a streamelhető HTTP szállításról van szó.

## Streaming: Fogalmak és motiváció

A streaming alapvető fogalmainak és motivációinak megértése elengedhetetlen a hatékony valós idejű kommunikációs rendszerek megvalósításához.

A **streaming** egy hálózati programozási technika, amely lehetővé teszi az adatok kis, kezelhető darabokban vagy eseménysorozatként történő küldését és fogadását, ahelyett, hogy az egész válaszra várnánk. Ez különösen hasznos:

- Nagy fájlok vagy adathalmazok esetén.
- Valós idejű frissítésekhez (pl. chat, folyamatjelzők).
- Hosszú futású számításoknál, amikor szeretnénk tájékoztatni a felhasználót.

Íme, amit a streamingről tudnod kell magas szinten:

- Az adat fokozatosan érkezik, nem egyszerre.
- A kliens az érkezéskor tudja feldolgozni az adatot.
- Csökkenti a látszólagos késleltetést és javítja a felhasználói élményt.

### Miért érdemes streamelni?

A streaming használatának okai a következők:

- A felhasználók azonnali visszajelzést kapnak, nem csak a végén.
- Valós idejű alkalmazások és reszponzív felhasználói felületek létrehozása.
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

Ez a példa bemutatja, hogyan küld a szerver egy sor üzenetet a kliensnek, ahogy azok elérhetővé válnak, ahelyett, hogy az összes üzenetre egyszerre várna.

**Hogyan működik:**
- A szerver minden üzenetet akkor küld, amikor az elkészül.
- A kliens fogadja és kiírja a darabokat, ahogy érkeznek.

**Elvárások:**
- A szervernek streaming választ kell használnia (pl. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Szerver (Java, Spring Boot és Server-Sent Events használatával):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**Kliens (Java, Spring WebFlux WebClient):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Java megvalósítási megjegyzések:**
- A Spring Boot reaktív stack-jét használja `Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream` helyett MCP streamelés választásával.

- **Egyszerű streaming igényekhez:** A klasszikus HTTP streaming egyszerűbb és elegendő az alapvető streaming igényekhez.

- **Összetett, interaktív alkalmazásokhoz:** Az MCP streaming strukturáltabb megközelítést kínál, gazdagabb metaadatokkal és értesítések, valamint végső eredmény elkülönítésével.

- **AI alkalmazásokhoz:** Az MCP értesítési rendszere különösen hasznos hosszú futású AI feladatoknál, ahol szeretnénk tájékoztatni a felhasználókat a folyamat állapotáról.

## Streaming az MCP-ben

Most, hogy láttál néhány ajánlást és összehasonlítást a klasszikus streaming és az MCP streaming között, nézzük meg részletesen, hogyan használhatod ki a streaminget az MCP-ben.

Az MCP keretrendszeren belüli streaming működésének megértése kulcsfontosságú olyan reszponzív alkalmazások építéséhez, amelyek valós idejű visszajelzést adnak a felhasználóknak hosszú futású műveletek során.

Az MCP-ben a streaming nem arról szól, hogy a fő választ darabokban küldjük, hanem arról, hogy a kliensnek **értesítéseket** küldünk, miközben egy eszköz feldolgoz egy kérést. Ezek az értesítések tartalmazhatnak előrehaladási frissítéseket, naplóbejegyzéseket vagy egyéb eseményeket.

### Hogyan működik?

A fő eredmény továbbra is egyetlen válaszként érkezik. Azonban az értesítések külön üzenetként küldhetők a feldolgozás során, így valós időben frissítik a klienst. A kliensnek képesnek kell lennie kezelni és megjeleníteni ezeket az értesítéseket.

## Mi az az értesítés?

Mondtuk, hogy "értesítés" – mit jelent ez az MCP kontextusában?

Az értesítés egy olyan üzenet, amelyet a szerver küld a kliensnek, hogy tájékoztassa a folyamat állapotáról, előrehaladásáról vagy egyéb eseményekről egy hosszú futású művelet közben. Az értesítések javítják az átláthatóságot és a felhasználói élményt.

Például egy kliensnek értesítést kell küldenie, amikor az első kézfogás (handshake) megtörtént a szerverrel.

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

Az értesítések egy MCP témához tartoznak, amit ["Logging"-nek](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) hívnak.

A naplózás működéséhez a szervernek engedélyeznie kell ezt funkcióként/képességként így:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Az SDK-tól függően a naplózás alapértelmezetten engedélyezett lehet, vagy explicit módon be kell kapcsolni a szerver konfigurációjában.

Különböző értesítés típusok léteznek:

| Szint      | Leírás                        | Példa használati eset           |
|------------|------------------------------|--------------------------------|
| debug      | Részletes hibakeresési információk | Függvény belépési/kilépési pontok |
| info       | Általános tájékoztató üzenetek | Művelet előrehaladási frissítések |
| notice     | Normál, de jelentős események  | Konfigurációs változások        |
| warning    | Figyelmeztető állapotok       | Elavult funkció használata      |
| error      | Hibás állapotok               | Művelet sikertelenségek         |
| critical   | Kritikus állapotok            | Rendszerkomponens hibák         |
| alert      | Azonnali intézkedést igényel  | Adatkárosodás észlelése         |
| emergency  | A rendszer használhatatlan    | Teljes rendszerösszeomlás       |

## Értesítések megvalósítása az MCP-ben

Az MCP-ben az értesítések megvalósításához a szerver és a kliens oldalon is be kell állítani a valós idejű frissítések kezelését. Ez lehetővé teszi, hogy az alkalmazás azonnali visszajelzést adjon a felhasználóknak hosszú futású műveletek alatt.

### Szerver oldal: Értesítések küldése

Kezdjük a szerver oldallal. Az MCP-ben olyan eszközöket definiálsz, amelyek képesek értesítéseket küldeni a kérések feldolgozása közben. A szerver a context objektumot (általában `ctx`) használja az üzenetek kliensnek küldésére.

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

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` szállítást használja:

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

Ebben a .NET példában a `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` metódus információs üzenetek küldésére szolgál.

Az értesítések engedélyezéséhez a .NET MCP szerveredben győződj meg róla, hogy streaming szállítást használsz:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Kliens oldal: Értesítések fogadása

A kliensnek üzenetkezelőt kell megvalósítania, amely kezeli és megjeleníti az értesítéseket, amint azok megérkeznek.

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

A fenti kódban a `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` kezeli a beérkező értesítéseket.

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

Ebben a .NET példában a `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` és a kliens üzenetkezelőt valósít meg az értesítések feldolgozásához.

## Előrehaladási értesítések és forgatókönyvek

Ez a szakasz bemutatja az előrehaladási értesítések fogalmát az MCP-ben, miért fontosak, és hogyan lehet őket megvalósítani Streamable HTTP használatával. Találsz egy gyakorlati feladatot is a megértésed elmélyítésére.

Az előrehaladási értesítések valós idejű üzenetek, amelyeket a szerver küld a kliensnek hosszú futású műveletek alatt. Ahelyett, hogy megvárnánk a teljes folyamat befejezését, a szerver folyamatosan tájékoztatja a klienst az aktuális állapotról. Ez javítja az átláthatóságot, a felhasználói élményt és megkönnyíti a hibakeresést.

**Példa:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Miért érdemes előrehaladási értesítéseket használni?

Az előrehaladási értesítések több okból is fontosak:

- **Jobb felhasználói élmény:** A felhasználók látják a folyamat előrehaladását, nem csak a végén kapnak visszajelzést.
- **Valós idejű visszajelzés:** A kliensek megjeleníthetnek folyamatjelzőket vagy naplókat, így az alkalmazás reszponzívnak tűnik.
- **Könnyebb hibakeresés és monitorozás:** Fejlesztők és felhasználók láthatják, hol akadhat el vagy lassulhat le egy folyamat.

### Hogyan valósítsuk meg az előrehaladási értesítéseket?

Így valósíthatod meg az előrehaladási értesítéseket MCP-ben:

- **Szerver oldalon:** Használd a `ctx.info()` or `ctx.log()` metódusokat az értesítések küldésére minden feldolgozott elem után. Ez üzenetet küld a kliensnek még a fő eredmény elkészülte előtt.
- **Kliens oldalon:** Valósíts meg egy üzenetkezelőt, amely figyeli és megjeleníti az értesítéseket, amint azok érkeznek. Ez az üzenetkezelő megkülönbözteti az értesítéseket a végső eredménytől.

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

Az MCP szerverek HTTP-alapú szállításokkal történő megvalósítása során a biztonság kiemelten fontos, és több támadási vektorral, valamint védekezési mechanizmussal kell számolni.

### Áttekintés

A biztonság kritikus, ha MCP szervereket teszünk elérhetővé HTTP-n keresztül. A Streamable HTTP új támadási felületeket nyit, ezért gondos konfiguráció szükséges.

### Főbb pontok
- **Origin fejléc ellenőrzése:** Mindig ellenőrizd az `Origin` fejlécet a jogosult források listájához képest.
- **Hitelesítés és jogosultságkezelés:** Biztosítsd, hogy csak jogosult kliensek férjenek hozzá az MCP szerverhez.
- **Titkosított kommunikáció:** Használj HTTPS-t az adatok védelméhez.
- **Üzenetkezelő implementálása a kliens oldalon:** A kliens oldalon is legyen megfelelő üzenetkezelő az értesítések feldolgozására.
- **Teszteld a kompatibilitást:** Győződj meg arról, hogy a meglévő eszközökkel és munkafolyamatokkal kompatibilis a rendszer.

### Kompatibilitás fenntartása

Ajánlott a migráció során fenntartani a kompatibilitást a meglévő SSE kliense

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.