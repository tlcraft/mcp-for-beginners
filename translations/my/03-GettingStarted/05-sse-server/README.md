<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T12:48:42+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "my"
}
-->
# SSE Server

SSE (Server Sent Events) သည် server မှ client သို့ တိုက်ရိုက် streaming ပေးနိုင်ရန်အတွက် စံသတ်မှတ်ချက်ဖြစ်ပြီး၊ server များသည် HTTP မှတဆင့် client များထံ အချိန်နှင့်တပြေးညီ အချက်အလက်များကို push ပေးနိုင်သည်။ ၎င်းသည် chat application များ၊ အသိပေးချက်များ သို့မဟုတ် အချိန်နှင့်တပြေးညီ ဒေတာများလိုအပ်သော application များအတွက် အထူးအသုံးဝင်သည်။ ထို့အပြင် သင့် server ကို cloud တစ်ခုတွင် တည်ရှိသော server တစ်ခုအဖြစ် တစ်ချိန်တည်းတွင် client များစွာ အသုံးပြုနိုင်သည်။

## အနှစ်ချုပ်

ဤသင်ခန်းစာတွင် SSE Server များကို ဘယ်လို တည်ဆောက်ပြီး အသုံးပြုရမည်ကို ဖော်ပြထားသည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးသတ်သည်အထိ သင်သည် အောက်ပါအရာများကို လုပ်ဆောင်နိုင်မည်ဖြစ်သည်-

- SSE Server တည်ဆောက်နိုင်မည်။
- Inspector ကို အသုံးပြု၍ SSE Server ကို debug လုပ်နိုင်မည်။
- Visual Studio Code ဖြင့် SSE Server ကို အသုံးပြုနိုင်မည်။

## SSE, ၎င်း၏ လုပ်ဆောင်ပုံ

SSE သည် ပံ့ပိုးထားသော သယ်ယူပို့ဆောင်မှုအမျိုးအစား နှစ်မျိုးထဲမှ တစ်ခုဖြစ်သည်။ သင်သည် ယခင်သင်ခန်းစာများတွင် stdio ကို အသုံးပြုထားကြောင်း မြင်တွေ့ပြီးဖြစ်သည်။ ကွာခြားချက်မှာ-

- SSE သည် connection နှင့် message များကို ကိုင်တွယ်ရမည်။
- ၎င်းသည် မည်သည့်နေရာတွင်မဆို တည်ရှိနိုင်သော server ဖြစ်သောကြောင့် Inspector နှင့် Visual Studio Code ကဲ့သို့သော ကိရိယာများနှင့် လုပ်ဆောင်ရာတွင် ထိုအချက်ကို ထည့်သွင်းစဉ်းစားရမည်။ ၎င်း၏ အဓိပ္ပါယ်မှာ server ကို စတင်ရန် မပြောပဲ connection တည်ဆောက်နိုင်မည့် endpoint ကို ပြသရမည်ဖြစ်သည်။ အောက်တွင် ဥပမာကုဒ်ကို ကြည့်ပါ-

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

အထက်ပါကုဒ်တွင်-

- `/sse` သည် route အဖြစ် သတ်မှတ်ထားသည်။ ဤ route သို့ request တစ်ခု လာရောက်သည်နှင့် transport instance အသစ်တစ်ခု ဖန်တီးပြီး server သည် transport ကို အသုံးပြု၍ *connect* လုပ်သည်။
- `/messages` သည် လာရောက်သော message များကို ကိုင်တွယ်သော route ဖြစ်သည်။

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

အထက်ပါကုဒ်တွင်-

- ASGI server instance တစ်ခု (Starlette ကို အသုံးပြု၍) ဖန်တီးပြီး default route `/` ကို mount လုပ်သည်။

  နောက်ခံတွင် `/sse` နှင့် `/messages` routes များကို connection နှင့် message များကို ကိုင်တွယ်ရန် သတ်မှတ်ထားသည်။ stdio server များကဲ့သို့ အခြား features များကို ထည့်သွင်းခြင်းဖြင့် app ကို တိုးချဲ့နိုင်သည်။

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    Web server မှ SSE ကို ပံ့ပိုးသော web server သို့ ပြောင်းလဲရန် အကူအညီပေးသော နည်းလမ်းနှစ်ခုရှိသည်-

    - `AddMcpServer` သည် စွမ်းဆောင်ရည်များ ထည့်သွင်းသည်။
    - `MapMcp` သည် `/SSE` နှင့် `/messages` ကဲ့သို့သော routes များ ထည့်သွင်းသည်။

SSE အကြောင်း နည်းနည်း သိရှိသွားပြီဖြစ်သောကြောင့် အခုတော့ SSE server တစ်ခု တည်ဆောက်ကြရအောင်။

## လေ့ကျင့်ခန်း: SSE Server တည်ဆောက်ခြင်း

Server တည်ဆောက်ရာတွင် အောက်ပါအချက်နှစ်ချက်ကို သတိထားရမည်-

- Connection နှင့် message များအတွက် endpoint များ ဖော်ပြရန် web server ကို အသုံးပြုရမည်။
- stdio အသုံးပြုသည့်အခါကဲ့သို့ tools, resources နှင့် prompts များဖြင့် server ကို တည်ဆောက်ရမည်။

### -1- Server instance တစ်ခု ဖန်တီးခြင်း

Server ဖန်တီးရာတွင် stdio နှင့် တူညီသည့် type များကို အသုံးပြုမည်။ သို့သော် transport အတွက် SSE ကို ရွေးချယ်ရမည်။

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

အထက်ပါကုဒ်တွင်-

- Server instance တစ်ခု ဖန်တီးထားသည်။
- express web framework ကို အသုံးပြု၍ app တစ်ခု သတ်မှတ်ထားသည်။
- လာရောက်မည့် connection များကို သိမ်းဆည်းရန် transports variable တစ်ခု ဖန်တီးထားသည်။

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

အထက်ပါကုဒ်တွင်-

- လိုအပ်သော library များကို import ပြုလုပ်ထားပြီး Starlette (ASGI framework) ကို အသုံးပြုထားသည်။
- MCP server instance `mcp` ကို ဖန်တီးထားသည်။

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

ယခုအချိန်တွင်-

- Web app တစ်ခု ဖန်တီးထားသည်။
- `AddMcpServer` ဖြင့် MCP features များကို ပံ့ပိုးထားသည်။

နောက်တစ်ဆင့်တွင် လိုအပ်သော routes များ ထည့်သွင်းကြရအောင်။

### -2- Routes များ ထည့်သွင်းခြင်း

Connection နှင့် လာရောက်မည့် message များကို ကိုင်တွယ်မည့် routes များ ထည့်သွင်းကြရအောင်-

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

အထက်ပါကုဒ်တွင်-

- `/sse` route သည် SSE type transport ကို ဖန်တီးပြီး MCP server တွင် `connect` ကို ခေါ်သည်။
- `/messages` route သည် လာရောက်သော message များကို ကိုင်တွယ်သည်။

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

အထက်ပါကုဒ်တွင်-

- Starlette framework ကို အသုံးပြု၍ ASGI app instance တစ်ခု ဖန်တီးထားသည်။ ၎င်းတွင် `mcp.sse_app()` ကို routes စာရင်းထဲ ထည့်သွင်းထားသည်။ ၎င်းက `/sse` နှင့် `/messages` routes များကို app instance တွင် mount လုပ်သည်။

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

ကုဒ်တစ်ကြောင်း `add.MapMcp()` ကို အဆုံးတွင် ထည့်သွင်းထားပြီး `/SSE` နှင့် `/messages` routes များ ရရှိထားသည်။

နောက်တစ်ဆင့်တွင် server ၏ စွမ်းဆောင်ရည်များ ထည့်သွင်းကြရအောင်။

### -3- Server စွမ်းဆောင်ရည်များ ထည့်သွင်းခြင်း

SSE အထူးသတ်မှတ်ချက်များအားလုံး သတ်မှတ်ပြီးနောက် tools, prompts နှင့် resources ကဲ့သို့သော server စွမ်းဆောင်ရည်များ ထည့်သွင်းကြရအောင်။

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

ဥပမာအားဖြင့် tool တစ်ခု ထည့်သွင်းပုံကို ပြထားသည်။ ဤ tool သည် "random-joke" ဟု အမည်ပေးထားပြီး Chuck Norris API ကို ခေါ်ယူကာ JSON ဖြင့် ပြန်လည်ထုတ်ပေးသည်။

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

ယခု server တွင် tool တစ်ခု ရှိပါပြီ။

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. ပထမဦးဆုံး tools များ ဖန်တီးကြရအောင်၊ *Tools.cs* ဖိုင်တစ်ခု ဖန်တီးပြီး အောက်ပါအတိုင်းရေးသားပါ-

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  ၎င်းတွင်-

  - `Tools` class ကို `McpServerToolType` decorator ဖြင့် ဖန်တီးထားသည်။
  - `AddNumbers` tool ကို `McpServerTool` decorator ဖြင့် method အဖြစ် သတ်မှတ်ထားပြီး parameters နှင့် implementation ကို ထည့်သွင်းထားသည်။

1. ဖန်တီးထားသော `Tools` class ကို အသုံးပြုကြရအောင်-

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  `WithTools` ကို ခေါ်၍ tools များပါဝင်သည့် class အဖြစ် `Tools` ကို သတ်မှတ်ထားသည်။ အဆင်ပြေပါပြီ။

အရမ်းကောင်းပြီ၊ SSE ကို အသုံးပြုသော server တစ်ခု ရှိပါပြီ၊ အခုတော့ စမ်းသပ်ကြည့်ကြရအောင်။

## လေ့ကျင့်ခန်း: Inspector ဖြင့် SSE Server ကို Debug လုပ်ခြင်း

Inspector သည် ယခင်သင်ခန်းစာ [Creating your first server](/03-GettingStarted/01-first-server/README.md) တွင် မြင်တွေ့ခဲ့သည့် ကောင်းမွန်သော ကိရိယာတစ်ခုဖြစ်သည်။ ဒီမှာလည်း Inspector ကို အသုံးပြုနိုင်မလား ကြည့်ကြရအောင်-

### -1- Inspector ကို စတင်ပြေးဆွဲခြင်း

Inspector ကို run မည်ဆို server SSE server တစ်ခု run နေပြီးသား ဖြစ်ရမည်၊ အခု run လိုက်ကြရအောင်-

1. Server ကို run ပါ

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    `pip install "mcp[cli]"` ဖြင့် install ပြုလုပ်သည့် `uvicorn` executable ကို အသုံးပြုထားသည်ကို သတိပြုပါ။ `server:app` ဟူသည်မှာ `server.py` ဖိုင်ကို run ပြီး Starlette instance `app` ကို အသုံးပြုမည်ဖြစ်သည်။

    ### .NET

    ```sh
    dotnet run
    ```

    Server ကို စတင်နိုင်ပါပြီ။ ၎င်းနှင့် ဆက်သွယ်ရန် terminal အသစ် လိုအပ်ပါသည်။

1. Inspector ကို run ပါ

    > ![NOTE]
    > Server run နေသော terminal နှင့် မတူသော terminal တစ်ခုတွင် run ပါ။ ထို့အပြင် သင့် server run နေသော URL အတိုင်း အောက်ပါ command ကို ပြင်ဆင်ရန် လိုအပ်သည်။

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspector run ပုံသည် runtime များအားလုံးတွင် တူညီသည်။ Server ကို စတင်ရန် path နှင့် command မပေးဘဲ server run နေသော URL နှင့် `/sse` route ကို သတ်မှတ်ပေးသည်ကို သတိပြုပါ။

### -2- Tool ကို စမ်းသပ်ကြည့်ခြင်း

Droplist မှ SSE ကို ရွေးချယ်ပြီး သင့် server run နေသော URL ကို (ဥပမာ http:localhost:4321/sse) ဖြည့်ပါ။ "Connect" ခလုတ်ကို နှိပ်ပါ။ ယခင်ကဲ့သို့ tools များကို စာရင်းပြပြီး tool တစ်ခု ရွေးချယ်ကာ input value များ ထည့်သွင်းပါ။ အောက်ပါအတိုင်း ရလဒ်ကို မြင်ရမည်-

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.my.png)

ကောင်းပါပြီ၊ Inspector နှင့် အဆင်ပြေစွာ လုပ်ဆောင်နိုင်ပါပြီ၊ အခုတော့ Visual Studio Code ဖြင့် ဘယ်လို အသုံးပြုရမည်ကို ကြည့်ကြရအောင်။

## အလုပ်အပ်

သင့် server ကို စွမ်းဆောင်ရည်များ ပိုမိုတိုးချဲ့၍ တည်ဆောက်ကြည့်ပါ။ ဥပမာ API ခေါ်ယူသော tool တစ်ခု ထည့်ရန် [ဤစာမျက်နှာ](https://api.chucknorris.io/) ကို ကြည့်ရှုနိုင်သည်။ Server ကို မည်သို့ ဖန်တီးမည်ကို သင်ဆုံးဖြတ်ပါ။ ပျော်ရွှင်စွာ လေ့လာပါ :)

## ဖြေရှင်းချက်

[ဖြေရှင်းချက်](./solution/README.md) အလုပ်လုပ်သောကုဒ်ပါရှိသည့်ဖြေရှင်းချက်တစ်ခု ဖြစ်ပါသည်။

## အဓိက သင်ခန်းစာများ

ဤအခန်းမှ အဓိက သင်ခန်းစာများမှာ-

- SSE သည် stdio အနောက်တွင် ပံ့ပိုးထားသော ဒုတိယ သယ်ယူပို့ဆောင်မှုအမျိုးအစားဖြစ်သည်။
- SSE ကို ပံ့ပိုးရန် web framework ကို အသုံးပြု၍ လာရောက်သော connection နှင့် message များကို စီမံရမည်။
- Inspector နှင့် Visual Studio Code နှစ်ခုလုံးကို stdio server များကဲ့သို့ SSE server ကို အသုံးပြုနိုင်သည်။ stdio နှင့် SSE အကြား ကွာခြားချက်မှာ SSE အတွက် server ကို သီးခြားစတင်ပြီး inspector tool ကို run ရမည်ဖြစ်ပြီး inspector tool တွင် URL ကို သတ်မှတ်ရမည်ဖြစ်သည်။

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## အပိုဆောင်း အရင်းအမြစ်များ

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## နောက်တစ်ဆင့်

- နောက်တစ်ဆင့်: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ အတည်ပြုရမည့် အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများ သို့မဟုတ် မှားဖတ်မှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။