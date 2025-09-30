<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T21:30:09+00:00",
  "source_file": "changelog.md",
  "language_code": "hu"
}
-->
# Változások naplója: MCP kezdőknek tananyag

Ez a dokumentum a Model Context Protocol (MCP) kezdőknek szóló tananyagában végrehajtott jelentős változások nyilvántartásaként szolgál. A változások fordított időrendben vannak dokumentálva (a legújabb változások elöl).

## 2025. szeptember 29.

### MCP szerver adatbázis-integrációs laborok - Átfogó gyakorlati tanulási útvonal

#### 11-MCPServerHandsOnLabs - Új, teljes adatbázis-integrációs tananyag
- **Teljes 13-laboros tanulási útvonal**: Átfogó gyakorlati tananyag hozzáadása, amely termelésre kész MCP szerverek építését tanítja PostgreSQL adatbázis-integrációval
  - **Valós példák**: Zava Retail analitikai esettanulmány, amely vállalati szintű mintákat mutat be
  - **Strukturált tanulási folyamat**:
    - **Laborok 00-03: Alapok** - Bevezetés, alapvető architektúra, biztonság és több-bérlős megoldások, környezet beállítása
    - **Laborok 04-06: MCP szerver építése** - Adatbázis-tervezés és séma, MCP szerver implementáció, eszközfejlesztés  
    - **Laborok 07-09: Haladó funkciók** - Szemantikus keresés integráció, tesztelés és hibakeresés, VS Code integráció
    - **Laborok 10-12: Termelés és legjobb gyakorlatok** - Telepítési stratégiák, monitorozás és megfigyelés, optimalizálás és legjobb gyakorlatok
  - **Vállalati technológiák**: FastMCP keretrendszer, PostgreSQL pgvectorral, Azure OpenAI beágyazások, Azure Container Apps, Application Insights
  - **Haladó funkciók**: Sor szintű biztonság (RLS), szemantikus keresés, több-bérlős adat-hozzáférés, vektor beágyazások, valós idejű monitorozás

#### Terminológia egységesítése - Modulok laborokká alakítása
- **Átfogó dokumentáció frissítés**: Az összes README fájl szisztematikus frissítése a 11-MCPServerHandsOnLabs-ban, hogy "Labor" terminológiát használjon "Modul" helyett
  - **Szakaszfejlécek**: Az "Mit tartalmaz ez a modul" frissítése "Mit tartalmaz ez a labor" formára mind a 13 laborban
  - **Tartalomleírás**: Az "Ez a modul bemutatja..." átalakítása "Ez a labor bemutatja..." formára a dokumentációban
  - **Tanulási célok**: Az "A modul végére..." frissítése "A labor végére..." formára
  - **Navigációs hivatkozások**: Az összes "Modul XX:" hivatkozás átalakítása "Labor XX:" formára a kereszthivatkozásokban és navigációban
  - **Teljesítési nyomon követés**: Az "A modul befejezése után..." frissítése "A labor befejezése után..." formára
  - **Technikai hivatkozások megőrzése**: A Python modul hivatkozások megőrzése a konfigurációs fájlokban (pl. `"module": "mcp_server.main"`)

#### Tanulási útmutató fejlesztése (study_guide.md)
- **Vizualizált tananyag térkép**: Új "11. Adatbázis-integrációs laborok" szakasz hozzáadása átfogó laborstruktúra vizualizációval
- **Repository struktúra**: Frissítés tízről tizenegy fő szakaszra, részletes 11-MCPServerHandsOnLabs leírással
- **Tanulási útvonal iránymutatás**: Navigációs utasítások bővítése a 00-11 szakaszok lefedésére
- **Technológiai lefedettség**: FastMCP, PostgreSQL, Azure szolgáltatások integrációjának részletei
- **Tanulási eredmények**: Termelésre kész szerverfejlesztés, adatbázis-integrációs minták és vállalati biztonság hangsúlyozása

#### Fő README struktúra fejlesztése
- **Labor-alapú terminológia**: A fő README.md frissítése a 11-MCPServerHandsOnLabs-ban, hogy következetesen "Labor" struktúrát használjon
- **Tanulási útvonal szervezése**: Egyértelmű haladás az alapfogalmaktól a haladó implementáción át a termelési telepítésig
- **Valós példákra fókuszálás**: Gyakorlati, kézzelfogható tanulás hangsúlyozása vállalati szintű mintákkal és technológiákkal

### Dokumentáció minőségi és konzisztencia fejlesztések
- **Gyakorlati tanulás hangsúlyozása**: Gyakorlati, labor-alapú megközelítés megerősítése a dokumentációban
- **Vállalati minták fókusza**: Termelésre kész implementációk és vállalati biztonsági szempontok kiemelése
- **Technológiai integráció**: Modern Azure szolgáltatások és AI integrációs minták átfogó lefedettsége
- **Tanulási folyamat**: Egyértelmű, strukturált út az alapfogalmaktól a termelési telepítésig

## 2025. szeptember 26.

### Esettanulmányok fejlesztése - GitHub MCP Registry integráció

#### Esettanulmányok (09-CaseStudy/) - Ökoszisztéma fejlesztési fókusz
- **README.md**: Jelentős bővítés átfogó GitHub MCP Registry esettanulmánnyal
  - **GitHub MCP Registry esettanulmány**: Új, átfogó esettanulmány a GitHub MCP Registry szeptemberi 2025-ös bevezetéséről
    - **Problémaelemzés**: Részletes vizsgálat a töredezett MCP szerver felfedezési és telepítési kihívásokról
    - **Megoldás architektúra**: GitHub központosított regiszter megközelítése egykattintásos VS Code telepítéssel
    - **Üzleti hatás**: Mérhető javulások a fejlesztői bevezetésben és termelékenységben
    - **Stratégiai érték**: Moduláris ügynök telepítés és eszközök közötti interoperabilitás hangsúlyozása
    - **Ökoszisztéma fejlesztés**: Alapvető platformként való pozícionálás az ügynöki integrációhoz
  - **Esettanulmány struktúra fejlesztése**: Mind a hét esettanulmány frissítése következetes formázással és átfogó leírásokkal
    - Azure AI Travel Agents: Több ügynökös koordináció hangsúlyozása
    - Azure DevOps integráció: Munkafolyamat automatizálás fókusza
    - Valós idejű dokumentáció visszakeresés: Python konzol kliens implementáció
    - Interaktív tanulási terv generátor: Chainlit beszélgető webalkalmazás
    - Szerkesztőben megjelenő dokumentáció: VS Code és GitHub Copilot integráció
    - Azure API Management: Vállalati API integrációs minták
    - GitHub MCP Registry: Ökoszisztéma fejlesztés és közösségi platform
  - **Átfogó következtetés**: Újraírt következtetés szakasz, amely kiemeli a hét esettanulmányt, amelyek az MCP implementáció különböző dimenzióit fedik le
    - Vállalati integráció, több ügynökös koordináció, fejlesztői termelékenység
    - Ökoszisztéma fejlesztés, oktatási alkalmazások kategorizálása
    - Fejlett betekintések az architektúra mintákba, implementációs stratégiákba és legjobb gyakorlatokba
    - Az MCP mint érett, termelésre kész protokoll hangsúlyozása

#### Tanulási útmutató frissítések (study_guide.md)
- **Vizualizált tananyag térkép**: Frissített gondolattérkép, amely tartalmazza a GitHub MCP Registry-t az esettanulmányok szakaszában
- **Esettanulmányok leírása**: Általános leírások helyett részletes bontás a hét átfogó esettanulmányról
- **Repository struktúra**: A 10. szakasz frissítése, hogy átfogó esettanulmány lefedettséget tükrözzön konkrét implementációs részletekkel
- **Változások naplója integráció**: 2025. szeptember 26-i bejegyzés hozzáadása, amely dokumentálja a GitHub MCP Registry hozzáadását és az esettanulmányok fejlesztéseit
- **Dátum frissítések**: A lábléc időbélyegének frissítése a legutóbbi revízióra (2025. szeptember 26.)

### Dokumentáció minőségi fejlesztések
- **Következetesség javítása**: Az esettanulmány formázásának és struktúrájának szabványosítása mind a hét példában
- **Átfogó lefedettség**: Az esettanulmányok mostantól vállalati, fejlesztői termelékenységi és ökoszisztéma fejlesztési forgatókönyveket fednek le
- **Stratégiai pozícionálás**: Az MCP mint alapvető platform hangsúlyozása az ügynöki rendszer telepítéséhez
- **Erőforrás integráció**: További erőforrások frissítése, beleértve a GitHub MCP Registry linket

## 2025. szeptember 15.

### Haladó témák bővítése - Egyedi szállítások és kontextus mérnökség

#### MCP egyedi szállítások (05-AdvancedTopics/mcp-transport/) - Új haladó implementációs útmutató
- **README.md**: Teljes implementációs útmutató egyedi MCP szállítási mechanizmusokhoz
  - **Azure Event Grid szállítás**: Átfogó szerver nélküli eseményvezérelt szállítási implementáció
    - C#, TypeScript és Python példák Azure Functions integrációval
    - Eseményvezérelt architektúra minták skálázható MCP megoldásokhoz
    - Webhook fogadók és push-alapú üzenetkezelés
  - **Azure Event Hubs szállítás**: Nagy áteresztőképességű streaming szállítási implementáció
    - Valós idejű streaming képességek alacsony késleltetésű forgatókönyvekhez
    - Particionálási stratégiák és ellenőrzési pontok kezelése
    - Üzenetcsomagolás és teljesítményoptimalizálás
  - **Vállalati integrációs minták**: Termelésre kész architektúra példák
    - Elosztott MCP feldolgozás több Azure Functions között
    - Hibrid szállítási architektúrák több szállítási típus kombinálásával
    - Üzenet tartósság, megbízhatóság és hibaelhárítási stratégiák
  - **Biztonság és monitorozás**: Azure Key Vault integráció és megfigyelési minták
    - Kezelt identitás hitelesítés és minimális jogosultság hozzáférés
    - Application Insights telemetria és teljesítmény monitorozás
    - Áramkör megszakítók és hibatűrési minták
  - **Tesztelési keretrendszerek**: Átfogó tesztelési stratégiák egyedi szállításokhoz
    - Egységtesztelés teszt duplikátumokkal és mock keretrendszerekkel
    - Integrációs tesztelés Azure Test Containers segítségével
    - Teljesítmény- és terhelés tesztelési szempontok

#### Kontextus mérnökség (05-AdvancedTopics/mcp-contextengineering/) - Feltörekvő AI diszciplína
- **README.md**: Átfogó feltárás a kontextus mérnökség mint feltörekvő terület
  - **Alapelvek**: Teljes kontextus megosztás, cselekvési döntés tudatosság és kontextus ablak kezelés
  - **MCP protokoll igazítás**: Hogyan kezeli az MCP tervezés a kontextus mérnökség kihívásait
    - Kontextus ablak korlátok és progresszív betöltési stratégiák
    - Relevancia meghatározás és dinamikus kontextus visszakeresés
    - Többmódú kontextus kezelés és biztonsági szempontok
  - **Implementációs megközelítések**: Egy szálas vs. több ügynökös architektúrák
    - Kontextus darabolás és prioritási technikák
    - Progresszív kontextus betöltés és tömörítési stratégiák
    - Rétegezett kontextus megközelítések és visszakeresési optimalizálás
  - **Mérési keretrendszer**: Feltörekvő metrikák a kontextus hatékonyságának értékelésére
    - Bemeneti hatékonyság, teljesítmény, minőség és felhasználói élmény szempontok
    - Kísérleti megközelítések a kontextus optimalizálására
    - Hibaanalízis és javítási módszertanok

#### Tananyag navigációs frissítések (README.md)
- **Fejlesztett modul struktúra**: A tananyag táblázat frissítése új haladó témák hozzáadásával
  - Kontextus mérnökség (5.14) és Egyedi szállítás (5.15) bejegyzések hozzáadása
  - Következetes formázás és navigációs hivatkozások az összes modulban
  - Leírások frissítése az aktuális tartalom terjedelmének tükrözésére

### Könyvtárstruktúra fejlesztések
- **Elnevezési szabványosítás**: Az "mcp transport" átnevezése "mcp-transport"-ra, hogy következetes legyen más haladó témájú mappákkal
- **Tartalom szervezése**: Az összes 05-AdvancedTopics mappa most következetes elnevezési mintát követ (mcp-[téma])

### Dokumentáció minőségi fejlesztések
- **MCP specifikáció igazítás**: Az összes új tartalom hivatkozik az aktuális MCP Specifikációra (2025-06-18)
- **Többnyelvű példák**: Átfogó kódpéldák C#, TypeScript és Python nyelven
- **Vállalati fókusz**: Termelésre kész minták és Azure felhő integráció az egész dokumentációban
- **Vizualizált dokumentáció**: Mermaid diagramok az architektúra és folyamatok vizualizálásához

## 2025. augusztus 18.

### Dokumentáció átfogó frissítése - MCP 2025-06-18 szabványok

#### MCP biztonsági legjobb gyakorlatok (02-Security/) - Teljes modernizáció
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Teljes újraírás az MCP Specifikáció 2025-06-18 igazításával
  - **Kötelező követelmények**: Explicit MUST/MUST NOT követelmények hozzáadása az hivatalos specifikációból, egyértelmű vizuális jelölésekkel
  - **12 alapvető biztonsági gyakorlat**: Átszervezés 15 elemből álló listáról átfogó biztonsági területekre
    - Token biztonság és hitelesítés külső identitás szolgáltató integrációval
    - Munkamenet kezelés és szállítási biztonság kriptográfiai követelményekkel
    - AI-specifikus fenyegetésvédelem Microsoft Prompt Shields integrációval
    - Hozzáférés-ellenőrzés és jogosultságok a minimális jogosultság elvével
    - Tartalom biztonság és monitorozás Azure Content Safety integrációval
    - Ellátási lánc biztonság átfogó komponens ellenőrzéssel
- **Vizuális Jelzések**: Kötelező követelmények és ajánlott gyakorlatok egyértelmű megjelölése

#### Alapfogalmak (01-CoreConcepts/) - Teljes Modernizáció
- **Protokoll Verzió Frissítése**: Frissítve a jelenlegi MCP Specifikáció 2025-06-18 hivatkozására, dátum-alapú verziózással (YYYY-MM-DD formátum)
- **Architektúra Finomítása**: A Hostok, Kliensek és Szerverek leírásának fejlesztése a jelenlegi MCP architektúra minták alapján
  - Hostok most egyértelműen AI alkalmazásokként definiálva, amelyek több MCP kliens kapcsolatot koordinálnak
  - Kliensek protokoll csatlakozóként leírva, amelyek egy-egy szerverrel tartanak fenn kapcsolatot
  - Szerverek helyi és távoli telepítési forgatókönyvekkel bővítve
- **Primitívek Átszervezése**: Szerver és kliens primitívek teljes átalakítása
  - Szerver Primitívek: Erőforrások (adatforrások), Promtok (sablonok), Eszközök (végrehajtható funkciók) részletes magyarázatokkal és példákkal
  - Kliens Primitívek: Mintavétel (LLM kimenetek), Kérdezés (felhasználói bemenet), Naplózás (hibakeresés/monitorozás)
  - Frissítve a jelenlegi felfedezési (`*/list`), lekérési (`*/get`) és végrehajtási (`*/call`) módszer mintákkal
- **Protokoll Architektúra**: Két rétegű architektúra modell bevezetése
  - Adat Réteg: JSON-RPC 2.0 alap, életciklus-kezeléssel és primitívekkel
  - Szállítási Réteg: STDIO (helyi) és Streamable HTTP SSE-vel (távoli) szállítási mechanizmusok
- **Biztonsági Keretrendszer**: Átfogó biztonsági elvek, beleértve a felhasználói beleegyezést, adatvédelem biztosítását, eszköz végrehajtási biztonságot és szállítási réteg biztonságot
- **Kommunikációs Minták**: Frissített protokoll üzenetek, amelyek bemutatják az inicializálási, felfedezési, végrehajtási és értesítési folyamatokat
- **Kód Példák**: Többnyelvű példák (.NET, Java, Python, JavaScript) frissítve a jelenlegi MCP SDK mintákra

#### Biztonság (02-Security/) - Átfogó Biztonsági Átalakítás  
- **Szabványokhoz Igazítás**: Teljes igazítás a MCP Specifikáció 2025-06-18 biztonsági követelményeihez
- **Hitelesítés Fejlődése**: Dokumentálva az egyedi OAuth szerverektől a külső identitás szolgáltató delegációig (Microsoft Entra ID)
- **AI-Specifikus Fenyegetés Elemzés**: Modern AI támadási vektorok kiterjesztett lefedettsége
  - Részletes prompt injekció támadási forgatókönyvek valós példákkal
  - Eszköz mérgezési mechanizmusok és "szőnyegkihúzás" támadási minták
  - Kontextus ablak mérgezés és modell zavar támadások
- **Microsoft AI Biztonsági Megoldások**: Microsoft biztonsági ökoszisztéma átfogó lefedettsége
  - AI Prompt Shields fejlett észlelési, kiemelési és határolási technikákkal
  - Azure Content Safety integrációs minták
  - GitHub Advanced Security az ellátási lánc védelmére
- **Fejlett Fenyegetés Enyhítés**: Részletes biztonsági kontrollok
  - Munkamenet eltérítés MCP-specifikus támadási forgatókönyvekkel és kriptográfiai munkamenet ID követelményekkel
  - Zavaros helyettes problémák MCP proxy forgatókönyvekben kifejezett beleegyezési követelményekkel
  - Token átengedési sebezhetőségek kötelező validációs kontrollokkal
- **Ellátási Lánc Biztonság**: Kiterjesztett AI ellátási lánc lefedettség, beleértve az alapmodelleket, beágyazási szolgáltatásokat, kontextus szolgáltatókat és harmadik fél API-kat
- **Alap Biztonság**: Fejlesztett integráció vállalati biztonsági mintákkal, beleértve a zero trust architektúrát és a Microsoft biztonsági ökoszisztémát
- **Erőforrás Szervezés**: Átfogó erőforrás linkek kategorizálása típus szerint (Hivatalos Dokumentációk, Szabványok, Kutatások, Microsoft Megoldások, Megvalósítási Útmutatók)

### Dokumentáció Minőségi Fejlesztések
- **Strukturált Tanulási Célok**: Fejlesztett tanulási célok konkrét, cselekvésre ösztönző eredményekkel
- **Kereszthivatkozások**: Linkek hozzáadása kapcsolódó biztonsági és alapfogalmi témák között
- **Aktuális Információk**: Minden dátum hivatkozás és specifikáció link frissítése a jelenlegi szabványokra
- **Megvalósítási Útmutatás**: Konkrét, cselekvésre ösztönző megvalósítási útmutatók hozzáadása mindkét szakaszban

## 2025. július 16.

### README és Navigációs Fejlesztések
- Teljesen újratervezett tananyag navigáció a README.md-ben
- `<details>` tagek helyett hozzáférhetőbb táblázat-alapú formátumot alkalmazva
- Alternatív elrendezési opciók létrehozása az új "alternative_layouts" mappában
- Kártya-alapú, füles-stílusú és harmonika-stílusú navigációs példák hozzáadása
- Frissített adattár szerkezeti szakasz, amely tartalmazza az összes legújabb fájlt
- Fejlesztett "Hogyan Használjuk Ezt a Tananyagot" szakasz egyértelmű ajánlásokkal
- Frissített MCP specifikációs linkek, amelyek a megfelelő URL-ekre mutatnak
- Kontextus Mérnöki szakasz (5.14) hozzáadása a tananyag szerkezetéhez

### Tanulási Útmutató Frissítések
- Teljesen átdolgozott tanulási útmutató, amely igazodik a jelenlegi adattár szerkezetéhez
- Új szakaszok hozzáadása MCP Kliensek és Eszközök, valamint Népszerű MCP Szerverek témában
- Frissített Vizuális Tananyag Térkép, amely pontosan tükrözi az összes témát
- Fejlesztett leírások a Haladó Témák szakaszban, amelyek lefedik az összes specializált területet
- Frissített Esettanulmányok szakasz, amely valós példákat tükröz
- Hozzáadva ezt az átfogó változásnaplót

### Közösségi Hozzájárulások (06-CommunityContributions/)
- Részletes információk hozzáadása MCP szerverekről képgeneráláshoz
- Átfogó szakasz hozzáadása Claude használatáról VSCode-ban
- Cline terminál kliens beállítási és használati útmutató hozzáadása
- Frissített MCP kliens szakasz, amely tartalmazza az összes népszerű kliens opciót
- Fejlesztett hozzájárulási példák pontosabb kódmintákkal

### Haladó Témák (05-AdvancedTopics/)
- Minden specializált téma mappa konzisztens elnevezéssel szervezve
- Kontextus mérnöki anyagok és példák hozzáadása
- Foundry ügynök integrációs dokumentáció hozzáadása
- Entra ID biztonsági integrációs dokumentáció fejlesztése

## 2025. június 11.

### Kezdeti Létrehozás
- Az MCP Kezdőknek tananyag első verziójának kiadása
- Alapvető szerkezet létrehozása mind a 10 fő szakaszhoz
- Vizuális Tananyag Térkép implementálása navigációhoz
- Kezdeti mintaprojektek hozzáadása több programozási nyelven

### Első Lépések (03-GettingStarted/)
- Első szerver implementációs példák létrehozása
- Kliens fejlesztési útmutatás hozzáadása
- LLM kliens integrációs utasítások hozzáadása
- VS Code integrációs dokumentáció hozzáadása
- Server-Sent Events (SSE) szerver példák implementálása

### Alapfogalmak (01-CoreConcepts/)
- Részletes magyarázat hozzáadása a kliens-szerver architektúráról
- Dokumentáció létrehozása a kulcsfontosságú protokoll komponensekről
- Üzenetküldési minták dokumentálása MCP-ben

## 2025. május 23.

### Adattár Szerkezete
- Az adattár inicializálása alapvető mappa szerkezettel
- README fájlok létrehozása minden fő szakaszhoz
- Fordítási infrastruktúra beállítása
- Kép eszközök és diagramok hozzáadása

### Dokumentáció
- Kezdeti README.md létrehozása tananyag áttekintéssel
- CODE_OF_CONDUCT.md és SECURITY.md hozzáadása
- SUPPORT.md beállítása segítségnyújtási útmutatással
- Előzetes tanulási útmutató szerkezet létrehozása

## 2025. április 15.

### Tervezés és Keretrendszer
- Az MCP Kezdőknek tananyag kezdeti tervezése
- Tanulási célok és célközönség meghatározása
- A tananyag 10 szakaszos szerkezetének körvonalazása
- Fogalmi keretrendszer kidolgozása példákhoz és esettanulmányokhoz
- Kulcsfontosságú fogalmak kezdeti prototípus példáinak létrehozása

---

**Felelősség kizárása**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével került lefordításra. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Fontos információk esetén javasolt professzionális emberi fordítást igénybe venni. Nem vállalunk felelősséget semmilyen félreértésért vagy téves értelmezésért, amely a fordítás használatából eredhet.