<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-12T22:12:23+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "hi"
}
-->
# MCP सर्वर तैनात करना

अपने MCP सर्वर को तैनात करने से अन्य लोग आपके स्थानीय वातावरण से परे इसके टूल्स और संसाधनों तक पहुँच सकते हैं। स्केलेबिलिटी, विश्वसनीयता, और प्रबंधन की आसानी की आपकी आवश्यकताओं के आधार पर कई तैनाती रणनीतियाँ हैं। नीचे आपको स्थानीय, कंटेनरों में, और क्लाउड पर MCP सर्वर तैनात करने के लिए मार्गदर्शन मिलेगा।

## अवलोकन

यह पाठ आपके MCP Server ऐप को तैनात करने के तरीके को कवर करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- विभिन्न तैनाती दृष्टिकोणों का मूल्यांकन करना।
- अपने ऐप को तैनात करना।

## स्थानीय विकास और तैनाती

यदि आपका सर्वर उपयोगकर्ताओं की मशीन पर चलाने के लिए है, तो आप निम्नलिखित चरणों का पालन कर सकते हैं:

1. **सर्वर डाउनलोड करें**। यदि आपने सर्वर नहीं लिखा है, तो इसे पहले अपनी मशीन पर डाउनलोड करें।
1. **सर्वर प्रक्रिया शुरू करें**: अपने MCP सर्वर एप्लिकेशन को चलाएं।

SSE के लिए (stdio प्रकार के सर्वर के लिए आवश्यक नहीं)

1. **नेटवर्किंग कॉन्फ़िगर करें**: सुनिश्चित करें कि सर्वर अपेक्षित पोर्ट पर उपलब्ध है।
1. **क्लाइंट्स कनेक्ट करें**: स्थानीय कनेक्शन URL जैसे `http://localhost:3000` का उपयोग करें।

## क्लाउड तैनाती

MCP सर्वर विभिन्न क्लाउड प्लेटफ़ॉर्म पर तैनात किए जा सकते हैं:

- **सर्वरलेस फंक्शंस**: हल्के MCP सर्वर को सर्वरलेस फंक्शंस के रूप में तैनात करें।
- **कंटेनर सेवाएँ**: Azure Container Apps, AWS ECS, या Google Cloud Run जैसी सेवाओं का उपयोग करें।
- **कुबेरनेट्स**: उच्च उपलब्धता के लिए MCP सर्वरों को कुबेरनेट्स क्लस्टर में तैनात और प्रबंधित करें।

### उदाहरण: Azure Container Apps

Azure Container Apps MCP Servers की तैनाती का समर्थन करता है। यह अभी भी विकासाधीन है और वर्तमान में SSE सर्वरों का समर्थन करता है।

इसे करने का तरीका इस प्रकार है:

1. एक रिपॉजिटरी क्लोन करें:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. इसे स्थानीय रूप से चलाकर परीक्षण करें:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. स्थानीय परीक्षण के लिए, *.vscode* डायरेक्टरी में *mcp.json* फ़ाइल बनाएं और निम्नलिखित सामग्री जोड़ें:

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

  SSE सर्वर शुरू होने के बाद, आप JSON फ़ाइल में प्ले आइकन पर क्लिक कर सकते हैं, अब आप GitHub Copilot द्वारा सर्वर के टूल्स को पकड़ते हुए देखेंगे, टूल आइकन देखें।

1. तैनाती के लिए, निम्न कमांड चलाएं:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

बस, इसे स्थानीय रूप से या Azure पर इन चरणों के माध्यम से तैनात करें।

## अतिरिक्त संसाधन

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps लेख](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP रिपो](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## आगे क्या है

- अगला: [Practical Implementation](/04-PracticalImplementation/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।