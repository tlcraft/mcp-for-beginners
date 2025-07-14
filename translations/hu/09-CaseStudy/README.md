<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-14T05:50:03+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hu"
}
-->
# MCP a gyakorlatban: Valós esettanulmányok

A Model Context Protocol (MCP) átalakítja, hogyan lépnek kapcsolatba az AI alkalmazások az adatokkal, eszközökkel és szolgáltatásokkal. Ez a rész valós esettanulmányokat mutat be, amelyek szemléltetik az MCP gyakorlati alkalmazását különböző vállalati helyzetekben.

## Áttekintés

Ebben a szakaszban konkrét példákat láthatunk az MCP megvalósításaira, kiemelve, hogyan használják a szervezetek ezt a protokollt összetett üzleti kihívások megoldására. Ezeknek az esettanulmányoknak a tanulmányozásával betekintést nyerhetünk az MCP sokoldalúságába, skálázhatóságába és gyakorlati előnyeibe a valós helyzetekben.

## Fő tanulási célok

Ezeknek az esettanulmányoknak a megismerésével:

- Megértheted, hogyan alkalmazható az MCP konkrét üzleti problémák megoldására
- Megismerheted a különböző integrációs mintákat és architekturális megközelítéseket
- Felismerheted a legjobb gyakorlatokat az MCP vállalati környezetben történő bevezetéséhez
- Rálátást nyerhetsz a valós megvalósítások során felmerülő kihívásokra és megoldásokra
- Azonosíthatod azokat a lehetőségeket, ahol hasonló mintákat alkalmazhatsz saját projektjeidben

## Kiemelt esettanulmányok

### 1. [Azure AI Utazási Ügynökök – Referencia megvalósítás](./travelagentsample.md)

Ez az esettanulmány bemutatja a Microsoft átfogó referencia megoldását, amely azt szemlélteti, hogyan lehet MCP, Azure OpenAI és Azure AI Search használatával többügynökös, AI-alapú utazástervező alkalmazást építeni. A projekt bemutatja:

- Többügynökös koordináció MCP-n keresztül
- Vállalati adatintegráció Azure AI Search segítségével
- Biztonságos, skálázható architektúra Azure szolgáltatásokkal
- Bővíthető eszköztár újrahasznosítható MCP komponensekkel
- Beszélgetés-alapú felhasználói élmény Azure OpenAI támogatással

Az architektúra és a megvalósítás részletei értékes betekintést nyújtanak összetett, többügynökös rendszerek építéséhez, ahol az MCP a koordinációs réteg.

### 2. [Azure DevOps elemek frissítése YouTube adatok alapján](./UpdateADOItemsFromYT.md)

Ez az esettanulmány egy gyakorlati MCP alkalmazást mutat be munkafolyamatok automatizálására. Megtudhatod, hogyan használhatók az MCP eszközök:

- Adatok kinyerésére online platformokról (YouTube)
- Munkafeladatok frissítésére Azure DevOps rendszerekben
- Ismételhető automatizált munkafolyamatok létrehozására
- Adatok integrálására különböző rendszerek között

Ez a példa azt szemlélteti, hogy még viszonylag egyszerű MCP megvalósítások is jelentős hatékonyságnövekedést hozhatnak a rutinfeladatok automatizálásával és az adatok konzisztenciájának javításával.

### 3. [Valós idejű dokumentáció lekérése MCP-vel](./docs-mcp/README.md)

Ez az esettanulmány végigvezet azon, hogyan lehet egy Python konzol klienssel kapcsolódni egy Model Context Protocol (MCP) szerverhez, hogy valós idejű, kontextusérzékeny Microsoft dokumentációt kérjünk le és naplózzunk. Megtanulhatod, hogyan:

- Csatlakozz MCP szerverhez Python kliens és az hivatalos MCP SDK segítségével
- Használj streaming HTTP klienseket hatékony, valós idejű adatlekéréshez
- Hívj dokumentációs eszközöket a szerveren, és naplózd a válaszokat közvetlenül a konzolra
- Integráld a naprakész Microsoft dokumentációt a munkafolyamatodba anélkül, hogy elhagynád a terminált

A fejezet gyakorlati feladatot, minimális működő kódmintát és további tanulási forrásokat is tartalmaz. A teljes útmutatót és kódot a hivatkozott fejezetben találod, amely megmutatja, hogyan alakíthatja át az MCP a dokumentációhoz való hozzáférést és a fejlesztői hatékonyságot konzolos környezetben.

### 4. [Interaktív tanulási terv generátor webalkalmazás MCP-vel](./docs-mcp/README.md)

Ez az esettanulmány bemutatja, hogyan lehet Chainlit és a Model Context Protocol (MCP) használatával interaktív webalkalmazást építeni, amely személyre szabott tanulási terveket generál bármilyen témához. A felhasználók megadhatnak egy témát (például „AI-900 tanúsítvány”) és egy tanulási időtartamot (pl. 8 hét), az alkalmazás pedig heti bontásban ajánl tartalmakat. A Chainlit beszélgetés-alapú chat felületet biztosít, így az élmény interaktív és alkalmazkodó.

- Beszélgetés-alapú webalkalmazás Chainlit segítségével
- Felhasználó által vezérelt témaválasztás és időtartam
- Heti bontású tartalomajánlások MCP-vel
- Valós idejű, alkalmazkodó válaszok chat felületen

A projekt bemutatja, hogyan lehet a beszélgetés-alapú AI-t és az MCP-t kombinálni dinamikus, felhasználóközpontú oktatási eszközök létrehozásához modern webes környezetben.

### 5. [Beépített dokumentáció MCP szerverrel VS Code-ban](./docs-mcp/README.md)

Ez az esettanulmány megmutatja, hogyan hozhatod be a Microsoft Learn dokumentációt közvetlenül a VS Code környezetedbe MCP szerver segítségével – így nem kell böngészőfüleket váltogatnod! Megtudhatod, hogyan:

- Azonnal kereshetsz és olvashatsz dokumentációt a VS Code MCP paneljén vagy parancspalettáján keresztül
- Hivatkozhatsz dokumentációra és illeszthetsz be linkeket közvetlenül README vagy tananyag markdown fájlokba
- Használhatod a GitHub Copilotot és az MCP-t együtt zökkenőmentes, AI-alapú dokumentációs és kódolási munkafolyamatokhoz
- Valós idejű visszajelzéssel ellenőrizheted és javíthatod dokumentációdat Microsoft által biztosított pontossággal
- Integrálhatod az MCP-t GitHub munkafolyamatokkal a folyamatos dokumentációellenőrzéshez

A megvalósítás tartalmazza:
- Példa `.vscode/mcp.json` konfigurációt az egyszerű beállításhoz
- Képernyőképes útmutatókat a beépített élményről
- Tippeket a Copilot és MCP együttes használatához a maximális hatékonyság érdekében

Ez a forgatókönyv ideális tananyagkészítőknek, dokumentációíróknak és fejlesztőknek, akik szeretnének a szerkesztőjükben maradva dolgozni dokumentációval, Copilottal és ellenőrző eszközökkel – mindezt MCP támogatással.

### 6. [APIM MCP szerver létrehozása](./apimsample.md)

Ez az esettanulmány lépésről lépésre bemutatja, hogyan hozhatsz létre MCP szervert Azure API Management (APIM) használatával. Lefedi:

- MCP szerver beállítása Azure API Managementben
- API műveletek MCP eszközökként való kitettsége
- Szabályzatok konfigurálása sebességkorlátozásra és biztonságra
- MCP szerver tesztelése Visual Studio Code és GitHub Copilot segítségével

Ez a példa azt mutatja be, hogyan használhatod ki az Azure képességeit egy robusztus MCP szerver létrehozásához, amely különféle alkalmazásokban használható, és elősegíti az AI rendszerek integrációját vállalati API-kkal.

## Összefoglalás

Ezek az esettanulmányok kiemelik a Model Context Protocol sokoldalúságát és gyakorlati alkalmazásait valós helyzetekben. Az összetett többügynökös rendszerektől a célzott automatizált munkafolyamatokig az MCP szabványosított módot kínál arra, hogy az AI rendszerek összekapcsolódjanak a szükséges eszközökkel és adatokkal, így értéket teremtsenek.

Ezeknek a megvalósításoknak a tanulmányozásával betekintést nyerhetsz az architekturális mintákba, megvalósítási stratégiákba és legjobb gyakorlatokba, amelyeket saját MCP projektjeidben is alkalmazhatsz. A példák bizonyítják, hogy az MCP nem csupán elméleti keretrendszer, hanem gyakorlati megoldás valós üzleti kihívásokra.

## További források

- [Azure AI Travel Agents GitHub tárhely](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP eszköz](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP eszköz](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP szerver](https://github.com/MicrosoftDocs/mcp)
- [MCP közösségi példák](https://github.com/microsoft/mcp)

Következő: Gyakorlati labor [AI munkafolyamatok egyszerűsítése: MCP szerver építése AI eszköztárral](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.