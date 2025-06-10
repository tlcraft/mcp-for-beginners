<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:17:35+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "cs"
}
-->
# Weather MCP Server

这是一个用 Python 实现的示例 MCP 服务器，提供天气工具的模拟响应。它可以作为你自己 MCP 服务器的基础。包括以下功能：

- **Weather Tool**：一个基于给定位置提供模拟天气信息的工具。
- **Git Clone Tool**：一个将 git 仓库克隆到指定文件夹的工具。
- **VS Code Open Tool**：一个在 VS Code 或 VS Code Insiders 中打开文件夹的工具。
- **Connect to Agent Builder**：允许你将 MCP 服务器连接到 Agent Builder 以进行测试和调试的功能。
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**：允许你使用 MCP Inspector 调试 MCP 服务器的功能。

## Get started with the Weather MCP Server template

> **Prerequisites**
>
> 要在本地开发机器上运行 MCP 服务器，你需要：
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/)（git_clone_repo 工具所需）
> - [VS Code](https://code.visualstudio.com/) 或 [VS Code Insiders](https://code.visualstudio.com/insiders/)（open_in_vscode 工具所需）
> - （可选 - 如果你喜欢 uv）[uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Prepare environment

有两种方式来设置本项目的环境。你可以根据喜好选择任意一种。

> Note: 创建虚拟环境后，重载 VSCode 或终端以确保使用虚拟环境中的 python。

| Approach | Steps |
| -------- | ----- |
| 使用 `uv` | 1. 创建虚拟环境：`uv venv` <br>2. 运行 VSCode 命令 "***Python: Select Interpreter***"，选择刚创建的虚拟环境中的 python <br>3. 安装依赖（包括开发依赖）：`uv pip install -r pyproject.toml --extra dev` |
| 使用 `pip` | 1. 创建虚拟环境：`python -m venv .venv` <br>2. 运行 VSCode 命令 "***Python: Select Interpreter***"，选择刚创建的虚拟环境中的 python<br>3. 安装依赖（包括开发依赖）：`pip install -e .[dev]` |

设置环境完成后，你可以通过 Agent Builder 作为 MCP 客户端，在本地开发机器上运行服务器，开始使用：
1. 打开 VS Code 调试面板。选择 `Debug in Agent Builder` 或按 `F5` 开始调试 MCP 服务器。
2. 使用 AI Toolkit Agent Builder 通过[此提示](../../../../../../../../../../../open_prompt_builder)测试服务器。服务器将自动连接到 Agent Builder。
3. 点击 `Run` 使用该提示测试服务器。

**恭喜**！你已成功通过 Agent Builder 作为 MCP 客户端在本地开发机器上运行了 Weather MCP Server。
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## What's included in the template

| Folder / File| 内容                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | 用于调试的 VSCode 文件                   |
| `.aitk`      | AI Toolkit 的配置文件                |
| `src`        | weather mcp server 的源代码   |

## How to debug the Weather MCP Server

> Notes:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) 是一个用于测试和调试 MCP 服务器的可视化开发工具。
> - 所有调试模式都支持断点，因此你可以在工具实现代码中添加断点。

## Available Tools

### Weather Tool
`get_weather` 工具提供指定位置的模拟天气信息。

| 参数 | 类型 | 说明 |
| --------- | ---- | ----------- |
| `location` | string | 获取天气的地点（例如城市名、州或坐标） |

### Git Clone Tool
`git_clone_repo` 工具将 git 仓库克隆到指定文件夹。

| 参数 | 类型 | 说明 |
| --------- | ---- | ----------- |
| `repo_url` | string | 需要克隆的 git 仓库 URL |
| `target_folder` | string | 仓库克隆目标文件夹路径 |

该工具返回一个 JSON 对象，包含：
- `success`：表示操作是否成功的布尔值
- `target_folder` 或 `error`：克隆仓库的路径或错误信息

### VS Code Open Tool
`open_in_vscode` 工具在 VS Code 或 VS Code Insiders 应用中打开文件夹。

| 参数 | 类型 | 说明 |
| --------- | ---- | ----------- |
| `folder_path` | string | 需要打开的文件夹路径 |
| `use_insiders` | boolean (可选) | 是否使用 VS Code Insiders 而非普通 VS Code |

该工具返回一个 JSON 对象，包含：
- `success`：表示操作是否成功的布尔值
- `message` 或 `error`：确认消息或错误信息

## Debug Mode | Description | Steps to debug |
| ---------- | ----------- | --------------- |
| Agent Builder | 通过 AI Toolkit 在 Agent Builder 中调试 MCP 服务器。 | 1. 打开 VS Code 调试面板。选择 `Debug in Agent Builder` 并按 `F5` 开始调试 MCP 服务器。<br>2. 使用 AI Toolkit Agent Builder 通过[此提示](../../../../../../../../../../../open_prompt_builder)测试服务器。服务器将自动连接到 Agent Builder。<br>3. 点击 `Run` 使用该提示测试服务器。 |
| MCP Inspector | 使用 MCP Inspector 调试 MCP 服务器。 | 1. 安装 [Node.js](https://nodejs.org/)<br> 2. 设置 Inspector：`cd inspector` && `npm install` <br> 3. 打开 VS Code 调试面板。选择 `Debug SSE in Inspector (Edge)` 或 `Debug SSE in Inspector (Chrome)`。按 F5 开始调试。<br> 4. 当 MCP Inspector 在浏览器中启动时，点击 `Connect` 按钮连接此 MCP 服务器。<br> 5. 之后你可以 `List Tools`，选择工具，输入参数，`Run Tool` 来调试你的服务器代码。<br> |

## Default Ports and customizations

| 调试模式 | 端口 | 定义 | 自定义 | 备注 |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | 编辑 [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)、[__init__.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) 来更改上述端口。 | 无 |
| MCP Inspector | 3001（服务器）；5173 和 3000（Inspector） | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | 编辑 [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)、[__init__.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) 来更改上述端口。| 无 |

## Feedback

如果你对这个模板有任何反馈或建议，请在 [AI Toolkit GitHub 仓库](https://github.com/microsoft/vscode-ai-toolkit/issues) 提交 issue。

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné interpretace vzniklé použitím tohoto překladu.