<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6c11b6162171abc895ed75d1e0f368a3",
  "translation_date": "2025-06-20T19:10:27+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hu"
}
-->
# MCP a gyakorlatban: valós esettanulmányok

A Model Context Protocol (MCP) átalakítja, hogyan lépnek kapcsolatba az AI alkalmazások az adatokkal, eszközökkel és szolgáltatásokkal. Ez a rész valós esettanulmányokat mutat be, amelyek gyakorlati alkalmazásokat szemléltetnek különböző vállalati helyzetekben.

## Áttekintés

Ebben a részben konkrét példákon keresztül ismerhetjük meg az MCP megvalósításait, kiemelve, hogy a szervezetek miként használják ezt a protokollt összetett üzleti kihívások megoldására. Az esettanulmányok vizsgálata során betekintést nyerhetünk az MCP sokoldalúságába, skálázhatóságába és gyakorlati előnyeibe a valós helyzetekben.

## Fő tanulási célok

Ezeknek az esettanulmányoknak a segítségével:

- Megértheted, hogyan alkalmazható az MCP konkrét üzleti problémák megoldására
- Megismerheted a különböző integrációs mintákat és architekturális megközelítéseket
- Felismerheted a legjobb gyakorlatokat az MCP vállalati környezetben történő bevezetéséhez
- Rálátást nyerhetsz a valós megvalósítások során felmerülő kihívásokra és megoldásokra
- Lehetőségeket azonosíthatsz arra, hogy hasonló mintákat alkalmazz saját projektjeidben

## Kiemelt esettanulmányok

### 1. [Azure AI Utazási Ügynökök – Referencia megvalósítás](./travelagentsample.md)

Ez az esettanulmány bemutatja a Microsoft átfogó referencia megoldását, amely azt szemlélteti, hogyan lehet MCP, Azure OpenAI és Azure AI Search használatával többügynökös, AI-alapú utazástervező alkalmazást építeni. A projekt kiemeli:

- Többügynökös koordináció MCP segítségével
- Vállalati adatintegráció Azure AI Search-ön keresztül
- Biztonságos, skálázható architektúra Azure szolgáltatásokkal
- Bővíthető eszköztár újrahasznosítható MCP komponensekkel
- Beszélgetés alapú felhasználói élmény Azure OpenAI támogatásával

Az architektúra és a megvalósítás részletei értékes betekintést nyújtanak összetett, többügynökös rendszerek építésébe, ahol az MCP a koordinációs réteg.

### 2. [Azure DevOps elemek frissítése YouTube adatok alapján](./UpdateADOItemsFromYT.md)

Ez az esettanulmány az MCP gyakorlati alkalmazását mutatja be munkafolyamatok automatizálására. Megtudhatjuk, hogyan használhatók az MCP eszközök arra, hogy:

- Online platformokról (YouTube) adatokat nyerjünk ki
- Azure DevOps munkafolyamat elemeit frissítsük
- Ismételhető automatizált munkafolyamatokat hozzunk létre
- Adatokat integráljunk különböző rendszerek között

Ez a példa azt mutatja be, hogy még viszonylag egyszerű MCP megvalósítások is jelentős hatékonyságnövekedést eredményezhetnek a rutinfeladatok automatizálásával és az adatok következetességének javításával a rendszerek között.

## Összefoglalás

Ezek az esettanulmányok kiemelik a Model Context Protocol sokoldalúságát és gyakorlati alkalmazhatóságát valós helyzetekben. Az összetett többügynökös rendszerektől a célzott automatizált munkafolyamatokig az MCP egységes módot kínál az AI rendszerek összekapcsolására azokkal az eszközökkel és adatokkal, amelyekre szükségük van az értékteremtéshez.

Ezeknek a megvalósításoknak a tanulmányozásával betekintést nyerhetsz az architekturális mintákba, megvalósítási stratégiákba és legjobb gyakorlatokba, amelyeket saját MCP projektjeidben is alkalmazhatsz. A példák bizonyítják, hogy az MCP nem csupán elméleti keretrendszer, hanem gyakorlati megoldás valós üzleti kihívásokra.

## További források

- [Azure AI Travel Agents GitHub tárhely](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP eszköz](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP eszköz](https://github.com/microsoft/playwright-mcp)
- [MCP közösségi példák](https://github.com/microsoft/mcp)

**Nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum anyanyelvű változata tekintendő hivatalos forrásnak. Fontos információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.