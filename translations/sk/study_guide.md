<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "aa1ce97bc694b08faf3018bab6d275b9",
  "translation_date": "2025-09-30T21:39:11+00:00",
  "source_file": "study_guide.md",
  "language_code": "sk"
}
-->
# Protokol Model Context (MCP) pre začiatočníkov - Študijný sprievodca

Tento študijný sprievodca poskytuje prehľad štruktúry a obsahu repozitára pre učebné osnovy „Protokol Model Context (MCP) pre začiatočníkov“. Použite tento sprievodca na efektívnu navigáciu v repozitári a maximálne využitie dostupných zdrojov.

## Prehľad repozitára

Protokol Model Context (MCP) je štandardizovaný rámec pre interakcie medzi AI modelmi a klientskými aplikáciami. Pôvodne vytvorený spoločnosťou Anthropic, MCP je teraz spravovaný širšou komunitou MCP prostredníctvom oficiálnej organizácie na GitHube. Tento repozitár poskytuje komplexné učebné osnovy s praktickými príkladmi kódu v jazykoch C#, Java, JavaScript, Python a TypeScript, určené pre AI vývojárov, systémových architektov a softvérových inžinierov.

## Vizualizovaná mapa učebných osnov

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization Benefits)
      (Real-world Use Cases)
      (AI Integration Fundamentals)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
      (Transport Mechanisms)
    02. Security
      ::icon(fa fa-shield)
      (AI-Specific Threats)
      (Best Practices 2025)
      (Azure Content Safety)
      (Auth & Authorization)
      (Microsoft Prompt Shields)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server Implementation)
      (Client Development)
      (LLM Client Integration)
      (VS Code Extensions)
      (SSE Server Setup)
      (HTTP Streaming)
      (AI Toolkit Integration)
      (Testing Frameworks)
      (Deployment Strategies)
    04. Practical Implementation
      ::icon(fa fa-code)
      (Multi-Language SDKs)
      (Testing & Debugging)
      (Prompt Templates)
      (Sample Projects)
      (Production Patterns)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Agent Integration)
      (Multi-modal AI Workflows)
      (OAuth2 Authentication)
      (Real-time Search)
      (Streaming Protocols)
      (Root Contexts)
      (Routing Strategies)
      (Sampling Techniques)
      (Scaling Solutions)
      (Security Hardening)
      (Entra ID Integration)
      (Web Search MCP)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Client Ecosystem)
      (MCP Server Registry)
      (Image Generation Tools)
      (GitHub Collaboration)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Production Deployments)
      (Microsoft MCP Servers)
      (Azure MCP Service)
      (Enterprise Case Studies)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance Optimization)
      (Fault Tolerance)
      (System Resilience)
      (Monitoring & Observability)
    09. Case Studies
      ::icon(fa fa-file-text)
      (Azure API Management)
      (AI Travel Agent)
      (Azure DevOps Integration)
      (Documentation MCP)
      (GitHub MCP Registry)
      (VS Code Integration)
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
    11. Database Integration Labs
      ::icon(fa fa-database)
      (PostgreSQL Integration)
      (Retail Analytics Use Case)
      (Row Level Security)
      (Semantic Search)
      (Production Deployment)
      (13-Lab Structure)
      (Hands-on Learning)
```

## Štruktúra repozitára

Repozitár je organizovaný do jedenástich hlavných sekcií, z ktorých každá sa zameriava na rôzne aspekty MCP:

1. **Úvod (00-Introduction/)**
   - Prehľad protokolu Model Context
   - Prečo je štandardizácia dôležitá v AI procesoch
   - Praktické prípady použitia a výhody

2. **Základné koncepty (01-CoreConcepts/)**
   - Architektúra klient-server
   - Kľúčové komponenty protokolu
   - Vzory správ v MCP

3. **Bezpečnosť (02-Security/)**
   - Hrozby bezpečnosti v systémoch založených na MCP
   - Najlepšie postupy na zabezpečenie implementácií
   - Stratégie autentifikácie a autorizácie
   - **Komplexná dokumentácia bezpečnosti**:
     - MCP Najlepšie bezpečnostné postupy 2025
     - Implementačný sprievodca Azure Content Safety
     - MCP Bezpečnostné kontroly a techniky
     - MCP Rýchly referenčný sprievodca najlepšími postupmi
   - **Kľúčové témy bezpečnosti**:
     - Útoky na injekciu promptov a otravu nástrojov
     - Únos relácií a problémy zmätku zástupcov
     - Zraniteľnosti pri prechode tokenov
     - Nadmerné povolenia a kontrola prístupu
     - Bezpečnosť dodávateľského reťazca pre AI komponenty
     - Integrácia Microsoft Prompt Shields

4. **Začíname (03-GettingStarted/)**
   - Nastavenie a konfigurácia prostredia
   - Vytváranie základných MCP serverov a klientov
   - Integrácia s existujúcimi aplikáciami
   - Obsahuje sekcie:
     - Prvá implementácia servera
     - Vývoj klienta
     - Integrácia LLM klienta
     - Integrácia VS Code
     - Server-Sent Events (SSE) server
     - HTTP streaming
     - Integrácia AI Toolkit
     - Testovacie stratégie
     - Pokyny na nasadenie

5. **Praktická implementácia (04-PracticalImplementation/)**
   - Používanie SDK v rôznych programovacích jazykoch
   - Techniky ladenia, testovania a validácie
   - Tvorba opakovane použiteľných šablón promptov a pracovných postupov
   - Ukážkové projekty s implementačnými príkladmi

6. **Pokročilé témy (05-AdvancedTopics/)**
   - Techniky kontextového inžinierstva
   - Integrácia agentov Foundry
   - Multimodálne AI pracovné postupy
   - Demos autentifikácie OAuth2
   - Schopnosti vyhľadávania v reálnom čase
   - Streaming v reálnom čase
   - Implementácia root kontextov
   - Stratégie smerovania
   - Techniky vzorkovania
   - Prístupy k škálovaniu
   - Bezpečnostné úvahy
   - Integrácia bezpečnosti Entra ID
   - Integrácia webového vyhľadávania

7. **Príspevky komunity (06-CommunityContributions/)**
   - Ako prispievať kódom a dokumentáciou
   - Spolupráca cez GitHub
   - Vylepšenia a spätná väzba riadené komunitou
   - Používanie rôznych MCP klientov (Claude Desktop, Cline, VSCode)
   - Práca s populárnymi MCP servermi vrátane generovania obrázkov

8. **Poučenia z počiatočného prijatia (07-LessonsfromEarlyAdoption/)**
   - Implementácie v reálnom svete a úspešné príbehy
   - Budovanie a nasadzovanie riešení založených na MCP
   - Trendy a budúca cesta
   - **Sprievodca Microsoft MCP servermi**: Komplexný sprievodca 10 produkčne pripravenými Microsoft MCP servermi vrátane:
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (15+ špecializovaných konektorov)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **Najlepšie postupy (08-BestPractices/)**
   - Ladenie výkonu a optimalizácia
   - Navrhovanie systémov MCP odolných voči chybám
   - Testovacie a odolnostné stratégie

10. **Prípadové štúdie (09-CaseStudy/)**
    - **Sedem komplexných prípadových štúdií** demonštrujúcich všestrannosť MCP v rôznych scenároch:
    - **Azure AI Travel Agents**: Orchestrácia viacerých agentov s Azure OpenAI a AI Search
    - **Integrácia Azure DevOps**: Automatizácia pracovných procesov s aktualizáciami údajov z YouTube
    - **Vyhľadávanie dokumentácie v reálnom čase**: Python konzolový klient s HTTP streamingom
    - **Interaktívny generátor študijných plánov**: Chainlit webová aplikácia s konverzačnou AI
    - **Dokumentácia v editore**: Integrácia VS Code s pracovnými postupmi GitHub Copilot
    - **Správa API Azure**: Integrácia podnikových API s vytváraním MCP serverov
    - **GitHub MCP Registry**: Vývoj ekosystému a platforma pre agentickú integráciu
    - Implementačné príklady zahŕňajúce podnikové integrácie, produktivitu vývojárov a vývoj ekosystému

11. **Praktický workshop (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Komplexný praktický workshop kombinujúci MCP s AI Toolkit
    - Budovanie inteligentných aplikácií prepájajúcich AI modely s reálnymi nástrojmi
    - Praktické moduly pokrývajúce základy, vývoj vlastného servera a stratégie nasadenia do produkcie
    - **Štruktúra laboratórií**:
      - Lab 1: Základy MCP servera
      - Lab 2: Pokročilý vývoj MCP servera
      - Lab 3: Integrácia AI Toolkit
      - Lab 4: Nasadenie do produkcie a škálovanie
    - Učenie založené na laboratóriách s podrobnými pokynmi krok za krokom

12. **Laboratóriá integrácie MCP servera s databázou (11-MCPServerHandsOnLabs/)**
    - **Komplexná 13-laboratórna učebná cesta** na vytváranie produkčne pripravených MCP serverov s integráciou PostgreSQL
    - **Implementácia maloobchodnej analytiky v reálnom svete** pomocou prípadu použitia Zava Retail
    - **Vzory na podnikovej úrovni** vrátane Row Level Security (RLS), semantického vyhľadávania a prístupu k dátam pre viacerých nájomcov
    - **Kompletná štruktúra laboratórií**:
      - **Laboratóriá 00-03: Základy** - Úvod, Architektúra, Bezpečnosť, Nastavenie prostredia
      - **Laboratóriá 04-06: Budovanie MCP servera** - Návrh databázy, Implementácia MCP servera, Vývoj nástrojov
      - **Laboratóriá 07-09: Pokročilé funkcie** - Semantické vyhľadávanie, Testovanie a ladenie, Integrácia VS Code
      - **Laboratóriá 10-12: Produkcia a najlepšie postupy** - Nasadenie, Monitorovanie, Optimalizácia
    - **Pokryté technológie**: FastMCP framework, PostgreSQL, Azure OpenAI, Azure Container Apps, Application Insights
    - **Výsledky učenia**: Produkčne pripravené MCP servery, vzory integrácie databáz, AI-poháňaná analytika, podniková bezpečnosť

## Dodatočné zdroje

Repozitár obsahuje podporné zdroje:

- **Priečinok s obrázkami**: Obsahuje diagramy a ilustrácie použité v celých učebných osnovách
- **Preklady**: Podpora viacerých jazykov s automatizovanými prekladmi dokumentácie
- **Oficiálne MCP zdroje**:
  - [MCP Dokumentácia](https://modelcontextprotocol.io/)
  - [MCP Špecifikácia](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repozitár](https://github.com/modelcontextprotocol)

## Ako používať tento repozitár

1. **Sekvenčné učenie**: Sledujte kapitoly v poradí (00 až 11) pre štruktúrovaný zážitok z učenia.
2. **Zameranie na konkrétny jazyk**: Ak vás zaujíma konkrétny programovací jazyk, preskúmajte adresáre s ukážkami implementácií vo vašom preferovanom jazyku.
3. **Praktická implementácia**: Začnite sekciou „Začíname“, aby ste nastavili svoje prostredie a vytvorili svoj prvý MCP server a klienta.
4. **Pokročilé skúmanie**: Keď sa oboznámite so základmi, ponorte sa do pokročilých tém na rozšírenie svojich znalostí.
5. **Zapojenie komunity**: Pripojte sa ku komunite MCP prostredníctvom diskusií na GitHube a kanálov Discord, aby ste sa spojili s odborníkmi a ostatnými vývojármi.

## MCP Klienti a nástroje

Učebné osnovy pokrývajú rôznych MCP klientov a nástroje:

1. **Oficiálni klienti**:
   - Visual Studio Code 
   - MCP vo Visual Studio Code
   - Claude Desktop
   - Claude vo VSCode 
   - Claude API

2. **Komunitní klienti**:
   - Cline (založený na termináli)
   - Cursor (editor kódu)
   - ChatMCP
   - Windsurf

3. **Nástroje na správu MCP**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Populárne MCP servery

Repozitár predstavuje rôzne MCP servery, vrátane:

1. **Oficiálne Microsoft MCP servery**:
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (15+ špecializovaných konektorov)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **Oficiálne referenčné servery**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **Generovanie obrázkov**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **Vývojové nástroje**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **Špecializované servery**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Prispievanie

Tento repozitár víta príspevky od komunity. Pozrite si sekciu Príspevky komunity pre pokyny, ako efektívne prispievať do ekosystému MCP.

## Zmeny

| Dátum | Zmeny |
|------|---------||
| 29. september 2025 | - Pridaná sekcia 11-MCPServerHandsOnLabs s komplexnou 13-laboratórnou učebnou cestou integrácie databáz<br>- Aktualizovaná vizualizovaná mapa učebných osnov na zahrnutie laboratórií integrácie databáz<br>- Vylepšená štruktúra repozitára na odrážanie jedenástich hlavných sekcií<br>- Pridaný podrobný popis integrácie PostgreSQL, prípadu použitia maloobchodnej analytiky a podnikových vzorov<br>- Aktualizované pokyny na navigáciu na zahrnutie sekcií 00-11 |
| 26. september 2025 | - Pridaná prípadová štúdia GitHub MCP Registry do sekcie 09-CaseStudy<br>- Aktualizované prípadové štúdie na odrážanie siedmich komplexných prípadových štúdií<br>- Vylepšené popisy prípadových štúdií so špecifickými implementačnými detailmi<br>- Aktualizovaná vizualizovaná mapa učebných osnov na zahrnutie GitHub MCP Registry<br>- Revidovaná štruktúra študijného sprievodcu na odrážanie zamerania na vývoj ekosystému |
| 18. júl 2025 | - Aktualizovaná štruktúra repozitára na zahrnutie sprievodcu Microsoft MCP servermi<br>- Pridaný komplexný zoznam 10 produkčne pripravených Microsoft MCP serverov<br>- Vylepšená sekcia Populárne MCP servery s Oficiálnymi Microsoft MCP servermi<br>- Aktualizovaná sekcia Prípadové štúdie so skutočnými súborovými príkladmi<br>- Pridané detaily štruktúry laboratórií pre praktický workshop |
| 16. júl 2025 | - Aktualizovaná štruktúra repozitára na odrážanie aktuálneho obsahu<br>- Pridaná sekcia MCP Klienti a nástroje<br>- Pridaná sekcia Populárne MCP servery<br>- Aktualizovaná vizualizovaná mapa učebných osnov so všetkými aktuálnymi témami<br>- Vylepšená sekcia Pokročilé témy so všetkými špecializovanými oblasťami<br>- Aktualizované Prípadové štúdie na odrážanie skutočných príkladov<br>- Ujasnený pôvod MCP ako vytvorený spoločnosťou Anthropic |
| 11. jún 2025 | - Počiatočné vytvorenie študijného sprievodcu<br>- Pridaná vizualizovaná mapa učebných osnov<br>- Načrtnutá štruktúra repozitára<br>- Zahrnuté ukážkové projekty a dodatočné zdroje |

---

*Tento študijný sprievodca bol aktualizovaný 29. septembra 2025 a poskytuje prehľad repozitára k tomuto dátumu. Obsah repozitára môže byť aktualizovaný po tomto dátume.*

---

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nenesieme zodpovednosť za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.