<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T08:54:01+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "mr"
}
-->
# व्यावहारिक अंमलबजावणी

व्यावहारिक अंमलबजावणी म्हणजे Model Context Protocol (MCP) ची ताकद प्रत्यक्षात अनुभवण्याचा भाग आहे. MCP च्या सिद्धांत आणि आर्किटेक्चर समजून घेणे महत्त्वाचे असले तरी, खऱ्या मूल्याची ओळख तेव्हा होते जेव्हा आपण या संकल्पनांचा वापर करून वास्तविक समस्यांसाठी उपाय तयार करतो, चाचणी करतो आणि तैनात करतो. हा अध्याय संकल्पनात्मक ज्ञान आणि प्रत्यक्ष विकास यांच्यातील अंतर कमी करतो, आणि MCP आधारित अनुप्रयोग तयार करण्याच्या प्रक्रियेत मार्गदर्शन करतो.

आपण बुद्धिमान सहाय्यक विकसित करत असाल, व्यवसाय प्रक्रियेत AI समाकलित करत असाल किंवा डेटा प्रक्रियेसाठी सानुकूल साधने तयार करत असाल, MCP लवचिक पाया पुरवतो. याचा भाषा-स्वतंत्र डिझाइन आणि लोकप्रिय प्रोग्रामिंग भाषांसाठी अधिकृत SDKs मुळे अनेक विकासकांना हे सहज उपलब्ध होते. या SDKs चा उपयोग करून आपण वेगाने प्रोटोटाइप तयार करू शकता, पुनरावृत्ती करू शकता आणि विविध प्लॅटफॉर्म आणि वातावरणांवर आपले उपाय स्केल करू शकता.

खालील विभागांमध्ये आपण C#, Java, TypeScript, JavaScript, आणि Python मध्ये MCP कसे अंमलात आणायचे याचे व्यावहारिक उदाहरणे, नमुना कोड आणि तैनाती धोरणे पाहाल. तसेच MCP सर्व्हर्स डिबग आणि टेस्ट कसे करायचे, API व्यवस्थापन कसे करायचे, आणि Azure वापरून क्लाउडवर उपाय कसे तैनात करायचे हे शिकाल. हे प्रत्यक्ष संसाधने आपल्या शिकण्याच्या प्रक्रियेला वेग देण्यासाठी आणि आत्मविश्वासाने मजबूत, उत्पादनासाठी तयार MCP अनुप्रयोग तयार करण्यासाठी डिझाइन केलेले आहेत.

## आढावा

हा धडा MCP अंमलबजावणीच्या व्यावहारिक पैलूंवर लक्ष केंद्रित करतो, अनेक प्रोग्रामिंग भाषांमध्ये. आपण C#, Java, TypeScript, JavaScript, आणि Python मध्ये MCP SDKs कसे वापरायचे, MCP सर्व्हर्स कसे डिबग आणि टेस्ट करायचे, तसेच पुनर्वापर करता येणारे संसाधने, प्रॉम्प्ट्स आणि साधने कशी तयार करायची हे पाहू.

## शिकण्याचे उद्दिष्ट

या धड्याच्या शेवटी, आपण सक्षम असाल:
- विविध प्रोग्रामिंग भाषांमध्ये अधिकृत SDKs वापरून MCP उपाय अंमलात आणणे
- MCP सर्व्हर्सचे सुसंगतपणे डिबग आणि टेस्ट करणे
- सर्व्हर वैशिष्ट्ये (Resources, Prompts, आणि Tools) तयार करणे आणि वापरणे
- गुंतागुंतीच्या कामांसाठी प्रभावी MCP वर्कफ्लो डिझाइन करणे
- कार्यक्षमता आणि विश्वासार्हतेसाठी MCP अंमलबजावणीचे ऑप्टिमायझेशन करणे

## अधिकृत SDK संसाधने

Model Context Protocol अनेक भाषांसाठी अधिकृत SDKs पुरवतो:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDKs सह काम करणे

हा विभाग अनेक प्रोग्रामिंग भाषांमध्ये MCP अंमलबजावणीचे व्यावहारिक उदाहरणे देतो. आपण `samples` निर्देशिकेत भाषानुसार वर्गीकृत नमुना कोड पाहू शकता.

### उपलब्ध नमुने

रिपॉझिटरीमध्ये खालील भाषांमध्ये [नमुना अंमलबजावणी](../../../04-PracticalImplementation/samples) समाविष्ट आहेत:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

प्रत्येक नमुना त्या विशिष्ट भाषा आणि परिसंस्थेसाठी MCP च्या मुख्य संकल्पना आणि अंमलबजावणी पद्धती दाखवतो.

## मुख्य सर्व्हर वैशिष्ट्ये

MCP सर्व्हर खालील कोणत्याही वैशिष्ट्यांचे संयोजन अंमलात आणू शकतात:

### Resources  
Resources वापरकर्त्याला किंवा AI मॉडेलला संदर्भ आणि डेटा पुरवतात:
- दस्तऐवज संच
- ज्ञान आधार
- संरचित डेटा स्रोत
- फाइल सिस्टम

### Prompts  
Prompts वापरकर्त्यांसाठी टेम्प्लेटेड संदेश आणि वर्कफ्लो असतात:
- पूर्वनिर्धारित संभाषण टेम्प्लेट्स
- मार्गदर्शित संवाद नमुने
- विशेष संवाद रचना

### Tools  
Tools AI मॉडेलला चालवायच्या फंक्शन्स आहेत:
- डेटा प्रक्रिया उपयोगी साधने
- बाह्य API समाकलन
- संगणकीय क्षमता
- शोध कार्यक्षमता

## नमुना अंमलबजावणी: C#

अधिकृत C# SDK रिपॉझिटरीमध्ये MCP च्या विविध पैलूंचे नमुना अंमलबजावणी समाविष्ट आहेत:

- **Basic MCP Client**: MCP क्लायंट कसा तयार करायचा आणि टूल्स कसे कॉल करायचे याचे सोपे उदाहरण
- **Basic MCP Server**: मूलभूत टूल नोंदणीसह सर्वात कमी सर्व्हर अंमलबजावणी
- **Advanced MCP Server**: टूल नोंदणी, प्रमाणीकरण आणि त्रुटी हाताळणीसह पूर्ण वैशिष्ट्यांचा सर्व्हर
- **ASP.NET Integration**: ASP.NET Core सह समाकलन दाखवणारे उदाहरण
- **Tool Implementation Patterns**: विविध जटिलतेच्या टूल्स अंमलबजावणीसाठी विविध नमुना पद्धती

MCP C# SDK अजून प्रिव्ह्यूमध्ये आहे आणि API मध्ये बदल होऊ शकतात. SDK विकसित होत असल्याने हा ब्लॉग सतत अपडेट केला जाईल.

### मुख्य वैशिष्ट्ये  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- आपला [पहिला MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) तयार करणे.

पूर्ण C# अंमलबजावणी नमुन्यांसाठी, [अधिकृत C# SDK नमुना रिपॉझिटरी](https://github.com/modelcontextprotocol/csharp-sdk) भेट द्या.

## नमुना अंमलबजावणी: Java अंमलबजावणी

Java SDK मध्ये उद्योजक-स्तरीय वैशिष्ट्यांसह मजबूत MCP अंमलबजावणी पर्याय आहेत.

### मुख्य वैशिष्ट्ये

- Spring Framework समाकलन
- मजबूत टाइप सुरक्षा
- प्रतिक्रियाशील प्रोग्रामिंग समर्थन
- सर्वसमावेशक त्रुटी हाताळणी

पूर्ण Java अंमलबजावणी नमुन्यासाठी, नमुना निर्देशिकेतील [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) पहा.

## नमुना अंमलबजावणी: JavaScript अंमलबजावणी

JavaScript SDK MCP अंमलबजावणीसाठी हलके आणि लवचिक दृष्टिकोन प्रदान करतो.

### मुख्य वैशिष्ट्ये

- Node.js आणि ब्राउझर समर्थन
- Promise-आधारित API
- Express आणि इतर फ्रेमवर्कसह सुलभ समाकलन
- स्ट्रीमिंगसाठी WebSocket समर्थन

पूर्ण JavaScript अंमलबजावणी नमुन्यासाठी, नमुना निर्देशिकेतील [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) पहा.

## नमुना अंमलबजावणी: Python अंमलबजावणी

Python SDK उत्कृष्ट ML फ्रेमवर्क समाकलनांसह Python-शैलीतील MCP अंमलबजावणी देते.

### मुख्य वैशिष्ट्ये

- asyncio सह Async/await समर्थन
- Flask आणि FastAPI समाकलन
- सोपी टूल नोंदणी
- लोकप्रिय ML लायब्ररींसह नैसर्गिक समाकलन

पूर्ण Python अंमलबजावणी नमुन्यासाठी, नमुना निर्देशिकेतील [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) पहा.

## API व्यवस्थापन

Azure API Management हे MCP सर्व्हर्स सुरक्षित कसे करायचे याचे उत्तम उत्तर आहे. कल्पना अशी की आपण आपल्या MCP सर्व्हरच्या पुढे Azure API Management इन्स्टन्स ठेवता आणि ते खालील सारख्या वैशिष्ट्ये हाताळते:

- दर मर्यादा (rate limiting)
- टोकन व्यवस्थापन
- निरीक्षण (monitoring)
- लोड बॅलन्सिंग
- सुरक्षा

### Azure नमुना

येथे एक Azure नमुना आहे जो अगदी तसेच करतो, म्हणजे [MCP Server तयार करणे आणि Azure API Management ने सुरक्षित करणे](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

खालील प्रतिमेत प्राधिकरण प्रवाह कसा होतो ते पहा:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

वरील प्रतिमेत खालील प्रक्रिया घडते:

- प्रमाणीकरण/प्राधिकरण Microsoft Entra वापरून होते.
- Azure API Management गेटवे म्हणून कार्य करते आणि ट्रॅफिक नियंत्रित करण्यासाठी धोरणे वापरते.
- Azure Monitor पुढील विश्लेषणासाठी सर्व विनंत्या लॉग करतो.

#### प्राधिकरण प्रवाह

प्राधिकरण प्रवाह अधिक तपशीलवार पाहूया:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP प्राधिकरण तपशील

अधिक जाणून घेण्यासाठी [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) पहा.

## Remote MCP Server Azure वर तैनात करणे

आता आपण पूर्वी नमूद केलेला नमुना तैनात करू शकतो का ते पाहू:

1. रिपॉझिटरी क्लोन करा

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` नोंदणी करा:

    ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run ` (काही वेळानंतर नोंदणी पूर्ण झाली आहे का ते तपासण्यासाठी)

3. या [azd](https://aka.ms/azd) कमांडचा वापर करून API Management सेवा, Function App (कोडसह) आणि इतर आवश्यक Azure संसाधने तयार करा:

    ```shell
    azd up
    ```

    या कमांडने Azure वर सर्व क्लाउड संसाधने तैनात केली पाहिजेत.

### MCP Inspector वापरून आपला सर्व्हर टेस्ट करणे

1. **नवीन टर्मिनल विंडोमध्ये**, MCP Inspector इन्स्टॉल करा आणि चालवा:

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    आपल्याला खालीलप्रमाणे इंटरफेस दिसेल:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.mr.png)

2. CTRL क्लिक करून MCP Inspector वेब अॅप त्या URL वरून लोड करा (उदा. http://127.0.0.1:6274/#resources)
3. ट्रान्सपोर्ट प्रकार `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` सेट करा आणि **Connect** करा:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. एखाद्या टूलवर क्लिक करा आणि **Run Tool** करा.

जर सर्व पावले यशस्वी झाली, तर आपण आता MCP सर्व्हरशी जोडलेले आहात आणि टूल कॉल करू शकलात.

## Azure साठी MCP सर्व्हर्स

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): या रिपॉझिटरी सेटमध्ये Azure Functions वापरून Python, C# .NET किंवा Node/TypeScript सह सानुकूल Remote MCP (Model Context Protocol) सर्व्हर्स तयार करण्यासाठी जलद प्रारंभ टेम्प्लेट आहेत.

हे नमुने विकसितकर्त्यांना संपूर्ण समाधान देतात जे त्यांना परवानगी देतात:

- स्थानिकपणे तयार आणि चालवा: स्थानिक मशीनवर MCP सर्व्हर विकसित आणि डिबग करा
- Azure वर तैनात करा: सोप्या azd up कमांडने क्लाउडवर सहज तैनात करा
- क्लायंट्स कडून कनेक्ट करा: VS Code च्या Copilot एजंट मोड आणि MCP Inspector टूलसह विविध क्लायंट्सकडून MCP सर्व्हरशी कनेक्ट व्हा

### मुख्य वैशिष्ट्ये:

- सुरक्षेची रचना: MCP सर्व्हर कीज आणि HTTPS वापरून सुरक्षित केला आहे
- प्रमाणीकरण पर्याय: अंगभूत प्रमाणीकरण आणि/किंवा API Management वापरून OAuth समर्थन
- नेटवर्क पृथक्करण: Azure Virtual Networks (VNET) वापरून नेटवर्क पृथक्करण सक्षम करते
- सर्व्हरलेस आर्किटेक्चर: स्केलेबल, इव्हेंट-चालित अंमलबजावणीसाठी Azure Functions वापरते
- स्थानिक विकास: व्यापक स्थानिक विकास आणि डिबगिंग समर्थन
- सोपी तैनाती: Azure वर तैनातीसाठी सुलभ प्रक्रिया

रिपॉझिटरीमध्ये सर्व आवश्यक कॉन्फिगरेशन फाइल्स, स्त्रोत कोड आणि इन्फ्रास्ट्रक्चर परिभाषा आहेत ज्यामुळे उत्पादनासाठी तयार MCP सर्व्हर अंमलबजावणी जलद सुरू करता येते.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure Functions वापरून Python मध्ये MCP चे नमुना अंमलबजावणी

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Azure Functions वापरून C# .NET मध्ये MCP चे नमुना अंमलबजावणी

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Azure Functions वापरून Node/TypeScript मध्ये MCP चे नमुना अंमलबजावणी

## मुख्य मुद्दे

- MCP SDKs भाषा-विशिष्ट साधने पुरवतात ज्याद्वारे मजबूत MCP उपाय अंमलात आणता येतात
- डिबगिंग आणि टेस्टिंग प्रक्रिया विश्वासार्ह MCP अनुप्रयोगांसाठी अत्यंत महत्त्वाची आहे
- पुनर्वापर करता येणाऱ्या प्रॉम्प्ट टेम्प्लेट्समुळे AI संवाद सातत्यपूर्ण होतात
- चांगल्या डिझाइन केलेल्या वर्कफ्लोने अनेक टूल्स वापरून गुंतागुंतीचे काम सहज हाताळता येतात
- MCP उपाय अंमलात आणताना सुरक्षा, कार्यक्षमता आणि त्रुटी हाताळणीचा विचार करणे आवश्यक आहे

## सराव

आपल्या क्षेत्रातील वास्तविक समस्येवर लक्ष केंद्रित करणारा व्यावहारिक MCP वर्कफ्लो डिझाइन करा:

1. या समस्येचे निराकरण करण्यासाठी उपयुक्त 3-4 टूल्स ओळखा
2. या टूल्स कसे परस्परसंवाद करतात हे दाखवणारा वर्कफ्लो आरेख तयार करा
3. आपल्या पसंतीच्या भाषेत एक टूलचा प्राथमिक आवृत्ती तयार करा
4. मॉडेलला आपले टूल प्रभावीपणे वापरण्यास मदत करणारा प्रॉम्प्ट टेम्प्लेट तयार करा

## अतिरिक्त संसाधने


---

पुढील: [Advanced Topics](../05-AdvancedTopics/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला पाहिजे. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवादाची शिफारस केली जाते. या अनुवादाच्या वापरामुळे होणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थव्यवस्थेसाठी आम्ही जबाबदार नाही.