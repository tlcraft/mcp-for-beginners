<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T20:58:23+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "zh"
}
-->
# SSE 服务器

SSE（服务器发送事件）是一种服务器到客户端的流式传输标准，允许服务器通过 HTTP 向客户端推送实时更新。这对于需要实时更新的应用非常有用，比如聊天应用、通知或实时数据流。此外，你的服务器可以被多个客户端同时使用，因为它运行在服务器上，比如云端。

## 概述

本课将介绍如何构建和使用 SSE 服务器。

## 学习目标

完成本课后，你将能够：

- 构建一个 SSE 服务器。
- 使用 Inspector 调试 SSE 服务器。
- 使用 Visual Studio Code 连接并使用 SSE 服务器。

## SSE 是如何工作的

SSE 是两种支持的传输类型之一。你之前的课程中已经见过第一种 stdio 的使用。它们的区别如下：

- SSE 需要你处理两件事：连接和消息。
- 由于服务器可以部署在任何地方，你需要在使用 Inspector 和 Visual Studio Code 等工具时反映这一点。也就是说，你不是指定如何启动服务器，而是指定服务器的连接端点。下面是示例代码：

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

在上面的代码中：

- `/sse` 被设置为一个路由。当请求该路由时，会创建一个新的传输实例，服务器通过该传输进行*连接*。
- `/messages` 是处理传入消息的路由。

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

在上面的代码中，我们：

- 创建了一个 ASGI 服务器实例（特别使用 Starlette），并挂载了默认路由 `/`。

  背后发生的是，路由 `/sse` 和 `/messages` 分别被设置来处理连接和消息。应用的其他部分，比如添加工具等功能，和 stdio 服务器类似。

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    有两个方法帮助我们将普通的 Web 服务器转变为支持 SSE 的服务器：

    - `AddMcpServer`，该方法添加相关功能。
    - `MapMcp`，该方法添加类似 `/SSE` 和 `/messages` 的路由。

现在我们对 SSE 有了更多了解，接下来开始构建 SSE 服务器。

## 练习：创建 SSE 服务器

创建服务器时，需要牢记两点：

- 需要使用 Web 服务器来暴露连接和消息的端点。
- 构建服务器时，像使用 stdio 时一样使用工具、资源和提示。

### -1- 创建服务器实例

创建服务器时，使用和 stdio 相同的类型，但传输方式需要选择 SSE。

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

在上面的代码中，我们：

- 创建了服务器实例。
- 使用 Web 框架 express 定义了应用。
- 创建了一个 transports 变量，用于存储传入的连接。

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

在上面的代码中，我们：

- 导入了所需库，包含 Starlette（一个 ASGI 框架）。
- 创建了 MCP 服务器实例 `mcp`。

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

此时，我们：

- 创建了 Web 应用。
- 通过 `AddMcpServer` 添加了 MCP 功能支持。

接下来添加必要的路由。

### -2- 添加路由

接下来添加处理连接和传入消息的路由：

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

在上面的代码中，我们定义了：

- `/sse` 路由，实例化了 SSE 类型的传输，并调用 MCP 服务器的 `connect` 方法。
- `/messages` 路由，处理传入消息。

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

在上面的代码中，我们：

- 使用 Starlette 框架创建了 ASGI 应用实例。并将 `mcp.sse_app()` 传入路由列表，挂载了 `/sse` 和 `/messages` 路由。

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

我们在最后添加了一行代码 `add.MapMcp()`，这意味着现在有了 `/SSE` 和 `/messages` 路由。

接下来为服务器添加功能。

### -3- 添加服务器功能

现在 SSE 相关的内容都定义好了，接下来添加服务器功能，比如工具、提示和资源。

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

这里演示如何添加一个工具。这个工具创建了一个名为 "random-joke" 的工具，调用 Chuck Norris API 并返回 JSON 响应。

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

现在你的服务器有了一个工具。

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. 先创建一些工具，为此我们创建一个文件 *Tools.cs*，内容如下：

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  这里我们做了以下操作：

  - 创建了带有装饰器 `McpServerToolType` 的类 `Tools`。
  - 通过装饰器 `McpServerTool` 定义了一个工具 `AddNumbers`，并提供了参数和实现。

1. 利用刚创建的 `Tools` 类：

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  我们调用了 `WithTools`，指定 `Tools` 作为包含工具的类。就这样，准备就绪。

太棒了，我们有了一个使用 SSE 的服务器，接下来试运行一下。

## 练习：使用 Inspector 调试 SSE 服务器

Inspector 是一个很棒的工具，我们在之前的课程 [创建你的第一个服务器](/03-GettingStarted/01-first-server/README.md) 中见过。让我们看看这里是否也能用 Inspector：

### -1- 运行 Inspector

要运行 Inspector，首先必须有一个正在运行的 SSE 服务器，接下来启动服务器：

1. 启动服务器

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    注意这里使用了 `uvicorn` 可执行文件，它是在执行 `pip install "mcp[cli]"` 时安装的。`server:app` 表示运行 `server.py` 文件，并且该文件中有一个名为 `app` 的 Starlette 实例。

    ### .NET

    ```sh
    dotnet run
    ```

    这将启动服务器。要与之交互，需要打开一个新的终端。

1. 运行 Inspector

    > ![NOTE]
    > 请在与服务器不同的终端窗口中运行此命令。另外，注意根据你的服务器运行的 URL 调整下面的命令。

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    运行 Inspector 在所有运行时中看起来都一样。注意这里不是传入服务器路径和启动命令，而是传入服务器运行的 URL，并指定 `/sse` 路由。

### -2- 试用工具

通过下拉列表选择 SSE 连接方式，填写服务器运行的 URL，例如 http:localhost:4321/sse。点击“Connect”按钮。和之前一样，选择列出工具，选择一个工具并输入参数。你应该会看到如下结果：

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.zh.png)

太棒了，你已经可以使用 Inspector 了，接下来看看如何用 Visual Studio Code 连接。

## 任务

尝试为你的服务器添加更多功能。参考 [这个页面](https://api.chucknorris.io/) ，例如添加一个调用 API 的工具。服务器的样子由你决定。玩得开心 :)

## 解决方案

[解决方案](./solution/README.md) 这里有一个可用的示例代码。

## 关键要点

本章的关键要点如下：

- SSE 是继 stdio 之后支持的第二种传输方式。
- 支持 SSE 需要使用 Web 框架管理传入的连接和消息。
- 你可以像使用 stdio 服务器一样，使用 Inspector 和 Visual Studio Code 来连接 SSE 服务器。注意 stdio 和 SSE 之间有些差异。对于 SSE，你需要先单独启动服务器，然后再运行 Inspector 工具。Inspector 工具也有所不同，需要指定服务器的 URL。

## 示例

- [Java 计算器](../samples/java/calculator/README.md)
- [.Net 计算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 计算器](../samples/javascript/README.md)
- [TypeScript 计算器](../samples/typescript/README.md)
- [Python 计算器](../../../../03-GettingStarted/samples/python) 

## 额外资源

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 接下来

- 下一课：[使用 MCP 的 HTTP 流（可流式 HTTP）](../06-http-streaming/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。