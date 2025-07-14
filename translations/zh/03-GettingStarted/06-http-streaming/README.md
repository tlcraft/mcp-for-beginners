<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:27:54+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "zh"
}
-->
# 使用模型上下文协议（MCP）的 HTTPS 流式传输

本章全面介绍了如何使用 HTTPS 和模型上下文协议（MCP）实现安全、可扩展且实时的流式传输。内容涵盖了流式传输的动机、可用的传输机制、如何在 MCP 中实现可流式的 HTTP、安全最佳实践、从 SSE 迁移的指导，以及构建自己的流式 MCP 应用的实用建议。

## MCP 中的传输机制与流式传输

本节探讨 MCP 中可用的不同传输机制及其在实现客户端与服务器之间实时通信流式能力中的作用。

### 什么是传输机制？

传输机制定义了客户端和服务器之间数据交换的方式。MCP 支持多种传输类型，以适应不同环境和需求：

- **stdio**：标准输入/输出，适合本地和基于命令行的工具。简单但不适合 Web 或云环境。
- **SSE（服务器发送事件）**：允许服务器通过 HTTP 向客户端推送实时更新。适合 Web 界面，但在可扩展性和灵活性方面有限。
- **可流式 HTTP**：基于现代 HTTP 的流式传输，支持通知和更好的可扩展性。推荐用于大多数生产和云场景。

### 比较表

请看下面的比较表，了解这些传输机制的区别：

| 传输方式          | 实时更新       | 流式传输    | 可扩展性    | 使用场景                |
|-------------------|----------------|-------------|-------------|-------------------------|
| stdio             | 否             | 否          | 低          | 本地命令行工具          |
| SSE               | 是             | 是          | 中          | Web，实时更新           |
| 可流式 HTTP       | 是             | 是          | 高          | 云环境，多客户端         |

> **提示：** 选择合适的传输方式会影响性能、可扩展性和用户体验。**可流式 HTTP** 推荐用于现代、可扩展且云就绪的应用。

请注意，前几章中介绍过的 stdio 和 SSE 传输方式，而本章重点讲解的是可流式 HTTP 传输。

## 流式传输：概念与动机

理解流式传输的基本概念和动机对于实现高效的实时通信系统至关重要。

**流式传输** 是网络编程中的一种技术，允许数据以小块或事件序列的形式发送和接收，而不是等待整个响应准备好后一次性传输。这在以下场景中特别有用：

- 大文件或大型数据集。
- 实时更新（如聊天、进度条）。
- 长时间运行的计算，需持续向用户反馈。

流式传输的核心要点：

- 数据逐步传送，而非一次性全部发送。
- 客户端可以边接收边处理数据。
- 降低感知延迟，提升用户体验。

### 为什么使用流式传输？

使用流式传输的原因包括：

- 用户能立即获得反馈，而非等待结束。
- 支持实时应用和响应式界面。
- 更高效地利用网络和计算资源。

### 简单示例：HTTP 流式服务器与客户端

下面是一个简单的流式传输实现示例：

<details>
<summary>Python</summary>

**服务器端（Python，使用 FastAPI 和 StreamingResponse）：**
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

该示例演示服务器在消息准备好时逐条发送给客户端，而不是等待所有消息准备完毕后一次性发送。

**工作原理：**
- 服务器在每条消息准备好时逐条生成。
- 客户端接收并打印每个数据块。

**要求：**
- 服务器必须使用流式响应（如 FastAPI 中的 `StreamingResponse`）。
- 客户端必须以流式方式处理响应（requests 中设置 `stream=True`）。
- Content-Type 通常为 `text/event-stream` 或 `application/octet-stream`。

</details>

<details>
<summary>Java</summary>

**服务器端（Java，使用 Spring Boot 和服务器发送事件）：**

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
- 使用 Spring Boot 的响应式栈和 `Flux` 实现流式传输
- `ServerSentEvent` 提供带事件类型的结构化事件流
- `WebClient` 的 `bodyToFlux()` 支持响应式流式消费
- `delayElements()` 模拟事件间的处理时间
- 事件可带类型（如 `info`、`result`），便于客户端处理

</details>

### 比较：传统流式传输 vs MCP 流式传输

传统流式传输与 MCP 流式传输的区别如下表所示：

| 特性                   | 传统 HTTP 流式传输           | MCP 流式传输（通知机制）          |
|------------------------|-----------------------------|---------------------------------|
| 主响应                 | 分块传输                    | 单次响应，最后发送               |
| 进度更新               | 作为数据块发送              | 作为通知消息发送                 |
| 客户端要求             | 必须处理流式响应            | 必须实现消息处理器               |
| 使用场景               | 大文件，AI 令牌流           | 进度、日志、实时反馈             |

### 关键差异

此外，还有以下关键差异：

- **通信模式：**
   - 传统 HTTP 流式传输：使用简单的分块传输编码发送数据块
   - MCP 流式传输：使用基于 JSON-RPC 协议的结构化通知系统

- **消息格式：**
   - 传统 HTTP：纯文本块，带换行符
   - MCP：结构化的 LoggingMessageNotification 对象，带元数据

- **客户端实现：**
   - 传统 HTTP：简单客户端处理流式响应
   - MCP：更复杂的客户端，需实现消息处理器以处理不同类型消息

- **进度更新：**
   - 传统 HTTP：进度作为主响应流的一部分
   - MCP：进度通过单独的通知消息发送，主响应最后发送

### 建议

关于选择传统流式传输（如前面示例中的 `/stream` 端点）还是 MCP 流式传输，我们有以下建议：

- **简单流式需求：** 传统 HTTP 流式传输实现简单，适合基础流式需求。
- **复杂交互应用：** MCP 流式传输提供更结构化的方式，带有丰富元数据，区分通知和最终结果。
- **AI 应用场景：** MCP 的通知系统特别适合长时间运行的 AI 任务，能持续向用户反馈进度。

## MCP 中的流式传输

到目前为止，你已经了解了传统流式传输和 MCP 流式传输的区别和建议。接下来详细介绍如何在 MCP 中利用流式传输。

理解 MCP 框架内的流式传输机制，对于构建在长时间操作中向用户提供实时反馈的响应式应用至关重要。

在 MCP 中，流式传输不是将主响应分块发送，而是在工具处理请求时向客户端发送**通知**。这些通知可以包含进度更新、日志或其他事件。

### 工作原理

主结果仍作为单次响应发送。但在处理过程中，可以发送通知消息，实时更新客户端。客户端必须能够处理并展示这些通知。

## 什么是通知？

我们提到“通知”，在 MCP 中这是什么意思？

通知是服务器向客户端发送的消息，用于告知长时间操作中的进度、状态或其他事件。通知提升了透明度和用户体验。

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

通知属于 MCP 中称为 ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) 的主题。

要启用日志功能，服务器需要将其作为功能/能力开启，如下所示：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 根据所用 SDK，日志功能可能默认启用，或者需要在服务器配置中显式开启。

通知类型包括：

| 级别       | 描述                         | 示例用例                      |
|------------|------------------------------|------------------------------|
| debug      | 详细调试信息                 | 函数入口/出口点              |
| info       | 一般信息消息                 | 操作进度更新                |
| notice     | 正常但重要的事件             | 配置变更                    |
| warning    | 警告条件                    | 弃用功能使用                |
| error      | 错误条件                    | 操作失败                    |
| critical   | 严重条件                    | 系统组件故障                |
| alert      | 需立即采取行动              | 检测到数据损坏              |
| emergency  | 系统不可用                  | 完全系统故障                |

## 在 MCP 中实现通知

要在 MCP 中实现通知，需要同时设置服务器端和客户端以处理实时更新。这使应用能在长时间操作中即时向用户反馈。

### 服务器端：发送通知

先看服务器端。在 MCP 中，你定义的工具可以在处理请求时发送通知。服务器使用上下文对象（通常是 `ctx`）向客户端发送消息。

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

在上述示例中，`process_files` 工具在处理每个文件时向客户端发送了三条通知。`ctx.info()` 方法用于发送信息类消息。

</details>

此外，为启用通知，确保服务器使用流式传输（如 `streamable-http`），客户端实现消息处理器以处理通知。以下是服务器使用 `streamable-http` 传输的配置示例：

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

在此 .NET 示例中，`ProcessFiles` 工具通过 `Tool` 属性标记，在处理每个文件时向客户端发送三条通知。`ctx.Info()` 方法用于发送信息类消息。

要在 .NET MCP 服务器中启用通知，请确保使用流式传输：

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### 客户端：接收通知

客户端必须实现消息处理器，处理并展示接收到的通知。

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

上述代码中，`message_handler` 函数检查传入消息是否为通知。如果是，则打印通知；否则作为普通服务器消息处理。注意 `ClientSession` 初始化时传入了 `message_handler`，用于处理接收的通知。

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

此 .NET 示例中，`MessageHandler` 函数检查传入消息是否为通知。若是，则打印通知；否则作为普通服务器消息处理。`ClientSession` 通过 `ClientSessionOptions` 初始化时传入消息处理器。

</details>

要启用通知，确保服务器使用流式传输（如 `streamable-http`），客户端实现消息处理器以处理通知。

## 进度通知与应用场景

本节介绍 MCP 中的进度通知概念、重要性及如何使用可流式 HTTP 实现。还包含一个实用练习，帮助巩固理解。

进度通知是服务器在长时间操作中向客户端发送的实时消息。服务器无需等待整个过程完成，而是持续更新当前状态。这提升了透明度、用户体验，并便于调试。

**示例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 为什么使用进度通知？

进度通知的重要性体现在：

- **更佳用户体验：** 用户能看到工作进展，而非仅在结束时获得反馈。
- **实时反馈：** 客户端可显示进度条或日志，使应用更具响应性。
- **便于调试和监控：** 开发者和用户能看到流程中可能的瓶颈或卡顿。

### 如何实现进度通知

实现进度通知的方法：

- **服务器端：** 使用 `ctx.info()` 或 `ctx.log()` 在处理每个项目时发送通知。这样在主结果准备好之前，客户端就能收到消息。
- **客户端：** 实现消息处理器，监听并展示接收到的通知。该处理器区分通知和最终结果。

**服务器示例：**

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

## 安全注意事项

在使用基于 HTTP 的传输实现 MCP 服务器时，安全性成为首要关注点，需要仔细防范多种攻击向量并采取相应的保护措施。

### 概述

当通过 HTTP 暴露 MCP 服务器时，安全性至关重要。Streamable HTTP 引入了新的攻击面，需要谨慎配置。

### 关键点
- **Origin 头验证**：始终验证 `Origin` 头以防止 DNS 重新绑定攻击。
- **绑定到 localhost**：本地开发时，将服务器绑定到 `localhost`，避免暴露到公共网络。
- **身份验证**：生产环境部署时，实施身份验证（如 API 密钥、OAuth）。
- **CORS**：配置跨域资源共享（CORS）策略以限制访问。
- **HTTPS**：生产环境使用 HTTPS 加密通信。

### 最佳实践
- 不要轻信未经验证的请求。
- 记录并监控所有访问和错误。
- 定期更新依赖以修补安全漏洞。

### 挑战
- 在安全性和开发便利性之间取得平衡
- 确保与各种客户端环境的兼容性


## 从 SSE 升级到 Streamable HTTP

对于当前使用 Server-Sent Events (SSE) 的应用，迁移到 Streamable HTTP 可以为 MCP 实现带来更强的功能和更好的长期可维护性。

### 为什么要升级？

升级从 SSE 到 Streamable HTTP 有两个主要原因：

- Streamable HTTP 提供比 SSE 更好的可扩展性、兼容性和更丰富的通知支持。
- 它是新 MCP 应用推荐使用的传输方式。

### 迁移步骤

以下是在 MCP 应用中从 SSE 迁移到 Streamable HTTP 的方法：

- **更新服务器代码**，在 `mcp.run()` 中使用 `transport="streamable-http"`。
- **更新客户端代码**，使用 `streamablehttp_client` 替代 SSE 客户端。
- **在客户端实现消息处理器**，用于处理通知。
- **测试与现有工具和工作流的兼容性**。

### 兼容性维护

建议在迁移过程中保持对现有 SSE 客户端的兼容性。以下是一些策略：

- 可以通过在不同端点同时运行 SSE 和 Streamable HTTP 两种传输方式来支持两者。
- 逐步将客户端迁移到新传输方式。

### 挑战

迁移过程中需要解决以下问题：

- 确保所有客户端都完成更新
- 处理通知传递方式的差异

## 安全注意事项

在实现任何服务器时，尤其是使用基于 HTTP 的传输（如 MCP 中的 Streamable HTTP）时，安全应放在首位。

在使用基于 HTTP 的传输实现 MCP 服务器时，安全性成为首要关注点，需要仔细防范多种攻击向量并采取相应的保护措施。

### 概述

当通过 HTTP 暴露 MCP 服务器时，安全性至关重要。Streamable HTTP 引入了新的攻击面，需要谨慎配置。

以下是一些关键的安全注意事项：

- **Origin 头验证**：始终验证 `Origin` 头以防止 DNS 重新绑定攻击。
- **绑定到 localhost**：本地开发时，将服务器绑定到 `localhost`，避免暴露到公共网络。
- **身份验证**：生产环境部署时，实施身份验证（如 API 密钥、OAuth）。
- **CORS**：配置跨域资源共享（CORS）策略以限制访问。
- **HTTPS**：生产环境使用 HTTPS 加密通信。

### 最佳实践

此外，实现 MCP 流式服务器时，建议遵循以下安全最佳实践：

- 不要轻信未经验证的请求。
- 记录并监控所有访问和错误。
- 定期更新依赖以修补安全漏洞。

### 挑战

在实现 MCP 流式服务器安全时，您将面临以下挑战：

- 在安全性和开发便利性之间取得平衡
- 确保与各种客户端环境的兼容性

### 任务：构建你自己的流式 MCP 应用

**场景：**  
构建一个 MCP 服务器和客户端，服务器处理一系列项目（如文件或文档），并为每个处理的项目发送通知。客户端应实时显示每条通知。

**步骤：**

1. 实现一个服务器工具，处理列表中的项目并发送通知。
2. 实现一个客户端，带有消息处理器以实时显示通知。
3. 运行服务器和客户端进行测试，观察通知效果。

[Solution](./solution/README.md)

## 进一步阅读与后续步骤

为了继续深入 MCP 流式传输的学习并扩展知识，本节提供了额外资源和建议的后续行动，帮助你构建更高级的应用。

### 进一步阅读

- [Microsoft: HTTP 流式传输简介](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core 中的 CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: 流式请求](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 后续步骤

- 尝试构建更高级的 MCP 工具，利用流式传输实现实时分析、聊天或协作编辑。
- 探索将 MCP 流式传输与前端框架（React、Vue 等）集成，实现实时 UI 更新。
- 下一步：[利用 VSCode 的 AI 工具包](../07-aitk/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。