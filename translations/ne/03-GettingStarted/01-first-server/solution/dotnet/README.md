<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:55:03+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ne"
}
-->
# यो नमुना चलाउँदै गर्दा

## -1- निर्भरता स्थापना गर्नुहोस्

```bash
dotnet restore
```

## -3- नमुना चलाउनुहोस्

```bash
dotnet run
```

## -4- नमुना परीक्षण गर्नुहोस्

सर्भर एउटा टर्मिनलमा चलिरहेको हुँदा, अर्को टर्मिनल खोल्नुहोस् र तलको आदेश चलाउनुहोस्:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

यसले वेब सर्भर सुरु गर्नेछ जसले दृश्यात्मक इन्टरफेस प्रदान गर्छ र तपाईंलाई नमुना परीक्षण गर्न अनुमति दिन्छ।

सर्भर जडित भएपछि:

- उपकरणहरू सूचीबद्ध गर्न प्रयास गर्नुहोस् र `add` कमाण्ड २ र ४ अर्गुमेन्टका साथ चलाउनुहोस्, नतिजामा ६ देखिनु पर्छ।
- resources र resource template मा जानुहोस् र "greeting" कल गर्नुहोस्, नाम टाइप गर्नुहोस् र तपाईंले दिएको नाम सहितको अभिवादन देख्न सक्नुहुनेछ।

### CLI मोडमा परीक्षण

तपाईं यो सिधै CLI मोडमा तलको आदेश चलाएर सुरु गर्न सक्नुहुन्छ:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरू सूचीबद्ध गर्नेछ। तपाईंले निम्न नतिजा देख्नु पर्नेछ:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

कुनै उपकरण कल गर्न टाइप गर्नुहोस्:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

तपाईंले निम्न नतिजा देख्नु पर्नेछ:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> सामान्यतया ब्राउजर भन्दा CLI मोडमा inspector चलाउनु धेरै छिटो हुन्छ।
> inspector बारे थप पढ्न [यहाँ](https://github.com/modelcontextprotocol/inspector) जानुहोस्।

**अस्वीकरण**:  
यस दस्तावेजलाई AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको प्रयास गर्छौं भने पनि, कृपया जानकार हुनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा नै आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीको लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।