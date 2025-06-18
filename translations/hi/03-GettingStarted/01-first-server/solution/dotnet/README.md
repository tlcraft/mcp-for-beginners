<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:53:18+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "hi"
}
-->
# इस सैंपल को चलाना

## -1- निर्भरताएँ इंस्टॉल करें

```bash
dotnet restore
```

## -3- सैंपल चलाएं

```bash
dotnet run
```

## -4- सैंपल का परीक्षण करें

जब सर्वर एक टर्मिनल में चल रहा हो, तो दूसरा टर्मिनल खोलें और निम्नलिखित कमांड चलाएं:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

इससे एक वेब सर्वर शुरू होगा जिसमें एक विज़ुअल इंटरफ़ेस होगा जो आपको सैंपल का परीक्षण करने देगा।

सर्वर कनेक्ट होने के बाद:

- टूल्स की सूची देखें और `add` चलाएं, आर्ग्स के रूप में 2 और 4 दें, परिणाम में आपको 6 दिखना चाहिए।
- resources और resource template में जाएं और "greeting" कॉल करें, कोई नाम टाइप करें और आपको उस नाम के साथ एक अभिवादन दिखेगा।

### CLI मोड में परीक्षण

आप इसे सीधे CLI मोड में निम्न कमांड चलाकर लॉन्च कर सकते हैं:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

यह सर्वर में उपलब्ध सभी टूल्स की सूची दिखाएगा। आपको निम्न आउटपुट दिखना चाहिए:

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

आपको निम्न आउटपुट दिखेगा:

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
> आमतौर पर ब्राउज़र की तुलना में CLI मोड में inspector चलाना कहीं तेज़ होता है।
> inspector के बारे में अधिक पढ़ें [यहाँ](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या गलतियाँ हो सकती हैं। मूल दस्तावेज़ को इसकी मूल भाषा में अधिकृत स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।