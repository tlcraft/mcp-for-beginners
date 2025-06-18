<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T08:49:59+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hi"
}
-->
# व्यावहारिक कार्यान्वयन

व्यावहारिक कार्यान्वयन वह जगह है जहाँ Model Context Protocol (MCP) की शक्ति वास्तविक रूप में सामने आती है। MCP के सिद्धांत और वास्तुकला को समझना महत्वपूर्ण है, लेकिन असली मूल्य तब उत्पन्न होता है जब आप इन अवधारणाओं को वास्तविक दुनिया की समस्याओं को हल करने वाले समाधानों को बनाने, परीक्षण करने और परिनियोजित करने में लागू करते हैं। यह अध्याय सैद्धांतिक ज्ञान और व्यावहारिक विकास के बीच की खाई को पाटता है, और आपको MCP-आधारित अनुप्रयोगों को जीवंत बनाने की प्रक्रिया में मार्गदर्शन करता है।

चाहे आप बुद्धिमान सहायक विकसित कर रहे हों, व्यवसाय के कार्यप्रवाहों में AI को एकीकृत कर रहे हों, या डेटा प्रोसेसिंग के लिए कस्टम टूल बना रहे हों, MCP एक लचीला आधार प्रदान करता है। इसकी भाषा-स्वतंत्र डिज़ाइन और लोकप्रिय प्रोग्रामिंग भाषाओं के लिए आधिकारिक SDK इसे कई प्रकार के डेवलपर्स के लिए सुलभ बनाते हैं। इन SDKs का उपयोग करके, आप जल्दी से प्रोटोटाइप बना सकते हैं, पुनरावृत्ति कर सकते हैं, और विभिन्न प्लेटफार्मों और पर्यावरणों में अपने समाधानों का पैमाना बढ़ा सकते हैं।

आगामी अनुभागों में, आपको व्यावहारिक उदाहरण, नमूना कोड, और परिनियोजन रणनीतियाँ मिलेंगी जो दिखाती हैं कि C#, Java, TypeScript, JavaScript, और Python में MCP को कैसे लागू किया जाए। आप यह भी सीखेंगे कि MCP सर्वरों को कैसे डिबग और टेस्ट करें, APIs का प्रबंधन कैसे करें, और Azure का उपयोग करके क्लाउड में समाधान कैसे तैनात करें। ये व्यावहारिक संसाधन आपकी सीखने की गति को बढ़ाने और मजबूत, उत्पादन-तैयार MCP अनुप्रयोगों को आत्मविश्वास से बनाने में मदद करने के लिए डिज़ाइन किए गए हैं।

## अवलोकन

यह पाठ MCP के व्यावहारिक कार्यान्वयन के पहलुओं पर केंद्रित है, जो कई प्रोग्रामिंग भाषाओं में लागू किया जाता है। हम देखेंगे कि कैसे C#, Java, TypeScript, JavaScript, और Python में MCP SDKs का उपयोग करके मजबूत अनुप्रयोग बनाए जाएं, MCP सर्वरों को डिबग और टेस्ट किया जाए, और पुन: उपयोग योग्य संसाधन, प्रॉम्प्ट, और टूल बनाए जाएं।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:
- विभिन्न प्रोग्रामिंग भाषाओं में आधिकारिक SDKs का उपयोग करके MCP समाधान लागू करना
- MCP सर्वरों को व्यवस्थित रूप से डिबग और टेस्ट करना
- सर्वर फीचर्स (Resources, Prompts, और Tools) बनाना और उपयोग करना
- जटिल कार्यों के लिए प्रभावी MCP कार्यप्रवाह डिजाइन करना
- प्रदर्शन और विश्वसनीयता के लिए MCP कार्यान्वयन का अनुकूलन करना

## आधिकारिक SDK संसाधन

Model Context Protocol कई भाषाओं के लिए आधिकारिक SDK प्रदान करता है:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDKs के साथ काम करना

यह अनुभाग कई प्रोग्रामिंग भाषाओं में MCP को लागू करने के व्यावहारिक उदाहरण प्रदान करता है। आप `samples` निर्देशिका में भाषा के अनुसार व्यवस्थित नमूना कोड पा सकते हैं।

### उपलब्ध नमूने

इस रिपॉजिटरी में निम्नलिखित भाषाओं में [नमूना कार्यान्वयन](../../../04-PracticalImplementation/samples) शामिल हैं:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

प्रत्येक नमूना उस विशेष भाषा और पारिस्थितिकी तंत्र के लिए प्रमुख MCP अवधारणाओं और कार्यान्वयन पैटर्न को दर्शाता है।

## मुख्य सर्वर फीचर्स

MCP सर्वर निम्नलिखित फीचर्स के किसी भी संयोजन को लागू कर सकते हैं:

### Resources  
Resources उपयोगकर्ता या AI मॉडल के लिए संदर्भ और डेटा प्रदान करते हैं:
- दस्तावेज़ रिपॉजिटरी
- ज्ञान आधार
- संरचित डेटा स्रोत
- फ़ाइल सिस्टम

### Prompts  
Prompts उपयोगकर्ताओं के लिए टेम्प्लेटेड संदेश और कार्यप्रवाह होते हैं:
- पूर्व-निर्धारित संवाद टेम्पलेट
- मार्गदर्शित इंटरैक्शन पैटर्न
- विशिष्ट संवाद संरचनाएँ

### Tools  
Tools AI मॉडल द्वारा निष्पादित किए जाने वाले कार्य होते हैं:
- डेटा प्रोसेसिंग यूटिलिटीज़
- बाहरी API एकीकरण
- गणनात्मक क्षमताएँ
- खोज कार्यक्षमता

## नमूना कार्यान्वयन: C#

आधिकारिक C# SDK रिपॉजिटरी में MCP के विभिन्न पहलुओं को दर्शाने वाले कई नमूना कार्यान्वयन शामिल हैं:

- **Basic MCP Client**: एक सरल उदाहरण जो दिखाता है कि कैसे MCP क्लाइंट बनाया जाए और टूल्स को कॉल किया जाए
- **Basic MCP Server**: बुनियादी टूल पंजीकरण के साथ न्यूनतम सर्वर कार्यान्वयन
- **Advanced MCP Server**: टूल पंजीकरण, प्रमाणीकरण, और त्रुटि हैंडलिंग के साथ पूर्ण-विशेषताओं वाला सर्वर
- **ASP.NET Integration**: ASP.NET Core के साथ एकीकरण के उदाहरण
- **Tool Implementation Patterns**: विभिन्न जटिलता स्तरों के साथ टूल कार्यान्वयन के पैटर्न

MCP C# SDK अभी प्रीव्यू में है और APIs में परिवर्तन हो सकते हैं। जैसे-जैसे SDK विकसित होगा, हम इस ब्लॉग को अपडेट करते रहेंगे।

### प्रमुख फीचर्स  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- अपना [पहला MCP Server बनाना](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)।

पूर्ण C# कार्यान्वयन नमूनों के लिए, [आधिकारिक C# SDK नमूना रिपॉजिटरी](https://github.com/modelcontextprotocol/csharp-sdk) देखें।

## नमूना कार्यान्वयन: Java Implementation

Java SDK उद्यम-स्तरीय फीचर्स के साथ मजबूत MCP कार्यान्वयन विकल्प प्रदान करता है।

### प्रमुख फीचर्स

- Spring Framework एकीकरण
- मजबूत प्रकार सुरक्षा
- प्रतिक्रियाशील प्रोग्रामिंग समर्थन
- व्यापक त्रुटि प्रबंधन

पूर्ण Java कार्यान्वयन नमूने के लिए, samples डायरेक्टरी में [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) देखें।

## नमूना कार्यान्वयन: JavaScript Implementation

JavaScript SDK हल्के और लचीले MCP कार्यान्वयन के लिए एक तरीका प्रदान करता है।

### प्रमुख फीचर्स

- Node.js और ब्राउज़र समर्थन
- प्रॉमिस-आधारित API
- Express और अन्य फ्रेमवर्क के साथ आसान एकीकरण
- स्ट्रीमिंग के लिए WebSocket समर्थन

पूर्ण JavaScript कार्यान्वयन नमूने के लिए, samples डायरेक्टरी में [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) देखें।

## नमूना कार्यान्वयन: Python Implementation

Python SDK उत्कृष्ट ML फ्रेमवर्क एकीकरण के साथ Python-उन्मुख MCP कार्यान्वयन प्रदान करता है।

### प्रमुख फीचर्स

- asyncio के साथ Async/await समर्थन
- Flask और FastAPI एकीकरण
- सरल टूल पंजीकरण
- लोकप्रिय ML लाइब्रेरीज के साथ मूल एकीकरण

पूर्ण Python कार्यान्वयन नमूने के लिए, samples डायरेक्टरी में [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) देखें।

## API प्रबंधन

Azure API Management MCP सर्वरों को सुरक्षित करने का एक बेहतरीन समाधान है। विचार यह है कि आप अपने MCP Server के सामने एक Azure API Management इंस्टेंस रखें और इसे उन फीचर्स को संभालने दें जो आप चाहते हैं, जैसे:

- दर सीमित करना (rate limiting)
- टोकन प्रबंधन
- निगरानी
- लोड संतुलन
- सुरक्षा

### Azure नमूना

यहाँ एक Azure नमूना है जो ठीक यही करता है, अर्थात् [MCP Server बनाना और Azure API Management के साथ सुरक्षित करना](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)।

नीचे की छवि में देखें कि प्राधिकरण प्रवाह कैसे होता है:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

पिछली छवि में निम्नलिखित होता है:

- Microsoft Entra का उपयोग करके प्रमाणीकरण/प्राधिकरण होता है।
- Azure API Management एक गेटवे के रूप में कार्य करता है और नीतियों का उपयोग करके ट्रैफ़िक को निर्देशित और प्रबंधित करता है।
- Azure Monitor सभी अनुरोधों को आगे के विश्लेषण के लिए लॉग करता है।

#### प्राधिकरण प्रवाह

आइए प्राधिकरण प्रवाह को और विस्तार से देखें:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP प्राधिकरण विनिर्देशन

[MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) के बारे में और जानें।

## Remote MCP Server को Azure पर तैनात करना

आइए देखें कि क्या हम पहले बताए गए नमूने को तैनात कर सकते हैं:

1. रिपॉजिटरी क्लोन करें

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` प्रदाता को पंजीकृत करें

    `az provider register --namespace Microsoft.App --wait`  
    या  
    `Register-AzResourceProvider -ProviderNamespace Microsoft.App`  
    और कुछ समय बाद जांचें कि पंजीकरण पूरा हुआ है या नहीं:  
    `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

3. इस [azd](https://aka.ms/azd) कमांड को चलाएं ताकि API Management सेवा, फ़ंक्शन ऐप (कोड के साथ), और अन्य आवश्यक Azure संसाधन प्रोविजन किए जा सकें

    ```shell
    azd up
    ```

    यह कमांड Azure पर सभी क्लाउड संसाधनों को तैनात कर देगा।

### MCP Inspector के साथ अपने सर्वर का परीक्षण करना

1. **नई टर्मिनल विंडो** में MCP Inspector इंस्टॉल और चलाएं

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    आपको इस तरह का इंटरफ़ेस दिखेगा:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hi.png)

2. CTRL क्लिक करें ताकि ऐप द्वारा प्रदर्शित URL (जैसे http://127.0.0.1:6274/#resources) से MCP Inspector वेब ऐप लोड हो जाए
3. ट्रांसपोर्ट प्रकार को `SSE` सेट करें और **Connect** करें:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools** पर क्लिक करें। किसी टूल पर क्लिक करके **Run Tool** करें।

यदि सभी चरण सफलतापूर्वक हुए हैं, तो आप अब MCP सर्वर से जुड़ चुके हैं और एक टूल कॉल करने में सक्षम हैं।

## Azure के लिए MCP सर्वर

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): यह रिपॉजिटरी सेट Azure Functions के साथ Python, C# .NET, या Node/TypeScript का उपयोग करके कस्टम रिमोट MCP (Model Context Protocol) सर्वर बनाने और तैनात करने के लिए क्विकस्टार्ट टेम्प्लेट प्रदान करता है।

यह नमूना डेवलपर्स को निम्नलिखित पूरी सुविधा देता है:

- लोकल पर निर्माण और चलाना: स्थानीय मशीन पर MCP सर्वर विकसित और डिबग करें
- Azure पर तैनात करना: क्लाउड पर आसानी से azd up कमांड के साथ तैनाती करें
- क्लाइंट से कनेक्ट करना: विभिन्न क्लाइंट्स से MCP सर्वर से जुड़ें, जिनमें VS Code का Copilot एजेंट मोड और MCP Inspector टूल शामिल हैं

### प्रमुख फीचर्स:

- डिज़ाइन से सुरक्षा: MCP सर्वर कुंजी और HTTPS के माध्यम से सुरक्षित है
- प्रमाणीकरण विकल्प: बिल्ट-इन ऑथ और/या API Management का उपयोग करके OAuth का समर्थन करता है
- नेटवर्क पृथक्करण: Azure Virtual Networks (VNET) का उपयोग करके नेटवर्क पृथक्करण की अनुमति देता है
- सर्वरलेस आर्किटेक्चर: स्केलेबल, इवेंट-ड्रिवन निष्पादन के लिए Azure Functions का लाभ उठाता है
- स्थानीय विकास: व्यापक स्थानीय विकास और डिबगिंग समर्थन
- सरल तैनाती: Azure के लिए सुव्यवस्थित तैनाती प्रक्रिया

रिपॉजिटरी में सभी आवश्यक कॉन्फ़िगरेशन फाइलें, स्रोत कोड, और इन्फ्रास्ट्रक्चर परिभाषाएँ शामिल हैं ताकि आप जल्दी से उत्पादन-तैयार MCP सर्वर कार्यान्वयन के साथ शुरुआत कर सकें।

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python के साथ Azure Functions का उपयोग करते हुए MCP का नमूना कार्यान्वयन

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET के साथ Azure Functions का उपयोग करते हुए MCP का नमूना कार्यान्वयन

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript के साथ Azure Functions का उपयोग करते हुए MCP का नमूना कार्यान्वयन।

## मुख्य निष्कर्ष

- MCP SDKs भाषा-विशिष्ट उपकरण प्रदान करते हैं जो मजबूत MCP समाधान लागू करने में मदद करते हैं
- डिबगिंग और परीक्षण प्रक्रिया विश्वसनीय MCP अनुप्रयोगों के लिए अत्यंत महत्वपूर्ण है
- पुन: उपयोग योग्य प्रॉम्प्ट टेम्पलेट्स निरंतर AI इंटरैक्शन सक्षम करते हैं
- अच्छी तरह डिज़ाइन किए गए कार्यप्रवाह कई टूल्स का उपयोग करके जटिल कार्यों का समन्वय कर सकते हैं
- MCP समाधान लागू करते समय सुरक्षा, प्रदर्शन, और त्रुटि प्रबंधन का ध्यान रखना आवश्यक है

## अभ्यास

अपने क्षेत्र में किसी वास्तविक समस्या को संबोधित करने वाला एक व्यावहारिक MCP कार्यप्रवाह डिज़ाइन करें:

1. उस समस्या को हल करने के लिए 3-4 उपयोगी टूल्स की पहचान करें
2. एक कार्यप्रवाह आरेख बनाएं जो दिखाए कि ये टूल कैसे इंटरैक्ट करते हैं
3. अपनी पसंदीदा भाषा का उपयोग करके एक टूल का एक बुनियादी संस्करण कार्यान्वित करें
4. एक प्रॉम्प्ट टेम्पलेट बनाएं जो मॉडल को आपके टूल का प्रभावी उपयोग करने में मदद करे

## अतिरिक्त संसाधन


---

अगला: [Advanced Topics](../05-AdvancedTopics/README.md)

**अस्वीकरण**:  
इस दस्तावेज़ का अनुवाद AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।