<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:33:48+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "hr"
}
-->
# Model Context Protocol (MCP) Python Implementacija

Ovaj repozitorij sadrži Python implementaciju Model Context Protocol (MCP), koja pokazuje kako kreirati i serversku i klijentsku aplikaciju koje komuniciraju koristeći MCP standard.

## Pregled

MCP implementacija se sastoji od dvije glavne komponente:

1. **MCP Server (`server.py`)** - Server koji izlaže:
   - **Alate**: Funkcije koje se mogu pozivati na daljinu
   - **Resurse**: Podatke koji se mogu dohvatiti
   - **Promptove**: Predloške za generiranje promptova za jezične modele

2. **MCP Klijent (`client.py`)** - Klijentska aplikacija koja se povezuje na server i koristi njegove funkcionalnosti

## Značajke

Ova implementacija demonstrira nekoliko ključnih MCP značajki:

### Alati
- `completion` - Generira tekstualna dovršenja iz AI modela (simulirano)
- `add` - Jednostavan kalkulator koji zbraja dva broja

### Resursi
- `models://` - Vraća informacije o dostupnim AI modelima
- `greeting://{name}` - Vraća personalizirani pozdrav za zadano ime

### Promptovi
- `review_code` - Generira prompt za pregled koda

## Instalacija

Za korištenje ove MCP implementacije, instalirajte potrebne pakete:

```powershell
pip install mcp-server mcp-client
```

## Pokretanje Servera i Klijenta

### Pokretanje Servera

Pokrenite server u jednom terminal prozoru:

```powershell
python server.py
```

Server se može pokrenuti i u razvojnom načinu rada koristeći MCP CLI:

```powershell
mcp dev server.py
```

Ili instalirati u Claude Desktop (ako je dostupan):

```powershell
mcp install server.py
```

### Pokretanje Klijenta

Pokrenite klijenta u drugom terminal prozoru:

```powershell
python client.py
```

Ovo će se povezati na server i demonstrirati sve dostupne funkcije.

### Korištenje Klijenta

Klijent (`client.py`) demonstrira sve MCP mogućnosti:

```powershell
python client.py
```

Ovo će se povezati na server i isprobati sve funkcije uključujući alate, resurse i promptove. Izlaz će prikazati:

1. Rezultat kalkulatora (5 + 7 = 12)
2. Odgovor alata za dovršavanje na pitanje "What is the meaning of life?"
3. Popis dostupnih AI modela
4. Personalizirani pozdrav za "MCP Explorer"
5. Predložak prompta za pregled koda

## Detalji Implementacije

Server je implementiran koristeći `FastMCP` API, koji pruža apstrakcije visokog nivoa za definiranje MCP servisa. Evo pojednostavljenog primjera kako se definiraju alati:

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

## Saznajte Više

Za više informacija o MCP-u, posjetite: https://modelcontextprotocol.io/

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba se smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.