<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a656dbc7648e07da08eb4d1ffde4938e",
  "translation_date": "2025-07-22T08:47:32+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "fa"
}
-->
# ایجاد یک کلاینت با LLM

تا اینجا، شما یاد گرفتید که چگونه یک سرور و یک کلاینت ایجاد کنید. کلاینت توانسته است به صورت صریح سرور را فراخوانی کند تا ابزارها، منابع و پرامپت‌های آن را لیست کند. اما این روش خیلی عملی نیست. کاربر شما در عصر عامل‌محور زندگی می‌کند و انتظار دارد از پرامپت‌ها استفاده کند و با یک LLM ارتباط برقرار کند. برای کاربر شما، مهم نیست که آیا از MCP برای ذخیره قابلیت‌ها استفاده می‌کنید یا نه، اما انتظار دارد که از زبان طبیعی برای تعامل استفاده کند. پس چگونه این مشکل را حل کنیم؟ راه‌حل اضافه کردن یک LLM به کلاینت است.

## مرور کلی

در این درس، ما بر اضافه کردن یک LLM به کلاینت تمرکز می‌کنیم و نشان می‌دهیم که چگونه این کار تجربه بهتری برای کاربر شما فراهم می‌کند.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- یک کلاینت با LLM ایجاد کنید.
- به صورت یکپارچه با یک سرور MCP از طریق LLM تعامل کنید.
- تجربه کاربری بهتری در سمت کلاینت ارائه دهید.

## رویکرد

بیایید رویکردی که باید اتخاذ کنیم را درک کنیم. اضافه کردن یک LLM ساده به نظر می‌رسد، اما آیا واقعاً این کار را انجام می‌دهیم؟

در اینجا نحوه تعامل کلاینت با سرور آمده است:

1. برقراری ارتباط با سرور.

1. لیست کردن قابلیت‌ها، پرامپت‌ها، منابع و ابزارها و ذخیره کردن اسکیمای آن‌ها.

1. اضافه کردن یک LLM و انتقال قابلیت‌های ذخیره‌شده و اسکیمای آن‌ها در قالبی که LLM بفهمد.

1. مدیریت یک پرامپت کاربر با انتقال آن به LLM همراه با ابزارهایی که توسط کلاینت لیست شده‌اند.

عالی، حالا که فهمیدیم چگونه می‌توانیم این کار را در سطح بالا انجام دهیم، بیایید این را در تمرین زیر امتحان کنیم.

## تمرین: ایجاد یک کلاینت با LLM

در این تمرین، ما یاد می‌گیریم که چگونه یک LLM به کلاینت خود اضافه کنیم.

### احراز هویت با استفاده از GitHub Personal Access Token

ایجاد یک توکن GitHub فرآیندی ساده است. در اینجا نحوه انجام آن آمده است:

- به تنظیمات GitHub بروید – روی عکس پروفایل خود در گوشه بالا سمت راست کلیک کنید و گزینه Settings را انتخاب کنید.
- به تنظیمات توسعه‌دهنده بروید – به پایین اسکرول کنید و روی Developer Settings کلیک کنید.
- Personal Access Tokens را انتخاب کنید – روی Personal access tokens کلیک کنید و سپس Generate new token را انتخاب کنید.
- توکن خود را پیکربندی کنید – یک یادداشت برای مرجع اضافه کنید، تاریخ انقضا تنظیم کنید و محدوده‌های لازم (مجوزها) را انتخاب کنید.
- توکن را تولید و کپی کنید – روی Generate token کلیک کنید و مطمئن شوید که بلافاصله آن را کپی می‌کنید، زیرا دیگر نمی‌توانید آن را ببینید.

### -1- اتصال به سرور

ابتدا کلاینت خود را ایجاد کنیم:

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

در کد بالا ما:

- کتابخانه‌های موردنیاز را وارد کردیم.
- یک کلاس با دو عضو، `client` و `openai` ایجاد کردیم که به ما کمک می‌کند یک کلاینت مدیریت کنیم و با یک LLM تعامل کنیم.
- نمونه LLM خود را پیکربندی کردیم تا از مدل‌های GitHub استفاده کند با تنظیم `baseUrl` به API استنتاج.

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

در کد بالا ما:

- کتابخانه‌های موردنیاز برای MCP را وارد کردیم.
- یک کلاینت ایجاد کردیم.

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

ابتدا باید وابستگی‌های LangChain4j را به فایل `pom.xml` خود اضافه کنید. این وابستگی‌ها را برای فعال کردن یکپارچگی MCP و پشتیبانی از مدل‌های GitHub اضافه کنید:

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

سپس کلاس کلاینت جاوای خود را ایجاد کنید:

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

در کد بالا ما:

- **وابستگی‌های LangChain4j را اضافه کردیم**: برای یکپارچگی MCP، کلاینت رسمی OpenAI و پشتیبانی از مدل‌های GitHub.
- **کتابخانه‌های LangChain4j را وارد کردیم**: برای یکپارچگی MCP و قابلیت‌های مدل چت OpenAI.
- **یک `ChatLanguageModel` ایجاد کردیم**: که برای استفاده از مدل‌های GitHub با توکن GitHub شما پیکربندی شده است.
- **انتقال HTTP را تنظیم کردیم**: با استفاده از Server-Sent Events (SSE) برای اتصال به سرور MCP.
- **یک کلاینت MCP ایجاد کردیم**: که ارتباط با سرور را مدیریت می‌کند.
- **از پشتیبانی داخلی MCP در LangChain4j استفاده کردیم**: که یکپارچگی بین LLM‌ها و سرورهای MCP را ساده می‌کند.

عالی، برای مرحله بعدی، بیایید قابلیت‌های سرور را لیست کنیم.

### -2- لیست قابلیت‌های سرور

حالا ما به سرور متصل می‌شویم و از آن قابلیت‌هایش را درخواست می‌کنیم:

#### TypeScript

در همان کلاس، متدهای زیر را اضافه کنید:

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

در کد بالا ما:

- کدی برای اتصال به سرور، `connectToServer` اضافه کردیم.
- یک متد `run` ایجاد کردیم که مسئول مدیریت جریان برنامه ما است. تا اینجا فقط ابزارها را لیست می‌کند اما به زودی موارد بیشتری به آن اضافه خواهیم کرد.

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

در اینجا چیزی که اضافه کردیم:

- منابع و ابزارها را لیست کردیم و آن‌ها را چاپ کردیم. برای ابزارها همچنین `inputSchema` را لیست کردیم که بعداً از آن استفاده می‌کنیم.

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

در کد بالا ما:

- ابزارهای موجود در سرور MCP را لیست کردیم.
- برای هر ابزار، نام، توضیحات و اسکیمای آن را لیست کردیم. مورد آخر چیزی است که به زودی برای فراخوانی ابزارها از آن استفاده خواهیم کرد.

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

در کد بالا ما:

- یک `McpToolProvider` ایجاد کردیم که به طور خودکار تمام ابزارها را از سرور MCP کشف و ثبت می‌کند.
- ارائه‌دهنده ابزار تبدیل بین اسکیمای ابزار MCP و فرمت ابزار LangChain4j را به صورت داخلی مدیریت می‌کند.
- این رویکرد فرآیند لیست کردن و تبدیل ابزارها را به صورت دستی حذف می‌کند.

### -3- تبدیل قابلیت‌های سرور به ابزارهای LLM

مرحله بعدی پس از لیست کردن قابلیت‌های سرور، تبدیل آن‌ها به قالبی است که LLM بفهمد. وقتی این کار را انجام دادیم، می‌توانیم این قابلیت‌ها را به عنوان ابزار به LLM ارائه دهیم.

#### TypeScript

1. کد زیر را برای تبدیل پاسخ از سرور MCP به قالب ابزار LLM اضافه کنید:

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

    کد بالا پاسخ از سرور MCP را می‌گیرد و آن را به یک تعریف ابزار تبدیل می‌کند که LLM می‌تواند بفهمد.

1. حالا متد `run` را به‌روزرسانی کنید تا قابلیت‌های سرور را لیست کند:

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

    در کد بالا، متد `run` را به‌روزرسانی کردیم تا از نتیجه عبور کند و برای هر ورودی `openAiToolAdapter` را فراخوانی کند.

#### Python

1. ابتدا، تابع تبدیل زیر را ایجاد کنید:

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

    در تابع بالا `convert_to_llm_tools`، پاسخ ابزار MCP را می‌گیریم و آن را به قالبی تبدیل می‌کنیم که LLM بفهمد.

1. سپس، کد کلاینت خود را به‌روزرسانی کنید تا از این تابع استفاده کند:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    در اینجا، ما یک فراخوانی به `convert_to_llm_tool` اضافه کردیم تا پاسخ ابزار MCP را به چیزی تبدیل کنیم که بعداً بتوانیم به LLM بدهیم.

#### .NET

1. کدی برای تبدیل پاسخ ابزار MCP به چیزی که LLM بفهمد اضافه کنید:

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

در کد بالا ما:

- یک تابع `ConvertFrom` ایجاد کردیم که نام، توضیحات و اسکیمای ورودی را می‌گیرد.
- عملکردی تعریف کردیم که یک FunctionDefinition ایجاد می‌کند که به یک ChatCompletionsDefinition منتقل می‌شود. دومی چیزی است که LLM می‌تواند بفهمد.

1. حالا ببینیم چگونه می‌توانیم کد موجود را به‌روزرسانی کنیم تا از این تابع استفاده کنیم:

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

    در کد بالا، تابع را به‌روزرسانی کردیم تا پاسخ ابزار MCP را به یک ابزار LLM تبدیل کند. حالا که کارهای سنگین را انجام دادیم، بیایید ببینیم چگونه همه چیز کنار هم قرار می‌گیرد وقتی که پرامپت کاربر را مدیریت می‌کنیم.

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

در کد بالا ما:

- یک رابط ساده `Bot` برای تعاملات زبان طبیعی تعریف کردیم.
- از `AiServices` در LangChain4j استفاده کردیم تا به طور خودکار LLM را با ارائه‌دهنده ابزار MCP متصل کنیم.
- فریم‌ورک به طور خودکار تبدیل اسکیمای ابزار و فراخوانی توابع را در پشت صحنه مدیریت می‌کند.
- این رویکرد پیچیدگی تبدیل ابزارها را حذف می‌کند - LangChain4j تمام پیچیدگی‌های تبدیل ابزارهای MCP به قالب سازگار با LLM را مدیریت می‌کند.

### -4- مدیریت درخواست پرامپت کاربر

در این بخش از کد، ما درخواست‌های کاربر را مدیریت می‌کنیم.

#### TypeScript

1. متدی اضافه کنید که برای فراخوانی LLM استفاده خواهد شد:

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

    در کد بالا ما:

    - متدی به نام `callTools` اضافه کردیم.
    - این متد پاسخ LLM را می‌گیرد و بررسی می‌کند که آیا ابزاری فراخوانی شده است یا خیر:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - اگر LLM نشان دهد که ابزاری باید فراخوانی شود، آن را فراخوانی می‌کند:

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

1. متد `run` را به‌روزرسانی کنید تا شامل فراخوانی‌های LLM و `callTools` باشد:

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

عالی، کد کامل را لیست کنیم:

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

1. برخی از واردات موردنیاز برای فراخوانی LLM را اضافه کنید:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. سپس، تابعی اضافه کنید که LLM را فراخوانی کند:

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

    در کد بالا ما:

    - توابعی که در سرور MCP پیدا کردیم و تبدیل کردیم را به LLM منتقل کردیم.
    - سپس LLM را با این توابع فراخوانی کردیم.
    - سپس، نتیجه را بررسی کردیم تا ببینیم چه توابعی باید فراخوانی شوند، اگر وجود داشته باشند.
    - در نهایت، آرایه‌ای از توابع برای فراخوانی منتقل کردیم.

1. مرحله نهایی، کد اصلی را به‌روزرسانی کنید:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    در کد بالا ما:

    - یک ابزار MCP را از طریق `call_tool` با استفاده از تابعی که LLM فکر می‌کرد باید بر اساس پرامپت ما فراخوانی شود، فراخوانی کردیم.
    - نتیجه فراخوانی ابزار را به سرور MCP چاپ کردیم.

#### .NET

1. کدی برای انجام درخواست پرامپت LLM نشان دهید:

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

    در کد بالا ما:

    - ابزارها را از سرور MCP دریافت کردیم، `var tools = await GetMcpTools()`.
    - یک پرامپت کاربر تعریف کردیم `userMessage`.
    - یک شیء گزینه‌ها ایجاد کردیم که مدل و ابزارها را مشخص می‌کند.
    - یک درخواست به سمت LLM ارسال کردیم.

1. یک مرحله آخر، ببینیم آیا LLM فکر می‌کند باید تابعی فراخوانی شود:

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

    در کد بالا ما:

    - از طریق لیستی از فراخوانی توابع حلقه زدیم.
    - برای هر ابزار، نام و آرگومان‌ها را تجزیه کردیم و ابزار را در سرور MCP با استفاده از کلاینت MCP فراخوانی کردیم. در نهایت نتایج را چاپ کردیم.

کد کامل:

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

در کد بالا ما:

- از پرامپت‌های زبان طبیعی ساده برای تعامل با ابزارهای سرور MCP استفاده کردیم.
- فریم‌ورک LangChain4j به طور خودکار مدیریت می‌کند:
  - تبدیل پرامپت‌های کاربر به فراخوانی ابزارها در صورت نیاز.
  - فراخوانی ابزارهای مناسب MCP بر اساس تصمیم LLM.
  - مدیریت جریان مکالمه بین LLM و سرور MCP.
- متد `bot.chat()` پاسخ‌های زبان طبیعی را برمی‌گرداند که ممکن است شامل نتایج اجرای ابزارهای MCP باشد.
- این رویکرد تجربه کاربری یکپارچه‌ای فراهم می‌کند که در آن کاربران نیازی به دانستن پیاده‌سازی MCP زیرین ندارند.

مثال کامل کد:

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

عالی، شما موفق شدید!

## تکلیف

کد تمرین را بگیرید و سرور را با ابزارهای بیشتری گسترش دهید. سپس یک کلاینت با LLM ایجاد کنید، مانند تمرین، و آن را با پرامپت‌های مختلف آزمایش کنید تا مطمئن شوید تمام ابزارهای سرور شما به صورت پویا فراخوانی می‌شوند. این روش ساخت کلاینت به این معناست که کاربر نهایی تجربه کاربری عالی خواهد داشت زیرا می‌تواند از پرامپت‌ها استفاده کند، به جای دستورات دقیق کلاینت، و از هرگونه سرور MCP که فراخوانی می‌شود بی‌خبر باشد.

## راه‌حل

[راه‌حل](/03-GettingStarted/03-llm-client/solution/README.md)

## نکات کلیدی

- اضافه کردن یک LLM به کلاینت شما راه بهتری برای تعامل کاربران با سرورهای MCP فراهم می‌کند.
- شما باید پاسخ سرور MCP را به چیزی که LLM بفهمد تبدیل کنید.

## نمونه‌ها

- [ماشین حساب جاوا](../samples/java/calculator/README.md)
- [ماشین حساب .Net](../../../../03-GettingStarted/samples/csharp)
- [ماشین حساب جاوااسکریپت](../samples/javascript/README.md)
- [ماشین حساب تایپ‌اسکریپت](../samples/typescript/README.md)
- [ماشین حساب پایتون](../../../../03-GettingStarted/samples/python)

## منابع اضافی

## مرحله بعدی

- بعدی: [مصرف یک سرور با استفاده از Visual Studio Code](../04-vscode/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما تلاش می‌کنیم دقت را حفظ کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل خطاها یا نادرستی‌ها باشند. سند اصلی به زبان اصلی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حساس، توصیه می‌شود از ترجمه حرفه‌ای انسانی استفاده کنید. ما مسئولیتی در قبال سوء تفاهم‌ها یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.