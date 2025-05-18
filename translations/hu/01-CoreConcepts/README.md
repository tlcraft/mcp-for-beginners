<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:56:03+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hu"
}
-->
# 📖 MCP Alapfogalmak: A Model Context Protocol elsajátítása AI integrációhoz

A Model Context Protocol (MCP) egy erőteljes, szabványosított keretrendszer, amely optimalizálja a kommunikációt a Nagy Nyelvi Modellek (LLM-ek) és külső eszközök, alkalmazások, valamint adatforrások között. Ez a SEO-optimalizált útmutató végigvezet az MCP alapfogalmain, biztosítva, hogy megértsd annak kliens-szerver architektúráját, alapvető elemeit, kommunikációs mechanikáját és a legjobb gyakorlatokat az implementációhoz.

## Áttekintés

Ez a lecke feltárja a Model Context Protocol (MCP) ökoszisztémát alkotó alapvető architektúrát és elemeket. Megismerheted a kliens-szerver architektúrát, kulcsfontosságú elemeket és kommunikációs mechanizmusokat, amelyek az MCP interakciókat működtetik.

## 👩‍🎓 Fő Tanulási Célkitűzések

A lecke végére:

- Megérted az MCP kliens-szerver architektúrát.
- Azonosítod a Hostok, Kliensek és Szerverek szerepeit és felelősségeit.
- Elemzed az MCP rugalmas integrációs rétegét alkotó alapvető jellemzőket.
- Megtanulod, hogyan áramlik az információ az MCP ökoszisztémában.
- Gyakorlati betekintést nyersz .NET, Java, Python és JavaScript kód példákon keresztül.

## 🔎 MCP Architektúra: Mélyebb Pillantás

Az MCP ökoszisztéma egy kliens-szerver modellre épül. Ez a moduláris struktúra lehetővé teszi az AI alkalmazások számára, hogy hatékonyan lépjenek kapcsolatba eszközökkel, adatbázisokkal, API-kkal és kontextuális erőforrásokkal. Nézzük meg közelebbről az architektúra alapvető elemeit.

### 1. Hostok

A Model Context Protocol (MCP) esetében a Hostok alapvető szerepet játszanak, mint a protokollal való interakció elsődleges felülete. A Hostok olyan alkalmazások vagy környezetek, amelyek kapcsolatot kezdeményeznek MCP szerverekkel, hogy hozzáférjenek adatokhoz, eszközökhöz és promptokhoz. Példák a Hostokra: integrált fejlesztői környezetek (IDE-k), mint a Visual Studio Code, AI eszközök, mint a Claude Desktop, vagy speciális feladatokra tervezett egyedi ügynökök.

**Hostok** olyan LLM alkalmazások, amelyek kapcsolatot kezdeményeznek. Ők:

- AI modellekkel lépnek interakcióba vagy végrehajtják azokat válaszok generálására.
- Kapcsolatot kezdeményeznek MCP szerverekkel.
- Kezelik a beszélgetés folyamatát és a felhasználói felületet.
- Felügyelik a jogosultsági és biztonsági korlátozásokat.
- Kezelik a felhasználói beleegyezést az adatok megosztására és eszközök végrehajtására.

### 2. Kliensek

A Kliensek alapvető elemek, amelyek megkönnyítik a Hostok és MCP szerverek közötti interakciót. A Kliensek közvetítőként működnek, lehetővé téve a Hostok számára, hogy hozzáférjenek és kihasználják az MCP szerverek által biztosított funkciókat. Alapvető szerepet játszanak a zökkenőmentes kommunikáció és hatékony adatcsere biztosításában az MCP architektúrában.

**Kliensek** a host alkalmazáson belüli csatlakozók. Ők:

- Kéréseket küldenek a szervereknek promptokkal/instrukciókkal.
- Képességeket tárgyalnak a szerverekkel.
- Kezelik az eszközvégrehajtási kéréseket a modellektől.
- Feldolgozzák és megjelenítik a válaszokat a felhasználóknak.

### 3. Szerverek

A Szerverek felelősek az MCP kliensektől érkező kérések kezeléséért és megfelelő válaszok biztosításáért. Kezelnek különböző műveleteket, mint az adatok lekérése, eszközvégrehajtás és prompt generálás. A Szerverek biztosítják, hogy a kliensek és Hostok közötti kommunikáció hatékony és megbízható legyen, megőrizve az interakciós folyamat integritását.

**Szerverek** olyan szolgáltatások, amelyek kontextust és képességeket biztosítanak. Ők:

- Regisztrálják a rendelkezésre álló funkciókat (erőforrások, promptok, eszközök).
- Fogadják és végrehajtják az eszköz hívásokat a klienstől.
- Kontextuális információt nyújtanak a modellek válaszainak javításához.
- Visszaküldik a kimeneteket a kliensnek.
- Szükség esetén fenntartják az állapotot az interakciók során.

A Szervereket bárki fejlesztheti a modell képességeinek bővítésére speciális funkciókkal.

### 4. Szerver Funkciók

A Model Context Protocol (MCP) szerverei alapvető építőelemeket biztosítanak, amelyek gazdag interakciókat tesznek lehetővé a kliensek, hostok és nyelvi modellek között. Ezek a funkciók az MCP képességeinek növelésére lettek tervezve, strukturált kontextus, eszközök és promptok biztosításával.

Az MCP szerverek az alábbi funkciókat kínálhatják:

#### 📑 Erőforrások

Az Erőforrások a Model Context Protocol (MCP) keretében különböző típusú kontextust és adatot foglalnak magukba, amelyeket a felhasználók vagy AI modellek felhasználhatnak. Ezek közé tartoznak:

- **Kontextuális Adatok**: Információ és kontextus, amelyet a felhasználók vagy AI modellek felhasználhatnak a döntéshozatalhoz és feladatvégrehajtáshoz.
- **Tudásbázisok és Dokumentumtárak**: Strukturált és strukturálatlan adatok gyűjteményei, mint cikkek, kézikönyvek és kutatási anyagok, amelyek értékes betekintést és információt nyújtanak.
- **Helyi Fájlok és Adatbázisok**: Helyileg eszközökön vagy adatbázisokban tárolt adatok, amelyek elérhetők feldolgozásra és elemzésre.
- **API-k és Webszolgáltatások**: Külső interfészek és szolgáltatások, amelyek további adatokat és funkciókat kínálnak, lehetővé téve az integrációt különböző online erőforrásokkal és eszközökkel.

Egy erőforrás például lehet egy adatbázis séma vagy egy fájl, amelyet így lehet elérni:

```text
file://log.txt
database://schema
```

### 🤖 Promptok

A Promptok a Model Context Protocol (MCP) keretében különböző előre definiált sablonokat és interakciós mintákat foglalnak magukba, amelyek célja a felhasználói munkafolyamatok egyszerűsítése és a kommunikáció javítása. Ezek közé tartoznak:

- **Sablonüzenetek és Munkafolyamatok**: Előre strukturált üzenetek és folyamatok, amelyek végigvezetik a felhasználókat konkrét feladatokon és interakciókon.
- **Előre definiált Interakciós Minták**: Standardizált cselekvési és válaszadási sorozatok, amelyek konzisztens és hatékony kommunikációt tesznek lehetővé.
- **Speciális Beszélgetési Sablonok**: Testreszabható sablonok, amelyek konkrét beszélgetéstípusokhoz igazodnak, biztosítva a releváns és kontextuálisan megfelelő interakciókat.

Egy prompt sablon így nézhet ki:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Eszközök

Az Eszközök a Model Context Protocol (MCP) keretében olyan funkciók, amelyeket az AI modell végrehajthat konkrét feladatok elvégzésére. Ezek az eszközök célja az AI modell képességeinek növelése strukturált és megbízható műveletek biztosításával. Főbb aspektusok közé tartoznak:

- **Funkciók az AI Modell Végrehajtásához**: Az eszközök végrehajtható funkciók, amelyeket az AI modell felhívhat különböző feladatok elvégzésére.
- **Egyedi Név és Leírás**: Minden eszköznek van egy külön neve és részletes leírása, amely magyarázza annak célját és funkcionalitását.
- **Paraméterek és Kimenetek**: Az eszközök specifikus paramétereket fogadnak el és strukturált kimeneteket adnak vissza, biztosítva a konzisztens és előre látható eredményeket.
- **Diszkrét Funkciók**: Az eszközök diszkrét funkciókat hajtanak végre, mint például webes keresések, számítások és adatbázis lekérdezések.

Egy példa eszköz így nézhet ki:

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

## Kliens Funkciók

A Model Context Protocol (MCP) keretében a kliensek számos kulcsfontosságú funkciót kínálnak a szervereknek, növelve az általános funkcionalitást és interakciót a protokollon belül. Az egyik figyelemre méltó funkció a Mintavétel.

### 👉 Mintavétel

- **Szerver Által Kezdeményezett Ügynöki Viselkedések**: A kliensek lehetővé teszik a szerverek számára, hogy specifikus cselekvéseket vagy viselkedéseket kezdeményezzenek autonóm módon, növelve a rendszer dinamikus képességeit.
- **Rekurzív LLM Interakciók**: Ez a funkció lehetővé teszi a rekurzív interakciókat nagy nyelvi modellekkel (LLM-ek), lehetővé téve a feladatok összetettebb és iteratív feldolgozását.
- **További Modell Befejezések Kérése**: A szerverek további befejezéseket kérhetnek a modellektől, biztosítva, hogy a válaszok alaposak és kontextuálisan relevánsak legyenek.

## Információ Áramlása az MCP-ben

A Model Context Protocol (MCP) meghatározza az információ struktúrált áramlását a hostok, kliensek, szerverek és modellek között. Az áramlás megértése segít tisztázni, hogyan kerülnek feldolgozásra a felhasználói kérések és hogyan integrálódnak a külső eszközök és adatok a modell válaszába.

- **Host Kapcsolatot Kezdeményez**  
  A host alkalmazás (mint egy IDE vagy chat interfész) kapcsolatot létesít egy MCP szerverrel, tipikusan STDIO, WebSocket vagy egy másik támogatott szállítón keresztül.

- **Képességek Tárgyalása**  
  A kliens (beágyazva a hostba) és a szerver információt cserélnek a támogatott funkcióikról, eszközeikről, erőforrásaikról és protokoll verzióikról. Ez biztosítja, hogy mindkét oldal megértse, milyen képességek állnak rendelkezésre a munkamenet során.

- **Felhasználói Kérés**  
  A felhasználó interakcióba lép a hosttal (például promptot vagy parancsot ad meg). A host összegyűjti ezt a bemenetet és átadja a kliensnek feldolgozásra.

- **Erőforrás vagy Eszköz Használat**  
  - A kliens további kontextust vagy erőforrásokat kérhet a szervertől (mint például fájlok, adatbázis bejegyzések vagy tudásbázis cikkek), hogy gazdagítsa a modell megértését.
  - Ha a modell úgy ítéli meg, hogy eszközre van szükség (például adatok lekérésére, számítás elvégzésére vagy API hívásra), a kliens eszköz hívási kérelmet küld a szervernek, megadva az eszköz nevét és paramétereit.

- **Szerver Végrehajtás**  
  A szerver megkapja az erőforrás vagy eszköz kérést, végrehajtja a szükséges műveleteket (mint például egy funkció futtatása, adatbázis lekérdezés vagy fájl lekérése), és visszaküldi az eredményeket a kliensnek strukturált formátumban.

- **Válasz Generálás**  
  A kliens integrálja a szerver válaszait (erőforrás adatok, eszköz kimenetek stb.) a folyamatban lévő modell interakcióba. A modell ezt az információt felhasználja egy átfogó és kontextuálisan releváns válasz generálásához.

- **Eredmény Megjelenítés**  
  A host megkapja a végső kimenetet a klienstől és bemutatja a felhasználónak, gyakran tartalmazva mind a modell által generált szöveget, mind az eszközvégrehajtások vagy erőforrás lekérdezések eredményeit.

Ez az áramlás lehetővé teszi az MCP számára, hogy támogassa az előrehaladott, interaktív és kontextusra érzékeny AI alkalmazásokat azáltal, hogy zökkenőmentesen kapcsolja össze a modelleket külső eszközökkel és adatforrásokkal.

## Protokoll Részletek

Az MCP (Model Context Protocol) a [JSON-RPC 2.0](https://www.jsonrpc.org/) alapjaira épül, szabványosított, nyelvfüggetlen üzenetformátumot biztosítva a hostok, kliensek és szerverek közötti kommunikációhoz. Ez az alap megbízható, strukturált és kiterjeszthető interakciókat tesz lehetővé különböző platformok és programozási nyelvek között.

### Kulcsfontosságú Protokoll Funkciók

Az MCP kiterjeszti a JSON-RPC 2.0-t további konvenciókkal az eszköz hívás, erőforrás hozzáférés és prompt kezelés terén. Támogatja több szállítási réteget (STDIO, WebSocket, SSE), és lehetővé teszi a biztonságos, kiterjeszthető és nyelvfüggetlen kommunikációt az összetevők között.

#### 🧢 Alap Protokoll

- **JSON-RPC Üzenetformátum**: Minden kérés és válasz a JSON-RPC 2.0 specifikációt használja, biztosítva a konzisztens struktúrát a metódus hívásokhoz, paraméterekhez, eredményekhez és hibakezeléshez.
- **Állapotos Kapcsolatok**: Az MCP munkamenetek állapotot tartanak fenn több kérésen keresztül, támogatva a folyamatban lévő beszélgetéseket, kontextus felhalmozást és erőforrás kezelést.
- **Képességek Tárgyalása**: Kapcsolat létrehozásakor a kliensek és szerverek információt cserélnek a támogatott funkciókról, protokoll verziókról, elérhető eszközökről és erőforrásokról. Ez biztosítja, hogy mindkét oldal megértse egymás képességeit és ennek megfelelően tudjon alkalmazkodni.

#### ➕ További Eszközök

Az alábbiakban néhány további eszköz és protokoll kiterjesztés található, amelyeket az MCP biztosít a fejlesztői élmény javítására és előrehaladott forgatókönyvek lehetővé tételére:

- **Konfigurációs Opciók**: Az MCP lehetővé teszi a munkamenet paramétereinek dinamikus konfigurálását, mint például az eszköz engedélyek, erőforrás hozzáférés és modell beállítások, minden interakcióhoz igazítva.
- **Haladás Követése**: A hosszú futású műveletek jelenthetnek haladásfrissítéseket, lehetővé té

**Jogi nyilatkozat**:  
Ezt a dokumentumot AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordították le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.