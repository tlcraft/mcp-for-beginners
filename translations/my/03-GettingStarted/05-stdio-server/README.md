<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:56:06+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "my"
}
-->
# MCP Server with stdio Transport

> **⚠️ အရေးကြီး အပ်ဒိတ်**: MCP Specification 2025-06-18 အရ standalone SSE (Server-Sent Events) transport ကို **deprecated** လုပ်ပြီး "Streamable HTTP" transport ဖြင့် အစားထိုးထားပါသည်။ လက်ရှိ MCP specification တွင် အဓိက transport mechanism နှစ်ခုကို ဖော်ပြထားသည်။
> 1. **stdio** - Standard input/output (local servers အတွက် အကြံပြုထားသည်)
> 2. **Streamable HTTP** - Remote servers အတွက် (SSE ကို အတွင်းပိုင်းတွင် အသုံးပြုနိုင်သည်)
>
> ဒီသင်ခန်းစာကို **stdio transport** အပေါ် အခြေခံပြီး အဓိကထားဖော်ပြထားပြီး MCP server implementation များအတွက် အကြံပြုထားသော နည်းလမ်းဖြစ်သည်။

stdio transport သည် MCP servers များကို standard input နှင့် output streams မှတစ်ဆင့် client များနှင့် ဆက်သွယ်နိုင်စေသည်။ လက်ရှိ MCP specification အတွင်း အများဆုံးအသုံးပြုသော transport mechanism ဖြစ်ပြီး client application များနှင့် လွယ်ကူစွာ ပေါင်းစည်းနိုင်သော အကျိုးရှိသော နည်းလမ်းဖြစ်သည်။

## အကျဉ်းချုပ်

ဒီသင်ခန်းစာတွင် stdio transport ကို အသုံးပြု၍ MCP Servers တည်ဆောက်ခြင်းနှင့် အသုံးပြုခြင်းကို လေ့လာပါမည်။

## သင်ခန်းစာရည်ရွယ်ချက်များ

ဒီသင်ခန်းစာအဆုံးတွင် သင်သည် အောက်ပါအရာများကို လုပ်နိုင်ပါမည်-

- stdio transport ကို အသုံးပြု၍ MCP Server တည်ဆောက်နိုင်ခြင်း
- MCP Server ကို Inspector ဖြင့် Debug လုပ်နိုင်ခြင်း
- Visual Studio Code ကို အသုံးပြု၍ MCP Server ကို အသုံးပြုနိုင်ခြင်း
- လက်ရှိ MCP transport mechanism များကို နားလည်ပြီး stdio ကို အကြံပြုထားသော အကြောင်းရင်းကို သိရှိခြင်း

## stdio Transport - အလုပ်လုပ်ပုံ

stdio transport သည် MCP specification (2025-06-18) အတွင်း support လုပ်ထားသော transport type နှစ်ခုအနက် တစ်ခုဖြစ်သည်။ အလုပ်လုပ်ပုံမှာ-

- **ရိုးရှင်းသော ဆက်သွယ်မှု**: Server သည် standard input (`stdin`) မှ JSON-RPC messages များကို ဖတ်ပြီး standard output (`stdout`) သို့ message များကို ပို့သည်။
- **Process-based**: Client သည် MCP server ကို subprocess အဖြစ် စတင်လုပ်ဆောင်သည်။
- **Message Format**: Messages များသည် individual JSON-RPC requests, notifications, သို့မဟုတ် responses ဖြစ်ပြီး newline ဖြင့် ခွဲထားသည်။
- **Logging**: Server သည် UTF-8 strings များကို standard error (`stderr`) သို့ log ရေးရန် MAY အသုံးပြုနိုင်သည်။

### အဓိကလိုအပ်ချက်များ:
- Messages များသည် newline ဖြင့် ခွဲထားရမည်ဖြစ်ပြီး embedded newlines မပါဝင်ရပါ။
- Server သည် `stdout` တွင် valid MCP message မဟုတ်သော အရာများကို မရေးရပါ။
- Client သည် server ၏ `stdin` တွင် valid MCP message မဟုတ်သော အရာများကို မရေးရပါ။

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

အထက်ပါ code တွင်-

- `Server` class နှင့် `StdioServerTransport` ကို MCP SDK မှ import လုပ်ထားသည်။
- Basic configuration နှင့် capabilities ဖြင့် server instance တစ်ခုကို ဖန်တီးထားသည်။

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

အထက်ပါ code တွင်-

- MCP SDK ကို အသုံးပြု၍ server instance တစ်ခုကို ဖန်တီးထားသည်။
- Decorators အသုံးပြု၍ tools များကို သတ်မှတ်ထားသည်။
- stdio_server context manager ကို transport ကို handle လုပ်ရန် အသုံးပြုထားသည်။

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

SSE နှင့် stdio servers အကြား အဓိကကွာခြားချက်မှာ-

- Web server setup သို့မဟုတ် HTTP endpoints မလိုအပ်ပါ။
- Client မှ subprocess အဖြစ် server ကို စတင်လုပ်ဆောင်သည်။
- stdin/stdout streams မှတစ်ဆင့် ဆက်သွယ်သည်။
- တည်ဆောက်ရန်နှင့် debug လုပ်ရန် ပိုမိုရိုးရှင်းသည်။

## လက်တွေ့လေ့ကျင့်ခန်း: stdio Server တစ်ခု ဖန်တီးခြင်း

Server တစ်ခုကို ဖန်တီးရန် အောက်ပါအချက်နှစ်ချက်ကို သတိထားရမည်-

- Connection နှင့် messages များအတွက် endpoints များကို expose လုပ်ရန် web server ကို အသုံးပြုရမည်။

## Lab: ရိုးရှင်းသော MCP stdio server တစ်ခု ဖန်တီးခြင်း

ဒီ lab တွင် stdio transport ကို အသုံးပြု၍ ရိုးရှင်းသော MCP server တစ်ခုကို ဖန်တီးပါမည်။ ဒီ server သည် clients များက standard Model Context Protocol ကို အသုံးပြု၍ ခေါ်နိုင်သော tools များကို expose လုပ်ပါမည်။

### လိုအပ်ချက်များ

- Python 3.8 သို့မဟုတ် အထက်
- MCP Python SDK: `pip install mcp`
- async programming အခြေခံကို နားလည်ထားခြင်း

အခုတော့ ပထမဆုံး MCP stdio server ကို ဖန်တီးလိုက်ကြစို့:

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

## Deprecated SSE နည်းလမ်းနှင့် stdio Transport အကြား အဓိကကွာခြားချက်များ

**Stdio Transport (လက်ရှိ Standard):**
- ရိုးရှင်းသော subprocess model - client သည် server ကို child process အဖြစ် စတင်လုပ်ဆောင်သည်။
- stdin/stdout မှ JSON-RPC messages ဖြင့် ဆက်သွယ်သည်။
- HTTP server setup မလိုအပ်ပါ။
- ပိုမိုကောင်းမွန်သော performance နှင့် security
- Debug လုပ်ရန်နှင့် တည်ဆောက်ရန် ပိုမိုရိုးရှင်းသည်။

**SSE Transport (MCP 2025-06-18 အရ Deprecated):**
- HTTP server နှင့် SSE endpoints များလိုအပ်သည်။
- Web server infrastructure ဖြင့် setup လုပ်ရန် ပိုမိုရှုပ်ထွေးသည်။
- HTTP endpoints အတွက် အပို security စဉ်းစားရန်လိုအပ်သည်။
- Web-based scenarios အတွက် Streamable HTTP ဖြင့် အစားထိုးထားသည်။

### stdio transport ဖြင့် server တစ်ခု ဖန်တီးခြင်း

stdio server ကို ဖန်တီးရန် အောက်ပါအဆင့်များကို လိုက်နာရမည်-

1. **လိုအပ်သော libraries များကို import လုပ်ပါ** - MCP server components နှင့် stdio transport ကို လိုအပ်သည်။
2. **Server instance တစ်ခုကို ဖန်တီးပါ** - Server ၏ capabilities များကို သတ်မှတ်ပါ။
3. **Tools များကို သတ်မှတ်ပါ** - expose လုပ်လိုသော functionality များကို ထည့်ပါ။
4. **Transport ကို setup လုပ်ပါ** - stdio communication ကို configure လုပ်ပါ။
5. **Server ကို run လုပ်ပါ** - Server ကို စတင်ပြီး messages များကို handle လုပ်ပါ။

အဆင့်ဆင့် တည်ဆောက်ကြစို့:

### အဆင့် 1: ရိုးရှင်းသော stdio server တစ်ခု ဖန်တီးပါ

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

### အဆင့် 2: Tools များကို ထပ်ထည့်ပါ

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

### အဆင့် 3: Server ကို run လုပ်ပါ

Code ကို `server.py` အဖြစ် save လုပ်ပြီး command line မှ run လုပ်ပါ:

```bash
python server.py
```

Server သည် stdin မှ input ကို စောင့်နေပြီး JSON-RPC messages ကို stdio transport မှတစ်ဆင့် ဆက်သွယ်ပါမည်။

### အဆင့် 4: Inspector ဖြင့် စမ်းသပ်ခြင်း

သင်၏ server ကို MCP Inspector ဖြင့် စမ်းသပ်နိုင်သည်-

1. Inspector ကို install လုပ်ပါ: `npx @modelcontextprotocol/inspector`
2. Inspector ကို run လုပ်ပြီး သင်၏ server ကို pointer လုပ်ပါ။
3. သင်ဖန်တီးထားသော tools များကို စမ်းသပ်ပါ။

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

1. Tools များကို ဖန်တီးရန် *Tools.cs* ဖိုင်တစ်ခုကို ဖန်တီးပါ:

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

2. **Web interface ကို ဖွင့်ပါ**: Inspector သည် browser window တစ်ခုကို ဖွင့်ပြီး သင်၏ server ၏ capabilities ကို ပြသပါမည်။

3. **Tools များကို စမ်းသပ်ပါ**: 
   - `get_greeting` tool ကို အမျိုးမျိုးသော name များဖြင့် စမ်းသပ်ပါ။
   - `calculate_sum` tool ကို အမျိုးမျိုးသော numbers များဖြင့် စမ်းသပ်ပါ။
   - `get_server_info` tool ကို ခေါ်ပြီး server metadata ကို ကြည့်ပါ။

4. **ဆက်သွယ်မှုကို ကြည့်ရှုပါ**: Inspector သည် client နှင့် server အကြား JSON-RPC messages များကို ပြသပါမည်။

### သင့်အနေနှင့် မြင်ရမည့်အရာများ

Server သည် မှန်ကန်စွာ စတင်လည်ပတ်ပါက သင်သည် အောက်ပါအရာများကို မြင်ရမည်-

- Inspector တွင် server capabilities များကို ပြသထားသည်။
- Tools များကို စမ်းသပ်နိုင်သည်။
- JSON-RPC message များအောင်မြင်စွာ လွှဲပြောင်းနေသည်။
- Tool response များကို interface တွင် ပြသထားသည်။

### ရှေ့ဆက်လုပ်ဆောင်ရန်

**Server မစတင်နိုင်ပါ**:
- `pip install mcp` ဖြင့် dependencies များကို install လုပ်ထားပါ။
- Python syntax နှင့် indentation ကို စစ်ဆေးပါ။
- Console တွင် error messages များကို ကြည့်ပါ။

**Tools မပေါ်လာပါ**:
- `@server.tool()` decorators များရှိကြောင်း သေချာပါ။
- Tool functions များကို `main()` မတိုင်မီ သတ်မှတ်ထားပါ။
- Server ကို မှန်ကန်စွာ configure လုပ်ထားကြောင်း စစ်ဆေးပါ။

**ဆက်သွယ်မှုပြဿနာများ**:
- Server သည် stdio transport ကို မှန်ကန်စွာ အသုံးပြုနေကြောင်း သေချာပါ။
- အခြား process များ interference မရှိကြောင်း စစ်ဆေးပါ။
- Inspector command syntax ကို စစ်ဆေးပါ။

## အလုပ်ပေးချက်

သင့် server ကို ပိုမို functionality များဖြင့် တိုးချဲ့ဖန်တီးကြည့်ပါ။ ဥပမာအားဖြင့် [ဒီစာမျက်နှာ](https://api.chucknorris.io/) ကို အသုံးပြု၍ API ကို ခေါ်သည့် tool တစ်ခုကို ထည့်ပါ။ Server ကို ဘယ်လိုပုံစံဖြစ်စေလိုသည်ကို သင်ဆုံးဖြတ်ပါ။ ပျော်ရွှင်စွာ လုပ်ဆောင်ပါ :)

## ဖြေရှင်းချက်

[Solution](./solution/README.md) အလုပ်လုပ်နေသော code ဖြင့်ဖြေရှင်းချက်တစ်ခုကို ရှာဖွေကြည့်ပါ။

## အဓိက Takeaways

ဒီအခန်းမှ အဓိက Takeaways များမှာ-

- stdio transport သည် local MCP servers အတွက် အကြံပြုထားသော mechanism ဖြစ်သည်။
- stdio transport သည် standard input နှင့် output streams ကို အသုံးပြု၍ MCP servers နှင့် clients အကြား seamless communication ကို ပေးစွမ်းသည်။
- Inspector နှင့် Visual Studio Code ကို အသုံးပြု၍ stdio servers ကို တိုက်ရိုက် အသုံးပြုနိုင်ပြီး debug လုပ်ရန်နှင့် integration လုပ်ရန် ရိုးရှင်းစေသည်။

## နမူနာများ 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## အပိုဆောင်းရင်းမြစ်များ

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## ရှေ့ဆက်လုပ်ဆောင်ရန်

## Next Steps

stdio transport ကို အသုံးပြု၍ MCP servers တည်ဆောက်ပုံကို သင်လေ့လာပြီးနောက် အောက်ပါအဆင့်များကို လေ့လာနိုင်သည်-

- **Next**: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md) - Remote servers အတွက် support လုပ်ထားသော transport mechanism ကို လေ့လာပါ။
- **Advanced**: [MCP Security Best Practices](../../02-Security/README.md) - MCP servers တွင် security ကို အကောင်အထည်ဖော်ပါ။
- **Production**: [Deployment Strategies](../09-deployment/README.md) - Production အတွက် servers များကို deploy လုပ်ပါ။

## အပိုဆောင်းရင်းမြစ်များ

- [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - တရားဝင် specification
- [MCP SDK Documentation](https://github.com/modelcontextprotocol/sdk) - ဘာသာစကားအားလုံးအတွက် SDK references
- [Community Examples](../../06-CommunityContributions/README.md) - Community မှ server နမူနာများ

---

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းဘာသာစကားဖြင့် ရေးသားထားသော စာရွက်စာတမ်းကို အာဏာရှိသော ရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။