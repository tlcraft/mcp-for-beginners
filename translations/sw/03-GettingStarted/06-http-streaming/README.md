<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:24:24+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "sw"
}
-->
# Upeperushaji wa HTTPS kwa Protokoli ya Muktadha wa Mfano (MCP)

Sura hii inatoa mwongozo kamili wa kutekeleza upeperushaji salama, unaoweza kupanuka, na wa wakati halisi kwa kutumia Protokoli ya Muktadha wa Mfano (MCP) kwa kutumia HTTPS. Inajumuisha sababu za upeperushaji, njia mbalimbali za usafirishaji, jinsi ya kutekeleza HTTP inayoweza kupeperushwa katika MCP, mbinu bora za usalama, uhamisho kutoka SSE, na mwongozo wa vitendo wa kujenga programu zako za MCP zinazoweza kupeperushwa.

## Njia za Usafirishaji na Upeperushaji katika MCP

Sehemu hii inachunguza njia tofauti za usafirishaji zinazopatikana katika MCP na nafasi yao katika kuwezesha uwezo wa upeperushaji kwa mawasiliano ya wakati halisi kati ya wateja na seva.

### Je, Njia ya Usafirishaji ni Nini?

Njia ya usafirishaji inaelezea jinsi data inavyobadilishana kati ya mteja na seva. MCP inaunga mkono aina mbalimbali za usafirishaji ili kufaa mazingira na mahitaji tofauti:

- **stdio**: Ingizo/saizi ya kawaida, inayofaa kwa zana za ndani na zile zinazotumia CLI. Rahisi lakini si nzuri kwa wavuti au wingu.
- **SSE (Matukio Yanayotumwa na Seva)**: Inaruhusu seva kusukuma masasisho ya wakati halisi kwa wateja kupitia HTTP. Inafaa kwa UI za wavuti, lakini ina mipaka ya upanuzi na kubadilika.
- **Streamable HTTP**: Usafirishaji wa kisasa unaotegemea HTTP unaoweza kupeperushwa, unaounga mkono arifa na upanuzi bora. Inapendekezwa kwa hali nyingi za uzalishaji na wingu.

### Jedwali la Mlinganisho

Tazama jedwali la mlinganisho hapa chini kuelewa tofauti kati ya njia hizi za usafirishaji:

| Usafirishaji     | Masasisho ya Wakati Halisi | Upeperushaji | Uwezo wa Kupanuka | Matumizi                   |
|------------------|----------------------------|--------------|-------------------|----------------------------|
| stdio            | Hapana                     | Hapana       | Chini            | Zana za CLI za ndani       |
| SSE              | Ndiyo                      | Ndiyo        | Kati              | Wavuti, masasisho ya wakati halisi |
| Streamable HTTP  | Ndiyo                      | Ndiyo        | Juu               | Wingu, wateja wengi        |

> **Tip:** Kuchagua njia sahihi ya usafirishaji huathiri utendaji, upanuzi, na uzoefu wa mtumiaji. **Streamable HTTP** inapendekezwa kwa programu za kisasa, zinazoweza kupanuka, na zenye kujiandaa kwa wingu.

Kumbuka njia za usafirishaji stdio na SSE ulizoziona katika sura zilizopita na jinsi Streamable HTTP inavyoshughulikiwa katika sura hii.

## Upeperushaji: Dhana na Sababu

Kuelewa dhana za msingi na sababu za upeperushaji ni muhimu kwa kutekeleza mifumo madhubuti ya mawasiliano ya wakati halisi.

**Upeperushaji** ni mbinu katika programu za mtandao inayoruhusu data kutumwa na kupokelewa kwa vipande vidogo vinavyoweza kudhibitiwa au kama mfululizo wa matukio, badala ya kusubiri jibu lote liwe tayari. Hii ni muhimu hasa kwa:

- Faili au seti kubwa za data.
- Masasisho ya wakati halisi (mfano, mazungumzo, mabara ya maendeleo).
- Hesabu za muda mrefu ambapo unataka mtumiaji aendelee kupata taarifa.

Hapa ni mambo unayopaswa kuyajua kuhusu upeperushaji kwa ujumla:

- Data hutolewa kidogo kidogo, si yote kwa wakati mmoja.
- Mteja anaweza kuchakata data anapopokea.
- Inapunguza ucheleweshaji unaohisiwa na kuboresha uzoefu wa mtumiaji.

### Kwa Nini Utumie Upeperushaji?

Sababu za kutumia upeperushaji ni kama ifuatavyo:

- Watumiaji hupata mrejesho mara moja, si tu mwishoni
- Inawawezesha programu za wakati halisi na UI zinazojibu haraka
- Matumizi bora ya rasilimali za mtandao na kompyuta

### Mfano Rahisi: Seva na Mteja wa Upeperushaji wa HTTP

Hapa kuna mfano rahisi wa jinsi upeperushaji unavyoweza kutekelezwa:

<details>
<summary>Python</summary>

**Seva (Python, ikitumia FastAPI na StreamingResponse):**
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

**Mteja (Python, ikitumia requests):**
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

Mfano huu unaonyesha seva ikituma mfululizo wa ujumbe kwa mteja anapopatikana, badala ya kusubiri ujumbe wote uwe tayari.

**Jinsi Inavyofanya Kazi:**
- Seva hutuma kila ujumbe linapokuwa tayari.
- Mteja hupokea na kuchapisha kila kipande anapopokea.

**Mahitaji:**
- Seva lazima itumie jibu la upeperushaji (mfano, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Seva (Java, ikitumia Spring Boot na Server-Sent Events):**

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

**Mteja (Java, ikitumia Spring WebFlux WebClient):**

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

**Maelezo ya Utekelezaji wa Java:**
- Inatumia stack ya reactive ya Spring Boot na `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) badala ya kuchagua upeperushaji kupitia MCP.

- **Kwa mahitaji rahisi ya upeperushaji:** Upeperushaji wa HTTP wa kawaida ni rahisi kutekeleza na unatosha kwa mahitaji ya msingi.

- **Kwa programu tata, zinazoshirikiana:** Upeperushaji wa MCP hutoa njia iliyopangwa zaidi yenye metadata tajiri na utofauti kati ya arifa na matokeo ya mwisho.

- **Kwa programu za AI:** Mfumo wa arifa wa MCP ni muhimu hasa kwa kazi za AI za muda mrefu ambapo unataka kuwajulisha watumiaji maendeleo.

## Upeperushaji katika MCP

Sawa, umeona mapendekezo na mlinganisho kuhusu tofauti kati ya upeperushaji wa kawaida na ule wa MCP. Sasa tuchunguze kwa undani jinsi unavyoweza kutumia upeperushaji katika MCP.

Kuelewa jinsi upeperushaji unavyofanya kazi ndani ya mfumo wa MCP ni muhimu kwa kujenga programu zinazojibu haraka na kutoa mrejesho wa wakati halisi kwa watumiaji wakati wa shughuli za muda mrefu.

Katika MCP, upeperushaji siyo kutuma jibu kuu kwa vipande, bali ni kutuma **arifa** kwa mteja wakati zana inashughulikia ombi. Arifa hizi zinaweza kujumuisha masasisho ya maendeleo, kumbukumbu, au matukio mengine.

### Jinsi Inavyofanya Kazi

Matokeo makuu bado hutumwa kama jibu moja. Hata hivyo, arifa zinaweza kutumwa kama ujumbe tofauti wakati wa usindikaji na hivyo kusasisha mteja kwa wakati halisi. Mteja lazima aweze kushughulikia na kuonyesha arifa hizi.

## Arifa ni Nini?

Tulisema "Arifa", maana yake ni nini katika muktadha wa MCP?

Arifa ni ujumbe unaotumwa kutoka seva kwenda kwa mteja ili kumjulisha kuhusu maendeleo, hali, au matukio mengine wakati wa operesheni za muda mrefu. Arifa huongeza uwazi na uzoefu wa mtumiaji.

Kwa mfano, mteja anapaswa kutuma arifa mara tu mawasiliano ya awali na seva yametimizwa.

Arifa inaonekana kama ujumbe wa JSON kama ifuatavyo:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Arifa zinahusiana na mada katika MCP inayojulikana kama ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Ili kuwezesha logging, seva inahitaji kuiwezesha kama kipengele/kifaa kama ifuatavyo:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Kulingana na SDK inayotumika, logging inaweza kuwa imewezeshwa kwa chaguo-msingi, au unaweza kuhitaji kuiwezesha wazi katika usanidi wa seva yako.

Kuna aina tofauti za arifa:

| Kiwango    | Maelezo                       | Mfano wa Matumizi             |
|------------|------------------------------|-------------------------------|
| debug      | Maelezo ya kina ya utambuzi  | Mambo ya kuingia/kuondoka kwenye kazi |
| info       | Ujumbe wa taarifa za jumla   | Masasisho ya maendeleo ya operesheni |
| notice     | Matukio ya kawaida lakini muhimu | Mabadiliko ya usanidi          |
| warning    | Hali za onyo                 | Matumizi ya kipengele kilichopotoka |
| error      | Hali za makosa              | Kushindwa kwa operesheni       |
| critical   | Hali muhimu                  | Kushindwa kwa sehemu ya mfumo  |
| alert      | Hatua lazima zichukuliwe mara moja | Ugonjwa wa uharibifu wa data  |
| emergency  | Mfumo hauwezi kutumika        | Kushindwa kabisa kwa mfumo     |

## Kutekeleza Arifa katika MCP

Ili kutekeleza arifa katika MCP, unahitaji kuandaa pande zote za seva na mteja kushughulikia masasisho ya wakati halisi. Hii inaruhusu programu yako kutoa mrejesho wa papo hapo kwa watumiaji wakati wa operesheni za muda mrefu.

### Seva: Kutuma Arifa

Tuanze na upande wa seva. Katika MCP, unaelezea zana zinazoweza kutuma arifa wakati wa kushughulikia maombi. Seva hutumia kitu cha muktadha (kawaida `ctx`) kutuma ujumbe kwa mteja.

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

Katika mfano uliotangulia, usafirishaji wa `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`:

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

Katika mfano huu wa .NET, njia ya `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` hutumika kutuma ujumbe wa taarifa.

Ili kuwezesha arifa kwenye seva yako ya MCP ya .NET, hakikisha unatumia usafirishaji unaoweza kupeperushwa:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Mteja: Kupokea Arifa

Mteja lazima aunde mshughulikiaji wa ujumbe kushughulikia na kuonyesha arifa anazopokea.

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

Katika msimbo uliotangulia, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` hutumika kushughulikia arifa zinazoingia.

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

Katika mfano huu wa .NET, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) na mteja wako hutekeleza mshughulikiaji wa ujumbe kushughulikia arifa.

## Arifa za Maendeleo & Muktadha wa Matukio

Sehemu hii inaelezea dhana ya arifa za maendeleo katika MCP, kwa nini ni muhimu, na jinsi ya kuzitekeleza kwa kutumia Streamable HTTP. Pia utapata zoezi la vitendo kusaidia kuelewa.

Arifa za maendeleo ni ujumbe wa wakati halisi unaotumwa kutoka seva kwenda kwa mteja wakati wa operesheni za muda mrefu. Badala ya kusubiri mchakato mzima ukamilike, seva inaendelea kusasisha mteja kuhusu hali ya sasa. Hii huongeza uwazi, uzoefu wa mtumiaji, na kurahisisha utambuzi wa matatizo.

**Mfano:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Kwa Nini Utumie Arifa za Maendeleo?

Arifa za maendeleo ni muhimu kwa sababu kadhaa:

- **Uzoefu bora wa mtumiaji:** Watumiaji wanaona masasisho wanapofanyika kazi, si tu mwishoni.
- **Mrejesho wa wakati halisi:** Wateja wanaweza kuonyesha mabara ya maendeleo au kumbukumbu, na kufanya programu ionekane inayojibu.
- **Utambuzi rahisi na ufuatiliaji:** Waendelezaji na watumiaji wanaweza kuona wapi mchakato unaweza kuwa polepole au kusimama.

### Jinsi ya Kutekeleza Arifa za Maendeleo

Hapa ni jinsi unavyoweza kutekeleza arifa za maendeleo katika MCP:

- **Kwenye seva:** Tumia `ctx.info()` or `ctx.log()` kutuma arifa kila kipengele kinaposhughulikiwa. Hii hutuma ujumbe kwa mteja kabla matokeo makuu hayajakuwa tayari.
- **Kwenye mteja:** Tengeneza mshughulikiaji wa ujumbe unaosikiliza na kuonyesha arifa zinapopokea. Mshughulikiaji huyu hutofautisha kati ya arifa na matokeo ya mwisho.

**Mfano wa Seva:**

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

**Mfano wa Mteja:**

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

## Mambo ya Usalama

Unapotekeleza seva za MCP kwa kutumia usafirishaji wa HTTP, usalama unakuwa jambo la msingi sana linalohitaji umakini mkubwa dhidi ya njia mbalimbali za mashambulizi na mbinu za ulinzi.

### Muhtasari

Usalama ni muhimu wakati seva za MCP zinapotolewa kupitia HTTP. Streamable HTTP huleta maeneo mapya ya mashambulizi na inahitaji usanidi makini.

### Mambo Muhimu
- **Uthibitishaji wa Kichwa cha Origin**: Daima hakikisha kichwa cha `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` badala ya mteja wa SSE.
3. **Tekeleza mshughulikiaji wa ujumbe** katika mteja kushughulikia arifa.
4. **Jaribu ushirikiano** na zana na mtiririko wa kazi uliopo.

### Kudumisha Ushirikiano

Inapendekezwa kudumisha ushirikiano na wateja wa SSE waliopo wakati wa mchakato wa uhamisho. Hapa kuna mikakati:

- Unaweza kuunga mkono SSE na Streamable HTTP kwa kuendesha usafirishaji wote kwenye maeneo tofauti.
- Hamisha wateja polepole kwenda kwenye usafirishaji mpya.

### Changamoto

Hakikisha unashughulikia changamoto zifuatazo wakati wa uhamisho:

- Kuhakikisha wateja wote wamebadilishwa
- Kushughulikia tofauti katika utoaji wa arifa

### Zoezi: Jenga Programu Yako ya MCP ya Upeperushaji

**Muktadha:**
Jenga seva na mteja wa MCP ambapo seva inashughulikia orodha ya vitu (mfano, faili au hati) na kutuma arifa kwa kila kipengele kinachoshughulikiwa. Mteja anapaswa kuonyesha kila arifa anapopokea.

**Hatua:**

1. Tekeleza zana ya seva inayoshughulikia orodha na kutuma arifa kwa kila kipengele.
2. Tekeleza mteja mwenye mshughulikiaji wa ujumbe kuonyesha arifa kwa wakati halisi.
3. Jaribu utekelezaji wako kwa kuendesha seva na mteja, na tazama arifa zinavyotumwa.

[Solution](./solution/README.md)

## Kusoma Zaidi & Nini Kifanyike Baadaye?

Ili kuendeleza safari yako na upeperushaji wa MCP na kuongeza maarifa yako, sehemu hii inatoa rasilimali za ziada na hatua zinazopendekezwa kwa ajili ya kujenga programu za hali ya juu zaidi.

### Kusoma Zaidi

- [Microsoft: Utangulizi wa Upeperushaji wa HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Matukio Yanayotumwa na Seva (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS katika ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Maombi ya Upeperushaji](https://requests.readthedocs.io/en/latest/user/advanced/#streaming

**Kiarifu cha Kukataa**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.