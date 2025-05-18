<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb55f3119d45c4412fc5555299e60498",
  "translation_date": "2025-05-17T13:27:58+00:00",
  "source_file": "03-GettingStarted/samples/python/README.md",
  "language_code": "hk"
}
-->
# 樣本

這是一個用於 MCP 伺服器的 Python 樣本

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

## 運行

```bash
python mcp_calculator_server.py
```

**免責聲明**：  
本文件已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們力求準確，但請注意，自動翻譯可能會包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要信息，建議使用專業的人類翻譯。我們對因使用本翻譯而產生的任何誤解或誤讀不承擔責任。