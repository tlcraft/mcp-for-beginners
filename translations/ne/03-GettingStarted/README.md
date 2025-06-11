<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:05:56+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ne"
}
-->
## Getting Started  

यस सेक्सनमा केही पाठहरू समावेश छन्:

- **1 Your first server**, यस पहिलो पाठमा, तपाईंले आफ्नो पहिलो सर्भर कसरी बनाउने र inspector tool मार्फत त्यसलाई कसरी निरीक्षण गर्ने सिक्नुहुनेछ, जुन तपाईंको सर्भर परीक्षण र डिबग गर्न एक उपयोगी तरिका हो, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, यस पाठमा, तपाईंले आफ्नो सर्भरमा जडान गर्न सक्ने client कसरी लेख्ने सिक्नुहुनेछ, [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**, client लेख्ने अझ राम्रो तरिका भनेको यसमा LLM थप्नु हो जसले तपाईंको सर्भरसँग के गर्ने भनेर "बातचीत" गर्न सक्छ, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**। यहाँ, हामी Visual Studio Code भित्रबाट हाम्रो MCP Server कसरी चलाउने हेरिरहेका छौं, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE एउटा server-to-client streaming को standard हो, जसले सर्भरलाई HTTP मार्फत क्लाइन्टहरूलाई real-time अपडेट पठाउन अनुमति दिन्छ [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 Utilising AI Toolkit for VSCode** तपाइँका MCP Clients र Servers लाई consume र test गर्न [to the lesson](/03-GettingStarted/06-aitk/README.md)

- **7 Testing**। यहाँ हामी विशेष गरी हाम्रो सर्भर र client लाई विभिन्न तरिकाले कसरी test गर्नेमा ध्यान दिनेछौं, [to the lesson](/03-GettingStarted/07-testing/README.md)

- **8 Deployment**। यस अध्यायले तपाईंका MCP समाधानहरू deployment गर्ने विभिन्न तरिकाहरू हेरिनेछ, [to the lesson](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) एउटा खुल्ला protocol हो जसले applications लाई LLMs लाई context प्रदान गर्ने तरिका standardize गर्छ। MCP लाई AI applications का लागि USB-C पोर्ट जस्तै सोच्नुहोस् - यसले AI मोडेलहरूलाई विभिन्न डेटा स्रोत र उपकरणहरूसँग जडान गर्ने standard तरिका प्रदान गर्छ।

## Learning Objectives

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- C#, Java, Python, TypeScript, र JavaScript मा MCP को लागि development environment सेटअप गर्न
- custom features (resources, prompts, र tools) सहित basic MCP servers बनाउने र deploy गर्ने
- MCP servers सँग जडान गर्ने host applications सिर्जना गर्ने
- MCP implementations लाई test र debug गर्ने
- सामान्य setup चुनौतीहरू र तिनीहरूको समाधान बुझ्ने
- तपाईंका MCP implementations लाई लोकप्रिय LLM सेवाहरू सँग जडान गर्ने

## Setting Up Your MCP Environment

MCP सँग काम गर्न सुरु गर्नु अघि, तपाईंको development environment तयार पार्नु र आधारभूत workflow बुझ्नु महत्वपूर्ण छ। यस सेक्सनले सुरुवातका setup चरणहरूमा तपाईंलाई मार्गदर्शन गर्नेछ ताकि MCP सँग सहज सुरुवात होस्।

### Prerequisites

MCP विकासमा डुब्नुअघि, सुनिश्चित गर्नुहोस् कि तपाईंसँग छ:

- **Development Environment**: तपाईंले रोजेको भाषा (C#, Java, Python, TypeScript, वा JavaScript) को लागि
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, वा कुनै आधुनिक कोड सम्पादक
- **Package Managers**: NuGet, Maven/Gradle, pip, वा npm/yarn
- **API Keys**: तपाईंको host applications मा प्रयोग गर्ने कुनै पनि AI सेवाहरूको लागि


### Official SDKs

आउँदो अध्यायहरूमा तपाईं Python, TypeScript, Java र .NET प्रयोग गरेर बनेका समाधानहरू देख्नुहुनेछ। यहाँ सबै आधिकारिक रूपमा समर्थित SDK हरू छन्।

MCP ले धेरै भाषाहरूको लागि आधिकारिक SDK हरू प्रदान गर्छ:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सँग सहकार्यमा मर्मत गरिएको
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सँग सहकार्यमा मर्मत गरिएको
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript कार्यान्वयन
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python कार्यान्वयन
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin कार्यान्वयन
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सँग सहकार्यमा मर्मत गरिएको
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust कार्यान्वयन

## Key Takeaways

- MCP विकास environment सेटअप भाषा-विशिष्ट SDK हरूको साथ सजिलो छ
- MCP servers निर्माण गर्दा स्पष्ट schema सहित उपकरणहरू सिर्जना र दर्ता गर्ने समावेश हुन्छ
- MCP clients सर्भर र मोडेलहरूसँग जडान भएर विस्तारित क्षमता प्रयोग गर्छन्
- भरोसायोग्य MCP implementations को लागि testing र debugging आवश्यक छ
- Deployment विकल्पहरू स्थानीय विकासदेखि क्लाउड आधारित समाधानसम्म फरक हुन्छन्

## Practicing

हामीसँग केही नमूनाहरू छन् जुन यस सेक्सनका सबै अध्यायहरूमा देखिने अभ्यासहरूलाई पूरक गर्छ। थप रूपमा प्रत्येक अध्यायमा आफ्नै अभ्यास र असाइनमेन्टहरू पनि छन्

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

Next: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। मूल दस्तावेज़ यसको मातृ भाषामा आधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।