<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T17:59:38+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hu"
}
-->
# 📖 MCP Alapfogalmak: A Model Context Protocol mesteri használata az AI integrációhoz

A Model Context Protocol (MCP) egy hatékony, szabványosított keretrendszer, amely optimalizálja a kommunikációt a nagy nyelvi modellek (LLM-ek) és külső eszközök, alkalmazások, valamint adatforrások között. Ez a SEO-optimalizált útmutató végigvezet az MCP alapfogalmain, hogy megértsd a kliens-szerver architektúrát, a lényeges összetevőket, a kommunikációs mechanizmusokat és a megvalósítás legjobb gyakorlatait.

## Áttekintés

Ebben a leckében megvizsgáljuk a Model Context Protocol (MCP) ökoszisztéma alapvető architektúráját és elemeit. Megismerheted a kliens-szerver architektúrát, a kulcsfontosságú összetevőket és a kommunikációs mechanizmusokat, amelyek az MCP interakciókat működtetik.

## 👩‍🎓 Fő tanulási célok

A lecke végére képes leszel:

- Megérteni az MCP kliens-szerver architektúrát.
- Azonosítani a Hosts, Clients és Servers szerepeit és felelősségeit.
- Elemezni az MCP rugalmas integrációs rétegének fő jellemzőit.
- Megérteni, hogyan áramlik az információ az MCP ökoszisztémában.
- Gyakorlati betekintést nyerni kódpéldák segítségével .NET, Java, Python és JavaScript nyelveken.

## 🔎 MCP Architektúra: Mélyebb betekintés

Az MCP ökoszisztéma kliens-szerver modellre épül. Ez a moduláris felépítés lehetővé teszi, hogy az AI alkalmazások hatékonyan kommunikáljanak eszközökkel, adatbázisokkal, API-kkal és kontextuális erőforrásokkal. Nézzük meg részletesebben ezt az architektúrát a fő összetevőkre bontva.

### 1. Hosts

A Model Context Protocol (MCP) esetén a Hosts kulcsszerepet töltenek be, mint a fő felület, amin keresztül a felhasználók kapcsolatba lépnek a protokollal. A Hosts alkalmazások vagy környezetek, amelyek kapcsolatot kezdeményeznek MCP szerverekkel az adatokhoz, eszközökhöz és promptokhoz való hozzáférés érdekében. Példák Hosts-ra: integrált fejlesztői környezetek (IDE-k) mint a Visual Studio Code, AI eszközök mint a Claude Desktop vagy egyedi ügynökök speciális feladatokra.

**Hosts** azok az LLM alkalmazások, amelyek kapcsolatot kezdeményeznek. Feladataik:

- AI modellekkel való interakció vagy futtatás válaszok generálásához.
- Kapcsolat indítása MCP szerverekhez.
- A beszélgetés folyamatának és a felhasználói felület irányítása.
- Jogosultságok és biztonsági korlátozások kezelése.
- Felhasználói hozzájárulás kezelése az adatok megosztásához és az eszközök futtatásához.

### 2. Clients

A Clients alapvető elemek, amelyek megkönnyítik a Hosts és az MCP szerverek közötti interakciót. A Clients közvetítőként működnek, lehetővé téve, hogy a Hosts hozzáférjen és használja az MCP szerverek által nyújtott funkciókat. Fontos szerepük van a gördülékeny kommunikáció és az adatok hatékony cseréjének biztosításában az MCP architektúrában.

**Clients** a host alkalmazáson belüli csatlakozók. Feladataik:

- Kérések küldése a szervereknek promptokkal/utasításokkal.
- Képességek egyeztetése a szerverekkel.
- Az AI modellek eszközhasználati kéréseinek kezelése.
- Válaszok feldolgozása és megjelenítése a felhasználóknak.

### 3. Servers

A Servers felelősek az MCP kliens kérések kezeléséért és a megfelelő válaszok biztosításáért. Különféle műveleteket végeznek, mint adatlekérés, eszközök futtatása és promptok generálása. A Servers biztosítják a hatékony és megbízható kommunikációt a kliens és a Hosts között, megőrizve az interakció folyamatának integritását.

**Servers** szolgáltatások, amelyek kontextust és képességeket biztosítanak. Feladataik:

- Elérhető funkciók (erőforrások, promptok, eszközök) regisztrálása.
- Eszközhívások fogadása és végrehajtása a kliens részéről.
- Kontextuális információ biztosítása a modell válaszainak javítására.
- Eredmények visszaküldése a kliensnek.
- Állapot fenntartása az interakciók során, ha szükséges.

A szervereket bárki fejlesztheti, hogy speciális funkciókkal bővítse a modell képességeit.

### 4. Server Features

Az MCP szerverek alapvető építőelemeket kínálnak, amelyek lehetővé teszik a gazdag interakciókat kliens, host és nyelvi modellek között. Ezek a funkciók strukturált kontextust, eszközöket és promptokat biztosítanak az MCP képességeinek bővítéséhez.

Az MCP szerverek az alábbi funkciókat kínálhatják:

#### 📑 Erőforrások

Az MCP-ben az erőforrások különböző típusú kontextust és adatokat foglalnak magukban, amelyeket a felhasználók vagy AI modellek felhasználhatnak. Ezek közé tartoznak:

- **Kontextuális adatok**: Információk és kontextus, amelyeket a felhasználók vagy AI modellek döntéshozatalhoz és feladatvégzéshez használhatnak.
- **Tudásbázisok és dokumentumtárak**: Strukturált és strukturálatlan adatok gyűjteményei, például cikkek, kézikönyvek és kutatási anyagok, amelyek értékes betekintést és információt nyújtanak.
- **Helyi fájlok és adatbázisok**: Helyileg tárolt adatok eszközökön vagy adatbázisokban, amelyek feldolgozásra és elemzésre elérhetők.
- **API-k és webszolgáltatások**: Külső interfészek és szolgáltatások, amelyek további adatokat és funkciókat kínálnak, lehetővé téve az integrációt különféle online erőforrásokkal és eszközökkel.

Egy erőforrás például lehet egy adatbázis séma vagy egy fájl, amely így érhető el:

```text
file://log.txt
database://schema
```

### 🤖 Promptok

Az MCP promptjai különféle előre definiált sablonokat és interakciós mintákat tartalmaznak, amelyek célja a felhasználói munkafolyamatok egyszerűsítése és a kommunikáció javítása. Ezek közé tartoznak:

- **Sablonos üzenetek és munkafolyamatok**: Előre strukturált üzenetek és folyamatok, amelyek irányítják a felhasználókat specifikus feladatokon és interakciókon keresztül.
- **Előre definiált interakciós minták**: Szabványosított műveletsorozatok és válaszok, amelyek elősegítik a következetes és hatékony kommunikációt.
- **Speciális beszélgetési sablonok**: Testreszabható sablonok, amelyek adott típusú beszélgetésekhez igazodnak, biztosítva a releváns és kontextushoz illő interakciókat.

Egy prompt sablon így nézhet ki:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Eszközök

Az MCP-ben az eszközök olyan funkciók, amelyeket az AI modell végrehajthat bizonyos feladatok elvégzésére. Ezek az eszközök célja, hogy bővítsék az AI modell képességeit strukturált és megbízható műveletek biztosításával. Főbb jellemzőik:

- **Az AI modell által végrehajtható funkciók**: Az eszközök olyan végrehajtható funkciók, amelyeket az AI modell meghívhat különféle feladatok elvégzésére.
- **Egyedi név és leírás**: Minden eszköznek van egy sajátos neve és részletes leírása, amely megmagyarázza a célját és működését.
- **Paraméterek és kimenetek**: Az eszközök meghatározott paramétereket fogadnak és strukturált kimeneteket adnak vissza, biztosítva a következetes és kiszámítható eredményeket.
- **Diszkrét funkciók**: Az eszközök elkülönült funkciókat végeznek, mint például webes keresések, számítások vagy adatbázis-lekérdezések.

Egy példa eszköz így nézhet ki:

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Client funkciók

Az MCP-ben a kliens számos kulcsfontosságú funkciót kínál a szerverek számára, ezzel bővítve a protokoll általános működését és az interakciót. Az egyik kiemelkedő funkció a Sampling.

### 👉 Sampling

- **Szerver által indított ügynöki viselkedések**: A kliensek lehetővé teszik, hogy a szerverek önállóan indítsanak el specifikus műveleteket vagy viselkedéseket, ezzel növelve a rendszer dinamikus képességeit.
- **Rekurzív LLM interakciók**: Ez a funkció lehetővé teszi a nagy nyelvi modellekkel történő rekurzív interakciókat, amelyek összetettebb és iteratív feladatfeldolgozást tesznek lehetővé.
- **További modell kiegészítések kérése**: A szerverek további válaszokat kérhetnek a modelltől, biztosítva, hogy a válaszok alaposak és kontextusban relevánsak legyenek.

## Információáramlás az MCP-ben

A Model Context Protocol (MCP) strukturált információáramlást határoz meg a hosts, clients, servers és modellek között. Ennek megértése segít tisztázni, hogyan dolgozódnak fel a felhasználói kérések, és hogyan integrálódnak a külső eszközök és adatok a modell válaszaiba.

- **Host kapcsolatot kezdeményez**  
  A host alkalmazás (például IDE vagy csevegőfelület) kapcsolatot létesít egy MCP szerverrel, jellemzően STDIO, WebSocket vagy más támogatott átvitel segítségével.

- **Képességek egyeztetése**  
  A kliens (a hostban beágyazva) és a szerver információt cserélnek a támogatott funkciókról, eszközökről, erőforrásokról és protokoll verziókról. Ez biztosítja, hogy mindkét fél értse, milyen képességek állnak rendelkezésre az adott munkamenethez.

- **Felhasználói kérés**  
  A felhasználó interakcióba lép a hosttal (például promptot vagy parancsot ad meg). A host összegyűjti ezt a bemenetet, és továbbítja a kliensnek feldolgozásra.

- **Erőforrás vagy eszköz használata**  
  - A kliens kérhet további kontextust vagy erőforrásokat a szervertől (például fájlokat, adatbázis-bejegyzéseket vagy tudásbázis cikkeket), hogy gazdagítsa a modell megértését.
  - Ha a modell úgy ítéli meg, hogy eszközre van szükség (például adatlekéréshez, számításhoz vagy API híváshoz), a kliens eszközhívási kérelmet küld a szervernek, megadva az eszköz nevét és paramétereit.

- **Szerver végrehajtás**  
  A szerver fogadja az erőforrás vagy eszközkérést, végrehajtja a szükséges műveleteket (például függvény futtatása, adatbázis lekérdezése vagy fájl visszakeresése), majd strukturált formában visszaküldi az eredményeket a kliensnek.

- **Válasz generálása**  
  A kliens integrálja a szerver válaszait (erőforrás adatok, eszköz kimenetek stb.) a folyamatban lévő modell interakcióba. A modell ezeket az információkat felhasználva átfogó és kontextusban releváns választ generál.

- **Eredmény bemutatása**  
  A host megkapja a kliens végső kimenetét, és megjeleníti a felhasználónak, gyakran tartalmazva a modell által generált szöveget és az eszközök futtatásából vagy erőforrás lekérdezésből származó eredményeket.

Ez a folyamat lehetővé teszi, hogy az MCP fejlett, interaktív és kontextusérzékeny AI alkalmazásokat támogasson azáltal, hogy zökkenőmentesen kapcsolja össze a modelleket külső eszközökkel és adatforrásokkal.

## Protokoll részletek

Az MCP (Model Context Protocol) a [JSON-RPC 2.0](https://www.jsonrpc.org/) protokollra épül, amely szabványos, nyelvfüggetlen üzenetformátumot biztosít a hosts, clients és servers közötti kommunikációhoz. Ez az alap megbízható, strukturált és bővíthető interakciókat tesz lehetővé különböző platformokon és programozási nyelveken.

### Fő protokoll jellemzők

Az MCP kiterjeszti a JSON-RPC 2.0-t további konvenciókkal az eszközök meghívására, erőforrások elérésére és prompt kezelésére. Több átvitel réteget támogat (STDIO, WebSocket, SSE), valamint biztonságos, bővíthető és nyelvfüggetlen kommunikációt tesz lehetővé az összetevők között.

#### 🧢 Alapprotokoll

- **JSON-RPC üzenetformátum**: Minden kérés és válasz a JSON-RPC 2.0 szabványt követi, biztosítva az egységes szerkezetet a metódushívások, paraméterek, eredmények és hibakezelés számára.
- **Állapotmegőrző kapcsolatok**: Az MCP munkamenetek több kérésen keresztül is megőrzik az állapotot, támogatva a folyamatban lévő beszélgetéseket, kontextusgyűjtést és erőforrás-kezelést.
- **Képesség egyeztetés**: Kapcsolat létesítésekor a kliensek és szerverek információt cserélnek a támogatott funkciókról, protokoll verziókról, elérhető eszközökről és erőforrásokról. Ez biztosítja, hogy mindkét fél értse a másik képességeit és ennek megfelelően alkalmazkodjon.

#### ➕ További segédprogramok

Az MCP további kiegészítéseket kínál a fejlesztői élmény javítására és fejlett forgatókönyvek támogatására:

- **Konfigurációs beállítások**: Dinamikusan konfigurálható munkamenet paraméterek, például eszköz jogosultságok, erőforrás hozzáférések és modell beállítások, az adott interakcióhoz igazítva.
- **Folyamatkövetés**: Hosszú ideig tartó műveletek képesek állapotfrissítéseket küldeni, támogatva a reszponzív felhasználói felületeket és jobb élményt bonyolult feladatok során.
- **Kérés megszakítása**: A kliensek megszakíthatják a folyamatban lévő kéréseket, lehetővé téve a felhasználóknak, hogy megszakítsák a már nem szükséges vagy túl lassú műveleteket.
- **Hibajelentés**: Szabványosított hibaüzenetek és kódok segítik a problémák diagnosztizálását, a hibák elegáns kezelését és hasznos visszajelzést adnak a felhasználóknak és fejlesztőknek.
- **Naplózás**: Kliensek és szerverek egyaránt képesek strukturált naplókat generálni az auditáláshoz, hibakereséshez és a protokoll interakciók monitorozásához.

Ezekkel a protokoll funkciókkal az MCP biztosítja a robusztus, biztonság

**Nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár az pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvű változatát kell tekinteni a hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy félreértelmezésekért.