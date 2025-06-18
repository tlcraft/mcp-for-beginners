<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:32:08+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "bg"
}
-->
# HTTPS стрийминг с Model Context Protocol (MCP)

Тази глава предоставя изчерпателно ръководство за реализиране на сигурен, мащабируем и в реално време стрийминг с Model Context Protocol (MCP) чрез HTTPS. Обхваща мотивацията за стрийминг, наличните транспортни механизми, как да се реализира стрийминг HTTP в MCP, най-добрите практики за сигурност, миграция от SSE и практически насоки за изграждане на собствени стрийминг MCP приложения.

## Транспортни механизми и стрийминг в MCP

Този раздел разглежда различните транспортни механизми, налични в MCP, и тяхната роля в осигуряването на стрийминг възможности за комуникация в реално време между клиенти и сървъри.

### Какво е транспортен механизъм?

Транспортният механизъм определя как се обменят данни между клиента и сървъра. MCP поддържа няколко типа транспорт, подходящи за различни среди и изисквания:

- **stdio**: Стандартен вход/изход, подходящ за локални и CLI инструменти. Прост, но неподходящ за уеб или облак.
- **SSE (Server-Sent Events)**: Позволява на сървърите да изпращат актуализации в реално време към клиентите през HTTP. Подходящ за уеб интерфейси, но с ограничения по отношение на мащабируемост и гъвкавост.
- **Streamable HTTP**: Модерен HTTP базиран стрийминг транспорт, поддържащ известия и по-добра мащабируемост. Препоръчва се за повечето продукционни и облачни сценарии.

### Таблица за сравнение

Вижте таблицата по-долу, за да разберете разликите между тези транспортни механизми:

| Транспорт         | Актуализации в реално време | Стрийминг | Мащабируемост | Приложение              |
|-------------------|-----------------------------|-----------|---------------|------------------------|
| stdio             | Не                          | Не        | Ниска         | Локални CLI инструменти |
| SSE               | Да                          | Да        | Средна        | Уеб, актуализации в реално време |
| Streamable HTTP   | Да                          | Да        | Висока        | Облак, много клиенти    |

> **Tip:** Изборът на правилния транспорт влияе на производителността, мащабируемостта и потребителското изживяване. **Streamable HTTP** е препоръчителен за модерни, мащабируеми и облачно готови приложения.

Обърнете внимание на транспортите stdio и SSE, които бяха показани в предишните глави, и как Streamable HTTP е транспортът, разгледан в тази глава.

## Стрийминг: концепции и мотивация

Разбирането на основните концепции и мотивации зад стрийминга е от съществено значение за реализирането на ефективни системи за комуникация в реално време.

**Стриймингът** е техника в мрежовото програмиране, която позволява данните да се изпращат и получават на малки, управляеми части или като поредица от събития, вместо да се чака цял отговор да бъде готов. Това е особено полезно за:

- Големи файлове или набори от данни.
- Актуализации в реално време (например чат, ленти за прогрес).
- Дългосрочни изчисления, при които искате да държите потребителя информиран.

Ето какво трябва да знаете за стрийминга на високо ниво:

- Данните се доставят постепенно, не наведнъж.
- Клиентът може да обработва данните, докато пристигат.
- Намалява възприеманата латентност и подобрява потребителското изживяване.

### Защо да използваме стрийминг?

Причините за използване на стрийминг са следните:

- Потребителите получават обратна връзка веднага, не само накрая
- Позволява приложения в реално време и отзивчиви интерфейси
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

Този пример показва сървър, който изпраща серия от съобщения към клиента веднага щом станат налични, вместо да чака всички съобщения да са готови.

**Как работи:**
- Сървърът изпраща всяко съобщение веднага щом е готово.
- Клиентът получава и отпечатва всяка част веднага щом пристигне.

**Изисквания:**
- Сървърът трябва да използва стрийминг отговор (например `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Сървър (Java, използвайки Spring Boot и Server-Sent Events):**

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

**Клиент (Java, използвайки Spring WebFlux WebClient):**

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

**Бележки за Java имплементацията:**
- Използва реактивния стек на Spring Boot с `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) вместо избор на стрийминг чрез MCP.

- **За прости стрийминг нужди:** Класическият HTTP стрийминг е по-лесен за имплементиране и достатъчен за основни нужди.

- **За сложни, интерактивни приложения:** MCP стриймингът осигурява по-структуриран подход с по-богата метаинформация и разделение между известия и крайни резултати.

- **За AI приложения:** Системата за известия на MCP е особено полезна при дългосрочни AI задачи, където искате да държите потребителите информирани за напредъка.

## Стрийминг в MCP

Добре, видяхте някои препоръки и сравнения досега за разликата между класическия стрийминг и стрийминга в MCP. Нека разгледаме подробно как точно може да използвате стрийминг в MCP.

Разбирането как работи стриймингът в рамките на MCP е от ключово значение за изграждане на отзивчиви приложения, които предоставят обратна връзка в реално време на потребителите по време на дългосрочни операции.

В MCP стриймингът не означава изпращане на основния отговор на части, а изпращане на **известия** към клиента, докато инструментът обработва заявката. Тези известия могат да включват актуализации на прогреса, логове или други събития.

### Как работи

Основният резултат все още се изпраща като един отговор. В същото време известията могат да се изпращат като отделни съобщения по време на обработката и по този начин да актуализират клиента в реално време. Клиентът трябва да може да обработва и показва тези известия.

## Какво е известие?

Казахме "известие", какво означава това в контекста на MCP?

Известието е съобщение, изпратено от сървъра към клиента, за да информира за прогрес, статус или други събития по време на дългосрочна операция. Известията подобряват прозрачността и потребителското изживяване.

Например, клиент трябва да изпрати известие, веднага щом първоначалното свързване със сървъра е установено.

Известието изглежда така като JSON съобщение:

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
> В зависимост от използвания SDK, логването може да е включено по подразбиране или може да се наложи изрично да го активирате в конфигурацията на сървъра.

Съществуват различни типове известия:

| Ниво       | Описание                      | Примерна употреба             |
|------------|-------------------------------|------------------------------|
| debug      | Подробна отстраняваща информация | Вход/изход на функции        |
| info       | Общи информационни съобщения   | Актуализации на прогрес      |
| notice     | Нормални, но значими събития   | Промени в конфигурацията     |
| warning    | Предупредителни условия        | Използване на остаряла функция|
| error      | Грешки                        | Неуспехи в операциите        |
| critical   | Критични условия              | Провали на системни компоненти|
| alert      | Необходимо е незабавно действие| Открита повреда на данни     |
| emergency  | Системата е неизползваема     | Пълна системна повреда       |

## Имплементиране на известия в MCP

За да реализирате известия в MCP, трябва да настроите както сървърната, така и клиентската страна за обработка на актуализации в реално време. Това позволява на вашето приложение да предоставя незабавна обратна връзка на потребителите по време на дългосрочни операции.

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

В горния пример, методът `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

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

В този .NET пример, методът `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` се използва за изпращане на информационни съобщения.

За да активирате известия в .NET MCP сървър, уверете се, че използвате стрийминг транспорт:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### От страна на клиента: Получаване на известия

Клиентът трябва да имплементира обработчик на съобщения, който да обработва и показва известията, веднага щом пристигнат.

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

В горния код, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` се използва за обработка на входящи известия.

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

В този .NET пример, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) и клиентът имплементира обработчик на съобщения за обработка на известия.

## Известия за прогрес и сценарии

Този раздел обяснява концепцията за известия за прогрес в MCP, защо са важни и как да ги реализирате с Streamable HTTP. Също така ще намерите практическо задание за затвърждаване на знанията.

Известията за прогрес са съобщения в реално време, изпращани от сървъра към клиента по време на дългосрочни операции. Вместо да се чака целият процес да приключи, сървърът поддържа клиента информиран за текущото състояние. Това подобрява прозрачността, потребителското изживяване и улеснява отстраняването на грешки.

**Пример:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Защо да използваме известия за прогрес?

Известията за прогрес са важни по няколко причини:

- **По-добро потребителско изживяване:** Потребителите виждат актуализации докато работата върви, а не само накрая.
- **Обратна връзка в реално време:** Клиентите могат да показват ленти за прогрес или логове, което прави приложението по-отзивчиво.
- **По-лесно отстраняване на грешки и мониторинг:** Разработчиците и потребителите могат да видят къде процесът е бавен или блокиран.

### Как да реализираме известия за прогрес

Ето как може да реализирате известия за прогрес в MCP:

- **На сървъра:** Използвайте `ctx.info()` or `ctx.log()` за изпращане на известия при обработката на всеки елемент. Това изпраща съобщение към клиента преди основния резултат да е готов.
- **На клиента:** Имплементирайте обработчик на съобщения, който слуша и показва известията веднага щом пристигнат. Този обработчик различава известията от крайния резултат.

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

## Съображения за сигурността

При реализиране на MCP сървъри с HTTP базирани транспорти, сигурността става основен приоритет, изискващ внимателно внимание към множество вектори на атака и защитни механизми.

### Преглед

Сигурността е критична при експониране на MCP сървъри през HTTP. Streamable HTTP въвежда нови възможности за атаки и изисква внимателна конфигурация.

### Ключови точки
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
3. **Имплементирайте обработчик на съобщения** в клиента за обработка на известия.
4. **Тествайте за съвместимост** с налични инструменти и работни потоци.

### Поддържане на съвместимост

Препоръчва се да поддържате съвместимост с наличните SSE клиенти по време на процеса на миграция. Ето някои стратегии:

- Можете да поддържате както SSE, така и Streamable HTTP, като ги пускате на различни крайни точки.
- Постепенно мигрирайте клиентите към новия транспорт.

### Предизвикателства

Уверете се, че сте адресирали следните предизвикателства по време на миграцията:

- Осигуряване, че всички клиенти са актуализирани
- Обработка на разлики в доставката на известия

### Задание: Изградете собствено стрийминг MCP приложение

**Сценарий:**
Изградете MCP сървър и клиент, където сървърът обработва списък с елементи (например файлове или документи) и изпраща известие за всеки обработен елемент. Клиентът трябва да показва всяко известие веднага щом пристигне.

**Стъпки:**

1. Имплементирайте сървърен инструмент, който обработва списък и изпраща известия за всеки елемент.
2. Имплементирайте клиент с обработчик на съобщения, който показва известия в реално време.
3. Тествайте имплементацията си, като стартирате и сървъра, и клиента, и наблюдавайте известията.

[Solution](./solution/README.md)

## Допълнително четене и какво следва?

За да продължите пътешествието си със стрийминг в MCP и да разширите знанията си, този раздел предоставя допълнителни ресурси и препоръчани следващи стъпки за изграждане на по-сложни приложения.

### Допълнително четене

- [Microsoft: Въведение в HTTP стрийм

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия първичен език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.