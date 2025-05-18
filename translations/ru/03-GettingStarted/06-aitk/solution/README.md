<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:32:02+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "ru"
}
-->
# 📘 Решение задачи: Расширение вашего MCP сервера калькулятора с помощью инструмента квадратного корня

## Обзор
В этом задании вы улучшили свой MCP сервер калькулятора, добавив новый инструмент, который вычисляет квадратный корень числа. Это дополнение позволяет вашему AI агенту обрабатывать более сложные математические запросы, такие как "Какой квадратный корень из 16?" или "Вычислите √49," используя подсказки на естественном языке.

## 🛠️ Реализация инструмента квадратного корня
Чтобы добавить эту функциональность, вы определили новую функцию инструмента в вашем файле server.py. Вот реализация:

```python
"""
Sample MCP Calculator Server implementation in Python.

This module demonstrates how to create a simple MCP server with calculator tools
that can perform basic arithmetic operations (add, subtract, multiply, divide).
"""

from mcp.server.fastmcp import FastMCP
import math

server = FastMCP("calculator")

@server.tool()
def add(a: float, b: float) -> float:
    """Add two numbers together and return the result."""
    return a + b

@server.tool()
def subtract(a: float, b: float) -> float:
    """Subtract b from a and return the result."""
    return a - b

@server.tool()
def multiply(a: float, b: float) -> float:
    """Multiply two numbers together and return the result."""
    return a * b

@server.tool()
def divide(a: float, b: float) -> float:
    """
    Divide a by b and return the result.
    
    Raises:
        ValueError: If b is zero
    """
    if b == 0:
        raise ValueError("Cannot divide by zero")
    return a / b

@server.tool()
def sqrt(a: float) -> float:
    """
    Return the square root of a.

    Raises:
        ValueError: If a is negative.
    """
    if a < 0:
        raise ValueError("Cannot compute the square root of a negative number.")
    return math.sqrt(a)
```

## 🔍 Как это работает

- **Импортируйте инструмент `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
- **Function Definition**: The `@server.tool()` decorator registers the `sqrt` function as a tool accessible by your AI agent.
- **Input Parameter**: The function accepts a single argument `a` of type `float`.
- **Error Handling**: If `a` is negative, the function raises a `ValueError` to prevent computing the square root of a negative number, which is not supported by the `math.sqrt()` function.
- **Return Value**: For non-negative inputs, the function returns the square root of `a` using Python's built-in `math.sqrt()` method.

## 🔄 Restarting the Server
After adding the new `sqrt` tool, it's essential to restart your MCP server to ensure the agent recognizes and can utilize the newly added functionality.

## 💬 Example Prompts to Test the New Tool
Here are some natural language prompts you can use to test the square root functionality:

- "What is the square root of 25?"
- "Calculate the square root of 81."
- "Find the square root of 0."
- "What is the square root of 2.25?"

These prompts should trigger the agent to invoke the `sqrt` tool and return the correct results.

## ✅ Summary
By completing this assignment, you've:

- Extended your calculator MCP server with a new `sqrt`.
- Позволяет вашему AI агенту обрабатывать вычисления квадратного корня через подсказки на естественном языке.
- Практиковались в добавлении новых инструментов и перезапуске сервера для интеграции дополнительных функций.

Не стесняйтесь экспериментировать дальше, добавляя больше математических инструментов, таких как возведение в степень или логарифмические функции, чтобы продолжать улучшать возможности вашего агента!

**Отказ от ответственности**:  
Этот документ был переведен с помощью службы машинного перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Мы стремимся к точности, однако, пожалуйста, учитывайте, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его родном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за недоразумения или неверные интерпретации, возникшие в результате использования данного перевода.