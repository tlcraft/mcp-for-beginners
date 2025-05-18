<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:13:09+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "sl"
}
-->
# इस नमूने को चलाना

## -1- निर्भरताएँ स्थापित करें

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- नमूना चलाएँ

```bash
dotnet run
```

## -4- नमूने का परीक्षण करें

जब सर्वर एक टर्मिनल में चल रहा हो, तो एक और टर्मिनल खोलें और निम्नलिखित कमांड चलाएँ:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

यह एक वेब सर्वर शुरू करना चाहिए जिसमें एक दृश्य इंटरफ़ेस हो, जो आपको नमूने का परीक्षण करने की अनुमति देगा।

एक बार जब सर्वर कनेक्ट हो जाए:

- उपकरण सूचीबद्ध करने का प्रयास करें और `add` चलाएँ, 2 और 4 के साथ तर्क के रूप में, आपको परिणाम में 6 देखना चाहिए।
- संसाधनों और संसाधन टेम्पलेट पर जाएं और "greeting" को कॉल करें, एक नाम टाइप करें और आपको आपके द्वारा प्रदान किए गए नाम के साथ एक अभिवादन देखना चाहिए।

### CLI मोड में परीक्षण

आप इसे CLI मोड में सीधे निम्नलिखित कमांड चलाकर शुरू कर सकते हैं:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

यह सर्वर में उपलब्ध सभी उपकरणों को सूचीबद्ध करेगा। आपको निम्नलिखित आउटपुट देखना चाहिए:

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

किसी उपकरण को चलाने के लिए टाइप करें:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

आपको निम्नलिखित आउटपुट देखना चाहिए:

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
> आमतौर पर CLI मोड में निरीक्षक चलाना ब्राउज़र की तुलना में काफी तेज़ होता है।
> निरीक्षक के बारे में अधिक पढ़ें [यहाँ](https://github.com/modelcontextprotocol/inspector)।

**Omejitev odgovornosti**: 
Ta dokument je bil preveden z uporabo storitve AI prevajanja [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da avtomatski prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije je priporočljivo profesionalno človeško prevajanje. Ne odgovarjamo za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.