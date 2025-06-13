<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:31:41+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "tr"
}
-->
# 📘 Ödev Çözümü: Hesap Makinesi MCP Sunucunuzu Karekök Aracıyla Genişletme

## Genel Bakış  
Bu ödevde, hesap makinesi MCP sunucunuzu bir sayının karekökünü hesaplayan yeni bir araç ekleyerek geliştirdiniz. Bu ekleme, yapay zeka ajanınızın "16'nın karekökü nedir?" veya "√49'u hesapla" gibi doğal dil komutlarıyla daha gelişmiş matematiksel sorguları yanıtlamasını sağlar.

## 🛠️ Karekök Aracının Uygulanması  
Bu işlevi eklemek için server.py dosyanızda yeni bir araç fonksiyonu tanımladınız. İşte uygulama:

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

- **`math.sqrt()` aracını `@server.tool()` ile içe aktardınız.  
- Yapay zeka ajanın doğal dil komutlarıyla karekök hesaplamalarını yapabilir hale geldi.  
- Yeni araçlar ekleyip sunucuyu yeniden başlatarak ek işlevsellikleri entegre etme pratiği yaptınız.  

Daha fazla matematik aracı, örneğin üs alma veya logaritma fonksiyonları ekleyerek ajanın yeteneklerini geliştirmeye devam edebilirsiniz!

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.