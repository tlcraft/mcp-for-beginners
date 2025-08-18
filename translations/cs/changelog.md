<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T14:49:44+00:00",
  "source_file": "changelog.md",
  "language_code": "cs"
}
-->
# Změny: Učební plán MCP pro začátečníky

Tento dokument slouží jako záznam všech významných změn provedených v učebním plánu Model Context Protocol (MCP) pro začátečníky. Změny jsou dokumentovány v obráceném chronologickém pořadí (nejnovější změny jako první).

## 18. srpna 2025

### Komplexní aktualizace dokumentace - Standardy MCP 2025-06-18

#### MCP Bezpečnostní osvědčené postupy (02-Security/) - Kompletní modernizace
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletní přepsání v souladu se specifikací MCP 2025-06-18
  - **Povinné požadavky**: Přidány explicitní požadavky MUST/MUST NOT ze specifikace s jasnými vizuálními indikátory
  - **12 základních bezpečnostních praktik**: Restrukturalizováno z 15 položek na komplexní bezpečnostní domény
    - Bezpečnost tokenů a autentizace s integrací externího poskytovatele identity
    - Správa relací a transportní bezpečnost s kryptografickými požadavky
    - Ochrana proti AI-specifickým hrozbám s integrací Microsoft Prompt Shields
    - Řízení přístupu a oprávnění s principem minimálních oprávnění
    - Bezpečnost obsahu a monitorování s integrací Azure Content Safety
    - Bezpečnost dodavatelského řetězce s ověřováním komponent
    - Bezpečnost OAuth a prevence útoků Confused Deputy s implementací PKCE
    - Reakce na incidenty a obnova s automatizovanými schopnostmi
    - Soulad a správa s regulačními požadavky
    - Pokročilé bezpečnostní kontroly s architekturou nulové důvěry
    - Integrace s Microsoft Security Ecosystem s komplexními řešeními
    - Neustálý vývoj bezpečnosti s adaptivními postupy
  - **Řešení Microsoft Security**: Rozšířené pokyny pro integraci Prompt Shields, Azure Content Safety, Entra ID a GitHub Advanced Security
  - **Zdroje pro implementaci**: Kategorizované odkazy na zdroje podle oficiální dokumentace MCP, řešení Microsoft Security, bezpečnostních standardů a implementačních příruček

#### Pokročilé bezpečnostní kontroly (02-Security/) - Implementace pro podniky
- **MCP-SECURITY-CONTROLS-2025.md**: Kompletní přepracování s bezpečnostním rámcem na úrovni podniku
  - **9 komplexních bezpečnostních domén**: Rozšířeno ze základních kontrol na podrobný podnikový rámec
    - Pokročilá autentizace a autorizace s integrací Microsoft Entra ID
    - Bezpečnost tokenů a prevence průchodu s komplexním ověřováním
    - Bezpečnost relací s prevencí únosů
    - AI-specifické bezpečnostní kontroly s prevencí injekcí a otravy nástrojů
    - Prevence útoků Confused Deputy s bezpečností proxy OAuth
    - Bezpečnost spouštění nástrojů s izolací a sandboxingem
    - Kontroly bezpečnosti dodavatelského řetězce s ověřováním závislostí
    - Monitorovací a detekční kontroly s integrací SIEM
    - Reakce na incidenty a obnova s automatizovanými schopnostmi
  - **Příklady implementace**: Přidány podrobné bloky konfigurace YAML a ukázky kódu
  - **Integrace řešení Microsoft**: Komplexní pokrytí bezpečnostních služeb Azure, GitHub Advanced Security a správy podnikové identity

#### Pokročilá témata bezpečnosti (05-AdvancedTopics/mcp-security/) - Implementace připravená pro produkci
- **README.md**: Kompletní přepsání pro implementaci podnikové bezpečnosti
  - **Aktuální specifikace**: Aktualizováno na specifikaci MCP 2025-06-18 s povinnými bezpečnostními požadavky
  - **Vylepšená autentizace**: Integrace Microsoft Entra ID s podrobnými příklady pro .NET a Java Spring Security
  - **Integrace AI bezpečnosti**: Implementace Microsoft Prompt Shields a Azure Content Safety s podrobnými příklady v Pythonu
  - **Pokročilá mitigace hrozeb**: Komplexní příklady implementace pro
    - Prevence útoků Confused Deputy s PKCE a validací uživatelského souhlasu
    - Prevence průchodu tokenů s validací publika a bezpečnou správou tokenů
    - Prevence únosů relací s kryptografickým vázáním a analýzou chování
  - **Integrace podnikové bezpečnosti**: Monitorování Azure Application Insights, detekční pipeline hrozeb a bezpečnost dodavatelského řetězce
  - **Kontrolní seznam implementace**: Jasné rozlišení mezi povinnými a doporučenými bezpečnostními kontrolami s výhodami ekosystému Microsoft Security

### Kvalita dokumentace a sladění se standardy
- **Odkazy na specifikace**: Aktualizovány všechny odkazy na aktuální specifikaci MCP 2025-06-18
- **Microsoft Security Ecosystem**: Rozšířené pokyny pro integraci v celé bezpečnostní dokumentaci
- **Praktická implementace**: Přidány podrobné ukázky kódu v .NET, Java a Pythonu s podnikových vzory
- **Organizace zdrojů**: Komplexní kategorizace oficiální dokumentace, bezpečnostních standardů a implementačních příruček
- **Vizuální indikátory**: Jasné označení povinných požadavků vs. doporučených postupů

#### Základní koncepty (01-CoreConcepts/) - Kompletní modernizace
- **Aktualizace verze protokolu**: Aktualizováno na aktuální specifikaci MCP 2025-06-18 s verzováním na základě data (formát YYYY-MM-DD)
- **Zlepšení architektury**: Vylepšené popisy hostitelů, klientů a serverů, aby odrážely aktuální vzory architektury MCP
  - Hostitelé nyní jasně definováni jako AI aplikace koordinující více připojení MCP klientů
  - Klienti popsáni jako konektory protokolu udržující vztahy jeden na jednoho se servery
  - Servery rozšířeny o scénáře místního vs. vzdáleného nasazení
- **Restrukturalizace primitiv**: Kompletní přepracování serverových a klientských primitiv
  - Serverové primitivy: Zdroje (datové zdroje), Šablony (prompty), Nástroje (spustitelné funkce) s podrobnými vysvětleními a příklady
  - Klientské primitivy: Vzorkování (LLM dokončení), Elicitace (uživatelský vstup), Protokolování (ladění/monitorování)
  - Aktualizováno s aktuálními vzory metod pro objevování (`*/list`), získávání (`*/get`) a provádění (`*/call`)
- **Architektura protokolu**: Představen dvouvrstvý model architektury
  - Datová vrstva: Základ JSON-RPC 2.0 s řízením životního cyklu a primitivy
  - Transportní vrstva: STDIO (místní) a Streamable HTTP s SSE (vzdálené) transportní mechanismy
- **Bezpečnostní rámec**: Komplexní bezpečnostní principy včetně explicitního uživatelského souhlasu, ochrany soukromí dat, bezpečnosti spouštění nástrojů a bezpečnosti transportní vrstvy
- **Komunikační vzory**: Aktualizovány zprávy protokolu pro zobrazení toků inicializace, objevování, provádění a notifikací
- **Ukázky kódu**: Aktualizovány vícejazyčné příklady (.NET, Java, Python, JavaScript), aby odrážely aktuální vzory MCP SDK

#### Bezpečnost (02-Security/) - Komplexní přepracování bezpečnosti  
- **Sladění se standardy**: Plné sladění s bezpečnostními požadavky specifikace MCP 2025-06-18
- **Vývoj autentizace**: Zdokumentován přechod od vlastních OAuth serverů k delegaci externím poskytovatelům identity (Microsoft Entra ID)
- **AI-specifická analýza hrozeb**: Rozšířené pokrytí moderních útoků na AI
  - Podrobné scénáře útoků injekcí promptů s příklady z reálného světa
  - Mechanismy otravy nástrojů a vzory útoků "rug pull"
  - Otrava kontextového okna a útoky na zmatení modelu
- **Řešení Microsoft AI Security**: Komplexní pokrytí ekosystému Microsoft Security
  - AI Prompt Shields s pokročilou detekcí, zvýrazněním a technikami oddělovačů
  - Vzory integrace Azure Content Safety
  - GitHub Advanced Security pro ochranu dodavatelského řetězce
- **Pokročilá mitigace hrozeb**: Podrobné bezpečnostní kontroly pro
  - Únosy relací s MCP-specifickými scénáři útoků a kryptografickými požadavky na ID relací
  - Problémy Confused Deputy v MCP proxy scénářích s explicitními požadavky na souhlas
  - Zranitelnosti průchodu tokenů s povinnými kontrolami validace
- **Bezpečnost dodavatelského řetězce**: Rozšířené pokrytí AI dodavatelského řetězce včetně základních modelů, služeb embeddingů, poskytovatelů kontextu a třetích stran API
- **Základní bezpečnost**: Rozšířená integrace s podnikovými bezpečnostními vzory včetně architektury nulové důvěry a ekosystému Microsoft Security
- **Organizace zdrojů**: Kategorizované komplexní odkazy na zdroje podle typu (Oficiální dokumentace, Standardy, Výzkum, Řešení Microsoft, Implementační příručky)

### Zlepšení kvality dokumentace
- **Strukturované výukové cíle**: Vylepšené výukové cíle s konkrétními, akčními výsledky
- **Křížové odkazy**: Přidány odkazy mezi souvisejícími tématy bezpečnosti a základních konceptů
- **Aktuální informace**: Aktualizovány všechny odkazy na data a specifikace na aktuální standardy
- **Pokyny k implementaci**: Přidány konkrétní, akční pokyny k implementaci v obou sekcích

## 16. července 2025

### Vylepšení README a navigace
- Kompletně přepracována navigace učebním plánem v README.md
- Nahrazeny `<details>` tagy přístupnějším formátem tabulek
- Vytvořeny alternativní možnosti rozvržení v nové složce "alternative_layouts"
- Přidány příklady navigace ve stylu karet, záložek a akordeonů
- Aktualizována sekce struktury úložiště, aby zahrnovala všechny nejnovější soubory
- Vylepšena sekce "Jak používat tento učební plán" s jasnými doporučeními
- Aktualizovány odkazy na specifikace MCP, aby odkazovaly na správné URL
- Přidána sekce Kontextové inženýrství (5.14) do struktury učebního plánu

### Aktualizace studijního průvodce
- Kompletně přepracován studijní průvodce, aby odpovídal aktuální struktuře úložiště
- Přidány nové sekce pro MCP klienty a nástroje a populární MCP servery
- Aktualizována vizuální mapa učebního plánu, aby přesně odrážela všechna témata
- Rozšířeny popisy pokročilých témat, aby pokryly všechny specializované oblasti
- Aktualizována sekce případových studií, aby odrážela skutečné příklady
- Přidán tento komplexní záznam změn

### Příspěvky komunity (06-CommunityContributions/)
- Přidány podrobné informace o MCP serverech pro generování obrázků
- Přidána komplexní sekce o používání Claude ve VSCode
- Přidány pokyny k nastavení a používání terminálového klienta Cline
- Aktualizována sekce MCP klientů, aby zahrnovala všechny populární možnosti klientů
- Vylepšeny příklady příspěvků s přesnějšími ukázkami kódu

### Pokročilá témata (05-AdvancedTopics/)
- Organizovány všechny složky specializovaných témat s konzistentním pojmenováním
- Přidány materiály a příklady kontextového inženýrství
- Přidána dokumentace k integraci Foundry agenta
- Vylepšena dokumentace k bezpečnostní integraci Entra ID

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
- Přidána dokumentace k integraci VS Code
- Implementovány příklady serveru s událostmi odesílanými serverem (SSE)

### Základní koncepty (01-CoreConcepts/)
- Přidáno podrobné vysvětlení architektury klient-server
- Vytvořena dokumentace klíčových komponent protokolu
- Zdokumentovány vzory zpráv v MCP

## 23. května 2025

### Struktura úložiště
- Inicializováno úložiště se základní strukturou složek
- Vytvořeny README soubory pro každou hlavní sekci
- Nastavena infrastruktura pro překlady
- Přidány obrazové zdroje a diagramy

### Dokumentace
- Vytvořen počáteční README.md s přehledem učebního plánu
- Přidány CODE_OF_CONDUCT.md a SECURITY.md
- Nastaven SUPPORT.md s pokyny pro získání pomoci
- Vytvořena předběžná struktura studijního průvodce

## 15. dubna 2025

### Plánování a rámec
- Počáteční plánování učebního plánu MCP pro začátečníky
- Definovány výukové cíle a cílové publikum
- Nastíněna 10sekční struktura učebního plánu
- Vyvinut konceptuální rámec pro příklady a případové studie
- Vytvořeny počáteční prototypové příklady pro klíčové koncepty

**Prohlášení:**  
Tento dokument byl přeložen pomocí služby pro automatizovaný překlad [Co-op Translator](https://github.com/Azure/co-op-translator). Ačkoli se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Neodpovídáme za žádná nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.