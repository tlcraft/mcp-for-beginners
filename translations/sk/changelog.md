<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:31:18+00:00",
  "source_file": "changelog.md",
  "language_code": "sk"
}
-->
# Zmeny: MCP pre začiatočníkov - učebné osnovy

Tento dokument slúži ako záznam všetkých významných zmien vykonaných v učebných osnovách Model Context Protocol (MCP) pre začiatočníkov. Zmeny sú dokumentované v obrátenom chronologickom poradí (najnovšie zmeny ako prvé).

## 15. september 2025

### Rozšírenie pokročilých tém - Vlastné transporty a inžinierstvo kontextu

#### MCP Vlastné transporty (05-AdvancedTopics/mcp-transport/) - Nový pokročilý implementačný sprievodca
- **README.md**: Kompletný sprievodca implementáciou vlastných transportných mechanizmov MCP
  - **Azure Event Grid Transport**: Komplexná implementácia serverless transportu založeného na udalostiach
    - Príklady v C#, TypeScript a Python s integráciou Azure Functions
    - Vzory architektúry založenej na udalostiach pre škálovateľné MCP riešenia
    - Prijímače webhookov a spracovanie správ na základe push mechanizmu
  - **Azure Event Hubs Transport**: Implementácia transportu s vysokou priepustnosťou pre scenáre s nízkou latenciou
    - Funkcie pre streamovanie v reálnom čase
    - Stratégie rozdelenia a správa kontrolných bodov
    - Optimalizácia výkonu a dávkové spracovanie správ
  - **Vzory integrácie podnikov**: Príklady architektúry pripravené na produkciu
    - Distribuované spracovanie MCP naprieč viacerými Azure Functions
    - Hybridné transportné architektúry kombinujúce rôzne typy transportov
    - Stratégie trvanlivosti správ, spoľahlivosti a spracovania chýb
  - **Bezpečnosť a monitorovanie**: Integrácia Azure Key Vault a vzory pozorovateľnosti
    - Autentifikácia spravovaných identít a prístup s minimálnymi oprávneniami
    - Telemetria Application Insights a monitorovanie výkonu
    - Mechanizmy ochrany proti zlyhaniu a vzory odolnosti
  - **Testovacie rámce**: Komplexné stratégie testovania vlastných transportov
    - Jednotkové testovanie s testovacími dvojníkmi a rámcami na simuláciu
    - Integračné testovanie s Azure Test Containers
    - Úvahy o výkonnostnom a záťažovom testovaní

#### Inžinierstvo kontextu (05-AdvancedTopics/mcp-contextengineering/) - Nová disciplína v oblasti AI
- **README.md**: Komplexný prieskum inžinierstva kontextu ako vznikajúcej oblasti
  - **Základné princípy**: Zdieľanie kontextu, uvedomovanie si rozhodnutí a správa kontextových okien
  - **Zladenie s MCP protokolom**: Ako dizajn MCP rieši výzvy inžinierstva kontextu
    - Obmedzenia kontextových okien a stratégie progresívneho načítania
    - Určovanie relevantnosti a dynamické získavanie kontextu
    - Viacmodalné spracovanie kontextu a úvahy o bezpečnosti
  - **Implementačné prístupy**: Jednovláknové vs. multi-agentové architektúry
    - Techniky rozdelenia kontextu a určovania priorít
    - Progresívne načítanie kontextu a kompresné stratégie
    - Vrstvené prístupy ku kontextu a optimalizácia získavania
  - **Rámec merania**: Nové metriky na hodnotenie efektívnosti kontextu
    - Účinnosť vstupov, výkon, kvalita a úvahy o používateľskej skúsenosti
    - Experimentálne prístupy k optimalizácii kontextu
    - Analýza zlyhaní a metodológie zlepšovania

#### Aktualizácie navigácie v učebných osnovách (README.md)
- **Vylepšená štruktúra modulov**: Aktualizovaná tabuľka učebných osnov na zahrnutie nových pokročilých tém
  - Pridané inžinierstvo kontextu (5.14) a vlastné transporty (5.15)
  - Konzistentné formátovanie a navigačné odkazy naprieč všetkými modulmi
  - Aktualizované popisy na odrážanie aktuálneho rozsahu obsahu

### Vylepšenia štruktúry adresárov
- **Štandardizácia názvov**: Premenovanie "mcp transport" na "mcp-transport" pre konzistenciu s ostatnými pokročilými témami
- **Organizácia obsahu**: Všetky priečinky 05-AdvancedTopics teraz dodržiavajú konzistentný vzor názvov (mcp-[téma])

### Vylepšenia kvality dokumentácie
- **Zladenie so špecifikáciou MCP**: Všetok nový obsah odkazuje na aktuálnu špecifikáciu MCP 2025-06-18
- **Viacjazyčné príklady**: Komplexné ukážky kódu v C#, TypeScript a Python
- **Zameranie na podniky**: Vzory pripravené na produkciu a integrácia s Azure cloudom
- **Vizualizácia dokumentácie**: Diagramy Mermaid pre vizualizáciu architektúry a tokov

## 18. august 2025

### Komplexná aktualizácia dokumentácie - Štandardy MCP 2025-06-18

#### MCP Najlepšie bezpečnostné praktiky (02-Security/) - Kompletná modernizácia
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletné prepracovanie v súlade so špecifikáciou MCP 2025-06-18
  - **Povinné požiadavky**: Pridané explicitné požiadavky MUST/MUST NOT zo špecifikácie s jasnými vizuálnymi indikátormi
  - **12 základných bezpečnostných praktík**: Prepracované z 15-bodového zoznamu na komplexné bezpečnostné domény
    - Bezpečnosť tokenov a autentifikácia s integráciou externého poskytovateľa identít
    - Správa relácií a transportná bezpečnosť s kryptografickými požiadavkami
    - Ochrana pred AI špecifickými hrozbami s integráciou Microsoft Prompt Shields
    - Kontrola prístupu a oprávnení s princípom minimálnych oprávnení
    - Bezpečnosť obsahu a monitorovanie s integráciou Azure Content Safety
    - Bezpečnosť dodávateľského reťazca s komplexnou verifikáciou komponentov
    - OAuth bezpečnosť a prevencia zmätkových útokov s implementáciou PKCE
    - Reakcia na incidenty a obnova s automatizovanými schopnosťami
    - Súlad a správa s regulačným zladením
    - Pokročilé bezpečnostné kontroly s architektúrou nulovej dôvery
    - Integrácia Microsoft bezpečnostného ekosystému s komplexnými riešeniami
    - Kontinuálny vývoj bezpečnosti s adaptívnymi praktikami
  - **Microsoft bezpečnostné riešenia**: Vylepšené pokyny na integráciu Prompt Shields, Azure Content Safety, Entra ID a GitHub Advanced Security
  - **Implementačné zdroje**: Kategorizované komplexné odkazy na zdroje podľa oficiálnej dokumentácie MCP, Microsoft bezpečnostných riešení, bezpečnostných štandardov a implementačných sprievodcov

#### Pokročilé bezpečnostné kontroly (02-Security/) - Implementácia pre podniky
- **MCP-SECURITY-CONTROLS-2025.md**: Kompletné prepracovanie s podnikovo orientovaným bezpečnostným rámcom
  - **9 komplexných bezpečnostných domén**: Rozšírené z jednoduchých kontrol na podrobný podnikový rámec
    - Pokročilá autentifikácia a autorizácia s integráciou Microsoft Entra ID
    - Bezpečnosť tokenov a kontroly proti passtrough s komplexnou validáciou
    - Bezpečnostné kontroly relácií s prevenciou únosov
    - AI špecifické bezpečnostné kontroly s prevenciou injekcie promptov a otravy nástrojov
    - Prevencia zmätkových útokov s bezpečnosťou proxy OAuth
    - Bezpečnosť vykonávania nástrojov s izoláciou a sandboxingom
    - Kontroly bezpečnosti dodávateľského reťazca s verifikáciou závislostí
    - Monitorovacie a detekčné kontroly s integráciou SIEM
    - Reakcia na incidenty a obnova s automatizovanými schopnosťami
  - **Implementačné príklady**: Pridané podrobné YAML konfiguračné bloky a ukážky kódu
  - **Integrácia Microsoft riešení**: Komplexné pokrytie Azure bezpečnostných služieb, GitHub Advanced Security a správy podnikových identít

#### Pokročilé témy bezpečnosti (05-AdvancedTopics/mcp-security/) - Implementácia pripravená na produkciu
- **README.md**: Kompletné prepracovanie pre podnikové bezpečnostné implementácie
  - **Zladenie s aktuálnou špecifikáciou**: Aktualizované na špecifikáciu MCP 2025-06-18 s povinnými bezpečnostnými požiadavkami
  - **Vylepšená autentifikácia**: Integrácia Microsoft Entra ID s komplexnými príkladmi v .NET a Java Spring Security
  - **Integrácia AI bezpečnosti**: Implementácia Microsoft Prompt Shields a Azure Content Safety s podrobnými príkladmi v Python
  - **Pokročilé zmiernenie hrozieb**: Komplexné implementačné príklady pre
    - Prevencia zmätkových útokov s PKCE a validáciou používateľského súhlasu
    - Prevencia passtrough tokenov s validáciou publika a bezpečnou správou tokenov
    - Prevencia únosov relácií s kryptografickým viazaním a analýzou správania
  - **Integrácia podnikovej bezpečnosti**: Monitorovanie Azure Application Insights, detekčné pipeline hrozieb a bezpečnosť dodávateľského reťazca
  - **Implementačný kontrolný zoznam**: Jasné povinné vs. odporúčané bezpečnostné kontroly s výhodami Microsoft bezpečnostného ekosystému

### Vylepšenia kvality dokumentácie a zladenie so štandardmi
- **Referencie na špecifikáciu**: Aktualizované všetky odkazy na aktuálnu špecifikáciu MCP 2025-06-18
- **Microsoft bezpečnostný ekosystém**: Vylepšené pokyny na integráciu naprieč celou bezpečnostnou dokumentáciou
- **Praktická implementácia**: Pridané podrobné ukážky kódu v .NET, Java a Python s podnikovými vzormi
- **Organizácia zdrojov**: Komplexná kategorizácia oficiálnej dokumentácie, bezpečnostných štandardov a implementačných sprievodcov
- **Vizuálne indikátory**: Jasné označenie povinných požiadaviek vs. odporúčaných praktík

## 16. júl 2025

### Vylepšenia README a navigácie
- Kompletný redizajn navigácie učebných osnov v README.md
- Nahradenie `<details>` tagov prístupnejším formátom založeným na tabuľkách
- Vytvorenie alternatívnych možností rozloženia v novom priečinku "alternative_layouts"
- Pridané príklady navigácie založenej na kartách, záložkách a akordeónoch
- Aktualizovaná sekcia štruktúry repozitára na zahrnutie všetkých najnovších súborov
- Vylepšená sekcia "Ako používať tieto učebné osnovy" s jasnými odporúčaniami
- Aktualizované odkazy na špecifikáciu MCP na správne URL
- Pridaná sekcia inžinierstva kontextu (5.14) do štruktúry učebných osnov

### Aktualizácie študijného sprievodcu
- Kompletná revízia študijného sprievodcu na zladenie s aktuálnou štruktúrou repozitára
- Pridané nové sekcie pre MCP klientov a nástroje, a populárne MCP servery
- Aktualizovaná vizuálna mapa učebných osnov na presné zobrazenie všetkých tém
- Vylepšené popisy pokročilých tém na pokrytie všetkých špecializovaných oblastí
- Aktualizovaná sekcia prípadových štúdií na odrážanie skutočných príkladov
- Pridaný tento komplexný záznam zmien

### Príspevky komunity (06-CommunityContributions/)
- Pridané podrobné informácie o MCP serveroch pre generovanie obrázkov
- Pridaná komplexná sekcia o používaní Claude vo VSCode
- Pridané pokyny na nastavenie a používanie klienta Cline v termináli
- Aktualizovaná sekcia MCP klientov na zahrnutie všetkých populárnych klientských možností
- Vylepšené príklady príspevkov s presnejšími ukážkami kódu

### Pokročilé témy (05-AdvancedTopics/)
- Organizované všetky špecializované témy do priečinkov s konzistentným názvom
- Pridané materiály a príklady inžinierstva kontextu
- Pridaná dokumentácia integrácie Foundry agentov
- Vylepšená dokumentácia bezpečnostnej integrácie Entra ID

## 11. jún 2025

### Počiatočné vytvorenie
- Uvoľnená prvá verzia učebných osnov MCP pre začiatočníkov
- Vytvorená základná štruktúra pre všetkých 10 hlavných sekcií
- Implementovaná vizuálna mapa učebných osnov pre navigáciu
- Pridané počiatočné ukážkové projekty v rôznych programovacích jazykoch

### Začíname (03-GettingStarted/)
- Vytvorené prvé príklady implementácie serverov
- Pridané pokyny na vývoj klientov
- Zahrnuté pokyny na integráciu LLM klientov
- Pridaná dokumentácia integrácie VS Code
- Implementované príklady serverov s udalosťami odosielanými serverom (SSE)

### Základné koncepty (01-CoreConcepts/)
- Pridané podrobné vysvetlenie architektúry klient-server
- Vytvorená dokumentácia kľúčových komponentov protokolu
- Dokumentované vzory správ v MCP

## 23. máj 2025

### Štruktúra repozitára
- Inicializovaný repozitár so základnou štruktúrou priečinkov
- Vytvorené README súbory pre každú hlavnú sekciu
- Nastavená infraštruktúra pre preklady
- Pridané obrazové zdroje a diagramy

### Dokumentácia
- Vytvorené počiatočné README.md s prehľadom učebných osnov
- Pridané CODE_OF_CONDUCT.md a SECURITY.md
- Nastavený SUPPORT.md s pokynmi na získanie pomoci
- Vytvorená predbežná štruktúra študijného sprievodcu

## 15. apríl 2025

### Plánovanie a rámec
- Počiatočné plánovanie učebných osnov MCP pre začiatočníkov
- Definované učebné ciele a cieľová skupina
- Načrtnutá 10-sekčná štruktúra učebných osnov
- Vyvinutý konceptuálny rámec pre príklady a prípadové štúdie
- Vytvorené počiatočné prototypové príklady pre kľúčové koncepty

---

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.