<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:24:53+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "hk"
}
-->
# Weather MCP Server

呢個係用 Python 寫嘅 Weather MCP Server 範例，實現咗天氣工具嘅模擬回應。你可以用佢嚟做自己 MCP Server 嘅骨架。功能包括：

- **Weather Tool**：根據指定地點提供模擬嘅天氣資訊嘅工具。
- **連接 Agent Builder**：可以將 MCP Server 連接到 Agent Builder，方便測試同除錯。
- **喺 [MCP Inspector](https://github.com/modelcontextprotocol/inspector) 裡面除錯**：用 MCP Inspector 來除錯 MCP Server 嘅功能。

## 用 Weather MCP Server 模板開始

> **先決條件**
>
> 喺本地開發機跑 MCP Server，需要：
>
> - [Python](https://www.python.org/)
> - （可選 - 如果你鍾意用 uv）[uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## 準備環境

有兩個方法可以設定呢個專案嘅環境，可以按你喜好揀其中一個。

> 注意：創建完虛擬環境後，記得重啟 VSCode 或終端，確保用緊虛擬環境嘅 python。

| 方法 | 步驟 |
| -------- | ----- |
| 用 `uv` | 1. 建立虛擬環境：`uv venv` <br>2. 喺 VSCode 執行 "***Python: Select Interpreter***" 命令，揀返你剛剛建立嘅虛擬環境嘅 python <br>3. 安裝依賴（包括開發依賴）：`uv pip install -r pyproject.toml --extra dev` |
| 用 `pip` | 1. 建立虛擬環境：`python -m venv .venv` <br>2. 喺 VSCode 執行 "***Python: Select Interpreter***" 命令，揀返你剛剛建立嘅虛擬環境嘅 python<br>3. 安裝依賴（包括開發依賴）：`pip install -e .[dev]` |

環境設定好之後，可以用 Agent Builder 作為 MCP Client 喺本地開發機跑呢個 server，開始用：

1. 開啟 VS Code 嘅 Debug 面板。揀 `Debug in Agent Builder` 或者按 `F5` 開始除錯 MCP server。
2. 用 AI Toolkit Agent Builder 用 [呢個提示](../../../../../../../../../../../open_prompt_builder) 測試 server。Server 會自動連接到 Agent Builder。
3. 點擊 `Run` 用提示測試 server。

**恭喜晒**！你已經成功喺本地開發機用 Agent Builder 作為 MCP Client 跑起咗 Weather MCP Server。
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## 模板包含咩

| 資料夾 / 檔案 | 內容 |
| ------------ | -------------------------------------------- |
| `.vscode` | VSCode 除錯用文件 |
| `.aitk` | AI Toolkit 配置 |
| `src` | weather mcp server 嘅原始碼 |

## 點樣除錯 Weather MCP Server

> 備註：
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) 係一個視覺化嘅開發工具，用嚟測試同除錯 MCP servers。
> - 所有除錯模式都支持斷點，所以你可以喺工具實現代碼加斷點。

| 除錯模式 | 描述 | 除錯步驟 |
| ---------- | ----------- | --------------- |
| Agent Builder | 喺 Agent Builder 用 AI Toolkit 除錯 MCP server。 | 1. 開啟 VS Code 嘅 Debug 面板。揀 `Debug in Agent Builder`，然後按 `F5` 開始除錯 MCP server。<br>2. 用 AI Toolkit Agent Builder 用 [呢個提示](../../../../../../../../../../../open_prompt_builder) 測試 server。Server 會自動連接 Agent Builder。<br>3. 點擊 `Run` 用提示測試 server。 |
| MCP Inspector | 用 MCP Inspector 除錯 MCP server。 | 1. 安裝 [Node.js](https://nodejs.org/)<br>2. 設定 Inspector：`cd inspector` && `npm install` <br>3. 開啟 VS Code Debug 面板。揀 `Debug SSE in Inspector (Edge)` 或 `Debug SSE in Inspector (Chrome)`，按 F5 開始除錯。<br>4. 當 MCP Inspector 喺瀏覽器啟動後，點擊 `Connect` 按鈕連接呢個 MCP server。<br>5. 然後你可以 `List Tools`，揀工具、輸入參數，然後 `Run Tool` 來除錯你嘅 server 代碼。<br> |

## 預設端口同自訂設定

| 除錯模式 | 端口 | 定義 | 自訂 | 備註 |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | 編輯 [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json)、[__init__.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) 去更改以上端口。 | 無 |
| MCP Inspector | 3001 (Server); 5173 同 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | 編輯 [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json)、[__init__.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) 去更改以上端口。| 無 |

## 反饋

如果你對呢個模板有任何反饋或者建議，歡迎喺 [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) 開 issue。

**免責聲明**：  
本文件使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們努力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們對因使用此翻譯而引致的任何誤解或誤釋概不負責。