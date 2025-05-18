<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:33:44+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "hu"
}
-->
# Esettanulmány: Azure AI Utazási Ügynökök – Referencia Implementáció

## Áttekintés

Az [Azure AI Utazási Ügynökök](https://github.com/Azure-Samples/azure-ai-travel-agents) egy átfogó referencia megoldás, amelyet a Microsoft fejlesztett ki annak bemutatására, hogyan lehet egy többügynökös, AI-alapú utazástervező alkalmazást létrehozni a Model Context Protocol (MCP), Azure OpenAI és Azure AI Search használatával. Ez a projekt bemutatja a legjobb gyakorlatokat több AI ügynök összehangolására, vállalati adatok integrálására, valamint egy biztonságos, bővíthető platform biztosítására valós életbeli forgatókönyvekhez.

## Főbb jellemzők
- **Többügynökös Orkesztráció:** Az MCP-t használja, hogy összehangolja a specializált ügynököket (például repülőjegy, hotel és útiterv ügynökök), amelyek együttműködnek összetett utazástervezési feladatok teljesítésére.
- **Vállalati Adatok Integrációja:** Csatlakozik az Azure AI Search és más vállalati adatforrásokhoz, hogy naprakész, releváns információkat biztosítson utazási ajánlásokhoz.
- **Biztonságos, Skálázható Architektúra:** Az Azure szolgáltatásokat használja hitelesítéshez, jogosultságkezeléshez és skálázható telepítéshez, követve a vállalati biztonsági legjobb gyakorlatokat.
- **Bővíthető Eszközkészlet:** Újrahasznosítható MCP eszközöket és prompt sablonokat valósít meg, lehetővé téve a gyors alkalmazkodást új területekhez vagy üzleti igényekhez.
- **Felhasználói Élmény:** Konverzációs felületet biztosít a felhasználók számára, hogy interakcióba lépjenek az utazási ügynökökkel, az Azure OpenAI és MCP által támogatva.

## Architektúra
![Architektúra](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Architektúra Diagram Leírás

Az Azure AI Utazási Ügynökök megoldás modularitásra, skálázhatóságra és több AI ügynök és vállalati adatforrás biztonságos integrációjára van tervezve. A fő komponensek és adatáramlás a következő:

- **Felhasználói Felület:** A felhasználók a rendszerrel egy konverzációs UI-n (például webes csevegés vagy Teams bot) keresztül lépnek kapcsolatba, amely felhasználói kérdéseket küld és utazási ajánlásokat fogad.
- **MCP Szerver:** Központi orkesztrátorként szolgál, fogadja a felhasználói inputokat, kezeli a kontextust és összehangolja a specializált ügynökök (például FlightAgent, HotelAgent, ItineraryAgent) tevékenységeit a Model Context Protocol segítségével.
- **AI Ügynökök:** Minden ügynök egy adott területért felelős (repülőjáratok, hotelek, útiterv) és MCP eszközként van megvalósítva. Az ügynökök prompt sablonokat és logikát használnak a kérések feldolgozására és válaszok generálására.
- **Azure OpenAI Szolgáltatás:** Fejlett természetes nyelvi megértést és generálást biztosít, lehetővé téve az ügynökök számára a felhasználói szándék értelmezését és konverzációs válaszok generálását.
- **Azure AI Search & Vállalati Adatok:** Az ügynökök lekérdezéseket küldenek az Azure AI Search-nek és más vállalati adatforrásoknak, hogy naprakész információkat kapjanak repülőjáratokról, hotelekről és utazási lehetőségekről.
- **Hitelesítés & Biztonság:** Integrálódik a Microsoft Entra ID-vel a biztonságos hitelesítés érdekében, és minimális jogosultságokkal rendelkező hozzáférési kontrollokat alkalmaz minden erőforrásra.
- **Telepítés:** Az Azure Container Apps-ra való telepítésre van tervezve, biztosítva a skálázhatóságot, monitorozást és operatív hatékonyságot.

Ez az architektúra lehetővé teszi több AI ügynök zökkenőmentes összehangolását, a vállalati adatok biztonságos integrációját, és egy robusztus, bővíthető platformot biztosít domain-specifikus AI megoldások építéséhez.

## Az Architektúra Diagram Lépésről Lépésre Történő Magyarázata
Képzelj el egy nagy utazás tervezését, ahol egy csapat szakértő asszisztens segít minden részletben. Az Azure AI Utazási Ügynökök rendszere hasonlóan működik, különböző részeket (mint csapattagok), amelyek mindegyike különleges feladatot lát el. Így illeszkedik össze minden:

### Felhasználói Felület (UI):
Gondolj rá úgy, mint az utazási ügynököd előcsarnoka. Itt teszel fel kérdéseket vagy kéréseket, mint például „Keress nekem egy járatot Párizsba.” Ez lehet egy chat ablak egy weboldalon vagy egy üzenetküldő alkalmazásban.

### MCP Szerver (Koordinátor):
Az MCP Szerver olyan, mint a menedzser, aki meghallgatja a kérésedet az előcsarnokban és eldönti, melyik szakértőnek kell kezelnie minden részt. Nyomon követi a beszélgetésedet és biztosítja, hogy minden zökkenőmentesen működjön.

### AI Ügynökök (Szakértő Asszisztensek):
Minden ügynök egy adott területen szakértő – egyikük mindent tud a repülőjáratokról, másik a hotelekről, és egy másik az útiterv tervezéséről. Amikor kérsz egy utazást, az MCP Szerver elküldi a kérésedet a megfelelő ügynök(ök)nek. Ezek az ügynökök a tudásukat és eszközeiket használják, hogy megtalálják a legjobb lehetőségeket számodra.

### Azure OpenAI Szolgáltatás (Nyelvi Szakértő):
Ez olyan, mint egy nyelvi szakértő, aki pontosan érti, mit kérsz, bármilyen formában is fogalmazod meg. Segít az ügynököknek megérteni a kérésedet és természetes, konverzációs nyelven válaszolni.

### Azure AI Search & Vállalati Adatok (Információs Könyvtár):
Képzelj el egy hatalmas, naprakész könyvtárat az összes legfrissebb utazási információval – járat menetrendek, hotel elérhetőség és még sok más. Az ügynökök ebben a könyvtárban keresnek, hogy a legpontosabb válaszokat kapják számodra.

### Hitelesítés & Biztonság (Biztonsági Őr):
Ahogy egy biztonsági őr ellenőrzi, ki léphet be bizonyos területekre, ez a rész biztosítja, hogy csak jogosult személyek és ügynökök férjenek hozzá érzékeny információkhoz. Biztonságban és privátban tartja az adataidat.

### Telepítés az Azure Container Apps-ra (Az Épület):
Mindezek az asszisztensek és eszközök egy biztonságos, skálázható épületben (a felhőben) dolgoznak együtt. Ez azt jelenti, hogy a rendszer sok felhasználót tud kezelni egyszerre, és mindig elérhető, amikor szükséged van rá.

## Hogyan működik együtt:

Kérdéssel kezded az előcsarnokban (UI).
A menedzser (MCP Szerver) kitalálja, melyik szakértő (ügynök) segíthet neked.
A szakértő a nyelvi szakértőt (OpenAI) használja a kérésed megértésére és a könyvtárat (AI Search) a legjobb válasz megtalálására.
A biztonsági őr (Hitelesítés) biztosítja, hogy minden biztonságos legyen.
Mindez egy megbízható, skálázható épületben (Azure Container Apps) történik, így az élményed zökkenőmentes és biztonságos.
Ez a csapatmunka lehetővé teszi a rendszer számára, hogy gyorsan és biztonságosan segítsen megtervezni az utazásodat, mint egy modern irodában dolgozó szakértő utazási ügynökök csapata!

## Technikai Megvalósítás
- **MCP Szerver:** A mag orchestration logikát hosztolja, ügynök eszközöket tesz elérhetővé, és kezeli a kontextust több lépéses utazástervezési munkafolyamatokhoz.
- **Ügynökök:** Minden ügynök (például FlightAgent, HotelAgent) egy MCP eszközként van megvalósítva saját prompt sablonokkal és logikával.
- **Azure Integráció:** Az Azure OpenAI-t használja a természetes nyelvi megértéshez és az Azure AI Search-t az adatok lekérdezéséhez.
- **Biztonság:** Integrálódik a Microsoft Entra ID-vel a hitelesítéshez és minimális jogosultságokkal rendelkező hozzáférési kontrollokat alkalmaz minden erőforrásra.
- **Telepítés:** Támogatja az Azure Container Apps-ra való telepítést a skálázhatóság és operatív hatékonyság érdekében.

## Eredmények és Hatás
- Bemutatja, hogyan lehet az MCP-t használni több AI ügynök összehangolására valós, gyártási szintű forgatókönyvekben.
- Gyorsítja a megoldásfejlesztést az ügynökök összehangolására, adatintegrációra és biztonságos telepítésre szolgáló újrahasznosítható minták biztosításával.
- Mintaként szolgál domain-specifikus, AI-alapú alkalmazások építéséhez MCP és Azure szolgáltatások használatával.

## Referenciák
- [Azure AI Utazási Ügynökök GitHub Repozitórium](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Szolgáltatás](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordítási szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.