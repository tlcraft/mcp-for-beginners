<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-13T17:01:03+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "cs"
}
-->
# Nejlepší bezpečnostní postupy

Přijetí Model Context Protocolu (MCP) přináší do aplikací založených na umělé inteligenci nové silné možnosti, ale zároveň představuje jedinečné bezpečnostní výzvy, které přesahují tradiční softwarová rizika. Kromě zavedených oblastí, jako je bezpečné programování, princip nejmenších oprávnění a bezpečnost dodavatelského řetězce, čelí MCP a AI pracovní zátěže novým hrozbám, jako jsou prompt injection, otrava nástrojů a dynamické modifikace nástrojů. Tyto rizika mohou vést k úniku dat, narušení soukromí a nechtěnému chování systému, pokud nejsou správně řízena.

Tato lekce se zabývá nejrelevantnějšími bezpečnostními riziky spojenými s MCP — včetně autentizace, autorizace, nadměrných oprávnění, nepřímého prompt injection a zranitelností dodavatelského řetězce — a poskytuje praktická opatření a nejlepší postupy, jak je zmírnit. Naučíte se také, jak využít řešení Microsoftu, jako jsou Prompt Shields, Azure Content Safety a GitHub Advanced Security, k posílení vaší implementace MCP. Pochopením a aplikací těchto opatření můžete výrazně snížit pravděpodobnost bezpečnostního incidentu a zajistit, že vaše AI systémy zůstanou spolehlivé a důvěryhodné.

# Výukové cíle

Na konci této lekce budete schopni:

- Identifikovat a vysvětlit jedinečná bezpečnostní rizika zavedená Model Context Protokolem (MCP), včetně prompt injection, otravy nástrojů, nadměrných oprávnění a zranitelností dodavatelského řetězce.
- Popsat a aplikovat účinná opatření pro zmírnění bezpečnostních rizik MCP, jako je robustní autentizace, princip nejmenších oprávnění, bezpečná správa tokenů a ověřování dodavatelského řetězce.
- Porozumět a využít řešení Microsoftu, jako jsou Prompt Shields, Azure Content Safety a GitHub Advanced Security, k ochraně MCP a AI pracovních zátěží.
- Uvědomit si důležitost validace metadat nástrojů, monitorování dynamických změn a obrany proti nepřímým prompt injection útokům.
- Integrovat zavedené bezpečnostní postupy — jako je bezpečné programování, zpevnění serveru a architektura zero trust — do vaší implementace MCP, aby se snížila pravděpodobnost a dopad bezpečnostních incidentů.

# Bezpečnostní opatření MCP

Každý systém, který má přístup k důležitým zdrojům, čelí implicitním bezpečnostním výzvám. Tyto výzvy lze obecně řešit správnou aplikací základních bezpečnostních opatření a konceptů. Jelikož je MCP teprve nově definován, specifikace se velmi rychle mění a protokol se vyvíjí. Nakonec bezpečnostní opatření v něm obsažená dozrají, což umožní lepší integraci s podnikovými a zavedenými bezpečnostními architekturami a nejlepšími postupy.

Výzkum publikovaný v [Microsoft Digital Defense Report](https://aka.ms/mddr) uvádí, že 98 % hlášených průniků by bylo zabráněno díky robustní bezpečnostní hygieně a nejlepší ochranou proti jakémukoliv průniku je správné nastavení základní bezpečnostní hygieny, osvědčených postupů bezpečného kódování a bezpečnosti dodavatelského řetězce — tyto prověřené postupy stále nejvíce snižují bezpečnostní rizika.

Podívejme se na některé způsoby, jak můžete začít řešit bezpečnostní rizika při zavádění MCP.

> **Note:** Následující informace jsou platné k **29. květnu 2025**. Protokol MCP se neustále vyvíjí a budoucí implementace mohou zavést nové vzory autentizace a kontroly. Pro nejnovější aktualizace a doporučení vždy odkazujte na [MCP Specification](https://spec.modelcontextprotocol.io/) a oficiální [MCP GitHub repository](https://github.com/modelcontextprotocol) a [stránku s nejlepšími bezpečnostními postupy](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problém

Původní specifikace MCP předpokládala, že vývojáři napíší vlastní autentizační server. To vyžadovalo znalosti OAuth a souvisejících bezpečnostních omezení. MCP servery fungovaly jako OAuth 2.0 autorizační servery, které přímo spravovaly požadovanou uživatelskou autentizaci, místo aby ji delegovaly na externí službu, jako je Microsoft Entra ID. Od **26. dubna 2025** aktualizace specifikace MCP umožňuje MCP serverům delegovat autentizaci uživatelů na externí službu.

### Rizika
- Nesprávně nakonfigurovaná autorizační logika na MCP serveru může vést k úniku citlivých dat a nesprávnému uplatnění přístupových práv.
- Krádež OAuth tokenu na lokálním MCP serveru. Pokud je token ukraden, může být použit k vydávání se za MCP server a přístupu k prostředkům a datům služby, pro kterou je token určen.

#### Token Passthrough
Token passthrough je v autorizační specifikaci výslovně zakázán, protože přináší řadu bezpečnostních rizik, mezi která patří:

#### Obcházení bezpečnostních opatření
MCP server nebo downstream API mohou implementovat důležitá bezpečnostní opatření, jako je omezení rychlosti požadavků, validace požadavků nebo monitorování provozu, která závisí na publiku tokenu nebo jiných omezeních přihlašovacích údajů. Pokud klienti mohou získat a používat tokeny přímo s downstream API bez řádné validace MCP serverem nebo bez zajištění, že tokeny jsou vydány pro správnou službu, obcházejí tato opatření.

#### Problémy s odpovědností a auditní stopou
MCP server nebude schopen identifikovat nebo rozlišit mezi MCP klienty, pokud klienti volají s přístupovým tokenem vydaným upstream, který může být pro MCP server neprůhledný. Logy downstream Resource Serveru mohou ukazovat požadavky, které vypadají, že pocházejí z jiného zdroje s jinou identitou, než je MCP server, který tokeny skutečně předává. Oba tyto faktory ztěžují vyšetřování incidentů, kontrolu a audit. Pokud MCP server předává tokeny bez validace jejich nároků (např. rolí, oprávnění nebo publika) či jiných metadat, může útočník s ukradeným tokenem použít server jako proxy pro únik dat.

#### Problémy s hranicí důvěry
Downstream Resource Server důvěřuje konkrétním entitám. Tato důvěra může zahrnovat předpoklady o původu nebo vzorcích chování klienta. Porušení této hranice důvěry může vést k neočekávaným problémům. Pokud je token akceptován více službami bez řádné validace, útočník, který kompromitoval jednu službu, může token použít k přístupu do dalších propojených služeb.

#### Riziko budoucí kompatibility
I když MCP server dnes začíná jako „čistý proxy“, může později potřebovat přidat bezpečnostní opatření. Začít správným oddělením publika tokenů usnadňuje budoucí vývoj bezpečnostního modelu.

### Opatření pro zmírnění rizik

**MCP servery NESMÍ přijímat žádné tokeny, které nebyly výslovně vydány pro MCP server**

- **Zkontrolujte a zpevněte autorizační logiku:** Pečlivě auditujte implementaci autorizace vašeho MCP serveru, aby měli přístup pouze zamýšlení uživatelé a klienti k citlivým zdrojům. Pro praktické rady viz [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) a [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Prosazujte bezpečné praktiky správy tokenů:** Dodržujte [nejlepší postupy Microsoftu pro validaci tokenů a jejich životnost](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), abyste zabránili zneužití přístupových tokenů a snížili riziko opakovaného použití nebo krádeže tokenů.
- **Chraňte ukládání tokenů:** Tokeny vždy ukládejte bezpečně a používejte šifrování k ochraně dat v klidu i při přenosu. Pro tipy na implementaci viz [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadměrná oprávnění pro MCP servery

### Problém

MCP serverům mohla být udělena nadměrná oprávnění k službě nebo zdroji, ke kterému přistupují. Například MCP server, který je součástí AI aplikace prodeje a připojuje se k podnikové datové úložišti, by měl mít přístup omezený pouze na prodejní data a neměl by mít přístup ke všem souborům v úložišti. Vraťme se k principu nejmenších oprávnění (jednomu z nejstarších bezpečnostních principů) — žádný zdroj by neměl mít oprávnění nad rámec toho, co je nezbytné pro vykonání jeho úkolů. AI zde představuje zvýšenou výzvu, protože pro její flexibilitu může být obtížné přesně definovat potřebná oprávnění.

### Rizika
- Udělení nadměrných oprávnění může umožnit únik nebo změnu dat, ke kterým MCP server neměl mít přístup. Může to být také problémem ochrany soukromí, pokud se jedná o osobní identifikovatelné informace (PII).

### Opatření pro zmírnění rizik
- **Uplatňujte princip nejmenších oprávnění:** Udělte MCP serveru pouze minimální oprávnění nezbytná pro vykonání jeho úkolů. Pravidelně přehodnocujte a aktualizujte tato oprávnění, aby nepřesahovala nezbytnou míru. Podrobné pokyny najdete v [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Používejte řízení přístupu na základě rolí (RBAC):** Přiřazujte MCP serveru role, které jsou úzce omezené na konkrétní zdroje a akce, vyhýbejte se širokým nebo zbytečným oprávněním.
- **Monitorujte a auditujte oprávnění:** Průběžně sledujte využívání oprávnění a auditujte přístupové záznamy, abyste rychle odhalili a odstranili nadměrná nebo nevyužívaná oprávnění.

# Nepřímé útoky prompt injection

### Problém

Zlovolné nebo kompromitované MCP servery mohou představovat významná rizika tím, že vystavují zákaznická data nebo umožňují nechtěné akce. Tato rizika jsou zvláště relevantní u AI a MCP založených pracovních zátěží, kde:

- **Útoky prompt injection:** Útočníci vkládají škodlivé instrukce do promptů nebo externího obsahu, což způsobuje, že AI systém provádí nechtěné akce nebo uniká citlivá data. Více informací: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrava nástrojů:** Útočníci manipulují s metadaty nástrojů (například popisy nebo parametry), aby ovlivnili chování AI, potenciálně obcházeli bezpečnostní opatření nebo unikali data. Podrobnosti: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Škodlivé instrukce jsou vloženy do dokumentů, webových stránek nebo e-mailů, které AI zpracovává, což vede k úniku nebo manipulaci s daty.
- **Dynamická modifikace nástrojů (Rug Pulls):** Definice nástrojů mohou být po schválení uživatelem změněny, což zavádí nové škodlivé chování bez vědomí uživatele.

Tyto zranitelnosti zdůrazňují potřebu robustní validace, monitorování a bezpečnostních opatření při integraci MCP serverů a nástrojů do vašeho prostředí. Pro podrobnější informace viz výše uvedené odkazy.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.cs.png)

**Nepřímý prompt injection** (také známý jako cross-domain prompt injection nebo XPIA) je kritická zranitelnost v generativních AI systémech, včetně těch používajících Model Context Protocol (MCP). Při tomto útoku jsou škodlivé instrukce skryty v externím obsahu — například v dokumentech, webových stránkách nebo e-mailech. Když AI systém tento obsah zpracovává, může vložené instrukce interpretovat jako legitimní uživatelské příkazy, což vede k nechtěným akcím, jako je únik dat, generování škodlivého obsahu nebo manipulace s uživatelskými interakcemi. Pro podrobný popis a reálné příklady viz [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Zvlášť nebezpečnou formou tohoto útoku je **otrava nástrojů**. Útočníci zde vkládají škodlivé instrukce do metadat MCP nástrojů (například popisů nebo parametrů). Protože velké jazykové modely (LLM) spoléhají na tato metadata při rozhodování, které nástroje vyvolat, mohou kompromitované popisy oklamat model, aby provedl neoprávněné volání nástrojů nebo obešel bezpečnostní kontroly. Tyto manipulace jsou často pro koncové uživatele neviditelné, ale AI systém je může interpretovat a vykonat. Toto riziko je zvýšené v hostovaných prostředích MCP serverů, kde definice nástrojů mohou být po schválení uživatelem aktualizovány — scénář někdy označovaný jako "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takových případech může být nástroj, který byl dříve bezpečný, později upraven tak, aby prováděl škodlivé akce, jako je únik dat nebo změna chování systému, aniž by o tom uživatel věděl. Více o tomto útoku najdete v [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.cs.png)

## Rizika
Nechtěné akce AI představují různá bezpečnostní rizika, včetně úniku dat a narušení soukromí.

### Opatření pro zmírnění rizik
### Použití prompt shields k ochraně proti nepřímým prompt injection útokům
-----------------------------------------------------------------------------

**AI Prompt Shields** jsou řešení vyvinuté společností Microsoft k obraně proti přímým i nepřímým prompt injection útokům. Pomáhají prostřednictvím:

1.  **Detekce a filtrování:** Prompt Shields využívají pokročilé algoritmy strojového učení a zpracování přirozeného jazyka k detekci a filtrování škodlivých instrukcí vložených v externím obsahu, jako jsou dokumenty, webové stránky nebo e-maily.
    
2.  **Spotlighting:** Tato technika pomáhá AI systému rozlišit platné systémové instrukce od potenciálně nedůvěryhodných externích vstupů. Transformací vstupního textu tak, aby byl pro model relevantnější, Spotlighting zajišťuje, že AI lépe identifikuje a ignoruje škodlivé instrukce.
    
3.  **Oddělovače a datamarking:** Začlenění oddělovačů do systémové zprávy jasně vymezuje umístění vstupního textu, což pomáhá AI systému rozpoznat a oddělit uživatelské vstupy od potenciálně škodlivého externího obsahu. Datamarking rozšiřuje tento koncept použitím speciálních značek k vyznačení hranic důvěryhodných a nedůvěryhodných dat.
    
4.  **Nepřetržité monitorování a aktualizace:** Microsoft průběžně sleduje a aktualizuje
Bezpečnost dodavatelského řetězce zůstává v éře AI zásadní, ale rozsah toho, co tvoří váš dodavatelský řetězec, se rozšířil. Kromě tradičních balíčků kódu je nyní nutné důkladně ověřovat a monitorovat všechny komponenty související s AI, včetně základních modelů, služeb embeddings, poskytovatelů kontextu a API třetích stran. Každý z těchto prvků může představovat zranitelnosti nebo rizika, pokud není správně spravován.

**Klíčové postupy zabezpečení dodavatelského řetězce pro AI a MCP:**
- **Ověřte všechny komponenty před integrací:** To zahrnuje nejen open-source knihovny, ale také AI modely, zdroje dat a externí API. Vždy kontrolujte původ, licencování a známé zranitelnosti.
- **Udržujte bezpečné nasazovací pipeline:** Používejte automatizované CI/CD pipeline s integrovaným bezpečnostním skenováním, abyste problémy odhalili co nejdříve. Zajistěte, že do produkce jsou nasazovány pouze důvěryhodné artefakty.
- **Průběžně monitorujte a auditujte:** Implementujte nepřetržité sledování všech závislostí, včetně modelů a datových služeb, abyste odhalili nové zranitelnosti nebo útoky na dodavatelský řetězec.
- **Používejte princip nejmenších oprávnění a kontrolu přístupu:** Omezte přístup k modelům, datům a službám pouze na nezbytné minimum pro fungování vašeho MCP serveru.
- **Rychle reagujte na hrozby:** Mějte zavedený proces pro záplaty nebo výměnu kompromitovaných komponent a pro rotaci tajemství či přihlašovacích údajů v případě detekce narušení.

[GitHub Advanced Security](https://github.com/security/advanced-security) nabízí funkce jako skenování tajemství, skenování závislostí a analýzu CodeQL. Tyto nástroje se integrují s [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) a [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), aby pomohly týmům identifikovat a zmírnit zranitelnosti jak v kódu, tak v komponentách AI dodavatelského řetězce.

Microsoft také interně uplatňuje rozsáhlé bezpečnostní postupy dodavatelského řetězce pro všechny své produkty. Více se dozvíte v [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Zavedené bezpečnostní postupy, které zlepší bezpečnost vaší implementace MCP

Každá implementace MCP dědí stávající bezpečnostní úroveň prostředí vaší organizace, na kterém je postavena, proto je při zvažování bezpečnosti MCP jako součásti vašich celkových AI systémů doporučeno zlepšit celkovou stávající bezpečnostní úroveň. Následující zavedené bezpečnostní kontroly jsou obzvláště relevantní:

- Bezpečné programování ve vaší AI aplikaci – chraňte se proti [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 pro LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), používejte bezpečné úložiště pro tajemství a tokeny, implementujte end-to-end zabezpečenou komunikaci mezi všemi komponentami aplikace atd.
- Zpevnění serveru – používejte MFA, kde je to možné, udržujte aktualizace záplat, integrujte server s poskytovatelem identity třetí strany pro přístup atd.
- Udržujte zařízení, infrastrukturu a aplikace aktuální s nejnovějšími záplatami
- Bezpečnostní monitoring – implementujte logování a monitorování AI aplikace (včetně MCP klientů/serverů) a odesílejte tyto logy do centrálního SIEM pro detekci anomálií
- Architektura zero trust – izolujte komponenty pomocí síťových a identitních kontrol logickým způsobem, aby se minimalizoval laterální pohyb v případě kompromitace AI aplikace.

# Klíčové poznatky

- Základy bezpečnosti zůstávají klíčové: Bezpečné programování, princip nejmenších oprávnění, ověřování dodavatelského řetězce a nepřetržité monitorování jsou nezbytné pro MCP a AI pracovní zátěže.
- MCP přináší nová rizika – jako je prompt injection, tool poisoning a nadměrná oprávnění – která vyžadují jak tradiční, tak specifické AI kontroly.
- Používejte robustní autentizaci, autorizaci a správu tokenů, ideálně s využitím externích poskytovatelů identity jako Microsoft Entra ID.
- Chraňte se před nepřímým prompt injection a tool poisoning ověřováním metadat nástrojů, monitorováním dynamických změn a používáním řešení jako Microsoft Prompt Shields.
- Všechny komponenty ve vašem AI dodavatelském řetězci – včetně modelů, embeddings a poskytovatelů kontextu – zacházejte s takovou samou pečlivostí jako s kódovými závislostmi.
- Sledujte aktuální vývoj specifikací MCP a přispívejte do komunity, abyste pomohli formovat bezpečné standardy.

# Další zdroje

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

### Další

Další: [Chapter 3: Getting Started](../03-GettingStarted/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.