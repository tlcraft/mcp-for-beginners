<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T08:55:23+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "ne"
}
-->
# Weather MCP Server

यो Python मा लेखिएको एउटा नमूना MCP Server हो जसले मौसम उपकरणहरूलाई नकली प्रतिक्रियासहित कार्यान्वयन गर्छ। यसलाई तपाईंको आफ्नै MCP Server को आधारको रूपमा प्रयोग गर्न सकिन्छ। यसमा निम्न सुविधाहरू समावेश छन्:

- **Weather Tool**: दिइएको स्थानको आधारमा नकली मौसम जानकारी प्रदान गर्ने उपकरण।
- **Git Clone Tool**: निर्दिष्ट फोल्डरमा git रिपोजिटरी क्लोन गर्ने उपकरण।
- **VS Code Open Tool**: फोल्डरलाई VS Code वा VS Code Insiders मा खोल्ने उपकरण।
- **Connect to Agent Builder**: MCP सर्भरलाई Agent Builder सँग जडान गरेर परीक्षण र डिबगिङ गर्न सकिने सुविधा।
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: MCP Inspector प्रयोग गरी MCP Server डिबग गर्ने सुविधा।

## Weather MCP Server टेम्प्लेटसँग सुरु गर्ने तरिका

> **पूर्व आवश्यकताहरू**
>
> तपाईंको स्थानीय विकास मेसिनमा MCP Server चलाउनका लागि आवश्यक छ:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (git_clone_repo उपकरणका लागि आवश्यक)
> - [VS Code](https://code.visualstudio.com/) वा [VS Code Insiders](https://code.visualstudio.com/insiders/) (open_in_vscode उपकरणका लागि आवश्यक)
> - (*वैकल्पिक - यदि तपाईं uv प्रयोग गर्न चाहनुहुन्छ भने*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## वातावरण तयार पार्ने

यस परियोजनाको वातावरण सेटअप गर्न दुई तरिका छन्। तपाईं आफ्नो रुचि अनुसार कुनै एक छान्न सक्नुहुन्छ।

> नोट: भर्चुअल वातावरण सिर्जना गरेपछि VSCode वा टर्मिनल पुनः लोड गर्नुहोस् ताकि भर्चुअल वातावरणको python प्रयोग होस्।

| तरिका | चरणहरू |
| -------- | ----- |
| `uv` प्रयोग गरेर | 1. भर्चुअल वातावरण सिर्जना गर्नुहोस्: `uv venv` <br>2. VSCode कमाण्ड "***Python: Select Interpreter***" चलाएर सिर्जना गरिएको भर्चुअल वातावरणको python छान्नुहोस् <br>3. निर्भरता स्थापना गर्नुहोस् (डेभ निर्भरता सहित): `uv pip install -r pyproject.toml --extra dev` |
| `pip` प्रयोग गरेर | 1. भर्चुअल वातावरण सिर्जना गर्नुहोस्: `python -m venv .venv` <br>2. VSCode कमाण्ड "***Python: Select Interpreter***" चलाएर सिर्जना गरिएको भर्चुअल वातावरणको python छान्नुहोस्<br>3. निर्भरता स्थापना गर्नुहोस् (डेभ निर्भरता सहित): `pip install -e .[dev]` |

वातावरण सेटअप गरेपछि, तपाईं Agent Builder मार्फत MCP Client को रूपमा आफ्नो स्थानीय विकास मेसिनमा सर्भर चलाउन सक्नुहुन्छ:
1. VS Code को Debug प्यानल खोल्नुहोस्। `Debug in Agent Builder` छान्नुहोस् वा `F5` थिचेर MCP सर्भर डिबग सुरु गर्नुहोस्।
2. AI Toolkit Agent Builder प्रयोग गरी [यो प्रॉम्प्ट](../../../../../../../../../../open_prompt_builder) सँग सर्भर परीक्षण गर्नुहोस्। सर्भर स्वचालित रूपमा Agent Builder सँग जडान हुनेछ।
3. प्रॉम्प्टसँग सर्भर परीक्षण गर्न `Run` क्लिक गर्नुहोस्।

**बधाई छ**! तपाईंले सफलतापूर्वक Agent Builder मार्फत MCP Client को रूपमा आफ्नो स्थानीय विकास मेसिनमा Weather MCP Server चलाउनुभयो।
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## टेम्प्लेटमा के समावेश छ

| फोल्डर / फाइल | सामग्रीहरू                                  |
| -------------- | ------------------------------------------ |
| `.vscode`      | डिबगिङका लागि VSCode फाइलहरू               |
| `.aitk`        | AI Toolkit का कन्फिगरेसनहरू                |
| `src`          | Weather MCP Server को स्रोत कोड             |

## Weather MCP Server कसरी डिबग गर्ने

> नोटहरू:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) MCP सर्भरहरू परीक्षण र डिबग गर्नको लागि भिजुअल डेभलपर उपकरण हो।
> - सबै डिबगिङ मोडहरूले ब्रेकपोइन्ट समर्थन गर्छन्, त्यसैले तपाईं उपकरण कार्यान्वयन कोडमा ब्रेकपोइन्ट थप्न सक्नुहुन्छ।

## उपलब्ध उपकरणहरू

### Weather Tool
`get_weather` उपकरणले निर्दिष्ट स्थानको लागि नकली मौसम जानकारी प्रदान गर्छ।

| प्यारामिटर | प्रकार | विवरण |
| --------- | ------ | ------ |
| `location` | string | मौसम जानकारी लिन चाहिएको स्थान (जस्तै, शहरको नाम, राज्य, वा निर्देशाङ्क) |

### Git Clone Tool
`git_clone_repo` उपकरणले git रिपोजिटरीलाई निर्दिष्ट फोल्डरमा क्लोन गर्छ।

| प्यारामिटर | प्रकार | विवरण |
| --------- | ------ | ------ |
| `repo_url` | string | क्लोन गर्नुपर्ने git रिपोजिटरीको URL |
| `target_folder` | string | रिपोजिटरी क्लोन गर्नुपर्ने फोल्डरको पथ |

उपकरणले JSON वस्तु फर्काउँछ जसमा:
- `success`: अपरेशन सफल भयो कि भएन भन्ने बूलियन मान
- `target_folder` वा `error`: क्लोन गरिएको रिपोजिटरीको पथ वा त्रुटि सन्देश

### VS Code Open Tool
`open_in_vscode` उपकरणले फोल्डरलाई VS Code वा VS Code Insiders एप्लिकेसनमा खोल्छ।

| प्यारामिटर | प्रकार | विवरण |
| --------- | ------ | ------ |
| `folder_path` | string | खोल्नुपर्ने फोल्डरको पथ |
| `use_insiders` | boolean (वैकल्पिक) | सामान्य VS Code को सट्टा VS Code Insiders प्रयोग गर्ने कि नगर्ने |

उपकरणले JSON वस्तु फर्काउँछ जसमा:
- `success`: अपरेशन सफल भयो कि भएन भन्ने बूलियन मान
- `message` वा `error`: पुष्टि सन्देश वा त्रुटि सन्देश

## डिबग मोड | विवरण | डिबग गर्ने चरणहरू |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit मार्फत Agent Builder मा MCP सर्भर डिबग गर्ने। | 1. VS Code Debug प्यानल खोल्नुहोस्। `Debug in Agent Builder` छान्नुहोस् र `F5` थिचेर MCP सर्भर डिबग सुरु गर्नुहोस्।<br>2. AI Toolkit Agent Builder प्रयोग गरी [यो प्रॉम्प्ट](../../../../../../../../../../open_prompt_builder) सँग सर्भर परीक्षण गर्नुहोस्। सर्भर स्वचालित रूपमा Agent Builder सँग जडान हुनेछ।<br>3. प्रॉम्प्टसँग सर्भर परीक्षण गर्न `Run` क्लिक गर्नुहोस्। |
| MCP Inspector | MCP Inspector प्रयोग गरी MCP सर्भर डिबग गर्ने। | 1. [Node.js](https://nodejs.org/) स्थापना गर्नुहोस्।<br>2. Inspector सेटअप गर्नुहोस्: `cd inspector` && `npm install` <br>3. VS Code Debug प्यानल खोल्नुहोस्। `Debug SSE in Inspector (Edge)` वा `Debug SSE in Inspector (Chrome)` छान्नुहोस्। `F5` थिचेर डिबग सुरु गर्नुहोस्।<br>4. MCP Inspector ब्राउजरमा खुल्दा, `Connect` बटन थिचेर यो MCP सर्भर जडान गर्नुहोस्।<br>5. त्यसपछि तपाईं `List Tools` गर्न सक्नुहुन्छ, उपकरण छान्न सक्नुहुन्छ, प्यारामिटरहरू प्रविष्ट गर्न सक्नुहुन्छ, र `Run Tool` थिचेर सर्भर कोड डिबग गर्न सक्नुहुन्छ।<br> |

## पूर्वनिर्धारित पोर्टहरू र अनुकूलनहरू

| डिबग मोड | पोर्टहरू | परिभाषाहरू | अनुकूलनहरू | नोट |
| ---------- | -------- | ----------- | ----------- | ---- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | माथिका पोर्टहरू परिवर्तन गर्न [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) सम्पादन गर्नुहोस्। | लागू हुँदैन |
| MCP Inspector | 3001 (सर्भर); 5173 र 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | माथिका पोर्टहरू परिवर्तन गर्न [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) सम्पादन गर्नुहोस्। | लागू हुँदैन |

## प्रतिक्रिया

यदि तपाईंलाई यस टेम्प्लेट सम्बन्धी कुनै प्रतिक्रिया वा सुझाव छ भने, कृपया [AI Toolkit GitHub रिपोजिटरी](https://github.com/microsoft/vscode-ai-toolkit/issues) मा इश्यू खोल्नुहोस्।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।