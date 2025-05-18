<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:33:15+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "hi"
}
-->
# 📘 असाइनमेंट समाधान: अपने कैलकुलेटर MCP सर्वर को एक वर्गमूल टूल के साथ विस्तारित करना

## अवलोकन
इस असाइनमेंट में, आपने अपने कैलकुलेटर MCP सर्वर को एक नया टूल जोड़कर उन्नत किया जो किसी संख्या का वर्गमूल निकालता है। इस जोड़ से आपका AI एजेंट अधिक उन्नत गणितीय प्रश्नों को संभाल सकता है, जैसे "16 का वर्गमूल क्या है?" या "√49 की गणना करें," प्राकृतिक भाषा संकेतों का उपयोग करते हुए।

## 🛠️ वर्गमूल टूल को लागू करना
इस कार्यक्षमता को जोड़ने के लिए, आपने अपने server.py फ़ाइल में एक नया टूल फ़ंक्शन परिभाषित किया। यहाँ इसका कार्यान्वयन है:

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

## 🔍 यह कैसे काम करता है

- **`math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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

- Extended your calculator MCP server with a new `sqrt` टूल को आयात करें।
- अपने AI एजेंट को प्राकृतिक भाषा संकेतों के माध्यम से वर्गमूल गणना संभालने में सक्षम बनाएं।
- नए टूल जोड़ने और अतिरिक्त कार्यक्षमताओं को एकीकृत करने के लिए सर्वर को पुनरारंभ करने का अभ्यास किया।

अपने एजेंट की क्षमताओं को बढ़ाने के लिए अधिक गणितीय टूल, जैसे घातांक या लघुगणक कार्यों को जोड़कर आगे प्रयोग करने के लिए स्वतंत्र महसूस करें!

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।