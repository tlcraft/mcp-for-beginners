<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:15:22+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "ne"
}
-->
# यो नमूना चलाउँदै

तपाईंलाई `uv` स्थापना गर्न सिफारिस गरिन्छ तर यो आवश्यक छैन, [निर्देशहरू](https://docs.astral.sh/uv/#highlights) हेर्नुहोस्

## -0- भर्चुअल वातावरण सिर्जना गर्नुहोस्

```bash
python -m venv venv
```

## -1- भर्चुअल वातावरण सक्रिय गर्नुहोस्

```bash
venv\Scrips\activate
```

## -2- आवश्यकताहरू स्थापना गर्नुहोस्

```bash
pip install "mcp[cli]"
```

## -3- नमूना चलाउनुहोस्

```bash
mcp run server.py
```

## -4- नमूनाको परीक्षण गर्नुहोस्

सर्भर एक टर्मिनलमा चलिरहेको छ भने, अर्को टर्मिनल खोल्नुहोस् र निम्न कमाण्ड चलाउनुहोस्:

```bash
mcp dev server.py
```

यसले एक दृश्य इन्टरफेस सहितको वेब सर्भर सुरु गर्नुपर्छ जसले तपाईंलाई नमूनाको परीक्षण गर्न अनुमति दिन्छ।

सर्भर जडान भएपछि:

- उपकरणहरूको सूची प्रयास गर्नुहोस् र `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` यसलाई घेरिएको छ।

तपाईं यसलाई CLI मोडमा सिधै निम्न कमाण्ड चलाएर सुरु गर्न सक्नुहुन्छ:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची दिनेछ। तपाईंले निम्न आउटपुट देख्नुपर्छ:

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

एउटा उपकरण निम्त्याउन टाइप गर्नुहोस्:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> सामान्यतया ब्राउजरमा भन्दा CLI मोडमा इस्पेक्टर चलाउन धेरै छिटो हुन्छ।
> इस्पेक्टरको बारेमा थप पढ्न [यहाँ](https://github.com/modelcontextprotocol/inspector) हेर्नुहोस्।

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको छ। हामी यथार्थताको लागि प्रयास गर्छौं, तर कृपया सचेत रहनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छ। यसको मूल भाषा मा रहेको दस्तावेजलाई आधिकारिक स्रोत मान्नुपर्छ। महत्वपूर्ण जानकारीको लागि, पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार हुनेछैनौं।