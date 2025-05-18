<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:50:43+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "hi"
}
-->
# MCP सर्वर तैनात करना

अपने MCP सर्वर को तैनात करने से अन्य लोग आपके स्थानीय वातावरण से परे इसके उपकरणों और संसाधनों तक पहुंच सकते हैं। कई तैनाती रणनीतियाँ हैं जिन्हें आप विचार कर सकते हैं, जो आपकी स्केलेबिलिटी, विश्वसनीयता, और प्रबंधन की आसानी की आवश्यकताओं पर निर्भर करती हैं। नीचे आप MCP सर्वरों को स्थानीय रूप से, कंटेनरों में, और क्लाउड पर तैनात करने के लिए मार्गदर्शन पाएंगे।

## अवलोकन

यह पाठ आपके MCP सर्वर ऐप को तैनात करने के तरीके को कवर करता है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- विभिन्न तैनाती दृष्टिकोणों का मूल्यांकन करना।
- अपने ऐप को तैनात करना।

## स्थानीय विकास और तैनाती

यदि आपका सर्वर उपयोगकर्ता मशीन पर चलाकर उपयोग करने के लिए है, तो आप निम्नलिखित चरणों का पालन कर सकते हैं:

1. **सर्वर डाउनलोड करें**। यदि आपने सर्वर नहीं लिखा है, तो पहले इसे अपनी मशीन पर डाउनलोड करें।
1. **सर्वर प्रक्रिया शुरू करें**: अपने MCP सर्वर एप्लिकेशन को चलाएं

SSE के लिए (stdio प्रकार के सर्वर के लिए आवश्यक नहीं)

1. **नेटवर्किंग कॉन्फ़िगर करें**: सुनिश्चित करें कि सर्वर अपेक्षित पोर्ट पर सुलभ है
1. **क्लाइंट्स को कनेक्ट करें**: स्थानीय कनेक्शन URLs का उपयोग करें जैसे `http://localhost:3000`

## क्लाउड तैनाती

MCP सर्वरों को विभिन्न क्लाउड प्लेटफार्मों पर तैनात किया जा सकता है:

- **सर्वरलेस फंक्शन्स**: हल्के MCP सर्वरों को सर्वरलेस फंक्शन्स के रूप में तैनात करें
- **कंटेनर सेवाएँ**: Azure Container Apps, AWS ECS, या Google Cloud Run जैसी सेवाओं का उपयोग करें
- **कुबेरनेट्स**: उच्च उपलब्धता के लिए कुबेरनेट्स क्लस्टर्स में MCP सर्वरों को तैनात और प्रबंधित करें

### उदाहरण: Azure Container Apps

Azure Container Apps MCP सर्वरों की तैनाती का समर्थन करता है। यह अभी भी काम प्रगति में है और वर्तमान में SSE सर्वरों का समर्थन करता है।

यहां बताया गया है कि आप इसे कैसे कर सकते हैं:

1. एक रिपो क्लोन करें:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. चीजों को परीक्षण करने के लिए इसे स्थानीय रूप से चलाएं:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. इसे स्थानीय रूप से आजमाने के लिए, एक *mcp.json* फ़ाइल *.vscode* डायरेक्टरी में बनाएं और निम्नलिखित सामग्री जोड़ें:

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

  एक बार SSE सर्वर शुरू होने के बाद, आप JSON फ़ाइल में प्ले आइकन पर क्लिक कर सकते हैं, अब आपको GitHub Copilot द्वारा सर्वर पर उपकरण उठाए जाते हुए देखना चाहिए, टूल आइकन देखें।

1. तैनात करने के लिए, निम्नलिखित कमांड चलाएं:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

आपके पास यह है, इसे स्थानीय रूप से तैनात करें, इन चरणों के माध्यम से Azure में तैनात करें।

## अतिरिक्त संसाधन

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps लेख](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP रिपो](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## आगे क्या

- आगे: [व्यावहारिक कार्यान्वयन](/04-PracticalImplementation/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।