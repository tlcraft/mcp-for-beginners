<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-05-17T12:34:43+00:00",
  "source_file": "03-GettingStarted/06-aitk/solution/README.md",
  "language_code": "tr"
}
-->
# 📘 Ödev Çözümü: Hesap Makinesi MCP Sunucunuzu Karekök Aracı ile Genişletme

## Genel Bakış
Bu ödevde, hesap makinesi MCP sunucunuzu bir sayının karekökünü hesaplayan yeni bir araç ekleyerek geliştirdiniz. Bu ekleme, AI ajanınızın "16'nın karekökü nedir?" veya "√49'u hesapla" gibi daha ileri düzey matematiksel sorguları doğal dil istemleri kullanarak ele almasını sağlar.

## 🛠️ Karekök Aracını Uygulama
Bu işlevselliği eklemek için, server.py dosyanızda yeni bir araç fonksiyonu tanımladınız. İşte uygulama:

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

## 🔍 Nasıl Çalışır

- **`math` aracını içe aktarın.
- AI ajanınızı doğal dil istemleri aracılığıyla karekök hesaplamalarını yapabilmesi için etkinleştirdiniz.
- Yeni araçlar ekleme ve sunucuyu yeniden başlatarak ek işlevleri entegre etme pratiği yaptınız.

Ajanınızın yeteneklerini geliştirmeye devam etmek için üstel veya logaritmik fonksiyonlar gibi daha fazla matematiksel araç ekleyerek denemeler yapmaktan çekinmeyin!

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belgenin kendi dilindeki hali yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanılmasından kaynaklanan yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.