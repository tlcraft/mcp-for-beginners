<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T10:33:28+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hu"
}
-->
# Biztonsági legjobb gyakorlatok

A Model Context Protocol (MCP) alkalmazása új, erőteljes képességeket hoz az AI-alapú alkalmazások számára, ugyanakkor egyedi biztonsági kihívásokat is felvet, amelyek túlmutatnak a hagyományos szoftverkockázatokon. A már ismert problémák, mint a biztonságos kódolás, a legkisebb jogosultság elve és az ellátási lánc biztonsága mellett az MCP és az AI munkaterhelések új fenyegetésekkel néznek szembe, például prompt injekcióval, eszközmérgezéssel, dinamikus eszköz módosítással, munkamenet eltérítéssel, összezavart helyettes támadásokkal és token átengedési sebezhetőségekkel. Ezek a kockázatok adatlopáshoz, adatvédelmi incidensekhez és nem kívánt rendszer viselkedéshez vezethetnek, ha nem kezelik őket megfelelően.

Ez a lecke az MCP-hez kapcsolódó legfontosabb biztonsági kockázatokat vizsgálja meg — beleértve az autentikációt, jogosultságkezelést, túlzott jogosultságokat, közvetett prompt injekciót, munkamenet biztonságot, összezavart helyettes problémákat, token átengedési sebezhetőségeket és az ellátási lánc sebezhetőségeit —, és gyakorlati megoldásokat, valamint legjobb gyakorlatokat kínál ezek mérséklésére. Megismerheted továbbá, hogyan használhatod a Microsoft megoldásait, mint a Prompt Shields, Azure Content Safety és GitHub Advanced Security, hogy megerősítsd MCP megvalósításodat. Ezeknek az irányelveknek az alkalmazásával jelentősen csökkentheted a biztonsági incidensek esélyét, és biztosíthatod, hogy AI rendszereid megbízhatóak és stabilak maradjanak.

# Tanulási célok

A lecke végére képes leszel:

- Azonosítani és megmagyarázni a Model Context Protocol (MCP) által bevezetett egyedi biztonsági kockázatokat, mint például a prompt injekció, eszközmérgezés, túlzott jogosultságok, munkamenet eltérítés, összezavart helyettes problémák, token átengedési sebezhetőségek és ellátási lánc sebezhetőségek.
- Leírni és alkalmazni hatékony mérséklő intézkedéseket az MCP biztonsági kockázatai ellen, mint például a megbízható autentikáció, legkisebb jogosultság elve, biztonságos token kezelés, munkamenet biztonsági kontrollok és ellátási lánc ellenőrzés.
- Megérteni és kihasználni a Microsoft megoldásait, mint a Prompt Shields, Azure Content Safety és GitHub Advanced Security az MCP és AI munkaterhelések védelmére.
- Felismerni az eszköz metaadatainak érvényesítésének fontosságát, a dinamikus változások figyelését, a közvetett prompt injekció elleni védelmet és a munkamenet eltérítés megelőzését.
- Integrálni a bevált biztonsági gyakorlatokat — például biztonságos kódolás, szerver megerősítés és zero trust architektúra — az MCP megvalósításába a biztonsági incidensek valószínűségének és hatásának csökkentése érdekében.

# MCP biztonsági kontrollok

Bármely rendszer, amely fontos erőforrásokhoz fér hozzá, implicit biztonsági kihívásokkal szembesül. Ezek a kihívások általában alapvető biztonsági kontrollok és elvek helyes alkalmazásával kezelhetők. Mivel az MCP csak nemrég lett definiálva, a specifikáció gyorsan változik és fejlődik. Végül a benne lévő biztonsági kontrollok is kiforrnak, lehetővé téve a jobb integrációt a vállalati és bevált biztonsági architektúrákkal és legjobb gyakorlatokkal.

A [Microsoft Digital Defense Report](https://aka.ms/mddr) kutatása szerint a jelentett biztonsági incidensek 98%-a megelőzhető lenne megfelelő biztonsági higiéniával, és a legjobb védelem bármilyen incidens ellen az alapvető biztonsági higiénia, a biztonságos kódolás és az ellátási lánc biztonságának helyes alkalmazása — ezek a már ismert, bevált gyakorlatok a legnagyobb hatással vannak a kockázatok csökkentésére.

Nézzük meg, hogyan kezdhetsz neki az MCP biztonsági kockázatainak kezeléséhez.

> **[!NOTE]:** A következő információk **2025. május 29-ig** érvényesek. Az MCP protokoll folyamatosan fejlődik, és a jövőbeni implementációk új autentikációs mintákat és kontrollokat vezethetnek be. A legfrissebb információkért és útmutatókért mindig tekintsd meg az [MCP specifikációt](https://spec.modelcontextprotocol.io/), az hivatalos [MCP GitHub tárhelyet](https://github.com/modelcontextprotocol) és a [biztonsági legjobb gyakorlatok oldalát](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problémafelvetés  
Az eredeti MCP specifikáció feltételezte, hogy a fejlesztők saját autentikációs szervert írnak. Ehhez OAuth és kapcsolódó biztonsági követelmények ismerete volt szükséges. Az MCP szerverek OAuth 2.0 engedélyező szerverként működtek, közvetlenül kezelve a felhasználói autentikációt, nem pedig külső szolgáltatásra, például Microsoft Entra ID-re delegálva azt. 2025. április 26-tól az MCP specifikáció frissítése lehetővé teszi, hogy az MCP szerverek a felhasználói autentikációt külső szolgáltatásra delegálják.

### Kockázatok
- Az MCP szerver hibásan konfigurált jogosultságkezelése érzékeny adatok kiszivárgásához és helytelen hozzáférési szabályok alkalmazásához vezethet.
- OAuth token lopás az MCP helyi szerverén. Ha ellopják, a tokent felhasználhatják az MCP szerver megszemélyesítésére, és hozzáférhetnek az OAuth tokenhez tartozó szolgáltatás erőforrásaihoz és adataihoz.

#### Token átengedés
A token átengedés kifejezetten tilos az engedélyezési specifikációban, mivel számos biztonsági kockázatot hordoz, többek között:

#### Biztonsági kontrollok megkerülése
Az MCP szerver vagy az alárendelt API-k fontos biztonsági kontrollokat, például sebességkorlátozást, kérésellenőrzést vagy forgalomfigyelést valósíthatnak meg, amelyek a token célközönségétől vagy más hitelesítő feltételektől függenek. Ha az ügyfelek közvetlenül az alárendelt API-kkal használhatják a tokeneket anélkül, hogy az MCP szerver megfelelően validálná azokat vagy ellenőrizné, hogy a tokenek a megfelelő szolgáltatásra szólnak-e, akkor ezek a kontrollok megkerülhetők.

#### Felelősség és auditálási problémák
Az MCP szerver nem tudja azonosítani vagy megkülönböztetni az MCP klienset, ha az ügyfelek egy upstream által kibocsátott hozzáférési tokennel hívják meg, amely az MCP szerver számára átlátszatlan lehet.  
Az alárendelt erőforrás szerver naplói olyan kéréseket mutathatnak, amelyek más forrásból, más identitással érkeznek, nem pedig az MCP szervertől, amely valójában továbbítja a tokeneket.  
Mindkét tényező megnehezíti az incidensek kivizsgálását, a kontrollokat és az auditálást.  
Ha az MCP szerver tokeneket továbbít anélkül, hogy validálná azok állításait (például szerepkörök, jogosultságok vagy célközönség) vagy más metaadatokat, egy rosszindulatú szereplő, aki ellopott tokennel rendelkezik, a szervert proxyként használhatja adatlopásra.

#### Bizalmi határ problémák
Az alárendelt erőforrás szerver bizalmat ad bizonyos entitásoknak. Ez a bizalom magában foglalhat feltételezéseket az eredetről vagy az ügyfél viselkedési mintáiról. Ennek a bizalmi határnak a megsértése váratlan problémákhoz vezethet.  
Ha a token több szolgáltatás által is elfogadott anélkül, hogy megfelelően validálnák, egy támadó, aki egy szolgáltatást kompromittál, a tokent felhasználhatja más kapcsolódó szolgáltatások elérésére.

#### Jövőbeli kompatibilitási kockázat
Még ha egy MCP szerver ma „tiszta proxyként” is működik, később szükség lehet biztonsági kontrollok hozzáadására. A megfelelő token célközönség szerinti elkülönítés megkönnyíti a biztonsági modell fejlődését.

### Mérséklő intézkedések

**Az MCP szerverek NEM fogadhatnak el olyan tokeneket, amelyeket kifejezetten nem az MCP szerver számára bocsátottak ki**

- **Jogosultságkezelés átvizsgálása és megerősítése:** Alaposan auditáld az MCP szerver jogosultságkezelését, hogy csak a szándékolt felhasználók és kliensek férhessenek hozzá érzékeny erőforrásokhoz. Gyakorlati útmutatásért lásd az [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) és a [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/) cikkeket.
- **Biztonságos token gyakorlatok betartása:** Kövesd a [Microsoft legjobb gyakorlatait a token validáció és élettartam kezelésében](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), hogy megelőzd a tokenek visszajátszását vagy lopását.
- **Token tárolás védelme:** Mindig biztonságosan tárold a tokeneket, és használj titkosítást mind tárolás, mind átvitel közben. Megvalósítási tippekért lásd a [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) videót.

# Túlzott jogosultságok az MCP szerverek számára

### Problémafelvetés  
Az MCP szerverek túlzott jogosultságokat kaphattak az általuk elért szolgáltatásokhoz vagy erőforrásokhoz. Például egy AI értékesítési alkalmazás részeként működő MCP szervernek, amely egy vállalati adatbázishoz csatlakozik, csak az értékesítési adatokhoz kellene hozzáférnie, nem pedig az összes fájlhoz az adatbázisban. A legkisebb jogosultság elvére visszautalva (ami az egyik legrégebbi biztonsági elv), egyetlen erőforrásnak sem szabadna több jogosultsággal rendelkeznie, mint amennyi a feladat végrehajtásához szükséges. Az AI ezen a területen különösen kihívást jelent, mert a rugalmasság érdekében nehéz pontosan meghatározni a szükséges jogosultságokat.

### Kockázatok  
- A túlzott jogosultságok lehetővé tehetik az adatok kiszivárogtatását vagy módosítását, amelyekhez az MCP szervernek nem lenne szabad hozzáférnie. Ez adatvédelmi problémát is jelenthet, ha az adatok személyes azonosításra alkalmas információkat (PII) tartalmaznak.

### Mérséklő intézkedések  
- **Alkalmazd a legkisebb jogosultság elvét:** Csak a szükséges minimális jogosultságokat add meg az MCP szervernek a feladatai ellátásához. Rendszeresen vizsgáld felül és frissítsd ezeket a jogosultságokat, hogy ne haladják meg a szükséges mértéket. Részletes útmutatásért lásd a [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) oldalt.
- **Használj szerepkör alapú hozzáférés-vezérlést (RBAC):** Rendelj az MCP szerverhez olyan szerepköröket, amelyek szigorúan meghatározott erőforrásokra és műveletekre vonatkoznak, elkerülve a széles vagy felesleges jogosultságokat.
- **Figyeld és auditáld a jogosultságokat:** Folyamatosan kövesd nyomon a jogosultságok használatát, és auditáld a hozzáférési naplókat, hogy időben észleld és orvosold a túlzott vagy nem használt jogosultságokat.

# Közvetett prompt injekciós támadások

### Problémafelvetés

Rosszindulatú vagy kompromittált MCP szerverek jelentős kockázatot jelentenek az ügyféladatok kiszivárogtatására vagy nem kívánt műveletek végrehajtására. Ezek a kockázatok különösen relevánsak az AI és MCP alapú munkaterhelések esetén, ahol:

- **Prompt injekciós támadások:** A támadók rosszindulatú utasításokat ágyaznak be promptokba vagy külső tartalmakba, amelyek az AI rendszert nem kívánt műveletek végrehajtására vagy érzékeny adatok kiszivárogtatására késztetik. További információ: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Eszközmérgezés:** A támadók manipulálják az eszköz metaadatait (például leírásokat vagy paramétereket), hogy befolyásolják az AI viselkedését, esetleg megkerüljék a biztonsági kontrollokat vagy adatokat lopjanak. Részletek: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Kereszt-domain prompt injekció:** Rosszindulatú utasítások dokumentumokba, weboldalakba vagy e-mailekbe ágyazva kerülnek, amelyeket az AI feldolgoz, ami adatlopáshoz vagy manipulációhoz vezethet.
- **Dinamikus eszköz módosítás (Rug Pulls):** Az eszköz definíciók a felhasználói jóváhagyás után módosíthatók, új rosszindulatú viselkedést bevezetve anélkül, hogy a felhasználó tudna róla.

Ezek a sebezhetőségek hangsúlyozzák a robusztus érvényesítés, figyelés és biztonsági kontrollok szükségességét az MCP szerverek és eszközök integrálásakor. Mélyebb betekintésért lásd a fent hivatkozott forrásokat.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hu.png)

**Közvetett prompt injekció** (más néven kereszt-domain prompt injekció vagy XPIA) kritikus sebezhetőség a generatív AI rendszerekben, beleértve az MCP-t használó rendszereket is. Ebben a támadásban rosszindulatú utasítások rejtve vannak külső tartalmakban — például dokumentumokban, weboldalakon vagy e-mailekben. Amikor az AI feldolgozza ezeket a tartalmakat, a beágyazott utasításokat jogos felhasználói parancsként értelmezheti, ami nem kívánt műveletekhez vezethet, például adatlopáshoz, káros tartalom generálásához vagy a felhasználói interakciók manipulálásához. Részletes magyarázatért és valós példákért lásd a [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/) oldalt.

Különösen veszélyes formája ennek a támadásnak az **eszközmérgezés**. Itt a támadók rosszindulatú utasításokat fecskendeznek be az MCP eszközök metaadataiba (például eszközleírásokba vagy paraméterekbe). Mivel a nagy nyelvi modellek (LLM-ek) ezekre a
A confused deputy probléma egy biztonsági sérülékenység, amely akkor fordul elő, amikor egy MCP szerver proxyként működik az MCP kliensek és harmadik féltől származó API-k között. Ezt a sérülékenységet ki lehet használni, ha az MCP szerver statikus kliensazonosítót használ a harmadik fél engedélyező szerverével való hitelesítéshez, amely nem támogatja a dinamikus kliensregisztrációt.

### Kockázatok

- **Cookie-alapú hozzájárulás megkerülése**: Ha a felhasználó korábban már hitelesítette magát az MCP proxy szerveren keresztül, a harmadik fél engedélyező szervere beállíthat egy hozzájárulási sütit a felhasználó böngészőjében. Egy támadó ezt később kihasználhatja, ha a felhasználónak egy rosszindulatú linket küld, amely egy előre elkészített engedélyezési kérést tartalmaz egy rosszindulatú átirányítási URI-val.
- **Engedélyezési kód ellopása**: Amikor a felhasználó rákattint a rosszindulatú linkre, a harmadik fél engedélyező szervere a meglévő süti miatt kihagyhatja a hozzájárulási képernyőt, és az engedélyezési kódot a támadó szerverére irányíthatja.
- **Jogosulatlan API-hozzáférés**: A támadó a lopott engedélyezési kódot hozzáférési tokenekre válthatja, és a felhasználó nevében hozzáférhet a harmadik fél API-jához anélkül, hogy ehhez kifejezett jóváhagyás szükséges lenne.

### Mérséklő intézkedések

- **Kifejezett hozzájárulás követelménye**: Az MCP proxy szerverek, amelyek statikus kliensazonosítókat használnak, **KÖTELEZŐ** megszerezniük a felhasználó hozzájárulását minden dinamikusan regisztrált kliens esetén, mielőtt továbbítanák a kérést a harmadik fél engedélyező szervereihez.
- **Megfelelő OAuth megvalósítás**: Kövesse az OAuth 2.1 biztonsági legjobb gyakorlatait, beleértve a kód kihívások (PKCE) használatát az engedélyezési kérésekhez, hogy megakadályozza az elfogási támadásokat.
- **Kliens érvényesítés**: Vezessen be szigorú ellenőrzést az átirányítási URI-k és kliensazonosítók esetén, hogy megakadályozza a rosszindulatú szereplők általi kihasználást.


# Token átengedési sérülékenységek

### Probléma leírása

A "token átengedés" egy anti-minta, amikor egy MCP szerver elfogad tokeneket egy MCP klienstől anélkül, hogy ellenőrizné, hogy a tokeneket valóban az MCP szerver számára állították-e ki, majd ezeket továbbítja a downstream API-k felé. Ez a gyakorlat kifejezetten sérti az MCP engedélyezési specifikációját, és súlyos biztonsági kockázatokat jelent.

### Kockázatok

- **Biztonsági kontrollok megkerülése**: A kliensek megkerülhetik a fontos biztonsági kontrollokat, mint például a sebességkorlátozást, a kérés-ellenőrzést vagy a forgalomfigyelést, ha a tokeneket közvetlenül használhatják a downstream API-kkal anélkül, hogy megfelelően validálnák azokat.
- **Felelősség és auditálási problémák**: Az MCP szerver nem lesz képes azonosítani vagy megkülönböztetni az MCP klienseket, ha azok upstream által kiadott hozzáférési tokeneket használnak, ami megnehezíti az incidensek kivizsgálását és az auditálást.
- **Adatkiszivárogtatás**: Ha a tokeneket megfelelő jogosultság-ellenőrzés nélkül továbbítják, egy rosszindulatú szereplő ellopott tokennel a szervert proxyként használhatja adatkiszivárogtatásra.
- **Bizalmi határ megsértése**: A downstream erőforrás-szerverek bizonyos entitásoknak bizalmat adhatnak, feltételezve azok eredetét vagy viselkedési mintáit. Ennek a bizalmi határnak a megsértése váratlan biztonsági problémákhoz vezethet.
- **Több szolgáltatás közötti token visszaélés**: Ha a tokeneket több szolgáltatás is elfogadja megfelelő validáció nélkül, egy támadó, aki egy szolgáltatást kompromittál, a tokennel hozzáférhet más kapcsolódó szolgáltatásokhoz is.

### Mérséklő intézkedések

- **Token érvényesítés**: Az MCP szerverek **NEM FOGADHATNAK EL** olyan tokeneket, amelyeket nem kifejezetten az MCP szerver számára állítottak ki.
- **Célközönség ellenőrzése**: Mindig ellenőrizze, hogy a tokenek rendelkeznek-e a megfelelő audience (célközönség) mezővel, amely megegyezik az MCP szerver azonosítójával.
- **Megfelelő token életciklus-kezelés**: Alkalmazzon rövid élettartamú hozzáférési tokeneket és megfelelő token forgatási gyakorlatokat a tokenlopás és visszaélés kockázatának csökkentése érdekében.


# Munkamenet eltérítés

### Probléma leírása

A munkamenet eltérítés egy támadási mód, amikor a szerver egy munkamenet-azonosítót ad a kliensnek, és egy jogosulatlan fél megszerzi és használja ugyanazt az azonosítót, hogy a kliens nevében jogosulatlan műveleteket hajtson végre. Ez különösen aggasztó állapotfüggő HTTP szerverek esetén, amelyek MCP kéréseket kezelnek.

### Kockázatok

- **Munkamenet eltérítés prompt injekcióval**: Egy támadó, aki megszerzi a munkamenet-azonosítót, rosszindulatú eseményeket küldhet egy olyan szervernek, amely megosztja a munkamenet állapotát azzal a szerverrel, amelyhez a kliens csatlakozik, potenciálisan káros műveleteket indítva vagy érzékeny adatokhoz férve hozzá.
- **Munkamenet eltérítés személyesítés**: Egy támadó ellopott munkamenet-azonosítóval közvetlenül hívásokat kezdeményezhet az MCP szerver felé, megkerülve a hitelesítést, és a jogosult felhasználóként kezelve magát.
- **Megszakított folytatható adatfolyamok**: Ha a szerver támogatja az újraküldést vagy folytatható adatfolyamokat, egy támadó idő előtt megszakíthat egy kérést, amelyet később az eredeti kliens folytathat, potenciálisan rosszindulatú tartalommal.

### Mérséklő intézkedések

- **Engedélyezés ellenőrzése**: Az MCP szerverek, amelyek engedélyezést valósítanak meg, **KÖTELEZŐ** ellenőrizniük minden bejövő kérést, és **NEM SZABAD** munkameneteket használniuk hitelesítésre.
- **Biztonságos munkamenet-azonosítók**: Az MCP szerverek **KÖTELEZŐ** biztonságos, nem determinisztikus munkamenet-azonosítókat használniuk, amelyeket biztonságos véletlenszám-generátorral állítanak elő. Kerülje az előre jelezhető vagy sorozatos azonosítókat.
- **Felhasználóhoz kötött munkamenet**: Az MCP szerverek **AJÁNLOTT** a munkamenet-azonosítókat felhasználó-specifikus információkhoz kötni, például a munkamenet-azonosítót egy olyan formátumban kombinálni, mint `<user_id>:<session_id>`, ahol a `<user_id>` az engedélyezett felhasználó egyedi azonosítója.
- **Munkamenet lejárat**: Alkalmazzon megfelelő munkamenet lejáratot és forgatást, hogy korlátozza a sebezhetőségi időablakot, ha egy munkamenet-azonosító kompromittálódik.
- **Kommunikáció biztonsága**: Mindig használjon HTTPS-t az összes kommunikációhoz, hogy megakadályozza a munkamenet-azonosító elfogását.


# Ellátási lánc biztonság

Az ellátási lánc biztonsága továbbra is alapvető fontosságú az AI korszakában, de az ellátási lánc fogalma kibővült. A hagyományos kódcsomagokon túl most már szigorúan ellenőrizni és figyelni kell minden AI-hoz kapcsolódó komponenst, beleértve az alapmodelleket, beágyazási szolgáltatásokat, kontextus szolgáltatókat és harmadik féltől származó API-kat. Ezek mindegyike sebezhetőségeket vagy kockázatokat hordozhat, ha nem megfelelően kezelik.

**Kulcsfontosságú ellátási lánc biztonsági gyakorlatok AI és MCP esetén:**
- **Minden komponens ellenőrzése integráció előtt:** Ez nem csak a nyílt forráskódú könyvtárakra vonatkozik, hanem az AI modellekre, adatforrásokra és külső API-kra is. Mindig ellenőrizze a származást, licencelést és ismert sebezhetőségeket.
- **Biztonságos telepítési folyamatok fenntartása:** Használjon automatizált CI/CD folyamatokat integrált biztonsági vizsgálatokkal a problémák korai felismerésére. Biztosítsa, hogy csak megbízható artefaktumok kerüljenek éles környezetbe.
- **Folyamatos megfigyelés és auditálás:** Valósítson meg folyamatos megfigyelést minden függőségre, beleértve a modelleket és adat szolgáltatásokat, hogy észlelje az új sebezhetőségeket vagy ellátási lánc támadásokat.
- **Legkisebb jogosultság és hozzáférés-ellenőrzés alkalmazása:** Korlátozza a modellekhez, adatokhoz és szolgáltatásokhoz való hozzáférést csak a MCP szerver működéséhez szükséges mértékre.
- **Gyors reagálás a fenyegetésekre:** Legyen folyamat a kompromittált komponensek javítására vagy cseréjére, valamint a titkok vagy hitelesítő adatok forgatására, ha biztonsági incidens történik.

A [GitHub Advanced Security](https://github.com/security/advanced-security) olyan funkciókat kínál, mint a titokkeresés, függőségvizsgálat és CodeQL elemzés. Ezek az eszközök integrálódnak az [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) és az [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) szolgáltatásokkal, hogy segítsék a csapatokat a sebezhetőségek azonosításában és mérséklésében mind a kód, mind az AI ellátási lánc komponensek esetén.

A Microsoft belsőleg is kiterjedt ellátási lánc biztonsági gyakorlatokat alkalmaz minden termékére. További információkért lásd a [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/) cikket.


# Megalapozott biztonsági legjobb gyakorlatok, amelyek javítják az MCP megvalósítás biztonsági helyzetét

Bármely MCP megvalósítás örökli a szervezet környezetének meglévő biztonsági helyzetét, amelyre épül, ezért az MCP biztonságát az AI rendszerek részeként vizsgálva ajánlott a meglévő biztonsági helyzet javítása. Az alábbi, jól bevált biztonsági kontrollok különösen relevánsak:

- Biztonságos kódolási legjobb gyakorlatok az AI alkalmazásban – védelem az [OWASP Top 10](https://owasp.org/www-project-top-ten/) és az [OWASP Top 10 LLM-ekre](https://genai.owasp.org/download/43299/?tmstv=1731900559) ellen, titkok és tokenek biztonságos tárolása, végpontok közötti biztonságos kommunikáció megvalósítása az összes alkalmazáskomponens között stb.
- Szerver megerősítése – ahol lehetséges, használjon MFA-t, tartsa naprakészen a javításokat, integrálja a szervert harmadik fél identitásszolgáltatójával a hozzáféréshez stb.
- Eszközök, infrastruktúra és alkalmazások naprakészen tartása javításokkal
- Biztonsági megfigyelés – AI alkalmazás (beleértve az MCP kliens/szervereket) naplózásának és megfigyelésének megvalósítása, valamint ezeknek a naplóknak központi SIEM-be küldése az anomáliák észlelésére
- Zero trust architektúra – komponensek elkülönítése hálózati és identitásvezérlők segítségével logikus módon, hogy minimalizálja az oldalirányú mozgást egy esetleges AI alkalmazás kompromittálódása esetén.

# Főbb tanulságok

- A biztonsági alapok továbbra is kritikusak: Biztonságos kódolás, legkisebb jogosultság elve, ellátási lánc ellenőrzése és folyamatos megfigyelés elengedhetetlen az MCP és AI munkaterhelések esetén.
- Az MCP új kockázatokat hoz magával – mint például prompt injekció, eszközmérgezés, munkamenet eltérítés, confused deputy probléma, token átengedési sérülékenységek és túlzott jogosultságok –, amelyekhez mind hagyományos, mind AI-specifikus kontrollok szükségesek.
- Használjon erős hitelesítési, engedélyezési és tokenkezelési gyakorlatokat, lehetőség szerint külső identitásszolgáltatók, például a Microsoft Entra ID bevonásával.
- Védekezzen az indirekt prompt injekció és eszközmérgezés ellen az eszköz metaadatainak ellenőrzésével, dinamikus változások figyelésével és olyan megoldások alkalmazásával, mint a Microsoft Prompt Shields.
- Valósítson meg biztonságos munkamenet-kezelést nem determinisztikus munkamenet-azonosítókkal, munkamenetek felhasználói identitáshoz kötésével, és soha ne használjon munkameneteket hitelesítésre.
- Előzze meg a confused deputy támadásokat azzal, hogy minden dinamikusan regisztrált kliens esetén kifejezett felhasználói hozzájárulást kér, és megfelelő OAuth biztonsági gyakorlatokat alkalmaz.
- Kerülje a token átengedési sérülékenységeket azzal, hogy az MCP szerverek csak kifejezetten nekik kiadott tokeneket fogadnak el, és megfelelően validálják a token jogosultságokat.
- Az AI ellátási lánc minden komponensét – beleértve a modelleket, beágyazásokat és kontextus szolgáltatókat – ugyanolyan szigorral kezelje, mint a kód függőségeit.
- Tartsa naprakészen az MCP specifikációkat, és járuljon hozzá a közösséghez a biztonságos szabványok kialakítása érdekében.

# További források

## Külső források
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.