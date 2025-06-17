<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T21:56:49+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "mo"
}
-->
# 使用 Model Context Protocol (MCP) 的 HTTPS 串流

本章提供了使用 HTTPS 和 Model Context Protocol (MCP) 實現安全、可擴展且即時串流的完整指南。內容涵蓋串流的動機、可用的傳輸機制、如何在 MCP 中實現可串流的 HTTP、安全最佳實踐、從 SSE 遷移，以及建立自己的串流 MCP 應用的實務指引。

## MCP 的傳輸機制與串流

本節探討 MCP 中可用的不同傳輸機制，以及它們在實現客戶端與伺服器之間即時通訊串流功能上的角色。

### 什麼是傳輸機制？

傳輸機制定義了客戶端與伺服器之間資料交換的方式。MCP 支援多種傳輸類型，以適應不同環境與需求：

- **stdio**：標準輸入/輸出，適合本地及 CLI 工具。簡單，但不適用於網頁或雲端環境。
- **SSE（Server-Sent Events）**：允許伺服器透過 HTTP 向客戶端推送即時更新。適合網頁介面，但在擴展性和彈性上有限。
- **可串流 HTTP（Streamable HTTP）**：基於現代 HTTP 的串流傳輸，支援通知功能且具更佳擴展性。建議用於大多數生產及雲端場景。

### 比較表

請參考下表，了解這些傳輸機制的差異：

| 傳輸方式         | 即時更新       | 串流       | 擴展性       | 使用案例               |
|-----------------|----------------|------------|--------------|------------------------|
| stdio           | 否             | 否         | 低           | 本地 CLI 工具          |
| SSE             | 是             | 是         | 中           | 網頁，即時更新         |
| 可串流 HTTP      | 是             | 是         | 高           | 雲端，多客戶端         |

> **提示：** 選擇合適的傳輸方式會影響效能、擴展性和使用者體驗。**可串流 HTTP** 是現代、可擴展且適合雲端應用的推薦選擇。

請注意前幾章介紹的 stdio 和 SSE 傳輸方式，以及本章重點介紹的可串流 HTTP 傳輸。

## 串流：概念與動機

理解串流的基本概念與動機，對於實作有效的即時通訊系統至關重要。

**串流** 是網路程式設計中的一種技術，允許資料以小且可管理的片段或事件序列方式發送與接收，而不必等待整個回應完成。這對以下情況特別有用：

- 大型檔案或資料集
- 即時更新（例如聊天、進度條）
- 長時間運算，想持續向使用者回報狀態

高階來說，串流的重點是：

- 資料逐步送達，而非一次全部傳送
- 客戶端可即時處理收到的資料
- 降低感知延遲，提升使用者體驗

### 為什麼要使用串流？

使用串流的原因如下：

- 使用者能立即獲得回饋，而非等到結束才看到結果
- 支援即時應用與反應式介面
- 更有效利用網路與運算資源

### 簡單範例：HTTP 串流伺服器與客戶端

以下是串流實作的簡單範例：

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

此範例展示伺服器如何在訊息陸續產生時，逐一傳送給客戶端，而非等待所有訊息準備好後一次送出。

**運作原理：**
- 伺服器在訊息準備好時逐條產出。
- 客戶端接收並即時列印每個片段。

**需求：**
- 伺服器必須使用串流回應（例如 `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`），而非透過 MCP 選擇串流。

- **簡單串流需求：** 傳統 HTTP 串流實作較簡單，適用於基本串流需求。

- **複雜互動應用：** MCP 串流提供更結構化的方式，擁有豐富的元資料，並區分通知與最終結果。

- **AI 應用：** MCP 的通知系統特別適合長時間運算的 AI 任務，可持續向使用者回報進度。

## MCP 中的串流

到目前為止，你已經看到傳統串流與 MCP 串流的比較與建議。接下來詳細說明如何在 MCP 中利用串流功能。

了解 MCP 框架中的串流運作方式，對於打造能在長時間運算時即時回饋使用者的反應式應用至關重要。

在 MCP 中，串流不是將主要回應分塊傳送，而是指在工具處理請求時，向客戶端傳送**通知**。這些通知可以包含進度更新、日誌或其他事件。

### 運作方式

主要結果仍會作為單一回應傳送。然而，通知會在處理過程中以獨立訊息發送，從而即時更新客戶端。客戶端必須能夠處理並顯示這些通知。

## 什麼是通知？

我們提到「通知」，在 MCP 的語境中這是什麼意思？

通知是伺服器在長時間運算過程中，向客戶端發送的訊息，用以告知進度、狀態或其他事件。通知提升透明度與使用者體驗。

例如，客戶端在與伺服器完成初始握手後，應該發送一則通知。

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

| 等級       | 說明                         | 範例使用情境                |
|------------|------------------------------|-----------------------------|
| debug      | 詳細除錯資訊                 | 函式進入/退出點             |
| info       | 一般資訊訊息                 | 操作進度更新               |
| notice     | 正常但重要事件               | 配置變更                   |
| warning    | 警告狀況                   | 使用已棄用功能             |
| error      | 錯誤狀況                   | 操作失敗                   |
| critical   | 關鍵狀況                   | 系統元件故障               |
| alert      | 必須立即採取行動             | 偵測到資料損壞             |
| emergency  | 系統無法使用                 | 完整系統故障               |

## 在 MCP 中實作通知

要在 MCP 中實作通知，需要同時設置伺服器端與客戶端以處理即時更新。這讓應用能在長時間運算中，立即回饋使用者。

### 伺服器端：發送通知

先從伺服器端開始。在 MCP 中，你定義可在處理請求時發送通知的工具。伺服器利用上下文物件（通常為 `ctx`）向客戶端傳送訊息。

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

### 客戶端：接收通知

客戶端必須實作訊息處理器，以接收並顯示即時通知。

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

上述程式碼中，`message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`，客戶端實作訊息處理器來處理通知。

## 進度通知與應用場景

本節說明 MCP 中進度通知的概念、重要性，以及如何利用可串流 HTTP 實作。你也會找到一個實務練習來加深理解。

進度通知是伺服器在長時間運算期間，向客戶端即時發送的訊息。伺服器不必等整個流程結束，就持續更新目前狀態。這提升透明度、使用者體驗，並方便除錯。

**範例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 為什麼要使用進度通知？

進度通知的重要原因包括：

- **提升使用者體驗：** 使用者能看到作業進展，而非僅在結束時才有回饋。
- **即時回饋：** 客戶端可顯示進度條或日誌，使應用感覺更有回應性。
- **方便除錯與監控：** 開發者與使用者可了解流程在哪個階段可能緩慢或卡住。

### 如何實作進度通知

以下為 MCP 中實作進度通知的方法：

- **伺服器端：** 使用 `ctx.info()` or `ctx.log()` 於處理每個項目時發送通知，讓客戶端在主結果準備好前即獲得訊息。
- **客戶端：** 實作訊息處理器，監聽並顯示通知，並區分通知與最終結果。

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

在使用基於 HTTP 的傳輸實作 MCP 伺服器時，安全性是必須重視的重點，需謹慎防範多種攻擊向量並採取保護措施。

### 概覽

當 MCP 伺服器透過 HTTP 暴露時，安全性至關重要。可串流 HTTP 引入新的攻擊面，必須仔細配置。

### 主要重點
- **Origin 標頭驗證**：務必驗證 `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client`，而非 SSE 客戶端。
3. **在客戶端實作訊息處理器**，以處理通知。
4. **測試與現有工具和工作流程的相容性**。

### 維持相容性

遷移過程中建議保持與現有 SSE 客戶端的相容性。以下為一些策略：

- 可同時支援 SSE 與可串流 HTTP，分別在不同端點運行。
- 逐步將客戶端遷移至新傳輸。

### 挑戰

遷移時需解決以下挑戰：

- 確保所有客戶端皆已更新
- 處理通知傳遞方式的差異

### 練習：打造你自己的串流 MCP 應用

**情境：**  
建立一個 MCP 伺服器與客戶端，伺服器處理一串項目（例如檔案或文件），並在處理每個項目時發送通知。客戶端應即時顯示每則通知。

**步驟：**

1. 實作一個伺服器工具，處理清單並為每個項目發送通知。
2. 實作一個帶有訊息處理器的客戶端，能即時顯示通知。
3. 同時執行伺服器與客戶端，並觀察通知效果。

[解答](./solution/README.md)

## 延伸閱讀與後續方向

若想持續深入 MCP 串流並擴展知識，本節提供額外資源與建議後續步驟，幫助你打造更進階的應用。

### 延伸閱讀

- [Microsoft：HTTP 串流入門](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft：Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft：ASP.NET Core 中的 CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests：串流請求](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 後續方向

- 嘗試開發更多使用串流的 MCP 工具，如即時分析、聊天或協同編輯。
- 探索將 MCP 串流整合至前端框架（React、Vue 等），實現即時 UI 更新。
- 下一章：[VSCode AI 工具包應用](../07-aitk/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。因使用本翻譯所產生之任何誤解或誤譯，本公司概不負責。