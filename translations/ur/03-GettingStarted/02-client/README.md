<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:39:26+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ur"
}
-->
# کلائنٹ بنانا

کلائنٹس مخصوص ایپلیکیشنز یا اسکرپٹس ہوتے ہیں جو براہ راست MCP سرور سے رابطہ کرتے ہیں تاکہ وسائل، ٹولز، اور پرامپٹس کی درخواست کی جا سکے۔ انسپکٹر ٹول کے برعکس، جو سرور کے ساتھ تعامل کے لیے گرافیکل انٹرفیس فراہم کرتا ہے، اپنا کلائنٹ لکھنے سے پروگراماتی اور خودکار تعامل ممکن ہوتا ہے۔ اس سے ڈویلپرز کو MCP کی صلاحیتوں کو اپنے ورک فلو میں شامل کرنے، کاموں کو خودکار بنانے، اور مخصوص ضروریات کے مطابق حسب ضرورت حل تیار کرنے کی سہولت ملتی ہے۔

## جائزہ

یہ سبق MCP ماڈل کانٹیکسٹ پروٹوکول کے ماحولیاتی نظام میں کلائنٹس کے تصور کا تعارف کراتا ہے۔ آپ سیکھیں گے کہ اپنا کلائنٹ کیسے لکھا جائے اور اسے MCP سرور سے کیسے جوڑا جائے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے:

- سمجھنا کہ کلائنٹ کیا کر سکتا ہے۔
- اپنا کلائنٹ لکھنا۔
- کلائنٹ کو MCP سرور سے جوڑنا اور ٹیسٹ کرنا تاکہ یقین ہو کہ سرور متوقع طریقے سے کام کر رہا ہے۔

## کلائنٹ لکھنے میں کیا شامل ہے؟

کلائنٹ لکھنے کے لیے آپ کو درج ذیل کرنا ہوگا:

- **صحیح لائبریریز امپورٹ کریں**۔ آپ وہی لائبریری استعمال کریں گے جو پہلے استعمال کی تھی، بس مختلف کنسٹرکٹس کے ساتھ۔
- **کلائنٹ کا ایک انسٹینس بنائیں**۔ اس میں کلائنٹ کا ایک انسٹینس بنانا اور اسے منتخب شدہ ٹرانسپورٹ طریقہ سے جوڑنا شامل ہوگا۔
- **یہ فیصلہ کریں کہ کون سے وسائل کی فہرست بنانی ہے**۔ آپ کے MCP سرور میں وسائل، ٹولز اور پرامپٹس ہوتے ہیں، آپ کو فیصلہ کرنا ہوگا کہ کون سی فہرست میں شامل کرنی ہے۔
- **کلائنٹ کو ہوسٹ ایپلیکیشن میں ضم کریں**۔ جب آپ سرور کی صلاحیتوں کو جان لیں، تو آپ کو اسے اپنی ہوسٹ ایپلیکیشن میں ضم کرنا ہوگا تاکہ اگر صارف کوئی پرامپٹ یا کمانڈ ٹائپ کرے تو متعلقہ سرور فیچر چلایا جا سکے۔

اب جب کہ ہم نے اعلی سطح پر سمجھ لیا کہ ہمیں کیا کرنا ہے، آئیں اگلے حصے میں ایک مثال دیکھتے ہیں۔

### ایک مثال کلائنٹ

آئیے اس مثال کلائنٹ پر نظر ڈالیں:

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

پچھلے کوڈ میں ہم نے:

- لائبریریز امپورٹ کیں
- کلائنٹ کا ایک انسٹینس بنایا اور stdio کے ذریعے ٹرانسپورٹ کے لیے کنیکٹ کیا۔
- پرامپٹس، وسائل اور ٹولز کی فہرست بنائی اور انہیں چلایا۔

یہ رہا آپ کا کلائنٹ جو MCP سرور سے بات کر سکتا ہے۔

آئیے اگلے مشق سیکشن میں ہر کوڈ کے ٹکڑے کو تفصیل سے سمجھیں اور وضاحت کریں کہ کیا ہو رہا ہے۔

## مشق: کلائنٹ لکھنا

جیسا کہ اوپر کہا گیا، آئیے کوڈ کی وضاحت کرنے میں وقت لگائیں، اور اگر چاہیں تو ساتھ ساتھ کوڈ بھی کریں۔

### -1- لائبریریز امپورٹ کرنا

آئیے وہ لائبریریز امپورٹ کریں جن کی ہمیں ضرورت ہے، ہمیں کلائنٹ اور منتخب شدہ ٹرانسپورٹ پروٹوکول stdio کے حوالے درکار ہوں گے۔ stdio ایک پروٹوکول ہے جو آپ کے مقامی کمپیوٹر پر چلنے والی چیزوں کے لیے ہے۔ SSE ایک اور ٹرانسپورٹ پروٹوکول ہے جسے ہم مستقبل کے ابواب میں دکھائیں گے، لیکن فی الحال stdio کے ساتھ جاری رکھتے ہیں۔

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

جاوا کے لیے، آپ ایک کلائنٹ بنائیں گے جو پچھلی مشق کے MCP سرور سے جڑتا ہے۔ [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) کے جاوا اسپرنگ بوٹ پروجیکٹ ڈھانچے کو استعمال کرتے ہوئے، `src/main/java/com/microsoft/mcp/sample/client/` فولڈر میں `SDKClient` نامی نئی جاوا کلاس بنائیں اور درج ذیل امپورٹس شامل کریں:

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

اب انسٹینشی ایشن کی طرف بڑھتے ہیں۔

### -2- کلائنٹ اور ٹرانسپورٹ کا انسٹینس بنانا

ہمیں ٹرانسپورٹ اور کلائنٹ دونوں کا انسٹینس بنانا ہوگا:

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

پچھلے کوڈ میں ہم نے:

- stdio ٹرانسپورٹ کا انسٹینس بنایا۔ دھیان دیں کہ یہ کمانڈ اور آرگیومنٹس بتاتا ہے کہ سرور کو کیسے تلاش اور شروع کرنا ہے کیونکہ یہ کلائنٹ بنانے کے دوران ضروری ہوگا۔

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- کلائنٹ کا انسٹینس بنایا، اسے نام اور ورژن دیا۔

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- کلائنٹ کو منتخب شدہ ٹرانسپورٹ سے جوڑا۔

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

پچھلے کوڈ میں ہم نے:

- ضروری لائبریریز امپورٹ کیں
- سرور پیرامیٹرز کا ایک آبجیکٹ بنایا کیونکہ ہم اسے سرور چلانے کے لیے استعمال کریں گے تاکہ کلائنٹ سے کنیکٹ ہو سکیں۔
- `run` نامی میتھڈ ڈیفائن کی جو `stdio_client` کو کال کرتی ہے جو کلائنٹ سیشن شروع کرتا ہے۔
- ایک انٹری پوائنٹ بنایا جہاں `asyncio.run` کے ذریعے `run` میتھڈ چلایا جاتا ہے۔

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

پچھلے کوڈ میں ہم نے:

- ضروری لائبریریز امپورٹ کیں۔
- stdio ٹرانسپورٹ بنایا اور `mcpClient` کلائنٹ بنایا۔ یہ کلائنٹ MCP سرور پر فیچرز کی فہرست بنانے اور چلانے کے لیے استعمال ہوگا۔

نوٹ کریں، "Arguments" میں آپ *.csproj* یا executable کی طرف اشارہ کر سکتے ہیں۔

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

پچھلے کوڈ میں ہم نے:

- مین میتھڈ بنایا جو SSE ٹرانسپورٹ سیٹ کرتا ہے جو `http://localhost:8080` کی طرف اشارہ کرتا ہے جہاں ہمارا MCP سرور چل رہا ہوگا۔
- کلائنٹ کلاس بنائی جو ٹرانسپورٹ کو کنسٹرکٹر پیرامیٹر کے طور پر لیتی ہے۔
- `run` میتھڈ میں ہم synchronous MCP کلائنٹ بناتے ہیں اور کنکشن کو initialize کرتے ہیں۔
- SSE (Server-Sent Events) ٹرانسپورٹ استعمال کیا جو جاوا اسپرنگ بوٹ MCP سرورز کے لیے HTTP بیسڈ کمیونیکیشن کے لیے مناسب ہے۔

### -3- سرور کی خصوصیات کی فہرست بنانا

اب ہمارے پاس ایک کلائنٹ ہے جو کنیکٹ ہو سکتا ہے اگر پروگرام چلایا جائے۔ تاہم، یہ فیچرز کی فہرست نہیں بناتا، تو آئیے یہ کرتے ہیں:

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

یہاں ہم دستیاب وسائل `list_resources()` اور ٹولز `list_tools` کی فہرست بناتے ہیں اور انہیں پرنٹ کرتے ہیں۔

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

اوپر ایک مثال ہے کہ ہم سرور پر موجود ٹولز کی فہرست کیسے بنا سکتے ہیں۔ ہر ٹول کے لیے، ہم اس کا نام پرنٹ کرتے ہیں۔

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

پچھلے کوڈ میں ہم نے:

- `listTools()` کال کی تاکہ MCP سرور سے تمام دستیاب ٹولز حاصل کیے جا سکیں۔
- `ping()` استعمال کیا تاکہ کنکشن کی تصدیق ہو سکے۔
- `ListToolsResult` میں تمام ٹولز کی معلومات شامل ہوتی ہے، جیسے نام، تفصیل، اور ان پٹ اسکیمہ۔

زبردست، اب ہم نے تمام فیچرز حاصل کر لیے ہیں۔ اب سوال یہ ہے کہ ہم انہیں کب استعمال کریں؟ یہ کلائنٹ کافی سادہ ہے، یعنی ہمیں فیچرز کو جب چاہیں واضح طور پر کال کرنا ہوگا۔ اگلے باب میں، ہم ایک زیادہ جدید کلائنٹ بنائیں گے جس کے پاس اپنا بڑا زبان ماڈل (LLM) ہوگا۔ فی الحال، آئیے دیکھتے ہیں کہ سرور پر فیچرز کو کیسے چلایا جائے:

### -4- فیچرز کو چلانا

فیچرز کو چلانے کے لیے ہمیں درست آرگیومنٹس اور بعض اوقات جس چیز کو چلانا ہے اس کا نام بھی بتانا ہوگا۔

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

پچھلے کوڈ میں ہم نے:

- ایک ریسورس پڑھا، ہم `readResource()` کال کرتے ہیں اور `uri` بتاتے ہیں۔ سرور پر یہ کچھ یوں نظر آتا ہے:

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

    ہمارا `uri` ویلیو `file://example.txt` سرور کے `file://{name}` سے میل کھاتا ہے۔ `example.txt` `name` کے طور پر میپ ہوگا۔

- ایک ٹول کال کیا، ہم اسے اس کے `name` اور `arguments` کے ساتھ کال کرتے ہیں:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- پرامپٹ حاصل کیا، `getPrompt()` کو `name` اور `arguments` کے ساتھ کال کیا۔ سرور کا کوڈ کچھ یوں ہے:

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

    اور آپ کا کلائنٹ کوڈ اس کے مطابق کچھ یوں ہوگا:

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

پچھلے کوڈ میں ہم نے:

- `greeting` نامی ریسورس کو `read_resource` کے ذریعے کال کیا۔
- `add` نامی ٹول کو `call_tool` کے ذریعے چلایا۔

### .NET

1. آئیے کچھ کوڈ شامل کریں تاکہ ٹول کال کیا جا سکے:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. نتیجہ پرنٹ کرنے کے لیے، یہ کوڈ استعمال کریں:

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

پچھلے کوڈ میں ہم نے:

- متعدد کیلکولیٹر ٹولز کو `callTool()` میتھڈ کے ذریعے `CallToolRequest` آبجیکٹس کے ساتھ کال کیا۔
- ہر ٹول کال میں ٹول کا نام اور اس کے لیے درکار آرگیومنٹس کا `Map` دیا گیا۔
- سرور ٹولز مخصوص پیرامیٹر ناموں کی توقع کرتے ہیں (جیسے ریاضیاتی آپریشنز کے لیے "a"، "b")۔
- نتائج `CallToolResult` آبجیکٹس کی صورت میں واپس آتے ہیں جن میں سرور کا جواب ہوتا ہے۔

### -5- کلائنٹ چلانا

کلائنٹ چلانے کے لیے، ٹرمینل میں درج ذیل کمانڈ ٹائپ کریں:

### TypeScript

*package.json* کے "scripts" سیکشن میں درج ذیل انٹری شامل کریں:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

کلائنٹ کو درج ذیل کمانڈ سے کال کریں:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

سب سے پہلے، یقینی بنائیں کہ آپ کا MCP سرور `http://localhost:8080` پر چل رہا ہے۔ پھر کلائنٹ چلائیں:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

متبادل طور پر، آپ مکمل کلائنٹ پروجیکٹ جو حل فولڈر `03-GettingStarted\02-client\solution\java` میں موجود ہے، چلا سکتے ہیں:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## اسائنمنٹ

اس اسائنمنٹ میں، آپ نے جو کچھ سیکھا ہے اسے استعمال کرتے ہوئے اپنا کلائنٹ بنائیں۔

یہاں ایک سرور ہے جسے آپ اپنے کلائنٹ کوڈ کے ذریعے کال کریں گے، دیکھیں کہ کیا آپ سرور میں مزید فیچرز شامل کر کے اسے مزید دلچسپ بنا سکتے ہیں۔

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

اس پروجیکٹ کو دیکھیں کہ آپ کیسے [پرامپٹس اور وسائل شامل کر سکتے ہیں](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)۔

اس لنک کو بھی چیک کریں کہ [پرامپٹس اور وسائل کو کیسے چلایا جائے](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/)۔

## حل

**حل فولڈر** مکمل، چلانے کے لیے تیار کلائنٹ امپلیمنٹیشنز پر مشتمل ہے جو اس ٹیوٹوریل میں شامل تمام تصورات کو ظاہر کرتی ہیں۔ ہر حل میں کلائنٹ اور سرور کوڈ الگ الگ، خود مختار پروجیکٹس میں منظم ہوتا ہے۔

### 📁 حل کا ڈھانچہ

حل کی ڈائریکٹری پروگرامنگ زبان کے لحاظ سے منظم ہے:

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

### 🚀 ہر حل میں کیا شامل ہے

ہر زبان کے لیے مخصوص حل میں شامل ہیں:

- **مکمل کلائنٹ امپلیمنٹیشن** جو ٹیوٹوریل کی تمام خصوصیات رکھتی ہے
- **کام کرنے والا پروجیکٹ ڈھانچہ** مناسب dependencies اور configuration کے ساتھ
- **بلڈ اور رن اسکرپٹس** آسان سیٹ اپ اور اجرا کے لیے
- **تفصیلی README** زبان کے لحاظ سے ہدایات کے ساتھ
- **ایرر ہینڈلنگ** اور نتیجہ پروسیسنگ کی مثالیں

### 📖 حل استعمال کرنا

1. **اپنی پسندیدہ زبان کے فولڈر میں جائیں**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **ہر فولڈر میں README کی ہدایات پر عمل کریں**:
   - dependencies انسٹال کرنا
   - پروجیکٹ بنانا
   - کلائنٹ چلانا

3. **مثال کے طور پر آپ کو جو آؤٹ پٹ نظر آئے گا**:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

مکمل دستاویزات اور مرحلہ وار ہدایات کے لیے دیکھیں: **[📖 حل کی دستاویزات](./solution/README.md)**

## 🎯 مکمل مثالیں

ہم نے تمام پروگرامنگ زبانوں کے لیے مکمل، کام کرنے والے کلائنٹ امپلیمنٹیشنز فراہم کیے ہیں جو اس ٹیوٹوریل میں بیان کردہ تمام فنکشنلٹی کو ظاہر کرتے ہیں۔ یہ مثالیں حوالہ کے طور پر یا آپ کے اپنے پروجیکٹس کے آغاز کے لیے استعمال کی جا سکتی ہیں۔

### دستیاب مکمل مثالیں

| زبان | فائل | وضاحت |
|-------|-------|---------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | SSE ٹرانسپورٹ کے ساتھ مکمل جاوا کلائنٹ، جامع ایرر ہینڈلنگ کے ساتھ |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | stdio ٹرانسپورٹ کے ساتھ مکمل C# کلائنٹ، خودکار سرور اسٹارٹ اپ کے ساتھ |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | مکمل TypeScript کلائنٹ، MCP پروٹوکول کی مکمل سپورٹ کے ساتھ |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | async/await پیٹرنز کے ساتھ مکمل Python کلائنٹ |

ہر مکمل مثال میں شامل ہیں:

- ✅ **کنکشن قائم کرنا** اور ایرر ہینڈلنگ
- ✅ **سرور کی دریافت** (ٹولز، وسائل، پرامپٹس جہاں قابل اطلاق ہوں)
- ✅ **کیلکولیٹر آپریشنز** (جمع، تفریق، ضرب، تقسیم، مدد)
- ✅ **نتائج کی پروسیسنگ** اور فارمیٹ شدہ آؤٹ پٹ
- ✅ **جامع ایرر ہینڈلنگ**
- ✅ **صاف، دستاویزی کوڈ** مرحلہ وار تبصروں کے ساتھ

### مکمل مثالوں کے ساتھ شروعات

1. **اوپر دی گئی جدول سے اپنی پسندیدہ زبان منتخب کریں**
2. **مکمل مثال فائل کا جائزہ لیں تاکہ مکمل امپلیمنٹیشن سمجھ سکیں**
3. **[`complete_examples.md`](./complete_examples.md) میں دی گئی ہدایات کے مطابق مثال چلائیں**
4. **اپنے مخصوص استعمال کے لیے مثال میں ترمیم اور توسیع کریں**

مکمل مثالوں کو چلانے اور حسب ضرورت بنانے کے لیے تفصیلی دستاویزات دیکھیں: **[📖 مکمل مثالوں کی دستاویزات](./complete_examples.md)**

### 💡 حل بمقابلہ مکمل مثالیں

| **حل فولڈر** | **مکمل مثالیں** |
|--------------|-----------------|
| مکمل پروجیکٹ ڈھانچہ اور بلڈ فائلز | ایک فائل پر مشتمل امپلیمنٹیشنز |
| dependencies کے ساتھ چلانے کے لیے تیار | مخصوص کوڈ مثالیں |
| پروڈکشن جیسا سیٹ اپ | تعلیمی حوالہ جات |
| زبان مخصوص ٹولنگ | زبانوں کے مابین موازنہ |
دونوں طریقے قیمتی ہیں - مکمل پروجیکٹس کے لیے **solution folder** استعمال کریں اور سیکھنے اور حوالہ کے لیے **complete examples**۔

## اہم نکات

اس باب کے اہم نکات کلائنٹس کے بارے میں درج ذیل ہیں:

- سرور پر فیچرز دریافت کرنے اور ان کو کال کرنے دونوں کے لیے استعمال ہو سکتے ہیں۔
- خود شروع ہوتے ہوئے سرور بھی شروع کر سکتے ہیں (جیسا کہ اس باب میں ہے) لیکن کلائنٹس چلتے ہوئے سرورز سے بھی جڑ سکتے ہیں۔
- سرور کی صلاحیتوں کو جانچنے کا بہترین طریقہ ہیں، جیسے کہ پچھلے باب میں Inspector کے متبادل کے طور پر بیان کیا گیا تھا۔

## اضافی وسائل

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## نمونے

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## آگے کیا ہے

- اگلا: [Creating a client with an LLM](../03-llm-client/README.md)

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔