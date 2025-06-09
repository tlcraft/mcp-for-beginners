<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:33:22+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hu"
}
-->
# Biztonsági legjobb gyakorlatok

A Model Context Protocol (MCP) alkalmazása új, erőteljes lehetőségeket kínál az AI-alapú alkalmazások számára, ugyanakkor egyedi biztonsági kihívásokat is hoz, amelyek túlmutatnak a hagyományos szoftverbiztonsági kockázatokon. A már ismert kérdések, mint a biztonságos kódolás, a legkisebb jogosultság elve és az ellátási lánc biztonsága mellett az MCP és az AI-munkaterhelések új fenyegetésekkel néznek szembe, például prompt injekcióval, eszközmérgezéssel és dinamikus eszköz módosítással. Ezek a kockázatok adatlopáshoz, adatvédelmi incidensekhez és nem kívánt rendszer viselkedéshez vezethetnek, ha nem kezelik őket megfelelően.

Ebben a leckében áttekintjük az MCP-vel kapcsolatos legfontosabb biztonsági kockázatokat – többek között az autentikációt, az autorizációt, a túlzott jogosultságokat, a közvetett prompt injekciót és az ellátási lánc sebezhetőségeit – valamint gyakorlati intézkedéseket és legjobb gyakorlatokat mutatunk be ezek enyhítésére. Megismerheted továbbá, hogyan használhatod a Microsoft megoldásait, mint a Prompt Shields, Azure Content Safety és GitHub Advanced Security, hogy megerősítsd MCP-implementációdat. Ezeknek az intézkedéseknek az alkalmazásával jelentősen csökkentheted egy biztonsági incidens bekövetkezésének esélyét, és biztosíthatod, hogy AI rendszereid megbízhatóak és stabilak maradjanak.

# Tanulási célok

A lecke végére képes leszel:

- Azonosítani és megmagyarázni a Model Context Protocol (MCP) által bevezetett egyedi biztonsági kockázatokat, beleértve a prompt injekciót, eszközmérgezést, túlzott jogosultságokat és az ellátási lánc sebezhetőségeit.
- Leírni és alkalmazni hatékony mérséklő intézkedéseket az MCP biztonsági kockázatai ellen, mint például a megbízható autentikáció, a legkisebb jogosultság elve, biztonságos tokenkezelés és az ellátási lánc ellenőrzése.
- Megérteni és kihasználni a Microsoft megoldásait, mint a Prompt Shields, Azure Content Safety és GitHub Advanced Security, az MCP és AI-munkaterhelések védelmére.
- Felismerni az eszköz metaadatainak validálásának fontosságát, a dinamikus változások monitorozását és a közvetett prompt injekciós támadások elleni védekezést.
- Integrálni a bevált biztonsági gyakorlatokat – például a biztonságos kódolást, a szerver megerősítését és a zero trust architektúrát – az MCP implementációba a biztonsági incidensek valószínűségének és hatásának csökkentése érdekében.

# MCP biztonsági intézkedések

Minden olyan rendszer, amely fontos erőforrásokhoz fér hozzá, implicit biztonsági kihívásokkal szembesül. Ezek a kihívások általában alapvető biztonsági intézkedések és elvek helyes alkalmazásával kezelhetők. Mivel az MCP még viszonylag új protokoll, a specifikáció gyorsan változik és fejlődik. Végül a benne foglalt biztonsági kontrollok kifinomultabbá válnak, lehetővé téve a jobb integrációt vállalati és bevált biztonsági architektúrákkal, valamint legjobb gyakorlatokkal.

A [Microsoft Digital Defense Report](https://aka.ms/mddr) kutatása szerint a jelentett biztonsági incidensek 98%-a megelőzhető lenne robusztus biztonsági higiénia alkalmazásával. A legjobb védelem bármilyen típusú incidens ellen a megfelelő alapbiztonsági higiénia, biztonságos kódolási gyakorlatok és az ellátási lánc biztonságának helyes kezelése – ezek a kipróbált és bevált módszerek a leghatékonyabbak a kockázatok csökkentésében.

Nézzük meg, milyen módokon kezdheted el kezelni a biztonsági kockázatokat MCP alkalmazásakor.

> **Megjegyzés:** Az alábbi információk a **2025. május 29.** állapotának felelnek meg. Az MCP protokoll folyamatosan fejlődik, és a jövőbeni implementációk új autentikációs mintákat és kontrollokat vezethetnek be. A legfrissebb frissítésekért és útmutatókért mindig tekintsd meg a [MCP Specification](https://spec.modelcontextprotocol.io/), a hivatalos [MCP GitHub repository](https://github.com/modelcontextprotocol) és a [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices) oldalakat.

### Problémafelvetés  
Az eredeti MCP specifikáció feltételezte, hogy a fejlesztők saját autentikációs szervert írnak. Ehhez szükség volt az OAuth és kapcsolódó biztonsági követelmények ismeretére. Az MCP szerverek OAuth 2.0 Authorization Server-ként működtek, kezelve a szükséges felhasználói hitelesítést közvetlenül, nem delegálva azt külső szolgáltatásnak, például a Microsoft Entra ID-nek. 2025. április 26-tól az MCP specifikáció frissítése lehetővé teszi, hogy az MCP szerverek a felhasználói hitelesítést külső szolgáltatásra delegálják.

### Kockázatok
- Az MCP szerver hibásan konfigurált autorizációs logikája érzékeny adatok kiszivárgásához és helytelen hozzáférési szabályok alkalmazásához vezethet.
- OAuth token lopás az MCP szerveren. Ha ellopják, a token segítségével azonosíthatják magukat az MCP szerverként, és hozzáférhetnek az adott tokenhez tartozó szolgáltatás erőforrásaihoz és adataihoz.

#### Token átengedés  
A token átengedés kifejezetten tilos az autorizációs specifikációban, mivel számos biztonsági kockázatot rejt magában, többek között:

#### Biztonsági kontrollok megkerülése  
Az MCP szerver vagy az alatta lévő API-k fontos biztonsági intézkedéseket valósíthatnak meg, mint például a lekérések korlátozása, érvényesítése vagy a forgalom monitorozása, amelyek a token célközönségén vagy más hitelesítő adatokon alapulnak. Ha az ügyfelek közvetlenül az alatta lévő API-kkal használják a tokeneket az MCP szerver helyes validálása nélkül, megkerülhetik ezeket az intézkedéseket.

#### Felelősség és auditálási problémák  
Az MCP szerver nem tudja azonosítani vagy megkülönböztetni az MCP klienseket, ha azok egy upstream által kibocsátott, az MCP szerver számára átlátszatlan hozzáférési tokennel hívják a szervert.  
Az alatta lévő erőforrás-szerver naplóiban olyan kérések jelenhetnek meg, amelyek más forrásból, eltérő identitással érkeznek, nem pedig az MCP szervertől, amely továbbítja a tokeneket.  
Ezek a tényezők megnehezítik az incidensek kivizsgálását, az ellenőrzéseket és az auditot.  
Ha az MCP szerver anélkül továbbít tokeneket, hogy validálná azok állításait (például szerepkörök, jogosultságok vagy célközönség) vagy egyéb metaadatait, egy rosszindulatú szereplő a lopott token birtokában a szervert proxyként használhatja adatlopásra.

#### Bizalmi határ problémák  
Az alatta lévő erőforrás-szerver specifikus entitásoknak ad bizalmat, amely magában foglalhat feltételezéseket a forrásról vagy az ügyfél viselkedési mintáiról. Ennek a bizalmi határnak a megsértése váratlan problémákhoz vezethet.  
Ha a token több szolgáltatás által is elfogadott validálás nélkül, egy támadó, aki egy szolgáltatást kompromittált, a tokennel hozzáférhet más kapcsolódó szolgáltatásokhoz is.

#### Jövőbeli kompatibilitási kockázat  
Még ha egy MCP szerver ma "tiszta proxyként" is működik, később szüksége lehet biztonsági kontrollok bevezetésére. A megfelelő token célközönség szerinti szétválasztás megkönnyíti a biztonsági modell további fejlesztését.

### Mérséklő intézkedések

**Az MCP szerverek NEM FOGADHATNAK EL olyan tokeneket, amelyeket nem kifejezetten az MCP szerver számára bocsátottak ki**

- **Felülvizsgálat és az autorizációs logika megerősítése:** Gondosan ellenőrizd az MCP szerver autorizációs implementációját, hogy csak a szándékolt felhasználók és kliensek férhessenek hozzá érzékeny erőforrásokhoz. Gyakorlati útmutatásért lásd: [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) és [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Biztonságos tokenkezelés érvényesítése:** Kövesd a [Microsoft legjobb gyakorlatait a tokenek validálására és élettartamára vonatkozóan](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), hogy megakadályozd a hozzáférési tokenek visszaélését, újrajátszását vagy ellopását.
- **Token tárolás védelme:** Mindig biztonságosan tárold a tokeneket, és használj titkosítást mind tároláskor, mind átvitelkor. Megvalósítási tippekért lásd: [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Túlzott jogosultságok MCP szerverek esetén

### Problémafelvetés  
Az MCP szerverek túlzott jogosultságokat kaphattak a hozzáférni kívánt szolgáltatáshoz vagy erőforráshoz. Például egy AI értékesítési alkalmazás részeként működő MCP szervernek csak az értékesítési adatokhoz kellene hozzáférnie, nem pedig az összes fájlhoz az adattárolóban. Visszautalva a legkisebb jogosultság elvére (az egyik legrégebbi biztonsági alapelvre), egyetlen erőforrásnak sem szabadna több jogosultsággal rendelkeznie, mint amennyi a feladat végrehajtásához szükséges. Az AI különösen kihívást jelent ezen a téren, mivel a rugalmasság érdekében nehéz pontosan meghatározni a szükséges jogosultságokat.

### Kockázatok  
- A túlzott jogosultságok lehetővé tehetik az adatlopást vagy módosítást olyan adatok esetén, amelyekhez az MCP szervernek nem kellett volna hozzáférnie. Ez adatvédelmi problémát is jelenthet, ha az adatok személyes azonosításra alkalmas információkat (PII) tartalmaznak.

### Mérséklő intézkedések  
- **Alkalmazd a legkisebb jogosultság elvét:** Csak a szükséges minimális jogosultságokat add meg az MCP szervernek a feladatai ellátásához. Rendszeresen vizsgáld felül és frissítsd ezeket a jogosultságokat, hogy ne haladják meg a szükséges mértéket. Részletes útmutatóért lásd: [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Használj szerepkör alapú hozzáférés-vezérlést (RBAC):** Rendelj az MCP szerverhez szűkített, specifikus erőforrásokra és műveletekre vonatkozó szerepköröket, elkerülve a széles vagy felesleges jogosultságokat.
- **Monitorozd és auditáld a jogosultságokat:** Folyamatosan figyeld a jogosultságok használatát és auditáld a hozzáférési naplókat, hogy időben felismerd és kezelhesd a túlzott vagy nem használt jogosultságokat.

# Közvetett prompt injekciós támadások

### Problémafelvetés

Rosszindulatú vagy kompromittált MCP szerverek jelentős kockázatot jelentenek az ügyféladatok kiszivárogtatása vagy nem kívánt műveletek engedélyezése révén. Ezek a kockázatok különösen relevánsak AI és MCP-alapú munkaterhelések esetén, ahol:

- **Prompt injekciós támadások:** A támadók rosszindulatú utasításokat ágyaznak be promptokba vagy külső tartalmakba, amelyek hatására az AI rendszer nem kívánt műveleteket hajt végre vagy érzékeny adatokat szivárogtat ki. Bővebben: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Eszközmérgezés:** A támadók manipulálják az eszközök metaadatait (például leírásokat vagy paramétereket), hogy befolyásolják az AI viselkedését, potenciálisan megkerülve a biztonsági kontrollokat vagy adatokat lopva. Részletek: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Kereszt-domain prompt injekció:** Rosszindulatú utasítások vannak beágyazva dokumentumokba, weboldalakba vagy e-mailekbe, amelyeket az AI feldolgoz, ami adatlopáshoz vagy manipulációhoz vezet.
- **Dinamikus eszköz módosítás (Rug Pulls):** Az eszközdefiníciók a felhasználói jóváhagyás után módosíthatók, új rosszindulatú viselkedést bevezetve a felhasználó tudta nélkül.

Ezek a sérülékenységek hangsúlyozzák a robusztus validáció, monitorozás és biztonsági kontrollok szükségességét az MCP szerverek és eszközök környezetbe történő integrálásakor. Mélyebb elemzésért lásd a fent hivatkozott forrásokat.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hu.png)

**Közvetett prompt injekció** (más néven kereszt-domain prompt injekció vagy XPIA) kritikus sebezhetőség a generatív AI rendszerekben, beleértve az MCP-t is. Ebben a támadásban a rosszindulatú utasításokat külső tartalmakba rejtik – például dokumentumokba, weboldalakba vagy e-mailekbe. Amikor az AI feldolgozza ezeket, az ágyazott utasításokat valós felhasználói parancsként értelmezheti, ami nem kívánt műveletekhez, például adatlopáshoz, káros tartalom generálásához vagy felhasználói interakciók manipulációjához vezethet. Részletes magyarázatért és valós példákért lásd: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Egy különösen veszélyes formája ennek a támadásnak az **Eszközmérgezés**. Ebben a támadásban a rosszindulatú szereplők az MCP eszközök metaadataiba (például eszközleírásokba vagy paraméterekbe) fecskendeznek be káros utasításokat. Mivel a nagy nyelvi modellek (LLM-ek) ezek alapján döntenek arról, mely eszközöket hívják meg, a kompromittált leírások megtéveszthetik a modellt, hogy jogosulatlan eszközhívásokat hajtson végre vagy megkerülje a biztonsági kontrollokat. Ezek a manipulációk gyakran láthatatlanok a végfelhasználók számára, de az AI rendszer értelmezi és végrehajtja őket. Ez a kockázat különösen erős a hosztolt MCP szerver környezetekben, ahol az eszközdefiníciók a fel
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Az út a Microsoftnál a szoftverellátási lánc biztonságához](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Biztonságos, legkisebb jogosultságú hozzáférés (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Legjobb gyakorlatok tokenek érvényesítésére és élettartamára](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Tokenek biztonságos tárolása és titkosítása (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management mint hitelesítési átjáró MCP-hez](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP biztonsági legjobb gyakorlatok](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Microsoft Entra ID használata MCP szerverek hitelesítéséhez](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Következő

Következő: [3. fejezet: Első lépések](/03-GettingStarted/README.md)

**Nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hivatalos forrásnak. Fontos információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy félreértelmezésekért.