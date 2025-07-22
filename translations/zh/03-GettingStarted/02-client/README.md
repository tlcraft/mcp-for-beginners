<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "22afa94e3912cd37af9ff20cf4aebc93",
  "translation_date": "2025-07-22T06:59:31+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "zh"
}
-->
# 创建客户端

客户端是与 MCP 服务器直接通信以请求资源、工具和提示的自定义应用程序或脚本。与使用提供图形界面的检查工具不同，编写自己的客户端可以实现程序化和自动化的交互。这使得开发者能够将 MCP 的功能集成到自己的工作流中，自动化任务，并根据特定需求构建定制化解决方案。

## 概述

本课程介绍了 Model Context Protocol (MCP) 生态系统中的客户端概念。您将学习如何编写自己的客户端并将其连接到 MCP 服务器。

## 学习目标

完成本课程后，您将能够：

- 理解客户端的功能。
- 编写自己的客户端。
- 将客户端连接到 MCP 服务器并进行测试，以确保服务器正常运行。

## 编写客户端需要做什么？

要编写一个客户端，您需要完成以下步骤：

- **导入正确的库**。您将使用之前相同的库，但需要使用不同的构造。
- **实例化一个客户端**。这包括创建一个客户端实例并将其连接到选定的传输方法。
- **决定要列出哪些资源**。您的 MCP 服务器提供资源、工具和提示，您需要决定列出哪些内容。
- **将客户端集成到主机应用程序中**。一旦了解了服务器的功能，您需要将其集成到主机应用程序中，以便用户输入提示或其他命令时，能够调用相应的服务器功能。

现在我们已经了解了高层次的操作步骤，接下来让我们看一个示例。

### 示例客户端

以下是一个示例客户端：

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

在上述代码中，我们：

- 导入了库。
- 创建了一个客户端实例，并使用 stdio 作为传输方式进行连接。
- 列出了提示、资源和工具，并调用了它们。

这就是一个可以与 MCP 服务器通信的客户端。

接下来，我们将在练习部分逐步分解每段代码并解释其作用。

## 练习：编写客户端

如上所述，我们将花时间解释代码，您也可以边学边写代码。

### -1- 导入库

首先导入我们需要的库，我们需要引用客户端和选定的传输协议 stdio。stdio 是一种适用于本地运行的协议。SSE 是另一种传输协议，我们将在后续章节中介绍，但目前我们先使用 stdio。

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

对于 Java，您将创建一个客户端，该客户端连接到之前练习中的 MCP 服务器。使用 [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) 中的 Java Spring Boot 项目结构，在 `src/main/java/com/microsoft/mcp/sample/client/` 文件夹中创建一个名为 `SDKClient` 的 Java 类，并添加以下导入：

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

接下来我们进行实例化。

### -2- 实例化客户端和传输

我们需要创建传输实例以及客户端实例：

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

在上述代码中，我们：

- 创建了一个 stdio 传输实例。注意它如何指定命令和参数以找到并启动服务器，这是我们在创建客户端时需要做的。

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- 通过指定名称和版本实例化了一个客户端。

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- 将客户端连接到选定的传输方式。

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

在上述代码中，我们：

- 导入了所需的库。
- 实例化了一个服务器参数对象，用于运行服务器以便我们可以通过客户端连接到它。
- 定义了一个 `run` 方法，该方法调用 `stdio_client` 来启动客户端会话。
- 创建了一个入口点，将 `run` 方法提供给 `asyncio.run`。

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

在上述代码中，我们：

- 导入了所需的库。
- 创建了一个 stdio 传输实例，并创建了一个客户端 `mcpClient`。后者将用于列出和调用 MCP 服务器上的功能。

注意，在 "Arguments" 中，您可以指向 *.csproj* 文件或可执行文件。

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

在上述代码中，我们：

- 创建了一个主方法，设置了一个指向 `http://localhost:8080` 的 SSE 传输，该地址是 MCP 服务器运行的地方。
- 创建了一个客户端类，该类将传输作为构造函数参数。
- 在 `run` 方法中，我们使用传输创建了一个同步 MCP 客户端并初始化了连接。
- 使用了 SSE（服务器发送事件）传输，这适用于基于 HTTP 的 Java Spring Boot MCP 服务器通信。

### -3- 列出服务器功能

现在，我们有了一个可以连接的客户端，但它实际上并没有列出服务器的功能，所以接下来我们来实现这一点：

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

在这里，我们列出了可用的资源 `list_resources()` 和工具 `list_tools`，并将它们打印出来。

#### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

以上是一个列出服务器工具的示例。对于每个工具，我们打印出其名称。

#### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

在上述代码中，我们：

- 调用了 `listTools()` 来获取 MCP 服务器上的所有可用工具。
- 使用 `ping()` 验证与服务器的连接是否正常。
- `ListToolsResult` 包含所有工具的信息，包括它们的名称、描述和输入模式。

很好，现在我们已经捕获了所有功能。接下来的问题是何时使用它们？这个客户端相对简单，需要我们显式调用功能。在下一章中，我们将创建一个更高级的客户端，它将拥有自己的大型语言模型（LLM）。不过现在，让我们看看如何调用服务器上的功能：

### -4- 调用功能

要调用功能，我们需要确保指定正确的参数，有时还需要指定要调用的名称。

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

在上述代码中，我们：

- 读取了一个资源，通过调用 `readResource()` 并指定 `uri` 来实现。以下是服务器端的代码示例：

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

    我们的 `uri` 值 `file://example.txt` 与服务器上的 `file://{name}` 匹配。`example.txt` 将映射到 `name`。

- 调用了一个工具，通过指定其 `name` 和 `arguments` 来实现：

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- 获取了一个提示，通过调用 `getPrompt()` 并提供 `name` 和 `arguments` 来实现。服务器代码如下：

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

    因此，客户端代码如下，以匹配服务器上声明的内容：

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

在上述代码中，我们：

- 使用 `read_resource` 调用了一个名为 `greeting` 的资源。
- 使用 `call_tool` 调用了一个名为 `add` 的工具。

#### .NET

1. 添加一些代码以调用工具：

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

2. 打印结果的代码如下：

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

在上述代码中，我们：

- 使用 `callTool()` 方法和 `CallToolRequest` 对象调用了多个计算器工具。
- 每个工具调用都指定了工具名称和所需参数的 `Map`。
- 服务器工具期望特定的参数名称（如数学操作中的 "a" 和 "b"）。
- 结果以 `CallToolResult` 对象的形式返回，包含服务器的响应。

### -5- 运行客户端

要运行客户端，请在终端中输入以下命令：

#### TypeScript

在 *package.json* 的 "scripts" 部分添加以下条目：

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

#### Python

使用以下命令调用客户端：

```sh
python client.py
```

#### .NET

```sh
dotnet run
```

#### Java

首先，确保您的 MCP 服务器正在 `http://localhost:8080` 上运行。然后运行客户端：

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

或者，您可以运行解决方案文件夹 `03-GettingStarted\02-client\solution\java` 中提供的完整客户端项目：

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## 作业

在本次作业中，您将使用所学内容创建自己的客户端。

以下是一个服务器，您需要通过客户端代码调用它，尝试为服务器添加更多功能，使其更有趣。

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

请参阅此项目以了解如何 [添加提示和资源](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)。

同时，查看此链接以了解如何调用 [提示和资源](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/)。

## 解决方案

**解决方案文件夹** 包含完整的、可运行的客户端实现，展示了本教程中涵盖的所有概念。每个解决方案包括客户端和服务器代码，组织为独立的项目。

### 📁 解决方案结构

解决方案目录按编程语言组织：

```text
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

### 🚀 每个解决方案包含的内容

每个语言特定的解决方案提供：

- **完整的客户端实现**，包含教程中的所有功能
- **工作项目结构**，具有适当的依赖项和配置
- **构建和运行脚本**，便于设置和执行
- **详细的 README**，提供语言特定的说明
- **错误处理** 和结果处理示例

### 📖 使用解决方案

1. **导航到您选择的语言文件夹**：

   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **按照每个文件夹中的 README 说明**：
   - 安装依赖项
   - 构建项目
   - 运行客户端

3. **您应该看到的示例输出**：

   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

有关完整文档和分步说明，请参阅：**[📖 解决方案文档](./solution/README.md)**

## 🎯 完整示例

我们为本教程中涵盖的所有编程语言提供了完整的、可运行的客户端实现。这些示例展示了上述功能的完整实现，可用作参考实现或您自己项目的起点。

### 可用的完整示例

| 语言 | 文件 | 描述 |
|------|------|------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | 使用 SSE 传输的完整 Java 客户端，包含全面的错误处理 |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | 使用 stdio 传输的完整 C# 客户端，支持自动服务器启动 |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | 完整的 TypeScript 客户端，支持 MCP 协议的所有功能 |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | 使用异步/等待模式的完整 Python 客户端 |

每个完整示例包括：

- ✅ **连接建立** 和错误处理
- ✅ **服务器发现**（工具、资源、提示等）
- ✅ **计算器操作**（加法、减法、乘法、除法、帮助）
- ✅ **结果处理** 和格式化输出
- ✅ **全面的错误处理**
- ✅ **清晰、文档化的代码**，带有分步注释

### 开始使用完整示例

1. **选择您喜欢的语言**，从上表中找到对应的示例。
2. **查看完整示例文件**，了解完整实现。
3. **运行示例**，按照 [`complete_examples.md`](./complete_examples.md) 中的说明操作。
4. **修改和扩展** 示例以满足您的具体需求。

有关运行和自定义这些示例的详细文档，请参阅：**[📖 完整示例文档](./complete_examples.md)**

### 💡 解决方案与完整示例的区别

| **解决方案文件夹** | **完整示例** |
|--------------------|--------------|
| 包含构建文件的完整项目结构 | 单文件实现 |
| 可直接运行，包含依赖项 | 专注于代码示例 |
| 类生产环境的设置 | 教学参考 |
| 语言特定工具支持 | 跨语言对比 |
两种方法都很有价值——对于完整的项目，请使用**解决方案文件夹**，而对于学习和参考，请使用**完整示例**。

## 关键要点

本章关于客户端的关键要点如下：

- 可以用于发现和调用服务器上的功能。
- 可以在自身启动时启动服务器（如本章所述），但客户端也可以连接到正在运行的服务器。
- 是测试服务器功能的绝佳方式，与上一章提到的 Inspector 等替代方案相比非常有用。

## 其他资源

- [在 MCP 中构建客户端](https://modelcontextprotocol.io/quickstart/client)

## 示例

- [Java 计算器](../samples/java/calculator/README.md)
- [.Net 计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 计算器](../samples/javascript/README.md)
- [TypeScript 计算器](../samples/typescript/README.md)
- [Python 计算器](../../../../03-GettingStarted/samples/python)

## 接下来

- 下一步：[使用 LLM 创建客户端](../03-llm-client/README.md)

**免责声明**：  
本文档使用AI翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们努力确保翻译的准确性，但请注意，自动翻译可能包含错误或不准确之处。原始语言的文档应被视为权威来源。对于重要信息，建议使用专业人工翻译。我们不对因使用此翻译而产生的任何误解或误读承担责任。