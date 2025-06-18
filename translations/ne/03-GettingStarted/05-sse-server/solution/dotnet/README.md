<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:55:09+00:00",
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

## -3- नमुनाको परीक्षण गर्नुहोस्

तलको कमाण्ड चलाउनु अघि अर्को टर्मिनल खोल्नुहोस् (सुनिश्चित गर्नुहोस् कि सर्भर अझै चलिरहेको छ)।

एक टर्मिनलमा सर्भर चलिरहेको अवस्थामा, अर्को टर्मिनल खोल्नुहोस् र तलको कमाण्ड चलाउनुहोस्:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

यसले वेब सर्भर सुरु गर्नेछ जसले दृश्यात्मक इन्टरफेस मार्फत नमुनाको परीक्षण गर्न सकिन्छ।

> सुनिश्चित गर्नुहोस् कि **SSE** ट्रान्सपोर्ट प्रकारको रूपमा चयन गरिएको छ, र URL `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add` छ, २ र ४ आर्गुमेन्टसहित, परिणाममा ६ देखिनु पर्नेछ।
- resources र resource template मा जानुहोस् र "greeting" कल गर्नुहोस्, नाम टाइप गर्नुहोस् र तपाईंले दिएको नाम सहितको अभिवादन देख्नुहुनेछ।

### CLI मोडमा परीक्षण

तपाईं यसलाई सिधै CLI मोडमा तलको कमाण्ड चलाएर सुरु गर्न सक्नुहुन्छ:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरू देखाउनेछ। तपाईंले तलको आउटपुट देख्नु पर्नेछ:

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

उपकरण चलाउन टाइप गर्नुहोस्:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

तपाईंले तलको आउटपुट देख्नु पर्नेछ:

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
> प्रायः ब्राउजरको तुलनामा CLI मोडमा ispector चलाउनु धेरै छिटो हुन्छ।
> inspector बारे थप पढ्न [यहाँ](https://github.com/modelcontextprotocol/inspector) जानुहोस्।

**अस्वीकरण**:  
यस दस्तावेजलाई AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको प्रयास गर्छौं भने पनि, कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारप्राप्त स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीको लागि पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।