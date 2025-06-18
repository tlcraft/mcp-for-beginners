<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:29:08+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "bg"
}
-->
# HTTPS стрийминг с Model Context Protocol (MCP)

Тази глава предоставя изчерпателно ръководство за реализиране на сигурен, мащабируем и реалновременен стрийминг с Model Context Protocol (MCP) чрез HTTPS. Обхваща мотивацията за стрийминг, наличните транспортни механизми, как да се реализира стрийминг HTTP в MCP, добри практики за сигурност, миграция от SSE и практически насоки за създаване на собствени стрийминг MCP приложения.

## Транспортни механизми и стрийминг в MCP

Този раздел разглежда различните транспортни механизми, налични в MCP, и тяхната роля за осигуряване на стрийминг възможности за реалновременна комуникация между клиенти и сървъри.

### Какво е транспортен механизъм?

Транспортният механизъм определя как се обменят данните между клиента и сървъра. MCP поддържа няколко типа транспорт, за да отговори на различни среди и изисквания:

- **stdio**: Стандартен вход/изход, подходящ за локални и CLI базирани инструменти. Прост, но неподходящ за уеб или облак.
- **SSE (Server-Sent Events)**: Позволява на сървърите да изпращат реалновременни актуализации към клиентите през HTTP. Подходящ за уеб интерфейси, но с ограничена мащабируемост и гъвкавост.
- **Streamable HTTP**: Модерен HTTP базиран стрийминг транспорт, поддържащ известия и по-добра мащабируемост. Препоръчва се за повечето производствени и облачни сценарии.

### Таблица за сравнение

Разгледайте таблицата по-долу, за да разберете разликите между тези транспортни механизми:

| Транспорт         | Реалновременни актуализации | Стрийминг | Мащабируемост | Приложение              |
|-------------------|-----------------------------|-----------|---------------|-------------------------|
| stdio             | Не                          | Не        | Ниска         | Локални CLI инструменти |
| SSE               | Да                          | Да        | Средна        | Уеб, реалновременни актуализации |
| Streamable HTTP   | Да                          | Да        | Висока        | Облак, мулти-клиент     |

> **Tip:** Изборът на правилния транспорт влияе върху производителността, мащабируемостта и потребителското изживяване. **Streamable HTTP** е препоръчителен за модерни, мащабируеми и облачно ориентирани приложения.

Обърнете внимание на транспортите stdio и SSE, които бяха показани в предишните глави, и как Streamable HTTP е транспортът, разгледан в тази глава.

## Стрийминг: Концепции и мотивация

Разбирането на основните концепции и мотивации зад стрийминга е важно за реализиране на ефективни системи за реалновременна комуникация.

**Стриймингът** е техника в мрежовото програмиране, която позволява данни да се изпращат и получават на малки, управляеми части или като последователност от събития, вместо да се чака цял отговор да бъде готов. Това е особено полезно за:

- Големи файлове или набори от данни.
- Реалновременни актуализации (напр. чат, индикатори за прогрес).
- Дълготрайни изчисления, при които искате да информирате потребителя.

Ето какво трябва да знаете за стрийминга на високо ниво:

- Данните се доставят постепенно, не наведнъж.
- Клиентът може да обработва данните веднага щом пристигнат.
- Намалява възприеманото забавяне и подобрява потребителското изживяване.

### Защо да използваме стрийминг?

Причините за използване на стрийминг са следните:

- Потребителите получават обратна връзка веднага, а не само накрая
- Позволява реалновременни приложения и отзивчиви интерфейси
- По-ефективно използване на мрежови и изчислителни ресурси

### Прост пример: HTTP стрийминг сървър и клиент

Ето един прост пример как може да се реализира стрийминг:

<details>
<summary>Python</summary>

**Сървър (Python, използващ FastAPI и StreamingResponse):**
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

**Клиент (Python, използващ requests):**
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

Този пример демонстрира сървър, който изпраща поредица от съобщения към клиента веднага щом са налични, вместо да чака всички съобщения да са готови.

**Как работи:**
- Сървърът изпраща всяко съобщение веднага щом е готово.
- Клиентът получава и отпечатва всяка част веднага щом пристигне.

**Изисквания:**
- Сървърът трябва да използва стрийминг отговор (например `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`), вместо да избира стрийминг чрез MCP.

- **За прости стрийминг нужди:** Класическият HTTP стрийминг е по-лесен за имплементиране и достатъчен за основни нужди.

- **За сложни, интерактивни приложения:** MCP стриймингът предоставя по-структуриран подход с по-богата метаданни и разделение между известия и крайни резултати.

- **За AI приложения:** Системата за известия на MCP е особено полезна за дълготрайни AI задачи, където искате да държите потребителите информирани за напредъка.

## Стрийминг в MCP

Добре, вече видяхте някои препоръки и сравнения за разликите между класическия стрийминг и стрийминга в MCP. Нека разгледаме подробно как точно можете да използвате стрийминг в MCP.

Разбирането как работи стриймингът в рамките на MCP е ключово за изграждането на отзивчиви приложения, които предоставят реалновременна обратна връзка на потребителите по време на дълготрайни операции.

В MCP стриймингът не означава изпращане на основния отговор на части, а изпращане на **известия** към клиента, докато инструментът обработва заявка. Тези известия могат да включват актуализации за напредъка, логове или други събития.

### Как работи

Основният резултат все още се изпраща като единен отговор. Въпреки това, известия могат да се изпращат като отделни съобщения по време на обработката и така да информират клиента в реално време. Клиентът трябва да може да обработва и показва тези известия.

## Какво е известие?

Казахме "известие", какво означава това в контекста на MCP?

Известие е съобщение, изпратено от сървъра към клиента, което информира за напредък, статус или други събития по време на дълготрайна операция. Известията повишават прозрачността и подобряват потребителското изживяване.

Например, клиент трябва да изпрати известие веднага щом първоначалният ръкостискане с сървъра е осъществен.

Известие изглежда така като JSON съобщение:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Известията принадлежат към тема в MCP, наречена ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

За да работи логването, сървърът трябва да го активира като функция/възможност по следния начин:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> В зависимост от използвания SDK, логването може да е активирано по подразбиране или да трябва да го включите изрично в конфигурацията на сървъра.

Има различни типове известия:

| Ниво      | Описание                     | Примерна употреба             |
|-----------|------------------------------|------------------------------|
| debug     | Подробна отстраняваща грешки информация | Вход/изход от функции        |
| info      | Общи информационни съобщения | Актуализации за напредък     |
| notice    | Нормални, но значими събития | Промени в конфигурацията     |
| warning   | Предупредителни състояния    | Използване на остаряла функция |
| error     | Състояния на грешки          | Неуспешни операции          |
| critical  | Критични състояния           | Повреди в системни компоненти |
| alert     | Незабавно действие е необходимо | Открити корупции на данни  |
| emergency | Системата е неизползваема    | Пълна системна повреда       |

## Реализиране на известия в MCP

За да реализирате известия в MCP, трябва да настроите както сървърната, така и клиентската страна да обработват реалновременни актуализации. Това позволява на приложението ви да дава незабавна обратна връзка на потребителите по време на дълготрайни операции.

### От страна на сървъра: Изпращане на известия

Нека започнем със сървърната страна. В MCP дефинирате инструменти, които могат да изпращат известия по време на обработка на заявки. Сървърът използва обекта контекст (обикновено `ctx`), за да изпраща съобщения към клиента.

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

В предишния пример, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` транспорт:

```python
mcp.run(transport="streamable-http")
```

</details>

### От страна на клиента: Получаване на известия

Клиентът трябва да реализира обработчик на съобщения, който да обработва и показва известията веднага щом пристигнат.

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

В горния код, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` и вашият клиент реализира обработчик на съобщения за обработка на известия.

## Известия за напредък и сценарии

Този раздел обяснява концепцията за известия за напредък в MCP, защо са важни и как да ги реализирате с помощта на Streamable HTTP. Също така ще намерите практическо задание за затвърждаване на знанията.

Известията за напредък са реалновременни съобщения, изпратени от сървъра към клиента по време на дълготрайни операции. Вместо да се чака процесът да завърши, сървърът държи клиента информиран за текущото състояние. Това повишава прозрачността, подобрява потребителското изживяване и улеснява отстраняването на грешки.

**Пример:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Защо да използваме известия за напредък?

Известията за напредък са важни по няколко причини:

- **По-добро потребителско изживяване:** Потребителите виждат актуализации в процеса на работа, а не само накрая.
- **Реалновременна обратна връзка:** Клиентите могат да показват ленти за напредък или логове, което прави приложението по-отзивчиво.
- **По-лесно отстраняване на грешки и мониторинг:** Разработчиците и потребителите могат да видят къде процесът се забавя или е блокиран.

### Как да реализираме известия за напредък

Ето как може да реализирате известия за напредък в MCP:

- **На сървъра:** Използвайте `ctx.info()` or `ctx.log()`, за да изпращате известия при обработка на всеки елемент. Това изпраща съобщение към клиента преди основния резултат да е готов.
- **На клиента:** Реализирайте обработчик на съобщения, който слуша и показва известията веднага щом пристигнат. Този обработчик разграничва известията от крайния резултат.

**Пример на сървър:**

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

**Пример на клиент:**

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

## Съображения за сигурност

При реализиране на MCP сървъри с HTTP базирани транспорти, сигурността е от първостепенно значение и изисква внимателно внимание към множество вектори на атака и защитни механизми.

### Преглед

Сигурността е критична при излагане на MCP сървъри през HTTP. Streamable HTTP въвежда нови повърхности за атака и изисква внимателна конфигурация.

### Ключови точки
- **Валидиране на Origin Header**: Винаги валидирайте `Origin` header to prevent DNS rebinding attacks.
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
3. **Реализирайте обработчик на съобщения** в клиента за обработка на известия.
4. **Тествайте съвместимостта** с наличните инструменти и работни потоци.

### Поддържане на съвместимост

Препоръчва се да се поддържа съвместимост с настоящите SSE клиенти по време на миграцията. Ето някои стратегии:

- Можете да поддържате както SSE, така и Streamable HTTP, като ги пуснете на различни крайни точки.
- Постепенно мигрирайте клиентите към новия транспорт.

### Предизвикателства

Уверете се, че сте адресирали следните предизвикателства по време на миграцията:

- Осигуряване, че всички клиенти са обновени
- Обработка на разлики в доставянето на известия

### Задание: Изградете собствено MCP стрийминг приложение

**Сценарий:**
Изградете MCP сървър и клиент, при които сървърът обработва списък с елементи (например файлове или документи) и изпраща известие за всеки обработен елемент. Клиентът трябва да показва всяко известие веднага щом пристигне.

**Стъпки:**

1. Реализирайте сървърен инструмент, който обработва списък и изпраща известия за всеки елемент.
2. Реализирайте клиент с обработчик на съобщения, който показва известията в реално време.
3. Тествайте реализацията като стартирате и сървъра, и клиента, и наблюдавайте известията.

[Решение](./solution/README.md)

## Допълнително четене и какво следва?

За да продължите пътя си със стрийминг в MCP и да разширите знанията си, този раздел предоставя допълнителни ресурси и предложения за следващи стъпки при изграждането на по-сложни приложения.

### Допълнително четене

- [Microsoft: Въведение в HTTP стрийминг](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS в ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Стрийминг заявки](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Какво следва?

- Опитайте да изградите по-сложни MCP инструменти, които използват стрийминг за реалновременна аналитика, чат или съвместно редактиране.
- Разгледайте интеграцията на MCP стрийминг с frontend фреймуърци (React, Vue и др.) за живи UI актуализации.
- Следващо: [Използване на AI Toolkit за VSCode](../07-aitk/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия оригинален език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, възникнали от използването на този превод.