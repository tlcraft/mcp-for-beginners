<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "40b1bbffdb8ce6812bf6e701cad876b6",
  "translation_date": "2025-07-17T19:14:28+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hu"
}
-->
# HTTPS Streaming a Model Context Protocol-lal (MCP)

Ez a fejezet átfogó útmutatót nyújt a biztonságos, skálázható és valós idejű streaming megvalósításához a Model Context Protocol (MCP) használatával HTTPS-en keresztül. Bemutatja a streaming motivációját, a rendelkezésre álló szállítási mechanizmusokat, hogyan valósítható meg a streamelhető HTTP az MCP-ben, a biztonsági legjobb gyakorlatokat, az SSE-ről való átállást, valamint gyakorlati tanácsokat saját streaming MCP alkalmazások építéséhez.

## Szállítási mechanizmusok és streaming MCP-ben

Ebben a részben megvizsgáljuk az MCP-ben elérhető különböző szállítási mechanizmusokat, és azok szerepét a valós idejű kommunikáció streaming képességeinek biztosításában a kliens és a szerver között.

### Mi az a szállítási mechanizmus?

A szállítási mechanizmus meghatározza, hogyan cserélődnek az adatok a kliens és a szerver között. Az MCP többféle szállítási típust támogat, hogy különböző környezetekhez és igényekhez igazodjon:

- **stdio**: Standard input/output, helyi és CLI-alapú eszközökhöz alkalmas. Egyszerű, de nem megfelelő webes vagy felhőalapú használatra.
- **SSE (Server-Sent Events)**: Lehetővé teszi, hogy a szerver valós idejű frissítéseket küldjön a klienseknek HTTP-n keresztül. Jó webes felhasználói felületekhez, de korlátozott a skálázhatósága és rugalmassága.
- **Streamelhető HTTP**: Modern, HTTP-alapú streaming szállítás, amely értesítéseket és jobb skálázhatóságot támogat. Ajánlott a legtöbb produkciós és felhőalapú forgatókönyvhöz.

### Összehasonlító táblázat

Nézd meg az alábbi összehasonlító táblázatot, hogy megértsd a különbségeket ezek között a szállítási mechanizmusok között:

| Szállítás          | Valós idejű frissítések | Streaming | Skálázhatóság | Használati eset            |
|--------------------|-------------------------|-----------|--------------|----------------------------|
| stdio              | Nem                    | Nem       | Alacsony     | Helyi CLI eszközök         |
| SSE                | Igen                   | Igen      | Közepes      | Web, valós idejű frissítések |
| Streamelhető HTTP  | Igen                   | Igen      | Magas        | Felhő, több kliens         |

> **Tip:** A megfelelő szállítási mód kiválasztása befolyásolja a teljesítményt, a skálázhatóságot és a felhasználói élményt. A **Streamable HTTP** ajánlott modern, skálázható és felhőbarát alkalmazásokhoz.

Figyeld meg a korábbi fejezetekben bemutatott stdio és SSE szállításokat, valamint hogy ebben a fejezetben a streamelhető HTTP szállításról van szó.

## Streaming: Fogalmak és motiváció

A streaming alapvető fogalmainak és motivációinak megértése elengedhetetlen a hatékony valós idejű kommunikációs rendszerek megvalósításához.

A **streaming** egy hálózati programozási technika, amely lehetővé teszi, hogy az adatokat kis, kezelhető darabokban vagy eseménysorozatként küldjük és fogadjuk, ahelyett, hogy az egész válasz elkészülésére várnánk. Ez különösen hasznos:

- Nagy fájlok vagy adathalmazok esetén.
- Valós idejű frissítésekhez (pl. chat, folyamatjelző sávok).
- Hosszú futásidejű számításoknál, amikor folyamatosan tájékoztatni szeretnénk a felhasználót.

Íme, amit a streamingről tudni érdemes magas szinten:

- Az adatok fokozatosan érkeznek, nem egyszerre.
- A kliens az adatokat érkezéskor feldolgozhatja.
- Csökkenti az észlelt késleltetést és javítja a felhasználói élményt.

### Miért használjunk streaminget?

A streaming használatának okai a következők:

- A felhasználók azonnali visszajelzést kapnak, nem csak a végén.
- Lehetővé teszi a valós idejű alkalmazásokat és a reszponzív felhasználói felületeket.
- Hatékonyabb hálózati és számítási erőforrás-felhasználás.

### Egyszerű példa: HTTP streaming szerver és kliens

Íme egy egyszerű példa a streaming megvalósítására:

#### Python

**Szerver (Python, FastAPI és StreamingResponse használatával):**

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

**Kliens (Python, requests használatával):**

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

Ez a példa bemutatja, hogy a szerver hogyan küld egy sor üzenetet a kliensnek, amint azok elérhetővé válnak, ahelyett, hogy megvárná az összes üzenet elkészültét.

**Hogyan működik:**

- A szerver minden üzenetet elküld, amint az elkészül.
- A kliens minden érkező darabot fogad és kiír.

**Követelmények:**

- A szervernek streaming választ kell használnia (pl. `StreamingResponse` FastAPI-ben).
- A kliensnek a választ streamként kell feldolgoznia (`stream=True` a requests-ben).
- A Content-Type általában `text/event-stream` vagy `application/octet-stream`.

#### Java

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

**Kliens (Java, Spring WebFlux WebClient használatával):**

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

- A Spring Boot reaktív stackjét használja `Flux`-szal a streaminghez.
- A `ServerSentEvent` strukturált esemény streaminget biztosít eseménytípusokkal.
- A `WebClient` `bodyToFlux()`-szal lehetővé teszi a reaktív streaming fogyasztást.
- A `delayElements()` szimulálja az események közötti feldolgozási időt.
- Az események típusokkal rendelkezhetnek (`info`, `result`) a jobb klienskezelés érdekében.

### Összehasonlítás: Klasszikus streaming vs MCP streaming

A klasszikus streaming és az MCP streaming közötti különbségek az alábbiak szerint ábrázolhatók:

| Jellemző               | Klasszikus HTTP streaming       | MCP streaming (értesítések)         |
|------------------------|--------------------------------|------------------------------------|
| Fő válasz              | Darabolt                       | Egyetlen, a végén                   |
| Haladás frissítések    | Adatdarabokként küldve         | Értesítésekként küldve              |
| Kliens követelmények   | Stream feldolgozása szükséges  | Üzenetkezelő megvalósítása szükséges |
| Használati eset        | Nagy fájlok, AI token stream-ek | Haladás, naplók, valós idejű visszajelzés |

### Megfigyelt kulcsfontosságú különbségek

Továbbá, itt vannak a legfontosabb különbségek:

- **Kommunikációs minta:**
  - Klasszikus HTTP streaming: Egyszerű darabolt átvitelkódolást használ az adatok darabokban történő küldésére.
  - MCP streaming: Strukturált értesítési rendszert használ JSON-RPC protokollal.

- **Üzenetformátum:**
   - Klasszikus HTTP: Egyszerű szöveges darabok új sorokkal
   - MCP: Strukturált LoggingMessageNotification objektumok metaadatokkal

- **Kliens megvalósítás:**
   - Klasszikus HTTP: Egyszerű kliens, amely feldolgozza a streaming válaszokat
   - MCP: Összetettebb kliens, amely üzenetkezelőt használ különböző típusú üzenetek feldolgozására

- **Folyamatfrissítések:**
  - Klasszikus HTTP: A folyamat a fő válaszstream része.
  - MCP: A folyamat külön értesítési üzeneteken keresztül érkezik, míg a fő válasz a végén jön.

### Ajánlások

Néhány javaslat a klasszikus streaming (például a fent bemutatott `/stream` végpont) és az MCP streaming közötti választáshoz:

- **Egyszerű streaming igényekhez:** A klasszikus HTTP streaming egyszerűbb megvalósítani, és elegendő az alapvető streaming igényekhez.
- **Összetett, interaktív alkalmazásokhoz:** Az MCP streaming strukturáltabb megközelítést kínál gazdagabb metaadatokkal és az értesítések és végső eredmények szétválasztásával.
- **AI alkalmazásokhoz:** Az MCP értesítési rendszere különösen hasznos hosszú futású AI feladatokhoz, ahol a felhasználókat folyamatosan tájékoztatni kell a folyamatról.
Két meggyőző érv szól az SSE-ről Streamable HTTP-re való áttérés mellett:

- A Streamable HTTP jobb skálázhatóságot, kompatibilitást és gazdagabb értesítési támogatást kínál, mint az SSE.
- Ez az ajánlott adatátviteli mód az új MCP alkalmazásokhoz.

### Migrációs lépések

Így migrálhat az SSE-ről Streamable HTTP-re az MCP alkalmazásaiban:

- **Frissítse a szerver kódját**, hogy `transport="streamable-http"` legyen megadva az `mcp.run()`-ban.
- **Frissítse a kliens kódját**, hogy az SSE kliens helyett a `streamablehttp_client`-et használja.
- **Valósítson meg egy üzenetkezelőt** a kliensben az értesítések feldolgozásához.
- **Tesztelje a kompatibilitást** a meglévő eszközökkel és munkafolyamatokkal.

### Kompatibilitás fenntartása

Ajánlott a migráció során megőrizni a kompatibilitást a meglévő SSE kliensekkel. Néhány javasolt megoldás:

- Mindkét protokollt támogathatod, ha különböző végpontokon futtatod az SSE-t és a Streamable HTTP-t.
- Fokozatosan migráld az ügyfeleket az új adatátvitelre.

### Kihívások

A migráció során figyelj az alábbi kihívásokra:

- Minden kliens frissítésének biztosítása
- Az értesítések kézbesítésében jelentkező különbségek kezelése

## Biztonsági szempontok

A biztonság kiemelten fontos bármilyen szerver megvalósításánál, különösen HTTP-alapú adatátviteli módok, például a Streamable HTTP használatakor az MCP-ben.

Az MCP szerverek HTTP-alapú adatátvitellel történő megvalósítása során a biztonság elsődleges szempont, amely alapos figyelmet igényel a különböző támadási felületekre és védelmi mechanizmusokra.

### Áttekintés

A biztonság kritikus fontosságú, amikor MCP szervereket tesz elérhetővé HTTP-n keresztül. A Streamable HTTP új támadási felületeket vezet be, és gondos konfigurációt igényel.

Íme néhány kulcsfontosságú biztonsági szempont:

- **Origin fejléc ellenőrzése**: Mindig ellenőrizd az `Origin` fejlécet, hogy megakadályozd a DNS újracímzéses támadásokat.
- **Localhost kötés**: Fejlesztés közben köss a szervereket `localhost`-hoz, hogy ne legyenek nyilvánosan elérhetők.
- **Hitelesítés**: Éles környezetben alkalmazz hitelesítést (pl. API kulcsok, OAuth).
- **CORS**: Állíts be Cross-Origin Resource Sharing (CORS) szabályokat a hozzáférés korlátozására.
- **HTTPS**: Éles környezetben használj HTTPS-t a forgalom titkosításához.

### Legjobb gyakorlatok

Ezen felül az MCP streaming szerver biztonságának megvalósításakor érdemes követni az alábbiakat:

- Soha ne bízz meg automatikusan a bejövő kérésekben, mindig ellenőrizd őket.
- Naplózz és figyelj minden hozzáférést és hibát.
- Rendszeresen frissítsd a függőségeket a biztonsági rések javítása érdekében.

### Kihívások

Néhány kihívással szembesülhet az MCP streaming szerverek biztonságának megvalósításakor:

- A biztonság és a fejlesztés egyszerűségének egyensúlyozása
- Kompatibilitás biztosítása különböző kliens környezetekkel

### Feladat: Építsen saját streaming MCP alkalmazást

**Forgatókönyv:**  
Készíts egy MCP szervert és klienst, ahol a szerver egy elemlistát dolgoz fel (például fájlokat vagy dokumentumokat), és minden feldolgozott elemről értesítést küld. Az ügyfélnek valós időben kell megjelenítenie az értesítéseket.

**Lépések:**

1. Valósíts meg egy szerver eszközt, amely feldolgoz egy listát és értesítéseket küld minden elemről.
2. Készíts egy klienst, amely üzenetkezelővel valós időben jeleníti meg az értesítéseket.
3. Teszteld a megvalósítást úgy, hogy egyszerre futtatod a szervert és a klienst, és figyeled az értesítéseket.

[Megoldás](./solution/README.md)

## További olvasmányok és következő lépések

Ha tovább szeretnéd mélyíteni MCP streaming ismereteidet és fejlettebb alkalmazásokat építenél, ez a rész további forrásokat és javasolt következő lépéseket kínál.

### További olvasmányok

- [Microsoft: Bevezetés a HTTP streamingbe](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS az ASP.NET Core-ban](https://learn.microsoft.com/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming kérések](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Következő lépések

- Próbálj meg fejlettebb MCP eszközöket építeni, amelyek streaminget használnak valós idejű elemzéshez, csevegéshez vagy együttműködő szerkesztéshez.
- Fedezd fel az MCP streaming integrálását frontend keretrendszerekkel (React, Vue stb.) az élő UI frissítésekhez.
- Következő: [AI Toolkit használata VSCode-ban](../07-aitk/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.