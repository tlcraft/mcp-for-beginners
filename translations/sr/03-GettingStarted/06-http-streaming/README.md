<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:29:58+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sr"
}
-->
# HTTPS стриминг са Model Context Protocol (MCP)

Ово поглавље пружа свеобухватан водич за имплементацију безбедног, скалабилног и реално-временског стриминга користећи Model Context Protocol (MCP) преко HTTPS-а. Обрађује мотиве за стриминг, доступне транспортне механизме, како имплементирати стриминг HTTP у MCP-у, најбоље безбедносне праксе, миграцију са SSE-а и практичне смернице за креирање ваших стриминг MCP апликација.

## Транспортни механизми и стриминг у MCP

Овај одељак истражује различите транспортне механизме доступне у MCP-у и њихову улогу у омогућавању стриминг могућности за реално-временску комуникацију између клијената и сервера.

### Шта је транспортни механизам?

Транспортни механизам дефинише како се подаци размењују између клијента и сервера. MCP подржава више типова транспорта како би се прилагодио различитим окружењима и захтевима:

- **stdio**: Стандардни улаз/излаз, погодан за локалне и CLI алате. Једноставан, али није погодан за веб или облак.
- **SSE (Server-Sent Events)**: Омогућава серверима да шаљу реално-временске ажурирања клијентима преко HTTP-а. Добар за веб интерфејсе, али ограничен у скалабилности и флексибилности.
- **Streamable HTTP**: Модеран HTTP базиран стриминг транспорт, који подржава нотификације и бољу скалабилност. Препоручује се за већину продукцијских и облачних сценарија.

### Табела поређења

Погледајте табелу поређења испод да бисте разумели разлике између ових транспортних механизама:

| Транспорт         | Реално-временска ажурирања | Стриминг | Скалабилност | Примена                 |
|-------------------|----------------------------|----------|--------------|-------------------------|
| stdio             | Не                         | Не       | Ниска        | Локални CLI алати       |
| SSE               | Да                         | Да       | Средња       | Веб, реално-временска ажурирања |
| Streamable HTTP   | Да                         | Да       | Висока       | Облак, више клијената  |

> **Tip:** Избор правог транспорта утиче на перформансе, скалабилност и корисничко искуство. **Streamable HTTP** је препоручен за модерне, скалабилне и облачно спремне апликације.

Обратите пажњу на транспортне механизме stdio и SSE који су представљени у претходним поглављима и како је Streamable HTTP транспорт који се обрађује у овом поглављу.

## Стриминг: Концепти и мотивација

Разумевање основних концепата и мотивације иза стриминга је кључно за имплементацију ефикасних система за реално-временску комуникацију.

**Стриминг** је техника у мрежном програмирању која омогућава слање и примање података у малим, управљивим деловима или као низ догађаја, уместо да се чека да цео одговор буде спреман. Ово је посебно корисно за:

- Велике фајлове или скупе података.
- Реално-временска ажурирања (нпр. ћаскање, траке напретка).
- Дуго трајајуће прорачуне где желите да корисник буде информисан.

Ево шта треба да знате о стримингу на високом нивоу:

- Подаци се испоручују постепено, не све одједном.
- Клијент може да обрађује податке како стижу.
- Смањује перципирану латенцију и побољшава корисничко искуство.

### Зашто користити стриминг?

Разлози за коришћење стриминга су следећи:

- Корисници добијају повратне информације одмах, а не само на крају
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

Овај пример показује сервер који шаље серију порука клијенту како постају доступне, уместо да чека да све поруке буду спремне.

**Како ради:**
- Сервер шаље сваку поруку кад је спремна.
- Клијент прима и исписује сваки део како стиже.

**Захтеви:**
- Сервер мора користити стриминг одговор (нпр. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) уместо избора стриминга преко MCP-а.

- **За једноставне потребе стриминга:** Класични HTTP стриминг је једноставнији за имплементацију и довољан за основне потребе.

- **За сложене, интерактивне апликације:** MCP стриминг пружа структуриранији приступ са богатијим метаподацима и раздвајањем између нотификација и коначних резултата.

- **За AI апликације:** MCP систем нотификација је посебно користан за дуготрајне AI задатке где желите да корисници буду обавештавани о напретку.

## Стриминг у MCP

Добро, видели сте неке препоруке и поређења до сада о разликама између класичног стриминга и стриминга у MCP-у. Хајде да детаљније објаснимо како можете искористити стриминг у MCP-у.

Разумевање како стриминг функционише у оквиру MCP-а је кључно за изградњу одзивних апликација које пружају реално-временске повратне информације корисницима током дуготрајних операција.

У MCP-у, стриминг није слање главног одговора у деловима, већ слање **нотификација** клијенту док алат обрађује захтев. Ове нотификације могу укључивати ажурирања напретка, логове или друге догађаје.

### Како функционише

Главни резултат се и даље шаље као један одговор. Међутим, нотификације могу бити послате као посебне поруке током обраде и тако ажурирати клијента у реалном времену. Клијент мора бити способан да обрађује и приказује ове нотификације.

## Шта је нотификација?

Рекли смо "нотификација", шта то значи у контексту MCP-а?

Нотификација је порука коју сервер шаље клијенту да га обавести о напретку, статусу или другим догађајима током дуготрајне операције. Нотификације побољшавају транспарентност и корисничко искуство.

На пример, клијент треба да пошаље нотификацију када је успостављен почетни руковање (handshake) са сервером.

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

Да би логовање радило, сервер мора омогућити ову функцију/могућност на следећи начин:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> У зависности од коришћеног SDK-а, логовање може бити омогућено подразумевано, или ћете морати експлицитно да га укључите у конфигурацији сервера.

Постоје различити нивои нотификација:

| Ниво       | Опис                          | Пример употребе              |
|------------|-------------------------------|-----------------------------|
| debug      | Детаљне информације за дебаг | Тачке уласка/изласка из функције |
| info       | Опште информативне поруке    | Ажурирања напретка операције |
| notice     | Нормални, али значајни догађаји | Промене конфигурације        |
| warning    | Упозорења                    | Коришћење застареле функције |
| error      | Грешке                      | Неуспеси операција           |
| critical   | Критични услови             | Кварови системских компоненти |
| alert      | Одмах је потребна акција    | Откривена корупција података |
| emergency  | Систем је нефункционалан    | Потпуни пад система          |

## Имплементација нотификација у MCP

Да бисте имплементирали нотификације у MCP-у, потребно је да подесите и сервер и клијент да обрађују реално-временска ажурирања. Ово омогућава вашој апликацији да корисницима пружи тренутне повратне информације током дуготрајних операција.

### Серверска страна: Слање нотификација

Почнимо са серверском страном. У MCP-у дефинишете алате који могу слати нотификације током обраде захтева. Сервер користи објекат контекста (обично `ctx`) за слање порука клијенту.

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

### Клијентска страна: Примање нотификација

Клијент мора имплементирати обраду порука која процесуира и приказује нотификације како стижу.

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

У претходном коду, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) и ваш клијент имплементира обраду порука за нотификације.

## Нотификације напретка и сценарији

Овај одељак објашњава концепт нотификација напретка у MCP-у, зашто су важне и како их имплементирати користећи Streamable HTTP. Такође, ту је и практичан задатак за учвршћивање знања.

Нотификације напретка су реално-временске поруке које сервер шаље клијенту током дуготрајних операција. Уместо да се чека да цео процес заврши, сервер стално обавештава клијента о тренутном статусу. Ово побољшава транспарентност, корисничко искуство и олакшава дебаговање.

**Пример:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Зашто користити нотификације напретка?

Нотификације напретка су важне из неколико разлога:

- **Боље корисничко искуство:** Корисници виде ажурирања како рад напредује, не само на крају.
- **Реално-временски повратни одговор:** Клијенти могу приказивати траке напретка или логове, чинећи апликацију одзивнијом.
- **Лакше дебаговање и праћење:** Развојни инжењери и корисници могу видети где процес може бити спор или заглављен.

### Како имплементирати нотификације напретка

Ево како можете имплементирати нотификације напретка у MCP-у:

- **На серверу:** Користите `ctx.info()` or `ctx.log()` да шаљете нотификације како се сваки предмет обрађује. Ово шаље поруку клијенту пре него што је главни резултат спреман.
- **На клијенту:** Имплементирајте обраду порука која слуша и приказује нотификације како стижу. Ова обрада разликује нотификације од коначног резултата.

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

## Безбедносне напомене

Када имплементирате MCP сервере са HTTP базираним транспортима, безбедност постаје кључни аспект који захтева пажљиво разматрање различитих напада и механизама заштите.

### Преглед

Безбедност је критична када се MCP сервери излажу преко HTTP-а. Streamable HTTP уводи нове потенцијалне површине за нападе и захтева пажљиву конфигурацију.

### Кључне тачке
- **Валидација Origin заглавља**: Увек проверавајте `Origin` header to prevent DNS rebinding attacks.
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

- Можете подржати и SSE и Streamable HTTP тако што ћете покретати оба транспорта на различитим крајњим тачкама.
- Постепено мигрирајте клијенте на нови транспорт.

### Изазови

Обратите пажњу на следеће изазове током миграције:

- Осигурати да су сви клијенти ажурирани
- Управљање разликама у испоруци нотификација

### Задатак: Направите своју MCP стриминг апликацију

**Сценарио:**
Направите MCP сервер и клијент где сервер обрађује листу ставки (нпр. фајлови или документи) и шаље нотификацију за сваку обрађену ставку. Клијент треба да приказује сваку нотификацију како стиже.

**Кораци:**

1. Имплементирајте серверски алат који обрађује листу и шаље нотификације за сваку ставку.
2. Имплементирајте клијента са обрадом порука која приказује нотификације у реалном времену.
3. Тестирајте имплементацију покретањем сервера и клијента и посматрајте нотификације.

[Solution](./solution/README.md)

## Додатно читање и шта даље?

Да бисте наставили пут са MCP стримингом и проширили своје знање, овај одељак пружа додатне ресурсе и предлоге за следеће кораке у изградњи напреднијих апликација.

### Додатно читање

- [Microsoft: Увод у HTTP стриминг](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS у ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.

**Одрицање одговорности**:  
Овај документ је преведен помоћу АИ сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која могу проистећи из коришћења овог превода.