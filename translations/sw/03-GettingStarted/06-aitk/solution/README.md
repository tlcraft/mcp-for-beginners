<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:37:20+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "sw"
}
-->
# 📘 Suluhisho la Kazi: Kupanua Seva ya Calculator MCP na Chombo cha Mizizi ya Mraba

## Muhtasari
Katika kazi hii, ulipanua seva yako ya calculator MCP kwa kuongeza chombo kipya kinachohesabu mizizi ya mraba ya namba. Ongezeko hili linawezesha wakala wako wa AI kushughulikia maswali ya hesabu ya juu zaidi, kama vile "Mizizi ya mraba ya 16 ni nini?" au "Hesabu √49," kwa kutumia maelekezo ya lugha ya kawaida.

## 🛠️ Kutekeleza Chombo cha Mizizi ya Mraba
Ili kuongeza uwezo huu, ulifafanua kazi mpya ya chombo katika faili yako ya server.py. Hapa kuna utekelezaji:

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

- **Ingiza chombo cha `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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

- Extended your calculator MCP server with a new `sqrt`.
- Uliwezesha wakala wako wa AI kushughulikia mahesabu ya mizizi ya mraba kupitia maelekezo ya lugha ya kawaida.
- Ulijifunza jinsi ya kuongeza zana mpya na kuanzisha tena seva ili kuunganisha uwezo wa ziada.

Usisite kujaribu zaidi kwa kuongeza zana zaidi za hesabu, kama vile uwezo wa kuzidisha au kazi za logarithemu, ili kuendelea kuboresha uwezo wa wakala wako!

**Kanusho**: 
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo chenye mamlaka. Kwa habari muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatuwajibiki kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.