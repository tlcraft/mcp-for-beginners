<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:47:32+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "sk"
}
-->
## Testovanie a ladenie

Predtým, než začnete testovať váš MCP server, je dôležité porozumieť dostupným nástrojom a najlepším praktikám pre ladenie. Efektívne testovanie zabezpečuje, že váš server sa správa podľa očakávaní a pomáha vám rýchlo identifikovať a vyriešiť problémy. Nasledujúca sekcia načrtáva odporúčané prístupy na validáciu vašej MCP implementácie.

## Prehľad

Táto lekcia sa zaoberá tým, ako vybrať správny testovací prístup a najefektívnejší testovací nástroj.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Opísať rôzne prístupy k testovaniu.
- Použiť rôzne nástroje na efektívne testovanie vášho kódu.

## Testovanie MCP serverov

MCP poskytuje nástroje na pomoc pri testovaní a ladení vašich serverov:

- **MCP Inspector**: Nástroj príkazového riadku, ktorý môže byť spustený ako CLI nástroj alebo ako vizuálny nástroj.
- **Manuálne testovanie**: Môžete použiť nástroj ako curl na spúšťanie webových požiadaviek, ale akýkoľvek nástroj schopný spustiť HTTP bude postačovať.
- **Jednotkové testovanie**: Je možné použiť váš obľúbený testovací rámec na testovanie funkcií servera aj klienta.

### Použitie MCP Inspector

Použitie tohto nástroja sme popísali v predchádzajúcich lekciách, ale poďme sa na to pozrieť trochu z vyššej úrovne. Je to nástroj postavený na Node.js a môžete ho použiť zavolaním `npx` spustiteľného súboru, ktorý dočasne stiahne a nainštaluje samotný nástroj a po vykonaní vašej požiadavky sa vyčistí.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) vám pomáha:

- **Objaviť schopnosti servera**: Automaticky detekovať dostupné zdroje, nástroje a výzvy
- **Testovať vykonávanie nástrojov**: Vyskúšať rôzne parametre a vidieť odpovede v reálnom čase
- **Zobraziť metadáta servera**: Preskúmať informácie o serveri, schémy a konfigurácie

Typické spustenie nástroja vyzerá takto:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Vyššie uvedený príkaz spustí MCP a jeho vizuálne rozhranie a otvorí lokálne webové rozhranie vo vašom prehliadači. Môžete očakávať, že uvidíte panel zobrazujúci vaše registrované MCP servery, ich dostupné nástroje, zdroje a výzvy. Rozhranie vám umožňuje interaktívne testovať vykonávanie nástrojov, prezerať metadáta servera a vidieť odpovede v reálnom čase, čo uľahčuje validáciu a ladenie vašich MCP serverových implementácií.

Takto to môže vyzerať: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.sk.png)

Tento nástroj môžete tiež spustiť v režime CLI, v tom prípade pridáte atribút `--cli`. Tu je príklad spustenia nástroja v režime "CLI", ktorý zoznamuje všetky nástroje na serveri:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuálne testovanie

Okrem spustenia nástroja inspector na testovanie schopností servera, ďalším podobným prístupom je spustenie klienta schopného používať HTTP, ako napríklad curl.

S curl môžete testovať MCP servery priamo pomocou HTTP požiadaviek:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Ako vidíte z vyššie uvedeného použitia curl, použijete POST požiadavku na spustenie nástroja pomocou dátového balíka obsahujúceho názov nástroja a jeho parametre. Použite prístup, ktorý vám najviac vyhovuje. CLI nástroje všeobecne bývajú rýchlejšie na použitie a umožňujú skriptovanie, čo môže byť užitočné v prostredí CI/CD.

### Jednotkové testovanie

Vytvorte jednotkové testy pre vaše nástroje a zdroje, aby ste zabezpečili, že fungujú podľa očakávaní. Tu je nejaký príklad testovacieho kódu.

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

Predchádzajúci kód robí nasledovné:

- Využíva rámec pytest, ktorý vám umožňuje vytvárať testy ako funkcie a používať príkazy assert.
- Vytvára MCP server s dvoma rôznymi nástrojmi.
- Používa príkaz `assert` na kontrolu, že určité podmienky sú splnené.

Pozrite si [celý súbor tu](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Na základe vyššie uvedeného súboru môžete testovať váš vlastný server, aby ste zabezpečili, že schopnosti sú vytvorené tak, ako by mali byť.

Všetky hlavné SDK majú podobné testovacie sekcie, takže sa môžete prispôsobiť vášmu zvolenému runtime.

## Príklady

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Čo ďalej

- Ďalej: [Nasadenie](/03-GettingStarted/08-deployment/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou AI prekladovej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.