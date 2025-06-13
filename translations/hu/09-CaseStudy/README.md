<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "23899e82d806f25e5e46e89aab564dca",
  "translation_date": "2025-06-13T21:28:41+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hu"
}
-->
# MCP a gyakorlatban: Valós esettanulmányok

A Model Context Protocol (MCP) átalakítja, hogyan lépnek kapcsolatba az AI alkalmazások az adatokkal, eszközökkel és szolgáltatásokkal. Ez a rész valós esettanulmányokat mutat be, amelyek szemléltetik az MCP gyakorlati alkalmazását különböző vállalati környezetekben.

## Áttekintés

Ebben a szakaszban konkrét példákon keresztül ismerhetjük meg az MCP megvalósításait, kiemelve, hogyan használják a szervezetek ezt a protokollt összetett üzleti kihívások megoldására. Az esettanulmányok elemzése során betekintést nyerhetünk az MCP sokoldalúságába, skálázhatóságába és gyakorlati előnyeibe a valós helyzetekben.

## Fő tanulási célok

Ezeknek az esettanulmányoknak a megismerésével:

- Megértheted, hogyan alkalmazható az MCP konkrét üzleti problémák megoldására
- Megismerheted a különböző integrációs mintákat és architekturális megközelítéseket
- Felismerheted az MCP vállalati környezetben történő bevezetésének legjobb gyakorlatait
- Rálátást kaphatsz a valós megvalósítások során felmerülő kihívásokra és megoldásokra
- Lehetőséget láthatsz hasonló minták alkalmazására saját projektjeidben

## Kiemelt esettanulmányok

### 1. [Azure AI Travel Agents – Referencia megvalósítás](./travelagentsample.md)

Ez az esettanulmány bemutatja a Microsoft átfogó referencia megoldását, amely azt szemlélteti, hogyan építhető fel egy többügynökös, AI-alapú utazástervező alkalmazás MCP, Azure OpenAI és Azure AI Search használatával. A projekt kiemeli:

- Többügynökös koordináció MCP-n keresztül
- Vállalati adatintegráció Azure AI Search segítségével
- Biztonságos, skálázható architektúra Azure szolgáltatásokkal
- Bővíthető eszköztár újrafelhasználható MCP komponensekkel
- Beszélgetés alapú felhasználói élmény Azure OpenAI támogatással

Az architektúra és a megvalósítás részletei értékes betekintést nyújtanak összetett, többügynökös rendszerek építésébe MCP mint koordinációs réteg alkalmazásával.

### 2. [Azure DevOps elemek frissítése YouTube adatok alapján](./UpdateADOItemsFromYT.md)

Ez az esettanulmány egy gyakorlati példát mutat be az MCP használatára munkafolyamatok automatizálásában. Megmutatja, hogyan használhatók az MCP eszközök az alábbiakra:

- Adatok kinyerése online platformokról (YouTube)
- Munkafolyamat elemek frissítése Azure DevOps rendszerekben
- Ismételhető automatizálási folyamatok létrehozása
- Adatok integrálása különálló rendszerek között

Ez a példa rámutat, hogy még viszonylag egyszerű MCP megvalósítások is jelentős hatékonyságnövekedést eredményezhetnek a rutinfeladatok automatizálásával és az adatok konzisztenciájának javításával a rendszerek között.

## Összegzés

Ezek az esettanulmányok kiemelik a Model Context Protocol sokoldalúságát és gyakorlati alkalmazhatóságát valós helyzetekben. Az összetett többügynökös rendszerektől a célzott automatizálási munkafolyamatokig az MCP egységes módot kínál arra, hogy az AI rendszerek összekapcsolódjanak a szükséges eszközökkel és adatokkal, ezáltal értéket teremtsenek.

A megvalósítások tanulmányozásával betekintést nyerhetsz az architekturális mintákba, megvalósítási stratégiákba és legjobb gyakorlatokba, amelyek saját MCP projektjeidben is alkalmazhatók. A példák azt mutatják, hogy az MCP nem csupán elméleti keretrendszer, hanem valós üzleti kihívásokra kínált gyakorlati megoldás.

## További források

- [Azure AI Travel Agents GitHub tárhely](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP eszköz](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP eszköz](https://github.com/microsoft/playwright-mcp)
- [MCP közösségi példák](https://github.com/microsoft/mcp)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén javasolt szakmai, emberi fordítást igénybe venni. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.