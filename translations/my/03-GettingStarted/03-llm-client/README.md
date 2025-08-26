<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
  "translation_date": "2025-08-19T18:52:40+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "my"
}
-->
# LLM အသုံးပြု၍ Client တစ်ခု ဖန်တီးခြင်း

ယခုအချိန်အထိ သင်သည် Server နှင့် Client တစ်ခုကို ဖန်တီးပုံကို ကြည့်ရှုခဲ့ပါပြီ။ Client သည် Server ကို Tools, Resources နှင့် Prompts များကို ဖော်ပြရန် တိုက်ရိုက်ခေါ်ဆိုနိုင်ခဲ့သည်။ သို့သော်၊ ဤနည်းလမ်းသည် အလွယ်တကူ အသုံးပြုနိုင်သော နည်းလမ်းမဟုတ်ပါ။ သင့်အသုံးပြုသူသည် Agentic Era တွင် နေထိုင်ပြီး Prompts များကို အသုံးပြုရန်နှင့် LLM နှင့် ဆက်သွယ်ရန် မျှော်လင့်ထားသည်။ သင့်အသုံးပြုသူအတွက် MCP ကို အသုံးပြု၍ သင့်စွမ်းရည်များကို သိမ်းဆည်းထားသည်ဟု မသက်ဆိုင်သော်လည်း သဘာဝဘာသာစကားကို အသုံးပြု၍ ဆက်သွယ်နိုင်ရန် မျှော်လင့်ထားသည်။ ထို့ကြောင့် ဤပြဿနာကို မည်သို့ ဖြေရှင်းမည်နည်း။ ဖြေရှင်းချက်မှာ Client တွင် LLM ကို ထည့်သွင်းခြင်းဖြစ်သည်။

## အကျဉ်းချုပ်

ဤသင်ခန်းစာတွင် Client တွင် LLM ကို ထည့်သွင်းခြင်းနှင့် သင့်အသုံးပြုသူအတွက် ပိုမိုကောင်းမွန်သော အတွေ့အကြုံကို ပေးနိုင်ပုံကို အဓိကထားဆွေးနွေးပါမည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာ၏ အဆုံးတွင် သင်သည် အောက်ပါအရာများကို လုပ်ဆောင်နိုင်မည်ဖြစ်သည်-

- LLM ပါဝင်သော Client တစ်ခု ဖန်တီးခြင်း။
- MCP Server နှင့် LLM ကို အသုံးပြု၍ ချောမွေ့စွာ ဆက်သွယ်ခြင်း။
- Client ဘက်တွင် အသုံးပြုသူအတွက် ပိုမိုကောင်းမွန်သော အတွေ့အကြုံ ပေးခြင်း။

## နည်းလမ်း

ကျွန်ုပ်တို့ လိုက်နာရမည့် နည်းလမ်းကို နားလည်ကြည့်ပါစို့။ LLM ကို ထည့်သွင်းခြင်းသည် ရိုးရှင်းသလို ထင်ရနိုင်သော်လည်း အမှန်တကယ် လုပ်ဆောင်မည်မှာ မည်သို့ဖြစ်မည်နည်း။

Client သည် Server နှင့် မည်သို့ ဆက်သွယ်မည်ကို အောက်ပါအတိုင်း ဖော်ပြထားသည်-

1. Server နှင့် ချိတ်ဆက်မှု တည်ဆောက်ပါ။

1. စွမ်းရည်များ၊ Prompts များ၊ Resources များနှင့် Tools များကို ဖော်ပြပြီး ၎င်းတို့၏ Schema ကို သိမ်းဆည်းပါ။

1. LLM ကို ထည့်သွင်းပြီး သိမ်းဆည်းထားသော စွမ်းရည်များနှင့် ၎င်းတို့၏ Schema ကို LLM နားလည်နိုင်သော Format ဖြင့် ပေးပို့ပါ။

1. အသုံးပြုသူ၏ Prompt ကို LLM သို့ ပေးပို့ပြီး Client မှ ဖော်ပြထားသော Tools များနှင့်အတူ ပေးပို့ပါ။

အဆင့်မြင့်အနေဖြင့် ဤနည်းလမ်းကို နားလည်ပြီးပါပြီ၊ အောက်ပါ လေ့ကျင့်ခန်းတွင် စမ်းသပ်ကြည့်ပါစို့။

## လေ့ကျင့်ခန်း- LLM ပါဝင်သော Client တစ်ခု ဖန်တီးခြင်း

ဤလေ့ကျင့်ခန်းတွင် Client တွင် LLM ကို ထည့်သွင်းပုံကို သင်ယူပါမည်။

### GitHub Personal Access Token အသုံးပြု၍ Authentication ပြုလုပ်ခြင်း

GitHub Token တစ်ခု ဖန်တီးခြင်းသည် ရိုးရှင်းသော လုပ်ငန်းစဉ်ဖြစ်သည်။ အောက်ပါအတိုင်း လုပ်ဆောင်နိုင်သည်-

- GitHub Settings သို့ သွားပါ – အပေါ်ယံညာဘက်ရှိ သင့်ပရိုဖိုင်ပုံကို နှိပ်ပြီး Settings ကို ရွေးပါ။
- Developer Settings သို့ သွားပါ – အောက်သို့ စာရွက်လှိမ့်ပြီး Developer Settings ကို နှိပ်ပါ။
- Personal Access Tokens ကို ရွေးပါ – Personal access tokens ကို နှိပ်ပြီး Generate new token ကို ရွေးပါ။
- သင့် Token ကို Configure လုပ်ပါ – မှတ်စုတစ်ခု ထည့်ပါ၊ သက်တမ်းကုန်ဆုံးရက်ကို သတ်မှတ်ပါ၊ လိုအပ်သော Scopes (Permissions) များကို ရွေးပါ။
- Token ကို Generate လုပ်ပြီး Copy လုပ်ပါ – Generate token ကို နှိပ်ပြီး ချက်ချင်း Copy လုပ်ပါ၊ ပြန်လည်ကြည့်ရှုနိုင်မည်မဟုတ်ပါ။

### -1- Server နှင့် ချိတ်ဆက်ပါ

အရင်ဆုံး Client ကို ဖန်တီးပါ-

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
- Client နှင့် LLM တစ်ခုနှင့် ဆက်သွယ်ရန် အကူအညီပေးမည့် `client` နှင့် `openai` ဆိုသော Members နှစ်ခုပါဝင်သော Class တစ်ခု ဖန်တီးထားသည်။
- GitHub Models ကို အသုံးပြုရန် LLM Instance ကို Configure လုပ်ထားပြီး `baseUrl` ကို inference API သို့ ညွှန်းထားသည်။

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

အရင်ဆုံး `pom.xml` ဖိုင်တွင် LangChain4j Dependencies များ ထည့်သွင်းရန် လိုအပ်သည်။ MCP Integration နှင့် GitHub Models ကို Support ပြုလုပ်ရန် Dependencies များ ထည့်သွင်းပါ-

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

- **LangChain4j Dependencies များ ထည့်သွင်းထားသည်**: MCP Integration, OpenAI Official Client နှင့် GitHub Models Support အတွက် လိုအပ်သည်။
- **LangChain4j Libraries များ Import လုပ်ထားသည်**: MCP Integration နှင့် OpenAI Chat Model Functionality အတွက်။
- **`ChatLanguageModel` တစ်ခု ဖန်တီးထားသည်**: GitHub Token ဖြင့် GitHub Models ကို အသုံးပြုရန် Configure လုပ်ထားသည်။
- **HTTP Transport ကို Set Up လုပ်ထားသည်**: Server-Sent Events (SSE) ကို အသုံးပြု၍ MCP Server နှင့် ချိတ်ဆက်ရန်။
- **MCP Client တစ်ခု ဖန်တီးထားသည်**: Server နှင့် ဆက်သွယ်မှုကို Handle လုပ်ရန်။
- **LangChain4j ရဲ့ Built-in MCP Support ကို အသုံးပြုထားသည်**: LLMs နှင့် MCP Servers အကြား Integration ကို ရိုးရှင်းစွာ ပြုလုပ်ရန်။

#### Rust

ဤဥပမာသည် Rust အခြေခံ MCP Server တစ်ခု ရှိသည်ဟု သတ်မှတ်ထားသည်။ MCP Server မရှိပါက [01-first-server](../01-first-server/README.md) သင်ခန်းစာကို ပြန်လည်ကြည့်ရှု၍ Server ကို ဖန်တီးပါ။

Rust MCP Server ရှိပြီးပါက Terminal ကို ဖွင့်ပြီး Server ရှိ Directory သို့ သွားပါ။ ထို့နောက် LLM Client Project အသစ်တစ်ခု ဖန်တီးရန် အောက်ပါ Command ကို Run လုပ်ပါ-

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

`Cargo.toml` ဖိုင်တွင် အောက်ပါ Dependencies များ ထည့်သွင်းပါ-

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> OpenAI အတွက် တရားဝင် Rust Library မရှိသော်လည်း၊ `async-openai` crate သည် [Community Maintained Library](https://platform.openai.com/docs/libraries/rust#rust) တစ်ခုဖြစ်ပြီး အများအားဖြင့် အသုံးပြုနေသည်။

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

ဤ Code သည် MCP Server နှင့် GitHub Models သို့ ချိတ်ဆက်ရန် Rust Application အခြေခံကို Set Up လုပ်ပေးသည်။

> [!IMPORTANT]
> Application ကို Run လုပ်မီ `OPENAI_API_KEY` Environment Variable ကို GitHub Token ဖြင့် Set လုပ်ထားရန် သေချာပါ။

အဆင့်မြှင့်အနေဖြင့် Server ရှိ စွမ်းရည်များကို List လုပ်ပါမည်။
အောက်ပါ Markdown ဖိုင်ကို မြန်မာဘာသာဖြင့် ဘာသာပြန်ထားသည် -

ကျွန်တော်တို့ LLM ကို ခေါ်ယူမည့်လုပ်ငန်းစဉ်ကို စီမံခန့်ခွဲရန် function တစ်ခုကို သတ်မှတ်လိုက်ပါ။ အောက်ပါ function ကို သင့် `main.rs` ဖိုင်ထဲတွင် ထည့်သွင်းပါ။

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

ဒီ function က LLM client, user prompt ပါဝင်တဲ့ messages စာရင်း, MCP server မှ tools ကို ယူပြီး LLM ကို request ပေးပြီး response ကို ပြန်လည်ရရှိစေပါသည်။

LLM response မှာ `choices` အ array ပါဝင်မည်ဖြစ်ပြီး၊ `tool_calls` ရှိမရှိကို စစ်ဆေးရန် လိုအပ်ပါသည်။ ဒါက LLM က tools တစ်ခုကို arguments ဖြင့် ခေါ်ယူရန် တောင်းဆိုနေသည်ကို သိနိုင်စေပါသည်။ LLM response ကို စီမံခန့်ခွဲရန် function တစ်ခုကို သတ်မှတ်ရန် အောက်ပါ code ကို သင့် `main.rs` ဖိုင်အောက်ဆုံးတွင် ထည့်သွင်းပါ။

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

`tool_calls` ရှိပါက၊ tool အချက်အလက်များကို ထုတ်ယူပြီး MCP server ကို tool request ဖြင့် ခေါ်ယူပါသည်။ ထို့နောက် conversation messages တွင် result များကို ထည့်သွင်းပြီး LLM နှင့် ဆက်လက်ပြောဆိုပါသည်။ assistant response နှင့် tool call results များကို messages တွင် update လုပ်ပါသည်။

LLM response မှ MCP calls အတွက် tool call အချက်အလက်များကို ထုတ်ယူရန် helper function တစ်ခုကို ထည့်သွင်းပါ။ အောက်ပါ code ကို သင့် `main.rs` ဖိုင်အောက်ဆုံးတွင် ထည့်သွင်းပါ။

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

အပိုင်းအားလုံး ပြည့်စုံပြီးနောက်၊ user prompt ကို စီမံခန့်ခွဲပြီး LLM ကို ခေါ်ယူနိုင်ပါသည်။ သင့် `main` function ကို အောက်ပါ code ဖြင့် update လုပ်ပါ။

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

ဒီ code က user prompt ကို LLM ကို query လုပ်ပြီး tool calls များကို dynamic အနေဖြင့် handle လုပ်ပါသည်။

အောင်မြင်ပါပြီ၊ သင်လုပ်နိုင်ပါပြီ!

## လုပ်ငန်းတာဝန်

Exercise မှ code ကို ယူပြီး server ကို tools များဖြင့် တိုးချဲ့ပါ။ ထို့နောက် LLM ပါဝင်သော client တစ်ခုကို ဖန်တီးပြီး server tools များကို dynamic အနေဖြင့် ခေါ်ယူနိုင်မှုကို စမ်းသပ်ပါ။ ဒီ client ဖန်တီးနည်းက end user အတွက် အလွန်ကောင်းမွန်သော အသုံးပြုမှုအတွေ့အကြုံကို ပေးနိုင်ပြီး၊ MCP server ကို ခေါ်ယူနေသည်ကို user မသိစေရန် prompt များကို အသုံးပြုနိုင်စေပါသည်။

## ဖြေရှင်းချက်

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## အဓိကအချက်များ

- သင့် client တွင် LLM ကို ထည့်သွင်းခြင်းက MCP Servers နှင့် ပိုမိုကောင်းမွန်သော အသုံးပြုမှုအတွေ့အကြုံကို ပေးနိုင်သည်။
- MCP Server response ကို LLM နားလည်နိုင်သော အရာတစ်ခုအဖြစ် ပြောင်းလဲရန် လိုအပ်သည်။

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
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။