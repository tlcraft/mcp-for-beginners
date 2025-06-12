<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-12T22:22:46+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "tw"
}
-->
## Testing and Debugging

在開始測試你的 MCP 伺服器之前，了解可用的工具和除錯的最佳實踐非常重要。有效的測試能確保你的伺服器如預期運作，並幫助你快速找出並解決問題。以下章節說明驗證 MCP 實作的推薦方法。

## Overview

本課程涵蓋如何選擇合適的測試方法及最有效的測試工具。

## Learning Objectives

完成本課程後，你將能夠：

- 描述各種測試方法。
- 使用不同工具有效測試你的程式碼。

## Testing MCP Servers

MCP 提供工具幫助你測試與除錯伺服器：

- **MCP Inspector**：一個可作為 CLI 工具及視覺化工具運行的命令列工具。
- **Manual testing**：你可以使用 curl 這類工具執行網路請求，但任何能執行 HTTP 的工具都可以。
- **Unit testing**：可以使用你偏好的測試框架，測試伺服器和客戶端的功能。

### Using MCP Inspector

我們在之前的課程中已介紹此工具的用法，這裡簡單說明。這是用 Node.js 建立的工具，你可以透過執行 `npx` 來使用，它會暫時下載並安裝工具，執行完請求後會自動清理。

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) 幫助你：

- **發現伺服器功能**：自動偵測可用資源、工具和提示
- **測試工具執行**：嘗試不同參數並即時查看回應
- **查看伺服器元資料**：檢視伺服器資訊、結構和設定

工具的典型執行方式如下：

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

上述指令會啟動 MCP 及其視覺介面，並在瀏覽器中開啟本地網頁介面。你會看到一個儀表板，顯示已註冊的 MCP 伺服器、可用的工具、資源和提示。此介面讓你能互動式測試工具執行、檢查伺服器元資料和查看即時回應，讓驗證與除錯 MCP 伺服器實作更輕鬆。

介面長這樣： ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tw.png)

你也可以用 CLI 模式執行此工具，方法是在指令中加入 `--cli` 參數。以下示範在「CLI」模式下執行工具，列出伺服器上的所有工具：

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manual Testing

除了使用 inspector 工具測試伺服器功能外，另一種類似方法是使用能執行 HTTP 的客戶端，例如 curl。

用 curl，你可以直接用 HTTP 請求測試 MCP 伺服器：

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

如上所示，curl 用 POST 請求呼叫工具，並以包含工具名稱和參數的 payload 作為內容。選擇最適合你的方法。CLI 工具通常使用起來較快，且容易撰寫腳本，對 CI/CD 環境很有幫助。

### Unit Testing

為你的工具和資源撰寫單元測試，確保它們正常運作。以下是一些範例測試程式碼。

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

上述程式碼做了以下事：

- 使用 pytest 框架，讓你以函式形式撰寫測試，並使用 assert 陳述式。
- 建立一個包含兩個不同工具的 MCP Server。
- 用 `assert` 陳述式檢查特定條件是否成立。

可參考 [完整檔案](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

根據上述檔案，你可以測試自己的伺服器，確保功能正確建立。

所有主要 SDK 都有類似的測試章節，方便你依選擇的執行環境調整。

## Samples

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Additional Resources

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## What's Next

- 下一步：[Deployment](/03-GettingStarted/09-deployment/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們對因使用本翻譯所引起的任何誤解或誤釋不負任何責任。