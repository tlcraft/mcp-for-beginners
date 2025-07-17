<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T00:38:49+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ne"
}
-->
# LLM सहित क्लाइन्ट बनाउने

अहिलेसम्म, तपाईंले सर्भर र क्लाइन्ट कसरी बनाउने देख्नुभएको छ। क्लाइन्टले सर्भरलाई स्पष्ट रूपमा कल गरेर यसको उपकरणहरू, स्रोतहरू र प्रॉम्प्टहरू सूचीबद्ध गर्न सक्षम भएको छ। तर, यो धेरै व्यावहारिक तरिका होइन। तपाईंको प्रयोगकर्ता एजेन्टिक युगमा बस्छ र प्रॉम्प्टहरू प्रयोग गरेर LLM सँग संवाद गर्ने अपेक्षा राख्छ। तपाईंको प्रयोगकर्तालाई यो फरक पर्दैन कि तपाईंले आफ्नो क्षमता भण्डारण गर्न MCP प्रयोग गर्नुहुन्छ कि हुँदैन, तर उनीहरू प्राकृतिक भाषामा अन्तरक्रिया गर्न चाहन्छन्। त्यसो भए हामी यो कसरी समाधान गर्ने? समाधान भनेको क्लाइन्टमा LLM थप्नु हो।

## अवलोकन

यस पाठमा हामी क्लाइन्टमा LLM थप्नमा केन्द्रित हुनेछौं र देखाउनेछौं कि यसले तपाईंको प्रयोगकर्तालाई कत्तिको राम्रो अनुभव प्रदान गर्छ।

## सिकाइका उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- LLM सहित क्लाइन्ट बनाउने।
- LLM प्रयोग गरेर MCP सर्भरसँग सहज रूपमा अन्तरक्रिया गर्ने।
- क्लाइन्ट पक्षमा राम्रो अन्तिम प्रयोगकर्ता अनुभव प्रदान गर्ने।

## दृष्टिकोण

हामीले लिनुपर्ने दृष्टिकोण बुझ्न प्रयास गरौं। LLM थप्नु सरल जस्तो लाग्छ, तर के हामी साँच्चै यसो गर्नेछौं?

क्लाइन्टले सर्भरसँग कसरी अन्तरक्रिया गर्नेछ:

1. सर्भरसँग जडान स्थापना गर्ने।

1. क्षमता, प्रॉम्प्ट, स्रोतहरू र उपकरणहरू सूचीबद्ध गर्ने र तिनीहरूको स्कीमा सुरक्षित गर्ने।

1. LLM थप्ने र सुरक्षित क्षमताहरू र तिनीहरूको स्कीमा LLM ले बुझ्ने ढाँचामा पास गर्ने।

1. प्रयोगकर्ताको प्रॉम्प्टलाई LLM मा पास गर्ने र क्लाइन्टले सूचीबद्ध गरेका उपकरणहरूसँग मिलाएर ह्यान्डल गर्ने।

शानदार, अब हामीले उच्च स्तरमा कसरी गर्ने बुझ्यौं, तलको अभ्यासमा यसलाई प्रयास गरौं।

## अभ्यास: LLM सहित क्लाइन्ट बनाउने

यस अभ्यासमा, हामी हाम्रो क्लाइन्टमा LLM थप्न सिक्नेछौं।

## GitHub Personal Access Token प्रयोग गरेर प्रमाणीकरण

GitHub टोकन बनाउनु सरल प्रक्रिया हो। यसरी गर्न सकिन्छ:

- GitHub सेटिङ्समा जानुहोस् – माथिल्लो दायाँ कुनामा आफ्नो प्रोफाइल तस्वीरमा क्लिक गरी सेटिङ्स चयन गर्नुहोस्।
- Developer Settings मा जानुहोस् – तल स्क्रोल गरी Developer Settings मा क्लिक गर्नुहोस्।
- Personal Access Tokens चयन गर्नुहोस् – Personal access tokens मा क्लिक गरी नयाँ टोकन जनरेट गर्नुहोस्।
- आफ्नो टोकन कन्फिगर गर्नुहोस् – सन्दर्भका लागि नोट थप्नुहोस्, समाप्ति मिति सेट गर्नुहोस्, र आवश्यक स्कोपहरू (अनुमतिहरू) चयन गर्नुहोस्।
- टोकन जनरेट गरी तुरुन्तै कपी गर्नुहोस्, किनकि पछि यो फेरि देख्न सकिँदैन।

### -1- सर्भरसँग जडान गर्नुहोस्

पहिले हाम्रो क्लाइन्ट बनाऔं:

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

माथिको कोडमा हामीले:

- आवश्यक लाइब्रेरीहरू आयात गरेका छौं
- दुई सदस्यहरू `client` र `openai` सहितको क्लास बनाएका छौं जसले क्लाइन्ट व्यवस्थापन र LLM सँग अन्तरक्रिया गर्न मद्दत गर्छ।
- हाम्रो LLM इन्स्ट्यान्सलाई GitHub Models प्रयोग गर्न `baseUrl` सेट गरेर कन्फिगर गरेका छौं।

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

माथिको कोडमा हामीले:

- MCP का लागि आवश्यक लाइब्रेरीहरू आयात गरेका छौं
- क्लाइन्ट बनाएका छौं

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

पहिले, तपाईंले आफ्नो `pom.xml` फाइलमा LangChain4j निर्भरता थप्नुपर्नेछ। MCP एकीकरण र GitHub Models समर्थन सक्षम गर्न यी निर्भरता थप्नुहोस्:

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

त्यसपछि आफ्नो Java क्लाइन्ट क्लास बनाउनुहोस्:

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

माथिको कोडमा हामीले:

- **LangChain4j निर्भरता थपेका छौं**: MCP एकीकरण, OpenAI आधिकारिक क्लाइन्ट, र GitHub Models समर्थनका लागि आवश्यक
- **LangChain4j लाइब्रेरीहरू आयात गरेका छौं**: MCP एकीकरण र OpenAI च्याट मोडेल कार्यक्षमताका लागि
- **`ChatLanguageModel` बनाएका छौं**: GitHub Models प्रयोग गर्न तपाईंको GitHub टोकन सहित कन्फिगर गरिएको
- **HTTP ट्रान्सपोर्ट सेटअप गरेका छौं**: Server-Sent Events (SSE) प्रयोग गरी MCP सर्भरसँग जडान गर्न
- **MCP क्लाइन्ट बनाएका छौं**: जसले सर्भरसँग सञ्चार ह्यान्डल गर्छ
- **LangChain4j को बिल्ट-इन MCP समर्थन प्रयोग गरेका छौं**: जसले LLM र MCP सर्भरबीचको एकीकरण सजिलो बनाउँछ

शानदार, अब हाम्रो अर्को कदम सर्भरका क्षमताहरू सूचीबद्ध गर्ने हो।

### -2- सर्भर क्षमताहरू सूचीबद्ध गर्नुहोस्

अब हामी सर्भरसँग जडान गरी यसको क्षमताहरू सोध्नेछौं:

### Typescript

उही क्लासमा तलका मेथडहरू थप्नुहोस्:

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

माथिको कोडमा हामीले:

- सर्भरसँग जडान गर्न `connectToServer` कोड थपेका छौं।
- `run` मेथड बनाएका छौं जुन हाम्रो एप्लिकेसन फ्लो ह्यान्डल गर्छ। अहिलेसम्म यो केवल उपकरणहरू सूचीबद्ध गर्छ तर हामी छिट्टै थप्नेछौं।

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

यहाँ हामीले थपेका छौं:

- स्रोतहरू र उपकरणहरू सूचीबद्ध गरी प्रिन्ट गरेका छौं। उपकरणहरूको लागि हामीले `inputSchema` पनि सूचीबद्ध गरेका छौं जुन पछि प्रयोग हुनेछ।

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

माथिको कोडमा हामीले:

- MCP सर्भरमा उपलब्ध उपकरणहरू सूचीबद्ध गरेका छौं
- प्रत्येक उपकरणको नाम, विवरण र स्कीमा सूचीबद्ध गरेका छौं। स्कीमा हामीले छिट्टै उपकरणहरू कल गर्न प्रयोग गर्नेछौं।

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

माथिको कोडमा हामीले:

- `McpToolProvider` बनाएका छौं जसले स्वचालित रूपमा MCP सर्भरबाट सबै उपकरणहरू पत्ता लगाएर दर्ता गर्छ
- उपकरण प्रदायकले MCP उपकरण स्कीमाहरू र LangChain4j को उपकरण ढाँचाबीच रूपान्तरण आन्तरिक रूपमा ह्यान्डल गर्छ
- यस दृष्टिकोणले म्यानुअल उपकरण सूचीबद्ध र रूपान्तरण प्रक्रियालाई हटाउँछ

### -3- सर्भर क्षमताहरूलाई LLM उपकरणहरूमा रूपान्तरण गर्नुहोस्

सर्भर क्षमताहरू सूचीबद्ध गरेपछि अर्को कदम ती क्षमताहरूलाई LLM ले बुझ्ने ढाँचामा रूपान्तरण गर्नु हो। यसपछि हामी यी क्षमताहरूलाई LLM का लागि उपकरणको रूपमा प्रदान गर्न सक्छौं।

### TypeScript

1. MCP सर्भरबाट आएको प्रतिक्रिया LLM ले प्रयोग गर्न सक्ने उपकरण ढाँचामा रूपान्तरण गर्न तलको कोड थप्नुहोस्:

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

    माथिको कोडले MCP सर्भरबाट आएको प्रतिक्रिया लिएर LLM ले बुझ्ने उपकरण परिभाषा ढाँचामा रूपान्तरण गर्छ।

1. अब `run` मेथड अपडेट गरेर सर्भर क्षमताहरू सूचीबद्ध गरौं:

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

    माथिको कोडमा, हामीले `run` मेथडलाई परिणाममा म्याप गरेर प्रत्येक प्रविष्टिमा `openAiToolAdapter` कल गर्ने गरी अपडेट गरेका छौं।

### Python

1. पहिले, तलको रूपान्तरण गर्ने फंक्शन बनाऔं:

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

    माथिको `convert_to_llm_tools` फंक्शनले MCP उपकरण प्रतिक्रिया लिएर LLM ले बुझ्ने ढाँचामा रूपान्तरण गर्छ।

1. अब हाम्रो क्लाइन्ट कोड अपडेट गरेर यो फंक्शन प्रयोग गरौं:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    यहाँ हामीले MCP उपकरण प्रतिक्रियालाई LLM मा पठाउन मिल्ने रूपमा रूपान्तरण गर्न `convert_to_llm_tool` कल थपेका छौं।

### .NET

1. MCP उपकरण प्रतिक्रियालाई LLM ले बुझ्ने रूपमा रूपान्तरण गर्न कोड थपौं:

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

माथिको कोडमा हामीले:

- `ConvertFrom` नामक फंक्शन बनाएका छौं जसले नाम, विवरण र इनपुट स्कीमा लिन्छ।
- यस्तो कार्यक्षमता परिभाषित गरेका छौं जसले `FunctionDefinition` बनाउँछ र त्यसलाई `ChatCompletionsDefinition` मा पास गर्छ। यो LLM ले बुझ्ने कुरा हो।

1. अब केही अवस्थित कोडलाई यो फंक्शन प्रयोग गर्न अपडेट गरौं:

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

    माथिको कोडमा हामीले:

    - MCP उपकरण प्रतिक्रियालाई LLM उपकरणमा रूपान्तरण गर्ने फंक्शन अपडेट गरेका छौं। थपेको कोड यस प्रकार छ:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        इनपुट स्कीमा उपकरण प्रतिक्रियाको "properties" एट्रिब्युटमा हुन्छ, त्यसैले हामीले त्यसलाई निकाल्नुपर्छ। त्यसपछि `ConvertFrom` लाई उपकरण विवरणसहित कल गर्छौं। अब हामीले मुख्य काम गरिसकेका छौं, प्रयोगकर्ताको प्रॉम्प्ट ह्यान्डल गर्दा यो कल कसरी हुन्छ हेर्नुहोस्।

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

माथिको कोडमा हामीले:

- प्राकृतिक भाषा अन्तरक्रियाका लागि सरल `Bot` इन्टरफेस परिभाषित गरेका छौं
- LangChain4j को `AiServices` प्रयोग गरेर LLM लाई MCP उपकरण प्रदायकसँग स्वचालित रूपमा बाँधेका छौं
- फ्रेमवर्कले उपकरण स्कीमा रूपान्तरण र फंक्शन कल स्वचालित रूपमा ह्यान्डल गर्छ
- यसले म्यानुअल उपकरण रूपान्तरण हटाउँछ - LangChain4j ले MCP उपकरणहरूलाई LLM-अनुकूल ढाँचामा रूपान्तरण गर्ने सबै जटिलता ह्यान्डल गर्छ

शानदार, अब हामी प्रयोगकर्ताको अनुरोध ह्यान्डल गर्न तयार छौं, त्यसो भए अगाडि बढौं।

### -4- प्रयोगकर्ताको प्रॉम्प्ट अनुरोध ह्यान्डल गर्नुहोस्

यस भागमा, हामी प्रयोगकर्ताको अनुरोध ह्यान्डल गर्नेछौं।

### TypeScript

1. LLM कल गर्न प्रयोग हुने मेथड थपौं:

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

    माथिको कोडमा हामीले:

    - `callTools` नामक मेथड थपेका छौं।
    - मेथडले LLM प्रतिक्रिया लिएर कुन उपकरणहरू कल भएका छन् जाँच गर्छ:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - LLM ले कल गर्नुपर्ने संकेत गरेमा उपकरण कल गर्छ:

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

1. `run` मेथड अपडेट गरेर LLM कल र `callTools` समावेश गरौं:

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

शानदार, पूर्ण कोड यसप्रकार छ:

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

1. LLM कल गर्न आवश्यक आयातहरू थपौं:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. LLM कल गर्ने फंक्शन थपौं:

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

    माथिको कोडमा हामीले:

    - MCP सर्भरमा भेटिएका र रूपान्तरण गरिएका फंक्शनहरू LLM लाई पास गरेका छौं।
    - त्यसपछि ती फंक्शनहरूसँग LLM कल गरेका छौं।
    - परिणाम जाँचेर कुन फंक्शनहरू कल गर्नुपर्ने हो हेरेका छौं।
    - अन्तमा कल गर्नुपर्ने फंक्शनहरूको सूची पास गरेका छौं।

1. अन्तिम चरण, मुख्य कोड अपडेट गरौं:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    माथिको कोडमा हामीले:

    - LLM ले सुझाव दिएको फंक्शन प्रयोग गरी MCP उपकरण कल गरेका छौं।
    - उपकरण कलको परिणाम MCP सर्भरमा प्रिन्ट गरेका छौं।

### .NET

1. LLM प्रॉम्प्ट अनुरोध गर्ने कोड देखाऔं:

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

    माथिको कोडमा हामीले:

    - MCP सर्भरबाट उपकरणहरू ल्याएका छौं, `var tools = await GetMcpTools()`।
    - प्रयोगकर्ताको प्रॉम्प्ट `userMessage` परिभाषित गरेका छौं।
    - मोडेल र उपकरणहरू निर्दिष्ट गर्दै विकल्प वस्तु बनाएका छौं।
    - LLM तर्फ अनुरोध पठाएका छौं।

1. अन्तिम चरण, LLM ले फंक्शन कल गर्नुपर्ने सोच्छ कि छैन हेर्नुहोस्:

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

    माथिको कोडमा हामीले:

    - फंक्शन कलहरूको सूचीमा लूप गरेका छौं।
    - प्रत्येक उपकरण कलका लागि नाम र आर्गुमेन्ट पार्स गरी MCP क्लाइन्ट प्रयोग गरेर उपकरण कल गरेका छौं। अन्तमा परिणाम प्रिन्ट गरेका छौं।

पूर्ण कोड यसप्रकार छ:

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

माथिको कोडमा हामीले:

- सरल प्राकृतिक भाषा प्रॉम्प्टहरू प्रयोग गरी MCP सर्भर उपकरणहरूसँग अन्तरक्रिया गरेका छौं
- LangChain4j फ्रेमवर्कले स्वचालित रूपमा ह्यान्डल गर्छ:
  - आवश्यक पर्दा प्रयोगकर्ता प्रॉम्प्टलाई उपकरण कलमा रूपान्तरण गर्ने
  - LLM को निर्णय अनुसार उपयुक्त MCP उपकरणहरू कल गर्ने
  - LLM र MCP सर्भरबीच संवाद प्रवाह व्यवस्थापन गर्ने
- `bot.chat()` मेथडले प्राकृतिक भाषा प्रतिक्रिया फर्काउँछ जसमा MCP उपकरण निष्पादनका परिणामहरू समावेश हुन सक्छन्
- यसले प्रयोगकर्तालाई सहज अनुभव प्रदान गर्छ जहाँ उनीहरूले MCP को भित्री कार्यान्वयनबारे जान्न आवश्यक पर्दैन

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

शानदार, तपाईंले गर्नुभयो!

## असाइनमेन्ट

अभ्यासबाट कोड लिएर सर्भरमा केही थप उपकरणहरू बनाउनुहोस्। त्यसपछि अभ्यासमा जस्तै LLM सहित क्लाइन्ट बनाउनुहोस् र विभिन्न प्रॉम्प्टहरूसँग परीक्षण गर्नुहोस् ताकि तपाईंका सबै सर्भर उपकरणहरू गतिशील रूपमा कल हुने सुनिश्चित होस्। यसरी क्लाइन्ट बनाउँदा अन्तिम प्रयोगकर्ताले उत्कृष्ट अनुभव पाउँछन् किनकि उनीहरूले ठ्याक्कै क्लाइन्ट कमाण्डहरू होइन, प्रॉम्प्टहरू प्रयोग गरेर काम गर्न सक्छन् र कुनै MCP सर्भर कल भइरहेको छ भन्ने थाहा नपाउनेछन्।

## समाधान

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## मुख्य बुँदाहरू

- क्लाइन्टमा LLM थप्दा प्रयोगकर्ताहरूलाई MCP सर्भरसँग अन्तरक्रिया गर्ने राम्रो तरिका मिल्छ।
- MCP सर्भरको प्रतिक्रिया LLM ले बुझ्ने ढाँचामा रूपान्तरण गर्न आवश्यक हुन्छ।

## नमूनाहरू

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## थप स्रोतहरू

## के छ अर्को

- अर्को: [Visual Studio Code प्रयोग गरी सर्भर उपभोग गर्ने](../04-vscode/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं भने पनि, कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।