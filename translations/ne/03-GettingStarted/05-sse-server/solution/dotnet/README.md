<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:54:48+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ne"
}
-->
# यो नमूना चलाउनुहोस्

## -1- आवश्यकताहरू स्थापना गर्नुहोस्

```bash
dotnet run
```

## -2- नमूना चलाउनुहोस्

```bash
dotnet run
```

## -3- नमूनाको परीक्षण गर्नुहोस्

तलको चलाउनु अघि छुट्टै टर्मिनल सुरू गर्नुहोस् (निश्चित गर्नुहोस् कि सर्भर अझै चलिरहेको छ)।

सर्भर एक टर्मिनलमा चलिरहेको छ भने, अर्को टर्मिनल खोल्नुहोस् र निम्न आदेश चलाउनुहोस्:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

यसले भिजुअल इन्टरफेस सहितको वेब सर्भर सुरू गर्नु पर्छ जसले तपाईंलाई नमूनाको परीक्षण गर्न अनुमति दिन्छ।

एक पटक सर्भर जडान भएपछि:

- उपकरणहरूको सूची बनाउने प्रयास गर्नुहोस् र `add` चलाउनुहोस्, २ र ४ को आर्गसका साथ, तपाईंले परिणाममा ६ देख्नु पर्छ।
- स्रोतहरू र स्रोत टेम्पलेटमा जानुहोस् र "greeting" कल गर्नुहोस्, नाम टाइप गर्नुहोस् र तपाईंले तपाईंले दिएको नामसहितको अभिवादन देख्नु पर्छ।

### CLI मोडमा परीक्षण

तपाईं निम्न आदेश चलाएर CLI मोडमा प्रत्यक्ष रूपमा यसलाई सुरू गर्न सक्नुहुन्छ:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

यसले सर्भरमा उपलब्ध सबै उपकरणहरूको सूची देखाउनेछ। तपाईंले निम्न आउटपुट देख्नु पर्छ:

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

उपकरणलाई कल गर्न टाइप गर्नुहोस्:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> सामान्यतया CLI मोडमा इन्स्पेक्टर चलाउनु ब्राउजरमा भन्दा धेरै छिटो हुन्छ।
> इन्स्पेक्टरको बारेमा थप पढ्नुहोस् [यहाँ](https://github.com/modelcontextprotocol/inspector)।

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको हो। हामी यथासम्भव शुद्धताको प्रयास गर्छौं, तर कृपया सचेत रहनुहोस् कि स्वचालित अनुवादहरूमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मूल भाषामा रहेको दस्तावेजलाई नै आधिकारिक स्रोत मान्नुपर्छ। महत्वपूर्ण जानकारीको लागि, पेशेवर मानव अनुवादको सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार हुनेछैनौं।