<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:05:23+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "mr"
}
-->
## Getting Started  

या विभागात अनेक धडे आहेत:

- **1 तुमचा पहिला सर्व्हर**, या पहिल्या धड्यात, तुम्ही तुमचा पहिला सर्व्हर कसा तयार करायचा आणि inspector टूलने त्याची तपासणी कशी करायची हे शिकाल, जे तुमच्या सर्व्हरची चाचणी आणि डिबगिंग करण्याचा एक महत्त्वाचा मार्ग आहे, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 क्लायंट**, या धड्यात, तुम्ही असा क्लायंट लिहिणे शिकाल जो तुमच्या सर्व्हरशी कनेक्ट होऊ शकेल, [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 LLM सह क्लायंट**, क्लायंट लिहिण्याचा आणखी चांगला मार्ग म्हणजे त्यात LLM जोडणे जेणेकरून तो तुमच्या सर्व्हरशी "नेगोशिएट" करू शकेल काय करायचे आहे, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio Code मध्ये GitHub Copilot Agent मोडमध्ये सर्व्हर वापरणे**. येथे आपण Visual Studio Code मधून आपला MCP Server चालवण्याकडे पाहत आहोत, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 SSE (Server Sent Events) कडून कन्स्युम करणे** SSE हा सर्व्हर-टू-क्लायंट स्ट्रीमिंगसाठी एक स्टँडर्ड आहे, जो सर्व्हर्सना HTTP वर रिअल-टाइम अपडेट्स क्लायंटकडे पाठवण्याची परवानगी देतो [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 VSCode साठी AI Toolkit वापरणे** तुमचे MCP Clients आणि Servers कसे वापरायचे आणि चाचणी कशी घ्यायची [to the lesson](/03-GettingStarted/06-aitk/README.md)

- **7 टेस्टिंग**. येथे आपण विशेषतः पाहणार आहोत की वेगवेगळ्या पद्धतीने आपल्या सर्व्हर आणि क्लायंटची चाचणी कशी करायची, [to the lesson](/03-GettingStarted/07-testing/README.md)

- **8 डिप्लॉयमेंट**. या विभागात आपण तुमच्या MCP सोल्यूशन्सचे विविध डिप्लॉयमेंट मार्ग पाहणार आहोत, [to the lesson](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) हा एक खुला प्रोटोकॉल आहे जो LLMs ला संदर्भ प्रदान करण्याच्या अॅप्लिकेशन्सना प्रमाणबद्ध करतो. MCP ला AI अॅप्लिकेशन्ससाठी USB-C पोर्टसारखे समजा - तो AI मॉडेल्सना विविध डेटा स्रोत आणि टूल्सशी जोडण्याचा एक प्रमाणबद्ध मार्ग प्रदान करतो.

## Learning Objectives

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- C#, Java, Python, TypeScript, आणि JavaScript मध्ये MCP साठी विकास वातावरण सेटअप करणे
- कस्टम फिचर्स (resources, prompts, आणि tools) सह बेसिक MCP सर्व्हर्स तयार करणे आणि डिप्लॉय करणे
- MCP सर्व्हर्सशी कनेक्ट होणाऱ्या होस्ट अॅप्लिकेशन्स तयार करणे
- MCP अंमलबजावणीची चाचणी आणि डिबगिंग करणे
- सामान्य सेटअप समस्यांचे आणि त्यांच्या उपायांचे समजून घेणे
- तुमच्या MCP अंमलबजावणीला लोकप्रिय LLM सेवा कशी कनेक्ट करायची

## Setting Up Your MCP Environment

MCP वर काम सुरू करण्यापूर्वी, तुमचे विकास वातावरण तयार करणे आणि मूलभूत वर्कफ्लो समजून घेणे महत्त्वाचे आहे. हा विभाग सुरुवातीच्या सेटअप स्टेप्समध्ये तुम्हाला मार्गदर्शन करेल जेणेकरून MCP सह सुरळीत सुरुवात होईल.

### Prerequisites

MCP विकासात डोकावण्यापूर्वी, खात्री करा की तुमच्याकडे आहे:

- **विकास वातावरण**: तुमच्या निवडलेल्या भाषेसाठी (C#, Java, Python, TypeScript, किंवा JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, किंवा कोणताही आधुनिक कोड एडिटर
- **पॅकेज मॅनेजर्स**: NuGet, Maven/Gradle, pip, किंवा npm/yarn
- **API Keys**: जे कोणत्याही AI सेवांसाठी तुम्ही होस्ट अॅप्लिकेशन्समध्ये वापरणार आहात

### Official SDKs

पुढील अध्यायांमध्ये तुम्हाला Python, TypeScript, Java आणि .NET वापरून तयार केलेल्या सोल्यूशन्स दिसतील. येथे सर्व अधिकृतपणे समर्थित SDKs आहेत.

MCP अनेक भाषांसाठी अधिकृत SDKs प्रदान करते:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सोबत सहयोगात व्यवस्थापित
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सोबत सहयोगात व्यवस्थापित
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - अधिकृत TypeScript अंमलबजावणी
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - अधिकृत Python अंमलबजावणी
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - अधिकृत Kotlin अंमलबजावणी
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सोबत सहयोगात व्यवस्थापित
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - अधिकृत Rust अंमलबजावणी

## Key Takeaways

- भाषा-विशिष्ट SDKs सह MCP विकास वातावरण सेटअप करणे सोपे आहे
- MCP सर्व्हर तयार करताना स्पष्ट स्कीमा असलेल्या टूल्स तयार करणे आणि नोंदणी करणे आवश्यक आहे
- MCP क्लायंट्स सर्व्हर्स आणि मॉडेल्सशी कनेक्ट होऊन विस्तारित क्षमता वापरतात
- चाचणी आणि डिबगिंग विश्वसनीय MCP अंमलबजावणीसाठी अत्यंत आवश्यक आहे
- डिप्लॉयमेंट पर्याय स्थानिक विकासापासून क्लाउड-आधारित सोल्यूशन्सपर्यंत आहेत

## Practicing

आमच्याकडे काही सॅम्पल्स आहेत जे या विभागातील सर्व अध्यायांतील सरावांसाठी पूरक आहेत. तसेच प्रत्येक अध्यायात स्वतःचे सराव आणि असाइनमेंट्स देखील आहेत.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

पुढे: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत म्हणून मानला पाहिजे. महत्त्वाची माहिती असल्यास, व्यावसायिक मानवी अनुवादाची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थ लावण्याबद्दल आम्ही जबाबदार नाही.