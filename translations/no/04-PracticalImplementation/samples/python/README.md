<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:31:21+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "no"
}
-->
# Model Context Protocol (MCP) Python-implementasjon

Dette repositoriet inneholder en Python-implementasjon av Model Context Protocol (MCP), som viser hvordan man lager både en server- og klientapplikasjon som kommuniserer ved hjelp av MCP-standarden.

## Oversikt

MCP-implementasjonen består av to hovedkomponenter:

1. **MCP Server (`server.py`)** – En server som eksponerer:
   - **Verktøy**: Funksjoner som kan kalles eksternt
   - **Ressurser**: Data som kan hentes ut
   - **Prompter**: Maler for å generere prompter til språkmodeller

2. **MCP Klient (`client.py`)** – En klientapplikasjon som kobler til serveren og bruker dens funksjoner

## Funksjoner

Denne implementasjonen viser flere viktige MCP-funksjoner:

### Verktøy
- `completion` – Genererer tekstkompletteringer fra AI-modeller (simulert)
- `add` – Enkel kalkulator som legger sammen to tall

### Ressurser
- `models://` – Returnerer informasjon om tilgjengelige AI-modeller
- `greeting://{name}` – Returnerer en personlig hilsen for et gitt navn

### Prompter
- `review_code` – Genererer en prompt for kodegjennomgang

## Installasjon

For å bruke denne MCP-implementasjonen, installer de nødvendige pakkene:

```powershell
pip install mcp-server mcp-client
```

## Kjøre Server og Klient

### Starte Serveren

Kjør serveren i ett terminalvindu:

```powershell
python server.py
```

Serveren kan også kjøres i utviklingsmodus med MCP CLI:

```powershell
mcp dev server.py
```

Eller installeres i Claude Desktop (om tilgjengelig):

```powershell
mcp install server.py
```

### Kjøre Klienten

Kjør klienten i et annet terminalvindu:

```powershell
python client.py
```

Dette vil koble til serveren og demonstrere alle tilgjengelige funksjoner.

### Klientbruk

Klienten (`client.py`) demonstrerer alle MCP-muligheter:

```powershell
python client.py
```

Dette kobler til serveren og tester alle funksjoner inkludert verktøy, ressurser og prompter. Utdata vil vise:

1. Kalkulatorverktøyets resultat (5 + 7 = 12)
2. Svar fra kompletteringsverktøyet på "What is the meaning of life?"
3. Liste over tilgjengelige AI-modeller
4. Personlig hilsen til "MCP Explorer"
5. Mal for kodegjennomgangsprompt

## Implementasjonsdetaljer

Serveren er implementert med `FastMCP` API-et, som tilbyr høynivå-abstraksjoner for å definere MCP-tjenester. Her er et forenklet eksempel på hvordan verktøy defineres:

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

Klienten bruker MCP-klientbiblioteket for å koble til og kalle serveren:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Lær mer

For mer informasjon om MCP, besøk: https://modelcontextprotocol.io/

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på dets opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.