<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:33:57+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ru"
}
-->
# HTTPS потоковая передача с протоколом Model Context Protocol (MCP)

В этой главе представлен подробный гид по реализации безопасной, масштабируемой и потоковой передачи данных в реальном времени с использованием протокола Model Context Protocol (MCP) через HTTPS. Рассматриваются мотивация для потоковой передачи, доступные механизмы транспорта, как реализовать потоковый HTTP в MCP, лучшие практики безопасности, миграция с SSE и практические рекомендации по созданию собственных потоковых приложений MCP.

## Механизмы транспорта и потоковая передача в MCP

В этом разделе рассматриваются различные механизмы транспорта, доступные в MCP, и их роль в обеспечении возможностей потоковой передачи для коммуникации в реальном времени между клиентами и серверами.

### Что такое механизм транспорта?

Механизм транспорта определяет, как данные обмениваются между клиентом и сервером. MCP поддерживает несколько типов транспорта, чтобы соответствовать разным средам и требованиям:

- **stdio**: стандартный ввод/вывод, подходит для локальных и CLI-инструментов. Простой, но не подходит для веба или облака.
- **SSE (Server-Sent Events)**: позволяет серверам отправлять обновления в реальном времени клиентам по HTTP. Хорош для веб-интерфейсов, но ограничен в масштабируемости и гибкости.
- **Streamable HTTP**: современный потоковый транспорт на базе HTTP, поддерживающий уведомления и лучшую масштабируемость. Рекомендуется для большинства производственных и облачных сценариев.

### Таблица сравнения

Посмотрите таблицу ниже, чтобы понять различия между этими механизмами транспорта:

| Транспорт        | Обновления в реальном времени | Потоковая передача | Масштабируемость | Сценарий использования     |
|------------------|-------------------------------|--------------------|------------------|----------------------------|
| stdio            | Нет                           | Нет                | Низкая           | Локальные CLI-инструменты  |
| SSE              | Да                            | Да                 | Средняя          | Веб, обновления в реальном времени |
| Streamable HTTP  | Да                            | Да                 | Высокая          | Облако, многопользовательские системы |

> **Совет:** Выбор правильного транспорта влияет на производительность, масштабируемость и удобство пользователя. **Streamable HTTP** рекомендуется для современных, масштабируемых и готовых к облаку приложений.

Обратите внимание на транспорты stdio и SSE, которые вы уже видели в предыдущих главах, и на то, что в этой главе рассматривается потоковый HTTP.

## Потоковая передача: концепции и мотивация

Понимание основных концепций и мотивации потоковой передачи важно для реализации эффективных систем коммуникации в реальном времени.

**Потоковая передача** — это техника в сетевом программировании, которая позволяет отправлять и получать данные небольшими, управляемыми порциями или в виде последовательности событий, а не ждать полной готовности всего ответа. Это особенно полезно для:

- Больших файлов или наборов данных.
- Обновлений в реальном времени (например, чат, индикаторы прогресса).
- Длительных вычислений, когда важно держать пользователя в курсе.

Вот что нужно знать о потоковой передаче в общих чертах:

- Данные доставляются постепенно, а не сразу целиком.
- Клиент может обрабатывать данные по мере их поступления.
- Снижает воспринимаемую задержку и улучшает пользовательский опыт.

### Зачем использовать потоковую передачу?

Причины использовать потоковую передачу следующие:

- Пользователи получают обратную связь сразу, а не только в конце.
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

В этом примере сервер отправляет клиенту серию сообщений по мере их готовности, а не ждёт, пока все сообщения будут готовы.

**Как это работает:**
- Сервер отдаёт каждое сообщение по мере готовности.
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`), а не обычный MCP транспорт.

- **Для простых потоковых задач:** классический HTTP-стриминг проще реализовать и достаточно для базовых потребностей.

- **Для сложных интерактивных приложений:** потоковая передача в MCP обеспечивает более структурированный подход с расширенными метаданными и разделением уведомлений и финальных результатов.

- **Для AI-приложений:** система уведомлений MCP особенно полезна для долгих AI-задач, когда важно информировать пользователя о ходе выполнения.

## Потоковая передача в MCP

Итак, вы уже видели рекомендации и сравнения классического стриминга и стриминга в MCP. Теперь рассмотрим подробнее, как именно использовать потоковую передачу в MCP.

Понимание того, как работает потоковая передача в рамках MCP, важно для создания отзывчивых приложений, которые предоставляют пользователю обратную связь в реальном времени во время длительных операций.

В MCP потоковая передача — это не отправка основного ответа частями, а отправка **уведомлений** клиенту во время обработки запроса инструментом. Эти уведомления могут включать обновления прогресса, логи или другие события.

### Как это работает

Основной результат всё равно отправляется одним ответом. Однако уведомления могут отправляться отдельными сообщениями во время обработки, обновляя клиента в реальном времени. Клиент должен уметь обрабатывать и отображать эти уведомления.

## Что такое уведомление?

Мы упомянули "уведомление" — что это значит в контексте MCP?

Уведомление — это сообщение от сервера клиенту, информирующее о прогрессе, статусе или других событиях во время длительной операции. Уведомления повышают прозрачность и улучшают пользовательский опыт.

Например, клиент должен отправить уведомление, когда выполнено начальное рукопожатие с сервером.

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

Для работы логирования сервер должен включить эту возможность как feature/capability следующим образом:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> В зависимости от используемого SDK логирование может быть включено по умолчанию, либо его нужно явно активировать в конфигурации сервера.

Существуют разные уровни уведомлений:

| Уровень   | Описание                      | Пример использования            |
|-----------|-------------------------------|--------------------------------|
| debug     | Подробная отладочная информация | Точки входа/выхода функций     |
| info      | Общие информационные сообщения | Обновления прогресса операции  |
| notice    | Обычные, но важные события     | Изменения конфигурации         |
| warning   | Предупреждения                 | Использование устаревших функций |
| error     | Ошибки                        | Сбои операций                  |
| critical  | Критические ошибки            | Отказы системных компонентов   |
| alert     | Требуется немедленное действие | Обнаружена порча данных        |
| emergency | Система недоступна            | Полный сбой системы            |

## Реализация уведомлений в MCP

Для реализации уведомлений в MCP необходимо настроить и серверную, и клиентскую части для обработки обновлений в реальном времени. Это позволяет вашему приложению предоставлять пользователям мгновенную обратную связь во время длительных операций.

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

В приведённом примере `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` транспорт:

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

В этом коде `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` — клиент реализует обработчик сообщений для обработки уведомлений.

## Уведомления о прогрессе и сценарии

В этом разделе объясняется концепция уведомлений о прогрессе в MCP, почему они важны и как реализовать их с помощью Streamable HTTP. Также приведено практическое задание для закрепления знаний.

Уведомления о прогрессе — это сообщения в реальном времени, отправляемые сервером клиенту во время длительных операций. Вместо того, чтобы ждать окончания всего процесса, сервер информирует клиента о текущем состоянии. Это повышает прозрачность, улучшает пользовательский опыт и облегчает отладку.

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
- **Обратная связь в реальном времени:** клиенты могут отображать индикаторы прогресса или логи, что делает приложение отзывчивым.
- **Проще отлаживать и мониторить:** разработчики и пользователи видят, где процесс может замедляться или застревать.

### Как реализовать уведомления о прогрессе

Вот как можно реализовать уведомления о прогрессе в MCP:

- **На сервере:** используйте `ctx.info()` or `ctx.log()`, чтобы отправлять уведомления по мере обработки каждого элемента. Это отправляет сообщения клиенту до готовности основного результата.
- **На клиенте:** реализуйте обработчик сообщений, который слушает и отображает уведомления по мере их поступления. Этот обработчик различает уведомления и финальный результат.

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

При реализации MCP-серверов с HTTP-транспортами безопасность становится критически важным аспектом, требующим внимания к множеству векторов атак и механизмов защиты.

### Обзор

Безопасность особенно важна при открытии MCP-серверов через HTTP. Streamable HTTP вводит новые точки уязвимости и требует тщательной настройки.

### Ключевые моменты
- **Проверка заголовка Origin**: всегда проверяйте заголовок `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` вместо SSE клиента.
3. **Реализуйте обработчик сообщений** на клиенте для обработки уведомлений.
4. **Проверьте совместимость** с существующими инструментами и рабочими процессами.

### Поддержание совместимости

Рекомендуется сохранять совместимость с существующими SSE-клиентами в процессе миграции. Вот несколько стратегий:

- Можно поддерживать одновременно SSE и Streamable HTTP, запуская оба транспорта на разных эндпоинтах.
- Постепенно мигрировать клиентов на новый транспорт.

### Сложности

При миграции нужно учитывать следующие сложности:

- Обновление всех клиентов
- Обработка различий в доставке уведомлений

### Задание: Создайте собственное потоковое приложение MCP

**Сценарий:**
Создайте MCP-сервер и клиент, где сервер обрабатывает список элементов (например, файлов или документов) и отправляет уведомление для каждого обработанного элемента. Клиент должен отображать каждое уведомление по мере поступления.

**Шаги:**

1. Реализуйте серверный инструмент, который обрабатывает список и отправляет уведомления для каждого элемента.
2. Реализуйте клиент с обработчиком сообщений для отображения уведомлений в реальном времени.
3. Проверьте свою реализацию, запустив сервер и клиент, и наблюдайте уведомления.

[Решение](./solution/README.md)

## Дополнительная литература и что дальше?

Чтобы продолжить изучение потоковой передачи в MCP и расширить свои знания, в этом разделе приведены дополнительные ресурсы и рекомендации по следующим шагам для создания более продвинутых приложений.

### Дополнительная литература

- [Microsoft: Введение в HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS в ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: потоковые запросы](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Что дальше?

- Попробуйте создавать более сложные инструменты MCP, использующие потоковую передачу для аналитики в реальном времени, чата или совместного редактирования.
- Изучите интеграцию потоковой передачи MCP с фронтенд-фреймворками (React, Vue и др.) для живых обновлений интерфейса.
- Далее: [Использование AI Toolkit для VSCode](../07-aitk/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, имейте в виду, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для критически важной информации рекомендуется использовать профессиональный перевод, выполненный человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.