<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb55f3119d45c4412fc5555299e60498",
  "translation_date": "2025-05-17T13:32:22+00:00",
  "source_file": "03-GettingStarted/samples/python/README.md",
  "language_code": "cs"
}
-->
# Ukázka

Toto je ukázka Pythonu pro MCP Server

Takto vypadá část kalkulačky:

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

## Instalace

Spusťte následující příkaz:

```bash
pip install mcp
```

## Spuštění

```bash
python mcp_calculator_server.py
```

**Prohlášení**:  
Tento dokument byl přeložen pomocí služby AI překladatel [Co-op Translator](https://github.com/Azure/co-op-translator). Ačkoli se snažíme o přesnost, prosíme vás, abyste si byli vědomi toho, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.