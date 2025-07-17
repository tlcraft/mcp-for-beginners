<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T06:04:01+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "th"
}
-->
# การสร้างไคลเอนต์ด้วย LLM

จนถึงตอนนี้ คุณได้เห็นวิธีการสร้างเซิร์ฟเวอร์และไคลเอนต์ ไคลเอนต์สามารถเรียกเซิร์ฟเวอร์โดยตรงเพื่อแสดงรายการเครื่องมือ ทรัพยากร และพรอมต์ต่างๆ ได้ อย่างไรก็ตาม นี่ไม่ใช่วิธีที่ใช้งานได้จริงมากนัก ผู้ใช้ของคุณอยู่ในยุคของเอเจนต์และคาดหวังที่จะใช้พรอมต์และสื่อสารกับ LLM เพื่อทำงานเหล่านั้น สำหรับผู้ใช้ของคุณ พวกเขาไม่สนใจว่าคุณจะใช้ MCP หรือไม่ในการเก็บความสามารถของคุณ แต่พวกเขาคาดหวังที่จะใช้ภาษาธรรมชาติเพื่อโต้ตอบ ดังนั้นเราจะแก้ปัญหานี้อย่างไร? คำตอบคือการเพิ่ม LLM เข้าไปในไคลเอนต์

## ภาพรวม

ในบทเรียนนี้ เราจะเน้นการเพิ่ม LLM เข้าไปในไคลเอนต์ของคุณ และแสดงให้เห็นว่าสิ่งนี้ช่วยให้ประสบการณ์ของผู้ใช้ดีขึ้นอย่างไร

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- สร้างไคลเอนต์ที่มี LLM
- โต้ตอบกับเซิร์ฟเวอร์ MCP อย่างราบรื่นโดยใช้ LLM
- มอบประสบการณ์ผู้ใช้ที่ดีกว่าฝั่งไคลเอนต์

## วิธีการ

ลองทำความเข้าใจวิธีการที่เราต้องใช้ การเพิ่ม LLM ดูเหมือนจะง่าย แต่เราจะทำจริงหรือไม่?

นี่คือวิธีที่ไคลเอนต์จะโต้ตอบกับเซิร์ฟเวอร์:

1. สร้างการเชื่อมต่อกับเซิร์ฟเวอร์

1. แสดงรายการความสามารถ พรอมต์ ทรัพยากร และเครื่องมือ พร้อมบันทึกสคีมาของพวกมัน

1. เพิ่ม LLM และส่งความสามารถที่บันทึกไว้พร้อมสคีมาในรูปแบบที่ LLM เข้าใจ

1. จัดการพรอมต์ของผู้ใช้โดยส่งต่อไปยัง LLM พร้อมกับเครื่องมือที่ไคลเอนต์แสดงรายการไว้

เยี่ยมมาก ตอนนี้เราเข้าใจภาพรวมแล้ว ลองทำแบบฝึกหัดด้านล่างกัน

## แบบฝึกหัด: การสร้างไคลเอนต์ด้วย LLM

ในแบบฝึกหัดนี้ เราจะเรียนรู้การเพิ่ม LLM เข้าไปในไคลเอนต์ของเรา

## การยืนยันตัวตนด้วย GitHub Personal Access Token

การสร้างโทเค็น GitHub เป็นกระบวนการที่ตรงไปตรงมา นี่คือวิธีทำ:

- ไปที่การตั้งค่า GitHub – คลิกที่รูปโปรไฟล์ของคุณที่มุมขวาบนแล้วเลือก Settings
- ไปที่ Developer Settings – เลื่อนลงมาแล้วคลิก Developer Settings
- เลือก Personal Access Tokens – คลิกที่ Personal access tokens แล้วเลือก Generate new token
- กำหนดค่าโทเค็นของคุณ – เพิ่มหมายเหตุสำหรับอ้างอิง ตั้งวันหมดอายุ และเลือกขอบเขต (สิทธิ์) ที่จำเป็น
- สร้างและคัดลอกโทเค็น – คลิก Generate token และอย่าลืมคัดลอกทันที เพราะคุณจะไม่สามารถเห็นมันอีก

### -1- เชื่อมต่อกับเซิร์ฟเวอร์

มาเริ่มสร้างไคลเอนต์ของเรากันก่อน:

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

ในโค้ดข้างต้น เราได้:

- นำเข้าห้องสมุดที่จำเป็น
- สร้างคลาสที่มีสมาชิกสองตัว คือ `client` และ `openai` ซึ่งจะช่วยจัดการไคลเอนต์และโต้ตอบกับ LLM ตามลำดับ
- กำหนดค่าอินสแตนซ์ LLM ของเราให้ใช้ GitHub Models โดยตั้งค่า `baseUrl` ให้ชี้ไปยัง inference API

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

ในโค้ดข้างต้น เราได้:

- นำเข้าห้องสมุดที่จำเป็นสำหรับ MCP
- สร้างไคลเอนต์

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

ก่อนอื่น คุณต้องเพิ่ม dependencies ของ LangChain4j ลงในไฟล์ `pom.xml` ของคุณ เพิ่ม dependencies เหล่านี้เพื่อเปิดใช้งานการรวม MCP และรองรับ GitHub Models:

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

จากนั้นสร้างคลาสไคลเอนต์ Java ของคุณ:

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

ในโค้ดข้างต้น เราได้:

- **เพิ่ม dependencies ของ LangChain4j**: จำเป็นสำหรับการรวม MCP, ไคลเอนต์ OpenAI อย่างเป็นทางการ และการรองรับ GitHub Models
- **นำเข้าห้องสมุด LangChain4j**: สำหรับการรวม MCP และฟังก์ชันโมเดลแชทของ OpenAI
- **สร้าง `ChatLanguageModel`**: กำหนดค่าให้ใช้ GitHub Models พร้อมโทเค็น GitHub ของคุณ
- **ตั้งค่า HTTP transport**: ใช้ Server-Sent Events (SSE) เพื่อเชื่อมต่อกับเซิร์ฟเวอร์ MCP
- **สร้างไคลเอนต์ MCP**: ที่จะจัดการการสื่อสารกับเซิร์ฟเวอร์
- **ใช้การสนับสนุน MCP ในตัวของ LangChain4j**: ซึ่งช่วยให้ง่ายต่อการรวม LLM กับเซิร์ฟเวอร์ MCP

ดีมาก ขั้นตอนถัดไป เรามาแสดงรายการความสามารถบนเซิร์ฟเวอร์กัน

### -2 แสดงรายการความสามารถของเซิร์ฟเวอร์

ตอนนี้เราจะเชื่อมต่อกับเซิร์ฟเวอร์และขอความสามารถของมัน:

### TypeScript

ในคลาสเดียวกัน ให้เพิ่มเมธอดต่อไปนี้:

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

ในโค้ดข้างต้น เราได้:

- เพิ่มโค้ดสำหรับเชื่อมต่อกับเซิร์ฟเวอร์ `connectToServer`
- สร้างเมธอด `run` ที่รับผิดชอบจัดการลำดับการทำงานของแอป ตอนนี้มันแค่แสดงรายการเครื่องมือ แต่เราจะเพิ่มฟังก์ชันอื่นๆ ในไม่ช้า

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

นี่คือสิ่งที่เราเพิ่ม:

- แสดงรายการทรัพยากรและเครื่องมือพร้อมพิมพ์ออกมา สำหรับเครื่องมือเรายังแสดง `inputSchema` ซึ่งจะใช้ในภายหลัง

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

ในโค้ดข้างต้น เราได้:

- แสดงรายการเครื่องมือที่มีใน MCP Server
- สำหรับแต่ละเครื่องมือ แสดงชื่อ คำอธิบาย และสคีมาของมัน ซึ่งเราจะใช้เรียกเครื่องมือในไม่ช้า

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

ในโค้ดข้างต้น เราได้:

- สร้าง `McpToolProvider` ที่ค้นหาและลงทะเบียนเครื่องมือทั้งหมดจาก MCP Server โดยอัตโนมัติ
- ตัวจัดการเครื่องมือจะจัดการการแปลงระหว่างสคีมาของเครื่องมือ MCP กับรูปแบบเครื่องมือของ LangChain4j ภายใน
- วิธีนี้ช่วยลดความยุ่งยากในการแสดงรายการและแปลงเครื่องมือด้วยตนเอง

### -3- แปลงความสามารถของเซิร์ฟเวอร์เป็นเครื่องมือสำหรับ LLM

ขั้นตอนถัดไปหลังจากแสดงรายการความสามารถของเซิร์ฟเวอร์คือการแปลงให้เป็นรูปแบบที่ LLM เข้าใจ เมื่อทำเสร็จแล้ว เราสามารถมอบความสามารถเหล่านี้เป็นเครื่องมือให้กับ LLM ได้

### TypeScript

1. เพิ่มโค้ดต่อไปนี้เพื่อแปลงการตอบสนองจาก MCP Server เป็นรูปแบบเครื่องมือที่ LLM ใช้ได้:

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

    โค้ดข้างต้นจะรับการตอบสนองจาก MCP Server และแปลงเป็นรูปแบบการกำหนดเครื่องมือที่ LLM เข้าใจ

1. ต่อไปอัปเดตเมธอด `run` เพื่อแสดงรายการความสามารถของเซิร์ฟเวอร์:

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

    ในโค้ดข้างต้น เราอัปเดตเมธอด `run` เพื่อวนลูปผลลัพธ์และสำหรับแต่ละรายการเรียก `openAiToolAdapter`

### Python

1. ก่อนอื่น สร้างฟังก์ชันแปลงดังนี้

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

    ในฟังก์ชัน `convert_to_llm_tools` ข้างต้น เรารับการตอบสนองเครื่องมือ MCP และแปลงเป็นรูปแบบที่ LLM เข้าใจ

1. ต่อไปอัปเดตโค้ดไคลเอนต์ของเราเพื่อใช้ฟังก์ชันนี้ดังนี้:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    ที่นี่ เราเพิ่มการเรียก `convert_to_llm_tool` เพื่อแปลงการตอบสนองเครื่องมือ MCP เป็นสิ่งที่เราสามารถส่งให้ LLM ได้ในภายหลัง

### .NET

1. เพิ่มโค้ดเพื่อแปลงการตอบสนองเครื่องมือ MCP เป็นสิ่งที่ LLM เข้าใจ

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

ในโค้ดข้างต้น เราได้:

- สร้างฟังก์ชัน `ConvertFrom` ที่รับชื่อ คำอธิบาย และสคีมาของอินพุต
- กำหนดฟังก์ชันที่สร้าง `FunctionDefinition` ซึ่งจะถูกส่งต่อไปยัง `ChatCompletionsDefinition` ซึ่งเป็นสิ่งที่ LLM เข้าใจ

1. มาดูวิธีอัปเดตโค้ดที่มีอยู่เพื่อใช้ฟังก์ชันนี้:

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

    ในโค้ดข้างต้น เราได้:

    - อัปเดตฟังก์ชันเพื่อแปลงการตอบสนองเครื่องมือ MCP เป็นเครื่องมือ LLM โดยเน้นโค้ดที่เพิ่ม:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        สคีมาของอินพุตเป็นส่วนหนึ่งของการตอบสนองเครื่องมือ แต่จะอยู่ในแอตทริบิวต์ "properties" ดังนั้นเราต้องดึงออกมา นอกจากนี้ เรายังเรียก `ConvertFrom` พร้อมรายละเอียดเครื่องมือ ตอนนี้ที่เราได้ทำงานหนักเสร็จแล้ว มาดูวิธีเรียกใช้งานเมื่อจัดการพรอมต์ของผู้ใช้ในขั้นตอนถัดไป

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

ในโค้ดข้างต้น เราได้:

- กำหนดอินเทอร์เฟซ `Bot` ง่ายๆ สำหรับการโต้ตอบด้วยภาษาธรรมชาติ
- ใช้ `AiServices` ของ LangChain4j เพื่อผูก LLM กับ MCP tool provider โดยอัตโนมัติ
- เฟรมเวิร์กจัดการการแปลงสคีมาของเครื่องมือและการเรียกฟังก์ชันเบื้องหลังโดยอัตโนมัติ
- วิธีนี้ช่วยลดความยุ่งยากในการแปลงเครื่องมือด้วยตนเอง — LangChain4j ดูแลความซับซ้อนทั้งหมดในการแปลงเครื่องมือ MCP ให้เข้ากับรูปแบบที่ LLM เข้าใจ

ดีมาก ตอนนี้เราพร้อมจัดการคำขอของผู้ใช้แล้ว มาดูขั้นตอนถัดไปกัน

### -4- จัดการคำขอพรอมต์ของผู้ใช้

ในส่วนนี้ของโค้ด เราจะจัดการคำขอของผู้ใช้

### TypeScript

1. เพิ่มเมธอดที่จะใช้เรียก LLM:

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

    ในโค้ดข้างต้น เราได้:

    - เพิ่มเมธอด `callTools`
    - เมธอดนี้รับการตอบสนองจาก LLM และตรวจสอบว่าเครื่องมือใดถูกเรียกใช้งานบ้าง (ถ้ามี):

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - เรียกเครื่องมือ หาก LLM ระบุว่าควรเรียก:

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

1. อัปเดตเมธอด `run` เพื่อรวมการเรียก LLM และเรียก `callTools`:

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

เยี่ยมมาก มาดูโค้ดทั้งหมดกัน:

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

1. เพิ่มการนำเข้าที่จำเป็นสำหรับการเรียก LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. ต่อไปเพิ่มฟังก์ชันที่จะเรียก LLM:

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

    ในโค้ดข้างต้น เราได้:

    - ส่งฟังก์ชันที่เราค้นพบจาก MCP Server และแปลงแล้วให้กับ LLM
    - เรียก LLM ด้วยฟังก์ชันเหล่านั้น
    - ตรวจสอบผลลัพธ์เพื่อดูว่าควรเรียกฟังก์ชันใดบ้าง (ถ้ามี)
    - สุดท้ายส่งอาร์เรย์ของฟังก์ชันที่จะเรียก

1. ขั้นตอนสุดท้าย อัปเดตโค้ดหลักของเรา:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    นั่นคือขั้นตอนสุดท้าย ในโค้ดข้างต้น เราได้:

    - เรียกเครื่องมือ MCP ผ่าน `call_tool` โดยใช้ฟังก์ชันที่ LLM คิดว่าเราควรเรียกตามพรอมต์ของเรา
    - พิมพ์ผลลัพธ์ของการเรียกเครื่องมือไปยัง MCP Server

### .NET

1. แสดงโค้ดสำหรับการร้องขอพรอมต์ LLM:

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

    ในโค้ดข้างต้น เราได้:

    - ดึงเครื่องมือจาก MCP Server ด้วย `var tools = await GetMcpTools()`
    - กำหนดพรอมต์ของผู้ใช้ `userMessage`
    - สร้างอ็อบเจ็กต์ options ระบุโมเดลและเครื่องมือ
    - ส่งคำขอไปยัง LLM

1. ขั้นตอนสุดท้าย มาดูว่า LLM คิดว่าเราควรเรียกฟังก์ชันหรือไม่:

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

    ในโค้ดข้างต้น เราได้:

    - วนลูปผ่านรายการฟังก์ชันที่เรียก
    - สำหรับแต่ละการเรียกเครื่องมือ แยกชื่อและอาร์กิวเมนต์ แล้วเรียกเครื่องมือบน MCP Server ผ่านไคลเอนต์ MCP สุดท้ายพิมพ์ผลลัพธ์

นี่คือโค้ดทั้งหมด:

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

ในโค้ดข้างต้น เราได้:

- ใช้พรอมต์ภาษาธรรมชาติอย่างง่ายเพื่อโต้ตอบกับเครื่องมือบน MCP Server
- เฟรมเวิร์ก LangChain4j จัดการโดยอัตโนมัติ:
  - การแปลงพรอมต์ผู้ใช้เป็นการเรียกเครื่องมือเมื่อจำเป็น
  - การเรียกเครื่องมือ MCP ที่เหมาะสมตามการตัดสินใจของ LLM
  - การจัดการลำดับการสนทนาระหว่าง LLM และ MCP Server
- เมธอด `bot.chat()` ส่งคืนการตอบสนองด้วยภาษาธรรมชาติที่อาจรวมผลลัพธ์จากการเรียกใช้เครื่องมือ MCP
- วิธีนี้มอบประสบการณ์ผู้ใช้ที่ราบรื่นโดยที่ผู้ใช้ไม่จำเป็นต้องรู้เกี่ยวกับการทำงานภายในของ MCP

ตัวอย่างโค้ดสมบูรณ์:

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

เยี่ยมมาก คุณทำได้!

## การบ้าน

นำโค้ดจากแบบฝึกหัดไปสร้างเซิร์ฟเวอร์ที่มีเครื่องมือเพิ่มเติม จากนั้นสร้างไคลเอนต์ที่มี LLM เหมือนในแบบฝึกหัด และทดสอบด้วยพรอมต์ต่างๆ เพื่อให้แน่ใจว่าเครื่องมือทั้งหมดบนเซิร์ฟเวอร์ถูกเรียกใช้งานแบบไดนามิก วิธีการสร้างไคลเอนต์แบบนี้จะช่วยให้ผู้ใช้ปลายทางได้รับประสบการณ์ที่ดี เพราะพวกเขาสามารถใช้พรอมต์แทนคำสั่งไคลเอนต์ที่แม่นยำ และไม่ต้องรู้ว่ามีการเรียกใช้ MCP Server อยู่เบื้องหลัง

## โซลูชัน

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## ประเด็นสำคัญที่ควรจดจำ

- การเพิ่ม LLM เข้าไปในไคลเอนต์ช่วยให้ผู้ใช้โต้ตอบกับ MCP Server ได้ดีขึ้น
- คุณต้องแปลงการตอบสนองจาก MCP Server เป็นรูปแบบที่ LLM เข้าใจ

## ตัวอย่าง

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## แหล่งข้อมูลเพิ่มเติม

## ต่อไป

- ถัดไป: [การใช้งานเซิร์ฟเวอร์ด้วย Visual Studio Code](../04-vscode/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดขึ้นจากการใช้การแปลนี้