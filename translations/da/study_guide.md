<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T09:57:58+00:00",
  "source_file": "study_guide.md",
  "language_code": "da"
}
-->
# Model Context Protocol (MCP) for Begyndere - Studieguide

Denne studieguide giver en oversigt over repository-strukturen og indholdet for "Model Context Protocol (MCP) for Beginners"-pensum. Brug denne guide til effektivt at navigere i repositoryet og få mest muligt ud af de tilgængelige ressourcer.

## Oversigt over Repository

Model Context Protocol (MCP) er en standardiseret ramme for interaktioner mellem AI-modeller og klientapplikationer. Oprindeligt skabt af Anthropic, vedligeholdes MCP nu af det bredere MCP-fællesskab gennem den officielle GitHub-organisation. Dette repository indeholder et omfattende pensum med praktiske kodeeksempler i C#, Java, JavaScript, Python og TypeScript, designet til AI-udviklere, systemarkitekter og softwareingeniører.

## Visuelt Pensumkort

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

## Repository-struktur

Repositoryet er organiseret i ti hovedsektioner, der hver især fokuserer på forskellige aspekter af MCP:

1. **Introduktion (00-Introduction/)**
   - Oversigt over Model Context Protocol
   - Hvorfor standardisering er vigtigt i AI-pipelines
   - Praktiske anvendelsestilfælde og fordele

2. **Kernebegreber (01-CoreConcepts/)**
   - Client-server arkitektur
   - Vigtige protokolkomponenter
   - Messaging-mønstre i MCP

3. **Sikkerhed (02-Security/)**
   - Sikkerhedstrusler i MCP-baserede systemer
   - Bedste praksis for sikring af implementeringer
   - Autentificerings- og autorisationsstrategier
   - **Omfattende sikkerhedsdokumentation**:
     - MCP Security Best Practices 2025
     - Azure Content Safety Implementation Guide
     - MCP Security Controls and Techniques
     - MCP Best Practices Quick Reference
   - **Vigtige sikkerhedsemner**:
     - Prompt injection og tool poisoning-angreb
     - Session hijacking og confused deputy-problemer
     - Token passthrough-sårbarheder
     - Overdrevne tilladelser og adgangskontrol
     - Supply chain-sikkerhed for AI-komponenter
     - Microsoft Prompt Shields-integration

4. **Kom godt i gang (03-GettingStarted/)**
   - Opsætning og konfiguration af miljø
   - Oprettelse af grundlæggende MCP-servere og klienter
   - Integration med eksisterende applikationer
   - Indeholder sektioner for:
     - Første serverimplementering
     - Klientudvikling
     - LLM-klientintegration
     - VS Code-integration
     - Server-Sent Events (SSE) server
     - HTTP streaming
     - AI Toolkit-integration
     - Teststrategier
     - Udrulningsvejledning

5. **Praktisk implementering (04-PracticalImplementation/)**
   - Brug af SDK’er på tværs af forskellige programmeringssprog
   - Debugging, test og valideringsteknikker
   - Udformning af genanvendelige promptskabeloner og workflows
   - Eksempler på projekter med implementering

6. **Avancerede emner (05-AdvancedTopics/)**
   - Context engineering-teknikker
   - Foundry agent-integration
   - Multi-modale AI-workflows
   - OAuth2-autentificeringsdemoer
   - Real-time søgefunktioner
   - Real-time streaming
   - Implementering af root contexts
   - Routing-strategier
   - Sampling-teknikker
   - Skaleringsmetoder
   - Sikkerhedsovervejelser
   - Entra ID-sikkerhedsintegration
   - Websøgningsintegration

7. **Fællesskabsbidrag (06-CommunityContributions/)**
   - Hvordan man bidrager med kode og dokumentation
   - Samarbejde via GitHub
   - Fællesskabsdrevne forbedringer og feedback
   - Brug af forskellige MCP-klienter (Claude Desktop, Cline, VSCode)
   - Arbejde med populære MCP-servere inklusive billedgenerering

8. **Lektioner fra tidlig adoption (07-LessonsfromEarlyAdoption/)**
   - Virkelige implementeringer og succeshistorier
   - Opbygning og udrulning af MCP-baserede løsninger
   - Tendenser og fremtidig roadmap
   - **Microsoft MCP Servers Guide**: Omfattende guide til 10 produktionsklare Microsoft MCP-servere, herunder:
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (15+ specialiserede connectors)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **Bedste praksis (08-BestPractices/)**
   - Performance-tuning og optimering
   - Design af fejltolerante MCP-systemer
   - Test- og robusthedsstrategier

10. **Case-studier (09-CaseStudy/)**
    - Eksempel på integration med Azure API Management
    - Eksempel på implementering af rejsebureau
    - Azure DevOps-integration med YouTube-opdateringer
    - Dokumentationsimplementering med MCP-eksempler
    - Implementeringseksempler med detaljeret dokumentation

11. **Hands-on workshop (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Omfattende hands-on workshop, der kombinerer MCP med AI Toolkit
    - Opbygning af intelligente applikationer, der forbinder AI-modeller med virkelige værktøjer
    - Praktiske moduler, der dækker grundlæggende, tilpasset serverudvikling og produktionsudrulningsstrategier
    - **Lab-struktur**:
      - Lab 1: MCP Server Fundamentals
      - Lab 2: Advanced MCP Server Development
      - Lab 3: AI Toolkit Integration
      - Lab 4: Production Deployment and Scaling
    - Lab-baseret læring med trin-for-trin instruktioner

## Yderligere ressourcer

Repositoryet indeholder understøttende ressourcer:

- **Images-mappe**: Indeholder diagrammer og illustrationer brugt gennem pensum
- **Oversættelser**: Flersproget support med automatiserede oversættelser af dokumentation
- **Officielle MCP-ressourcer**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Sådan bruger du dette repository

1. **Sekventiel læring**: Følg kapitlerne i rækkefølge (00 til 10) for en struktureret læringsoplevelse.
2. **Sprog-specifik fokus**: Hvis du er interesseret i et bestemt programmeringssprog, kan du udforske sample-mapperne for implementeringer i dit foretrukne sprog.
3. **Praktisk implementering**: Start med sektionen "Kom godt i gang" for at sætte dit miljø op og oprette din første MCP-server og klient.
4. **Avanceret udforskning**: Når du er fortrolig med det grundlæggende, kan du dykke ned i de avancerede emner for at udvide din viden.
5. **Fællesskabsengagement**: Deltag i MCP-fællesskabet via GitHub-diskussioner og Discord-kanaler for at forbinde med eksperter og andre udviklere.

## MCP-klienter og værktøjer

Pensum dækker forskellige MCP-klienter og værktøjer:

1. **Officielle klienter**:
   - Visual Studio Code
   - MCP i Visual Studio Code
   - Claude Desktop
   - Claude i VSCode
   - Claude API

2. **Fællesskabsklienter**:
   - Cline (terminal-baseret)
   - Cursor (kodeeditor)
   - ChatMCP
   - Windsurf

3. **MCP-administrationsværktøjer**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Populære MCP-servere

Repositoryet introducerer forskellige MCP-servere, herunder:

1. **Officielle Microsoft MCP-servere**:
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (15+ specialiserede connectors)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **Officielle reference-servere**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **Billedgenerering**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **Udviklingsværktøjer**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **Specialiserede servere**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Bidrag

Dette repository byder velkommen til bidrag fra fællesskabet. Se sektionen Fællesskabsbidrag for vejledning i, hvordan du effektivt kan bidrage til MCP-økosystemet.

## Ændringslog

| Dato          | Ændringer                                                                                              |
|---------------|------------------------------------------------------------------------------------------------------|
| 18. juli 2025 | - Opdateret repository-struktur med Microsoft MCP Servers Guide<br>- Tilføjet omfattende liste over 10 produktionsklare Microsoft MCP-servere<br>- Udvidet sektionen Populære MCP-servere med Officielle Microsoft MCP-servere<br>- Opdateret Case Studies med faktiske fil-eksempler<br>- Tilføjet detaljer om Lab-struktur til Hands-on Workshop |
| 16. juli 2025 | - Opdateret repository-struktur for at afspejle aktuelt indhold<br>- Tilføjet sektion MCP Clients and Tools<br>- Tilføjet sektion Populære MCP-servere<br>- Opdateret Visuelt Pensumkort med alle aktuelle emner<br>- Udvidet Avancerede emner med alle specialiserede områder<br>- Opdateret Case Studies med faktiske eksempler<br>- Præciseret MCP’s oprindelse som skabt af Anthropic |
| 11. juni 2025 | - Oprindelig oprettelse af studieguide<br>- Tilføjet Visuelt Pensumkort<br>- Skitseret repository-struktur<br>- Inkluderet eksempler på projekter og yderligere ressourcer |

---

*Denne studieguide blev opdateret den 18. juli 2025 og giver en oversigt over repositoryet pr. denne dato. Indholdet i repositoryet kan blive opdateret efter denne dato.*

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.