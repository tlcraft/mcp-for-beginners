<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:10:57+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "tl"
}
-->
## Testing and Debugging

Bago ka magsimulang mag-test ng iyong MCP server, mahalagang maintindihan ang mga available na tools at mga pinakamainam na paraan para mag-debug. Ang epektibong testing ay nagsisiguro na ang iyong server ay gumagana ayon sa inaasahan at tumutulong upang mabilis mong matukoy at maresolba ang mga isyu. Ang sumusunod na seksyon ay naglalahad ng mga inirerekomendang pamamaraan para i-validate ang iyong MCP implementation.

## Overview

Tinutukoy ng araling ito kung paano pumili ng tamang testing approach at ang pinakaepektibong testing tool.

## Learning Objectives

Pagkatapos ng araling ito, magagawa mong:

- Ilarawan ang iba't ibang pamamaraan para sa testing.
- Gamitin ang iba't ibang tools para epektibong i-test ang iyong code.

## Testing MCP Servers

Nagbibigay ang MCP ng mga tools para tulungan kang i-test at i-debug ang iyong mga server:

- **MCP Inspector**: Isang command line tool na maaaring patakbuhin bilang CLI tool o bilang visual tool.
- **Manual testing**: Maaari kang gumamit ng tool tulad ng curl para magpadala ng web requests, pero kahit anong tool na kayang magpatakbo ng HTTP ay pwede.
- **Unit testing**: Posibleng gamitin ang paborito mong testing framework para i-test ang mga features ng parehong server at client.

### Using MCP Inspector

Naipaliwanag na namin ang paggamit ng tool na ito sa mga nakaraang aralin pero pag-usapan natin ito nang bahagya sa mataas na antas. Ito ay isang tool na ginawa sa Node.js at maaari mo itong gamitin sa pamamagitan ng pagtawag sa `npx` executable na magda-download at mag-iinstall ng tool pansamantala at maglilinis ng sarili kapag natapos na ang iyong request.

Ang [MCP Inspector](https://github.com/modelcontextprotocol/inspector) ay tumutulong sa iyo na:

- **Matuklasan ang Kakayahan ng Server**: Awtomatikong nadedetect ang mga available na resources, tools, at prompts
- **Subukan ang Pagpapatakbo ng Tool**: Subukan ang iba't ibang parameters at makita ang mga tugon nang real-time
- **Tingnan ang Metadata ng Server**: Suriin ang impormasyon ng server, schemas, at mga configuration

Ganito ang karaniwang itsura ng pagpapatakbo ng tool:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Ang command sa itaas ay nagpapasimula ng MCP at ang visual interface nito at naglulunsad ng lokal na web interface sa iyong browser. Makikita mo ang dashboard na nagpapakita ng mga naka-register mong MCP servers, ang mga available nilang tools, resources, at prompts. Pinapayagan ka ng interface na ito na interaktibong subukan ang pagpapatakbo ng mga tool, suriin ang metadata ng server, at tingnan ang mga tugon nang real-time, na nagpapadali sa pag-validate at pag-debug ng iyong MCP server implementations.

Ganito ang maaaring itsura nito: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tl.png)

Maaari mo ring patakbuhin ang tool na ito sa CLI mode kung saan idinadagdag mo ang `--cli` attribute. Narito ang halimbawa ng pagpapatakbo ng tool sa "CLI" mode na naglilista ng lahat ng tools sa server:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manual Testing

Bukod sa pagpapatakbo ng inspector tool para subukan ang kakayahan ng server, isang katulad na pamamaraan ay ang pagpapatakbo ng client na kayang gumamit ng HTTP tulad ng curl.

Sa curl, maaari mong direktang i-test ang MCP servers gamit ang HTTP requests:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Tulad ng nakikita mo sa paggamit ng curl sa itaas, gumagamit ka ng POST request para tawagin ang isang tool gamit ang payload na binubuo ng pangalan ng tool at ang mga parameters nito. Piliin ang paraan na pinakaangkop sa iyo. Ang mga CLI tools sa pangkalahatan ay mas mabilis gamitin at madaling gawing script na kapaki-pakinabang sa isang CI/CD environment.

### Unit Testing

Gumawa ng unit tests para sa iyong mga tools at resources upang matiyak na gumagana ang mga ito ayon sa inaasahan. Narito ang halimbawa ng testing code.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

Ang code sa itaas ay gumagawa ng mga sumusunod:

- Ginagamit ang pytest framework na nagpapahintulot sa iyo na gumawa ng mga tests bilang mga function at gumamit ng assert statements.
- Lumilikha ng MCP Server na may dalawang magkakaibang tools.
- Gumagamit ng `assert` statement para suriin kung natutugunan ang ilang mga kondisyon.

Tingnan ang [buong file dito](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Batay sa file na ito, maaari mong i-test ang sarili mong server upang matiyak na ang mga kakayahan ay naitatag nang tama.

Lahat ng pangunahing SDK ay may katulad na mga seksyon para sa testing kaya maaari mong i-adjust ito sa iyong napiling runtime.

## Samples

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Additional Resources

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## What's Next

- Next: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Pagtatanggol**:  
Ang dokumentong ito ay isinalin gamit ang serbisyong AI na pagsasalin [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na nagmula sa paggamit ng pagsasaling ito.