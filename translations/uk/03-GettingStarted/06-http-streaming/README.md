<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:35:48+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "uk"
}
-->
# HTTPS потокова передача з Model Context Protocol (MCP)

У цій главі наведено детальний посібник з впровадження безпечної, масштабованої та реального часу потокової передачі з Model Context Protocol (MCP) через HTTPS. Розглядаються мотивація потокової передачі, доступні транспортні механізми, як реалізувати потоковий HTTP у MCP, найкращі практики безпеки, міграція з SSE та практичні рекомендації для створення власних потокових додатків MCP.

## Транспортні механізми та потокова передача в MCP

У цьому розділі розглядаються різні транспортні механізми, доступні в MCP, та їх роль у забезпеченні можливостей потокової передачі для реального часу взаємодії між клієнтами та серверами.

### Що таке транспортний механізм?

Транспортний механізм визначає, як дані обмінюються між клієнтом і сервером. MCP підтримує кілька типів транспорту, щоб відповідати різним середовищам і вимогам:

- **stdio**: стандартний ввід/вивід, підходить для локальних інструментів та командного рядка. Простіший, але не підходить для вебу чи хмари.
- **SSE (Server-Sent Events)**: дозволяє серверам надсилати клієнтам оновлення в реальному часі через HTTP. Добре підходить для веб-інтерфейсів, але має обмеження в масштабованості та гнучкості.
- **Streamable HTTP**: сучасний HTTP-базований транспорт для потокової передачі, що підтримує сповіщення та кращу масштабованість. Рекомендується для більшості виробничих і хмарних сценаріїв.

### Таблиця порівняння

Ознайомтеся з таблицею порівняння нижче, щоб зрозуміти відмінності між цими транспортними механізмами:

| Транспорт         | Оновлення в реальному часі | Потокова передача | Масштабованість | Сценарій використання     |
|-------------------|----------------------------|-------------------|-----------------|--------------------------|
| stdio             | Ні                         | Ні                | Низька         | Локальні CLI-інструменти  |
| SSE               | Так                        | Так               | Середня        | Веб, оновлення в реальному часі |
| Streamable HTTP   | Так                        | Так               | Висока         | Хмара, мультиклієнтські додатки |

> **Порада:** Вибір правильного транспорту впливає на продуктивність, масштабованість і користувацький досвід. **Streamable HTTP** рекомендується для сучасних, масштабованих і готових до хмари додатків.

Зверніть увагу на транспорти stdio і SSE, які ви бачили в попередніх главах, і на те, що в цій главі розглядається транспорт Streamable HTTP.

## Потокова передача: концепції та мотивація

Розуміння основних концепцій і мотивації, що стоять за потоковою передачею, є необхідним для впровадження ефективних систем комунікації в реальному часі.

**Потокова передача** — це техніка в мережевому програмуванні, яка дозволяє надсилати і отримувати дані маленькими, керованими частинами або послідовністю подій, замість того, щоб чекати на готовність всієї відповіді. Це особливо корисно для:

- Великих файлів або наборів даних.
- Оновлень у реальному часі (наприклад, чат, індикатори прогресу).
- Довготривалих обчислень, коли потрібно інформувати користувача про стан.

Ось що потрібно знати про потокову передачу на високому рівні:

- Дані доставляються поступово, а не всі одразу.
- Клієнт може обробляти дані по мірі їх надходження.
- Зменшує сприйману затримку і покращує користувацький досвід.

### Чому варто використовувати потокову передачу?

Причини для використання потокової передачі такі:

- Користувачі отримують зворотний зв’язок одразу, а не лише в кінці.
- Дозволяє створювати реальні час додатки та чутливі інтерфейси.
- Ефективніше використовує мережеві та обчислювальні ресурси.

### Простий приклад: HTTP потоковий сервер і клієнт

Ось простий приклад реалізації потокової передачі:

<details>
<summary>Python</summary>

**Сервер (Python, використання FastAPI і StreamingResponse):**
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

**Клієнт (Python, використання requests):**
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

Цей приклад демонструє сервер, який надсилає серію повідомлень клієнту по мірі їх готовності, замість того, щоб чекати, поки всі повідомлення будуть готові.

**Як це працює:**
- Сервер віддає кожне повідомлення по мірі його готовності.
- Клієнт отримує та виводить кожен фрагмент по мірі надходження.

**Вимоги:**
- Сервер має використовувати потокову відповідь (наприклад, `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) замість вибору потоковості через MCP.

- **Для простих потреб потокової передачі:** класичний HTTP-потік простіший у реалізації і достатній для базових випадків.

- **Для складних, інтерактивних додатків:** потокова передача MCP забезпечує більш структурований підхід із багатшими метаданими та розділенням між сповіщеннями та кінцевими результатами.

- **Для AI-додатків:** система сповіщень MCP особливо корисна для довготривалих AI-завдань, де важливо інформувати користувачів про прогрес.

## Потокова передача в MCP

Отже, ви вже бачили деякі рекомендації та порівняння класичної потокової передачі та потокової передачі в MCP. Тепер розглянемо докладно, як саме можна використовувати потокову передачу в MCP.

Розуміння того, як працює потокова передача у рамках MCP, є ключовим для створення чутливих додатків, які надають зворотний зв’язок у реальному часі під час довготривалих операцій.

У MCP потокова передача полягає не в тому, щоб надсилати основну відповідь частинами, а в тому, щоб надсилати **сповіщення** клієнту під час обробки запиту інструментом. Ці сповіщення можуть містити оновлення прогресу, логи або інші події.

### Як це працює

Основний результат все одно надсилається як єдина відповідь. Однак сповіщення можуть надсилатися окремими повідомленнями під час обробки, оновлюючи клієнта в реальному часі. Клієнт повинен вміти обробляти та відображати ці сповіщення.

## Що таке сповіщення?

Ми згадали "сповіщення", що це означає у контексті MCP?

Сповіщення — це повідомлення, яке сервер надсилає клієнту, щоб інформувати про прогрес, статус або інші події під час довготривалої операції. Сповіщення підвищують прозорість і покращують користувацький досвід.

Наприклад, клієнт має надіслати сповіщення після успішного встановлення початкового з’єднання з сервером.

Сповіщення виглядає як JSON-повідомлення:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Сповіщення належать до теми в MCP, яка називається ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Щоб увімкнути логування, сервер має активувати цю функцію/можливість таким чином:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Залежно від використаного SDK, логування може бути ввімкнене за замовчуванням або його потрібно явно активувати в конфігурації сервера.

Існують різні типи сповіщень:

| Рівень    | Опис                         | Приклад використання          |
|-----------|------------------------------|------------------------------|
| debug     | Детальна інформація для відладки | Точки входу/виходу функцій   |
| info      | Загальні інформаційні повідомлення | Оновлення прогресу операції  |
| notice    | Звичайні, але значущі події  | Зміни конфігурації           |
| warning   | Попереджувальні умови        | Використання застарілих функцій |
| error     | Помилки                      | Збої операцій                |
| critical  | Критичні умови               | Збої системних компонентів   |
| alert     | Потрібна негайна дія         | Виявлення пошкодження даних  |
| emergency | Система непрацездатна        | Повний збій системи          |

## Реалізація сповіщень у MCP

Щоб реалізувати сповіщення в MCP, потрібно налаштувати як серверну, так і клієнтську частини для обробки оновлень у реальному часі. Це дозволяє вашому додатку надавати миттєвий зворотний зв’язок користувачам під час довготривалих операцій.

### Серверна частина: надсилання сповіщень

Почнемо із серверної сторони. У MCP ви визначаєте інструменти, які можуть надсилати сповіщення під час обробки запитів. Сервер використовує об’єкт контексту (зазвичай `ctx`), щоб надсилати повідомлення клієнту.

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

### Клієнтська частина: отримання сповіщень

Клієнт має реалізувати обробник повідомлень, щоб обробляти та відображати сповіщення по мірі їх надходження.

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) клієнт реалізує обробник повідомлень для обробки сповіщень.

## Сповіщення про прогрес і сценарії

У цьому розділі пояснюється концепція сповіщень про прогрес у MCP, чому вони важливі і як їх реалізувати за допомогою Streamable HTTP. Також тут є практичне завдання для закріплення знань.

Сповіщення про прогрес — це повідомлення в реальному часі, які сервер надсилає клієнту під час довготривалих операцій. Замість того, щоб чекати завершення всього процесу, сервер постійно інформує клієнта про поточний стан. Це підвищує прозорість, покращує користувацький досвід і полегшує налагодження.

**Приклад:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Чому варто використовувати сповіщення про прогрес?

Сповіщення про прогрес важливі з кількох причин:

- **Кращий користувацький досвід:** користувачі бачать оновлення під час виконання, а не лише в кінці.
- **Зворотний зв’язок у реальному часі:** клієнти можуть відображати індикатори прогресу або логи, що робить додаток більш чутливим.
- **Полегшення налагодження та моніторингу:** розробники та користувачі можуть бачити, де процес може сповільнюватися або застрягати.

### Як реалізувати сповіщення про прогрес

Ось як можна реалізувати сповіщення про прогрес у MCP:

- **На сервері:** використовуйте `ctx.info()` or `ctx.log()`, щоб надсилати сповіщення по мірі обробки кожного елемента. Це надсилає повідомлення клієнту до того, як буде готовий основний результат.
- **На клієнті:** реалізуйте обробник повідомлень, який слухає та відображає сповіщення по мірі їх надходження. Цей обробник розрізняє сповіщення і кінцевий результат.

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

При впровадженні MCP серверів із HTTP-базованими транспортами безпека стає найважливішим аспектом, що вимагає уважності до різних векторів атак і механізмів захисту.

### Огляд

Безпека критично важлива при відкритті MCP серверів через HTTP. Streamable HTTP вводить нові вектори атак і потребує ретельного налаштування.

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
3. **Реалізуйте обробник повідомлень** у клієнті для обробки сповіщень.
4. **Перевірте сумісність** з існуючими інструментами та робочими процесами.

### Підтримка сумісності

Рекомендується підтримувати сумісність із існуючими SSE клієнтами під час процесу міграції. Ось деякі стратегії:

- Ви можете підтримувати одночасно SSE і Streamable HTTP, запускаючи обидва транспорти на різних кінцевих точках.
- Поступово мігруйте клієнтів на новий транспорт.

### Виклики

Переконайтеся, що ви врахували наступні виклики під час міграції:

- Оновлення всіх клієнтів
- Обробка відмінностей у доставці сповіщень

### Завдання: Створіть власний потоковий MCP додаток

**Сценарій:**
Створіть MCP сервер і клієнт, де сервер обробляє список елементів (наприклад, файли або документи) і надсилає сповіщення для кожного обробленого елемента. Клієнт має відображати кожне сповіщення по мірі його надходження.

**Кроки:**

1. Реалізуйте серверний інструмент, який обробляє список і надсилає сповіщення для кожного елемента.
2. Реалізуйте клієнта з обробником повідомлень для відображення сповіщень у реальному часі.
3. Протестуйте реалізацію, запустивши сервер і клієнта, та спостерігайте за сповіщеннями.

[Solution](./solution/README.md)

## Подальше читання та що далі?

Щоб продовжити вивчення MCP потокової передачі та розширити свої знання, цей розділ пропонує додаткові ресурси та рекомендовані кроки для створення більш складних додатків.

### Подальше читання

- [Microsoft: Вступ до HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS в ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Потокові запити](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Що далі?

- Спробуйте створити більш просунуті MCP інструменти, які використовують потокову передачу для аналітики в реальному часі, чату або спільного редагування.


**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоч ми і прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння чи неправильні тлумачення, що виникли внаслідок використання цього перекладу.