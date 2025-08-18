<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T20:08:52+00:00",
  "source_file": "changelog.md",
  "language_code": "sk"
}
-->
# Zmeny: MCP pre začiatočníkov - učebné osnovy

Tento dokument slúži ako záznam všetkých významných zmien vykonaných v učebných osnovách Model Context Protocol (MCP) pre začiatočníkov. Zmeny sú dokumentované v obrátenom chronologickom poradí (najnovšie zmeny sú uvedené ako prvé).

## 18. august 2025

### Komplexná aktualizácia dokumentácie - Štandardy MCP 2025-06-18

#### MCP Bezpečnostné najlepšie praktiky (02-Security/) - Kompletná modernizácia
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletné prepracovanie v súlade so špecifikáciou MCP 2025-06-18
  - **Povinné požiadavky**: Pridané explicitné požiadavky MUST/MUST NOT zo špecifikácie s jasnými vizuálnymi indikátormi
  - **12 základných bezpečnostných praktík**: Prepracované z 15 položiek na komplexné bezpečnostné domény
    - Bezpečnosť tokenov a autentifikácia s integráciou externého poskytovateľa identity
    - Správa relácií a transportná bezpečnosť s kryptografickými požiadavkami
    - Ochrana pred AI špecifickými hrozbami s integráciou Microsoft Prompt Shields
    - Kontrola prístupu a oprávnení s princípom minimálnych oprávnení
    - Bezpečnosť obsahu a monitorovanie s integráciou Azure Content Safety
    - Bezpečnosť dodávateľského reťazca s komplexnou verifikáciou komponentov
    - Bezpečnosť OAuth a prevencia zmätku proxy s implementáciou PKCE
    - Reakcia na incidenty a obnova s automatizovanými schopnosťami
    - Súlad a správa s regulačným zosúladením
    - Pokročilé bezpečnostné kontroly s architektúrou nulovej dôvery
    - Integrácia Microsoft Security Ecosystem s komplexnými riešeniami
    - Kontinuálny vývoj bezpečnosti s adaptívnymi praktikami
  - **Microsoft Security Solutions**: Vylepšené pokyny na integráciu pre Prompt Shields, Azure Content Safety, Entra ID a GitHub Advanced Security
  - **Implementačné zdroje**: Kategorizované odkazy na zdroje podľa oficiálnej dokumentácie MCP, Microsoft Security Solutions, bezpečnostných štandardov a implementačných príručiek

#### Pokročilé bezpečnostné kontroly (02-Security/) - Implementácia pre podniky
- **MCP-SECURITY-CONTROLS-2025.md**: Kompletné prepracovanie s bezpečnostným rámcom na úrovni podnikov
  - **9 komplexných bezpečnostných domén**: Rozšírené z jednoduchých kontrol na podrobný podnikový rámec
    - Pokročilá autentifikácia a autorizácia s integráciou Microsoft Entra ID
    - Bezpečnosť tokenov a kontroly proti prenosu s komplexnou validáciou
    - Bezpečnostné kontroly relácií s prevenciou únosu
    - AI špecifické bezpečnostné kontroly s prevenciou injekcie promptov a otravy nástrojov
    - Prevencia zmätku proxy útokov s bezpečnosťou OAuth proxy
    - Bezpečnosť vykonávania nástrojov s izoláciou a sandboxingom
    - Kontroly bezpečnosti dodávateľského reťazca s verifikáciou závislostí
    - Kontroly monitorovania a detekcie s integráciou SIEM
    - Reakcia na incidenty a obnova s automatizovanými schopnosťami
  - **Príklady implementácie**: Pridané podrobné YAML konfiguračné bloky a ukážky kódu
  - **Integrácia Microsoft Solutions**: Komplexné pokrytie bezpečnostných služieb Azure, GitHub Advanced Security a správy podnikových identít

#### Pokročilé témy bezpečnosti (05-AdvancedTopics/mcp-security/) - Implementácia pripravená na produkciu
- **README.md**: Kompletné prepracovanie pre implementáciu podnikovej bezpečnosti
  - **Zosúladenie aktuálnej špecifikácie**: Aktualizované na špecifikáciu MCP 2025-06-18 s povinnými bezpečnostnými požiadavkami
  - **Vylepšená autentifikácia**: Integrácia Microsoft Entra ID s podrobnými ukážkami pre .NET a Java Spring Security
  - **Integrácia AI bezpečnosti**: Implementácia Microsoft Prompt Shields a Azure Content Safety s podrobnými ukážkami v Pythone
  - **Pokročilá mitigácia hrozieb**: Komplexné implementačné príklady pre
    - Prevencia zmätku proxy útokov s PKCE a validáciou používateľského súhlasu
    - Prevencia prenosu tokenov s validáciou publika a bezpečnou správou tokenov
    - Prevencia únosu relácií s kryptografickým viazaním a analýzou správania
  - **Integrácia podnikovej bezpečnosti**: Monitorovanie Azure Application Insights, detekčné pipeline hrozieb a bezpečnosť dodávateľského reťazca
  - **Implementačný kontrolný zoznam**: Jasné povinné vs. odporúčané bezpečnostné kontroly s výhodami Microsoft bezpečnostného ekosystému

### Kvalita dokumentácie a zosúladenie so štandardmi
- **Referencie špecifikácií**: Aktualizované všetky odkazy na aktuálnu špecifikáciu MCP 2025-06-18
- **Microsoft Security Ecosystem**: Vylepšené pokyny na integráciu v celej bezpečnostnej dokumentácii
- **Praktická implementácia**: Pridané podrobné ukážky kódu v .NET, Java a Python s podnikovými vzormi
- **Organizácia zdrojov**: Komplexná kategorizácia oficiálnej dokumentácie, bezpečnostných štandardov a implementačných príručiek
- **Vizuálne indikátory**: Jasné označenie povinných požiadaviek vs. odporúčaných praktík

#### Základné koncepty (01-CoreConcepts/) - Kompletná modernizácia
- **Aktualizácia verzie protokolu**: Aktualizované na aktuálnu špecifikáciu MCP 2025-06-18 s verzovaním podľa dátumu (formát YYYY-MM-DD)
- **Rafinácia architektúry**: Vylepšené popisy hostiteľov, klientov a serverov na odrážanie aktuálnych vzorov architektúry MCP
  - Hostitelia teraz jasne definovaní ako AI aplikácie koordinujúce viacero pripojení MCP klientov
  - Klienti popísaní ako konektory protokolu udržiavajúce vzťahy jeden na jedného so servermi
  - Servery vylepšené s lokálnymi vs. vzdialenými scenármi nasadenia
- **Prepracovanie primitív**: Kompletné prepracovanie primitív servera a klienta
  - Primitívy servera: Zdroje (datové zdroje), Prompty (šablóny), Nástroje (vykonateľné funkcie) s podrobnými vysvetleniami a príkladmi
  - Primitívy klienta: Sampling (LLM dokončenia), Elicitácia (vstup používateľa), Logging (ladenie/monitorovanie)
  - Aktualizované s aktuálnymi vzormi metód objavovania (`*/list`), získavania (`*/get`) a vykonávania (`*/call`)
- **Architektúra protokolu**: Predstavený dvojvrstvový model architektúry
  - Dátová vrstva: Základ JSON-RPC 2.0 s manažmentom životného cyklu a primitívami
  - Transportná vrstva: STDIO (lokálne) a Streamable HTTP s SSE (vzdialené) transportné mechanizmy
- **Bezpečnostný rámec**: Komplexné bezpečnostné princípy vrátane explicitného súhlasu používateľa, ochrany súkromia dát, bezpečnosti vykonávania nástrojov a bezpečnosti transportnej vrstvy
- **Komunikačné vzory**: Aktualizované správy protokolu na zobrazenie inicializácie, objavovania, vykonávania a notifikačných tokov
- **Ukážky kódu**: Obnovené viacjazyčné príklady (.NET, Java, Python, JavaScript) na odrážanie aktuálnych vzorov MCP SDK

#### Bezpečnosť (02-Security/) - Komplexná bezpečnostná modernizácia  
- **Zosúladenie so štandardmi**: Plné zosúladenie s bezpečnostnými požiadavkami špecifikácie MCP 2025-06-18
- **Evolúcia autentifikácie**: Dokumentovaná evolúcia od vlastných OAuth serverov k delegácii externého poskytovateľa identity (Microsoft Entra ID)
- **AI špecifická analýza hrozieb**: Rozšírené pokrytie moderných AI útokových vektorov
  - Podrobné scenáre útokov injekcie promptov s reálnymi príkladmi
  - Mechanizmy otravy nástrojov a vzory útokov "rug pull"
  - Otrava kontextového okna a útoky zmätku modelu
- **Microsoft AI bezpečnostné riešenia**: Komplexné pokrytie bezpečnostného ekosystému Microsoft
  - AI Prompt Shields s pokročilou detekciou, zvýraznením a technikami delimitácie
  - Integrácia Azure Content Safety
  - GitHub Advanced Security na ochranu dodávateľského reťazca
- **Pokročilá mitigácia hrozieb**: Podrobné bezpečnostné kontroly pre
  - Únos relácií s MCP špecifickými scenármi útokov a kryptografickými požiadavkami na ID relácií
  - Problémy zmätku proxy v scenároch MCP proxy s explicitnými požiadavkami na súhlas
  - Zraniteľnosti prenosu tokenov s povinnými kontrolami validácie
- **Bezpečnosť dodávateľského reťazca**: Rozšírené pokrytie AI dodávateľského reťazca vrátane základných modelov, embedding služieb, poskytovateľov kontextu a API tretích strán
- **Základná bezpečnosť**: Vylepšená integrácia s podnikovými bezpečnostnými vzormi vrátane architektúry nulovej dôvery a bezpečnostného ekosystému Microsoft
- **Organizácia zdrojov**: Kategorizované komplexné odkazy na zdroje podľa typu (Oficiálne dokumenty, Štandardy, Výskum, Microsoft riešenia, Implementačné príručky)

### Zlepšenia kvality dokumentácie
- **Štruktúrované učebné ciele**: Vylepšené učebné ciele s konkrétnymi, akčnými výsledkami 
- **Krížové odkazy**: Pridané odkazy medzi súvisiacimi témami bezpečnosti a základných konceptov
- **Aktuálne informácie**: Aktualizované všetky odkazy na dátumy a špecifikácie na aktuálne štandardy
- **Implementačné pokyny**: Pridané konkrétne, akčné pokyny na implementáciu v oboch sekciách

## 16. júl 2025

### Vylepšenia README a navigácie
- Kompletný redesign navigácie učebných osnov v README.md
- Nahradené `<details>` tagy prístupnejším formátom na báze tabuliek
- Vytvorené alternatívne možnosti rozloženia v novom priečinku "alternative_layouts"
- Pridané príklady navigácie na báze kariet, záložiek a akordeónov
- Aktualizovaná sekcia štruktúry repozitára na zahrnutie všetkých najnovších súborov
- Vylepšená sekcia "Ako používať tieto učebné osnovy" s jasnými odporúčaniami
- Aktualizované odkazy na špecifikáciu MCP na správne URL
- Pridaná sekcia Context Engineering (5.14) do štruktúry učebných osnov

### Aktualizácie študijného sprievodcu
- Kompletná revízia študijného sprievodcu na zosúladenie s aktuálnou štruktúrou repozitára
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
- Organizované všetky špecializované priečinky tém s konzistentným názvoslovím
- Pridané materiály a príklady na kontextové inžinierstvo
- Pridaná dokumentácia na integráciu Foundry agentov
- Vylepšená dokumentácia na integráciu bezpečnosti Entra ID

## 11. jún 2025

### Počiatočné vytvorenie
- Vydaná prvá verzia učebných osnov MCP pre začiatočníkov
- Vytvorená základná štruktúra pre všetkých 10 hlavných sekcií
- Implementovaná vizuálna mapa učebných osnov pre navigáciu
- Pridané počiatočné vzorové projekty v rôznych programovacích jazykoch

### Začíname (03-GettingStarted/)
- Vytvorené prvé príklady implementácie servera
- Pridané pokyny na vývoj klienta
- Zahrnuté pokyny na integráciu LLM klientov
- Pridaná dokumentácia na integráciu VS Code
- Implementované príklady serverov s udalosťami odosielanými serverom (SSE)

### Základné koncepty (01-CoreConcepts/)
- Pridané podrobné vysvetlenie architektúry klient-server
- Vytvorená dokumentácia o kľúčových komponentoch protokolu
- Dokumentované vzory správ v MCP

## 23. máj 2025

### Štruktúra repozitára
- Inicializovaný repozitár so základnou štruktúrou priečinkov
- Vytvorené README súbory pre každú hlavnú sekciu
- Nastavená infraštruktúra pre preklady
- Pridané obrazové zdroje a diagramy

### Dokumentácia
- Vytvorený počiatočný README.md s prehľadom učebných osnov
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

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nenesieme zodpovednosť za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.