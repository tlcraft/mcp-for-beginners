<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:04:21+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "hk"
}
-->
# Weather MCP Server

呢個係一個用Python寫嘅Weather MCP Server範例，實現咗天氣工具同模擬回應。你可以用佢做自己MCP Server嘅基礎。包括以下功能：

- **Weather Tool**：一個根據指定地點提供模擬天氣資訊嘅工具。
- **Git Clone Tool**：一個可以將git倉庫複製到指定資料夾嘅工具。
- **VS Code Open Tool**：一個可以喺VS Code或者VS Code Insiders開啟資料夾嘅工具。
- **Connect to Agent Builder**：可以將MCP server連接到Agent Builder，方便測試同除錯。
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**：可以用MCP Inspector嚟除錯MCP Server嘅功能。

## 開始用Weather MCP Server範本

> **前置條件**
>
> 喺你本地開發機跑MCP Server，你需要：
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/)（git_clone_repo工具需要）
> - [VS Code](https://code.visualstudio.com/) 或 [VS Code Insiders](https://code.visualstudio.com/insiders/)（open_in_vscode工具需要）
> - （可選 - 如果你鍾意用uv）[uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## 準備環境

有兩個方法可以設定呢個專案嘅環境，你可以按自己喜好揀一個。

> 注意：創建虛擬環境後，記得重載VSCode或者terminal，確保用緊虛擬環境嘅python。

| 方法 | 步驟 |
| -------- | ----- |
| 用 `uv` | 1. 創建虛擬環境：`uv venv` <br>2. 喺VSCode執行命令 "***Python: Select Interpreter***"，揀返剛創建嘅虛擬環境python <br>3. 安裝依賴（包括開發依賴）：`uv pip install -r pyproject.toml --extra dev` |
| 用 `pip` | 1. 創建虛擬環境：`python -m venv .venv` <br>2. 喺VSCode執行命令 "***Python: Select Interpreter***"，揀返剛創建嘅虛擬環境python <br>3. 安裝依賴（包括開發依賴）：`pip install -e .[dev]` |

設定好環境之後，你可以喺本地開發機用Agent Builder作為MCP Client嚟運行server開始：

1. 喺VS Code嘅Debug面板開啟，揀 `Debug in Agent Builder` 或者撳 `F5` 開始除錯MCP server。
2. 用AI Toolkit Agent Builder用[呢個prompt](../../../../../../../../../../../open_prompt_builder)測試server。Server會自動連接Agent Builder。
3. 撳 `Run` 用個prompt測試server。

**恭喜晒**！你已經成功喺本地開發機用Agent Builder作為MCP Client運行咗Weather MCP Server。
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## 範本包含啲乜嘢

| 資料夾 / 檔案 | 內容                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | 用嚟除錯嘅VSCode檔案                   |
| `.aitk`      | AI Toolkit嘅設定檔                |
| `src`        | weather mcp server嘅原始碼   |

## 點樣除錯Weather MCP Server

> 注意：
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector)係一個視覺化嘅開發工具，用嚟測試同除錯MCP servers。
> - 所有除錯模式都支援斷點，你可以喺工具實現代碼加斷點。

## 可用工具

### Weather Tool
`get_weather` 工具會提供指定地點嘅模擬天氣資訊。

| 參數 | 類型 | 說明 |
| --------- | ---- | ----------- |
| `location` | string | 想查天氣嘅地點（例如城市名、州或者座標） |

### Git Clone Tool
`git_clone_repo` 工具會將git倉庫複製到指定資料夾。

| 參數 | 類型 | 說明 |
| --------- | ---- | ----------- |
| `repo_url` | string | 要複製嘅git倉庫URL |
| `target_folder` | string | 複製倉庫嘅資料夾路徑 |

工具會返回一個JSON物件，包括：
- `success`：布林值，表示操作是否成功
- `target_folder` 或 `error`：複製倉庫嘅路徑或者錯誤訊息

### VS Code Open Tool
`open_in_vscode` 工具會喺VS Code或者VS Code Insiders開啟資料夾。

| 參數 | 類型 | 說明 |
| --------- | ---- | ----------- |
| `folder_path` | string | 要開啟嘅資料夾路徑 |
| `use_insiders` | boolean (可選) | 是否用VS Code Insiders代替普通VS Code |

工具會返回一個JSON物件，包括：
- `success`：布林值，表示操作是否成功
- `message` 或 `error`：確認訊息或者錯誤訊息

## 除錯模式 | 說明 | 除錯步驟 |
| ---------- | ----------- | --------------- |
| Agent Builder | 喺Agent Builder透過AI Toolkit除錯MCP server。 | 1. 喺VS Code Debug面板開啟，揀 `Debug in Agent Builder`，撳 `F5` 開始除錯MCP server。<br>2. 用AI Toolkit Agent Builder用[呢個prompt](../../../../../../../../../../../open_prompt_builder)測試server。Server會自動連接Agent Builder。<br>3. 撳 `Run` 用prompt測試server。 |
| MCP Inspector | 用MCP Inspector除錯MCP server。 | 1. 安裝[Node.js](https://nodejs.org/)<br> 2. 設定Inspector：`cd inspector` && `npm install` <br> 3. 喺VS Code Debug面板開啟，揀 `Debug SSE in Inspector (Edge)` 或 `Debug SSE in Inspector (Chrome)`，撳F5開始除錯。<br> 4. MCP Inspector喺瀏覽器開啟後，撳 `Connect` 鍵連接呢個MCP server。<br> 5. 然後你可以`List Tools`，揀工具、輸入參數，再`Run Tool`嚟除錯server代碼。<br> |

## 預設端口同自訂設定

| 除錯模式 | 端口 | 定義 | 自訂設定 | 備註 |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | 編輯 [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) 改端口。 | 無 |
| MCP Inspector | 3001 (Server); 5173 同 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | 編輯 [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) 改端口。 | 無 |

## 反饋

如果你對呢個範本有任何意見或者建議，歡迎喺[AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues)開issue。

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我們致力於準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們不對因使用本翻譯而引致的任何誤解或誤釋負責。