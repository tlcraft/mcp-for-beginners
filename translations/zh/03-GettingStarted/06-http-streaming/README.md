<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:39:51+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "zh"
}
-->
# 使用 Model Context Protocol (MCP) 的 HTTPS 流式传输

本章全面介绍了如何使用 HTTPS 结合 Model Context Protocol (MCP) 实现安全、可扩展且实时的流式传输。内容涵盖了流式传输的动机、可用的传输机制、如何在 MCP 中实现可流式的 HTTP、安全最佳实践、从 SSE 的迁移以及构建流式 MCP 应用的实用指导。

## MCP 中的传输机制与流式传输

本节探讨 MCP 中可用的不同传输机制及其在实现客户端与服务器实时通信流式能力中的作用。

### 什么是传输机制？

传输机制定义了客户端和服务器之间数据交换的方式。MCP 支持多种传输类型，以适应不同环境和需求：

- **stdio**：标准输入/输出，适合本地和命令行工具。简单但不适合 Web 或云环境。
- **SSE（服务器发送事件）**：允许服务器通过 HTTP 向客户端推送实时更新。适合 Web UI，但在可扩展性和灵活性上有限。
- **可流式 HTTP**：基于现代 HTTP 的流式传输，支持通知和更好的可扩展性。推荐用于大多数生产和云场景。

### 比较表

请查看下表，了解这些传输机制的区别：

| 传输方式          | 实时更新        | 流式传输    | 可扩展性    | 使用场景                |
|-------------------|-----------------|-------------|-------------|-------------------------|
| stdio             | 否              | 否          | 低          | 本地命令行工具          |
| SSE               | 是              | 是          | 中          | Web，实时更新           |
| 可流式 HTTP       | 是              | 是          | 高          | 云环境，多客户端        |

> **提示：** 选择合适的传输方式会影响性能、可扩展性和用户体验。**可流式 HTTP** 推荐用于现代、可扩展且云就绪的应用。

请注意前几章中介绍的 stdio 和 SSE 传输方式，本章重点介绍的是可流式 HTTP 传输。

## 流式传输：概念与动机

理解流式传输的基本概念和动机，对于实现高效的实时通信系统至关重要。

**流式传输** 是网络编程中的一种技术，它允许数据分批或作为事件序列发送和接收，而不必等待整个响应准备完毕。该技术特别适用于：

- 大型文件或数据集
- 实时更新（例如聊天、进度条）
- 长时间运行的计算，需要持续向用户反馈

以下是流式传输的核心要点：

- 数据逐步传输，而非一次性全部发送
- 客户端可边接收边处理数据
- 降低感知延迟，提升用户体验

### 为什么要使用流式传输？

使用流式传输的原因包括：

- 用户能即时获得反馈，而非等待操作结束
- 支持实时应用和响应式 UI
- 更高效地利用网络和计算资源

### 简单示例：HTTP 流式传输服务器与客户端

下面是一个简单的流式传输实现示例：

<details>
<summary>Python</summary>

**服务器（Python，使用 FastAPI 和 StreamingResponse）：**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**客户端（Python，使用 requests）：**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

该示例展示了服务器如何在消息准备好时逐条发送给客户端，而不是等待所有消息准备完毕。

**工作原理：**
- 服务器在每条消息准备好时发送
- 客户端接收并打印每个数据块

**要求：**
- 服务器必须使用流式响应（如 `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`）

</details>

<details>
<summary>Java</summary>

**服务器（Java，使用 Spring Boot 和服务器发送事件 SSE）：**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**客户端（Java，使用 Spring WebFlux WebClient）：**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Java 实现说明：**
- 使用 Spring Boot 的响应式栈，结合 `Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`，与选择 MCP 流式传输进行对比。

- **简单流式需求：** 传统 HTTP 流式传输更易实现，适合基本流式需求。

- **复杂交互应用：** MCP 流式传输提供更结构化的方式，拥有丰富的元数据，区分通知和最终结果。

- **AI 应用：** MCP 的通知系统特别适合长时间运行的 AI 任务，方便持续向用户反馈进度。

## MCP 中的流式传输

到目前为止，你已经了解了经典流式传输和 MCP 流式传输的推荐与比较。接下来详细介绍如何在 MCP 中利用流式传输。

理解 MCP 框架中的流式传输机制，对于构建在长时间运行操作中向用户实时反馈的响应式应用至关重要。

在 MCP 中，流式传输并非将主响应分块发送，而是在工具处理请求时向客户端发送**通知**。这些通知可以包括进度更新、日志或其他事件。

### 工作原理

主结果仍作为单个响应发送。但在处理过程中，可以发送单独的通知消息，从而实时更新客户端。客户端必须能处理并显示这些通知。

## 什么是通知？

我们提到了“通知”，在 MCP 中这指的是什么？

通知是服务器向客户端发送的消息，用于告知长时间运行操作中的进度、状态或其他事件。通知提升了透明度和用户体验。

例如，客户端应在与服务器完成初始握手后发送一条通知。

通知的 JSON 消息示例如下：

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

通知属于 MCP 中称为["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) 的主题。

要启用日志功能，服务器需将其作为特性/能力开启，示例如下：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 根据所用 SDK，日志功能可能默认开启，或需在服务器配置中显式启用。

通知类型如下：

| 级别       | 描述                         | 示例用例                    |
|------------|------------------------------|-----------------------------|
| debug      | 详细调试信息                 | 函数入口/出口点             |
| info       | 一般信息消息                 | 操作进度更新               |
| notice     | 普通但重要事件               | 配置变更                   |
| warning    | 警告条件                     | 过时功能使用               |
| error      | 错误条件                     | 操作失败                   |
| critical   | 严重条件                     | 系统组件故障               |
| alert      | 必须立即采取行动             | 发现数据损坏               |
| emergency  | 系统不可用                   | 完全系统故障               |

## 在 MCP 中实现通知

要在 MCP 中实现通知，需要同时设置服务器端和客户端以处理实时更新，从而让应用在长时间运行操作中即时反馈给用户。

### 服务器端：发送通知

先从服务器端开始。在 MCP 中，你定义的工具可以在处理请求时发送通知。服务器使用上下文对象（通常是 `ctx`）向客户端发送消息。

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

在上例中，`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` 传输：

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

在该 .NET 示例中，使用了 `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` 方法发送信息消息。

确保你的 .NET MCP 服务器使用流式传输以启用通知：

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### 客户端：接收通知

客户端必须实现消息处理器，用于处理并显示接收到的通知。

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

上述代码中，`message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` 用于处理接收的通知。

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

该 .NET 示例中，`MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`，客户端实现了消息处理器来处理通知。

## 进度通知及应用场景

本节介绍 MCP 中进度通知的概念、重要性及如何使用可流式 HTTP 实现。还包含一个实操练习，帮助加深理解。

进度通知是在长时间运行操作中，服务器向客户端实时发送的消息。服务器无需等待整个过程完成，即可持续向客户端更新当前状态。这提升了透明度、用户体验，也方便调试。

**示例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 为什么使用进度通知？

进度通知的重要性体现在：

- **更佳用户体验：** 用户能看到操作进展，而非仅在结束时获得反馈。
- **实时反馈：** 客户端可显示进度条或日志，提升应用响应感。
- **更易调试和监控：** 开发者和用户能看到流程卡顿或延迟的位置。

### 如何实现进度通知

实现进度通知的方法：

- **服务器端：** 使用 `ctx.info()` or `ctx.log()` 在处理每个项目时发送通知。这些消息在主结果准备好之前发送给客户端。
- **客户端：** 实现消息处理器，监听并显示接收到的通知。该处理器能区分通知和最终结果。

**服务器示例：**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**客户端示例：**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## 安全考虑

在使用基于 HTTP 的传输实现 MCP 服务器时，安全问题至关重要，需要关注多种攻击向量和防护机制。

### 概述

公开 MCP 服务器时，安全性尤为关键。可流式 HTTP 引入了新的攻击面，需谨慎配置。

### 关键点
- **Origin 头验证**：始终验证 `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` 而非 SSE 客户端。
3. **在客户端实现消息处理器**，处理通知。
4. **测试与现有工具和工作流的兼容性**。

### 保持兼容性

迁移过程中建议保持与现有 SSE 客户端的兼容性。策略包括：

- 同时支持 SSE 和可流式 HTTP，在不同端点运行。
- 逐步迁移客户端到新传输。

### 挑战

迁移时需解决以下问题：

- 确保所有客户端都已更新
- 处理通知传递差异

### 练习：构建你自己的流式 MCP 应用

**场景：**
构建一个 MCP 服务器和客户端，服务器处理一组项目（如文件或文档），并在处理每个项目时发送通知。客户端应实时显示每条通知。

**步骤：**

1. 实现服务器工具，处理列表并为每个项目发送通知。
2. 实现客户端消息处理器，实时显示通知。
3. 运行服务器和客户端，测试并观察通知效果。

[解决方案](./solution/README.md)

## 拓展阅读与后续步骤

继续深入 MCP 流式传输的学习，本节提供额外资源和建议的下一步行动，助力构建更高级的应用。

### 拓展阅读

- [Microsoft: HTTP 流式传输简介](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: 服务器发送事件 (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core 中的 CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: 流式请求](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 后续步骤

- 尝试构建更高级的 MCP 工具，利用流式传输实现实时分析、聊天或协作编辑。
- 探索将 MCP 流式传输与前端框架（React、Vue 等）集成，实现实时 UI 更新。
- 下一章：[VSCode 的 AI 工具包使用](../07-aitk/README.md)

**免责声明**：  
本文件使用AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)进行翻译。虽然我们力求准确，但请注意自动翻译可能包含错误或不准确之处。原始语言的文件应被视为权威来源。对于重要信息，建议采用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。