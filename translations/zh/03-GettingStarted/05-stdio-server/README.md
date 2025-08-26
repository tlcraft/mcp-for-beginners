<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:20:43+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "zh"
}
-->
# MCP服务器与stdio传输

> **⚠️重要更新**：自MCP规范2025-06-18起，独立的SSE（服务器发送事件）传输已被**弃用**，并由“可流式HTTP”传输取代。目前的MCP规范定义了两种主要的传输机制：
> 1. **stdio** - 标准输入/输出（推荐用于本地服务器）
> 2. **可流式HTTP** - 用于可能在内部使用SSE的远程服务器
>
> 本课程已更新为重点介绍**stdio传输**，这是大多数MCP服务器实现的推荐方法。

stdio传输允许MCP服务器通过标准输入和输出流与客户端通信。这是当前MCP规范中最常用且推荐的传输机制，提供了一种简单高效的方式来构建MCP服务器，并能轻松与各种客户端应用集成。

## 概述

本课程涵盖如何使用stdio传输构建和使用MCP服务器。

## 学习目标

完成本课程后，您将能够：

- 使用stdio传输构建MCP服务器。
- 使用Inspector调试MCP服务器。
- 使用Visual Studio Code消费MCP服务器。
- 理解当前MCP传输机制及推荐使用stdio的原因。

## stdio传输 - 工作原理

stdio传输是当前MCP规范（2025-06-18）支持的两种传输类型之一。其工作原理如下：

- **简单通信**：服务器从标准输入（`stdin`）读取JSON-RPC消息，并将消息发送到标准输出（`stdout`）。
- **基于进程**：客户端将MCP服务器作为子进程启动。
- **消息格式**：消息是单独的JSON-RPC请求、通知或响应，以换行符分隔。
- **日志记录**：服务器可以将UTF-8字符串写入标准错误（`stderr`）用于日志记录。

### 关键要求：
- 消息必须以换行符分隔，且不得包含嵌入的换行符。
- 服务器不得向`stdout`写入任何非有效MCP消息的内容。
- 客户端不得向服务器的`stdin`写入任何非有效MCP消息的内容。

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

在上述代码中：

- 我们从MCP SDK中导入了`Server`类和`StdioServerTransport`。
- 我们创建了一个具有基本配置和功能的服务器实例。

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

在上述代码中，我们：

- 使用MCP SDK创建了一个服务器实例。
- 使用装饰器定义工具。
- 使用stdio_server上下文管理器处理传输。

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

与SSE的主要区别在于stdio服务器：

- 不需要设置Web服务器或HTTP端点。
- 由客户端作为子进程启动。
- 通过stdin/stdout流通信。
- 实现和调试更简单。

## 练习：创建一个stdio服务器

要创建我们的服务器，需要注意以下两点：

- 我们需要使用Web服务器来公开连接和消息的端点。

## 实验：创建一个简单的MCP stdio服务器

在本实验中，我们将使用推荐的stdio传输创建一个简单的MCP服务器。该服务器将公开工具，供客户端使用标准模型上下文协议调用。

### 前置条件

- Python 3.8或更高版本
- MCP Python SDK：`pip install mcp`
- 基本的异步编程知识

让我们开始创建第一个MCP stdio服务器：

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## 与已弃用的SSE方法的主要区别

**Stdio传输（当前标准）：**
- 简单的子进程模型 - 客户端将服务器作为子进程启动。
- 通过stdin/stdout使用JSON-RPC消息进行通信。
- 不需要设置HTTP服务器。
- 性能和安全性更好。
- 调试和开发更容易。

**SSE传输（自MCP 2025-06-18起弃用）：**
- 需要带有SSE端点的HTTP服务器。
- 使用Web服务器基础设施设置更复杂。
- 对HTTP端点的额外安全性考虑。
- 现已被可流式HTTP取代，用于基于Web的场景。

### 使用stdio传输创建服务器

要创建我们的stdio服务器，我们需要：

1. **导入所需库** - 我们需要MCP服务器组件和stdio传输。
2. **创建服务器实例** - 定义服务器及其功能。
3. **定义工具** - 添加我们希望公开的功能。
4. **设置传输** - 配置stdio通信。
5. **运行服务器** - 启动服务器并处理消息。

让我们一步步构建：

### 第一步：创建一个基本的stdio服务器

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### 第二步：添加更多工具

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### 第三步：运行服务器

将代码保存为`server.py`并从命令行运行：

```bash
python server.py
```

服务器将启动并等待从stdin接收输入。它通过stdio传输使用JSON-RPC消息进行通信。

### 第四步：使用Inspector进行测试

您可以使用MCP Inspector测试您的服务器：

1. 安装Inspector：`npx @modelcontextprotocol/inspector`
2. 运行Inspector并指向您的服务器。
3. 测试您创建的工具。

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// 添加工具
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "获取个性化问候语",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "需要问候的人的名字",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `你好，${request.params.arguments?.name}！欢迎使用MCP stdio服务器。`,
        },
      ],
    };
  } else {
    throw new Error(`未知工具：${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("获取个性化问候语")]
    public string GetGreeting(string name)
    {
        return $"你好，{name}！欢迎使用MCP stdio服务器。";
    }

    [Description("计算两个数字的和")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. 首先创建一些工具，为此我们将创建一个文件*Tools.cs*，内容如下：

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **打开Web界面**：Inspector将打开一个浏览器窗口，显示您的服务器功能。

3. **测试工具**： 
   - 使用不同的名字测试`get_greeting`工具。
   - 使用各种数字测试`calculate_sum`工具。
   - 调用`get_server_info`工具查看服务器元数据。

4. **监控通信**：Inspector显示客户端和服务器之间交换的JSON-RPC消息。

### 您应该看到的内容

当您的服务器正确启动时，您应该看到：
- Inspector中列出的服务器功能。
- 可供测试的工具。
- 成功的JSON-RPC消息交换。
- 界面中显示的工具响应。

### 常见问题及解决方案

**服务器无法启动：**
- 检查是否安装了所有依赖项：`pip install mcp`
- 验证Python语法和缩进。
- 查看控制台中的错误消息。

**工具未显示：**
- 确保存在`@server.tool()`装饰器。
- 检查工具函数是否在`main()`之前定义。
- 验证服务器是否正确配置。

**连接问题：**
- 确保服务器正确使用stdio传输。
- 检查是否有其他进程干扰。
- 验证Inspector命令语法。

## 作业

尝试为您的服务器添加更多功能。例如，您可以参考[此页面](https://api.chucknorris.io/)添加一个调用API的工具。您可以自由设计服务器的功能。玩得开心 :)

## 解决方案

[解决方案](./solution/README.md) 提供了一个可能的解决方案及工作代码。

## 关键点总结

本章的关键点如下：

- stdio传输是本地MCP服务器的推荐机制。
- stdio传输允许MCP服务器和客户端通过标准输入和输出流进行无缝通信。
- 您可以直接使用Inspector和Visual Studio Code消费stdio服务器，使调试和集成变得简单。

## 示例 

- [Java计算器](../samples/java/calculator/README.md)
- [.Net计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript计算器](../samples/javascript/README.md)
- [TypeScript计算器](../samples/typescript/README.md)
- [Python计算器](../../../../03-GettingStarted/samples/python) 

## 额外资源

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 下一步

## 后续步骤

现在您已经学习了如何使用stdio传输构建MCP服务器，可以探索更高级的主题：

- **下一步**：[MCP的HTTP流式传输（可流式HTTP）](../06-http-streaming/README.md) - 学习远程服务器支持的另一种传输机制。
- **高级**：[MCP安全最佳实践](../../02-Security/README.md) - 在MCP服务器中实现安全性。
- **生产环境**：[部署策略](../09-deployment/README.md) - 将您的服务器部署到生产环境。

## 额外资源

- [MCP规范2025-06-18](https://spec.modelcontextprotocol.io/specification/) - 官方规范。
- [MCP SDK文档](https://github.com/modelcontextprotocol/sdk) - 各语言的SDK参考。
- [社区示例](../../06-CommunityContributions/README.md) - 更多社区提供的服务器示例。

---

**免责声明**：  
本文档使用AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)进行翻译。尽管我们努力确保翻译的准确性，但请注意，自动翻译可能包含错误或不准确之处。原始语言的文档应被视为权威来源。对于关键信息，建议使用专业人工翻译。我们不对因使用此翻译而产生的任何误解或误读承担责任。