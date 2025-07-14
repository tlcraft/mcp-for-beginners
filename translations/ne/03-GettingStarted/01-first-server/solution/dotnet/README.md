<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-13T17:48:17+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ne"
}
-->
# यो नमुना चलाउने तरिका

## -1- निर्भरता स्थापना गर्नुहोस्

```bash
dotnet restore
```

## -3- नमुना चलाउनुहोस्

```bash
dotnet run
```

## -4- नमुना परीक्षण गर्नुहोस्

सर्भर एक टर्मिनलमा चलिरहेको अवस्थामा, अर्को टर्मिनल खोल्नुहोस् र तलको कमाण्ड चलाउनुहोस्:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

यसले एउटा वेब सर्भर सुरु गर्नेछ जसले भिजुअल इन्टरफेस प्रदान गर्छ र तपाईंलाई नमुना परीक्षण गर्न अनुमति दिन्छ।

सर्भर जडान भएपछि:

- उपकरणहरूको सूची हेर्नुहोस् र `add` चलाउनुहोस्, २ र ४ आर्गुमेन्टसहित, परिणाममा ६ देखिनु पर्छ।
- resources र resource template मा जानुहोस् र "greeting" कल गर्नुहोस्, नाम टाइप गर्नुहोस् र तपाईंले दिएको नामसहितको अभिवादन देख्नु हुनेछ।

### CLI मोडमा परीक्षण

तपाईं सिधै CLI मोडमा यसलाई तलको कमाण्ड चलाएर सुरु गर्न सक्नुहुन्छ:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची देखाउनेछ। तपाईंले तलको आउटपुट देख्नु पर्छ:

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

तपाईंले तलको आउटपुट देख्नु पर्छ:

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
> CLI मोडमा इन्स्पेक्टर चलाउनु ब्राउजरको तुलनामा प्रायः धेरै छिटो हुन्छ।
> इन्स्पेक्टरबारे थप पढ्न [यहाँ](https://github.com/modelcontextprotocol/inspector) जानुहोस्।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।