<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T19:39:06+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "my"
}
-->
# SSE Server

SSE (Server Sent Events) သည် server မှ client သို့ တိုက်ရိုက် streaming ပေးနိုင်ရန်အတွက် စံသတ်မှတ်ချက်ဖြစ်ပြီး၊ server များသည် HTTP မှတဆင့် client များထံ အချိန်နှင့်တပြေးညီ အချက်အလက်များကို push ပေးနိုင်သည်။ ၎င်းသည် chat application များ၊ အသိပေးချက်များ သို့မဟုတ် အချိန်နှင့်တပြေးညီ ဒေတာများလိုအပ်သော application များအတွက် အထူးအသုံးဝင်သည်။ ထို့အပြင် သင့် server ကို cloud တစ်ခုခုတွင် တည်ဆောက်ထား၍ အချိန်တစ်ပြေးညီ client များစွာက အသုံးပြုနိုင်ပါသည်။

## အနှစ်ချုပ်

ဤသင်ခန်းစာတွင် SSE Server များကို ဘယ်လို တည်ဆောက်ပြီး အသုံးပြုရမည်ကို ဖော်ပြထားသည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးတွင် သင်သည် -

- SSE Server တည်ဆောက်နိုင်မည်။
- Inspector ကို အသုံးပြု၍ SSE Server ကို debug လုပ်နိုင်မည်။
- Visual Studio Code ဖြင့် SSE Server ကို အသုံးပြုနိုင်မည်။

## SSE, ၎င်း၏ လုပ်ဆောင်ပုံ

SSE သည် ပံ့ပိုးထားသော သယ်ယူပို့ဆောင်မှုအမျိုးအစား နှစ်မျိုးထဲမှ တစ်ခုဖြစ်သည်။ သင်သည် ယခင်သင်ခန်းစာများတွင် stdio ကို အသုံးပြုထားကြောင်း မြင်တွေ့ပြီးဖြစ်သည်။ ကွာခြားချက်မှာ -

- SSE သည် connection နှင့် message များကို ကိုင်တွယ်ရမည်။
- ၎င်းသည် server တစ်ခုဖြစ်ပြီး မည်သည့်နေရာတွင်မဆို တည်ရှိနိုင်သောကြောင့် Inspector နှင့် Visual Studio Code ကဲ့သို့သော ကိရိယာများနှင့် လုပ်ဆောင်ရာတွင် ထိုအချက်ကို ထည့်သွင်းစဉ်းစားရမည်။ ၎င်း၏ အဓိပ္ပါယ်မှာ server ကို စတင်ရန် နည်းလမ်းပြခြင်းမဟုတ်ဘဲ connection တည်ဆောက်နိုင်သော endpoint ကို ပြသပေးရမည်ဖြစ်သည်။ အောက်တွင် ဥပမာကုဒ်ကို ကြည့်ပါ။

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

အထက်ပါကုဒ်တွင် -

- `/sse` သည် route အဖြစ် သတ်မှတ်ထားသည်။ ဤ route သို့ request တစ်ခု ရောက်ရှိလာသည်နှင့်အမျှ transport instance အသစ်တစ်ခု ဖန်တီးပြီး server သည် ဤ transport ဖြင့် *connect* လုပ်သည်။
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

အထက်ပါကုဒ်တွင် -

- ASGI server instance တစ်ခု (Starlette ကို အသုံးပြု၍) ဖန်တီးပြီး default route `/` ကို mount လုပ်သည်။

  နောက်ခံတွင် `/sse` နှင့် `/messages` routes များကို connection နှင့် message များကို ကိုင်တွယ်ရန် သတ်မှတ်ထားသည်။ အခြား app အစိတ်အပိုင်းများ၊ tools များ ထည့်သွင်းခြင်းက stdio server များနှင့် တူညီသည်။

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

    Web server မှ SSE ကို ပံ့ပိုးသော web server သို့ ပြောင်းလဲရန် အကူအညီပေးသော နည်းလမ်းနှစ်ခုရှိသည် -

    - `AddMcpServer` သည် စွမ်းဆောင်ရည်များ ထည့်သွင်းသည်။
    - `MapMcp` သည် `/SSE` နှင့် `/messages` ကဲ့သို့သော routes များ ထည့်သွင်းသည်။
```

Now that we know a little bit more about SSE, let's build an SSE server next.

## Exercise: Creating an SSE Server

To create our server, we need to keep two things in mind:

- We need to use a web server to expose endpoints for connection and messages.
- Build our server like we normally do with tools, resources and prompts when we were using stdio.

### -1- Create a server instance

To create our server, we use the same types as with stdio. However, for the transport, we need to choose SSE.

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

In the preceding code we've:

- Created a server instance.
- Defined an app using the web framework express.
- Created a transports variable that we will use to store incoming connections.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

In the preceding code we've:

- Imported the libraries we're going to need with Starlette (an ASGI framework) being pulled in.
- Created an MCP server instance `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

At this point, we've:

- Created a web app
- Added support for MCP features through `AddMcpServer`.

Let's add the needed routes next.

### -2- Add routes

Let's add routes next that handle the connection and incoming messages:

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

In the preceding code we've defined:

- An `/sse` route that instantiates a transport of type SSE and ends up calling `connect` on the MCP server.
- A `/messages` route that takes care of incoming messages.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

In the preceding code we've:

- Created an ASGI app instance using the Starlette framework. As part of that we passes `mcp.sse_app()` to it's list of routes. That ends up mounting an `/sse` and `/messages` route on the app instance.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

We've added one line of code at the end `add.MapMcp()` this means we now have routes `/SSE` and `/messages`. 

Let's add capabilties to the server next.

### -3- Adding server capabilities

Now that we've got everything SSE specific defined, let's add server capabilities like tools, prompts and resources.

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

Here's how you can add a tool for example. This specific tool creates a tool call "random-joke" that calls a Chuck Norris API and returns a JSON response.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Now your server has one tool.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// MCP server တစ်ခု ဖန်တီးခြင်း
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

# ရှိပြီးသား ASGI server တွင် SSE server ကို mount လုပ်ခြင်း
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Let's create some tools first, for this we will create a file *Tools.cs* with the following content:

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

  Here we've added the following:

  - Created a class `Tools` with the decorator `McpServerToolType`.
  - Defined a tool `AddNumbers` by decorating the method with `McpServerTool`. We've also provided parameters and an implementation.

1. Let's leverage the `Tools` class we just created:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  We've added a call to `WithTools` that specifies `Tools` as the class containing the tools. That's it, we're ready.

Great, we have a server using SSE, let's take it for a spin next.

## Exercise: Debugging an SSE Server with Inspector

Inspector is a great tool that we saw in a previous lesson [Creating your first server](/03-GettingStarted/01-first-server/README.md). Let's see if we can use the Inspector even here:

### -1- Running the inspector

To run the inspector, you first must have an SSE server running, so let's do that next:

1. Run the server 

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Note how we use the executable `uvicorn` that's installed when we typed `pip install "mcp[cli]"`. Typing `server:app` means we're trying to run a file `server.py` and for it to have a Starlette instance called `app`. 

    ### .NET

    ```sh
    dotnet run
    ```

    This should start the server. To interface with it you need a new terminal.

1. Run the inspector

    > ![NOTE]
    > Run this in a separate terminal window than the server is running in. Also note, you need to adjust the below command to fit the URL where your server runs.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspector ကို အသုံးပြုရာတွင် runtime များအားလုံးတွင် တူညီသော ပုံစံဖြင့် လည်ပတ်သည်။ server ကို စတင်ရန် command တစ်ခုနှင့် path တစ်ခု ပေးပို့ခြင်းမပြုဘဲ server လည်ပတ်နေသော URL ကို ပေးပို့ပြီး `/sse` route ကို သတ်မှတ်ပေးရသည်ကို သတိပြုပါ။

### -2- Tool ကို စမ်းသပ်ခြင်း

SSE ကို droplist မှ ရွေးချယ်ပြီး သင့် server လည်ပတ်နေသော URL ကို (ဥပမာ http:localhost:4321/sse) url field တွင် ဖြည့်ပါ။ "Connect" ခလုတ်ကို နှိပ်ပါ။ ယခင်ကဲ့သို့ tools များကို စာရင်းပြုစုရန် ရွေးချယ်ပြီး tool တစ်ခုကို ရွေးချယ်၍ input တန်ဖိုးများ ထည့်သွင်းပါ။ အောက်ပါအတိုင်း ရလဒ်ကို မြင်ရမည်ဖြစ်သည်။

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.my.png)

အလွန်ကောင်းပါပြီ၊ inspector နှင့် အလုပ်လုပ်နိုင်ပါပြီ။ အခုတော့ Visual Studio Code ဖြင့် ဘယ်လို အလုပ်လုပ်ရမည်ကို ကြည့်ကြရအောင်။

## လုပ်ငန်းတာဝန်

သင့် server ကို ပိုမိုစွမ်းဆောင်ရည်များဖြင့် တည်ဆောက်ကြည့်ပါ။ ဥပမာ API တစ်ခုကို ခေါ်သုံးသော tool တစ်ခု ထည့်သွင်းရန် [ဤစာမျက်နှာ](https://api.chucknorris.io/) ကို ကြည့်ပါ။ server ကို ဘယ်လို ဖန်တီးမည်ကို သင်ဆုံးဖြတ်ပါ။ ပျော်ရွှင်စွာ လေ့လာပါ :)

## ဖြေရှင်းချက်

[ဖြေရှင်းချက်](./solution/README.md) အလုပ်လုပ်သောကုဒ်ပါဝင်သည့်ဖြေရှင်းချက်တစ်ခု ဖြစ်ပါသည်။

## အဓိက သင်ခန်းစာများ

ဤအခန်းမှ အဓိက သင်ခန်းစာများမှာ -

- SSE သည် stdio အနောက်တွင် ပံ့ပိုးထားသော ဒုတိယ သယ်ယူပို့ဆောင်မှုအမျိုးအစားဖြစ်သည်။
- SSE ကို ပံ့ပိုးရန် web framework အသုံးပြု၍ connection များနှင့် message များကို စီမံခန့်ခွဲရမည်။
- Inspector နှင့် Visual Studio Code နှစ်ခုလုံးကို stdio server များကဲ့သို့ SSE server ကို အသုံးပြုနိုင်သည်။ stdio နှင့် SSE အကြား ကွာခြားချက်မှာ SSE အတွက် server ကို သီးခြားစတင်ရမည်ဖြစ်ပြီး inspector tool ကိုလည်း URL ဖြင့် သတ်မှတ်ရမည်ဖြစ်သည်။

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
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။