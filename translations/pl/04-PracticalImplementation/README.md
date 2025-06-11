<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:13:02+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "pl"
}
-->
# Praktyczna implementacja

Praktyczna implementacja to moment, w którym moc Model Context Protocol (MCP) staje się namacalna. Choć zrozumienie teorii i architektury stojącej za MCP jest ważne, prawdziwa wartość pojawia się, gdy zastosujesz te koncepcje do budowy, testowania i wdrażania rozwiązań rozwiązujących rzeczywiste problemy. Ten rozdział łączy wiedzę koncepcyjną z praktycznym rozwojem, prowadząc Cię przez proces tworzenia aplikacji opartych na MCP.

Niezależnie od tego, czy tworzysz inteligentnych asystentów, integrujesz AI w procesy biznesowe, czy budujesz niestandardowe narzędzia do przetwarzania danych, MCP zapewnia elastyczną podstawę. Jego językowo-neutralna konstrukcja oraz oficjalne SDK dla popularnych języków programowania sprawiają, że jest dostępny dla szerokiego grona deweloperów. Wykorzystując te SDK, możesz szybko prototypować, iterować i skalować swoje rozwiązania na różnych platformach i środowiskach.

W kolejnych sekcjach znajdziesz praktyczne przykłady, fragmenty kodu oraz strategie wdrażania pokazujące, jak zaimplementować MCP w C#, Java, TypeScript, JavaScript i Python. Nauczysz się także, jak debugować i testować serwery MCP, zarządzać API oraz wdrażać rozwiązania w chmurze za pomocą Azure. Te praktyczne materiały mają na celu przyspieszyć Twoją naukę i pomóc Ci pewnie budować solidne, gotowe do produkcji aplikacje MCP.

## Przegląd

Ta lekcja koncentruje się na praktycznych aspektach implementacji MCP w różnych językach programowania. Omówimy, jak korzystać z MCP SDK w C#, Java, TypeScript, JavaScript i Python, aby tworzyć solidne aplikacje, debugować i testować serwery MCP oraz tworzyć wielokrotnego użytku zasoby, prompt’y i narzędzia.

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

Ta sekcja zawiera praktyczne przykłady implementacji MCP w różnych językach programowania. Przykładowy kod znajdziesz w katalogu `samples`, uporządkowany według języków.

### Dostępne przykłady

Repozytorium zawiera przykładowe implementacje w następujących językach:

- C#
- Java
- TypeScript
- JavaScript
- Python

Każdy przykład demonstruje kluczowe koncepcje MCP oraz wzorce implementacyjne dla danego języka i ekosystemu.

## Podstawowe funkcje serwera

Serwery MCP mogą implementować dowolną kombinację poniższych funkcji:

### Resources  
Resources dostarczają kontekst i dane dla użytkownika lub modelu AI do wykorzystania:
- Repozytoria dokumentów
- Bazy wiedzy
- Źródła danych strukturalnych
- Systemy plików

### Prompts  
Prompts to szablony wiadomości i workflow dla użytkowników:
- Zdefiniowane szablony rozmów
- Wzorce interakcji prowadzonej
- Specjalistyczne struktury dialogu

### Tools  
Tools to funkcje, które model AI może wykonać:
- Narzędzia do przetwarzania danych
- Integracje z zewnętrznymi API
- Możliwości obliczeniowe
- Funkcje wyszukiwania

## Przykładowe implementacje: C#

Oficjalne repozytorium C# SDK zawiera kilka przykładów implementacji pokazujących różne aspekty MCP:

- **Basic MCP Client**: Prosty przykład tworzenia klienta MCP i wywoływania narzędzi
- **Basic MCP Server**: Minimalna implementacja serwera z podstawową rejestracją narzędzi
- **Advanced MCP Server**: Pełna funkcjonalność serwera z rejestracją narzędzi, uwierzytelnianiem i obsługą błędów
- **Integracja z ASP.NET**: Przykłady integracji z ASP.NET Core
- **Wzorce implementacji narzędzi**: Różne wzorce implementacji narzędzi o różnym stopniu złożoności

SDK MCP dla C# jest w fazie podglądu i API mogą ulec zmianie. Będziemy na bieżąco aktualizować ten blog wraz z rozwojem SDK.

### Kluczowe funkcje  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Budowanie [pierwszego MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pełne przykłady implementacji w C# znajdziesz w [oficjalnym repozytorium przykładów C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Przykładowa implementacja: Java

Java SDK oferuje solidne opcje implementacji MCP z funkcjami na poziomie korporacyjnym.

### Kluczowe funkcje

- Integracja ze Spring Framework
- Silne typowanie
- Wsparcie programowania reaktywnego
- Kompleksowa obsługa błędów

Pełny przykład implementacji w Javie znajdziesz w pliku [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) w katalogu samples.

## Przykładowa implementacja: JavaScript

JavaScript SDK zapewnia lekkie i elastyczne podejście do implementacji MCP.

### Kluczowe funkcje

- Wsparcie Node.js i przeglądarek
- API oparte na Promise
- Łatwa integracja z Express i innymi frameworkami
- Wsparcie WebSocket do streamingu

Pełny przykład implementacji w JavaScript znajdziesz w pliku [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) w katalogu samples.

## Przykładowa implementacja: Python

Python SDK oferuje „pythoniczne” podejście do implementacji MCP z doskonałą integracją z frameworkami ML.

### Kluczowe funkcje

- Wsparcie async/await z asyncio
- Integracja z Flask i FastAPI
- Prosta rejestracja narzędzi
- Natychmiastowa integracja z popularnymi bibliotekami ML

Pełny przykład implementacji w Pythonie znajdziesz w pliku [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) w katalogu samples.

## Zarządzanie API

Azure API Management to świetne rozwiązanie, które pozwala zabezpieczyć serwery MCP. Idea polega na umieszczeniu instancji Azure API Management przed Twoim serwerem MCP i pozwoleniu jej na obsługę funkcji, które mogą Ci się przydać, takich jak:

- ograniczanie liczby żądań (rate limiting)
- zarządzanie tokenami
- monitorowanie
- równoważenie obciążenia
- bezpieczeństwo

### Przykład Azure

Oto przykład Azure, który robi dokładnie to, czyli [tworzy serwer MCP i zabezpiecza go za pomocą Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Zobacz, jak przebiega przepływ autoryzacji na poniższym obrazku:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na powyższym obrazku dzieje się:

- Uwierzytelnianie/autoryzacja odbywa się za pomocą Microsoft Entra.
- Azure API Management działa jako brama i wykorzystuje polityki do kierowania i zarządzania ruchem.
- Azure Monitor rejestruje wszystkie żądania do dalszej analizy.

#### Przepływ autoryzacji

Przyjrzyjmy się przepływowi autoryzacji bardziej szczegółowo:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specyfikacja autoryzacji MCP

Dowiedz się więcej o [specyfikacji autoryzacji MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Wdrażanie zdalnego serwera MCP na Azure

Sprawdźmy, czy możemy wdrożyć wspomniany wcześniej przykład:

1. Sklonuj repozytorium

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Zarejestruj `Microsoft.App`  
   ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `  
   `. Then run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `  
   Po chwili sprawdź stan rejestracji poleceniem `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`.

3. Uruchom to polecenie [azd](https://aka.ms/azd), aby utworzyć usługę API Management, aplikację funkcji (z kodem) oraz wszystkie inne potrzebne zasoby Azure

    ```shell
    azd up
    ```

    To polecenie powinno wdrożyć wszystkie zasoby w chmurze Azure.

### Testowanie serwera za pomocą MCP Inspector

1. W **nowym oknie terminala** zainstaluj i uruchom MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Powinieneś zobaczyć interfejs podobny do:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pl.png) 

2. CTRL kliknij, aby załadować aplikację webową MCP Inspector z adresu URL wyświetlonego przez aplikację (np. http://127.0.0.1:6274/#resources)
3. Ustaw typ transportu na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` i kliknij **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. Kliknij na narzędzie i wybierz **Run Tool**.  

Jeśli wszystkie kroki zakończyły się powodzeniem, powinieneś być teraz połączony z serwerem MCP i móc wywołać narzędzie.

## Serwery MCP dla Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ten zestaw repozytoriów to szablon szybkiego startu do budowy i wdrażania niestandardowych zdalnych serwerów MCP (Model Context Protocol) wykorzystujących Azure Functions w Pythonie, C# .NET lub Node/TypeScript.

Przykłady zapewniają kompletne rozwiązanie, które pozwala programistom:

- Budować i uruchamiać lokalnie: rozwijać i debugować serwer MCP na lokalnej maszynie
- Wdrażać na Azure: łatwo wdrażać w chmurze za pomocą prostego polecenia azd up
- Łączyć się z klientami: łączyć się z serwerem MCP z różnych klientów, w tym trybu agenta Copilot w VS Code oraz narzędzia MCP Inspector

### Kluczowe funkcje:

- Bezpieczeństwo od podstaw: serwer MCP zabezpieczony za pomocą kluczy i HTTPS
- Opcje uwierzytelniania: wsparcie OAuth z wbudowanym auth i/lub API Management
- Izolacja sieciowa: możliwość izolacji sieciowej za pomocą Azure Virtual Networks (VNET)
- Architektura serverless: wykorzystanie Azure Functions dla skalowalnego, zdarzeniowego wykonania
- Lokalny rozwój: kompleksowe wsparcie lokalnego rozwoju i debugowania
- Proste wdrożenie: usprawniony proces wdrażania na Azure

Repozytorium zawiera wszystkie niezbędne pliki konfiguracyjne, kod źródłowy i definicje infrastruktury, aby szybko rozpocząć implementację serwera MCP gotowego do produkcji.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Przykładowa implementacja MCP z użyciem Azure Functions w Pythonie

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Przykładowa implementacja MCP z użyciem Azure Functions w C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Przykładowa implementacja MCP z użyciem Azure Functions w Node/TypeScript.

## Najważniejsze wnioski

- SDK MCP dostarczają narzędzia specyficzne dla języka do tworzenia solidnych rozwiązań MCP
- Proces debugowania i testowania jest kluczowy dla niezawodnych aplikacji MCP
- Wielokrotnego użytku szablony promptów umożliwiają spójne interakcje z AI
- Dobrze zaprojektowane workflow mogą orkiestrując złożone zadania z wykorzystaniem wielu narzędzi
- Implementacja MCP wymaga uwzględnienia kwestii bezpieczeństwa, wydajności i obsługi błędów

## Ćwiczenie

Zaprojektuj praktyczne workflow MCP, które rozwiązuje rzeczywisty problem z Twojej dziedziny:

1. Wybierz 3-4 narzędzia, które byłyby przydatne do rozwiązania tego problemu
2. Stwórz diagram workflow pokazujący, jak te narzędzia ze sobą współpracują
3. Zaimplementuj podstawową wersję jednego z narzędzi w wybranym języku
4. Stwórz szablon promptu, który pomoże modelowi efektywnie korzystać z Twojego narzędzia

## Dodatkowe zasoby


---

Następny: [Zaawansowane tematy](../05-AdvancedTopics/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego języku źródłowym powinien być uznawany za autorytatywne źródło. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.