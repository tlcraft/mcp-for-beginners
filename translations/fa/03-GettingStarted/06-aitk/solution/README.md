<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:32:16+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "fa"
}
-->
# 📘 راه حل تکلیف: گسترش سرور MCP ماشین حساب شما با ابزار جذر

## مرور کلی
در این تکلیف، شما سرور MCP ماشین حساب خود را با افزودن ابزاری جدید که جذر یک عدد را محاسبه می‌کند، بهبود دادید. این افزودنی به عامل هوش مصنوعی شما اجازه می‌دهد تا با پرسش‌های ریاضی پیچیده‌تری مانند "جذر 16 چیست؟" یا "محاسبه √49" از طریق درخواست‌های زبان طبیعی مقابله کند.

## 🛠️ پیاده‌سازی ابزار جذر
برای اضافه کردن این قابلیت، شما یک تابع ابزار جدید در فایل server.py خود تعریف کردید. اینجا پیاده‌سازی آن آمده است:

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

## 🔍 چگونه کار می‌کند

- **وارد کردن ابزار `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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
- فعال کردن عامل هوش مصنوعی شما برای انجام محاسبات جذر از طریق درخواست‌های زبان طبیعی.
- تمرین افزودن ابزارهای جدید و راه‌اندازی مجدد سرور برای ادغام قابلیت‌های اضافی.

می‌توانید به آزمایش بیشتر ادامه دهید و ابزارهای ریاضی بیشتری مانند توان‌گیری یا توابع لگاریتمی اضافه کنید تا قابلیت‌های عامل خود را بیشتر گسترش دهید!

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌ها باشند. سند اصلی به زبان اصلی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئولیتی در قبال سوء تفاهم‌ها یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.