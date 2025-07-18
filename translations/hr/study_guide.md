<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T10:30:28+00:00",
  "source_file": "study_guide.md",
  "language_code": "hr"
}
-->
# Model Context Protocol (MCP) za početnike - vodič za učenje

Ovaj vodič za učenje pruža pregled strukture i sadržaja repozitorija za kurikulum "Model Context Protocol (MCP) za početnike". Koristite ovaj vodič za učinkovito snalaženje u repozitoriju i maksimalno iskorištavanje dostupnih resursa.

## Pregled repozitorija

Model Context Protocol (MCP) je standardizirani okvir za interakcije između AI modela i klijentskih aplikacija. Izvorno ga je stvorio Anthropic, a sada ga održava šira MCP zajednica putem službene GitHub organizacije. Ovaj repozitorij nudi sveobuhvatan kurikulum s praktičnim primjerima koda u C#, Javi, JavaScriptu, Pythonu i TypeScriptu, namijenjen AI developerima, sistemskim arhitektima i softverskim inženjerima.

## Vizualna karta kurikuluma

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

## Struktura repozitorija

Repozitorij je organiziran u deset glavnih sekcija, od kojih se svaka fokusira na različite aspekte MCP-a:

1. **Uvod (00-Introduction/)**
   - Pregled Model Context Protocola
   - Zašto je standardizacija važna u AI procesima
   - Praktične primjene i prednosti

2. **Osnovni pojmovi (01-CoreConcepts/)**
   - Klijent-server arhitektura
   - Ključne komponente protokola
   - Obrasci poruka u MCP-u

3. **Sigurnost (02-Security/)**
   - Sigurnosne prijetnje u sustavima temeljenim na MCP-u
   - Najbolje prakse za osiguranje implementacija
   - Strategije autentikacije i autorizacije
   - **Sveobuhvatna sigurnosna dokumentacija**:
     - MCP sigurnosne najbolje prakse 2025
     - Vodič za implementaciju Azure Content Safety
     - MCP sigurnosne kontrole i tehnike
     - Brzi pregled MCP najboljih praksi
   - **Ključne sigurnosne teme**:
     - Napadi ubrizgavanja prompta i trovanje alata
     - Preuzimanje sesije i problemi "confused deputy"
     - Ranljivosti pri prosljeđivanju tokena
     - Pretjerane dozvole i kontrola pristupa
     - Sigurnost lanca opskrbe za AI komponente
     - Integracija Microsoft Prompt Shields

4. **Početak rada (03-GettingStarted/)**
   - Postavljanje i konfiguracija okruženja
   - Kreiranje osnovnih MCP servera i klijenata
   - Integracija s postojećim aplikacijama
   - Uključuje sekcije za:
     - Prvu implementaciju servera
     - Razvoj klijenta
     - Integraciju LLM klijenta
     - Integraciju u VS Code
     - Server-Sent Events (SSE) server
     - HTTP streaming
     - Integraciju AI Toolkit-a
     - Strategije testiranja
     - Smjernice za implementaciju

5. **Praktična implementacija (04-PracticalImplementation/)**
   - Korištenje SDK-ova u različitim programskim jezicima
   - Tehnike otklanjanja pogrešaka, testiranja i validacije
   - Izrada ponovljivih predložaka prompta i tijekova rada
   - Primjeri projekata s implementacijama

6. **Napredne teme (05-AdvancedTopics/)**
   - Tehnike inženjeringa konteksta
   - Integracija Foundry agenta
   - Višestruki modaliteti AI tijekova rada
   - Demonstracije OAuth2 autentikacije
   - Mogućnosti pretraživanja u stvarnom vremenu
   - Streaming u stvarnom vremenu
   - Implementacija root konteksta
   - Strategije usmjeravanja
   - Tehnike uzorkovanja
   - Pristupi skaliranju
   - Sigurnosni aspekti
   - Integracija Entra ID sigurnosti
   - Integracija web pretraživanja

7. **Doprinosi zajednice (06-CommunityContributions/)**
   - Kako doprinijeti kodom i dokumentacijom
   - Suradnja putem GitHuba
   - Poboljšanja i povratne informacije vođene zajednicom
   - Korištenje različitih MCP klijenata (Claude Desktop, Cline, VSCode)
   - Rad s popularnim MCP serverima uključujući generiranje slika

8. **Lekcije iz ranog usvajanja (07-LessonsfromEarlyAdoption/)**
   - Implementacije iz stvarnog svijeta i uspješne priče
   - Izgradnja i implementacija rješenja temeljenih na MCP-u
   - Trendovi i budući planovi
   - **Vodič za Microsoft MCP servere**: Sveobuhvatan vodič za 10 proizvodno spremnih Microsoft MCP servera uključujući:
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (15+ specijaliziranih konektora)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **Najbolje prakse (08-BestPractices/)**
   - Podešavanje performansi i optimizacija
   - Dizajniranje otpornog MCP sustava
   - Strategije testiranja i otpornosti

10. **Studije slučaja (09-CaseStudy/)**
    - Primjer integracije Azure API Managementa
    - Primjer implementacije turističkog agenta
    - Integracija Azure DevOps-a s YouTube ažuriranjima
    - Primjeri implementacije MCP dokumentacije
    - Primjeri implementacije s detaljnom dokumentacijom

11. **Praktična radionica (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Sveobuhvatna praktična radionica koja kombinira MCP s AI Toolkit-om
    - Izgradnja inteligentnih aplikacija koje povezuju AI modele s alatima iz stvarnog svijeta
    - Praktični moduli koji pokrivaju osnove, razvoj prilagođenih servera i strategije produkcijske implementacije
    - **Struktura laboratorija**:
      - Laboratorij 1: Osnove MCP servera
      - Laboratorij 2: Napredni razvoj MCP servera
      - Laboratorij 3: Integracija AI Toolkit-a
      - Laboratorij 4: Produkcijska implementacija i skaliranje
    - Pristup učenju temeljen na laboratorijima s uputama korak po korak

## Dodatni resursi

Repozitorij uključuje prateće resurse:

- **Mapa Images**: Sadrži dijagrame i ilustracije korištene kroz kurikulum
- **Prijevodi**: Podrška za više jezika s automatskim prijevodima dokumentacije
- **Službeni MCP resursi**:
  - [MCP Dokumentacija](https://modelcontextprotocol.io/)
  - [MCP Specifikacija](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repozitorij](https://github.com/modelcontextprotocol)

## Kako koristiti ovaj repozitorij

1. **Sekvencijalno učenje**: Slijedite poglavlja redom (od 00 do 10) za strukturirano učenje.
2. **Fokus na određeni jezik**: Ako vas zanima određeni programski jezik, istražite direktorije s primjerima za implementacije na željenom jeziku.
3. **Praktična implementacija**: Počnite s odjeljkom "Početak rada" za postavljanje okruženja i kreiranje prvog MCP servera i klijenta.
4. **Napredno istraživanje**: Kad savladate osnove, zaronite u napredne teme za proširenje znanja.
5. **Angažman u zajednici**: Pridružite se MCP zajednici putem GitHub diskusija i Discord kanala za povezivanje s ekspertima i kolegama developerima.

## MCP klijenti i alati

Kurikulum pokriva različite MCP klijente i alate:

1. **Službeni klijenti**:
   - Visual Studio Code
   - MCP u Visual Studio Code-u
   - Claude Desktop
   - Claude u VSCode-u
   - Claude API

2. **Klijenti zajednice**:
   - Cline (terminalski)
   - Cursor (uređivač koda)
   - ChatMCP
   - Windsurf

3. **Alati za upravljanje MCP-om**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Popularni MCP serveri

Repozitorij predstavlja različite MCP servere, uključujući:

1. **Službeni Microsoft MCP serveri**:
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (15+ specijaliziranih konektora)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **Službeni referentni serveri**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **Generiranje slika**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **Alati za razvoj**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **Specijalizirani serveri**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Doprinosi

Ovaj repozitorij pozdravlja doprinose iz zajednice. Pogledajte odjeljak Doprinosi zajednice za upute kako učinkovito doprinositi MCP ekosustavu.

## Dnevnik promjena

| Datum | Promjene |
|-------|----------|
| 18. srpnja 2025. | - Ažurirana struktura repozitorija s vodičem za Microsoft MCP servere<br>- Dodan sveobuhvatan popis 10 proizvodno spremnih Microsoft MCP servera<br>- Proširen odjeljak Popularni MCP serveri sa službenim Microsoft MCP serverima<br>- Ažuriran odjeljak Studije slučaja s stvarnim primjerima datoteka<br>- Dodani detalji o strukturi laboratorija za praktičnu radionicu |
| 16. srpnja 2025. | - Ažurirana struktura repozitorija u skladu s trenutnim sadržajem<br>- Dodan odjeljak MCP klijenti i alati<br>- Dodan odjeljak Popularni MCP serveri<br>- Ažurirana vizualna karta kurikuluma sa svim aktualnim temama<br>- Proširen odjeljak Napredne teme sa svim specijaliziranim područjima<br>- Ažurirane Studije slučaja s stvarnim primjerima<br>- Pojašnjen MCP kao protokol koji je stvorio Anthropic |
| 11. lipnja 2025. | - Izrada početnog vodiča za učenje<br>- Dodana vizualna karta kurikuluma<br>- Nacrtana struktura repozitorija<br>- Uključeni primjeri projekata i dodatni resursi |

---

*Ovaj vodič za učenje ažuriran je 18. srpnja 2025. i pruža pregled repozitorija na taj datum. Sadržaj repozitorija može biti ažuriran i nakon tog datuma.*

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.