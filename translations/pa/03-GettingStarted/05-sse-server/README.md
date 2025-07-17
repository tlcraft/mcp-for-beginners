<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T00:57:17+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "pa"
}
-->
# SSE ਸਰਵਰ

SSE (Server Sent Events) ਸਰਵਰ ਤੋਂ ਕਲਾਇੰਟ ਤੱਕ ਸਟ੍ਰੀਮਿੰਗ ਲਈ ਇੱਕ ਮਿਆਰੀ ਤਰੀਕਾ ਹੈ, ਜੋ ਸਰਵਰਾਂ ਨੂੰ HTTP ਰਾਹੀਂ ਕਲਾਇੰਟਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ ਭੇਜਣ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਇਹ ਖਾਸ ਕਰਕੇ ਉਹਨਾਂ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਬਹੁਤ ਲਾਭਦਾਇਕ ਹੈ ਜਿਨ੍ਹਾਂ ਨੂੰ ਲਾਈਵ ਅੱਪਡੇਟ ਦੀ ਲੋੜ ਹੁੰਦੀ ਹੈ, ਜਿਵੇਂ ਕਿ ਚੈਟ ਐਪਲੀਕੇਸ਼ਨ, ਨੋਟੀਫਿਕੇਸ਼ਨ ਜਾਂ ਰੀਅਲ-ਟਾਈਮ ਡੇਟਾ ਫੀਡ। ਇਸਦੇ ਨਾਲ, ਤੁਹਾਡਾ ਸਰਵਰ ਕਈ ਕਲਾਇੰਟਾਂ ਵੱਲੋਂ ਇੱਕੋ ਸਮੇਂ ਵਰਤਿਆ ਜਾ ਸਕਦਾ ਹੈ ਕਿਉਂਕਿ ਇਹ ਕਿਸੇ ਕਲਾਉਡ ਵਿੱਚ ਚਲਾਇਆ ਜਾ ਸਕਦਾ ਹੈ।

## ਓਵਰਵਿਊ

ਇਸ ਪਾਠ ਵਿੱਚ ਅਸੀਂ ਸਿੱਖਾਂਗੇ ਕਿ SSE ਸਰਵਰ ਕਿਵੇਂ ਬਣਾਉਣ ਅਤੇ ਵਰਤਣੇ ਹਨ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੇ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- ਇੱਕ SSE ਸਰਵਰ ਬਣਾਉਣਾ।
- Inspector ਦੀ ਵਰਤੋਂ ਕਰਕੇ SSE ਸਰਵਰ ਨੂੰ ਡੀਬੱਗ ਕਰਨਾ।
- Visual Studio Code ਦੀ ਵਰਤੋਂ ਕਰਕੇ SSE ਸਰਵਰ ਨੂੰ ਕਨਜ਼ਿਊਮ ਕਰਨਾ।

## SSE, ਇਹ ਕਿਵੇਂ ਕੰਮ ਕਰਦਾ ਹੈ

SSE ਦੋ ਸਮਰਥਿਤ ਟ੍ਰਾਂਸਪੋਰਟ ਕਿਸਮਾਂ ਵਿੱਚੋਂ ਇੱਕ ਹੈ। ਤੁਸੀਂ ਪਹਿਲਾਂ ਦੇ ਪਾਠਾਂ ਵਿੱਚ stdio ਦੀ ਵਰਤੋਂ ਵੇਖੀ ਹੈ। ਫਰਕ ਇਹ ਹੈ:

- SSE ਲਈ ਤੁਹਾਨੂੰ ਦੋ ਚੀਜ਼ਾਂ ਸੰਭਾਲਣੀਆਂ ਪੈਂਦੀਆਂ ਹਨ; ਕਨੈਕਸ਼ਨ ਅਤੇ ਸੁਨੇਹੇ।
- ਕਿਉਂਕਿ ਇਹ ਇੱਕ ਐਸਾ ਸਰਵਰ ਹੈ ਜੋ ਕਿਤੇ ਵੀ ਹੋ ਸਕਦਾ ਹੈ, ਤੁਹਾਨੂੰ Inspector ਅਤੇ Visual Studio Code ਵਰਗੇ ਟੂਲਾਂ ਨਾਲ ਕੰਮ ਕਰਦੇ ਸਮੇਂ ਇਸ ਗੱਲ ਦਾ ਧਿਆਨ ਰੱਖਣਾ ਪੈਂਦਾ ਹੈ। ਇਸਦਾ ਮਤਲਬ ਇਹ ਹੈ ਕਿ ਤੁਸੀਂ ਸਰਵਰ ਸ਼ੁਰੂ ਕਰਨ ਦੀ ਬਜਾਏ ਉਸ ਐਂਡਪੌਇੰਟ ਨੂੰ ਦਰਸਾਉਂਦੇ ਹੋ ਜਿੱਥੇ ਕਨੈਕਸ਼ਨ ਸਥਾਪਿਤ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ। ਹੇਠਾਂ ਉਦਾਹਰਨ ਦੇਖੋ:

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

- ਇੱਕ ASGI ਸਰਵਰ ਦਾ ਇੰਸਟੈਂਸ ਬਣਾਇਆ ਹੈ (ਖਾਸ ਕਰਕੇ Starlette ਦੀ ਵਰਤੋਂ ਕਰਕੇ) ਅਤੇ ਡਿਫਾਲਟ ਰੂਟ `/` ਨੂੰ ਮਾਊਂਟ ਕੀਤਾ ਹੈ।

  ਪਿਛੋਕੜ ਵਿੱਚ ਇਹ ਹੁੰਦਾ ਹੈ ਕਿ `/sse` ਅਤੇ `/messages` ਰੂਟ ਕਨੈਕਸ਼ਨਾਂ ਅਤੇ ਸੁਨੇਹਿਆਂ ਨੂੰ ਸੰਭਾਲਣ ਲਈ ਸੈੱਟ ਕੀਤੇ ਜਾਂਦੇ ਹਨ। ਬਾਕੀ ਐਪ, ਜਿਵੇਂ ਕਿ ਟੂਲਾਂ ਸ਼ਾਮਲ ਕਰਨਾ, stdio ਸਰਵਰਾਂ ਵਾਂਗ ਹੀ ਹੁੰਦਾ ਹੈ।

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

    - `AddMcpServer`, ਇਹ ਮੈਥਡ ਸਮਰੱਥਾਵਾਂ ਜੋੜਦਾ ਹੈ।
    - `MapMcp`, ਇਹ `/SSE` ਅਤੇ `/messages` ਵਰਗੇ ਰੂਟ ਜੋੜਦਾ ਹੈ।

ਹੁਣ ਜਦੋਂ ਕਿ ਅਸੀਂ SSE ਬਾਰੇ ਕੁਝ ਹੋਰ ਜਾਣਕਾਰੀ ਪ੍ਰਾਪਤ ਕਰ ਲਈ ਹੈ, ਆਓ ਇੱਕ SSE ਸਰਵਰ ਬਣਾਈਏ।

## ਅਭਿਆਸ: SSE ਸਰਵਰ ਬਣਾਉਣਾ

ਸਰਵਰ ਬਣਾਉਣ ਲਈ ਸਾਨੂੰ ਦੋ ਗੱਲਾਂ ਦਾ ਧਿਆਨ ਰੱਖਣਾ ਪੈਂਦਾ ਹੈ:

- ਸਾਨੂੰ ਇੱਕ ਵੈੱਬ ਸਰਵਰ ਦੀ ਲੋੜ ਹੈ ਜੋ ਕਨੈਕਸ਼ਨ ਅਤੇ ਸੁਨੇਹਿਆਂ ਲਈ ਐਂਡਪੌਇੰਟ ਖੋਲ੍ਹੇ।
- ਸਾਨੂੰ ਆਪਣਾ ਸਰਵਰ ਉਸੇ ਤਰ੍ਹਾਂ ਬਣਾਉਣਾ ਹੈ ਜਿਵੇਂ ਅਸੀਂ stdio ਵਰਤਦੇ ਸਮੇਂ ਕਰਦੇ ਸੀ, ਟੂਲਾਂ, ਸਰੋਤਾਂ ਅਤੇ ਪ੍ਰਾਂਪਟਾਂ ਨਾਲ।

### -1- ਸਰਵਰ ਇੰਸਟੈਂਸ ਬਣਾਉਣਾ

ਸਰਵਰ ਬਣਾਉਣ ਲਈ ਅਸੀਂ stdio ਵਰਗੇ ਹੀ ਟਾਈਪ ਵਰਤਦੇ ਹਾਂ। ਪਰ ਟ੍ਰਾਂਸਪੋਰਟ ਲਈ ਸਾਨੂੰ SSE ਚੁਣਨਾ ਪੈਂਦਾ ਹੈ।

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

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਇੱਕ ਸਰਵਰ ਇੰਸਟੈਂਸ ਬਣਾਇਆ ਹੈ।
- express ਵੈੱਬ ਫਰੇਮਵਰਕ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਇੱਕ ਐਪ ਪਰਿਭਾਸ਼ਿਤ ਕੀਤਾ ਹੈ।
- ਇੱਕ transports ਵੈਰੀਏਬਲ ਬਣਾਇਆ ਹੈ ਜੋ ਆਉਣ ਵਾਲੀਆਂ ਕਨੈਕਸ਼ਨਾਂ ਨੂੰ ਸਟੋਰ ਕਰੇਗਾ।

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਲਾਇਬ੍ਰੇਰੀਆਂ ਇੰਪੋਰਟ ਕੀਤੀਆਂ ਹਨ, ਜਿਸ ਵਿੱਚ Starlette (ਇੱਕ ASGI ਫਰੇਮਵਰਕ) ਸ਼ਾਮਲ ਹੈ।
- ਇੱਕ MCP ਸਰਵਰ ਇੰਸਟੈਂਸ `mcp` ਬਣਾਇਆ ਹੈ।

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

ਇਸ ਮੋੜ 'ਤੇ ਅਸੀਂ:

- ਇੱਕ ਵੈੱਬ ਐਪ ਬਣਾਇਆ ਹੈ।
- `AddMcpServer` ਰਾਹੀਂ MCP ਫੀਚਰਾਂ ਲਈ ਸਹਾਇਤਾ ਜੋੜੀ ਹੈ।

ਹੁਣ ਅਸੀਂ ਲੋੜੀਂਦੇ ਰੂਟ ਜੋੜੀਏ।

### -2- ਰੂਟ ਜੋੜਨਾ

ਹੁਣ ਅਸੀਂ ਉਹ ਰੂਟ ਜੋੜੀਏ ਜੋ ਕਨੈਕਸ਼ਨ ਅਤੇ ਆਉਣ ਵਾਲੇ ਸੁਨੇਹਿਆਂ ਨੂੰ ਸੰਭਾਲਦੇ ਹਨ:

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

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਇੱਕ `/sse` ਰੂਟ ਪਰਿਭਾਸ਼ਿਤ ਕੀਤਾ ਹੈ ਜੋ SSE ਕਿਸਮ ਦਾ ਟ੍ਰਾਂਸਪੋਰਟ ਬਣਾਉਂਦਾ ਹੈ ਅਤੇ MCP ਸਰਵਰ 'ਤੇ `connect` ਕਾਲ ਕਰਦਾ ਹੈ।
- ਇੱਕ `/messages` ਰੂਟ ਜੋ ਆਉਣ ਵਾਲੇ ਸੁਨੇਹਿਆਂ ਦੀ ਦੇਖਭਾਲ ਕਰਦਾ ਹੈ।

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- Starlette ਫਰੇਮਵਰਕ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਇੱਕ ASGI ਐਪ ਇੰਸਟੈਂਸ ਬਣਾਇਆ ਹੈ। ਇਸ ਵਿੱਚ ਅਸੀਂ `mcp.sse_app()` ਨੂੰ ਰੂਟਾਂ ਦੀ ਸੂਚੀ ਵਿੱਚ ਦਿੱਤਾ ਹੈ। ਇਸ ਨਾਲ `/sse` ਅਤੇ `/messages` ਰੂਟ ਐਪ ਇੰਸਟੈਂਸ 'ਤੇ ਮਾਊਂਟ ਹੋ ਜਾਂਦੇ ਹਨ।

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

ਅਸੀਂ ਅੰਤ ਵਿੱਚ ਇੱਕ ਲਾਈਨ ਕੋਡ ਜੋੜੀ ਹੈ `add.MapMcp()` ਜਿਸਦਾ ਮਤਲਬ ਹੁੰਦਾ ਹੈ ਕਿ ਹੁਣ ਸਾਡੇ ਕੋਲ `/SSE` ਅਤੇ `/messages` ਰੂਟ ਹਨ।

ਹੁਣ ਸਰਵਰ ਵਿੱਚ ਸਮਰੱਥਾਵਾਂ ਜੋੜੀਏ।

### -3- ਸਰਵਰ ਸਮਰੱਥਾਵਾਂ ਜੋੜਨਾ

ਹੁਣ ਜਦੋਂ ਕਿ ਸਾਰੇ SSE ਵਿਸ਼ੇਸ਼ ਤੱਤ ਪਰਿਭਾਸ਼ਿਤ ਹੋ ਗਏ ਹਨ, ਆਓ ਸਰਵਰ ਵਿੱਚ ਟੂਲ, ਪ੍ਰਾਂਪਟ ਅਤੇ ਸਰੋਤ ਵਰਗੀਆਂ ਸਮਰੱਥਾਵਾਂ ਜੋੜੀਏ।

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

ਇਹ ਉਦਾਹਰਨ ਹੈ ਕਿ ਤੁਸੀਂ ਕਿਸ ਤਰ੍ਹਾਂ ਇੱਕ ਟੂਲ ਜੋੜ ਸਕਦੇ ਹੋ। ਇਹ ਖਾਸ ਟੂਲ "random-joke" ਨਾਂ ਦਾ ਟੂਲ ਬਣਾਉਂਦਾ ਹੈ ਜੋ Chuck Norris API ਨੂੰ ਕਾਲ ਕਰਦਾ ਹੈ ਅਤੇ JSON ਜਵਾਬ ਵਾਪਸ ਕਰਦਾ ਹੈ।

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

ਹੁਣ ਤੁਹਾਡੇ ਸਰਵਰ ਕੋਲ ਇੱਕ ਟੂਲ ਹੈ।

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

1. ਪਹਿਲਾਂ ਕੁਝ ਟੂਲ ਬਣਾਈਏ, ਇਸ ਲਈ ਅਸੀਂ ਇੱਕ ਫਾਇਲ *Tools.cs* ਬਣਾਵਾਂਗੇ ਜਿਸ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤਾ ਸਮੱਗਰੀ ਹੋਵੇਗੀ:

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

  ਇੱਥੇ ਅਸੀਂ ਇਹ ਜੋੜਿਆ ਹੈ:

  - `Tools` ਕਲਾਸ ਬਣਾਈ ਹੈ ਜਿਸ 'ਤੇ `McpServerToolType` ਡੈਕੋਰੇਟਰ ਲਗਾਇਆ ਹੈ।
  - `AddNumbers` ਨਾਂ ਦਾ ਟੂਲ ਬਣਾਇਆ ਹੈ ਜਿਸ ਮੈਥਡ ਨੂੰ `McpServerTool` ਨਾਲ ਡੈਕੋਰੇਟ ਕੀਤਾ ਹੈ। ਅਸੀਂ ਪੈਰਾਮੀਟਰ ਅਤੇ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਵੀ ਦਿੱਤੀ ਹੈ।

1. ਹੁਣ ਅਸੀਂ `Tools` ਕਲਾਸ ਦੀ ਵਰਤੋਂ ਕਰੀਏ:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  ਅਸੀਂ `WithTools` ਕਾਲ ਜੋੜੀ ਹੈ ਜੋ ਦੱਸਦੀ ਹੈ ਕਿ `Tools` ਉਹ ਕਲਾਸ ਹੈ ਜਿਸ ਵਿੱਚ ਟੂਲ ਹਨ। ਬਸ, ਹੁਣ ਅਸੀਂ ਤਿਆਰ ਹਾਂ।

ਵਧੀਆ, ਸਾਡੇ ਕੋਲ SSE ਵਰਤਦਾ ਇੱਕ ਸਰਵਰ ਹੈ, ਆਓ ਹੁਣ ਇਸਨੂੰ ਚਲਾਈਏ।

## ਅਭਿਆਸ: Inspector ਨਾਲ SSE ਸਰਵਰ ਡੀਬੱਗ ਕਰਨਾ

Inspector ਇੱਕ ਵਧੀਆ ਟੂਲ ਹੈ ਜੋ ਅਸੀਂ ਪਹਿਲਾਂ ਦੇ ਪਾਠ [Creating your first server](/03-GettingStarted/01-first-server/README.md) ਵਿੱਚ ਵੇਖਿਆ ਸੀ। ਆਓ ਵੇਖੀਏ ਕਿ ਕੀ ਅਸੀਂ ਇੱਥੇ ਵੀ Inspector ਦੀ ਵਰਤੋਂ ਕਰ ਸਕਦੇ ਹਾਂ:

### -1- Inspector ਚਲਾਉਣਾ

Inspector ਚਲਾਉਣ ਲਈ, ਤੁਹਾਡੇ ਕੋਲ ਪਹਿਲਾਂ ਇੱਕ SSE ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ, ਤਾਂ ਆਓ ਪਹਿਲਾਂ ਉਹ ਕਰੀਏ:

1. ਸਰਵਰ ਚਲਾਓ

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    ਧਿਆਨ ਦਿਓ ਕਿ ਅਸੀਂ `uvicorn` ਐਗਜ਼ਿਕਿਊਟੇਬਲ ਦੀ ਵਰਤੋਂ ਕਰ ਰਹੇ ਹਾਂ ਜੋ `pip install "mcp[cli]"` ਟਾਈਪ ਕਰਨ 'ਤੇ ਇੰਸਟਾਲ ਹੁੰਦਾ ਹੈ। `server:app` ਟਾਈਪ ਕਰਨ ਦਾ ਮਤਲਬ ਹੈ ਕਿ ਅਸੀਂ `server.py` ਫਾਇਲ ਚਲਾ ਰਹੇ ਹਾਂ ਜਿਸ ਵਿੱਚ ਇੱਕ Starlette ਇੰਸਟੈਂਸ `app` ਨਾਂ ਦਾ ਹੈ।

    ### .NET

    ```sh
    dotnet run
    ```

    ਇਹ ਸਰਵਰ ਸ਼ੁਰੂ ਕਰ ਦੇਵੇਗਾ। ਇਸ ਨਾਲ ਇੰਟਰਫੇਸ ਕਰਨ ਲਈ ਤੁਹਾਨੂੰ ਇੱਕ ਨਵਾਂ ਟਰਮੀਨਲ ਖੋਲ੍ਹਣਾ ਪਵੇਗਾ।

1. Inspector ਚਲਾਓ

    > ![NOTE]
    > ਇਸਨੂੰ ਉਸੇ ਟਰਮੀਨਲ ਤੋਂ ਵੱਖਰੇ ਟਰਮੀਨਲ ਵਿੰਡੋ ਵਿੱਚ ਚਲਾਓ ਜਿੱਥੇ ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੈ। ਨਾਲ ਹੀ ਧਿਆਨ ਦਿਓ ਕਿ ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਤੁਹਾਡੇ ਸਰਵਰ ਦੇ URL ਅਨੁਸਾਰ ਬਦਲਣਾ ਪਵੇਗਾ।

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspector ਚਲਾਉਣਾ ਸਾਰੇ ਰਨਟਾਈਮਾਂ ਵਿੱਚ ਇੱਕੋ ਜਿਹਾ ਹੈ। ਧਿਆਨ ਦਿਓ ਕਿ ਅਸੀਂ ਸਰਵਰ ਚਲਾਉਣ ਲਈ ਪਾਥ ਦੇਣ ਦੀ ਬਜਾਏ ਉਸ URL ਨੂੰ ਦਿੰਦੇ ਹਾਂ ਜਿੱਥੇ ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੈ ਅਤੇ `/sse` ਰੂਟ ਵੀ ਦਰਸਾਉਂਦੇ ਹਾਂ।

### -2- ਟੂਲ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰਨਾ

ਡ੍ਰੌਪਲਿਸਟ ਵਿੱਚੋਂ SSE ਚੁਣੋ ਅਤੇ ਉਸ URL ਨੂੰ ਭਰੋ ਜਿੱਥੇ ਤੁਹਾਡਾ ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੈ, ਉਦਾਹਰਨ ਵਜੋਂ http:localhost:4321/sse। ਹੁਣ "Connect" ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ। ਪਹਿਲਾਂ ਵਾਂਗ, ਟੂਲਾਂ ਦੀ ਸੂਚੀ ਦਿਖਾਓ, ਇੱਕ ਟੂਲ ਚੁਣੋ ਅਤੇ ਇਨਪੁੱਟ ਮੁੱਲ ਦਿਓ। ਤੁਹਾਨੂੰ ਹੇਠਾਂ ਦਿੱਤੇ ਨਤੀਜੇ ਵਰਗਾ ਕੁਝ ਵੇਖਣ ਨੂੰ ਮਿਲੇਗਾ:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.pa.png)

ਵਧੀਆ, ਤੁਸੀਂ Inspector ਨਾਲ ਕੰਮ ਕਰ ਸਕਦੇ ਹੋ, ਆਓ ਹੁਣ ਵੇਖੀਏ ਕਿ Visual Studio Code ਨਾਲ ਕਿਵੇਂ ਕੰਮ ਕਰਨਾ ਹੈ।

## ਅਸਾਈਨਮੈਂਟ

ਆਪਣੇ ਸਰਵਰ ਵਿੱਚ ਹੋਰ ਸਮਰੱਥਾਵਾਂ ਜੋੜਨ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ। ਉਦਾਹਰਨ ਵਜੋਂ, [ਇਸ ਪੰਨੇ](https://api.chucknorris.io/) ਨੂੰ ਵੇਖੋ ਜਿੱਥੇ ਤੁਸੀਂ ਇੱਕ ਐਸਾ ਟੂਲ ਜੋੜ ਸਕਦੇ ਹੋ ਜੋ API ਕਾਲ ਕਰਦਾ ਹੈ। ਤੁਸੀਂ ਫੈਸਲਾ ਕਰੋ ਕਿ ਸਰਵਰ ਕਿਵੇਂ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਜ਼ੇ ਕਰੋ :)

## ਹੱਲ

[Solution](./solution/README.md) ਇੱਥੇ ਇੱਕ ਸੰਭਵ ਹੱਲ ਹੈ ਜਿਸ ਵਿੱਚ ਕੰਮ ਕਰਦਾ ਕੋਡ ਹੈ।

## ਮੁੱਖ ਗੱਲਾਂ

ਇਸ ਅਧਿਆਇ ਤੋਂ ਮੁੱਖ ਗੱਲਾਂ ਇਹ ਹਨ:

- SSE stdio ਦੇ ਬਾਅਦ ਦੂਜਾ ਸਮਰਥਿਤ ਟ੍ਰਾਂਸਪੋਰਟ ਹੈ।
- SSE ਨੂੰ ਸਮਰਥਿਤ ਕਰਨ ਲਈ, ਤੁਹਾਨੂੰ ਆਉਣ ਵਾਲੀਆਂ ਕਨੈਕਸ਼ਨਾਂ ਅਤੇ ਸੁਨੇਹਿਆਂ ਨੂੰ ਵੈੱਬ ਫਰੇਮਵਰਕ ਰਾਹੀਂ ਸੰਭਾਲਣਾ ਪੈਂਦਾ ਹੈ।
- ਤੁਸੀਂ Inspector ਅਤੇ Visual Studio Code ਦੋਹਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ SSE ਸਰਵਰ ਨੂੰ ਕਨਜ਼ਿਊਮ ਕਰ ਸਕਦੇ ਹੋ, ਬਿਲਕੁਲ stdio ਸਰਵਰਾਂ ਵਾਂਗ। ਧਿਆਨ ਦਿਓ ਕਿ stdio ਅਤੇ SSE ਵਿੱਚ ਕੁਝ ਫਰਕ ਹਨ। SSE ਲਈ, ਤੁਹਾਨੂੰ ਸਰਵਰ ਨੂੰ ਅਲੱਗ ਚਲਾਉਣਾ ਪੈਂਦਾ ਹੈ ਅਤੇ ਫਿਰ Inspector ਟੂਲ ਚਲਾਉਣਾ ਪੈਂਦਾ ਹੈ। Inspector ਟੂਲ ਲਈ ਵੀ ਕੁਝ ਫਰਕ ਹਨ, ਜਿਵੇਂ ਕਿ ਤੁਹਾਨੂੰ URL ਦਰਸਾਉਣਾ ਪੈਂਦਾ ਹੈ।

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