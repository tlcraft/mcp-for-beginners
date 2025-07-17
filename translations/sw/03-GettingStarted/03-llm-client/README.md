<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T19:11:25+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sw"
}
-->
# Kuunda mteja na LLM

Hadi sasa, umeona jinsi ya kuunda seva na mteja. Mteja amekuwa na uwezo wa kuita seva moja kwa moja ili kuorodhesha zana zake, rasilimali na maelekezo. Hata hivyo, hii si njia bora sana. Mtumiaji wako anaishi katika enzi ya mawakala na anatarajia kutumia maelekezo na kuwasiliana na LLM kufanya hivyo. Kwa mtumiaji wako, haijalishi kama unatumia MCP au la kuhifadhi uwezo wako lakini wanatarajia kutumia lugha ya asili kuwasiliana. Basi tunatatuaje hili? Suluhisho ni kuongeza LLM kwenye mteja.

## Muhtasari

Katika somo hili tunazingatia kuongeza LLM kwenye mteja wako na kuonyesha jinsi hii inavyotoa uzoefu bora kwa mtumiaji wako.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kuunda mteja mwenye LLM.
- Kuunganishwa kwa urahisi na seva ya MCP kwa kutumia LLM.
- Kutoa uzoefu bora kwa mtumiaji upande wa mteja.

## Mbinu

Hebu tujifunze mbinu tunayohitaji kuchukua. Kuongeza LLM inaonekana rahisi, lakini je, tutafanya hivyo kweli?

Hivi ndivyo mteja atavyowasiliana na seva:

1. Kuanzisha muunganisho na seva.

1. Kuorodhesha uwezo, maelekezo, rasilimali na zana, na kuhifadhi muundo wake.

1. Kuongeza LLM na kupitisha uwezo ulihifadhiwa pamoja na muundo wake kwa njia ambayo LLM inaelewa.

1. Kushughulikia maelekezo ya mtumiaji kwa kuyapitia LLM pamoja na zana zilizoorodheshwa na mteja.

Nzuri, sasa tunaelewa jinsi ya kufanya hili kwa kiwango cha juu, hebu tujaribu katika zoezi lililopo hapa chini.

## Zoezi: Kuunda mteja mwenye LLM

Katika zoezi hili, tutajifunza kuongeza LLM kwenye mteja wetu.

## Uthibitishaji kwa kutumia GitHub Personal Access Token

Kuunda tokeni ya GitHub ni mchakato rahisi. Hapa ni jinsi unavyoweza kufanya hivyo:

- Nenda kwenye GitHub Settings – Bonyeza picha yako ya wasifu upande wa juu kulia na chagua Settings.
- Elekea kwenye Developer Settings – Skrolli chini na bonyeza Developer Settings.
- Chagua Personal Access Tokens – Bonyeza Personal access tokens kisha Generate new token.
- Sanidi Tokeni Yako – Ongeza maelezo kwa kumbukumbu, weka tarehe ya kumalizika, na chagua idhini zinazohitajika (permissions).
- Tengeneza na Nakili Tokeni – Bonyeza Generate token, na hakikisha unakili mara moja, kwa sababu hutakuwa na nafasi ya kuiona tena.

### -1- Unganisha na seva

Hebu tuanze kwa kuunda mteja wetu:

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

Katika msimbo uliotangulia tume:

- Kuleta maktaba zinazohitajika
- Kuunda darasa lenye wanachama wawili, `client` na `openai` ambao watatusaidia kusimamia mteja na kuwasiliana na LLM mtawaliwa.
- Kusanidi mfano wetu wa LLM kutumia GitHub Models kwa kuweka `baseUrl` kuelekeza kwenye inference API.

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

Katika msimbo uliotangulia tume:

- Kuleta maktaba zinazohitajika kwa MCP
- Kuunda mteja

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

Kwanza, utahitaji kuongeza utegemezi wa LangChain4j kwenye faili yako ya `pom.xml`. Ongeza utegemezi huu kuwezesha ushirikiano wa MCP na msaada wa GitHub Models:

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

Kisha unda darasa lako la mteja wa Java:

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

Katika msimbo uliotangulia tume:

- **Kuongeza utegemezi wa LangChain4j**: Unaohitajika kwa ushirikiano wa MCP, mteja rasmi wa OpenAI, na msaada wa GitHub Models
- **Kuleta maktaba za LangChain4j**: Kwa ushirikiano wa MCP na utendaji wa mfano wa mazungumzo wa OpenAI
- **Kuunda `ChatLanguageModel`**: Iliyosanidiwa kutumia GitHub Models na tokeni yako ya GitHub
- **Kusanidi usafirishaji wa HTTP**: Kutumia Server-Sent Events (SSE) kuungana na seva ya MCP
- **Kuunda mteja wa MCP**: Atakayesimamia mawasiliano na seva
- **Kutumia msaada wa MCP uliopo ndani ya LangChain4j**: Unaorahisisha ushirikiano kati ya LLMs na seva za MCP

Nzuri, kwa hatua yetu inayofuata, hebu tuorodheshe uwezo kwenye seva.

### -2- Orodhesha uwezo wa seva

Sasa tutaungana na seva na kuomba uwezo wake:

### Typescript

Katika darasa lile lile, ongeza njia zifuatazo:

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

Katika msimbo uliotangulia tume:

- Kuongeza msimbo wa kuungana na seva, `connectToServer`.
- Kuunda njia ya `run` inayohusika na kusimamia mtiririko wa programu yetu. Hadi sasa inaorodhesha zana tu lakini tutaziongeza zaidi hivi karibuni.

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

Hapa tuliongeza:

- Kuorodhesha rasilimali na zana na kuzichapisha. Kwa zana pia tunaorodhesha `inputSchema` ambayo tutaitumia baadaye.

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

Katika msimbo uliotangulia tume:

- Kuweka orodha ya zana zinazopatikana kwenye MCP Server
- Kwa kila zana, kuorodhesha jina, maelezo na muundo wake. Hii ni kitu ambacho tutatumia kuitumia zana hivi karibuni.

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

Katika msimbo uliotangulia tume:

- Kuunda `McpToolProvider` inayogundua na kusajili moja kwa moja zana zote kutoka kwa seva ya MCP
- Mtoa zana anasimamia uongofu kati ya miundo ya zana za MCP na muundo wa zana wa LangChain4j ndani
- Mbinu hii inaficha mchakato wa kuorodhesha zana na uongofu wa mikono

### -3- Badilisha uwezo wa seva kuwa zana za LLM

Hatua inayofuata baada ya kuorodhesha uwezo wa seva ni kubadilisha kuwa muundo unaoeleweka na LLM. Mara tu tutakapofanya hivyo, tunaweza kutoa uwezo huu kama zana kwa LLM yetu.

### TypeScript

1. Ongeza msimbo ufuatao kubadilisha majibu kutoka MCP Server kuwa muundo wa zana unaotumika na LLM:

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

    Msimbo huu unachukua jibu kutoka MCP Server na kubadilisha kuwa muundo wa zana unaoeleweka na LLM.

1. Sasa tuboreshe njia ya `run` kuorodhesha uwezo wa seva:

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

    Katika msimbo uliotangulia, tumeongeza njia ya `run` kupitia matokeo na kwa kila kipengee kuita `openAiToolAdapter`.

### Python

1. Kwanza, hebu tuunde kazi ifuatayo ya kubadilisha

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

    Katika kazi ya `convert_to_llm_tools` tunachukua jibu la zana ya MCP na kulibadilisha kuwa muundo unaoeleweka na LLM.

1. Kisha, tuboreshe msimbo wetu wa mteja kutumia kazi hii kama ifuatavyo:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Hapa, tunaongeza wito wa `convert_to_llm_tool` kubadilisha jibu la zana ya MCP kuwa kitu ambacho tunaweza kumpa LLM baadaye.

### .NET

1. Tuweke msimbo wa kubadilisha jibu la zana ya MCP kuwa kitu ambacho LLM inaelewa

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

Katika msimbo uliotangulia tume:

- Kuunda kazi `ConvertFrom` inayopokea jina, maelezo na muundo wa ingizo.
- Kueleza utendaji unaounda `FunctionDefinition` inayopitishwa kwa `ChatCompletionsDefinition`. Hii ni kitu ambacho LLM inaelewa.

1. Hebu tuone jinsi tunavyoweza kuboresha baadhi ya misimbo iliyopo kutumia kazi hii:

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

Katika msimbo uliotangulia, tume:

- Kuboresha kazi kubadilisha jibu la zana ya MCP kuwa zana ya LLM. Hebu tuelezee msimbo tuliouongeza:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

    Muundo wa ingizo ni sehemu ya jibu la zana lakini kwenye sifa ya "properties", hivyo tunahitaji kutoa. Zaidi ya hayo, sasa tunaita `ConvertFrom` na maelezo ya zana. Sasa tumefanya kazi ngumu, hebu tuone jinsi wito unavyoungana tunaposhughulikia maelekezo ya mtumiaji.

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

Katika msimbo uliotangulia tume:

- Kueleza interface rahisi ya `Bot` kwa mawasiliano ya lugha ya asili
- Kutumia `AiServices` ya LangChain4j kuunganisha moja kwa moja LLM na mtoa zana wa MCP
- Mfumo unashughulikia moja kwa moja uongofu wa muundo wa zana na wito wa kazi nyuma ya pazia
- Mbinu hii inaondoa uongofu wa mikono wa zana - LangChain4j inasimamia ugumu wote wa kubadilisha zana za MCP kuwa muundo unaolingana na LLM

Nzuri, sasa tumejiandaa kushughulikia maombi ya mtumiaji, basi tuanze na hilo.

### -4- Shughulikia ombi la maelekezo ya mtumiaji

Katika sehemu hii ya msimbo, tutashughulikia maombi ya mtumiaji.

### TypeScript

1. Ongeza njia itakayotumika kuita LLM yetu:

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

    Katika msimbo uliotangulia tume:

    - Kuongeza njia `callTools`.
    - Njia hii inachukua jibu la LLM na kuangalia ni zana gani zimeitwa, kama zipo:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Kuita zana, ikiwa LLM inaonyesha inapaswa kuitwa:

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

1. Boresha njia ya `run` kujumuisha wito kwa LLM na kuitwa kwa `callTools`:

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

Nzuri, hebu tuorodheshe msimbo mzima:

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

1. Ongeza baadhi ya imports zinazohitajika kuitisha LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Kisha, ongeza kazi itakayoitisha LLM:

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

Katika msimbo uliotangulia tume:

- Kupitisha kazi zetu, tulizozipata kwenye seva ya MCP na kuzibadilisha, kwa LLM.
- Kuita LLM na kazi hizo.
- Kagua matokeo kuona ni kazi gani tunapaswa kuitisha, kama zipo.
- Mwisho, tunapita orodha ya kazi za kuitisha.

1. Hatua ya mwisho, tuboreshe msimbo wetu mkuu:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

Hapo, hiyo ilikuwa hatua ya mwisho, katika msimbo huu tume:

- Kuita zana ya MCP kupitia `call_tool` kwa kutumia kazi ambayo LLM iliona inapaswa kuitwa kulingana na maelekezo yetu.
- Kuchapisha matokeo ya wito wa zana kwa seva ya MCP.

### .NET

1. Tuweke msimbo wa ombi la maelekezo kwa LLM:

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

Katika msimbo uliotangulia tume:

- Kupata zana kutoka seva ya MCP, `var tools = await GetMcpTools()`.
- Kueleza maelekezo ya mtumiaji `userMessage`.
- Kuunda chaguo linaloeleza mfano na zana.
- Kufanya ombi kwa LLM.

1. Hatua ya mwisho, tuone kama LLM inadhani tunapaswa kuita kazi:

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

Katika msimbo uliotangulia tume:

- Kupitia orodha ya wito wa kazi.
- Kwa kila wito wa zana, kutambua jina na hoja na kuitisha zana kwenye seva ya MCP kwa kutumia mteja wa MCP. Mwisho tunachapisha matokeo.

Hapa ni msimbo mzima:

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

Katika msimbo uliotangulia tume:

- Kutumia maelekezo rahisi ya lugha ya asili kuwasiliana na zana za seva ya MCP
- Mfumo wa LangChain4j unashughulikia moja kwa moja:
  - Kubadilisha maelekezo ya mtumiaji kuwa wito wa zana inapohitajika
  - Kuita zana zinazofaa za MCP kulingana na uamuzi wa LLM
  - Kusimamia mtiririko wa mazungumzo kati ya LLM na seva ya MCP
- Njia ya `bot.chat()` inarudisha majibu ya lugha ya asili ambayo yanaweza kujumuisha matokeo kutoka kwa utekelezaji wa zana za MCP
- Mbinu hii hutoa uzoefu mzuri kwa mtumiaji ambapo hawahitaji kujua kuhusu utekelezaji wa MCP nyuma ya pazia

Mfano kamili wa msimbo:

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

Nzuri, umefanikiwa!

## Kazi ya Nyumbani

Chukua msimbo kutoka kwenye zoezi na uendeleze seva na zana zaidi. Kisha unda mteja mwenye LLM, kama ilivyo kwenye zoezi, na ujaribu kwa maelekezo tofauti kuhakikisha zana zote za seva zinaitwa kwa njia ya mabadiliko. Njia hii ya kujenga mteja inamaanisha mtumiaji wa mwisho atapata uzoefu mzuri kwani wanaweza kutumia maelekezo badala ya amri kamili za mteja, na hawatambui kama seva ya MCP inaitwa.

## Suluhisho

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Muhimu Kukumbuka

- Kuongeza LLM kwenye mteja wako kunatoa njia bora kwa watumiaji kuwasiliana na seva za MCP.
- Unahitaji kubadilisha jibu la seva ya MCP kuwa kitu ambacho LLM inaelewa.

## Sampuli

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

## Nini Kifuatacho

- Ifuatayo: [Kutumia seva kwa kutumia Visual Studio Code](../04-vscode/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.