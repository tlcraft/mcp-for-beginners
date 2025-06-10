<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:07:55+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "pa"
}
-->
# Weather MCP Server

ਇਹ Python ਵਿੱਚ ਇੱਕ ਨਮੂਨਾ MCP Server ਹੈ ਜੋ ਮੌਸਮ ਦੇ ਸੰਦਾਂ ਨੂੰ ਮੌਕ ਜਵਾਬਾਂ ਨਾਲ ਲਾਗੂ ਕਰਦਾ ਹੈ। ਇਸਨੂੰ ਆਪਣੇ MCP Server ਲਈ ਇੱਕ ਢਾਂਚਾ ਵਜੋਂ ਵਰਤਿਆ ਜਾ ਸਕਦਾ ਹੈ। ਇਸ ਵਿੱਚ ਹੇਠ ਲਿਖੀਆਂ ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਸ਼ਾਮਲ ਹਨ:

- **Weather Tool**: ਇੱਕ ਸੰਦ ਜੋ ਦਿੱਤੇ ਗਏ ਸਥਾਨ ਅਨੁਸਾਰ ਮੌਸਮ ਦੀ ਮੌਕ ਜਾਣਕਾਰੀ ਦਿੰਦਾ ਹੈ।
- **Git Clone Tool**: ਇੱਕ ਸੰਦ ਜੋ ਗਿਟ ਰਿਪੋਜ਼ਿਟਰੀ ਨੂੰ ਨਿਰਧਾਰਿਤ ਫੋਲਡਰ ਵਿੱਚ ਕਲੋਨ ਕਰਦਾ ਹੈ।
- **VS Code Open Tool**: ਇੱਕ ਸੰਦ ਜੋ VS Code ਜਾਂ VS Code Insiders ਵਿੱਚ ਫੋਲਡਰ ਖੋਲ੍ਹਦਾ ਹੈ।
- **Connect to Agent Builder**: ਇੱਕ ਫੀਚਰ ਜੋ ਤੁਹਾਨੂੰ MCP ਸਰਵਰ ਨੂੰ Agent Builder ਨਾਲ ਜੁੜਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ ਤਾਂ ਜੋ ਟੈਸਟਿੰਗ ਅਤੇ ਡੀਬੱਗਿੰਗ ਕੀਤੀ ਜਾ ਸਕੇ।
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: ਇੱਕ ਫੀਚਰ ਜੋ MCP Inspector ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP Server ਨੂੰ ਡੀਬੱਗ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।

## Weather MCP Server ਟੈਮਪਲੇਟ ਨਾਲ ਸ਼ੁਰੂਆਤ

> **ਜਰੂਰੀ ਚੀਜ਼ਾਂ**
>
> ਆਪਣੇ ਲੋਕਲ ਡਿਵ ਮਸ਼ੀਨ 'ਤੇ MCP Server ਚਲਾਉਣ ਲਈ ਤੁਹਾਨੂੰ ਲੋੜੀਂਦਾ ਹੈ:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo ਟੂਲ ਲਈ ਜਰੂਰੀ)
> - [VS Code](https://code.visualstudio.com/) ਜਾਂ [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode ਟੂਲ ਲਈ ਜਰੂਰੀ)
> - (*ਵਿਕਲਪਿਕ - ਜੇ ਤੁਸੀਂ uv ਨੂੰ ਪਸੰਦ ਕਰਦੇ ਹੋ*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## ਵਾਤਾਵਰਣ ਤਿਆਰ ਕਰੋ

ਇਸ ਪ੍ਰੋਜੈਕਟ ਲਈ ਵਾਤਾਵਰਣ ਸੈੱਟਅਪ ਕਰਨ ਦੇ ਦੋ ਤਰੀਕੇ ਹਨ। ਤੁਸੀਂ ਆਪਣੀ ਪਸੰਦ ਅਨੁਸਾਰ ਕਿਸੇ ਇੱਕ ਨੂੰ ਚੁਣ ਸਕਦੇ ਹੋ।

> ਨੋਟ: ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਬਣਾਉਣ ਤੋਂ ਬਾਅਦ ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ VSCode ਜਾਂ ਟਰਮੀਨਲ ਨੂੰ ਰੀਲੋਡ ਕੀਤਾ ਗਿਆ ਹੈ ਤਾਂ ਜੋ ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਦਾ python ਵਰਤਿਆ ਜਾਵੇ।

| ਤਰੀਕਾ | ਕਦਮ |
| -------- | ----- |
| `uv` ਦੀ ਵਰਤੋਂ ਕਰਕੇ | 1. ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਬਣਾਓ: `uv venv` <br>2. VSCode ਕਮਾਂਡ "***Python: Select Interpreter***" ਚਲਾਓ ਅਤੇ ਬਣਾਏ ਗਏ ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਤੋਂ python ਚੁਣੋ <br>3. ਡਿਪੈਂਡੈਂਸੀਜ਼ (ਡਿਵ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਸਮੇਤ) ਇੰਸਟਾਲ ਕਰੋ: `uv pip install -r pyproject.toml --extra dev` |
| `pip` ਦੀ ਵਰਤੋਂ ਕਰਕੇ | 1. ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਬਣਾਓ: `python -m venv .venv` <br>2. VSCode ਕਮਾਂਡ "***Python: Select Interpreter***" ਚਲਾਓ ਅਤੇ ਬਣਾਏ ਗਏ ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਤੋਂ python ਚੁਣੋ<br>3. ਡਿਪੈਂਡੈਂਸੀਜ਼ (ਡਿਵ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਸਮੇਤ) ਇੰਸਟਾਲ ਕਰੋ: `pip install -e .[dev]` |

ਵਾਤਾਵਰਣ ਸੈੱਟਅਪ ਕਰਨ ਤੋਂ ਬਾਅਦ, ਤੁਸੀਂ Agent Builder ਰਾਹੀਂ MCP Client ਵਜੋਂ ਆਪਣੇ ਲੋਕਲ ਡਿਵ ਮਸ਼ੀਨ 'ਤੇ ਸਰਵਰ ਚਲਾ ਸਕਦੇ ਹੋ:
1. VS Code ਡੀਬੱਗ ਪੈਨਲ ਖੋਲ੍ਹੋ। MCP ਸਰਵਰ ਡੀਬੱਗ ਕਰਨ ਲਈ `Debug in Agent Builder` ਚੁਣੋ ਜਾਂ `F5` ਦਬਾਓ।
2. AI Toolkit Agent Builder ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰੋ [ਇਸ ਪ੍ਰਾਂਪਟ](../../../../../../../../../../../open_prompt_builder) ਨਾਲ। ਸਰਵਰ ਆਪੋ-ਆਪਣੇ Agent Builder ਨਾਲ ਜੁੜ ਜਾਵੇਗਾ।
3. ਪ੍ਰਾਂਪਟ ਨਾਲ ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰਨ ਲਈ `Run` 'ਤੇ ਕਲਿੱਕ ਕਰੋ।

**ਵਧਾਈਆਂ**! ਤੁਸੀਂ Agent Builder ਰਾਹੀਂ MCP Client ਵਜੋਂ ਆਪਣੇ ਲੋਕਲ ਡਿਵ ਮਸ਼ੀਨ 'ਤੇ Weather MCP Server ਸਫਲਤਾਪੂਰਵਕ ਚਲਾਇਆ ਹੈ।
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## ਟੈਮਪਲੇਟ ਵਿੱਚ ਕੀ ਸ਼ਾਮਲ ਹੈ

| ਫੋਲਡਰ / ਫਾਇਲ | ਸਮੱਗਰੀ |
| ------------ | -------------------------------------------- |
| `.vscode` | ਡੀਬੱਗਿੰਗ ਲਈ VSCode ਫਾਇਲਾਂ |
| `.aitk` | AI Toolkit ਲਈ ਸੰਰਚਨਾਵਾਂ |
| `src` | weather mcp server ਦਾ ਸੋਰਸ ਕੋਡ |

## Weather MCP Server ਨੂੰ ਕਿਵੇਂ ਡੀਬੱਗ ਕਰੀਏ

> ਨੋਟਸ:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) MCP ਸਰਵਰਾਂ ਦੀ ਟੈਸਟਿੰਗ ਅਤੇ ਡੀਬੱਗਿੰਗ ਲਈ ਇੱਕ ਵਿਜ਼ੂਅਲ ਡਿਵੈਲਪਰ ਸੰਦ ਹੈ।
> - ਸਾਰੇ ਡੀਬੱਗਿੰਗ ਮੋਡ ਬ੍ਰੇਕਪੋਇੰਟਸ ਨੂੰ ਸਪੋਰਟ ਕਰਦੇ ਹਨ, ਇਸ ਲਈ ਤੁਸੀਂ ਟੂਲ ਇੰਪਲੀਮੇਂਟੇਸ਼ਨ ਕੋਡ ਵਿੱਚ ਬ੍ਰੇਕਪੋਇੰਟਸ ਜੋੜ ਸਕਦੇ ਹੋ।

## ਉਪਲਬਧ ਸੰਦ

### Weather Tool
`get_weather` ਸੰਦ ਦਿੱਤੇ ਗਏ ਸਥਾਨ ਲਈ ਮੌਸਮ ਦੀ ਮੌਕ ਜਾਣਕਾਰੀ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ।

| ਪੈਰਾਮੀਟਰ | ਕਿਸਮ | ਵੇਰਵਾ |
| --------- | ---- | ----------- |
| `location` | string | ਮੌਸਮ ਜਾਣਨ ਲਈ ਸਥਾਨ (ਜਿਵੇਂ ਕਿ ਸ਼ਹਿਰ ਦਾ ਨਾਮ, ਰਾਜ, ਜਾਂ ਕੋਆਰਡੀਨੇਟਸ) |

### Git Clone Tool
`git_clone_repo` ਸੰਦ ਇੱਕ ਗਿਟ ਰਿਪੋਜ਼ਿਟਰੀ ਨੂੰ ਨਿਰਧਾਰਿਤ ਫੋਲਡਰ ਵਿੱਚ ਕਲੋਨ ਕਰਦਾ ਹੈ।

| ਪੈਰਾਮੀਟਰ | ਕਿਸਮ | ਵੇਰਵਾ |
| --------- | ---- | ----------- |
| `repo_url` | string | ਕਲੋਨ ਕਰਨ ਲਈ ਗਿਟ ਰਿਪੋਜ਼ਿਟਰੀ ਦਾ URL |
| `target_folder` | string | ਫੋਲਡਰ ਦਾ ਪਾਥ ਜਿੱਥੇ ਰਿਪੋਜ਼ਿਟਰੀ ਕਲੋਨ ਕੀਤਾ ਜਾਣਾ ਹੈ |

ਸੰਦ ਇੱਕ JSON ਆਬਜੈਕਟ ਵਾਪਸ ਕਰਦਾ ਹੈ ਜਿਸ ਵਿੱਚ:
- `success`: Boolean ਜੋ ਦਿਖਾਉਂਦਾ ਹੈ ਕਿ ਓਪਰੇਸ਼ਨ ਸਫਲ ਰਿਹਾ ਜਾਂ ਨਹੀਂ
- `target_folder` ਜਾਂ `error`: ਕਲੋਨ ਕੀਤੇ ਗਏ ਰਿਪੋਜ਼ਿਟਰੀ ਦਾ ਪਾਥ ਜਾਂ ਕੋਈ ਐਰਰ ਸੁਨੇਹਾ

### VS Code Open Tool
`open_in_vscode` ਸੰਦ ਇੱਕ ਫੋਲਡਰ ਨੂੰ VS Code ਜਾਂ VS Code Insiders ਐਪਲੀਕੇਸ਼ਨ ਵਿੱਚ ਖੋਲ੍ਹਦਾ ਹੈ।

| ਪੈਰਾਮੀਟਰ | ਕਿਸਮ | ਵੇਰਵਾ |
| --------- | ---- | ----------- |
| `folder_path` | string | ਖੋਲ੍ਹਣ ਲਈ ਫੋਲਡਰ ਦਾ ਪਾਥ |
| `use_insiders` | boolean (ਵਿਕਲਪਿਕ) | ਕੀ VS Code ਦੀ ਬਜਾਏ VS Code Insiders ਵਰਤਣਾ ਹੈ |

ਸੰਦ ਇੱਕ JSON ਆਬਜੈਕਟ ਵਾਪਸ ਕਰਦਾ ਹੈ ਜਿਸ ਵਿੱਚ:
- `success`: Boolean ਜੋ ਦਿਖਾਉਂਦਾ ਹੈ ਕਿ ਓਪਰੇਸ਼ਨ ਸਫਲ ਰਿਹਾ ਜਾਂ ਨਹੀਂ
- `message` ਜਾਂ `error`: ਪੁਸ਼ਟੀ ਸੁਨੇਹਾ ਜਾਂ ਐਰਰ ਸੁਨੇਹਾ

## ਡੀਬੱਗ ਮੋਡ | ਵੇਰਵਾ | ਡੀਬੱਗ ਕਰਨ ਦੇ ਕਦਮ
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit ਰਾਹੀਂ Agent Builder ਵਿੱਚ MCP ਸਰਵਰ ਨੂੰ ਡੀਬੱਗ ਕਰੋ। | 1. VS Code ਡੀਬੱਗ ਪੈਨਲ ਖੋਲ੍ਹੋ। MCP ਸਰਵਰ ਡੀਬੱਗ ਕਰਨ ਲਈ `Debug in Agent Builder` ਚੁਣੋ ਅਤੇ `F5` ਦਬਾਓ।<br>2. AI Toolkit Agent Builder ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰੋ [ਇਸ ਪ੍ਰਾਂਪਟ](../../../../../../../../../../../open_prompt_builder)। ਸਰਵਰ ਆਪੋ-ਆਪਣੇ Agent Builder ਨਾਲ ਜੁੜ ਜਾਵੇਗਾ।<br>3. ਪ੍ਰਾਂਪਟ ਨਾਲ ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰਨ ਲਈ `Run` 'ਤੇ ਕਲਿੱਕ ਕਰੋ। |
| MCP Inspector | MCP Inspector ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰ ਨੂੰ ਡੀਬੱਗ ਕਰੋ। | 1. [Node.js](https://nodejs.org/) ਇੰਸਟਾਲ ਕਰੋ<br>2. Inspector ਸੈੱਟਅਪ ਕਰੋ: `cd inspector` && `npm install` <br>3. VS Code ਡੀਬੱਗ ਪੈਨਲ ਖੋਲ੍ਹੋ। `Debug SSE in Inspector (Edge)` ਜਾਂ `Debug SSE in Inspector (Chrome)` ਚੁਣੋ। F5 ਦਬਾ ਕੇ ਡੀਬੱਗਿੰਗ ਸ਼ੁਰੂ ਕਰੋ।<br>4. ਜਦੋਂ MCP Inspector ਬ੍ਰਾਊਜ਼ਰ ਵਿੱਚ ਖੁਲਦਾ ਹੈ, ਤਾਂ ਇਸ MCP ਸਰਵਰ ਨਾਲ ਜੁੜਨ ਲਈ `Connect` ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ।<br>5. ਫਿਰ ਤੁਸੀਂ `List Tools` ਕਰ ਸਕਦੇ ਹੋ, ਕੋਈ ਟੂਲ ਚੁਣੋ, ਪੈਰਾਮੀਟਰ ਦਿਓ, ਅਤੇ `Run Tool` ਕਰਕੇ ਆਪਣੇ ਸਰਵਰ ਕੋਡ ਨੂੰ ਡੀਬੱਗ ਕਰੋ।<br> |

## ਡਿਫਾਲਟ ਪੋਰਟ ਅਤੇ ਕਸਟਮਾਈਜ਼ੇਸ਼ਨ

| ਡੀਬੱਗ ਮੋਡ | ਪੋਰਟ | ਡਿਫਿਨੀਸ਼ਨ | ਕਸਟਮਾਈਜ਼ੇਸ਼ਨ | ਨੋਟ |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | ਉਪਰੋਕਤ ਪੋਰਟ ਬਦਲਣ ਲਈ [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) ਸੋਧੋ। | ਲਾਗੂ ਨਹੀਂ |
| MCP Inspector | 3001 (ਸਰਵਰ); 5173 ਅਤੇ 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | ਉਪਰੋਕਤ ਪੋਰਟ ਬਦਲਣ ਲਈ [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) ਸੋਧੋ। | ਲਾਗੂ ਨਹੀਂ |

## ਫੀਡਬੈਕ

ਜੇ ਤੁਹਾਡੇ ਕੋਲ ਇਸ ਟੈਮਪਲੇਟ ਲਈ ਕੋਈ ਫੀਡਬੈਕ ਜਾਂ ਸੁਝਾਅ ਹਨ, ਤਾਂ ਕਿਰਪਾ ਕਰਕੇ [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) 'ਤੇ ਇੱਕ ਇਸ਼ੂ ਖੋਲ੍ਹੋ।

**ਅਸਵੀਕਾਰੋਥਾ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਯਤਨ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੇ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪ੍ਰੋਫੈਸ਼ਨਲ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫ਼ਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਭ੍ਰਮ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।