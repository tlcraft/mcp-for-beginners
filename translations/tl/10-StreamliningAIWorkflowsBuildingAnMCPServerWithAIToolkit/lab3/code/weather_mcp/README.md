<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:35:13+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "tl"
}
-->
# Weather MCP Server

Ito ay isang halimbawa ng MCP Server sa Python na nag-iimplementa ng mga tool sa panahon gamit ang mga mock na sagot. Maaari itong gamitin bilang pundasyon para sa iyong sariling MCP Server. Kasama dito ang mga sumusunod na tampok:

- **Weather Tool**: Isang tool na nagbibigay ng pekeng impormasyon tungkol sa panahon base sa ibinigay na lokasyon.
- **Connect to Agent Builder**: Isang tampok na nagpapahintulot sa iyo na ikonekta ang MCP server sa Agent Builder para sa pagsubok at pag-debug.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Isang tampok na nagpapahintulot sa pag-debug ng MCP Server gamit ang MCP Inspector.

## Simulan ang Weather MCP Server template

> **Mga Kinakailangan**
>
> Para patakbuhin ang MCP Server sa iyong lokal na makina para sa pag-develop, kakailanganin mo:
>
> - [Python](https://www.python.org/)
> - (*Opsyonal - kung mas gusto mo ang uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Ihanda ang kapaligiran

May dalawang paraan para i-setup ang kapaligiran para sa proyektong ito. Maaari kang pumili alinman sa dalawa ayon sa iyong gusto.

> Note: I-reload ang VSCode o terminal para masigurong ginagamit ang virtual environment python pagkatapos gawin ang virtual environment.

| Approach | Mga Hakbang |
| -------- | ---------- |
| Using `uv` | 1. Gumawa ng virtual environment: `uv venv` <br>2. Patakbuhin ang VSCode Command "***Python: Select Interpreter***" at piliin ang python mula sa nilikhang virtual environment <br>3. I-install ang mga dependencies (kasama ang dev dependencies): `uv pip install -r pyproject.toml --extra dev` |
| Using `pip` | 1. Gumawa ng virtual environment: `python -m venv .venv` <br>2. Patakbuhin ang VSCode Command "***Python: Select Interpreter***" at piliin ang python mula sa nilikhang virtual environment<br>3. I-install ang mga dependencies (kasama ang dev dependencies): `pip install -e .[dev]` |

Pagkatapos ma-setup ang kapaligiran, maaari mong patakbuhin ang server sa iyong lokal na makina gamit ang Agent Builder bilang MCP Client para makapagsimula:
1. Buksan ang VS Code Debug panel. Piliin ang `Debug in Agent Builder` o pindutin ang `F5` para simulan ang pag-debug ng MCP server.
2. Gamitin ang AI Toolkit Agent Builder para subukan ang server gamit ang [prompt na ito](../../../../../../../../../../../open_prompt_builder). Awtomatikong makakonekta ang server sa Agent Builder.
3. I-click ang `Run` para subukan ang server gamit ang prompt.

**Congrats**! Matagumpay mong naipatakbo ang Weather MCP Server sa iyong lokal na makina gamit ang Agent Builder bilang MCP Client.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Ano ang kasama sa template

| Folder / File| Nilalaman                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | Mga file ng VSCode para sa pag-debug                   |
| `.aitk`      | Mga configuration para sa AI Toolkit                |
| `src`        | Ang source code para sa weather mcp server   |

## Paano i-debug ang Weather MCP Server

> Mga Tala:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) ay isang visual na developer tool para sa pagsubok at pag-debug ng MCP servers.
> - Lahat ng debugging modes ay sumusuporta sa breakpoints, kaya maaari kang maglagay ng breakpoints sa code ng tool implementation.

| Debug Mode | Paglalarawan | Mga Hakbang sa pag-debug |
| ---------- | ----------- | ----------------------- |
| Agent Builder | I-debug ang MCP server sa Agent Builder gamit ang AI Toolkit. | 1. Buksan ang VS Code Debug panel. Piliin ang `Debug in Agent Builder` at pindutin ang `F5` para simulan ang pag-debug ng MCP server.<br>2. Gamitin ang AI Toolkit Agent Builder para subukan ang server gamit ang [prompt na ito](../../../../../../../../../../../open_prompt_builder). Awtomatikong makakonekta ang server sa Agent Builder.<br>3. I-click ang `Run` para subukan ang server gamit ang prompt. |
| MCP Inspector | I-debug ang MCP server gamit ang MCP Inspector. | 1. I-install ang [Node.js](https://nodejs.org/)<br> 2. I-setup ang Inspector: `cd inspector` && `npm install` <br> 3. Buksan ang VS Code Debug panel. Piliin ang `Debug SSE in Inspector (Edge)` o `Debug SSE in Inspector (Chrome)`. Pindutin ang F5 para simulan ang pag-debug.<br> 4. Kapag nag-launch ang MCP Inspector sa browser, i-click ang `Connect` button para ikonekta ang MCP server na ito.<br> 5. Pagkatapos ay maaari mong `List Tools`, pumili ng tool, ilagay ang mga parameter, at `Run Tool` para i-debug ang iyong server code.<br> |

## Default Ports at mga customizations

| Debug Mode | Ports | Mga Kahulugan | Mga Customizations | Tala |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | I-edit ang [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) para baguhin ang mga ports sa itaas. | N/A |
| MCP Inspector | 3001 (Server); 5173 at 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | I-edit ang [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) para baguhin ang mga ports sa itaas.| N/A |

## Feedback

Kung mayroon kang feedback o mungkahi para sa template na ito, mangyaring magbukas ng isyu sa [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.