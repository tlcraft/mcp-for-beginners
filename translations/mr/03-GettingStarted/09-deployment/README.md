<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:28:32+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "mr"
}
-->
# MCP सर्व्हर डिप्लॉय करणे

तुमचा MCP सर्व्हर डिप्लॉय केल्याने इतर लोकांना त्याच्या टूल्स आणि रिसोर्सेसना तुमच्या लोकल एन्व्हायर्नमेंटच्या बाहेरून ऍक्सेस करता येते. स्केलेबिलिटी, रिलायबिलिटी, आणि मॅनेजमेंटच्या सोप्या पद्धतीनुसार वेगवेगळ्या डिप्लॉयमेंट स्ट्रॅटेजी आहेत. खाली तुम्हाला MCP सर्व्हर लोकली, कंटेनरमध्ये आणि क्लाऊडवर कसे डिप्लॉय करायचे याबाबत मार्गदर्शन मिळेल.

## आढावा

हा लेसन तुमचा MCP Server ऍप कसा डिप्लॉय करायचा ते शिकवतो.

## शिकण्याचे उद्दिष्टे

या लेसनच्या शेवटी, तुम्ही करू शकाल:

- वेगवेगळ्या डिप्लॉयमेंट पद्धतींचे मूल्यमापन करणे.
- तुमचा ऍप डिप्लॉय करणे.

## लोकल डेव्हलपमेंट आणि डिप्लॉयमेंट

जर तुमचा सर्व्हर युजर्सच्या मशीनवर चालवण्यासाठी असेल, तर खालील स्टेप्स फॉलो करा:

1. **सर्व्हर डाउनलोड करा**. जर तुम्ही सर्व्हर लिहिला नसेल, तर आधी तो तुमच्या मशीनवर डाउनलोड करा.
1. **सर्व्हर प्रोसेस सुरु करा**: तुमचा MCP सर्व्हर ऍप्लिकेशन रन करा.

SSE साठी (stdio प्रकारच्या सर्व्हरसाठी आवश्यक नाही)

1. **नेटवर्किंग कॉन्फिगर करा**: सर्व्हर अपेक्षित पोर्टवर ऍक्सेसिबल आहे याची खात्री करा.
1. **क्लायंट्स कनेक्ट करा**: लोकल कनेक्शन URLs वापरा जसे की `http://localhost:3000`

## क्लाऊड डिप्लॉयमेंट

MCP सर्व्हर विविध क्लाऊड प्लॅटफॉर्मवर डिप्लॉय केले जाऊ शकतात:

- **सर्व्हरलेस फंक्शन्स**: हलक्या MCP सर्व्हरना सर्व्हरलेस फंक्शन्स म्हणून डिप्लॉय करा.
- **कंटेनर सर्व्हिसेस**: Azure Container Apps, AWS ECS, किंवा Google Cloud Run सारख्या सेवांचा वापर करा.
- **कुबेरनेट्स**: उच्च उपलब्धतेसाठी MCP सर्व्हर कुबेरनेट्स क्लस्टर्समध्ये डिप्लॉय आणि मॅनेज करा.

### उदाहरण: Azure Container Apps

Azure Container Apps MCP Servers डिप्लॉयमेंटला सपोर्ट करतात. हे अजून प्रगतीच्या टप्प्यात आहे आणि सध्या SSE सर्व्हरना सपोर्ट करते.

हे कसे करायचे:

1. एक रेपो क्लोन करा:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. लोकली टेस्ट करण्यासाठी ते रन करा:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. लोकली ट्राय करण्यासाठी, *.vscode* डिरेक्टरीमध्ये *mcp.json* फाईल तयार करा आणि खालील कंटेंट जोडा:

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

  SSE सर्व्हर सुरु झाल्यानंतर, JSON फाईलमधील प्ले आयकॉनवर क्लिक करा, तुम्हाला आता GitHub Copilot कडून सर्व्हरवरील टूल्स दिसतील, टूल आयकॉन पहा.

1. डिप्लॉय करण्यासाठी खालील कमांड रन करा:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

हेच आहे, लोकली डिप्लॉय करा, नंतर Azure वर या स्टेप्सने डिप्लॉय करा.

## अतिरिक्त संसाधने

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps article](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## पुढे काय

- पुढे: [Practical Implementation](/04-PracticalImplementation/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीकरिता व्यावसायिक मानवी भाषांतर शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुतींसाठी किंवा चुकीच्या अर्थलावांसाठी आम्ही जबाबदार नाही.