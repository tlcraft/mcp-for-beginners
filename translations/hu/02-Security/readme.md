<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:48:02+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "hu"
}
-->
# Biztonsági Legjobb Gyakorlatok

A Model Context Protocol (MCP) alkalmazása erőteljes új képességeket hoz az AI-vezérelt alkalmazásokba, de egyedi biztonsági kihívásokat is bevezet, amelyek túlmutatnak a hagyományos szoftveres kockázatokon. A bevett aggodalmak, mint a biztonságos kódolás, legkisebb jogosultság és ellátási lánc biztonsága mellett, az MCP és az AI munkaterhelések új fenyegetésekkel szembesülnek, mint a prompt injekció, eszköz mérgezés és dinamikus eszköz módosítás. Ha ezeket nem kezelik megfelelően, a kockázatok adatkiáramláshoz, adatvédelmi megsértésekhez és nem kívánt rendszer viselkedéshez vezethetnek.

Ez a lecke az MCP-hez kapcsolódó legrelevánsabb biztonsági kockázatokat vizsgálja meg - beleértve a hitelesítést, az engedélyezést, a túlzott jogosultságokat, a közvetett prompt injekciót és az ellátási lánc sebezhetőségeit -, és cselekvésre alkalmas kontrollokat és legjobb gyakorlatokat kínál a kockázatok enyhítésére. Megtanulhatja, hogyan használja ki a Microsoft megoldásait, mint a Prompt Shields, Azure Content Safety és GitHub Advanced Security az MCP implementációjának megerősítésére. Ezeknek a kontrolloknak a megértésével és alkalmazásával jelentősen csökkentheti a biztonsági megsértés valószínűségét, és biztosíthatja, hogy AI rendszerei robusztusak és megbízhatóak maradjanak.

# Tanulási Célok

A lecke végére képes lesz:

- Azonosítani és megmagyarázni a Model Context Protocol (MCP) által bevezetett egyedi biztonsági kockázatokat, beleértve a prompt injekciót, eszköz mérgezést, túlzott jogosultságokat és ellátási lánc sebezhetőségeit.
- Leírni és alkalmazni hatékony enyhítő kontrollokat az MCP biztonsági kockázatokra, mint a robusztus hitelesítés, legkisebb jogosultság, biztonságos token kezelés és ellátási lánc ellenőrzés.
- Megérteni és kihasználni a Microsoft megoldásait, mint a Prompt Shields, Azure Content Safety és GitHub Advanced Security az MCP és AI munkaterhelések védelmére.
- Felismerni az eszköz metaadatok validálásának, a dinamikus változások monitorozásának és a közvetett prompt injekció támadások elleni védekezés fontosságát.
- Integrálni a bevett biztonsági legjobb gyakorlatokat - mint a biztonságos kódolás, szerver keményítés és zero trust architektúra - az MCP implementációjába a biztonsági megsértések valószínűségének és hatásának csökkentése érdekében.

# MCP biztonsági kontrollok

Bármely rendszer, amely fontos erőforrásokhoz fér hozzá, implicit biztonsági kihívásokkal rendelkezik. A biztonsági kihívások általában kezelhetők az alapvető biztonsági kontrollok és koncepciók helyes alkalmazásával. Mivel az MCP csak újonnan került meghatározásra, a specifikáció nagyon gyorsan változik, ahogy a protokoll fejlődik. Végül a benne lévő biztonsági kontrollok érni fognak, lehetővé téve a jobb integrációt a vállalati és bevett biztonsági architektúrákkal és legjobb gyakorlatokkal.

A [Microsoft Digital Defense Report](https://aka.ms/mddr) kutatása szerint a jelentett megsértések 98%-át megakadályozná a robusztus biztonsági higiénia, és a legjobb védelem bármilyen megsértés ellen az alapvető biztonsági higiénia, biztonságos kódolási legjobb gyakorlatok és ellátási lánc biztonságának helyes megvalósítása - azok a kipróbált és tesztelt gyakorlatok, amelyeket már ismerünk, még mindig a legnagyobb hatást gyakorolják a biztonsági kockázatok csökkentésére.

Nézzük meg néhány módját annak, hogy elkezdhetjük kezelni a biztonsági kockázatokat az MCP alkalmazásakor.

# MCP szerver hitelesítés (ha az MCP implementáció 2025. április 26. előtt történt)

> **Megjegyzés:** Az alábbi információk 2025. április 26-i állapot szerint helyesek. Az MCP protokoll folyamatosan fejlődik, és a jövőbeni implementációk új hitelesítési mintákat és kontrollokat vezethetnek be. A legfrissebb frissítésekért és útmutatásért mindig tekintse meg az [MCP Specifikációt](https://spec.modelcontextprotocol.io/) és az hivatalos [MCP GitHub tárházat](https://github.com/modelcontextprotocol).

### Probléma megfogalmazása
Az eredeti MCP specifikáció feltételezte, hogy a fejlesztők saját hitelesítési szervert írnak. Ez az OAuth és kapcsolódó biztonsági korlátok ismeretét igényelte. Az MCP szerverek OAuth 2.0 Engedélyezési Szerverként működtek, közvetlenül kezelve a szükséges felhasználói hitelesítést, ahelyett hogy külső szolgáltatásnak, mint a Microsoft Entra ID-nek delegálták volna. 2025. április 26-tól az MCP specifikáció frissítése lehetővé teszi, hogy az MCP szerverek a felhasználói hitelesítést külső szolgáltatásnak delegálják.

### Kockázatok
- Az MCP szerverben helytelenül konfigurált engedélyezési logika érzékeny adatok kitettségéhez és helytelenül alkalmazott hozzáférés-kontrollokhoz vezethet.
- OAuth token lopás a helyi MCP szerveren. Ha ellopják, a token felhasználható az MCP szerver megszemélyesítésére és erőforrásokhoz és adatokhoz való hozzáférésre a szolgáltatásból, amelyhez az OAuth token tartozik.

### Enyhítő kontrollok
- **Engedélyezési logika felülvizsgálata és keményítése:** Gondosan auditálja az MCP szerverének engedélyezési implementációját, hogy biztosítsa, csak a szándékolt felhasználók és kliensek férhetnek hozzá érzékeny erőforrásokhoz. Gyakorlati útmutatásért tekintse meg az [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) és [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Biztonságos token gyakorlatok érvényesítése:** Kövesse [Microsoft legjobb gyakorlatokat a token validálás és élettartam](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) érdekében, hogy megakadályozza a hozzáférési tokenek visszaélését és csökkentse a token újrajátszás vagy lopás kockázatát.
- **Token tárolás védelme:** Mindig tárolja a tokeneket biztonságosan, és használjon titkosítást a megőrzésük és szállításuk védelmére. Implementációs tippekért tekintse meg [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Túlzott jogosultságok az MCP szervereknél

### Probléma megfogalmazása
Az MCP szerverek túlzott jogosultságokat kaptak a szolgáltatás/erőforrás elérésére, amelyhez hozzáférnek. Például egy AI értékesítési alkalmazás részét képező MCP szerver, amely egy vállalati adatbázishoz kapcsolódik, csak az értékesítési adatokhoz kellene hozzáférnie, és nem engedélyezett, hogy hozzáférjen az összes fájlhoz a tárolóban. Az egyik legrégebbi biztonsági elv, a legkisebb jogosultság elve szerint, egy erőforrásnak sem kellene a szükségesnél nagyobb jogosultságokat kapnia a feladatok végrehajtásához, amelyre szánták. Az AI nagyobb kihívást jelent ezen a területen, mivel a rugalmasság biztosítása érdekében nehéz lehet pontosan meghatározni a szükséges jogosultságokat.

### Kockázatok
- Túlzott jogosultságok megadása lehetővé teheti az adatok kiáramlását vagy módosítását, amelyhez az MCP szervernek nem szándékozták hozzáférni. Ez adatvédelmi problémát is jelenthet, ha az adatok személyesen azonosítható információk (PII).

### Enyhítő kontrollok
- **Alkalmazza a legkisebb jogosultság elvét:** Csak a minimális jogosultságokat adja meg az MCP szervernek a szükséges feladatok végrehajtásához. Rendszeresen vizsgálja felül és frissítse ezeket a jogosultságokat, hogy biztosítsa, nem haladják meg a szükséges mértéket. Részletes útmutatásért tekintse meg [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Használja a szerep-alapú hozzáférés-kontrollt (RBAC):** Adjon szerepeket az MCP szervernek, amelyek szorosan korlátozottak specifikus erőforrásokra és műveletekre, elkerülve a széles vagy szükségtelen jogosultságokat.
- **Jogosultságok monitorozása és auditálása:** Folyamatosan monitorozza a jogosultságok használatát és auditálja a hozzáférési naplókat, hogy gyorsan észlelje és orvosolja a túlzott vagy fel nem használt jogosultságokat.

# Közvetett prompt injekció támadások

### Probléma megfogalmazása

A rosszindulatú vagy kompromittált MCP szerverek jelentős kockázatokat okozhatnak, például ügyféladatok kitettségét vagy nem kívánt műveletek engedélyezését. Ezek a kockázatok különösen relevánsak az AI és MCP-alapú munkaterhelések esetében, ahol:

- **Prompt Injekciós Támadások**: A támadók rosszindulatú utasításokat ágyaznak be promptokba vagy külső tartalmakba, ami miatt az AI rendszer nem kívánt műveleteket hajt végre vagy érzékeny adatokat szivárogtat ki. További információ: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Eszköz Mérgezés**: A támadók manipulálják az eszköz metaadatait (például leírásokat vagy paramétereket), hogy befolyásolják az AI viselkedését, potenciálisan megkerülve a biztonsági kontrollokat vagy adatokat szivárogtatva ki. Részletek: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Kereszt-Domain Prompt Injekció**: Rosszindulatú utasításokat ágyaznak be dokumentumokba, weboldalakba vagy e-mailekbe, amelyeket az AI feldolgoz, adat szivárgáshoz vagy manipulációhoz vezetve.
- **Dinamikus Eszköz Módosítás (Rug Pulls)**: Az eszköz definíciók módosíthatók a felhasználói jóváhagyás után, új rosszindulatú viselkedést vezetve be a felhasználó tudta nélkül.

Ezek a sebezhetőségek kiemelik a robusztus validáció, monitorozás és biztonsági kontrollok szükségességét, amikor MCP szervereket és eszközöket integrál a környezetébe. További részletekért tekintse meg a fent hivatkozott forrásokat.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.hu.png)

**Közvetett Prompt Injekció** (más néven kereszt-domain prompt injekció vagy XPIA) kritikus sebezhetőség a generatív AI rendszerekben, beleértve azokat, amelyek a Model Context Protocol (MCP) használják. Ebben a támadásban rosszindulatú utasítások rejtve vannak külső tartalmakban - mint dokumentumok, weboldalak vagy e-mailek. Amikor az AI rendszer feldolgozza ezt a tartalmat, a beágyazott utasításokat legitim felhasználói parancsokként értelmezheti, nem kívánt műveletekhez vezetve, mint adat szivárgás, káros tartalom generálása vagy felhasználói interakciók manipulálása. Részletes magyarázatért és valós példákért tekintse meg [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

E támadás különösen veszélyes formája az **Eszköz Mérgezés**. Itt a támadók rosszindulatú utasításokat injektálnak az MCP eszközök metaadataiba (mint az eszköz leírások vagy paraméterek). Mivel a nagy nyelvi modellek (LLM-ek) ezen metaadatokra támaszkodnak az eszközök meghívásának eldöntéséhez, a kompromittált leírások becsaphatják a modellt, hogy jogosulatlan eszköz hívásokat hajtson végre vagy megkerülje a biztonsági kontrollokat. Ezek a manipulációk gyakran láthatatlanok a végfelhasználók számára, de az AI rendszer értelmezheti és végrehajthatja őket. Ez a kockázat fokozódik a hosztolt MCP szerver környezetekben, ahol az eszköz definíciók frissíthetők a felhasználói jóváhagyás után - ezt a forgatókönyvet néha "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)"-nak nevezik. Ilyen esetekben egy korábban biztonságos eszköz később módosítható rosszindulatú műveletek végrehajtására, mint adat kiáramlás vagy rendszer viselkedés módosítása, a felhasználó tudta nélkül. További információért ezen támadási vektorról tekintse meg [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.hu.png)

## Kockázatok
A nem szándékolt AI műveletek számos biztonsági kockázatot jelentenek, beleértve az adat kiáramlást és adatvédelmi megsértéseket.

### Enyhítő kontrollok
### Prompt pajzsok használata a közvetett prompt injekció támadások ellen
-----------------------------------------------------------------------------

**AI Prompt Pajzsok** a Microsoft által kifejlesztett megoldás mind közvetlen, mind közvetett prompt injekció támadások ellen. Segítenek a következők révén:

1.  **Észlelés és Szűrés**: A Prompt Pajzsok fejlett gépi tanulási algoritmusokat és természetes nyelvi feldolgozást használnak, hogy észleljék és kiszűrjék a rosszindulatú utasításokat külső tartalmakban, mint dokumentumok, weboldalak vagy e-mailek.
    
2.  **Spotlighting**: Ez a technika segíti az AI rendszert abban, hogy megkülönböztesse az érvényes rendszer utasításokat és a potenciálisan megbízhatatlan külső bemeneteket. Az input szöveg átalakításával, hogy relevánsabb legyen a modell számára, a Spotlighting biztosítja, hogy az AI jobban azonosíthassa és figyelmen kívül hagyja a rosszindulatú utasításokat.
    
3.  **Határolók és Adatjelölés**: A rendszerüzenetben határolók szerepeltetése explicit módon körvonalazza az input szöveg helyét, segítve az AI rendszert abban, hogy felismerje és elkülönítse a felhasználói bemeneteket a potenciálisan káros külső tartalmaktól. Az adatjelölés kiterjeszti ezt
- [OWASP Top 10 LLM-ekhez](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Fejlett Biztonság](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Az út a szoftverellátási lánc biztonságossá tételéhez a Microsoftnál](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Biztonságos legkisebb jogosultságú hozzáférés (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Legjobb gyakorlatok a token érvényesítéshez és élettartamhoz](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Biztonságos token tárolás és tokenek titkosítása (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management mint hitelesítési átjáró az MCP-hez](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID használata az MCP szerverekkel való hitelesítéshez](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Következő

Következő: [3. fejezet: Kezdés](/03-GettingStarted/README.md)

**Felelősség kizárása**:  
Ez a dokumentum az AI fordítószolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével került lefordításra. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.