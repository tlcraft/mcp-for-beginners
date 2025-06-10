<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:38:28+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "sl"
}
-->
# Weather MCP Server

මෙය Python භාවිතා කරමින් කෘතිම ප්‍රතිචාර සමඟ කාලගුණ මෙවලම් ක්‍රියාත්මක කරන නියම MCP Server එකකි. ඔබගේම MCP Server එකක් සඳහා මූලික සැකිල්ලක් ලෙස මෙය භාවිතා කළ හැක. එය පහත විශේෂාංග ඇතුළත් කරයි:

- **Weather Tool**: දී ඇති ස්ථානය අනුව කාලගුණ තොරතුරු මොකඩ් ලෙස ලබාදෙන මෙවලමක්.
- **Connect to Agent Builder**: MCP server එක Agent Builder එකට සම්බන්ධ කර පරීක්ෂා කිරීම සහ දෝෂ හඳුනා ගැනීම සඳහා විශේෂාංගයක්.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Server එක MCP Inspector භාවිතයෙන් දෝෂ හඳුනා ගැනීමට හැකි විශේෂාංගයක්.

## Weather MCP Server සැකිල්ල සමඟ ආරම්භ කිරීම

> **අවශ්‍යතා**
>
> ඔබේ ස්ථානාන්තර සංවර්ධන යන්ත්‍රය මත MCP Server ධාවනය කිරීමට පහත අවශ්‍ය වේ:
>
> - [Python](https://www.python.org/)
> - (*විකල්පයක් - ඔබ uv කැමති නම්*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## පරිසරය සකස් කිරීම

මෙම ව්‍යාපෘතිය සඳහා පරිසරය සකස් කිරීමට ක්‍රම දෙකක් ඇත. ඔබේ කැමැත්ත අනුව ඕනෑම එකක් තෝරා ගත හැක.

> Note: වර්චුවල් පරිසරය නිර්මාණය කිරීමෙන් පසු VSCode හෝ ටර්මිනල් නැවත පූරණය කරන්න, වර්චුවල් පරිසරයේ Python භාවිතා වන බවට තහවුරු කිරීමට.

| ක්‍රමය | පියවර |
| -------- | ----- |
| Using `uv` | 1. වර්චුවල් පරිසරය නිර්මාණය කරන්න: `uv venv` <br>2. VSCode විධානය ධාවනය කරන්න "***Python: Select Interpreter***" සහ නිර්මාණය කළ වර්චුවල් පරිසරයේ Python තෝරන්න <br>3. අවශ්‍ය මොඩියුල (දෙවැනි මොඩියුල ඇතුළුව) ස්ථාපනය කරන්න: `uv pip install -r pyproject.toml --extra dev` |
| Using `pip` | 1. වර්චුවල් පරිසරය නිර්මාණය කරන්න: `python -m venv .venv` <br>2. VSCode විධානය ධාවනය කරන්න "***Python: Select Interpreter***" සහ නිර්මාණය කළ වර්චුවල් පරිසරයේ Python තෝරන්න<br>3. අවශ්‍ය මොඩියුල (දෙවැනි මොඩියුල ඇතුළුව) ස්ථාපනය කරන්න: `pip install -e .[dev]` | 

පරිසරය සකස් කිරීමෙන් පසු, ඔබට Agent Builder හරහා MCP Client ලෙස ස්ථානාන්තර සංවර්ධන යන්ත්‍රයේ සේවාදායකය ධාවනය කළ හැක:
1. VS Code Debug පැනලය විවෘත කරන්න. MCP server එක debug කිරීමට `Debug in Agent Builder` තෝරන්න හෝ `F5` ඔබන්න.
2. AI Toolkit Agent Builder භාවිතයෙන් [මෙම ප්‍රොම්ප්ට්](../../../../../../../../../../../open_prompt_builder) සමඟ සේවාදායකය පරීක්ෂා කරන්න. සේවාදායකය ස්වයංක්‍රීයව Agent Builder එකට සම්බන්ධ වේ.
3. ප්‍රොම්ප්ට් සමඟ සේවාදායකය පරීක්ෂා කිරීමට `Run` ක්ලික් කරන්න.

**ඔබට සුභපැතුම්!** ඔබ සාර්ථකව Agent Builder හරහා MCP Client ලෙස ස්ථානාන්තර සංවර්ධන යන්ත්‍රයේ Weather MCP Server ධාවනය කර ඇත.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## සැකිල්ලේ අඩංගු දේ

| ෆෝල්ඩරය / ගොනුව | අන්තර්ගතය                                   |
| ------------ | -------------------------------------------- |
| `.vscode`    | Debugging සඳහා VSCode ගොනු                   |
| `.aitk`      | AI Toolkit සඳහා වින්‍යාස ගොනු                |
| `src`        | weather mcp server සඳහා මූලාශ්‍ර කේතය        |

## Weather MCP Server දෝෂ හඳුනා ගැනීමේ ක්‍රමය

> සටහන්:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) MCP servers පරීක්ෂා කිරීම සහ දෝෂ හඳුනා ගැනීම සඳහා දෘශ්‍ය සංවර්ධන මෙවලමකි.
> - සියලු debugging ක්‍රම breakpoints සහය දක්වයි, එබැවින් ඔබට මෙවලම් ක්‍රියාත්මක කිරීමේ කේතයේ breakpoints එක් කළ හැක.

| Debug ක්‍රමය | විස්තරය | දෝෂ හඳුනා ගැනීමේ පියවර |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit හරහා Agent Builder තුළ MCP server එක debug කිරීම. | 1. VS Code Debug පැනලය විවෘත කරන්න. MCP server debug කිරීමට `Debug in Agent Builder` තෝරන්න සහ `F5` ඔබන්න.<br>2. AI Toolkit Agent Builder භාවිතයෙන් [මෙම ප්‍රොම්ප්ට්](../../../../../../../../../../../open_prompt_builder) සමඟ සේවාදායකය පරීක්ෂා කරන්න. සේවාදායකය ස්වයංක්‍රීයව Agent Builder එකට සම්බන්ධ වේ.<br>3. ප්‍රොම්ප්ට් සමඟ සේවාදායකය පරීක්ෂා කිරීමට `Run` ක්ලික් කරන්න. |
| MCP Inspector | MCP Inspector භාවිතයෙන් MCP server එක debug කිරීම. | 1. [Node.js](https://nodejs.org/) ස්ථාපනය කරන්න<br> 2. Inspector සකස් කරන්න: `cd inspector` && `npm install` <br> 3. VS Code Debug පැනලය විවෘත කරන්න. `Debug SSE in Inspector (Edge)` හෝ `Debug SSE in Inspector (Chrome)` තෝරන්න. F5 ඔබා debugging ආරම්භ කරන්න.<br> 4. MCP Inspector බ්‍රවුසරයේ ආරම්භ වන විට, මෙම MCP server එක සම්බන්ධ කිරීමට `Connect` බොත්තම ක්ලික් කරන්න.<br> 5. එවිට ඔබට `List Tools`, මෙවලමක් තෝරන්න, පරාමිතීන් ඇතුළත් කරන්න, සහ `Run Tool` මඟින් ඔබගේ සේවාදායක කේතය debug කළ හැක.<br> |

## පෙරනිමි පෝට් සහ අභිරුචි

| Debug ක්‍රමය | පෝට් | විස්තර | අභිරුචි | සටහන |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) සංස්කරණය කර ඉහත පෝට් වෙනස් කරන්න. | N/A |
| MCP Inspector | 3001 (Server); 5173 සහ 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) සංස්කරණය කර ඉහත පෝට් වෙනස් කරන්න.| N/A |

## ප්‍රතිචාර

මෙම සැකිල්ල සම්බන්ධයෙන් ඔබට කිසිඳු ප්‍රතිචාර හෝ යෝජනා ඇත්නම්, කරුණාකර [AI Toolkit GitHub ගිණුමේ](https://github.com/microsoft/vscode-ai-toolkit/issues) ඉෂූවක් විවෘත කරන්න.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v izvorni jezikovni različici velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.