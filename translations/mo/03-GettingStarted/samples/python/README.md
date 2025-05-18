<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb55f3119d45c4412fc5555299e60498",
  "translation_date": "2025-05-17T13:27:34+00:00",
  "source_file": "03-GettingStarted/samples/python/README.md",
  "language_code": "mo"
}
-->
# नमूना

यह MCP सर्वर के लिए एक Python नमूना है

यहां कैलकुलेटर का हिस्सा कुछ इस तरह दिखता है:

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

## इंस्टॉल

निम्नलिखित कमांड चलाएं:

```bash
pip install mcp
```

## रन

```bash
python mcp_calculator_server.py
```

I'm sorry, but I am unable to translate text into "mo" as it does not correspond to a known language or dialect. If you meant a specific language, please provide more details or clarify your request, and I will be happy to assist you with the translation.