<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T10:49:22+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "cs"
}
-->
# Nejlepší bezpečnostní postupy

Přijetí Model Context Protocolu (MCP) přináší do aplikací založených na umělé inteligenci nové a silné možnosti, ale zároveň představuje jedinečné bezpečnostní výzvy, které přesahují tradiční softwarová rizika. Kromě zavedených oblastí, jako je bezpečné programování, princip nejmenších oprávnění a bezpečnost dodavatelského řetězce, čelí MCP a AI pracovní zátěže novým hrozbám, jako jsou prompt injection, otrava nástrojů, dynamické modifikace nástrojů, únosy relací, útoky typu confused deputy a zranitelnosti při předávání tokenů. Tyto rizika mohou vést k úniku dat, narušení soukromí a nechtěnému chování systému, pokud nejsou správně řízena.

Tato lekce se zabývá nejrelevantnějšími bezpečnostními riziky spojenými s MCP — včetně autentizace, autorizace, nadměrných oprávnění, nepřímého prompt injection, bezpečnosti relací, problémů confused deputy, zranitelností při předávání tokenů a zranitelností dodavatelského řetězce — a poskytuje praktická opatření a nejlepší postupy pro jejich zmírnění. Naučíte se také, jak využít řešení Microsoftu, jako jsou Prompt Shields, Azure Content Safety a GitHub Advanced Security, k posílení vaší implementace MCP. Porozuměním a aplikací těchto opatření můžete výrazně snížit pravděpodobnost bezpečnostního incidentu a zajistit, že vaše AI systémy zůstanou robustní a důvěryhodné.

## Cíle učení

Na konci této lekce budete schopni:

- Identifikovat a vysvětlit jedinečná bezpečnostní rizika zavedená Model Context Protokolem (MCP), včetně prompt injection, otravy nástrojů, nadměrných oprávnění, únosu relací, problémů confused deputy, zranitelností při předávání tokenů a zranitelností dodavatelského řetězce.
- Popsat a aplikovat účinná opatření pro zmírnění bezpečnostních rizik MCP, jako je robustní autentizace, princip nejmenších oprávnění, bezpečná správa tokenů, kontrola bezpečnosti relací a ověřování dodavatelského řetězce.
- Porozumět a využít řešení Microsoftu, jako jsou Prompt Shields, Azure Content Safety a GitHub Advanced Security, k ochraně MCP a AI pracovních zátěží.
- Uvědomit si důležitost ověřování metadat nástrojů, monitorování dynamických změn, obrany proti nepřímým prompt injection útokům a prevence únosu relací.
- Integrovat zavedené bezpečnostní postupy — jako je bezpečné programování, zpevnění serveru a architektura zero trust — do vaší implementace MCP, aby se snížila pravděpodobnost a dopad bezpečnostních incidentů.

# Bezpečnostní kontroly MCP

Každý systém, který má přístup k důležitým zdrojům, čelí implicitním bezpečnostním výzvám. Tyto výzvy lze obecně řešit správnou aplikací základních bezpečnostních kontrol a konceptů. Jelikož je MCP teprve nově definován, specifikace se velmi rychle mění a protokol se vyvíjí. Nakonec bezpečnostní kontroly v něm obsažené dozrají, což umožní lepší integraci s podnikovými a zavedenými bezpečnostními architekturami a nejlepšími postupy.

Výzkum publikovaný v [Microsoft Digital Defense Report](https://aka.ms/mddr) uvádí, že 98 % hlášených průniků by bylo zabráněno díky robustní bezpečnostní hygieně a nejlepší ochranou proti jakémukoli průniku je správné nastavení základní bezpečnostní hygieny, osvědčených postupů bezpečného kódování a bezpečnosti dodavatelského řetězce — tyto prověřené postupy stále nejvíce snižují bezpečnostní rizika.

## Současná bezpečnostní situace

> **Note:** Následující informace jsou platné k **29. květnu 2025**. Protokol MCP se neustále vyvíjí a budoucí implementace mohou zavést nové vzory autentizace a kontroly. Pro nejnovější aktualizace a doporučení vždy odkazujte na [MCP Specification](https://spec.modelcontextprotocol.io/) a oficiální [MCP GitHub repository](https://github.com/modelcontextprotocol) a [stránku s nejlepšími bezpečnostními postupy](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problém

Původní specifikace MCP předpokládala, že vývojáři napíší vlastní autentizační server. To vyžadovalo znalosti OAuth a souvisejících bezpečnostních omezení. MCP servery fungovaly jako OAuth 2.0 autorizační servery, které přímo spravovaly požadovanou uživatelskou autentizaci, místo aby ji delegovaly na externí službu, jako je Microsoft Entra ID. Od **26. dubna 2025** aktualizace specifikace MCP umožňuje MCP serverům delegovat autentizaci uživatelů na externí službu.

### Rizika
- Nesprávně nakonfigurovaná autorizační logika na MCP serveru může vést k úniku citlivých dat a nesprávnému uplatnění přístupových kontrol.
- Krádež OAuth tokenu na lokálním MCP serveru. Pokud je token ukraden, může být použit k vydávání se za MCP server a přístupu k prostředkům a datům služby, pro kterou je token určen.

#### Předávání tokenů: Kritický anti-vzor

**Předávání tokenů je výslovně zakázáno** v aktuální specifikaci autorizace MCP kvůli závažným bezpečnostním důsledkům:

#### Obcházení bezpečnostních kontrol
MCP server nebo downstream API mohou implementovat důležité bezpečnostní kontroly, jako je omezení rychlosti, validace požadavků nebo monitorování provozu, které závisí na publiku tokenu nebo jiných omezeních přihlašovacích údajů. Pokud klienti mohou získat a používat tokeny přímo s downstream API bez řádné validace MCP serverem nebo bez zajištění, že tokeny jsou vydány pro správnou službu, obcházejí tyto kontroly.

#### Problémy s odpovědností a auditní stopou
MCP server nebude schopen identifikovat nebo rozlišit mezi MCP klienty, pokud klienti volají s přístupovým tokenem vydaným upstream, který může být pro MCP server neprůhledný. Logy downstream Resource Serveru mohou ukazovat požadavky, které vypadají, že pocházejí z jiného zdroje s jinou identitou, než je MCP server, který tokeny skutečně předává. Oba tyto faktory ztěžují vyšetřování incidentů, kontrolu a auditování. Pokud MCP server předává tokeny bez ověření jejich nároků (např. rolí, oprávnění nebo publika) či jiných metadat, může útočník s ukradeným tokenem použít server jako proxy pro exfiltraci dat.

#### Problémy s hranicí důvěry
Downstream Resource Server důvěřuje konkrétním entitám. Tato důvěra může zahrnovat předpoklady o původu nebo vzorcích chování klienta. Porušení této hranice důvěry může vést k neočekávaným problémům. Pokud je token akceptován více službami bez řádné validace, útočník, který kompromitoval jednu službu, může token použít k přístupu k dalším propojeným službám.

#### Riziko budoucí kompatibility
I když MCP server dnes začíná jako „čistý proxy“, může později potřebovat přidat bezpečnostní kontroly. Začít správným oddělením publika tokenů usnadňuje budoucí vývoj bezpečnostního modelu.

### Opatření pro zmírnění rizik

**MCP servery NESMÍ přijímat žádné tokeny, které nebyly výslovně vydány pro MCP server**

- **Zkontrolujte a zpevněte autorizační logiku:** Pečlivě auditujte implementaci autorizace vašeho MCP serveru, aby měli přístup k citlivým zdrojům pouze zamýšlení uživatelé a klienti. Pro praktické rady viz [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) a [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Prosazujte bezpečné praktiky s tokeny:** Dodržujte [nejlepší postupy Microsoftu pro validaci tokenů a jejich životnost](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), abyste zabránili zneužití přístupových tokenů a snížili riziko opakovaného použití nebo krádeže tokenů.
- **Chraňte ukládání tokenů:** Tokeny vždy ukládejte bezpečně a používejte šifrování k ochraně dat v klidu i při přenosu. Pro tipy na implementaci viz [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadměrná oprávnění pro MCP servery

### Problém
MCP serverům mohla být udělena nadměrná oprávnění k službě nebo zdroji, ke kterému přistupují. Například MCP server, který je součástí AI aplikace prodeje a připojuje se k podnikové datové úložišti, by měl mít přístup omezený pouze na prodejní data a neměl by mít přístup ke všem souborům v úložišti. Vraťme se k principu nejmenších oprávnění (jednomu z nejstarších bezpečnostních principů) — žádný zdroj by neměl mít oprávnění nad rámec toho, co je nezbytné pro vykonání jeho úkolů. AI zde představuje zvýšenou výzvu, protože pro její flexibilitu může být obtížné přesně definovat potřebná oprávnění.

### Rizika
- Udělení nadměrných oprávnění může umožnit exfiltraci nebo změnu dat, ke kterým MCP server neměl mít přístup. Může to být také problémem ochrany soukromí, pokud se jedná o osobní identifikovatelné informace (PII).

### Opatření pro zmírnění rizik
- **Uplatňujte princip nejmenších oprávnění:** Udělte MCP serveru pouze minimální oprávnění nezbytná k vykonání jeho úkolů. Pravidelně tyto oprávnění přezkoumávejte a aktualizujte, aby nepřesahovala nezbytnou míru. Podrobné pokyny najdete v [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Používejte řízení přístupu na základě rolí (RBAC):** Přiřazujte MCP serveru role, které jsou úzce omezené na konkrétní zdroje a akce, vyhýbejte se širokým nebo zbytečným oprávněním.
- **Monitorujte a auditujte oprávnění:** Nepřetržitě sledujte využívání oprávnění a auditujte přístupové záznamy, abyste rychle odhalili a odstranili nadměrná nebo nevyužívaná oprávnění.

# Nepřímé útoky prompt injection

### Problém

Zlovolné nebo kompromitované MCP servery mohou představovat významná rizika tím, že vystavují zákaznická data nebo umožňují nechtěné akce. Tato rizika jsou zvláště relevantní u AI a MCP založených pracovních zátěží, kde:

- **Útoky prompt injection:** Útočníci vkládají škodlivé instrukce do promptů nebo externího obsahu, což způsobuje, že AI systém provádí nechtěné akce nebo uniká citlivá data. Více informací: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrava nástrojů:** Útočníci manipulují s metadaty nástrojů (například popisy nebo parametry), aby ovlivnili chování AI, potenciálně obcházeli bezpečnostní kontroly nebo exfiltrovali data. Podrobnosti: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-domain prompt injection:** Škodlivé instrukce jsou vloženy do dokumentů, webových stránek nebo e-mailů, které AI zpracovává, což vede k úniku nebo manipulaci s daty.
- **Dynamická modifikace nástrojů (Rug Pulls):** Definice nástrojů mohou být po schválení uživatelem změněny, což zavádí nové škodlivé chování bez vědomí uživatele.

Tyto zranitelnosti zdůrazňují potřebu robustní validace, monitorování a bezpečnostních kontrol při integraci MCP serverů a nástrojů do vašeho prostředí. Pro hlubší pochopení viz výše uvedené odkazy.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.cs.png)

**Nepřímý prompt injection** (také známý jako cross-domain prompt injection nebo XPIA) je kritická zranitelnost v generativních AI systémech, včetně těch používajících Model Context Protocol (MCP). Při tomto útoku jsou škodlivé instrukce skryty v externím obsahu — například v dokumentech, webových stránkách nebo e-mailech. Když AI systém tento obsah zpracovává, může vložené instrukce interpretovat jako legitimní uživatelské příkazy, což vede k nechtěným akcím, jako je únik dat, generování škodlivého obsahu nebo manipulace s uživatelskými interakcemi. Pro podrobný popis a reálné příklady viz [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Zvláště nebezpečnou formou tohoto útoku je **otrava nástrojů**. Útočníci zde vkládají škodlivé instrukce do metadat MCP nástrojů (například popisů nebo parametrů). Protože velké jazykové modely (LLM) spoléhají na tato metadata při rozhodování, které nástroje vyvolat, mohou kompromitované popisy oklamat model, aby provedl neautorizované volání nástrojů nebo obešel bezpečnostní kontroly. Tyto manipulace jsou často pro koncové uživatele neviditelné, ale AI systém je může interpretovat a vykonat. Toto riziko je zvýšené v hostovaných prostředích MCP serverů, kde definice nástrojů mohou být po schválení uživatelem aktualizovány — scénář někdy označovaný jako "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takových případech může být nástroj, který byl dříve bezpečný, později upraven tak, aby prováděl škodlivé akce, jako je exfiltrace dat nebo změna chování systému, aniž by o tom uživatel věděl. Více o tomto útoku najdete v [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.cs.png)

## Rizika
Nechtěné akce AI představují různá bezpečnostní rizika, včetně úniku dat a narušení soukromí.

### Opatření pro zmírnění rizik
### Použití prompt shields k ochraně proti nepřímým prompt injection útokům
-----------------------------------------------------------------------------

**AI Prompt Shields** jsou řešení vyvinuté Microsoftem k obraně proti přímým i nepřímým prompt injection útokům. Pomáhají prostřednictvím:

1.  **Detekce a filtrování:** Prompt Shields využívají pokročilé algoritmy strojového učení a zpracování přirozeného jazyka k detekci a filtrování škodlivých instrukcí vložených v externím obsahu, jako jsou dokumenty, webové stránky nebo e-maily.
    
2.  **Spotlighting:** Tato technika pomáhá AI systému rozlišit platné systémové instrukce od potenciálně nedůvěryhodných externích vstupů. Transformací vstupního textu tak, aby byl pro model relevantnější, Spotlighting zajišťuje, že AI lépe identifikuje a ignoruje škodlivé instrukce.
    
3.  **Oddělovače a datamarking:** Začlenění oddělovačů do systémové zprávy jasně vymezuje umístění vstupního textu, což pomáhá AI systému rozpozn
Problém zmateného zástupce je bezpečnostní zranitelnost, která nastává, když MCP server funguje jako proxy mezi MCP klienty a API třetích stran. Tuto zranitelnost lze zneužít, pokud MCP server používá statické klientské ID pro autentizaci u autorizačního serveru třetí strany, který nepodporuje dynamickou registraci klientů.

### Rizika

- **Obcházení souhlasu založeného na cookies**: Pokud se uživatel dříve autentizoval přes MCP proxy server, může autorizační server třetí strany nastavit v prohlížeči uživatele cookie se souhlasem. Útočník může toto později zneužít zasláním škodlivého odkazu s upravenou autorizační žádostí obsahující škodlivé přesměrování URI.
- **Krádež autorizačního kódu**: Když uživatel klikne na škodlivý odkaz, autorizační server třetí strany může přeskočit obrazovku souhlasu kvůli existující cookie a autorizační kód může být přesměrován na server útočníka.
- **Neoprávněný přístup k API**: Útočník může vyměnit ukradený autorizační kód za přístupové tokeny a vydávat se za uživatele, aby získal přístup k API třetí strany bez výslovného schválení.

### Opatření ke zmírnění

- **Požadavky na explicitní souhlas**: MCP proxy servery používající statická klientská ID **MUSÍ** získat souhlas uživatele pro každého dynamicky registrovaného klienta před přeposláním na autorizační servery třetích stran.
- **Správná implementace OAuth**: Dodržujte bezpečnostní nejlepší postupy OAuth 2.1, včetně použití code challenge (PKCE) u autorizačních požadavků, aby se zabránilo útokům zachycení.
- **Validace klienta**: Implementujte přísnou validaci přesměrovacích URI a identifikátorů klientů, aby se zabránilo zneužití škodlivými aktéry.


# Zranitelnosti při přeposílání tokenů

### Popis problému

„Token passthrough“ je anti-vzor, kdy MCP server přijímá tokeny od MCP klienta, aniž by ověřil, že tokeny byly správně vydány přímo pro MCP server, a poté je „přeposílá“ do downstream API. Tento přístup výslovně porušuje specifikaci autorizace MCP a představuje vážná bezpečnostní rizika.

### Rizika

- **Obcházení bezpečnostních kontrol**: Klienti by mohli obejít důležité bezpečnostní kontroly, jako je omezení rychlosti, validace požadavků nebo monitorování provozu, pokud mohou používat tokeny přímo s downstream API bez řádné validace.
- **Problémy s odpovědností a auditní stopou**: MCP server nebude schopen identifikovat nebo rozlišit mezi MCP klienty, pokud klienti používají přístupové tokeny vydané upstream, což ztíží vyšetřování incidentů a audit.
- **Exfiltrace dat**: Pokud jsou tokeny předávány bez správné validace nároků, může škodlivý aktér s ukradeným tokenem použít server jako proxy pro exfiltraci dat.
- **Porušení hranic důvěry**: Downstream servery zdrojů mohou důvěřovat specifickým entitám na základě předpokladů o původu nebo vzorcích chování. Porušení této hranice může vést k neočekávaným bezpečnostním problémům.
- **Zneužití tokenů v rámci více služeb**: Pokud jsou tokeny přijímány více službami bez řádné validace, útočník, který kompromituje jednu službu, může použít token k přístupu k dalším propojeným službám.

### Opatření ke zmírnění

- **Validace tokenů**: MCP servery **NESMÍ** přijímat žádné tokeny, které nebyly výslovně vydány pro samotný MCP server.
- **Ověření publika**: Vždy ověřujte, že tokeny mají správný nárok audience odpovídající identitě MCP serveru.
- **Správná správa životního cyklu tokenů**: Implementujte krátkodobé přístupové tokeny a správné postupy rotace tokenů, aby se snížilo riziko krádeže a zneužití tokenů.


# Únos relace

### Popis problému

Únos relace je útok, kdy klient obdrží od serveru ID relace a neoprávněná strana získá a použije toto stejné ID relace k vydávání se za původního klienta a provádění neoprávněných akcí jeho jménem. To je zvláště problematické u stavových HTTP serverů zpracovávajících požadavky MCP.

### Rizika

- **Vstřikování škodlivých promptů při únosu relace**: Útočník, který získá ID relace, může posílat škodlivé události na server, který sdílí stav relace se serverem, ke kterému je klient připojen, což může vyvolat škodlivé akce nebo přístup k citlivým datům.
- **Vydávání se za uživatele při únosu relace**: Útočník s ukradeným ID relace může volat přímo MCP server, obejít autentizaci a být považován za legitimního uživatele.
- **Ohrožení obnovitelných streamů**: Pokud server podporuje opětovné doručení/obnovitelné streamy, útočník může předčasně ukončit požadavek, který pak původní klient obnoví s potenciálně škodlivým obsahem.

### Opatření ke zmírnění

- **Ověření autorizace**: MCP servery, které implementují autorizaci, **MUSÍ** ověřovat všechny příchozí požadavky a **NESMÍ** používat relace pro autentizaci.
- **Bezpečná ID relací**: MCP servery **MUSÍ** používat bezpečná, nedeterministická ID relací generovaná pomocí bezpečných generátorů náhodných čísel. Vyhněte se předvídatelným nebo sekvenčním identifikátorům.
- **Vazba relace na uživatele**: MCP servery **MĚLY BY** vázat ID relace na uživatelsky specifické informace, kombinovat ID relace s unikátními údaji autorizovaného uživatele (např. jeho interním uživatelským ID) ve formátu `
<user_id>:<session_id>`.
- **Vypršení platnosti relace**: Implementujte správné vypršení platnosti a rotaci relací, aby se omezilo okno zranitelnosti v případě kompromitace ID relace.
- **Zabezpečení přenosu**: Vždy používejte HTTPS pro veškerou komunikaci, aby se zabránilo zachycení ID relace.


# Bezpečnost dodavatelského řetězce

Bezpečnost dodavatelského řetězce zůstává v éře AI zásadní, ale rozsah toho, co tvoří váš dodavatelský řetězec, se rozšířil. Kromě tradičních balíčků kódu musíte nyní důkladně ověřovat a monitorovat všechny AI související komponenty, včetně základních modelů, služeb embeddingů, poskytovatelů kontextu a API třetích stran. Každá z těchto částí může představovat zranitelnosti nebo rizika, pokud není správně řízena.

**Klíčové bezpečnostní postupy dodavatelského řetězce pro AI a MCP:**
- **Ověřujte všechny komponenty před integrací:** To zahrnuje nejen open-source knihovny, ale také AI modely, datové zdroje a externí API. Vždy kontrolujte původ, licencování a známé zranitelnosti.
- **Udržujte bezpečné nasazovací pipeline:** Používejte automatizované CI/CD pipeline s integrovaným bezpečnostním skenováním pro včasné odhalení problémů. Zajistěte, že do produkce jsou nasazovány pouze důvěryhodné artefakty.
- **Průběžně monitorujte a auditujte:** Implementujte kontinuální monitorování všech závislostí, včetně modelů a datových služeb, pro detekci nových zranitelností nebo útoků na dodavatelský řetězec.
- **Používejte princip nejmenších oprávnění a přístupové kontroly:** Omezte přístup k modelům, datům a službám pouze na to, co je nezbytné pro fungování vašeho MCP serveru.
- **Rychle reagujte na hrozby:** Mějte zavedený proces pro záplaty nebo výměnu kompromitovaných komponent a pro rotaci tajemství či přihlašovacích údajů v případě detekce narušení.

[GitHub Advanced Security](https://github.com/security/advanced-security) nabízí funkce jako skenování tajemství, skenování závislostí a analýzu CodeQL. Tyto nástroje se integrují s [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) a [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), aby pomohly týmům identifikovat a zmírnit zranitelnosti jak v kódu, tak v AI komponentách dodavatelského řetězce.

Microsoft také interně implementuje rozsáhlé bezpečnostní postupy dodavatelského řetězce pro všechny produkty. Více se dozvíte v [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Zavedené bezpečnostní nejlepší postupy, které zlepší bezpečnostní úroveň vaší implementace MCP

Každá implementace MCP dědí stávající bezpečnostní úroveň prostředí vaší organizace, na kterém je postavena, proto se při zvažování bezpečnosti MCP jako součásti vašich celkových AI systémů doporučuje zlepšit celkovou stávající bezpečnostní úroveň. Následující zavedené bezpečnostní kontroly jsou obzvláště relevantní:

- Bezpečnostní nejlepší postupy psaní kódu ve vaší AI aplikaci – ochrana proti [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 pro LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), použití bezpečných trezorů pro tajemství a tokeny, implementace end-to-end zabezpečené komunikace mezi všemi komponentami aplikace atd.
- Zpevnění serveru – používejte MFA, kde je to možné, udržujte aktualizace a záplaty, integrujte server s poskytovatelem identity třetí strany pro přístup atd.
- Udržujte zařízení, infrastrukturu a aplikace aktuální s nejnovějšími záplatami
- Bezpečnostní monitoring – implementace logování a monitorování AI aplikace (včetně MCP klientů/serverů) a odesílání těchto logů do centrálního SIEM pro detekci anomálií
- Architektura zero trust – izolace komponent pomocí síťových a identitních kontrol logickým způsobem, aby se minimalizoval laterální pohyb v případě kompromitace AI aplikace.

# Klíčové poznatky

- Základy bezpečnosti zůstávají klíčové: Bezpečné psaní kódu, princip nejmenších oprávnění, ověřování dodavatelského řetězce a kontinuální monitoring jsou nezbytné pro MCP a AI workloady.
- MCP přináší nová rizika – jako jsou prompt injection, otrava nástrojů, únos relace, problém zmateného zástupce, zranitelnosti přeposílání tokenů a nadměrná oprávnění – která vyžadují jak tradiční, tak AI-specifická opatření.
- Používejte robustní autentizaci, autorizaci a správu tokenů, využívejte externí poskytovatele identity jako Microsoft Entra ID, kde je to možné.
- Chraňte se proti nepřímému prompt injection a otravě nástrojů ověřováním metadat nástrojů, monitorováním dynamických změn a používáním řešení jako Microsoft Prompt Shields.
- Implementujte bezpečnou správu relací pomocí nedeterministických ID relací, vázání relací na uživatelské identity a nikdy nepoužívejte relace pro autentizaci.
- Předejděte útokům zmateného zástupce vyžadováním explicitního souhlasu uživatele pro každého dynamicky registrovaného klienta a implementací správných bezpečnostních praktik OAuth.
- Vyhněte se zranitelnostem přeposílání tokenů tím, že MCP servery přijímají pouze tokeny výslovně vydané pro ně a správně validují nároky tokenů.
- Všechny komponenty ve vašem AI dodavatelském řetězci – včetně modelů, embeddingů a poskytovatelů kontextu – ošetřujte s stejně přísnou péčí jako závislosti kódu.
- Sledujte aktuální vývoj specifikací MCP a přispívejte komunitě, abyste pomohli formovat bezpečné standardy.

# Další zdroje

## Externí zdroje
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
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
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Další bezpečnostní dokumenty

Pro podrobnější bezpečnostní pokyny se prosím podívejte na tyto dokumenty:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) – Komplexní seznam bezpečnostních nejlepších praktik pro implementace MCP
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) – Příklady implementace integrace Azure Content Safety s MCP servery
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) – Nejnovější bezpečnostní kontroly a techniky pro zabezpečení nasazení MCP
- [MCP Best Practices](./mcp-best-practices.md) – Rychlý referenční průvodce bezpečností MCP

---

## Co dál

Další: [Kapitola 3: Začínáme](../03-GettingStarted/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.