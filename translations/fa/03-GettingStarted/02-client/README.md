<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:38:39+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "fa"
}
-->
# ایجاد یک کلاینت

کلاینت‌ها برنامه‌ها یا اسکریپت‌های سفارشی هستند که مستقیماً با سرور MCP ارتباط برقرار می‌کنند تا منابع، ابزارها و پرامپت‌ها را درخواست کنند. برخلاف استفاده از ابزار inspector که یک رابط گرافیکی برای تعامل با سرور فراهم می‌کند، نوشتن کلاینت خودتان امکان تعامل برنامه‌نویسی و خودکار را می‌دهد. این به توسعه‌دهندگان اجازه می‌دهد قابلیت‌های MCP را در جریان‌های کاری خود ادغام کنند، وظایف را خودکار کنند و راه‌حل‌های سفارشی متناسب با نیازهای خاص بسازند.

## مرور کلی

این درس مفهوم کلاینت‌ها را در اکوسیستم پروتکل مدل کانتکست (MCP) معرفی می‌کند. شما یاد می‌گیرید چگونه کلاینت خود را بنویسید و آن را به سرور MCP متصل کنید.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- درک کنید کلاینت چه کاری می‌تواند انجام دهد.
- کلاینت خود را بنویسید.
- کلاینت را به سرور MCP متصل کرده و تست کنید تا مطمئن شوید سرور به درستی کار می‌کند.

## چه مواردی برای نوشتن یک کلاینت لازم است؟

برای نوشتن یک کلاینت، باید موارد زیر را انجام دهید:

- **وارد کردن کتابخانه‌های مناسب**. شما از همان کتابخانه قبلی استفاده می‌کنید، فقط ساختارهای متفاوتی به کار می‌برید.
- **ایجاد نمونه‌ای از کلاینت**. این شامل ساخت یک نمونه کلاینت و اتصال آن به روش انتقال انتخاب شده است.
- **تصمیم‌گیری درباره منابعی که باید فهرست شوند**. سرور MCP شما شامل منابع، ابزارها و پرامپت‌ها است، باید تصمیم بگیرید کدام یک را فهرست کنید.
- **ادغام کلاینت با برنامه میزبان**. وقتی قابلیت‌های سرور را شناختید، باید کلاینت را در برنامه میزبان خود ادغام کنید تا اگر کاربر پرامپت یا دستور دیگری وارد کرد، ویژگی مربوطه در سرور فراخوانی شود.

حالا که در سطح کلی فهمیدیم چه کاری قرار است انجام دهیم، بیایید به یک مثال نگاه کنیم.

### یک کلاینت نمونه

بیایید این کلاینت نمونه را بررسی کنیم:

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

در کد بالا ما:

- کتابخانه‌ها را وارد کردیم
- یک نمونه کلاینت ساختیم و با استفاده از stdio به عنوان روش انتقال به سرور متصل شدیم.
- پرامپت‌ها، منابع و ابزارها را فهرست کرده و همه را فراخوانی کردیم.

همین، یک کلاینت که می‌تواند با سرور MCP ارتباط برقرار کند.

در بخش تمرین بعدی، هر قطعه کد را به دقت بررسی کرده و توضیح می‌دهیم چه اتفاقی می‌افتد.

## تمرین: نوشتن یک کلاینت

همانطور که گفته شد، بیایید کد را با دقت توضیح دهیم و اگر خواستید همراه با ما کدنویسی کنید.

### -1- وارد کردن کتابخانه‌ها

بیایید کتابخانه‌های مورد نیاز را وارد کنیم، ما به ارجاعاتی به کلاینت و پروتکل انتقال انتخابی خود، stdio، نیاز داریم. stdio پروتکلی است برای برنامه‌هایی که روی ماشین محلی شما اجرا می‌شوند. SSE پروتکل انتقال دیگری است که در فصل‌های بعدی نشان خواهیم داد اما این گزینه دیگر شماست. فعلاً با stdio ادامه می‌دهیم.

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

برای جاوا، شما یک کلاینت می‌سازید که به سرور MCP از تمرین قبلی متصل می‌شود. با استفاده از همان ساختار پروژه Java Spring Boot از [شروع کار با سرور MCP](../../../../03-GettingStarted/01-first-server/solution/java)، یک کلاس جاوای جدید به نام `SDKClient` در پوشه `src/main/java/com/microsoft/mcp/sample/client/` ایجاد کنید و واردات زیر را اضافه کنید:

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

حالا به سراغ ایجاد نمونه می‌رویم.

### -2- ایجاد نمونه کلاینت و انتقال

ما باید یک نمونه از انتقال و یک نمونه از کلاینت بسازیم:

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

در کد بالا ما:

- یک نمونه انتقال stdio ساختیم. توجه کنید که چگونه فرمان و آرگومان‌ها برای پیدا کردن و راه‌اندازی سرور مشخص شده‌اند، چون این کاری است که هنگام ساخت کلاینت باید انجام دهیم.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- یک کلاینت با نام و نسخه مشخص ایجاد کردیم.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- کلاینت را به انتقال انتخاب شده متصل کردیم.

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

در کد بالا ما:

- کتابخانه‌های مورد نیاز را وارد کردیم
- یک شیء پارامترهای سرور ساختیم که برای اجرای سرور و اتصال کلاینت به آن استفاده می‌کنیم.
- متدی به نام `run` تعریف کردیم که به نوبه خود `stdio_client` را فراخوانی می‌کند تا جلسه کلاینت را شروع کند.
- یک نقطه ورود ایجاد کردیم که متد `run` را به `asyncio.run` می‌دهد.

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

در کد بالا ما:

- کتابخانه‌های مورد نیاز را وارد کردیم.
- یک انتقال stdio ساختیم و کلاینتی به نام `mcpClient` ایجاد کردیم. این کلاینت برای فهرست کردن و فراخوانی ویژگی‌ها روی سرور MCP استفاده می‌شود.

توجه داشته باشید، در بخش "Arguments"، می‌توانید به فایل *.csproj* یا فایل اجرایی اشاره کنید.

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

در کد بالا ما:

- متد main ایجاد کردیم که یک انتقال SSE به آدرس `http://localhost:8080` که سرور MCP ما روی آن اجرا می‌شود، تنظیم می‌کند.
- یک کلاس کلاینت ساختیم که انتقال را به عنوان پارامتر سازنده می‌گیرد.
- در متد `run`، یک کلاینت MCP همزمان با استفاده از انتقال ایجاد کرده و اتصال را مقداردهی اولیه می‌کند.
- از انتقال SSE (Server-Sent Events) استفاده کردیم که برای ارتباط مبتنی بر HTTP با سرورهای MCP جاوا Spring Boot مناسب است.

### -3- فهرست کردن ویژگی‌های سرور

حالا ما کلاینتی داریم که می‌تواند به سرور متصل شود اگر برنامه اجرا شود. اما هنوز ویژگی‌های سرور را فهرست نمی‌کند، پس بیایید این کار را انجام دهیم:

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

در اینجا منابع موجود را با `list_resources()` و ابزارها را با `list_tools` فهرست کرده و چاپ می‌کنیم.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

مثالی از نحوه فهرست کردن ابزارهای سرور است. برای هر ابزار، نام آن را چاپ می‌کنیم.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

در کد بالا ما:

- با `listTools()` تمام ابزارهای موجود در سرور MCP را دریافت کردیم.
- با `ping()` بررسی کردیم که اتصال به سرور برقرار است.
- `ListToolsResult` شامل اطلاعاتی درباره همه ابزارها از جمله نام‌ها، توضیحات و ساختار ورودی آنها است.

عالی، حالا همه ویژگی‌ها را گرفتیم. حالا سوال این است که چه زمانی از آنها استفاده کنیم؟ این کلاینت ساده است، به این معنی که باید به صورت صریح ویژگی‌ها را وقتی می‌خواهیم فراخوانی کنیم. در فصل بعدی، کلاینت پیشرفته‌تری می‌سازیم که به مدل زبان بزرگ (LLM) خودش دسترسی دارد. فعلاً بیایید ببینیم چگونه می‌توان ویژگی‌های سرور را فراخوانی کرد:

### -4- فراخوانی ویژگی‌ها

برای فراخوانی ویژگی‌ها باید مطمئن شویم آرگومان‌های درست را مشخص کرده‌ایم و در برخی موارد نام آنچه می‌خواهیم فراخوانی کنیم را نیز.

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

در کد بالا ما:

- یک منبع را خواندیم، با فراخوانی `readResource()` و مشخص کردن `uri`. این احتمالاً در سمت سرور به این شکل است:

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

    مقدار `uri` ما `file://example.txt` با `file://{name}` در سرور مطابقت دارد. `example.txt` به `name` نگاشت می‌شود.

- یک ابزار را فراخوانی کردیم، با مشخص کردن `name` و `arguments` به این شکل:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- پرامپت گرفتیم، با فراخوانی `getPrompt()` با `name` و `arguments`. کد سرور به این شکل است:

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

    و کد کلاینت شما به این شکل خواهد بود تا با آنچه در سرور تعریف شده مطابقت داشته باشد:

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

در کد بالا ما:

- منبعی به نام `greeting` را با `read_resource` فراخوانی کردیم.
- ابزاری به نام `add` را با `call_tool` فراخوانی کردیم.

### .NET

1. بیایید کدی اضافه کنیم برای فراخوانی یک ابزار:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. برای چاپ نتیجه، این کد را اضافه کنید:

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

در کد بالا ما:

- چند ابزار ماشین حساب را با متد `callTool()` و اشیاء `CallToolRequest` فراخوانی کردیم.
- هر فراخوانی ابزار نام ابزار و یک `Map` از آرگومان‌های مورد نیاز آن ابزار را مشخص می‌کند.
- ابزارهای سرور انتظار دارند پارامترهای خاصی (مثل "a"، "b" برای عملیات ریاضی) دریافت کنند.
- نتایج به صورت اشیاء `CallToolResult` که پاسخ سرور را دارند، بازگردانده می‌شوند.

### -5- اجرای کلاینت

برای اجرای کلاینت، دستور زیر را در ترمینال وارد کنید:

### TypeScript

این ورودی را به بخش "scripts" در *package.json* اضافه کنید:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

کلاینت را با دستور زیر اجرا کنید:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

ابتدا مطمئن شوید سرور MCP شما روی `http://localhost:8080` در حال اجرا است. سپس کلاینت را اجرا کنید:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

همچنین می‌توانید پروژه کامل کلاینت را که در پوشه راه‌حل `03-GettingStarted\02-client\solution\java` قرار دارد اجرا کنید:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## تمرین

در این تمرین، از آنچه یاد گرفته‌اید برای ایجاد یک کلاینت استفاده کنید اما کلاینت خودتان را بسازید.

در اینجا یک سرور دارید که باید از طریق کد کلاینت خود به آن متصل شوید، ببینید آیا می‌توانید ویژگی‌های بیشتری به سرور اضافه کنید تا جذاب‌تر شود.

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

این پروژه را ببینید تا یاد بگیرید چگونه می‌توانید [پرامپت‌ها و منابع را اضافه کنید](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

همچنین این لینک را برای نحوه فراخوانی [پرامپت‌ها و منابع](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/) بررسی کنید.

## راه‌حل

**پوشه راه‌حل** شامل پیاده‌سازی‌های کامل و آماده اجرا از کلاینت است که تمام مفاهیم آموزش داده شده در این آموزش را نشان می‌دهد. هر راه‌حل شامل کد کلاینت و سرور است که در پروژه‌های جداگانه و مستقل سازماندهی شده‌اند.

### 📁 ساختار راه‌حل

دایرکتوری راه‌حل بر اساس زبان برنامه‌نویسی سازماندهی شده است:

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

### 🚀 هر راه‌حل شامل چه مواردی است

هر راه‌حل مخصوص زبان شامل:

- **پیاده‌سازی کامل کلاینت** با تمام ویژگی‌های آموزش داده شده
- **ساختار پروژه کاری** با وابستگی‌ها و پیکربندی مناسب
- **اسکریپت‌های ساخت و اجرا** برای راه‌اندازی و اجرای آسان
- **README دقیق** با دستورالعمل‌های مخصوص زبان
- **نمونه‌های مدیریت خطا** و پردازش نتایج

### 📖 استفاده از راه‌حل‌ها

1. **به پوشه زبان مورد نظر خود بروید**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **دستورالعمل‌های README را در هر پوشه دنبال کنید برای:**
   - نصب وابستگی‌ها
   - ساخت پروژه
   - اجرای کلاینت

3. **خروجی نمونه‌ای که باید ببینید:**
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

برای مستندات کامل و دستورالعمل‌های گام به گام، به: **[📖 مستندات راه‌حل](./solution/README.md)** مراجعه کنید.

## 🎯 مثال‌های کامل

ما پیاده‌سازی‌های کامل و کاری کلاینت را برای تمام زبان‌های برنامه‌نویسی پوشش داده شده در این آموزش فراهم کرده‌ایم. این مثال‌ها عملکرد کامل شرح داده شده را نشان می‌دهند و می‌توانند به عنوان مرجع یا نقطه شروع برای پروژه‌های خودتان استفاده شوند.

### مثال‌های کامل موجود

| زبان | فایل | توضیحات |
|-------|-------|----------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | کلاینت کامل جاوا با انتقال SSE و مدیریت جامع خطا |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | کلاینت کامل C# با انتقال stdio و راه‌اندازی خودکار سرور |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | کلاینت کامل TypeScript با پشتیبانی کامل از پروتکل MCP |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | کلاینت کامل Python با الگوهای async/await |

هر مثال کامل شامل:

- ✅ **برقراری اتصال** و مدیریت خطا
- ✅ **کشف سرور** (ابزارها، منابع، پرامپت‌ها در صورت وجود)
- ✅ **عملیات ماشین حساب** (جمع، تفریق، ضرب، تقسیم، راهنما)
- ✅ **پردازش نتایج** و خروجی قالب‌بندی شده
- ✅ **مدیریت جامع خطا**
- ✅ **کد تمیز و مستندسازی شده** با توضیحات گام به گام

### شروع با مثال‌های کامل

1. **زبان مورد نظر خود را از جدول بالا انتخاب کنید**
2. **فایل مثال کامل را مرور کنید تا پیاده‌سازی کامل را بفهمید**
3. **مثال را با دنبال کردن دستورالعمل‌ها در [`complete_examples.md`](./complete_examples.md) اجرا کنید**
4. **مثال را برای نیازهای خاص خود تغییر داده و گسترش دهید**

برای مستندات دقیق درباره اجرای این مثال‌ها و سفارشی‌سازی آنها، به: **[📖 مستندات مثال‌های کامل](./complete_examples.md)** مراجعه کنید.

### 💡 تفاوت راه‌حل و مثال‌های کامل

| **پوشه راه‌حل** | **مثال‌های کامل** |
|-----------------|-------------------|
| ساختار کامل پروژه با فایل‌های ساخت | پیاده‌سازی‌های تک‌فایلی |
| آماده اجرا با وابستگی‌ها | نمونه‌های کد متمرکز |
| تنظیمات مشابه محیط تولید | مرجع آموزشی |
| ابزارهای مخصوص زبان | مقایسه بین زبان‌ها |
هر دو رویکرد ارزشمند هستند - از **پوشه solution** برای پروژه‌های کامل و از **مثال‌های کامل** برای یادگیری و مرجع استفاده کنید.

## نکات کلیدی

نکات کلیدی این فصل درباره کلاینت‌ها به شرح زیر است:

- می‌توان از آن‌ها هم برای کشف و هم برای فراخوانی ویژگی‌ها روی سرور استفاده کرد.
- می‌توانند در حین راه‌اندازی خود، سرور را نیز راه‌اندازی کنند (مانند این فصل) اما کلاینت‌ها می‌توانند به سرورهای در حال اجرا نیز متصل شوند.
- روشی عالی برای آزمایش قابلیت‌های سرور در کنار گزینه‌هایی مانند Inspector است که در فصل قبل توضیح داده شد.

## منابع اضافی

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## نمونه‌ها

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## مرحله بعد

- بعدی: [Creating a client with an LLM](../03-llm-client/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.