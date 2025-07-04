<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T18:34:12+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hu"
}
-->
# Biztonsági legjobb gyakorlatok

A Model Context Protocol (MCP) alkalmazása új, erőteljes képességeket hoz az AI-alapú alkalmazások számára, ugyanakkor egyedi biztonsági kihívásokat is felvet, amelyek túlmutatnak a hagyományos szoftverbiztonsági kockázatokon. A már ismert problémák, mint a biztonságos kódolás, a legkisebb jogosultság elve és az ellátási lánc biztonsága mellett az MCP és az AI munkaterhelések új fenyegetésekkel néznek szembe, például prompt injekcióval, eszközmérgezéssel és dinamikus eszköz módosítással. Ezek a kockázatok adatlopáshoz, adatvédelmi incidensekhez és nem kívánt rendszer viselkedéshez vezethetnek, ha nem kezelik őket megfelelően.

Ez a lecke az MCP-hez kapcsolódó legfontosabb biztonsági kockázatokat vizsgálja meg – beleértve az autentikációt, az autorizációt, a túlzott jogosultságokat, az indirekt prompt injekciót és az ellátási lánc sebezhetőségeit –, valamint gyakorlati intézkedéseket és legjobb gyakorlatokat kínál ezek mérséklésére. Megismerheted továbbá, hogyan használhatod a Microsoft megoldásait, mint a Prompt Shields, az Azure Content Safety és a GitHub Advanced Security, hogy megerősítsd MCP megvalósításodat. Ezeknek az intézkedéseknek az alkalmazásával jelentősen csökkentheted a biztonsági incidensek esélyét, és biztosíthatod, hogy AI rendszereid megbízhatóak és stabilak maradjanak.

# Tanulási célok

A lecke végére képes leszel:

- Azonosítani és megmagyarázni a Model Context Protocol (MCP) által bevezetett egyedi biztonsági kockázatokat, mint például a prompt injekció, eszközmérgezés, túlzott jogosultságok és ellátási lánc sebezhetőségek.
- Leírni és alkalmazni hatékony mérséklő intézkedéseket az MCP biztonsági kockázatai ellen, mint a megbízható autentikáció, legkisebb jogosultság elve, biztonságos token kezelés és ellátási lánc ellenőrzés.
- Megérteni és kihasználni a Microsoft megoldásait, például a Prompt Shields, Azure Content Safety és GitHub Advanced Security, az MCP és AI munkaterhelések védelmére.
- Felismerni az eszköz metaadatainak érvényesítésének fontosságát, a dinamikus változások figyelését és az indirekt prompt injekció elleni védekezést.
- Integrálni a bevált biztonsági gyakorlatokat – mint a biztonságos kódolás, szerver megerősítés és zero trust architektúra – az MCP megvalósításába a biztonsági incidensek valószínűségének és hatásának csökkentése érdekében.

# MCP biztonsági intézkedések

Bármely rendszer, amely fontos erőforrásokhoz fér hozzá, implicit biztonsági kihívásokkal szembesül. Ezek a kihívások általában alapvető biztonsági intézkedések és elvek helyes alkalmazásával kezelhetők. Mivel az MCP csak nemrég lett definiálva, a specifikáció gyorsan változik és fejlődik. Végül a benne lévő biztonsági intézkedések is kiforrottabbá válnak, lehetővé téve a jobb integrációt vállalati és bevált biztonsági architektúrákkal és gyakorlatokkal.

A [Microsoft Digital Defense Report](https://aka.ms/mddr) kutatása szerint a jelentett biztonsági incidensek 98%-a megelőzhető lenne megfelelő biztonsági higiéniával, és a legjobb védelem bármilyen incidens ellen az alapvető biztonsági higiénia, a biztonságos kódolás és az ellátási lánc biztonságának helyes alkalmazása – ezek a jól bevált gyakorlatok továbbra is a legnagyobb hatással vannak a kockázatok csökkentésére.

Nézzük meg, hogyan kezdhetsz neki az MCP biztonsági kockázatainak kezeléséhez.

> **Megjegyzés:** A következő információk **2025. május 29.** állapotának megfelelőek. Az MCP protokoll folyamatosan fejlődik, és a jövőbeni implementációk új autentikációs mintákat és intézkedéseket hozhatnak. A legfrissebb információkért mindig tekintsd meg az [MCP specifikációt](https://spec.modelcontextprotocol.io/), az hivatalos [MCP GitHub tárhelyet](https://github.com/modelcontextprotocol) és a [biztonsági legjobb gyakorlatok oldalát](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problémafelvetés  
Az eredeti MCP specifikáció feltételezte, hogy a fejlesztők saját autentikációs szervert írnak. Ehhez OAuth és kapcsolódó biztonsági korlátok ismerete volt szükséges. Az MCP szerverek OAuth 2.0 engedélyező szerverként működtek, közvetlenül kezelve a felhasználói autentikációt, nem delegálva azt külső szolgáltatásnak, például a Microsoft Entra ID-nek. 2025. április 26-tól az MCP specifikáció frissítése lehetővé teszi, hogy az MCP szerverek a felhasználói autentikációt külső szolgáltatásra bízzák.

### Kockázatok
- Az MCP szerver hibásan konfigurált autorizációs logikája érzékeny adatok kiszivárgásához és helytelen hozzáférés-vezérléshez vezethet.
- OAuth token lopás a helyi MCP szerveren. Ha ellopják a tokent, azzal az MCP szerver megszemélyesíthető, és hozzáférhet az OAuth tokenhez tartozó szolgáltatás erőforrásaihoz és adataihoz.

#### Token átengedés  
A token átengedés kifejezetten tilos az autorizációs specifikációban, mert számos biztonsági kockázatot hordoz, többek között:

#### Biztonsági intézkedések megkerülése  
Az MCP szerver vagy az alárendelt API-k fontos biztonsági intézkedéseket valósíthatnak meg, mint például a sebességkorlátozás, kérés-ellenőrzés vagy forgalomfigyelés, amelyek a token célközönségétől vagy más hitelesítő adatoktól függenek. Ha az ügyfelek közvetlenül az alárendelt API-kkal használhatják a tokeneket anélkül, hogy az MCP szerver megfelelően ellenőrizné őket vagy biztosítaná, hogy a tokenek a megfelelő szolgáltatásra szólnak, akkor ezek az intézkedések megkerülhetők.

#### Felelősség és auditálási problémák  
Az MCP szerver nem tudja azonosítani vagy megkülönböztetni az MCP klienset, ha az ügyfelek egy upstream által kibocsátott hozzáférési tokennel hívják meg, amely az MCP szerver számára átlátszatlan lehet.  
Az alárendelt erőforrás-szerver naplói olyan kéréseket mutathatnak, amelyek más forrásból, más identitással érkeznek, nem pedig az MCP szervertől, amely valójában továbbítja a tokeneket.  
Mindkét tényező megnehezíti az incidensek kivizsgálását, az ellenőrzéseket és az auditálást.  
Ha az MCP szerver tokeneket továbbít anélkül, hogy ellenőrizné azok állításait (például szerepkörök, jogosultságok vagy célközönség) vagy más metaadatokat, egy rosszindulatú szereplő, aki ellopott token birtokában van, a szervert proxyként használhatja adatlopásra.

#### Bizalmi határ problémák  
Az alárendelt erőforrás-szerver bizalmat ad bizonyos entitásoknak. Ez a bizalom magában foglalhat feltételezéseket az eredetről vagy az ügyfél viselkedési mintáiról. Ennek a bizalmi határnak a megsértése váratlan problémákhoz vezethet.  
Ha a token több szolgáltatás által is elfogadott anélkül, hogy megfelelően ellenőriznék, egy támadó, aki egy szolgáltatást kompromittál, a tokent felhasználhatja más kapcsolódó szolgáltatások elérésére.

#### Jövőbeli kompatibilitási kockázat  
Még ha egy MCP szerver ma „tiszta proxyként” is működik, később szüksége lehet biztonsági intézkedések hozzáadására. A megfelelő token célközönség szerinti elkülönítés megkönnyíti a biztonsági modell fejlődését.

### Mérséklő intézkedések

**Az MCP szerverek NEM fogadhatnak el olyan tokeneket, amelyeket nem kifejezetten az MCP szerver számára bocsátottak ki**

- **Autorizációs logika felülvizsgálata és megerősítése:** Gondosan auditáld az MCP szerver autorizációs megvalósítását, hogy csak a szándékolt felhasználók és kliensek férhessenek hozzá érzékeny erőforrásokhoz. Gyakorlati útmutatóért lásd az [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) és a [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/) cikkeket.
- **Biztonságos token gyakorlatok betartása:** Kövesd a [Microsoft legjobb gyakorlatait a token érvényesítés és élettartam kezelés terén](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), hogy megelőzd a tokenek visszajátszását vagy lopását.
- **Token tárolás védelme:** Mindig biztonságosan tárold a tokeneket, és használj titkosítást mind tároláskor, mind átvitelkor. Megvalósítási tippekért lásd a [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) videót.

# Túlzott jogosultságok az MCP szerverek számára

### Problémafelvetés  
Az MCP szerverek túlzott jogosultságokat kaphattak az általuk elért szolgáltatásokhoz vagy erőforrásokhoz. Például egy AI értékesítési alkalmazás részeként működő MCP szervernek csak az értékesítési adatokhoz kellene hozzáférnie egy vállalati adattárban, nem pedig az összes fájlhoz. A legkisebb jogosultság elvére visszautalva (ami az egyik legrégebbi biztonsági elv), egyetlen erőforrásnak sem szabadna több jogosultsággal rendelkeznie, mint amennyi a feladat végrehajtásához szükséges. Az AI ezen a területen különösen kihívást jelent, mert a rugalmasság érdekében nehéz pontosan meghatározni a szükséges jogosultságokat.

### Kockázatok  
- A túlzott jogosultságok lehetővé tehetik az adatok kiszivárogtatását vagy módosítását, amelyekhez az MCP szervernek nem kellett volna hozzáférnie. Ez adatvédelmi problémát is jelenthet, ha az adatok személyes azonosításra alkalmas információk (PII).

### Mérséklő intézkedések  
- **Alkalmazd a legkisebb jogosultság elvét:** Csak a szükséges minimális jogosultságokat add meg az MCP szervernek a feladatai ellátásához. Rendszeresen vizsgáld felül és frissítsd ezeket a jogosultságokat, hogy ne haladják meg a szükséges mértéket. Részletes útmutatóért lásd a [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) oldalt.
- **Használj szerepkör alapú hozzáférés-vezérlést (RBAC):** Rendelj az MCP szerverhez olyan szerepköröket, amelyek szigorúan meghatározott erőforrásokra és műveletekre vonatkoznak, elkerülve a széles vagy felesleges jogosultságokat.
- **Figyeld és auditáld a jogosultságokat:** Folyamatosan kövesd nyomon a jogosultságok használatát, és auditáld a hozzáférési naplókat, hogy időben észleld és orvosold a túlzott vagy nem használt jogosultságokat.

# Indirekt prompt injekciós támadások

### Problémafelvetés

Rosszindulatú vagy kompromittált MCP szerverek jelentős kockázatot jelentenek az ügyféladatok kiszivárogtatásával vagy nem kívánt műveletek végrehajtásával. Ezek a kockázatok különösen relevánsak az AI és MCP alapú munkaterhelések esetén, ahol:

- **Prompt injekciós támadások:** A támadók rosszindulatú utasításokat ágyaznak be promptokba vagy külső tartalmakba, amelyek az AI rendszert nem kívánt műveletek végrehajtására vagy érzékeny adatok kiszivárogtatására késztetik. További információ: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Eszközmérgezés:** A támadók manipulálják az eszközök metaadatait (például leírásokat vagy paramétereket), hogy befolyásolják az AI viselkedését, esetleg megkerüljék a biztonsági intézkedéseket vagy adatokat lopjanak. Részletek: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Kereszt-domain prompt injekció:** Rosszindulatú utasítások dokumentumokban, weboldalakon vagy e-mailekben vannak elrejtve, amelyeket az AI feldolgoz, ami adatlopáshoz vagy manipulációhoz vezet.
- **Dinamikus eszköz módosítás (Rug Pull):** Az eszközdefiníciók a felhasználói jóváhagyás után módosíthatók, új rosszindulatú viselkedést bevezetve anélkül, hogy a felhasználó tudna róla.

Ezek a sebezhetőségek hangsúlyozzák a robusztus érvényesítés, megfigyelés és biztonsági intézkedések szükségességét az MCP szerverek és eszközök környezetbe integrálásakor. Mélyebb betekintésért lásd a fent hivatkozott forrásokat.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hu.png)

**Indirekt prompt injekció** (más néven kereszt-domain prompt injekció vagy XPIA) kritikus sebezhetőség a generatív AI rendszerekben, beleértve a Model Context Protocol (MCP) használatát is. Ebben a támadásban rosszindulatú utasítások rejtve vannak külső tartalmakban – például dokumentumokban, weboldalakon vagy e-mailekben. Amikor az AI feldolgozza ezeket, a beágyazott utasításokat jogos felhasználói parancsként értelmezheti, ami nem kívánt műveletekhez vezethet, mint adatlopás, káros tartalom generálása vagy a felhasználói interakciók manipulálása. Részletes magyarázatért és valós példákért lásd a [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/) oldalt.

Különösen veszélyes formája ennek a támadásnak az **eszközmérgezés**. Itt a támadók rosszindulatú utasításokat fecskendeznek be az MCP eszközök metaadataiba (például eszközleírásokba vagy paraméterekbe). Mivel a nagy nyelvi modellek (LLM-ek) ezekre a metaadatokra támaszkodnak az eszközök kiválasztásakor, a kompromittált leírások megtéveszthetik a modellt, hogy jogosulatlan eszközhívásokat hajtson végre vagy megkerülje a biztonsági intézkedéseket. Ezek a manipulációk gyakran láthatatlanok a végfelhasználók számára, de az AI rendszer értelmezheti és végrehajthatja őket. Ez a kock
Az ellátási lánc biztonsága továbbra is alapvető az AI korszakában, de az ellátási lánc fogalma kibővült. A hagyományos kódcsomagokon túl most már szigorúan ellenőrizni és figyelni kell minden AI-hoz kapcsolódó összetevőt, beleértve az alapmodelleket, beágyazási szolgáltatásokat, kontextus szolgáltatókat és harmadik féltől származó API-kat. Ezek mindegyike sebezhetőségeket vagy kockázatokat hordozhat, ha nem megfelelően kezelik.

**Kulcsfontosságú ellátási lánc biztonsági gyakorlatok AI és MCP esetén:**
- **Minden összetevő ellenőrzése integráció előtt:** Ez nem csak a nyílt forráskódú könyvtárakra vonatkozik, hanem az AI modellekre, adatforrásokra és külső API-kra is. Mindig ellenőrizze az eredetet, a licencfeltételeket és a ismert sebezhetőségeket.
- **Biztonságos telepítési folyamatok fenntartása:** Használjon automatizált CI/CD folyamatokat beépített biztonsági vizsgálatokkal a problémák korai felismeréséhez. Biztosítsa, hogy csak megbízható artefaktumok kerüljenek éles környezetbe.
- **Folyamatos megfigyelés és auditálás:** Valósítson meg folyamatos megfigyelést minden függőségre, beleértve a modelleket és adat szolgáltatásokat is, hogy észlelje az új sebezhetőségeket vagy ellátási lánc támadásokat.
- **Legkisebb jogosultság és hozzáférés-ellenőrzés alkalmazása:** Korlátozza a modellekhez, adatokhoz és szolgáltatásokhoz való hozzáférést csak a MCP szerver működéséhez szükséges mértékre.
- **Gyors reagálás a fenyegetésekre:** Legyen kialakított folyamat a kompromittált összetevők javítására vagy cseréjére, valamint a titkos kulcsok vagy hitelesítő adatok forgatására, ha betörést észlelnek.

A [GitHub Advanced Security](https://github.com/security/advanced-security) olyan funkciókat kínál, mint a titkos kulcsok keresése, függőségvizsgálat és CodeQL elemzés. Ezek az eszközök integrálhatók az [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) és az [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) szolgáltatásokkal, hogy segítsék a csapatokat a kód és az AI ellátási lánc összetevőinek sebezhetőségeinek azonosításában és kezelésében.

A Microsoft belsőleg is kiterjedt ellátási lánc biztonsági gyakorlatokat alkalmaz minden termék esetében. További információkért lásd a [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/) cikket.


# Megalapozott biztonsági bevált gyakorlatok, amelyek javítják az MCP megvalósítás biztonsági helyzetét

Bármely MCP megvalósítás örökli a szervezet környezetének meglévő biztonsági helyzetét, amelyre épül, ezért az MCP biztonságát az AI rendszerek részeként vizsgálva ajánlott a meglévő biztonsági helyzet általános javítása. Az alábbi, jól bevált biztonsági intézkedések különösen relevánsak:

-   Biztonságos kódolási bevált gyakorlatok az AI alkalmazásban – védelem az [OWASP Top 10](https://owasp.org/www-project-top-ten/) ellen, az [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559) figyelembevétele, biztonságos tárolók használata titkos kulcsok és tokenek számára, végpontok közötti biztonságos kommunikáció megvalósítása az összes alkalmazáskomponens között stb.
-   Szerver megerősítése – ahol lehetséges, használjon MFA-t, tartsa naprakészen a javításokat, integrálja a szervert harmadik fél azonosító szolgáltatóval a hozzáféréshez stb.
-   Eszközök, infrastruktúra és alkalmazások naprakészen tartása javításokkal
-   Biztonsági megfigyelés – AI alkalmazás (beleértve az MCP kliens/szervereket) naplózásának és megfigyelésének megvalósítása, valamint ezeknek a naplóknak központi SIEM rendszerbe küldése az anomáliák észlelésére
-   Zero trust architektúra – komponensek elkülönítése hálózati és azonosítási szabályokkal logikus módon, hogy minimalizálja az oldalirányú mozgást, ha egy AI alkalmazás kompromittálódna.

# Főbb tanulságok

- A biztonsági alapelvek továbbra is kritikusak: biztonságos kódolás, legkisebb jogosultság, ellátási lánc ellenőrzése és folyamatos megfigyelés elengedhetetlen az MCP és AI munkaterhelések esetén.
- Az MCP új kockázatokat hoz, mint például a prompt injekció, eszközmérgezés és túlzott jogosultságok, amelyekhez mind hagyományos, mind AI-specifikus kontrollok szükségesek.
- Használjon erős hitelesítési, jogosultságkezelési és tokenkezelési gyakorlatokat, lehetőség szerint külső azonosító szolgáltatókat, például Microsoft Entra ID-t alkalmazva.
- Védekezzen az indirekt prompt injekció és eszközmérgezés ellen az eszköz metaadatainak ellenőrzésével, dinamikus változások figyelésével és olyan megoldások használatával, mint a Microsoft Prompt Shields.
- Az AI ellátási lánc minden összetevőjét – beleértve a modelleket, beágyazásokat és kontextus szolgáltatókat – ugyanolyan szigorral kezelje, mint a kód függőségeit.
- Tartsa naprakészen az MCP specifikációkat, és járuljon hozzá a közösséghez a biztonságos szabványok kialakításához.

# További források

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Következő

Következő: [3. fejezet: Első lépések](../03-GettingStarted/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.