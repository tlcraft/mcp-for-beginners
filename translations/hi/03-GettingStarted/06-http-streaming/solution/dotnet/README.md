<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-07-13T21:03:25+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "hi"
}
-->
# इस सैंपल को चलाना

## -1- निर्भरताएँ इंस्टॉल करें

```bash
dotnet restore
```

## -2- सैंपल चलाएँ

```bash
dotnet run
```

## -3- सैंपल का परीक्षण करें

नीचे दिए गए कमांड को चलाने से पहले एक अलग टर्मिनल खोलें (सुनिश्चित करें कि सर्वर अभी भी चल रहा है)।

जब एक टर्मिनल में सर्वर चल रहा हो, तो दूसरा टर्मिनल खोलें और निम्न कमांड चलाएँ:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

यह एक वेब सर्वर शुरू करेगा जिसमें एक विज़ुअल इंटरफ़ेस होगा, जिससे आप सैंपल का परीक्षण कर सकेंगे।

> सुनिश्चित करें कि **Streamable HTTP** ट्रांसपोर्ट टाइप के रूप में चुना गया है, और URL `http://localhost:3001/mcp` है।

सर्वर कनेक्ट होने के बाद:

- टूल्स की सूची देखें और `add` कमांड चलाएँ, आर्ग्स 2 और 4 के साथ, आपको परिणाम में 6 दिखाई देगा।
- resources और resource template में जाएँ और "greeting" कॉल करें, एक नाम टाइप करें और आपको उस नाम के साथ एक अभिवादन दिखाई देगा।

### CLI मोड में परीक्षण

आप इसे सीधे CLI मोड में निम्न कमांड चलाकर लॉन्च कर सकते हैं:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

यह सर्वर में उपलब्ध सभी टूल्स की सूची दिखाएगा। आपको निम्न आउटपुट दिखाई देगा:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
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
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

आपको निम्न आउटपुट दिखाई देगा:

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
> आमतौर पर ब्राउज़र की तुलना में CLI मोड में inspector चलाना कहीं तेज़ होता है।
> inspector के बारे में अधिक पढ़ें [यहाँ](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।