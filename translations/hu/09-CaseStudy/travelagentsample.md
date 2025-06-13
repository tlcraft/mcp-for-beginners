<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:52:12+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "hu"
}
-->
# Esettanulmány: Azure AI Utazási Ügynökök – Referencia Implementáció

## Áttekintés

Az [Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) egy átfogó referencia megoldás, amelyet a Microsoft fejlesztett ki, és amely bemutatja, hogyan lehet több ügynökös, mesterséges intelligenciával támogatott utazástervező alkalmazást létrehozni a Model Context Protocol (MCP), az Azure OpenAI és az Azure AI Search használatával. Ez a projekt a legjobb gyakorlatokat szemlélteti az AI ügynökök összehangolására, vállalati adatok integrálására, valamint egy biztonságos és bővíthető platform biztosítására valós üzleti helyzetekhez.

## Főbb jellemzők
- **Több ügynök összehangolása:** Az MCP-t használja a specializált ügynökök (például repülőjárat, szállás és útiterv ügynökök) koordinálására, amelyek együttműködve teljesítik a komplex utazástervezési feladatokat.
- **Vállalati adatok integrálása:** Csatlakozik az Azure AI Search-hoz és egyéb vállalati adatforrásokhoz, hogy naprakész és releváns információkat nyújtson az utazási ajánlásokhoz.
- **Biztonságos, skálázható architektúra:** Az Azure szolgáltatásait használja hitelesítéshez, jogosultságkezeléshez és skálázható telepítéshez, követve a vállalati biztonsági legjobb gyakorlatokat.
- **Bővíthető eszközök:** Újrahasznosítható MCP eszközöket és prompt sablonokat valósít meg, amelyek gyors alkalmazkodást tesznek lehetővé új területeken vagy üzleti igények esetén.
- **Felhasználói élmény:** Beszélgetős felületet biztosít a felhasználók számára az utazási ügynökökkel való interakcióhoz, az Azure OpenAI és az MCP támogatásával.

## Architektúra
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Az architektúra diagram leírása

Az Azure AI Travel Agents megoldás moduláris, skálázható és biztonságos integrációra tervezett több AI ügynök és vállalati adatforrás összekapcsolásához. A főbb komponensek és az adatáramlás a következők:

- **Felhasználói felület:** A felhasználók egy beszélgetős UI-n (például webes csevegő vagy Teams bot) keresztül kommunikálnak a rendszerrel, ahol lekérdezéseket küldenek és utazási ajánlásokat kapnak.
- **MCP Server:** Központi koordinátorként működik, fogadja a felhasználói bemenetet, kezeli a kontextust, és összehangolja a specializált ügynökök (pl. FlightAgent, HotelAgent, ItineraryAgent) tevékenységét a Model Context Protocol segítségével.
- **AI ügynökök:** Minden ügynök egy adott területért felelős (repülőjáratok, szállások, útiterv), és MCP eszközként van megvalósítva. Ezek az ügynökök prompt sablonokat és logikát használnak a kérések feldolgozásához és válaszok generálásához.
- **Azure OpenAI Service:** Fejlett természetes nyelvi megértést és generálást biztosít, lehetővé téve az ügynökök számára a felhasználói szándék értelmezését és beszélgetős válaszok előállítását.
- **Azure AI Search és vállalati adatok:** Az ügynökök lekérdezik az Azure AI Search-t és egyéb vállalati adatforrásokat, hogy naprakész információkat szerezzenek a repülőjáratokról, szállásokról és utazási lehetőségekről.
- **Hitelesítés és biztonság:** A Microsoft Entra ID-vel integrálódik a biztonságos hitelesítés érdekében, és a legkisebb jogosultság elvét alkalmazza az összes erőforrásra.
- **Telepítés:** Azure Container Apps-re tervezve a skálázhatóság, monitorozás és működési hatékonyság érdekében.

Ez az architektúra lehetővé teszi a több AI ügynök zökkenőmentes összehangolását, a vállalati adatok biztonságos integrációját, valamint egy robusztus, bővíthető platformot domain-specifikus AI megoldások építéséhez.

## Lépésről lépésre az architektúra diagram magyarázata
Képzelj el egy nagy utazás megtervezését, ahol egy szakértő asszisztens csapat segít minden részletben. Az Azure AI Travel Agents rendszer hasonló módon működik, különböző részekből áll (mint a csapattagok), akik mindegyike egy speciális feladatért felelős. Íme, hogyan illeszkedik össze minden:

### Felhasználói felület (UI):
Gondolj erre úgy, mint az utazási ügynököd recepciójára. Itt teszed fel a kérdéseidet vagy adod le a kéréseidet, például „Találj nekem egy repülőjáratot Párizsba.” Ez lehet egy weboldalon lévő csevegőablak vagy egy üzenetküldő alkalmazás.

### MCP Server (A koordinátor):
Az MCP Server olyan, mint a menedzser, aki a recepcióban meghallgatja a kérésed, és eldönti, melyik szakértőhöz kell irányítani a feladatot. Nyomon követi a beszélgetést, és biztosítja, hogy minden gördülékenyen működjön.

### AI ügynökök (Szakértő asszisztensek):
Minden ügynök egy adott terület specialistája — az egyik a repülőjáratokban, a másik a szállásokban, a harmadik az útiterv tervezésében jártas. Amikor utazást kérsz, az MCP Server elküldi a kérésed a megfelelő ügynök(ök)nek. Ezek az ügynökök a tudásukat és eszközeiket használva keresik meg a legjobb lehetőségeket számodra.

### Azure OpenAI Service (Nyelvi szakértő):
Olyan, mintha lenne egy nyelvi szakértőd, aki pontosan érti, mit kérsz, bármilyen módon is fogalmazd meg. Segíti az ügynököket a kéréseid értelmezésében és természetes, beszélgetős válaszok generálásában.

### Azure AI Search és vállalati adatok (Információs könyvtár):
Képzelj el egy hatalmas, mindig naprakész könyvtárat, amelyben megtalálhatók a legfrissebb utazási információk — repülőjáratok menetrendje, szállásfoglaltság és egyéb adatok. Az ügynökök ebben a könyvtárban keresnek, hogy a legpontosabb válaszokat adják neked.

### Hitelesítés és biztonság (Biztonsági őr):
Ahogy egy biztonsági őr ellenőrzi, ki léphet be bizonyos területekre, ez a rész gondoskodik arról, hogy csak jogosult személyek és ügynökök férjenek hozzá érzékeny adatokhoz. Így védve van az adatod és a magánszférád.

### Telepítés Azure Container Apps-en (Az épület):
Minden asszisztens és eszköz egy biztonságos, skálázható épületben (a felhőben) dolgozik együtt. Ez azt jelenti, hogy a rendszer egyszerre sok felhasználót képes kiszolgálni, és mindig elérhető, amikor szükséged van rá.

## Hogyan működik ez együtt:

Először a recepcióban (UI) teszel fel egy kérdést.
A menedzser (MCP Server) eldönti, melyik szakértő (ügynök) segít neked.
A szakértő a nyelvi szakértőhöz (OpenAI) fordul, hogy megértse a kérésed, majd az információs könyvtárban (AI Search) keresi a legjobb választ.
A biztonsági őr (Hitelesítés) biztosítja, hogy minden biztonságos maradjon.
Mindez egy megbízható, skálázható épületben (Azure Container Apps) zajlik, így az élmény gördülékeny és biztonságos.
Ez az együttműködés lehetővé teszi, hogy a rendszer gyorsan és biztonságosan segítsen megtervezni az utazásodat, akárcsak egy szakértői utazási iroda modern csapata!

## Technikai megvalósítás
- **MCP Server:** A fő összehangoló logikát futtatja, elérhetővé teszi az ügynökök eszközeit, és kezeli a több lépéses utazástervezési munkafolyamatok kontextusát.
- **Ügynökök:** Minden ügynök (pl. FlightAgent, HotelAgent) MCP eszközként van megvalósítva saját prompt sablonokkal és logikával.
- **Azure integráció:** Az Azure OpenAI-t használja természetes nyelvi megértéshez, az Azure AI Search-t pedig adatlekéréshez.
- **Biztonság:** A Microsoft Entra ID-vel integrálódik a hitelesítéshez, és a legkisebb jogosultság elvét alkalmazza az összes erőforrásra.
- **Telepítés:** Támogatja az Azure Container Apps-re történő telepítést a skálázhatóság és működési hatékonyság érdekében.

## Eredmények és hatás
- Bemutatja, hogyan használható az MCP több AI ügynök összehangolására valós, éles környezetben.
- Gyorsítja a megoldásfejlesztést újrahasznosítható minták biztosításával az ügynökök koordinálásához, az adatintegrációhoz és a biztonságos telepítéshez.
- Útmutatóként szolgál domain-specifikus, AI-alapú alkalmazások építéséhez az MCP és az Azure szolgáltatások használatával.

## Hivatkozások
- [Azure AI Travel Agents GitHub tárhely](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.