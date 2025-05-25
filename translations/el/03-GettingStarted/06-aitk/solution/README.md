<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:35:03+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "el"
}
-->
# 📘 Λύση Εργασίας: Επέκταση του MCP Διακομιστή Υπολογιστή σας με ένα Εργαλείο Τετραγωνικής Ρίζας

## Επισκόπηση
Σε αυτή την εργασία, ενισχύσατε τον MCP διακομιστή υπολογιστή σας προσθέτοντας ένα νέο εργαλείο που υπολογίζει την τετραγωνική ρίζα ενός αριθμού. Αυτή η προσθήκη επιτρέπει στον πράκτορα AI σας να χειρίζεται πιο προηγμένα μαθηματικά ερωτήματα, όπως "Ποια είναι η τετραγωνική ρίζα του 16;" ή "Υπολόγισε √49," χρησιμοποιώντας φυσική γλώσσα.

## 🛠️ Υλοποίηση του Εργαλείου Τετραγωνικής Ρίζας
Για να προσθέσετε αυτή τη λειτουργικότητα, ορίσατε μια νέα συνάρτηση εργαλείου στο αρχείο server.py σας. Εδώ είναι η υλοποίηση:

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

## 🔍 Πώς Λειτουργεί

- **Εισαγωγή του εργαλείου `math` module**: To perform mathematical operations beyond basic arithmetic, Python provides the built-in `math` module. This module includes a variety of mathematical functions and constants. By importing it using `import math`, you gain access to functions like `math.sqrt()`, which computes the square root of a number.
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

- Extended your calculator MCP server with a new `sqrt`.
- Ενεργοποιήσατε τον πράκτορα AI σας να χειρίζεται υπολογισμούς τετραγωνικής ρίζας μέσω προτροπών φυσικής γλώσσας.
- Εξασκηθήκατε στην προσθήκη νέων εργαλείων και στην επανεκκίνηση του διακομιστή για την ενσωμάτωση πρόσθετων λειτουργιών.

Νιώστε ελεύθεροι να πειραματιστείτε περαιτέρω προσθέτοντας περισσότερα μαθηματικά εργαλεία, όπως εργαλεία εκθετικής ή λογαριθμικής λειτουργίας, για να συνεχίσετε να ενισχύετε τις δυνατότητες του πράκτορα σας!

**Αποποίηση ευθύνης**: 
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ προσπαθούμε για ακρίβεια, παρακαλώ να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις μπορεί να περιέχουν σφάλματα ή ανακρίβειες. Το αρχικό έγγραφο στη γλώσσα του θα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν είμαστε υπεύθυνοι για τυχόν παρεξηγήσεις ή εσφαλμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.