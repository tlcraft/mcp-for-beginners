<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1c767a35642f753127dc08545c25a290",
  "translation_date": "2025-08-18T15:31:33+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sk"
}
-->
# MCP Bezpečnosť: Komplexná ochrana AI systémov

[![Najlepšie praktiky MCP bezpečnosti](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.sk.png)](https://youtu.be/88No8pw706o)

_(Kliknite na obrázok vyššie pre zobrazenie videa tejto lekcie)_

Bezpečnosť je základným prvkom pri návrhu AI systémov, a preto ju kladieme ako prioritu v našej druhej sekcii. To je v súlade s princípom Microsoftu **Secure by Design** z iniciatívy [Secure Future Initiative](https://www.microsoft.com/security/blog/2025/04/17/microsofts-secure-by-design-journey-one-year-of-success/).

Protokol Model Context Protocol (MCP) prináša silné nové schopnosti pre aplikácie poháňané AI, ale zároveň zavádza jedinečné bezpečnostné výzvy, ktoré presahujú tradičné softvérové riziká. MCP systémy čelia nielen známym bezpečnostným problémom (bezpečné kódovanie, princíp minimálnych oprávnení, bezpečnosť dodávateľského reťazca), ale aj novým AI-špecifickým hrozbám, ako sú injekcia promptov, otrava nástrojov, únos relácií, útoky zmätku zástupcu, zraniteľnosti pri prechode tokenov a dynamická modifikácia schopností.

Táto lekcia skúma najkritickejšie bezpečnostné riziká pri implementáciách MCP—zahŕňajúc autentifikáciu, autorizáciu, nadmerné oprávnenia, nepriamu injekciu promptov, bezpečnosť relácií, problémy zmätku zástupcu, správu tokenov a zraniteľnosti dodávateľského reťazca. Naučíte sa praktické opatrenia a najlepšie praktiky na zmiernenie týchto rizík, pričom využijete riešenia Microsoftu ako Prompt Shields, Azure Content Safety a GitHub Advanced Security na posilnenie vašej MCP implementácie.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- **Identifikovať MCP-špecifické hrozby**: Rozpoznať jedinečné bezpečnostné riziká v MCP systémoch vrátane injekcie promptov, otravy nástrojov, nadmerných oprávnení, únosu relácií, problémov zmätku zástupcu, zraniteľností pri prechode tokenov a rizík dodávateľského reťazca
- **Aplikovať bezpečnostné opatrenia**: Implementovať účinné zmiernenia vrátane robustnej autentifikácie, prístupu na princípe minimálnych oprávnení, bezpečnej správy tokenov, kontrol bezpečnosti relácií a overovania dodávateľského reťazca
- **Využiť bezpečnostné riešenia Microsoftu**: Porozumieť a nasadiť Microsoft Prompt Shields, Azure Content Safety a GitHub Advanced Security na ochranu MCP pracovných záťaží
- **Overiť bezpečnosť nástrojov**: Rozpoznať dôležitosť validácie metadát nástrojov, monitorovania dynamických zmien a obrany proti nepriamym útokom injekcie promptov
- **Integrovať najlepšie praktiky**: Kombinovať zavedené bezpečnostné základy (bezpečné kódovanie, spevnenie serverov, nulová dôvera) s MCP-špecifickými opatreniami na komplexnú ochranu

# MCP Bezpečnostná architektúra a opatrenia

Moderné implementácie MCP vyžadujú vrstvené bezpečnostné prístupy, ktoré riešia tradičné softvérové bezpečnostné hrozby aj AI-špecifické riziká. Rýchlo sa vyvíjajúca špecifikácia MCP neustále zdokonaľuje svoje bezpečnostné opatrenia, čím umožňuje lepšiu integráciu s podnikovou bezpečnostnou architektúrou a zavedenými najlepšími praktikami.

Výskum z [Microsoft Digital Defense Report](https://aka.ms/mddr) ukazuje, že **98 % hlásených narušení by bolo možné predísť robustnou bezpečnostnou hygienou**. Najúčinnejšia ochranná stratégia kombinuje základné bezpečnostné praktiky s MCP-špecifickými opatreniami—osvedčené základné bezpečnostné opatrenia zostávajú najvýznamnejšie pri znižovaní celkového bezpečnostného rizika.

## Aktuálny bezpečnostný stav

> **Note:** Tieto informácie odrážajú bezpečnostné štandardy MCP k **18. augustu 2025**. Protokol MCP sa rýchlo vyvíja a budúce implementácie môžu zaviesť nové autentifikačné vzory a vylepšené opatrenia. Vždy sa odkazujte na aktuálnu [MCP špecifikáciu](https://spec.modelcontextprotocol.io/), [MCP GitHub repozitár](https://github.com/modelcontextprotocol) a [dokumentáciu najlepších bezpečnostných praktík](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) pre najnovšie pokyny.

### Vývoj autentifikácie MCP

Špecifikácia MCP sa výrazne vyvinula vo svojom prístupe k autentifikácii a autorizácii:

- **Pôvodný prístup**: Skoré špecifikácie vyžadovali od vývojárov implementáciu vlastných autentifikačných serverov, pričom MCP servery fungovali ako OAuth 2.0 Authorization Servers, ktoré priamo spravovali autentifikáciu používateľov
- **Aktuálny štandard (2025-06-18)**: Aktualizovaná špecifikácia umožňuje MCP serverom delegovať autentifikáciu na externých poskytovateľov identity (ako Microsoft Entra ID), čím sa zlepšuje bezpečnostný postoj a znižuje zložitosť implementácie
- **Transport Layer Security**: Rozšírená podpora bezpečných transportných mechanizmov s vhodnými autentifikačnými vzormi pre lokálne (STDIO) aj vzdialené (Streamable HTTP) pripojenia

## Bezpečnosť autentifikácie a autorizácie

### Aktuálne bezpečnostné výzvy

Moderné implementácie MCP čelia viacerým výzvam v oblasti autentifikácie a autorizácie:

### Riziká a hrozby

- **Nesprávne nakonfigurovaná logika autorizácie**: Chybná implementácia autorizácie v MCP serveroch môže odhaliť citlivé údaje a nesprávne aplikovať prístupové kontroly
- **Kompromitácia OAuth tokenov**: Krádež tokenov lokálneho MCP servera umožňuje útočníkom vydávať sa za servery a pristupovať k downstream službám
- **Zraniteľnosti pri prechode tokenov**: Nesprávne spracovanie tokenov vytvára obchádzanie bezpečnostných kontrol a medzery v zodpovednosti
- **Nadmerné oprávnenia**: MCP servery s nadmernými oprávneniami porušujú princíp minimálnych oprávnení a rozširujú povrch útoku

#### Prechod tokenov: Kritický anti-vzor

**Prechod tokenov je výslovne zakázaný** v aktuálnej špecifikácii autorizácie MCP kvôli závažným bezpečnostným dôsledkom:

##### Obchádzanie bezpečnostných kontrol
- MCP servery a downstream API implementujú kritické bezpečnostné opatrenia (obmedzovanie rýchlosti, validácia požiadaviek, monitorovanie prevádzky), ktoré závisia od správnej validácie tokenov
- Priame použitie tokenov klientom na API obchádza tieto základné ochrany, čím podkopáva bezpečnostnú architektúru

##### Výzvy v oblasti zodpovednosti a auditu  
- MCP servery nemôžu rozlíšiť klientov používajúcich tokeny vydané upstream, čím sa narúšajú auditné stopy
- Logy downstream serverov zdrojov ukazujú zavádzajúce pôvody požiadaviek namiesto skutočných MCP serverov ako sprostredkovateľov
- Vyšetrovanie incidentov a audity súladu sa stávajú výrazne náročnejšími

##### Riziká exfiltrácie údajov
- Nevalidované tvrdenia tokenov umožňujú škodlivým aktérom s ukradnutými tokenmi používať MCP servery ako proxy na exfiltráciu údajov
- Porušenie hraníc dôvery umožňuje neoprávnené vzory prístupu, ktoré obchádzajú zamýšľané bezpečnostné opatrenia

##### Útoky na viaceré služby
- Kompromitované tokeny akceptované viacerými službami umožňujú laterálny pohyb medzi prepojenými systémami
- Predpoklady dôvery medzi službami môžu byť porušené, keď nie je možné overiť pôvod tokenov

### Bezpečnostné opatrenia a zmiernenia

**Kritické bezpečnostné požiadavky:**

> **MANDATORY**: MCP servery **NESMÚ** akceptovať žiadne tokeny, ktoré neboli výslovne vydané pre MCP server

#### Opatrenia autentifikácie a autorizácie

- **Dôkladná revízia autorizácie**: Vykonajte komplexné audity logiky autorizácie MCP serverov, aby ste zabezpečili, že citlivé zdroje môžu pristupovať iba zamýšľaní používatelia a klienti
  - **Príručka implementácie**: [Azure API Management ako autentifikačná brána pre MCP servery](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
  - **Integrácia identity**: [Používanie Microsoft Entra ID na autentifikáciu MCP serverov](https://den.dev/blog/mcp-server-auth-entra-id-session/)

- **Bezpečná správa tokenov**: Implementujte [najlepšie praktiky validácie tokenov a ich životného cyklu od Microsoftu](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)
  - Validujte tvrdenia publika tokenov, aby zodpovedali identite MCP servera
  - Implementujte správnu rotáciu tokenov a politiky ich expirácie
  - Predchádzajte útokom na opakovanie tokenov a neoprávnenému použitiu

- **Chránené úložisko tokenov**: Zabezpečte úložisko tokenov šifrovaním v pokoji aj počas prenosu
  - **Najlepšie praktiky**: [Pokyny na bezpečné úložisko tokenov a šifrovanie](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

#### Implementácia prístupových kontrol

- **Princíp minimálnych oprávnení**: Poskytnite MCP serverom iba minimálne oprávnenia potrebné na zamýšľanú funkčnosť
  - Pravidelné revízie oprávnení a ich aktualizácie na predchádzanie nárastu oprávnení
  - **Dokumentácia Microsoftu**: [Bezpečný prístup na princípe minimálnych oprávnení](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)

- **Role-Based Access Control (RBAC)**: Implementujte jemne zrnité priradenia rolí
  - Obmedzte role na konkrétne zdroje a akcie
  - Vyhnite sa širokým alebo nepotrebným oprávneniam, ktoré rozširujú povrch útoku

- **Kontinuálne monitorovanie oprávnení**: Implementujte priebežné audity prístupu a monitorovanie
  - Monitorujte vzory používania oprávnení na anomálie
  - Rýchlo napravte nadmerné alebo nevyužité oprávnenia

## AI-špecifické bezpečnostné hrozby

### Útoky injekcie promptov a manipulácie nástrojov

Moderné implementácie MCP čelia sofistikovaným AI-špecifickým útokom, ktoré tradičné bezpečnostné opatrenia nedokážu plne riešiť:

#### **Nepriama injekcia promptov (Cross-Domain Prompt Injection)**

**Nepriama injekcia promptov** predstavuje jednu z najkritickejších zraniteľností v MCP-poháňaných AI systémoch. Útočníci vkladajú škodlivé inštrukcie do externého obsahu—dokumentov, webových stránok, e-mailov alebo dátových zdrojov—ktoré AI systémy následne spracovávajú ako legitímne príkazy.

**Scenáre útokov:**
- **Injekcia na základe dokumentov**: Škodlivé inštrukcie skryté v spracovaných dokumentoch, ktoré spúšťajú nežiaduce akcie AI
- **Využitie webového obsahu**: Kompromitované webové stránky obsahujúce vložené prompty, ktoré manipulujú správanie AI pri ich skenovaní
- **Útoky na základe e-mailov**: Škodlivé prompty v e-mailoch, ktoré spôsobujú únik informácií alebo vykonávanie neoprávnených akcií AI asistentmi
- **Kontaminácia dátových zdrojov**: Kompromitované databázy alebo API poskytujúce znečistený obsah AI systémom

**Reálny dopad**: Tieto útoky môžu viesť k exfiltrácii údajov, narušeniu súkromia, generovaniu škodlivého obsahu a manipulácii používateľských interakcií. Pre podrobnú analýzu pozrite [Prompt Injection v MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

![Diagram útoku injekcie promptov](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sk.png)

#### **Útoky na otravu nástrojov**

**Otrava nástrojov** cieli na metadáta, ktoré definujú MCP nástroje, využívajúc spôsob, akým LLM interpretujú popisy nástrojov a parametre na rozhodovanie o ich vykonávaní.

**Mechanizmy útokov:**
- **Manipulácia metadát**: Útočníci vkladajú škodlivé inštrukcie do popisov nástrojov, definícií parametrov alebo príkladov použitia
- **Neviditeľné inštrukcie**: Skryté prompty v metadátach nástrojov, ktoré sú spracované AI modelmi, ale neviditeľné pre ľudských používateľov
- **Dynamická modifikácia nástrojov ("Rug Pulls")**: Nástroje schválené používateľmi sú neskôr upravené na vykonávanie škodlivých akcií bez vedomia používateľa
- **Injekcia parametrov**: Škodlivý obsah vložený do schém parametrov nástrojov, ktorý ovplyvňuje správanie modelu

**Riziká hostovaných serverov**: Vzdialené MCP servery predstavujú zvýšené riziká, pretože definície nástrojov môžu byť aktualizované po počiatočnom schválení používateľom, čím vznikajú scenáre, kde predtým bezpečné nástroje sa stanú škodlivými. Pre komplexnú analýzu pozrite [Útoky na otravu nástrojov (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![Diagram útoku injekcie nástrojov](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sk.png)

#### **Ďalšie AI útoky**

- **Cross-Domain Prompt Injection (XPIA)**: Sofistikované útoky využívajúce obsah z viacerých domén na obchádzanie bezpečnostných opatrení
- **Dynamická modifikácia schopností**: Zmeny schopností nástrojov v reálnom čase, ktoré unikajú počiatočným bezpečnostným hodnoteniam
- **Otrava kontextového okna**: Útoky manipulujúce veľké kontextové okná na skrytie škodlivých inštrukcií
- **Útoky na zmätok modelu**: Využitie obmedzení modelu na vytvorenie nepredvídateľného alebo nebezpečného správania

### Dopad AI bezpečnostných rizík

**Dôsledky s vysokým dopadom:**
- **Exfiltrácia údajov**: Neoprávnený prístup a krádež citlivých podnikových alebo osobných údajov
- **Porušenie súkromia**: Odhalenie osobne identifikovateľných informácií (PII) a dôverných podnikových údajov  
- **Manipulácia systémov**: Nezamýšľané úpravy kritických systémov a pracovných tokov
- **Krádež poverení**: Kompromitácia autentifikačných tokenov a poverení služieb
- **Laterálny pohyb**: Použitie kompromitovaných AI systémov ako pivotov pre širšie útoky na sieť

### Bezpečnostné riešenia Microsoftu pre AI

#### **AI Prompt Shields: Pokročilá ochrana proti útokom inj
- **Generovanie bezpečných relácií**: Používajte kryptograficky bezpečné, nedeterministické ID relácií generované pomocou bezpečných generátorov náhodných čísel  
- **Väzba na používateľa**: Viažte ID relácií na informácie špecifické pre používateľa pomocou formátov ako `<user_id>:<session_id>` na zabránenie zneužitia relácií medzi používateľmi  
- **Správa životného cyklu relácií**: Implementujte správne vypršanie platnosti, rotáciu a zneplatnenie relácií na obmedzenie okien zraniteľnosti  
- **Bezpečnosť prenosu**: Povinné používanie HTTPS pre všetku komunikáciu na zabránenie zachytenia ID relácií  

### Problém zmäteného zástupcu  

**Problém zmäteného zástupcu** nastáva, keď servery MCP fungujú ako autentifikačné proxy medzi klientmi a službami tretích strán, čím vytvárajú príležitosti na obídenie autorizácie prostredníctvom zneužitia statických ID klientov.  

#### **Mechanizmy útoku a riziká**  

- **Obídenie súhlasu na základe cookies**: Predchádzajúca autentifikácia používateľa vytvára cookies súhlasu, ktoré útočníci zneužívajú prostredníctvom škodlivých požiadaviek na autorizáciu s upravenými URI presmerovania  
- **Krádež autorizačného kódu**: Existujúce cookies súhlasu môžu spôsobiť, že autorizačné servery preskočia obrazovky súhlasu a presmerujú kódy na koncové body kontrolované útočníkom  
- **Neoprávnený prístup k API**: Ukradnuté autorizačné kódy umožňujú výmenu tokenov a vydávanie sa za používateľa bez výslovného schválenia  

#### **Stratégie zmiernenia**  

**Povinné opatrenia:**  
- **Požiadavky na výslovný súhlas**: Proxy servery MCP používajúce statické ID klientov **MUSIA** získať súhlas používateľa pre každého dynamicky registrovaného klienta  
- **Implementácia bezpečnosti OAuth 2.1**: Dodržiavajte aktuálne bezpečnostné postupy OAuth vrátane PKCE (Proof Key for Code Exchange) pre všetky požiadavky na autorizáciu  
- **Prísna validácia klientov**: Implementujte dôkladnú validáciu URI presmerovania a identifikátorov klientov na zabránenie zneužitiu  

### Zraniteľnosti pri preposielaní tokenov  

**Preposielanie tokenov** predstavuje explicitný anti-vzor, pri ktorom servery MCP akceptujú tokeny klientov bez správnej validácie a preposielajú ich na downstream API, čím porušujú špecifikácie autorizácie MCP.  

#### **Bezpečnostné dôsledky**  

- **Obídenie kontrol**: Priame použitie tokenov klientov na API obchádza kritické kontroly obmedzenia rýchlosti, validácie a monitorovania  
- **Korupcia auditných záznamov**: Tokeny vydané upstreamom znemožňujú identifikáciu klientov, čím narúšajú schopnosti vyšetrovania incidentov  
- **Proxy na exfiltráciu dát**: Nevalidované tokeny umožňujú škodlivým aktérom používať servery ako proxy na neoprávnený prístup k dátam  
- **Porušenie hraníc dôvery**: Predpoklady dôvery downstream služieb môžu byť porušené, keď nie je možné overiť pôvod tokenov  
- **Rozšírenie útokov na viaceré služby**: Kompromitované tokeny akceptované naprieč viacerými službami umožňujú laterálny pohyb  

#### **Požadované bezpečnostné opatrenia**  

**Nepostrádateľné požiadavky:**  
- **Validácia tokenov**: Servery MCP **NESMÚ** akceptovať tokeny, ktoré neboli výslovne vydané pre server MCP  
- **Overenie publika**: Vždy overujte, či tvrdenia o publiku tokenov zodpovedajú identite servera MCP  
- **Správny životný cyklus tokenov**: Implementujte krátkodobé prístupové tokeny s bezpečnými praktikami rotácie  

## Bezpečnosť dodávateľského reťazca pre AI systémy  

Bezpečnosť dodávateľského reťazca sa vyvinula nad rámec tradičných softvérových závislostí a zahŕňa celý ekosystém AI. Moderné implementácie MCP musia dôsledne overovať a monitorovať všetky komponenty súvisiace s AI, pretože každý z nich predstavuje potenciálne zraniteľnosti, ktoré by mohli ohroziť integritu systému.  

### Rozšírené komponenty dodávateľského reťazca AI  

**Tradičné softvérové závislosti:**  
- Open-source knižnice a rámce  
- Kontajnerové obrazy a základné systémy  
- Vývojové nástroje a build pipeline  
- Komponenty infraštruktúry a služby  

**AI-špecifické prvky dodávateľského reťazca:**  
- **Základné modely**: Predtrénované modely od rôznych poskytovateľov vyžadujúce overenie pôvodu  
- **Embedding služby**: Externé služby na vektorizáciu a semantické vyhľadávanie  
- **Poskytovatelia kontextu**: Zdroje dát, znalostné bázy a úložiská dokumentov  
- **API tretích strán**: Externé AI služby, ML pipeline a koncové body na spracovanie dát  
- **Artefakty modelov**: Váhy, konfigurácie a varianty modelov po jemnom doladení  
- **Zdroje tréningových dát**: Dátové sady použité na tréning a jemné doladenie modelov  

### Komplexná stratégia bezpečnosti dodávateľského reťazca  

#### **Overenie komponentov a dôveryhodnosť**  
- **Validácia pôvodu**: Overte pôvod, licencovanie a integritu všetkých AI komponentov pred ich integráciou  
- **Bezpečnostné hodnotenie**: Vykonajte skenovanie zraniteľností a bezpečnostné kontroly pre modely, zdroje dát a AI služby  
- **Analýza reputácie**: Vyhodnoťte bezpečnostnú históriu a praktiky poskytovateľov AI služieb  
- **Overenie súladu**: Uistite sa, že všetky komponenty spĺňajú bezpečnostné a regulačné požiadavky organizácie  

#### **Bezpečné nasadzovacie pipeline**  
- **Automatizovaná bezpečnosť CI/CD**: Integrujte bezpečnostné skenovanie do automatizovaných pipeline nasadzovania  
- **Integrita artefaktov**: Implementujte kryptografické overenie všetkých nasadených artefaktov (kód, modely, konfigurácie)  
- **Postupné nasadzovanie**: Používajte progresívne stratégie nasadzovania s bezpečnostnou validáciou na každom kroku  
- **Dôveryhodné úložiská artefaktov**: Nasadzujte iba z overených, bezpečných úložísk a registrácií artefaktov  

#### **Kontinuálne monitorovanie a reakcia**  
- **Skenovanie závislostí**: Priebežné monitorovanie zraniteľností všetkých softvérových a AI komponentov  
- **Monitorovanie modelov**: Kontinuálne hodnotenie správania modelov, odchýlok výkonu a bezpečnostných anomálií  
- **Sledovanie zdravia služieb**: Monitorovanie externých AI služieb z hľadiska dostupnosti, bezpečnostných incidentov a zmien politík  
- **Integrácia hrozieb**: Zahrnutie informačných kanálov o hrozbách špecifických pre AI a ML riziká  

#### **Kontrola prístupu a princíp minimálnych oprávnení**  
- **Oprávnenia na úrovni komponentov**: Obmedzte prístup k modelom, dátam a službám na základe obchodnej potreby  
- **Správa účtov služieb**: Implementujte dedikované účty služieb s minimálnymi potrebnými oprávneniami  
- **Segmentácia siete**: Izolujte AI komponenty a obmedzte sieťový prístup medzi službami  
- **Kontroly API brány**: Používajte centralizované API brány na kontrolu a monitorovanie prístupu k externým AI službám  

#### **Reakcia na incidenty a obnova**  
- **Postupy rýchlej reakcie**: Zavedené procesy na opravu alebo výmenu kompromitovaných AI komponentov  
- **Rotácia poverení**: Automatizované systémy na rotáciu tajomstiev, API kľúčov a poverení služieb  
- **Schopnosti návratu**: Možnosť rýchlo sa vrátiť k predchádzajúcim známym dobrým verziám AI komponentov  
- **Obnova po narušení dodávateľského reťazca**: Špecifické postupy na reakciu na kompromitácie upstream AI služieb  

### Nástroje a integrácia bezpečnosti od Microsoftu  

**GitHub Advanced Security** poskytuje komplexnú ochranu dodávateľského reťazca vrátane:  
- **Skenovanie tajomstiev**: Automatizovaná detekcia poverení, API kľúčov a tokenov v úložiskách  
- **Skenovanie závislostí**: Hodnotenie zraniteľností pre open-source závislosti a knižnice  
- **Analýza CodeQL**: Statická analýza kódu na bezpečnostné zraniteľnosti a problémy s kódovaním  
- **Prehľad dodávateľského reťazca**: Viditeľnosť zdravia a bezpečnostného stavu závislostí  

**Integrácia Azure DevOps a Azure Repos:**  
- Bezproblémová integrácia bezpečnostného skenovania naprieč vývojovými platformami Microsoftu  
- Automatizované bezpečnostné kontroly v Azure Pipelines pre AI pracovné zaťaženia  
- Presadzovanie politík pre bezpečné nasadzovanie AI komponentov  

**Interné praktiky Microsoftu:**  
Microsoft implementuje rozsiahle bezpečnostné praktiky dodávateľského reťazca naprieč všetkými produktmi. Viac o osvedčených postupoch sa dozviete v [Cesta k zabezpečeniu softvérového dodávateľského reťazca v Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).  


### **Microsoft Security Solutions**
- [Microsoft Prompt Shields Dokumentácia](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety Služba](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Microsoft Entra ID Bezpečnosť](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najlepšie postupy pre správu tokenov v Azure](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [GitHub Pokročilá bezpečnosť](https://github.com/security/advanced-security)

### **Príručky implementácie a návody**
- [Azure API Management ako autentifikačná brána MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID Autentifikácia s MCP servermi](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Bezpečné ukladanie tokenov a šifrovanie (Video)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### **DevOps a bezpečnosť dodávateľského reťazca**
- [Azure DevOps Bezpečnosť](https://azure.microsoft.com/products/devops)
- [Azure Repos Bezpečnosť](https://azure.microsoft.com/products/devops/repos/)
- [Cesta Microsoftu k bezpečnosti dodávateľského reťazca](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)

## **Dodatočná bezpečnostná dokumentácia**

Pre komplexné bezpečnostné pokyny si pozrite tieto špecializované dokumenty v tejto sekcii:

- **[MCP Najlepšie bezpečnostné postupy 2025](./mcp-security-best-practices-2025.md)** - Kompletné najlepšie postupy pre bezpečnosť MCP implementácií
- **[Implementácia Azure Content Safety](./azure-content-safety-implementation.md)** - Praktické príklady implementácie integrácie Azure Content Safety  
- **[MCP Bezpečnostné kontroly 2025](./mcp-security-controls-2025.md)** - Najnovšie bezpečnostné kontroly a techniky pre nasadenie MCP
- **[Rýchly referenčný sprievodca MCP Najlepšie postupy](./mcp-best-practices.md)** - Rýchly referenčný sprievodca základnými bezpečnostnými postupmi MCP

---

## Čo ďalej

Ďalej: [Kapitola 3: Začíname](../03-GettingStarted/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou služby na automatický preklad [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, uvedomte si, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.