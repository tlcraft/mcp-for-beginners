<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:33:14+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "hu"
}
-->
# 📘 Feladatmegoldás: A számológép MCP szerverének bővítése négyzetgyök eszközzel

## Áttekintés
Ebben a feladatban bővítetted a számológép MCP szerveredet egy új eszközzel, amely egy szám négyzetgyökét számolja ki. Ez a kiegészítés lehetővé teszi, hogy az AI ügynököd összetettebb matematikai kérdéseket is kezeljen, például „Mi 16 négyzetgyöke?” vagy „Számold ki √49” természetes nyelvű utasítások alapján.

## 🛠️ A négyzetgyök eszköz megvalósítása
Ehhez a funkcióhoz egy új eszközfüggvényt definiáltál a server.py fájlban. Íme a megvalósítás:

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

## 🔍 Működés

- **Importáld a `math` modult, majd használd a `math.sqrt()` függvényt a `@server.tool()` dekorátorral ellátott `sqrt` eszköz definiálásához.**
- Lehetővé tetted, hogy az AI ügynököd természetes nyelvű utasítások alapján is tudjon négyzetgyököt számolni.
- Gyakoroltad új eszközök hozzáadását és a szerver újraindítását, hogy integráld a további funkciókat.

Nyugodtan kísérletezz tovább további matematikai eszközök hozzáadásával, például hatványozással vagy logaritmikus függvényekkel, hogy még tovább fejleszd az ügynök képességeit!

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) használatával fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvű változata tekintendő hivatalos forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ezen fordítás használatából eredő félreértésekért vagy helytelen értelmezésekért.