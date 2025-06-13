<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:32:29+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "nl"
}
-->
# 📘 Oplossing Opdracht: Je Calculator MCP Server Uitbreiden met een Worteltrekker Tool

## Overzicht  
In deze opdracht heb je je calculator MCP-server uitgebreid met een nieuwe tool die de vierkantswortel van een getal berekent. Hierdoor kan je AI-agent complexere wiskundige vragen aan, zoals "Wat is de vierkantswortel van 16?" of "Bereken √49," met behulp van natuurlijke taal prompts.

## 🛠️ De Worteltrekker Tool Implementeren  
Om deze functionaliteit toe te voegen, heb je een nieuwe tool-functie gedefinieerd in je server.py bestand. Dit is de implementatie:

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

- **Importeer de `math.sqrt()` tool.  
- Je AI-agent kan nu vierkantswortel berekeningen uitvoeren via natuurlijke taal prompts.  
- Je hebt geoefend met het toevoegen van nieuwe tools en het herstarten van de server om extra functionaliteiten te integreren.

Voel je vrij om verder te experimenteren door meer wiskundige tools toe te voegen, zoals machtsverheffen of logaritmische functies, om de mogelijkheden van je agent verder uit te breiden!

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor belangrijke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.