<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:44:14+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "da"
}
-->
## Test og Fejlfinding

Før du begynder at teste din MCP-server, er det vigtigt at forstå de tilgængelige værktøjer og bedste praksis for fejlfinding. Effektiv test sikrer, at din server opfører sig som forventet og hjælper dig med hurtigt at identificere og løse problemer. Den følgende sektion beskriver anbefalede tilgange til at validere din MCP-implementering.

## Oversigt

Denne lektion dækker, hvordan man vælger den rigtige testtilgang og det mest effektive testværktøj.

## Læringsmål

Ved afslutningen af denne lektion vil du kunne:

- Beskrive forskellige tilgange til test.
- Bruge forskellige værktøjer til effektivt at teste din kode.

## Test af MCP-servere

MCP tilbyder værktøjer til at hjælpe dig med at teste og fejlsøge dine servere:

- **MCP Inspector**: Et kommandolinjeværktøj, der kan køres både som et CLI-værktøj og som et visuelt værktøj.
- **Manuel test**: Du kan bruge et værktøj som curl til at køre webanmodninger, men ethvert værktøj, der kan køre HTTP, vil gøre det.
- **Enhedstest**: Det er muligt at bruge din foretrukne testframework til at teste funktionerne på både server og klient.

### Brug af MCP Inspector

Vi har beskrevet brugen af dette værktøj i tidligere lektioner, men lad os tale lidt om det på et højere niveau. Det er et værktøj bygget i Node.js, og du kan bruge det ved at kalde `npx`-eksekverbar fil, som vil downloade og installere værktøjet midlertidigt og vil rydde op, når det er færdigt med at køre din anmodning.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) hjælper dig med:

- **Opdage serverfunktioner**: Automatisk registrere tilgængelige ressourcer, værktøjer og prompts
- **Test værktøjseksekvering**: Prøv forskellige parametre og se svar i realtid
- **Se servermetadata**: Undersøg serverinfo, skemaer og konfigurationer

En typisk kørsel af værktøjet ser sådan ud:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Ovenstående kommando starter en MCP og dens visuelle interface og lancerer en lokal webinterface i din browser. Du kan forvente at se et dashboard, der viser dine registrerede MCP-servere, deres tilgængelige værktøjer, ressourcer og prompts. Interfacet giver dig mulighed for interaktivt at teste værktøjseksekvering, inspicere servermetadata og se svar i realtid, hvilket gør det lettere at validere og fejlfinde dine MCP-serverimplementeringer.

Her er hvordan det kan se ud: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.da.png)

Du kan også køre dette værktøj i CLI-tilstand, hvor du tilføjer `--cli` attribut. Her er et eksempel på at køre værktøjet i "CLI" tilstand, som lister alle værktøjer på serveren:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuel Test

Udover at køre inspektorværktøjet for at teste serverfunktioner, er en anden lignende tilgang at køre en klient, der kan bruge HTTP, som for eksempel curl.

Med curl kan du teste MCP-servere direkte ved hjælp af HTTP-anmodninger:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Som du kan se fra ovenstående brug af curl, bruger du en POST-anmodning til at aktivere et værktøj ved hjælp af en payload bestående af værktøjets navn og dets parametre. Brug den tilgang, der passer dig bedst. CLI-værktøjer generelt har en tendens til at være hurtigere at bruge og egner sig til at blive scriptet, hvilket kan være nyttigt i et CI/CD-miljø.

### Enhedstest

Opret enhedstest for dine værktøjer og ressourcer for at sikre, at de fungerer som forventet. Her er noget eksempel testkode.

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

Den foregående kode gør følgende:

- Udnytter pytest framework, som lader dig oprette test som funktioner og bruge assert-udsagn.
- Opretter en MCP-server med to forskellige værktøjer.
- Bruger `assert` udsagn til at kontrollere, at visse betingelser er opfyldt.

Tag et kig på [den fulde fil her](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Givet ovenstående fil kan du teste din egen server for at sikre, at funktioner oprettes som de skal.

Alle større SDK'er har lignende testsektioner, så du kan tilpasse til din valgte runtime.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Yderligere Ressourcer

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Hvad er Næste

- Næste: [Udrulning](/03-GettingStarted/08-deployment/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Mens vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.