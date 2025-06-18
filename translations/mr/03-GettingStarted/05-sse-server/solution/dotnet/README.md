<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:54:34+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "mr"
}
-->
# या नमुन्याचा वापर करणे

## -1- अवलंबित्वे इंस्टॉल करा

```bash
dotnet restore
```

## -2- नमुना चालवा

```bash
dotnet run
```

## -3- नमुन्याची चाचणी करा

खालील कमांड चालवण्यापूर्वी वेगळा टर्मिनल उघडा (सर्व्हर अजूनही चालू आहे याची खात्री करा).

एक टर्मिनलमध्ये सर्व्हर चालू असताना, दुसरा टर्मिनल उघडा आणि खालील कमांड चालवा:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

यामुळे एक वेब सर्व्हर सुरू होईल ज्यामध्ये एक व्हिज्युअल इंटरफेस असेल, ज्याद्वारे तुम्ही नमुन्याची चाचणी करू शकता.

> खात्री करा की **SSE** हा ट्रान्सपोर्ट प्रकार म्हणून निवडलेला आहे, आणि URL `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add` आहे, args 2 आणि 4 असतील तर निकालात 6 दिसेल.
- resources आणि resource template मध्ये जा आणि "greeting" कॉल करा, नाव टाका आणि तुम्हाला दिलेल्या नावासह एक अभिवादन दिसेल.

### CLI मोडमध्ये चाचणी

तुम्ही थेट CLI मोडमध्ये खालील कमांड चालवून हे सुरू करू शकता:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

यामुळे सर्व्हरमध्ये उपलब्ध असलेले सर्व टूल्स यादीत दिसतील. तुम्हाला खालील आउटपुट दिसेल:

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

टूल कॉल करण्यासाठी टाइप करा:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

तुम्हाला खालील आउटपुट दिसेल:

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
> ब्राउझरच्या तुलनेत CLI मोडमध्ये inspector चालवणे सहसा जास्त वेगाने होते.
> inspector बद्दल अधिक वाचा [इथे](https://github.com/modelcontextprotocol/inspector).

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अपूर्णता असू शकतात. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाची माहिती साठी व्यावसायिक मानवी अनुवाद घेणे शिफारसीय आहे. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलाभाबद्दल आम्ही जबाबदार नाही.