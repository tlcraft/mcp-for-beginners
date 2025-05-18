<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb55f3119d45c4412fc5555299e60498",
  "translation_date": "2025-05-17T13:32:44+00:00",
  "source_file": "03-GettingStarted/samples/python/README.md",
  "language_code": "ro"
}
-->
# Exemplar

Acesta este un exemplu de Python pentru un server MCP

Iată cum arată partea de calculator:

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

## Instalare

Rulează următoarea comandă:

```bash
pip install mcp
```

## Executare

```bash
python mcp_calculator_server.py
```

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să obținem acuratețe, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem răspunzători pentru neînțelegeri sau interpretări greșite care decurg din utilizarea acestei traduceri.