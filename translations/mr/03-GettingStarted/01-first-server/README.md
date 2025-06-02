<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:06:16+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "mr"
}
-->
### -2- प्रोजेक्ट तयार करा

आता जेव्हा तुम्ही तुमचा SDK इन्स्टॉल केला आहे, तर पुढे प्रोजेक्ट तयार करूया:

### -3- प्रोजेक्ट फायली तयार करा

### -4- सर्व्हर कोड तयार करा

### -5- एक टूल आणि एक रिसोर्स जोडा

खालील कोड जोडून एक टूल आणि एक रिसोर्स जोडा:

### -6 अंतिम कोड

सर्व्हर सुरू होण्यासाठी आवश्यक शेवटचा कोड जोडूया:

### -7- सर्व्हर चाचणी करा

खालील कमांड वापरून सर्व्हर सुरू करा:

### -8- इन्स्पेक्टर वापरून चालवा

इन्स्पेक्टर हा एक उत्तम टूल आहे जो तुमचा सर्व्हर सुरू करतो आणि तुम्हाला त्याच्याशी संवाद साधण्याची परवानगी देतो, ज्यामुळे तुम्ही त्याची कार्यक्षमता तपासू शकता. चला तो सुरू करूया:

> [!NOTE]
> "command" फील्डमध्ये तुम्हाला वेगळं दिसू शकतं कारण त्यात तुमच्या विशिष्ट रनटाइमसाठी सर्व्हर चालवण्याचा कमांड असतो.

तुम्हाला खालील वापरकर्ता इंटरफेस दिसेल:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.mr.png)

1. Connect बटणावर क्लिक करून सर्व्हरशी कनेक्ट व्हा  
  सर्व्हरशी कनेक्ट झाल्यावर तुम्हाला खालील स्क्रीन दिसेल:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.mr.png)

2. "Tools" आणि "listTools" निवडा, तुम्हाला "Add" दिसेल, त्यावर क्लिक करा आणि पॅरामीटर मूल्ये भरा.

  तुम्हाला खालील प्रतिसाद दिसेल, म्हणजे "add" टूलचा निकाल:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.mr.png)

अभिनंदन, तुम्ही तुमचा पहिला सर्व्हर तयार करून यशस्वीपणे चालवला आहे!

### अधिकृत SDKs

MCP अनेक भाषांसाठी अधिकृत SDKs प्रदान करते:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft सह संयुक्तपणे देखभाल  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI सह संयुक्तपणे देखभाल  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - अधिकृत TypeScript अंमलबजावणी  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - अधिकृत Python अंमलबजावणी  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - अधिकृत Kotlin अंमलबजावणी  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI सह संयुक्तपणे देखभाल  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - अधिकृत Rust अंमलबजावणी  

## मुख्य मुद्दे

- MCP विकास वातावरण सेट करणे सोपे आहे, भाषानुसार SDKs उपलब्ध आहेत  
- MCP सर्व्हर तयार करताना स्पष्ट स्कीमासह टूल्स तयार करणे आणि नोंदणी करणे आवश्यक आहे  
- चाचणी आणि डिबगिंग विश्वसनीय MCP अंमलबजावणीसाठी महत्त्वाचे आहे  

## नमुने

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## असाइनमेंट

तुमच्या पसंतीच्या भाषेत ( .NET, Java, Python, किंवा JavaScript) एक साधा MCP सर्व्हर तयार करा ज्यामध्ये तुमचा निवडलेला टूल असेल:  
1. टूलची अंमलबजावणी करा.  
2. इनपुट पॅरामीटर्स आणि रिटर्न व्हॅल्यूस परिभाषित करा.  
3. इन्स्पेक्टर टूल वापरून सर्व्हर योग्य प्रकारे काम करत आहे का ते तपासा.  
4. विविध इनपुट्ससह अंमलबजावणीची चाचणी करा.  

## सोल्यूशन

[Solution](./solution/README.md)

## अतिरिक्त संसाधने

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## पुढे काय

पुढे: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये चुका किंवा अपूर्णता असू शकतात. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवादाची शिफारस केली जाते. या अनुवादाच्या वापरामुळे होणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीसाठी आम्ही जबाबदार नाही.