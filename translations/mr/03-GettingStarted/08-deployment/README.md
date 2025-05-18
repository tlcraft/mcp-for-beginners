<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:51:10+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "mr"
}
-->
# MCP सर्व्हर तैनात करणे

तुमच्या MCP सर्व्हरचे तैनाती केल्याने इतरांना त्याचे साधने आणि संसाधने तुमच्या स्थानिक वातावरणाच्या पलीकडे प्रवेश करण्यास अनुमती मिळते. स्केलेबिलिटी, विश्वसनीयता आणि व्यवस्थापनाच्या सुलभतेसाठी तुमच्या आवश्यकतांनुसार विचार करण्यासाठी अनेक तैनाती धोरणे आहेत. खाली तुम्हाला MCP सर्व्हर स्थानिक, कंटेनरमध्ये आणि क्लाउडवर तैनात करण्यासाठी मार्गदर्शन मिळेल.

## आढावा

या धड्यात तुमच्या MCP सर्व्हर अॅपची तैनाती कशी करावी हे समाविष्ट आहे.

## शिकण्याची उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- विविध तैनाती पध्दतींचा मूल्यांकन करा.
- तुमचे अॅप तैनात करा.

## स्थानिक विकास आणि तैनाती

जर तुमचा सर्व्हर वापरकर्त्यांच्या मशीनवर चालवण्यासाठी असेल, तर तुम्ही खालील पायऱ्या अनुसरू शकता:

1. **सर्व्हर डाउनलोड करा**. जर तुम्ही सर्व्हर लिहिले नसेल तर सर्वप्रथम ते तुमच्या मशीनवर डाउनलोड करा.
1. **सर्व्हर प्रक्रिया सुरू करा**: तुमचे MCP सर्व्हर अॅप्लिकेशन चालवा

SSE साठी (stdio प्रकारच्या सर्व्हरसाठी आवश्यक नाही)

1. **नेटवर्किंग कॉन्फिगर करा**: सुनिश्चित करा की सर्व्हर अपेक्षित पोर्टवर प्रवेशयोग्य आहे
1. **क्लायंट्स कनेक्ट करा**: स्थानिक कनेक्शन URLs वापरा जसे `http://localhost:3000`

## क्लाउड तैनाती

MCP सर्व्हर विविध क्लाउड प्लॅटफॉर्मवर तैनात केले जाऊ शकतात:

- **सर्व्हरलेस फंक्शन्स**: हलके MCP सर्व्हर सर्व्हरलेस फंक्शन्स म्हणून तैनात करा
- **कंटेनर सेवा**: Azure Container Apps, AWS ECS, किंवा Google Cloud Run सारख्या सेवांचा वापर करा
- **Kubernetes**: उच्च उपलब्धतेसाठी Kubernetes क्लस्टर्समध्ये MCP सर्व्हर तैनात आणि व्यवस्थापित करा

### उदाहरण: Azure Container Apps

Azure Container Apps MCP सर्व्हर्सची तैनातीला समर्थन देतात. हे अजूनही कार्य प्रगतीत आहे आणि सध्या SSE सर्व्हर्सला समर्थन देते.

हे कसे करावे:

1. रिपॉझिटरी क्लोन करा:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. गोष्टी तपासण्यासाठी स्थानिकपणे चालवा:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. स्थानिकपणे प्रयत्न करण्यासाठी, *.vscode* डिरेक्टरीमध्ये *mcp.json* फाइल तयार करा आणि खालील सामग्री जोडा:

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

  SSE सर्व्हर सुरू झाल्यावर, तुम्ही JSON फाइलमध्ये प्ले आयकॉनवर क्लिक करू शकता, आता तुम्हाला GitHub Copilot द्वारे सर्व्हरवरील साधने ओळखली जातील, टूल आयकॉन पहा.

1. तैनात करण्यासाठी, खालील कमांड चालवा:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

तुमच्याकडे ते आहे, स्थानिकपणे तैनात करा, या चरणांद्वारे Azure वर तैनात करा.

## अतिरिक्त संसाधने

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps लेख](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## पुढे काय

- पुढे: [व्यावहारिक अंमलबजावणी](/04-PracticalImplementation/README.md)

**अस्वीकृती**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये त्रुटी किंवा अपूर्णता असू शकते. मूळ भाषेतील दस्तऐवज अधिकृत स्रोत मानला पाहिजे. महत्त्वपूर्ण माहितीसाठी, व्यावसायिक मानव भाषांतराची शिफारस केली जाते. या भाषांतराचा वापर करून उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.