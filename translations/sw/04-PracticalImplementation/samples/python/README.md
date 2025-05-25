<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:32:39+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "sw"
}
-->
# Model Context Protocol (MCP) Python Implementation

Hii repository ina utekelezaji wa Python wa Model Context Protocol (MCP), ikionyesha jinsi ya kuunda programu za server na client zinazozungumza kwa kutumia kiwango cha MCP.

## Muhtasari

Utekelezaji wa MCP una vipengele viwili vikuu:

1. **MCP Server (`server.py`)** - Server inayotoa:
   - **Tools**: Kazi zinazoweza kuitwa kwa mbali
   - **Resources**: Data inayoweza kupatikana
   - **Prompts**: Violezo vya kuunda prompts kwa model za lugha

2. **MCP Client (`client.py`)** - Programu ya client inayounganisha na server na kutumia vipengele vyake

## Vipengele

Utekelezaji huu unaonyesha vipengele muhimu vya MCP:

### Tools
- `completion` - Inazalisha maandishi ya kukamilisha kutoka kwa modeli za AI (simulated)
- `add` - Calculator rahisi inayoongeza nambari mbili

### Resources
- `models://` - Inarudisha taarifa kuhusu modeli za AI zinazopatikana
- `greeting://{name}` - Inarudisha salamu binafsi kwa jina lililotolewa

### Prompts
- `review_code` - Inazalisha prompt ya ukaguzi wa msimbo

## Ufungaji

Ili kutumia utekelezaji huu wa MCP, install vifurushi vinavyohitajika:

```powershell
pip install mcp-server mcp-client
```

## Kuendesha Server na Client

### Kuanza Server

Endesha server kwenye dirisha moja la terminal:

```powershell
python server.py
```

Server pia inaweza kuendeshwa katika mode ya maendeleo kwa kutumia MCP CLI:

```powershell
mcp dev server.py
```

Au kusakinishwa kwenye Claude Desktop (ikiwa inapatikana):

```powershell
mcp install server.py
```

### Kuendesha Client

Endesha client kwenye dirisha lingine la terminal:

```powershell
python client.py
```

Hii itaunganisha na server na kuonyesha vipengele vyote vinavyopatikana.

### Matumizi ya Client

Client (`client.py`) inaonyesha uwezo wote wa MCP:

```powershell
python client.py
```

Hii itaunganisha na server na kutumia vipengele vyote ikiwemo tools, resources, na prompts. Matokeo yataonyesha:

1. Jibu la tool ya calculator (5 + 7 = 12)
2. Jibu la tool ya completion kwa "What is the meaning of life?"
3. Orodha ya modeli za AI zinazopatikana
4. Salamu binafsi kwa "MCP Explorer"
5. Kiolezo cha prompt ya ukaguzi wa msimbo

## Maelezo ya Utekelezaji

Server imeandikwa kwa kutumia API ya `FastMCP`, inayotoa viwango vya juu vya kufafanua huduma za MCP. Hapa kuna mfano rahisi wa jinsi tools zinavyofafanuliwa:

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

Client inatumia maktaba ya MCP client kuungana na kuitisha server:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Jifunze Zaidi

Kwa maelezo zaidi kuhusu MCP, tembelea: https://modelcontextprotocol.io/

**Kiadhibu**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za moja kwa moja zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu na ya binadamu inashauriwa. Hatubeba dhamana kwa kutafsiri vibaya au kutoelewana kunakotokana na matumizi ya tafsiri hii.