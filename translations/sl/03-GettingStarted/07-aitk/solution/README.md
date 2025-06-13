<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:34:05+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "sl"
}
-->
# 📘 Rješenje zadatka: Proširenje MCP servera kalkulatora s alatom za kvadratni korijen

## Pregled
U ovom zadatku ste unaprijedili svoj MCP server kalkulatora dodavanjem novog alata koji računa kvadratni korijen broja. Ova nadogradnja omogućuje vašem AI agentu da rješava složenije matematičke upite, poput "Koliki je kvadratni korijen od 16?" ili "Izračunaj √49," koristeći prirodni jezik.

## 🛠️ Implementacija alata za kvadratni korijen
Da biste dodali ovu funkcionalnost, definirali ste novu funkciju alata u datoteci server.py. Evo implementacije:

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

## 🔍 Kako to radi

- **Uvezite `math` modul i koristite `math.sqrt()` funkciju u alatu označenom s `@server.tool()` pod imenom `sqrt` koji prima parametar `a` tipa `float` i obrađuje eventualne `ValueError` iznimke pri pozivu `math.sqrt(a)`.**
- Omogućili ste svom AI agentu da obrađuje izračune kvadratnog korijena putem upita na prirodnom jeziku.
- Vježbali ste dodavanje novih alata i ponovno pokretanje servera kako biste integrirali dodatne funkcionalnosti.

Slobodno nastavite s eksperimentiranjem dodavanjem još matematičkih alata, poput potenciranja ili logaritamskih funkcija, kako biste dodatno unaprijedili sposobnosti svog agenta!

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvorno jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.