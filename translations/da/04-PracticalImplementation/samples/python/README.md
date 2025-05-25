<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:31:11+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "da"
}
-->
# Model Context Protocol (MCP) Python-implementering

Dette repository indeholder en Python-implementering af Model Context Protocol (MCP), som viser, hvordan man opretter både en server- og klientapplikation, der kommunikerer ved hjælp af MCP-standarden.

## Oversigt

MCP-implementeringen består af to hovedkomponenter:

1. **MCP Server (`server.py`)** – En server, der tilbyder:
   - **Tools**: Funktioner, der kan kaldes eksternt
   - **Resources**: Data, der kan hentes
   - **Prompts**: Skabeloner til at generere prompts til sprogmodeller

2. **MCP Client (`client.py`)** – En klientapplikation, der opretter forbindelse til serveren og bruger dens funktioner

## Funktioner

Denne implementering demonstrerer flere centrale MCP-funktioner:

### Tools
- `completion` – Genererer tekstfærdiggørelser fra AI-modeller (simuleret)
- `add` – Simpel lommeregner, der lægger to tal sammen

### Resources
- `models://` – Returnerer information om tilgængelige AI-modeller
- `greeting://{name}` – Returnerer en personlig hilsen til et givent navn

### Prompts
- `review_code` – Genererer en prompt til kodegennemgang

## Installation

For at bruge denne MCP-implementering, installer de nødvendige pakker:

```powershell
pip install mcp-server mcp-client
```

## Kørsel af Server og Client

### Start af Server

Kør serveren i et terminalvindue:

```powershell
python server.py
```

Serveren kan også køres i udviklingstilstand ved hjælp af MCP CLI:

```powershell
mcp dev server.py
```

Eller installeres i Claude Desktop (hvis tilgængelig):

```powershell
mcp install server.py
```

### Kørsel af Client

Kør klienten i et andet terminalvindue:

```powershell
python client.py
```

Dette vil oprette forbindelse til serveren og demonstrere alle tilgængelige funktioner.

### Brug af Client

Klienten (`client.py`) demonstrerer alle MCP’s muligheder:

```powershell
python client.py
```

Dette vil forbinde til serveren og afprøve alle funktioner, inklusive tools, resources og prompts. Outputtet viser:

1. Resultat fra lommeregner-tool (5 + 7 = 12)
2. Svar fra completion-tool på "What is the meaning of life?"
3. Liste over tilgængelige AI-modeller
4. Personlig hilsen til "MCP Explorer"
5. Skabelon til kodegennemgangsprompt

## Implementeringsdetaljer

Serveren er implementeret med `FastMCP` API’en, som tilbyder højniveau-abstraktioner til at definere MCP-tjenester. Her er et forenklet eksempel på, hvordan tools defineres:

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

Klienten bruger MCP client-biblioteket til at forbinde til og kalde serveren:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Lær Mere

For mere information om MCP, besøg: https://modelcontextprotocol.io/

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for eventuelle misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.