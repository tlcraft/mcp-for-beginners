<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:23:18+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "tl"
}
-->
# HTTPS Streaming gamit ang Model Context Protocol (MCP)

Ang kabanatang ito ay nagbibigay ng komprehensibong gabay sa pagpapatupad ng ligtas, scalable, at real-time na streaming gamit ang Model Context Protocol (MCP) sa pamamagitan ng HTTPS. Tinalakay dito ang dahilan kung bakit kailangang mag-stream, ang mga available na mekanismo ng transportasyon, kung paano ipatupad ang streamable HTTP sa MCP, mga best practice sa seguridad, paglipat mula sa SSE, at praktikal na gabay para makagawa ng sarili mong streaming MCP applications.

## Mga Mekanismo ng Transportasyon at Streaming sa MCP

Tinutuklas ng seksyong ito ang iba't ibang mekanismo ng transportasyon sa MCP at ang kanilang papel sa pagpapagana ng streaming para sa real-time na komunikasyon sa pagitan ng mga kliyente at server.

### Ano ang Transport Mechanism?

Ang transport mechanism ay naglalarawan kung paano ipinagpapalitan ang data sa pagitan ng kliyente at server. Sinusuportahan ng MCP ang iba't ibang uri ng transport upang umangkop sa iba't ibang kapaligiran at pangangailangan:

- **stdio**: Standard input/output, angkop para sa lokal at CLI-based na mga tool. Simple ngunit hindi angkop para sa web o cloud.
- **SSE (Server-Sent Events)**: Pinapayagan ang mga server na magpadala ng real-time na update sa mga kliyente sa pamamagitan ng HTTP. Maganda para sa web UI, ngunit limitado ang scalability at flexibility.
- **Streamable HTTP**: Modernong HTTP-based na streaming transport na sumusuporta sa mga notification at mas mahusay ang scalability. Inirerekomenda para sa karamihan ng production at cloud na senaryo.

### Talahanayan ng Paghahambing

Tingnan ang talahanayan sa ibaba upang maunawaan ang pagkakaiba ng mga mekanismong ito:

| Transport         | Real-time Updates | Streaming | Scalability | Use Case                |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | Hindi            | Hindi     | Mababa      | Lokal na CLI tools      |
| SSE               | Oo               | Oo        | Katamtaman  | Web, real-time updates  |
| Streamable HTTP   | Oo               | Oo        | Mataas      | Cloud, multi-client     |

> **Tip:** Ang pagpili ng tamang transport ay nakakaapekto sa performance, scalability, at karanasan ng gumagamit. **Streamable HTTP** ang inirerekomenda para sa mga modern, scalable, at cloud-ready na aplikasyon.

Pansinin ang mga transport na stdio at SSE na naipakita sa mga nakaraang kabanata at kung paano ang streamable HTTP ang tinalakay sa kabanatang ito.

## Streaming: Mga Konsepto at Dahilan

Mahalagang maunawaan ang mga pangunahing konsepto at dahilan sa likod ng streaming para makapagtayo ng epektibong real-time na sistema ng komunikasyon.

Ang **Streaming** ay isang teknik sa network programming na nagpapahintulot na maipadala at matanggap ang data nang paunti-unti o bilang sunod-sunod na mga kaganapan, sa halip na hintayin ang buong tugon na maging handa. Lalo itong kapaki-pakinabang para sa:

- Malalaking file o datasets.
- Real-time na mga update (halimbawa, chat, progress bars).
- Mga mahahabang proseso kung saan nais mong ipaalam agad sa gumagamit ang progreso.

Narito ang mga pangunahing dapat malaman tungkol sa streaming:

- Unti-unting naipapadala ang data, hindi sabay-sabay.
- Maaaring iproseso ng kliyente ang data habang dumarating ito.
- Nakababawas ng latency na nararamdaman at nagpapabuti ng karanasan ng gumagamit.

### Bakit gumamit ng streaming?

Narito ang mga dahilan kung bakit ginagamit ang streaming:

- Nakakakuha ang mga gumagamit ng agarang tugon, hindi lang sa katapusan.
- Nagpapagana ng real-time na mga aplikasyon at responsive na UI.
- Mas epektibong paggamit ng network at compute resources.

### Simpleng Halimbawa: HTTP Streaming Server at Client

Narito ang isang simpleng halimbawa kung paano ipinatutupad ang streaming:

<details>
<summary>Python</summary>

**Server (Python, gamit ang FastAPI at StreamingResponse):**
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

**Client (Python, gamit ang requests):**
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

Ipinapakita ng halimbawang ito ang server na nagpapadala ng sunod-sunod na mga mensahe sa kliyente habang ito ay available, sa halip na hintayin ang lahat ng mensahe na maging handa.

**Paano ito gumagana:**
- Ipinapadala ng server ang bawat mensahe kapag handa na.
- Tinatanggap at ipinapakita ng kliyente ang bawat bahagi habang dumarating.

**Mga Kinakailangan:**
- Dapat gumamit ang server ng streaming response (halimbawa, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**Server (Java, gamit ang Spring Boot at Server-Sent Events):**

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

**Client (Java, gamit ang Spring WebFlux WebClient):**

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

**Mga Tala sa Implementasyon ng Java:**
- Ginagamit ang reactive stack ng Spring Boot gamit ang `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) kumpara sa pagpili ng streaming sa MCP.

- **Para sa simpleng pangangailangan sa streaming:** Mas simple ang klasikong HTTP streaming na ipatupad at sapat na para sa mga basic na streaming.

- **Para sa mas komplikado at interactive na aplikasyon:** Nagbibigay ang MCP streaming ng mas istrukturadong paraan na may mas mayamang metadata at paghihiwalay ng mga notification at panghuling resulta.

- **Para sa AI na aplikasyon:** Napaka-kapaki-pakinabang ng notification system ng MCP para sa mga mahahabang AI task kung saan nais mong ipaalam sa mga gumagamit ang progreso.

## Streaming sa MCP

Ngayon na nakita mo na ang ilang mga rekomendasyon at paghahambing tungkol sa pagkakaiba ng klasikong streaming at streaming sa MCP, tatalakayin natin nang detalyado kung paano mo magagamit ang streaming sa MCP.

Mahalagang maunawaan kung paano gumagana ang streaming sa loob ng MCP framework upang makabuo ng mga responsive na aplikasyon na nagbibigay ng real-time na feedback sa mga gumagamit habang tumatakbo ang mga mahahabang proseso.

Sa MCP, ang streaming ay hindi tungkol sa pagpapadala ng pangunahing tugon nang paunti-unti, kundi tungkol sa pagpapadala ng **mga notification** sa kliyente habang pinoproseso ng isang tool ang isang request. Maaaring kasama sa mga notification ang mga update sa progreso, logs, o iba pang mga kaganapan.

### Paano ito gumagana

Ang pangunahing resulta ay ipinapadala pa rin bilang isang solong tugon. Gayunpaman, ang mga notification ay maaaring ipadala bilang hiwalay na mga mensahe habang pinoproseso ang request upang ma-update ang kliyente nang real time. Dapat kayang tanggapin at ipakita ng kliyente ang mga notification na ito.

## Ano ang Notification?

Nabanggit natin ang "Notification", ano ang ibig sabihin nito sa konteksto ng MCP?

Ang notification ay isang mensaheng ipinapadala mula sa server papunta sa kliyente upang ipaalam ang progreso, status, o iba pang mga kaganapan habang tumatakbo ang isang mahahabang proseso. Pinapabuti ng mga notification ang transparency at karanasan ng gumagamit.

Halimbawa, inaasahan na magpapadala ang kliyente ng notification kapag nagawa na ang paunang handshake sa server.

Ganito ang itsura ng notification bilang isang JSON message:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Ang mga notification ay kabilang sa isang topic sa MCP na tinatawag na ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Para gumana ang logging, kailangang i-enable ito ng server bilang feature/capability tulad nito:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Depende sa SDK na ginagamit, maaaring naka-enable na ang logging bilang default, o kailangan mo itong i-enable nang tahasan sa iyong server configuration.

May iba't ibang uri ng notification:

| Level     | Paglalarawan                  | Halimbawa ng Paggamit          |
|-----------|-------------------------------|-------------------------------|
| debug     | Detalyadong impormasyon para sa debugging | Mga punto ng pagpasok/paglabas ng function |
| info      | Pangkalahatang mga mensahe ng impormasyon | Mga update sa progreso ng operasyon |
| notice    | Normal ngunit mahalagang mga kaganapan | Mga pagbabago sa configuration |
| warning   | Mga kondisyon na babala       | Paggamit ng deprecated na feature |
| error     | Mga kondisyon ng error         | Mga pagkabigo sa operasyon    |
| critical  | Kritikal na kondisyon          | Pagkabigo ng bahagi ng sistema |
| alert     | Kailangan ng agarang aksyon   | Natuklasang data corruption   |
| emergency | Hindi magamit ang sistema      | Kumpletong pagkasira ng sistema |

## Pagpapatupad ng Notifications sa MCP

Para magpatupad ng notifications sa MCP, kailangan mong ayusin ang parehong server at client upang hawakan ang real-time na mga update. Pinapayagan nito ang iyong aplikasyon na magbigay ng agarang tugon sa mga gumagamit habang tumatakbo ang mahahabang operasyon.

### Server-side: Pagpapadala ng Notifications

Magsimula tayo sa server side. Sa MCP, nagdedeklara ka ng mga tool na maaaring magpadala ng notifications habang pinoproseso ang mga request. Ginagamit ng server ang context object (karaniwan ay `ctx`) upang magpadala ng mga mensahe sa kliyente.

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

Sa halimbawang ito, ang `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` na transport:

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

Sa halimbawang .NET na ito, ginagamit ang `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` na metodo para magpadala ng mga informational na mensahe.

Para i-enable ang notifications sa iyong .NET MCP server, siguraduhing gumagamit ka ng streaming transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Client-side: Pagtanggap ng Notifications

Dapat magpatupad ang client ng message handler upang iproseso at ipakita ang mga notification habang dumarating.

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

Sa code na ito, ginagamit ang `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` para hawakan ang mga papasok na notification.

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

Sa halimbawang .NET na ito, ginagamit ang `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) at nagpapatupad ang client ng message handler para iproseso ang mga notification.

## Progress Notifications at Mga Senaryo

Ipinaliliwanag sa seksyong ito ang konsepto ng progress notifications sa MCP, bakit ito mahalaga, at kung paano ito ipinatutupad gamit ang Streamable HTTP. Makakakita ka rin ng praktikal na gawain para patatagin ang iyong pag-unawa.

Ang progress notifications ay mga real-time na mensaheng ipinapadala mula sa server papunta sa kliyente habang tumatakbo ang mahahabang operasyon. Sa halip na hintayin ang buong proseso na matapos, pinananatili ng server ang kliyente na updated tungkol sa kasalukuyang estado. Pinapabuti nito ang transparency, karanasan ng gumagamit, at nagpapadali ng debugging.

**Halimbawa:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Bakit Gumamit ng Progress Notifications?

Mahalaga ang progress notifications dahil sa mga sumusunod:

- **Mas magandang karanasan ng gumagamit:** Nakikita ng mga gumagamit ang mga update habang nagpapatuloy ang trabaho, hindi lang sa dulo.
- **Real-time na tugon:** Maaaring magpakita ang mga kliyente ng progress bar o logs, kaya mas responsive ang app.
- **Mas madaling debugging at monitoring:** Nakikita ng mga developer at gumagamit kung saan maaaring bumagal o maipit ang proseso.

### Paano Magpatupad ng Progress Notifications

Ganito ang paraan ng pagpapatupad ng progress notifications sa MCP:

- **Sa server:** Gamitin ang `ctx.info()` or `ctx.log()` para magpadala ng notifications habang pinoproseso ang bawat item. Nagpapadala ito ng mensahe sa kliyente bago maging handa ang pangunahing resulta.
- **Sa client:** Magpatupad ng message handler na nakikinig at nagpapakita ng mga notification habang dumarating. Nakikilala ng handler na ito ang pagkakaiba ng mga notification at ng panghuling resulta.

**Halimbawa ng Server:**

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

**Halimbawa ng Client:**

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

## Mga Pagsasaalang-alang sa Seguridad

Kapag nagpapatupad ng MCP servers gamit ang HTTP-based transports, napakahalaga ng seguridad at kinakailangan ng maingat na pagtingin sa iba't ibang mga panganib at mekanismo ng proteksyon.

### Pangkalahatang-ideya

Mahalaga ang seguridad kapag inilalantad ang MCP servers sa HTTP. Nagdudulot ang Streamable HTTP ng mga bagong potensyal na panganib at nangangailangan ng maingat na pagsasaayos.

### Mahahalagang Punto
- **Pag-validate ng Origin Header**: Palaging i-validate ang `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` sa halip na SSE client.
3. **Magpatupad ng message handler** sa client para iproseso ang mga notification.
4. **Subukan ang compatibility** sa mga kasalukuyang tool at workflow.

### Pagpapanatili ng Compatibility

Inirerekomenda na panatilihin ang compatibility sa mga umiiral na SSE client habang isinasagawa ang migration. Narito ang ilang mga estratehiya:

- Maaaring suportahan ang parehong SSE at Streamable HTTP sa pamamagitan ng pagpapatakbo ng dalawang transport sa magkahiwalay na endpoint.
- Unti-unting ilipat ang mga kliyente sa bagong transport.

### Mga Hamon

Siguraduhing matugunan ang mga sumusunod na hamon sa panahon ng migration:

- Pagtiyak na lahat ng kliyente ay na-update
- Paghawak sa mga pagkakaiba sa paghahatid ng notification

### Gawain: Gumawa ng Sariling Streaming MCP App

**Senaryo:**
Gumawa ng MCP server at client kung saan pinoproseso ng server ang isang listahan ng mga item (halimbawa, mga file o dokumento) at nagpapadala ng notification para sa bawat item na naproseso. Dapat ipakita ng client ang bawat notification habang dumarating.

**Mga Hakbang:**

1. Magpatupad ng server tool na nagpoproseso ng listahan at nagpapadala ng mga notification para sa bawat item.
2. Magpatupad ng client na may message handler upang ipakita ang mga notification nang real time.
3. Subukan ang iyong implementasyon sa pamamagitan ng pagpapatakbo ng server at client, at obserbahan ang mga notification.

[Solution](./solution/README.md)

## Karagdagang Pagbabasa at Ano ang Susunod?

Para ipagpatuloy ang iyong paglalakbay sa MCP streaming at palawakin pa ang iyong kaalaman, nagbibigay ang seksyong ito ng karagdagang mga mapagkukunan at mga mungkahing susunod na hakbang para sa paggawa ng mas advanced na mga aplikasyon.

### Karagdagang Pagbabasa

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Ano ang Susunod?

- Subukang gumawa ng mas advanced na MCP tools na gumagamit ng streaming para sa real-time analytics, chat, o collaborative editing.
- Tuklasin ang pagsasama ng MCP streaming sa mga frontend framework (React, Vue, atbp.) para sa live UI updates.
- Susunod: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Pagsisiwalat**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama't nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pinagmulan ng katotohanan. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.