<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:31:29+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hu"
}
-->
# 📖 MCP Alapfogalmak: A Model Context Protocol mesteri elsajátítása az AI integrációhoz

A Model Context Protocol (MCP) egy erőteljes, szabványosított keretrendszer, amely optimalizálja a kommunikációt a Nagy Nyelvi Modellek (LLM-ek) és külső eszközök, alkalmazások, valamint adatforrások között. Ez a SEO-optimalizált útmutató végigvezet a MCP alapfogalmain, hogy megértsd annak kliens-szerver architektúráját, lényeges elemeit, kommunikációs mechanizmusait és a megvalósítás legjobb gyakorlatait.

## Áttekintés

Ebben a leckében megismered a Model Context Protocol (MCP) ökoszisztéma alapvető architektúráját és komponenseit. Megtudhatod, hogyan működik a kliens-szerver modell, mik a kulcsfontosságú elemek, és milyen kommunikációs mechanizmusok támogatják az MCP működését.

## 👩‍🎓 Fő tanulási célok

A lecke végére képes leszel:

- Megérteni az MCP kliens-szerver architektúrát.
- Azonosítani a Hosts, Clients és Servers szerepét és felelősségeit.
- Elemezni az MCP rugalmas integrációs rétegének alapvető jellemzőit.
- Megérteni az információáramlást az MCP ökoszisztémán belül.
- Gyakorlati betekintést nyerni .NET, Java, Python és JavaScript példákon keresztül.

## 🔎 MCP Architektúra: Mélyebb betekintés

Az MCP ökoszisztéma kliens-szerver modellen alapul. Ez a moduláris felépítés lehetővé teszi, hogy az AI alkalmazások hatékonyan kommunikáljanak eszközökkel, adatbázisokkal, API-kkal és kontextuális erőforrásokkal. Nézzük meg az architektúra főbb elemeit.

### 1. Hosts

A Model Context Protocol (MCP) esetében a Hosts kulcsszerepet játszanak, mint az elsődleges felület, amelyen keresztül a felhasználók kapcsolatba lépnek a protokollal. A Hosts olyan alkalmazások vagy környezetek, amelyek kapcsolatot kezdeményeznek az MCP szerverekkel, hogy hozzáférjenek adatokhoz, eszközökhöz és promptokhoz. Példák a Hosts-ra: integrált fejlesztői környezetek (IDE-k) mint a Visual Studio Code, AI eszközök, mint a Claude Desktop, vagy speciális feladatokra készült egyedi ügynökök.

**A Hosts** LLM alkalmazások, amelyek kapcsolatot kezdeményeznek. Ők:

- AI modellekkel dolgoznak vagy velük interakcióba lépnek válaszok generálására.
- Kapcsolatot kezdeményeznek MCP szerverekkel.
- Kezelik a beszélgetés menetét és a felhasználói felületet.
- Irányítják az engedélyeket és biztonsági korlátozásokat.
- Kezelik a felhasználói beleegyezést az adatmegosztáshoz és eszközvégrehajtáshoz.

### 2. Clients

A Clients alapvető összetevők, amelyek elősegítik a Hosts és az MCP szerverek közötti interakciót. A Clients közvetítőként működnek, lehetővé téve a Hosts számára, hogy hozzáférjenek és használják az MCP szerverek által kínált funkciókat. Fontos szerepük van a gördülékeny kommunikáció és hatékony adatcsere biztosításában az MCP architektúrán belül.

**A Clients** a host alkalmazáson belüli csatlakozók. Ők:

- Kéréseket küldenek a szervereknek promptokkal/utasításokkal.
- Tárgyalják a képességeket a szerverekkel.
- Kezelik a modellek eszközhasználati kéréseit.
- Feldolgozzák és megjelenítik a válaszokat a felhasználók számára.

### 3. Servers

A Servers felelősek az MCP kliens kérések kezeléséért és a megfelelő válaszok biztosításáért. Különféle műveleteket végeznek, mint adatlekérés, eszközvégrehajtás és prompt generálás. A Servers biztosítják, hogy a kliens és a Hosts közötti kommunikáció hatékony és megbízható legyen, megőrizve az interakció integritását.

**A Servers** olyan szolgáltatások, amelyek kontextust és képességeket nyújtanak. Ők:

- Regisztrálják az elérhető funkciókat (erőforrások, promptok, eszközök).
- Fogadják és végrehajtják a kliens eszközhívásait.
- Kontextuális információkat biztosítanak a modell válaszainak javítására.
- Visszaküldik az eredményeket a kliensnek.
- Szükség esetén fenntartják az állapotot az interakciók során.

A szervereket bárki fejlesztheti, hogy kiterjessze a modell képességeit speciális funkciókkal.

### 4. Server Features

Az MCP szerverek alapvető építőelemeket kínálnak, amelyek lehetővé teszik a gazdag interakciókat a kliens, host és nyelvi modellek között. Ezek a funkciók arra szolgálnak, hogy strukturált kontextust, eszközöket és promptokat biztosítsanak, ezzel bővítve az MCP képességeit.

Az MCP szerverek a következő funkciókat kínálhatják:

#### 📑 Resources

Az MCP-ben az erőforrások különféle kontextusokat és adatokat jelentenek, amelyeket a felhasználók vagy AI modellek felhasználhatnak. Ezek közé tartoznak:

- **Kontextuális adatok**: Információk és háttér, amelyeket a felhasználók vagy AI modellek döntéshozatalhoz és feladatvégzéshez használhatnak.
- **Tudásbázisok és dokumentumgyűjtemények**: Strukturált és nem strukturált adatok gyűjteményei, például cikkek, kézikönyvek és kutatási anyagok, amelyek értékes információkat nyújtanak.
- **Helyi fájlok és adatbázisok**: Helyileg tárolt adatok eszközökön vagy adatbázisokban, amelyek feldolgozhatók és elemezhetők.
- **API-k és webszolgáltatások**: Külső interfészek és szolgáltatások, amelyek további adatokat és funkciókat kínálnak, lehetővé téve az online erőforrások és eszközök integrációját.

Egy erőforrás például lehet egy adatbázis séma vagy egy fájl, amely így érhető el:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Az MCP promptok különféle előre definiált sablonokat és interakciós mintákat tartalmaznak, amelyek célja a felhasználói munkafolyamatok egyszerűsítése és a kommunikáció javítása. Ezek közé tartoznak:

- **Sablonüzenetek és munkafolyamatok**: Előre strukturált üzenetek és folyamatok, amelyek irányítják a felhasználókat specifikus feladatokon és interakciókon keresztül.
- **Előre definiált interakciós minták**: Standardizált cselekvési és válaszlépések, amelyek elősegítik a következetes és hatékony kommunikációt.
- **Speciális beszélgetési sablonok**: Testreszabható sablonok, amelyek adott beszélgetéstípusokra szabottak, biztosítva a releváns és kontextuálisan megfelelő interakciókat.

Egy prompt sablon így nézhet ki:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Az MCP-ben az eszközök olyan funkciók, amelyeket az AI modell végrehajthat adott feladatok elvégzésére. Ezek az eszközök bővítik az AI modell képességeit strukturált és megbízható műveletekkel. Fő jellemzőik:

- **Funkciók az AI modell számára végrehajtásra**: Az eszközök futtatható funkciók, amelyeket az AI modell hívhat meg különböző feladatok elvégzésére.
- **Egyedi név és leírás**: Minden eszköznek saját neve és részletes leírása van, amely megmagyarázza célját és működését.
- **Paraméterek és kimenetek**: Az eszközök meghatározott paramétereket fogadnak el, és strukturált kimenetet adnak vissza, biztosítva az állandó és kiszámítható eredményeket.
- **Diszkrét funkciók**: Az eszközök különálló funkciókat hajtanak végre, mint például webes keresés, számítások vagy adatbázis lekérdezések.

Egy eszköz például így nézhet ki:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Client Features

Az MCP-ben a kliensek számos kulcsfontosságú funkciót kínálnak a szervereknek, amelyek növelik a protokoll általános működését és interakcióját. Az egyik kiemelt funkció a Sampling.

### 👉 Sampling

- **Szerver által kezdeményezett ügynöki viselkedések**: A kliensek lehetővé teszik, hogy a szerverek autonóm módon indítsanak el bizonyos műveleteket vagy viselkedéseket, fokozva a rendszer dinamikus képességeit.
- **Rekurzív LLM interakciók**: Ez a funkció lehetővé teszi a Nagy Nyelvi Modellekkel való ismétlődő, összetettebb és iteratív feladatfeldolgozást.
- **További modell kiegészítések kérése**: A szerverek kérhetnek további kiegészítéseket a modelltől, biztosítva, hogy a válaszok alaposak és kontextuálisan relevánsak legyenek.

## Információáramlás az MCP-ben

A Model Context Protocol (MCP) meghatároz egy strukturált információáramlást a hosts, clients, servers és modellek között. Ennek megértése segít tisztázni, hogyan dolgozódnak fel a felhasználói kérések, és hogyan integrálódnak a külső eszközök és adatok a modell válaszaiba.

- **A host kezdeményezi a kapcsolatot**  
  A host alkalmazás (például egy IDE vagy csevegőfelület) kapcsolatot létesít egy MCP szerverrel, általában STDIO, WebSocket vagy más támogatott átviteli módon keresztül.

- **Képességek egyeztetése**  
  A kliens (a hoston belül) és a szerver információt cserélnek a támogatott funkciókról, eszközökről, erőforrásokról és protokoll verziókról. Ez biztosítja, hogy mindkét fél tisztában legyen az elérhető képességekkel a munkamenet során.

- **Felhasználói kérés**  
  A felhasználó interakcióba lép a hosttal (például promptot vagy parancsot ad meg). A host összegyűjti ezt a bemenetet, és továbbítja a kliensnek feldolgozásra.

- **Erőforrás vagy eszköz használata**  
  - A kliens kérhet további kontextust vagy erőforrásokat a szervertől (például fájlokat, adatbázis bejegyzéseket vagy tudásbázis cikkeket), hogy gazdagítsa a modell megértését.
  - Ha a modell úgy ítéli meg, hogy eszközre van szükség (például adat lekérése, számítás elvégzése vagy API hívás), a kliens eszköz meghívási kérést küld a szervernek, megadva az eszköz nevét és paramétereit.

- **Szerver végrehajtás**  
  A szerver fogadja az erőforrás vagy eszköz kérést, végrehajtja a szükséges műveleteket (például függvény futtatása, adatbázis lekérdezés vagy fájl lekérése), és strukturált formában visszaküldi az eredményeket a kliensnek.

- **Válasz generálás**  
  A kliens integrálja a szerver válaszait (erőforrás adatok, eszköz kimenetek stb.) a folyamatban lévő modell interakcióba. A modell ezeket az információkat felhasználva generál átfogó és kontextuálisan releváns választ.

- **Eredmény bemutatása**  
  A host megkapja a kliens végső kimenetét, és megjeleníti a felhasználónak, gyakran a modell által generált szöveget, valamint az eszközvégrehajtás vagy erőforrás lekérés eredményeit.

Ez a folyamat lehetővé teszi az MCP számára, hogy fejlett, interaktív és kontextusérzékeny AI alkalmazásokat támogasson, zökkenőmentesen összekapcsolva a modelleket külső eszközökkel és adatforrásokkal.

## Protokoll részletek

Az MCP a [JSON-RPC 2.0](https://www.jsonrpc.org/) protokollra épül, amely szabványos, nyelvfüggetlen üzenetformátumot biztosít a hosts, clients és servers közötti kommunikációhoz. Ez a fundamentum megbízható, strukturált és bővíthető interakciókat tesz lehetővé különböző platformokon és programozási nyelveken.

### Kulcsprotokoll jellemzők

Az MCP kiterjeszti a JSON-RPC 2.0-t további konvenciókkal az eszköz meghívás, erőforrás hozzáférés és prompt kezelés terén. Többféle átviteli réteget támogat (STDIO, WebSocket, SSE), és biztonságos, bővíthető, nyelvfüggetlen kommunikációt tesz lehetővé a komponensek között.

#### 🧢 Alapprotokoll

- **JSON-RPC üzenetformátum**: Minden kérés és válasz a JSON-RPC 2.0 specifikációt követi, biztosítva az egységes szerkezetet a metódushívásokhoz, paraméterekhez, eredményekhez és hibakezeléshez.
- **Állapotmegőrző kapcsolatok**: Az MCP munkamenetek több kérésen át megőrzik az állapotot, támogatva a folyamatos beszélgetéseket, kontextus felhalmozást és erőforrás kezelést.
- **Képességek egyeztetése**: A kapcsolat létrehozásakor a kliensek és szerverek információt cserélnek a támogatott funkciókról, protokoll verziókról, elérhető eszközökről és erőforrásokról. Ez biztosítja, hogy mindkét fél értse a másik képességeit és alkalmazkodni tudjon.

#### ➕ További eszközök

Az MCP további eszközöket és protokoll kiterjesztéseket kínál a fejlesztői élmény javítására és fejlett forgatókönyvek támogatására:

- **Konfigurációs lehetőségek**: Az MCP lehetővé teszi a munkamenet paramétereinek dinamikus beállítását, például eszközengedélyeket, erőforrás-hozzáférést és modellbeállításokat, az adott interakcióhoz igazítva.
- **Folyamatkövetés**: Hosszú futású műveletek előrehaladási jelentéseket küldhetnek, lehetővé téve a felhasználói felületek reagálását és jobb felhasználói élményt komplex feladatok alatt.
- **Kérés megszakítása**: A kliensek megszakíthatják a folyamatban lévő kéréseket, lehetővé téve a felhasználók számára a már nem szükséges vagy túl hosszú műveletek megszakítását.
- **Hibajelentés**: Szabványosított hibaüzenetek és kódok segítenek a problémák diagnosztizálásában, a hibák kezelésekor, és használható visszajelzést adnak a felhasználóknak és fejlesztőknek.
- **Naplózás**: Mind a kliensek, mind a szerverek strukturált naplókat bocsáthatnak ki auditálás, hibakeresés és protokoll interakciók monitorozása céljából.

Ezekkel a protokoll jellemzőkkel az MCP megbízható, biztonságos és rugalmas kommunikációt biztosít a nyelvi modellek és külső eszközök vagy adatforrások között.

### 🔐

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hivatalos forrásnak. Kritikus információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy félreértelmezésekért.