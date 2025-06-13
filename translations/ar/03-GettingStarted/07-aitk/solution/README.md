<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:30:44+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "ar"
}
-->
# 📘 حل الواجب: توسيع خادم MCP للحاسبة الخاصة بك بأداة الجذر التربيعي

## نظرة عامة  
في هذا الواجب، قمت بتعزيز خادم MCP للحاسبة الخاصة بك عن طريق إضافة أداة جديدة تحسب الجذر التربيعي لعدد ما. يتيح هذا الإضافة لوكيل الذكاء الاصطناعي الخاص بك التعامل مع استفسارات رياضية أكثر تعقيدًا، مثل "ما هو الجذر التربيعي للعدد 16؟" أو "احسب √49"، باستخدام أوامر اللغة الطبيعية.

## 🛠️ تنفيذ أداة الجذر التربيعي  
لإضافة هذه الوظيفة، عرّفت دالة أداة جديدة في ملف server.py الخاص بك. إليك التنفيذ:

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

## 🔍 كيف تعمل  

- **استيراد أداة `math.sqrt()`** باستخدام `@server.tool()` لتعريف أداة الجذر التربيعي.
- تمكين وكيل الذكاء الاصطناعي الخاص بك من التعامل مع حسابات الجذر التربيعي من خلال أوامر اللغة الطبيعية.
- ممارسة إضافة أدوات جديدة وإعادة تشغيل الخادم لدمج وظائف إضافية.

لا تتردد في التجربة أكثر عن طريق إضافة أدوات رياضية أخرى، مثل الأسس أو الدوال اللوغاريتمية، لمواصلة تحسين قدرات وكيلك!

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى جاهدين لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر المعتمد. للمعلومات الحساسة، يُنصح بالاستعانة بترجمة بشرية محترفة. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.