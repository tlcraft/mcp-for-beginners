<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T16:58:17+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ne"
}
-->
### -2- परियोजना सिर्जना गर्नुहोस्

अब तपाईंले आफ्नो SDK स्थापना गर्नुभएको छ, अब परियोजना सिर्जना गरौं: 

### -3- परियोजना फाइलहरू सिर्जना गर्नुहोस्

### -4- सर्भर कोड सिर्जना गर्नुहोस्

### -5- एउटा टुल र एउटा स्रोत थप्नुहोस्

तलको कोड थपेर एउटा टुल र एउटा स्रोत थप्नुहोस्: 

### -6 अन्तिम कोड

सर्भर सुरु गर्नको लागि आवश्यक अन्तिम कोड थपौं: 

### -7- सर्भर परीक्षण गर्नुहोस्

तलको कमाण्ड प्रयोग गरी सर्भर सुरु गर्नुहोस्: 

### -8- इन्स्पेक्टर प्रयोग गरी चलाउनुहोस्

इन्स्पेक्टर एउटा उत्कृष्ट उपकरण हो जसले तपाईंको सर्भर सुरु गरी त्यससँग अन्तरक्रिया गर्न दिन्छ ताकि तपाईं यसको कार्यक्षमता परीक्षण गर्न सक्नुहुन्छ। यसलाई सुरु गरौं:

> [!NOTE]
> "command" फिल्डमा देखिने कुरा फरक हुन सक्छ किनभने यसले तपाईंको विशेष रनटाइमका लागि सर्भर चलाउने कमाण्ड समावेश गर्दछ।

तपाईंले निम्न प्रयोगकर्ता अन्तरफलक देख्नु पर्नेछ:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ne.png)

1. Connect बटन थिचेर सर्भरसँग जडान गर्नुहोस्। सर्भरसँग जडान भएपछि, तपाईंले निम्न देख्नु पर्नेछ:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ne.png)

2. "Tools" र "listTools" चयन गर्नुहोस्, तपाईंले "Add" देख्नु हुनेछ, "Add" चयन गरी प्यारामिटर मानहरू भर्नुहोस्।

  तपाईंले निम्न प्रतिक्रिया देख्नु पर्नेछ, अर्थात् "add" टुलबाट प्राप्त नतिजा:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ne.png)

बधाई छ, तपाईंले आफ्नो पहिलो सर्भर सफलतापूर्वक सिर्जना र चलाउनुभयो!

### आधिकारिक SDK हरू

MCP ले विभिन्न भाषाहरूका लागि आधिकारिक SDK हरू प्रदान गर्दछ:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सँग सहकार्यमा मर्मत गरिएको
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सँग सहकार्यमा मर्मत गरिएको
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript कार्यान्वयन
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python कार्यान्वयन
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin कार्यान्वयन
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सँग सहकार्यमा मर्मत गरिएको
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust कार्यान्वयन

## मुख्य सिकाइहरू

- MCP विकास वातावरण सेटअप भाषा-विशिष्ट SDK हरूको साथ सजिलो छ
- MCP सर्भरहरू बनाउन स्पष्ट स्कीमा सहितका टुलहरू सिर्जना र दर्ता गर्नुपर्छ
- परीक्षण र डिबगिङ MCP कार्यान्वयनहरूको विश्वसनीयताका लागि आवश्यक छ

## नमूनाहरू

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## कार्य

आफ्नो रोजाइको एउटा टुल सहित सरल MCP सर्भर सिर्जना गर्नुहोस्:
1. आफ्नो मनपर्ने भाषामा टुल कार्यान्वयन गर्नुहोस् (.NET, Java, Python, वा JavaScript).
2. इनपुट प्यारामिटरहरू र रिटर्न मानहरू परिभाषित गर्नुहोस्।
3. सर्भरले ठीकसँग काम गर्छ कि गर्दैन भनेर सुनिश्चित गर्न इन्स्पेक्टर टुल चलाउनुहोस्।
4. विभिन्न इनपुटहरूसँग कार्यान्वयन परीक्षण गर्नुहोस्।

## समाधान

[Solution](./solution/README.md)

## अतिरिक्त स्रोतहरू

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## अब के गर्ने

अर्को: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी सटीकता सुनिश्चित गर्न प्रयास गर्छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा गलत जानकारी हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।