<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T10:21:04+00:00",
  "source_file": "study_guide.md",
  "language_code": "sk"
}
-->
# Model Context Protocol (MCP) pre začiatočníkov – študijný sprievodca

Tento študijný sprievodca poskytuje prehľad štruktúry a obsahu repozitára pre kurz „Model Context Protocol (MCP) pre začiatočníkov“. Použite ho na efektívnu orientáciu v repozitári a maximálne využitie dostupných zdrojov.

## Prehľad repozitára

Model Context Protocol (MCP) je štandardizovaný rámec pre interakcie medzi AI modelmi a klientskymi aplikáciami. Pôvodne vytvorený spoločnosťou Anthropic, MCP je teraz spravovaný širšou komunitou MCP prostredníctvom oficiálnej GitHub organizácie. Tento repozitár ponúka komplexný kurz s praktickými ukážkami kódu v jazykoch C#, Java, JavaScript, Python a TypeScript, určený pre AI vývojárov, systémových architektov a softvérových inžinierov.

## Vizualizácia kurikula

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
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
```

## Štruktúra repozitára

Repozitár je rozdelený do desiatich hlavných sekcií, zameraných na rôzne aspekty MCP:

1. **Úvod (00-Introduction/)**
   - Prehľad Model Context Protocol
   - Prečo je štandardizácia dôležitá v AI pipeline
   - Praktické prípady použitia a výhody

2. **Základné koncepty (01-CoreConcepts/)**
   - Klient-server architektúra
   - Kľúčové komponenty protokolu
   - Vzory komunikácie v MCP

3. **Bezpečnosť (02-Security/)**
   - Hrozby bezpečnosti v systémoch založených na MCP
   - Najlepšie postupy zabezpečenia implementácií
   - Stratégie autentifikácie a autorizácie
   - **Komplexná dokumentácia bezpečnosti**:
     - MCP Security Best Practices 2025
     - Azure Content Safety Implementation Guide
     - MCP Security Controls and Techniques
     - MCP Best Practices Quick Reference
   - **Kľúčové bezpečnostné témy**:
     - Útoky typu prompt injection a tool poisoning
     - Únos relácie a problémy confused deputy
     - Zraniteľnosti token passthrough
     - Nadmerné oprávnenia a kontrola prístupu
     - Bezpečnosť dodávateľského reťazca pre AI komponenty
     - Integrácia Microsoft Prompt Shields

4. **Začíname (03-GettingStarted/)**
   - Nastavenie a konfigurácia prostredia
   - Vytvorenie základných MCP serverov a klientov
   - Integrácia do existujúcich aplikácií
   - Obsahuje sekcie pre:
     - Prvú implementáciu servera
     - Vývoj klienta
     - Integráciu LLM klienta
     - Integráciu vo VS Code
     - Server-Sent Events (SSE) server
     - HTTP streaming
     - Integráciu AI Toolkit
     - Testovacie stratégie
     - Pokyny pre nasadenie

5. **Praktická implementácia (04-PracticalImplementation/)**
   - Použitie SDK v rôznych programovacích jazykoch
   - Ladenie, testovanie a overovacie techniky
   - Tvorba znovupoužiteľných šablón promptov a pracovných tokov
   - Ukážkové projekty s príkladmi implementácie

6. **Pokročilé témy (05-AdvancedTopics/)**
   - Techniky kontextového inžinierstva
   - Integrácia Foundry agenta
   - Multimodálne AI pracovné toky
   - Ukážky autentifikácie OAuth2
   - Reálne vyhľadávanie v reálnom čase
   - Streaming v reálnom čase
   - Implementácia root kontextov
   - Routingové stratégie
   - Techniky vzorkovania
   - Prístupy k škálovaniu
   - Bezpečnostné úvahy
   - Integrácia bezpečnosti Entra ID
   - Integrácia webového vyhľadávania

7. **Príspevky komunity (06-CommunityContributions/)**
   - Ako prispievať kódom a dokumentáciou
   - Spolupráca cez GitHub
   - Vylepšenia a spätná väzba od komunity
   - Používanie rôznych MCP klientov (Claude Desktop, Cline, VSCode)
   - Práca s populárnymi MCP servermi vrátane generovania obrázkov

8. **Lekcie z raného nasadenia (07-LessonsfromEarlyAdoption/)**
   - Reálne implementácie a úspešné príbehy
   - Budovanie a nasadzovanie riešení založených na MCP
   - Trendy a budúca cesta vývoja
   - **Sprievodca Microsoft MCP servermi**: Komplexný prehľad 10 produkčne pripravených Microsoft MCP serverov vrátane:
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
   - Návrh MCP systémov odolných voči chybám
   - Testovanie a stratégie odolnosti

10. **Prípadové štúdie (09-CaseStudy/)**
    - Ukážka integrácie Azure API Management
    - Ukážka implementácie cestovnej agentúry
    - Integrácia Azure DevOps s aktualizáciami YouTube
    - Príklady implementácie MCP dokumentácie
    - Implementačné príklady s podrobnou dokumentáciou

11. **Praktický workshop (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Komplexný praktický workshop kombinujúci MCP s AI Toolkit
    - Budovanie inteligentných aplikácií prepájajúcich AI modely s reálnymi nástrojmi
    - Praktické moduly pokrývajúce základy, vývoj vlastného servera a stratégie produkčného nasadenia
    - **Štruktúra laboratória**:
      - Laboratórium 1: Základy MCP servera
      - Laboratórium 2: Pokročilý vývoj MCP servera
      - Laboratórium 3: Integrácia AI Toolkit
      - Laboratórium 4: Produkčné nasadenie a škálovanie
    - Výučba založená na laboratórnych cvičeniach s podrobnými inštrukciami

## Dodatočné zdroje

Repozitár obsahuje podporné zdroje:

- **Zložka obrázkov**: Obsahuje diagramy a ilustrácie použité v celom kurze
- **Preklady**: Podpora viacerých jazykov s automatizovanými prekladmi dokumentácie
- **Oficiálne MCP zdroje**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Ako používať tento repozitár

1. **Sekvenčné učenie**: Prejdite kapitoly v poradí (00 až 10) pre systematické štúdium.
2. **Zameranie na konkrétny jazyk**: Ak vás zaujíma konkrétny programovací jazyk, preskúmajte priečinky so vzorkami pre implementácie vo vašom preferovanom jazyku.
3. **Praktická implementácia**: Začnite sekciou „Začíname“ na nastavenie prostredia a vytvorenie prvého MCP servera a klienta.
4. **Pokročilý prieskum**: Keď zvládnete základy, ponorte sa do pokročilých tém na rozšírenie vedomostí.
5. **Zapojenie komunity**: Pridajte sa ku komunite MCP cez GitHub diskusie a Discord kanály, aby ste sa spojili s odborníkmi a ďalšími vývojármi.

## MCP klienti a nástroje

Kurz pokrýva rôznych MCP klientov a nástroje:

1. **Oficiálni klienti**:
   - Visual Studio Code
   - MCP vo Visual Studio Code
   - Claude Desktop
   - Claude vo VSCode
   - Claude API

2. **Klienti komunity**:
   - Cline (terminálový)
   - Cursor (editor kódu)
   - ChatMCP
   - Windsurf

3. **Nástroje na správu MCP**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Populárne MCP servery

Repozitár predstavuje rôzne MCP servery vrátane:

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

## Príspevky

Tento repozitár vítá príspevky od komunity. Pozrite sekciu Príspevky komunity pre návod, ako efektívne prispievať do ekosystému MCP.

## Zoznam zmien

| Dátum | Zmeny |
|-------|--------|
| 18. júl 2025 | - Aktualizovaná štruktúra repozitára vrátane Sprievodcu Microsoft MCP servermi<br>- Pridaný komplexný zoznam 10 produkčne pripravených Microsoft MCP serverov<br>- Vylepšená sekcia Populárne MCP servery s oficiálnymi Microsoft MCP servermi<br>- Aktualizovaná sekcia Prípadové štúdie s reálnymi príkladmi súborov<br>- Pridané detaily štruktúry laboratória pre praktický workshop |
| 16. júl 2025 | - Aktualizovaná štruktúra repozitára podľa aktuálneho obsahu<br>- Pridaná sekcia MCP klienti a nástroje<br>- Pridaná sekcia Populárne MCP servery<br>- Aktualizovaná vizualizácia kurikula so všetkými aktuálnymi témami<br>- Vylepšená sekcia Pokročilé témy so všetkými špecializovanými oblasťami<br>- Aktualizované Prípadové štúdie s reálnymi príkladmi<br>- Uvedenie MCP ako projektu vytvoreného Anthropic |
| 11. jún 2025 | - Prvé vytvorenie študijného sprievodcu<br>- Pridaná vizualizácia kurikula<br>- Načrtnutá štruktúra repozitára<br>- Zahrnuté ukážkové projekty a dodatočné zdroje |

---

*Tento študijný sprievodca bol aktualizovaný 18. júla 2025 a poskytuje prehľad repozitára k tomuto dátumu. Obsah repozitára môže byť po tomto dátume aktualizovaný.*

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.