<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T09:45:41+00:00",
  "source_file": "study_guide.md",
  "language_code": "pl"
}
-->
# Model Context Protocol (MCP) dla początkujących – przewodnik nauki

Ten przewodnik nauki przedstawia przegląd struktury i zawartości repozytorium dla kursu „Model Context Protocol (MCP) dla początkujących”. Skorzystaj z tego przewodnika, aby efektywnie poruszać się po repozytorium i w pełni wykorzystać dostępne zasoby.

## Przegląd repozytorium

Model Context Protocol (MCP) to ustandaryzowany framework do interakcji między modelami AI a aplikacjami klienckimi. Początkowo stworzony przez Anthropic, MCP jest obecnie utrzymywany przez szerszą społeczność MCP za pośrednictwem oficjalnej organizacji na GitHubie. To repozytorium oferuje kompleksowy program nauczania z praktycznymi przykładami kodu w C#, Java, JavaScript, Python oraz TypeScript, przeznaczony dla deweloperów AI, architektów systemów i inżynierów oprogramowania.

## Wizualna mapa programu nauczania

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

## Struktura repozytorium

Repozytorium jest podzielone na dziesięć głównych sekcji, z których każda skupia się na innym aspekcie MCP:

1. **Wprowadzenie (00-Introduction/)**
   - Przegląd Model Context Protocol
   - Dlaczego standaryzacja jest ważna w pipeline’ach AI
   - Praktyczne zastosowania i korzyści

2. **Podstawowe koncepcje (01-CoreConcepts/)**
   - Architektura klient-serwer
   - Kluczowe komponenty protokołu
   - Wzorce komunikacji w MCP

3. **Bezpieczeństwo (02-Security/)**
   - Zagrożenia bezpieczeństwa w systemach opartych na MCP
   - Najlepsze praktyki zabezpieczania implementacji
   - Strategie uwierzytelniania i autoryzacji
   - **Kompleksowa dokumentacja bezpieczeństwa**:
     - MCP Security Best Practices 2025
     - Azure Content Safety Implementation Guide
     - MCP Security Controls and Techniques
     - MCP Best Practices Quick Reference
   - **Kluczowe tematy bezpieczeństwa**:
     - Ataki typu prompt injection i tool poisoning
     - Przejęcie sesji i problemy confused deputy
     - Luki związane z przekazywaniem tokenów
     - Nadmierne uprawnienia i kontrola dostępu
     - Bezpieczeństwo łańcucha dostaw komponentów AI
     - Integracja Microsoft Prompt Shields

4. **Pierwsze kroki (03-GettingStarted/)**
   - Konfiguracja środowiska i ustawienia
   - Tworzenie podstawowych serwerów i klientów MCP
   - Integracja z istniejącymi aplikacjami
   - Zawiera sekcje dotyczące:
     - Pierwszej implementacji serwera
     - Rozwoju klienta
     - Integracji klienta LLM
     - Integracji z VS Code
     - Serwera Server-Sent Events (SSE)
     - Strumieniowania HTTP
     - Integracji AI Toolkit
     - Strategii testowania
     - Wytycznych dotyczących wdrożenia

5. **Praktyczna implementacja (04-PracticalImplementation/)**
   - Korzystanie z SDK w różnych językach programowania
   - Techniki debugowania, testowania i walidacji
   - Tworzenie wielokrotnego użytku szablonów promptów i workflowów
   - Przykładowe projekty z przykładami implementacji

6. **Zaawansowane tematy (05-AdvancedTopics/)**
   - Techniki inżynierii kontekstu
   - Integracja agenta Foundry
   - Wielomodalne workflowy AI
   - Demonstracje uwierzytelniania OAuth2
   - Możliwości wyszukiwania w czasie rzeczywistym
   - Strumieniowanie w czasie rzeczywistym
   - Implementacja root contexts
   - Strategie routingu
   - Techniki próbkowania
   - Podejścia do skalowania
   - Aspekty bezpieczeństwa
   - Integracja bezpieczeństwa Entra ID
   - Integracja wyszukiwania w sieci

7. **Wkład społeczności (06-CommunityContributions/)**
   - Jak wnosić kod i dokumentację
   - Współpraca przez GitHub
   - Ulepszenia i opinie napędzane przez społeczność
   - Korzystanie z różnych klientów MCP (Claude Desktop, Cline, VSCode)
   - Praca z popularnymi serwerami MCP, w tym generowaniem obrazów

8. **Wnioski z wczesnej adopcji (07-LessonsfromEarlyAdoption/)**
   - Realne implementacje i historie sukcesu
   - Budowa i wdrażanie rozwiązań opartych na MCP
   - Trendy i przyszła mapa drogowa
   - **Przewodnik po serwerach Microsoft MCP**: Kompleksowy przewodnik po 10 produkcyjnych serwerach Microsoft MCP, w tym:
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (15+ specjalizowanych konektorów)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **Najlepsze praktyki (08-BestPractices/)**
   - Optymalizacja wydajności i strojenie
   - Projektowanie odpornych na błędy systemów MCP
   - Strategie testowania i odporności

10. **Studia przypadków (09-CaseStudy/)**
    - Przykład integracji Azure API Management
    - Przykład implementacji agenta podróży
    - Integracja Azure DevOps z aktualizacjami YouTube
    - Przykłady implementacji MCP w dokumentacji
    - Przykłady implementacji z szczegółową dokumentacją

11. **Warsztaty praktyczne (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Kompleksowe warsztaty praktyczne łączące MCP z AI Toolkit
    - Budowa inteligentnych aplikacji łączących modele AI z narzędziami rzeczywistymi
    - Praktyczne moduły obejmujące podstawy, rozwój niestandardowego serwera i strategie wdrożenia produkcyjnego
    - **Struktura laboratorium**:
      - Lab 1: Podstawy serwera MCP
      - Lab 2: Zaawansowany rozwój serwera MCP
      - Lab 3: Integracja AI Toolkit
      - Lab 4: Wdrożenie produkcyjne i skalowanie
    - Nauka oparta na laboratoriach z instrukcjami krok po kroku

## Dodatkowe zasoby

Repozytorium zawiera materiały wspierające:

- **Folder Images**: Zawiera diagramy i ilustracje używane w całym programie nauczania
- **Tłumaczenia**: Wsparcie wielojęzyczne z automatycznymi tłumaczeniami dokumentacji
- **Oficjalne zasoby MCP**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Jak korzystać z tego repozytorium

1. **Nauka sekwencyjna**: Przechodź przez rozdziały po kolei (od 00 do 10), aby uzyskać uporządkowaną ścieżkę nauki.
2. **Skupienie na konkretnym języku**: Jeśli interesuje Cię konkretny język programowania, przeglądaj katalogi z przykładami implementacji w wybranym języku.
3. **Praktyczna implementacja**: Zacznij od sekcji „Pierwsze kroki”, aby skonfigurować środowisko i stworzyć swój pierwszy serwer i klient MCP.
4. **Zaawansowane eksploracje**: Po opanowaniu podstaw przejdź do zaawansowanych tematów, aby poszerzyć wiedzę.
5. **Zaangażowanie społeczności**: Dołącz do społeczności MCP poprzez dyskusje na GitHubie i kanały Discord, aby łączyć się z ekspertami i innymi deweloperami.

## Klienci i narzędzia MCP

Program nauczania obejmuje różne klientów i narzędzia MCP:

1. **Oficjalni klienci**:
   - Visual Studio Code
   - MCP w Visual Studio Code
   - Claude Desktop
   - Claude w VSCode
   - Claude API

2. **Klienci społecznościowi**:
   - Cline (terminalowy)
   - Cursor (edytor kodu)
   - ChatMCP
   - Windsurf

3. **Narzędzia do zarządzania MCP**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Popularne serwery MCP

Repozytorium przedstawia różne serwery MCP, w tym:

1. **Oficjalne serwery Microsoft MCP**:
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (15+ specjalizowanych konektorów)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **Oficjalne serwery referencyjne**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **Generowanie obrazów**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **Narzędzia deweloperskie**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **Serwery specjalistyczne**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Wkład w projekt

To repozytorium zachęca społeczność do współtworzenia. Zobacz sekcję Wkład społeczności, aby dowiedzieć się, jak skutecznie wspierać ekosystem MCP.

## Dziennik zmian

| Data | Zmiany |
|------|---------|
| 18 lipca 2025 | - Zaktualizowano strukturę repozytorium o przewodnik po serwerach Microsoft MCP<br>- Dodano kompleksową listę 10 produkcyjnych serwerów Microsoft MCP<br>- Rozbudowano sekcję Popularne serwery MCP o oficjalne serwery Microsoft MCP<br>- Zaktualizowano sekcję Studia przypadków o rzeczywiste przykłady plików<br>- Dodano szczegóły dotyczące struktury laboratoriów w warsztatach praktycznych |
| 16 lipca 2025 | - Zaktualizowano strukturę repozytorium, aby odzwierciedlić aktualną zawartość<br>- Dodano sekcję Klienci i narzędzia MCP<br>- Dodano sekcję Popularne serwery MCP<br>- Zaktualizowano wizualną mapę programu nauczania o wszystkie aktualne tematy<br>- Rozbudowano sekcję Zaawansowane tematy o wszystkie specjalistyczne obszary<br>- Zaktualizowano Studia przypadków, aby odzwierciedlały rzeczywiste przykłady<br>- Wyjaśniono pochodzenie MCP jako stworzonego przez Anthropic |
| 11 czerwca 2025 | - Pierwotne utworzenie przewodnika nauki<br>- Dodano wizualną mapę programu nauczania<br>- Nakreślono strukturę repozytorium<br>- Dołączono przykładowe projekty i dodatkowe zasoby |

---

*Ten przewodnik nauki został zaktualizowany 18 lipca 2025 i przedstawia stan repozytorium na ten dzień. Zawartość repozytorium może być aktualizowana po tej dacie.*

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.