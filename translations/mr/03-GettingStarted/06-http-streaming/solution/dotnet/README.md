<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-07-13T21:03:39+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "mr"
}
-->
# हा नमुना चालविणे

## -1- अवलंबित्वे इंस्टॉल करा

```bash
dotnet restore
```

## -2- नमुना चालवा

```bash
dotnet run
```

## -3- नमुन्याची चाचणी करा

खालील कमांड चालवण्यापूर्वी वेगळा टर्मिनल उघडा (सर्व्हर अजूनही चालू असल्याची खात्री करा).

एका टर्मिनलमध्ये सर्व्हर चालू असताना, दुसरा टर्मिनल उघडा आणि खालील कमांड चालवा:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

यामुळे एक वेब सर्व्हर सुरू होईल ज्यामध्ये एक दृश्यात्मक इंटरफेस असेल ज्याद्वारे तुम्ही नमुन्याची चाचणी करू शकता.

> खात्री करा की **Streamable HTTP** ट्रान्सपोर्ट प्रकार म्हणून निवडलेले आहे, आणि URL `http://localhost:3001/mcp` आहे.

सर्व्हर कनेक्ट झाल्यानंतर:

- tools ची यादी करून `add` चालवून पहा, args 2 आणि 4 सह, तुम्हाला निकालात 6 दिसेल.
- resources आणि resource template मध्ये जा आणि "greeting" कॉल करा, नाव टाका आणि तुम्हाला दिलेल्या नावासह अभिवादन दिसेल.

### CLI मोडमध्ये चाचणी

तुम्ही खालील कमांड चालवून थेट CLI मोडमध्ये सुरू करू शकता:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

यामुळे सर्व्हरमधील उपलब्ध सर्व tools ची यादी दिसेल. तुम्हाला खालील आउटपुट दिसेल:

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

tool invoke करण्यासाठी टाइप करा:

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
> CLI मोडमध्ये inspector चालवणे ब्राउझरच्या तुलनेत सहसा खूप जलद असते.
> inspector बद्दल अधिक वाचा [येथे](https://github.com/modelcontextprotocol/inspector).

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.