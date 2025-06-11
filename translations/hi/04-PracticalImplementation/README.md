<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:06:25+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hi"
}
-->
# Practical Implementation

प्रैक्टिकल इम्प्लीमेंटेशन वह जगह है जहां Model Context Protocol (MCP) की ताकत वास्तविक रूप में सामने आती है। MCP के सिद्धांत और आर्किटेक्चर को समझना ज़रूरी है, लेकिन असली मूल्य तब आता है जब आप इन अवधारणाओं को लागू करके ऐसे समाधान बनाते हैं, टेस्ट करते हैं और डिप्लॉय करते हैं जो वास्तविक दुनिया की समस्याओं को हल करते हैं। यह अध्याय वैचारिक ज्ञान और व्यावहारिक विकास के बीच की खाई को पाटता है, और MCP-आधारित एप्लिकेशन को जीवन में लाने की प्रक्रिया में आपका मार्गदर्शन करता है।

चाहे आप इंटेलिजेंट असिस्टेंट विकसित कर रहे हों, बिजनेस वर्कफ़्लो में AI को इंटीग्रेट कर रहे हों, या डेटा प्रोसेसिंग के लिए कस्टम टूल्स बना रहे हों, MCP एक लचीला आधार प्रदान करता है। इसकी भाषा-स्वतंत्र डिज़ाइन और लोकप्रिय प्रोग्रामिंग भाषाओं के लिए आधिकारिक SDK इसे डेवलपर्स की एक विस्तृत श्रेणी के लिए सुलभ बनाते हैं। इन SDK का उपयोग करके, आप जल्दी से प्रोटोटाइप बना सकते हैं, पुनरावृत्ति कर सकते हैं, और अपने समाधान को विभिन्न प्लेटफ़ॉर्म और वातावरणों में स्केल कर सकते हैं।

आगे के सेक्शन्स में, आपको प्रैक्टिकल उदाहरण, सैंपल कोड, और डिप्लॉयमेंट स्ट्रेटेजीज़ मिलेंगी जो दिखाती हैं कि C#, Java, TypeScript, JavaScript, और Python में MCP को कैसे इम्प्लीमेंट किया जाता है। आप सीखेंगे कि MCP सर्वर को कैसे डिबग और टेस्ट करें, APIs को मैनेज करें, और Azure का उपयोग करके क्लाउड में समाधान को डिप्लॉय करें। ये हैंड्स-ऑन संसाधन आपकी सीखने की गति को तेज करने और भरोसेमंद, प्रोडक्शन-तैयार MCP एप्लिकेशन बनाने में आपकी मदद करने के लिए डिज़ाइन किए गए हैं।

## Overview

यह पाठ MCP इम्प्लीमेंटेशन के प्रैक्टिकल पहलुओं पर केंद्रित है, जो कई प्रोग्रामिंग भाषाओं में लागू होता है। हम देखेंगे कि कैसे MCP SDKs का उपयोग करके C#, Java, TypeScript, JavaScript, और Python में मजबूत एप्लिकेशन बनाए जाएं, MCP सर्वरों को डिबग और टेस्ट किया जाए, और पुन: उपयोग योग्य संसाधन, प्रॉम्प्ट्स, और टूल्स बनाए जाएं।

## Learning Objectives

इस पाठ के अंत तक, आप सक्षम होंगे:
- विभिन्न प्रोग्रामिंग भाषाओं में आधिकारिक SDKs का उपयोग करके MCP समाधान लागू करना
- MCP सर्वरों को व्यवस्थित रूप से डिबग और टेस्ट करना
- सर्वर फीचर्स (Resources, Prompts, और Tools) बनाना और उपयोग करना
- जटिल कार्यों के लिए प्रभावी MCP वर्कफ़्लो डिज़ाइन करना
- प्रदर्शन और विश्वसनीयता के लिए MCP इम्प्लीमेंटेशन को ऑप्टिमाइज़ करना

## Official SDK Resources

Model Context Protocol कई भाषाओं के लिए आधिकारिक SDK प्रदान करता है:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

यह सेक्शन MCP को कई प्रोग्रामिंग भाषाओं में इम्प्लीमेंट करने के प्रैक्टिकल उदाहरण देता है। आप `samples` डायरेक्टरी में भाषा के अनुसार व्यवस्थित सैंपल कोड पा सकते हैं।

### Available Samples

रिपॉजिटरी में निम्न भाषाओं में सैंपल इम्प्लीमेंटेशन शामिल हैं:

- C#
- Java
- TypeScript
- JavaScript
- Python

प्रत्येक सैंपल उस विशिष्ट भाषा और इकोसिस्टम के लिए MCP की प्रमुख अवधारणाओं और इम्प्लीमेंटेशन पैटर्न को प्रदर्शित करता है।

## Core Server Features

MCP सर्वर इन फीचर्स के किसी भी संयोजन को लागू कर सकते हैं:

### Resources
Resources उपयोगकर्ता या AI मॉडल के लिए संदर्भ और डेटा प्रदान करते हैं:
- दस्तावेज़ रिपॉजिटरी
- ज्ञान आधार
- संरचित डेटा स्रोत
- फ़ाइल सिस्टम

### Prompts
Prompts उपयोगकर्ताओं के लिए टेम्प्लेटेड संदेश और वर्कफ़्लो होते हैं:
- पूर्व-निर्धारित संवाद टेम्प्लेट
- मार्गदर्शित इंटरैक्शन पैटर्न
- विशेषीकृत संवाद संरचनाएं

### Tools
Tools AI मॉडल द्वारा निष्पादित किए जाने वाले फ़ंक्शन होते हैं:
- डेटा प्रोसेसिंग यूटिलिटीज़
- बाहरी API इंटीग्रेशन
- गणनात्मक क्षमताएं
- खोज कार्यक्षमता

## Sample Implementations: C#

आधिकारिक C# SDK रिपॉजिटरी में MCP के विभिन्न पहलुओं को दिखाने वाले कई सैंपल इम्प्लीमेंटेशन शामिल हैं:

- **Basic MCP Client**: MCP क्लाइंट बनाने और टूल्स कॉल करने का सरल उदाहरण
- **Basic MCP Server**: बेसिक टूल रजिस्ट्रेशन के साथ न्यूनतम सर्वर इम्प्लीमेंटेशन
- **Advanced MCP Server**: टूल रजिस्ट्रेशन, प्रमाणीकरण, और त्रुटि हैंडलिंग के साथ पूर्ण-विशेषताएं वाला सर्वर
- **ASP.NET Integration**: ASP.NET Core के साथ इंटीग्रेशन दिखाने वाले उदाहरण
- **Tool Implementation Patterns**: विभिन्न जटिलता स्तरों के साथ टूल इम्प्लीमेंट करने के पैटर्न

MCP C# SDK अभी प्रीव्यू में है और APIs में बदलाव हो सकते हैं। हम SDK के विकास के साथ इस ब्लॉग को निरंतर अपडेट करते रहेंगे।

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- अपना [पहला MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) बनाना।

पूर्ण C# इम्प्लीमेंटेशन सैंपल्स के लिए, आधिकारिक C# SDK सैंपल रिपॉजिटरी देखें: [official C# SDK samples repository](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample implementation: Java Implementation

Java SDK MCP इम्प्लीमेंटेशन के लिए एंटरप्राइज़-ग्रेड फीचर्स के साथ मजबूत विकल्प प्रदान करता है।

### Key Features

- Spring Framework इंटीग्रेशन
- मजबूत टाइप सुरक्षा
- रिएक्टिव प्रोग्रामिंग सपोर्ट
- व्यापक त्रुटि हैंडलिंग

पूर्ण Java इम्प्लीमेंटेशन सैंपल के लिए, samples डायरेक्टरी में [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) देखें।

## Sample implementation: JavaScript Implementation

JavaScript SDK MCP इम्प्लीमेंटेशन के लिए हल्का और लचीला दृष्टिकोण प्रदान करता है।

### Key Features

- Node.js और ब्राउज़र सपोर्ट
- प्रॉमिस-आधारित API
- Express और अन्य फ्रेमवर्क के साथ आसान इंटीग्रेशन
- स्ट्रीमिंग के लिए WebSocket सपोर्ट

पूर्ण JavaScript इम्प्लीमेंटेशन सैंपल के लिए, samples डायरेक्टरी में [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) देखें।

## Sample implementation: Python Implementation

Python SDK MCP इम्प्लीमेंटेशन के लिए एक Pythonic दृष्टिकोण प्रदान करता है, जिसमें उत्कृष्ट ML फ्रेमवर्क इंटीग्रेशन शामिल हैं।

### Key Features

- asyncio के साथ Async/await सपोर्ट
- Flask और FastAPI इंटीग्रेशन
- सरल टूल रजिस्ट्रेशन
- लोकप्रिय ML लाइब्रेरीज के साथ नेटिव इंटीग्रेशन

पूर्ण Python इम्प्लीमेंटेशन सैंपल के लिए, samples डायरेक्टरी में [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) देखें।

## API management 

Azure API Management MCP सर्वरों की सुरक्षा का एक बेहतरीन समाधान है। विचार यह है कि आप अपने MCP सर्वर के सामने Azure API Management इंस्टेंस रखें और यह उन फीचर्स को संभाले जो आप चाहते हैं, जैसे:

- रेट लिमिटिंग
- टोकन प्रबंधन
- मॉनिटरिंग
- लोड बैलेंसिंग
- सुरक्षा

### Azure Sample

यहाँ एक Azure Sample है जो बिल्कुल यही करता है, यानी [MCP Server बनाना और Azure API Management के साथ इसे सुरक्षित करना](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)।

नीचे दी गई छवि में देखें कि ऑथराइजेशन फ्लो कैसे होता है:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

इस छवि में निम्नलिखित होता है:

- Microsoft Entra का उपयोग करके प्रमाणीकरण/अधिकार प्राप्ति होती है।
- Azure API Management एक गेटवे के रूप में कार्य करता है और ट्रैफिक को निर्देशित और प्रबंधित करने के लिए नीतियों का उपयोग करता है।
- Azure Monitor सभी अनुरोधों को लॉग करता है ताकि आगे विश्लेषण किया जा सके।

#### Authorization flow

आइए अधिक विस्तार से ऑथराइजेशन फ्लो देखें:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

[MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) के बारे में अधिक जानें।

## Deploy Remote MCP Server to Azure

आइए देखें कि क्या हम पहले बताए गए सैंपल को डिप्लॉय कर सकते हैं:

1. रिपॉजिटरी क्लोन करें

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` रजिस्टर करें:

    ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `  
    या  
    Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `  
    कुछ समय बाद जांचें कि रजिस्ट्रेशन पूरा हुआ या नहीं।

3. इस [azd](https://aka.ms/azd) कमांड को चलाएं ताकि API Management सेवा, फंक्शन ऐप (कोड के साथ), और अन्य आवश्यक Azure संसाधन प्रोविजन हो जाएं:

    ```shell
    azd up
    ```

    यह कमांड Azure पर सभी क्लाउड संसाधनों को डिप्लॉय कर देगी।

### Testing your server with MCP Inspector

1. एक **नई टर्मिनल विंडो** में MCP Inspector इंस्टॉल करें और चलाएं:

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    आपको एक ऐसा इंटरफेस दिखेगा:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hi.png) 

2. CTRL क्लिक करके MCP Inspector वेब ऐप को उस URL से खोलें जो ऐप दिखाता है (जैसे http://127.0.0.1:6274/#resources)
3. ट्रांसपोर्ट टाइप को `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` पर सेट करें और **Connect** करें:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**। किसी टूल पर क्लिक करें और **Run Tool** करें।

यदि सभी चरण सफल रहे, तो आप अब MCP सर्वर से कनेक्टेड हैं और एक टूल कॉल कर पाए हैं।

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): यह रिपॉजिटरी सेट Azure Functions के साथ Python, C# .NET या Node/TypeScript का उपयोग करके कस्टम रिमोट MCP (Model Context Protocol) सर्वर बनाने और डिप्लॉय करने के लिए क्विकस्टार्ट टेम्प्लेट प्रदान करता है।

यह सैंपल एक पूर्ण समाधान देता है जो डेवलपर्स को सक्षम बनाता है:

- लोकल मशीन पर MCP सर्वर बनाएं और चलाएं: विकास और डिबगिंग करें
- Azure पर डिप्लॉय करें: सरल `azd up` कमांड से क्लाउड में आसानी से डिप्लॉय करें
- क्लाइंट्स से कनेक्ट करें: विभिन्न क्लाइंट्स से MCP सर्वर से जुड़ें, जिसमें VS Code के Copilot एजेंट मोड और MCP Inspector टूल शामिल हैं

### Key Features:

- डिज़ाइन द्वारा सुरक्षा: MCP सर्वर कुंजी और HTTPS का उपयोग करके सुरक्षित होता है
- प्रमाणीकरण विकल्प: बिल्ट-इन ऑथ और/या API Management के साथ OAuth सपोर्ट
- नेटवर्क आइसोलेशन: Azure Virtual Networks (VNET) के माध्यम से नेटवर्क अलगाव की अनुमति
- सर्वरलेस आर्किटेक्चर: स्केलेबल, इवेंट-ड्रिवन निष्पादन के लिए Azure Functions का उपयोग
- लोकल विकास: व्यापक लोकल विकास और डिबगिंग सपोर्ट
- सरल डिप्लॉयमेंट: Azure पर त्वरित और सहज डिप्लॉयमेंट प्रक्रिया

रिपॉजिटरी में सभी आवश्यक कॉन्फ़िगरेशन फाइलें, सोर्स कोड, और इन्फ्रास्ट्रक्चर परिभाषाएं शामिल हैं ताकि आप जल्दी से प्रोडक्शन-तैयार MCP सर्वर इम्प्लीमेंटेशन शुरू कर सकें।

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python के साथ Azure Functions का उपयोग करके MCP का सैंपल इम्प्लीमेंटेशन

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET के साथ Azure Functions का उपयोग करके MCP का सैंपल इम्प्लीमेंटेशन

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript के साथ Azure Functions का उपयोग करके MCP का सैंपल इम्प्लीमेंटेशन।

## Key Takeaways

- MCP SDKs भाषा-विशिष्ट टूल्स प्रदान करते हैं जो मजबूत MCP समाधान बनाने में मदद करते हैं
- डिबगिंग और टेस्टिंग प्रक्रिया विश्वसनीय MCP एप्लिकेशन के लिए महत्वपूर्ण है
- पुन: उपयोग योग्य प्रॉम्प्ट टेम्प्लेट AI इंटरैक्शन को सुसंगत बनाते हैं
- अच्छी तरह डिज़ाइन किए गए वर्कफ़्लो कई टूल्स का उपयोग करके जटिल कार्यों का संचालन कर सकते हैं
- MCP समाधान लागू करते समय सुरक्षा, प्रदर्शन, और त्रुटि हैंडलिंग का ध्यान रखना जरूरी है

## Exercise

अपने डोमेन की एक वास्तविक समस्या को हल करने वाला एक प्रैक्टिकल MCP वर्कफ़्लो डिज़ाइन करें:

1. उस समस्या को हल करने के लिए 3-4 उपयोगी टूल्स की पहचान करें
2. एक वर्कफ़्लो डायग्राम बनाएं जो दिखाए कि ये टूल्स कैसे इंटरैक्ट करते हैं
3. अपनी पसंदीदा भाषा में एक टूल का बेसिक वर्जन इम्प्लीमेंट करें
4. एक प्रॉम्प्ट टेम्प्लेट बनाएं जो मॉडल को आपके टूल का प्रभावी उपयोग करने में मदद करे

## Additional Resources


---

Next: [Advanced Topics](../05-AdvancedTopics/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। हम सटीकता के लिए प्रयासरत हैं, लेकिन कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।