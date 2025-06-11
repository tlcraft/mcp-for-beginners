<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c7fbf0cdaa44b3245daff0c8bb4f439e",
  "translation_date": "2025-06-11T15:31:48+00:00",
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


Postępuj zgodnie z tymi krokami, aby rozpocząć korzystanie z tych zasobów:
1. **Zrób fork repozytorium**: Kliknij [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Sklonuj repozytorium**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Dołącz do Discorda Azure AI Foundry, poznaj ekspertów i innych programistów**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Wsparcie wielojęzyczne

#### Wspierane przez GitHub Action (Automatyczne i zawsze aktualne)

# 🚀 Program nauczania Model Context Protocol (MCP) dla początkujących

## **Naucz się MCP na praktycznych przykładach kodu w C#, Java, JavaScript, Python i TypeScript**

## 🧠 Przegląd programu nauczania Model Context Protocol

**Model Context Protocol (MCP)** to nowoczesny framework zaprojektowany w celu standaryzacji interakcji między modelami AI a aplikacjami klienckimi. Ten otwarty program nauczania oferuje usystematyzowaną ścieżkę edukacyjną, zawierającą praktyczne przykłady kodu i rzeczywiste przypadki użycia, obejmując popularne języki programowania takie jak C#, Java, JavaScript, TypeScript i Python.

Niezależnie od tego, czy jesteś programistą AI, architektem systemów czy inżynierem oprogramowania, ten przewodnik jest kompleksowym źródłem wiedzy, które pozwoli Ci opanować podstawy MCP i strategie jego wdrożenia.

## 🔗 Oficjalne zasoby MCP

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Szczegółowe samouczki i przewodniki użytkownika  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Architektura protokołu i odniesienia techniczne  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Otwarte SDK, narzędzia i przykłady kodu  

## 🧭 Pełna struktura programu nauczania MCP

| Ch | Tytuł | Opis | Link |
|--|--|--|--|
| 00 | **Wprowadzenie do MCP** | Przegląd Model Context Protocol i jego znaczenia w pipeline’ach AI, w tym czym jest Model Context Protocol, dlaczego standaryzacja jest ważna oraz praktyczne przypadki użycia i korzyści | [Introduction](./00-Introduction/README.md) |
| 01 | **Wyjaśnienie podstawowych pojęć** | Dogłębne omówienie kluczowych koncepcji MCP, w tym architektury klient-serwer, głównych komponentów protokołu oraz wzorców komunikacji | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **Bezpieczeństwo w MCP** | Identyfikacja zagrożeń bezpieczeństwa w systemach opartych na MCP, techniki i najlepsze praktyki zabezpieczania implementacji | [Security](/02-Security/README.md) |
| 03 | **Pierwsze kroki z MCP** | Konfiguracja środowiska, tworzenie podstawowych serwerów i klientów MCP, integracja MCP z istniejącymi aplikacjami | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **Pierwszy serwer** | Konfiguracja podstawowego serwera z użyciem protokołu MCP, zrozumienie interakcji serwer-klient oraz testowanie serwera | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Pierwszy klient** | Konfiguracja podstawowego klienta z użyciem protokołu MCP, zrozumienie interakcji klient-serwer oraz testowanie klienta | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klient z LLM** | Konfiguracja klienta używającego protokołu MCP z dużym modelem językowym (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Korzystanie z serwera w Visual Studio Code** | Konfiguracja Visual Studio Code do korzystania z serwerów działających w protokole MCP | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Tworzenie serwera przy użyciu SSE** | SSE pozwala udostępnić serwer w internecie. Ta sekcja pomoże Ci stworzyć serwer korzystający z SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Korzystanie z AI Toolkit** | AI Toolkit to świetne narzędzie, które pomoże Ci zarządzać przepływem pracy AI i MCP | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testowanie serwera** | Testowanie to ważny etap procesu tworzenia oprogramowania. Ta sekcja pomoże Ci przetestować serwer przy użyciu różnych narzędzi | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Wdrażanie serwera** | Jak przejść od lokalnego rozwoju do produkcji? Ta sekcja pomoże Ci rozwijać i wdrażać serwer | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktyczna implementacja** | Korzystanie z SDK w różnych językach, debugowanie, testowanie i walidacja, tworzenie wielokrotnego użytku szablonów promptów i przepływów pracy | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **Zaawansowane tematy w MCP** | Wielomodalne przepływy pracy AI i rozszerzalność, bezpieczne strategie skalowania, MCP w ekosystemach korporacyjnych | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracja MCP z Azure** | Pokazuje integrację z Azure | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalność** | Pokazuje, jak pracować z różnymi modalnościami, takimi jak obrazy i inne | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **Demo MCP OAuth2** | Minimalna aplikacja Spring Boot pokazująca OAuth2 z MCP, zarówno jako Authorization jak i Resource Server. Demonstruje bezpieczne wydawanie tokenów, chronione endpointy, wdrożenie na Azure Container Apps oraz integrację z API Management | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Dowiedz się więcej o root context i jak je implementować | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Poznaj różne typy routingu | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naucz się pracy z samplingiem | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skalowanie** | Dowiedz się o skalowaniu serwerów MCP, w tym o strategiach skalowania horyzontalnego i wertykalnego, optymalizacji zasobów oraz strojenia wydajności | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Bezpieczeństwo** | Zabezpiecz swój serwer MCP, w tym uwierzytelnianie, autoryzację oraz strategie ochrony danych | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Serwer i klient MCP w Pythonie integrujący się z SerpAPI do wyszukiwania w czasie rzeczywistym w sieci, wiadomości, produktów i Q&A. Demonstruje orkiestrację wielu narzędzi, integrację z zewnętrznymi API oraz solidne obsługiwanie błędów | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Strumieniowanie w czasie rzeczywistym** | Strumieniowanie danych w czasie rzeczywistym stało się niezbędne we współczesnym świecie napędzanym danymi, gdzie firmy i aplikacje wymagają natychmiastowego dostępu do informacji, by podejmować szybkie decyzje | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 06 | **Wkład społeczności** | Jak wnosić kod i dokumentację, współpraca przez GitHub, ulepszenia i opinie napędzane przez społeczność | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Wnioski z wczesnego wdrożenia** | Rzeczywiste wdrożenia i co się sprawdziło, budowa i wdrażanie rozwiązań opartych na MCP, trendy i przyszła mapa drogowa | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najlepsze praktyki MCP** | Strojenie wydajności i optymalizacja, projektowanie odpornych systemów MCP, strategie testowania i odporności | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Studia przypadków MCP** | Dogłębne analizy architektur rozwiązań MCP, plany wdrożeń i wskazówki dotyczące integracji, opatrzone komentarzami diagramy oraz omówienia projektów | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Usprawnianie przepływów AI: Budowa serwera MCP z AI Toolkit** | Kompleksowe, praktyczne warsztaty łączące MCP z Microsoft AI Toolkit dla VS Code. Naucz się tworzyć inteligentne aplikacje łączące modele AI z narzędziami rzeczywistymi poprzez praktyczne moduły obejmujące podstawy, tworzenie niestandardowego serwera oraz strategie wdrożenia produkcyjnego. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Przykładowe projekty

### 🧮 Przykładowe projekty kalkulatora MCP:
<details>
  <summary><strong>Przeglądaj implementacje kodu według języka</strong></summary>

  - [Przykład serwera MCP w C#](./03-GettingStarted/samples/csharp/README.md)
  - [Kalkulator MCP w Javie](./03-GettingStarted/samples/java/calculator/README.md)
  - [Demo MCP w JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [Serwer MCP w Pythonie](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Przykład MCP w TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Zaawansowane projekty kalkulatora MCP:
<details>
  <summary><strong>Przeglądaj zaawansowane przykłady</strong></summary>

  - [Zaawansowany przykład w C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Przykład aplikacji kontenerowej w Javie](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Zaawansowany przykład w JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [Złożona implementacja w Pythonie](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Przykład kontenera w TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Wymagania wstępne do nauki MCP

Aby w pełni wykorzystać ten program, powinieneś posiadać:

- Podstawową znajomość C#, Java lub Python
- Zrozumienie modelu klient-serwer i API
- (Opcjonalnie) Znajomość podstaw uczenia maszynowego

## 📚 Przewodnik po nauce

Dostępny jest obszerny [Przewodnik po nauce](./study_guide.md), który pomoże Ci efektywnie poruszać się po tym repozytorium. Przewodnik zawiera:

- Wizualną mapę programu obejmującą wszystkie tematy
- Szczegółowy podział każdej sekcji repozytorium
- Wskazówki, jak korzystać z przykładowych projektów
- Zalecane ścieżki nauki dla różnych poziomów zaawansowania
- Dodatkowe materiały wspierające proces nauki

## 🛠️ Jak efektywnie korzystać z tego programu

Każda lekcja w tym przewodniku zawiera:

1. Jasne wyjaśnienia koncepcji MCP  
2. Przykłady kodu na żywo w różnych językach  
3. Ćwiczenia do tworzenia prawdziwych aplikacji MCP  
4. Dodatkowe materiały dla zaawansowanych użytkowników  

## 📜 Informacje o licencji

Ta zawartość jest objęta **licencją MIT**. Warunki licencji znajdziesz w pliku [LICENSE](../../LICENSE).

## 🤝 Zasady współpracy

Ten projekt zachęca do zgłaszania wkładu i sugestii. Większość wkładów wymaga zgody na Contributor License Agreement (CLA), w którym oświadczasz, że masz prawo i rzeczywiście udzielasz nam praw do korzystania z Twojego wkładu. Szczegóły znajdziesz na <https://cla.opensource.microsoft.com>.

Po przesłaniu pull requesta, bot CLA automatycznie sprawdzi, czy musisz dostarczyć CLA i odpowiednio oznaczy PR (np. kontrola statusu, komentarz). Wystarczy, że wykonasz te kroki raz dla wszystkich repozytoriów korzystających z naszego CLA.

Projekt przyjął [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).  
Więcej informacji znajdziesz w [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) lub kontaktując się pod adresem [opencode@microsoft.com](mailto:opencode@microsoft.com) w razie dodatkowych pytań lub uwag.

## 🎒 Inne kursy
Nasz zespół tworzy także inne kursy! Sprawdź:

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
- [Wybierz własną przygodę z Copilotem](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Informacja o znaku towarowym

Ten projekt może zawierać znaki towarowe lub logotypy projektów, produktów lub usług. Autoryzowane użycie znaków towarowych lub logotypów Microsoft musi być zgodne z [Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).  
Użycie znaków towarowych lub logotypów Microsoft w zmodyfikowanych wersjach tego projektu nie może powodować nieporozumień ani sugerować wsparcia ze strony Microsoft.  
Każde użycie znaków towarowych lub logotypów firm trzecich podlega zasadom tych firm.

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy wszelkich starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło autorytatywne. W przypadku informacji o istotnym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.