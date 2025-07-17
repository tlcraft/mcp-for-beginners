<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-16T20:57:12+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "zh"
}
-->
# 创建客户端

客户端是与 MCP 服务器直接通信以请求资源、工具和提示的自定义应用程序或脚本。与使用提供图形界面与服务器交互的检查器工具不同，编写自己的客户端可以实现程序化和自动化的交互。这使开发者能够将 MCP 功能集成到自己的工作流程中，自动化任务，并构建针对特定需求的定制解决方案。

## 概述

本课介绍了 Model Context Protocol (MCP) 生态系统中的客户端概念。你将学习如何编写自己的客户端并连接到 MCP 服务器。

## 学习目标

完成本课后，你将能够：

- 理解客户端的功能。
- 编写自己的客户端。
- 连接并测试客户端与 MCP 服务器，确保服务器按预期工作。

## 编写客户端需要做什么？

编写客户端时，你需要完成以下步骤：

- **导入正确的库**。你将使用之前相同的库，只是使用不同的构造。
- **实例化客户端**。这包括创建客户端实例并连接到所选的传输方式。
- **决定列出哪些资源**。你的 MCP 服务器包含资源、工具和提示，你需要决定列出哪些。
- **将客户端集成到宿主应用中**。一旦了解服务器的功能，就需要将客户端集成到宿主应用中，这样当用户输入提示或其他命令时，就会调用相应的服务器功能。

了解了整体流程后，接下来让我们看一个示例。

### 示例客户端

来看这个示例客户端：

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

在上面的代码中，我们：

- 导入了库
- 创建了客户端实例，并使用 stdio 作为传输方式连接
- 列出了提示、资源和工具，并调用了它们

这就是一个可以与 MCP 服务器通信的客户端。

接下来，我们将在练习部分详细拆解每段代码，解释其作用。

## 练习：编写客户端

如上所述，我们将花时间详细讲解代码，如果愿意，也可以边学边写。

### -1- 导入库

先导入所需的库，我们需要引用客户端和所选的传输协议 stdio。stdio 是用于本地机器运行的协议。SSE 是另一种传输协议，我们将在后续章节介绍，但目前先用 stdio。

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

对于 Java，你将创建一个连接到前面练习中 MCP 服务器的客户端。使用 [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) 中相同的 Java Spring Boot 项目结构，在 `src/main/java/com/microsoft/mcp/sample/client/` 文件夹下创建一个名为 `SDKClient` 的新 Java 类，并添加以下导入：

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

接下来进行实例化。

### -2- 实例化客户端和传输

我们需要创建传输实例和客户端实例：

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

在上面的代码中，我们：

- 创建了一个 stdio 传输实例。注意它指定了启动服务器的命令和参数，因为创建客户端时需要启动服务器。

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- 通过指定名称和版本实例化了客户端。

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- 将客户端连接到所选传输。

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

在上面的代码中，我们：

- 导入了所需库
- 实例化了服务器参数对象，用于运行服务器以便客户端连接
- 定义了一个 `run` 方法，调用 `stdio_client` 启动客户端会话
- 创建了入口点，使用 `asyncio.run` 调用 `run` 方法

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

在上面的代码中，我们：

- 导入了所需库
- 创建了 stdio 传输和客户端 `mcpClient`，后者用于列出和调用 MCP 服务器上的功能

注意，“Arguments” 中可以指向 *.csproj* 文件或可执行文件。

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

在上面的代码中，我们：

- 创建了一个 main 方法，设置了指向 `http://localhost:8080` 的 SSE 传输，MCP 服务器将在此运行
- 创建了一个客户端类，构造函数接收传输参数
- 在 `run` 方法中，使用传输创建同步 MCP 客户端并初始化连接
- 使用了适合 Java Spring Boot MCP 服务器的 SSE（服务器发送事件）传输

### -3- 列出服务器功能

现在我们有了可以连接的客户端，但它还没有列出服务器功能，接下来实现这一点：

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

这里我们列出了可用的资源 `list_resources()` 和工具 `list_tools`，并打印出来。

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

上面是列出服务器工具的示例。对于每个工具，我们打印其名称。

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

在上面的代码中，我们：

- 调用了 `listTools()` 获取 MCP 服务器上的所有工具
- 使用 `ping()` 验证与服务器的连接是否正常
- `ListToolsResult` 包含所有工具的信息，包括名称、描述和输入模式

很好，现在我们获取了所有功能。问题是何时使用它们？这个客户端比较简单，需要显式调用功能。下一章我们将创建一个更高级的客户端，内置大型语言模型（LLM）。现在先看看如何调用服务器上的功能：

### -4- 调用功能

调用功能时，需要确保传入正确的参数，有时还要指定调用的名称。

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

在上面的代码中，我们：

- 读取资源，通过调用 `readResource()` 并指定 `uri`。服务器端大致如下：

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

    我们的 `uri` 值 `file://example.txt` 匹配服务器端的 `file://{name}`，`example.txt` 会映射到 `name`。

- 调用工具，通过指定其 `name` 和 `arguments`：

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- 获取提示，调用 `getPrompt()` 并传入 `name` 和 `arguments`。服务器端代码如下：

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

    因此客户端代码如下，匹配服务器声明：

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

在上面的代码中，我们：

- 使用 `read_resource` 调用了名为 `greeting` 的资源
- 使用 `call_tool` 调用了名为 `add` 的工具

### C#

1. 添加调用工具的代码：

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

2. 打印结果的代码：

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

在上面的代码中，我们：

- 使用 `callTool()` 方法和 `CallToolRequest` 对象调用了多个计算器工具
- 每个工具调用都指定了工具名称和所需参数的 `Map`
- 服务器工具期望特定参数名（如数学运算的 "a"、"b"）
- 结果作为 `CallToolResult` 对象返回，包含服务器响应

### -5- 运行客户端

在终端输入以下命令运行客户端：

### TypeScript

在 *package.json* 的 "scripts" 部分添加以下内容：

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

使用以下命令调用客户端：

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

确保 MCP 服务器运行在 `http://localhost:8080`，然后运行客户端：

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

或者，你也可以运行解决方案文件夹 `03-GettingStarted\02-client\solution\java` 中提供的完整客户端项目：

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## 任务

本任务中，你将运用所学创建自己的客户端。

这里有一个服务器，你需要通过客户端代码调用它，试着为服务器添加更多功能，使其更有趣。

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

查看此项目了解如何[添加提示和资源](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)。

另外，查看此链接了解如何调用[提示和资源](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/)。

## 解决方案

[解决方案](./solution/README.md)

## 关键要点

本章关于客户端的关键要点如下：

- 可用于发现和调用服务器上的功能。
- 可以在启动自身时启动服务器（如本章所示），也可以连接到已运行的服务器。
- 是测试服务器功能的好方法，除了前章介绍的 Inspector 之外的另一种选择。

## 额外资源

- [在 MCP 中构建客户端](https://modelcontextprotocol.io/quickstart/client)

## 示例

- [Java 计算器](../samples/java/calculator/README.md)
- [.Net 计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 计算器](../samples/javascript/README.md)
- [TypeScript 计算器](../samples/typescript/README.md)
- [Python 计算器](../../../../03-GettingStarted/samples/python)

## 接下来

- 下一章：[使用 LLM 创建客户端](../03-llm-client/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们概不负责。