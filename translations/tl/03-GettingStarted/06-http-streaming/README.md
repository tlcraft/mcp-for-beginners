<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:22:37+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "tl"
}
-->
# HTTPS Streaming gamit ang Model Context Protocol (MCP)

Ang kabanatang ito ay nagbibigay ng komprehensibong gabay sa pagpapatupad ng secure, scalable, at real-time na streaming gamit ang Model Context Protocol (MCP) sa pamamagitan ng HTTPS. Tinalakay dito ang dahilan ng streaming, mga available na mekanismo ng transportasyon, kung paano ipatupad ang streamable HTTP sa MCP, mga best practice sa seguridad, paglipat mula sa SSE, at praktikal na gabay sa paggawa ng sariling streaming MCP na mga aplikasyon.

## Mga Mekanismo ng Transportasyon at Streaming sa MCP

Sinasaliksik ng seksyong ito ang iba't ibang mekanismo ng transportasyon na available sa MCP at ang kanilang papel sa pagpapagana ng streaming para sa real-time na komunikasyon sa pagitan ng mga kliyente at server.

### Ano ang Transport Mechanism?

Ang mekanismo ng transportasyon ay tumutukoy kung paano ipinagpapalitan ang data sa pagitan ng kliyente at server. Sinusuportahan ng MCP ang iba't ibang uri ng transportasyon upang umangkop sa iba't ibang kapaligiran at pangangailangan:

- **stdio**: Standard input/output, angkop para sa lokal at CLI-based na mga tool. Simple ngunit hindi angkop para sa web o cloud.
- **SSE (Server-Sent Events)**: Pinapayagan ang mga server na magpadala ng real-time na update sa mga kliyente sa pamamagitan ng HTTP. Maganda para sa web UI, ngunit limitado sa scalability at flexibility.
- **Streamable HTTP**: Modernong HTTP-based na streaming transport, sumusuporta sa mga notification at mas mahusay ang scalability. Inirerekomenda para sa karamihan ng production at cloud na mga senaryo.

### Talahanayan ng Paghahambing

Tingnan ang talahanayan sa ibaba upang maunawaan ang mga pagkakaiba ng mga mekanismong ito:

| Transport         | Real-time Updates | Streaming | Scalability | Gamit                     |
|-------------------|------------------|-----------|-------------|---------------------------|
| stdio             | Hindi            | Hindi     | Mababa      | Lokal na CLI tools        |
| SSE               | Oo               | Oo        | Katamtaman  | Web, real-time na update  |
| Streamable HTTP   | Oo               | Oo        | Mataas      | Cloud, multi-client       |

> **Tip:** Ang pagpili ng tamang transport ay nakakaapekto sa performance, scalability, at karanasan ng gumagamit. **Streamable HTTP** ang inirerekomenda para sa modern, scalable, at cloud-ready na mga aplikasyon.

Pansinin ang mga transport na stdio at SSE na naipakita sa mga nakaraang kabanata at kung paano ang streamable HTTP ang tinalakay sa kabanatang ito.

## Streaming: Mga Konsepto at Dahilan

Mahalagang maunawaan ang mga pangunahing konsepto at dahilan sa likod ng streaming para sa epektibong pagpapatupad ng real-time na komunikasyon.

**Streaming** ay isang teknik sa network programming na nagpapahintulot na ang data ay maipadala at matanggap nang paunti-unti o bilang sunod-sunod na mga pangyayari, sa halip na hintayin ang buong tugon na maging handa. Lalo itong kapaki-pakinabang para sa:

- Malalaking file o dataset.
- Real-time na update (hal. chat, progress bars).
- Mahabang proseso kung saan nais mong patuloy na maipaalam ang gumagamit.

Narito ang mga pangunahing dapat malaman tungkol sa streaming:

- Ang data ay naipapadala nang paunti-unti, hindi sabay-sabay.
- Kayang iproseso ng kliyente ang data habang dumarating ito.
- Nakababawas ng pakiramdam ng delay at nagpapabuti sa karanasan ng gumagamit.

### Bakit gumamit ng streaming?

Narito ang mga dahilan sa paggamit ng streaming:

- Agad na nakakatanggap ng feedback ang mga gumagamit, hindi lang sa katapusan.
- Nagpapagana ng real-time na aplikasyon at responsive na UI.
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

Ipinapakita ng halimbawang ito ang server na nagpapadala ng sunod-sunod na mga mensahe sa kliyente habang ito ay available, sa halip na hintayin ang lahat ng mensahe na maging handa.

**Paano ito gumagana:**
- Ipinapadala ng server ang bawat mensahe kapag handa na ito.
- Tinatanggap at ipiniprint ng kliyente ang bawat bahagi habang dumarating.

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) sa halip na pumili ng streaming sa pamamagitan ng MCP.

- **Para sa simpleng pangangailangan sa streaming:** Mas madali at sapat na ang klasikong HTTP streaming.

- **Para sa mas kumplikado at interactive na aplikasyon:** Nagbibigay ang MCP streaming ng mas organisadong pamamaraan na may mas detalyadong metadata at paghihiwalay ng notifications at final results.

- **Para sa AI na aplikasyon:** Napakainam ng notification system ng MCP para sa mga mahahabang AI tasks kung saan nais mong ipaalam ang progreso sa mga gumagamit.

## Streaming sa MCP

Ngayon na nakita mo na ang ilang rekomendasyon at paghahambing tungkol sa klasikong streaming at streaming sa MCP, tatalakayin natin nang detalyado kung paano mo magagamit ang streaming sa MCP.

Mahalagang maunawaan kung paano gumagana ang streaming sa loob ng MCP framework para makabuo ng mga responsive na aplikasyon na nagbibigay ng real-time na feedback sa mga gumagamit habang tumatakbo ang mga mahahabang proseso.

Sa MCP, ang streaming ay hindi tungkol sa pagpapadala ng pangunahing tugon nang paunti-unti, kundi sa pagpapadala ng **notifications** sa kliyente habang pinoproseso ng tool ang isang kahilingan. Ang mga notification na ito ay maaaring mga update sa progreso, mga log, o iba pang mga pangyayari.

### Paano ito gumagana

Ang pangunahing resulta ay ipinapadala pa rin bilang isang solong tugon. Gayunpaman, ang mga notification ay maaaring ipadala bilang hiwalay na mga mensahe habang nagpapatuloy ang proseso upang ma-update ang kliyente sa real time. Dapat kayang tanggapin at ipakita ng kliyente ang mga notification na ito.

## Ano ang Notification?

Nabanggit natin ang "Notification", ano nga ba ang ibig sabihin nito sa konteksto ng MCP?

Ang notification ay isang mensahe na ipinapadala mula sa server papunta sa kliyente upang ipaalam ang progreso, status, o iba pang mga pangyayari habang tumatakbo ang isang mahaba at kumplikadong operasyon. Pinapabuti ng mga notification ang transparency at karanasan ng gumagamit.

Halimbawa, dapat magpadala ang kliyente ng notification kapag nagawa na ang unang handshake sa server.

Ganito ang hitsura ng notification bilang isang JSON na mensahe:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Ang mga notification ay kabilang sa isang paksa sa MCP na tinatawag na ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Para gumana ang logging, kailangang paganahin ito ng server bilang isang feature/capability gaya nito:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Depende sa SDK na ginagamit, maaaring naka-enable na ang logging bilang default, o kailangan mo itong i-enable nang manu-mano sa configuration ng server mo.

May iba't ibang uri ng mga notification:

| Antas      | Paglalarawan                   | Halimbawa ng Gamit              |
|------------|-------------------------------|--------------------------------|
| debug      | Detalyadong impormasyon para sa debugging | Mga entry/exit point ng function |
| info       | Pangkalahatang mga impormasyong pangkaalaman | Mga update sa progreso ng operasyon |
| notice     | Normal ngunit mahalagang mga pangyayari | Mga pagbabago sa configuration  |
| warning    | Mga kondisyon na babala       | Paggamit ng deprecated na feature |
| error      | Mga kondisyon ng error         | Mga pagkabigo sa operasyon      |
| critical   | Kritikal na mga kondisyon      | Pagkabigo ng mga bahagi ng sistema |
| alert      | Kailangan ng agarang aksyon   | Natuklasang korapsyon ng data   |
| emergency  | Hindi magamit ang sistema      | Kumpletong pagkasira ng sistema |

## Pagpapatupad ng Notifications sa MCP

Para magpatupad ng notifications sa MCP, kailangan mong i-setup ang parehong server at client para sa pagtanggap ng real-time na mga update. Pinapayagan nito ang iyong aplikasyon na magbigay ng agarang feedback sa mga gumagamit habang tumatakbo ang mahahabang operasyon.

### Sa Server: Pagpapadala ng Notifications

Magsimula tayo sa bahagi ng server. Sa MCP, nagdedeklara ka ng mga tool na maaaring magpadala ng notifications habang pinoproseso ang mga kahilingan. Ginagamit ng server ang context object (karaniwan ay `ctx`) upang magpadala ng mga mensahe sa kliyente.

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

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` na transport:

```python
mcp.run(transport="streamable-http")
```

</details>

### Sa Client: Pagtanggap ng Notifications

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

Sa code na ito, ang `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) at ipinatutupad ng client ang message handler para sa mga notification.

## Mga Progress Notification at Mga Senaryo

Ipinaliwanag sa seksyong ito ang konsepto ng progress notifications sa MCP, bakit ito mahalaga, at kung paano ito ipinatutupad gamit ang Streamable HTTP. Makakakita ka rin ng praktikal na gawain para mapalalim ang iyong pagkaunawa.

Ang progress notifications ay mga real-time na mensahe mula sa server papunta sa client habang tumatakbo ang mahahabang operasyon. Sa halip na hintayin ang buong proseso na matapos, pinananatili ng server ang client na updated sa kasalukuyang status. Pinapabuti nito ang transparency, karanasan ng gumagamit, at nagpapadali sa pag-debug.

**Halimbawa:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Bakit Gamitin ang Progress Notifications?

Mahalaga ang progress notifications dahil sa mga sumusunod:

- **Mas magandang karanasan ng gumagamit:** Nakikita ng mga user ang mga update habang nagpapatuloy ang trabaho, hindi lang sa katapusan.
- **Real-time na feedback:** Maaaring ipakita ng client ang progress bars o mga log, kaya mas responsive ang app.
- **Mas madaling pag-debug at pagmamanman:** Nakikita ng mga developer at user kung saan nagkakaproblema o bumabagal ang proseso.

### Paano Ipatupad ang Progress Notifications

Ganito mo ipinatutupad ang progress notifications sa MCP:

- **Sa server:** Gamitin ang `ctx.info()` or `ctx.log()` para magpadala ng notifications habang pinoproseso ang bawat item. Ipinapadala nito ang mensahe bago ang pangunahing resulta ay handa na.
- **Sa client:** Magpatupad ng message handler na nakikinig at nagpapakita ng notifications habang dumarating. Nakikilala ng handler ang pagitan ng notifications at final result.

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

Kapag nagpapatupad ng MCP server gamit ang HTTP-based na transport, ang seguridad ay isang napakahalagang isyu na nangangailangan ng maingat na pagtuon sa iba't ibang paraan ng pag-atake at mga mekanismo ng proteksyon.

### Pangkalahatang Pagsusuri

Mahalaga ang seguridad kapag inilalantad ang MCP server sa HTTP. Nagdadala ang Streamable HTTP ng mga bagong panganib kaya kailangan ng maingat na pagsasaayos.

### Mahahalagang Punto
- **Origin Header Validation**: Laging suriin ang `Origin` header upang matiyak na mula ito sa pinagkakatiwalaang pinagmulan.

### Pagpapanatili ng Compatibility

Inirerekomenda na panatilihin ang compatibility sa mga umiiral nang SSE client habang isinasagawa ang migration. Narito ang ilang mga estratehiya:

- Maaari mong suportahan ang parehong SSE at Streamable HTTP sa pamamagitan ng pagpapatakbo ng parehong transport sa magkakaibang endpoint.
- Unti-unting ilipat ang mga client sa bagong transport.

### Mga Hamon

Siguraduhing matugunan ang mga sumusunod na hamon habang nagmi-migrate:

- Pagtiyak na updated ang lahat ng client
- Paghawak sa mga pagkakaiba sa paraan ng paghahatid ng notification

### Gawain: Gumawa ng Sariling Streaming MCP App

**Senaryo:**
Gumawa ng MCP server at client kung saan pinoproseso ng server ang isang listahan ng mga item (hal. mga file o dokumento) at nagpapadala ng notification para sa bawat item na naproseso. Ipinapakita ng client ang bawat notification habang dumarating.

**Mga Hakbang:**

1. Gumawa ng tool sa server na nagpoproseso ng listahan at nagpapadala ng notifications para sa bawat item.
2. Gumawa ng client na may message handler upang ipakita ang mga notifications sa real time.
3. Subukan ang implementasyon sa pamamagitan ng pagpapatakbo ng parehong server at client, at obserbahan ang mga notifications.

[Solution](./solution/README.md)

## Karagdagang Pagbasa at Ano ang Susunod?

Para ipagpatuloy ang iyong pag-aaral sa MCP streaming at palawakin ang iyong kaalaman, nagbibigay ang seksyong ito ng karagdagang mga sanggunian at mga mungkahing susunod na hakbang para makagawa ng mas advanced na mga aplikasyon.

### Karagdagang Pagbasa

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Ano ang Susunod?

- Subukang gumawa ng mas advanced na MCP tools na gumagamit ng streaming para sa real-time analytics, chat, o collaborative editing.
- Tuklasin ang integrasyon ng MCP streaming sa mga frontend framework (React, Vue, atbp.) para sa live UI updates.
- Susunod: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang orihinal na wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.