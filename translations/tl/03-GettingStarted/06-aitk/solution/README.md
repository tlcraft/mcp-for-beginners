<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:37:08+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "tl"
}
-->
# 📘 Solusyon sa Takdang Aralin: Pagpapalawak ng Iyong Calculator MCP Server gamit ang Square Root Tool

## Pangkalahatang-ideya
Sa takdang araling ito, pinahusay mo ang iyong calculator MCP server sa pamamagitan ng pagdaragdag ng bagong tool na nagkakalkula ng square root ng isang numero. Ang karagdagang ito ay nagpapahintulot sa iyong AI agent na humawak ng mas advanced na mga query sa matematika, tulad ng "Ano ang square root ng 16?" o "Kalkulahin ang √49," gamit ang mga natural na wika na prompt.

## 🛠️ Pagpapatupad ng Square Root Tool
Upang maidagdag ang kakayahang ito, nag-defina ka ng bagong tool function sa iyong server.py file. Narito ang implementasyon:

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

- **I-import ang `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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
- Pinagana ang iyong AI agent na humawak ng mga kalkulasyon ng square root sa pamamagitan ng mga natural na wika na prompt.
- Nagpraktis sa pagdaragdag ng mga bagong tool at pag-restart ng server upang maisama ang karagdagang mga kakayahan.

Huwag mag-atubiling mag-eksperimento pa sa pamamagitan ng pagdaragdag ng higit pang mga tool sa matematika, tulad ng exponentiation o logarithmic functions, upang patuloy na mapahusay ang mga kakayahan ng iyong agent!

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat sinisikap naming maging tumpak, pakitandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga error o hindi pagkakatumpak. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang pinagmulan. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Kami ay hindi mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.