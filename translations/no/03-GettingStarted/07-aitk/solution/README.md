<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:32:15+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "no"
}
-->
# 📘 Oppgaveløsning: Utvid din Calculator MCP-server med et kvadratrotsverktøy

## Oversikt
I denne oppgaven har du utvidet din calculator MCP-server ved å legge til et nytt verktøy som beregner kvadratroten av et tall. Denne tillegg gjør at AI-agenten din kan håndtere mer avanserte matematiske spørsmål, som "Hva er kvadratroten av 16?" eller "Beregn √49," ved hjelp av naturlige språkkommandoer.

## 🛠️ Implementering av kvadratrotsverktøyet
For å legge til denne funksjonaliteten definerte du en ny verktøyfunksjon i filen server.py. Her er implementeringen:

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

## 🔍 Slik fungerer det

- **Importer `math`-modulen og bruk `math.sqrt()`-funksjonen.**
- Aktiverte AI-agenten din til å håndtere kvadratrotsberegninger gjennom naturlige språkkommandoer.
- Øvde på å legge til nye verktøy og restarte serveren for å integrere ekstra funksjonalitet.

Prøv gjerne å legge til flere matematiske verktøy, som potensregning eller logaritmefunksjoner, for å fortsette å forbedre agentens evner!

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.