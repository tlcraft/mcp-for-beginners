<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-17T16:42:33+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "uk"
}
-->
# HTTPS Стрімінг із Протоколом Контексту Моделі (MCP)

Цей розділ містить детальний посібник з впровадження безпечного, масштабованого та реального часу стрімінгу за допомогою Протоколу Контексту Моделі (MCP) через HTTPS. Тут розглядаються мотивація для стрімінгу, доступні транспортні механізми, як реалізувати стрімінг HTTP у MCP, кращі практики безпеки, міграція зі SSE та практичні поради для створення власних стрімінгових додатків MCP.

## Транспортні Механізми та Стрімінг у MCP

У цьому розділі досліджуються різні транспортні механізми, доступні в MCP, та їхня роль у забезпеченні можливостей стрімінгу для реального часу зв’язку між клієнтами та серверами.

### Що таке транспортний механізм?

Транспортний механізм визначає, як обмінюються дані між клієнтом і сервером. MCP підтримує кілька типів транспорту, щоб відповідати різним середовищам і вимогам:

- **stdio**: Стандартний ввід/вивід, підходить для локальних та CLI-інструментів. Простий, але не підходить для вебу чи хмари.
- **SSE (Server-Sent Events)**: Дозволяє серверам надсилати оновлення в реальному часі клієнтам через HTTP. Добре для веб-інтерфейсів, але обмежений у масштабованості та гнучкості.
- **Streamable HTTP**: Сучасний стрімінговий транспорт на базі HTTP, що підтримує сповіщення та кращу масштабованість. Рекомендується для більшості продакшн та хмарних сценаріїв.

### Таблиця порівняння

Ознайомтеся з таблицею порівняння нижче, щоб зрозуміти відмінності між цими транспортними механізмами:

| Транспорт        | Оновлення в реальному часі | Стрімінг | Масштабованість | Випадок використання       |
|------------------|----------------------------|----------|-----------------|----------------------------|
| stdio            | Ні                         | Ні       | Низька         | Локальні CLI-інструменти   |
| SSE              | Так                        | Так      | Середня        | Веб, оновлення в реальному часі |
| Streamable HTTP  | Так                        | Так      | Висока         | Хмара, мультиклієнтські системи |

> **Порада:** Вибір правильного транспорту впливає на продуктивність, масштабованість і користувацький досвід. **Streamable HTTP** рекомендується для сучасних, масштабованих і готових до хмари додатків.

Зверніть увагу на транспорти stdio та SSE, які були показані у попередніх розділах, а також на те, що Streamable HTTP є транспортом, який розглядається в цьому розділі.

## Стрімінг: Концепції та Мотивація

Розуміння основних концепцій і мотивації стрімінгу є необхідним для впровадження ефективних систем зв’язку в реальному часі.

**Стрімінг** — це техніка в мережевому програмуванні, яка дозволяє надсилати і отримувати дані невеликими, керованими частинами або як послідовність подій, замість того, щоб чекати на повну готовність відповіді. Це особливо корисно для:

- Великих файлів або наборів даних.
- Оновлень у реальному часі (наприклад, чат, індикатори прогресу).
- Довготривалих обчислень, коли потрібно інформувати користувача про хід виконання.

Ось що варто знати про стрімінг на високому рівні:

- Дані доставляються поступово, а не всі одразу.
- Клієнт може обробляти дані по мірі їх надходження.
- Зменшує відчутну затримку і покращує користувацький досвід.

### Чому варто використовувати стрімінг?

Причини використання стрімінгу такі:

- Користувачі отримують зворотній зв’язок одразу, а не тільки в кінці.
- Дозволяє створювати додатки в реальному часі та чутливі інтерфейси.
- Ефективніше використовує мережеві та обчислювальні ресурси.

### Простий приклад: HTTP стрімінговий сервер і клієнт

Ось простий приклад реалізації стрімінгу:

<details>
<summary>Python</summary>

**Сервер (Python, використовуючи FastAPI та StreamingResponse):**
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

**Клієнт (Python, використовуючи requests):**
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

Цей приклад демонструє, як сервер надсилає серію повідомлень клієнту по мірі їх готовності, замість того, щоб чекати на всі повідомлення.

**Як це працює:**
- Сервер передає кожне повідомлення, щойно воно готове.
- Клієнт отримує та виводить кожен фрагмент по мірі надходження.

**Вимоги:**
- Сервер має використовувати стрімінгову відповідь (наприклад, `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) замість вибору стрімінгу через MCP.

- **Для простих потреб стрімінгу:** Класичний HTTP стрімінг простіший у реалізації і достатній для базових випадків.

- **Для складних інтерактивних додатків:** Стрімінг MCP пропонує більш структурований підхід із багатшою метаданою та розділенням між сповіщеннями і кінцевими результатами.

- **Для AI-додатків:** Система сповіщень MCP особливо корисна для довготривалих AI-завдань, коли потрібно інформувати користувачів про прогрес.

## Стрімінг у MCP

Отже, ви вже бачили деякі рекомендації та порівняння класичного стрімінгу і стрімінгу в MCP. Тепер розглянемо детально, як саме можна використовувати стрімінг у MCP.

Розуміння того, як працює стрімінг у рамках MCP, є ключовим для створення чутливих додатків, які надають зворотний зв’язок у реальному часі під час довготривалих операцій.

У MCP стрімінг — це не про надсилання основної відповіді частинами, а про відправлення **сповіщень** клієнту під час обробки запиту інструментом. Ці сповіщення можуть містити оновлення прогресу, логи або інші події.

### Як це працює

Основний результат все ще надсилається як єдина відповідь. Однак сповіщення можуть надсилатися окремими повідомленнями під час обробки, оновлюючи клієнта в реальному часі. Клієнт повинен мати змогу обробляти та відображати ці сповіщення.

## Що таке сповіщення?

Ми згадали «сповіщення», що це означає в контексті MCP?

Сповіщення — це повідомлення, яке сервер надсилає клієнту, щоб інформувати про прогрес, стан або інші події під час довготривалої операції. Сповіщення підвищують прозорість і покращують користувацький досвід.

Наприклад, клієнт має надіслати сповіщення після встановлення початкового з’єднання з сервером.

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

Щоб увімкнути логування, сервер повинен активувати цю функцію/можливість таким чином:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Залежно від використовуваного SDK, логування може бути ввімкнено за замовчуванням, або його потрібно явно активувати в конфігурації сервера.

Існують різні типи сповіщень:

| Рівень     | Опис                           | Приклад використання             |
|------------|--------------------------------|---------------------------------|
| debug      | Детальна інформація для налагодження | Входи/виходи функцій             |
| info       | Загальні інформаційні повідомлення | Оновлення прогресу операції      |
| notice     | Звичайні, але важливі події     | Зміни конфігурації               |
| warning    | Попереджувальні умови           | Використання застарілих функцій  |
| error      | Помилки                        | Збої операції                   |
| critical   | Критичні умови                 | Збої компонентів системи         |
| alert      | Необхідна негайна дія           | Виявлено пошкодження даних       |
| emergency  | Система непридатна до роботи    | Повний збій системи              |

## Реалізація сповіщень у MCP

Щоб реалізувати сповіщення в MCP, потрібно налаштувати як серверну, так і клієнтську частини для обробки оновлень у реальному часі. Це дозволить вашому додатку надавати миттєвий зворотній зв’язок користувачам під час довготривалих операцій.

### Серверна частина: Надсилання сповіщень

Почнемо з серверної частини. У MCP ви визначаєте інструменти, які можуть надсилати сповіщення під час обробки запитів. Сервер використовує об’єкт контексту (зазвичай `ctx`), щоб надсилати повідомлення клієнту.

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

У наведеному прикладі `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` транспорт:

```python
mcp.run(transport="streamable-http")
```

</details>

### Клієнтська частина: Отримання сповіщень

Клієнт повинен реалізувати обробник повідомлень, щоб обробляти та відображати сповіщення по мірі їх надходження.

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

У наведеному коді `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) — ваш клієнт реалізує обробник повідомлень для обробки сповіщень.

## Сповіщення про прогрес та сценарії

У цьому розділі пояснюється концепція сповіщень про прогрес у MCP, чому вони важливі та як їх реалізувати за допомогою Streamable HTTP. Також тут є практичне завдання для закріплення знань.

Сповіщення про прогрес — це повідомлення в реальному часі, які сервер надсилає клієнту під час довготривалих операцій. Замість того, щоб чекати на завершення всього процесу, сервер постійно інформує клієнта про поточний стан. Це підвищує прозорість, покращує користувацький досвід і полегшує налагодження.

**Приклад:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Чому варто використовувати сповіщення про прогрес?

Сповіщення про прогрес важливі з кількох причин:

- **Кращий користувацький досвід:** Користувачі бачать оновлення у міру виконання роботи, а не тільки в кінці.
- **Зворотній зв’язок у реальному часі:** Клієнти можуть відображати індикатори прогресу або логи, що робить додаток більш чутливим.
- **Полегшене налагодження та моніторинг:** Розробники і користувачі можуть бачити, де процес може затримуватися або зупинятися.

### Як реалізувати сповіщення про прогрес

Ось як можна реалізувати сповіщення про прогрес у MCP:

- **На сервері:** Використовуйте `ctx.info()` or `ctx.log()`, щоб надсилати сповіщення під час обробки кожного елемента. Це надсилає повідомлення клієнту до того, як буде готовий основний результат.
- **На клієнті:** Реалізуйте обробник повідомлень, який слухає та відображає сповіщення по мірі їх надходження. Цей обробник розрізняє сповіщення і кінцевий результат.

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

При впровадженні MCP-серверів із HTTP-транспортом безпека стає надзвичайно важливою і вимагає уважного розгляду різних векторів атак і механізмів захисту.

### Огляд

Безпека критично важлива при відкритті MCP-серверів через HTTP. Streamable HTTP вводить нові потенційні вразливості і потребує ретельного налаштування.

### Ключові моменти
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
2. **Update client code** to use `streamablehttp_client` замість клієнта SSE.
3. **Реалізуйте обробник повідомлень** у клієнті для обробки сповіщень.
4. **Перевірте сумісність** з існуючими інструментами та робочими процесами.

### Підтримка сумісності

Рекомендується підтримувати сумісність із існуючими SSE-клієнтами під час процесу міграції. Ось деякі стратегії:

- Ви можете підтримувати одночасно SSE і Streamable HTTP, запускаючи обидва транспорти на різних кінцевих точках.
- Поступово мігруйте клієнтів на новий транспорт.

### Виклики

Під час міграції слід врахувати такі виклики:

- Забезпечення оновлення всіх клієнтів.
- Обробка відмінностей у доставці сповіщень.

### Завдання: Створіть власний MCP-додаток зі стрімінгом

**Сценарій:**
Створіть MCP-сервер і клієнт, де сервер обробляє список елементів (наприклад, файли або документи) і надсилає сповіщення про обробку кожного елемента. Клієнт повинен відображати кожне сповіщення по мірі його надходження.

**Кроки:**

1. Реалізуйте серверний інструмент, який обробляє список і надсилає сповіщення для кожного елемента.
2. Реалізуйте клієнта з обробником повідомлень для відображення сповіщень у реальному часі.
3. Перевірте реалізацію, запустивши сервер і клієнт, та спостерігайте за сповіщеннями.

[Розв’язок](./solution/README.md)

## Подальше читання та що далі?

Щоб продовжити роботу зі стрімінгом MCP і розширити свої знання, цей розділ надає додаткові ресурси та пропозиції для створення більш складних додатків.

### Подальше читання

- [Microsoft: Вступ до HTTP стрімінгу](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS в ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Стрімінгові запити](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Що далі?

- Спр

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння чи неправильні тлумачення, що виникли внаслідок використання цього перекладу.