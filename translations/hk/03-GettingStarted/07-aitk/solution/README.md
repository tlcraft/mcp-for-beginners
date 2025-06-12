<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-12T22:31:06+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "hk"
}
-->
# 📘 作業解答：擴展你的 Calculator MCP Server，加設平方根工具

## 概覽  
在這次作業中，你為 Calculator MCP Server 加入了一個新工具，可以計算數字的平方根。這個新增功能令你的 AI 代理能處理更進階的數學查詢，例如「16 的平方根是多少？」或「計算 √49」，並用自然語言提示進行操作。

## 🛠️ 實作平方根工具  
要加入這個功能，你在 server.py 檔案中定義了一個新的工具函數。以下是實作內容：

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

- **引入 `math` 模組並使用 `math.sqrt()` 函數，透過 `@server.tool()` 裝飾器定義 `sqrt` 工具。  
- 讓你的 AI 代理能夠用自然語言提示處理平方根計算。  
- 練習新增工具並重啟伺服器，以整合更多功能。  

歡迎你繼續嘗試新增其他數學工具，例如次方或對數函數，持續提升你的代理能力！

**免責聲明**：  
本文件係用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)翻譯。雖然我哋努力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原文文件嘅母語版本應視為權威來源。對於重要資料，建議使用專業人工翻譯。我哋對因使用本翻譯而引致嘅任何誤解或誤釋概不負責。