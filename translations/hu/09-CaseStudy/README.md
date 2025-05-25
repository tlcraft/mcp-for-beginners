<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:42:52+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hu"
}
-->
# Esettanulmány: Azure AI Utazási Ügynökök – Referencia Implementáció

## Áttekintés

Az [Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) egy átfogó referencia megoldás, amelyet a Microsoft fejlesztett ki, hogy bemutassa, miként lehet több ügynökös, mesterséges intelligenciával támogatott utazástervező alkalmazást építeni a Model Context Protocol (MCP), az Azure OpenAI és az Azure AI Search használatával. Ez a projekt a több AI ügynök összehangolásának, vállalati adatok integrálásának és egy biztonságos, bővíthető platform biztosításának legjobb gyakorlatait szemlélteti valós alkalmazási esetekre.

## Főbb jellemzők
- **Több ügynök összehangolása:** Az MCP segítségével koordinálja a specializált ügynököket (például járat-, szálloda- és útiterv ügynökök), amelyek együttműködve oldják meg a bonyolult utazástervezési feladatokat.
- **Vállalati adat integráció:** Csatlakozik az Azure AI Search-hoz és más vállalati adatforrásokhoz, hogy naprakész, releváns információkat nyújtson az utazási ajánlásokhoz.
- **Biztonságos, skálázható architektúra:** Az Azure szolgáltatásait használja hitelesítéshez, jogosultságkezeléshez és skálázható telepítéshez, követve a vállalati biztonsági legjobb gyakorlatokat.
- **Bővíthető eszköztár:** Újrahasznosítható MCP eszközöket és prompt sablonokat valósít meg, lehetővé téve gyors alkalmazkodást új területekhez vagy üzleti igényekhez.
- **Felhasználói élmény:** Beszélgetés alapú felületet kínál a felhasználóknak az utazási ügynökökkel való interakcióhoz, az Azure OpenAI és az MCP támogatásával.

## Architektúra
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Az architektúra diagram leírása

Az Azure AI Travel Agents megoldás moduláris, skálázható és biztonságos integrációra épül több AI ügynök és vállalati adatforrás között. A fő komponensek és az adatáramlás a következő:

- **Felhasználói felület:** A felhasználók beszélgetés alapú UI-n (például webes chat vagy Teams bot) keresztül lépnek kapcsolatba a rendszerrel, ahol kérdéseket tesznek fel és utazási ajánlásokat kapnak.
- **MCP Server:** Központi összehangolóként működik, fogadja a felhasználói bemenetet, kezeli a kontextust, és koordinálja a specializált ügynökök (pl. FlightAgent, HotelAgent, ItineraryAgent) tevékenységét a Model Context Protocol segítségével.
- **AI ügynökök:** Minden ügynök egy adott területért felelős (járatok, szállodák, útiterv), és MCP eszközként valósul meg. Prompt sablonokat és logikát használnak a kérések feldolgozására és válaszok generálására.
- **Azure OpenAI Service:** Fejlett természetes nyelvi megértést és generálást biztosít, lehetővé téve az ügynökök számára a felhasználói szándék értelmezését és természetes, beszélgetéshez illő válaszok létrehozását.
- **Azure AI Search és vállalati adatok:** Az ügynökök lekérdezik az Azure AI Search-t és más vállalati adatforrásokat, hogy naprakész információkat szerezzenek járatokról, szállodákról és utazási lehetőségekről.
- **Hitelesítés és biztonság:** Integrálódik a Microsoft Entra ID-val a biztonságos hitelesítés érdekében, és minimális jogosultság elvét alkalmazza az összes erőforrásra.
- **Telepítés:** Azure Container Apps-re optimalizált, biztosítva a skálázhatóságot, felügyeletet és működési hatékonyságot.

Ez az architektúra lehetővé teszi a több AI ügynök zökkenőmentes összehangolását, a vállalati adatok biztonságos integrációját, valamint egy robusztus, bővíthető platformot a domain-specifikus AI megoldások fejlesztéséhez.

## Lépésről lépésre az architektúra diagram magyarázata
Képzelj el egy nagy utazás tervezését, ahol egy szakértő asszisztensekből álló csapat segít minden részletben. Az Azure AI Travel Agents rendszer hasonlóan működik, különböző részekből áll (mint egy csapat tagjai), amelyek mindegyike egy speciális feladatot lát el. Íme, hogyan illeszkedik mindez össze:

### Felhasználói felület (UI):
Gondolj erre úgy, mint az utazási ügynököd recepciójára. Itt teszed fel a kérdéseidet vagy adod le a kéréseidet, például „Keress nekem egy járatot Párizsba.” Ez lehet egy weboldali chat ablak vagy egy üzenetküldő alkalmazás.

### MCP Server (Az összehangoló):
Az MCP Server olyan, mint a menedzser, aki meghallgatja a recepcióban a kérésedet, és eldönti, melyik szakértőnek kell foglalkoznia vele. Nyomon követi a beszélgetést, és biztosítja, hogy minden zökkenőmentesen működjön.

### AI ügynökök (Szakértő asszisztensek):
Minden ügynök egy adott terület szakértője – az egyik mindent tud a járatokról, a másik a szállodákról, a harmadik pedig az útiterv tervezéséről. Amikor utazást kérsz, az MCP Server elküldi a kérésed a megfelelő ügynöknek/ügynököknek. Ezek az ügynökök a tudásukat és eszközeiket használva keresik meg a legjobb lehetőségeket.

### Azure OpenAI Service (Nyelvi szakértő):
Ez olyan, mintha lenne egy nyelvi szakértőd, aki pontosan érti, mit kérdezel, bármilyen formában is fogalmazod meg. Segít az ügynököknek megérteni a kéréseidet, és természetes, beszélgetéshez illő válaszokat adni.

### Azure AI Search és vállalati adatok (Információs könyvtár):
Képzelj el egy hatalmas, naprakész könyvtárat, amely a legfrissebb utazási információkat tartalmazza – járatmenetrendeket, szállodai elérhetőségeket és még sok mást. Az ügynökök ebben a könyvtárban keresik meg a legpontosabb válaszokat.

### Hitelesítés és biztonság (Biztonsági őr):
Ahogy egy biztonsági őr ellenőrzi, ki léphet be bizonyos területekre, ez a rész biztosítja, hogy csak jogosult személyek és ügynökök férhessenek hozzá érzékeny információkhoz. Védi az adataidat és a magánéletedet.

### Telepítés Azure Container Apps-en (Az épület):
Minden asszisztens és eszköz együtt dolgozik egy biztonságos, skálázható épületben (a felhőben). Ez azt jelenti, hogy a rendszer egyszerre sok felhasználót tud kiszolgálni, és mindig elérhető, amikor szükséged van rá.

## Hogyan működik ez az egész együtt:

Először a recepciósnál (UI) teszel fel egy kérdést.
A menedzser (MCP Server) eldönti, melyik szakértő (ügynök) segíthet neked.
A szakértő a nyelvi szakértőt (OpenAI) használja a kérésed megértéséhez, és a könyvtárat (AI Search) a legjobb válasz megtalálásához.
A biztonsági őr (Hitelesítés) gondoskodik róla, hogy minden biztonságos legyen.
Mindez egy megbízható, skálázható épületben (Azure Container Apps) történik, így az élmény gördülékeny és biztonságos.
Ez az együttműködés lehetővé teszi, hogy a rendszer gyorsan és biztonságosan segítse az utazásod megtervezését, akárcsak egy szakértő utazási ügynökökből álló csapat egy modern irodában!

## Műszaki megvalósítás
- **MCP Server:** Tárhelye a fő összehangoló logikának, elérhetővé teszi az ügynökök eszközeit, és kezeli a kontextust a többlépéses utazástervezési munkafolyamatokhoz.
- **Ügynökök:** Minden ügynök (pl. FlightAgent, HotelAgent) MCP eszközként valósul meg saját prompt sablonokkal és logikával.
- **Azure integráció:** Az Azure OpenAI-t használja természetes nyelvi megértéshez, az Azure AI Search-t pedig adatlekéréshez.
- **Biztonság:** Integrálódik a Microsoft Entra ID-val a hitelesítéshez, és minimális jogosultság elvét alkalmazza az összes erőforrásra.
- **Telepítés:** Támogatja az Azure Container Apps-re történő telepítést a skálázhatóság és a működési hatékonyság érdekében.

## Eredmények és hatás
- Bemutatja, hogyan lehet az MCP-t használni több AI ügynök összehangolására valós, éles környezetben.
- Gyorsítja a megoldásfejlesztést újrahasznosítható minták biztosításával az ügynökök koordinációjához, adat integrációhoz és biztonságos telepítéshez.
- Mintaként szolgál domain-specifikus, AI-alapú alkalmazások építéséhez MCP és Azure szolgáltatások használatával.

## Hivatkozások
- [Azure AI Travel Agents GitHub tárhely](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Felelősségkizárás**:  
Ezt a dokumentumot az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár az pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hivatalos forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.