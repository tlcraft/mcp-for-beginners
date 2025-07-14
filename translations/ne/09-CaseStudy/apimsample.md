<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:29:29+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "ne"
}
-->
# केस स्टडी: API Management मा REST API लाई MCP सर्भरको रूपमा एक्स्पोज गर्ने

Azure API Management एउटा सेवा हो जसले तपाईंको API Endpoints माथि गेटवे प्रदान गर्छ। यसको काम Azure API Management ले तपाईंको APIs को अगाडि प्रोक्सीको रूपमा काम गर्छ र आउने अनुरोधहरूलाई के गर्ने निर्णय गर्न सक्छ।

यसलाई प्रयोग गरेर, तपाईंले धेरै सुविधाहरू थप्न सक्नुहुन्छ जस्तै:

- **सुरक्षा**, तपाईं API कुञ्जीहरू, JWT देखि Managed Identity सम्म सबै कुरा प्रयोग गर्न सक्नुहुन्छ।
- **रेट लिमिटिङ**, यो एक उत्कृष्ट सुविधा हो जसले तपाईंलाई निश्चित समय एकाइमा कति कलहरू जान सक्छन् भनेर निर्णय गर्न मद्दत गर्छ। यसले सबै प्रयोगकर्ताहरूलाई राम्रो अनुभव सुनिश्चित गर्छ र तपाईंको सेवा अनुरोधहरूले ओभरलोड नहोस् भनी मद्दत गर्छ।
- **स्केलिङ र लोड ब्यालेन्सिङ**। तपाईंले लोड ब्यालेन्स गर्नका लागि धेरै endpoints सेटअप गर्न सक्नुहुन्छ र कसरी "लोड ब्यालेन्स" गर्ने निर्णय पनि गर्न सक्नुहुन्छ।
- **AI सुविधाहरू जस्तै सेम्यान्टिक क्यासिङ**, टोकन लिमिट र टोकन मोनिटरिङ लगायत। यी सुविधाहरूले प्रतिक्रिया समय सुधार गर्छन् र तपाईंलाई टोकन खर्चमा नियन्त्रण राख्न मद्दत गर्छ। [यहाँ थप पढ्नुहोस्](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities)।

## किन MCP + Azure API Management?

Model Context Protocol छिट्टै एजेन्टिक AI एपहरूका लागि मानक बन्दैछ र उपकरणहरू र डाटालाई एकसमान तरिकाले एक्स्पोज गर्ने तरिका हो। Azure API Management तब स्वाभाविक विकल्प हो जब तपाईंले APIs "प्रबन्धन" गर्नुपर्ने हुन्छ। MCP सर्भरहरू प्रायः अन्य APIs सँग एकीकृत हुन्छन् ताकि उपकरणका लागि अनुरोधहरू समाधान गर्न सकियोस्। त्यसैले Azure API Management र MCP लाई संयोजन गर्नु धेरै अर्थपूर्ण हुन्छ।

## अवलोकन

यस विशेष केसमा हामी API endpoints लाई MCP सर्भरको रूपमा एक्स्पोज गर्न सिक्नेछौं। यसरी गर्दा, हामी यी endpoints लाई एजेन्टिक एपको भाग बनाउन सजिलो हुन्छ र Azure API Management का सुविधाहरू पनि उपयोग गर्न सकिन्छ।

## मुख्य सुविधाहरू

- तपाईंले उपकरणको रूपमा एक्स्पोज गर्न चाहनुभएको endpoint मेथडहरू चयन गर्नुहुन्छ।
- थप सुविधाहरू तपाईंले API को नीति सेक्सनमा के कन्फिगर गर्नुहुन्छ त्यसमा निर्भर हुन्छ। तर यहाँ हामी तपाईंलाई रेट लिमिटिङ कसरी थप्ने देखाउनेछौं।

## पूर्व-चरण: API आयात गर्नुहोस्

यदि तपाईंको Azure API Management मा पहिले नै API छ भने राम्रो, तपाईं यो चरण छोड्न सक्नुहुन्छ। नभए, यो लिंक हेर्नुहोस्, [Azure API Management मा API आयात गर्ने](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api)।

## API लाई MCP सर्भरको रूपमा एक्स्पोज गर्नुहोस्

API endpoints एक्स्पोज गर्न, यी चरणहरू पालना गरौं:

1. Azure Portal मा जानुहोस् र यो ठेगाना खोल्नुहोस् <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   तपाईंको API Management इन्स्टेन्समा जानुहोस्।

1. बाँया मेनुमा, APIs > MCP Servers > + Create new MCP Server चयन गर्नुहोस्।

1. API मा, MCP सर्भरको रूपमा एक्स्पोज गर्न REST API चयन गर्नुहोस्।

1. उपकरणको रूपमा एक्स्पोज गर्न एक वा बढी API Operations चयन गर्नुहोस्। तपाईं सबै अपरेसनहरू वा केही विशेष अपरेसनहरू मात्र चयन गर्न सक्नुहुन्छ।

    ![Select methods to expose](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create** चयन गर्नुहोस्।

1. मेनु विकल्प **APIs** र **MCP Servers** मा जानुहोस्, तपाईंले तलको देख्नुहुनेछ:

    ![See the MCP Server in the main pane](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP सर्भर सिर्जना भइसकेको छ र API अपरेसनहरू उपकरणको रूपमा एक्स्पोज भएका छन्। MCP सर्भर MCP Servers पेनमा सूचीबद्ध छ। URL स्तम्भले MCP सर्भरको endpoint देखाउँछ जुन तपाईं परीक्षण वा क्लाइन्ट एप्लिकेसन भित्र कल गर्न सक्नुहुन्छ।

## वैकल्पिक: नीतिहरू कन्फिगर गर्नुहोस्

Azure API Management मा नीतिहरूको मुख्य अवधारणा छ जहाँ तपाईं आफ्नो endpoints का लागि विभिन्न नियमहरू सेटअप गर्नुहुन्छ जस्तै रेट लिमिटिङ वा सेम्यान्टिक क्यासिङ। यी नीतिहरू XML मा लेखिन्छन्।

यहाँ कसरी तपाईं आफ्नो MCP सर्भरको लागि रेट लिमिट नीति सेटअप गर्न सक्नुहुन्छ:

1. पोर्टलमा, APIs अन्तर्गत, **MCP Servers** चयन गर्नुहोस्।

1. तपाईंले सिर्जना गरेको MCP सर्भर चयन गर्नुहोस्।

1. बाँया मेनुमा, MCP अन्तर्गत, **Policies** चयन गर्नुहोस्।

1. नीति सम्पादकमा, तपाईंले MCP सर्भरका उपकरणहरूमा लागू गर्न चाहनुभएको नीतिहरू थप्नुहोस् वा सम्पादन गर्नुहोस्। नीतिहरू XML ढाँचामा परिभाषित हुन्छन्। उदाहरणका लागि, तपाईंले MCP सर्भरका उपकरणहरूमा कलहरू सीमित गर्न नीति थप्न सक्नुहुन्छ (यस उदाहरणमा, प्रति क्लाइन्ट IP ठेगानामा ३० सेकेन्डमा ५ कलहरू)। यसरी XML ले रेट लिमिट लागू गर्नेछ:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    नीति सम्पादकको एउटा छवि यहाँ छ:

    ![Policy editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## प्रयास गर्नुहोस्

आउनुहोस् हाम्रो MCP सर्भर इच्छित रूपमा काम गरिरहेको छ कि छैन जाँचौं।

यसका लागि, हामी Visual Studio Code र GitHub Copilot को Agent मोड प्रयोग गर्नेछौं। हामी MCP सर्भरलाई *mcp.json* मा थप्नेछौं। यसरी गर्दा, Visual Studio Code एजेन्टिक क्षमताहरू सहित क्लाइन्टको रूपमा काम गर्नेछ र अन्तिम प्रयोगकर्ताहरूले प्रॉम्प्ट टाइप गरेर उक्त सर्भरसँग अन्तरक्रिया गर्न सक्नेछन्।

Visual Studio Code मा MCP सर्भर कसरी थप्ने हेर्नुहोस्:

1. Command Palette बाट MCP: **Add Server command** प्रयोग गर्नुहोस्।

1. सोधिएपछि, सर्भर प्रकार चयन गर्नुहोस्: **HTTP (HTTP वा Server Sent Events)**।

1. API Management मा MCP सर्भरको URL प्रविष्ट गर्नुहोस्। उदाहरण: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE endpoint का लागि) वा **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP endpoint का लागि), ट्रान्सपोर्टहरू बीचको भिन्नता `/sse` वा `/mcp` हो।

1. तपाईंको रोजाइ अनुसार सर्भर ID प्रविष्ट गर्नुहोस्। यो महत्वपूर्ण मान होइन तर यसले तपाईंलाई यो सर्भर इन्स्टेन्स सम्झन मद्दत गर्नेछ।

1. कन्फिगरेसन तपाईंको workspace सेटिङ्स वा user सेटिङ्समा बचत गर्ने चयन गर्नुहोस्।

  - **Workspace settings** - सर्भर कन्फिगरेसन .vscode/mcp.json फाइलमा मात्र बचत हुन्छ जुन हालको workspace मा मात्र उपलब्ध हुन्छ।

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    वा यदि तपाईंले ट्रान्सपोर्टको रूपमा streaming HTTP चयन गर्नुभयो भने यो अलिक फरक हुनेछ:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - सर्भर कन्फिगरेसन तपाईंको ग्लोबल *settings.json* फाइलमा थपिन्छ र सबै workspace हरूमा उपलब्ध हुन्छ। कन्फिगरेसन यस प्रकार देखिन्छ:

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. तपाईंले Azure API Management तर्फ सही प्रमाणिकरण सुनिश्चित गर्न कन्फिगरेसनमा हेडर थप्न आवश्यक छ। यसले **Ocp-Apim-Subscription-Key** नामक हेडर प्रयोग गर्छ।

    - यसलाई सेटिङ्समा कसरी थप्ने:

    ![Adding header for authentication](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), यसले API कुञ्जी मान सोध्न प्रॉम्प्ट देखाउनेछ जुन तपाईं Azure Portal मा आफ्नो Azure API Management इन्स्टेन्सका लागि फेला पार्न सक्नुहुन्छ।

   - *mcp.json* मा थप्न चाहनुहुन्छ भने यसरी थप्न सक्नुहुन्छ:

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

### Agent मोड प्रयोग गर्नुहोस्

अब हामी सेटिङ्स वा *.vscode/mcp.json* मा सबै तयार छौं। प्रयास गरौं।

त्यहाँ यस्तै एउटा Tools आइकन हुनेछ, जहाँ तपाईंको सर्भरबाट एक्स्पोज गरिएका उपकरणहरू सूचीबद्ध हुन्छन्:

![Tools from the server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Tools आइकनमा क्लिक गर्नुहोस् र तपाईंलाई यस्तै उपकरणहरूको सूची देखिनेछ:

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. उपकरण चलाउन च्याटमा प्रॉम्प्ट प्रविष्ट गर्नुहोस्। उदाहरणका लागि, यदि तपाईंले अर्डरको जानकारी प्राप्त गर्ने उपकरण चयन गर्नुभयो भने, एजेन्टलाई अर्डरको बारेमा सोध्न सक्नुहुन्छ। यहाँ एउटा उदाहरण प्रॉम्प्ट छ:

    ```text
    get information from order 2
    ```

    अब तपाईंलाई उपकरण चलाउन जारी राख्न सोध्ने उपकरण आइकन देखिनेछ। जारी राख्न चयन गर्नुहोस्, तपाईंलाई यस्तै आउटपुट देखिनेछ:

    ![Result from prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **तपाईंले माथि जे देख्नुहुन्छ त्यो तपाईंले सेटअप गरेका उपकरणहरूमा निर्भर हुन्छ, तर विचार यो हो कि तपाईंलाई माथि जस्तै पाठ्य प्रतिक्रिया प्राप्त हुन्छ।**


## सन्दर्भहरू

यहाँ तपाईं कसरी थप सिक्न सक्नुहुन्छ:

- [Azure API Management र MCP मा ट्युटोरियल](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python नमूना: Azure API Management प्रयोग गरेर सुरक्षित रिमोट MCP सर्भरहरू (प्रयोगात्मक)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP क्लाइन्ट प्राधिकरण प्रयोगशाला](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [VS Code को लागि Azure API Management एक्सटेन्सन प्रयोग गरी API आयात र प्रबन्धन](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Azure API Center मा रिमोट MCP सर्भर दर्ता र खोज](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Azure API Management सँग धेरै AI क्षमताहरू देखाउने उत्कृष्ट रिपोजिटरी
- [AI Gateway कार्यशालाहरू](https://azure-samples.github.io/AI-Gateway/) Azure Portal प्रयोग गरेर कार्यशालाहरू, जुन AI क्षमताहरू मूल्याङ्कन गर्न सुरु गर्ने राम्रो तरिका हो।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।