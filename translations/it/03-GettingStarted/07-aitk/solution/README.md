<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:31:35+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "it"
}
-->
# 📘 Soluzione dell'Assegnamento: Estendere il Tuo Server MCP del Calcolatore con uno Strumento per la Radice Quadrata

## Panoramica
In questo esercizio, hai migliorato il tuo server MCP del calcolatore aggiungendo un nuovo strumento che calcola la radice quadrata di un numero. Questa aggiunta permette al tuo agente AI di gestire query matematiche più avanzate, come "Qual è la radice quadrata di 16?" o "Calcola √49," utilizzando comandi in linguaggio naturale.

## 🛠️ Implementazione dello Strumento Radice Quadrata
Per aggiungere questa funzionalità, hai definito una nuova funzione strumento nel file server.py. Ecco l’implementazione:

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

## 🔍 Come Funziona

- **Importa lo strumento `math.sqrt()` utilizzando `@server.tool()` per definire `sqrt(a: float)` che calcola la radice quadrata di `a` gestendo eventuali `ValueError`.**
- Hai abilitato il tuo agente AI a gestire calcoli di radice quadrata tramite comandi in linguaggio naturale.
- Hai messo in pratica l’aggiunta di nuovi strumenti e il riavvio del server per integrare funzionalità aggiuntive.

Sentiti libero di sperimentare ulteriormente aggiungendo altri strumenti matematici, come l’esponenziazione o le funzioni logaritmiche, per continuare a potenziare le capacità del tuo agente!

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di considerare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo responsabilità per eventuali fraintendimenti o interpretazioni errate derivanti dall’uso di questa traduzione.