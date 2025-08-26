<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-19T14:48:57+00:00",
  "source_file": "changelog.md",
  "language_code": "hu"
}
-->
# Változások naplója: MCP kezdőknek tananyag

Ez a dokumentum a Model Context Protocol (MCP) kezdőknek szóló tananyagában végrehajtott jelentős változások nyilvántartásaként szolgál. A változások fordított időrendben vannak dokumentálva (a legújabb változások elöl).

## 2025. augusztus 18.

### Dokumentáció átfogó frissítése - MCP 2025-06-18 szabványok

#### MCP biztonsági legjobb gyakorlatok (02-Security/) - Teljes modernizáció
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Teljes újraírás az MCP 2025-06-18 specifikációval összhangban
  - **Kötelező követelmények**: Hozzáadva az explicit MUST/MUST NOT követelmények az hivatalos specifikációból, egyértelmű vizuális jelölésekkel
  - **12 alapvető biztonsági gyakorlat**: Átalakítva a 15 elemből álló listát átfogó biztonsági területekre
    - Tokenbiztonság és hitelesítés külső identitásszolgáltató integrációval
    - Munkamenet-kezelés és szállítási biztonság kriptográfiai követelményekkel
    - AI-specifikus fenyegetésvédelem Microsoft Prompt Shields integrációval
    - Hozzáférés-ellenőrzés és jogosultságok a legkisebb jogosultság elvével
    - Tartalombiztonság és monitorozás Azure Content Safety integrációval
    - Ellátási lánc biztonság átfogó komponensellenőrzéssel
    - OAuth biztonság és Confused Deputy megelőzés PKCE implementációval
    - Incidenskezelés és helyreállítás automatizált képességekkel
    - Megfelelőség és irányítás szabályozási összehangolással
    - Fejlett biztonsági kontrollok nulla bizalom architektúrával
    - Microsoft biztonsági ökoszisztéma integráció átfogó megoldásokkal
    - Folyamatos biztonsági fejlődés adaptív gyakorlatokkal
  - **Microsoft biztonsági megoldások**: Fejlesztett integrációs útmutató Prompt Shields, Azure Content Safety, Entra ID és GitHub Advanced Security számára
  - **Implementációs források**: Átfogó forráslinkek kategorizálása hivatalos MCP dokumentáció, Microsoft biztonsági megoldások, biztonsági szabványok és implementációs útmutatók szerint

#### Fejlett biztonsági kontrollok (02-Security/) - Vállalati implementáció
- **MCP-SECURITY-CONTROLS-2025.md**: Teljes átdolgozás vállalati szintű biztonsági keretrendszerrel
  - **9 átfogó biztonsági terület**: Bővítve az alapvető kontrolloktól részletes vállalati keretrendszerig
    - Fejlett hitelesítés és jogosultságkezelés Microsoft Entra ID integrációval
    - Tokenbiztonság és anti-passthrough kontrollok átfogó validációval
    - Munkamenet-biztonsági kontrollok eltérítés megelőzésével
    - AI-specifikus biztonsági kontrollok prompt injekció és eszközmérgezés megelőzésével
    - Confused Deputy támadás megelőzés OAuth proxy biztonsággal
    - Eszközvégrehajtási biztonság sandboxing és izolációval
    - Ellátási lánc biztonsági kontrollok függőségellenőrzéssel
    - Monitorozási és detektálási kontrollok SIEM integrációval
    - Incidenskezelés és helyreállítás automatizált képességekkel
  - **Implementációs példák**: Részletes YAML konfigurációs blokkok és kódpéldák hozzáadva
  - **Microsoft megoldások integrációja**: Átfogó lefedettség Azure biztonsági szolgáltatások, GitHub Advanced Security és vállalati identitáskezelés terén

#### Fejlett témák biztonság (05-AdvancedTopics/mcp-security/) - Gyártásra kész implementáció
- **README.md**: Teljes újraírás vállalati biztonsági implementációhoz
  - **Aktuális specifikációval való összehangolás**: Frissítve az MCP 2025-06-18 specifikációval kötelező biztonsági követelményekkel
  - **Fejlesztett hitelesítés**: Microsoft Entra ID integráció átfogó .NET és Java Spring Security példákkal
  - **AI biztonsági integráció**: Microsoft Prompt Shields és Azure Content Safety implementáció részletes Python példákkal
  - **Fejlett fenyegetéscsökkentés**: Átfogó implementációs példák
    - Confused Deputy támadás megelőzés PKCE és felhasználói beleegyezés validációval
    - Token passthrough megelőzés közönségvalidációval és biztonságos tokenkezeléssel
    - Munkamenet-eltérítés megelőzés kriptográfiai kötés és viselkedéselemzés segítségével
  - **Vállalati biztonsági integráció**: Azure Application Insights monitorozás, fenyegetésdetektálási csatornák és ellátási lánc biztonság
  - **Implementációs ellenőrzőlista**: Egyértelmű kötelező és ajánlott biztonsági kontrollok Microsoft biztonsági ökoszisztéma előnyeivel

### Dokumentáció minősége és szabványok összehangolása
- **Specifikációs hivatkozások**: Frissítve minden hivatkozás az aktuális MCP 2025-06-18 specifikációra
- **Microsoft biztonsági ökoszisztéma**: Fejlesztett integrációs útmutató az összes biztonsági dokumentációban
- **Gyakorlati implementáció**: Részletes kódpéldák hozzáadva .NET, Java és Python nyelveken vállalati mintákkal
- **Források szervezése**: Átfogó kategorizálás hivatalos dokumentáció, biztonsági szabványok és implementációs útmutatók szerint
- **Vizuális jelölések**: Egyértelmű kötelező követelmények és ajánlott gyakorlatok megjelölése

#### Alapfogalmak (01-CoreConcepts/) - Teljes modernizáció
- **Protokoll verzió frissítése**: Frissítve az aktuális MCP 2025-06-18 specifikációra dátum-alapú verziózással (YYYY-MM-DD formátum)
- **Architektúra finomítása**: Fejlesztett leírások a Hostokról, Kliensekről és Szerverekről az aktuális MCP architektúra minták alapján
  - Hostok most egyértelműen AI alkalmazásokként definiálva, amelyek több MCP klienskapcsolatot koordinálnak
  - Kliensek protokollcsatlakozóként leírva, amelyek egy-egy szerverkapcsolatot tartanak fenn
  - Szerverek helyi és távoli telepítési forgatókönyvekkel bővítve
- **Primitívek átalakítása**: Teljes átdolgozás a szerver és kliens primitívekről
  - Szerver primitívek: Erőforrások (adatforrások), Promptek (sablonok), Eszközök (végrehajtható funkciók) részletes magyarázatokkal és példákkal
  - Kliens primitívek: Mintavétel (LLM kimenetek), Elicitáció (felhasználói bemenet), Naplózás (hibakeresés/monitorozás)
  - Frissítve az aktuális felfedezés (`*/list`), lekérés (`*/get`) és végrehajtás (`*/call`) módszerminták szerint
- **Protokoll architektúra**: Két rétegű architektúra modell bevezetése
  - Adatréteg: JSON-RPC 2.0 alap kriptográfiai életciklus-kezeléssel és primitívekkel
  - Szállítási réteg: STDIO (helyi) és Streamable HTTP SSE-vel (távoli) szállítási mechanizmusok
- **Biztonsági keretrendszer**: Átfogó biztonsági elvek, beleértve az explicit felhasználói beleegyezést, adatvédelem védelmét, eszközvégrehajtási biztonságot és szállítási réteg biztonságot
- **Kommunikációs minták**: Frissített protokollüzenetek inicializálás, felfedezés, végrehajtás és értesítési folyamatok bemutatására
- **Kódpéldák**: Többnyelvű példák frissítése (.NET, Java, Python, JavaScript) az aktuális MCP SDK minták szerint

#### Biztonság (02-Security/) - Átfogó biztonsági átdolgozás  
- **Szabványok összehangolása**: Teljes összehangolás az MCP 2025-06-18 specifikáció biztonsági követelményeivel
- **Hitelesítés fejlődése**: Dokumentált fejlődés az egyedi OAuth szerverektől a külső identitásszolgáltató delegációig (Microsoft Entra ID)
- **AI-specifikus fenyegetéselemzés**: Fejlesztett lefedettség a modern AI támadási vektorokról
  - Részletes prompt injekció támadási forgatókönyvek valós példákkal
  - Eszközmérgezési mechanizmusok és "szőnyegkihúzás" támadási minták
  - Kontextusablak mérgezés és modellzavar támadások
- **Microsoft AI biztonsági megoldások**: Átfogó lefedettség a Microsoft biztonsági ökoszisztémáról
  - AI Prompt Shields fejlett detektálással, kiemeléssel és határoló technikákkal
  - Azure Content Safety integrációs minták
  - GitHub Advanced Security az ellátási lánc védelmére
- **Fejlett fenyegetéscsökkentés**: Részletes biztonsági kontrollok
  - Munkamenet-eltérítés MCP-specifikus támadási forgatókönyvekkel és kriptográfiai munkamenet-azonosító követelményekkel
  - Confused Deputy problémák MCP proxy forgatókönyvekben explicit beleegyezési követelményekkel
  - Token passthrough sebezhetőségek kötelező validációs kontrollokkal
- **Ellátási lánc biztonság**: Bővített AI ellátási lánc lefedettség, beleértve az alapmodelleket, beágyazási szolgáltatásokat, kontextus-szolgáltatókat és harmadik fél API-kat
- **Alapbiztonság**: Fejlesztett integráció vállalati biztonsági mintákkal, beleértve a nulla bizalom architektúrát és a Microsoft biztonsági ökoszisztémát
- **Források szervezése**: Átfogó forráslinkek kategorizálása típus szerint (Hivatalos dokumentáció, Szabványok, Kutatás, Microsoft megoldások, Implementációs útmutatók)

### Dokumentáció minőségi fejlesztések
- **Strukturált tanulási célok**: Fejlesztett tanulási célok konkrét, cselekvésre ösztönző eredményekkel
- **Kereszthivatkozások**: Hivatkozások hozzáadása kapcsolódó biztonsági és alapfogalmi témák között
- **Aktuális információk**: Frissítve minden dátumhivatkozás és specifikációs link az aktuális szabványokra
- **Implementációs útmutató**: Konkrét, cselekvésre ösztönző implementációs irányelvek hozzáadása mindkét szakaszban

## 2025. július 16.

### README és navigációs fejlesztések
- Teljesen újratervezett tananyag navigáció README.md-ben
- `<details>` címkék helyett hozzáférhetőbb táblázat-alapú formátumot alkalmazva
- Alternatív elrendezési opciók létrehozása az új "alternative_layouts" mappában
- Kártya-alapú, füles stílusú és harmonika-stílusú navigációs példák hozzáadása
- Frissítve a tárolóstruktúra szakasz az összes legújabb fájl hozzáadásával
- Fejlesztett "Hogyan használjuk ezt a tananyagot" szakasz egyértelmű ajánlásokkal
- Frissítve az MCP specifikációs linkek a megfelelő URL-ekre mutatva
- Kontextusmérnöki szakasz (5.14) hozzáadása a tananyag struktúrájához

### Tanulási útmutató frissítések
- Teljesen átdolgozott tanulási útmutató az aktuális tárolóstruktúrával összhangban
- Új szakaszok hozzáadása MCP kliensek és eszközök, valamint népszerű MCP szerverek számára
- Frissítve a vizuális tananyag térkép az összes témát pontosan tükrözve
- Fejlesztett leírások a fejlett témákról, hogy lefedjék az összes specializált területet
- Frissítve az esettanulmányok szakasz, hogy valós példákat tükrözzön
- Hozzáadva ezt az átfogó változásnaplót

### Közösségi hozzájárulások (06-CommunityContributions/)
- Részletes információk hozzáadása MCP szerverekről képgeneráláshoz
- Átfogó szakasz hozzáadása Claude használatáról VSCode-ban
- Cline terminál kliens beállítási és használati utasítások hozzáadása
- Frissítve az MCP kliens szakasz az összes népszerű kliens opcióval
- Fejlesztett hozzájárulási példák pontosabb kódmintákkal

### Fejlett témák (05-AdvancedTopics/)
- Minden specializált témamappa egységes elnevezéssel szervezve
- Kontextusmérnöki anyagok és példák hozzáadása
- Foundry ügynök integrációs dokumentáció hozzáadása
- Fejlesztett Entra ID biztonsági integrációs dokumentáció

## 2025. június 11.

### Első létrehozás
- Az MCP kezdőknek tananyag első verziójának kiadása
- Alapstruktúra létrehozása mind a 10 fő szakaszhoz
- Vizuális tananyag térkép implementálása navigációhoz
- Első mintaprojektek hozzáadása több programozási nyelven

### Első lépések (03-GettingStarted/)
- Első szerver implementációs példák létrehozása
- Kliensfejlesztési útmutató hozzáadása
- LLM kliens integrációs utasítások hozzáadása
- VS Code integrációs dokumentáció hozzáadása
- Server-Sent Events (SSE) szerver példák implementálása

### Alapfogalmak (01-CoreConcepts/)
- Részletes magyarázat hozzáadása a kliens-szerver architektúráról
- Dokumentáció létrehozása a protokoll kulcskomponenseiről
- Üzenetküldési minták dokumentálása MCP-ben

## 2025. május 23.

### Tárolóstruktúra
- Alapmappastruktúra inicializálása a tárolóban
- README fájlok létrehozása minden fő szakaszhoz
- Fordítási infrastruktúra beállítása
- Képanyagok és diagramok hozzáadása

### Dokumentáció
- Első README.md létrehozása a tananyag áttekintésével
- CODE_OF_CONDUCT.md és SECURITY.md hozzáadása
- SUPPORT.md beállítása segítségkérés útmutatóval
- Előzetes tanulási útmutató struktúra létrehozása

## 2025. április 15.

### Tervezés és keretrendszer
- MCP kezdőknek tananyag kezdeti tervezése
- Tanulási célok és célközönség meghatározása
- A tananyag 10 szakaszos struktúrájának körvonalazása
- Konceptuális keretrendszer kidolgozása példákhoz és esettanulmányokhoz
- Kulcsfogalmak kezdeti prototípus példáinak létrehozása

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.