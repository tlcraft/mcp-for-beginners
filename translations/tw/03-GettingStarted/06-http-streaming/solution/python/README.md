<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-12T22:20:47+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "tw"
}
-->
# 執行這個範例

以下說明如何使用 Python 執行經典的 HTTP 串流伺服器與客戶端，以及 MCP 串流伺服器與客戶端。

### 概覽

- 你將設置一個 MCP 伺服器，在處理項目時向客戶端串流進度通知。
- 客戶端會即時顯示每則通知。
- 本指南涵蓋前置需求、設定、執行與疑難排解。

### 前置需求

- Python 3.9 或更新版本
- `mcp` Python 套件（使用 `pip install mcp` 安裝）

### 安裝與設定

1. 克隆儲存庫或下載解決方案檔案。

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **建立並啟用虛擬環境（建議）：**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **安裝必要的相依套件：**

   ```pwsh
   pip install "mcp[cli]"
   ```

### 檔案

- **伺服器：** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **客戶端：** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### 執行經典 HTTP 串流伺服器

1. 進入解決方案目錄：

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. 啟動經典 HTTP 串流伺服器：

   ```pwsh
   python server.py
   ```

3. 伺服器啟動後會顯示：

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### 執行經典 HTTP 串流客戶端

1. 開啟新終端機（啟用相同虛擬環境與目錄）：

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. 你會看到串流訊息依序列印出來：

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

### 執行 MCP 串流伺服器

1. 進入解決方案目錄：
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. 使用 streamable-http 傳輸啟動 MCP 伺服器：
   ```pwsh
   python server.py mcp
   ```
3. 伺服器啟動後會顯示：
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### 執行 MCP 串流客戶端

1. 開啟新終端機（啟用相同虛擬環境與目錄）：
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. 你會看到伺服器處理每個項目時，即時列印通知：
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

### 主要實作步驟

1. **使用 FastMCP 建立 MCP 伺服器。**
2. **定義一個工具，處理清單並使用 `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` 傳送通知，以實現非阻塞操作。**
- 伺服器與客戶端都要處理例外狀況以提升穩定性。
- 測試多個客戶端以觀察即時更新。
- 若遇錯誤，請檢查 Python 版本並確認所有相依套件已安裝。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所導致之任何誤解或誤譯負責。