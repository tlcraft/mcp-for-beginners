<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-16T22:27:58+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "fa"
}
-->
# ایجاد یک کلاینت

کلاینت‌ها برنامه‌ها یا اسکریپت‌های سفارشی هستند که مستقیماً با سرور MCP ارتباط برقرار می‌کنند تا منابع، ابزارها و پرامپت‌ها را درخواست کنند. برخلاف استفاده از ابزار inspector که یک رابط گرافیکی برای تعامل با سرور فراهم می‌کند، نوشتن کلاینت خودتان امکان تعامل برنامه‌نویسی و خودکار را می‌دهد. این به توسعه‌دهندگان اجازه می‌دهد قابلیت‌های MCP را در جریان‌های کاری خود ادغام کنند، وظایف را خودکار کنند و راه‌حل‌های سفارشی متناسب با نیازهای خاص بسازند.

## مرور کلی

این درس مفهوم کلاینت‌ها در اکوسیستم Model Context Protocol (MCP) را معرفی می‌کند. شما یاد می‌گیرید چگونه کلاینت خود را بنویسید و آن را به سرور MCP متصل کنید.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- درک کنید که یک کلاینت چه کاری می‌تواند انجام دهد.
- کلاینت خود را بنویسید.
- کلاینت را به سرور MCP متصل کرده و آن را تست کنید تا مطمئن شوید سرور به درستی کار می‌کند.

## چه مواردی برای نوشتن یک کلاینت لازم است؟

برای نوشتن یک کلاینت، باید موارد زیر را انجام دهید:

- **وارد کردن کتابخانه‌های مناسب**. شما از همان کتابخانه قبلی استفاده می‌کنید، فقط ساختارهای متفاوتی به کار می‌برید.
- **ایجاد یک نمونه کلاینت**. این شامل ساخت یک نمونه کلاینت و اتصال آن به روش انتقال انتخاب شده است.
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
- پرامپت‌ها، منابع و ابزارها را فهرست کردیم و همه را فراخوانی کردیم.

همین، یک کلاینت که می‌تواند با سرور MCP ارتباط برقرار کند.

در بخش تمرین بعدی، وقت می‌گذاریم و هر بخش کد را تجزیه و تحلیل می‌کنیم و توضیح می‌دهیم چه اتفاقی می‌افتد.

## تمرین: نوشتن یک کلاینت

همانطور که گفته شد، بیایید وقت بگذاریم و کد را توضیح دهیم، و اگر خواستید همراه با ما کد بزنید.

### -1- وارد کردن کتابخانه‌ها

بیایید کتابخانه‌های مورد نیاز را وارد کنیم، ما به ارجاعاتی به کلاینت و پروتکل انتقال انتخابی خود، stdio، نیاز داریم. stdio پروتکلی است برای برنامه‌هایی که قرار است روی ماشین محلی شما اجرا شوند. SSE پروتکل انتقال دیگری است که در فصل‌های بعدی نشان خواهیم داد، اما این گزینه دیگر شماست. فعلاً با stdio ادامه می‌دهیم.

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

برای جاوا، شما یک کلاینت می‌سازید که به سرور MCP از تمرین قبلی متصل می‌شود. با استفاده از همان ساختار پروژه Java Spring Boot از [شروع کار با MCP Server](../../../../03-GettingStarted/01-first-server/solution/java)، یک کلاس جاوای جدید به نام `SDKClient` در پوشه `src/main/java/com/microsoft/mcp/sample/client/` ایجاد کنید و واردات زیر را اضافه کنید:

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

- یک کلاینت با دادن نام و نسخه نمونه‌سازی کردیم.

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
- یک شیء پارامترهای سرور نمونه‌سازی کردیم چون از آن برای اجرای سرور استفاده می‌کنیم تا بتوانیم با کلاینت به آن متصل شویم.
- متدی به نام `run` تعریف کردیم که به نوبه خود `stdio_client` را فراخوانی می‌کند که یک جلسه کلاینت را شروع می‌کند.
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
- یک انتقال stdio ساختیم و یک کلاینت به نام `mcpClient` ایجاد کردیم. این کلاینت برای فهرست کردن و فراخوانی ویژگی‌ها روی سرور MCP استفاده خواهد شد.

توجه داشته باشید، در "Arguments"، می‌توانید به فایل *.csproj* یا به فایل اجرایی اشاره کنید.

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

- متد main ایجاد کردیم که یک انتقال SSE را به آدرس `http://localhost:8080` که سرور MCP ما در آن اجرا می‌شود، تنظیم می‌کند.
- یک کلاس کلاینت ساختیم که انتقال را به عنوان پارامتر سازنده می‌گیرد.
- در متد `run`، یک کلاینت MCP همزمان با استفاده از انتقال ایجاد کرده و اتصال را مقداردهی اولیه می‌کند.
- از انتقال SSE (Server-Sent Events) استفاده کردیم که برای ارتباط مبتنی بر HTTP با سرورهای Java Spring Boot MCP مناسب است.

### -3- فهرست کردن ویژگی‌های سرور

حالا ما یک کلاینت داریم که می‌تواند به سرور متصل شود اگر برنامه اجرا شود. اما در واقع ویژگی‌های سرور را فهرست نمی‌کند، پس بیایید این کار را انجام دهیم:

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

در اینجا منابع موجود، `list_resources()` و ابزارها، `list_tools` را فهرست کرده و چاپ می‌کنیم.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

در بالا نمونه‌ای از نحوه فهرست کردن ابزارهای سرور آمده است. برای هر ابزار، نام آن را چاپ می‌کنیم.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

در کد بالا ما:

- متد `listTools()` را برای دریافت همه ابزارهای موجود از سرور MCP فراخوانی کردیم.
- از `ping()` برای اطمینان از صحت اتصال به سرور استفاده کردیم.
- `ListToolsResult` شامل اطلاعاتی درباره همه ابزارها از جمله نام‌ها، توضیحات و ساختار ورودی آنها است.

عالی، حالا همه ویژگی‌ها را گرفتیم. حالا سوال این است که چه زمانی از آنها استفاده کنیم؟ خب، این کلاینت خیلی ساده است، به این معنا که باید به صورت صریح ویژگی‌ها را وقتی می‌خواهیم فراخوانی کنیم. در فصل بعد، یک کلاینت پیشرفته‌تر می‌سازیم که به مدل زبان بزرگ (LLM) خودش دسترسی دارد. فعلاً بیایید ببینیم چگونه می‌توانیم ویژگی‌های سرور را فراخوانی کنیم:

### -4- فراخوانی ویژگی‌ها

برای فراخوانی ویژگی‌ها باید مطمئن شویم آرگومان‌های درست را مشخص کرده‌ایم و در برخی موارد نام چیزی که می‌خواهیم فراخوانی کنیم را هم تعیین کنیم.

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

- یک منبع را خواندیم، منبع را با فراخوانی `readResource()` و مشخص کردن `uri` صدا زدیم. این احتمالاً در سمت سرور به این شکل است:

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

- یک ابزار را فراخوانی کردیم، آن را با مشخص کردن `name` و `arguments` به این شکل صدا زدیم:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- پرامپت گرفتیم، برای گرفتن پرامپت، `getPrompt()` را با `name` و `arguments` فراخوانی کردیم. کد سرور به این شکل است:

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

    و کد کلاینت شما به این شکل خواهد بود تا با آنچه در سرور اعلام شده مطابقت داشته باشد:

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

- منبعی به نام `greeting` را با استفاده از `read_resource` فراخوانی کردیم.
- ابزاری به نام `add` را با استفاده از `call_tool` فراخوانی کردیم.

### C#

1. بیایید کدی اضافه کنیم برای فراخوانی یک ابزار:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. برای چاپ نتیجه، این کد را داریم:

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

- چند ابزار ماشین حساب را با استفاده از متد `callTool()` و اشیاء `CallToolRequest` فراخوانی کردیم.
- هر فراخوانی ابزار نام ابزار و یک `Map` از آرگومان‌های مورد نیاز آن ابزار را مشخص می‌کند.
- ابزارهای سرور انتظار دارند پارامترهای خاصی (مثل "a"، "b" برای عملیات ریاضی) دریافت کنند.
- نتایج به صورت اشیاء `CallToolResult` که پاسخ سرور را شامل می‌شوند، بازگردانده می‌شوند.

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

در این تمرین، از آنچه یاد گرفته‌اید برای ایجاد یک کلاینت استفاده می‌کنید اما کلاینت خودتان را می‌سازید.

در اینجا یک سرور دارید که باید از طریق کد کلاینت خود به آن فراخوانی بزنید، ببینید آیا می‌توانید ویژگی‌های بیشتری به سرور اضافه کنید تا جذاب‌تر شود.

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

برای دیدن نحوه [افزودن پرامپت‌ها و منابع](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs) این پروژه را ببینید.

همچنین این لینک را برای نحوه فراخوانی [پرامپت‌ها و منابع](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/) بررسی کنید.

## راه‌حل

[راه‌حل](./solution/README.md)

## نکات کلیدی

نکات کلیدی این فصل درباره کلاینت‌ها عبارتند از:

- می‌توانند برای کشف و فراخوانی ویژگی‌ها روی سرور استفاده شوند.
- می‌توانند سرور را هنگام شروع خودشان راه‌اندازی کنند (مثل این فصل) اما کلاینت‌ها می‌توانند به سرورهای در حال اجرا نیز متصل شوند.
- راه بسیار خوبی برای تست قابلیت‌های سرور در کنار گزینه‌هایی مثل Inspector است که در فصل قبل توضیح داده شد.

## منابع اضافی

- [ساخت کلاینت‌ها در MCP](https://modelcontextprotocol.io/quickstart/client)

## نمونه‌ها

- [ماشین حساب جاوا](../samples/java/calculator/README.md)
- [ماشین حساب .Net](../../../../03-GettingStarted/samples/csharp)
- [ماشین حساب جاوااسکریپت](../samples/javascript/README.md)
- [ماشین حساب TypeScript](../samples/typescript/README.md)
- [ماشین حساب پایتون](../../../../03-GettingStarted/samples/python)

## مرحله بعد

- بعدی: [ایجاد کلاینت با LLM](../03-llm-client/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.