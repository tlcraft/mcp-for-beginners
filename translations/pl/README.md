<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "677cecb63a0bf6c0f49e40ffc15f6189",
  "translation_date": "2025-06-02T12:22:48+00:00",
  "source_file": "README.md",
  "language_code": "pl"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.pl.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Postępuj według tych kroków, aby rozpocząć korzystanie z tych zasobów:
1. **Utwórz fork repozytorium**: Kliknij [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Sklonuj repozytorium**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Dołącz do Azure AI Foundry Discord i poznaj ekspertów oraz innych programistów**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Wsparcie wielojęzyczne

#### Obsługiwane przez GitHub Action (Automatyczne i zawsze aktualne)

# 🚀 Program nauczania Model Context Protocol (MCP) dla początkujących

## **Poznaj MCP na praktycznych przykładach kodu w C#, Java, JavaScript, Python i TypeScript**

## 🧠 Przegląd programu nauczania Model Context Protocol

**Model Context Protocol (MCP)** to nowoczesne ramy zaprojektowane w celu standaryzacji interakcji między modelami AI a aplikacjami klienckimi. Ten otwarty program nauczania oferuje uporządkowaną ścieżkę edukacyjną, zawierającą praktyczne przykłady kodu i rzeczywiste scenariusze użycia, w popularnych językach programowania takich jak C#, Java, JavaScript, TypeScript i Python.

Niezależnie od tego, czy jesteś programistą AI, architektem systemów, czy inżynierem oprogramowania, ten przewodnik jest Twoim kompleksowym źródłem wiedzy do opanowania podstaw MCP oraz strategii jego wdrażania.

## 🔗 Oficjalne zasoby MCP

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Szczegółowe samouczki i przewodniki użytkownika  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Architektura protokołu i odniesienia techniczne  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Otwarte SDK, narzędzia i przykłady kodu  

## 🧭 Pełna struktura programu nauczania MCP

| Ch | Tytuł | Opis | Link |
|--|--|--|--|
| 00 | **Wprowadzenie do MCP** | Przegląd Model Context Protocol i jego znaczenia w pipeline’ach AI, w tym czym jest Model Context Protocol, dlaczego standaryzacja jest ważna oraz praktyczne zastosowania i korzyści | [Introduction](./00-Introduction/README.md) |
| 01 | **Wyjaśnienie podstawowych pojęć** | Dogłębne omówienie kluczowych pojęć MCP, w tym architektury klient-serwer, głównych komponentów protokołu i wzorców komunikacji | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **Bezpieczeństwo w MCP** | Identyfikacja zagrożeń bezpieczeństwa w systemach opartych na MCP, techniki i najlepsze praktyki zabezpieczania implementacji | [Security](/02-Security/README.md) |
| 03 | **Pierwsze kroki z MCP** | Konfiguracja środowiska, tworzenie podstawowych serwerów i klientów MCP, integracja MCP z istniejącymi aplikacjami | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **Pierwszy serwer** | Konfiguracja podstawowego serwera z użyciem protokołu MCP, zrozumienie interakcji klient-serwer oraz testowanie serwera | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Pierwszy klient** | Konfiguracja podstawowego klienta z użyciem protokołu MCP, zrozumienie interakcji klient-serwer oraz testowanie klienta | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klient z LLM** | Konfiguracja klienta korzystającego z protokołu MCP z wykorzystaniem Large Language Model (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Korzystanie z serwera w Visual Studio Code** | Konfiguracja Visual Studio Code do korzystania z serwerów opartych na protokole MCP | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Tworzenie serwera z użyciem SSE** | SSE pozwala udostępnić serwer w internecie. Ta sekcja pomoże Ci stworzyć serwer korzystający z SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Korzystanie z AI Toolkit** | AI Toolkit to świetne narzędzie, które pomoże Ci zarządzać przepływem pracy AI i MCP | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testowanie serwera** | Testowanie to ważny etap procesu tworzenia oprogramowania. Ta sekcja pomoże Ci przetestować serwer przy użyciu różnych narzędzi | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Wdrażanie serwera** | Jak przejść od lokalnego developmentu do produkcji? Ta sekcja pomoże Ci rozwinąć i wdrożyć serwer | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktyczna implementacja** | Korzystanie z SDK w różnych językach, debugowanie, testowanie i walidacja, tworzenie wielokrotnego użytku szablonów promptów i workflow | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **Zaawansowane tematy MCP** | Wielomodalne workflow AI i rozszerzalność, bezpieczne strategie skalowania, MCP w środowiskach korporacyjnych | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **Demo MCP OAuth2** | Implementacja uwierzytelniania OAuth2 z serwerami MCP, w tym walidacja tokenów dostępu, autoryzacja oparta na zakresach oraz zabezpieczenie API | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.2 | **Wyszukiwanie w sieci z MCP** | Implementacja funkcji wyszukiwania w sieci za pomocą Model Context Protocol, w tym przetwarzanie zapytań, obsługa wyników i integracja z API wyszukiwarek | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Wkład społeczności** | Jak wnosić kod i dokumentację, współpraca przez GitHub, ulepszenia i opinie społeczności | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Wnioski z wczesnego wdrożenia** | Rzeczywiste implementacje i co się sprawdziło, budowa i wdrażanie rozwiązań opartych na MCP, trendy i przyszłe plany | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najlepsze praktyki MCP** | Optymalizacja wydajności, projektowanie odpornych na błędy systemów MCP, strategie testowania i odporności | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Studia przypadków MCP** | Szczegółowe analizy architektur rozwiązań MCP, plany wdrożeniowe i wskazówki integracyjne, diagramy i omówienia projektów | [Case Studies](./09-CaseStudy/README.md) |

## Przykładowe projekty

### 🧮 Przykładowe projekty kalkulatora MCP:
<details>
  <summary><strong>Przegląd implementacji kodu według języka</strong></summary>

  - [C# MCP Server Example](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Calculator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Example](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Zaawansowane projekty kalkulatora MCP:
<details>
  <summary><strong>Przegląd zaawansowanych przykładów</strong></summary>

  - [Advanced C# Sample](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App Example](./04-PracticalImplementation/samples/java/containerapp/README.md)
- [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Wymagania wstępne do nauki MCP

Aby jak najlepiej skorzystać z tego programu, powinieneś mieć:

- Podstawową wiedzę z C#, Java lub Python
- Zrozumienie modelu klient-serwer oraz API
- (Opcjonalnie) Znajomość podstaw uczenia maszynowego

## 🛠️ Jak skutecznie korzystać z tego programu

Każda lekcja w tym przewodniku zawiera:

1. Jasne wyjaśnienia koncepcji MCP  
2. Przykłady kodu na żywo w różnych językach  
3. Ćwiczenia do tworzenia prawdziwych aplikacji MCP  
4. Dodatkowe materiały dla zaawansowanych użytkowników  

## 📜 Informacje o licencji

Zawartość ta jest licencjonowana na podstawie **MIT License**. Szczegóły warunków znajdziesz w pliku [LICENSE](../../LICENSE).

## 🤝 Zasady współpracy

Ten projekt chętnie przyjmuje wkład i sugestie. Większość wkładów wymaga zgody na Contributor License Agreement (CLA), w którym deklarujesz, że masz prawo i faktycznie udzielasz nam
praw do wykorzystania Twojego wkładu. Szczegóły dostępne są pod adresem <https://cla.opensource.microsoft.com>.

Po przesłaniu pull requesta, bot CLA automatycznie sprawdzi, czy musisz dostarczyć
CLA i odpowiednio oznaczy PR (np. status, komentarz). Wystarczy, że wykonasz instrukcje
podane przez bota. Robisz to tylko raz we wszystkich repozytoriach korzystających z naszego CLA.

Projekt przyjął [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
Więcej informacji znajdziesz w [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) lub
kontaktując się pod adresem [opencode@microsoft.com](mailto:opencode@microsoft.com) w razie dodatkowych pytań lub uwag.

## 🎒 Inne kursy
Nasz zespół tworzy również inne kursy! Sprawdź:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for AI Paired Programming](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for C#/.NET Developers](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Choose Your Own Copilot Adventure](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Informacja o znakach towarowych

Ten projekt może zawierać znaki towarowe lub logotypy projektów, produktów lub usług. Autoryzowane użycie znaków towarowych lub logotypów Microsoft podlega i musi przestrzegać
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Użycie znaków towarowych lub logotypów Microsoft w zmodyfikowanych wersjach tego projektu nie może powodować nieporozumień ani sugerować wsparcia Microsoft.
Wszelkie użycie znaków towarowych lub logotypów stron trzecich podlega politykom tych stron.

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy pamiętać, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy uważać za wiarygodne źródło. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.