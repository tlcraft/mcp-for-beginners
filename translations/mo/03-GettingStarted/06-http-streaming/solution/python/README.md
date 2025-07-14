<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:17:29+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "mo"
}
-->
# 執行此範例

以下說明如何使用 Python 執行經典的 HTTP 串流伺服器與客戶端，以及 MCP 串流伺服器與客戶端。

### 概覽

- 您將設定一個 MCP 伺服器，在處理項目時向客戶端串流進度通知。
- 客戶端會即時顯示每則通知。
- 本指南涵蓋前置需求、設定、執行與故障排除。

### 前置需求

- Python 3.9 或更新版本
- `mcp` Python 套件（使用 `pip install mcp` 安裝）

### 安裝與設定

1. 複製儲存庫或下載解決方案檔案。

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

1. **安裝所需依賴：**

   ```pwsh
   pip install "mcp[cli]"
   ```

### 檔案

- **伺服器：** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **客戶端：** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### 執行經典 HTTP 串流伺服器

1. 切換到解決方案目錄：

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

2. 您會看到串流訊息依序列印：

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

1. 切換到解決方案目錄：
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
2. 當伺服器處理每個項目時，您會即時看到通知列印出來：
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
2. **定義一個工具，處理清單並使用 `ctx.info()` 或 `ctx.log()` 發送通知。**
3. **以 `transport="streamable-http"` 執行伺服器。**
4. **實作客戶端，使用訊息處理器即時顯示通知。**

### 程式碼導覽
- 伺服器使用非同步函式與 MCP 上下文發送進度更新。
- 客戶端實作非同步訊息處理器，列印通知與最終結果。

### 小技巧與故障排除

- 使用 `async/await` 以避免阻塞操作。
- 伺服器與客戶端皆應妥善處理例外，提升穩定性。
- 可用多個客戶端測試，觀察即時更新效果。
- 若遇錯誤，請確認 Python 版本並確保所有依賴已安裝。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。