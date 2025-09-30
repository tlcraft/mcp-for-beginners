<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T21:33:26+00:00",
  "source_file": "changelog.md",
  "language_code": "cs"
}
-->
# Změny: MCP pro začátečníky - učební plán

Tento dokument slouží jako záznam všech významných změn provedených v učebním plánu Model Context Protocol (MCP) pro začátečníky. Změny jsou dokumentovány v obráceném chronologickém pořadí (nejnovější změny jako první).

## 29. září 2025

### MCP Server Database Integration Labs - Komplexní praktická učební cesta

#### 11-MCPServerHandsOnLabs - Nový kompletní učební plán pro integraci databází
- **Kompletní učební cesta s 13 laboratořemi**: Přidán komplexní praktický učební plán pro vytváření produkčně připravených MCP serverů s integrací databáze PostgreSQL
  - **Implementace v reálném světě**: Případová studie Zava Retail Analytics demonstrující vzory na podnikové úrovni
  - **Strukturovaný postup učení**:
    - **Laboratoře 00-03: Základy** - Úvod, základní architektura, bezpečnost a multi-tenancy, nastavení prostředí
    - **Laboratoře 04-06: Vytváření MCP serveru** - Návrh databáze a schéma, implementace MCP serveru, vývoj nástrojů  
    - **Laboratoře 07-09: Pokročilé funkce** - Integrace sémantického vyhledávání, testování a ladění, integrace s VS Code
    - **Laboratoře 10-12: Produkce a osvědčené postupy** - Strategie nasazení, monitorování a observabilita, optimalizace a osvědčené postupy
  - **Podnikové technologie**: FastMCP framework, PostgreSQL s pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Pokročilé funkce**: Řízení přístupu na úrovni řádků (RLS), sémantické vyhledávání, přístup k datům pro více nájemců, vektorové embeddings, monitorování v reálném čase

#### Standardizace terminologie - Převod z "modulů" na "laboratoře"
- **Komplexní aktualizace dokumentace**: Systematicky aktualizovány všechny README soubory v 11-MCPServerHandsOnLabs na terminologii "laboratoř" místo "modul"
  - **Nadpisy sekcí**: Aktualizováno "Co tento modul pokrývá" na "Co tato laboratoř pokrývá" ve všech 13 laboratořích
  - **Popis obsahu**: Změněno "Tento modul poskytuje..." na "Tato laboratoř poskytuje..." v celé dokumentaci
  - **Cíle učení**: Aktualizováno "Na konci tohoto modulu..." na "Na konci této laboratoře..."
  - **Navigační odkazy**: Převod všech odkazů "Modul XX:" na "Laboratoř XX:" v křížových odkazech a navigaci
  - **Sledování dokončení**: Aktualizováno "Po dokončení tohoto modulu..." na "Po dokončení této laboratoře..."
  - **Zachování technických odkazů**: Zachovány odkazy na Python moduly v konfiguračních souborech (např. `"module": "mcp_server.main"`)

#### Vylepšení studijního průvodce (study_guide.md)
- **Vizualizace učebního plánu**: Přidána nová sekce "11. Laboratoře pro integraci databází" s vizualizací struktury laboratoří
- **Struktura repozitáře**: Aktualizováno z deseti na jedenáct hlavních sekcí s podrobným popisem 11-MCPServerHandsOnLabs
- **Pokyny k učební cestě**: Rozšířeny navigační instrukce pro pokrytí sekcí 00-11
- **Pokrytí technologií**: Přidány detaily o integraci FastMCP, PostgreSQL a služeb Azure
- **Výsledky učení**: Zdůrazněn vývoj produkčně připravených serverů, vzory integrace databází a podniková bezpečnost

#### Vylepšení hlavního README
- **Terminologie založená na laboratořích**: Aktualizováno hlavní README.md v 11-MCPServerHandsOnLabs pro konzistentní použití struktury "laboratoř"
- **Organizace učební cesty**: Jasný postup od základních konceptů přes pokročilou implementaci až po nasazení do produkce
- **Zaměření na reálný svět**: Důraz na praktické, praktické učení s podnikovými vzory a technologiemi

### Zlepšení kvality a konzistence dokumentace
- **Důraz na praktické učení**: Posílen praktický, laboratorní přístup v celé dokumentaci
- **Zaměření na podnikové vzory**: Zdůrazněny produkčně připravené implementace a úvahy o podnikové bezpečnosti
- **Integrace technologií**: Komplexní pokrytí moderních služeb Azure a vzorů AI integrace
- **Postup učení**: Jasná, strukturovaná cesta od základních konceptů k nasazení do produkce

## 26. září 2025

### Vylepšení případových studií - Integrace GitHub MCP Registry

#### Případové studie (09-CaseStudy/) - Zaměření na rozvoj ekosystému
- **README.md**: Významné rozšíření s komplexní případovou studií GitHub MCP Registry
  - **Případová studie GitHub MCP Registry**: Nová komplexní případová studie zkoumající spuštění GitHub MCP Registry v září 2025
    - **Analýza problému**: Podrobný rozbor roztříštěného objevování a nasazování MCP serverů
    - **Architektura řešení**: Centralizovaný přístup registru GitHub s instalací na jedno kliknutí ve VS Code
    - **Dopad na podnikání**: Měřitelné zlepšení onboardingu vývojářů a produktivity
    - **Strategická hodnota**: Zaměření na modulární nasazení agentů a interoperabilitu mezi nástroji
    - **Rozvoj ekosystému**: Pozice jako základní platforma pro integraci agentů
  - **Vylepšená struktura případových studií**: Aktualizováno všech sedm případových studií s konzistentním formátováním a komplexními popisy
    - Azure AI Travel Agents: Důraz na orchestraci více agentů
    - Integrace Azure DevOps: Zaměření na automatizaci pracovních postupů
    - Real-Time Documentation Retrieval: Implementace Python konzolového klienta
    - Interactive Study Plan Generator: Konverzační webová aplikace Chainlit
    - In-Editor Documentation: Integrace VS Code a GitHub Copilot
    - Azure API Management: Vzory integrace podnikových API
    - GitHub MCP Registry: Rozvoj ekosystému a komunitní platforma
  - **Komplexní závěr**: Přepsána závěrečná sekce zdůrazňující sedm případových studií pokrývajících různé dimenze implementace MCP
    - Integrace podniků, orchestraci více agentů, produktivitu vývojářů
    - Rozvoj ekosystému, vzdělávací aplikace
    - Rozšířené poznatky o architektonických vzorech, strategiích implementace a osvědčených postupech
    - Důraz na MCP jako vyspělý, produkčně připravený protokol

#### Aktualizace studijního průvodce (study_guide.md)
- **Vizualizace učebního plánu**: Aktualizována myšlenková mapa pro zahrnutí GitHub MCP Registry v sekci případových studií
- **Popis případových studií**: Rozšířeno z obecných popisů na podrobný rozbor sedmi komplexních případových studií
- **Struktura repozitáře**: Aktualizována sekce 10 pro odrážení komplexního pokrytí případových studií s konkrétními detaily implementace
- **Integrace změn**: Přidán záznam z 26. září 2025 dokumentující přidání GitHub MCP Registry a vylepšení případových studií
- **Aktualizace data**: Aktualizováno časové razítko v zápatí na nejnovější revizi (26. září 2025)

### Zlepšení kvality dokumentace
- **Zlepšení konzistence**: Standardizováno formátování a struktura případových studií napříč všemi sedmi příklady
- **Komplexní pokrytí**: Případové studie nyní pokrývají scénáře podniků, produktivity vývojářů a rozvoje ekosystému
- **Strategické umístění**: Posílen důraz na MCP jako základní platformu pro nasazení agentních systémů
- **Integrace zdrojů**: Aktualizovány další zdroje pro zahrnutí odkazu na GitHub MCP Registry

## 15. září 2025

### Rozšíření pokročilých témat - Vlastní transporty a inženýrství kontextu

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - Nový pokročilý průvodce implementací
- **README.md**: Kompletní průvodce implementací vlastních transportních mechanismů MCP
  - **Transport Azure Event Grid**: Komplexní implementace serverless transportu založeného na událostech
    - Příklady v C#, TypeScriptu a Pythonu s integrací Azure Functions
    - Vzory architektury založené na událostech pro škálovatelné MCP řešení
    - Webhook přijímače a zpracování zpráv na bázi push
  - **Transport Azure Event Hubs**: Implementace transportu pro vysokou propustnost streamování
    - Schopnosti streamování v reálném čase pro scénáře s nízkou latencí
    - Strategie rozdělení a správa kontrolních bodů
    - Optimalizace výkonu a dávkování zpráv
  - **Vzory integrace podniků**: Produkčně připravené architektonické příklady
    - Distribuované zpracování MCP napříč více Azure Functions
    - Hybridní transportní architektury kombinující více typů transportů
    - Strategie trvanlivosti zpráv, spolehlivosti a zpracování chyb
  - **Bezpečnost a monitorování**: Integrace Azure Key Vault a vzory observability
    - Autentizace spravované identity a přístup s minimálními oprávněními
    - Telemetrie Application Insights a monitorování výkonu
    - Obvody přerušení a vzory odolnosti proti chybám
  - **Testovací rámce**: Komplexní strategie testování pro vlastní transporty
    - Jednotkové testování s testovacími dvojníky a rámci pro simulaci
    - Integrační testování s Azure Test Containers
    - Úvahy o výkonu a zátěžovém testování

#### Inženýrství kontextu (05-AdvancedTopics/mcp-contextengineering/) - Nově vznikající AI disciplína
- **README.md**: Komplexní průzkum inženýrství kontextu jako nově vznikajícího oboru
  - **Základní principy**: Kompletní sdílení kontextu, povědomí o rozhodování akcí a správa kontextového okna
  - **Zarovnání s MCP protokolem**: Jak návrh MCP řeší výzvy inženýrství kontextu
    - Omezení kontextového okna a strategie progresivního načítání
    - Určování relevance a dynamické získávání kontextu
    - Více-modální zpracování kontextu a úvahy o bezpečnosti
  - **Přístupy k implementaci**: Jednovláknové vs. architektury více agentů
    - Techniky rozdělení kontextu a prioritizace
    - Progresivní načítání kontextu a strategie komprese
    - Vrstvené přístupy ke kontextu a optimalizace získávání
  - **Rámec měření**: Nově vznikající metriky pro hodnocení efektivity kontextu
    - Účinnost vstupu, výkon, kvalita a úvahy o uživatelské zkušenosti
    - Experimentální přístupy k optimalizaci kontextu
    - Analýza selhání a metodologie zlepšení

#### Aktualizace navigace učebního plánu (README.md)
- **Vylepšená struktura modulů**: Aktualizována tabulka učebního plánu pro zahrnutí nových pokročilých témat
  - Přidány položky Inženýrství kontextu (5.14) a Vlastní transporty (5.15)
  - Konzistentní formátování a navigační odkazy napříč všemi moduly
  - Aktualizovány popisy pro odrážení aktuálního rozsahu obsahu

### Vylepšení struktury adresářů
- **Standardizace názvů**: Přejmenováno "mcp transport" na "mcp-transport" pro konzistenci s ostatními složkami pokročilých témat
- **Organizace obsahu**: Všechny složky 05-AdvancedTopics nyní dodržují konzistentní vzor názvů (mcp-[téma])

### Zlepšení kvality dokumentace
- **Zarovnání se specifikací MCP**: Veškerý nový obsah odkazuje na aktuální specifikaci MCP 2025-06-18
- **Vícejazyčné příklady**: Komplexní příklady kódu v C#, TypeScriptu a Pythonu
- **Zaměření na podniky**: Produkčně připravené vzory a integrace Azure cloud v celém obsahu
- **Vizualizace dokumentace**: Diagramy Mermaid pro vizualizaci architektury a toků

## 18. srpna 2025

### Komplexní aktualizace dokumentace - Standardy MCP 2025-06-18

#### MCP Security Best Practices (02-Security/) - Kompletní modernizace
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletní přepis zarovnaný se specifikací MCP 2025-06-18
  - **Povinné požadavky**: Přidány explicitní požadavky MUST/MUST NOT z oficiální specifikace s jasnými vizuálními indikátory
  - **12 základních bezpečnostních praktik**: Restrukturováno z 15 položek na komplexní bezpečnostní domény
    - Bezpečnost tokenů a autentizace s integrací externího poskytovatele identity
    - Správa relací a bezpečnost transportu s kryptografickými požadavky
    - Ochrana proti AI-specifickým hrozbám s integrací Microsoft Prompt Shields
    - Řízení přístupu a oprávnění s principem minimálních oprávnění
    - Bezpečnost obsahu a monitorování s integrací Azure Content Safety
    - Bezpečnost dodavatelského řetězce s komplexním ověřením komponent
    - Bezpečnost OAuth a prevence zmateného zástupce s implementací PKCE
    - Reakce na incidenty a obnova s automatizovanými schopnostmi
    - Soulad a správa s regulačním zarovnáním
    - Pokročilé bezpečnostní kontroly s architekturou nulové důvěry
    - Integrace bezpečnostního ekosystému Microsoft s komplexními řešeními
    - Kontinuální evoluce bezpečnosti s adaptivními praktikami
  - **Řešení Microsoft Security**: Rozšířené pokyny pro integraci Prompt Shields, Azure Content Safety, Entra ID a GitHub Advanced Security
  - **Implementační zdroje**: Kategorizované komplexní odkazy na oficiální dokumentaci MCP, řešení Microsoft Security, bezpečnostní standardy a implementační průvodce

#### Pokročilé bezpečnostní kontroly (02-Security/) - Podniková implementace
- **MCP-SECURITY-CONTROLS-2025.md**: Kompletní přepracování s bezpečnostním rámcem na podnikové úrovni
  - **9 komplexních bezpečnostních domén**: Rozšířeno z základních kontrol na podrobný podnikový rámec
    - Pokročilá autentizace a autorizace s integrací Microsoft Entra ID
    - Bezpečnost tokenů a kontroly proti průchodu s komplexní validací
    - Bezpečnost relací s prevencí únosu
    - AI-specifické bezpečnostní kontroly s prevencí injekce promptů a otravou nástrojů
    - Prevence útoků zmateného zástupce s bezpečností proxy OAuth
    - Bezpečnost provádění nástrojů s izolací a sandboxingem
    - Kontroly bezpečnosti dodavatelského řetězce s ověřením závislostí
    - Monitorovací a detekční kontroly s integrací SIEM
    - Reakce na incidenty a obnova s automatizovanými schopnostmi
  - **Příklady implementace**: Přidány podrobné bloky konfigurace YAML a
- **Vizuální indikátory**: Jasné označení povinných požadavků vs. doporučených postupů

#### Základní koncepty (01-CoreConcepts/) - Kompletní modernizace
- **Aktualizace verze protokolu**: Aktualizováno na aktuální MCP specifikaci 2025-06-18 s verzováním podle data (formát YYYY-MM-DD)
- **Zjemnění architektury**: Vylepšené popisy Hostů, Klientů a Serverů, které odrážejí aktuální vzory MCP architektury
  - Hosté nyní jasně definováni jako AI aplikace koordinující více připojení MCP klientů
  - Klienti popsáni jako konektory protokolu udržující vztahy jeden na jednoho se servery
  - Servery rozšířeny o scénáře lokálního vs. vzdáleného nasazení
- **Restrukturalizace primitivů**: Kompletní přepracování primitivů serveru a klienta
  - Primitivy serveru: Zdroje (datové zdroje), Výzvy (šablony), Nástroje (spustitelné funkce) s podrobnými vysvětleními a příklady
  - Primitivy klienta: Sampling (LLM dokončení), Elicitation (uživatelský vstup), Logging (ladění/monitorování)
  - Aktualizováno podle aktuálních vzorů metod pro objevování (`*/list`), získávání (`*/get`) a provádění (`*/call`)
- **Architektura protokolu**: Představen dvouvrstvý model architektury
  - Datová vrstva: Základ JSON-RPC 2.0 s řízením životního cyklu a primitivy
  - Transportní vrstva: STDIO (lokální) a Streamable HTTP se SSE (vzdálené) transportní mechanismy
- **Bezpečnostní rámec**: Komplexní bezpečnostní principy včetně explicitního souhlasu uživatele, ochrany soukromí dat, bezpečnosti provádění nástrojů a bezpečnosti transportní vrstvy
- **Komunikační vzory**: Aktualizované zprávy protokolu zobrazující inicializaci, objevování, provádění a tok oznámení
- **Příklady kódu**: Obnovené příklady v různých jazycích (.NET, Java, Python, JavaScript) odrážející aktuální vzory MCP SDK

#### Bezpečnost (02-Security/) - Komplexní přepracování bezpečnosti  
- **Sjednocení se standardy**: Plné sladění s bezpečnostními požadavky MCP specifikace 2025-06-18
- **Evoluce autentizace**: Dokumentována evoluce od vlastních OAuth serverů k delegaci externím poskytovatelům identity (Microsoft Entra ID)
- **Analýza hrozeb specifických pro AI**: Rozšířené pokrytí moderních útoků na AI
  - Podrobné scénáře útoků injekcí výzev s příklady z reálného světa
  - Mechanismy otravy nástrojů a vzory útoků typu "rug pull"
  - Otrava kontextového okna a útoky na zmatení modelu
- **Řešení bezpečnosti AI od Microsoftu**: Komplexní pokrytí ekosystému bezpečnosti Microsoftu
  - AI Prompt Shields s pokročilou detekcí, zvýrazněním a technikami oddělovačů
  - Vzory integrace Azure Content Safety
  - GitHub Advanced Security pro ochranu dodavatelského řetězce
- **Pokročilé zmírnění hrozeb**: Podrobné bezpečnostní kontroly pro
  - Únos relace s MCP-specifickými scénáři útoků a požadavky na kryptografické ID relace
  - Problémy zmateného zástupce v MCP proxy scénářích s požadavky na explicitní souhlas
  - Zranitelnosti při předávání tokenů s povinnými validačními kontrolami
- **Bezpečnost dodavatelského řetězce**: Rozšířené pokrytí AI dodavatelského řetězce včetně základních modelů, služeb embeddingů, poskytovatelů kontextu a API třetích stran
- **Základní bezpečnost**: Vylepšená integrace s podnikatelskými bezpečnostními vzory včetně architektury nulové důvěry a ekosystému bezpečnosti Microsoftu
- **Organizace zdrojů**: Kategorizované komplexní odkazy na zdroje podle typu (Oficiální dokumenty, Standardy, Výzkum, Řešení Microsoftu, Implementační příručky)

### Vylepšení kvality dokumentace
- **Strukturované vzdělávací cíle**: Vylepšené vzdělávací cíle s konkrétními, akčními výsledky 
- **Křížové odkazy**: Přidány odkazy mezi souvisejícími tématy bezpečnosti a základních konceptů
- **Aktuální informace**: Aktualizovány všechny odkazy na data a specifikace na aktuální standardy
- **Pokyny k implementaci**: Přidány konkrétní, akční pokyny k implementaci napříč oběma sekcemi

## 16. července 2025

### README a vylepšení navigace
- Kompletně přepracována navigace kurikulem v README.md
- Nahrazeny značky `<details>` přístupnějším formátem tabulky
- Vytvořeny alternativní možnosti rozvržení v nové složce "alternative_layouts"
- Přidány příklady navigace ve stylu karet, záložek a akordeonu
- Aktualizována sekce struktury repozitáře, aby zahrnovala všechny nejnovější soubory
- Vylepšena sekce "Jak používat toto kurikulum" s jasnými doporučeními
- Aktualizovány odkazy na MCP specifikace, aby směřovaly na správné URL
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
- Přidány pokyny k nastavení a používání terminálového klienta Cline
- Aktualizována sekce MCP klientů, aby zahrnovala všechny populární možnosti klientů
- Vylepšeny příklady příspěvků s přesnějšími ukázkami kódu

### Pokročilá témata (05-AdvancedTopics/)
- Organizovány všechny složky specializovaných témat s konzistentním pojmenováním
- Přidány materiály a příklady kontextového inženýrství
- Přidána dokumentace integrace agentů Foundry
- Vylepšena dokumentace integrace bezpečnosti Entra ID

## 11. června 2025

### Počáteční vytvoření
- Vydána první verze kurikula MCP pro začátečníky
- Vytvořena základní struktura pro všech 10 hlavních sekcí
- Implementována vizuální mapa kurikula pro navigaci
- Přidány počáteční ukázkové projekty v několika programovacích jazycích

### Začínáme (03-GettingStarted/)
- Vytvořeny první příklady implementace serveru
- Přidány pokyny pro vývoj klienta
- Zahrnuty pokyny pro integraci LLM klienta
- Přidána dokumentace integrace VS Code
- Implementovány příklady serverů s událostmi odesílanými serverem (SSE)

### Základní koncepty (01-CoreConcepts/)
- Přidáno podrobné vysvětlení architektury klient-server
- Vytvořena dokumentace klíčových komponent protokolu
- Zdokumentovány vzory zpráv v MCP

## 23. května 2025

### Struktura repozitáře
- Inicializován repozitář se základní strukturou složek
- Vytvořeny README soubory pro každou hlavní sekci
- Nastavena infrastruktura pro překlady
- Přidány obrazové materiály a diagramy

### Dokumentace
- Vytvořen počáteční README.md s přehledem kurikula
- Přidány CODE_OF_CONDUCT.md a SECURITY.md
- Nastaven SUPPORT.md s pokyny pro získání pomoci
- Vytvořena předběžná struktura studijního průvodce

## 15. dubna 2025

### Plánování a rámec
- Počáteční plánování kurikula MCP pro začátečníky
- Definovány vzdělávací cíle a cílová skupina
- Nastíněna struktura kurikula o 10 sekcích
- Vyvinut konceptuální rámec pro příklady a případové studie
- Vytvořeny počáteční prototypové příklady pro klíčové koncepty

---

**Prohlášení**:  
Tento dokument byl přeložen pomocí služby AI pro překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Neodpovídáme za žádná nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.