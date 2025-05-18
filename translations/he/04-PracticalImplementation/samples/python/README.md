<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:59:03+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "he"
}
-->
# דוגמה

זוהי דוגמת פייתון לשרת MCP.

מודול זה מדגים כיצד ליישם שרת MCP בסיסי שיכול לטפל בבקשות להשלמה. הוא מספק יישום דמה שמדמה אינטראקציה עם דגמי AI שונים.

כך נראה תהליך רישום הכלי:

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

## התקנה

הרץ את הפקודה הבאה:

```bash
pip install mcp
```

## הרצה

```bash
python mcp_sample.py
```

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד אנו שואפים לדיוק, אנא היו מודעים לכך שתרגומים אוטומטיים עשויים להכיל טעויות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור הסמכותי. למידע קריטי, מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא אחראים לכל אי הבנות או פרשנויות מוטעות הנובעות מהשימוש בתרגום זה.