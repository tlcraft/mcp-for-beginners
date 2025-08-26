<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:25:04+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "hi"
}
-->
# MCP सर्वर stdio ट्रांसपोर्ट के साथ

> **⚠️ महत्वपूर्ण अपडेट**: MCP स्पेसिफिकेशन 2025-06-18 के अनुसार, स्टैंडअलोन SSE (Server-Sent Events) ट्रांसपोर्ट को **डिप्रिकेट** कर दिया गया है और इसे "Streamable HTTP" ट्रांसपोर्ट से बदल दिया गया है। वर्तमान MCP स्पेसिफिकेशन दो मुख्य ट्रांसपोर्ट मैकेनिज़्म को परिभाषित करता है:
> 1. **stdio** - स्टैंडर्ड इनपुट/आउटपुट (स्थानीय सर्वरों के लिए अनुशंसित)
> 2. **Streamable HTTP** - रिमोट सर्वरों के लिए जो आंतरिक रूप से SSE का उपयोग कर सकते हैं
>
> यह पाठ stdio ट्रांसपोर्ट पर केंद्रित है, जो अधिकांश MCP सर्वर इम्प्लीमेंटेशन के लिए अनुशंसित तरीका है।

stdio ट्रांसपोर्ट MCP सर्वरों को क्लाइंट्स के साथ स्टैंडर्ड इनपुट और आउटपुट स्ट्रीम्स के माध्यम से संवाद करने की अनुमति देता है। यह वर्तमान MCP स्पेसिफिकेशन में सबसे सामान्य और अनुशंसित ट्रांसपोर्ट मैकेनिज़्म है, जो MCP सर्वरों को सरल और प्रभावी तरीके से विभिन्न क्लाइंट एप्लिकेशन के साथ एकीकृत करने की सुविधा प्रदान करता है।

## अवलोकन

यह पाठ stdio ट्रांसपोर्ट का उपयोग करके MCP सर्वर बनाने और उपयोग करने के तरीके को कवर करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- stdio ट्रांसपोर्ट का उपयोग करके MCP सर्वर बनाना।
- MCP सर्वर को Inspector का उपयोग करके डिबग करना।
- Visual Studio Code का उपयोग करके MCP सर्वर का उपभोग करना।
- वर्तमान MCP ट्रांसपोर्ट मैकेनिज़्म को समझना और यह जानना कि stdio क्यों अनुशंसित है।

## stdio ट्रांसपोर्ट - यह कैसे काम करता है

stdio ट्रांसपोर्ट वर्तमान MCP स्पेसिफिकेशन (2025-06-18) में समर्थित दो ट्रांसपोर्ट प्रकारों में से एक है। यह इस प्रकार काम करता है:

- **सरल संचार**: सर्वर स्टैंडर्ड इनपुट (`stdin`) से JSON-RPC संदेश पढ़ता है और स्टैंडर्ड आउटपुट (`stdout`) पर संदेश भेजता है।
- **प्रोसेस-आधारित**: क्लाइंट MCP सर्वर को एक सबप्रोसेस के रूप में लॉन्च करता है।
- **संदेश प्रारूप**: संदेश व्यक्तिगत JSON-RPC अनुरोध, सूचनाएं, या प्रतिक्रियाएं होते हैं, जो नई लाइनों द्वारा सीमांकित होते हैं।
- **लॉगिंग**: सर्वर लॉगिंग उद्देश्यों के लिए स्टैंडर्ड एरर (`stderr`) पर UTF-8 स्ट्रिंग्स लिख सकता है।

### मुख्य आवश्यकताएं:
- संदेश नई लाइनों द्वारा सीमांकित होने चाहिए और उनमें एम्बेडेड नई लाइनें नहीं होनी चाहिए।
- सर्वर को `stdout` पर ऐसा कुछ भी नहीं लिखना चाहिए जो वैध MCP संदेश न हो।
- क्लाइंट को सर्वर के `stdin` पर ऐसा कुछ भी नहीं लिखना चाहिए जो वैध MCP संदेश न हो।

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

उपरोक्त कोड में:

- हम MCP SDK से `Server` क्लास और `StdioServerTransport` को इम्पोर्ट करते हैं।
- हम बेसिक कॉन्फ़िगरेशन और क्षमताओं के साथ एक सर्वर इंस्टेंस बनाते हैं।

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

उपरोक्त कोड में:

- हम MCP SDK का उपयोग करके एक सर्वर इंस्टेंस बनाते हैं।
- डेकोरेटर्स का उपयोग करके टूल्स को परिभाषित करते हैं।
- stdio_server कॉन्टेक्स्ट मैनेजर का उपयोग करके ट्रांसपोर्ट को संभालते हैं।

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

SSE से मुख्य अंतर यह है कि stdio सर्वर:

- वेब सर्वर सेटअप या HTTP एंडपॉइंट्स की आवश्यकता नहीं रखते।
- क्लाइंट द्वारा सबप्रोसेस के रूप में लॉन्च किए जाते हैं।
- stdin/stdout स्ट्रीम्स के माध्यम से संवाद करते हैं।
- इन्हें लागू करना और डिबग करना आसान है।

## अभ्यास: stdio सर्वर बनाना

हमारे सर्वर को बनाने के लिए, हमें दो बातों का ध्यान रखना होगा:

- हमें कनेक्शन और संदेशों के लिए एंडपॉइंट्स को एक्सपोज़ करने के लिए एक वेब सर्वर का उपयोग करना होगा।

## प्रयोगशाला: एक सरल MCP stdio सर्वर बनाना

इस प्रयोगशाला में, हम अनुशंसित stdio ट्रांसपोर्ट का उपयोग करके एक सरल MCP सर्वर बनाएंगे। यह सर्वर ऐसे टूल्स को एक्सपोज़ करेगा जिन्हें क्लाइंट्स स्टैंडर्ड मॉडल कॉन्टेक्स्ट प्रोटोकॉल का उपयोग करके कॉल कर सकते हैं।

### आवश्यकताएं

- Python 3.8 या बाद का संस्करण
- MCP Python SDK: `pip install mcp`
- असिंक्रोनस प्रोग्रामिंग की बुनियादी समझ

आइए अपना पहला MCP stdio सर्वर बनाना शुरू करें:

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

## डिप्रिकेटेड SSE दृष्टिकोण से मुख्य अंतर

**Stdio ट्रांसपोर्ट (वर्तमान मानक):**
- सरल सबप्रोसेस मॉडल - क्लाइंट सर्वर को चाइल्ड प्रोसेस के रूप में लॉन्च करता है।
- JSON-RPC संदेशों का उपयोग करके stdin/stdout के माध्यम से संचार।
- HTTP सर्वर सेटअप की आवश्यकता नहीं।
- बेहतर प्रदर्शन और सुरक्षा।
- डिबगिंग और विकास में आसानी।

**SSE ट्रांसपोर्ट (MCP 2025-06-18 से डिप्रिकेट):**
- HTTP सर्वर के साथ SSE एंडपॉइंट्स की आवश्यकता।
- वेब सर्वर इंफ्रास्ट्रक्चर के साथ अधिक जटिल सेटअप।
- HTTP एंडपॉइंट्स के लिए अतिरिक्त सुरक्षा विचार।
- अब वेब-आधारित परिदृश्यों के लिए Streamable HTTP द्वारा प्रतिस्थापित।

### stdio ट्रांसपोर्ट के साथ सर्वर बनाना

stdio सर्वर बनाने के लिए, हमें निम्नलिखित करना होगा:

1. **आवश्यक लाइब्रेरीज़ इम्पोर्ट करें** - हमें MCP सर्वर घटकों और stdio ट्रांसपोर्ट की आवश्यकता होगी।
2. **सर्वर इंस्टेंस बनाएं** - सर्वर को उसकी क्षमताओं के साथ परिभाषित करें।
3. **टूल्स परिभाषित करें** - वह कार्यक्षमता जोड़ें जिसे हम एक्सपोज़ करना चाहते हैं।
4. **ट्रांसपोर्ट सेट करें** - stdio संचार को कॉन्फ़िगर करें।
5. **सर्वर चलाएं** - सर्वर शुरू करें और संदेशों को संभालें।

आइए इसे चरण दर चरण बनाएं:

### चरण 1: एक बेसिक stdio सर्वर बनाएं

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

### चरण 2: और टूल्स जोड़ें

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

### चरण 3: सर्वर चलाना

कोड को `server.py` के रूप में सेव करें और कमांड लाइन से चलाएं:

```bash
python server.py
```

सर्वर शुरू हो जाएगा और stdin से इनपुट की प्रतीक्षा करेगा। यह stdio ट्रांसपोर्ट पर JSON-RPC संदेशों का उपयोग करके संवाद करता है।

### चरण 4: Inspector के साथ परीक्षण करना

आप अपने सर्वर का परीक्षण MCP Inspector का उपयोग करके कर सकते हैं:

1. Inspector इंस्टॉल करें: `npx @modelcontextprotocol/inspector`
2. Inspector चलाएं और इसे अपने सर्वर की ओर इंगित करें।
3. आपने जो टूल्स बनाए हैं, उनका परीक्षण करें।

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

1. पहले कुछ टूल्स बनाएं। इसके लिए हम *Tools.cs* नामक फाइल बनाएंगे जिसमें निम्नलिखित सामग्री होगी:

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

2. **वेब इंटरफेस खोलें**: Inspector एक ब्राउज़र विंडो खोलेगा जिसमें आपके सर्वर की क्षमताएं दिखाई देंगी।

3. **टूल्स का परीक्षण करें**: 
   - `get_greeting` टूल को विभिन्न नामों के साथ आज़माएं।
   - `calculate_sum` टूल को विभिन्न संख्याओं के साथ परीक्षण करें।
   - `get_server_info` टूल को कॉल करें ताकि सर्वर मेटाडेटा देखा जा सके।

4. **संचार की निगरानी करें**: Inspector JSON-RPC संदेशों को दिखाता है जो क्लाइंट और सर्वर के बीच एक्सचेंज किए जा रहे हैं।

### आपको क्या देखना चाहिए

जब आपका सर्वर सही तरीके से शुरू हो जाता है, तो आपको निम्नलिखित दिखाई देंगे:
- Inspector में सर्वर की क्षमताएं सूचीबद्ध।
- परीक्षण के लिए उपलब्ध टूल्स।
- सफल JSON-RPC संदेश एक्सचेंज।
- इंटरफेस में टूल प्रतिक्रियाएं प्रदर्शित।

### सामान्य समस्याएं और समाधान

**सर्वर शुरू नहीं हो रहा है:**
- सुनिश्चित करें कि सभी डिपेंडेंसीज़ इंस्टॉल हैं: `pip install mcp`
- Python सिंटैक्स और इंडेंटेशन की जांच करें।
- कंसोल में त्रुटि संदेश देखें।

**टूल्स दिखाई नहीं दे रहे हैं:**
- सुनिश्चित करें कि `@server.tool()` डेकोरेटर्स मौजूद हैं।
- जांचें कि टूल फंक्शन्स `main()` से पहले परिभाषित हैं।
- सुनिश्चित करें कि सर्वर सही तरीके से कॉन्फ़िगर है।

**कनेक्शन समस्याएं:**
- सुनिश्चित करें कि सर्वर stdio ट्रांसपोर्ट का सही तरीके से उपयोग कर रहा है।
- जांचें कि कोई अन्य प्रक्रिया हस्तक्षेप नहीं कर रही है।
- Inspector कमांड सिंटैक्स की जांच करें।

## असाइनमेंट

अपने सर्वर को और अधिक क्षमताओं के साथ बनाने का प्रयास करें। उदाहरण के लिए, [इस पेज](https://api.chucknorris.io/) को देखें और एक ऐसा टूल जोड़ें जो API को कॉल करता हो। आप तय करें कि सर्वर कैसा दिखना चाहिए। मज़े करें :)

## समाधान

[Solution](./solution/README.md) यहां एक संभावित समाधान है जिसमें कार्यशील कोड शामिल है।

## मुख्य बातें

इस अध्याय की मुख्य बातें निम्नलिखित हैं:

- stdio ट्रांसपोर्ट स्थानीय MCP सर्वरों के लिए अनुशंसित मैकेनिज़्म है।
- stdio ट्रांसपोर्ट MCP सर्वरों और क्लाइंट्स के बीच स्टैंडर्ड इनपुट और आउटपुट स्ट्रीम्स का उपयोग करके सहज संचार की अनुमति देता है।
- आप Inspector और Visual Studio Code दोनों का उपयोग करके stdio सर्वरों का उपभोग कर सकते हैं, जिससे डिबगिंग और एकीकरण आसान हो जाता है।

## नमूने 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## अतिरिक्त संसाधन

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## आगे क्या

## अगले कदम

अब जब आपने stdio ट्रांसपोर्ट के साथ MCP सर्वर बनाना सीख लिया है, तो आप अधिक उन्नत विषयों का पता लगा सकते हैं:

- **अगला**: [MCP के साथ HTTP स्ट्रीमिंग (Streamable HTTP)](../06-http-streaming/README.md) - रिमोट सर्वरों के लिए समर्थित अन्य ट्रांसपोर्ट मैकेनिज़्म के बारे में जानें।
- **उन्नत**: [MCP सुरक्षा सर्वोत्तम प्रथाएं](../../02-Security/README.md) - अपने MCP सर्वरों में सुरक्षा लागू करें।
- **उत्पादन**: [डिप्लॉयमेंट रणनीतियां](../09-deployment/README.md) - अपने सर्वरों को उत्पादन उपयोग के लिए तैनात करें।

## अतिरिक्त संसाधन

- [MCP स्पेसिफिकेशन 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - आधिकारिक स्पेसिफिकेशन।
- [MCP SDK डाक्यूमेंटेशन](https://github.com/modelcontextprotocol/sdk) - सभी भाषाओं के लिए SDK संदर्भ।
- [सामुदायिक उदाहरण](../../06-CommunityContributions/README.md) - समुदाय से अधिक सर्वर उदाहरण।

---

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता सुनिश्चित करने का प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियां या अशुद्धियां हो सकती हैं। मूल भाषा में उपलब्ध मूल दस्तावेज़ को प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।