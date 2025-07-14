<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T08:55:41+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "pa"
}
-->
# Weather MCP Server

ਇਹ Python ਵਿੱਚ ਇੱਕ ਨਮੂਨਾ MCP Server ਹੈ ਜੋ ਮੌਸਮ ਦੇ ਟੂਲਾਂ ਨੂੰ ਮੌਕ ਜਵਾਬਾਂ ਨਾਲ ਲਾਗੂ ਕਰਦਾ ਹੈ। ਇਸਨੂੰ ਤੁਹਾਡੇ ਆਪਣੇ MCP Server ਲਈ ਇੱਕ ਢਾਂਚਾ ਵਜੋਂ ਵਰਤਿਆ ਜਾ ਸਕਦਾ ਹੈ। ਇਸ ਵਿੱਚ ਹੇਠ ਲਿਖੀਆਂ ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਸ਼ਾਮਲ ਹਨ:

- **Weather Tool**: ਇੱਕ ਟੂਲ ਜੋ ਦਿੱਤੇ ਗਏ ਸਥਾਨ ਦੇ ਆਧਾਰ 'ਤੇ ਮੌਸਮ ਦੀ ਮੌਕ ਜਾਣਕਾਰੀ ਦਿੰਦਾ ਹੈ।
- **Git Clone Tool**: ਇੱਕ ਟੂਲ ਜੋ ਇੱਕ git ਰਿਪੋਜ਼ਿਟਰੀ ਨੂੰ ਨਿਰਧਾਰਿਤ ਫੋਲਡਰ ਵਿੱਚ ਕਲੋਨ ਕਰਦਾ ਹੈ।
- **VS Code Open Tool**: ਇੱਕ ਟੂਲ ਜੋ VS Code ਜਾਂ VS Code Insiders ਵਿੱਚ ਫੋਲਡਰ ਖੋਲ੍ਹਦਾ ਹੈ।
- **Connect to Agent Builder**: ਇੱਕ ਫੀਚਰ ਜੋ MCP ਸਰਵਰ ਨੂੰ Agent Builder ਨਾਲ ਟੈਸਟਿੰਗ ਅਤੇ ਡੀਬੱਗਿੰਗ ਲਈ ਜੋੜਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: ਇੱਕ ਫੀਚਰ ਜੋ MCP Inspector ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP Server ਨੂੰ ਡੀਬੱਗ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।

## Weather MCP Server ਟੈਮਪਲੇਟ ਨਾਲ ਸ਼ੁਰੂਆਤ ਕਰੋ

> **ਪੂਰਵ-ਸ਼ਰਤਾਂ**
>
> ਆਪਣੇ ਲੋਕਲ ਡਿਵ ਮਸ਼ੀਨ 'ਤੇ MCP Server ਚਲਾਉਣ ਲਈ, ਤੁਹਾਨੂੰ ਲੋੜ ਹੋਵੇਗੀ:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo ਟੂਲ ਲਈ ਜ਼ਰੂਰੀ)
> - [VS Code](https://code.visualstudio.com/) ਜਾਂ [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode ਟੂਲ ਲਈ ਜ਼ਰੂਰੀ)
> - (*ਵਿਕਲਪਿਕ - ਜੇ ਤੁਸੀਂ uv ਪਸੰਦ ਕਰਦੇ ਹੋ*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## ਵਾਤਾਵਰਣ ਤਿਆਰ ਕਰੋ

ਇਸ ਪ੍ਰੋਜੈਕਟ ਲਈ ਵਾਤਾਵਰਣ ਸੈੱਟਅਪ ਕਰਨ ਦੇ ਦੋ ਤਰੀਕੇ ਹਨ। ਤੁਸੀਂ ਆਪਣੀ ਪਸੰਦ ਅਨੁਸਾਰ ਕੋਈ ਵੀ ਇੱਕ ਚੁਣ ਸਕਦੇ ਹੋ।

> ਨੋਟ: ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਬਣਾਉਣ ਤੋਂ ਬਾਅਦ ਇਹ ਯਕੀਨੀ ਬਣਾਉਣ ਲਈ VSCode ਜਾਂ ਟਰਮੀਨਲ ਨੂੰ ਰੀਲੋਡ ਕਰੋ ਕਿ ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਦਾ Python ਵਰਤਿਆ ਜਾ ਰਿਹਾ ਹੈ।

| ਤਰੀਕਾ | ਕਦਮ |
| -------- | ----- |
| `uv` ਦੀ ਵਰਤੋਂ ਕਰਕੇ | 1. ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਬਣਾਓ: `uv venv` <br>2. VSCode ਕਮਾਂਡ "***Python: Select Interpreter***" ਚਲਾਓ ਅਤੇ ਬਣਾਏ ਗਏ ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਤੋਂ Python ਚੁਣੋ <br>3. ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ (ਡਿਵ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਸਮੇਤ): `uv pip install -r pyproject.toml --extra dev` |
| `pip` ਦੀ ਵਰਤੋਂ ਕਰਕੇ | 1. ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਬਣਾਓ: `python -m venv .venv` <br>2. VSCode ਕਮਾਂਡ "***Python: Select Interpreter***" ਚਲਾਓ ਅਤੇ ਬਣਾਏ ਗਏ ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਤੋਂ Python ਚੁਣੋ<br>3. ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ (ਡਿਵ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਸਮੇਤ): `pip install -e .[dev]` |

ਵਾਤਾਵਰਣ ਸੈੱਟਅਪ ਕਰਨ ਤੋਂ ਬਾਅਦ, ਤੁਸੀਂ Agent Builder ਦੇ ਜ਼ਰੀਏ MCP Client ਵਜੋਂ ਆਪਣੇ ਲੋਕਲ ਡਿਵ ਮਸ਼ੀਨ 'ਤੇ ਸਰਵਰ ਚਲਾ ਸਕਦੇ ਹੋ:
1. VS Code ਡੀਬੱਗ ਪੈਨਲ ਖੋਲ੍ਹੋ। `Debug in Agent Builder` ਚੁਣੋ ਜਾਂ MCP ਸਰਵਰ ਡੀਬੱਗ ਕਰਨ ਲਈ `F5` ਦਬਾਓ।
2. AI Toolkit Agent Builder ਦੀ ਵਰਤੋਂ ਕਰਕੇ [ਇਸ ਪ੍ਰਾਂਪਟ](../../../../../../../../../../open_prompt_builder) ਨਾਲ ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰੋ। ਸਰਵਰ ਆਪਣੇ ਆਪ Agent Builder ਨਾਲ ਜੁੜ ਜਾਵੇਗਾ।
3. ਪ੍ਰਾਂਪਟ ਨਾਲ ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰਨ ਲਈ `Run` 'ਤੇ ਕਲਿੱਕ ਕਰੋ।

**ਵਧਾਈਆਂ**! ਤੁਸੀਂ Agent Builder ਦੇ ਜ਼ਰੀਏ MCP Client ਵਜੋਂ ਆਪਣੇ ਲੋਕਲ ਡਿਵ ਮਸ਼ੀਨ 'ਤੇ Weather MCP Server ਸਫਲਤਾਪੂਰਵਕ ਚਲਾ ਲਿਆ ਹੈ।  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## ਟੈਮਪਲੇਟ ਵਿੱਚ ਕੀ ਸ਼ਾਮਲ ਹੈ

| ਫੋਲਡਰ / ਫਾਇਲ | ਸਮੱਗਰੀ                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | ਡੀਬੱਗਿੰਗ ਲਈ VSCode ਫਾਇਲਾਂ                   |
| `.aitk`      | AI Toolkit ਲਈ ਸੰਰਚਨਾਵਾਂ                     |
| `src`        | weather mcp server ਲਈ ਸਰੋਤ ਕੋਡ               |

## Weather MCP Server ਨੂੰ ਕਿਵੇਂ ਡੀਬੱਗ ਕਰੀਏ

> ਨੋਟਸ:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) MCP ਸਰਵਰਾਂ ਦੀ ਟੈਸਟਿੰਗ ਅਤੇ ਡੀਬੱਗਿੰਗ ਲਈ ਇੱਕ ਵਿਜ਼ੂਅਲ ਡਿਵੈਲਪਰ ਟੂਲ ਹੈ।
> - ਸਾਰੇ ਡੀਬੱਗ ਮੋਡ ਬ੍ਰੇਕਪੌਇੰਟਸ ਨੂੰ ਸਹਿਯੋਗ ਦਿੰਦੇ ਹਨ, ਇਸ ਲਈ ਤੁਸੀਂ ਟੂਲ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਕੋਡ ਵਿੱਚ ਬ੍ਰੇਕਪੌਇੰਟਸ ਜੋੜ ਸਕਦੇ ਹੋ।

## ਉਪਲਬਧ ਟੂਲ

### Weather Tool  
`get_weather` ਟੂਲ ਦਿੱਤੇ ਗਏ ਸਥਾਨ ਲਈ ਮੌਸਮ ਦੀ ਮੌਕ ਜਾਣਕਾਰੀ ਦਿੰਦਾ ਹੈ।

| ਪੈਰਾਮੀਟਰ | ਕਿਸਮ | ਵੇਰਵਾ |
| --------- | ---- | ----------- |
| `location` | string | ਮੌਸਮ ਜਾਣਨ ਲਈ ਸਥਾਨ (ਜਿਵੇਂ ਕਿ ਸ਼ਹਿਰ ਦਾ ਨਾਮ, ਰਾਜ, ਜਾਂ ਕੋਆਰਡੀਨੇਟ) |

### Git Clone Tool  
`git_clone_repo` ਟੂਲ ਇੱਕ git ਰਿਪੋਜ਼ਿਟਰੀ ਨੂੰ ਨਿਰਧਾਰਿਤ ਫੋਲਡਰ ਵਿੱਚ ਕਲੋਨ ਕਰਦਾ ਹੈ।

| ਪੈਰਾਮੀਟਰ | ਕਿਸਮ | ਵੇਰਵਾ |
| --------- | ---- | ----------- |
| `repo_url` | string | ਕਲੋਨ ਕਰਨ ਲਈ git ਰਿਪੋਜ਼ਿਟਰੀ ਦਾ URL |
| `target_folder` | string | ਉਹ ਫੋਲਡਰ ਜਿੱਥੇ ਰਿਪੋਜ਼ਿਟਰੀ ਕਲੋਨ ਕਰਨੀ ਹੈ |

ਟੂਲ ਇੱਕ JSON ਆਬਜੈਕਟ ਵਾਪਸ ਕਰਦਾ ਹੈ ਜਿਸ ਵਿੱਚ ਸ਼ਾਮਲ ਹਨ:  
- `success`: Boolean ਜੋ ਦੱਸਦਾ ਹੈ ਕਿ ਓਪਰੇਸ਼ਨ ਸਫਲ ਰਿਹਾ ਜਾਂ ਨਹੀਂ  
- `target_folder` ਜਾਂ `error`: ਕਲੋਨ ਕੀਤੀ ਗਈ ਰਿਪੋਜ਼ਿਟਰੀ ਦਾ ਪਾਥ ਜਾਂ ਕੋਈ ਗਲਤੀ ਦਾ ਸੁਨੇਹਾ  

### VS Code Open Tool  
`open_in_vscode` ਟੂਲ VS Code ਜਾਂ VS Code Insiders ਐਪਲੀਕੇਸ਼ਨ ਵਿੱਚ ਫੋਲਡਰ ਖੋਲ੍ਹਦਾ ਹੈ।

| ਪੈਰਾਮੀਟਰ | ਕਿਸਮ | ਵੇਰਵਾ |
| --------- | ---- | ----------- |
| `folder_path` | string | ਖੋਲ੍ਹਣ ਲਈ ਫੋਲਡਰ ਦਾ ਪਾਥ |
| `use_insiders` | boolean (ਵਿਕਲਪਿਕ) | ਕੀ VS Code ਦੀ ਬਜਾਏ VS Code Insiders ਵਰਤਣਾ ਹੈ |

ਟੂਲ ਇੱਕ JSON ਆਬਜੈਕਟ ਵਾਪਸ ਕਰਦਾ ਹੈ ਜਿਸ ਵਿੱਚ ਸ਼ਾਮਲ ਹਨ:  
- `success`: Boolean ਜੋ ਦੱਸਦਾ ਹੈ ਕਿ ਓਪਰੇਸ਼ਨ ਸਫਲ ਰਿਹਾ ਜਾਂ ਨਹੀਂ  
- `message` ਜਾਂ `error`: ਪੁਸ਼ਟੀ ਸੁਨੇਹਾ ਜਾਂ ਗਲਤੀ ਦਾ ਸੁਨੇਹਾ  

## ਡੀਬੱਗ ਮੋਡ | ਵੇਰਵਾ | ਡੀਬੱਗ ਕਰਨ ਦੇ ਕਦਮ  
| ---------- | ----------- | --------------- |  
| Agent Builder | AI Toolkit ਰਾਹੀਂ Agent Builder ਵਿੱਚ MCP ਸਰਵਰ ਨੂੰ ਡੀਬੱਗ ਕਰੋ। | 1. VS Code ਡੀਬੱਗ ਪੈਨਲ ਖੋਲ੍ਹੋ। `Debug in Agent Builder` ਚੁਣੋ ਅਤੇ MCP ਸਰਵਰ ਡੀਬੱਗ ਕਰਨ ਲਈ `F5` ਦਬਾਓ।<br>2. AI Toolkit Agent Builder ਦੀ ਵਰਤੋਂ ਕਰਕੇ [ਇਸ ਪ੍ਰਾਂਪਟ](../../../../../../../../../../open_prompt_builder) ਨਾਲ ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰੋ। ਸਰਵਰ ਆਪਣੇ ਆਪ Agent Builder ਨਾਲ ਜੁੜ ਜਾਵੇਗਾ।<br>3. ਪ੍ਰਾਂਪਟ ਨਾਲ ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰਨ ਲਈ `Run` 'ਤੇ ਕਲਿੱਕ ਕਰੋ। |  
| MCP Inspector | MCP Inspector ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰ ਨੂੰ ਡੀਬੱਗ ਕਰੋ। | 1. [Node.js](https://nodejs.org/) ਇੰਸਟਾਲ ਕਰੋ<br>2. Inspector ਸੈੱਟਅਪ ਕਰੋ: `cd inspector` && `npm install` <br>3. VS Code ਡੀਬੱਗ ਪੈਨਲ ਖੋਲ੍ਹੋ। `Debug SSE in Inspector (Edge)` ਜਾਂ `Debug SSE in Inspector (Chrome)` ਚੁਣੋ। ਡੀਬੱਗਿੰਗ ਸ਼ੁਰੂ ਕਰਨ ਲਈ F5 ਦਬਾਓ।<br>4. ਜਦੋਂ MCP Inspector ਬ੍ਰਾਊਜ਼ਰ ਵਿੱਚ ਲਾਂਚ ਹੋਵੇ, ਤਾਂ ਇਸ MCP ਸਰਵਰ ਨੂੰ ਜੋੜਨ ਲਈ `Connect` ਬਟਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ।<br>5. ਫਿਰ ਤੁਸੀਂ `List Tools` ਕਰ ਸਕਦੇ ਹੋ, ਟੂਲ ਚੁਣੋ, ਪੈਰਾਮੀਟਰ ਦਿਓ, ਅਤੇ `Run Tool` ਕਰਕੇ ਆਪਣੇ ਸਰਵਰ ਕੋਡ ਨੂੰ ਡੀਬੱਗ ਕਰੋ।<br> |

## ਡੀਫਾਲਟ ਪੋਰਟ ਅਤੇ ਕਸਟਮਾਈਜ਼ੇਸ਼ਨ

| ਡੀਬੱਗ ਮੋਡ | ਪੋਰਟ | ਪਰਿਭਾਸ਼ਾਵਾਂ | ਕਸਟਮਾਈਜ਼ੇਸ਼ਨ | ਨੋਟ |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | ਉਪਰੋਕਤ ਪੋਰਟ ਬਦਲਣ ਲਈ [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) ਸੋਧੋ। | N/A |
| MCP Inspector | 3001 (Server); 5173 ਅਤੇ 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | ਉਪਰੋਕਤ ਪੋਰਟ ਬਦਲਣ ਲਈ [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) ਸੋਧੋ। | N/A |

## ਫੀਡਬੈਕ

ਜੇ ਤੁਹਾਡੇ ਕੋਲ ਇਸ ਟੈਮਪਲੇਟ ਲਈ ਕੋਈ ਫੀਡਬੈਕ ਜਾਂ ਸੁਝਾਅ ਹਨ, ਤਾਂ ਕਿਰਪਾ ਕਰਕੇ [AI Toolkit GitHub ਰਿਪੋਜ਼ਿਟਰੀ](https://github.com/microsoft/vscode-ai-toolkit/issues) 'ਤੇ ਇੱਕ ਇਸ਼ੂ ਖੋਲ੍ਹੋ।

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।