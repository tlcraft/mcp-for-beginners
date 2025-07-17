<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T12:47:35+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "my"
}
-->
# LLM ဖြင့် client တစ်ခု ဖန်တီးခြင်း

ယခုအထိ server နဲ့ client တို့ကို ဘယ်လိုဖန်တီးရမယ်ဆိုတာ ကြည့်ရှုခဲ့ပြီဖြစ်ပါတယ်။ client က server ကို တိုက်ရိုက်ခေါ်ပြီး tools, resources နဲ့ prompts တွေကို စာရင်းပြုလုပ်နိုင်ခဲ့ပါတယ်။ သို့သော် ဒီနည်းလမ်းက အလွန်လက်တွေ့ကျမဟုတ်ပါဘူး။ သင့်အသုံးပြုသူက agentic အခေတ်မှာ နေထိုင်ပြီး prompts တွေကို သုံးပြီး LLM နဲ့ ဆက်သွယ်ချင်ကြပါတယ်။ သင့်အသုံးပြုသူအတွက် MCP ကို သုံးမသုံးက မဟုတ်ပါဘူး၊ သဘာဝဘာသာစကားနဲ့ ဆက်သွယ်နိုင်ဖို့ကို မျှော်လင့်ကြပါတယ်။ ဒါဆို ဘယ်လိုဖြေရှင်းမလဲ? ဖြေရှင်းချက်က client ထဲမှာ LLM တစ်ခု ထည့်သွင်းပေးခြင်းဖြစ်ပါတယ်။

## အနှစ်ချုပ်

ဒီသင်ခန်းစာမှာ client ကို LLM တစ်ခု ထည့်သွင်းပေးခြင်းအပေါ် အာရုံစိုက်ပြီး သင့်အသုံးပြုသူအတွက် ပိုမိုကောင်းမွန်တဲ့ အတွေ့အကြုံကို ဘယ်လိုပေးနိုင်မလဲ ပြသပေးမှာဖြစ်ပါတယ်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာပြီးဆုံးတဲ့အချိန်မှာ သင်မှာနိုင်မှာတွေက -

- LLM ပါဝင်တဲ့ client တစ်ခု ဖန်တီးနိုင်မယ်။
- LLM ကို သုံးပြီး MCP server နဲ့ အဆင်ပြေစွာ ဆက်သွယ်နိုင်မယ်။
- client ဘက်မှာ အသုံးပြုသူအတွက် ပိုမိုကောင်းမွန်တဲ့ အတွေ့အကြုံ ပေးနိုင်မယ်။

## နည်းလမ်း

လိုအပ်တဲ့ နည်းလမ်းကို နားလည်ကြည့်ကြရအောင်။ LLM တစ်ခု ထည့်သွင်းတာ ရိုးရှင်းသလိုပဲ ဖြစ်ပေမယ့် တကယ်လုပ်မလား?

client က server နဲ့ ဆက်သွယ်ပုံက -

1. server နဲ့ ချိတ်ဆက်ခြင်း။

1. capabilities, prompts, resources နဲ့ tools တွေကို စာရင်းပြုလုပ်ပြီး schema ကို သိမ်းဆည်းခြင်း။

1. LLM တစ်ခု ထည့်သွင်းပြီး သိမ်းဆည်းထားတဲ့ capabilities နဲ့ schema ကို LLM နားလည်နိုင်တဲ့ ပုံစံနဲ့ ပေးပို့ခြင်း။

1. အသုံးပြုသူ prompt ကို LLM ကို ပေးပို့ပြီး client က စာရင်းပြုလုပ်ထားတဲ့ tools တွေနဲ့အတူ ကိုင်တွယ်ခြင်း။

အရမ်းကောင်းပြီ၊ အထက်ပါအဆင့်တွေကို နားလည်သွားပြီဆိုတော့ အောက်မှာ လေ့ကျင့်ခန်းတစ်ခုနဲ့ စမ်းကြည့်ကြရအောင်။

## လေ့ကျင့်ခန်း - LLM ပါဝင်တဲ့ client ဖန်တီးခြင်း

ဒီလေ့ကျင့်ခန်းမှာ LLM ကို client ထဲ ထည့်သွင်းပုံကို သင်ယူပါမယ်။

## GitHub Personal Access Token ဖြင့် အတည်ပြုခြင်း

GitHub token ဖန်တီးခြင်းက ရိုးရှင်းတဲ့ လုပ်ငန်းစဉ်ပါ။ ဒီလိုလုပ်နိုင်ပါတယ် -

- GitHub Settings သို့ သွားပါ – အပေါ်ညာဘက်က profile ပုံကို နှိပ်ပြီး Settings ကို ရွေးချယ်ပါ။
- Developer Settings သို့ သွားပါ – အောက်ဆင်းပြီး Developer Settings ကို နှိပ်ပါ။
- Personal Access Tokens ကို ရွေးချယ်ပါ – Personal access tokens ကို နှိပ်ပြီး Generate new token ကို နှိပ်ပါ။
- Token ကို ပြင်ဆင်ပါ – မှတ်ချက်တစ်ခု ထည့်ပြီး သက်တမ်းကုန်ဆုံးရက် သတ်မှတ်ပြီး လိုအပ်တဲ့ scopes (ခွင့်ပြုချက်များ) ကို ရွေးချယ်ပါ။
- Token ကို ဖန်တီးပြီး ကူးယူပါ – Generate token ကို နှိပ်ပြီး ချက်ချင်း ကူးယူပါ၊ နောက်တစ်ကြိမ် မမြင်ရတော့ပါဘူး။

### -1- server နဲ့ ချိတ်ဆက်ခြင်း

client ကို ပထမဆုံး ဖန်တီးကြရအောင် -

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

အထက်ပါ ကုဒ်မှာ -

- လိုအပ်တဲ့ libraries တွေကို import လုပ်ထားပါတယ်။
- `client` နဲ့ `openai` ဆိုတဲ့ members နှစ်ခုပါဝင်တဲ့ class တစ်ခု ဖန်တီးထားပြီး client ကို စီမံခန့်ခွဲခြင်းနဲ့ LLM နဲ့ ဆက်သွယ်ခြင်းအတွက် အသုံးပြုမှာဖြစ်ပါတယ်။
- LLM instance ကို GitHub Models သုံးဖို့ `baseUrl` ကို inference API ကို ရည်ညွှန်းအောင် သတ်မှတ်ထားပါတယ်။

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

အထက်ပါ ကုဒ်မှာ -

- MCP အတွက် လိုအပ်တဲ့ libraries တွေကို import လုပ်ထားပါတယ်။
- client တစ်ခု ဖန်တီးထားပါတယ်။

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

ပထမဦးဆုံး `pom.xml` ဖိုင်ထဲ LangChain4j dependencies တွေ ထည့်ရပါမယ်။ MCP integration နဲ့ GitHub Models ကို ထောက်ပံ့ဖို့ ဒီ dependencies တွေ ထည့်ပါ။

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

ပြီးရင် Java client class ကို ဖန်တီးပါ။

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

အထက်ပါ ကုဒ်မှာ -

- **LangChain4j dependencies တွေ ထည့်ထားပါတယ်** - MCP integration, OpenAI official client နဲ့ GitHub Models ထောက်ပံ့မှုအတွက်လိုအပ်ပါတယ်။
- **LangChain4j libraries တွေကို import လုပ်ထားပါတယ်** - MCP integration နဲ့ OpenAI chat model အတွက်။
- **`ChatLanguageModel` တစ်ခု ဖန်တီးထားပါတယ်** - GitHub token နဲ့ GitHub Models သုံးဖို့ configure လုပ်ထားပါတယ်။
- **HTTP transport ကို စီစဉ်ထားပါတယ်** - Server-Sent Events (SSE) သုံးပြီး MCP server နဲ့ ချိတ်ဆက်ရန်။
- **MCP client တစ်ခု ဖန်တီးထားပါတယ်** - server နဲ့ ဆက်သွယ်မှုကို ကိုင်တွယ်ပေးမယ်။
- **LangChain4j ရဲ့ MCP support ကို အသုံးပြုထားပါတယ်** - LLM နဲ့ MCP server တွေကို ပေါင်းစပ်ဖို့ လွယ်ကူစေပါတယ်။

အရမ်းကောင်းပြီ၊ နောက်တစ်ဆင့်မှာ server ရဲ့ capabilities တွေကို စာရင်းပြုလုပ်ကြရအောင်။

### -2- server capabilities စာရင်းပြုလုပ်ခြင်း

ယခု server နဲ့ ချိတ်ဆက်ပြီး capabilities တွေကို မေးမြန်းကြမယ်။

### TypeScript

အဲဒီ class ထဲမှာ အောက်ပါ method တွေ ထည့်ပါ။

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

အထက်ပါ ကုဒ်မှာ -

- server နဲ့ ချိတ်ဆက်ဖို့ `connectToServer` method ထည့်ထားပါတယ်။
- app flow ကို ကိုင်တွယ်မယ့် `run` method တစ်ခု ဖန်တီးထားပြီး ယခုအချိန်မှာ tools တွေကို စာရင်းပြုလုပ်တာပဲ ဖြစ်ပါတယ်၊ နောက်ပိုင်းမှာ ပိုမိုတိုးချဲ့ပါမယ်။

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

ဒီမှာ -

- resources နဲ့ tools တွေကို စာရင်းပြုလုပ်ပြီး print ထုတ်ထားပါတယ်။ tools အတွက် `inputSchema` ကိုလည်း စာရင်းပြုလုပ်ထားပြီး နောက်ပိုင်းမှာ အသုံးပြုမှာဖြစ်ပါတယ်။

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

အထက်ပါ ကုဒ်မှာ -

- MCP Server မှာ ရနိုင်တဲ့ tools တွေကို စာရင်းပြုလုပ်ထားပါတယ်။
- tool တစ်ခုချင်းစီအတွက် name, description နဲ့ schema ကို စာရင်းပြုလုပ်ထားပါတယ်။ schema က tools တွေကို ခေါ်ဖို့ အသုံးပြုမယ့် အချက်အလက်ဖြစ်ပါတယ်။

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

အထက်ပါ ကုဒ်မှာ -

- MCP server မှ tools အားလုံးကို အလိုအလျောက် ရှာဖွေပြီး မှတ်ပုံတင်ပေးတဲ့ `McpToolProvider` တစ်ခု ဖန်တီးထားပါတယ်။
- tool provider က MCP tool schemas နဲ့ LangChain4j tool format အကြား ပြောင်းလဲပေးတာကို ကိုင်တွယ်ပေးပါတယ်။
- ဒီနည်းလမ်းက tools စာရင်းပြုလုပ်ခြင်းနဲ့ ပြောင်းလဲခြင်းကို လက်ဖြင့် မလုပ်ရတော့ပဲ အလိုအလျောက် ပြုလုပ်ပေးပါတယ်။

### -3- server capabilities ကို LLM tools အဖြစ် ပြောင်းလဲခြင်း

server capabilities စာရင်းပြုလုပ်ပြီးနောက် LLM နားလည်နိုင်တဲ့ ပုံစံသို့ ပြောင်းလဲရပါမယ်။ ပြောင်းလဲပြီးရင် ဒီ capabilities တွေကို LLM အတွက် tools အဖြစ် ပေးနိုင်ပါပြီ။

### TypeScript

1. MCP Server response ကို LLM သုံးနိုင်တဲ့ tool format သို့ ပြောင်းဖို့ အောက်ပါ code ကို ထည့်ပါ။

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

    အထက်ပါ code က MCP Server response ကို LLM နားလည်နိုင်တဲ့ tool definition format သို့ ပြောင်းပေးပါတယ်။

1. `run` method ကို update လုပ်ပြီး server capabilities တွေကို စာရင်းပြုလုပ်ပါ။

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

    အထက်ပါ code မှာ `run` method ကို update လုပ်ပြီး result ကို map လုပ်ကာ entry တစ်ခုချင်းစီအတွက် `openAiToolAdapter` ကို ခေါ်ပါတယ်။

### Python

1. ပထမဦးဆုံး converter function ကို ဖန်တီးပါ။

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

    `convert_to_llm_tools` function မှာ MCP tool response ကို LLM နားလည်နိုင်တဲ့ ပုံစံသို့ ပြောင်းပေးပါတယ်။

1. client code ကို update လုပ်ပြီး ဒီ function ကို အသုံးပြုပါ။

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    ဒီမှာ MCP tool response ကို LLM သုံးနိုင်တဲ့ ပုံစံသို့ ပြောင်းဖို့ `convert_to_llm_tool` ကို ခေါ်သုံးထားပါတယ်။

### .NET

1. MCP tool response ကို LLM နားလည်နိုင်တဲ့ ပုံစံသို့ ပြောင်းဖို့ code ထည့်ပါ။

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

အထက်ပါ code မှာ -

- `ConvertFrom` function တစ်ခု ဖန်တီးထားပြီး name, description နဲ့ input schema ကို လက်ခံပါတယ်။
- FunctionDefinition တစ်ခု ဖန်တီးပြီး ChatCompletionsDefinition ထဲ ပေးပို့ပါတယ်။ ChatCompletionsDefinition က LLM နားလည်နိုင်တဲ့ ပုံစံဖြစ်ပါတယ်။

1. ရှိပြီးသား code ကို update လုပ်ပြီး ဒီ function ကို အသုံးပြုပါ။

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

    အထက်ပါ code မှာ -

    - MCP tool response ကို LLM tool သို့ ပြောင်းဖို့ function ကို update လုပ်ထားပါတယ်။ ထည့်သွင်းထားတဲ့ code ကို အောက်မှာ ဖော်ပြထားပါတယ်။

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        input schema က tool response ရဲ့ "properties" attribute မှာ ပါဝင်တာကြောင့် ထုတ်ယူရပါတယ်။ ထို့နောက် `ConvertFrom` ကို tool အသေးစိတ်နဲ့ ခေါ်ပါတယ်။ အခုတော့ အလုပ်ကြီးပြီးပါပြီ၊ အသုံးပြုသူ prompt ကို ကိုင်တွယ်တဲ့ အဆင့်ကို ကြည့်ကြရအောင်။

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

အထက်ပါ code မှာ -

- သဘာဝဘာသာစကားနဲ့ ဆက်သွယ်ဖို့ `Bot` interface ရိုးရှင်းတစ်ခု သတ်မှတ်ထားပါတယ်။
- LangChain4j ရဲ့ `AiServices` ကို အသုံးပြုပြီး LLM နဲ့ MCP tool provider ကို အလိုအလျောက် ချိတ်ဆက်ထားပါတယ်။
- framework က tool schema ပြောင်းလဲခြင်းနဲ့ function ခေါ်ခြင်းကို အလိုအလျောက် ကိုင်တွယ်ပေးပါတယ်။
- ဒီနည်းလမ်းက manual tool conversion လုပ်စရာ မလိုတော့ပဲ MCP tools တွေကို LLM သုံးနိုင်တဲ့ ပုံစံသို့ ပြောင်းပေးတာကို LangChain4j က ကိုင်တွယ်ပေးပါတယ်။

အရမ်းကောင်းပြီ၊ အသုံးပြုသူ request တွေကို ကိုင်တွယ်ဖို့ ပြင်ဆင်ထားပြီဖြစ်တဲ့အတွက် နောက်တစ်ဆင့်ကို ဆက်လုပ်ကြရအောင်။

### -4- အသုံးပြုသူ prompt ကို ကိုင်တွယ်ခြင်း

ဒီအပိုင်းမှာ အသုံးပြုသူ request တွေကို ကိုင်တွယ်ပါမယ်။

### TypeScript

1. LLM ကို ခေါ်ဖို့ အသုံးပြုမယ့် method တစ်ခု ထည့်ပါ။

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

    အထက်ပါ code မှာ -

    - `callTools` method တစ်ခု ထည့်ထားပါတယ်။
    - method က LLM response ကို လက်ခံပြီး ဘယ် tools တွေ ခေါ်ထားသလဲ စစ်ဆေးပါတယ်။

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - LLM က tool တစ်ခု ခေါ်ဖို့ ပြောရင် tool ကို ခေါ်ပါတယ်။

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

1. `run` method ကို update လုပ်ပြီး LLM ကို ခေါ်ခြင်းနဲ့ `callTools` ကို ခေါ်ဖို့ ထည့်ပါ။

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

အရမ်းကောင်းပြီ၊ အကုန်လုံး code ကို ပြန်လည်ကြည့်ကြရအောင်။

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

1. LLM ကို ခေါ်ဖို့ လိုအပ်တဲ့ imports တွေ ထည့်ပါ။

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. LLM ကို ခေါ်ဖို့ function ကို ထည့်ပါ။

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

    အထက်ပါ code မှာ -

    - MCP server မှ ရရှိပြီး ပြောင်းလဲထားတဲ့ functions တွေကို LLM ကို ပေးပို့ထားပါတယ်။
    - LLM ကို functions တွေနဲ့ ခေါ်ထားပါတယ်။
    - ရလဒ်ကို စစ်ဆေးပြီး ဘယ် functions တွေ ခေါ်ရမလဲ စစ်ဆေးပါတယ်။
    - နောက်ဆုံးမှာ ခေါ်ရမယ့် functions များကို array အဖြစ် ပေးပို့ပါတယ်။

1. နောက်ဆုံးအဆင့်မှာ main code ကို update လုပ်ပါ။

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    အထက်ပါ code မှာ -

    - LLM က ခေါ်ဖို့ ပြောတဲ့ function နဲ့ MCP tool ကို `call_tool` ဖြင့် ခေါ်ပါတယ်။
    - MCP Server မှ tool call ရလဒ်ကို print ထုတ်ပါတယ်။

### .NET

1. LLM prompt request လုပ်ဖို့ code ကို ပြပါ။

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

    အထက်ပါ code မှာ -

    - MCP server မှ tools တွေ ရယူထားပါတယ်၊ `var tools = await GetMcpTools()`။
    - အသုံးပြုသူ prompt `userMessage` ကို သတ်မှတ်ထားပါတယ်။
    - model နဲ့ tools ကို သတ်မှတ်တဲ့ options object တစ်ခု ဖန်တီးထားပါတယ်။
    - LLM ကို request တစ်ခု လုပ်ထားပါတယ်။

1. နောက်ဆုံးအဆင့်မှာ LLM က function ခေါ်ဖို့ ပြောရင် စစ်ဆေးပါ။

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

    အထက်ပါ code မှာ -

    - function calls စာရင်းကို loop လုပ်ပါတယ်။
    - tool call တစ်ခုချင်းစီအတွက် name နဲ့ arguments ကို ဖော်ထုတ်ပြီး MCP client သုံးပြီး MCP server မှ tool ကို ခေါ်ပါတယ်။ နောက်ဆုံးမှာ ရလဒ်ကို print ထုတ်ပါတယ်။

အကုန်လုံး code ကို ပြန်လည်ကြည့်ပါ။

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

အထက်ပါ code မှာ -

- MCP server tools တွေနဲ့ သဘာဝဘာသာ prompt တွေကို သုံးပြီး ဆက်သွယ်ထားပါတယ်။
- LangChain4j framework က အလိုအလျောက် ကိုင်တွယ်ပေးတာတွေက -
  - အသုံးပြုသူ prompt ကို tool call တွေသို့ ပြောင်းလဲခြင်း။
  - LLM ရဲ့ ဆုံးဖြတ်ချက်အရ MCP tools ကို ခေါ်ခြင်း။
  - LLM နဲ့ MCP server အကြား စကားပြောမှုကို စီမံခန့်ခွဲခြင်း။
- `bot.chat()` method က MCP tool အလုပ်လုပ်မှုရလဒ်ပါဝင်နိုင်တဲ့ သဘာဝဘာသာဖြေကြားချက်တွေ ပြန်ပေးပါတယ်။
- ဒီနည်းလမ်းက အသုံးပြုသူတွေကို MCP implementation အကြောင်း မသိဘဲ prompt တွေနဲ့ လွယ်ကူစွာ အသုံးပြုနိုင်စေပါတယ်။

အပြည့်အစုံ code ဥပမာ -

```java
public class LangChain4jClient {
    
    public static void main(String[] args) throws Exception {        ChatLanguageModel model = OpenAiOfficialChatModel.builder()
                .isGitHubModels(true)
                .apiKey(System.getenv("GITHUB_TOKEN"))
                .timeout(Duration.ofSeconds(60))
                .modelName("gpt-4.1-nano")
                .timeout(Duration.ofSeconds(60))
                .build();

        McpTransport transport = new HttpMcpTransport.Builder()
                .sseUrl("http://localhost:8080/sse")
                .timeout(Duration.ofSeconds(60))
                .logRequests(true)
                .logResponses(true)
                .build();

        McpClient mcpClient = new DefaultMcpClient.Builder()
                .transport(transport)
                .build();

        ToolProvider toolProvider = McpToolProvider.builder()
                .mcpClients(List.of(mcpClient))
                .build();

        Bot bot = AiServices.builder(Bot.class)
                .chatLanguageModel(model)
                .toolProvider(toolProvider)
                .build();

        try {
            String response = bot.chat("Calculate the sum of 24.5 and 17.3 using the calculator service");
            System.out.println(response);

            response = bot.chat("What's the square root of 144?");
            System.out.println(response);

            response = bot.chat("Show me the help for the calculator service");
            System.out.println(response);
        } finally {
            mcpClient.close();
        }
    }
}
```

အရမ်းကောင်းပြီ၊ သင်လုပ်နိုင်ပြီ!

## အလုပ်အပ်

လေ့ကျင့်ခန်းက code ကို ယူပြီး server ကို tools ပိုများအောင် တိုးချဲ့ပါ။ ပြီးရင် LLM ပါဝင်တဲ့ client တစ်ခု ဖန်တီးပြီး လေ့ကျင့်ခန်းလို prompt များနဲ့ စမ်းသပ်ကြည့်ပါ။ ဒီနည်းလမ်းနဲ့ client တစ်ခု ဖန်တီးခြင်းက အသုံးပြုသူအတွက် prompt တွေကို သုံးပြီး MCP server tools တွေကို dynamic ခေါ်နိုင်တဲ့ အတွေ့အကြုံကောင်းမွန်စေပါလိမ့်မယ်။

## ဖြေရှင်းချက်

[Solution](/03-GettingStarted/03-

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းသည် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။