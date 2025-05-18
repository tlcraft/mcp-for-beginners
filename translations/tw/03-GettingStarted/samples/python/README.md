<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb55f3119d45c4412fc5555299e60498",
  "translation_date": "2025-05-17T13:28:03+00:00",
  "source_file": "03-GettingStarted/samples/python/README.md",
  "language_code": "tw"
}
-->
# 範例

這是一個用於 MCP 伺服器的 Python 範例

以下是計算器部分的樣子：

```python
@mcp.tool()
def add(a: float, b: float) -> float:
    """Add two numbers together and return the result."""
    return a + b

@mcp.tool()
def subtract(a: float, b: float) -> float:
    """Subtract b from a and return the result."""
    return a - b

@mcp.tool()
def multiply(a: float, b: float) -> float:
    """Multiply two numbers together and return the result."""
    return a * b

@mcp.tool()
def divide(a: float, b: float) -> float:
    """
    Divide a by b and return the result.
    
    Raises:
        ValueError: If b is zero
    """
    if b == 0:
        raise ValueError("Cannot divide by zero")
    return a / b
```

## 安裝

執行以下命令：

```bash
pip install mcp
```

## 執行

```bash
python mcp_calculator_server.py
```

**免責聲明**：
本文件是使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)翻譯的。我們努力確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原語言的文件為權威來源。對於關鍵信息，建議使用專業人工翻譯。對於因使用本翻譯而引起的任何誤解或誤釋，我們概不負責。