<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:17:39+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hi"
}
-->
### -2- प्रोजेक्ट बनाएं

अब जब आपका SDK इंस्टॉल हो चुका है, तो चलिए अगला कदम उठाते हैं और एक प्रोजेक्ट बनाते हैं:  

### -3- प्रोजेक्ट फाइलें बनाएं

### -4- सर्वर कोड बनाएं

### -5- एक टूल और एक रिसोर्स जोड़ना

निम्नलिखित कोड जोड़कर एक टूल और एक रिसोर्स जोड़ें:  

### -6 अंतिम कोड

आइए वह अंतिम कोड जोड़ते हैं जिसकी ज़रूरत है ताकि सर्वर शुरू हो सके:  

### -7- सर्वर का परीक्षण करें

निम्नलिखित कमांड से सर्वर शुरू करें:  

### -8- इंस्पेक्टर का उपयोग करके चलाएं

इंस्पेक्टर एक बेहतरीन टूल है जो आपके सर्वर को शुरू करता है और आपको इसके साथ इंटरैक्ट करने देता है ताकि आप परीक्षण कर सकें कि यह सही काम कर रहा है। चलिए इसे शुरू करते हैं:

> [!NOTE]
> "command" फील्ड में कमांड आपके चुने हुए रनटाइम के अनुसार अलग दिख सकता है।  

आपको निम्नलिखित यूजर इंटरफेस दिखाई देगा:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hi.png)

1. कनेक्ट बटन चुनकर सर्वर से कनेक्ट करें।  
   सर्वर से कनेक्ट होने के बाद आपको निम्नलिखित दिखाई देगा:  

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hi.png)

2. "Tools" और "listTools" चुनें, आपको "Add" दिखाई देगा, "Add" चुनें और पैरामीटर मान भरें।  

   आपको निम्नलिखित प्रतिक्रिया दिखाई देगी, यानी "add" टूल से परिणाम:  

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hi.png)

बधाई हो, आपने अपना पहला सर्वर सफलतापूर्वक बनाया और चलाया!  

### आधिकारिक SDKs

MCP कई भाषाओं के लिए आधिकारिक SDK प्रदान करता है:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft के सहयोग से मेंटेन किया गया
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI के सहयोग से मेंटेन किया गया
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript इम्प्लीमेंटेशन
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python इम्प्लीमेंटेशन
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin इम्प्लीमेंटेशन
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI के सहयोग से मेंटेन किया गया
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust इम्प्लीमेंटेशन

## मुख्य बिंदु

- MCP डेवलपमेंट एनवायरनमेंट सेटअप करना भाषा-विशिष्ट SDKs के साथ सरल है
- MCP सर्वर बनाने में टूल्स बनाना और स्पष्ट स्कीमा के साथ रजिस्टर करना शामिल है
- परीक्षण और डिबगिंग विश्वसनीय MCP इम्प्लीमेंटेशन के लिए आवश्यक हैं

## नमूने

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## असाइनमेंट

अपनी पसंद का एक साधारण MCP सर्वर बनाएं:

1. अपने पसंदीदा भाषा (.NET, Java, Python, या JavaScript) में टूल को इम्प्लीमेंट करें।
2. इनपुट पैरामीटर और रिटर्न मान परिभाषित करें।
3. इंस्पेक्टर टूल चलाएं ताकि सुनिश्चित हो सके कि सर्वर सही काम कर रहा है।
4. विभिन्न इनपुट के साथ इम्प्लीमेंटेशन का परीक्षण करें।

## समाधान

[समाधान](./solution/README.md)

## अतिरिक्त संसाधन

- [Azure पर Model Context Protocol का उपयोग करके एजेंट बनाएं](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps के साथ रिमोट MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP एजेंट](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## आगे क्या है

अगला: [MCP क्लाइंट के साथ शुरुआत](/03-GettingStarted/02-client/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।