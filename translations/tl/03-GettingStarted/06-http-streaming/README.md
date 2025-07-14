<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:47:59+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "tl"
}
-->
# HTTPS Streaming gamit ang Model Context Protocol (MCP)

Ang kabanatang ito ay nagbibigay ng komprehensibong gabay sa pagpapatupad ng ligtas, scalable, at real-time na streaming gamit ang Model Context Protocol (MCP) sa pamamagitan ng HTTPS. Tinutukoy nito ang dahilan ng streaming, mga available na mekanismo ng transportasyon, kung paano ipatupad ang streamable HTTP sa MCP, mga pinakamahusay na kasanayan sa seguridad, paglipat mula sa SSE, at praktikal na gabay sa paggawa ng sarili mong streaming MCP na mga aplikasyon.

## Mga Mekanismo ng Transportasyon at Streaming sa MCP

Tinutuklas ng seksyong ito ang iba't ibang mekanismo ng transportasyon na available sa MCP at ang kanilang papel sa pagpapagana ng streaming para sa real-time na komunikasyon sa pagitan ng mga kliyente at server.

### Ano ang Mekanismo ng Transportasyon?

Ang mekanismo ng transportasyon ay tumutukoy kung paano ipinagpapalitan ang datos sa pagitan ng kliyente at server. Sinusuportahan ng MCP ang iba't ibang uri ng transportasyon upang umangkop sa iba't ibang kapaligiran at pangangailangan:

- **stdio**: Standard input/output, angkop para sa lokal at CLI-based na mga tool. Simple ngunit hindi angkop para sa web o cloud.
- **SSE (Server-Sent Events)**: Pinapayagan ang mga server na magpadala ng real-time na update sa mga kliyente sa pamamagitan ng HTTP. Maganda para sa web UI, ngunit limitado sa scalability at flexibility.
- **Streamable HTTP**: Modernong HTTP-based na streaming transport, sumusuporta sa mga notification at mas mahusay na scalability. Inirerekomenda para sa karamihan ng production at cloud na mga senaryo.

### Talahanayan ng Paghahambing

Tingnan ang talahanayan sa ibaba upang maunawaan ang pagkakaiba ng mga mekanismong ito:

| Transport         | Real-time Updates | Streaming | Scalability | Gamit                  |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | Hindi            | Hindi     | Mababa      | Lokal na CLI tools       |
| SSE               | Oo               | Oo        | Katamtaman  | Web, real-time updates  |
| Streamable HTTP   | Oo               | Oo        | Mataas      | Cloud, multi-client     |

> **Tip:** Ang pagpili ng tamang transport ay nakakaapekto sa performance, scalability, at karanasan ng gumagamit. **Streamable HTTP** ang inirerekomenda para sa mga modernong, scalable, at cloud-ready na aplikasyon.

Pansinin ang mga transport na stdio at SSE na ipinakita sa mga naunang kabanata at kung paano ang streamable HTTP ang tinalakay sa kabanatang ito.

## Streaming: Mga Konsepto at Dahilan

Mahalagang maunawaan ang mga pangunahing konsepto at dahilan sa likod ng streaming para sa epektibong pagpapatupad ng real-time na komunikasyon.

**Streaming** ay isang teknik sa network programming na nagpapahintulot na ang datos ay maipadala at matanggap nang paunti-unti o bilang sunud-sunod na mga pangyayari, sa halip na maghintay na matapos ang buong tugon. Ito ay kapaki-pakinabang lalo na para sa:

- Malalaking file o dataset.
- Real-time na mga update (hal. chat, progress bars).
- Mahahabang proseso kung saan nais mong ipaalam sa gumagamit ang progreso.

Narito ang mga dapat mong malaman tungkol sa streaming sa pangkalahatan:

- Unti-unting naihahatid ang datos, hindi sabay-sabay.
- Maaaring iproseso ng kliyente ang datos habang dumarating.
- Nakababawas ng latency na nararamdaman at nagpapabuti ng karanasan ng gumagamit.

### Bakit gamitin ang streaming?

Narito ang mga dahilan kung bakit gamitin ang streaming:

- Agad na nakakatanggap ng feedback ang mga gumagamit, hindi lang sa dulo.
- Nagpapahintulot ng real-time na aplikasyon at responsive na UI.
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

Ipinapakita ng halimbawang ito ang server na nagpapadala ng serye ng mga mensahe sa kliyente habang ito ay available, sa halip na maghintay na lahat ng mensahe ay handa na.

**Paano ito gumagana:**
- Ipinapadala ng server ang bawat mensahe kapag ito ay handa na.
- Tinatanggap at piniprint ng kliyente ang bawat bahagi habang dumarating.

**Mga Kinakailangan:**
- Dapat gumamit ang server ng streaming response (hal. `StreamingResponse` sa FastAPI).
- Dapat iproseso ng kliyente ang tugon bilang stream (`stream=True` sa requests).
- Karaniwang `Content-Type` ay `text/event-stream` o `application/octet-stream`.

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
- Gumagamit ng reactive stack ng Spring Boot gamit ang `Flux` para sa streaming
- `ServerSentEvent` ay nagbibigay ng structured event streaming na may mga uri ng event
- `WebClient` gamit ang `bodyToFlux()` ay nagpapahintulot ng reactive streaming consumption
- `delayElements()` ay nagsisimula ng processing time sa pagitan ng mga event
- Maaaring magkaroon ng mga uri ng event (`info`, `result`) para sa mas mahusay na paghawak ng kliyente

</details>

### Paghahambing: Classic Streaming vs MCP Streaming

Ang mga pagkakaiba sa pagitan ng klasikong streaming at streaming sa MCP ay maaaring ipakita tulad nito:

| Katangian             | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|-----------------------|-------------------------------|-----------------------------------|
| Pangunahing tugon     | Chunked                       | Isa lang, sa dulo                 |
| Mga update sa progreso | Ipinapadala bilang data chunks | Ipinapadala bilang mga notification |
| Kinakailangan ng kliyente | Kailangang iproseso ang stream | Kailangang magpatupad ng message handler |
| Gamit                 | Malalaking file, AI token streams | Progreso, logs, real-time feedback |

### Mga Pangunahing Pagkakaiba

Bukod dito, narito ang ilang pangunahing pagkakaiba:

- **Pattern ng Komunikasyon:**
   - Classic HTTP streaming: Gumagamit ng simpleng chunked transfer encoding para magpadala ng data sa mga bahagi
   - MCP streaming: Gumagamit ng structured notification system gamit ang JSON-RPC protocol

- **Format ng Mensahe:**
   - Classic HTTP: Plain text chunks na may mga newline
   - MCP: Structured LoggingMessageNotification objects na may metadata

- **Implementasyon ng Kliyente:**
   - Classic HTTP: Simpleng kliyente na nagpoproseso ng streaming responses
   - MCP: Mas sopistikadong kliyente na may message handler para iproseso ang iba't ibang uri ng mensahe

- **Mga Update sa Progreso:**
   - Classic HTTP: Bahagi ng pangunahing response stream ang progreso
   - MCP: Ipinapadala ang progreso sa pamamagitan ng hiwalay na notification messages habang ang pangunahing tugon ay dumarating sa dulo

### Mga Rekomendasyon

Narito ang ilang mga bagay na inirerekomenda kapag pipili sa pagitan ng klasikong streaming (gaya ng ipinakita sa `/stream` endpoint) at streaming gamit ang MCP.

- **Para sa simpleng pangangailangan sa streaming:** Mas madali ang klasikong HTTP streaming at sapat na para sa mga basic na pangangailangan.

- **Para sa komplikado at interactive na aplikasyon:** Nagbibigay ang MCP streaming ng mas istrukturadong paraan na may mas mayamang metadata at paghihiwalay ng notifications at final results.

- **Para sa AI na aplikasyon:** Lalo na kapaki-pakinabang ang notification system ng MCP para sa mahahabang AI tasks kung saan nais mong ipaalam sa mga gumagamit ang progreso.

## Streaming sa MCP

Ngayon na nakita mo na ang mga rekomendasyon at paghahambing tungkol sa klasikong streaming at MCP streaming, tatalakayin natin nang detalyado kung paano mo magagamit ang streaming sa MCP.

Mahalagang maunawaan kung paano gumagana ang streaming sa loob ng MCP framework para makabuo ng mga responsive na aplikasyon na nagbibigay ng real-time na feedback sa mga gumagamit habang tumatakbo ang mahahabang operasyon.

Sa MCP, ang streaming ay hindi tungkol sa pagpapadala ng pangunahing tugon nang paunti-unti, kundi tungkol sa pagpapadala ng **notifications** sa kliyente habang pinoproseso ng tool ang isang kahilingan. Ang mga notification na ito ay maaaring maglaman ng mga update sa progreso, logs, o iba pang mga pangyayari.

### Paano ito gumagana

Ang pangunahing resulta ay ipinapadala pa rin bilang isang solong tugon. Gayunpaman, ang mga notification ay maaaring ipadala bilang hiwalay na mga mensahe habang nagpapatuloy ang proseso upang ma-update ang kliyente nang real time. Dapat kayang tanggapin at ipakita ng kliyente ang mga notification na ito.

## Ano ang Notification?

Sinabi nating "Notification", ano ang ibig sabihin nito sa konteksto ng MCP?

Ang notification ay isang mensahe mula sa server papunta sa kliyente upang ipaalam ang progreso, status, o iba pang mga pangyayari habang tumatakbo ang isang mahaba o komplikadong operasyon. Pinapabuti ng mga notification ang transparency at karanasan ng gumagamit.

Halimbawa, ang kliyente ay dapat magpadala ng notification kapag nagawa na ang unang handshake sa server.

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

Para gumana ang logging, kailangang i-enable ito ng server bilang feature/capability tulad nito:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Depende sa SDK na ginagamit, maaaring naka-enable na ang logging bilang default, o kailangan mo itong i-enable nang manu-mano sa configuration ng server.

May iba't ibang uri ng notification:

| Antas      | Paglalarawan                  | Halimbawa ng Gamit            |
|------------|------------------------------|------------------------------|
| debug      | Detalyadong impormasyon para sa debugging | Mga entry/exit point ng function |
| info       | Pangkalahatang impormasyon    | Mga update sa progreso ng operasyon |
| notice     | Normal ngunit mahalagang mga pangyayari | Mga pagbabago sa configuration |
| warning    | Mga kondisyon na babala      | Paggamit ng deprecated na feature |
| error      | Mga kondisyon ng error       | Pagkabigo ng operasyon       |
| critical   | Kritikal na kondisyon         | Pagkabigo ng bahagi ng sistema |
| alert      | Kailangang agad na aksyunan   | Natuklasang corruption ng data |
| emergency  | Hindi magamit ang sistema     | Kumpletong pagkasira ng sistema |

## Pagpapatupad ng Notifications sa MCP

Para magpatupad ng notifications sa MCP, kailangan mong i-setup ang parehong server at client upang hawakan ang real-time na mga update. Pinapayagan nito ang iyong aplikasyon na magbigay ng agarang feedback sa mga gumagamit habang tumatakbo ang mahahabang operasyon.

### Sa Server: Pagpapadala ng Notifications

Magsimula tayo sa server side. Sa MCP, nagdedeklara ka ng mga tool na maaaring magpadala ng notifications habang pinoproseso ang mga kahilingan. Ginagamit ng server ang context object (karaniwang `ctx`) para magpadala ng mga mensahe sa kliyente.

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

Sa naunang halimbawa, ang tool na `process_files` ay nagpapadala ng tatlong notifications sa kliyente habang pinoproseso ang bawat file. Ginagamit ang `ctx.info()` method para magpadala ng mga impormasyong mensahe.

</details>

Bukod dito, para paganahin ang notifications, siguraduhing gumagamit ang server ng streaming transport (tulad ng `streamable-http`) at ang kliyente ay may message handler para iproseso ang mga notification. Ganito ang pag-setup ng server para gamitin ang `streamable-http` transport:

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

Sa halimbawang .NET na ito, ang tool na `ProcessFiles` ay may `Tool` attribute at nagpapadala ng tatlong notifications sa kliyente habang pinoproseso ang bawat file. Ginagamit ang `ctx.Info()` method para magpadala ng mga impormasyong mensahe.

Para paganahin ang notifications sa iyong .NET MCP server, siguraduhing gumagamit ka ng streaming transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Sa Client: Pagtanggap ng Notifications

Dapat magpatupad ang kliyente ng message handler para iproseso at ipakita ang mga notification habang dumarating.

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

Sa code na ito, sinusuri ng `message_handler` function kung ang papasok na mensahe ay notification. Kung oo, ipiniprint nito ang notification; kung hindi, ipinoproseso ito bilang regular na mensahe mula sa server. Pansinin din kung paano ini-initialize ang `ClientSession` gamit ang `message_handler` para hawakan ang mga papasok na notification.

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

Sa halimbawang .NET na ito, sinusuri ng `MessageHandler` function kung ang papasok na mensahe ay notification. Kung oo, ipiniprint nito ang notification; kung hindi, ipinoproseso ito bilang regular na mensahe mula sa server. Ini-initialize ang `ClientSession` gamit ang message handler sa pamamagitan ng `ClientSessionOptions`.

</details>

Para paganahin ang notifications, siguraduhing gumagamit ang server ng streaming transport (tulad ng `streamable-http`) at ang kliyente ay may message handler para iproseso ang mga notification.

## Mga Progress Notification at Mga Senaryo

Ipinaliwanag sa seksyong ito ang konsepto ng progress notifications sa MCP, bakit ito mahalaga, at kung paano ito ipinatutupad gamit ang Streamable HTTP. Makakakita ka rin ng praktikal na gawain para palalimin ang iyong pag-unawa.

Ang progress notifications ay mga real-time na mensahe mula sa server papunta sa kliyente habang tumatakbo ang mahahabang operasyon. Sa halip na maghintay na matapos ang buong proseso, patuloy na ina-update ng server ang kliyente tungkol sa kasalukuyang estado. Pinapabuti nito ang transparency, karanasan ng gumagamit, at nagpapadali ng debugging.

**Halimbawa:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Bakit Gamitin ang Progress Notifications?

Mahalaga ang progress notifications dahil sa mga sumusunod:

- **Mas magandang karanasan ng gumagamit:** Nakikita ng mga gumagamit ang mga update habang nagpapatuloy ang trabaho, hindi lang sa dulo.
- **Real-time na feedback:** Maaaring magpakita ang mga kliyente ng progress bars o logs, kaya mas responsive ang app.
- **Mas madaling debugging at monitoring:** Nakikita ng mga developer at gumagamit kung saan maaaring bumagal o maipit ang proseso.

### Paano Ipatupad ang Progress Notifications

Ganito ang paraan ng pagpapatupad ng progress notifications sa MCP:

- **Sa server:** Gamitin ang `ctx.info()` o `ctx.log()` para magpadala ng notifications habang pinoproseso ang bawat item. Nagpapadala ito ng mensahe sa kliyente bago pa man maging handa ang pangunahing resulta.
- **Sa kliyente:** Magpatupad ng message handler na nakikinig at nagpapakita ng mga notification habang dumarating. Nakikilala ng handler na ito ang pagkakaiba ng notifications at ng panghuling resulta.

**Halimbawa sa Server:**

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

**Halimbawa ng Kliyente:**

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

Kapag nag-iimplementa ng MCP servers gamit ang HTTP-based na mga transport, ang seguridad ay nagiging pangunahing alalahanin na nangangailangan ng maingat na pagtutok sa iba't ibang paraan ng pag-atake at mga mekanismo ng proteksyon.

### Pangkalahatang-ideya

Mahalaga ang seguridad kapag inilalantad ang MCP servers sa HTTP. Ang Streamable HTTP ay nagdadala ng mga bagong panganib at nangangailangan ng maingat na pagsasaayos.

### Mga Pangunahing Punto
- **Pag-validate ng Origin Header**: Laging i-validate ang `Origin` header upang maiwasan ang DNS rebinding attacks.
- **Localhost Binding**: Para sa lokal na pag-develop, i-bind ang mga server sa `localhost` upang hindi ito ma-expose sa pampublikong internet.
- **Authentication**: Magpatupad ng authentication (hal., API keys, OAuth) para sa mga production deployment.
- **CORS**: Isaayos ang mga polisiya ng Cross-Origin Resource Sharing (CORS) upang limitahan ang access.
- **HTTPS**: Gumamit ng HTTPS sa production para i-encrypt ang trapiko.

### Mga Pinakamahusay na Gawi
- Huwag kailanman pagkatiwalaan ang mga papasok na request nang walang validation.
- I-log at i-monitor ang lahat ng access at mga error.
- Regular na i-update ang mga dependencies upang ma-patch ang mga kahinaan sa seguridad.

### Mga Hamon
- Pagtutugma ng seguridad at kadalian sa pag-develop
- Pagtitiyak ng compatibility sa iba't ibang client environment


## Pag-upgrade mula SSE patungong Streamable HTTP

Para sa mga aplikasyon na kasalukuyang gumagamit ng Server-Sent Events (SSE), ang paglipat sa Streamable HTTP ay nagbibigay ng mas malawak na kakayahan at mas matibay na pangmatagalang suporta para sa iyong mga MCP implementation.

### Bakit Mag-upgrade?

May dalawang malakas na dahilan para mag-upgrade mula SSE patungong Streamable HTTP:

- Nagbibigay ang Streamable HTTP ng mas mahusay na scalability, compatibility, at mas mayamang suporta sa notification kumpara sa SSE.
- Ito ang inirerekomendang transport para sa mga bagong MCP application.

### Mga Hakbang sa Migrasyon

Narito kung paano ka makakapag-migrate mula SSE patungong Streamable HTTP sa iyong mga MCP application:

- **I-update ang server code** upang gamitin ang `transport="streamable-http"` sa `mcp.run()`.
- **I-update ang client code** upang gamitin ang `streamablehttp_client` sa halip na SSE client.
- **Mag-implementa ng message handler** sa client para iproseso ang mga notification.
- **Subukan ang compatibility** sa mga kasalukuyang tools at workflows.

### Pagpapanatili ng Compatibility

Inirerekomenda na panatilihin ang compatibility sa mga kasalukuyang SSE client habang isinasagawa ang migrasyon. Narito ang ilang mga estratehiya:

- Maaari mong suportahan ang parehong SSE at Streamable HTTP sa pamamagitan ng pagpapatakbo ng parehong transport sa magkaibang endpoints.
- Unti-unting i-migrate ang mga client sa bagong transport.

### Mga Hamon

Siguraduhing matugunan ang mga sumusunod na hamon habang nagmi-migrate:

- Pagtitiyak na lahat ng client ay na-update
- Paghawak sa mga pagkakaiba sa paraan ng paghahatid ng notification

## Mga Pagsasaalang-alang sa Seguridad

Dapat maging pangunahing prayoridad ang seguridad kapag nag-iimplementa ng anumang server, lalo na kapag gumagamit ng HTTP-based na mga transport tulad ng Streamable HTTP sa MCP.

Kapag nag-iimplementa ng MCP servers gamit ang HTTP-based na mga transport, ang seguridad ay nagiging pangunahing alalahanin na nangangailangan ng maingat na pagtutok sa iba't ibang paraan ng pag-atake at mga mekanismo ng proteksyon.

### Pangkalahatang-ideya

Mahalaga ang seguridad kapag inilalantad ang MCP servers sa HTTP. Ang Streamable HTTP ay nagdadala ng mga bagong panganib at nangangailangan ng maingat na pagsasaayos.

Narito ang ilang mahahalagang pagsasaalang-alang sa seguridad:

- **Pag-validate ng Origin Header**: Laging i-validate ang `Origin` header upang maiwasan ang DNS rebinding attacks.
- **Localhost Binding**: Para sa lokal na pag-develop, i-bind ang mga server sa `localhost` upang hindi ito ma-expose sa pampublikong internet.
- **Authentication**: Magpatupad ng authentication (hal., API keys, OAuth) para sa mga production deployment.
- **CORS**: Isaayos ang mga polisiya ng Cross-Origin Resource Sharing (CORS) upang limitahan ang access.
- **HTTPS**: Gumamit ng HTTPS sa production para i-encrypt ang trapiko.

### Mga Pinakamahusay na Gawi

Bukod dito, narito ang ilang pinakamahusay na gawi na dapat sundin kapag nag-iimplementa ng seguridad sa iyong MCP streaming server:

- Huwag kailanman pagkatiwalaan ang mga papasok na request nang walang validation.
- I-log at i-monitor ang lahat ng access at mga error.
- Regular na i-update ang mga dependencies upang ma-patch ang mga kahinaan sa seguridad.

### Mga Hamon

Makakaharap ka ng ilang hamon kapag nag-iimplementa ng seguridad sa MCP streaming servers:

- Pagtutugma ng seguridad at kadalian sa pag-develop
- Pagtitiyak ng compatibility sa iba't ibang client environment

### Takdang-Aralin: Gumawa ng Sariling Streaming MCP App

**Senaryo:**
Gumawa ng MCP server at client kung saan ang server ay nagpoproseso ng listahan ng mga item (hal., mga file o dokumento) at nagpapadala ng notification para sa bawat item na naproseso. Dapat ipakita ng client ang bawat notification habang dumarating ito.

**Mga Hakbang:**

1. Mag-implementa ng server tool na nagpoproseso ng listahan at nagpapadala ng mga notification para sa bawat item.
2. Mag-implementa ng client na may message handler upang ipakita ang mga notification nang real time.
3. Subukan ang iyong implementasyon sa pamamagitan ng pagpapatakbo ng parehong server at client, at obserbahan ang mga notification.

[Solution](./solution/README.md)

## Karagdagang Babasahin at Ano ang Susunod?

Para ipagpatuloy ang iyong paglalakbay sa MCP streaming at palawakin ang iyong kaalaman, nagbibigay ang seksyong ito ng karagdagang mga mapagkukunan at mga mungkahing susunod na hakbang para sa paggawa ng mas advanced na mga aplikasyon.

### Karagdagang Babasahin

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### Ano ang Susunod?

- Subukang gumawa ng mas advanced na MCP tools na gumagamit ng streaming para sa real-time analytics, chat, o collaborative editing.
- Tuklasin ang pagsasama ng MCP streaming sa mga frontend framework (React, Vue, atbp.) para sa live na pag-update ng UI.
- Susunod: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.