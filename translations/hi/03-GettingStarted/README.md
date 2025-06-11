<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:04:30+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hi"
}
-->
## Getting Started  

यह सेक्शन कई पाठों से बना है:

- **1 Your first server**, इस पहले पाठ में, आप अपना पहला सर्वर बनाना सीखेंगे और इसे इंस्पेक्टर टूल से जांचेंगे, जो आपके सर्वर को टेस्ट और डिबग करने का एक उपयोगी तरीका है, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, इस पाठ में, आप एक क्लाइंट लिखना सीखेंगे जो आपके सर्वर से कनेक्ट हो सके, [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**, क्लाइंट लिखने का एक बेहतर तरीका है कि उसमें LLM जोड़ा जाए ताकि यह आपके सर्वर से "नेगोशिएट" कर सके कि क्या करना है, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**. यहाँ, हम Visual Studio Code के अंदर से हमारा MCP Server चलाने पर ध्यान दे रहे हैं, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE एक मानक है जो सर्वर से क्लाइंट तक स्ट्रीमिंग करता है, जिससे सर्वर HTTP के जरिए क्लाइंट को रियल-टाइम अपडेट भेज सकते हैं [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 Utilising AI Toolkit for VSCode** अपने MCP क्लाइंट्स और सर्वर्स को कंज्यूम और टेस्ट करने के लिए [to the lesson](/03-GettingStarted/06-aitk/README.md)

- **7 Testing**. यहाँ हम खासतौर पर यह देखेंगे कि हम अपने सर्वर और क्लाइंट को अलग-अलग तरीकों से कैसे टेस्ट कर सकते हैं, [to the lesson](/03-GettingStarted/07-testing/README.md)

- **8 Deployment**. यह अध्याय आपके MCP सॉल्यूशंस को डिप्लॉय करने के विभिन्न तरीकों पर नजर डालेगा, [to the lesson](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) एक खुला प्रोटोकॉल है जो यह निर्धारित करता है कि एप्लिकेशन LLMs को संदर्भ कैसे प्रदान करते हैं। MCP को AI एप्लिकेशन के लिए USB-C पोर्ट की तरह सोचें - यह AI मॉडल्स को विभिन्न डेटा स्रोतों और टूल्स से जोड़ने का एक मानकीकृत तरीका प्रदान करता है।

## Learning Objectives

इस पाठ के अंत तक, आप सक्षम होंगे:

- C#, Java, Python, TypeScript, और JavaScript में MCP के लिए विकास वातावरण सेटअप करना
- कस्टम फीचर्स (resources, prompts, और tools) के साथ बेसिक MCP सर्वर्स बनाना और डिप्लॉय करना
- होस्ट एप्लिकेशन बनाना जो MCP सर्वर्स से कनेक्ट हो
- MCP इम्प्लीमेंटेशन का टेस्ट और डिबग करना
- सामान्य सेटअप चुनौतियों और उनके समाधान को समझना
- अपने MCP इम्प्लीमेंटेशन को लोकप्रिय LLM सेवाओं से कनेक्ट करना

## Setting Up Your MCP Environment

MCP के साथ काम शुरू करने से पहले, अपने विकास वातावरण को तैयार करना और मूल कार्यप्रवाह को समझना जरूरी है। यह सेक्शन आपको शुरुआती सेटअप के कदमों में मार्गदर्शन करेगा ताकि MCP के साथ आपका अनुभव सहज हो।

### Prerequisites

MCP विकास में उतरने से पहले सुनिश्चित करें कि आपके पास है:

- **Development Environment**: अपनी पसंदीदा भाषा (C#, Java, Python, TypeScript, या JavaScript) के लिए
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, या कोई आधुनिक कोड संपादक
- **Package Managers**: NuGet, Maven/Gradle, pip, या npm/yarn
- **API Keys**: उन AI सेवाओं के लिए जिनका आप अपने होस्ट एप्लिकेशन में उपयोग करने वाले हैं


### Official SDKs

आगामी अध्यायों में आप Python, TypeScript, Java और .NET का उपयोग करके बने समाधान देखेंगे। यहाँ सभी आधिकारिक समर्थित SDKs हैं।

MCP कई भाषाओं के लिए आधिकारिक SDK प्रदान करता है:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft के साथ सहयोग में बनाए रखा गया
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI के साथ सहयोग में बनाए रखा गया
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - आधिकारिक TypeScript इम्प्लीमेंटेशन
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - आधिकारिक Python इम्प्लीमेंटेशन
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - आधिकारिक Kotlin इम्प्लीमेंटेशन
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI के साथ सहयोग में बनाए रखा गया
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - आधिकारिक Rust इम्प्लीमेंटेशन

## Key Takeaways

- MCP विकास वातावरण सेटअप करना भाषा-विशिष्ट SDKs के साथ सरल है
- MCP सर्वर्स बनाना टूल्स को स्पष्ट स्कीमाओं के साथ बनाना और रजिस्टर करना शामिल है
- MCP क्लाइंट्स सर्वर्स और मॉडल्स से कनेक्ट होकर विस्तारित क्षमताओं का लाभ उठाते हैं
- विश्वसनीय MCP इम्प्लीमेंटेशन के लिए टेस्टिंग और डिबगिंग जरूरी है
- डिप्लॉयमेंट विकल्प स्थानीय विकास से लेकर क्लाउड-आधारित समाधान तक हो सकते हैं

## Practicing

हमारे पास कुछ सैंपल्स हैं जो इस सेक्शन के सभी अध्यायों में मिलने वाले अभ्यासों को पूरा करते हैं। इसके अलावा, प्रत्येक अध्याय के अपने अभ्यास और असाइनमेंट भी हैं।

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../../../03-GettingStarted/samples/javascript)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

Next: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**अस्वीकरण**:  
इस दस्तावेज़ का अनुवाद AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके किया गया है। हम सटीकता के लिए प्रयासरत हैं, लेकिन कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या गलतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।