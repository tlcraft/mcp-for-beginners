<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T14:58:13+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "hk"
}
-->
# Lesson: 建立一個網頁搜尋 MCP 伺服器

本章展示如何建立一個真實世界的 AI 代理，能整合外部 API、處理多元資料類型、管理錯誤，並協調多個工具——全部以生產環境可用的格式。你將會看到：

- **整合需要驗證的外部 API**
- **處理來自多個端點的多樣資料類型**
- **穩健的錯誤處理及日誌策略**
- **在單一伺服器中協調多個工具**

到最後，你將擁有實務經驗，掌握進階 AI 及 LLM 應用的設計模式和最佳實務。

## 介紹

這課程中，你會學到如何建立一個進階的 MCP 伺服器和客戶端，利用 SerpAPI 將 LLM 能力擴展到即時網路資料。這是開發能夠存取最新網路資訊的動態 AI 代理的重要技能。

## 學習目標

完成本課程後，你將能夠：

- 安全地將外部 API（如 SerpAPI）整合到 MCP 伺服器
- 實作多種工具，包括網頁、新聞、產品搜尋及問答
- 解析並格式化結構化資料供 LLM 使用
- 有效處理錯誤和管理 API 請求速率限制
- 建立並測試自動化和互動式 MCP 客戶端

## 網頁搜尋 MCP 伺服器

本節介紹網頁搜尋 MCP 伺服器的架構與功能。你會看到 FastMCP 和 SerpAPI 如何結合，將 LLM 能力擴展至即時網路資料。

### 概覽

這個實作包含四個工具，展示 MCP 安全且有效處理多元外部 API 任務的能力：

- **general_search**：用於廣泛的網頁搜尋結果
- **news_search**：用於最新新聞標題
- **product_search**：用於電子商務產品資料
- **qna**：用於問答片段

### 功能
- **程式碼範例**：包含針對 Python（且易於擴展至其他語言）的語言特定程式碼區塊，使用可摺疊區塊提升清晰度

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

在執行客戶端前，先了解伺服器的運作很有幫助。請參考 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)。

以下是伺服器如何定義並註冊工具的簡短範例：

<details>  
<summary>Python Server</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **外部 API 整合**：示範如何安全處理 API 金鑰和外部請求
- **結構化資料解析**：展示如何將 API 回應轉換成 LLM 友善格式
- **錯誤處理**：健全的錯誤處理與適當日誌記錄
- **互動式客戶端**：包含自動化測試與互動模式
- **上下文管理**：利用 MCP Context 進行日誌記錄與請求追蹤

## 先決條件

開始前，請確認環境已正確設定，完成以下步驟。這能確保所有依賴已安裝，API 金鑰配置無誤，方便開發與測試。

- Python 3.8 或以上版本
- SerpAPI API 金鑰（可至 [SerpAPI](https://serpapi.com/) 註冊，免費方案可用）

## 安裝

請依照以下步驟設定你的環境：

1. 使用 uv（推薦）或 pip 安裝依賴：

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. 在專案根目錄建立 `.env` 檔案，放入你的 SerpAPI 金鑰：

```
SERPAPI_KEY=your_serpapi_key_here
```

## 使用說明

網頁搜尋 MCP 伺服器是核心元件，透過整合 SerpAPI，提供網頁、新聞、產品搜尋及問答工具。它負責接收請求、管理 API 呼叫、解析回應，並回傳結構化結果給客戶端。

你可以查看完整實作於 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)。

### 啟動伺服器

啟動 MCP 伺服器，使用以下指令：

```bash
python server.py
```

伺服器將以 stdio 為基礎運行，客戶端可直接連接。

### 客戶端模式

客戶端（`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)）。

### 執行客戶端

執行自動化測試（會自動啟動伺服器）：

```bash
python client.py
```

或以互動模式運行：

```bash
python client.py --interactive
```

### 以不同方式測試

依照你的需求與工作流程，有多種方法測試和互動伺服器提供的工具。

#### 使用 MCP Python SDK 撰寫自訂測試腳本
你也可以用 MCP Python SDK 撰寫自己的測試腳本：

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

在此情境中，「測試腳本」指的是你寫的自訂 Python 程式，作為 MCP 伺服器的客戶端。它不是正式的單元測試，而是讓你程式化連接伺服器、呼叫任一工具並檢視結果。這方法適合：

- 原型開發及工具呼叫實驗
- 驗證伺服器對不同輸入的反應
- 自動化重複工具呼叫
- 建立自訂工作流程或整合 MCP 伺服器

你可以用測試腳本快速嘗試新查詢、除錯工具行為，甚至作為更進階自動化的起點。以下是使用 MCP Python SDK 建立此類腳本的範例：

## 工具說明

伺服器提供以下工具來執行不同類型的搜尋和查詢。每個工具的參數及使用範例說明如下。

本節詳細介紹各工具及其參數。

### general_search

執行一般網頁搜尋並回傳格式化結果。

**如何呼叫此工具：**

你可以透過 MCP Python SDK 從自己的腳本呼叫 `general_search`，或使用 Inspector 或互動式客戶端模式。以下是使用 SDK 的程式碼範例：

<details>
<summary>Python 範例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

或者在互動模式下，選擇 `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string)：搜尋關鍵字

**請求範例：**

```json
{
  "query": "latest AI trends"
}
```

### news_search

搜尋與查詢相關的最新新聞文章。

**如何呼叫此工具：**

你可以透過 MCP Python SDK 從自己的腳本呼叫 `news_search`，或使用 Inspector 或互動式客戶端模式。以下是使用 SDK 的程式碼範例：

<details>
<summary>Python 範例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

或者在互動模式下，選擇 `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string)：搜尋關鍵字

**請求範例：**

```json
{
  "query": "AI policy updates"
}
```

### product_search

搜尋符合查詢條件的產品。

**如何呼叫此工具：**

你可以透過 MCP Python SDK 從自己的腳本呼叫 `product_search`，或使用 Inspector 或互動式客戶端模式。以下是使用 SDK 的程式碼範例：

<details>
<summary>Python 範例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

或者在互動模式下，選擇 `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string)：產品搜尋關鍵字

**請求範例：**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

取得搜尋引擎的直接問答回覆。

**如何呼叫此工具：**

你可以透過 MCP Python SDK 從自己的腳本呼叫 `qna`，或使用 Inspector 或互動式客戶端模式。以下是使用 SDK 的程式碼範例：

<details>
<summary>Python 範例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

或者在互動模式下，選擇 `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string)：要尋找答案的問題

**請求範例：**

```json
{
  "question": "what is artificial intelligence"
}
```

## 程式碼細節

本節提供伺服器和客戶端實作的程式碼片段和參考。

<details>
<summary>Python</summary>

完整實作請見 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)。

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## 本課程中的進階概念

開始動手前，這裡列出一些本章會出現的重要進階概念。理解它們能幫助你跟上內容，即使你是第一次接觸：

- **多工具協調**：在單一 MCP 伺服器內同時運行多個不同工具（如網頁搜尋、新聞搜尋、產品搜尋和問答），讓伺服器能處理多樣任務，而非只限於單一功能。
- **API 請求速率限制管理**：許多外部 API（如 SerpAPI）會限制一定時間內的請求數。良好程式會檢查這些限制並妥善處理，避免當觸及限制時應用崩潰。
- **結構化資料解析**：API 回應通常複雜且巢狀。本概念是將這些回應轉換成乾淨、易用且對 LLM 或其他程式友善的格式。
- **錯誤復原**：有時候會出錯——可能是網路故障，或 API 回應不如預期。錯誤復原意味著程式能處理這些問題並提供有用回饋，而非崩潰。
- **參數驗證**：確保所有工具輸入都正確且安全使用，包括設定預設值和檢查類型，有助於避免錯誤和混淆。

本節將幫助你診斷並解決在使用網頁搜尋 MCP 伺服器時可能遇到的常見問題。若遇錯誤或異常行為，先參考這裡的排錯建議，通常能快速解決問題。

## 排錯指南

使用網頁搜尋 MCP 伺服器時，偶爾會遇到問題——這在開發使用外部 API 和新工具時很常見。本節提供實用解決方案，幫你快速回到正軌。遇到錯誤時，請先從這裡開始：以下建議針對大部分使用者常見問題，通常能免去額外求助。

### 常見問題

以下是使用者最常遇到的問題，附上清楚解釋及解決步驟：

1. **.env 檔案缺少 SERPAPI_KEY**
   - 若看到錯誤 `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``，請檢查是否有 `.env` 檔案，並確認 SERPAPI_KEY 是否正確。如果金鑰無誤但仍出錯，請確認免費方案是否已用盡配額。

### 除錯模式

預設情況下，應用程式只記錄重要資訊。如果你想看到更多細節（例如診斷複雜問題），可以啟用 DEBUG 模式。這會顯示更多關於每個步驟的資訊。

**範例：正常輸出**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**範例：DEBUG 輸出**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

注意 DEBUG 模式會包含更多 HTTP 請求、回應及其他內部細節，對排錯非常有幫助。

啟用 DEBUG 模式，請在 `client.py` or `server.py` 頂部設定日誌等級為 DEBUG：

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## 下一步

- [5.10 即時串流](../mcp-realtimestreaming/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原文文件的母語版本應視為權威來源。對於重要資料，建議採用專業人工翻譯。我們不對因使用此翻譯而產生的任何誤解或誤釋負責。