<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-27T16:24:51+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "cs"
}
-->
# 📘 Assignment Solution: Extending Your Calculator MCP Server with a Square Root Tool

## Overview
In this assignment, you expanded your calculator MCP server by adding a new tool that computes the square root of a number. This upgrade enables your AI agent to process more complex math queries, like "What is the square root of 16?" or "Calculate √49," using natural language prompts.

## 🛠️ Implementing the Square Root Tool
To implement this feature, you created a new tool function in your server.py file. Here's the code:

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

- **Import the `math` module** and use `math.sqrt()` inside a `@server.tool()` decorated function named `sqrt` that takes a float `a` as input and returns the square root, handling `ValueError` exceptions.
- Enabled your AI agent to process square root calculations through natural language prompts.
- Practiced adding new tools and restarting the server to integrate additional features.

Feel free to keep experimenting by adding more math tools, like exponentiation or logarithms, to further improve your agent's abilities!

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vzniklé použitím tohoto překladu.