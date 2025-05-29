<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:35:09+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sk"
}
-->
# Najlepšie bezpečnostné praktiky

Prijatie Model Context Protocolu (MCP) prináša výkonné nové možnosti pre aplikácie poháňané umelou inteligenciou, no zároveň prináša špecifické bezpečnostné výzvy, ktoré presahujú tradičné softvérové riziká. Okrem známych otázok ako bezpečné programovanie, princíp najmenších právomocí a bezpečnosť dodávateľského reťazca, čelia MCP a AI pracovné záťaže novým hrozbám, ako sú prompt injection, otrava nástrojov a dynamické úpravy nástrojov. Tieto riziká môžu viesť k úniku dát, porušeniu súkromia a nežiaducej činnosti systému, ak nie sú správne riadené.

Táto lekcia skúma najdôležitejšie bezpečnostné riziká spojené s MCP — vrátane autentifikácie, autorizácie, nadmerných oprávnení, nepriameho prompt injection a zraniteľností v dodávateľskom reťazci — a poskytuje praktické opatrenia a najlepšie postupy na ich zmiernenie. Tiež sa naučíte, ako využiť riešenia Microsoftu ako Prompt Shields, Azure Content Safety a GitHub Advanced Security na posilnenie vašej implementácie MCP. Pochopením a aplikovaním týchto opatrení môžete výrazne znížiť pravdepodobnosť bezpečnostného incidentu a zabezpečiť, že vaše AI systémy zostanú spoľahlivé a dôveryhodné.

# Ciele učenia

Na konci tejto lekcie budete schopní:

- Identifikovať a vysvetliť jedinečné bezpečnostné riziká, ktoré prináša Model Context Protocol (MCP), vrátane prompt injection, otravy nástrojov, nadmerných oprávnení a zraniteľností v dodávateľskom reťazci.
- Popísať a aplikovať účinné kontrolné opatrenia na zmiernenie bezpečnostných rizík MCP, ako sú robustná autentifikácia, princíp najmenších právomocí, bezpečné spravovanie tokenov a overovanie dodávateľského reťazca.
- Pochopiť a využiť riešenia Microsoftu ako Prompt Shields, Azure Content Safety a GitHub Advanced Security na ochranu MCP a AI pracovných záťaží.
- Uvedomiť si význam validácie metadát nástrojov, monitorovania dynamických zmien a obrany proti nepriamym prompt injection útokom.
- Integrovať etablované bezpečnostné postupy — ako bezpečné programovanie, zabezpečenie serverov a architektúru zero trust — do vašej implementácie MCP, aby ste znížili pravdepodobnosť a dopad bezpečnostných incidentov.

# Bezpečnostné kontroly MCP

Každý systém s prístupom k dôležitým zdrojom prináša implicitné bezpečnostné výzvy. Tieto výzvy je možné vo všeobecnosti riešiť správnym uplatnením základných bezpečnostných kontrol a konceptov. Keďže MCP je relatívne novým protokolom, jeho špecifikácia sa rýchlo mení a vyvíja. Postupne sa bezpečnostné kontroly v rámci MCP vyvinú, čo umožní lepšiu integráciu s podnikovými a etablovanými bezpečnostnými architektúrami a najlepšími praktikami.

Výskum publikovaný v [Microsoft Digital Defense Report](https://aka.ms/mddr) uvádza, že 98 % hlásených bezpečnostných incidentov by bolo možné zabrániť dôslednou bezpečnostnou hygienou a najlepšou ochranou proti akémukoľvek narušeniu je správne nastavenie základnej bezpečnostnej hygieny, bezpečných programovacích praktík a bezpečnosti dodávateľského reťazca — tieto overené postupy stále najviac prispievajú k znižovaniu bezpečnostných rizík.

Pozrime sa na niektoré spôsoby, ako môžete začať riešiť bezpečnostné riziká pri zavádzaní MCP.

> **Note:** Nasledujúce informácie sú platné k **29. máju 2025**. Protokol MCP sa neustále vyvíja a budúce implementácie môžu priniesť nové vzory autentifikácie a kontroly. Pre najnovšie aktualizácie a odporúčania vždy odkazujte na [MCP Specification](https://spec.modelcontextprotocol.io/) a oficiálne [MCP GitHub repository](https://github.com/modelcontextprotocol) a [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problém

Pôvodná špecifikácia MCP predpokladala, že vývojári napíšu vlastný autentifikačný server. To vyžadovalo znalosť OAuth a súvisiacich bezpečnostných obmedzení. MCP servery fungovali ako OAuth 2.0 autorizačné servery, ktoré spravovali potrebnú autentifikáciu používateľa priamo, namiesto delegovania na externú službu, ako je Microsoft Entra ID. Od **26. apríla 2025** aktualizácia MCP špecifikácie umožňuje MCP serverom delegovať autentifikáciu používateľa na externú službu.

### Riziká

- Nesprávne nakonfigurovaná autorizácia na MCP serveri môže viesť k odhaleniu citlivých údajov a nesprávnemu uplatneniu prístupových práv.
- Krádež OAuth tokenu na lokálnom MCP serveri. Ak je token ukradnutý, môže byť použitý na vydávanie sa za MCP server a prístup k zdrojom a dátam, pre ktoré bol token vydaný.

#### Token Passthrough

Token passthrough je v autorizácii výslovne zakázaný, pretože prináša viacero bezpečnostných rizík, ktoré zahŕňajú:

#### Obchádzanie bezpečnostných kontrol

MCP server alebo downstream API môžu implementovať dôležité bezpečnostné kontroly, ako je obmedzovanie rýchlosti, validácia požiadaviek alebo monitorovanie prevádzky, ktoré závisia od cieľa tokenu alebo iných obmedzení prihlasovacích údajov. Ak klienti získajú a používajú tokeny priamo s downstream API bez správnej validácie MCP serverom alebo bez zabezpečenia, že tokeny sú vydané pre správnu službu, obchádzajú tieto kontroly.

#### Problémy s identifikáciou a auditom

MCP server nebude schopný identifikovať alebo rozlíšiť MCP klientov, keď klienti volajú s prístupovým tokenom vydaným upstream, ktorý môže byť pre MCP server nepriehľadný. Logy downstream Resource Servera môžu zobrazovať požiadavky, ktoré vyzerajú, že pochádzajú z iného zdroja s inou identitou, namiesto MCP servera, ktorý tokeny skutočne posiela. Tieto faktory komplikujú vyšetrovanie incidentov, kontroly a audit. Ak MCP server posiela tokeny bez overenia ich nárokov (napríklad rolí, oprávnení alebo cieľa) alebo iných metadát, môže útočník s ukradnutým tokenom použiť server ako proxy na únik dát.

#### Problémy s hranicou dôvery

Downstream Resource Server dôveruje konkrétnym entitám. Táto dôvera môže zahŕňať predpoklady o pôvode alebo vzoroch správania klienta. Porušenie tejto hranice dôvery môže viesť k neočakávaným problémom. Ak token prijímajú viaceré služby bez správnej validácie, útočník, ktorý kompromitoval jednu službu, môže použiť token na prístup k ďalším prepojeným službám.

#### Riziko budúcej kompatibility

Aj keď MCP server dnes funguje ako „čistý proxy“, môže byť neskôr potrebné pridať bezpečnostné kontroly. Správne oddelenie cieľa tokenu od začiatku uľahčuje ďalší vývoj bezpečnostného modelu.

### Opatrenia na zmiernenie rizík

**MCP servery NESMÚ akceptovať žiadne tokeny, ktoré neboli výslovne vydané pre MCP server**

- **Prekontrolujte a spevnite autorizáciu:** Dôkladne auditujte implementáciu autorizácie na vašom MCP serveri, aby mali prístup iba zamýšľaní používatelia a klienti ku citlivým zdrojom. Pre praktické usmernenie pozrite [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) a [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Dodržiavajte bezpečné postupy správy tokenov:** Postupujte podľa [Microsoftových najlepších praktík pre validáciu tokenov a ich životnosť](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby ste predišli zneužitiu prístupových tokenov a znížili riziko ich opätovného použitia alebo krádeže.
- **Chráňte ukladanie tokenov:** Tokeny vždy bezpečne ukladajte a používajte šifrovanie na ich ochranu v pokoji aj počas prenosu. Pre tipy na implementáciu pozrite [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadmerné oprávnenia pre MCP servery

### Problém

MCP servery môžu mať pridelené nadmerné oprávnenia k službe alebo zdroju, ku ktorému pristupujú. Napríklad MCP server, ktorý je súčasťou AI aplikácie pre predaj a pripája sa k podnikovej dátovej databáze, by mal mať prístup obmedzený len na predajné dáta a nemal by mať prístup ku všetkým súborom v úložisku. Späť k princípu najmenších právomocí (jeden z najstarších bezpečnostných princípov) – žiadny zdroj by nemal mať oprávnenia nad rámec toho, čo je potrebné na vykonanie jeho úloh. AI predstavuje v tejto oblasti zvýšenú výzvu, pretože flexibilita AI sťažuje presné definovanie potrebných oprávnení.

### Riziká

- Pridelenie nadmerných oprávnení môže umožniť únik alebo úpravu dát, ku ktorým MCP server nemal mať prístup. Môže to byť tiež problémom súkromia, ak ide o osobné identifikačné údaje (PII).

### Opatrenia na zmiernenie rizík

- **Uplatnite princíp najmenších právomocí:** Pridelené oprávnenia MCP serveru by mali byť len minimálne potrebné na vykonanie jeho úloh. Pravidelne ich kontrolujte a aktualizujte, aby neprekročili potrebný rozsah. Pre podrobné usmernenie pozrite [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Používajte riadenie prístupu na základe rolí (RBAC):** Priraďujte MCP serveru roly, ktoré sú presne definované pre konkrétne zdroje a akcie, vyhýbajte sa širokým alebo zbytočným oprávneniam.
- **Monitorujte a auditujte oprávnenia:** Neustále sledujte používanie oprávnení a auditujte prístupové logy, aby ste rýchlo odhalili a odstránili nadmerné alebo nepoužívané oprávnenia.

# Nepriame prompt injection útoky

### Problém

Zlovestné alebo kompromitované MCP servery môžu predstavovať významné riziká vystavením zákazníckych dát alebo umožnením nežiaducej činnosti. Tieto riziká sú obzvlášť dôležité v AI a MCP záťažiach, kde:

- **Prompt Injection útoky:** Útočníci vkladajú škodlivé inštrukcie do promptov alebo externého obsahu, čo spôsobuje, že AI systém vykonáva nežiaduce akcie alebo unikajú citlivé dáta. Viac: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrava nástrojov:** Útočníci manipulujú s metadátami nástrojov (napríklad popisy alebo parametre), aby ovplyvnili správanie AI, potenciálne obchádzajúc bezpečnostné kontroly alebo unikali dáta. Detaily: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Škodlivé inštrukcie sú vložené do dokumentov, webových stránok alebo emailov, ktoré AI spracováva, čo vedie k úniku alebo manipulácii dát.
- **Dynamické úpravy nástrojov (Rug Pulls):** Definície nástrojov môžu byť po schválení používateľom zmenené, čím sa zavádzajú nové škodlivé správania bez vedomia používateľa.

Tieto zraniteľnosti zdôrazňujú potrebu robustnej validácie, monitorovania a bezpečnostných opatrení pri integrácii MCP serverov a nástrojov do vášho prostredia. Pre hlbšie pochopenie pozrite uvedené odkazy.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sk.png)

**Nepriame Prompt Injection** (tiež známe ako cross-domain prompt injection alebo XPIA) je kritická zraniteľnosť v generatívnych AI systémoch, vrátane tých, ktoré používajú Model Context Protocol (MCP). Pri tomto útoku sú škodlivé inštrukcie skryté v externom obsahu — ako dokumenty, webové stránky alebo emaily. Keď AI systém spracuje tento obsah, môže tieto vložené inštrukcie interpretovať ako legitímne používateľské príkazy, čo vedie k nežiaducej činnosti, ako je únik dát, generovanie škodlivého obsahu alebo manipulácia s interakciami používateľa. Pre detailné vysvetlenie a príklady z praxe pozrite [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Obzvlášť nebezpečnou formou tohto útoku je **Otrava nástrojov**. Tu útočníci vkladajú škodlivé inštrukcie do metadát MCP nástrojov (napríklad popisy alebo parametre). Keďže veľké jazykové modely (LLM) používajú tieto metadáta na rozhodovanie, ktoré nástroje vyvolať, kompromitované popisy môžu model oklamať, aby vykonal neautorizované volania nástrojov alebo obchádzal bezpečnostné kontroly. Tieto manipulácie sú často neviditeľné pre koncových používateľov, ale môžu ich interpretovať a vykonávať AI systémy. Riziko sa zvyšuje v hosťovaných MCP serverových prostrediach, kde definície nástrojov môžu byť po schválení používateľa aktualizované — situácia známa ako "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takých prípadoch môže byť nástroj, ktorý bol predtým bezpečný, neskôr upravený na vykonávanie škodlivých akcií, ako je únik dát alebo zmena správania systému, bez vedomia používateľa. Viac o tomto útoku: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sk.png)

## Riziká

Nežiaduce akcie AI predstavujú rôzne bezpečnostné riziká vrátane úniku dát a porušovania súkromia.

### Opatrenia na zmiernenie rizík

### Použitie prompt shields na ochranu proti nepriamym prompt injection útokom
-----------------------------------------------------------------------------

**AI Prompt Shields** sú riešenie vyvinuté spoločnosťou Microsoft na obranu proti priamym aj nepriamym prompt injection útokom. Pomáhajú prostredníctvom:

1.  **Detekcie a filtrovania:** Prompt Shields využívajú pokročilé algoritmy strojového učenia a spracovania prirodzeného jazyka na detekciu a filtrovanie škodlivých inštrukcií vložených v externom obsahu, ako sú dokumenty, webové stránky alebo emaily.
    
2.  **Spotlighting:** Táto technika pomáha AI systému rozlíšiť platné systémové inštrukcie od potenciálne nedôveryhodných externých vstupov. Transformáciou vstupného textu tak, aby bol relevantnejší pre model, Spotlighting zabezpečuje, že AI lepšie identifikuje a ignoruje škodlivé inštrukcie.
    
3.  **Delimitery a datamarking:** Zahrnutie delimitrov v systémovej správe jasne vyznačuje umiestnenie vstupného textu, čo pomáha AI systému rozpoznať a oddeliť používateľské vstupy od potenciálne škodlivého externého
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Cesta k zabezpečeniu dodávateľského reťazca softvéru v Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Zabezpečený prístup s minimálnymi právami (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najlepšie postupy pre overovanie tokenov a ich platnosť](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Použitie bezpečného ukladania tokenov a ich šifrovanie (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management ako autentifikačná brána pre MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Najlepšie bezpečnostné praktiky MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Použitie Microsoft Entra ID na autentifikáciu s MCP servermi](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Ďalej

Ďalej: [Kapitola 3: Začíname](/03-GettingStarted/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, berte prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.