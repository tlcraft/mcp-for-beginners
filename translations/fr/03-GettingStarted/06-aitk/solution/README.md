<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-16T15:31:28+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "fr"
}
-->
# 📘 Solution de l'exercice : Extension de votre serveur MCP Calculator avec un outil de racine carrée

## Aperçu  
Dans cet exercice, vous avez amélioré votre serveur MCP Calculator en ajoutant un nouvel outil qui calcule la racine carrée d’un nombre. Cette fonctionnalité permet à votre agent IA de traiter des requêtes mathématiques plus avancées, comme « Quelle est la racine carrée de 16 ? » ou « Calcule √49 », en utilisant des instructions en langage naturel.

## 🛠️ Implémentation de l’outil racine carrée  
Pour ajouter cette fonctionnalité, vous avez défini une nouvelle fonction outil dans votre fichier server.py. Voici l’implémentation :

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

## 🔍 Fonctionnement

- **Importez l’outil `math.sqrt()`**.  
- Permettez à votre agent IA de gérer les calculs de racine carrée via des requêtes en langage naturel.  
- Vous vous êtes exercé à ajouter de nouveaux outils et à redémarrer le serveur pour intégrer ces fonctionnalités supplémentaires.

N’hésitez pas à continuer à expérimenter en ajoutant d’autres outils mathématiques, comme l’exponentiation ou les fonctions logarithmiques, pour enrichir les capacités de votre agent !

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de recourir à une traduction professionnelle humaine. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l'utilisation de cette traduction.