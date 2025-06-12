<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-12T22:13:32+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "tw"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

本章提供使用 HTTPS 實作 Model Context Protocol (MCP) 安全、可擴展且即時串流的完整指南。內容涵蓋串流的動機、可用的傳輸機制、如何在 MCP 中實作可串流的 HTTP、安全最佳實務、從 SSE 遷移，以及建立自有串流 MCP 應用的實務指引。

## MCP 中的傳輸機制與串流

本節探討 MCP 中不同的傳輸機制，以及它們在實現客戶端與伺服器即時通訊串流功能的角色。

### 什麼是傳輸機制？

傳輸機制定義客戶端與伺服器間資料交換的方式。MCP 支援多種傳輸類型，以符合不同環境與需求：

- **stdio**：標準輸入/輸出，適合本地和 CLI 工具。簡單但不適合網頁或雲端。
- **SSE (Server-Sent Events)**：允許伺服器透過 HTTP 向客戶端推送即時更新。適合網頁介面，但在擴展性與彈性有限。
- **Streamable HTTP**：現代化基於 HTTP 的串流傳輸，支援通知與更佳的擴展性。建議用於大多數生產與雲端場景。

### 比較表

請參考下表了解這些傳輸機制的差異：

| 傳輸機制           | 即時更新         | 串流       | 擴展性       | 使用案例                |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | 否               | 否        | 低          | 本地 CLI 工具           |
| SSE               | 是               | 是        | 中          | 網頁，即時更新          |
| Streamable HTTP   | 是               | 是        | 高          | 雲端，多客戶端          |

> **Tip:** 選擇合適的傳輸方式會影響效能、擴展性與使用者體驗。**Streamable HTTP** 是現代、可擴展且適合雲端應用的推薦方案。

請注意前面章節提過的 stdio 和 SSE 傳輸，以及本章所介紹的 Streamable HTTP 傳輸。

## 串流：概念與動機

理解串流的基本概念與動機，是實作有效即時通訊系統的關鍵。

**串流** 是網路程式設計中的一種技術，允許資料以小且可管理的區塊或事件序列形式傳送與接收，而非等待整個回應完成。這對以下情境特別有用：

- 大型檔案或資料集。
- 即時更新（例如聊天、進度條）。
- 長時間運算時想持續通知使用者。

串流的高階重點包括：

- 資料逐步送達，不是一次全送完。
- 客戶端可即時處理資料。
- 降低感知延遲，提升使用者體驗。

### 為什麼要用串流？

使用串流的原因如下：

- 使用者能即時收到回饋，而非等待結束才看到結果
- 支援即時應用與反應迅速的介面
- 更有效率地利用網路與運算資源

### 簡單範例：HTTP 串流伺服器與客戶端

以下是一個簡單示範如何實作串流：

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

此範例示範伺服器隨時傳送訊息給客戶端，而非等待所有訊息都準備好才送出。

**運作方式：**
- 伺服器在每則訊息準備好時即刻送出。
- 客戶端接收並即時列印每個資料區塊。

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

- **簡單串流需求：** 傳統 HTTP 串流較容易實作，適合基本串流需求。

- **複雜且互動式應用：** MCP 串流提供更有結構的方式，包含豐富的元資料，並分離通知與最終結果。

- **AI 應用：** MCP 的通知系統特別適合長時間運算的 AI 任務，能持續向使用者回報進度。

## MCP 中的串流

好，前面你已經看過關於傳統串流與 MCP 串流的推薦與比較，現在來深入了解如何在 MCP 中運用串流。

理解 MCP 框架內的串流運作，對於建立能在長時間操作中即時回饋使用者的應用至關重要。

在 MCP 裡，串流不是將主要回應分段傳送，而是在工具處理請求時，向客戶端傳送**通知**。這些通知可能包含進度更新、日誌或其他事件。

### 運作原理

主要結果仍會以單一回應送出，但通知會在處理過程中以獨立訊息傳送，實時更新客戶端。客戶端必須能處理並顯示這些通知。

## 什麼是通知？

剛剛提到「通知」，在 MCP 的語境中指的是什麼？

通知是伺服器發送給客戶端的訊息，用來告知長時間操作中的進度、狀態或其他事件。通知提升透明度與使用者體驗。

例如，客戶端應在與伺服器完成初步握手後，收到一則通知。

通知通常是像這樣的 JSON 訊息：

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

要啟用日誌功能，伺服器需要像下面這樣開啟該功能/能力：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 依所用 SDK 不同，日誌功能可能預設開啟，或需在伺服器設定中明確啟用。

通知類型多樣：

| 等級       | 描述                         | 範例使用情境                 |
|-----------|------------------------------|-----------------------------|
| debug     | 詳細除錯資訊                  | 函式進入/離開點             |
| info      | 一般資訊訊息                  | 操作進度更新                 |
| notice    | 正常但重要事件                | 設定變更                     |
| warning   | 警告狀況                    | 使用已棄用功能               |
| error     | 錯誤狀況                    | 操作失敗                     |
| critical  | 關鍵狀況                    | 系統元件故障                 |
| alert     | 必須立即採取行動              | 偵測到資料損毀               |
| emergency | 系統無法使用                  | 完全系統故障                 |

## 在 MCP 中實作通知

要在 MCP 中實作通知，需同時設定伺服器與客戶端以處理即時更新。如此一來，應用能在長時間操作中即時回饋使用者。

### 伺服器端：發送通知

先從伺服器端開始。在 MCP 中，你定義的工具可以在處理請求時發送通知。伺服器利用上下文物件（通常是 `ctx`）向客戶端傳送訊息。

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

前述範例中，`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` 傳輸：

```python
mcp.run(transport="streamable-http")
```

</details>

### 客戶端：接收通知

客戶端必須實作訊息處理器，以處理並顯示收到的通知。

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

本節說明 MCP 中的進度通知概念、重要性，以及如何用 Streamable HTTP 實作。並提供實務練習以加深理解。

進度通知是伺服器在長時間操作中，持續向客戶端傳送的即時訊息。伺服器不必等整個流程結束，能持續更新目前狀態。這提升透明度、使用者體驗，也方便除錯。

**範例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 為什麼使用進度通知？

進度通知重要原因：

- **提升使用者體驗：** 使用者能看到工作進度，而非只在結束時看到結果。
- **即時回饋：** 客戶端能顯示進度條或日誌，讓應用感覺更靈敏。
- **方便除錯與監控：** 開發者與使用者能掌握流程卡在哪裡或變慢。

### 如何實作進度通知

以下是 MCP 中實作進度通知的方法：

- **伺服器端：** 使用 `ctx.info()` or `ctx.log()` 在處理每個項目時發送通知。這會在主要結果準備好前，先傳送訊息給客戶端。
- **客戶端：** 實作訊息處理器，監聽並顯示收到的通知。此處理器會區分通知與最終結果。

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

當使用基於 HTTP 的傳輸實作 MCP 伺服器時，安全性成為極為重要的議題，需要謹慎防範多種攻擊向量並採取保護機制。

### 概述

公開 MCP 伺服器於 HTTP 上時，安全至關重要。Streamable HTTP 帶來新的攻擊面，必須仔細設定。

### 主要要點
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
3. **在客戶端實作訊息處理器** 以處理通知。
4. **測試與現有工具和工作流程的相容性。**

### 維持相容性

建議在遷移期間維持與現有 SSE 客戶端的相容性，策略包括：

- 同時支援 SSE 與 Streamable HTTP，分別運行於不同端點。
- 漸進式將客戶端遷移至新傳輸方式。

### 挑戰

遷移過程中需克服的挑戰：

- 確保所有客戶端都已更新
- 處理通知傳遞差異

### 作業：建立自己的串流 MCP 應用

**情境：**  
建立一個 MCP 伺服器與客戶端，伺服器處理一串項目（例如檔案或文件），並在處理每個項目時發送通知。客戶端應即時顯示每則通知。

**步驟：**

1. 實作一個伺服器工具，處理列表並對每個項目發送通知。
2. 實作一個客戶端，含訊息處理器，能即時顯示通知。
3. 執行伺服器與客戶端，並觀察通知效果。

[Solution](./solution/README.md)

## 延伸閱讀與後續步驟

欲持續探索 MCP 串流並擴展知識，本節提供額外資源與建議後續進階應用的方向。

### 延伸閱讀

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 後續步驟

- 嘗試開發更進階的 MCP 工具，利用串流實現即時分析、聊天或協同編輯。
- 探索將 MCP 串流整合至前端框架（React、Vue 等），實現即時 UI 更新。
- 下一步：[Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意自動翻譯可能會包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生之任何誤解或曲解負責。