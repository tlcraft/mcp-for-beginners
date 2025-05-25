<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:08:41+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "mr"
}
-->
# या नमुन्याचा वापर करणे

## -1- अवलंबित्वे स्थापित करा

```bash
npm install
```

## -3- नमुना चालवा

```bash
npm run build
```

## -4- नमुना चाचणी करा

सर्व्हर एका टर्मिनलमध्ये चालू असताना, दुसरे टर्मिनल उघडा आणि खालील कमांड चालवा:

```bash
npm run inspector
```

हे एक वेब सर्व्हर सुरू करेल ज्यामध्ये नमुन्याची चाचणी करण्यासाठी एक दृश्य इंटरफेस उपलब्ध असेल.

एकदा सर्व्हर कनेक्ट झाल्यावर:

- साधने सूचीबद्ध करण्याचा प्रयत्न करा आणि `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build` चालवा.

- एका स्वतंत्र टर्मिनलमध्ये खालील कमांड चालवा:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    हे सर्व्हरमध्ये उपलब्ध असलेल्या सर्व साधनांची यादी करेल. तुम्ही खालील आउटपुट पाहावे:

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

- साधन प्रकाराला कॉल करण्यासाठी खालील कमांड टाइप करा:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

तुम्ही खालील आउटपुट पाहावे:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> CLI मोडमध्ये निरीक्षक चालवणे ब्राउझरपेक्षा सहसा खूप जलद असते.
> निरीक्षकाबद्दल अधिक वाचा [येथे](https://github.com/modelcontextprotocol/inspector).

**अस्वीकरण**:  
हा दस्तऐवज एआय अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये त्रुटी किंवा अचूकतेचा अभाव असू शकतो. मूळ भाषेतील दस्तऐवज हा अधिकृत स्रोत मानला जावा. अत्यावश्यक माहितीसाठी, व्यावसायिक मानवी अनुवादाची शिफारस केली जाते. या अनुवादाच्या वापरातून उद्भवलेल्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.