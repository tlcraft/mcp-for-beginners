<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
  "translation_date": "2025-08-18T14:17:17+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ur"
}
-->
# کلائنٹ کو LLM کے ساتھ بنانا

اب تک، آپ نے دیکھا کہ سرور اور کلائنٹ کیسے بنائے جاتے ہیں۔ کلائنٹ نے سرور کو واضح طور پر کال کر کے اس کے ٹولز، وسائل اور پرومٹس کی فہرست حاصل کی ہے۔ لیکن یہ طریقہ زیادہ عملی نہیں ہے۔ آپ کا صارف ایجنٹک دور میں رہتا ہے اور توقع کرتا ہے کہ وہ پرومٹس استعمال کرے اور LLM کے ساتھ بات چیت کرے۔ آپ کے صارف کو اس بات کی پرواہ نہیں ہوتی کہ آپ اپنی صلاحیتوں کو محفوظ کرنے کے لیے MCP استعمال کرتے ہیں یا نہیں، لیکن وہ قدرتی زبان کے ذریعے بات چیت کی توقع کرتے ہیں۔ تو ہم اس مسئلے کو کیسے حل کریں؟ حل یہ ہے کہ کلائنٹ میں LLM شامل کیا جائے۔

## جائزہ

اس سبق میں ہم کلائنٹ میں LLM شامل کرنے پر توجہ مرکوز کریں گے اور دکھائیں گے کہ یہ آپ کے صارف کے لیے کس طرح بہتر تجربہ فراہم کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے:

- LLM کے ساتھ کلائنٹ بنانا۔
- LLM کے ذریعے MCP سرور کے ساتھ بغیر کسی رکاوٹ کے بات چیت کرنا۔
- کلائنٹ سائیڈ پر صارف کے لیے بہتر تجربہ فراہم کرنا۔

## طریقہ کار

آئیے اس طریقہ کار کو سمجھنے کی کوشش کریں جو ہمیں اپنانا ہوگا۔ LLM شامل کرنا آسان لگتا ہے، لیکن کیا ہم واقعی ایسا کریں گے؟

یہاں کلائنٹ سرور کے ساتھ کیسے بات چیت کرے گا:

1. سرور کے ساتھ کنکشن قائم کریں۔

1. صلاحیتوں، پرومٹس، وسائل اور ٹولز کی فہرست بنائیں اور ان کی اسکیمہ محفوظ کریں۔

1. LLM شامل کریں اور محفوظ کردہ صلاحیتوں اور ان کی اسکیمہ کو ایسے فارمیٹ میں پاس کریں جو LLM سمجھ سکے۔

1. صارف کے پرومٹ کو ہینڈل کریں اور اسے LLM کے ساتھ کلائنٹ کے درج کردہ ٹولز کے ساتھ پاس کریں۔

زبردست، اب ہم سمجھ گئے کہ ہم یہ اعلیٰ سطح پر کیسے کر سکتے ہیں، آئیے نیچے دیے گئے مشق میں اسے آزما کر دیکھتے ہیں۔

## مشق: LLM کے ساتھ کلائنٹ بنانا

اس مشق میں، ہم اپنے کلائنٹ میں LLM شامل کرنا سیکھیں گے۔

### GitHub پرسنل ایکسیس ٹوکن کے ذریعے تصدیق

GitHub ٹوکن بنانا ایک سیدھا سا عمل ہے۔ یہاں یہ کیسے کیا جا سکتا ہے:

- GitHub سیٹنگز پر جائیں – اوپر دائیں کونے میں اپنی پروفائل تصویر پر کلک کریں اور سیٹنگز منتخب کریں۔
- ڈیولپر سیٹنگز پر جائیں – نیچے سکرول کریں اور ڈیولپر سیٹنگز پر کلک کریں۔
- پرسنل ایکسیس ٹوکن منتخب کریں – پرسنل ایکسیس ٹوکن پر کلک کریں اور نیا ٹوکن جنریٹ کریں۔
- اپنے ٹوکن کو کنفیگر کریں – حوالہ کے لیے ایک نوٹ شامل کریں، ایکسپائریشن ڈیٹ سیٹ کریں، اور ضروری اسکوپس (اجازتیں) منتخب کریں۔
- ٹوکن جنریٹ کریں اور کاپی کریں – جنریٹ ٹوکن پر کلک کریں، اور اسے فوراً کاپی کرنا یقینی بنائیں، کیونکہ آپ اسے دوبارہ نہیں دیکھ سکیں گے۔

### -1- سرور سے کنکشن قائم کریں

آئیے پہلے اپنا کلائنٹ بنائیں:

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

اوپر دیے گئے کوڈ میں ہم نے:

- ضروری لائبریریاں درآمد کیں۔
- ایک کلاس بنائی جس میں دو ممبرز ہیں، `client` اور `openai`، جو ہمیں کلائنٹ کو منظم کرنے اور LLM کے ساتھ بات چیت کرنے میں مدد دیں گے۔
- اپنے LLM انسٹینس کو GitHub ماڈلز استعمال کرنے کے لیے کنفیگر کیا، `baseUrl` کو انفیرنس API کی طرف اشارہ کرنے کے لیے سیٹ کیا۔

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

اوپر دیے گئے کوڈ میں ہم نے:

- MCP کے لیے ضروری لائبریریاں درآمد کیں۔
- ایک کلائنٹ بنایا۔

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

سب سے پہلے، آپ کو اپنے `pom.xml` فائل میں LangChain4j ڈیپینڈنسیز شامل کرنے کی ضرورت ہوگی۔ MCP انٹیگریشن اور GitHub ماڈلز سپورٹ کو فعال کرنے کے لیے یہ ڈیپینڈنسیز شامل کریں:

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

پھر اپنی جاوا کلائنٹ کلاس بنائیں:

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

اوپر دیے گئے کوڈ میں ہم نے:

- **LangChain4j ڈیپینڈنسیز شامل کیں**: MCP انٹیگریشن، OpenAI آفیشل کلائنٹ، اور GitHub ماڈلز سپورٹ کے لیے ضروری۔
- **LangChain4j لائبریریاں درآمد کیں**: MCP انٹیگریشن اور OpenAI چیٹ ماڈل کی فعالیت کے لیے۔
- **ایک `ChatLanguageModel` بنایا**: GitHub ماڈلز کے ساتھ اپنے GitHub ٹوکن کے ذریعے کنفیگر کیا۔
- **HTTP ٹرانسپورٹ سیٹ اپ کیا**: MCP سرور سے کنیکٹ ہونے کے لیے Server-Sent Events (SSE) استعمال کیا۔
- **MCP کلائنٹ بنایا**: جو سرور کے ساتھ بات چیت کو ہینڈل کرے گا۔
- **LangChain4j کے بلٹ ان MCP سپورٹ کا استعمال کیا**: جو LLMs اور MCP سرورز کے درمیان انٹیگریشن کو آسان بناتا ہے۔

#### Rust

یہ مثال فرض کرتی ہے کہ آپ کے پاس Rust پر مبنی MCP سرور چل رہا ہے۔ اگر آپ کے پاس نہیں ہے، تو [01-first-server](../01-first-server/README.md) سبق میں واپس جا کر سرور بنائیں۔

ایک بار جب آپ کے پاس Rust MCP سرور ہو، ایک ٹرمینل کھولیں اور سرور کے ساتھ اسی ڈائریکٹری میں جائیں۔ پھر ایک نیا LLM کلائنٹ پروجیکٹ بنانے کے لیے درج ذیل کمانڈ چلائیں:

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

اپنی `Cargo.toml` فائل میں درج ذیل ڈیپینڈنسیز شامل کریں:

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> OpenAI کے لیے کوئی آفیشل Rust لائبریری نہیں ہے، تاہم، `async-openai` کریٹ ایک [کمیونٹی مینٹینڈ لائبریری](https://platform.openai.com/docs/libraries/rust#rust) ہے جو عام طور پر استعمال ہوتی ہے۔

اپنی `src/main.rs` فائل کھولیں اور اس کے مواد کو درج ذیل کوڈ سے تبدیل کریں:

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

یہ کوڈ ایک بنیادی Rust ایپلیکیشن سیٹ اپ کرتا ہے جو MCP سرور اور GitHub ماڈلز کے ساتھ LLM انٹریکشن کے لیے کنیکٹ کرے گا۔

> [!IMPORTANT]
> ایپلیکیشن چلانے سے پہلے `OPENAI_API_KEY` ماحول متغیر کو اپنے GitHub ٹوکن کے ساتھ سیٹ کرنا یقینی بنائیں۔

زبردست، اگلے مرحلے میں، آئیے سرور کی صلاحیتوں کی فہرست بنائیں۔
ہم LLM کال کو ہینڈل کرنے کے لیے ایک فنکشن ڈیفائن کریں گے۔ اپنے `main.rs` فائل میں درج ذیل فنکشن شامل کریں:

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

یہ فنکشن LLM کلائنٹ، پیغامات کی فہرست (جس میں یوزر پرامپٹ شامل ہے)، MCP سرور کے ٹولز لیتا ہے، اور LLM کو ایک درخواست بھیجتا ہے، جس کے بعد جواب واپس کرتا ہے۔

LLM کے جواب میں `choices` کی ایک array شامل ہوگی۔ ہمیں نتیجہ پروسیس کرنا ہوگا تاکہ یہ معلوم ہو سکے کہ آیا کوئی `tool_calls` موجود ہیں۔ اس سے ہمیں پتہ چلتا ہے کہ LLM کسی مخصوص ٹول کو دلائل کے ساتھ کال کرنے کی درخواست کر رہا ہے۔ اپنے `main.rs` فائل کے آخر میں درج ذیل کوڈ شامل کریں تاکہ LLM کے جواب کو ہینڈل کرنے کے لیے ایک فنکشن ڈیفائن کیا جا سکے:

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

اگر `tool_calls` موجود ہوں، تو یہ ٹول کی معلومات نکالتا ہے، MCP سرور کو ٹول کی درخواست کے ساتھ کال کرتا ہے، اور نتائج کو گفتگو کے پیغامات میں شامل کرتا ہے۔ اس کے بعد یہ LLM کے ساتھ گفتگو جاری رکھتا ہے اور پیغامات کو اسسٹنٹ کے جواب اور ٹول کال کے نتائج کے ساتھ اپ ڈیٹ کرتا ہے۔

MCP کالز کے لیے LLM کی طرف سے واپس کیے گئے ٹول کال کی معلومات نکالنے کے لیے، ہم ایک اور ہیلپر فنکشن شامل کریں گے جو کال کرنے کے لیے درکار تمام چیزیں نکالے گا۔ اپنے `main.rs` فائل کے آخر میں درج ذیل کوڈ شامل کریں:

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

تمام حصے مکمل ہونے کے بعد، ہم ابتدائی یوزر پرامپٹ کو ہینڈل کر سکتے ہیں اور LLM کو کال کر سکتے ہیں۔ اپنے `main` فنکشن کو اپ ڈیٹ کریں تاکہ درج ذیل کوڈ شامل ہو:

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

یہ LLM سے ابتدائی یوزر پرامپٹ کے ساتھ استفسار کرے گا، دو نمبروں کے مجموعے کے بارے میں پوچھے گا، اور جواب کو پروسیس کرے گا تاکہ ٹول کالز کو ڈائنامک طریقے سے ہینڈل کیا جا سکے۔

زبردست، آپ نے یہ کر لیا!

## اسائنمنٹ

ایکسسرسائز سے کوڈ لیں اور سرور کو مزید ٹولز کے ساتھ تیار کریں۔ پھر ایک کلائنٹ بنائیں جس میں LLM شامل ہو، جیسا کہ ایکسرسائز میں ہے، اور مختلف پرامپٹس کے ساتھ اس کا تجربہ کریں تاکہ یہ یقینی بنایا جا سکے کہ آپ کے سرور کے تمام ٹولز ڈائنامک طریقے سے کال ہو رہے ہیں۔ اس طرح کلائنٹ بنانے کا مطلب یہ ہے کہ اختتامی یوزر کو ایک شاندار تجربہ حاصل ہوگا کیونکہ وہ پرامپٹس استعمال کر سکیں گے، بجائے اس کے کہ وہ کلائنٹ کے عین کمانڈز استعمال کریں، اور MCP سرور کے کال ہونے سے بے خبر رہیں گے۔

## حل

[حل](/03-GettingStarted/03-llm-client/solution/README.md)

## اہم نکات

- اپنے کلائنٹ میں LLM شامل کرنے سے یوزرز کو MCP سرورز کے ساتھ بہتر طریقے سے انٹریکٹ کرنے کا موقع ملتا ہے۔
- آپ کو MCP سرور کے جواب کو LLM کے سمجھنے کے قابل بنانا ہوگا۔

## نمونے

- [جاوا کیلکولیٹر](../samples/java/calculator/README.md)
- [.Net کیلکولیٹر](../../../../03-GettingStarted/samples/csharp)
- [جاوا اسکرپٹ کیلکولیٹر](../samples/javascript/README.md)
- [ٹائپ اسکرپٹ کیلکولیٹر](../samples/typescript/README.md)
- [پائتھون کیلکولیٹر](../../../../03-GettingStarted/samples/python)
- [رسٹ کیلکولیٹر](../../../../03-GettingStarted/samples/rust)

## اضافی وسائل

## آگے کیا ہے

- اگلا: [Visual Studio Code کا استعمال کرتے ہوئے سرور کو کنزیوم کرنا](../04-vscode/README.md)

**ڈسکلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لیے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستگی ہو سکتی ہیں۔ اصل دستاویز کو اس کی اصل زبان میں مستند ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لیے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے لیے ہم ذمہ دار نہیں ہیں۔