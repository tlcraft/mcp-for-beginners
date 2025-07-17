<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-16T23:39:03+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ar"
}
-->
# إنشاء عميل مع LLM

حتى الآن، رأيت كيف تنشئ خادمًا وعميلًا. كان العميل قادرًا على استدعاء الخادم صراحةً لعرض أدواته وموارده والنماذج النصية. ومع ذلك، هذه ليست طريقة عملية جدًا. المستخدم الخاص بك يعيش في عصر الوكلاء ويتوقع استخدام النماذج النصية والتواصل مع LLM للقيام بذلك. بالنسبة لمستخدمك، لا يهم إذا كنت تستخدم MCP أم لا لتخزين قدراتك، لكنهم يتوقعون استخدام اللغة الطبيعية للتفاعل. فكيف نحل هذه المشكلة؟ الحل هو إضافة LLM إلى العميل.

## نظرة عامة

في هذا الدرس نركز على إضافة LLM إلى عميلك ونوضح كيف يوفر ذلك تجربة أفضل بكثير لمستخدمك.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- إنشاء عميل مع LLM.
- التفاعل بسلاسة مع خادم MCP باستخدام LLM.
- تقديم تجربة مستخدم أفضل على جانب العميل.

## النهج

دعونا نحاول فهم النهج الذي نحتاج إلى اتخاذه. إضافة LLM تبدو بسيطة، لكن هل سنفعل ذلك فعليًا؟

إليك كيف سيتفاعل العميل مع الخادم:

1. إنشاء اتصال مع الخادم.

1. عرض القدرات، النماذج النصية، الموارد والأدوات، وحفظ مخططها.

1. إضافة LLM وتمرير القدرات المحفوظة ومخططها بصيغة يفهمها LLM.

1. التعامل مع نموذج المستخدم بتمريره إلى LLM مع الأدوات التي يعرضها العميل.

رائع، الآن فهمنا كيف يمكننا القيام بذلك على مستوى عالٍ، دعونا نجرب ذلك في التمرين أدناه.

## تمرين: إنشاء عميل مع LLM

في هذا التمرين، سنتعلم كيفية إضافة LLM إلى عميلنا.

## المصادقة باستخدام رمز الوصول الشخصي لـ GitHub

إنشاء رمز GitHub هو عملية بسيطة. إليك كيف يمكنك القيام بذلك:

- اذهب إلى إعدادات GitHub – انقر على صورة ملفك الشخصي في الزاوية العلوية اليمنى واختر الإعدادات.
- انتقل إلى إعدادات المطور – قم بالتمرير لأسفل وانقر على إعدادات المطور.
- اختر رموز الوصول الشخصية – انقر على رموز الوصول الشخصية ثم إنشاء رمز جديد.
- قم بتكوين الرمز الخاص بك – أضف ملاحظة للرجوع إليها، حدد تاريخ انتهاء الصلاحية، واختر الأذونات اللازمة.
- أنشئ وانسخ الرمز – انقر على إنشاء الرمز، وتأكد من نسخه فورًا، لأنك لن تتمكن من رؤيته مرة أخرى.

### -1- الاتصال بالخادم

لننشئ عميلنا أولاً:

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

في الكود السابق قمنا بـ:

- استيراد المكتبات اللازمة
- إنشاء فئة تحتوي على عضوين، `client` و `openai`، لمساعدتنا في إدارة العميل والتفاعل مع LLM على التوالي.
- تكوين مثيل LLM لاستخدام نماذج GitHub عن طريق تعيين `baseUrl` للإشارة إلى واجهة برمجة التطبيقات الخاصة بالاستدلال.

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

في الكود السابق قمنا بـ:

- استيراد المكتبات اللازمة لـ MCP
- إنشاء عميل

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

أولاً، ستحتاج إلى إضافة تبعيات LangChain4j إلى ملف `pom.xml` الخاص بك. أضف هذه التبعيات لتمكين تكامل MCP ودعم نماذج GitHub:

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

ثم أنشئ فئة العميل الخاصة بك في Java:

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

في الكود السابق قمنا بـ:

- **إضافة تبعيات LangChain4j**: المطلوبة لتكامل MCP، العميل الرسمي لـ OpenAI، ودعم نماذج GitHub
- **استيراد مكتبات LangChain4j**: لتكامل MCP ووظائف نموذج الدردشة OpenAI
- **إنشاء `ChatLanguageModel`**: مهيأ لاستخدام نماذج GitHub مع رمز GitHub الخاص بك
- **إعداد النقل عبر HTTP**: باستخدام Server-Sent Events (SSE) للاتصال بخادم MCP
- **إنشاء عميل MCP**: الذي سيتولى التواصل مع الخادم
- **استخدام دعم MCP المدمج في LangChain4j**: الذي يبسط التكامل بين LLM وخوادم MCP

رائع، للخطوة التالية، دعونا نعرض القدرات على الخادم.

### -2 عرض قدرات الخادم

الآن سنتصل بالخادم ونطلب قدراته:

### Typescript

في نفس الفئة، أضف الطرق التالية:

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

في الكود السابق قمنا بـ:

- إضافة كود للاتصال بالخادم، `connectToServer`.
- إنشاء طريقة `run` المسؤولة عن إدارة تدفق التطبيق. حتى الآن تعرض فقط الأدوات لكننا سنضيف المزيد قريبًا.

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

إليك ما أضفناه:

- عرض الموارد والأدوات وطباعتها. بالنسبة للأدوات، نعرض أيضًا `inputSchema` الذي سنستخدمه لاحقًا.

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

في الكود السابق قمنا بـ:

- عرض الأدوات المتاحة على خادم MCP
- لكل أداة، عرض الاسم والوصف ومخططها. هذا الأخير هو ما سنستخدمه لاستدعاء الأدوات قريبًا.

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

في الكود السابق قمنا بـ:

- إنشاء `McpToolProvider` الذي يكتشف ويسجل تلقائيًا جميع الأدوات من خادم MCP
- مزود الأدوات يتولى تحويل مخططات أدوات MCP إلى صيغة أدوات LangChain4j داخليًا
- هذا النهج يلغي الحاجة إلى عرض الأدوات يدويًا وعملية التحويل

### -3- تحويل قدرات الخادم إلى أدوات LLM

الخطوة التالية بعد عرض قدرات الخادم هي تحويلها إلى صيغة يفهمها LLM. بمجرد القيام بذلك، يمكننا تقديم هذه القدرات كأدوات لـ LLM.

### TypeScript

1. أضف الكود التالي لتحويل استجابة خادم MCP إلى صيغة أداة يمكن لـ LLM استخدامها:

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

    الكود أعلاه يأخذ استجابة من خادم MCP ويحولها إلى صيغة تعريف أداة يفهمها LLM.

1. دعنا نحدث طريقة `run` بعد ذلك لعرض قدرات الخادم:

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

    في الكود السابق، قمنا بتحديث طريقة `run` لتتصفح النتيجة ولكل إدخال تستدعي `openAiToolAdapter`.

### Python

1. أولاً، دعنا ننشئ دالة المحول التالية

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

    في الدالة أعلاه `convert_to_llm_tools` نأخذ استجابة أداة MCP ونحولها إلى صيغة يمكن لـ LLM فهمها.

1. بعد ذلك، دعنا نحدث كود العميل للاستفادة من هذه الدالة كما يلي:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    هنا، نضيف استدعاءً لـ `convert_to_llm_tool` لتحويل استجابة أداة MCP إلى شيء يمكننا تغذيته إلى LLM لاحقًا.

### .NET

1. دعنا نضيف كودًا لتحويل استجابة أداة MCP إلى شيء يمكن لـ LLM فهمه

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

في الكود السابق قمنا بـ:

- إنشاء دالة `ConvertFrom` التي تأخذ الاسم، الوصف ومخطط الإدخال.
- تعريف وظيفة تنشئ `FunctionDefinition` يتم تمريرها إلى `ChatCompletionsDefinition`. هذا الأخير هو ما يمكن لـ LLM فهمه.

1. دعنا نرى كيف يمكننا تحديث بعض الكود الموجود للاستفادة من هذه الدالة أعلاه:

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

في الكود السابق، قمنا بـ:

- تحديث الدالة لتحويل استجابة أداة MCP إلى أداة LLM. دعونا نبرز الكود الذي أضفناه:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        مخطط الإدخال هو جزء من استجابة الأداة لكنه في خاصية "properties"، لذا نحتاج إلى استخراجه. علاوة على ذلك، نستدعي الآن `ConvertFrom` مع تفاصيل الأداة. بعد أن قمنا بالعمل الشاق، دعونا نرى كيف يتجمع الاستدعاء أثناء تعاملنا مع نموذج المستخدم لاحقًا.

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

في الكود السابق قمنا بـ:

- تعريف واجهة بسيطة `Bot` للتفاعلات باللغة الطبيعية
- استخدام `AiServices` من LangChain4j لربط LLM تلقائيًا مع مزود أدوات MCP
- الإطار يتولى تلقائيًا تحويل مخطط الأدوات واستدعاء الوظائف خلف الكواليس
- هذا النهج يلغي الحاجة إلى تحويل الأدوات يدويًا - LangChain4j يتولى كل تعقيدات تحويل أدوات MCP إلى صيغة متوافقة مع LLM

رائع، نحن الآن مستعدون للتعامل مع أي طلبات من المستخدم، فلننتقل لذلك.

### -4- التعامل مع طلب نموذج المستخدم

في هذا الجزء من الكود، سنتعامل مع طلبات المستخدم.

### TypeScript

1. أضف طريقة ستستخدم لاستدعاء LLM الخاص بنا:

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

    في الكود السابق قمنا بـ:

    - إضافة طريقة `callTools`.
    - الطريقة تأخذ استجابة LLM وتتحقق من الأدوات التي تم استدعاؤها، إن وجدت:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - تستدعي أداة، إذا أشار LLM إلى أنه يجب استدعاؤها:

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

1. حدث طريقة `run` لتشمل استدعاءات إلى LLM واستدعاء `callTools`:

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

رائع، دعونا نعرض الكود بالكامل:

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

1. دعنا نضيف بعض الاستيرادات اللازمة لاستدعاء LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. بعد ذلك، دعنا نضيف الدالة التي ستستدعي LLM:

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

    في الكود السابق قمنا بـ:

    - تمرير الدوال التي وجدناها على خادم MCP وقمنا بتحويلها إلى LLM.
    - ثم استدعينا LLM مع هذه الدوال.
    - بعد ذلك، نفحص النتيجة لنرى ما هي الدوال التي يجب استدعاؤها، إن وجدت.
    - أخيرًا، نمرر مصفوفة من الدوال للاستدعاء.

1. الخطوة النهائية، دعنا نحدث الكود الرئيسي:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    ها هي الخطوة النهائية، في الكود أعلاه نحن:

    - نستدعي أداة MCP عبر `call_tool` باستخدام دالة اعتقد LLM أنه يجب استدعاؤها بناءً على النموذج النصي.
    - نطبع نتيجة استدعاء الأداة إلى خادم MCP.

### .NET

1. دعنا نعرض بعض الكود لطلب نموذج LLM:

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

    في الكود السابق قمنا بـ:

    - جلب الأدوات من خادم MCP، `var tools = await GetMcpTools()`.
    - تعريف نموذج المستخدم `userMessage`.
    - إنشاء كائن خيارات يحدد النموذج والأدوات.
    - إجراء طلب إلى LLM.

1. خطوة أخيرة، دعنا نرى إذا كان LLM يعتقد أنه يجب استدعاء دالة:

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

    في الكود السابق قمنا بـ:

    - التكرار عبر قائمة استدعاءات الدوال.
    - لكل استدعاء أداة، تحليل الاسم والوسائط واستدعاء الأداة على خادم MCP باستخدام عميل MCP. وأخيرًا نطبع النتائج.

إليك الكود بالكامل:

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

في الكود السابق قمنا بـ:

- استخدام نماذج نصية بسيطة للتفاعل مع أدوات خادم MCP
- إطار LangChain4j يتولى تلقائيًا:
  - تحويل نماذج المستخدم إلى استدعاءات أدوات عند الحاجة
  - استدعاء أدوات MCP المناسبة بناءً على قرار LLM
  - إدارة تدفق المحادثة بين LLM وخادم MCP
- طريقة `bot.chat()` تعيد ردودًا باللغة الطبيعية قد تتضمن نتائج تنفيذ أدوات MCP
- هذا النهج يوفر تجربة مستخدم سلسة حيث لا يحتاج المستخدمون لمعرفة تفاصيل تنفيذ MCP الأساسية

مثال الكود الكامل:

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

رائع، لقد أنجزت المهمة!

## الواجب

خذ الكود من التمرين وقم بتوسيع الخادم ببعض الأدوات الإضافية. ثم أنشئ عميلًا مع LLM، كما في التمرين، وجربه مع نماذج مختلفة للتأكد من أن جميع أدوات الخادم يتم استدعاؤها ديناميكيًا. هذه الطريقة في بناء العميل تعني أن المستخدم النهائي سيحصل على تجربة مستخدم رائعة لأنه قادر على استخدام النماذج النصية بدلاً من أوامر العميل الدقيقة، وسيكون غير مدرك لأي خادم MCP يتم استدعاؤه.

## الحل

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## النقاط الرئيسية

- إضافة LLM إلى عميلك يوفر طريقة أفضل للمستخدمين للتفاعل مع خوادم MCP.
- تحتاج إلى تحويل استجابة خادم MCP إلى صيغة يمكن لـ LLM فهمها.

## عينات

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## موارد إضافية

## ما التالي

- التالي: [استهلاك خادم باستخدام Visual Studio Code](../04-vscode/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.