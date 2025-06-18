<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:33:13+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sr"
}
-->
# HTTPS стриминг са Model Context Protocol (MCP)

Ово поглавље пружа детаљан водич за имплементацију сигурног, скалабилног и реално-временског стриминга уз помоћ Model Context Protocol (MCP) преко HTTPS-а. Обухвата мотиве за стриминг, доступне транспортне механизме, како имплементирати стриминг HTTP у MCP-у, најбоље безбедносне праксе, миграцију са SSE-а и практичне смернице за креирање ваших сопствених стриминг MCP апликација.

## Транспортни механизми и стриминг у MCP-у

Овај одељак истражује различите транспортне механизме доступне у MCP-у и њихову улогу у омогућавању стриминг могућности за реално-временску комуникацију између клијената и сервера.

### Шта је транспортни механизам?

Транспортни механизам дефинише како се подаци размењују између клијента и сервера. MCP подржава више типова транспорта како би одговарао различитим окружењима и захтевима:

- **stdio**: Стандардни улаз/излаз, погодан за локалне и CLI алате. Једноставан, али није погодан за веб или облак.
- **SSE (Server-Sent Events)**: Омогућава серверима да шаљу реално-временске ажурирања клијентима преко HTTP-а. Добро за веб корисничке интерфејсе, али ограничено у скалабилности и флексибилности.
- **Streamable HTTP**: Модеран стриминг транспорт заснован на HTTP-у, који подржава нотификације и бољу скалабилност. Препоручује се за већину продукцијских и облачних сценарија.

### Табела поређења

Погледајте табелу испод да бисте разумели разлике између ових транспортних механизама:

| Транспорт        | Реално-временска ажурирања | Стриминг | Скалабилност | Примена                 |
|------------------|----------------------------|----------|--------------|-------------------------|
| stdio            | Не                         | Не       | Ниска        | Локални CLI алати       |
| SSE              | Да                         | Да       | Средња       | Веб, реално-временска ажурирања |
| Streamable HTTP  | Да                         | Да       | Висока       | Облак, мулти-клијент    |

> **[!TIP]** Избор правог транспорта утиче на перформансе, скалабилност и корисничко искуство. **Streamable HTTP** је препоручен за модерне, скалабилне и облачно спремне апликације.

Обратите пажњу на транспорт stdio и SSE који су приказани у претходним поглављима, као и на то да је у овом поглављу обрађен Streamable HTTP.

## Стриминг: Концепти и мотиви

Разумевање основних концепата и мотива иза стриминга је кључно за имплементацију ефикасних система за реално-временску комуникацију.

**Стриминг** је техника у мрежном програмирању која омогућава слање и пријем података у малим, управљивим деловима или као низ догађаја, уместо да се чека цео одговор. Ово је посебно корисно за:

- Велике фајлове или скупове података.
- Реално-временска ажурирања (нпр. ћаскање, траке напретка).
- Дуготрајне прорачуне где желите да корисник буде информисан.

Ево шта треба да знате о стримингу у великој слици:

- Подаци се испоручују постепено, не одједном.
- Клијент може обрађивати податке како стижу.
- Смањује перцепцију кашњења и побољшава корисничко искуство.

### Зашто користити стриминг?

Разлози за коришћење стриминга су следећи:

- Корисници добијају повратну информацију одмах, а не само на крају
- Омогућава реално-временске апликације и одзивне корисничке интерфејсе
- Ефикаснија употреба мрежних и рачунарских ресурса

### Једноставан пример: HTTP стриминг сервер и клијент

Ево једноставног примера како се стриминг може имплементирати:

<details>
<summary>Python</summary>

**Сервер (Python, користећи FastAPI и StreamingResponse):**
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

**Клијент (Python, користећи requests):**
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

Овај пример показује сервер који шаље низ порука клијенту како постају доступне, уместо да чека да све поруке буду спремне.

**Како ради:**
- Сервер шаље сваку поруку чим је спремна.
- Клијент прима и штампа сваки део како стиже.

**Захтеви:**
- Сервер мора користити стриминг одговор (нпр. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Сервер (Java, користећи Spring Boot и Server-Sent Events):**

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

**Клијент (Java, користећи Spring WebFlux WebClient):**

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

**Напомене о Java имплементацији:**
- Користи реактивни стек Spring Boot-а са `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) уместо избора стриминга преко MCP-а.

- **За једноставне потребе стриминга:** Класични HTTP стриминг је једноставнији за имплементацију и довољан за основне потребе.

- **За сложене, интерактивне апликације:** MCP стриминг пружа структуриранији приступ са богатијим метаподацима и раздвајањем нотификација и коначних резултата.

- **За AI апликације:** MCP систем нотификација је посебно користан за дуготрајне AI задатке где желите да кориснике обавештавате о напретку.

## Стриминг у MCP-у

Дакле, видели сте неке препоруке и поређења до сада о разлици између класичног стриминга и стриминга у MCP-у. Хајде да детаљније погледамо како тачно можете искористити стриминг у MCP-у.

Разумевање како стриминг функционише у оквиру MCP-а је кључно за креирање одзивних апликација које корисницима пружају реално-временске повратне информације током дуготрајних операција.

У MCP-у, стриминг није слање главног одговора у деловима, већ слање **нотификација** клијенту док алат обрађује захтев. Ове нотификације могу укључивати ажурирања напретка, логове или друге догађаје.

### Како функционише

Главни резултат се и даље шаље као један одговор. Међутим, нотификације могу бити послате као посебне поруке током обраде и тиме ажурирати клијента у реалном времену. Клијент мора бити у стању да их обради и прикаже.

## Шта је нотификација?

Рекли смо "нотификација", шта то значи у контексту MCP-а?

Нотификација је порука послата са сервера клијенту која обавештава о напретку, статусу или другим догађајима током дуготрајне операције. Нотификације побољшавају транспарентност и корисничко искуство.

На пример, клијент треба да пошаље нотификацију кад је успостављена почетна веза са сервером.

Нотификација изгледа овако као JSON порука:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Нотификације припадају теми у MCP-у која се назива ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Да би логовање радило, сервер мора да га омогући као функцију/могућност на следећи начин:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> У зависности од коришћеног SDK-а, логовање може бити подразумевано омогућено или ћете морати да га експлицитно укључите у конфигурацији сервера.

Постоје различите врсте нотификација:

| Ниво      | Опис                           | Пример употребе               |
|-----------|--------------------------------|------------------------------|
| debug     | Детаљне информације за дебаговање | Улази и излази из функција    |
| info      | Опште информативне поруке      | Ажурирања напретка операције |
| notice    | Нормални али значајни догађаји | Промене конфигурације         |
| warning   | Упозорења                     | Коришћење застареле функције |
| error     | Грешке                       | Неуспеси операција            |
| critical  | Критични услови               | Неуспеси системских компоненти|
| alert     | Неодложна акција потребна    | Откривена корупција података |
| emergency | Систем није употребљив       | Потпуни системски пад        |

## Имплементација нотификација у MCP-у

Да бисте имплементирали нотификације у MCP-у, потребно је да подесите и серверску и клијентску страну за руковање реално-временским ажурирањима. Ово омогућава вашој апликацији да корисницима пружи тренутну повратну информацију током дуготрајних операција.

### Серверска страна: Слање нотификација

Почнимо са серверском страном. У MCP-у дефинишете алате који могу слати нотификације током обраде захтева. Сервер користи контекст објекат (обично `ctx`) за слање порука клијенту.

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

У претходном примеру, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

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

У овом .NET примеру, метод `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` се користи за слање информативних порука.

Да бисте омогућили нотификације у вашем .NET MCP серверу, уверите се да користите стриминг транспорт:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Клијентска страна: Примање нотификација

Клијент мора да имплементира обраду порука како би обрађивао и приказивао нотификације како пристижу.

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

У претходном коду, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` се користи за обраду долазних нотификација.

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

У овом .NET примеру, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) и ваш клијент имплементира обраду порука за нотификације.

## Нотификације напретка и сценарији

Овај одељак објашњава концепт нотификација напретка у MCP-у, зашто су важне и како их имплементирати користећи Streamable HTTP. Такође садржи практичан задатак за учвршћивање знања.

Нотификације напретка су реално-временске поруке послате са сервера клијенту током дуготрајних операција. Уместо да се чека да цео процес заврши, сервер стално обавештава клијента о тренутном статусу. Ово побољшава транспарентност, корисничко искуство и олакшава отклањање грешака.

**Пример:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Зашто користити нотификације напретка?

Нотификације напретка су важне из више разлога:

- **Боље корисничко искуство:** Корисници виде ажурирања током рада, не само на крају.
- **Реално-временска повратна информација:** Клијенти могу приказивати траке напретка или логове, што апликацији даје одзивност.
- **Лакше отклањање грешака и праћење:** Програмери и корисници могу видети где процес успорава или је заглављен.

### Како имплементирати нотификације напретка

Ево како можете имплементирати нотификације напретка у MCP-у:

- **На серверу:** Користите `ctx.info()` or `ctx.log()` за слање нотификација како се сваки елемент обрађује. Ово шаље поруку клијенту пре него што главни резултат буде спреман.
- **На клијенту:** Имплементирајте обраду порука која слуша и приказује нотификације како пристижу. Ова обрада разликује нотификације од коначног резултата.

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

**Пример клијента:**

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

## Безбедносне препоруке

Када имплементирате MCP сервере са HTTP-базираним транспортима, безбедност постаје кључни аспект који захтева пажљиво разматрање више врста напада и механизама заштите.

### Преглед

Безбедност је критична када се MCP сервери излажу преко HTTP-а. Streamable HTTP уводи нове површине за нападе и захтева пажљиву конфигурацију.

### Кључне тачке
- **Валидација Origin заглавља**: Увек проверите `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` уместо SSE клијента.
3. **Имплементирајте обраду порука** у клијенту за обраду нотификација.
4. **Тестирајте компатибилност** са постојећим алатима и радним токовима.

### Одржавање компатибилности

Препоручује се одржавање компатибилности са постојећим SSE клијентима током процеса миграције. Ево неких стратегија:

- Можете подржати и SSE и Streamable HTTP покретањем оба транспорта на различитим крајњим тачкама.
- Постепено мигрирајте клијенте на нови транспорт.

### Изазови

Обратите пажњу на следеће изазове током миграције:

- Обезбеђивање да су сви клијенти ажурирани
- Руководење разликама у испоруци нотификација

### Задатак: Направите своју MCP стриминг апликацију

**Сценарио:**
Направите MCP сервер и клијент где сервер обрађује листу ставки (нпр. фајлова или докумената) и шаље нотификацију за сваку обрађену ставку. Клијент треба да прикаже сваку нотификацију чим стигне.

**Кораци:**

1. Имплементирајте серверски алат који обрађује листу и шаље нотификације за сваку ставку.
2. Имплементирајте клијент

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматизовани преводи могу садржати грешке или нетачности. Изворни документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални превод од стране људског преводиоца. Нисмо одговорни за било какве неспоразуме или погрешне интерпретације настале коришћењем овог превода.