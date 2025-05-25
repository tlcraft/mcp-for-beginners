<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:56:02+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "hi"
}
-->
# नमूना

यह MCP सर्वर के लिए एक Python नमूना है।

यह मॉड्यूल दिखाता है कि एक बेसिक MCP सर्वर को कैसे लागू किया जा सकता है जो पूर्णता अनुरोधों को संभाल सकता है। यह विभिन्न AI मॉडलों के साथ बातचीत का अनुकरण करने वाला एक मॉक कार्यान्वयन प्रदान करता है।

यहां उपकरण पंजीकरण प्रक्रिया कैसी दिखती है:

```python
completion_tool = ToolDefinition(
    name="completion",
    description="Generate completions using AI models",
    parameters={
        "model": {
            "type": "string",
            "enum": self.models,
            "description": "The AI model to use for completion"
        },
        "prompt": {
            "type": "string",
            "description": "The prompt text to complete"
        },
        "temperature": {
            "type": "number",
            "description": "Sampling temperature (0.0 to 1.0)"
        },
        "max_tokens": {
            "type": "number",
            "description": "Maximum number of tokens to generate"
        }
    },
    required=["model", "prompt"]
)

# Register the tool with its handler
self.server.tools.register(completion_tool, self._handle_completion)
```

## इंस्टॉल

निम्नलिखित कमांड चलाएं:

```bash
pip install mcp
```

## चलाएं

```bash
python mcp_sample.py
```

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। इसकी मूल भाषा में मूल दस्तावेज़ को आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।