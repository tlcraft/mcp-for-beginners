<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fae57a69c2b62cb7d92ff12da65f36c3",
  "translation_date": "2025-05-17T10:07:50+00:00",
  "source_file": "03-GettingStarted/02-client/solution/typescript/README.md",
  "language_code": "ne"
}
-->
# यो नमूना चलाउनुहोस्

तपाईंलाई `uv` स्थापना गर्न सिफारिस गरिन्छ तर यो अनिवार्य होइन, [निर्देशहरू](https://docs.astral.sh/uv/#highlights) हेर्नुहोस्

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
Prompt:  {
  type: 'text',
  text: 'Please review this code:\n\nconsole.log("hello");'
}
Resource template:  file
Tool result:  { content: [ { type: 'text', text: '9' } ] }
```

**अस्वीकरण**:  
यो दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको छ। हामी शुद्धताको लागि प्रयास गर्छौं, कृपया सचेत रहनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मातृभाषामा रहेको मूल दस्तावेज़लाई आधिकारिक स्रोत मान्नुपर्छ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।