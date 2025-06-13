<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:30:32+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "en"
}
-->
# 📘 Assignment Solution: Extending Your Calculator MCP Server with a Square Root Tool

## Overview
In this assignment, you improved your calculator MCP server by adding a new tool that calculates the square root of a number. This enhancement enables your AI agent to handle more complex math queries like "What is the square root of 16?" or "Calculate √49," using natural language commands.

## 🛠️ Implementing the Square Root Tool
To add this feature, you created a new tool function in your server.py file. Here's the implementation:

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

- **Import the `math` module** and use `math.sqrt()` within the `@server.tool()` decorated `sqrt` function.
- Allowed your AI agent to perform square root calculations through natural language prompts.
- Practiced adding new tools and restarting the server to incorporate additional functionalities.

Feel free to continue experimenting by adding more math tools, such as exponentiation or logarithmic functions, to further expand your agent's capabilities!

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.