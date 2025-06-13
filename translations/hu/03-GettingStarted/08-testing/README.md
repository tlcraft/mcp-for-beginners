<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:11:23+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "hu"
}
-->
## Tesztelés és Hibakeresés

Mielőtt elkezdenéd tesztelni az MCP szerveredet, fontos megérteni a rendelkezésre álló eszközöket és a hibakeresés legjobb gyakorlatait. A hatékony tesztelés biztosítja, hogy a szerver a várakozásoknak megfelelően működjön, és segít gyorsan azonosítani és megoldani a problémákat. A következő rész a javasolt módszereket ismerteti az MCP megvalósításod érvényesítéséhez.

## Áttekintés

Ez a lecke bemutatja, hogyan válaszd ki a megfelelő tesztelési megközelítést és a leghatékonyabb tesztelő eszközt.

## Tanulási célok

A lecke végére képes leszel:

- Leírni a tesztelés különböző megközelítéseit.
- Különböző eszközöket használni a kód hatékony teszteléséhez.

## MCP szerverek tesztelése

Az MCP eszközöket biztosít a szervereid teszteléséhez és hibakereséséhez:

- **MCP Inspector**: Parancssoros eszköz, amely CLI-ként és vizuális eszközként is használható.
- **Manuális tesztelés**: Használhatsz például curl-t webkérések futtatásához, de bármilyen HTTP képes eszköz megfelel.
- **Egységtesztelés**: Használhatod a kedvenc tesztkeretrendszered a szerver és kliens funkcióinak tesztelésére.

### MCP Inspector használata

Ezt az eszközt korábbi leckékben már bemutattuk, de most egy kicsit átfogóbb képet adunk róla. Node.js-ben készült, és az `npx` futtatható állomány meghívásával használhatod, amely ideiglenesen letölti és telepíti az eszközt, majd a kérésed lefuttatása után eltávolítja magát.

Az [MCP Inspector](https://github.com/modelcontextprotocol/inspector) segít:

- **Szerver képességek felfedezése**: Automatikusan felismeri az elérhető erőforrásokat, eszközöket és promptokat
- **Eszközök futtatásának tesztelése**: Különböző paraméterek kipróbálása és válaszok valós idejű megtekintése
- **Szerver metaadatainak megtekintése**: Információk, sémák és konfigurációk vizsgálata

Az eszköz tipikus futtatása így néz ki:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

A fenti parancs elindít egy MCP-t és annak vizuális felületét, majd elindít egy helyi webes felületet a böngésződben. Egy irányítópultot fogsz látni, amely megjeleníti a regisztrált MCP szervereidet, azok elérhető eszközeit, erőforrásait és promptjait. Az interfész lehetővé teszi az eszközök interaktív tesztelését, a szerver metaadatainak vizsgálatát és a valós idejű válaszok megtekintését, megkönnyítve az MCP szerver implementációk érvényesítését és hibakeresését.

Így nézhet ki: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hu.png)

Az eszközt CLI módban is futtathatod, ilyenkor a `--cli` kapcsolót kell megadni. Íme egy példa, amikor a szerveren elérhető összes eszközt listázza:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuális tesztelés

Az inspector eszköz használata mellett egy másik hasonló megközelítés egy HTTP-képes kliens futtatása, például curl.

Curl segítségével közvetlenül HTTP kérésekkel tesztelheted az MCP szervereket:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Ahogy a fenti curl példából látható, egy POST kéréssel hívsz meg egy eszközt, amelynek a terhelése az eszköz nevét és paramétereit tartalmazza. Használd azt a módszert, amelyik a legjobban megfelel neked. A CLI eszközök általában gyorsabbak, és könnyen szkriptelhetők, ami hasznos lehet CI/CD környezetben.

### Egységtesztelés

Készíts egységteszteket az eszközeidhez és erőforrásaidhoz, hogy megbizonyosodj arról, hogy azok a várakozásoknak megfelelően működnek. Íme egy példa tesztkód.

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

A fenti kód a következőket teszi:

- A pytest keretrendszert használja, amely lehetővé teszi, hogy függvényként hozz létre teszteket és assert állításokat használj.
- Létrehoz egy MCP szervert két különböző eszközzel.
- Az `assert` állítással ellenőrzi, hogy bizonyos feltételek teljesülnek.

Nézd meg a [teljes fájlt itt](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

A fenti fájl alapján tesztelheted a saját szervered, hogy megbizonyosodj arról, hogy a képességek megfelelően jönnek létre.

Minden jelentősebb SDK hasonló tesztelési részeket tartalmaz, így könnyen igazíthatod a választott futtatókörnyezetedhez.

## Minták

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## További források

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Mi következik

- Következő: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Felelősség kizárása**:  
Ezt a dokumentumot az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum anyanyelvű változatát tekintse a hiteles forrásnak. Kritikus információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.