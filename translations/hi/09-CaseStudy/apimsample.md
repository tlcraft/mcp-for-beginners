<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:28:23+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "hi"
}
-->
# केस स्टडी: API Management में REST API को MCP सर्वर के रूप में एक्सपोज़ करना

Azure API Management एक सेवा है जो आपके API Endpoints के ऊपर एक गेटवे प्रदान करती है। इसका काम इस तरह होता है कि Azure API Management आपके APIs के सामने एक प्रॉक्सी की तरह काम करता है और आने वाले अनुरोधों के साथ क्या करना है, यह तय कर सकता है।

इसे इस्तेमाल करके, आप कई फीचर्स जोड़ सकते हैं जैसे:

- **सुरक्षा**, आप API keys, JWT से लेकर managed identity तक सब कुछ उपयोग कर सकते हैं।
- **रेट लिमिटिंग**, एक शानदार फीचर है जिससे आप तय कर सकते हैं कि एक निश्चित समय में कितनी कॉल्स गुजर सकती हैं। इससे यह सुनिश्चित होता है कि सभी उपयोगकर्ताओं को अच्छा अनुभव मिले और आपकी सेवा अनुरोधों से ओवरलोड न हो।
- **स्केलिंग और लोड बैलेंसिंग**। आप कई endpoints सेट कर सकते हैं ताकि लोड को बैलेंस किया जा सके और यह भी तय कर सकते हैं कि "लोड बैलेंस" कैसे करना है।
- **AI फीचर्स जैसे सेमांटिक कैशिंग**, टोकन लिमिट और टोकन मॉनिटरिंग आदि। ये बेहतरीन फीचर्स हैं जो प्रतिक्रिया समय को बेहतर बनाते हैं और साथ ही आपके टोकन खर्च पर नियंत्रण रखने में मदद करते हैं। [यहाँ और पढ़ें](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities)।

## MCP + Azure API Management क्यों?

Model Context Protocol तेजी से एजेंटिक AI ऐप्स के लिए एक मानक बनता जा रहा है और टूल्स व डेटा को एक सुसंगत तरीके से एक्सपोज़ करने का तरीका है। जब आपको APIs को "मैनेज" करना होता है तो Azure API Management एक स्वाभाविक विकल्प होता है। MCP सर्वर अक्सर अन्य APIs के साथ इंटीग्रेट होते हैं ताकि किसी टूल के लिए अनुरोध हल किए जा सकें। इसलिए Azure API Management और MCP को मिलाना बहुत समझदारी भरा है।

## अवलोकन

इस खास उपयोग मामले में हम सीखेंगे कि API endpoints को MCP सर्वर के रूप में कैसे एक्सपोज़ किया जाए। ऐसा करने से, हम आसानी से इन endpoints को एजेंटिक ऐप का हिस्सा बना सकते हैं और साथ ही Azure API Management के फीचर्स का लाभ उठा सकते हैं।

## मुख्य फीचर्स

- आप उन endpoint मेथड्स का चयन करते हैं जिन्हें आप टूल्स के रूप में एक्सपोज़ करना चाहते हैं।
- अतिरिक्त फीचर्स इस बात पर निर्भर करते हैं कि आप अपनी API के लिए पॉलिसी सेक्शन में क्या कॉन्फ़िगर करते हैं। लेकिन यहाँ हम आपको दिखाएंगे कि आप रेट लिमिटिंग कैसे जोड़ सकते हैं।

## प्री-स्टेप: API इम्पोर्ट करें

अगर आपके पास पहले से Azure API Management में API है तो यह कदम छोड़ सकते हैं। यदि नहीं, तो इस लिंक को देखें, [Azure API Management में API इम्पोर्ट करना](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api)।

## API को MCP सर्वर के रूप में एक्सपोज़ करें

API endpoints को एक्सपोज़ करने के लिए, निम्नलिखित कदम उठाएं:

1. Azure पोर्टल पर जाएं और इस पते पर नेविगेट करें <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
अपने API Management इंस्टेंस पर जाएं।

1. बाएं मेनू में, APIs > MCP Servers > + Create new MCP Server चुनें।

1. API में, एक REST API चुनें जिसे MCP सर्वर के रूप में एक्सपोज़ करना है।

1. एक या अधिक API Operations चुनें जिन्हें टूल्स के रूप में एक्सपोज़ करना है। आप सभी ऑपरेशन्स या केवल कुछ विशेष ऑपरेशन्स चुन सकते हैं।

    ![Select methods to expose](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create** चुनें।

1. मेनू विकल्प **APIs** और **MCP Servers** पर जाएं, आपको निम्न दिखाई देगा:

    ![See the MCP Server in the main pane](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP सर्वर बन चुका है और API ऑपरेशन्स टूल्स के रूप में एक्सपोज़ हो गए हैं। MCP सर्वर MCP Servers पेन में सूचीबद्ध है। URL कॉलम में MCP सर्वर का endpoint दिखता है जिसे आप परीक्षण या क्लाइंट एप्लिकेशन में कॉल कर सकते हैं।

## वैकल्पिक: पॉलिसी कॉन्फ़िगर करें

Azure API Management में पॉलिसी का मूल विचार होता है जहाँ आप अपने endpoints के लिए विभिन्न नियम सेट करते हैं, जैसे रेट लिमिटिंग या सेमांटिक कैशिंग। ये पॉलिसी XML में लिखी जाती हैं।

यहाँ बताया गया है कि आप MCP सर्वर के लिए रेट लिमिटिंग पॉलिसी कैसे सेट कर सकते हैं:

1. पोर्टल में, APIs के अंतर्गत **MCP Servers** चुनें।

1. उस MCP सर्वर को चुनें जिसे आपने बनाया है।

1. बाएं मेनू में, MCP के अंतर्गत **Policies** चुनें।

1. पॉलिसी एडिटर में, उन पॉलिसी को जोड़ें या संपादित करें जिन्हें आप MCP सर्वर के टूल्स पर लागू करना चाहते हैं। पॉलिसी XML फॉर्मेट में होती हैं। उदाहरण के लिए, आप एक पॉलिसी जोड़ सकते हैं जो MCP सर्वर के टूल्स के लिए कॉल्स को सीमित करे (इस उदाहरण में, प्रति क्लाइंट IP पते 30 सेकंड में 5 कॉल्स)। यह XML रेट लिमिटिंग करेगा:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    पॉलिसी एडिटर की एक छवि यहाँ है:

    ![Policy editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## इसे आज़माएं

आइए सुनिश्चित करें कि हमारा MCP सर्वर सही तरीके से काम कर रहा है।

इसके लिए, हम Visual Studio Code और GitHub Copilot के Agent मोड का उपयोग करेंगे। हम MCP सर्वर को *mcp.json* में जोड़ेंगे। ऐसा करने से, Visual Studio Code एजेंटिक क्षमताओं वाला क्लाइंट के रूप में काम करेगा और अंतिम उपयोगकर्ता एक प्रॉम्प्ट टाइप करके सर्वर के साथ इंटरैक्ट कर सकेंगे।

Visual Studio Code में MCP सर्वर जोड़ने का तरीका:

1. कमांड पैलेट से MCP: **Add Server कमांड** का उपयोग करें।

1. जब पूछा जाए, तो सर्वर प्रकार चुनें: **HTTP (HTTP या Server Sent Events)**।

1. API Management में MCP सर्वर का URL दर्ज करें। उदाहरण: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE endpoint के लिए) या **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP endpoint के लिए), ध्यान दें कि ट्रांसपोर्ट में अंतर `/sse` या `/mcp` है।

1. अपनी पसंद का एक सर्वर ID दर्ज करें। यह कोई महत्वपूर्ण मान नहीं है लेकिन इससे आपको यह याद रखने में मदद मिलेगी कि यह सर्वर इंस्टेंस क्या है।

1. चुनें कि कॉन्फ़िगरेशन को वर्कस्पेस सेटिंग्स या यूजर सेटिंग्स में सेव करना है।

  - **वर्कस्पेस सेटिंग्स** - सर्वर कॉन्फ़िगरेशन केवल वर्तमान वर्कस्पेस में उपलब्ध .vscode/mcp.json फ़ाइल में सेव होती है।

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    या यदि आप स्ट्रीमिंग HTTP ट्रांसपोर्ट चुनते हैं तो यह थोड़ा अलग होगा:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **यूजर सेटिंग्स** - सर्वर कॉन्फ़िगरेशन आपके ग्लोबल *settings.json* फ़ाइल में जोड़ा जाता है और सभी वर्कस्पेस में उपलब्ध होता है। कॉन्फ़िगरेशन इस तरह दिखता है:

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. आपको एक हेडर भी जोड़ना होगा ताकि यह Azure API Management के प्रति सही तरीके से प्रमाणित हो सके। यह एक हेडर का उपयोग करता है जिसका नाम है **Ocp-Apim-Subscription-Key**।

    - इसे सेटिंग्स में जोड़ने का तरीका:

    ![Adding header for authentication](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), इससे एक प्रॉम्प्ट दिखेगा जो आपसे API key का मान पूछेगा, जिसे आप Azure पोर्टल में अपने Azure API Management इंस्टेंस के लिए पा सकते हैं।

   - इसे *mcp.json* में जोड़ने के लिए, आप इसे इस तरह जोड़ सकते हैं:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Agent मोड का उपयोग करें

अब हम सेटिंग्स या *.vscode/mcp.json* में तैयार हैं। चलिए इसे आज़माते हैं।

ऐसा एक Tools आइकन होना चाहिए, जहाँ आपके सर्वर से एक्सपोज़ किए गए टूल्स सूचीबद्ध होंगे:

![Tools from the server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Tools आइकन पर क्लिक करें और आपको टूल्स की एक सूची दिखेगी:

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. टूल को कॉल करने के लिए चैट में एक प्रॉम्प्ट दर्ज करें। उदाहरण के लिए, यदि आपने किसी ऑर्डर की जानकारी प्राप्त करने के लिए टूल चुना है, तो आप एजेंट से ऑर्डर के बारे में पूछ सकते हैं। यहाँ एक उदाहरण प्रॉम्प्ट है:

    ```text
    get information from order 2
    ```

    अब आपको एक टूल्स आइकन दिखाई देगा जो टूल कॉल करने के लिए कहेगा। जारी रखने के लिए चुनें, आपको अब इस तरह का आउटपुट दिखाई देगा:

    ![Result from prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **ऊपर जो आप देख रहे हैं वह इस बात पर निर्भर करता है कि आपने कौन से टूल्स सेटअप किए हैं, लेकिन विचार यह है कि आपको ऊपर जैसा टेक्स्टुअल जवाब मिलता है।**


## संदर्भ

यहाँ आप और अधिक सीख सकते हैं:

- [Azure API Management और MCP पर ट्यूटोरियल](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python सैंपल: Azure API Management का उपयोग करके सुरक्षित रिमोट MCP सर्वर (प्रयोगात्मक)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP क्लाइंट ऑथराइजेशन लैब](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [VS Code के लिए Azure API Management एक्सटेंशन का उपयोग करके APIs इम्पोर्ट और मैनेज करें](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Azure API Center में रिमोट MCP सर्वर रजिस्टर और डिस्कवर करें](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) एक बेहतरीन रिपॉजिटरी जो Azure API Management के साथ कई AI क्षमताएं दिखाती है
- [AI Gateway वर्कशॉप्स](https://azure-samples.github.io/AI-Gateway/) Azure पोर्टल का उपयोग करते हुए वर्कशॉप्स, जो AI क्षमताओं का मूल्यांकन शुरू करने का एक शानदार तरीका है।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।