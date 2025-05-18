<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:14:54+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "hi"
}
-->
# इस नमूने को चलाना

`uv` स्थापित करने की सिफारिश की जाती है, लेकिन यह आवश्यक नहीं है, [निर्देश](https://docs.astral.sh/uv/#highlights) देखें

## -0- एक वर्चुअल एनवायरनमेंट बनाएं

```bash
python -m venv venv
```

## -1- वर्चुअल एनवायरनमेंट सक्रिय करें

```bash
venv\Scrips\activate
```

## -2- निर्भरताएँ स्थापित करें

```bash
pip install "mcp[cli]"
```

## -3- नमूना चलाएं

```bash
mcp run server.py
```

## -4- नमूना परीक्षण करें

जब सर्वर एक टर्मिनल में चल रहा हो, तो दूसरा टर्मिनल खोलें और निम्नलिखित कमांड चलाएं:

```bash
mcp dev server.py
```

यह एक वेब सर्वर शुरू करेगा जिसमें एक दृश्य इंटरफ़ेस होगा जो आपको नमूने का परीक्षण करने की अनुमति देगा।

एक बार सर्वर कनेक्ट हो जाने पर:

- उपकरणों को सूचीबद्ध करने का प्रयास करें और `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` इसके चारों ओर एक आवरण है।

आप इसे CLI मोड में सीधे निम्नलिखित कमांड चलाकर लॉन्च कर सकते हैं:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

यह सर्वर में उपलब्ध सभी उपकरणों को सूचीबद्ध करेगा। आपको निम्नलिखित आउटपुट देखना चाहिए:

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

किसी उपकरण को बुलाने के लिए टाइप करें:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

आपको निम्नलिखित आउटपुट देखना चाहिए:

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

> [!TIP]
> आमतौर पर ब्राउज़र की तुलना में CLI मोड में इंस्पेक्टर चलाना बहुत तेज़ होता है।
> इंस्पेक्टर के बारे में अधिक पढ़ें [यहां](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।