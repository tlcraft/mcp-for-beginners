<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:01:49+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "ne"
}
-->
# यो नमूना चलाउनुहोस्

तपाईंलाई `uv` स्थापना गर्न सिफारिस गरिन्छ तर यो अनिवार्य छैन, [निर्देशनहरू](https://docs.astral.sh/uv/#highlights) हेर्नुहोस्

## -0- भर्चुअल वातावरण बनाउनुहोस्

```bash
python -m venv venv
```

## -1- भर्चुअल वातावरण सक्रिय गर्नुहोस्

```bash
venv\Scrips\activate
```

## -2- निर्भरता स्थापना गर्नुहोस्

```bash
pip install "mcp[cli]"
```

## -3- नमूना चलाउनुहोस्

```bash
mcp run server.py
```

## -4- नमूना परीक्षण गर्नुहोस्

सर्भर एक टर्मिनलमा चलिरहेको हुँदा, अर्को टर्मिनल खोल्नुहोस् र निम्न आदेश चलाउनुहोस्:

```bash
mcp dev server.py
```

यसले दृश्य इन्टरफेससहितको वेब सर्भर सुरु गर्नु पर्छ जसले तपाईंलाई नमूना परीक्षण गर्न अनुमति दिन्छ।

एकपटक सर्भर जडान भएपछि:

- उपकरणहरूको सूची बनाउने प्रयास गर्नुहोस् र `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` यसको वरिपरि आवरण हो।

तपाईं निम्न आदेश चलाएर यसलाई CLI मोडमा सिधै सुरु गर्न सक्नुहुन्छ:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची बनाउनेछ। तपाईंले निम्न आउटपुट देख्नुपर्छ:

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

एउटा उपकरण चलाउन टाइप गर्नुहोस्:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

तपाईंले निम्न आउटपुट देख्नुपर्छ:

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
> ब्राउजरको तुलनामा CLI मोडमा निरीक्षक चलाउनु सामान्यतया धेरै छिटो हुन्छ।
> निरीक्षकको बारेमा थप पढ्नुहोस् [यहाँ](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको छ। हामी शुद्धताको लागि प्रयास गर्छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादहरूमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छ। यसको मातृभाषामा रहेको मूल दस्तावेजलाई आधिकारिक स्रोत मान्नुपर्छ। महत्वपूर्ण जानकारीको लागि, पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार हुनेछैनौं।