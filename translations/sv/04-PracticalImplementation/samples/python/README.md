<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:31:02+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "sv"
}
-->
# Model Context Protocol (MCP) Python-implementation

Det här arkivet innehåller en Python-implementation av Model Context Protocol (MCP), som visar hur man skapar både en server- och klientapplikation som kommunicerar med MCP-standarden.

## Översikt

MCP-implementationen består av två huvudkomponenter:

1. **MCP Server (`server.py`)** – En server som tillhandahåller:
   - **Tools**: Funktioner som kan anropas på distans
   - **Resources**: Data som kan hämtas
   - **Prompts**: Mallar för att generera prompts till språkmodeller

2. **MCP Client (`client.py`)** – En klientapplikation som ansluter till servern och använder dess funktioner

## Funktioner

Denna implementation visar flera viktiga MCP-funktioner:

### Tools
- `completion` – Genererar textkompletteringar från AI-modeller (simulerat)
- `add` – Enkel kalkylator som adderar två tal

### Resources
- `models://` – Returnerar information om tillgängliga AI-modeller
- `greeting://{name}` – Returnerar en personlig hälsning för ett givet namn

### Prompts
- `review_code` – Genererar en prompt för kodgranskning

## Installation

För att använda denna MCP-implementation, installera de nödvändiga paketen:

```powershell
pip install mcp-server mcp-client
```

## Köra Server och Klient

### Starta Servern

Kör servern i ett terminalfönster:

```powershell
python server.py
```

Servern kan även köras i utvecklingsläge med MCP CLI:

```powershell
mcp dev server.py
```

Eller installeras i Claude Desktop (om tillgängligt):

```powershell
mcp install server.py
```

### Köra Klienten

Kör klienten i ett annat terminalfönster:

```powershell
python client.py
```

Detta ansluter till servern och demonstrerar alla tillgängliga funktioner.

### Användning av Klient

Klienten (`client.py`) visar alla MCP-funktioner:

```powershell
python client.py
```

Detta ansluter till servern och testar alla funktioner inklusive tools, resources och prompts. Utdata visar:

1. Resultatet från kalkylatorn (5 + 7 = 12)
2. Svar från completions-tool på "What is the meaning of life?"
3. Lista över tillgängliga AI-modeller
4. Personlig hälsning för "MCP Explorer"
5. Mall för kodgranskningsprompt

## Implementationsdetaljer

Servern är implementerad med `FastMCP` API:et, som erbjuder högre abstraktioner för att definiera MCP-tjänster. Här är ett förenklat exempel på hur tools definieras:

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

Klienten använder MCP client-biblioteket för att ansluta till och anropa servern:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Läs Mer

För mer information om MCP, besök: https://modelcontextprotocol.io/

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen var medveten om att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.