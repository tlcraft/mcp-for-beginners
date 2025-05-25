<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:18:45+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "mo"
}
-->
# नमूना चलाना

यहां हम मान लेते हैं कि आपके पास पहले से ही एक कार्यशील सर्वर कोड है। कृपया पहले के अध्यायों में से किसी एक सर्वर का पता लगाएं।

## mcp.json सेट करें

यहाँ एक फाइल है जिसे आप संदर्भ के लिए उपयोग कर सकते हैं, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)।

सर्वर प्रविष्टि को आवश्यकतानुसार बदलें ताकि यह आपके सर्वर के पूर्ण पथ की ओर इशारा करे, जिसमें चलाने के लिए आवश्यक पूर्ण कमांड शामिल हो।

उपरोक्त संदर्भित उदाहरण फाइल में सर्वर प्रविष्टि इस प्रकार दिखती है:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

यह इस प्रकार के कमांड को चलाने के अनुरूप है: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` कुछ इस तरह टाइप करें "add 3 to 20"।

    आपको चैट टेक्स्ट बॉक्स के ऊपर एक टूल प्रस्तुत होते हुए दिखाई देना चाहिए, जो आपको टूल चलाने के लिए चयन करने का संकेत देगा, जैसा कि इस दृश्य में दिखाया गया है:

    ![VS Code संकेत करता है कि वह एक टूल चलाना चाहता है](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.mo.png)

    टूल का चयन करने पर एक संख्यात्मक परिणाम "23" कहता हुआ आना चाहिए, यदि आपका प्रॉम्प्ट जैसा हमने पहले बताया था।

I'm sorry, but I'm not sure what language you're referring to with "mo." Could you please provide more context or specify the language you're interested in?