<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:22:27+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hu"
}
-->
# Biztonsági legjobb gyakorlatok

A Model Context Protocol (MCP) bevezetése új, erőteljes lehetőségeket kínál az AI-alapú alkalmazások számára, ugyanakkor egyedi biztonsági kihívásokat is hoz, amelyek túlmutatnak a hagyományos szoftverkockázatokon. A megszokott biztonsági elvek, mint a biztonságos kódolás, a legkisebb jogosultság elve és az ellátási lánc biztonsága mellett az MCP és az AI munkaterhelések új fenyegetésekkel néznek szembe, mint például a prompt injekció, eszközmérgezés és dinamikus eszköz módosítás. Ezek a kockázatok adatlopáshoz, adatvédelmi incidensekhez és nem kívánt rendszer viselkedéshez vezethetnek, ha nem kezelik őket megfelelően.

Ebben a leckében az MCP-hez kapcsolódó legfontosabb biztonsági kockázatokat vizsgáljuk meg – beleértve az autentikációt, az engedélyezést, a túlzott jogosultságokat, az indirekt prompt injekciót és az ellátási lánc sebezhetőségeit –, és gyakorlati megoldásokat, valamint legjobb gyakorlatokat mutatunk be ezek mérséklésére. Megismerheted továbbá, hogyan használhatod a Microsoft megoldásait, mint a Prompt Shields, Azure Content Safety és GitHub Advanced Security, hogy megerősítsd MCP megvalósításodat. Ezeknek az irányelveknek az alkalmazásával jelentősen csökkentheted egy biztonsági incidens esélyét, és biztosíthatod, hogy AI rendszereid megbízhatóak és ellenállóak maradjanak.

# Tanulási célok

A lecke végére képes leszel:

- Azonosítani és megmagyarázni a Model Context Protocol (MCP) által bevezetett egyedi biztonsági kockázatokat, beleértve a prompt injekciót, eszközmérgezést, túlzott jogosultságokat és ellátási lánc sebezhetőségeket.
- Ismertetni és alkalmazni hatékony mérséklő intézkedéseket az MCP biztonsági kockázataira, mint például a robusztus autentikáció, a legkisebb jogosultság elve, biztonságos token kezelés és az ellátási lánc ellenőrzése.
- Megérteni és kihasználni a Microsoft megoldásait, mint a Prompt Shields, Azure Content Safety és GitHub Advanced Security, hogy megvédd az MCP-t és az AI munkaterheléseket.
- Felismerni az eszköz metaadatainak érvényesítésének fontosságát, a dinamikus változások figyelését és az indirekt prompt injekció elleni védelmet.
- Integrálni a bevált biztonsági gyakorlatokat – például biztonságos kódolást, szerver megerősítést és zero trust architektúrát – az MCP megvalósításába, hogy csökkentsd a biztonsági incidensek valószínűségét és hatását.

# MCP biztonsági intézkedések

Bármely rendszer, amely hozzáfér fontos erőforrásokhoz, implicit biztonsági kihívásokkal szembesül. Ezek a kihívások általában alapvető biztonsági intézkedések és koncepciók helyes alkalmazásával kezelhetők. Mivel az MCP csak nemrég lett definiálva, a specifikáció gyorsan változik, és a protokoll fejlődésével a benne lévő biztonsági intézkedések is érnek majd, lehetővé téve jobb integrációt a vállalati és bevált biztonsági architektúrákkal és gyakorlatokkal.

A [Microsoft Digital Defense Report](https://aka.ms/mddr) kutatása szerint a jelentett incidensek 98%-a megelőzhető lenne megfelelő biztonsági higiéniával, és a legjobb védelem bármilyen biztonsági esemény ellen az alapvető biztonsági higiéniád, biztonságos kódolási gyakorlatok és az ellátási lánc biztonságának helyes kezelése – ezek a már bevált módszerek továbbra is a legnagyobb hatással vannak a biztonsági kockázatok csökkentésére.

Nézzük meg, milyen módokon kezdheted meg a biztonsági kockázatok kezelését MCP használata esetén.

# MCP szerver autentikáció (ha az MCP megvalósításod 2025. április 26. előtt készült)

> **Note:** Az alábbi információ 2025. április 26-ig érvényes. Az MCP protokoll folyamatosan fejlődik, és a jövőbeni megvalósítások új autentikációs mintákat és intézkedéseket vezethetnek be. A legfrissebb frissítésekért és útmutatásokért mindig tekintsd meg az [MCP Specification](https://spec.modelcontextprotocol.io/) oldalt és az [MCP GitHub repository](https://github.com/modelcontextprotocol) hivatalos tárolóját.

### Problémafelvetés  
Az eredeti MCP specifikáció feltételezte, hogy a fejlesztők saját autentikációs szervert írnak. Ehhez OAuth és kapcsolódó biztonsági korlátok ismerete volt szükséges. Az MCP szerverek OAuth 2.0 engedélyezési szerverként működtek, kezelve a szükséges felhasználói autentikációt közvetlenül, nem pedig külső szolgáltatásra, például Microsoft Entra ID-re delegálva azt. 2025. április 26-tól az MCP specifikáció frissítése lehetővé teszi, hogy az MCP szerverek a felhasználói autentikációt külső szolgáltatásra bízzák.

### Kockázatok
- Az MCP szerveren hibásan konfigurált engedélyezési logika érzékeny adatok kiszivárgásához és helytelen hozzáférési jogosultságok alkalmazásához vezethet.
- OAuth tokenek ellopása az MCP szerveren. Ha ellopják a tokent, azzal az MCP szerver megszemélyesíthető, és hozzáférhet az OAuth token által védett erőforrásokhoz és adatokhoz.

### Mérséklő intézkedések
- **Engedélyezési logika felülvizsgálata és megerősítése:** Gondosan auditáld az MCP szerver engedélyezési megvalósítását, hogy csak a szándékolt felhasználók és kliensek férhessenek hozzá érzékeny erőforrásokhoz. Gyakorlati útmutatásért lásd: [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) és [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Biztonságos token-kezelési gyakorlatok alkalmazása:** Kövesd a [Microsoft legjobb gyakorlatait token érvényesítésre és élettartamra](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), hogy megelőzd a tokenek visszaélését, újrajátszását vagy ellopását.
- **Token tárolás védelme:** Mindig biztonságosan tárold a tokeneket, és használj titkosítást mind tárolás, mind átvitel közben. Megvalósítási tippekért lásd: [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Túlzott jogosultságok MCP szerverek számára

### Problémafelvetés  
Előfordulhat, hogy az MCP szerverek túlzott jogosultságokat kaptak az általuk elért szolgáltatásokhoz/erőforrásokhoz. Például egy AI értékesítési alkalmazás részeként működő MCP szervernek csak az értékesítési adatokhoz kell hozzáférnie egy vállalati adattárban, nem pedig az adattár összes fájljához. Visszautalva a legkisebb jogosultság elvére (az egyik legrégebbi biztonsági alapelv), egyetlen erőforrásnak sem szabad olyan jogosultságokat kapnia, amelyek meghaladják az adott feladat végrehajtásához szükségeseket. Az AI ebben a térben különösen kihívást jelent, mert a rugalmasság érdekében nehéz pontosan meghatározni a szükséges jogosultságokat.

### Kockázatok  
- A túlzott jogosultságok lehetővé tehetik az adatlopást vagy módosítást olyan adatok esetében, amelyekhez az MCP szervernek nem szabadna hozzáférnie. Ez adatvédelmi problémát is okozhat, ha a kezelt adatok személyes azonosításra alkalmas információk (PII).

### Mérséklő intézkedések
- **Alkalmazd a legkisebb jogosultság elvét:** Csak a minimálisan szükséges jogosultságokat add meg az MCP szervernek a feladatai elvégzéséhez. Rendszeresen vizsgáld felül és frissítsd ezeket a jogosultságokat, hogy ne haladják meg a szükséges mértéket. Részletes útmutató: [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Használj szerepalapú hozzáférés-vezérlést (RBAC):** Rendelj az MCP szerverhez olyan szerepeket, amelyek szigorúan meghatározott erőforrásokra és műveletekre vonatkoznak, elkerülve a széles vagy felesleges jogosultságokat.
- **Figyeld és auditáld a jogosultságokat:** Folyamatosan kövesd nyomon a jogosultságok használatát, és auditáld a hozzáférési naplókat, hogy időben észleld és javítsd a túlzott vagy nem használt jogosultságokat.

# Indirekt prompt injekciós támadások

### Problémafelvetés

Kártékony vagy kompromittált MCP szerverek jelentős kockázatot jelentenek az ügyféladatok kiszivárogtatására vagy nem kívánt műveletek végrehajtására. Ezek a kockázatok különösen relevánsak AI és MCP alapú munkaterheléseknél, ahol:

- **Prompt injekciós támadások:** A támadók rosszindulatú utasításokat ágyaznak be promptokba vagy külső tartalmakba, amelyek hatására az AI rendszer nem kívánt műveleteket hajt végre vagy érzékeny adatokat szivárogtat ki. További információ: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Eszközmérgezés:** A támadók manipulálják az eszközök metaadatait (például leírásokat vagy paramétereket), hogy befolyásolják az AI viselkedését, esetleg megkerüljék a biztonsági intézkedéseket vagy adatokat lopjanak ki. Részletek: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Kereszt-domain prompt injekció:** Rosszindulatú utasítások dokumentumokba, weboldalakba vagy emailekbe vannak ágyazva, amelyeket az AI feldolgoz, adatvesztéshez vagy manipulációhoz vezetve.
- **Dinamikus eszköz módosítás (Rug Pulls):** Az eszközdefiníciók felhasználói jóváhagyás után módosíthatók, így új rosszindulatú viselkedések léphetnek fel a felhasználó tudta nélkül.

Ezek a sebezhetőségek hangsúlyozzák a robusztus érvényesítés, monitorozás és biztonsági intézkedések szükségességét az MCP szerverek és eszközök környezetbe történő integrálásakor. Mélyebb betekintésért lásd a fenti hivatkozásokat.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hu.png)

**Indirekt prompt injekció** (más néven kereszt-domain prompt injekció vagy XPIA) kritikus sebezhetőség a generatív AI rendszerekben, beleértve a Model Context Protocol (MCP) használatát is. Ebben a támadásban rosszindulatú utasítások rejtve vannak külső tartalmakban – például dokumentumokban, weboldalakon vagy emailekben. Amikor az AI rendszer feldolgozza ezeket, az ágyazott utasításokat jogos felhasználói parancsként értelmezheti, ami nem kívánt műveletekhez vezethet, például adatvesztéshez, káros tartalom generálásához vagy a felhasználói interakciók manipulálásához. Részletes magyarázatért és valós példákért lásd: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Különösen veszélyes formája ennek a támadásnak az **Eszközmérgezés**. Ebben a támadásban a rosszindulatú szereplők az MCP eszközök metaadataiba (például eszközleírásokba vagy paraméterekbe) fecskendeznek be káros utasításokat. Mivel a nagy nyelvi modellek (LLM-ek) ezek alapján döntenek arról, hogy mely eszközöket hívják meg, a manipulált leírások megtéveszthetik a modellt, hogy jogosulatlan eszközhívásokat hajtson végre vagy megkerülje a biztonsági ellenőrzéseket. Ezek a manipulációk gyakran láthatatlanok a végfelhasználók számára, de az AI rendszer értelmezheti és végrehajthatja azokat. A kockázat különösen nagy a hosztolt MCP szerver környezetekben, ahol az eszközdefiníciók a felhasználói jóváhagyás után módosíthatók – ezt néha "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)" néven említik. Ilyen esetekben egy korábban biztonságos eszköz később rosszindulatú tevékenységeket végezhet, például adatokat lop vagy megváltoztatja a rendszer viselkedését a felhasználó tudta nélkül. Erről a támadási vektorról bővebben: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.hu.png)

## Kockázatok
A nem kívánt AI műveletek számos biztonsági kockázatot rejtenek, beleértve az adatlopást és adatvédelmi incidenseket.

### Mérséklő intézkedések
### Prompt Shields használata az indirekt prompt injekciós támadások ellen
-----------------------------------------------------------------------------

**AI Prompt Shields** a Microsoft által fejlesztett megoldás, amely védi a rendszereket mind közvetlen, mind indirekt prompt injekciós támadásokkal szemben. Ezek az alábbi módokon segítenek:

1.  **Észlelés és szűrés:** A Prompt Shields fejlett gépi tanulási algoritmusokat és természetes nyelvfeldolgozást alkalmaznak a rosszindulatú utasítások észlelésére és kiszűrésére, amelyek külső tartalmakban – például dokumentumokban, weboldalakon vagy emailekben – vannak elrejtve.
    
2.  **Spotlighting:** Ez a technika segíti az AI rendszert abban, hogy megkülönböztesse az érvényes rendszerutasításokat a potenciálisan megbízhatatlan külső bemenetektől. Az input szöveg olyan átalakításával, amely relevánsabbá teszi azt a modell számára, a Spotlighting biztosítja, hogy az AI jobban felismerje és figyelmen kívül hagyja a káros utasításokat.
    
3.  **Elválasztók és adatjelölés:** A rendszerüzenetben elhelyezett elválasztók egyértelműen jelölik az input szöveg helyét, segítve az AI rendszert abban, hogy megkülönböztesse a felhasználói bemeneteket a potenciálisan káros külső tartalomtól. Az adatjelölés ezt kiterjeszti speciális jelölők használatával, amelyek kiemelik a megbízható és nem megbízható adatok határait.
    
4.  **Folyamatos figyelés és frissítések:** A
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Az út a Microsoft szoftverellátási láncának biztonságossá tételéhez](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Biztonságos, minimális jogosultságú hozzáférés (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Legjobb gyakorlatok token érvényesítésére és élettartamára](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Biztonságos token tárolás és tokenek titkosítása (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management mint hitelesítési kapu MCP-hez](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID használata MCP szerverek hitelesítéséhez](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Következő

Következő: [3. fejezet: Első lépések](/03-GettingStarted/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy téves értelmezésekért.