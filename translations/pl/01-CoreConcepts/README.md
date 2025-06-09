<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:22:28+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "pl"
}
-->
# 📖 Podstawowe koncepcje MCP: Opanowanie Model Context Protocol dla integracji AI

Model Context Protocol (MCP) to potężne, ustandaryzowane ramy, które optymalizują komunikację pomiędzy dużymi modelami językowymi (LLM) a zewnętrznymi narzędziami, aplikacjami i źródłami danych. Ten przewodnik zoptymalizowany pod kątem SEO przeprowadzi Cię przez kluczowe koncepcje MCP, zapewniając zrozumienie architektury klient-serwer, podstawowych elementów, mechanizmów komunikacji oraz najlepszych praktyk implementacyjnych.

## Przegląd

Ta lekcja omawia podstawową architekturę i komponenty, które tworzą ekosystem Model Context Protocol (MCP). Poznasz architekturę klient-serwer, kluczowe elementy oraz mechanizmy komunikacji, które napędzają interakcje MCP.

## 👩‍🎓 Główne cele nauki

Po zakończeniu tej lekcji będziesz potrafił:

- Zrozumieć architekturę klient-serwer MCP.
- Zidentyfikować role i obowiązki Hosts, Clients i Servers.
- Przeanalizować kluczowe cechy, które czynią MCP elastyczną warstwą integracyjną.
- Poznać sposób przepływu informacji w ekosystemie MCP.
- Zdobyć praktyczną wiedzę dzięki przykładom kodu w .NET, Javie, Pythonie i JavaScript.

## 🔎 Architektura MCP: Głębsze spojrzenie

Ekosystem MCP opiera się na modelu klient-serwer. Ta modułowa struktura pozwala aplikacjom AI efektywnie współdziałać z narzędziami, bazami danych, API i zasobami kontekstowymi. Rozbijmy tę architekturę na jej podstawowe elementy.

### 1. Hosts

W Model Context Protocol (MCP) Hosts odgrywają kluczową rolę jako główny interfejs, przez który użytkownicy wchodzą w interakcję z protokołem. Hosts to aplikacje lub środowiska, które inicjują połączenia z serwerami MCP, aby uzyskać dostęp do danych, narzędzi i promptów. Przykładami Hosts są zintegrowane środowiska programistyczne (IDE) takie jak Visual Studio Code, narzędzia AI jak Claude Desktop lub niestandardowe agenty stworzone do konkretnych zadań.

**Hosts** to aplikacje LLM, które inicjują połączenia. One:

- Wykonują lub współdziałają z modelami AI w celu generowania odpowiedzi.
- Inicjują połączenia z serwerami MCP.
- Zarządzają przepływem rozmowy i interfejsem użytkownika.
- Kontrolują uprawnienia i ograniczenia bezpieczeństwa.
- Obsługują zgodę użytkownika na udostępnianie danych i wykonywanie narzędzi.

### 2. Clients

Clients są kluczowymi komponentami ułatwiającymi interakcję pomiędzy Hosts a serwerami MCP. Działają jako pośrednicy, umożliwiając Hosts dostęp i wykorzystanie funkcji oferowanych przez serwery MCP. Odgrywają istotną rolę w zapewnieniu płynnej komunikacji i efektywnej wymiany danych w architekturze MCP.

**Clients** to konektory w aplikacji hosta. One:

- Wysyłają żądania do serwerów z promptami/instrukcjami.
- Negocjują możliwości z serwerami.
- Zarządzają żądaniami wykonania narzędzi od modeli.
- Przetwarzają i wyświetlają odpowiedzi użytkownikom.

### 3. Servers

Servers odpowiadają za obsługę żądań od klientów MCP i dostarczanie odpowiednich odpowiedzi. Zarządzają różnymi operacjami, takimi jak pobieranie danych, wykonywanie narzędzi czy generowanie promptów. Serwery dbają o to, aby komunikacja między klientami a Hosts była efektywna i niezawodna, utrzymując integralność procesu interakcji.

**Servers** to usługi dostarczające kontekst i funkcjonalności. One:

- Rejestrują dostępne funkcje (zasoby, prompty, narzędzia)
- Odbierają i wykonują wywołania narzędzi od klienta
- Dostarczają informacje kontekstowe wzbogacające odpowiedzi modeli
- Zwracają wyniki do klienta
- Utrzymują stan podczas interakcji, jeśli jest to potrzebne

Serwery mogą być tworzone przez każdego, kto chce rozszerzyć możliwości modelu o specjalistyczne funkcje.

### 4. Funkcje serwera

Serwery w Model Context Protocol (MCP) dostarczają podstawowe elementy umożliwiające bogate interakcje pomiędzy klientami, hostami i modelami językowymi. Funkcje te zostały zaprojektowane, by wzbogacić możliwości MCP, oferując uporządkowany kontekst, narzędzia i prompty.

Serwery MCP mogą oferować dowolne z następujących funkcji:

#### 📑 Zasoby

Zasoby w Model Context Protocol (MCP) obejmują różne typy kontekstu i danych, które mogą być wykorzystywane przez użytkowników lub modele AI. Należą do nich:

- **Dane kontekstowe**: Informacje i kontekst, które użytkownicy lub modele AI mogą wykorzystać do podejmowania decyzji i realizacji zadań.
- **Bazy wiedzy i repozytoria dokumentów**: Zbiory danych ustrukturyzowanych i nieustrukturyzowanych, takie jak artykuły, podręczniki czy prace naukowe, dostarczające cennych informacji.
- **Lokalne pliki i bazy danych**: Dane przechowywane lokalnie na urządzeniach lub w bazach danych, dostępne do przetwarzania i analizy.
- **API i usługi webowe**: Zewnętrzne interfejsy i usługi oferujące dodatkowe dane i funkcjonalności, umożliwiające integrację z różnymi zasobami i narzędziami online.

Przykładem zasobu może być schemat bazy danych lub plik, do którego można uzyskać dostęp w następujący sposób:

```text
file://log.txt
database://schema
```

### 🤖 Prompty

Prompty w Model Context Protocol (MCP) to różne predefiniowane szablony i wzorce interakcji zaprojektowane, by usprawnić przepływ pracy użytkownika i poprawić komunikację. Należą do nich:

- **Szablony wiadomości i workflow**: Wstępnie ustrukturyzowane wiadomości i procesy, które prowadzą użytkowników przez konkretne zadania i interakcje.
- **Predefiniowane wzorce interakcji**: Standardowe sekwencje działań i odpowiedzi, które ułatwiają spójną i efektywną komunikację.
- **Specjalistyczne szablony rozmów**: Dostosowywane szablony przeznaczone do określonych typów konwersacji, zapewniające odpowiednie i kontekstowo trafne interakcje.

Szablon promptu może wyglądać tak:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Narzędzia

Narzędzia w Model Context Protocol (MCP) to funkcje, które model AI może wykonać, by zrealizować konkretne zadania. Zostały zaprojektowane, by rozszerzyć możliwości modelu AI poprzez dostarczenie uporządkowanych i niezawodnych operacji. Kluczowe aspekty to:

- **Funkcje do wykonania przez model AI**: Narzędzia to funkcje, które model AI może wywołać, aby zrealizować różne zadania.
- **Unikalna nazwa i opis**: Każde narzędzie ma odrębną nazwę oraz szczegółowy opis wyjaśniający jego cel i działanie.
- **Parametry i wyniki**: Narzędzia przyjmują określone parametry i zwracają uporządkowane wyniki, zapewniając spójność i przewidywalność efektów.
- **Dyskretne funkcje**: Narzędzia realizują odrębne funkcje, takie jak wyszukiwanie w sieci, obliczenia czy zapytania do baz danych.

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

## Funkcje klienta

W Model Context Protocol (MCP) klienci oferują serwerom kilka kluczowych funkcji, które wzbogacają ogólną funkcjonalność i interakcję w protokole. Jedną z wyróżniających się funkcji jest Sampling.

### 👉 Sampling

- **Agentowe zachowania inicjowane przez serwer**: Klienci umożliwiają serwerom autonomiczne inicjowanie określonych działań lub zachowań, zwiększając dynamiczne możliwości systemu.
- **Rekurencyjne interakcje z LLM**: Ta funkcja pozwala na rekurencyjne interakcje z dużymi modelami językowymi, umożliwiając bardziej złożone i iteracyjne przetwarzanie zadań.
- **Żądanie dodatkowych uzupełnień modelu**: Serwery mogą żądać dodatkowych uzupełnień od modelu, zapewniając, że odpowiedzi są wyczerpujące i kontekstowo adekwatne.

## Przepływ informacji w MCP

Model Context Protocol (MCP) definiuje uporządkowany przepływ informacji pomiędzy hostami, klientami, serwerami i modelami. Zrozumienie tego przepływu pomaga wyjaśnić, jak przetwarzane są żądania użytkowników oraz jak zewnętrzne narzędzia i dane są integrowane w odpowiedziach modelu.

- **Host inicjuje połączenie**  
  Aplikacja hosta (np. IDE lub interfejs czatu) nawiązuje połączenie z serwerem MCP, zazwyczaj przez STDIO, WebSocket lub inny obsługiwany transport.

- **Negocjacja możliwości**  
  Klient (osadzony w hoście) i serwer wymieniają informacje o obsługiwanych funkcjach, narzędziach, zasobach i wersjach protokołu. Zapewnia to wzajemne zrozumienie dostępnych możliwości na czas sesji.

- **Żądanie użytkownika**  
  Użytkownik wchodzi w interakcję z hostem (np. wpisuje prompt lub polecenie). Host zbiera ten input i przekazuje go do klienta do przetworzenia.

- **Wykorzystanie zasobów lub narzędzi**  
  - Klient może zażądać dodatkowego kontekstu lub zasobów od serwera (np. plików, wpisów w bazie danych lub artykułów z bazy wiedzy), aby wzbogacić rozumienie modelu.
  - Jeśli model uzna, że potrzebne jest narzędzie (np. do pobrania danych, wykonania obliczeń lub wywołania API), klient wysyła do serwera żądanie wywołania narzędzia, określając jego nazwę i parametry.

- **Wykonanie przez serwer**  
  Serwer odbiera żądanie zasobu lub narzędzia, wykonuje niezbędne operacje (np. uruchomienie funkcji, zapytanie do bazy danych lub pobranie pliku) i zwraca wyniki do klienta w uporządkowanym formacie.

- **Generowanie odpowiedzi**  
  Klient integruje odpowiedzi serwera (dane zasobów, wyniki narzędzi itd.) w bieżącą interakcję z modelem. Model wykorzystuje te informacje, by wygenerować kompleksową i kontekstowo trafną odpowiedź.

- **Prezentacja wyniku**  
  Host otrzymuje ostateczny output od klienta i prezentuje go użytkownikowi, często łącząc wygenerowany tekst modelu z wynikami wykonania narzędzi lub wyszukiwania zasobów.

Ten przepływ umożliwia MCP wspieranie zaawansowanych, interaktywnych i świadomych kontekstu aplikacji AI poprzez płynne łączenie modeli z zewnętrznymi narzędziami i źródłami danych.

## Szczegóły protokołu

MCP (Model Context Protocol) bazuje na [JSON-RPC 2.0](https://www.jsonrpc.org/), oferując ustandaryzowany, niezależny od języka format komunikatów do komunikacji między hostami, klientami i serwerami. Ta podstawa umożliwia niezawodne, uporządkowane i rozszerzalne interakcje na różnych platformach i w różnych językach programowania.

### Kluczowe cechy protokołu

MCP rozszerza JSON-RPC 2.0 o dodatkowe konwencje dotyczące wywołań narzędzi, dostępu do zasobów i zarządzania promptami. Obsługuje wiele warstw transportu (STDIO, WebSocket, SSE) i umożliwia bezpieczną, rozszerzalną i niezależną od języka komunikację pomiędzy komponentami.

#### 🧢 Protokół bazowy

- **Format komunikatów JSON-RPC**: Wszystkie żądania i odpowiedzi używają specyfikacji JSON-RPC 2.0, zapewniając spójną strukturę wywołań metod, parametrów, wyników i obsługi błędów.
- **Połączenia stanowe**: Sesje MCP utrzymują stan przez wiele żądań, wspierając ciągłe rozmowy, akumulację kontekstu i zarządzanie zasobami.
- **Negocjacja możliwości**: Podczas nawiązywania połączenia klienci i serwery wymieniają informacje o obsługiwanych funkcjach, wersjach protokołu, dostępnych narzędziach i zasobach. Zapewnia to wzajemne zrozumienie i możliwość dostosowania.

#### ➕ Dodatkowe narzędzia

Poniżej kilka dodatkowych narzędzi i rozszerzeń protokołu, które MCP oferuje, by poprawić doświadczenie deweloperskie i umożliwić zaawansowane scenariusze:

- **Opcje konfiguracji**: MCP pozwala na dynamiczną konfigurację parametrów sesji, takich jak uprawnienia do narzędzi, dostęp do zasobów czy ustawienia modelu, dopasowane do każdej interakcji.
- **Śledzenie postępu**: Operacje długotrwałe mogą raportować aktualizacje postępu, co umożliwia responsywne interfejsy użytkownika i lepsze doświadczenia podczas złożonych zadań.
- **Anulowanie żądań**: Klienci mogą anulować trwające żądania, pozwalając użytkownikom przerwać operacje, które nie są już potrzebne lub trwają zbyt długo.
- **Raportowanie błędów**: Ustandaryzowane komunikaty i kody błędów pomagają diagnozować problemy, obsługiwać awarie w sposób łagodny i dostarczać użyteczne informacje zwrotne użytkownikom i deweloperom.
- **Logowanie**: Zarówno klienci, jak i serwery mogą generować uporządkowane logi do celów audytu, debugowania i monitorowania interakcji protokołu.

Wykorzystując te funkcje protokołu, MCP zapewnia solidną, bezpieczną i elastyczną komunikację pomiędzy modelami językowymi a zewnętrznymi narzędziami lub źródłami danych.

### 🔐 Zagadnienia bezpieczeństwa

Implementacje MCP powinny przestrzegać kilku kluczowych zasad bezpieczeństwa, aby zapewnić bezpieczne i godne zaufania interakcje:

- **Zgoda i kontrola użytkownika**: Użytkownicy muszą wyrazić wyraźną zgodę przed uzyskaniem dostępu do danych lub wykonaniem operacji. Powinni mieć jasną kontrolę nad tym, jakie dane są udostępniane i które działania są autoryzowane, wspierane przez intuicyjne interfejsy do przeglądu i zatwierdzania aktywności.

- **Prywatność danych**: Dane użytkownika powinny być udostępniane wyłącznie za wyraźną zgodą i chronione odpowiednimi mechanizmami kontroli dostępu. Implementacje MCP muszą zapobiegać nieautoryzowanemu przesyłaniu danych i zapewniać zachowanie prywatności we wszystkich interakcjach.

- **Bezpieczeństwo narzędzi**: Przed wywołaniem narzędzia wymagana jest wyraźna zgoda użytkownika. Użytkownicy powinni mieć jasne informacje o funkcjonalności każdego narzędzia, a silne granice bezpieczeństwa muszą zapobiegać niezamierzonemu lub niebezpiecznemu wykonaniu narzędzi.

Przestrzegając tych zasad, MCP zapewnia utrzymanie zaufania użytkowników, prywatności i bezpieczeństwa we wszystkich interakcjach protokołu.

## Przykłady kodu: Kluczowe komponenty

Poniżej znajdują się przykłady kodu w kilku popularnych językach programowania, które ilustrują implementację kluczowych komponentów serwera MCP oraz narzędzi.

### Przykład .NET: Tworzenie prostego serwera MCP z narzędziami

Praktyczny przykład w .NET pokazujący, jak zaimplementować prosty serwer MCP z niestandardowymi narzędziami. Przykład demonstruje definiowanie i rejestrację narzędzi, obsługę żądań oraz łączenie serwera z Model Context Protocol.

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

Ten przykład pokazuje ten sam

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiarygodne i autorytatywne. W przypadku informacji o krytycznym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.