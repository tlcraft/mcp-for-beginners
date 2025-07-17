<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T18:13:34+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "mr"
}
-->
# LLM सह क्लायंट तयार करणे

आत्तापर्यंत, तुम्ही पाहिले आहे की सर्व्हर आणि क्लायंट कसे तयार करायचे. क्लायंटने स्पष्टपणे सर्व्हरला कॉल करून त्याचे टूल्स, संसाधने आणि प्रॉम्प्ट्स यादीबद्ध केली आहे. मात्र, हा दृष्टिकोन फारसा व्यवहार्य नाही. तुमचा वापरकर्ता एजंटिक युगात राहतो आणि प्रॉम्प्ट्स वापरून LLM शी संवाद साधण्याची अपेक्षा करतो. तुमच्या वापरकर्त्यास याची पर्वा नाही की तुम्ही तुमच्या क्षमता साठवण्यासाठी MCP वापरता की नाही, पण ते नैसर्गिक भाषेत संवाद साधण्याची अपेक्षा करतात. तर आपण हे कसे सोडवू? यासाठी क्लायंटमध्ये LLM जोडणे हा उपाय आहे.

## आढावा

या धड्यात आपण क्लायंटमध्ये LLM कसे जोडायचे यावर लक्ष केंद्रित करू आणि हे वापरकर्त्यास कसे चांगले अनुभव देते हे दाखवू.

## शिकण्याचे उद्दिष्ट

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- LLM सह क्लायंट तयार करणे.
- LLM वापरून MCP सर्व्हरशी सहज संवाद साधणे.
- क्लायंट बाजूने वापरकर्त्यास चांगला अनुभव देणे.

## दृष्टिकोन

आपण कोणता दृष्टिकोन घेणार आहोत ते समजून घेऊया. LLM जोडणे सोपे वाटते, पण आपण प्रत्यक्षात हे कसे करणार?

क्लायंट सर्व्हरशी कसे संवाद साधेल ते खालीलप्रमाणे:

1. सर्व्हरशी कनेक्शन स्थापित करा.

1. क्षमता, प्रॉम्प्ट्स, संसाधने आणि टूल्स यादीबद्ध करा आणि त्यांचा स्कीमा जतन करा.

1. LLM जोडा आणि जतन केलेल्या क्षमता व त्यांचा स्कीमा LLM समजेल अशा स्वरूपात द्या.

1. वापरकर्त्याचा प्रॉम्प्ट LLM कडे पाठवा, क्लायंटने यादीबद्ध केलेल्या टूल्ससह.

छान, आता आपण उच्चस्तरीय पातळीवर हे कसे करायचे ते समजले, तर खालील सरावात हे करून पाहूया.

## सराव: LLM सह क्लायंट तयार करणे

या सरावात आपण क्लायंटमध्ये LLM कसे जोडायचे ते शिकू.

## GitHub Personal Access Token वापरून प्रमाणीकरण

GitHub टोकन तयार करणे सोपे आहे. हे कसे करायचे:

- GitHub सेटिंग्जवर जा – वरच्या उजव्या कोपऱ्यात तुमच्या प्रोफाइल चित्रावर क्लिक करा आणि Settings निवडा.
- Developer Settings वर जा – खाली स्क्रोल करा आणि Developer Settings वर क्लिक करा.
- Personal Access Tokens निवडा – Personal access tokens वर क्लिक करा आणि नंतर Generate new token निवडा.
- तुमचा टोकन कॉन्फिगर करा – संदर्भासाठी नोट जोडा, समाप्ती तारीख सेट करा आणि आवश्यक परवानग्या निवडा.
- टोकन तयार करा आणि कॉपी करा – Generate token वर क्लिक करा आणि लगेच कॉपी करा, कारण नंतर ते पुन्हा दिसणार नाही.

### -1- सर्व्हरशी कनेक्ट करा

आता आपला क्लायंट तयार करूया:

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

वरील कोडमध्ये आपण:

- आवश्यक लायब्ररी आयात केल्या आहेत
- `client` आणि `openai` या दोन सदस्यांसह एक क्लास तयार केला आहे, जे क्लायंट व्यवस्थापित करण्यासाठी आणि LLM शी संवाद साधण्यासाठी मदत करतील.
- GitHub Models वापरण्यासाठी `baseUrl` सेट करून LLM इंस्टन्स कॉन्फिगर केला आहे.

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

वरील कोडमध्ये आपण:

- MCP साठी आवश्यक लायब्ररी आयात केल्या आहेत
- क्लायंट तयार केला आहे

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

सर्वप्रथम, तुमच्या `pom.xml` फाईलमध्ये LangChain4j डिपेंडन्सीज जोडा. MCP इंटिग्रेशन आणि GitHub Models सपोर्टसाठी खालील डिपेंडन्सीज जोडा:

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

नंतर तुमचा Java क्लायंट क्लास तयार करा:

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

वरील कोडमध्ये आपण:

- **LangChain4j डिपेंडन्सीज जोडल्या**: MCP इंटिग्रेशन, OpenAI अधिकृत क्लायंट आणि GitHub Models सपोर्टसाठी आवश्यक
- **LangChain4j लायब्ररी आयात केल्या**: MCP इंटिग्रेशन आणि OpenAI चॅट मॉडेलसाठी
- **`ChatLanguageModel` तयार केला**: GitHub Models वापरण्यासाठी तुमचा GitHub टोकन वापरून कॉन्फिगर केला
- **HTTP ट्रान्सपोर्ट सेट केला**: Server-Sent Events (SSE) वापरून MCP सर्व्हरशी कनेक्ट करण्यासाठी
- **MCP क्लायंट तयार केला**: जो सर्व्हरशी संवाद साधेल
- **LangChain4j चा अंगभूत MCP सपोर्ट वापरला**: ज्यामुळे LLM आणि MCP सर्व्हरमधील इंटिग्रेशन सुलभ होते

छान, पुढील टप्प्यासाठी, आता सर्व्हरवरील क्षमता यादीबद्ध करूया.

### -2- सर्व्हर क्षमता यादीबद्ध करा

आता आपण सर्व्हरशी कनेक्ट होऊन त्याच्या क्षमता मागणार आहोत:

### TypeScript

त्याच क्लासमध्ये खालील मेथड्स जोडा:

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

वरील कोडमध्ये आपण:

- सर्व्हरशी कनेक्ट होण्यासाठी `connectToServer` कोड जोडला आहे.
- `run` मेथड तयार केली आहे जी आमच्या अॅपच्या फ्लोची जबाबदारी सांभाळते. आतापर्यंत ती फक्त टूल्स यादीबद्ध करते, पण लवकरच त्यात अधिक जोडणार आहोत.

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

आम्ही काय जोडले:

- संसाधने आणि टूल्स यादीबद्ध केली आणि त्यांना प्रिंट केले. टूल्ससाठी `inputSchema` देखील यादीबद्ध केली जी नंतर वापरली जाईल.

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

वरील कोडमध्ये आपण:

- MCP सर्व्हरवरील उपलब्ध टूल्स यादीबद्ध केली
- प्रत्येक टूलसाठी नाव, वर्णन आणि त्याचा स्कीमा यादीबद्ध केला. हा स्कीमा आपण लवकरच टूल कॉल करण्यासाठी वापरणार आहोत.

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

वरील कोडमध्ये आपण:

- `McpToolProvider` तयार केला जो MCP सर्व्हरमधील सर्व टूल्स आपोआप शोधून नोंदणी करतो
- टूल प्रोव्हायडर MCP टूल स्कीम्स आणि LangChain4j च्या टूल फॉरमॅटमधील रूपांतरण अंतर्गत हाताळतो
- हा दृष्टिकोन मॅन्युअल टूल यादीबद्ध करणे आणि रूपांतरण प्रक्रिया लपवतो

### -3- सर्व्हर क्षमता LLM टूल्समध्ये रूपांतरित करा

सर्व्हर क्षमता यादीबद्ध केल्यानंतर पुढचा टप्पा म्हणजे त्यांना LLM समजेल अशा स्वरूपात रूपांतरित करणे. एकदा हे केल्यावर, आपण या क्षमतांना LLM साठी टूल्स म्हणून पुरवू शकतो.

### TypeScript

1. MCP सर्व्हरच्या प्रतिसादाला LLM वापरू शकणाऱ्या टूल स्वरूपात रूपांतरित करण्यासाठी खालील कोड जोडा:

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

    वरील कोड MCP सर्व्हरचा प्रतिसाद घेऊन तो LLM समजेल अशा टूल डिफिनिशन स्वरूपात रूपांतरित करतो.

1. नंतर `run` मेथड अपडेट करा जेणेकरून सर्व्हर क्षमता यादीबद्ध करता येतील:

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

    वरील कोडमध्ये, `run` मेथड अपडेट केली आहे ज्यात परिणामावर मॅपिंग करून प्रत्येक एन्ट्रीसाठी `openAiToolAdapter` कॉल केला जातो.

### Python

1. प्रथम, खालील कन्व्हर्टर फंक्शन तयार करूया:

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

    `convert_to_llm_tools` फंक्शनमध्ये MCP टूल प्रतिसाद घेतला जातो आणि LLM समजेल अशा स्वरूपात रूपांतरित केला जातो.

1. नंतर, क्लायंट कोड अपडेट करा जेणेकरून हा फंक्शन वापरता येईल:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    येथे, आपण `convert_to_llm_tool` कॉल जोडत आहोत जेणेकरून MCP टूल प्रतिसाद LLM ला दिला जाऊ शकेल.

### .NET

1. MCP टूल प्रतिसाद LLM समजेल अशा स्वरूपात रूपांतरित करण्यासाठी कोड जोडा:

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

वरील कोडमध्ये आपण:

- `ConvertFrom` नावाचा फंक्शन तयार केला जो नाव, वर्णन आणि इनपुट स्कीमा घेतो.
- एक फंक्शन डिफिनिशन तयार करण्याची कार्यक्षमता दिली जी ChatCompletionsDefinition कडे पाठवली जाते. हे LLM समजेल अशा स्वरूपात आहे.

1. आता काही विद्यमान कोड कसा अपडेट करायचा ते पाहूया:

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

    वरील कोडमध्ये आपण:

    - MCP टूल प्रतिसाद LLM टूलमध्ये रूपांतरित करण्यासाठी फंक्शन अपडेट केली आहे. खालील कोड विशेषतः जोडला आहे:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        इनपुट स्कीमा टूल प्रतिसादाचा भाग आहे पण "properties" अ‍ॅट्रिब्यूटमध्ये आहे, त्यामुळे ते एक्स्ट्रॅक्ट करणे आवश्यक आहे. त्यानंतर `ConvertFrom` कॉल केला जातो टूल तपशीलांसह. आता आपण मुख्य काम केले आहे, पुढे वापरकर्त्याचा प्रॉम्प्ट कसा हाताळायचा ते पाहूया.

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

वरील कोडमध्ये आपण:

- नैसर्गिक भाषेतील संवादासाठी सोपा `Bot` इंटरफेस डिफाइन केला आहे
- LangChain4j चा `AiServices` वापरून LLM आणि MCP टूल प्रोव्हायडर आपोआप बाइंड केला आहे
- फ्रेमवर्क टूल स्कीमा रूपांतरण आणि फंक्शन कॉलिंग मागे हाताळतो
- मॅन्युअल टूल रूपांतरणाची गरज नाही - LangChain4j सर्व क्लिष्टता हाताळतो

छान, आता आपण वापरकर्त्याच्या विनंत्या हाताळण्यासाठी तयार आहोत, तर पुढे जाऊया.

### -4- वापरकर्त्याचा प्रॉम्प्ट विनंती हाताळा

या कोड भागात आपण वापरकर्त्याच्या विनंत्या हाताळणार आहोत.

### TypeScript

1. LLM कॉल करण्यासाठी खालील मेथड जोडा:

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

    वरील कोडमध्ये आपण:

    - `callTools` नावाचा मेथड जोडला आहे.
    - हा मेथड LLM प्रतिसाद घेतो आणि कोणते टूल्स कॉल झाले आहेत ते तपासतो:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - LLM सूचित केल्यास टूल कॉल करतो:

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

1. `run` मेथड अपडेट करा जेणेकरून LLM कॉल्स आणि `callTools` कॉल्स समाविष्ट होतील:

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

चांगले, पूर्ण कोड खालीलप्रमाणे आहे:

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

1. LLM कॉल करण्यासाठी आवश्यक काही आयात जोडा:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. नंतर, LLM कॉल करणारा फंक्शन जोडा:

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

    वरील कोडमध्ये आपण:

    - MCP सर्व्हरवर सापडलेल्या आणि रूपांतरित केलेल्या फंक्शन्स LLM कडे दिल्या.
    - नंतर LLM कॉल केला.
    - निकाल तपासला की कोणते फंक्शन्स कॉल करायचे आहेत.
    - शेवटी कॉल करायच्या फंक्शन्सची यादी दिली.

1. शेवटचा टप्पा, मुख्य कोड अपडेट करा:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    वरील कोडमध्ये आपण:

    - LLM च्या सूचनेनुसार `call_tool` वापरून MCP टूल कॉल केला.
    - टूल कॉलचा निकाल MCP सर्व्हरवर प्रिंट केला.

### .NET

1. LLM प्रॉम्प्ट विनंतीसाठी कोड दाखवा:

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

    वरील कोडमध्ये आपण:

    - MCP सर्व्हरवरून टूल्स मिळवले, `var tools = await GetMcpTools()`.
    - वापरकर्त्याचा प्रॉम्प्ट `userMessage` तयार केला.
    - मॉडेल आणि टूल्ससह पर्याय ऑब्जेक्ट तयार केला.
    - LLM कडे विनंती केली.

1. शेवटचा टप्पा, LLM ला फंक्शन कॉल करायचे आहे का ते तपासा:

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

    वरील कोडमध्ये आपण:

    - फंक्शन कॉल्सच्या यादीतून लूप केला.
    - प्रत्येक टूल कॉलसाठी नाव आणि आर्ग्युमेंट्स पार्स करून MCP क्लायंट वापरून टूल कॉल केला. निकाल प्रिंट केला.

पूर्ण कोड खालीलप्रमाणे आहे:

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

वरील कोडमध्ये आपण:

- सोप्या नैसर्गिक भाषा प्रॉम्प्ट्स वापरून MCP सर्व्हर टूल्सशी संवाद साधला
- LangChain4j फ्रेमवर्क आपोआप हाताळतो:
  - वापरकर्त्याचे प्रॉम्प्ट्स टूल कॉलमध्ये रूपांतरित करणे
  - LLM च्या निर्णयानुसार योग्य MCP टूल्स कॉल करणे
  - LLM आणि MCP सर्व्हरमधील संभाषण प्रवाह व्यवस्थापित करणे
- `bot.chat()` मेथड नैसर्गिक भाषेतील प्रतिसाद देते ज्यात MCP टूल्सच्या निष्पत्तींचा समावेश असू शकतो
- हा दृष्टिकोन वापरकर्त्यास एक अखंड अनुभव देतो जिथे त्यांना MCP च्या अंतर्गत अंमलबजावणीची माहिती नसते

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

छान, तुम्ही यशस्वीपणे पूर्ण केले!

## असाइनमेंट

सरावातील कोड घेऊन सर्व्हरमध्ये आणखी काही टूल्स तयार करा. नंतर सरावाप्रमाणे LLM सह क्लायंट तयार करा आणि वेगवेगळ्या प्रॉम्प्ट्ससह चाचणी करा जेणेकरून तुमचे सर्व्हर टूल्स डायनॅमिकली कॉल होतील याची खात्री करा. अशा प्रकारे क्लायंट तयार केल्याने अंतिम वापरकर्त्यास उत्तम अनुभव मिळेल कारण ते अचूक क्लायंट कमांड्सऐवजी प्रॉम्प्ट्स वापरू शकतील आणि कोणताही MCP सर्व्हर कॉल होत असल्याची त्यांना जाणीवही होणार नाही.

## सोल्यूशन

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## मुख्य मुद्दे

- क्लायंटमध्ये LLM जोडल्याने वापरकर्त्यांसाठी MCP सर्व्हरशी संवाद साधण्याचा चांगला मार्ग मिळतो.
- MCP सर्व्हरचा प्रतिसाद LLM समजेल अशा स्वरूपात रूपांतरित करणे आवश्यक आहे.

## नमुने

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधने

## पुढे काय

- पुढे: [Visual Studio Code वापरून सर्व्हर वापरणे](../04-vscode/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.