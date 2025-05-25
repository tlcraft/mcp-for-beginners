<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:32:31+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "tl"
}
-->
# Model Context Protocol (MCP) Python Implementation

Ang repository na ito ay naglalaman ng Python implementation ng Model Context Protocol (MCP), na nagpapakita kung paano gumawa ng parehong server at client application na nag-uusap gamit ang MCP standard.

## Overview

Ang MCP implementation ay binubuo ng dalawang pangunahing bahagi:

1. **MCP Server (`server.py`)** - Isang server na naglalabas ng:
   - **Tools**: Mga function na pwedeng tawagin nang remote
   - **Resources**: Data na pwedeng kunin
   - **Prompts**: Mga template para gumawa ng prompts para sa language models

2. **MCP Client (`client.py`)** - Isang client application na kumokonekta sa server at ginagamit ang mga features nito

## Features

Ipinapakita ng implementation na ito ang ilang mahahalagang MCP features:

### Tools
- `completion` - Gumagawa ng text completions mula sa AI models (simulated)
- `add` - Simpleng calculator na nagdadagdag ng dalawang numero

### Resources
- `models://` - Nagbibigay ng impormasyon tungkol sa mga available na AI models
- `greeting://{name}` - Nagbibigay ng personalized na pagbati para sa isang pangalan

### Prompts
- `review_code` - Gumagawa ng prompt para sa pagre-review ng code

## Installation

Para magamit ang MCP implementation na ito, i-install ang mga kinakailangang packages:

```powershell
pip install mcp-server mcp-client
```

## Running the Server and Client

### Starting the Server

Patakbuhin ang server sa isang terminal window:

```powershell
python server.py
```

Pwedeng patakbuhin ang server sa development mode gamit ang MCP CLI:

```powershell
mcp dev server.py
```

O i-install ito sa Claude Desktop (kung available):

```powershell
mcp install server.py
```

### Running the Client

Patakbuhin ang client sa isa pang terminal window:

```powershell
python client.py
```

Ito ay kokonekta sa server at ipapakita ang lahat ng available na features.

### Client Usage

Ipinapakita ng client (`client.py`) ang lahat ng kakayahan ng MCP:

```powershell
python client.py
```

Ito ay kokonekta sa server at gagamitin ang lahat ng features kabilang ang tools, resources, at prompts. Ang output ay magpapakita ng:

1. Resulta ng calculator tool (5 + 7 = 12)
2. Sagot ng completion tool sa "What is the meaning of life?"
3. Listahan ng mga available na AI models
4. Personalized na pagbati para sa "MCP Explorer"
5. Template ng prompt para sa pagre-review ng code

## Implementation Details

Ang server ay ginawa gamit ang `FastMCP` API, na nagbibigay ng mataas na antas na abstraction para magdefine ng MCP services. Narito ang isang pinasimpleng halimbawa kung paano dine-define ang mga tools:

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

Gumagamit ang client ng MCP client library para kumonekta at tumawag sa server:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Learn More

Para sa karagdagang impormasyon tungkol sa MCP, bisitahin: https://modelcontextprotocol.io/

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama't sinisikap naming maging tumpak ang pagsasalin, pakatandaan na maaaring may mga pagkakamali o hindi pagkakatugma ang mga awtomatikong pagsasalin. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.