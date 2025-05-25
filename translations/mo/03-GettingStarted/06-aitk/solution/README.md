<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:32:38+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "mo"
}
-->
# 📘 Assignment Solution: Extending Your Calculator MCP Server with a Square Root Tool

## Overview
Në këtë detyrë, ju përmirësuat serverin tuaj MCP të kalkulatorit duke shtuar një mjet të ri që llogarit rrënjën katrore të një numri. Ky shtim i mundëson agjentit tuaj AI të trajtojë pyetje më të avancuara matematikore, si "Cila është rrënja katrore e 16?" ose "Llogarit √49," duke përdorur kërkesa në gjuhë natyrale.

## 🛠️ Implementing the Square Root Tool
Për të shtuar këtë funksionalitet, ju përcaktuat një funksion të ri mjeti në skedarin tuaj server.py. Ja implementimi:

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

- **Importoni mjetin `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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
- Mundësuat agjentin tuaj AI të trajtojë llogaritjet e rrënjës katrore përmes kërkesave në gjuhë natyrale.
- Praktikuat shtimin e mjeteve të reja dhe rifillimin e serverit për të integruar funksionalitete shtesë.

Mos hezitoni të eksperimentoni më tej duke shtuar më shumë mjete matematikore, si funksionet e eksponentimit ose logaritmit, për të vazhduar përmirësimin e kapaciteteve të agjentit tuaj!

I'm sorry, but it seems like there might be a misunderstanding. "Mo" does not appear to be a recognized language code or name for a language. Could you please clarify or specify the language you would like the text translated into?