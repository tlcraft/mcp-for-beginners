<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
<<<<<<< HEAD
  "translation_date": "2025-08-18T19:12:59+00:00",
=======
  "translation_date": "2025-08-18T14:18:38+00:00",
>>>>>>> origin/main
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hu"
}
-->
<<<<<<< HEAD
# MCP akcióban: Valós esettanulmányok

[![MCP akcióban: Valós esettanulmányok](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.hu.png)](https://youtu.be/IxshWb2Az5w)

_(Kattints a fenti képre a leckéhez tartozó videó megtekintéséhez)_

A Model Context Protocol (MCP) átalakítja, ahogyan az AI alkalmazások kapcsolatba lépnek az adatokkal, eszközökkel és szolgáltatásokkal. Ebben a részben valós esettanulmányokat mutatunk be, amelyek szemléltetik az MCP gyakorlati alkalmazását különböző vállalati környezetekben.
=======
# MCP működés közben: Valós esettanulmányok

[![MCP működés közben: Valós esettanulmányok](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.hu.png)](https://youtu.be/IxshWb2Az5w)

_(Kattints a fenti képre a leckéhez tartozó videó megtekintéséhez)_

A Model Context Protocol (MCP) átalakítja, ahogyan az AI alkalmazások kapcsolatba lépnek az adatokkal, eszközökkel és szolgáltatásokkal. Ebben a részben valós esettanulmányokat mutatunk be, amelyek szemléltetik az MCP gyakorlati alkalmazását különböző vállalati helyzetekben.
>>>>>>> origin/main

## Áttekintés

Ez a rész konkrét példákat mutat be az MCP megvalósítására, kiemelve, hogyan használják a szervezetek ezt a protokollt összetett üzleti problémák megoldására. Az esettanulmányok vizsgálatával betekintést nyerhetsz az MCP sokoldalúságába, skálázhatóságába és gyakorlati előnyeibe valós helyzetekben.

## Fő tanulási célok

Az esettanulmányok megismerésével:

- Megérted, hogyan alkalmazható az MCP konkrét üzleti problémák megoldására
- Megtanulod a különböző integrációs mintákat és architekturális megközelítéseket
- Felismered az MCP vállalati környezetben történő megvalósításának legjobb gyakorlatait
- Betekintést nyersz a valós megvalósítások során felmerülő kihívásokba és megoldásokba
- Azonosítod azokat a lehetőségeket, amelyekkel hasonló mintákat alkalmazhatsz saját projektjeidben

## Kiemelt esettanulmányok

<<<<<<< HEAD
### 1. [Azure AI Utazási Ügynökök – Referencia Megvalósítás](./travelagentsample.md)
=======
### 1. [Azure AI Utazási Ügynökök – Referencia megvalósítás](./travelagentsample.md)
>>>>>>> origin/main

Ez az esettanulmány a Microsoft átfogó referencia megoldását vizsgálja, amely bemutatja, hogyan lehet MCP, Azure OpenAI és Azure AI Search segítségével több ügynököt használó, AI-alapú utazástervező alkalmazást építeni. A projekt bemutatja:

- Több ügynök koordinációját MCP segítségével
- Vállalati adatintegrációt az Azure AI Search használatával
- Biztonságos, skálázható architektúrát Azure szolgáltatásokkal
- Bővíthető eszközöket újrahasznosítható MCP komponensekkel
<<<<<<< HEAD
- Beszélgetésalapú felhasználói élményt az Azure OpenAI által
=======
- Beszélgetés-alapú felhasználói élményt az Azure OpenAI által
>>>>>>> origin/main

Az architektúra és megvalósítás részletei értékes betekintést nyújtanak az összetett, több ügynököt használó rendszerek MCP koordinációs rétegként történő felépítésébe.

### 2. [Azure DevOps elemek frissítése YouTube adatokból](./UpdateADOItemsFromYT.md)

Ez az esettanulmány bemutatja az MCP gyakorlati alkalmazását munkafolyamatok automatizálására. Megmutatja, hogyan használhatók az MCP eszközök:

- Adatok kinyerésére online platformokról (YouTube)
- Munkafolyamat-elemek frissítésére Azure DevOps rendszerekben
- Ismételhető automatizálási munkafolyamatok létrehozására
- Adatok integrálására különböző rendszerek között

<<<<<<< HEAD
Ez a példa szemlélteti, hogy még a viszonylag egyszerű MCP megvalósítások is jelentős hatékonyságnövekedést eredményezhetnek rutin feladatok automatizálásával és az adatok konzisztenciájának javításával.
=======
Ez a példa szemlélteti, hogy még a viszonylag egyszerű MCP megvalósítások is jelentős hatékonyságnövekedést eredményezhetnek az ismétlődő feladatok automatizálásával és az adatok konzisztenciájának javításával.
>>>>>>> origin/main

### 3. [Valós idejű dokumentáció lekérése MCP-vel](./docs-mcp/README.md)

Ez az esettanulmány bemutatja, hogyan lehet egy Python konzol klienssel csatlakozni egy Model Context Protocol (MCP) szerverhez, hogy valós idejű, kontextusfüggő Microsoft dokumentációt lehessen lekérni és naplózni. Megtanulhatod, hogyan:

- Csatlakozz MCP szerverhez Python kliens és hivatalos MCP SDK használatával
- Használj streaming HTTP klienseket hatékony, valós idejű adatlekéréshez
- Hívj dokumentációs eszközöket a szerveren, és naplózd a válaszokat közvetlenül a konzolba
- Integráld a legfrissebb Microsoft dokumentációt a munkafolyamatodba anélkül, hogy elhagynád a terminált

<<<<<<< HEAD
A fejezet tartalmaz egy gyakorlati feladatot, egy minimális működő kódmintát, valamint további forrásokhoz vezető linkeket a mélyebb tanuláshoz. Nézd meg a teljes bemutatót és kódot a kapcsolódó fejezetben, hogy megértsd, hogyan alakíthatja át az MCP a dokumentáció elérését és a fejlesztői produktivitást konzol-alapú környezetekben.

### 4. [Interaktív tanulási terv generáló webalkalmazás MCP-vel](./docs-mcp/README.md)

Ez az esettanulmány bemutatja, hogyan lehet interaktív webalkalmazást építeni Chainlit és Model Context Protocol (MCP) használatával, amely személyre szabott tanulási terveket generál bármely témához. A felhasználók megadhatnak egy témát (például "AI-900 minősítés") és egy tanulási időtartamot (pl. 8 hét), az alkalmazás pedig heti bontásban ajánlott tartalmat biztosít. A Chainlit lehetővé teszi egy beszélgetésalapú chat interfész létrehozását, amely élvezetes és alkalmazkodó élményt nyújt.

- Beszélgetésalapú webalkalmazás Chainlit által
- Felhasználó által vezérelt kérdések a témáról és időtartamról
- Heti bontású tartalomajánlások MCP segítségével
- Valós idejű, adaptív válaszok chat interfészben

A projekt bemutatja, hogyan kombinálható a beszélgetésalapú AI és MCP dinamikus, felhasználóvezérelt oktatási eszközök létrehozására modern webkörnyezetben.

### 5. [Dokumentáció a szerkesztőben MCP szerverrel VS Code-ban](./docs-mcp/README.md)

Ez az esettanulmány bemutatja, hogyan hozhatod be a Microsoft Learn dokumentációt közvetlenül a VS Code környezetedbe MCP szerver használatával – többé nem kell böngészőfülek között váltogatni! Megtudhatod, hogyan:

- Azonnal kereshetsz és olvashatsz dokumentációt a VS Code MCP paneljén vagy parancspalettáján keresztül
- Hivatkozhatsz dokumentációra, és beszúrhatsz linkeket közvetlenül README vagy kurzus markdown fájlokba
- Használhatod a GitHub Copilotot és MCP-t együtt zökkenőmentes, AI-alapú dokumentációs és kódmunkafolyamatokhoz
- Valós idejű visszajelzéssel és Microsoft által biztosított pontossággal javíthatod dokumentációdat
- Integrálhatod MCP-t GitHub munkafolyamatokkal folyamatos dokumentáció validálás érdekében

A megvalósítás tartalmazza:

- Példa `.vscode/mcp.json` konfigurációt az egyszerű beállításhoz
- Képernyőképekkel illusztrált bemutatót a szerkesztői élményről
- Tippeket a Copilot és MCP kombinálásához a maximális produktivitás érdekében

Ez a forgatókönyv ideális kurzus szerzőknek, dokumentáció íróknak és fejlesztőknek, akik szeretnének a szerkesztőjükben maradni, miközben dokumentációval, Copilot-tal és validációs eszközökkel dolgoznak – mindezt MCP által támogatva.

### 6. [APIM MCP szerver létrehozása](./apimsample.md)

Ez az esettanulmány lépésről lépésre bemutatja, hogyan lehet MCP szervert létrehozni Azure API Management (APIM) használatával. Kitér:

- MCP szerver beállítására Azure API Management-ben
- API műveletek MCP eszközként való kitettségére
- Rate limiting és biztonsági szabályzatok konfigurálására
- MCP szerver tesztelésére Visual Studio Code és GitHub Copilot használatával
=======
A fejezet tartalmaz egy gyakorlati feladatot, egy minimális működő kódmintát, valamint további forrásokhoz vezető linkeket a mélyebb tanuláshoz. A teljes bemutató és kód a kapcsolódó fejezetben található, amely megmutatja, hogyan alakíthatja át az MCP a dokumentáció elérését és a fejlesztői termelékenységet konzol-alapú környezetekben.

### 4. [Interaktív tanulási terv generáló webalkalmazás MCP-vel](./docs-mcp/README.md)

Ez az esettanulmány bemutatja, hogyan lehet interaktív webalkalmazást építeni Chainlit és Model Context Protocol (MCP) használatával, amely személyre szabott tanulási terveket generál bármely témához. A felhasználók megadhatnak egy témát (például "AI-900 minősítés") és egy tanulási időtartamot (pl. 8 hét), az alkalmazás pedig heti bontásban ajánlott tartalmat biztosít. A Chainlit lehetővé teszi egy beszélgetés-alapú chat interfész létrehozását, amely élvezetes és alkalmazkodó élményt nyújt.

- Beszélgetés-alapú webalkalmazás Chainlit által
- Felhasználó által vezérelt kérdések a témáról és időtartamról
- Heti bontású tartalomajánlások MCP segítségével
- Valós idejű, alkalmazkodó válaszok chat interfészben

A projekt bemutatja, hogyan kombinálható a beszélgetés-alapú AI és MCP dinamikus, felhasználó által vezérelt oktatási eszközök létrehozására modern webkörnyezetben.

### 5. [Szerkesztőben elérhető dokumentáció MCP szerverrel VS Code-ban](./docs-mcp/README.md)

Ez az esettanulmány bemutatja, hogyan hozhatod el a Microsoft Learn dokumentációt közvetlenül a VS Code környezetedbe MCP szerver használatával – nincs többé szükség böngészőfülek váltogatására! Megtudhatod, hogyan:

- Azonnal kereshetsz és olvashatsz dokumentációt a VS Code MCP paneljén vagy parancspalettáján keresztül
- Hivatkozhatsz dokumentációra, és illeszthetsz be linkeket közvetlenül README vagy kurzus markdown fájlokba
- Használhatod a GitHub Copilotot és MCP-t együtt zökkenőmentes, AI-alapú dokumentációs és kódmunkafolyamatokhoz
- Valós idejű visszajelzéssel és Microsoft által biztosított pontossággal ellenőrizheted és javíthatod dokumentációdat
- Integrálhatod MCP-t GitHub munkafolyamatokkal folyamatos dokumentáció ellenőrzéshez

A megvalósítás tartalmaz:

- Példa `.vscode/mcp.json` konfigurációt az egyszerű beállításhoz
- Képernyőképekkel illusztrált bemutatót a szerkesztőben történő használatról
- Tippeket a Copilot és MCP kombinálásához a maximális termelékenység érdekében

Ez a forgatókönyv ideális kurzus szerzőknek, dokumentáció íróknak és fejlesztőknek, akik szeretnének a szerkesztőjükben maradni, miközben dokumentációval, Copilot-tal és ellenőrző eszközökkel dolgoznak – mindezt MCP által támogatva.

### 6. [APIM MCP szerver létrehozása](./apimsample.md)

Ez az esettanulmány lépésről lépésre bemutatja, hogyan hozhatsz létre MCP szervert az Azure API Management (APIM) használatával. A következőket tartalmazza:

- MCP szerver beállítása az Azure API Management-ben
- API műveletek MCP eszközként való kitettsége
- Politikai konfigurációk beállítása sebességkorlátozásra és biztonságra
- MCP szerver tesztelése Visual Studio Code és GitHub Copilot használatával
>>>>>>> origin/main

Ez a példa bemutatja, hogyan lehet az Azure képességeit kihasználva robusztus MCP szervert létrehozni, amely különböző alkalmazásokban használható, javítva az AI rendszerek integrációját vállalati API-kkal.

## Összegzés

<<<<<<< HEAD
Ezek az esettanulmányok kiemelik a Model Context Protocol sokoldalúságát és gyakorlati alkalmazását valós helyzetekben. Az összetett több ügynököt használó rendszerektől a célzott automatizálási munkafolyamatokig az MCP szabványosított módot kínál az AI rendszerek összekapcsolására az általuk szükséges eszközökkel és adatokkal, hogy értéket teremtsenek.
=======
Ezek az esettanulmányok kiemelik a Model Context Protocol sokoldalúságát és gyakorlati alkalmazásait valós helyzetekben. Az összetett több ügynököt használó rendszerektől a célzott automatizálási munkafolyamatokig az MCP szabványosított módot kínál az AI rendszerek összekapcsolására az általuk szükséges eszközökkel és adatokkal, hogy értéket teremtsenek.
>>>>>>> origin/main

Az implementációk tanulmányozásával betekintést nyerhetsz az architekturális mintákba, megvalósítási stratégiákba és legjobb gyakorlatokba, amelyeket saját MCP projektjeidben alkalmazhatsz. A példák megmutatják, hogy az MCP nem csupán elméleti keretrendszer, hanem gyakorlati megoldás valós üzleti kihívásokra.

## További források

- [Azure AI Utazási Ügynökök GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Eszköz](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Eszköz](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Szerver](https://github.com/MicrosoftDocs/mcp)
- [MCP Közösségi Példák](https://github.com/microsoft/mcp)

Következő: Gyakorlati labor [AI munkafolyamatok egyszerűsítése: MCP szerver építése AI Toolkit segítségével](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Felelősség kizárása**:  
Ez a dokumentum az AI fordítási szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével lett lefordítva. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt professzionális emberi fordítást igénybe venni. Nem vállalunk felelősséget semmilyen félreértésért vagy téves értelmezésért, amely a fordítás használatából eredhet.