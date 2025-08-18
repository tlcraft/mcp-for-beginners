<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1c767a35642f753127dc08545c25a290",
  "translation_date": "2025-08-18T19:55:57+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "cs"
}
-->
# MCP Bezpečnost: Komplexní ochrana pro AI systémy

[![MCP Bezpečnostní postupy](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.cs.png)](https://youtu.be/88No8pw706o)

_(Klikněte na obrázek výše pro zhlédnutí videa této lekce)_

Bezpečnost je základním kamenem návrhu AI systémů, a proto ji zařazujeme jako druhou sekci. To odpovídá principu Microsoftu **Secure by Design** z [Secure Future Initiative](https://www.microsoft.com/security/blog/2025/04/17/microsofts-secure-by-design-journey-one-year-of-success/).

Model Context Protocol (MCP) přináší nové výkonné schopnosti pro aplikace poháněné AI, ale zároveň zavádí unikátní bezpečnostní výzvy, které přesahují tradiční softwarová rizika. MCP systémy čelí jak zavedeným bezpečnostním problémům (bezpečné kódování, princip minimálních oprávnění, bezpečnost dodavatelského řetězce), tak novým hrozbám specifickým pro AI, jako jsou injekce promptů, otrava nástrojů, únosy relací, útoky zmateného zástupce, zranitelnosti při předávání tokenů a dynamické úpravy schopností.

Tato lekce se zaměřuje na nejkritičtější bezpečnostní rizika při implementaci MCP—zahrnuje autentizaci, autorizaci, nadměrná oprávnění, nepřímé injekce promptů, bezpečnost relací, problémy zmateného zástupce, správu tokenů a zranitelnosti dodavatelského řetězce. Naučíte se praktická opatření a osvědčené postupy pro zmírnění těchto rizik a využití řešení Microsoftu, jako jsou Prompt Shields, Azure Content Safety a GitHub Advanced Security, pro posílení vašeho MCP nasazení.

## Cíle učení

Na konci této lekce budete schopni:

- **Identifikovat hrozby specifické pro MCP**: Rozpoznat unikátní bezpečnostní rizika v MCP systémech, včetně injekce promptů, otravy nástrojů, nadměrných oprávnění, únosů relací, problémů zmateného zástupce, zranitelností při předávání tokenů a rizik dodavatelského řetězce
- **Aplikovat bezpečnostní opatření**: Implementovat efektivní mitigace, včetně robustní autentizace, přístupu s minimálními oprávněními, bezpečné správy tokenů, kontrol bezpečnosti relací a ověřování dodavatelského řetězce
- **Využít bezpečnostní řešení Microsoftu**: Porozumět a nasadit Microsoft Prompt Shields, Azure Content Safety a GitHub Advanced Security pro ochranu MCP pracovních zátěží
- **Ověřit bezpečnost nástrojů**: Rozpoznat důležitost validace metadat nástrojů, monitorování dynamických změn a obrany proti nepřímým injekcím promptů
- **Integrovat osvědčené postupy**: Kombinovat zavedené bezpečnostní základy (bezpečné kódování, zpevnění serverů, zero trust) s opatřeními specifickými pro MCP pro komplexní ochranu

# MCP Bezpečnostní architektura a opatření

Moderní implementace MCP vyžadují vrstvené bezpečnostní přístupy, které řeší jak tradiční softwarovou bezpečnost, tak hrozby specifické pro AI. Rychle se vyvíjející specifikace MCP nadále zdokonaluje své bezpečnostní mechanismy, což umožňuje lepší integraci s podnikovými bezpečnostními architekturami a zavedenými osvědčenými postupy.

Výzkum z [Microsoft Digital Defense Report](https://aka.ms/mddr) ukazuje, že **98 % hlášených narušení by bylo možné předejít robustní bezpečnostní hygienou**. Nejúčinnější ochranná strategie kombinuje základní bezpečnostní postupy s opatřeními specifickými pro MCP—osvědčená základní bezpečnostní opatření zůstávají nejúčinnější při snižování celkového bezpečnostního rizika.

## Současná bezpečnostní situace

> **Poznámka:** Tyto informace odrážejí bezpečnostní standardy MCP k datu **18. srpna 2025**. Specifikace MCP se rychle vyvíjí a budoucí implementace mohou zavést nové autentizační vzory a vylepšené mechanismy. Vždy se odkazujte na aktuální [Specifikaci MCP](https://spec.modelcontextprotocol.io/), [GitHub repozitář MCP](https://github.com/modelcontextprotocol) a [dokumentaci osvědčených bezpečnostních postupů](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) pro nejnovější pokyny.

### Vývoj autentizace MCP

Specifikace MCP se významně vyvinula ve svém přístupu k autentizaci a autorizaci:

- **Původní přístup**: Rané specifikace vyžadovaly, aby vývojáři implementovali vlastní autentizační servery, přičemž MCP servery fungovaly jako OAuth 2.0 autorizační servery, které přímo spravovaly autentizaci uživatelů
- **Současný standard (2025-06-18)**: Aktualizovaná specifikace umožňuje MCP serverům delegovat autentizaci na externí poskytovatele identity (například Microsoft Entra ID), což zlepšuje bezpečnostní postoj a snižuje složitost implementace
- **Transportní vrstva zabezpečení**: Rozšířená podpora pro bezpečné transportní mechanismy s odpovídajícími autentizačními vzory pro lokální (STDIO) i vzdálené (Streamable HTTP) připojení

## Bezpečnost autentizace a autorizace

### Současné bezpečnostní výzvy

Moderní implementace MCP čelí několika výzvám v oblasti autentizace a autorizace:

### Rizika a vektory hrozeb

- **Chybně nakonfigurovaná logika autorizace**: Chybná implementace autorizace v MCP serverech může odhalit citlivá data a nesprávně aplikovat přístupové kontroly
- **Kompromitace OAuth tokenů**: Krádež tokenů lokálního MCP serveru umožňuje útočníkům vydávat se za servery a přistupovat ke službám
- **Zranitelnosti při předávání tokenů**: Nesprávná manipulace s tokeny vytváří obcházení bezpečnostních kontrol a mezery v odpovědnosti
- **Nadměrná oprávnění**: MCP servery s příliš velkými oprávněními porušují princip minimálních oprávnění a rozšiřují útočné plochy

#### Předávání tokenů: Kritický anti-vzor

**Předávání tokenů je výslovně zakázáno** v aktuální specifikaci autorizace MCP kvůli závažným bezpečnostním důsledkům:

##### Obcházení bezpečnostních kontrol
- MCP servery a downstream API implementují kritické bezpečnostní kontroly (omezení rychlosti, validace požadavků, monitorování provozu), které závisí na správné validaci tokenů
- Přímé použití tokenů klientem vůči API obchází tyto zásadní ochrany, což podkopává bezpečnostní architekturu

##### Problémy s odpovědností a auditem  
- MCP servery nemohou rozlišit mezi klienty používajícími tokeny vydané upstream, což narušuje auditní stopy
- Logy downstream serverů ukazují zavádějící původ požadavků místo skutečných prostředníků MCP serverů
- Vyšetřování incidentů a audity souladu se stávají výrazně obtížnějšími

##### Rizika exfiltrace dat
- Neověřené nároky tokenů umožňují škodlivým aktérům s odcizenými tokeny používat MCP servery jako proxy pro exfiltraci dat
- Porušení důvěryhodných hranic umožňuje neoprávněné přístupové vzory, které obcházejí zamýšlené bezpečnostní kontroly

##### Útočné vektory mezi službami
- Kompromitované tokeny přijímané více službami umožňují laterální pohyb napříč propojenými systémy
- Důvěryhodné předpoklady mezi službami mohou být porušeny, když nelze ověřit původ tokenů

### Bezpečnostní opatření a mitigace

**Kritické bezpečnostní požadavky:**

> **POVINNÉ**: MCP servery **NESMÍ** přijímat žádné tokeny, které nebyly výslovně vydány pro MCP server

#### Opatření pro autentizaci a autorizaci

- **Důkladná revize autorizace**: Proveďte komplexní audity logiky autorizace MCP serverů, abyste zajistili, že citlivé zdroje mohou přistupovat pouze zamýšlení uživatelé a klienti
  - **Průvodce implementací**: [Azure API Management jako autentizační brána pro MCP servery](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
  - **Integrace identity**: [Použití Microsoft Entra ID pro autentizaci MCP serverů](https://den.dev/blog/mcp-server-auth-entra-id-session/)

- **Bezpečná správa tokenů**: Implementujte [Microsoftovy osvědčené postupy pro validaci a životní cyklus tokenů](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)
  - Validujte nároky tokenů, aby odpovídaly identitě MCP serveru
  - Implementujte správnou rotaci a expirační politiky tokenů
  - Zabraňte útokům na opakované použití tokenů a neoprávněnému použití

- **Chráněné úložiště tokenů**: Zabezpečte úložiště tokenů šifrováním jak v klidu, tak během přenosu
  - **Osvědčené postupy**: [Pokyny pro zabezpečené úložiště a šifrování tokenů](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

#### Implementace přístupových kontrol

- **Princip minimálních oprávnění**: Udělujte MCP serverům pouze minimální oprávnění potřebná pro zamýšlenou funkčnost
  - Pravidelné revize a aktualizace oprávnění, aby se zabránilo jejich rozšiřování
  - **Dokumentace Microsoftu**: [Zabezpečený přístup s minimálními oprávněními](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)

- **Role-Based Access Control (RBAC)**: Implementujte jemně odstupňované přiřazení rolí
  - Role omezte na konkrétní zdroje a akce
  - Vyhněte se širokým nebo zbytečným oprávněním, která rozšiřují útočné plochy

- **Nepřetržité monitorování oprávnění**: Implementujte průběžné audity a monitorování přístupu
  - Sledujte vzory používání oprávnění pro anomálie
  - Okamžitě napravte nadměrná nebo nepoužívaná oprávnění

## Hrozby specifické pro AI

### Útoky injekcí promptů a manipulace s nástroji

Moderní implementace MCP čelí sofistikovaným útokům specifickým pro AI, které tradiční bezpečnostní opatření nemohou plně řešit:

#### **Nepřímá injekce promptů (Cross-Domain Prompt Injection)**

**Nepřímá injekce promptů** představuje jednu z nejkritičtějších zranitelností v AI systémech podporovaných MCP. Útočníci vkládají škodlivé instrukce do externího obsahu—dokumentů, webových stránek, e-mailů nebo datových zdrojů—které AI systémy následně zpracovávají jako legitimní příkazy.

**Scénáře útoků:**
- **Injekce na základě dokumentů**: Škodlivé instrukce skryté v zpracovávaných dokumentech, které spouštějí nechtěné akce AI
- **Zneužití webového obsahu**: Kompromitované webové stránky obsahující vložené prompty, které manipulují chování AI při jejich scrapování
- **Útoky na bázi e-mailů**: Škodlivé prompty v e-mailech, které způsobují únik informací nebo provádění neoprávněných akcí
- **Kontaminace datových zdrojů**: Kompromitované databáze nebo API poskytující znečištěný obsah AI systémům

**Dopad v reálném světě**: Tyto útoky mohou vést k exfiltraci dat, narušení soukromí, generování škodlivého obsahu a manipulaci uživatelských interakcí. Pro podrobnou analýzu viz [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

![Diagram útoku injekce promptů](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.cs.png)

#### **Útoky na otravu nástrojů**

**Otrava nástrojů** cílí na metadata, která definují MCP nástroje, a zneužívá způsob, jakým LLM interpretují popisy nástrojů a parametry pro rozhodování o jejich provádění.

**Mechanismy útoku:**
- **Manipulace metadat**: Útočníci vkládají škodlivé instrukce do popisů nástrojů, definic parametrů nebo příkladů použití
- **Neviditelné instrukce**: Skryté prompty v metadatech nástrojů, které jsou zpracovávány AI modely, ale neviditelné pro lidské uživatele
- **Dynamická úprava nástrojů ("Rug Pulls")**: Nástroje schválené uživateli jsou později upraveny tak, aby prováděly škodlivé akce bez vědomí uživatele
- **Injekce parametrů**: Škodlivý obsah vložený do schémat parametrů nástrojů, který ovlivňuje chování modelu

**Rizika hostovaných serverů**: Vzdálené MCP servery představují zvýšená rizika, protože definice nástrojů mohou být aktualizovány po počátečním schválení uživatelem, což vytváří scénáře, kdy se dříve bezpečné nástroje stanou škodlivými. Pro komplexní analýzu viz [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![Diagram útoku injekce nástrojů](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.cs.png)

#### **Další útočné vektory specifické pro AI**

- **Cross-Domain Prompt Injection (XPIA)**: Sofistikované útoky využívající obsah z více domén k obcházení bezpečnostních kontrol
- **Dynamická úprava schopností**: Změny schopností nástrojů v reálném čase, které unikají počátečním bezpečnostním hodnocením
- **Kontaminace kontextového okna**: Útoky manipulující velká kontextová okna k ukrytí škodlivých instrukcí
- **Útoky na zmatení modelu**: Zneužití omezení modelu k vytvoření nepředvídatelného nebo nebezpečného chování

### Dopad bezpečnostních rizik AI

**Důsledky s vysokým dopadem:**
- **Exfiltrace dat**: Neoprávněný přístup a krádež citlivých podnikových nebo osobních dat
- **Narušení soukromí**: Odhalení osobně identifikovatelných informací (PII) a důvěrných obchodních dat  
- **Manipulace systémů**: Nezamýšlené úpravy kritických systémů a pracovních postupů
- **Krádež přihlašovacích údajů**: Kompromitace autentizačních tokenů a přístupových údajů ke službám
- **Laterální pohyb**: Použití kompromitovaných AI systémů jako výchozích bodů pro širší síťové útoky

### Bezpečnostní řešení Microsoftu pro AI

#### **AI Prompt Shields: Pokročilá ochrana proti injekčním útokům**

Microsoft **AI Prompt Shields** poskytují komplexní obranu proti přímým i nepřímým injekčním útokům prostřednictvím více bezpečnostních vrstev:

##### **Základní ochranné mechanismy:**

1. **Pokročilá detekce a filtrování**
   - Algoritmy strojového učení a NLP techniky detekují škodlivé instrukce v externím obsahu
   - Analýza dokumentů, webových stránek, e-mailů a datových zdrojů v reálném čase
- **Generování bezpečných relací**: Používejte kryptograficky bezpečné, nedeterministické ID relací generované pomocí bezpečných generátorů náhodných čísel  
- **Vazba na uživatele**: Spojte ID relací s informacemi specifickými pro uživatele pomocí formátů jako `<user_id>:<session_id>` pro prevenci zneužití relací mezi uživateli  
- **Správa životního cyklu relací**: Implementujte správné vypršení platnosti, rotaci a zneplatnění relací pro omezení zranitelnosti  
- **Bezpečnost přenosu**: Povinné použití HTTPS pro veškerou komunikaci, aby se zabránilo odposlechu ID relací  

### Problém zmateného zástupce  

**Problém zmateného zástupce** nastává, když servery MCP fungují jako autentizační proxy mezi klienty a službami třetích stran, což vytváří příležitosti pro obcházení autorizace prostřednictvím zneužití statických ID klientů.  

#### **Mechanika útoků a rizika**  

- **Obcházení souhlasu pomocí cookies**: Předchozí autentizace uživatele vytváří cookies souhlasu, které útočníci zneužívají prostřednictvím škodlivých požadavků na autorizaci s upravenými URI přesměrování  
- **Krádež autorizačního kódu**: Existující cookies souhlasu mohou způsobit, že autorizační servery přeskočí obrazovky souhlasu a přesměrují kódy na koncové body ovládané útočníkem  
- **Neoprávněný přístup k API**: Ukradené autorizační kódy umožňují výměnu tokenů a vydávání se za uživatele bez explicitního schválení  

#### **Strategie zmírnění**  

**Povinné kontroly:**  
- **Požadavek na explicitní souhlas**: Proxy servery MCP používající statická ID klientů **MUSÍ** získat souhlas uživatele pro každého dynamicky registrovaného klienta  
- **Implementace bezpečnosti OAuth 2.1**: Dodržujte aktuální bezpečnostní postupy OAuth, včetně PKCE (Proof Key for Code Exchange) pro všechny požadavky na autorizaci  
- **Přísná validace klientů**: Implementujte důkladnou validaci URI přesměrování a identifikátorů klientů, aby se zabránilo zneužití  

### Zranitelnosti při předávání tokenů  

**Předávání tokenů** představuje explicitní anti-pattern, kdy servery MCP přijímají tokeny klientů bez řádné validace a předávají je downstream API, čímž porušují specifikace autorizace MCP.  

#### **Bezpečnostní důsledky**  

- **Obcházení kontrol**: Přímé použití tokenů klientů vůči API obchází klíčové kontroly, jako je omezení rychlosti, validace a monitorování  
- **Narušení auditní stopy**: Tokeny vydané upstream znemožňují identifikaci klientů, což narušuje schopnosti vyšetřování incidentů  
- **Proxy pro exfiltraci dat**: Nevalidované tokeny umožňují škodlivým aktérům používat servery jako proxy pro neoprávněný přístup k datům  
- **Porušení hranic důvěry**: Předpoklady důvěry downstream služeb mohou být porušeny, pokud nelze ověřit původ tokenů  
- **Rozšíření útoků na více služeb**: Kompromitované tokeny přijímané napříč více službami umožňují laterální pohyb  

#### **Požadované bezpečnostní kontroly**  

**Nepostradatelné požadavky:**  
- **Validace tokenů**: Servery MCP **NESMÍ** přijímat tokeny, které nebyly explicitně vydány pro server MCP  
- **Ověření publika**: Vždy ověřujte, že tvrzení o publiku tokenů odpovídají identitě serveru MCP  
- **Správný životní cyklus tokenů**: Implementujte krátkodobé přístupové tokeny s bezpečnými postupy rotace  

## Bezpečnost dodavatelského řetězce pro AI systémy  

Bezpečnost dodavatelského řetězce se rozšířila nad rámec tradičních softwarových závislostí a zahrnuje celý ekosystém AI. Moderní implementace MCP musí důsledně ověřovat a monitorovat všechny komponenty související s AI, protože každá z nich představuje potenciální zranitelnost, která by mohla ohrozit integritu systému.  

### Rozšířené komponenty dodavatelského řetězce AI  

**Tradiční softwarové závislosti:**  
- Open-source knihovny a frameworky  
- Obrazové soubory kontejnerů a základní systémy  
- Vývojové nástroje a buildovací pipeline  
- Komponenty infrastruktury a služby  

**AI-specifické prvky dodavatelského řetězce:**  
- **Základní modely**: Předtrénované modely od různých poskytovatelů vyžadující ověření původu  
- **Embeddingové služby**: Externí služby pro vektorizaci a sémantické vyhledávání  
- **Poskytovatelé kontextu**: Datové zdroje, znalostní báze a repozitáře dokumentů  
- **API třetích stran**: Externí AI služby, ML pipeline a koncové body pro zpracování dat  
- **Artefakty modelů**: Váhy, konfigurace a varianty modelů upravené na míru  
- **Zdrojové tréninkové data**: Datové sady použité pro trénink a doladění modelů  

### Komplexní strategie bezpečnosti dodavatelského řetězce  

#### **Ověření komponent a důvěra**  
- **Ověření původu**: Ověřte původ, licencování a integritu všech AI komponent před integrací  
- **Bezpečnostní hodnocení**: Provádějte skenování zranitelností a bezpečnostní přezkumy modelů, datových zdrojů a AI služeb  
- **Analýza reputace**: Hodnoťte bezpečnostní historii a postupy poskytovatelů AI služeb  
- **Ověření souladu**: Zajistěte, aby všechny komponenty splňovaly bezpečnostní a regulační požadavky organizace  

#### **Bezpečné nasazovací pipeline**  
- **Automatizovaná bezpečnost CI/CD**: Integrujte skenování bezpečnosti do automatizovaných pipeline nasazení  
- **Integrita artefaktů**: Implementujte kryptografické ověření všech nasazených artefaktů (kód, modely, konfigurace)  
- **Postupné nasazení**: Používejte progresivní strategie nasazení s bezpečnostní validací na každé úrovni  
- **Důvěryhodné repozitáře artefaktů**: Nasazujte pouze z ověřených, bezpečných registrů a repozitářů artefaktů  

#### **Nepřetržité monitorování a reakce**  
- **Skenování závislostí**: Průběžné monitorování zranitelností všech softwarových a AI komponent  
- **Monitorování modelů**: Nepřetržité hodnocení chování modelů, výkonových odchylek a bezpečnostních anomálií  
- **Sledování zdraví služeb**: Monitorování externích AI služeb z hlediska dostupnosti, bezpečnostních incidentů a změn politik  
- **Integrace hrozeb**: Zahrnutí zdrojů hrozeb specifických pro AI a ML bezpečnostní rizika  

#### **Kontrola přístupu a princip minimálních oprávnění**  
- **Oprávnění na úrovni komponent**: Omezte přístup k modelům, datům a službám na základě obchodní nutnosti  
- **Správa účtů služeb**: Implementujte dedikované účty služeb s minimálními požadovanými oprávněními  
- **Segmentace sítě**: Izolujte AI komponenty a omezte síťový přístup mezi službami  
- **Kontroly API brány**: Používejte centralizované API brány pro kontrolu a monitorování přístupu k externím AI službám  

#### **Reakce na incidenty a obnova**  
- **Postupy rychlé reakce**: Zavedené procesy pro záplatování nebo nahrazení kompromitovaných AI komponent  
- **Rotace přihlašovacích údajů**: Automatizované systémy pro rotaci tajných klíčů, API klíčů a přihlašovacích údajů služeb  
- **Schopnosti rollbacku**: Možnost rychlého návratu k předchozím známým dobrým verzím AI komponent  
- **Obnova po narušení dodavatelského řetězce**: Specifické postupy pro reakci na kompromitace upstream AI služeb  

### Microsoft Security Tools & Integrace  

**GitHub Advanced Security** poskytuje komplexní ochranu dodavatelského řetězce včetně:  
- **Skenování tajných klíčů**: Automatizovaná detekce přihlašovacích údajů, API klíčů a tokenů v repozitářích  
- **Skenování závislostí**: Hodnocení zranitelností open-source závislostí a knihoven  
- **Analýza CodeQL**: Statická analýza kódu pro bezpečnostní zranitelnosti a problémy v kódování  
- **Přehled dodavatelského řetězce**: Viditelnost zdraví a bezpečnostního stavu závislostí  

**Integrace Azure DevOps & Azure Repos:**  
- Bezproblémová integrace skenování bezpečnosti napříč vývojovými platformami Microsoftu  
- Automatizované bezpečnostní kontroly v Azure Pipelines pro AI pracovní zátěže  
- Prosazování politik pro bezpečné nasazení AI komponent  

**Interní postupy Microsoftu:**  
Microsoft implementuje rozsáhlé postupy bezpečnosti dodavatelského řetězce napříč všemi produkty. Více o osvědčených přístupech se dozvíte v [Cesta k zabezpečení softwarového dodavatelského řetězce v Microsoftu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).  

## Základní bezpečnostní postupy  

Implementace MCP dědí a staví na existující bezpečnostní pozici vaší organizace. Posílení základních bezpečnostních postupů významně zvyšuje celkovou bezpečnost AI systémů a nasazení MCP.  

### Základní bezpečnostní principy  

#### **Bezpečné vývojové postupy**  
- **Soulad s OWASP**: Chraňte se proti [OWASP Top 10](https://owasp.org/www-project-top-ten/) zranitelnostem webových aplikací  
- **Ochrany specifické pro AI**: Implementujte kontroly pro [OWASP Top 10 pro LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)  
- **Bezpečná správa tajných klíčů**: Používejte dedikované trezory pro tokeny, API klíče a citlivá konfigurační data  
- **Šifrování end-to-end**: Implementujte bezpečnou komunikaci napříč všemi komponentami aplikace a datovými toky  
- **Validace vstupů**: Důkladná validace všech uživatelských vstupů, parametrů API a datových zdrojů  

#### **Zpevnění infrastruktury**  
- **Vícefaktorová autentizace**: Povinné MFA pro všechny administrativní a servisní účty  
- **Správa záplat**: Automatizované, včasné záplatování operačních systémů, frameworků a závislostí  
- **Integrace poskytovatele identity**: Centralizovaná správa identit prostřednictvím podnikových poskytovatelů identit (Microsoft Entra ID, Active Directory)  
- **Segmentace sítě**: Logická izolace komponent MCP pro omezení potenciálu laterálního pohybu  
- **Princip minimálních oprávnění**: Minimální požadovaná oprávnění pro všechny systémové komponenty a účty  

#### **Monitorování bezpečnosti a detekce**  
- **Komplexní logování**: Podrobné logování aktivit AI aplikací, včetně interakcí klient-server MCP  
- **Integrace SIEM**: Centralizované řízení informací o bezpečnosti a událostech pro detekci anomálií  
- **Behaviorální analytika**: Monitorování poháněné AI pro detekci neobvyklých vzorců v chování systému a uživatelů  
- **Inteligence hrozeb**: Integrace externích zdrojů hrozeb a indikátorů kompromitace (IOCs)  
- **Reakce na incidenty**: Dobře definované postupy pro detekci, reakci a obnovu při bezpečnostních incidentech  

#### **Architektura Zero Trust**  
- **Nikdy nedůvěřuj, vždy ověřuj**: Nepřetržité ověřování uživatelů, zařízení a síťových připojení  
- **Mikro-segmentace**: Granulární síťové kontroly, které izolují jednotlivé pracovní zátěže a služby  
- **Bezpečnost zaměřená na identitu**: Bezpečnostní politiky založené na ověřených identitách místo síťové lokace  
- **Nepřetržité hodnocení rizik**: Dynamické hodnocení bezpečnostní pozice na základě aktuálního kontextu a chování  
- **Podmíněný přístup**: Kontroly přístupu, které se přizpůsobují na základě rizikových faktorů, lokace a důvěryhodnosti zařízení  

### Vzory integrace do podnikových systémů  

#### **Integrace do bezpečnostního ekosystému Microsoftu**  
- **Microsoft Defender for Cloud**: Komplexní správa bezpečnostní pozice v cloudu  
- **Azure Sentinel**: Cloudové SIEM a SOAR schopnosti pro ochranu AI pracovní zátěže  
- **Microsoft Entra ID**: Podniková správa identit a přístupu s politikami podmíněného přístupu  
- **Azure Key Vault**: Centralizovaná správa tajných klíčů s podporou hardwarového bezpečnostního modulu (HSM)  
- **Microsoft Purview**: Správa dat a dodržování předpisů pro datové zdroje a pracovní toky AI  

#### **Soulad a správa**  
- **Regulační sladění**: Zajistěte, aby implementace MCP splňovaly požadavky specifické pro dané odvětví (GDPR, HIPAA, SOC 2)  
- **Klasifikace dat**: Správná kategorizace a zpracování citlivých dat zpracovávaných AI systémy  
- **Auditní stopy**: Komplexní logování pro regulační soulad a forenzní vyšetřování  
- **Kontroly ochrany soukromí**: Implementace principů ochrany soukromí již při návrhu architektury AI systému  
- **Správa změn**: Formální procesy pro bezpečnostní přezkumy změn AI systému  

Tyto základní postupy vytvářejí robustní bezpečnostní základnu, která zvyšuje účinnost specifických bezpečnostních kontrol MCP a poskytuje komplexní ochranu pro aplikace poháněné AI.  

## Klíčové bezpečnostní poznatky  

- **Vícevrstvý bezpečnostní přístup**: Kombinujte základní bezpečnostní postupy (bezpečné kódování, minimální oprávnění, ověření dodavatelského řetězce, nepřetržité monitorování) s kontrolami specifickými pro AI pro komplexní ochranu  

- **Specifické hrozby pro AI**: Systémy MCP čelí unikátním rizikům, jako jsou injekce promptů, otrava nástrojů, únos relací, problém zmateného zástupce, zranitelnosti při předávání tokenů a nadměrná oprávnění, které vyžadují specializovaná opatření  

- **Excelence v autentizaci a autorizaci**: Implementujte robustní autentizaci pomocí externích poskytovatelů identit (Microsoft Entra ID), prosazujte správnou validaci tokenů a nikdy nepřijímejte tokeny, které nebyly explicitně vydány pro váš server MCP  

- **Prevence útoků na AI**: Nasazujte Microsoft Prompt Shields a Azure Content Safety pro obranu proti nepřímým injekcím promptů a útokům na otravu nástrojů, zatímco validujete metadata nástrojů a monitorujete dynamické změny  

- **Bezpečnost relací a přenosu**: Používejte kryptograficky bezpečné, nedeterministické ID relací vázané na identity uživatelů, implementujte správnou správu životního cyklu relací a nikdy nepoužívejte relace pro autentizaci  

- **Nejlepší postupy bezpečnosti OAuth**: Zabraňte útokům zmateného zástupce prostřednictvím explicitního souhl
### **Microsoft Security Solutions**
- [Microsoft Prompt Shields Documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety Service](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Microsoft Entra ID Security](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Azure Token Management Best Practices](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [GitHub Advanced Security](https://github.com/security/advanced-security)

### **Průvodce implementací a návody**
- [Azure API Management jako autentizační brána MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID autentizace s MCP servery](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Bezpečné ukládání tokenů a šifrování (video)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### **DevOps a bezpečnost dodavatelského řetězce**
- [Azure DevOps Security](https://azure.microsoft.com/products/devops)
- [Azure Repos Security](https://azure.microsoft.com/products/devops/repos/)
- [Cesta k zabezpečení dodavatelského řetězce v Microsoftu](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)

## **Další dokumentace k bezpečnosti**

Pro komplexní bezpečnostní pokyny se podívejte na tyto specializované dokumenty v této sekci:

- **[MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md)** - Kompletní osvědčené postupy pro zabezpečení MCP implementací
- **[Azure Content Safety Implementation](./azure-content-safety-implementation.md)** - Praktické příklady implementace integrace Azure Content Safety  
- **[MCP Security Controls 2025](./mcp-security-controls-2025.md)** - Nejnovější bezpečnostní kontroly a techniky pro nasazení MCP
- **[MCP Best Practices Quick Reference](./mcp-best-practices.md)** - Rychlý referenční průvodce základními bezpečnostními postupy MCP

---

## Co dál

Další: [Kapitola 3: Začínáme](../03-GettingStarted/README.md)

**Prohlášení:**  
Tento dokument byl přeložen pomocí služby pro automatický překlad [Co-op Translator](https://github.com/Azure/co-op-translator). Ačkoli se snažíme o přesnost, mějte na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace doporučujeme profesionální lidský překlad. Neodpovídáme za žádná nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.