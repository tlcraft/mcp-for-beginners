<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T16:59:17+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "pl"
}
-->
# 📖 MCP Core Concepts: Opanowanie Model Context Protocol dla integracji AI

Model Context Protocol (MCP) to potężny, ustandaryzowany framework, który optymalizuje komunikację między dużymi modelami językowymi (LLM) a zewnętrznymi narzędziami, aplikacjami i źródłami danych. Ten przewodnik zoptymalizowany pod kątem SEO przeprowadzi Cię przez kluczowe koncepcje MCP, zapewniając zrozumienie jego architektury klient-serwer, podstawowych komponentów, mechanizmów komunikacji oraz najlepszych praktyk wdrożeniowych.

## Przegląd

Ta lekcja omawia podstawową architekturę i komponenty, które tworzą ekosystem Model Context Protocol (MCP). Poznasz architekturę klient-serwer, kluczowe elementy oraz mechanizmy komunikacji napędzające interakcje MCP.

## 👩‍🎓 Główne cele nauki

Po zakończeniu tej lekcji będziesz potrafił:

- Zrozumieć architekturę klient-serwer MCP.
- Zidentyfikować role i obowiązki Hosts, Clients i Servers.
- Przeanalizować kluczowe cechy, które czynią MCP elastyczną warstwą integracyjną.
- Poznać przepływ informacji w ekosystemie MCP.
- Zdobyć praktyczną wiedzę dzięki przykładom kodu w .NET, Javie, Pythonie i JavaScript.

## 🔎 Architektura MCP: Dogłębne spojrzenie

Ekosystem MCP opiera się na modelu klient-serwer. Ta modułowa struktura pozwala aplikacjom AI efektywnie współdziałać z narzędziami, bazami danych, API i zasobami kontekstowymi. Rozbijmy tę architekturę na podstawowe komponenty.

### 1. Hosts

W Model Context Protocol (MCP) Hosts odgrywają kluczową rolę jako główny interfejs, przez który użytkownicy wchodzą w interakcję z protokołem. Hosts to aplikacje lub środowiska, które inicjują połączenia z serwerami MCP, aby uzyskać dostęp do danych, narzędzi i promptów. Przykładami Hosts są zintegrowane środowiska programistyczne (IDE) takie jak Visual Studio Code, narzędzia AI jak Claude Desktop czy własne agenty stworzone do konkretnych zadań.

**Hosts** to aplikacje LLM, które inicjują połączenia. One:

- Wykonują lub współdziałają z modelami AI, by generować odpowiedzi.
- Inicjują połączenia z serwerami MCP.
- Zarządzają przepływem konwersacji i interfejsem użytkownika.
- Kontrolują uprawnienia i ograniczenia bezpieczeństwa.
- Obsługują zgodę użytkownika na udostępnianie danych i wykonywanie narzędzi.

### 2. Clients

Clients to kluczowe komponenty ułatwiające interakcję między Hosts a serwerami MCP. Działają jako pośrednicy, umożliwiając Hosts dostęp i korzystanie z funkcjonalności oferowanych przez serwery MCP. Pełnią istotną rolę w zapewnieniu płynnej komunikacji i efektywnej wymiany danych w architekturze MCP.

**Clients** to konektory wewnątrz aplikacji hosta. One:

- Wysyłają żądania do serwerów z promptami/instrukcjami.
- Negocjują możliwości z serwerami.
- Zarządzają żądaniami wykonania narzędzi od modeli.
- Przetwarzają i wyświetlają odpowiedzi użytkownikom.

### 3. Servers

Serwery odpowiadają za obsługę żądań od klientów MCP i dostarczanie odpowiednich odpowiedzi. Zarządzają różnymi operacjami, takimi jak pobieranie danych, wykonywanie narzędzi i generowanie promptów. Serwery dbają o efektywną i niezawodną komunikację między klientami a Hosts, utrzymując integralność procesu interakcji.

**Servers** to usługi, które dostarczają kontekst i funkcje. One:

- Rejestrują dostępne funkcje (zasoby, prompt, narzędzia).
- Odbierają i wykonują wywołania narzędzi od klienta.
- Dostarczają informacje kontekstowe, które wzbogacają odpowiedzi modelu.
- Zwracają wyniki do klienta.
- Utrzymują stan w trakcie interakcji, jeśli jest to potrzebne.

Serwery mogą być tworzone przez każdego, kto chce rozszerzyć możliwości modelu o specjalistyczne funkcje.

### 4. Funkcje serwera

Serwery w Model Context Protocol (MCP) dostarczają podstawowe elementy, które umożliwiają bogate interakcje między klientami, hostami i modelami językowymi. Funkcje te zostały zaprojektowane, aby zwiększyć możliwości MCP, oferując ustrukturyzowany kontekst, narzędzia i prompt.

Serwery MCP mogą oferować dowolne z następujących funkcji:

#### 📑 Zasoby

Zasoby w Model Context Protocol (MCP) obejmują różne typy kontekstu i danych, które mogą być wykorzystywane przez użytkowników lub modele AI. Należą do nich:

- **Dane kontekstowe**: Informacje i kontekst, które użytkownicy lub modele AI mogą wykorzystać do podejmowania decyzji i realizacji zadań.
- **Bazy wiedzy i repozytoria dokumentów**: Zbiory danych ustrukturyzowanych i nieustrukturyzowanych, takie jak artykuły, podręczniki i publikacje naukowe, które dostarczają cennych informacji.
- **Pliki lokalne i bazy danych**: Dane przechowywane lokalnie na urządzeniach lub w bazach danych, dostępne do przetwarzania i analizy.
- **API i usługi sieciowe**: Zewnętrzne interfejsy i usługi oferujące dodatkowe dane i funkcje, umożliwiające integrację z różnymi zasobami i narzędziami online.

Przykładem zasobu może być schemat bazy danych lub plik dostępny w następujący sposób:

```text
file://log.txt
database://schema
```

### 🤖 Prompty

Prompty w Model Context Protocol (MCP) obejmują różne predefiniowane szablony i wzorce interakcji zaprojektowane, aby usprawnić przepływ pracy użytkownika i poprawić komunikację. Należą do nich:

- **Szablony wiadomości i workflow**: Wstępnie zorganizowane wiadomości i procesy prowadzące użytkowników przez konkretne zadania i interakcje.
- **Predefiniowane wzorce interakcji**: Ustandaryzowane sekwencje działań i odpowiedzi ułatwiające spójną i efektywną komunikację.
- **Specjalistyczne szablony rozmów**: Dostosowywane szablony przeznaczone do określonych typów konwersacji, zapewniające odpowiednie i kontekstowo trafne interakcje.

Szablon promptu może wyglądać następująco:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Narzędzia

Narzędzia w Model Context Protocol (MCP) to funkcje, które model AI może wykonać, aby zrealizować konkretne zadania. Narzędzia te mają na celu zwiększenie możliwości modelu AI poprzez dostarczenie ustrukturyzowanych i niezawodnych operacji. Kluczowe aspekty to:

- **Funkcje do wykonania przez model AI**: Narzędzia to wykonywalne funkcje, które model AI może wywołać, by realizować różne zadania.
- **Unikalna nazwa i opis**: Każde narzędzie ma unikalną nazwę oraz szczegółowy opis wyjaśniający jego cel i funkcjonalność.
- **Parametry i wyniki**: Narzędzia przyjmują określone parametry i zwracają ustrukturyzowane wyniki, zapewniając spójne i przewidywalne efekty.
- **Funkcje dyskretne**: Narzędzia realizują odrębne funkcje, takie jak wyszukiwanie w sieci, obliczenia czy zapytania do bazy danych.

Przykład narzędzia może wyglądać tak:

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

## Funkcje klienta

W Model Context Protocol (MCP) klienci oferują serwerom kilka kluczowych funkcji, które wzbogacają ogólną funkcjonalność i interakcję w protokole. Jedną z wyróżniających się funkcji jest Sampling.

### 👉 Sampling

- **Zachowania agentowe inicjowane przez serwer**: Klienci umożliwiają serwerom autonomiczne inicjowanie określonych działań lub zachowań, wzmacniając dynamiczne możliwości systemu.
- **Rekurencyjne interakcje LLM**: Ta funkcja pozwala na rekurencyjne interakcje z dużymi modelami językowymi (LLM), umożliwiając bardziej złożone i iteracyjne przetwarzanie zadań.
- **Żądanie dodatkowych uzupełnień modelu**: Serwery mogą prosić o dodatkowe uzupełnienia od modelu, zapewniając, że odpowiedzi są wyczerpujące i kontekstowo trafne.

## Przepływ informacji w MCP

Model Context Protocol (MCP) definiuje ustrukturyzowany przepływ informacji między hostami, klientami, serwerami i modelami. Zrozumienie tego przepływu pomaga wyjaśnić, jak przetwarzane są żądania użytkownika oraz jak zewnętrzne narzędzia i dane są integrowane z odpowiedziami modelu.

- **Host inicjuje połączenie**  
  Aplikacja hosta (np. IDE lub interfejs czatu) nawiązuje połączenie z serwerem MCP, zwykle przez STDIO, WebSocket lub inny obsługiwany transport.

- **Negocjacja możliwości**  
  Klient (osadzony w hoście) i serwer wymieniają informacje o wspieranych funkcjach, narzędziach, zasobach i wersjach protokołu. Zapewnia to, że obie strony rozumieją dostępne możliwości sesji.

- **Żądanie użytkownika**  
  Użytkownik wchodzi w interakcję z hostem (np. wpisuje prompt lub polecenie). Host zbiera ten input i przekazuje go do klienta do przetworzenia.

- **Użycie zasobów lub narzędzi**  
  - Klient może zażądać dodatkowego kontekstu lub zasobów od serwera (np. plików, wpisów w bazie danych czy artykułów z bazy wiedzy), aby wzbogacić rozumienie modelu.
  - Jeśli model uzna, że potrzebne jest narzędzie (np. do pobrania danych, wykonania obliczeń lub wywołania API), klient wysyła do serwera żądanie wywołania narzędzia, podając nazwę narzędzia i parametry.

- **Wykonanie na serwerze**  
  Serwer odbiera żądanie zasobu lub narzędzia, wykonuje niezbędne operacje (np. uruchomienie funkcji, zapytanie do bazy danych, pobranie pliku) i zwraca wyniki klientowi w ustrukturyzowanym formacie.

- **Generowanie odpowiedzi**  
  Klient integruje odpowiedzi serwera (dane zasobów, wyniki narzędzi itp.) z trwającą interakcją modelu. Model wykorzystuje te informacje, by wygenerować wyczerpującą i kontekstowo odpowiednią odpowiedź.

- **Prezentacja wyniku**  
  Host otrzymuje finalny wynik od klienta i prezentuje go użytkownikowi, często łącząc wygenerowany tekst modelu z wynikami wykonania narzędzi lub wyszukiwania zasobów.

Ten przepływ umożliwia MCP wspieranie zaawansowanych, interaktywnych i świadomych kontekstu aplikacji AI, poprzez płynne łączenie modeli z zewnętrznymi narzędziami i źródłami danych.

## Szczegóły protokołu

MCP (Model Context Protocol) opiera się na [JSON-RPC 2.0](https://www.jsonrpc.org/), zapewniając ustandaryzowany, niezależny od języka format wiadomości do komunikacji między hostami, klientami i serwerami. Ta podstawa umożliwia niezawodne, ustrukturyzowane i rozszerzalne interakcje na różnych platformach i w różnych językach programowania.

### Kluczowe cechy protokołu

MCP rozszerza JSON-RPC 2.0 o dodatkowe konwencje dla wywołań narzędzi, dostępu do zasobów i zarządzania promptami. Wspiera wiele warstw transportu (STDIO, WebSocket, SSE) oraz umożliwia bezpieczną, rozszerzalną i niezależną od języka komunikację między komponentami.

#### 🧢 Protokół bazowy

- **Format wiadomości JSON-RPC**: Wszystkie żądania i odpowiedzi korzystają ze specyfikacji JSON-RPC 2.0, zapewniając spójną strukturę dla wywołań metod, parametrów, wyników i obsługi błędów.
- **Połączenia stanowe**: Sesje MCP utrzymują stan przez wiele żądań, wspierając kontynuowane rozmowy, akumulację kontekstu i zarządzanie zasobami.
- **Negocjacja możliwości**: Podczas nawiązywania połączenia klienci i serwery wymieniają informacje o wspieranych funkcjach, wersjach protokołu, dostępnych narzędziach i zasobach. Zapewnia to wzajemne zrozumienie możliwości i możliwość dostosowania.

#### ➕ Dodatkowe narzędzia

Poniżej kilka dodatkowych narzędzi i rozszerzeń protokołu, które MCP oferuje, by poprawić doświadczenie deweloperów i umożliwić zaawansowane scenariusze:

- **Opcje konfiguracji**: MCP pozwala na dynamiczne konfigurowanie parametrów sesji, takich jak uprawnienia do narzędzi, dostęp do zasobów czy ustawienia modelu, dostosowane do każdej interakcji.
- **Śledzenie postępu**: Operacje długotrwałe mogą raportować aktualizacje postępu, umożliwiając responsywne interfejsy użytkownika i lepsze doświadczenie podczas złożonych zadań.
- **Anulowanie żądań**: Klienci mogą anulować bieżące żądania, pozwalając użytkownikom przerwać operacje, które nie są już potrzebne lub trwają zbyt długo.
- **Raportowanie błędów**: Ustandaryzowane komunikaty i kody błędów pomagają diagnozować problemy, obsługiwać awarie w sposób łagodny i dostarczać przydatne informacje zwrotne użytkownikom i deweloperom.
- **Logowanie**: Zarówno klienci, jak i serwery mogą emitować ustrukturyzowane logi do audytu, debugowania i monitorowania interakcji protokołu.

Dzięki tym funkcjom MCP zapewnia solidną, bezpieczną i elastyczną komunikację między modelami językowymi a zewnętrznymi narzędziami i źródłami danych.

### 🔐 Aspekty bezpieczeństwa

Implementacje MCP powinny przestrzegać kilku kluczowych zasad bezpieczeństwa, by zapewnić bezpieczne i godne zaufania interakcje:

- **Zgoda i kontrola użytkownika**: Użytkownicy muszą wyrazić wyraźną zgodę przed uzyskaniem dostępu do danych lub wykonaniem operacji. Powinni mieć jasną kontrolę nad tym, jakie dane są udostępniane i które akcje są autoryzowane, wspierane przez intuicyjne interfejsy do przeglądu i zatwierdzania działań.

- **Prywatność danych**: Dane użytkownika mogą być ujawniane tylko za wyraźną zgodą i muszą być chronione odpowiednimi mechanizmami kontroli dostępu. Implementacje MCP muszą zabezpieczać przed nieautoryzowanym przesyłaniem danych i zapewniać ochronę prywatności podczas wszystkich interakcji.

- **Bezpieczeństwo narzędzi**: Przed wywołaniem jakiegokolwiek narzędzia wymagana jest wyraźna zgoda użytkownika. Użytkownicy powinni mieć jasne zrozumienie funkcjonalności każdego narzędzia, a silne granice bezpieczeństwa muszą zapobiegać niezamierzonemu lub niebezpiecznemu wykonaniu narzędzi.

Przestrzegając tych zasad, MCP zapewnia utrzymanie zaufania użytkowników, prywatności i bezpieczeństwa we wszystkich interakcjach protokołu.

## Przykłady kodu: Kluczowe komponenty

Poniżej znajdują się przykłady kodu w kilku popularnych językach programowania, które ilustrują, jak zaimplementować kluczowe komponenty serwera MCP oraz narzędzia.

### Przykład .NET: Tworzenie prostego serwera MCP z narzędziami

Praktyczny przykład kodu .NET pokazujący, jak zaimplementować prosty serwer MCP z niestandardowymi narzędziami. Przykład prezentuje definiowanie i rejestrację narzędzi, obsługę żądań oraz połączenie serwera z wykorzystaniem Model Context Protocol.

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



**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy uważać za wiarygodne źródło informacji. W przypadku informacji o krytycznym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.