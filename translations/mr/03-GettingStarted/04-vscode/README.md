<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8ea28e5e566edd5969337fd0b191ba3f",
  "translation_date": "2025-07-17T00:27:21+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "mr"
}
-->
# GitHub Copilot Agent मोडमधून सर्व्हर वापरणे

Visual Studio Code आणि GitHub Copilot हे क्लायंट म्हणून काम करू शकतात आणि MCP Server वापरू शकतात. तुम्हाला कदाचित विचार येईल, आपण हे का करू इच्छितो? याचा अर्थ असा की MCP Server मध्ये असलेली कोणतीही वैशिष्ट्ये आता तुमच्या IDE मधून वापरता येतील. उदाहरणार्थ, GitHub चा MCP Server जोडल्यास, टर्मिनलमध्ये विशिष्ट कमांड टाइप करण्याऐवजी प्रॉम्प्ट्सद्वारे GitHub नियंत्रित करता येईल. किंवा सामान्यतः काहीही जे तुमचा डेव्हलपर अनुभव सुधारू शकते, ते नैसर्गिक भाषेत नियंत्रित करता येईल. आता तुम्हाला फायदा दिसू लागला ना?

## आढावा

हा धडा Visual Studio Code आणि GitHub Copilot च्या Agent मोडचा वापर करून तुमच्या MCP Server साठी क्लायंट कसा वापरायचा हे शिकवतो.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही खालील गोष्टी करू शकाल:

- Visual Studio Code द्वारे MCP Server वापरणे.
- GitHub Copilot द्वारे टूल्ससारख्या क्षमता चालवणे.
- Visual Studio Code मध्ये तुमचा MCP Server शोधणे आणि व्यवस्थापित करण्यासाठी कॉन्फिगर करणे.

## वापर

तुम्ही तुमचा MCP Server दोन वेगवेगळ्या मार्गांनी नियंत्रित करू शकता:

- वापरकर्ता इंटरफेस, हे कसे करायचे ते तुम्हाला या प्रकरणात नंतर दाखवले जाईल.
- टर्मिनल, `code` executable वापरून टर्मिनलमधून गोष्टी नियंत्रित करणे शक्य आहे:

  तुमच्या वापरकर्ता प्रोफाइलमध्ये MCP Server जोडण्यासाठी, --add-mcp कमांड लाइन पर्याय वापरा आणि JSON सर्व्हर कॉन्फिगरेशन `{ "name": "server-name", "command": ... }` या स्वरूपात द्या.

  ```
  code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
  ```

### स्क्रीनशॉट्स

![Visual Studio Code मध्ये मार्गदर्शित MCP सर्व्हर कॉन्फिगरेशन](../../../../translated_images/chat-mode-agent.729a22473f822216dd1e723aaee1f7d4a2ede571ee0948037a2d9357a63b9d0b.mr.png)  
![प्रत्येक एजंट सत्रासाठी टूल निवड](../../../../translated_images/agent-mode-select-tools.522c7ba5df0848f8f0d1e439c2e96159431bc620cb39ccf3f5dc611412fd0006.mr.png)  
![MCP विकासादरम्यान त्रुटी सहज डिबग करा](../../../../translated_images/mcp-list-servers.fce89eefe3f30032bed8952e110ab9d82fadf043fcfa071f7d40cf93fb1ea9e9.mr.png)

पुढील विभागांमध्ये आपण व्हिज्युअल इंटरफेस कसा वापरतो याबद्दल अधिक चर्चा करूया.

## दृष्टिकोन

उच्च स्तरावर आपल्याला असे करावे लागेल:

- आमच्या MCP Server साठी शोधण्यासाठी एक फाइल कॉन्फिगर करा.
- त्या सर्व्हरला सुरू करा/कनेक्ट करा जेणेकरून त्याच्या क्षमता यादीत दिसतील.
- GitHub Copilot Chat इंटरफेसद्वारे त्या क्षमतांचा वापर करा.

छान, आता आपण प्रवाह समजला आहे, चला Visual Studio Code द्वारे MCP Server वापरण्याचा सराव करूया.

## सराव: सर्व्हर वापरणे

या सरावात, आपण Visual Studio Code मध्ये तुमचा MCP Server शोधण्यासाठी कॉन्फिगर करू जेणेकरून तो GitHub Copilot Chat इंटरफेसमधून वापरता येईल.

### -0- पूर्वतयारी, MCP Server शोध सक्षम करा

तुम्हाला MCP Servers चा शोध सक्षम करावा लागू शकतो.

1. Visual Studio Code मध्ये `File -> Preferences -> Settings` येथे जा.

1. "MCP" शोधा आणि settings.json फाइलमध्ये `chat.mcp.discovery.enabled` सक्षम करा.

### -1- कॉन्फिग फाइल तयार करा

तुमच्या प्रोजेक्टच्या मूळ फोल्डरमध्ये .vscode नावाचा फोल्डर तयार करा आणि त्यात MCP.json नावाची फाइल तयार करा. ती अशी दिसायला हवी:

```text
.vscode
|-- mcp.json
```

आता पाहूया सर्व्हर एंट्री कशी जोडायची.

### -2- सर्व्हर कॉन्फिगर करा

*mcp.json* मध्ये खालील सामग्री जोडा:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

वरील उदाहरणात Node.js मध्ये लिहिलेला सर्व्हर कसा सुरू करायचा हे दाखवले आहे, इतर रनटाइमसाठी `command` आणि `args` वापरून योग्य कमांड द्या.

### -3- सर्व्हर सुरू करा

आता तुम्ही एंट्री जोडली आहे, चला सर्व्हर सुरू करूया:

1. *mcp.json* मध्ये तुमची एंट्री शोधा आणि "play" आयकॉन दिसत असल्याची खात्री करा:

  ![Visual Studio Code मध्ये सर्व्हर सुरू करणे](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.mr.png)  

1. "play" आयकॉनवर क्लिक करा, GitHub Copilot Chat मध्ये टूल्स आयकॉनवर उपलब्ध टूल्सची संख्या वाढल्याचे दिसेल. त्या टूल्स आयकॉनवर क्लिक केल्यास नोंदणीकृत टूल्सची यादी दिसेल. तुम्ही प्रत्येक टूल निवडू किंवा न निवडू शकता, ज्यामुळे GitHub Copilot त्यांना संदर्भ म्हणून वापरेल की नाही हे ठरवता येईल:

  ![Visual Studio Code मध्ये टूल्स](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.mr.png)

1. टूल चालवण्यासाठी, असा प्रॉम्प्ट टाइप करा ज्याचा वर्णन तुमच्या टूल्सपैकी एका टूलशी जुळतो, उदाहरणार्थ "add 22 to 1":

  ![GitHub Copilot मधून टूल चालवणे](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.mr.png)

  तुम्हाला 23 असा प्रतिसाद दिसेल.

## असाइनमेंट

तुमच्या *mcp.json* फाइलमध्ये सर्व्हर एंट्री जोडा आणि सर्व्हर सुरू/थांबवू शकता याची खात्री करा. तसेच GitHub Copilot Chat इंटरफेसद्वारे तुमच्या सर्व्हरवरील टूल्सशी संवाद साधू शकता याची खात्री करा.

## सोल्यूशन

[Solution](./solution/README.md)

## मुख्य मुद्दे

या प्रकरणातून घेण्यासारखे मुद्दे:

- Visual Studio Code हा एक उत्कृष्ट क्लायंट आहे जो तुम्हाला अनेक MCP Servers आणि त्यांचे टूल्स वापरण्याची परवानगी देतो.
- GitHub Copilot Chat इंटरफेसद्वारे तुम्ही सर्व्हरशी संवाद साधता.
- तुम्ही वापरकर्त्याकडून API कीजसारखे इनपुट मागवू शकता जे *mcp.json* फाइलमध्ये सर्व्हर एंट्री कॉन्फिग करताना MCP Server कडे पाठवता येतात.

## नमुने

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../../../../03-GettingStarted/samples/typescript)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधने

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## पुढे काय

- पुढे: [SSE Server तयार करणे](../05-sse-server/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेच्या त्रुटी असू शकतात. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.