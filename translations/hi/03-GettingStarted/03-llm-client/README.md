<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a656dbc7648e07da08eb4d1ffde4938e",
  "translation_date": "2025-07-22T09:15:48+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hi"
}
-->
# LLM के साथ क्लाइंट बनाना

अब तक, आपने देखा कि सर्वर और क्लाइंट कैसे बनाते हैं। क्लाइंट ने सर्वर को स्पष्ट रूप से कॉल करके उसके टूल्स, संसाधनों और प्रॉम्प्ट्स की सूची बनाई है। हालांकि, यह बहुत व्यावहारिक तरीका नहीं है। आपका उपयोगकर्ता एजेंटिक युग में रहता है और प्रॉम्प्ट्स का उपयोग करने और LLM के साथ संवाद करने की उम्मीद करता है। आपके उपयोगकर्ता को इस बात से कोई फर्क नहीं पड़ता कि आप अपनी क्षमताओं को स्टोर करने के लिए MCP का उपयोग करते हैं या नहीं, लेकिन वे प्राकृतिक भाषा का उपयोग करके बातचीत करने की उम्मीद करते हैं। तो हम इसे कैसे हल करें? समाधान क्लाइंट में LLM जोड़ने के बारे में है।

## अवलोकन

इस पाठ में हम आपके क्लाइंट में LLM जोड़ने पर ध्यान केंद्रित करेंगे और दिखाएंगे कि यह आपके उपयोगकर्ता के लिए बेहतर अनुभव कैसे प्रदान करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- LLM के साथ एक क्लाइंट बनाना।
- MCP सर्वर के साथ LLM का उपयोग करके सहजता से बातचीत करना।
- क्लाइंट साइड पर बेहतर उपयोगकर्ता अनुभव प्रदान करना।

## दृष्टिकोण

आइए समझते हैं कि हमें कौन सा दृष्टिकोण अपनाना चाहिए। LLM जोड़ना सरल लगता है, लेकिन क्या हम वास्तव में ऐसा करेंगे?

क्लाइंट सर्वर के साथ इस तरह से बातचीत करेगा:

1. सर्वर के साथ कनेक्शन स्थापित करें।

1. क्षमताओं, प्रॉम्प्ट्स, संसाधनों और टूल्स की सूची बनाएं और उनकी स्कीमा को सेव करें।

1. एक LLM जोड़ें और सेव की गई क्षमताओं और उनकी स्कीमा को उस प्रारूप में पास करें जिसे LLM समझता है।

1. उपयोगकर्ता प्रॉम्प्ट को संभालें और इसे LLM को पास करें, साथ ही क्लाइंट द्वारा सूचीबद्ध टूल्स को भी।

बहुत अच्छा, अब हम समझ गए हैं कि इसे उच्च स्तर पर कैसे किया जा सकता है। आइए इसे नीचे दिए गए अभ्यास में आजमाएं।

## अभ्यास: LLM के साथ क्लाइंट बनाना

इस अभ्यास में, हम अपने क्लाइंट में LLM जोड़ना सीखेंगे।

### GitHub Personal Access Token का उपयोग करके प्रमाणीकरण

GitHub टोकन बनाना एक सरल प्रक्रिया है। इसे कैसे करें:

- GitHub सेटिंग्स पर जाएं – ऊपर दाईं ओर अपने प्रोफ़ाइल चित्र पर क्लिक करें और सेटिंग्स चुनें।
- डेवलपर सेटिंग्स पर जाएं – नीचे स्क्रॉल करें और डेवलपर सेटिंग्स पर क्लिक करें।
- Personal Access Tokens चुनें – Personal Access Tokens पर क्लिक करें और फिर नया टोकन जनरेट करें।
- अपने टोकन को कॉन्फ़िगर करें – संदर्भ के लिए एक नोट जोड़ें, समाप्ति तिथि सेट करें, और आवश्यक स्कोप (अनुमतियां) चुनें।
- टोकन जनरेट करें और कॉपी करें – टोकन जनरेट पर क्लिक करें और इसे तुरंत कॉपी करना सुनिश्चित करें, क्योंकि आप इसे फिर से नहीं देख पाएंगे।

### -1- सर्वर से कनेक्ट करें

पहले अपना क्लाइंट बनाएं:

#### TypeScript

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

ऊपर दिए गए कोड में हमने:

- आवश्यक लाइब्रेरीज़ को इंपोर्ट किया।
- एक क्लास बनाई जिसमें दो सदस्य हैं, `client` और `openai`, जो हमें क्लाइंट को प्रबंधित करने और LLM के साथ बातचीत करने में मदद करेंगे।
- GitHub Models का उपयोग करने के लिए `baseUrl` को सेट करके हमारे LLM इंस्टेंस को कॉन्फ़िगर किया।

#### Python

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

ऊपर दिए गए कोड में हमने:

- MCP के लिए आवश्यक लाइब्रेरीज़ को इंपोर्ट किया।
- एक क्लाइंट बनाया।

#### .NET

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

#### Java

सबसे पहले, आपको अपने `pom.xml` फ़ाइल में LangChain4j डिपेंडेंसीज़ जोड़ने की आवश्यकता होगी। MCP इंटीग्रेशन और GitHub Models सपोर्ट को सक्षम करने के लिए इन डिपेंडेंसीज़ को जोड़ें:

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

फिर अपनी Java क्लाइंट क्लास बनाएं:

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

ऊपर दिए गए कोड में हमने:

- **LangChain4j डिपेंडेंसीज़ जोड़ीं**: MCP इंटीग्रेशन, OpenAI आधिकारिक क्लाइंट, और GitHub Models सपोर्ट के लिए आवश्यक।
- **LangChain4j लाइब्रेरीज़ को इंपोर्ट किया**: MCP इंटीग्रेशन और OpenAI चैट मॉडल कार्यक्षमता के लिए।
- **एक `ChatLanguageModel` बनाया**: GitHub टोकन के साथ GitHub Models का उपयोग करने के लिए कॉन्फ़िगर किया।
- **HTTP ट्रांसपोर्ट सेट अप किया**: MCP सर्वर से कनेक्ट करने के लिए Server-Sent Events (SSE) का उपयोग किया।
- **एक MCP क्लाइंट बनाया**: जो सर्वर के साथ संचार को संभालेगा।
- **LangChain4j के बिल्ट-इन MCP सपोर्ट का उपयोग किया**: जो LLMs और MCP सर्वर्स के बीच इंटीग्रेशन को सरल बनाता है।

बहुत अच्छा, अगले चरण में, आइए सर्वर पर क्षमताओं की सूची बनाएं।

### -2- सर्वर क्षमताओं की सूची बनाएं

अब हम सर्वर से कनेक्ट करेंगे और उसकी क्षमताओं के लिए पूछेंगे:

#### TypeScript

उसी क्लास में निम्नलिखित मेथड्स जोड़ें:

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

ऊपर दिए गए कोड में हमने:

- सर्वर से कनेक्ट करने के लिए कोड जोड़ा, `connectToServer`।
- एक `run` मेथड बनाया जो हमारे ऐप फ्लो को संभालने के लिए जिम्मेदार है। अभी तक यह केवल टूल्स की सूची बनाता है, लेकिन हम इसमें जल्द ही और जोड़ेंगे।

#### Python

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

यहां हमने जो जोड़ा है:

- संसाधनों और टूल्स की सूची बनाई और उन्हें प्रिंट किया। टूल्स के लिए हमने `inputSchema` भी सूचीबद्ध किया जिसे हम बाद में उपयोग करेंगे।

#### .NET

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

        // TODO: convert tool definition from MCP tool to LLm tool     
    }

    return toolDefinitions;
}
```

ऊपर दिए गए कोड में हमने:

- MCP सर्वर पर उपलब्ध टूल्स की सूची बनाई।
- प्रत्येक टूल के लिए नाम, विवरण और उसकी स्कीमा सूचीबद्ध की। बाद में हम इसका उपयोग टूल्स को कॉल करने के लिए करेंगे।

#### Java

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

ऊपर दिए गए कोड में हमने:

- एक `McpToolProvider` बनाया जो MCP सर्वर से सभी टूल्स को स्वचालित रूप से खोजता और रजिस्टर करता है।
- टूल प्रोवाइडर MCP टूल स्कीमा और LangChain4j के टूल प्रारूप के बीच रूपांतरण को आंतरिक रूप से संभालता है।
- यह दृष्टिकोण मैनुअल टूल सूचीकरण और रूपांतरण प्रक्रिया को अमूर्त करता है।

### -3- सर्वर क्षमताओं को LLM टूल्स में बदलें

सर्वर क्षमताओं की सूची बनाने के बाद अगला कदम उन्हें उस प्रारूप में बदलना है जिसे LLM समझता है। एक बार ऐसा करने के बाद, हम इन क्षमताओं को LLM को टूल्स के रूप में प्रदान कर सकते हैं।

#### TypeScript

1. MCP सर्वर से प्रतिक्रिया को LLM टूल प्रारूप में बदलने के लिए निम्नलिखित कोड जोड़ें:

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

    ऊपर दिया गया कोड MCP सर्वर से प्रतिक्रिया लेता है और उसे टूल परिभाषा प्रारूप में बदलता है जिसे LLM समझ सकता है।

1. अगले चरण में `run` मेथड को अपडेट करें ताकि सर्वर क्षमताओं की सूची बनाई जा सके:

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

    ऊपर दिए गए कोड में हमने `run` मेथड को अपडेट किया ताकि परिणाम के माध्यम से मैप किया जा सके और प्रत्येक प्रविष्टि के लिए `openAiToolAdapter` को कॉल किया जा सके।

#### Python

1. पहले, निम्नलिखित कन्वर्टर फ़ंक्शन बनाएं:

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

    ऊपर दिए गए `convert_to_llm_tools` फ़ंक्शन में हम MCP टूल प्रतिक्रिया लेते हैं और उसे उस प्रारूप में बदलते हैं जिसे LLM समझ सकता है।

1. अगला, अपने क्लाइंट कोड को इस फ़ंक्शन का उपयोग करने के लिए अपडेट करें:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    यहां, हम MCP टूल प्रतिक्रिया को `convert_to_llm_tool` के माध्यम से बदल रहे हैं ताकि इसे बाद में LLM को फीड किया जा सके।

#### .NET

1. MCP टूल प्रतिक्रिया को LLM के लिए समझने योग्य प्रारूप में बदलने के लिए कोड जोड़ें:

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

ऊपर दिए गए कोड में हमने:

- एक फ़ंक्शन `ConvertFrom` बनाया जो नाम, विवरण और इनपुट स्कीमा लेता है।
- एक FunctionDefinition बनाया जो ChatCompletionsDefinition को पास किया जाता है। यह वह है जिसे LLM समझ सकता है।

1. कुछ मौजूदा कोड को अपडेट करने के लिए देखें कि हम इस फ़ंक्शन का लाभ कैसे उठा सकते हैं:

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

    ऊपर दिए गए कोड में हमने:

    - MCP टूल प्रतिक्रिया को LLM टूल में बदलने के लिए फ़ंक्शन को अपडेट किया। आइए जोड़े गए कोड को हाइलाइट करें:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        इनपुट स्कीमा टूल प्रतिक्रिया का हिस्सा है लेकिन "properties" एट्रिब्यूट पर है, इसलिए हमें इसे निकालने की आवश्यकता है। इसके अलावा, अब हम टूल विवरण के साथ `ConvertFrom` को कॉल करते हैं। अब हमने भारी काम कर लिया है, आइए देखें कि उपयोगकर्ता प्रॉम्प्ट को संभालते समय यह सब कैसे एक साथ आता है।

#### Java

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

ऊपर दिए गए कोड में हमने:

- प्राकृतिक भाषा इंटरैक्शन के लिए एक सरल `Bot` इंटरफ़ेस परिभाषित किया।
- LangChain4j के `AiServices` का उपयोग करके LLM को MCP टूल प्रोवाइडर के साथ स्वचालित रूप से बांधा।
- फ्रेमवर्क टूल स्कीमा रूपांतरण और फ़ंक्शन कॉलिंग को पर्दे के पीछे स्वचालित रूप से संभालता है।
- यह दृष्टिकोण MCP टूल्स को LLM-संगत प्रारूप में बदलने की मैनुअल प्रक्रिया को समाप्त करता है।

बहुत अच्छा, अब हम उपयोगकर्ता अनुरोधों को संभालने के लिए तैयार हैं, तो आइए इसे अगले चरण में निपटाएं।

### -4- उपयोगकर्ता प्रॉम्प्ट अनुरोध को संभालें

इस कोड भाग में, हम उपयोगकर्ता अनुरोधों को संभालेंगे।

#### TypeScript

1. एक मेथड जोड़ें जो हमारे LLM को कॉल करने के लिए उपयोग किया जाएगा:

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

    ऊपर दिए गए कोड में हमने:

    - एक मेथड `callTools` जोड़ा।
    - मेथड LLM प्रतिक्रिया लेता है और जांचता है कि क्या कोई टूल्स कॉल किए गए हैं:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - यदि LLM संकेत देता है कि टूल को कॉल किया जाना चाहिए, तो टूल को कॉल करता है:

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

1. `run` मेथड को अपडेट करें ताकि LLM को कॉल किया जा सके और `callTools` को कॉल किया जा सके:

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

बहुत अच्छा, आइए कोड को पूरा सूचीबद्ध करें:

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

#### Python

1. LLM को कॉल करने के लिए आवश्यक इंपोर्ट्स जोड़ें:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. अगला, वह फ़ंक्शन जोड़ें जो LLM को कॉल करेगा:

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

    ऊपर दिए गए कोड में हमने:

    - हमारे फ़ंक्शंस, जिन्हें हमने MCP सर्वर पर पाया और बदला, को LLM को पास किया।
    - फिर हमने LLM को इन फ़ंक्शंस के साथ कॉल किया।
    - फिर, हम परिणाम का निरीक्षण कर रहे हैं कि कौन से फ़ंक्शंस कॉल किए जाने चाहिए, यदि कोई हो।
    - अंत में, हम कॉल करने के लिए फ़ंक्शंस की एक सूची पास कर रहे हैं।

1. अंतिम चरण, मुख्य कोड को अपडेट करें:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    वहां, यह अंतिम चरण था। ऊपर दिए गए कोड में हम:

    - MCP टूल को `call_tool` के माध्यम से कॉल कर रहे हैं, एक फ़ंक्शन का उपयोग करके जिसे LLM ने सोचा कि हमारे प्रॉम्प्ट के आधार पर कॉल किया जाना चाहिए।
    - MCP सर्वर पर टूल कॉल का परिणाम प्रिंट कर रहे हैं।

#### .NET

1. LLM प्रॉम्प्ट अनुरोध करने के लिए कोड दिखाएं:

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

    ऊपर दिए गए कोड में हमने:

    - MCP सर्वर से टूल्स प्राप्त किए, `var tools = await GetMcpTools()`।
    - एक उपयोगकर्ता प्रॉम्प्ट `userMessage` परिभाषित किया।
    - एक विकल्प ऑब्जेक्ट बनाया जिसमें मॉडल और टूल्स निर्दिष्ट किए गए।
    - LLM की ओर एक अनुरोध किया।

1. एक अंतिम चरण, देखें कि क्या LLM सोचता है कि हमें कोई फ़ंक्शन कॉल करना चाहिए:

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

    ऊपर दिए गए कोड में हमने:

    - फ़ंक्शन कॉल की सूची के माध्यम से लूप किया।
    - प्रत्येक टूल कॉल के लिए, नाम और तर्कों को पार्स किया और MCP सर्वर पर MCP क्लाइंट का उपयोग करके टूल को कॉल किया। अंत में हम परिणाम प्रिंट करते हैं।

यहां पूरा कोड है:

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

#### Java

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

ऊपर दिए गए कोड में हमने:

- MCP सर्वर टूल्स के साथ बातचीत करने के लिए सरल प्राकृतिक भाषा प्रॉम्प्ट्स का उपयोग किया।
- LangChain4j फ्रेमवर्क स्वचालित रूप से संभालता है:
  - जब आवश्यक हो तो उपयोगकर्ता प्रॉम्प्ट्स को टूल कॉल्स में बदलना।
  - LLM के निर्णय के आधार पर उपयुक्त MCP टूल्स को कॉल करना।
  - LLM और MCP सर्वर के बीच बातचीत प्रवाह का प्रबंधन।
- `bot.chat()` मेथड प्राकृतिक भाषा प्रतिक्रियाएं लौटाता है जो MCP टूल निष्पादन के परिणाम शामिल कर सकती हैं।
- यह दृष्टिकोण एक सहज उपयोगकर्ता अनुभव प्रदान करता है जहां उपयोगकर्ताओं को अंतर्निहित MCP कार्यान्वयन के बारे में जानने की आवश्यकता नहीं होती है।

पूरा कोड उदाहरण:

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

बहुत अच्छा, आपने इसे कर दिखाया!

## असाइनमेंट

अभ्यास से कोड लें और कुछ और टूल्स के साथ सर्वर बनाएं। फिर अभ्यास में दिए गए तरीके से LLM के साथ एक क्लाइंट बनाएं और इसे विभिन्न प्रॉम्प्ट्स के साथ परीक्षण करें ताकि यह सुनिश्चित हो सके कि आपके सर्वर टूल्स को गतिशील रूप से कॉल किया जा रहा है। इस तरह से क्लाइंट बनाना उपयोगकर्ता को एक शानदार अनुभव प्रदान करता है क्योंकि वे प्रॉम्प्ट्स का उपयोग करने में सक्षम होते हैं, सटीक क्लाइंट कमांड्स के बजाय, और MCP सर्वर को कॉल किए जाने से अनजान रहते हैं।

## समाधान

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## मुख्य बातें

- अपने क्लाइंट में LLM जोड़ना MCP सर्वर्स के साथ बातचीत करने का बेहतर तरीका प्रदान करता है।
- आपको MCP सर्वर प्रतिक्रिया को उस प्रारूप में बदलने की आवश्यकता है जिसे LLM समझ सकता है।

## नमूने

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधन

## आगे क्या है

- अगला: [Visual Studio Code का उपयोग करके सर्वर का उपभोग करना](../04-vscode/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता सुनिश्चित करने का प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियां या अशुद्धियां हो सकती हैं। मूल भाषा में उपलब्ध मूल दस्तावेज़ को प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।