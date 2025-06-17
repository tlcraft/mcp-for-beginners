<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:33:23+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "my"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

ဤအခန်းတွင် HTTPS ကိုအသုံးပြု၍ Model Context Protocol (MCP) ဖြင့် လုံခြုံပြီး၊ တိုးချဲ့နိုင်ပြီး၊ အချိန်နှင့်တပြေးညီ သွားလာနိုင်သော streaming ကို အကောင်အထည်ဖော်နည်းကို လမ်းညွှန်ပြထားသည်။ Streaming ကိုအသုံးပြုရန် ရည်ရွယ်ချက်၊ ရရှိနိုင်သော သယ်ယူပို့ဆောင်မှုနည်းလမ်းများ၊ MCP တွင် streamable HTTP ကို မည်သို့ အကောင်အထည်ဖော်မည်၊ လုံခြုံရေးဆိုင်ရာ အကောင်းဆုံး လေ့လာချက်များ၊ SSE မှ မိုက်ဂရိတ်လုပ်ခြင်း၊ သင်၏ကိုယ်ပိုင် streaming MCP အက်ပလီကေးရှင်းများ ဖန်တီးရန် လက်တွေ့ လမ်းညွှန်ချက်များ ပါဝင်သည်။

## Transport Mechanisms and Streaming in MCP

ဤအပိုင်းတွင် MCP တွင် ရရှိနိုင်သည့် သယ်ယူပို့ဆောင်မှုနည်းလမ်းများကို ရှာဖွေပြီး၊ client နှင့် server များအကြား အချိန်နှင့်တပြေးညီ ဆက်သွယ်မှုအတွက် streaming အင်အားများ ဖန်တီးပေးသည့် အခန်းကဏ္ဍကို ရှင်းပြသည်။

### သယ်ယူပို့ဆောင်မှုနည်းလမ်း란?

သယ်ယူပို့ဆောင်မှုနည်းလမ်းဆိုသည်မှာ client နှင့် server အကြား ဒေတာကို မည်သို့ လဲလှယ်ပေးမည်ကို သတ်မှတ်သည်။ MCP သည် ပတ်ဝန်းကျင်နှင့် လိုအပ်ချက်များအလိုက် မတူညီသည့် သယ်ယူပို့ဆောင်မှုအမျိုးအစားများကို ထောက်ခံသည်-

- **stdio**: အခြေခံ input/output ဖြစ်ပြီး ဒေသတွင်း CLI ကိရိယာများအတွက် သင့်တော်သည်။ ရိုးရှင်းသော်လည်း web သို့မဟုတ် cloud အတွက် မသင့်တော်ပါ။
- **SSE (Server-Sent Events)**: server မှ client သို့ HTTP ဖြင့် အချိန်နှင့်တပြေးညီ update များ ပို့နိုင်သည်။ web UI များအတွက် ကောင်းမွန်သော်လည်း တိုးချဲ့နိုင်မှုနှင့် လွယ်ကူမှုတွင် ကန့်သတ်ချက်ရှိသည်။
- **Streamable HTTP**: ခေတ်မီ HTTP အခြေခံ streaming သယ်ယူပို့ဆောင်မှုဖြစ်ပြီး အသိပေးချက်များနှင့် တိုးချဲ့နိုင်မှု ကောင်းမွန်သည်။ ထုတ်လုပ်မှုနှင့် cloud ပတ်ဝန်းကျင်များအတွက် အကြံပြုသည်။

### နှိုင်းယှဉ်ဇယား

အောက်ပါ ဇယားတွင် သယ်ယူပို့ဆောင်မှုနည်းလမ်းများအကြား ကွာခြားချက်များကို ကြည့်ရှုနိုင်သည်-

| သယ်ယူပို့ဆောင်မှု | အချိန်နှင့်တပြေးညီ Update များ | Streaming | တိုးချဲ့နိုင်မှု | အသုံးပြုမှုကိစ္စ           |
|-------------------|-------------------------------|-----------|----------------|----------------------------|
| stdio             | မဟုတ်ပါ                      | မဟုတ်ပါ  | နည်းပါးသည်   | ဒေသတွင်း CLI ကိရိယာများ  |
| SSE               | ဟုတ်သည်                      | ဟုတ်သည်  | အလယ်အလတ်      | Web, အချိန်နှင့်တပြေးညီ Update များ |
| Streamable HTTP    | ဟုတ်သည်                      | ဟုတ်သည်  | မြင့်မားသည်    | Cloud, multi-client        |

> **Tip:** သင့်တော်သော သယ်ယူပို့ဆောင်မှုကို ရွေးချယ်ခြင်းသည် စွမ်းဆောင်ရည်၊ တိုးချဲ့နိုင်မှုနှင့် အသုံးပြုသူအတွေ့အကြုံကို ထိခိုက်စေသည်။ **Streamable HTTP** ကို ခေတ်မီ၊ တိုးချဲ့နိုင်ပြီး cloud အဆင်သင့် အက်ပလီကေးရှင်းများအတွက် အကြံပြုသည်။

ယခင်အခန်းများတွင် ပြသခဲ့သည့် stdio နှင့် SSE သယ်ယူပို့ဆောင်မှုများနှင့် ယခုအခန်းတွင် ဖော်ပြထားသည့် streamable HTTP သယ်ယူပို့ဆောင်မှုကို သတိပြုကြည့်ပါ။

## Streaming: အကြောင်းအရာနှင့် ရည်ရွယ်ချက်

Streaming ၏ အခြေခံအယူအဆများနှင့် ရည်ရွယ်ချက်များကို နားလည်ခြင်းသည် အချိန်နှင့်တပြေးညီ ဆက်သွယ်မှုစနစ်များကို ထိရောက်စွာ တည်ဆောက်ရာတွင် အရေးကြီးသည်။

**Streaming** ဆိုသည်မှာ network programming တွင် ဒေတာကို တစ်ပြိုင်နက်တည်း ပြီးစီးရန် မစောင့်ဘဲ၊ အစိတ်အပိုင်းများ သို့မဟုတ် ဖြစ်ရပ်များစဉ်လိုက် အဖြစ် ပို့ဆောင်နိုင်သည့် နည်းလမ်းဖြစ်သည်။ ၎င်းသည် အထူးသဖြင့်-

- ဖိုင်ကြီးများ သို့မဟုတ် ဒေတာစုစည်းမှုများ။
- အချိန်နှင့်တပြေးညီ update များ (ဥပမာ၊ စကားပြော, progress bar များ)။
- အချိန်ကြာရှည် တာဝန်များတွင် အသုံးပြုသူအား အဆက်မပြတ် သတင်းပေးရန်။

Streaming ၏ အထွေထွေ သိထားသင့်သော အချက်များ-

- ဒေတာကို တဖြည်းဖြည်း ပေးပို့သည်၊ တပြိုင်နက်တည်း မပေးပို့ပါ။
- Client သည် ရောက်ရှိလာသည့် ဒေတာကို ချက်ချင်း လုပ်ဆောင်နိုင်သည်။
- လျင်မြန်မှုခံစားမှု လျော့နည်းကာ အသုံးပြုသူအတွေ့အကြုံ တိုးတက်စေသည်။

### Streaming ကို မည်သို့အသုံးပြုသင့်သနည်း?

Streaming ကို အသုံးပြုရခြင်း၏ အကြောင်းအရင်းများမှာ-

- အသုံးပြုသူများ သတင်းအချက်အလက်ကို ချက်ချင်း ရရှိနိုင်သည်၊ နောက်ဆုံးတွင်သာ မဟုတ်ပါ။
- အချိန်နှင့်တပြေးညီ အက်ပလီကေးရှင်းများနှင့် တုံ့ပြန်မှုရှိသော UI များ ဖန်တီးနိုင်သည်။
- ကွန်ယက်နှင့် ကွန်ပျူတာစွမ်းအားကို ပိုမို ထိရောက်စွာ အသုံးပြုနိုင်သည်။

### ရိုးရှင်းသော ဥပမာ: HTTP Streaming Server & Client

Streaming ကို မည်သို့ အကောင်အထည်ဖော်နိုင်သည်ဆိုသော ရိုးရှင်းသော ဥပမာ-

<details>
<summary>Python</summary>

**Server (Python, FastAPI နှင့် StreamingResponse အသုံးပြု):**
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

**Client (Python, requests အသုံးပြု):**
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

ဤဥပမာတွင် server သည် မက်ဆေ့ချ်များအားလုံး ပြီးစီးရန် မစောင့်ဘဲ အသစ်ရရှိသည့် မက်ဆေ့ချ်တစ်ခုချင်း ပို့ပေးသည်။

**လုပ်ဆောင်ပုံ:**
- Server သည် မက်ဆေ့ချ်တစ်ခုချင်း အသင့်ရှိသလို ပေးပို့သည်။
- Client သည် ရောက်ရှိလာသည့် အစိတ်အပိုင်းကို လက်ခံ၍ မျက်နှာပြင်တွင် ပြသသည်။

**လိုအပ်ချက်များ:**
- Server သည် streaming response (ဥပမာ၊ `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) ကို အသုံးပြုရမည်။
- **ရိုးရှင်းသော streaming လိုအပ်ချက်များအတွက်:** ရိုးရှင်းသော HTTP streaming ကို အသုံးပြုခြင်း ပိုလွယ်ကူပြီး လုံလောက်သည်။
- **ရှုပ်ထွေးပြီး အပြန်အလှန် တုံ့ပြန်မှုရှိသော အက်ပလီကေးရှင်းများအတွက်:** MCP streaming သည် အသေးစိတ် metadata များနှင့် အသိပေးချက်များ၊ နောက်ဆုံးရလဒ်များကို ခွဲခြားပေးသည့် ပိုမိုစနစ်တကျသော နည်းလမ်းဖြစ်သည်။
- **AI အက်ပလီကေးရှင်းများအတွက်:** MCP ၏ အသိပေးစနစ်သည် ရှည်လျားသော AI လုပ်ငန်းများတွင် အသုံးပြုသူအား တိုးတက်မှုအခြေအနေများကို သိရှိနိုင်စေရန် အထူးအသုံးဝင်သည်။

## MCP တွင် Streaming

ယခုအထိ ရိုးရာ streaming နှင့် MCP streaming တို့၏ ကွာခြားချက်များကို ကြည့်ရှုခဲ့ပြီးဖြစ်သည်။ MCP တွင် streaming ကို မည်သို့အသုံးချရမည်ကို အသေးစိတ် ဖော်ပြမည်။

MCP ဖရိမ်းဝတ်အတွင်း streaming ၏ လုပ်ဆောင်ပုံကို နားလည်ခြင်းသည် ရှည်လျားသော လုပ်ငန်းစဉ်များတွင် အသုံးပြုသူအား အချိန်နှင့်တပြေးညီ တုံ့ပြန်ချက် ပေးနိုင်သော အက်ပလီကေးရှင်းများ ဖန်တီးရာတွင် အရေးကြီးသည်။

MCP တွင် streaming ဆိုသည်မှာ မူလတုံ့ပြန်ချက်ကို အစိတ်အပိုင်းဖြင့် ပို့ခြင်းမဟုတ်ပဲ၊ ကိရိယာတစ်ခုသည် တောင်းဆိုမှုကို လုပ်ဆောင်နေစဉ်တွင် client သို့ **အသိပေးချက်များ** ပို့ခြင်းဖြစ်သည်။ ၎င်းအသိပေးချက်များတွင် တိုးတက်မှု အချက်အလက်များ၊ မှတ်တမ်းများ သို့မဟုတ် အခြားဖြစ်ရပ်များ ပါဝင်နိုင်သည်။

### လုပ်ဆောင်ပုံ

မူလရလဒ်ကို တစ်ခုတည်းသော တုံ့ပြန်ချက်အဖြစ် ပေးပို့သည်။ သို့သော် တိုးတက်မှု အသိပေးချက်များကို လုပ်ငန်းစဉ်အတွင်း သီးခြား မက်ဆေ့ချ်များအဖြစ် ပို့နိုင်ပြီး client ကို အချိန်နှင့်တပြေးညီ update ပေးနိုင်သည်။ Client သည် ဤအသိပေးချက်များကို ကိုင်တွယ် ပြသနိုင်ရမည်။

## အသိပေးချက်ဆိုတာဘာလဲ?

"အသိပေးချက်" ဟု ဆိုလိုသည်မှာ MCP အတွင်း ဘာကို ဆိုလိုသနည်း?

အသိပေးချက်ဆိုသည်မှာ server မှ client သို့ ရှည်လျားသော လုပ်ငန်းစဉ်တစ်ခုအတွင်း တိုးတက်မှု၊ အခြေအနေ သို့မဟုတ် အခြားဖြစ်ရပ်များအကြောင်း သတင်းပို့သည့် မက်ဆေ့ချ်ဖြစ်သည်။ အသိပေးချက်များက တိကျမှန်ကန်မှုနှင့် အသုံးပြုသူအတွေ့အကြုံ တိုးတက်စေသည်။

ဥပမာအားဖြင့် client သည် server နှင့် ပထမဆုံး handshake ပြီးဆုံးသည့်အခါ အသိပေးချက် တစ်ခု ပို့ရန် ရှိသည်။

အသိပေးချက်သည် JSON မက်ဆေ့ချ်အဖြစ် အောက်ပါပုံစံရှိသည်-

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

အသိပေးချက်များသည် MCP ၏ ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) ဟူသော topic နှင့် ဆက်စပ်သည်။

logging ကို အလုပ်လုပ်စေရန် server သည် အောက်ပါအတိုင်း feature/capability အဖြစ် ဖွင့်ထားရမည်-

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> အသုံးပြုသော SDK အလိုက် logging ကို ပုံမှန်အားဖြင့် ဖွင့်ထားနိုင်သော်လည်း server configuration တွင် တိတိကျကျ ဖွင့်ရန် လိုအပ်နိုင်သည်။

အသိပေးချက်အမျိုးအစားများမှာ-

| အဆင့်      | ဖော်ပြချက်                      | ဥပမာ အသုံးပြုမှု                |
|------------|-------------------------------|---------------------------------|
| debug      | အသေးစိတ် debug အချက်အလက်များ   | function ဝင်/ထွက် နေရာများ     |
| info       | အထွေထွေ သတင်းအချက်အလက်များ | လုပ်ငန်းတိုးတက်မှု update များ  |
| notice     | ပုံမှန် သို့သော် အရေးကြီးဖြစ်ရပ်များ | configuration ပြောင်းလဲမှုများ   |
| warning    | သတိပေး အခြေအနေများ           | အသုံးမပြုသင့်သော feature များ  |
| error      | အမှားအခြေအနေများ              | လုပ်ငန်းပျက်ကွက်မှုများ         |
| critical   | အရေးပေါ် အခြေအနေများ          | စနစ်အစိတ်အပိုင်းပျက်စီးမှုများ  |
| alert      | ချက်ချင်း လုပ်ဆောင်ရမည့်အခြေအနေ | ဒေတာပျက်စီးမှုတွေ့ရှိခြင်း     |
| emergency  | စနစ်အသုံးမပြုနိုင်သောအခြေအနေ | စနစ်အပြည့်အဝ ပျက်စီးမှု         |

## MCP တွင် အသိပေးချက်များ အကောင်အထည်ဖော်ခြင်း

MCP တွင် အသိပေးချက်များ အကောင်အထည်ဖော်ရန် server နှင့် client နှစ်ဖက်လုံးတွင် အချိန်နှင့်တပြေးညီ update များကို ကိုင်တွယ်နိုင်ရန် ပြင်ဆင်ရမည်။ ၎င်းက သင့်အက်ပလီကေးရှင်းအား ရှည်လျားသော လုပ်ငန်းများတွင် အသုံးပြုသူအား ချက်ချင်း တုံ့ပြန်ချက်ပေးနိုင်စေသည်။

### Server ဘက်: အသိပေးချက် ပို့ခြင်း

Server ဘက်မှစလိုက်ပါ။ MCP တွင် tool များကို တောင်းဆိုမှုများကို လုပ်ဆောင်စဉ် အသိပေးချက်များ ပို့နိုင်ရန် သတ်မှတ်သည်။ Server သည် context object (ပုံမှန်အားဖြင့် `ctx`) ကို အသုံးပြု၍ client သို့ မက်ဆေ့ချ်များ ပို့သည်။

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

ဥပမာတွင် `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` သယ်ယူပို့ဆောင်မှုကို အသုံးပြုသည်-

```python
mcp.run(transport="streamable-http")
```

</details>

### Client ဘက်: အသိပေးချက် လက်ခံခြင်း

Client သည် အသိပေးချက်များ လက်ခံ၍ ပြသနိုင်ရန် message handler ကို အကောင်အထည်ဖော်ရမည်။

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

အထက်ပါ ကုဒ်တွင် `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` ကို အသုံးပြုပြီး client သည် အသိပေးချက်များကို ကိုင်တွယ်သည်။

## တိုးတက်မှု အသိပေးချက်များနှင့် သုံးစွဲမှုအခြေအနေများ

ဤအပိုင်းတွင် MCP တွင် တိုးတက်မှု အသိပေးချက်များ၏ အဓိပ္ပါယ်၊ အရေးကြီးမှုနှင့် Streamable HTTP ဖြင့် မည်သို့ အကောင်အထည်ဖော်မည်ကို ရှင်းပြသည်။ သင်၏ နားလည်မှုကို အတည်ပြုရန် လက်တွေ့ လေ့ကျင့်ခန်းလည်း ပါဝင်သည်။

တိုးတက်မှု အသိပေးချက်များသည် ရှည်လျားသော လုပ်ငန်းစဉ်များအတွင်း server မှ client သို့ အချိန်နှင့်တပြေးညီ ပို့သော မက်ဆေ့ချ်များဖြစ်သည်။ လုပ်ငန်းစဉ် ပြီးဆုံးရန် မစောင့်ဘဲ လက်ရှိအခြေအနေကို client သို့ အသိပေးခြင်းဖြင့် တိကျမှန်ကန်မှု၊ အသုံးပြုသူအတွေ့အကြုံ တိုးတက်စေပြီး debugging ကိုလည်း လွယ်ကူစေသည်။

**ဥပမာ:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### တိုးတက်မှု အသိပေးချက်များကို မည်သို့အသုံးပြုသနည်း?

တိုးတက်မှု အသိပေးချက်များ အရေးကြီးသော အချက်များမှာ-

- **အသုံးပြုသူအတွေ့အကြုံ ကောင်းမွန်စေခြင်း:** လုပ်ငန်းတိုးတက်မှုကို အချိန်နှင့်တပြေးညီ မြင်တွေ့နိုင်သည်။
- **အချိန်နှင့်တပြေးညီ တုံ့ပြန်ချက်:** Client များ progress bar သို့မဟုတ် မှတ်တမ်းများ ပြသနိုင်ပြီး အက်ပလီကေးရှင်း တုံ့ပြန်မှုရှိစေသည်။
- **debugging နှင့် စောင့်ကြည့်မှု လွယ်ကူစေခြင်း:** developer များနှင့် အသုံးပြုသူများ လုပ်ငန်းတစ်ခုမှာ ဘယ်နေရာမှာ နှေးကွေးသလဲ သို့မဟုတ် ရပ်တန့်သွ

**ကန့်သတ်ချက်**  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှုဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးပမ်းဆောင်ရွက်ထားသော်လည်း၊ စက်မှုဘာသာပြန်ခြင်းအတွက် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ရှိနိုင်ကြောင်း သတိပြုပါရန် လိုအပ်ပါသည်။ မူလစာရွက်စာတမ်းကို မူရင်းဘာသာဖြင့်သာ အတည်ပြုရမည့်အချက်အလက်အဖြစ် ထည့်သွင်းစဉ်းစားသင့်ပါသည်။ အရေးကြီးသောအချက်အလက်များအတွက် သင့်တော်သော လူ့ဘာသာပြန်ပညာရှင်၏ ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။