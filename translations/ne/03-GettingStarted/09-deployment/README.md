<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:28:44+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "ne"
}
-->
# MCP सर्भरहरू डिप्लोय गर्ने

तपाईंको MCP सर्भर डिप्लोय गर्दा अरूले यसको उपकरणहरू र स्रोतहरू तपाईंको स्थानीय वातावरणभन्दा बाहिर पहुँच गर्न सक्छन्। तपाईका आवश्यकता अनुसार स्केलेबिलिटी, विश्वसनीयता, र व्यवस्थापन सजिलो हुने विभिन्न डिप्लोयमेन्ट रणनीतिहरू छन्। तल तपाईलाई स्थानीय, कन्टेनरहरूमा, र क्लाउडमा MCP सर्भरहरू कसरी डिप्लोय गर्ने बारे मार्गदर्शन दिइएको छ।

## अवलोकन

यस पाठले तपाईलाई कसरी MCP Server एप डिप्लोय गर्ने बारे सिकाउँछ।

## सिकाइका उद्देश्यहरू

यस पाठको अन्त्यमा, तपाई सक्षम हुनुहुनेछ:

- विभिन्न डिप्लोयमेन्ट विधिहरूको मूल्याङ्कन गर्न।
- आफ्नो एप डिप्लोय गर्न।

## स्थानीय विकास र डिप्लोयमेन्ट

यदि तपाईको सर्भर प्रयोगकर्ताको मेसिनमा चलाएर प्रयोग गर्न बनाइएको हो भने, निम्न चरणहरू पालना गर्न सक्नुहुन्छ:

1. **सर्भर डाउनलोड गर्नुहोस्**। यदि तपाईले सर्भर लेख्नुभएको छैन भने, पहिले यसलाई आफ्नो मेसिनमा डाउनलोड गर्नुहोस्।
1. **सर्भर प्रक्रिया सुरु गर्नुहोस्**: आफ्नो MCP सर्भर एप्लिकेशन चलाउनुहोस्।

SSE को लागि (stdio प्रकार सर्भरको लागि आवश्यक छैन)

1. **नेटवर्किङ कन्फिगर गर्नुहोस्**: सुनिश्चित गर्नुहोस् सर्भर अपेक्षित पोर्टमा पहुँचयोग्य छ।
1. **क्लाइन्टहरू जडान गर्नुहोस्**: स्थानीय जडान URL हरू प्रयोग गर्नुहोस् जस्तै `http://localhost:3000`।

## क्लाउड डिप्लोयमेन्ट

MCP सर्भरहरू विभिन्न क्लाउड प्लेटफर्महरूमा डिप्लोय गर्न सकिन्छ:

- **सर्भरलेस फंक्शनहरू**: हल्का MCP सर्भरहरू सर्भरलेस फंक्शनको रूपमा डिप्लोय गर्नुहोस्।
- **कन्टेनर सेवाहरू**: Azure Container Apps, AWS ECS, वा Google Cloud Run जस्ता सेवाहरू प्रयोग गर्नुहोस्।
- **कुबेरनेटिस**: उच्च उपलब्धताका लागि MCP सर्भरहरू कुबेरनेटिस क्लस्टरहरूमा डिप्लोय र व्यवस्थापन गर्नुहोस्।

### उदाहरण: Azure Container Apps

Azure Container Apps ले MCP सर्भरहरूको डिप्लोयमेन्ट समर्थन गर्दछ। यो अझै विकासको क्रममा छ र हाल SSE सर्भरहरूलाई समर्थन गर्दछ।

यसरी गर्न सक्नुहुन्छ:

1. एउटा रिपो क्लोन गर्नुहोस्:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. परीक्षण गर्न स्थानीय रूपमा चलाउनुहोस्:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. स्थानीय रूपमा प्रयास गर्न, *.vscode* डाइरेक्टरीमा *mcp.json* फाइल बनाउनुहोस् र निम्न सामग्री थप्नुहोस्:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  SSE सर्भर सुरु भएपछि, JSON फाइलमा प्ले आइकनमा क्लिक गर्न सक्नुहुन्छ, अब GitHub Copilot ले सर्भरका उपकरणहरू पत्ता लगाउनेछ, Tool आइकन हेर्नुहोस्।

1. डिप्लोय गर्न, तलको कमाण्ड चलाउनुहोस्:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

यसो गरेर तपाईले स्थानीय रूपमा वा Azure मा यी चरणहरू मार्फत डिप्लोय गर्न सक्नुहुन्छ।

## थप स्रोतहरू

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps लेख](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP रिपो](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## अब के?

- अर्को: [Practical Implementation](/04-PracticalImplementation/README.md)

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्दछ। मूल दस्तावेज़ यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।