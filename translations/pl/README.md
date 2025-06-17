<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:43:06+00:00",
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
3. [**Dołącz do Azure AI Foundry Discord i poznaj ekspertów oraz innych programistów**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Wsparcie wielojęzyczne

#### Obsługiwane przez GitHub Action (Automatyczne i zawsze aktualne)

# 🚀 Program nauczania Model Context Protocol (MCP) dla początkujących

## **Naucz się MCP na praktycznych przykładach kodu w C#, Java, JavaScript, Python i TypeScript**

## 🧠 Przegląd programu nauczania Model Context Protocol

**Model Context Protocol (MCP)** to nowoczesny framework zaprojektowany, aby ustandaryzować interakcje między modelami AI a aplikacjami klienckimi. Ten otwarty program nauczania oferuje uporządkowaną ścieżkę edukacyjną, wzbogaconą praktycznymi przykładami kodu i rzeczywistymi zastosowaniami, w popularnych językach programowania takich jak C#, Java, JavaScript, TypeScript i Python.

Niezależnie od tego, czy jesteś deweloperem AI, architektem systemów, czy inżynierem oprogramowania, ten przewodnik to kompleksowe źródło wiedzy o podstawach MCP i strategiach jego wdrażania.

## 🔗 Oficjalne zasoby MCP

- 📘 [Dokumentacja MCP](https://modelcontextprotocol.io/) – Szczegółowe samouczki i przewodniki użytkownika  
- 📜 [Specyfikacja MCP](https://spec.modelcontextprotocol.io/) – Architektura protokołu i odniesienia techniczne  
- 🧑‍💻 [Repozytorium MCP na GitHub](https://github.com/modelcontextprotocol) – Otwarte SDK, narzędzia i przykłady kodu  

## 🧭 Pełna struktura programu nauczania MCP

| Rozdział | Tytuł | Opis | Link |
|--|--|--|--|
| 00 | **Wprowadzenie do MCP** | Przegląd Model Context Protocol i jego znaczenia w pipeline’ach AI, w tym czym jest MCP, dlaczego standaryzacja jest ważna oraz praktyczne zastosowania i korzyści | [Wprowadzenie](./00-Introduction/README.md) |
| 01 | **Omówienie kluczowych koncepcji** | Szczegółowe omówienie podstawowych koncepcji MCP, w tym architektury klient-serwer, kluczowych elementów protokołu oraz wzorców komunikacji | [Kluczowe koncepcje](./01-CoreConcepts/README.md) |
| 02 | **Bezpieczeństwo w MCP** | Identyfikacja zagrożeń bezpieczeństwa w systemach opartych na MCP, techniki i najlepsze praktyki zabezpieczania implementacji | [Bezpieczeństwo](./02-Security/README.md) |
| 03 | **Pierwsze kroki z MCP** | Konfiguracja środowiska, tworzenie podstawowych serwerów i klientów MCP, integracja MCP z istniejącymi aplikacjami | [Pierwsze kroki](./03-GettingStarted/README.md) |
| 3.1 | **Pierwszy serwer** | Konfiguracja podstawowego serwera korzystającego z protokołu MCP, zrozumienie interakcji serwer-klient oraz testowanie serwera | [Pierwszy serwer](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Pierwszy klient** | Konfiguracja podstawowego klienta korzystającego z protokołu MCP, zrozumienie interakcji klient-serwer oraz testowanie klienta | [Pierwszy klient](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klient z LLM** | Konfiguracja klienta korzystającego z protokołu MCP z wykorzystaniem dużego modelu językowego (LLM) | [Klient z LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Korzystanie z serwera w Visual Studio Code** | Konfiguracja Visual Studio Code do korzystania z serwerów wykorzystujących protokół MCP | [Korzystanie z serwera w Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Tworzenie serwera z użyciem SSE** | SSE pozwala na udostępnienie serwera w Internecie. Ta sekcja pomoże Ci stworzyć serwer z użyciem SSE | [Tworzenie serwera z użyciem SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Streaming** | Naucz się implementować strumieniowanie HTTP do przesyłania danych w czasie rzeczywistym między klientami a serwerami MCP | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Korzystanie z AI Toolkit** | AI Toolkit to świetne narzędzie, które pomoże Ci zarządzać przepływem pracy AI i MCP | [Korzystanie z AI Toolkit](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testowanie serwera** | Testowanie jest ważnym elementem procesu rozwoju. Ta sekcja pomoże Ci testować serwer przy użyciu różnych narzędzi | [Testowanie serwera](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Wdrażanie serwera** | Jak przejść od lokalnego rozwoju do produkcji? Ta sekcja pomoże Ci rozwinąć i wdrożyć serwer | [Wdrażanie serwera](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Praktyczna implementacja** | Korzystanie z SDK w różnych językach, debugowanie, testowanie i walidacja, tworzenie wielokrotnego użytku szablonów promptów i workflowów | [Praktyczna implementacja](./04-PracticalImplementation/README.md) |
| 05 | **Zaawansowane tematy MCP** | Wielomodalne workflow AI i rozszerzalność, bezpieczne strategie skalowania, MCP w ekosystemach korporacyjnych | [Zaawansowane tematy](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracja MCP z Azure** | Prezentacja integracji z Azure | [Integracja MCP z Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Wielomodalność** | Pokazuje, jak pracować z różnymi modalnościami, takimi jak obrazy i inne | [Wielomodalność](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **Demo MCP OAuth2** | Minimalna aplikacja Spring Boot pokazująca OAuth2 z MCP, zarówno jako Authorization, jak i Resource Server. Demonstruje bezpieczne wydawanie tokenów, chronione endpointy, wdrożenie w Azure Container Apps oraz integrację z API Management | [Demo MCP OAuth2](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Dowiedz się więcej o root context i jak je implementować | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Poznaj różne typy routingu | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naucz się pracy z samplingiem | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skalowanie** | Dowiedz się o skalowaniu serwerów MCP, w tym o strategiach skalowania horyzontalnego i wertykalnego, optymalizacji zasobów oraz tuningu wydajności | [Skalowanie](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Bezpieczeństwo** | Zabezpiecz swój serwer MCP, w tym strategie uwierzytelniania, autoryzacji i ochrony danych | [Bezpieczeństwo](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Serwer i klient MCP w Pythonie integrujący się z SerpAPI do wyszukiwania w czasie rzeczywistym w sieci, wiadomościach, produktach oraz Q&A. Demonstruje orkiestrację wielu narzędzi, integrację z zewnętrznymi API oraz solidne obsługiwanie błędów | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Realtime Streaming** | Strumieniowanie danych w czasie rzeczywistym stało się niezbędne w dzisiejszym świecie opartym na danych, gdzie firmy i aplikacje potrzebują natychmiastowego dostępu do informacji, aby podejmować szybkie decyzje | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Realtime Web Search** | Jak MCP zmienia wyszukiwanie w czasie rzeczywistym, oferując ustandaryzowane podejście do zarządzania kontekstem między modelami AI, wyszukiwarkami i aplikacjami | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Wkład społeczności** | Jak wnosić kod i dokumentację, współpracować przez GitHub, społecznościowe ulepszenia i feedback | [Wkład społeczności](./06-CommunityContributions/README.md) |
| 07 | **Wnioski z wczesnej adopcji** | Praktyczne wdrożenia i co się sprawdziło, tworzenie i wdrażanie rozwiązań opartych na MCP, trendy i przyszła mapa drogowa | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najlepsze praktyki dla MCP** | Optymalizacja wydajności, projektowanie odpornych systemów MCP, strategie testowania i odporności | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Studia przypadków MCP** | Szczegółowe analizy architektur rozwiązań MCP, plany wdrożeń i wskazówki dotyczące integracji, opatrzone komentarzami diagramy i omówienia projektów | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Usprawnianie przepływów AI: budowa serwera MCP z AI Toolkit** | Kompleksowe warsztaty praktyczne łączące MCP z AI Toolkit Microsoftu dla VS Code. Naucz się tworzyć inteligentne aplikacje łączące modele AI z narzędziami rzeczywistymi poprzez praktyczne moduły obejmujące podstawy, tworzenie niestandardowego serwera i strategie wdrożenia produkcyjnego. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

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

Aby w pełni wykorzystać ten materiał, powinieneś mieć:

- Podstawową znajomość C#, Java lub Python  
- Zrozumienie modelu klient-serwer oraz API  
- (Opcjonalnie) Znajomość podstaw uczenia maszynowego  

## 📚 Przewodnik nauki

Dostępny jest obszerny [Przewodnik nauki](./study_guide.md), który pomoże Ci efektywnie poruszać się po tym repozytorium. Przewodnik zawiera:

- Wizualną mapę programu obejmującą wszystkie tematy  
- Szczegółowy podział każdej sekcji repozytorium  
- Wskazówki, jak korzystać z przykładowych projektów  
- Rekomendowane ścieżki nauki dla różnych poziomów zaawansowania  
- Dodatkowe zasoby wspierające Twoją naukę  

## 🛠️ Jak efektywnie korzystać z tego programu nauczania

Każda lekcja w tym przewodniku zawiera:

1. Jasne wyjaśnienia koncepcji MCP  
2. Przykłady kodu na żywo w różnych językach  
3. Ćwiczenia do tworzenia rzeczywistych aplikacji MCP  
4. Dodatkowe materiały dla zaawansowanych  

## 📜 Informacje o licencji

Ta zawartość jest udostępniona na licencji **MIT License**. Warunki licencji znajdziesz w pliku [LICENSE](../../LICENSE).

## 🤝 Zasady współpracy

Ten projekt chętnie przyjmuje wkład i sugestie. Większość wkładów wymaga zaakceptowania
Contributor License Agreement (CLA), w którym deklarujesz, że masz prawo i rzeczywiście udzielasz
nam praw do korzystania z Twojego wkładu. Szczegóły znajdziesz na <https://cla.opensource.microsoft.com>.

Po przesłaniu pull requesta, bot CLA automatycznie sprawdzi, czy musisz dostarczyć
CLA i odpowiednio oznaczy PR (np. kontrola statusu, komentarz). Wystarczy, że wykonasz
instrukcje podane przez bota. Robisz to tylko raz dla wszystkich repozytoriów korzystających z naszego CLA.

Projekt przyjął [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
Więcej informacji znajdziesz w [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) lub
kontaktując się pod adresem [opencode@microsoft.com](mailto:opencode@microsoft.com) w razie dodatkowych pytań lub uwag.

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
- [Opanowanie GitHub Copilot do wspólnego programowania AI](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Opanowanie GitHub Copilot dla programistów C#/.NET](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Wybierz swoją własną przygodę z Copilotem](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Informacja o znaku towarowym

Ten projekt może zawierać znaki towarowe lub logotypy projektów, produktów lub usług. Autoryzowane użycie znaków towarowych lub logotypów Microsoft musi być zgodne z
[Wytycznymi Microsoft dotyczącymi znaków towarowych i marki](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Użycie znaków towarowych lub logotypów Microsoft w zmodyfikowanych wersjach tego projektu nie może wprowadzać w błąd ani sugerować sponsorowania przez Microsoft.
Wszelkie użycie znaków towarowych lub logotypów stron trzecich podlega politykom tych stron.

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy pamiętać, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło wiarygodne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.