<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T14:03:45+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hu"
}
-->
# MCP a gyakorlatban: valós esettanulmányok

A Model Context Protocol (MCP) átalakítja, hogyan lépnek kapcsolatba az AI alkalmazások az adatokkal, eszközökkel és szolgáltatásokkal. Ez a szakasz valós esettanulmányokat mutat be, amelyek a MCP gyakorlati alkalmazásait szemléltetik különböző vállalati helyzetekben.

## Áttekintés

Ebben a részben konkrét példákat láthatunk a MCP megvalósításaira, kiemelve, hogyan használják a szervezetek ezt a protokollt összetett üzleti problémák megoldására. Az esettanulmányok tanulmányozásával betekintést nyerhetünk a MCP sokoldalúságába, skálázhatóságába és gyakorlati előnyeibe valós helyzetekben.

## Fő tanulási célok

Az esettanulmányok áttekintésével képes leszel:

- Megérteni, hogyan alkalmazható a MCP konkrét üzleti problémák megoldására
- Megismerni különböző integrációs mintákat és architekturális megközelítéseket
- Felismerni a MCP bevezetésének legjobb gyakorlatait vállalati környezetben
- Rálátni a valós megvalósítások során felmerülő kihívásokra és megoldásokra
- Azonosítani a hasonló minták alkalmazási lehetőségeit saját projektjeidben

## Kiemelt esettanulmányok

### 1. [Azure AI Utazási Ügynökök – Referencia megvalósítás](./travelagentsample.md)

Ez az esettanulmány a Microsoft átfogó referencia megoldását vizsgálja, amely bemutatja, hogyan lehet MCP, Azure OpenAI és Azure AI Search segítségével több ügynökös, mesterséges intelligenciával támogatott utazástervező alkalmazást építeni. A projekt bemutatja:

- Több ügynök összehangolását MCP-n keresztül
- Vállalati adatintegrációt Azure AI Search segítségével
- Biztonságos, skálázható architektúrát Azure szolgáltatásokkal
- Bővíthető eszköztárat újrahasználható MCP komponensekkel
- Beszélgetés-alapú felhasználói élményt Azure OpenAI támogatással

Az architektúra és a megvalósítás részletei értékes betekintést nyújtanak összetett, több ügynökös rendszerek építésébe, ahol a MCP a koordinációs réteg.

### 2. [Azure DevOps elemek frissítése YouTube adatokból](./UpdateADOItemsFromYT.md)

Ez az esettanulmány a MCP gyakorlati alkalmazását mutatja be munkafolyamatok automatizálására. Megtudhatod, hogyan használhatók a MCP eszközök:

- Adatok kinyerésére online platformokról (YouTube)
- Munkafolyamat elemek frissítésére Azure DevOps rendszerekben
- Ismételhető automatizált folyamatok létrehozására
- Adatok integrálására különböző rendszerek között

Ez a példa azt szemlélteti, hogy még viszonylag egyszerű MCP megvalósítások is jelentős hatékonyságnövekedést hozhatnak a rutin feladatok automatizálásával és az adatok konzisztenciájának javításával.

### 3. [Valós idejű dokumentáció lekérése MCP-vel](./docs-mcp/README.md)

Ez az esettanulmány végigvezet azon, hogyan csatlakoztathatsz egy Python konzolos klienst egy Model Context Protocol (MCP) szerverhez valós idejű, kontextus-érzékeny Microsoft dokumentáció lekéréséhez és naplózásához. Megtanulhatod, hogyan:

- Csatlakozz MCP szerverhez Python klienssel és a hivatalos MCP SDK-val
- Használj streaming HTTP klienseket hatékony, valós idejű adatlekéréshez
- Hívj meg dokumentációs eszközöket a szerveren és naplózd a válaszokat közvetlenül a konzolra
- Integráld a friss Microsoft dokumentációt a munkafolyamatodba anélkül, hogy elhagynád a terminált

A fejezet gyakorlati feladatot, minimális működő kódmintát és további tanulási forrásokat is tartalmaz. A teljes lépésről-lépésre útmutatót és a kódot a kapcsolt fejezetben találod, hogy megértsd, hogyan alakíthatja át a MCP a dokumentációhoz való hozzáférést és a fejlesztői hatékonyságot konzolos környezetekben.

### 4. [Interaktív tanulási terv generáló webalkalmazás MCP-vel](./docs-mcp/README.md)

Ez az esettanulmány bemutatja, hogyan építhetsz interaktív webalkalmazást Chainlit és a Model Context Protocol (MCP) segítségével, amely személyre szabott tanulási terveket készít bármilyen témában. A felhasználók megadhatnak egy témakört (például „AI-900 tanúsítás”) és tanulási időtartamot (például 8 hét), az alkalmazás pedig heti bontásban ajánlott tartalmakat kínál. A Chainlit beszélgetés-alapú chat felületet biztosít, így az élmény interaktív és alkalmazkodó.

- Beszélgetés-alapú webalkalmazás Chainlit támogatással
- Felhasználó által vezérelt témakör és időtartam megadása
- Heti bontású tartalomajánlások MCP segítségével
- Valós idejű, alkalmazkodó válaszok chat felületen

A projekt azt mutatja be, hogyan kombinálható a beszélgetés-alapú AI és a MCP dinamikus, felhasználóközpontú oktatási eszközök létrehozásához modern webes környezetben.

### 5. [Szerkesztőn belüli dokumentáció MCP szerverrel VS Code-ban](./docs-mcp/README.md)

Ez az esettanulmány azt mutatja be, hogyan hozhatod be a Microsoft Learn Docs tartalmakat közvetlenül a VS Code szerkesztőbe MCP szerver segítségével – így nem kell böngészőfüleket váltogatni! Megtudhatod, hogyan:

- Azonnal kereshetsz és olvashatsz dokumentációt a VS Code-ban az MCP panel vagy parancspaletta segítségével
- Hivatkozhatsz dokumentációra és szúrhatsz be linkeket közvetlenül README vagy tanfolyam markdown fájlokba
- Egyesítheted a GitHub Copilotot és az MCP-t zökkenőmentes, AI-alapú dokumentációs és kódfolyamatokhoz
- Valós idejű visszajelzéssel és Microsoft által biztosított pontossággal ellenőrizheted és javíthatod dokumentációdat
- Integrálhatod az MCP-t a GitHub munkafolyamatokba a folyamatos dokumentáció-ellenőrzés érdekében

A megvalósítás tartalmazza:
- Példa `.vscode/mcp.json` konfigurációt az egyszerű beállításhoz
- Képernyőképes útmutatókat a szerkesztőn belüli élményről
- Tippeket a Copilot és MCP kombinálásához a maximális hatékonyság érdekében

Ez a forgatókönyv ideális tanfolyamkészítőknek, dokumentációíróknak és fejlesztőknek, akik a szerkesztőjükben szeretnének maradni miközben dokumentációval, Copilottal és ellenőrző eszközökkel dolgoznak – mindezt MCP támogatással.

## Összefoglalás

Ezek az esettanulmányok rávilágítanak a Model Context Protocol sokoldalúságára és gyakorlati alkalmazásaira valós helyzetekben. Az összetett több ügynökös rendszerektől a célzott automatizált munkafolyamatokig a MCP szabványosított módot kínál arra, hogy az AI rendszerek hatékonyan kapcsolódjanak az őket támogató eszközökhöz és adatokhoz.

Ezeknek a megvalósításoknak a tanulmányozásával betekintést nyerhetsz architekturális mintákba, implementációs stratégiákba és legjobb gyakorlatokba, amelyeket saját MCP projektjeidben is alkalmazhatsz. A példák bizonyítják, hogy a MCP nem csupán elméleti keretrendszer, hanem valódi üzleti kihívásokra adott gyakorlati megoldás.

## További források

- [Azure AI Travel Agents GitHub tárhely](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP eszköz](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP eszköz](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP szerver](https://github.com/MicrosoftDocs/mcp)
- [MCP közösségi példák](https://github.com/microsoft/mcp)

**Nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum anyanyelvű változatát kell tekinteni hiteles forrásnak. Fontos információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.