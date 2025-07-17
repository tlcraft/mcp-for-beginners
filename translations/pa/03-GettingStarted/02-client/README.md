<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:54:44+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "pa"
}
-->
# ਕਲਾਇੰਟ ਬਣਾਉਣਾ

ਕਲਾਇੰਟ ਖਾਸ ਤੌਰ 'ਤੇ ਬਣਾਈਆਂ ਗਈਆਂ ਐਪਲੀਕੇਸ਼ਨਾਂ ਜਾਂ ਸਕ੍ਰਿਪਟਾਂ ਹੁੰਦੀਆਂ ਹਨ ਜੋ ਸਿੱਧਾ MCP ਸਰਵਰ ਨਾਲ ਗੱਲਬਾਤ ਕਰਦੀਆਂ ਹਨ ਤਾਂ ਜੋ ਸਰੋਤ, ਟੂਲ ਅਤੇ ਪ੍ਰਾਂਪਟ ਮੰਗ ਸਕਣ। ਇੰਸਪੈਕਟਰ ਟੂਲ ਵਰਤਣ ਦੇ ਵਿਰੁੱਧ, ਜੋ ਸਰਵਰ ਨਾਲ ਗ੍ਰਾਫਿਕਲ ਇੰਟਰਫੇਸ ਰਾਹੀਂ ਇੰਟਰੈਕਟ ਕਰਨ ਲਈ ਹੁੰਦਾ ਹੈ, ਆਪਣਾ ਕਲਾਇੰਟ ਲਿਖਣ ਨਾਲ ਤੁਸੀਂ ਪ੍ਰੋਗਰਾਮੈਟਿਕ ਅਤੇ ਆਟੋਮੇਟਿਕ ਇੰਟਰੈਕਸ਼ਨ ਕਰ ਸਕਦੇ ਹੋ। ਇਸ ਨਾਲ ਡਿਵੈਲਪਰ MCP ਦੀਆਂ ਖੂਬੀਆਂ ਨੂੰ ਆਪਣੇ ਕੰਮ ਦੇ ਤਰੀਕੇ ਵਿੱਚ ਸ਼ਾਮਲ ਕਰ ਸਕਦੇ ਹਨ, ਕੰਮ ਆਟੋਮੇਟ ਕਰ ਸਕਦੇ ਹਨ ਅਤੇ ਖਾਸ ਜ਼ਰੂਰਤਾਂ ਲਈ ਕਸਟਮ ਹੱਲ ਤਿਆਰ ਕਰ ਸਕਦੇ ਹਨ।

## ਝਲਕ

ਇਸ ਪਾਠ ਵਿੱਚ MCP ਪਰਿਪੇਖ ਪ੍ਰੋਟੋਕੋਲ (MCP) ਪਰਿਵਾਰ ਵਿੱਚ ਕਲਾਇੰਟ ਦੀ ਸੰਕਲਪਨਾ ਨੂੰ ਜਾਣੂ ਕਰਵਾਇਆ ਗਿਆ ਹੈ। ਤੁਸੀਂ ਸਿੱਖੋਗੇ ਕਿ ਆਪਣਾ ਕਲਾਇੰਟ ਕਿਵੇਂ ਲਿਖਣਾ ਹੈ ਅਤੇ ਇਸਨੂੰ MCP ਸਰਵਰ ਨਾਲ ਕਿਵੇਂ ਜੋੜਨਾ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੀ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- ਸਮਝਣਾ ਕਿ ਕਲਾਇੰਟ ਕੀ ਕਰ ਸਕਦਾ ਹੈ।
- ਆਪਣਾ ਕਲਾਇੰਟ ਲਿਖਣਾ।
- ਕਲਾਇੰਟ ਨੂੰ MCP ਸਰਵਰ ਨਾਲ ਜੋੜ ਕੇ ਟੈਸਟ ਕਰਨਾ ਤਾਂ ਜੋ ਇਹ ਯਕੀਨੀ ਬਣਾਇਆ ਜਾ ਸਕੇ ਕਿ ਸਰਵਰ ਠੀਕ ਕੰਮ ਕਰ ਰਿਹਾ ਹੈ।

## ਕਲਾਇੰਟ ਲਿਖਣ ਵਿੱਚ ਕੀ ਸ਼ਾਮਲ ਹੁੰਦਾ ਹੈ?

ਕਲਾਇੰਟ ਲਿਖਣ ਲਈ, ਤੁਹਾਨੂੰ ਇਹ ਕਰਨਾ ਪਵੇਗਾ:

- **ਸਹੀ ਲਾਇਬ੍ਰੇਰੀਆਂ ਇੰਪੋਰਟ ਕਰੋ।** ਤੁਸੀਂ ਪਹਿਲਾਂ ਵਰਤੀ ਗਈ ਲਾਇਬ੍ਰੇਰੀ ਹੀ ਵਰਤੋਂਗੇ, ਸਿਰਫ਼ ਵੱਖ-ਵੱਖ ਤਰੀਕੇ ਨਾਲ।
- **ਕਲਾਇੰਟ ਦਾ ਉਦਾਹਰਨ ਬਣਾਓ।** ਇਸ ਵਿੱਚ ਕਲਾਇੰਟ ਦਾ ਇਕ ਉਦਾਹਰਨ ਬਣਾਉਣਾ ਅਤੇ ਇਸਨੂੰ ਚੁਣੇ ਹੋਏ ਟ੍ਰਾਂਸਪੋਰਟ ਤਰੀਕੇ ਨਾਲ ਜੋੜਨਾ ਸ਼ਾਮਲ ਹੈ।
- **ਫੈਸਲਾ ਕਰੋ ਕਿ ਕਿਹੜੇ ਸਰੋਤ ਲਿਸਟ ਕਰਨੇ ਹਨ।** ਤੁਹਾਡੇ MCP ਸਰਵਰ ਕੋਲ ਸਰੋਤ, ਟੂਲ ਅਤੇ ਪ੍ਰਾਂਪਟ ਹੁੰਦੇ ਹਨ, ਤੁਹਾਨੂੰ ਇਹ ਫੈਸਲਾ ਕਰਨਾ ਹੈ ਕਿ ਕਿਹੜੇ ਲਿਸਟ ਕਰਨੇ ਹਨ।
- **ਕਲਾਇੰਟ ਨੂੰ ਹੋਸਟ ਐਪਲੀਕੇਸ਼ਨ ਨਾਲ ਜੋੜੋ।** ਜਦੋਂ ਤੁਹਾਨੂੰ ਸਰਵਰ ਦੀਆਂ ਖੂਬੀਆਂ ਪਤਾ ਲੱਗ ਜਾਣ, ਤਾਂ ਇਸਨੂੰ ਆਪਣੇ ਹੋਸਟ ਐਪਲੀਕੇਸ਼ਨ ਵਿੱਚ ਸ਼ਾਮਲ ਕਰੋ ਤਾਂ ਜੋ ਜੇ ਕੋਈ ਯੂਜ਼ਰ ਪ੍ਰਾਂਪਟ ਜਾਂ ਹੋਰ ਕਮਾਂਡ ਟਾਈਪ ਕਰੇ ਤਾਂ ਉਸਦੇ ਅਨੁਸਾਰ ਸਰਵਰ ਦੀ ਖਾਸੀਅਤ ਚਾਲੂ ਹੋ ਜਾਵੇ।

ਹੁਣ ਜਦੋਂ ਅਸੀਂ ਉੱਚ ਸਤਰ 'ਤੇ ਸਮਝ ਗਏ ਹਾਂ ਕਿ ਅਸੀਂ ਕੀ ਕਰਨ ਜਾ ਰਹੇ ਹਾਂ, ਆਓ ਅਗਲੇ ਹਿੱਸੇ ਵਿੱਚ ਇੱਕ ਉਦਾਹਰਨ ਵੇਖੀਏ।

### ਇੱਕ ਉਦਾਹਰਨ ਕਲਾਇੰਟ

ਆਓ ਇਸ ਉਦਾਹਰਨ ਕਲਾਇੰਟ ਨੂੰ ਵੇਖੀਏ:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

ਉਪਰ ਦਿੱਤੇ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਲਾਇਬ੍ਰੇਰੀਆਂ ਇੰਪੋਰਟ ਕੀਤੀਆਂ
- ਇੱਕ ਕਲਾਇੰਟ ਦਾ ਉਦਾਹਰਨ ਬਣਾਇਆ ਅਤੇ stdio ਟ੍ਰਾਂਸਪੋਰਟ ਰਾਹੀਂ ਜੋੜਿਆ
- ਪ੍ਰਾਂਪਟ, ਸਰੋਤ ਅਤੇ ਟੂਲ ਲਿਸਟ ਕੀਤੇ ਅਤੇ ਸਾਰੇ ਚਲਾਏ

ਇਹ ਲੈ, ਇੱਕ ਕਲਾਇੰਟ ਜੋ MCP ਸਰਵਰ ਨਾਲ ਗੱਲ ਕਰ ਸਕਦਾ ਹੈ।

ਅਗਲੇ ਅਭਿਆਸ ਹਿੱਸੇ ਵਿੱਚ ਅਸੀਂ ਹਰ ਕੋਡ ਟੁਕੜੇ ਨੂੰ ਵੱਖ-ਵੱਖ ਸਮਝਾਂਗੇ ਅਤੇ ਵਿਆਖਿਆ ਕਰਾਂਗੇ ਕਿ ਕੀ ਹੋ ਰਿਹਾ ਹੈ।

## ਅਭਿਆਸ: ਕਲਾਇੰਟ ਲਿਖਣਾ

ਜਿਵੇਂ ਉਪਰ ਕਿਹਾ ਗਿਆ, ਆਓ ਕੋਡ ਨੂੰ ਸਮਝਣ ਲਈ ਸਮਾਂ ਲਵਾਂ ਅਤੇ ਜੇ ਤੁਸੀਂ ਚਾਹੋ ਤਾਂ ਨਾਲ ਨਾਲ ਕੋਡ ਵੀ ਕਰੋ।

### -1- ਲਾਇਬ੍ਰੇਰੀਆਂ ਇੰਪੋਰਟ ਕਰਨਾ

ਆਓ ਲਾਇਬ੍ਰੇਰੀਆਂ ਇੰਪੋਰਟ ਕਰੀਏ ਜੋ ਸਾਨੂੰ ਚਾਹੀਦੀਆਂ ਹਨ, ਸਾਨੂੰ ਕਲਾਇੰਟ ਅਤੇ ਚੁਣੇ ਹੋਏ ਟ੍ਰਾਂਸਪੋਰਟ ਪ੍ਰੋਟੋਕੋਲ stdio ਦੀ ਲੋੜ ਹੋਵੇਗੀ। stdio ਉਹ ਪ੍ਰੋਟੋਕੋਲ ਹੈ ਜੋ ਤੁਹਾਡੇ ਲੋਕਲ ਮਸ਼ੀਨ 'ਤੇ ਚੱਲਣ ਵਾਲੀਆਂ ਚੀਜ਼ਾਂ ਲਈ ਬਣਾਇਆ ਗਿਆ ਹੈ। SSE ਇੱਕ ਹੋਰ ਟ੍ਰਾਂਸਪੋਰਟ ਪ੍ਰੋਟੋਕੋਲ ਹੈ ਜੋ ਅਸੀਂ ਅਗਲੇ ਅਧਿਆਇਆਂ ਵਿੱਚ ਵੇਖਾਂਗੇ, ਪਰ ਇਸ ਵੇਲੇ ਲਈ stdio ਨਾਲ ਹੀ ਅੱਗੇ ਵਧੀਏ।

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

Java ਲਈ, ਤੁਸੀਂ ਇੱਕ ਕਲਾਇੰਟ ਬਣਾਓਗੇ ਜੋ ਪਿਛਲੇ ਅਭਿਆਸ ਤੋਂ MCP ਸਰਵਰ ਨਾਲ ਜੁੜਦਾ ਹੈ। [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) ਵਿੱਚ ਦਿੱਤੇ ਗਏ Java Spring Boot ਪ੍ਰੋਜੈਕਟ ਸਟ੍ਰਕਚਰ ਦੀ ਵਰਤੋਂ ਕਰਦੇ ਹੋਏ, `src/main/java/com/microsoft/mcp/sample/client/` ਫੋਲਡਰ ਵਿੱਚ `SDKClient` ਨਾਮ ਦੀ ਨਵੀਂ Java ਕਲਾਸ ਬਣਾਓ ਅਤੇ ਹੇਠਾਂ ਦਿੱਤੇ ਇੰਪੋਰਟ ਸ਼ਾਮਲ ਕਰੋ:

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

ਹੁਣ ਅਸੀਂ ਇੰਸਟੈਂਸ਼ੀਏਸ਼ਨ ਵੱਲ ਵਧੀਏ।

### -2- ਕਲਾਇੰਟ ਅਤੇ ਟ੍ਰਾਂਸਪੋਰਟ ਦੀ ਇੰਸਟੈਂਸ਼ੀਏਸ਼ਨ

ਸਾਨੂੰ ਟ੍ਰਾਂਸਪੋਰਟ ਅਤੇ ਕਲਾਇੰਟ ਦੋਹਾਂ ਦੇ ਉਦਾਹਰਨ ਬਣਾਉਣੇ ਪੈਣਗੇ:

### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

ਉਪਰ ਦਿੱਤੇ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- stdio ਟ੍ਰਾਂਸਪੋਰਟ ਦਾ ਉਦਾਹਰਨ ਬਣਾਇਆ। ਧਿਆਨ ਦਿਓ ਕਿ ਇਸ ਵਿੱਚ ਕਮਾਂਡ ਅਤੇ ਆਰਗਸ ਦਿੱਤੇ ਗਏ ਹਨ ਜੋ ਸਰਵਰ ਨੂੰ ਲੱਭਣ ਅਤੇ ਚਾਲੂ ਕਰਨ ਲਈ ਹਨ, ਕਿਉਂਕਿ ਇਹ ਕੁਝ ਅਜਿਹਾ ਹੈ ਜੋ ਅਸੀਂ ਕਲਾਇੰਟ ਬਣਾਉਂਦੇ ਸਮੇਂ ਕਰਨਾ ਪਵੇਗਾ।

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- ਕਲਾਇੰਟ ਨੂੰ ਨਾਮ ਅਤੇ ਵਰਜਨ ਦੇ ਕੇ ਇੰਸਟੈਂਸ਼ੀਏਟ ਕੀਤਾ।

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- ਕਲਾਇੰਟ ਨੂੰ ਚੁਣੇ ਹੋਏ ਟ੍ਰਾਂਸਪੋਰਟ ਨਾਲ ਜੋੜਿਆ।

    ```typescript
    await client.connect(transport);
    ```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)

async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()

          

if __name__ == "__main__":
    import asyncio

    asyncio.run(run())
```

ਉਪਰ ਦਿੱਤੇ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਲੋੜੀਂਦੀਆਂ ਲਾਇਬ੍ਰੇਰੀਆਂ ਇੰਪੋਰਟ ਕੀਤੀਆਂ
- ਸਰਵਰ ਪੈਰਾਮੀਟਰਾਂ ਦਾ ਇੱਕ ਆਬਜੈਕਟ ਬਣਾਇਆ ਕਿਉਂਕਿ ਅਸੀਂ ਇਸਨੂੰ ਸਰਵਰ ਚਲਾਉਣ ਲਈ ਵਰਤਾਂਗੇ ਤਾਂ ਜੋ ਕਲਾਇੰਟ ਨਾਲ ਜੁੜ ਸਕੀਏ
- ਇੱਕ `run` ਮੈਥਡ ਬਣਾਇਆ ਜੋ `stdio_client` ਨੂੰ ਕਾਲ ਕਰਦਾ ਹੈ ਜੋ ਕਲਾਇੰਟ ਸੈਸ਼ਨ ਸ਼ੁਰੂ ਕਰਦਾ ਹੈ
- ਇੱਕ ਐਂਟਰੀ ਪੌਇੰਟ ਬਣਾਇਆ ਜਿੱਥੇ ਅਸੀਂ `run` ਮੈਥਡ ਨੂੰ `asyncio.run` ਨੂੰ ਦਿੰਦੇ ਹਾਂ

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

ਉਪਰ ਦਿੱਤੇ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਲੋੜੀਂਦੀਆਂ ਲਾਇਬ੍ਰੇਰੀਆਂ ਇੰਪੋਰਟ ਕੀਤੀਆਂ
- stdio ਟ੍ਰਾਂਸਪੋਰਟ ਬਣਾਇਆ ਅਤੇ `mcpClient` ਕਲਾਇੰਟ ਬਣਾਇਆ। ਇਹ ਅਸੀਂ MCP ਸਰਵਰ 'ਤੇ ਫੀਚਰ ਲਿਸਟ ਕਰਨ ਅਤੇ ਚਲਾਉਣ ਲਈ ਵਰਤਾਂਗੇ।

ਨੋਟ ਕਰੋ, "Arguments" ਵਿੱਚ ਤੁਸੀਂ *.csproj* ਜਾਂ ਐਗਜ਼ਿਕਿਊਟੇਬਲ ਦਿਸ਼ਾ ਦਰਸ਼ਾ ਸਕਦੇ ਹੋ।

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

ਉਪਰ ਦਿੱਤੇ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਇੱਕ ਮੈਨ ਮੈਥਡ ਬਣਾਇਆ ਜੋ SSE ਟ੍ਰਾਂਸਪੋਰਟ ਸੈੱਟ ਕਰਦਾ ਹੈ ਜੋ `http://localhost:8080` ਨੂੰ ਪੌਇੰਟ ਕਰਦਾ ਹੈ ਜਿੱਥੇ MCP ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੋਵੇਗਾ
- ਇੱਕ ਕਲਾਇੰਟ ਕਲਾਸ ਬਣਾਈ ਜੋ ਟ੍ਰਾਂਸਪੋਰਟ ਨੂੰ ਕਨਸਟ੍ਰਕਟਰ ਪੈਰਾਮੀਟਰ ਵਜੋਂ ਲੈਂਦੀ ਹੈ
- `run` ਮੈਥਡ ਵਿੱਚ, ਅਸੀਂ ਟ੍ਰਾਂਸਪੋਰਟ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸਿੰਕ੍ਰੋਨਸ MCP ਕਲਾਇੰਟ ਬਣਾਉਂਦੇ ਹਾਂ ਅਤੇ ਕਨੈਕਸ਼ਨ ਸ਼ੁਰੂ ਕਰਦੇ ਹਾਂ
- SSE (Server-Sent Events) ਟ੍ਰਾਂਸਪੋਰਟ ਵਰਤਿਆ ਜੋ HTTP-ਅਧਾਰਿਤ Java Spring Boot MCP ਸਰਵਰਾਂ ਲਈ موزوں ਹੈ

### -3- ਸਰਵਰ ਫੀਚਰਾਂ ਦੀ ਲਿਸਟਿੰਗ

ਹੁਣ ਸਾਡੇ ਕੋਲ ਇੱਕ ਕਲਾਇੰਟ ਹੈ ਜੋ ਜੁੜ ਸਕਦਾ ਹੈ ਜੇਕਰ ਪ੍ਰੋਗਰਾਮ ਚਲਾਇਆ ਜਾਵੇ। ਪਰ ਇਹ ਅਜੇ ਤੱਕ ਆਪਣੇ ਫੀਚਰਾਂ ਨੂੰ ਲਿਸਟ ਨਹੀਂ ਕਰਦਾ, ਆਓ ਹੁਣ ਇਹ ਕਰੀਏ:

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
```

ਇੱਥੇ ਅਸੀਂ ਉਪਲਬਧ ਸਰੋਤ `list_resources()` ਅਤੇ ਟੂਲ `list_tools` ਨੂੰ ਲਿਸਟ ਕਰਕੇ ਪ੍ਰਿੰਟ ਕਰਦੇ ਹਾਂ।

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

ਉਪਰ ਦਿੱਤਾ ਉਦਾਹਰਨ ਹੈ ਕਿ ਅਸੀਂ ਸਰਵਰ 'ਤੇ ਟੂਲ ਕਿਵੇਂ ਲਿਸਟ ਕਰ ਸਕਦੇ ਹਾਂ। ਹਰ ਟੂਲ ਲਈ, ਅਸੀਂ ਉਸਦਾ ਨਾਮ ਪ੍ਰਿੰਟ ਕਰਦੇ ਹਾਂ।

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

ਉਪਰ ਦਿੱਤੇ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- MCP ਸਰਵਰ ਤੋਂ ਸਾਰੇ ਉਪਲਬਧ ਟੂਲ ਲੈਣ ਲਈ `listTools()` ਕਾਲ ਕੀਤਾ
- ਸਰਵਰ ਨਾਲ ਕਨੈਕਸ਼ਨ ਚੈੱਕ ਕਰਨ ਲਈ `ping()` ਵਰਤਿਆ
- `ListToolsResult` ਵਿੱਚ ਸਾਰੇ ਟੂਲਾਂ ਦੀ ਜਾਣਕਾਰੀ ਹੁੰਦੀ ਹੈ ਜਿਵੇਂ ਕਿ ਨਾਮ, ਵਰਣਨ ਅਤੇ ਇਨਪੁਟ ਸਕੀਮਾ

ਵਧੀਆ, ਹੁਣ ਸਾਡੇ ਕੋਲ ਸਾਰੇ ਫੀਚਰਾਂ ਦੀ ਸੂਚੀ ਹੈ। ਹੁਣ ਸਵਾਲ ਇਹ ਹੈ ਕਿ ਅਸੀਂ ਇਹਨਾਂ ਨੂੰ ਕਦੋਂ ਵਰਤਾਂਗੇ? ਇਹ ਕਲਾਇੰਟ ਬਹੁਤ ਸਧਾਰਣ ਹੈ, ਇਸਦਾ ਮਤਲਬ ਇਹ ਹੈ ਕਿ ਅਸੀਂ ਜਦੋਂ ਚਾਹੀਦਾ ਹੈ ਫੀਚਰਾਂ ਨੂੰ ਖੁਦ ਕਾਲ ਕਰਨਾ ਪਵੇਗਾ। ਅਗਲੇ ਅਧਿਆਇ ਵਿੱਚ ਅਸੀਂ ਇੱਕ ਹੋਰ ਅਡਵਾਂਸਡ ਕਲਾਇੰਟ ਬਣਾਵਾਂਗੇ ਜਿਸਦੇ ਕੋਲ ਆਪਣਾ ਵੱਡਾ ਭਾਸ਼ਾਈ ਮਾਡਲ (LLM) ਹੋਵੇਗਾ। ਪਰ ਇਸ ਵੇਲੇ ਲਈ, ਆਓ ਵੇਖੀਏ ਕਿ ਸਰਵਰ ਦੇ ਫੀਚਰਾਂ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:

### -4- ਫੀਚਰਾਂ ਨੂੰ ਕਾਲ ਕਰਨਾ

ਫੀਚਰਾਂ ਨੂੰ ਕਾਲ ਕਰਨ ਲਈ ਸਾਨੂੰ ਯਕੀਨੀ ਬਣਾਉਣਾ ਪਵੇਗਾ ਕਿ ਅਸੀਂ ਸਹੀ ਆਰਗੂਮੈਂਟ ਦਿੱਤੇ ਹਨ ਅਤੇ ਕੁਝ ਮਾਮਲਿਆਂ ਵਿੱਚ ਉਸ ਚੀਜ਼ ਦਾ ਨਾਮ ਵੀ ਦਿੱਤਾ ਹੈ ਜਿਸਨੂੰ ਅਸੀਂ ਕਾਲ ਕਰਨਾ ਚਾਹੁੰਦੇ ਹਾਂ।

### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

ਉਪਰ ਦਿੱਤੇ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਇੱਕ ਸਰੋਤ ਨੂੰ ਪੜ੍ਹਿਆ, ਅਸੀਂ `readResource()` ਕਾਲ ਕਰਦੇ ਹਾਂ ਜਿਸ ਵਿੱਚ `uri` ਦਿੱਤਾ ਹੁੰਦਾ ਹੈ। ਸਰਵਰ ਪਾਸੇ ਇਹ ਕੁਝ ਇਸ ਤਰ੍ਹਾਂ ਲੱਗਦਾ ਹੈ:

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    ਸਾਡਾ `uri` ਮੁੱਲ `file://example.txt` ਸਰਵਰ ਦੇ `file://{name}` ਨਾਲ ਮੇਲ ਖਾਂਦਾ ਹੈ। `example.txt` ਨੂੰ `name` ਵਜੋਂ ਮੈਪ ਕੀਤਾ ਜਾਵੇਗਾ।

- ਇੱਕ ਟੂਲ ਕਾਲ ਕੀਤਾ, ਅਸੀਂ ਇਸਨੂੰ ਉਸਦੇ `name` ਅਤੇ `arguments` ਦੇ ਕੇ ਕਾਲ ਕਰਦੇ ਹਾਂ:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- ਪ੍ਰਾਂਪਟ ਲਿਆ, ਪ੍ਰਾਂਪਟ ਲੈਣ ਲਈ ਅਸੀਂ `getPrompt()` ਕਾਲ ਕਰਦੇ ਹਾਂ ਜਿਸ ਵਿੱਚ `name` ਅਤੇ `arguments` ਹੁੰਦੇ ਹਨ। ਸਰਵਰ ਕੋਡ ਕੁਝ ਇਸ ਤਰ੍ਹਾਂ ਹੈ:

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    ਅਤੇ ਤੁਹਾਡਾ ਕਲਾਇੰਟ ਕੋਡ ਇਸ ਤਰ੍ਹਾਂ ਹੋਵੇਗਾ ਜੋ ਸਰਵਰ 'ਤੇ ਘੋਸ਼ਿਤ ਕੀਤੇ ਗਏ ਨਾਲ ਮੇਲ ਖਾਂਦਾ ਹੈ:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

ਉਪਰ ਦਿੱਤੇ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- `greeting` ਨਾਮਕ ਸਰੋਤ ਨੂੰ `read_resource` ਨਾਲ ਕਾਲ ਕੀਤਾ
- `add` ਨਾਮਕ ਟੂਲ ਨੂੰ `call_tool` ਨਾਲ ਕਾਲ ਕੀਤਾ

### .NET

1. ਆਓ ਕੁਝ ਕੋਡ ਸ਼ਾਮਲ ਕਰੀਏ ਜੋ ਟੂਲ ਕਾਲ ਕਰਦਾ ਹੈ:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. ਨਤੀਜਾ ਪ੍ਰਿੰਟ ਕਰਨ ਲਈ, ਇਹ ਕੋਡ ਵਰਤੋਂ:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

ਉਪਰ ਦਿੱਤੇ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਕਈ ਕੈਲਕੂਲੇਟਰ ਟੂਲਾਂ ਨੂੰ `callTool()` ਮੈਥਡ ਨਾਲ ਕਾਲ ਕੀਤਾ ਜਿਸ ਵਿੱਚ `CallToolRequest` ਆਬਜੈਕਟ ਹਨ
- ਹਰ ਟੂਲ ਕਾਲ ਵਿੱਚ ਟੂਲ ਦਾ ਨਾਮ ਅਤੇ ਉਸਦੇ ਲਈ ਲੋੜੀਂਦੇ ਆਰਗੂਮੈਂਟਾਂ ਦਾ `Map` ਦਿੱਤਾ ਗਿਆ
- ਸਰਵਰ ਟੂਲ ਖਾਸ ਪੈਰਾਮੀਟਰ ਨਾਮਾਂ ਦੀ ਉਮੀਦ ਕਰਦੇ ਹਨ (ਜਿਵੇਂ "a", "b" ਗਣਿਤੀ ਕਾਰਵਾਈਆਂ ਲਈ)
- ਨਤੀਜੇ `CallToolResult` ਆਬਜੈਕਟ ਵਜੋਂ ਵਾਪਸ ਮਿਲਦੇ ਹਨ ਜਿਸ ਵਿੱਚ ਸਰਵਰ ਤੋਂ ਜਵਾਬ ਹੁੰਦਾ ਹੈ

### -5- ਕਲਾਇੰਟ ਚਲਾਉਣਾ

ਕਲਾਇੰਟ ਚਲਾਉਣ ਲਈ, ਟਰਮੀਨਲ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤੀ ਕਮਾਂਡ ਟਾਈਪ ਕਰੋ:

### TypeScript

ਆਪਣੇ *package.json* ਦੇ "scripts" ਹਿੱਸੇ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤਾ ਐਂਟਰੀ ਸ਼ਾਮਲ ਕਰੋ:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

ਕਲਾਇੰਟ ਨੂੰ ਹੇਠਾਂ ਦਿੱਤੀ ਕਮਾਂਡ ਨਾਲ ਕਾਲ ਕਰੋ:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

ਸਭ ਤੋਂ ਪਹਿਲਾਂ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਹਾਡਾ MCP ਸਰਵਰ `http://localhost:8080` 'ਤੇ ਚੱਲ ਰਿਹਾ ਹੈ। ਫਿਰ ਕਲਾਇੰਟ ਚਲਾਓ:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਤੁਸੀਂ ਸੌਲਿਊਸ਼ਨ ਫੋਲਡਰ `03-GettingStarted\02-client\solution\java` ਵਿੱਚ ਦਿੱਤਾ ਪੂਰਾ ਕਲਾਇੰਟ ਪ੍ਰੋਜੈਕਟ ਵੀ ਚਲਾ ਸਕਦੇ ਹੋ:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## ਅਸਾਈਨਮੈਂਟ

ਇਸ ਅਸਾਈਨਮੈਂਟ ਵਿੱਚ, ਤੁਸੀਂ ਜੋ ਸਿੱਖਿਆ ਹੈ ਉਸਦਾ ਉਪਯੋਗ ਕਰਦੇ ਹੋਏ ਆਪਣਾ ਕਲਾਇੰਟ ਬਣਾਉਗੇ।

ਇੱਥੇ ਇੱਕ ਸਰਵਰ ਹੈ ਜਿਸਨੂੰ ਤੁਸੀਂ ਆਪਣੇ ਕਲਾਇੰਟ ਕੋਡ ਰਾਹੀਂ ਕਾਲ ਕਰਨਾ ਹੈ, ਦੇਖੋ ਕਿ ਕੀ ਤੁਸੀਂ ਸਰਵਰ ਵਿੱਚ ਹੋਰ ਫੀਚਰ ਸ਼ਾਮਲ ਕਰਕੇ ਇਸਨੂੰ ਹੋਰ ਦਿਲਚਸਪ ਬਣਾ ਸਕਦੇ ਹੋ।

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

ਇਸ ਪ੍ਰੋਜੈਕਟ ਨੂੰ ਵੇਖੋ ਕਿ ਤੁਸੀਂ ਕਿਵੇਂ [prompts ਅਤੇ resources ਸ਼ਾਮਲ ਕਰ ਸਕਦੇ ਹੋ](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)।

ਇਸ ਲਿੰਕ ਨੂੰ ਵੀ ਚੈੱਕ ਕਰੋ ਕਿ ਕਿਵੇਂ [prompts ਅਤੇ resources ਕਾਲ ਕਰਨੇ ਹਨ](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/)।

## ਹੱਲ

**ਹੱਲ ਫੋਲਡਰ** ਵਿੱਚ ਪੂਰੇ ਤੌਰ 'ਤੇ ਤਿਆਰ, ਚਲਾਉਣ ਯੋਗ ਕਲਾਇੰਟ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਹਨ ਜੋ ਇਸ ਟਿਊਟੋਰਿਯਲ ਵਿੱਚ ਕਵਰ ਕੀਤੀਆਂ ਸਾਰੀਆਂ ਸੰਕਲਪਨਾਵਾਂ ਨੂੰ ਦਰਸਾਉਂਦੇ ਹਨ। ਹਰ ਹੱਲ ਵਿੱਚ ਕਲਾਇੰਟ ਅਤੇ ਸਰਵਰ ਕੋਡ ਵੱਖ-ਵੱਖ, ਖੁਦਮੁਖਤਾਰ ਪ੍ਰੋਜੈਕਟਾਂ ਵਿੱਚ ਸੰਗਠਿਤ ਹੁੰਦੇ ਹਨ।

### 📁 ਹੱਲ ਦੀ ਬਣਤਰ

ਹੱਲ ਡਾਇਰੈਕਟਰੀ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਭਾਸ਼ਾ ਅਨੁਸਾਰ ਵੰਡਿਆ ਗਿਆ ਹੈ:

```
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw            # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 ਹਰ ਹੱਲ ਵਿੱਚ ਕੀ ਸ਼ਾਮਲ ਹੈ

ਹਰ ਭਾਸ਼ਾ-ਵਿਸ਼ੇਸ਼ ਹੱਲ ਵਿੱਚ ਸ਼ਾਮਲ ਹਨ:

- **ਪੂਰੀ ਕਲਾਇੰ
ਦੋਹਾਂ ਤਰੀਕੇ ਕੀਮਤੀ ਹਨ - ਪੂਰੇ ਪ੍ਰੋਜੈਕਟਾਂ ਲਈ **solution folder** ਦੀ ਵਰਤੋਂ ਕਰੋ ਅਤੇ ਸਿੱਖਣ ਅਤੇ ਸੰਦਰਭ ਲਈ **complete examples** ਨੂੰ ਦੇਖੋ।  
## ਮੁੱਖ ਗੱਲਾਂ

ਇਸ ਅਧਿਆਇ ਲਈ ਮੁੱਖ ਗੱਲਾਂ ਗਾਹਕਾਂ ਬਾਰੇ ਇਹ ਹਨ:

- ਸਰਵਰ 'ਤੇ ਫੀਚਰਾਂ ਨੂੰ ਖੋਜਣ ਅਤੇ ਕਾਲ ਕਰਨ ਲਈ ਵਰਤੇ ਜਾ ਸਕਦੇ ਹਨ।  
- ਆਪਣੇ ਆਪ ਨੂੰ ਸ਼ੁਰੂ ਕਰਦੇ ਸਮੇਂ ਸਰਵਰ ਨੂੰ ਵੀ ਸ਼ੁਰੂ ਕਰ ਸਕਦੇ ਹਨ (ਜਿਵੇਂ ਇਸ ਅਧਿਆਇ ਵਿੱਚ) ਪਰ ਗਾਹਕ ਚੱਲ ਰਹੇ ਸਰਵਰਾਂ ਨਾਲ ਵੀ ਜੁੜ ਸਕਦੇ ਹਨ।  
- ਸਰਵਰ ਦੀਆਂ ਸਮਰੱਥਾਵਾਂ ਦੀ ਜਾਂਚ ਕਰਨ ਦਾ ਇੱਕ ਵਧੀਆ ਤਰੀਕਾ ਹੈ, ਜਿਵੇਂ ਕਿ ਪਿਛਲੇ ਅਧਿਆਇ ਵਿੱਚ ਵਰਣਿਤ Inspector ਵਰਗੇ ਵਿਕਲਪਾਂ ਦੇ ਨਾਲ।  

## ਵਾਧੂ ਸਰੋਤ

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## ਨਮੂਨੇ

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## ਅਗਲਾ ਕੀ ਹੈ

- ਅਗਲਾ: [Creating a client with an LLM](../03-llm-client/README.md)

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।