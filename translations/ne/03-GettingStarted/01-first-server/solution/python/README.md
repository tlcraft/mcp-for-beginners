<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d26f746e21775c30b4d7ed97962b24df",
  "translation_date": "2025-08-18T16:13:08+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "ne"
}
-->
# यो नमूना चलाउनुहोस्

तपाईंलाई `uv` इन्स्टल गर्न सिफारिस गरिन्छ, तर यो अनिवार्य छैन। [निर्देशनहरू](https://docs.astral.sh/uv/#highlights) हेर्नुहोस्।

## -0- भर्चुअल वातावरण बनाउनुहोस्

```bash
python -m venv venv
```

## -1- भर्चुअल वातावरण सक्रिय गर्नुहोस्

```bash
venv\Scripts\activate
```

## -2- आवश्यक निर्भरता इन्स्टल गर्नुहोस्

```bash
pip install "mcp[cli]"
```

## -3- नमूना चलाउनुहोस्

```bash
mcp run server.py
```

## -4- नमूनाको परीक्षण गर्नुहोस्

सर्भर एक टर्मिनलमा चलिरहेको अवस्थामा, अर्को टर्मिनल खोल्नुहोस् र निम्न आदेश चलाउनुहोस्:

```bash
mcp dev server.py
```

यसले भिजुअल इन्टरफेस भएको वेब सर्भर सुरु गर्नेछ, जसले तपाईंलाई नमूनाको परीक्षण गर्न अनुमति दिनेछ।

सर्भर जडान भएपछि:

- उपकरणहरूको सूची हेर्नुहोस् र `add` चलाउनुहोस्, 2 र 4 लाई तर्कको रूपमा प्रयोग गर्नुहोस्। परिणाममा तपाईंले 6 देख्नुहुनेछ।

- स्रोतहरू र स्रोत टेम्प्लेटमा जानुहोस् र `get_greeting` कल गर्नुहोस्। कुनै नाम टाइप गर्नुहोस्, र तपाईंले दिएको नामसहितको अभिवादन देख्नुहुनेछ।

### CLI मोडमा परीक्षण गर्नुहोस्

तपाईंले चलाएको इन्स्पेक्टर वास्तवमा Node.js एप हो, र `mcp dev` यसको वरिपरि एक आवरण हो।

तपाईं यसलाई CLI मोडमा सिधै निम्न आदेश चलाएर सुरु गर्न सक्नुहुन्छ:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची देखाउनेछ। तपाईंले निम्न आउटपुट देख्नुहुनेछ:

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

उपकरण चलाउन टाइप गर्नुहोस्:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

तपाईंले निम्न आउटपुट देख्नुहुनेछ:

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
> ब्राउजरमा भन्दा CLI मोडमा इन्स्पेक्टर चलाउनु सामान्यतया धेरै छिटो हुन्छ।
> इन्स्पेक्टरबारे थप पढ्न [यहाँ](https://github.com/modelcontextprotocol/inspector) जानुहोस्।

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको छ। हामी शुद्धताको लागि प्रयास गर्छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छ। यसको मूल भाषा मा रहेको मूल दस्तावेज़लाई आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार हुने छैनौं।