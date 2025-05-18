<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:19:20+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "hi"
}
-->
# नमूना चलाना

यहां हम मानते हैं कि आपके पास पहले से ही कार्यशील सर्वर कोड है। कृपया पहले के अध्यायों में से किसी एक सर्वर को ढूंढें।

## mcp.json सेट करें

यहां एक फ़ाइल है जिसे आप संदर्भ के लिए उपयोग करते हैं, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)।

सर्वर प्रविष्टि को आवश्यकतानुसार बदलें ताकि आपके सर्वर के लिए पूर्ण पथ सहित इसे चलाने के लिए आवश्यक पूर्ण कमांड की ओर इशारा किया जा सके।

ऊपर संदर्भित उदाहरण फ़ाइल में सर्वर प्रविष्टि इस प्रकार दिखती है:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

यह इस प्रकार के कमांड को चलाने से मेल खाता है: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` कुछ ऐसा टाइप करें "add 3 to 20"।

    आपको चैट टेक्स्ट बॉक्स के ऊपर एक टूल प्रदर्शित होता दिखाई देना चाहिए जो आपको टूल चलाने के लिए चयन करने का संकेत देता है जैसा कि इस दृश्य में है:

    ![VS Code यह संकेत देता है कि वह एक टूल चलाना चाहता है](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.hi.png)

    टूल का चयन करने पर एक संख्यात्मक परिणाम "23" दिखाई देना चाहिए यदि आपका प्रॉम्प्ट जैसा हमने पहले उल्लेख किया था।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में प्राधिकृत स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।