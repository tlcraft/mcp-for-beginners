<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:05:12+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "hk"
}
-->
# Lesson: 建立網頁搜尋 MCP 伺服器

本章示範如何建立一個實際應用的 AI 代理，整合外部 API，處理多種資料類型，管理錯誤，並協調多個工具——全部以生產環境準備好的形式呈現。你將看到：

- **整合需要驗證的外部 API**
- **處理來自多個端點的多樣資料類型**
- **穩健的錯誤處理與日誌策略**
- **單一伺服器中多工具協調**

完成後，你將擁有實務經驗，掌握先進 AI 和大型語言模型應用的模式與最佳實踐。

## 介紹

這課程會教你如何建立一個進階的 MCP 伺服器和客戶端，利用 SerpAPI 將即時網頁資料擴充 LLM 功能。這是開發能存取最新網路資訊的動態 AI 代理的重要技能。

## 學習目標

完成本課後，你將能夠：

- 安全地將外部 API（如 SerpAPI）整合到 MCP 伺服器
- 實作多種工具，包含網頁、新聞、產品搜尋及問答
- 解析並格式化結構化資料供 LLM 使用
- 有效處理錯誤與管理 API 限流
- 建立並測試自動化及互動式 MCP 客戶端

## 網頁搜尋 MCP 伺服器

本節介紹網頁搜尋 MCP 伺服器的架構與功能。你會看到 FastMCP 和 SerpAPI 如何結合，擴展 LLM 的即時網頁資料能力。

### 概述

此實作包含四個工具，展示 MCP 如何安全且高效地處理多樣且由外部 API 驅動的任務：

- **general_search**：廣泛的網頁搜尋
- **news_search**：最新新聞標題搜尋
- **product_search**：電商產品資料搜尋
- **qna**：問答片段搜尋

### 功能
- **程式碼範例**：包含語言專用的程式碼區塊（以 Python 為例，且易擴充至其他語言），使用可摺疊區塊提升清晰度

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

在執行客戶端前，了解伺服器做什麼會很有幫助。請參考 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

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

- **外部 API 整合**：示範如何安全管理 API 金鑰與外部請求
- **結構化資料解析**：示範如何將 API 回應轉換為適合 LLM 使用的格式
- **錯誤處理**：強健的錯誤管理與適當日誌紀錄
- **互動式客戶端**：包含自動化測試與互動模式
- **上下文管理**：利用 MCP Context 進行日誌與請求追蹤

## 前置作業

開始前，請確保你的開發環境已正確設定。完成以下步驟能確保所有相依套件安裝完成，且 API 金鑰配置無誤，方便後續開發與測試。

- Python 3.8 或以上
- SerpAPI API 金鑰（可在 [SerpAPI](https://serpapi.com/) 註冊，提供免費方案）

## 安裝

請依下列步驟設定你的環境：

1. 使用 uv（推薦）或 pip 安裝相依套件：

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. 在專案根目錄建立 `.env` 檔案，填入你的 SerpAPI 金鑰：

```
SERPAPI_KEY=your_serpapi_key_here
```

## 使用說明

網頁搜尋 MCP 伺服器是核心元件，透過整合 SerpAPI 提供網頁、新聞、產品搜尋及問答工具。它負責處理請求、管理 API 呼叫、解析回應，並將結構化結果回傳給客戶端。

完整實作可參考 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)。

### 啟動伺服器

啟動 MCP 伺服器，請使用以下指令：

```bash
python server.py
```

伺服器將以 stdio 為基礎，讓客戶端能直接連線。

### 客戶端模式

客戶端程式為 [`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)。

### 執行客戶端

執行自動化測試（會自動啟動伺服器）：

```bash
python client.py
```

或以互動模式執行：

```bash
python client.py --interactive
```

### 不同測試方法

根據你的需求和工作流程，有多種方式可測試和互動伺服器提供的工具。

#### 使用 MCP Python SDK 撰寫自訂測試腳本
你也可以用 MCP Python SDK 撰寫自訂測試腳本：

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

這裡的「測試腳本」是指你寫的自訂 Python 程式，當作 MCP 伺服器的客戶端。它不是正式的單元測試，而是讓你能程式化地連接伺服器，呼叫任何工具並帶入參數，檢查結果。這方法適合：

- 快速原型與工具呼叫試驗
- 驗證伺服器對不同輸入的回應
- 自動化重複工具呼叫
- 建立自己的工作流程或整合方案

你可以用測試腳本快速嘗試新查詢、除錯工具行為，或作為進階自動化的起點。以下是使用 MCP Python SDK 建立此類腳本的範例：

## 工具說明

伺服器提供以下工具，用於不同類型的搜尋與查詢。以下描述每個工具的參數及使用範例。

本節提供各工具及其參數的詳細說明。

### general_search

執行一般網頁搜尋並回傳格式化結果。

**如何呼叫此工具：**

你可以用 MCP Python SDK 從自己的程式呼叫 `general_search`，或在 Inspector 或互動客戶端模式中操作。以下是 SDK 範例：

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

另外，在互動模式中，選擇 `general_search` from the menu and enter your query when prompted.

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

你可以用 MCP Python SDK 從自己的程式呼叫 `news_search`，或在 Inspector 或互動客戶端模式中操作。以下是 SDK 範例：

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

另外，在互動模式中，選擇 `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字串）：搜尋關鍵字

**範例請求：**

```json
{
  "query": "AI policy updates"
}
```

### product_search

搜尋符合查詢的產品。

**如何呼叫此工具：**

你可以用 MCP Python SDK 從自己的程式呼叫 `product_search`，或在 Inspector 或互動客戶端模式中操作。以下是 SDK 範例：

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

另外，在互動模式中，選擇 `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字串）：產品搜尋關鍵字

**範例請求：**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

取得搜尋引擎直接回答的問題答案。

**如何呼叫此工具：**

你可以用 MCP Python SDK 從自己的程式呼叫 `qna`，或在 Inspector 或互動客戶端模式中操作。以下是 SDK 範例：

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

另外，在互動模式中，選擇 `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question`（字串）：要尋找答案的問題

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

完整實作詳見 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)。

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## 本課的進階概念

開始建置前，這裡介紹一些本章會經常出現的重要進階概念。理解它們能幫助你更順利跟上，即使你是第一次接觸：

- **多工具協調**：指在單一 MCP 伺服器中同時執行多種工具（如網頁搜尋、新聞搜尋、產品搜尋及問答）。這讓伺服器能處理多元任務，而非單一功能。
- **API 限流管理**：許多外部 API（如 SerpAPI）限制你在一定時間內的請求數。良好程式會檢查這些限制並優雅處理，避免應用崩潰。
- **結構化資料解析**：API 回應常常複雜且巢狀。這個概念是將回應轉成乾淨、易用且對 LLM 或其他程式友善的格式。
- **錯誤復原**：有時會發生問題——例如網路故障或 API 回應異常。錯誤復原指你的程式能處理這些狀況並給出有用回饋，而非崩潰。
- **參數驗證**：檢查工具輸入是否正確且安全使用，包括設定預設值與確保型別正確，幫助避免錯誤與混淆。

本節將協助你診斷並解決使用網頁搜尋 MCP 伺服器時常見的問題。遇到錯誤或意外行為時，先參考這裡的解決方案，通常能快速排除問題。

## 疑難排解

使用網頁搜尋 MCP 伺服器時，偶爾會遇到問題——這在開發整合外部 API 和新工具時很常見。本節提供常見問題的實用解決方案，助你快速回到正軌。遇到錯誤時，請從這裡開始：以下建議針對多數使用者面臨的問題，常能無需額外協助就解決。

### 常見問題

以下列出使用者常遇的問題，並附上清楚解釋與解決步驟：

1. **.env 檔缺少 SERPAPI_KEY**
   - 若看到錯誤 `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``，請確認 `.env` 檔存在且正確填寫金鑰。如果金鑰無誤但仍出錯，檢查免費方案配額是否已用盡。

### 除錯模式

預設情況下，應用只會記錄重要資訊。若你想看到更多細節（例如診斷棘手問題），可以開啟 DEBUG 模式。這會顯示更多關於每個步驟的資訊。

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

注意 DEBUG 模式會額外顯示 HTTP 請求、回應及其他內部細節，對於排錯非常有幫助。

要啟用 DEBUG 模式，請在 `client.py` or `server.py` 頂部設定日誌等級為 DEBUG：

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

- [6. 社群貢獻](../../06-CommunityContributions/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我哋致力保持準確性，但請注意自動翻譯可能會有錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資料，建議採用專業人手翻譯。因使用本翻譯而引致嘅任何誤解或錯誤詮釋，我哋概不負責。