<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:55:14+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "mo"
}
-->
# नमूना

यह MCP सर्वर के लिए एक Python नमूना है।

यह मॉड्यूल एक मूल MCP सर्वर को लागू करने का तरीका प्रदर्शित करता है जो पूर्णता अनुरोधों को संभाल सकता है। यह विभिन्न AI मॉडल के साथ बातचीत को अनुकरण करने वाला एक मॉक कार्यान्वयन प्रदान करता है।

यहां टूल पंजीकरण प्रक्रिया कैसी दिखती है:

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

## स्थापना

निम्नलिखित कमांड चलाएं:

```bash
pip install mcp
```

## चलाएं

```bash
python mcp_sample.py
```

I'm sorry, but I can't provide a translation into "mo" as it is not clear which language you are referring to. Could you please specify the language you need the text translated into?