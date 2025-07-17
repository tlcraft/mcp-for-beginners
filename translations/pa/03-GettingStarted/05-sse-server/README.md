<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T18:23:10+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "pa"
}
-->
# SSE ਸਰਵਰ

SSE (Server Sent Events) ਸਰਵਰ ਤੋਂ ਕਲਾਇੰਟ ਤੱਕ ਸਟ੍ਰੀਮਿੰਗ ਲਈ ਇੱਕ ਮਿਆਰੀ ਤਰੀਕਾ ਹੈ, ਜੋ ਸਰਵਰਾਂ ਨੂੰ HTTP ਰਾਹੀਂ ਕਲਾਇੰਟਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ ਭੇਜਣ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਇਹ ਖਾਸ ਕਰਕੇ ਉਹਨਾਂ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਬਹੁਤ ਲਾਭਦਾਇਕ ਹੈ ਜਿਨ੍ਹਾਂ ਨੂੰ ਲਾਈਵ ਅੱਪਡੇਟ ਦੀ ਲੋੜ ਹੁੰਦੀ ਹੈ, ਜਿਵੇਂ ਕਿ ਚੈਟ ਐਪਲੀਕੇਸ਼ਨ, ਨੋਟੀਫਿਕੇਸ਼ਨ ਜਾਂ ਰੀਅਲ-ਟਾਈਮ ਡੇਟਾ ਫੀਡ। ਇਸਦੇ ਨਾਲ, ਤੁਹਾਡਾ ਸਰਵਰ ਇੱਕੋ ਸਮੇਂ ਕਈ ਕਲਾਇੰਟਾਂ ਵੱਲੋਂ ਵਰਤਿਆ ਜਾ ਸਕਦਾ ਹੈ ਕਿਉਂਕਿ ਇਹ ਕਿਸੇ ਕਲਾਉਡ ਵਿੱਚ ਚਲਾਇਆ ਜਾ ਸਕਦਾ ਹੈ।

## ਓਵਰਵਿਊ

ਇਸ ਪਾਠ ਵਿੱਚ ਅਸੀਂ ਸਿੱਖਾਂਗੇ ਕਿ SSE ਸਰਵਰ ਕਿਵੇਂ ਬਣਾਉਣੇ ਅਤੇ ਵਰਤਣੇ ਹਨ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੇ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- ਇੱਕ SSE ਸਰਵਰ ਬਣਾਉਣਾ।
- Inspector ਦੀ ਵਰਤੋਂ ਕਰਕੇ SSE ਸਰਵਰ ਨੂੰ ਡੀਬੱਗ ਕਰਨਾ।
- Visual Studio Code ਦੀ ਵਰਤੋਂ ਕਰਕੇ SSE ਸਰਵਰ ਨੂੰ ਕਨਜ਼ਿਊਮ ਕਰਨਾ।

## SSE, ਇਹ ਕਿਵੇਂ ਕੰਮ ਕਰਦਾ ਹੈ

SSE ਦੋ ਸਮਰਥਿਤ ਟ੍ਰਾਂਸਪੋਰਟ ਕਿਸਮਾਂ ਵਿੱਚੋਂ ਇੱਕ ਹੈ। ਤੁਸੀਂ ਪਹਿਲਾਂ ਹੀ ਪਹਿਲੀ stdio ਕਿਸਮ ਨੂੰ ਪਿਛਲੇ ਪਾਠਾਂ ਵਿੱਚ ਵਰਤਦੇ ਦੇਖਿਆ ਹੈ। ਫਰਕ ਇਹ ਹੈ:

- SSE ਵਿੱਚ ਤੁਹਾਨੂੰ ਦੋ ਚੀਜ਼ਾਂ ਨੂੰ ਸੰਭਾਲਣਾ ਪੈਂਦਾ ਹੈ; ਕਨੈਕਸ਼ਨ ਅਤੇ ਸੁਨੇਹੇ।
- ਕਿਉਂਕਿ ਇਹ ਇੱਕ ਐਸਾ ਸਰਵਰ ਹੈ ਜੋ ਕਿਤੇ ਵੀ ਹੋ ਸਕਦਾ ਹੈ, ਤੁਹਾਨੂੰ ਇਹ ਧਿਆਨ ਵਿੱਚ ਰੱਖਣਾ ਪਵੇਗਾ ਕਿ ਤੁਸੀਂ Inspector ਅਤੇ Visual Studio Code ਵਰਗੇ ਟੂਲਾਂ ਨਾਲ ਕਿਵੇਂ ਕੰਮ ਕਰਦੇ ਹੋ। ਇਸਦਾ ਮਤਲਬ ਇਹ ਹੈ ਕਿ ਤੁਸੀਂ ਸਰਵਰ ਸ਼ੁਰੂ ਕਰਨ ਦੀ ਬਜਾਏ ਉਸ ਐਂਡਪੌਇੰਟ ਨੂੰ ਦਰਸਾਉਂਦੇ ਹੋ ਜਿੱਥੇ ਕਨੈਕਸ਼ਨ ਸਥਾਪਿਤ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ। ਹੇਠਾਂ ਉਦਾਹਰਨ ਦੇਖੋ:

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

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ:

- `/sse` ਇੱਕ ਰੂਟ ਵਜੋਂ ਸੈੱਟ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਇਸ ਰੂਟ ਵੱਲ ਬੇਨਤੀ ਕੀਤੀ ਜਾਂਦੀ ਹੈ, ਇੱਕ ਨਵਾਂ ਟ੍ਰਾਂਸਪੋਰਟ ਇੰਸਟੈਂਸ ਬਣਾਇਆ ਜਾਂਦਾ ਹੈ ਅਤੇ ਸਰਵਰ ਇਸ ਟ੍ਰਾਂਸਪੋਰਟ ਰਾਹੀਂ *ਕਨੈਕਟ* ਹੁੰਦਾ ਹੈ।
- `/messages`, ਇਹ ਰੂਟ ਆਉਣ ਵਾਲੇ ਸੁਨੇਹਿਆਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ।

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

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਇੱਕ ASGI ਸਰਵਰ ਦਾ ਇੰਸਟੈਂਸ ਬਣਾਇਆ (ਖਾਸ ਕਰਕੇ Starlette ਦੀ ਵਰਤੋਂ ਕਰਕੇ) ਅਤੇ ਡਿਫਾਲਟ ਰੂਟ `/` ਨੂੰ ਮਾਊਂਟ ਕੀਤਾ।

  ਪਿਛੋਕੜ ਵਿੱਚ ਇਹ ਹੁੰਦਾ ਹੈ ਕਿ `/sse` ਅਤੇ `/messages` ਰੂਟ ਕਨੈਕਸ਼ਨਾਂ ਅਤੇ ਸੁਨੇਹਿਆਂ ਨੂੰ ਸੰਭਾਲਣ ਲਈ ਸੈੱਟ ਕੀਤੇ ਜਾਂਦੇ ਹਨ। ਬਾਕੀ ਐਪ, ਜਿਵੇਂ ਕਿ ਟੂਲਾਂ ਦੇ ਫੀਚਰ ਸ਼ਾਮਲ ਕਰਨਾ, stdio ਸਰਵਰਾਂ ਵਾਂਗ ਹੀ ਹੁੰਦਾ ਹੈ।

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

    ਦੋ ਮੈਥਡ ਹਨ ਜੋ ਸਾਨੂੰ ਵੈੱਬ ਸਰਵਰ ਤੋਂ SSE ਸਮਰਥਿਤ ਵੈੱਬ ਸਰਵਰ ਬਣਾਉਣ ਵਿੱਚ ਮਦਦ ਕਰਦੇ ਹਨ:

    - `AddMcpServer`, ਇਹ ਸਮਰੱਥਾਵਾਂ ਜੋੜਦਾ ਹੈ।
    - `MapMcp`, ਇਹ `/SSE` ਅਤੇ `/messages` ਵਰਗੇ ਰੂਟ ਜੋੜਦਾ ਹੈ।
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

    Inspector ਚਲਾਉਣਾ ਸਾਰੇ ਰਨਟਾਈਮਾਂ ਵਿੱਚ ਇੱਕੋ ਜਿਹਾ ਹੁੰਦਾ ਹੈ। ਧਿਆਨ ਦਿਓ ਕਿ ਅਸੀਂ ਸਰਵਰ ਨੂੰ ਸ਼ੁਰੂ ਕਰਨ ਲਈ ਰਾਹ ਜਾਂ ਕਮਾਂਡ ਦੇਣ ਦੀ ਬਜਾਏ, ਉਸ URL ਨੂੰ ਦਿੰਦੇ ਹਾਂ ਜਿੱਥੇ ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੈ ਅਤੇ `/sse` ਰੂਟ ਨੂੰ ਵੀ ਦਰਸਾਉਂਦੇ ਹਾਂ।

### -2- ਟੂਲ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰਨਾ

ਡ੍ਰੌਪਲਿਸਟ ਵਿੱਚੋਂ SSE ਚੁਣੋ ਅਤੇ ਉਸ URL ਨੂੰ ਭਰੋ ਜਿੱਥੇ ਤੁਹਾਡਾ ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੈ, ਉਦਾਹਰਨ ਵਜੋਂ http:localhost:4321/sse। ਹੁਣ "Connect" ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਪਹਿਲਾਂ ਵਾਂਗ, ਟੂਲਾਂ ਦੀ ਸੂਚੀ ਬਣਾਓ, ਇੱਕ ਟੂਲ ਚੁਣੋ ਅਤੇ ਇਨਪੁੱਟ ਮੁੱਲ ਦਿਓ। ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤੇ ਨਤੀਜੇ ਵਰਗਾ ਕੁਝ ਵੇਖਣ ਨੂੰ ਮਿਲੇਗਾ:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.pa.png)

ਵਧੀਆ, ਤੁਸੀਂ Inspector ਨਾਲ ਕੰਮ ਕਰ ਸਕਦੇ ਹੋ, ਹੁਣ ਦੇਖੀਏ ਕਿ ਅਸੀਂ Visual Studio Code ਨਾਲ ਕਿਵੇਂ ਕੰਮ ਕਰ ਸਕਦੇ ਹਾਂ।

## ਅਸਾਈਨਮੈਂਟ

ਆਪਣੇ ਸਰਵਰ ਨੂੰ ਹੋਰ ਸਮਰੱਥਾਵਾਂ ਨਾਲ ਬਣਾਉਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ। ਉਦਾਹਰਨ ਵਜੋਂ, [ਇਸ ਪੰਨੇ](https://api.chucknorris.io/) ਨੂੰ ਵੇਖੋ ਅਤੇ ਇੱਕ ਐਸਾ ਟੂਲ ਸ਼ਾਮਲ ਕਰੋ ਜੋ ਕਿਸੇ API ਨੂੰ ਕਾਲ ਕਰਦਾ ਹੋਵੇ। ਤੁਸੀਂ ਫੈਸਲਾ ਕਰੋ ਕਿ ਸਰਵਰ ਕਿਵੇਂ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਜ਼ੇ ਕਰੋ :)

## ਹੱਲ

[Solution](./solution/README.md) ਇੱਥੇ ਇੱਕ ਸੰਭਵ ਹੱਲ ਹੈ ਜਿਸ ਵਿੱਚ ਕੰਮ ਕਰਦਾ ਕੋਡ ਦਿੱਤਾ ਗਿਆ ਹੈ।

## ਮੁੱਖ ਗੱਲਾਂ

ਇਸ ਅਧਿਆਇ ਤੋਂ ਮੁੱਖ ਸਿੱਖਣ ਵਾਲੀਆਂ ਗੱਲਾਂ ਹਨ:

- SSE stdio ਦੇ ਬਾਅਦ ਦੂਜਾ ਸਮਰਥਿਤ ਟ੍ਰਾਂਸਪੋਰਟ ਹੈ।
- SSE ਨੂੰ ਸਮਰਥਨ ਦੇਣ ਲਈ, ਤੁਹਾਨੂੰ ਆਉਣ ਵਾਲੀਆਂ ਕਨੈਕਸ਼ਨਾਂ ਅਤੇ ਸੁਨੇਹਿਆਂ ਨੂੰ ਵੈੱਬ ਫਰੇਮਵਰਕ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸੰਭਾਲਣਾ ਪੈਂਦਾ ਹੈ।
- ਤੁਸੀਂ Inspector ਅਤੇ Visual Studio Code ਦੋਹਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ SSE ਸਰਵਰ ਨੂੰ ਕਨਜ਼ਿਊਮ ਕਰ ਸਕਦੇ ਹੋ, ਬਿਲਕੁਲ stdio ਸਰਵਰਾਂ ਵਾਂਗ। ਧਿਆਨ ਦਿਓ ਕਿ stdio ਅਤੇ SSE ਵਿੱਚ ਕੁਝ ਫਰਕ ਹੁੰਦਾ ਹੈ। SSE ਲਈ, ਤੁਹਾਨੂੰ ਸਰਵਰ ਨੂੰ ਅਲੱਗ ਤੌਰ 'ਤੇ ਚਲਾਉਣਾ ਪੈਂਦਾ ਹੈ ਅਤੇ ਫਿਰ Inspector ਟੂਲ ਚਲਾਉਣਾ ਪੈਂਦਾ ਹੈ। Inspector ਟੂਲ ਲਈ ਵੀ ਕੁਝ ਫਰਕ ਹਨ, ਜਿਵੇਂ ਕਿ URL ਦਰਸਾਉਣਾ ਲਾਜ਼ਮੀ ਹੈ।

## ਨਮੂਨੇ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## ਵਾਧੂ ਸਰੋਤ

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## ਅਗਲਾ ਕੀ ਹੈ

- ਅਗਲਾ: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।