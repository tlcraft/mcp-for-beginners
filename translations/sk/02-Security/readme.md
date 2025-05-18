<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:51:15+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "sk"
}
-->
# Najlepšie praktiky v oblasti bezpečnosti

Prijatie protokolu Model Context Protocol (MCP) prináša silné nové schopnosti pre aplikácie riadené AI, ale tiež zavádza jedinečné bezpečnostné výzvy, ktoré presahujú tradičné riziká softvéru. Okrem už zavedených obáv, ako je bezpečné kódovanie, princíp najmenších privilégií a bezpečnosť dodávateľského reťazca, MCP a pracovné zaťaženia AI čelia novým hrozbám, ako sú promptová injekcia, otrava nástrojov a dynamická úprava nástrojov. Tieto riziká môžu viesť k exfiltrácii dát, narušeniu súkromia a nežiaducemu správaniu systému, ak nie sú správne riadené.

Táto lekcia skúma najrelevantnejšie bezpečnostné riziká spojené s MCP—vrátane autentifikácie, autorizácie, nadmerných povolení, nepriamej promptovej injekcie a zraniteľností dodávateľského reťazca—a poskytuje praktické opatrenia a najlepšie praktiky na ich zmiernenie. Tiež sa naučíte, ako využiť riešenia Microsoft, ako sú Prompt Shields, Azure Content Safety a GitHub Advanced Security, na posilnenie vašej implementácie MCP. Pochopením a aplikovaním týchto opatrení môžete výrazne znížiť pravdepodobnosť bezpečnostného narušenia a zabezpečiť, aby vaše AI systémy zostali robustné a dôveryhodné.

# Ciele učenia

Na konci tejto lekcie budete schopní:

- Identifikovať a vysvetliť jedinečné bezpečnostné riziká zavedené protokolom Model Context Protocol (MCP), vrátane promptovej injekcie, otravy nástrojov, nadmerných povolení a zraniteľností dodávateľského reťazca.
- Opísať a aplikovať efektívne zmierňujúce opatrenia pre bezpečnostné riziká MCP, ako sú robustná autentifikácia, princíp najmenších privilégií, bezpečné riadenie tokenov a overovanie dodávateľského reťazca.
- Pochopiť a využiť riešenia Microsoft, ako sú Prompt Shields, Azure Content Safety a GitHub Advanced Security, na ochranu MCP a pracovných zaťažení AI.
- Rozpoznať dôležitosť overovania metaúdajov nástrojov, monitorovania dynamických zmien a obrany proti útokom nepriamej promptovej injekcie.
- Integrovať zavedené bezpečnostné najlepšie praktiky—ako je bezpečné kódovanie, spevnenie servera a architektúra nulovej dôvery—do vašej implementácie MCP na zníženie pravdepodobnosti a dopadu bezpečnostných narušení.

# Bezpečnostné opatrenia MCP

Každý systém, ktorý má prístup k dôležitým zdrojom, má implicitné bezpečnostné výzvy. Bezpečnostné výzvy je možné všeobecne riešiť správnou aplikáciou základných bezpečnostných opatrení a konceptov. Keďže MCP je novodefinovaný, špecifikácia sa veľmi rýchlo mení a vyvíja. Nakoniec bezpečnostné opatrenia v ňom dozrejú, čo umožní lepšiu integráciu s podnikovou a zavedenou bezpečnostnou architektúrou a najlepšími praktikami.

Výskum publikovaný v [Microsoft Digital Defense Report](https://aka.ms/mddr) uvádza, že 98% nahlásených narušení by bolo zabránených robustnou bezpečnostnou hygienou a najlepšou ochranou proti akémukoľvek druhu narušenia je správne nastaviť základnú bezpečnostnú hygienu, najlepšie praktiky bezpečného kódovania a bezpečnosť dodávateľského reťazca—tieto osvedčené praktiky, o ktorých už vieme, stále majú najväčší vplyv na zníženie bezpečnostného rizika.

Pozrime sa na niektoré spôsoby, ako môžete začať riešiť bezpečnostné riziká pri prijatí MCP.

# Autentifikácia servera MCP (ak vaša implementácia MCP bola pred 26. aprílom 2025)

> **Note:** Nasledujúce informácie sú správne k 26. aprílu 2025. Protokol MCP sa neustále vyvíja a budúce implementácie môžu zaviesť nové vzory autentifikácie a opatrenia. Pre najnovšie aktualizácie a usmernenia vždy odkazujte na [MCP Specification](https://spec.modelcontextprotocol.io/) a oficiálny [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Vyhlásenie problému 
Pôvodná špecifikácia MCP predpokladala, že vývojári by napísali vlastný autentifikačný server. To vyžadovalo znalosti OAuth a súvisiacich bezpečnostných obmedzení. MCP servery fungovali ako OAuth 2.0 Authorization Servers, priamo spravovali požadovanú autentifikáciu používateľa, namiesto toho, aby ju delegovali na externú službu, ako je Microsoft Entra ID. Od 26. apríla 2025, aktualizácia špecifikácie MCP umožňuje MCP serverom delegovať autentifikáciu používateľa na externú službu.

### Riziká
- Nesprávne nakonfigurovaná logika autorizácie v MCP serveri môže viesť k expozícii citlivých dát a nesprávne aplikovaným kontrolám prístupu.
- Krádež OAuth tokenu na lokálnom MCP serveri. Ak je token ukradnutý, môže byť použitý na vydávanie sa za MCP server a prístup k zdrojom a dátam zo služby, pre ktorú je OAuth token určený.

### Zmierňujúce opatrenia
- **Preverenie a spevnenie logiky autorizácie:** Dôkladne auditujte implementáciu autorizácie vášho MCP servera, aby ste zabezpečili, že len zamýšľaní používatelia a klienti môžu pristupovať k citlivým zdrojom. Pre praktické usmernenie, pozrite si [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) a [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Presadzovanie bezpečných praktík tokenov:** Dodržiavajte [najlepšie praktiky Microsoftu pre validáciu tokenov a ich životnosť](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens), aby ste zabránili zneužitiu prístupových tokenov a znížili riziko opätovného prehratia alebo krádeže tokenu.
- **Ochrana úložiska tokenov:** Vždy ukladajte tokeny bezpečne a používajte šifrovanie na ich ochranu v pokoji a pri prenose. Pre tipy na implementáciu, pozrite si [Použitie bezpečného úložiska tokenov a šifrovanie tokenov](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Nadmerné povolenia pre MCP servery

### Vyhlásenie problému
MCP servery mohli byť oprávnené nadmernými povoleniami k službe/zdroju, ku ktorému pristupujú. Napríklad, MCP server, ktorý je súčasťou AI predajnej aplikácie, ktorá sa pripája k podnikovej dátovej úložisku, by mal mať prístup obmedzený na predajné dáta a nemal by mať povolený prístup ku všetkým súborom v úložisku. Vychádzajúc z princípu najmenších privilégií (jedného z najstarších bezpečnostných princípov), žiadny zdroj by nemal mať povolenia nad rámec toho, čo je potrebné na vykonanie úloh, pre ktoré bol určený. AI predstavuje zvýšenú výzvu v tomto priestore, pretože umožňuje flexibilitu, je ťažké definovať presné povolenia, ktoré sú potrebné.

### Riziká 
- Poskytnutie nadmerných povolení môže umožniť exfiltráciu alebo zmenu dát, ku ktorým MCP server nemal byť schopný pristupovať. To by tiež mohlo byť problémom súkromia, ak sú dáta osobne identifikovateľné informácie (PII).

### Zmierňujúce opatrenia
- **Aplikujte princíp najmenších privilégií:** Poskytnite MCP serveru len minimálne potrebné povolenia na vykonanie požadovaných úloh. Pravidelne kontrolujte a aktualizujte tieto povolenia, aby ste zabezpečili, že neprekračujú to, čo je potrebné. Pre podrobné usmernenie, pozrite si [Zabezpečenie prístupu s najmenšími privilégiami](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Používajte kontrolu prístupu na základe rolí (RBAC):** Priraďte role MCP serveru, ktoré sú úzko zamerané na konkrétne zdroje a akcie, vyhýbajúc sa širokým alebo nepotrebným povoleniam.
- **Monitorujte a auditujte povolenia:** Nepretržite monitorujte používanie povolení a auditujte prístupové logy, aby ste rýchlo odhalili a napravili nadmerné alebo nevyužité privilégiá.

# Útoky nepriamej promptovej injekcie

### Vyhlásenie problému

Škodlivé alebo kompromitované MCP servery môžu predstavovať významné riziká tým, že vystavujú zákaznícke dáta alebo umožňujú neželané akcie. Tieto riziká sú obzvlášť relevantné v pracovných zaťaženiach založených na AI a MCP, kde:

- **Útoky promptovej injekcie**: Útočníci vkladajú škodlivé pokyny do promptov alebo externého obsahu, čo spôsobuje, že AI systém vykonáva neželané akcie alebo uniká citlivé dáta. Viac informácií: [Promptová injekcia](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrava nástrojov**: Útočníci manipulujú s metaúdajmi nástrojov (ako sú popisy alebo parametre), aby ovplyvnili správanie AI, potenciálne obchádzajúc bezpečnostné opatrenia alebo exfiltrujúce dáta. Podrobnosti: [Otrava nástrojov](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Promptová injekcia medzi doménami**: Škodlivé pokyny sú vložené do dokumentov, webových stránok alebo e-mailov, ktoré sú potom spracované AI, čo vedie k úniku dát alebo manipulácii.
- **Dynamická úprava nástrojov (Rug Pulls)**: Definície nástrojov môžu byť zmenené po schválení používateľom, zavádzajúc nové škodlivé správanie bez vedomia používateľa.

Tieto zraniteľnosti zdôrazňujú potrebu robustného overovania, monitorovania a bezpečnostných opatrení pri integrácii MCP serverov a nástrojov do vášho prostredia. Pre hlbší ponor, pozrite si prepojené referencie vyššie.

**Nepriama promptová injekcia** (známa aj ako promptová injekcia medzi doménami alebo XPIA) je kritická zraniteľnosť v generatívnych AI systémoch, vrátane tých, ktoré používajú protokol Model Context Protocol (MCP). Pri tomto útoku sú škodlivé pokyny skryté v externom obsahu—ako sú dokumenty, webové stránky alebo e-maily. Keď AI systém spracováva tento obsah, môže interpretovať vložené pokyny ako legitímne používateľské príkazy, čo vedie k nežiaducim akciám ako únik dát, generovanie škodlivého obsahu alebo manipulácia s interakciami používateľa. Pre podrobné vysvetlenie a príklady zo skutočného sveta, pozrite si [Promptová injekcia](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Obzvlášť nebezpečnou formou tohto útoku je **Otrava nástrojov**. Tu útočníci vkladajú škodlivé pokyny do metaúdajov nástrojov MCP (ako sú popisy nástrojov alebo parametre). Keďže veľké jazykové modely (LLMs) sa spoliehajú na tieto metaúdaje pri rozhodovaní, ktoré nástroje zavolať, kompromitované popisy môžu oklamať model, aby vykonával neoprávnené volania nástrojov alebo obchádzal bezpečnostné opatrenia. Tieto manipulácie sú často neviditeľné pre koncových používateľov, ale môžu byť interpretované a vykonané AI systémom. Toto riziko je zvýšené v hostovaných prostrediach MCP serverov, kde definície nástrojov môžu byť aktualizované po schválení používateľom—scenár niekedy označovaný ako "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". V takýchto prípadoch, nástroj, ktorý bol predtým bezpečný, môže byť neskôr upravený na vykonávanie škodlivých akcií, ako je exfiltrácia dát alebo zmena správania systému, bez vedomia používateľa. Pre viac o tomto vektorovom útoku, pozrite si [Otrava nástrojov](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

## Riziká
Nežiadúce akcie AI predstavujú rôzne bezpečnostné riziká, ktoré zahŕňajú exfiltráciu dát a narušenie súkromia.

### Zmierňujúce opatrenia
### Použitie promptových štítov na ochranu proti útokom nepriamej promptovej injekcie
-----------------------------------------------------------------------------

**AI Prompt Shields** sú riešenie vyvinuté spoločnosťou Microsoft na obranu proti priamym aj nepriamym útokom promptovej injekcie. Pomáhajú prostredníctvom:

1.  **Detekcia a filtrovanie**: Prompt Shields používajú pokročilé algoritmy strojového učenia a spracovania prirodzeného jazyka na detekciu a filtrovanie škodlivých pokynov vložených do externého obsahu, ako sú dokumenty, webové stránky alebo e-maily.
    
2.  **Spotlighting**: Táto technika pomáha AI systému rozlišovať medzi platnými systémovými pokynmi a potenciálne nedôveryhodnými externými vstupmi. Transformovaním textu vstupu tak, aby bol pre model relevantnejší, Spotlighting zabezpečuje, že AI môže lepšie identifikovať a ignorovať škodlivé pokyny.
    
3.  **Delimiters a Datamarking**: Zahrnutie delimitrov do systémovej správy explicitne určuje umiestnenie textu vstupu, čo pomáha AI systému rozpoznať a oddeliť používateľské vstupy od potenciálne škodlivého externého obsahu. Datamarking rozširuje tento koncept použitím špeciálnych značiek na zvýraznenie hraníc dôveryhodných a nedôveryhodných dát.
    
4.  **Nepretržité monitorovanie a aktualizácie**: Microsoft neustále monitoruje a aktualizuje Prompt Shields, aby riešil nové a vyvíjajúce sa hrozby. Tento proaktívny prístup zabezpečuje, že obrana zostáva účinná proti najnovším technikám útokov.
    
5. **Integrácia s Azure Content Safety:** Prompt Shields sú súčasťou širšieho balíka Azure AI Content Safety, ktorý poskytuje ďalšie nástroje na detekciu pokusov o únik z väzenia, škodlivého obsahu a ďalších bezpečnostných rizík v AI aplikáciách.

Viac o AI promptových štítoch si môžete prečítať v [Prompt Shields dokumentácii](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

### Bezpečnosť dodávateľského reťazca

Bezpečnosť dodávateľského reťazca zostáva základná v ére AI, ale rozsah toho, čo predstavuje váš dodávateľský reťazec, sa rozšíril. Okrem tradičných balíkov kódu musíte teraz dôkladne overovať a monitorovať všetky komponenty súvisiace s AI, vrátane základných modelov, služieb embedovania, poskytovateľov kontextu a API tretích strán. Každý z nich môže zaviesť zraniteľnosti alebo riziká, ak nie sú správne riadené.

**Kľúčové praktiky bezpečnosti dodávateľského reťazca pre AI a MCP:**
- **Overte všetky komponenty pred integráciou:** To zahŕňa nielen open-source knižnice, ale aj AI modely, zdroje dát a externé API. Vždy kontrolujte pôvod, licenciu a známe zraniteľnosti
- [OWASP Top 10 pre LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Pokročilá bezpečnosť](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Cesta k zabezpečeniu dodávateľského reťazca softvéru v Microsofte](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Zabezpečený prístup s minimálnymi privilégiami (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Najlepšie postupy pre overovanie tokenov a ich životnosť](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Používajte bezpečné úložisko tokenov a šifrujte tokeny (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management ako autentifikačná brána pre MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Používanie Microsoft Entra ID na autentifikáciu s MCP servermi](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Ďalej

Ďalej: [Kapitola 3: Začíname](/03-GettingStarted/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, upozorňujeme, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by sa mal považovať za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.