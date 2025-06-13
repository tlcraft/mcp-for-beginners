<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:11:10+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "sw"
}
-->
## Kupima na Kurekebisha Makosa

Kabla ya kuanza kupima server yako ya MCP, ni muhimu kuelewa zana zinazopatikana na mbinu bora za kurekebisha makosa. Kupima kwa ufanisi kunahakikisha server yako inafanya kazi kama inavyotarajiwa na kukusaidia kutambua na kutatua matatizo haraka. Sehemu inayofuata inaelezea mbinu zinazopendekezwa za kuthibitisha utekelezaji wako wa MCP.

## Muhtasari

Somo hili linashughulikia jinsi ya kuchagua njia sahihi ya kupima na zana bora zaidi za kupima.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Eleza mbinu mbalimbali za kupima.
- Tumia zana tofauti kupima msimbo wako kwa ufanisi.

## Kupima Servers za MCP

MCP inatoa zana kusaidia kupima na kurekebisha makosa ya servers zako:

- **MCP Inspector**: Zana ya mstari wa amri inayoweza kutumika kama CLI na pia kama zana ya kuona.
- **Kupima kwa mkono**: Unaweza kutumia zana kama curl kufanya maombi ya wavuti, lakini zana yoyote inayoweza kufanya HTTP itatosha.
- **Kupima kwa vitengo**: Inawezekana kutumia mfumo wa kupima unaoupenda kupima vipengele vya server na mteja.

### Kutumia MCP Inspector

Tumeelezea matumizi ya zana hii katika masomo yaliyopita lakini hebu tuzungumze kidogo kwa muhtasari. Ni zana iliyojengwa kwa Node.js na unaweza kuitumia kwa kuita kiendeshi cha `npx` ambacho kitasakinisha na kupakua zana hiyo kwa muda mfupi na kisha kujisafisha baada ya kukamilisha ombi lako.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) inakusaidia:

- **Gundua Uwezo wa Server**: Kugundua moja kwa moja rasilimali, zana, na maelekezo yanayopatikana
- **Jaribu Uendeshaji wa Zana**: Jaribu vigezo tofauti na uone majibu papo hapo
- **Tazama Metadata ya Server**: Chunguza taarifa za server, schema, na usanidi

Matumizi ya kawaida ya zana yanaonekana kama ifuatavyo:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Amri hapo juu huanzisha MCP na kiolesura chake cha kuona na kuanzisha kiolesura cha wavuti cha ndani kwenye kivinjari chako. Unaweza kutegemea kuona dashibodi inayonyesha servers zako za MCP zilizosajiliwa, zana zao zinazopatikana, rasilimali, na maelekezo. Kiolesura hiki hukuwezesha kupima utekelezaji wa zana kwa njia ya mwingiliano, kuchunguza metadata ya server, na kuona majibu papo hapo, jambo linalorahisisha kuthibitisha na kurekebisha makosa katika utekelezaji wa MCP wako.

Hapa ni mfano wa muonekano wake: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sw.png)

Unaweza pia kuendesha zana hii katika hali ya CLI kwa kuongeza sifa `--cli`. Hapa kuna mfano wa kuendesha zana katika hali ya "CLI" inayoorodhesha zana zote kwenye server:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Kupima kwa Mkono

Mbali na kuendesha zana ya inspector kupima uwezo wa server, njia nyingine inayofanana ni kuendesha mteja anayeweza kutumia HTTP kama vile curl.

Kwa kutumia curl, unaweza kupima servers za MCP moja kwa moja kwa maombi ya HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Kama unavyoona kutoka kwa matumizi hapo juu ya curl, unatumia ombi la POST kuitisha zana kwa kutumia data inayojumuisha jina la zana na vigezo vyake. Tumia njia inayokufaa zaidi. Zana za CLI kwa ujumla huwa haraka zaidi kutumia na zinafaa kuandaliwa kwa maandishi ambayo inaweza kuwa muhimu katika mazingira ya CI/CD.

### Kupima kwa Vitengo

Tengeneza vipimo vya vitengo kwa zana na rasilimali zako kuhakikisha zinafanya kazi kama inavyotarajiwa. Hapa kuna mfano wa msimbo wa kupima.

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

Msimbo uliotangulia hufanya yafuatayo:

- Unatumia mfumo wa pytest unaokuwezesha kutengeneza vipimo kama kazi na kutumia kauli za assert.
- Hutengeneza MCP Server yenye zana mbili tofauti.
- Inatumia kauli ya `assert` kukagua kuwa masharti fulani yamekutana.

Tazama [faili kamili hapa](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Kwa kuzingatia faili hapo juu, unaweza kupima server yako mwenyewe kuhakikisha uwezo umeundwa kama inavyopaswa.

SDK zote kuu zina sehemu zinazofanana za kupima hivyo unaweza kubadilisha kwa runtime unayotumia.

## Sampuli

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Nini Kifuatacho

- Ifuatayo: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Kiadhibu**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za moja kwa moja zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatuna wajibu wowote kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.