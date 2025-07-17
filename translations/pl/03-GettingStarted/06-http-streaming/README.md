<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "40b1bbffdb8ce6812bf6e701cad876b6",
  "translation_date": "2025-07-17T18:31:51+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "pl"
}
-->
# HTTPS Streaming z Model Context Protocol (MCP)

Ten rozdział zawiera kompleksowy przewodnik po implementacji bezpiecznego, skalowalnego i działającego w czasie rzeczywistym streamingu z wykorzystaniem Model Context Protocol (MCP) przez HTTPS. Omawia motywację do streamingu, dostępne mechanizmy transportu, jak zaimplementować streamowalny HTTP w MCP, najlepsze praktyki bezpieczeństwa, migrację z SSE oraz praktyczne wskazówki dotyczące tworzenia własnych aplikacji streamingowych MCP.

## Mechanizmy transportu i streaming w MCP

W tej sekcji przyjrzymy się różnym mechanizmmom transportu dostępnym w MCP oraz ich roli w umożliwianiu streamingu dla komunikacji w czasie rzeczywistym między klientami a serwerami.

### Czym jest mechanizm transportu?

Mechanizm transportu definiuje sposób wymiany danych między klientem a serwerem. MCP obsługuje różne typy transportu, aby dopasować się do różnych środowisk i wymagań:

- **stdio**: Standardowe wejście/wyjście, odpowiednie dla narzędzi lokalnych i CLI. Proste, ale nie nadaje się do weba czy chmury.
- **SSE (Server-Sent Events)**: Pozwala serwerom wysyłać aktualizacje w czasie rzeczywistym do klientów przez HTTP. Dobre dla interfejsów webowych, ale ograniczone pod względem skalowalności i elastyczności.
- **Streamable HTTP**: Nowoczesny transport streamingowy oparty na HTTP, wspierający powiadomienia i lepszą skalowalność. Zalecany dla większości produkcyjnych i chmurowych zastosowań.

### Tabela porównawcza

Spójrz na poniższą tabelę, aby zrozumieć różnice między tymi mechanizmami transportu:

| Transport         | Aktualizacje w czasie rzeczywistym | Streaming | Skalowalność | Przypadek użycia          |
|-------------------|------------------------------------|-----------|--------------|---------------------------|
| stdio             | Nie                                | Nie       | Niska        | Narzędzia lokalne CLI     |
| SSE               | Tak                                | Tak       | Średnia      | Web, aktualizacje w czasie rzeczywistym |
| Streamable HTTP   | Tak                                | Tak       | Wysoka       | Chmura, wielu klientów    |

> **Tip:** Wybór odpowiedniego transportu wpływa na wydajność, skalowalność i doświadczenie użytkownika. **Streamable HTTP** jest zalecany dla nowoczesnych, skalowalnych i gotowych na chmurę aplikacji.

Zwróć uwagę na transporty stdio i SSE, które poznawałeś w poprzednich rozdziałach oraz na to, że streamowalny HTTP jest tematem tego rozdziału.

## Streaming: koncepcje i motywacja

Zrozumienie podstawowych koncepcji i motywacji stojących za streamingiem jest kluczowe dla skutecznej implementacji systemów komunikacji w czasie rzeczywistym.

**Streaming** to technika w programowaniu sieciowym, która pozwala na wysyłanie i odbieranie danych w małych, łatwych do zarządzania fragmentach lub jako sekwencja zdarzeń, zamiast czekać na gotową całą odpowiedź. Jest to szczególnie przydatne dla:

- Dużych plików lub zbiorów danych.
- Aktualizacji w czasie rzeczywistym (np. czat, paski postępu).
- Długotrwałych obliczeń, gdzie chcemy informować użytkownika na bieżąco.

Oto, co warto wiedzieć o streamingu na wysokim poziomie:

- Dane są dostarczane stopniowo, nie wszystkie naraz.
- Klient może przetwarzać dane w miarę ich napływania.
- Zmniejsza odczuwalne opóźnienia i poprawia doświadczenie użytkownika.

### Dlaczego warto używać streamingu?

Powody stosowania streamingu to:

- Użytkownicy otrzymują natychmiastową informację zwrotną, nie tylko na końcu.
- Umożliwia aplikacje w czasie rzeczywistym i responsywne UI.
- Bardziej efektywne wykorzystanie zasobów sieci i obliczeń.

### Prosty przykład: serwer i klient HTTP streamingowy

Oto prosty przykład implementacji streamingu:

## Python

**Serwer (Python, używając FastAPI i StreamingResponse):**

### Python

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```


**Klient (Python, używając requests):**

### Python

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```


Ten przykład pokazuje serwer wysyłający serię wiadomości do klienta w miarę ich dostępności, zamiast czekać na wszystkie wiadomości.

**Jak to działa:**
- Serwer zwraca każdą wiadomość, gdy jest gotowa.
- Klient odbiera i wyświetla każdą część w momencie jej nadejścia.

**Wymagania:**
- Serwer musi używać odpowiedzi streamingowej (np. `StreamingResponse` w FastAPI).
- Klient musi przetwarzać odpowiedź jako strumień (`stream=True` w requests).
- Content-Type to zwykle `text/event-stream` lub `application/octet-stream`.

## Java

**Serwer (Java, używając Spring Boot i Server-Sent Events):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**Klient (Java, używając Spring WebFlux WebClient):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Uwagi do implementacji w Javie:**
- Używa reaktywnego stosu Spring Boot z `Flux` do streamingu
- `ServerSentEvent` zapewnia strukturalny streaming zdarzeń z typami zdarzeń
- `WebClient` z `bodyToFlux()` umożliwia reaktywne przetwarzanie streamingu
- `delayElements()` symuluje czas przetwarzania między zdarzeniami
- Zdarzenia mogą mieć typy (`info`, `result`) dla lepszej obsługi po stronie klienta


### Porównanie: klasyczny streaming vs streaming MCP

Różnice między klasycznym streamingiem a streamingiem w MCP można przedstawić tak:

| Cecha                  | Klasyczny HTTP Streaming         | Streaming MCP (Powiadomienia)     |
|------------------------|---------------------------------|----------------------------------|
| Główna odpowiedź       | Podzielona na fragmenty          | Pojedyncza, na końcu             |
| Aktualizacje postępu   | Wysyłane jako fragmenty danych   | Wysyłane jako powiadomienia      |
| Wymagania klienta      | Musi przetwarzać strumień        | Musi implementować handler wiadomości |
| Przypadek użycia       | Duże pliki, strumienie tokenów AI| Postęp, logi, informacje w czasie rzeczywistym |

### Kluczowe różnice

Dodatkowo, oto kilka kluczowych różnic:

- **Wzorzec komunikacji:**
   - Klasyczny HTTP streaming: używa prostego kodowania transferu chunked do wysyłania danych w kawałkach
   - Streaming MCP: używa strukturalnego systemu powiadomień z protokołem JSON-RPC

- **Format wiadomości:**
   - Klasyczny HTTP: zwykły tekst z podziałem na linie
   - MCP: strukturalne obiekty LoggingMessageNotification z metadanymi

- **Implementacja klienta:**
   - Klasyczny HTTP: prosty klient przetwarzający odpowiedzi streamingowe
   - MCP: bardziej zaawansowany klient z handlerem wiadomości do obsługi różnych typów wiadomości

- **Aktualizacje postępu:**
   - Klasyczny HTTP: postęp jest częścią głównego strumienia odpowiedzi
   - MCP: postęp jest wysyłany jako osobne powiadomienia, a główna odpowiedź przychodzi na końcu

### Rekomendacje

Oto kilka zaleceń dotyczących wyboru między klasycznym streamingiem (endpoint `/stream` pokazany powyżej) a streamingiem przez MCP:

- **Dla prostych potrzeb streamingowych:** Klasyczny HTTP streaming jest łatwiejszy do implementacji i wystarczający dla podstawowych zastosowań.

- **Dla złożonych, interaktywnych aplikacji:** Streaming MCP oferuje bardziej strukturalne podejście z bogatszymi metadanymi i rozdzieleniem powiadomień od wyników końcowych.

- **Dla aplikacji AI:** System powiadomień MCP jest szczególnie przydatny dla długotrwałych zadań AI, gdzie chcesz na bieżąco informować użytkowników o postępie.

## Streaming w MCP

Widziałeś już rekomendacje i porównania dotyczące różnic między klasycznym streamingiem a streamingiem w MCP. Teraz przejdźmy do szczegółów, jak dokładnie możesz wykorzystać streaming w MCP.

Zrozumienie, jak działa streaming w ramach MCP, jest kluczowe do budowania responsywnych aplikacji, które dostarczają użytkownikom informacje zwrotne w czasie rzeczywistym podczas długotrwałych operacji.

W MCP streaming nie polega na wysyłaniu głównej odpowiedzi w kawałkach, lecz na wysyłaniu **powiadomień** do klienta podczas przetwarzania żądania przez narzędzie. Powiadomienia mogą zawierać aktualizacje postępu, logi lub inne zdarzenia.

### Jak to działa

Główny wynik jest nadal wysyłany jako pojedyncza odpowiedź. Jednak powiadomienia mogą być wysyłane jako osobne wiadomości w trakcie przetwarzania, dzięki czemu klient jest na bieżąco informowany. Klient musi umieć obsłużyć i wyświetlić te powiadomienia.

## Czym jest powiadomienie?

Mówiliśmy o "powiadomieniu" – co to oznacza w kontekście MCP?

Powiadomienie to wiadomość wysyłana z serwera do klienta, informująca o postępie, statusie lub innych zdarzeniach podczas długotrwałej operacji. Powiadomienia zwiększają przejrzystość i poprawiają doświadczenie użytkownika.

Na przykład klient powinien wysłać powiadomienie po nawiązaniu początkowego połączenia z serwerem.

Powiadomienie wygląda tak jako wiadomość JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Powiadomienia należą do tematu w MCP określanego jako ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Aby włączyć logowanie, serwer musi aktywować tę funkcję/możliwość w następujący sposób:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> W zależności od używanego SDK, logowanie może być domyślnie włączone lub może wymagać jawnego aktywowania w konfiguracji serwera.

Istnieją różne typy powiadomień:

| Poziom     | Opis                          | Przykładowe zastosowanie        |
|------------|-------------------------------|--------------------------------|
| debug      | Szczegółowe informacje debugowania | Punkty wejścia/wyjścia funkcji |
| info       | Ogólne komunikaty informacyjne | Aktualizacje postępu operacji  |
| notice     | Normalne, ale istotne zdarzenia | Zmiany konfiguracji            |
| warning    | Warunki ostrzegawcze           | Użycie przestarzałej funkcji   |
| error      | Warunki błędów                 | Niepowodzenia operacji         |
| critical   | Warunki krytyczne              | Awaria komponentu systemu      |
| alert      | Konieczność natychmiastowego działania | Wykryto uszkodzenie danych   |
| emergency  | System jest nieużyteczny       | Całkowita awaria systemu       |


## Implementacja powiadomień w MCP

Aby zaimplementować powiadomienia w MCP, musisz skonfigurować zarówno serwer, jak i klienta do obsługi aktualizacji w czasie rzeczywistym. Pozwala to Twojej aplikacji na natychmiastowe informowanie użytkowników podczas długotrwałych operacji.

### Po stronie serwera: wysyłanie powiadomień

Zacznijmy od strony serwera. W MCP definiujesz narzędzia, które mogą wysyłać powiadomienia podczas przetwarzania żądań. Serwer używa obiektu kontekstu (zwykle `ctx`), aby wysyłać wiadomości do klienta.

### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

W powyższym przykładzie narzędzie `process_files` wysyła trzy powiadomienia do klienta podczas przetwarzania każdego pliku. Metoda `ctx.info()` służy do wysyłania komunikatów informacyjnych.

Dodatkowo, aby włączyć powiadomienia, upewnij się, że Twój serwer używa transportu streamingowego (np. `streamable-http`), a klient implementuje handler wiadomości do obsługi powiadomień. Oto jak skonfigurować serwer do używania transportu `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

### .NET

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

W tym przykładzie .NET narzędzie `ProcessFiles` jest oznaczone atrybutem `Tool` i wysyła trzy powiadomienia do klienta podczas przetwarzania każdego pliku. Metoda `ctx.Info()` służy do wysyłania komunikatów informacyjnych.

Aby włączyć powiadomienia w serwerze MCP .NET, upewnij się, że używasz transportu streamingowego:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

### Po stronie klienta: odbieranie powiadomień

Klient musi zaimplementować handler wiadomości, który będzie przetwarzał i wyświetlał powiadomienia w momencie ich nadejścia.

### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

W powyższym kodzie funkcja `message_handler` sprawdza, czy nadchodząca wiadomość jest powiadomieniem. Jeśli tak, wypisuje powiadomienie; w przeciwnym razie przetwarza je jako zwykłą wiadomość serwera. Zwróć też uwagę, że `ClientSession` jest inicjalizowana z `message_handler`, aby obsługiwać przychodzące powiadomienia.

### .NET

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

W tym przykładzie .NET funkcja `MessageHandler` sprawdza, czy nadchodząca wiadomość jest powiadomieniem. Jeśli tak, wypisuje powiadomienie; w przeciwnym razie przetwarza je jako zwykłą wiadomość serwera. `ClientSession` jest inicjalizowana z handlerem wiadomości przez `ClientSessionOptions`.

Aby włączyć powiadomienia, upewnij się, że Twój serwer używa transportu streamingowego (np. `streamable-http`), a klient implementuje handler wiadomości do obsługi powiadomień.

## Powiadomienia o postępie i scenariusze

Ta sekcja wyjaśnia koncepcję powiadomień o postępie w MCP, dlaczego są ważne i jak je zaimplementować za pomocą Streamable HTTP. Znajdziesz tu także praktyczne zadanie, które pomoże utrwalić wiedzę.

Powiadomienia o postępie to wiadomości wysyłane w czasie rzeczywistym z serwera do klienta podczas długotrwałych operacji. Zamiast czekać na zakończenie całego procesu, serwer na bieżąco informuje klienta o aktualnym statusie. Poprawia to przejrzystość, doświadczenie użytkownika i ułatwia debugowanie.

**Przykład:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Dlaczego warto używać powiadomień o postępie?

Powiadomienia o postępie są ważne z kilku powodów:

- **Lepsze doświadczenie użytkownika:** Użytkownicy widzą aktualizacje w trakcie pracy, a nie tylko na końcu.
- **Informacja zwrotna w czasie rzeczywistym:** Klient może wyświetlać paski postępu lub logi, co sprawia, że aplikacja jest bardziej responsywna.
- **Łatwiejsze debugowanie i monitorowanie:** Deweloperzy i użytkownicy mogą zobaczyć, gdzie proces może się opóźniać lub utknąć.

### Jak zaimplementować powiadomienia o postępie

Oto jak możesz zaimplementować powiadomienia o postępie w MCP:

- **Po stronie serwera:** Używaj `ctx.info()` lub `ctx.log()`, aby wysyłać powiadomienia podczas przetwarzania każdego elementu. Wysyła to wiadomość do klienta przed gotowym wynikiem.
- **Po stronie klienta:** Zaimplementuj handler wiadomości, który nasłuchuje i wyświetla powiadomienia w momencie ich nadejścia. Handler rozróżnia powiadomienia i wynik końcowy.

**Przykład serwera:**

## Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```


**Przykład klienta:**

### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```


## Aspekty bezpieczeństwa

Podczas implementacji serwerów MCP z transportami opartymi na HTTP, bezpieczeństwo staje się kluczową kwestią wymagającą uwagi na wiele wektorów ataku i mechanizmów ochronnych.

### Przegląd

Bezpieczeństwo jest krytyczne przy udostępnianiu serwerów MCP przez HTTP. Streamable HTTP wprowadza nowe powierzchnie ataku i wymaga starannej konfiguracji.

### Kluczowe punkty
- **Walidacja nagłówka Origin**: Zawsze weryfikuj nagłówek `Origin`, aby zapobiec atakom DNS rebinding.
- **Więzywanie do localhost**: Podczas lokalnego rozwoju wiąż serwery do `localhost`, aby nie były dostępne publicznie.
- **Uwierzytelnianie**: Wdrażaj uwierzytelnianie (np. klucze API, OAuth) w środowiskach produkcyjnych.

### Dlaczego warto zaktualizować?

Istnieją dwa ważne powody, aby przejść z SSE na Streamable HTTP:

- Streamable HTTP oferuje lepszą skalowalność, kompatybilność oraz bogatsze wsparcie powiadomień niż SSE.
- Jest to zalecany transport dla nowych aplikacji MCP.

### Kroki migracji

Oto jak możesz przeprowadzić migrację z SSE na Streamable HTTP w swoich aplikacjach MCP:

- **Zaktualizuj kod serwera**, aby używał `transport="streamable-http"` w `mcp.run()`.
- **Zaktualizuj kod klienta**, aby korzystał z `streamablehttp_client` zamiast klienta SSE.
- **Zaimplementuj obsługę wiadomości** w kliencie do przetwarzania powiadomień.
- **Przetestuj kompatybilność** z istniejącymi narzędziami i procesami.

### Utrzymanie kompatybilności

Zaleca się utrzymanie kompatybilności z istniejącymi klientami SSE podczas migracji. Oto kilka strategii:

- Możesz obsługiwać zarówno SSE, jak i Streamable HTTP, uruchamiając oba transporty na różnych endpointach.
- Stopniowo migruj klientów do nowego transportu.

### Wyzwania

Podczas migracji zwróć uwagę na następujące wyzwania:

- Zapewnienie aktualizacji wszystkich klientów
- Radzenie sobie z różnicami w dostarczaniu powiadomień

## Aspekty bezpieczeństwa

Bezpieczeństwo powinno być priorytetem przy implementacji każdego serwera, zwłaszcza gdy używa się transportów opartych na HTTP, takich jak Streamable HTTP w MCP.

Podczas implementacji serwerów MCP z transportami HTTP bezpieczeństwo staje się kluczową kwestią, wymagającą uwagi na różne wektory ataków i mechanizmy ochronne.

### Przegląd

Bezpieczeństwo jest kluczowe przy udostępnianiu serwerów MCP przez HTTP. Streamable HTTP wprowadza nowe powierzchnie ataku i wymaga starannej konfiguracji.

Oto najważniejsze kwestie związane z bezpieczeństwem:

- **Weryfikacja nagłówka Origin**: Zawsze sprawdzaj nagłówek `Origin`, aby zapobiec atakom DNS rebinding.
- **Powiązanie z localhost**: Podczas lokalnego rozwoju wiąż serwery z `localhost`, aby nie były dostępne publicznie.
- **Uwierzytelnianie**: Wdrażaj uwierzytelnianie (np. klucze API, OAuth) w środowiskach produkcyjnych.
- **CORS**: Konfiguruj polityki Cross-Origin Resource Sharing (CORS), aby ograniczyć dostęp.
- **HTTPS**: W środowisku produkcyjnym korzystaj z HTTPS do szyfrowania ruchu.

### Najlepsze praktyki

Dodatkowo, oto kilka najlepszych praktyk przy implementacji bezpieczeństwa w serwerze streamingowym MCP:

- Nigdy nie ufaj przychodzącym żądaniom bez weryfikacji.
- Loguj i monitoruj wszystkie dostępy oraz błędy.
- Regularnie aktualizuj zależności, aby załatać luki bezpieczeństwa.

### Wyzwania

Podczas wdrażania bezpieczeństwa w serwerach streamingowych MCP napotkasz następujące wyzwania:

- Zachowanie równowagi między bezpieczeństwem a łatwością rozwoju
- Zapewnienie kompatybilności z różnymi środowiskami klientów

### Zadanie: Zbuduj własną aplikację streamingową MCP

**Scenariusz:**  
Zbuduj serwer i klient MCP, gdzie serwer przetwarza listę elementów (np. plików lub dokumentów) i wysyła powiadomienie dla każdego przetworzonego elementu. Klient powinien wyświetlać każde powiadomienie w momencie jego nadejścia.

**Kroki:**

1. Zaimplementuj narzędzie serwerowe, które przetwarza listę i wysyła powiadomienia dla każdego elementu.
2. Zaimplementuj klienta z obsługą wiadomości, który wyświetla powiadomienia na żywo.
3. Przetestuj implementację, uruchamiając serwer i klienta, i obserwuj powiadomienia.

[Solution](./solution/README.md)

## Dalsza lektura i co dalej?

Aby kontynuować naukę o streamingu MCP i poszerzyć wiedzę, ta sekcja zawiera dodatkowe materiały oraz sugestie kolejnych kroków do tworzenia bardziej zaawansowanych aplikacji.

### Dalsza lektura

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Co dalej?

- Spróbuj zbudować bardziej zaawansowane narzędzia MCP wykorzystujące streaming do analiz w czasie rzeczywistym, czatu lub współdzielonej edycji.
- Zbadaj integrację streamingu MCP z frameworkami frontendowymi (React, Vue itp.) dla aktualizacji UI na żywo.
- Następny temat: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.