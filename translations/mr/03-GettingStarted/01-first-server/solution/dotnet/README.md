<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-09T21:57:55+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "mr"
}
-->
# हा नमुना चालविणे

## -1- अवलंबित्वे इंस्टॉल करा

```bash
dotnet restore
```

## -3- नमुना चालवा

```bash
dotnet run
```

## -4- नमुन्याची चाचणी करा

सर्व्हर एका टर्मिनलमध्ये चालू असताना, दुसरा टर्मिनल उघडा आणि खालील कमांड चालवा:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

यामुळे एक वेब सर्व्हर सुरू होईल ज्यामध्ये एक दृश्यात्मक इंटरफेस असेल, ज्याद्वारे तुम्ही नमुन्याची चाचणी करू शकता.

सर्व्हर कनेक्ट झाल्यानंतर:

- टूल्सची यादी पाहा आणि `add` चालवा, 2 आणि 4 या आर्ग्युमेंट्ससह, तुम्हाला निकालात 6 दिसेल.
- resources आणि resource template मध्ये जा आणि "greeting" कॉल करा, नाव टाका आणि तुम्हाला दिलेल्या नावासह एक अभिवादन दिसेल.

### CLI मोडमध्ये चाचणी

तुम्ही खालील कमांड चालवून थेट CLI मोडमध्ये हे सुरू करू शकता:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

यामुळे सर्व्हरमधील सर्व टूल्सची यादी दिसेल. तुम्हाला खालील आउटपुट दिसेल:

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

टूल कॉल करण्यासाठी टाइप करा:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

तुम्हाला खालील आउटपुट दिसेल:

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
> CLI मोडमध्ये inspector चालवणे ब्राउझरच्या तुलनेत सहसा खूप जलद असते.
> inspector बद्दल अधिक वाचा [येथे](https://github.com/modelcontextprotocol/inspector).

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.