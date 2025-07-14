<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-07-13T20:09:20+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ne"
}
-->
# यो नमुना चलाउने तरिका

## -1- निर्भरता स्थापना गर्नुहोस्

```bash
dotnet restore
```

## -2- नमुना चलाउनुहोस्

```bash
dotnet run
```

## -3- नमुना परीक्षण गर्नुहोस्

तलको कमाण्ड चलाउनु अघि अर्को टर्मिनल खोल्नुहोस् (सुनिश्चित गर्नुहोस् कि सर्भर अझै चलिरहेको छ)।

एक टर्मिनलमा सर्भर चलिरहेको अवस्थामा, अर्को टर्मिनल खोल्नुहोस् र तलको कमाण्ड चलाउनुहोस्:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

यसले एउटा वेब सर्भर सुरु गर्नेछ जसले भिजुअल इन्टरफेस मार्फत नमुना परीक्षण गर्न अनुमति दिन्छ।

> सुनिश्चित गर्नुहोस् कि **SSE** ट्रान्सपोर्ट प्रकारको रूपमा चयन गरिएको छ, र URL `http://localhost:3001/sse` छ।

सर्भर जडान भएपछि:

- उपकरणहरूको सूची हेर्न प्रयास गर्नुहोस् र `add` कमाण्ड चलाउनुहोस्, २ र ४ आर्गुमेन्टसहित, परिणाममा ६ देखिनु पर्छ।
- resources र resource template मा जानुहोस् र "greeting" कल गर्नुहोस्, नाम टाइप गर्नुहोस् र तपाईंले दिएको नामसहितको अभिवादन देख्नु पर्छ।

### CLI मोडमा परीक्षण

तपाईं सिधै CLI मोडमा यसलाई तलको कमाण्ड चलाएर सुरु गर्न सक्नुहुन्छ:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची देखाउनेछ। तपाईंले तलको आउटपुट देख्नु पर्छ:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
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
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> सामान्यतया ब्राउजरको तुलनामा CLI मोडमा inspector चलाउनु धेरै छिटो हुन्छ।
> inspector को बारेमा थप पढ्न [यहाँ](https://github.com/modelcontextprotocol/inspector) जानुहोस्।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।