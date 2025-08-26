<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1197b6dbde36773e04a5ae826557fdb9",
  "translation_date": "2025-08-26T17:26:01+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hi"
}
-->
## शुरुआत करें  

[![अपना पहला MCP सर्वर बनाएं](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.hi.png)](https://youtu.be/sNDZO9N4m9Y)

_(ऊपर दी गई छवि पर क्लिक करें इस पाठ का वीडियो देखने के लिए)_

यह अनुभाग कई पाठों से बना है:

- **1 आपका पहला सर्वर**, इस पहले पाठ में, आप सीखेंगे कि अपना पहला सर्वर कैसे बनाएं और इसे इंस्पेक्टर टूल के साथ जांचें, जो आपके सर्वर का परीक्षण और डिबग करने का एक मूल्यवान तरीका है, [पाठ पर जाएं](01-first-server/README.md)

- **2 क्लाइंट**, इस पाठ में, आप सीखेंगे कि ऐसा क्लाइंट कैसे लिखें जो आपके सर्वर से कनेक्ट हो सके, [पाठ पर जाएं](02-client/README.md)

- **3 LLM के साथ क्लाइंट**, क्लाइंट लिखने का एक और बेहतर तरीका यह है कि इसमें LLM जोड़ें ताकि यह आपके सर्वर के साथ "बातचीत" कर सके कि क्या करना है, [पाठ पर जाएं](03-llm-client/README.md)

- **4 GitHub Copilot Agent मोड में Visual Studio Code के साथ सर्वर का उपयोग करना**। यहां, हम Visual Studio Code के भीतर से अपना MCP सर्वर चलाने पर ध्यान देंगे, [पाठ पर जाएं](04-vscode/README.md)

- **5 stdio Transport Server** stdio ट्रांसपोर्ट वर्तमान विनिर्देश में MCP सर्वर-से-क्लाइंट संचार के लिए अनुशंसित मानक है, जो सुरक्षित सबप्रोसेस-आधारित संचार प्रदान करता है [पाठ पर जाएं](05-stdio-server/README.md)

- **6 MCP के साथ HTTP स्ट्रीमिंग (स्ट्रीम करने योग्य HTTP)**। आधुनिक HTTP स्ट्रीमिंग, प्रगति सूचनाओं, और स्ट्रीम करने योग्य HTTP का उपयोग करके स्केलेबल, रीयल-टाइम MCP सर्वर और क्लाइंट को लागू करने के तरीके के बारे में जानें। [पाठ पर जाएं](06-http-streaming/README.md)

- **7 VSCode के लिए AI टूलकिट का उपयोग करना** MCP क्लाइंट और सर्वर का उपभोग और परीक्षण करने के लिए [पाठ पर जाएं](07-aitk/README.md)

- **8 परीक्षण**। यहां हम विशेष रूप से इस पर ध्यान केंद्रित करेंगे कि हम अपने सर्वर और क्लाइंट का विभिन्न तरीकों से परीक्षण कैसे कर सकते हैं, [पाठ पर जाएं](08-testing/README.md)

- **9 परिनियोजन**। यह अध्याय आपके MCP समाधानों को परिनियोजित करने के विभिन्न तरीकों पर चर्चा करेगा, [पाठ पर जाएं](09-deployment/README.md)

Model Context Protocol (MCP) एक ओपन प्रोटोकॉल है जो यह मानकीकृत करता है कि एप्लिकेशन LLMs को संदर्भ कैसे प्रदान करते हैं। MCP को AI एप्लिकेशन के लिए USB-C पोर्ट की तरह समझें - यह AI मॉडल को विभिन्न डेटा स्रोतों और टूल्स से कनेक्ट करने का एक मानकीकृत तरीका प्रदान करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- C#, Java, Python, TypeScript, और JavaScript में MCP के लिए विकास वातावरण सेट करें
- कस्टम फीचर्स (संसाधन, प्रॉम्प्ट्स, और टूल्स) के साथ बुनियादी MCP सर्वर बनाएं और परिनियोजित करें
- होस्ट एप्लिकेशन बनाएं जो MCP सर्वरों से कनेक्ट हों
- MCP कार्यान्वयन का परीक्षण और डिबग करें
- सामान्य सेटअप चुनौतियों और उनके समाधान को समझें
- अपने MCP कार्यान्वयन को लोकप्रिय LLM सेवाओं से कनेक्ट करें

## अपना MCP वातावरण सेट करना

MCP के साथ काम शुरू करने से पहले, यह महत्वपूर्ण है कि आप अपना विकास वातावरण तैयार करें और बुनियादी वर्कफ़्लो को समझें। यह अनुभाग MCP के साथ एक सुगम शुरुआत सुनिश्चित करने के लिए प्रारंभिक सेटअप चरणों के माध्यम से आपका मार्गदर्शन करेगा।

### आवश्यकताएँ

MCP विकास में उतरने से पहले, सुनिश्चित करें कि आपके पास निम्नलिखित हैं:

- **विकास वातावरण**: आपके चुने गए भाषा (C#, Java, Python, TypeScript, या JavaScript) के लिए
- **IDE/एडिटर**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, या कोई भी आधुनिक कोड एडिटर
- **पैकेज मैनेजर**: NuGet, Maven/Gradle, pip, या npm/yarn
- **API कुंजियाँ**: उन AI सेवाओं के लिए जिन्हें आप अपने होस्ट एप्लिकेशन में उपयोग करने की योजना बना रहे हैं

### आधिकारिक SDKs

आगामी अध्यायों में आप Python, TypeScript, Java और .NET का उपयोग करके बनाए गए समाधान देखेंगे। यहां सभी आधिकारिक रूप से समर्थित SDKs दिए गए हैं।

MCP कई भाषाओं के लिए आधिकारिक SDKs प्रदान करता है:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft के साथ सहयोग में बनाए रखा गया
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI के साथ सहयोग में बनाए रखा गया
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript कार्यान्वयन
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python कार्यान्वयन
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin कार्यान्वयन
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI के साथ सहयोग में बनाए रखा गया
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust कार्यान्वयन

## मुख्य बातें

- MCP विकास वातावरण सेट करना भाषा-विशिष्ट SDKs के साथ सरल है
- MCP सर्वर बनाना टूल्स को स्पष्ट स्कीमाओं के साथ बनाना और पंजीकृत करना शामिल करता है
- MCP क्लाइंट सर्वरों और मॉडलों से कनेक्ट होते हैं ताकि विस्तारित क्षमताओं का लाभ उठाया जा सके
- विश्वसनीय MCP कार्यान्वयन के लिए परीक्षण और डिबगिंग आवश्यक हैं
- परिनियोजन विकल्प स्थानीय विकास से लेकर क्लाउड-आधारित समाधानों तक होते हैं

## अभ्यास

हमारे पास नमूनों का एक सेट है जो इस अनुभाग के सभी अध्यायों में दिखाए गए अभ्यासों को पूरक करता है। इसके अतिरिक्त, प्रत्येक अध्याय में अपने स्वयं के अभ्यास और असाइनमेंट भी हैं।

- [Java कैलकुलेटर](./samples/java/calculator/README.md)
- [.Net कैलकुलेटर](../../../03-GettingStarted/samples/csharp)
- [JavaScript कैलकुलेटर](./samples/javascript/README.md)
- [TypeScript कैलकुलेटर](./samples/typescript/README.md)
- [Python कैलकुलेटर](../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधन

- [Azure पर Model Context Protocol का उपयोग करके एजेंट बनाएं](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps के साथ रिमोट MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP एजेंट](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## आगे क्या है

अगला: [अपना पहला MCP सर्वर बनाना](01-first-server/README.md)

---

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता सुनिश्चित करने का प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियां या अशुद्धियां हो सकती हैं। मूल भाषा में उपलब्ध मूल दस्तावेज़ को प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।