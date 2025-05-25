<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:01:18+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "hi"
}
-->
# इस नमूने को चलाना

आपको `uv` स्थापित करने की सलाह दी जाती है, लेकिन यह जरूरी नहीं है, [निर्देश](https://docs.astral.sh/uv/#highlights) देखें।

## -0- एक वर्चुअल वातावरण बनाएं

```bash
python -m venv venv
```

## -1- वर्चुअल वातावरण सक्रिय करें

```bash
venv\Scrips\activate
```

## -2- आवश्यकताएँ स्थापित करें

```bash
pip install "mcp[cli]"
```

## -3- नमूना चलाएं

```bash
mcp run server.py
```

## -4- नमूने का परीक्षण करें

जब सर्वर एक टर्मिनल में चल रहा हो, तो दूसरा टर्मिनल खोलें और निम्नलिखित कमांड चलाएँ:

```bash
mcp dev server.py
```

यह एक वेब सर्वर शुरू करना चाहिए जिसमें एक दृश्य इंटरफ़ेस हो जो आपको नमूने का परीक्षण करने की अनुमति देता है।

एक बार सर्वर जुड़ने के बाद:

- उपकरणों को सूचीबद्ध करने का प्रयास करें और `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` इसके चारों ओर एक रैपर है।

आप निम्नलिखित कमांड चलाकर इसे सीधे CLI मोड में लॉन्च कर सकते हैं:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
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

किसी उपकरण को चालू करने के लिए टाइप करें:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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

> ![!TIP]
> आमतौर पर ब्राउज़र की तुलना में CLI मोड में इंस्पेक्टर चलाना बहुत तेज होता है।
> इंस्पेक्टर के बारे में अधिक पढ़ें [यहाँ](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल भाषा में मूल दस्तावेज़ को आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।