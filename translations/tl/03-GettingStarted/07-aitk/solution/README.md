<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:33:00+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "tl"
}
-->
# 📘 Solusyon sa Takdang-Aralin: Pinalalawak ang Iyong Calculator MCP Server gamit ang Square Root Tool

## Pangkalahatang-ideya
Sa takdang-aralin na ito, pinahusay mo ang iyong calculator MCP server sa pamamagitan ng pagdagdag ng bagong tool na nagkakalkula ng square root ng isang numero. Pinapayagan ng karagdagang ito ang iyong AI agent na tugunan ang mas kumplikadong mga tanong sa matematika, tulad ng "Ano ang square root ng 16?" o "Kalkulahin ang √49," gamit ang mga natural na utos sa wika.

## 🛠️ Pagsasakatuparan ng Square Root Tool
Para maidagdag ang functionality na ito, nagdefine ka ng bagong tool function sa iyong server.py file. Narito ang implementasyon:

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

## 🔍 Paano Ito Gumagana

- **I-import ang `math` module at gamitin ang `math.sqrt()` sa loob ng `@server.tool()` na may pangalang `sqrt`.**
- Pinayagan ang iyong AI agent na magsagawa ng mga kalkulasyon ng square root gamit ang natural na mga utos sa wika.
- Nagsanay kang magdagdag ng mga bagong tool at i-restart ang server para maisama ang mga dagdag na functionality.

Huwag mag-atubiling mag-eksperimento pa sa pagdagdag ng iba pang mga tool sa matematika, tulad ng exponentiation o logarithmic functions, upang lalo pang mapalawak ang kakayahan ng iyong agent!

**Pagtatanggol**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.