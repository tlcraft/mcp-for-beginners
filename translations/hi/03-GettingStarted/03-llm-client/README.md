<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T18:05:45+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hi"
}
-->
# LLM के साथ क्लाइंट बनाना

अब तक, आपने देखा कि कैसे एक सर्वर और क्लाइंट बनाया जाता है। क्लाइंट स्पष्ट रूप से सर्वर को कॉल कर सकता है ताकि उसके टूल्स, संसाधन और प्रॉम्प्ट्स की सूची प्राप्त की जा सके। हालांकि, यह तरीका बहुत व्यावहारिक नहीं है। आपका उपयोगकर्ता एजेंटिक युग में रहता है और उम्मीद करता है कि वह प्रॉम्प्ट्स का उपयोग करके और एक LLM के साथ संवाद करके काम कर सके। आपके उपयोगकर्ता के लिए यह मायने नहीं रखता कि आप अपनी क्षमताओं को स्टोर करने के लिए MCP का उपयोग करते हैं या नहीं, लेकिन वे प्राकृतिक भाषा का उपयोग करके इंटरैक्ट करने की उम्मीद करते हैं। तो हम इसे कैसे हल करें? समाधान है क्लाइंट में एक LLM जोड़ना।

## अवलोकन

इस पाठ में हम अपने क्लाइंट में एक LLM जोड़ने पर ध्यान केंद्रित करेंगे और दिखाएंगे कि यह आपके उपयोगकर्ता के लिए कितना बेहतर अनुभव प्रदान करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- एक LLM के साथ क्लाइंट बनाना।
- एक MCP सर्वर के साथ LLM का उपयोग करके सहजता से इंटरैक्ट करना।
- क्लाइंट साइड पर बेहतर अंतिम उपयोगकर्ता अनुभव प्रदान करना।

## दृष्टिकोण

आइए समझते हैं कि हमें किस दृष्टिकोण को अपनाना होगा। एक LLM जोड़ना सरल लगता है, लेकिन क्या हम वास्तव में ऐसा करेंगे?

यहाँ बताया गया है कि क्लाइंट सर्वर के साथ कैसे इंटरैक्ट करेगा:

1. सर्वर के साथ कनेक्शन स्थापित करें।

1. क्षमताओं, प्रॉम्प्ट्स, संसाधनों और टूल्स की सूची बनाएं, और उनके स्कीमा को सहेजें।

1. एक LLM जोड़ें और सहेजी गई क्षमताओं और उनके स्कीमा को उस फॉर्मेट में पास करें जिसे LLM समझता है।

1. उपयोगकर्ता के प्रॉम्प्ट को LLM को पास करें, साथ ही क्लाइंट द्वारा सूचीबद्ध टूल्स भी भेजें।

बहुत बढ़िया, अब जब हम उच्च स्तर पर समझ गए हैं कि इसे कैसे किया जा सकता है, तो नीचे दिए गए अभ्यास में इसे आजमाते हैं।

## अभ्यास: LLM के साथ क्लाइंट बनाना

इस अभ्यास में, हम अपने क्लाइंट में एक LLM जोड़ना सीखेंगे।

## GitHub Personal Access Token का उपयोग करके प्रमाणीकरण

GitHub टोकन बनाना एक सरल प्रक्रिया है। इसे आप इस तरह कर सकते हैं:

- GitHub सेटिंग्स पर जाएं – ऊपर दाईं ओर अपनी प्रोफ़ाइल तस्वीर पर क्लिक करें और Settings चुनें।
- Developer Settings पर जाएं – नीचे स्क्रॉल करें और Developer Settings पर क्लिक करें।
- Personal Access Tokens चुनें – Personal access tokens पर क्लिक करें और फिर Generate new token चुनें।
- अपने टोकन को कॉन्फ़िगर करें – संदर्भ के लिए एक नोट जोड़ें, समाप्ति तिथि सेट करें, और आवश्यक स्कोप्स (अनुमतियाँ) चुनें।
- टोकन जनरेट करें और कॉपी करें – Generate token पर क्लिक करें, और इसे तुरंत कॉपी कर लें क्योंकि आप इसे बाद में नहीं देख पाएंगे।

### -1- सर्वर से कनेक्ट करें

सबसे पहले अपना क्लाइंट बनाते हैं:

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

पिछले कोड में हमने:

- आवश्यक लाइब्रेरीज़ को इम्पोर्ट किया
- एक क्लास बनाया जिसमें दो सदस्य हैं, `client` और `openai`, जो हमें क्लाइंट को मैनेज करने और LLM के साथ इंटरैक्ट करने में मदद करेंगे।
- अपने LLM इंस्टेंस को GitHub Models का उपयोग करने के लिए कॉन्फ़िगर किया, `baseUrl` को inference API की ओर सेट करके।

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

पिछले कोड में हमने:

- MCP के लिए आवश्यक लाइब्रेरीज़ को इम्पोर्ट किया
- एक क्लाइंट बनाया

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

सबसे पहले, आपको अपने `pom.xml` फ़ाइल में LangChain4j डिपेंडेंसीज़ जोड़नी होंगी। MCP इंटीग्रेशन और GitHub Models सपोर्ट सक्षम करने के लिए ये डिपेंडेंसीज़ जोड़ें:

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

फिर अपना Java क्लाइंट क्लास बनाएं:

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

पिछले कोड में हमने:

- **LangChain4j डिपेंडेंसीज़ जोड़ीं**: MCP इंटीग्रेशन, OpenAI आधिकारिक क्लाइंट, और GitHub Models सपोर्ट के लिए आवश्यक
- **LangChain4j लाइब्रेरीज़ इम्पोर्ट कीं**: MCP इंटीग्रेशन और OpenAI चैट मॉडल कार्यक्षमता के लिए
- **`ChatLanguageModel` बनाया**: GitHub Models का उपयोग करने के लिए आपके GitHub टोकन के साथ कॉन्फ़िगर किया गया
- **HTTP ट्रांसपोर्ट सेटअप किया**: Server-Sent Events (SSE) का उपयोग करके MCP सर्वर से कनेक्ट करने के लिए
- **MCP क्लाइंट बनाया**: जो सर्वर के साथ संचार को संभालेगा
- **LangChain4j के बिल्ट-इन MCP सपोर्ट का उपयोग किया**: जो LLMs और MCP सर्वर्स के बीच इंटीग्रेशन को सरल बनाता है

बहुत बढ़िया, अब अगले चरण के लिए, चलिए सर्वर की क्षमताओं की सूची बनाते हैं।

### -2- सर्वर क्षमताओं की सूची बनाएं

अब हम सर्वर से कनेक्ट करेंगे और उसकी क्षमताओं के बारे में पूछेंगे:

### TypeScript

उसी क्लास में, निम्नलिखित मेथड्स जोड़ें:

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

पिछले कोड में हमने:

- सर्वर से कनेक्ट करने के लिए कोड जोड़ा, `connectToServer`।
- एक `run` मेथड बनाया जो हमारे ऐप के फ्लो को संभालता है। अभी तक यह केवल टूल्स की सूची बनाता है, लेकिन हम इसमें जल्द ही और जोड़ेंगे।

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

यहाँ हमने जोड़ा:

- संसाधनों और टूल्स की सूची बनाई और उन्हें प्रिंट किया। टूल्स के लिए हमने `inputSchema` भी सूचीबद्ध किया जिसे हम बाद में उपयोग करेंगे।

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

पिछले कोड में हमने:

- MCP सर्वर पर उपलब्ध टूल्स की सूची बनाई
- प्रत्येक टूल के लिए नाम, विवरण और उसका स्कीमा सूचीबद्ध किया। बाद में हम इसे टूल कॉल करने के लिए उपयोग करेंगे।

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

पिछले कोड में हमने:

- एक `McpToolProvider` बनाया जो स्वचालित रूप से MCP सर्वर से सभी टूल्स को खोजता और रजिस्टर करता है
- टूल प्रोवाइडर MCP टूल स्कीमाओं और LangChain4j के टूल फॉर्मेट के बीच रूपांतरण को आंतरिक रूप से संभालता है
- यह दृष्टिकोण मैनुअल टूल लिस्टिंग और रूपांतरण प्रक्रिया को abstract करता है

### -3- सर्वर क्षमताओं को LLM टूल्स में कन्वर्ट करें

सर्वर क्षमताओं की सूची बनाने के बाद अगला कदम उन्हें उस फॉर्मेट में कन्वर्ट करना है जिसे LLM समझ सके। एक बार ऐसा हो जाने पर, हम इन क्षमताओं को अपने LLM के लिए टूल्स के रूप में प्रदान कर सकते हैं।

### TypeScript

1. MCP सर्वर से प्रतिक्रिया को LLM के उपयोग के लिए टूल फॉर्मेट में कन्वर्ट करने के लिए निम्नलिखित कोड जोड़ें:

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

    ऊपर दिया गया कोड MCP सर्वर से प्रतिक्रिया लेकर उसे LLM के समझने योग्य टूल डिफिनिशन फॉर्मेट में बदल देता है।

1. अब `run` मेथड को अपडेट करें ताकि सर्वर क्षमताओं की सूची बनाई जा सके:

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

    पिछले कोड में, हमने `run` मेथड को अपडेट किया है ताकि वह परिणाम के माध्यम से मैप करे और प्रत्येक एंट्री के लिए `openAiToolAdapter` को कॉल करे।

### Python

1. सबसे पहले, निम्न कन्वर्टर फ़ंक्शन बनाएं:

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

    ऊपर दिए गए `convert_to_llm_tools` फ़ंक्शन में हम MCP टूल प्रतिक्रिया को LLM के समझने योग्य फॉर्मेट में कन्वर्ट करते हैं।

1. फिर, अपने क्लाइंट कोड को इस फ़ंक्शन का उपयोग करने के लिए अपडेट करें:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    यहाँ, हम MCP टूल प्रतिक्रिया को LLM को फीड करने योग्य फॉर्मेट में कन्वर्ट करने के लिए `convert_to_llm_tool` कॉल जोड़ रहे हैं।

### .NET

1. MCP टूल प्रतिक्रिया को LLM के समझने योग्य फॉर्मेट में कन्वर्ट करने के लिए कोड जोड़ें:

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

पिछले कोड में हमने:

- `ConvertFrom` नामक एक फ़ंक्शन बनाया जो नाम, विवरण और इनपुट स्कीमा लेता है।
- एक फ़ंक्शनलिटी परिभाषित की जो एक FunctionDefinition बनाता है जिसे ChatCompletionsDefinition को पास किया जाता है। यह वह फॉर्मेट है जिसे LLM समझता है।

1. अब देखते हैं कि हम इस फ़ंक्शन का उपयोग करने के लिए मौजूदा कोड को कैसे अपडेट कर सकते हैं:

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

    पिछले कोड में हमने:

    - MCP टूल प्रतिक्रिया को LLM टूल में कन्वर्ट करने के लिए फ़ंक्शन को अपडेट किया। हमने जो कोड जोड़ा है उसे हाइलाइट करते हैं:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        इनपुट स्कीमा टूल प्रतिक्रिया का हिस्सा है लेकिन "properties" एट्रिब्यूट में है, इसलिए हमें इसे एक्सट्रैक्ट करना होगा। इसके अलावा, अब हम टूल विवरण के साथ `ConvertFrom` को कॉल करते हैं। अब जब हमने यह मुख्य काम कर लिया है, तो देखते हैं कि उपयोगकर्ता प्रॉम्प्ट को हैंडल करते समय यह कॉल कैसे काम करता है।

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

पिछले कोड में हमने:

- प्राकृतिक भाषा इंटरैक्शन के लिए एक सरल `Bot` इंटरफ़ेस परिभाषित किया
- LangChain4j के `AiServices` का उपयोग किया ताकि LLM को MCP टूल प्रोवाइडर के साथ स्वचालित रूप से बाइंड किया जा सके
- फ्रेमवर्क स्वचालित रूप से टूल स्कीमा कन्वर्ज़न और फ़ंक्शन कॉलिंग को हैंडल करता है
- यह दृष्टिकोण मैनुअल टूल कन्वर्ज़न को समाप्त करता है - LangChain4j MCP टूल्स को LLM-समर्थित फॉर्मेट में कन्वर्ट करने की सारी जटिलता संभालता है

बहुत बढ़िया, अब हम उपयोगकर्ता अनुरोधों को हैंडल करने के लिए तैयार हैं, तो इसे अगला टारगेट बनाते हैं।

### -4- उपयोगकर्ता प्रॉम्प्ट अनुरोध को हैंडल करें

इस कोड भाग में, हम उपयोगकर्ता अनुरोधों को हैंडल करेंगे।

### TypeScript

1. एक मेथड जोड़ें जिसका उपयोग हम अपने LLM को कॉल करने के लिए करेंगे:

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

    पिछले कोड में हमने:

    - `callTools` नामक एक मेथड जोड़ा।
    - यह मेथड LLM प्रतिक्रिया लेता है और जांचता है कि कौन से टूल्स कॉल किए गए हैं, यदि कोई हैं:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - यदि LLM संकेत देता है कि किसी टूल को कॉल करना चाहिए, तो उसे कॉल करता है:

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

बहुत बढ़िया, पूरा कोड देखें:

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

1. LLM को कॉल करने के लिए आवश्यक कुछ इम्पोर्ट्स जोड़ें:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. फिर, वह फ़ंक्शन जोड़ें जो LLM को कॉल करेगा:

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

    पिछले कोड में हमने:

    - MCP सर्वर पर पाए गए और कन्वर्ट किए गए फ़ंक्शंस को LLM को पास किया।
    - फिर LLM को उन फ़ंक्शंस के साथ कॉल किया।
    - परिणाम की जांच की कि हमें कौन से फ़ंक्शंस कॉल करने चाहिए, यदि कोई हों।
    - अंत में, कॉल करने के लिए फ़ंक्शंस की एक सूची पास की।

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

    यहाँ, हमने:

    - LLM के प्रॉम्प्ट के आधार पर MCP टूल को `call_tool` के माध्यम से कॉल किया।
    - MCP सर्वर पर टूल कॉल का परिणाम प्रिंट किया।

### .NET

1. LLM प्रॉम्प्ट अनुरोध के लिए कुछ कोड दिखाते हैं:

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

    पिछले कोड में हमने:

    - MCP सर्वर से टूल्स प्राप्त किए, `var tools = await GetMcpTools()`।
    - एक उपयोगकर्ता प्रॉम्प्ट `userMessage` परिभाषित किया।
    - मॉडल और टूल्स निर्दिष्ट करते हुए एक विकल्प ऑब्जेक्ट बनाया।
    - LLM के लिए अनुरोध किया।

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

    पिछले कोड में हमने:

    - फ़ंक्शन कॉल की सूची के माध्यम से लूप किया।
    - प्रत्येक टूल कॉल के लिए नाम और आर्गुमेंट्स पार्स किए और MCP क्लाइंट का उपयोग करके MCP सर्वर पर टूल को कॉल किया। अंत में परिणाम प्रिंट किया।

पूरा कोड देखें:

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

पिछले कोड में हमने:

- सरल प्राकृतिक भाषा प्रॉम्प्ट्स का उपयोग करके MCP सर्वर टूल्स के साथ इंटरैक्ट किया
- LangChain4j फ्रेमवर्क स्वचालित रूप से संभालता है:
  - जब आवश्यक हो तो उपयोगकर्ता प्रॉम्प्ट्स को टूल कॉल्स में कन्वर्ट करना
  - LLM के निर्णय के आधार पर उपयुक्त MCP टूल्स को कॉल करना
  - LLM और MCP सर्वर के बीच बातचीत के प्रवाह को प्रबंधित करना
- `bot.chat()` मेथड प्राकृतिक भाषा में प्रतिक्रियाएं लौटाता है जिनमें MCP टूल निष्पादन के परिणाम शामिल हो सकते हैं
- यह दृष्टिकोण एक सहज उपयोगकर्ता अनुभव प्रदान करता है जहाँ उपयोगकर्ताओं को अंतर्निहित MCP इम्प्लीमेंटेशन के बारे में जानने की जरूरत नहीं होती

पूर्ण कोड उदाहरण:

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

बहुत बढ़िया, आपने कर दिखाया!

## असाइनमेंट

अभ्यास से कोड लें और सर्वर में कुछ और टूल्स जोड़ें। फिर एक LLM के साथ क्लाइंट बनाएं, जैसे अभ्यास में किया गया है, और विभिन्न प्रॉम्प्ट्स के साथ इसे टेस्ट करें ताकि यह सुनिश्चित हो सके कि आपके सभी सर्वर टूल्स डायनामिक रूप से कॉल हो रहे हैं। इस तरह क्लाइंट बनाने का मतलब है कि अंतिम उपयोगकर्ता को एक शानदार अनुभव मिलेगा क्योंकि वे सटीक क्लाइंट कमांड्स के बजाय प्रॉम्प्ट्स का उपयोग कर पाएंगे और MCP सर्वर के कॉल होने से अनजान रहेंगे।

## समाधान

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## मुख्य बातें

- अपने क्लाइंट में एक LLM जोड़ने से उपयोगकर्ताओं के लिए MCP सर्वर्स के साथ इंटरैक्शन का बेहतर तरीका मिलता है।
- आपको MCP सर्वर की प्रतिक्रिया को उस फॉर्मेट में कन्वर्ट करना होगा जिसे LLM समझ सके।

## नमूने

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधन

## आगे क्या है

- अगला: [Visual Studio Code का उपयोग करके सर्वर का उपभोग](../04-vscode/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।