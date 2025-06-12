<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-12T22:31:53+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "fa"
}
-->
# 📘 راه‌حل تمرین: افزودن ابزار جذر به سرور MCP ماشین‌حساب شما

## مرور کلی  
در این تمرین، سرور MCP ماشین‌حساب خود را با افزودن ابزاری جدید که جذر یک عدد را محاسبه می‌کند، بهبود دادید. این افزونه به عامل هوش مصنوعی شما امکان می‌دهد تا پرسش‌های ریاضی پیچیده‌تری مانند «جذر ۱۶ چقدر است؟» یا «محاسبه √۴۹» را با استفاده از دستورات زبان طبیعی پاسخ دهد.

## 🛠️ پیاده‌سازی ابزار جذر  
برای افزودن این قابلیت، یک تابع ابزار جدید در فایل server.py تعریف کردید. در اینجا پیاده‌سازی آن آمده است:

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

## 🔍 نحوه کارکرد  

- **وارد کردن ابزار `math.sqrt()` از ماژول math و استفاده از دکوراتور @server.tool() برای تعریف تابع sqrt.**  
- عامل هوش مصنوعی شما اکنون می‌تواند محاسبات جذر را از طریق دستورات زبان طبیعی انجام دهد.  
- تمرین افزودن ابزارهای جدید و راه‌اندازی مجدد سرور برای ادغام قابلیت‌های بیشتر انجام شد.

برای ارتقای بیشتر قابلیت‌های عامل خود، می‌توانید ابزارهای ریاضی بیشتری مانند توانی یا لگاریتمی اضافه کنید و آزمایش کنید!

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوء تفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.