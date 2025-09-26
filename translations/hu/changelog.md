<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:56:40+00:00",
  "source_file": "changelog.md",
  "language_code": "hu"
}
-->
# Változások naplója: MCP kezdőknek tananyag

Ez a dokumentum a Model Context Protocol (MCP) kezdőknek szóló tananyagában történt jelentős változások nyilvántartására szolgál. A változások fordított időrendben vannak dokumentálva (a legújabb változások elöl).

## 2025. szeptember 26.

### Esettanulmányok bővítése - GitHub MCP Registry integráció

#### Esettanulmányok (09-CaseStudy/) - Ökoszisztéma fejlesztés fókuszban
- **README.md**: Jelentős bővítés átfogó GitHub MCP Registry esettanulmánnyal
  - **GitHub MCP Registry esettanulmány**: Új, átfogó esettanulmány a GitHub MCP Registry 2025 szeptemberi bevezetéséről
    - **Problémaelemzés**: Részletes vizsgálat a töredezett MCP szerver felfedezési és telepítési kihívásokról
    - **Megoldás architektúra**: GitHub központosított regiszter megközelítése egykattintásos VS Code telepítéssel
    - **Üzleti hatás**: Mérhető javulások a fejlesztői bevezetésben és termelékenységben
    - **Stratégiai érték**: Moduláris ügynök telepítés és eszközök közötti interoperabilitás hangsúlyozása
    - **Ökoszisztéma fejlesztés**: Alapvető platformként való pozícionálás az ügynöki integrációhoz
  - **Esettanulmányok szerkezetének bővítése**: Mind a hét esettanulmány frissítése egységes formázással és átfogó leírásokkal
    - Azure AI utazási ügynökök: Több ügynök összehangolásának hangsúlyozása
    - Azure DevOps integráció: Munkafolyamat automatizálás fókuszban
    - Valós idejű dokumentáció visszakeresés: Python konzol kliens megvalósítás
    - Interaktív tanulási terv generátor: Chainlit beszélgető webalkalmazás
    - Dokumentáció szerkesztőben: VS Code és GitHub Copilot integráció
    - Azure API kezelés: Vállalati API integrációs minták
    - GitHub MCP Registry: Ökoszisztéma fejlesztés és közösségi platform
  - **Átfogó következtetés**: Újraírt következtetés szakasz, amely kiemeli a hét esettanulmányt, amelyek az MCP megvalósítás különböző dimenzióit ölelik fel
    - Vállalati integráció, több ügynök összehangolás, fejlesztői termelékenység
    - Ökoszisztéma fejlesztés, oktatási alkalmazások kategorizálása
    - Mélyebb betekintés az architektúra mintákba, megvalósítási stratégiákba és legjobb gyakorlatokba
    - Hangsúly az MCP mint érett, gyártásra kész protokoll

#### Tanulási útmutató frissítések (study_guide.md)
- **Vizuális tananyag térkép**: Frissített gondolattérkép, amely tartalmazza a GitHub MCP Registry-t az esettanulmányok szekcióban
- **Esettanulmányok leírása**: Általános leírások helyett részletes bontás a hét átfogó esettanulmányról
- **Repository szerkezet**: Frissített 10. szekció, amely tükrözi az átfogó esettanulmány lefedettséget konkrét megvalósítási részletekkel
- **Változások naplója integráció**: Hozzáadva a 2025. szeptember 26-i bejegyzés, amely dokumentálja a GitHub MCP Registry hozzáadását és az esettanulmányok bővítéseit
- **Dátum frissítések**: Frissített lábléc időbélyeg az utolsó revízióra (2025. szeptember 26.)

### Dokumentáció minőségi fejlesztések
- **Konzisztencia javítása**: Egységes esettanulmány formázás és szerkezet minden példában
- **Átfogó lefedettség**: Az esettanulmányok most már kiterjednek vállalati, fejlesztői termelékenységi és ökoszisztéma fejlesztési forgatókönyvekre
- **Stratégiai pozícionálás**: Fokozott hangsúly az MCP mint alapvető platform az ügynöki rendszerek telepítéséhez
- **Erőforrás integráció**: Frissített további erőforrások, amelyek tartalmazzák a GitHub MCP Registry linket

## 2025. szeptember 15.

### Haladó témák bővítése - Egyedi szállítások és kontextus mérnökség

#### MCP egyedi szállítások (05-AdvancedTopics/mcp-transport/) - Új haladó megvalósítási útmutató
- **README.md**: Teljes megvalósítási útmutató az egyedi MCP szállítási mechanizmusokhoz
  - **Azure Event Grid szállítás**: Átfogó szerver nélküli eseményvezérelt szállítási megvalósítás
    - C#, TypeScript és Python példák Azure Functions integrációval
    - Eseményvezérelt architektúra minták skálázható MCP megoldásokhoz
    - Webhook fogadók és push-alapú üzenetkezelés
  - **Azure Event Hubs szállítás**: Nagy áteresztőképességű streaming szállítási megvalósítás
    - Valós idejű streaming képességek alacsony késleltetésű forgatókönyvekhez
    - Particionálási stratégiák és ellenőrzési pontok kezelése
    - Üzenetcsomagolás és teljesítmény optimalizálás
  - **Vállalati integrációs minták**: Gyártásra kész architektúra példák
    - Elosztott MCP feldolgozás több Azure Functions között
    - Hibrid szállítási architektúrák több szállítási típus kombinálásával
    - Üzenet tartósság, megbízhatóság és hibaelhárítási stratégiák
  - **Biztonság és monitorozás**: Azure Key Vault integráció és megfigyelési minták
    - Kezelt identitás hitelesítés és minimális jogosultság hozzáférés
    - Application Insights telemetria és teljesítmény monitorozás
    - Áramkör megszakítók és hibatűrési minták
  - **Tesztelési keretrendszerek**: Átfogó tesztelési stratégiák az egyedi szállításokhoz
    - Egységtesztelés teszt duplikátumokkal és mock keretrendszerekkel
    - Integrációs tesztelés Azure Test Containers segítségével
    - Teljesítmény és terhelési tesztelési szempontok

#### Kontextus mérnökség (05-AdvancedTopics/mcp-contextengineering/) - Feltörekvő AI diszciplína
- **README.md**: Átfogó feltárás a kontextus mérnökségről mint feltörekvő területről
  - **Alapelvek**: Teljes kontextus megosztás, cselekvési döntés tudatosság és kontextus ablak kezelés
  - **MCP protokoll igazítás**: Hogyan kezeli az MCP tervezés a kontextus mérnökség kihívásait
    - Kontextus ablak korlátok és progresszív betöltési stratégiák
    - Relevancia meghatározás és dinamikus kontextus visszakeresés
    - Többmódú kontextus kezelés és biztonsági szempontok
  - **Megvalósítási megközelítések**: Egy szálú vs. több ügynök architektúrák
    - Kontextus darabolás és prioritási technikák
    - Progresszív kontextus betöltés és tömörítési stratégiák
    - Rétegezett kontextus megközelítések és visszakeresési optimalizálás
  - **Mérési keretrendszer**: Feltörekvő metrikák a kontextus hatékonyságának értékelésére
    - Bemeneti hatékonyság, teljesítmény, minőség és felhasználói élmény szempontok
    - Kísérleti megközelítések a kontextus optimalizálására
    - Hibaanalízis és javítási módszertanok

#### Tananyag navigációs frissítések (README.md)
- **Fejlesztett modul szerkezet**: Frissített tananyag táblázat, amely tartalmazza az új haladó témákat
  - Hozzáadva Kontextus mérnökség (5.14) és Egyedi szállítás (5.15) bejegyzések
  - Egységes formázás és navigációs linkek minden modulban
  - Frissített leírások, amelyek tükrözik az aktuális tartalom terjedelmét

### Könyvtár szerkezet fejlesztések
- **Elnevezési szabványosítás**: Az "mcp transport" átnevezése "mcp-transport"-ra, hogy összhangban legyen más haladó témák mappáival
- **Tartalom szervezés**: Az összes 05-AdvancedTopics mappa most már egységes elnevezési mintát követ (mcp-[téma])

### Dokumentáció minőségi fejlesztések
- **MCP specifikáció igazítás**: Minden új tartalom hivatkozik az aktuális MCP Specifikációra (2025-06-18)
- **Többnyelvű példák**: Átfogó kódpéldák C#, TypeScript és Python nyelveken
- **Vállalati fókusz**: Gyártásra kész minták és Azure felhő integráció mindenhol
- **Vizuális dokumentáció**: Mermaid diagramok az architektúra és folyamatok vizualizálásához

## 2025. augusztus 18.

### Dokumentáció átfogó frissítése - MCP 2025-06-18 szabványok

#### MCP biztonsági legjobb gyakorlatok (02-Security/) - Teljes modernizáció
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Teljes újraírás az MCP Specifikáció 2025-06-18-hoz igazítva
  - **Kötelező követelmények**: Hozzáadva explicit KELL/NEM KELL követelmények az hivatalos specifikációból, egyértelmű vizuális jelölésekkel
  - **12 alapvető biztonsági gyakorlat**: Átszervezve 15 elemből álló listáról átfogó biztonsági területekre
    - Token biztonság és hitelesítés külső identitás szolgáltató integrációval
    - Munkamenet kezelés és szállítási biztonság kriptográfiai követelményekkel
    - AI-specifikus fenyegetésvédelem Microsoft Prompt Shields integrációval
    - Hozzáférés-vezérlés és jogosultságok minimális jogosultság elvével
    - Tartalom biztonság és monitorozás Azure Content Safety integrációval
    - Ellátási lánc biztonság átfogó komponens ellenőrzéssel
    - OAuth biztonság és zavart helyettesítő megelőzés PKCE megvalósítással
    - Incidens válasz és helyreállítás automatizált képességekkel
    - Megfelelőség és irányítás szabályozási igazítással
    - Haladó biztonsági vezérlők nulla bizalom architektúrával
    - Microsoft biztonsági ökoszisztéma integráció átfogó megoldásokkal
    - Folyamatos biztonsági fejlődés adaptív gyakorlatokkal
  - **Microsoft biztonsági megoldások**: Fejlesztett integrációs útmutató Prompt Shields, Azure Content Safety, Entra ID és GitHub Advanced Security számára
  - **Megvalósítási erőforrások**: Kategorizált átfogó erőforrás linkek hivatalos MCP dokumentációval, Microsoft biztonsági megoldásokkal, biztonsági szabványokkal és megvalósítási útmutatókkal

#### Haladó biztonsági vezérlők (02-Security/) - Vállalati megvalósítás
- **MCP-SECURITY-CONTROLS-2025.md**: Teljes átdolgozás vállalati szintű biztonsági keretrendszerrel
  - **9 átfogó biztonsági terület**: Bővítve alapvető vezérlőkből részletes vállalati keretrendszerre
    - Haladó hitelesítés és jogosultság Microsoft Entra ID integrációval
    - Token biztonság és anti-passthrough vezérlők átfogó validációval
    - Munkamenet biztonsági vezérlők eltérítés megelőzésével
    - AI-specifikus biztonsági vezérlők prompt injekció és eszköz mérgezés megelőzésével
    - Zavart helyettesítő támadás megelőzés OAuth proxy biztonsággal
    - Eszköz végrehajtási biztonság sandboxing és izolációval
    - Ellátási lánc biztonsági vezérlők függőség ellenőrzéssel
    - Monitorozás és észlelési vezérlők SIEM integrációval
    - Incidens válasz és helyreállítás automatizált képességekkel
  - **Megvalósítási példák**: Részletes YAML konfigurációs blokkok és kódpéldák hozzáadva
  - **Microsoft megoldások integrációja**: Átfogó lefedettség Azure biztonsági szolgáltatások, GitHub Advanced Security és vállalati identitás kezelés terén

#### Haladó témák biztonság (05-AdvancedTopics/mcp-security/) - Gyártásra kész megvalósítás
- **README.md**: Teljes újraírás vállalati biztonsági megvalósításhoz
  - **Aktuális specifikáció igazítás**: Frissítve az MCP Specifikáció 2025-06-18-hoz kötelező biztonsági követelményekkel
  - **Fejlesztett hitelesítés**: Microsoft Entra ID integráció átfogó .NET és Java Spring Security példákkal
  - **AI biztonsági integráció**: Microsoft Prompt Shields és Azure Content Safety megvalósítás részletes Python példákkal
  - **Haladó fenyegetés mérséklés**: Átfogó megvalósítási példák
    - Zavart helyettesítő támadás megelőzés PKCE és felhasználói beleegyezés validációval
    - Token passthrough megelőzés közönség validációval és biztonságos token kezeléssel
    - Munkamenet eltérítés megelőzés kriptográfiai kötés és viselkedés elemzés segítségével
  - **Vállalati biztonsági integráció**: Azure Application Insights monitorozás, fenyegetés észlelési csatornák és ellátási lánc biztonság
  - **Megvalósítási ellenőrzőlista**: Egyértelmű kötelező vs. ajánlott biztonsági vezérlők Microsoft biztonsági ökoszisztéma előnyeivel

### Dokumentáció minőségi és szabvány igazítás
- **Specifikáció hivatkozások**: Minden hivatkozás frissítve az aktuális MCP Specifikációra (2025-06-18)
- **Microsoft biztonsági ökoszisztéma**: Fejlesztett integrációs útmutató minden biztonsági dokumentációban
- **Gyakorlati megvalósítás**: Részletes kódpéldák hozzáadva .NET, Java és Python nyelveken vállalati mintákkal
- **Erőforrás szervezés**: Átfogó kategorizálás hivatalos dokumentációval, biztonsági szabványokkal és megvalósítási útmutatókkal
- **Vizuális jelölések**: Egyértelmű kötelező követelmények vs. ajánlott gyakorlatok megjelölése

#### Alapfogalmak (01-CoreConcepts/) - Teljes modernizáció
- **Protokoll verzió frissítés**: Frissítve az aktuális MCP Specifikációra (2025-06-18) dátum alapú verziózással (YYYY-MM-DD formátum)
- **Architektúra finomítás**: Fejlesztett leírások a Hostokról, Kliensekről és Szerverekről, amelyek tü
- A `<details>` címkék helyett hozzáférhetőbb, táblázat-alapú formátumot használtam
- Új "alternative_layouts" mappában alternatív elrendezési opciókat hoztam létre
- Hozzáadtam kártya-alapú, füles-stílusú és harmonika-stílusú navigációs példákat
- Frissítettem a repozitórium szerkezeti szekcióját, hogy tartalmazza az összes legújabb fájlt
- Fejlesztettem a "Hogyan használjuk ezt a tananyagot" szekciót egyértelmű ajánlásokkal
- Frissítettem az MCP specifikációs linkeket, hogy a helyes URL-ekre mutassanak
- Hozzáadtam a Kontextus Mérnökség szekciót (5.14) a tananyag szerkezetéhez

### Tanulási Útmutató Frissítések
- Teljesen átdolgoztam a tanulási útmutatót, hogy igazodjon a jelenlegi repozitórium szerkezetéhez
- Új szekciókat adtam hozzá az MCP kliensek és eszközök, valamint a népszerű MCP szerverek témájában
- Frissítettem a Vizualizált Tananyag Térképet, hogy pontosan tükrözze az összes témát
- Fejlesztettem a Haladó Témák leírásait, hogy lefedjék az összes specializált területet
- Frissítettem az Esettanulmányok szekciót, hogy valós példákat tartalmazzon
- Hozzáadtam ezt az átfogó változásnaplót

### Közösségi Hozzájárulások (06-CommunityContributions/)
- Részletes információkat adtam hozzá az MCP szerverekről képgeneráláshoz
- Átfogó szekciót hoztam létre Claude VSCode-ban való használatáról
- Hozzáadtam a Cline terminál kliens beállítási és használati útmutatóját
- Frissítettem az MCP kliens szekciót, hogy tartalmazza az összes népszerű kliens opciót
- Fejlesztettem a hozzájárulási példákat pontosabb kódmintákkal

### Haladó Témák (05-AdvancedTopics/)
- Minden specializált témamappát egységes elnevezéssel szerveztem
- Hozzáadtam kontextus mérnökségi anyagokat és példákat
- Hozzáadtam Foundry ügynök integrációs dokumentációt
- Fejlesztettem az Entra ID biztonsági integrációs dokumentációt

## 2025. június 11.

### Első Létrehozás
- Kiadtam az MCP Kezdőknek tananyag első verzióját
- Létrehoztam az összes 10 fő szekció alapstruktúráját
- Megvalósítottam a Vizualizált Tananyag Térképet a navigációhoz
- Hozzáadtam kezdeti mintaprojekteket több programozási nyelven

### Első Lépések (03-GettingStarted/)
- Létrehoztam első szerver implementációs példákat
- Hozzáadtam kliens fejlesztési útmutatót
- Tartalmaztam LLM kliens integrációs útmutatót
- Hozzáadtam VS Code integrációs dokumentációt
- Megvalósítottam Server-Sent Events (SSE) szerver példákat

### Alapfogalmak (01-CoreConcepts/)
- Részletes magyarázatot adtam a kliens-szerver architektúráról
- Dokumentáltam a protokoll kulcselemeit
- Dokumentáltam az üzenetküldési mintákat MCP-ben

## 2025. május 23.

### Repó Szerkezete
- Inicializáltam a repozitóriumot alapvető mappastruktúrával
- Létrehoztam README fájlokat minden fő szekcióhoz
- Beállítottam fordítási infrastruktúrát
- Hozzáadtam képes eszközöket és diagramokat

### Dokumentáció
- Létrehoztam az első README.md-t a tananyag áttekintésével
- Hozzáadtam CODE_OF_CONDUCT.md és SECURITY.md fájlokat
- Beállítottam SUPPORT.md-t segítségnyújtási útmutatóval
- Létrehoztam előzetes tanulási útmutató struktúrát

## 2025. április 15.

### Tervezés és Keretrendszer
- Kezdeti tervezés az MCP Kezdőknek tananyaghoz
- Meghatároztam a tanulási célokat és a célközönséget
- Körvonalaztam a tananyag 10 szekciós struktúráját
- Kifejlesztettem koncepcionális keretrendszert példákhoz és esettanulmányokhoz
- Létrehoztam kezdeti prototípus példákat kulcsfogalmakhoz

---

