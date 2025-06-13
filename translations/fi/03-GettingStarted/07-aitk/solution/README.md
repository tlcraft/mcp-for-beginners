<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e9490aedc71f99bc774af57b207a7adb",
  "translation_date": "2025-06-13T02:32:21+00:00",
  "source_file": "03-GettingStarted/07-aitk/solution/README.md",
  "language_code": "fi"
}
-->
# 📘 Tehtävän Ratkaisu: Laajenna Laskimesi MCP-palvelinta Neliöjuurityökalulla

## Yleiskatsaus
Tässä tehtävässä paransit laskimesi MCP-palvelinta lisäämällä uuden työkalun, joka laskee luvun neliöjuuren. Tämä lisäys mahdollistaa tekoälyagenttisi käsitellä monimutkaisempia matemaattisia kysymyksiä, kuten "Mikä on luvun 16 neliöjuuri?" tai "Laske √49" luonnollisilla kielenkäyttöisillä kehotteilla.

## 🛠️ Neliöjuurityökalun Toteutus
Lisätäksesi tämän toiminnallisuuden määrittelit uuden työkalufunktion server.py-tiedostossasi. Tässä toteutus:

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

## 🔍 Miten Se Toimii

- **Tuodaan `math`-moduuli ja käytetään `math.sqrt()`-funktiota `@server.tool()`-koristelijalla määritellyssä `sqrt`-työkalussa.**
- Mahdollistetaan tekoälyagenttisi suorittaa neliöjuurilaskelmia luonnollisen kielen kehotteilla.
- Harjoitellaan uusien työkalujen lisäämistä ja palvelimen uudelleenkäynnistystä lisätoimintojen integroimiseksi.

Kokeile rohkeasti lisätä lisää matemaattisia työkaluja, kuten potenssilaskenta tai logaritmifunktiot, jatkaaksesi agenttisi kyvykkyyksien kehittämistä!

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.