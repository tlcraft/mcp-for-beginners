<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:25:22+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hi"
}
-->
### -2- प्रोजेक्ट बनाएं

अब जब आपका SDK इंस्टॉल हो चुका है, तो अगला कदम प्रोजेक्ट बनाना है: 

### -3- प्रोजेक्ट फाइलें बनाएं

### -4- सर्वर कोड बनाएं

### -5- एक टूल और एक रिसोर्स जोड़ना

निम्नलिखित कोड जोड़कर एक टूल और एक रिसोर्स जोड़ें:

### -6- अंतिम कोड

आइए वह अंतिम कोड जोड़ें जिससे सर्वर स्टार्ट हो सके:

### -7- सर्वर का परीक्षण करें

निम्नलिखित कमांड से सर्वर शुरू करें:

### -8- इंस्पेक्टर का उपयोग करें

इंस्पेक्टर एक बेहतरीन टूल है जो आपके सर्वर को शुरू करता है और आपको इसके साथ इंटरैक्ट करने देता है ताकि आप टेस्ट कर सकें कि यह सही काम कर रहा है या नहीं। चलिए इसे शुरू करते हैं:

> [!NOTE]
> "command" फ़ील्ड में यह थोड़ा अलग दिख सकता है क्योंकि इसमें आपके खास रनटाइम के लिए सर्वर चलाने का कमांड होता है।

आपको निम्नलिखित यूजर इंटरफेस दिखाई देगा:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hi.png)

1. कनेक्ट बटन चुनकर सर्वर से कनेक्ट करें  
  एक बार जब आप सर्वर से कनेक्ट हो जाते हैं, तो आपको निम्नलिखित दिखेगा:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hi.png)

2. "Tools" और "listTools" चुनें, आपको "Add" दिखेगा, "Add" चुनें और पैरामीटर मान भरें।

  आपको निम्नलिखित प्रतिक्रिया मिलेगी, यानी "add" टूल का परिणाम:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hi.png)

बधाई हो, आपने अपना पहला सर्वर सफलतापूर्वक बनाया और चलाया है!

### आधिकारिक SDKs

MCP कई भाषाओं के लिए आधिकारिक SDKs प्रदान करता है:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft के साथ सहयोग में मेंटेन किया गया
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI के साथ सहयोग में मेंटेन किया गया
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript इम्प्लीमेंटेशन
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python इम्प्लीमेंटेशन
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin इम्प्लीमेंटेशन
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI के साथ सहयोग में मेंटेन किया गया
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust इम्प्लीमेंटेशन

## मुख्य बातें

- MCP डेवलपमेंट एनवायरनमेंट सेटअप करना भाषा-विशिष्ट SDKs के साथ आसान है
- MCP सर्वर बनाने में स्पष्ट स्कीमाओं के साथ टूल्स बनाना और रजिस्टर करना शामिल है
- परीक्षण और डिबगिंग विश्वसनीय MCP इम्प्लीमेंटेशन के लिए आवश्यक हैं

## सैंपल्स

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## असाइनमेंट

अपने पसंदीदा टूल के साथ एक सरल MCP सर्वर बनाएं:
1. टूल को अपनी पसंदीदा भाषा (.NET, Java, Python, या JavaScript) में इम्प्लीमेंट करें।
2. इनपुट पैरामीटर और रिटर्न वैल्यूज को परिभाषित करें।
3. सुनिश्चित करने के लिए इंस्पेक्टर टूल चलाएं कि सर्वर ठीक से काम कर रहा है।
4. विभिन्न इनपुट्स के साथ इम्प्लीमेंटेशन का परीक्षण करें।

## समाधान

[Solution](./solution/README.md)

## अतिरिक्त संसाधन

- [Azure पर Model Context Protocol का उपयोग करके एजेंट बनाएं](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps के साथ Remote MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## अगला कदम

अगला: [MCP क्लाइंट्स के साथ शुरुआत](/03-GettingStarted/02-client/README.md)

**अस्वीकरण**:  
इस दस्तावेज़ का अनुवाद AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।