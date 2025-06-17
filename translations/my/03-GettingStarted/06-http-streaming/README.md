<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-17T16:42:01+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "my"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

ဤအခန်းတွင် Model Context Protocol (MCP) ကို အသုံးပြုပြီး HTTPS ဖြင့် လုံခြုံပြီး၊ တိုးချဲ့နိုင်ပြီး၊ အချိန်နှင့်တပြေးညီ စီးဆင်းမှု (streaming) ကို အကောင်အထည်ဖော်နည်းများကို လုံးလုံးလေးလေး ရှင်းပြထားသည်။ Streaming ရဲ့ အဓိကရည်ရွယ်ချက်၊ ရရှိနိုင်သော ပို့ဆောင်မှုနည်းလမ်းများ၊ MCP တွင် streamable HTTP ကို အကောင်အထည်ဖော်နည်း၊ လုံခြုံရေးအကောင်းဆုံး လေ့လာချက်များ၊ SSE မှ ပြောင်းရွှေ့ခြင်းနဲ့ ကိုယ်ပိုင် streaming MCP အက်ပလီကေးရှင်းများ တည်ဆောက်နည်း လမ်းညွှန်ချက်များ ပါဝင်သည်။

## MCP မှာ ပို့ဆောင်မှုနည်းလမ်းများနဲ့ Streaming

ဤအပိုင်းတွင် MCP မှာ ရရှိနိုင်သော ပို့ဆောင်မှုနည်းလမ်းများနှင့် ၎င်းတို့၏ တာဝန်၊ အချိန်နှင့်တပြေးညီ ဆက်သွယ်မှုအတွက် Streaming ကို အကောင်အထည်ဖော်ရာတွင် ဘယ်လို အရေးပါကြောင်း ရှင်းပြထားသည်။

### ပို့ဆောင်မှုနည်းလမ်း ဆိုတာ ဘာလဲ?

ပို့ဆောင်မှုနည်းလမ်း ဆိုသည်မှာ client နဲ့ server ကြား ဒေတာများကို ဘယ်လို လဲလှယ်ပေးမလဲ ဆိုတာ သတ်မှတ်ပေးသည်။ MCP သည် ပတ်ဝန်းကျင်နှင့် လိုအပ်ချက်အမျိုးမျိုးအတွက် သင့်တော်သော ပို့ဆောင်မှုအမျိုးအစားများစွာကို ထောက်ပံ့သည်-

- **stdio**: စံနမူနာ input/output ဖြစ်ပြီး ဒေသတွင်းနှင့် CLI အခြေပြု tools များအတွက် သင့်တော်သည်။ ရိုးရှင်းသော်လည်း web သို့မဟုတ် cloud အတွက် မသင့်တော်ပါ။
- **SSE (Server-Sent Events)**: server မှ client များဆီသို့ HTTP ဖြင့် အချိန်နှင့်တပြေးညီ အပ်ဒိတ်များ ပို့နိုင်သည်။ web UI များအတွက် ကောင်းမွန်သော်လည်း တိုးချဲ့နိုင်မှုနည်းပြီး ပေါ်လစီကန့်သတ်ချက်များ ရှိသည်။
- **Streamable HTTP**: ခေတ်မီ HTTP အခြေပြု streaming ပို့ဆောင်မှုဖြစ်ပြီး အသိပေးချက်များနှင့် ပိုမိုတိုးချဲ့နိုင်မှုများကို ထောက်ပံ့သည်။ ထုတ်လုပ်မှုနှင့် cloud ပတ်ဝန်းကျင်များအတွက် အကြံပြုသည်။

### နှိုင်းယှဉ်ဇယား

ဤဇယားတွင် ပို့ဆောင်မှုနည်းလမ်းအမျိုးအစားများ၏ ကွာခြားချက်များကို ကြည့်ရှုနိုင်သည်-

| ပို့ဆောင်မှု         | အချိန်နှင့်တပြေးညီ အပ်ဒိတ်များ | Streaming | တိုးချဲ့နိုင်မှု | အသုံးပြုမှုအမျိုးအစား      |
|---------------------|------------------------------|-----------|---------------|-----------------------------|
| stdio               | မရှိ                         | မရှိ      | နည်း          | ဒေသတွင်း CLI tools များ    |
| SSE                 | ရှိ                          | ရှိ       | အလယ်အလတ်    | Web, အချိန်နှင့်တပြေးညီ အပ်ဒိတ်များ |
| Streamable HTTP     | ရှိ                          | ရှိ       | မြင့်မား      | Cloud, multi-client          |

> **Tip:** သင့်တော်သော ပို့ဆောင်မှုကို ရွေးချယ်ခြင်းသည် စွမ်းဆောင်ရည်၊ တိုးချဲ့နိုင်မှုနဲ့ အသုံးပြုသူ အတွေ့အကြုံကို သက်ရောက်စေသည်။ **Streamable HTTP** ကို ခေတ်မီ၊ တိုးချဲ့နိုင်ပြီး cloud သင့်တော်သော အက်ပလီကေးရှင်းများအတွက် အကြံပြုပါသည်။

ယခင်အခန်းများတွင် ပြသခဲ့သော stdio နဲ့ SSE ပို့ဆောင်မှုများကို မှတ်သားပြီး ဤအခန်းတွင် အဓိကဖော်ပြထားသော Streamable HTTP ကို သတိပြုပါ။

## Streaming: အကြောင်းအရာနှင့် ရည်ရွယ်ချက်

Streaming ၏ အခြေခံသဘောတရားများနှင့် ရည်ရွယ်ချက်များကို နားလည်ခြင်းသည် အကျိုးရှိသော အချိန်နှင့်တပြေးညီ ဆက်သွယ်မှုစနစ်များ တည်ဆောက်ရာတွင် အရေးကြီးသည်။

**Streaming** သည် network programming တွင် ဒေတာကို တစ်ပြိုင်နက်လုံး စောင့်ဆိုင်းခြင်းမပြုဘဲ၊ အစိတ်အပိုင်းသေးသေးလေးများ သို့မဟုတ် ဖြစ်ရပ်စဉ်လိုက် စီးဆင်းပေးနိုင်သော နည်းပညာဖြစ်သည်။ ၎င်းသည် အထူးသဖြင့် -

- ဖိုင်အရွယ်အစားကြီးများ သို့မဟုတ် ဒေတာစုစည်းမှုများ။
- အချိန်နှင့်တပြေးညီ အပ်ဒိတ်များ (ဥပမာ - စကားပြော, တိုးတက်မှုအတန်းများ)။
- သုံးစွဲသူကို အဆက်မပြတ် သတင်းပေးလိုသော ကြာရှည်ဆောင်ရွက်မှုများ။

Streaming အကြောင်းအရာအခြေခံ -

- ဒေတာကို တဖြည်းဖြည်းပေးပို့သည်၊ တပြိုင်နက်လုံး မပေးပို့ပါ။
- client သည် လက်ခံရရှိသည့် ဒေတာကို ချက်ချင်း ဆောင်ရွက်နိုင်သည်။
- စောင့်ဆိုင်းချိန်ခံစားမှုကို လျော့နည်းစေပြီး အသုံးပြုသူအတွေ့အကြုံကို တိုးတက်စေသည်။

### Streaming ကို ဘာကြောင့် သုံးသလဲ?

Streaming သုံးစွဲရခြင်း၏ အကြောင်းအရင်းများမှာ-

- အသုံးပြုသူများ အလုပ်စတင်သည်နှင့် တပြိုင်နက် feedback ရရှိနိုင်သည်။
- အချိန်နှင့်တပြေးညီ အက်ပလီကေးရှင်းများနှင့် ပြန်ကြားမှုမြန်သော UI များ ဖန်တီးနိုင်သည်။
- နက်ဝပ်နှင့် ကွန်ပျူတာ စွမ်းအားများကို ပိုမိုထိရောက်စွာ အသုံးပြုနိုင်သည်။

### ရိုးရှင်းသော ဥပမာ - HTTP Streaming Server နှင့် Client

Streaming ကို မည်သို့ အကောင်အထည်ဖော်နိုင်သည်ကို ရိုးရှင်းသော ဥပမာ-

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

ဤဥပမာတွင် server သည် မက်ဆေ့ချ်များအားလုံး ပြင်ဆင်ပြီး စောင့်ဆိုင်းခြင်းမပြုဘဲ၊ အဆင့်ဆင့် client သို့ ပေးပို့သည်။

**အလုပ်လုပ်ပုံ:**
- server သည် မက်ဆေ့ချ် တစ်ခုချင်းစီ ပြင်ဆင်ပြီး ရရှိသလို ပေးပို့သည်။
- client သည် လက်ခံရရှိသည့် အစိတ်အပိုင်းများကို ချက်ချင်း ပုံနှိပ်ပြသည်။

**လိုအပ်ချက်များ:**
- server သည် streaming response ကို အသုံးပြုရမည် (ဥပမာ - `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) နှင့် MCP မှာ streaming ရွေးချယ်ခြင်း။

- **ရိုးရှင်းသော streaming လိုအပ်ချက်များအတွက်:** ရိုးရှင်းသော HTTP streaming သည် လွယ်ကူပြီး အခြေခံ streaming လိုအပ်ချက်များအတွက် လုံလောက်သည်။

- **ရှုပ်ထွေးပြီး အပြန်အလှန်ဆက်သွယ်မှု လိုအပ်သော အက်ပလီကေးရှင်းများအတွက်:** MCP streaming သည် သတင်းအချက်အလက်များ ပိုမိုစနစ်တကျ ဖော်ပြပေးပြီး အသိပေးချက်များနှင့် နောက်ဆုံးရလဒ်များကို ခွဲခြားပေးသည်။

- **AI အက်ပလီကေးရှင်းများအတွက်:** MCP ၏ အသိပေးစနစ်သည် ကြာရှည်ဆောင်ရွက်မှု AI လုပ်ငန်းများတွင် အသုံးပြုသူများအား တိုးတက်မှုအခြေအနေကို အဆက်မပြတ် သတင်းပေးရန် အထူးအသုံးဝင်သည်။

## MCP တွင် Streaming

အခုထိ classical streaming နဲ့ MCP streaming ကြား ကွာခြားချက်များကို ကြည့်ရှုပြီးသားဖြစ်သည်။ ယခု MCP တွင် streaming ကို မည်သို့ အသုံးချနိုင်သည်ကို အသေးစိတ် ရှင်းပြမည်။

MCP framework အတွင်း streaming ၏ အလုပ်လုပ်ပုံကို နားလည်ခြင်းသည် ကြာရှည်ဆောင်ရွက်မှုများတွင် အသုံးပြုသူများအား အချိန်နှင့်တပြေးညီ feedback ပေးနိုင်သော responsive အက်ပလီကေးရှင်းများ ဖန်တီးရာတွင် အရေးကြီးသည်။

MCP တွင် streaming ဆိုသည်မှာ မူလ တုံ့ပြန်ချက်ကို အစိတ်အပိုင်းများဖြင့် ပို့ခြင်း မဟုတ်ဘဲ၊ ကိရိယာတစ်ခုက တောင်းဆိုမှုကို ဆောင်ရွက်နေစဉ် client ဆီသို့ **အသိပေးချက်များ (notifications)** ပေးပို့ခြင်းဖြစ်သည်။ ဤအသိပေးချက်များတွင် တိုးတက်မှုအခြေအနေများ၊ မှတ်တမ်းများ သို့မဟုတ် အခြား ဖြစ်ရပ်များ ပါဝင်နိုင်သည်။

### အလုပ်လုပ်ပုံ

မူလရလဒ်ကို တစ်ခုတည်းသော တုံ့ပြန်ချက်အဖြစ် ပေးပို့သည်။ သို့သော် ဆောင်ရွက်နေစဉ် အသိပေးချက်များကို သီးခြားမက်ဆေ့ချ်များအဖြစ် ပို့၍ client ကို အချိန်နှင့်တပြေးညီ အပ်ဒိတ်ပေးနိုင်သည်။ client သည် ဤအသိပေးချက်များကို လက်ခံပြီး ပြသနိုင်ရမည်။

## အသိပေးချက် (Notification) ဆိုတာ ဘာလဲ?

“Notification” ဟု ပြောလိုက်သည်မှာ MCP အတွင်း ဘာကို ဆိုလိုသနည်း?

အသိပေးချက် ဆိုသည်မှာ ကြာရှည်ဆောင်ရွက်မှုအတွင်း server မှ client သို့ တိုးတက်မှု၊ အခြေအနေ သို့မဟုတ် အခြား ဖြစ်ရပ်များကို သတင်းပေးရန် ပို့သော မက်ဆေ့ချ်ဖြစ်သည်။ အသိပေးချက်များသည် ဖော်ပြချက်တိုးတက်မှုနှင့် အသုံးပြုသူအတွေ့အကြုံ တိုးတက်စေသည်။

ဥပမာအားဖြင့် client သည် server နှင့် မူလ လက်မှတ်လက်ခံမှု ပြီးဆုံးသည့်အခါ အသိပေးချက် တစ်ခု ပို့ရမည်။

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

အသိပေးချက်များသည် MCP တွင် ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) ဟူသော topic တစ်ခုတွင် ပါဝင်သည်။

Logging ကို အသုံးပြုရန် server တွင် အောက်ပါအတိုင်း အင်္ဂါရပ်/စွမ်းရည် အဖြစ် ဖွင့်ရမည်-

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> အသုံးပြုသော SDK အပေါ် မူတည်၍ logging ကို ပုံမှန်အားဖြင့် ဖွင့်ထားနိုင်သော်လည်း၊ server configuration တွင် ထပ်မံ ဖွင့်ရန် လိုအပ်နိုင်သည်။

အသိပေးချက် အမျိုးအစားများမှာ-

| အဆင့်       | ဖော်ပြချက်                      | အသုံးပြုမှု ဥပမာ             |
|-------------|-------------------------------|------------------------------|
| debug       | အသေးစိတ် debugging အချက်အလက်များ | function ၀င်/ထွက် အစိတ်အပိုင်းများ |
| info        | အထွေထွေ သတင်းအချက်အလက်များ  | လုပ်ငန်းတိုးတက်မှု အပ်ဒိတ်များ    |
| notice      | သာမန်ဖြစ်သော်လည်း အရေးကြီးသော ဖြစ်ရပ်များ | ပြင်ဆင်မှု ပြောင်းလဲမှုများ       |
| warning     | သတိပေး အခြေအနေများ            | ရှုံးနိမ့်သွားသော feature အသုံးပြုမှု |
| error       | အမှားအခြေအနေများ              | လုပ်ငန်း မအောင်မြင်မှုများ       |
| critical    | အရေးပေါ် အခြေအနေများ           | စနစ်ပစ္စည်း မအောင်မြင်မှုများ   |
| alert       | ချက်ချင်း လုပ်ဆောင်ရမည့် အရေးပေါ် အခြေအနေ | ဒေတာ ပျက်စီးမှု တွေ့ရှိမှု       |
| emergency   | စနစ်အသုံးမပြုနိုင်သော အခြေအနေ | စနစ် လုံးဝ ပျက်စီးမှု           |

## MCP တွင် အသိပေးချက်များ အကောင်အထည်ဖော်ခြင်း

MCP တွင် အသိပေးချက်များကို အကောင်အထည်ဖော်ရန် server နှင့် client နှစ်ဖက်စလုံးကို အချိန်နှင့်တပြေးညီ အပ်ဒိတ်များကို ကိုင်တွယ်နိုင်ရန် စီစဉ်ရမည်ဖြစ်သည်။ ၎င်းဖြင့် ကြာရှည်ဆောင်ရွက်မှုများအတွင်း အသုံးပြုသူများအား ချက်ချင်းတုံ့ပြန်ချက် ပေးနိုင်သည်။

### Server ဘက် - အသိပေးချက် ပို့ခြင်း

Server ဘက်ကနေ စတင်ပါစို့။ MCP တွင် tool များကို တောင်းဆိုမှုများကို ဆောင်ရွက်နေစဉ် အသိပေးချက်များ ပို့နိုင်ရန် သတ်မှတ်နိုင်သည်။ server သည် context object (ပုံမှန်အားဖြင့် `ctx`) ကို အသုံးပြု၍ client သို့ မက်ဆေ့ချ်များ ပို့သည်။

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

ဥပမာအရ `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ပို့ဆောင်မှုကို အသုံးပြုသည်-

```python
mcp.run(transport="streamable-http")
```

</details>

### Client ဘက် - အသိပေးချက် လက်ခံခြင်း

Client သည် လက်ခံရရှိသည့် အသိပေးချက်များကို ကိုင်တွယ်ပြသရန် message handler တစ်ခု အကောင်အထည်ဖော်ရမည်။

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

အထက်ပါကုဒ်တွင် `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` သုံးပြီး client သည် အသိပေးချက်များကို ကိုင်တွယ်သည်။

## တိုးတက်မှု အသိပေးချက်များနှင့် အခြေအနေများ

ဤအပိုင်းတွင် MCP ၏ တိုးတက်မှု အသိပေးချက်များ၏ အဓိပ္ပါယ်၊ အရေးပါမှုနှင့် Streamable HTTP အသုံးပြု၍ မည်သို့ အကောင်အထည်ဖော်မည်ကို ရှင်းပြသည်။ သင်ယူမှု တိုးမြှင့်ရန် လက်တွေ့ လေ့ကျင့်ခန်းလည်း ပါဝင်သည်။

တိုးတက်မှု အသိပေးချက်များသည် ကြာရှည်ဆောင်ရွက်မှုများအတွင်း server မှ client သို့ အချိန်နှင့်တပြေးညီ ပို့သော မက်ဆေ့ချ်များဖြစ်သည်။ လုပ်ငန်းတစ်ခု ပြီးဆုံးရန် စောင့်ဆိုင်းခြင်း မပြုဘဲ server သည် လက်ရှိ အခြေအနေကို client သို့ အပ်ဒိတ်ပေးသည်။ ၎င်းသည် ဖော်ပြချက်တိုးတက်မှု၊ အသုံးပြုသူ အတွေ့အကြုံ တိုးတက်စေပြီး debugging လုပ်ရန်လည်း လွယ်ကူစေသည်။

**ဥပမာ:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### တိုးတက်မှု အသိပေးချက်များကို ဘာကြောင့် သုံးသလဲ?

တိုးတက်မှု အသိပေးချက်များသည် အောက်ပါအကြောင်းများကြောင့် အရေးကြီးသည်-

- **အသုံးပြုသူအတွေ့အကြုံ ကောင်းမွန်စေခြင်း** - အလုပ်တိုးတက်သည့်အတိုင်း အပ်ဒိတ်များကို မြင်တွေ့နိုင်သည်။
- **အချိန်နှင့်တပြေးညီ တုံ့ပြန်ချက်** - client များသည် တိုးတက်မှု အတန်းများ သို့မဟုတ် မှတ်တမ်းများ ပြသနိုင်ပြီး အက်ပလီကေးရှင်းကို ပြန်ကြားမှုမြန်စေသည်။
- **Debugging နှင့် စောင့်ကြည့်မှု လွယ်ကူစေခြင်း** - developer များနှင့်

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်မှုဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားပေမယ့်၊ စက်ရုပ်ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ တရားဝင်အချက်အလက်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူသားပရော်ဖက်ရှင်နယ် ဘာသာပြန်သူများ၏ ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာသော နားလည်မှုမမှန်ခြင်းများ သို့မဟုတ် မှားယွင်းချက်များအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။