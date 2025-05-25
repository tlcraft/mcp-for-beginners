<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:28:19+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "hk"
}
-->
# Model Context Protocol (MCP) Python 實作

呢個 repository 包含咗 Model Context Protocol (MCP) 嘅 Python 實作，示範點樣建立一個 server 同 client 應用程式，利用 MCP 標準進行通訊。

## 概覽

MCP 實作主要由兩個部分組成：

1. **MCP Server (`server.py`)** - 一個提供以下功能嘅 server：
   - **Tools**：可以遠端調用嘅函數
   - **Resources**：可以獲取嘅資料
   - **Prompts**：用嚟產生語言模型提示嘅模板

2. **MCP Client (`client.py`)** - 一個連接 server 並使用其功能嘅客戶端應用程式

## 功能

呢個實作示範咗幾個 MCP 嘅主要功能：

### Tools
- `completion` - 從 AI 模型產生文字補全（模擬）
- `add` - 簡單計算機，可以加兩個數字

### Resources
- `models://` - 回傳可用 AI 模型嘅資料
- `greeting://{name}` - 根據指定名字回傳個人化問候

### Prompts
- `review_code` - 產生用嚟做代碼審查嘅提示模板

## 安裝

使用呢個 MCP 實作，請安裝所需嘅套件：

```powershell
pip install mcp-server mcp-client
```

## 運行 Server 同 Client

### 啟動 Server

喺一個終端機視窗運行 server：

```powershell
python server.py
```

server 亦可以用 MCP CLI 喺開發模式運行：

```powershell
mcp dev server.py
```

或者安裝喺 Claude Desktop（如果有嘅話）：

```powershell
mcp install server.py
```

### 運行 Client

喺另一個終端機視窗運行 client：

```powershell
python client.py
```

咁樣會連接到 server，示範所有可用功能。

### Client 使用方法

client (`client.py`) 示範所有 MCP 功能：

```powershell
python client.py
```

咁樣會連接到 server，並執行所有功能，包括 tools、resources 同 prompts。輸出會顯示：

1. 計算機工具結果 (5 + 7 = 12)
2. 補全文字工具回應 “What is the meaning of life?”
3. 可用 AI 模型列表
4. “MCP Explorer” 嘅個人化問候
5. 代碼審查提示模板

## 實作細節

server 用 `FastMCP` API 實作，提供高階抽象嚟定義 MCP 服務。以下係簡化嘅工具定義範例：

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

client 用 MCP client library 連接同調用 server：

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## 深入了解

想知道更多關於 MCP 嘅資訊，請瀏覽：https://modelcontextprotocol.io/

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋盡力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我哋對因使用此翻譯而引致嘅任何誤解或誤釋概不負責。