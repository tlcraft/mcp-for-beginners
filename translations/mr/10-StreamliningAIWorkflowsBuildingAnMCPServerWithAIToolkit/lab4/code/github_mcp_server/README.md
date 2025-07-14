<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T08:55:00+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "mr"
}
-->
# Weather MCP Server

हा Python मधील एक नमुना MCP Server आहे जो mock responses सह हवामान साधने अंमलात आणतो. तुम्ही तुमच्या स्वतःच्या MCP Server साठी याचा आधार म्हणून वापर करू शकता. यात खालील वैशिष्ट्ये आहेत:

- **Weather Tool**: दिलेल्या ठिकाणावर आधारित mock केलेली हवामान माहिती पुरवणारे साधन.
- **Git Clone Tool**: git repository निर्दिष्ट फोल्डरमध्ये क्लोन करणारे साधन.
- **VS Code Open Tool**: VS Code किंवा VS Code Insiders मध्ये फोल्डर उघडणारे साधन.
- **Connect to Agent Builder**: MCP server ला Agent Builder शी जोडण्याची सुविधा, ज्यामुळे चाचणी आणि डिबगिंग करता येते.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Inspector वापरून MCP Server डिबग करण्याची सुविधा.

## Weather MCP Server टेम्प्लेटसह सुरुवात करा

> **आवश्यकता**
>
> तुमच्या स्थानिक विकास मशीनवर MCP Server चालवण्यासाठी, तुम्हाला खालील गोष्टी लागतील:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo साधनासाठी आवश्यक)
> - [VS Code](https://code.visualstudio.com/) किंवा [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode साधनासाठी आवश्यक)
> - (*ऐच्छिक - जर तुम्हाला uv वापरायचे असेल तर*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## पर्यावरण तयार करा

या प्रोजेक्टसाठी पर्यावरण तयार करण्यासाठी दोन पद्धती आहेत. तुम्ही तुमच्या पसंतीनुसार कोणतीही एक निवडू शकता.

> लक्षात ठेवा: वर्चुअल पर्यावरण तयार केल्यानंतर VSCode किंवा टर्मिनल रीलोड करा जेणेकरून वर्चुअल पर्यावरणातील python वापरला जाईल.

| पद्धत | टप्पे |
| -------- | ----- |
| `uv` वापरून | 1. वर्चुअल पर्यावरण तयार करा: `uv venv` <br>2. VSCode मध्ये "***Python: Select Interpreter***" कमांड चालवा आणि तयार केलेल्या वर्चुअल पर्यावरणातील python निवडा <br>3. अवलंबित्वे (dev dependencies सह) इन्स्टॉल करा: `uv pip install -r pyproject.toml --extra dev` |
| `pip` वापरून | 1. वर्चुअल पर्यावरण तयार करा: `python -m venv .venv` <br>2. VSCode मध्ये "***Python: Select Interpreter***" कमांड चालवा आणि तयार केलेल्या वर्चुअल पर्यावरणातील python निवडा<br>3. अवलंबित्वे (dev dependencies सह) इन्स्टॉल करा: `pip install -e .[dev]` |

पर्यावरण तयार केल्यानंतर, तुम्ही Agent Builder च्या माध्यमातून MCP Client म्हणून तुमच्या स्थानिक विकास मशीनवर सर्व्हर चालवू शकता:
1. VS Code Debug पॅनेल उघडा. `Debug in Agent Builder` निवडा किंवा MCP server डिबगिंग सुरू करण्यासाठी `F5` दाबा.
2. AI Toolkit Agent Builder वापरून [हा प्रॉम्प्ट](../../../../../../../../../../open_prompt_builder) वापरून सर्व्हरची चाचणी करा. सर्व्हर आपोआप Agent Builder शी जोडले जाईल.
3. प्रॉम्प्टसह सर्व्हरची चाचणी करण्यासाठी `Run` क्लिक करा.

**अभिनंदन**! तुम्ही यशस्वीरित्या Agent Builder च्या माध्यमातून MCP Client म्हणून तुमच्या स्थानिक विकास मशीनवर Weather MCP Server चालवला आहे.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## टेम्प्लेटमध्ये काय समाविष्ट आहे

| फोल्डर / फाइल | सामग्री                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | डिबगिंगसाठी VSCode फाइल्स                   |
| `.aitk`      | AI Toolkit साठी कॉन्फिगरेशन                  |
| `src`        | हवामान mcp server साठी स्रोत कोड             |

## Weather MCP Server कसा डिबग करायचा

> टीपा:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) हा MCP servers च्या चाचणी आणि डिबगिंगसाठी एक दृश्य विकासक साधन आहे.
> - सर्व डिबगिंग मोड ब्रेकपॉइंट्सना समर्थन देतात, त्यामुळे तुम्ही साधनाच्या अंमलबजावणी कोडमध्ये ब्रेकपॉइंट्स जोडू शकता.

## उपलब्ध साधने

### Weather Tool
`get_weather` साधन दिलेल्या ठिकाणासाठी mock केलेली हवामान माहिती पुरवते.

| पॅरामीटर | प्रकार | वर्णन |
| --------- | ---- | ----------- |
| `location` | string | हवामान जाणून घेण्यासाठी ठिकाण (उदा. शहराचे नाव, राज्य, किंवा निर्देशांक) |

### Git Clone Tool
`git_clone_repo` साधन git repository निर्दिष्ट फोल्डरमध्ये क्लोन करते.

| पॅरामीटर | प्रकार | वर्णन |
| --------- | ---- | ----------- |
| `repo_url` | string | क्लोन करण्यासाठी git repository ची URL |
| `target_folder` | string | ज्या फोल्डरमध्ये repository क्लोन करायचा आहे तो मार्ग |

साधन खालील JSON ऑब्जेक्ट परत करते:
- `success`: ऑपरेशन यशस्वी झाले की नाही हे दर्शवणारा Boolean
- `target_folder` किंवा `error`: क्लोन केलेल्या repository चा मार्ग किंवा त्रुटी संदेश

### VS Code Open Tool
`open_in_vscode` साधन VS Code किंवा VS Code Insiders मध्ये फोल्डर उघडते.

| पॅरामीटर | प्रकार | वर्णन |
| --------- | ---- | ----------- |
| `folder_path` | string | उघडायच्या फोल्डरचा मार्ग |
| `use_insiders` | boolean (ऐच्छिक) | नियमित VS Code ऐवजी VS Code Insiders वापरायचा की नाही |

साधन खालील JSON ऑब्जेक्ट परत करते:
- `success`: ऑपरेशन यशस्वी झाले की नाही हे दर्शवणारा Boolean
- `message` किंवा `error`: पुष्टी संदेश किंवा त्रुटी संदेश

## डिबग मोड | वर्णन | डिबग करण्याचे टप्पे |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit च्या माध्यमातून Agent Builder मध्ये MCP server डिबग करा. | 1. VS Code Debug पॅनेल उघडा. `Debug in Agent Builder` निवडा आणि MCP server डिबगिंग सुरू करण्यासाठी `F5` दाबा.<br>2. AI Toolkit Agent Builder वापरून [हा प्रॉम्प्ट](../../../../../../../../../../open_prompt_builder) वापरून सर्व्हरची चाचणी करा. सर्व्हर आपोआप Agent Builder शी जोडले जाईल.<br>3. प्रॉम्प्टसह सर्व्हरची चाचणी करण्यासाठी `Run` क्लिक करा. |
| MCP Inspector | MCP Inspector वापरून MCP server डिबग करा. | 1. [Node.js](https://nodejs.org/) इन्स्टॉल करा<br> 2. Inspector सेटअप करा: `cd inspector` && `npm install` <br> 3. VS Code Debug पॅनेल उघडा. `Debug SSE in Inspector (Edge)` किंवा `Debug SSE in Inspector (Chrome)` निवडा. डिबगिंग सुरू करण्यासाठी F5 दाबा.<br> 4. जेव्हा MCP Inspector ब्राउझरमध्ये सुरू होईल, तेव्हा `Connect` बटणावर क्लिक करून हा MCP server कनेक्ट करा.<br> 5. नंतर तुम्ही `List Tools` करू शकता, साधन निवडा, पॅरामीटर्स द्या, आणि `Run Tool` करून तुमचा सर्व्हर कोड डिबग करा.<br> |

## डीफॉल्ट पोर्ट्स आणि सानुकूलने

| डिबग मोड | पोर्ट्स | व्याख्या | सानुकूलने | टीप |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | वरील पोर्ट्स बदलण्यासाठी [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) संपादित करा. | लागू नाही |
| MCP Inspector | 3001 (सर्व्हर); 5173 आणि 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | वरील पोर्ट्स बदलण्यासाठी [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) संपादित करा. | लागू नाही |

## अभिप्राय

जर तुम्हाला या टेम्प्लेटसाठी काही अभिप्राय किंवा सूचना असतील, तर कृपया [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) वर एक इश्यू उघडा.

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.