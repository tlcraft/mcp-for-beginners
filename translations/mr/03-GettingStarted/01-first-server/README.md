<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90651bcd1df019768921d531653638a",
  "translation_date": "2025-06-12T23:21:56+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "mr"
}
-->
### -2- प्रोजेक्ट तयार करा

आता तुमच्याकडे SDK इन्स्टॉल झाले आहे, चला पुढे प्रोजेक्ट तयार करूया:

### -3- प्रोजेक्ट फाइल्स तयार करा

### -4- सर्व्हर कोड तयार करा

### -5- टूल आणि रिसोर्स जोडणे

खालील कोड जोडून एक टूल आणि एक रिसोर्स जोडा:

### -6 अंतिम कोड

सर्व्हर सुरू करण्यासाठी आवश्यक शेवटचा कोड जोडूया:

### -7- सर्व्हर टेस्ट करा

खालील कमांड वापरून सर्व्हर सुरू करा:

### -8- इन्स्पेक्टर वापरा

इन्स्पेक्टर हा एक उत्तम टूल आहे जो तुमचा सर्व्हर सुरू करतो आणि तुम्हाला त्याच्याशी संवाद साधण्याची परवानगी देतो, ज्यामुळे तुम्ही त्याचा कार्यप्रदर्शन तपासू शकता. चला ते सुरू करूया:

> [!NOTE]
> "command" फील्डमधील कमांड वेगवेगळ्या रनटाइमसाठी वेगळी दिसू शकते.

तुम्हाला खालील वापरकर्ता इंटरफेस दिसेल:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.mr.png)

1. Connect बटणावर क्लिक करून सर्व्हरशी कनेक्ट व्हा  
  एकदा तुम्ही सर्व्हरशी कनेक्ट झालात की, तुम्हाला खालील स्क्रीन दिसेल:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.mr.png)

1. "Tools" आणि "listTools" निवडा, तुम्हाला "Add" दिसेल, "Add" निवडा आणि पॅरामीटर मूल्ये भरा.

  तुम्हाला खालील प्रतिसाद दिसेल, म्हणजे "add" टूलचा निकाल:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.mr.png)

अभिनंदन, तुम्ही तुमचा पहिला सर्व्हर तयार करून चालवला आहे!

### अधिकृत SDKs

MCP विविध भाषांसाठी अधिकृत SDKs पुरवते:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सह सहकार्याने देखभाल
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सह सहकार्याने देखभाल
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - अधिकृत TypeScript अंमलबजावणी
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - अधिकृत Python अंमलबजावणी
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - अधिकृत Kotlin अंमलबजावणी
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सह सहकार्याने देखभाल
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - अधिकृत Rust अंमलबजावणी

## मुख्य मुद्दे

- MCP विकासासाठी भाषा-विशिष्ट SDKs सोबत पर्यावरण तयार करणे सोपे आहे
- MCP सर्व्हर तयार करताना टूल्स तयार करणे आणि नोंदणी करणे आवश्यक आहे ज्यांचे स्पष्ट स्कीमा असतात
- चाचणी आणि डीबगिंग विश्वसनीय MCP अंमलबजावणीसाठी महत्त्वाचे आहे

## नमुने

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## असाइनमेंट

तुमच्या पसंतीच्या भाषेत एक साधा MCP सर्व्हर तयार करा ज्यामध्ये एक टूल असले पाहिजे:
1. टूल तुमच्या पसंतीच्या भाषेत ( .NET, Java, Python, किंवा JavaScript) अंमलात आणा.
2. इनपुट पॅरामीटर्स आणि रिटर्न व्हॅल्यूस परिभाषित करा.
3. सर्व्हर योग्यरित्या काम करत आहे याची खात्री करण्यासाठी इन्स्पेक्टर टूल वापरा.
4. विविध इनपुटसह अंमलबजावणी तपासा.

## समाधान

[Solution](./solution/README.md)

## अतिरिक्त संसाधने

- [Azure वर Model Context Protocol वापरून एजंट तयार करा](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps सह Remote MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP एजंट](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## पुढे काय

पुढे: [MCP Clients सह सुरुवात](/03-GettingStarted/02-client/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या मूळ भाषेत अधिकृत स्रोत म्हणून समजला जावा. महत्त्वाची माहिती साठी व्यावसायिक मानवी अनुवाद शिफारस केली जाते. या अनुवादाच्या वापरामुळे झालेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलावासाठी आम्ही जबाबदार नाही.