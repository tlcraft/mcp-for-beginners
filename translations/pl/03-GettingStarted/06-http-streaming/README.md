<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-12T22:18:36+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "pl"
}
-->
# HTTPS Streaming z Modelem Context Protocol (MCP)

Ten rozdział zawiera kompleksowy przewodnik dotyczący implementacji bezpiecznego, skalowalnego i działającego w czasie rzeczywistym streamingu z wykorzystaniem Model Context Protocol (MCP) przez HTTPS. Omawia motywację do streamingu, dostępne mechanizmy transportu, jak zaimplementować streamowalny HTTP w MCP, najlepsze praktyki bezpieczeństwa, migrację z SSE oraz praktyczne wskazówki do tworzenia własnych aplikacji streamingowych MCP.

## Mechanizmy Transportu i Streaming w MCP

W tej sekcji przyjrzymy się różnym dostępnym mechanizmmom transportu w MCP oraz ich roli w umożliwianiu streamingu dla komunikacji w czasie rzeczywistym między klientami a serwerami.

### Co to jest mechanizm transportu?

Mechanizm transportu określa, jak dane są wymieniane między klientem a serwerem. MCP obsługuje różne typy transportu, dopasowane do różnych środowisk i wymagań:

- **stdio**: standardowe wejście/wyjście, odpowiednie dla narzędzi lokalnych i CLI. Proste, ale nie nadaje się do weba czy chmury.
- **SSE (Server-Sent Events)**: pozwala serwerom wysyłać aktualizacje w czasie rzeczywistym do klientów przez HTTP. Dobre dla interfejsów webowych, ale ograniczone pod względem skalowalności i elastyczności.
- **Streamable HTTP**: nowoczesny transport streamingowy oparty na HTTP, wspierający powiadomienia i lepszą skalowalność. Zalecany dla większości zastosowań produkcyjnych i chmurowych.

### Tabela porównawcza

Spójrz na poniższą tabelę, aby zrozumieć różnice między tymi mechanizmami transportu:

| Transport         | Aktualizacje w czasie rzeczywistym | Streaming | Skalowalność | Przypadek użycia          |
|-------------------|-----------------------------------|-----------|--------------|---------------------------|
| stdio             | Nie                               | Nie       | Niska        | Narzędzia lokalne CLI     |
| SSE               | Tak                               | Tak       | Średnia      | Web, aktualizacje na żywo |
| Streamable HTTP   | Tak                               | Tak       | Wysoka       | Chmura, wielu klientów    |

> **Tip:** Wybór odpowiedniego transportu wpływa na wydajność, skalowalność i doświadczenie użytkownika. **Streamable HTTP** jest zalecany dla nowoczesnych, skalowalnych i gotowych na chmurę aplikacji.

Zwróć uwagę na transporty stdio i SSE omawiane w poprzednich rozdziałach oraz na streamowalny HTTP, który jest tematem tego rozdziału.

## Streaming: Pojęcia i motywacja

Zrozumienie podstawowych pojęć i motywacji stojących za streamingiem jest kluczowe dla efektywnej implementacji systemów komunikacji w czasie rzeczywistym.

**Streaming** to technika w programowaniu sieciowym pozwalająca na wysyłanie i odbieranie danych w małych, łatwych do zarządzania porcjach lub jako sekwencja zdarzeń, zamiast czekać na pełną odpowiedź. Jest to szczególnie przydatne w przypadku:

- dużych plików lub zbiorów danych,
- aktualizacji w czasie rzeczywistym (np. czat, paski postępu),
- długotrwałych obliczeń, gdzie chcemy informować użytkownika na bieżąco.

Oto najważniejsze informacje o streamingu w skrócie:

- Dane są dostarczane stopniowo, nie wszystkie naraz.
- Klient może przetwarzać dane na bieżąco.
- Zmniejsza postrzegane opóźnienie i poprawia doświadczenie użytkownika.

### Dlaczego warto używać streamingu?

Powody stosowania streamingu to:

- Użytkownicy otrzymują natychmiastową informację zwrotną, a nie tylko po zakończeniu procesu.
- Umożliwia tworzenie aplikacji działających w czasie rzeczywistym i responsywnych interfejsów.
- Bardziej efektywne wykorzystanie zasobów sieciowych i obliczeniowych.

### Prosty przykład: Serwer i klient HTTP Streaming

Oto prosty przykład implementacji streamingu:

<details>
<summary>Python</summary>

**Serwer (Python, używając FastAPI i StreamingResponse):**
<details>
<summary>Python</summary>

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

</details>

**Klient (Python, używając requests):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

Ten przykład pokazuje serwer wysyłający serię komunikatów do klienta w miarę ich dostępności, zamiast czekać na przygotowanie wszystkich wiadomości.

**Jak to działa:**
- Serwer zwraca każdą wiadomość w momencie jej gotowości.
- Klient odbiera i wyświetla każdą porcję danych na bieżąco.

**Wymagania:**
- Serwer musi korzystać ze streamowanej odpowiedzi (np. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) zamiast zwykłego wyboru streamingu przez MCP.

- **Dla prostych potrzeb streamingowych:** klasyczny HTTP streaming jest łatwiejszy do implementacji i wystarczający.
- **Dla bardziej złożonych, interaktywnych aplikacji:** streaming MCP oferuje bardziej uporządkowane podejście z bogatszymi metadanymi i rozdzieleniem powiadomień od ostatecznych wyników.
- **Dla aplikacji AI:** system powiadomień MCP jest szczególnie przydatny w długotrwałych zadaniach AI, gdzie chcemy informować użytkowników o postępach.

## Streaming w MCP

Do tej pory widziałeś rekomendacje i porównania między klasycznym streamingiem a streamingiem w MCP. Teraz przejdźmy do szczegółów, jak dokładnie możesz wykorzystać streaming w MCP.

Zrozumienie działania streamingu w ramach MCP jest kluczowe do budowania responsywnych aplikacji, które dostarczają użytkownikowi informacje zwrotne w czasie rzeczywistym podczas długotrwałych operacji.

W MCP streaming nie polega na wysyłaniu głównej odpowiedzi w kawałkach, lecz na przesyłaniu **powiadomień** do klienta w trakcie przetwarzania żądania przez narzędzie. Powiadomienia mogą zawierać aktualizacje postępu, logi lub inne zdarzenia.

### Jak to działa

Główny wynik jest nadal wysyłany jako pojedyncza odpowiedź. Jednak powiadomienia mogą być wysyłane jako oddzielne wiadomości podczas przetwarzania i dzięki temu na bieżąco aktualizować klienta. Klient musi być w stanie obsłużyć i wyświetlić te powiadomienia.

## Co to jest powiadomienie?

Powiedzieliśmy "Powiadomienie" – co to dokładnie oznacza w kontekście MCP?

Powiadomienie to wiadomość wysłana z serwera do klienta, informująca o postępie, statusie lub innych zdarzeniach podczas długotrwałej operacji. Powiadomienia zwiększają przejrzystość i poprawiają doświadczenie użytkownika.

Na przykład klient powinien wysłać powiadomienie, gdy zostanie nawiązane początkowe połączenie z serwerem.

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

Powiadomienia należą do tematu w MCP nazywanego ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Aby logging działał, serwer musi włączyć tę funkcję/możliwość w następujący sposób:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> W zależności od używanego SDK, logging może być domyślnie włączony lub trzeba go jawnie aktywować w konfiguracji serwera.

Istnieją różne typy powiadomień:

| Poziom     | Opis                          | Przykładowe zastosowanie       |
|------------|-------------------------------|-------------------------------|
| debug      | Szczegółowe informacje debugujące | Punkty wejścia/wyjścia funkcji |
| info       | Ogólne informacje             | Aktualizacje postępu operacji  |
| notice     | Normalne, ale istotne zdarzenia | Zmiany konfiguracji           |
| warning    | Warunki ostrzegawcze          | Użycie przestarzałych funkcji |
| error      | Warunki błędów                | Błędy operacji                |
| critical   | Warunki krytyczne             | Awaria komponentów systemu    |
| alert      | Natychmiastowa akcja wymagana | Wykryto uszkodzenie danych   |
| emergency  | System jest nieużywalny       | Całkowita awaria systemu      |

## Implementacja powiadomień w MCP

Aby zaimplementować powiadomienia w MCP, musisz przygotować zarówno serwer, jak i klienta do obsługi aktualizacji w czasie rzeczywistym. Pozwala to aplikacji dostarczać natychmiastową informację zwrotną podczas długotrwałych operacji.

### Po stronie serwera: wysyłanie powiadomień

Zacznijmy od strony serwera. W MCP definiujesz narzędzia, które mogą wysyłać powiadomienia podczas przetwarzania żądań. Serwer używa obiektu kontekstu (zwykle `ctx`), aby wysyłać wiadomości do klienta.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

W powyższym przykładzie transport `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

</details>

### Po stronie klienta: odbieranie powiadomień

Klient musi zaimplementować handler wiadomości, który będzie przetwarzał i wyświetlał powiadomienia w miarę ich nadejścia.

<details>
<summary>Python</summary>

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

W powyższym kodzie `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) oraz klient implementuje handler wiadomości do obsługi powiadomień.

## Powiadomienia o postępie i scenariusze

Ta sekcja wyjaśnia koncepcję powiadomień o postępie w MCP, dlaczego są ważne oraz jak je zaimplementować przy użyciu Streamable HTTP. Znajdziesz tu również praktyczne zadanie do utrwalenia wiedzy.

Powiadomienia o postępie to wiadomości wysyłane na bieżąco z serwera do klienta podczas długotrwałych operacji. Zamiast czekać na zakończenie całego procesu, serwer informuje klienta o aktualnym stanie. To zwiększa przejrzystość, poprawia doświadczenie użytkownika i ułatwia debugowanie.

**Przykład:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Dlaczego warto używać powiadomień o postępie?

Powiadomienia o postępie są ważne z kilku powodów:

- **Lepsze doświadczenie użytkownika:** użytkownicy widzą postęp pracy na bieżąco, nie tylko po zakończeniu.
- **Informacja zwrotna w czasie rzeczywistym:** klienci mogą wyświetlać paski postępu lub logi, co sprawia, że aplikacja wydaje się responsywna.
- **Łatwiejsze debugowanie i monitorowanie:** deweloperzy i użytkownicy widzą, gdzie proces może być wolny lub zablokowany.

### Jak zaimplementować powiadomienia o postępie

Oto jak możesz zaimplementować powiadomienia o postępie w MCP:

- **Po stronie serwera:** użyj `ctx.info()` or `ctx.log()`, aby wysyłać powiadomienia podczas przetwarzania kolejnych elementów. Wysyła to wiadomość do klienta zanim gotowy będzie główny wynik.
- **Po stronie klienta:** zaimplementuj handler wiadomości, który będzie nasłuchiwał i wyświetlał powiadomienia w czasie rzeczywistym. Handler rozróżnia powiadomienia i ostateczny wynik.

**Przykład serwera:**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**Przykład klienta:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## Aspekty bezpieczeństwa

Implementując serwery MCP z transportami opartymi na HTTP, bezpieczeństwo staje się kluczowym zagadnieniem wymagającym uwagi na różne wektory ataków i mechanizmy ochronne.

### Przegląd

Bezpieczeństwo jest krytyczne przy udostępnianiu serwerów MCP przez HTTP. Streamable HTTP wprowadza nowe powierzchnie ataku i wymaga starannej konfiguracji.

### Kluczowe kwestie
- **Walidacja nagłówka Origin**: zawsze sprawdzaj nagłówek `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` zamiast klienta SSE.
3. **Implementuj handler wiadomości** w kliencie do przetwarzania powiadomień.
4. **Testuj kompatybilność** z istniejącymi narzędziami i workflow.

### Utrzymanie kompatybilności

Zaleca się zachowanie kompatybilności z istniejącymi klientami SSE podczas migracji. Oto kilka strategii:

- Możesz obsługiwać jednocześnie SSE i Streamable HTTP, uruchamiając oba transporty na różnych endpointach.
- Stopniowo migruj klientów na nowy transport.

### Wyzwania

Podczas migracji należy zwrócić uwagę na:

- Zapewnienie aktualizacji wszystkich klientów
- Radzenie sobie z różnicami w dostarczaniu powiadomień

### Zadanie: Zbuduj własną aplikację streamingową MCP

**Scenariusz:**
Zbuduj serwer i klient MCP, gdzie serwer przetwarza listę elementów (np. plików lub dokumentów) i wysyła powiadomienie dla każdego przetworzonego elementu. Klient powinien wyświetlać każde powiadomienie w momencie jego nadejścia.

**Kroki:**

1. Zaimplementuj narzędzie serwera, które przetwarza listę i wysyła powiadomienia dla każdego elementu.
2. Zaimplementuj klienta z handlerem wiadomości, który wyświetla powiadomienia na żywo.
3. Przetestuj implementację, uruchamiając serwer i klienta, i obserwuj powiadomienia.

[Solution](./solution/README.md)

## Dalsza lektura i co dalej?

Aby kontynuować naukę o streamingu w MCP i poszerzyć wiedzę, ta sekcja oferuje dodatkowe zasoby i propozycje kolejnych kroków do tworzenia bardziej zaawansowanych aplikacji.

### Dalsza lektura

- [Microsoft: Wprowadzenie do HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS w ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Co dalej?

- Spróbuj tworzyć bardziej zaawansowane narzędzia MCP wykorzystujące streaming do analiz w czasie rzeczywistym, czatu lub współdzielonej edycji.
- Zbadaj integrację streamingu MCP z frameworkami frontendowymi (React, Vue itd.) dla aktualizacji UI na żywo.
- Następny krok: [Wykorzystanie AI Toolkit dla VSCode](../07-aitk/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uważany za autorytatywne źródło. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.