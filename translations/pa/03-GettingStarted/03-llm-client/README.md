<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T18:22:19+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "pa"
}
-->
# LLM ਨਾਲ ਕਲਾਇੰਟ ਬਣਾਉਣਾ

ਹੁਣ ਤੱਕ, ਤੁਸੀਂ ਵੇਖਿਆ ਕਿ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਕਿਵੇਂ ਬਣਾਉਣੇ ਹਨ। ਕਲਾਇੰਟ ਸਰਵਰ ਨੂੰ ਸਪਸ਼ਟ ਤੌਰ 'ਤੇ ਕਾਲ ਕਰ ਸਕਦਾ ਹੈ ਤਾਂ ਜੋ ਉਸਦੇ ਟੂਲ, ਸਰੋਤ ਅਤੇ ਪ੍ਰਾਂਪਟ ਦੀ ਸੂਚੀ ਮਿਲ ਸਕੇ। ਪਰ ਇਹ ਤਰੀਕਾ ਬਹੁਤ ਵਿਆਵਹਾਰਿਕ ਨਹੀਂ ਹੈ। ਤੁਹਾਡੇ ਯੂਜ਼ਰ ਏਜੰਟਿਕ ਯੁੱਗ ਵਿੱਚ ਰਹਿੰਦੇ ਹਨ ਅਤੇ ਉਮੀਦ ਕਰਦੇ ਹਨ ਕਿ ਉਹ ਪ੍ਰਾਂਪਟ ਵਰਤ ਕੇ ਅਤੇ LLM ਨਾਲ ਗੱਲਬਾਤ ਕਰਕੇ ਕੰਮ ਕਰ ਸਕਣ। ਤੁਹਾਡੇ ਯੂਜ਼ਰ ਲਈ ਇਹ ਮਾਇਨੇ ਨਹੀਂ ਰੱਖਦਾ ਕਿ ਤੁਸੀਂ ਆਪਣੀਆਂ ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਸਟੋਰ ਕਰਨ ਲਈ MCP ਵਰਤਦੇ ਹੋ ਜਾਂ ਨਹੀਂ, ਪਰ ਉਹ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਵਿੱਚ ਗੱਲਬਾਤ ਕਰਨ ਦੀ ਉਮੀਦ ਰੱਖਦੇ ਹਨ। ਤਾਂ ਫਿਰ ਅਸੀਂ ਇਹ ਕਿਵੇਂ ਹੱਲ ਕਰੀਏ? ਹੱਲ ਇਹ ਹੈ ਕਿ ਕਲਾਇੰਟ ਵਿੱਚ ਇੱਕ LLM ਸ਼ਾਮਲ ਕੀਤਾ ਜਾਵੇ।

## ਓਵਰਵਿਊ

ਇਸ ਪਾਠ ਵਿੱਚ ਅਸੀਂ ਧਿਆਨ ਦੇਵਾਂਗੇ ਕਿ ਕਿਵੇਂ ਇੱਕ LLM ਨੂੰ ਕਲਾਇੰਟ ਵਿੱਚ ਸ਼ਾਮਲ ਕਰਕੇ ਤੁਹਾਡੇ ਯੂਜ਼ਰ ਲਈ ਬਿਹਤਰ ਅਨੁਭਵ ਪ੍ਰਦਾਨ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੀ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- ਇੱਕ LLM ਵਾਲਾ ਕਲਾਇੰਟ ਬਣਾਉਣਾ।
- MCP ਸਰਵਰ ਨਾਲ LLM ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਬਿਨਾਂ ਰੁਕਾਵਟ ਗੱਲਬਾਤ ਕਰਨਾ।
- ਕਲਾਇੰਟ ਪਾਸੇ ਬਿਹਤਰ ਅੰਤਮ ਯੂਜ਼ਰ ਅਨੁਭਵ ਦੇਣਾ।

## ਤਰੀਕਾ

ਆਓ ਸਮਝੀਏ ਕਿ ਸਾਨੂੰ ਕਿਹੜਾ ਤਰੀਕਾ ਅਪਣਾਉਣਾ ਹੈ। LLM ਸ਼ਾਮਲ ਕਰਨਾ ਆਸਾਨ ਲੱਗਦਾ ਹੈ, ਪਰ ਕੀ ਅਸੀਂ ਇਹ ਅਸਲ ਵਿੱਚ ਕਰਾਂਗੇ?

ਇਸ ਤਰ੍ਹਾਂ ਕਲਾਇੰਟ ਸਰਵਰ ਨਾਲ ਗੱਲਬਾਤ ਕਰੇਗਾ:

1. ਸਰਵਰ ਨਾਲ ਕਨੈਕਸ਼ਨ ਸਥਾਪਿਤ ਕਰੋ।

1. ਸਮਰੱਥਾਵਾਂ, ਪ੍ਰਾਂਪਟ, ਸਰੋਤ ਅਤੇ ਟੂਲ ਦੀ ਸੂਚੀ ਬਣਾਓ ਅਤੇ ਉਹਨਾਂ ਦਾ ਸਕੀਮਾ ਸੇਵ ਕਰੋ।

1. ਇੱਕ LLM ਸ਼ਾਮਲ ਕਰੋ ਅਤੇ ਸੇਵ ਕੀਤੀਆਂ ਸਮਰੱਥਾਵਾਂ ਅਤੇ ਉਹਨਾਂ ਦੇ ਸਕੀਮਾ ਨੂੰ LLM ਸਮਝਣ ਵਾਲੇ ਫਾਰਮੈਟ ਵਿੱਚ ਪਾਸ ਕਰੋ।

1. ਯੂਜ਼ਰ ਦੇ ਪ੍ਰਾਂਪਟ ਨੂੰ LLM ਨੂੰ ਭੇਜੋ, ਨਾਲ ਹੀ ਕਲਾਇੰਟ ਵੱਲੋਂ ਸੂਚੀਬੱਧ ਟੂਲ ਵੀ ਭੇਜੋ।

ਵਧੀਆ, ਹੁਣ ਅਸੀਂ ਉੱਚ ਸਤਰ 'ਤੇ ਸਮਝ ਗਏ ਕਿ ਇਹ ਕਿਵੇਂ ਕਰਨਾ ਹੈ, ਆਓ ਹੇਠਾਂ ਦਿੱਤੇ ਅਭਿਆਸ ਵਿੱਚ ਇਸਨੂੰ ਅਜ਼ਮਾਈਏ।

## ਅਭਿਆਸ: LLM ਨਾਲ ਕਲਾਇੰਟ ਬਣਾਉਣਾ

ਇਸ ਅਭਿਆਸ ਵਿੱਚ, ਅਸੀਂ ਸਿੱਖਾਂਗੇ ਕਿ ਕਿਵੇਂ ਆਪਣੇ ਕਲਾਇੰਟ ਵਿੱਚ ਇੱਕ LLM ਸ਼ਾਮਲ ਕਰੀਏ।

## GitHub Personal Access Token ਨਾਲ ਪ੍ਰਮਾਣਿਕਤਾ

GitHub ਟੋਕਨ ਬਣਾਉਣਾ ਸਿੱਧਾ ਸਾਦਾ ਹੈ। ਇਹ ਹੈ ਕਿਵੇਂ:

- GitHub Settings 'ਤੇ ਜਾਓ – ਸਿਖਰਲੇ ਸੱਜੇ ਕੋਨੇ ਵਿੱਚ ਆਪਣੀ ਪ੍ਰੋਫਾਈਲ ਤਸਵੀਰ 'ਤੇ ਕਲਿੱਕ ਕਰੋ ਅਤੇ Settings ਚੁਣੋ।
- Developer Settings 'ਤੇ ਜਾਓ – ਹੇਠਾਂ ਸਕ੍ਰੋਲ ਕਰੋ ਅਤੇ Developer Settings 'ਤੇ ਕਲਿੱਕ ਕਰੋ।
- Personal Access Tokens ਚੁਣੋ – Personal access tokens 'ਤੇ ਕਲਿੱਕ ਕਰੋ ਅਤੇ ਫਿਰ Generate new token 'ਤੇ ਕਲਿੱਕ ਕਰੋ।
- ਆਪਣਾ ਟੋਕਨ ਸੰਰਚਿਤ ਕਰੋ – ਸੰਦਰਭ ਲਈ ਨੋਟ ਜੋੜੋ, ਮਿਆਦ ਨਿਰਧਾਰਤ ਕਰੋ ਅਤੇ ਜ਼ਰੂਰੀ scopes (ਅਧਿਕਾਰ) ਚੁਣੋ।
- ਟੋਕਨ ਬਣਾਓ ਅਤੇ ਕਾਪੀ ਕਰੋ – Generate token 'ਤੇ ਕਲਿੱਕ ਕਰੋ ਅਤੇ ਇਸਨੂੰ ਤੁਰੰਤ ਕਾਪੀ ਕਰ ਲਵੋ, ਕਿਉਂਕਿ ਤੁਸੀਂ ਇਸਨੂੰ ਦੁਬਾਰਾ ਨਹੀਂ ਦੇਖ ਸਕੋਗੇ।

### -1- ਸਰਵਰ ਨਾਲ ਕਨੈਕਟ ਕਰੋ

ਆਓ ਪਹਿਲਾਂ ਆਪਣਾ ਕਲਾਇੰਟ ਬਣਾਈਏ:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MCPClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", 
            apiKey: process.env.GITHUB_TOKEN,
        });

        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }
}
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਲੋੜੀਂਦੇ ਲਾਇਬ੍ਰੇਰੀਜ਼ ਇੰਪੋਰਟ ਕੀਤੀਆਂ
- ਇੱਕ ਕਲਾਸ ਬਣਾਈ ਜਿਸ ਵਿੱਚ ਦੋ ਮੈਂਬਰ ਹਨ, `client` ਅਤੇ `openai`, ਜੋ ਸਾਡੇ ਕਲਾਇੰਟ ਨੂੰ ਮੈਨੇਜ ਕਰਨ ਅਤੇ LLM ਨਾਲ ਗੱਲਬਾਤ ਕਰਨ ਵਿੱਚ ਮਦਦ ਕਰਨਗੇ।
- ਆਪਣੀ LLM ਇੰਸਟੈਂਸ ਨੂੰ GitHub Models ਵਰਤਣ ਲਈ ਕਨਫਿਗਰ ਕੀਤਾ, `baseUrl` ਨੂੰ inference API ਵੱਲ ਸੈੱਟ ਕਰਕੇ।

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

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- MCP ਲਈ ਲੋੜੀਂਦੇ ਲਾਇਬ੍ਰੇਰੀਜ਼ ਇੰਪੋਰਟ ਕੀਤੀਆਂ
- ਇੱਕ ਕਲਾਇੰਟ ਬਣਾਇਆ

### .NET

```csharp
using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using System.Text.Json;

var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
    Arguments = [],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

### Java

ਸਭ ਤੋਂ ਪਹਿਲਾਂ, ਤੁਹਾਨੂੰ ਆਪਣੇ `pom.xml` ਫਾਇਲ ਵਿੱਚ LangChain4j ਡਿਪੈਂਡੈਂਸੀਜ਼ ਸ਼ਾਮਲ ਕਰਣੀਆਂ ਪੈਣਗੀਆਂ। ਇਹ ਡਿਪੈਂਡੈਂਸੀਜ਼ MCP ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਅਤੇ GitHub Models ਸਹਾਇਤਾ ਲਈ ਹਨ:

```xml
<properties>
    <langchain4j.version>1.0.0-beta3</langchain4j.version>
</properties>

<dependencies>
    <!-- LangChain4j MCP Integration -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-mcp</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- OpenAI Official API Client -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-open-ai-official</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- GitHub Models Support -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-github-models</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- Spring Boot Starter (optional, for production apps) -->
    <dependency>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-actuator</artifactId>
    </dependency>
</dependencies>
```

ਫਿਰ ਆਪਣੀ Java ਕਲਾਇੰਟ ਕਲਾਸ ਬਣਾਓ:

```java
import dev.langchain4j.mcp.McpToolProvider;
import dev.langchain4j.mcp.client.DefaultMcpClient;
import dev.langchain4j.mcp.client.McpClient;
import dev.langchain4j.mcp.client.transport.McpTransport;
import dev.langchain4j.mcp.client.transport.http.HttpMcpTransport;
import dev.langchain4j.model.chat.ChatLanguageModel;
import dev.langchain4j.model.openaiofficial.OpenAiOfficialChatModel;
import dev.langchain4j.service.AiServices;
import dev.langchain4j.service.tool.ToolProvider;

import java.time.Duration;
import java.util.List;

public class LangChain4jClient {
    
    public static void main(String[] args) throws Exception {        // Configure the LLM to use GitHub Models
        ChatLanguageModel model = OpenAiOfficialChatModel.builder()
                .isGitHubModels(true)
                .apiKey(System.getenv("GITHUB_TOKEN"))
                .timeout(Duration.ofSeconds(60))
                .modelName("gpt-4.1-nano")
                .build();

        // Create MCP transport for connecting to server
        McpTransport transport = new HttpMcpTransport.Builder()
                .sseUrl("http://localhost:8080/sse")
                .timeout(Duration.ofSeconds(60))
                .logRequests(true)
                .logResponses(true)
                .build();

        // Create MCP client
        McpClient mcpClient = new DefaultMcpClient.Builder()
                .transport(transport)
                .build();
    }
}
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- **LangChain4j ਡਿਪੈਂਡੈਂਸੀਜ਼ ਸ਼ਾਮਲ ਕੀਤੀਆਂ**: MCP ਇੰਟੀਗ੍ਰੇਸ਼ਨ, OpenAI ਅਧਿਕਾਰਤ ਕਲਾਇੰਟ ਅਤੇ GitHub Models ਸਹਾਇਤਾ ਲਈ
- **LangChain4j ਲਾਇਬ੍ਰੇਰੀਜ਼ ਇੰਪੋਰਟ ਕੀਤੀਆਂ**: MCP ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਅਤੇ OpenAI ਚੈਟ ਮਾਡਲ ਫੰਕਸ਼ਨਾਲਿਟੀ ਲਈ
- **`ChatLanguageModel` ਬਣਾਇਆ**: GitHub Models ਨੂੰ ਤੁਹਾਡੇ GitHub ਟੋਕਨ ਨਾਲ ਵਰਤਣ ਲਈ ਕਨਫਿਗਰ ਕੀਤਾ
- **HTTP ਟ੍ਰਾਂਸਪੋਰਟ ਸੈੱਟ ਕੀਤਾ**: Server-Sent Events (SSE) ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰ ਨਾਲ ਕਨੈਕਟ ਕਰਨ ਲਈ
- **MCP ਕਲਾਇੰਟ ਬਣਾਇਆ**: ਜੋ ਸਰਵਰ ਨਾਲ ਗੱਲਬਾਤ ਸੰਭਾਲੇਗਾ
- **LangChain4j ਦੀ ਬਿਲਟ-ਇਨ MCP ਸਹਾਇਤਾ ਵਰਤੀ**: ਜੋ LLMs ਅਤੇ MCP ਸਰਵਰਾਂ ਵਿਚਕਾਰ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਨੂੰ ਆਸਾਨ ਬਣਾਉਂਦੀ ਹੈ

ਵਧੀਆ, ਅਗਲੇ ਕਦਮ ਲਈ, ਆਓ ਸਰਵਰ ਦੀਆਂ ਸਮਰੱਥਾਵਾਂ ਦੀ ਸੂਚੀ ਬਣਾਈਏ।

### -2- ਸਰਵਰ ਸਮਰੱਥਾਵਾਂ ਦੀ ਸੂਚੀ ਬਣਾਓ

ਹੁਣ ਅਸੀਂ ਸਰਵਰ ਨਾਲ ਕਨੈਕਟ ਕਰਕੇ ਉਸ ਦੀਆਂ ਸਮਰੱਥਾਵਾਂ ਮੰਗਾਂਗੇ:

### TypeScript

ਉਸੇ ਕਲਾਸ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤੇ ਮੈਥਡ ਸ਼ਾਮਲ ਕਰੋ:

```typescript
async connectToServer(transport: Transport) {
     await this.client.connect(transport);
     this.run();
     console.error("MCPClient started on stdin/stdout");
}

async run() {
    console.log("Asking server for available tools");

    // listing tools
    const toolsResult = await this.client.listTools();
}
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਸਰਵਰ ਨਾਲ ਕਨੈਕਟ ਕਰਨ ਲਈ `connectToServer` ਕੋਡ ਸ਼ਾਮਲ ਕੀਤਾ।
- ਇੱਕ `run` ਮੈਥਡ ਬਣਾਇਆ ਜੋ ਐਪ ਦੇ ਫਲੋ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ। ਹੁਣ ਤੱਕ ਇਹ ਸਿਰਫ ਟੂਲ ਦੀ ਸੂਚੀ ਦਿਖਾਉਂਦਾ ਹੈ ਪਰ ਅਸੀਂ ਇਸ ਵਿੱਚ ਜਲਦੀ ਹੋਰ ਕੁਝ ਸ਼ਾਮਲ ਕਰਾਂਗੇ।

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
    print("Tool", tool.inputSchema["properties"])
```

ਇਹ ਹੈ ਜੋ ਅਸੀਂ ਸ਼ਾਮਲ ਕੀਤਾ:

- ਸਰੋਤ ਅਤੇ ਟੂਲ ਦੀ ਸੂਚੀ ਬਣਾਈ ਅਤੇ ਪ੍ਰਿੰਟ ਕੀਤੀ। ਟੂਲ ਲਈ ਅਸੀਂ `inputSchema` ਵੀ ਲਿਸਟ ਕਰਦੇ ਹਾਂ ਜੋ ਅੱਗੇ ਵਰਤੋਂ ਵਿੱਚ ਆਵੇਗਾ।

### .NET

```csharp
async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
{
    Console.WriteLine("Listing tools");
    var tools = await mcpClient.ListToolsAsync();

    List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

    foreach (var tool in tools)
    {
        Console.WriteLine($"Connected to server with tools: {tool.Name}");
        Console.WriteLine($"Tool description: {tool.Description}");
        Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

        // TODO: convert tool defintion from MCP tool to LLm tool     
    }

    return toolDefinitions;
}
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- MCP ਸਰਵਰ 'ਤੇ ਉਪਲਬਧ ਟੂਲ ਦੀ ਸੂਚੀ ਬਣਾਈ
- ਹਰ ਟੂਲ ਲਈ ਨਾਮ, ਵਰਣਨ ਅਤੇ ਉਸਦਾ ਸਕੀਮਾ ਲਿਸਟ ਕੀਤਾ। ਇਹ ਸਕੀਮਾ ਅਸੀਂ ਜਲਦੀ ਟੂਲ ਕਾਲ ਕਰਨ ਲਈ ਵਰਤਾਂਗੇ।

### Java

```java
// Create a tool provider that automatically discovers MCP tools
ToolProvider toolProvider = McpToolProvider.builder()
        .mcpClients(List.of(mcpClient))
        .build();

// The MCP tool provider automatically handles:
// - Listing available tools from the MCP server
// - Converting MCP tool schemas to LangChain4j format
// - Managing tool execution and responses
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਇੱਕ `McpToolProvider` ਬਣਾਇਆ ਜੋ MCP ਸਰਵਰ ਤੋਂ ਸਾਰੇ ਟੂਲ ਖੋਜ ਕੇ ਰਜਿਸਟਰ ਕਰਦਾ ਹੈ
- ਟੂਲ ਪ੍ਰੋਵਾਈਡਰ MCP ਟੂਲ ਸਕੀਮਾਂ ਅਤੇ LangChain4j ਦੇ ਟੂਲ ਫਾਰਮੈਟ ਵਿਚਕਾਰ ਕਨਵਰਜ਼ਨ ਨੂੰ ਅੰਦਰੂਨੀ ਤੌਰ 'ਤੇ ਸੰਭਾਲਦਾ ਹੈ
- ਇਹ ਤਰੀਕਾ ਮੈਨੂਅਲ ਟੂਲ ਲਿਸਟਿੰਗ ਅਤੇ ਕਨਵਰਜ਼ਨ ਦੀ ਜਟਿਲਤਾ ਨੂੰ ਦੂਰ ਕਰਦਾ ਹੈ

### -3- ਸਰਵਰ ਸਮਰੱਥਾਵਾਂ ਨੂੰ LLM ਟੂਲਾਂ ਵਿੱਚ ਬਦਲੋ

ਸਰਵਰ ਸਮਰੱਥਾਵਾਂ ਦੀ ਸੂਚੀ ਬਣਾਉਣ ਤੋਂ ਬਾਅਦ ਅਗਲਾ ਕਦਮ ਇਹ ਹੈ ਕਿ ਉਹਨਾਂ ਨੂੰ LLM ਸਮਝਣ ਵਾਲੇ ਫਾਰਮੈਟ ਵਿੱਚ ਬਦਲਿਆ ਜਾਵੇ। ਇਸ ਤੋਂ ਬਾਅਦ ਅਸੀਂ ਇਹ ਸਮਰੱਥਾਵਾਂ LLM ਨੂੰ ਟੂਲਾਂ ਵਜੋਂ ਦੇ ਸਕਦੇ ਹਾਂ।

### TypeScript

1. MCP ਸਰਵਰ ਤੋਂ ਪ੍ਰਾਪਤ ਜਵਾਬ ਨੂੰ LLM ਲਈ ਸਮਝਣਯੋਗ ਟੂਲ ਫਾਰਮੈਟ ਵਿੱਚ ਬਦਲਣ ਲਈ ਹੇਠਾਂ ਦਿੱਤਾ ਕੋਡ ਸ਼ਾਮਲ ਕਰੋ:

    ```typescript
    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
        }) {
        // Create a zod schema based on the input_schema
        const schema = z.object(tool.input_schema);
    
        return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
            name: tool.name,
            description: tool.description,
            parameters: {
            type: "object",
            properties: tool.input_schema.properties,
            required: tool.input_schema.required,
            },
            },
        };
    }

    ```

    ਉਪਰੋਕਤ ਕੋਡ MCP ਸਰਵਰ ਤੋਂ ਜਵਾਬ ਲੈਂਦਾ ਹੈ ਅਤੇ ਉਸਨੂੰ LLM ਸਮਝਣ ਵਾਲੇ ਟੂਲ ਡਿਫਿਨੀਸ਼ਨ ਵਿੱਚ ਬਦਲਦਾ ਹੈ।

1. ਹੁਣ `run` ਮੈਥਡ ਨੂੰ ਅਪਡੇਟ ਕਰੀਏ ਤਾਂ ਜੋ ਸਰਵਰ ਸਮਰੱਥਾਵਾਂ ਦੀ ਸੂਚੀ ਬਣਾਈ ਜਾਵੇ:

    ```typescript
    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
            name: tool.name,
            description: tool.description,
            input_schema: tool.inputSchema,
            });
        });
    }
    ```

    ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ `run` ਮੈਥਡ ਨੂੰ ਅਪਡੇਟ ਕੀਤਾ ਹੈ ਜੋ ਨਤੀਜੇ ਵਿੱਚੋਂ ਹਰ ਐਂਟਰੀ ਲਈ `openAiToolAdapter` ਕਾਲ ਕਰਦਾ ਹੈ।

### Python

1. ਪਹਿਲਾਂ, ਹੇਠਾਂ ਦਿੱਤਾ ਕਨਵਰਟਰ ਫੰਕਸ਼ਨ ਬਣਾਈਏ:

    ```python
    def convert_to_llm_tool(tool):
        tool_schema = {
            "type": "function",
            "function": {
                "name": tool.name,
                "description": tool.description,
                "type": "function",
                "parameters": {
                    "type": "object",
                    "properties": tool.inputSchema["properties"]
                }
            }
        }

        return tool_schema
    ```

    ਇਸ ਫੰਕਸ਼ਨ `convert_to_llm_tools` ਵਿੱਚ ਅਸੀਂ MCP ਟੂਲ ਜਵਾਬ ਨੂੰ LLM ਸਮਝਣ ਵਾਲੇ ਫਾਰਮੈਟ ਵਿੱਚ ਬਦਲਦੇ ਹਾਂ।

1. ਫਿਰ, ਆਪਣੇ ਕਲਾਇੰਟ ਕੋਡ ਨੂੰ ਇਸ ਫੰਕਸ਼ਨ ਦੀ ਵਰਤੋਂ ਲਈ ਅਪਡੇਟ ਕਰੀਏ:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    ਇੱਥੇ ਅਸੀਂ MCP ਟੂਲ ਜਵਾਬ ਨੂੰ LLM ਲਈ ਸਮਝਣਯੋਗ ਬਣਾਉਣ ਲਈ `convert_to_llm_tool` ਕਾਲ ਕਰ ਰਹੇ ਹਾਂ।

### .NET

1. MCP ਟੂਲ ਜਵਾਬ ਨੂੰ LLM ਸਮਝਣ ਵਾਲੇ ਫਾਰਮੈਟ ਵਿੱਚ ਬਦਲਣ ਲਈ ਕੋਡ ਸ਼ਾਮਲ ਕਰੋ:

```csharp
ChatCompletionsToolDefinition ConvertFrom(string name, string description, JsonElement jsonElement)
{ 
    // convert the tool to a function definition
    FunctionDefinition functionDefinition = new FunctionDefinition(name)
    {
        Description = description,
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = jsonElement
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    // create a tool definition
    ChatCompletionsToolDefinition toolDefinition = new ChatCompletionsToolDefinition(functionDefinition);
    return toolDefinition;
}
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਇੱਕ ਫੰਕਸ਼ਨ `ConvertFrom` ਬਣਾਇਆ ਜੋ ਨਾਮ, ਵਰਣਨ ਅਤੇ ਇਨਪੁਟ ਸਕੀਮਾ ਲੈਂਦਾ ਹੈ।
- ਇੱਕ ਫੰਕਸ਼ਨਲਿਟੀ ਪਰਿਭਾਸ਼ਿਤ ਕੀਤੀ ਜੋ `FunctionDefinition` ਬਣਾਉਂਦੀ ਹੈ ਜੋ `ChatCompletionsDefinition` ਨੂੰ ਪਾਸ ਹੁੰਦੀ ਹੈ। ਇਹ LLM ਲਈ ਸਮਝਣਯੋਗ ਹੁੰਦਾ ਹੈ।

1. ਹੁਣ ਦੇਖੀਏ ਕਿ ਅਸੀਂ ਮੌਜੂਦਾ ਕੋਡ ਨੂੰ ਇਸ ਫੰਕਸ਼ਨ ਦੀ ਵਰਤੋਂ ਲਈ ਕਿਵੇਂ ਅਪਡੇਟ ਕਰ ਸਕਦੇ ਹਾਂ:

    ```csharp
    async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
    {
        Console.WriteLine("Listing tools");
        var tools = await mcpClient.ListToolsAsync();

        List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

        foreach (var tool in tools)
        {
            Console.WriteLine($"Connected to server with tools: {tool.Name}");
            Console.WriteLine($"Tool description: {tool.Description}");
            Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

            JsonElement propertiesElement;
            tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

            var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
            Console.WriteLine($"Tool definition: {def}");
            toolDefinitions.Add(def);

            Console.WriteLine($"Properties: {propertiesElement}");        
        }

        return toolDefinitions;
    }
    ```

    ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

    - MCP ਟੂਲ ਜਵਾਬ ਨੂੰ LLM ਟੂਲ ਵਿੱਚ ਬਦਲਣ ਲਈ ਫੰਕਸ਼ਨ ਅਪਡੇਟ ਕੀਤਾ। ਹੇਠਾਂ ਦਿੱਤਾ ਕੋਡ ਇਸ ਬਾਰੇ ਹੈ:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        ਇਨਪੁਟ ਸਕੀਮਾ ਟੂਲ ਜਵਾਬ ਦਾ ਹਿੱਸਾ ਹੈ ਪਰ "properties" ਐਟ੍ਰਿਬਿਊਟ ਵਿੱਚ, ਇਸ ਲਈ ਸਾਨੂੰ ਇਸਨੂੰ ਕੱਢਣਾ ਪੈਂਦਾ ਹੈ। ਫਿਰ ਅਸੀਂ `ConvertFrom` ਨੂੰ ਟੂਲ ਵੇਰਵੇ ਨਾਲ ਕਾਲ ਕਰਦੇ ਹਾਂ। ਹੁਣ ਜਦੋਂ ਇਹ ਭਾਰੀ ਕੰਮ ਹੋ ਗਿਆ, ਆਓ ਦੇਖੀਏ ਕਿ ਯੂਜ਼ਰ ਪ੍ਰਾਂਪਟ ਨੂੰ ਕਿਵੇਂ ਸੰਭਾਲਿਆ ਜਾਵੇ।

### Java

```java
// Create a Bot interface for natural language interaction
public interface Bot {
    String chat(String prompt);
}

// Configure the AI service with LLM and MCP tools
Bot bot = AiServices.builder(Bot.class)
        .chatLanguageModel(model)
        .toolProvider(toolProvider)
        .build();
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਵਿੱਚ ਗੱਲਬਾਤ ਲਈ ਇੱਕ ਸਧਾਰਣ `Bot` ਇੰਟਰਫੇਸ ਪਰਿਭਾਸ਼ਿਤ ਕੀਤਾ
- LangChain4j ਦੇ `AiServices` ਦੀ ਵਰਤੋਂ ਕੀਤੀ ਜੋ LLM ਨੂੰ MCP ਟੂਲ ਪ੍ਰੋਵਾਈਡਰ ਨਾਲ ਆਪਣੇ ਆਪ ਬਾਈਂਡ ਕਰਦਾ ਹੈ
- ਫਰੇਮਵਰਕ ਆਪਣੇ ਆਪ ਟੂਲ ਸਕੀਮਾ ਕਨਵਰਜ਼ਨ ਅਤੇ ਫੰਕਸ਼ਨ ਕਾਲਿੰਗ ਸੰਭਾਲਦਾ ਹੈ
- ਇਹ ਤਰੀਕਾ ਮੈਨੂਅਲ ਟੂਲ ਕਨਵਰਜ਼ਨ ਨੂੰ ਖਤਮ ਕਰਦਾ ਹੈ - LangChain4j MCP ਟੂਲਾਂ ਨੂੰ LLM-ਸਮਰਥਿਤ ਫਾਰਮੈਟ ਵਿੱਚ ਬਦਲਣ ਦੀ ਸਾਰੀ ਜਟਿਲਤਾ ਸੰਭਾਲਦਾ ਹੈ

ਵਧੀਆ, ਹੁਣ ਅਸੀਂ ਯੂਜ਼ਰ ਦੀਆਂ ਬੇਨਤੀਆਂ ਸੰਭਾਲਣ ਲਈ ਤਿਆਰ ਹਾਂ, ਆਓ ਅਗਲਾ ਕਦਮ ਕਰੀਏ।

### -4- ਯੂਜ਼ਰ ਪ੍ਰਾਂਪਟ ਬੇਨਤੀ ਸੰਭਾਲੋ

ਇਸ ਹਿੱਸੇ ਵਿੱਚ ਅਸੀਂ ਯੂਜ਼ਰ ਦੀਆਂ ਬੇਨਤੀਆਂ ਨੂੰ ਸੰਭਾਲਾਂਗੇ।

### TypeScript

1. ਇੱਕ ਮੈਥਡ ਸ਼ਾਮਲ ਕਰੋ ਜੋ ਸਾਡੇ LLM ਨੂੰ ਕਾਲ ਕਰਨ ਲਈ ਵਰਤੀ ਜਾਵੇਗੀ:

    ```typescript
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
    ) {
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);


        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  

        }
    }
    ```

    ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

    - ਇੱਕ ਮੈਥਡ `callTools` ਸ਼ਾਮਲ ਕੀਤਾ।
    - ਇਹ ਮੈਥਡ LLM ਦੇ ਜਵਾਬ ਨੂੰ ਲੈਂਦਾ ਹੈ ਅਤੇ ਦੇਖਦਾ ਹੈ ਕਿ ਕਿਹੜੇ ਟੂਲ ਕਾਲ ਕੀਤੇ ਗਏ ਹਨ, ਜੇ ਕੋਈ ਹਨ:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - ਜੇ LLM ਦੱਸਦਾ ਹੈ ਕਿ ਕਿਸੇ ਟੂਲ ਨੂੰ ਕਾਲ ਕਰਨਾ ਹੈ ਤਾਂ ਉਸਨੂੰ ਕਾਲ ਕਰਦਾ ਹੈ:

        ```typescript
        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  
        ```

1. `run` ਮੈਥਡ ਨੂੰ ਅਪਡੇਟ ਕਰੋ ਤਾਂ ਜੋ LLM ਨੂੰ ਕਾਲ ਕੀਤਾ ਜਾਵੇ ਅਤੇ `callTools` ਕਾਲ ਹੋਵੇ:

    ```typescript

    // 1. Create messages that's input for the LLM
    const prompt = "What is the sum of 2 and 3?"

    const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

    console.log("Querying LLM: ", messages[0].content);

    // 2. Calling the LLM
    let response = this.openai.chat.completions.create({
        model: "gpt-4o-mini",
        max_tokens: 1000,
        messages,
        tools: tools,
    });    

    let results: any[] = [];

    // 3. Go through the LLM response,for each choice, check if it has tool calls 
    (await response).choices.map(async (choice: { message: any; }) => {
        const message = choice.message;
        if (message.tool_calls) {
            console.log("Making tool call")
            await this.callTools(message.tool_calls, results);
        }
    });
    ```

ਵਧੀਆ, ਪੂਰਾ ਕੋਡ ਇੱਥੇ ਹੈ:

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MyClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", // might need to change to this url in the future: https://models.github.ai/inference
            apiKey: process.env.GITHUB_TOKEN,
        });

       
        
        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }

    async connectToServer(transport: Transport) {
        await this.client.connect(transport);
        this.run();
        console.error("MCPClient started on stdin/stdout");
    }

    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
          }) {
          // Create a zod schema based on the input_schema
          const schema = z.object(tool.input_schema);
      
          return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
              name: tool.name,
              description: tool.description,
              parameters: {
              type: "object",
              properties: tool.input_schema.properties,
              required: tool.input_schema.required,
              },
            },
          };
    }
    
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
      ) {
        for (const tool_call of tool_calls) {
          const toolName = tool_call.function.name;
          const args = tool_call.function.arguments;
    
          console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);
    
    
          // 2. Call the server's tool 
          const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
          });
    
          console.log("Tool result: ", toolResult);
    
          // 3. Do something with the result
          // TODO  
    
         }
    }

    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
              name: tool.name,
              description: tool.description,
              input_schema: tool.inputSchema,
            });
        });

        const prompt = "What is the sum of 2 and 3?";
    
        const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

        console.log("Querying LLM: ", messages[0].content);
        let response = this.openai.chat.completions.create({
            model: "gpt-4o-mini",
            max_tokens: 1000,
            messages,
            tools: tools,
        });    

        let results: any[] = [];
    
        // 1. Go through the LLM response,for each choice, check if it has tool calls 
        (await response).choices.map(async (choice: { message: any; }) => {
          const message = choice.message;
          if (message.tool_calls) {
              console.log("Making tool call")
              await this.callTools(message.tool_calls, results);
          }
        });
    }
    
}

let client = new MyClient();
 const transport = new StdioClientTransport({
            command: "node",
            args: ["./build/index.js"]
        });

client.connectToServer(transport);
```

### Python

1. LLM ਕਾਲ ਕਰਨ ਲਈ ਲੋੜੀਂਦੇ ਇੰਪੋਰਟ ਸ਼ਾਮਲ ਕਰੋ:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. ਫਿਰ, ਉਹ ਫੰਕਸ਼ਨ ਸ਼ਾਮਲ ਕਰੋ ਜੋ LLM ਨੂੰ ਕਾਲ ਕਰੇਗਾ:

    ```python
    # llm

    def call_llm(prompt, functions):
        token = os.environ["GITHUB_TOKEN"]
        endpoint = "https://models.inference.ai.azure.com"

        model_name = "gpt-4o"

        client = ChatCompletionsClient(
            endpoint=endpoint,
            credential=AzureKeyCredential(token),
        )

        print("CALLING LLM")
        response = client.complete(
            messages=[
                {
                "role": "system",
                "content": "You are a helpful assistant.",
                },
                {
                "role": "user",
                "content": prompt,
                },
            ],
            model=model_name,
            tools = functions,
            # Optional parameters
            temperature=1.,
            max_tokens=1000,
            top_p=1.    
        )

        response_message = response.choices[0].message
        
        functions_to_call = []

        if response_message.tool_calls:
            for tool_call in response_message.tool_calls:
                print("TOOL: ", tool_call)
                name = tool_call.function.name
                args = json.loads(tool_call.function.arguments)
                functions_to_call.append({ "name": name, "args": args })

        return functions_to_call
    ```

    ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

    - ਉਹ ਫੰਕਸ਼ਨ LLM ਨੂੰ ਦਿੱਤੇ ਜੋ MCP ਸਰਵਰ ਤੋਂ ਮਿਲੇ ਅਤੇ ਬਦਲੇ ਗਏ ਸਨ।
    - ਫਿਰ LLM ਨੂੰ ਕਾਲ ਕੀਤਾ।
    - ਨਤੀਜੇ ਦੀ ਜਾਂਚ ਕੀਤੀ ਕਿ ਕਿਹੜੇ ਫੰਕਸ਼ਨ ਕਾਲ ਕਰਨੇ ਹਨ, ਜੇ ਕੋਈ ਹਨ।
    - ਆਖਿਰਕਾਰ ਕਾਲ ਕਰਨ ਲਈ ਫੰਕਸ਼ਨਾਂ ਦੀ ਲਿਸਟ ਦਿੱਤੀ।

1. ਆਖਰੀ ਕਦਮ, ਮੁੱਖ ਕੋਡ ਅਪਡੇਟ ਕਰੋ:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

    - MCP ਟੂਲ ਨੂੰ `call_tool` ਰਾਹੀਂ ਕਾਲ ਕੀਤਾ ਜੋ LLM ਨੇ ਸੂਚਿਤ ਕੀਤਾ ਸੀ।
    - ਟੂਲ ਕਾਲ ਦਾ ਨਤੀਜਾ MCP ਸਰਵਰ ਨੂੰ ਪ੍ਰਿੰਟ ਕੀਤਾ।

### .NET

1. LLM ਪ੍ਰਾਂਪਟ ਬੇਨਤੀ ਕਰਨ ਲਈ ਕੋਡ ਦਿਖਾਓ:

    ```csharp
    var tools = await GetMcpTools();

    for (int i = 0; i < tools.Count; i++)
    {
        var tool = tools[i];
        Console.WriteLine($"MCP Tools def: {i}: {tool}");
    }

    // 0. Define the chat history and the user message
    var userMessage = "add 2 and 4";

    chatHistory.Add(new ChatRequestUserMessage(userMessage));

    // 1. Define tools
    ChatCompletionsToolDefinition def = CreateToolDefinition();


    // 2. Define options, including the tools
    var options = new ChatCompletionsOptions(chatHistory)
    {
        Model = "gpt-4o-mini",
        Tools = { tools[0] }
    };

    // 3. Call the model  

    ChatCompletions? response = await client.CompleteAsync(options);
    var content = response.Content;

    ```

    ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

    - MCP ਸਰਵਰ ਤੋਂ ਟੂਲ ਲਏ, `var tools = await GetMcpTools()`।
    - ਯੂਜ਼ਰ ਪ੍ਰਾਂਪਟ `userMessage` ਬਣਾਇਆ।
    - ਮਾਡਲ ਅਤੇ ਟੂਲਾਂ ਨੂੰ ਦਰਸਾਉਂਦਾ ਇੱਕ options ਆਬਜੈਕਟ ਬਣਾਇਆ।
    - LLM ਵੱਲ ਬੇਨਤੀ ਕੀਤੀ।

1. ਆਖਰੀ ਕਦਮ, ਦੇਖੀਏ ਕਿ LLM ਸੋਚਦਾ ਹੈ ਕਿ ਕਿਸੇ ਫੰਕਸ਼ਨ ਨੂੰ ਕਾਲ ਕਰਨਾ ਚਾਹੀਦਾ ਹੈ:

    ```csharp
    // 4. Check if the response contains a function call
    ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
    for (int i = 0; i < response.ToolCalls.Count; i++)
    {
        var call = response.ToolCalls[i];
        Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
        //Tool call 0: add with arguments {"a":2,"b":4}

        var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(call.Arguments);
        var result = await mcpClient.CallToolAsync(
            call.Name,
            dict!,
            cancellationToken: CancellationToken.None
        );

        Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

    }
    ```

    ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

    - ਫੰਕਸ਼ਨ ਕਾਲਾਂ ਦੀ ਸੂਚੀ ਵਿੱਚ ਲੂਪ ਕੀਤਾ।
    - ਹਰ ਟੂਲ ਕਾਲ ਲਈ ਨਾਮ ਅਤੇ ਆਰਗੁਮੈਂਟ ਪਾਰਸ ਕਰਕੇ MCP ਸਰਵਰ 'ਤੇ ਟੂਲ ਕਾਲ ਕੀਤਾ ਅਤੇ ਨਤੀਜੇ ਪ੍ਰਿੰਟ ਕੀਤੇ।

ਪੂਰਾ ਕੋਡ ਇੱਥੇ ਹੈ:

```csharp
using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using System.Text.Json;

var endpoint = "https://models.inference.ai.azure.com";
var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN"); // Your GitHub Access Token
var client = new ChatCompletionsClient(new Uri(endpoint), new AzureKeyCredential(token));
var chatHistory = new List<ChatRequestMessage>
{
    new ChatRequestSystemMessage("You are a helpful assistant that knows about AI")
};

var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
    Arguments = [],
});

Console.WriteLine("Setting up stdio transport");

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);

ChatCompletionsToolDefinition ConvertFrom(string name, string description, JsonElement jsonElement)
{ 
    // convert the tool to a function definition
    FunctionDefinition functionDefinition = new FunctionDefinition(name)
    {
        Description = description,
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = jsonElement
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    // create a tool definition
    ChatCompletionsToolDefinition toolDefinition = new ChatCompletionsToolDefinition(functionDefinition);
    return toolDefinition;
}



async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
{
    Console.WriteLine("Listing tools");
    var tools = await mcpClient.ListToolsAsync();

    List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

    foreach (var tool in tools)
    {
        Console.WriteLine($"Connected to server with tools: {tool.Name}");
        Console.WriteLine($"Tool description: {tool.Description}");
        Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);

        Console.WriteLine($"Properties: {propertiesElement}");        
    }

    return toolDefinitions;
}

// 1. List tools on mcp server

var tools = await GetMcpTools();
for (int i = 0; i < tools.Count; i++)
{
    var tool = tools[i];
    Console.WriteLine($"MCP Tools def: {i}: {tool}");
}

// 2. Define the chat history and the user message
var userMessage = "add 2 and 4";

chatHistory.Add(new ChatRequestUserMessage(userMessage));


// 3. Define options, including the tools
var options = new ChatCompletionsOptions(chatHistory)
{
    Model = "gpt-4o-mini",
    Tools = { tools[0] }
};

// 4. Call the model  

ChatCompletions? response = await client.CompleteAsync(options);
var content = response.Content;

// 5. Check if the response contains a function call
ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
for (int i = 0; i < response.ToolCalls.Count; i++)
{
    var call = response.ToolCalls[i];
    Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
    //Tool call 0: add with arguments {"a":2,"b":4}

    var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(call.Arguments);
    var result = await mcpClient.CallToolAsync(
        call.Name,
        dict!,
        cancellationToken: CancellationToken.None
    );

    Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

}

// 5. Print the generic response
Console.WriteLine($"Assistant response: {content}");
```

### Java

```java
try {
    // Execute natural language requests that automatically use MCP tools
    String response = bot.chat("Calculate the sum of 24.5 and 17.3 using the calculator service");
    System.out.println(response);

    response = bot.chat("What's the square root of 144?");
    System.out.println(response);

    response = bot.chat("Show me the help for the calculator service");
    System.out.println(response);
} finally {
    mcpClient.close();
}
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਸਧਾਰਣ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਪ੍ਰ

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।