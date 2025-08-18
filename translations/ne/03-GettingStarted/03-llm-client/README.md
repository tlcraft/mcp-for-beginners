<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
  "translation_date": "2025-08-18T16:13:19+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ne"
}
-->
# LLM प्रयोग गरेर क्लाइन्ट बनाउने

अहिलेसम्म, तपाईंले सर्भर र क्लाइन्ट कसरी बनाउने देख्नुभएको छ। क्लाइन्टले सर्भरलाई स्पष्ट रूपमा उपकरणहरू, स्रोतहरू, र प्रम्प्टहरूको सूची दिन कल गर्न सक्षम भएको छ। तर, यो धेरै व्यावहारिक दृष्टिकोण होइन। तपाईंको प्रयोगकर्ता एजेन्टिक युगमा बस्छन् र प्रम्प्टहरू प्रयोग गर्न र LLM सँग संवाद गर्न चाहन्छन्। प्रयोगकर्ताका लागि, तपाईंले आफ्नो क्षमता MCP मा भण्डारण गर्न प्रयोग गर्नुहुन्छ कि हुँदैन भन्ने कुराले फरक पर्दैन, तर उनीहरूले प्राकृतिक भाषाको माध्यमबाट संवाद गर्न चाहन्छन्। त्यसो भए हामी यो कसरी समाधान गर्ने? समाधान भनेको क्लाइन्टमा LLM थप्ने हो।

## अवलोकन

यस पाठमा हामी क्लाइन्टमा LLM थप्न केन्द्रित गर्छौं र यो कसरी तपाईंको प्रयोगकर्ताका लागि धेरै राम्रो अनुभव प्रदान गर्दछ भन्ने देखाउँछौं।

## सिकाइ उद्देश्यहरू

यस पाठको अन्त्यसम्ममा, तपाईं सक्षम हुनुहुनेछ:

- LLM सहित क्लाइन्ट बनाउने।
- MCP सर्भरसँग सहज रूपमा LLM प्रयोग गरेर संवाद गर्ने।
- क्लाइन्ट पक्षमा अन्तिम प्रयोगकर्ताको अनुभव सुधार गर्ने।

## दृष्टिकोण

हामीले लिनुपर्ने दृष्टिकोण बुझ्ने प्रयास गरौं। LLM थप्न सरल लाग्छ, तर के हामी वास्तवमै यो गर्नेछौं?

क्लाइन्टले सर्भरसँग यसरी संवाद गर्नेछ:

1. सर्भरसँग जडान स्थापना गर्नुहोस्।

1. क्षमता, प्रम्प्टहरू, स्रोतहरू, र उपकरणहरूको सूची बनाउनुहोस् र तिनीहरूको स्किमालाई सुरक्षित गर्नुहोस्।

1. LLM थप्नुहोस् र सुरक्षित गरिएका क्षमता र तिनीहरूको स्किमालाई LLM ले बुझ्ने ढाँचामा पास गर्नुहोस्।

1. प्रयोगकर्ताको प्रम्प्टलाई LLM मा पास गर्नुहोस्, क्लाइन्टले सूचीबद्ध गरेका उपकरणहरूसँगै।

ठीक छ, अब हामीले उच्च स्तरमा यो कसरी गर्न सकिन्छ भन्ने कुरा बुझ्यौं, तलको अभ्यासमा यसलाई प्रयास गरौं।

## अभ्यास: LLM सहित क्लाइन्ट बनाउने

यस अभ्यासमा, हामी हाम्रो क्लाइन्टमा LLM थप्न सिक्नेछौं।

### GitHub व्यक्तिगत पहुँच टोकन प्रयोग गरेर प्रमाणीकरण

GitHub टोकन बनाउने प्रक्रिया सरल छ। यसरी गर्न सकिन्छ:

- GitHub सेटिङमा जानुहोस् – माथि दायाँ कुनामा आफ्नो प्रोफाइल चित्रमा क्लिक गर्नुहोस् र सेटिङ चयन गर्नुहोस्।
- डेभलपर सेटिङमा जानुहोस् – तल स्क्रोल गर्नुहोस् र डेभलपर सेटिङमा क्लिक गर्नुहोस्।
- व्यक्तिगत पहुँच टोकन चयन गर्नुहोस् – व्यक्तिगत पहुँच टोकनमा क्लिक गर्नुहोस् र नयाँ टोकन सिर्जना गर्नुहोस्।
- आफ्नो टोकन कन्फिगर गर्नुहोस् – सन्दर्भको लागि नोट थप्नुहोस्, समाप्ति मिति सेट गर्नुहोस्, र आवश्यक स्कोपहरू (अनुमतिहरू) चयन गर्नुहोस्।
- टोकन सिर्जना गर्नुहोस् र प्रतिलिपि गर्नुहोस् – टोकन सिर्जना क्लिक गर्नुहोस्, र तुरुन्तै प्रतिलिपि गर्नुहोस्, किनकि तपाईंले यसलाई फेरि हेर्न सक्नुहुन्न।

### -1- सर्भरसँग जडान गर्नुहोस्

पहिला हाम्रो क्लाइन्ट बनाऔं:

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

उपरोक्त कोडमा हामीले:

- आवश्यक पुस्तकालयहरू आयात गरेका छौं।
- दुई सदस्यहरू `client` र `openai` सहितको कक्षा बनाएका छौं, जसले क्लाइन्ट व्यवस्थापन गर्न र LLM सँग संवाद गर्न मद्दत गर्दछ।
- हाम्रो LLM इन्स्ट्यान्सलाई GitHub मोडेलहरू प्रयोग गर्न कन्फिगर गरेका छौं `baseUrl` लाई इन्फरेन्स API मा पोइन्ट गरेर।

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

उपरोक्त कोडमा हामीले:

- MCP का लागि आवश्यक पुस्तकालयहरू आयात गरेका छौं।
- क्लाइन्ट बनाएका छौं।

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

पहिला, तपाईंले `pom.xml` फाइलमा LangChain4j निर्भरता थप्नुपर्नेछ। MCP एकीकरण र GitHub मोडेल समर्थन सक्षम गर्न यी निर्भरता थप्नुहोस्:

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

त्यसपछि आफ्नो Java क्लाइन्ट कक्षा बनाउनुहोस्:

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

उपरोक्त कोडमा हामीले:

- **LangChain4j निर्भरता थपेका छौं**: MCP एकीकरण, OpenAI आधिकारिक क्लाइन्ट, र GitHub मोडेल समर्थनका लागि आवश्यक।
- **LangChain4j पुस्तकालयहरू आयात गरेका छौं**: MCP एकीकरण र OpenAI च्याट मोडेल कार्यक्षमताका लागि।
- **`ChatLanguageModel` बनाएका छौं**: GitHub टोकनको साथ GitHub मोडेलहरू प्रयोग गर्न कन्फिगर गरिएको।
- **HTTP ट्रान्सपोर्ट सेट अप गरेका छौं**: MCP सर्भरसँग जडान गर्न Server-Sent Events (SSE) प्रयोग गर्दै।
- **MCP क्लाइन्ट बनाएका छौं**: जसले सर्भरसँगको संवाद व्यवस्थापन गर्नेछ।
- **LangChain4j को बिल्ट-इन MCP समर्थन प्रयोग गरेका छौं**: जसले LLM र MCP सर्भरहरू बीचको एकीकरणलाई सरल बनाउँछ।

#### Rust

यो उदाहरणले Rust आधारित MCP सर्भर चलिरहेको छ भन्ने मान्छ। यदि तपाईंसँग छैन भने, [01-first-server](../01-first-server/README.md) पाठमा फर्केर सर्भर बनाउनुहोस्।

एकपटक तपाईंको Rust MCP सर्भर भए पछि, टर्मिनल खोल्नुहोस् र सर्भर रहेको डाइरेक्टरीमा जानुहोस्। त्यसपछि नयाँ LLM क्लाइन्ट प्रोजेक्ट बनाउन निम्न कमाण्ड चलाउनुहोस्:

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

`Cargo.toml` फाइलमा निम्न निर्भरता थप्नुहोस्:

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> OpenAI का लागि आधिकारिक Rust पुस्तकालय छैन, तर `async-openai` क्रेट [समुदायद्वारा मर्मत गरिएको पुस्तकालय](https://platform.openai.com/docs/libraries/rust#rust) हो जुन सामान्यतया प्रयोग गरिन्छ।

`src/main.rs` फाइल खोल्नुहोस् र यसको सामग्रीलाई निम्न कोडले प्रतिस्थापन गर्नुहोस्:

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

यो कोडले MCP सर्भर र GitHub मोडेलहरूसँग LLM संवादका लागि जडान गर्ने आधारभूत Rust एप्लिकेसन सेट अप गर्दछ।

> [!IMPORTANT]
> एप्लिकेसन चलाउनु अघि `OPENAI_API_KEY` वातावरण चरलाई आफ्नो GitHub टोकनसँग सेट गर्न निश्चित गर्नुहोस्।

ठीक छ, हाम्रो अर्को चरणका लागि, सर्भरमा क्षमता सूची बनाऔं।

### -2- सर्भर क्षमता सूची बनाउनुहोस्

अब हामी सर्भरसँग जडान गर्नेछौं र यसको क्षमता सोध्नेछौं:

#### TypeScript

उही कक्षामा निम्न विधिहरू थप्नुहोस्:

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

उपरोक्त कोडमा हामीले:

- सर्भरसँग जडान गर्नको लागि कोड थपेका छौं, `connectToServer`।
- हाम्रो एप फ्लो व्यवस्थापन गर्ने जिम्मेवार `run` विधि बनाएका छौं। हालसम्म यसले उपकरणहरूको मात्र सूची बनाउँछ, तर हामी यसमा थप थप्नेछौं।

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

यहाँ हामीले थपेका छौं:

- स्रोतहरू र उपकरणहरूको सूची बनाएका छौं र तिनीहरूलाई प्रिन्ट गरेका छौं। उपकरणहरूको लागि हामीले `inputSchema` पनि सूची बनाएका छौं, जुन हामी पछि प्रयोग गर्नेछौं।

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

उपरोक्त कोडमा हामीले:

- MCP सर्भरमा उपलब्ध उपकरणहरूको सूची बनाएका छौं।
- प्रत्येक उपकरणको लागि नाम, विवरण, र यसको स्किमा सूची बनाएका छौं। पछिल्लो कुरा हामी चाँडै उपकरणहरू कल गर्न प्रयोग गर्नेछौं।

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

उपरोक्त कोडमा हामीले:

- `McpToolProvider` बनाएका छौं जसले MCP सर्भरबाट सबै उपकरणहरू स्वचालित रूपमा पत्ता लगाउँछ र दर्ता गर्दछ।
- उपकरण प्रदायकले MCP उपकरण स्किमाहरू र LangChain4j को उपकरण ढाँचाबीचको रूपान्तरण आन्तरिक रूपमा व्यवस्थापन गर्दछ।
- यो दृष्टिकोणले उपकरण सूची बनाउने र रूपान्तरण प्रक्रिया म्यानुअल रूपमा हटाउँछ।

#### Rust

MCP सर्भरबाट उपकरणहरू प्राप्त गर्न `list_tools` विधि प्रयोग गरिन्छ। आफ्नो `main` कार्यमा, MCP क्लाइन्ट सेट अप गरेपछि निम्न कोड थप्नुहोस्:

```rust
// Get MCP tool listing 
let tools = mcp_client.list_tools(Default::default()).await?;
```

### -3- सर्भर क्षमताहरूलाई LLM उपकरणमा रूपान्तरण गर्नुहोस्

सर्भर क्षमताहरू सूची बनाएपछि अर्को चरण भनेको तिनीहरूलाई LLM ले बुझ्ने ढाँचामा रूपान्तरण गर्नु हो। एकपटक हामीले यो गरेपछि, हामी यी क्षमताहरूलाई उपकरणको रूपमा LLM मा प्रदान गर्न सक्छौं।

#### TypeScript

1. MCP सर्भरबाट प्राप्त प्रतिक्रियालाई LLM ले प्रयोग गर्न सक्ने उपकरण ढाँचामा रूपान्तरण गर्न निम्न कोड थप्नुहोस्:

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

    माथिको कोडले MCP सर्भरबाट प्राप्त प्रतिक्रियालाई LLM ले बुझ्न सक्ने उपकरण परिभाषा ढाँचामा रूपान्तरण गर्दछ।

1. `run` विधिलाई अपडेट गरौं:

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

    उपरोक्त कोडमा, हामीले `run` विधिलाई परिणामको माध्यमबाट म्याप गर्न र प्रत्येक प्रविष्टिका लागि `openAiToolAdapter` कल गर्न अपडेट गरेका छौं।

#### Python

1. पहिलो, निम्न रूपान्तरणकर्ता कार्य बनाऔं:

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

    माथिको `convert_to_llm_tools` कार्यमा हामी MCP उपकरण प्रतिक्रियालाई LLM ले बुझ्न सक्ने ढाँचामा रूपान्तरण गर्छौं।

1. अब, हाम्रो क्लाइन्ट कोडलाई निम्नानुसार अपडेट गरौं:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    यहाँ, हामीले MCP उपकरण प्रतिक्रियालाई LLM मा फिड गर्न सक्ने ढाँचामा रूपान्तरण गर्न `convert_to_llm_tool` कल थपेका छौं।

#### .NET

1. MCP उपकरण प्रतिक्रियालाई LLM ले बुझ्न सक्ने ढाँचामा रूपान्तरण गर्न कोड थपौं:

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

उपरोक्त कोडमा हामीले:

- `ConvertFrom` नाम, विवरण, र इनपुट स्किमा लिने कार्य बनाएका छौं।
- `FunctionDefinition` बनाउने कार्यक्षमता परिभाषित गरेका छौं, जुन `ChatCompletionsDefinition` मा पास गरिन्छ। पछिल्लो कुरा LLM ले बुझ्न सक्छ।

1. केही विद्यमान कोडलाई अपडेट गरौं:

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

    उपरोक्त कोडमा, हामीले:

    - MCP उपकरण प्रतिक्रियालाई LLM उपकरणमा रूपान्तरण गर्न कार्य अपडेट गरेका छौं। थपिएको कोडलाई हाइलाइट गरौं:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        इनपुट स्किमा उपकरण प्रतिक्रियाको भाग हो तर "properties" विशेषतामा छ, त्यसैले हामीले यसलाई निकाल्नुपर्छ। त्यसपछि, हामी उपकरण विवरणको साथ `ConvertFrom` कल गर्छौं। अब हामीले मुख्य काम गरिसकेका छौं, प्रयोगकर्ताको प्रम्प्टलाई कसरी ह्यान्डल गर्ने देखौं।

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

उपरोक्त कोडमा हामीले:

- प्राकृतिक भाषाको संवादका लागि सरल `Bot` इन्टरफेस परिभाषित गरेका छौं।
- LangChain4j को `AiServices` प्रयोग गरेर LLM लाई MCP उपकरण प्रदायकसँग स्वचालित रूपमा बाँधेका छौं।
- फ्रेमवर्कले उपकरण स्किमा रूपान्तरण र कार्य कलिंगलाई आन्तरिक रूपमा व्यवस्थापन गर्दछ।
- यो दृष्टिकोणले MCP उपकरणहरूलाई LLM-संगत ढाँचामा रूपान्तरण गर्ने म्यानुअल प्रक्रिया हटाउँछ।

#### Rust

MCP उपकरण प्रतिक्रियालाई LLM ले बुझ्न सक्ने ढाँचामा रूपान्तरण गर्न, हामी उपकरण सूची बनाउँदा प्रयोग गरिने सहायक कार्य थप्नेछौं। यो कार्य `main.rs` फाइलमा `main` कार्यको तल थप्नुहोस्:

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

ठीक छ, अब हामी प्रयोगकर्ताको अनुरोध ह्यान्डल गर्न तयार छौं, त्यसैले यो tackle गरौं।

### -4- प्रयोगकर्ताको प्रम्प्ट अनुरोध ह्यान्डल गर्नुहोस्

यस भागमा, हामी प्रयोगकर्ताको अनुरोध ह्यान्डल गर्नेछौं।

#### TypeScript

1. हाम्रो LLM कल गर्न प्रयोग गरिने विधि थपौं:

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

    उपरोक्त कोडमा हामीले:

    - `callTools` नामक विधि थपेका छौं।
    - विधिले LLM प्रतिक्रिया लिन्छ र जाँच गर्छ कि कुनै उपकरणहरू कल गरिएको छ कि छैन:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - LLM ले उपकरण कल गर्न संकेत गरेमा उपकरण कल गर्छ:

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

1. `run` विधिलाई अपडेट गरौं:

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

ठीक छ, कोडलाई पूर्ण रूपमा सूची बनाऔं:

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

1. LLM कल गर्न आवश्यक आयातहरू थपौं:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. LLM कल गर्ने कार्य थपौं:

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

    उपरोक्त कोडमा हामीले:

    - MCP सर्भरबाट फेला परेका उपकरणहरूलाई LLM मा पास गरेका छौं।
    - त्यसपछि, हामीले ती उपकरणहरू सहित LLM कल गरेका छौं।
    - त्यसपछि, हामीले परिणाम निरीक्षण गरेका छौं कि कुनै उपकरणहरू कल गर्नुपर्छ कि छैन।
    - अन्तमा, हामीले उपकरणहरूको सूची पास गरेका छौं।

1. अन्तिम चरण, मुख्य कोड अपडेट गरौं:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    यहाँ, हामी:

    - MCP सर्भरमा `call_tool` मार्फत MCP उपकरण कल गर्दैछौं।
    - उपकरण कलको परिणाम प्रिन्ट गर्दैछौं।

#### .NET

1. LLM प्रम्प्ट अनुरोधको लागि कोड देखौं:

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

    उपरोक्त कोडमा हामीले:

    - MCP सर्भरबाट उपकरणहरू फेच गरेका छौं, `var tools = await GetMcpTools()`।
    - प्रयोगकर्ताको प्रम्प्ट परिभाषित गरेका छौं `userMessage`।
    - विकल्प वस्तु निर्माण गरेका छौं जसले मोडेल र उपकरण निर्दिष्ट गर्दछ।
    - LLM तर्फ अनुरोध गरेका छौं।

1. अन्तिम चरण, LLM ले कार्य कल गर्नुपर्छ कि भनेर हेर्नुहोस्:

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

    उपरोक्त कोडमा हामीले:

    - कार्य कलहरूको सूचीमा लूप गरेका छौं।
    - प्रत्येक उपकरण कलको लागि, नाम र तर्कहरू पार्स गरेर MCP सर्भरमा MCP क्लाइन्ट प्रयोग गरेर उपकरण कल गरेका छौं। अन्तमा हामी परिणाम प्रिन्ट गर्छौं।

पूर्ण कोड:

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

उपरोक्त कोडमा हामीले:

- MCP सर्भर उपकरणहरूसँग संवाद गर्न सरल प्राकृतिक भाषा प्रम्प्टहरू प्रयोग गरेका छौं।
- LangChain4j फ्रेमवर्कले स्वचालित रूपमा:
  - प्रयोगकर्ताको प्रम्प्टलाई आवश्यक पर्दा उपकरण कलमा रूपान्तरण गर्छ।
  - LLM को निर्णयको आधारमा उपयुक्त MCP उपकरणहरू कल गर्छ।
  - LLM र MCP सर्भर बीचको संवाद प्रवाह व्यवस्थापन गर्छ।
- `bot.chat()` विधिले MCP उपकरण कार्यान्वयनबाट परिणामहरू समावेश गर्न सक्ने प्राकृतिक भाषा प्रतिक्रियाहरू फर्काउँछ।
- यो दृष्टिकोणले प्रयोगकर्तालाई अन्तर्निहित MCP कार्यान्वयनको बारेमा जान्न आवश्यक छैन।

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

#### Rust

यहाँ मुख्य काम हुन्छ। हामी प्रारम्भिक प्रयोगकर्ता प्रम्प्टको साथ LLM कल गर्नेछौं, त्यसपछि प्रतिक्रिया प्रक्रिया गर्नेछौं कि कुनै उपकरणहरू कल गर्नुपर्छ कि छैन। यदि उपकरणहरू कल गर्नुपर्छ भने, हामी ती उपकरणहरू कल गर्नेछौं र अन्तिम प्रतिक्रिया प्राप्त नभएसम्म LLM सँग संवाद जारी राख्नेछौं।
हामी LLM कललाई व्यवस्थापन गर्ने एउटा फङ्सन परिभाषित गर्नेछौं। आफ्नो `main.rs` फाइलमा निम्न फङ्सन थप्नुहोस्:

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

यो फङ्सनले LLM क्लाइन्ट, सन्देशहरूको सूची (जसमा प्रयोगकर्ताको प्रम्प्ट समावेश छ), MCP सर्भरबाट टुलहरू लिन्छ, र LLM लाई अनुरोध पठाउँछ, जसले प्रतिक्रिया फर्काउँछ।

LLM बाट आएको प्रतिक्रियामा `choices` को एउटा एरे हुनेछ। हामीले परिणामलाई प्रक्रिया गर्न आवश्यक छ कि कुनै `tool_calls` छन् कि छैनन्। यसले हामीलाई थाहा दिन्छ कि LLM ले विशेष टुललाई तर्कसहित बोलाउन अनुरोध गरिरहेको छ। आफ्नो `main.rs` फाइलको तल निम्न कोड थप्नुहोस् जसले LLM प्रतिक्रियालाई व्यवस्थापन गर्ने फङ्सन परिभाषित गर्छ:

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

यदि `tool_calls` उपस्थित छन् भने, यो टुल जानकारी निकाल्छ, MCP सर्भरलाई टुल अनुरोधसहित बोलाउँछ, र परिणामहरू कुराकानी सन्देशहरूमा थप्छ। त्यसपछि यो LLM सँग कुराकानी जारी राख्छ र सन्देशहरू सहायकको प्रतिक्रिया र टुल कल परिणामहरूसँग अपडेट गरिन्छ।

MCP कलहरूको लागि LLM ले फर्काएको टुल कल जानकारी निकाल्न, हामी अर्को हेल्पर फङ्सन थप्नेछौं जसले कल गर्न आवश्यक सबै कुरा निकाल्छ। आफ्नो `main.rs` फाइलको तल निम्न कोड थप्नुहोस्:

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

सबै टुक्राहरू तयार भएपछि, हामी प्रारम्भिक प्रयोगकर्ता प्रम्प्टलाई व्यवस्थापन गर्न र LLM कल गर्न सक्छौं। आफ्नो `main` फङ्सनलाई निम्न कोड समावेश गर्न अपडेट गर्नुहोस्:

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

यसले दुई संख्याको योग सोध्ने प्रारम्भिक प्रयोगकर्ता प्रम्प्टसँग LLM सोध्छ, र टुल कलहरू गतिशील रूपमा व्यवस्थापन गर्न प्रतिक्रिया प्रक्रिया गर्छ।

शानदार, तपाईंले यो पूरा गर्नुभयो!

## असाइनमेन्ट

अभ्यासबाट कोड लिई सर्भरमा केही थप टुलहरू निर्माण गर्नुहोस्। त्यसपछि अभ्यासमा जस्तै LLM सहित क्लाइन्ट बनाउनुहोस्, र विभिन्न प्रम्प्टहरूसँग परीक्षण गर्नुहोस् ताकि तपाईंको सर्भर टुलहरू गतिशील रूपमा बोलाइन्छ। क्लाइन्ट निर्माण गर्ने यो तरिकाले अन्तिम प्रयोगकर्तालाई उत्कृष्ट अनुभव प्रदान गर्दछ किनभने उनीहरूले प्रम्प्टहरू प्रयोग गर्न सक्छन्, सटीक क्लाइन्ट कमाण्डहरू होइन, र MCP सर्भर बोलाइएको कुराबाट अनभिज्ञ रहन्छन्।

## समाधान

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## मुख्य सिकाइहरू

- आफ्नो क्लाइन्टमा LLM थप्दा प्रयोगकर्ताहरूलाई MCP सर्भरहरूसँग अन्तरक्रिया गर्न राम्रो तरिका प्रदान गर्दछ।
- तपाईंले MCP सर्भर प्रतिक्रियालाई LLM ले बुझ्न सक्ने केहीमा रूपान्तरण गर्न आवश्यक छ।

## नमूनाहरू

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)
- [Rust Calculator](../../../../03-GettingStarted/samples/rust)

## थप स्रोतहरू

## अब के गर्ने

- अगाडि: [Visual Studio Code प्रयोग गरेर सर्भर उपभोग गर्ने](../04-vscode/README.md)

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी यथासम्भव शुद्धताको प्रयास गर्छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादहरूमा त्रुटि वा अशुद्धता हुन सक्छ। यसको मूल भाषामा रहेको मूल दस्तावेज़लाई आधिकारिक स्रोत मानिनुपर्छ। महत्त्वपूर्ण जानकारीका लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार हुने छैनौं।