<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:33:06+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "sw"
}
-->
# 📘 Suluhisho la Kazi ya Nyumba: Kupanua Server yako ya Calculator MCP kwa Kifaa cha Mizizi ya Mraba

## Muhtasari
Katika kazi hii ya nyumba, umeongeza server yako ya calculator MCP kwa kuongeza kifaa kipya kinachohesabu mizizi ya mraba ya nambari. Nyongeza hii inaruhusu wakala wako wa AI kushughulikia maswali ya hisabati ya hali ya juu, kama vile "Mizizi ya mraba ya 16 ni kiasi gani?" au "Hesabu √49," ukitumia maagizo ya lugha ya asili.

## 🛠️ Kutekeleza Kifaa cha Mizizi ya Mraba
Ili kuongeza kazi hii, uliunda kifaa kipya cha kazi katika faili yako ya server.py. Hapa ni utekelezaji:

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

## 🔍 Jinsi Inavyofanya Kazi

- **Ingiza kifaa cha `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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

- Extended your calculator MCP server with a new `sqrt`.**
- Umeruhusu wakala wako wa AI kushughulikia hesabu za mizizi ya mraba kupitia maagizo ya lugha ya asili.
- Umezoea kuongeza vifaa vipya na kuanzisha tena server ili kuingiza vipengele vipya.

Jisikilize huru kujaribu zaidi kwa kuongeza vifaa vingine vya hisabati, kama vile nguvu au kazi za logaritimu, ili kuendeleza uwezo wa wakala wako!

**Kisahafu**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuwa sahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Nyaraka ya asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatubeba dhamana yoyote kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.