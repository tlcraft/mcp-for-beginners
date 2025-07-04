<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T18:46:05+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sk"
}
-->
# Najlepšie bezpečnostné postupy

Prijatie Model Context Protocolu (MCP) prináša do aplikácií poháňaných umelou inteligenciou nové silné možnosti, ale zároveň predstavuje jedinečné bezpečnostné výzvy, ktoré presahujú tradičné softvérové riziká. Okrem osvedčených zásad ako bezpečné programovanie, princíp najmenších právomocí a bezpečnosť dodávateľského reťazca, MCP a pracovné záťaže AI čelia novým hrozbám, ako sú prompt injection, otrava nástrojov a dynamické modifikácie nástrojov. Tieto riziká môžu viesť k úniku dát, porušeniu súkromia a nežiaducej činnosti systému, ak nie sú správne riadené.

Táto lekcia skúma najrelevantnejšie bezpečnostné riziká spojené s MCP — vrátane autentifikácie, autorizácie, nadmerných oprávnení, nepriamych útokov prompt injection a zraniteľností dodávateľského reťazca — a poskytuje praktické opatrenia a najlepšie postupy na ich zmiernenie. Naučíte sa tiež, ako využiť riešenia Microsoftu ako Prompt Shields, Azure Content Safety a GitHub Advanced Security na posilnenie implementácie MCP. Pochopením a aplikovaním týchto opatrení môžete výrazne znížiť pravdepodobnosť bezpečnostného incidentu a zabezpečiť, že vaše AI systémy zostanú spoľahlivé a dôveryhodné.

# Ciele učenia

Na konci tejto lekcie budete schopní:

- Identifikovať a vysvetliť jedinečné bezpečnostné riziká zavedené Model Context Protocolom (MCP), vrátane prompt injection, otravy nástrojov, nadmerných oprávnení a zraniteľností dodávateľského reťazca.
- Opísať a aplikovať účinné opatrenia na zmiernenie bezpečnostných rizík MCP, ako sú robustná autentifikácia, princíp najmenších právomocí, bezpečná správa tokenov a overovanie dodávateľského reťazca.
- Pochopiť a využiť riešenia Microsoftu ako Prompt Shields, Azure Content Safety a GitHub Advanced Security na ochranu MCP a AI pracovných záťaží.
- Uvedomiť si dôležitosť validácie metadát nástrojov, monitorovania dynamických zmien a obrany proti nepriamym útokom prompt injection.
- Integrovať osvedčené bezpečnostné postupy — ako bezpečné programovanie, spevňovanie serverov a architektúru zero trust — do vašej implementácie MCP, aby ste znížili pravdepodobnosť a dopad bezpečnostných incidentov.

# Bezpečnostné opatrenia MCP

Každý systém, ktorý má prístup k dôležitým zdrojom, čelí implicitným bezpečnostným výzvam. Tieto výzvy je možné vo všeobecnosti riešiť správnou aplikáciou základných bezpečnostných opatrení a konceptov. Keďže MCP je len nedávno definovaný, špecifikácia sa veľmi rýchlo mení a protokol sa vyvíja. Postupne sa bezpečnostné opatrenia v ňom vyvinú, čo umožní lepšiu integráciu s podnikmi a zavedenými bezpečnostnými architektúrami a najlepšími praktikami.

Výskum publikovaný v [Microsoft Digital Defense Report](https://aka.ms/mddr) uvádza, že 98 % hlásených narušení by bolo možné zabrániť dôslednou bezpečnostnou hygienou a najlepšou ochranou proti akémukoľvek narušeniu je správne nastavenie základnej bezpečnostnej hygieny, osvedčených postupov bezpečného programovania a bezpečnosti dodávateľského reťazca — tieto overené postupy stále najviac prispievajú k zníženiu bezpečnostného rizika.

Pozrime sa na niektoré spôsoby, ako môžete začať riešiť bezpečnostné riziká pri zavádzaní MCP.

> **Note:** Nasledujúce informácie sú platné k **29. máju 2025**. Protokol MCP sa neustále vyvíja a budúce implementácie môžu zaviesť nové vzory autentifikácie a kontroly. Pre najnovšie aktualizácie a odporúčania vždy odkazujte na [MCP Specification](https://spec.modelcontextprotocol.io/) a oficiálne [MCP GitHub repository](https://github.com/modelcontextprotocol) a [stránku s najlepšími bezpečnostnými praktikami](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problém

Pôvodná špecifikácia MCP predpokladala, že vývojári napíšu vlastný autentifikačný server. To vyžadovalo znalosť OAuth a súvisiacich bezpečnostných obmedzení. MCP servery fungovali ako OAuth 2.0 autorizačné servery, ktoré priamo spravovali potrebnú autentifikáciu používateľa, namiesto delegovania na externú službu, ako je Microsoft Entra ID. Od **26. apríla 2025** aktualizácia špecifikácie MCP umožňuje MCP serverom delegovať autentifikáciu používateľa na externú službu.

### Riziká
- Nesprávne nakonfigurovaná autorizačná logika na MCP serveri môže viesť k odhaleniu citlivých údajov a nesprávnemu uplatneniu prístupových práv.
- Krádež OAuth tokenu na lokálnom MCP serveri. Ak je token ukradnutý, môže byť použitý na vydávanie sa za MCP server a prístup k zdrojom a dátam služby, pre ktorú je token určený.

#### Token Passthrough
Token passthrough je v autorizačnej špecifikácii výslovne zakázaný, pretože prináša niekoľko bezpečnostných rizík, medzi ktoré patria:

#### Obchádzanie bezpečnostných opatrení
MCP server alebo downstream API môžu implementovať dôležité bezpečnostné opatrenia ako obmedzovanie rýchlosti, validáciu požiadaviek alebo monitorovanie prevádzky, ktoré závisia od publika tokenu alebo iných obmedzení poverení. Ak klienti môžu získať a používať tokeny priamo s downstream API bez toho, aby ich MCP server správne overoval alebo zabezpečil, že tokeny sú vydané pre správnu službu, tieto opatrenia obchádzajú.

#### Problémy s identifikáciou a auditom
MCP server nebude schopný identifikovať alebo rozlíšiť medzi MCP klientmi, keď klienti volajú s tokenom vydaným upstream, ktorý môže byť pre MCP server nečitateľný.
Logy downstream Resource Servera môžu zobrazovať požiadavky, ktoré vyzerajú, že pochádzajú z iného zdroja s inou identitou, namiesto MCP servera, ktorý tokeny skutočne posiela.
Oba faktory sťažujú vyšetrovanie incidentov, kontrolu a audit.
Ak MCP server posiela tokeny bez overenia ich nárokov (napr. rolí, oprávnení alebo publika) alebo iných metadát, škodlivý aktér s ukradnutým tokenom môže použiť server ako proxy na únik dát.

#### Problémy s hranicou dôvery
Downstream Resource Server dôveruje konkrétnym entitám. Táto dôvera môže zahŕňať predpoklady o pôvode alebo vzorcoch správania klienta. Porušenie tejto hranice dôvery môže viesť k neočakávaným problémom.
Ak je token akceptovaný viacerými službami bez riadneho overenia, útočník, ktorý kompromituje jednu službu, môže použiť token na prístup k ďalším prepojeným službám.

#### Riziko budúcej kompatibility
Aj keď MCP server dnes začína ako „čistý proxy“, môže byť neskôr potrebné pridať bezpečnostné opatrenia. Začatie s riadnym oddelením publika tokenu uľahčuje vývoj bezpečnostného modelu.

### Opatrenia na zmiernenie

**MCP servery NESMÚ akceptovať žiadne tokeny, ktoré neboli výslovne vydané pre MCP server**

- **Preskúmajte a spevnite autorizačnú logiku:** Starostlivo auditujte implementáciu autorizácie na vašom MCP serveri, aby mali prístup k citlivým zdrojom len zamýšľaní používatelia a klienti. Pre praktické návody pozrite [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) a [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Dodržiavajte bezpečné praktiky správy tokenov:** Postupujte podľa [najlepších praktík Microsoftu pre validáciu tokenov a ich životnosť](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby ste zabránili zneužitiu prístupových tokenov a znížili riziko opätovného použitia alebo krádeže tokenov.
- **Chráňte ukladanie tokenov:** Tokeny vždy ukladajte bezpečne a používajte šifrovanie na ich ochranu v pokoji aj počas prenosu. Pre tipy na implementáciu pozrite [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadmerné oprávnenia pre MCP servery

### Problém

MCP servery mohli byť vybavené nadmerným oprávnením k službe alebo zdroju, ku ktorému pristupujú. Napríklad MCP server, ktorý je súčasťou AI aplikácie pre predaj a pripája sa k podnikovej dátovej databáze, by mal mať prístup obmedzený len na predajné dáta a nemal by mať povolený prístup ku všetkým súborom v úložisku. Vráťme sa k princípu najmenších právomocí (jednému z najstarších bezpečnostných princípov) — žiadny zdroj by nemal mať oprávnenia nad rámec toho, čo je potrebné na vykonanie jeho úloh. AI predstavuje v tejto oblasti zvýšenú výzvu, pretože na zabezpečenie flexibility môže byť náročné presne definovať potrebné oprávnenia.

### Riziká
- Udeľovanie nadmerných oprávnení môže umožniť únik alebo zmenu dát, ku ktorým MCP server nemal mať prístup. Môže to byť tiež problémom ochrany súkromia, ak ide o osobné identifikovateľné informácie (PII).

### Opatrenia na zmiernenie
- **Uplatnite princíp najmenších právomocí:** Udeľujte MCP serveru len minimálne oprávnenia potrebné na vykonanie jeho úloh. Pravidelne kontrolujte a aktualizujte tieto oprávnenia, aby neprekročili potrebnú mieru. Pre podrobné usmernenie pozrite [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Používajte riadenie prístupu na základe rolí (RBAC):** Priraďte MCP serveru role, ktoré sú úzko zamerané na konkrétne zdroje a akcie, vyhýbajte sa širokým alebo zbytočným oprávneniam.
- **Monitorujte a auditujte oprávnenia:** Neustále sledujte využívanie oprávnení a auditujte prístupové záznamy, aby ste rýchlo odhalili a odstránili nadmerné alebo nepoužívané oprávnenia.

# Nepriame útoky prompt injection

### Problém

Zlovestné alebo kompromitované MCP servery môžu predstavovať významné riziká tým, že odhaľujú zákaznícke dáta alebo umožňujú nežiaduce akcie. Tieto riziká sú obzvlášť relevantné v AI a MCP pracovných záťažiach, kde:

- **Útoky prompt injection:** Útočníci vkladajú škodlivé inštrukcie do promptov alebo externého obsahu, čo spôsobuje, že AI systém vykonáva nežiaduce akcie alebo uniká citlivé dáta. Viac informácií: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrava nástrojov:** Útočníci manipulujú s metadátami nástrojov (napríklad popisy alebo parametre), aby ovplyvnili správanie AI, potenciálne obchádzajúc bezpečnostné opatrenia alebo unikajúc dáta. Podrobnosti: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Škodlivé inštrukcie sú vložené do dokumentov, webových stránok alebo e-mailov, ktoré AI spracováva, čo vedie k úniku alebo manipulácii dát.
- **Dynamická modifikácia nástrojov (Rug Pulls):** Definície nástrojov môžu byť po schválení používateľom zmenené, čím sa zavádzajú nové škodlivé správania bez vedomia používateľa.

Tieto zraniteľnosti zdôrazňujú potrebu robustnej validácie, monitorovania a bezpečnostných opatrení pri integrácii MCP serverov a nástrojov do vášho prostredia. Pre hlbšie pochopenie pozrite si vyššie uvedené odkazy.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sk.png)

**Nepriama prompt injection** (známa aj ako cross-domain prompt injection alebo XPIA) je kritická zraniteľnosť v generatívnych AI systémoch, vrátane tých, ktoré používajú Model Context Protocol (MCP). Pri tomto útoku sú škodlivé inštrukcie skryté v externom obsahu — ako sú dokumenty, webové stránky alebo e-maily. Keď AI systém tento obsah spracuje, môže interpretovať vložené inštrukcie ako legitímne používateľské príkazy, čo vedie k nežiaducej činnosti, ako je únik dát, generovanie škodlivého obsahu alebo manipulácia používateľských interakcií. Pre podrobný popis a reálne príklady pozrite [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Obzvlášť nebezpečnou formou tohto útoku je **Otrava nástrojov**. Útočníci tu vkladajú škodlivé inštrukcie do metadát MCP nástrojov (napríklad popisy alebo parametre). Keďže veľké jazykové modely (LLM) sa spoliehajú na tieto metadáta pri rozhodovaní, ktoré nástroje vyvolať, kompromitované popisy môžu model oklamať, aby vykonal neautorizované volania nástrojov alebo obchádzal bezpečnostné opatrenia. Tieto manipulácie sú často pre koncových používateľov neviditeľné, no AI systém ich môže interpretovať a vykonať. Toto riziko je zvýšené v hostovaných MCP serveroch, kde definície nástrojov môžu byť po schválení používateľom aktualizované — situácia niekedy označovaná ako "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takých prípadoch môže byť nástroj, ktorý bol pôvodne bezpečný, neskôr zmenený na vykonávanie škodlivých akcií, ako je únik dát alebo zmena správania systému, bez vedomia používateľa. Viac o tomto útoku nájdete v [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sk.png)

## Riziká
Nežiaduce akcie AI predstavujú rôzne bezpečnostné riziká, vrátane úniku dát a porušenia súkromia.

### Opatrenia na zmiernenie
### Použitie prompt shields na ochranu proti nepriamym útokom prompt injection
-----------------------------------------------------------------------------

**AI Prompt Shields** sú riešenie vyvinuté spoločnosťou Microsoft na obranu proti priamym aj nepriamym útokom prompt injection. Pomáhajú prostredníctvom:

1.  **Detekcie a filtrovania:** Prompt Shields využívajú pokročilé algoritmy strojového učenia a spracovania prirodzeného jazyka na detekciu a filtrovanie škodlivých inštrukcií vložených v externom obsahu, ako sú dokumenty, webové stránky alebo e-maily.
    
2.  **Spotlighting:** Táto technika pomáha AI systému rozlíšiť platné systémové inštrukcie od potenciálne nedôveryhodných externých vstupov. Transformáciou vstupného textu spôsobom, ktorý je pre model relevantnejší, Spotlighting zabezpečuje, že AI lepšie identifikuje a ignoruje škodlivé inštrukcie.
    
3.
Bezpečnosť dodávateľského reťazca zostáva v ére AI kľúčová, no rozsah toho, čo sa považuje za váš dodávateľský reťazec, sa rozšíril. Okrem tradičných balíkov kódu musíte teraz dôkladne overovať a monitorovať všetky komponenty súvisiace s AI, vrátane základných modelov, služieb embeddings, poskytovateľov kontextu a API tretích strán. Každý z týchto prvkov môže, ak nie je správne spravovaný, zaviesť zraniteľnosti alebo riziká.

**Kľúčové postupy zabezpečenia dodávateľského reťazca pre AI a MCP:**
- **Overte všetky komponenty pred integráciou:** To zahŕňa nielen open-source knižnice, ale aj AI modely, zdroje dát a externé API. Vždy skontrolujte pôvod, licencovanie a známe zraniteľnosti.
- **Udržiavajte bezpečné nasadzovacie pipeline:** Používajte automatizované CI/CD pipeline s integrovaným bezpečnostným skenovaním na včasné odhalenie problémov. Zabezpečte, aby do produkcie boli nasadzované iba dôveryhodné artefakty.
- **Priebežne monitorujte a auditujte:** Zavádzajte nepretržité monitorovanie všetkých závislostí, vrátane modelov a dátových služieb, aby ste odhalili nové zraniteľnosti alebo útoky na dodávateľský reťazec.
- **Uplatňujte princíp najmenších právomocí a kontrolu prístupu:** Obmedzte prístup k modelom, dátam a službám len na nevyhnutné minimum pre fungovanie vášho MCP servera.
- **Rýchlo reagujte na hrozby:** Majte zavedený proces na opravu alebo výmenu kompromitovaných komponentov a na rotáciu tajomstiev či prihlasovacích údajov v prípade zistenia narušenia.

[GitHub Advanced Security](https://github.com/security/advanced-security) ponúka funkcie ako skenovanie tajomstiev, skenovanie závislostí a analýzu CodeQL. Tieto nástroje sa integrujú s [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) a [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), aby pomohli tímom identifikovať a zmierniť zraniteľnosti v kóde aj v komponentoch AI dodávateľského reťazca.

Microsoft tiež vo vnútri spoločnosti implementuje rozsiahle bezpečnostné postupy pre dodávateľský reťazec vo všetkých produktoch. Viac sa dozviete v [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Overené bezpečnostné postupy, ktoré zlepšia bezpečnostnú úroveň vašej implementácie MCP

Každá implementácia MCP dedí existujúcu bezpečnostnú úroveň prostredia vašej organizácie, na ktorom je postavená, preto pri zvažovaní bezpečnosti MCP ako súčasti vašich celkových AI systémov sa odporúča zlepšiť celkovú existujúcu bezpečnostnú úroveň. Nasledujúce overené bezpečnostné kontroly sú obzvlášť relevantné:

-   Najlepšie praktiky bezpečného kódovania vo vašej AI aplikácii – chráňte sa pred [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 pre LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), používajte bezpečné úložiská pre tajomstvá a tokeny, implementujte end-to-end zabezpečenú komunikáciu medzi všetkými komponentmi aplikácie a podobne.
-   Spevnenie servera – používajte MFA kde je to možné, pravidelne aplikujte záplaty, integrujte server s poskytovateľom identity tretích strán pre prístup a podobne.
-   Udržiavajte zariadenia, infraštruktúru a aplikácie aktuálne so záplatami.
-   Bezpečnostné monitorovanie – implementujte logovanie a monitorovanie AI aplikácie (vrátane MCP klienta/serverov) a odosielajte tieto logy do centrálneho SIEM na detekciu anomálií.
-   Architektúra Zero Trust – izolujte komponenty pomocou sieťových a identitných kontrol logickým spôsobom, aby ste minimalizovali laterálny pohyb v prípade kompromitácie AI aplikácie.

# Kľúčové zhrnutie

- Základy bezpečnosti zostávajú kritické: Bezpečné kódovanie, princíp najmenších právomocí, overovanie dodávateľského reťazca a nepretržité monitorovanie sú nevyhnutné pre MCP a AI záťaže.
- MCP prináša nové riziká – ako napríklad prompt injection, tool poisoning a nadmerné oprávnenia – ktoré vyžadujú tradičné aj špecifické AI kontroly.
- Používajte robustné praktiky autentifikácie, autorizácie a správy tokenov, pričom využívajte externých poskytovateľov identity ako Microsoft Entra ID, kde je to možné.
- Chráňte sa pred nepriamym prompt injection a tool poisoning overovaním metadát nástrojov, monitorovaním dynamických zmien a používaním riešení ako Microsoft Prompt Shields.
- Zaobchádzajte so všetkými komponentmi vo vašom AI dodávateľskom reťazci – vrátane modelov, embeddings a poskytovateľov kontextu – s rovnakou dôslednosťou ako s kódovými závislosťami.
- Sledujte aktuálne špecifikácie MCP a prispievajte do komunity, aby ste pomohli formovať bezpečné štandardy.

# Ďalšie zdroje

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

### Ďalej

Ďalej: [Chapter 3: Getting Started](../03-GettingStarted/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.