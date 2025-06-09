<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:43:16+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hu"
}
-->
# 📖 MCP Alapfogalmak: A Model Context Protocol Mesteri Használata AI Integrációhoz

A Model Context Protocol (MCP) egy erőteljes, szabványosított keretrendszer, amely optimalizálja a kommunikációt a Nagy Nyelvi Modellek (LLM-ek) és külső eszközök, alkalmazások, valamint adatforrások között. Ez az SEO-optimalizált útmutató végigvezet az MCP alapfogalmain, hogy megértsd a kliens-szerver architektúrát, a lényeges komponenseket, a kommunikáció működését és a legjobb megvalósítási gyakorlatokat.

## Áttekintés

Ebben a leckében az MCP ökoszisztéma alapvető architektúráját és összetevőit vizsgáljuk meg. Megismered a kliens-szerver modellt, a kulcsfontosságú elemeket és a kommunikációs mechanizmusokat, amelyek az MCP interakciókat működtetik.

## 👩‍🎓 Főbb Tanulási Célok

A lecke végére képes leszel:

- Megérteni az MCP kliens-szerver architektúrát.
- Azonosítani a Hosts, Clients és Servers szerepét és felelősségeit.
- Elemezni az MCP rugalmasságát biztosító fő jellemzőket.
- Megérteni az információáramlást az MCP ökoszisztémában.
- Gyakorlati példákon keresztül megismerni a .NET, Java, Python és JavaScript kódokat.

## 🔎 MCP Architektúra: Mélyebb Áttekintés

Az MCP ökoszisztéma kliens-szerver modellen alapul. Ez a moduláris felépítés lehetővé teszi, hogy az AI alkalmazások hatékonyan kommunikáljanak eszközökkel, adatbázisokkal, API-kkal és kontextuális erőforrásokkal. Nézzük meg az architektúra fő összetevőit.

### 1. Hosts

A Model Context Protocol (MCP) esetében a Hosts kulcsszerepet játszanak, mint az elsődleges felület, amelyen keresztül a felhasználók interakcióba lépnek a protokollal. A Hosts olyan alkalmazások vagy környezetek, amelyek kapcsolatot kezdeményeznek az MCP szerverekkel, hogy hozzáférjenek adatokhoz, eszközökhöz és promptokhoz. Példák a Hosts-ra: integrált fejlesztői környezetek (IDE-k) mint a Visual Studio Code, AI eszközök, például Claude Desktop vagy speciális feladatokra tervezett egyedi ügynökök.

**A Hosts** LLM alkalmazások, amelyek kapcsolatot indítanak. Feladataik:

- AI modellekkel való interakció vagy azok futtatása válaszok generálására.
- Kapcsolat kezdeményezése az MCP szerverekkel.
- A beszélgetés folyamatának és a felhasználói felület kezelésének irányítása.
- Engedélyek és biztonsági korlátozások kezelése.
- Felhasználói hozzájárulás kezelése adatmegosztáshoz és eszközök futtatásához.

### 2. Clients

A Clients elengedhetetlen komponensek, amelyek elősegítik a Hosts és az MCP szerverek közötti interakciót. A Clients közvetítőként működnek, lehetővé téve a Hosts számára, hogy hozzáférjenek és használják az MCP szerverek által nyújtott funkciókat. Fontos szerepük van a zökkenőmentes kommunikáció és hatékony adatcsere biztosításában az MCP architektúrában.

**A Clients** a host alkalmazáson belüli kapcsolódók. Feladataik:

- Kérések küldése a szervereknek promptokkal vagy utasításokkal.
- Képességek egyeztetése a szerverekkel.
- Eszközvégrehajtási kérések kezelése a modellektől.
- Válaszok feldolgozása és megjelenítése a felhasználóknak.

### 3. Servers

A Servers felelősek az MCP kliens kérések fogadásáért és megfelelő válaszok biztosításáért. Kezelik az adatlekéréseket, eszközvégrehajtásokat és prompt generálást. A Servers biztosítják, hogy a kliensek és a Hosts közötti kommunikáció hatékony és megbízható legyen, megőrizve az interakció integritását.

**A Servers** szolgáltatások, amelyek kontextust és képességeket nyújtanak. Feladataik:

- Elérhető funkciók regisztrálása (erőforrások, promptok, eszközök).
- Eszközhívások fogadása és végrehajtása a kliens részéről.
- Kontextuális információ biztosítása a modell válaszainak javítására.
- Eredmények visszaküldése a kliensnek.
- Állapot megtartása az interakciók során, ha szükséges.

A Servers bárki által fejleszthetők, hogy speciális funkciókkal bővítsék a modell képességeit.

### 4. Server Features

Az MCP szerverek alapvető építőelemeket biztosítanak, amelyek gazdag interakciókat tesznek lehetővé kliensek, hosts és nyelvi modellek között. Ezek a funkciók strukturált kontextust, eszközöket és promptokat kínálnak, hogy bővítsék az MCP képességeit.

Az MCP szerverek az alábbi funkciókat kínálhatják:

#### 📑 Erőforrások

Az MCP-ben az erőforrások különféle kontextusokat és adatokat jelentenek, amelyeket a felhasználók vagy az AI modellek hasznosíthatnak. Ezek közé tartoznak:

- **Kontextuális adatok**: Információk és háttér, amelyeket a felhasználók vagy modellek döntéshozatalhoz és feladatvégzéshez használhatnak.
- **Tudásbázisok és dokumentumtárak**: Strukturált és strukturálatlan adatok gyűjteményei, például cikkek, kézikönyvek, kutatási anyagok, amelyek értékes információkat tartalmaznak.
- **Helyi fájlok és adatbázisok**: Eszközön vagy adatbázisban tárolt adatok, amelyek elérhetők feldolgozásra és elemzésre.
- **API-k és webszolgáltatások**: Külső interfészek és szolgáltatások, amelyek további adatokat és funkciókat biztosítanak, lehetővé téve online erőforrásokkal és eszközökkel való integrációt.

Egy erőforrás például lehet egy adatbázis séma vagy egy fájl, amely így érhető el:

```text
file://log.txt
database://schema
```

### 🤖 Promptok

Az MCP promptok előre definiált sablonokat és interakciós mintákat tartalmaznak, amelyek célja a felhasználói munkafolyamatok egyszerűsítése és a kommunikáció javítása. Ezek:

- **Sablonüzenetek és munkafolyamatok**: Előre strukturált üzenetek és folyamatok, amelyek irányítják a felhasználót specifikus feladatokon és interakciókon keresztül.
- **Előre definiált interakciós minták**: Standardizált cselekvéssorozatok és válaszok, amelyek következetes és hatékony kommunikációt biztosítanak.
- **Speciális beszélgetési sablonok**: Testreszabható sablonok bizonyos beszélgetéstípusokhoz, amelyek relevánsak és kontextusban megfelelőek.

Egy prompt sablon így nézhet ki:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Eszközök

Az MCP-ben az eszközök olyan funkciók, amelyeket az AI modell végrehajthat specifikus feladatok elvégzésére. Ezek az eszközök bővítik az AI modell képességeit, megbízható és strukturált műveleteket biztosítva. Főbb jellemzők:

- **Funkciók, amelyeket az AI modell végrehajthat**: Az eszközök futtatható funkciók, amelyeket a modell hívhat meg különféle feladatokhoz.
- **Egyedi név és leírás**: Minden eszköznek egyedi neve és részletes leírása van, amely elmagyarázza a célját és működését.
- **Paraméterek és kimenetek**: Az eszközök specifikus paramétereket fogadnak, és strukturált eredményeket adnak vissza, biztosítva a következetes működést.
- **Diszkrét funkciók**: Az eszközök különálló műveleteket végeznek, például webes keresést, számításokat vagy adatbázis-lekérdezéseket.

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

## Client Funkciók

Az MCP-ben a kliensek több kulcsfontosságú funkciót kínálnak a szervereknek, amelyek növelik a protokoll általános funkcionalitását és interakcióját. Az egyik kiemelt funkció a Sampling.

### 👉 Sampling

- **Szerver által kezdeményezett agentikus viselkedések**: A kliensek lehetővé teszik a szerverek számára, hogy autonóm módon indítsanak el specifikus műveleteket vagy viselkedéseket, növelve a rendszer dinamikus képességeit.
- **Rekurzív LLM interakciók**: Ez a funkció lehetővé teszi a nagynyelvű modellekkel való rekurzív interakciókat, támogatva a komplexebb és iteratív feladatfeldolgozást.
- **További modell-kiegészítések kérése**: A szerverek kérhetnek további válaszokat a modelltől, biztosítva a részletes és kontextusban releváns eredményeket.

## Információáramlás az MCP-ben

Az MCP strukturált információáramlást határoz meg a hosts, clients, servers és modellek között. Ennek megértése segít tisztázni, hogyan dolgozódnak fel a felhasználói kérések, és hogyan integrálódnak a külső eszközök és adatok a modell válaszaiba.

- **A Host kapcsolatot kezdeményez**  
  A host alkalmazás (például IDE vagy csevegőfelület) kapcsolatot létesít egy MCP szerverrel, általában STDIO, WebSocket vagy más támogatott protokollon keresztül.

- **Képességek egyeztetése**  
  A kliens (a hostban) és a szerver információt cserélnek támogatott funkcióikról, eszközeikről, erőforrásaikról és protokoll verzióikról. Ez biztosítja, hogy mindkét fél tisztában legyen a rendelkezésre álló képességekkel.

- **Felhasználói kérés**  
  A felhasználó interakcióba lép a hosttal (például prompt vagy parancs bevitele). A host összegyűjti az inputot, és továbbítja a kliensnek feldolgozásra.

- **Erőforrás vagy eszköz használata**  
  - A kliens további kontextust vagy erőforrásokat kérhet a szervertől (például fájlokat, adatbázis-bejegyzéseket vagy tudásbázis cikkeket), hogy gazdagítsa a modell megértését.
  - Ha a modell úgy ítéli meg, hogy eszköz használata szükséges (pl. adat lekérése, számítás végrehajtása vagy API hívás), a kliens eszközhívási kérést küld a szervernek, megadva az eszköz nevét és paramétereit.

- **Szerver végrehajtás**  
  A szerver fogadja az erőforrás vagy eszközkérést, végrehajtja a szükséges műveleteket (például függvény futtatása, adatbázis lekérdezése vagy fájl lekérése), majd strukturált formában visszaküldi az eredményeket a kliensnek.

- **Válaszgenerálás**  
  A kliens integrálja a szerver válaszait (erőforrás adatok, eszköz eredmények stb.) a folyamatban lévő modell-interakcióba. A modell ezeket felhasználva átfogó és kontextusban releváns választ generál.

- **Eredmény bemutatása**  
  A host megkapja a kliens végső kimenetét, és megjeleníti a felhasználónak, gyakran magában foglalva a modell által generált szöveget és az eszközök vagy erőforrások eredményeit.

Ez a folyamat lehetővé teszi, hogy az MCP fejlett, interaktív és kontextusérzékeny AI alkalmazásokat támogasson, zökkenőmentesen összekapcsolva a modelleket külső eszközökkel és adatforrásokkal.

## Protokoll részletek

Az MCP a [JSON-RPC 2.0](https://www.jsonrpc.org/) protokollra épül, amely szabványos, nyelvfüggetlen üzenetformátumot biztosít a hosts, clients és servers közötti kommunikációhoz. Ez az alap megbízható, strukturált és bővíthető interakciókat tesz lehetővé különböző platformokon és programozási nyelveken.

### Fő Protokoll Jellemzők

Az MCP kiterjeszti a JSON-RPC 2.0-t további konvenciókkal az eszközhívás, erőforrás-hozzáférés és prompt-kezelés terén. Többféle szállítási réteget támogat (STDIO, WebSocket, SSE), és biztonságos, bővíthető, nyelvfüggetlen kommunikációt tesz lehetővé.

#### 🧢 Alapprotokoll

- **JSON-RPC üzenetformátum**: Minden kérés és válasz a JSON-RPC 2.0 szabványt követi, biztosítva az egységes szerkezetet metódushívások, paraméterek, eredmények és hibakezelés esetén.
- **Állapotmegőrző kapcsolatok**: Az MCP munkamenetek több kérésen át megőrzik az állapotot, támogatva a folyamatos beszélgetéseket, kontextus felhalmozást és erőforrás-kezelést.
- **Képességek egyeztetése**: Kapcsolatfelvételkor a kliensek és szerverek információt cserélnek támogatott funkcióikról, protokoll verzióikról, elérhető eszközökről és erőforrásokról. Ez biztosítja, hogy mindkét fél ismerje a másik képességeit és alkalmazkodni tudjon.

#### ➕ További segédfunkciók

Az MCP további kiegészítőket és protokollbővítményeket kínál a fejlesztői élmény javítására és összetettebb helyzetek kezelésére:

- **Konfigurációs lehetőségek**: Dinamikusan állíthatók a munkamenet paraméterei, mint eszköz engedélyek, erőforrás hozzáférés és modell beállítások, személyre szabva az interakciót.
- **Folyamatkövetés**: Hosszú ideig tartó műveletek haladási állapotot jelentenek, lehetővé téve a reszponzív felhasználói felületeket és jobb élményt összetett feladatoknál.
- **Kérés megszakítás**: A kliensek megszakíthatják a folyamatban lévő kéréseket, hogy a felhasználók leállíthassák a már nem szükséges vagy túl hosszú műveleteket.
- **Hibajelentés**: Szabványosított hibaüzenetek és kódok segítik a problémák diagnosztizálását, a hibakezelést és hasznos visszajelzést nyújtanak felhasználóknak és fejlesztőknek.
- **Naplózás**: Mind kliensek, mind szerverek strukturált naplókat generálhatnak auditálásra, hibakeresésre és a protokoll interakciók megfigyelésére.

Ezekkel a funkciókkal az MCP megbízható, biztonságos és rugalmas kommunikációt biztosít a nyelvi modellek és külső eszközök vagy adatforrások között.

### 🔐 Biztonsági Szempontok

Az MCP megvalósításoknak több kulcsfontosságú biztonsági elvet kell követniük a biztonságos és megbízható interakciók érdekében:

- **Felhasználói hozzájárulás és kontroll**: A felhasználóknak explicit hozzájárulást kell adniuk, mielőtt bármilyen adat hozzáférhetővé válna vagy művelet végrehajtódna. Világos kontrollal kell rendelkezniük arr

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár az pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hivatalos forrásnak. Kritikus információk esetén professzionális, emberi fordítás igénybevétele javasolt. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.