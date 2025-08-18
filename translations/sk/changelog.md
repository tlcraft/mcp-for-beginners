<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T15:17:59+00:00",
  "source_file": "changelog.md",
  "language_code": "sk"
}
-->
# Zmeny: Učebný plán MCP pre začiatočníkov

Tento dokument slúži ako záznam všetkých významných zmien vykonaných v učebnom pláne Model Context Protocol (MCP) pre začiatočníkov. Zmeny sú zaznamenané v obrátenom chronologickom poradí (najnovšie zmeny sú uvedené ako prvé).

## 18. august 2025

### Komplexná aktualizácia dokumentácie - Štandardy MCP 2025-06-18

#### MCP Bezpečnostné najlepšie postupy (02-Security/) - Kompletná modernizácia
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kompletné prepracovanie v súlade so špecifikáciou MCP 2025-06-18
  - **Povinné požiadavky**: Pridané explicitné požiadavky MUST/MUST NOT zo špecifikácie s jasnými vizuálnymi indikátormi
  - **12 základných bezpečnostných praktík**: Preštruktúrované z 15-bodového zoznamu na komplexné bezpečnostné domény
    - Bezpečnosť tokenov a autentifikácia s integráciou externého poskytovateľa identity
    - Správa relácií a bezpečnosť prenosu s kryptografickými požiadavkami
    - Ochrana pred AI-špecifickými hrozbami s integráciou Microsoft Prompt Shields
    - Riadenie prístupu a oprávnení s princípom minimálnych oprávnení
    - Bezpečnosť obsahu a monitorovanie s integráciou Azure Content Safety
    - Bezpečnosť dodávateľského reťazca s overovaním komponentov
    - Bezpečnosť OAuth a prevencia Confused Deputy útokov s implementáciou PKCE
    - Reakcia na incidenty a obnova s automatizovanými schopnosťami
    - Súlad a riadenie s regulačnými požiadavkami
    - Pokročilé bezpečnostné kontroly s architektúrou nulovej dôvery
    - Integrácia s Microsoft Security Ecosystem s komplexnými riešeniami
    - Neustály vývoj bezpečnosti s adaptívnymi praktikami
  - **Microsoft bezpečnostné riešenia**: Vylepšené pokyny na integráciu pre Prompt Shields, Azure Content Safety, Entra ID a GitHub Advanced Security
  - **Implementačné zdroje**: Kategorizované odkazy na zdroje podľa oficiálnej dokumentácie MCP, Microsoft bezpečnostných riešení, bezpečnostných štandardov a implementačných príručiek

#### Pokročilé bezpečnostné kontroly (02-Security/) - Implementácia pre podniky
- **MCP-SECURITY-CONTROLS-2025.md**: Kompletné prepracovanie s bezpečnostným rámcom na úrovni podnikov
  - **9 komplexných bezpečnostných domén**: Rozšírené z jednoduchých kontrol na podrobný podnikový rámec
    - Pokročilá autentifikácia a autorizácia s integráciou Microsoft Entra ID
    - Bezpečnosť tokenov a ochrana proti preposielaniu s komplexným overovaním
    - Bezpečnostné kontroly relácií s prevenciou únosov
    - AI-špecifické bezpečnostné kontroly s prevenciou injekcií a otravy nástrojov
    - Prevencia Confused Deputy útokov s bezpečnosťou OAuth proxy
    - Bezpečnosť vykonávania nástrojov s izoláciou a sandboxingom
    - Kontroly bezpečnosti dodávateľského reťazca s overovaním závislostí
    - Monitorovanie a detekcia s integráciou SIEM
    - Reakcia na incidenty a obnova s automatizovanými schopnosťami
  - **Príklady implementácie**: Pridané podrobné YAML konfiguračné bloky a ukážky kódu
  - **Integrácia Microsoft riešení**: Komplexné pokrytie Azure bezpečnostných služieb, GitHub Advanced Security a podnikovej správy identity

#### Pokročilé bezpečnostné témy (05-AdvancedTopics/mcp-security/) - Implementácia pripravená na produkciu
- **README.md**: Kompletné prepracovanie pre podnikové bezpečnostné implementácie
  - **Zarovnanie so súčasnou špecifikáciou**: Aktualizované na špecifikáciu MCP 2025-06-18 s povinnými bezpečnostnými požiadavkami
  - **Vylepšená autentifikácia**: Integrácia Microsoft Entra ID s podrobnými príkladmi pre .NET a Java Spring Security
  - **Integrácia AI bezpečnosti**: Implementácia Microsoft Prompt Shields a Azure Content Safety s podrobnými príkladmi v Pythone
  - **Pokročilé zmierňovanie hrozieb**: Komplexné implementačné príklady pre
    - Prevenciu Confused Deputy útokov s PKCE a overovaním súhlasu používateľa
    - Prevenciu preposielania tokenov s overovaním publika a bezpečnou správou tokenov
    - Prevenciu únosov relácií s kryptografickým viazaním a analýzou správania
  - **Integrácia podnikovej bezpečnosti**: Monitorovanie Azure Application Insights, detekčné pipeline a bezpečnosť dodávateľského reťazca
  - **Kontrolný zoznam implementácie**: Jasné rozlíšenie medzi povinnými a odporúčanými bezpečnostnými kontrolami s výhodami Microsoft bezpečnostného ekosystému

### Kvalita dokumentácie a zarovnanie so štandardmi
- **Referencie na špecifikácie**: Aktualizované všetky odkazy na aktuálnu špecifikáciu MCP 2025-06-18
- **Microsoft bezpečnostný ekosystém**: Vylepšené pokyny na integráciu v celej bezpečnostnej dokumentácii
- **Praktická implementácia**: Pridané podrobné ukážky kódu v .NET, Java a Python s podnikateľskými vzormi
- **Organizácia zdrojov**: Komplexná kategorizácia oficiálnej dokumentácie, bezpečnostných štandardov a implementačných príručiek
- **Vizuálne indikátory**: Jasné označenie povinných požiadaviek oproti odporúčaným praktikám

#### Základné koncepty (01-CoreConcepts/) - Kompletná modernizácia
- **Aktualizácia verzie protokolu**: Aktualizované na aktuálnu špecifikáciu MCP 2025-06-18 s dátumovým verzovaním (formát YYYY-MM-DD)
- **Vylepšenie architektúry**: Vylepšené popisy hostiteľov, klientov a serverov na základe aktuálnych vzorov architektúry MCP
  - Hostitelia teraz jasne definovaní ako AI aplikácie koordinujúce viacero pripojení MCP klientov
  - Klienti popísaní ako konektory protokolu udržiavajúce vzťahy jeden na jedného so servermi
  - Servery vylepšené o lokálne a vzdialené scenáre nasadenia
- **Prepracovanie primitív**: Kompletné prepracovanie primitív servera a klienta
  - Serverové primitívy: Zdroje (databázy), Šablóny (prompty), Nástroje (vykonateľné funkcie) s podrobnými vysvetleniami a príkladmi
  - Klientské primitívy: Sampling (LLM doplnenia), Elicitation (vstupy používateľa), Logging (ladenie/monitorovanie)
  - Aktualizované s aktuálnymi vzormi metód objavovania (`*/list`), získavania (`*/get`) a vykonávania (`*/call`)
- **Architektúra protokolu**: Zavedený dvojvrstvový model architektúry
  - Dátová vrstva: Základ JSON-RPC 2.0 s riadením životného cyklu a primitívmi
  - Transportná vrstva: STDIO (lokálne) a Streamable HTTP so SSE (vzdialené) mechanizmami prenosu
- **Bezpečnostný rámec**: Komplexné bezpečnostné princípy vrátane explicitného súhlasu používateľa, ochrany súkromia dát, bezpečnosti vykonávania nástrojov a bezpečnosti transportnej vrstvy
- **Komunikačné vzory**: Aktualizované správy protokolu na zobrazenie tokov inicializácie, objavovania, vykonávania a notifikácií
- **Ukážky kódu**: Obnovené viacjazyčné príklady (.NET, Java, Python, JavaScript) na základe aktuálnych vzorov MCP SDK

#### Bezpečnosť (02-Security/) - Komplexné prepracovanie bezpečnosti  
- **Zarovnanie so štandardmi**: Plné zarovnanie s bezpečnostnými požiadavkami špecifikácie MCP 2025-06-18
- **Evolúcia autentifikácie**: Zdokumentovaná evolúcia od vlastných OAuth serverov k delegácii externého poskytovateľa identity (Microsoft Entra ID)
- **AI-špecifická analýza hrozieb**: Rozšírené pokrytie moderných AI útokov
  - Podrobné scenáre útokov injekciou promptov s reálnymi príkladmi
  - Mechanizmy otravy nástrojov a vzory útokov „rug pull“
  - Otrava kontextového okna a útoky na zmätok modelu
- **Microsoft AI bezpečnostné riešenia**: Komplexné pokrytie Microsoft bezpečnostného ekosystému
  - AI Prompt Shields s pokročilou detekciou, zvýrazňovaním a technikami delimitácie
  - Vzory integrácie Azure Content Safety
  - GitHub Advanced Security na ochranu dodávateľského reťazca
- **Pokročilé zmierňovanie hrozieb**: Podrobné bezpečnostné kontroly pre
  - Únosy relácií s MCP-špecifickými scenármi útokov a kryptografickými požiadavkami na ID relácií
  - Problémy Confused Deputy v MCP proxy scenároch s explicitnými požiadavkami na súhlas
  - Zraniteľnosti preposielania tokenov s povinnými kontrolami overovania
- **Bezpečnosť dodávateľského reťazca**: Rozšírené pokrytie AI dodávateľského reťazca vrátane základných modelov, embeddingových služieb, poskytovateľov kontextu a API tretích strán
- **Základná bezpečnosť**: Vylepšená integrácia s podnikateľskými bezpečnostnými vzormi vrátane architektúry nulovej dôvery a Microsoft bezpečnostného ekosystému
- **Organizácia zdrojov**: Kategorizované komplexné odkazy na zdroje podľa typu (Oficiálna dokumentácia, Štandardy, Výskum, Microsoft riešenia, Implementačné príručky)

### Vylepšenia kvality dokumentácie
- **Štruktúrované vzdelávacie ciele**: Vylepšené vzdelávacie ciele s konkrétnymi, akčnými výsledkami 
- **Krížové odkazy**: Pridané odkazy medzi súvisiacimi bezpečnostnými a základnými konceptmi
- **Aktuálne informácie**: Aktualizované všetky dátumy a odkazy na špecifikácie na aktuálne štandardy
- **Implementačné pokyny**: Pridané konkrétne, akčné implementačné pokyny v celom rozsahu oboch sekcií

## 16. júl 2025

### Vylepšenia README a navigácie
- Kompletné prepracovanie navigácie učebného plánu v README.md
- Nahradenie `<details>` značiek prístupnejším formátom tabuľky
- Vytvorenie alternatívnych možností rozloženia v novej zložke "alternative_layouts"
- Pridané príklady navigácie na báze kariet, záložiek a akordeónov
- Aktualizovaná sekcia štruktúry úložiska na zahrnutie všetkých najnovších súborov
- Vylepšená sekcia "Ako používať tento učebný plán" s jasnými odporúčaniami
- Aktualizované odkazy na špecifikáciu MCP na správne URL
- Pridaná sekcia Kontextové inžinierstvo (5.14) do štruktúry učebného plánu

### Aktualizácie študijného sprievodcu
- Kompletná revízia študijného sprievodcu na zarovnanie s aktuálnou štruktúrou úložiska
- Pridané nové sekcie pre MCP klientov a nástroje a populárne MCP servery
- Aktualizovaná vizuálna mapa učebného plánu na presné zobrazenie všetkých tém
- Vylepšené popisy pokročilých tém na pokrytie všetkých špecializovaných oblastí
- Aktualizovaná sekcia prípadových štúdií na odrážanie skutočných príkladov
- Pridaný tento komplexný záznam zmien

### Príspevky komunity (06-CommunityContributions/)
- Pridané podrobné informácie o MCP serveroch na generovanie obrázkov
- Pridaná komplexná sekcia o používaní Claude vo VSCode
- Pridané pokyny na nastavenie a používanie terminálového klienta Cline
- Aktualizovaná sekcia MCP klientov na zahrnutie všetkých populárnych možností klientov
- Vylepšené príklady príspevkov s presnejšími ukážkami kódu

### Pokročilé témy (05-AdvancedTopics/)
- Organizované všetky špecializované zložky tém s konzistentným pomenovaním
- Pridané materiály a príklady kontextového inžinierstva
- Pridaná dokumentácia integrácie Foundry agentov
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
- Zahrnuté pokyny na integráciu LLM klientov
- Pridaná dokumentácia integrácie VS Code
- Implementované príklady serverov s udalosťami odosielanými serverom (SSE)

### Základné koncepty (01-CoreConcepts/)
- Pridané podrobné vysvetlenie architektúry klient-server
- Vytvorená dokumentácia kľúčových komponentov protokolu
- Zdokumentované vzory správ v MCP

## 23. máj 2025

### Štruktúra úložiska
- Inicializované úložisko so základnou štruktúrou zložiek
- Vytvorené README súbory pre každú hlavnú sekciu
- Nastavená infraštruktúra prekladu
- Pridané obrazové zdroje a diagramy

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

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nenesieme zodpovednosť za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.