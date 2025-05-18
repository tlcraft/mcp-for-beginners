<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:54:41+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "ru"
}
-->
# Пример

Это пример на Python для сервера MCP.

Этот модуль демонстрирует, как реализовать базовый сервер MCP, который может обрабатывать запросы на завершение. Он предоставляет примерную реализацию, которая симулирует взаимодействие с различными моделями ИИ.

Вот как выглядит процесс регистрации инструмента:

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

## Установка

Выполните следующую команду:

```bash
pip install mcp
```

## Запуск

```bash
python mcp_sample.py
```

**Отказ от ответственности**:  
Этот документ был переведен с помощью службы автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Мы стремимся к точности, но, пожалуйста, учитывайте, что автоматизированные переводы могут содержать ошибки или неточности. Оригинальный документ на его родном языке должен считаться авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования этого перевода.