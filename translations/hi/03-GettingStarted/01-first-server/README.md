<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T16:56:56+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hi"
}
-->
### -2- प्रोजेक्ट बनाएँ

अब जब आपका SDK इंस्टॉल हो चुका है, तो अगला कदम प्रोजेक्ट बनाना है:

### -3- प्रोजेक्ट फाइलें बनाएँ

### -4- सर्वर कोड बनाएँ

### -5- एक टूल और एक रिसोर्स जोड़ना

निम्नलिखित कोड जोड़कर एक टूल और एक रिसोर्स जोड़ें:

### -6- अंतिम कोड

सर्वर शुरू करने के लिए आवश्यक अंतिम कोड जोड़ें:

### -7- सर्वर का परीक्षण करें

निम्नलिखित कमांड के साथ सर्वर शुरू करें:

### -8- इंस्पेक्टर का उपयोग करके चलाएँ

इंस्पेक्टर एक शानदार टूल है जो आपके सर्वर को शुरू करता है और आपको इसके साथ इंटरैक्ट करने देता है ताकि आप यह जांच सकें कि यह सही से काम कर रहा है। इसे शुरू करें:

> [!NOTE]
> "command" फ़ील्ड में यह अलग दिख सकता है क्योंकि इसमें आपके विशेष रनटाइम के लिए सर्वर चलाने का कमांड होता है।

आपको निम्नलिखित यूजर इंटरफेस दिखेगा:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hi.png)

1. कनेक्ट बटन चुनकर सर्वर से कनेक्ट करें  
   एक बार जब आप सर्वर से कनेक्ट हो जाते हैं, तो आपको निम्नलिखित दिखेगा:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hi.png)

2. "Tools" और "listTools" चुनें, आपको "Add" दिखाई देगा, "Add" चुनें और पैरामीटर मान भरें।

   आपको निम्नलिखित प्रतिक्रिया मिलेगी, यानी "add" टूल का परिणाम:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hi.png)

बधाई हो, आपने अपना पहला सर्वर सफलतापूर्वक बनाया और चलाया है!

### आधिकारिक SDKs

MCP कई भाषाओं के लिए आधिकारिक SDKs प्रदान करता है:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft के सहयोग से मेंटेन किया गया  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI के सहयोग से मेंटेन किया गया  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript इम्प्लीमेंटेशन  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python इम्प्लीमेंटेशन  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin इम्प्लीमेंटेशन  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI के सहयोग से मेंटेन किया गया  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust इम्प्लीमेंटेशन  

## मुख्य बातें

- MCP विकास वातावरण स्थापित करना भाषा-विशिष्ट SDKs के साथ सरल है  
- MCP सर्वर बनाने में स्पष्ट स्कीमाओं के साथ टूल बनाना और रजिस्टर करना शामिल है  
- परीक्षण और डिबगिंग विश्वसनीय MCP इम्प्लीमेंटेशन के लिए आवश्यक हैं  

## सैंपल्स

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## असाइनमेंट

अपने पसंदीदा टूल के साथ एक सरल MCP सर्वर बनाएं:  
1. अपने पसंदीदा भाषा (.NET, Java, Python, या JavaScript) में टूल इम्प्लीमेंट करें।  
2. इनपुट पैरामीटर और रिटर्न वैल्यू परिभाषित करें।  
3. सर्वर के सही काम करने की पुष्टि के लिए इंस्पेक्टर टूल चलाएं।  
4. विभिन्न इनपुट के साथ इम्प्लीमेंटेशन का परीक्षण करें।  

## समाधान

[समाधान](./solution/README.md)  

## अतिरिक्त संसाधन

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)  

## आगे क्या

अगला: [MCP क्लाइंट्स के साथ शुरुआत](/03-GettingStarted/02-client/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या गलतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।