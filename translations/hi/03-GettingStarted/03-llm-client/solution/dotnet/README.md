<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:39:35+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "hi"
}
-->
# इस नमूने को चलाएं

> [!NOTE]
> यह नमूना मानता है कि आप GitHub Codespaces इंस्टेंस का उपयोग कर रहे हैं। यदि आप इसे स्थानीय रूप से चलाना चाहते हैं, तो आपको GitHub पर एक व्यक्तिगत एक्सेस टोकन सेट करना होगा।

## लाइब्रेरी स्थापित करें

```sh
dotnet restore
```

निम्नलिखित लाइब्रेरी स्थापित करनी चाहिए: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## चलाएं

```sh 
dotnet run
```

आपको एक आउटपुट ऐसा दिखाई देना चाहिए:

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

बहुत सारा आउटपुट सिर्फ डिबगिंग है लेकिन महत्वपूर्ण यह है कि आप MCP सर्वर से टूल्स की सूची बना रहे हैं, उन्हें LLM टूल्स में बदलें और आप MCP क्लाइंट प्रतिक्रिया "Sum 6" के साथ समाप्त होते हैं।

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ को इसकी मूल भाषा में आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।