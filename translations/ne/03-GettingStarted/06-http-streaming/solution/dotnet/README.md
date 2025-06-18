<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:16:58+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
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

तलको कमाण्ड चलाउनुभन्दा पहिले अर्को टर्मिनल खोल्नुहोस् (सुनिश्चित गर्नुहोस् सर्भर अझै चलिरहेको छ)।

एक टर्मिनलमा सर्भर चलिरहेको बेला, अर्को टर्मिनल खोल्नुहोस् र निम्न कमाण्ड चलाउनुहोस्:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

यसले वेब सर्भर सुरु गर्नेछ जसले भिजुअल इन्टरफेसमार्फत नमुनाको परीक्षण गर्न सकिन्छ।

> सुनिश्चित गर्नुहोस् कि **Streamable HTTP** ट्रान्सपोर्ट प्रकार चयन गरिएको छ, र URL `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add` छ, २ र ४ आर्गुमेन्टसहित, तपाईंले परिणाममा ६ देख्नु पर्नेछ।
- resources र resource template मा जानुहोस् र "greeting" कल गर्नुहोस्, नाम टाइप गर्नुहोस् र तपाईंले दिएको नामसहितको अभिवादन देख्नु पर्नेछ।

### CLI मोडमा परीक्षण

तपाईं यसलाई सिधै CLI मोडमा निम्न कमाण्ड चलाएर सुरु गर्न सक्नुहुन्छ:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची देखाउनेछ। तपाईंले निम्न आउटपुट देख्नु पर्नेछ:

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

कुनै उपकरण चलाउनका लागि टाइप गर्नुहोस्:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

तपाईंले निम्न आउटपुट देख्नु पर्नेछ:

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
> ब्राउजरमा भन्दा CLI मोडमा ispector चलाउनु सामान्यतया धेरै छिटो हुन्छ।
> ispector बारे थप पढ्न [यहाँ](https://github.com/modelcontextprotocol/inspector) जानुहोस्।

**अस्वीकरण**:  
यो दस्तावेज़ [Co-op Translator](https://github.com/Azure/co-op-translator) नामक एआई अनुवाद सेवाको प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा गलतफहमी हुन सक्छ। मूल दस्तावेज आफ्नो मूल भाषामा नै अधिकारिक स्रोत मानिनेछ। महत्वपूर्ण जानकारीका लागि पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।