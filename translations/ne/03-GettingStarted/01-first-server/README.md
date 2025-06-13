<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T05:57:02+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ne"
}
-->
### -2- प्रोजेक्ट सिर्जना गर्नुहोस्

अब तपाईंले आफ्नो SDK स्थापना गर्नुभएको छ, अब प्रोजेक्ट सिर्जना गरौं: 

### -3- प्रोजेक्ट फाइलहरू सिर्जना गर्नुहोस्

### -4- सर्भर कोड सिर्जना गर्नुहोस्

### -5- टूल र स्रोत थप्दै

तलको कोड थपेर एउटा टूल र एउटा स्रोत थप्नुहोस्: 

### -6 अन्तिम कोड

सर्भर सुरु गर्नका लागि आवश्यक अन्तिम कोड थपौं: 

### -7- सर्भर परीक्षण गर्नुहोस्

तलको कमाण्ड प्रयोग गरेर सर्भर सुरु गर्नुहोस्: 

### -8- इन्स्पेक्टर प्रयोग गर्दै चलाउनुहोस्

इन्स्पेक्टर एउटा राम्रो उपकरण हो जसले तपाईंको सर्भर सुरु गर्छ र तपाईंलाई त्यससँग अन्तरक्रिया गर्न दिन्छ ताकि तपाईं परीक्षण गर्न सक्नुहुन्छ कि यो काम गर्छ कि गर्दैन। सुरु गरौं:

> [!NOTE]
> यो "command" फिल्डमा फरक देखिन सक्छ किनभने यसले तपाईंको विशेष रनटाइमसँग सर्भर चलाउने कमाण्ड समावेश गर्दछ। 

तपाईंले निम्न प्रयोगकर्ता अन्तरफलक देख्नु पर्नेछ:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ne.png)

1. Connect बटन थिचेर सर्भरसँग जडान हुनुहोस्। सर्भरसँग जडान भएपछि तपाईंले तलको दृश्य देख्नु पर्नेछ:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ne.png)

2. "Tools" र "listTools" चयन गर्नुहोस्, तपाईंले "Add" देख्नु पर्नेछ, "Add" चयन गरेर प्यारामिटर मानहरू भर्नुहोस्।

  तपाईंले तलको प्रतिक्रिया देख्नु पर्नेछ, अर्थात् "add" टूलबाट नतिजा:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ne.png)

बधाई छ, तपाईंले आफ्नो पहिलो सर्भर सिर्जना गरी चलाउन सफल हुनुभयो!

### आधिकारिक SDK हरू

MCP ले विभिन्न भाषाहरूका लागि आधिकारिक SDK हरू प्रदान गर्दछ:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सँगको सहकार्यमा मर्मत गरिएको
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सँगको सहकार्यमा मर्मत गरिएको
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript कार्यान्वयन
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python कार्यान्वयन
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin कार्यान्वयन
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सँगको सहकार्यमा मर्मत गरिएको
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust कार्यान्वयन

## मुख्य बुँदाहरू

- MCP विकास वातावरण सेटअप गर्न भाषा-विशेष SDK हरूले सजिलो बनाउँछन्
- MCP सर्भरहरू बनाउँदा स्पष्ट स्किमासँग टूलहरू सिर्जना र दर्ता गर्नुपर्छ
- परीक्षण र डिबगिङ विश्वसनीय MCP कार्यान्वयनका लागि अत्यावश्यक छन्

## नमूनाहरू

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## कार्य

आफ्नो रोजाइको टूल सहित सरल MCP सर्भर सिर्जना गर्नुहोस्:
1. मनपर्ने भाषामा टूल कार्यान्वयन गर्नुहोस् (.NET, Java, Python, वा JavaScript).
2. इनपुट प्यारामिटर र रिटर्न मानहरू परिभाषित गर्नुहोस्।
3. सर्भरले ठीकसँग काम गर्छ कि गर्दैन जाँच्न इन्स्पेक्टर टूल चलाउनुहोस्।
4. विभिन्न इनपुटहरूसँग कार्यान्वयन परीक्षण गर्नुहोस्।

## समाधान

[Solution](./solution/README.md)

## थप स्रोतहरू

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## अर्को के छ

अर्को: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरेर अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया जानकार हुनुस् कि स्वचालित अनुवादमा त्रुटि वा असत्यता हुनसक्छ। मूल दस्तावेजलाई यसको मातृभाषामा आधिकारिक स्रोतको रूपमा मान्नुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।