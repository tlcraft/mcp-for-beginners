<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:40:59+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "tl"
}
-->
# MCP Server gamit ang stdio Transport

> **⚠️ Mahalagang Update**: Simula sa MCP Specification 2025-06-18, ang standalone SSE (Server-Sent Events) transport ay **hindi na ginagamit** at pinalitan ng "Streamable HTTP" transport. Ang kasalukuyang MCP specification ay nagtatakda ng dalawang pangunahing mekanismo ng transport:
> 1. **stdio** - Standard input/output (inirerekomenda para sa mga lokal na server)
> 2. **Streamable HTTP** - Para sa mga remote server na maaaring gumamit ng SSE sa loob
>
> Ang araling ito ay na-update upang mag-focus sa **stdio transport**, na siyang inirerekomendang paraan para sa karamihan ng mga MCP server implementation.

Ang stdio transport ay nagbibigay-daan sa mga MCP server na makipag-ugnayan sa mga kliyente gamit ang standard input at output streams. Ito ang pinaka-karaniwang ginagamit at inirerekomendang mekanismo ng transport sa kasalukuyang MCP specification, na nagbibigay ng simple at epektibong paraan upang bumuo ng MCP servers na madaling ma-integrate sa iba't ibang client applications.

## Pangkalahatang-ideya

Ang araling ito ay tumatalakay kung paano bumuo at gumamit ng MCP Servers gamit ang stdio transport.

## Mga Layunin sa Pag-aaral

Sa pagtatapos ng araling ito, magagawa mo ang sumusunod:

- Bumuo ng MCP Server gamit ang stdio transport.
- I-debug ang MCP Server gamit ang Inspector.
- Gumamit ng MCP Server gamit ang Visual Studio Code.
- Maunawaan ang kasalukuyang mga mekanismo ng MCP transport at kung bakit inirerekomenda ang stdio.

## stdio Transport - Paano Ito Gumagana

Ang stdio transport ay isa sa dalawang suportadong uri ng transport sa kasalukuyang MCP specification (2025-06-18). Narito kung paano ito gumagana:

- **Simpleng Komunikasyon**: Binabasa ng server ang mga JSON-RPC na mensahe mula sa standard input (`stdin`) at nagpapadala ng mga mensahe sa standard output (`stdout`).
- **Batay sa Proseso**: Ang client ay naglulunsad ng MCP server bilang isang subprocess.
- **Format ng Mensahe**: Ang mga mensahe ay indibidwal na JSON-RPC requests, notifications, o responses, na pinaghihiwalay ng mga newline.
- **Pag-log**: Ang server AY MAARING magsulat ng UTF-8 strings sa standard error (`stderr`) para sa pag-log.

### Mga Pangunahing Kinakailangan:
- Ang mga mensahe AY DAPAT na pinaghihiwalay ng mga newline at HINDI DAPAT maglaman ng embedded newlines.
- Ang server AY HINDI DAPAT magsulat ng kahit ano sa `stdout` na hindi valid na MCP message.
- Ang client AY HINDI DAPAT magsulat ng kahit ano sa `stdin` ng server na hindi valid na MCP message.

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

Sa code na ito:

- Ini-import natin ang `Server` class at `StdioServerTransport` mula sa MCP SDK.
- Gumagawa tayo ng server instance na may basic configuration at capabilities.

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

Sa code na ito:

- Gumagawa tayo ng server instance gamit ang MCP SDK.
- Nagde-define tayo ng tools gamit ang decorators.
- Ginagamit ang stdio_server context manager para sa transport.

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

Ang pangunahing pagkakaiba mula sa SSE ay ang stdio servers:

- Hindi nangangailangan ng web server setup o HTTP endpoints.
- Nilulunsad bilang subprocesses ng client.
- Nakikipag-ugnayan gamit ang stdin/stdout streams.
- Mas simple i-implement at i-debug.

## Ehersisyo: Paglikha ng stdio Server

Para makagawa ng server, kailangan nating tandaan ang dalawang bagay:

- Kailangan nating gumamit ng web server para mag-expose ng endpoints para sa koneksyon at mga mensahe.

## Lab: Paglikha ng simpleng MCP stdio server

Sa lab na ito, gagawa tayo ng simpleng MCP server gamit ang inirerekomendang stdio transport. Ang server na ito ay mag-eexpose ng tools na maaaring tawagin ng mga kliyente gamit ang standard Model Context Protocol.

### Mga Kinakailangan

- Python 3.8 o mas bago.
- MCP Python SDK: `pip install mcp`.
- Pangunahing kaalaman sa async programming.

Simulan natin ang paggawa ng unang MCP stdio server:

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

## Pangunahing Pagkakaiba mula sa Deprecated SSE Approach

**Stdio Transport (Kasalukuyang Standard):**
- Simpleng subprocess model - nilulunsad ng client ang server bilang child process.
- Komunikasyon sa pamamagitan ng stdin/stdout gamit ang JSON-RPC messages.
- Walang kinakailangang HTTP server setup.
- Mas mahusay na performance at seguridad.
- Mas madaling i-debug at i-develop.

**SSE Transport (Hindi na ginagamit simula MCP 2025-06-18):**
- Nangangailangan ng HTTP server na may SSE endpoints.
- Mas kumplikadong setup gamit ang web server infrastructure.
- Karagdagang mga konsiderasyon sa seguridad para sa HTTP endpoints.
- Pinalitan na ng Streamable HTTP para sa web-based scenarios.

### Paglikha ng server gamit ang stdio transport

Para makagawa ng stdio server, kailangan nating:

1. **I-import ang mga kinakailangang library** - Kailangan natin ang MCP server components at stdio transport.
2. **Gumawa ng server instance** - I-define ang server gamit ang mga capabilities nito.
3. **Mag-define ng tools** - Idagdag ang functionality na gusto nating i-expose.
4. **I-set up ang transport** - I-configure ang stdio communication.
5. **Patakbuhin ang server** - Simulan ang server at i-handle ang mga mensahe.

Gawin natin ito step-by-step:

### Hakbang 1: Gumawa ng basic stdio server

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

### Hakbang 2: Magdagdag ng mas maraming tools

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

### Hakbang 3: Patakbuhin ang server

I-save ang code bilang `server.py` at patakbuhin ito mula sa command line:

```bash
python server.py
```

Ang server ay magsisimula at maghihintay ng input mula sa stdin. Nakikipag-ugnayan ito gamit ang JSON-RPC messages sa stdio transport.

### Hakbang 4: Testing gamit ang Inspector

Pwede mong i-test ang server gamit ang MCP Inspector:

1. I-install ang Inspector: `npx @modelcontextprotocol/inspector`.
2. Patakbuhin ang Inspector at ituro ito sa iyong server.
3. I-test ang mga tools na ginawa mo.

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

// Magdagdag ng tools
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Kumuha ng personalized na pagbati",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Pangalan ng taong babatiin",
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
    [Description("Kumuha ng personalized na pagbati")]
    public string GetGreeting(string name)
    {
        return $"Hello, {name}! Welcome to MCP stdio server.";
    }

    [Description("Kalkulahin ang kabuuan ng dalawang numero")]
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

1. Gumawa muna ng tools, para dito gagawa tayo ng file *Tools.cs* na may ganitong nilalaman:

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

2. **Buksan ang web interface**: Bubuksan ng Inspector ang browser window na nagpapakita ng capabilities ng iyong server.

3. **I-test ang mga tools**: 
   - Subukan ang `get_greeting` tool gamit ang iba't ibang pangalan.
   - Subukan ang `calculate_sum` tool gamit ang iba't ibang numero.
   - Tawagin ang `get_server_info` tool para makita ang metadata ng server.

4. **I-monitor ang komunikasyon**: Ipinapakita ng Inspector ang mga JSON-RPC messages na ipinapadala sa pagitan ng client at server.

### Ano ang Dapat Mong Makita

Kapag tama ang pagsisimula ng iyong server, dapat mong makita:
- Mga capabilities ng server na nakalista sa Inspector.
- Mga tools na available para sa testing.
- Matagumpay na palitan ng JSON-RPC messages.
- Mga tugon ng tools na ipinapakita sa interface.

### Karaniwang Problema at Solusyon

**Hindi magsimula ang server:**
- Siguraduhing naka-install ang lahat ng dependencies: `pip install mcp`.
- I-verify ang Python syntax at indentation.
- Hanapin ang mga error message sa console.

**Hindi lumalabas ang mga tools:**
- Siguraduhing may `@server.tool()` decorators.
- I-check na ang mga tool functions ay na-define bago ang `main()`.
- I-verify na tama ang configuration ng server.

**Problema sa koneksyon:**
- Siguraduhing tama ang paggamit ng stdio transport sa server.
- I-check na walang ibang proseso ang nakakaabala.
- I-verify ang syntax ng Inspector command.

## Takdang-Aralin

Subukang palawakin ang iyong server gamit ang mas maraming capabilities. Tingnan ang [pahinang ito](https://api.chucknorris.io/) para, halimbawa, magdagdag ng tool na tumatawag sa isang API. Ikaw ang magdesisyon kung ano ang magiging hitsura ng server. Mag-enjoy! :)

## Solusyon

[Solusyon](./solution/README.md) Narito ang posibleng solusyon na may gumaganang code.

## Mga Pangunahing Puntos

Ang mga pangunahing puntos mula sa kabanatang ito ay ang mga sumusunod:

- Ang stdio transport ang inirerekomendang mekanismo para sa mga lokal na MCP servers.
- Ang stdio transport ay nagbibigay-daan sa seamless na komunikasyon sa pagitan ng MCP servers at clients gamit ang standard input at output streams.
- Pwede mong gamitin ang Inspector at Visual Studio Code para direktang gumamit ng stdio servers, na nagpapadali sa debugging at integration.

## Mga Halimbawa 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Karagdagang Resources

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Ano ang Susunod

## Mga Susunod na Hakbang

Ngayon na natutunan mo kung paano bumuo ng MCP servers gamit ang stdio transport, maaari mong tuklasin ang mas advanced na mga paksa:

- **Susunod**: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md) - Alamin ang isa pang suportadong mekanismo ng transport para sa remote servers.
- **Advanced**: [MCP Security Best Practices](../../02-Security/README.md) - Magpatupad ng seguridad sa iyong MCP servers.
- **Production**: [Deployment Strategies](../09-deployment/README.md) - I-deploy ang iyong servers para sa production use.

## Karagdagang Resources

- [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Opisyal na specification.
- [MCP SDK Documentation](https://github.com/modelcontextprotocol/sdk) - Mga reference ng SDK para sa lahat ng wika.
- [Community Examples](../../06-CommunityContributions/README.md) - Mas maraming halimbawa ng server mula sa komunidad.

---

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama't sinisikap naming maging tumpak, tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na opisyal na sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.