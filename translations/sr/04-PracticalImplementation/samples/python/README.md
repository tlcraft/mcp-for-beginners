<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:33:40+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "sr"
}
-->
# Model Context Protocol (MCP) Python implementacija

Ovaj repozitorijum sadrži Python implementaciju Model Context Protocol-a (MCP), koja pokazuje kako napraviti i serversku i klijentsku aplikaciju koje komuniciraju koristeći MCP standard.

## Pregled

MCP implementacija se sastoji od dva glavna dela:

1. **MCP Server (`server.py`)** - Server koji izlaže:
   - **Alate**: Funkcije koje se mogu pozivati na daljinu
   - **Resurse**: Podatke koje je moguće preuzeti
   - **Promptove**: Šablone za generisanje promptova za jezičke modele

2. **MCP Klijent (`client.py`)** - Klijentska aplikacija koja se povezuje na server i koristi njegove funkcionalnosti

## Funkcionalnosti

Ova implementacija prikazuje nekoliko ključnih MCP funkcija:

### Alati
- `completion` - Generiše tekstualne dopune pomoću AI modela (simulirano)
- `add` - Jednostavan kalkulator koji sabira dva broja

### Resursi
- `models://` - Vraća informacije o dostupnim AI modelima
- `greeting://{name}` - Vraća personalizovani pozdrav za dato ime

### Promptovi
- `review_code` - Generiše prompt za pregled koda

## Instalacija

Da biste koristili ovu MCP implementaciju, instalirajte potrebne pakete:

```powershell
pip install mcp-server mcp-client
```

## Pokretanje servera i klijenta

### Pokretanje servera

Pokrenite server u jednom terminal prozoru:

```powershell
python server.py
```

Server se takođe može pokrenuti u razvojnom režimu koristeći MCP CLI:

```powershell
mcp dev server.py
```

Ili instalirati u Claude Desktop (ako je dostupan):

```powershell
mcp install server.py
```

### Pokretanje klijenta

Pokrenite klijenta u drugom terminal prozoru:

```powershell
python client.py
```

Ovo će uspostaviti vezu sa serverom i demonstrirati sve dostupne funkcije.

### Korišćenje klijenta

Klijent (`client.py`) prikazuje sve MCP mogućnosti:

```powershell
python client.py
```

Ovo će se povezati sa serverom i isprobati sve funkcije uključujući alate, resurse i promptove. Rezultati će prikazati:

1. Rezultat kalkulator alata (5 + 7 = 12)
2. Odgovor alata za dopunu na pitanje "What is the meaning of life?"
3. Listu dostupnih AI modela
4. Personalizovani pozdrav za "MCP Explorer"
5. Šablon prompta za pregled koda

## Detalji implementacije

Server je implementiran korišćenjem `FastMCP` API-ja, koji pruža apstrakcije visokog nivoa za definisanje MCP servisa. Evo pojednostavljenog primera kako se definišu alati:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

Klijent koristi MCP klijentsku biblioteku za povezivanje i pozivanje servera:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Saznajte više

Za više informacija o MCP-u posetite: https://modelcontextprotocol.io/

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде прецизан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне тумачења настала употребом овог превода.