<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:27:50+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "ne"
}
-->
# Weather MCP Server

यो Python मा लेखिएको एक नमूना MCP Server हो जसले मौसम उपकरणहरूलाई नकली प्रतिक्रियासँग कार्यान्वयन गर्दछ। यसलाई तपाईंको आफ्नै MCP Server को आधारको रूपमा प्रयोग गर्न सकिन्छ। यसमा निम्न सुविधाहरू समावेश छन्:

- **Weather Tool**: दिइएको स्थानको आधारमा नकली मौसम जानकारी प्रदान गर्ने उपकरण।
- **Agent Builder सँग जडान**: MCP server लाई परीक्षण र डिबगिङका लागि Agent Builder सँग जडान गर्ने सुविधा।
- **[MCP Inspector](https://github.com/modelcontextprotocol/inspector) मा डिबग गर्नुहोस्**: MCP Server लाई MCP Inspector प्रयोग गरेर डिबग गर्ने सुविधा।

## Weather MCP Server टेम्प्लेटसँग सुरु गर्नुहोस्

> **आवश्यकताहरू**
>
> तपाईंको स्थानीय विकास मेसिनमा MCP Server चलाउनका लागि आवश्यक छ:
>
> - [Python](https://www.python.org/)
> - (*वैकल्पिक - यदि तपाईं uv रोज्नुहुन्छ भने*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## वातावरण तयार गर्नुहोस्

यस प्रोजेक्टको वातावरण सेटअप गर्न दुई तरिकाहरू छन्। तपाईं आफ्नो रुचि अनुसार कुनै एक छनौट गर्न सक्नुहुन्छ।

> Note: भर्चुअल वातावरण बनाएपछि भर्चुअल वातावरणको python प्रयोग भइरहेको छ भनेर सुनिश्चित गर्न VSCode वा टर्मिनल पुनः लोड गर्नुहोस्।

| तरिका | चरणहरू |
| -------- | ----- |
| Using `uv` | 1. भर्चुअल वातावरण बनाउनुहोस्: `uv venv` <br>2. VSCode Command "***Python: Select Interpreter***" चलाएर बनाएको भर्चुअल वातावरणको python चयन गर्नुहोस् <br>3. निर्भरता (डेभ निर्भरता सहित) स्थापना गर्नुहोस्: `uv pip install -r pyproject.toml --extra dev` |
| Using `pip` | 1. भर्चुअल वातावरण बनाउनुहोस्: `python -m venv .venv` <br>2. VSCode Command "***Python: Select Interpreter***" चलाएर बनाएको भर्चुअल वातावरणको python चयन गर्नुहोस्<br>3. निर्भरता (डेभ निर्भरता सहित) स्थापना गर्नुहोस्: `pip install -e .[dev]` | 

वातावरण सेटअप गरेपछि, तपाईं आफ्नो स्थानीय विकास मेसिनमा Agent Builder लाई MCP Client को रूपमा प्रयोग गरी सर्भर चलाउन सक्नुहुन्छ:
1. VS Code को Debug प्यानल खोल्नुहोस्। MCP server डिबग गर्न `Debug in Agent Builder` चयन गर्नुहोस् वा `F5` थिच्नुहोस्।
2. AI Toolkit Agent Builder प्रयोग गरेर [यस प्रॉम्प्ट](../../../../../../../../../../../open_prompt_builder) मार्फत सर्भर परीक्षण गर्नुहोस्। सर्भर स्वतः Agent Builder सँग जडान हुनेछ।
3. प्रॉम्प्टसँग सर्भर परीक्षण गर्न `Run` क्लिक गर्नुहोस्।

**बधाई छ**! तपाईंले सफलतापूर्वक स्थानीय विकास मेसिनमा Agent Builder मार्फत MCP Client को रूपमा Weather MCP Server चलाउनुभयो।
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## टेम्प्लेटमा के समावेश छ

| फोल्डर / फाइल | सामग्रीहरू                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | डिबगिङका लागि VSCode फाइलहरू                   |
| `.aitk`      | AI Toolkit का लागि कन्फिगरेसनहरू                |
| `src`        | weather mcp server को स्रोत कोड   |

## Weather MCP Server कसरी डिबग गर्ने

> नोटहरू:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) MCP server हरूको परीक्षण र डिबगिङका लागि भिजुअल विकास उपकरण हो।
> - सबै डिबगिङ मोडहरूले ब्रेकप्वाइन्ट समर्थन गर्दछन्, त्यसैले तपाईं उपकरण कार्यान्वयन कोडमा ब्रेकप्वाइन्टहरू थप्न सक्नुहुन्छ।

| डिबग मोड | विवरण | डिबग गर्ने चरणहरू |
| ---------- | ----------- | --------------- |
| Agent Builder | AI Toolkit मार्फत Agent Builder मा MCP server डिबग गर्नुहोस्। | 1. VS Code Debug प्यानल खोल्नुहोस्। MCP server डिबग गर्न `Debug in Agent Builder` चयन गरी `F5` थिच्नुहोस्।<br>2. AI Toolkit Agent Builder प्रयोग गरेर [यस प्रॉम्प्ट](../../../../../../../../../../../open_prompt_builder) बाट सर्भर परीक्षण गर्नुहोस्। सर्भर स्वतः Agent Builder सँग जडान हुनेछ।<br>3. प्रॉम्प्टसँग सर्भर परीक्षण गर्न `Run` क्लिक गर्नुहोस्। |
| MCP Inspector | MCP Inspector प्रयोग गरेर MCP server डिबग गर्नुहोस्। | 1. [Node.js](https://nodejs.org/) स्थापना गर्नुहोस्।<br> 2. Inspector सेटअप गर्नुहोस्: `cd inspector` && `npm install` <br> 3. VS Code Debug प्यानल खोल्नुहोस्। `Debug SSE in Inspector (Edge)` वा `Debug SSE in Inspector (Chrome)` चयन गर्नुहोस्। F5 थिचेर डिबग सुरु गर्नुहोस्।<br> 4. MCP Inspector ब्राउजरमा खुल्दा, यो MCP server सँग जडान गर्न `Connect` बटन क्लिक गर्नुहोस्।<br> 5. त्यसपछि तपाईं `List Tools`, उपकरण चयन गर्नुहोस्, प्यारामिटरहरू इनपुट गर्नुहोस्, र `Run Tool` गरेर आफ्नो सर्भर कोड डिबग गर्न सक्नुहुन्छ।<br> |

## पूर्वनिर्धारित पोर्टहरू र अनुकूलनहरू

| डिबग मोड | पोर्टहरू | परिभाषाहरू | अनुकूलनहरू | नोट |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | माथिका पोर्टहरू परिवर्तन गर्न [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) सम्पादन गर्नुहोस्। | लागू हुँदैन |
| MCP Inspector | 3001 (Server); 5173 र 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | माथिका पोर्टहरू परिवर्तन गर्न [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) सम्पादन गर्नुहोस्। | लागू हुँदैन |

## प्रतिक्रिया

यदि तपाईंसँग यस टेम्प्लेटको लागि कुनै प्रतिक्रिया वा सुझावहरू छन् भने, कृपया [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues) मा issue खोल्नुहोस्।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयास गर्छौं, तर कृपया जान्नुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा असत्यताहरू हुनसक्छन्। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।