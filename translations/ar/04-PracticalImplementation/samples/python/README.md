<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:54:58+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "ar"
}
-->
# نموذج

هذا مثال بايثون لخادم MCP.

يوضح هذا النموذج كيفية تنفيذ خادم MCP أساسي يمكنه التعامل مع طلبات الإكمال. يوفر تنفيذًا وهميًا يحاكي التفاعل مع نماذج الذكاء الاصطناعي المختلفة.

إليك كيف تبدو عملية تسجيل الأداة:

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

## التثبيت

قم بتشغيل الأمر التالي:

```bash
pip install mcp
```

## التشغيل

```bash
python mcp_sample.py
```

**إخلاء مسؤولية**: 
تم ترجمة هذه الوثيقة باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى للدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار الوثيقة الأصلية بلغتها الأصلية المصدر الموثوق. بالنسبة للمعلومات الحساسة، يوصى بالترجمة البشرية الاحترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ناتج عن استخدام هذه الترجمة.