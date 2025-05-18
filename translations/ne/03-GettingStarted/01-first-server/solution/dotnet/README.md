<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:08:12+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ne"
}
-->
# यो नमुना चलाउने

## -1- आवश्यकताहरू स्थापना गर्नुहोस्

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- नमुना चलाउनुहोस्

```bash
dotnet run
```

## -4- नमुना परीक्षण गर्नुहोस्

एक टर्मिनलमा सर्भर चलिरहेको अवस्थामा, अर्को टर्मिनल खोल्नुहोस् र तलको आदेश चलाउनुहोस्:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

यसले भिजुअल इन्टरफेससहितको वेब सर्भर सुरू गर्नुपर्छ जसले तपाईंलाई नमुना परीक्षण गर्न अनुमति दिन्छ।

सर्भर जडान भएपछि:

- उपकरणहरू सूचीबद्ध गर्ने प्रयास गर्नुहोस् र `add` चलाउनुहोस्, २ र ४ को तर्कसहित, तपाईंले नतिजामा ६ देख्नु पर्नेछ।
- स्रोतहरू र स्रोत टेम्प्लेटमा जानुहोस् र "greeting" कल गर्नुहोस्, नाम टाइप गर्नुहोस् र तपाईंले दिएको नामसहितको अभिवादन देख्नु पर्नेछ।

### CLI मोडमा परीक्षण

तपाईं तलको आदेश चलाएर यसलाई सिधै CLI मोडमा सुरू गर्न सक्नुहुन्छ:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची दिनेछ। तपाईंले तलको नतिजा देख्नु पर्नेछ:

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

एउटा उपकरण चलाउन टाइप गर्नुहोस्:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

तपाईंले तलको नतिजा देख्नु पर्नेछ:

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
> ब्राउजरको तुलनामा CLI मोडमा निरीक्षक चलाउनु सामान्यतया धेरै छिटो हुन्छ।
> निरीक्षकको बारेमा [यहाँ](https://github.com/modelcontextprotocol/inspector) थप पढ्नुहोस्।

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको छ। हामी शुद्धताको लागि प्रयास गर्छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मौलिक भाषामा रहेको दस्तावेज़लाई आधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीको लागि, पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्या प्रति हामी जिम्मेवार छैनौं।