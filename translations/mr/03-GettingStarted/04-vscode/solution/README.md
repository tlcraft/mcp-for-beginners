<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:33:55+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "mr"
}
-->
# नमुना चालवणे

येथे आपण गृहित धरतो की तुमच्याकडे आधीच एक कार्यरत सर्व्हर कोड आहे. कृपया आधीच्या अध्यायांमधील कोणत्याही सर्व्हरचा शोध घ्या.

## mcp.json सेट करा

हे एक संदर्भासाठी वापरायचे फाइल आहे, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

तुमच्या सर्व्हरकडे पूर्ण मार्ग आणि आवश्यक संपूर्ण आदेश दाखवण्यासाठी सर्व्हर एंट्री आवश्यकतेनुसार बदला.

वरील उदाहरण फाइलमध्ये सर्व्हर एंट्री असे दिसते:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

हे खालीलप्रमाणे आदेश चालवण्याशी जुळते: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` काहीतरी असं लिहा "add 3 to 20".

    तुम्हाला चॅट टेक्स्ट बॉक्सच्या वर एक टूल दिसेल जे तुम्हाला टूल चालवण्यासाठी निवडण्यास सांगेल, जसं या दृश्यात आहे:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.mr.png)

    टूल निवडल्यानंतर जर तुमचा प्रॉम्प्ट वरीलप्रमाणे असेल तर "23" असा संख्यात्मक निकाल दिसेल.

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) चा वापर करून भाषांतरित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाची माहिती असल्यास, व्यावसायिक मानवी भाषांतर करण्याचा सल्ला दिला जातो. या भाषांतराच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थ लावण्याबद्दल आम्ही जबाबदार नाही.