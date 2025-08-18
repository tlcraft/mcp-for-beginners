<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "94c80ae71fb9971e9b57b51ab0912121",
  "translation_date": "2025-08-18T23:37:03+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "my"
}
-->
# Client တစ်ခု ဖန်တီးခြင်း

Client များသည် MCP Server နှင့်တိုက်ရိုက်ဆက်သွယ်ပြီး အရင်းအမြစ်များ၊ ကိရိယာများနှင့် prompt များကို တောင်းဆိုနိုင်သည့် အထူးဖန်တီးထားသော အက်ပ်လီကေးရှင်းများ သို့မဟုတ် စာရေးထားသော script များဖြစ်သည်။ Server နှင့် အပြန်အလှန်ဆက်သွယ်ရန် ဂရပ်ဖစ်အင်တာဖေ့စ်ကို ပံ့ပိုးပေးသည့် inspector tool ကို အသုံးပြုခြင်းနှင့် မတူဘဲ၊ ကိုယ်ပိုင် client ကိုရေးသားခြင်းဖြင့် အလိုအလျောက်လုပ်ဆောင်မှုများနှင့် ကိုယ်ပိုင် workflow များထဲသို့ MCP စွမ်းဆောင်ရည်များကို ပေါင်းစည်းနိုင်သည်။ ဒါကတော့ အထူးလိုအပ်ချက်များအတွက် အထူးပြုဖြေရှင်းချက်များ ဖန်တီးရန် ဖွံ့ဖြိုးသူများအတွက် အထောက်အကူဖြစ်စေသည်။

## အနှစ်ချုပ်

ဒီသင်ခန်းစာမှာ Model Context Protocol (MCP) စနစ်အတွင်း client များ၏ အကြံဉာဏ်ကို မိတ်ဆက်ပေးမှာဖြစ်ပါတယ်။ သင်၏ကိုယ်ပိုင် client ကိုရေးသားပြီး MCP Server တစ်ခုနှင့် ဆက်သွယ်ပုံကို သင်လေ့လာနိုင်ပါမည်။

## သင်ခန်းစာရည်မှန်းချက်များ

ဒီသင်ခန်းစာအဆုံးတွင် သင်သည် အောက်ပါအရာများကို နားလည်နိုင်ပါမည်-

- Client တစ်ခုက ဘာလုပ်ဆောင်နိုင်သလဲဆိုတာကို နားလည်ခြင်း။
- ကိုယ်ပိုင် client ကိုရေးသားခြင်း။
- MCP Server နှင့် client ကို ဆက်သွယ်ပြီး Server သည် မျှော်မှန်းထားသည့်အတိုင်း အလုပ်လုပ်နေကြောင်း စမ်းသပ်ခြင်း။

## Client တစ်ခုရေးသားရန် ဘာတွေလိုအပ်သလဲ?

Client တစ်ခုရေးသားရန် သင်သည် အောက်ပါအဆင့်များကို လိုက်နာရမည်-

- **လိုအပ်သော library များကို သွင်းယူပါ**။ ယခင်က အသုံးပြုခဲ့သည့် library ကိုပင် အသုံးပြုမည်ဖြစ်ပြီး၊ သို့သော် အခြား construct များကို အသုံးပြုမည်ဖြစ်သည်။
- **Client တစ်ခုကို ဖန်တီးပါ**။ ဒါကတော့ client instance တစ်ခုကို ဖန်တီးပြီး ရွေးချယ်ထားသော transport method နှင့် ဆက်သွယ်ရန် လိုအပ်ပါမည်။
- **List ပြမည့် အရင်းအမြစ်များကို ဆုံးဖြတ်ပါ**။ သင့် MCP Server တွင် အရင်းအမြစ်များ၊ ကိရိယာများနှင့် prompt များ ပါဝင်ပြီး၊ သင်သည် မည်သည့်အရာကို list ပြမည်ဆိုတာ ဆုံးဖြတ်ရမည်။
- **Client ကို host application နှင့် ပေါင်းစည်းပါ**။ Server ၏ စွမ်းဆောင်ရည်များကို သိရှိပြီးနောက်၊ သုံးစွဲသူက prompt သို့မဟုတ် အခြား command တစ်ခုကို ရိုက်ထည့်သည့်အခါ၊ ဆက်စပ်သော Server feature ကို ခေါ်ဆောင်နိုင်ရန် သင့် host application နှင့် ပေါင်းစည်းရမည်။

အခုတော့ ကျွန်တော်တို့ ဘာလုပ်မယ်ဆိုတာ အထွေထွေသဘောတူပြီးဖြစ်တဲ့အတွက်၊ နောက်တစ်ဆင့်မှာ ဥပမာတစ်ခုကို ကြည့်ကြရအောင်။

### Client တစ်ခု၏ ဥပမာ

ဒီ client ဥပမာကို ကြည့်ကြရအောင်-

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

အထက်ပါ code တွင် ကျွန်တော်တို့-

- Library များကို သွင်းယူခဲ့သည်။
- Client တစ်ခုကို ဖန်တီးပြီး stdio ကို transport အဖြစ် အသုံးပြု၍ ဆက်သွယ်ခဲ့သည်။
- Prompt များ၊ အရင်းအမြစ်များနှင့် ကိရိယာများကို list ပြပြီး၊ အားလုံးကို ခေါ်ဆောင်ခဲ့သည်။

ဒီတော့ MCP Server နှင့် ဆက်သွယ်နိုင်တဲ့ client တစ်ခု ရရှိသွားပါပြီ။

နောက်ထပ် exercise အပိုင်းတွင် code snippet တစ်ခုချင်းစီကို ခွဲခြမ်းစိတ်ဖြာပြီး ဘာတွေဖြစ်သွားတယ်ဆိုတာ ရှင်းပြကြရအောင်။

## လေ့ကျင့်ခန်း: Client တစ်ခုရေးသားခြင်း

အထက်မှာ ပြောခဲ့သလို၊ code ကို ရှင်းပြရင်း သင်လည်း code ကို ရေးသားလိုက်နိုင်ပါတယ်။

### -1- Library များကို သွင်းယူခြင်း

လိုအပ်သော library များကို သွင်းယူကြရအောင်။ Client နှင့် ရွေးချယ်ထားသော transport protocol (stdio) ကို ရည်ညွှန်းရန် လိုအပ်ပါမည်။ stdio သည် သင့် local စက်ပေါ်တွင် အလုပ်လုပ်ရန် ရည်ရွယ်ထားသော protocol တစ်ခုဖြစ်သည်။ SSE သည် နောက်ပိုင်း chapter များတွင် ပြသမည့် အခြား transport protocol တစ်ခုဖြစ်သည်။ ယခုအချိန်တွင် stdio ဖြင့် ဆက်လက်လုပ်ဆောင်ကြရအောင်။

#### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

#### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

#### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

#### Java

Java အတွက်တော့ ယခင် exercise မှ MCP Server နှင့် ဆက်သွယ်သည့် Java Spring Boot project ကို အသုံးပြုပါ။ `src/main/java/com/microsoft/mcp/sample/client/` folder တွင် `SDKClient` ဟုခေါ်သော Java class အသစ်တစ်ခု ဖန်တီးပြီး အောက်ပါ imports များကို ထည့်သွင်းပါ-

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

#### Rust

`Cargo.toml` ဖိုင်တွင် အောက်ပါ dependencies များကို ထည့်သွင်းရမည်။

```toml
[package]
name = "calculator-client"
version = "0.1.0"
edition = "2024"

[dependencies]
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

ထို့နောက် သင့် client code တွင် လိုအပ်သော library များကို သွင်းယူနိုင်ပါသည်။

```rust
use rmcp::{
    RmcpError,
    model::CallToolRequestParam,
    service::ServiceExt,
    transport::{ConfigureCommandExt, TokioChildProcess},
};
use tokio::process::Command;
```

အခုတော့ instantiation ဆီသို့ ရောက်ကြရအောင်။

### -2- Client နှင့် transport ကို ဖန်တီးခြင်း

Transport နှင့် Client တို့၏ instance များကို ဖန်တီးရမည်-

#### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

အထက်ပါ code တွင် ကျွန်တော်တို့-

- stdio transport instance တစ်ခုကို ဖန်တီးခဲ့သည်။ Server ကို ရှာဖွေပြီး စတင်ရန် command နှင့် args များကို သတ်မှတ်ထားပုံကို သတိပြုပါ။

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Client တစ်ခုကို အမည်နှင့် version ဖြင့် ဖန်တီးခဲ့သည်။

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Client ကို ရွေးချယ်ထားသော transport နှင့် ဆက်သွယ်ခဲ့သည်။

    ```typescript
    await client.connect(transport);
    ```

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

အထက်ပါ code တွင် ကျွန်တော်တို့-

- လိုအပ်သော library များကို သွင်းယူခဲ့သည်။
- Server parameters object တစ်ခုကို ဖန်တီးခဲ့သည်။ Server ကို run လုပ်ပြီး client နှင့် ဆက်သွယ်ရန် အသုံးပြုမည်ဖြစ်သည်။
- `stdio_client` ကို ခေါ်သည့် `run` method ကို သတ်မှတ်ခဲ့သည်။
- `asyncio.run` ကို အသုံးပြု၍ `run` method ကို provide လုပ်ခဲ့သည်။

#### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

အထက်ပါ code တွင် ကျွန်တော်တို့-

- လိုအပ်သော library များကို သွင်းယူခဲ့သည်။
- stdio transport တစ်ခုကို ဖန်တီးပြီး `mcpClient` ဟုခေါ်သော client တစ်ခုကို ဖန်တီးခဲ့သည်။ ယင်း client ကို MCP Server တွင် feature များကို list ပြရန်နှင့် invoke ပြုလုပ်ရန် အသုံးပြုမည်။

မှတ်ချက်- "Arguments" တွင် *.csproj* သို့မဟုတ် executable ကို ရည်ညွှန်းနိုင်သည်။

#### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

အထက်ပါ code တွင် ကျွန်တော်တို့-

- `http://localhost:8080` တွင် run လုပ်မည့် MCP Server ကို ရည်ညွှန်းသည့် SSE transport ကို သတ်မှတ်ခဲ့သည်။
- Transport ကို constructor parameter အဖြစ် လက်ခံသည့် client class တစ်ခုကို ဖန်တီးခဲ့သည်။
- `run` method တွင် transport ကို အသုံးပြု၍ synchronous MCP client တစ်ခုကို ဖန်တီးပြီး connection ကို initialize လုပ်ခဲ့သည်။
- Java Spring Boot MCP Server များနှင့် HTTP-based ဆက်သွယ်မှုအတွက် သင့်လျော်သော SSE (Server-Sent Events) transport ကို အသုံးပြုခဲ့သည်။

#### Rust

Server ကို စတင်ပြီး feature များကို list ပြရန်၊ main function တွင် client ကို initialize ပြုလုပ်နိုင်သည်။

```rust
async fn main() -> Result<(), RmcpError> {
    // Assume the server is a sibling project named "calculator-server" in the same directory
    let server_dir = std::path::Path::new(env!("CARGO_MANIFEST_DIR"))
        .parent()
        .expect("failed to locate workspace root")
        .join("calculator-server");

    let client = ()
        .serve(
            TokioChildProcess::new(Command::new("cargo").configure(|cmd| {
                cmd.arg("run").current_dir(server_dir);
            }))
            .map_err(RmcpError::transport_creation::<TokioChildProcess>)?,
        )
        .await?;

    // TODO: Initialize

    // TODO: List tools

    // TODO: Call add tool with arguments = {"a": 3, "b": 2}

    client.cancel().await?;
    Ok(())
}
```

### -3- Server ၏ feature များကို list ပြခြင်း

Client ကို run လုပ်သည့်အခါ Server ၏ feature များကို list ပြရန် လိုအပ်သည်။

#### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

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
```

ဒီမှာ `list_resources()` နှင့် `list_tools` ကို အသုံးပြု၍ ရရှိနိုင်သော အရင်းအမြစ်များနှင့် ကိရိယာများကို list ပြပြီး print ထုတ်ထားသည်။

#### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

အထက်ပါမှာ Server ၏ tools များကို list ပြပုံကို ပြထားသည်။ Tool တစ်ခုချင်းစီအတွက် name ကို print ထုတ်ထားသည်။

#### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

အထက်ပါ code တွင် ကျွန်တော်တို့-

- MCP Server မှ ရရှိနိုင်သော tool များအားလုံးကို `listTools()` ဖြင့် ခေါ်ယူခဲ့သည်။
- Server နှင့် connection အလုပ်လုပ်နေကြောင်း စစ်ဆေးရန် `ping()` ကို အသုံးပြုခဲ့သည်။
- `ListToolsResult` တွင် tool များ၏ အမည်များ၊ ဖော်ပြချက်များနှင့် input schema များ ပါဝင်သည်။

အိုကေ၊ feature များအားလုံးကို ဖမ်းယူပြီးဖြစ်သည်။ အခုတော့ feature များကို ဘယ်အချိန်မှာ အသုံးပြုမလဲဆိုတာ စဉ်းစားရမည်။ Client တစ်ခုဟာ ရိုးရှင်းတဲ့ client ဖြစ်ပြီး၊ feature များကို အသုံးပြုလိုတဲ့အချိန်မှာသာ ခေါ်ဆောင်ရမည်။ နောက်အခန်းမှာတော့ ကိုယ်ပိုင် LLM (large language model) ရှိတဲ့ ပိုမိုတိုးတက်တဲ့ client တစ်ခုကို ဖန်တီးမှာဖြစ်ပါတယ်။ ယခုအချိန်တွင်တော့ Server ၏ feature များကို ဘယ်လို invoke ပြုလုပ်မလဲဆိုတာ ကြည့်ကြရအောင်-

#### Rust

Main function တွင် client ကို initialize ပြီးနောက် Server ကို initialize လုပ်ပြီး feature များကို list ပြနိုင်သည်။

```rust
// Initialize
let server_info = client.peer_info();
println!("Server info: {:?}", server_info);

// List tools
let tools = client.list_tools(Default::default()).await?;
println!("Available tools: {:?}", tools);
```

### -4- Feature များကို invoke ပြုလုပ်ခြင်း

Feature များကို invoke ပြုလုပ်ရန် သင့် arguments များနှင့် သတ်မှတ်ထားသော အမည်ကို မှန်ကန်စွာ သတ်မှတ်ရမည်။

#### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

အထက်ပါ code တွင် ကျွန်တော်တို့-

- Resource တစ်ခုကို ဖတ်ယူခဲ့သည်။ `readResource()` ကို `uri` ဖြင့် ခေါ်ယူခဲ့သည်။ Server ဘက်တွင် အောက်ပါအတိုင်း ဖြစ်နိုင်သည်-

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    Server တွင် `file://{name}` ဟု သတ်မှတ်ထားသော `uri` value `file://example.txt` နှင့် ကိုက်ညီသည်။ `example.txt` ကို `name` သို့ mapping ပြုလုပ်မည်။

- Tool တစ်ခုကို ခေါ်ယူခဲ့သည်။ `name` နှင့် `arguments` ကို သတ်မှတ်ပြီး ခေါ်ယူခဲ့သည်-

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Prompt တစ်ခုကို ရယူခဲ့သည်။ `getPrompt()` ကို `name` နှင့် `arguments` ဖြင့် ခေါ်ယူခဲ့သည်။ Server code သည် အောက်ပါအတိုင်း ဖြစ်နိုင်သည်-

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    Client code သည် Server တွင် သတ်မှတ်ထားသည့်အတိုင်း အောက်ပါအတိုင်း ဖြစ်ရမည်-

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

#### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

အထက်ပါ code တွင် ကျွန်တော်တို့-

- `read_resource` ကို အသုံးပြု၍ `greeting` ဟုခေါ်သော resource ကို ခေါ်ယူခဲ့သည်။
- `call_tool` ကို အသုံးပြု၍ `add` ဟုခေါ်သော tool ကို invoke ပြုလုပ်ခဲ့သည်။

#### .NET

1. Tool တစ်ခုကို ခေါ်ယူရန် အောက်ပါ code ကို ထည့်သွင်းပါ-

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. ရလဒ်ကို print ထုတ်ရန် အောက်ပါ code ကို အသုံးပြုပါ-

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

#### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

အထက်ပါ code တွင် ကျွန်တော်တို့-

- `CallToolRequest` object များနှင့် tool များကို `callTool()` method ဖြင့် ခေါ်ယူခဲ့သည်။
- Tool တစ်ခုချင်းစီအတွက် tool name နှင့် အဆိုပါ tool အတွက် လိုအပ်သော arguments များပါဝင်သည့် `Map` ကို သတ်မှတ်ခဲ့သည်။
- Server tools များသည် အထူး parameter အမည်များ (ဥပမာ- "a", "b" စသည်) ကို မျှော်မှန်းထားသည်။
- ရလဒ်များကို Server မှ ပြန်လာသော `CallToolResult` object များအဖြစ် ရရှိခဲ့သည်။

#### Rust

```rust
// Call add tool with arguments = {"a": 3, "b": 2}
let a = 3;
let b = 2;
let tool_result = client
    .call_tool(CallToolRequestParam {
        name: "add".into(),
        arguments: serde_json::json!({ "a": a, "b": b }).as_object().cloned(),
    })
    .await?;
println!("Result of {:?} + {:?}: {:?}", a, b, tool_result);
```

### -5- Client ကို run လုပ်ခြင်း

Client ကို run လုပ်ရန် terminal တွင် အောက်ပါ command ကို ရိုက်ထည့်ပါ-

#### TypeScript

*package.json* တွင် "scripts" အပိုင်းတွင် အောက်ပါ entry ကို ထည့်သွင်းပါ-

```json
"client": "tsc && node build/client.js"
```

```sh
npm run client
```

#### Python

Client ကို အောက်ပါ command ဖြင့် ခေါ်ပါ-

```sh
python client.py
```

#### .NET

```sh
dotnet run
```

#### Java

ပထမဦးစွာ MCP Server ကို `http://localhost:8080` တွင် run လုပ်ထားပါ။ ထို့နောက် client ကို run လုပ်ပါ-

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

မဟုတ်ရင် `03-GettingStarted\02-client\solution\java` folder တွင် ပံ့ပိုးထားသော အပြည့်အစုံ client project ကို run လုပ်နိုင်သည်-

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

#### Rust

```bash
cargo fmt
cargo run
```

## လုပ်ငန်းတာဝန်

ဒီလုပ်ငန်းတာဝန်တွင် သင်သည် client တစ်ခု ဖန်တီးခြင်းအတွက် သင်လေ့လာခဲ့သည့်အရာများကို အသုံးပြုမည်ဖြစ်ပြီး ကိုယ်ပိုင် client တစ်ခုကို ဖန်တီးရမည်။

အောက်ပါ Server ကို သင်၏ client code မှ ခေါ်ယူနိုင်ရန် အသုံးပြုပါ၊ Server ကို ပိုမိုစိတ်ဝင်စားစေရန် feature များကို ထည့်သွင်းကြည့်ပါ။

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

ဒီ project ကို ကြည့်ပါ- [add prompts and resources](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)။

ထို့အပြင် ဒီ link ကို ကြည့်ပါ- [prompts and resources](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/) ကို invoke ပြုလုပ်ပုံ။

### Rust

[ယခင်အပိုင်း](../../../../03-GettingStarted/01-first-server) တွင် MCP Server တစ်ခုကို Rust ဖြင့် ဖန်တီးပုံကို သင်လေ့လာခဲ့ပါသည်။ ထိုအပေါ် ဆက်လက်တည်ဆောက်နိုင်သလို၊ MCP Server Rust-based ဥပမာများအတွက် ဒီ link ကိုလည်း ကြည့်နိုင်သည်- [MCP Server Examples](https://github.com/modelcontextprotocol/rust-sdk/tree/main/examples/servers)

## ဖြေရှင်းချက်

**solution folder** တွင် ဒီသင်ခန်းစာတွင် ဖော်ပြထားသည့် အကြံဉာဏ်အားလုံးကို ပြသသည့် client implementation များပါဝင်သည်။ Solution တစ်ခုစီတွင် client နှင့် server code များကို သီးခြားစီ စီစဉ်ထားသည်။

### 📁 Solution Structure

Solution directory ကို programming language အလိုက် စီစဉ်ထားသည်-

```text
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw             # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
├── rust/                # Rust client implementation
|  ├── Cargo.lock        # Cargo lock file
|  ├── Cargo.toml        # Project configuration and dependencies
|  ├── src               # Source code
|  │   └── main.rs       # Main client code
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 Solution တစ်ခုစီတွင် ပါဝင်သောအရာများ

Language-specific solution တစ်ခုစီတွင် အောက်ပါအရာများ ပါဝင်သည်-

- **Client implementation အပြည့်အစုံ** (tutorial တွင်ဖော်ပြထားသည့် feature အားလုံးပါဝင်သည်)
- **Project structure အလုပ်လုပ်စေမှု** (လိုအပ်သော dependencies နှင့် configuration များပါဝင်သည်)
- **Build နှင့် run script များ** (setup နှင့် execution ကို လွယ်ကူစေသည်)
- **README အသေးစိတ်** (language-specific လမ်းညွှန်ချက်များပါဝင်သည်)
- **Error
တစ်ခုချင်းစီသော နမူနာများတွင် ပါဝင်သည် -

- ✅ **ချိတ်ဆက်မှု တည်ဆောက်ခြင်း** နှင့် အမှားကိုင်တွယ်မှု
- ✅ **ဆာဗာ ရှာဖွေမှု** (ကိရိယာများ၊ အရင်းအမြစ်များ၊ လိုအပ်သော အကြံပြုချက်များ)
- ✅ **ဂဏန်းတွက်စက် လုပ်ဆောင်ချက်များ** (ပေါင်းခြင်း၊ နုတ်ခြင်း၊ များခြင်း၊ ခွဲခြင်း၊ အကူအညီ)
- ✅ **ရလဒ်ကို ကိုင်တွယ်ခြင်း** နှင့် ဖော်ပြထားသော အထွေထွေထုတ်လွှင့်မှု
- ✅ **အကျုံးဝင်သော အမှားကိုင်တွယ်မှု**
- ✅ **သန့်ရှင်းပြီး မှတ်ချက်ထည့်ထားသော ကုဒ်များ** (အဆင့်ဆင့် မှတ်ချက်များဖြင့်)

### နမူနာများဖြင့် စတင်ခြင်း

1. အထက်ပါဇယားမှ **သင့်နှစ်သက်သော ဘာသာစကား** ကို ရွေးချယ်ပါ  
2. **နမူနာဖိုင်ကို ပြန်လည်သုံးသပ်ပါ** - အကောင်အထည်ဖော်မှုကို နားလည်ရန်  
3. [`complete_examples.md`](./complete_examples.md) တွင် ဖော်ပြထားသော လမ်းညွှန်ချက်များအတိုင်း **နမူနာကို အကောင်အထည်ဖော်ပါ**  
4. သင့်ရဲ့ အထူးလိုအပ်ချက်အတွက် **နမူနာကို ပြင်ဆင်ပြီး တိုးချဲ့ပါ**  

ဤနမူနာများကို အကောင်အထည်ဖော်ခြင်းနှင့် စိတ်ကြိုက်ပြင်ဆင်ခြင်းအကြောင်း အသေးစိတ်စာရွက်စာတမ်းများကို ဖတ်ရန် - **[📖 Complete Examples Documentation](./complete_examples.md)** ကို ကြည့်ပါ။

### 💡 Solution နှင့် Complete Examples အကြား ကွာခြားချက်

| **Solution Folder** | **Complete Examples** |
|--------------------|--------------------- |
| Build ဖိုင်များပါဝင်သော အပြည့်အစုံ Project ဖွဲ့စည်းမှု | Single-file အကောင်အထည်ဖော်မှုများ |
| Dependencies ဖြင့် ချက်ချင်း အသုံးပြုနိုင် | အဓိကထားသော ကုဒ်နမူနာများ |
| ထုတ်လုပ်မှုဆိုင်ရာ အခြေအနေများနှင့် ဆင်တူသော Setup | ပညာရေးဆိုင်ရာ ရည်ညွှန်းချက် |
| ဘာသာစကားအလိုက် Tooling | ဘာသာစကားများကို နှိုင်းယှဉ်ခြင်း |

နည်းလမ်းနှစ်မျိုးစလုံး အကျိုးရှိသည် - **Solution Folder** ကို အပြည့်အစုံ Project များအတွက် အသုံးပြုပါ၊ **Complete Examples** ကို သင်ယူမှုနှင့် ရည်ညွှန်းချက်အတွက် အသုံးပြုပါ။

## အဓိက အချက်များ

ဤအခန်းအတွက် အဓိက အချက်များမှာ -

- Client များသည် ဆာဗာပေါ်တွင် လုပ်ဆောင်ချက်များကို ရှာဖွေခြင်းနှင့် ခေါ်ယူခြင်းနှစ်မျိုးလုံးအတွက် အသုံးပြုနိုင်သည်။
- Client များသည် (ဤအခန်းတွင် ဖော်ပြထားသည့်အတိုင်း) ကိုယ်တိုင် စတင်စဉ် ဆာဗာကို စတင်နိုင်သလို၊ လည်ပတ်နေသော ဆာဗာများနှင့်လည်း ချိတ်ဆက်နိုင်သည်။
- Client များသည် အခြားရွေးချယ်စရာများ (ဥပမာ - ယခင်အခန်းတွင် ဖော်ပြထားသည့် Inspector) နှင့်အတူ ဆာဗာ၏ စွမ်းရည်များကို စမ်းသပ်ရန် အကောင်းဆုံးနည်းလမ်းတစ်ခုဖြစ်သည်။

## ထပ်မံလေ့လာရန် အရင်းအမြစ်များ

- [MCP တွင် Client များ တည်ဆောက်ခြင်း](https://modelcontextprotocol.io/quickstart/client)

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)
- [Rust Calculator](../../../../03-GettingStarted/samples/rust)

## နောက်တစ်ဆင့်

- နောက်တစ်ဆင့်: [LLM ဖြင့် Client တစ်ခု ဖန်တီးခြင်း](../03-llm-client/README.md)

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်ပါ။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ အတည်ပြုထားသော ဘာသာပြန်မှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပာယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။