<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T11:05:29+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sk"
}
-->
# Najlepšie bezpečnostné postupy

Prijatie Model Context Protocol (MCP) prináša výkonné nové možnosti pre aplikácie riadené umelou inteligenciou, ale zároveň predstavuje jedinečné bezpečnostné výzvy, ktoré presahujú tradičné softvérové riziká. Okrem osvedčených problémov, ako je bezpečné programovanie, princíp najmenších právomocí a bezpečnosť dodávateľského reťazca, MCP a pracovné záťaže AI čelia novým hrozbám, ako sú prompt injection, otrava nástrojov, dynamická modifikácia nástrojov, únos relácie, útoky typu confused deputy a zraniteľnosti token passthrough. Tieto riziká môžu viesť k úniku dát, porušeniu súkromia a nežiaducej činnosti systému, ak nie sú správne riadené.

Táto lekcia skúma najrelevantnejšie bezpečnostné riziká spojené s MCP — vrátane autentifikácie, autorizácie, nadmerných oprávnení, nepriameho prompt injection, bezpečnosti relácií, problémov confused deputy, zraniteľností token passthrough a zraniteľností dodávateľského reťazca — a poskytuje praktické opatrenia a najlepšie postupy na ich zmiernenie. Tiež sa naučíte, ako využiť riešenia Microsoftu, ako sú Prompt Shields, Azure Content Safety a GitHub Advanced Security, na posilnenie implementácie MCP. Pochopením a aplikovaním týchto opatrení môžete výrazne znížiť pravdepodobnosť bezpečnostného incidentu a zabezpečiť, že vaše AI systémy zostanú robustné a dôveryhodné.

# Ciele učenia

Na konci tejto lekcie budete schopní:

- Identifikovať a vysvetliť jedinečné bezpečnostné riziká zavedené Model Context Protocol (MCP), vrátane prompt injection, otravy nástrojov, nadmerných oprávnení, únosu relácie, problémov confused deputy, zraniteľností token passthrough a zraniteľností dodávateľského reťazca.
- Opísať a aplikovať účinné opatrenia na zmiernenie bezpečnostných rizík MCP, ako sú robustná autentifikácia, princíp najmenších právomocí, bezpečná správa tokenov, kontrola bezpečnosti relácií a overovanie dodávateľského reťazca.
- Pochopiť a využiť riešenia Microsoftu, ako sú Prompt Shields, Azure Content Safety a GitHub Advanced Security, na ochranu MCP a AI pracovných záťaží.
- Uvedomiť si dôležitosť validácie metadát nástrojov, monitorovania dynamických zmien, obrany proti nepriamym prompt injection útokom a prevencie únosu relácií.
- Integrovať osvedčené bezpečnostné postupy — ako je bezpečné programovanie, spevňovanie serverov a architektúra zero trust — do vašej implementácie MCP, aby ste znížili pravdepodobnosť a dopad bezpečnostných incidentov.

# Bezpečnostné opatrenia MCP

Každý systém, ktorý má prístup k dôležitým zdrojom, čelí implicitným bezpečnostným výzvam. Bezpečnostné výzvy je možné vo všeobecnosti riešiť správnou aplikáciou základných bezpečnostných opatrení a konceptov. Keďže MCP je len nedávno definovaný, špecifikácia sa veľmi rýchlo mení a vyvíja. Postupne sa bezpečnostné opatrenia v ňom vyvinú, čo umožní lepšiu integráciu s podnikmi a zavedenými bezpečnostnými architektúrami a najlepšími praktikami.

Výskum publikovaný v [Microsoft Digital Defense Report](https://aka.ms/mddr) uvádza, že 98 % nahlásených narušení by bolo možné zabrániť dôslednou bezpečnostnou hygienou a najlepšou ochranou proti akémukoľvek narušeniu je správne nastavenie základnej bezpečnostnej hygieny, osvedčených postupov bezpečného programovania a bezpečnosti dodávateľského reťazca — tieto overené postupy stále najviac prispievajú k zníženiu bezpečnostného rizika.

Pozrime sa na niektoré spôsoby, ako môžete začať riešiť bezpečnostné riziká pri zavádzaní MCP.

> **Note:** Nasledujúce informácie sú platné k **29. máju 2025**. Protokol MCP sa neustále vyvíja a budúce implementácie môžu zaviesť nové vzory autentifikácie a kontroly. Pre najnovšie aktualizácie a odporúčania vždy odkazujte na [MCP Specification](https://spec.modelcontextprotocol.io/) a oficiálne [MCP GitHub repository](https://github.com/modelcontextprotocol) a [stránku s najlepšími bezpečnostnými praktikami](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Vyjadrenie problému  
Pôvodná špecifikácia MCP predpokladala, že vývojári napíšu vlastný autentifikačný server. To vyžadovalo znalosť OAuth a súvisiacich bezpečnostných obmedzení. MCP servery fungovali ako OAuth 2.0 autorizačné servery, ktoré priamo spravovali požadovanú autentifikáciu používateľa namiesto delegovania na externú službu, ako je Microsoft Entra ID. Od **26. apríla 2025** aktualizácia špecifikácie MCP umožňuje MCP serverom delegovať autentifikáciu používateľa na externú službu.

### Riziká
- Nesprávne nakonfigurovaná autorizačná logika v MCP serveri môže viesť k odhaleniu citlivých údajov a nesprávnemu uplatneniu prístupových práv.
- Krádež OAuth tokenu na lokálnom MCP serveri. Ak je token ukradnutý, môže byť použitý na vydávanie sa za MCP server a prístup k zdrojom a dátam služby, pre ktorú je token určený.

#### Token Passthrough
Token passthrough je v autorizačnej špecifikácii výslovne zakázaný, pretože prináša niekoľko bezpečnostných rizík, medzi ktoré patria:

#### Obchádzanie bezpečnostných opatrení
MCP server alebo downstream API môžu implementovať dôležité bezpečnostné opatrenia, ako je obmedzovanie rýchlosti, validácia požiadaviek alebo monitorovanie prevádzky, ktoré závisia od publika tokenu alebo iných obmedzení poverení. Ak klienti môžu získať a používať tokeny priamo s downstream API bez toho, aby ich MCP server správne overoval alebo zabezpečil, že tokeny sú vydané pre správnu službu, tieto opatrenia obchádzajú.

#### Problémy s identifikáciou a auditom
MCP server nebude schopný identifikovať alebo rozlíšiť medzi MCP klientmi, keď klienti volajú s prístupovým tokenom vydaným upstream, ktorý môže byť pre MCP server neviditeľný.
Záznamy downstream Resource Servera môžu ukazovať požiadavky, ktoré sa javia, že pochádzajú z iného zdroja s inou identitou, namiesto MCP servera, ktorý tokeny skutočne posiela.
Oba faktory sťažujú vyšetrovanie incidentov, kontrolu a audit.
Ak MCP server posiela tokeny bez overenia ich nárokov (napr. rolí, oprávnení alebo publika) alebo iných metadát, škodlivý aktér s ukradnutým tokenom môže použiť server ako proxy na exfiltráciu dát.

#### Problémy s hranicou dôvery
Downstream Resource Server dôveruje konkrétnym entitám. Táto dôvera môže zahŕňať predpoklady o pôvode alebo vzorcoch správania klienta. Porušenie tejto hranice dôvery môže viesť k neočakávaným problémom.
Ak je token akceptovaný viacerými službami bez riadneho overenia, útočník, ktorý kompromituje jednu službu, môže použiť token na prístup k ďalším prepojeným službám.

#### Riziko budúcej kompatibility
Aj keď MCP server dnes začína ako „čistý proxy“, môže byť neskôr potrebné pridať bezpečnostné opatrenia. Začatie s riadnym oddelením publika tokenu uľahčuje vývoj bezpečnostného modelu.

### Opatrenia na zmiernenie

**MCP servery NESMÚ akceptovať žiadne tokeny, ktoré neboli výslovne vydané pre MCP server**

- **Preskúmajte a spevnite autorizačnú logiku:** Starostlivo auditujte implementáciu autorizácie MCP servera, aby mali prístup len zamýšľaní používatelia a klienti k citlivým zdrojom. Pre praktické usmernenie pozrite [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) a [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Dodržiavajte bezpečné praktiky správy tokenov:** Postupujte podľa [najlepších praktík Microsoftu pre validáciu a životnosť tokenov](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby ste zabránili zneužitiu prístupových tokenov a znížili riziko opätovného použitia alebo krádeže tokenov.
- **Chráňte ukladanie tokenov:** Tokeny vždy ukladajte bezpečne a používajte šifrovanie na ich ochranu v pokoji aj počas prenosu. Pre tipy na implementáciu pozrite [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadmerné oprávnenia pre MCP servery

### Vyjadrenie problému
MCP servery mohli byť udelené nadmerné oprávnenia k službe alebo zdroju, ku ktorému pristupujú. Napríklad MCP server, ktorý je súčasťou AI predajnej aplikácie pripájajúcej sa k podnikovej dátovej úložisku, by mal mať prístup obmedzený len na predajné dáta a nemal by mať povolený prístup ku všetkým súborom v úložisku. Vráťme sa k princípu najmenších právomocí (jednému z najstarších bezpečnostných princípov) — žiadny zdroj by nemal mať oprávnenia nad rámec toho, čo je potrebné na vykonanie jeho úloh. AI predstavuje v tejto oblasti zvýšenú výzvu, pretože na zabezpečenie flexibility môže byť náročné presne definovať potrebné oprávnenia.

### Riziká  
- Udelenie nadmerných oprávnení môže umožniť exfiltráciu alebo úpravu dát, ku ktorým MCP server nemal mať prístup. Môže to byť tiež problémom ochrany súkromia, ak ide o osobné identifikovateľné informácie (PII).

### Opatrenia na zmiernenie
- **Uplatnite princíp najmenších právomocí:** Udeľujte MCP serveru len minimálne oprávnenia potrebné na vykonanie jeho úloh. Pravidelne kontrolujte a aktualizujte tieto oprávnenia, aby neprekročili potrebnú mieru. Pre podrobné usmernenie pozrite [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Používajte riadenie prístupu na základe rolí (RBAC):** Priraďte MCP serveru role, ktoré sú úzko zamerané na konkrétne zdroje a akcie, vyhýbajte sa širokým alebo zbytočným oprávneniam.
- **Monitorujte a auditujte oprávnenia:** Neustále sledujte používanie oprávnení a auditujte prístupové záznamy, aby ste rýchlo odhalili a odstránili nadmerné alebo nepoužívané oprávnenia.

# Nepriame útoky prompt injection

### Vyjadrenie problému

Zlovestné alebo kompromitované MCP servery môžu predstavovať významné riziká tým, že odhaľujú zákaznícke dáta alebo umožňujú nežiaduce akcie. Tieto riziká sú obzvlášť relevantné v AI a MCP pracovných záťažiach, kde:

- **Útoky prompt injection:** Útočníci vkladajú škodlivé inštrukcie do promptov alebo externého obsahu, čo spôsobuje, že AI systém vykonáva nežiaduce akcie alebo uniká citlivé dáta. Viac informácií: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrava nástrojov:** Útočníci manipulujú s metadátami nástrojov (napríklad popisy alebo parametre), aby ovplyvnili správanie AI, potenciálne obchádzajúc bezpečnostné opatrenia alebo exfiltrujúc dáta. Podrobnosti: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Škodlivé inštrukcie sú vložené do dokumentov, webových stránok alebo e-mailov, ktoré AI spracováva, čo vedie k úniku alebo manipulácii dát.
- **Dynamická modifikácia nástrojov (Rug Pulls):** Definície nástrojov môžu byť po schválení používateľom zmenené, čím sa zavádzajú nové škodlivé správania bez vedomia používateľa.

Tieto zraniteľnosti zdôrazňujú potrebu robustnej validácie, monitorovania a bezpečnostných opatrení pri integrácii MCP serverov a nástrojov do vášho prostredia. Pre hlbšie pochopenie pozrite si uvedené odkazy.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sk.png)

**Nepriame prompt injection** (tiež známe ako cross-domain prompt injection alebo XPIA) je kritická zraniteľnosť v generatívnych AI systémoch, vrátane tých, ktoré používajú Model Context Protocol (MCP). Pri tomto útoku sú škodlivé inštrukcie skryté v externom obsahu — ako sú dokumenty, webové stránky alebo e-maily. Keď AI systém tento obsah spracuje, môže interpretovať vložené inštrukcie ako legitímne používateľské príkazy, čo vedie k nežiaducej činnosti, ako je únik dát, generovanie škodlivého obsahu alebo manipulácia s interakciami používateľa. Pre podrobný popis a reálne príklady pozrite [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Obzvlášť nebezpečnou formou tohto útoku je **Otrava nástrojov**. Útočníci tu vkladajú škodlivé inštrukcie do metadát MCP nástrojov (napríklad popisy alebo parametre). Keďže veľké jazykové modely (LLM) sa spoliehajú na tieto metadáta pri rozhodovaní, ktoré nástroje vyvolať, kompromitované popisy môžu model oklamať, aby vykonal neautorizované volania nástrojov alebo obchádzal bezpečnostné opatrenia. Tieto manipulácie sú často pre koncových používateľov neviditeľné, no AI systém ich môže interpretovať a vykonať. Toto riziko je zvýšené v hostovaných MCP serverových prostrediach, kde definície nástrojov môžu byť po schválení používateľom aktualizované — scenár niekedy označovaný ako „[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)“. V takých prípadoch môže byť nástroj, ktorý bol predtým bezpečný, neskôr upravený na vykonávanie škodlivých akcií, ako je exfiltrácia dát alebo zmena správania systému, bez vedomia používateľa. Viac o tomto útoku nájdete v [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sk.png)

## Riziká
Nežiaduce akcie AI predstavujú rôzne bezpečnostné riziká, vrátane exfiltrácie dát a porušenia súkromia.

### Opatrenia na zmiernenie
### Použitie prompt shields na ochranu proti nepriamym prompt injection útokom
-----------------------------------------------------------------------------

**AI Prompt Shields** sú riešenie vyvinuté spoločnosťou Microsoft na obranu proti priamym aj nepriamym prompt injection útokom. Pomáhajú prostredníctvom:

1.  **Detekcie a filtrovania:** Prompt Shields používajú pokročilé algoritmy strojového učenia a spracovania prirodzeného jazyka na detekciu a filtrovanie škodlivých inštrukcií vložených v externom obsahu, ako sú dokumenty
Problém zmätkujúceho zástupcu je bezpečnostná zraniteľnosť, ktorá nastáva, keď MCP server funguje ako proxy medzi MCP klientmi a API tretích strán. Túto zraniteľnosť je možné zneužiť, ak MCP server používa statické klientské ID na autentifikáciu u autorizačného servera tretej strany, ktorý nepodporuje dynamickú registráciu klientov.

### Riziká

- **Obídenie súhlasu založené na cookie**: Ak sa používateľ predtým autentifikoval cez MCP proxy server, autorizačný server tretej strany môže v prehliadači používateľa nastaviť cookie so súhlasom. Útočník to môže zneužiť zaslaním škodlivého odkazu s upravenou autorizačnou požiadavkou obsahujúcou škodlivú URI presmerovania.
- **Krádež autorizačného kódu**: Po kliknutí na škodlivý odkaz môže autorizačný server tretej strany preskočiť obrazovku so súhlasom kvôli existujúcej cookie a autorizačný kód môže byť presmerovaný na server útočníka.
- **Neoprávnený prístup k API**: Útočník môže vymeniť ukradnutý autorizačný kód za prístupové tokeny a vydávať sa za používateľa, čím získa prístup k API tretej strany bez výslovného schválenia.

### Opatrenia na zmiernenie

- **Požiadavky na explicitný súhlas**: MCP proxy servery používajúce statické klientské ID **MUSIA** získať súhlas používateľa pre každého dynamicky registrovaného klienta pred odoslaním požiadavky na autorizačné servery tretích strán.
- **Správna implementácia OAuth**: Dodržiavajte bezpečnostné odporúčania OAuth 2.1, vrátane použitia kódových výziev (PKCE) pri autorizačných požiadavkách, aby ste zabránili zachyteniu.
- **Validácia klienta**: Zaviesť prísnu validáciu URI presmerovania a identifikátorov klientov, aby sa zabránilo zneužitiu škodlivými aktérmi.


# Zraniteľnosti pri prenose tokenov

### Popis problému

„Token passthrough“ je anti-vzor, kde MCP server prijíma tokeny od MCP klienta bez overenia, či boli tokeny správne vydané priamo pre MCP server, a následne ich „prenáša“ do ďalších API. Tento prístup priamo porušuje špecifikáciu autorizácie MCP a predstavuje vážne bezpečnostné riziká.

### Riziká

- **Obídenie bezpečnostných kontrol**: Klienti môžu obísť dôležité bezpečnostné kontroly ako obmedzenie rýchlosti, validáciu požiadaviek alebo monitorovanie prevádzky, ak môžu používať tokeny priamo s ďalšími API bez riadneho overenia.
- **Problémy s účtovateľnosťou a auditom**: MCP server nebude schopný identifikovať alebo rozlíšiť medzi MCP klientmi, keď klienti používajú prístupové tokeny vydané vyššie, čo sťažuje vyšetrovanie incidentov a audit.
- **Únik dát**: Ak sa tokeny prenášajú bez správnej validácie nárokov, škodlivý aktér s ukradnutým tokenom môže použiť server ako proxy na únik dát.
- **Porušenie hraníc dôvery**: Servery zdrojov môžu dôverovať konkrétnym entitám na základe pôvodu alebo vzorcov správania. Porušenie tejto dôvery môže viesť k neočakávaným bezpečnostným problémom.
- **Zneužitie tokenov v multi-službách**: Ak tokeny prijímajú viaceré služby bez riadneho overenia, útočník, ktorý kompromituje jednu službu, môže použiť token na prístup k ďalším prepojeným službám.

### Opatrenia na zmiernenie

- **Validácia tokenov**: MCP servery **NESMÚ** akceptovať tokeny, ktoré neboli výslovne vydané pre samotný MCP server.
- **Overenie publika**: Vždy overte, že tokeny obsahujú správny nárok audience, ktorý zodpovedá identite MCP servera.
- **Správne riadenie životného cyklu tokenov**: Zaviesť krátkodobé prístupové tokeny a správne praktiky rotácie tokenov na zníženie rizika krádeže a zneužitia tokenov.


# Únos relácie

### Popis problému

Únos relácie je útok, pri ktorom klient dostane od servera ID relácie a neoprávnená osoba získa a použije toto isté ID relácie na vydávanie sa za pôvodného klienta a vykonávanie neoprávnených akcií v jeho mene. Tento problém je obzvlášť závažný pri stavových HTTP serveroch spracúvajúcich MCP požiadavky.

### Riziká

- **Vkladanie škodlivých promptov pri únose relácie**: Útočník, ktorý získa ID relácie, môže posielať škodlivé udalosti serveru, ktorý zdieľa stav relácie so serverom, ku ktorému je klient pripojený, čo môže spôsobiť škodlivé akcie alebo prístup k citlivým údajom.
- **Vydávanie sa za používateľa pri únose relácie**: Útočník s ukradnutým ID relácie môže volať priamo MCP server, obísť autentifikáciu a byť považovaný za legitímneho používateľa.
- **Ohrozené obnoviteľné prúdy**: Ak server podporuje opätovné doručenie alebo obnoviteľné prúdy, útočník môže predčasne ukončiť požiadavku, ktorá bude neskôr obnovená pôvodným klientom s potenciálne škodlivým obsahom.

### Opatrenia na zmiernenie

- **Overovanie autorizácie**: MCP servery, ktoré implementujú autorizáciu, **MUSIA** overovať všetky prichádzajúce požiadavky a **NESMÚ** používať relácie na autentifikáciu.
- **Bezpečné ID relácií**: MCP servery **MUSIA** používať bezpečné, nedeterministické ID relácií generované pomocou bezpečných generátorov náhodných čísel. Vyhnite sa predvídateľným alebo sekvenčným identifikátorom.
- **Viazanie relácie na používateľa**: MCP servery **ODPORÚČAJÚ** viazať ID relácie na používateľsky špecifické informácie, kombinujúc ID relácie s unikátnymi údajmi o autorizovanom používateľovi (napr. jeho interné používateľské ID) vo formáte `
<user_id>:<session_id>`.
- **Vypršanie platnosti relácie**: Zaviesť správne vypršanie platnosti a rotáciu relácií, aby sa obmedzil čas zraniteľnosti v prípade kompromitácie ID relácie.
- **Zabezpečenie prenosu**: Vždy používať HTTPS pre všetku komunikáciu, aby sa zabránilo zachyteniu ID relácie.


# Bezpečnosť dodávateľského reťazca

Bezpečnosť dodávateľského reťazca zostáva kľúčová v ére AI, no rozsah toho, čo predstavuje váš dodávateľský reťazec, sa rozšíril. Okrem tradičných balíkov kódu musíte teraz dôkladne overovať a monitorovať všetky AI súvisiace komponenty, vrátane základných modelov, služieb embeddingov, poskytovateľov kontextu a API tretích strán. Každý z týchto prvkov môže predstavovať zraniteľnosti alebo riziká, ak nie je správne spravovaný.

**Kľúčové bezpečnostné postupy pre dodávateľský reťazec AI a MCP:**
- **Overujte všetky komponenty pred integráciou:** To zahŕňa nielen open-source knižnice, ale aj AI modely, zdroje dát a externé API. Vždy kontrolujte pôvod, licencovanie a známe zraniteľnosti.
- **Udržiavajte bezpečné nasadzovacie pipeline:** Používajte automatizované CI/CD pipeline s integrovaným bezpečnostným skenovaním na včasné odhalenie problémov. Zabezpečte, aby do produkcie boli nasadzované len dôveryhodné artefakty.
- **Priebežne monitorujte a auditujte:** Zaviesť nepretržité monitorovanie všetkých závislostí, vrátane modelov a dátových služieb, na detekciu nových zraniteľností alebo útokov na dodávateľský reťazec.
- **Používajte princíp najmenších práv a kontrolu prístupu:** Obmedzte prístup k modelom, dátam a službám len na nevyhnutné minimum pre fungovanie MCP servera.
- **Rýchlo reagujte na hrozby:** Majte zavedený proces na opravu alebo výmenu kompromitovaných komponentov a na rotáciu tajomstiev alebo prihlasovacích údajov v prípade zistenia narušenia.

[GitHub Advanced Security](https://github.com/security/advanced-security) poskytuje funkcie ako skenovanie tajomstiev, skenovanie závislostí a analýzu CodeQL. Tieto nástroje sa integrujú s [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) a [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/), aby pomohli tímom identifikovať a zmierniť zraniteľnosti v kóde aj AI komponentoch dodávateľského reťazca.

Microsoft tiež interné implementuje rozsiahle bezpečnostné postupy dodávateľského reťazca pre všetky produkty. Viac informácií nájdete v [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Overené bezpečnostné postupy, ktoré zlepšia bezpečnostnú úroveň vašej implementácie MCP

Každá implementácia MCP dedí existujúcu bezpečnostnú úroveň prostredia vašej organizácie, na ktorom je postavená, preto sa pri zvažovaní bezpečnosti MCP ako súčasti vašich AI systémov odporúča zlepšiť celkovú existujúcu bezpečnostnú úroveň. Nasledujúce overené bezpečnostné kontroly sú obzvlášť relevantné:

-   Najlepšie praktiky bezpečného kódovania vo vašej AI aplikácii – chrániť proti [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 pre LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), používanie bezpečných trezorov pre tajomstvá a tokeny, implementácia end-to-end zabezpečenej komunikácie medzi všetkými komponentmi aplikácie atď.
-   Zosilnenie servera – používať MFA kde je to možné, udržiavať aktualizácie záplat, integrovať server s poskytovateľom identity tretích strán pre prístup atď.
-   Udržiavať zariadenia, infraštruktúru a aplikácie aktuálne s najnovšími záplatami
-   Bezpečnostné monitorovanie – implementovať logovanie a monitorovanie AI aplikácie (vrátane MCP klientov/serverov) a odosielať tieto logy do centrálneho SIEM na detekciu anomálií
-   Architektúra nulovej dôvery – izolovať komponenty pomocou sieťových a identitných kontrol logickým spôsobom, aby sa minimalizoval laterálny pohyb v prípade kompromitácie AI aplikácie.

# Kľúčové zhrnutie

- Základy bezpečnosti zostávajú kľúčové: Bezpečné kódovanie, princíp najmenších práv, overovanie dodávateľského reťazca a nepretržité monitorovanie sú nevyhnutné pre MCP a AI záťaže.
- MCP prináša nové riziká – ako vkladanie škodlivých promptov, otrava nástrojov, únos relácie, problém zmätkujúceho zástupcu, zraniteľnosti pri prenose tokenov a nadmerné oprávnenia – ktoré vyžadujú tradičné aj špecifické AI kontroly.
- Používajte robustné praktiky autentifikácie, autorizácie a správy tokenov, využívajúc externých poskytovateľov identity ako Microsoft Entra ID, kde je to možné.
- Chráňte sa pred nepriamym vkladaním promptov a otravou nástrojov overovaním metadát nástrojov, monitorovaním dynamických zmien a používaním riešení ako Microsoft Prompt Shields.
- Implementujte bezpečnú správu relácií použitím nedeterministických ID relácií, viazaním relácií na používateľské identity a nikdy nepoužívajte relácie na autentifikáciu.
- Predchádzajte útokom zmätkujúceho zástupcu vyžadovaním explicitného súhlasu používateľa pre každého dynamicky registrovaného klienta a implementáciou správnych bezpečnostných praktík OAuth.
- Vyhnite sa zraniteľnostiam pri prenose tokenov tým, že MCP servery budú akceptovať len tokeny výslovne vydané pre ne a správne validovať nároky tokenov.
- Zaobchádzajte so všetkými komponentmi vo vašom AI dodávateľskom reťazci – vrátane modelov, embeddingov a poskytovateľov kontextu – s rovnakou dôslednosťou ako s kódovými závislosťami.
- Sledujte aktuálne špecifikácie MCP a prispievajte do komunity, aby ste pomohli formovať bezpečné štandardy.

# Ďalšie zdroje

## Externé zdroje
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

## Ďalšie bezpečnostné dokumenty

Pre podrobnejšie bezpečnostné usmernenia si pozrite tieto dokumenty:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) – Komplexný zoznam bezpečnostných najlepších praktík pre implementácie MCP
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) – Príklady implementácie integrácie Azure Content Safety s MCP servermi
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) – Najnovšie bezpečnostné kontroly a techniky na zabezpečenie nasadení MCP
- [MCP Best Practices](./mcp-best-practices.md) – Rýchly referenčný sprievodca pre bezpečnosť MCP

### Ďalej

Ďalej: [Kapitola 3: Začíname](../03-GettingStarted/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.