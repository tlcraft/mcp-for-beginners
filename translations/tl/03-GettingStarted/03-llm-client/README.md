<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T08:24:02+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "tl"
}
-->
# Paglikha ng kliyente gamit ang LLM

Sa ngayon, nakita mo na kung paano gumawa ng server at kliyente. Ang kliyente ay nakakapag-tawag sa server nang direkta para ilista ang mga tools, resources, at prompts nito. Ngunit, hindi ito gaanong praktikal na paraan. Ang iyong user ay nabubuhay sa panahon ng agentic at inaasahan nilang gumamit ng prompts at makipag-ugnayan sa isang LLM para gawin ito. Para sa iyong user, hindi mahalaga kung gagamit ka ng MCP o hindi para i-store ang iyong mga kakayahan, pero inaasahan nilang makipag-interact gamit ang natural na wika. Paano natin ito sosolusyunan? Ang solusyon ay ang pagdagdag ng LLM sa kliyente.

## Pangkalahatang-ideya

Sa araling ito, tututok tayo sa pagdagdag ng LLM sa iyong kliyente at ipapakita kung paano ito nagbibigay ng mas magandang karanasan para sa iyong user.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Gumawa ng kliyente na may LLM.
- Makipag-ugnayan nang maayos sa MCP server gamit ang LLM.
- Magbigay ng mas magandang karanasan sa end user sa bahagi ng kliyente.

## Paraan

Subukan nating unawain ang paraan na kailangan nating gawin. Ang pagdagdag ng LLM ay parang simple, pero gagawin ba talaga natin ito?

Ganito makikipag-ugnayan ang kliyente sa server:

1. Magtatag ng koneksyon sa server.

1. Ililista ang mga kakayahan, prompts, resources, at tools, at ise-save ang kanilang schema.

1. Magdadagdag ng LLM at ipapasa ang mga na-save na kakayahan at schema sa format na naiintindihan ng LLM.

1. Haharapin ang prompt ng user sa pamamagitan ng pagpapasa nito sa LLM kasama ang mga tools na inilista ng kliyente.

Maganda, ngayon na naiintindihan natin kung paano ito gagawin sa mataas na antas, subukan natin ito sa sumusunod na ehersisyo.

## Ehersisyo: Paglikha ng kliyente na may LLM

Sa ehersisyong ito, matututuhan natin kung paano magdagdag ng LLM sa ating kliyente.

## Pag-authenticate gamit ang GitHub Personal Access Token

Ang paggawa ng GitHub token ay isang diretso na proseso. Ganito ang paraan:

- Pumunta sa GitHub Settings – I-click ang iyong profile picture sa kanang itaas na bahagi at piliin ang Settings.
- Pumunta sa Developer Settings – Mag-scroll pababa at i-click ang Developer Settings.
- Piliin ang Personal Access Tokens – I-click ang Personal access tokens at pagkatapos ay Generate new token.
- I-configure ang Iyong Token – Magdagdag ng tala para sa reference, magtakda ng expiration date, at piliin ang mga kinakailangang scopes (permissions).
- I-generate at Kopyahin ang Token – I-click ang Generate token, at siguraduhing kopyahin ito agad dahil hindi mo na ito makikita muli.

### -1- Kumonekta sa server

Gumawa muna tayo ng ating kliyente:

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

Sa naunang code ay:

- In-import ang mga kinakailangang libraries
- Gumawa ng klase na may dalawang miyembro, `client` at `openai` na tutulong sa atin na pamahalaan ang kliyente at makipag-ugnayan sa LLM.
- In-configure ang ating LLM instance para gamitin ang GitHub Models sa pamamagitan ng pagtatakda ng `baseUrl` na tumutukoy sa inference API.

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

Sa naunang code ay:

- In-import ang mga kinakailangang libraries para sa MCP
- Gumawa ng kliyente

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

Una, kailangan mong idagdag ang LangChain4j dependencies sa iyong `pom.xml` file. Idagdag ang mga dependencies na ito para paganahin ang MCP integration at suporta sa GitHub Models:

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

Pagkatapos, gumawa ng iyong Java client class:

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

Sa naunang code ay:

- **Nagdagdag ng LangChain4j dependencies**: Kinakailangan para sa MCP integration, opisyal na OpenAI client, at suporta sa GitHub Models
- **In-import ang LangChain4j libraries**: Para sa MCP integration at OpenAI chat model functionality
- **Gumawa ng `ChatLanguageModel`**: In-configure para gamitin ang GitHub Models gamit ang iyong GitHub token
- **Nagsaayos ng HTTP transport**: Gamit ang Server-Sent Events (SSE) para kumonekta sa MCP server
- **Gumawa ng MCP client**: Na siyang hahawak ng komunikasyon sa server
- **Gumamit ng built-in MCP support ng LangChain4j**: Na nagpapadali ng integrasyon sa pagitan ng LLMs at MCP servers

Maganda, para sa susunod na hakbang, ilista natin ang mga kakayahan sa server.

### -2 Ilahad ang mga kakayahan ng server

Ngayon ay kokonekta tayo sa server at hihingin ang mga kakayahan nito:

### Typescript

Sa parehong klase, idagdag ang mga sumusunod na method:

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

Sa naunang code ay:

- Nagdagdag ng code para kumonekta sa server, `connectToServer`.
- Gumawa ng `run` method na responsable sa paghawak ng daloy ng app. Sa ngayon, nililista lang nito ang mga tools pero magdadagdag pa tayo ng iba dito.

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

Narito ang idinagdag natin:

- Paglilista ng mga resources at tools at pag-print ng mga ito. Para sa tools, nililista rin natin ang `inputSchema` na gagamitin natin mamaya.

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

Sa naunang code ay:

- Nilista ang mga tools na available sa MCP Server
- Para sa bawat tool, nilista ang pangalan, deskripsyon, at schema nito. Ang huli ay gagamitin natin para tawagin ang mga tools sa lalong madaling panahon.

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

Sa naunang code ay:

- Gumawa ng `McpToolProvider` na awtomatikong naghahanap at nagrerehistro ng lahat ng tools mula sa MCP server
- Ang tool provider ang humahawak ng conversion sa pagitan ng MCP tool schemas at LangChain4j's tool format nang internal
- Ang paraang ito ay nag-aalis ng manual na proseso ng paglista at conversion ng tools

### -3- I-convert ang mga kakayahan ng server sa mga tool ng LLM

Susunod na hakbang pagkatapos ilista ang mga kakayahan ng server ay i-convert ang mga ito sa format na naiintindihan ng LLM. Kapag nagawa na natin ito, maibibigay natin ang mga kakayahang ito bilang mga tool sa ating LLM.

### TypeScript

1. Idagdag ang sumusunod na code para i-convert ang response mula sa MCP Server sa tool format na magagamit ng LLM:

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

    Ang code sa itaas ay kumukuha ng response mula sa MCP Server at kino-convert ito sa tool definition format na naiintindihan ng LLM.

1. I-update naman natin ang `run` method para ilista ang mga kakayahan ng server:

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

    Sa naunang code, in-update natin ang `run` method para i-map ang resulta at para sa bawat entry ay tawagin ang `openAiToolAdapter`.

### Python

1. Una, gumawa tayo ng sumusunod na converter function

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

    Sa function na `convert_to_llm_tools` ay kinukuha natin ang MCP tool response at kino-convert ito sa format na naiintindihan ng LLM.

1. Sunod, i-update natin ang client code para gamitin ang function na ito:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Dito, nagdagdag tayo ng tawag sa `convert_to_llm_tool` para i-convert ang MCP tool response sa bagay na maipapasa natin sa LLM mamaya.

### .NET

1. Magdagdag tayo ng code para i-convert ang MCP tool response sa format na naiintindihan ng LLM

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

Sa naunang code ay:

- Gumawa ng function na `ConvertFrom` na tumatanggap ng pangalan, deskripsyon, at input schema.
- Nagdefine ng functionality na lumilikha ng FunctionDefinition na ipinapasa sa ChatCompletionsDefinition. Ang huli ay naiintindihan ng LLM.

1. Tingnan natin kung paano natin ma-update ang ilang umiiral na code para magamit ang function na ito:

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

    Sa naunang code ay:

    - In-update ang function para i-convert ang MCP tool response sa LLM tool. Narito ang bahagi ng code na idinagdag:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Ang input schema ay bahagi ng tool response pero nasa "properties" attribute, kaya kailangan natin itong kunin. Bukod dito, tinawag natin ang `ConvertFrom` gamit ang detalye ng tool. Ngayon na nagawa na natin ang mabigat na bahagi, tingnan natin kung paano ito pinagsama habang hinahandle ang prompt ng user.

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

Sa naunang code ay:

- Nagdefine ng simpleng `Bot` interface para sa natural language interactions
- Ginamit ang LangChain4j's `AiServices` para awtomatikong i-bind ang LLM sa MCP tool provider
- Awtomatikong hinahandle ng framework ang tool schema conversion at function calling sa likod ng eksena
- Inaalis ng paraang ito ang manual na conversion ng tools - ang LangChain4j ang humahawak sa lahat ng komplikasyon ng pag-convert ng MCP tools sa LLM-compatible format

Maganda, handa na tayo para harapin ang mga kahilingan ng user, kaya gawin natin iyon sa susunod.

### -4- Hatiin ang kahilingan ng user prompt

Sa bahaging ito ng code, haharapin natin ang mga kahilingan ng user.

### TypeScript

1. Magdagdag ng method na gagamitin para tawagin ang ating LLM:

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

    Sa naunang code ay:

    - Nagdagdag ng method na `callTools`.
    - Tinitingnan ng method ang response ng LLM para malaman kung anong mga tools ang tinawag, kung meron man:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Tinatawag ang tool, kung sinasabi ng LLM na dapat itong tawagin:

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

1. I-update ang `run` method para isama ang tawag sa LLM at ang pagtawag sa `callTools`:

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

Maganda, ilista natin ang buong code:

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

1. Magdagdag tayo ng ilang imports na kailangan para tawagin ang LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Sunod, idagdag natin ang function na tatawag sa LLM:

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

    Sa naunang code ay:

    - Ipinasa natin ang mga functions na nakuha natin mula sa MCP server at na-convert sa LLM.
    - Tinawag natin ang LLM gamit ang mga functions na iyon.
    - Sinusuri natin ang resulta para malaman kung anong functions ang dapat tawagin, kung meron man.
    - Sa huli, ipinapasa natin ang array ng mga functions na tatawagin.

1. Panghuling hakbang, i-update natin ang main code:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Ayan, iyon ang panghuling hakbang, sa code sa itaas ay:

    - Tinatawag ang MCP tool gamit ang `call_tool` gamit ang function na inisip ng LLM na dapat tawagin base sa prompt.
    - Ipiniprint ang resulta ng tawag sa tool sa MCP Server.

### .NET

1. Ipakita natin ang code para sa LLM prompt request:

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

    Sa naunang code ay:

    - Kinuha ang mga tools mula sa MCP server, `var tools = await GetMcpTools()`.
    - Nagdefine ng user prompt `userMessage`.
    - Gumawa ng options object na nagsasaad ng model at tools.
    - Gumawa ng request papunta sa LLM.

1. Huling hakbang, tingnan natin kung iniisip ng LLM na dapat tayong tumawag ng function:

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

    Sa naunang code ay:

    - Nag-loop sa listahan ng function calls.
    - Para sa bawat tawag sa tool, kinukuha ang pangalan at mga argumento at tinatawagan ang tool sa MCP server gamit ang MCP client. Sa huli, ipiniprint ang mga resulta.

Narito ang buong code:

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

Sa naunang code ay:

- Gumamit ng simpleng natural language prompts para makipag-ugnayan sa mga tools ng MCP server
- Awtomatikong hinahandle ng LangChain4j framework ang:
  - Pag-convert ng user prompts sa tool calls kapag kinakailangan
  - Pagtawag sa tamang MCP tools base sa desisyon ng LLM
  - Pamamahala ng daloy ng pag-uusap sa pagitan ng LLM at MCP server
- Ang `bot.chat()` method ay nagbabalik ng natural language responses na maaaring kasama ang resulta mula sa pagpapatakbo ng MCP tools
- Ang paraang ito ay nagbibigay ng seamless na karanasan sa user kung saan hindi na nila kailangang malaman ang tungkol sa likod ng MCP implementation

Kompletong halimbawa ng code:

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

Magaling, nagawa mo na!

## Takdang-Aralin

Kunin ang code mula sa ehersisyo at palawakin ang server gamit ang mas maraming tools. Pagkatapos, gumawa ng kliyente na may LLM, tulad sa ehersisyo, at subukan ito gamit ang iba't ibang prompts upang matiyak na lahat ng iyong server tools ay natatawag nang dinamiko. Ang ganitong paraan ng paggawa ng kliyente ay nangangahulugan na magkakaroon ng mahusay na karanasan ang end user dahil nagagamit nila ang prompts, sa halip na eksaktong mga command ng kliyente, at hindi nila kailangang malaman kung may MCP server na tinatawag.

## Solusyon

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Mahahalagang Punto

- Ang pagdagdag ng LLM sa iyong kliyente ay nagbibigay ng mas magandang paraan para makipag-ugnayan ang mga user sa MCP Servers.
- Kailangan mong i-convert ang response ng MCP Server sa format na naiintindihan ng LLM.

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Karagdagang Mga Mapagkukunan

## Ano ang Susunod

- Susunod: [Paggamit ng server gamit ang Visual Studio Code](../04-vscode/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.