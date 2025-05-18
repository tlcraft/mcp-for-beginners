<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:32:09+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "ar"
}
-->
# 📘 حل الواجب: توسيع خادم MCP الحاسبة الخاص بك بأداة الجذر التربيعي

## نظرة عامة
في هذا الواجب، قمت بتحسين خادم MCP الحاسبة الخاص بك عن طريق إضافة أداة جديدة تحسب الجذر التربيعي للعدد. يتيح هذا الإضافة لوكيل الذكاء الاصطناعي الخاص بك التعامل مع استفسارات رياضية أكثر تقدمًا، مثل "ما هو الجذر التربيعي لـ 16؟" أو "احسب √49"، باستخدام مطالبات اللغة الطبيعية.

## 🛠️ تنفيذ أداة الجذر التربيعي
لإضافة هذه الوظيفة، قمت بتعريف وظيفة أداة جديدة في ملف server.py الخاص بك. إليك التنفيذ:

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

## 🔍 كيف يعمل

- **استيراد أداة `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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
- تمكين وكيل الذكاء الاصطناعي الخاص بك من التعامل مع حسابات الجذر التربيعي من خلال مطالبات اللغة الطبيعية.
- ممارسة إضافة أدوات جديدة وإعادة تشغيل الخادم لدمج وظائف إضافية.

لا تتردد في تجربة المزيد عن طريق إضافة أدوات رياضية أخرى، مثل الرفع إلى القوة أو الدوال اللوغاريتمية، لمواصلة تحسين قدرات وكيلك!

**إخلاء المسؤولية**:  
تم ترجمة هذه الوثيقة باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى للدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو معلومات غير دقيقة. يجب اعتبار الوثيقة الأصلية بلغتها الأم المصدر الموثوق. بالنسبة للمعلومات الحرجة، يُوصى بالترجمة البشرية الاحترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ينشأ عن استخدام هذه الترجمة.