<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:36:13+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "nl"
}
-->
# 📘 Oplossing van de Opdracht: Je Rekenmachine MCP Server Uitbreiden met een Worteltool

## Overzicht
In deze opdracht heb je je rekenmachine MCP server verbeterd door een nieuwe tool toe te voegen die de wortel van een getal berekent. Deze toevoeging stelt je AI-agent in staat om meer geavanceerde wiskundige vragen te behandelen, zoals "Wat is de wortel van 16?" of "Bereken √49," met behulp van natuurlijke taal prompts.

## 🛠️ Implementatie van de Worteltool
Om deze functionaliteit toe te voegen, heb je een nieuwe toolfunctie gedefinieerd in je server.py bestand. Hier is de implementatie:

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

## 🔍 Hoe Het Werkt

- **Importeer de `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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

- Extended your calculator MCP server with a new `sqrt` tool.
- Je AI-agent in staat gesteld om wortelberekeningen te verwerken via natuurlijke taal prompts.
- Geoefend met het toevoegen van nieuwe tools en het herstarten van de server om extra functionaliteiten te integreren.

Voel je vrij om verder te experimenteren door meer wiskundige tools toe te voegen, zoals machtsverheffing of logaritmische functies, om de mogelijkheden van je agent verder uit te breiden!

**Disclaimer**:  
Dit document is vertaald met behulp van AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons inzetten voor nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of misinterpretaties die voortvloeien uit het gebruik van deze vertaling.