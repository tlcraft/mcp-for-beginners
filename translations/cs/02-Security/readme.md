<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:49:34+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "cs"
}
-->
# Nejlepší postupy zabezpečení

Přijetí protokolu Model Context Protocol (MCP) přináší do aplikací poháněných AI nové silné schopnosti, ale také zavádí jedinečné bezpečnostní výzvy, které přesahují tradiční softwarová rizika. Kromě zavedených obav, jako je bezpečné kódování, minimální práva a bezpečnost dodavatelského řetězce, čelí MCP a AI pracovní zátěže novým hrozbám, jako je injekce promptů, otrava nástrojů a dynamická modifikace nástrojů. Pokud nejsou správně řízeny, tato rizika mohou vést k exfiltraci dat, porušení soukromí a neúmyslnému chování systému.

Tato lekce zkoumá nejrelevantnější bezpečnostní rizika spojená s MCP—včetně autentizace, autorizace, nadměrných oprávnění, nepřímé injekce promptů a zranitelností dodavatelského řetězce—a poskytuje praktická opatření a nejlepší postupy k jejich zmírnění. Naučíte se také, jak využít řešení Microsoftu, jako jsou Prompt Shields, Azure Content Safety a GitHub Advanced Security, ke zpevnění vaší implementace MCP. Porozuměním a aplikací těchto opatření můžete významně snížit pravděpodobnost bezpečnostního narušení a zajistit, aby vaše AI systémy zůstaly robustní a důvěryhodné.

# Výukové cíle

Na konci této lekce budete schopni:

- Identifikovat a vysvětlit jedinečná bezpečnostní rizika zavedená protokolem Model Context Protocol (MCP), včetně injekce promptů, otravy nástrojů, nadměrných oprávnění a zranitelností dodavatelského řetězce.
- Popsat a aplikovat efektivní opatření k zmírnění bezpečnostních rizik MCP, jako jsou robustní autentizace, minimální práva, bezpečná správa tokenů a ověření dodavatelského řetězce.
- Porozumět a využít řešení Microsoftu, jako jsou Prompt Shields, Azure Content Safety a GitHub Advanced Security, k ochraně MCP a AI pracovní zátěže.
- Rozpoznat důležitost ověřování metadat nástrojů, monitorování dynamických změn a obrany proti nepřímým útokům injekce promptů.
- Integrovat zavedené bezpečnostní nejlepší postupy—jako je bezpečné kódování, zpevnění serverů a architektura nulové důvěry—do vaší implementace MCP, aby se snížila pravděpodobnost a dopad bezpečnostních narušení.

# Opatření bezpečnosti MCP

Každý systém, který má přístup k důležitým zdrojům, má implicitní bezpečnostní výzvy. Bezpečnostní výzvy lze obecně řešit správnou aplikací základních bezpečnostních opatření a konceptů. Protože MCP je teprve nově definován, specifikace se velmi rychle mění a vyvíjí. Nakonec se bezpečnostní opatření v něm vyvinou, což umožní lepší integraci s podnikovými a zavedenými bezpečnostními architekturami a nejlepšími postupy.

Výzkum publikovaný v [Microsoft Digital Defense Report](https://aka.ms/mddr) uvádí, že 98% hlášených narušení by bylo zabráněno robustní hygienou zabezpečení a nejlepší ochranou proti jakémukoli narušení je získat základní hygienu zabezpečení, nejlepší postupy bezpečného kódování a bezpečnost dodavatelského řetězce správně—ty osvědčené postupy, o kterých již víme, stále mají největší dopad na snížení bezpečnostního rizika.

Podívejme se na některé způsoby, jak můžete začít řešit bezpečnostní rizika při přijímání MCP.

# Autentizace serveru MCP (pokud byla vaše implementace MCP před 26. dubnem 2025)

> **Poznámka:** Následující informace jsou správné k 26. dubnu 2025. Protokol MCP se neustále vyvíjí a budoucí implementace mohou zavést nové vzory a opatření autentizace. Pro nejnovější aktualizace a pokyny vždy odkazujte na [Specifikaci MCP](https://spec.modelcontextprotocol.io/) a oficiální [GitHub repozitář MCP](https://github.com/modelcontextprotocol).

### Prohlášení problému 
Původní specifikace MCP předpokládala, že vývojáři napíší svůj vlastní autentizační server. To vyžadovalo znalost OAuth a souvisejících bezpečnostních omezení. Servery MCP fungovaly jako autorizační servery OAuth 2.0, které přímo spravovaly požadovanou autentizaci uživatelů, místo aby ji delegovaly na externí službu, jako je Microsoft Entra ID. Od 26. dubna 2025 aktualizace specifikace MCP umožňuje serverům MCP delegovat autentizaci uživatelů na externí službu.

### Rizika
- Špatně nakonfigurovaná logika autorizace na serveru MCP může vést k expozici citlivých dat a nesprávně aplikovaným kontrolám přístupu.
- Krádež tokenu OAuth na místním serveru MCP. Pokud je token ukraden, může být použit k vydávání se za server MCP a přístupu ke zdrojům a datům ze služby, pro kterou je token OAuth určen.

### Opatření k zmírnění
- **Revize a zpevnění logiky autorizace:** Pečlivě auditujte implementaci autorizace vašeho serveru MCP, abyste zajistili, že pouze zamýšlení uživatelé a klienti mají přístup k citlivým zdrojům. Pro praktické pokyny viz [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) a [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Prosazování bezpečných praktik tokenů:** Dodržujte [nejlepší postupy Microsoftu pro validaci tokenů a jejich životnost](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), abyste zabránili zneužití přístupových tokenů a snížili riziko opakování nebo krádeže tokenů.
- **Ochrana úložiště tokenů:** Vždy ukládejte tokeny bezpečně a používejte šifrování k jejich ochraně v klidu i během přenosu. Pro tipy k implementaci viz [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadměrná oprávnění pro servery MCP

### Prohlášení problému
Servery MCP mohly být nadměrně oprávněny ke službě/zdroji, ke kterému mají přístup. Například server MCP, který je součástí AI aplikace prodeje, připojující se k podnikovému datovému úložišti, by měl mít přístup omezený na prodejní data a neměl by mít povolený přístup ke všem souborům v úložišti. Odkazování zpět na princip minimálních práv (jeden z nejstarších bezpečnostních principů), žádný zdroj by neměl mít oprávnění přesahující to, co je vyžadováno pro provedení úkolů, pro které byl zamýšlen. AI představuje zvýšenou výzvu v této oblasti, protože umožňuje flexibilitu, je náročné definovat přesná potřebná oprávnění.

### Rizika 
- Poskytnutí nadměrných oprávnění může umožnit exfiltraci nebo úpravu dat, ke kterým server MCP neměl mít přístup. To může být také problémem soukromí, pokud jsou data osobně identifikovatelné informace (PII).

### Opatření k zmírnění
- **Aplikujte princip minimálních práv:** Poskytněte serveru MCP pouze minimální oprávnění nezbytná pro provedení jeho požadovaných úkolů. Pravidelně revidujte a aktualizujte tato oprávnění, aby nepřesahovala to, co je potřeba. Pro podrobné pokyny viz [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Používejte řízení přístupu založené na rolích (RBAC):** Přidělte role serveru MCP, které jsou úzce vymezeny na konkrétní zdroje a akce, vyhýbajíce se širokým nebo zbytečným oprávněním.
- **Monitorujte a auditujte oprávnění:** Nepřetržitě monitorujte používání oprávnění a auditujte přístupové logy, abyste rychle detekovali a napravili nadměrné nebo nevyužité oprávnění.

# Nepřímé útoky injekce promptů

### Prohlášení problému

Zlý nebo kompromitovaný servery MCP mohou představovat významná rizika tím, že vystavují zákaznická data nebo umožňují neúmyslné akce. Tato rizika jsou obzvláště relevantní v pracovních zátěžích založených na AI a MCP, kde:

- **Útoky injekce promptů**: Útočníci vkládají zlomyslné instrukce do promptů nebo externího obsahu, což způsobuje, že AI systém provádí neúmyslné akce nebo uniká citlivá data. Více informací: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrava nástrojů**: Útočníci manipulují metadata nástrojů (například popisy nebo parametry) k ovlivnění chování AI, potenciálně obejít bezpečnostní opatření nebo exfiltrovat data. Podrobnosti: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Zlomyslné instrukce jsou vloženy do dokumentů, webových stránek nebo e-mailů, které jsou následně zpracovány AI, což vede k úniku dat nebo manipulaci.
- **Dynamická modifikace nástrojů (Rug Pulls)**: Definice nástrojů mohou být změněny po schválení uživatelem, což zavádí nové zlomyslné chování bez vědomí uživatele.

Tyto zranitelnosti zdůrazňují potřebu robustního ověřování, monitorování a bezpečnostních opatření při integraci serverů MCP a nástrojů do vašeho prostředí. Pro hlubší pohled viz odkazy výše.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.cs.png)

**Nepřímá injekce promptů** (také známá jako injekce promptů napříč doménami nebo XPIA) je kritická zranitelnost v generativních AI systémech, včetně těch, které používají protokol Model Context Protocol (MCP). V tomto útoku jsou zlomyslné instrukce skryty v externím obsahu—jako jsou dokumenty, webové stránky nebo e-maily. Když AI systém zpracovává tento obsah, může interpretovat vložené instrukce jako legitimní uživatelské příkazy, což vede k neúmyslným akcím, jako je únik dat, generování škodlivého obsahu nebo manipulace uživatelských interakcí. Pro podrobné vysvětlení a příklady ze skutečného světa viz [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Zvláště nebezpečnou formou tohoto útoku je **Otrava nástrojů**. Zde útočníci vkládají zlomyslné instrukce do metadat nástrojů MCP (například popisy nástrojů nebo parametry). Vzhledem k tomu, že velké jazykové modely (LLMs) spoléhají na tato metadata při rozhodování, které nástroje použít, kompromitované popisy mohou oklamat model, aby prováděl neoprávněné volání nástrojů nebo obcházel bezpečnostní opatření. Tyto manipulace jsou často neviditelné pro koncové uživatele, ale mohou být interpretovány a vykonány AI systémem. Toto riziko je zvýšeno v prostředích hostovaných serverů MCP, kde definice nástrojů mohou být aktualizovány po schválení uživatelem—scénář někdy nazývaný "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takových případech může být nástroj, který byl dříve bezpečný, později upraven tak, aby prováděl zlomyslné akce, jako je exfiltrace dat nebo změna chování systému, bez vědomí uživatele. Pro více informací o tomto vektoru útoku viz [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.cs.png)

## Rizika
Neúmyslné akce AI představují různé bezpečnostní rizika, která zahrnují exfiltraci dat a porušení soukromí.

### Opatření k zmírnění
### Použití prompt shields k ochraně proti nepřímým útokům injekce promptů
-----------------------------------------------------------------------------

**AI Prompt Shields** jsou řešení vyvinuté společností Microsoft na obranu proti přímým i nepřímým útokům injekce promptů. Pomáhají prostřednictvím:

1. **Detekce a filtrování**: Prompt Shields používají pokročilé algoritmy strojového učení a zpracování přirozeného jazyka k detekci a filtrování zlomyslných instrukcí vložených do externího obsahu, jako jsou dokumenty, webové stránky nebo e-maily.
    
2. **Spotlighting**: Tato technika pomáhá AI systému rozlišovat mezi platnými systémovými instrukcemi a potenciálně nedůvěryhodnými externími vstupy. Transformací vstupního textu způsobem, který je pro model relevantnější, Spotlighting zajišťuje, že AI může lépe identifikovat a ignorovat zlomyslné instrukce.
    
3. **Oddělovače a datové označování**: Zahrnutí oddělovačů do systémové zprávy explicitně vymezuje umístění vstupního textu, což pomáhá AI systému rozpoznat a oddělit uživatelské vstupy od potenciálně škodlivého externího obsahu. Datové označování rozšiřuje tento koncept pomocí speciálních markerů k vyznačení hranic důvěryhodných a nedůvěryhodných dat.
    
4. **Nepřetržité monitorování a aktualizace**: Microsoft nepřetržitě monitoruje a aktualizuje Prompt Shields, aby řešil nové a vyvíjející se hrozby. Tento proaktivní přístup zajišťuje, že obrana zůstává účinná proti nejnovějším technikám útoku.
    
5. **Integrace s Azure Content Safety:** Prompt Shields jsou součástí širšího balíčku Azure AI Content Safety, který poskytuje další nástroje pro detekci pokusů o jailbreak, škodlivého obsahu a dalších bezpečnostních rizik v AI aplikacích.

Můžete si přečíst více o AI prompt shields v [dokumentaci Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.cs.png)

### Bezpečnost dodavatelského řetězce

Bezpečnost dodavatelského řetězce zůstává základní v éře AI, ale rozsah toho, co tvoří váš dodavatelský řetězec, se rozšířil. Kromě tradičních balíčků kódu musíte nyní důkladně ověřovat a monitorovat všechny komponenty související s AI, včetně základních modelů, služeb embeddingů, poskytovatelů kontextu a API třetích stran. Každý z nich může zavést zranitelnosti nebo rizika, pokud nejsou správně řízeny.

**Klíčové praktiky bezpečnosti dodavatelského řetězce pro AI a MCP:**
- **Ověřte všechny komponenty před integrací:** To zahrnuje nejen open-source knihovny, ale také AI modely, zdroje dat a externí API. Vždy kontrolujte původ, licencování a známé zranitelnosti.
- **Udržujte bezpečné nasazovací kanály:** Používejte automatizované CI/CD kanály s integrovaným bezpečnostním skenováním k zachycení problémů včas. Zajistěte, že do produkce jsou nasazovány pouze důvěryhodné artefakty.
- **Nepřetržitě monitorujte a auditujte:** Implementujte nepřetržité monitorování všech závislost
- [OWASP Top 10 pro LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [Pokročilá bezpečnost na GitHubu](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Cesta k zabezpečení softwarového dodavatelského řetězce v Microsoftu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Zabezpečený přístup s minimálními oprávněními (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Nejlepší postupy pro validaci tokenů a jejich životnost](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Používání bezpečného úložiště tokenů a jejich šifrování (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management jako autentizační brána pro MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Používání Microsoft Entra ID k autentizaci s MCP servery](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Další 

Další: [Kapitola 3: Začínáme](/03-GettingStarted/README.md)

**Upozornění**:  
Tento dokument byl přeložen pomocí AI překladové služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, vezměte prosím na vědomí, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za závazný zdroj. Pro kritické informace je doporučen profesionální lidský překlad. Nejsme zodpovědní za jakékoli nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.