<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-16T15:31:41+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "ja"
}
-->
# 📘 課題解答：平方根ツールを追加してCalculator MCPサーバーを拡張する

## 概要
この課題では、Calculator MCPサーバーに数値の平方根を計算する新しいツールを追加しました。この追加により、AIエージェントは「16の平方根は？」や「√49を計算して」といった自然言語の質問に対応できるようになります。

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

## 🔍 動作の仕組み

- **`math`モジュールをインポートし、`math.sqrt()`関数を利用した`sqrt`ツールを定義。**
- AIエージェントが自然言語のプロンプトで平方根の計算を処理できるようにした。
- 新しいツールを追加し、サーバーを再起動して機能を統合する手順を実践。

さらに、べき乗や対数関数などの数学ツールを追加して、エージェントの機能をさらに強化することも自由に試してみてください！

**免責事項**：  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されました。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても責任を負いかねますのでご了承ください。