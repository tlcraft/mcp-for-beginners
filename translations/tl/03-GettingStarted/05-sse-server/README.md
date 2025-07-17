<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T19:09:27+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "tl"
}
-->
# SSE Server

Ang SSE (Server Sent Events) ay isang pamantayan para sa streaming mula server papunta sa client, na nagpapahintulot sa mga server na magpadala ng real-time na mga update sa mga client gamit ang HTTP. Napaka-kapaki-pakinabang ito para sa mga aplikasyon na nangangailangan ng live na update, tulad ng mga chat application, mga notification, o real-time na data feeds. Bukod dito, maaaring gamitin ng maraming client ang iyong server nang sabay-sabay dahil ito ay tumatakbo sa isang server na maaaring nasa cloud halimbawa.

## Pangkalahatang-ideya

Tinuturo sa araling ito kung paano gumawa at gumamit ng SSE Servers.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Gumawa ng SSE Server.
- Mag-debug ng SSE Server gamit ang Inspector.
- Gumamit ng SSE Server gamit ang Visual Studio Code.

## SSE, paano ito gumagana

Ang SSE ay isa sa dalawang suportadong uri ng transport. Nakita mo na ang una, ang stdio, sa mga naunang aralin. Ang pagkakaiba ay ang mga sumusunod:

- Kailangan mong pangasiwaan ang dalawang bagay sa SSE; ang koneksyon at mga mensahe.
- Dahil ang server na ito ay maaaring tumakbo kahit saan, kailangan mong ipakita ito sa paraan ng paggamit mo ng mga tools tulad ng Inspector at Visual Studio Code. Ibig sabihin nito, sa halip na ituro kung paano simulan ang server, itinuturo mo ang endpoint kung saan maaaring magtatag ng koneksyon. Tingnan ang halimbawa ng code sa ibaba:

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

Sa code sa itaas:

- Ang `/sse` ay itinakda bilang ruta. Kapag may request na ginawa sa rutang ito, isang bagong transport instance ang nilikha at ang server ay *kumokonekta* gamit ang transport na ito.
- Ang `/messages` naman ang ruta na humahawak sa mga papasok na mensahe.

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

Sa code sa itaas:

- Gumagawa tayo ng instance ng ASGI server (gamit ang Starlette partikular) at ini-mount ang default na ruta `/`

  Ang nangyayari sa likod ng eksena ay ang mga ruta na `/sse` at `/messages` ay naka-set up para hawakan ang mga koneksyon at mga mensahe ayon sa pagkakasunod. Ang iba pang bahagi ng app, tulad ng pagdagdag ng mga features gaya ng tools, ay ginagawa tulad ng sa stdio servers.

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

May dalawang paraan na tumutulong sa atin mula sa isang web server patungo sa web server na sumusuporta sa SSE at ito ay:

- `AddMcpServer`, ang method na ito ay nagdadagdag ng mga kakayahan.
- `MapMcp`, ito ay nagdadagdag ng mga ruta tulad ng `/SSE` at `/messages`.
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

// Gumawa ng MCP server
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

# I-mount ang SSE server sa kasalukuyang ASGI server
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

    Ang pagpapatakbo ng inspector ay pareho sa lahat ng runtime. Pansinin na sa halip na magbigay ng path sa ating server at command para simulan ang server, nagbibigay tayo ng URL kung saan tumatakbo ang server at tinutukoy din natin ang ruta na `/sse`.

### -2- Pagsubok sa tool

Ikonekta ang server sa pamamagitan ng pagpili ng SSE sa droplist at punan ang url field kung saan tumatakbo ang iyong server, halimbawa http:localhost:4321/sse. Ngayon, i-click ang "Connect" button. Tulad ng dati, piliin ang list tools, pumili ng tool at magbigay ng mga input na halaga. Makikita mo ang resulta tulad ng nasa ibaba:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.tl.png)

Magaling, kaya mo nang gamitin ang inspector, tingnan natin kung paano gamitin ang Visual Studio Code sa susunod.

## Takdang-Aralin

Subukang palawakin ang iyong server ng mas maraming kakayahan. Tingnan ang [pahina na ito](https://api.chucknorris.io/) para, halimbawa, magdagdag ng tool na tumatawag ng API. Ikaw ang magpapasya kung ano ang magiging itsura ng server. Mag-enjoy :)

## Solusyon

[Solusyon](./solution/README.md) Narito ang isang posibleng solusyon na may gumaganang code.

## Mahahalagang Punto

Ang mga mahahalagang punto mula sa kabanatang ito ay ang mga sumusunod:

- Ang SSE ang pangalawang suportadong transport maliban sa stdio.
- Para suportahan ang SSE, kailangan mong pamahalaan ang mga papasok na koneksyon at mga mensahe gamit ang web framework.
- Maaari mong gamitin ang parehong Inspector at Visual Studio Code para gamitin ang SSE server, tulad ng sa stdio servers. Pansinin ang kaunting pagkakaiba sa pagitan ng stdio at SSE. Para sa SSE, kailangan mong patakbuhin ang server nang hiwalay bago patakbuhin ang iyong inspector tool. Sa inspector tool, may kaunting pagkakaiba rin dahil kailangan mong tukuyin ang URL.

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Karagdagang Mga Sanggunian

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Ano ang Susunod

- Susunod: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.