<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5f1383103523fa822e1fec7ef81904d5",
  "translation_date": "2025-08-18T18:56:42+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "my"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

ဤအခန်းတွင် Model Context Protocol (MCP) ကို အသုံးပြု၍ HTTPS ဖြင့် လုံခြုံမှုရှိသော၊ အရွယ်အစားကြီးမားသော၊ အချိန်နှင့်တပြေးညီ စီးဆင်းမှုကို အကောင်အထည်ဖော်ရန် လမ်းညွှန်ချက်များကို ပေးထားသည်။ Streaming ရဲ့ အဓိကရည်ရွယ်ချက်၊ အသုံးပြုနိုင်သော သယ်ဆောင်မှု Mechanisms များ၊ MCP တွင် Streamable HTTP ကို အကောင်အထည်ဖော်နည်း၊ လုံခြုံမှုအကောင်းဆုံး လုပ်ထုံးလုပ်နည်းများ၊ SSE မှ ပြောင်းရွှေ့ခြင်းနှင့် MCP Streaming Applications ကို တည်ဆောက်ရန် လက်တွေ့လမ်းညွှန်ချက်များကို ဖော်ပြထားသည်။

## Transport Mechanisms နှင့် MCP တွင် Streaming

ဤအပိုင်းတွင် MCP တွင် အသုံးပြုနိုင်သော Transport Mechanisms များနှင့် Client နှင့် Server အကြား အချိန်နှင့်တပြေးညီ ဆက်သွယ်မှုကို အကောင်အထည်ဖော်ရန် ၎င်းတို့၏ အခန်းကဏ္ဍကို လေ့လာမည်။

### Transport Mechanism ဆိုတာဘာလဲ?

Transport Mechanism သည် Client နှင့် Server အကြား ဒေတာကို ဘယ်လို လွှဲပြောင်းပေးပို့မည်ကို သတ်မှတ်သည်။ MCP သည် အခြေအနေများနှင့် လိုအပ်ချက်များကို ဖြည့်ဆည်းရန် Transport အမျိုးအစားများစွာကို ပံ့ပိုးပေးသည်။

- **stdio**: Standard input/output, ဒေသတွင်းနှင့် CLI-based tools များအတွက် သင့်လျော်သည်။ ရိုးရှင်းသော်လည်း Web သို့မဟုတ် Cloud အတွက် မသင့်လျော်ပါ။
- **SSE (Server-Sent Events)**: Server များက HTTP ဖြင့် Client များကို အချိန်နှင့်တပြေးညီ အပ်ဒိတ်များ ပို့နိုင်သည်။ Web UI များအတွက် သင့်လျော်သော်လည်း အရွယ်အစားနှင့် လွယ်ကူမှုမှာ ကန့်သတ်ချက်ရှိသည်။
- **Streamable HTTP**: ခေတ်မီ HTTP-based streaming transport, notifications များနှင့် ပိုမိုကောင်းမွန်သော scalability ကို ပံ့ပိုးပေးသည်။ အများဆုံး production နှင့် cloud scenarios များအတွက် အကြံပြုသည်။

### နှိုင်းယှဉ်ဇယား

Transport Mechanisms များ၏ ကွာခြားချက်များကို နားလည်ရန် အောက်ပါ နှိုင်းယှဉ်ဇယားကို ကြည့်ပါ။

| Transport         | အချိန်နှင့်တပြေးညီ အပ်ဒိတ်များ | Streaming | Scalability | အသုံးပြုမှု                  |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | မရှိပါ               | မရှိပါ        | အနည်းငယ်         | ဒေသတွင်း CLI tools         |
| SSE               | ရှိသည်              | ရှိသည်       | အလယ်အလတ်      | Web, အချိန်နှင့်တပြေးညီ အပ်ဒိတ်များ  |
| Streamable HTTP   | ရှိသည်              | ရှိသည်       | မြင့်မား         | Cloud, multi-client     |

> **Tip:** သင့် Transport ရွေးချယ်မှုသည် စွမ်းဆောင်ရည်၊ အရွယ်အစားနှင့် အသုံးပြုသူအတွေ့အကြုံကို သက်ရောက်စေသည်။ **Streamable HTTP** သည် ခေတ်မီ၊ အရွယ်အစားကြီးမားသော၊ cloud-ready applications များအတွက် အကြံပြုသည်။

## Streaming: အယူအဆများနှင့် ရည်ရွယ်ချက်

Streaming ရဲ့ အခြေခံအယူအဆများနှင့် ရည်ရွယ်ချက်များကို နားလည်ခြင်းသည် အချိန်နှင့်တပြေးညီ ဆက်သွယ်မှုစနစ်များကို အကောင်းဆုံး အကောင်အထည်ဖော်ရန် အရေးကြီးသည်။

**Streaming** သည် Network Programming တွင် ဒေတာကို တစ်ခုပြီးတစ်ခု အဆင့်ဆင့်ပို့ခြင်း သို့မဟုတ် အဖြစ်အပျက်များအနေနှင့် ပို့ခြင်းဖြင့် လုပ်ဆောင်သည့်နည်းလမ်းဖြစ်သည်။ ဒါဟာ အထူးသဖြင့် အောက်ပါအခြေအနေများတွင် အသုံးဝင်သည်-

- ဖိုင်များ သို့မဟုတ် ဒေတာအစုအဝေးများ ကြီးမားသောအခါ
- အချိန်နှင့်တပြေးညီ အပ်ဒိတ်များ (ဥပမာ- chat, progress bars)
- အချိန်ကြာမြင့်သော လုပ်ငန်းများတွင် အသုံးပြုသူကို အခြေအနေများကို အမြဲသိရှိစေလိုသောအခါ

### Streaming ကို ဘာကြောင့် အသုံးပြုသင့်သလဲ?

Streaming ကို အသုံးပြုရသည့် အကြောင်းအရင်းများမှာ-

- အသုံးပြုသူများသည် အလုပ်ပြီးဆုံးသည်အထိ မစောင့်ဘဲ ချက်ချင်း feedback ရရှိသည်။
- အချိန်နှင့်တပြေးညီ applications နှင့် responsive UIs များကို ဖန်တီးနိုင်သည်။
- Network နှင့် compute resources ကို ပိုမိုထိရောက်စွာ အသုံးပြုနိုင်သည်။

### ရိုးရှင်းသော Streaming Server နှင့် Client ဥပမာ

#### Python

**Server (Python, FastAPI နှင့် StreamingResponse ကို အသုံးပြုခြင်း):**

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

**Client (Python, requests ကို အသုံးပြုခြင်း):**

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

ဤဥပမာသည် Server က Client ကို message များကို အဆင့်ဆင့်ပို့ခြင်းကို ပြသသည်။

**ဘယ်လိုအလုပ်လုပ်သလဲ:**

- Server က message တစ်ခုစီကို အဆင့်ဆင့်ပို့သည်။
- Client က message တစ်ခုစီကို ရရှိသည့်အတိုင်း process လုပ်သည်။

#### Java

**Server (Java, Spring Boot နှင့် Server-Sent Events ကို အသုံးပြုခြင်း):**

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

**Client (Java, Spring WebFlux WebClient ကို အသုံးပြုခြင်း):**

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

**Java အကောင်အထည်ဖော်မှု မှတ်ချက်များ:**

- Spring Boot ရဲ့ reactive stack ကို အသုံးပြုသည်။
- `ServerSentEvent` သည် structured event streaming ကို ပံ့ပိုးပေးသည်။
- `WebClient` သည် `bodyToFlux()` ဖြင့် reactive streaming consumption ကို ပံ့ပိုးပေးသည်။

## Streaming in MCP

MCP တွင် Streaming သည် **notifications** ပို့ခြင်းဖြင့် Client ကို အချိန်နှင့်တပြေးညီ update ပေးခြင်းဖြစ်သည်။ 

### Notification ဆိုတာဘာလဲ?

Notification သည် Server မှ Client သို့ progress, status သို့မဟုတ် အခြားအဖြစ်အပျက်များကို အချိန်နှင့်တပြေးညီ update ပေးရန် ပို့သော message ဖြစ်သည်။

Notification များသည် MCP တွင် ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) ဟုခေါ်သော topic တစ်ခုအတွင်း ပါဝင်သည်။

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

## Notifications ကို MCP တွင် အကောင်အထည်ဖော်ခြင်း

### Server-side: Notifications ပို့ခြင်း

#### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

#### .NET

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

### Client-side: Notifications လက်ခံခြင်း

#### Python

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

#### .NET

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

## Progress Notifications နှင့် Scenarios

Progress Notifications သည် Server မှ Client သို့ အချိန်နှင့်တပြေးညီ message များပို့ခြင်းဖြစ်သည်။

**ဥပမာ:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Progress Notifications ကို MCP တွင် အကောင်အထည်ဖော်နည်း

#### Server-side

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

#### Client-side

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

## လုံခြုံမှုစဉ်းစားချက်များ

Streamable HTTP ကို အသုံးပြုသော MCP Servers တွင် လုံခြုံမှုသည် အရေးကြီးသောအချက်ဖြစ်သည်။

### အဓိကအချက်များ

- **Origin Header Validation**: DNS rebinding attacks ကို ကာကွယ်ရန် `Origin` header ကို အမြဲ validate လုပ်ပါ။
- **Localhost Binding**: Development အတွက် `localhost` ကို bind လုပ်ပါ။
- **Authentication**: Production အတွက် authentication (ဥပမာ- API keys, OAuth) ကို အသုံးပြုပါ။
- **CORS**: Cross-Origin Resource Sharing (CORS) policies ကို configure လုပ်ပါ။
- **HTTPS**: Production တွင် HTTPS ကို အသုံးပြုပါ။

### အကောင်းဆုံး လုပ်ထုံးလုပ်နည်းများ

- လာရောက်သော requests များကို validate မလုပ်ဘဲ မယုံကြည်ပါနှင့်။
- Access နှင့် error များအားလုံးကို log လုပ်ပါ။
- Security vulnerabilities များကို patch လုပ်ရန် dependencies များကို regular update လုပ်ပါ။

## SSE မှ Streamable HTTP သို့ Upgrade လုပ်ခြင်း

SSE ကို အသုံးပြုနေသော applications များအတွက် Streamable HTTP သို့ ပြောင်းရွှေ့ခြင်းသည် ပိုမိုကောင်းမွန်သော စွမ်းဆောင်ရည်နှင့် ရေရှည်တည်တံ့မှုကို ပေးစွမ်းနိုင်သည်။

### Upgrade လုပ်ရသည့် အကြောင်းအရင်း

...
SSE မှ Streamable HTTP သို့ အဆင့်မြှင့်တင်ရန် အရေးကြီးသောအကြောင်းအရင်းနှစ်ခုရှိသည်။

- Streamable HTTP သည် SSE ထက် ပိုမိုကောင်းမွန်သော scalability၊ compatibility နှင့် notification ပံ့ပိုးမှုများကို ပေးစွမ်းနိုင်သည်။
- ဒါဟာ MCP အသစ်များအတွက် အကြံပြုထားသော transport ဖြစ်သည်။

### အဆင့်မြှင့်တင်ခြင်းအဆင့်များ

MCP application များတွင် SSE မှ Streamable HTTP သို့ အဆင့်မြှင့်တင်ရန် အောက်ပါအဆင့်များကို လိုက်နာပါ။

- **Server code ကို update လုပ်ပါ** `transport="streamable-http"` ကို `mcp.run()` တွင် အသုံးပြုပါ။
- **Client code ကို update လုပ်ပါ** SSE client အစား `streamablehttp_client` ကို အသုံးပြုပါ။
- **Message handler တစ်ခုကို client တွင် implement လုပ်ပါ** notifications များကို process လုပ်ရန်။
- **Existing tools နှင့် workflows များနှင့် compatibility ရှိမရှိ စမ်းသပ်ပါ။**

### Compatibility ကို ထိန်းသိမ်းခြင်း

Migration လုပ်စဉ်အတွင်း Existing SSE clients များနှင့် compatibility ကို ထိန်းသိမ်းရန် အကြံပြုထားသည်။ အောက်ပါနည်းလမ်းများကို အသုံးပြုနိုင်သည်။

- SSE နှင့် Streamable HTTP နှစ်ခုလုံးကို support လုပ်နိုင်ရန် transport များကို အခြား endpoint များတွင် run လုပ်ပါ။
- Gradually clients များကို transport အသစ်သို့ ပြောင်းပါ။

### စိန်ခေါ်မှုများ

Migration လုပ်စဉ်အတွင်း အောက်ပါ စိန်ခေါ်မှုများကို ဖြေရှင်းရန် သေချာပါ။

- Clients များအားလုံးကို update လုပ်ရန်
- Notification delivery တွင် ကွာခြားမှုများကို ကိုင်တွယ်ရန်

## လုံခြုံရေးအရေးယူမှုများ

MCP server များကို implement လုပ်ရာတွင် HTTP-based transports (Streamable HTTP) ကို အသုံးပြုသောအခါ လုံခြုံရေးသည် အဓိကအရေးပါသည်။

HTTP-based transports ကို အသုံးပြုသော MCP servers များကို implement လုပ်ရာတွင် လုံခြုံရေးသည် အဓိကအရေးပါသောအရာဖြစ်ပြီး attack vectors များနှင့် ကာကွယ်မှု mechanisms များကို ဂရုစိုက်ရန် လိုအပ်သည်။

### အကျဉ်းချုပ်

MCP servers များကို HTTP မှတဆင့် expose လုပ်ရာတွင် လုံခြုံရေးသည် အရေးကြီးသည်။ Streamable HTTP သည် attack surfaces အသစ်များကို ဖန်တီးပြီး သေချာသော configuration လိုအပ်သည်။

အောက်ပါ လုံခြုံရေးအချက်များကို သတိပြုပါ။

- **Origin Header Validation**: DNS rebinding attacks များကို ကာကွယ်ရန် `Origin` header ကို အမြဲ validate လုပ်ပါ။
- **Localhost Binding**: Local development အတွက် servers များကို `localhost` တွင် bind လုပ်ပါ၊ public internet သို့ မဖော်ထုတ်ပါနှင့်။
- **Authentication**: Production deployments အတွက် authentication (e.g., API keys, OAuth) ကို implement လုပ်ပါ။
- **CORS**: Cross-Origin Resource Sharing (CORS) policies များကို configure လုပ်ပြီး access ကို ကန့်သတ်ပါ။
- **HTTPS**: Production တွင် HTTPS ကို အသုံးပြုပြီး traffic ကို encrypt လုပ်ပါ။

### အကောင်းဆုံးအလေ့အကျင့်များ

MCP streaming server တွင် လုံခြုံရေးကို implement လုပ်ရာတွင် အောက်ပါအလေ့အကျင့်များကို လိုက်နာပါ။

- Validation မရှိသော incoming requests များကို မယုံပါနှင့်။
- Access နှင့် error များအားလုံးကို log လုပ်ပြီး monitor လုပ်ပါ။
- Security vulnerabilities များကို patch လုပ်ရန် dependencies များကို regular update လုပ်ပါ။

### စိန်ခေါ်မှုများ

MCP streaming servers တွင် လုံခြုံရေးကို implement လုပ်ရာတွင် အောက်ပါ စိန်ခေါ်မှုများကို ရင်ဆိုင်ရမည်။

- Development အဆင်ပြေမှုနှင့် လုံခြုံရေးအကြား အချိုးကျမှုကို ရှာဖွေရန်
- Clients များ၏ environment များနှင့် compatibility ရှိစေရန်

### လုပ်ငန်းတာဝန်: သင့်ကိုယ်ပိုင် Streaming MCP App တည်ဆောက်ပါ

**အခြေအနေ:**
MCP server နှင့် client တစ်ခုကို တည်ဆောက်ပါ၊ server သည် items (e.g., files or documents) များကို process လုပ်ပြီး process လုပ်ပြီးသော item တစ်ခုစီအတွက် notification ပေးပါမည်။ Client သည် notification များကို real time တွင် ပြသရမည်။

**အဆင့်များ:**

1. List ကို process လုပ်ပြီး item တစ်ခုစီအတွက် notification ပေးသော server tool တစ်ခုကို implement လုပ်ပါ။
2. Real time တွင် notification များကို ပြသရန် message handler ပါရှိသော client တစ်ခုကို implement လုပ်ပါ။
3. Server နှင့် client ကို run လုပ်ပြီး notification များကို စမ်းသပ်ပါ။

[Solution](./solution/README.md)

## ထပ်မံဖတ်ရှုရန်နှင့် နောက်တစ်ဆင့်

MCP streaming နှင့် ပိုမိုအဆင့်မြင့်သော application များကို တည်ဆောက်ရန် သင်၏အသိပညာကို တိုးချဲ့ရန် အပိုင်းတွင် ထပ်မံဖတ်ရှုရန် resources များနှင့် အကြံပြုချက်များကို ပေးထားသည်။

### ထပ်မံဖတ်ရှုရန်

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### နောက်တစ်ဆင့်

- Real-time analytics, chat, သို့မဟုတ် collaborative editing အတွက် streaming ကို အသုံးပြုသော ပိုမိုအဆင့်မြင့်သော MCP tools များကို တည်ဆောက်ရန် ကြိုးစားပါ။
- Live UI updates အတွက် MCP streaming ကို frontend frameworks (React, Vue, စသည်) နှင့် ပေါင်းစပ်ရန် စမ်းသပ်ပါ။
- နောက်တစ်ဆင့်: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတရ အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူက ဘာသာပြန်မှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။