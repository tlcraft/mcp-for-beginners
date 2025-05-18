<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:56:13+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "mr"
}
-->
# नमुना

हा MCP सर्व्हरसाठी एक Python नमुना आहे.

हा मॉड्यूल कसे साधारण MCP सर्व्हर तयार करायचे ते दाखवतो जे पूर्णता विनंत्या हाताळू शकते. हे विविध AI मॉडेल्ससोबत संवाद साधण्याचे अनुकरण करणारी एक बनावट अंमलबजावणी प्रदान करते.

उपकरण नोंदणी प्रक्रिया कशी दिसते ते येथे आहे:

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

## स्थापित करा

खालील आदेश चालवा:

```bash
pip install mcp
```

## चालवा

```bash
python mcp_sample.py
```

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, कृपया लक्षात घ्या की स्वयंचलित भाषांतरात त्रुटी किंवा अचूकतेचा अभाव असू शकतो. मूळ भाषेतील मूळ दस्तऐवज अधिकृत स्रोत म्हणून विचारात घेतला पाहिजे. महत्त्वपूर्ण माहितीच्या बाबतीत, व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराचा वापर करून उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.