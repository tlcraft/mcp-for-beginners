<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c40c54fa74ded9c223bc0ebfc8a2de7c",
  "translation_date": "2025-06-18T05:55:16+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "ne"
}
-->
# यो नमूना चलाउनुहोस्

> [!NOTE]
> यो नमूना तपाईं GitHub Codespaces प्रयोग गर्दै हुनुहुन्छ भनी मानिन्छ। यदि तपाईंले यो स्थानीय रूपमा चलाउन चाहनुहुन्छ भने, GitHub मा व्यक्तिगत पहुँच टोकन (PAT) सेटअप गर्नुपर्नेछ।
>
> ```bash
> # zsh/bash
> export GITHUB_TOKEN="{{YOUR_GITHUB_PAT}}"
> ```
>
> ```powershell
> # PowerShell
> $env:GITHUB_TOKEN = "{{YOUR_GITHUB_PAT}}"
> ```

## पुस्तकालयहरू स्थापना गर्नुहोस्

```sh
dotnet restore
```

तलका पुस्तकालयहरू स्थापना गर्नुपर्नेछ: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## चलाउनुहोस्

```sh 
dotnet run
```

तपाईंले निम्न जस्तो आउटपुट देख्नुपर्नेछ:

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

धेरै आउटपुट डिबगिङको लागि हो तर महत्वपूर्ण कुरा यो हो कि तपाईं MCP Server बाट उपकरणहरू सूचीबद्ध गर्दै हुनुहुन्छ, तीलाई LLM उपकरणहरूमा परिवर्तन गर्दै हुनुहुन्छ र अन्ततः MCP क्लाइन्टको प्रतिक्रिया "Sum 6" प्राप्त गर्दै हुनुहुन्छ।

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको प्रयास गर्छौं, तर कृपया जान्नुहोस् कि स्वचालित अनुवादमा त्रुटि वा गलतिहरू हुन सक्छन्। मूल दस्तावेज़ यसको मूल भाषामा आधिकारिक स्रोत मानिनेछ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार हुने छैनौं।