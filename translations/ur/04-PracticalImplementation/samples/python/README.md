<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:55:09+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "ur"
}
-->
# نمونہ

یہ ایک MCP سرور کے لیے Python نمونہ ہے۔

یہ ماڈیول یہ دکھاتا ہے کہ ایک بنیادی MCP سرور کیسے نافذ کیا جا سکتا ہے جو تکمیل کی درخواستوں کو سنبھال سکتا ہے۔ یہ مختلف AI ماڈلز کے ساتھ تعامل کی تقلید کرنے والی ایک فرضی عملدرآمد فراہم کرتا ہے۔

یہاں ٹول رجسٹریشن کے عمل کی صورت دکھائی گئی ہے:

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

## انسٹال کریں

مندرجہ ذیل کمانڈ چلائیں:

```bash
pip install mcp
```

## چلائیں

```bash
python mcp_sample.py
```

**ڈس کلیمر**:
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا نقائص ہو سکتے ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں مستند ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لیے، پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والے کسی بھی غلط فہمی یا غلط تشریح کے لیے ہم ذمہ دار نہیں ہیں۔