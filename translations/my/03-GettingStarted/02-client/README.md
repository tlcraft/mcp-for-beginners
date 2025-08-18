<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "94c80ae71fb9971e9b57b51ab0912121",
  "translation_date": "2025-08-18T18:57:47+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "my"
}
-->
# Client တစ်ခု ဖန်တီးခြင်း

Client များသည် MCP Server နှင့်တိုက်ရိုက်ဆက်သွယ်ပြီး အရင်းအမြစ်များ၊ ကိရိယာများနှင့် prompt များကို တောင်းဆိုနိုင်သော အထူး application များ သို့မဟုတ် script များဖြစ်သည်။ Server ကိုအသုံးပြုရန် graphical interface ပေးသော inspector tool ကို အသုံးပြုခြင်းနှင့်မတူဘဲ၊ ကိုယ်ပိုင် client ရေးသားခြင်းသည် programmatic နှင့် automated အဆက်အသွယ်များကို ခွင့်ပြုသည်။ ဒါက developer များကို MCP ရဲ့စွမ်းရည်များကို ကိုယ်ပိုင် workflow များထဲတွင် ပေါင်းစပ်နိုင်ရန်၊ အလုပ်များကို အလိုအလျောက်လုပ်ဆောင်နိုင်ရန်နှင့် သတ်မှတ်လိုက်သော လိုအပ်ချက်များအတွက် အထူးဖြေရှင်းချက်များ တည်ဆောက်နိုင်ရန် ခွင့်ပြုသည်။

## အကျဉ်းချုပ်

ဒီသင်ခန်းစာမှာ Model Context Protocol (MCP) ecosystem အတွင်း client များ၏ အယူအဆကို မိတ်ဆက်ပေးမှာဖြစ်ပါတယ်။ သင်ကိုယ်တိုင် client ရေးသားပြီး MCP Server နှင့် ချိတ်ဆက်ပုံကို သင်ယူနိုင်ပါမည်။

## သင်ယူရမည့်ရည်ရွယ်ချက်များ

ဒီသင်ခန်းစာအဆုံးသတ်ချိန်မှာ သင်သည် အောက်ပါအရာများကို နားလည်နိုင်ပါမည်-

- Client တစ်ခုက ဘာလုပ်နိုင်သလဲဆိုတာ နားလည်ခြင်း။
- ကိုယ်ပိုင် client ရေးသားခြင်း။
- MCP Server နှင့် client ကို ချိတ်ဆက်ပြီး Server သည် မျှော်မှန်းထားသလို အလုပ်လုပ်နေကြောင်း စမ်းသပ်ခြင်း။

## Client ရေးသားခြင်းတွင် ပါဝင်သည့်အရာများ

Client ရေးသားရန်အတွက် အောက်ပါအရာများကို လုပ်ဆောင်ရမည်-

- **လိုအပ်သော library များကို import လုပ်ပါ**။ အရင်အသုံးပြုခဲ့သော library ကိုပဲ အသုံးပြုမည်ဖြစ်ပြီး construct များကတော့ ကွဲပြားပါမည်။
- **Client တစ်ခုကို instantiate လုပ်ပါ**။ ဒါက client instance တစ်ခုကို ဖန်တီးပြီး ရွေးချယ်ထားသော transport method နှင့် ချိတ်ဆက်ရန် ပါဝင်ပါမည်။
- **List လုပ်မည့် resource များကို ဆုံးဖြတ်ပါ**။ MCP Server တွင် resource များ၊ tool များနှင့် prompt များ ပါဝင်ပြီး သင် list လုပ်မည့်အရာကို ဆုံးဖြတ်ရပါမည်။
- **Client ကို host application နှင့် ပေါင်းစပ်ပါ**။ Server ၏စွမ်းရည်များကို သိရှိပြီးနောက် host application နှင့် ပေါင်းစပ်ရပါမည်။ ဒါမှသာ user က prompt သို့မဟုတ် command တစ်ခုရိုက်ထည့်သောအခါ သက်ဆိုင်သော Server feature ကို invoke လုပ်နိုင်ပါမည်။

အခုတော့ ကျွန်တော်တို့ ဘာလုပ်မလဲဆိုတာ အထွေထွေသဘောထားနားလည်ပြီးနောက်၊ နောက်အပိုင်းမှာ ဥပမာတစ်ခုကို ကြည့်လိုက်ရအောင်။

### Client ဥပမာတစ်ခု

ဒီ client ဥပမာကို ကြည့်လိုက်ရအောင်-

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

အထက်ပါ code တွင်-

- Library များကို import လုပ်ထားသည်။
- Client တစ်ခုကို instantiate လုပ်ပြီး stdio ကို transport အဖြစ် အသုံးပြု၍ ချိတ်ဆက်ထားသည်။
- Prompt များ၊ resource များနှင့် tool များကို list လုပ်ပြီး အားလုံးကို invoke လုပ်ထားသည်။

ဒီမှာ MCP Server နှင့် ဆက်သွယ်နိုင်သော client တစ်ခု ရရှိပါပြီ။

နောက် exercise အပိုင်းတွင် code snippet တစ်ခုချင်းစီကို ခွဲခြမ်းရှင်းလင်းပြီး ဘာဖြစ်နေသလဲဆိုတာ ရှင်းပြမည်။

## Exercise: Client ရေးသားခြင်း

အထက်မှာ ပြောခဲ့သလို code ကို ရှင်းပြရင်း coding လုပ်ချင်ရင် code along လုပ်နိုင်ပါတယ်။

### -1- Library များ Import လုပ်ခြင်း

လိုအပ်သော library များကို import လုပ်ပါ။ Client နှင့် ရွေးချယ်ထားသော transport protocol, stdio ကို reference လုပ်ရန်လိုအပ်ပါမည်။ stdio သည် local machine ပေါ်တွင် run မည့်အရာများအတွက် protocol တစ်ခုဖြစ်သည်။ SSE သည် နောက် chapters တွင် ပြသမည့် transport protocol တစ်ခုဖြစ်ပြီး ဒါကတော့ သင့်အခြားရွေးချယ်မှုဖြစ်သည်။ အခုတော့ stdio ဖြင့် ဆက်လက်လုပ်ဆောင်ကြရအောင်။

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

Java အတွက် MCP Server နှင့် ချိတ်ဆက်မည့် client တစ်ခုကို ရေးသားရမည်။ [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) မှ Java Spring Boot project structure ကို အသုံးပြု၍ `SDKClient` ဟုခေါ်သော Java class တစ်ခုကို `src/main/java/com/microsoft/mcp/sample/client/` folder တွင် ဖန်တီးပြီး အောက်ပါ imports များကို ထည့်သွင်းပါ။

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

`Cargo.toml` file တွင် အောက်ပါ dependencies များကို ထည့်သွင်းရန်လိုအပ်ပါမည်။

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

ထို့နောက် client code တွင် လိုအပ်သော library များကို import လုပ်နိုင်ပါမည်။

```rust
use rmcp::{
    RmcpError,
    model::CallToolRequestParam,
    service::ServiceExt,
    transport::{ConfigureCommandExt, TokioChildProcess},
};
use tokio::process::Command;
```

အခုတော့ instantiation ကို ဆက်လက်လုပ်ဆောင်ကြရအောင်။

### -2- Client နှင့် Transport ကို Instantiate လုပ်ခြင်း

Transport နှင့် Client တစ်ခုကို instantiate လုပ်ရန်လိုအပ်ပါမည်-

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

အထက်ပါ code တွင်-

- stdio transport instance တစ်ခုကို ဖန်တီးထားသည်။ Command နှင့် args ကို သတ်မှတ်ထားပုံကို သတိပြုပါ၊ ဒါက Server ကို ရှာဖွေပြီး start လုပ်ရန်လိုအပ်သောအရာဖြစ်သည်။

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Client တစ်ခုကို name နှင့် version ဖြင့် instantiate လုပ်ထားသည်။

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Client ကို ရွေးချယ်ထားသော transport နှင့် ချိတ်ဆက်ထားသည်။

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

အထက်ပါ code တွင်-

- လိုအပ်သော library များကို import လုပ်ထားသည်။
- Server parameters object တစ်ခုကို instantiate လုပ်ထားသည်၊ ဒါကို Server ကို run လုပ်ရန် အသုံးပြုမည်။
- `run` method ကို သတ်မှတ်ထားပြီး `stdio_client` ကို ခေါ်သည့် client session တစ်ခုကို start လုပ်သည်။
- Entry point တစ်ခုကို ဖန်တီးထားပြီး `asyncio.run` ကို `run` method ဖြင့် ပေးထားသည်။

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

အထက်ပါ code တွင်-

- လိုအပ်သော library များကို import လုပ်ထားသည်။
- stdio transport တစ်ခုကို ဖန်တီးပြီး `mcpClient` ဟုခေါ်သော client တစ်ခုကို ဖန်တီးထားသည်။ ဒါကို MCP Server ပေါ်တွင် feature များကို list လုပ်ရန်နှင့် invoke လုပ်ရန် အသုံးပြုမည်။

Note, "Arguments" တွင် *.csproj* သို့မဟုတ် executable ကို ရည်ညွှန်းနိုင်သည်။

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

အထက်ပါ code တွင်-

- Main method တစ်ခုကို ဖန်တီးထားပြီး SSE transport ကို `http://localhost:8080` သို့ ရည်ညွှန်းထားသည်၊ MCP Server သည် အဲဒီနေရာတွင် run လုပ်နေမည်။
- Transport ကို constructor parameter အဖြစ်ယူသော client class တစ်ခုကို ဖန်တီးထားသည်။
- `run` method တွင် synchronous MCP client တစ်ခုကို transport ဖြင့် ဖန်တီးပြီး connection ကို initialize လုပ်ထားသည်။
- SSE (Server-Sent Events) transport ကို အသုံးပြုထားပြီး Java Spring Boot MCP Server များနှင့် HTTP-based communication အတွက် သင့်လျော်သည်။

#### Rust

Rust client သည် "calculator-server" ဟုခေါ်သော sibling project ကို directory တူတူတွင် run လုပ်မည်ဟု ချက်ချင်း သတ်မှတ်ထားသည်။ အောက်ပါ code သည် Server ကို start လုပ်ပြီး connect လုပ်မည်။

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

### -3- Server Features များကို List လုပ်ခြင်း

အခုတော့ program ကို run လုပ်ပါက client သည် connect လုပ်နိုင်ပါမည်။ သို့သော် features များကို list မလုပ်သေးပါ။ အခုတော့ list လုပ်ကြရအောင်-

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

ဒီမှာ resource များကို `list_resources()` ဖြင့်၊ tool များကို `list_tools` ဖြင့် list လုပ်ပြီး print ထုတ်ထားသည်။

#### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

အထက်ပါ code သည် Server ပေါ်တွင် tool များကို list လုပ်ပုံကို ပြထားသည်။ Tool တစ်ခုချင်းစီအတွက် name ကို print ထုတ်ထားသည်။

#### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

အထက်ပါ code တွင်-

- MCP Server မှ tool များအားလုံးကို `listTools()` ဖြင့် ရယူထားသည်။
- Server နှင့် connection အလုပ်လုပ်နေကြောင်း `ping()` ဖြင့် စမ်းသပ်ထားသည်။
- `ListToolsResult` တွင် tool များ၏ name, description နှင့် input schema များပါဝင်သည်။

အခုတော့ feature များအားလုံးကို capture လုပ်ထားပါပြီ။ အခုတော့ feature များကို ဘယ်အချိန်မှာ အသုံးပြုမလဲဆိုတာ စဉ်းစားရမည်။ ဒီ client သည် ရိုးရှင်းသော client ဖြစ်ပြီး feature များကို အသုံးပြုလိုသောအခါ explicit call လုပ်ရန်လိုအပ်ပါမည်။ နောက် chapter တွင် ကိုယ်ပိုင် large language model (LLM) ရှိသော ပိုမိုအဆင့်မြင့် client တစ်ခုကို ဖန်တီးမည်။ အခုတော့ Server ပေါ်တွင် feature များကို invoke လုပ်ပုံကို ကြည့်လိုက်ရအောင်-

#### Rust

Main function တွင် client ကို initialize လုပ်ပြီး Server ကို initialize လုပ်ကာ feature များကို list လုပ်နိုင်ပါမည်။

```rust
// Initialize
let server_info = client.peer_info();
println!("Server info: {:?}", server_info);

// List tools
let tools = client.list_tools(Default::default()).await?;
println!("Available tools: {:?}", tools);
```

### -4- Feature များကို Invoke လုပ်ခြင်း

Feature များကို invoke လုပ်ရန် argument များနှင့် invoke လုပ်လိုသော name ကို သေချာ specify လုပ်ရန်လိုအပ်ပါမည်။

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

အထက်ပါ code တွင်-

- Resource တစ်ခုကို `readResource()` ဖြင့် call လုပ်ထားသည်၊ `uri` ကို specify လုပ်ထားသည်။ Server ပေါ်တွင် အောက်ပါအတိုင်း ဖြစ်နိုင်ပါသည်-

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

    Client မှ `uri` value `file://example.txt` သည် Server ပေါ်တွင် `file://{name}` နှင့် ကိုက်ညီသည်။ `example.txt` ကို `name` သို့ map လုပ်မည်။

- Tool တစ်ခုကို `name` နှင့် `arguments` specify လုပ်ကာ call လုပ်ထားသည်-

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Prompt တစ်ခုကို `name` နှင့် `arguments` ဖြင့် `getPrompt()` ကို call လုပ်ထားသည်။ Server code သည် အောက်ပါအတိုင်း ဖြစ်နိုင်ပါသည်-

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

    Client code သည် Server ပေါ်တွင် သတ်မှတ်ထားသောအတိုင်း အောက်ပါအတိုင်း ဖြစ်နိုင်ပါသည်-

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

အထက်ပါ code တွင်-

- `read_resource` ဖြင့် `greeting` ဟုခေါ်သော resource ကို call လုပ်ထားသည်။
- `call_tool` ဖြင့် `add` ဟုခေါ်သော tool ကို invoke လုပ်ထားသည်။

#### .NET

1. Tool တစ်ခုကို call လုပ်ရန် code ထည့်ပါ-

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Result ကို print ထုတ်ရန် အောက်ပါ code ကို အသုံးပြုပါ-

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

အထက်ပါ code တွင်-

- `CallToolRequest` object များဖြင့် `callTool()` method ကို အသုံးပြုကာ calculator tool များကို call လုပ်ထားသည်။
- Tool တစ်ခု call လုပ်ရာတွင် tool name နှင့် tool အတွက်လိုအပ်သော arguments များကို `Map` အဖြစ် specify လုပ်ထားသည်။
- Server tool များသည် သတ်မှတ်ထားသော parameter name များ (ဥပမာ- "a", "b" mathematical operations အတွက်) ကို မျှော်မှန်းထားသည်။
- Result များကို Server မှ response ပါဝင်သော `CallToolResult` object အဖြစ် ပြန်လည်ရရှိသည်။

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

### -5- Client ကို Run လုပ်ခြင်း

Client ကို terminal တွင် အောက်ပါ command ဖြင့် run လုပ်ပါ-

#### TypeScript

*package.json* တွင် "scripts" section တွင် အောက်ပါ entry ကို ထည့်ပါ-

```json
"client": "tsc && node build/client.js"
```

```sh
npm run client
```

#### Python

Client ကို အောက်ပါ command ဖြင့် call လုပ်ပါ-

```sh
python client.py
```

#### .NET

```sh
dotnet run
```

#### Java

MCP Server ကို `http://localhost:8080` တွင် run လုပ်ထားကြောင်း သေချာပါစေ။ Client ကို run လုပ်ပါ-

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

အခြားနည်းလမ်းအဖြစ် `03-GettingStarted\02-client\solution\java` folder တွင်ပါဝင်သော complete client project ကို run လုပ်နိုင်ပါသည်-

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

## Assignment

ဒီ assignment တွင် သင်သင်ယူခဲ့သောအရာများကို အသုံးပြုကာ ကိုယ်ပိုင် client တစ်ခုကို ဖန်တီးရမည်။

အောက်ပါ Server ကို သုံးပြီး သင့် client code မှ call လုပ်ပါ၊ Server ကို feature များ ပိုမိုစိတ်ဝင်စားဖွယ်ဖြစ်စေရန် ထည့်သွင်းနိုင်မည်။

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

ဒီ project ကိုကြည့်ကာ [prompt နှင့် resource များ ထည့်သွင်းပုံ](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs) ကို လေ့လာပါ။

ထို့အပြင် [prompt နှင့် resource များကို invoke လုပ်ပုံ](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/) ကိုလည်း ကြည့်ပါ။

### Rust

[ယခင်အပိုင်း](../../../../03-GettingStarted/01-first-server) တွင် MCP Server ရေးသားပုံကို သင်ယူခဲ့ပါသည်။ အဲဒီအပေါ် ဆက်လက်တည်ဆောက်နိုင်သလို MCP Server Rust-based ဥပမာများကို [ဒီ link](https://github.com/modelcontextprotocol/rust-sdk/tree/main/examples/servers) တွင်လည်း ကြည့်နိုင်ပါသည်။

## Solution

**solution folder** တွင် tutorial တွင်ဖော်ပြထားသော concept များအားလုံးကို ပြသထားသော complete, ready-to-run client implementation များ ပါဝင်သည်။ Solution တစ်ခုစီတွင် client နှင့် server code များကို သီးခြား project များအဖြစ် စနစ်တကျ စုစည်းထားသည်။

### 📁 Solution Structure

Solution directory ကို programming language အလိုက် စုစည်းထားသည်-

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

Language-specific solution တစ်ခုစီတွင်-

- **Complete client implementation** tutorial တွင်ဖော်ပြထားသော feature အားလုံးပါဝင်သည်။
- **Working project structure** dependency နှင့် configuration များကို သေချာပြုလုပ်ထားသည်။
- **Build နှင့် run scripts** setup နှင့် execution ကို လွယ်ကူစေရန်။
- **Detailed README** language-specific လမ်းညွှန်ချက်များပါဝင်သည်။
- **Error handling** နှင့် result ကို process လုပ်ပုံ ဥပမာများပါဝင်သည်။

### 📖 Solution များကို အသုံးပြုခြင်း

1. **သင့် language folder ကို ရွေးပါ**:

   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **README လမ်းညွှန်ချက်များကို လိုက်နာပါ**:
   - Dependency များ install လုပ်ခြင်း
   - Project ကို build လုပ်ခြင်း
   - Client ကို run လုပ်ခြင်း

3. **Example output** သင်မြင်ရမည့်အရာ:

   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Complete documentation နှင့် လမ်းညွှန်ချက်များအတွက် **[📖 Solution Documentation](./solution/README.md)** ကို ကြည့်ပါ။

## 🎯 Complete Examples

Tutorial တွင်ဖော်ပြထားသော functionality အားလုံးကို ပြသထားသော complete, working client implementation များကို ပေးထားပါသည်။ ဤဥပမာများကို reference implementation သို့မဟုတ် သင့်ကိုယ်ပိုင် project မ
### အပြည့်အစုံသော ဥပမာများနှင့် စတင်ခြင်း

1. **သင့်နှစ်သက်သော ဘာသာစကား** ကို အထက်ပါဇယားမှ ရွေးပါ။
2. **အပြည့်အစုံသော ဥပမာဖိုင်ကို** ပြန်လည်သုံးသပ်ပြီး အကောင်အထည်ဖော်မှုကို နားလည်ပါ။
3. **ဥပမာကို အကောင်အထည်ဖော်ရန်** [`complete_examples.md`](./complete_examples.md) တွင် ရှိသော လမ်းညွှန်ချက်များကို လိုက်နာပါ။
4. **သင့်ရည်ရွယ်ချက်အတွက်** ဥပမာကို ပြင်ဆင်ပြီး တိုးချဲ့ပါ။

ဤဥပမာများကို အကောင်အထည်ဖော်ခြင်းနှင့် စိတ်ကြိုက်ပြင်ဆင်ခြင်းအကြောင်း အသေးစိတ်လမ်းညွှန်ချက်များကို **[📖 အပြည့်အစုံသော ဥပမာများ လမ်းညွှန်ချက်](./complete_examples.md)** တွင် ကြည့်ရှုနိုင်ပါသည်။

### 💡 ဖြေရှင်းချက်နှင့် အပြည့်အစုံသော ဥပမာများ

| **ဖြေရှင်းချက် ဖိုလ်ဒါ** | **အပြည့်အစုံသော ဥပမာများ** |
|--------------------|--------------------- |
| Build ဖိုင်များပါဝင်သော စီမံကိန်းအဆောက်အအုံ | Single-file အကောင်အထည်ဖော်မှုများ |
| Dependencies ဖြင့် ချက်ချင်း အသုံးပြုနိုင် | အဓိကထားသော ကုဒ်ဥပမာများ |
| ထုတ်လုပ်မှုဆိုင်ရာ အဆင့်ဆင့် | ပညာရေးဆိုင်ရာ ရည်ညွှန်းချက် |
| ဘာသာစကားအလိုက် Tools | ဘာသာစကားများနှိုင်းယှဉ်မှု |

နှစ်မျိုးလုံး အရေးပါသည် - **ဖြေရှင်းချက် ဖိုလ်ဒါ** ကို အပြည့်အစုံသော စီမံကိန်းများအတွက် အသုံးပြုပါ၊ **အပြည့်အစုံသော ဥပမာများ** ကို သင်ယူခြင်းနှင့် ရည်ညွှန်းချက်အတွက် အသုံးပြုပါ။

## အဓိကအချက်များ

ဤအခန်း၏ အဓိကအချက်များမှာ client များနှင့် ပတ်သက်၍ အောက်ပါအချက်များဖြစ်သည်-

- Server တွင် ရှာဖွေခြင်းနှင့် လုပ်ဆောင်မှုများကို client မှ အသုံးပြုနိုင်သည်။
- Server ကို client ကို စတင်စဉ်တစ်ချိန်တည်း စတင်နိုင်သလို (ဤအခန်းတွင် ပြထားသည့်အတိုင်း) ရှိပြီးသား server များနှင့် ချိတ်ဆက်နိုင်သည်။
- Server ၏ စွမ်းရည်များကို စမ်းသပ်ရန် client သည် Inspector ကဲ့သို့သော အခြားရွေးချယ်မှုများနှင့် အတူ အသုံးဝင်သော နည်းလမ်းတစ်ခုဖြစ်သည်။

## ထပ်ဆောင်းအရင်းအမြစ်များ

- [MCP တွင် client များ တည်ဆောက်ခြင်း](https://modelcontextprotocol.io/quickstart/client)

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)
- [Rust Calculator](../../../../03-GettingStarted/samples/rust)

## အတက်အကျ

- နောက်တစ်ခု: [LLM ဖြင့် client တစ်ခု တည်ဆောက်ခြင်း](../03-llm-client/README.md)

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။