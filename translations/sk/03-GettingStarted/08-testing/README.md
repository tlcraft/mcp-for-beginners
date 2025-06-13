<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:11:59+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "sk"
}
-->
## Testovanie a ladenie

Pred začatím testovania vášho MCP servera je dôležité pochopiť dostupné nástroje a osvedčené postupy pre ladenie. Efektívne testovanie zabezpečí, že váš server bude fungovať podľa očakávaní a pomôže vám rýchlo identifikovať a vyriešiť problémy. Nasledujúca sekcia popisuje odporúčané prístupy na overenie implementácie MCP.

## Prehľad

Táto lekcia sa zaoberá výberom správneho testovacieho prístupu a najefektívnejším testovacím nástrojom.

## Ciele učenia

Na konci tejto lekcie budete vedieť:

- Opísať rôzne prístupy k testovaniu.
- Použiť rôzne nástroje na efektívne testovanie vášho kódu.

## Testovanie MCP serverov

MCP poskytuje nástroje, ktoré vám pomôžu testovať a ladiť vaše servery:

- **MCP Inspector**: nástroj príkazového riadku, ktorý môžete spustiť ako CLI nástroj alebo ako vizuálny nástroj.
- **Manuálne testovanie**: môžete použiť nástroj ako curl na spúšťanie webových požiadaviek, ale stačí akýkoľvek nástroj schopný pracovať s HTTP.
- **Unit testing**: je možné použiť váš obľúbený testovací framework na testovanie funkcií servera aj klienta.

### Použitie MCP Inspector

Použitie tohto nástroja sme už popisovali v predchádzajúcich lekciách, ale poďme si to stručne zhrnúť. Je to nástroj postavený na Node.js, ktorý spustíte pomocou `npx` spustiteľného súboru, ktorý si dočasne stiahne a nainštaluje nástroj a po dokončení vášho požiadavku sa sám vyčistí.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) vám pomáha:

- **Objavovanie schopností servera**: automaticky detekuje dostupné zdroje, nástroje a výzvy
- **Testovanie spustenia nástrojov**: vyskúšajte rôzne parametre a sledujte odpovede v reálnom čase
- **Zobrazenie metadát servera**: prezrite si informácie o serveri, schémy a konfigurácie

Typické spustenie nástroja vyzerá takto:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Vyššie uvedený príkaz spustí MCP a jeho vizuálne rozhranie a otvorí lokálne webové rozhranie vo vašom prehliadači. Očakávajte, že uvidíte dashboard zobrazujúci registrované MCP servery, ich dostupné nástroje, zdroje a výzvy. Rozhranie vám umožňuje interaktívne testovať spustenie nástrojov, kontrolovať metadáta servera a sledovať odpovede v reálnom čase, čo uľahčuje overovanie a ladenie implementácií MCP serverov.

Takto to môže vyzerať: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sk.png)

Tento nástroj môžete tiež spustiť v režime CLI, kde pridáte atribút `--cli`. Tu je príklad spustenia nástroja v "CLI" režime, ktorý vypíše všetky nástroje na serveri:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuálne testovanie

Okrem spustenia inspector nástroja na testovanie schopností servera môžete použiť aj klienta schopného pracovať s HTTP, napríklad curl.

S curl môžete testovať MCP servery priamo pomocou HTTP požiadaviek:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Ako vidíte z vyššie uvedeného použitia curl, použijete POST požiadavku na vyvolanie nástroja s payloadom obsahujúcim názov nástroja a jeho parametre. Použite prístup, ktorý vám najviac vyhovuje. CLI nástroje sú všeobecne rýchlejšie na použitie a dajú sa dobre skriptovať, čo môže byť užitočné v CI/CD prostredí.

### Unit testing

Vytvorte jednotkové testy pre vaše nástroje a zdroje, aby ste sa uistili, že fungujú podľa očakávaní. Tu je príklad testovacieho kódu.

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

- Využíva pytest framework, ktorý umožňuje vytvárať testy ako funkcie a používať assert príkazy.
- Vytvára MCP Server s dvoma rôznymi nástrojmi.
- Používa `assert` príkaz na kontrolu splnenia určitých podmienok.

Pozrite si [celý súbor tu](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Na základe vyššie uvedeného súboru môžete otestovať svoj vlastný server, aby ste sa uistili, že schopnosti sú vytvorené správne.

Všetky hlavné SDK majú podobné sekcie testovania, takže ich môžete prispôsobiť svojmu vybranému runtime.

## Ukážky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ďalšie zdroje

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Čo nasleduje

- Ďalej: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, majte prosím na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.