<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:29:04+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "mr"
}
-->
# केस स्टडी: API Management मध्ये REST API ला MCP सर्व्हर म्हणून उघडणे

Azure API Management ही एक सेवा आहे जी तुमच्या API Endpoints च्या वर एक Gateway प्रदान करते. हे कसे काम करते म्हणजे Azure API Management तुमच्या APIs च्या समोर एक प्रॉक्सी म्हणून काम करते आणि येणाऱ्या विनंत्यांसोबत काय करायचे ते ठरवू शकते.

याचा वापर करून, तुम्ही अनेक वैशिष्ट्ये जोडू शकता जसे की:

- **सुरक्षा**, तुम्ही API कीज, JWT पासून ते managed identity पर्यंत सर्व काही वापरू शकता.
- **रेट लिमिटिंग**, एक छान वैशिष्ट्य म्हणजे ठराविक वेळेत किती कॉल्स होऊ शकतात हे ठरवता येणे. यामुळे सर्व वापरकर्त्यांना चांगला अनुभव मिळतो आणि तुमची सेवा विनंत्यांनी ओव्हरलोड होत नाही याची खात्री होते.
- **स्केलिंग आणि लोड बॅलन्सिंग**. तुम्ही अनेक endpoints सेट करू शकता ज्यामुळे लोड संतुलित होतो आणि तुम्ही "लोड बॅलन्स" कसे करायचे ते ठरवू शकता.
- **AI वैशिष्ट्ये जसे की semantic caching**, टोकन लिमिट आणि टोकन मॉनिटरिंग वगैरे. ही छान वैशिष्ट्ये आहेत जी प्रतिसादक्षमता सुधारतात तसेच तुमच्या टोकन खर्चावर लक्ष ठेवण्यास मदत करतात. [इथे अधिक वाचा](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## का MCP + Azure API Management?

Model Context Protocol (MCP) एजंटिक AI अ‍ॅप्ससाठी लवकरच एक मानक बनत आहे आणि साधने व डेटा एकसंध पद्धतीने उघडण्याचा मार्ग आहे. जेव्हा तुम्हाला APIs "मॅनेज" करायच्या असतात तेव्हा Azure API Management हा नैसर्गिक पर्याय आहे. MCP Servers अनेकदा इतर APIs सोबत एकत्र काम करतात जेणेकरून एखाद्या साधनासाठी विनंत्या सोडवता येतात. त्यामुळे Azure API Management आणि MCP यांचा एकत्र वापर करणे खूपच अर्थपूर्ण ठरतो.

## आढावा

या विशिष्ट वापर प्रकरणात आपण API endpoints ला MCP Server म्हणून कसे उघडायचे ते शिकू. यामुळे आपण या endpoints ला एजंटिक अ‍ॅपचा भाग बनवू शकतो आणि त्याचबरोबर Azure API Management चे वैशिष्ट्येही वापरू शकतो.

## मुख्य वैशिष्ट्ये

- तुम्ही कोणते endpoint मेथड्स साधन म्हणून उघडायचे आहेत ते निवडता.
- तुम्हाला मिळणारी अतिरिक्त वैशिष्ट्ये तुमच्या API साठी पॉलिसी सेक्शनमध्ये काय कॉन्फिगर केले आहे त्यावर अवलंबून असतात. पण येथे आपण रेट लिमिटिंग कसे जोडायचे ते दाखवणार आहोत.

## पूर्व-चरण: API आयात करा

जर तुमच्याकडे आधीच Azure API Management मध्ये API असेल तर छान, तुम्ही हा टप्पा वगळू शकता. नाहीतर, हा दुवा पहा, [Azure API Management मध्ये API आयात करणे](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## API ला MCP Server म्हणून उघडा

API endpoints उघडण्यासाठी, खालील टप्पे फॉलो करा:

1. Azure Portal वर जा आणि खालील पत्ता उघडा <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
तुमच्या API Management इंस्टन्सकडे जा.

1. डाव्या मेनूमध्ये, APIs > MCP Servers > + Create new MCP Server निवडा.

1. API मध्ये, MCP सर्व्हर म्हणून उघडण्यासाठी REST API निवडा.

1. एक किंवा अधिक API ऑपरेशन्स साधन म्हणून उघडण्यासाठी निवडा. तुम्ही सर्व ऑपरेशन्स किंवा फक्त विशिष्ट ऑपरेशन्स निवडू शकता.

    ![उघडण्यासाठी मेथड्स निवडा](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create** निवडा.

1. मेनू पर्याय **APIs** आणि **MCP Servers** कडे जा, तुम्हाला खालील दिसेल:

    ![मुख्य पॅनमध्ये MCP Server पहा](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP सर्व्हर तयार झाला आहे आणि API ऑपरेशन्स साधन म्हणून उघडले गेले आहेत. MCP सर्व्हर MCP Servers पॅनमध्ये सूचीबद्ध आहे. URL कॉलममध्ये MCP सर्व्हरचा endpoint दिसतो ज्याला तुम्ही टेस्टिंगसाठी किंवा क्लायंट अ‍ॅप्लिकेशनमध्ये कॉल करू शकता.

## ऐच्छिक: पॉलिसी कॉन्फिगर करा

Azure API Management मध्ये पॉलिसी ही मुख्य संकल्पना आहे जिथे तुम्ही तुमच्या endpoints साठी विविध नियम सेट करता जसे की रेट लिमिटिंग किंवा semantic caching. या पॉलिसी XML मध्ये लिहिल्या जातात.

MCP Server साठी रेट लिमिटिंग कशी सेट करायची ते खालीलप्रमाणे:

1. पोर्टलमध्ये, APIs अंतर्गत, **MCP Servers** निवडा.

1. तुम्ही तयार केलेला MCP सर्व्हर निवडा.

1. डाव्या मेनूमध्ये, MCP अंतर्गत, **Policies** निवडा.

1. पॉलिसी एडिटरमध्ये, तुम्हाला लागू करायच्या पॉलिसी जोडा किंवा संपादित करा. पॉलिसी XML फॉरमॅटमध्ये असतात. उदाहरणार्थ, तुम्ही MCP सर्व्हरच्या साधनांसाठी कॉल्स मर्यादित करण्यासाठी पॉलिसी जोडू शकता (या उदाहरणात, प्रति क्लायंट IP पत्ता 30 सेकंदात 5 कॉल्स). खाली XML आहे जी रेट लिमिटिंग करेल:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    पॉलिसी एडिटरची ही प्रतिमा पहा:

    ![पॉलिसी एडिटर](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)

## वापरून पहा

आपला MCP Server अपेक्षेनुसार काम करत आहे याची खात्री करूया.

यासाठी, आपण Visual Studio Code आणि GitHub Copilot चा Agent मोड वापरणार आहोत. आपण MCP सर्व्हर *mcp.json* मध्ये जोडणार आहोत. यामुळे Visual Studio Code एजंटिक क्षमता असलेला क्लायंट म्हणून काम करेल आणि अंतिम वापरकर्ते प्रॉम्प्ट टाइप करून त्या सर्व्हरशी संवाद साधू शकतील.

Visual Studio Code मध्ये MCP सर्व्हर कसा जोडायचा ते पाहूया:

1. Command Palette मधून MCP: **Add Server command** वापरा.

1. विचारल्यावर, सर्व्हर प्रकार निवडा: **HTTP (HTTP किंवा Server Sent Events)**.

1. API Management मधील MCP सर्व्हरचा URL टाका. उदाहरण: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE endpoint साठी) किंवा **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP endpoint साठी), यात ट्रान्सपोर्टमधील फरक `/sse` किंवा `/mcp` आहे.

1. तुमच्या पसंतीचा सर्व्हर ID टाका. हा महत्त्वाचा नाही पण तुम्हाला हा सर्व्हर ओळखायला मदत करेल.

1. कॉन्फिगरेशन तुमच्या workspace सेटिंग्जमध्ये जतन करायची की user सेटिंग्जमध्ये हे ठरवा.

  - **Workspace settings** - सर्व्हर कॉन्फिगरेशन फक्त चालू workspace मध्ये उपलब्ध असलेल्या .vscode/mcp.json फाईलमध्ये जतन होतो.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    किंवा जर तुम्ही streaming HTTP ट्रान्सपोर्ट निवडला तर थोडा वेगळा असेल:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - सर्व्हर कॉन्फिगरेशन तुमच्या जागतिक *settings.json* फाईलमध्ये जोडले जाते आणि सर्व workspace मध्ये उपलब्ध असते. कॉन्फिगरेशन खालीलप्रमाणे दिसते:

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. तुम्हाला Azure API Management कडे योग्यरित्या प्रमाणीकरणासाठी हेडर देखील जोडावा लागेल. हे हेडर **Ocp-Apim-Subscription-Key** नावाचा आहे.

    - सेटिंग्जमध्ये हे कसे जोडायचे:

    ![प्रमाणीकरणासाठी हेडर जोडणे](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), यामुळे API कीची किंमत विचारणारा प्रॉम्प्ट दिसेल जी तुम्हाला Azure Portal मधून तुमच्या Azure API Management इंस्टन्ससाठी मिळेल.

   - *mcp.json* मध्ये जोडायचे असल्यास, असे करा:

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

### Agent मोड वापरा

आता आपण सेटिंग्जमध्ये किंवा *.vscode/mcp.json* मध्ये सर्व काही सेट केले आहे. वापरून पाहूया.

तुमच्या सर्व्हरमधून उघडलेल्या साधनांची यादी असलेला Tools आयकॉन असावा:

![सर्व्हरमधील साधने](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Tools आयकॉन क्लिक करा, तुम्हाला साधनांची यादी दिसेल:

    ![साधने](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. साधन वापरण्यासाठी चॅटमध्ये प्रॉम्प्ट टाका. उदाहरणार्थ, जर तुम्ही एखादे साधन निवडले असेल जे ऑर्डरची माहिती देते, तर एजंटला ऑर्डरबद्दल विचारू शकता. खाली एक उदाहरण प्रॉम्प्ट आहे:

    ```text
    get information from order 2
    ```

    तुम्हाला आता साधन चालवायचे आहे का हे विचारणारा Tools आयकॉन दिसेल. चालू ठेवण्यासाठी निवडा, तुम्हाला खालीलप्रमाणे आउटपुट दिसेल:

    ![प्रॉम्प्टचा निकाल](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **वरील जे तुम्हाला दिसेल ते तुम्ही सेट केलेल्या साधनांवर अवलंबून आहे, पण कल्पना अशी की तुम्हाला वरीलप्रमाणे मजकूर स्वरूपात प्रतिसाद मिळेल.**

## संदर्भ

अधिक जाणून घेण्यासाठी:

- [Azure API Management आणि MCP वर ट्युटोरियल](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python नमुना: Azure API Management वापरून सुरक्षित रिमोट MCP सर्व्हर (प्रायोगिक)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP क्लायंट ऑथरायझेशन लॅब](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [VS Code साठी Azure API Management एक्सटेंशन वापरून API आयात आणि व्यवस्थापन](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Azure API Center मध्ये रिमोट MCP सर्व्हर नोंदणी आणि शोध](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) - Azure API Management सह अनेक AI क्षमता दाखवणारे उत्कृष्ट रेपो
- [AI Gateway कार्यशाळा](https://azure-samples.github.io/AI-Gateway/) - Azure Portal वापरून कार्यशाळा, AI क्षमता तपासण्याचा उत्तम मार्ग

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.