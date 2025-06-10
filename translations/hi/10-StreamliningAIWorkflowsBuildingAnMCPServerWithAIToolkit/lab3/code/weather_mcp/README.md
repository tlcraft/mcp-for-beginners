<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:26:37+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "hi"
}
-->
# Weather MCP Server

यह Python में एक नमूना MCP Server है जो mock प्रतिक्रियाओं के साथ weather tools को लागू करता है। इसे अपने खुद के MCP Server के लिए एक आधार के रूप में इस्तेमाल किया जा सकता है। इसमें निम्नलिखित विशेषताएं शामिल हैं:

- **Weather Tool**: एक ऐसा टूल जो दिए गए स्थान के आधार पर mock की गई मौसम की जानकारी प्रदान करता है।
- **Agent Builder से कनेक्ट करें**: एक फीचर जो आपको MCP सर्वर को Agent Builder से परीक्षण और डिबगिंग के लिए कनेक्ट करने की अनुमति देता है।
- **[MCP Inspector](https://github.com/modelcontextprotocol/inspector) में डिबग करें**: एक फीचर जो MCP Inspector का उपयोग करके MCP Server को डिबग करने की सुविधा देता है।

## Weather MCP Server टेम्पलेट के साथ शुरुआत करें

> **पूर्व आवश्यकताएँ**
>
> अपने स्थानीय विकास मशीन पर MCP Server चलाने के लिए, आपको निम्नलिखित की आवश्यकता होगी:
>
> - [Python](https://www.python.org/)
> - (*वैकल्पिक - यदि आप uv पसंद करते हैं*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## पर्यावरण तैयार करें

इस प्रोजेक्ट के लिए पर्यावरण सेटअप करने के दो तरीके हैं। आप अपनी पसंद के अनुसार किसी एक को चुन सकते हैं।

> नोट: वर्चुअल एनवायरनमेंट बनाने के बाद सुनिश्चित करें कि VSCode या टर्मिनल को रीलोड करें ताकि वर्चुअल एनवायरनमेंट का Python उपयोग हो।

| तरीका | चरण |
| -------- | ----- |
| `uv` का उपयोग करते हुए | 1. वर्चुअल एनवायरनमेंट बनाएं: `uv venv` <br>2. VSCode कमांड "***Python: Select Interpreter***" चलाएं और बनाए गए वर्चुअल एनवायरनमेंट का Python चुनें <br>3. निर्भरताएं (डेव निर्भरताएं शामिल) इंस्टॉल करें: `uv pip install -r pyproject.toml --extra dev` |
| `pip` का उपयोग करते हुए | 1. वर्चुअल एनवायरनमेंट बनाएं: `python -m venv .venv` <br>2. VSCode कमांड "***Python: Select Interpreter***" चलाएं और बनाए गए वर्चुअल एनवायरनमेंट का Python चुनें<br>3. निर्भरताएं (डेव निर्भरताएं शामिल) इंस्टॉल करें: `pip install -e .[dev]` |

पर्यावरण सेटअप करने के बाद, आप Agent Builder के माध्यम से MCP क्लाइंट के रूप में अपने स्थानीय विकास मशीन पर सर्वर चला सकते हैं:
1. VS Code Debug पैनल खोलें। MCP सर्वर डिबगिंग शुरू करने के लिए `Debug in Agent Builder` चुनें या `F5` दबाएं।
2. AI Toolkit Agent Builder का उपयोग करके [इस प्रॉम्प्ट](../../../../../../../../../../../open_prompt_builder) के साथ सर्वर का परीक्षण करें। सर्वर अपने आप Agent Builder से कनेक्ट हो जाएगा।
3. प्रॉम्प्ट के साथ सर्वर का परीक्षण करने के लिए `Run` पर क्लिक करें।

**बधाई हो**! आपने सफलतापूर्वक Agent Builder के माध्यम से MCP क्लाइंट के रूप में अपने स्थानीय विकास मशीन पर Weather MCP Server चलाया है।
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## टेम्पलेट में क्या शामिल है

| फ़ोल्डर / फ़ाइल | सामग्री                                      |
| ------------ | -------------------------------------------- |
| `.vscode`    | डिबगिंग के लिए VSCode फ़ाइलें                   |
| `.aitk`      | AI Toolkit के लिए कॉन्फ़िगरेशन                  |
| `src`        | weather mcp सर्वर का स्रोत कोड                     |

## Weather MCP Server को कैसे डिबग करें

> नोट्स:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) MCP सर्वरों के परीक्षण और डिबगिंग के लिए एक विज़ुअल डेवलपर टूल है।
> - सभी डिबगिंग मोड ब्रेकपॉइंट्स का समर्थन करते हैं, इसलिए आप टूल के इम्प्लीमेंटेशन कोड में ब्रेकपॉइंट्स जोड़ सकते हैं।

| डिबग मोड | विवरण | डिबग करने के चरण |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit के माध्यम से Agent Builder में MCP सर्वर को डिबग करें। | 1. VS Code Debug पैनल खोलें। MCP सर्वर डिबगिंग शुरू करने के लिए `Debug in Agent Builder` चुनें और `F5` दबाएं।<br>2. AI Toolkit Agent Builder का उपयोग करके [इस प्रॉम्प्ट](../../../../../../../../../../../open_prompt_builder) के साथ सर्वर का परीक्षण करें। सर्वर अपने आप Agent Builder से कनेक्ट हो जाएगा।<br>3. प्रॉम्प्ट के साथ सर्वर का परीक्षण करने के लिए `Run` पर क्लिक करें। |
| MCP Inspector | MCP Inspector का उपयोग करके MCP सर्वर को डिबग करें। | 1. [Node.js](https://nodejs.org/) इंस्टॉल करें<br> 2. Inspector सेटअप करें: `cd inspector` && `npm install` <br> 3. VS Code Debug पैनल खोलें। `Debug SSE in Inspector (Edge)` या `Debug SSE in Inspector (Chrome)` चुनें। डिबगिंग शुरू करने के लिए F5 दबाएं।<br> 4. जब MCP Inspector ब्राउज़र में लॉन्च हो, तो इस MCP सर्वर से कनेक्ट करने के लिए `Connect` बटन पर क्लिक करें।<br> 5. फिर आप `List Tools` कर सकते हैं, एक टूल चुन सकते हैं, पैरामीटर इनपुट कर सकते हैं, और अपने सर्वर कोड को डिबग करने के लिए `Run Tool` कर सकते हैं।<br> |

## डिफ़ॉल्ट पोर्ट और कस्टमाइज़ेशन

| डिबग मोड | पोर्ट्स | परिभाषाएं | कस्टमाइज़ेशन | नोट |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | उपरोक्त पोर्ट बदलने के लिए [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) संपादित करें। | लागू नहीं |
| MCP Inspector | 3001 (सर्वर); 5173 और 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | उपरोक्त पोर्ट बदलने के लिए [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) संपादित करें।| लागू नहीं |

## प्रतिक्रिया

यदि आपके पास इस टेम्पलेट के लिए कोई प्रतिक्रिया या सुझाव हैं, तो कृपया [AI Toolkit GitHub रिपॉजिटरी](https://github.com/microsoft/vscode-ai-toolkit/issues) पर एक इश्यू खोलें।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।