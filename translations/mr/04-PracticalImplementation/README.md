<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:49:12+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "mr"
}
-->
# व्यावहारिक अंमलबजावणी

व्यावहारिक अंमलबजावणी म्हणजे Model Context Protocol (MCP) ची शक्ती प्रत्यक्षात जाणवते. MCP च्या सिद्धांत आणि आर्किटेक्चर समजून घेणे महत्त्वाचे असले तरी, खरी किंमत तेव्हा दिसून येते जेव्हा तुम्ही या संकल्पनांचा वापर करून वास्तविक समस्या सोडवणाऱ्या उपायांची रचना, चाचणी आणि तैनाती करता. हा अध्याय संकल्पनात्मक ज्ञान आणि प्रत्यक्ष विकास यामधील अंतर कमी करतो आणि तुम्हाला MCP आधारित अनुप्रयोग तयार करण्याच्या प्रक्रियेत मार्गदर्शन करतो.

तुम्ही बुद्धिमान सहाय्यक विकसित करत असाल, व्यवसाय प्रक्रियांमध्ये AI समाकलित करत असाल किंवा डेटा प्रक्रिया साठी सानुकूल साधने तयार करत असाल, MCP एक लवचिक पाया पुरवतो. त्याचा भाषा-स्वतंत्र डिझाइन आणि लोकप्रिय प्रोग्रामिंग भाषांसाठी अधिकृत SDKs विविध विकासकांसाठी सहज उपलब्ध करतात. या SDKs चा वापर करून तुम्ही वेगाने प्रोटोटाइप तयार करू शकता, पुनरावृत्ती करू शकता आणि विविध प्लॅटफॉर्म व वातावरणांवर तुमचे उपाय वाढवू शकता.

खालील विभागांमध्ये तुम्हाला व्यावहारिक उदाहरणे, नमुना कोड आणि तैनाती धोरणे सापडतील जी C#, Java, TypeScript, JavaScript आणि Python मध्ये MCP कसे अंमलात आणायचे हे दाखवतात. तुम्हाला MCP सर्व्हर डिबग आणि चाचणी कशी करायची, API व्यवस्थापन कसे करायचे आणि Azure वापरून क्लाउडवर उपाय कसे तैनात करायचे हे देखील शिकायला मिळेल. हे प्रत्यक्ष संसाधने तुमचे शिक्षण वेगवान करतील आणि तुम्हाला आत्मविश्वासाने मजबूत, उत्पादनासाठी तयार MCP अनुप्रयोग तयार करण्यात मदत करतील.

## आढावा

हा धडा MCP अंमलबजावणीच्या व्यावहारिक पैलूंवर लक्ष केंद्रित करतो, विविध प्रोग्रामिंग भाषांमध्ये. आपण C#, Java, TypeScript, JavaScript आणि Python मध्ये MCP SDKs कसे वापरायचे, MCP सर्व्हर डिबग आणि चाचणी कशी करायची, तसेच पुनर्वापरयोग्य संसाधने, प्रॉम्प्ट्स आणि साधने कशी तयार करायची हे पाहू.

## शिकण्याचे उद्दिष्ट

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:
- विविध प्रोग्रामिंग भाषांमध्ये अधिकृत SDKs वापरून MCP उपाय अंमलात आणणे
- MCP सर्व्हरची व्यवस्थित डिबगिंग आणि चाचणी करणे
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

हा विभाग विविध प्रोग्रामिंग भाषांमध्ये MCP अंमलबजावणीचे व्यावहारिक उदाहरणे पुरवतो. तुम्हाला `samples` निर्देशिकेत भाषेनुसार आयोजित नमुना कोड सापडेल.

### उपलब्ध नमुने

रिपॉझिटरीमध्ये खालील भाषांमध्ये [नमुना अंमलबजावणी](../../../04-PracticalImplementation/samples) समाविष्ट आहे:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

प्रत्येक नमुन्यात त्या विशिष्ट भाषा आणि परिसंस्थेसाठी MCP च्या मुख्य संकल्पना आणि अंमलबजावणी पद्धती दाखवल्या आहेत.

## मुख्य सर्व्हर वैशिष्ट्ये

MCP सर्व्हर खालील कोणत्याही वैशिष्ट्यांच्या संयोजनाची अंमलबजावणी करू शकतात:

### Resources  
Resources वापरकर्त्यास किंवा AI मॉडेलला संदर्भ आणि डेटा पुरवतात:  
- दस्तऐवज संच  
- ज्ञानाधार  
- संरचित डेटा स्रोत  
- फाइल सिस्टम

### Prompts  
Prompts वापरकर्त्यांसाठी टेम्प्लेटेड संदेश आणि वर्कफ्लो असतात:  
- पूर्वनिर्धारित संभाषण टेम्प्लेट  
- मार्गदर्शित संवाद नमुने  
- विशेष संवाद रचना

### Tools  
Tools AI मॉडेलसाठी कार्ये पार पाडण्यासाठी असतात:  
- डेटा प्रक्रिया उपयुक्तता  
- बाह्य API समाकलन  
- गणनात्मक क्षमता  
- शोध कार्यक्षमता

## नमुना अंमलबजावणी: C#

अधिकृत C# SDK रिपॉझिटरीमध्ये MCP च्या विविध पैलू दाखवणाऱ्या अनेक नमुना अंमलबजावण्या आहेत:

- **Basic MCP Client**: MCP क्लायंट तयार करून टूल कॉल कसे करायचे याचे सोपे उदाहरण  
- **Basic MCP Server**: मूलभूत टूल नोंदणीसह किमान सर्व्हर अंमलबजावणी  
- **Advanced MCP Server**: टूल नोंदणी, प्रमाणीकरण आणि त्रुटी हाताळणीसह पूर्ण वैशिष्ट्यांचा सर्व्हर  
- **ASP.NET Integration**: ASP.NET Core सह समाकलन दाखवणारी उदाहरणे  
- **Tool Implementation Patterns**: विविध जटिलतेच्या टूल्ससाठी अंमलबजावणी पद्धती

MCP C# SDK अजून प्रीव्ह्यूमध्ये आहे आणि API मध्ये बदल होऊ शकतात. SDK विकसित होत राहिल्याने हा ब्लॉग सतत अद्ययावत केला जाईल.

### मुख्य वैशिष्ट्ये  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- तुमचा [पहिला MCP Server तयार करणे](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

पूर्ण C# अंमलबजावणी नमुन्यांसाठी, [अधिकृत C# SDK नमुना रिपॉझिटरी](https://github.com/modelcontextprotocol/csharp-sdk) पहा.

## नमुना अंमलबजावणी: Java अंमलबजावणी

Java SDK एंटरप्राइझ-ग्रेड वैशिष्ट्यांसह मजबूत MCP अंमलबजावणी पर्याय पुरवतो.

### मुख्य वैशिष्ट्ये

- Spring Framework समाकलन  
- मजबूत टाइप सुरक्षा  
- प्रतिक्रियाशील प्रोग्रामिंग समर्थन  
- सर्वसमावेशक त्रुटी हाताळणी

पूर्ण Java अंमलबजावणी नमुन्यासाठी, नमुना निर्देशिकेतील [Java sample](samples/java/containerapp/README.md) पहा.

## नमुना अंमलबजावणी: JavaScript अंमलबजावणी

JavaScript SDK हलकी आणि लवचिक MCP अंमलबजावणीची पद्धत पुरवतो.

### मुख्य वैशिष्ट्ये

- Node.js आणि ब्राउझर समर्थन  
- Promise-आधारित API  
- Express आणि इतर फ्रेमवर्कसह सुलभ समाकलन  
- स्ट्रीमिंगसाठी WebSocket समर्थन

पूर्ण JavaScript अंमलबजावणी नमुन्यासाठी, नमुना निर्देशिकेतील [JavaScript sample](samples/javascript/README.md) पहा.

## नमुना अंमलबजावणी: Python अंमलबजावणी

Python SDK उत्कृष्ट ML फ्रेमवर्क समाकलनांसह Python-आधारित MCP अंमलबजावणी पुरवतो.

### मुख्य वैशिष्ट्ये

- asyncio सह Async/await समर्थन  
- Flask आणि FastAPI समाकलन  
- सोपी टूल नोंदणी  
- लोकप्रिय ML लायब्ररींसह नैसर्गिक समाकलन

पूर्ण Python अंमलबजावणी नमुन्यासाठी, नमुना निर्देशिकेतील [Python sample](samples/python/README.md) पहा.

## API व्यवस्थापन

Azure API Management हे MCP सर्व्हर सुरक्षित करण्याचा उत्तम उपाय आहे. कल्पना अशी आहे की तुमच्या MCP सर्व्हरच्या समोर Azure API Management इंस्टन्स ठेवायचा आणि तो खालील सारख्या वैशिष्ट्यांची जबाबदारी घेईल:

- दर मर्यादा (rate limiting)  
- टोकन व्यवस्थापन  
- निरीक्षण (monitoring)  
- लोड बॅलन्सिंग  
- सुरक्षा

### Azure नमुना

खालील Azure नमुना हेच करतो, म्हणजेच [MCP Server तयार करणे आणि Azure API Management सह सुरक्षित करणे](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

खालील प्रतिमेत अधिकृतता प्रक्रिया कशी होते ते पहा:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

वरील प्रतिमेत खालील गोष्टी घडतात:

- प्रमाणीकरण/अधिकृतता Microsoft Entra वापरून केली जाते.  
- Azure API Management गेटवे म्हणून कार्य करते आणि धोरणांचा वापर करून ट्रॅफिकचे मार्गदर्शन व व्यवस्थापन करते.  
- Azure Monitor पुढील विश्लेषणासाठी सर्व विनंत्या लॉग करतो.

#### अधिकृतता प्रवाह

अधिकृतता प्रवाह अधिक तपशीलात पाहू:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP अधिकृतता तपशील

अधिक जाणून घेण्यासाठी [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) पहा.

## Azure वर Remote MCP Server तैनात करणे

आता आपण आधी नमूद केलेला नमुना तैनात करू शकतो का ते पाहू:

1. रिपॉझिटरी क्लोन करा

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` resource provider नोंदणी करा.  
    * Azure CLI वापरत असल्यास, `az provider register --namespace Microsoft.App --wait` चालवा.  
    * Azure PowerShell वापरत असल्यास, `Register-AzResourceProvider -ProviderNamespace Microsoft.App` चालवा. नंतर काही वेळाने `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` तपासा की नोंदणी पूर्ण झाली आहे का.

3. API Management सेवा, function app (कोडसह) आणि इतर आवश्यक Azure संसाधने तयार करण्यासाठी हा [azd](https://aka.ms/azd) आदेश चालवा:

    ```shell
    azd up
    ```

    हा आदेश Azure वर सर्व क्लाउड संसाधने तैनात करेल.

### MCP Inspector सह तुमचा सर्व्हर चाचणी करणे

1. **नवीन टर्मिनल विंडो** मध्ये MCP Inspector इंस्टॉल आणि चालवा

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    तुम्हाला खालीलप्रमाणे इंटरफेस दिसेल:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.mr.png) 

2. CTRL क्लिक करून MCP Inspector वेब अॅप URL वरून लोड करा (उदा. http://127.0.0.1:6274/#resources)  
3. ट्रान्सपोर्ट प्रकार `SSE` सेट करा  
4. तुमच्या चालू API Management SSE endpoint चा URL सेट करा जो `azd up` नंतर दिसतो आणि **Connect** करा:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools** वर क्लिक करा. टूल निवडा आणि **Run Tool** करा.

जर सर्व पावले यशस्वी झाली, तर तुम्ही आता MCP सर्व्हरशी जोडलेले आहात आणि टूल कॉल करू शकलात.

## Azure साठी MCP सर्व्हर

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): ही रिपॉझिटरी सेट Azure Functions वापरून Python, C# .NET किंवा Node/TypeScript मध्ये सानुकूल रिमोट MCP (Model Context Protocol) सर्व्हर तयार करण्यासाठी जलद प्रारंभ टेम्प्लेट आहे.

हे नमुने विकासकांना पूर्ण उपाय पुरवतात ज्यामुळे ते:

- स्थानिकपणे तयार आणि चालवू शकतात: स्थानिक मशीनवर MCP सर्व्हर विकसित आणि डिबग करा  
- Azure वर तैनात करा: सोप्या azd up आदेशाने क्लाउडवर सहज तैनात करा  
- क्लायंट्सकडून कनेक्ट करा: विविध क्लायंट्समधून MCP सर्व्हरशी कनेक्ट व्हा, जसे VS Code चा Copilot एजंट मोड आणि MCP Inspector टूल

### मुख्य वैशिष्ट्ये:

- डिझाइननुसार सुरक्षा: MCP सर्व्हर कीज आणि HTTPS वापरून सुरक्षित केला आहे  
- प्रमाणीकरण पर्याय: अंगभूत प्रमाणीकरण आणि/किंवा API Management वापरून OAuth समर्थन  
- नेटवर्क पृथक्करण: Azure Virtual Networks (VNET) वापरून नेटवर्क पृथक्करण  
- सर्व्हरलेस आर्किटेक्चर: Azure Functions वापरून स्केलेबल, इव्हेंट-चालित अंमलबजावणी  
- स्थानिक विकास: व्यापक स्थानिक विकास आणि डिबगिंग समर्थन  
- सोपी तैनाती: Azure वर सुलभ तैनाती प्रक्रिया

रिपॉझिटरीमध्ये सर्व आवश्यक कॉन्फिगरेशन फाइल्स, स्रोत कोड आणि इन्फ्रास्ट्रक्चर परिभाषा आहेत ज्यामुळे तुम्ही उत्पादनासाठी तयार MCP सर्व्हर अंमलबजावणी लवकर सुरू करू शकता.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure Functions सह Python वापरून MCP चे नमुना अंमलबजावणी  
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Azure Functions सह C# .NET वापरून MCP चे नमुना अंमलबजावणी  
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Azure Functions सह Node/TypeScript वापरून MCP चे नमुना अंमलबजावणी

## मुख्य मुद्दे

- MCP SDKs भाषा-विशिष्ट साधने पुरवतात ज्यामुळे मजबूत MCP उपाय अंमलात आणता येतात  
- डिबगिंग आणि चाचणी प्रक्रिया विश्वासार्ह MCP अनुप्रयोगांसाठी अत्यंत महत्त्वाची आहे  
- पुनर्वापरयोग्य प्रॉम्प्ट टेम्प्लेट्स AI संवाद सुसंगत करतात  
- चांगल्या डिझाइन केलेले वर्कफ्लो अनेक टूल्स वापरून गुंतागुंतीची कामे सुलभ करतात  
- MCP उपाय अंमलात आणताना सुरक्षा, कार्यक्षमता आणि त्रुटी हाताळणी यांचा विचार करणे आवश्यक आहे

## सराव

तुमच्या क्षेत्रातील वास्तविक समस्येवर आधारित व्यावहारिक MCP वर्कफ्लो डिझाइन करा:

1. या समस्येचे निराकरण करण्यासाठी 3-4 उपयुक्त टूल्स ओळखा  
2. या टूल्स कसे परस्परसंवाद करतात हे दाखवणारा वर्कफ्लो आकृती तयार करा  
3. तुमच्या पसंतीच्या भाषेत एक टूलचा मूलभूत आवृत्ती अंमलात आणा  
4. मॉडेलला तुमचे टूल प्रभावीपणे वापरण्यास मदत करणारा प्रॉम्प्ट टेम्प्लेट तयार करा

## अतिरिक्त संसाधने


---

पुढे: [प्रगत विषय](../05-AdvancedTopics/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.