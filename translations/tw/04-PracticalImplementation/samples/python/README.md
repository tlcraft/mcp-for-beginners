<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:28:28+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "tw"
}
-->
# Model Context Protocol (MCP) Python 實作

這個儲存庫包含 Model Context Protocol (MCP) 的 Python 實作，示範如何建立同時作為伺服器和客戶端的應用程式，並使用 MCP 標準進行通訊。

## 概覽

MCP 的實作主要包含兩個部分：

1. **MCP Server (`server.py`)** - 一個提供以下功能的伺服器：
   - **Tools**：可遠端呼叫的函式
   - **Resources**：可取得的資料
   - **Prompts**：用於產生語言模型提示詞的範本

2. **MCP Client (`client.py`)** - 連接伺服器並使用其功能的客戶端應用程式

## 功能

這個實作展示了 MCP 的幾項重要功能：

### Tools
- `completion` - 從 AI 模型產生文字補全（模擬）
- `add` - 簡單的加法計算器

### Resources
- `models://` - 回傳可用 AI 模型的資訊
- `greeting://{name}` - 根據指定名稱回傳個人化問候語

### Prompts
- `review_code` - 產生用於程式碼審查的提示詞範本

## 安裝

要使用這個 MCP 實作，請安裝所需的套件：

```powershell
pip install mcp-server mcp-client
```

## 執行伺服器與客戶端

### 啟動伺服器

在一個終端機視窗執行伺服器：

```powershell
python server.py
```

也可以用 MCP CLI 以開發模式執行伺服器：

```powershell
mcp dev server.py
```

或者安裝到 Claude Desktop（若有提供）：

```powershell
mcp install server.py
```

### 執行客戶端

在另一個終端機視窗執行客戶端：

```powershell
python client.py
```

這會連接到伺服器並示範所有可用功能。

### 客戶端使用說明

客戶端 (`client.py`) 展示所有 MCP 功能：

```powershell
python client.py
```

這會連接伺服器並執行所有功能，包括工具、資源和提示詞。輸出會顯示：

1. 計算器工具結果 (5 + 7 = 12)
2. 補全工具對「What is the meaning of life?」的回應
3. 可用 AI 模型列表
4. 對「MCP Explorer」的個人化問候
5. 程式碼審查提示詞範本

## 實作細節

伺服器是使用 `FastMCP` API 實作，提供高階抽象用來定義 MCP 服務。以下是定義工具的簡化範例：

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

客戶端使用 MCP 客戶端函式庫來連接並呼叫伺服器：

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## 進一步了解

想了解更多 MCP 資訊，請造訪：https://modelcontextprotocol.io/

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們努力追求準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。