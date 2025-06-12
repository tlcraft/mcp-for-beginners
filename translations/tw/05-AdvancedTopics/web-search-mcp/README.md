<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:01:10+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "tw"
}
-->
# Lesson: 建立一個 Web 搜尋 MCP 伺服器

本章示範如何打造一個整合外部 API、處理多種資料類型、管理錯誤，並協調多種工具的實務 AI 代理伺服器，且具備生產環境可用的架構。你將會看到：

- **整合需要驗證的外部 API**
- **處理來自多個端點的多樣資料類型**
- **穩健的錯誤處理與日誌策略**
- **單一伺服器中多工具的協調運作**

結束後，你將擁有應用於進階 AI 與大型語言模型（LLM）應用的實務經驗與設計模式。

## 介紹

在本課程中，你將學會如何建立一個進階的 MCP 伺服器與客戶端，利用 SerpAPI 將即時網路資料擴充 LLM 的能力。這是打造能夠存取最新網路資訊的動態 AI 代理的重要技能。

## 學習目標

完成本課程後，你將能夠：

- 安全地整合外部 API（例如 SerpAPI）到 MCP 伺服器
- 實作多種工具，涵蓋網頁、新聞、商品搜尋及問答功能
- 解析並格式化結構化資料以供 LLM 使用
- 有效處理錯誤與管理 API 請求速率限制
- 建置並測試自動化及互動式 MCP 客戶端

## Web 搜尋 MCP 伺服器

本節介紹 Web 搜尋 MCP 伺服器的架構與功能，展示如何結合 FastMCP 與 SerpAPI，將即時網路資料擴充 LLM 的能力。

### 概述

本實作包含四個工具，展現 MCP 在安全且高效處理多樣外部 API 任務的能力：

- **general_search**：提供廣泛的網頁搜尋結果
- **news_search**：搜尋最新新聞標題
- **product_search**：搜尋電子商務商品資料
- **qna**：提供問答摘要

### 功能特色
- **程式碼範例**：包含針對 Python（且易於擴充到其他語言）的語言專屬程式碼區塊，並使用可折疊區塊以提升閱讀清晰度

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

在執行客戶端之前，了解伺服器的運作方式會很有幫助。請參考 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

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

- **外部 API 整合**：示範如何安全地處理 API 金鑰與外部請求
- **結構化資料解析**：展示如何將 API 回應轉換為適合 LLM 使用的格式
- **錯誤處理**：具備完善的錯誤處理與適當的日誌紀錄
- **互動式客戶端**：包含自動化測試及互動模式供測試使用
- **上下文管理**：利用 MCP Context 進行日誌與請求追蹤

## 先決條件

開始前，請確保你的環境已正確設定，依照以下步驟安裝所有相依套件並設定 API 金鑰，以確保開發與測試流程順暢。

- Python 3.8 或以上版本
- SerpAPI API 金鑰（可於 [SerpAPI](https://serpapi.com/) 註冊，提供免費方案）

## 安裝

請依照以下步驟設定你的環境：

1. 使用 uv（推薦）或 pip 安裝相依套件：

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. 在專案根目錄建立 `.env` 檔，填入你的 SerpAPI 金鑰：

```
SERPAPI_KEY=your_serpapi_key_here
```

## 使用說明

Web 搜尋 MCP 伺服器是核心元件，透過整合 SerpAPI，提供網頁、新聞、商品搜尋與問答等工具。它負責接收請求、管理 API 呼叫、解析回應，並回傳結構化結果給客戶端。

完整實作可參考 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)。

### 啟動伺服器

啟動 MCP 伺服器請使用以下指令：

```bash
python server.py
```

伺服器將以 stdio 為基礎的 MCP 伺服器運行，客戶端可直接連線。

### 客戶端模式

客戶端程式為 (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)。

### 執行客戶端

執行自動化測試（此操作會自動啟動伺服器）：

```bash
python client.py
```

或以互動模式執行：

```bash
python client.py --interactive
```

### 使用不同方式測試

依照你的需求與工作流程，有多種方式測試與互動伺服器提供的工具。

#### 使用 MCP Python SDK 撰寫自訂測試腳本
你也可以用 MCP Python SDK 自行撰寫測試腳本：

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

在這裡，「測試腳本」指的是你撰寫的自訂 Python 程式，作為 MCP 伺服器的客戶端。它不是正式的單元測試，而是讓你程式化地連接伺服器、呼叫任一工具並檢視結果。這種方式適合用於：
- 快速原型與工具呼叫實驗
- 驗證伺服器對不同輸入的反應
- 自動化重複的工具呼叫
- 建立你自己的工作流程或整合

測試腳本可用來快速嘗試新查詢、除錯工具行為，甚至作為進階自動化的起點。以下是使用 MCP Python SDK 建立此類腳本的範例：

## 工具說明

伺服器提供以下工具，協助你執行不同類型的搜尋與查詢。每個工具說明包含其參數與使用範例。

本節提供各工具及其參數的詳細說明。

### general_search

執行一般網頁搜尋並回傳格式化結果。

**如何呼叫此工具：**

你可以使用 MCP Python SDK 從自己的腳本呼叫 `general_search`，或透過 Inspector 及互動式客戶端模式使用。以下為 SDK 的程式範例：

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

或在互動模式中選擇 `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字串）：搜尋關鍵字

**範例請求：**

```json
{
  "query": "latest AI trends"
}
```

### news_search

搜尋與查詢相關的最新新聞文章。

**如何呼叫此工具：**

你可以使用 MCP Python SDK 從自己的腳本呼叫 `news_search`，或透過 Inspector 及互動式客戶端模式使用。以下為 SDK 的程式範例：

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

或在互動模式中選擇 `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字串）：搜尋關鍵字

**範例請求：**

```json
{
  "query": "AI policy updates"
}
```

### product_search

搜尋符合查詢條件的商品。

**如何呼叫此工具：**

你可以使用 MCP Python SDK 從自己的腳本呼叫 `product_search`，或透過 Inspector 及互動式客戶端模式使用。以下為 SDK 的程式範例：

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

或在互動模式中選擇 `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字串）：商品搜尋關鍵字

**範例請求：**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

從搜尋引擎取得直接的問題答案。

**如何呼叫此工具：**

你可以使用 MCP Python SDK 從自己的腳本呼叫 `qna`，或透過 Inspector 及互動式客戶端模式使用。以下為 SDK 的程式範例：

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

或在互動模式中選擇 `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question`（字串）：欲查詢的問題

**範例請求：**

```json
{
  "question": "what is artificial intelligence"
}
```

## 程式碼細節

本節提供伺服器與客戶端實作的程式碼片段與參考。

<details>
<summary>Python</summary>

完整實作請參考 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)。

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## 本課程中的進階概念

開始建置之前，這裡列出本章會用到的一些重要進階概念。了解它們有助於你更順利跟上內容，即使你對這些概念還不熟悉：

- **多工具協調運作**：指在同一 MCP 伺服器中同時執行多種不同工具（如網頁搜尋、新聞搜尋、商品搜尋與問答），讓伺服器能處理多樣任務，而非僅限單一功能。
- **API 請求速率限制處理**：許多外部 API（如 SerpAPI）會限制你在一定時間內可發出的請求數量。良好的程式碼會檢查這些限制並優雅處理，避免應用程式因超過限制而崩潰。
- **結構化資料解析**：API 回應通常複雜且巢狀，這個概念是將回應轉換成乾淨、易用的格式，方便 LLM 或其他程式使用。
- **錯誤恢復**：有時會發生問題，例如網路失敗或 API 回應異常。錯誤恢復代表你的程式能處理這些狀況並提供有用的回饋，而非崩潰。
- **參數驗證**：檢查傳入工具的所有輸入是否正確且安全使用，包括設定預設值與型別檢查，幫助防止錯誤與混淆。

本節將協助你診斷與解決在使用 Web 搜尋 MCP 伺服器時可能遇到的常見問題。遇到錯誤或異常行為時，請先參考這裡的解決方案，通常能快速解決問題。

## 疑難排解

使用 Web 搜尋 MCP 伺服器時，偶爾會遇到問題——這在開發整合外部 API 與新工具時很正常。本節提供實用解決方案，協助你快速恢復正常。如果你遇到錯誤，請從這裡開始查找：以下提示涵蓋大部分使用者常見的問題，通常能在不需額外協助的情況下解決。

### 常見問題

以下列出使用者最常碰到的問題，並附上清楚的說明與解決步驟：

1. **.env 檔缺少 SERPAPI_KEY**
   - 若你看到錯誤訊息 `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``，請確認 `.env` 檔存在且已填入正確的 SERPAPI_KEY。若金鑰無誤但仍出錯，請檢查免費方案配額是否已用盡。

### 除錯模式

預設情況下，應用只會記錄重要資訊。如果你想查看更詳細的執行情況（例如診斷複雜問題），可以啟用 DEBUG 模式。這會顯示更多關於每個步驟的資訊。

**範例：一般輸出**
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

你會發現 DEBUG 模式包含更多 HTTP 請求、回應與其他內部細節，非常有助於疑難排解。

啟用 DEBUG 模式，請在 `client.py` or `server.py` 頂端設定日誌等級為 DEBUG：

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

## 接下來的內容

- [5.10 即時串流](../mcp-realtimestreaming/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們不對因使用本翻譯而產生之任何誤解或誤釋負責。