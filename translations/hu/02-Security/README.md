<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1c767a35642f753127dc08545c25a290",
  "translation_date": "2025-08-18T19:25:28+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hu"
}
-->
# MCP Biztonság: Átfogó védelem AI rendszerek számára

[![MCP Biztonsági Legjobb Gyakorlatok](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.hu.png)](https://youtu.be/88No8pw706o)

_(Kattints a fenti képre a leckéhez tartozó videó megtekintéséhez)_

A biztonság alapvető az AI rendszerek tervezésében, ezért helyezzük ezt a második szekció középpontjába. Ez összhangban áll a Microsoft **Secure by Design** elvével, amely a [Secure Future Initiative](https://www.microsoft.com/security/blog/2025/04/17/microsofts-secure-by-design-journey-one-year-of-success/) része.

A Model Context Protocol (MCP) új, erőteljes képességeket hoz az AI-alapú alkalmazások számára, miközben egyedi biztonsági kihívásokat is felvet, amelyek túlmutatnak a hagyományos szoftveres kockázatokon. Az MCP rendszerek szembesülnek mind a már ismert biztonsági problémákkal (biztonságos kódolás, legkisebb jogosultság elve, ellátási lánc biztonsága), mind az új, AI-specifikus fenyegetésekkel, mint például a prompt injekció, eszközmérgezés, munkamenet-eltérítés, zavart helyettesítő támadások, token átadási sérülékenységek és dinamikus képességmódosítás.

Ez a lecke az MCP implementációk legkritikusabb biztonsági kockázatait tárgyalja—beleértve az autentikációt, az autorizációt, a túlzott jogosultságokat, a közvetett prompt injekciót, a munkamenet-biztonságot, a zavart helyettesítő problémákat, a tokenkezelést és az ellátási lánc sérülékenységeit. Megismerheted azokat a gyakorlati kontrollokat és legjobb gyakorlatokat, amelyekkel ezek a kockázatok csökkenthetők, miközben a Microsoft megoldásait, például a Prompt Shields-t, az Azure Content Safety-t és a GitHub Advanced Security-t használhatod MCP telepítésed megerősítésére.

## Tanulási célok

A lecke végére képes leszel:

- **MCP-specifikus fenyegetések azonosítása**: Felismerni az MCP rendszerek egyedi biztonsági kockázatait, beleértve a prompt injekciót, az eszközmérgezést, a túlzott jogosultságokat, a munkamenet-eltérítést, a zavart helyettesítő problémákat, a token átadási sérülékenységeket és az ellátási lánc kockázatait
- **Biztonsági kontrollok alkalmazása**: Hatékony enyhítések bevezetése, beleértve a robusztus autentikációt, a legkisebb jogosultság elvét, a biztonságos tokenkezelést, a munkamenet-biztonsági kontrollokat és az ellátási lánc ellenőrzését
- **Microsoft biztonsági megoldások használata**: A Microsoft Prompt Shields, Azure Content Safety és GitHub Advanced Security megértése és alkalmazása MCP munkaterhelések védelmére
- **Eszközbiztonság validálása**: Az eszközök metaadatainak validálásának, a dinamikus változások monitorozásának és a közvetett prompt injekciós támadások elleni védekezés fontosságának felismerése
- **Legjobb gyakorlatok integrálása**: A bevált biztonsági alapelvek (biztonságos kódolás, szerver megerősítése, zero trust) kombinálása MCP-specifikus kontrollokkal az átfogó védelem érdekében

# MCP Biztonsági Architektúra és Kontrollok

A modern MCP implementációk rétegezett biztonsági megközelítéseket igényelnek, amelyek mind a hagyományos szoftverbiztonságot, mind az AI-specifikus fenyegetéseket kezelik. Az MCP specifikáció gyors fejlődése folyamatosan javítja a biztonsági kontrollokat, lehetővé téve a jobb integrációt a vállalati biztonsági architektúrákkal és a bevált gyakorlatokkal.

A [Microsoft Digital Defense Report](https://aka.ms/mddr) kutatásai szerint **a jelentett biztonsági incidensek 98%-a megelőzhető lenne robusztus biztonsági higiénia alkalmazásával**. A leghatékonyabb védelmi stratégia az alapvető biztonsági gyakorlatok és az MCP-specifikus kontrollok kombinációja—a bevált alapbiztonsági intézkedések továbbra is a legnagyobb hatással vannak az általános biztonsági kockázatok csökkentésére.

## Jelenlegi biztonsági helyzet

> **Megjegyzés:** Ez az információ az MCP biztonsági szabványokat tükrözi **2025. augusztus 18-i** állapot szerint. Az MCP protokoll gyorsan fejlődik, és a jövőbeli implementációk új autentikációs mintákat és továbbfejlesztett kontrollokat vezethetnek be. Mindig hivatkozz az aktuális [MCP Specifikációra](https://spec.modelcontextprotocol.io/), [MCP GitHub tárházra](https://github.com/modelcontextprotocol) és [biztonsági legjobb gyakorlatok dokumentációjára](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) a legfrissebb útmutatásért.

### Az MCP autentikáció fejlődése

Az MCP specifikáció jelentős fejlődésen ment keresztül az autentikáció és autorizáció megközelítésében:

- **Eredeti megközelítés**: A korai specifikációk megkövetelték, hogy a fejlesztők egyedi autentikációs szervereket implementáljanak, az MCP szerverek pedig OAuth 2.0 Authorization Serverként működtek, közvetlenül kezelve a felhasználói autentikációt
- **Jelenlegi szabvány (2025-06-18)**: A frissített specifikáció lehetővé teszi, hogy az MCP szerverek külső identitásszolgáltatókra (például Microsoft Entra ID) delegálják az autentikációt, javítva a biztonsági helyzetet és csökkentve az implementációs komplexitást
- **Szállítási réteg biztonsága**: Továbbfejlesztett támogatás a biztonságos szállítási mechanizmusokhoz, megfelelő autentikációs mintákkal mind helyi (STDIO), mind távoli (Streamable HTTP) kapcsolatokhoz

## Autentikáció és autorizáció biztonsága

### Jelenlegi biztonsági kihívások

A modern MCP implementációk számos autentikációs és autorizációs kihívással szembesülnek:

### Kockázatok és fenyegetési vektorok

- **Hibásan konfigurált autorizációs logika**: Az MCP szerverek hibás autorizációs implementációja érzékeny adatok kiszivárgását és helytelen hozzáférés-ellenőrzést eredményezhet
- **OAuth token kompromittálása**: A helyi MCP szerver tokenek ellopása lehetővé teszi a támadók számára, hogy szervereket megszemélyesítsenek és hozzáférjenek downstream szolgáltatásokhoz
- **Token átadási sérülékenységek**: A helytelen tokenkezelés biztonsági kontrollok megkerülését és elszámoltathatósági hiányosságokat eredményez
- **Túlzott jogosultságok**: A túlzottan privilegizált MCP szerverek megsértik a legkisebb jogosultság elvét, és növelik a támadási felületet

#### Token átadás: Kritikus anti-minta

**A token átadás kifejezetten tiltott** az aktuális MCP autorizációs specifikációban a súlyos biztonsági következmények miatt:

##### Biztonsági kontrollok megkerülése
- Az MCP szerverek és downstream API-k kritikus biztonsági kontrollokat (sebességkorlátozás, kérésvalidálás, forgalomfigyelés) implementálnak, amelyek megfelelő tokenvalidáláson alapulnak
- A közvetlen kliens-API tokenhasználat megkerüli ezeket az alapvető védelmeket, aláásva a biztonsági architektúrát

##### Els...
- **Biztonságos munkamenet-generálás**: Használj kriptográfiailag biztonságos, nem determinisztikus munkamenet-azonosítókat, amelyeket biztonságos véletlenszám-generátorokkal hozol létre  
- **Felhasználóspecifikus kötés**: Kösd a munkamenet-azonosítókat felhasználóspecifikus információkhoz olyan formátumokkal, mint `<user_id>:<session_id>`, hogy megakadályozd a felhasználók közötti munkamenet-visszaéléseket  
- **Munkamenet-életciklus kezelése**: Valósíts meg megfelelő lejárati, forgatási és érvénytelenítési mechanizmusokat a sebezhetőségi ablakok minimalizálása érdekében  
- **Adatátvitel biztonsága**: Kötelező a HTTPS minden kommunikációhoz, hogy megakadályozd a munkamenet-azonosítók elfogását  

### Zavart helyettesítő probléma

A **zavart helyettesítő probléma** akkor fordul elő, amikor az MCP szerverek hitelesítési proxyként működnek az ügyfelek és harmadik fél szolgáltatások között, lehetőséget teremtve az engedélyezési megkerülésre statikus ügyfélazonosítók kihasználásával.

#### **Támadási mechanizmusok és kockázatok**

- **Süti-alapú beleegyezés megkerülése**: Korábbi felhasználói hitelesítés beleegyezési sütiket hoz létre, amelyeket támadók kihasználnak rosszindulatú engedélykérésekkel és manipulált átirányítási URI-kkal  
- **Engedélyezési kód lopás**: A meglévő beleegyezési sütik miatt az engedélyezési szerverek kihagyhatják a beleegyezési képernyőket, és a kódokat támadók által irányított végpontokra irányíthatják  
- **Jogosulatlan API-hozzáférés**: Ellopott engedélyezési kódok lehetővé teszik a tokencserét és a felhasználók megszemélyesítését kifejezett jóváhagyás nélkül  

#### **Megelőzési stratégiák**

**Kötelező ellenőrzések:**
- **Kifejezett beleegyezési követelmények**: Az MCP proxy szerverek, amelyek statikus ügyfélazonosítókat használnak, **KÖTELESEK** minden dinamikusan regisztrált ügyfélhez felhasználói beleegyezést kérni  
- **OAuth 2.1 biztonsági megvalósítás**: Kövesd az aktuális OAuth biztonsági legjobb gyakorlatokat, beleértve a PKCE-t (Proof Key for Code Exchange) minden engedélykéréshez  
- **Szigorú ügyfél-ellenőrzés**: Valósíts meg szigorú átirányítási URI és ügyfélazonosító validációt a visszaélések megelőzése érdekében  

### Token továbbítási sebezhetőségek  

A **token továbbítás** egy kifejezett anti-minta, ahol az MCP szerverek ügyféltokeneket fogadnak el megfelelő validáció nélkül, és továbbítják azokat downstream API-khoz, megsértve az MCP engedélyezési specifikációit.

#### **Biztonsági következmények**

- **Ellenőrzési megkerülés**: Az ügyfél és az API közötti közvetlen tokenhasználat megkerüli a kritikus sebességkorlátozási, validációs és monitorozási ellenőrzéseket  
- **Audit nyomvonal sérülése**: A felfelé irányuló tokenek lehetetlenné teszik az ügyfél azonosítását, megnehezítve az incidensvizsgálatot  
- **Proxy-alapú adatlopás**: Nem validált tokenek lehetővé teszik rosszindulatú szereplők számára, hogy szervereket használjanak proxyként jogosulatlan adat-hozzáféréshez  
- **Bizalmi határ megsértése**: A downstream szolgáltatások bizalmi feltételezései sérülhetnek, ha a tokenek eredete nem igazolható  
- **Többszolgáltatásos támadás kiterjesztése**: Kompromittált tokenek, amelyeket több szolgáltatás is elfogad, lehetővé teszik az oldalirányú mozgást  

#### **Kötelező biztonsági ellenőrzések**

**Nem tárgyalható követelmények:**
- **Token validáció**: Az MCP szerverek **NEM FOGADHATNAK EL** olyan tokeneket, amelyeket nem kifejezetten az MCP szerver számára bocsátottak ki  
- **Célközönség ellenőrzése**: Mindig ellenőrizd, hogy a token célközönség-állításai megfelelnek-e az MCP szerver azonosítójának  
- **Megfelelő token-életciklus**: Valósíts meg rövid élettartamú hozzáférési tokeneket biztonságos forgatási gyakorlatokkal  

## Ellátási lánc biztonsága AI rendszerekhez

Az ellátási lánc biztonsága túlmutat a hagyományos szoftverfüggőségeken, és magában foglalja az egész AI ökoszisztémát. A modern MCP implementációknak szigorúan ellenőrizniük és monitorozniuk kell az összes AI-hoz kapcsolódó komponenst, mivel mindegyik potenciális sebezhetőségeket vezethet be, amelyek veszélyeztethetik a rendszer integritását.

### Kiterjesztett AI ellátási lánc elemek

**Hagyományos szoftverfüggőségek:**
- Nyílt forráskódú könyvtárak és keretrendszerek  
- Konténerképek és alap rendszerek  
- Fejlesztői eszközök és build pipeline-ok  
- Infrastruktúra-komponensek és szolgáltatások  

**AI-specifikus ellátási lánc elemek:**
- **Alapmodellek**: Különböző szolgáltatóktól származó előre betanított modellek, amelyek származásának ellenőrzése szükséges  
- **Beágyazási szolgáltatások**: Külső vektorizációs és szemantikus keresési szolgáltatások  
- **Kontekstszervezők**: Adatforrások, tudásbázisok és dokumentumtárak  
- **Harmadik fél API-k**: Külső AI szolgáltatások, ML pipeline-ok és adatfeldolgozó végpontok  
- **Modell-artefaktumok**: Súlyok, konfigurációk és finomhangolt modellváltozatok  
- **Képzési adatforrások**: Adatkészletek, amelyeket a modellek képzéséhez és finomhangolásához használnak  

### Átfogó ellátási lánc biztonsági stratégia

#### **Komponens ellenőrzés és bizalom**
- **Származás ellenőrzése**: Ellenőrizd az összes AI komponens eredetét, licencelését és integritását az integráció előtt  
- **Biztonsági értékelés**: Végezz sebezhetőségi vizsgálatokat és biztonsági áttekintéseket a modellek, adatforrások és AI szolgáltatások esetében  
- **Hírnév elemzés**: Értékeld az AI szolgáltatók biztonsági előzményeit és gyakorlatait  
- **Megfelelőség ellenőrzése**: Győződj meg arról, hogy minden komponens megfelel a szervezeti biztonsági és szabályozási követelményeknek  

#### **Biztonságos telepítési pipeline-ok**  
- **Automatizált CI/CD biztonság**: Integráld a biztonsági vizsgálatokat az automatizált telepítési pipeline-okba  
- **Artefaktum integritás**: Valósíts meg kriptográfiai ellenőrzést minden telepített artefaktumra (kód, modellek, konfigurációk)  
- **Szakaszos telepítés**: Használj progresszív telepítési stratégiákat biztonsági validációval minden szakaszban  
- **Megbízható artefaktum-tárházak**: Csak ellenőrzött, biztonságos artefaktum-regiszterekből és tárházakból telepíts  

#### **Folyamatos monitorozás és válaszadás**
- **Függőségvizsgálat**: Folyamatos sebezhetőségi monitorozás minden szoftver- és AI-komponens-függőségre  
- **Modell monitorozás**: Folyamatos értékelés a modell viselkedéséről, teljesítményének eltéréséről és biztonsági anomáliákról  
- **Szolgáltatás egészségi állapotának követése**: Külső AI szolgáltatások monitorozása elérhetőség, biztonsági incidensek és szabályzatváltozások szempontjából  
- **Fenyegetés-intelligencia integráció**: AI és ML biztonsági kockázatokra vonatkozó fenyegetés-adatok beépítése  

#### **Hozzáférés-vezérlés és minimális jogosultság**
- **Komponens szintű engedélyek**: Korlátozd a modellekhez, adatokhoz és szolgáltatásokhoz való hozzáférést üzleti szükségletek alapján  
- **Szolgáltatásfiók-kezelés**: Valósíts meg dedikált szolgáltatásfiókokat minimális szükséges jogosultságokkal  
- **Hálózati szegmentáció**: Izoláld az AI komponenseket, és korlátozd a hálózati hozzáférést a szolgáltatások között  
- **API-átjáró ellenőrzések**: Használj központosított API-átjárókat a külső AI szolgáltatásokhoz való hozzáférés szabályozására és monitorozására  

#### **Incidenskezelés és helyreállítás**
- **Gyors válasz eljárások**: Létrehozott folyamatok a kompromittált AI komponensek javítására vagy cseréjére  
- **Hitelesítő adatok forgatása**: Automatizált rendszerek a titkok, API-kulcsok és szolgáltatás-hitelesítési adatok forgatására  
- **Visszagörgetési képességek**: Képesség gyorsan visszatérni az AI komponensek korábbi, ismert jó verzióira  
- **Ellátási lánc megsértésének helyreállítása**: Specifikus eljárások az upstream AI szolgáltatások kompromittálására való reagáláshoz  

### Microsoft biztonsági eszközök és integráció

**GitHub Advanced Security** átfogó ellátási lánc védelmet nyújt, beleértve:
- **Titokvizsgálat**: Automatizált hitelesítő adatok, API-kulcsok és tokenek észlelése a tárházakban  
- **Függőségvizsgálat**: Nyílt forráskódú függőségek és könyvtárak sebezhetőségi értékelése  
- **CodeQL elemzés**: Statikus kódelemzés biztonsági sebezhetőségek és kódolási problémák azonosítására  
- **Ellátási lánc betekintések**: Függőségek egészségi állapotának és biztonsági státuszának láthatósága  

**Azure DevOps és Azure Repos integráció:**
- Zökkenőmentes biztonsági vizsgálati integráció a Microsoft fejlesztési platformokon  
- Automatizált biztonsági ellenőrzések az Azure Pipelines-ban AI munkaterhelésekhez  
- Szabályzatok érvényesítése a biztonságos AI komponens telepítéshez  

**Microsoft belső gyakorlatok:**
A Microsoft kiterjedt ellátási lánc biztonsági gyakorlatokat alkalmaz minden termékénél. Tudj meg többet a bevált megközelítésekről a [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/) oldalon.
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

- **[MCP Biztonsági Legjobb Gyakorlatok 2025](./mcp-security-best-practices-2025.md)** - Teljes biztonsági legjobb gyakorlatok MCP megvalósításokhoz
- **[Azure Tartalomvédelem Megvalósítása](./azure-content-safety-implementation.md)** - Gyakorlati megvalósítási példák Azure Tartalomvédelem integrációhoz  
- **[MCP Biztonsági Kontrollok 2025](./mcp-security-controls-2025.md)** - Legújabb biztonsági kontrollok és technikák MCP telepítésekhez
- **[MCP Legjobb Gyakorlatok Gyors Referencia](./mcp-best-practices.md)** - Gyors referencia útmutató az alapvető MCP biztonsági gyakorlatokhoz

---

## Hogyan Tovább

Következő: [3. fejezet: Kezdő lépések](../03-GettingStarted/README.md)

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.