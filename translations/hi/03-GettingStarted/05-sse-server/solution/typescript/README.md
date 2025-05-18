<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:08:20+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "hi"
}
-->
# इस नमूने को चलाना

## -1- आवश्यकताएं स्थापित करें

```bash
npm install
```

## -3- नमूना चलाएं

```bash
npm run build
```

## -4- नमूना परीक्षण करें

जब सर्वर एक टर्मिनल में चल रहा हो, तो दूसरा टर्मिनल खोलें और निम्नलिखित कमांड चलाएं:

```bash
npm run inspector
```

यह एक वेब सर्वर शुरू करना चाहिए जिसमें एक दृश्य इंटरफ़ेस होगा जो आपको नमूने का परीक्षण करने की अनुमति देगा।

एक बार सर्वर कनेक्ट हो जाने पर:

- टूल्स की सूची बनाने का प्रयास करें और `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build` चलाएं।

- एक अलग टर्मिनल में निम्नलिखित कमांड चलाएं:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    यह सर्वर में उपलब्ध सभी टूल्स की सूची बनाएगा। आपको निम्नलिखित आउटपुट दिखाई देना चाहिए:

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

- टूल प्रकार को निम्नलिखित कमांड टाइप करके बुलाएं:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

आपको निम्नलिखित आउटपुट दिखाई देना चाहिए:

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
> आमतौर पर ब्राउज़र की तुलना में CLI मोड में इंस्पेक्टर चलाना बहुत तेज होता है।
> इंस्पेक्टर के बारे में अधिक पढ़ें [यहां](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ को इसकी मूल भाषा में आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।