<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:49:43+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "tl"
}
-->
# HTTPS Streaming gamit ang Model Context Protocol (MCP)

Ang kabanatang ito ay nagbibigay ng komprehensibong gabay sa pagpapatupad ng secure, scalable, at real-time streaming gamit ang Model Context Protocol (MCP) sa pamamagitan ng HTTPS. Tinutukoy nito ang dahilan kung bakit kailangan ng streaming, ang mga available na mekanismo ng transport, kung paano ipatupad ang streamable HTTP sa MCP, mga best practice sa seguridad, migrasyon mula sa SSE, at praktikal na gabay sa paggawa ng sarili mong streaming MCP applications.

## Mga Mekanismo ng Transport at Streaming sa MCP

Tinutuklas ng seksyong ito ang iba't ibang mekanismo ng transport na available sa MCP at ang kanilang papel sa pagpapagana ng streaming para sa real-time na komunikasyon sa pagitan ng mga kliyente at server.

### Ano ang Transport Mechanism?

Ang transport mechanism ay nagtatakda kung paano ipinagpapalitan ang data sa pagitan ng client at server. Sinusuportahan ng MCP ang iba't ibang uri ng transport upang umangkop sa iba't ibang kapaligiran at pangangailangan:

- **stdio**: Standard input/output, angkop para sa lokal at CLI-based na mga tools. Simple pero hindi angkop para sa web o cloud.
- **SSE (Server-Sent Events)**: Pinapayagan ang server na mag-push ng real-time na updates sa client gamit ang HTTP. Maganda para sa web UI, pero limitado sa scalability at flexibility.
- **Streamable HTTP**: Modernong HTTP-based streaming transport, sumusuporta sa notifications at mas mahusay ang scalability. Inirerekomenda para sa karamihan ng production at cloud scenarios.

### Talaan ng Paghahambing

Tingnan ang talahanayan sa ibaba para maunawaan ang pagkakaiba ng mga transport mechanisms:

| Transport         | Real-time Updates | Streaming | Scalability | Use Case                |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | Hindi            | Hindi     | Mababa      | Lokal na CLI tools      |
| SSE               | Oo               | Oo        | Katamtaman  | Web, real-time updates  |
| Streamable HTTP   | Oo               | Oo        | Mataas      | Cloud, multi-client     |

> **Tip:** Ang pagpili ng tamang transport ay nakakaapekto sa performance, scalability, at karanasan ng user. **Streamable HTTP** ang inirerekomenda para sa mga modern, scalable, at cloud-ready na aplikasyon.

Pansinin ang mga transport na stdio at SSE na naipakita sa mga naunang kabanata at kung paano ang streamable HTTP ang tinalakay sa kabanatang ito.

## Streaming: Mga Konsepto at Dahilan

Mahalagang maunawaan ang mga pangunahing konsepto at dahilan sa likod ng streaming para makapagtayo ng epektibong real-time communication systems.

Ang **streaming** ay isang teknik sa network programming na nagpapahintulot na magpadala at tumanggap ng data sa maliliit at madaling pamahalaang bahagi o bilang sunod-sunod na mga event, sa halip na hintayin ang buong response na maging handa. Napaka-kapaki-pakinabang ito para sa:

- Malalaking files o datasets.
- Real-time na updates (hal. chat, progress bars).
- Mahabang proseso kung saan nais mong ipaalam sa user ang progreso.

Narito ang mga pangunahing bagay na dapat malaman tungkol sa streaming:

- Unti-unting naipapadala ang data, hindi sabay-sabay.
- Maaaring iproseso ng client ang data habang dumarating.
- Nakababawas ng latency na nararamdaman at nagpapaganda ng user experience.

### Bakit gumamit ng streaming?

Narito ang mga dahilan kung bakit ginagamit ang streaming:

- Nakakakuha agad ng feedback ang mga user, hindi lang sa katapusan.
- Nagpapahintulot ng real-time na aplikasyon at responsive na UI.
- Mas epektibong paggamit ng network at compute resources.

### Simpleng Halimbawa: HTTP Streaming Server at Client

Narito ang simpleng halimbawa kung paano ipinatutupad ang streaming:

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

Ipinapakita ng halimbawang ito ang server na nagpapadala ng serye ng mga mensahe sa client habang available na ang mga ito, sa halip na hintayin ang lahat ng mensahe na maging handa.

**Paano ito gumagana:**
- Ipinapadala ng server ang bawat mensahe kapag handa na ito.
- Tinatanggap at piniprint ng client ang bawat bahagi habang dumarating.

**Mga Kinakailangan:**
- Dapat gumamit ang server ng streaming response (hal. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) sa halip na piliin ang streaming sa pamamagitan ng MCP.

- **Para sa simpleng pangangailangan sa streaming:** Mas madali ang klasikong HTTP streaming at sapat na para sa mga basic na pangangailangan.

- **Para sa mas komplikado at interactive na aplikasyon:** Nagbibigay ang MCP streaming ng mas organisadong paraan na may mas maraming metadata at paghihiwalay sa pagitan ng notifications at final results.

- **Para sa AI na aplikasyon:** Partikular na kapaki-pakinabang ang notification system ng MCP para sa mahahabang AI tasks kung saan nais mong ipaalam sa mga user ang progreso.

## Streaming sa MCP

Ngayon na nakita mo na ang mga rekomendasyon at paghahambing tungkol sa pagkakaiba ng klasikong streaming at streaming sa MCP, tatalakayin natin nang mas detalyado kung paano mo magagamit ang streaming sa MCP.

Mahalagang maunawaan kung paano gumagana ang streaming sa loob ng MCP framework para makabuo ng mga responsive na aplikasyon na nagbibigay ng real-time na feedback sa mga user habang tumatakbo ang mahahabang proseso.

Sa MCP, ang streaming ay hindi tungkol sa pagpapadala ng pangunahing sagot sa piraso-piraso, kundi sa pagpapadala ng **notifications** sa client habang pinoproseso ng tool ang isang request. Ang mga notifications na ito ay maaaring maglaman ng mga update sa progreso, mga log, o iba pang mga event.

### Paano ito gumagana

Ang pangunahing resulta ay ipinapadala pa rin bilang isang solong response. Ngunit, ang mga notification ay maaaring ipadala bilang hiwalay na mga mensahe habang nagpapatuloy ang proseso at sa gayon ay naia-update ang client sa real time. Dapat kaya ng client na i-handle at ipakita ang mga notification na ito.

## Ano ang Notification?

Nabanggit natin ang "Notification", ano nga ba ang ibig sabihin nito sa konteksto ng MCP?

Ang notification ay isang mensahe na ipinapadala mula sa server papunta sa client upang ipaalam ang progreso, status, o iba pang mga pangyayari habang nagpapatuloy ang isang mahaba at tumatagal na operasyon. Pinapabuti ng mga notification ang transparency at karanasan ng user.

Halimbawa, dapat magpadala ang client ng notification kapag nagawa na ang unang handshake sa server.

Ganito ang hitsura ng notification bilang isang JSON message:

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

Para gumana ang logging, kailangang paganahin ito ng server bilang isang feature/capability gaya ng sumusunod:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Depende sa SDK na ginagamit, maaaring naka-enable na ang logging bilang default, o kailangan mo itong i-enable nang manu-mano sa iyong server configuration.

May iba't ibang uri ng notifications:

| Level     | Paglalarawan                    | Halimbawa ng Gamit              |
|-----------|--------------------------------|--------------------------------|
| debug     | Detalyadong impormasyon para sa debugging | Entry/exit points ng function   |
| info      | Pangkalahatang impormasyon      | Mga update sa progreso ng operasyon |
| notice    | Normal pero mahalagang pangyayari | Mga pagbabago sa configuration  |
| warning   | Mga kondisyon na nagbababala    | Paggamit ng deprecated na feature |
| error     | Mga error na kondisyon          | Mga pagkabigo sa operasyon      |
| critical  | Kritikal na kondisyon           | Pagpalya ng mga system component |
| alert     | Agarang aksyon ang kailangan    | Nadiskubreng data corruption    |
| emergency | Hindi magamit ang system        | Kumpletong pagkasira ng system  |

## Pagpapatupad ng Notifications sa MCP

Para ipatupad ang notifications sa MCP, kailangan mong i-setup ang parehong server at client upang mag-handle ng real-time na updates. Pinapayagan nito ang iyong aplikasyon na magbigay ng agarang feedback sa mga user habang nagpapatuloy ang mahahabang operasyon.

### Sa Server Side: Pagpapadala ng Notifications

Magsimula tayo sa server side. Sa MCP, nagde-define ka ng mga tool na maaaring magpadala ng notifications habang pinoproseso ang mga request. Ginagamit ng server ang context object (karaniwang `ctx`) para magpadala ng mga mensahe sa client.

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

Sa naunang halimbawa, ang `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport:

```python
mcp.run(transport="streamable-http")
```

</details>

### Sa Client Side: Pagtanggap ng Notifications

Kailangang magpatupad ang client ng message handler para iproseso at ipakita ang mga notifications habang dumarating ang mga ito.

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

Sa naunang code, ang `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) at ipinatupad ng iyong client ang message handler para iproseso ang mga notifications.

## Mga Progress Notifications at Mga Scenario

Ipinaliliwanag ng seksyong ito ang konsepto ng progress notifications sa MCP, bakit ito mahalaga, at paano ito ipinatutupad gamit ang Streamable HTTP. Makakakita ka rin ng praktikal na gawain para mas lalo mong maintindihan.

Ang progress notifications ay mga real-time na mensahe na ipinapadala mula sa server papunta sa client habang nagpapatuloy ang mahahabang operasyon. Sa halip na hintayin ang buong proseso na matapos, patuloy na ina-update ng server ang client tungkol sa kasalukuyang status. Pinapabuti nito ang transparency, karanasan ng user, at nagpapadali ng debugging.

**Halimbawa:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Bakit Gumamit ng Progress Notifications?

Mahalaga ang progress notifications dahil sa mga sumusunod:

- **Mas magandang karanasan ng user:** Nakikita ng user ang mga update habang nagpapatuloy ang trabaho, hindi lang sa katapusan.
- **Real-time na feedback:** Maaaring magpakita ang client ng progress bars o logs, kaya mas responsive ang app.
- **Mas madaling debugging at monitoring:** Nakikita ng developers at users kung saan maaaring mabagal o ma-stuck ang proseso.

### Paano Ipatupad ang Progress Notifications

Ganito ang paraan ng pagpapatupad ng progress notifications sa MCP:

- **Sa server:** Gamitin ang `ctx.info()` or `ctx.log()` para magpadala ng notifications habang pinoproseso ang bawat item. Pinapadala nito ang mensahe sa client bago pa man maging handa ang pangunahing resulta.
- **Sa client:** Magpatupad ng message handler na nakikinig at nagpapakita ng notifications habang dumarating ang mga ito. Nakikilala ng handler ang pagitan ng notifications at ng final result.

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

Kapag nagpapatupad ng MCP servers gamit ang HTTP-based transports, ang seguridad ay isang pangunahing alalahanin na nangangailangan ng maingat na pagtingin sa iba't ibang uri ng atake at mga mekanismo ng proteksyon.

### Pangkalahatang-ideya

Mahalaga ang seguridad kapag inilalantad ang MCP servers sa HTTP. Nagdadala ang Streamable HTTP ng mga bagong panganib kaya kailangan ng maingat na configuration.

### Mahahalagang Punto
- **Origin Header Validation**: Laging i-validate ang `Origin` header to prevent DNS rebinding attacks.
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
3. **Magpatupad ng message handler** sa client para iproseso ang notifications.
4. **Subukan ang compatibility** sa mga kasalukuyang tools at workflows.

### Pananatili ng Compatibility

Inirerekomenda na panatilihin ang compatibility sa mga kasalukuyang SSE clients habang nagsasagawa ng migrasyon. Narito ang ilang estratehiya:

- Maaari mong suportahan ang parehong SSE at Streamable HTTP sa pamamagitan ng pagpapatakbo ng parehong transport sa magkahiwalay na endpoints.
- Unti-unting i-migrate ang mga client sa bagong transport.

### Mga Hamon

Siguraduhing matugunan ang mga sumusunod na hamon habang nagmi-migrate:

- Pagtiyak na lahat ng client ay updated
- Paghawak sa mga pagkakaiba sa paraan ng paghahatid ng notifications

### Gawain: Gumawa ng Sariling Streaming MCP App

**Senaryo:**
Gumawa ng MCP server at client kung saan ang server ay nagpoproseso ng listahan ng mga item (hal. mga file o dokumento) at nagpapadala ng notification para sa bawat item na naproseso. Dapat ipakita ng client ang bawat notification habang dumarating.

**Mga Hakbang:**

1. Ipatupad ang server tool na nagpoproseso ng listahan at nagpapadala ng notifications para sa bawat item.
2. Ipatupad ang client na may message handler para ipakita ang notifications sa real time.
3. Subukan ang iyong implementasyon sa pagpapatakbo ng parehong server at client, at obserbahan ang mga notifications.

[Solution](./solution/README.md)

## Karagdagang Babasahin at Ano ang Susunod?

Para ipagpatuloy ang iyong paglalakbay sa MCP streaming at palawakin ang iyong kaalaman, naglalaman ang seksyong ito ng mga karagdagang resources at mga mungkahing susunod na hakbang para sa paggawa ng mas advanced na aplikasyon.

### Karagdagang Babasahin

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Ano ang Susunod?

- Subukan gumawa ng mas advanced na MCP tools na gumagamit ng streaming para sa real-time analytics, chat, o collaborative editing.
- Suriin ang integrasyon ng MCP streaming sa mga frontend frameworks (React, Vue, atbp.) para sa live UI updates.
- Susunod: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Pahayag ng Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi tumpak na impormasyon. Ang orihinal na dokumento sa kanyang orihinal na wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.