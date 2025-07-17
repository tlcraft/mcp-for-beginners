<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:36:32+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ar"
}
-->
# إنشاء عميل

العملاء هم تطبيقات مخصصة أو سكريبتات تتواصل مباشرة مع خادم MCP لطلب الموارد، الأدوات، والتعليمات. على عكس استخدام أداة المفتش التي توفر واجهة رسومية للتفاعل مع الخادم، كتابة عميل خاص بك تتيح تفاعلات برمجية وآلية. هذا يمكّن المطورين من دمج قدرات MCP في سير عملهم، أتمتة المهام، وبناء حلول مخصصة تلبي احتياجات محددة.

## نظرة عامة

تقدم هذه الدرس مفهوم العملاء ضمن نظام بروتوكول سياق النموذج (MCP). ستتعلم كيفية كتابة عميل خاص بك وجعله يتصل بخادم MCP.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- فهم ما يمكن للعميل القيام به.
- كتابة عميل خاص بك.
- الاتصال واختبار العميل مع خادم MCP للتأكد من عمل الأخير كما هو متوقع.

## ما الذي يتطلبه كتابة عميل؟

لكتابة عميل، ستحتاج إلى القيام بما يلي:

- **استيراد المكتبات الصحيحة**. ستستخدم نفس المكتبة كما في السابق، لكن مع تراكيب مختلفة.
- **إنشاء مثيل للعميل**. يتضمن ذلك إنشاء نسخة من العميل وربطها بطريقة النقل المختارة.
- **تحديد الموارد التي سيتم سردها**. يأتي خادم MCP مع موارد، أدوات وتعليمات، عليك تحديد أي منها تريد عرضه.
- **دمج العميل مع تطبيق مضيف**. بمجرد معرفة قدرات الخادم، تحتاج إلى دمج هذا مع تطبيق المضيف بحيث إذا كتب المستخدم تعليمات أو أوامر أخرى يتم استدعاء الميزة المقابلة على الخادم.

الآن بعد أن فهمنا بشكل عام ما سنفعله، دعونا نلقي نظرة على مثال.

### مثال على عميل

لننظر إلى هذا المثال على عميل:

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

في الكود السابق قمنا بـ:

- استيراد المكتبات
- إنشاء نسخة من العميل وربطها باستخدام stdio كطريقة نقل.
- سرد التعليمات، الموارد، والأدوات واستدعاؤها جميعًا.

ها هو لديك، عميل يمكنه التحدث إلى خادم MCP.

دعونا نأخذ وقتنا في القسم التالي من التمرين ونفصل كل جزء من الكود ونشرح ما يحدث.

## تمرين: كتابة عميل

كما ذكرنا أعلاه، دعونا نأخذ وقتنا في شرح الكود، وبالطبع يمكنك البرمجة معنا إذا أردت.

### -1- استيراد المكتبات

لنستورد المكتبات التي نحتاجها، سنحتاج إلى مراجع للعميل وبروتوكول النقل المختار، stdio. stdio هو بروتوكول مخصص للأشياء التي تعمل على جهازك المحلي. SSE هو بروتوكول نقل آخر سنعرضه في الفصول القادمة لكنه خيار آخر. لكن الآن، لنكمل مع stdio.

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

بالنسبة لجافا، ستنشئ عميلًا يتصل بخادم MCP من التمرين السابق. باستخدام نفس هيكل مشروع Java Spring Boot من [البدء مع MCP Server](../../../../03-GettingStarted/01-first-server/solution/java)، أنشئ فئة جافا جديدة باسم `SDKClient` في المجلد `src/main/java/com/microsoft/mcp/sample/client/` وأضف الاستيرادات التالية:

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

لننتقل إلى إنشاء المثيل.

### -2- إنشاء مثيل للعميل والنقل

سنحتاج إلى إنشاء نسخة من النقل ونسخة من العميل:

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

في الكود السابق قمنا بـ:

- إنشاء نسخة من نقل stdio. لاحظ كيف يحدد الأمر والوسائط لكيفية العثور على الخادم وتشغيله لأن هذا شيء سنحتاج لفعله أثناء إنشاء العميل.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- إنشاء نسخة من العميل بإعطائه اسمًا وإصدارًا.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- ربط العميل بالنقل المختار.

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

في الكود السابق قمنا بـ:

- استيراد المكتبات اللازمة
- إنشاء كائن معلمات الخادم لاستخدامه لتشغيل الخادم حتى نتمكن من الاتصال به عبر العميل.
- تعريف دالة `run` التي تستدعي بدورها `stdio_client` التي تبدأ جلسة العميل.
- إنشاء نقطة دخول حيث نوفر دالة `run` لـ `asyncio.run`.

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

في الكود السابق قمنا بـ:

- استيراد المكتبات اللازمة.
- إنشاء نقل stdio وإنشاء عميل `mcpClient`. هذا الأخير هو ما سنستخدمه لسرد واستدعاء الميزات على خادم MCP.

ملاحظة، في "Arguments"، يمكنك الإشارة إما إلى ملف *.csproj* أو إلى الملف التنفيذي.

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

في الكود السابق قمنا بـ:

- إنشاء دالة main التي تضبط نقل SSE مشيرة إلى `http://localhost:8080` حيث سيعمل خادم MCP الخاص بنا.
- إنشاء فئة عميل تأخذ النقل كمعامل منشئ.
- في دالة `run`، ننشئ عميل MCP متزامن باستخدام النقل ونبدأ الاتصال.
- استخدمنا نقل SSE (Server-Sent Events) المناسب للتواصل عبر HTTP مع خوادم MCP المبنية على Java Spring Boot.

### -3- سرد ميزات الخادم

الآن، لدينا عميل يمكنه الاتصال إذا تم تشغيل البرنامج. مع ذلك، لا يقوم فعليًا بسرد ميزاته، فلنقم بذلك الآن:

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

هنا نسرد الموارد المتاحة `list_resources()` والأدوات `list_tools` ونطبعها.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

أعلاه مثال على كيفية سرد الأدوات على الخادم. لكل أداة، نطبع اسمها.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

في الكود السابق قمنا بـ:

- استدعاء `listTools()` للحصول على جميع الأدوات المتاحة من خادم MCP.
- استخدام `ping()` للتحقق من أن الاتصال بالخادم يعمل.
- يحتوي `ListToolsResult` على معلومات عن جميع الأدوات بما في ذلك أسماؤها، أوصافها، ومخططات الإدخال الخاصة بها.

رائع، الآن قمنا بجمع كل الميزات. الآن السؤال متى نستخدمها؟ حسنًا، هذا العميل بسيط جدًا، بمعنى أننا سنحتاج إلى استدعاء الميزات صراحةً عندما نريدها. في الفصل التالي، سننشئ عميلًا أكثر تقدمًا يمتلك نموذج لغة كبير خاص به، LLM. لكن الآن، دعونا نرى كيف يمكننا استدعاء الميزات على الخادم:

### -4- استدعاء الميزات

لاستدعاء الميزات، نحتاج إلى التأكد من تحديد الوسائط الصحيحة وفي بعض الحالات اسم ما نحاول استدعاءه.

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

في الكود السابق قمنا بـ:

- قراءة مورد، نستدعي المورد عبر `readResource()` مع تحديد `uri`. هذا ما يبدو عليه على جانب الخادم:

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

    قيمة `uri` لدينا `file://example.txt` تطابق `file://{name}` على الخادم. `example.txt` سيتم تعيينها إلى `name`.

- استدعاء أداة، نستدعيها بتحديد `name` و `arguments` هكذا:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- الحصول على تعليمات، لاستدعاء تعليمات، تستخدم `getPrompt()` مع `name` و `arguments`. كود الخادم يبدو هكذا:

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

    وبالتالي يبدو كود العميل الناتج هكذا ليتطابق مع ما هو معلن على الخادم:

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

في الكود السابق قمنا بـ:

- استدعاء مورد يسمى `greeting` باستخدام `read_resource`.
- استدعاء أداة تسمى `add` باستخدام `call_tool`.

### .NET

1. لنضيف بعض الكود لاستدعاء أداة:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. لطباعة النتيجة، إليك بعض الكود للتعامل مع ذلك:

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

في الكود السابق قمنا بـ:

- استدعاء عدة أدوات حاسبة باستخدام طريقة `callTool()` مع كائنات `CallToolRequest`.
- كل استدعاء أداة يحدد اسم الأداة و`Map` من الوسائط المطلوبة.
- أدوات الخادم تتوقع أسماء معلمات محددة (مثل "a"، "b" للعمليات الرياضية).
- تُعاد النتائج ككائنات `CallToolResult` تحتوي على استجابة الخادم.

### -5- تشغيل العميل

لتشغيل العميل، اكتب الأمر التالي في الطرفية:

### TypeScript

أضف الإدخال التالي إلى قسم "scripts" في *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

شغّل العميل بالأمر التالي:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

أولًا، تأكد من تشغيل خادم MCP على `http://localhost:8080`. ثم شغّل العميل:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

بدلاً من ذلك، يمكنك تشغيل مشروع العميل الكامل الموجود في مجلد الحل `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## المهمة

في هذه المهمة، ستستخدم ما تعلمته في إنشاء عميل لكن ستنشئ عميلًا خاصًا بك.

إليك خادم يمكنك استخدامه تحتاج إلى استدعائه عبر كود العميل الخاص بك، حاول إضافة المزيد من الميزات إلى الخادم لجعله أكثر إثارة.

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

راجع هذا المشروع لترى كيف يمكنك [إضافة التعليمات والموارد](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

أيضًا، تحقق من هذا الرابط لكيفية استدعاء [التعليمات والموارد](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## الحل

يحتوي **مجلد الحل** على تطبيقات عملاء كاملة وجاهزة للتشغيل توضح كل المفاهيم التي تم تغطيتها في هذا الدرس. كل حل يتضمن كود العميل والخادم منظم في مشاريع منفصلة ومستقلة.

### 📁 هيكل الحل

يتم تنظيم مجلد الحل حسب لغة البرمجة:

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

### 🚀 ماذا يتضمن كل حل

كل حل خاص بلغة معينة يوفر:

- **تطبيق عميل كامل** مع كل الميزات من الدرس
- **هيكل مشروع يعمل** مع الاعتمادات والتكوين المناسب
- **سكريبتات البناء والتشغيل** لتسهيل الإعداد والتنفيذ
- **README مفصل** مع تعليمات خاصة باللغة
- **أمثلة على التعامل مع الأخطاء** ومعالجة النتائج

### 📖 استخدام الحلول

1. **انتقل إلى مجلد اللغة المفضلة لديك**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **اتبع تعليمات README** في كل مجلد لـ:
   - تثبيت الاعتمادات
   - بناء المشروع
   - تشغيل العميل

3. **مثال على المخرجات** التي يجب أن تراها:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

للحصول على توثيق كامل وتعليمات خطوة بخطوة، راجع: **[📖 توثيق الحل](./solution/README.md)**

## 🎯 أمثلة كاملة

قدمنا تطبيقات عملاء كاملة وعاملة لكل لغات البرمجة التي تم تغطيتها في هذا الدرس. توضح هذه الأمثلة الوظائف الكاملة الموضحة أعلاه ويمكن استخدامها كنماذج مرجعية أو نقاط انطلاق لمشاريعك الخاصة.

### الأمثلة الكاملة المتاحة

| اللغة | الملف | الوصف |
|----------|------|-------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | عميل جافا كامل يستخدم نقل SSE مع معالجة شاملة للأخطاء |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | عميل C# كامل يستخدم نقل stdio مع بدء تشغيل تلقائي للخادم |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | عميل TypeScript كامل مع دعم كامل لبروتوكول MCP |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | عميل Python كامل يستخدم أنماط async/await |

كل مثال كامل يتضمن:

- ✅ **إقامة الاتصال** والتعامل مع الأخطاء
- ✅ **اكتشاف الخادم** (الأدوات، الموارد، التعليمات حيثما ينطبق)
- ✅ **عمليات الحاسبة** (جمع، طرح، ضرب، قسمة، مساعدة)
- ✅ **معالجة النتائج** والإخراج المنسق
- ✅ **معالجة شاملة للأخطاء**
- ✅ **كود نظيف وموثق** مع تعليقات خطوة بخطوة

### البدء مع الأمثلة الكاملة

1. **اختر لغتك المفضلة** من الجدول أعلاه
2. **راجع ملف المثال الكامل** لفهم التنفيذ الكامل
3. **شغّل المثال** باتباع التعليمات في [`complete_examples.md`](./complete_examples.md)
4. **عدّل ووسع** المثال لحالتك الخاصة

للحصول على توثيق مفصل حول تشغيل وتخصيص هذه الأمثلة، راجع: **[📖 توثيق الأمثلة الكاملة](./complete_examples.md)**

### 💡 الحل مقابل الأمثلة الكاملة

| **مجلد الحل** | **الأمثلة الكاملة** |
|--------------------|--------------------- |
| هيكل مشروع كامل مع ملفات البناء | تطبيقات في ملف واحد |
| جاهز للتشغيل مع الاعتمادات | أمثلة كود مركزة |
| إعداد يشبه الإنتاج | مرجع تعليمي |
| أدوات خاصة باللغة | مقارنة عبر اللغات |
كلا النهجين ذو قيمة - استخدم **مجلد الحلول** للمشاريع الكاملة و**الأمثلة الكاملة** للتعلم والرجوع إليها.  
## النقاط الرئيسية

النقاط الرئيسية لهذا الفصل حول العملاء هي كما يلي:

- يمكن استخدامها لاكتشاف الميزات على الخادم واستدعائها.
- يمكنها بدء تشغيل خادم أثناء تشغيلها (كما في هذا الفصل) ولكن يمكن للعملاء أيضًا الاتصال بالخوادم التي تعمل بالفعل.
- هي طريقة رائعة لاختبار قدرات الخادم إلى جانب بدائل مثل Inspector كما وُصف في الفصل السابق.

## موارد إضافية

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## عينات

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## ما التالي

- التالي: [Creating a client with an LLM](../03-llm-client/README.md)

**إخلاء مسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.