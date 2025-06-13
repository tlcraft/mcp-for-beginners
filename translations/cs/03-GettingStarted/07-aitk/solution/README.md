<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:33:21+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "cs"
}
-->
# 📘 Assignment Solution: Extending Your Calculator MCP Server with a Square Root Tool

## Overview
In this assignment, you improved your calculator MCP server by adding a new tool that computes the square root of a number. This upgrade enables your AI agent to respond to more complex math queries, like "What is the square root of 16?" or "Calculate √49," using natural language commands.

## 🛠️ Implementing the Square Root Tool
To implement this feature, you created a new tool function in your server.py file. Here's how it looks:

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

## 🔍 How It Works

- **Import the `math` module** and use `math.sqrt()` inside a function decorated with `@server.tool()`.
- This function, named `sqrt`, accepts a parameter `a` of type `float`.
- It handles invalid inputs by raising a `ValueError` if necessary.
- The `sqrt` function returns the square root of `a` using `math.sqrt()`.
- Registering this function as a tool allows your AI agent to perform square root calculations through natural language prompts.
- This exercise gave you practice adding new tools and restarting the server to integrate new features.

Feel free to continue experimenting by adding more mathematical tools, like exponentiation or logarithms, to further expand your agent’s abilities!

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.