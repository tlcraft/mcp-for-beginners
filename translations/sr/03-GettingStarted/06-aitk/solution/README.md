<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:38:28+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "sr"
}
-->
# 📘 Rešenje zadatka: Proširenje vašeg MCP servera kalkulatora sa alatom za kvadratni koren

## Pregled
U ovom zadatku ste unapredili svoj MCP server kalkulatora dodavanjem novog alata koji izračunava kvadratni koren broja. Ovo proširenje omogućava vašem AI agentu da obrađuje složenije matematičke upite, kao što su "Koliki je kvadratni koren od 16?" ili "Izračunaj √49," koristeći prirodni jezik.

## 🛠️ Implementacija alata za kvadratni koren
Da biste dodali ovu funkcionalnost, definisali ste novu funkciju alata u vašem server.py fajlu. Evo implementacije:

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

## 🔍 Kako funkcioniše

- **Importujte `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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

- Extended your calculator MCP server with a new `sqrt` alat.
- Omogućili ste vašem AI agentu da obrađuje izračunavanje kvadratnog korena putem upita u prirodnom jeziku.
- Vežbali ste dodavanje novih alata i ponovno pokretanje servera kako biste integrisali dodatne funkcionalnosti.

Slobodno nastavite da eksperimentišete dodavanjem još matematičkih alata, kao što su potenciranje ili logaritamske funkcije, kako biste nastavili sa unapređenjem sposobnosti vašeg agenta!

**Одрицање од одговорности**:  
Овај документ је преведен користећи услугу за превођење помоћу вештачке интелигенције [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да будемо прецизни, молимо вас да будете свесни да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати меродавним извором. За критичне информације, препоручује се професионални људски превод. Не сносимо одговорност за било каква неразумевања или погрешна тумачења настала употребом овог превода.