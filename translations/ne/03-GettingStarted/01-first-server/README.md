<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:31:43+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ne"
}
-->
### -2- परियोजना सिर्जना गर्नुहोस्

अब तपाईंले आफ्नो SDK स्थापना गर्नुभयो, अब परियोजना सिर्जना गरौं: 

### -3- परियोजना फाइलहरू सिर्जना गर्नुहोस्

### -4- सर्भर कोड सिर्जना गर्नुहोस्

### -5- एउटा उपकरण र स्रोत थप्दै

तलको कोड थपेर एउटा उपकरण र स्रोत थप्नुहोस्: 

### -6 अन्तिम कोड

सर्भर सुरु गर्न आवश्यक अन्तिम कोड थपौं: 

### -7- सर्भर परीक्षण गर्नुहोस्

तलको कमाण्ड प्रयोग गरेर सर्भर सुरु गर्नुहोस्: 

### -8- इन्स्पेक्टर प्रयोग गरेर चलाउनुहोस्

इन्स्पेक्टर एक उत्कृष्ट उपकरण हो जसले तपाईंको सर्भर सुरु गर्छ र तपाईंलाई त्यससँग अन्तरक्रिया गर्न दिन्छ ताकि तपाईं परीक्षण गर्न सक्नुहुनेछ कि यो काम गर्छ कि गर्दैन। सुरु गरौं:

> [!NOTE]
> "command" फिल्डमा कमाण्ड तपाईंको विशिष्ट रनटाइम अनुसार फरक देखिन सक्छ

तपाईंले तलको प्रयोगकर्ता इन्टरफेस देख्नुहुनेछ:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ne.png)

1. कनेक्ट बटन छानेर सर्भरमा जडान हुनुहोस्  
  सर्भरमा जडान भएपछि, तपाईंले तलको देख्नुहुनेछ:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ne.png)

1. "Tools" र "listTools" छान्नुहोस्, तपाईंले "Add" देख्नुहुनेछ, "Add" छान्नुहोस् र प्यारामिटर मानहरू भर्नुहोस्।

  तपाईंले तलको प्रतिक्रिया देख्नुहुनेछ, अर्थात् "add" उपकरणबाट नतिजा:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ne.png)

बधाई छ, तपाईंले आफ्नो पहिलो सर्भर सफलतापूर्वक सिर्जना र चलाउनुभयो!

### आधिकारिक SDK हरू

MCP ले विभिन्न भाषाहरूका लागि आधिकारिक SDK हरू प्रदान गर्छ:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सँगको सहकार्यमा मर्मत गरिएको
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सँगको सहकार्यमा मर्मत गरिएको
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript कार्यान्वयन
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python कार्यान्वयन
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin कार्यान्वयन
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सँगको सहकार्यमा मर्मत गरिएको
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust कार्यान्वयन

## मुख्य सिकाइहरू

- MCP विकास वातावरण सेटअप भाषा-विशेष SDK हरूको साथ सजिलो छ
- MCP सर्भरहरू निर्माण गर्दा स्पष्ट स्कीमाहरू सहित उपकरणहरू सिर्जना र दर्ता गर्नुपर्छ
- परीक्षण र डिबगिङ विश्वसनीय MCP कार्यान्वयनका लागि आवश्यक छ

## नमूनाहरू

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## असाइनमेन्ट

तपाईंको रोजाइको उपकरण सहित एक सरल MCP सर्भर सिर्जना गर्नुहोस्:
1. तपाईंको मनपर्ने भाषामा उपकरण कार्यान्वयन गर्नुहोस् (.NET, Java, Python, वा JavaScript)।
2. इनपुट प्यारामिटरहरू र फर्कने मानहरू परिभाषित गर्नुहोस्।
3. इन्स्पेक्टर उपकरण चलाएर सर्भर ठीकसँग काम गर्छ कि गर्दैन जाँच गर्नुहोस्।
4. विभिन्न इनपुटहरूसँग कार्यान्वयन परीक्षण गर्नुहोस्।

## समाधान

[Solution](./solution/README.md)

## अतिरिक्त स्रोतहरू

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## के अगाडि

अर्को: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा असंगतता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानवीय अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।