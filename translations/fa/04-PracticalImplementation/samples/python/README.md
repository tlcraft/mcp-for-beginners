<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:55:03+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "fa"
}
-->
# نمونه

این یک نمونه پایتون برای یک سرور MCP است.

این ماژول نشان می‌دهد چگونه یک سرور پایه MCP را پیاده‌سازی کنید که قادر به مدیریت درخواست‌های تکمیل باشد. این یک پیاده‌سازی شبیه‌سازی‌شده ارائه می‌دهد که تعامل با مدل‌های مختلف هوش مصنوعی را شبیه‌سازی می‌کند.

فرآیند ثبت ابزار به این صورت است:

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

## نصب

دستور زیر را اجرا کنید:

```bash
pip install mcp
```

## اجرا

```bash
python mcp_sample.py
```

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً آگاه باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه انسانی حرفه‌ای توصیه می‌شود. ما مسئولیتی در قبال هرگونه سوء تفاهم یا تفسیر نادرست ناشی از استفاده از این ترجمه نداریم.