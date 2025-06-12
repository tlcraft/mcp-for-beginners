<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-12T22:14:00+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hk"
}
-->
# HTTPS 串流同 Model Context Protocol (MCP)

本章詳細介紹點樣用 HTTPS 同 Model Context Protocol (MCP) 去實現安全、可擴展、同實時嘅串流。內容涵蓋串流嘅動機、可用嘅傳輸機制、點樣喺 MCP 實現可串流嘅 HTTP、安全最佳實踐、由 SSE 過渡嘅方法，以及點樣實際建立你自己嘅串流 MCP 應用。

## MCP 嘅傳輸機制同串流

呢部分講解 MCP 支援嘅唔同傳輸機制，以及佢哋喺實現客戶端同伺服器實時通訊嘅串流功能中嘅角色。

### 乜嘢係傳輸機制？

傳輸機制係定義客戶端同伺服器之間點樣交換數據。MCP 支援多種傳輸類型，適合唔同環境同需求：

- **stdio**：標準輸入/輸出，適合本地同命令行工具。簡單但唔適合 web 或雲端。
- **SSE (Server-Sent Events)**：伺服器可以透過 HTTP 向客戶端推送實時更新。適合 web UI，但擴展性同彈性有限。
- **Streamable HTTP**：基於現代 HTTP 嘅串流傳輸，支援通知同更好嘅擴展性。建議用喺大部分生產同雲端場景。

### 比較表

睇下下面嘅比較表，了解呢啲傳輸機制嘅分別：

| 傳輸方式          | 實時更新         | 串流          | 擴展性       | 使用場景               |
|------------------|-----------------|--------------|------------|----------------------|
| stdio            | 否              | 否           | 低          | 本地 CLI 工具          |
| SSE              | 是              | 是           | 中          | Web、實時更新          |
| Streamable HTTP  | 是              | 是           | 高          | 雲端、多客戶端         |

> **Tip:** 揀啱嘅傳輸方式會影響效能、擴展性同用戶體驗。**Streamable HTTP** 係現代、可擴展同適合雲端應用嘅推薦方案。

留意之前章節介紹過嘅 stdio 同 SSE 傳輸，今次呢章重點係 Streamable HTTP。

## 串流：概念同動機

了解串流嘅基本概念同動機，對實現有效嘅實時通訊系統好重要。

**串流**係一種網絡編程技巧，容許數據以細小、可管理嘅片段或事件序列形式發送同接收，而唔係等整個回應完成先處理。呢個方法特別適合：

- 大型檔案或數據集。
- 實時更新（例如聊天、進度條）。
- 長時間運算，需要持續通知用戶。

高層次講，串流有以下特點：

- 數據逐步送達，唔係一次過。
- 客戶端可以邊收邊處理數據。
- 減低感知延遲，提升用戶體驗。

### 點解用串流？

用串流嘅原因包括：

- 用戶即時收到反饋，唔係等到最後先見到結果
- 支援實時應用同反應靈敏嘅 UI
- 更有效利用網絡同計算資源

### 簡單示例：HTTP 串流伺服器同客戶端

以下係一個簡單示例，展示點樣實現串流：

<details>
<summary>Python</summary>

**伺服器 (Python，用 FastAPI 同 StreamingResponse)：**
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

**客戶端 (Python，用 requests)：**
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

呢個示例展示伺服器點樣即時發送多個訊息畀客戶端，而唔係等所有訊息準備好先發。

**工作原理：**
- 伺服器逐條發送訊息。
- 客戶端即時接收同打印每個片段。

**要求：**
- 伺服器要用串流回應（例如 `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`），而唔係用 MCP 去揀串流。

- **簡單串流需求：** 傳統 HTTP 串流較易實現，足夠基本需求。

- **複雜互動應用：** MCP 串流提供結構化方法，包含更豐富嘅元數據，同通知同最終結果分離。

- **AI 應用：** MCP 嘅通知系統對長時間運算嘅 AI 任務特別有用，可以持續通知用戶進度。

## MCP 裡面嘅串流

到而家為止，你已經睇過傳統串流同 MCP 串流嘅推薦同比較。依家深入講解點樣喺 MCP 利用串流。

了解 MCP 框架入面串流嘅工作原理，對建立響應式應用好重要，可以喺長時間運算期間即時回饋用戶。

喺 MCP 入面，串流唔係將主要回應分塊發送，而係喺工具處理請求時，向客戶端發送**通知**。呢啲通知可以係進度更新、日誌或者其他事件。

### 工作原理

主要結果仍然係一次過發送。但通知可以喺處理過程中作為獨立訊息發送，實時更新客戶端。客戶端要能夠處理同顯示呢啲通知。

## 乜嘢係通知？

講到「通知」，喺 MCP 嘅上下文入面係乜意思？

通知係伺服器發送畀客戶端嘅訊息，用嚟通知進度、狀態或其他事件，特別係喺長時間運行嘅操作中。通知提升透明度同用戶體驗。

例如，客戶端應該喺同伺服器完成初步握手後發送通知。

通知嘅 JSON 格式大致係咁：

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

通知屬於 MCP 入面叫做 ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) 嘅主題。

要啟用日誌功能，伺服器需要喺功能/能力中開啟，如下：

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 視乎使用嘅 SDK，日誌可能係預設啟用，或者你需要喺伺服器配置中明確啟用。

通知有唔同類型：

| 級別       | 描述                          | 範例用途                      |
|-----------|-----------------------------|-----------------------------|
| debug     | 詳細除錯資訊                   | 函數進入/退出點              |
| info      | 一般資訊訊息                   | 操作進度更新                 |
| notice    | 正常但重要事件                 | 配置變更                     |
| warning   | 警告狀況                      | 使用已棄用功能               |
| error     | 錯誤狀況                      | 操作失敗                     |
| critical  | 臨界狀況                      | 系統組件故障                 |
| alert     | 必須立即採取行動               | 偵測到數據損壞               |
| emergency | 系統無法使用                   | 完整系統故障                 |

## 喺 MCP 實現通知

要喺 MCP 實現通知，你需要同時設置伺服器同客戶端，處理實時更新。咁你嘅應用就可以喺長時間運算時即時向用戶反饋。

### 伺服器端：發送通知

由伺服器端開始講。喺 MCP，你定義嘅工具可以喺處理請求時發送通知。伺服器用 context 物件（通常係 `ctx`）向客戶端發送訊息。

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

喺上述示例中，`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` 傳輸：

```python
mcp.run(transport="streamable-http")
```

</details>

### 客戶端：接收通知

客戶端必須實現一個訊息處理器，處理同顯示即時到達嘅通知。

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`，你嘅客戶端會用訊息處理器去處理通知。

## 進度通知同場景

呢部分解釋 MCP 入面進度通知嘅概念、重要性，以及點樣用 Streamable HTTP 實現。仲有實際練習幫助理解。

進度通知係伺服器喺長時間操作期間向客戶端發送嘅實時訊息。唔使等整個流程完成，伺服器會持續更新當前狀態。呢樣提升透明度、用戶體驗，亦方便除錯。

**示例：**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 點解用進度通知？

進度通知重要嘅原因：

- **更好嘅用戶體驗：** 用戶見到工作進度更新，唔係淨係最後先見到結果。
- **實時反饋：** 客戶端可以顯示進度條或日誌，令應用更有反應。
- **方便除錯同監控：** 開發者同用戶可以睇到流程邊度可能慢或停頓。

### 點樣實現進度通知

以下係 MCP 裡面實現進度通知嘅方法：

- **伺服器端：** 用 `ctx.info()` or `ctx.log()` 喺每處理一項時發送通知，喺主結果準備好之前發送訊息。
- **客戶端：** 實現訊息處理器，監聽同顯示通知。呢個處理器會分辨通知同最終結果。

**伺服器示例：**

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

**客戶端示例：**

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

## 安全考慮

實現 MCP 伺服器時，尤其係用 HTTP 傳輸，安全係重中之重，需要仔細防範多種攻擊途徑同保護措施。

### 概覽

當透過 HTTP 對外暴露 MCP 伺服器時，安全至關重要。Streamable HTTP 帶來新嘅攻擊面，需要謹慎配置。

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
2. **Update client code** to use `streamablehttp_client`，而唔係 SSE 客戶端。
3. **喺客戶端實現訊息處理器** 處理通知。
4. **測試同現有工具同工作流程嘅兼容性**。

### 保持兼容性

建議喺過渡期間保持同現有 SSE 客戶端兼容。策略包括：

- 同時支援 SSE 同 Streamable HTTP，分別喺唔同端點運行。
- 逐步遷移客戶端到新傳輸。

### 挑戰

過渡期間要處理以下挑戰：

- 確保所有客戶端都更新
- 處理通知傳送差異

### 練習：建立你自己嘅串流 MCP 應用

**場景：**  
建立一個 MCP 伺服器同客戶端，伺服器處理一系列項目（例如檔案或文件），並為每個處理完成嘅項目發送通知。客戶端應即時顯示每條通知。

**步驟：**

1. 實現伺服器工具，處理列表並為每項發送通知。
2. 實現客戶端訊息處理器，實時顯示通知。
3. 測試伺服器同客戶端，觀察通知效果。

[Solution](./solution/README.md)

## 延伸閱讀同下一步？

想繼續深入 MCP 串流，擴展知識，本節提供額外資源同建議下一步做法，幫你建立更進階嘅應用。

### 延伸閱讀

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 下一步？

- 試下建立更進階嘅 MCP 工具，用串流做實時分析、聊天或者協作編輯。
- 探索將 MCP 串流同前端框架（React、Vue 等）整合，實現 UI 實時更新。
- 下一章：[Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我們致力於提供準確的翻譯，但請注意自動翻譯可能存在錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用此翻譯而引起的任何誤解或誤釋承擔責任。