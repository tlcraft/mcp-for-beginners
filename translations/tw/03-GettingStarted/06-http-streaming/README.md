<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:44:01+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "tw"
}
-->
# HTTPS 串流與 Model Context Protocol (MCP)

本章節提供使用 HTTPS 實作安全、可擴展且即時串流的完整指南，透過 Model Context Protocol (MCP) 進行。內容涵蓋串流的動機、可用的傳輸機制、如何在 MCP 中實作可串流的 HTTP、安全最佳實踐、從 SSE 遷移的指引，以及建構自有串流 MCP 應用的實務建議。

## MCP 中的傳輸機制與串流

本節探討 MCP 中可用的不同傳輸機制，以及它們如何促成客戶端與伺服器之間即時通訊的串流功能。

### 什麼是傳輸機制？

傳輸機制定義了客戶端與伺服器之間資料交換的方式。MCP 支援多種傳輸類型，以符合不同環境與需求：

- **stdio**：標準輸入/輸出，適用於本地和命令列工具。簡單但不適合網頁或雲端。
- **SSE (Server-Sent Events)**：允許伺服器透過 HTTP 向客戶端推送即時更新。適合網頁 UI，但在擴展性與彈性上有限。
- **Streamable HTTP**：現代基於 HTTP 的串流傳輸，支援通知與更佳擴展性。建議用於大多數生產與雲端場景。

### 比較表

請參考下表，了解這些傳輸機制的差異：

| 傳輸機制          | 即時更新       | 串流       | 擴展性      | 使用案例                 |
|-------------------|----------------|------------|-------------|--------------------------|
| stdio             | 否             | 否         | 低          | 本地命令列工具           |
| SSE               | 是             | 是         | 中          | 網頁、即時更新           |
| Streamable HTTP    | 是             | 是         | 高          | 雲端、多客戶端           |

> **提示：** 選擇合適的傳輸機制會影響效能、擴展性與使用者體驗。**Streamable HTTP** 是現代、可擴展且適合雲端應用的推薦選擇。

請注意前面章節提到的 stdio 與 SSE 傳輸機制，以及本章介紹的 Streamable HTTP 傳輸。

## 串流：概念與動機

理解串流的基本概念與動機，對實作有效的即時通訊系統至關重要。

**串流** 是網路程式設計中的一種技術，允許資料以小且可管理的區塊或事件序列方式傳送與接收，而非等待整個回應完成後一次送達。這對以下情境特別有用：

- 大型檔案或資料集
- 即時更新（例如聊天、進度條）
- 長時間運算，想持續向使用者回報狀態

以下是串流的高階重點：

- 資料逐步送達，而非一次完成
- 客戶端可即時處理收到的資料
- 降低感知延遲，提升使用者體驗

### 為什麼使用串流？

使用串流的理由包括：

- 使用者能立即獲得回饋，而非等待結束
- 支援即時應用與互動式 UI
- 更有效率地利用網路與計算資源

### 簡單範例：HTTP 串流伺服器與客戶端

以下為串流實作的簡單範例：

<details>
<summary>Python</summary>

**伺服器 (Python，使用 FastAPI 與 StreamingResponse)：**
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

**客戶端 (Python，使用 requests)：**
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

此範例展示伺服器隨著訊息產生即刻傳送給客戶端，而非等待所有訊息準備完畢。

**運作方式：**
- 伺服器隨訊息產生即逐一 yield。
- 客戶端接收並即時印出每個區塊。

**需求：**
- 伺服器必須使用串流回應（例如 `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`）。

</details>

<details>
<summary>Java</summary>

**伺服器 (Java，使用 Spring Boot 與 Server-Sent Events)：**

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

**客戶端 (Java，使用 Spring WebFlux WebClient)：**

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

**Java 實作說明：**
- 使用 Spring Boot 的反應式堆疊搭配 `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`，相較於 MCP 的串流選擇。

- **簡單串流需求：** 傳統 HTTP 串流較易實作，適合基本串流需求。

- **複雜互動應用：** MCP 串流提供更結構化的方式，包含豐富的元資料，並分離通知與最終結果。

- **AI 應用：** MCP 的通知系統對長時間運算任務特別有用，能持續向使用者報告進度。

## MCP 中的串流

到目前為止，你已看過經典串流與 MCP 串流的推薦與比較。接下來將深入說明如何在 MCP 中運用串流。

理解 MCP 框架中串流的運作方式，對建構能在長時間作業中向使用者即時回饋的互動式應用至關重要。

在 MCP 中，串流不是將主要回應拆成多個區塊送出，而是在工具處理請求時向客戶端發送**通知**。這些通知可包含進度更新、日誌或其他事件。

### 運作原理

主要結果仍以單一回應送出，但在處理過程中可透過獨立訊息傳送通知，即時更新客戶端。客戶端必須能處理並顯示這些通知。

## 什麼是通知？

我們提到「通知」，在 MCP 中這是什麼意思？

通知是伺服器發送給客戶端的訊息，用於告知長時間作業的進度、狀態或其他事件。通知能提升透明度與使用者體驗。

例如，客戶端應在完成與伺服器初步握手後發送一則通知。

通知的 JSON 格式範例如下：

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

通知屬於 MCP 中名為 ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) 的主題。

要啟用日誌功能，伺服器需將其設定為功能/能力，如下：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 根據使用的 SDK，日誌功能可能預設啟用，或需在伺服器設定中明確開啟。

通知類型有多種：

| 等級       | 說明                         | 範例使用情境               |
|------------|------------------------------|----------------------------|
| debug      | 詳細除錯資訊                 | 函式進入/退出點           |
| info       | 一般資訊訊息                 | 操作進度更新               |
| notice     | 正常但重要事件               | 配置變更                   |
| warning    | 警告狀況                   | 使用已棄用功能             |
| error      | 錯誤狀況                   | 操作失敗                   |
| critical   | 臨界狀況                   | 系統元件故障               |
| alert      | 需立即採取行動             | 偵測到資料損毀             |
| emergency  | 系統不可用                 | 完整系統故障               |

## 在 MCP 中實作通知

要在 MCP 中實作通知，需同時設定伺服器與客戶端，處理即時更新。這讓應用能在長時間作業中即時回饋使用者。

### 伺服器端：發送通知

從伺服器端開始。在 MCP 中，你定義的工具能在處理請求時發送通知。伺服器使用上下文物件（通常是 `ctx`）向客戶端發送訊息。

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

前例中，`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` 傳輸：

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

此 .NET 範例中，`ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` 用於發送資訊訊息。

要在 .NET MCP 伺服器啟用通知，請確保使用串流傳輸：

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### 客戶端：接收通知

客戶端必須實作訊息處理器，處理並顯示接收到的通知。

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

上述程式碼中，`message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` 負責處理進來的通知。

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

此 .NET 範例中，`MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`，客戶端實作訊息處理器來處理通知。

## 進度通知與應用場景

本節說明 MCP 中進度通知的概念、重要性，以及如何使用 Streamable HTTP 實作。並附有實作練習以加深理解。

進度通知是在長時間作業中，伺服器向客戶端即時傳送的訊息。伺服器不必等待整個過程完成，而是持續更新當前狀態。這提升透明度、使用者體驗，並利於除錯。

**範例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 為何使用進度通知？

進度通知重要原因：

- **提升使用者體驗：** 使用者可隨作業進展看到更新，而非僅在結束時。
- **即時回饋：** 客戶端能顯示進度條或日誌，讓應用更有回應感。
- **便於除錯與監控：** 開發者與使用者能看到流程中可能的瓶頸或卡住點。

### 如何實作進度通知

以下為 MCP 中實作進度通知的方式：

- **伺服器端：** 使用 `ctx.info()` or `ctx.log()` 在每個項目處理時發送通知。這會在主結果準備好前先發送訊息給客戶端。
- **客戶端：** 實作訊息處理器，監聽並顯示接收到的通知。此處理器能區分通知與最終結果。

**伺服器範例：**

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

**客戶端範例：**

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

## 安全性考量

在使用基於 HTTP 的傳輸實作 MCP 伺服器時，安全性是不可忽視的重點，需注意多種攻擊向量並採取防護措施。

### 概述

對外暴露 MCP 伺服器時，安全性至關重要。Streamable HTTP 帶來新的攻擊面，需要謹慎配置。

### 重點事項
- **Origin 標頭驗證**：務必驗證 `Origin` 以防跨站請求。
- **TLS 加密**：強制使用 HTTPS 保護資料傳輸。
- **身分驗證與授權**：確保只有授權用戶可存取。
- **輸入驗證**：防止注入與其他攻擊。
- **限制連線數與頻率**：避免拒絕服務攻擊。

### 維持相容性

建議在遷移過程中保持對現有 SSE 客戶端的相容性。可採用以下策略：

- 同時支援 SSE 與 Streamable HTTP，透過不同端點運行。
- 逐步將客戶端遷移至新傳輸。

### 遷移挑戰

遷移時需注意：

- 確保所有客戶端更新
- 處理通知傳遞差異

### 作業：建立你自己的串流 MCP 應用

**情境：**  
建置一個 MCP 伺服器與客戶端，伺服器處理一串項目（例如檔案或文件），並在處理每個項目時發送通知。客戶端應即時顯示收到的通知。

**步驟：**

1. 實作一個伺服器工具，處理清單並對每個項目發送通知。
2. 實作一個客戶端，帶有訊息處理器，即時顯示通知。
3. 執行伺服器與客戶端，觀察通知的運作。

[解答](./solution/README.md)

## 延伸閱讀與後續建議

欲繼續探索 MCP 串流並擴展知識，本節提供額外資源與建議的後續步驟，協助打造更進階的應用。

### 延伸閱讀

- [Microsoft：HTTP 串流入門](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft：Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft：ASP.NET Core 中的 CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests：串流請求](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 接下來？

- 嘗試建置使用串流的更進階 MCP 工具，應用於即時分析、聊天或協同編輯。
- 探索將 MCP 串流整合至前端框架（如 React、Vue 等），實現即時 UI 更新。
- 下一步：[利用 VSCode 的 AI 工具組](../07-aitk/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤譯承擔責任。