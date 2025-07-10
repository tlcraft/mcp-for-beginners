<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-10T15:59:25+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hk"
}
-->
# HTTPS 串流與 Model Context Protocol (MCP)

本章節提供使用 HTTPS 實作安全、可擴展且即時串流的完整指南，搭配 Model Context Protocol (MCP)。內容涵蓋串流的動機、可用的傳輸機制、如何在 MCP 中實作可串流的 HTTP、安全最佳實踐、從 SSE 遷移，以及建立自訂串流 MCP 應用的實務指引。

## MCP 中的傳輸機制與串流

本節探討 MCP 中可用的不同傳輸機制，以及它們在實現客戶端與伺服器間即時通訊串流功能上的角色。

### 什麼是傳輸機制？

傳輸機制定義了客戶端與伺服器之間資料交換的方式。MCP 支援多種傳輸類型，以適應不同環境與需求：

- **stdio**：標準輸入/輸出，適合本地及 CLI 工具。簡單但不適合網頁或雲端環境。
- **SSE (Server-Sent Events)**：允許伺服器透過 HTTP 推送即時更新給客戶端。適合網頁 UI，但在擴展性與彈性上有限。
- **Streamable HTTP**：現代基於 HTTP 的串流傳輸，支援通知與更佳的擴展性。建議用於大多數生產與雲端場景。

### 比較表

請參考下表了解這些傳輸機制的差異：

| 傳輸機制          | 即時更新       | 串流       | 擴展性       | 使用場景                 |
|-------------------|----------------|------------|--------------|--------------------------|
| stdio             | 否             | 否         | 低           | 本地 CLI 工具            |
| SSE               | 是             | 是         | 中           | 網頁、即時更新           |
| Streamable HTTP   | 是             | 是         | 高           | 雲端、多客戶端           |

> **提示：** 選擇合適的傳輸機制會影響效能、擴展性與使用者體驗。**Streamable HTTP** 是現代、可擴展且適合雲端應用的推薦選擇。

請注意前幾章介紹過的 stdio 和 SSE 傳輸機制，以及本章重點介紹的 Streamable HTTP。

## 串流：概念與動機

理解串流的基本概念與動機，對於實作有效的即時通訊系統至關重要。

**串流** 是網路程式設計中的一種技術，允許資料以小而可控的區塊或事件序列方式傳送與接收，而非等待整個回應完成後才傳送。這在以下情況特別有用：

- 大型檔案或資料集。
- 即時更新（例如聊天、進度條）。
- 長時間運算，想持續向使用者回報狀態。

串流的高階重點如下：

- 資料逐步傳送，而非一次全部送出。
- 客戶端可即時處理接收到的資料。
- 降低感知延遲，提升使用者體驗。

### 為什麼要使用串流？

使用串流的原因包括：

- 使用者能立即獲得回饋，而非等到結束才看到結果。
- 支援即時應用與回應式 UI。
- 更有效率地使用網路與運算資源。

### 簡單範例：HTTP 串流伺服器與客戶端

以下是一個簡單的串流實作範例：

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

此範例示範伺服器在訊息可用時即時傳送給客戶端，而非等待所有訊息準備好後一次送出。

**運作方式：**
- 伺服器在每則訊息準備好時即時產生。
- 客戶端接收並即時印出每個區塊。

**需求：**
- 伺服器必須使用串流回應（例如 FastAPI 的 `StreamingResponse`）。
- 客戶端必須以串流方式處理回應（requests 中設定 `stream=True`）。
- Content-Type 通常為 `text/event-stream` 或 `application/octet-stream`。

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
- 使用 Spring Boot 的反應式架構與 `Flux` 進行串流
- `ServerSentEvent` 提供結構化事件串流與事件類型
- `WebClient` 搭配 `bodyToFlux()` 支援反應式串流消費
- `delayElements()` 模擬事件間的處理時間
- 事件可帶有類型（如 `info`、`result`）以利客戶端處理

</details>

### 比較：傳統串流 vs MCP 串流

傳統串流與 MCP 串流的差異可用下表說明：

| 特性                   | 傳統 HTTP 串流               | MCP 串流（通知）               |
|------------------------|------------------------------|-------------------------------|
| 主要回應               | 分塊傳送                     | 單一回應於結尾                |
| 進度更新               | 以資料區塊形式傳送           | 以通知訊息傳送                |
| 客戶端需求             | 必須處理串流                 | 必須實作訊息處理器            |
| 使用場景               | 大型檔案、AI 令牌串流        | 進度、日誌、即時回饋          |

### 主要差異說明

此外，還有以下關鍵差異：

- **通訊模式：**
   - 傳統 HTTP 串流：使用簡單的分塊傳輸編碼送出資料
   - MCP 串流：使用結構化通知系統，基於 JSON-RPC 協定

- **訊息格式：**
   - 傳統 HTTP：純文字區塊，帶換行符號
   - MCP：結構化的 LoggingMessageNotification 物件，含元資料

- **客戶端實作：**
   - 傳統 HTTP：簡單客戶端處理串流回應
   - MCP：較複雜的客戶端，需實作訊息處理器以處理不同訊息類型

- **進度更新：**
   - 傳統 HTTP：進度包含在主要回應串流中
   - MCP：進度透過獨立通知訊息傳送，主要回應於結尾送出

### 建議

在選擇實作傳統串流（如前述使用 `/stream` 的端點）或 MCP 串流時，我們有以下建議：

- **簡單串流需求：** 傳統 HTTP 串流較易實作，適合基本串流需求。
- **複雜互動應用：** MCP 串流提供更結構化的方式，帶有豐富元資料，且通知與最終結果分離。
- **AI 應用：** MCP 的通知系統特別適合長時間運算的 AI 任務，能持續向使用者回報進度。

## MCP 中的串流

到目前為止，你已看到傳統串流與 MCP 串流的比較與建議。接下來深入說明如何在 MCP 中利用串流。

理解 MCP 框架內串流的運作方式，對於打造在長時間運算中能即時回饋使用者的回應式應用至關重要。

在 MCP 中，串流並非將主要回應分塊傳送，而是透過在工具處理請求時，向客戶端發送**通知**。這些通知可包含進度更新、日誌或其他事件。

### 運作方式

主要結果仍以單一回應送出，但在處理過程中可透過獨立訊息發送通知，讓客戶端即時更新。客戶端必須能處理並顯示這些通知。

## 什麼是通知？

我們提到「通知」，在 MCP 中這是什麼意思？

通知是伺服器向客戶端發送的訊息，用以告知長時間操作中的進度、狀態或其他事件。通知提升透明度與使用者體驗。

例如，客戶端在與伺服器完成初始握手後，應該會收到一則通知。

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

通知屬於 MCP 中稱為 ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) 的主題。

要啟用日誌功能，伺服器需將其設定為功能/能力，如下：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 根據所使用的 SDK，日誌功能可能預設啟用，或需在伺服器設定中明確開啟。

通知有不同類型：

| 等級       | 說明                         | 範例使用情境                 |
|------------|------------------------------|------------------------------|
| debug      | 詳細除錯資訊                 | 函式進入/離開點              |
| info       | 一般資訊訊息                 | 操作進度更新                |
| notice     | 正常但重要事件               | 設定變更                    |
| warning    | 警告狀況                    | 使用已棄用功能              |
| error      | 錯誤狀況                    | 操作失敗                    |
| critical   | 關鍵狀況                    | 系統元件故障                |
| alert      | 必須立即採取行動            | 偵測到資料損毀              |
| emergency  | 系統無法使用                | 完整系統故障                |

## 在 MCP 中實作通知

要在 MCP 中實作通知，需同時設定伺服器與客戶端以處理即時更新。這讓應用能在長時間操作中即時回饋使用者。

### 伺服器端：發送通知

先從伺服器端開始。在 MCP 中，你定義的工具可在處理請求時發送通知。伺服器使用上下文物件（通常是 `ctx`）向客戶端發送訊息。

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

上述範例中，`process_files` 工具在處理每個檔案時會發送三則通知給客戶端。`ctx.info()` 方法用於發送資訊訊息。

</details>

此外，為啟用通知，請確保伺服器使用串流傳輸（如 `streamable-http`），且客戶端實作訊息處理器以處理通知。以下示範如何設定伺服器使用 `streamable-http` 傳輸：

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

此 .NET 範例中，`ProcessFiles` 工具以 `Tool` 屬性標註，並在處理每個檔案時發送三則通知給客戶端。`ctx.Info()` 方法用於發送資訊訊息。

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

客戶端必須實作訊息處理器，來處理並顯示接收到的通知。

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

上述程式碼中，`message_handler` 函式會檢查收到的訊息是否為通知。若是，則印出通知；否則當作一般伺服器訊息處理。並且注意 `ClientSession` 是如何以 `message_handler` 初始化，以處理接收的通知。

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

此 .NET 範例中，`MessageHandler` 函式會檢查收到的訊息是否為通知。若是，則印出通知；否則當作一般伺服器訊息處理。`ClientSession` 透過 `ClientSessionOptions` 以訊息處理器初始化。

</details>

要啟用通知，請確保伺服器使用串流傳輸（如 `streamable-http`），且客戶端實作訊息處理器以處理通知。

## 進度通知與應用場景

本節說明 MCP 中進度通知的概念、重要性，以及如何使用 Streamable HTTP 實作。你也會看到一個實務練習，幫助加深理解。

進度通知是伺服器在長時間操作中，向客戶端即時發送的訊息。伺服器不必等整個流程完成，便能持續更新客戶端目前狀態。這提升透明度、使用者體驗，並方便除錯。

**範例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 為什麼要使用進度通知？

進度通知的重要原因包括：

- **提升使用者體驗：** 使用者能看到工作進展，而非僅在結束時才有回饋。
- **即時回饋：** 客戶端可顯示進度條或日誌，讓應用感覺更有反應。
- **方便除錯與監控：** 開發者與使用者能了解流程卡在哪裡或變慢。

### 如何實作進度通知

以下是 MCP 中實作進度通知的方法：

- **伺服器端：** 使用 `ctx.info()` 或 `ctx.log()` 在處理每個項目時發送通知。這會在主要結果準備好前，先向客戶端發送訊息。
- **客戶端：** 實作訊息處理器，監聽並顯示接收到的通知。此處理器能區分通知與最終結果。

**伺服器範例：**

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

**Client 範例：**

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

在使用基於 HTTP 的傳輸實作 MCP 伺服器時，安全性成為首要關注點，需要仔細防範多種攻擊向量並採取保護機制。

### 概述

當 MCP 伺服器透過 HTTP 對外提供服務時，安全性非常重要。Streamable HTTP 引入了新的攻擊面，必須謹慎配置。

### 主要重點
- **Origin Header 驗證**：務必驗證 `Origin` 標頭，以防止 DNS 重綁定攻擊。
- **綁定 localhost**：本地開發時，將伺服器綁定到 `localhost`，避免暴露於公網。
- **身份驗證**：正式部署時實作身份驗證（例如 API 金鑰、OAuth）。
- **CORS**：設定跨來源資源共享（CORS）政策以限制存取。
- **HTTPS**：生產環境使用 HTTPS 以加密流量。

### 最佳實踐
- 不要輕信未經驗證的請求。
- 記錄並監控所有存取與錯誤。
- 定期更新相依套件以修補安全漏洞。

### 挑戰
- 在安全性與開發便利性間取得平衡
- 確保與各種客戶端環境的相容性


## 從 SSE 升級到 Streamable HTTP

對於目前使用 Server-Sent Events (SSE) 的應用程式，遷移到 Streamable HTTP 可提供更強大的功能與更長遠的可維護性。

### 為什麼要升級？

升級 SSE 至 Streamable HTTP 有兩大理由：

- Streamable HTTP 比 SSE 提供更佳的擴展性、相容性及更豐富的通知支援。
- 它是新 MCP 應用程式推薦使用的傳輸方式。

### 遷移步驟

以下是 MCP 應用程式從 SSE 遷移到 Streamable HTTP 的方法：

- **更新伺服器程式碼**，在 `mcp.run()` 中使用 `transport="streamable-http"`。
- **更新客戶端程式碼**，改用 `streamablehttp_client` 取代 SSE 客戶端。
- **在客戶端實作訊息處理器**，用以處理通知。
- **測試與現有工具和工作流程的相容性**。

### 維持相容性

建議在遷移期間維持與現有 SSE 客戶端的相容性。以下是一些策略：

- 可同時支援 SSE 與 Streamable HTTP，分別在不同端點運行。
- 逐步將客戶端遷移至新傳輸方式。

### 挑戰

遷移過程中需克服以下挑戰：

- 確保所有客戶端都完成更新
- 處理通知傳遞上的差異

## 安全考量

實作任何伺服器時，安全性都應是首要任務，尤其是使用像 Streamable HTTP 這類基於 HTTP 的傳輸於 MCP。

在使用基於 HTTP 的傳輸實作 MCP 伺服器時，安全性成為首要關注點，需要仔細防範多種攻擊向量並採取保護機制。

### 概述

當 MCP 伺服器透過 HTTP 對外提供服務時，安全性非常重要。Streamable HTTP 引入了新的攻擊面，必須謹慎配置。

以下是一些重要的安全考量：

- **Origin Header 驗證**：務必驗證 `Origin` 標頭，以防止 DNS 重綁定攻擊。
- **綁定 localhost**：本地開發時，將伺服器綁定到 `localhost`，避免暴露於公網。
- **身份驗證**：正式部署時實作身份驗證（例如 API 金鑰、OAuth）。
- **CORS**：設定跨來源資源共享（CORS）政策以限制存取。
- **HTTPS**：生產環境使用 HTTPS 以加密流量。

### 最佳實踐

此外，實作 MCP 串流伺服器時，建議遵循以下最佳實踐：

- 不要輕信未經驗證的請求。
- 記錄並監控所有存取與錯誤。
- 定期更新相依套件以修補安全漏洞。

### 挑戰

在實作 MCP 串流伺服器的安全性時，會面臨以下挑戰：

- 在安全性與開發便利性間取得平衡
- 確保與各種客戶端環境的相容性

### 作業：建立你自己的串流 MCP 應用程式

**情境：**  
建立一個 MCP 伺服器與客戶端，伺服器會處理一串項目（例如檔案或文件），並在處理每個項目時發送通知。客戶端應即時顯示每則通知。

**步驟：**

1. 實作一個伺服器工具，處理清單並為每個項目發送通知。
2. 實作一個客戶端，包含訊息處理器以即時顯示通知。
3. 同時執行伺服器與客戶端，測試並觀察通知。

[Solution](./solution/README.md)

## 延伸閱讀與後續步驟

想繼續深入 MCP 串流的學習並擴展知識，本節提供更多資源與建議的後續行動，幫助你打造更進階的應用程式。

### 延伸閱讀

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 後續建議

- 嘗試打造更進階的 MCP 工具，利用串流實現即時分析、聊天或協同編輯功能。
- 探索將 MCP 串流整合至前端框架（React、Vue 等），實現即時 UI 更新。
- 下一步：[利用 VSCode 的 AI 工具包](../07-aitk/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。