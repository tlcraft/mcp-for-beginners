<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:38:42+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "my"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

ဤအခန်းတွင် HTTPS ကို အသုံးပြု၍ Model Context Protocol (MCP) ဖြင့် လုံခြုံပြီး၊ တိုးချဲ့နိုင်သော၊ အချိန်နောက်ကျခြင်းမရှိသော streaming ကို အကောင်အထည်ဖော်နည်းများအား လက်တွေ့ ညွှန်ပြထားသည်။ Streaming ကို အသုံးပြုရခြင်းရဲ့ အကြောင်းရင်း၊ ရရှိနိုင်သော သယ်ယူပို့ဆောင်မှုနည်းလမ်းများ၊ MCP တွင် streamable HTTP ကို အကောင်အထည်ဖော်နည်း၊ လုံခြုံရေးအကောင်းဆုံးလုပ်ထုံးလုပ်နည်းများ၊ SSE မှ ပြောင်းရွှေ့ခြင်း၊ သင့်ကိုယ်ပိုင် streaming MCP အက်ပလီကေးရှင်းများ ဖန်တီးရာတွင် လိုအပ်သော လမ်းညွှန်ချက်များကို ပါဝင်ဖော်ပြထားသည်။

## Transport Mechanisms and Streaming in MCP

ဤအပိုင်းတွင် MCP တွင် ရရှိနိုင်သော သယ်ယူပို့ဆောင်မှုနည်းလမ်းအမျိုးမျိုးနှင့် ၎င်းတို့၏ client နှင့် server အကြား အချိန်နောက်ကျမှုမရှိသော ဆက်သွယ်မှုများအတွက် streaming လုပ်ဆောင်နိုင်စွမ်းများ ဖော်ဆောင်ပေးသည့် အခန်းကဏ္ဍကို လေ့လာရှုကြမည်။

### Transport Mechanism ဆိုတာဘာလဲ?

Transport mechanism ဆိုသည်မှာ client နှင့် server အကြား ဒေတာလဲလှယ်မှုကို ဘယ်လို ပြုလုပ်မည်ဆိုသည်ကို သတ်မှတ်သည်။ MCP သည် ပတ်ဝန်းကျင်နှင့် လိုအပ်ချက်အမျိုးမျိုးအတွက် သင့်တော်သော သယ်ယူပို့ဆောင်မှုအမျိုးအစားများစွာကို ထောက်ပံ့ပေးသည်-

- **stdio**: standard input/output ဖြစ်ပြီး ဒေသတွင်းနှင့် CLI အခြေပြုကိရိယာများအတွက် သင့်တော်သည်။ ရိုးရှင်းသော်လည်း web သို့မဟုတ် cloud အတွက် မသင့်တော်ပါ။
- **SSE (Server-Sent Events)**: server များမှ client များသို့ HTTP အပေါ်မှ အချိန်နောက်ကျမှုမရှိသော အပ်ဒိတ်များကို ပို့နိုင်သည်။ web UI များအတွက် ကောင်းမွန်သော်လည်း တိုးချဲ့နိုင်မှုနှင့် လွယ်ကူမှုမှာ ကန့်သတ်ချက်ရှိသည်။
- **Streamable HTTP**: ခေတ်မီသော HTTP အခြေပြု streaming သယ်ယူပို့ဆောင်မှုဖြစ်ပြီး အသိပေးချက်များနှင့် တိုးချဲ့နိုင်မှုကောင်းမွန်မှုများ ပံ့ပိုးပေးသည်။ ထုတ်လုပ်မှုနှင့် cloud ပတ်ဝန်းကျင်များအတွက် အကြံပြုသည်။

### နှိုင်းယှဉ်ဇယား

အောက်ပါ ဇယားတွင် သယ်ယူပို့ဆောင်မှုနည်းလမ်းများ၏ ကွာခြားချက်များကို နားလည်နိုင်ရန် ဖော်ပြထားသည်-

| Transport         | Real-time Updates | Streaming | Scalability | Use Case                |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | မဟုတ်ပါ         | မဟုတ်ပါ  | နည်းပါးသည်  | ဒေသတွင်း CLI ကိရိယာများ |
| SSE               | ဟုတ်သည်          | ဟုတ်သည်   | အလယ်အလတ်    | web၊ အချိန်နောက်ကျမှုမရှိသော အပ်ဒိတ်များ |
| Streamable HTTP   | ဟုတ်သည်          | ဟုတ်သည်   | မြင့်မားသည်  | cloud၊ client များစွာ |

> **Tip:** သင့်တော်သော သယ်ယူပို့ဆောင်မှုကို ရွေးချယ်ခြင်းသည် စွမ်းဆောင်ရည်၊ တိုးချဲ့နိုင်မှုနှင့် အသုံးပြုသူ အတွေ့အကြုံကို ထိခိုက်စေသည်။ ခေတ်မီ၊ တိုးချဲ့နိုင်ပြီး cloud သင့်လျော်သော အက်ပလီကေးရှင်းများအတွက် **Streamable HTTP** ကို အကြံပြုပါသည်။

ယခင်အခန်းများတွင် ပြသခဲ့သော stdio နှင့် SSE သယ်ယူပို့ဆောင်မှုများနှင့် ယခုအခန်းတွင် ဖော်ပြထားသော streamable HTTP သယ်ယူပို့ဆောင်မှုကို သတိပြုကြပါ။

## Streaming: Concepts and Motivation

Streaming ၏ အခြေခံသဘောတရားများနှင့် အကြောင်းရင်းများကို နားလည်ခြင်းသည် အချိန်နောက်ကျမှုမရှိသော ဆက်သွယ်မှုစနစ်များကို ထိရောက်စွာ တည်ဆောက်ရာတွင် အရေးကြီးသည်။

**Streaming** သည် network programming တွင် ဒေတာများကို တစ်ပြိုင်နက်တည်း ပြီးပြည့်စုံသော တုံ့ပြန်ချက်အတွက် မစောင့်ပဲ၊ သေးငယ်ပြီး စီမံနိုင်သော အပိုင်းအစများ သို့မဟုတ် ဖြစ်ရပ်စဉ်များ အဆက်မပြတ် ပို့ဆောင်ခြင်းနည်းလမ်းဖြစ်သည်။ ၎င်းသည် အထူးသဖြင့် အောက်ပါအရာများအတွက် အသုံးဝင်သည်-

- ဖိုင်များ သို့မဟုတ် ဒေတာစုစည်းမှုကြီးများ။
- အချိန်နောက်ကျမှုမရှိသော အပ်ဒိတ်များ (ဥပမာ - စကားပြော, တိုးတက်မှု ဘားများ)။
- ကြာရှည်သည့် တွက်ချက်မှုများတွင် အသုံးပြုသူကို အဆက်မပြတ် သတင်းပေးရန်။

Streaming အကြောင်းအရာကို အထွေထွေသိရှိရန်-

- ဒေတာများကို တစ်ပြိုင်နက်တည်း မပို့ပဲ တဖြည်းဖြည်းပို့သည်။
- client သည် ဒေတာရောက်ရှိသလို ကိုင်တွယ်နိုင်သည်။
- အချိန်နောက်ကျမှုခံစားမှု လျော့နည်းပြီး အသုံးပြုသူ အတွေ့အကြုံကောင်းမွန်စေသည်။

### Streaming ကို ဘာကြောင့် အသုံးပြုသနည်း?

Streaming အသုံးပြုရခြင်း၏ အကြောင်းရင်းများမှာ-

- အသုံးပြုသူများသည် အဆုံးသတ်မီ မဟုတ်ဘဲ ချက်ချင်းတုံ့ပြန်မှုရရှိသည်။
- အချိန်နောက်ကျမှုမရှိသော အက်ပလီကေးရှင်းများနှင့် တုံ့ပြန်မှုမြန်သော UI များ ဖန်တီးနိုင်သည်။
- ကွန်ရက်နှင့် ကွန်ပျူတာ အရင်းအမြစ်များကို ထိရောက်စွာ အသုံးပြုနိုင်သည်။

### ရိုးရှင်းသော ဥပမာ - HTTP Streaming Server & Client

Streaming ကို အကောင်အထည်ဖော်နိုင်ပုံ ရိုးရှင်းစွာ ဖော်ပြထားသည်-

<details>
<summary>Python</summary>

**Server (Python, FastAPI နှင့် StreamingResponse အသုံးပြု၍):**
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

**Client (Python, requests အသုံးပြု၍):**
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

ဤဥပမာတွင် server သည် စာတိုများစွာကို ပြင်ဆင်ပြီး client သို့ တစ်ခုချင်းစီ ပို့ပေးသည်။ စာတိုအားလုံး ပြင်ဆင်ပြီးမှ မစောင့်ဘဲဖြစ်သည်။

**အလုပ်လုပ်ပုံ:**
- server သည် စာတိုတစ်ခုချင်းစီ ပြင်ဆင်ပြီးတိုင်း ပေးပို့သည်။
- client သည် စာတိုများ ရောက်ရှိသလို လက်ခံပြီး ပုံနှိပ်ပြသည်။

**လိုအပ်ချက်များ:**
- server သည် streaming response (ဥပမာ `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`) ကို အသုံးပြုရမည်။

</details>

<details>
<summary>Java</summary>

**Server (Java, Spring Boot နှင့် Server-Sent Events အသုံးပြု၍):**

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

**Client (Java, Spring WebFlux WebClient အသုံးပြု၍):**

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

**Java အကောင်အထည်ဖော်ချက်မှတ်စုများ:**
- Spring Boot ၏ reactive stack ကို အသုံးပြု၍ `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream` တို့ဖြင့် streaming ကို ဆောင်ရွက်သည်။
- MCP မှ streaming ကို ရွေးချယ်ခြင်းနှင့် နှိုင်းယှဉ်၍ အလုပ်လုပ်ပုံကွာခြားသည်။

- **ရိုးရှင်းသော streaming လိုအပ်ချက်များအတွက်:** Classic HTTP streaming သည် ပိုမိုရိုးရှင်းပြီး မူလ streaming လိုအပ်ချက်များအတွက် လုံလောက်သည်။

- **ရှုပ်ထွေးပြီး အပြန်အလှန်ဆက်သွယ်မှုများရှိသော အက်ပလီကေးရှင်းများအတွက်:** MCP streaming သည် အသေးစိတ် metadata များနှင့် အသိပေးချက်များနှင့် နောက်ဆုံးရလဒ်များကို ခွဲခြားပေးသည့် ပိုမိုစနစ်တကျသော နည်းလမ်းဖြစ်သည်။

- **AI အက်ပလီကေးရှင်းများအတွက်:** MCP ၏ အသိပေးစနစ်သည် ကြာရှည်ဆက်လက် ဆောင်ရွက်နေသည့် AI အလုပ်များတွင် အသုံးပြုသူအား တိုးတက်မှုအခြေအနေများကို သတင်းပေးရန် အထူးအသုံးဝင်သည်။

## Streaming in MCP

ယခုအထိ classical streaming နှင့် MCP streaming ၏ ကွာခြားချက်များနှင့် အကြံပြုချက်များကို ကြည့်ရှုခဲ့ပါပြီ။ ယခု MCP တွင် streaming ကို မည်သို့ အသုံးချနိုင်သည်ကို အသေးစိတ် ရှင်းပြမည်။

MCP စနစ်အတွင်း streaming ၏ အလုပ်လုပ်ပုံကို နားလည်ခြင်းသည် ကြာရှည်ဆောင်ရွက်နေစဉ် အသုံးပြုသူအား အချိန်နောက်ကျမှုမရှိသော တုံ့ပြန်မှုများ ပေးနိုင်သော အက်ပလီကေးရှင်းများ ဖန်တီးရာတွင် အရေးကြီးသည်။

MCP တွင် streaming သည် အဓိက တုံ့ပြန်ချက်ကို အပိုင်းအစများဖြင့် ပို့ခြင်းမဟုတ်ပဲ၊ တူညီသော အချိန်တွင် ကိရိယာတစ်ခုက တောင်းဆိုချက်ကို လုပ်ဆောင်နေစဉ် client သို့ **အသိပေးချက်များ** ပို့ခြင်းဖြစ်သည်။ ၎င်းအသိပေးချက်များတွင် တိုးတက်မှု အပ်ဒိတ်များ၊ မှတ်တမ်းများ သို့မဟုတ် အခြား ဖြစ်ရပ်များ ပါဝင်နိုင်သည်။

### အလုပ်လုပ်ပုံ

အဓိကရလဒ်ကို တစ်ခုတည်းသော တုံ့ပြန်ချက်အဖြစ် ပေးပို့သည်။ သို့သော် processing ဖြစ်စဉ်အတွင်း အသိပေးချက်များကို သီးခြားစာတိုများအဖြစ် ပို့နိုင်ပြီး client ကို အချိန်နောက်ကျမှုမရှိစွာ update ပြုလုပ်ပေးသည်။ client သည် ဤအသိပေးချက်များကို ကိုင်တွယ်ပြီး ပြသနိုင်ရမည်။

## Notification ဆိုတာဘာလဲ?

ကျွန်ုပ်တို့ "Notification" ဟု ဆိုခဲ့သည်။ MCP အတွင်း၌ ၎င်းသည် ဘာကို ဆိုလိုသနည်း?

Notification သည် server မှ client သို့ ကြာရှည်ဆောင်ရွက်နေသော လုပ်ငန်းစဉ်တစ်ခုအတွင်း တိုးတက်မှု၊ အခြေအနေ သို့မဟုတ် အခြားဖြစ်ရပ်များကို အသိပေးရန် ပို့သော စာတိုဖြစ်သည်။ Notification များသည် ထင်မြင်နိုင်မှုကို တိုးတက်စေပြီး အသုံးပြုသူ အတွေ့အကြုံကို မြှင့်တင်ပေးသည်။

ဥပမာအားဖြင့် client သည် server နှင့် အစပျိုးချိတ်ဆက်မှု ပြုလုပ်ပြီးနောက် Notification တစ်ခု ပို့ရမည်ဖြစ်သည်။

Notification သည် JSON စာတိုအဖြစ် အောက်ပါပုံစံဖြစ်သည်-

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notification များသည် MCP ၏ ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) ဟူသော ခေါင်းစဉ်တစ်ခုတွင် ပါဝင်သည်။

Logging ကို အလုပ်လုပ်စေရန် server သည် ၎င်းကို feature/capability အဖြစ် ဖွင့်ထားရမည်-

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> သုံးနေသော SDK အပေါ် မူတည်၍ logging သည် ပုံမှန်အားဖြင့် ဖွင့်ထားနိုင်သည်၊ သို့မဟုတ် server configuration တွင် သင့်တော်စွာ ဖွင့်ရပါမည်။

Notification များအမျိုးအစားများ-

| Level     | ဖော်ပြချက်                    | ဥပမာ အသုံးပြုမှု              |
|-----------|-------------------------------|---------------------------------|
| debug     | အသေးစိတ် debugging အချက်အလက်များ | function ဝင်/ထွက်နေရာများ       |
| info      | အထွေထွေ သတင်းအချက်အလက်များ    | လုပ်ငန်းတိုးတက်မှု အပ်ဒိတ်များ     |
| notice    | သာမာန် သို့မဟုတ် အရေးကြီးဖြစ်ရပ်များ | စနစ်ပြင်ဆင်မှုများ               |
| warning   | သတိပေး အခြေအနေများ              | အဟောင်း features အသုံးပြုမှု      |
| error     | အမှားအခြေအနေများ                 | လုပ်ငန်းကျရှုံးမှုများ             |
| critical  | အရေးပေါ် အခြေအနေများ             | စနစ်အစိတ်အပိုင်း မအောင်မြင်မှုများ  |
| alert     | ချက်ချင်း လုပ်ဆောင်ရမည့် အရေးပေါ်    | ဒေတာပျက်စီးမှုတွေ့ရှိမှု          |
| emergency | စနစ် အသုံးမပြုနိုင်ခြင်း           | စနစ်လုံးဝ ပျက်စီးမှု               |

## MCP တွင် Notification များ အကောင်အထည်ဖော်ခြင်း

MCP တွင် notification များကို အကောင်အထည်ဖော်ရန် server နှင့် client နှစ်ဖက်စလုံးတွင် အချိန်နောက်ကျမှုမရှိသော အပ်ဒိတ်များကို ကိုင်တွယ်နိုင်ရန် ပြင်ဆင်ရမည်။ ၎င်းသည် ကြာရှည်ဆောင်ရွက်နေစဉ် အသုံးပြုသူအား ချက်ချင်းတုံ့ပြန်မှု ပေးနိုင်စေသည်။

### Server ဘက် - Notification ပို့ခြင်း

server ဘက်မှ စတင်မည်။ MCP တွင် request များကို လုပ်ဆောင်စဉ် notification ပို့နိုင်သော tools များကို သတ်မှတ်သည်။ server သည် context object (အများအားဖြင့် `ctx`) ကို အသုံးပြု၍ client သို့ စာတိုများ ပို့သည်။

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

အထက်ပါ ဥပမာတွင် `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` သယ်ယူပို့ဆောင်မှုကို အသုံးပြုထားသည်-

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

ဤ .NET ဥပမာတွင် `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` ကို အသုံးပြု၍ သတင်းအချက်အလက်များ ပို့သည်။

သင့် .NET MCP server တွင် notification များဖွင့်ရန် streaming transport ကို သုံးပါ-

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Client ဘက် - Notification လက်ခံခြင်း

client သည် notification များ ရောက်ရှိသလို ကိုင်တွယ်ပြသနိုင်ရန် message handler တစ်ခု ထည့်သွင်းရမည်။

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

အထက်ပါ ကုဒ်တွင် `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` သည် လက်ခံလာသော notification များကို ကိုင်တွယ်သည်။

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

ဤ .NET ဥပမာတွင် `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` အသုံးပြု၍ client သည် notification များကို ကိုင်တွယ်သည်။

## Progress Notifications & Scenarios

ဤအပိုင်းတွင် MCP တွင် progress notification ဆိုသည့် အကြောင်းအရာ၊ ၎င်း၏ အရေးကြီးမှုနှင့် Streamable HTTP ဖြင့် မည်သို့ အကောင်အထည်ဖော်ရမည်ကို ဖော်ပြထားသည်။ သင်၏ နားလည်မှုကို ခိုင်မာစေရန် လက်တွေ့ လေ့ကျင့်ခန်းလည်း ပါဝင်သည်။

Progress notification များသည် ကြာရှည်ဆောင်ရွက်နေစဉ် server မှ client သို့ အချိန်နောက်ကျမှုမရှိစွာ ပို့သော စ

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်မှု ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားပေမယ့်၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန်။ မူလစာတမ်းကို မူရင်းဘာသာဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ်ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် ပရော်ဖက်ရှင်နယ် လူသား ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် မတိကျမှုများ သို့မဟုတ် နားမလည်မှုများအတွက် ကျွန်ုပ်တို့တာဝန်မယူပါ။