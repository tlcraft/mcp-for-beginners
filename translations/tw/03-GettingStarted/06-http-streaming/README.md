<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T21:59:04+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "tw"
}
-->
# 使用 Model Context Protocol (MCP) 的 HTTPS 串流

本章詳盡說明如何使用 HTTPS 及 Model Context Protocol (MCP) 實現安全、可擴展且即時的串流功能。內容涵蓋串流的動機、可用的傳輸機制、如何在 MCP 中實作可串流的 HTTP、安全最佳實踐、從 SSE 遷移的方式，以及構建自己的串流 MCP 應用的實務指導。

## MCP 的傳輸機制與串流

本節探討 MCP 中可用的不同傳輸機制，以及它們在實現客戶端與伺服器間即時通訊串流功能上的角色。

### 什麼是傳輸機制？

傳輸機制定義了客戶端與伺服器之間資料交換的方式。MCP 支援多種傳輸類型，以符合不同環境與需求：

- **stdio**：標準輸入/輸出，適合本地與 CLI 工具。簡單但不適用於網頁或雲端。
- **SSE (Server-Sent Events)**：允許伺服器透過 HTTP 推送即時更新給客戶端。適合網頁 UI，但在擴展性與彈性上有限。
- **Streamable HTTP**：現代化的基於 HTTP 的串流傳輸，支援通知與更佳的擴展性。推薦用於大多數生產環境與雲端場景。

### 比較表

請參考下表了解這些傳輸機制的差異：

| 傳輸方式          | 即時更新        | 串流        | 擴展性      | 使用場景                 |
|-------------------|-----------------|-------------|-------------|--------------------------|
| stdio             | 否              | 否          | 低          | 本地 CLI 工具            |
| SSE               | 是              | 是          | 中          | 網頁、即時更新           |
| Streamable HTTP   | 是              | 是          | 高          | 雲端、多用戶             |

> **提示：** 選擇合適的傳輸方式會影響效能、擴展性與使用者體驗。**Streamable HTTP** 是現代、可擴展且適合雲端應用的推薦選擇。

請注意前幾章介紹的 stdio 和 SSE 傳輸方式，以及本章所涵蓋的 Streamable HTTP 傳輸。

## 串流：概念與動機

理解串流的基本概念與動機，是實作有效即時通訊系統的關鍵。

**串流** 是網路程式設計中的一種技術，允許資料以小且可管理的區塊或事件序列形式傳送與接收，而非等待整個回應完成後一次送達。這在以下情況特別有用：

- 大型檔案或資料集
- 即時更新（如聊天、進度條）
- 長時間運算，且希望持續向使用者回報狀態

以下是串流的高階要點：

- 資料逐步送達，而非一次性全部傳送
- 客戶端可即時處理收到的資料
- 降低感知延遲，提升使用者體驗

### 為什麼要使用串流？

使用串流的原因如下：

- 使用者能立即獲得回饋，而非僅在結束時收到結果
- 支援即時應用與響應式 UI
- 更有效率地利用網路與運算資源

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

此範例示範伺服器隨著訊息產生即時傳送給客戶端，而非等待所有訊息準備好後一次送出。

**運作方式：**
- 伺服器在每則訊息準備好時即刻產出。
- 客戶端接收並即時印出每個區塊。

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

- **簡單串流需求：** 傳統 HTTP 串流較易實作，適用於基本串流需求。

- **複雜互動應用：** MCP 串流提供更有結構的方式，包含豐富的元資料，以及通知與最終結果的分離。

- **AI 應用：** MCP 的通知系統特別適合長時間執行的 AI 任務，可持續向使用者回報進度。

## MCP 中的串流

目前你已看到關於傳統串流與 MCP 串流的建議與比較，接下來將詳細說明如何在 MCP 中運用串流。

理解 MCP 框架中串流的運作，對於打造在長時間操作中能即時回饋使用者的響應式應用至關重要。

在 MCP 中，串流並非將主要回應分塊傳送，而是在工具處理請求時，向客戶端發送**通知**。這些通知可包含進度更新、日誌或其他事件。

### 運作原理

主要結果仍以單一回應送出，但在處理過程中可分別發送通知訊息，讓客戶端即時更新。客戶端必須能夠處理並顯示這些通知。

## 什麼是通知？

剛才提到「通知」，在 MCP 的上下文中是什麼意思？

通知是伺服器在長時間操作期間，向客戶端傳送的訊息，用以告知進度、狀態或其他事件。通知提升透明度與使用者體驗。

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

若要啟用日誌功能，伺服器需以如下方式啟用此功能：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 根據使用的 SDK，日誌功能可能預設啟用，或需在伺服器設定中明確啟用。

通知類型如下：

| 等級       | 說明                         | 範例使用場景                 |
|------------|------------------------------|------------------------------|
| debug      | 詳細除錯資訊                 | 函式進入/離開點              |
| info       | 一般資訊訊息                 | 操作進度更新                |
| notice     | 正常但重要的事件             | 設定變更                    |
| warning    | 警告狀況                    | 廢棄功能使用                |
| error      | 錯誤狀況                    | 操作失敗                    |
| critical   | 致命狀況                    | 系統元件故障                |
| alert      | 需立即採取行動              | 偵測到資料損壞              |
| emergency  | 系統無法使用                | 完全系統故障                |

## 在 MCP 中實作通知

要在 MCP 中實作通知，需同時設定伺服器端與客戶端以處理即時更新。這讓應用能在長時間操作中即時回饋使用者。

### 伺服器端：發送通知

從伺服器端開始。在 MCP 中，你會定義可在處理請求時發送通知的工具。伺服器使用上下文物件（通常是 `ctx`）來傳送訊息給客戶端。

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

在上述程式碼中，`message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`，客戶端實作訊息處理器以處理通知。

## 進度通知與應用場景

本節說明 MCP 中進度通知的概念、重要性，以及如何使用 Streamable HTTP 實作。並提供實務練習以加深理解。

進度通知是伺服器在長時間操作期間，向客戶端發送的即時訊息。伺服器不需等待整個流程結束，即持續回報當前狀態。這提升透明度、使用者體驗，也方便除錯。

**範例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 為什麼使用進度通知？

進度通知的重要性如下：

- **提升使用者體驗：** 使用者能隨時看到工作進度，而非僅在結束時。
- **即時回饋：** 客戶端可顯示進度條或日誌，讓應用感覺更靈敏。
- **方便除錯與監控：** 開發者與使用者能看到流程中可能的瓶頸或卡住的地方。

### 如何實作進度通知

以下是 MCP 中實作進度通知的方法：

- **伺服器端：** 使用 `ctx.info()` or `ctx.log()` 在每處理一項目時發送通知。這會在主要結果準備好前，先向客戶端發送訊息。
- **客戶端：** 實作訊息處理器，監聽並顯示接收到的通知。此處理器需區分通知與最終結果。

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

在使用基於 HTTP 的傳輸實作 MCP 伺服器時，安全性是極其重要的議題，需謹慎防範多種攻擊向量並採取保護機制。

### 概述

當 MCP 伺服器透過 HTTP 對外開放時，安全性至關重要。Streamable HTTP 引入新的攻擊面，需謹慎設定。

### 重點
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
3. **在客戶端實作訊息處理器**，處理通知。
4. **測試與現有工具和工作流程的相容性**。

### 維持相容性

建議在遷移過程中維持與現有 SSE 客戶端的相容性。以下為一些策略：

- 可同時支援 SSE 與 Streamable HTTP，分別在不同端點運行。
- 逐步將客戶端遷移至新傳輸。

### 挑戰

遷移時需解決以下問題：

- 確保所有客戶端皆已更新
- 處理通知傳遞差異

### 練習：打造自己的串流 MCP 應用

**情境：**  
建立一個 MCP 伺服器與客戶端，伺服器處理一組項目（例如檔案或文件），並在處理每個項目時發送通知。客戶端應即時顯示每則通知。

**步驟：**

1. 實作一個伺服器工具，處理清單並為每項目發送通知。
2. 實作一個客戶端，包含訊息處理器即時顯示通知。
3. 執行伺服器與客戶端，觀察通知訊息。

[解答](./solution/README.md)

## 延伸閱讀與後續行動

若想繼續深入 MCP 串流並擴展知識，本節提供額外資源與建議的下一步，幫助你打造更進階的應用。

### 延伸閱讀

- [Microsoft：HTTP 串流入門](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft：Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft：ASP.NET Core 中的 CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests：串流請求](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 後續行動

- 嘗試打造更進階的 MCP 工具，利用串流實現即時分析、聊天或協同編輯。
- 探索將 MCP 串流與前端框架（React、Vue 等）整合，實現即時 UI 更新。
- 下一章：[利用 AI Toolkit for VSCode](../07-aitk/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所產生之任何誤解或誤釋負責。