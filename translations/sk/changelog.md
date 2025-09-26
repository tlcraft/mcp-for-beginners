<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T19:01:41+00:00",
  "source_file": "changelog.md",
  "language_code": "sk"
}
-->
# Zmeny: MCP pre začiatočníkov - učebné osnovy

Tento dokument slúži ako záznam všetkých významných zmien vykonaných v učebných osnovách Model Context Protocol (MCP) pre začiatočníkov. Zmeny sú dokumentované v obrátenom chronologickom poradí (najnovšie zmeny sú uvedené ako prvé).

## 26. september 2025

### Vylepšenie prípadových štúdií - Integrácia GitHub MCP Registry

#### Prípadové štúdie (09-CaseStudy/) - Zameranie na rozvoj ekosystému
- **README.md**: Významné rozšírenie s komplexnou prípadovou štúdiou GitHub MCP Registry
  - **Prípadová štúdia GitHub MCP Registry**: Nová komplexná štúdia skúmajúca spustenie GitHub MCP Registry v septembri 2025
    - **Analýza problému**: Podrobný rozbor problémov s fragmentovaným objavovaním a nasadzovaním MCP serverov
    - **Architektúra riešenia**: Centralizovaný prístup GitHub Registry s inštaláciou na jedno kliknutie vo VS Code
    - **Obchodný dopad**: Merateľné zlepšenia v onboardingu vývojárov a produktivite
    - **Strategická hodnota**: Zameranie na modulárne nasadzovanie agentov a interoperabilitu medzi nástrojmi
    - **Rozvoj ekosystému**: Pozicionovanie ako základná platforma pre integráciu agentov
  - **Vylepšená štruktúra prípadových štúdií**: Aktualizované všetkých sedem prípadových štúdií s konzistentným formátovaním a podrobnými popismi
    - Azure AI Travel Agents: Dôraz na orchestráciu viacerých agentov
    - Integrácia Azure DevOps: Zameranie na automatizáciu pracovných postupov
    - Získavanie dokumentácie v reálnom čase: Implementácia klienta Python konzoly
    - Interaktívny generátor študijných plánov: Konverzačná webová aplikácia Chainlit
    - Dokumentácia v editore: Integrácia VS Code a GitHub Copilot
    - Azure API Management: Vzory integrácie podnikových API
    - GitHub MCP Registry: Rozvoj ekosystému a komunitná platforma
  - **Komplexný záver**: Prepracovaná záverečná sekcia zdôrazňujúca sedem prípadových štúdií pokrývajúcich rôzne dimenzie implementácie MCP
    - Kategorizácia: Podniková integrácia, orchestrácia viacerých agentov, produktivita vývojárov
    - Rozvoj ekosystému, vzdelávacie aplikácie
    - Vylepšené poznatky o architektonických vzoroch, implementačných stratégiách a osvedčených postupoch
    - Dôraz na MCP ako zrelý, pripravený protokol pre produkčné prostredie

#### Aktualizácie študijného sprievodcu (study_guide.md)
- **Vizualizácia učebných osnov**: Aktualizovaná myšlienková mapa zahŕňajúca GitHub MCP Registry v sekcii prípadových štúdií
- **Popis prípadových štúdií**: Vylepšený z generických popisov na podrobný rozbor siedmich komplexných prípadových štúdií
- **Štruktúra repozitára**: Aktualizovaná sekcia 10 na odrážanie komplexného pokrytia prípadových štúdií so špecifickými implementačnými detailmi
- **Integrácia zmenového logu**: Pridaný záznam z 26. septembra 2025 dokumentujúci pridanie GitHub MCP Registry a vylepšenia prípadových štúdií
- **Aktualizácie dátumu**: Aktualizovaný časový údaj v pätičke na najnovšiu revíziu (26. september 2025)

### Vylepšenia kvality dokumentácie
- **Zlepšenie konzistencie**: Štandardizované formátovanie a štruktúra prípadových štúdií vo všetkých siedmich príkladoch
- **Komplexné pokrytie**: Prípadové štúdie teraz pokrývajú podnikové scenáre, produktivitu vývojárov a rozvoj ekosystému
- **Strategické pozicionovanie**: Zvýšený dôraz na MCP ako základnú platformu pre nasadzovanie agentických systémov
- **Integrácia zdrojov**: Aktualizované ďalšie zdroje vrátane odkazu na GitHub MCP Registry

## 15. september 2025

### Rozšírenie pokročilých tém - Vlastné transporty a inžinierstvo kontextu

#### MCP Vlastné transporty (05-AdvancedTopics/mcp-transport/) - Nový pokročilý implementačný sprievodca
- **README.md**: Kompletný implementačný sprievodca pre vlastné transportné mechanizmy MCP
  - **Transport Azure Event Grid**: Komplexná implementácia serverless event-driven transportu
    - Príklady v C#, TypeScript a Python s integráciou Azure Functions
    - Vzory architektúry založenej na udalostiach pre škálovateľné riešenia MCP
    - Prijímače webhookov a spracovanie správ na základe push
  - **Transport Azure Event Hubs**: Implementácia transportu s vysokou priepustnosťou pre streaming
    - Funkcie streamovania v reálnom čase pre scenáre s nízkou latenciou
    - Stratégie rozdelenia a správa kontrolných bodov
    - Optimalizácia výkonu a dávkovanie správ
  - **Vzory podnikovej integrácie**: Produkčne pripravené architektonické príklady
    - Distribuované spracovanie MCP naprieč viacerými Azure Functions
    - Hybridné transportné architektúry kombinujúce rôzne typy transportov
    - Stratégie odolnosti správ, spoľahlivosti a spracovania chýb
  - **Bezpečnosť a monitorovanie**: Integrácia Azure Key Vault a vzory pozorovateľnosti
    - Autentifikácia spravovanej identity a prístup s najnižšími oprávneniami
    - Telemetria Application Insights a monitorovanie výkonu
    - Mechanizmy obmedzenia a vzory odolnosti voči chybám
  - **Testovacie rámce**: Komplexné testovacie stratégie pre vlastné transporty
    - Jednotkové testovanie s testovacími dvojníkmi a rámcami na simuláciu
    - Integračné testovanie s Azure Test Containers
    - Úvahy o výkonnostnom a záťažovom testovaní

#### Inžinierstvo kontextu (05-AdvancedTopics/mcp-contextengineering/) - Nová disciplína AI
- **README.md**: Komplexný prieskum inžinierstva kontextu ako vznikajúcej oblasti
  - **Základné princípy**: Kompletné zdieľanie kontextu, uvedomovanie si rozhodnutí o akciách a správa kontextového okna
  - **Zladenie s MCP protokolom**: Ako dizajn MCP rieši výzvy inžinierstva kontextu
    - Obmedzenia kontextového okna a stratégie progresívneho načítania
    - Určovanie relevantnosti a dynamické získavanie kontextu
    - Viacmodalné spracovanie kontextu a úvahy o bezpečnosti
  - **Implementačné prístupy**: Jednovláknové vs. architektúry viacerých agentov
    - Techniky rozdelenia kontextu a prioritizácie
    - Progresívne načítanie kontextu a kompresné stratégie
    - Vrstvené prístupy ku kontextu a optimalizácia získavania
  - **Rámec merania**: Vznikajúce metriky na hodnotenie efektívnosti kontextu
    - Účinnosť vstupov, výkon, kvalita a úvahy o používateľskej skúsenosti
    - Experimentálne prístupy k optimalizácii kontextu
    - Analýza zlyhaní a metodológie zlepšenia

#### Aktualizácie navigácie učebných osnov (README.md)
- **Vylepšená štruktúra modulov**: Aktualizovaná tabuľka učebných osnov na zahrnutie nových pokročilých tém
  - Pridané Inžinierstvo kontextu (5.14) a Vlastné transporty (5.15)
  - Konzistentné formátovanie a navigačné odkazy vo všetkých moduloch
  - Aktualizované popisy na odrážanie aktuálneho rozsahu obsahu

### Vylepšenia štruktúry adresárov
- **Štandardizácia názvov**: Premenované "mcp transport" na "mcp-transport" pre konzistenciu s ostatnými pokročilými témami
- **Organizácia obsahu**: Všetky adresáre 05-AdvancedTopics teraz dodržiavajú konzistentný vzor názvov (mcp-[téma])

### Vylepšenia kvality dokumentácie
- **Zladenie so špecifikáciou MCP**: Všetok nový obsah odkazuje na aktuálnu špecifikáciu MCP 2025-06-18
- **Viacjazyčné príklady**: Komplexné príklady kódu v C#, TypeScript a Python
- **Zameranie na podniky**: Produkčne pripravené vzory a integrácia Azure cloud
- **Vizualizácia dokumentácie**: Diagramy Mermaid pre vizualizáciu architektúry a tokov

## 18. august 2025

### Komplexná aktualizácia dokumentácie - Štandardy MCP 2025-06-18

#### Najlepšie bezpečnostné postupy MCP (02-Security/) - Kompletná modernizácia
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletné prepracovanie v súlade so špecifikáciou MCP 2025-06-18
  - **Povinné požiadavky**: Pridané explicitné požiadavky MUST/MUST NOT z oficiálnej špecifikácie s jasnými vizuálnymi indikátormi
  - **12 základných bezpečnostných praktík**: Preštruktúrované z 15-bodového zoznamu na komplexné bezpečnostné domény
    - Bezpečnosť tokenov a autentifikácia s integráciou externých poskytovateľov identity
    - Správa relácií a bezpečnosť transportu s kryptografickými požiadavkami
    - Ochrana pred AI špecifickými hrozbami s integráciou Microsoft Prompt Shields
    - Riadenie prístupu a oprávnení s princípom najnižších oprávnení
    - Bezpečnosť obsahu a monitorovanie s integráciou Azure Content Safety
    - Bezpečnosť dodávateľského reťazca s komplexnou verifikáciou komponentov
    - Bezpečnosť OAuth a prevencia zmätku proxy s implementáciou PKCE
    - Reakcia na incidenty a obnova s automatizovanými schopnosťami
    - Súlad a správa s regulačným zosúladením
    - Pokročilé bezpečnostné kontroly s architektúrou nulovej dôvery
    - Integrácia ekosystému Microsoft Security s komplexnými riešeniami
    - Kontinuálny vývoj bezpečnosti s adaptívnymi praktikami
  - **Riešenia Microsoft Security**: Vylepšené pokyny na integráciu Prompt Shields, Azure Content Safety, Entra ID a GitHub Advanced Security
  - **Implementačné zdroje**: Kategorizované komplexné odkazy na zdroje podľa oficiálnej dokumentácie MCP, riešení Microsoft Security, bezpečnostných štandardov a implementačných sprievodcov

#### Pokročilé bezpečnostné kontroly (02-Security/) - Podniková implementácia
- **MCP-SECURITY-CONTROLS-2025.md**: Kompletné prepracovanie s podnikovo orientovaným bezpečnostným rámcom
  - **9 komplexných bezpečnostných domén**: Rozšírené z jednoduchých kontrol na podrobný podnikový rámec
    - Pokročilá autentifikácia a autorizácia s integráciou Microsoft Entra ID
    - Bezpečnosť tokenov a kontroly proti passtrough s komplexnou validáciou
    - Kontroly bezpečnosti relácií s prevenciou únosov
    - AI špecifické bezpečnostné kontroly s prevenciou injekcie promptov a otravy nástrojov
    - Prevencia zmätku proxy útokov s bezpečnosťou OAuth proxy
    - Bezpečnosť vykonávania nástrojov s sandboxingom a izoláciou
    - Kontroly bezpečnosti dodávateľského reťazca s verifikáciou závislostí
    - Monitorovanie a detekčné kontroly s integráciou SIEM
    - Reakcia na incidenty a obnova s automatizovanými schopnosťami
  - **Implementačné príklady**: Pridané podrobné bloky YAML konfigurácie a príklady kódu
  - **Integrácia riešení Microsoft**: Komplexné pokrytie bezpečnostných služieb Azure, GitHub Advanced Security a správy podnikovej identity

#### Pokročilé témy bezpečnosti (05-AdvancedTopics/mcp-security/) - Produkčne pripravená implementácia
- **README.md**: Kompletné prepracovanie pre podnikovú implementáciu bezpečnosti
  - **Zladenie s aktuálnou špecifikáciou**: Aktualizované na špecifikáciu MCP 2025-06-18 s povinnými bezpečnostnými požiadavkami
  - **Vylepšená autentifikácia**: Integrácia Microsoft Entra ID s komplexnými príkladmi v .NET a Java Spring Security
  - **Integrácia AI bezpečnosti**: Implementácia Microsoft Prompt Shields a Azure Content Safety s podrobnými príkladmi v Python
  - **Pokročilé zmiernenie hrozieb**: Komplexné implementačné príklady pre
    - Prevencia zmätku proxy útokov s PKCE a validáciou používateľského súhlasu
    - Prevencia passtrough tokenov s validáciou publika a bezpečnou správou tokenov
    - Prevencia únosov relácií s kryptografickým viazaním a analýzou správania
  - **Integrácia podnikovej bezpečnosti**: Monitorovanie Azure Application Insights, detekčné pipeline hrozieb a bezpečnosť dodávateľského reťazca
  - **Implementačný kontrolný zoznam**: Jasné povinné vs. odporúčané bezpečnostné kontroly s výhodami ekosystému Microsoft Security

### Vylepšenia kvality dokumentácie a zosúladenie so štandardmi
- **Referencie na špecifikáciu**: Aktualizované všetky odkazy na aktuálnu špecifikáciu MCP 2025-06-18
- **Ekosystém Microsoft Security**: Vylepšené pokyny na integráciu v celej bezpečnostnej dokumentácii
- **Praktická implementácia**: Pridané podrobné príklady kódu v .NET, Java a Python s podnikovými vzormi
- **Organizácia zdrojov**: Komplexná kategorizácia oficiálnej dokumentácie, bezpečnostných štandardov a implementačných sprievodcov
- **Vizuálne indikátory**: Jasné označenie povinných požiadaviek vs. odporúčaných praktík

#### Základné koncepty (01-CoreConcepts/) - Kompletná modernizácia
- **Aktualizácia verzie protokolu**: Aktualizované na odkazovanie na aktuálnu špecifikáciu MCP 2025-06-18 s verzovaním na základe dátumu (formát YYYY-MM-DD)
- **Prepracovanie architektúry**: Vylepšené popisy hostiteľov, klientov a serverov na odrážanie aktuálnych vzorov architektúry MCP
  - Hostitelia teraz jasne definovaní ako AI aplikácie koordinujúce viaceré pripojenia MCP klientov
  - Klienti popísaní ako konektory protokolu udržiavajúce vzťahy jeden na jedného so servermi
  - Servery vylepšené s lokálnymi vs. vzdialenými scenármi nasadenia
- **Prepracovanie primitív**: Kompletné prepracovanie primitív servera a klienta
  - Primitívy servera: Zdroje (datové zdroje), Prompty (šablóny), Nástroje (vykonateľné funkcie) s podrobnými vysvetleniami a príkladmi
  - Primitívy klienta: Sampling (LLM dokončenia), Elicitation (vstup používateľa), Logging (debugging/monitorovanie)
  - Aktualizované s aktuálnymi metódami objavovania (`*/list`), získavania (`*/get`) a vykonávania (`*/call`)
- **Architektúra protokolu**: Predstavený dvojvrstvový model architektúry
  - Dátová vrstva: Základ JSON-RPC 2.0
- Nahradené značky `<details>` formátom založeným na tabuľkách pre lepšiu prístupnosť
- Vytvorené alternatívne možnosti rozloženia v novej zložke "alternative_layouts"
- Pridané príklady navigácie založenej na kartách, štýle záložiek a akordeóne
- Aktualizovaná sekcia štruktúry repozitára, aby zahŕňala všetky najnovšie súbory
- Vylepšená sekcia "Ako používať tento učebný plán" s jasnými odporúčaniami
- Aktualizované odkazy na špecifikácie MCP na správne URL adresy
- Pridaná sekcia Kontextového inžinierstva (5.14) do štruktúry učebného plánu

### Aktualizácie študijného sprievodcu
- Kompletná revízia študijného sprievodcu v súlade s aktuálnou štruktúrou repozitára
- Pridané nové sekcie pre MCP klientov a nástroje, a populárne MCP servery
- Aktualizovaná vizuálna mapa učebného plánu, aby presne odrážala všetky témy
- Vylepšené popisy pokročilých tém, aby pokryli všetky špecializované oblasti
- Aktualizovaná sekcia prípadových štúdií, aby odrážala skutočné príklady
- Pridaný tento komplexný zoznam zmien

### Príspevky komunity (06-CommunityContributions/)
- Pridané podrobné informácie o MCP serveroch na generovanie obrázkov
- Pridaná komplexná sekcia o používaní Claude vo VSCode
- Pridané pokyny na nastavenie a používanie terminálového klienta Cline
- Aktualizovaná sekcia MCP klientov, aby zahŕňala všetky populárne možnosti klientov
- Vylepšené príklady príspevkov s presnejšími ukážkami kódu

### Pokročilé témy (05-AdvancedTopics/)
- Zorganizované všetky zložky špecializovaných tém s konzistentným názvoslovím
- Pridané materiály a príklady kontextového inžinierstva
- Pridaná dokumentácia integrácie agenta Foundry
- Vylepšená dokumentácia integrácie bezpečnosti Entra ID

## 11. jún 2025

### Počiatočné vytvorenie
- Vydaná prvá verzia učebného plánu MCP pre začiatočníkov
- Vytvorená základná štruktúra pre všetkých 10 hlavných sekcií
- Implementovaná vizuálna mapa učebného plánu pre navigáciu
- Pridané počiatočné ukážkové projekty v rôznych programovacích jazykoch

### Začíname (03-GettingStarted/)
- Vytvorené prvé príklady implementácie servera
- Pridané pokyny na vývoj klienta
- Zahrnuté pokyny na integráciu klienta LLM
- Pridaná dokumentácia integrácie VS Code
- Implementované príklady serverov s udalosťami odosielanými serverom (SSE)

### Základné koncepty (01-CoreConcepts/)
- Pridané podrobné vysvetlenie architektúry klient-server
- Vytvorená dokumentácia o kľúčových komponentoch protokolu
- Zdokumentované vzory správ v MCP

## 23. máj 2025

### Štruktúra repozitára
- Inicializovaný repozitár so základnou štruktúrou zložiek
- Vytvorené README súbory pre každú hlavnú sekciu
- Nastavená infraštruktúra pre preklady
- Pridané obrazové materiály a diagramy

### Dokumentácia
- Vytvorený počiatočný README.md s prehľadom učebného plánu
- Pridané CODE_OF_CONDUCT.md a SECURITY.md
- Nastavený SUPPORT.md s pokynmi na získanie pomoci
- Vytvorená predbežná štruktúra študijného sprievodcu

## 15. apríl 2025

### Plánovanie a rámec
- Počiatočné plánovanie učebného plánu MCP pre začiatočníkov
- Definované vzdelávacie ciele a cieľová skupina
- Načrtnutá 10-sekčná štruktúra učebného plánu
- Vyvinutý konceptuálny rámec pre príklady a prípadové štúdie
- Vytvorené počiatočné prototypové príklady pre kľúčové koncepty

---

