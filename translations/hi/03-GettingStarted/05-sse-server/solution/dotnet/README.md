<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:54:14+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "hi"
}
-->
# इस नमूने को चलाना

## -1- निर्भरता स्थापित करें

```bash
dotnet run
```

## -2- नमूना चलाएं

```bash
dotnet run
```

## -3- नमूना परीक्षण करें

नीचे दिए गए को चलाने से पहले एक अलग टर्मिनल शुरू करें (सुनिश्चित करें कि सर्वर अभी भी चल रहा है)।

सर्वर को एक टर्मिनल में चलाते हुए, एक और टर्मिनल खोलें और निम्नलिखित कमांड चलाएं:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

यह एक वेब सर्वर शुरू करेगा जिसमें एक दृश्य इंटरफ़ेस होगा जिससे आप नमूने का परीक्षण कर सकते हैं।

एक बार सर्वर कनेक्ट हो जाने पर:

- टूल्स को सूचीबद्ध करने की कोशिश करें और `add` चलाएं, आर्ग्स 2 और 4 के साथ, आपको परिणाम में 6 दिखाई देना चाहिए।
- संसाधनों और संसाधन टेम्पलेट पर जाएं और "greeting" कॉल करें, एक नाम टाइप करें और आपको आपके द्वारा प्रदान किए गए नाम के साथ एक अभिवादन दिखाई देना चाहिए।

### CLI मोड में परीक्षण

आप इसे सीधे CLI मोड में निम्नलिखित कमांड चलाकर लॉन्च कर सकते हैं:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

यह सर्वर में उपलब्ध सभी टूल्स को सूचीबद्ध करेगा। आपको निम्नलिखित आउटपुट देखना चाहिए:

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

किसी टूल को बुलाने के लिए टाइप करें:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> ब्राउज़र की तुलना में CLI मोड में इंस्पेक्टर को चलाना आमतौर पर बहुत तेज होता है।
> इंस्पेक्टर के बारे में अधिक पढ़ें [यहां](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया अवगत रहें कि स्वचालित अनुवादों में त्रुटियाँ या गलतियाँ हो सकती हैं। मूल भाषा में मूल दस्तावेज़ को आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।