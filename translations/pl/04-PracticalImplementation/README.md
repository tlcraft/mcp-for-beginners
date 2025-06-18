<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:04:58+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "pl"
}
-->
# Praktyczna implementacja

Praktyczna implementacja to moment, w którym moc Model Context Protocol (MCP) staje się namacalna. Chociaż zrozumienie teorii i architektury MCP jest ważne, prawdziwa wartość pojawia się, gdy zastosujesz te koncepcje do budowy, testowania i wdrażania rozwiązań rozwiązujących rzeczywiste problemy. Ten rozdział łączy wiedzę koncepcyjną z praktycznym programowaniem, prowadząc Cię przez proces tworzenia aplikacji opartych na MCP.

Niezależnie od tego, czy tworzysz inteligentnych asystentów, integrujesz AI z procesami biznesowymi, czy budujesz niestandardowe narzędzia do przetwarzania danych, MCP zapewnia elastyczną podstawę. Jego niezależna od języka konstrukcja oraz oficjalne SDK dla popularnych języków programowania sprawiają, że jest dostępny dla szerokiego grona deweloperów. Wykorzystując te SDK, możesz szybko prototypować, iterować i skalować swoje rozwiązania na różnych platformach i środowiskach.

W kolejnych sekcjach znajdziesz praktyczne przykłady, przykładowy kod oraz strategie wdrożenia pokazujące, jak zaimplementować MCP w C#, Javie, TypeScript, JavaScript oraz Pythonie. Nauczysz się również, jak debugować i testować serwery MCP, zarządzać API oraz wdrażać rozwiązania w chmurze za pomocą Azure. Te praktyczne materiały mają na celu przyspieszyć Twoją naukę i pomóc Ci pewnie tworzyć solidne, gotowe do produkcji aplikacje MCP.

## Przegląd

Ta lekcja koncentruje się na praktycznych aspektach implementacji MCP w różnych językach programowania. Poznamy, jak korzystać z MCP SDK w C#, Javie, TypeScript, JavaScript oraz Pythonie, aby budować solidne aplikacje, debugować i testować serwery MCP oraz tworzyć wielokrotnego użytku zasoby, prompt’y i narzędzia.

## Cele nauki

Po zakończeniu tej lekcji będziesz potrafił:
- Implementować rozwiązania MCP z użyciem oficjalnych SDK w różnych językach programowania
- Systematycznie debugować i testować serwery MCP
- Tworzyć i wykorzystywać funkcje serwera (Resources, Prompts i Tools)
- Projektować efektywne workflow MCP dla złożonych zadań
- Optymalizować implementacje MCP pod kątem wydajności i niezawodności

## Oficjalne zasoby SDK

Model Context Protocol oferuje oficjalne SDK dla wielu języków:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Praca z MCP SDK

Ta sekcja zawiera praktyczne przykłady implementacji MCP w różnych językach programowania. Przykładowy kod znajdziesz w katalogu `samples` zorganizowanym według języków.

### Dostępne przykłady

Repozytorium zawiera [przykładowe implementacje](../../../04-PracticalImplementation/samples) w następujących językach:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Każdy przykład pokazuje kluczowe koncepcje MCP i wzorce implementacyjne dla danego języka i ekosystemu.

## Główne funkcje serwera

Serwery MCP mogą implementować dowolne kombinacje następujących funkcji:

### Resources  
Resources dostarczają kontekst i dane do wykorzystania przez użytkownika lub model AI:  
- Repozytoria dokumentów  
- Bazy wiedzy  
- Strukturalne źródła danych  
- Systemy plików  

### Prompts  
Prompts to szablonowe komunikaty i workflow dla użytkowników:  
- Wstępnie zdefiniowane szablony konwersacji  
- Wzorce prowadzonej interakcji  
- Specjalistyczne struktury dialogowe  

### Tools  
Tools to funkcje wykonywane przez model AI:  
- Narzędzia do przetwarzania danych  
- Integracje z zewnętrznymi API  
- Możliwości obliczeniowe  
- Funkcje wyszukiwania  

## Przykładowe implementacje: C#

Oficjalne repozytorium C# SDK zawiera kilka przykładów pokazujących różne aspekty MCP:

- **Basic MCP Client**: Prosty przykład tworzenia klienta MCP i wywoływania narzędzi  
- **Basic MCP Server**: Minimalna implementacja serwera z podstawową rejestracją narzędzi  
- **Advanced MCP Server**: Pełna funkcjonalność serwera z rejestracją narzędzi, uwierzytelnianiem i obsługą błędów  
- **Integracja z ASP.NET**: Przykłady integracji z ASP.NET Core  
- **Wzorce implementacji narzędzi**: Różne wzorce implementacji narzędzi o różnym poziomie złożoności  

MCP C# SDK jest w fazie podglądowej, więc API mogą ulec zmianie. Będziemy na bieżąco aktualizować ten blog wraz z rozwojem SDK.

### Kluczowe funkcje  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Budowanie [pierwszego serwera MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pełne przykłady implementacji w C# znajdziesz w [oficjalnym repozytorium SDK C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Przykładowa implementacja: Java

Java SDK oferuje solidne opcje implementacji MCP z funkcjami klasy enterprise.

### Kluczowe funkcje

- Integracja ze Spring Framework  
- Silna kontrola typów  
- Wsparcie dla programowania reaktywnego  
- Kompleksowa obsługa błędów  

Pełny przykład implementacji w Javie znajdziesz w pliku [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) w katalogu samples.

## Przykładowa implementacja: JavaScript

JavaScript SDK zapewnia lekkie i elastyczne podejście do implementacji MCP.

### Kluczowe funkcje

- Wsparcie dla Node.js i przeglądarek  
- API oparte na Promise  
- Łatwa integracja z Express i innymi frameworkami  
- Wsparcie WebSocket do streamingu  

Pełny przykład implementacji w JavaScript znajdziesz w pliku [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) w katalogu samples.

## Przykładowa implementacja: Python

Python SDK oferuje pythoniczne podejście do implementacji MCP z doskonałą integracją z frameworkami ML.

### Kluczowe funkcje

- Wsparcie async/await z asyncio  
- Integracja z Flask i FastAPI  
- Prosta rejestracja narzędzi  
- Natychmiastowa integracja z popularnymi bibliotekami ML  

Pełny przykład implementacji w Pythonie znajdziesz w pliku [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) w katalogu samples.

## Zarządzanie API

Azure API Management to doskonałe rozwiązanie, aby zabezpieczyć serwery MCP. Pomysł polega na umieszczeniu instancji Azure API Management przed serwerem MCP, która zajmie się funkcjami, które prawdopodobnie będą potrzebne, takimi jak:

- ograniczanie liczby żądań (rate limiting)  
- zarządzanie tokenami  
- monitorowanie  
- równoważenie obciążenia  
- bezpieczeństwo  

### Przykład Azure

Oto przykład Azure realizujący dokładnie to, czyli [tworzenie serwera MCP i zabezpieczenie go za pomocą Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Zobacz, jak przebiega proces autoryzacji na poniższym obrazku:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na powyższym obrazku dzieje się:

- Uwierzytelnianie/autoryzacja odbywa się przy użyciu Microsoft Entra.  
- Azure API Management działa jako brama i wykorzystuje polityki do kierowania i zarządzania ruchem.  
- Azure Monitor rejestruje wszystkie żądania do dalszej analizy.  

#### Przebieg autoryzacji

Przyjrzyjmy się dokładniej przebiegowi autoryzacji:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specyfikacja autoryzacji MCP

Dowiedz się więcej o [specyfikacji autoryzacji MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Wdrażanie zdalnego serwera MCP na Azure

Sprawdźmy, czy uda nam się wdrożyć wcześniej wspomniany przykład:

1. Sklonuj repozytorium

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Zarejestruj `Microsoft.App`  
    ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `  
    lub  
    Register-AzResourceProvider -ProviderNamespace Microsoft.App  
    `. Then run `  
    Po chwili sprawdź, czy rejestracja została zakończona komendą:  
    (Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState

3. Uruchom polecenie [azd](https://aka.ms/azd), aby utworzyć usługę zarządzania API, aplikację funkcji (z kodem) oraz wszystkie inne wymagane zasoby Azure

    ```shell
    azd up
    ```

    To polecenie powinno wdrożyć wszystkie zasoby chmurowe w Azure

### Testowanie serwera za pomocą MCP Inspector

1. W **nowym oknie terminala** zainstaluj i uruchom MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Powinieneś zobaczyć interfejs podobny do:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pl.png) 

2. Kliknij CTRL i załaduj aplikację webową MCP Inspector z wyświetlonego przez aplikację URL (np. http://127.0.0.1:6274/#resources)  
3. Ustaw typ transportu na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` i **Połącz**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lista narzędzi**. Kliknij na narzędzie i wybierz **Uruchom narzędzie**.

Jeśli wszystkie kroki przebiegły pomyślnie, powinieneś być połączony z serwerem MCP i móc wywołać narzędzie.

## Serwery MCP dla Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ten zestaw repozytoriów to szablony szybkiego startu do budowy i wdrażania niestandardowych zdalnych serwerów MCP (Model Context Protocol) za pomocą Azure Functions w Pythonie, C# .NET lub Node/TypeScript.

Przykłady zapewniają kompletne rozwiązanie, które pozwala programistom:

- Budować i uruchamiać lokalnie: rozwijać i debugować serwer MCP na lokalnej maszynie  
- Wdrażać do Azure: łatwo wdrażać w chmurze za pomocą prostego polecenia azd up  
- Łączyć się z klientami: łączyć się z serwerem MCP z różnych klientów, w tym z trybu agenta Copilot w VS Code oraz narzędzia MCP Inspector  

### Kluczowe cechy:

- Bezpieczeństwo od podstaw: serwer MCP jest zabezpieczony za pomocą kluczy i HTTPS  
- Opcje uwierzytelniania: wspiera OAuth z wbudowanym auth i/lub API Management  
- Izolacja sieciowa: umożliwia izolację sieciową za pomocą Azure Virtual Networks (VNET)  
- Architektura serverless: wykorzystuje Azure Functions do skalowalnego, zdarzeniowego wykonania  
- Lokalny rozwój: kompleksowe wsparcie lokalnego rozwoju i debugowania  
- Proste wdrożenie: uproszczony proces wdrażania do Azure  

Repozytorium zawiera wszystkie niezbędne pliki konfiguracyjne, kod źródłowy oraz definicje infrastruktury, aby szybko rozpocząć pracę z produkcyjną implementacją serwera MCP.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Przykładowa implementacja MCP z użyciem Azure Functions w Pythonie

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Przykładowa implementacja MCP z użyciem Azure Functions w C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Przykładowa implementacja MCP z użyciem Azure Functions w Node/TypeScript.

## Najważniejsze wnioski

- SDK MCP dostarczają narzędzia specyficzne dla języka do implementacji solidnych rozwiązań MCP  
- Proces debugowania i testowania jest kluczowy dla niezawodnych aplikacji MCP  
- Wielokrotnego użytku szablony promptów umożliwiają spójne interakcje z AI  
- Dobrze zaprojektowane workflow mogą orkiestracji złożone zadania wykorzystując wiele narzędzi  
- Implementacja rozwiązań MCP wymaga uwzględnienia bezpieczeństwa, wydajności i obsługi błędów  

## Ćwiczenie

Zaprojektuj praktyczny workflow MCP, który rozwiązuje rzeczywisty problem w Twojej dziedzinie:

1. Wybierz 3-4 narzędzia, które byłyby przydatne do rozwiązania tego problemu  
2. Stwórz diagram workflow pokazujący, jak te narzędzia ze sobą współpracują  
3. Zaimplementuj podstawową wersję jednego z narzędzi w wybranym przez siebie języku  
4. Stwórz szablon promptu, który pomoże modelowi skutecznie korzystać z Twojego narzędzia  

## Dodatkowe zasoby


---

Następny: [Zaawansowane tematy](../05-AdvancedTopics/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy traktować jako źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.