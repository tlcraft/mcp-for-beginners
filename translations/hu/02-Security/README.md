<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1c767a35642f753127dc08545c25a290",
  "translation_date": "2025-08-18T14:32:50+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hu"
}
-->
# MCP Biztonság: Átfogó védelem AI rendszerek számára

[![MCP Biztonsági Legjobb Gyakorlatok](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.hu.png)](https://youtu.be/88No8pw706o)

_(Kattints a fenti képre a leckéhez tartozó videó megtekintéséhez)_

A biztonság alapvető az AI rendszerek tervezésében, ezért helyezzük ezt a második szekció középpontjába. Ez összhangban áll a Microsoft **Secure by Design** elvével, amely a [Secure Future Initiative](https://www.microsoft.com/security/blog/2025/04/17/microsofts-secure-by-design-journey-one-year-of-success/) része.

A Model Context Protocol (MCP) új, erőteljes képességeket hoz az AI-alapú alkalmazások számára, miközben egyedi biztonsági kihívásokat is felvet, amelyek túlmutatnak a hagyományos szoftveres kockázatokon. Az MCP rendszerek szembesülnek mind a meglévő biztonsági problémákkal (biztonságos kódolás, legkisebb jogosultság elve, ellátási lánc biztonsága), mind az új, AI-specifikus fenyegetésekkel, mint például a prompt injekció, eszközmérgezés, munkamenet-eltérítés, összezavart helyettes támadások, token átadási sérülékenységek és dinamikus képességmódosítás.

Ez a lecke az MCP implementációk legkritikusabb biztonsági kockázatait tárgyalja—beleértve az autentikációt, az autorizációt, a túlzott jogosultságokat, a közvetett prompt injekciót, a munkamenet-biztonságot, az összezavart helyettes problémákat, a tokenkezelést és az ellátási lánc sérülékenységeit. Megismerheted azokat a gyakorlati kontrollokat és legjobb gyakorlatokat, amelyekkel ezek a kockázatok csökkenthetők, miközben a Microsoft megoldásait, például a Prompt Shields-t, az Azure Content Safety-t és a GitHub Advanced Security-t használhatod MCP telepítésed megerősítésére.

## Tanulási célok

A lecke végére képes leszel:

- **MCP-specifikus fenyegetések azonosítása**: Felismerni az MCP rendszerek egyedi biztonsági kockázatait, beleértve a prompt injekciót, az eszközmérgezést, a túlzott jogosultságokat, a munkamenet-eltérítést, az összezavart helyettes problémákat, a token átadási sérülékenységeket és az ellátási lánc kockázatait
- **Biztonsági kontrollok alkalmazása**: Hatékony intézkedések bevezetése, beleértve a robusztus autentikációt, a legkisebb jogosultság elvét, a biztonságos tokenkezelést, a munkamenet-biztonsági kontrollokat és az ellátási lánc ellenőrzését
- **Microsoft biztonsági megoldások használata**: A Microsoft Prompt Shields, Azure Content Safety és GitHub Advanced Security megértése és alkalmazása MCP munkaterhelések védelmére
- **Eszközbiztonság validálása**: Az eszközök metaadatainak validálásának, a dinamikus változások monitorozásának és a közvetett prompt injekciós támadások elleni védekezés fontosságának felismerése
- **Legjobb gyakorlatok integrálása**: A bevált biztonsági alapelvek (biztonságos kódolás, szerver megerősítése, zero trust) kombinálása MCP-specifikus kontrollokkal az átfogó védelem érdekében

# MCP Biztonsági Architektúra és Kontrollok

A modern MCP implementációk rétegezett biztonsági megközelítéseket igényelnek, amelyek mind a hagyományos szoftverbiztonságot, mind az AI-specifikus fenyegetéseket kezelik. Az MCP specifikáció gyors fejlődése folyamatosan javítja a biztonsági kontrollokat, lehetővé téve a jobb integrációt a vállalati biztonsági architektúrákkal és a bevált gyakorlatokkal.

A [Microsoft Digital Defense Report](https://aka.ms/mddr) kutatásai szerint **a jelentett biztonsági incidensek 98%-a megelőzhető lenne megfelelő biztonsági higiénia alkalmazásával**. A leghatékonyabb védelmi stratégia az alapvető biztonsági gyakorlatok és az MCP-specifikus kontrollok kombinációja—a bevált alapbiztonsági intézkedések továbbra is a legnagyobb hatással vannak az általános biztonsági kockázatok csökkentésére.

## Jelenlegi Biztonsági Környezet

> **Megjegyzés:** Ez az információ az MCP biztonsági szabványokat tükrözi **2025. augusztus 18-i** állapot szerint. Az MCP protokoll gyorsan fejlődik, és a jövőbeli implementációk új autentikációs mintákat és továbbfejlesztett kontrollokat vezethetnek be. Mindig hivatkozz az aktuális [MCP Specifikációra](https://spec.modelcontextprotocol.io/), az [MCP GitHub tárházra](https://github.com/modelcontextprotocol) és a [biztonsági legjobb gyakorlatok dokumentációjára](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) a legfrissebb útmutatásért.

### Az MCP Autentikáció Fejlődése

Az MCP specifikáció jelentős fejlődésen ment keresztül az autentikáció és autorizáció megközelítésében:

- **Eredeti megközelítés**: A korai specifikációk megkövetelték, hogy a fejlesztők egyedi autentikációs szervereket implementáljanak, az MCP szerverek pedig OAuth 2.0 Authorization Serverként működtek, közvetlenül kezelve a felhasználói autentikációt
- **Jelenlegi szabvány (2025-06-18)**: A frissített specifikáció lehetővé teszi, hogy az MCP szerverek külső identitásszolgáltatókra (például Microsoft Entra ID) delegálják az autentikációt, javítva a biztonsági helyzetet és csökkentve az implementációs komplexitást
- **Transport Layer Security**: Továbbfejlesztett támogatás a biztonságos szállítási mechanizmusokhoz, megfelelő autentikációs mintákkal mind helyi (STDIO), mind távoli (Streamable HTTP) kapcsolatokhoz

## Autentikáció és Autorizáció Biztonság

### Jelenlegi Biztonsági Kihívások

A modern MCP implementációk számos autentikációs és autorizációs kihívással szembesülnek:

### Kockázatok és Fenyegetési Vektorok

- **Hibásan konfigurált autorizációs logika**: Az MCP szerverek hibás autorizációs implementációja érzékeny adatok kiszivárgását és helytelen hozzáférés-ellenőrzést eredményezhet
- **OAuth token kompromittálása**: A helyi MCP szerver tokenek ellopása lehetővé teszi a támadók számára, hogy szervereket megszemélyesítsenek és hozzáférjenek downstream szolgáltatásokhoz
- **Token átadási sérülékenységek**: A helytelen tokenkezelés biztonsági kontrollok megkerülését és elszámoltathatósági hiányosságokat eredményez
- **Túlzott jogosultságok**: A túlzott jogosultságokkal rendelkező MCP szerverek megsértik a legkisebb jogosultság elvét, és növelik a támadási felületet

#### Token Átadás: Egy Kritikus Anti-Minta

**A token átadás kifejezetten tiltott** az aktuális MCP autorizációs specifikációban a súlyos biztonsági következmények miatt:

##### Biztonsági Kontroll Megkerülése
- Az MCP szerverek és a downstream API-k kritikus biztonsági kontrollokat (sebességkorlátozás, kérésvalidálás, forgalomfigyelés) implementálnak, amelyek megfelelő tokenvalidálástól függenek
- A közvetlen kliens-API tokenhasználat megkerüli ezeket az alapvető védelmeket, aláásva a biztonsági architektúrát

##### Elszámoltathatósági és Auditálási Kihívások  
- Az MCP szerverek nem tudják megkülönböztetni a klienseket, amelyek upstream által kiadott tokeneket használnak, megszakítva az audit nyomvonalakat
- A downstream erőforrás-szerver naplói félrevezető kérésforrásokat mutatnak, nem pedig az MCP szerver közvetítőit
- Az incidensvizsgálat és a megfelelőségi auditálás jelentősen nehezebbé válik

##### Adatkiáramlási Kockázatok
- Az érvénytelenített tokenállítások lehetővé teszik a rosszindulatú szereplők számára, hogy ellopott tokenekkel az MCP szervereket proxyként használják adatkiáramlásra
- A bizalmi határok megsértése lehetővé teszi a jogosulatlan hozzáférési mintákat, amelyek megkerülik a szándékolt biztonsági kontrollokat

##### Több Szolgáltatást Érintő Támadási Vektorok
- A több szolgáltatás által elfogadott kompromittált tokenek lehetővé teszik az oldalirányú mozgást a kapcsolódó rendszerek között
- A szolgáltatások közötti bizalmi feltételezések megsérülhetnek, amikor a token eredetét nem lehet ellenőrizni

### Biztonsági Kontrollok és Enyhítések

**Kritikus Biztonsági Követelmények:**

> **KÖTELEZŐ**: Az MCP szerverek **NEM FOGADHATNAK EL** olyan tokeneket, amelyeket nem kifejezetten az MCP szerver számára bocsátottak ki

#### Autentikáció és Autorizáció Kontrollok

- **Alapos Autorizációs Felülvizsgálat**: Végezzen átfogó auditokat az MCP szerver autorizációs logikáján, hogy biztosítsa, csak a szándékolt felhasználók és kliensek férhetnek hozzá érzékeny erőforrásokhoz
  - **Implementációs Útmutató**: [Azure API Management mint Autentikációs Átjáró MCP Szerverekhez](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
  - **Identitás Integráció**: [Microsoft Entra ID használata MCP Szerver Autentikációhoz](https://den.dev/blog/mcp-server-auth-entra-id-session/)

- **Biztonságos Tokenkezelés**: Implementálja a [Microsoft tokenvalidálási és életciklus legjobb gyakorlatait](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)
  - Ellenőrizze, hogy a token közönségállításai megfelelnek az MCP szerver identitásának
  - Implementáljon megfelelő tokenforgatási és lejárati szabályzatokat
  - Előzze meg a token újrajátszási támadásokat és jogosulatlan használatot

- **Védett Token Tárolás**: Biztosítsa a tokenek tárolását titkosítással mind nyugalmi állapotban, mind átvitel közben
  - **Legjobb Gyakorlatok**: [Biztonságos Token Tárolási és Titkosítási Útmutató](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

#### Hozzáférés-ellenőrzési Implementáció

- **Legkisebb Jogosultság Elve**: Csak a minimálisan szükséges jogosultságokat adja meg az MCP szervereknek a szándékolt funkciókhoz
  - Rendszeres jogosultság-felülvizsgálatok és frissítések a jogosultságok növekedésének megelőzésére
  - **Microsoft Dokumentáció**: [Biztonságos Legkisebb Jogosultságú Hozzáférés](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)

- **Szerepkör-alapú Hozzáférés-ellenőrzés (RBAC)**: Finomhangolt szerepkör-hozzárendelések implementálása
  - Szorosan korlátozza a szerepköröket specifikus erőforrásokra és műveletekre
  - Kerülje a széles vagy szükségtelen jogosultságokat, amelyek növelik a támadási felületet

- **Folyamatos Jogosultságfigyelés**: Implementáljon folyamatos hozzáférési auditálást és monitorozást
  - Figyelje a jogosultság-használati mintákat anomáliák után kutatva
  - Azonnal orvosolja a túlzott vagy nem használt jogosultságokat
- **Biztonságos munkamenet-generálás**: Használj kriptográfiailag biztonságos, nem-determinisztikus munkamenet-azonosítókat, amelyeket biztonságos véletlenszám-generátorokkal hozol létre.
- **Felhasználó-specifikus kötés**: Kösd a munkamenet-azonosítókat felhasználó-specifikus információkhoz olyan formátumokkal, mint `<user_id>:<session_id>`, hogy megakadályozd a munkamenetek keresztfelhasználói visszaéléseit.
- **Munkamenet-életciklus kezelése**: Valósíts meg megfelelő lejárati, rotációs és érvénytelenítési mechanizmusokat a sebezhetőségi ablakok korlátozása érdekében.
- **Átvitelbiztonság**: Kötelező HTTPS minden kommunikációhoz, hogy megakadályozd a munkamenet-azonosítók elfogását.

### Zavarodott helyettes probléma

A **zavarodott helyettes probléma** akkor fordul elő, amikor az MCP szerverek hitelesítési proxyként működnek az ügyfelek és harmadik fél szolgáltatások között, lehetőséget teremtve az engedélyezési megkerülésre statikus ügyfélazonosítók kihasználásával.

#### **Támadási mechanizmusok és kockázatok**

- **Sütialapú beleegyezés megkerülése**: Korábbi felhasználói hitelesítés beleegyezési sütiket hoz létre, amelyeket támadók kihasználhatnak rosszindulatú engedélyezési kérésekkel, manipulált átirányítási URI-k használatával.
- **Engedélyezési kód lopás**: A meglévő beleegyezési sütik miatt az engedélyezési szerverek kihagyhatják a beleegyezési képernyőket, és a kódokat támadó által irányított végpontokra irányíthatják.
- **Jogosulatlan API hozzáférés**: Ellopott engedélyezési kódok lehetővé teszik a tokencserét és a felhasználói megszemélyesítést explicit jóváhagyás nélkül.

#### **Megelőzési stratégiák**

**Kötelező kontrollok:**
- **Explicit beleegyezési követelmények**: Az MCP proxy szerverek, amelyek statikus ügyfélazonosítókat használnak, **KÖTELESEK** minden dinamikusan regisztrált ügyfél esetében felhasználói beleegyezést szerezni.
- **OAuth 2.1 biztonsági megvalósítás**: Kövesd az aktuális OAuth biztonsági legjobb gyakorlatokat, beleértve a PKCE-t (Proof Key for Code Exchange) minden engedélyezési kéréshez.
- **Szigorú ügyfél-ellenőrzés**: Valósíts meg alapos ellenőrzést az átirányítási URI-k és ügyfélazonosítók esetében, hogy megakadályozd a kihasználást.

### Token továbbítási sebezhetőségek  

A **token továbbítás** egy kifejezett anti-minta, ahol az MCP szerverek megfelelő validáció nélkül elfogadják az ügyfél tokeneket, és továbbítják azokat downstream API-khoz, megsértve az MCP engedélyezési specifikációit.

#### **Biztonsági következmények**

- **Kontroll megkerülése**: Az ügyfél és az API közvetlen tokenhasználata megkerüli a kritikus sebességkorlátozási, validációs és monitorozási kontrollokat.
- **Audit nyomvonal sérülése**: A felfelé irányuló tokenek lehetetlenné teszik az ügyfél azonosítását, megnehezítve az incidens vizsgálatát.
- **Proxy-alapú adatlopás**: Nem validált tokenek lehetővé teszik rosszindulatú szereplők számára, hogy szervereket használjanak proxyként jogosulatlan adat-hozzáféréshez.
- **Bizalmi határ megsértése**: A downstream szolgáltatások bizalmi feltételezései sérülhetnek, ha a tokenek eredete nem igazolható.
- **Több szolgáltatás elleni támadás kiterjesztése**: Kompromittált tokenek, amelyeket több szolgáltatás elfogad, lehetővé teszik az oldalirányú mozgást.

#### **Szükséges biztonsági kontrollok**

**Nem tárgyalható követelmények:**
- **Token validáció**: Az MCP szerverek **NEM FOGADHATNAK EL** olyan tokeneket, amelyeket nem kifejezetten az MCP szerver számára bocsátottak ki.
- **Célközönség ellenőrzése**: Mindig ellenőrizd, hogy a token célközönség állításai megfelelnek az MCP szerver identitásának.
- **Megfelelő token életciklus**: Valósíts meg rövid élettartamú hozzáférési tokeneket biztonságos rotációs gyakorlatokkal.

## Ellátási lánc biztonsága AI rendszerekhez

Az ellátási lánc biztonsága túllépett a hagyományos szoftverfüggőségeken, és magában foglalja az egész AI ökoszisztémát. A modern MCP megvalósításoknak szigorúan ellenőrizniük és monitorozniuk kell az összes AI-hoz kapcsolódó komponenst, mivel mindegyik potenciális sebezhetőségeket hozhat, amelyek veszélyeztethetik a rendszer integritását.

### Kibővített AI ellátási lánc elemek

**Hagyományos szoftverfüggőségek:**
- Nyílt forráskódú könyvtárak és keretrendszerek
- Konténerképek és alap rendszerek  
- Fejlesztői eszközök és build pipeline-ok
- Infrastruktúra komponensek és szolgáltatások

**AI-specifikus ellátási lánc elemek:**
- **Alapmodellek**: Különböző szolgáltatóktól származó előre betanított modellek, amelyek származásának ellenőrzése szükséges.
- **Beágyazási szolgáltatások**: Külső vektorizációs és szemantikai keresési szolgáltatások.
- **Kontekstszervezők**: Adatforrások, tudásbázisok és dokumentumtárak.  
- **Harmadik fél API-k**: Külső AI szolgáltatások, ML pipeline-ok és adatfeldolgozó végpontok.
- **Modell-artefaktumok**: Súlyok, konfigurációk és finomhangolt modellváltozatok.
- **Képzési adatforrások**: Adatkészletek, amelyeket a modellek képzéséhez és finomhangolásához használnak.

### Átfogó ellátási lánc biztonsági stratégia

#### **Komponens ellenőrzés és bizalom**
- **Származás ellenőrzése**: Ellenőrizd az összes AI komponens eredetét, licencelését és integritását integráció előtt.
- **Biztonsági értékelés**: Végezzen sebezhetőségi vizsgálatokat és biztonsági áttekintéseket modellek, adatforrások és AI szolgáltatások esetében.
- **Hírnév elemzés**: Értékeld az AI szolgáltatók biztonsági előéletét és gyakorlatát.
- **Megfelelőség ellenőrzése**: Biztosítsd, hogy minden komponens megfeleljen a szervezeti biztonsági és szabályozási követelményeknek.

#### **Biztonságos telepítési pipeline-ok**  
- **Automatizált CI/CD biztonság**: Integráld a biztonsági vizsgálatokat az automatizált telepítési pipeline-okba.
- **Artefaktum integritás**: Valósíts meg kriptográfiai ellenőrzést minden telepített artefaktumhoz (kód, modellek, konfigurációk).
- **Szakaszos telepítés**: Használj progresszív telepítési stratégiákat biztonsági validációval minden szakaszban.
- **Megbízható artefaktum-tárak**: Csak ellenőrzött, biztonságos artefaktum-regiszterekből és tárakból telepíts.

#### **Folyamatos monitorozás és válaszadás**
- **Függőség vizsgálat**: Folyamatos sebezhetőségi monitorozás minden szoftver és AI komponens függőség esetében.
- **Modell monitorozás**: Folyamatos értékelés a modell viselkedéséről, teljesítményének eltolódásáról és biztonsági anomáliákról.
- **Szolgáltatás egészségügyi követés**: Külső AI szolgáltatások monitorozása elérhetőség, biztonsági incidensek és szabályváltozások szempontjából.
- **Fenyegetés hírszerzés integráció**: AI és ML biztonsági kockázatokra specifikus fenyegetés hírcsatornák beépítése.

#### **Hozzáférés-ellenőrzés és minimális jogosultság**
- **Komponens szintű engedélyek**: Korlátozd a hozzáférést modellekhez, adatokhoz és szolgáltatásokhoz üzleti szükségletek alapján.
- **Szolgáltatásfiók-kezelés**: Valósíts meg dedikált szolgáltatásfiókokat minimális szükséges engedélyekkel.
- **Hálózati szegmentáció**: Izoláld az AI komponenseket, és korlátozd a hálózati hozzáférést a szolgáltatások között.
- **API Gateway kontrollok**: Használj központosított API gateway-eket a külső AI szolgáltatásokhoz való hozzáférés ellenőrzésére és monitorozására.

#### **Incidens válaszadás és helyreállítás**
- **Gyors válasz eljárások**: Létrehozott folyamatok a kompromittált AI komponensek javítására vagy cseréjére.
- **Hitelesítő adatok rotációja**: Automatizált rendszerek titkok, API kulcsok és szolgáltatás hitelesítő adatok rotációjára.
- **Visszaállítási képességek**: Képesség gyorsan visszatérni az AI komponensek korábbi, ismert jó verzióira.
- **Ellátási lánc megsértés helyreállítása**: Specifikus eljárások az upstream AI szolgáltatások kompromittálására való reagáláshoz.
### **Microsoft Biztonsági Megoldások**
- [Microsoft Prompt Shields Dokumentáció](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Tartalomvédelem Szolgáltatás](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Microsoft Entra ID Biztonság](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Azure Tokenkezelési Legjobb Gyakorlatok](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [GitHub Fejlett Biztonság](https://github.com/security/advanced-security)

### **Megvalósítási Útmutatók és Oktatóanyagok**
- [Azure API Management mint MCP Hitelesítési Átjáró](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID Hitelesítés MCP Szerverekkel](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Biztonságos Token Tárolás és Titkosítás (Videó)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### **DevOps és Ellátási Lánc Biztonság**
- [Azure DevOps Biztonság](https://azure.microsoft.com/products/devops)
- [Azure Repos Biztonság](https://azure.microsoft.com/products/devops/repos/)
- [Microsoft Ellátási Lánc Biztonsági Útja](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)

## **További Biztonsági Dokumentáció**

Átfogó biztonsági útmutatásért tekintse meg az alábbi speciális dokumentumokat ebben a szekcióban:

- **[MCP Biztonsági Legjobb Gyakorlatok 2025](./mcp-security-best-practices-2025.md)** - Teljes körű biztonsági legjobb gyakorlatok MCP megvalósításokhoz
- **[Azure Tartalomvédelem Megvalósítása](./azure-content-safety-implementation.md)** - Gyakorlati megvalósítási példák az Azure Tartalomvédelem integrációjához  
- **[MCP Biztonsági Kontrollok 2025](./mcp-security-controls-2025.md)** - Legújabb biztonsági kontrollok és technikák MCP telepítésekhez
- **[MCP Legjobb Gyakorlatok Gyors Referencia](./mcp-best-practices.md)** - Gyors referencia útmutató az alapvető MCP biztonsági gyakorlatokhoz

---

## Hogyan Tovább

Következő: [3. fejezet: Első lépések](../03-GettingStarted/README.md)

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.