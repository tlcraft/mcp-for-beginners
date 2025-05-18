<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:01:42+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "mr"
}
-->
# हे नमुना चालवणे

आपल्याला `uv` स्थापित करणे सुचवले जाते, परंतु ते आवश्यक नाही, [सूचना](https://docs.astral.sh/uv/#highlights) पहा

## -0- एक आभासी वातावरण तयार करा

```bash
python -m venv venv
```

## -1- आभासी वातावरण सक्रिय करा

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

एक टर्मिनलमध्ये सर्व्हर चालू ठेवून, दुसरे टर्मिनल उघडा आणि खालील आदेश चालवा:

```bash
mcp dev server.py
```

यामुळे एक वेब सर्व्हर सुरू होईल ज्यामध्ये दृश्य इंटरफेस असेल जो तुम्हाला नमुना तपासण्यास अनुमती देईल.

एकदा सर्व्हर कनेक्ट झाल्यानंतर:

- साधने सूचीबद्ध करण्याचा प्रयत्न करा आणि `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` त्याचा एक आवरण आहे.

तुम्ही खालील आदेश चालवून CLI मोडमध्ये थेट लॉन्च करू शकता:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

यामुळे सर्व्हरमध्ये उपलब्ध असलेल्या सर्व साधनांची सूची तयार होईल. तुम्हाला खालील आउटपुट दिसेल:

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

साधनास आमंत्रित करण्यासाठी टाइप करा:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> ब्राउझरपेक्षा CLI मोडमध्ये निरीक्षक चालवणे सहसा खूप जलद असते.
> निरीक्षकाबद्दल अधिक वाचा [येथे](https://github.com/modelcontextprotocol/inspector).

**अस्वीकृति**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, परंतु कृपया लक्षात ठेवा की स्वयंचलित भाषांतरे त्रुटी किंवा अचूकतेच्या कमतरता असू शकतात. मूळ भाषेतील दस्तऐवज हा अधिकृत स्रोत मानला पाहिजे. अत्यावश्यक माहितीसाठी, व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थ लावल्यास आम्ही जबाबदार नाही.