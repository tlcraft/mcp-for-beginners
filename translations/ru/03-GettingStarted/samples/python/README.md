<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb55f3119d45c4412fc5555299e60498",
  "translation_date": "2025-05-17T13:26:59+00:00",
  "source_file": "03-GettingStarted/samples/python/README.md",
  "language_code": "ru"
}
-->
# Пример

Это пример на Python для сервера MCP

Вот как выглядит часть калькулятора:

```python
@mcp.tool()
def add(a: float, b: float) -> float:
    """Add two numbers together and return the result."""
    return a + b

@mcp.tool()
def subtract(a: float, b: float) -> float:
    """Subtract b from a and return the result."""
    return a - b

@mcp.tool()
def multiply(a: float, b: float) -> float:
    """Multiply two numbers together and return the result."""
    return a * b

@mcp.tool()
def divide(a: float, b: float) -> float:
    """
    Divide a by b and return the result.
    
    Raises:
        ValueError: If b is zero
    """
    if b == 0:
        raise ValueError("Cannot divide by zero")
    return a / b
```

## Установка

Выполните следующую команду:

```bash
pip install mcp
```

## Запуск

```bash
python mcp_calculator_server.py
```

**Отказ от ответственности**:  
Этот документ был переведен с помощью службы автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Хотя мы стремимся к точности, пожалуйста, учитывайте, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его родном языке должен рассматриваться как авторитетный источник. Для получения важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недопонимания или неправильные толкования, возникающие в результате использования этого перевода.