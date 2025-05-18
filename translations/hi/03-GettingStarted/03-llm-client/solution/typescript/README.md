<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:53:50+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "hi"
}
-->
# इस नमूने को चलाना

इस नमूने में क्लाइंट पर एक LLM होना शामिल है। LLM को आपको इसे Codespaces में चलाने या GitHub में व्यक्तिगत एक्सेस टोकन सेट अप करने की आवश्यकता होती है।

## -1- निर्भरता स्थापित करें

```bash
npm install
```

## -3- सर्वर चलाएँ

```bash
npm run build
```

## -4- क्लाइंट चलाएँ

```sh
npm run client
```

आपको एक परिणाम दिखाई देना चाहिए जो इस तरह से हो:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल भाषा में मूल दस्तावेज़ को प्राधिकृत स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम उत्तरदायी नहीं हैं।