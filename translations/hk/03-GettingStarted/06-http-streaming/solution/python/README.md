<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-12T22:20:56+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "hk"
}
-->
# 運行呢個範例

以下係點樣用 Python 運行經典 HTTP 串流伺服器同客戶端，以及 MCP 串流伺服器同客戶端。

### 概覽

- 你會設定一個 MCP 伺服器，當處理項目時會串流進度通知俾客戶端。
- 客戶端會即時顯示每個通知。
- 呢份指南涵蓋先決條件、安裝、運行同故障排除。

### 先決條件

- Python 3.9 或更新版本
- `mcp` Python 套件（用 `pip install mcp` 安裝）

### 安裝同設定

1. 克隆倉庫或者下載方案檔案。

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **建立同啟動虛擬環境（建議）：**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **安裝所需依賴：**

   ```pwsh
   pip install "mcp[cli]"
   ```

### 檔案

- **伺服器：** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **客戶端：** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### 運行經典 HTTP 串流伺服器

1. 轉到方案目錄：

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. 啟動經典 HTTP 串流伺服器：

   ```pwsh
   python server.py
   ```

3. 伺服器會啟動並顯示：

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### 運行經典 HTTP 串流客戶端

1. 開啟新終端（啟動同一個虛擬環境同目錄）：

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. 你會見到串流訊息依次打印：

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### 運行 MCP 串流伺服器

1. 轉到方案目錄：
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. 用 streamable-http 傳輸啟動 MCP 伺服器：
   ```pwsh
   python server.py mcp
   ```
3. 伺服器會啟動並顯示：
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### 運行 MCP 串流客戶端

1. 開啟新終端（啟動同一個虛擬環境同目錄）：
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. 當伺服器處理每個項目時，你會即時見到通知打印：
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### 主要實現步驟

1. **用 FastMCP 建立 MCP 伺服器。**
2. **定義一個工具，處理列表並用 `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` 發送通知，做到非阻塞操作。**
- 喺伺服器同客戶端都要做好異常處理，確保穩定。
- 測試多個客戶端，觀察即時更新效果。
- 如果遇到錯誤，檢查 Python 版本同確保所有依賴都已安裝。

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。對因使用本翻譯而引起的任何誤解或誤釋，我們概不負責。