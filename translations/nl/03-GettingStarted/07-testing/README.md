<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:45:11+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "nl"
}
-->
## Testen en Debuggen

Voordat je begint met het testen van je MCP-server, is het belangrijk om de beschikbare tools en beste praktijken voor debuggen te begrijpen. Effectief testen zorgt ervoor dat je server zich gedraagt zoals verwacht en helpt je snel problemen te identificeren en op te lossen. Het volgende gedeelte schetst aanbevolen benaderingen voor het valideren van je MCP-implementatie.

## Overzicht

Deze les behandelt hoe je de juiste testbenadering en het meest effectieve testtool selecteert.

## Leerdoelen

Aan het einde van deze les kun je:

- Verschillende benaderingen voor testen beschrijven.
- Verschillende tools gebruiken om je code effectief te testen.

## Testen van MCP-servers

MCP biedt tools om je te helpen bij het testen en debuggen van je servers:

- **MCP Inspector**: Een commandoregeltool die zowel als CLI-tool als visuele tool kan worden uitgevoerd.
- **Handmatig testen**: Je kunt een tool zoals curl gebruiken om webverzoeken uit te voeren, maar elke tool die HTTP kan uitvoeren, volstaat.
- **Unit testen**: Het is mogelijk om je favoriete testframework te gebruiken om de functies van zowel server als client te testen.

### Gebruik van MCP Inspector

We hebben het gebruik van deze tool in eerdere lessen beschreven, maar laten we er op hoog niveau over praten. Het is een tool gebouwd in Node.js en je kunt het gebruiken door het `npx` uitvoerbare bestand aan te roepen, dat de tool zelf tijdelijk downloadt en installeert en zichzelf opruimt zodra het klaar is met het uitvoeren van je verzoek.

De [MCP Inspector](https://github.com/modelcontextprotocol/inspector) helpt je:

- **Ontdekken van Servermogelijkheden**: Beschikbare bronnen, tools en prompts automatisch detecteren
- **Testen van Tooluitvoering**: Verschillende parameters proberen en reacties in real-time zien
- **Bekijken van Servermetadata**: Serverinformatie, schema's en configuraties onderzoeken

Een typische uitvoering van de tool ziet er als volgt uit:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Het bovenstaande commando start een MCP en zijn visuele interface en lanceert een lokale webinterface in je browser. Je kunt verwachten een dashboard te zien met je geregistreerde MCP-servers, hun beschikbare tools, bronnen en prompts. De interface stelt je in staat om interactief tooluitvoering te testen, servermetadata te inspecteren en realtime reacties te bekijken, waardoor het gemakkelijker wordt om je MCP-serverimplementaties te valideren en debuggen.

Hier is hoe het eruit kan zien: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.nl.png)

Je kunt deze tool ook in CLI-modus uitvoeren, in welk geval je de `--cli` attribuut toevoegt. Hier is een voorbeeld van het uitvoeren van de tool in "CLI"-modus die alle tools op de server opsomt:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Handmatig Testen

Naast het uitvoeren van de inspectortool om servermogelijkheden te testen, is een vergelijkbare benadering het uitvoeren van een client die HTTP kan gebruiken, zoals bijvoorbeeld curl.

Met curl kun je MCP-servers direct testen met HTTP-verzoeken:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Zoals je kunt zien aan het bovenstaande gebruik van curl, gebruik je een POST-verzoek om een tool aan te roepen met een payload bestaande uit de naam van de tool en zijn parameters. Gebruik de aanpak die het beste bij je past. CLI-tools zijn over het algemeen sneller in gebruik en lenen zich goed voor scripting, wat nuttig kan zijn in een CI/CD-omgeving.

### Unit Testen

Maak unit tests voor je tools en bronnen om ervoor te zorgen dat ze werken zoals verwacht. Hier is wat voorbeeld testcode.

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

De bovenstaande code doet het volgende:

- Benut het pytest-framework dat je toestaat tests te maken als functies en assert-verklaringen te gebruiken.
- Creëert een MCP-server met twee verschillende tools.
- Gebruikt de `assert`-verklaring om te controleren of aan bepaalde voorwaarden wordt voldaan.

Bekijk het [volledige bestand hier](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Gezien het bovenstaande bestand kun je je eigen server testen om ervoor te zorgen dat mogelijkheden worden gecreëerd zoals ze zouden moeten.

Alle grote SDK's hebben vergelijkbare testsecties, zodat je kunt aanpassen aan je gekozen runtime.

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Aanvullende Bronnen

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Wat Nu

- Volgende: [Deployment](/03-GettingStarted/08-deployment/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsservice [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons best doen voor nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.