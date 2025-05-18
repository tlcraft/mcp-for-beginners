<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:40:18+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "ne"
}
-->
# यस नमूना चलाउनुहोस्

> [!NOTE]
> यो नमूनाले तपाईंले GitHub Codespaces प्रयोग गरिरहेको मान्छ। यदि तपाईं यसलाई स्थानिय रूपमा चलाउन चाहनुहुन्छ भने, GitHub मा व्यक्तिगत पहुँच टोकन सेट अप गर्न आवश्यक छ।

## लाइब्रेरीहरू स्थापना गर्नुहोस्

```sh
dotnet restore
```

निम्न लाइब्रेरीहरू स्थापना गर्नु पर्छ: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## चलाउनुहोस्

```sh 
dotnet run
```

तपाईंले निम्न जस्तै आउटपुट देख्नु पर्छ:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

धेरै आउटपुट केवल डिबगिङ मात्र हो तर महत्वपूर्ण कुरा यो हो कि तपाईं MCP सर्भरबाट उपकरणहरू सूचीबद्ध गर्दै हुनुहुन्छ, तीलाई LLM उपकरणमा परिणत गर्नुहोस् र तपाईं MCP ग्राहक प्रतिक्रिया "Sum 6" पाउनुहुन्छ।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी यथार्थताको लागि प्रयास गर्छौं, तर कृपया जानकार रहनुहोस् कि स्वचालित अनुवादहरूमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मूल भाषामा रहेको मूल दस्तावेजलाई अधिकारिक स्रोतको रूपमा मान्नुपर्छ। महत्त्वपूर्ण जानकारीको लागि, पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार हुनेछैनौं।