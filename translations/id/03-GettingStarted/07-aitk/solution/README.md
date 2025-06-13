<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:32:49+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "id"
}
-->
# 📘 Solusi Tugas: Memperluas Server MCP Kalkulator Anda dengan Alat Akar Kuadrat

## Ikhtisar  
Dalam tugas ini, Anda meningkatkan server MCP kalkulator Anda dengan menambahkan alat baru yang menghitung akar kuadrat dari sebuah angka. Penambahan ini memungkinkan agen AI Anda menangani pertanyaan matematika yang lebih kompleks, seperti "Berapa akar kuadrat dari 16?" atau "Hitung √49," menggunakan perintah dalam bahasa alami.

## 🛠️ Menerapkan Alat Akar Kuadrat  
Untuk menambahkan fungsi ini, Anda mendefinisikan fungsi alat baru di file server.py Anda. Berikut implementasinya:

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

## 🔍 Cara Kerjanya  

- **Impor alat `math.sqrt()`**.  
- Memungkinkan agen AI Anda untuk menangani perhitungan akar kuadrat melalui perintah bahasa alami.  
- Berlatih menambahkan alat baru dan me-restart server untuk mengintegrasikan fungsi tambahan.

Silakan bereksperimen lebih lanjut dengan menambahkan alat matematika lainnya, seperti perpangkatan atau fungsi logaritma, untuk terus meningkatkan kemampuan agen Anda!

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.