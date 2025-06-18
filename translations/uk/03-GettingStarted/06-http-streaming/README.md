<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:41:19+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "uk"
}
-->
# HTTPS Стрімінг з Model Context Protocol (MCP)

Цей розділ містить детальний посібник з реалізації безпечного, масштабованого та реального часу стрімінгу за допомогою Model Context Protocol (MCP) через HTTPS. Тут розглядаються мотивація для стрімінгу, доступні транспортні механізми, як реалізувати стрімінг HTTP у MCP, найкращі практики безпеки, міграція з SSE, а також практичні поради для створення власних стрімінгових MCP-застосунків.

## Транспортні механізми та стрімінг у MCP

У цьому розділі розглядаються різні транспортні механізми, доступні в MCP, та їхня роль у забезпеченні можливостей стрімінгу для реального часу комунікації між клієнтами та серверами.

### Що таке транспортний механізм?

Транспортний механізм визначає, як дані обмінюються між клієнтом і сервером. MCP підтримує кілька типів транспорту, щоб відповідати різним середовищам і вимогам:

- **stdio**: стандартний ввід/вивід, підходить для локальних інструментів та CLI. Простий, але не підходить для вебу чи хмари.
- **SSE (Server-Sent Events)**: дозволяє серверам надсилати клієнтам оновлення в реальному часі через HTTP. Добре підходить для веб-інтерфейсів, але має обмеження в масштабованості та гнучкості.
- **Streamable HTTP**: сучасний стрімінговий транспорт на основі HTTP, що підтримує сповіщення та кращу масштабованість. Рекомендований для більшості продакшн та хмарних сценаріїв.

### Таблиця порівняння

Ознайомтеся з таблицею порівняння нижче, щоб зрозуміти відмінності між цими транспортними механізмами:

| Транспорт         | Оновлення в реальному часі | Стрімінг | Масштабованість | Сценарій використання    |
|-------------------|----------------------------|----------|-----------------|-------------------------|
| stdio             | Ні                         | Ні       | Низька          | Локальні CLI інструменти|
| SSE               | Так                        | Так      | Середня         | Веб, оновлення в реальному часі |
| Streamable HTTP   | Так                        | Так      | Висока          | Хмара, мультиклієнтські системи |

> [!TIP]
> Вибір правильного транспорту впливає на продуктивність, масштабованість та користувацький досвід. **Streamable HTTP** рекомендується для сучасних, масштабованих і готових до хмари застосунків.

Зверніть увагу на транспорти stdio і SSE, які ви бачили в попередніх розділах, а також на те, що Streamable HTTP є транспортом, що розглядається в цьому розділі.

## Стрімінг: концепції та мотивація

Розуміння основних концепцій і мотивацій стрімінгу є важливим для реалізації ефективних систем комунікації в реальному часі.

**Стрімінг** — це техніка в мережевому програмуванні, яка дозволяє надсилати та отримувати дані невеликими, керованими частинами або як послідовність подій, замість того, щоб чекати на повну відповідь. Це особливо корисно для:

- Великих файлів або наборів даних.
- Оновлень у реальному часі (наприклад, чат, індикатори прогресу).
- Довготривалих обчислень, коли потрібно тримати користувача в курсі.

Ось що варто знати про стрімінг на високому рівні:

- Дані доставляються поступово, а не всі одразу.
- Клієнт може обробляти дані по мірі їх надходження.
- Зменшує відчуття затримки та покращує користувацький досвід.

### Чому варто використовувати стрімінг?

Причини для використання стрімінгу:

- Користувачі отримують зворотний зв’язок одразу, а не тільки в кінці.
- Дозволяє створювати застосунки в реальному часі та чутливі інтерфейси.
- Ефективніше використовує мережеві та обчислювальні ресурси.

### Простий приклад: HTTP стрімінг сервер і клієнт

Ось простий приклад, як можна реалізувати стрімінг:

<details>
<summary>Python</summary>

**Сервер (Python, з використанням FastAPI та StreamingResponse):**
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

**Клієнт (Python, з використанням requests):**
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

Цей приклад демонструє, як сервер надсилає серію повідомлень клієнту по мірі їх готовності, а не чекає на підготовку всіх повідомлень.

**Як це працює:**
- Сервер видає кожне повідомлення, щойно воно готове.
- Клієнт приймає та виводить кожен фрагмент по мірі надходження.

**Вимоги:**
- Сервер має використовувати стрімінгову відповідь (наприклад, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Сервер (Java, з використанням Spring Boot та Server-Sent Events):**

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

**Клієнт (Java, з використанням Spring WebFlux WebClient):**

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

**Примітки до реалізації на Java:**
- Використовується реактивний стек Spring Boot з `Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) замість вибору стрімінгу через MCP.

- **Для простих потреб стрімінгу:** Класичний HTTP стрімінг простіший у реалізації і достатній для базових задач.

- **Для складних, інтерактивних застосунків:** Стрімінг MCP пропонує більш структурований підхід з багатшими метаданими та розділенням між сповіщеннями і кінцевими результатами.

- **Для AI-застосунків:** Система сповіщень MCP особливо корисна для довготривалих AI-задач, де потрібно тримати користувачів у курсі прогресу.

## Стрімінг у MCP

Отже, ви вже бачили деякі рекомендації та порівняння між класичним стрімінгом і стрімінгом у MCP. Тепер розглянемо детальніше, як саме можна використовувати стрімінг у MCP.

Розуміння того, як працює стрімінг у рамках MCP, є важливим для створення чутливих застосунків, які надають зворотний зв’язок у реальному часі під час довготривалих операцій.

У MCP стрімінг — це не надсилання основної відповіді частинами, а відправлення **сповіщень** клієнту під час обробки запиту інструментом. Ці сповіщення можуть містити оновлення прогресу, логи або інші події.

### Як це працює

Основний результат все одно надсилається одним повідомленням. Проте сповіщення можуть надсилатися окремими повідомленнями під час обробки, оновлюючи клієнта в реальному часі. Клієнт повинен вміти обробляти та відображати ці сповіщення.

## Що таке сповіщення?

Ми згадали "сповіщення", що це означає в контексті MCP?

Сповіщення — це повідомлення, яке сервер надсилає клієнту, щоб інформувати про прогрес, статус або інші події під час довготривалої операції. Сповіщення підвищують прозорість і покращують користувацький досвід.

Наприклад, клієнт повинен надіслати сповіщення після встановлення початкового з’єднання із сервером.

Сповіщення виглядає так у форматі JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Сповіщення належать до теми в MCP, що називається ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Щоб увімкнути логування, сервер повинен активувати цю функцію/можливість так:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Залежно від використовуваного SDK, логування може бути ввімкнене за замовчуванням, або ж його потрібно явно активувати у конфігурації сервера.

Існують різні типи сповіщень:

| Рівень     | Опис                         | Приклад використання            |
|------------|------------------------------|--------------------------------|
| debug      | Детальна інформація для налагодження | Вхід/вихід функцій             |
| info       | Загальні інформаційні повідомлення | Оновлення прогресу операції    |
| notice     | Звичайні, але важливі події  | Зміни конфігурації             |
| warning    | Попереджувальні умови        | Використання застарілих функцій|
| error      | Помилки                      | Збої операцій                  |
| critical   | Критичні умови               | Збої компонентів системи       |
| alert      | Потрібно негайно вжити заходів | Виявлено пошкодження даних    |
| emergency  | Система непридатна до роботи | Повний збій системи            |

## Реалізація сповіщень у MCP

Щоб реалізувати сповіщення у MCP, потрібно налаштувати як серверну, так і клієнтську частини для обробки оновлень у реальному часі. Це дозволить вашому застосунку надавати миттєвий зворотний зв’язок користувачам під час довготривалих операцій.

### Серверна частина: Надсилання сповіщень

Почнемо з серверної сторони. У MCP ви визначаєте інструменти, які можуть надсилати сповіщення під час обробки запитів. Сервер використовує об’єкт контексту (зазвичай `ctx`) для надсилання повідомлень клієнту.

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

У наведеному прикладі метод `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` використовується для надсилання інформаційних повідомлень.

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

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

У цьому прикладі на .NET метод `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` використовується для надсилання інформаційних повідомлень.

Щоб увімкнути сповіщення на вашому MCP-сервері .NET, переконайтеся, що ви використовуєте стрімінговий транспорт:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Клієнтська частина: Отримання сповіщень

Клієнт повинен реалізувати обробник повідомлень, щоб обробляти і відображати сповіщення по мірі їх надходження.

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

У наведеному коді `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` відповідає за обробку вхідних сповіщень.

</details>

<details>
<summary>.NET</summary>

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

У цьому прикладі на .NET `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) і ваш клієнт реалізує обробник повідомлень для обробки сповіщень.

## Сповіщення про прогрес і сценарії використання

Цей розділ пояснює концепцію сповіщень про прогрес у MCP, чому вони важливі та як реалізувати їх за допомогою Streamable HTTP. Також тут наведено практичне завдання для закріплення знань.

Сповіщення про прогрес — це повідомлення в реальному часі, які сервер надсилає клієнту під час довготривалих операцій. Замість того, щоб чекати на завершення процесу, сервер постійно інформує клієнта про поточний стан. Це покращує прозорість, користувацький досвід і спрощує налагодження.

**Приклад:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Чому варто використовувати сповіщення про прогрес?

Сповіщення про прогрес важливі з кількох причин:

- **Кращий користувацький досвід:** Користувачі бачать оновлення під час роботи, а не тільки в кінці.
- **Зворотний зв’язок у реальному часі:** Клієнти можуть відображати індикатори прогресу або логи, роблячи застосунок більш чутливим.
- **Простота налагодження та моніторингу:** Розробники та користувачі можуть бачити, де процес може уповільнюватися або зависати.

### Як реалізувати сповіщення про прогрес

Ось як можна реалізувати сповіщення про прогрес у MCP:

- **На сервері:** Використовуйте `ctx.info()` or `ctx.log()` для надсилання сповіщень по мірі обробки кожного елемента. Це надсилає повідомлення клієнту до того, як буде готовий основний результат.
- **На клієнті:** Реалізуйте обробник повідомлень, який слухає і відображає сповіщення по мірі їх надходження. Цей обробник розрізняє сповіщення та кінцевий результат.

**Приклад сервера:**

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

**Приклад клієнта:**

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

## Питання безпеки

При реалізації MCP-серверів із HTTP-транспортами безпека стає ключовим аспектом, що вимагає уваги до різних векторів атак і механізмів захисту.

### Огляд

Безпека критично важлива при відкритті MCP-серверів через HTTP. Streamable HTTP вводить нові вектори атак і потребує ретельного налаштування.

### Основні моменти
- **Перевірка заголовка Origin**: Завжди перевіряйте `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` замість SSE клієнта.
3. **Реалізуйте обробник повідомлень** на клієнті для обробки сповіщень.
4. **Перевірте сумісність** з існуючими інструментами та робочими процесами.

### Підтримка сумісності

Рекомендується підтримувати сумісність із існуючими SSE-клієнтами під час міграції. Ось кілька стратегій:

- Ви можете підтримувати одночасно SSE і Streamable HTTP, запустивши обидва транспорти на різних кінцевих точках.
- Поступово мігруйте клієнтів на новий транспорт.

### Виклики

Переконайтеся, що ви врахували такі виклики під час міграції:

- Забезпечення оновлення всіх клієнтів
- Обробка відмінностей у доставці сповіщень

### Завдання: Створіть власний MCP-застосунок зі стрімінгом

**Сценарій:**
Створіть MCP-сервер і клієнт, де сервер обробляє список елементів (наприклад, файлів чи документів) і надсилає сповіщення про кожен оброблений елемент. Клієнт повинен відображати кожне сповіщення по мірі надходження.

**Кроки:**

1. Реалізуйте серверний інструмент, який обробляє список і надсилає сповіщення для кожного елемента.
2. Реалізуйте клієнта з обробником повідомлень для відображення сповіщень у реальному часі.
3. Перевірте реалізацію, запустивши сервер і клієнта, і спостерігайте за

**Відмова від відповідальності**:  
Цей документ був перекладений за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, просимо враховувати, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.