<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:07:33+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "ne"
}
-->
# Weather MCP Server

Yo Python maa weather tools sanga mock response haru implement gareko ek sample MCP Server ho. Yo tapai ko afno MCP Server ko scaffold ko rup maa prayog garna sakincha. Yo ma talim features haru samabesh chan:

- **Weather Tool**: Diye ko location anusar mocked weather janakari dinay tool.
- **Git Clone Tool**: Git repository lai specified folder maa clone garne tool.
- **VS Code Open Tool**: Folder lai VS Code ya VS Code Insiders maa kholne tool.
- **Connect to Agent Builder**: MCP server lai Agent Builder sanga jodne feature testing ra debugging ka lagi.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Server lai MCP Inspector bata debug garna milne feature.

## Weather MCP Server template sanga suru garnu

> **Aawasyak chijharu**
>
> Tapai le MCP Server afno local dev machine maa run garna lai:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo tool ka lagi awasyak)
> - [VS Code](https://code.visualstudio.com/) ya [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode tool ka lagi awasyak)
> - (*Optional - uv manparne haru ka lagi*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Environment prepare garnu

Yo project ko environment setup garna dui tarika chan. Tapai afno pasand anusar kunai pani ek chunnu sakincha.

> Note: Virtual environment create garepachi VSCode ya terminal reload garnu parcha jasle virtual environment ko python use garos.

| Tarika | Steps |
| -------- | ----- |
| Using `uv` | 1. Virtual environment banaunu: `uv venv` <br>2. VSCode Command "***Python: Select Interpreter***" run gari created virtual environment ko python select garnu<br>3. Dependencies install garnu (dev dependencies samet): `uv pip install -r pyproject.toml --extra dev` |
| Using `pip` | 1. Virtual environment banaunu: `python -m venv .venv` <br>2. VSCode Command "***Python: Select Interpreter***" run gari created virtual environment ko python select garnu<br>3. Dependencies install garnu (dev dependencies samet): `pip install -e .[dev]` |

Environment setup bhayepachi, tapai local dev machine maa Agent Builder lai MCP Client ko rup maa run garna sakincha:
1. VS Code ko Debug panel kholnu. `Debug in Agent Builder` select garera `F5` dabaera MCP server debug start garnu.
2. AI Toolkit Agent Builder ko prayog gari [yo prompt](../../../../../../../../../../../open_prompt_builder) sanga server test garnu. Server automatic Agent Builder sanga connect huncha.
3. Prompt sanga server test garna `Run` click garnu.

**Badhaai cha**! Tapai le safal rup maa Weather MCP Server lai local dev machine maa Agent Builder ko madhyam bata MCP Client ko rup maa run garnu bhayo.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Template maa ke chha

| Folder / File| Samagri                                    |
| ------------ | ----------------------------------------- |
| `.vscode`    | Debugging ka lagi VSCode files             |
| `.aitk`      | AI Toolkit ko configurations               |
| `src`        | Weather MCP server ko source code           |

## Weather MCP Server kasari debug garne

> Notes:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) MCP servers testing ra debugging ka lagi visual developer tool ho.
> - Sabai debugging mode haru breakpoint support garcha, jasle tapai lai tool implementation code maa breakpoint halna dincha.

## Upalabdha Tools

### Weather Tool
`get_weather` tool le specified location ko mocked weather janakari dincha.

| Parameter | Type | Description |
| --------- | ---- | ----------- |
| `location` | string | Weather herna location (jasto city name, state, ya coordinates) |

### Git Clone Tool
`git_clone_repo` tool le git repository lai specified folder maa clone garcha.

| Parameter | Type | Description |
| --------- | ---- | ----------- |
| `repo_url` | string | Clone garna ko lagi git repository ko URL |
| `target_folder` | string | Repository clone garne folder ko path |

Tool le JSON object return garcha:
- `success`: Operation safal bhayo ki bhayena bhanne boolean
- `target_folder` ya `error`: Clone bhayeko repository ko path ya error message

### VS Code Open Tool
`open_in_vscode` tool le folder lai VS Code ya VS Code Insiders application maa kholcha.

| Parameter | Type | Description |
| --------- | ---- | ----------- |
| `folder_path` | string | Kholaune folder ko path |
| `use_insiders` | boolean (optional) | VS Code ko regular version ko sato VS Code Insiders prayog garne ki nai |

Tool le JSON object return garcha:
- `success`: Operation safal bhayo ki bhayena bhanne boolean
- `message` ya `error`: Confirmation message ya error message

## Debug Mode | Description | Debug garna ko steps |
| ---------- | ----------- | -------------------- |
| Agent Builder | AI Toolkit bata Agent Builder maa MCP server debug garne. | 1. VS Code Debug panel kholnu. `Debug in Agent Builder` select gari `F5` dabaera MCP server debugging start garnu.<br>2. AI Toolkit Agent Builder bata [yo prompt](../../../../../../../../../../../open_prompt_builder) sanga server test garnu. Server automatic Agent Builder sanga connect huncha.<br>3. Prompt sanga server test garna `Run` click garnu. |
| MCP Inspector | MCP Inspector ko prayog gari MCP server debug garne. | 1. [Node.js](https://nodejs.org/) install garnu<br> 2. Inspector setup garnu: `cd inspector` && `npm install` <br> 3. VS Code Debug panel kholnu. `Debug SSE in Inspector (Edge)` ya `Debug SSE in Inspector (Chrome)` select garnu. F5 dabaera debugging start garnu.<br> 4. MCP Inspector browser maa launch huda, `Connect` button click gari MCP server connect garnu.<br> 5. Pachhi tapai `List Tools` garna sakincha, tool select garnu, parameters input garnu, ra `Run Tool` gari server code debug garnu.<br> |

## Default Ports ra customization

| Debug Mode | Ports | Definitions | Customizations | Note |
| ---------- | ----- | ----------- | -------------- |------ |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) edit gari ports change garna sakincha. | N/A |
| MCP Inspector | 3001 (Server); 5173 ra 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) edit gari ports change garna sakincha.| N/A |

## Feedback

Yo template ko barema kunai feedback ya sujhab cha bhane, kripaya [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) maa issue kholnu hola.

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी सटीकता सुनिश्चित गर्न प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा गलतफहमीहरू हुनसक्छन्। मूल दस्तावेज यसको मूल भाषामा आधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीको लागि व्यावसायिक मानवीय अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा व्याख्यामा हामी जिम्मेवार छैनौं।