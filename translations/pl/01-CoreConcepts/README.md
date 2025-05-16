<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-16T15:50:47+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "pl"
}
-->
# 📖 Podstawowe koncepcje MCP: Opanowanie Model Context Protocol dla integracji AI

Model Context Protocol (MCP) to potężny, ustandaryzowany framework, który optymalizuje komunikację między dużymi modelami językowymi (LLM) a zewnętrznymi narzędziami, aplikacjami i źródłami danych. Ten przewodnik zoptymalizowany pod SEO przeprowadzi Cię przez podstawowe koncepcje MCP, zapewniając zrozumienie jego architektury klient-serwer, kluczowych elementów, mechanizmów komunikacji oraz najlepszych praktyk implementacyjnych.

## Przegląd

Ta lekcja bada podstawową architekturę i komponenty, które tworzą ekosystem Model Context Protocol (MCP). Poznasz architekturę klient-serwer, kluczowe komponenty oraz mechanizmy komunikacji, które napędzają interakcje MCP.

## 👩‍🎓 Główne cele nauki

Na koniec tej lekcji będziesz potrafił:

- Zrozumieć architekturę klient-serwer MCP.
- Określić role i obowiązki Hosts, Clients i Servers.
- Przeanalizować kluczowe cechy, które czynią MCP elastyczną warstwą integracyjną.
- Poznać przepływ informacji w ekosystemie MCP.
- Zdobyć praktyczne wskazówki dzięki przykładom kodu w .NET, Java, Python i JavaScript.

## 🔎 Architektura MCP: Głębsze spojrzenie

Ekosystem MCP opiera się na modelu klient-serwer. Ta modułowa struktura pozwala aplikacjom AI efektywnie współdziałać z narzędziami, bazami danych, API i zasobami kontekstowymi. Rozbijmy tę architekturę na jej podstawowe komponenty.

### 1. Hosts

W Model Context Protocol (MCP) Hosts odgrywają kluczową rolę jako główny interfejs, za pomocą którego użytkownicy wchodzą w interakcję z protokołem. Hosts to aplikacje lub środowiska, które inicjują połączenia z serwerami MCP, aby uzyskać dostęp do danych, narzędzi i promptów. Przykładami Hosts są zintegrowane środowiska programistyczne (IDE) takie jak Visual Studio Code, narzędzia AI jak Claude Desktop lub niestandardowi agenci stworzeni do konkretnych zadań.

**Hosts** to aplikacje LLM, które inicjują połączenia. One:

- Wykonują lub współdziałają z modelami AI, aby generować odpowiedzi.
- Inicjują połączenia z serwerami MCP.
- Zarządzają przebiegiem konwersacji i interfejsem użytkownika.
- Kontrolują uprawnienia i ograniczenia bezpieczeństwa.
- Obsługują zgodę użytkownika na udostępnianie danych i wykonywanie narzędzi.

### 2. Clients

Clients to kluczowe komponenty ułatwiające interakcję między Hosts a serwerami MCP. Działają jako pośrednicy, umożliwiając Hosts dostęp do funkcji oferowanych przez serwery MCP. Odgrywają ważną rolę w zapewnieniu płynnej komunikacji i efektywnej wymiany danych w architekturze MCP.

**Clients** to konektory w aplikacji hosta. One:

- Wysyłają żądania do serwerów z promptami/instrukcjami.
- Negocjują możliwości z serwerami.
- Zarządzają żądaniami wykonania narzędzi od modeli.
- Przetwarzają i wyświetlają odpowiedzi użytkownikom.

### 3. Servers

Serwery odpowiadają za obsługę żądań od klientów MCP i dostarczanie odpowiednich odpowiedzi. Zarządzają różnymi operacjami, takimi jak pobieranie danych, wykonywanie narzędzi i generowanie promptów. Serwery zapewniają, że komunikacja między klientami a Hosts jest efektywna i niezawodna, utrzymując integralność procesu interakcji.

**Servers** to usługi dostarczające kontekst i możliwości. One:

- Rejestrują dostępne funkcje (zasoby, prompt, narzędzia)
- Odbierają i wykonują wywołania narzędzi od klienta
- Dostarczają informacje kontekstowe, które wzbogacają odpowiedzi modelu
- Zwracają wyniki do klienta
- Utrzymują stan podczas interakcji, jeśli jest to potrzebne

Serwery mogą być tworzone przez każdego, kto chce rozszerzyć możliwości modelu o specjalistyczne funkcje.

### 4. Funkcje serwera

Serwery w Model Context Protocol (MCP) dostarczają fundamentalne elementy umożliwiające bogate interakcje między klientami, hostami i modelami językowymi. Funkcje te mają na celu zwiększenie możliwości MCP poprzez oferowanie ustrukturyzowanego kontekstu, narzędzi i promptów.

Serwery MCP mogą oferować dowolne z poniższych funkcji:

#### 📑 Zasoby

Zasoby w Model Context Protocol (MCP) obejmują różne typy kontekstu i danych, które mogą być wykorzystywane przez użytkowników lub modele AI. Należą do nich:

- **Dane kontekstowe**: Informacje i kontekst, z których użytkownicy lub modele AI mogą korzystać do podejmowania decyzji i wykonywania zadań.
- **Bazy wiedzy i repozytoria dokumentów**: Zbiory danych strukturalnych i niestrukturalnych, takie jak artykuły, podręczniki i prace naukowe, które dostarczają cennych informacji.
- **Pliki lokalne i bazy danych**: Dane przechowywane lokalnie na urządzeniach lub w bazach danych, dostępne do przetwarzania i analizy.
- **API i usługi sieciowe**: Zewnętrzne interfejsy i usługi oferujące dodatkowe dane i funkcje, umożliwiające integrację z różnymi zasobami i narzędziami online.

Przykładem zasobu może być schemat bazy danych lub plik dostępny w następujący sposób:

```text
file://log.txt
database://schema
```

### 🤖 Prompty

Prompty w Model Context Protocol (MCP) obejmują różne predefiniowane szablony i wzorce interakcji, zaprojektowane w celu usprawnienia przepływów pracy użytkownika i poprawy komunikacji. Należą do nich:

- **Szablony wiadomości i przepływy pracy**: Wstępnie ustrukturyzowane wiadomości i procesy, które prowadzą użytkowników przez konkretne zadania i interakcje.
- **Predefiniowane wzorce interakcji**: Standardowe sekwencje działań i odpowiedzi, które ułatwiają spójną i efektywną komunikację.
- **Specjalistyczne szablony konwersacji**: Konfigurowalne szablony dostosowane do konkretnych typów rozmów, zapewniające odpowiednie i kontekstowe interakcje.

Szablon promptu może wyglądać następująco:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Narzędzia

Narzędzia w Model Context Protocol (MCP) to funkcje, które model AI może wykonać, aby zrealizować konkretne zadania. Narzędzia te mają na celu zwiększenie możliwości modelu AI poprzez dostarczenie ustrukturyzowanych i niezawodnych operacji. Kluczowe aspekty to:

- **Funkcje do wykonania przez model AI**: Narzędzia to funkcje, które model AI może wywołać, aby zrealizować różne zadania.
- **Unikalna nazwa i opis**: Każde narzędzie ma unikalną nazwę oraz szczegółowy opis wyjaśniający jego cel i funkcjonalność.
- **Parametry i wyniki**: Narzędzia przyjmują określone parametry i zwracają ustrukturyzowane wyniki, co zapewnia spójność i przewidywalność efektów.
- **Funkcje dyskretne**: Narzędzia wykonują oddzielne funkcje, takie jak wyszukiwanie w sieci, obliczenia czy zapytania do bazy danych.

Przykład narzędzia może wyglądać tak:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Funkcje klienta

W Model Context Protocol (MCP) klienci oferują serwerom kilka kluczowych funkcji, które zwiększają ogólną funkcjonalność i interakcję w protokole. Jedną z ważnych funkcji jest Sampling.

### 👉 Sampling

- **Agentowe zachowania inicjowane przez serwer**: Klienci umożliwiają serwerom autonomiczne inicjowanie określonych działań lub zachowań, zwiększając dynamiczne możliwości systemu.
- **Rekurencyjne interakcje z LLM**: Ta funkcja pozwala na rekurencyjne interakcje z dużymi modelami językowymi (LLM), umożliwiając bardziej złożone i iteracyjne przetwarzanie zadań.
- **Żądanie dodatkowych uzupełnień modelu**: Serwery mogą żądać dodatkowych uzupełnień od modelu, zapewniając, że odpowiedzi są wyczerpujące i kontekstowo adekwatne.

## Przepływ informacji w MCP

Model Context Protocol (MCP) definiuje ustrukturyzowany przepływ informacji między hosts, clients, servers i modelami. Zrozumienie tego przepływu pomaga wyjaśnić, jak przetwarzane są żądania użytkowników i jak zewnętrzne narzędzia oraz dane są integrowane w odpowiedziach modelu.

- **Host inicjuje połączenie**  
  Aplikacja hosta (np. IDE lub interfejs czatu) nawiązuje połączenie z serwerem MCP, zwykle za pomocą STDIO, WebSocket lub innego obsługiwanego transportu.

- **Negocjacja możliwości**  
  Klient (osadzony w hoście) i serwer wymieniają się informacjami o obsługiwanych funkcjach, narzędziach, zasobach i wersjach protokołu. Zapewnia to wzajemne zrozumienie dostępnych możliwości dla sesji.

- **Żądanie użytkownika**  
  Użytkownik wchodzi w interakcję z hostem (np. wpisuje prompt lub polecenie). Host zbiera to wejście i przekazuje je do klienta do przetworzenia.

- **Użycie zasobu lub narzędzia**  
  - Klient może zażądać dodatkowego kontekstu lub zasobów od serwera (np. plików, wpisów w bazie danych, artykułów z bazy wiedzy), aby wzbogacić zrozumienie modelu.
  - Jeśli model uzna, że potrzebne jest narzędzie (np. do pobrania danych, wykonania obliczenia lub wywołania API), klient wysyła żądanie wywołania narzędzia do serwera, podając nazwę narzędzia i parametry.

- **Wykonanie przez serwer**  
  Serwer odbiera żądanie zasobu lub narzędzia, wykonuje niezbędne operacje (np. uruchomienie funkcji, zapytanie do bazy danych, pobranie pliku) i zwraca wyniki klientowi w ustrukturyzowanym formacie.

- **Generowanie odpowiedzi**  
  Klient integruje odpowiedzi serwera (dane zasobów, wyniki narzędzi itp.) w trwającej interakcji z modelem. Model używa tych informacji do wygenerowania kompleksowej i kontekstowo adekwatnej odpowiedzi.

- **Prezentacja wyniku**  
  Host otrzymuje ostateczny wynik od klienta i prezentuje go użytkownikowi, często łącząc wygenerowany tekst modelu oraz wyniki wywołań narzędzi lub wyszukiwań zasobów.

Ten przepływ pozwala MCP wspierać zaawansowane, interaktywne i świadome kontekstu aplikacje AI poprzez bezproblemowe łączenie modeli z zewnętrznymi narzędziami i źródłami danych.

## Szczegóły protokołu

MCP (Model Context Protocol) jest zbudowany na bazie [JSON-RPC 2.0](https://www.jsonrpc.org/), dostarczając ustandaryzowany, niezależny od języka format wiadomości do komunikacji między hosts, clients i servers. Ta podstawa umożliwia niezawodne, ustrukturyzowane i rozszerzalne interakcje na różnych platformach i w różnych językach programowania.

### Kluczowe cechy protokołu

MCP rozszerza JSON-RPC 2.0 o dodatkowe konwencje dla wywołań narzędzi, dostępu do zasobów i zarządzania promptami. Obsługuje wiele warstw transportu (STDIO, WebSocket, SSE) i umożliwia bezpieczną, rozszerzalną oraz niezależną od języka komunikację między komponentami.

#### 🧢 Podstawowy protokół

- **Format wiadomości JSON-RPC**: Wszystkie żądania i odpowiedzi korzystają ze specyfikacji JSON-RPC 2.0, co zapewnia spójną strukturę wywołań metod, parametrów, wyników i obsługi błędów.
- **Połączenia stanowe**: Sesje MCP utrzymują stan między wieloma żądaniami, wspierając kontynuowane rozmowy, akumulację kontekstu i zarządzanie zasobami.
- **Negocjacja możliwości**: Podczas nawiązywania połączenia, klienci i serwery wymieniają informacje o obsługiwanych funkcjach, wersjach protokołu, dostępnych narzędziach i zasobach. Zapewnia to wzajemne zrozumienie i możliwość dostosowania.

#### ➕ Dodatkowe narzędzia

Poniżej znajdują się dodatkowe narzędzia i rozszerzenia protokołu, które MCP oferuje, aby poprawić doświadczenie deweloperów i umożliwić zaawansowane scenariusze:

- **Opcje konfiguracji**: MCP pozwala na dynamiczną konfigurację parametrów sesji, takich jak uprawnienia do narzędzi, dostęp do zasobów i ustawienia modelu, dostosowane do każdej interakcji.
- **Śledzenie postępu**: Operacje długotrwałe mogą raportować postęp, umożliwiając responsywne interfejsy użytkownika i lepsze doświadczenie podczas złożonych zadań.
- **Anulowanie żądań**: Klienci mogą anulować realizowane żądania, pozwalając użytkownikom przerwać operacje, które nie są już potrzebne lub zajmują zbyt dużo czasu.
- **Raportowanie błędów**: Ustandaryzowane komunikaty błędów i kody pomagają diagnozować problemy, obsługiwać awarie i dostarczać użytkownikom oraz deweloperom przydatne informacje zwrotne.
- **Logowanie**: Zarówno klienci, jak i serwery mogą emitować ustrukturyzowane logi do celów audytu, debugowania i monitorowania interakcji protokołu.

Wykorzystując te funkcje protokołu, MCP zapewnia solidną, bezpieczną i elastyczną komunikację między modelami językowymi a zewnętrznymi narzędziami lub źródłami danych.

### 🔐 Aspekty bezpieczeństwa

Implementacje MCP powinny przestrzegać kilku kluczowych zasad bezpieczeństwa, aby zapewnić bezpieczne i godne zaufania interakcje:

- **Zgoda i kontrola użytkownika**: Użytkownicy muszą wyrazić wyraźną zgodę przed dostępem do danych lub wykonaniem operacji. Powinni mieć jasną kontrolę nad tym, jakie dane są udostępniane i jakie działania są autoryzowane, wspieraną przez intuicyjne interfejsy do przeglądu i zatwierdzania działań.

- **Prywatność danych**: Dane użytkowników powinny być ujawniane tylko za wyraźną zgodą i chronione odpowiednimi mechanizmami kontroli dostępu. Implementacje MCP muszą zapobiegać nieautoryzowanemu przesyłaniu danych i zapewniać ochronę prywatności na wszystkich etapach interakcji.

- **Bezpieczeństwo narzędzi**: Przed wywołaniem narzędzia wymagana jest wyraźna zgoda użytkownika. Użytkownicy powinni mieć jasne zrozumienie funkcji każdego narzędzia, a granice bezpieczeństwa muszą być rygorystycznie egzekwowane, by zapobiegać niezamierzonemu lub niebezpiecznemu wykonaniu narzędzi.

Stosując się do tych zasad, MCP zapewnia utrzymanie zaufania, prywatności i bezpieczeństwa użytkowników we wszystkich interakcjach protokołu.

## Przykłady kodu: Kluczowe komponenty

Poniżej znajdują się przykłady kodu w kilku popularnych językach programowania, które ilustrują, jak zaimplementować kluczowe komponenty serwera MCP i narzędzia.

### Przykład .NET: Tworzenie prostego serwera MCP z narzędziami

Oto praktyczny przykład kodu .NET pokazujący, jak zaimplementować prosty serwer MCP z niestandardowymi narzędziami. Ten przykład demonstruje, jak definiować i rejestrować narzędzia, obsługiwać żądania oraz łączyć serwer za pomocą Model Context Protocol.

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

Ten przykład pokazuje ten sam serwer MCP i re

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być traktowany jako źródło wiążące. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.