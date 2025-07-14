<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:04:44+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "ne"
}
-->
# यो नमुना चलाउने तरिका

`uv` इन्स्टल गर्न सिफारिस गरिन्छ तर अनिवार्य छैन, हेर्नुहोस् [निर्देशनहरू](https://docs.astral.sh/uv/#highlights)

## -1- निर्भरता इन्स्टल गर्नुहोस्

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

यसले वेब सर्भर सुरु गर्नेछ जसमा भिजुअल इन्टरफेस हुनेछ र तपाईंले नमुना परीक्षण गर्न सक्नुहुनेछ।

सर्भर जडान भएपछि:

- उपकरणहरूको सूची हेर्न प्रयास गर्नुहोस् र `add` चलाउनुहोस्, २ र ४ आर्गुमेन्टसहित, परिणाममा ६ देखिनु पर्छ।
- resources र resource template मा जानुहोस् र "greeting" कल गर्नुहोस्, नाम टाइप गर्नुहोस् र तपाईंले दिएको नामसहितको अभिवादन देख्नु हुनेछ।

### CLI मोडमा परीक्षण

तपाईंले चलाएको inspector वास्तवमा Node.js एप हो र `mcp dev` यसको वरिपरि बनेको wrapper हो।

तपाईं यसलाई सिधै CLI मोडमा तलको कमाण्ड चलाएर सुरु गर्न सक्नुहुन्छ:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची देखाउनेछ। तपाईंले तलको आउटपुट देख्नु पर्छ:

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

कुनै उपकरण चलाउन टाइप गर्नुहोस्:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

तपाईंले तलको आउटपुट देख्नु पर्छ:

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
> सामान्यतया inspector लाई CLI मोडमा ब्राउजर भन्दा धेरै छिटो चलाउन सकिन्छ।
> inspector बारे थप पढ्न [यहाँ](https://github.com/modelcontextprotocol/inspector) जानुहोस्।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।