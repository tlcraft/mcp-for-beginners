<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-12T22:31:01+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "tw"
}
-->
# 📘 作業解答：擴充你的 Calculator MCP 伺服器，加入平方根工具

## 概述
在這次作業中，你透過新增一個能計算數字平方根的工具，來強化你的 Calculator MCP 伺服器。這讓你的 AI 代理能處理更進階的數學問題，例如「16 的平方根是多少？」或「計算 √49」，並能用自然語言指令完成。

## 🛠️ 實作平方根工具
為了加入這個功能，你在 server.py 檔案中定義了一個新的工具函式。實作如下：

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

## 🔍 運作原理

- **引入 `math` 模組，並使用 `math.sqrt()` 函式，搭配 `@server.tool()` 裝飾器定義 `sqrt` 工具。**
- 讓你的 AI 代理能透過自然語言指令處理平方根計算。
- 練習新增工具並重新啟動伺服器，以整合更多功能。

歡迎你繼續嘗試新增其他數學工具，例如冪次方或對數函數，讓你的代理功能更完整！

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們努力追求準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯所引起之任何誤解或誤譯負責。