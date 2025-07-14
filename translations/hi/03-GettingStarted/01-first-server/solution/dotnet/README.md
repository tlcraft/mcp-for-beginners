<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-13T17:47:56+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "hi"
}
-->
# इस सैंपल को चलाना

## -1- निर्भरताएँ इंस्टॉल करें

```bash
dotnet restore
```

## -3- सैंपल चलाएँ

```bash
dotnet run
```

## -4- सैंपल का परीक्षण करें

जब एक टर्मिनल में सर्वर चल रहा हो, तो दूसरा टर्मिनल खोलें और निम्नलिखित कमांड चलाएँ:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

इससे एक वेब सर्वर शुरू होगा जिसमें एक विज़ुअल इंटरफ़ेस होगा जो आपको सैंपल का परीक्षण करने की अनुमति देगा।

सर्वर कनेक्ट होने के बाद:

- टूल्स की सूची देखें और `add` चलाएँ, आर्ग्स 2 और 4 के साथ, आपको परिणाम में 6 दिखाई देगा।
- resources और resource template में जाएँ और "greeting" कॉल करें, एक नाम टाइप करें और आपको उस नाम के साथ एक अभिवादन दिखाई देगा जो आपने दिया है।

### CLI मोड में परीक्षण

आप इसे सीधे CLI मोड में निम्नलिखित कमांड चलाकर लॉन्च कर सकते हैं:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

यह सर्वर में उपलब्ध सभी टूल्स की सूची दिखाएगा। आपको निम्नलिखित आउटपुट दिखाई देगा:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

किसी टूल को कॉल करने के लिए टाइप करें:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

आपको निम्नलिखित आउटपुट दिखाई देगा:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
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