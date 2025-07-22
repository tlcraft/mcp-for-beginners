<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "20064351f7e0fa904e96b057ed742df3",
  "translation_date": "2025-07-22T08:55:17+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "pl"
}
-->
# Praktyczna Implementacja

Praktyczna implementacja to moment, w którym moc Model Context Protocol (MCP) staje się namacalna. Chociaż zrozumienie teorii i architektury MCP jest ważne, prawdziwa wartość ujawnia się, gdy zastosujesz te koncepcje do budowy, testowania i wdrażania rozwiązań rozwiązujących rzeczywiste problemy. Ten rozdział łączy wiedzę teoretyczną z praktycznym rozwojem, prowadząc Cię przez proces tworzenia aplikacji opartych na MCP.

Niezależnie od tego, czy tworzysz inteligentnych asystentów, integrujesz AI z procesami biznesowymi, czy budujesz niestandardowe narzędzia do przetwarzania danych, MCP zapewnia elastyczną podstawę. Jego niezależny od języka projekt oraz oficjalne SDK dla popularnych języków programowania sprawiają, że jest dostępny dla szerokiego grona programistów. Dzięki tym SDK możesz szybko prototypować, iterować i skalować swoje rozwiązania na różnych platformach i w różnych środowiskach.

W kolejnych sekcjach znajdziesz praktyczne przykłady, przykładowy kod i strategie wdrażania, które pokazują, jak zaimplementować MCP w językach C#, Java, TypeScript, JavaScript i Python. Dowiesz się również, jak debugować i testować serwery MCP, zarządzać API oraz wdrażać rozwiązania w chmurze za pomocą Azure. Te praktyczne zasoby zostały zaprojektowane, aby przyspieszyć Twoją naukę i pomóc Ci pewnie budować solidne, gotowe do produkcji aplikacje MCP.

## Przegląd

Ta lekcja koncentruje się na praktycznych aspektach implementacji MCP w różnych językach programowania. Omówimy, jak korzystać z SDK MCP w językach C#, Java, TypeScript, JavaScript i Python, aby budować solidne aplikacje, debugować i testować serwery MCP oraz tworzyć zasoby, szablony i narzędzia wielokrotnego użytku.

## Cele nauki

Po ukończeniu tej lekcji będziesz w stanie:

- Implementować rozwiązania MCP za pomocą oficjalnych SDK w różnych językach programowania
- Systematycznie debugować i testować serwery MCP
- Tworzyć i używać funkcji serwera (Zasoby, Szablony, Narzędzia)
- Projektować efektywne przepływy pracy MCP dla złożonych zadań
- Optymalizować implementacje MCP pod kątem wydajności i niezawodności

## Oficjalne zasoby SDK

Model Context Protocol oferuje oficjalne SDK dla wielu języków:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Praca z SDK MCP

Ta sekcja zawiera praktyczne przykłady implementacji MCP w różnych językach programowania. Przykładowy kod znajdziesz w katalogu `samples`, zorganizowanym według języka.

### Dostępne przykłady

Repozytorium zawiera [przykładowe implementacje](../../../04-PracticalImplementation/samples) w następujących językach:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Każdy przykład demonstruje kluczowe koncepcje MCP i wzorce implementacji dla danego języka i ekosystemu.

## Kluczowe funkcje serwera

Serwery MCP mogą implementować dowolną kombinację następujących funkcji:

### Zasoby

Zasoby dostarczają kontekstu i danych dla użytkownika lub modelu AI:

- Repozytoria dokumentów
- Bazy wiedzy
- Źródła danych strukturalnych
- Systemy plików

### Szablony

Szablony to predefiniowane wiadomości i przepływy pracy dla użytkowników:

- Wstępnie zdefiniowane szablony konwersacji
- Wzorce interakcji prowadzących
- Specjalistyczne struktury dialogowe

### Narzędzia

Narzędzia to funkcje, które model AI może wykonywać:

- Narzędzia do przetwarzania danych
- Integracje zewnętrznych API
- Funkcje obliczeniowe
- Funkcjonalność wyszukiwania

## Przykładowe implementacje: Implementacja w C#

Oficjalne repozytorium SDK C# zawiera kilka przykładów implementacji demonstrujących różne aspekty MCP:

- **Podstawowy klient MCP**: Prosty przykład pokazujący, jak utworzyć klienta MCP i wywoływać narzędzia
- **Podstawowy serwer MCP**: Minimalna implementacja serwera z podstawową rejestracją narzędzi
- **Zaawansowany serwer MCP**: Pełnoprawny serwer z rejestracją narzędzi, uwierzytelnianiem i obsługą błędów
- **Integracja z ASP.NET**: Przykłady demonstrujące integrację z ASP.NET Core
- **Wzorce implementacji narzędzi**: Różne wzorce implementacji narzędzi o różnym poziomie złożoności

SDK MCP dla C# jest w wersji zapoznawczej i API mogą ulec zmianie. Będziemy na bieżąco aktualizować ten blog w miarę rozwoju SDK.

### Kluczowe funkcje

- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)
- Budowanie swojego [pierwszego serwera MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pełne przykłady implementacji w C# znajdziesz w [oficjalnym repozytorium przykładów SDK C#](https://github.com/modelcontextprotocol/csharp-sdk).

## Przykładowa implementacja: Implementacja w Javie

SDK dla Javy oferuje solidne opcje implementacji MCP z funkcjami klasy enterprise.

### Kluczowe funkcje

- Integracja z Spring Framework
- Silne bezpieczeństwo typów
- Obsługa programowania reaktywnego
- Kompleksowa obsługa błędów

Pełny przykład implementacji w Javie znajdziesz w [przykładzie Java](samples/java/containerapp/README.md) w katalogu przykładów.

## Przykładowa implementacja: Implementacja w JavaScript

SDK dla JavaScript zapewnia lekkie i elastyczne podejście do implementacji MCP.

### Kluczowe funkcje

- Obsługa Node.js i przeglądarek
- API oparte na Promise
- Łatwa integracja z Express i innymi frameworkami
- Obsługa WebSocket dla streamingu

Pełny przykład implementacji w JavaScript znajdziesz w [przykładzie JavaScript](samples/javascript/README.md) w katalogu przykładów.

## Przykładowa implementacja: Implementacja w Pythonie

SDK dla Pythona oferuje podejście zgodne z filozofią Pythona do implementacji MCP z doskonałą integracją z frameworkami ML.

### Kluczowe funkcje

- Obsługa async/await z asyncio
- Integracja z FastAPI
- Prosta rejestracja narzędzi
- Natychmiastowa integracja z popularnymi bibliotekami ML

Pełny przykład implementacji w Pythonie znajdziesz w [przykładzie Python](samples/python/README.md) w katalogu przykładów.

## Zarządzanie API

Azure API Management to świetne rozwiązanie do zabezpieczania serwerów MCP. Pomysł polega na umieszczeniu instancji Azure API Management przed Twoim serwerem MCP, aby obsługiwała funkcje, które mogą być potrzebne, takie jak:

- ograniczanie liczby żądań
- zarządzanie tokenami
- monitorowanie
- równoważenie obciążenia
- bezpieczeństwo

### Przykład Azure

Oto przykład Azure, który pokazuje, jak [utworzyć serwer MCP i zabezpieczyć go za pomocą Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Zobacz, jak wygląda przepływ autoryzacji na poniższym obrazku:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

W powyższym obrazie dzieje się następujące:

- Uwierzytelnianie/autoryzacja odbywa się za pomocą Microsoft Entra.
- Azure API Management działa jako brama i używa zasad do kierowania i zarządzania ruchem.
- Azure Monitor rejestruje wszystkie żądania do dalszej analizy.

#### Przepływ autoryzacji

Przyjrzyjmy się bardziej szczegółowo przepływowi autoryzacji:

![Diagram sekwencji](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specyfikacja autoryzacji MCP

Dowiedz się więcej o [specyfikacji autoryzacji MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow).

## Wdrażanie zdalnego serwera MCP na Azure

Zobaczmy, czy możemy wdrożyć wspomniany wcześniej przykład:

1. Sklonuj repozytorium

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Zarejestruj dostawcę zasobów `Microsoft.App`.

   - Jeśli używasz Azure CLI, uruchom `az provider register --namespace Microsoft.App --wait`.
   - Jeśli używasz Azure PowerShell, uruchom `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Następnie po pewnym czasie uruchom `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`, aby sprawdzić, czy rejestracja została zakończona.

1. Uruchom to polecenie [azd](https://aka.ms/azd), aby przygotować usługę zarządzania API, aplikację funkcji (z kodem) i wszystkie inne wymagane zasoby Azure:

    ```shell
    azd up
    ```

    To polecenie powinno wdrożyć wszystkie zasoby chmurowe na Azure.

### Testowanie serwera za pomocą MCP Inspector

1. W **nowym oknie terminala** zainstaluj i uruchom MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Powinieneś zobaczyć interfejs podobny do:

    ![Połącz z inspektorem Node](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pl.png)

1. Kliknij CTRL, aby załadować aplikację webową MCP Inspector z adresu URL wyświetlanego przez aplikację (np. [http://127.0.0.1:6274/#resources](http://127.0.0.1:6274/#resources)).
1. Ustaw typ transportu na `SSE`.
1. Ustaw adres URL na swój działający punkt końcowy SSE zarządzania API wyświetlany po `azd up` i **Połącz**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

1. **Lista narzędzi**. Kliknij na narzędzie i **Uruchom narzędzie**.

Jeśli wszystkie kroki zostały wykonane poprawnie, powinieneś teraz być połączony z serwerem MCP i móc wywoływać narzędzia.

## Serwery MCP dla Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ten zestaw repozytoriów to szablon szybkiego startu do budowy i wdrażania niestandardowych zdalnych serwerów MCP (Model Context Protocol) za pomocą Azure Functions z Pythonem, C# .NET lub Node/TypeScript.

Przykłady zapewniają kompletne rozwiązanie, które pozwala programistom:

- Budować i uruchamiać lokalnie: Tworzyć i debugować serwer MCP na lokalnym komputerze
- Wdrażać na Azure: Łatwo wdrażać w chmurze za pomocą prostego polecenia `azd up`
- Łączyć się z klientami: Łączyć się z serwerem MCP z różnych klientów, w tym trybu agenta Copilot w VS Code i narzędzia MCP Inspector

### Kluczowe funkcje

- Bezpieczeństwo w projekcie: Serwer MCP jest zabezpieczony za pomocą kluczy i HTTPS
- Opcje uwierzytelniania: Obsługuje OAuth za pomocą wbudowanego uwierzytelniania i/lub zarządzania API
- Izolacja sieci: Umożliwia izolację sieci za pomocą Azure Virtual Networks (VNET)
- Architektura bezserwerowa: Wykorzystuje Azure Functions do skalowalnego, zdarzeniowego wykonywania
- Rozwój lokalny: Kompleksowe wsparcie dla lokalnego rozwoju i debugowania
- Proste wdrażanie: Uproszczony proces wdrażania na Azure

Repozytorium zawiera wszystkie niezbędne pliki konfiguracyjne, kod źródłowy i definicje infrastruktury, aby szybko rozpocząć pracę z gotową do produkcji implementacją serwera MCP.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Przykładowa implementacja MCP za pomocą Azure Functions z Pythonem

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Przykładowa implementacja MCP za pomocą Azure Functions z C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Przykładowa implementacja MCP za pomocą Azure Functions z Node/TypeScript.

## Kluczowe wnioski

- SDK MCP dostarczają narzędzi specyficznych dla języka do implementacji solidnych rozwiązań MCP
- Proces debugowania i testowania jest kluczowy dla niezawodnych aplikacji MCP
- Szablony wielokrotnego użytku umożliwiają spójne interakcje AI
- Dobrze zaprojektowane przepływy pracy mogą koordynować złożone zadania przy użyciu wielu narzędzi
- Implementacja rozwiązań MCP wymaga uwzględnienia bezpieczeństwa, wydajności i obsługi błędów

## Ćwiczenie

Zaprojektuj praktyczny przepływ pracy MCP, który rozwiązuje rzeczywisty problem w Twojej dziedzinie:

1. Zidentyfikuj 3-4 narzędzia, które byłyby przydatne do rozwiązania tego problemu
2. Stwórz diagram przepływu pracy pokazujący, jak te narzędzia współdziałają
3. Zaimplementuj podstawową wersję jednego z narzędzi w preferowanym języku
4. Stwórz szablon, który pomoże modelowi efektywnie korzystać z Twojego narzędzia

## Dodatkowe zasoby

---

Dalej: [Zaawansowane tematy](../05-AdvancedTopics/README.md)

**Zastrzeżenie**:  
Ten dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy wszelkich starań, aby tłumaczenie było precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego rodzimym języku powinien być uznawany za wiarygodne źródło. W przypadku informacji o kluczowym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.