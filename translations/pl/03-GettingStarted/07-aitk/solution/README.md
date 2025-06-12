<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-12T22:31:59+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "pl"
}
-->
# 📘 Rozwiązanie zadania: Rozszerzenie serwera MCP kalkulatora o narzędzie do pierwiastkowania

## Przegląd
W tym zadaniu rozbudowałeś swój serwer MCP kalkulatora, dodając nowe narzędzie, które oblicza pierwiastek kwadratowy liczby. Dzięki temu Twój agent AI może obsługiwać bardziej zaawansowane zapytania matematyczne, takie jak „Jaki jest pierwiastek kwadratowy z 16?” lub „Oblicz √49”, używając naturalnych poleceń.

## 🛠️ Implementacja narzędzia do pierwiastkowania
Aby dodać tę funkcjonalność, zdefiniowałeś nową funkcję narzędzia w pliku server.py. Oto implementacja:

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

## 🔍 Jak to działa

- **Importuj narzędzie `math.sqrt()` i oznacz je dekoratorem `@server.tool()` jako `sqrt`.**
- Umożliwiłeś agentowi AI obsługę obliczeń pierwiastka kwadratowego na podstawie naturalnych poleceń.
- Przećwiczyłeś dodawanie nowych narzędzi oraz ponowne uruchamianie serwera, aby zintegrować dodatkowe funkcje.

Śmiało eksperymentuj dalej, dodając kolejne narzędzia matematyczne, takie jak potęgowanie czy funkcje logarytmiczne, aby jeszcze bardziej rozbudować możliwości swojego agenta!

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy pamiętać, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy traktować jako autorytatywne źródło. W przypadku informacji o kluczowym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.