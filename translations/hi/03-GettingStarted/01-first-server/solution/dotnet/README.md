<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:07:47+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "hi"
}
-->
# इस नमूने को चलाना

## -1- निर्भरता स्थापित करें

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- नमूना चलाएं

```bash
dotnet run
```

## -4- नमूना परीक्षण करें

एक टर्मिनल में सर्वर चलाते हुए, दूसरा टर्मिनल खोलें और निम्नलिखित कमांड चलाएं:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

यह एक वेब सर्वर शुरू करना चाहिए जिसमें एक दृश्य इंटरफ़ेस होगा जो आपको नमूने का परीक्षण करने की अनुमति देगा।

एक बार सर्वर कनेक्ट हो जाने पर:

- टूल्स की सूची बनाने की कोशिश करें और `add` चलाएं, तर्क 2 और 4 के साथ, आपको परिणाम में 6 दिखाई देना चाहिए।
- संसाधनों और संसाधन टेम्पलेट पर जाएं और "greeting" कॉल करें, एक नाम टाइप करें और आपको आपके द्वारा प्रदान किए गए नाम के साथ एक अभिवादन दिखाई देना चाहिए।

### CLI मोड में परीक्षण

आप निम्नलिखित कमांड चलाकर इसे सीधे CLI मोड में लॉन्च कर सकते हैं:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

यह सर्वर में उपलब्ध सभी टूल्स की सूची बनाएगा। आपको निम्नलिखित आउटपुट दिखाई देना चाहिए:

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

किसी टूल को इनवोक करने के लिए टाइप करें:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

आपको निम्नलिखित आउटपुट दिखाई देना चाहिए:

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
> आमतौर पर CLI मोड में इंस्पेक्टर चलाना ब्राउज़र की तुलना में बहुत तेज होता है।
> इंस्पेक्टर के बारे में अधिक पढ़ें [यहां](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल भाषा में मूल दस्तावेज़ को प्राधिकृत स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।