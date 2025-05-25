<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:32:32+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "ur"
}
-->
# 📘 اسائنمنٹ حل: اپنے کیلکولیٹر MCP سرور کو مربع جڑ کے ٹول کے ساتھ بڑھانا

## جائزہ
اس اسائنمنٹ میں، آپ نے اپنے کیلکولیٹر MCP سرور کو ایک نئے ٹول کے ساتھ بہتر بنایا ہے جو کسی نمبر کی مربع جڑ کا حساب لگاتا ہے۔ اس اضافے سے آپ کے AI ایجنٹ کو مزید پیچیدہ ریاضیاتی سوالات جیسے "16 کی مربع جڑ کیا ہے؟" یا "√49 کا حساب لگائیں" کو قدرتی زبان کے اشارے کے ذریعے حل کرنے کی صلاحیت ملتی ہے۔

## 🛠️ مربع جڑ کے ٹول کا نفاذ
اس فعالیت کو شامل کرنے کے لیے، آپ نے اپنے server.py فائل میں ایک نیا ٹول فنکشن تعریف کیا۔ یہاں اس کا نفاذ ہے:

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

## 🔍 یہ کیسے کام کرتا ہے

- **`math` ٹول درآمد کریں۔
- اپنے AI ایجنٹ کو قدرتی زبان کے اشارے کے ذریعے مربع جڑ کی حساب کتاب کو سنبھالنے کی صلاحیت دی۔
- نئے ٹولز شامل کرنے اور اضافی فعالیت کو مربوط کرنے کے لیے سرور کو دوبارہ شروع کرنے کی مشق کی۔

مزید تجربہ کرنے کے لیے آزاد محسوس کریں اور مزید ریاضیاتی ٹولز جیسے اسپرونٹیشن یا لوگارتھمک فنکشنز شامل کریں تاکہ اپنے ایجنٹ کی صلاحیتوں کو بڑھاتے رہیں!

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ جبکہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا غیر درستیاں ہوسکتی ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں مستند ماخذ سمجھا جانا چاہئے۔ اہم معلومات کے لئے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمہ کے استعمال سے پیدا ہونے والی کسی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔