<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb55f3119d45c4412fc5555299e60498",
  "translation_date": "2025-05-17T13:33:19+00:00",
  "source_file": "03-GettingStarted/samples/python/README.md",
  "language_code": "hr"
}
-->
# Primjer

Ovo je Python primjer za MCP Server

Evo kako izgleda dio kalkulatora:

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

## Instalacija

Pokrenite sljedeću naredbu:

```bash
pip install mcp
```

## Pokretanje

```bash
python mcp_calculator_server.py
```

**Izjava o odricanju odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, molimo vas da budete svjesni da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne odgovaramo za nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.