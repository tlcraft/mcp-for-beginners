<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:54:37+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "ne"
}
-->
# यस नमूनालाई चलाउँदै

यस नमूनाले क्लाइन्टमा LLM हुनु आवश्यक छ। LLM लाई तपाईंले या त यसलाई Codespaces मा चलाउनु पर्नेछ वा तपाईंले GitHub मा व्यक्तिगत पहुँच टोकन सेटअप गर्नुपर्नेछ।

## -1- निर्भरता स्थापना गर्नुहोस्

```bash
npm install
```

## -3- सर्भर चलाउनुहोस्

```bash
npm run build
```

## -4- क्लाइन्ट चलाउनुहोस्

```sh
npm run client
```

तपाईंले निम्न जस्तै परिणाम देख्नु पर्छ:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको हो। हामी यथार्थताको लागि प्रयास गरिरहेका छौं, कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादहरूमा त्रुटिहरू वा असत्यताहरू हुन सक्छन्। यसको मूल भाषामा रहेको दस्तावेज़लाई आधिकारिक स्रोत मानिनु पर्दछ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।