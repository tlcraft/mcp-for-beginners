<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-12T22:31:39+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "es"
}
-->
# 📘 Solución de la tarea: Ampliando tu servidor MCP de calculadora con una herramienta de raíz cuadrada

## Resumen
En esta tarea, mejoraste tu servidor MCP de calculadora agregando una nueva herramienta que calcula la raíz cuadrada de un número. Esta adición permite que tu agente de IA maneje consultas matemáticas más avanzadas, como "¿Cuál es la raíz cuadrada de 16?" o "Calcula √49," utilizando indicaciones en lenguaje natural.

## 🛠️ Implementando la herramienta de raíz cuadrada
Para agregar esta funcionalidad, definiste una nueva función de herramienta en tu archivo server.py. Aquí está la implementación:

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

## 🔍 Cómo funciona

- **Importa la herramienta `math.sqrt()` usando `@server.tool()` llamada `sqrt`.**
- Permitiste que tu agente de IA realice cálculos de raíz cuadrada a través de indicaciones en lenguaje natural.
- Practicaste cómo agregar nuevas herramientas y reiniciar el servidor para integrar funcionalidades adicionales.

¡Siéntete libre de experimentar agregando más herramientas matemáticas, como exponenciación o funciones logarítmicas, para seguir mejorando las capacidades de tu agente!

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas que puedan surgir del uso de esta traducción.