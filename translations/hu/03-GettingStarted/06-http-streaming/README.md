<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-10T16:22:34+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hu"
}
-->
# HTTPS Streaming a Model Context Protocol-lal (MCP)

Ez a fejezet átfogó útmutatót nyújt a biztonságos, skálázható és valós idejű streaming megvalósításához a Model Context Protocol (MCP) használatával HTTPS-en keresztül. Bemutatja a streaming motivációját, a rendelkezésre álló szállítási mechanizmusokat, hogyan valósítható meg streamelhető HTTP MCP-ben, a biztonsági legjobb gyakorlatokat, az SSE-ről való átállást, valamint gyakorlati útmutatást saját streaming MCP alkalmazások építéséhez.

## Szállítási mechanizmusok és streaming MCP-ben

Ebben a részben megvizsgáljuk az MCP-ben elérhető különböző szállítási mechanizmusokat, és azok szerepét a valós idejű kommunikáció streaming képességeinek biztosításában kliens és szerver között.

### Mi az a szállítási mechanizmus?

A szállítási mechanizmus meghatározza, hogyan cserélődnek az adatok a kliens és a szerver között. Az MCP többféle szállítási típust támogat, hogy különböző környezetekhez és igényekhez igazodjon:

- **stdio**: Standard bemenet/kimenet, helyi és parancssori eszközökhöz alkalmas. Egyszerű, de nem webes vagy felhős környezethez.
- **SSE (Server-Sent Events)**: Lehetővé teszi a szerverek számára, hogy valós idejű frissítéseket küldjenek HTTP-n keresztül a klienseknek. Jó webes felületekhez, de korlátozott skálázhatóságú és rugalmasságú.
- **Streamable HTTP**: Modern, HTTP-alapú streaming szállítás, támogatja az értesítéseket és jobb skálázhatóságot. Ajánlott a legtöbb éles és felhős környezethez.

### Összehasonlító táblázat

Nézd meg az alábbi összehasonlító táblázatot, hogy megértsd a különbségeket ezek között a szállítási mechanizmusok között:

| Szállítás          | Valós idejű frissítések | Streaming | Skálázhatóság | Használati eset          |
|--------------------|------------------------|-----------|---------------|--------------------------|
| stdio              | Nem                    | Nem       | Alacsony      | Helyi CLI eszközök       |
| SSE                | Igen                   | Igen      | Közepes       | Web, valós idejű frissítések |
| Streamable HTTP    | Igen                   | Igen      | Magas         | Felhő, több kliens       |

> **Tip:** A megfelelő szállítási mód kiválasztása befolyásolja a teljesítményt, skálázhatóságot és a felhasználói élményt. A **Streamable HTTP** ajánlott modern, skálázható és felhőbarát alkalmazásokhoz.

Figyeld meg a stdio és SSE szállításokat, amelyeket az előző fejezetekben láttál, és hogy ebben a fejezetben a streamelhető HTTP a tárgyalt szállítás.

## Streaming: Fogalmak és motiváció

A streaming alapvető fogalmainak és motivációinak megértése elengedhetetlen a hatékony valós idejű kommunikációs rendszerek megvalósításához.

A **streaming** egy hálózati programozási technika, amely lehetővé teszi, hogy az adatokat kis, kezelhető darabokban vagy eseménysorozatként küldjük és fogadjuk, ahelyett, hogy az egész válasz elkészülésére várnánk. Ez különösen hasznos:

- Nagy fájlok vagy adathalmazok esetén.
- Valós idejű frissítésekhez (pl. chat, folyamatjelző sávok).
- Hosszú ideig futó számításoknál, amikor szeretnénk a felhasználót folyamatosan tájékoztatni.

Íme, amit a streamingről tudni érdemes magas szinten:

- Az adat fokozatosan érkezik, nem egyszerre.
- A kliens az adatok érkezésekor azonnal feldolgozhatja azokat.
- Csökkenti az észlelt késleltetést és javítja a felhasználói élményt.

### Miért használjunk streaminget?

A streaming használatának okai a következők:

- A felhasználók azonnali visszajelzést kapnak, nem csak a végén.
- Lehetővé teszi a valós idejű alkalmazásokat és reszponzív felhasználói felületeket.
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

Ez a példa bemutatja, hogy a szerver egy sor üzenetet küld a kliensnek, amint azok elérhetővé válnak, ahelyett, hogy az összes üzenet elkészülésére várna.

**Hogyan működik:**
- A szerver minden üzenetet akkor küld, amikor az elkészül.
- A kliens fogadja és kiírja az érkező adatdarabokat.

**Követelmények:**
- A szervernek streaming választ kell használnia (pl. `StreamingResponse` FastAPI-ban).
- A kliensnek streamként kell feldolgoznia a választ (`stream=True` a requests-ben).
- A Content-Type általában `text/event-stream` vagy `application/octet-stream`.

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
- Spring Boot reaktív stack-et használ `Flux`-szal a streaminghez
- `ServerSentEvent` strukturált esemény streaminget biztosít eseménytípusokkal
- `WebClient` `bodyToFlux()`-szal reaktív streaming fogyasztást tesz lehetővé
- `delayElements()` szimulálja az események közötti feldolgozási időt
- Az események típusokat kaphatnak (`info`, `result`) a jobb klienskezelés érdekében

</details>

### Összehasonlítás: Klasszikus streaming vs MCP streaming

A különbségek a "klasszikus" streaming és az MCP streaming között az alábbi táblázatban foglalhatók össze:

| Jellemző               | Klasszikus HTTP streaming       | MCP streaming (értesítések)         |
|------------------------|--------------------------------|------------------------------------|
| Fő válasz              | Darabolt (chunked)              | Egyetlen, a végén                   |
| Folyamatjelentések     | Adatdarabokként küldve          | Értesítésekként küldve              |
| Kliens követelmények   | Stream feldolgozása szükséges   | Üzenetkezelő implementálása szükséges |
| Használati eset        | Nagy fájlok, AI token stream-ek | Folyamatjelentések, naplók, valós idejű visszajelzés |

### Fontosabb különbségek

Továbbá, itt néhány kulcsfontosságú különbség:

- **Kommunikációs minta:**
   - Klasszikus HTTP streaming: Egyszerű chunked átvitel az adatok darabokban küldéséhez
   - MCP streaming: Strukturált értesítési rendszer JSON-RPC protokollal

- **Üzenetformátum:**
   - Klasszikus HTTP: Egyszerű szöveges darabok új sorokkal
   - MCP: Strukturált LoggingMessageNotification objektumok metaadatokkal

- **Kliens megvalósítás:**
   - Klasszikus HTTP: Egyszerű kliens, amely feldolgozza a streaming válaszokat
   - MCP: Összetettebb kliens, amely üzenetkezelőt használ különböző üzenettípusok feldolgozására

- **Folyamatjelentések:**
   - Klasszikus HTTP: A folyamatjelentés a fő válasz része
   - MCP: A folyamatjelentés külön értesítési üzenetekben érkezik, míg a fő válasz a végén jön

### Ajánlások

Néhány javaslat a klasszikus streaming (például a fent bemutatott `/stream` végpont) és az MCP streaming közötti választáshoz:

- **Egyszerű streaming igényekhez:** A klasszikus HTTP streaming egyszerűbb megvalósítani, és elegendő az alapvető streaming igényekhez.

- **Összetett, interaktív alkalmazásokhoz:** Az MCP streaming strukturáltabb megközelítést kínál gazdagabb metaadatokkal és az értesítések és a végső eredmény szétválasztásával.

- **AI alkalmazásokhoz:** Az MCP értesítési rendszere különösen hasznos hosszú ideig futó AI feladatoknál, ahol fontos a felhasználók folyamatos tájékoztatása.

## Streaming MCP-ben

Rendben, eddig láttál néhány ajánlást és összehasonlítást a klasszikus streaming és az MCP streaming között. Most nézzük meg részletesen, hogyan használhatod ki a streaminget MCP-ben.

Az MCP keretrendszeren belüli streaming működésének megértése elengedhetetlen olyan reszponzív alkalmazások építéséhez, amelyek valós idejű visszajelzést adnak a felhasználóknak hosszú ideig tartó műveletek során.

Az MCP-ben a streaming nem arról szól, hogy a fő választ darabokban küldjük, hanem arról, hogy **értesítéseket** küldünk a kliensnek, miközben egy eszköz feldolgoz egy kérést. Ezek az értesítések tartalmazhatnak folyamatjelentéseket, naplókat vagy egyéb eseményeket.

### Hogyan működik?

A fő eredmény továbbra is egyetlen válaszként érkezik. Azonban az értesítések külön üzenetként küldhetők a feldolgozás során, így valós időben frissítik a klienst. A kliensnek képesnek kell lennie kezelni és megjeleníteni ezeket az értesítéseket.

## Mi az az értesítés?

Mondtuk, hogy "értesítés" – mit jelent ez az MCP kontextusában?

Az értesítés egy olyan üzenet, amelyet a szerver küld a kliensnek, hogy tájékoztassa a folyamat állapotáról, előrehaladásáról vagy egyéb eseményekről egy hosszú ideig tartó művelet során. Az értesítések növelik az átláthatóságot és javítják a felhasználói élményt.

Például a kliensnek értesítést kell küldenie, amikor az első kézfogás (handshake) megtörtént a szerverrel.

Egy értesítés JSON üzenetként így néz ki:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Az értesítések az MCP-ben egy témához tartoznak, amit ["Logging"-nak](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) hívnak.

A naplózás működéséhez a szervernek engedélyeznie kell ezt a funkciót/képességet az alábbi módon:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Az SDK-tól függően a naplózás alapértelmezés szerint engedélyezve lehet, vagy explicit módon kell bekapcsolni a szerver konfigurációjában.

Különböző értesítéstípusok léteznek:

| Szint      | Leírás                        | Példahasználat                |
|------------|------------------------------|------------------------------|
| debug      | Részletes hibakeresési információk | Függvény belépési/kilépési pontok |
| info       | Általános információs üzenetek | Művelet előrehaladásának frissítései |
| notice     | Normál, de jelentős események | Konfigurációs változások      |
| warning    | Figyelmeztető állapotok       | Elavult funkció használata    |
| error      | Hibás állapotok               | Művelet sikertelenségei       |
| critical   | Kritikus állapotok            | Rendszerkomponens hibák       |
| alert      | Azonnali beavatkozás szükséges | Adatkorrupt állapot észlelése |
| emergency  | A rendszer használhatatlan    | Teljes rendszerleállás        |

## Értesítések megvalósítása MCP-ben

Az értesítések megvalósításához MCP-ben mind a szerver, mind a kliens oldalon be kell állítani a valós idejű frissítések kezelését. Ez lehetővé teszi, hogy az alkalmazás azonnali visszajelzést adjon a felhasználóknak hosszú ideig tartó műveletek során.

### Szerveroldal: Értesítések küldése

Kezdjük a szerver oldallal. MCP-ben olyan eszközöket definiálsz, amelyek képesek értesítéseket küldeni a kérések feldolgozása közben. A szerver a kontextus objektumot (általában `ctx`) használja az üzenetek kliensnek küldésére.

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

A fenti példában a `process_files` eszköz három értesítést küld a kliensnek, miközben feldolgozza az egyes fájlokat. A `ctx.info()` metódust használja információs üzenetek küldésére.

</details>

Ezen felül, hogy az értesítések működjenek, győződj meg róla, hogy a szerver streaming szállítást használ (például `streamable-http`), és a kliens üzenetkezelőt valósít meg az értesítések feldolgozására. Így állíthatod be a szervert a `streamable-http` szállítás használatára:

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

Ebben a .NET példában a `ProcessFiles` eszköz a `Tool` attribútummal van ellátva, és három értesítést küld a kliensnek, miközben feldolgozza az egyes fájlokat. A `ctx.Info()` metódust használja információs üzenetek küldésére.

Az értesítések engedélyezéséhez a .NET MCP szerveredben győződj meg róla, hogy streaming szállítást használsz:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Kliensoldal: Értesítések fogadása

A kliensnek üzenetkezelőt kell megvalósítania, amely feldolgozza és megjeleníti az értesítéseket, amint azok megérkeznek.

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

A fenti kódban a `message_handler` függvény ellenőrzi, hogy az érkező üzenet értesítés-e. Ha igen, kiírja az értesítést; különben normál szerverüzenetként dolgozza fel. Figyeld meg, hogy a `ClientSession` inicializálásakor a `message_handler` van megadva az értesítések kezelésére.

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

Ebben a .NET példában a `MessageHandler` függvény ellenőrzi, hogy az érkező üzenet értesítés-e. Ha igen, kiírja az értesítést; különben normál szerverüzenetként dolgozza fel. A `ClientSession` a `ClientSessionOptions` segítségével inicializálódik az üzenetkezelővel.

</details>

Az értesítések engedélyezéséhez győződj meg róla, hogy a szerver streaming szállítást használ (például `streamable-http`), és a kliens üzenetkezelőt valósít meg az értesítések feldolgozására.

## Folyamatjelentések és használati esetek

Ez a rész bemutatja a folyamatjelentések fogalmát MCP-ben, miért fontosak, és hogyan valósíthatók meg Streamable HTTP segítségével. Találsz egy gyakorlati feladatot is a megértés elmélyítésére.

A folyamatjelentések valós idejű üzenetek, amelyeket a

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

HTTP-alapú transzportokkal megvalósított MCP szerverek esetén a biztonság kiemelt fontosságú, amely többféle támadási vektor és védekezési mechanizmus alapos figyelembevételét igényli.

### Áttekintés

A biztonság kulcsfontosságú, ha MCP szervereket teszünk elérhetővé HTTP-n keresztül. A streamelhető HTTP új támadási felületeket hoz, ezért gondos konfiguráció szükséges.

### Főbb pontok
- **Origin fejléc ellenőrzése**: Mindig ellenőrizd az `Origin` fejlécet, hogy megakadályozd a DNS rebinding támadásokat.
- **Localhost kötés**: Fejlesztéshez köss a szervereket `localhost`-hoz, hogy ne legyenek nyilvánosan elérhetők.
- **Hitelesítés**: Éles környezetben alkalmazz hitelesítést (pl. API kulcsok, OAuth).
- **CORS**: Állíts be Cross-Origin Resource Sharing (CORS) szabályokat a hozzáférés korlátozására.
- **HTTPS**: Éles környezetben használj HTTPS-t a forgalom titkosításához.

### Legjobb gyakorlatok
- Soha ne bízz meg érkező kérésekben validálás nélkül.
- Naplózz és figyelj minden hozzáférést és hibát.
- Rendszeresen frissítsd a függőségeket a biztonsági rések javítása érdekében.

### Kihívások
- A biztonság és a fejlesztési egyszerűség egyensúlyának megtalálása
- Különböző kliens környezetekkel való kompatibilitás biztosítása


## Frissítés SSE-ről Streamable HTTP-re

Azoknak az alkalmazásoknak, amelyek jelenleg Server-Sent Events (SSE) technológiát használnak, a Streamable HTTP-re való áttérés fejlettebb lehetőségeket és hosszabb távú fenntarthatóságot kínál az MCP megvalósításokhoz.

### Miért érdemes frissíteni?

Két fő ok szól az SSE-ről Streamable HTTP-re való váltás mellett:

- A Streamable HTTP jobb skálázhatóságot, kompatibilitást és gazdagabb értesítési támogatást nyújt, mint az SSE.
- Ez az ajánlott transzport új MCP alkalmazásokhoz.

### Migrációs lépések

Így válthatsz SSE-ről Streamable HTTP-re az MCP alkalmazásaidban:

- **Frissítsd a szerver kódot**, hogy a `mcp.run()`-ban `transport="streamable-http"` legyen.
- **Frissítsd a kliens kódot**, hogy az SSE kliens helyett `streamablehttp_client`-et használjon.
- **Valósíts meg egy üzenetkezelőt** a kliensben az értesítések feldolgozásához.
- **Teszteld a kompatibilitást** a meglévő eszközökkel és munkafolyamatokkal.

### Kompatibilitás fenntartása

Ajánlott a migráció során megőrizni a kompatibilitást a meglévő SSE kliensekkel. Néhány megoldás:

- Mindkét transzportot támogathatod, ha különböző végpontokon futtatod őket.
- Fokozatosan migráld a klienseket az új transzportra.

### Kihívások

A migráció során figyelj az alábbiakra:

- Minden kliens frissítésének biztosítása
- Az értesítések kézbesítésében lévő különbségek kezelése

## Biztonsági szempontok

A biztonság kiemelt prioritás kell legyen bármilyen szerver megvalósításakor, különösen HTTP-alapú transzportok, például a Streamable HTTP használatakor az MCP-ben.

HTTP-alapú transzportokkal megvalósított MCP szerverek esetén a biztonság kiemelt fontosságú, amely többféle támadási vektor és védekezési mechanizmus alapos figyelembevételét igényli.

### Áttekintés

A biztonság kulcsfontosságú, ha MCP szervereket teszünk elérhetővé HTTP-n keresztül. A Streamable HTTP új támadási felületeket hoz, ezért gondos konfiguráció szükséges.

Néhány fontos biztonsági szempont:

- **Origin fejléc ellenőrzése**: Mindig ellenőrizd az `Origin` fejlécet, hogy megakadályozd a DNS rebinding támadásokat.
- **Localhost kötés**: Fejlesztéshez köss a szervereket `localhost`-hoz, hogy ne legyenek nyilvánosan elérhetők.
- **Hitelesítés**: Éles környezetben alkalmazz hitelesítést (pl. API kulcsok, OAuth).
- **CORS**: Állíts be Cross-Origin Resource Sharing (CORS) szabályokat a hozzáférés korlátozására.
- **HTTPS**: Éles környezetben használj HTTPS-t a forgalom titkosításához.

### Legjobb gyakorlatok

Ezen felül az MCP streaming szerver biztonságának megvalósításakor érdemes követni az alábbi legjobb gyakorlatokat:

- Soha ne bízz meg érkező kérésekben validálás nélkül.
- Naplózz és figyelj minden hozzáférést és hibát.
- Rendszeresen frissítsd a függőségeket a biztonsági rések javítása érdekében.

### Kihívások

Az MCP streaming szerverek biztonságának megvalósítása során az alábbi kihívásokkal találkozhatsz:

- A biztonság és a fejlesztési egyszerűség egyensúlyának megtalálása
- Különböző kliens környezetekkel való kompatibilitás biztosítása

### Feladat: Építsd meg saját streaming MCP alkalmazásodat

**Forgatókönyv:**
Készíts egy MCP szervert és klienst, ahol a szerver egy elemlistát (pl. fájlok vagy dokumentumok) dolgoz fel, és minden feldolgozott elemhez értesítést küld. A kliensnek valós időben kell megjelenítenie az értesítéseket.

**Lépések:**

1. Valósíts meg egy szerver eszközt, amely feldolgoz egy listát és értesítéseket küld minden elemhez.
2. Valósíts meg egy klienst, amely üzenetkezelővel valós időben jeleníti meg az értesítéseket.
3. Teszteld a megvalósítást úgy, hogy egyszerre futtatod a szervert és a klienst, és figyeled az értesítéseket.

[Solution](./solution/README.md)

## További olvasmányok és következő lépések

Ahhoz, hogy tovább mélyítsd MCP streaming ismereteidet és fejlettebb alkalmazásokat építs, ez a rész további forrásokat és javasolt következő lépéseket kínál.

### További olvasmányok

- [Microsoft: Bevezetés a HTTP streamingbe](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS az ASP.NET Core-ban](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Mi következik?

- Próbálj meg fejlettebb MCP eszközöket építeni, amelyek streaminget használnak valós idejű elemzéshez, csevegéshez vagy együttműködő szerkesztéshez.
- Fedezd fel az MCP streaming integrálását frontend keretrendszerekkel (React, Vue stb.) az élő UI frissítésekhez.
- Következő: [AI Toolkit használata VSCode-ban](../07-aitk/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.