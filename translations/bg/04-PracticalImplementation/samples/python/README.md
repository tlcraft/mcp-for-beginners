<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T15:00:49+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "bg"
}
-->
# Пример

Това е пример на Python за MCP сървър.

Този модул демонстрира как да се имплементира основен MCP сървър, който може да обработва заявки за завършване. Той предоставя примерна имплементация, която симулира взаимодействие с различни AI модели.

Ето как изглежда процесът на регистрация на инструмента:

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

## Инсталиране

Изпълнете следната команда:

```bash
pip install mcp
```

## Стартиране

```bash
python mcp_sample.py
```

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI услуга за превод [Co-op Translator](https://github.com/Azure/co-op-translator). Докато се стремим към точност, моля, имайте предвид, че автоматизираните преводи може да съдържат грешки или неточности. Оригиналният документ на родния му език трябва да се счита за авторитетния източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за недоразумения или неправилни интерпретации, произтичащи от използването на този превод.