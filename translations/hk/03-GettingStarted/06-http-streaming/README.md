<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:42:38+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hk"
}
-->
# HTTPS 串流與 Model Context Protocol (MCP)

本章詳盡介紹如何使用 HTTPS 透過 Model Context Protocol (MCP) 實現安全、可擴展及即時的串流功能。內容涵蓋串流的動機、可用的傳輸機制、如何在 MCP 中實作可串流的 HTTP、最佳安全實踐、從 SSE 遷移的方法，以及打造自家串流 MCP 應用的實務指引。

## MCP 的傳輸機制與串流

本節探討 MCP 中可用的不同傳輸機制，以及它們如何促進客戶端與伺服器間即時通訊的串流能力。

### 什麼是傳輸機制？

傳輸機制定義了客戶端與伺服器之間資料交換的方式。MCP 支援多種傳輸類型，以配合不同環境和需求：

- **stdio**：標準輸入/輸出，適合本地及 CLI 工具。簡單但不適合網頁或雲端環境。
- **SSE (Server-Sent Events)**：讓伺服器透過 HTTP 推送即時更新給客戶端。適合網頁 UI，但在擴展性與彈性上有限。
- **Streamable HTTP**：現代基於 HTTP 的串流傳輸，支援通知與更佳的擴展性。建議用於大多數生產及雲端場景。

### 比較表

請參閱下表了解這些傳輸機制的差異：

| 傳輸機制         | 即時更新         | 串流         | 擴展性       | 使用案例                |
|-----------------|-----------------|------------|------------|-------------------------|
| stdio           | 否              | 否         | 低         | 本地 CLI 工具           |
| SSE             | 是              | 是         | 中         | 網頁，即時更新          |
| Streamable HTTP | 是              | 是         | 高         | 雲端，多用戶            |

> **提示：** 選擇合適的傳輸機制會影響效能、擴展性及用戶體驗。**Streamable HTTP** 是現代、可擴展及雲端就緒應用的推薦選擇。

請留意前幾章介紹的 stdio 和 SSE 傳輸，以及本章涵蓋的 Streamable HTTP 傳輸。

## 串流：概念與動機

理解串流的基本概念和動機，對實作有效的即時通訊系統至關重要。

**串流** 是網路程式設計中的一種技術，允許資料分批或以事件序列方式傳送和接收，而不必等整個回應完成。特別適合：

- 大型檔案或資料集。
- 即時更新（例如聊天、進度條）。
- 長時間運算，想持續向使用者回報進度。

串流的核心重點：

- 資料逐步傳送，而非一次送完。
- 客戶端可即時處理接收到的資料。
- 降低感知延遲，提升使用者體驗。

### 為什麼要用串流？

使用串流的原因包括：

- 使用者能即時獲得反饋，而非等到結束才知道結果。
- 支援即時應用和回應式 UI。
- 更有效率地使用網路和計算資源。

### 簡單範例：HTTP 串流伺服器與客戶端

以下是一個串流實作的簡單範例：

<details>
<summary>Python</summary>

**伺服器（Python，使用 FastAPI 與 StreamingResponse）：**
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

**客戶端（Python，使用 requests）：**
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

此範例示範伺服器在訊息陸續準備好時就發送給客戶端，而非等待所有訊息完成後一次送出。

**運作原理：**
- 伺服器在訊息準備好時就逐一產生。
- 客戶端接收並即時印出每個資料區塊。

**需求：**
- 伺服器必須使用串流回應（例如 `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`）。

</details>

<details>
<summary>Java</summary>

**伺服器（Java，使用 Spring Boot 與 Server-Sent Events）：**

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

**客戶端（Java，使用 Spring WebFlux WebClient）：**

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
- 使用 Spring Boot 的反應式架構，搭配 `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`，相較於選擇 MCP 的串流。

- **簡單串流需求：** 傳統 HTTP 串流較易實作，適合基礎串流需求。

- **複雜互動應用：** MCP 串流提供結構化的方式，帶有豐富的元資料，並區分通知與最終結果。

- **AI 應用：** MCP 的通知系統特別適合長時間運算的 AI 任務，能持續通知使用者進度。

## MCP 中的串流

至此你已看到經典串流與 MCP 串流的推薦與比較，接下來深入探討如何在 MCP 中善用串流。

理解 MCP 框架內串流的運作，對於打造能即時回饋使用者的響應式應用非常重要，特別是在長時間執行的操作中。

在 MCP 中，串流並非把主要回應分塊傳送，而是透過在工具處理請求時發送 **通知** 給客戶端。這些通知可包含進度更新、日誌或其他事件。

### 運作方式

主要結果仍以單一回應送出，但在處理過程中可以分別發送通知訊息，即時更新客戶端。客戶端必須能處理並顯示這些通知。

## 什麼是通知？

剛提到「通知」，在 MCP 中指的是什麼？

通知是伺服器發送給客戶端的訊息，用以告知長時間操作的進度、狀態或其他事件。通知提升透明度與使用者體驗。

例如，客戶端應在與伺服器完成初始握手後發送通知。

通知以 JSON 訊息形式呈現：

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

要啟用日誌功能，伺服器需將其作為功能/能力啟用，如下：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 根據所使用的 SDK，日誌功能可能預設啟用，或需在伺服器設定中明確啟用。

通知類型有多種：

| 等級       | 描述                          | 範例使用情境                 |
|-----------|------------------------------|------------------------------|
| debug     | 詳細除錯資訊                  | 函式進入/退出點              |
| info      | 一般資訊訊息                  | 操作進度更新                |
| notice    | 正常但重要事件                | 設定變更                    |
| warning   | 警告狀況                    | 使用已棄用功能              |
| error     | 錯誤狀況                    | 操作失敗                    |
| critical  | 關鍵狀況                    | 系統元件故障                |
| alert     | 必須立即採取行動            | 偵測到資料損壞              |
| emergency | 系統無法使用                | 完整系統故障                |

## 在 MCP 中實作通知

要在 MCP 中實作通知，需要同時設置伺服器與客戶端，處理即時更新。這讓應用程式能在長時間操作時，立即向使用者回饋資訊。

### 伺服器端：發送通知

先從伺服器端開始。在 MCP 中，你定義的工具可在處理請求時發送通知。伺服器使用上下文物件（通常為 `ctx`）向客戶端發送訊息。

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

上述範例中，`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

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

此 .NET 範例中，`ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` 方法用於發送資訊訊息。

若要在 .NET MCP 伺服器啟用通知，請確保使用串流傳輸：

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`，客戶端實作訊息處理器以處理通知。

## 進度通知與使用情境

本節說明 MCP 中進度通知的概念、重要性，以及如何利用 Streamable HTTP 實作。並附上實務練習加深理解。

進度通知是在長時間操作中，伺服器即時發送給客戶端的訊息。伺服器不需等整個流程完成，而是持續回報當前狀態。這提升透明度、用戶體驗，並方便除錯。

**範例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 為什麼要用進度通知？

進度通知重要原因：

- **提升使用者體驗：** 使用者看到操作進展，而非僅在結束時才有反應。
- **即時回饋：** 客戶端可顯示進度條或日誌，讓應用更有回應感。
- **方便除錯與監控：** 開發者與使用者能掌握流程瓶頸或卡住的位置。

### 如何實作進度通知

實作進度通知的方法：

- **伺服器端：** 使用 `ctx.info()` or `ctx.log()` 於每處理一項時發送通知。這會在主要結果準備好前發送訊息給客戶端。
- **客戶端：** 實作訊息處理器，監聽並顯示通知。此處理器能區分通知與最終結果。

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

## 安全考量

使用基於 HTTP 的傳輸實作 MCP 伺服器時，安全性是重中之重，需仔細防範多種攻擊向量並採取保護措施。

### 概述

公開 MCP 伺服器於 HTTP 時，安全性至關重要。Streamable HTTP 帶來新的攻擊面，需謹慎設定。

### 重要要點
- **Origin 標頭驗證**：務必驗證 `Origin`，確保來源可信。
- **使用 HTTPS**：避免中間人攻擊，確保傳輸加密。
- **授權與認證**：確保只有授權用戶可存取。
- **限制請求頻率**：防止拒絕服務攻擊。
- **隔離與沙箱**：限制工具執行環境，防止濫用。

### 維持相容性

遷移過程中建議保持與現有 SSE 客戶端的相容性，策略包括：

- 同時支援 SSE 與 Streamable HTTP，分別在不同端點運行。
- 逐步將客戶端遷移至新傳輸機制。

### 遷移挑戰

遷移時需克服的挑戰：

- 確保所有客戶端皆已更新。
- 處理通知傳遞差異。

### 練習：打造自己的串流 MCP 應用

**情境：**  
打造一個 MCP 伺服器與客戶端，伺服器處理一系列項目（例如檔案或文件），並在處理每個項目時發送通知。客戶端應即時顯示每個通知。

**步驟：**

1. 實作一個伺服器工具，處理清單並對每個項目發送通知。
2. 實作一個客戶端，包含訊息處理器，實時顯示通知。
3. 執行伺服器與客戶端測試，觀察通知效果。

[解答](./solution/README.md)

## 延伸閱讀與後續

欲繼續 MCP 串流的學習之旅並擴展知識，本節提供額外資源及建議的後續步驟，助你打造更進階的應用。

### 延伸閱讀

- [Microsoft: HTTP 串流入門](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core 中的 CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: 串流請求](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 接下來？

- 嘗試打造更進階的 MCP 工具，使用串流實現即時分析、聊天或協作編輯。
- 探索將 MCP 串流整合到前端框架（如 React、Vue 等），實現即時 UI 更新。
- 下一步：[利用 VSCode 的 AI 工具包](../07-aitk/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋負責。