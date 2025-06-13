<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:33:36+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "ro"
}
-->
# 📘 Soluția temei: Extinderea serverului MCP al calculatorului cu un instrument pentru rădăcina pătrată

## Prezentare generală
În această temă, ai îmbunătățit serverul MCP al calculatorului prin adăugarea unui nou instrument care calculează rădăcina pătrată a unui număr. Această completare îi permite agentului tău AI să gestioneze interogări matematice mai avansate, precum „Care este rădăcina pătrată a lui 16?” sau „Calculează √49,” folosind comenzi în limbaj natural.

## 🛠️ Implementarea instrumentului pentru rădăcina pătrată
Pentru a adăuga această funcționalitate, ai definit o nouă funcție de instrument în fișierul server.py. Iată implementarea:

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

## 🔍 Cum funcționează

- **Importă instrumentul `math.sqrt()` folosind @server.tool() cu numele `sqrt`.**
- Ai permis agentului tău AI să realizeze calcule cu rădăcină pătrată prin comenzi în limbaj natural.
- Ai exersat adăugarea de noi instrumente și repornirea serverului pentru a integra funcționalități suplimentare.

Simte-te liber să experimentezi mai departe, adăugând și alte instrumente matematice, cum ar fi exponentierea sau funcțiile logaritmice, pentru a continua să îmbunătățești capabilitățile agentului tău!

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere automată AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original, în limba sa nativă, trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot rezulta din utilizarea acestei traduceri.