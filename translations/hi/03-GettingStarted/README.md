<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-13T17:13:43+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hi"
}
-->
## शुरुआत करना  

यह अनुभाग कई पाठों से बना है:

- **1 आपका पहला सर्वर**, इस पहले पाठ में, आप सीखेंगे कि अपना पहला सर्वर कैसे बनाएं और इसे इंस्पेक्टर टूल से जांचें, जो आपके सर्वर को टेस्ट और डिबग करने का एक उपयोगी तरीका है, [पाठ के लिए](01-first-server/README.md)

- **2 क्लाइंट**, इस पाठ में, आप सीखेंगे कि एक ऐसा क्लाइंट कैसे लिखें जो आपके सर्वर से कनेक्ट हो सके, [पाठ के लिए](02-client/README.md)

- **3 LLM के साथ क्लाइंट**, क्लाइंट लिखने का एक बेहतर तरीका है कि उसमें LLM जोड़ें ताकि यह आपके सर्वर के साथ "नेगोशिएट" कर सके कि क्या करना है, [पाठ के लिए](03-llm-client/README.md)

- **4 Visual Studio Code में GitHub Copilot एजेंट मोड के साथ सर्वर का उपयोग करना**। यहाँ, हम Visual Studio Code के अंदर से अपना MCP सर्वर चलाने पर ध्यान दे रहे हैं, [पाठ के लिए](04-vscode/README.md)

- **5 SSE (Server Sent Events) से कंज्यूम करना** SSE एक मानक है जो सर्वर से क्लाइंट तक स्ट्रीमिंग के लिए है, जिससे सर्वर HTTP के माध्यम से क्लाइंट को रियल-टाइम अपडेट भेज सकते हैं [पाठ के लिए](05-sse-server/README.md)

- **6 MCP के साथ HTTP स्ट्रीमिंग (Streamable HTTP)**। आधुनिक HTTP स्ट्रीमिंग, प्रोग्रेस नोटिफिकेशन, और स्केलेबल, रियल-टाइम MCP सर्वर और क्लाइंट को Streamable HTTP के जरिए कैसे लागू करें, इसके बारे में जानें। [पाठ के लिए](06-http-streaming/README.md)

- **7 VSCode के लिए AI Toolkit का उपयोग** अपने MCP क्लाइंट और सर्वर को कंज्यूम और टेस्ट करने के लिए [पाठ के लिए](07-aitk/README.md)

- **8 टेस्टिंग**। यहाँ हम खासतौर पर यह देखेंगे कि हम अपने सर्वर और क्लाइंट को विभिन्न तरीकों से कैसे टेस्ट कर सकते हैं, [पाठ के लिए](08-testing/README.md)

- **9 डिप्लॉयमेंट**। यह अध्याय आपके MCP सॉल्यूशंस को डिप्लॉय करने के विभिन्न तरीकों पर नजर डालेगा, [पाठ के लिए](09-deployment/README.md)


Model Context Protocol (MCP) एक खुला प्रोटोकॉल है जो यह मानकीकृत करता है कि एप्लिकेशन LLMs को संदर्भ कैसे प्रदान करते हैं। MCP को AI एप्लिकेशन के लिए USB-C पोर्ट की तरह समझें - यह AI मॉडल्स को विभिन्न डेटा स्रोतों और टूल्स से जोड़ने का एक मानकीकृत तरीका प्रदान करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- C#, Java, Python, TypeScript, और JavaScript में MCP के लिए विकास पर्यावरण सेटअप करना
- कस्टम फीचर्स (resources, prompts, और tools) के साथ बेसिक MCP सर्वर बनाना और डिप्लॉय करना
- MCP सर्वर से कनेक्ट होने वाले होस्ट एप्लिकेशन बनाना
- MCP इम्प्लीमेंटेशन का टेस्ट और डिबग करना
- सामान्य सेटअप चुनौतियों और उनके समाधान को समझना
- अपने MCP इम्प्लीमेंटेशन को लोकप्रिय LLM सेवाओं से कनेक्ट करना

## अपने MCP पर्यावरण की सेटिंग

MCP के साथ काम शुरू करने से पहले, अपने विकास पर्यावरण को तैयार करना और बुनियादी वर्कफ़्लो को समझना महत्वपूर्ण है। यह अनुभाग आपको प्रारंभिक सेटअप चरणों के माध्यम से मार्गदर्शन करेगा ताकि MCP के साथ एक सहज शुरुआत हो सके।

### आवश्यकताएँ

MCP विकास में उतरने से पहले, सुनिश्चित करें कि आपके पास है:

- **विकास पर्यावरण**: आपकी चुनी हुई भाषा के लिए (C#, Java, Python, TypeScript, या JavaScript)
- **IDE/एडिटर**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, या कोई आधुनिक कोड एडिटर
- **पैकेज मैनेजर**: NuGet, Maven/Gradle, pip, या npm/yarn
- **API Keys**: उन किसी भी AI सेवाओं के लिए जिन्हें आप अपने होस्ट एप्लिकेशन में उपयोग करने वाले हैं


### आधिकारिक SDKs

आगामी अध्यायों में आप Python, TypeScript, Java और .NET का उपयोग करके बनाए गए समाधान देखेंगे। यहाँ सभी आधिकारिक समर्थित SDKs हैं।

MCP कई भाषाओं के लिए आधिकारिक SDKs प्रदान करता है:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft के सहयोग से मेंटेन किया गया
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI के सहयोग से मेंटेन किया गया
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript इम्प्लीमेंटेशन
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python इम्प्लीमेंटेशन
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin इम्प्लीमेंटेशन
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI के सहयोग से मेंटेन किया गया
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust इम्प्लीमेंटेशन

## मुख्य बातें

- MCP विकास पर्यावरण सेटअप भाषा-विशिष्ट SDKs के साथ सरल है
- MCP सर्वर बनाना टूल्स को स्पष्ट स्कीमाओं के साथ बनाना और रजिस्टर करना शामिल है
- MCP क्लाइंट सर्वर और मॉडल से कनेक्ट होकर विस्तारित क्षमताओं का लाभ उठाते हैं
- विश्वसनीय MCP इम्प्लीमेंटेशन के लिए टेस्टिंग और डिबगिंग आवश्यक है
- डिप्लॉयमेंट विकल्प स्थानीय विकास से लेकर क्लाउड-आधारित समाधानों तक होते हैं

## अभ्यास

हमारे पास कुछ सैंपल हैं जो इस अनुभाग के सभी अध्यायों में देखे जाने वाले अभ्यासों को पूरा करते हैं। इसके अलावा प्रत्येक अध्याय के अपने अभ्यास और असाइनमेंट भी हैं।

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधन

- [Azure पर Model Context Protocol का उपयोग करके एजेंट बनाना](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps के साथ रिमोट MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP एजेंट](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## आगे क्या है

अगला: [अपना पहला MCP सर्वर बनाना](01-first-server/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।