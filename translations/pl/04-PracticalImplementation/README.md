<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-16T15:36:33+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "pl"
}
-->
# Praktyczna implementacja

Praktyczna implementacja to moment, w którym moc Model Context Protocol (MCP) staje się namacalna. Choć zrozumienie teorii i architektury MCP jest ważne, prawdziwa wartość pojawia się, gdy zastosujesz te koncepcje do budowy, testowania i wdrażania rozwiązań rozwiązujących rzeczywiste problemy. Ten rozdział łączy wiedzę koncepcyjną z praktycznym rozwojem, prowadząc Cię przez proces tworzenia aplikacji opartych na MCP.

Niezależnie od tego, czy tworzysz inteligentnych asystentów, integrujesz AI z procesami biznesowymi, czy budujesz niestandardowe narzędzia do przetwarzania danych, MCP zapewnia elastyczną podstawę. Jego niezależny od języka projekt oraz oficjalne SDK dla popularnych języków programowania sprawiają, że jest dostępny dla szerokiego grona deweloperów. Wykorzystując te SDK, możesz szybko prototypować, iterować i skalować swoje rozwiązania na różnych platformach i środowiskach.

W kolejnych sekcjach znajdziesz praktyczne przykłady, przykładowy kod i strategie wdrażania, które pokażą, jak implementować MCP w C#, Java, TypeScript, JavaScript i Python. Dowiesz się także, jak debugować i testować serwery MCP, zarządzać API oraz wdrażać rozwiązania w chmurze za pomocą Azure. Te praktyczne materiały mają przyspieszyć Twoją naukę i pomóc pewnie budować solidne, gotowe do produkcji aplikacje MCP.

## Przegląd

Ta lekcja skupia się na praktycznych aspektach implementacji MCP w różnych językach programowania. Poznamy, jak używać MCP SDK w C#, Java, TypeScript, JavaScript i Python, aby tworzyć solidne aplikacje, debugować i testować serwery MCP oraz tworzyć wielokrotnego użytku zasoby, prompt’y i narzędzia.

## Cele nauki

Po zakończeniu tej lekcji będziesz potrafił:
- Implementować rozwiązania MCP korzystając z oficjalnych SDK w różnych językach programowania
- Systematycznie debugować i testować serwery MCP
- Tworzyć i używać funkcji serwera (Resources, Prompts i Tools)
- Projektować efektywne workflow MCP dla złożonych zadań
- Optymalizować implementacje MCP pod kątem wydajności i niezawodności

## Oficjalne SDK

Model Context Protocol oferuje oficjalne SDK dla wielu języków:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Praca z MCP SDK

Ta sekcja zawiera praktyczne przykłady implementacji MCP w różnych językach programowania. Przykładowy kod znajdziesz w katalogu `samples`, uporządkowanym według języka.

### Dostępne przykłady

Repozytorium zawiera przykłady implementacji w następujących językach:

- C#
- Java
- TypeScript
- JavaScript
- Python

Każdy przykład demonstruje kluczowe koncepcje MCP oraz wzorce implementacyjne dla danego języka i ekosystemu.

## Podstawowe funkcje serwera

Serwery MCP mogą implementować dowolne połączenie następujących funkcji:

### Resources
Resources dostarczają kontekst i dane do wykorzystania przez użytkownika lub model AI:
- Repozytoria dokumentów
- Bazy wiedzy
- Strukturalne źródła danych
- Systemy plików

### Prompts
Prompts to szablonowe wiadomości i workflow dla użytkowników:
- Zdefiniowane wcześniej szablony konwersacji
- Wzorce prowadzonej interakcji
- Specjalistyczne struktury dialogowe

### Tools
Tools to funkcje, które model AI może wykonać:
- Narzędzia do przetwarzania danych
- Integracje z zewnętrznymi API
- Możliwości obliczeniowe
- Funkcje wyszukiwania

## Przykładowe implementacje: C#

Oficjalne repozytorium C# SDK zawiera kilka przykładów pokazujących różne aspekty MCP:

- **Basic MCP Client**: Prosty przykład pokazujący, jak stworzyć klienta MCP i wywołać narzędzia
- **Basic MCP Server**: Minimalna implementacja serwera z podstawową rejestracją narzędzi
- **Advanced MCP Server**: Serwer pełnej funkcjonalności z rejestracją narzędzi, uwierzytelnianiem i obsługą błędów
- **ASP.NET Integration**: Przykłady integracji z ASP.NET Core
- **Tool Implementation Patterns**: Różne wzorce implementacji narzędzi o różnym poziomie złożoności

SDK MCP dla C# jest w wersji preview i API mogą ulec zmianie. Będziemy na bieżąco aktualizować ten blog w miarę rozwoju SDK.

### Kluczowe funkcje
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Budowa [pierwszego serwera MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pełne przykłady implementacji w C# znajdziesz w [oficjalnym repozytorium SDK C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Przykładowa implementacja: Java

SDK Java oferuje solidne opcje implementacji MCP z funkcjami klasy enterprise.

### Kluczowe funkcje

- Integracja ze Spring Framework
- Silne typowanie
- Wsparcie dla programowania reaktywnego
- Kompleksowa obsługa błędów

Pełny przykład implementacji w Javie znajdziesz w pliku [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) w katalogu samples.

## Przykładowa implementacja: JavaScript

SDK JavaScript zapewnia lekkie i elastyczne podejście do implementacji MCP.

### Kluczowe funkcje

- Wsparcie dla Node.js i przeglądarki
- API oparte na Promise
- Łatwa integracja z Express i innymi frameworkami
- Wsparcie WebSocket do strumieniowania

Pełny przykład implementacji w JavaScript znajdziesz w pliku [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) w katalogu samples.

## Przykładowa implementacja: Python

SDK Python oferuje pythoniczne podejście do implementacji MCP z doskonałą integracją z frameworkami ML.

### Kluczowe funkcje

- Wsparcie async/await z asyncio
- Integracja z Flask i FastAPI
- Prosta rejestracja narzędzi
- Natychmiastowa integracja z popularnymi bibliotekami ML

Pełny przykład implementacji w Pythonie znajdziesz w pliku [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) w katalogu samples.

## Zarządzanie API

Azure API Management to świetne rozwiązanie, które pozwala zabezpieczyć serwery MCP. Pomysł polega na umieszczeniu instancji Azure API Management przed serwerem MCP, która obsłuży funkcje, które prawdopodobnie będziesz chciał mieć, takie jak:

- ograniczanie liczby żądań (rate limiting)
- zarządzanie tokenami
- monitorowanie
- balansowanie obciążenia
- bezpieczeństwo

### Przykład Azure

Oto przykład Azure robiący dokładnie to, czyli [tworzenie serwera MCP i zabezpieczanie go za pomocą Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Na poniższym obrazku widać, jak przebiega proces autoryzacji:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na powyższym obrazku dzieje się następujące:

- Autentykacja/autoryzacja odbywa się przy użyciu Microsoft Entra.
- Azure API Management działa jako brama i wykorzystuje polityki do kierowania i zarządzania ruchem.
- Azure Monitor loguje wszystkie żądania do dalszej analizy.

#### Przebieg autoryzacji

Przyjrzyjmy się dokładniej przebiegowi autoryzacji:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specyfikacja autoryzacji MCP

Dowiedz się więcej o [specyfikacji autoryzacji MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Wdrażanie zdalnego serwera MCP na Azure

Sprawdźmy, czy możemy wdrożyć wcześniej wspomniany przykład:

1. Sklonuj repozytorium

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Zarejestruj `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` i po pewnym czasie sprawdź, czy rejestracja jest zakończona.

3. Uruchom polecenie [azd](https://aka.ms/azd), aby utworzyć usługę zarządzania API, aplikację funkcji (z kodem) oraz wszystkie inne wymagane zasoby Azure

    ```shell
    azd up
    ```

    To polecenie powinno wdrożyć wszystkie zasoby chmurowe na Azure

### Testowanie serwera za pomocą MCP Inspector

1. W **nowym oknie terminala** zainstaluj i uruchom MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Powinieneś zobaczyć interfejs podobny do:

    ![Connect to Node inspector](../../../translated_images/connect.9f4ccffc595d24b85ce22579ddf26016b5f21d941d544568c1b9752a51d0a4b1.pl.png)

2. Kliknij CTRL i otwórz aplikację webową MCP Inspector z wyświetlonego adresu URL (np. http://127.0.0.1:6274/#resources)
3. Ustaw typ transportu na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` i **Połącz**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Wyświetl listę narzędzi**. Kliknij na narzędzie i wybierz **Run Tool**.

Jeśli wszystkie kroki zostały wykonane poprawnie, powinieneś być teraz połączony z serwerem MCP i móc wywołać narzędzie.

## Serwery MCP dla Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Zestaw repozytoriów stanowiących szablon szybkiego startu do budowy i wdrażania niestandardowych zdalnych serwerów MCP (Model Context Protocol) z użyciem Azure Functions w Python, C# .NET lub Node/TypeScript.

Przykłady dostarczają kompletne rozwiązanie, które pozwala deweloperom:

- Budować i uruchamiać lokalnie: rozwijać i debugować serwer MCP na lokalnej maszynie
- Wdrażać na Azure: łatwo wdrażać do chmury za pomocą prostego polecenia azd up
- Łączyć się z klientami: łączyć się z serwerem MCP z różnych klientów, w tym trybu agenta Copilot w VS Code oraz narzędzia MCP Inspector

### Kluczowe funkcje:

- Bezpieczeństwo wbudowane w projekt: serwer MCP zabezpieczony kluczami i HTTPS
- Opcje uwierzytelniania: wsparcie OAuth z wbudowanym auth i/lub API Management
- Izolacja sieciowa: umożliwia izolację sieci za pomocą Azure Virtual Networks (VNET)
- Architektura bezserwerowa: wykorzystuje Azure Functions do skalowalnego, zdarzeniowego wykonania
- Lokalny rozwój: kompleksowe wsparcie dla lokalnego rozwoju i debugowania
- Proste wdrażanie: usprawniony proces wdrażania na Azure

Repozytorium zawiera wszystkie niezbędne pliki konfiguracyjne, kod źródłowy i definicje infrastruktury, aby szybko rozpocząć implementację serwera MCP gotowego do produkcji.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Przykładowa implementacja MCP z użyciem Azure Functions i Pythona

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Przykładowa implementacja MCP z użyciem Azure Functions i C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Przykładowa implementacja MCP z użyciem Azure Functions i Node/TypeScript

## Najważniejsze wnioski

- SDK MCP dostarczają narzędzia specyficzne dla języków do implementacji solidnych rozwiązań MCP
- Proces debugowania i testowania jest kluczowy dla niezawodnych aplikacji MCP
- Szablony promptów umożliwiają spójne interakcje z AI
- Dobrze zaprojektowane workflow mogą orkiestrują złożone zadania wykorzystując wiele narzędzi
- Implementacja MCP wymaga uwzględnienia kwestii bezpieczeństwa, wydajności i obsługi błędów

## Ćwiczenie

Zaprojektuj praktyczny workflow MCP, który rozwiązuje rzeczywisty problem w Twojej dziedzinie:

1. Zidentyfikuj 3-4 narzędzia, które byłyby przydatne do rozwiązania tego problemu
2. Stwórz diagram workflow pokazujący, jak te narzędzia ze sobą współpracują
3. Zaimplementuj podstawową wersję jednego z narzędzi w wybranym przez siebie języku
4. Stwórz szablon promptu, który pomoże modelowi efektywnie korzystać z Twojego narzędzia

## Dodatkowe zasoby


---

Następny: [Zaawansowane tematy](../05-AdvancedTopics/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy pamiętać, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być uważany za źródło wiążące. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.