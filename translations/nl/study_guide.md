<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "719117a0a5f34ade7b5dfb61ee06fb13",
  "translation_date": "2025-09-26T18:39:58+00:00",
  "source_file": "study_guide.md",
  "language_code": "nl"
}
-->
# Model Context Protocol (MCP) voor Beginners - Studiegids

Deze studiegids biedt een overzicht van de structuur en inhoud van de repository voor het curriculum "Model Context Protocol (MCP) voor Beginners". Gebruik deze gids om de repository efficiënt te navigeren en optimaal gebruik te maken van de beschikbare bronnen.

## Overzicht van de Repository

Het Model Context Protocol (MCP) is een gestandaardiseerd raamwerk voor interacties tussen AI-modellen en clienttoepassingen. Oorspronkelijk ontwikkeld door Anthropic, wordt MCP nu onderhouden door de bredere MCP-community via de officiële GitHub-organisatie. Deze repository biedt een uitgebreid curriculum met praktische codevoorbeelden in C#, Java, JavaScript, Python en TypeScript, ontworpen voor AI-ontwikkelaars, systeemarchitecten en software-engineers.

## Visuele Curriculumkaart

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
```

## Structuur van de Repository

De repository is georganiseerd in tien hoofdsecties, elk gericht op verschillende aspecten van MCP:

1. **Introductie (00-Introduction/)**
   - Overzicht van het Model Context Protocol
   - Waarom standaardisatie belangrijk is in AI-pijplijnen
   - Praktische toepassingen en voordelen

2. **Kernconcepten (01-CoreConcepts/)**
   - Client-serverarchitectuur
   - Belangrijke protocolcomponenten
   - Messagingpatronen in MCP

3. **Beveiliging (02-Security/)**
   - Beveiligingsrisico's in MCP-gebaseerde systemen
   - Best practices voor het beveiligen van implementaties
   - Authenticatie- en autorisatiestrategieën
   - **Uitgebreide Beveiligingsdocumentatie**:
     - MCP Security Best Practices 2025
     - Azure Content Safety Implementation Guide
     - MCP Security Controls and Techniques
     - MCP Best Practices Quick Reference
   - **Belangrijke Beveiligingsthema's**:
     - Prompt-injectie en toolvergiftigingsaanvallen
     - Sessiekaping en confused deputy-problemen
     - Token-passthrough kwetsbaarheden
     - Overmatige permissies en toegangscontrole
     - Leveringsketenbeveiliging voor AI-componenten
     - Microsoft Prompt Shields-integratie

4. **Aan de slag (03-GettingStarted/)**
   - Omgevingsinstelling en configuratie
   - Basis MCP-servers en -clients maken
   - Integratie met bestaande toepassingen
   - Inclusief secties voor:
     - Eerste serverimplementatie
     - Clientontwikkeling
     - LLM-clientintegratie
     - VS Code-integratie
     - Server-Sent Events (SSE) server
     - HTTP-streaming
     - AI Toolkit-integratie
     - Teststrategieën
     - Implementatierichtlijnen

5. **Praktische Implementatie (04-PracticalImplementation/)**
   - Gebruik van SDK's in verschillende programmeertalen
   - Debugging, testen en validatietechnieken
   - Herbruikbare prompttemplates en workflows maken
   - Voorbeeldprojecten met implementatievoorbeelden

6. **Geavanceerde Onderwerpen (05-AdvancedTopics/)**
   - Context-engineeringtechnieken
   - Foundry-agentintegratie
   - Multi-modale AI-workflows
   - OAuth2-authenticatiedemo's
   - Real-time zoekmogelijkheden
   - Real-time streaming
   - Root-contexten implementeren
   - Routeringsstrategieën
   - Samplingtechnieken
   - Schaalmethoden
   - Beveiligingsoverwegingen
   - Entra ID-beveiligingsintegratie
   - Webzoekintegratie

7. **Communitybijdragen (06-CommunityContributions/)**
   - Hoe code en documentatie bij te dragen
   - Samenwerken via GitHub
   - Community-gedreven verbeteringen en feedback
   - Gebruik van verschillende MCP-clients (Claude Desktop, Cline, VSCode)
   - Werken met populaire MCP-servers, inclusief beeldgeneratie

8. **Lessen uit Vroege Adoptie (07-LessonsfromEarlyAdoption/)**
   - Implementaties en succesverhalen uit de praktijk
   - MCP-gebaseerde oplossingen bouwen en implementeren
   - Trends en toekomstige roadmap
   - **Microsoft MCP Servers Guide**: Uitgebreide gids voor 10 productieklare Microsoft MCP-servers, waaronder:
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (15+ gespecialiseerde connectors)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **Best Practices (08-BestPractices/)**
   - Prestatieoptimalisatie
   - Ontwerpen van fouttolerante MCP-systemen
   - Test- en veerkrachtstrategieën

10. **Case Studies (09-CaseStudy/)**
    - **Zeven uitgebreide case studies** die de veelzijdigheid van MCP demonstreren in diverse scenario's:
    - **Azure AI Travel Agents**: Multi-agent orkestratie met Azure OpenAI en AI Search
    - **Azure DevOps Integratie**: Workflowprocessen automatiseren met YouTube-data-updates
    - **Real-Time Documentatieophaling**: Python-consoleclient met HTTP-streaming
    - **Interactieve Studieplan Generator**: Chainlit-webapp met conversatie-AI
    - **In-Editor Documentatie**: VS Code-integratie met GitHub Copilot-workflows
    - **Azure API Management**: Enterprise API-integratie met MCP-servercreatie
    - **GitHub MCP Registry**: Ecosysteemontwikkeling en agentische integratieplatform
    - Implementatievoorbeelden variërend van bedrijfsintegratie, ontwikkelaarsproductiviteit tot ecosysteemontwikkeling

11. **Hands-on Workshop (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Uitgebreide hands-on workshop die MCP combineert met AI Toolkit
    - Intelligente toepassingen bouwen die AI-modellen verbinden met echte tools
    - Praktische modules die de basis, aangepaste serverontwikkeling en productie-implementatiestrategieën behandelen
    - **Labstructuur**:
      - Lab 1: MCP Server Fundamentals
      - Lab 2: Advanced MCP Server Development
      - Lab 3: AI Toolkit Integration
      - Lab 4: Production Deployment and Scaling
    - Lab-gebaseerde leerbenadering met stapsgewijze instructies

## Aanvullende Bronnen

De repository bevat ondersteunende bronnen:

- **Afbeeldingenmap**: Bevat diagrammen en illustraties die door het hele curriculum worden gebruikt
- **Vertalingen**: Meertalige ondersteuning met geautomatiseerde vertalingen van documentatie
- **Officiële MCP-bronnen**:
  - [MCP Documentatie](https://modelcontextprotocol.io/)
  - [MCP Specificatie](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Hoe deze Repository te Gebruiken

1. **Sequentieel Leren**: Volg de hoofdstukken op volgorde (00 tot 10) voor een gestructureerde leerervaring.
2. **Taalgerichte Focus**: Als je geïnteresseerd bent in een specifieke programmeertaal, bekijk dan de voorbeeldmappen voor implementaties in jouw voorkeurstaal.
3. **Praktische Implementatie**: Begin met de sectie "Aan de slag" om je omgeving in te stellen en je eerste MCP-server en -client te maken.
4. **Geavanceerde Verkenning**: Zodra je vertrouwd bent met de basis, duik in de geavanceerde onderwerpen om je kennis uit te breiden.
5. **Communitybetrokkenheid**: Sluit je aan bij de MCP-community via GitHub-discussies en Discord-kanalen om in contact te komen met experts en medeontwikkelaars.

## MCP Clients en Tools

Het curriculum behandelt verschillende MCP-clients en tools:

1. **Officiële Clients**:
   - Visual Studio Code 
   - MCP in Visual Studio Code
   - Claude Desktop
   - Claude in VSCode 
   - Claude API

2. **Community Clients**:
   - Cline (terminal-gebaseerd)
   - Cursor (code-editor)
   - ChatMCP
   - Windsurf

3. **MCP Beheertools**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Populaire MCP Servers

De repository introduceert verschillende MCP-servers, waaronder:

1. **Officiële Microsoft MCP Servers**:
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (15+ gespecialiseerde connectors)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **Officiële Referentieservers**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **Beeldgeneratie**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **Ontwikkelingstools**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **Gespecialiseerde Servers**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Bijdragen

Deze repository verwelkomt bijdragen van de community. Zie de sectie Communitybijdragen voor richtlijnen over hoe je effectief kunt bijdragen aan het MCP-ecosysteem.

## Wijzigingslogboek

| Datum | Wijzigingen |
|------|-------------|
| 26 september 2025 | - GitHub MCP Registry case study toegevoegd aan sectie 09-CaseStudy<br>- Case Studies bijgewerkt met zeven uitgebreide case studies<br>- Case study beschrijvingen verbeterd met specifieke implementatiedetails<br>- Visuele Curriculumkaart bijgewerkt met GitHub MCP Registry<br>- Studiegidsstructuur herzien om ecosysteemontwikkelingsfocus te weerspiegelen |
| 18 juli 2025 | - Repositorystructuur bijgewerkt met Microsoft MCP Servers Guide<br>- Uitgebreide lijst toegevoegd van 10 productieklare Microsoft MCP-servers<br>- Populaire MCP Servers-sectie verbeterd met Officiële Microsoft MCP Servers<br>- Case Studies-sectie bijgewerkt met daadwerkelijke bestandsvoorbeelden<br>- Labstructuurdetails toegevoegd voor Hands-on Workshop |
| 16 juli 2025 | - Repositorystructuur bijgewerkt om huidige inhoud te weerspiegelen<br>- MCP Clients en Tools-sectie toegevoegd<br>- Populaire MCP Servers-sectie toegevoegd<br>- Visuele Curriculumkaart bijgewerkt met alle huidige onderwerpen<br>- Geavanceerde Onderwerpen-sectie verbeterd met alle gespecialiseerde gebieden<br>- Case Studies bijgewerkt met daadwerkelijke voorbeelden<br>- Oorsprong van MCP verduidelijkt als ontwikkeld door Anthropic |
| 11 juni 2025 | - Initiële creatie van de studiegids<br>- Visuele Curriculumkaart toegevoegd<br>- Repositorystructuur geschetst<br>- Voorbeeldprojecten en aanvullende bronnen opgenomen |

---

*Deze studiegids is bijgewerkt op 26 september 2025 en biedt een overzicht van de repository zoals die op die datum was. De inhoud van de repository kan na deze datum worden bijgewerkt.*

---

