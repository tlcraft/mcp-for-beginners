<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:32:54+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "ms"
}
-->
# 📘 פתרון המשימה: הרחבת שרת ה-MCP של המחשבון שלך עם כלי שורש ריבועי

## סקירה כללית
במשימה זו, הרחבת את שרת ה-MCP של המחשבון שלך על ידי הוספת כלי חדש שמחשב את השורש הריבועי של מספר. תוספת זו מאפשרת לסוכן ה-AI שלך לטפל בשאילתות מתמטיות מתקדמות יותר, כמו "מה השורש הריבועי של 16?" או "חשב √49," באמצעות פקודות בשפה טבעית.

## 🛠️ יישום כלי השורש הריבועי
כדי להוסיף את הפונקציונליות הזו, הגדרת פונקציית כלי חדשה בקובץ server.py שלך. הנה היישום:

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

## 🔍 איך זה עובד

- **ייבוא כלי ה-`math.sqrt()`**.
- אפשרת לסוכן ה-AI שלך לבצע חישובי שורש ריבועי באמצעות פקודות בשפה טבעית.
- התאמנת בהוספת כלים חדשים והפעלה מחדש של השרת כדי לשלב פונקציות נוספות.

אתה מוזמן להמשיך ולנסות להוסיף כלים מתמטיים נוספים, כמו חזקות או פונקציות לוגריתמיות, כדי להרחיב עוד יותר את יכולות הסוכן שלך!

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat kritikal, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.