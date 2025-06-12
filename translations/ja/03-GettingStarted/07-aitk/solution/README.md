<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-12T22:31:18+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "ja"
}
-->
# 📘 課題解答：電卓MCPサーバーに平方根ツールを追加する

## 概要
この課題では、電卓MCPサーバーに平方根を計算する新しいツールを追加しました。この機能により、AIエージェントは「16の平方根は？」や「√49を計算して」といった自然言語の質問に対応できるようになります。

## 🛠️ 平方根ツールの実装
この機能を追加するために、server.pyファイルに新しいツール関数を定義しました。実装は以下の通りです。

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

## 🔍 仕組み

- **`math.sqrt()` を使う `sqrt` ツールを `@server.tool()` デコレーターで定義しました。**
- AIエージェントが自然言語の指示で平方根計算を扱えるようにしました。
- 新しいツールを追加し、サーバーを再起動して機能を統合する練習を行いました。

さらに指数関数や対数関数など、他の数学ツールを追加してエージェントの機能を拡張することもぜひ試してみてください！

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されました。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。正式な情報源としては、原文（原言語の文書）を参照してください。重要な情報については、専門の人間翻訳をご利用いただくことを推奨します。本翻訳の利用により生じた誤解や誤訳について、一切の責任を負いかねます。