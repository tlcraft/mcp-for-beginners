<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:54:14+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "bg"
}
-->
# HTTPS стрийминг с Model Context Protocol (MCP)

Тази глава предоставя изчерпателно ръководство за реализиране на сигурен, мащабируем и в реално време стрийминг с Model Context Protocol (MCP) чрез HTTPS. Обхваща мотивацията за стрийминг, наличните транспортни механизми, как да се реализира стрийминг HTTP в MCP, най-добри практики за сигурност, миграция от SSE и практически насоки за изграждане на собствени стрийминг MCP приложения.

## Транспортни механизми и стрийминг в MCP

Този раздел разглежда различните транспортни механизми, налични в MCP, и тяхната роля при осигуряване на стрийминг възможности за комуникация в реално време между клиенти и сървъри.

### Какво е транспортен механизъм?

Транспортният механизъм определя как се обменят данни между клиента и сървъра. MCP поддържа няколко типа транспорт, за да отговори на различни среди и изисквания:

- **stdio**: Стандартен вход/изход, подходящ за локални и CLI базирани инструменти. Прост, но неподходящ за уеб или облак.
- **SSE (Server-Sent Events)**: Позволява на сървърите да изпращат актуализации в реално време към клиентите по HTTP. Подходящ за уеб интерфейси, но с ограничения по отношение на мащабируемост и гъвкавост.
- **Streamable HTTP**: Модерен HTTP базиран стрийминг транспорт, поддържащ нотификации и по-добра мащабируемост. Препоръчва се за повечето производствени и облачни сценарии.

### Таблица за сравнение

Вижте таблицата по-долу, за да разберете разликите между тези транспортни механизми:

| Транспорт         | Актуализации в реално време | Стрийминг | Мащабируемост | Приложение               |
|-------------------|-----------------------------|-----------|---------------|--------------------------|
| stdio             | Не                          | Не        | Ниска         | Локални CLI инструменти  |
| SSE               | Да                          | Да        | Средна        | Уеб, актуализации в реално време |
| Streamable HTTP   | Да                          | Да        | Висока        | Облак, много клиенти     |

> **Съвет:** Изборът на правилния транспорт влияе на производителността, мащабируемостта и потребителското изживяване. **Streamable HTTP** е препоръчителен за модерни, мащабируеми и облачно готови приложения.

Обърнете внимание на транспортите stdio и SSE, които бяха показани в предишните глави, и как streamable HTTP е транспортът, разгледан в тази глава.

## Стрийминг: Концепции и мотивация

Разбирането на основните концепции и мотивацията зад стрийминга е важно за реализиране на ефективни системи за комуникация в реално време.

**Стрийминг** е техника в мрежовото програмиране, която позволява данните да се изпращат и получават на малки, управляеми парчета или като последователност от събития, вместо да се чака цял отговор да е готов. Това е особено полезно за:

- Големи файлове или набори от данни.
- Актуализации в реално време (например чат, ленти за напредък).
- Дългосрочни изчисления, при които искате да държите потребителя информиран.

Ето какво трябва да знаете за стрийминга на високо ниво:

- Данните се доставят постепенно, а не наведнъж.
- Клиентът може да обработва данните веднага щом пристигнат.
- Намалява възприеманата латентност и подобрява потребителското изживяване.

### Защо да използваме стрийминг?

Причините за използване на стрийминг са следните:

- Потребителите получават обратна връзка веднага, а не само в края
- Позволява приложения в реално време и отзивчиви потребителски интерфейси
- По-ефективно използване на мрежови и изчислителни ресурси

### Прост пример: HTTP стрийминг сървър и клиент

Ето един прост пример как може да се реализира стрийминг:

<details>
<summary>Python</summary>

**Сървър (Python, използвайки FastAPI и StreamingResponse):**
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

**Клиент (Python, използвайки requests):**
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

Този пример показва сървър, който изпраща серия от съобщения към клиента, докато те стават налични, вместо да чака всички съобщения да са готови.

**Как работи:**
- Сървърът връща всяко съобщение, веднага щом е готово.
- Клиентът получава и отпечатва всяко парче веднага след пристигането му.

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) вместо да избира стрийминг през MCP.

- **За прости стрийминг нужди:** Класическият HTTP стрийминг е по-лесен за реализиране и достатъчен за основни случаи.

- **За сложни, интерактивни приложения:** MCP стриймингът предоставя по-структуриран подход с по-богати метаданни и разделение между нотификации и крайни резултати.

- **За AI приложения:** Системата за нотификации на MCP е особено полезна за дългосрочни AI задачи, където искате да държите потребителите информирани за напредъка.

## Стрийминг в MCP

Добре, вече видяхте някои препоръки и сравнения за разликата между класическия стрийминг и стрийминга в MCP. Нека разгледаме по-подробно как точно можете да използвате стрийминг в MCP.

Разбирането как работи стриймингът в рамките на MCP е ключово за създаване на отзивчиви приложения, които предоставят обратна връзка в реално време по време на дългосрочни операции.

В MCP стриймингът не се отнася до изпращане на основния отговор на части, а до изпращане на **нотификации** към клиента, докато инструментът обработва заявка. Тези нотификации могат да включват актуализации за напредък, логове или други събития.

### Как работи

Основният резултат все още се изпраща като един отговор. Въпреки това, нотификациите могат да се изпращат като отделни съобщения по време на обработката и по този начин да актуализират клиента в реално време. Клиентът трябва да може да обработва и показва тези нотификации.

## Какво е нотификация?

Казахме "нотификация", какво означава това в контекста на MCP?

Нотификацията е съобщение, изпратено от сървъра към клиента, за да информира за напредък, статус или други събития по време на дългосрочна операция. Нотификациите повишават прозрачността и подобряват потребителското изживяване.

Например, клиентът трябва да изпрати нотификация, веднага щом първоначалното ръкостискане със сървъра е направено.

Нотификацията изглежда така като JSON съобщение:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Нотификациите принадлежат към тема в MCP, наречена ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

За да заработи логването, сървърът трябва да го активира като функция/възможност по следния начин:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> В зависимост от използвания SDK, логването може да е активирано по подразбиране или да трябва да го включите изрично в конфигурацията на сървъра.

Съществуват различни типове нотификации:

| Ниво       | Описание                      | Примерна употреба             |
|------------|-------------------------------|------------------------------|
| debug      | Подробна отладъчна информация | Точки на влизане/излизане във функции |
| info       | Общи информационни съобщения  | Актуализации за напредък     |
| notice     | Нормални, но значими събития  | Промени в конфигурацията     |
| warning    | Предупредителни условия       | Използване на остаряла функция |
| error      | Грешки                       | Провали на операции          |
| critical   | Критични условия              | Провали на системни компоненти |
| alert      | Необходима е незабавна реакция | Открити повреди на данни     |
| emergency  | Системата е неизползваема     | Пълен системен срив          |

## Реализиране на нотификации в MCP

За да реализирате нотификации в MCP, трябва да настроите както сървърната, така и клиентската страна да обработват актуализации в реално време. Това позволява на вашето приложение да предоставя незабавна обратна връзка на потребителите по време на дългосрочни операции.

### Сървърна страна: Изпращане на нотификации

Нека започнем със сървърната страна. В MCP дефинирате инструменти, които могат да изпращат нотификации по време на обработка на заявки. Сървърът използва контекстния обект (обикновено `ctx`), за да изпраща съобщения към клиента.

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

В горния пример, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` транспорт:

```python
mcp.run(transport="streamable-http")
```

</details>

### Клиентска страна: Получаване на нотификации

Клиентът трябва да реализира обработчик на съобщения, който да обработва и показва нотификациите веднага щом пристигнат.

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) и вашият клиент реализира обработчик на съобщения за обработка на нотификации.

## Нотификации за напредък и сценарии

Този раздел обяснява концепцията за нотификации за напредък в MCP, защо са важни и как да ги реализирате с помощта на Streamable HTTP. Също така ще намерите практическо задание за затвърждаване на знанията.

Нотификациите за напредък са съобщения в реално време, изпращани от сървъра към клиента по време на дългосрочни операции. Вместо да се чака целият процес да завърши, сървърът поддържа клиента актуализиран за текущото състояние. Това подобрява прозрачността, потребителското изживяване и улеснява отстраняването на проблеми.

**Пример:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Защо да използваме нотификации за напредък?

Нотификациите за напредък са важни по няколко причини:

- **По-добро потребителско изживяване:** Потребителите виждат актуализации докато работата върви, а не само в края.
- **Обратна връзка в реално време:** Клиентите могат да показват ленти за напредък или логове, правейки приложението по-отзивчиво.
- **По-лесно отстраняване на грешки и мониторинг:** Разработчиците и потребителите могат да видят къде процесът може да е бавен или блокиран.

### Как да реализираме нотификации за напредък

Ето как можете да реализирате нотификации за напредък в MCP:

- **На сървъра:** Използвайте `ctx.info()` or `ctx.log()`, за да изпращате нотификации при обработката на всеки елемент. Това изпраща съобщение към клиента преди основния резултат да е готов.
- **На клиента:** Реализирайте обработчик на съобщения, който слуша и показва нотификациите веднага щом пристигнат. Този обработчик различава нотификациите от крайния резултат.

**Пример със сървър:**

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

**Пример с клиент:**

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

При реализиране на MCP сървъри с HTTP базирани транспорти, сигурността става ключов приоритет, изискващ внимателно внимание към множество вектори на атака и защитни механизми.

### Преглед

Сигурността е критична при експониране на MCP сървъри през HTTP. Streamable HTTP въвежда нови повърхности за атаки и изисква внимателна конфигурация.

### Ключови моменти
- **Валидация на Origin Header**: Винаги валидирайте `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` вместо SSE клиент.
3. **Реализирайте обработчик на съобщения** в клиента за обработка на нотификациите.
4. **Тествайте съвместимостта** с наличните инструменти и работни потоци.

### Поддържане на съвместимост

Препоръчва се да поддържате съвместимост с налични SSE клиенти по време на миграционния процес. Ето някои стратегии:

- Можете да поддържате както SSE, така и Streamable HTTP, като ги пускате на различни крайни точки.
- Постепенно мигрирайте клиентите към новия транспорт.

### Предизвикателства

Уверете се, че сте адресирали следните предизвикателства по време на миграцията:

- Осигуряване, че всички клиенти са актуализирани
- Обработка на разлики в доставката на нотификации

### Задание: Изградете собствено MCP стрийминг приложение

**Сценарий:**
Изградете MCP сървър и клиент, където сървърът обработва списък от елементи (например файлове или документи) и изпраща нотификация за всеки обработен елемент. Клиентът трябва да показва всяка нотификация веднага щом пристигне.

**Стъпки:**

1. Реализирайте сървърен инструмент, който обработва списък и изпраща нотификации за всеки елемент.
2. Реализирайте клиент с обработчик на съобщения, който показва нотификациите в реално време.
3. Тествайте реализацията си, като стартирате и сървъра, и клиента, и наблюдавате нотификациите.

[Solution](./solution/README.md)

## Допълнително четене и какво следва?

За да продължите пътешествието си с MCP стрийминг и да разширите знанията си, този раздел предоставя допълнителни ресурси и препоръчани следващи стъпки за изграждане на по-сложни приложения.

### Допълнително четене

- [Microsoft: Въведение в HTTP стрийминг](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS в ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Какво следва?

- Опитайте да изградите по-сложни MCP инструменти, които използват стрийминг за анализи в реално време, чат или съвместно редактиране.
- Изследвайте интеграцията

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за всякакви недоразумения или неправилни тълкувания, възникнали в резултат на използването на този превод.