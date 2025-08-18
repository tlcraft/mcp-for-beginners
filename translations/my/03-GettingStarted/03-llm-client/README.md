<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
  "translation_date": "2025-08-18T18:53:58+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "my"
}
-->
# LLM အသုံးပြု၍ Client တစ်ခု ဖန်တီးခြင်း

ယခုအချိန်အထိ သင်သည် Server နှင့် Client တစ်ခုကို ဖန်တီးပုံကို ကြည့်ရှုခဲ့ပါပြီ။ Client သည် Server ကို တိုက်ရိုက်ခေါ်ဆိုပြီး Tools, Resources, နှင့် Prompts များကို စာရင်းပြုစုနိုင်ခဲ့သည်။ သို့သော်၊ ဤနည်းလမ်းသည် အလွယ်တကူအသုံးပြုနိုင်သော နည်းလမ်းမဟုတ်ပါ။ သင့်အသုံးပြုသူသည် Agentic Era တွင် နေထိုင်ပြီး Prompts များကို အသုံးပြုကာ LLM နှင့် ဆက်သွယ်ရန် မျှော်မှန်းထားသည်။ သင့်အသုံးပြုသူအတွက် MCP ကို အသုံးပြု၍ သင့်စွမ်းရည်များကို သိမ်းဆည်းထားသည်ဟု မသက်ဆိုင်သော်လည်း သဘာဝဘာသာစကားကို အသုံးပြု၍ ဆက်သွယ်နိုင်ရန် မျှော်လင့်ထားသည်။ ထို့ကြောင့် ဤပြဿနာကို မည်သို့ ဖြေရှင်းမည်နည်း။ ဖြေရှင်းချက်မှာ Client တွင် LLM ကို ထည့်သွင်းခြင်းဖြစ်သည်။

## အကျဉ်းချုပ်

ဤသင်ခန်းစာတွင် Client တွင် LLM ကို ထည့်သွင်းခြင်းနှင့် သင့်အသုံးပြုသူအတွက် ပိုမိုကောင်းမွန်သော အတွေ့အကြုံကို ပေးနိုင်ပုံကို အဓိကထားဆွေးနွေးပါမည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာ၏ နောက်ဆုံးတွင် သင်သည် အောက်ပါအရာများကို လုပ်ဆောင်နိုင်မည်ဖြစ်သည်-

- LLM ပါဝင်သော Client တစ်ခု ဖန်တီးနိုင်ခြင်း။
- MCP Server နှင့် LLM ကို အသုံးပြု၍ အဆင်ပြေစွာ ဆက်သွယ်နိုင်ခြင်း။
- Client ဘက်တွင် အသုံးပြုသူအတွက် ပိုမိုကောင်းမွန်သော အတွေ့အကြုံ ပေးနိုင်ခြင်း။

## လုပ်ဆောင်ရန် နည်းလမ်း

ကျွန်ုပ်တို့ လိုက်နာရမည့် နည်းလမ်းကို နားလည်ကြည့်ရှုကြပါစို့။ LLM ကို ထည့်သွင်းခြင်းသည် ရိုးရှင်းသလို ထင်ရနိုင်သော်လည်း အမှန်တကယ် လုပ်ဆောင်ရမည့်အရာများမှာ မည်သို့ဖြစ်မည်နည်း။

Client သည် Server နှင့် မည်သို့ ဆက်သွယ်မည်ဆိုသည်မှာ-

1. Server နှင့် ချိတ်ဆက်မှု တည်ဆောက်ပါ။

1. စွမ်းရည်များ၊ Prompts များ၊ Resources များနှင့် Tools များကို စာရင်းပြုစုပြီး ၎င်းတို့၏ Schema ကို သိမ်းဆည်းပါ။

1. LLM ကို ထည့်သွင်းပြီး သိမ်းဆည်းထားသော စွမ်းရည်များနှင့် ၎င်းတို့၏ Schema ကို LLM နားလည်နိုင်သော Format ဖြင့် ပေးပို့ပါ။

1. အသုံးပြုသူ၏ Prompt ကို LLM သို့ ပေးပို့ပြီး Client မှ စာရင်းပြုစုထားသော Tools များနှင့်အတူ ပေးပို့ပါ။

အကောင်းဆုံး၊ ကျွန်ုပ်တို့သည် အဆင့်မြင့်အနေဖြင့် မည်သို့လုပ်ဆောင်ရမည်ကို နားလည်ခဲ့ပြီဖြစ်သည်။ အောက်ပါ လေ့ကျင့်ခန်းတွင် စမ်းသပ်ကြည့်ရအောင်။

## လေ့ကျင့်ခန်း- LLM ပါဝင်သော Client တစ်ခု ဖန်တီးခြင်း

ဤလေ့ကျင့်ခန်းတွင် Client တွင် LLM ကို ထည့်သွင်းပုံကို သင်ယူပါမည်။

### GitHub Personal Access Token အသုံးပြု၍ Authentication

GitHub Token တစ်ခု ဖန်တီးခြင်းသည် ရိုးရှင်းသော လုပ်ငန်းစဉ်တစ်ခုဖြစ်သည်။ ဤအတိုင်းလုပ်ဆောင်ပါ-

- GitHub Settings သို့ သွားပါ – အပေါ်ယာဉ်ထောင့်ရှိ သင့်ပရိုဖိုင်ပုံကို နှိပ်ပြီး Settings ကို ရွေးပါ။
- Developer Settings သို့ သွားပါ – အောက်သို့ Scroll လုပ်ပြီး Developer Settings ကို နှိပ်ပါ။
- Personal Access Tokens ကို ရွေးပါ – Personal access tokens ကို နှိပ်ပြီး Generate new token ကို ရွေးပါ။
- သင့် Token ကို Configure လုပ်ပါ – မှတ်စုတစ်ခု ထည့်ပါ၊ သက်တမ်းကုန်ဆုံးရက်ကို သတ်မှတ်ပါ၊ လိုအပ်သော Scopes (Permissions) များကို ရွေးပါ။
- Token ကို Generate လုပ်ပြီး Copy လုပ်ပါ – Generate token ကို နှိပ်ပြီး ချက်ချင်း Copy လုပ်ပါ။ ထို့နောက် ၎င်းကို ထပ်မကြည့်နိုင်တော့ပါ။

### -1- Server နှင့် ချိတ်ဆက်ပါ

အရင်ဆုံး Client ကို ဖန်တီးကြည့်ရအောင်-

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

အထက်ပါ Code တွင်-

- လိုအပ်သော Libraries များ Import လုပ်ထားသည်။
- Client နှင့် LLM တစ်ခုနှင့် ဆက်သွယ်ရန် ကူညီမည့် `client` နှင့် `openai` ဆိုသော Members နှစ်ခုပါဝင်သော Class တစ်ခု ဖန်တီးထားသည်။
- GitHub Models ကို အသုံးပြုရန် `baseUrl` ကို Inference API သို့ ညွှန်ထားပြီး LLM Instance ကို Configure လုပ်ထားသည်။

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

အထက်ပါ Code တွင်-

- MCP အတွက် လိုအပ်သော Libraries များ Import လုပ်ထားသည်။
- Client တစ်ခု ဖန်တီးထားသည်။

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

အရင်ဆုံး LangChain4j Dependencies များကို `pom.xml` ဖိုင်တွင် ထည့်သွင်းရန် လိုအပ်ပါမည်။ MCP Integration နှင့် GitHub Models ကို Support လုပ်ရန် Dependencies များကို ထည့်သွင်းပါ-

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

ထို့နောက် Java Client Class ကို ဖန်တီးပါ-

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

အထက်ပါ Code တွင်-

- **LangChain4j Dependencies များ ထည့်သွင်းထားသည်**: MCP Integration, OpenAI Official Client, နှင့် GitHub Models Support အတွက် လိုအပ်သည်။
- **LangChain4j Libraries များ Import လုပ်ထားသည်**: MCP Integration နှင့် OpenAI Chat Model Functionality အတွက်။
- **`ChatLanguageModel` တစ်ခု ဖန်တီးထားသည်**: GitHub Token ဖြင့် GitHub Models ကို အသုံးပြုရန် Configure လုပ်ထားသည်။
- **HTTP Transport ကို Set Up လုပ်ထားသည်**: Server-Sent Events (SSE) ကို အသုံးပြု၍ MCP Server နှင့် ချိတ်ဆက်ရန်။
- **MCP Client တစ်ခု ဖန်တီးထားသည်**: Server နှင့် ဆက်သွယ်မှုကို Handle လုပ်ရန်။
- **LangChain4j Built-in MCP Support ကို အသုံးပြုထားသည်**: LLMs နှင့် MCP Servers အကြား Integration ကို ရိုးရှင်းစေသည်။

#### Rust

ဤဥပမာသည် Rust အခြေခံ MCP Server တစ်ခု ရှိသည်ဟု သတ်မှတ်ထားသည်။ MCP Server မရှိပါက [01-first-server](../01-first-server/README.md) သင်ခန်းစာကို ပြန်လည်ကြည့်ရှု၍ Server ကို ဖန်တီးပါ။

Rust MCP Server ရှိပြီးပါက Terminal ကို ဖွင့်ပြီး Server ရှိ Directory သို့ သွားပါ။ ထို့နောက် LLM Client Project အသစ်တစ်ခု ဖန်တီးရန် အောက်ပါ Command ကို Run လုပ်ပါ-

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

`Cargo.toml` ဖိုင်တွင် အောက်ပါ Dependencies များကို ထည့်သွင်းပါ-

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> OpenAI အတွက် တရားဝင် Rust Library မရှိသေးပါ၊ သို့သော် `async-openai` crate သည် [Community Maintained Library](https://platform.openai.com/docs/libraries/rust#rust) တစ်ခုဖြစ်ပြီး အများအားဖြင့် အသုံးပြုနေသည်။

`src/main.rs` ဖိုင်ကို ဖွင့်ပြီး အောက်ပါ Code ဖြင့် ၎င်း၏ Content ကို အစားထိုးပါ-

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

ဤ Code သည် MCP Server နှင့် GitHub Models ကို LLM Interaction အတွက် ချိတ်ဆက်မည့် Rust Application အခြေခံကို Set Up လုပ်ထားသည်။

> [!IMPORTANT]
> Application ကို Run လုပ်မီ `OPENAI_API_KEY` Environment Variable ကို GitHub Token ဖြင့် Set လုပ်ထားပါ။

အကောင်းဆုံး၊ နောက်တစ်ဆင့်တွင် Server ရှိ စွမ်းရည်များကို စာရင်းပြုစုကြည့်ရအောင်။

### -2- Server စွမ်းရည်များ စာရင်းပြုစုခြင်း

ယခုအခါ Server နှင့် ချိတ်ဆက်ပြီး ၎င်း၏ စွမ်းရည်များကို မေးမြန်းကြည့်ရအောင်-

#### TypeScript

အတန်းတစ်ခုအတွင်း အောက်ပါ Methods များကို ထည့်သွင်းပါ-

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

အထက်ပါ Code တွင်-

- Server နှင့် ချိတ်ဆက်ရန် `connectToServer` ကို ထည့်သွင်းထားသည်။
- Tools များကို စာရင်းပြုစုရန် `run` Method တစ်ခု ဖန်တီးထားသည်။ ယခုအချိန်တွင် Tools များကိုသာ စာရင်းပြုစုထားပြီး နောက်ပိုင်းတွင် အခြား Functionality များကို ထည့်သွင်းမည်။

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

အထက်ပါ Code တွင်-

- Resources နှင့် Tools များကို စာရင်းပြုစုပြီး Print လုပ်ထားသည်။ Tools များအတွက် `inputSchema` ကိုလည်း စာရင်းပြုစုထားပြီး နောက်ပိုင်းတွင် အသုံးပြုမည်။

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

အထက်ပါ Code တွင်-

- MCP Server တွင် ရရှိနိုင်သော Tools များကို စာရင်းပြုစုထားသည်။
- Tool တစ်ခုစီအတွက် Name, Description, နှင့် Schema ကို စာရင်းပြုစုထားသည်။ Schema သည် နောက်ပိုင်းတွင် Tools များကို ခေါ်ဆိုရန် အသုံးပြုမည့် အရာဖြစ်သည်။

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

အထက်ပါ Code တွင်-

- `McpToolProvider` တစ်ခု ဖန်တီးထားပြီး MCP Server မှ Tools များကို အလိုအလျောက် ရှာဖွေပြီး Register လုပ်ထားသည်။
- Tool Provider သည် MCP Tool Schemas နှင့် LangChain4j Tool Format အကြား Conversion ကို အတွင်းပိုင်းတွင် Handle လုပ်ထားသည်။
- ဤနည်းလမ်းသည် Tool Listing နှင့် Conversion Process ကို Manual လုပ်ဆောင်ရန် မလိုအပ်စေသည်။

#### Rust

MCP Server မှ Tools များကို Retrieving လုပ်ရန် `list_tools` Method ကို အသုံးပြုပါ။ MCP Client ကို Set Up လုပ်ပြီးနောက် `main` Function တွင် အောက်ပါ Code ကို ထည့်သွင်းပါ-

```rust
// Get MCP tool listing 
let tools = mcp_client.list_tools(Default::default()).await?;
```

### -3- Server စွမ်းရည်များကို LLM Tools သို့ Convert လုပ်ခြင်း

Server စွမ်းရည်များကို LLM နားလည်နိုင်သော Format သို့ Convert လုပ်ရန် နောက်တစ်ဆင့်ဖြစ်သည်။ ၎င်းကို လုပ်ဆောင်ပြီးနောက် Tools များကို LLM သို့ ပေးပို့နိုင်မည်ဖြစ်သည်။

#### TypeScript

1. MCP Server Response ကို LLM နားလည်နိုင်သော Tool Definition Format သို့ Convert လုပ်ရန် အောက်ပါ Code ကို ထည့်သွင်းပါ-

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

    အထက်ပါ Code သည် MCP Server Response ကို LLM နားလည်နိုင်သော Tool Definition Format သို့ Convert လုပ်သည်။

1. `run` Method ကို Update လုပ်ပြီး Server စွမ်းရည်များကို စာရင်းပြုစုပါ-

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

    အထက်ပါ Code တွင် `run` Method ကို Update လုပ်ထားပြီး Result တစ်ခုစီအတွက် `openAiToolAdapter` ကို ခေါ်ဆိုထားသည်။

#### Python

1. Converter Function တစ်ခု ဖန်တီးပါ-

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

    အထက်ပါ Function `convert_to_llm_tools` တွင် MCP Tool Response ကို LLM နားလည်နိုင်သော Format သို့ Convert လုပ်ထားသည်။

1. Client Code ကို Update လုပ်ပြီး Function ကို အသုံးပြုပါ-

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    ဤနေရာတွင် MCP Tool Response ကို LLM သို့ Feed လုပ်ရန် Convert လုပ်ထားသည်။

#### .NET

1. MCP Tool Response ကို LLM နားလည်နိုင်သော Format သို့ Convert လုပ်ရန် Code ကို ထည့်သွင်းပါ-

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

အထက်ပါ Code တွင်-

- `ConvertFrom` Function တစ်ခု ဖန်တီးထားပြီး Name, Description, နှင့် Input Schema ကို လက်ခံထားသည်။
- FunctionDefinition တစ်ခု ဖန်တီးထားပြီး ChatCompletionsDefinition သို့ Pass လုပ်ထားသည်။ ChatCompletionsDefinition သည် LLM နားလည်နိုင်သော Format ဖြစ်သည်။

1. ရှိပြီးသား Code ကို Update လုပ်ပြီး Function ကို အသုံးပြုပါ-

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

    အထက်ပါ Code တွင် MCP Tool Response ကို LLM Tool သို့ Convert လုပ်ထားသည်။

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

အထက်ပါ Code တွင်-

- Natural Language Interaction အတွက် `Bot` Interface တစ်ခု ဖန်တီးထားသည်။
- LangChain4j Framework ကို အသုံးပြု၍ LLM နှင့် MCP Tool Provider ကို Bind လုပ်ထားသည်။
- Framework သည် MCP Tools ကို LLM-Compatible Format သို့ Convert လုပ်ခြင်းနှင့် Function Calling ကို အလိုအလျောက် Handle လုပ်ထားသည်။

#### Rust

MCP Tool Response ကို LLM နားလည်နိုင်သော Format သို့ Convert လုပ်ရန် Helper Function တစ်ခု ထည့်သွင်းပါ။ `main.rs` ဖိုင်တွင် `main` Function အောက်တွင် ထည့်သွင်းပါ-

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

အကောင်းဆုံး၊ ယခုအခါ User Requests ကို Handle လုပ်ရန် ပြုလုပ်ကြည့်ရအောင်။

### -4- User Prompt Request ကို Handle လုပ်ခြင်း

Code ၏ ဤအပိုင်းတွင် User Requests ကို Handle လုပ်ပါမည်။

#### TypeScript

1. LLM ကို ခေါ်ဆိုရန် အသုံးပြုမည့် Method တစ်ခု ထည့်သွင်းပါ-

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

    အထက်ပါ Code တွင်-

    - `callTools` Method ကို ထည့်သွင်းထားသည်။
    - LLM Response ကို Tools များကို ခေါ်ဆိုရန် လိုအပ်ချက်ရှိ/မရှိ စစ်ဆေးထားသည်။

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Tools များကို LLM မှ ခေါ်ဆိုရန် လိုအပ်ချက်ရှိပါက Tools ကို ခေါ်ဆိုထားသည်။

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

1. `run` Method ကို Update လုပ်ပြီး LLM ကို ခေါ်ဆိုပါ-

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

အကောင်းဆုံး၊ Code အပြည့်အစုံကို ကြည့်ရှုပါ-

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

1. LLM ကို ခေါ်ဆိုရန် လိုအပ်သော Imports များကို ထည့်သွင်းပါ-

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. LLM ကို ခေါ်ဆိုမည့် Function ကို ထည့်သွင်းပါ-

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

    အထက်ပါ Code တွင်-

    - MCP Server မှ ရရှိသော Functions များကို LLM သို့ Pass လုပ်ထားသည်။
    - Functions များကို LLM Response အရ ခေါ်ဆိုထားသည်။

1. Main Code ကို Update လုပ်ပါ-

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    အထက်ပါ Code တွင်-

    - MCP Server မှ Tools ကို LLM Response အရ ခေါ်ဆိုထားသည်။
    - Tool Call Result ကို Print လုပ်ထားသည်။

#### .NET

1. LLM Prompt Request ကို လုပ်ဆောင်ရန် Code ကို ထည့်သွင်းပါ-

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

    အထက်ပါ Code တွင်-

    - MCP Server မှ Tools များကို Fetch လုပ်ထားသည်။
    - User Prompt ကို သတ်မှတ်ထားသည်။
    - Model နှင့် Tools ကို Specify လုပ်ထားသည်။

1. LLM Response အရ Function Call လုပ်ရန် Code ကို ထည့်သွင်းပါ-

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

    အထက်ပါ Code တွင်-

    - Function Calls များကို Loop လုပ်ထားသည်။
    - MCP Server မှ Tools ကို MCP Client အသုံးပြု၍ ခေါ်ဆိုထားသည်။

Code အပြည့်အစုံ-

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

အထက်ပါ Code တွင်-

- Natural Language Prompts ကို အသုံးပြု၍ MCP Server Tools နှင့် ဆက်သွယ်ထားသည်။
- LangChain4j Framework သည် Tool Schema Conversion နှင့် Function Calling ကို အလိုအလျောက် Handle လုပ်ထားသည်။

Code အပြည့်အစုံ-

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

ဤနေရာတွင် အဓိကလုပ်ငန်းများကို ဆောင်ရွက်ပါမည်။ User Prompt ကို LLM သို့ ပေးပို့ပြီး Response ကို Process လုပ်ပါမည်။ Tools များကို ခေါ်ဆိုရန် လိုအပ်ပါက Tools များကို MCP Server မှ ခေါ်ဆိုပြီး Conversation
အောက်ပါ Markdown ဖိုင်ကို မြန်မာဘာသာဖြင့် ဘာသာပြန်ထားသည် -

---

ကျွန်တော်တို့ LLM ကို ခေါ်ယူမည့်အခါတွင် function တစ်ခုကို သတ်မှတ်လိုက်ရအောင်။ `main.rs` ဖိုင်ထဲတွင် အောက်ပါ function ကို ထည့်ပါ။

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

ဒီ function က LLM client, user prompt ပါဝင်တဲ့ messages စာရင်း, MCP server မှ tools ကို ယူပြီး LLM ကို request ပို့ပြီး response ကို ပြန်ပေးပါမည်။

LLM response မှာ `choices` array ပါဝင်မည်။ ဒီ result ကို process လုပ်ပြီး `tool_calls` ရှိမရှိ စစ်ဆေးရမည်။ ဒါက LLM က tools တစ်ခုကို arguments ဖြင့် ခေါ်ယူရန် တောင်းဆိုနေသည်ကို ပြသပါသည်။ LLM response ကို handle လုပ်ရန် function တစ်ခုကို သတ်မှတ်ရန် `main.rs` ဖိုင်အောက်ဆုံးတွင် အောက်ပါ code ကို ထည့်ပါ။

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

`tool_calls` ရှိပါက tool အချက်အလက်ကို extract လုပ်ပြီး MCP server ကို tool request ဖြင့် ခေါ်ယူပါမည်။ ပြီးလျှင် conversation messages တွင် result ကို ထည့်ပြီး LLM နှင့် ဆက်လက်ပြောဆိုပါမည်။ messages တွင် assistant response နှင့် tool call results ကို update လုပ်ပါမည်။

MCP calls အတွက် LLM response မှ tool call အချက်အလက်ကို extract လုပ်ရန် helper function တစ်ခုကို ထည့်ရန်လိုအပ်သည်။ အောက်ပါ code ကို `main.rs` ဖိုင်အောက်ဆုံးတွင် ထည့်ပါ။

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

အပိုင်းအားလုံး ပြည့်စုံပြီးနောက် user prompt ကို handle လုပ်ပြီး LLM ကို ခေါ်ယူနိုင်ပါပြီ။ `main` function ကို update လုပ်ပြီး အောက်ပါ code ကို ထည့်ပါ။

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

ဒီ code က user prompt ကို LLM ကို query လုပ်ပြီး tool calls ကို dynamic အနေနဲ့ handle လုပ်ပါမည်။

အောင်မြင်ပါပြီ!

## လုပ်ငန်းတာဝန်

Exercise မှ code ကို ယူပြီး server ကို tools များဖြင့် တိုးချဲ့ပါ။ ပြီးလျှင် LLM ပါဝင်တဲ့ client တစ်ခုကို ဖန်တီးပြီး prompts များကို အသုံးပြု၍ server tools များကို dynamic အနေနဲ့ ခေါ်ယူနိုင်မည်ဖြစ်ကြောင်း စမ်းသပ်ပါ။ ဒီ client ဖန်တီးနည်းက end user အတွက် အလွန်ကောင်းမွန်တဲ့ user experience ကို ပေးနိုင်ပါမည်။ သူတို့သည် prompts ကိုသာ အသုံးပြုနိုင်ပြီး MCP server ကို ခေါ်ယူနေသည်ကို မသိလိုက်ပါ။

## ဖြေရှင်းချက်

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## အဓိကအချက်များ

- Client တွင် LLM ကို ထည့်သွင်းခြင်းက MCP Servers နှင့် ပိုမိုကောင်းမွန်သော အပြန်အလှန် ဆက်သွယ်မှုကို ပေးနိုင်သည်။
- MCP Server response ကို LLM နားလည်နိုင်သော format သို့ ပြောင်းလဲရန် လိုအပ်သည်။

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)
- [Rust Calculator](../../../../03-GettingStarted/samples/rust)

## အပိုဆောင်းအရင်းအမြစ်များ

## နောက်တစ်ခု

- နောက်တစ်ခု: [Visual Studio Code ကို အသုံးပြု၍ server ကို အသုံးပြုခြင်း](../04-vscode/README.md)

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။