<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:29:29+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "pa"
}
-->
# ਐਮਸੀਪੀ ਸਰਵਰ stdio ਟ੍ਰਾਂਸਪੋਰਟ ਨਾਲ

> **⚠️ ਮਹੱਤਵਪੂਰਨ ਅੱਪਡੇਟ**: ਐਮਸੀਪੀ ਸਪੈਸਿਫਿਕੇਸ਼ਨ 2025-06-18 ਦੇ ਤਹਿਤ, ਅਲੱਗ SSE (ਸਰਵਰ-ਸੈਂਟ ਇਵੈਂਟਸ) ਟ੍ਰਾਂਸਪੋਰਟ ਨੂੰ **ਡਿਪ੍ਰੀਕੇਟ** ਕਰ ਦਿੱਤਾ ਗਿਆ ਹੈ ਅਤੇ "Streamable HTTP" ਟ੍ਰਾਂਸਪੋਰਟ ਨਾਲ ਬਦਲ ਦਿੱਤਾ ਗਿਆ ਹੈ। ਮੌਜੂਦਾ ਐਮਸੀਪੀ ਸਪੈਸਿਫਿਕੇਸ਼ਨ ਦੋ ਮੁੱਖ ਟ੍ਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮਾਂ ਨੂੰ ਪਰਿਭਾਸ਼ਿਤ ਕਰਦਾ ਹੈ:
> 1. **stdio** - ਸਟੈਂਡਰਡ ਇਨਪੁਟ/ਆਉਟਪੁੱਟ (ਸਥਾਨਕ ਸਰਵਰਾਂ ਲਈ ਸਿਫਾਰਸ਼ੀ)
> 2. **Streamable HTTP** - ਦੂਰ-ਦਰਾਜ ਦੇ ਸਰਵਰਾਂ ਲਈ ਜੋ ਅੰਦਰੂਨੀ ਤੌਰ 'ਤੇ SSE ਵਰਤ ਸਕਦੇ ਹਨ
>
> ਇਸ ਪਾਠ ਨੂੰ **stdio ਟ੍ਰਾਂਸਪੋਰਟ** 'ਤੇ ਧਿਆਨ ਕੇਂਦਰਿਤ ਕਰਨ ਲਈ ਅੱਪਡੇਟ ਕੀਤਾ ਗਿਆ ਹੈ, ਜੋ ਕਿ ਜ਼ਿਆਦਾਤਰ ਐਮਸੀਪੀ ਸਰਵਰ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਲਈ ਸਿਫਾਰਸ਼ੀ ਪਹੁੰਚ ਹੈ।

stdio ਟ੍ਰਾਂਸਪੋਰਟ ਐਮਸੀਪੀ ਸਰਵਰਾਂ ਨੂੰ ਸਟੈਂਡਰਡ ਇਨਪੁਟ ਅਤੇ ਆਉਟਪੁੱਟ ਸਟ੍ਰੀਮਾਂ ਰਾਹੀਂ ਕਲਾਇੰਟਾਂ ਨਾਲ ਸੰਚਾਰ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਇਹ ਮੌਜੂਦਾ ਐਮਸੀਪੀ ਸਪੈਸਿਫਿਕੇਸ਼ਨ ਵਿੱਚ ਸਭ ਤੋਂ ਆਮ ਅਤੇ ਸਿਫਾਰਸ਼ੀ ਟ੍ਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ ਹੈ, ਜੋ ਐਮਸੀਪੀ ਸਰਵਰਾਂ ਨੂੰ ਬਣਾਉਣ ਦਾ ਇੱਕ ਸਧਾਰਨ ਅਤੇ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਤਰੀਕਾ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ ਜੋ ਵੱਖ-ਵੱਖ ਕਲਾਇੰਟ ਐਪਲੀਕੇਸ਼ਨਾਂ ਨਾਲ ਆਸਾਨੀ ਨਾਲ ਇੰਟੀਗਰੇਟ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ।

## ਝਲਕ

ਇਹ ਪਾਠ stdio ਟ੍ਰਾਂਸਪੋਰਟ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਐਮਸੀਪੀ ਸਰਵਰਾਂ ਨੂੰ ਬਣਾਉਣ ਅਤੇ ਉਪਭੋਗ ਕਰਨ ਦੇ ਤਰੀਕੇ ਨੂੰ ਕਵਰ ਕਰਦਾ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਇਹ ਕਰਨ ਦੇ ਯੋਗ ਹੋਵੋਗੇ:

- stdio ਟ੍ਰਾਂਸਪੋਰਟ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਐਮਸੀਪੀ ਸਰਵਰ ਬਣਾਉਣਾ।
- ਇੰਸਪੈਕਟਰ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਐਮਸੀਪੀ ਸਰਵਰ ਨੂੰ ਡੀਬੱਗ ਕਰਨਾ।
- Visual Studio Code ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਐਮਸੀਪੀ ਸਰਵਰ ਨੂੰ ਉਪਭੋਗ ਕਰਨਾ।
- ਮੌਜੂਦਾ ਐਮਸੀਪੀ ਟ੍ਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮਾਂ ਨੂੰ ਸਮਝਣਾ ਅਤੇ stdio ਦੀ ਸਿਫਾਰਸ਼ ਕਿਉਂ ਕੀਤੀ ਜਾਂਦੀ ਹੈ।

## stdio ਟ੍ਰਾਂਸਪੋਰਟ - ਇਹ ਕਿਵੇਂ ਕੰਮ ਕਰਦਾ ਹੈ

stdio ਟ੍ਰਾਂਸਪੋਰਟ ਮੌਜੂਦਾ ਐਮਸੀਪੀ ਸਪੈਸਿਫਿਕੇਸ਼ਨ (2025-06-18) ਵਿੱਚ ਸਮਰਥਿਤ ਦੋ ਟ੍ਰਾਂਸਪੋਰਟ ਕਿਸਮਾਂ ਵਿੱਚੋਂ ਇੱਕ ਹੈ। ਇਹ ਇਸ ਤਰੀਕੇ ਨਾਲ ਕੰਮ ਕਰਦਾ ਹੈ:

- **ਸਧਾਰਨ ਸੰਚਾਰ**: ਸਰਵਰ ਸਟੈਂਡਰਡ ਇਨਪੁਟ (`stdin`) ਤੋਂ JSON-RPC ਸੁਨੇਹੇ ਪੜ੍ਹਦਾ ਹੈ ਅਤੇ ਸਟੈਂਡਰਡ ਆਉਟਪੁੱਟ (`stdout`) ਨੂੰ ਸੁਨੇਹੇ ਭੇਜਦਾ ਹੈ।
- **ਪ੍ਰੋਸੈਸ-ਅਧਾਰਿਤ**: ਕਲਾਇੰਟ ਐਮਸੀਪੀ ਸਰਵਰ ਨੂੰ ਇੱਕ ਸਬਪ੍ਰੋਸੈਸ ਵਜੋਂ ਲਾਂਚ ਕਰਦਾ ਹੈ।
- **ਸੁਨੇਹਾ ਫਾਰਮੈਟ**: ਸੁਨੇਹੇ ਵਿਅਕਤੀਗਤ JSON-RPC ਬੇਨਤੀ, ਸੂਚਨਾਵਾਂ ਜਾਂ ਜਵਾਬ ਹੁੰਦੇ ਹਨ, ਜੋ ਨਵੀਂ ਲਾਈਨਾਂ ਦੁਆਰਾ ਵੱਖਰੇ ਕੀਤੇ ਜਾਂਦੇ ਹਨ।
- **ਲੌਗਿੰਗ**: ਸਰਵਰ ਲੌਗਿੰਗ ਦੇ ਉਦੇਸ਼ਾਂ ਲਈ ਸਟੈਂਡਰਡ ਐਰਰ (`stderr`) 'ਤੇ UTF-8 ਸਟ੍ਰਿੰਗਾਂ ਲਿਖ ਸਕਦਾ ਹੈ।

### ਮੁੱਖ ਜ਼ਰੂਰਤਾਂ:
- ਸੁਨੇਹੇ ਨਵੀਂ ਲਾਈਨਾਂ ਦੁਆਰਾ ਵੱਖਰੇ ਕੀਤੇ ਜਾਣੇ ਚਾਹੀਦੇ ਹਨ ਅਤੇ ਉਨ੍ਹਾਂ ਵਿੱਚ ਸਮਰਪਿਤ ਨਵੀਂ ਲਾਈਨਾਂ ਨਹੀਂ ਹੋਣੀਆਂ ਚਾਹੀਦੀਆਂ।
- ਸਰਵਰ `stdout` 'ਤੇ ਕੁਝ ਵੀ ਨਹੀਂ ਲਿਖੇਗਾ ਜੋ ਇੱਕ ਵੈਧ ਐਮਸੀਪੀ ਸੁਨੇਹਾ ਨਹੀਂ ਹੈ।
- ਕਲਾਇੰਟ ਸਰਵਰ ਦੇ `stdin` 'ਤੇ ਕੁਝ ਵੀ ਨਹੀਂ ਲਿਖੇਗਾ ਜੋ ਇੱਕ ਵੈਧ ਐਮਸੀਪੀ ਸੁਨੇਹਾ ਨਹੀਂ ਹੈ।

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ:

- ਅਸੀਂ ਐਮਸੀਪੀ SDK ਤੋਂ `Server` ਕਲਾਸ ਅਤੇ `StdioServerTransport` ਨੂੰ ਇੰਪੋਰਟ ਕਰਦੇ ਹਾਂ।
- ਅਸੀਂ ਬੁਨਿਆਦੀ ਸੰਰਚਨਾ ਅਤੇ ਸਮਰੱਥਾਵਾਂ ਨਾਲ ਇੱਕ ਸਰਵਰ ਇੰਸਟੈਂਸ ਬਣਾਉਂਦੇ ਹਾਂ।

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਐਮਸੀਪੀ SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਇੱਕ ਸਰਵਰ ਇੰਸਟੈਂਸ ਬਣਾਉਂਦੇ ਹਾਂ।
- ਡੈਕੋਰੇਟਰਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਟੂਲ ਪਰਿਭਾਸ਼ਿਤ ਕਰਦੇ ਹਾਂ।
- stdio_server ਕਾਂਟੈਕਸਟ ਮੈਨੇਜਰ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਟ੍ਰਾਂਸਪੋਰਟ ਨੂੰ ਸੰਭਾਲਦੇ ਹਾਂ।

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

SSE ਨਾਲ ਮੁੱਖ ਅੰਤਰ ਇਹ ਹੈ ਕਿ stdio ਸਰਵਰ:

- ਵੈੱਬ ਸਰਵਰ ਸੈਟਅਪ ਜਾਂ HTTP ਐਂਡਪੋਇੰਟ ਦੀ ਲੋੜ ਨਹੀਂ ਹੈ।
- ਕਲਾਇੰਟ ਦੁਆਰਾ ਸਬਪ੍ਰੋਸੈਸ ਵਜੋਂ ਲਾਂਚ ਕੀਤੇ ਜਾਂਦੇ ਹਨ।
- stdin/stdout ਸਟ੍ਰੀਮਾਂ ਰਾਹੀਂ ਸੰਚਾਰ ਕਰਦੇ ਹਨ।
- ਲਾਗੂ ਕਰਨ ਅਤੇ ਡੀਬੱਗ ਕਰਨ ਲਈ ਸਧਾਰਨ ਹਨ।

## ਅਭਿਆਸ: stdio ਸਰਵਰ ਬਣਾਉਣਾ

ਸਾਡਾ ਸਰਵਰ ਬਣਾਉਣ ਲਈ, ਸਾਨੂੰ ਦੋ ਗੱਲਾਂ ਦਾ ਧਿਆਨ ਰੱਖਣਾ ਪਵੇਗਾ:

- ਸਾਨੂੰ ਕਨੈਕਸ਼ਨ ਅਤੇ ਸੁਨੇਹਿਆਂ ਲਈ ਐਂਡਪੋਇੰਟਸ ਨੂੰ ਉਜਾਗਰ ਕਰਨ ਲਈ ਇੱਕ ਵੈੱਬ ਸਰਵਰ ਦੀ ਲੋੜ ਹੈ।

## ਲੈਬ: ਇੱਕ ਸਧਾਰਨ ਐਮਸੀਪੀ stdio ਸਰਵਰ ਬਣਾਉਣਾ

ਇਸ ਲੈਬ ਵਿੱਚ, ਅਸੀਂ stdio ਟ੍ਰਾਂਸਪੋਰਟ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਇੱਕ ਸਧਾਰਨ ਐਮਸੀਪੀ ਸਰਵਰ ਬਣਾਵਾਂਗੇ। ਇਹ ਸਰਵਰ ਉਹ ਟੂਲ ਉਜਾਗਰ ਕਰੇਗਾ ਜੋ ਕਲਾਇੰਟ ਸਟੈਂਡਰਡ ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕੋਲ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕਾਲ ਕਰ ਸਕਦੇ ਹਨ।

### ਪੂਰਵ ਸ਼ਰਤਾਂ

- Python 3.8 ਜਾਂ ਇਸ ਤੋਂ ਉੱਚਾ
- ਐਮਸੀਪੀ ਪਾਈਥਨ SDK: `pip install mcp`
- async ਪ੍ਰੋਗਰਾਮਿੰਗ ਦੀ ਬੁਨਿਆਦੀ ਸਮਝ

ਆਓ ਆਪਣਾ ਪਹਿਲਾ ਐਮਸੀਪੀ stdio ਸਰਵਰ ਬਣਾਉਣਾ ਸ਼ੁਰੂ ਕਰੀਏ:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## ਡਿਪ੍ਰੀਕੇਟ ਕੀਤੇ SSE ਪਹੁੰਚ ਤੋਂ ਮੁੱਖ ਅੰਤਰ

**Stdio ਟ੍ਰਾਂਸਪੋਰਟ (ਮੌਜੂਦਾ ਮਿਆਰ):**
- ਸਧਾਰਨ ਸਬਪ੍ਰੋਸੈਸ ਮਾਡਲ - ਕਲਾਇੰਟ ਸਰਵਰ ਨੂੰ ਚਾਈਲਡ ਪ੍ਰੋਸੈਸ ਵਜੋਂ ਲਾਂਚ ਕਰਦਾ ਹੈ।
- stdin/stdout ਰਾਹੀਂ JSON-RPC ਸੁਨੇਹਿਆਂ ਦੁਆਰਾ ਸੰਚਾਰ।
- HTTP ਸਰਵਰ ਸੈਟਅਪ ਦੀ ਲੋੜ ਨਹੀਂ।
- ਬਿਹਤਰ ਪ੍ਰਦਰਸ਼ਨ ਅਤੇ ਸੁਰੱਖਿਆ।
- ਡੀਬੱਗਿੰਗ ਅਤੇ ਵਿਕਾਸ ਲਈ ਆਸਾਨ।

**SSE ਟ੍ਰਾਂਸਪੋਰਟ (ਐਮਸੀਪੀ 2025-06-18 ਦੇ ਤਹਿਤ ਡਿਪ੍ਰੀਕੇਟ):**
- HTTP ਸਰਵਰ ਨਾਲ SSE ਐਂਡਪੋਇੰਟਸ ਦੀ ਲੋੜ ਸੀ।
- ਵੈੱਬ ਸਰਵਰ ਇੰਫਰਾਸਟਰਕਚਰ ਨਾਲ ਜਟਿਲ ਸੈਟਅਪ।
- HTTP ਐਂਡਪੋਇੰਟਸ ਲਈ ਵਾਧੂ ਸੁਰੱਖਿਆ ਵਿਚਾਰ।
- ਹੁਣ ਵੈੱਬ-ਅਧਾਰਿਤ ਸਥਿਤੀਆਂ ਲਈ Streamable HTTP ਨਾਲ ਬਦਲ ਦਿੱਤਾ ਗਿਆ।

### stdio ਟ੍ਰਾਂਸਪੋਰਟ ਨਾਲ ਸਰਵਰ ਬਣਾਉਣਾ

stdio ਸਰਵਰ ਬਣਾਉਣ ਲਈ, ਸਾਨੂੰ ਇਹ ਕਰਨ ਦੀ ਲੋੜ ਹੈ:

1. **ਲੋੜੀਂਦੇ ਲਾਇਬ੍ਰੇਰੀਆਂ ਇੰਪੋਰਟ ਕਰੋ** - ਸਾਨੂੰ ਐਮਸੀਪੀ ਸਰਵਰ ਕੰਪੋਨੈਂਟਸ ਅਤੇ stdio ਟ੍ਰਾਂਸਪੋਰਟ ਦੀ ਲੋੜ ਹੈ।
2. **ਸਰਵਰ ਇੰਸਟੈਂਸ ਬਣਾਓ** - ਸਰਵਰ ਨੂੰ ਇਸ ਦੀ ਸਮਰੱਥਾਵਾਂ ਨਾਲ ਪਰਿਭਾਸ਼ਿਤ ਕਰੋ।
3. **ਟੂਲ ਪਰਿਭਾਸ਼ਿਤ ਕਰੋ** - ਉਹ ਕਾਰਜਸ਼ੀਲਤਾ ਸ਼ਾਮਲ ਕਰੋ ਜੋ ਅਸੀਂ ਉਜਾਗਰ ਕਰਨਾ ਚਾਹੁੰਦੇ ਹਾਂ।
4. **ਟ੍ਰਾਂਸਪੋਰਟ ਸੈਟਅਪ ਕਰੋ** - stdio ਸੰਚਾਰ ਨੂੰ ਸੰਰਚਿਤ ਕਰੋ।
5. **ਸਰਵਰ ਚਲਾਓ** - ਸਰਵਰ ਸ਼ੁਰੂ ਕਰੋ ਅਤੇ ਸੁਨੇਹਿਆਂ ਨੂੰ ਸੰਭਾਲੋ।

ਆਓ ਇਸਨੂੰ ਕਦਮ-ਦਰ-ਕਦਮ ਬਣਾਈਏ:

### ਕਦਮ 1: ਇੱਕ ਬੁਨਿਆਦੀ stdio ਸਰਵਰ ਬਣਾਓ

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### ਕਦਮ 2: ਹੋਰ ਟੂਲ ਸ਼ਾਮਲ ਕਰੋ

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### ਕਦਮ 3: ਸਰਵਰ ਚਲਾਉਣਾ

ਕੋਡ ਨੂੰ `server.py` ਵਜੋਂ ਸੇਵ ਕਰੋ ਅਤੇ ਕਮਾਂਡ ਲਾਈਨ ਤੋਂ ਚਲਾਓ:

```bash
python server.py
```

ਸਰਵਰ ਸ਼ੁਰੂ ਹੋਵੇਗਾ ਅਤੇ stdin ਤੋਂ ਇਨਪੁਟ ਦੀ ਉਡੀਕ ਕਰੇਗਾ। ਇਹ stdio ਟ੍ਰਾਂਸਪੋਰਟ ਰਾਹੀਂ JSON-RPC ਸੁਨੇਹਿਆਂ ਨਾਲ ਸੰਚਾਰ ਕਰਦਾ ਹੈ।

### ਕਦਮ 4: ਇੰਸਪੈਕਟਰ ਨਾਲ ਟੈਸਟਿੰਗ

ਤੁਸੀਂ ਆਪਣੇ ਸਰਵਰ ਨੂੰ ਐਮਸੀਪੀ ਇੰਸਪੈਕਟਰ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਟੈਸਟ ਕਰ ਸਕਦੇ ਹੋ:

1. ਇੰਸਪੈਕਟਰ ਇੰਸਟਾਲ ਕਰੋ: `npx @modelcontextprotocol/inspector`
2. ਇੰਸਪੈਕਟਰ ਚਲਾਓ ਅਤੇ ਇਸਨੂੰ ਆਪਣੇ ਸਰਵਰ ਵੱਲ ਪੋਇੰਟ ਕਰੋ।
3. ਉਹ ਟੂਲ ਟੈਸਟ ਕਰੋ ਜੋ ਤੁਸੀਂ ਬਣਾਏ ਹਨ।

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// Add tools
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Get a personalized greeting",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Name of the person to greet",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `Hello, ${request.params.arguments?.name}! Welcome to MCP stdio server.`,
        },
      ],
    };
  } else {
    throw new Error(`Unknown tool: ${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("Get a personalized greeting")]
    public string GetGreeting(string name)
    {
        return $"Hello, {name}! Welcome to MCP stdio server.";
    }

    [Description("Calculate the sum of two numbers")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. ਪਹਿਲਾਂ ਕੁਝ ਟੂਲ ਬਣਾਉਣ ਲਈ, ਅਸੀਂ *Tools.cs* ਫਾਈਲ ਬਣਾਵਾਂਗੇ ਜਿਸ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤਾ ਸਮੱਗਰੀ ਹੋਵੇਗਾ:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **ਵੈੱਬ ਇੰਟਰਫੇਸ ਖੋਲ੍ਹੋ**: ਇੰਸਪੈਕਟਰ ਇੱਕ ਬ੍ਰਾਊਜ਼ਰ ਵਿੰਡੋ ਖੋਲ੍ਹੇਗਾ ਜੋ ਤੁਹਾਡੇ ਸਰਵਰ ਦੀ ਸਮਰੱਥਾਵਾਂ ਦਿਖਾਉਂਦਾ ਹੈ।

3. **ਟੂਲ ਟੈਸਟ ਕਰੋ**: 
   - ਵੱਖ-ਵੱਖ ਨਾਮਾਂ ਨਾਲ `get_greeting` ਟੂਲ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ।
   - ਵੱਖ-ਵੱਖ ਨੰਬਰਾਂ ਨਾਲ `calculate_sum` ਟੂਲ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ।
   - ਸਰਵਰ ਮੈਟਾਡੇਟਾ ਦੇਖਣ ਲਈ `get_server_info` ਟੂਲ ਨੂੰ ਕਾਲ ਕਰੋ।

4. **ਸੰਚਾਰ ਦੀ ਨਿਗਰਾਨੀ ਕਰੋ**: ਇੰਸਪੈਕਟਰ JSON-RPC ਸੁਨੇਹਿਆਂ ਨੂੰ ਦਿਖਾਉਂਦਾ ਹੈ ਜੋ ਕਲਾਇੰਟ ਅਤੇ ਸਰਵਰ ਦੇ ਵਿਚਕਾਰ ਅਦਲ-ਬਦਲ ਕੀਤੇ ਜਾ ਰਹੇ ਹਨ।

### ਤੁਸੀਂ ਕੀ ਦੇਖੋਗੇ

ਜਦੋਂ ਤੁਹਾਡਾ ਸਰਵਰ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਸ਼ੁਰੂ ਹੁੰਦਾ ਹੈ, ਤਾਂ ਤੁਸੀਂ ਇਹ ਦੇਖੋਗੇ:
- ਇੰਸਪੈਕਟਰ ਵਿੱਚ ਸਰਵਰ ਦੀ ਸਮਰੱਥਾਵਾਂ ਦੀ ਸੂਚੀ।
- ਟੈਸਟ ਕਰਨ ਲਈ ਉਪਲਬਧ ਟੂਲ।
- ਸਫਲ JSON-RPC ਸੁਨੇਹਾ ਅਦਲ-ਬਦਲ।
- ਇੰਟਰਫੇਸ ਵਿੱਚ ਟੂਲ ਜਵਾਬ ਦਿਖਾਏ ਗਏ।

### ਆਮ ਸਮੱਸਿਆਵਾਂ ਅਤੇ ਹੱਲ

**ਸਰਵਰ ਸ਼ੁਰੂ ਨਹੀਂ ਹੋ ਰਿਹਾ:**
- ਸਾਰੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕੀਤੇ ਗਏ ਹਨ ਜਾਂ ਨਹੀਂ: `pip install mcp`।
- Python ਸਿੰਟੈਕਸ ਅਤੇ ਇੰਡੈਂਟੇਸ਼ਨ ਦੀ ਜਾਂਚ ਕਰੋ।
- ਕਨਸੋਲ ਵਿੱਚ ਐਰਰ ਸੁਨੇਹਿਆਂ ਦੀ ਜਾਂਚ ਕਰੋ।

**ਟੂਲ ਦਿਖਾਈ ਨਹੀਂ ਦੇ ਰਹੇ:**
- ਯਕੀਨੀ ਬਣਾਓ ਕਿ `@server.tool()` ਡੈਕੋਰੇਟਰ ਮੌਜੂਦ ਹਨ।
- ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਟੂਲ ਫੰਕਸ਼ਨ `main()` ਤੋਂ ਪਹਿਲਾਂ ਪਰਿਭਾਸ਼ਿਤ ਕੀਤੇ ਗਏ ਹਨ।
- ਸਰਵਰ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਸੰਰਚਿਤ ਹੈ ਜਾਂ ਨਹੀਂ ਦੀ ਜਾਂਚ ਕਰੋ।

**ਕਨੈਕਸ਼ਨ ਸਮੱਸਿਆਵਾਂ:**
- ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਸਰਵਰ stdio ਟ੍ਰਾਂਸਪੋਰਟ ਨੂੰ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਵਰਤ ਰਿਹਾ ਹੈ।
- ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਹੋਰ ਪ੍ਰੋਸੈਸੇਜ਼ ਦਖਲ ਨਹੀਂ ਦੇ ਰਹੇ।
- ਇੰਸਪੈਕਟਰ ਕਮਾਂਡ ਸਿੰਟੈਕਸ ਦੀ ਜਾਂਚ ਕਰੋ।

## ਅਸਾਈਨਮੈਂਟ

ਆਪਣੇ ਸਰਵਰ ਨੂੰ ਹੋਰ ਸਮਰੱਥਾਵਾਂ ਨਾਲ ਬਣਾਉਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ। [ਇਸ ਪੇਜ](https://api.chucknorris.io/) ਨੂੰ ਦੇਖੋ, ਉਦਾਹਰਣ ਲਈ, ਇੱਕ ਟੂਲ ਸ਼ਾਮਲ ਕਰਨ ਲਈ ਜੋ API ਨੂੰ ਕਾਲ ਕਰਦਾ ਹੈ। ਤੁਸੀਂ ਫੈਸਲਾ ਕਰੋ ਕਿ ਸਰਵਰ ਕਿਵ

---

**ਅਸਵੀਕਾਰਨਾ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀ ਹੋਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਦਿਓ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸੁਚੱਜੇਪਣ ਹੋ ਸਕਦੇ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼, ਜੋ ਇਸਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੈ, ਨੂੰ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੇ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।