<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T09:01:32+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "tl"
}
-->
# Weather MCP Server

Ito ay isang halimbawa ng MCP Server sa Python na nag-iimplementa ng mga weather tools na may mock responses. Maaari itong gamitin bilang pundasyon para sa iyong sariling MCP Server. Kasama dito ang mga sumusunod na tampok:

- **Weather Tool**: Isang tool na nagbibigay ng pekeng impormasyon tungkol sa panahon base sa ibinigay na lokasyon.
- **Git Clone Tool**: Isang tool na nagko-clone ng git repository sa isang tinukoy na folder.
- **VS Code Open Tool**: Isang tool na nagbubukas ng folder sa VS Code o VS Code Insiders.
- **Connect to Agent Builder**: Isang tampok na nagpapahintulot sa iyo na ikonekta ang MCP server sa Agent Builder para sa testing at debugging.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Isang tampok na nagpapahintulot sa iyo na i-debug ang MCP Server gamit ang MCP Inspector.

## Pagsisimula gamit ang Weather MCP Server template

> **Mga Kinakailangan**
>
> Para patakbuhin ang MCP Server sa iyong lokal na development machine, kakailanganin mo ang mga sumusunod:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (Kailangan para sa git_clone_repo tool)
> - [VS Code](https://code.visualstudio.com/) o [VS Code Insiders](https://code.visualstudio.com/insiders/) (Kailangan para sa open_in_vscode tool)
> - (*Opsyonal - kung gusto mo ng uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Paghahanda ng kapaligiran

May dalawang paraan para i-setup ang kapaligiran para sa proyektong ito. Maaari kang pumili ng alinman base sa iyong kagustuhan.

> Note: I-reload ang VSCode o terminal para masigurong ang python mula sa virtual environment ang gagamitin pagkatapos gumawa ng virtual environment.

| Paraan | Mga Hakbang |
| -------- | ----- |
| Gamit ang `uv` | 1. Gumawa ng virtual environment: `uv venv` <br>2. Patakbuhin ang VSCode Command "***Python: Select Interpreter***" at piliin ang python mula sa ginawa mong virtual environment <br>3. I-install ang mga dependencies (kasama ang dev dependencies): `uv pip install -r pyproject.toml --extra dev` |
| Gamit ang `pip` | 1. Gumawa ng virtual environment: `python -m venv .venv` <br>2. Patakbuhin ang VSCode Command "***Python: Select Interpreter***" at piliin ang python mula sa ginawa mong virtual environment<br>3. I-install ang mga dependencies (kasama ang dev dependencies): `pip install -e .[dev]` |

Pagkatapos ma-setup ang kapaligiran, maaari mo nang patakbuhin ang server sa iyong lokal na development machine gamit ang Agent Builder bilang MCP Client para makapagsimula:
1. Buksan ang VS Code Debug panel. Piliin ang `Debug in Agent Builder` o pindutin ang `F5` para simulan ang pag-debug ng MCP server.
2. Gamitin ang AI Toolkit Agent Builder para subukan ang server gamit ang [prompt na ito](../../../../../../../../../../open_prompt_builder). Awtomatikong makakonekta ang server sa Agent Builder.
3. I-click ang `Run` para subukan ang server gamit ang prompt.

**Binabati kita**! Matagumpay mong naipatakbo ang Weather MCP Server sa iyong lokal na development machine gamit ang Agent Builder bilang MCP Client.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Ano ang kasama sa template

| Folder / File| Nilalaman                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | Mga file ng VSCode para sa debugging         |
| `.aitk`      | Mga configuration para sa AI Toolkit          |
| `src`        | Ang source code para sa weather mcp server    |

## Paano i-debug ang Weather MCP Server

> Mga Tala:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) ay isang visual developer tool para sa testing at debugging ng MCP servers.
> - Lahat ng debugging modes ay sumusuporta sa breakpoints, kaya maaari kang maglagay ng breakpoints sa code ng tool implementation.

## Mga Available na Tools

### Weather Tool
Ang `get_weather` tool ay nagbibigay ng pekeng impormasyon tungkol sa panahon para sa isang tinukoy na lokasyon.

| Parameter | Uri | Paglalarawan |
| --------- | ---- | ----------- |
| `location` | string | Lokasyon na kukunan ng impormasyon ng panahon (halimbawa, pangalan ng lungsod, estado, o coordinates) |

### Git Clone Tool
Ang `git_clone_repo` tool ay nagko-clone ng git repository sa isang tinukoy na folder.

| Parameter | Uri | Paglalarawan |
| --------- | ---- | ----------- |
| `repo_url` | string | URL ng git repository na iko-clone |
| `target_folder` | string | Path ng folder kung saan iko-clone ang repository |

Ang tool ay nagbabalik ng JSON object na may:
- `success`: Boolean na nagsasaad kung naging matagumpay ang operasyon
- `target_folder` o `error`: Ang path ng na-clone na repository o mensahe ng error

### VS Code Open Tool
Ang `open_in_vscode` tool ay nagbubukas ng folder sa VS Code o VS Code Insiders na aplikasyon.

| Parameter | Uri | Paglalarawan |
| --------- | ---- | ----------- |
| `folder_path` | string | Path ng folder na bubuksan |
| `use_insiders` | boolean (opsyonal) | Kung gagamitin ang VS Code Insiders sa halip na regular na VS Code |

Ang tool ay nagbabalik ng JSON object na may:
- `success`: Boolean na nagsasaad kung naging matagumpay ang operasyon
- `message` o `error`: Isang kumpirmasyon o mensahe ng error

## Debug Mode | Paglalarawan | Mga Hakbang sa pag-debug |
| ---------- | ----------- | --------------- |
| Agent Builder | I-debug ang MCP server sa Agent Builder gamit ang AI Toolkit. | 1. Buksan ang VS Code Debug panel. Piliin ang `Debug in Agent Builder` at pindutin ang `F5` para simulan ang pag-debug ng MCP server.<br>2. Gamitin ang AI Toolkit Agent Builder para subukan ang server gamit ang [prompt na ito](../../../../../../../../../../open_prompt_builder). Awtomatikong makakonekta ang server sa Agent Builder.<br>3. I-click ang `Run` para subukan ang server gamit ang prompt. |
| MCP Inspector | I-debug ang MCP server gamit ang MCP Inspector. | 1. I-install ang [Node.js](https://nodejs.org/)<br> 2. I-setup ang Inspector: `cd inspector` && `npm install` <br> 3. Buksan ang VS Code Debug panel. Piliin ang `Debug SSE in Inspector (Edge)` o `Debug SSE in Inspector (Chrome)`. Pindutin ang F5 para simulan ang pag-debug.<br> 4. Kapag nag-launch ang MCP Inspector sa browser, i-click ang `Connect` button para ikonekta ang MCP server na ito.<br> 5. Pagkatapos, maaari mong `List Tools`, pumili ng tool, ilagay ang mga parameter, at `Run Tool` para i-debug ang iyong server code.<br> |

## Default Ports at mga customizations

| Debug Mode | Ports | Mga Kahulugan | Mga Customizations | Tala |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | I-edit ang [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) para baguhin ang mga port na ito. | Wala |
| MCP Inspector | 3001 (Server); 5173 at 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | I-edit ang [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) para baguhin ang mga port na ito.| Wala |

## Feedback

Kung mayroon kang anumang puna o suhestiyon para sa template na ito, mangyaring magbukas ng isyu sa [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.