<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:27:24+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "mr"
}
-->
# Weather MCP Server

हा Python मध्ये लिहिलेला sample MCP Server आहे जो weather tools mock responses सह implement करतो. हा तुमच्या स्वतःच्या MCP Server साठी scaffold म्हणून वापरता येऊ शकतो. यात खालील features आहेत:

- **Weather Tool**: एक tool जो दिलेल्या location नुसार mock weather माहिती पुरवतो.
- **Connect to Agent Builder**: एक feature ज्याद्वारे तुम्ही MCP server ला Agent Builder शी जोडू शकता टेस्टिंग आणि debugging साठी.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Server ला MCP Inspector वापरून debug करण्याची सुविधा.

## Weather MCP Server template सोबत सुरुवात करा

> **आवश्यकता**
>
> MCP Server तुमच्या local dev machine वर चालवण्यासाठी, तुम्हाला हवे असेल:
>
> - [Python](https://www.python.org/)
> - (*ऐच्छिक - जर तुम्हाला uv आवडत असेल*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## पर्यावरण तयार करा

या प्रोजेक्टसाठी environment सेटअप करण्याचे दोन मार्ग आहेत. तुम्ही तुमच्या आवडीनुसार कोणताही एक निवडू शकता.

> Note: virtual environment तयार केल्यावर virtual environment चा python वापर होईल यासाठी VSCode किंवा terminal पुन्हा लोड करा.

| Approach | Steps |
| -------- | ----- |
| Using `uv` | 1. virtual environment तयार करा: `uv venv` <br>2. VSCode मध्ये "***Python: Select Interpreter***" कमांड चालवा आणि तयार केलेल्या virtual environment मधील python निवडा <br>3. dependencies (dev dependencies सह) install करा: `uv pip install -r pyproject.toml --extra dev` |
| Using `pip` | 1. virtual environment तयार करा: `python -m venv .venv` <br>2. VSCode मध्ये "***Python: Select Interpreter***" कमांड चालवा आणि तयार केलेल्या virtual environment मधील python निवडा<br>3. dependencies (dev dependencies सह) install करा: `pip install -e .[dev]` |

पर्यावरण तयार केल्यानंतर, तुम्ही Agent Builder वापरून तुमच्या local dev machine वर MCP Client म्हणून server चालवू शकता:
1. VS Code Debug panel उघडा. `Debug in Agent Builder` निवडा किंवा `F5` दाबा आणि MCP server debugging सुरू करा.
2. AI Toolkit Agent Builder वापरून [हा prompt](../../../../../../../../../../../open_prompt_builder) वापरून server ची चाचणी करा. Server आपोआप Agent Builder शी कनेक्ट होईल.
3. prompt सह server ची चाचणी करण्यासाठी `Run` क्लिक करा.

**अभिनंदन**! तुम्ही यशस्वीरित्या तुमच्या local dev machine वर Agent Builder वापरून Weather MCP Server चालवला आहे.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## template मध्ये काय समाविष्ट आहे

| Folder / File| Contents                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | debugging साठी VSCode फायली                   |
| `.aitk`      | AI Toolkit साठी configurations                |
| `src`        | weather mcp server साठी source code           |

## Weather MCP Server कसे debug करावे

> नोंदी:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) हा एक visual developer tool आहे जो MCP servers च्या टेस्टिंग आणि debugging साठी वापरला जातो.
> - सर्व debugging modes मध्ये breakpoints सपोर्ट आहेत, त्यामुळे तुम्ही tool implementation code मध्ये breakpoints ठेवू शकता.

| Debug Mode | Description | Steps to debug |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit द्वारे Agent Builder मध्ये MCP server debug करा. | 1. VS Code Debug panel उघडा. `Debug in Agent Builder` निवडा आणि `F5` दाबा, MCP server debug सुरू करण्यासाठी.<br>2. AI Toolkit Agent Builder वापरून [हा prompt](../../../../../../../../../../../open_prompt_builder) वापरून server ची चाचणी करा. Server आपोआप Agent Builder शी कनेक्ट होईल.<br>3. prompt सह server ची चाचणी करण्यासाठी `Run` क्लिक करा. |
| MCP Inspector | MCP Inspector वापरून MCP server debug करा. | 1. [Node.js](https://nodejs.org/) install करा<br> 2. Inspector सेटअप करा: `cd inspector` && `npm install` <br> 3. VS Code Debug panel उघडा. `Debug SSE in Inspector (Edge)` किंवा `Debug SSE in Inspector (Chrome)` निवडा. F5 दाबा debug सुरू करण्यासाठी.<br> 4. जेव्हा MCP Inspector ब्राउझरमध्ये सुरू होईल, तेव्हा `Connect` बटणावर क्लिक करून या MCP server शी कनेक्ट करा.<br> 5. मग तुम्ही `List Tools` करू शकता, tool निवडा, parameters टाका, आणि `Run Tool` करून तुमचा server code debug करा.<br> |

## Default Ports आणि सानुकूलने

| Debug Mode | Ports | Definitions | Customizations | Note |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) edit करून वरील ports बदला. | N/A |
| MCP Inspector | 3001 (Server); 5173 आणि 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) edit करून वरील ports बदला.| N/A |

## Feedback

जर तुम्हाला या template बद्दल काही feedback किंवा सूचना असतील, तर कृपया [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) वर issue उघडा.

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद शिफारस केली जाते. या अनुवादाच्या वापरामुळे झालेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.