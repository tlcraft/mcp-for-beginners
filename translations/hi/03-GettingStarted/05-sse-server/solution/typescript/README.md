<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:19:22+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "hi"
}
-->
# इस सैंपल को चलाना

## -1- निर्भरताएँ इंस्टॉल करें

```bash
npm install
```

## -3- सैंपल चलाएँ

```bash
npm run build
```

## -4- सैंपल का परीक्षण करें

जब सर्वर एक टर्मिनल में चल रहा हो, तो दूसरा टर्मिनल खोलें और निम्नलिखित कमांड चलाएँ:

```bash
npm run inspector
```

इससे एक वेब सर्वर शुरू होगा जिसमें एक विज़ुअल इंटरफ़ेस होगा, जिससे आप सैंपल का परीक्षण कर सकेंगे।

सर्वर कनेक्ट होने के बाद:

- टूल्स की सूची देखें और `add` कमांड चलाएँ, जिसमें आर्ग्स 2 और 4 हों, आपको परिणाम में 6 दिखना चाहिए।
- resources और resource template में जाएँ और "greeting" कॉल करें, एक नाम टाइप करें और आपको उस नाम के साथ एक अभिवादन दिखेगा।

### CLI मोड में परीक्षण

आपने जो inspector चलाया है वह वास्तव में एक Node.js ऐप है और `mcp dev` इसके ऊपर एक रैपर है।

- सर्वर को कमांड `npm run build` से शुरू करें।

- एक अलग टर्मिनल में निम्नलिखित कमांड चलाएँ:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    यह सर्वर में उपलब्ध सभी टूल्स की सूची दिखाएगा। आपको निम्नलिखित आउटपुट दिखना चाहिए:

    ```text
    {
    "tools": [
        {
        "name": "add",
        "description": "Add two numbers",
        "inputSchema": {
            "type": "object",
            "properties": {
            "a": {
                "title": "A",
                "type": "integer"
            },
            "b": {
                "title": "B",
                "type": "integer"
            }
            },
            "required": [
            "a",
            "b"
            ],
            "title": "addArguments"
        }
        }
    ]
    }
    ```

- टूल टाइप को निम्नलिखित कमांड टाइप करके कॉल करें:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

आपको निम्नलिखित आउटपुट दिखना चाहिए:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> CLI मोड में inspector चलाना ब्राउज़र की तुलना में आमतौर पर कहीं तेज़ होता है।
> inspector के बारे में अधिक पढ़ें [यहाँ](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।