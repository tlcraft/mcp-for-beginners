<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "69ba3bd502bd743233137bac5539c08b",
  "translation_date": "2025-08-18T15:45:57+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "mr"
}
-->
# हे नमुना चालवणे

`uv` स्थापित करणे शिफारसीय आहे, परंतु ते अनिवार्य नाही. [सूचना](https://docs.astral.sh/uv/#highlights) येथे पहा.

## -0- एक वर्च्युअल वातावरण तयार करा

```bash
python -m venv venv
```

## -1- वर्च्युअल वातावरण सक्रिय करा

```bash
venv\Scrips\activate
```

## -2- आवश्यक गोष्टी स्थापित करा

```bash
pip install "mcp[cli]"
```

## -3- नमुना चालवा

```bash
uvicorn server:app
```

## -4- नमुना चाचणी करा

सर्व्हर एका टर्मिनलमध्ये चालू असताना, दुसरे टर्मिनल उघडा आणि खालील कमांड चालवा:

```bash
mcp dev server.py
```

यामुळे एक वेब सर्व्हर सुरू होईल, ज्यामध्ये तुम्हाला नमुना चाचणी करण्यासाठी व्हिज्युअल इंटरफेस मिळेल.

सर्व्हर कनेक्ट झाल्यावर:

- टूल्सची यादी करण्याचा प्रयत्न करा आणि `add` चालवा, args 2 आणि 4 सह, तुम्हाला निकालात 6 दिसेल.
- संसाधने आणि संसाधन टेम्पलेटला जा आणि `get_greeting` कॉल करा, नाव टाइप करा, आणि तुम्हाला दिलेल्या नावासह अभिवादन दिसेल.

### CLI मोडमध्ये चाचणी करणे

तुम्ही चालवलेला निरीक्षक हा प्रत्यक्षात Node.js अॅप आहे आणि `mcp dev` हा त्याभोवती एक रॅपर आहे.

तुम्ही CLI मोडमध्ये थेट खालील कमांड चालवून तो सुरू करू शकता:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

यामुळे सर्व्हरमध्ये उपलब्ध असलेली सर्व टूल्स सूचीबद्ध होतील. तुम्हाला खालीलप्रमाणे आउटपुट दिसेल:

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

टूल चालवण्यासाठी टाइप करा:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

तुम्हाला खालीलप्रमाणे आउटपुट दिसेल:

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
> CLI मोडमध्ये निरीक्षक चालवणे ब्राउझरपेक्षा सहसा खूप जलद असते.
> निरीक्षकाबद्दल अधिक वाचा [येथे](https://github.com/modelcontextprotocol/inspector).

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये त्रुटी किंवा अचूकतेचा अभाव असू शकतो. मूळ भाषेतील दस्तऐवज हा अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराचा वापर करून उद्भवलेल्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार राहणार नाही.