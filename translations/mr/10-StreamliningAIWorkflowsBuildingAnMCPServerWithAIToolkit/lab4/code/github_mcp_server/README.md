<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:07:02+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "mr"
}
-->
# Weather MCP Server

हा Python मधील एक नमुना MCP Server आहे जो mock प्रतिसादांसह हवामान साधने अंमलात आणतो. तुम्ही तुमच्या स्वतःच्या MCP Server साठी हा scaffold म्हणून वापरू शकता. यात खालील वैशिष्ट्ये आहेत:

- **Weather Tool**: दिलेल्या स्थानावर आधारित mock हवामान माहिती प्रदान करणारे साधन.
- **Git Clone Tool**: git रिपॉझिटरी निर्दिष्ट फोल्डरमध्ये क्लोन करणारे साधन.
- **VS Code Open Tool**: VS Code किंवा VS Code Insiders मध्ये फोल्डर उघडणारे साधन.
- **Connect to Agent Builder**: MCP सर्व्हर Agent Builder शी कनेक्ट करण्याची सुविधा, चाचणी आणि डीबगिंगसाठी.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Inspector वापरून MCP Server डीबग करण्याची सुविधा.

## Weather MCP Server टेम्प्लेटसह सुरुवात करा

> **आवश्यकता**
>
> तुमच्या स्थानिक विकास मशीनवर MCP Server चालवण्यासाठी, तुम्हाला खालील गोष्टी लागतील:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo साधनासाठी आवश्यक)
> - [VS Code](https://code.visualstudio.com/) किंवा [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode साधनासाठी आवश्यक)
> - (*ऐच्छिक - जर तुम्हाला uv प्राधान्य असेल तर*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## वातावरण तयार करा

या प्रोजेक्टसाठी वातावरण सेटअप करण्यासाठी दोन पद्धती आहेत. तुम्ही तुमच्या पसंतीनुसार कोणतीही निवडू शकता.

> टीप: व्हर्च्युअल वातावरण तयार केल्यानंतर VSCode किंवा टर्मिनल रीलोड करा, जेणेकरून व्हर्च्युअल वातावरणातील python वापरला जाईल.

| पद्धत | टप्पे |
| -------- | ----- |
| Using `uv` | 1. व्हर्च्युअल वातावरण तयार करा: `uv venv` <br>2. VSCode कमांड "***Python: Select Interpreter***" चालवा आणि तयार केलेल्या व्हर्च्युअल वातावरणातील python निवडा <br>3. डिपेंडन्सी (डेव्हलपमेंटसह) इन्स्टॉल करा: `uv pip install -r pyproject.toml --extra dev` |
| Using `pip` | 1. व्हर्च्युअल वातावरण तयार करा: `python -m venv .venv` <br>2. VSCode कमांड "***Python: Select Interpreter***" चालवा आणि तयार केलेल्या व्हर्च्युअल वातावरणातील python निवडा<br>3. डिपेंडन्सी (डेव्हलपमेंटसह) इन्स्टॉल करा: `pip install -e .[dev]` |

वातावरण सेट केल्यानंतर, तुम्ही Agent Builder वापरून स्थानिक विकास मशीनवर MCP Client म्हणून सर्व्हर चालवू शकता:
1. VS Code चा Debug पॅनेल उघडा. `Debug in Agent Builder` निवडा किंवा `F5` दाबा आणि MCP सर्व्हर डीबगिंग सुरू करा.
2. AI Toolkit Agent Builder वापरून [हा prompt](../../../../../../../../../../../open_prompt_builder) वापरून सर्व्हरची चाचणी करा. सर्व्हर आपोआप Agent Builder शी कनेक्ट होईल.
3. सर्व्हरची चाचणी करण्यासाठी `Run` क्लिक करा.

**अभिनंदन**! तुम्ही यशस्वीरित्या Agent Builder वापरून स्थानिक विकास मशीनवर Weather MCP Server चालवला आहे.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## टेम्प्लेटमध्ये काय समाविष्ट आहे

| फोल्डर / फाइल| सामग्री                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | डीबगिंगसाठी VSCode फाइल्स                   |
| `.aitk`      | AI Toolkit साठी कॉन्फिगरेशन                |
| `src`        | Weather MCP सर्व्हरसाठी स्रोत कोड   |

## Weather MCP Server कसा डीबग करावा

> टीपा:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) हा MCP सर्व्हर चाचणी आणि डीबगिंगसाठी एक दृश्य विकास साधन आहे.
> - सर्व डीबगिंग मोड ब्रेकपॉइंट्सला समर्थन देतात, त्यामुळे तुम्ही टूल अंमलबजावणी कोडमध्ये ब्रेकपॉइंट्स सेट करू शकता.

## उपलब्ध साधने

### Weather Tool
`get_weather` साधन निर्दिष्ट ठिकाणासाठी mock हवामान माहिती प्रदान करते.

| पॅरामीटर | प्रकार | वर्णन |
| --------- | ---- | ----------- |
| `location` | string | हवामान जाणून घेण्यासाठी स्थान (उदा., शहराचे नाव, राज्य किंवा निर्देशांक) |

### Git Clone Tool
`git_clone_repo` साधन git रिपॉझिटरी निर्दिष्ट फोल्डरमध्ये क्लोन करते.

| पॅरामीटर | प्रकार | वर्णन |
| --------- | ---- | ----------- |
| `repo_url` | string | क्लोन करण्यासाठी git रिपॉझिटरीचा URL |
| `target_folder` | string | रिपॉझिटरी क्लोन करण्यासाठी फोल्डरचा पथ |

साधन JSON ऑब्जेक्ट परत करते ज्यात:
- `success`: ऑपरेशन यशस्वी झाले की नाही हे दर्शवणारा Boolean
- `target_folder` किंवा `error`: क्लोन केलेल्या रिपॉझिटरीचा पथ किंवा त्रुटी संदेश

### VS Code Open Tool
`open_in_vscode` साधन फोल्डर VS Code किंवा VS Code Insiders मध्ये उघडते.

| पॅरामीटर | प्रकार | वर्णन |
| --------- | ---- | ----------- |
| `folder_path` | string | उघडण्यासाठी फोल्डरचा पथ |
| `use_insiders` | boolean (ऐच्छिक) | VS Code च्या ऐवजी VS Code Insiders वापरायचे की नाही |

साधन JSON ऑब्जेक्ट परत करते ज्यात:
- `success`: ऑपरेशन यशस्वी झाले की नाही हे दर्शवणारा Boolean
- `message` किंवा `error`: पुष्टी संदेश किंवा त्रुटी संदेश

## डीबग मोड | वर्णन | डीबग करण्याचे टप्पे |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit च्या माध्यमातून Agent Builder मध्ये MCP सर्व्हर डीबग करा. | 1. VS Code चा Debug पॅनेल उघडा. `Debug in Agent Builder` निवडा आणि `F5` दाबून MCP सर्व्हर डीबगिंग सुरू करा.<br>2. AI Toolkit Agent Builder वापरून [हा prompt](../../../../../../../../../../../open_prompt_builder) वापरून सर्व्हरची चाचणी करा. सर्व्हर आपोआप Agent Builder शी कनेक्ट होईल.<br>3. prompt वापरून सर्व्हरची चाचणी करण्यासाठी `Run` क्लिक करा. |
| MCP Inspector | MCP Inspector वापरून MCP सर्व्हर डीबग करा. | 1. [Node.js](https://nodejs.org/) इन्स्टॉल करा<br> 2. Inspector सेटअप करा: `cd inspector` && `npm install` <br> 3. VS Code चा Debug पॅनेल उघडा. `Debug SSE in Inspector (Edge)` किंवा `Debug SSE in Inspector (Chrome)` निवडा. F5 दाबा आणि डीबगिंग सुरू करा.<br> 4. जेव्हा MCP Inspector ब्राउझरमध्ये सुरू होईल, तेव्हा या MCP सर्व्हरशी कनेक्ट करण्यासाठी `Connect` बटणावर क्लिक करा.<br> 5. नंतर तुम्ही `List Tools` करू शकता, साधन निवडा, पॅरामीटर्स टाका, आणि `Run Tool` करून तुमचा सर्व्हर कोड डीबग करा.<br> |

## डीफॉल्ट पोर्ट्स आणि सानुकूलने

| डीबग मोड | पोर्ट्स | व्याख्या | सानुकूलने | टीप |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | वर दिलेल्या पोर्ट्स बदलण्यासाठी [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) संपादित करा. | लागू नाही |
| MCP Inspector | 3001 (सर्व्हर); 5173 आणि 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | वर दिलेल्या पोर्ट्स बदलण्यासाठी [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) संपादित करा.| लागू नाही |

## अभिप्राय

जर तुम्हाला या टेम्प्लेटबाबत काही अभिप्राय किंवा सूचना असतील, तर कृपया [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) वर एक इश्यू उघडा.

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेत त्रुटी असू शकतात. मूळ दस्तऐवज त्याच्या मूळ भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी भाषांतर शिफारसीय आहे. या भाषांतराचा वापर केल्यामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीसाठी आम्ही जबाबदार नाही.