<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:34:01+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "sl"
}
-->
# Model Context Protocol (MCP) Python Implementation

Ta repozitorij vsebuje Python implementacijo Model Context Protocol (MCP), ki prikazuje, kako ustvariti tako strežnik kot odjemalsko aplikacijo, ki komunicirata preko MCP standarda.

## Pregled

Implementacija MCP sestavlja dve glavni komponenti:

1. **MCP Server (`server.py`)** – strežnik, ki ponuja:
   - **Orodja**: funkcije, ki jih je mogoče klicati na daljavo
   - **Viri**: podatki, ki jih je mogoče pridobiti
   - **Pozivi**: predloge za generiranje pozivov za jezikovne modele

2. **MCP Client (`client.py`)** – odjemalska aplikacija, ki se poveže na strežnik in uporablja njegove funkcije

## Značilnosti

Ta implementacija prikazuje več ključnih funkcij MCP:

### Orodja
- `completion` – generira besedilne dokončave iz AI modelov (simulirano)
- `add` – preprost kalkulator, ki sešteje dve števili

### Viri
- `models://` – vrne informacije o razpoložljivih AI modelih
- `greeting://{name}` – vrne osebno pozdravno sporočilo za dano ime

### Pozivi
- `review_code` – generira poziv za pregled kode

## Namestitev

Za uporabo te MCP implementacije namestite potrebne pakete:

```powershell
pip install mcp-server mcp-client
```

## Zagon strežnika in odjemalca

### Zagon strežnika

Strežnik zaženite v enem terminalskem oknu:

```powershell
python server.py
```

Strežnik lahko zaženete tudi v razvojni različici z uporabo MCP CLI:

```powershell
mcp dev server.py
```

Ali ga namestite v Claude Desktop (če je na voljo):

```powershell
mcp install server.py
```

### Zagon odjemalca

Odjemalca zaženite v drugem terminalskem oknu:

```powershell
python client.py
```

S tem se povežete na strežnik in preizkusite vse razpoložljive funkcije.

### Uporaba odjemalca

Odjemalec (`client.py`) prikazuje vse MCP zmogljivosti:

```powershell
python client.py
```

S tem se povežete na strežnik in preizkusite vse funkcije, vključno z orodji, viri in pozivi. Izpis bo prikazal:

1. Rezultat kalkulatorja (5 + 7 = 12)
2. Odgovor orodja za dokončanje na vprašanje "What is the meaning of life?"
3. Seznam razpoložljivih AI modelov
4. Osebno pozdravno sporočilo za "MCP Explorer"
5. Predlogo poziva za pregled kode

## Podrobnosti implementacije

Strežnik je implementiran z uporabo `FastMCP` API-ja, ki omogoča visoko raven abstrakcije za definiranje MCP storitev. Tukaj je poenostavljen primer definicije orodij:

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

Odjemalec uporablja MCP knjižnico za povezavo in klic strežnika:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Več informacij

Za več informacij o MCP obiščite: https://modelcontextprotocol.io/

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvor nem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.