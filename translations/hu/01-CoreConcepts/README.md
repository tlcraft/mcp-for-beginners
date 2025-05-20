<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T22:20:07+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hu"
}
-->
# 📖 MCP Alapfogalmak: A Model Context Protocol Mesteri Használata az AI Integrációhoz

A Model Context Protocol (MCP) egy erőteljes, szabványosított keretrendszer, amely optimalizálja a kommunikációt a Nagy Nyelvi Modellek (LLM-ek) és külső eszközök, alkalmazások, valamint adatforrások között. Ez az SEO-optimalizált útmutató végigvezet a MCP alapfogalmain, hogy megértsd a kliens-szerver architektúrát, a lényeges összetevőket, a kommunikáció mechanizmusait és a megvalósítás legjobb gyakorlatait.

## Áttekintés

Ebben a leckében megvizsgáljuk a Model Context Protocol (MCP) ökoszisztéma alapvető architektúráját és összetevőit. Megismerheted a kliens-szerver modellt, a kulcsfontosságú elemeket és a kommunikációs mechanizmusokat, amelyek az MCP interakciókat működtetik.

## 👩‍🎓 Fő Tanulási Célok

A lecke végére képes leszel:

- Megérteni az MCP kliens-szerver architektúrát.
- Azonosítani a Hosts, Clients és Servers szerepeit és felelősségeit.
- Elemezni az MCP rugalmas integrációs rétegét alkotó főbb jellemzőket.
- Megérteni az információáramlást az MCP ökoszisztémában.
- Gyakorlati betekintést nyerni a .NET, Java, Python és JavaScript kódpéldákon keresztül.

## 🔎 MCP Architektúra: Mélyebb Pillantás

Az MCP ökoszisztéma kliens-szerver modellen alapul. Ez a moduláris felépítés lehetővé teszi, hogy az AI alkalmazások hatékonyan kommunikáljanak eszközökkel, adatbázisokkal, API-kkal és kontextuális erőforrásokkal. Nézzük meg az architektúrát a legfontosabb elemeire bontva.

### 1. Hosts

A Model Context Protocol (MCP) esetében a Hosts kulcsszerepet játszanak, mint a fő felület, amelyen keresztül a felhasználók kapcsolatba lépnek a protokollal. A Hosts olyan alkalmazások vagy környezetek, amelyek kapcsolatot kezdeményeznek az MCP szerverekkel, hogy adatokat, eszközöket és promptokat érjenek el. Példák Hosts-ra: integrált fejlesztői környezetek (IDE-k) mint a Visual Studio Code, AI eszközök mint a Claude Desktop, vagy egyedi ügynökök, amelyek specifikus feladatokra készültek.

**A Hosts** LLM alkalmazások, amelyek kapcsolatot kezdeményeznek. Ők:

- AI modellekkel kommunikálnak válaszok generálásához.
- Kapcsolatot létesítenek az MCP szerverekkel.
- Kezelik a beszélgetés menetét és a felhasználói felületet.
- Irányítják az engedélyezési és biztonsági korlátozásokat.
- Gondoskodnak a felhasználói beleegyezésről az adatok megosztásához és az eszközök futtatásához.

### 2. Clients

A Clients alapvető összetevők, amelyek elősegítik a Hosts és az MCP szerverek közötti interakciót. A Clients közvetítőként működnek, lehetővé téve, hogy a Hosts hozzáférjenek az MCP szerverek által nyújtott funkciókhoz. Fontos szerepük van a zökkenőmentes kommunikáció és hatékony adatcsere biztosításában az MCP architektúrán belül.

**A Clients** a host alkalmazáson belüli csatlakozók. Ők:

- Kéréseket küldenek a szervereknek promptokkal vagy utasításokkal.
- Tárgyalják a képességeket a szerverekkel.
- Kezelik az AI modellektől érkező eszköz végrehajtási kéréseket.
- Feldolgozzák és megjelenítik a válaszokat a felhasználóknak.

### 3. Servers

A Servers felelősek az MCP kliens kérések kezeléséért és a megfelelő válaszok biztosításáért. Különféle műveleteket végeznek, mint adatlekérés, eszközvégrehajtás vagy prompt generálás. A Servers biztosítják, hogy a kommunikáció a kliensek és a Hosts között hatékony és megbízható legyen, megőrizve az interakció integritását.

**A Servers** szolgáltatások, amelyek kontextust és képességeket nyújtanak. Ők:

- Regisztrálják az elérhető funkciókat (erőforrások, promptok, eszközök)
- Fogadják és végrehajtják a kliens által küldött eszköz hívásokat
- Kontextuális információval támogatják a modell válaszait
- Visszaküldik az eredményeket a kliensnek
- Szükség esetén fenntartják az állapotot az interakciók során

A szervereket bárki fejlesztheti, hogy kiterjessze a modell képességeit speciális funkciókkal.

### 4. Server Features

Az MCP szerverek alapvető építőelemeket biztosítanak, amelyek lehetővé teszik a gazdag interakciókat kliensek, hosts és nyelvi modellek között. Ezek a funkciók struktúrált kontextust, eszközöket és promptokat kínálnak az MCP képességeinek bővítésére.

Az MCP szerverek az alábbi funkciókat kínálhatják:

#### 📑 Resources

Az MCP-ben az erőforrások különféle kontextusokat és adatokat foglalnak magukban, amelyeket a felhasználók vagy az AI modellek hasznosíthatnak. Ezek közé tartoznak:

- **Kontextuális adatok**: Információk és háttéradatok, amelyeket a felhasználók vagy AI modellek döntéshozatalhoz és feladatvégzéshez használhatnak.
- **Tudásbázisok és dokumentumtárak**: Strukturált és strukturálatlan adatok gyűjteményei, például cikkek, kézikönyvek és kutatási anyagok, amelyek értékes betekintést nyújtanak.
- **Helyi fájlok és adatbázisok**: Helyileg tárolt adatok eszközökön vagy adatbázisokban, amelyek feldolgozásra és elemzésre hozzáférhetők.
- **API-k és webszolgáltatások**: Külső interfészek és szolgáltatások, amelyek további adatokat és funkciókat biztosítanak, lehetővé téve az integrációt különféle online erőforrásokkal és eszközökkel.

Például egy erőforrás lehet egy adatbázis séma vagy egy fájl, amely így érhető el:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Az MCP-ben a promptok különféle előre definiált sablonokat és interakciós mintákat tartalmaznak, amelyek célja a felhasználói munkafolyamatok egyszerűsítése és a kommunikáció javítása. Ezek közé tartoznak:

- **Sablonosított üzenetek és munkafolyamatok**: Előre felépített üzenetek és folyamatok, amelyek segítik a felhasználókat specifikus feladatok és interakciók végrehajtásában.
- **Előre definiált interakciós minták**: Standardizált cselekvési és válaszsorozatok, amelyek támogatják a következetes és hatékony kommunikációt.
- **Speciális beszélgetési sablonok**: Testreszabható minták, amelyek adott beszélgetéstípusokra szabottak, biztosítva a releváns és kontextusban megfelelő interakciókat.

Egy prompt sablon így nézhet ki:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Az MCP-ben az eszközök olyan funkciók, amelyeket az AI modell végrehajthat bizonyos feladatok elvégzésére. Ezek az eszközök bővítik az AI modell képességeit, strukturált és megbízható műveleteket kínálva. Fő jellemzőik:

- **Az AI modell által végrehajtható funkciók**: Az eszközök futtatható funkciók, amelyeket az AI modell hívhat meg különféle feladatok elvégzésére.
- **Egyedi név és leírás**: Minden eszköznek egyedi neve és részletes leírása van, amely megmagyarázza a célját és működését.
- **Paraméterek és kimenetek**: Az eszközök specifikus paramétereket fogadnak el és strukturált kimenetet adnak vissza, biztosítva az állandó és kiszámítható eredményeket.
- **Diszkrét funkciók**: Az eszközök különálló feladatokat végeznek, mint például webes keresés, számítások vagy adatbázis lekérdezések.

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

## Client Features

Az MCP-ben a kliensek több kulcsfontosságú funkciót kínálnak a szervereknek, amelyek növelik a protokoll teljes funkcionalitását és interakcióját. Egyik kiemelkedő funkció a Sampling.

### 👉 Sampling

- **Szerver által kezdeményezett ügynöki viselkedések**: A kliensek lehetővé teszik a szerverek számára, hogy autonóm módon indítsanak el specifikus műveleteket vagy viselkedéseket, ezzel növelve a rendszer dinamikus képességeit.
- **Rekurzív LLM interakciók**: Ez a funkció lehetővé teszi a Nagy Nyelvi Modellekkel való rekurzív interakciókat, támogatva a komplexebb és ismétlődő feladatfeldolgozást.
- **További modell kiegészítések kérése**: A szerverek további válaszokat kérhetnek a modelltől, biztosítva, hogy a válaszok átfogóak és kontextuálisan relevánsak legyenek.

## Információáramlás az MCP-ben

A Model Context Protocol (MCP) strukturált információáramlást határoz meg a hosts, clients, servers és modellek között. Ennek megértése segít tisztázni, hogyan dolgozzák fel a felhasználói kéréseket, és hogyan integrálódnak a külső eszközök és adatok a modell válaszaiba.

- **A Host kapcsolatot kezdeményez**  
  A host alkalmazás (például IDE vagy csevegőfelület) kapcsolatot létesít egy MCP szerverrel, általában STDIO, WebSocket vagy más támogatott protokollon keresztül.

- **Képességek tárgyalása**  
  A kliens (a hostban beágyazva) és a szerver információt cserélnek a támogatott funkcióikról, eszközeikről, erőforrásaikról és protokoll verzióikról. Ez biztosítja, hogy mindkét fél tisztában legyen a munkamenet során elérhető lehetőségekkel.

- **Felhasználói kérés**  
  A felhasználó interakcióba lép a hosttal (például promptot vagy parancsot ad meg). A host összegyűjti a bemenetet és továbbítja a kliensnek feldolgozásra.

- **Erőforrás vagy eszköz használata**  
  - A kliens kérhet további kontextust vagy erőforrásokat a szervertől (például fájlokat, adatbázis bejegyzéseket vagy tudásbázis cikkeket) a modell jobb megértéséhez.
  - Ha a modell úgy ítéli meg, hogy eszköz használata szükséges (például adatlekérés, számítás vagy API hívás), a kliens eszköz hívási kérelmet küld a szervernek, megadva az eszköz nevét és paramétereit.

- **Szerver végrehajtás**  
  A szerver fogadja az erőforrás vagy eszköz kérést, végrehajtja a szükséges műveleteket (például függvény futtatás, adatbázis lekérdezés vagy fájl lekérés), majd strukturált formában visszaküldi az eredményt a kliensnek.

- **Válasz generálás**  
  A kliens integrálja a szerver válaszait (erőforrás adatok, eszköz kimenetek stb.) a folyamatban lévő modell interakcióba. A modell ezt az információt használja egy átfogó és kontextuálisan releváns válasz generálásához.

- **Eredmény bemutatása**  
  A host megkapja a kliens végső kimenetét, és bemutatja a felhasználónak, gyakran a modell által generált szöveget és az eszközök végrehajtásának vagy erőforrás lekérések eredményeit együtt.

Ez a folyamat lehetővé teszi, hogy az MCP fejlett, interaktív és kontextus-érzékeny AI alkalmazásokat támogasson, zökkenőmentesen összekapcsolva a modelleket külső eszközökkel és adatforrásokkal.

## Protokoll részletek

Az MCP (Model Context Protocol) a [JSON-RPC 2.0](https://www.jsonrpc.org/) fölé épül, szabványos, nyelvfüggetlen üzenetformátumot biztosítva a hosts, clients és servers közötti kommunikációhoz. Ez az alap megbízható, strukturált és bővíthető interakciókat tesz lehetővé különféle platformokon és programozási nyelveken.

### Fő protokoll jellemzők

Az MCP kiterjeszti a JSON-RPC 2.0-t további konvenciókkal az eszköz hívásokhoz, erőforrás hozzáféréshez és prompt kezeléshez. Többféle transzport réteget támogat (STDIO, WebSocket, SSE), és biztonságos, bővíthető, nyelvfüggetlen kommunikációt tesz lehetővé a komponensek között.

#### 🧢 Alapprotokoll

- **JSON-RPC üzenetformátum**: Minden kérés és válasz a JSON-RPC 2.0 specifikációt követi, biztosítva a következetes szerkezetet a metódushívások, paraméterek, eredmények és hibakezelés terén.
- **Állapotmegőrző kapcsolatok**: Az MCP munkamenetek több kérésen át megőrzik az állapotot, támogatva a folyamatos beszélgetéseket, kontextus felhalmozást és erőforrás kezelést.
- **Képességek tárgyalása**: A kapcsolat létrehozásakor a kliensek és szerverek információt cserélnek a támogatott funkciókról, protokoll verziókról, elérhető eszközökről és erőforrásokról. Ez biztosítja, hogy mindkét fél értse a másik képességeit és azokhoz igazodjon.

#### ➕ További segédletek

Az MCP további hasznos kiterjesztéseket és eszközöket kínál a fejlesztői élmény javítására és haladó forgatókönyvek támogatására:

- **Konfigurációs opciók**: Dinamikusan konfigurálható munkamenet paraméterek, például eszköz engedélyek, erőforrás hozzáférés és modell beállítások, testreszabva az adott interakcióhoz.
- **Folyamatkövetés**: Hosszú ideig futó műveletek képesek állapotfrissítéseket küldeni, támogatva a reszponzív felhasználói felületeket és jobb élményt komplex feladatok során.
- **Kérés megszakítása**: A kliensek megszakíthatják a folyamatban lévő kéréseket, lehetővé téve a felhasználóknak, hogy megszakítsák a már nem szükséges vagy túl hosszú műveleteket.
- **Hibajelentés**: Szabványosított hibaüzenetek és kódok segítik a problémák diagnosztizálását, a hibakezelést és hasznos visszajelzést nyújtanak felhasználóknak és fejlesztőknek.
- **Naplózás**: Kliensek és szerverek strukturált naplókat küldhetnek az auditálás, hibakeresés és protokoll interakciók monitorozása céljából.

Ezekkel a protokoll funkciókkal az MCP biztosítja a robosztus, biztonságos és rugalmas kommunikációt a nyelvi modellek és külső eszközök vagy adatforrások között.

### 🔐 Biztonsági sz

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) használatával fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.