<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-16T15:31:53+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "zh"
}
-->
# 📘 作业解决方案：为你的计算器 MCP 服务器扩展平方根工具

## 概述
在本次作业中，你通过添加一个计算数字平方根的新工具，增强了你的计算器 MCP 服务器。这个新增功能使你的 AI 代理能够处理更高级的数学查询，比如“16 的平方根是多少？”或“计算 √49”，并能通过自然语言提示完成计算。

## 🛠️ 实现平方根工具
为了实现这个功能，你在 server.py 文件中定义了一个新的工具函数。实现代码如下：

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

## 🔍 工作原理

- **导入 `math` 模块并使用 `math.sqrt()` 函数。**
- 通过自然语言提示，使你的 AI 代理能够处理平方根计算。
- 练习添加新工具并重启服务器，以整合更多功能。

你可以继续尝试添加更多数学工具，比如指数运算或对数函数，进一步提升你的代理能力！

**免责声明**：  
本文件使用AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)进行翻译。尽管我们力求准确，但请注意自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们概不负责。