<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-16T15:31:34+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "de"
}
-->
# 📘 Lösung der Aufgabe: Erweiterung Ihres Calculator MCP Servers um ein Quadratwurzel-Tool

## Übersicht
In dieser Aufgabe haben Sie Ihren Calculator MCP Server erweitert, indem Sie ein neues Tool hinzugefügt haben, das die Quadratwurzel einer Zahl berechnet. Diese Ergänzung ermöglicht es Ihrem KI-Agenten, komplexere mathematische Anfragen zu bearbeiten, wie zum Beispiel „Wie lautet die Quadratwurzel von 16?“ oder „Berechne √49“ mithilfe natürlicher Sprachbefehle.

## 🛠️ Implementierung des Quadratwurzel-Tools
Um diese Funktion hinzuzufügen, haben Sie eine neue Tool-Funktion in Ihrer server.py-Datei definiert. Hier ist die Implementierung:

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

## 🔍 Wie es funktioniert

- **Importieren Sie das `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
- **Function Definition**: The `@server.tool()` decorator registers the `sqrt` function as a tool accessible by your AI agent.
- **Input Parameter**: The function accepts a single argument `a` of type `float`.
- **Error Handling**: If `a` is negative, the function raises a `ValueError` to prevent computing the square root of a negative number, which is not supported by the `math.sqrt()` function.
- **Return Value**: For non-negative inputs, the function returns the square root of `a` using Python's built-in `math.sqrt()` method.

## 🔄 Restarting the Server
After adding the new `sqrt` tool, it's essential to restart your MCP server to ensure the agent recognizes and can utilize the newly added functionality.

## 💬 Example Prompts to Test the New Tool
Here are some natural language prompts you can use to test the square root functionality:

- "What is the square root of 25?"
- "Calculate the square root of 81."
- "Find the square root of 0."
- "What is the square root of 2.25?"

These prompts should trigger the agent to invoke the `sqrt` tool and return the correct results.

## ✅ Summary
By completing this assignment, you've:

- Extended your calculator MCP server with a new `sqrt` Tool.
- Ermöglichen Sie Ihrem KI-Agenten, Quadratwurzel-Berechnungen über natürliche Sprachbefehle durchzuführen.
- Üben Sie das Hinzufügen neuer Tools und das Neustarten des Servers, um zusätzliche Funktionen zu integrieren.

Probieren Sie gerne weitere mathematische Werkzeuge aus, wie Potenz- oder Logarithmusfunktionen, um die Fähigkeiten Ihres Agenten weiter zu verbessern!

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, bitten wir zu beachten, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die durch die Nutzung dieser Übersetzung entstehen.