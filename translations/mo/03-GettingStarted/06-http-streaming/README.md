<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:41:03+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "mo"
}
-->
# HTTPS 串流與 Model Context Protocol (MCP)

本章將全面介紹如何使用 HTTPS 與 Model Context Protocol (MCP) 實現安全、可擴展且即時的串流功能。內容涵蓋串流的動機、可用的傳輸機制、如何在 MCP 中實作可串流的 HTTP、資安最佳實踐、從 SSE 的遷移，以及建置串流 MCP 應用的實務指引。

## MCP 的傳輸機制與串流

本節探討 MCP 中可用的不同傳輸機制，以及它們在實現客戶端與伺服器之間即時通訊串流功能上的角色。

### 什麼是傳輸機制？

傳輸機制定義了客戶端與伺服器之間資料交換的方式。MCP 支援多種傳輸類型，以適應不同的環境與需求：

- **stdio**：標準輸入/輸出，適合本地和 CLI 工具。簡單，但不適合網頁或雲端環境。
- **SSE (Server-Sent Events)**：允許伺服器透過 HTTP 向客戶端推送即時更新。適合網頁介面，但擴展性與彈性有限。
- **Streamable HTTP**：現代 HTTP 串流傳輸，支援通知與更佳的擴展性。推薦用於大多數生產與雲端場景。

### 比較表

請參考下表以了解這些傳輸機制的差異：

| 傳輸方式          | 即時更新         | 串流        | 擴展性       | 適用場景               |
|-------------------|------------------|-------------|--------------|------------------------|
| stdio             | 否               | 否          | 低           | 本地 CLI 工具           |
| SSE               | 是               | 是          | 中           | 網頁、即時更新          |
| Streamable HTTP   | 是               | 是          | 高           | 雲端、多客戶端          |

> **提示：** 選擇合適的傳輸機制會影響效能、擴展性與使用者體驗。**Streamable HTTP** 是現代、可擴展且雲端友好應用的推薦方案。

請注意，前幾章介紹過的 stdio 與 SSE 傳輸方式，而本章重點介紹的則是 Streamable HTTP。

## 串流：概念與動機

理解串流的基本概念與動機，對於實作有效的即時通訊系統至關重要。

**串流** 是網路程式設計中的一種技術，允許資料以小而可控的區塊或事件序列方式傳送與接收，而非等待整個回應準備完成後一次傳送。此技術特別適用於：

- 大型檔案或資料集。
- 即時更新（例如聊天、進度條）。
- 長時間運算，並希望持續通知使用者。

以下是串流的高階重點：

- 資料逐步送達，而非一次全部傳送。
- 客戶端可隨資料到達即時處理。
- 降低感知延遲，提升使用者體驗。

### 為什麼要使用串流？

使用串流的原因包括：

- 使用者能立即獲得回饋，而非僅在結束時。
- 支援即時應用與反應式介面。
- 更有效率地使用網路與運算資源。

### 簡單範例：HTTP 串流伺服器與客戶端

以下是一個簡單示範串流如何實作：

<details>
<summary>Python</summary>

**伺服器端 (Python，使用 FastAPI 與 StreamingResponse)：**
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

此範例示範伺服器隨著訊息可用即時傳送給客戶端，而非等待所有訊息準備完成。

**運作方式：**
- 伺服器在每則訊息準備好時即送出。
- 客戶端收到資料塊即時印出。

**需求：**
- 伺服器必須使用串流回應（例如 `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`）。

</details>

<details>
<summary>Java</summary>

**伺服器端 (Java，使用 Spring Boot 與 Server-Sent Events)：**

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) 與 MCP 串流的選擇。

- **簡單串流需求時：** 傳統 HTTP 串流較易實作且足夠。

- **複雜互動應用時：** MCP 串流提供更結構化的方式，包含豐富的元資料及通知與最終結果的分離。

- **AI 應用時：** MCP 的通知系統特別適合長時間運算的 AI 任務，方便持續通知使用者進度。

## MCP 中的串流

到目前為止，你已看到經典串流與 MCP 串流的建議與比較。接下來深入說明如何在 MCP 中利用串流。

理解 MCP 框架內串流的運作方式，對於建構能在長時間運作中向使用者提供即時回饋的應用至關重要。

在 MCP 中，串流不是將主要回應拆成多塊傳送，而是在工具處理請求時向客戶端傳送**通知**。這些通知可包含進度更新、日誌或其他事件。

### 運作原理

主要結果仍會以單一回應送出。但通知可在處理過程中以獨立訊息發送，從而即時更新客戶端。客戶端必須能夠處理並顯示這些通知。

## 什麼是通知？

我們提到「通知」，在 MCP 中指的是什麼？

通知是伺服器在長時間運作中，向客戶端傳送的訊息，用於告知進度、狀態或其他事件。通知提升透明度與使用者體驗。

例如，客戶端在與伺服器完成初始握手後，會收到一則通知。

通知的 JSON 範例如下：

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

通知屬於 MCP 中稱為 ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) 的主題。

要啟用日誌功能，伺服器需將其設為功能/能力，如下：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 根據使用的 SDK，不同情況下日誌可能預設啟用，或需在伺服器設定中明確開啟。

通知類型包括：

| 等級       | 說明                         | 範例使用情境                  |
|------------|------------------------------|------------------------------|
| debug      | 詳細除錯資訊                 | 函式進入/離開點              |
| info       | 一般資訊訊息                 | 作業進度更新                 |
| notice     | 正常但重要事件               | 設定變更                     |
| warning    | 警告狀況                     | 廢棄功能使用                 |
| error      | 錯誤狀況                     | 作業失敗                     |
| critical   | 關鍵狀況                     | 系統元件故障                 |
| alert      | 必須立即採取行動             | 偵測到資料損壞               |
| emergency  | 系統不可用                   | 完全系統故障                 |

## 在 MCP 中實作通知

要在 MCP 中實作通知，需要設定伺服器與客戶端雙方以處理即時更新。這讓應用在長時間作業中能即時回饋使用者。

### 伺服器端：發送通知

從伺服器端開始。在 MCP 中，你定義的工具可在處理請求時發送通知。伺服器使用上下文物件（通常為 `ctx`）向客戶端傳送訊息。

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

客戶端必須實作訊息處理器，來處理並顯示收到的通知。

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

上述程式中，`message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` 用於處理接收到的通知。

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

## 進度通知與應用場景

本節說明 MCP 中進度通知的概念、重要性，以及如何使用 Streamable HTTP 實作。並提供實作練習以加深理解。

進度通知是伺服器在長時間作業中向客戶端發送的即時訊息。伺服器不必等待整個作業完成，而是持續回報目前狀態。這提升透明度、使用者體驗，並方便除錯。

**範例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 為何使用進度通知？

進度通知的重要原因包括：

- **提升使用者體驗：** 使用者能即時看到作業進度，而非僅在結束時。
- **即時回饋：** 客戶端可顯示進度條或日誌，讓應用感覺更靈敏。
- **便於除錯與監控：** 開發者與使用者可即時掌握作業瓶頸或停滯點。

### 如何實作進度通知

以下是在 MCP 中實作進度通知的方法：

- **伺服器端：** 使用 `ctx.info()` or `ctx.log()` 於處理每個項目時發送通知，在主結果準備好前先傳送訊息給客戶端。
- **客戶端：** 實作訊息處理器，監聽並顯示到達的通知。此處理器能區分通知與最終結果。

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

當使用 HTTP 傳輸實作 MCP 伺服器時，安全性是極為重要的議題，需要仔細防範多種攻擊向量並採取保護機制。

### 概述

當 MCP 伺服器透過 HTTP 對外提供服務時，安全性至關重要。Streamable HTTP 可能帶來新的攻擊面，需謹慎配置。

### 重要事項
- **Origin 標頭驗證**：務必驗證 `Origin` 以防止跨站請求偽造 (CSRF)。
- **使用 HTTPS**：確保資料傳輸加密，避免竊聽與中間人攻擊。
- **驗證與授權**：限制存取權限，確保只有授權用戶能使用串流服務。
- **防範資源耗盡攻擊**：避免惡意用戶透過串流耗盡系統資源。

### 維持相容性

在遷移過程中，建議保持與現有 SSE 客戶端的相容性。策略包括：

- 同時支援 SSE 與 Streamable HTTP，分別於不同端點運行。
- 逐步將客戶端遷移至新傳輸。

### 遷移挑戰

遷移時需注意：

- 確保所有客戶端都已更新。
- 處理通知傳遞差異。

### 練習：打造自己的串流 MCP 應用

**情境：**  
建置一個 MCP 伺服器與客戶端，伺服器處理一串項目（例如檔案或文件），並於處理每個項目時發送通知。客戶端則即時顯示收到的通知。

**步驟：**

1. 實作伺服器工具，處理清單並為每個項目發送通知。
2. 實作客戶端訊息處理器，實時顯示通知。
3. 執行並測試伺服器與客戶端，觀察通知效果。

[解答](./solution/README.md)

## 延伸閱讀與後續建議

為持續深入 MCP 串流領域並擴展知識，本節提供額外資源與後續建議，助你打造更進階的應用。

### 延伸閱讀

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 後續建議

- 嘗試打造更進階的 MCP 工具，使用串流實現即時分析、聊天或協同編輯。
- 探索將 MCP 串流整合至前端框架（React、Vue 等），實現即時 UI 更新。
- 下一步：[利用 VSCode 的 AI 工具包](../07-aitk/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋承擔責任。