<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T21:24:29+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "pl"
}
-->
# 📖 Podstawowe Koncepcje MCP: Opanowanie Model Context Protocol dla Integracji AI

Model Context Protocol (MCP) to potężne, ustandaryzowane ramy optymalizujące komunikację między dużymi modelami językowymi (LLM) a zewnętrznymi narzędziami, aplikacjami i źródłami danych. Ten przewodnik zoptymalizowany pod SEO przeprowadzi Cię przez podstawowe koncepcje MCP, zapewniając zrozumienie architektury klient-serwer, kluczowych komponentów, mechanizmów komunikacji oraz najlepszych praktyk wdrożeniowych.

## Przegląd

Ta lekcja omawia podstawową architekturę i komponenty tworzące ekosystem Model Context Protocol (MCP). Poznasz architekturę klient-serwer, kluczowe elementy oraz mechanizmy komunikacji napędzające interakcje MCP.

## 👩‍🎓 Główne cele nauki

Na koniec tej lekcji będziesz potrafił:

- Zrozumieć architekturę klient-serwer MCP.
- Zidentyfikować role i obowiązki Hosts, Clients i Servers.
- Przeanalizować kluczowe cechy, które czynią MCP elastyczną warstwą integracyjną.
- Poznać, jak przepływa informacja w ekosystemie MCP.
- Zdobyć praktyczne wskazówki dzięki przykładom kodu w .NET, Java, Python i JavaScript.

## 🔎 Architektura MCP: Szczegółowe spojrzenie

Ekosystem MCP opiera się na modelu klient-serwer. Ta modułowa struktura pozwala aplikacjom AI efektywnie współdziałać z narzędziami, bazami danych, API i zasobami kontekstowymi. Rozbijmy tę architekturę na podstawowe komponenty.

### 1. Hosts

W Model Context Protocol (MCP) Hosts pełnią kluczową rolę jako główny interfejs, za pomocą którego użytkownicy wchodzą w interakcję z protokołem. Hosts to aplikacje lub środowiska inicjujące połączenia z serwerami MCP w celu uzyskania dostępu do danych, narzędzi i promptów. Przykładami Hosts są zintegrowane środowiska programistyczne (IDE) takie jak Visual Studio Code, narzędzia AI jak Claude Desktop lub niestandardowi agenci zaprojektowani do konkretnych zadań.

**Hosts** to aplikacje LLM, które inicjują połączenia. One:

- Wykonują lub współdziałają z modelami AI, aby generować odpowiedzi.
- Inicjują połączenia z serwerami MCP.
- Zarządzają przepływem rozmowy i interfejsem użytkownika.
- Kontrolują uprawnienia i ograniczenia bezpieczeństwa.
- Obsługują zgodę użytkownika na udostępnianie danych i wykonywanie narzędzi.

### 2. Clients

Clients to kluczowe komponenty ułatwiające interakcję między Hosts a serwerami MCP. Działają jako pośrednicy, umożliwiając Hosts dostęp i korzystanie z funkcji oferowanych przez serwery MCP. Odgrywają ważną rolę w zapewnieniu płynnej komunikacji i efektywnej wymiany danych w architekturze MCP.

**Clients** to konektory w aplikacji hosta. One:

- Wysyłają zapytania do serwerów z promptami/instrukcjami.
- Negocjują możliwości z serwerami.
- Zarządzają żądaniami wykonania narzędzi od modeli.
- Przetwarzają i wyświetlają odpowiedzi użytkownikom.

### 3. Servers

Servers odpowiadają za obsługę żądań od klientów MCP i dostarczanie odpowiednich odpowiedzi. Zarządzają różnymi operacjami, takimi jak pobieranie danych, wykonywanie narzędzi i generowanie promptów. Servers zapewniają, że komunikacja między klientami a hostami jest efektywna i niezawodna, utrzymując integralność procesu interakcji.

**Servers** to usługi dostarczające kontekst i funkcjonalności. One:

- Rejestrują dostępne funkcje (zasoby, prompt, narzędzia).
- Odbierają i wykonują wywołania narzędzi od klienta.
- Dostarczają informacje kontekstowe wzbogacające odpowiedzi modelu.
- Zwracają wyniki z powrotem do klienta.
- Utrzymują stan podczas interakcji, gdy jest to potrzebne.

Serwery mogą być tworzone przez każdego, kto chce rozszerzyć możliwości modelu o specjalistyczną funkcjonalność.

### 4. Funkcje Serwera

Serwery w Model Context Protocol (MCP) oferują podstawowe elementy umożliwiające bogate interakcje między klientami, hostami i modelami językowymi. Funkcje te mają na celu zwiększenie możliwości MCP poprzez dostarczanie ustrukturyzowanego kontekstu, narzędzi i promptów.

Serwery MCP mogą oferować dowolne z następujących funkcji:

#### 📑 Zasoby

Zasoby w Model Context Protocol (MCP) obejmują różne typy kontekstu i danych, które mogą być wykorzystywane przez użytkowników lub modele AI. Należą do nich:

- **Dane kontekstowe**: Informacje i kontekst, które użytkownicy lub modele AI mogą wykorzystać do podejmowania decyzji i realizacji zadań.
- **Bazy wiedzy i repozytoria dokumentów**: Zbiory danych strukturalnych i niestrukturalnych, takie jak artykuły, podręczniki i prace naukowe, dostarczające cennych informacji.
- **Pliki lokalne i bazy danych**: Dane przechowywane lokalnie na urządzeniach lub w bazach danych, dostępne do przetwarzania i analizy.
- **API i usługi sieciowe**: Zewnętrzne interfejsy i usługi oferujące dodatkowe dane i funkcje, umożliwiające integrację z różnymi zasobami i narzędziami online.

Przykładem zasobu może być schemat bazy danych lub plik, do którego dostęp uzyskuje się w następujący sposób:

```text
file://log.txt
database://schema
```

### 🤖 Prompty

Prompty w Model Context Protocol (MCP) to różnorodne gotowe szablony i wzorce interakcji, które usprawniają przepływ pracy użytkownika i poprawiają komunikację. Należą do nich:

- **Szablony wiadomości i przepływy pracy**: Wstępnie ustrukturyzowane wiadomości i procesy prowadzące użytkowników przez konkretne zadania i interakcje.
- **Zdefiniowane wzorce interakcji**: Standardowe sekwencje działań i odpowiedzi, które ułatwiają spójną i efektywną komunikację.
- **Specjalistyczne szablony rozmów**: Dostosowane szablony przeznaczone do konkretnych typów konwersacji, zapewniające odpowiednie i kontekstowe interakcje.

Szablon promptu może wyglądać tak:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Narzędzia

Narzędzia w Model Context Protocol (MCP) to funkcje, które model AI może wykonać, aby zrealizować konkretne zadania. Są one zaprojektowane, by zwiększyć możliwości modelu, dostarczając ustrukturyzowane i niezawodne operacje. Kluczowe aspekty to:

- **Funkcje do wykonania przez model AI**: Narzędzia to wykonywalne funkcje, które model AI może wywołać, by przeprowadzić różne zadania.
- **Unikalna nazwa i opis**: Każde narzędzie ma unikalną nazwę i szczegółowy opis wyjaśniający jego cel i działanie.
- **Parametry i wyniki**: Narzędzia przyjmują określone parametry i zwracają ustrukturyzowane wyniki, zapewniając spójne i przewidywalne efekty.
- **Funkcje dyskretne**: Narzędzia wykonują konkretne funkcje, takie jak wyszukiwanie w sieci, obliczenia czy zapytania do baz danych.

Przykładowe narzędzie może wyglądać tak:

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Funkcje Klienta

W Model Context Protocol (MCP) klienci oferują serwerom kilka kluczowych funkcji, zwiększając ogólną funkcjonalność i interakcję w protokole. Jedną z wyróżniających się funkcji jest Sampling.

### 👉 Sampling

- **Agentowe zachowania inicjowane przez serwer**: Klienci umożliwiają serwerom autonomiczne inicjowanie określonych działań lub zachowań, wzmacniając dynamiczne możliwości systemu.
- **Rekurencyjne interakcje z LLM**: Ta funkcja pozwala na rekurencyjne interakcje z dużymi modelami językowymi (LLM), umożliwiając bardziej złożone i iteracyjne przetwarzanie zadań.
- **Żądanie dodatkowych uzupełnień modelu**: Serwery mogą prosić o dodatkowe uzupełnienia od modelu, zapewniając wyczerpujące i kontekstowo odpowiednie odpowiedzi.

## Przepływ informacji w MCP

Model Context Protocol (MCP) definiuje ustrukturyzowany przepływ informacji między hostami, klientami, serwerami i modelami. Zrozumienie tego przepływu pomaga wyjaśnić, jak przetwarzane są żądania użytkownika oraz jak zewnętrzne narzędzia i dane są integrowane z odpowiedziami modelu.

- **Host inicjuje połączenie**  
  Aplikacja hosta (np. IDE lub interfejs czatu) nawiązuje połączenie z serwerem MCP, zazwyczaj przez STDIO, WebSocket lub inny obsługiwany transport.

- **Negocjacja możliwości**  
  Klient (osadzony w hoście) i serwer wymieniają się informacjami o obsługiwanych funkcjach, narzędziach, zasobach i wersjach protokołu. To zapewnia, że obie strony rozumieją dostępne możliwości podczas sesji.

- **Żądanie użytkownika**  
  Użytkownik wchodzi w interakcję z hostem (np. wpisuje prompt lub polecenie). Host zbiera dane i przekazuje je do klienta w celu przetworzenia.

- **Użycie zasobu lub narzędzia**  
  - Klient może poprosić serwer o dodatkowy kontekst lub zasoby (np. pliki, wpisy w bazie danych, artykuły z bazy wiedzy) w celu wzbogacenia zrozumienia modelu.
  - Jeśli model uzna, że potrzebne jest narzędzie (np. do pobrania danych, wykonania obliczeń lub wywołania API), klient wysyła do serwera żądanie wywołania narzędzia, podając jego nazwę i parametry.

- **Wykonanie przez serwer**  
  Serwer odbiera żądanie zasobu lub narzędzia, wykonuje niezbędne operacje (np. uruchamia funkcję, wykonuje zapytanie do bazy danych lub pobiera plik) i zwraca wyniki do klienta w ustrukturyzowanym formacie.

- **Generowanie odpowiedzi**  
  Klient integruje odpowiedzi serwera (dane zasobów, wyniki narzędzi itp.) w trwającą interakcję modelu. Model wykorzystuje te informacje do wygenerowania kompleksowej i kontekstowo odpowiedniej odpowiedzi.

- **Prezentacja wyniku**  
  Host otrzymuje końcowy wynik od klienta i przedstawia go użytkownikowi, często łącząc wygenerowany tekst modelu oraz wyniki wykonania narzędzi lub wyszukiwania zasobów.

Ten przepływ umożliwia MCP wsparcie zaawansowanych, interaktywnych i świadomych kontekstu aplikacji AI, łącząc modele z zewnętrznymi narzędziami i źródłami danych bez zakłóceń.

## Szczegóły protokołu

MCP (Model Context Protocol) opiera się na [JSON-RPC 2.0](https://www.jsonrpc.org/), zapewniając ustandaryzowany, niezależny od języka format wiadomości do komunikacji między hostami, klientami i serwerami. Ta podstawa umożliwia niezawodne, ustrukturyzowane i rozszerzalne interakcje na różnych platformach i w różnych językach programowania.

### Kluczowe cechy protokołu

MCP rozszerza JSON-RPC 2.0 o dodatkowe konwencje dotyczące wywołań narzędzi, dostępu do zasobów i zarządzania promptami. Obsługuje wiele warstw transportowych (STDIO, WebSocket, SSE) oraz umożliwia bezpieczną, rozszerzalną i niezależną od języka komunikację między komponentami.

#### 🧢 Protokół bazowy

- **Format wiadomości JSON-RPC**: Wszystkie zapytania i odpowiedzi korzystają ze specyfikacji JSON-RPC 2.0, zapewniając spójną strukturę dla wywołań metod, parametrów, wyników i obsługi błędów.
- **Stanowe połączenia**: Sesje MCP utrzymują stan między wieloma zapytaniami, wspierając trwające rozmowy, akumulację kontekstu i zarządzanie zasobami.
- **Negocjacja możliwości**: Podczas nawiązywania połączenia klienci i serwery wymieniają informacje o obsługiwanych funkcjach, wersjach protokołu, dostępnych narzędziach i zasobach. To pozwala obu stronom zrozumieć swoje możliwości i odpowiednio się dostosować.

#### ➕ Dodatkowe narzędzia

Poniżej kilka dodatkowych narzędzi i rozszerzeń protokołu, które MCP oferuje, by poprawić doświadczenie programisty i umożliwić zaawansowane scenariusze:

- **Opcje konfiguracji**: MCP pozwala na dynamiczną konfigurację parametrów sesji, takich jak uprawnienia do narzędzi, dostęp do zasobów i ustawienia modelu, dostosowane do każdej interakcji.
- **Śledzenie postępu**: Operacje długotrwałe mogą raportować postęp, co umożliwia responsywne interfejsy użytkownika i lepsze doświadczenia podczas złożonych zadań.
- **Anulowanie zapytań**: Klienci mogą anulować trwające zapytania, pozwalając użytkownikom przerwać operacje, które nie są już potrzebne lub trwają zbyt długo.
- **Raportowanie błędów**: Ustandaryzowane komunikaty i kody błędów pomagają diagnozować problemy, obsługiwać awarie w sposób łagodny i dostarczać przydatne informacje zwrotne użytkownikom i programistom.
- **Logowanie**: Zarówno klienci, jak i serwery mogą generować ustrukturyzowane logi do audytu, debugowania i monitorowania interakcji protokołu.

Wykorzystując te funkcje protokołu, MCP zapewnia solidną, bezpieczną i elastyczną komunikację między modelami językowymi a zewnętrznymi narzędziami lub źródłami danych.

### 🔐 Aspekty bezpieczeństwa

Implementacje MCP powinny przestrzegać kilku kluczowych zasad bezpieczeństwa, by zapewnić bezpieczne i godne zaufania interakcje:

- **Zgoda i kontrola użytkownika**: Użytkownicy muszą wyrazić wyraźną zgodę przed uzyskaniem dostępu do danych lub wykonaniem operacji. Powinni mieć jasną kontrolę nad tym, jakie dane są udostępniane i które działania są autoryzowane, wspierane przez intuicyjne interfejsy do przeglądania i zatwierdzania aktywności.

- **Prywatność danych**: Dane użytkownika powinny być udostępniane tylko za wyraźną zgodą i chronione odpowiednimi mechanizmami kontroli dostępu. Implementacje MCP muszą zabezpieczać przed nieautoryzowanym przesyłaniem danych i zapewniać prywatność podczas wszystkich interakcji.

- **Bezpieczeństwo narzędzi**: Przed wywołaniem narzędzia wymagana jest wyraźna zgoda użytkownika. Użytkownicy powinni dokładnie rozumieć funkcjonalność każdego narzędzia, a systemy muszą egzekwować solidne granice bezpieczeństwa, by zapobiec niezamierzonemu lub niebezpiecznemu wykonaniu narzędzi.

Przestrzegając tych zasad, MCP gwarantuje utrzymanie zaufania użytkowników, prywatności i bezpieczeństwa we wszystkich interakcjach protokołu.

## Przykłady kodu: Kluczowe komponenty

Poniżej znajdują się przykłady kodu w popularnych językach programowania, ilustrujące implementację kluczowych komponentów serwera MCP i narzędzi.

### Przykład .NET: Tworzenie prostego serwera MCP z narzędziami

Praktyczny przykład w .NET pokazujący, jak zaimplementować prosty serwer MCP z niestandardowymi narzędziami. Przykład demonstruje definiowanie i rejestrację narzędzi, obsługę żądań oraz łączenie serwera za pomocą Model Context Protocol.

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### Przykład Java: Komponenty serwera MCP

Ten przykład pokazuje ten sam serwer MCP i rejestrację narzędzi co w przykładzie .NET powy

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za autorytatywne źródło. W przypadku informacji o krytycznym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.