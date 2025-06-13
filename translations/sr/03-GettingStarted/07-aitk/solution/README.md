<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:33:49+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "sr"
}
-->
# 📘 Rešenje zadatka: Proširenje vašeg Calculator MCP servera alatkom za kvadratni koren

## Pregled
U ovom zadatku ste unapredili vaš Calculator MCP server dodavanjem nove alatke koja izračunava kvadratni koren broja. Ova dopuna omogućava vašem AI agentu da obrađuje složenije matematičke upite, kao što su "Koliki je kvadratni koren od 16?" ili "Izračunaj √49," koristeći prirodni jezik.

## 🛠️ Implementacija alatke za kvadratni koren
Da biste dodali ovu funkcionalnost, definisali ste novu alatku u fajlu server.py. Evo implementacije:

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

## 🔍 Kako to funkcioniše

- **Uvozite `math` modul i koristite `math.sqrt()` funkciju unutar `@server.tool()` dekoratora za alatku `sqrt`.**
- Omogućili ste vašem AI agentu da obrađuje izračunavanja kvadratnog korena putem prirodnog jezika.
- Vežbali ste dodavanje novih alatki i restartovanje servera kako biste integrisali dodatne funkcionalnosti.

Slobodno nastavite sa eksperimentisanjem dodavanjem još matematičkih alatki, kao što su potenciranje ili logaritamske funkcije, kako biste dodatno unapredili mogućnosti vašeg agenta!

**Ограничење одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетом. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала коришћењем овог превода.