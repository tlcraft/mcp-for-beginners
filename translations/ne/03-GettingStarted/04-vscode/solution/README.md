<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:35:46+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "ne"
}
-->
# नमुना चलाउने तरिका

यहाँ हामी मान्दैछौं कि तपाईंसँग पहिले नै काम गर्ने सर्वर कोड छ। कृपया पहिलेका कुनै अध्यायबाट सर्वर फेला पार्नुहोस्।

## mcp.json सेटअप गर्ने तरिका

यहाँ एउटा फाइल छ जुन तपाईं सन्दर्भका लागि प्रयोग गर्न सक्नुहुन्छ, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)।

सर्भर एंट्री आवश्यक अनुसार परिवर्तन गर्नुहोस् ताकि तपाईँको सर्भरको पूर्ण पथ र चलाउन आवश्यक कमाण्ड समावेश होस्।

माथि उल्लेखित उदाहरण फाइलमा सर्भर एंट्री यसरी देखिन्छ:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

यो यसरी कमाण्ड चलाउन समकक्ष हुन्छ: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` जस्तो केहि लेख्नुहोस्, जस्तै "add 3 to 20"।

    तपाईँले च्याट टेक्स्ट बक्सको माथि एउटा उपकरण देख्नु पर्नेछ जुन उपकरण चलाउन चयन गर्नका लागि संकेत गर्छ, यसरी:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ne.png)

    उपकरण चयन गर्दा यदि तपाईँको प्रॉम्प्ट हामीले पहिले भनेजस्तै थियो भने "23" भन्ने संख्यात्मक नतिजा आउनुपर्छ।

**अस्वीकरण**:  
यस दस्तावेजलाई AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा नै आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानवीय अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।