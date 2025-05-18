<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:56:19+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "ne"
}
-->
# नमूना

यो एक MCP सर्भरको लागि Python नमूना हो।

यो मोड्युलले कसरी आधारभूत MCP सर्भर कार्यान्वयन गर्ने भनेर देखाउँछ जसले पूरा गर्ने अनुरोधहरू ह्यान्डल गर्न सक्छ। यसले विभिन्न AI मोडेलहरूसँग अन्तरक्रिया गर्ने नक्कली कार्यान्वयन प्रदान गर्दछ।

उपकरण दर्ता प्रक्रिया यसरी देखिन्छ:

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

## स्थापना गर्नुहोस्

निम्न आदेश चलाउनुहोस्:

```bash
pip install mcp
```

## चलाउनुहोस्

```bash
python mcp_sample.py
```

**अस्वीकरण**: 
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको छ। हामी शुद्धताको लागि प्रयास गर्छौं, कृपया सचेत रहनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मूल भाषामा रहेको दस्तावेजलाई आधिकारिक स्रोत मानिनुपर्छ। महत्त्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार हुनेछैनौं।