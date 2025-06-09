<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:31:34+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "hk"
}
-->
# Lesson: 建立一個網頁搜尋 MCP 伺服器

本章示範如何建立一個實際運作的 AI 代理，結合外部 API、處理多種資料類型、管理錯誤，以及協調多個工具——全部以生產環境可用的格式呈現。你將會看到：

- **整合需要驗證的外部 API**
- **處理來自多個端點的多樣化資料類型**
- **穩健的錯誤處理與記錄策略**
- **單一伺服器中多工具協調運作**

完成後，你將擁有實務經驗，掌握對進階 AI 及大型語言模型（LLM）應用至關重要的設計模式與最佳實踐。

## 介紹

這堂課會教你如何建立一個先進的 MCP 伺服器與客戶端，利用 SerpAPI 即時擴展 LLM 的網頁資料能力。這是開發能從網路取得最新資訊的動態 AI 代理的重要技能。

## 學習目標

完成本課程後，你將能：

- 安全地將外部 API（如 SerpAPI）整合到 MCP 伺服器中
- 實作多個工具來進行網頁、新聞、商品搜尋及問答
- 解析並格式化結構化資料以供 LLM 使用
- 有效處理錯誤並管理 API 請求速率限制
- 建立並測試自動化及互動式 MCP 客戶端

## 網頁搜尋 MCP 伺服器

本節介紹網頁搜尋 MCP 伺服器的架構與功能。你會看到 FastMCP 與 SerpAPI 如何結合，為 LLM 擴展即時網路資料能力。

### 概述

此實作包含四個工具，展示 MCP 如何安全且高效地處理多樣化、外部 API 驅動的任務：

- **general_search**：廣泛的網頁搜尋
- **news_search**：最新新聞標題搜尋
- **product_search**：電子商務商品搜尋
- **qna**：問答片段搜尋

### 功能
- **程式碼範例**：包含 Python 的語言特定程式碼區塊（並可輕鬆擴展到其他語言），使用可摺疊區塊方便閱讀

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

在執行客戶端之前，了解伺服器做了什麼會很有幫助。請參考 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

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

- **外部 API 整合**：示範安全處理 API 金鑰與外部請求
- **結構化資料解析**：展示如何將 API 回應轉成 LLM 友好的格式
- **錯誤處理**：具備完善的錯誤處理與適當的記錄
- **互動式客戶端**：包含自動化測試及互動模式
- **上下文管理**：利用 MCP Context 進行日誌記錄與請求追蹤

## 先決條件

開始前，請確保你的環境已正確設定，依照以下步驟安裝所有相依套件，並妥善設定 API 金鑰，以確保開發與測試順利。

- Python 3.8 或以上版本
- SerpAPI API Key（可在 [SerpAPI](https://serpapi.com/) 註冊，免費方案可用）

## 安裝

開始前，請依照以下步驟設定環境：

1. 使用 uv（推薦）或 pip 安裝相依套件：

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

網頁搜尋 MCP 伺服器是核心元件，透過整合 SerpAPI 提供網頁、新聞、商品搜尋及問答工具。它負責處理進來的請求、管理 API 呼叫、解析回應，並回傳結構化結果給客戶端。

完整實作請參考 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)。

### 啟動伺服器

啟動 MCP 伺服器，請使用以下指令：

```bash
python server.py
```

伺服器會以 stdio 為基礎運作，客戶端可直接連線。

### 客戶端模式

客戶端（`client.py`) supports two modes for interacting with the MCP server:

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

### 使用不同方式測試

根據需求與工作流程，有多種方法可測試與互動伺服器提供的工具。

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

此處的「測試腳本」指的是你寫的 Python 程式，作為 MCP 伺服器的客戶端。它不是正式的單元測試，而是讓你程式化連接伺服器，呼叫任意工具並檢視結果。這種方法適合用來：

- 原型設計及試驗工具呼叫
- 驗證伺服器對不同輸入的回應
- 自動化重複的工具呼叫
- 建立你自己的工作流程或整合 MCP 伺服器

測試腳本可快速嘗試新查詢、除錯工具行為，甚至作為進階自動化的起點。以下是使用 MCP Python SDK 建立此類腳本的範例：

## 工具說明

你可以使用伺服器提供的以下工具，執行不同類型的搜尋與查詢。每個工具均附有參數與範例用法說明。

本節詳述各工具及其參數。

### general_search

執行一般網頁搜尋並回傳格式化結果。

**如何呼叫此工具：**

你可以用 MCP Python SDK 從自己的腳本呼叫 `general_search`，或透過 Inspector 或互動式客戶端模式操作。以下是 SDK 的程式碼範例：

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

或者，在互動模式中，選擇 `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字串）：搜尋查詢字串

**範例請求：**

```json
{
  "query": "latest AI trends"
}
```

### news_search

搜尋與查詢相關的最新新聞文章。

**如何呼叫此工具：**

你可以用 MCP Python SDK 從自己的腳本呼叫 `news_search`，或透過 Inspector 或互動式客戶端模式操作。以下是 SDK 的程式碼範例：

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

或者，在互動模式中，選擇 `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字串）：搜尋查詢字串

**範例請求：**

```json
{
  "query": "AI policy updates"
}
```

### product_search

搜尋符合查詢的商品。

**如何呼叫此工具：**

你可以用 MCP Python SDK 從自己的腳本呼叫 `product_search`，或透過 Inspector 或互動式客戶端模式操作。以下是 SDK 的程式碼範例：

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

或者，在互動模式中，選擇 `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（字串）：商品搜尋查詢字串

**範例請求：**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

從搜尋引擎取得直接的問題答案。

**如何呼叫此工具：**

你可以用 MCP Python SDK 從自己的腳本呼叫 `qna`，或透過 Inspector 或互動式客戶端模式操作。以下是 SDK 的程式碼範例：

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

或者，在互動模式中，選擇 `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question`（字串）：要查找答案的問題

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

請參閱 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) 了解完整實作細節。

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## 本課的進階概念

開始建置前，這裡列出本章將會出現的重要進階概念。理解這些有助於你跟上內容，即使你是初學者：

- **多工具協調**：指在單一 MCP 伺服器中同時運行多種不同工具（如網頁搜尋、新聞搜尋、商品搜尋和問答）。這讓伺服器能處理多元任務，而非只限於一項。
- **API 請求速率限制處理**：許多外部 API（例如 SerpAPI）會限制你在特定時間內能發出的請求數量。良好的程式會檢查這些限制並妥善處理，避免應用程式因超出限制而崩潰。
- **結構化資料解析**：API 回應常常結構複雜且巢狀。這個概念是將回應轉換成乾淨且易用的格式，方便 LLM 或其他程式使用。
- **錯誤復原**：有時會發生錯誤，例如網路失敗或 API 回應不如預期。錯誤復原指程式能處理這些問題並給出有用的反饋，而不是直接崩潰。
- **參數驗證**：檢查工具輸入是否正確且安全使用，包括設定預設值與確認類型正確，幫助避免錯誤與混淆。

本節也協助你診斷與解決使用網頁搜尋 MCP 伺服器時常見的問題。如果遇到錯誤或異常行為，這裡的排錯建議通常能快速解決問題，讓你免於尋求額外協助。

## 排錯指南

使用網頁搜尋 MCP 伺服器時，偶爾會遇到問題——這在開發外部 API 與新工具時很常見。本節提供實用解決方案，幫助你快速恢復正常。遇到錯誤時，建議從這裡開始：以下提示針對使用者最常碰到的問題，通常能幫你迅速解決。

### 常見問題

以下列出使用者最常遇到的問題，並附上清楚說明與解決步驟：

1. **.env 檔缺少 SERPAPI_KEY**
   - 若看到錯誤 `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``，請確認 `.env` 檔存在且正確設定。如果金鑰無誤但仍有錯誤，請確認免費方案配額是否已用盡。

### 除錯模式

預設情況下，應用只會記錄重要資訊。若想查看更詳細的運作狀態（例如診斷複雜問題），可啟用 DEBUG 模式。這會顯示更多每一步驟的細節。

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

可見 DEBUG 模式會額外列出 HTTP 請求、回應及其他內部細節，對排錯非常有幫助。

要啟用 DEBUG 模式，請在 `client.py` or `server.py` 頂部將記錄層級設為 DEBUG：

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
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原文文件以其母語版本為權威來源。對於重要資訊，建議採用專業人工翻譯。對於因使用本翻譯而引起嘅任何誤解或誤釋，本公司概不負責。