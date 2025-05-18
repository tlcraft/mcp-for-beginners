<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:33:01+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "hk"
}
-->
# 📘 作業解決方案：擴展你的計算器 MCP 伺服器，加入平方根工具

## 概述
在這個作業中，你通過添加一個新的工具來增強你的計算器 MCP 伺服器，該工具可以計算一個數字的平方根。這項新增功能使得你的 AI 代理可以處理更高級的數學查詢，例如 "16 的平方根是多少？" 或 "計算 √49"，使用自然語言提示。

## 🛠️ 實施平方根工具
為了添加這個功能，你在 server.py 文件中定義了一個新的工具函數。以下是實現：

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

## 🔍 運作方式

- **導入 `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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

- Extended your calculator MCP server with a new `sqrt` 工具。
- 使你的 AI 代理能夠通過自然語言提示處理平方根計算。
- 練習添加新工具並重啟伺服器以整合額外功能。

隨意進一步嘗試添加更多數學工具，例如指數或對數函數，以繼續增強你的代理能力！

**免責聲明**：
此文件已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要信息，建議使用專業人工翻譯。對於因使用此翻譯而引起的任何誤解或誤釋，我們不承擔責任。