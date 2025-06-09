<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-27T16:26:12+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "cs"
}
-->
# Model Context Protocol (MCP) Python Implementation

Detta repository innehåller en Python-implementation av Model Context Protocol (MCP), som visar hur man skapar både en server- och klientapplikation som kommunicerar med MCP-standarden.

## Översikt

MCP-implementationen består av två huvudkomponenter:

1. **MCP Server (`server.py`)** - En server som exponerar:
   - **Tools**: Funktioner som kan anropas på distans
   - **Resources**: Data som kan hämtas
   - **Prompts**: Mallar för att generera prompts för språkmodeller

2. **MCP Client (`client.py`)** - En klientapplikation som ansluter till servern och använder dess funktioner

## Funktioner

Denna implementation demonstrerar flera viktiga MCP-funktioner:

### Tools
- `completion` - Genererar textkompletteringar från AI-modeller (simulerat)
- `add` - Enkel räknare som adderar två tal

### Resources
- `models://` - Returnerar information om tillgängliga AI-modeller
- `greeting://{name}` - Returnerar en personlig hälsning för ett givet namn

### Prompts
- `review_code` - Genererar en prompt för kodgranskning

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

Servern kan också köras i utvecklingsläge med MCP CLI:

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

Detta kommer att ansluta till servern och demonstrera alla tillgängliga funktioner.

### Klientanvändning

Klienten (`client.py`) visar alla MCP-funktioner:

```powershell
python client.py
```

Detta ansluter till servern och testar alla funktioner inklusive tools, resources och prompts. Utdata visar:

1. Resultat från räknarverktyget (5 + 7 = 12)
2. Svar från kompletteringsverktyget på "What is the meaning of life?"
3. Lista över tillgängliga AI-modeller
4. Personlig hälsning för "MCP Explorer"
5. Mall för kodgranskningsprompt

## Implementationsdetaljer

Servern är implementerad med `FastMCP` API, som erbjuder högre abstraktioner för att definiera MCP-tjänster. Här är ett förenklat exempel på hur tools definieras:

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

Klienten använder MCP-klientbiblioteket för att ansluta till och anropa servern:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Läs Mer

För mer information om MCP, besök: https://modelcontextprotocol.io/

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.