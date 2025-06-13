<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:33:28+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "sk"
}
-->
# 📘 Riešenie úlohy: Rozšírenie vášho kalkulačkového MCP servera o nástroj na druhú odmocninu

## Prehľad
V tejto úlohe ste rozšírili váš kalkulačkový MCP server pridaním nového nástroja, ktorý vypočíta druhú odmocninu čísla. Toto rozšírenie umožňuje vášmu AI agentovi riešiť zložitejšie matematické otázky, ako napríklad „Aká je druhá odmocnina z 16?“ alebo „Vypočítaj √49“ pomocou prirodzených jazykových príkazov.

## 🛠️ Implementácia nástroja na druhú odmocninu
Na pridanie tejto funkcie ste definovali novú nástrojovú funkciu vo vašom súbore server.py. Tu je implementácia:

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

## 🔍 Ako to funguje

- **Importuje `math` knižnicu a používa funkciu `math.sqrt()` v nástroji `@server.tool()` s názvom `sqrt`.**
- Umožňuje vášmu AI agentovi spracovávať výpočty druhej odmocniny prostredníctvom prirodzených jazykových príkazov.
- Precvičili ste si pridávanie nových nástrojov a reštartovanie servera, aby sa nové funkcie integrovali.

Neváhajte ďalej experimentovať a pridávať ďalšie matematické nástroje, ako sú umocňovanie alebo logaritmické funkcie, aby ste ešte viac rozšírili schopnosti vášho agenta!

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, vezmite prosím na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.