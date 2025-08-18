<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
  "translation_date": "2025-08-18T14:32:39+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "th"
}
-->
# การสร้างไคลเอนต์ด้วย LLM

จนถึงตอนนี้ คุณได้เรียนรู้วิธีสร้างเซิร์ฟเวอร์และไคลเอนต์ ไคลเอนต์สามารถเรียกเซิร์ฟเวอร์เพื่อแสดงรายการเครื่องมือ ทรัพยากร และคำสั่งได้อย่างชัดเจน อย่างไรก็ตาม วิธีนี้ไม่ค่อยสะดวกนัก ผู้ใช้ของคุณอยู่ในยุคที่เน้นการใช้ตัวแทน (agentic era) และคาดหวังที่จะใช้คำสั่งและสื่อสารกับ LLM เพื่อทำงานต่างๆ สำหรับผู้ใช้ของคุณ พวกเขาไม่สนใจว่าคุณจะใช้ MCP หรือไม่ในการจัดเก็บความสามารถ แต่พวกเขาคาดหวังที่จะใช้ภาษาธรรมชาติในการโต้ตอบ แล้วเราจะแก้ปัญหานี้ได้อย่างไร? คำตอบคือการเพิ่ม LLM เข้าไปในไคลเอนต์

## ภาพรวม

ในบทเรียนนี้ เราจะมุ่งเน้นไปที่การเพิ่ม LLM เข้าไปในไคลเอนต์ของคุณ และแสดงให้เห็นว่ามันช่วยปรับปรุงประสบการณ์ของผู้ใช้ได้อย่างไร

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- สร้างไคลเอนต์ที่มี LLM
- โต้ตอบกับเซิร์ฟเวอร์ MCP ได้อย่างราบรื่นโดยใช้ LLM
- มอบประสบการณ์การใช้งานที่ดีกว่าให้กับผู้ใช้ในฝั่งไคลเอนต์

## วิธีการ

ลองมาทำความเข้าใจวิธีการที่เราต้องใช้ การเพิ่ม LLM ฟังดูง่าย แต่เราจะทำสิ่งนี้จริงๆ ได้อย่างไร?

นี่คือวิธีที่ไคลเอนต์จะโต้ตอบกับเซิร์ฟเวอร์:

1. สร้างการเชื่อมต่อกับเซิร์ฟเวอร์

1. แสดงรายการความสามารถ คำสั่ง ทรัพยากร และเครื่องมือ และบันทึกโครงสร้างของพวกมัน

1. เพิ่ม LLM และส่งความสามารถที่บันทึกไว้และโครงสร้างของพวกมันในรูปแบบที่ LLM เข้าใจ

1. จัดการคำสั่งของผู้ใช้โดยส่งไปยัง LLM พร้อมกับเครื่องมือที่ไคลเอนต์แสดงรายการไว้

ดีมาก ตอนนี้เราเข้าใจวิธีการทำงานในระดับสูงแล้ว ลองทำตามในแบบฝึกหัดด้านล่างนี้

## แบบฝึกหัด: การสร้างไคลเอนต์ด้วย LLM

ในแบบฝึกหัดนี้ เราจะเรียนรู้วิธีเพิ่ม LLM เข้าไปในไคลเอนต์ของเรา

### การตรวจสอบสิทธิ์โดยใช้ GitHub Personal Access Token

การสร้าง GitHub token เป็นกระบวนการที่ง่าย นี่คือวิธีการ:

- ไปที่ GitHub Settings – คลิกที่รูปโปรไฟล์ของคุณที่มุมขวาบนและเลือก Settings
- ไปที่ Developer Settings – เลื่อนลงและคลิกที่ Developer Settings
- เลือก Personal Access Tokens – คลิกที่ Personal access tokens และจากนั้น Generate new token
- กำหนดค่าตัว Token – เพิ่มหมายเหตุสำหรับการอ้างอิง ตั้งวันหมดอายุ และเลือกขอบเขต (permissions) ที่จำเป็น
- สร้างและคัดลอก Token – คลิก Generate token และอย่าลืมคัดลอกทันที เพราะคุณจะไม่สามารถดูมันได้อีก

### -1- เชื่อมต่อกับเซิร์ฟเวอร์

มาสร้างไคลเอนต์ของเราก่อน:

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

ในโค้ดข้างต้นเราได้:

- นำเข้าห้องสมุดที่จำเป็น
- สร้างคลาสที่มีสมาชิกสองตัว `client` และ `openai` ซึ่งจะช่วยเราจัดการไคลเอนต์และโต้ตอบกับ LLM
- กำหนดค่าอินสแตนซ์ LLM ของเราให้ใช้ GitHub Models โดยตั้งค่า `baseUrl` ให้ชี้ไปที่ inference API

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

ในโค้ดข้างต้นเราได้:

- นำเข้าห้องสมุดที่จำเป็นสำหรับ MCP
- สร้างไคลเอนต์

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

ก่อนอื่น คุณจะต้องเพิ่ม dependencies ของ LangChain4j ลงในไฟล์ `pom.xml` ของคุณ เพิ่ม dependencies เหล่านี้เพื่อเปิดใช้งานการรวม MCP และการสนับสนุน GitHub Models:

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

ในโค้ดข้างต้นเราได้:

- **เพิ่ม dependencies ของ LangChain4j**: จำเป็นสำหรับการรวม MCP, ไคลเอนต์ OpenAI อย่างเป็นทางการ และการสนับสนุน GitHub Models
- **นำเข้าห้องสมุด LangChain4j**: สำหรับการรวม MCP และฟังก์ชันโมเดลแชทของ OpenAI
- **สร้าง `ChatLanguageModel`**: กำหนดค่าให้ใช้ GitHub Models พร้อมกับ GitHub token ของคุณ
- **ตั้งค่าการส่งข้อมูล HTTP**: โดยใช้ Server-Sent Events (SSE) เพื่อเชื่อมต่อกับเซิร์ฟเวอร์ MCP
- **สร้าง MCP client**: ที่จะจัดการการสื่อสารกับเซิร์ฟเวอร์
- **ใช้การสนับสนุน MCP ในตัวของ LangChain4j**: ซึ่งช่วยให้การรวมระหว่าง LLM และเซิร์ฟเวอร์ MCP ง่ายขึ้น

#### Rust

ตัวอย่างนี้สมมติว่าคุณมีเซิร์ฟเวอร์ MCP ที่ใช้ Rust ทำงานอยู่ หากคุณยังไม่มี ให้ย้อนกลับไปที่บทเรียน [01-first-server](../01-first-server/README.md) เพื่อสร้างเซิร์ฟเวอร์

เมื่อคุณมีเซิร์ฟเวอร์ MCP ที่ใช้ Rust แล้ว ให้เปิดเทอร์มินัลและไปยังไดเรกทอรีเดียวกับเซิร์ฟเวอร์ จากนั้นรันคำสั่งต่อไปนี้เพื่อสร้างโปรเจกต์ไคลเอนต์ LLM ใหม่:

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

เพิ่ม dependencies ต่อไปนี้ลงในไฟล์ `Cargo.toml` ของคุณ:

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> ยังไม่มีห้องสมุด Rust อย่างเป็นทางการสำหรับ OpenAI อย่างไรก็ตาม crate `async-openai` เป็น [ห้องสมุดที่ชุมชนดูแล](https://platform.openai.com/docs/libraries/rust#rust) ซึ่งใช้กันทั่วไป

เปิดไฟล์ `src/main.rs` และแทนที่เนื้อหาด้วยโค้ดต่อไปนี้:

```rust
use async_openai::{Client, config::OpenAIConfig};
use rmcp::{
    RmcpError,
    model::{CallToolRequestParam, ListToolsResult},
    service::{RoleClient, RunningService, ServiceExt},
    transport::{ConfigureCommandExt, TokioChildProcess},
};
use serde_json::{Value, json};
use std::error::Error;
use tokio::process::Command;

#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    // Initial message
    let mut messages = vec![json!({"role": "user", "content": "What is the sum of 3 and 2?"})];

    // Setup OpenAI client
    let api_key = std::env::var("OPENAI_API_KEY")?;
    let openai_client = Client::with_config(
        OpenAIConfig::new()
            .with_api_base("https://models.github.ai/inference/chat")
            .with_api_key(api_key),
    );

    // Setup MCP client
    let server_dir = std::path::Path::new(env!("CARGO_MANIFEST_DIR"))
        .parent()
        .unwrap()
        .join("calculator-server");

    let mcp_client = ()
        .serve(
            TokioChildProcess::new(Command::new("cargo").configure(|cmd| {
                cmd.arg("run").current_dir(server_dir);
            }))
            .map_err(RmcpError::transport_creation::<TokioChildProcess>)?,
        )
        .await?;

    // TODO: Get MCP tool listing 

    // TODO: LLM conversation with tool calls

    Ok(())
}
```

โค้ดนี้ตั้งค่าแอปพลิเคชัน Rust พื้นฐานที่จะเชื่อมต่อกับเซิร์ฟเวอร์ MCP และ GitHub Models สำหรับการโต้ตอบ LLM

> [!IMPORTANT]
> อย่าลืมตั้งค่าตัวแปรสภาพแวดล้อม `OPENAI_API_KEY` ด้วย GitHub token ของคุณก่อนรันแอปพลิเคชัน

ดีมาก ขั้นตอนต่อไปคือการแสดงรายการความสามารถบนเซิร์ฟเวอร์

### -2- แสดงรายการความสามารถของเซิร์ฟเวอร์

ตอนนี้เราจะเชื่อมต่อกับเซิร์ฟเวอร์และขอความสามารถของมัน:

#### Typescript

ในคลาสเดียวกัน เพิ่มเมธอดต่อไปนี้:

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

ในโค้ดข้างต้นเราได้:

- เพิ่มโค้ดสำหรับการเชื่อมต่อกับเซิร์ฟเวอร์ `connectToServer`
- สร้างเมธอด `run` ที่รับผิดชอบการจัดการ flow ของแอปของเรา ตอนนี้มันแค่แสดงรายการเครื่องมือ แต่เราจะเพิ่มมากขึ้นในไม่ช้า

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

นี่คือสิ่งที่เราเพิ่ม:

- แสดงรายการทรัพยากรและเครื่องมือและพิมพ์ออกมา สำหรับเครื่องมือเรายังแสดง `inputSchema` ซึ่งเราจะใช้ในภายหลัง

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

ในโค้ดข้างต้นเราได้:

- แสดงรายการเครื่องมือที่มีอยู่บนเซิร์ฟเวอร์ MCP
- สำหรับแต่ละเครื่องมือ แสดงชื่อ คำอธิบาย และโครงสร้างของมัน ซึ่งเราจะใช้เรียกเครื่องมือในไม่ช้า

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

ในโค้ดข้างต้นเราได้:

- สร้าง `McpToolProvider` ที่ค้นหาและลงทะเบียนเครื่องมือทั้งหมดจากเซิร์ฟเวอร์ MCP โดยอัตโนมัติ
- ตัวจัดหาเครื่องมือจัดการการแปลงระหว่างโครงสร้างเครื่องมือ MCP และรูปแบบเครื่องมือของ LangChain4j ภายใน
- วิธีนี้ช่วยลดกระบวนการแสดงรายการเครื่องมือและการแปลงด้วยตนเอง

#### Rust

การดึงเครื่องมือจากเซิร์ฟเวอร์ MCP ทำได้โดยใช้เมธอด `list_tools` ในฟังก์ชัน `main` ของคุณ หลังจากตั้งค่า MCP client ให้เพิ่มโค้ดต่อไปนี้:

```rust
// Get MCP tool listing 
let tools = mcp_client.list_tools(Default::default()).await?;
```

### -3- แปลงความสามารถของเซิร์ฟเวอร์เป็นเครื่องมือ LLM

ขั้นตอนถัดไปหลังจากแสดงรายการความสามารถของเซิร์ฟเวอร์คือการแปลงพวกมันให้อยู่ในรูปแบบที่ LLM เข้าใจ เมื่อเราทำเช่นนั้น เราสามารถให้ความสามารถเหล่านี้เป็นเครื่องมือแก่ LLM ได้

#### TypeScript

1. เพิ่มโค้ดต่อไปนี้เพื่อแปลงการตอบกลับจากเซิร์ฟเวอร์ MCP เป็นรูปแบบเครื่องมือที่ LLM สามารถใช้ได้:

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

    โค้ดด้านบนจะนำการตอบกลับจากเซิร์ฟเวอร์ MCP และแปลงเป็นรูปแบบการกำหนดเครื่องมือที่ LLM เข้าใจ

1. อัปเดตเมธอด `run` เพื่อแสดงรายการความสามารถของเซิร์ฟเวอร์:

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

    ในโค้ดข้างต้นเราได้อัปเดตเมธอด `run` เพื่อวนลูปผ่านผลลัพธ์และสำหรับแต่ละรายการเรียก `openAiToolAdapter`

#### Python

1. สร้างฟังก์ชันตัวแปลงต่อไปนี้:

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

    ในฟังก์ชัน `convert_to_llm_tools` ด้านบน เราแปลงการตอบกลับเครื่องมือ MCP เป็นรูปแบบที่ LLM เข้าใจ

1. อัปเดตโค้ดไคลเอนต์ของเราเพื่อใช้ฟังก์ชันนี้:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    ที่นี่เราเพิ่มการเรียก `convert_to_llm_tool` เพื่อแปลงการตอบกลับเครื่องมือ MCP เป็นสิ่งที่เราสามารถป้อนให้ LLM ได้ในภายหลัง

#### .NET

1. เพิ่มโค้ดเพื่อแปลงการตอบกลับเครื่องมือ MCP เป็นสิ่งที่ LLM เข้าใจ:

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

ในโค้ดข้างต้นเราได้:

- สร้างฟังก์ชัน `ConvertFrom` ที่รับชื่อ คำอธิบาย และโครงสร้างอินพุต
- กำหนดฟังก์ชันที่สร้าง FunctionDefinition ซึ่งจะถูกส่งไปยัง ChatCompletionsDefinition สิ่งหลังเป็นสิ่งที่ LLM เข้าใจ

1. อัปเดตโค้ดที่มีอยู่เพื่อใช้ประโยชน์จากฟังก์ชันนี้:

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

    ในโค้ดข้างต้นเราได้:

    - อัปเดตฟังก์ชันเพื่อแปลงการตอบกลับเครื่องมือ MCP เป็นเครื่องมือ LLM

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

ในโค้ดข้างต้นเราได้:

- กำหนดอินเทอร์เฟซ `Bot` อย่างง่ายสำหรับการโต้ตอบด้วยภาษาธรรมชาติ
- ใช้ `AiServices` ของ LangChain4j เพื่อผูก LLM กับตัวจัดหาเครื่องมือ MCP โดยอัตโนมัติ
- เฟรมเวิร์คจัดการการแปลงโครงสร้างเครื่องมือ MCP และการเรียกฟังก์ชันเบื้องหลัง
- วิธีนี้ช่วยลดความซับซ้อนของการแปลงเครื่องมือ MCP เป็นรูปแบบที่ LLM รองรับ

#### Rust

เพื่อแปลงการตอบกลับเครื่องมือ MCP เป็นรูปแบบที่ LLM เข้าใจ เราจะเพิ่มฟังก์ชันช่วยเหลือที่จัดรูปแบบรายการเครื่องมือ เพิ่มโค้ดต่อไปนี้ลงในไฟล์ `main.rs` ของคุณด้านล่างฟังก์ชัน `main` ซึ่งจะถูกเรียกเมื่อทำการร้องขอไปยัง LLM:

```rust
async fn format_tools(tools: &ListToolsResult) -> Result<Vec<Value>, Box<dyn Error>> {
    let tools_json = serde_json::to_value(tools)?;
    let Some(tools_array) = tools_json.get("tools").and_then(|t| t.as_array()) else {
        return Ok(vec![]);
    };

    let formatted_tools = tools_array
        .iter()
        .filter_map(|tool| {
            let name = tool.get("name")?.as_str()?;
            let description = tool.get("description")?.as_str()?;
            let schema = tool.get("inputSchema")?;

            Some(json!({
                "type": "function",
                "function": {
                    "name": name,
                    "description": description,
                    "parameters": {
                        "type": "object",
                        "properties": schema.get("properties").unwrap_or(&json!({})),
                        "required": schema.get("required").unwrap_or(&json!([]))
                    }
                }
            }))
        })
        .collect();

    Ok(formatted_tools)
}
```

ดีมาก ตอนนี้เราพร้อมที่จะจัดการคำขอของผู้ใช้แล้ว ลองทำในขั้นตอนถัดไป

### -4- จัดการคำขอคำสั่งของผู้ใช้

ในส่วนนี้ของโค้ด เราจะจัดการคำขอของผู้ใช้

#### TypeScript

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

    ในโค้ดข้างต้นเราได้:

    - เพิ่มเมธอด `callTools`
    - เมธอดนี้รับการตอบกลับจาก LLM และตรวจสอบว่าเครื่องมือใดถูกเรียกหรือไม่:

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

1. อัปเดตเมธอด `run` เพื่อรวมการเรียก LLM และการเรียก `callTools`:

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

ดีมาก ลองแสดงโค้ดทั้งหมด:

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

1. เพิ่ม imports ที่จำเป็นสำหรับการเรียก LLM:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. เพิ่มฟังก์ชันที่เรียก LLM:

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

    ในโค้ดข้างต้นเราได้:

    - ส่งฟังก์ชันของเรา ซึ่งเราพบในเซิร์ฟเวอร์ MCP และแปลงแล้ว ไปยัง LLM
    - จากนั้นเราเรียก LLM ด้วยฟังก์ชันดังกล่าว
    - จากนั้นเราตรวจสอบผลลัพธ์เพื่อดูว่าควรเรียกฟังก์ชันใดหรือไม่
    - สุดท้าย เราส่งอาร์เรย์ของฟังก์ชันที่ต้องเรียก

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

    ในโค้ดด้านบนเราได้:

    - เรียกเครื่องมือ MCP ผ่าน `call_tool` โดยใช้ฟังก์ชันที่ LLM คิดว่าควรเรียกตามคำสั่งของเรา
    - พิมพ์ผลลัพธ์ของการเรียกเครื่องมือไปยังเซิร์ฟเวอร์ MCP

#### .NET

1. แสดงโค้ดสำหรับการร้องขอคำสั่ง LLM:

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

    ในโค้ดข้างต้นเราได้:

    - ดึงเครื่องมือจากเซิร์ฟเวอร์ MCP `var tools = await GetMcpTools()`
    - กำหนดคำสั่งผู้ใช้ `userMessage`
    - สร้างอ็อปชันที่ระบุโมเดลและเครื่องมือ
    - ทำการร้องขอไปยัง LLM

1. ขั้นตอนสุดท้าย ดูว่า LLM คิดว่าเราควรเรียกฟังก์ชันหรือไม่:

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

    ในโค้ดข้างต้นเราได้:

    - วนลูปผ่านรายการการเรียกฟังก์ชัน
    - สำหรับแต่ละการเรียกเครื่องมือ แยกชื่อและอาร์กิวเมนต์ออก และเรียกเครื่องมือบนเซิร์ฟเวอร์ MCP โดยใช้ MCP client สุดท้ายเราพิมพ์ผลลัพธ์

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

ในโค้ดข้างต้นเราได้:

- ใช้คำสั่งภาษาธรรมชาติอย่างง่ายเพื่อโต้ตอบกับเครื่องมือเซิร์ฟเวอร์ MCP
- เฟรมเวิร์ค LangChain4j จัดการ:
  - การแปลงคำสั่งผู้ใช้เป็นการเรียกเครื่องมือเมื่อจำเป็น
  - การเรียกเครื่องมือ MCP ที่เหมาะสมตามการตัดสินใจของ LLM
  - การจัดการ flow การสนทนาระหว่าง LLM และเซิร์ฟเวอร์ MCP
- เมธอด `bot.chat()` ส่งคืนการตอบกลับภาษาธรรมชาติที่อาจรวมถึงผลลัพธ์จากการเรียกเครื่องมือ MCP
- วิธีนี้มอบประสบการณ์การใช้งานที่ราบรื่นซึ่งผู้ใช้ไม่จำเป็นต้องรู้เกี่ยวกับการใช้งาน MCP ที่อยู่เบื้องหลัง

ตัวอย่างโค้ดทั้งหมด:

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

#### Rust

นี่คือจุดที่งานส่วนใหญ่เกิดขึ้น เราจะเรียก LLM ด้วยคำสั่งผู้ใช้เริ่มต้น จากนั้นประมวลผลการตอบกลับเพื่อดูว่ามีเครื่องมือใดที่ต้องเรียกหรือไม่ หากมี เราจะเรียกเครื่องมือเหล่านั้นและดำเนินการสนทนากับ LLM จนกว่าจะไม่มีการเรียกเครื่องมือเพิ่มเติมและเราได้คำตอบสุดท้าย
เราจะทำการเรียก LLM หลายครั้ง ดังนั้นให้เรากำหนดฟังก์ชันที่จะจัดการการเรียก LLM เพิ่มฟังก์ชันต่อไปนี้ลงในไฟล์ `main.rs` ของคุณ:

```rust
async fn call_llm(
    client: &Client<OpenAIConfig>,
    messages: &[Value],
    tools: &ListToolsResult,
) -> Result<Value, Box<dyn Error>> {
    let response = client
        .completions()
        .create_byot(json!({
            "messages": messages,
            "model": "openai/gpt-4.1",
            "tools": format_tools(tools).await?,
        }))
        .await?;
    Ok(response)
}
```

ฟังก์ชันนี้รับข้อมูลจาก LLM client, รายการข้อความ (รวมถึงข้อความที่ผู้ใช้ป้อน), เครื่องมือจาก MCP server และส่งคำขอไปยัง LLM โดยจะคืนค่าการตอบกลับ

การตอบกลับจาก LLM จะมีอาร์เรย์ของ `choices` เราจำเป็นต้องประมวลผลผลลัพธ์เพื่อดูว่ามี `tool_calls` อยู่หรือไม่ ซึ่งจะช่วยให้เราทราบว่า LLM กำลังร้องขอให้เรียกใช้เครื่องมือเฉพาะพร้อมกับอาร์กิวเมนต์ เพิ่มโค้ดต่อไปนี้ลงในส่วนท้ายของไฟล์ `main.rs` เพื่อกำหนดฟังก์ชันสำหรับจัดการการตอบกลับของ LLM:

```rust
async fn process_llm_response(
    llm_response: &Value,
    mcp_client: &RunningService<RoleClient, ()>,
    openai_client: &Client<OpenAIConfig>,
    mcp_tools: &ListToolsResult,
    messages: &mut Vec<Value>,
) -> Result<(), Box<dyn Error>> {
    let Some(message) = llm_response
        .get("choices")
        .and_then(|c| c.as_array())
        .and_then(|choices| choices.first())
        .and_then(|choice| choice.get("message"))
    else {
        return Ok(());
    };

    // Print content if available
    if let Some(content) = message.get("content").and_then(|c| c.as_str()) {
        println!("🤖 {}", content);
    }

    // Handle tool calls
    if let Some(tool_calls) = message.get("tool_calls").and_then(|tc| tc.as_array()) {
        messages.push(message.clone()); // Add assistant message

        // Execute each tool call
        for tool_call in tool_calls {
            let (tool_id, name, args) = extract_tool_call_info(tool_call)?;
            println!("⚡ Calling tool: {}", name);

            let result = mcp_client
                .call_tool(CallToolRequestParam {
                    name: name.into(),
                    arguments: serde_json::from_str::<Value>(&args)?.as_object().cloned(),
                })
                .await?;

            // Add tool result to messages
            messages.push(json!({
                "role": "tool",
                "tool_call_id": tool_id,
                "content": serde_json::to_string_pretty(&result)?
            }));
        }

        // Continue conversation with tool results
        let response = call_llm(openai_client, messages, mcp_tools).await?;
        Box::pin(process_llm_response(
            &response,
            mcp_client,
            openai_client,
            mcp_tools,
            messages,
        ))
        .await?;
    }
    Ok(())
}
```

หากมี `tool_calls` อยู่ จะทำการดึงข้อมูลเครื่องมือ เรียก MCP server ด้วยคำขอเครื่องมือ และเพิ่มผลลัพธ์ลงในข้อความสนทนา จากนั้นจะดำเนินการสนทนาต่อกับ LLM และข้อความจะถูกอัปเดตด้วยการตอบกลับของผู้ช่วยและผลลัพธ์จากการเรียกใช้เครื่องมือ

เพื่อดึงข้อมูลการเรียกใช้เครื่องมือที่ LLM ส่งกลับมาสำหรับการเรียก MCP เราจะเพิ่มฟังก์ชันช่วยเหลืออีกตัวเพื่อดึงข้อมูลทุกอย่างที่จำเป็นสำหรับการเรียกใช้ เพิ่มโค้ดต่อไปนี้ลงในส่วนท้ายของไฟล์ `main.rs`:

```rust
fn extract_tool_call_info(tool_call: &Value) -> Result<(String, String, String), Box<dyn Error>> {
    let tool_id = tool_call
        .get("id")
        .and_then(|id| id.as_str())
        .unwrap_or("")
        .to_string();
    let function = tool_call.get("function").ok_or("Missing function")?;
    let name = function
        .get("name")
        .and_then(|n| n.as_str())
        .unwrap_or("")
        .to_string();
    let args = function
        .get("arguments")
        .and_then(|a| a.as_str())
        .unwrap_or("{}")
        .to_string();
    Ok((tool_id, name, args))
}
```

เมื่อทุกส่วนพร้อมแล้ว เราสามารถจัดการข้อความเริ่มต้นของผู้ใช้และเรียก LLM ได้ อัปเดตฟังก์ชัน `main` ของคุณเพื่อรวมโค้ดต่อไปนี้:

```rust
// LLM conversation with tool calls
let response = call_llm(&openai_client, &messages, &tools).await?;
process_llm_response(
    &response,
    &mcp_client,
    &openai_client,
    &tools,
    &mut messages,
)
.await?;
```

โค้ดนี้จะทำการสอบถาม LLM ด้วยข้อความเริ่มต้นของผู้ใช้ที่ถามหาผลรวมของตัวเลขสองตัว และจะประมวลผลการตอบกลับเพื่อจัดการการเรียกใช้เครื่องมือแบบไดนามิก

เยี่ยมมาก คุณทำสำเร็จแล้ว!

## งานที่ได้รับมอบหมาย

นำโค้ดจากแบบฝึกหัดนี้และสร้างเซิร์ฟเวอร์ที่มีเครื่องมือเพิ่มเติม จากนั้นสร้าง client ที่มี LLM เหมือนในแบบฝึกหัด และทดสอบด้วยข้อความที่แตกต่างกันเพื่อให้แน่ใจว่าเครื่องมือทั้งหมดของเซิร์ฟเวอร์ของคุณถูกเรียกใช้งานแบบไดนามิก วิธีการสร้าง client แบบนี้จะช่วยให้ผู้ใช้ได้รับประสบการณ์ที่ดีขึ้น เนื่องจากพวกเขาสามารถใช้ข้อความแทนคำสั่ง client ที่แน่นอน และไม่ต้องรับรู้ถึง MCP server ที่ถูกเรียกใช้งาน

## วิธีแก้ไข

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## สิ่งสำคัญที่ควรทราบ

- การเพิ่ม LLM ลงใน client ของคุณช่วยให้ผู้ใช้สามารถโต้ตอบกับ MCP Servers ได้ดีขึ้น
- คุณจำเป็นต้องแปลงการตอบกลับของ MCP Server ให้เป็นสิ่งที่ LLM เข้าใจได้

## ตัวอย่าง

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)
- [Rust Calculator](../../../../03-GettingStarted/samples/rust)

## แหล่งข้อมูลเพิ่มเติม

## ขั้นตอนถัดไป

- ถัดไป: [การใช้งานเซิร์ฟเวอร์ด้วย Visual Studio Code](../04-vscode/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้การแปลมีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาดั้งเดิมควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลภาษาจากผู้เชี่ยวชาญที่เป็นมนุษย์ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดซึ่งเกิดจากการใช้การแปลนี้