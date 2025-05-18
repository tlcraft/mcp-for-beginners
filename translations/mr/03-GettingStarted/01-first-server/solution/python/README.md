<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:15:13+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "mr"
}
-->
# हे नमुना चालवणे

तुम्हाला `uv` स्थापित करणे सुचवले जाते, परंतु ते आवश्यक नाही, [सूचना](https://docs.astral.sh/uv/#highlights) पहा

## -0- एक वर्चुअल वातावरण तयार करा

```bash
python -m venv venv
```

## -1- वर्चुअल वातावरण सक्रिय करा

```bash
venv\Scrips\activate
```

## -2- अवलंबन स्थापित करा

```bash
pip install "mcp[cli]"
```

## -3- नमुना चालवा

```bash
mcp run server.py
```

## -4- नमुना तपासा

सर्व्हर एका टर्मिनलमध्ये चालू असताना, दुसरे टर्मिनल उघडा आणि खालील आदेश चालवा:

```bash
mcp dev server.py
```

हे एक व्हिज्युअल इंटरफेससह वेब सर्व्हर सुरू करेल, ज्यामुळे तुम्हाला नमुना तपासता येईल.

एकदा सर्व्हर कनेक्ट झाल्यावर:

- साधनांची यादी करण्याचा प्रयत्न करा आणि `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` हे त्याचे आवरण आहे.

तुम्ही खालील आदेश चालवून CLI मोडमध्ये थेट ते सुरू करू शकता:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
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

एखादे साधन वापरण्यासाठी टाइप करा:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> ब्राउझरपेक्षा CLI मोडमध्ये ispector चालवणे सहसा खूप जलद असते.
> निरीक्षकाबद्दल अधिक वाचा [येथे](https://github.com/modelcontextprotocol/inspector).

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये त्रुटी किंवा अपूर्णता असू शकतात. मूळ भाषेतील दस्तऐवज हा अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी, व्यावसायिक मानवी अनुवादाची शिफारस केली जाते. या अनुवादाचा वापर करून उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थ लावण्यास आम्ही जबाबदार नाही.