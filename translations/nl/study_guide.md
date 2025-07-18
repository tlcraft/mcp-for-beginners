<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T10:04:37+00:00",
  "source_file": "study_guide.md",
  "language_code": "nl"
}
-->
# Model Context Protocol (MCP) voor Beginners - Studiegids

Deze studiegids geeft een overzicht van de structuur en inhoud van de repository voor de cursus "Model Context Protocol (MCP) voor Beginners". Gebruik deze gids om efficiënt door de repository te navigeren en optimaal gebruik te maken van de beschikbare bronnen.

## Overzicht van de Repository

Het Model Context Protocol (MCP) is een gestandaardiseerd raamwerk voor interacties tussen AI-modellen en clientapplicaties. Oorspronkelijk ontwikkeld door Anthropic, wordt MCP nu onderhouden door de bredere MCP-gemeenschap via de officiële GitHub-organisatie. Deze repository biedt een uitgebreide cursus met praktische codevoorbeelden in C#, Java, JavaScript, Python en TypeScript, bedoeld voor AI-ontwikkelaars, systeemarchitecten en software-engineers.

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

De repository is ingedeeld in tien hoofdsecties, elk gericht op verschillende aspecten van MCP:

1. **Introductie (00-Introduction/)**
   - Overzicht van het Model Context Protocol
   - Waarom standaardisatie belangrijk is in AI-pijplijnen
   - Praktische toepassingen en voordelen

2. **Kernconcepten (01-CoreConcepts/)**
   - Client-serverarchitectuur
   - Belangrijke protocolcomponenten
   - Messagingpatronen in MCP

3. **Beveiliging (02-Security/)**
   - Beveiligingsrisico’s in MCP-gebaseerde systemen
   - Best practices voor veilige implementaties
   - Authenticatie- en autorisatiestrategieën
   - **Uitgebreide beveiligingsdocumentatie**:
     - MCP Security Best Practices 2025
     - Azure Content Safety Implementatiehandleiding
     - MCP Security Controls en Technieken
     - MCP Best Practices Quick Reference
   - **Belangrijke beveiligingsthema’s**:
     - Prompt injection en tool poisoning aanvallen
     - Session hijacking en confused deputy problemen
     - Token passthrough kwetsbaarheden
     - Overmatige permissies en toegangscontrole
     - Supply chain beveiliging voor AI-componenten
     - Integratie van Microsoft Prompt Shields

4. **Aan de Slag (03-GettingStarted/)**
   - Omgevingsopzet en configuratie
   - Basis MCP-servers en clients maken
   - Integratie met bestaande applicaties
   - Bevat secties voor:
     - Eerste serverimplementatie
     - Clientontwikkeling
     - LLM-clientintegratie
     - VS Code-integratie
     - Server-Sent Events (SSE) server
     - HTTP-streaming
     - AI Toolkit-integratie
     - Teststrategieën
     - Deployment-richtlijnen

5. **Praktische Implementatie (04-PracticalImplementation/)**
   - Gebruik van SDK’s in verschillende programmeertalen
   - Debuggen, testen en validatietechnieken
   - Maken van herbruikbare prompttemplates en workflows
   - Voorbeeldprojecten met implementatievoorbeelden

6. **Geavanceerde Onderwerpen (05-AdvancedTopics/)**
   - Context engineering technieken
   - Foundry agent integratie
   - Multi-modale AI-workflows
   - OAuth2 authenticatie-demo’s
   - Real-time zoekmogelijkheden
   - Real-time streaming
   - Implementatie van root contexts
   - Routingstrategieën
   - Samplingtechnieken
   - Schaalmethoden
   - Beveiligingsoverwegingen
   - Entra ID beveiligingsintegratie
   - Webzoekintegratie

7. **Communitybijdragen (06-CommunityContributions/)**
   - Hoe code en documentatie bijdragen
   - Samenwerken via GitHub
   - Community-gedreven verbeteringen en feedback
   - Gebruik van diverse MCP-clients (Claude Desktop, Cline, VSCode)
   - Werken met populaire MCP-servers inclusief beeldgeneratie

8. **Lessen uit Vroege Adoptie (07-LessonsfromEarlyAdoption/)**
   - Praktische implementaties en succesverhalen
   - Bouwen en uitrollen van MCP-gebaseerde oplossingen
   - Trends en toekomstige roadmap
   - **Microsoft MCP Servers Gids**: Uitgebreide gids voor 10 productieklare Microsoft MCP-servers, waaronder:
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
   - Prestatieoptimalisatie en tuning
   - Ontwerpen van fouttolerante MCP-systemen
   - Test- en veerkrachtstrategieën

10. **Case Studies (09-CaseStudy/)**
    - Voorbeeld van Azure API Management integratie
    - Voorbeeldimplementatie van een reisagent
    - Azure DevOps integratie met YouTube-updates
    - Documentatie MCP-implementatievoorbeelden
    - Implementatievoorbeelden met gedetailleerde documentatie

11. **Praktische Workshop (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Uitgebreide hands-on workshop die MCP combineert met AI Toolkit
    - Bouwen van intelligente applicaties die AI-modellen koppelen aan tools uit de praktijk
    - Praktische modules over de basis, aangepaste serverontwikkeling en productie-uitrolstrategieën
    - **Labstructuur**:
      - Lab 1: MCP Server Fundamentals
      - Lab 2: Geavanceerde MCP Serverontwikkeling
      - Lab 3: AI Toolkit-integratie
      - Lab 4: Productie-uitrol en schaalvergroting
    - Lab-gebaseerde leerbenadering met stapsgewijze instructies

## Aanvullende Bronnen

De repository bevat ondersteunende bronnen:

- **Afbeeldingenmap**: Bevat diagrammen en illustraties die door de cursus heen worden gebruikt
- **Vertalingen**: Meertalige ondersteuning met automatische vertalingen van documentatie
- **Officiële MCP-bronnen**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Hoe Gebruik je Deze Repository

1. **Gestructureerd Leren**: Volg de hoofdstukken op volgorde (00 tot en met 10) voor een gestructureerde leerervaring.
2. **Taalgerichte Focus**: Als je geïnteresseerd bent in een specifieke programmeertaal, bekijk dan de samples-mappen voor implementaties in jouw voorkeurstaal.
3. **Praktische Implementatie**: Begin met de sectie "Aan de Slag" om je omgeving op te zetten en je eerste MCP-server en client te maken.
4. **Geavanceerde Verkenning**: Zodra je de basis beheerst, duik je in de geavanceerde onderwerpen om je kennis uit te breiden.
5. **Community Betrokkenheid**: Word lid van de MCP-gemeenschap via GitHub-discussies en Discord-kanalen om in contact te komen met experts en medeontwikkelaars.

## MCP Clients en Tools

De cursus behandelt diverse MCP-clients en tools:

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

3. **MCP Beheer Tools**:
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

4. **Ontwikkeltools**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **Gespecialiseerde Servers**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Bijdragen

Deze repository verwelkomt bijdragen vanuit de community. Zie de sectie Communitybijdragen voor richtlijnen over hoe je effectief kunt bijdragen aan het MCP-ecosysteem.

## Wijzigingslog

| Datum | Wijzigingen |
|-------|-------------|
| 18 juli 2025 | - Bijgewerkte structuur van de repository met Microsoft MCP Servers Gids<br>- Uitgebreide lijst van 10 productieklare Microsoft MCP-servers toegevoegd<br>- Sectie Populaire MCP Servers uitgebreid met Officiële Microsoft MCP Servers<br>- Case Studies sectie bijgewerkt met daadwerkelijke bestandsvoorbeelden<br>- Details over Labstructuur toegevoegd voor Praktische Workshop |
| 16 juli 2025 | - Structuur van de repository aangepast aan actuele inhoud<br>- Sectie MCP Clients en Tools toegevoegd<br>- Sectie Populaire MCP Servers toegevoegd<br>- Visuele Curriculumkaart bijgewerkt met alle actuele onderwerpen<br>- Geavanceerde Onderwerpen sectie uitgebreid met alle gespecialiseerde gebieden<br>- Case Studies bijgewerkt met daadwerkelijke voorbeelden<br>- Oorsprong van MCP verduidelijkt als ontwikkeld door Anthropic |
| 11 juni 2025 | - Eerste versie van de studiegids gemaakt<br>- Visuele Curriculumkaart toegevoegd<br>- Structuur van de repository geschetst<br>- Voorbeeldprojecten en aanvullende bronnen opgenomen |

---

*Deze studiegids is bijgewerkt op 18 juli 2025 en geeft een overzicht van de repository tot die datum. De inhoud van de repository kan na deze datum worden aangepast.*

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.