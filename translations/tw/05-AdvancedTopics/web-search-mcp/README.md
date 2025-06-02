<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:05:51+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "tw"
}
-->
# Lesson: 建立一個 Web 搜尋 MCP 伺服器


本章展示如何建立一個真實世界的 AI 代理，整合外部 API、處理多種資料類型、管理錯誤，並協調多種工具——全部以生產環境準備的形式呈現。你將會看到：

- **整合需要驗證的外部 API**
- **處理來自多個端點的多樣資料類型**
- **健全的錯誤處理與日誌策略**
- **單一伺服器中多工具協調**

結束時，你將擁有實務經驗，掌握進階 AI 與 LLM 應用的模式與最佳實踐。

## 介紹

在本課程中，你將學習如何建立一個進階的 MCP 伺服器與客戶端，利用 SerpAPI 擴展 LLM 能力，結合即時網路資料。這是開發能存取最新網路資訊的動態 AI 代理的重要技能。

## 學習目標

完成本課程後，你將能夠：

- 安全地整合外部 API（例如 SerpAPI）到 MCP 伺服器中
- 實作多種工具：網路搜尋、新聞搜尋、產品搜尋與問答
- 解析並格式化結構化資料以供 LLM 使用
- 有效處理錯誤與管理 API 請求限制
- 建立並測試自動化及互動式 MCP 客戶端

## Web 搜尋 MCP 伺服器

本節介紹 Web 搜尋 MCP 伺服器的架構與功能。你會看到如何使用 FastMCP 與 SerpAPI 一起，擴展 LLM 能力，結合即時網路資料。

### 概覽

此實作包含四個工具，展示 MCP 安全且高效處理多樣外部 API 任務的能力：

- **general_search**：提供廣泛的網路搜尋結果
- **news_search**：提供最新新聞標題
- **product_search**：提供電子商務資料
- **qna**：提供問答片段

### 功能
- **程式碼範例**：包含 Python 的語言特定程式碼區塊（並可輕鬆擴充至其他語言），使用可摺疊區塊增加清晰度

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

- **外部 API 整合**：示範安全處理 API 金鑰與外部請求
- **結構化資料解析**：展示如何將 API 回應轉換成適合 LLM 的格式
- **錯誤處理**：健全的錯誤處理與適當的日誌記錄
- **互動式客戶端**：包含自動化測試與互動模式
- **上下文管理**：利用 MCP Context 進行日誌與請求追蹤

## 前置條件

開始前，請確認你的環境設定妥當，按照以下步驟確保所有相依套件安裝完成，且 API 金鑰已正確設定，方便開發與測試。

- Python 3.8 或以上版本
- SerpAPI API Key（可於 [SerpAPI](https://serpapi.com/) 註冊，提供免費方案）

## 安裝

開始前，請依照以下步驟設定你的環境：

1. 使用 uv（推薦）或 pip 安裝相依套件：

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. 在專案根目錄建立 `.env` 檔，放入你的 SerpAPI 金鑰：

```
SERPAPI_KEY=your_serpapi_key_here
```

## 使用說明

Web 搜尋 MCP 伺服器是核心元件，透過整合 SerpAPI，提供網路、新聞、產品搜尋與問答工具。它負責接收請求、管理 API 呼叫、解析回應，並回傳結構化結果給客戶端。

完整實作可參考 [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)。

### 啟動伺服器

啟動 MCP 伺服器，請使用以下指令：

```bash
python server.py
```

伺服器將以 stdio 為基礎的 MCP 伺服器運行，客戶端可直接連線。

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

### 使用不同方法測試

依照需求與工作流程，有多種方式測試與互動伺服器提供的工具。

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


在這裡，「測試腳本」指的是你撰寫的 Python 程式，作為 MCP 伺服器的客戶端。它不是正式的單元測試，而是讓你程式化地連接伺服器、呼叫任一工具並傳入參數，檢視結果。此方式適合：

- 快速原型與實驗工具呼叫
- 驗證伺服器對不同輸入的反應
- 自動化重複工具呼叫
- 建立你自己的工作流程或整合

你可以用測試腳本快速嘗試新查詢、除錯工具行為，或作為更進階自動化的起點。以下是如何使用 MCP Python SDK 建立此類腳本的範例：

## 工具說明

伺服器提供以下工具，可用於不同類型的搜尋與查詢。每個工具的參數與使用範例如下。

本節提供各工具及其參數的詳細說明。

### general_search

執行一般網路搜尋並回傳格式化結果。

**如何呼叫此工具：**

你可以用 MCP Python SDK 在自己的腳本中呼叫 `general_search`，或在 Inspector 及互動式客戶端模式中使用。以下是 SDK 範例：

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
- `query`（字串）：搜尋查詢內容

**範例請求：**

```json
{
  "query": "latest AI trends"
}
```

### news_search

搜尋與查詢相關的最新新聞文章。

**如何呼叫此工具：**

你可以用 MCP Python SDK 在自己的腳本中呼叫 `news_search`，或在 Inspector 及互動式客戶端模式中使用。以下是 SDK 範例：

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
- `query`（字串）：搜尋查詢內容

**範例請求：**

```json
{
  "query": "AI policy updates"
}
```

### product_search

搜尋符合查詢的產品。

**如何呼叫此工具：**

你可以用 MCP Python SDK 在自己的腳本中呼叫 `product_search`，或在 Inspector 及互動式客戶端模式中使用。以下是 SDK 範例：

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
- `query`（字串）：產品搜尋查詢

**範例請求：**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

從搜尋引擎取得問題的直接答案。

**如何呼叫此工具：**

你可以用 MCP Python SDK 在自己的腳本中呼叫 `qna`，或在 Inspector 及互動式客戶端模式中使用。以下是 SDK 範例：

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

## 本課程的進階概念

開始建置前，這裡有幾個重要的進階概念會貫穿整章。理解這些有助於你跟上內容，即使是初學者也能受益：

- **多工具協調**：指在單一 MCP 伺服器中同時執行多個不同工具（如網路搜尋、新聞搜尋、產品搜尋與問答），讓伺服器能處理多樣任務，而非僅限一種。
- **API 請求限制管理**：許多外部 API（如 SerpAPI）限制一定時間內的請求數量。良好的程式會檢查並妥善處理這些限制，避免應用崩潰。
- **結構化資料解析**：API 回應通常複雜且巢狀，本概念指將回應轉換為乾淨、易用的格式，方便 LLM 或其他程式使用。
- **錯誤復原**：當發生問題（例如網路失敗或 API 回應異常）時，錯誤復原讓程式能妥善處理並回饋有用資訊，而非崩潰。
- **參數驗證**：檢查所有輸入工具的參數是否正確且安全，包括設定預設值與確認類型，幫助避免錯誤與混淆。

本節將協助你診斷與解決在使用 Web 搜尋 MCP 伺服器時可能遇到的常見問題。若遇錯誤或異常行為，請先參考此故障排除部分，通常能快速解決問題。

## 故障排除

在使用 Web 搜尋 MCP 伺服器時，偶爾會遇到問題——這是開發外部 API 與新工具時常見的情況。本節提供實用解決方案，讓你能快速回到正軌。若遇錯誤，請從這裡開始：以下建議針對大多數用戶遇到的問題，通常能在不需額外協助下解決。

### 常見問題

以下是用戶最常遇到的問題，附有清楚解釋與解決步驟：

1. **.env 檔中缺少 SERPAPI_KEY**
   - 如果看到錯誤 `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``，請確認你已建立 `.env` 檔並填入正確的 SERPAPI_KEY。如果金鑰正確但仍出錯，請檢查免費方案配額是否已用盡。

### 除錯模式

預設情況下，應用程式只記錄重要資訊。如果你想看到更多細節（例如診斷複雜問題），可以啟用 DEBUG 模式。這會顯示應用程式每個步驟的更多訊息。

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

你會發現 DEBUG 模式包含更多關於 HTTP 請求、回應及其他內部細節的行數。這對故障排除非常有幫助。

要啟用 DEBUG 模式，請在 `client.py` or `server.py` 頂部將日誌等級設定為 DEBUG：

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

- [6. 社群貢獻](../../06-CommunityContributions/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。