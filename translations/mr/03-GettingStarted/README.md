<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "858362ce0118de3fec0f9114bf396101",
  "translation_date": "2025-08-18T15:41:12+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "mr"
}
-->
## सुरुवात करणे  

[![तुमचा पहिला MCP सर्व्हर तयार करा](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.mr.png)](https://youtu.be/sNDZO9N4m9Y)

_(वरील प्रतिमेवर क्लिक करून या धड्याचा व्हिडिओ पहा)_

या विभागात अनेक धडे समाविष्ट आहेत:

- **1 तुमचा पहिला सर्व्हर**, या पहिल्या धड्यात तुम्ही तुमचा पहिला सर्व्हर कसा तयार करायचा आणि निरीक्षक साधनाचा वापर करून त्याची तपासणी कशी करायची हे शिकाल, तुमचा सर्व्हर चाचणी आणि डीबग करण्याचा एक उपयुक्त मार्ग, [धड्याला जा](01-first-server/README.md)

- **2 क्लायंट**, या धड्यात तुम्ही तुमच्या सर्व्हरशी कनेक्ट होणारा क्लायंट कसा लिहायचा हे शिकाल, [धड्याला जा](02-client/README.md)

- **3 LLM सह क्लायंट**, क्लायंट लिहिण्याचा आणखी चांगला मार्ग म्हणजे त्यात LLM जोडणे, ज्यामुळे तो तुमच्या सर्व्हरशी "वाटाघाटी" करू शकतो की काय करायचे आहे, [धड्याला जा](03-llm-client/README.md)

- **4 Visual Studio Code मध्ये GitHub Copilot Agent मोड वापरून सर्व्हरचा वापर**. येथे, आम्ही Visual Studio Code मधून आमचा MCP सर्व्हर चालवण्याकडे पाहत आहोत, [धड्याला जा](04-vscode/README.md)

- **5 SSE (Server Sent Events) मधून वापर** SSE हे सर्व्हर-टू-क्लायंट स्ट्रीमिंगसाठी एक मानक आहे, जे सर्व्हरला HTTP वर क्लायंटला रिअल-टाइम अपडेट्स पुश करण्याची परवानगी देते [धड्याला जा](05-sse-server/README.md)

- **6 MCP सह HTTP स्ट्रीमिंग (Streamable HTTP)**. आधुनिक HTTP स्ट्रीमिंग, प्रगती सूचना, आणि Streamable HTTP वापरून स्केलेबल, रिअल-टाइम MCP सर्व्हर आणि क्लायंट कसे अंमलात आणायचे ते शिका. [धड्याला जा](06-http-streaming/README.md)

- **7 VSCode साठी AI Toolkit चा वापर** MCP क्लायंट्स आणि सर्व्हर्सचा वापर आणि चाचणी करण्यासाठी [धड्याला जा](07-aitk/README.md)

- **8 चाचणी**. येथे आम्ही विशेषतः आमचा सर्व्हर आणि क्लायंट वेगवेगळ्या प्रकारे कसे चाचणी करू शकतो यावर लक्ष केंद्रित करू, [धड्याला जा](08-testing/README.md)

- **9 डिप्लॉयमेंट**. या अध्यायात आम्ही तुमच्या MCP सोल्यूशन्स डिप्लॉय करण्याचे वेगवेगळे मार्ग पाहू, [धड्याला जा](09-deployment/README.md)


Model Context Protocol (MCP) हे एक ओपन प्रोटोकॉल आहे जे अॅप्लिकेशन्सना LLMs ला संदर्भ प्रदान करण्यासाठी मानकीकृत करते. MCP ला AI अॅप्लिकेशन्ससाठी USB-C पोर्टसारखे समजा - हे AI मॉडेल्सना वेगवेगळ्या डेटा स्रोत आणि साधनांशी कनेक्ट करण्याचा मानकीकृत मार्ग प्रदान करते.

## शिकण्याची उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही हे करू शकाल:

- C#, Java, Python, TypeScript, आणि JavaScript मध्ये MCP साठी विकास वातावरण सेट करा
- कस्टम वैशिष्ट्यांसह (संसाधने, प्रॉम्प्ट्स, आणि साधने) मूलभूत MCP सर्व्हर तयार करा आणि डिप्लॉय करा
- MCP सर्व्हर्सशी कनेक्ट होणाऱ्या होस्ट अॅप्लिकेशन्स तयार करा
- MCP अंमलबजावणीची चाचणी आणि डीबग करा
- सामान्य सेटअप आव्हाने आणि त्यांचे उपाय समजून घ्या
- तुमच्या MCP अंमलबजावणीला लोकप्रिय LLM सेवांशी कनेक्ट करा

## तुमचे MCP वातावरण सेट करणे

MCP सोबत काम करण्यास सुरुवात करण्यापूर्वी, तुमचे विकास वातावरण तयार करणे आणि मूलभूत कार्यप्रवाह समजून घेणे महत्त्वाचे आहे. MCP सोबत सुरळीत सुरुवात सुनिश्चित करण्यासाठी प्रारंभिक सेटअप चरणांद्वारे तुम्हाला मार्गदर्शन केले जाईल.

### पूर्वतयारी

MCP विकासात उतरण्यापूर्वी, खात्री करा की तुमच्याकडे आहे:

- **विकास वातावरण**: तुमच्या निवडलेल्या भाषेसाठी (C#, Java, Python, TypeScript, किंवा JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, किंवा कोणताही आधुनिक कोड एडिटर
- **पॅकेज मॅनेजर्स**: NuGet, Maven/Gradle, pip, किंवा npm/yarn
- **API Keys**: तुमच्या होस्ट अॅप्लिकेशन्समध्ये वापरण्याची योजना असलेल्या कोणत्याही AI सेवांसाठी


### अधिकृत SDKs

आगामी अध्यायांमध्ये तुम्ही Python, TypeScript, Java आणि .NET वापरून तयार केलेले सोल्यूशन्स पाहाल. येथे सर्व अधिकृतपणे समर्थित SDKs आहेत.

MCP अनेक भाषांसाठी अधिकृत SDKs प्रदान करते:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सोबत सहकार्याने देखरेख केली जाते
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सोबत सहकार्याने देखरेख केली जाते
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - अधिकृत TypeScript अंमलबजावणी
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - अधिकृत Python अंमलबजावणी
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - अधिकृत Kotlin अंमलबजावणी
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सोबत सहकार्याने देखरेख केली जाते
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - अधिकृत Rust अंमलबजावणी

## मुख्य मुद्दे

- MCP विकास वातावरण सेट करणे भाषेसाठी विशिष्ट SDKs सह सोपे आहे
- MCP सर्व्हर तयार करणे स्पष्ट स्कीमासह साधने तयार करणे आणि नोंदणी करणे यामध्ये समाविष्ट आहे
- MCP क्लायंट्स सर्व्हर्स आणि मॉडेल्सशी कनेक्ट होतात जेणेकरून विस्तारित क्षमता वापरता येतील
- विश्वसनीय MCP अंमलबजावणीसाठी चाचणी आणि डीबग करणे आवश्यक आहे
- डिप्लॉयमेंट पर्याय स्थानिक विकासापासून क्लाउड-आधारित सोल्यूशन्सपर्यंत आहेत

## सराव

आमच्याकडे नमुन्यांचा एक संच आहे जो तुम्हाला या विभागातील सर्व अध्यायांमध्ये दिसणाऱ्या सरावांना पूरक आहे. याशिवाय प्रत्येक अध्यायात स्वतःचे सराव आणि असाइनमेंट्स देखील आहेत.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधने

- [Model Context Protocol वापरून Azure वर एजंट्स तयार करा](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps सह Remote MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## पुढे काय

पुढे: [तुमचा पहिला MCP सर्व्हर तयार करणे](01-first-server/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) चा वापर करून भाषांतरित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित भाषांतरांमध्ये त्रुटी किंवा अचूकतेचा अभाव असू शकतो. मूळ भाषेतील दस्तऐवज हा अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी, व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराचा वापर केल्यामुळे उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार राहणार नाही.