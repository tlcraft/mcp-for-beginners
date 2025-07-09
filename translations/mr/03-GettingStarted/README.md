<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-09T22:29:28+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "mr"
}
-->
## सुरुवात करणे  

या विभागात अनेक धडे आहेत:

- **1 तुमचा पहिला सर्व्हर**, या पहिल्या धड्यात, तुम्ही तुमचा पहिला सर्व्हर कसा तयार करायचा आणि inspector टूलने त्याची तपासणी कशी करायची हे शिकाल, जे तुमच्या सर्व्हरची चाचणी आणि डिबगिंग करण्याचा एक महत्त्वाचा मार्ग आहे, [धड्यासाठी](01-first-server/README.md)

- **2 क्लायंट**, या धड्यात, तुम्ही असा क्लायंट लिहिणे शिकाल जो तुमच्या सर्व्हरशी कनेक्ट होऊ शकेल, [धड्यासाठी](02-client/README.md)

- **3 LLM सह क्लायंट**, क्लायंट लिहिण्याचा आणखी चांगला मार्ग म्हणजे त्यात LLM जोडणे जेणेकरून तो तुमच्या सर्व्हरशी "नेगोशिएट" करू शकेल की काय करायचे, [धड्यासाठी](03-llm-client/README.md)

- **4 Visual Studio Code मध्ये GitHub Copilot Agent मोड वापरून सर्व्हर वापरणे**. येथे आपण Visual Studio Code मधून आमचा MCP सर्व्हर कसा चालवायचा ते पाहत आहोत, [धड्यासाठी](04-vscode/README.md)

- **5 SSE (Server Sent Events) द्वारे वापरणे** SSE हा सर्व्हर-टू-क्लायंट स्ट्रीमिंगसाठी एक मानक आहे, जो सर्व्हरला HTTP वरून क्लायंटला रिअल-टाइम अपडेट्स पाठवण्याची परवानगी देतो [धड्यासाठी](05-sse-server/README.md)

- **6 MCP सह HTTP स्ट्रीमिंग (Streamable HTTP)**. आधुनिक HTTP स्ट्रीमिंग, प्रगती सूचना, आणि Streamable HTTP वापरून स्केलेबल, रिअल-टाइम MCP सर्व्हर आणि क्लायंट कसे तयार करायचे हे शिका. [धड्यासाठी](06-http-streaming/README.md)

- **7 VSCode साठी AI Toolkit वापरणे** जेणेकरून तुम्ही तुमचे MCP क्लायंट आणि सर्व्हर वापरून चाचणी करू शकता [धड्यासाठी](07-aitk/README.md)

- **8 चाचणी**. येथे आपण विशेषतः पाहणार आहोत की वेगवेगळ्या पद्धतीने आमचा सर्व्हर आणि क्लायंट कसे चाचणी करू शकतो, [धड्यासाठी](08-testing/README.md)

- **9 तैनाती**. हा अध्याय तुमच्या MCP सोल्यूशन्सची तैनात करण्याच्या विविध मार्गांवर लक्ष केंद्रित करेल, [धड्यासाठी](09-deployment/README.md)


Model Context Protocol (MCP) हा एक खुला प्रोटोकॉल आहे जो LLMs ला संदर्भ प्रदान करण्यासाठी अ‍ॅप्लिकेशन्सना एकसारखा मार्ग देतो. MCP ला AI अ‍ॅप्लिकेशन्ससाठी USB-C पोर्ट म्हणून विचार करा - तो AI मॉडेल्सना विविध डेटा स्रोत आणि टूल्सशी जोडण्यासाठी एकसारखा मार्ग पुरवतो.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- C#, Java, Python, TypeScript, आणि JavaScript मध्ये MCP साठी विकास वातावरण सेटअप करणे
- कस्टम वैशिष्ट्यांसह (resources, prompts, आणि tools) मूलभूत MCP सर्व्हर तयार करणे आणि तैनात करणे
- MCP सर्व्हरशी कनेक्ट होणारी होस्ट अ‍ॅप्लिकेशन्स तयार करणे
- MCP अंमलबजावणीची चाचणी आणि डिबगिंग करणे
- सामान्य सेटअप अडचणी आणि त्यांचे उपाय समजून घेणे
- तुमच्या MCP अंमलबजावणींना लोकप्रिय LLM सेवांशी कनेक्ट करणे

## तुमचे MCP वातावरण सेट करणे

MCP वर काम सुरू करण्यापूर्वी, तुमचे विकास वातावरण तयार करणे आणि मूलभूत कार्यप्रवाह समजून घेणे महत्त्वाचे आहे. हा विभाग तुम्हाला सुरुवातीच्या सेटअपच्या टप्प्यांमध्ये मार्गदर्शन करेल जेणेकरून MCP सह सुरळीत सुरुवात होईल.

### पूर्वअट

MCP विकासात उतरायच्या आधी, खात्री करा की तुमच्याकडे आहे:

- **विकास वातावरण**: तुमच्या निवडलेल्या भाषेसाठी (C#, Java, Python, TypeScript, किंवा JavaScript)
- **IDE/एडिटर**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, किंवा कोणताही आधुनिक कोड एडिटर
- **पॅकेज मॅनेजर्स**: NuGet, Maven/Gradle, pip, किंवा npm/yarn
- **API कीज**: तुमच्या होस्ट अ‍ॅप्लिकेशन्समध्ये वापरण्यासाठी कोणत्याही AI सेवांसाठी

### अधिकृत SDKs

पुढील अध्यायांमध्ये तुम्हाला Python, TypeScript, Java आणि .NET वापरून तयार केलेल्या सोल्यूशन्स दिसतील. येथे सर्व अधिकृतपणे समर्थित SDKs आहेत.

MCP अनेक भाषांसाठी अधिकृत SDKs पुरवतो:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सह सहकार्याने देखभाल केलेले
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सह सहकार्याने देखभाल केलेले
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - अधिकृत TypeScript अंमलबजावणी
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - अधिकृत Python अंमलबजावणी
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - अधिकृत Kotlin अंमलबजावणी
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सह सहकार्याने देखभाल केलेले
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - अधिकृत Rust अंमलबजावणी

## मुख्य मुद्दे

- भाषा-विशिष्ट SDKs सह MCP विकास वातावरण सेट करणे सोपे आहे
- MCP सर्व्हर तयार करताना स्पष्ट स्कीमासह टूल्स तयार करणे आणि नोंदणी करणे आवश्यक आहे
- MCP क्लायंट्स सर्व्हर आणि मॉडेल्सशी कनेक्ट होऊन विस्तारित क्षमता वापरतात
- विश्वसनीय MCP अंमलबजावणीसाठी चाचणी आणि डिबगिंग आवश्यक आहे
- तैनातीचे पर्याय स्थानिक विकासापासून क्लाउड-आधारित सोल्यूशन्सपर्यंत आहेत

## सराव

आमच्याकडे काही नमुने आहेत जे या विभागातील सर्व अध्यायांतील व्यायामांना पूरक आहेत. याशिवाय प्रत्येक अध्यायात स्वतःचे व्यायाम आणि असाइनमेंट्स देखील आहेत.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधने

- [Azure वर Model Context Protocol वापरून एजंट तयार करणे](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps सह Remote MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## पुढे काय

पुढे: [तुमचा पहिला MCP सर्व्हर तयार करणे](01-first-server/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.