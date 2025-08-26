<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:25:53+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "bn"
}
-->
# MCP সার্ভার stdio পরিবহন সহ

> **⚠️ গুরুত্বপূর্ণ আপডেট**: MCP স্পেসিফিকেশন ২০২৫-০৬-১৮ অনুযায়ী, স্ট্যান্ডঅ্যালোন SSE (Server-Sent Events) পরিবহন **অপ্রচলিত** এবং "Streamable HTTP" পরিবহনে প্রতিস্থাপিত হয়েছে। বর্তমান MCP স্পেসিফিকেশন দুটি প্রধান পরিবহন পদ্ধতি সংজ্ঞায়িত করে:
> 1. **stdio** - স্ট্যান্ডার্ড ইনপুট/আউটপুট (স্থানীয় সার্ভারের জন্য সুপারিশকৃত)
> 2. **Streamable HTTP** - দূরবর্তী সার্ভারের জন্য যা অভ্যন্তরীণভাবে SSE ব্যবহার করতে পারে
>
> এই পাঠটি **stdio পরিবহন**-এর উপর কেন্দ্রীভূত করা হয়েছে, যা বেশিরভাগ MCP সার্ভার বাস্তবায়নের জন্য সুপারিশকৃত পদ্ধতি।

stdio পরিবহন MCP সার্ভারগুলিকে স্ট্যান্ডার্ড ইনপুট এবং আউটপুট স্ট্রিমের মাধ্যমে ক্লায়েন্টদের সাথে যোগাযোগ করতে দেয়। এটি বর্তমান MCP স্পেসিফিকেশনে সবচেয়ে সাধারণ এবং সুপারিশকৃত পরিবহন পদ্ধতি, যা MCP সার্ভার তৈরি করার একটি সহজ এবং কার্যকর উপায় প্রদান করে যা বিভিন্ন ক্লায়েন্ট অ্যাপ্লিকেশনের সাথে সহজেই সংহত করা যায়।

## সংক্ষিপ্ত বিবরণ

এই পাঠটি stdio পরিবহন ব্যবহার করে MCP সার্ভার তৈরি এবং ব্যবহার করার পদ্ধতি কভার করে।

## শেখার লক্ষ্য

এই পাঠ শেষে, আপনি সক্ষম হবেন:

- stdio পরিবহন ব্যবহার করে MCP সার্ভার তৈরি করতে।
- MCP সার্ভারকে Inspector দিয়ে ডিবাগ করতে।
- Visual Studio Code ব্যবহার করে MCP সার্ভার ব্যবহার করতে।
- বর্তমান MCP পরিবহন পদ্ধতি এবং stdio কেন সুপারিশকৃত তা বুঝতে।

## stdio পরিবহন - এটি কীভাবে কাজ করে

stdio পরিবহন বর্তমান MCP স্পেসিফিকেশনে (২০২৫-০৬-১৮) সমর্থিত দুটি পরিবহন প্রকারের একটি। এটি কীভাবে কাজ করে:

- **সহজ যোগাযোগ**: সার্ভার স্ট্যান্ডার্ড ইনপুট (`stdin`) থেকে JSON-RPC বার্তা পড়ে এবং স্ট্যান্ডার্ড আউটপুট (`stdout`) এ বার্তা পাঠায়।
- **প্রক্রিয়া-ভিত্তিক**: ক্লায়েন্ট MCP সার্ভারকে একটি সাবপ্রক্রিয়া হিসাবে চালু করে।
- **বার্তা বিন্যাস**: বার্তাগুলি পৃথক JSON-RPC অনুরোধ, বিজ্ঞপ্তি বা প্রতিক্রিয়া, যা নতুন লাইনের মাধ্যমে পৃথক করা হয়।
- **লগিং**: সার্ভার লগিং উদ্দেশ্যে স্ট্যান্ডার্ড ত্রুটি (`stderr`) এ UTF-8 স্ট্রিং লিখতে পারে।

### প্রধান প্রয়োজনীয়তা:
- বার্তাগুলি অবশ্যই নতুন লাইনের মাধ্যমে পৃথক করা হবে এবং বার্তাগুলিতে এম্বেডেড নতুন লাইন থাকা যাবে না।
- সার্ভার `stdout`-এ এমন কিছু লিখতে পারবে না যা বৈধ MCP বার্তা নয়।
- ক্লায়েন্ট `stdin`-এ সার্ভারের জন্য এমন কিছু লিখতে পারবে না যা বৈধ MCP বার্তা নয়।

### টাইপস্ক্রিপ্ট

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

উপরের কোডে:

- আমরা MCP SDK থেকে `Server` ক্লাস এবং `StdioServerTransport` আমদানি করি।
- আমরা মৌলিক কনফিগারেশন এবং সক্ষমতা সহ একটি সার্ভার ইনস্ট্যান্স তৈরি করি।

### পাইথন

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

উপরের কোডে আমরা:

- MCP SDK ব্যবহার করে একটি সার্ভার ইনস্ট্যান্স তৈরি করি।
- ডেকোরেটর ব্যবহার করে টুল সংজ্ঞায়িত করি।
- stdio_server কন্টেক্সট ম্যানেজার ব্যবহার করে পরিবহন পরিচালনা করি।

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

SSE থেকে stdio সার্ভারের মূল পার্থক্য:

- ওয়েব সার্ভার সেটআপ বা HTTP এন্ডপয়েন্টের প্রয়োজন নেই।
- ক্লায়েন্ট সার্ভারকে সাবপ্রক্রিয়া হিসাবে চালু করে।
- stdin/stdout স্ট্রিমের মাধ্যমে যোগাযোগ করে।
- বাস্তবায়ন এবং ডিবাগিং সহজ।

## অনুশীলন: একটি stdio সার্ভার তৈরি করা

আমাদের সার্ভার তৈরি করতে, দুটি বিষয় মনে রাখতে হবে:

- সংযোগ এবং বার্তার জন্য এন্ডপয়েন্ট প্রকাশ করতে একটি ওয়েব সার্ভার ব্যবহার করতে হবে।
## ল্যাব: একটি সাধারণ MCP stdio সার্ভার তৈরি করা

এই ল্যাবে, আমরা stdio পরিবহন ব্যবহার করে একটি সাধারণ MCP সার্ভার তৈরি করব। এই সার্ভারটি এমন টুল প্রকাশ করবে যা ক্লায়েন্টরা স্ট্যান্ডার্ড Model Context Protocol ব্যবহার করে কল করতে পারে।

### প্রয়োজনীয়তা

- পাইথন ৩.৮ বা তার বেশি
- MCP পাইথন SDK: `pip install mcp`
- অ্যাসিঙ্ক প্রোগ্রামিংয়ের মৌলিক ধারণা

চলুন আমাদের প্রথম MCP stdio সার্ভার তৈরি করি:

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

## অপ্রচলিত SSE পদ্ধতির সাথে মূল পার্থক্য

**Stdio পরিবহন (বর্তমান মান):**
- সহজ সাবপ্রক্রিয়া মডেল - ক্লায়েন্ট সার্ভারকে চাইল্ড প্রক্রেস হিসাবে চালু করে।
- stdin/stdout ব্যবহার করে JSON-RPC বার্তার মাধ্যমে যোগাযোগ।
- HTTP সার্ভার সেটআপের প্রয়োজন নেই।
- উন্নত পারফরম্যান্স এবং নিরাপত্তা।
- ডিবাগিং এবং ডেভেলপমেন্ট সহজ।

**SSE পরিবহন (MCP ২০২৫-০৬-১৮ অনুযায়ী অপ্রচলিত):**
- SSE এন্ডপয়েন্ট সহ HTTP সার্ভারের প্রয়োজন ছিল।
- ওয়েব সার্ভার অবকাঠামো সহ আরও জটিল সেটআপ।
- HTTP এন্ডপয়েন্টের জন্য অতিরিক্ত নিরাপত্তা বিবেচনা।
- ওয়েব-ভিত্তিক পরিস্থিতির জন্য Streamable HTTP দ্বারা প্রতিস্থাপিত।

### stdio পরিবহন সহ একটি সার্ভার তৈরি করা

stdio সার্ভার তৈরি করতে আমাদের করতে হবে:

1. **প্রয়োজনীয় লাইব্রেরি আমদানি করা** - MCP সার্ভার কম্পোনেন্ট এবং stdio পরিবহন প্রয়োজন।
2. **একটি সার্ভার ইনস্ট্যান্স তৈরি করা** - সার্ভারের সক্ষমতা সংজ্ঞায়িত করা।
3. **টুল সংজ্ঞায়িত করা** - আমরা যে কার্যকারিতা প্রকাশ করতে চাই তা যোগ করা।
4. **পরিবহন সেটআপ করা** - stdio যোগাযোগ কনফিগার করা।
5. **সার্ভার চালানো** - সার্ভার শুরু করা এবং বার্তা পরিচালনা করা।

চলুন ধাপে ধাপে এটি তৈরি করি:

### ধাপ ১: একটি মৌলিক stdio সার্ভার তৈরি করা

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

### ধাপ ২: আরও টুল যোগ করা

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

### ধাপ ৩: সার্ভার চালানো

কোডটি `server.py` নামে সংরক্ষণ করুন এবং কমান্ড লাইন থেকে চালান:

```bash
python server.py
```

সার্ভার শুরু হবে এবং stdin থেকে ইনপুটের জন্য অপেক্ষা করবে। এটি stdio পরিবহন ব্যবহার করে JSON-RPC বার্তার মাধ্যমে যোগাযোগ করে।

### ধাপ ৪: Inspector দিয়ে পরীক্ষা করা

আপনার সার্ভার MCP Inspector ব্যবহার করে পরীক্ষা করতে পারেন:

1. Inspector ইনস্টল করুন: `npx @modelcontextprotocol/inspector`
2. Inspector চালান এবং আপনার সার্ভারের দিকে নির্দেশ করুন।
3. আপনি যে টুল তৈরি করেছেন তা পরীক্ষা করুন।

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

1. প্রথমে কিছু টুল তৈরি করি, এর জন্য আমরা *Tools.cs* নামে একটি ফাইল তৈরি করব যার মধ্যে নিম্নলিখিত বিষয়বস্তু থাকবে:

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

2. **ওয়েব ইন্টারফেস খুলুন**: Inspector একটি ব্রাউজার উইন্ডো খুলবে যেখানে আপনার সার্ভারের সক্ষমতা দেখাবে।

3. **টুল পরীক্ষা করুন**: 
   - বিভিন্ন নাম দিয়ে `get_greeting` টুল পরীক্ষা করুন।
   - বিভিন্ন সংখ্যার সাথে `calculate_sum` টুল পরীক্ষা করুন।
   - সার্ভারের মেটাডেটা দেখতে `get_server_info` টুল কল করুন।

4. **যোগাযোগ পর্যবেক্ষণ করুন**: Inspector ক্লায়েন্ট এবং সার্ভারের মধ্যে বিনিময় হওয়া JSON-RPC বার্তা দেখায়।

### আপনি যা দেখতে পাবেন

যখন আপনার সার্ভার সঠিকভাবে শুরু হয়, আপনি দেখতে পাবেন:
- Inspector-এ সার্ভারের সক্ষমতা তালিকাভুক্ত।
- পরীক্ষার জন্য টুল উপলব্ধ।
- সফল JSON-RPC বার্তা বিনিময়।
- ইন্টারফেসে টুল প্রতিক্রিয়া প্রদর্শিত।

### সাধারণ সমস্যা এবং সমাধান

**সার্ভার শুরু হচ্ছে না:**
- নিশ্চিত করুন যে সমস্ত নির্ভরতা ইনস্টল করা হয়েছে: `pip install mcp`
- পাইথন সিনট্যাক্স এবং ইন্ডেন্টেশন যাচাই করুন।
- কনসোলে ত্রুটি বার্তা দেখুন।

**টুল প্রদর্শিত হচ্ছে না:**
- নিশ্চিত করুন যে `@server.tool()` ডেকোরেটর উপস্থিত আছে।
- টুল ফাংশনগুলি `main()` এর আগে সংজ্ঞায়িত করা হয়েছে কিনা তা যাচাই করুন।
- নিশ্চিত করুন যে সার্ভার সঠিকভাবে কনফিগার করা হয়েছে।

**সংযোগ সমস্যা:**
- নিশ্চিত করুন যে সার্ভার সঠিকভাবে stdio পরিবহন ব্যবহার করছে।
- নিশ্চিত করুন যে অন্য কোনো প্রক্রিয়া বাধা দিচ্ছে না।
- Inspector কমান্ড সিনট্যাক্স যাচাই করুন।

## অ্যাসাইনমেন্ট

আপনার সার্ভার আরও সক্ষমতা দিয়ে তৈরি করার চেষ্টা করুন। [এই পৃষ্ঠা](https://api.chucknorris.io/) দেখুন, উদাহরণস্বরূপ, একটি টুল যোগ করতে যা একটি API কল করে। আপনি সিদ্ধান্ত নিন সার্ভারটি কেমন হবে। মজা করুন :)

## সমাধান

[সমাধান](./solution/README.md) এখানে একটি সম্ভাব্য সমাধান রয়েছে কার্যকর কোড সহ।

## মূল বিষয়গুলো

এই অধ্যায়ের মূল বিষয়গুলো হল:

- stdio পরিবহন স্থানীয় MCP সার্ভারের জন্য সুপারিশকৃত পদ্ধতি।
- stdio পরিবহন MCP সার্ভার এবং ক্লায়েন্টদের মধ্যে স্ট্যান্ডার্ড ইনপুট এবং আউটপুট স্ট্রিম ব্যবহার করে নির্বিঘ্ন যোগাযোগের অনুমতি দেয়।
- আপনি Inspector এবং Visual Studio Code উভয়ই ব্যবহার করে stdio সার্ভার সরাসরি ব্যবহার করতে পারেন, যা ডিবাগিং এবং সংহতকরণকে সহজ করে তোলে।

## নমুনা

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## অতিরিক্ত সম্পদ

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## পরবর্তী কী

## পরবর্তী পদক্ষেপ

এখন আপনি stdio পরিবহন সহ MCP সার্ভার তৈরি করতে শিখেছেন, আপনি আরও উন্নত বিষয়গুলি অন্বেষণ করতে পারেন:

- **পরবর্তী**: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md) - দূরবর্তী সার্ভারের জন্য সমর্থিত অন্য পরিবহন পদ্ধতি সম্পর্কে জানুন।
- **উন্নত**: [MCP Security Best Practices](../../02-Security/README.md) - MCP সার্ভারে নিরাপত্তা বাস্তবায়ন করুন।
- **প্রোডাকশন**: [Deployment Strategies](../09-deployment/README.md) - প্রোডাকশন ব্যবহারের জন্য আপনার সার্ভার মোতায়েন করুন।

## অতিরিক্ত সম্পদ

- [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - অফিসিয়াল স্পেসিফিকেশন।
- [MCP SDK Documentation](https://github.com/modelcontextprotocol/sdk) - সমস্ত ভাষার জন্য SDK রেফারেন্স।
- [Community Examples](../../06-CommunityContributions/README.md) - সম্প্রদায়ের আরও সার্ভার উদাহরণ।

---

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসম্ভব সঠিক অনুবাদ প্রদানের চেষ্টা করি, তবে অনুগ্রহ করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল ভাষায় থাকা নথিটিকে প্রামাণিক উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যা হলে আমরা তার জন্য দায়ী থাকব না।