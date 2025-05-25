<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:22:21+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "mr"
}
-->
# हे नमुना चालवणे

तुम्हाला `uv` स्थापित करण्याची शिफारस केली जाते, परंतु ते आवश्यक नाही, [सूचना](https://docs.astral.sh/uv/#highlights) पहा

## -1- अवलंबित्व स्थापित करा

```bash
npm install
```

## -3- नमुना चालवा

```bash
npm run build
```

## -4- नमुना तपासा

सर्व्हर एका टर्मिनलमध्ये चालू असताना, दुसरे टर्मिनल उघडा आणि खालील आदेश चालवा:

```bash
npm run inspector
```

हे एक वेब सर्व्हर सुरू करेल ज्यामध्ये तुम्हाला नमुना तपासण्यासाठी एक दृश्य इंटरफेस मिळेल.

सर्व्हर कनेक्ट झाल्यावर:

- साधनांची यादी करण्याचा प्रयत्न करा आणि `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` हे त्यावर एक आवरण आहे.

तुम्ही CLI मोडमध्ये थेट खालील आदेश चालवून ते सुरू करू शकता:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

हे सर्व्हरमध्ये उपलब्ध असलेली सर्व साधने सूचीबद्ध करेल. तुम्हाला खालील आउटपुट दिसायला हवे:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

एखादे साधन चालवण्यासाठी टाइप करा:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> ब्राउझरपेक्षा CLI मोडमध्ये निरीक्षक चालवणे सहसा खूप जलद असते.
> निरीक्षकाबद्दल अधिक वाचा [येथे](https://github.com/modelcontextprotocol/inspector).

**अस्वीकृती**:  
हे दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केले गेले आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित भाषांतरांमध्ये त्रुटी किंवा अचूकतेचा अभाव असू शकतो. मूळ भाषेतील मूळ दस्तऐवज अधिकृत स्रोत मानला जावा. महत्त्वपूर्ण माहितीसाठी, व्यावसायिक मानव भाषांतराची शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थ लावण्यास आम्ही जबाबदार नाही.