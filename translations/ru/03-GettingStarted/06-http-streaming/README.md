<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:33:15+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ru"
}
-->
# HTTPS-потоковая передача с использованием Model Context Protocol (MCP)

В этой главе представлен подробный гид по реализации безопасной, масштабируемой и потоковой передачи данных в реальном времени с помощью Model Context Protocol (MCP) через HTTPS. Рассматриваются мотивация для потоковой передачи, доступные транспортные механизмы, как реализовать потоковый HTTP в MCP, лучшие практики безопасности, миграция с SSE и практические рекомендации по созданию собственных потоковых приложений MCP.

## Транспортные механизмы и потоковая передача в MCP

В этом разделе рассматриваются различные транспортные механизмы, доступные в MCP, и их роль в обеспечении потоковой передачи для связи в реальном времени между клиентами и серверами.

### Что такое транспортный механизм?

Транспортный механизм определяет, как данные обмениваются между клиентом и сервером. MCP поддерживает несколько типов транспорта, чтобы соответствовать разным средам и требованиям:

- **stdio**: стандартный ввод/вывод, подходит для локальных инструментов и командной строки. Простой, но не подходит для веба или облака.
- **SSE (Server-Sent Events)**: позволяет серверам отправлять клиентам обновления в реальном времени по HTTP. Хорош для веб-интерфейсов, но ограничен в масштабируемости и гибкости.
- **Streamable HTTP**: современный потоковый транспорт на основе HTTP, поддерживающий уведомления и лучшую масштабируемость. Рекомендуется для большинства производственных и облачных сценариев.

### Таблица сравнения

Посмотрите таблицу ниже, чтобы понять различия между этими транспортными механизмами:

| Транспорт        | Обновления в реальном времени | Потоковая передача | Масштабируемость | Сценарий использования    |
|------------------|-------------------------------|--------------------|------------------|---------------------------|
| stdio            | Нет                           | Нет                | Низкая           | Локальные инструменты CLI |
| SSE              | Да                            | Да                 | Средняя          | Веб, обновления в реальном времени |
| Streamable HTTP  | Да                            | Да                 | Высокая          | Облако, многоклиентские приложения |

> **Совет:** Выбор правильного транспорта влияет на производительность, масштабируемость и пользовательский опыт. Для современных, масштабируемых и готовых к облаку приложений рекомендуется использовать **Streamable HTTP**.

Обратите внимание на транспорты stdio и SSE, которые были рассмотрены в предыдущих главах, и на Streamable HTTP, который рассматривается в этой главе.

## Потоковая передача: концепции и мотивация

Понимание основных концепций и мотивации потоковой передачи важно для реализации эффективных систем связи в реальном времени.

**Потоковая передача** — это метод в сетевом программировании, который позволяет отправлять и получать данные небольшими, управляемыми частями или в виде последовательности событий, вместо того чтобы ждать полной готовности всего ответа. Это особенно полезно для:

- Больших файлов или наборов данных.
- Обновлений в реальном времени (например, чат, индикаторы прогресса).
- Долгих вычислений, когда нужно держать пользователя в курсе.

Основные моменты о потоковой передаче:

- Данные доставляются постепенно, а не сразу целиком.
- Клиент может обрабатывать данные по мере их поступления.
- Снижает воспринимаемую задержку и улучшает пользовательский опыт.

### Зачем использовать потоковую передачу?

Причины использовать потоковую передачу следующие:

- Пользователи получают обратную связь сразу, а не только по завершении.
- Позволяет создавать приложения в реальном времени и отзывчивые интерфейсы.
- Более эффективное использование сетевых и вычислительных ресурсов.

### Простой пример: HTTP-потоковый сервер и клиент

Вот простой пример реализации потоковой передачи:

<details>
<summary>Python</summary>

**Сервер (Python, используя FastAPI и StreamingResponse):**
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

**Клиент (Python, используя requests):**
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

Этот пример демонстрирует, как сервер отправляет клиенту серию сообщений по мере их готовности, а не ждёт, пока все сообщения будут сформированы.

**Как это работает:**
- Сервер отправляет каждое сообщение по мере его готовности.
- Клиент получает и выводит каждую часть по мере поступления.

**Требования:**
- Сервер должен использовать потоковый ответ (например, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Сервер (Java, используя Spring Boot и Server-Sent Events):**

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

**Клиент (Java, используя Spring WebFlux WebClient):**

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

**Примечания по реализации на Java:**
- Используется реактивный стек Spring Boot с `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) вместо выбора потоковой передачи через MCP.

- **Для простых потоковых задач:** классическая HTTP-потоковая передача проще в реализации и подходит для базовых сценариев.

- **Для сложных интерактивных приложений:** потоковая передача MCP предлагает более структурированный подход с расширенными метаданными и разделением уведомлений и окончательных результатов.

- **Для AI-приложений:** система уведомлений MCP особенно полезна для долгих AI-задач, когда важно держать пользователя в курсе прогресса.

## Потоковая передача в MCP

Итак, вы уже видели рекомендации и сравнения между классической потоковой передачей и потоковой передачей в MCP. Теперь рассмотрим подробно, как именно использовать потоковую передачу в MCP.

Понимание того, как работает потоковая передача в рамках MCP, необходимо для создания отзывчивых приложений, которые предоставляют пользователям обратную связь в реальном времени во время долгих операций.

В MCP потоковая передача — это не отправка основного ответа частями, а отправка **уведомлений** клиенту во время обработки запроса инструментом. Эти уведомления могут содержать обновления прогресса, логи или другие события.

### Как это работает

Основной результат всё ещё отправляется одним ответом. Однако уведомления могут отправляться отдельными сообщениями во время обработки, тем самым обновляя клиента в реальном времени. Клиент должен уметь принимать и отображать эти уведомления.

## Что такое уведомление?

Мы упомянули «уведомление», что это значит в контексте MCP?

Уведомление — это сообщение от сервера клиенту, информирующее о прогрессе, статусе или других событиях во время долгой операции. Уведомления повышают прозрачность и улучшают пользовательский опыт.

Например, клиент должен отправить уведомление после установления начального соединения с сервером.

Уведомление выглядит как JSON-сообщение:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Уведомления относятся к теме в MCP, называемой ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Чтобы включить логирование, серверу нужно активировать эту функцию/возможность следующим образом:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> В зависимости от используемого SDK, логирование может быть включено по умолчанию, или его нужно явно активировать в конфигурации сервера.

Существуют разные уровни уведомлений:

| Уровень   | Описание                     | Пример использования         |
|-----------|------------------------------|------------------------------|
| debug     | Подробная отладочная информация | Вход и выход из функций      |
| info      | Общие информационные сообщения | Обновления прогресса         |
| notice    | Обычные, но важные события   | Изменения конфигурации       |
| warning   | Предупреждающие условия      | Использование устаревших функций |
| error     | Ошибки                      | Сбои в работе                |
| critical  | Критические ошибки           | Отказы компонентов системы   |
| alert     | Требуется немедленное действие | Обнаружена порча данных      |
| emergency | Система недоступна           | Полный отказ системы         |

## Реализация уведомлений в MCP

Для реализации уведомлений в MCP необходимо настроить сервер и клиент для обработки обновлений в реальном времени. Это позволяет вашему приложению предоставлять мгновенную обратную связь пользователям во время долгих операций.

### На стороне сервера: отправка уведомлений

Начнём с сервера. В MCP вы определяете инструменты, которые могут отправлять уведомления во время обработки запросов. Сервер использует объект контекста (обычно `ctx`) для отправки сообщений клиенту.

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

В приведённом примере метод `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` транспорт:

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

В этом примере на .NET метод `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` используется для отправки информационных сообщений.

Чтобы включить уведомления в вашем MCP-сервере на .NET, убедитесь, что используется потоковый транспорт:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### На стороне клиента: получение уведомлений

Клиент должен реализовать обработчик сообщений, который будет обрабатывать и отображать уведомления по мере их поступления.

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

В приведённом коде `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` отвечает за обработку входящих уведомлений.

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

В этом примере на .NET `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) и клиент реализует обработчик сообщений для обработки уведомлений.

## Уведомления о прогрессе и сценарии

В этом разделе объясняется концепция уведомлений о прогрессе в MCP, почему они важны и как реализовать их с помощью Streamable HTTP. Также приведено практическое задание для закрепления знаний.

Уведомления о прогрессе — это сообщения в реальном времени, отправляемые сервером клиенту во время долгих операций. Вместо того чтобы ждать завершения всего процесса, сервер постоянно информирует клиента о текущем статусе. Это повышает прозрачность, улучшает пользовательский опыт и облегчает отладку.

**Пример:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Зачем нужны уведомления о прогрессе?

Уведомления о прогрессе важны по нескольким причинам:

- **Лучший пользовательский опыт:** пользователи видят обновления по мере выполнения работы, а не только в конце.
- **Обратная связь в реальном времени:** клиенты могут отображать индикаторы прогресса или логи, делая приложение отзывчивым.
- **Упрощение отладки и мониторинга:** разработчики и пользователи видят, где процесс может замедляться или застревать.

### Как реализовать уведомления о прогрессе

Вот как можно реализовать уведомления о прогрессе в MCP:

- **На сервере:** используйте `ctx.info()` or `ctx.log()` для отправки уведомлений по мере обработки каждого элемента. Это отправляет сообщение клиенту до готовности основного результата.
- **На клиенте:** реализуйте обработчик сообщений, который слушает и отображает уведомления по мере их поступления. Этот обработчик различает уведомления и окончательный результат.

**Пример сервера:**

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

**Пример клиента:**

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

## Вопросы безопасности

При реализации MCP-серверов с HTTP-транспортами безопасность становится первостепенной задачей, требующей внимания к множеству векторов атак и механизмов защиты.

### Обзор

Безопасность критична при открытии MCP-серверов по HTTP. Streamable HTTP вводит новые уязвимости и требует тщательной настройки.

### Основные моменты
- **Проверка заголовка Origin**: всегда проверяйте `Origin` для предотвращения CSRF-атак.
- **Использование HTTPS**: обязательное шифрование для защиты данных в пути.
- **Аутентификация и авторизация**: убедитесь, что только авторизованные пользователи имеют доступ к потокам.
- **Ограничение скорости и контроль ресурсов**: предотвращайте DoS-атаки.
- **Мониторинг и логирование**: отслеживайте подозрительную активность.

### Поддержание совместимости

Рекомендуется сохранять совместимость с существующими клиентами SSE в процессе миграции. Вот несколько стратегий:

- Можно поддерживать одновременно SSE и Streamable HTTP, запуская оба транспорта на разных конечных точках.
- Постепенно переводить клиентов на новый транспорт.

### Сложности

При миграции нужно учитывать:

- Обновление всех клиентов.
- Обработку различий в доставке уведомлений.

### Задание: Создайте собственное потоковое приложение MCP

**Сценарий:**
Создайте MCP-сервер и клиент, где сервер обрабатывает список элементов (например, файлов или документов) и отправляет уведомление для каждого обработанного элемента. Клиент должен отображать каждое уведомление по мере его поступления.

**Шаги:**

1. Реализуйте серверный инструмент, который обрабатывает список и отправляет уведомления по каждому элементу.
2. Реализуйте клиент с обработчиком сообщений для отображения уведомлений в реальном времени.
3. Протестируйте свою реализацию, запустив сервер и клиент, и наблюдайте уведомления.

[Решение](./solution/README.md)

## Дополнительные материалы и что дальше?

Чтобы продолжить изучение потоковой передачи в MCP и расширить свои знания, этот раздел предлагает дополнительные ресурсы и рекомендации по следующим шагам для создания более сложных приложений.

### Дополнительные материалы

- [Microsoft: Введение в HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS в ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Что дальше?

- Попробуйте создать более продвинутые инструменты MCP, использующие потоковую передачу для аналитики в реальном времени, чата или совместного редактирования.
- Изучите интеграцию MCP потоковой передачи с фронтенд-фреймворками (React, Vue и др.) для живого обновления интерфейса.
- Следующая тема: [Использование AI Toolkit для VSCode](../07-aitk/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, пожалуйста, имейте в виду, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.