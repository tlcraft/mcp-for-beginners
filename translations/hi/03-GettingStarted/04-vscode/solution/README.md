<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:29:48+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "hi"
}
-->
# सैंपल चलाना

यहाँ हम मानते हैं कि आपके पास पहले से ही एक काम करता हुआ सर्वर कोड है। कृपया पहले के किसी अध्याय से एक सर्वर ढूंढें।

## mcp.json सेटअप करें

यहाँ एक फाइल है जिसका आप संदर्भ के लिए उपयोग कर सकते हैं, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)।

सर्वर एंट्री को आवश्यकतानुसार बदलें ताकि वह आपके सर्वर के पूर्ण पथ और चलाने के लिए आवश्यक पूर्ण कमांड को सही ढंग से दिखाए।

उदाहरण के लिए ऊपर संदर्भित फाइल में सर्वर एंट्री इस प्रकार दिखती है:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

यह कमांड चलाने के समान है: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` कुछ इस तरह कुछ टाइप करें "add 3 to 20"।

    आपको चैट टेक्स्ट बॉक्स के ऊपर एक टूल दिखाई देगा जो आपको टूल चलाने के लिए चुनने का संकेत देगा, जैसा कि इस चित्र में दिखाया गया है:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hi.png)

    टूल चुनने पर यदि आपका प्रॉम्प्ट जैसा हमने ऊपर बताया वैसा था, तो यह "23" जैसा कोई संख्यात्मक परिणाम देगा।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।