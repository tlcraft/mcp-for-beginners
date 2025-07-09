<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T23:01:08+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "hi"
}
-->
# इस सैंपल को चलाना

आपको `uv` इंस्टॉल करने की सलाह दी जाती है लेकिन यह जरूरी नहीं है, देखें [निर्देश](https://docs.astral.sh/uv/#highlights)

## -0- एक वर्चुअल एनवायरनमेंट बनाएं

```bash
python -m venv venv
```

## -1- वर्चुअल एनवायरनमेंट को सक्रिय करें

```bash
venv\Scrips\activate
```

## -2- निर्भरताएँ इंस्टॉल करें

```bash
pip install "mcp[cli]"
```

## -3- सैंपल चलाएं

```bash
mcp run server.py
```

## -4- सैंपल का परीक्षण करें

जब एक टर्मिनल में सर्वर चल रहा हो, तो दूसरा टर्मिनल खोलें और निम्नलिखित कमांड चलाएं:

```bash
mcp dev server.py
```

इससे एक वेब सर्वर शुरू होगा जिसमें एक विज़ुअल इंटरफ़ेस होगा जो आपको सैंपल का परीक्षण करने की अनुमति देगा।

सर्वर कनेक्ट होने के बाद:

- टूल्स की सूची देखें और `add` कमांड चलाएं, आर्ग्स 2 और 4 के साथ, आपको परिणाम में 6 दिखना चाहिए।

- resources और resource template में जाएं और get_greeting कॉल करें, एक नाम टाइप करें और आपको उस नाम के साथ एक अभिवादन दिखाई देगा।

### CLI मोड में परीक्षण

जो इंस्पेक्टर आपने चलाया है वह वास्तव में एक Node.js ऐप है और `mcp dev` इसके चारों ओर एक रैपर है।

आप इसे सीधे CLI मोड में निम्नलिखित कमांड चलाकर लॉन्च कर सकते हैं:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

यह सर्वर में उपलब्ध सभी टूल्स की सूची दिखाएगा। आपको निम्नलिखित आउटपुट दिखाई देना चाहिए:

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

किसी टूल को कॉल करने के लिए टाइप करें:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> इंस्पेक्टर के बारे में अधिक पढ़ें [यहाँ](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।