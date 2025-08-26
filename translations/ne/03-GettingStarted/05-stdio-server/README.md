<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:27:48+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "ne"
}
-->
# MCP Server with stdio Transport

> **⚠️ महत्त्वपूर्ण अपडेट**: MCP Specification 2025-06-18 अनुसार, standalone SSE (Server-Sent Events) transport **अप्रचलित** भएको छ र यसको स्थानमा "Streamable HTTP" transport आएको छ। हालको MCP specification ले दुई मुख्य transport विधिहरू परिभाषित गर्दछ:
> 1. **stdio** - स्थानीय सर्भरहरूको लागि सिफारिस गरिएको (Standard input/output)
> 2. **Streamable HTTP** - टाढाका सर्भरहरूको लागि, जसले आन्तरिक रूपमा SSE प्रयोग गर्न सक्छ
>
> यो पाठ stdio transport मा केन्द्रित छ, जुन अधिकांश MCP सर्भर कार्यान्वयनहरूको लागि सिफारिस गरिएको विधि हो।

stdio transport ले MCP सर्भरहरूलाई standard input र output streams मार्फत क्लाइन्टहरूसँग संवाद गर्न अनुमति दिन्छ। यो हालको MCP specification मा सबैभन्दा सामान्य र सिफारिस गरिएको transport विधि हो, जसले विभिन्न क्लाइन्ट एप्लिकेसनहरूसँग सजिलै एकीकृत गर्न सकिने सरल र प्रभावकारी तरिका प्रदान गर्दछ।

## अवलोकन

यो पाठले stdio transport प्रयोग गरेर MCP सर्भर निर्माण गर्ने र उपभोग गर्ने तरिका समेट्छ।

## सिकाइ उद्देश्यहरू

यो पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- stdio transport प्रयोग गरेर MCP सर्भर निर्माण गर्न।
- Inspector प्रयोग गरेर MCP सर्भर डिबग गर्न।
- Visual Studio Code प्रयोग गरेर MCP सर्भर उपभोग गर्न।
- हालको MCP transport विधिहरू बुझ्न र किन stdio सिफारिस गरिएको हो भन्ने कुरा बुझ्न।

## stdio Transport - यो कसरी काम गर्छ

stdio transport हालको MCP specification (2025-06-18) मा समर्थित दुई transport प्रकारहरू मध्ये एक हो। यसले निम्न तरिकाले काम गर्छ:

- **सरल संवाद**: सर्भरले standard input (`stdin`) बाट JSON-RPC सन्देशहरू पढ्छ र standard output (`stdout`) मा सन्देशहरू पठाउँछ।
- **प्रक्रिया-आधारित**: क्लाइन्टले MCP सर्भरलाई subprocess को रूपमा सुरु गर्छ।
- **सन्देश ढाँचा**: सन्देशहरू व्यक्तिगत JSON-RPC अनुरोधहरू, सूचनाहरू, वा प्रतिक्रियाहरू हुन्, जुन नयाँ लाइनले छुट्याइएको हुन्छ।
- **लगिङ**: सर्भरले UTF-8 स्ट्रिङहरू standard error (`stderr`) मा लगिङको लागि लेख्न सक्छ।

### मुख्य आवश्यकताहरू:
- सन्देशहरू नयाँ लाइनले छुट्याइएको हुनुपर्छ र embedded नयाँ लाइनहरू समावेश गर्नु हुँदैन।
- सर्भरले `stdout` मा कुनै पनि कुरा लेख्नु हुँदैन जुन मान्य MCP सन्देश होइन।
- क्लाइन्टले सर्भरको `stdin` मा कुनै पनि कुरा लेख्नु हुँदैन जुन मान्य MCP सन्देश होइन।

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

उपरोक्त कोडमा:

- हामीले MCP SDK बाट `Server` class र `StdioServerTransport` आयात गरेका छौं।
- हामीले आधारभूत कन्फिगरेसन र क्षमताहरूको साथ सर्भर instance सिर्जना गरेका छौं।

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

उपरोक्त कोडमा हामीले:

- MCP SDK प्रयोग गरेर सर्भर instance सिर्जना गरेका छौं।
- डेकोरेटरहरू प्रयोग गरेर उपकरणहरू परिभाषित गरेका छौं।
- stdio_server context manager प्रयोग गरेर transport ह्यान्डल गरेका छौं।

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

SSE बाट stdio सर्भरहरूको मुख्य भिन्नता:

- वेब सर्भर सेटअप वा HTTP endpoints आवश्यक पर्दैन।
- क्लाइन्टले subprocess को रूपमा सर्भर सुरु गर्छ।
- stdin/stdout streams मार्फत संवाद गर्छ।
- कार्यान्वयन र डिबग गर्न सजिलो छ।

## अभ्यास: stdio सर्भर सिर्जना गर्नुहोस्

हाम्रो सर्भर सिर्जना गर्न, हामीले दुई कुरामा ध्यान दिनुपर्छ:

- हामीले endpoints को लागि वेब सर्भर प्रयोग गर्नुपर्छ।
## प्रयोगशाला: सरल MCP stdio सर्भर सिर्जना गर्नुहोस्

यस प्रयोगशालामा, हामी stdio transport प्रयोग गरेर एक सरल MCP सर्भर सिर्जना गर्नेछौं। यो सर्भरले उपकरणहरू प्रदान गर्नेछ जसलाई क्लाइन्टहरूले standard Model Context Protocol प्रयोग गरेर कल गर्न सक्छन्।

### पूर्वापेक्षाहरू

- Python 3.8 वा पछिल्लो संस्करण
- MCP Python SDK: `pip install mcp`
- async प्रोग्रामिङको आधारभूत ज्ञान

आउनुहोस्, हाम्रो पहिलो MCP stdio सर्भर सिर्जना गरौं:

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

## SSE विधिबाट stdio transport को मुख्य भिन्नता

**Stdio Transport (हालको मानक):**
- सरल subprocess मोडेल - क्लाइन्टले सर्भरलाई child process को रूपमा सुरु गर्छ।
- stdin/stdout मार्फत JSON-RPC सन्देशहरू प्रयोग गरेर संवाद।
- HTTP सर्भर सेटअप आवश्यक छैन।
- राम्रो प्रदर्शन र सुरक्षा।
- डिबग र विकास गर्न सजिलो।

**SSE Transport (MCP 2025-06-18 अनुसार अप्रचलित):**
- HTTP सर्भरको आवश्यकता SSE endpoints सहित।
- वेब सर्भर संरचनासहित अधिक जटिल सेटअप।
- HTTP endpoints को लागि अतिरिक्त सुरक्षा विचारहरू।
- वेब-आधारित परिदृश्यहरूको लागि Streamable HTTP ले प्रतिस्थापन गरेको।

### stdio transport प्रयोग गरेर सर्भर सिर्जना गर्नुहोस्

हाम्रो stdio सर्भर सिर्जना गर्न, हामीले निम्न गर्नुपर्छ:

1. **आवश्यक लाइब्रेरीहरू आयात गर्नुहोस्** - MCP सर्भर कम्पोनेन्टहरू र stdio transport आवश्यक छ।
2. **सर्भर instance सिर्जना गर्नुहोस्** - सर्भरलाई यसको क्षमताहरू सहित परिभाषित गर्नुहोस्।
3. **उपकरणहरू परिभाषित गर्नुहोस्** - हामीले प्रदान गर्न चाहेको कार्यक्षमता थप्नुहोस्।
4. **transport सेटअप गर्नुहोस्** - stdio संवाद कन्फिगर गर्नुहोस्।
5. **सर्भर चलाउनुहोस्** - सर्भर सुरु गर्नुहोस् र सन्देशहरू ह्यान्डल गर्नुहोस्।

आउनुहोस्, यसलाई चरणबद्ध रूपमा निर्माण गरौं:

### चरण 1: आधारभूत stdio सर्भर सिर्जना गर्नुहोस्

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

### चरण 2: थप उपकरणहरू थप्नुहोस्

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

### चरण 3: सर्भर चलाउनुहोस्

कोडलाई `server.py` को रूपमा बचत गर्नुहोस् र कमाण्ड लाइनबाट चलाउनुहोस्:

```bash
python server.py
```

सर्भर सुरु हुनेछ र stdin बाट इनपुटको प्रतीक्षा गर्नेछ। यो stdio transport मार्फत JSON-RPC सन्देशहरू प्रयोग गरेर संवाद गर्छ।

### चरण 4: Inspector प्रयोग गरेर परीक्षण गर्नुहोस्

तपाईं आफ्नो सर्भरलाई MCP Inspector प्रयोग गरेर परीक्षण गर्न सक्नुहुन्छ:

1. Inspector स्थापना गर्नुहोस्: `npx @modelcontextprotocol/inspector`
2. Inspector चलाउनुहोस् र आफ्नो सर्भरमा पोइन्ट गर्नुहोस्।
3. तपाईंले सिर्जना गरेका उपकरणहरू परीक्षण गर्नुहोस्।

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

// उपकरणहरू थप्नुहोस्
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "व्यक्तिगत अभिवादन प्राप्त गर्नुहोस्",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "अभिवादन गर्न व्यक्तिको नाम",
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
          text: `नमस्ते, ${request.params.arguments?.name}! MCP stdio सर्भरमा स्वागत छ।`,
        },
      ],
    };
  } else {
    throw new Error(`अज्ञात उपकरण: ${request.params.name}`);
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
    [Description("व्यक्तिगत अभिवादन प्राप्त गर्नुहोस्")]
    public string GetGreeting(string name)
    {
        return $"नमस्ते, {name}! MCP stdio सर्भरमा स्वागत छ।";
    }

    [Description("दुई संख्याको योग गणना गर्नुहोस्")]
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

1. सुरुमा केही उपकरणहरू सिर्जना गरौं। यसका लागि हामी *Tools.cs* नामक फाइल बनाउनेछौं, जसमा निम्न सामग्री हुनेछ:

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

2. **वेब इन्टरफेस खोल्नुहोस्**: Inspector ब्राउजर विन्डो खोल्नेछ, जसले तपाईंको सर्भरको क्षमताहरू देखाउँछ।

3. **उपकरणहरू परीक्षण गर्नुहोस्**: 
   - `get_greeting` उपकरणलाई विभिन्न नामहरूसँग परीक्षण गर्नुहोस्।
   - `calculate_sum` उपकरणलाई विभिन्न संख्याहरूको साथ परीक्षण गर्नुहोस्।
   - `get_server_info` उपकरणलाई कल गरेर सर्भर मेटाडाटा हेर्नुहोस्।

4. **संवादको निगरानी गर्नुहोस्**: Inspector ले क्लाइन्ट र सर्भर बीच आदानप्रदान भएका JSON-RPC सन्देशहरू देखाउँछ।

### तपाईंले के देख्नुहुनेछ

जब तपाईंको सर्भर सही रूपमा सुरु हुन्छ, तपाईंले देख्नुहुनेछ:
- Inspector मा सर्भर क्षमताहरू सूचीबद्ध।
- परीक्षणका लागि उपलब्ध उपकरणहरू।
- सफल JSON-RPC सन्देश आदानप्रदान।
- इन्टरफेसमा उपकरण प्रतिक्रियाहरू देखाइन्छ।

### सामान्य समस्या र समाधान

**सर्भर सुरु हुँदैन:**
- सबै निर्भरता स्थापना भएको छ कि छैन जाँच गर्नुहोस्: `pip install mcp`
- Python को सिंट्याक्स र इन्डेन्टेसन जाँच गर्नुहोस्।
- कन्सोलमा त्रुटि सन्देशहरू हेर्नुहोस्।

**उपकरणहरू देखिँदैनन्:**
- सुनिश्चित गर्नुहोस् कि `@server.tool()` डेकोरेटरहरू उपस्थित छन्।
- उपकरण कार्यहरू `main()` भन्दा पहिले परिभाषित छन् कि छैन जाँच गर्नुहोस्।
- सर्भर सही रूपमा कन्फिगर गरिएको छ कि छैन जाँच गर्नुहोस्।

**जडान समस्या:**
- सर्भरले stdio transport सही रूपमा प्रयोग गरिरहेको छ कि छैन सुनिश्चित गर्नुहोस्।
- अन्य प्रक्रियाहरूले हस्तक्षेप गरिरहेका छैनन् कि छैन जाँच गर्नुहोस्।
- Inspector कमाण्ड सिंट्याक्स जाँच गर्नुहोस्।

## असाइनमेन्ट

आफ्नो सर्भरलाई थप क्षमताहरूको साथ निर्माण गर्ने प्रयास गर्नुहोस्। [यो पृष्ठ](https://api.chucknorris.io/) हेर्नुहोस्, उदाहरणका लागि, API कल गर्ने उपकरण थप्न। तपाईंले सर्भर कस्तो देखिनुपर्छ भन्ने निर्णय गर्नुहोस्। रमाइलो गर्नुहोस् :)

## समाधान

[Solution](./solution/README.md) यहाँ कार्यरत कोडको सम्भावित समाधान छ।

## मुख्य कुरा

यस अध्यायबाट मुख्य कुरा निम्न छन्:

- stdio transport स्थानीय MCP सर्भरहरूको लागि सिफारिस गरिएको विधि हो।
- stdio transport ले standard input र output streams प्रयोग गरेर MCP सर्भरहरू र क्लाइन्टहरू बीच सहज संवादको अनुमति दिन्छ।
- तपाईं Inspector र Visual Studio Code दुवै प्रयोग गरेर stdio सर्भरहरूलाई सिधै उपभोग गर्न सक्नुहुन्छ, जसले डिबग र एकीकरणलाई सरल बनाउँछ।

## नमूनाहरू 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## थप स्रोतहरू

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## के आउँदैछ

## आगामी चरणहरू

अब तपाईंले stdio transport प्रयोग गरेर MCP सर्भर निर्माण गर्ने तरिका सिक्नुभएको छ, तपाईं थप उन्नत विषयहरू अन्वेषण गर्न सक्नुहुन्छ:

- **अगाडि**: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md) - टाढाका सर्भरहरूको लागि समर्थित अर्को transport विधि सिक्नुहोस्।
- **उन्नत**: [MCP Security Best Practices](../../02-Security/README.md) - MCP सर्भरहरूमा सुरक्षा कार्यान्वयन गर्नुहोस्।
- **उत्पादन**: [Deployment Strategies](../09-deployment/README.md) - उत्पादन प्रयोगको लागि सर्भरहरू तैनाथ गर्नुहोस्।

## थप स्रोतहरू

- [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - आधिकारिक स्पेसिफिकेसन।
- [MCP SDK Documentation](https://github.com/modelcontextprotocol/sdk) - सबै भाषाहरूको लागि SDK सन्दर्भहरू।
- [Community Examples](../../06-CommunityContributions/README.md) - समुदायबाट थप सर्भर उदाहरणहरू।

---

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको छ। हामी शुद्धताको लागि प्रयास गर्छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादहरूमा त्रुटि वा अशुद्धता हुन सक्छ। यसको मूल भाषा मा रहेको मूल दस्तावेज़लाई आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार हुने छैनौं।