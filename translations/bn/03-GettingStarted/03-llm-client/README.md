<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T18:09:33+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "bn"
}
-->
# LLM দিয়ে ক্লায়েন্ট তৈরি করা

এখন পর্যন্ত, আপনি দেখেছেন কীভাবে একটি সার্ভার এবং ক্লায়েন্ট তৈরি করা যায়। ক্লায়েন্ট সরাসরি সার্ভারকে কল করে তার টুলস, রিসোর্স এবং প্রম্পটগুলো তালিকাভুক্ত করতে পেরেছে। তবে, এটি খুবই ব্যবহারিক পদ্ধতি নয়। আপনার ব্যবহারকারী এখন এজেন্টিক যুগে বাস করছে এবং প্রম্পট ব্যবহার করে LLM-এর সাথে যোগাযোগ করতে চায়। আপনার ব্যবহারকারী MCP ব্যবহার করছেন কিনা তা নিয়ে তেমন চিন্তা করে না, তবে তারা আশা করে যে তারা প্রাকৃতিক ভাষায় ইন্টারঅ্যাক্ট করতে পারবে। তাহলে আমরা কীভাবে এটি সমাধান করব? সমাধান হলো ক্লায়েন্টে একটি LLM যোগ করা।

## ওভারভিউ

এই পাঠে আমরা ক্লায়েন্টে একটি LLM যোগ করার ওপর ফোকাস করব এবং দেখাবো কীভাবে এটি ব্যবহারকারীর জন্য অনেক ভালো অভিজ্ঞতা প্রদান করে।

## শেখার উদ্দেশ্য

এই পাঠ শেষ করার পর, আপনি সক্ষম হবেন:

- একটি LLM সহ ক্লায়েন্ট তৈরি করতে।
- LLM ব্যবহার করে MCP সার্ভারের সাথে নির্বিঘ্নে যোগাযোগ করতে।
- ক্লায়েন্ট সাইডে ব্যবহারকারীর জন্য উন্নত অভিজ্ঞতা প্রদান করতে।

## পদ্ধতি

চলুন বুঝে নিই আমাদের কী পদ্ধতি নিতে হবে। LLM যোগ করা সহজ শোনালেও, আমরা কি সত্যিই এটি করব?

ক্লায়েন্ট সার্ভারের সাথে কীভাবে ইন্টারঅ্যাক্ট করবে:

1. সার্ভারের সাথে সংযোগ স্থাপন করা।

1. ক্ষমতা, প্রম্পট, রিসোর্স এবং টুলস তালিকাভুক্ত করা এবং তাদের স্কিমা সংরক্ষণ করা।

1. একটি LLM যোগ করা এবং সংরক্ষিত ক্ষমতা ও তাদের স্কিমা এমন ফরম্যাটে LLM-কে দেওয়া যা সে বুঝতে পারে।

1. ব্যবহারকারীর প্রম্পট হ্যান্ডেল করা, সেটি LLM-কে পাঠানো এবং ক্লায়েন্টের তালিকাভুক্ত টুলসের সাথে ব্যবহার করা।

দারুণ, এখন আমরা উচ্চ স্তরে বুঝে গেছি কীভাবে এটি করা যায়, নিচের অনুশীলনে এটি চেষ্টা করি।

## অনুশীলন: LLM সহ ক্লায়েন্ট তৈরি করা

এই অনুশীলনে, আমরা শিখব কীভাবে আমাদের ক্লায়েন্টে একটি LLM যোগ করতে হয়।

## GitHub Personal Access Token দিয়ে প্রমাণীকরণ

GitHub টোকেন তৈরি করা সহজ একটি প্রক্রিয়া। এভাবে করতে পারেন:

- GitHub Settings-এ যান – উপরের ডান কোণে আপনার প্রোফাইল ছবি ক্লিক করে Settings নির্বাচন করুন।
- Developer Settings-এ যান – নিচে স্ক্রল করে Developer Settings ক্লিক করুন।
- Personal Access Tokens নির্বাচন করুন – Personal access tokens ক্লিক করে Generate new token নির্বাচন করুন।
- আপনার টোকেন কনফিগার করুন – রেফারেন্সের জন্য একটি নোট যোগ করুন, মেয়াদ নির্ধারণ করুন এবং প্রয়োজনীয় স্কোপ (অনুমতি) নির্বাচন করুন।
- টোকেন তৈরি করুন এবং কপি করুন – Generate token ক্লিক করুন এবং তাৎক্ষণিক কপি করে রাখুন, কারণ পরে আর দেখতে পারবেন না।

### -1- সার্ভারের সাথে সংযোগ স্থাপন

প্রথমে আমাদের ক্লায়েন্ট তৈরি করি:

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

উপরের কোডে আমরা:

- প্রয়োজনীয় লাইব্রেরি ইমপোর্ট করেছি
- একটি ক্লাস তৈরি করেছি যার দুটি সদস্য `client` এবং `openai` আছে, যা আমাদের ক্লায়েন্ট পরিচালনা এবং LLM-এর সাথে ইন্টারঅ্যাক্ট করতে সাহায্য করবে।
- আমাদের LLM ইনস্ট্যান্স GitHub Models ব্যবহার করার জন্য কনফিগার করেছি, যেখানে `baseUrl` ইনফারেন্স API নির্দেশ করে।

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

উপরের কোডে আমরা:

- MCP এর জন্য প্রয়োজনীয় লাইব্রেরি ইমপোর্ট করেছি
- একটি ক্লায়েন্ট তৈরি করেছি

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

প্রথমে, আপনার `pom.xml` ফাইলে LangChain4j ডিপেন্ডেন্সি যোগ করতে হবে। MCP ইন্টিগ্রেশন এবং GitHub Models সাপোর্টের জন্য নিচের ডিপেন্ডেন্সিগুলো যোগ করুন:

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

তারপর আপনার Java ক্লায়েন্ট ক্লাস তৈরি করুন:

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

উপরের কোডে আমরা:

- **LangChain4j ডিপেন্ডেন্সি যোগ করেছি**: MCP ইন্টিগ্রেশন, OpenAI অফিসিয়াল ক্লায়েন্ট এবং GitHub Models সাপোর্টের জন্য
- **LangChain4j লাইব্রেরি ইমপোর্ট করেছি**: MCP ইন্টিগ্রেশন এবং OpenAI চ্যাট মডেল ফাংশনালিটির জন্য
- **`ChatLanguageModel` তৈরি করেছি**: GitHub Models ব্যবহার করার জন্য আপনার GitHub টোকেন দিয়ে কনফিগার করা
- **HTTP ট্রান্সপোর্ট সেটআপ করেছি**: Server-Sent Events (SSE) ব্যবহার করে MCP সার্ভারের সাথে সংযোগের জন্য
- **MCP ক্লায়েন্ট তৈরি করেছি**: যা সার্ভারের সাথে যোগাযোগ পরিচালনা করবে
- **LangChain4j এর বিল্ট-ইন MCP সাপোর্ট ব্যবহার করেছি**: যা LLM এবং MCP সার্ভারের মধ্যে ইন্টিগ্রেশন সহজ করে

দারুণ, পরবর্তী ধাপে চলুন সার্ভারের ক্ষমতাগুলো তালিকাভুক্ত করি।

### -2- সার্ভারের ক্ষমতাগুলো তালিকাভুক্ত করা

এখন আমরা সার্ভারের সাথে সংযোগ করব এবং তার ক্ষমতাগুলো জানতে চাইব:

### TypeScript

একই ক্লাসে নিচের মেথডগুলো যোগ করুন:

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

উপরের কোডে আমরা:

- সার্ভারের সাথে সংযোগ করার জন্য `connectToServer` কোড যোগ করেছি।
- একটি `run` মেথড তৈরি করেছি যা আমাদের অ্যাপ ফ্লো পরিচালনা করবে। এখন পর্যন্ত এটি শুধু টুলস তালিকাভুক্ত করে, তবে আমরা শীঘ্রই আরও যোগ করব।

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

আমরা যা যোগ করেছি:

- রিসোর্স এবং টুলস তালিকাভুক্ত করেছি এবং প্রিন্ট করেছি। টুলসের জন্য আমরা `inputSchema` ও তালিকাভুক্ত করেছি যা পরে ব্যবহার করব।

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

উপরের কোডে আমরা:

- MCP সার্ভারে উপলব্ধ টুলস তালিকাভুক্ত করেছি
- প্রতিটি টুলের নাম, বর্ণনা এবং তার স্কিমা তালিকাভুক্ত করেছি। স্কিমাটি আমরা শীঘ্রই টুল কল করার জন্য ব্যবহার করব।

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

উপরের কোডে আমরা:

- একটি `McpToolProvider` তৈরি করেছি যা স্বয়ংক্রিয়ভাবে MCP সার্ভার থেকে সব টুল আবিষ্কার ও রেজিস্টার করে
- টুল প্রোভাইডার MCP টুল স্কিমা এবং LangChain4j এর টুল ফরম্যাটের মধ্যে রূপান্তর নিজেই পরিচালনা করে
- এই পদ্ধতি ম্যানুয়াল টুল তালিকা ও রূপান্তর প্রক্রিয়া থেকে মুক্তি দেয়

### -3- সার্ভারের ক্ষমতাগুলো LLM টুলসে রূপান্তর করা

সার্ভারের ক্ষমতাগুলো তালিকাভুক্ত করার পরের ধাপ হলো সেগুলো এমন ফরম্যাটে রূপান্তর করা যা LLM বুঝতে পারে। একবার আমরা এটি করলে, আমরা এই ক্ষমতাগুলো LLM এর টুল হিসেবে দিতে পারব।

### TypeScript

1. MCP সার্ভারের রেসপন্সকে LLM ব্যবহারযোগ্য টুল ফরম্যাটে রূপান্তর করার জন্য নিচের কোড যোগ করুন:

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

    উপরের কোড MCP সার্ভারের রেসপন্স নিয়ে সেটিকে LLM বুঝতে পারার মতো টুল ডেফিনিশনে রূপান্তর করে।

1. এরপর `run` মেথড আপডেট করুন সার্ভারের ক্ষমতাগুলো তালিকাভুক্ত করার জন্য:

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

    উপরের কোডে, আমরা `run` মেথড আপডেট করেছি যাতে রেজাল্টের প্রতিটি এন্ট্রির জন্য `openAiToolAdapter` কল করা হয়।

### Python

1. প্রথমে, নিচের কনভার্টার ফাংশন তৈরি করি:

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

    `convert_to_llm_tools` ফাংশনে MCP টুল রেসপন্স নিয়ে সেটিকে LLM বুঝতে পারার ফরম্যাটে রূপান্তর করা হয়।

1. এরপর আমাদের ক্লায়েন্ট কোড আপডেট করি এই ফাংশন ব্যবহার করার জন্য:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    এখানে আমরা MCP টুল রেসপন্সকে LLM-এ ফিড করার জন্য `convert_to_llm_tool` কল যোগ করেছি।

### .NET

1. MCP টুল রেসপন্সকে LLM বুঝতে পারার ফরম্যাটে রূপান্তর করার কোড যোগ করি:

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

উপরের কোডে আমরা:

- `ConvertFrom` ফাংশন তৈরি করেছি যা নাম, বর্ণনা এবং ইনপুট স্কিমা নেয়।
- একটি ফাংশনালিটি ডিফাইন করেছি যা `FunctionDefinition` তৈরি করে এবং সেটি `ChatCompletionsDefinition` এ পাস করে। পরেরটি LLM বুঝতে পারে।

1. এখন দেখি কীভাবে বিদ্যমান কোড আপডেট করে এই ফাংশনের সুবিধা নেওয়া যায়:

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

    উপরের কোডে আমরা:

    - MCP টুল রেসপন্সকে LLM টুলে রূপান্তর করার জন্য ফাংশন আপডেট করেছি। নিচে আমরা যোগ করা কোড হাইলাইট করছি:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        ইনপুট স্কিমা টুল রেসপন্সের অংশ, কিন্তু "properties" অ্যাট্রিবিউটে থাকে, তাই সেটি বের করতে হয়। এরপর আমরা `ConvertFrom` কল করি টুলের বিস্তারিত নিয়ে। এখন আমরা মূল কাজ শেষ করেছি, চলুন দেখি কীভাবে এটি ব্যবহারকারীর প্রম্পট হ্যান্ডেল করার সময় একসাথে কাজ করে।

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

উপরের কোডে আমরা:

- প্রাকৃতিক ভাষায় ইন্টারঅ্যাকশনের জন্য একটি সাধারণ `Bot` ইন্টারফেস ডিফাইন করেছি
- LangChain4j এর `AiServices` ব্যবহার করেছি যা স্বয়ংক্রিয়ভাবে LLM এবং MCP টুল প্রোভাইডারকে বেঁধে দেয়
- ফ্রেমওয়ার্ক স্বয়ংক্রিয়ভাবে টুল স্কিমা রূপান্তর এবং ফাংশন কলিং পরিচালনা করে
- এই পদ্ধতি ম্যানুয়াল টুল রূপান্তর প্রয়োজনীয়তা দূর করে - LangChain4j MCP টুলগুলোকে LLM-সঙ্গত ফরম্যাটে রূপান্তর করার সব জটিলতা সামলায়

দারুণ, এখন আমরা ব্যবহারকারীর অনুরোধ হ্যান্ডেল করার জন্য প্রস্তুত, তাই চলুন সেটি করি।

### -4- ব্যবহারকারীর প্রম্পট হ্যান্ডেল করা

এই অংশে আমরা ব্যবহারকারীর অনুরোধ হ্যান্ডেল করব।

### TypeScript

1. LLM কল করার জন্য একটি মেথড যোগ করুন:

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

    উপরের কোডে আমরা:

    - `callTools` মেথড যোগ করেছি।
    - মেথডটি LLM রেসপন্স নিয়ে দেখে কোন টুল কল হয়েছে কিনা:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - যদি LLM নির্দেশ দেয়, তাহলে টুল কল করে:

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

1. `run` মেথড আপডেট করুন যাতে LLM কল এবং `callTools` কল অন্তর্ভুক্ত থাকে:

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

দারুণ, পুরো কোডটি নিচে দেওয়া হলো:

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

1. LLM কল করার জন্য প্রয়োজনীয় কিছু ইমপোর্ট যোগ করি:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. এরপর LLM কল করার ফাংশন যোগ করি:

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

    উপরের কোডে আমরা:

    - MCP সার্ভার থেকে পাওয়া এবং রূপান্তরিত ফাংশনগুলো LLM-কে দিয়েছি।
    - তারপর LLM কল করেছি ঐ ফাংশনগুলো দিয়ে।
    - ফলাফল দেখে কোন ফাংশন কল করতে হবে তা নির্ধারণ করেছি।
    - অবশেষে কল করার জন্য ফাংশনের একটি অ্যারে পাস করেছি।

1. শেষ ধাপে আমাদের মূল কোড আপডেট করি:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    এখানে আমরা:

    - LLM প্রম্পট অনুযায়ী MCP টুল কল করছি `call_tool` ফাংশনের মাধ্যমে।
    - MCP সার্ভারের টুল কলের ফলাফল প্রিন্ট করছি।

### .NET

1. LLM প্রম্পট রিকোয়েস্ট করার কোড দেখাই:

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

    উপরের কোডে আমরা:

    - MCP সার্ভার থেকে টুলস নিয়ে এসেছি, `var tools = await GetMcpTools()`.
    - একটি ব্যবহারকারীর প্রম্পট `userMessage` ডিফাইন করেছি।
    - মডেল এবং টুলস নির্দিষ্ট করে অপশন অবজেক্ট তৈরি করেছি।
    - LLM-এ রিকোয়েস্ট পাঠিয়েছি।

1. শেষ ধাপে দেখি LLM কি ফাংশন কল করা উচিত মনে করে:

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

    উপরের কোডে আমরা:

    - ফাংশন কলের তালিকা লুপ করেছি।
    - প্রতিটি টুল কলের জন্য নাম ও আর্গুমেন্ট পার্স করে MCP সার্ভারে কল করেছি এবং ফলাফল প্রিন্ট করেছি।

পুরো কোড নিচে দেওয়া হলো:

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

উপরের কোডে আমরা:

- সহজ প্রাকৃতিক ভাষার প্রম্পট ব্যবহার করে MCP সার্ভারের টুলসের সাথে ইন্টারঅ্যাক্ট করেছি
- LangChain4j ফ্রেমওয়ার্ক স্বয়ংক্রিয়ভাবে পরিচালনা করে:
  - প্রয়োজন হলে ব্যবহারকারীর প্রম্পটকে টুল কল এ রূপান্তর করা
  - LLM এর সিদ্ধান্ত অনুযায়ী MCP টুলস কল করা
  - LLM এবং MCP সার্ভারের মধ্যে কথোপকথনের প্রবাহ নিয়ন্ত্রণ করা
- `bot.chat()` মেথড প্রাকৃতিক ভাষায় উত্তর দেয় যা MCP টুল এক্সিকিউশনের ফলাফলও অন্তর্ভুক্ত করতে পারে
- এই পদ্ধতি ব্যবহারকারীর জন্য নির্বিঘ্ন অভিজ্ঞতা দেয় যেখানে তারা MCP বাস্তবায়নের কথা জানার প্রয়োজন হয় না

সম্পূর্ণ কোড উদাহরণ:

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

দারুণ, আপনি সফল হয়েছেন!

## অ্যাসাইনমেন্ট

অনুশীলনের কোড নিয়ে সার্ভারে আরও কিছু টুল যোগ করে তৈরি করুন। তারপর অনুশীলনের মতো একটি LLM সহ ক্লায়েন্ট তৈরি করুন এবং বিভিন্ন প্রম্পট দিয়ে পরীক্ষা করুন যাতে নিশ্চিত হওয়া যায় আপনার সব সার্ভার টুল ডায়নামিকভাবে কল হচ্ছে। এই পদ্ধতিতে ক্লায়েন্ট তৈরি করলে শেষ ব্যবহারকারীর জন্য চমৎকার অভিজ্ঞতা হয় কারণ তারা প্রম্পট ব্যবহার করে কাজ করতে পারে, সঠিক ক্লায়েন্ট কমান্ড না জানলেও, এবং MCP সার্ভার কল হওয়ার বিষয়টি তাদের অজানা থাকে।

## সমাধান

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## মূল বিষয়সমূহ

- ক্লায়েন্টে একটি LLM যোগ করলে ব্যবহারকারীরা MCP সার্ভারের সাথে আরও ভালোভাবে ইন্টারঅ্যাক্ট করতে পারে।
- MCP সার্ভারের রেসপন্সকে LLM বুঝতে পারার ফরম্যাটে রূপান্তর করতে হয়।

## নমুনা

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## অতিরিক্ত রিসোর্স

## পরবর্তী ধাপ

- পরবর্তী: [Visual Studio Code ব্যবহার করে সার্ভার ব্যবহার](../04-vscode/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।