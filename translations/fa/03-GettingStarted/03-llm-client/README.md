<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T17:38:14+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "fa"
}
-->
# ایجاد یک کلاینت با LLM

تا اینجا، نحوه ایجاد یک سرور و یک کلاینت را دیده‌اید. کلاینت توانسته بود به صورت صریح سرور را فراخوانی کند تا ابزارها، منابع و پرامپت‌های آن را فهرست کند. اما این روش چندان عملی نیست. کاربر شما در عصر عامل‌محور زندگی می‌کند و انتظار دارد از پرامپت‌ها استفاده کند و با یک LLM ارتباط برقرار کند. برای کاربر شما مهم نیست که آیا از MCP برای ذخیره قابلیت‌ها استفاده می‌کنید یا نه، اما انتظار دارد با زبان طبیعی تعامل داشته باشد. پس چگونه این مشکل را حل کنیم؟ راه حل افزودن یک LLM به کلاینت است.

## مرور کلی

در این درس تمرکز ما بر افزودن یک LLM به کلاینت است و نشان می‌دهیم چگونه این کار تجربه بسیار بهتری برای کاربر شما فراهم می‌کند.

## اهداف یادگیری

تا پایان این درس، قادر خواهید بود:

- ایجاد یک کلاینت با یک LLM.
- تعامل بدون درز با سرور MCP با استفاده از LLM.
- ارائه تجربه بهتر برای کاربر نهایی در سمت کلاینت.

## رویکرد

بیایید رویکردی که باید دنبال کنیم را درک کنیم. افزودن یک LLM ساده به نظر می‌رسد، اما آیا واقعاً این کار را انجام خواهیم داد؟

نحوه تعامل کلاینت با سرور به این صورت است:

1. برقراری اتصال با سرور.

1. فهرست کردن قابلیت‌ها، پرامپت‌ها، منابع و ابزارها و ذخیره کردن اسکیمای آن‌ها.

1. افزودن یک LLM و ارسال قابلیت‌های ذخیره شده و اسکیمای آن‌ها به فرمتی که LLM می‌فهمد.

1. مدیریت پرامپت کاربر با ارسال آن به LLM همراه با ابزارهای فهرست شده توسط کلاینت.

عالی است، حالا که در سطح کلی فهمیدیم چگونه این کار را انجام دهیم، بیایید این را در تمرین زیر امتحان کنیم.

## تمرین: ایجاد یک کلاینت با LLM

در این تمرین، یاد می‌گیریم چگونه یک LLM را به کلاینت خود اضافه کنیم.

## احراز هویت با استفاده از توکن دسترسی شخصی GitHub

ایجاد یک توکن GitHub فرآیندی ساده است. در اینجا نحوه انجام آن آمده است:

- به تنظیمات GitHub بروید – روی عکس پروفایل خود در گوشه بالا سمت راست کلیک کنید و Settings را انتخاب کنید.
- به Developer Settings بروید – به پایین اسکرول کنید و روی Developer Settings کلیک کنید.
- Personal Access Tokens را انتخاب کنید – روی Personal access tokens کلیک کنید و سپس Generate new token را بزنید.
- توکن خود را پیکربندی کنید – یک یادداشت برای مرجع اضافه کنید، تاریخ انقضا تعیین کنید و مجوزهای لازم را انتخاب کنید.
- توکن را ایجاد و کپی کنید – روی Generate token کلیک کنید و حتماً فوراً آن را کپی کنید، چون دیگر قادر به دیدن آن نخواهید بود.

### -1- اتصال به سرور

بیایید ابتدا کلاینت خود را ایجاد کنیم:

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

در کد بالا:

- کتابخانه‌های مورد نیاز را وارد کردیم
- یک کلاس با دو عضو `client` و `openai` ایجاد کردیم که به ترتیب به ما در مدیریت کلاینت و تعامل با LLM کمک می‌کنند.
- نمونه LLM خود را طوری پیکربندی کردیم که از مدل‌های GitHub استفاده کند، با تنظیم `baseUrl` به API استنتاج.

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

در کد بالا:

- کتابخانه‌های مورد نیاز برای MCP را وارد کردیم
- یک کلاینت ایجاد کردیم

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

ابتدا باید وابستگی‌های LangChain4j را به فایل `pom.xml` خود اضافه کنید. این وابستگی‌ها را برای فعال‌سازی ادغام MCP و پشتیبانی از مدل‌های GitHub اضافه کنید:

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

در کد بالا:

- **وابستگی‌های LangChain4j را اضافه کردیم**: برای ادغام MCP، کلاینت رسمی OpenAI و پشتیبانی از مدل‌های GitHub
- **کتابخانه‌های LangChain4j را وارد کردیم**: برای ادغام MCP و عملکرد مدل چت OpenAI
- **یک `ChatLanguageModel` ایجاد کردیم**: پیکربندی شده برای استفاده از مدل‌های GitHub با توکن GitHub شما
- **انتقال HTTP را تنظیم کردیم**: با استفاده از Server-Sent Events (SSE) برای اتصال به سرور MCP
- **یک کلاینت MCP ایجاد کردیم**: که ارتباط با سرور را مدیریت می‌کند
- **از پشتیبانی داخلی MCP در LangChain4j استفاده کردیم**: که ادغام بین LLM و سرورهای MCP را ساده می‌کند

عالی است، برای مرحله بعدی، بیایید قابلیت‌های سرور را فهرست کنیم.

### -2- فهرست کردن قابلیت‌های سرور

حالا به سرور متصل می‌شویم و قابلیت‌های آن را درخواست می‌کنیم:

### Typescript

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

در کد بالا:

- کدی برای اتصال به سرور، `connectToServer` اضافه کردیم.
- متد `run` را ایجاد کردیم که مسئول مدیریت جریان برنامه ما است. تا اینجا فقط ابزارها را فهرست می‌کند اما به زودی موارد بیشتری به آن اضافه خواهیم کرد.

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

موارد اضافه شده:

- منابع و ابزارها را فهرست کردیم و چاپ کردیم. برای ابزارها همچنین `inputSchema` را فهرست کردیم که بعداً استفاده می‌کنیم.

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

در کد بالا:

- ابزارهای موجود در سرور MCP را فهرست کردیم
- برای هر ابزار، نام، توضیح و اسکیمای آن را فهرست کردیم. این مورد آخر چیزی است که به زودی برای فراخوانی ابزارها استفاده خواهیم کرد.

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

در کد بالا:

- یک `McpToolProvider` ایجاد کردیم که به صورت خودکار همه ابزارها را از سرور MCP کشف و ثبت می‌کند
- ارائه‌دهنده ابزار تبدیل بین اسکیمای ابزار MCP و فرمت ابزار LangChain4j را به صورت داخلی مدیریت می‌کند
- این رویکرد فرآیند فهرست کردن و تبدیل ابزارها را به صورت دستی حذف می‌کند

### -3- تبدیل قابلیت‌های سرور به ابزارهای LLM

گام بعدی پس از فهرست کردن قابلیت‌های سرور، تبدیل آن‌ها به فرمتی است که LLM می‌فهمد. وقتی این کار را انجام دادیم، می‌توانیم این قابلیت‌ها را به عنوان ابزار به LLM ارائه دهیم.

### TypeScript

1. کد زیر را برای تبدیل پاسخ از سرور MCP به فرمت ابزاری که LLM می‌تواند استفاده کند، اضافه کنید:

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

    کد بالا پاسخ از سرور MCP را گرفته و به فرمت تعریف ابزار تبدیل می‌کند که LLM می‌تواند آن را بفهمد.

1. حالا متد `run` را به‌روزرسانی کنیم تا قابلیت‌های سرور را فهرست کند:

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

    در کد بالا، متد `run` را به‌روزرسانی کردیم تا روی نتیجه پیمایش کند و برای هر ورودی `openAiToolAdapter` را فراخوانی کند.

### Python

1. ابتدا تابع تبدیل زیر را ایجاد کنیم:

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

    در تابع `convert_to_llm_tools` بالا، پاسخ ابزار MCP را گرفته و به فرمتی تبدیل می‌کنیم که LLM می‌تواند بفهمد.

1. سپس کد کلاینت خود را به گونه‌ای به‌روزرسانی کنیم که از این تابع استفاده کند:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    در اینجا، فراخوانی `convert_to_llm_tool` را اضافه کردیم تا پاسخ ابزار MCP را به چیزی تبدیل کنیم که بعداً به LLM بدهیم.

### .NET

1. کدی برای تبدیل پاسخ ابزار MCP به چیزی که LLM می‌تواند بفهمد اضافه کنیم:

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

در کد بالا:

- تابع `ConvertFrom` را ایجاد کردیم که نام، توضیح و اسکیمای ورودی را می‌گیرد.
- عملکردی تعریف کردیم که یک `FunctionDefinition` ایجاد می‌کند که به `ChatCompletionsDefinition` ارسال می‌شود. این مورد آخر چیزی است که LLM می‌تواند بفهمد.

1. حالا ببینیم چگونه می‌توانیم کد موجود را به‌روزرسانی کنیم تا از این تابع استفاده کند:

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

    در کد بالا:

    - تابع را به‌روزرسانی کردیم تا پاسخ ابزار MCP را به ابزار LLM تبدیل کند. بخش‌هایی که اضافه کردیم را برجسته می‌کنیم:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        اسکیمای ورودی بخشی از پاسخ ابزار است اما در ویژگی "properties" قرار دارد، بنابراین باید استخراج شود. علاوه بر این، اکنون `ConvertFrom` را با جزئیات ابزار فراخوانی می‌کنیم. حالا که بخش سنگین کار را انجام دادیم، ببینیم چگونه فراخوانی آن هنگام مدیریت پرامپت کاربر انجام می‌شود.

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

در کد بالا:

- یک رابط ساده `Bot` برای تعاملات زبان طبیعی تعریف کردیم
- از `AiServices` در LangChain4j استفاده کردیم تا به صورت خودکار LLM را با ارائه‌دهنده ابزار MCP متصل کند
- فریم‌ورک به صورت خودکار تبدیل اسکیمای ابزار و فراخوانی توابع را پشت صحنه مدیریت می‌کند
- این رویکرد تبدیل دستی ابزارها را حذف می‌کند - LangChain4j تمام پیچیدگی تبدیل ابزارهای MCP به فرمت سازگار با LLM را مدیریت می‌کند

عالی است، حالا آماده‌ایم درخواست‌های کاربر را مدیریت کنیم، پس بیایید به آن بپردازیم.

### -4- مدیریت درخواست پرامپت کاربر

در این بخش از کد، درخواست‌های کاربر را مدیریت می‌کنیم.

### TypeScript

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

    در کد بالا:

    - متد `callTools` را اضافه کردیم.
    - این متد پاسخ LLM را می‌گیرد و بررسی می‌کند که چه ابزارهایی فراخوانی شده‌اند، اگر وجود داشته باشند:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - اگر LLM نشان دهد باید ابزاری فراخوانی شود، آن را فراخوانی می‌کند:

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

عالی است، کد کامل را ببینیم:

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

1. برخی واردات لازم برای فراخوانی LLM را اضافه کنیم:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. سپس تابعی که LLM را فراخوانی می‌کند اضافه کنیم:

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

    در کد بالا:

    - توابعی که در سرور MCP یافتیم و تبدیل کردیم را به LLM دادیم.
    - سپس LLM را با این توابع فراخوانی کردیم.
    - نتیجه را بررسی می‌کنیم تا ببینیم چه توابعی باید فراخوانی شوند، اگر وجود داشته باشند.
    - در نهایت آرایه‌ای از توابع برای فراخوانی ارسال می‌کنیم.

1. مرحله نهایی، کد اصلی را به‌روزرسانی کنیم:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    این آخرین مرحله بود، در کد بالا:

    - یک ابزار MCP را از طریق `call_tool` با استفاده از تابعی که LLM فکر می‌کند باید بر اساس پرامپت ما فراخوانی شود، فراخوانی می‌کنیم.
    - نتیجه فراخوانی ابزار به سرور MCP را چاپ می‌کنیم.

### .NET

1. کدی برای انجام درخواست پرامپت LLM نشان دهیم:

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

    در کد بالا:

    - ابزارها را از سرور MCP دریافت کردیم، `var tools = await GetMcpTools()`.
    - یک پرامپت کاربر `userMessage` تعریف کردیم.
    - یک شیء options ساختیم که مدل و ابزارها را مشخص می‌کند.
    - درخواست به سمت LLM ارسال کردیم.

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

    در کد بالا:

    - روی لیست فراخوانی توابع حلقه زدیم.
    - برای هر فراخوانی ابزار، نام و آرگومان‌ها را استخراج کرده و ابزار را روی سرور MCP با استفاده از کلاینت MCP فراخوانی کردیم. در نهایت نتایج را چاپ کردیم.

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

در کد بالا:

- از پرامپت‌های ساده زبان طبیعی برای تعامل با ابزارهای سرور MCP استفاده کردیم
- فریم‌ورک LangChain4j به صورت خودکار موارد زیر را مدیریت می‌کند:
  - تبدیل پرامپت‌های کاربر به فراخوانی ابزار در صورت نیاز
  - فراخوانی ابزارهای مناسب MCP بر اساس تصمیم LLM
  - مدیریت جریان مکالمه بین LLM و سرور MCP
- متد `bot.chat()` پاسخ‌های زبان طبیعی را برمی‌گرداند که ممکن است شامل نتایج اجرای ابزارهای MCP باشد
- این رویکرد تجربه کاربری یکپارچه‌ای فراهم می‌کند که کاربران نیازی به دانستن جزئیات پیاده‌سازی MCP ندارند

نمونه کد کامل:

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

عالی است، شما موفق شدید!

## تمرین

کد تمرین را بردارید و سرور را با ابزارهای بیشتری توسعه دهید. سپس یک کلاینت با LLM ایجاد کنید، مانند تمرین، و آن را با پرامپت‌های مختلف آزمایش کنید تا مطمئن شوید همه ابزارهای سرور شما به صورت پویا فراخوانی می‌شوند. این روش ساخت کلاینت باعث می‌شود کاربر نهایی تجربه بسیار خوبی داشته باشد چون می‌تواند از پرامپت‌ها استفاده کند، به جای دستورات دقیق کلاینت، و از فراخوانی هر سرور MCP بی‌خبر باشد.

## راه حل

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## نکات کلیدی

- افزودن یک LLM به کلاینت شما راه بهتری برای تعامل کاربران با سرورهای MCP فراهم می‌کند.
- باید پاسخ سرور MCP را به فرمتی تبدیل کنید که LLM بتواند آن را بفهمد.

## نمونه‌ها

- [ماشین حساب جاوا](../samples/java/calculator/README.md)
- [ماشین حساب .Net](../../../../03-GettingStarted/samples/csharp)
- [ماشین حساب جاوااسکریپت](../samples/javascript/README.md)
- [ماشین حساب تایپ‌اسکریپت](../samples/typescript/README.md)
- [ماشین حساب پایتون](../../../../03-GettingStarted/samples/python)

## منابع اضافی

## مرحله بعد

- بعدی: [مصرف یک سرور با استفاده از Visual Studio Code](../04-vscode/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.