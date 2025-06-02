<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:27:21+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "mr"
}
-->
### -2- प्रोजेक्ट तयार करा

आता जेव्हा तुम्ही तुमचा SDK इंस्टॉल केला आहे, तर पुढे प्रोजेक्ट तयार करूया: 

### -3- प्रोजेक्ट फाइल्स तयार करा

### -4- सर्व्हर कोड तयार करा

### -5- एक टूल आणि एक रिसोर्स जोडा

खालील कोड जोडून एक टूल आणि एक रिसोर्स जोडा:

### -6 शेवटचा कोड

सर्व्हर सुरू होण्यासाठी आवश्यक शेवटचा कोड जोडूया:

### -7- सर्व्हरची चाचणी करा

खालील कमांड वापरून सर्व्हर सुरू करा:

### -8- Inspector वापरून चालवा

Inspector हा एक उत्कृष्ट टूल आहे जो तुमचा सर्व्हर सुरू करून त्याच्याशी संवाद साधण्याची परवानगी देतो जेणेकरून तुम्ही तपासू शकता की तो योग्यरित्या काम करतोय की नाही. चला ते सुरू करूया:

> [!NOTE]
> "command" फील्डमध्ये कमांड वेगळ्या प्रकारे दिसू शकते कारण त्यात तुमच्या विशिष्ट रनटाइमसाठी सर्व्हर चालवण्याची कमांड असते.

तुम्हाला खालील वापरकर्ता इंटरफेस दिसेल:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.mr.png)

1. Connect बटण निवडून सर्व्हरशी कनेक्ट व्हा  
  एकदा तुम्ही सर्व्हरशी कनेक्ट केल्यावर, तुम्हाला खालील दृश्य दिसेल:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.mr.png)

1. "Tools" आणि "listTools" निवडा, तुम्हाला "Add" दिसेल, "Add" निवडा आणि पॅरामीटर मूल्ये भरा.

  तुम्हाला खालील प्रतिसाद दिसेल, म्हणजे "add" टूलचा निकाल:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.mr.png)

अभिनंदन, तुम्ही तुमचा पहिला सर्व्हर तयार करून चालवण्यात यशस्वी झाला आहात!

### अधिकृत SDKs

MCP अनेक भाषांसाठी अधिकृत SDKs पुरवते:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सह सहयोगाने व्यवस्थापित  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सह सहयोगाने व्यवस्थापित  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - अधिकृत TypeScript अंमलबजावणी  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - अधिकृत Python अंमलबजावणी  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - अधिकृत Kotlin अंमलबजावणी  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सह सहयोगाने व्यवस्थापित  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - अधिकृत Rust अंमलबजावणी  

## मुख्य मुद्दे

- MCP विकास वातावरण सेट करणे भाषानुसार SDKs मुळे सोपे आहे  
- MCP सर्व्हर तयार करताना स्पष्ट स्कीमा असलेली टूल्स तयार करणे आणि नोंदणी करणे आवश्यक आहे  
- विश्वसनीय MCP अंमलबजावणीसाठी चाचणी आणि डिबगिंग महत्त्वाचे आहे  

## नमुने 

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## असाइनमेंट

तुमच्या पसंतीच्या भाषेत एक साधा MCP सर्व्हर तयार करा:  
1. तुमच्या पसंतीच्या भाषेत टूल अंमलात आणा (.NET, Java, Python, किंवा JavaScript).  
2. इनपुट पॅरामीटर्स आणि परतावा मूल्ये परिभाषित करा.  
3. Inspector टूल चालवा आणि सर्व्हर योग्यरित्या कार्यरत आहे का ते तपासा.  
4. विविध इनपुट्ससह अंमलबजावणीची चाचणी करा.  

## सोल्यूशन

[Solution](./solution/README.md)

## अतिरिक्त संसाधने

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## पुढे काय

पुढे: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहिती साठी व्यावसायिक मानवी भाषांतर शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीसाठी आम्ही जबाबदार नाही.