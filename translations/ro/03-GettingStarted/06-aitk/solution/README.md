<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:38:04+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "ro"
}
-->
# 📘 Soluție Temă: Extinderea Serverului MCP Calculator cu un Instrument de Rădăcină Pătrată

## Prezentare Generală
În această temă, ai îmbunătățit serverul tău MCP calculator prin adăugarea unui nou instrument care calculează rădăcina pătrată a unui număr. Această adiție permite agentului tău AI să gestioneze interogări matematice mai avansate, precum "Care este rădăcina pătrată a lui 16?" sau "Calculează √49," folosind sugestii în limbaj natural.

## 🛠️ Implementarea Instrumentului de Rădăcină Pătrată
Pentru a adăuga această funcționalitate, ai definit o nouă funcție instrument în fișierul tău server.py. Iată implementarea:

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

## 🔍 Cum Funcționează

- **Importă instrumentul `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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
- Ai permis agentului tău AI să gestioneze calcule de rădăcină pătrată prin sugestii în limbaj natural.
- Ai exersat adăugarea de noi instrumente și repornirea serverului pentru a integra funcționalități suplimentare.

Simte-te liber să experimentezi în continuare prin adăugarea mai multor instrumente matematice, precum funcții de exponențiere sau logaritmice, pentru a continua să îmbunătățești capacitățile agentului tău!

**Declinare:**

Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem responsabili pentru neînțelegeri sau interpretări greșite care decurg din utilizarea acestei traduceri.