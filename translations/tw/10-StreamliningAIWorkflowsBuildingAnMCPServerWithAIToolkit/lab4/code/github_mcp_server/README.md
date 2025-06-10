<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:04:45+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "tw"
}
-->
# Weather MCP Server

這是一個使用 Python 實作的範例 MCP Server，提供天氣工具的模擬回應。你可以用它作為自己 MCP Server 的骨架。包含以下功能：

- **Weather Tool**：根據指定地點提供模擬的天氣資訊。
- **Git Clone Tool**：將 git 倉庫複製到指定資料夾的工具。
- **VS Code Open Tool**：在 VS Code 或 VS Code Insiders 中開啟資料夾的工具。
- **Connect to Agent Builder**：可將 MCP server 連接到 Agent Builder 進行測試與除錯的功能。
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**：可使用 MCP Inspector 來除錯 MCP Server 的功能。

## 開始使用 Weather MCP Server 範本

> **前置需求**
>
> 若要在本機開發環境執行 MCP Server，你需要：
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/)（git_clone_repo 工具需要）
> - [VS Code](https://code.visualstudio.com/) 或 [VS Code Insiders](https://code.visualstudio.com/insiders/)（open_in_vscode 工具需要）
> - （選用 - 若你偏好 uv）[uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## 環境準備

這個專案有兩種方式來設定環境，可以依照你的喜好選擇其中一種。

> 注意：建立虛擬環境後，請重新載入 VSCode 或終端機，確保使用的是虛擬環境的 python。

| 方式 | 步驟 |
| -------- | ----- |
| 使用 `uv` | 1. 建立虛擬環境：`uv venv` <br>2. 執行 VSCode 指令 "***Python: Select Interpreter***"，選擇剛建立的虛擬環境中的 python <br>3. 安裝相依套件（包含開發相依）：`uv pip install -r pyproject.toml --extra dev` |
| 使用 `pip` | 1. 建立虛擬環境：`python -m venv .venv` <br>2. 執行 VSCode 指令 "***Python: Select Interpreter***"，選擇剛建立的虛擬環境中的 python <br>3. 安裝相依套件（包含開發相依）：`pip install -e .[dev]` |

設定好環境後，你可以透過 Agent Builder 當作 MCP Client，在本機開發環境執行伺服器開始：

1. 打開 VS Code 除錯面板。選擇 `Debug in Agent Builder` 或按 `F5` 開始除錯 MCP server。
2. 使用 AI Toolkit Agent Builder 透過[這個提示](../../../../../../../../../../../open_prompt_builder)測試伺服器。伺服器會自動連接到 Agent Builder。
3. 點擊 `Run` 以使用提示測試伺服器。

**恭喜！** 你已成功透過 Agent Builder 當作 MCP Client，在本機開發環境執行 Weather MCP Server。
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## 範本包含內容

| 資料夾 / 檔案 | 內容 |
| ------------ | -------------------------------------------- |
| `.vscode` | 用於除錯的 VSCode 檔案 |
| `.aitk` | AI Toolkit 的設定檔 |
| `src` | weather mcp server 的原始程式碼 |

## 如何除錯 Weather MCP Server

> 注意事項：
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) 是一個用於測試和除錯 MCP server 的視覺化開發工具。
> - 所有除錯模式都支援斷點，因此你可以在工具實作程式碼中加入斷點。

## 可用工具

### Weather Tool
`get_weather` 工具提供指定地點的模擬天氣資訊。

| 參數 | 類型 | 說明 |
| --------- | ---- | ----------- |
| `location` | string | 要查詢天氣的地點（例如：城市名稱、州或座標） |

### Git Clone Tool
`git_clone_repo` 工具將 git 倉庫複製到指定資料夾。

| 參數 | 類型 | 說明 |
| --------- | ---- | ----------- |
| `repo_url` | string | 要複製的 git 倉庫網址 |
| `target_folder` | string | 複製到的資料夾路徑 |

此工具會回傳 JSON 物件，包含：
- `success`：布林值，表示操作是否成功
- `target_folder` 或 `error`：複製後倉庫的路徑或錯誤訊息

### VS Code Open Tool
`open_in_vscode` 工具可在 VS Code 或 VS Code Insiders 應用程式中開啟資料夾。

| 參數 | 類型 | 說明 |
| --------- | ---- | ----------- |
| `folder_path` | string | 要開啟的資料夾路徑 |
| `use_insiders` | boolean（選用） | 是否使用 VS Code Insiders 取代一般 VS Code |

此工具會回傳 JSON 物件，包含：
- `success`：布林值，表示操作是否成功
- `message` 或 `error`：確認訊息或錯誤訊息

## 除錯模式 | 說明 | 除錯步驟 |
| ---------- | ----------- | --------------- |
| Agent Builder | 透過 AI Toolkit 在 Agent Builder 中除錯 MCP server。 | 1. 打開 VS Code 除錯面板。選擇 `Debug in Agent Builder` 並按 `F5` 開始除錯 MCP server。<br>2. 使用 AI Toolkit Agent Builder 透過[這個提示](../../../../../../../../../../../open_prompt_builder)測試伺服器。伺服器會自動連接到 Agent Builder。<br>3. 點擊 `Run` 使用提示測試伺服器。 |
| MCP Inspector | 使用 MCP Inspector 除錯 MCP server。 | 1. 安裝 [Node.js](https://nodejs.org/)<br>2. 設定 Inspector：`cd inspector` && `npm install` <br>3. 打開 VS Code 除錯面板。選擇 `Debug SSE in Inspector (Edge)` 或 `Debug SSE in Inspector (Chrome)`。按 F5 開始除錯。<br>4. 當 MCP Inspector 在瀏覽器啟動後，點擊 `Connect` 按鈕以連接此 MCP server。<br>5. 接著你可以 `List Tools`，選擇工具、輸入參數，並 `Run Tool` 來除錯你的伺服器程式碼。<br> |

## 預設埠號與自訂設定

| 除錯模式 | 埠號 | 定義 | 自訂設定 | 備註 |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | 編輯 [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)、[__init__.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) 以修改上述埠號。 | 無 |
| MCP Inspector | 3001（伺服器）；5173 和 3000（Inspector） | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | 編輯 [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)、[__init__.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) 以修改上述埠號。 | 無 |

## 回饋

如果你對此範本有任何回饋或建議，請在 [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) 開啟 issue。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所引起之任何誤解或誤釋負責。