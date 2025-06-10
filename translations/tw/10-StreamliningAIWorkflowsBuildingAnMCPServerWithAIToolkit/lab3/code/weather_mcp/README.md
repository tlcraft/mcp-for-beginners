<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:25:14+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "tw"
}
-->
# Weather MCP Server

這是一個用 Python 實作的範例 MCP Server，內建模擬天氣工具回應。你可以用它當作自己 MCP Server 的架構。功能包含：

- **Weather Tool**：根據指定地點提供模擬天氣資訊的工具。
- **Connect to Agent Builder**：可以把 MCP Server 連接到 Agent Builder，方便測試與除錯。
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**：可以用 MCP Inspector 來除錯 MCP Server。

## 使用 Weather MCP Server 範本快速上手

> **先決條件**
>
> 要在本機開發環境執行 MCP Server，你需要：
>
> - [Python](https://www.python.org/)
> - （選用 - 如果你偏好 uv）[uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## 環境準備

設定此專案環境有兩種做法，請依喜好選擇。

> 注意：建立虛擬環境後，請重新載入 VSCode 或終端機，確保使用的是虛擬環境的 python。

| 方式 | 步驟 |
| -------- | ----- |
| 使用 `uv` | 1. 建立虛擬環境：`uv venv` <br>2. 執行 VSCode 指令 "***Python: Select Interpreter***"，選擇剛建立的虛擬環境 python <br>3. 安裝依賴（包含開發依賴）：`uv pip install -r pyproject.toml --extra dev` |
| 使用 `pip` | 1. 建立虛擬環境：`python -m venv .venv` <br>2. 執行 VSCode 指令 "***Python: Select Interpreter***"，選擇剛建立的虛擬環境 python<br>3. 安裝依賴（包含開發依賴）：`pip install -e .[dev]` | 

環境設定完成後，你可以用 Agent Builder 當作 MCP Client，在本機開發環境啟動 Server 開始使用：
1. 開啟 VS Code 除錯面板。選擇 `Debug in Agent Builder` 或按 `F5` 開始除錯 MCP Server。
2. 用 AI Toolkit Agent Builder 搭配[這個提示詞](../../../../../../../../../../../open_prompt_builder)測試 Server，Server 會自動連接到 Agent Builder。
3. 點擊 `Run` 用提示詞測試 Server。

**恭喜**！你已成功透過 Agent Builder 在本機開發環境啟動 Weather MCP Server。
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## 範本包含內容

| 資料夾 / 檔案 | 內容                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | 用於除錯的 VSCode 設定檔                   |
| `.aitk`      | AI Toolkit 的設定檔                |
| `src`        | weather mcp server 的原始碼   |

## 如何除錯 Weather MCP Server

> 注意：
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) 是一款用於測試與除錯 MCP server 的視覺化開發工具。
> - 所有除錯模式都支援斷點，你可以在工具實作程式碼中加入斷點。

| 除錯模式 | 說明 | 除錯步驟 |
| ---------- | ----------- | --------------- |
| Agent Builder | 透過 AI Toolkit 在 Agent Builder 中除錯 MCP Server。 | 1. 開啟 VS Code 除錯面板。選擇 `Debug in Agent Builder`，按 `F5` 開始除錯 MCP Server。<br>2. 用 AI Toolkit Agent Builder 搭配[這個提示詞](../../../../../../../../../../../open_prompt_builder)測試 Server，Server 會自動連接到 Agent Builder。<br>3. 點擊 `Run` 用提示詞測試 Server。 |
| MCP Inspector | 使用 MCP Inspector 除錯 MCP Server。 | 1. 安裝 [Node.js](https://nodejs.org/)<br> 2. 設定 Inspector：`cd inspector` && `npm install` <br> 3. 開啟 VS Code 除錯面板。選擇 `Debug SSE in Inspector (Edge)` 或 `Debug SSE in Inspector (Chrome)`，按 F5 開始除錯。<br> 4. 當 MCP Inspector 在瀏覽器啟動時，點擊 `Connect` 按鈕連接此 MCP Server。<br> 5. 接著你可以 `List Tools`，選擇工具、輸入參數，並 `Run Tool` 來除錯程式碼。<br> |

## 預設埠號與自訂設定

| 除錯模式 | 埠號 | 定義檔 | 自訂設定 | 備註 |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | 編輯 [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json)、[__init__.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) 來修改上述埠號。 | 無 |
| MCP Inspector | 3001 (Server); 5173 與 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | 編輯 [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json)、[__init__.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) 來修改上述埠號。 | 無 |

## 回饋

如果你對此範本有任何回饋或建議，請在 [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) 開啟 issue。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於翻譯的準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所產生的任何誤解或誤釋負責。