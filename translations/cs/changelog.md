<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:58:48+00:00",
  "source_file": "changelog.md",
  "language_code": "cs"
}
-->
# Changelog: MCP pro začátečníky

Tento dokument slouží jako záznam všech významných změn provedených v kurikulu Model Context Protocol (MCP) pro začátečníky. Změny jsou dokumentovány v obráceném chronologickém pořadí (nejnovější změny jako první).

## 26. září 2025

### Rozšíření případových studií - Integrace GitHub MCP Registry

#### Případové studie (09-CaseStudy/) - Zaměření na rozvoj ekosystému
- **README.md**: Významné rozšíření s komplexní případovou studií GitHub MCP Registry
  - **Případová studie GitHub MCP Registry**: Nová komplexní případová studie zkoumající spuštění GitHub MCP Registry v září 2025
    - **Analýza problému**: Podrobný rozbor roztříštěného vyhledávání MCP serverů a problémů s nasazením
    - **Architektura řešení**: Centralizovaný přístup GitHubu s instalací na jedno kliknutí ve VS Code
    - **Dopad na podnikání**: Měřitelné zlepšení onboardingu vývojářů a produktivity
    - **Strategická hodnota**: Zaměření na modulární nasazení agentů a interoperabilitu mezi nástroji
    - **Rozvoj ekosystému**: Pozice jako základní platforma pro integraci agentů
  - **Vylepšená struktura případových studií**: Aktualizace všech sedmi případových studií s konzistentním formátováním a podrobnými popisy
    - Azure AI Travel Agents: Důraz na orchestraci více agentů
    - Integrace Azure DevOps: Zaměření na automatizaci pracovních postupů
    - Získávání dokumentace v reálném čase: Implementace klienta Python konzole
    - Interaktivní generátor studijních plánů: Konverzační webová aplikace Chainlit
    - Dokumentace v editoru: Integrace VS Code a GitHub Copilot
    - Správa API Azure: Vzory integrace podnikových API
    - GitHub MCP Registry: Rozvoj ekosystému a komunitní platforma
  - **Komplexní závěr**: Přepsaná závěrečná sekce zdůrazňující sedm případových studií pokrývajících různé dimenze implementace MCP
    - Integrace podniků, orchestrace více agentů, produktivita vývojářů
    - Rozvoj ekosystému, kategorizace vzdělávacích aplikací
    - Vylepšené poznatky o architektonických vzorech, implementačních strategiích a osvědčených postupech
    - Důraz na MCP jako vyspělý, připravený protokol pro produkční nasazení

#### Aktualizace studijního průvodce (study_guide.md)
- **Vizualizace kurikula**: Aktualizovaná myšlenková mapa zahrnující GitHub MCP Registry v sekci případových studií
- **Popis případových studií**: Rozšíření z obecných popisů na podrobný rozbor sedmi komplexních případových studií
- **Struktura repozitáře**: Aktualizace sekce 10 tak, aby odrážela komplexní pokrytí případových studií s konkrétními detaily implementace
- **Integrace changelogu**: Přidán záznam z 26. září 2025 dokumentující přidání GitHub MCP Registry a vylepšení případových studií
- **Aktualizace data**: Aktualizace časového razítka v zápatí na nejnovější revizi (26. září 2025)

### Vylepšení kvality dokumentace
- **Zlepšení konzistence**: Standardizace formátování a struktury případových studií napříč všemi sedmi příklady
- **Komplexní pokrytí**: Případové studie nyní pokrývají scénáře podniků, produktivity vývojářů a rozvoje ekosystému
- **Strategické pozicování**: Zvýšený důraz na MCP jako základní platformu pro nasazení agentních systémů
- **Integrace zdrojů**: Aktualizace dalších zdrojů zahrnující odkaz na GitHub MCP Registry

## 15. září 2025

### Rozšíření pokročilých témat - Vlastní transporty a inženýrství kontextu

#### Vlastní transporty MCP (05-AdvancedTopics/mcp-transport/) - Nový pokročilý implementační průvodce
- **README.md**: Kompletní průvodce implementací vlastních transportních mechanismů MCP
  - **Transport Azure Event Grid**: Komplexní implementace serverless event-driven transportu
    - Příklady v C#, TypeScriptu a Pythonu s integrací Azure Functions
    - Vzory architektury založené na událostech pro škálovatelná řešení MCP
    - Příjemci webhooků a zpracování zpráv na bázi push
  - **Transport Azure Event Hubs**: Implementace transportu pro vysokou propustnost streamování
    - Schopnosti streamování v reálném čase pro scénáře s nízkou latencí
    - Strategie rozdělení a správa kontrolních bodů
    - Optimalizace výkonu a dávkování zpráv
  - **Vzory integrace podniků**: Produkčně připravené architektonické příklady
    - Distribuované zpracování MCP napříč více funkcemi Azure
    - Hybridní transportní architektury kombinující více typů transportů
    - Strategie trvanlivosti zpráv, spolehlivosti a zpracování chyb
  - **Bezpečnost a monitorování**: Integrace Azure Key Vault a vzory pozorovatelnosti
    - Autentizace spravované identity a přístup s minimálními oprávněními
    - Telemetrie Application Insights a monitorování výkonu
    - Obvody přerušení a vzory odolnosti proti chybám
  - **Testovací rámce**: Komplexní strategie testování vlastních transportů
    - Jednotkové testování s testovacími dvojníky a rámci pro simulaci
    - Integrační testování s Azure Test Containers
    - Úvahy o výkonu a zátěžovém testování

#### Inženýrství kontextu (05-AdvancedTopics/mcp-contextengineering/) - Nově vznikající disciplína AI
- **README.md**: Komplexní průzkum inženýrství kontextu jako nově vznikajícího oboru
  - **Základní principy**: Kompletní sdílení kontextu, povědomí o rozhodování akcí a správa oken kontextu
  - **Zarovnání s protokolem MCP**: Jak návrh MCP řeší výzvy inženýrství kontextu
    - Omezení oken kontextu a strategie progresivního načítání
    - Určování relevance a dynamické získávání kontextu
    - Multimodální zpracování kontextu a bezpečnostní úvahy
  - **Implementační přístupy**: Jednovláknové vs. architektury více agentů
    - Techniky rozdělení a prioritizace kontextu
    - Progresivní načítání kontextu a strategie komprese
    - Vrstvené přístupy ke kontextu a optimalizace získávání
  - **Rámec měření**: Nově vznikající metriky pro hodnocení efektivity kontextu
    - Účinnost vstupů, výkon, kvalita a úvahy o uživatelské zkušenosti
    - Experimentální přístupy k optimalizaci kontextu
    - Analýza selhání a metodologie zlepšení

#### Aktualizace navigace kurikula (README.md)
- **Vylepšená struktura modulů**: Aktualizovaná tabulka kurikula zahrnující nová pokročilá témata
  - Přidána inženýrství kontextu (5.14) a vlastní transporty (5.15)
  - Konzistentní formátování a navigační odkazy napříč všemi moduly
  - Aktualizované popisy odrážející aktuální rozsah obsahu

### Vylepšení struktury adresářů
- **Standardizace názvů**: Přejmenování "mcp transport" na "mcp-transport" pro konzistenci s ostatními složkami pokročilých témat
- **Organizace obsahu**: Všechny složky 05-AdvancedTopics nyní dodržují konzistentní vzor názvů (mcp-[téma])

### Vylepšení kvality dokumentace
- **Zarovnání se specifikací MCP**: Veškerý nový obsah odkazuje na aktuální specifikaci MCP 2025-06-18
- **Vícejazyčné příklady**: Komplexní příklady kódu v C#, TypeScriptu a Pythonu
- **Zaměření na podniky**: Produkčně připravené vzory a integrace Azure cloud napříč celým obsahem
- **Vizualizace dokumentace**: Diagramy Mermaid pro vizualizaci architektury a toků

## 18. srpna 2025

### Komplexní aktualizace dokumentace - Standardy MCP 2025-06-18

#### Nejlepší bezpečnostní postupy MCP (02-Security/) - Kompletní modernizace
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletní přepis zarovnaný se specifikací MCP 2025-06-18
  - **Povinné požadavky**: Přidány explicitní požadavky MUST/MUST NOT z oficiální specifikace s jasnými vizuálními indikátory
  - **12 základních bezpečnostních praktik**: Restrukturalizováno z 15 položek na komplexní bezpečnostní domény
    - Bezpečnost tokenů a autentizace s integrací externích poskytovatelů identity
    - Správa relací a transportní bezpečnost s kryptografickými požadavky
    - Ochrana proti AI-specifickým hrozbám s integrací Microsoft Prompt Shields
    - Řízení přístupu a oprávnění s principem minimálních oprávnění
    - Bezpečnost obsahu a monitorování s integrací Azure Content Safety
    - Bezpečnost dodavatelského řetězce s komplexním ověřením komponent
    - Bezpečnost OAuth a prevence zmateného zástupce s implementací PKCE
    - Reakce na incidenty a obnova s automatizovanými schopnostmi
    - Soulad a správa s regulačním zarovnáním
    - Pokročilé bezpečnostní kontroly s architekturou nulové důvěry
    - Integrace bezpečnostního ekosystému Microsoftu s komplexními řešeními
    - Kontinuální evoluce bezpečnosti s adaptivními praktikami
  - **Řešení Microsoft Security**: Vylepšené pokyny pro integraci Prompt Shields, Azure Content Safety, Entra ID a GitHub Advanced Security
  - **Implementační zdroje**: Kategorizované komplexní odkazy na zdroje podle Oficiální dokumentace MCP, Řešení Microsoft Security, Bezpečnostní standardy a Implementační průvodce

#### Pokročilé bezpečnostní kontroly (02-Security/) - Podniková implementace
- **MCP-SECURITY-CONTROLS-2025.md**: Kompletní přepracování s podnikovým bezpečnostním rámcem
  - **9 komplexních bezpečnostních domén**: Rozšířeno z základních kontrol na podrobný podnikový rámec
    - Pokročilá autentizace a autorizace s integrací Microsoft Entra ID
    - Bezpečnost tokenů a kontroly proti průchodu s komplexním ověřením
    - Bezpečnost relací s prevencí únosů
    - AI-specifické bezpečnostní kontroly s prevencí injekce promptů a otravou nástrojů
    - Prevence útoků zmateného zástupce s bezpečností proxy OAuth
    - Bezpečnost provádění nástrojů s izolací a sandboxingem
    - Kontroly bezpečnosti dodavatelského řetězce s ověřením závislostí
    - Monitorovací a detekční kontroly s integrací SIEM
    - Reakce na incidenty a obnova s automatizovanými schopnostmi
  - **Implementační příklady**: Přidány podrobné bloky konfigurace YAML a příklady kódu
  - **Integrace řešení Microsoft**: Komplexní pokrytí bezpečnostních služeb Azure, GitHub Advanced Security a správy podnikové identity

#### Pokročilá bezpečnostní témata (05-AdvancedTopics/mcp-security/) - Produkčně připravená implementace
- **README.md**: Kompletní přepis pro podnikovou implementaci bezpečnosti
  - **Zarovnání s aktuální specifikací**: Aktualizováno na specifikaci MCP 2025-06-18 s povinnými bezpečnostními požadavky
  - **Vylepšená autentizace**: Integrace Microsoft Entra ID s komplexními příklady .NET a Java Spring Security
  - **Integrace AI bezpečnosti**: Implementace Microsoft Prompt Shields a Azure Content Safety s podrobnými příklady v Pythonu
  - **Pokročilé zmírnění hrozeb**: Komplexní implementační příklady pro
    - Prevence útoků zmateného zástupce s PKCE a validací uživatelského souhlasu
    - Prevence průchodu tokenů s validací publika a bezpečnou správou tokenů
    - Prevence únosů relací s kryptografickým vázáním a analýzou chování
  - **Integrace podnikové bezpečnosti**: Monitorování Application Insights, detekční pipeline hrozeb a bezpečnost dodavatelského řetězce
  - **Kontrolní seznam implementace**: Jasné povinné vs. doporučené bezpečnostní kontroly s výhodami bezpečnostního ekosystému Microsoft

### Vylepšení kvality dokumentace a zarovnání se standardy
- **Reference specifikace**: Aktualizace všech odkazů na aktuální specifikaci MCP 2025-06-18
- **Bezpečnostní ekosystém Microsoft**: Vylepšené pokyny pro integraci napříč celou bezpečnostní dokumentací
- **Praktická implementace**: Přidány podrobné příklady kódu v .NET, Java a Pythonu s podnikovými vzory
- **Organizace zdrojů**: Komplexní kategorizace oficiální dokumentace, bezpečnostních standardů a implementačních průvodců
- **Vizuální indikátory**: Jasné označení povinných požadavků vs. doporučených praktik

#### Základní koncepty (01-CoreConcepts/) - Kompletní modernizace
- **Aktualizace verze protokolu**: Aktualizováno na aktuální specifikaci MCP 2025-06-18 s verzováním na základě data (formát YYYY-MM-DD)
- **Vylepšení architektury**: Rozšířené popisy Hostů, Klientů a Serverů odrážející aktuální vzory architektury MCP
  - Hosté nyní jasně definováni jako AI aplikace koordinující více připojení MCP klientů
  - Klienti popsáni jako konektory protokolu udržující vztahy jeden na jednoho se servery
  - Servery rozšířeny o scénáře lokálního vs. vzdáleného nasazení
- **Restrukturalizace primitiv**: Kompletní přepracování primitiv serveru a klienta
  - Primitivy serveru: Zdroje (datové zdroje), Prompty (šablony), Nástroje (spustitelné funkce) s podrobnými vysvětleními a příklady
  - Primitivy klienta: Sampling (LLM dokončení), Elicitation (uživatelský vstup), Logging (ladění/monitorování)
  - Aktualizováno s aktuálními metodami pro objevování (`*/list`), získávání (`*/get`) a provádění (`*/call`)
- **Architektura protokolu**: Představen dvouvrstvý model architektury
  - Datová vrstva: Základ JSON-RPC 2.0 s řízením životního cyklu a primitivy
  - Transportní vrstva: STDIO (lokální) a Streamable HTTP se SSE (vzdálené) transportní mechanismy
- **Bezpečnostní rámec**: Komplexní bezpečnostní principy včetně explicitního uživatelského souhlasu, ochrany soukromí dat, bezpečnosti provádění nástrojů a bezpečnosti transportní vrstvy
- **Komunikační vzory**: Aktualizované zprávy protokolu zobrazující inicializaci, objevování, provádění a tok oznámení
- **Příklady kódu**: Obnovené vícejazyčné příklady (.NET, Java, Python, JavaScript) odrážející aktuální vzory MCP SDK

#### Bezpečnost (02-Security/) - Komplexní bezpečnostní přepracování  
- **Zarovnání se standardy**: Plné zarovnání s požadavky na bezpečnost specifikace MCP 2025-06-18

- Nahrazeny značky `<details>` přístupnějším formátem založeným na tabulkách
- Vytvořeny alternativní možnosti rozvržení ve složce "alternative_layouts"
- Přidány příklady navigace založené na kartách, záložkách a akordeonu
- Aktualizována sekce struktury repozitáře, aby zahrnovala všechny nejnovější soubory
- Vylepšena sekce "Jak používat tento kurikulum" s jasnými doporučeními
- Aktualizovány odkazy na specifikace MCP, aby odkazovaly na správné URL
- Přidána sekce Kontextové inženýrství (5.14) do struktury kurikula

### Aktualizace studijního průvodce
- Kompletně přepracován studijní průvodce, aby odpovídal aktuální struktuře repozitáře
- Přidány nové sekce pro MCP klienty a nástroje a populární MCP servery
- Aktualizována vizuální mapa kurikula, aby přesně odrážela všechna témata
- Vylepšeny popisy pokročilých témat, aby pokryly všechny specializované oblasti
- Aktualizována sekce případových studií, aby odrážela skutečné příklady
- Přidán tento komplexní seznam změn

### Příspěvky komunity (06-CommunityContributions/)
- Přidány podrobné informace o MCP serverech pro generování obrázků
- Přidána komplexní sekce o používání Claude ve VSCode
- Přidány pokyny pro nastavení a používání terminálového klienta Cline
- Aktualizována sekce MCP klientů, aby zahrnovala všechny populární možnosti klientů
- Vylepšeny příklady příspěvků s přesnějšími ukázkami kódu

### Pokročilá témata (05-AdvancedTopics/)
- Organizovány všechny složky specializovaných témat s konzistentním pojmenováním
- Přidány materiály a příklady pro kontextové inženýrství
- Přidána dokumentace pro integraci agenta Foundry
- Vylepšena dokumentace pro integraci zabezpečení Entra ID

## 11. června 2025

### První vytvoření
- Vydána první verze kurikula MCP pro začátečníky
- Vytvořena základní struktura pro všech 10 hlavních sekcí
- Implementována vizuální mapa kurikula pro navigaci
- Přidány počáteční ukázkové projekty v několika programovacích jazycích

### Začínáme (03-GettingStarted/)
- Vytvořeny první příklady implementace serveru
- Přidány pokyny pro vývoj klienta
- Zahrnuty pokyny pro integraci klienta LLM
- Přidána dokumentace pro integraci VS Code
- Implementovány příklady serverů s událostmi odesílanými serverem (SSE)

### Základní koncepty (01-CoreConcepts/)
- Přidáno podrobné vysvětlení architektury klient-server
- Vytvořena dokumentace klíčových komponent protokolu
- Zdokumentovány vzory zpráv v MCP

## 23. května 2025

### Struktura repozitáře
- Inicializován repozitář se základní strukturou složek
- Vytvořeny soubory README pro každou hlavní sekci
- Nastavena infrastruktura pro překlady
- Přidány obrazové materiály a diagramy

### Dokumentace
- Vytvořen počáteční README.md s přehledem kurikula
- Přidány soubory CODE_OF_CONDUCT.md a SECURITY.md
- Nastaven SUPPORT.md s pokyny pro získání pomoci
- Vytvořena předběžná struktura studijního průvodce

## 15. dubna 2025

### Plánování a rámec
- Počáteční plánování kurikula MCP pro začátečníky
- Definovány vzdělávací cíle a cílová skupina
- Nastíněna 10sekční struktura kurikula
- Vyvinut konceptuální rámec pro příklady a případové studie
- Vytvořeny počáteční prototypové příklady pro klíčové koncepty

---

