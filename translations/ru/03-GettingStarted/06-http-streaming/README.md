<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T21:53:17+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ru"
}
-->
# HTTPS потоковая передача с использованием Model Context Protocol (MCP)

В этой главе представлен подробный гид по реализации безопасной, масштабируемой и потоковой передачи данных в реальном времени с помощью Model Context Protocol (MCP) через HTTPS. Рассматриваются мотивация для потоковой передачи, доступные транспортные механизмы, как реализовать потоковый HTTP в MCP, лучшие практики безопасности, миграция с SSE и практические рекомендации по созданию собственных потоковых приложений MCP.

## Транспортные механизмы и потоковая передача в MCP

В этом разделе рассматриваются различные транспортные механизмы, доступные в MCP, и их роль в обеспечении потоковой передачи для связи в реальном времени между клиентами и серверами.

### Что такое транспортный механизм?

Транспортный механизм определяет, как данные передаются между клиентом и сервером. MCP поддерживает несколько типов транспорта, чтобы соответствовать различным условиям и требованиям:

- **stdio**: стандартный ввод/вывод, подходит для локальных и CLI-инструментов. Простой, но не подходит для веба или облака.
- **SSE (Server-Sent Events)**: позволяет серверам отправлять клиентам обновления в реальном времени по HTTP. Хорош для веб-интерфейсов, но ограничен в масштабируемости и гибкости.
- **Streamable HTTP**: современный транспорт на основе HTTP с поддержкой уведомлений и лучшей масштабируемостью. Рекомендуется для большинства производственных и облачных сценариев.

### Таблица сравнения

Посмотрите таблицу ниже, чтобы понять различия между этими транспортными механизмами:

| Транспорт         | Обновления в реальном времени | Потоковая передача | Масштабируемость | Сценарий использования       |
|-------------------|-------------------------------|--------------------|------------------|------------------------------|
| stdio             | Нет                           | Нет                | Низкая           | Локальные CLI-инструменты    |
| SSE               | Да                            | Да                 | Средняя          | Веб, обновления в реальном времени |
| Streamable HTTP   | Да                            | Да                 | Высокая          | Облако, многоклиентские системы |

> **Tip:** Выбор правильного транспорта влияет на производительность, масштабируемость и опыт пользователя. **Streamable HTTP** рекомендуется для современных, масштабируемых и облачных приложений.

Обратите внимание на транспорты stdio и SSE, которые были показаны в предыдущих главах, и на то, что в этой главе рассматривается транспорт Streamable HTTP.

## Потоковая передача: концепции и мотивация

Понимание основных концепций и причин использования потоковой передачи важно для реализации эффективных систем связи в реальном времени.

**Потоковая передача** — это техника в сетевом программировании, позволяющая отправлять и получать данные небольшими, удобными для обработки частями или как последовательность событий, вместо того чтобы ждать готовности всего ответа. Это особенно полезно для:

- Больших файлов или наборов данных.
- Обновлений в реальном времени (например, чат, индикаторы прогресса).
- Длительных вычислений, когда нужно информировать пользователя о ходе выполнения.

Вот что важно знать о потоковой передаче на высоком уровне:

- Данные поступают постепенно, а не сразу полностью.
- Клиент может обрабатывать данные по мере их поступления.
- Снижает воспринимаемую задержку и улучшает пользовательский опыт.

### Зачем использовать потоковую передачу?

Причины для использования потоковой передачи:

- Пользователь получает обратную связь сразу, а не только по завершении.
- Позволяет создавать приложения в реальном времени и отзывчивые интерфейсы.
- Более эффективное использование сетевых и вычислительных ресурсов.

### Простой пример: HTTP потоковый сервер и клиент

Вот простой пример реализации потоковой передачи:

<details>
<summary>Python</summary>

**Сервер (Python, с использованием FastAPI и StreamingResponse):**
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

**Клиент (Python, с использованием requests):**
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

Этот пример демонстрирует, как сервер отправляет серию сообщений клиенту по мере их готовности, а не ждёт, пока все сообщения будут готовы.

**Как это работает:**
- Сервер выдаёт каждое сообщение по мере его готовности.
- Клиент получает и выводит каждую часть по мере поступления.

**Требования:**
- Сервер должен использовать потоковый ответ (например, `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) вместо выбора потоковой передачи через MCP.

- **Для простых потоковых задач:** классический HTTP-поток проще в реализации и достаточно для базовых нужд.

- **Для сложных, интерактивных приложений:** потоковая передача MCP предоставляет более структурированный подход с расширенными метаданными и разделением уведомлений и конечных результатов.

- **Для AI-приложений:** система уведомлений MCP особенно полезна для длительных AI-задач, когда нужно информировать пользователя о ходе выполнения.

## Потоковая передача в MCP

Итак, вы уже видели рекомендации и сравнения классической потоковой передачи и потоковой передачи в MCP. Теперь рассмотрим подробно, как именно использовать потоковую передачу в MCP.

Понимание того, как работает потоковая передача в рамках MCP, важно для создания отзывчивых приложений, которые предоставляют обратную связь пользователям во время длительных операций.

В MCP потоковая передача — это не отправка основного ответа частями, а отправка **уведомлений** клиенту в процессе обработки запроса инструментом. Эти уведомления могут включать обновления прогресса, логи или другие события.

### Как это работает

Основной результат всё ещё отправляется одним ответом. Однако уведомления могут передаваться отдельными сообщениями во время обработки, тем самым обновляя клиента в реальном времени. Клиент должен уметь обрабатывать и отображать эти уведомления.

## Что такое уведомление?

Мы упомянули "уведомление" — что это значит в контексте MCP?

Уведомление — это сообщение от сервера клиенту, информирующее о ходе, статусе или других событиях во время длительной операции. Уведомления повышают прозрачность и улучшают пользовательский опыт.

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

Для работы логирования сервер должен включить эту функцию/возможность следующим образом:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> В зависимости от используемого SDK, логирование может быть включено по умолчанию, либо его нужно явно активировать в конфигурации сервера.

Существуют разные уровни уведомлений:

| Уровень    | Описание                         | Пример использования           |
|------------|---------------------------------|-------------------------------|
| debug      | Подробная отладочная информация | Вход/выход из функций          |
| info       | Общая информационная информация | Обновления прогресса операции  |
| notice     | Обычные, но важные события      | Изменения конфигурации         |
| warning    | Предупреждения                  | Использование устаревших функций |
| error      | Ошибки                         | Сбой операций                  |
| critical   | Критические ошибки             | Сбои компонентов системы       |
| alert      | Требуется немедленное действие | Обнаружена порча данных        |
| emergency  | Система неработоспособна       | Полный отказ системы           |

## Реализация уведомлений в MCP

Чтобы реализовать уведомления в MCP, необходимо настроить сервер и клиент для обработки обновлений в реальном времени. Это позволяет вашему приложению предоставлять мгновенную обратную связь пользователям во время длительных операций.

### Серверная часть: отправка уведомлений

Начнём с серверной части. В MCP вы определяете инструменты, которые могут отправлять уведомления во время обработки запросов. Сервер использует объект контекста (обычно `ctx`) для отправки сообщений клиенту.

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

В приведённом примере функция `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` использует транспорт:

```python
mcp.run(transport="streamable-http")
```

</details>

### Клиентская часть: получение уведомлений

Клиент должен реализовать обработчик сообщений для обработки и отображения уведомлений по мере их поступления.

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

В приведённом коде `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) — ваш клиент реализует обработчик сообщений для обработки уведомлений.

## Уведомления о прогрессе и сценарии использования

В этом разделе объясняется концепция уведомлений о прогрессе в MCP, почему они важны и как их реализовать с помощью Streamable HTTP. Также приведено практическое задание для закрепления знаний.

Уведомления о прогрессе — это сообщения в реальном времени, отправляемые сервером клиенту во время длительных операций. Вместо того чтобы ждать окончания процесса, сервер информирует клиента о текущем статусе. Это повышает прозрачность, улучшает пользовательский опыт и облегчает отладку.

**Пример:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Зачем нужны уведомления о прогрессе?

Уведомления о прогрессе важны по нескольким причинам:

- **Лучший пользовательский опыт:** пользователи видят обновления по мере выполнения работы, а не только по её завершении.
- **Обратная связь в реальном времени:** клиенты могут отображать индикаторы прогресса или логи, делая приложение отзывчивым.
- **Проще отлаживать и мониторить:** разработчики и пользователи видят, где процесс может замедляться или зависать.

### Как реализовать уведомления о прогрессе

Вот как можно реализовать уведомления о прогрессе в MCP:

- **На сервере:** используйте `ctx.info()` or `ctx.log()` для отправки уведомлений по мере обработки каждого элемента. Это отправляет сообщение клиенту до готовности основного результата.
- **На клиенте:** реализуйте обработчик сообщений, который слушает и отображает уведомления по мере их поступления. Обработчик должен отличать уведомления от финального результата.

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

При реализации MCP-серверов с HTTP-транспортом безопасность становится первостепенной задачей, требующей внимания к различным вектором атак и механизмам защиты.

### Обзор

Безопасность критична при открытии MCP-серверов через HTTP. Streamable HTTP добавляет новые потенциальные уязвимости и требует тщательной настройки.

### Основные моменты
- **Проверка заголовка Origin**: всегда проверяйте `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` вместо клиента SSE.
3. **Реализуйте обработчик сообщений** на клиенте для обработки уведомлений.
4. **Проверьте совместимость** с существующими инструментами и рабочими процессами.

### Поддержание совместимости

Рекомендуется сохранять совместимость с существующими SSE-клиентами в процессе миграции. Вот несколько стратегий:

- Можно поддерживать и SSE, и Streamable HTTP, запуская оба транспорта на разных эндпоинтах.
- Постепенно переводить клиентов на новый транспорт.

### Проблемы

Обратите внимание на следующие сложности при миграции:

- Обновление всех клиентов
- Обработка различий в доставке уведомлений

### Задание: Создайте своё потоковое MCP-приложение

**Сценарий:**
Создайте MCP-сервер и клиент, где сервер обрабатывает список элементов (например, файлов или документов) и отправляет уведомление для каждого обработанного элемента. Клиент должен отображать каждое уведомление по мере поступления.

**Шаги:**

1. Реализуйте серверный инструмент, который обрабатывает список и отправляет уведомления для каждого элемента.
2. Реализуйте клиент с обработчиком сообщений для отображения уведомлений в реальном времени.
3. Проверьте реализацию, запустив сервер и клиент, и наблюдайте уведомления.

[Решение](./solution/README.md)

## Дополнительная литература и что дальше?

Чтобы продолжить изучение потоковой передачи MCP и расширить свои знания, в этом разделе представлены дополнительные ресурсы и рекомендации по следующим шагам для создания более сложных приложений.

### Дополнительная литература

- [Microsoft: Введение в HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS в ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: потоковые запросы](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Что дальше?

- Попробуйте создавать более сложные инструменты MCP с использованием потоковой передачи для аналитики в реальном времени, чатов или совместного редактирования.
- Изучите интеграцию потоковой передачи MCP с фронтенд-фреймворками (React, Vue и др.) для живого обновления UI.
- Следующая тема: [Использование AI Toolkit для VSCode](../07-aitk/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, пожалуйста, имейте в виду, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.