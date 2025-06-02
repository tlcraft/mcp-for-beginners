<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:26:42+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "mr"
}
-->
## Getting Started  

या विभागात अनेक धडे आहेत:

- **-1- तुमचा पहिला सर्व्हर**, या पहिल्या धड्यात, तुम्ही तुमचा पहिला सर्व्हर कसा तयार करायचा आणि inspector tool वापरून त्याची तपासणी कशी करायची हे शिकाल, हा एक मौल्यवान मार्ग आहे तुमचा सर्व्हर टेस्ट आणि डिबग करण्यासाठी, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, या धड्यात, तुम्ही असा क्लायंट लिहायला शिकाल जो तुमच्या सर्व्हरशी कनेक्ट होऊ शकेल, [to the lesson](/03-GettingStarted/02-client/README.md)

- **-3- Client with LLM**, क्लायंट लिहिण्याचा आणखी एक चांगला मार्ग म्हणजे त्यात LLM जोडणे जेणेकरून तो तुमच्या सर्व्हरशी "नेगोशिएट" करू शकेल काय करायचे ते ठरवण्यासाठी, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **-4- Visual Studio Code मध्ये सर्व्हर GitHub Copilot Agent मोड वापरणे**. येथे आपण Visual Studio Code मधून MCP Server चालवण्याकडे पाहत आहोत, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **-5- SSE (Server Sent Events) वापरून कनेक्ट होणे** SSE हा सर्व्हर-टू-क्लायंट स्ट्रीमिंगसाठीचा एक मानक आहे, जो सर्व्हरना HTTP वर रिअल-टाइम अपडेट्स क्लायंटकडे पाठवण्याची परवानगी देतो, [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **-6- AI Toolkit for VSCode वापरणे** तुमचे MCP Clients आणि Servers वापरून टेस्ट करण्यासाठी आणि वापरण्यासाठी [to the lesson](/03-GettingStarted/06-aitk/README.md)

- **-7 Testing**. येथे आपण विशेषतः पाहणार आहोत की आपल्या सर्व्हर आणि क्लायंटची विविध मार्गांनी चाचणी कशी करता येईल, [to the lesson](/03-GettingStarted/07-testing/README.md)

- **-8- Deployment**. हा विभाग तुमच्या MCP सोल्यूशन्सना डिप्लॉय करण्याचे विविध मार्ग पाहणार आहे, [to the lesson](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) हा एक खुला प्रोटोकॉल आहे जो LLMs ला संदर्भ कसा पुरवायचा हे स्टँडर्डाइझ करतो. MCP ला AI अॅप्लिकेशन्ससाठी USB-C पोर्ट म्हणून विचार करा - तो AI मॉडेल्सना विविध डेटा स्रोत आणि टूल्सशी कनेक्ट करण्याचा एक स्टँडर्ड मार्ग पुरवतो.

## Learning Objectives

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- C#, Java, Python, TypeScript, आणि JavaScript मध्ये MCP साठी डेव्हलपमेंट एन्व्हायर्नमेंट सेटअप करणे
- कस्टम फीचर्ससह (resources, prompts, आणि tools) बेसिक MCP सर्व्हर्स तयार करणे आणि डिप्लॉय करणे
- MCP सर्व्हर्सशी कनेक्ट होणाऱ्या होस्ट अॅप्लिकेशन्स तयार करणे
- MCP अंमलबजावणीची चाचणी आणि डिबगिंग करणे
- सामान्य सेटअप अडचणी आणि त्यांचे उपाय समजून घेणे
- लोकप्रिय LLM सेवांशी तुमच्या MCP अंमलबजावणी कनेक्ट करणे

## Setting Up Your MCP Environment

MCP वर काम सुरू करण्यापूर्वी, तुमचे डेव्हलपमेंट एन्व्हायर्नमेंट तयार करणे आणि मूलभूत कार्यप्रवाह समजून घेणे महत्त्वाचे आहे. या विभागात सुरुवातीच्या सेटअप स्टेप्सवर मार्गदर्शन केले जाईल जेणेकरून MCP सह सुरळीत सुरुवात होईल.

### Prerequisites

MCP डेव्हलपमेंटमध्ये उतरायच्या आधी, खात्री करा की तुमच्याकडे:

- **डेव्हलपमेंट एन्व्हायर्नमेंट**: तुमच्या निवडलेल्या भाषेसाठी (C#, Java, Python, TypeScript, किंवा JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, किंवा कोणताही आधुनिक कोड एडिटर
- **पॅकेज मॅनेजर्स**: NuGet, Maven/Gradle, pip, किंवा npm/yarn
- **API Keys**: कोणत्याही AI सेवांसाठी जे तुम्ही तुमच्या होस्ट अॅप्लिकेशन्समध्ये वापरणार आहात


### Official SDKs

आगामी अध्यायांमध्ये तुम्हाला Python, TypeScript, Java आणि .NET वापरून तयार केलेल्या सोल्यूशन्स दिसतील. येथे सर्व अधिकृतपणे समर्थित SDKs दिले आहेत.

MCP अनेक भाषांसाठी अधिकृत SDKs पुरवतो:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सह सहयोगाने देखभाल
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सह सहयोगाने देखभाल
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - अधिकृत TypeScript अंमलबजावणी
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - अधिकृत Python अंमलबजावणी
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - अधिकृत Kotlin अंमलबजावणी
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सह सहयोगाने देखभाल
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - अधिकृत Rust अंमलबजावणी

## Key Takeaways

- MCP डेव्हलपमेंट एन्व्हायर्नमेंट सेटअप करणे भाषानुसार SDKs मुळे सोपे आहे
- MCP सर्व्हर तयार करताना स्पष्ट schemas सह टूल्स तयार करणे आणि नोंदणी करणे आवश्यक आहे
- MCP क्लायंट्स सर्व्हर्स आणि मॉडेल्सशी कनेक्ट होऊन विस्तारित क्षमतांचा लाभ घेतात
- चाचणी आणि डिबगिंग विश्वासार्ह MCP अंमलबजावणीसाठी आवश्यक आहे
- डिप्लॉयमेंटच्या पर्यायांमध्ये स्थानिक डेव्हलपमेंटपासून क्लाउड-आधारित सोल्यूशन्सपर्यंत पर्याय आहेत

## Practicing

आपल्याकडे काही सॅम्पल्स आहेत जे या विभागातील सर्व अध्यायांतील व्यायामांना पूरक आहेत. शिवाय प्रत्येक अध्यायाचे स्वतःचे व्यायाम आणि असाइनमेंट्स देखील आहेत

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

Next: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत म्हणून मानला पाहिजे. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद शिफारसीय आहे. या अनुवादाच्या वापरामुळे झालेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलाभासाठी आम्ही जबाबदार नाही.