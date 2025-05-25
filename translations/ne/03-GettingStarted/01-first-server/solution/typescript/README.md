<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:22:34+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "ne"
}
-->
# यो नमूना चलाउनुहोस्

तपाईंलाई `uv` स्थापना गर्न सिफारिस गरिन्छ तर यो अनिवार्य छैन, [निर्देशहरू](https://docs.astral.sh/uv/#highlights) हेर्नुहोस्

## -1- निर्भरताहरू स्थापना गर्नुहोस्

```bash
npm install
```

## -3- नमूना चलाउनुहोस्

```bash
npm run build
```

## -4- नमूना परीक्षण गर्नुहोस्

सर्भर एक टर्मिनलमा चलिरहेको हुँदा, अर्को टर्मिनल खोल्नुहोस् र निम्न आदेश चलाउनुहोस्:

```bash
npm run inspector
```

यसले एक वेब सर्भर सुरु गर्नु पर्छ जसले तपाईंलाई नमूना परीक्षण गर्नको लागि दृश्य इन्टरफेस प्रदान गर्दछ।

सर्भर जडान भएपछि:

- उपकरणहरूको सूची गर्ने प्रयास गर्नुहोस् र `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` यसको वरिपरि एक आवरण हो।

तपाईं यसलाई CLI मोडमा सिधै निम्न आदेश चलाएर सुरु गर्न सक्नुहुन्छ:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची दिनेछ। तपाईंले निम्न आउटपुट देख्नु पर्छ:

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

कुनै उपकरणलाई बोलाउन टाइप गर्नुहोस्:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

तपाईंले निम्न आउटपुट देख्नु पर्छ:

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
> सामान्यतया ब्राउजरमा भन्दा CLI मोडमा निरीक्षक चलाउनु धेरै छिटो हुन्छ।
> निरीक्षकको बारेमा थप पढ्नुहोस् [यहाँ](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको हो। हामी यथासम्भव शुद्धताको लागि प्रयास गर्छौं, तर कृपया सचेत रहनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा असमानताहरू हुन सक्छन्। यसको मूल भाषा मा रहेको मूल दस्तावेजलाई प्राधिकृत स्रोतको रूपमा मान्नुपर्छ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार हुनेछैनौं।