<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-16T23:50:26+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ur"
}
-->
# LLM کے ساتھ کلائنٹ بنانا

اب تک، آپ نے دیکھا کہ سرور اور کلائنٹ کیسے بنائے جاتے ہیں۔ کلائنٹ سرور کو واضح طور پر کال کر کے اس کے ٹولز، وسائل اور پرامپٹس کی فہرست حاصل کر سکتا ہے۔ تاہم، یہ طریقہ کار زیادہ عملی نہیں ہے۔ آپ کا صارف ایجنٹک دور میں رہتا ہے اور توقع کرتا ہے کہ وہ پرامپٹس استعمال کرے گا اور LLM کے ساتھ بات چیت کرے گا۔ آپ کے صارف کے لیے یہ اہم نہیں کہ آپ اپنی صلاحیتوں کو ذخیرہ کرنے کے لیے MCP استعمال کرتے ہیں یا نہیں، لیکن وہ قدرتی زبان میں بات چیت کی توقع رکھتے ہیں۔ تو ہم اس مسئلے کو کیسے حل کریں؟ حل یہ ہے کہ کلائنٹ میں ایک LLM شامل کیا جائے۔

## جائزہ

اس سبق میں ہم کلائنٹ میں LLM شامل کرنے پر توجہ دیں گے اور دکھائیں گے کہ یہ آپ کے صارف کے لیے کس طرح بہتر تجربہ فراہم کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے آخر تک، آپ قابل ہوں گے:

- LLM کے ساتھ ایک کلائنٹ بنائیں۔
- LLM کا استعمال کرتے ہوئے MCP سرور کے ساتھ بغیر رکاوٹ بات چیت کریں۔
- کلائنٹ سائڈ پر بہتر صارف تجربہ فراہم کریں۔

## طریقہ کار

آئیے سمجھنے کی کوشش کرتے ہیں کہ ہمیں کون سا طریقہ اختیار کرنا ہے۔ LLM شامل کرنا آسان لگتا ہے، لیکن کیا ہم واقعی ایسا کریں گے؟

یہ ہے کہ کلائنٹ سرور کے ساتھ کیسے بات چیت کرے گا:

1. سرور کے ساتھ کنکشن قائم کریں۔

1. صلاحیتوں، پرامپٹس، وسائل اور ٹولز کی فہرست بنائیں، اور ان کا اسکیمہ محفوظ کریں۔

1. ایک LLM شامل کریں اور محفوظ شدہ صلاحیتوں اور ان کے اسکیمے کو ایسے فارمیٹ میں پاس کریں جو LLM سمجھ سکے۔

1. صارف کے پرامپٹ کو LLM کو پاس کریں، ساتھ ہی کلائنٹ کی طرف سے فہرست کردہ ٹولز بھی بھیجیں۔

زبردست، اب جب ہم اعلی سطح پر سمجھ گئے ہیں کہ یہ کیسے کیا جا سکتا ہے، تو آئیے نیچے دیے گئے مشق میں اسے آزما کر دیکھتے ہیں۔

## مشق: LLM کے ساتھ کلائنٹ بنانا

اس مشق میں، ہم سیکھیں گے کہ اپنے کلائنٹ میں LLM کیسے شامل کیا جائے۔

## GitHub پرسنل ایکسیس ٹوکن کے ذریعے تصدیق

GitHub ٹوکن بنانا ایک آسان عمل ہے۔ آپ یہ طریقہ استعمال کر سکتے ہیں:

- GitHub سیٹنگز پر جائیں – اوپر دائیں کونے میں اپنی پروفائل تصویر پر کلک کریں اور Settings منتخب کریں۔
- Developer Settings پر جائیں – نیچے سکرول کریں اور Developer Settings پر کلک کریں۔
- Personal Access Tokens منتخب کریں – Personal access tokens پر کلک کریں اور پھر Generate new token پر کلک کریں۔
- اپنا ٹوکن ترتیب دیں – حوالہ کے لیے نوٹ شامل کریں، ایک میعاد ختم ہونے کی تاریخ مقرر کریں، اور ضروری اسکوپس (اجازتیں) منتخب کریں۔
- ٹوکن بنائیں اور کاپی کریں – Generate token پر کلک کریں، اور فوراً اسے کاپی کر لیں کیونکہ آپ اسے دوبارہ نہیں دیکھ سکیں گے۔

### -1- سرور سے کنکشن قائم کریں

آئیے پہلے اپنا کلائنٹ بنائیں:

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

پچھلے کوڈ میں ہم نے:

- ضروری لائبریریاں امپورٹ کیں
- ایک کلاس بنائی جس میں دو ممبرز `client` اور `openai` شامل ہیں جو کلائنٹ کو منظم کرنے اور LLM کے ساتھ بات چیت کرنے میں مدد دیں گے۔
- اپنے LLM انسٹینس کو GitHub Models استعمال کرنے کے لیے ترتیب دیا، `baseUrl` کو inference API کی طرف سیٹ کیا۔

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

پچھلے کوڈ میں ہم نے:

- MCP کے لیے ضروری لائبریریاں امپورٹ کیں
- ایک کلائنٹ بنایا

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

سب سے پہلے، آپ کو اپنے `pom.xml` فائل میں LangChain4j کی dependencies شامل کرنی ہوں گی۔ MCP انٹیگریشن اور GitHub Models کی سپورٹ کے لیے یہ dependencies شامل کریں:

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

پھر اپنی Java کلائنٹ کلاس بنائیں:

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

پچھلے کوڈ میں ہم نے:

- **LangChain4j dependencies شامل کیں**: MCP انٹیگریشن، OpenAI آفیشل کلائنٹ، اور GitHub Models کی سپورٹ کے لیے ضروری
- **LangChain4j لائبریریاں امپورٹ کیں**: MCP انٹیگریشن اور OpenAI چیٹ ماڈل کی فعالیت کے لیے
- **`ChatLanguageModel` بنایا**: GitHub Models کو آپ کے GitHub ٹوکن کے ساتھ استعمال کرنے کے لیے ترتیب دیا
- **HTTP ٹرانسپورٹ سیٹ کیا**: Server-Sent Events (SSE) کا استعمال کرتے ہوئے MCP سرور سے کنکشن کے لیے
- **MCP کلائنٹ بنایا**: جو سرور کے ساتھ بات چیت سنبھالے گا
- **LangChain4j کی بلٹ ان MCP سپورٹ استعمال کی**: جو LLMs اور MCP سرورز کے درمیان انٹیگریشن کو آسان بناتی ہے

زبردست، اگلے مرحلے کے لیے، آئیے سرور کی صلاحیتوں کی فہرست بنائیں۔

### -2 سرور کی صلاحیتوں کی فہرست بنائیں

اب ہم سرور سے کنیکٹ کریں گے اور اس کی صلاحیتوں کے بارے میں پوچھیں گے:

### TypeScript

اسی کلاس میں، درج ذیل طریقے شامل کریں:

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

پچھلے کوڈ میں ہم نے:

- سرور سے کنکشن کے لیے کوڈ شامل کیا، `connectToServer`۔
- `run` میتھڈ بنایا جو ہماری ایپ کے فلو کو سنبھالتا ہے۔ اب تک یہ صرف ٹولز کی فہرست دیتا ہے لیکن ہم جلد ہی اس میں مزید شامل کریں گے۔

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

یہ ہے جو ہم نے شامل کیا:

- وسائل اور ٹولز کی فہرست بنائی اور پرنٹ کی۔ ٹولز کے لیے ہم `inputSchema` بھی فہرست کرتے ہیں جو بعد میں استعمال ہوگا۔

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

پچھلے کوڈ میں ہم نے:

- MCP سرور پر دستیاب ٹولز کی فہرست بنائی
- ہر ٹول کے لیے نام، وضاحت اور اس کا اسکیمہ فہرست کیا۔ یہ اسکیمہ وہ چیز ہے جسے ہم جلد ہی ٹولز کو کال کرنے کے لیے استعمال کریں گے۔

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

پچھلے کوڈ میں ہم نے:

- `McpToolProvider` بنایا جو خودکار طور پر MCP سرور سے تمام ٹولز دریافت اور رجسٹر کرتا ہے
- ٹول پرووائیڈر MCP ٹول اسکیموں اور LangChain4j کے ٹول فارمیٹ کے درمیان تبدیلی کو اندرونی طور پر سنبھالتا ہے
- یہ طریقہ کار دستی ٹول لسٹنگ اور تبدیلی کے عمل کو چھپا دیتا ہے

### -3- سرور کی صلاحیتوں کو LLM ٹولز میں تبدیل کریں

سرور کی صلاحیتوں کی فہرست بنانے کے بعد اگلا قدم انہیں ایسے فارمیٹ میں تبدیل کرنا ہے جو LLM سمجھ سکے۔ جب ہم یہ کر لیں، تو ہم ان صلاحیتوں کو اپنے LLM کے لیے ٹولز کے طور پر فراہم کر سکتے ہیں۔

### TypeScript

1. MCP سرور کے جواب کو LLM کے قابل استعمال ٹول فارمیٹ میں تبدیل کرنے کے لیے درج ذیل کوڈ شامل کریں:

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

    اوپر دیا گیا کوڈ MCP سرور کے جواب کو لے کر اسے ایسے ٹول کی تعریف میں تبدیل کرتا ہے جو LLM سمجھ سکے۔

1. اب `run` میتھڈ کو اپ ڈیٹ کریں تاکہ سرور کی صلاحیتوں کی فہرست بنائی جا سکے:

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

    پچھلے کوڈ میں، ہم نے `run` میتھڈ کو اپ ڈیٹ کیا تاکہ نتیجہ میں موجود ہر انٹری پر `openAiToolAdapter` کال کی جا سکے۔

### Python

1. سب سے پہلے، درج ذیل کنورٹر فنکشن بنائیں:

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

    `convert_to_llm_tools` فنکشن میں ہم MCP ٹول کے جواب کو ایسے فارمیٹ میں تبدیل کرتے ہیں جو LLM سمجھ سکے۔

1. پھر اپنے کلائنٹ کوڈ کو اس فنکشن کا استعمال کرنے کے لیے اپ ڈیٹ کریں:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    یہاں ہم `convert_to_llm_tool` کو کال کر رہے ہیں تاکہ MCP ٹول کے جواب کو ایسی شکل میں تبدیل کیا جا سکے جسے ہم بعد میں LLM کو دے سکیں۔

### .NET

1. MCP ٹول کے جواب کو LLM کے قابل سمجھنے والے فارمیٹ میں تبدیل کرنے کے لیے کوڈ شامل کریں:

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

پچھلے کوڈ میں ہم نے:

- `ConvertFrom` فنکشن بنایا جو نام، وضاحت اور ان پٹ اسکیمہ لیتا ہے۔
- ایسی فعالیت متعین کی جو `FunctionDefinition` بناتی ہے اور اسے `ChatCompletionsDefinition` کو دیتی ہے۔ یہ وہ چیز ہے جو LLM سمجھ سکتا ہے۔

1. اب دیکھتے ہیں کہ ہم موجودہ کوڈ کو اس فنکشن کے فائدے کے لیے کیسے اپ ڈیٹ کر سکتے ہیں:

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

    پچھلے کوڈ میں ہم نے:

    - MCP ٹول کے جواب کو LLM ٹول میں تبدیل کرنے کے لیے فنکشن کو اپ ڈیٹ کیا۔ آئیے اس کوڈ کو نمایاں کریں جو ہم نے شامل کیا:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        ان پٹ اسکیمہ ٹول کے جواب کا حصہ ہے لیکن "properties" ایٹریبیوٹ میں، اس لیے ہمیں اسے نکالنا پڑتا ہے۔ مزید برآں، ہم اب `ConvertFrom` کو ٹول کی تفصیلات کے ساتھ کال کرتے ہیں۔ اب جب ہم نے یہ بھاری کام کر لیا ہے، تو دیکھتے ہیں کہ صارف کے پرامپٹ کو ہینڈل کرتے ہوئے یہ کال کیسے آتی ہے۔

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

پچھلے کوڈ میں ہم نے:

- قدرتی زبان کی بات چیت کے لیے ایک سادہ `Bot` انٹرفیس متعین کیا
- LangChain4j کے `AiServices` کا استعمال کیا تاکہ LLM کو خودکار طور پر MCP ٹول پرووائیڈر کے ساتھ باندھ دیا جائے
- فریم ورک خودکار طور پر ٹول اسکیمہ کی تبدیلی اور فنکشن کالنگ کو پس منظر میں سنبھالتا ہے
- یہ طریقہ کار دستی ٹول تبدیلی کو ختم کرتا ہے - LangChain4j MCP ٹولز کو LLM کے قابل قبول فارمیٹ میں تبدیل کرنے کی تمام پیچیدگی سنبھالتا ہے

زبردست، اب ہم صارف کی درخواستوں کو ہینڈل کرنے کے لیے تیار ہیں، تو آئیے اگلے مرحلے پر چلتے ہیں۔

### -4- صارف کے پرامپٹ کی درخواست کو ہینڈل کریں

اس حصے میں، ہم صارف کی درخواستوں کو ہینڈل کریں گے۔

### TypeScript

1. ایک ایسا میتھڈ شامل کریں جو ہمارے LLM کو کال کرے گا:

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

    پچھلے کوڈ میں ہم نے:

    - `callTools` میتھڈ شامل کیا۔
    - یہ میتھڈ LLM کے جواب کو لیتا ہے اور چیک کرتا ہے کہ کون سے ٹولز کال کیے گئے ہیں، اگر کوئی ہیں:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - اگر LLM نے کسی ٹول کو کال کرنے کا اشارہ دیا تو اسے کال کرتا ہے:

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

1. `run` میتھڈ کو اپ ڈیٹ کریں تاکہ LLM کو کال کیا جا سکے اور `callTools` کو کال کیا جا سکے:

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

زبردست، مکمل کوڈ درج ذیل ہے:

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

1. LLM کو کال کرنے کے لیے ضروری امپورٹس شامل کریں:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. پھر وہ فنکشن شامل کریں جو LLM کو کال کرے گا:

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

    پچھلے کوڈ میں ہم نے:

    - اپنے فنکشنز جو MCP سرور سے حاصل کیے اور تبدیل کیے، LLM کو دیے۔
    - پھر LLM کو ان فنکشنز کے ساتھ کال کیا۔
    - نتیجہ کا معائنہ کیا کہ کون سے فنکشنز کال کرنے چاہئیں، اگر کوئی ہوں۔
    - آخر میں، کال کرنے کے لیے فنکشنز کی ایک فہرست پاس کی۔

1. آخری مرحلہ، اپنے مرکزی کوڈ کو اپ ڈیٹ کریں:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    یہ آخری مرحلہ تھا، اوپر کے کوڈ میں ہم:

    - `call_tool` کے ذریعے MCP ٹول کو کال کر رہے ہیں، وہ فنکشن جو LLM نے ہمارے پرامپٹ کی بنیاد پر کال کرنے کا سوچا۔
    - MCP سرور کو ٹول کال کے نتیجے کو پرنٹ کر رہے ہیں۔

### .NET

1. LLM پرامپٹ کی درخواست کے لیے کوڈ دکھائیں:

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

    پچھلے کوڈ میں ہم نے:

    - MCP سرور سے ٹولز حاصل کیے، `var tools = await GetMcpTools()`۔
    - صارف کا پرامپٹ `userMessage` متعین کیا۔
    - ماڈل اور ٹولز کی وضاحت کرتے ہوئے ایک options آبجیکٹ بنایا۔
    - LLM کی طرف درخواست بھیجی۔

1. آخری مرحلہ، دیکھیں کہ کیا LLM سمجھتا ہے کہ ہمیں فنکشن کال کرنی چاہیے:

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

    پچھلے کوڈ میں ہم نے:

    - فنکشن کالز کی فہرست میں لوپ لگایا۔
    - ہر ٹول کال کے لیے نام اور دلائل نکالے اور MCP کلائنٹ کا استعمال کرتے ہوئے MCP سرور پر ٹول کال کی۔ آخر میں نتائج پرنٹ کیے۔

مکمل کوڈ درج ذیل ہے:

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

پچھلے کوڈ میں ہم نے:

- MCP سرور کے ٹولز کے ساتھ سادہ قدرتی زبان کے پرامپٹس استعمال کیے
- LangChain4j فریم ورک خودکار طور پر سنبھالتا ہے:
  - جب ضرورت ہو تو صارف کے پرامپٹس کو ٹول کالز میں تبدیل کرنا
  - LLM کے فیصلے کی بنیاد پر مناسب MCP ٹولز کو کال کرنا
  - LLM اور MCP سرور کے درمیان گفتگو کے بہاؤ کو منظم کرنا
- `bot.chat()` میتھڈ قدرتی زبان میں جوابات دیتا ہے جن میں MCP ٹولز کے نتائج شامل ہو سکتے ہیں
- یہ طریقہ کار صارف کو ایک ہموار تجربہ فراہم کرتا ہے جہاں صارفین کو MCP کی اندرونی تفصیلات کا علم نہیں ہوتا

مکمل کوڈ کی مثال:

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

زبردست، آپ نے کر دکھایا!

## اسائنمنٹ

مشق سے کوڈ لیں اور سرور میں مزید ٹولز شامل کریں۔ پھر LLM کے ساتھ ایک کلائنٹ بنائیں، جیسا کہ مشق میں کیا گیا، اور مختلف پرامپٹس کے ساتھ اسے آزما کر دیکھیں کہ آپ کے سرور کے تمام ٹولز متحرک طور پر کال ہو رہے ہیں۔ کلائنٹ بنانے کا یہ طریقہ صارف کو بہترین تجربہ فراہم کرتا ہے کیونکہ وہ مخصوص کلائنٹ کمانڈز کے بجائے پرامپٹس استعمال کر سکتے ہیں اور انہیں MCP سرور کی کالنگ کا علم نہیں ہوتا۔

## حل

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## اہم نکات

- اپنے کلائنٹ میں LLM شامل کرنے سے صارفین کے لیے MCP سرورز کے ساتھ بات چیت کا بہتر طریقہ فراہم ہوتا ہے۔
- آپ کو MCP سرور کے جواب کو ایسے فارمیٹ میں تبدیل کرنا ہوگا جو LLM سمجھ سکے۔

## نمونے

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## اضافی وسائل

## آگے کیا ہے

- اگلا: [Visual Studio Code استعمال کرتے ہوئے سرور کا استعمال](../04-vscode/README.md)

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔