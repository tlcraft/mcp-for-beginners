<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
<<<<<<< HEAD
  "translation_date": "2025-08-18T19:12:21+00:00",
=======
  "translation_date": "2025-08-18T14:17:36+00:00",
>>>>>>> origin/main
  "source_file": "changelog.md",
  "language_code": "hu"
}
-->
<<<<<<< HEAD
# Változások naplója: MCP kezdőknek tananyag

Ez a dokumentum a Model Context Protocol (MCP) kezdőknek szóló tananyagában végrehajtott jelentős változások nyilvántartásaként szolgál. A változások fordított időrendi sorrendben vannak dokumentálva (a legújabb változások elöl).

## 2025. augusztus 18.

### Dokumentáció átfogó frissítése - MCP 2025-06-18 szabványok

#### MCP biztonsági legjobb gyakorlatok (02-Security/) - Teljes modernizáció
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Teljes újraírás az MCP 2025-06-18 specifikációval összhangban
  - **Kötelező követelmények**: Hozzáadva az explicit KELL/NEM KELL követelmények az hivatalos specifikációból, egyértelmű vizuális jelölésekkel
  - **12 alapvető biztonsági gyakorlat**: Átalakítva a 15 elemből álló listát átfogó biztonsági területekre
=======
# Változásnapló: MCP Kezdőknek Tananyag

Ez a dokumentum a Model Context Protocol (MCP) Kezdőknek szóló tananyagában történt összes jelentős változás nyilvántartására szolgál. A változások fordított időrendben vannak dokumentálva (a legújabb változások elöl).

## 2025. augusztus 18.

### Dokumentáció Teljeskörű Frissítése - MCP 2025-06-18 Szabványok

#### MCP Biztonsági Legjobb Gyakorlatok (02-Security/) - Teljes Modernizáció
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Teljes újraírás az MCP 2025-06-18 Szabványhoz igazítva
  - **Kötelező Követelmények**: Egyértelműen jelölt MUST/MUST NOT követelmények hozzáadása a hivatalos szabványból
  - **12 Alapvető Biztonsági Gyakorlat**: Átalakítás a 15 elemből álló listáról átfogó biztonsági területekre
>>>>>>> origin/main
    - Tokenbiztonság és hitelesítés külső identitásszolgáltató integrációval
    - Munkamenet-kezelés és szállítási biztonság kriptográfiai követelményekkel
    - AI-specifikus fenyegetésvédelem Microsoft Prompt Shields integrációval
    - Hozzáférés-vezérlés és jogosultságok a legkisebb jogosultság elvével
<<<<<<< HEAD
    - Tartalom biztonság és monitorozás Azure Content Safety integrációval
    - Ellátási lánc biztonság átfogó komponens ellenőrzéssel
    - OAuth biztonság és zavart helyettes támadások megelőzése PKCE implementációval
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
    - Zavart helyettes támadások megelőzése OAuth proxy biztonsággal
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
    - Zavart helyettes támadások megelőzése PKCE és felhasználói beleegyezés validációval
    - Token passthrough megelőzése közönségvalidációval és biztonságos tokenkezeléssel
    - Munkamenet-eltérítés megelőzése kriptográfiai kötés és viselkedéselemzés segítségével
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
  - Szerver primitívek: Erőforrások (adatforrások), Promptok (sablonok), Eszközök (végrehajtható funkciók) részletes magyarázatokkal és példákkal
  - Kliens primitívek: Mintavétel (LLM kimenetek), Elicitáció (felhasználói bemenet), Naplózás (hibakeresés/monitorozás)
  - Frissítve az aktuális felfedezés (`*/list`), lekérés (`*/get`) és végrehajtás (`*/call`) módszerminták szerint
- **Protokoll architektúra**: Két rétegű architektúra modell bevezetése
  - Adatréteg: JSON-RPC 2.0 alap lifecycle menedzsmenttel és primitívekkel
  - Szállítási réteg: STDIO (helyi) és Streamable HTTP SSE-vel (távoli) szállítási mechanizmusok
- **Biztonsági keretrendszer**: Átfogó biztonsági elvek, beleértve az explicit felhasználói beleegyezést, adatvédelem védelmét, eszközvégrehajtási biztonságot és szállítási réteg biztonságot
- **Kommunikációs minták**: Frissített protokollüzenetek az inicializálás, felfedezés, végrehajtás és értesítési folyamatok bemutatására
- **Kódpéldák**: Többnyelvű példák frissítése (.NET, Java, Python, JavaScript) az aktuális MCP SDK minták szerint

#### Biztonság (02-Security/) - Átfogó biztonsági átdolgozás  
- **Szabványok összehangolása**: Teljes összehangolás az MCP 2025-06-18 specifikáció biztonsági követelményeivel
- **Hitelesítés fejlődése**: Dokumentálva az egyedi OAuth szerverektől a külső identitásszolgáltató delegációig (Microsoft Entra ID)
- **AI-specifikus fenyegetéselemzés**: Fejlesztett lefedettség a modern AI támadási vektorokról
  - Részletes prompt injekció támadási forgatókönyvek valós példákkal
  - Eszközmérgezési mechanizmusok és "szőnyegkihúzás" támadási minták
  - Kontextusablak mérgezés és modellzavar támadások
- **Microsoft AI biztonsági megoldások**: Átfogó lefedettség a Microsoft biztonsági ökoszisztémáról
  - AI Prompt Shields fejlett detektálással, kiemeléssel és határoló technikákkal
  - Azure Content Safety integrációs minták
  - GitHub Advanced Security az ellátási lánc védelmére
- **Fejlett fenyegetéscsökkentés**: Részletes biztonsági kontrollok
  - Munkamenet-eltérítés MCP-specifikus támadási forgatókönyvekkel és kriptográfiai munkamenetazonosító követelményekkel
  - Zavart helyettes problémák MCP proxy forgatókönyvekben explicit beleegyezési követelményekkel
  - Token passthrough sebezhetőségek kötelező validációs kontrollokkal
- **Ellátási lánc biztonság**: Bővített AI ellátási lánc lefedettség, beleértve az alapmodelleket, beágyazási szolgáltatásokat, kontextus-szolgáltatókat és harmadik fél API-kat
- **Alapvető biztonság**: Fejlesztett integráció vállalati biztonsági mintákkal, beleértve a nulla bizalom architektúrát és a Microsoft biztonsági ökoszisztémát
- **Források szervezése**: Átfogó forráslinkek kategorizálása típus szerint (Hivatalos dokumentáció, Szabványok, Kutatás, Microsoft megoldások, Implementációs útmutatók)

### Dokumentáció minőségi fejlesztések
- **Strukturált tanulási célok**: Fejlesztett tanulási célok konkrét, cselekvésre ösztönző eredményekkel
- **Kereszthivatkozások**: Linkek hozzáadása kapcsolódó biztonsági és alapfogalmi témák között
- **Aktuális információk**: Frissítve minden dátumhivatkozás és specifikációs link az aktuális szabványokra
- **Implementációs útmutató**: Konkrét, cselekvésre ösztönző implementációs irányelvek hozzáadása mindkét szakaszban

## 2025. július 16.

### README és navigációs fejlesztések
- Teljesen újratervezett tananyag navigáció README.md-ben
- `<details>` tagek helyett hozzáférhetőbb táblázat-alapú formátumot alkalmazva
- Alternatív elrendezési opciók létrehozása az új "alternative_layouts" mappában
- Kártya-alapú, füles-stílusú és harmonika-stílusú navigációs példák hozzáadása
- Frissítve a tárolóstruktúra szakasz az összes legújabb fájl hozzáadásával
- Fejlesztett "Hogyan használjuk ezt a tananyagot" szakasz egyértelmű ajánlásokkal
- Frissítve az MCP specifikációs linkek a megfelelő URL-ekre mutatva
- Kontextusmérnöki szakasz (5.14) hozzáadása a tananyag struktúrájához

### Tanulási útmutató frissítések
- Teljesen átdolgozott tanulási útmutató az aktuális tárolóstruktúrával összhangban
- Új szakaszok hozzáadása MCP kliensek és eszközök, valamint népszerű MCP szerverek számára
- Frissítve a vizuális tananyag térkép az összes témát pontosan tükrözve
- Fejlesztett leírások a fejlett témákról az összes specializált terület lefedésére
- Frissítve az esettanulmányok szakasz a valós példák tükrözésére
- Hozzáadva ezt az átfogó változásnaplót

### Közösségi hozzájárulások (06-CommunityContributions/)
- Részletes információk hozzáadása MCP szerverekről képgeneráláshoz
- Átfogó szakasz hozzáadása Claude VSCode-ban való használatáról
- Cline terminál kliens beállítási és használati útmutató hozzáadása
- Frissítve az MCP kliens szakasz az összes népszerű kliens opcióval
- Fejlesztett hozzájárulási példák pontosabb kódmintákkal

### Fejlett témák (05-AdvancedTopics/)
- Minden specializált téma mappa konzisztens elnevezéssel szervezve
=======
    - Tartalombiztonság és felügyelet Azure Content Safety integrációval
    - Ellátási lánc biztonsága átfogó komponensellenőrzéssel
    - OAuth biztonság és Confused Deputy támadások megelőzése PKCE implementációval
    - Incidenskezelés és helyreállítás automatizált képességekkel
    - Megfelelőség és irányítás szabályozási igazodással
    - Fejlett biztonsági vezérlők zéró bizalmi architektúrával
    - Microsoft Biztonsági Ökoszisztéma Integráció átfogó megoldásokkal
    - Folyamatos biztonsági fejlődés adaptív gyakorlatokkal
  - **Microsoft Biztonsági Megoldások**: Fejlesztett integrációs útmutató Prompt Shields, Azure Content Safety, Entra ID és GitHub Advanced Security számára
  - **Implementációs Források**: Átfogó forráslinkek kategorizálása hivatalos MCP dokumentáció, Microsoft biztonsági megoldások, biztonsági szabványok és implementációs útmutatók szerint

#### Fejlett Biztonsági Vezérlők (02-Security/) - Vállalati Implementáció
- **MCP-SECURITY-CONTROLS-2025.md**: Teljes átdolgozás vállalati szintű biztonsági keretrendszerrel
  - **9 Átfogó Biztonsági Terület**: Alapvető vezérlőkből részletes vállalati keretrendszerre bővítve
    - Fejlett hitelesítés és jogosultságkezelés Microsoft Entra ID integrációval
    - Tokenbiztonság és Anti-Passthrough vezérlők átfogó validációval
    - Munkamenet-biztonsági vezérlők eltérítés elleni védelemmel
    - AI-specifikus biztonsági vezérlők prompt injekció és eszközmérgezés megelőzésével
    - Confused Deputy támadások megelőzése OAuth proxy biztonsággal
    - Eszközvégrehajtási biztonság sandboxing és izoláció révén
    - Ellátási lánc biztonsági vezérlők függőségellenőrzéssel
    - Felügyeleti és észlelési vezérlők SIEM integrációval
    - Incidenskezelés és helyreállítás automatizált képességekkel
  - **Implementációs Példák**: Részletes YAML konfigurációs blokkok és kódpéldák hozzáadása
  - **Microsoft Megoldások Integrációja**: Átfogó lefedettség az Azure biztonsági szolgáltatásairól, GitHub Advanced Security-ről és vállalati identitáskezelésről

#### Fejlett Témák Biztonság (05-AdvancedTopics/mcp-security/) - Gyártásra Kész Implementáció
- **README.md**: Teljes újraírás vállalati biztonsági implementációhoz
  - **Aktuális Szabványhoz Igazítás**: Frissítve az MCP 2025-06-18 Szabványhoz kötelező biztonsági követelményekkel
  - **Fejlett Hitelesítés**: Microsoft Entra ID integráció átfogó .NET és Java Spring Security példákkal
  - **AI Biztonsági Integráció**: Microsoft Prompt Shields és Azure Content Safety implementáció részletes Python példákkal
  - **Fejlett Fenyegetésmérséklés**: Átfogó implementációs példák
    - Confused Deputy támadások megelőzése PKCE és felhasználói beleegyezés validációval
    - Token Passthrough megelőzése közönségvalidációval és biztonságos tokenkezeléssel
    - Munkamenet-eltérítés megelőzése kriptográfiai kötésekkel és viselkedéselemzéssel
  - **Vállalati Biztonsági Integráció**: Azure Application Insights monitorozás, fenyegetésészlelési csatornák és ellátási lánc biztonság
  - **Implementációs Ellenőrzőlista**: Egyértelmű kötelező és ajánlott biztonsági vezérlők a Microsoft biztonsági ökoszisztéma előnyeivel

### Dokumentáció Minősége és Szabványokhoz Igazítása
- **Szabványhivatkozások**: Az összes hivatkozás frissítése az aktuális MCP 2025-06-18 Szabványra
- **Microsoft Biztonsági Ökoszisztéma**: Fejlesztett integrációs útmutató az összes biztonsági dokumentációban
- **Gyakorlati Implementáció**: Részletes kódpéldák hozzáadása .NET, Java és Python nyelveken vállalati mintákkal
- **Források Szervezése**: Hivatalos dokumentáció, biztonsági szabványok és implementációs útmutatók átfogó kategorizálása
- **Vizuális Jelölők**: Kötelező követelmények és ajánlott gyakorlatok egyértelmű megjelölése

#### Alapfogalmak (01-CoreConcepts/) - Teljes Modernizáció
- **Protokoll Verziófrissítés**: Frissítve az aktuális MCP 2025-06-18 Szabványra dátum-alapú verziózással (ÉÉÉÉ-HH-NN formátum)
- **Architektúra Finomhangolása**: A Hostok, Kliensek és Szerverek leírásának fejlesztése az aktuális MCP architektúra minták tükrében
  - Hostok most egyértelműen AI alkalmazásokként definiálva, amelyek több MCP klienskapcsolatot koordinálnak
  - Kliensek protokoll csatlakozókként leírva, amelyek egy-egy szerverrel tartanak fenn kapcsolatot
  - Szerverek helyi és távoli telepítési forgatókönyvekkel bővítve
- **Primitívek Átszervezése**: Szerver- és kliensprimitívek teljes átdolgozása
  - Szerverprimitívek: Erőforrások (adatforrások), Promptek (sablonok), Eszközök (végrehajtható funkciók) részletes magyarázatokkal és példákkal
  - Kliensprimitívek: Mintavételezés (LLM kiegészítések), Kiváltás (felhasználói bemenet), Naplózás (hibakeresés/monitorozás)
  - Frissítve az aktuális felfedezési (`*/list`), lekérési (`*/get`) és végrehajtási (`*/call`) módszermintákra
- **Protokoll Architektúra**: Két rétegű architektúra modell bevezetése
  - Adatréteg: JSON-RPC 2.0 alapok életciklus-kezeléssel és primitívekkel
  - Szállítási réteg: STDIO (helyi) és Streamable HTTP SSE-vel (távoli) szállítási mechanizmusok
- **Biztonsági Keretrendszer**: Átfogó biztonsági alapelvek, beleértve a felhasználói beleegyezést, adatvédelem védelmét, eszközvégrehajtási biztonságot és szállítási réteg biztonságot
- **Kommunikációs Minták**: Frissített protokollüzenetek az inicializálás, felfedezés, végrehajtás és értesítési folyamatok bemutatására
- **Kódpéldák**: Többnyelvű példák frissítése (.NET, Java, Python, JavaScript) az aktuális MCP SDK minták tükrében

#### Biztonság (02-Security/) - Átfogó Biztonsági Átdolgozás  
- **Szabványokhoz Igazítás**: Teljes igazítás az MCP 2025-06-18 Szabvány biztonsági követelményeihez
- **Hitelesítés Fejlődése**: Dokumentált fejlődés az egyedi OAuth szerverektől a külső identitásszolgáltatók delegálásáig (Microsoft Entra ID)
- **AI-specifikus Fenyegetéselemzés**: Modern AI támadási vektorok kiterjesztett lefedettsége
  - Részletes prompt injekciós támadási forgatókönyvek valós példákkal
  - Eszközmérgezési mechanizmusok és "szőnyegkihúzás" támadási minták
  - Kontextusablak mérgezés és modellzavarási támadások
- **Microsoft AI Biztonsági Megoldások**: Microsoft biztonsági ökoszisztéma átfogó lefedettsége
  - AI Prompt Shields fejlett észleléssel, kiemeléssel és elválasztási technikákkal
  - Azure Content Safety integrációs minták
  - GitHub Advanced Security az ellátási lánc védelmére
- **Fejlett Fenyegetésmérséklés**: Részletes biztonsági vezérlők
  - Munkamenet-eltérítés MCP-specifikus támadási forgatókönyvekkel és kriptográfiai munkamenet-azonosító követelményekkel
  - Confused Deputy problémák MCP proxy forgatókönyvekben explicit beleegyezési követelményekkel
  - Token passthrough sebezhetőségek kötelező validációs vezérlőkkel
- **Ellátási Lánc Biztonság**: Kiterjesztett AI ellátási lánc lefedettség, beleértve az alapmodelleket, beágyazási szolgáltatásokat, kontextusszolgáltatókat és harmadik fél API-kat
- **Alapvető Biztonság**: Fejlesztett integráció vállalati biztonsági mintákkal, beleértve a zéró bizalmi architektúrát és a Microsoft biztonsági ökoszisztémát
- **Források Szervezése**: Átfogó forráslinkek kategorizálása típus szerint (Hivatalos Dokumentumok, Szabványok, Kutatás, Microsoft Megoldások, Implementációs Útmutatók)

### Dokumentáció Minőségi Fejlesztések
- **Strukturált Tanulási Célok**: Fejlesztett tanulási célok konkrét, cselekvésre ösztönző eredményekkel 
- **Kereszthivatkozások**: Linkek hozzáadása kapcsolódó biztonsági és alapfogalmi témák között
- **Aktuális Információk**: Az összes dátumhivatkozás és szabványlink frissítése az aktuális szabványokra
- **Implementációs Útmutatás**: Konkrét, cselekvésre ösztönző implementációs irányelvek hozzáadása mindkét szekcióban

## 2025. július 16.

### README és Navigációs Fejlesztések
- Teljesen újratervezett tananyag navigáció README.md-ben
- `<details>` tagek cseréje hozzáférhetőbb táblázat-alapú formátumra
- Alternatív elrendezési opciók létrehozása az új "alternative_layouts" mappában
- Kártya-alapú, füles és harmonika-stílusú navigációs példák hozzáadása
- Frissített adattárstruktúra szekció az összes legújabb fájlhoz
- Fejlesztett "Hogyan Használjuk Ezt a Tananyagot" szekció egyértelmű ajánlásokkal
- Frissített MCP szabványlinkek a helyes URL-ekre mutatva
- Kontextusmérnöki szekció (5.14) hozzáadása a tananyag struktúrájához

### Tanulási Útmutató Frissítések
- Teljesen átdolgozott tanulási útmutató az aktuális adattárstruktúrához igazítva
- Új szekciók hozzáadása MCP Kliensek és Eszközök, valamint Népszerű MCP Szerverek témakörben
- Frissített vizuális tananyag térkép az összes téma pontos tükrözésére
- Fejlesztett leírások a Fejlett Témák szekcióban az összes specializált terület lefedésére
- Frissített esettanulmányok szekció valós példák tükrözésére
- Hozzáadva ezt az átfogó változásnaplót

### Közösségi Hozzájárulások (06-CommunityContributions/)
- Részletes információk hozzáadása képgenerálásra alkalmas MCP szerverekről
- Átfogó szekció hozzáadása Claude használatáról VSCode-ban
- Cline terminál kliens beállítási és használati útmutató hozzáadása
- Frissített MCP kliens szekció az összes népszerű kliens opcióval
- Fejlesztett hozzájárulási példák pontosabb kódrészletekkel

### Fejlett Témák (05-AdvancedTopics/)
- Az összes specializált téma mappa konzisztens elnevezéssel történő rendszerezése
>>>>>>> origin/main
- Kontextusmérnöki anyagok és példák hozzáadása
- Foundry ügynök integrációs dokumentáció hozzáadása
- Fejlesztett Entra ID biztonsági integrációs dokumentáció

## 2025. június 11.

<<<<<<< HEAD
### Kezdeti létrehozás
- Az MCP kezdőknek tananyag első verziójának kiadása
- Alapstruktúra létrehozása mind a 10 fő szakaszhoz
- Vizuális tananyag térkép implementálása navigációhoz
- Kezdeti mintaprojektek hozzáadása több programozási nyelven

### Első lépések (03-GettingStarted/)
- Első szerver implementációs példák létrehozása
- Kliensfejlesztési útmutató hozzáadása
- LLM kliens integrációs utasítások hozzáadása
=======
### Kezdeti Létrehozás
- Az MCP Kezdőknek tananyag első verziójának kiadása
- Az összes 10 fő szekció alapstruktúrájának létrehozása
- Vizuális tananyag térkép implementálása a navigációhoz
- Kezdeti mintaprojektek hozzáadása több programozási nyelven

### Első Lépések (03-GettingStarted/)
- Első szerverimplementációs példák létrehozása
- Kliensfejlesztési útmutató hozzáadása
- LLM kliens integrációs útmutató hozzáadása
>>>>>>> origin/main
- VS Code integrációs dokumentáció hozzáadása
- Server-Sent Events (SSE) szerver példák implementálása

### Alapfogalmak (01-CoreConcepts/)
- Részletes magyarázat hozzáadása a kliens-szerver architektúráról
<<<<<<< HEAD
- Dokumentáció létrehozása a protokoll kulcselemeiről
- Üzenetküldési minták dokumentálása MCP-ben

## 2025. május 23.

### Tárolóstruktúra
- Alapmappa-struktúra inicializálása
- README fájlok létrehozása minden fő szakaszhoz
- Fordítási infrastruktúra beállítása
- Képállományok és diagramok hozzáadása

### Dokumentáció
- Kezdeti README.md létrehozása tananyag áttekintéssel
- CODE_OF_CONDUCT.md és SECURITY.md hozzáadása
- SUPPORT.md beállítása segítségkérés útmutatóval
- Kezdeti tanulási útmutató struktúra létrehozása

## 2025. április 15.

### Tervezés és keretrendszer
- MCP kezdőknek tananyag kezdeti tervezése
- Tanulási célok és célközönség meghatározása
- A tananyag 10 szakaszos struktúrájának körvonalazása
- Példák és esettanulmányok koncepcionális keretrendszerének kidolgozása
- Kulcsfogalmak kezdeti prototípus példáinak létrehozása
=======
- Dokumentáció létrehozása a kulcsfontosságú protokoll komponensekről
- MCP üzenetküldési minták dokumentálása

## 2025. május 23.

### Adattár Struktúra
- Az adattár inicializálása alapvető mappastruktúrával
- README fájlok létrehozása minden fő szekcióhoz
- Fordítási infrastruktúra beállítása
- Képanyagok és diagramok hozzáadása

### Dokumentáció
- Kezdeti README.md létrehozása a tananyag áttekintésével
- CODE_OF_CONDUCT.md és SECURITY.md hozzáadása
- SUPPORT.md beállítása segítségkéréshez
- Előzetes tanulási útmutató struktúra létrehozása

## 2025. április 15.

### Tervezés és Keretrendszer
- Az MCP Kezdőknek tananyag kezdeti tervezése
- Tanulási célok és célközönség meghatározása
- A tananyag 10 szekciós struktúrájának felvázolása
- Fogalmi keretrendszer kidolgozása példákhoz és esettanulmányokhoz
- Kezdeti prot
>>>>>>> origin/main

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.