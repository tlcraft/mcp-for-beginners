<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:30:05+00:00",
  "source_file": "changelog.md",
  "language_code": "cs"
}
-->
# Changelog: MCP pro začátečníky - učební plán

Tento dokument slouží jako záznam všech významných změn provedených v učebním plánu Model Context Protocol (MCP) pro začátečníky. Změny jsou dokumentovány v obráceném chronologickém pořadí (nejnovější změny jako první).

## 15. září 2025

### Rozšíření pokročilých témat - Vlastní transporty a inženýrství kontextu

#### MCP Vlastní transporty (05-AdvancedTopics/mcp-transport/) - Nový průvodce pokročilou implementací
- **README.md**: Kompletní průvodce implementací vlastních transportních mechanismů MCP
  - **Azure Event Grid Transport**: Komplexní bezserverová implementace transportu založeného na událostech
    - Příklady v C#, TypeScriptu a Pythonu s integrací Azure Functions
    - Vzory architektury založené na událostech pro škálovatelné MCP řešení
    - Přijímače webhooků a zpracování zpráv na bázi push
  - **Azure Event Hubs Transport**: Implementace transportu pro vysokou propustnost streamování
    - Schopnosti streamování v reálném čase pro scénáře s nízkou latencí
    - Strategie rozdělení a správa kontrolních bodů
    - Optimalizace výkonu a dávkové zpracování zpráv
  - **Vzory integrace v podniku**: Architektonické příklady připravené pro produkci
    - Distribuované zpracování MCP napříč více Azure Functions
    - Hybridní transportní architektury kombinující různé typy transportů
    - Strategie pro trvanlivost zpráv, spolehlivost a zpracování chyb
  - **Bezpečnost a monitorování**: Integrace Azure Key Vault a vzory pro observabilitu
    - Autentizace spravované identity a přístup s minimálními oprávněními
    - Telemetrie Application Insights a monitorování výkonu
    - Vzory pro obvody a odolnost vůči chybám
  - **Testovací rámce**: Komplexní strategie testování vlastních transportů
    - Jednotkové testování s testovacími dvojníky a rámci pro simulaci
    - Integrační testování s Azure Test Containers
    - Úvahy o výkonu a zátěžovém testování

#### Inženýrství kontextu (05-AdvancedTopics/mcp-contextengineering/) - Nově vznikající disciplína AI
- **README.md**: Komplexní průzkum inženýrství kontextu jako nově vznikajícího oboru
  - **Základní principy**: Sdílení kontextu, povědomí o rozhodování akcí a správa oken kontextu
  - **Zarovnání s MCP protokolem**: Jak návrh MCP řeší výzvy inženýrství kontextu
    - Omezení oken kontextu a strategie progresivního načítání
    - Určování relevance a dynamické získávání kontextu
    - Multimodální zpracování kontextu a bezpečnostní úvahy
  - **Implementační přístupy**: Jednovláknové vs. multi-agentní architektury
    - Techniky rozdělení a prioritizace kontextu
    - Progresivní načítání kontextu a strategie komprese
    - Vrstvené přístupy ke kontextu a optimalizace získávání
  - **Rámec měření**: Nově vznikající metriky pro hodnocení efektivity kontextu
    - Účinnost vstupů, výkon, kvalita a úvahy o uživatelské zkušenosti
    - Experimentální přístupy k optimalizaci kontextu
    - Analýza selhání a metodologie zlepšení

#### Aktualizace navigace učebního plánu (README.md)
- **Vylepšená struktura modulů**: Aktualizovaná tabulka učebního plánu zahrnující nová pokročilá témata
  - Přidány položky Inženýrství kontextu (5.14) a Vlastní transporty (5.15)
  - Konzistentní formátování a navigační odkazy napříč všemi moduly
  - Aktualizované popisy odrážející aktuální rozsah obsahu

### Vylepšení struktury adresářů
- **Standardizace názvů**: Přejmenováno "mcp transport" na "mcp-transport" pro konzistenci s ostatními složkami pokročilých témat
- **Organizace obsahu**: Všechny složky 05-AdvancedTopics nyní dodržují konzistentní vzor názvů (mcp-[téma])

### Vylepšení kvality dokumentace
- **Zarovnání se specifikací MCP**: Veškerý nový obsah odkazuje na aktuální specifikaci MCP 2025-06-18
- **Vícejazyčné příklady**: Komplexní příklady kódu v C#, TypeScriptu a Pythonu
- **Zaměření na podnikové prostředí**: Vzory připravené pro produkci a integrace s Azure cloudem
- **Vizualizace dokumentace**: Diagramy Mermaid pro vizualizaci architektury a toků

## 18. srpna 2025

### Komplexní aktualizace dokumentace - Standardy MCP 2025-06-18

#### Nejlepší bezpečnostní praktiky MCP (02-Security/) - Kompletní modernizace
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletní přepis zarovnaný se specifikací MCP 2025-06-18
  - **Povinné požadavky**: Přidány explicitní požadavky MUST/MUST NOT z oficiální specifikace s jasnými vizuálními indikátory
  - **12 základních bezpečnostních praktik**: Restrukturalizováno z 15 položek na komplexní bezpečnostní domény
    - Bezpečnost tokenů a autentizace s integrací externího poskytovatele identity
    - Správa relací a transportní bezpečnost s kryptografickými požadavky
    - Ochrana proti AI-specifickým hrozbám s integrací Microsoft Prompt Shields
    - Řízení přístupu a oprávnění s principem minimálních oprávnění
    - Bezpečnost obsahu a monitorování s integrací Azure Content Safety
    - Bezpečnost dodavatelského řetězce s komplexním ověřením komponent
    - Bezpečnost OAuth a prevence zmateného zástupce s implementací PKCE
    - Reakce na incidenty a obnova s automatizovanými schopnostmi
    - Soulad a správa s regulačním zarovnáním
    - Pokročilé bezpečnostní kontroly s architekturou nulové důvěry
    - Integrace ekosystému Microsoft Security s komplexními řešeními
    - Kontinuální evoluce bezpečnosti s adaptivními praktikami
  - **Řešení Microsoft Security**: Rozšířené pokyny pro integraci Prompt Shields, Azure Content Safety, Entra ID a GitHub Advanced Security
  - **Implementační zdroje**: Kategorizované komplexní odkazy na zdroje podle Oficiální dokumentace MCP, Řešení Microsoft Security, Bezpečnostní standardy a Implementační příručky

#### Pokročilé bezpečnostní kontroly (02-Security/) - Implementace pro podnikové prostředí
- **MCP-SECURITY-CONTROLS-2025.md**: Kompletní přepracování s bezpečnostním rámcem na úrovni podniku
  - **9 komplexních bezpečnostních domén**: Rozšířeno ze základních kontrol na podrobný rámec pro podnikové prostředí
    - Pokročilá autentizace a autorizace s integrací Microsoft Entra ID
    - Bezpečnost tokenů a kontroly proti průchodu s komplexním ověřením
    - Bezpečnost relací s prevencí únosu
    - AI-specifické bezpečnostní kontroly s prevencí injekce promptů a otravou nástrojů
    - Prevence zmateného zástupce s bezpečností proxy OAuth
    - Bezpečnost provádění nástrojů s izolací a sandboxingem
    - Kontroly bezpečnosti dodavatelského řetězce s ověřením závislostí
    - Monitorovací a detekční kontroly s integrací SIEM
    - Reakce na incidenty a obnova s automatizovanými schopnostmi
  - **Implementační příklady**: Přidány podrobné bloky konfigurace YAML a příklady kódu
  - **Integrace řešení Microsoft**: Komplexní pokrytí bezpečnostních služeb Azure, GitHub Advanced Security a správy podnikové identity

#### Pokročilá bezpečnostní témata (05-AdvancedTopics/mcp-security/) - Implementace připravená pro produkci
- **README.md**: Kompletní přepis pro implementaci bezpečnosti na úrovni podniku
  - **Zarovnání s aktuální specifikací**: Aktualizováno na specifikaci MCP 2025-06-18 s povinnými bezpečnostními požadavky
  - **Rozšířená autentizace**: Integrace Microsoft Entra ID s komplexními příklady v .NET a Java Spring Security
  - **Integrace AI bezpečnosti**: Implementace Microsoft Prompt Shields a Azure Content Safety s podrobnými příklady v Pythonu
  - **Pokročilé zmírnění hrozeb**: Komplexní implementační příklady pro
    - Prevence zmateného zástupce s PKCE a validací uživatelského souhlasu
    - Prevence průchodu tokenů s validací publika a bezpečnou správou tokenů
    - Prevence únosu relací s kryptografickým propojením a analýzou chování
  - **Integrace podnikové bezpečnosti**: Monitorování Azure Application Insights, detekční pipeline hrozeb a bezpečnost dodavatelského řetězce
  - **Kontrolní seznam implementace**: Jasné povinné vs. doporučené bezpečnostní kontroly s výhodami ekosystému Microsoft Security

### Vylepšení kvality dokumentace a zarovnání se standardy
- **Reference specifikace**: Aktualizovány všechny odkazy na aktuální specifikaci MCP 2025-06-18
- **Ekosystém Microsoft Security**: Rozšířené pokyny pro integraci napříč celou bezpečnostní dokumentací
- **Praktická implementace**: Přidány podrobné příklady kódu v .NET, Java a Pythonu s podnikovými vzory
- **Organizace zdrojů**: Komplexní kategorizace oficiální dokumentace, bezpečnostních standardů a implementačních příruček
- **Vizualní indikátory**: Jasné označení povinných požadavků vs. doporučených praktik

## 16. července 2025

### Vylepšení README a navigace
- Kompletně přepracována navigace učebního plánu v README.md
- Nahrazeny `<details>` tagy přístupnějším formátem založeným na tabulkách
- Vytvořeny alternativní možnosti rozložení v nové složce "alternative_layouts"
- Přidány příklady navigace založené na kartách, záložkách a akordeonech
- Aktualizována sekce struktury repozitáře, aby zahrnovala všechny nejnovější soubory
- Vylepšena sekce "Jak používat tento učební plán" s jasnými doporučeními
- Aktualizovány odkazy na specifikaci MCP, aby směřovaly na správné URL
- Přidána sekce Inženýrství kontextu (5.14) do struktury učebního plánu

### Aktualizace studijního průvodce
- Kompletně přepracován studijní průvodce, aby odpovídal aktuální struktuře repozitáře
- Přidány nové sekce pro MCP klienty a nástroje a populární MCP servery
- Aktualizována vizuální mapa učebního plánu, aby přesně odrážela všechna témata
- Vylepšeny popisy pokročilých témat, aby pokryly všechna specializovaná témata
- Aktualizována sekce případových studií, aby odrážela skutečné příklady
- Přidán tento komplexní changelog

### Příspěvky komunity (06-CommunityContributions/)
- Přidány podrobné informace o MCP serverech pro generování obrázků
- Přidána komplexní sekce o používání Claude ve VSCode
- Přidány pokyny pro nastavení a používání klienta Cline v terminálu
- Aktualizována sekce MCP klientů, aby zahrnovala všechny populární možnosti klientů
- Vylepšeny příklady příspěvků s přesnějšími ukázkami kódu

### Pokročilá témata (05-AdvancedTopics/)
- Organizovány všechny specializované složky témat s konzistentním pojmenováním
- Přidány materiály a příklady inženýrství kontextu
- Přidána dokumentace integrace agentů Foundry
- Vylepšena dokumentace integrace bezpečnosti Entra ID

## 11. června 2025

### Počáteční vytvoření
- Vydána první verze učebního plánu MCP pro začátečníky
- Vytvořena základní struktura pro všech 10 hlavních sekcí
- Implementována vizuální mapa učebního plánu pro navigaci
- Přidány počáteční ukázkové projekty v několika programovacích jazycích

### Začínáme (03-GettingStarted/)
- Vytvořeny první příklady implementace serveru
- Přidány pokyny pro vývoj klienta
- Zahrnuty pokyny pro integraci klienta LLM
- Přidána dokumentace integrace VS Code
- Implementovány příklady serveru s událostmi odesílanými serverem (SSE)

### Základní koncepty (01-CoreConcepts/)
- Přidáno podrobné vysvětlení architektury klient-server
- Vytvořena dokumentace klíčových komponent protokolu
- Dokumentovány vzory zpráv v MCP

## 23. května 2025

### Struktura repozitáře
- Inicializován repozitář se základní strukturou složek
- Vytvořeny README soubory pro každou hlavní sekci
- Nastavena infrastruktura pro překlady
- Přidány obrazové materiály a diagramy

### Dokumentace
- Vytvořen počáteční README.md s přehledem učebního plánu
- Přidány CODE_OF_CONDUCT.md a SECURITY.md
- Nastaven SUPPORT.md s pokyny pro získání pomoci
- Vytvořena předběžná struktura studijního průvodce

## 15. dubna 2025

### Plánování a rámec
- Počáteční plánování učebního plánu MCP pro začátečníky
- Definovány vzdělávací cíle a cílová skupina
- Nastíněna 10-sekční struktura učebního plánu
- Vyvinut konceptuální rámec pro příklady a případové studie
- Vytvořeny počáteční prototypové příklady pro klíčové koncepty

---

**Prohlášení**:  
Tento dokument byl přeložen pomocí služby pro automatický překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace doporučujeme profesionální lidský překlad. Nenese odpovědnost za žádná nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.