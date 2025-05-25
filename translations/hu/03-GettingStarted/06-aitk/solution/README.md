<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:37:30+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "hu"
}
-->
# 📘 Feladatmegoldás: Számológép MCP szerver kiterjesztése négyzetgyök eszközzel

## Áttekintés
Ebben a feladatban kiegészítetted a számológép MCP szerveredet egy új eszközzel, amely kiszámítja egy szám négyzetgyökét. Ez a kiegészítés lehetővé teszi, hogy AI ügynököd bonyolultabb matematikai kérdéseket is kezeljen, mint például "Mennyi a 16 négyzetgyöke?" vagy "Számítsd ki a √49-et," természetes nyelvi utasítások segítségével.

## 🛠️ A négyzetgyök eszköz megvalósítása
Ennek a funkciónak a hozzáadásához egy új eszközfüggvényt definiáltál a server.py fájlodban. Íme a megvalósítás:

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

## 🔍 Hogyan működik

- **Importáld a `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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

- Extended your calculator MCP server with a new `sqrt` eszközt.
- Engedélyezd az AI ügynököd számára a négyzetgyök számítások kezelését természetes nyelvi utasítások segítségével.
- Gyakorold új eszközök hozzáadását és a szerver újraindítását, hogy további funkciókat integrálj.

Nyugodtan kísérletezz tovább, és adj hozzá több matematikai eszközt, például hatványozást vagy logaritmikus függvényeket, hogy tovább növeld ügynököd képességeit!

**Jogi nyilatkozat**:  
Ez a dokumentum AI fordítási szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével lett lefordítva. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelven tekintendő hiteles forrásnak. Fontos információk esetén javasolt a professzionális emberi fordítás. Nem vállalunk felelősséget semmilyen félreértésért vagy félreértelmezésért, amely a fordítás használatából ered.