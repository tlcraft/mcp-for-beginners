<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:29:01+00:00",
  "source_file": "changelog.md",
  "language_code": "hu"
}
-->
# Változások naplója: MCP kezdőknek szóló tananyag

Ez a dokumentum a Model Context Protocol (MCP) kezdőknek szóló tananyagában végrehajtott jelentős változások nyilvántartásaként szolgál. A változások fordított időrendben vannak dokumentálva (a legújabb változások elöl).

## 2025. szeptember 15.

### Haladó témák bővítése - Egyedi szállítások és kontextus mérnökség

#### MCP egyedi szállítások (05-AdvancedTopics/mcp-transport/) - Új haladó megvalósítási útmutató
- **README.md**: Teljes megvalósítási útmutató az egyedi MCP szállítási mechanizmusokhoz
  - **Azure Event Grid Transport**: Átfogó szerver nélküli eseményvezérelt szállítási megvalósítás
    - C#, TypeScript és Python példák Azure Functions integrációval
    - Eseményvezérelt architektúra minták skálázható MCP megoldásokhoz
    - Webhook fogadók és push-alapú üzenetkezelés
  - **Azure Event Hubs Transport**: Nagy áteresztőképességű streaming szállítási megvalósítás
    - Valós idejű streaming képességek alacsony késleltetésű forgatókönyvekhez
    - Particionálási stratégiák és ellenőrzési pontok kezelése
    - Üzenetcsomagolás és teljesítményoptimalizálás
  - **Vállalati integrációs minták**: Gyártásra kész architektúra példák
    - Elosztott MCP feldolgozás több Azure Functions között
    - Hibrid szállítási architektúrák, amelyek több szállítási típust kombinálnak
    - Üzenet tartósság, megbízhatóság és hibakezelési stratégiák
  - **Biztonság és monitorozás**: Azure Key Vault integráció és megfigyelési minták
    - Kezelt identitás hitelesítés és minimális jogosultságú hozzáférés
    - Application Insights telemetria és teljesítményfigyelés
    - Áramkör megszakítók és hibatűrési minták
  - **Tesztelési keretrendszerek**: Átfogó tesztelési stratégiák egyedi szállításokhoz
    - Egységtesztelés tesztduplikációkkal és mock keretrendszerekkel
    - Integrációs tesztelés Azure Test Containers segítségével
    - Teljesítmény- és terhelési tesztelési szempontok

#### Kontextus mérnökség (05-AdvancedTopics/mcp-contextengineering/) - Feltörekvő AI diszciplína
- **README.md**: Átfogó feltárás a kontextus mérnökségről mint feltörekvő területről
  - **Alapelvek**: Teljes kontextus megosztás, cselekvési döntés tudatosság és kontextusablak kezelés
  - **MCP protokoll igazítása**: Hogyan kezeli az MCP tervezés a kontextus mérnökség kihívásait
    - Kontextusablak korlátai és progresszív betöltési stratégiák
    - Relevancia meghatározás és dinamikus kontextus visszakeresés
    - Többmódú kontextus kezelés és biztonsági szempontok
  - **Megvalósítási megközelítések**: Egyszálú vs. többügynökös architektúrák
    - Kontextus darabolás és prioritási technikák
    - Progresszív kontextus betöltés és tömörítési stratégiák
    - Rétegezett kontextus megközelítések és visszakeresési optimalizálás
  - **Mérési keretrendszer**: Feltörekvő metrikák a kontextus hatékonyságának értékelésére
    - Bemeneti hatékonyság, teljesítmény, minőség és felhasználói élmény szempontok
    - Kísérleti megközelítések a kontextus optimalizálására
    - Hibaanalízis és javítási módszertanok

#### Tananyag navigációs frissítések (README.md)
- **Fejlesztett modulstruktúra**: Frissített tananyag táblázat az új haladó témák hozzáadásával
  - Kontextus mérnökség (5.14) és Egyedi szállítás (5.15) bejegyzések hozzáadása
  - Egységes formázás és navigációs linkek az összes modulban
  - Frissített leírások, amelyek tükrözik az aktuális tartalom terjedelmét

### Könyvtárstruktúra fejlesztések
- **Elnevezési szabványosítás**: Az "mcp transport" átnevezése "mcp-transport"-ra az egyéb haladó témák mappáinak konzisztenciája érdekében
- **Tartalom szervezése**: Az összes 05-AdvancedTopics mappa most egységes elnevezési mintát követ (mcp-[téma])

### Dokumentáció minőségi fejlesztések
- **MCP specifikáció igazítása**: Az összes új tartalom hivatkozik az aktuális MCP specifikációra (2025-06-18)
- **Többnyelvű példák**: Átfogó kódpéldák C#, TypeScript és Python nyelveken
- **Vállalati fókusz**: Gyártásra kész minták és Azure felhőintegráció az egész dokumentációban
- **Vizuális dokumentáció**: Mermaid diagramok az architektúra és folyamatok vizualizálásához

## 2025. augusztus 18.

### Dokumentáció átfogó frissítése - MCP 2025-06-18 szabványok

#### MCP biztonsági legjobb gyakorlatok (02-Security/) - Teljes modernizáció
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Teljes újraírás az MCP specifikáció 2025-06-18 igazításával
  - **Kötelező követelmények**: Explicit MUST/MUST NOT követelmények hozzáadása az hivatalos specifikációból, egyértelmű vizuális jelölésekkel
  - **12 alapvető biztonsági gyakorlat**: Átszervezve a 15 elemes listából átfogó biztonsági területekre
    - Tokenbiztonság és hitelesítés külső identitásszolgáltató integrációval
    - Munkamenet-kezelés és szállítási biztonság kriptográfiai követelményekkel
    - AI-specifikus fenyegetésvédelem Microsoft Prompt Shields integrációval
    - Hozzáférés-vezérlés és jogosultságok a minimális jogosultság elvével
    - Tartalom biztonság és monitorozás Azure Content Safety integrációval
    - Ellátási lánc biztonság átfogó komponens ellenőrzéssel
    - OAuth biztonság és zavart helyettes támadások megelőzése PKCE megvalósítással
    - Incidens válasz és helyreállítás automatizált képességekkel
    - Megfelelőség és irányítás szabályozási igazítással
    - Haladó biztonsági vezérlők nulla bizalom architektúrával
    - Microsoft biztonsági ökoszisztéma integráció átfogó megoldásokkal
    - Folyamatos biztonsági fejlődés adaptív gyakorlatokkal
  - **Microsoft biztonsági megoldások**: Fejlesztett integrációs útmutató Prompt Shields, Azure Content Safety, Entra ID és GitHub Advanced Security számára
  - **Megvalósítási erőforrások**: Kategorizált átfogó erőforrás linkek hivatalos MCP dokumentáció, Microsoft biztonsági megoldások, biztonsági szabványok és megvalósítási útmutatók szerint

#### Haladó biztonsági vezérlők (02-Security/) - Vállalati megvalósítás
- **MCP-SECURITY-CONTROLS-2025.md**: Teljes átdolgozás vállalati szintű biztonsági keretrendszerrel
  - **9 átfogó biztonsági terület**: Bővítve az alapvető vezérlőktől részletes vállalati keretrendszerig
    - Fejlett hitelesítés és jogosultságkezelés Microsoft Entra ID integrációval
    - Tokenbiztonság és anti-passthrough vezérlők átfogó validációval
    - Munkamenet biztonsági vezérlők eltérítés megelőzésével
    - AI-specifikus biztonsági vezérlők prompt injekció és eszközmérgezés megelőzésével
    - Zavart helyettes támadások megelőzése OAuth proxy biztonsággal
    - Eszköz végrehajtási biztonság sandboxing és izolációval
    - Ellátási lánc biztonsági vezérlők függőség ellenőrzéssel
    - Monitorozási és észlelési vezérlők SIEM integrációval
    - Incidens válasz és helyreállítás automatizált képességekkel
  - **Megvalósítási példák**: Részletes YAML konfigurációs blokkok és kódpéldák hozzáadása
  - **Microsoft megoldások integrációja**: Átfogó lefedettség az Azure biztonsági szolgáltatásokról, GitHub Advanced Security-ről és vállalati identitáskezelésről

#### Haladó témák biztonság (05-AdvancedTopics/mcp-security/) - Gyártásra kész megvalósítás
- **README.md**: Teljes újraírás vállalati biztonsági megvalósításhoz
  - **Aktuális specifikáció igazítása**: Frissítve az MCP specifikáció 2025-06-18-hoz kötelező biztonsági követelményekkel
  - **Fejlesztett hitelesítés**: Microsoft Entra ID integráció átfogó .NET és Java Spring Security példákkal
  - **AI biztonsági integráció**: Microsoft Prompt Shields és Azure Content Safety megvalósítás részletes Python példákkal
  - **Haladó fenyegetéscsökkentés**: Átfogó megvalósítási példák
    - Zavart helyettes támadások megelőzése PKCE és felhasználói beleegyezés validációval
    - Token passthrough megelőzése közönség validációval és biztonságos tokenkezeléssel
    - Munkamenet eltérítés megelőzése kriptográfiai kötés és viselkedéselemzés segítségével
  - **Vállalati biztonsági integráció**: Azure Application Insights monitorozás, fenyegetésészlelési csatornák és ellátási lánc biztonság
  - **Megvalósítási ellenőrzőlista**: Egyértelmű kötelező vs. ajánlott biztonsági vezérlők Microsoft biztonsági ökoszisztéma előnyeivel

### Dokumentáció minőségi és szabvány igazítás
- **Specifikáció hivatkozások**: Az összes hivatkozás frissítése az aktuális MCP specifikáció 2025-06-18-hoz
- **Microsoft biztonsági ökoszisztéma**: Fejlesztett integrációs útmutató az egész biztonsági dokumentációban
- **Gyakorlati megvalósítás**: Részletes kódpéldák hozzáadása .NET, Java és Python nyelveken vállalati mintákkal
- **Erőforrás szervezés**: Átfogó kategorizálás hivatalos dokumentáció, biztonsági szabványok és megvalósítási útmutatók szerint
- **Vizuális jelölések**: Egyértelmű kötelező követelmények vs. ajánlott gyakorlatok megjelölése

---

**Felelősség kizárása**:  
Ez a dokumentum az AI fordítási szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével lett lefordítva. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt professzionális emberi fordítást igénybe venni. Nem vállalunk felelősséget semmilyen félreértésért vagy téves értelmezésért, amely a fordítás használatából eredhet.