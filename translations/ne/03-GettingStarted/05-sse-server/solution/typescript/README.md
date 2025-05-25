<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:08:53+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "ne"
}
-->
# यो नमूना चलाउनुहोस्

## -1- निर्भरता स्थापना गर्नुहोस्

```bash
npm install
```

## -3- नमूना चलाउनुहोस्

```bash
npm run build
```

## -4- नमूना परीक्षण गर्नुहोस्

सर्भर एक टर्मिनलमा चलिरहेको अवस्थामा, अर्को टर्मिनल खोल्नुहोस् र तलको आदेश चलाउनुहोस्:

```bash
npm run inspector
```

यसले दृश्य अन्तरफेसको साथ वेब सर्भर सुरु गर्नु पर्छ जसले तपाईंलाई नमूना परीक्षण गर्न अनुमति दिन्छ।

सर्भर जडान भएपछि:

- उपकरणहरूको सूची बनाउने प्रयास गर्नुहोस् र `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build` चलाउनुहोस्।

- छुट्टै टर्मिनलमा तलको आदेश चलाउनुहोस्:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची बनाउनेछ। तपाईंले निम्न आउटपुट देख्नु पर्छ:

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

- उपकरण प्रकारलाई निम्न आदेश टाइप गरेर बोलाउनुहोस्:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

तपाईंले निम्न आउटपुट देख्नु पर्छ:

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
> सामान्यतया ब्राउजरको भन्दा CLI मोडमा इस्पेक्टर चलाउनु धेरै छिटो हुन्छ।
> इस्पेक्टरको बारेमा थप पढ्नुहोस् [यहाँ](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादहरूमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मूल भाषामा रहेको मूल दस्तावेजलाई प्राधिकृत स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीको लागि, पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी उत्तरदायी हुनेछैनौं।