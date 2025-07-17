<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T12:45:19+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "my"
}
-->
# Client တစ်ခု ဖန်တီးခြင်း

Clients ဆိုသည်မှာ MCP Server နှင့် တိုက်ရိုက် ဆက်သွယ်၍ အရင်းအမြစ်များ၊ ကိရိယာများနှင့် prompt များကို တောင်းဆိုနိုင်သော စိတ်ကြိုက် application များ သို့မဟုတ် script များဖြစ်သည်။ Server နှင့် ဆက်သွယ်ရာတွင် graphical interface ပေးသော inspector tool ကို အသုံးပြုခြင်းနှင့် မတူဘဲ၊ ကိုယ်ပိုင် client ကို ရေးသားခြင်းဖြင့် ပရိုဂရမ်ရေးသားခြင်းနှင့် အလိုအလျောက်လုပ်ဆောင်မှုများ ပြုလုပ်နိုင်သည်။ ၎င်းက developer များအား MCP ၏ စွမ်းဆောင်ရည်များကို ကိုယ်ပိုင် workflow များထဲသို့ ပေါင်းစပ်နိုင်ရန်၊ အလုပ်များကို အလိုအလျောက်လုပ်ဆောင်ရန်နှင့် လိုအပ်ချက်အလိုက် စိတ်ကြိုက် ဖြေရှင်းချက်များ တည်ဆောက်ရန် အခွင့်အလမ်းပေးသည်။

## အနှစ်ချုပ်

ဤသင်ခန်းစာတွင် Model Context Protocol (MCP) ပတ်ဝန်းကျင်အတွင်း client များ၏ အယူအဆကို မိတ်ဆက်ပေးမည်ဖြစ်သည်။ ကိုယ်ပိုင် client ကို ဘယ်လိုရေးသားရမည်နှင့် MCP Server နှင့် ဘယ်လိုချိတ်ဆက်ရမည်ကို သင်ယူမည်ဖြစ်သည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးသတ်သည်အထိ သင်သည် -

- Client တစ်ခုက ဘာလုပ်နိုင်သည်ကို နားလည်နိုင်မည်။
- ကိုယ်ပိုင် client ကို ရေးသားနိုင်မည်။
- MCP server နှင့် client ကို ချိတ်ဆက်ပြီး စမ်းသပ်နိုင်မည်။

## Client ရေးသားရာတွင် လိုအပ်သည့် အချက်များ

Client ရေးသားရန်အတွက် အောက်ပါအချက်များ လိုအပ်ပါသည် -

- **မှန်ကန်သော library များကို import ပြုလုပ်ရန်**။ ယခင်က အသုံးပြုခဲ့သည့် library တူညီသော်လည်း ဖွဲ့စည်းပုံကွဲပြားမှုရှိသည်။
- **Client instance တစ်ခု ဖန်တီးရန်**။ Client instance တစ်ခု ဖန်တီးပြီး ရွေးချယ်ထားသော transport method နှင့် ချိတ်ဆက်ရမည်။
- **စာရင်းပြုစုမည့် အရင်းအမြစ်များကို ဆုံးဖြတ်ရန်**။ MCP server တွင် ရရှိနိုင်သည့် resources, tools နှင့် prompts များရှိပြီး၊ မည်သည်ကို စာရင်းပြုစုမည်ကို ဆုံးဖြတ်ရမည်။
- **Client ကို host application နှင့် ပေါင်းစပ်ရန်**။ Server ၏ စွမ်းဆောင်ရည်များကို သိရှိပြီးနောက်၊ အသုံးပြုသူက prompt သို့မဟုတ် အမိန့်တစ်ခု ရိုက်ထည့်သည့်အခါ ဆက်စပ် server feature ကို ဖော်ဆောင်နိုင်ရန် host application ထဲသို့ ပေါင်းစပ်ရမည်။

အထက်ပါ အကြောင်းအရာများကို နားလည်သွားပြီဆိုရင် နောက်တစ်ဆင့် အကြောင်းအရာကို ဥပမာဖြင့် ကြည့်ကြရအောင်။

### Client ဥပမာတစ်ခု

ဤ client ဥပမာကို ကြည့်ကြရအောင် -

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

အထက်ပါ ကုဒ်တွင် -

- Library များကို import ပြုလုပ်သည်။
- Client instance တစ်ခု ဖန်တီးပြီး stdio ကို transport အဖြစ် အသုံးပြု၍ ချိတ်ဆက်သည်။
- Prompts, resources နှင့် tools များကို စာရင်းပြုစုပြီး အားလုံးကို ဖော်ဆောင်သည်။

ဒါဆိုရင် MCP Server နှင့် ဆက်သွယ်နိုင်သော client တစ်ခု ရှိသွားပြီဖြစ်သည်။

နောက်တစ်ဆင့်တွင် ကုဒ်အပိုင်းအစ တစ်ခုချင်းစီကို ခွဲခြမ်းစိတ်ဖြာပြီး အကြောင်းအရာကို ရှင်းပြပါမည်။

## လေ့ကျင့်ခန်း - Client ရေးသားခြင်း

အထက်တွင် ပြောခဲ့သလို ကုဒ်ကို နားလည်စွာ ရှင်းပြပြီး လိုလျှင် ကိုယ်တိုင်လည်း ရေးသားကြည့်ပါ။

### -1- Library များကို import ပြုလုပ်ခြင်း

လိုအပ်သော library များကို import ပြုလုပ်ပါမည်။ Client နှင့် ရွေးချယ်ထားသော transport protocol stdio အတွက် ရည်ညွှန်းချက်များ လိုအပ်ပါသည်။ stdio သည် သင့် local machine ပေါ်တွင် run ရန် ရည်ရွယ်ထားသော protocol ဖြစ်သည်။ SSE သည် နောက်ပိုင်းအခန်းများတွင် ပြသမည့် transport protocol တစ်ခုဖြစ်ပြီး အခြားရွေးချယ်စရာဖြစ်သည်။ ယခုအခါတွင် stdio ဖြင့် ဆက်လက်လုပ်ဆောင်ကြမည်။

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

Java အတွက် MCP server နှင့် ချိတ်ဆက်မည့် client ကို ယခင်လေ့ကျင့်ခန်းမှ Java Spring Boot project ဖွဲ့စည်းပုံကို အသုံးပြု၍ `src/main/java/com/microsoft/mcp/sample/client/` ဖိုလ်ဒါအတွင်း `SDKClient` ဆိုသော Java class အသစ်တစ်ခု ဖန်တီးပြီး အောက်ပါ import များ ထည့်သွင်းပါ။

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

အခုတော့ instantiation ဆက်လုပ်ကြရအောင်။

### -2- Client နှင့် transport ကို instantiate ပြုလုပ်ခြင်း

Transport နှင့် client instance များ ဖန်တီးရမည်။

### TypeScript

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

အထက်ပါ ကုဒ်တွင် -

- stdio transport instance တစ်ခု ဖန်တီးထားသည်။ Server ကို ရှာဖွေစတင်ရန် command နှင့် args များကို သတ်မှတ်ထားသည်။

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Client ကို name နှင့် version ဖြင့် instantiate ပြုလုပ်ထားသည်။

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

အထက်ပါ ကုဒ်တွင် -

- လိုအပ်သော library များကို import ပြုလုပ်ထားသည်။
- Server parameters object တစ်ခု instantiate ပြုလုပ်ထားသည်။ ၎င်းကို server run ရန် အသုံးပြုမည်။
- `run` method တစ်ခု သတ်မှတ်ထားပြီး ၎င်းသည် `stdio_client` ကို ခေါ်၍ client session စတင်သည်။
- `asyncio.run` ကို အသုံးပြု၍ entry point တစ်ခု ဖန်တီးထားသည်။

### .NET

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

အထက်ပါ ကုဒ်တွင် -

- လိုအပ်သော library များကို import ပြုလုပ်ထားသည်။
- stdio transport တစ်ခု ဖန်တီးပြီး `mcpClient` ဆိုသော client တစ်ခု ဖန်တီးထားသည်။ ၎င်းကို MCP Server ၏ features များကို စာရင်းပြုစုခြင်းနှင့် ဖော်ဆောင်ရာတွင် အသုံးပြုမည်။

မှတ်ချက် - "Arguments" တွင် *.csproj* သို့မဟုတ် executable ကို ရည်ညွှန်းနိုင်သည်။

### Java

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

အထက်ပါ ကုဒ်တွင် -

- MCP server ရှိမည့် `http://localhost:8080` ကို ရည်ညွှန်းသည့် SSE transport ကို main method တွင် ဖန်တီးထားသည်။
- Transport ကို constructor parameter အဖြစ် လက်ခံသည့် client class တစ်ခု ဖန်တီးထားသည်။
- `run` method တွင် transport ဖြင့် synchronous MCP client တစ်ခု ဖန်တီးပြီး ချိတ်ဆက်မှု စတင်ထားသည်။
- Java Spring Boot MCP servers နှင့် HTTP-based ဆက်သွယ်မှုအတွက် သင့်တော်သော SSE (Server-Sent Events) transport ကို အသုံးပြုထားသည်။

### -3- Server features များကို စာရင်းပြုစုခြင်း

ယခု client သည် program run လုပ်ပါက server နှင့် ချိတ်ဆက်နိုင်ပါသည်။ သို့သော် features များကို စာရင်းပြုစုခြင်း မရှိသေးပါ။ ထို့ကြောင့် အောက်ပါအတိုင်း ဆက်လုပ်ကြရအောင် -

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

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
```

ဒီမှာ available resources များ `list_resources()` နှင့် tools များ `list_tools` ကို စာရင်းပြုစုပြီး ထုတ်ပြထားသည်။

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

အထက်ပါ ကုဒ်သည် server ပေါ်ရှိ tools များကို စာရင်းပြုစုနည်း ဥပမာဖြစ်သည်။ tool တစ်ခုချင်းစီအတွက် အမည်ကို ထုတ်ပြသည်။

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

အထက်ပါ ကုဒ်တွင် -

- MCP server မှ ရရှိနိုင်သည့် tools များအား `listTools()` ဖြင့် ခေါ်ယူထားသည်။
- Server နှင့် ချိတ်ဆက်မှုကို စစ်ဆေးရန် `ping()` ကို အသုံးပြုထားသည်။
- `ListToolsResult` တွင် tools များ၏ အမည်၊ ဖော်ပြချက်နှင့် input schema များ ပါဝင်သည်။

အဆင်ပြေပါပြီ။ ယခု features များကို ဘယ်အချိန်တွင် အသုံးပြုမလဲ? ဤ client သည် ရိုးရှင်းပြီး features များကို လိုချင်သည့်အခါ တိုက်ရိုက် ခေါ်ယူရမည်ဖြစ်သည်။ နောက်အခန်းတွင် ကိုယ်ပိုင် LLM ပါဝင်သည့် client တစ်ခု ဖန်တီးမည်ဖြစ်သည်။ ယခုအခါ server features များကို ဘယ်လို ဖော်ဆောင်မလဲ ကြည့်ကြရအောင်။

### -4- Features များကို ဖော်ဆောင်ခြင်း

Features များကို ဖော်ဆောင်ရန် မှန်ကန်သော arguments များနှင့် တချို့အခါတွင် ဖော်ဆောင်လိုသည့် အမည်ကို သတ်မှတ်ရမည်။

### TypeScript

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

အထက်ပါ ကုဒ်တွင် -

- Resource တစ်ခုကို ဖတ်ရန် `readResource()` ကို `uri` ဖြင့် ခေါ်သည်။ Server ဘက်တွင် အောက်ပါအတိုင်း ဖြစ်နိုင်သည် -

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

    ကျွန်ုပ်တို့၏ `uri` တန်ဖိုး `file://example.txt` သည် server ၏ `file://{name}` နှင့် ကိုက်ညီသည်။ `example.txt` ကို `name` အဖြစ် သတ်မှတ်သည်။

- Tool တစ်ခုကို ခေါ်ရန် `name` နှင့် `arguments` ဖြင့် ခေါ်သည် -

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Prompt ရယူရန် `getPrompt()` ကို `name` နှင့် `arguments` ဖြင့် ခေါ်သည်။ Server ကုဒ်မှာ အောက်ပါအတိုင်း ဖြစ်သည် -

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

    ထို့ကြောင့် client ကုဒ်မှာ server တွင် သတ်မှတ်ထားသည့်အတိုင်း ဖြစ်သည် -

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

အထက်ပါ ကုဒ်တွင် -

- `greeting` ဆိုသော resource ကို `read_resource` ဖြင့် ခေါ်ယူထားသည်။
- `add` ဆိုသော tool ကို `call_tool` ဖြင့် ဖော်ဆောင်ထားသည်။

### .NET

1. Tool တစ်ခု ခေါ်ရန် ကုဒ် ထည့်ပါ -

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

2. ရလဒ်ကို ထုတ်ပြရန် ကုဒ် -

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

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

အထက်ပါ ကုဒ်တွင် -

- `callTool()` method ဖြင့် calculator tools များစွာကို `CallToolRequest` objects ဖြင့် ခေါ်ယူထားသည်။
- Tool တစ်ခုချင်းစီသည် tool အမည်နှင့် လိုအပ်သော arguments များပါဝင်သည့် `Map` ကို သတ်မှတ်ထားသည်။
- Server tools များသည် သတ်မှတ်ထားသော parameter အမည်များ (ဥပမာ "a", "b") ကို မျှော်လင့်သည်။
- ရလဒ်များကို `CallToolResult` objects အဖြစ် ပြန်လည်ရရှိသည်။

### -5- Client ကို run ပြုလုပ်ခြင်း

Client ကို run မည်ဆိုလျှင် terminal တွင် အောက်ပါ command ကို ရိုက်ထည့်ပါ။

### TypeScript

*package.json* ၏ "scripts" အပိုင်းတွင် အောက်ပါ entry ကို ထည့်ပါ -

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Client ကို အောက်ပါ command ဖြင့် ခေါ်ပါ -

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

ပထမဦးဆုံး MCP server ကို `http://localhost:8080` တွင် run လုပ်ထားပါ။ ထို့နောက် client ကို run ပါ -

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

အခြားနည်းလမ်းအဖြစ် `03-GettingStarted\02-client\solution\java` ဖိုလ်ဒါရှိ client project အား run လုပ်နိုင်ပါသည် -

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## အလုပ်အပ်

ဤအလုပ်အပ်တွင် သင်သည် client ဖန်တီးခြင်းတွင် သင်ယူထားသည့် အရာများကို အသုံးပြုကာ ကိုယ်ပိုင် client တစ်ခု ဖန်တီးရမည်ဖြစ်သည်။

သင်ခန်းစာတွင် အသုံးပြုနိုင်သည့် server တစ်ခု ရှိပြီး client ကနေ ခေါ်ဆိုရမည်။ Server ကို ပိုမိုစိတ်ဝင်စားဖွယ် ဖြစ်အောင် feature များ ထပ်မံ ထည့်သွင်းနိုင်မလား စမ်းကြည့်ပါ။

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

ဤ project တွင် [prompts နှင့် resources များ ထည့်သွင်းနည်း](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs) ကို ကြည့်ရှုနိုင်သည်။

ထို့အပြင် [prompts နှင့် resources များ ဖော်ဆောင်နည်း](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/) ကိုလည်း စစ်ဆေးပါ။

## ဖြေရှင်းချက်

**solution folder** တွင် ဤသင်ခန်းစာတွင် ဖော်ပြထားသည့် အယူအဆများအားလုံးကို ပြသသည့် ပြည့်စုံပြီး အသုံးပြုနိုင်သော client implementation များ ပါဝင်သည်။ solution တစ်ခုစီတွင် client နှင့် server code များကို project များအလိုက် သီးခြား စီစဉ်ထားသည်။

### 📁 Solution ဖွဲ့စည်းပုံ

solution directory ကို programming language အလိုက် စီစဉ်ထားသည် -

```
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw            # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 Solution တစ်ခုစီတွင် ပါဝင်သည့် အရာများ

ဘာသာစကားအလိုက် solution တစ်ခုစီတွင် -

- **သင်ခန်းစာမှ features အားလုံးပါဝင်သည့် ပြည့်စုံ client implementation**
- **မှန်ကန်သော dependencies နှင့် configuration ပါရှိသည့် project ဖွဲ့စည်းပုံ**
- **တည်ဆောက်ခြင်းနှင့် run scripts များ**
- **ဘာသာစကားအလိုက် အသေးစိတ် README**
- **အမှားကိုင်တွယ်ခြင်းနှင့် ရလဒ်ကိုင်တွယ်ခြင်း ဥပမာများ**

### 📖 Solution များကို အသုံးပြုခြင်း

1. သင်နှစ်သက်သော ဘာသာစကား folder သို့ သွားပါ -

   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. folder တစ်ခုချင်းစီတွင် README အညွှန်းများကို လိုက်နာပါ -

   - Dependencies 설치ခြင်း
   - Project တည်ဆောက်ခြင်း
   - Client run ပြုလုပ်ခြင်း

3. ရရှိနိုင်သည့် output ဥပမာ -

   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

အသေးစိတ် စာရွက်စာတမ်းများနှင့် လမ်းညွှန်ချက်များအတွက် **[📖 Solution Documentation](./solution/README.md)** ကို ကြည့်ပါ။

## 🎯 ပြည့်စုံသော ဥပမာများ

ဤသင်ခန်းစာတွင် ဖော်ပြထားသည့် programming language အားလုံးအတွက် ပြည့်စုံပြီး အလုပ်လုပ်နိုင်သော client implementation များကို ပံ့ပိုးပေးထားသည်။ ဤဥပမာများသည် အထက်ဖော်ပြထားသည့် လုပ်ဆောင်ချက်များအားလုံးကို ပြသပြီး ကိုယ်ပိုင် project များအတွက် ကိုးကားနိုင်သည်။

### ရရှိနိုင်သည့် ပြည့်စုံသော ဥပမာများ

| ဘာသာစကား | ဖိုင် | ဖော်ပြချက် |
|----------|------|-------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | SSE transport အသုံးပြု၍ comprehensive error handling ပါဝင်သည့် Java client ပြည့်စုံ |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | stdio transport အသုံးပြု၍ server ကို အလိုအလျောက် စတင်နိုင်သော C# client ပြည့်စ
နှစ်ခုလုံးနည်းလမ်းများမှာ တန်ဖိုးရှိပြီး - ပြည့်စုံသောပရောဂျက်များအတွက် **solution folder** ကို အသုံးပြုပါ၊ သင်ယူခြင်းနှင့် ကိုးကားရန်အတွက် **complete examples** ကို အသုံးပြုပါ။

## အဓိကယူဆချက်များ

ဤအခန်းအတွက် အဓိကယူဆချက်များမှာ client များအကြောင်းအောက်ပါအတိုင်းဖြစ်သည်-

- ဆာဗာပေါ်ရှိ လုပ်ဆောင်ချက်များကို ရှာဖွေခြင်းနှင့် ခေါ်ယူခြင်းနှစ်ခုလုံးတွင် အသုံးပြုနိုင်သည်။
- မိမိကိုယ်ကို စတင်သည့်အခါ ဆာဗာကို စတင်နိုင်သည် (ဤအခန်းကဲ့သို့) သို့သော် client များသည် လည်ပတ်နေသော ဆာဗာများနှင့်လည်း ချိတ်ဆက်နိုင်သည်။
- ယခင်အခန်းတွင် ဖော်ပြခဲ့သည့် Inspector ကဲ့သို့သော အခြားရွေးချယ်စရာများနှင့် နှိုင်းယှဉ်၍ ဆာဗာ၏ စွမ်းဆောင်ရည်များကို စမ်းသပ်ရန် အလွန်ကောင်းမွန်သော နည်းလမ်းတစ်ခုဖြစ်သည်။

## အပိုဆောင်းအရင်းအမြစ်များ

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## နောက်တစ်ဆင့်

- နောက်တစ်ဆင့်: [Creating a client with an LLM](../03-llm-client/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။