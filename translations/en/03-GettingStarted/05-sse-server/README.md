<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T09:28:32+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "en"
}
-->
# SSE Server

SSE (Server Sent Events) is a standard for server-to-client streaming, allowing servers to push real-time updates to clients over HTTP. This is especially useful for applications that need live updates, such as chat apps, notifications, or real-time data feeds. Also, your server can be accessed by multiple clients simultaneously since it runs on a server that can be hosted in the cloud, for example.

## Overview

This lesson explains how to build and use SSE Servers.

## Learning Objectives

By the end of this lesson, you will be able to:

- Build an SSE Server.
- Debug an SSE Server using the Inspector.
- Use an SSE Server with Visual Studio Code.

## SSE, how it works

SSE is one of two supported transport types. You’ve already seen the first one, stdio, used in previous lessons. The difference is:

- SSE requires you to handle two things: connections and messages.
- Since this server can run anywhere, you need to reflect that in how you work with tools like the Inspector and Visual Studio Code. This means that instead of specifying how to start the server, you point to the endpoint where the connection is established. See the example code below:

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

In the code above:

- `/sse` is set up as a route. When a request hits this route, a new transport instance is created and the server *connects* using this transport.
- `/messages` is the route that handles incoming messages.

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

In the code above we:

- Create an instance of an ASGI server (using Starlette specifically) and mount the default route `/`.

  Behind the scenes, the routes `/sse` and `/messages` are set up to handle connections and messages respectively. The rest of the app, like adding features such as tools, works the same way as with stdio servers.

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

There are two methods that help us transform a web server into one that supports SSE:

- `AddMcpServer` adds the necessary capabilities.
- `MapMcp` adds routes like `/SSE` and `/messages`.

Now that we have a basic understanding of SSE, let’s build an SSE server.

## Exercise: Creating an SSE Server

When creating our server, keep two things in mind:

- Use a web server to expose endpoints for connections and messages.
- Build the server as usual with tools, resources, and prompts, just like when using stdio.

### -1- Create a server instance

We use the same types as with stdio, but for the transport, we select SSE.

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

In the code above we have:

- Created a server instance.
- Defined an app using the Express web framework.
- Created a `transports` variable to store incoming connections.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

In the code above we have:

- Imported the necessary libraries, including Starlette (an ASGI framework).
- Created an MCP server instance called `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

At this point, we have:

- Created a web app.
- Added support for MCP features via `AddMcpServer`.

Next, let’s add the required routes.

### -2- Add routes

Now, add routes to handle connections and incoming messages:

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

In the code above we have defined:

- An `/sse` route that creates an SSE transport and calls `connect` on the MCP server.
- A `/messages` route that handles incoming messages.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

In the code above we have:

- Created an ASGI app instance using the Starlette framework. We pass `mcp.sse_app()` to its list of routes, which mounts `/sse` and `/messages` routes on the app.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

We added one line at the end: `add.MapMcp()`. This means we now have `/SSE` and `/messages` routes.

Next, let’s add capabilities to the server.

### -3- Adding server capabilities

With the SSE-specific setup done, let’s add server capabilities like tools, prompts, and resources.

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

Here’s how to add a tool, for example. This tool creates a "random-joke" tool that calls a Chuck Norris API and returns a JSON response.

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

1. First, create some tools by adding a file *Tools.cs* with the following content:

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

  Here we have:

  - Created a class `Tools` decorated with `McpServerToolType`.
  - Defined a tool `AddNumbers` by decorating the method with `McpServerTool`. Parameters and implementation are provided.

1. Next, use the `Tools` class we just created:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  We added a call to `WithTools` specifying `Tools` as the class containing the tools. That’s it, we’re ready.

Great, we have an SSE server. Let’s try it out.

## Exercise: Debugging an SSE Server with Inspector

Inspector is a great tool we saw in a previous lesson [Creating your first server](/03-GettingStarted/01-first-server/README.md). Let’s see if we can use Inspector here as well:

### -1- Running the inspector

To run Inspector, you first need an SSE server running. Let’s start it:

1. Run the server

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Notice we use the executable `uvicorn` installed when running `pip install "mcp[cli]"`. The argument `server:app` means we run the file `server.py` and expect it to have a Starlette instance called `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    This should start the server. To interact with it, open a new terminal.

1. Run the inspector

    > ![NOTE]
    > Run this in a separate terminal window from where the server is running. Also, adjust the command below to match the URL where your server is running.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Running Inspector is similar across runtimes. Instead of passing a path to the server and a command to start it, you pass the URL where the server is running and specify the `/sse` route.

### -2- Trying out the tool

Connect to the server by selecting SSE in the dropdown and entering the URL where your server runs, for example `http://localhost:4321/sse`. Click "Connect". Then, list tools, select one, and provide input values. You should see a result like this:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.en.png)

Great, you can work with Inspector. Next, let’s see how to use Visual Studio Code.

## Assignment

Try expanding your server with more capabilities. See [this page](https://api.chucknorris.io/) to, for example, add a tool that calls an API. You decide what your server should do. Have fun :)

## Solution

[Solution](./solution/README.md) Here’s one possible solution with working code.

## Key Takeaways

The main points from this chapter are:

- SSE is the second supported transport alongside stdio.
- To support SSE, you need to manage incoming connections and messages using a web framework.
- You can use both Inspector and Visual Studio Code to consume an SSE server, just like stdio servers. Note some differences: for SSE, you start the server separately and then run Inspector. Also, with Inspector, you specify the URL instead of a path.

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Additional Resources

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## What's Next

- Next: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.