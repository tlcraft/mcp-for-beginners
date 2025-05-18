<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:40:45+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "tw"
}
-->
## 測試與除錯

在開始測試你的 MCP 伺服器之前，了解可用的工具和最佳的除錯實踐是非常重要的。有效的測試可以確保你的伺服器如預期般運行，並幫助你快速識別和解決問題。以下部分概述了驗證 MCP 實施的推薦方法。

## 概述

這一課講述如何選擇正確的測試方法和最有效的測試工具。

## 學習目標

完成本課後，你將能夠：

- 描述各種測試方法。
- 使用不同的工具有效測試你的代碼。

## 測試 MCP 伺服器

MCP 提供工具幫助你測試和除錯伺服器：

- **MCP Inspector**：一個命令行工具，可以作為 CLI 工具和視覺工具運行。
- **手動測試**：你可以使用像 curl 這樣的工具運行網絡請求，但任何能運行 HTTP 的工具都可以。
- **單元測試**：可以使用你喜愛的測試框架來測試伺服器和客戶端的功能。

### 使用 MCP Inspector

我們在之前的課程中描述了這個工具的使用，但讓我們在高層次上談談它。這是一個用 Node.js 建立的工具，你可以通過調用 `npx` 可執行文件來使用它，這將臨時下載並安裝工具本身，並在完成運行請求後清理自己。

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) 可以幫助你：

- **發現伺服器功能**：自動檢測可用資源、工具和提示
- **測試工具執行**：嘗試不同的參數並實時查看響應
- **查看伺服器元數據**：檢查伺服器信息、模式和配置

工具的典型運行如下所示：

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

上述命令啟動 MCP 及其視覺界面，並在你的瀏覽器中啟動本地網絡界面。你可以期待看到一個儀表板，顯示你註冊的 MCP 伺服器、其可用工具、資源和提示。界面允許你互動式測試工具執行、檢查伺服器元數據並查看實時響應，使得驗證和除錯你的 MCP 伺服器實施更加容易。

這是它的樣子：![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.tw.png)

你也可以在 CLI 模式下運行這個工具，在這種情況下你需要添加 `--cli` 屬性。這是運行工具在 "CLI" 模式下的示例，列出伺服器上的所有工具：

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### 手動測試

除了運行檢查工具來測試伺服器功能之外，另一個類似的方法是運行能夠使用 HTTP 的客戶端，例如 curl。

使用 curl，你可以直接通過 HTTP 請求測試 MCP 伺服器：

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

如上所見，使用 curl，你使用 POST 請求來調用工具，使用包含工具名稱及其參數的有效負載。使用最適合你的方法。CLI 工具通常使用速度更快，並且可以編寫腳本，這在 CI/CD 環境中非常有用。

### 單元測試

為你的工具和資源創建單元測試，以確保它們按預期工作。這裡是一些示例測試代碼。

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

上述代碼執行以下操作：

- 利用 pytest 框架，允許你創建測試作為函數並使用 assert 語句。
- 創建一個 MCP 伺服器，具有兩個不同的工具。
- 使用 `assert` 語句檢查某些條件是否滿足。

查看[完整文件](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

根據上述文件，你可以測試自己的伺服器，以確保功能按預期創建。

所有主要的 SDK 都有類似的測試部分，因此你可以根據所選的運行時進行調整。

## 範例

- [Java 計算器](../samples/java/calculator/README.md)
- [.Net 計算器](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 計算器](../samples/javascript/README.md)
- [TypeScript 計算器](../samples/typescript/README.md)
- [Python 計算器](../../../../03-GettingStarted/samples/python)

## 其他資源

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## 下一步

- 下一步：[部署](/03-GettingStarted/08-deployment/README.md)

**免責聲明**：
本文件使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力追求準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應將原始文件的母語版本視為權威來源。對於重要信息，建議使用專業人工翻譯。對於使用本翻譯所引起的任何誤解或誤讀，我們不承擔責任。