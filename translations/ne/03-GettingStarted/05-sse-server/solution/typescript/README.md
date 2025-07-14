<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:19:43+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "ne"
}
-->
# यो नमुना चलाउने तरिका

## -1- निर्भरता स्थापना गर्नुहोस्

```bash
npm install
```

## -3- नमुना चलाउनुहोस्

```bash
npm run build
```

## -4- नमुना परीक्षण गर्नुहोस्

सर्भर एक टर्मिनलमा चलिरहेको अवस्थामा, अर्को टर्मिनल खोल्नुहोस् र तलको कमाण्ड चलाउनुहोस्:

```bash
npm run inspector
```

यसले एउटा वेब सर्भर सुरु गर्नेछ जसले भिजुअल इन्टरफेस मार्फत नमुना परीक्षण गर्न अनुमति दिन्छ।

सर्भर जडान भएपछि:

- उपकरणहरूको सूची हेर्नुहोस् र `add` कमाण्ड २ र ४ आर्गुमेन्टसहित चलाउनुहोस्, परिणाममा ६ देखिनु पर्छ।
- resources र resource template मा जानुहोस् र "greeting" कल गर्नुहोस्, नाम टाइप गर्नुहोस् र तपाईंले दिएको नामसहितको अभिवादन देख्नु हुनेछ।

### CLI मोडमा परीक्षण

तपाईंले चलाएको inspector वास्तवमा Node.js एप हो र `mcp dev` यसको वरिपरि बनेको wrapper हो।

- सर्भर सुरु गर्न `npm run build` कमाण्ड चलाउनुहोस्।

- अर्को टर्मिनलमा तलको कमाण्ड चलाउनुहोस्:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची देखाउनेछ। तपाईंले तलको आउटपुट देख्नु पर्नेछ:

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

- उपकरण प्रकार invoke गर्न तलको कमाण्ड टाइप गर्नुहोस्:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

तपाईंले तलको आउटपुट देख्नु पर्नेछ:

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
> CLI मोडमा inspector चलाउनु ब्राउजरमा भन्दा सामान्यतया धेरै छिटो हुन्छ।
> inspector को बारेमा थप पढ्न [यहाँ](https://github.com/modelcontextprotocol/inspector) जानुहोस्।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।