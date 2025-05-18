<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:47:16+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "cs"
}
-->
## Testování a ladění

Než začnete testovat svůj MCP server, je důležité porozumět dostupným nástrojům a osvědčeným postupům pro ladění. Efektivní testování zajišťuje, že se váš server chová podle očekávání, a pomáhá rychle identifikovat a řešit problémy. Následující část obsahuje doporučené přístupy pro ověření vaší implementace MCP.

## Přehled

Tato lekce se zabývá tím, jak vybrat správný přístup k testování a nejúčinnější testovací nástroj.

## Cíle učení

Na konci této lekce budete schopni:

- Popsat různé přístupy k testování.
- Používat různé nástroje k efektivnímu testování vašeho kódu.

## Testování MCP serverů

MCP poskytuje nástroje, které vám pomohou testovat a ladit vaše servery:

- **MCP Inspector**: Nástroj příkazového řádku, který lze spustit jak jako CLI nástroj, tak jako vizuální nástroj.
- **Manuální testování**: Můžete použít nástroj jako curl k provádění webových požadavků, ale jakýkoli nástroj schopný provádět HTTP požadavky bude stačit.
- **Jednotkové testování**: Je možné použít váš oblíbený testovací rámec k testování funkcí jak serveru, tak klienta.

### Použití MCP Inspector

Použití tohoto nástroje jsme popsali v předchozích lekcích, ale pojďme si o něm povědět trochu obecněji. Je to nástroj postavený na Node.js a můžete jej použít voláním `npx`, což dočasně stáhne a nainstaluje samotný nástroj a po dokončení vašeho požadavku se automaticky vyčistí.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) vám pomáhá:

- **Objevovat schopnosti serveru**: Automaticky detekovat dostupné zdroje, nástroje a prompty
- **Testovat provádění nástrojů**: Zkoušet různé parametry a vidět odpovědi v reálném čase
- **Zobrazovat metadata serveru**: Zkoumat informace o serveru, schémata a konfigurace

Typické spuštění nástroje vypadá takto:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Výše uvedený příkaz spustí MCP a jeho vizuální rozhraní a otevře lokální webové rozhraní ve vašem prohlížeči. Můžete očekávat, že uvidíte dashboard zobrazující vaše registrované MCP servery, jejich dostupné nástroje, zdroje a prompty. Rozhraní vám umožňuje interaktivně testovat provádění nástrojů, zkoumat metadata serveru a zobrazovat odpovědi v reálném čase, což usnadňuje ověřování a ladění vašich implementací MCP serveru.

Takto to může vypadat: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.cs.png)

Tento nástroj můžete také spustit v režimu CLI, v takovém případě přidáte atribut `--cli`. Zde je příklad spuštění nástroje v režimu "CLI", který vypíše všechny nástroje na serveru:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuální testování

Kromě spuštění inspektorového nástroje pro testování schopností serveru je dalším podobným přístupem spuštění klienta schopného používat HTTP, například curl.

S curl můžete testovat MCP servery přímo pomocí HTTP požadavků:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Jak můžete vidět z výše uvedeného použití curl, používáte POST požadavek k vyvolání nástroje pomocí datového obsahu obsahujícího název nástroje a jeho parametry. Použijte přístup, který vám nejlépe vyhovuje. CLI nástroje obecně bývají rychlejší na použití a umožňují skriptování, což může být užitečné v prostředí CI/CD.

### Jednotkové testování

Vytvořte jednotkové testy pro vaše nástroje a zdroje, abyste zajistili, že fungují podle očekávání. Zde je ukázkový testovací kód.

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

Předchozí kód dělá následující:

- Využívá rámec pytest, který vám umožňuje vytvářet testy jako funkce a používat příkazy assert.
- Vytváří MCP server se dvěma různými nástroji.
- Používá příkaz `assert`, aby zkontroloval, že určité podmínky jsou splněny.

Podívejte se na [celý soubor zde](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Na základě výše uvedeného souboru můžete testovat svůj vlastní server, abyste zajistili, že schopnosti jsou vytvořeny, jak by měly být.

Všechny hlavní SDK mají podobné testovací sekce, takže se můžete přizpůsobit vybranému runtime.

## Ukázky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Další zdroje

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Co dál

- Další: [Nasazení](/03-GettingStarted/08-deployment/README.md)

**Prohlášení**:  
Tento dokument byl přeložen pomocí služby AI překladatele [Co-op Translator](https://github.com/Azure/co-op-translator). Ačkoli se snažíme o přesnost, prosím, mějte na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo chybné interpretace vyplývající z použití tohoto překladu.