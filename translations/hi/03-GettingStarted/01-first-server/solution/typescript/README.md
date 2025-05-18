<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:21:59+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "hi"
}
-->
# इस उदाहरण को चलाना

आपको `uv` इंस्टॉल करने की सलाह दी जाती है, लेकिन यह अनिवार्य नहीं है, [निर्देश](https://docs.astral.sh/uv/#highlights) देखें।

## -1- निर्भरता इंस्टॉल करें

```bash
npm install
```

## -3- उदाहरण चलाएं

```bash
npm run build
```

## -4- उदाहरण का परीक्षण करें

एक टर्मिनल में सर्वर चलाने के साथ, दूसरा टर्मिनल खोलें और निम्नलिखित कमांड चलाएं:

```bash
npm run inspector
```

यह एक वेब सर्वर शुरू करेगा जिसमें एक दृश्य इंटरफ़ेस होगा, जो आपको उदाहरण का परीक्षण करने की अनुमति देगा।

एक बार सर्वर कनेक्ट होने के बाद:

- टूल्स की सूची बनाने की कोशिश करें और `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` इसे एक रैपर के रूप में चलाएं।

आप इसे CLI मोड में सीधे निम्नलिखित कमांड चलाकर लॉन्च कर सकते हैं:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

यह सर्वर में उपलब्ध सभी टूल्स की सूची बनाएगा। आपको निम्नलिखित आउटपुट दिखाई देना चाहिए:

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

किसी टूल को बुलाने के लिए टाइप करें:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

आपको निम्नलिखित आउटपुट दिखाई देना चाहिए:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> आमतौर पर ब्राउज़र की तुलना में CLI मोड में इंस्पेक्टर चलाना बहुत तेज़ होता है।
> इंस्पेक्टर के बारे में अधिक पढ़ें [यहां](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल भाषा में दस्तावेज़ को आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।