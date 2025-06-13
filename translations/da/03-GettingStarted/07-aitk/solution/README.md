<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:32:09+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "da"
}
-->
# 📘 Opgaveløsning: Udvidelse af din Calculator MCP-server med et Kvadratrodsværktøj

## Oversigt
I denne opgave har du udvidet din calculator MCP-server ved at tilføje et nyt værktøj, der beregner kvadratroden af et tal. Denne tilføjelse gør det muligt for din AI-agent at håndtere mere avancerede matematiske forespørgsler, som for eksempel "Hvad er kvadratroden af 16?" eller "Beregn √49" ved hjælp af naturlige sprogkommandoer.

## 🛠️ Implementering af Kvadratrodsværktøjet
For at tilføje denne funktionalitet definerede du en ny værktøjsfunktion i din server.py-fil. Her er implementeringen:

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

## 🔍 Sådan virker det

- **Importer `math.sqrt()`-værktøjet.**
- Gør det muligt for din AI-agent at håndtere kvadratrodsberegninger via naturlige sprogkommandoer.
- Øvede dig i at tilføje nye værktøjer og genstarte serveren for at integrere ekstra funktioner.

Du er velkommen til at eksperimentere videre ved at tilføje flere matematiske værktøjer, såsom potensfunktioner eller logaritmer, for at fortsætte med at forbedre din agents evner!

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.