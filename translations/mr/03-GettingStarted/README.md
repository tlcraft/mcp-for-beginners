<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T23:21:26+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "mr"
}
-->
## Getting Started  

या विभागात अनेक धडे आहेत:

- **1 तुमचा पहिला सर्व्हर**, या पहिल्या धड्यात, तुम्हाला तुमचा पहिला सर्व्हर कसा तयार करायचा आणि inspector tool वापरून त्याची तपासणी कशी करायची हे शिकवले जाईल, जे तुमच्या सर्व्हरचे परीक्षण आणि डीबगिंग करण्याचा एक मौल्यवान मार्ग आहे, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, या धड्यात, तुम्हाला तुमच्या सर्व्हरशी कनेक्ट होणारा क्लायंट कसा लिहायचा हे शिकवले जाईल, [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**, क्लायंट लिहिण्याचा आणखी एक चांगला मार्ग म्हणजे त्यात LLM जोडणे जेणेकरून तो तुमच्या सर्व्हरशी "negotiation" करू शकेल की काय करायचे, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio Code मध्ये GitHub Copilot Agent मोडमध्ये सर्व्हर वापरणे**. येथे, आपण Visual Studio Code च्या आतून MCP Server चालवण्याकडे पाहत आहोत, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 SSE (Server Sent Events) द्वारे कन्स्युमिंग** SSE हा सर्व्हर-टू-क्लायंट स्ट्रीमिंगसाठी एक मानक आहे, ज्यामुळे सर्व्हर HTTP वर रिअल-टाइम अपडेट्स क्लायंट्सना पाठवू शकतात [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 MCP सह HTTP Streaming (Streamable HTTP)**. आधुनिक HTTP स्ट्रीमिंग, प्रगती सूचना आणि Streamable HTTP वापरून स्केलेबल, रिअल-टाइम MCP सर्व्हर आणि क्लायंट कसे तयार करायचे याबद्दल जाणून घ्या. [to the lesson](/03-GettingStarted/06-http-streaming/README.md)

- **7 VSCode साठी AI Toolkit वापरणे** जेणेकरून तुम्ही तुमचे MCP क्लायंट आणि सर्व्हर वापरून तपासू शकता आणि चाचणी करू शकता [to the lesson](/03-GettingStarted/07-aitk/README.md)

- **8 Testing**. येथे आपण विशेषतः वेगवेगळ्या मार्गांनी आपला सर्व्हर आणि क्लायंट कसे टेस्ट करू शकतो यावर लक्ष केंद्रित करू, [to the lesson](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**. हा विभाग तुमच्या MCP सोल्यूशन्स कसे डिप्लॉय करायचे याचे विविध मार्ग पाहेल, [to the lesson](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) हा एक खुला प्रोटोकॉल आहे जो LLMs ला संदर्भ पुरवण्याचा एक प्रमाणित मार्ग तयार करतो. MCP ला AI अनुप्रयोगांसाठी USB-C पोर्ट समजा - तो AI मॉडेल्सना वेगवेगळ्या डेटा स्रोतांशी आणि टूल्सशी जोडण्याचा एक प्रमाणित मार्ग पुरवतो.

## Learning Objectives

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- C#, Java, Python, TypeScript, आणि JavaScript मध्ये MCP साठी विकास वातावरण तयार करणे
- कस्टम वैशिष्ट्यांसह (resources, prompts, आणि tools) मूलभूत MCP सर्व्हर तयार करणे आणि डिप्लॉय करणे
- MCP सर्व्हरशी कनेक्ट होणाऱ्या होस्ट अनुप्रयोगांची निर्मिती करणे
- MCP अंमलबजावणींची चाचणी आणि डीबगिंग करणे
- सामान्य सेटअप अडचणी आणि त्यांचे उपाय समजून घेणे
- तुमच्या MCP अंमलबजावणींना लोकप्रिय LLM सेवा जोडणे

## Setting Up Your MCP Environment

MCP वर काम सुरू करण्यापूर्वी, तुमचे विकास वातावरण तयार करणे आणि मूलभूत कार्यप्रवाह समजून घेणे महत्त्वाचे आहे. या विभागात सुरुवातीच्या सेटअपच्या टप्प्यांवर मार्गदर्शन केले जाईल जेणेकरून MCP सह सुरळीत सुरुवात होईल.

### Prerequisites

MCP विकासात उतरायच्या आधी, खात्री करा की:

- **Development Environment**: तुमच्या निवडलेल्या भाषेसाठी (C#, Java, Python, TypeScript, किंवा JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, किंवा कोणताही आधुनिक कोड एडिटर
- **Package Managers**: NuGet, Maven/Gradle, pip, किंवा npm/yarn
- **API Keys**: कोणत्याही AI सेवा वापरण्यासाठी जे तुम्ही होस्ट अनुप्रयोगांमध्ये वापरणार आहात


### Official SDKs

आगामी विभागांमध्ये तुम्हाला Python, TypeScript, Java आणि .NET वापरून तयार केलेल्या सोल्यूशन्स दिसतील. येथे सर्व अधिकृतपणे समर्थित SDKs आहेत.

MCP अनेक भाषांसाठी अधिकृत SDKs पुरवतो:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सोबत सहकार्याने व्यवस्थापित
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सोबत सहकार्याने व्यवस्थापित
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - अधिकृत TypeScript अंमलबजावणी
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - अधिकृत Python अंमलबजावणी
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - अधिकृत Kotlin अंमलबजावणी
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सोबत सहकार्याने व्यवस्थापित
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - अधिकृत Rust अंमलबजावणी

## Key Takeaways

- भाषा-विशिष्ट SDKs सह MCP विकास वातावरण तयार करणे सोपे आहे
- MCP सर्व्हर तयार करताना स्पष्ट schemas सह tools तयार करणे आणि नोंदणी करणे आवश्यक आहे
- MCP क्लायंट्स सर्व्हर आणि मॉडेल्सशी कनेक्ट होऊन विस्तारित क्षमता वापरतात
- विश्वसनीय MCP अंमलबजावणीसाठी चाचणी आणि डीबगिंग महत्त्वाचे आहे
- डिप्लॉयमेंटचे पर्याय स्थानिक विकासापासून ते क्लाउड-आधारित सोल्यूशन्सपर्यंत आहेत

## Practicing

आपल्याकडे काही नमुने आहेत जे या विभागातील सर्व अध्यायांतील व्यायामांना पूरक आहेत. तसेच प्रत्येक अध्यायाला स्वतःचे व्यायाम आणि असाइनमेंट्स आहेत.

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
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्नशील आहोत, तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला पाहिजे. महत्त्वाच्या माहिती साठी व्यावसायिक मानवी भाषांतर शिफारस केली जाते. या भाषांतराचा वापर केल्यामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीसाठी आम्ही जबाबदार नाही.