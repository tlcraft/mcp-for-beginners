<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T21:37:58+00:00",
  "source_file": "changelog.md",
  "language_code": "sk"
}
-->
# Zmeny: MCP pre začiatočníkov - učebné osnovy

Tento dokument slúži ako záznam všetkých významných zmien vykonaných v učebných osnovách Model Context Protocol (MCP) pre začiatočníkov. Zmeny sú dokumentované v obrátenom chronologickom poradí (najnovšie zmeny sú uvedené ako prvé).

## 29. september 2025

### MCP Server Database Integration Labs - Komplexná praktická učebná cesta

#### 11-MCPServerHandsOnLabs - Nové kompletné učebné osnovy pre integráciu databáz
- **Kompletná učebná cesta s 13 laboratóriami**: Pridané komplexné praktické učebné osnovy na vytváranie produkčne pripravených MCP serverov s integráciou databázy PostgreSQL
  - **Implementácia v reálnom svete**: Prípadová štúdia Zava Retail Analytics demonštrujúca vzory na podnikovej úrovni
  - **Štruktúrovaný postup učenia**:
    - **Laboratóriá 00-03: Základy** - Úvod, základná architektúra, bezpečnosť a multitenantnosť, nastavenie prostredia
    - **Laboratóriá 04-06: Vytváranie MCP servera** - Návrh databázy a schéma, implementácia MCP servera, vývoj nástrojov  
    - **Laboratóriá 07-09: Pokročilé funkcie** - Integrácia semantického vyhľadávania, testovanie a ladenie, integrácia VS Code
    - **Laboratóriá 10-12: Produkcia a osvedčené postupy** - Stratégie nasadenia, monitorovanie a pozorovateľnosť, optimalizácia a osvedčené postupy
  - **Podnikové technológie**: FastMCP framework, PostgreSQL s pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Pokročilé funkcie**: Row Level Security (RLS), semantické vyhľadávanie, multitenantný prístup k údajom, vektorové embeddings, monitorovanie v reálnom čase

#### Štandardizácia terminológie - Konverzia z modulov na laboratóriá
- **Komplexná aktualizácia dokumentácie**: Systematicky aktualizované všetky README súbory v 11-MCPServerHandsOnLabs na používanie terminológie "Laboratórium" namiesto "Modul"
  - **Hlavičky sekcií**: Aktualizované "Čo tento modul pokrýva" na "Čo toto laboratórium pokrýva" vo všetkých 13 laboratóriách
  - **Popis obsahu**: Zmenené "Tento modul poskytuje..." na "Toto laboratórium poskytuje..." v celej dokumentácii
  - **Ciele učenia**: Aktualizované "Na konci tohto modulu..." na "Na konci tohto laboratória..."
  - **Navigačné odkazy**: Konvertované všetky odkazy "Modul XX:" na "Laboratórium XX:" v krížových odkazoch a navigácii
  - **Sledovanie dokončenia**: Aktualizované "Po dokončení tohto modulu..." na "Po dokončení tohto laboratória..."
  - **Zachované technické odkazy**: Zachované odkazy na Python moduly v konfiguračných súboroch (napr. `"module": "mcp_server.main"`)

#### Vylepšenie študijného sprievodcu (study_guide.md)
- **Vizualizácia učebných osnov**: Pridaná nová sekcia "11. Laboratóriá pre integráciu databáz" s komplexnou vizualizáciou štruktúry laboratórií
- **Štruktúra repozitára**: Aktualizované z desiatich na jedenásť hlavných sekcií s podrobným popisom 11-MCPServerHandsOnLabs
- **Navigačné pokyny**: Rozšírené pokyny na navigáciu, ktoré pokrývajú sekcie 00-11
- **Pokrytie technológií**: Pridané detaily o integrácii FastMCP, PostgreSQL a Azure služieb
- **Výsledky učenia**: Zdôraznený vývoj produkčne pripravených serverov, vzory integrácie databáz a podniková bezpečnosť

#### Vylepšenie hlavného README
- **Terminológia založená na laboratóriách**: Aktualizované hlavné README.md v 11-MCPServerHandsOnLabs na konzistentné používanie štruktúry "Laboratórium"
- **Organizácia učebnej cesty**: Jasný postup od základných konceptov cez pokročilú implementáciu až po nasadenie do produkcie
- **Zameranie na reálny svet**: Dôraz na praktické, praktické učenie s podnikovými vzormi a technológiami

### Zlepšenia kvality a konzistencie dokumentácie
- **Dôraz na praktické učenie**: Posilnený praktický, laboratórny prístup v celej dokumentácii
- **Zameranie na podnikové vzory**: Zdôraznené produkčne pripravené implementácie a úvahy o podnikovej bezpečnosti
- **Integrácia technológií**: Komplexné pokrytie moderných Azure služieb a vzorov AI integrácie
- **Postup učenia**: Jasná, štruktúrovaná cesta od základných konceptov po nasadenie do produkcie

## 26. september 2025

### Vylepšenie prípadových štúdií - Integrácia GitHub MCP Registry

#### Prípadové štúdie (09-CaseStudy/) - Zameranie na rozvoj ekosystému
- **README.md**: Významné rozšírenie s komplexnou prípadovou štúdiou GitHub MCP Registry
  - **Prípadová štúdia GitHub MCP Registry**: Nová komplexná prípadová štúdia skúmajúca spustenie GitHub MCP Registry v septembri 2025
    - **Analýza problému**: Podrobný rozbor fragmentovaných výziev pri objavovaní a nasadzovaní MCP serverov
    - **Architektúra riešenia**: Centralizovaný prístup k registru GitHub s inštaláciou na jedno kliknutie vo VS Code
    - **Dopad na podnikanie**: Merateľné zlepšenia pri onboardingu vývojárov a produktivite
    - **Strategická hodnota**: Zameranie na modulárne nasadenie agentov a interoperabilitu medzi nástrojmi
    - **Rozvoj ekosystému**: Pozicionovanie ako základná platforma pre integráciu agentov
  - **Vylepšená štruktúra prípadových štúdií**: Aktualizované všetkých sedem prípadových štúdií s konzistentným formátovaním a komplexnými popismi
    - Azure AI Travel Agents: Dôraz na orchestráciu viacerých agentov
    - Integrácia Azure DevOps: Zameranie na automatizáciu pracovných postupov
    - Dokumentácia v reálnom čase: Implementácia klienta Python konzoly
    - Interaktívny generátor študijných plánov: Chainlit konverzačná webová aplikácia
    - Dokumentácia v editore: Integrácia VS Code a GitHub Copilot
    - Azure API Management: Vzory integrácie podnikových API
    - GitHub MCP Registry: Rozvoj ekosystému a komunitná platforma
  - **Komplexný záver**: Prepracovaná záverečná sekcia zdôrazňujúca sedem prípadových štúdií pokrývajúcich rôzne dimenzie implementácie MCP
    - Integrácia podnikov, orchestrácia viacerých agentov, produktivita vývojárov
    - Kategorizácia rozvoja ekosystému, vzdelávacích aplikácií
    - Rozšírené poznatky o architektonických vzoroch, implementačných stratégiách a osvedčených postupoch
    - Dôraz na MCP ako zrelý, produkčne pripravený protokol

#### Aktualizácie študijného sprievodcu (study_guide.md)
- **Vizualizácia učebných osnov**: Aktualizovaná myšlienková mapa na zahrnutie GitHub MCP Registry v sekcii Prípadové štúdie
- **Popis prípadových štúdií**: Rozšírené z generických popisov na podrobný rozbor siedmich komplexných prípadových štúdií
- **Štruktúra repozitára**: Aktualizovaná sekcia 10 na odrážanie komplexného pokrytia prípadových štúdií so špecifickými implementačnými detailmi
- **Integrácia zmenového denníka**: Pridaný záznam z 26. septembra 2025 dokumentujúci pridanie GitHub MCP Registry a vylepšenia prípadových štúdií
- **Aktualizácie dátumu**: Aktualizovaný časový údaj v pätičke na odrážanie najnovšej revízie (26. september 2025)

### Zlepšenia kvality dokumentácie
- **Zlepšenie konzistencie**: Štandardizované formátovanie a štruktúra prípadových štúdií vo všetkých siedmich príkladoch
- **Komplexné pokrytie**: Prípadové štúdie teraz pokrývajú podnikové, produktivitu vývojárov a scenáre rozvoja ekosystému
- **Strategické pozicionovanie**: Zdôraznené MCP ako základná platforma pre nasadenie agentických systémov
- **Integrácia zdrojov**: Aktualizované dodatočné zdroje na zahrnutie odkazu na GitHub MCP Registry

## 15. september 2025

### Rozšírenie pokročilých tém - Vlastné transporty a inžinierstvo kontextu

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - Nový pokročilý implementačný sprievodca
- **README.md**: Kompletný implementačný sprievodca pre vlastné transportné mechanizmy MCP
  - **Azure Event Grid Transport**: Komplexná implementácia serverless transportu založeného na udalostiach
    - Príklady v C#, TypeScript a Python s integráciou Azure Functions
    - Vzory architektúry založenej na udalostiach pre škálovateľné MCP riešenia
    - Prijímače webhookov a spracovanie správ na základe push
  - **Azure Event Hubs Transport**: Implementácia transportu pre vysokú priepustnosť streamovania
    - Schopnosti streamovania v reálnom čase pre scenáre s nízkou latenciou
    - Stratégie rozdelenia a správa kontrolných bodov
    - Balenie správ a optimalizácia výkonu
  - **Vzory podnikovej integrácie**: Produkčne pripravené architektonické príklady
    - Distribuované spracovanie MCP naprieč viacerými Azure Functions
    - Hybridné transportné architektúry kombinujúce viac typov transportov
    - Trvanlivosť správ, spoľahlivosť a stratégie spracovania chýb
  - **Bezpečnosť a monitorovanie**: Integrácia Azure Key Vault a vzory pozorovateľnosti
    - Autentifikácia spravovanej identity a prístup s najmenšími oprávneniami
    - Telemetria Application Insights a monitorovanie výkonu
    - Obvodové ističe a vzory tolerancie chýb
  - **Testovacie rámce**: Komplexné testovacie stratégie pre vlastné transporty
    - Jednotkové testovanie s testovacími dvojníkmi a rámcami na simuláciu
    - Integračné testovanie s Azure Test Containers
    - Úvahy o výkonnostnom a záťažovom testovaní

#### Inžinierstvo kontextu (05-AdvancedTopics/mcp-contextengineering/) - Nová disciplína AI
- **README.md**: Komplexný prieskum inžinierstva kontextu ako vznikajúcej oblasti
  - **Základné princípy**: Kompletné zdieľanie kontextu, uvedomovanie si rozhodnutí o akciách a správa kontextového okna
  - **Zladenie s MCP protokolom**: Ako návrh MCP rieši výzvy inžinierstva kontextu
    - Obmedzenia kontextového okna a stratégie progresívneho načítania
    - Určovanie relevantnosti a dynamické získavanie kontextu
    - Spracovanie multimodálneho kontextu a úvahy o bezpečnosti
  - **Implementačné prístupy**: Jednovláknové vs. architektúry viacerých agentov
    - Techniky rozdelenia a prioritizácie kontextu
    - Progresívne načítanie kontextu a kompresné stratégie
    - Vrstvené prístupy ku kontextu a optimalizácia získavania
  - **Rámec merania**: Vznikajúce metriky na hodnotenie efektívnosti kontextu
    - Účinnosť vstupu, výkon, kvalita a úvahy o používateľskej skúsenosti
    - Experimentálne prístupy k optimalizácii kontextu
    - Analýza zlyhaní a metodiky zlepšovania

#### Aktualizácie navigácie učebných osnov (README.md)
- **Vylepšená štruktúra modulov**: Aktualizovaná tabuľka učebných osnov na zahrnutie nových pokročilých tém
  - Pridané položky Inžinierstvo kontextu (5.14) a Vlastné transporty (5.15)
  - Konzistentné formátovanie a navigačné odkazy vo všetkých moduloch
  - Aktualizované popisy na odrážanie aktuálneho rozsahu obsahu

### Vylepšenia štruktúry adresárov
- **Štandardizácia názvov**: Premenované "mcp transport" na "mcp-transport" pre konzistenciu s ostatnými pokročilými témami
- **Organizácia obsahu**: Všetky priečinky 05-AdvancedTopics teraz dodržiavajú konzistentný vzor názvov (mcp-[téma])

### Vylepšenia kvality dokumentácie
- **Zladenie so špecifikáciou MCP**: Všetok nový obsah odkazuje na aktuálnu špecifikáciu MCP 2025-06-18
- **Príklady vo viacerých jazykoch**: Komplexné príklady kódu v C#, TypeScript a Python
- **Zameranie na podniky**: Produkčne pripravené vzory a integrácia Azure cloudových služieb v celom obsahu
- **Vizualizácia dokumentácie**: Diagramy Mermaid pre vizualizáciu architektúry a toku

## 18. august 2025

### Komplexná aktualizácia dokumentácie - Štandardy MCP 2025-06-18

#### MCP Best Practices pre bezpečnosť (02-Security/) - Kompletná modernizácia
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletné prepracovanie v súlade so špecifikáciou MCP 2025-06-18
  - **Povinné požiadavky**: Pridané explicitné požiadavky MUST/MUST NOT z oficiálnej špecifikácie s jasnými vizuálnymi indikátormi
  - **12 základných bezpečnostných praktík**: Preštruktúrované z 15-bodového zoznamu na komplexné bezpečnostné domény
    - Bezpečnosť tokenov a autentifikácia s integráciou externých poskytovateľov identity
    - Správa relácií a bezpečnosť transportu s kryptografickými požiadavkami
    - Ochrana pred AI špecifickými hrozbami s integráciou Microsoft Prompt Shields
    - Kontrola prístupu a oprávnení s princípom najmenších oprávnení
    - Bezpečnosť obsahu a monitorovanie s integráciou Azure Content Safety
    - Bezpečnosť dodávateľského reťazca s komplexnou verifikáciou komponentov
    - Bezpečnosť OAuth a prevencia zmätkových útokov s implementáciou PKCE
    - Reakcia na incidenty a obnova s automatizovanými schopnosťami
    - Súlad a správa s regulačným zosúladením
    - Pokročilé bezpečnostné kontroly s architektúrou nulovej dôvery
    - Integrácia Microsoft Security Ecosystem s komplexnými riešeniami
    - Kontinuálny vývoj bezpečnosti s adaptívnymi praktikami
  - **Microsoft Security Solutions**: Rozšírené pokyny na integráciu Prompt Shields, Azure Content Safety, Entra ID a GitHub Advanced Security
  - **Implementačné zdroje**: Kategorizované komplexné odkazy na zdroje podľa Oficiálnej dokumentácie MCP, Microsoft Security Solutions, Bezpečnostných štandardov a Implementačných sprievodcov

#### Pokročilé bezpečnostné kontroly (02-Security/) - Implementácia na podnikovej úrovni
- **MCP-SECURITY-CONTROLS-2025.md**: Kompletné
- **Vizualné indikátory**: Jasné označenie povinných požiadaviek oproti odporúčaným postupom

#### Základné koncepty (01-CoreConcepts/) - Kompletná modernizácia
- **Aktualizácia verzie protokolu**: Aktualizované na odkazovanie na aktuálnu špecifikáciu MCP 2025-06-18 s verzovaním podľa dátumu (formát YYYY-MM-DD)
- **Zdokonalenie architektúry**: Vylepšené popisy Hostov, Klientov a Serverov, ktoré odrážajú aktuálne vzory architektúry MCP
  - Hosty sú teraz jasne definované ako AI aplikácie koordinujúce viacero pripojení MCP klientov
  - Klienti sú popísaní ako konektory protokolu udržiavajúce vzťahy jeden na jedného so servermi
  - Servery sú rozšírené o scenáre lokálneho a vzdialeného nasadenia
- **Restrukturalizácia primitív**: Kompletná revízia primitív serverov a klientov
  - Primitívy serverov: Zdroje (datové zdroje), Výzvy (šablóny), Nástroje (spustiteľné funkcie) s podrobnými vysvetleniami a príkladmi
  - Primitívy klientov: Sampling (LLM dokončenia), Elicitácia (vstup od používateľa), Logovanie (ladenie/monitorovanie)
  - Aktualizované aktuálnymi vzormi metód objavovania (`*/list`), získavania (`*/get`) a vykonávania (`*/call`)
- **Architektúra protokolu**: Zavedený dvojvrstvový model architektúry
  - Dátová vrstva: Základ JSON-RPC 2.0 s riadením životného cyklu a primitívami
  - Transportná vrstva: STDIO (lokálne) a Streamable HTTP so SSE (vzdialené) transportné mechanizmy
- **Bezpečnostný rámec**: Komplexné bezpečnostné princípy vrátane explicitného súhlasu používateľa, ochrany súkromia dát, bezpečnosti vykonávania nástrojov a bezpečnosti transportnej vrstvy
- **Komunikačné vzory**: Aktualizované správy protokolu na zobrazenie inicializácie, objavovania, vykonávania a notifikačných tokov
- **Príklady kódu**: Obnovené príklady v rôznych jazykoch (.NET, Java, Python, JavaScript) na odrážanie aktuálnych vzorov MCP SDK

#### Bezpečnosť (02-Security/) - Komplexná revízia bezpečnosti  
- **Zladenie so štandardmi**: Úplné zladenie s požiadavkami bezpečnosti špecifikácie MCP 2025-06-18
- **Evolúcia autentifikácie**: Zdokumentovaná evolúcia od vlastných OAuth serverov k delegácii externých poskytovateľov identity (Microsoft Entra ID)
- **Analýza hrozieb špecifických pre AI**: Rozšírené pokrytie moderných útokov na AI
  - Podrobné scenáre útokov na injekciu výziev s príkladmi z reálneho sveta
  - Mechanizmy otravy nástrojov a vzory útokov typu "rug pull"
  - Otrava kontextového okna a útoky na zmätok modelu
- **Riešenia bezpečnosti AI od Microsoftu**: Komplexné pokrytie ekosystému bezpečnosti Microsoftu
  - AI Prompt Shields s pokročilou detekciou, zvýraznením a technikami oddelenia
  - Vzory integrácie Azure Content Safety
  - GitHub Advanced Security na ochranu dodávateľského reťazca
- **Pokročilé zmierňovanie hrozieb**: Podrobné bezpečnostné kontroly pre
  - Únos relácie s MCP-špecifickými scenármi útokov a požiadavkami na kryptografické ID relácie
  - Problémy zmätku zástupcu v scenároch proxy MCP s explicitnými požiadavkami na súhlas
  - Zraniteľnosti pri prechode tokenov s povinnými kontrolami validácie
- **Bezpečnosť dodávateľského reťazca**: Rozšírené pokrytie AI dodávateľského reťazca vrátane základných modelov, služieb embeddings, poskytovateľov kontextu a API tretích strán
- **Základná bezpečnosť**: Vylepšená integrácia s podnikateľskými bezpečnostnými vzormi vrátane architektúry nulovej dôvery a ekosystému bezpečnosti Microsoftu
- **Organizácia zdrojov**: Kategorizované komplexné odkazy na zdroje podľa typu (Oficiálne dokumenty, Štandardy, Výskum, Riešenia Microsoftu, Implementačné príručky)

### Zlepšenia kvality dokumentácie
- **Štruktúrované vzdelávacie ciele**: Vylepšené vzdelávacie ciele s konkrétnymi, akčnými výsledkami 
- **Krížové odkazy**: Pridané odkazy medzi súvisiacimi témami bezpečnosti a základných konceptov
- **Aktuálne informácie**: Aktualizované všetky odkazy na dátumy a špecifikácie na aktuálne štandardy
- **Implementačné pokyny**: Pridané konkrétne, akčné implementačné pokyny v celom oboch sekciách

## 16. júl 2025

### README a vylepšenia navigácie
- Kompletný redizajn navigácie kurikula v README.md
- Nahradené značky `<details>` prístupnejším formátom tabuľky
- Vytvorené alternatívne možnosti rozloženia v novom priečinku "alternative_layouts"
- Pridané príklady navigácie založené na kartách, záložkách a akordeónoch
- Aktualizovaná sekcia štruktúry úložiska na zahrnutie všetkých najnovších súborov
- Vylepšená sekcia "Ako používať toto kurikulum" s jasnými odporúčaniami
- Aktualizované odkazy na špecifikáciu MCP na správne URL
- Pridaná sekcia Kontextové inžinierstvo (5.14) do štruktúry kurikula

### Aktualizácie študijného sprievodcu
- Kompletná revízia študijného sprievodcu na zosúladenie s aktuálnou štruktúrou úložiska
- Pridané nové sekcie pre MCP Klientov a Nástroje, a Populárne MCP Servery
- Aktualizovaná vizuálna mapa kurikula na presné zobrazenie všetkých tém
- Vylepšené popisy pokročilých tém na pokrytie všetkých špecializovaných oblastí
- Aktualizovaná sekcia Prípadové štúdie na odrážanie skutočných príkladov
- Pridaný tento komplexný záznam zmien

### Príspevky komunity (06-CommunityContributions/)
- Pridané podrobné informácie o MCP serveroch pre generovanie obrázkov
- Pridaná komplexná sekcia o používaní Claude vo VSCode
- Pridané pokyny na nastavenie a používanie terminálového klienta Cline
- Aktualizovaná sekcia MCP klientov na zahrnutie všetkých populárnych klientských možností
- Vylepšené príklady príspevkov s presnejšími ukážkami kódu

### Pokročilé témy (05-AdvancedTopics/)
- Organizované všetky špecializované priečinky tém s konzistentným názvoslovím
- Pridané materiály a príklady kontextového inžinierstva
- Pridaná dokumentácia integrácie agenta Foundry
- Vylepšená dokumentácia integrácie bezpečnosti Entra ID

## 11. jún 2025

### Počiatočné vytvorenie
- Vydaná prvá verzia kurikula MCP pre začiatočníkov
- Vytvorená základná štruktúra pre všetkých 10 hlavných sekcií
- Implementovaná vizuálna mapa kurikula pre navigáciu
- Pridané počiatočné vzorové projekty v rôznych programovacích jazykoch

### Začíname (03-GettingStarted/)
- Vytvorené prvé príklady implementácie serverov
- Pridané pokyny na vývoj klientov
- Zahrnuté pokyny na integráciu LLM klientov
- Pridaná dokumentácia integrácie VS Code
- Implementované príklady serverov s udalosťami odosielanými serverom (SSE)

### Základné koncepty (01-CoreConcepts/)
- Pridané podrobné vysvetlenie architektúry klient-server
- Vytvorená dokumentácia kľúčových komponentov protokolu
- Zdokumentované vzory správ v MCP

## 23. máj 2025

### Štruktúra úložiska
- Inicializované úložisko so základnou štruktúrou priečinkov
- Vytvorené README súbory pre každú hlavnú sekciu
- Nastavená infraštruktúra pre preklady
- Pridané obrazové zdroje a diagramy

### Dokumentácia
- Vytvorený počiatočný README.md s prehľadom kurikula
- Pridané CODE_OF_CONDUCT.md a SECURITY.md
- Nastavený SUPPORT.md s pokynmi na získanie pomoci
- Vytvorená predbežná štruktúra študijného sprievodcu

## 15. apríl 2025

### Plánovanie a rámec
- Počiatočné plánovanie kurikula MCP pre začiatočníkov
- Definované vzdelávacie ciele a cieľová skupina
- Načrtnutá 10-sekčná štruktúra kurikula
- Vyvinutý konceptuálny rámec pre príklady a prípadové štúdie
- Vytvorené počiatočné prototypové príklady pre kľúčové koncepty

---

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nenesieme zodpovednosť za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.