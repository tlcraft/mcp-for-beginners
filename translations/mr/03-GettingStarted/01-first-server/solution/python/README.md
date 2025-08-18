<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d26f746e21775c30b4d7ed97962b24df",
  "translation_date": "2025-08-18T15:43:53+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "mr"
}
-->
# हे नमुना चालवणे

`uv` स्थापित करणे शिफारस केले जाते, पण ते आवश्यक नाही. अधिक माहितीसाठी [सूचना](https://docs.astral.sh/uv/#highlights) पहा.

## -0- एक वर्चुअल वातावरण तयार करा

```bash
python -m venv venv
```

## -1- वर्चुअल वातावरण सक्रिय करा

```bash
venv\Scripts\activate
```

## -2- आवश्यक गोष्टी स्थापित करा

```bash
pip install "mcp[cli]"
```

## -3- नमुना चालवा

```bash
mcp run server.py
```

## -4- नमुना चाचणी करा

सर्व्हर एका टर्मिनलमध्ये चालू असताना, दुसरे टर्मिनल उघडा आणि खालील कमांड चालवा:

```bash
mcp dev server.py
```

यामुळे एक वेब सर्व्हर सुरू होईल ज्यामध्ये तुम्हाला नमुना चाचणी करण्यासाठी एक दृश्य इंटरफेस मिळेल.

सर्व्हर कनेक्ट झाल्यावर:

- टूल्सची यादी करण्याचा प्रयत्न करा आणि `add` चालवा, args 2 आणि 4 सह, तुम्हाला निकालामध्ये 6 दिसेल.

- Resources आणि Resource Template वर जा आणि get_greeting कॉल करा, एक नाव टाइप करा आणि तुम्हाला दिलेल्या नावासह एक अभिवादन दिसेल.

### CLI मोडमध्ये चाचणी करणे

तुम्ही चालवलेला Inspector हा प्रत्यक्षात एक Node.js अॅप आहे आणि `mcp dev` हा त्याभोवती एक wrapper आहे.

CLI मोडमध्ये थेट लॉन्च करण्यासाठी खालील कमांड चालवा:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

यामुळे सर्व्हरमध्ये उपलब्ध असलेल्या सर्व टूल्सची यादी दिसेल. तुम्हाला खालील आउटपुट दिसेल:

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

टूल invoke करण्यासाठी टाइप करा:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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

> [!TIP]  
> CLI मोडमध्ये Inspector चालवणे ब्राउझरपेक्षा सहसा खूप जलद असते.  
> Inspector बद्दल अधिक वाचा [येथे](https://github.com/modelcontextprotocol/inspector).  

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरे त्रुटी किंवा अचूकतेच्या अभावाने युक्त असू शकतात. मूळ भाषेतील दस्तऐवज हा अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराचा वापर करून उद्भवलेल्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.