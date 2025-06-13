<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:30:52+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "ur"
}
-->
# 📘 Assignment Solution: Extending Your Calculator MCP Server with a Square Root Tool

## Overview
اس اسائنمنٹ میں، آپ نے اپنے calculator MCP سرور کو ایک نئے ٹول کے ذریعے بہتر بنایا جو کسی نمبر کی مربع جذر کا حساب لگاتا ہے۔ اس اضافے سے آپ کا AI ایجنٹ زیادہ پیچیدہ ریاضیاتی سوالات جیسے "16 کا مربع جذر کیا ہے؟" یا "√49 کا حساب لگائیں" قدرتی زبان کے پرامپٹس کے ذریعے حل کر سکتا ہے۔

## 🛠️ Implementing the Square Root Tool
اس فنکشن کو شامل کرنے کے لیے، آپ نے اپنے server.py فائل میں ایک نیا ٹول فنکشن ڈیفائن کیا۔ یہاں اس کا نفاذ دیا گیا ہے:

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

## 🔍 How It Works

- **`math.sqrt()` ٹول کو import کیا گیا ہے۔
- آپ کے AI ایجنٹ کو مربع جذر کے حسابات قدرتی زبان کے پرامپٹس کے ذریعے سنبھالنے کے قابل بنایا گیا ہے۔
- نئے ٹولز شامل کرنے اور سرور کو ری اسٹارٹ کرنے کی مشق کی گئی تاکہ اضافی فیچرز کو شامل کیا جا سکے۔

مزید ریاضیاتی ٹولز جیسے exponentiation یا logarithmic فنکشنز شامل کر کے اپنے ایجنٹ کی صلاحیتوں کو مزید بڑھانے کے لیے تجربہ کریں!

**ڈسکلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ذریعہ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ تجویز کیا جاتا ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تعبیر کے ذمہ دار نہیں ہیں۔