<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:44:42+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "no"
}
-->
## Testing and Debugging

Før du begynner å teste MCP-serveren din, er det viktig å forstå tilgjengelige verktøy og beste praksis for feilsøking. Effektiv testing sikrer at serveren din oppfører seg som forventet og hjelper deg med raskt å identifisere og løse problemer. Den følgende delen beskriver anbefalte tilnærminger for å validere MCP-implementeringen din.

## Oversikt

Denne leksjonen dekker hvordan du velger riktig testingstilnærming og det mest effektive testverktøyet.

## Læringsmål

Ved slutten av denne leksjonen vil du kunne:

- Beskrive ulike tilnærminger for testing.
- Bruke forskjellige verktøy for effektivt å teste koden din.

## Testing av MCP-servere

MCP tilbyr verktøy for å hjelpe deg med å teste og feilsøke serverne dine:

- **MCP Inspector**: Et kommandolinjeverktøy som kan kjøres både som et CLI-verktøy og som et visuelt verktøy.
- **Manuell testing**: Du kan bruke et verktøy som curl for å kjøre webforespørsler, men ethvert verktøy som kan kjøre HTTP vil fungere.
- **Enhetstesting**: Det er mulig å bruke ditt foretrukne testmiljø for å teste funksjonene til både server og klient.

### Bruk av MCP Inspector

Vi har beskrevet bruken av dette verktøyet i tidligere leksjoner, men la oss snakke litt om det på et høyt nivå. Det er et verktøy bygget i Node.js, og du kan bruke det ved å kalle `npx`-kjørbar som vil laste ned og installere verktøyet midlertidig og vil rense seg opp når det er ferdig med å kjøre forespørselen din.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) hjelper deg med å:

- **Oppdage serverkapasiteter**: Automatisk oppdage tilgjengelige ressurser, verktøy og meldinger
- **Teste verktøyutførelse**: Prøv forskjellige parametere og se svar i sanntid
- **Se servermetadata**: Undersøk serverinfo, skjemaer og konfigurasjoner

En typisk kjøring av verktøyet ser slik ut:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Ovenstående kommando starter en MCP og dens visuelle grensesnitt og lanserer et lokalt webgrensesnitt i nettleseren din. Du kan forvente å se et dashbord som viser dine registrerte MCP-servere, deres tilgjengelige verktøy, ressurser og meldinger. Grensesnittet lar deg interaktivt teste verktøyutførelse, inspisere servermetadata og se sanntidssvar, noe som gjør det lettere å validere og feilsøke MCP-serverimplementeringene dine.

Slik kan det se ut: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.no.png)

Du kan også kjøre dette verktøyet i CLI-modus, i så fall legger du til `--cli` attributt. Her er et eksempel på å kjøre verktøyet i "CLI"-modus som lister opp alle verktøyene på serveren:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuell Testing

I tillegg til å kjøre inspektorverktøyet for å teste serverkapasiteter, er en annen lignende tilnærming å kjøre en klient som kan bruke HTTP som for eksempel curl.

Med curl kan du teste MCP-servere direkte ved hjelp av HTTP-forespørsler:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Som du kan se fra ovenstående bruk av curl, bruker du en POST-forespørsel for å aktivere et verktøy ved hjelp av en nyttelast bestående av verktøyets navn og dets parametere. Bruk den tilnærmingen som passer deg best. CLI-verktøy har generelt en tendens til å være raskere å bruke og kan skriptes, noe som kan være nyttig i et CI/CD-miljø.

### Enhetstesting

Lag enhetstester for verktøyene og ressursene dine for å sikre at de fungerer som forventet. Her er noe eksempel testkode.

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

Den foregående koden gjør følgende:

- Utnytter pytest-rammeverket som lar deg lage tester som funksjoner og bruke assert-setninger.
- Oppretter en MCP-server med to forskjellige verktøy.
- Bruker `assert`-setning for å sjekke at visse betingelser er oppfylt.

Ta en titt på [den fullstendige filen her](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Gitt ovenstående fil, kan du teste din egen server for å sikre at kapasiteter blir opprettet som de skal.

Alle større SDK-er har lignende testseksjoner, så du kan tilpasse deg til din valgte kjøretid.

## Eksempler 

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python) 

## Tilleggsressurser

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Hva er neste

- Neste: [Utrulling](/03-GettingStarted/08-deployment/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.