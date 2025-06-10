<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:06:00+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "hi"
}
-->
# Weather MCP Server

यह Python में एक नमूना MCP Server है जो mock प्रतिक्रियाओं के साथ weather tools को लागू करता है। इसे आपके अपने MCP Server के लिए एक ढांचे के रूप में इस्तेमाल किया जा सकता है। इसमें निम्नलिखित विशेषताएँ शामिल हैं:

- **Weather Tool**: एक टूल जो दिए गए स्थान के आधार पर नकली मौसम की जानकारी प्रदान करता है।
- **Git Clone Tool**: एक टूल जो एक git रिपॉजिटरी को निर्दिष्ट फ़ोल्डर में क्लोन करता है।
- **VS Code Open Tool**: एक टूल जो VS Code या VS Code Insiders में फ़ोल्डर खोलता है।
- **Connect to Agent Builder**: एक फीचर जो MCP सर्वर को परीक्षण और डिबगिंग के लिए Agent Builder से जोड़ने की अनुमति देता है।
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: एक फीचर जो MCP Inspector का उपयोग करके MCP Server को डिबग करने की सुविधा देता है।

## Weather MCP Server टेम्पलेट के साथ शुरुआत करें

> **आवश्यकताएँ**
>
> अपने स्थानीय विकास मशीन में MCP Server चलाने के लिए आपको चाहिए:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo टूल के लिए आवश्यक)
> - [VS Code](https://code.visualstudio.com/) या [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode टूल के लिए आवश्यक)
> - (*वैकल्पिक - यदि आप uv पसंद करते हैं*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## पर्यावरण तैयार करें

इस प्रोजेक्ट के लिए पर्यावरण सेटअप करने के दो तरीके हैं। आप अपनी पसंद के अनुसार कोई भी तरीका चुन सकते हैं।

> नोट: वर्चुअल पर्यावरण बनाने के बाद सुनिश्चित करें कि वर्चुअल पर्यावरण का python इस्तेमाल हो, इसके लिए VSCode या टर्मिनल को पुनः लोड करें।

| तरीका | चरण |
| -------- | ----- |
| `uv` का उपयोग करते हुए | 1. वर्चुअल पर्यावरण बनाएं: `uv venv` <br>2. VSCode कमांड "***Python: Select Interpreter***" चलाएं और बनाए गए वर्चुअल पर्यावरण का python चुनें <br>3. डिपेंडेंसियाँ (डेव डिपेंडेंसियाँ सहित) इंस्टॉल करें: `uv pip install -r pyproject.toml --extra dev` |
| `pip` का उपयोग करते हुए | 1. वर्चुअल पर्यावरण बनाएं: `python -m venv .venv` <br>2. VSCode कमांड "***Python: Select Interpreter***" चलाएं और बनाए गए वर्चुअल पर्यावरण का python चुनें<br>3. डिपेंडेंसियाँ (डेव डिपेंडेंसियाँ सहित) इंस्टॉल करें: `pip install -e .[dev]` |

पर्यावरण सेटअप करने के बाद, आप Agent Builder के माध्यम से MCP Client के रूप में अपने स्थानीय विकास मशीन में सर्वर चला सकते हैं:
1. VS Code Debug पैनल खोलें। MCP सर्वर को डिबग करने के लिए `Debug in Agent Builder` चुनें या `F5` दबाएं।
2. AI Toolkit Agent Builder का उपयोग करके [इस प्रॉम्प्ट](../../../../../../../../../../../open_prompt_builder) के साथ सर्वर का परीक्षण करें। सर्वर स्वतः Agent Builder से जुड़ जाएगा।
3. प्रॉम्प्ट के साथ सर्वर का परीक्षण करने के लिए `Run` पर क्लिक करें।

**बधाई हो**! आपने सफलतापूर्वक Agent Builder के माध्यम से MCP Client के रूप में अपने स्थानीय विकास मशीन में Weather MCP Server चलाया है।
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## टेम्पलेट में क्या शामिल है

| फ़ोल्डर / फ़ाइल | सामग्री                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | डिबगिंग के लिए VSCode फ़ाइलें                   |
| `.aitk`      | AI Toolkit के लिए कॉन्फ़िगरेशन                |
| `src`        | weather mcp server का स्रोत कोड               |

## Weather MCP Server को कैसे डिबग करें

> नोट्स:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) MCP सर्वर के परीक्षण और डिबगिंग के लिए एक दृश्य डेवलपर टूल है।
> - सभी डिबगिंग मोड ब्रेकपॉइंट्स का समर्थन करते हैं, इसलिए आप टूल के कार्यान्वयन कोड में ब्रेकपॉइंट जोड़ सकते हैं।

## उपलब्ध टूल्स

### Weather Tool
`get_weather` टूल निर्दिष्ट स्थान के लिए नकली मौसम की जानकारी प्रदान करता है।

| पैरामीटर | प्रकार | विवरण |
| --------- | ---- | ----------- |
| `location` | string | मौसम जानने के लिए स्थान (जैसे, शहर का नाम, राज्य, या निर्देशांक) |

### Git Clone Tool
`git_clone_repo` टूल एक git रिपॉजिटरी को निर्दिष्ट फ़ोल्डर में क्लोन करता है।

| पैरामीटर | प्रकार | विवरण |
| --------- | ---- | ----------- |
| `repo_url` | string | क्लोन करने के लिए git रिपॉजिटरी का URL |
| `target_folder` | string | वह फ़ोल्डर जहाँ रिपॉजिटरी क्लोन की जानी है |

टूल एक JSON ऑब्जेक्ट लौटाता है जिसमें:
- `success`: Boolean जो ऑपरेशन की सफलता को दर्शाता है
- `target_folder` या `error`: क्लोन की गई रिपॉजिटरी का पथ या एक त्रुटि संदेश

### VS Code Open Tool
`open_in_vscode` टूल VS Code या VS Code Insiders एप्लिकेशन में एक फ़ोल्डर खोलता है।

| पैरामीटर | प्रकार | विवरण |
| --------- | ---- | ----------- |
| `folder_path` | string | खोलने के लिए फ़ोल्डर का पथ |
| `use_insiders` | boolean (वैकल्पिक) | क्या नियमित VS Code के बजाय VS Code Insiders का उपयोग करना है |

टूल एक JSON ऑब्जेक्ट लौटाता है जिसमें:
- `success`: Boolean जो ऑपरेशन की सफलता को दर्शाता है
- `message` या `error`: पुष्टि संदेश या त्रुटि संदेश

## डिबग मोड | विवरण | डिबग करने के चरण |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit के माध्यम से Agent Builder में MCP सर्वर को डिबग करें। | 1. VS Code Debug पैनल खोलें। MCP सर्वर को डिबग करने के लिए `Debug in Agent Builder` चुनें और `F5` दबाएं।<br>2. AI Toolkit Agent Builder का उपयोग करके [इस प्रॉम्प्ट](../../../../../../../../../../../open_prompt_builder) के साथ सर्वर का परीक्षण करें। सर्वर स्वतः Agent Builder से जुड़ जाएगा।<br>3. प्रॉम्प्ट के साथ सर्वर का परीक्षण करने के लिए `Run` पर क्लिक करें। |
| MCP Inspector | MCP Inspector का उपयोग करके MCP सर्वर को डिबग करें। | 1. [Node.js](https://nodejs.org/) इंस्टॉल करें<br> 2. Inspector सेटअप करें: `cd inspector` && `npm install` <br> 3. VS Code Debug पैनल खोलें। `Debug SSE in Inspector (Edge)` या `Debug SSE in Inspector (Chrome)` चुनें। डिबगिंग शुरू करने के लिए F5 दबाएं।<br> 4. जब MCP Inspector ब्राउज़र में लॉन्च हो, तो इस MCP सर्वर से कनेक्ट करने के लिए `Connect` बटन पर क्लिक करें।<br> 5. फिर आप `List Tools` कर सकते हैं, टूल चुन सकते हैं, पैरामीटर इनपुट कर सकते हैं, और `Run Tool` करके अपने सर्वर कोड को डिबग कर सकते हैं।<br> |

## डिफ़ॉल्ट पोर्ट और कस्टमाइज़ेशन

| डिबग मोड | पोर्ट | परिभाषाएँ | कस्टमाइज़ेशन | नोट |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | ऊपर दिए गए पोर्ट बदलने के लिए [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) संपादित करें। | लागू नहीं |
| MCP Inspector | 3001 (सर्वर); 5173 और 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | ऊपर दिए गए पोर्ट बदलने के लिए [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) संपादित करें।| लागू नहीं |

## प्रतिक्रिया

यदि आपके पास इस टेम्पलेट के लिए कोई प्रतिक्रिया या सुझाव हैं, तो कृपया [AI Toolkit GitHub रिपॉजिटरी](https://github.com/microsoft/vscode-ai-toolkit/issues) पर एक इश्यू खोलें।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनूदित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या गलतियां हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।