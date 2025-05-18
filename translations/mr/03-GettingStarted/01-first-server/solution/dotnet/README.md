<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:08:03+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "mr"
}
-->
# या नमुन्याचे चालवणे

## -1- अवलंबित्वे स्थापित करा

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- नमुना चालवा

```bash
dotnet run
```

## -4- नमुना तपासा

सर्व्हर एका टर्मिनलमध्ये चालू असताना, दुसरे टर्मिनल उघडा आणि खालील आदेश चालवा:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

हे एक वेब सर्व्हर सुरू करेल ज्यामध्ये तुम्हाला नमुना तपासण्यासाठी व्हिज्युअल इंटरफेस मिळेल.

सर्व्हर कनेक्ट झाल्यानंतर:

- साधनांची यादी करण्याचा प्रयत्न करा आणि `add` चालवा, args 2 आणि 4 सह, तुम्हाला परिणामात 6 दिसेल.
- संसाधने आणि संसाधन टेम्पलेटला जा आणि "greeting" कॉल करा, एक नाव टाइप करा आणि तुम्ही दिलेल्या नावासह एक अभिवादन पाहावे.

### CLI मोडमध्ये चाचणी

तुम्ही खालील आदेश चालवून ते थेट CLI मोडमध्ये सुरू करू शकता:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

हे सर्व्हरमधील सर्व उपलब्ध साधने सूचीबद्ध करेल. तुम्हाला खालील आउटपुट दिसावे:

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

साधन चालवण्यासाठी टाइप करा:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

तुम्हाला खालील आउटपुट दिसावे:

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
> CLI मोडमध्ये निरीक्षक चालवणे ब्राउझरपेक्षा सामान्यतः खूप जलद असते.
> निरीक्षकाबद्दल अधिक वाचा [इथे](https://github.com/modelcontextprotocol/inspector).

**अस्वीकृती**:  
हे दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केले गेले आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात ठेवा की स्वयंचलित भाषांतरे त्रुटी किंवा अशुद्धता असू शकतात. मूळ भाषेतील मूळ दस्तऐवज अधिकृत स्रोत मानला जावा. महत्वाच्या माहितीसाठी, व्यावसायिक मानव भाषांतराची शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.