<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3ede7f051090bd4acfe5b068bab9f6b0",
  "translation_date": "2025-06-10T04:23:33+00:00",
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


Wykonaj te kroki, aby rozpocząć korzystanie z tych zasobów:
1. **Utwórz fork repozytorium**: Kliknij [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Sklonuj repozytorium**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Dołącz do Azure AI Foundry Discord i poznaj ekspertów oraz innych deweloperów**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Wsparcie wielojęzyczne

#### Obsługiwane przez GitHub Action (zautomatyzowane i zawsze aktualne)

# 🚀 Model Context Protocol (MCP) Curriculum dla początkujących

## **Naucz się MCP na praktycznych przykładach kodu w C#, Java, JavaScript, Python i TypeScript**

## 🧠 Przegląd programu nauczania Model Context Protocol

**Model Context Protocol (MCP)** to nowoczesne rozwiązanie mające na celu ustandaryzowanie interakcji między modelami AI a aplikacjami klienckimi. Ten otwarty kurs oferuje uporządkowaną ścieżkę nauki, zawierającą praktyczne przykłady kodu oraz rzeczywiste zastosowania w popularnych językach programowania, takich jak C#, Java, JavaScript, TypeScript i Python.

Niezależnie od tego, czy jesteś deweloperem AI, architektem systemów czy inżynierem oprogramowania, ten przewodnik jest kompleksowym źródłem wiedzy na temat podstaw MCP oraz strategii jego wdrażania.

## 🔗 Oficjalne zasoby MCP

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Szczegółowe samouczki i przewodniki użytkownika  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Architektura protokołu i odniesienia techniczne  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Otwarte SDK, narzędzia i przykłady kodu  

## 🧭 Pełna struktura programu MCP

| Ch | Tytuł | Opis | Link |
|--|--|--|--|
| 00 | **Wprowadzenie do MCP** | Przegląd Model Context Protocol i jego znaczenia w pipeline'ach AI, w tym czym jest MCP, dlaczego standaryzacja jest ważna oraz praktyczne przypadki użycia i korzyści | [Introduction](./00-Introduction/README.md) |
| 01 | **Wyjaśnienie podstawowych koncepcji** | Dogłębne omówienie kluczowych koncepcji MCP, w tym architektury klient-serwer, głównych komponentów protokołu oraz wzorców komunikacji | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **Bezpieczeństwo w MCP** | Identyfikacja zagrożeń bezpieczeństwa w systemach opartych na MCP, techniki i najlepsze praktyki zabezpieczania implementacji | [Security](/02-Security/README.md) |
| 03 | **Pierwsze kroki z MCP** | Konfiguracja środowiska, tworzenie podstawowych serwerów i klientów MCP, integracja MCP z istniejącymi aplikacjami | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **Pierwszy serwer** | Konfiguracja podstawowego serwera zgodnie z protokołem MCP, zrozumienie interakcji serwer-klient oraz testowanie serwera | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Pierwszy klient**  | Konfiguracja podstawowego klienta zgodnie z protokołem MCP, zrozumienie interakcji klient-serwer oraz testowanie klienta | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klient z LLM**  | Konfiguracja klienta MCP korzystającego z dużego modelu językowego (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Korzystanie z serwera w Visual Studio Code** | Konfiguracja Visual Studio Code do pracy z serwerami korzystającymi z protokołu MCP | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Tworzenie serwera z użyciem SSE** | SSE pozwala na udostępnienie serwera w internecie. Ta sekcja pomoże Ci stworzyć serwer wykorzystujący SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Korzystanie z AI Toolkit** | AI Toolkit to świetne narzędzie pomagające zarządzać pracą z AI i MCP | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testowanie serwera** | Testowanie to ważny etap procesu tworzenia oprogramowania. Ta sekcja pokaże, jak korzystać z różnych narzędzi do testów | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Wdrażanie serwera** | Jak przejść od lokalnego rozwoju do produkcji? Ta sekcja pomoże Ci rozwijać i wdrażać serwer | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktyczna implementacja** | Korzystanie z SDK w różnych językach, debugowanie, testowanie i walidacja, tworzenie wielokrotnego użytku szablonów promptów i workflow | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **Zaawansowane tematy MCP** | Wielomodalne workflow AI i rozszerzalność, bezpieczne strategie skalowania, MCP w środowiskach korporacyjnych | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracja MCP z Azure** | Przykład integracji z Azure | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalność** | Pokaz pracy z różnymi modalnościami, takimi jak obrazy i inne | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **Demo MCP OAuth2** | Minimalna aplikacja Spring Boot pokazująca OAuth2 z MCP jako Authorization i Resource Server. Demonstruje bezpieczne wydawanie tokenów, chronione endpointy, wdrożenie w Azure Container Apps oraz integrację z API Management | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Dowiedz się więcej o root context i jak je zaimplementować | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Poznaj różne typy routingu | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naucz się pracy z samplingiem | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skalowanie** | Poznaj skalowanie serwerów MCP, w tym strategie skalowania poziomego i pionowego, optymalizację zasobów oraz strojenie wydajności | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Bezpieczeństwo** | Zabezpiecz swój serwer MCP, w tym uwierzytelnianie, autoryzację i strategie ochrony danych | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Serwer i klient MCP w Pythonie integrujący się z SerpAPI do wyszukiwania w czasie rzeczywistym w sieci, wiadomościach, produktach i Q&A. Pokazuje orkiestrację wielu narzędzi, integrację z zewnętrznymi API i solidne zarządzanie błędami | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Wkład społeczności** | Jak wnosić kod i dokumentację, współpraca przez GitHub, ulepszenia i opinie społeczności | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Wnioski z wczesnej adopcji** | Rzeczywiste wdrożenia i co się sprawdziło, budowanie i wdrażanie rozwiązań opartych na MCP, trendy i przyszła mapa drogowa | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najlepsze praktyki MCP** | Strojenie wydajności i optymalizacja, projektowanie odpornych na błędy systemów MCP, strategie testowania i odporności | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Studia przypadków MCP** | Szczegółowe analizy architektur rozwiązań MCP, plany wdrożeń i wskazówki integracyjne, opatrzone diagramy i przewodniki po projektach | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Usprawnianie przepływów pracy AI: Budowa serwera MCP z AI Toolkit** | Kompleksowe, praktyczne warsztaty łączące MCP z AI Toolkit firmy Microsoft dla VS Code. Naucz się tworzyć inteligentne aplikacje łączące modele AI z narzędziami rzeczywistymi poprzez praktyczne moduły obejmujące podstawy, tworzenie niestandardowego serwera oraz strategie wdrożenia produkcyjnego. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Przykładowe projekty

### 🧮 Przykładowe projekty kalkulatora MCP:
<details>
  <summary><strong>Przegląd implementacji kodu według języka</strong></summary>

  - [Przykład serwera MCP w C#](./03-GettingStarted/samples/csharp/README.md)
  - [Kalkulator MCP w Javie](./03-GettingStarted/samples/java/calculator/README.md)
  - [Demo MCP w JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [Serwer MCP w Pythonie](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Przykład MCP w TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Zaawansowane projekty kalkulatora MCP:
<details>
  <summary><strong>Przegląd zaawansowanych przykładów</strong></summary>

  - [Zaawansowany przykład w C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Przykład aplikacji kontenerowej w Javie](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Zaawansowany przykład w JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [Złożona implementacja w Pythonie](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Przykład kontenera w TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Wymagania wstępne do nauki MCP

Aby w pełni wykorzystać ten materiał, powinieneś mieć:

- Podstawową znajomość C#, Javy lub Pythona
- Zrozumienie modelu klient-serwer oraz API
- (Opcjonalnie) Znajomość podstaw uczenia maszynowego

## 🛠️ Jak efektywnie korzystać z tego materiału

Każda lekcja w tym przewodniku zawiera:

1. Jasne wyjaśnienia koncepcji MCP  
2. Przykłady kodu na żywo w różnych językach  
3. Ćwiczenia do tworzenia rzeczywistych aplikacji MCP  
4. Dodatkowe materiały dla zaawansowanych użytkowników  

## 📜 Informacje o licencji

Ta zawartość jest udostępniona na podstawie **licencji MIT**. Szczegóły i warunki znajdziesz w pliku [LICENSE](../../LICENSE).

## 🤝 Zasady współpracy

Ten projekt zachęca do zgłaszania wkładów i sugestii. Większość z nich wymaga zaakceptowania
Contributor License Agreement (CLA), w którym oświadczasz, że masz prawo i faktycznie udzielasz nam
praw do korzystania z Twojego wkładu. Szczegóły znajdziesz na <https://cla.opensource.microsoft.com>.

Po zgłoszeniu pull requesta, bot CLA automatycznie sprawdzi, czy musisz dostarczyć
CLA i odpowiednio oznaczy PR (np. status, komentarz). Wystarczy, że wykonasz to raz dla wszystkich repozytoriów korzystających z naszego CLA.

Projekt ten przyjął [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
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

Ten projekt może zawierać znaki towarowe lub logotypy dotyczące projektów, produktów lub usług. Autoryzowane użycie znaków towarowych lub logotypów Microsoft musi być zgodne z
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Użycie znaków towarowych lub logotypów Microsoft w zmodyfikowanych wersjach tego projektu nie może wprowadzać w błąd ani sugerować sponsorowania przez Microsoft.
Wszelkie użycie znaków towarowych lub logotypów stron trzecich podlega zasadom tych podmiotów.

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być uznawany za autorytatywne źródło. W przypadku informacji o kluczowym znaczeniu zaleca się skorzystanie z profesjonalnego, ludzkiego tłumaczenia. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.