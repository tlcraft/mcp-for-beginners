<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:33:58+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "hr"
}
-->
# 📘 Rješenje zadatka: Proširenje vašeg Calculator MCP servera s alatom za izračunavanje kvadratnog korijena

## Pregled
U ovom zadatku ste unaprijedili svoj Calculator MCP server dodavanjem novog alata koji računa kvadratni korijen broja. Ova nadogradnja omogućuje vašem AI agentu da rješava složenije matematičke upite, poput "Koliki je kvadratni korijen od 16?" ili "Izračunaj √49," koristeći prirodni jezik.

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

- **Uvezite alat `math.sqrt()` pomoću `@server.tool()` dekoratora.**
- Omogućili ste svom AI agentu da obrađuje izračune kvadratnog korijena putem prirodnih jezičnih upita.
- Vježbali ste dodavanje novih alata i ponovno pokretanje servera kako biste integrirali dodatne funkcionalnosti.

Slobodno nastavite eksperimentirati dodavanjem još matematičkih alata, poput potenciranja ili logaritamskih funkcija, kako biste dodatno unaprijedili mogućnosti vašeg agenta!

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.