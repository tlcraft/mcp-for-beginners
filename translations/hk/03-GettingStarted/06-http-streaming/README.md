<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T21:57:59+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hk"
}
-->
# HTTPS 串流與 Model Context Protocol (MCP)

本章詳盡介紹如何使用 HTTPS 透過 Model Context Protocol (MCP) 實作安全、可擴展且即時的串流功能。內容涵蓋串流的動機、可用的傳輸機制、MCP 中可串流 HTTP 的實作、安全最佳實踐、從 SSE 的遷移，以及建立自己的串流 MCP 應用程式的實務指引。

## MCP 的傳輸機制與串流

本節探討 MCP 中可用的不同傳輸機制，以及它們在實現客戶端與伺服器之間即時通訊串流功能上的角色。

### 什麼是傳輸機制？

傳輸機制定義了客戶端與伺服器間資料交換的方式。MCP 支援多種傳輸類型，以適應不同環境和需求：

- **stdio**：標準輸入/輸出，適合本地及 CLI 工具。簡單但不適用於網頁或雲端環境。
- **SSE (Server-Sent Events)**：讓伺服器能透過 HTTP 推送即時更新給客戶端。適合網頁介面，但在擴展性和彈性上有限。
- **Streamable HTTP**：基於現代 HTTP 的串流傳輸，支援通知與更佳的擴展性。建議用於大多數生產及雲端場景。

### 比較表

以下比較表幫助你了解這些傳輸機制的差異：

| 傳輸機制           | 即時更新         | 串流       | 擴展性       | 使用場景                 |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | 否               | 否        | 低          | 本地 CLI 工具           |
| SSE               | 是               | 是        | 中          | 網頁、即時更新          |
| Streamable HTTP   | 是               | 是        | 高          | 雲端、多客戶端          |

> **提示：** 選擇合適的傳輸機制會影響效能、擴展性及用戶體驗。**Streamable HTTP** 是現代、可擴展且適合雲端應用的推薦方案。

請注意前幾章介紹的 stdio 和 SSE 傳輸機制，以及本章重點的 streamable HTTP。

## 串流：概念與動機

理解串流的基本概念與動機，是實作有效即時通訊系統的關鍵。

**串流** 是網路程式設計中的一種技術，允許資料以小且可控的片段或事件序列方式傳送與接收，而非等待整個回應完成。這對以下情境特別有用：

- 大型檔案或資料集。
- 即時更新（例如聊天、進度條）。
- 長時間運算，讓使用者隨時掌握進度。

串流的高層次要點：

- 資料逐步傳送，而非一次性全部送出。
- 客戶端可即時處理接收到的資料。
- 降低感知延遲，提升用戶體驗。

### 為什麼要用串流？

使用串流的原因包括：

- 使用者可即時獲得反饋，而非等到全部完成才收到結果。
- 支援即時應用與響應式 UI。
- 更有效率地利用網路與運算資源。

### 簡單範例：HTTP 串流伺服器與客戶端

以下是串流實作的簡單範例：

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

此範例展示伺服器在訊息可用時即時發送給客戶端，而非等待所有訊息都準備好。

**運作原理：**
- 伺服器隨著訊息準備好即刻傳送。
- 客戶端接收並即時印出每段資料。

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`），而非單純透過 MCP 選擇串流。

- **簡單串流需求：** 傳統 HTTP 串流較易實作，足以滿足基本串流需求。

- **複雜互動應用：** MCP 串流提供更結構化的方式，帶有豐富的元資料，並能區分通知與最終結果。

- **AI 應用：** MCP 的通知系統對於長時間執行的 AI 任務特別有用，可讓使用者持續掌握進度。

## MCP 中的串流

你已經看到關於傳統串流與 MCP 串流的比較與建議，接下來深入探討如何在 MCP 中善用串流功能。

了解 MCP 框架下串流的運作方式，是打造在長時間處理時能即時回饋用戶的響應式應用的基礎。

在 MCP 中，串流並非將主要回應拆成多段傳送，而是透過發送**通知**給客戶端，在工具處理請求的過程中持續更新。這些通知可包含進度更新、日誌或其他事件。

### 運作方式

主要結果仍以單一回應送出。但處理過程中可透過獨立訊息傳送通知，讓客戶端即時更新。客戶端必須能處理並顯示這些通知。

## 什麼是通知？

前面提到「通知」，在 MCP 中指的是什麼？

通知是伺服器發送給客戶端的訊息，用來告知長時間運作中的進度、狀態或其他事件。通知提升透明度與用戶體驗。

例如，客戶端應在與伺服器完成初步握手後發送通知。

通知的 JSON 格式如下：

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

若要啟用日誌功能，伺服器需將其作為功能/能力開啟，如下所示：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 視使用的 SDK 而定，日誌功能可能預設啟用，或需在伺服器配置中明確開啟。

通知類型包括：

| 等級       | 說明                         | 範例用途                      |
|-----------|------------------------------|-----------------------------|
| debug     | 詳細除錯資訊                 | 函式進入/離開點             |
| info      | 一般資訊訊息                 | 操作進度更新                |
| notice    | 正常但重要事件               | 配置變更                    |
| warning   | 警告狀況                    | 使用已棄用功能              |
| error     | 錯誤狀況                    | 操作失敗                    |
| critical  | 嚴重狀況                    | 系統元件故障                |
| alert     | 必須立即採取行動            | 偵測到資料損壞              |
| emergency | 系統無法使用                | 完整系統故障                |

## 在 MCP 中實作通知

要在 MCP 中實作通知，需同時設定伺服器端與客戶端來處理即時更新。這能讓應用程式在長時間運作時即時回饋使用者。

### 伺服器端：發送通知

從伺服器端開始，在 MCP 中你定義可在處理請求時發送通知的工具。伺服器利用上下文物件（通常是 `ctx`）向客戶端發送訊息。

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

在上述範例中，`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

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

本節說明 MCP 中進度通知的概念、重要性，以及如何利用 Streamable HTTP 實作。並附帶實作練習以加深理解。

進度通知是在長時間運作過程中，伺服器即時發送給客戶端的訊息。伺服器不必等整個流程完成，而是持續更新當前狀態。這提升透明度、用戶體驗，並使除錯更容易。

**範例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 為什麼使用進度通知？

進度通知的重要性包括：

- **提升使用者體驗：** 使用者能看到工作進展，而非僅在結束時收到結果。
- **即時回饋：** 客戶端可顯示進度條或日誌，讓應用更有互動感。
- **便於除錯與監控：** 開發者與使用者可掌握流程卡在哪裡。

### 如何實作進度通知

以下是 MCP 中實作進度通知的方法：

- **伺服器端：** 使用 `ctx.info()` or `ctx.log()` 於處理每項目時發送通知，於主結果完成前即發送訊息給客戶端。
- **客戶端：** 實作訊息處理器，監聽並顯示接收到的通知，並區分通知與最終結果。

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

當使用基於 HTTP 的傳輸實作 MCP 伺服器時，安全性是必須重視的重點，需針對多種攻擊向量與防護機制進行謹慎配置。

### 概述

公開 MCP 伺服器於 HTTP 時，安全性極為重要。Streamable HTTP 引入新的攻擊面，必須仔細設定。

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
3. **在客戶端實作訊息處理器** 以處理通知。
4. **測試與現有工具和工作流程的相容性**。

### 維持相容性

建議在遷移過程中維持與現有 SSE 客戶端的相容性。策略包括：

- 可同時支援 SSE 與 Streamable HTTP，並分別在不同端點運行。
- 逐步將客戶端遷移至新傳輸機制。

### 挑戰

遷移過程需克服以下挑戰：

- 確保所有客戶端都更新。
- 處理通知傳遞差異。

### 練習：打造自己的串流 MCP 應用

**情境：**  
建立一個 MCP 伺服器與客戶端，伺服器處理一串項目（例如檔案或文件），並於處理每個項目時發送通知。客戶端應即時顯示每則通知。

**步驟：**

1. 實作一個伺服器工具，處理項目列表並發送每項通知。
2. 實作一個客戶端，含訊息處理器，能即時顯示通知。
3. 執行並測試伺服器與客戶端，觀察通知。

[解答](./solution/README.md)

## 延伸閱讀與後續步驟

欲持續學習 MCP 串流並擴展知識，本節提供額外資源與建議的後續行動，助你打造更進階的應用。

### 延伸閱讀

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 後續步驟

- 嘗試打造更進階的 MCP 工具，使用串流實現即時分析、聊天或協作編輯。
- 探索將 MCP 串流整合至前端框架（React、Vue 等），實現即時 UI 更新。
- 下一步：[利用 AI Toolkit for VSCode](../07-aitk/README.md)

**免責聲明**：  
本文件乃使用人工智能翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引致的任何誤解或誤釋承擔責任。