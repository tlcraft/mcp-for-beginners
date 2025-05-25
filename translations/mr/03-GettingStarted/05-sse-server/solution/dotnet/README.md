<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:54:32+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "mr"
}
-->
# हे नमुना चालवित आहे

## -1- आवश्यक गोष्टी स्थापित करा

```bash
dotnet run
```

## -2- नमुना चालवा

```bash
dotnet run
```

## -3- नमुना चाचणी करा

खालील चालवण्यापूर्वी एक वेगळे टर्मिनल सुरू करा (सुनिश्चित करा की सर्व्हर चालू आहे).

एका टर्मिनलमध्ये सर्व्हर चालू असताना, दुसरे टर्मिनल उघडा आणि खालील कमांड चालवा:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

हे एक वेब सर्व्हर सुरू करेल ज्यामध्ये एक दृश्य इंटरफेस असेल, ज्यामुळे तुम्हाला नमुना चाचणी करता येईल.

सर्व्हर जोडला गेल्यावर:

- साधने सूचीबद्ध करण्याचा प्रयत्न करा आणि `add` चालवा, args 2 आणि 4 सह, तुम्हाला निकालात 6 दिसायला हवे.
- संसाधने आणि संसाधन टेम्पलेटला जा आणि "greeting" कॉल करा, नाव टाइप करा आणि तुम्हाला दिलेले नाव असलेले अभिवादन दिसेल.

### CLI मोडमध्ये चाचणी करणे

तुम्ही खालील कमांड चालवून थेट CLI मोडमध्ये लॉन्च करू शकता:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

हे सर्व्हरमध्ये उपलब्ध असलेल्या सर्व साधनांची यादी करेल. तुम्हाला खालील आउटपुट दिसायला हवे:

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

साधन सुरू करण्यासाठी टाइप करा:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

तुम्हाला खालील आउटपुट दिसायला हवे:

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
> CLI मोडमध्ये निरीक्षक चालवणे ब्राउझरपेक्षा सहसा खूप वेगवान असते.
> निरीक्षकाबद्दल अधिक वाचा [इथे](https://github.com/modelcontextprotocol/inspector).

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरे त्रुटी किंवा अचूकतेच्या अभावासह असू शकतात. मूळ भाषेतील दस्तऐवज अधिकृत स्रोत मानला पाहिजे. महत्त्वपूर्ण माहितीसाठी, व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.