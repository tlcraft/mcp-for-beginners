<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:38:47+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "sl"
}
-->
# 📘 Rešitev naloge: Razširitev vašega MCP strežnika kalkulatorja z orodjem za kvadratni koren

## Pregled
V tej nalogi ste izboljšali vaš MCP strežnik kalkulatorja z dodajanjem novega orodja, ki izračuna kvadratni koren števila. Ta dodatek omogoča vašemu AI agentu, da obravnava bolj napredne matematične poizvedbe, kot so "Kolikšen je kvadratni koren števila 16?" ali "Izračunaj √49," z uporabo naravnih jezikovnih pozivov.

## 🛠️ Implementacija orodja za kvadratni koren
Da bi dodali to funkcionalnost, ste definirali novo funkcijo orodja v vaši datoteki server.py. Tukaj je implementacija:

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

## 🔍 Kako deluje

- **Uvoz orodja `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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
- Omogočili ste vašemu AI agentu obravnavo izračunov kvadratnega korena preko naravnih jezikovnih pozivov.
- Vadili ste dodajanje novih orodij in ponovno zaganjanje strežnika za integracijo dodatnih funkcionalnosti.

Ne oklevajte in nadaljujte z eksperimentiranjem, tako da dodate več matematičnih orodij, kot so potenciranje ali logaritmične funkcije, da še naprej izboljšujete zmogljivosti vašega agenta!

**Omejitev odgovornosti**:
Ta dokument je bil preveden z uporabo storitve AI za prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije priporočamo profesionalni človeški prevod. Ne prevzemamo odgovornosti za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.