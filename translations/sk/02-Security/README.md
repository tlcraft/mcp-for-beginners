<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:24:21+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sk"
}
-->
# Najlepšie bezpečnostné postupy

Prijatie Model Context Protocol (MCP) prináša výkonné nové možnosti pre aplikácie poháňané AI, ale zároveň predstavuje jedinečné bezpečnostné výzvy, ktoré presahujú tradičné softvérové riziká. Okrem známych aspektov, ako je bezpečné kódovanie, princíp minimálnych práv a bezpečnosť dodávateľského reťazca, MCP a AI pracovné záťaže čelia novým hrozbám, ako sú prompt injection, tool poisoning a dynamické úpravy nástrojov. Tieto riziká môžu viesť k úniku dát, porušeniu súkromia a nežiaducej funkčnosti systému, ak nie sú správne riadené.

Táto lekcia skúma najrelevantnejšie bezpečnostné riziká spojené s MCP — vrátane autentifikácie, autorizácie, nadmerných oprávnení, nepriamych útokov prompt injection a zraniteľností v dodávateľskom reťazci — a poskytuje konkrétne kontroly a osvedčené postupy na ich zmiernenie. Tiež sa naučíte, ako využiť riešenia Microsoftu ako Prompt Shields, Azure Content Safety a GitHub Advanced Security na posilnenie implementácie MCP. Pochopením a aplikovaním týchto opatrení môžete výrazne znížiť pravdepodobnosť bezpečnostného incidentu a zabezpečiť, že vaše AI systémy zostanú spoľahlivé a dôveryhodné.

# Ciele učenia

Na konci tejto lekcie budete vedieť:

- Identifikovať a vysvetliť jedinečné bezpečnostné riziká zavedené Model Context Protocol (MCP), vrátane prompt injection, tool poisoning, nadmerných oprávnení a zraniteľností dodávateľského reťazca.
- Opísať a aplikovať účinné opatrenia na zmiernenie bezpečnostných rizík MCP, ako sú robustná autentifikácia, princíp minimálnych práv, bezpečná správa tokenov a overovanie dodávateľského reťazca.
- Pochopiť a využiť riešenia Microsoftu ako Prompt Shields, Azure Content Safety a GitHub Advanced Security na ochranu MCP a AI pracovných záťaží.
- Uvedomiť si dôležitosť validácie metadát nástrojov, monitorovania dynamických zmien a obrany proti nepriamym útokom prompt injection.
- Integrovať osvedčené bezpečnostné postupy — ako bezpečné kódovanie, hardening serverov a architektúru zero trust — do vašej implementácie MCP na zníženie pravdepodobnosti a dopadu bezpečnostných incidentov.

# Bezpečnostné kontroly MCP

Každý systém, ktorý má prístup k dôležitým zdrojom, prináša implicitné bezpečnostné výzvy. Bezpečnostné výzvy sa zvyčajne riešia správnym použitím základných bezpečnostných kontrol a konceptov. Keďže MCP je len nedávno definovaný, jeho špecifikácia sa veľmi rýchlo mení a vyvíja. Postupom času sa bezpečnostné kontroly v rámci MCP zdokonalia, čo umožní lepšiu integráciu s podnikovými a osvedčenými bezpečnostnými architektúrami a postupmi.

Výskum publikovaný v [Microsoft Digital Defense Report](https://aka.ms/mddr) uvádza, že 98 % hlásených incidentov by bolo možné zabrániť dôslednou bezpečnostnou hygienou a najlepšou ochranou proti akémukoľvek narušeniu je správne nastavenie základnej bezpečnostnej hygieny, osvedčených postupov bezpečného kódovania a bezpečnosti dodávateľského reťazca — tieto overené postupy stále majú najväčší vplyv na znižovanie bezpečnostného rizika.

Pozrime sa na niektoré spôsoby, ako začať riešiť bezpečnostné riziká pri prijímaní MCP.

# MCP serverová autentifikácia (ak bola vaša implementácia MCP pred 26. aprílom 2025)

> **Note:** Nasledujúce informácie sú platné k 26. aprílu 2025. MCP protokol sa neustále vyvíja a budúce implementácie môžu zaviesť nové vzory autentifikácie a kontroly. Pre najnovšie aktualizácie a usmernenia vždy odkazujte na [MCP Specification](https://spec.modelcontextprotocol.io/) a oficiálne [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problém
Pôvodná špecifikácia MCP predpokladala, že vývojári si napíšu vlastný autentifikačný server. To vyžadovalo znalosť OAuth a súvisiacich bezpečnostných obmedzení. MCP servery fungovali ako OAuth 2.0 autorizačné servery, ktoré spravovali autentifikáciu používateľa priamo, namiesto delegovania na externú službu, ako je Microsoft Entra ID. Od 26. apríla 2025 aktualizácia špecifikácie MCP umožňuje MCP serverom delegovať autentifikáciu používateľa na externú službu.

### Riziká
- Nesprávne nakonfigurovaná autorizačná logika na MCP serveri môže viesť k odhaleniu citlivých údajov a nesprávne aplikovaným prístupovým kontrolám.
- Krádež OAuth tokenu na lokálnom MCP serveri. Ak je token ukradnutý, môže byť použitý na vydávanie sa za MCP server a prístup k zdrojom a dátam, pre ktoré je token určený.

### Opatrenia na zmiernenie
- **Preverte a spevnite autorizačnú logiku:** Dôkladne auditujte implementáciu autorizácie na vašom MCP serveri, aby mali prístup len zamýšľaní používatelia a klienti k citlivým zdrojom. Pre praktické rady pozrite [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) a [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Dodržiavajte bezpečné praktiky správy tokenov:** Postupujte podľa [Microsoft’s best practices for token validation and lifetime](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby ste predišli zneužitiu prístupových tokenov a znížili riziko opätovného použitia alebo krádeže tokenov.
- **Chráňte ukladanie tokenov:** Tokeny vždy ukladajte bezpečne a používajte šifrovanie na ich ochranu v pokoji aj počas prenosu. Pre tipy na implementáciu pozrite [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadmerné oprávnenia pre MCP servery

### Problém
MCP servery mohli dostať nadmerné oprávnenia k službe alebo zdroju, ku ktorému pristupujú. Napríklad MCP server, ktorý je súčasťou AI predajnej aplikácie a pripája sa k podnikovému dátovému skladu, by mal mať prístup obmedzený len na predajné údaje a nemal by mať prístup ku všetkým súborom v sklade. Vráťme sa k princípu minimálnych práv (jeden z najstarších bezpečnostných princípov), žiadny zdroj by nemal mať oprávnenia nad rámec toho, čo je potrebné na vykonanie jeho úloh. AI prináša v tejto oblasti zvýšenú výzvu, pretože na zabezpečenie flexibility môže byť náročné presne definovať potrebné oprávnenia.

### Riziká
- Poskytnutie nadmerných oprávnení môže umožniť únik alebo úpravu dát, ku ktorým MCP server nemal mať prístup. Môže to byť aj problém súkromia, ak ide o osobné identifikovateľné informácie (PII).

### Opatrenia na zmiernenie
- **Aplikujte princíp minimálnych práv:** Udeľujte MCP serveru iba minimálne oprávnenia potrebné na vykonanie jeho úloh. Pravidelne tieto oprávnenia kontrolujte a aktualizujte, aby neprekročili potrebnú mieru. Pre podrobné usmernenia pozrite [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Používajte Role-Based Access Control (RBAC):** Priraďte MCP serveru roly úzko viazané na konkrétne zdroje a akcie, vyhnite sa širokým alebo zbytočným oprávneniam.
- **Monitorujte a auditujte oprávnenia:** Neustále sledujte využívanie oprávnení a auditujte prístupové logy, aby ste včas odhalili a odstránili nadmerné alebo nepoužívané oprávnenia.

# Nepriame útoky prompt injection

### Problém

Zlovestné alebo kompromitované MCP servery môžu predstavovať významné riziká tým, že vystavujú zákaznícke dáta alebo umožňujú nežiaduce akcie. Tieto riziká sú obzvlášť relevantné pri AI a MCP pracovných záťažiach, kde:

- **Prompt Injection útoky:** Útočníci vkladajú škodlivé inštrukcie do promptov alebo externého obsahu, čo spôsobuje, že AI systém vykoná neplánované akcie alebo uniknú citlivé údaje. Viac: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Útočníci manipulujú s metadátami nástrojov (napr. popisy alebo parametre), aby ovplyvnili správanie AI, potenciálne obchádzali bezpečnostné kontroly alebo unikali dáta. Podrobnosti: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Škodlivé inštrukcie sú vložené do dokumentov, webových stránok alebo emailov, ktoré AI spracováva, čo vedie k úniku alebo manipulácii dát.
- **Dynamické úpravy nástrojov (Rug Pulls):** Definície nástrojov môžu byť zmenené po schválení používateľom, čo zavádza nové škodlivé správanie bez vedomia používateľa.

Tieto zraniteľnosti zdôrazňujú potrebu robustnej validácie, monitorovania a bezpečnostných kontrol pri integrácii MCP serverov a nástrojov do vášho prostredia. Pre podrobnejší prehľad pozrite uvedené odkazy.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sk.png)

**Nepriama prompt injection** (známa tiež ako cross-domain prompt injection alebo XPIA) je kritická zraniteľnosť v generatívnych AI systémoch, vrátane tých používajúcich Model Context Protocol (MCP). Pri tomto útoku sú škodlivé inštrukcie skryté v externom obsahu — ako sú dokumenty, webové stránky alebo emaily. Keď AI systém tento obsah spracuje, môže tieto vložené inštrukcie interpretovať ako legitímne používateľské príkazy, čo vedie k neplánovaným akciám, ako je únik dát, generovanie škodlivého obsahu alebo manipulácia používateľských interakcií. Pre detailné vysvetlenie a príklady zo života pozrite [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Obzvlášť nebezpečnou formou tohto útoku je **Tool Poisoning**. Tu útočníci vkladajú škodlivé inštrukcie do metadát MCP nástrojov (napríklad do popisov alebo parametrov). Keďže veľké jazykové modely (LLM) sa na základe týchto metadát rozhodujú, ktoré nástroje vyvolať, kompromitované popisy môžu oklamať model a spustiť neautorizované volania nástrojov alebo obísť bezpečnostné kontroly. Tieto manipulácie sú často pre koncových používateľov neviditeľné, no AI systém ich môže interpretovať a konať podľa nich. Toto riziko je zvýšené v hosťovaných MCP serverových prostrediach, kde sa definície nástrojov môžu meniť po schválení používateľom — situácia nazývaná aj "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takom prípade môže byť nástroj, ktorý bol pôvodne bezpečný, neskôr upravený na škodlivé akcie, ako je únik dát alebo zmena správania systému, bez vedomia používateľa. Viac o tomto vektore útoku nájdete v [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sk.png)

## Riziká
Neplánované akcie AI predstavujú rôzne bezpečnostné riziká, vrátane úniku dát a porušenia súkromia.

### Opatrenia na zmiernenie
### Použitie prompt shields na ochranu proti nepriamym prompt injection útokom
-----------------------------------------------------------------------------

**AI Prompt Shields** sú riešenie vyvinuté spoločnosťou Microsoft na obranu proti priamym aj nepriamym prompt injection útokom. Pomáhajú prostredníctvom:

1.  **Detekcie a filtrovania:** Prompt Shields využívajú pokročilé algoritmy strojového učenia a spracovania prirodzeného jazyka na detekciu a filtrovanie škodlivých inštrukcií vložených v externom obsahu, ako sú dokumenty, webové stránky alebo emaily.
    
2.  **Spotlighting:** Táto technika pomáha AI systému rozlíšiť platné systémové inštrukcie od potenciálne nedôveryhodných externých vstupov. Transformáciou vstupného textu tak, aby bol pre model relevantnejší, Spotlighting zabezpečuje lepšiu identifikáciu a ignorovanie škodlivých inštrukcií.
    
3.  **Delimitery a datamarking:** Zaradenie delimiterov do systémovej správy explicitne určuje polohu vstupného textu, čo pomáha AI systému rozpoznať a oddeliť používateľské vstupy od potenciálne škodlivého externého obsahu. Datamarking rozširuje tento koncept použitím špeciálnych značiek na vyznačenie hraníc dôveryhodných a nedôveryhodných dát.
    
4.  **Kontinuálne monitorovanie a aktualizácie:** Microsoft neustále sleduje a aktualizuje Prompt Shields, aby reagoval na nové a vyvíjajúce sa hrozby. Tento proaktívny prístup zabezpečuje, že obrany zostávajú účinné proti najnovším technikám útokov.
    
5. **Integrácia s Azure Content Safety:** Prompt Shields sú súčasťou širšieho balíka Azure AI Content Safety, ktorý poskytuje ďalšie nástroje na detekciu pokusov o jailbreak, škodlivý obsah a iné bezpečnostné riziká v AI aplikáciách.

Viac o AI prompt shields si môžete prečítať v [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.sk.png)

### Bezpečnosť dodávateľského reťazca

Bezpečnosť dodávateľského reťazca zostáva kľúčová aj v ére AI, no rozsah toho, čo sa považuje za váš dodávateľský reťazec, sa rozšíril. Okrem tradičných balíkov kódu musíte teraz dôsledne overovať a monitorovať všetky AI súvisiace komponenty, vrátane základných modelov, embedding služieb, poskytovateľov kontextu a API tretích strán. Každý z týchto prvkov môže predstavovať zraniteľnosti alebo riziká, ak nie sú správne riadené.

**Kľúčové postupy bezpečnosti dodávateľského reťazca pre AI a MCP:**
- **Overte všetky komponenty pred integráciou:** To zahŕňa nielen open-source knižnice, ale aj AI modely, dátové zdroje a externé API. Vždy kontrolujte pôvod, licencovanie a známe zraniteľnosti.
- **Udržiavajte bezpečné nasadzovacie pipeline:** Používajte automatizované CI/CD pipeline s integrovaným bezpečnostným skenovaním na včasné odhalenie problémov. Zabezpečte, že do produkcie sú nasadzované len dôveryhodné artefakty.
- **Priebežne monitorujte a auditujte:** Implementujte nepretržité sledovanie všetkých závislostí, vrátane modelov a dátových služieb, aby ste detegovali nové zraniteľnosti alebo útoky na dodávateľský reťazec.
- **Aplikujte princíp minimálnych práv a prístupové kontroly
- [OWASP Top 10 pre LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Cesta k zabezpečeniu dodávateľského reťazca softvéru v Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Zabezpečený prístup s minimálnymi právami (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najlepšie postupy pre overovanie tokenov a ich životnosť](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Použitie bezpečného ukladania tokenov a ich šifrovanie (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management ako autentifikačná brána pre MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Použitie Microsoft Entra ID na autentifikáciu s MCP servermi](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Ďalej

Ďalej: [Kapitola 3: Začíname](/03-GettingStarted/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.