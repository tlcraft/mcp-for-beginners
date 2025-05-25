<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:46:41+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "sw"
}
-->
## Kupima na Kurekebisha

Kabla ya kuanza kupima seva yako ya MCP, ni muhimu kuelewa zana zilizopo na mbinu bora za kurekebisha. Kupima kwa ufanisi kunahakikisha seva yako inafanya kazi kama inavyotarajiwa na hukusaidia kutambua na kutatua masuala haraka. Sehemu ifuatayo inaelezea mbinu zinazopendekezwa za kuthibitisha utekelezaji wa MCP yako.

## Muhtasari

Somo hili linaeleza jinsi ya kuchagua mbinu sahihi ya kupima na zana bora zaidi ya kupima.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Eleza mbinu mbalimbali za kupima.
- Tumia zana tofauti kupima msimbo wako kwa ufanisi.

## Kupima Seva za MCP

MCP inatoa zana za kukusaidia kupima na kurekebisha seva zako:

- **MCP Inspector**: Chombo cha amri kinachoweza kutumika kama zana ya CLI na kama zana ya kuona.
- **Kupima kwa mkono**: Unaweza kutumia chombo kama curl kuendesha maombi ya wavuti, lakini chombo chochote kinachoweza kuendesha HTTP kitafanya kazi.
- **Kupima kwa vitengo**: Inawezekana kutumia mfumo wako wa kupima unaopendelea kupima vipengele vya seva na mteja.

### Kutumia MCP Inspector

Tumeelezea matumizi ya chombo hiki katika masomo yaliyopita lakini hebu tuzungumze kidogo kwa kiwango cha juu. Ni chombo kilichojengwa katika Node.js na unaweza kukitumia kwa kuita `npx` ambayo itapakua na kusakinisha chombo yenyewe kwa muda na itajisafisha mara tu inapomaliza kuendesha ombi lako.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) hukusaidia:

- **Gundua Uwezo wa Seva**: Tambua moja kwa moja rasilimali zinazopatikana, zana, na vidokezo
- **Jaribu Utekelezaji wa Zana**: Jaribu vigezo tofauti na uone majibu papo hapo
- **Tazama Metadata ya Seva**: Chunguza taarifa za seva, miundo, na usanidi

Mara ya kawaida ya kuendesha chombo inaonekana hivi:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Amri hapo juu huanzisha MCP na kiolesura chake cha kuona na kuzindua kiolesura cha wavuti cha ndani katika kivinjari chako. Unaweza kutarajia kuona dashibodi inayoonyesha seva zako za MCP zilizosajiliwa, zana zao zinazopatikana, rasilimali, na vidokezo. Kiolesura hukuruhusu kupima utekelezaji wa zana kwa njia ya mwingiliano, kukagua metadata ya seva, na kuona majibu ya papo hapo, na kufanya iwe rahisi kuthibitisha na kurekebisha utekelezaji wa seva yako ya MCP.

Inaweza kuonekana hivi: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.sw.png)

Unaweza pia kuendesha chombo hiki katika hali ya CLI ambapo utaongeza sifa ya `--cli`. Hapa ni mfano wa kuendesha chombo katika hali ya "CLI" ambayo inaorodhesha zana zote kwenye seva:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Kupima kwa Mkono

Mbali na kuendesha chombo cha inspector kupima uwezo wa seva, mbinu nyingine inayofanana ni kuendesha mteja anayeweza kutumia HTTP kama kwa mfano curl.

Kwa kutumia curl, unaweza kupima seva za MCP moja kwa moja kwa kutumia maombi ya HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Kama unavyoona kutoka kwa matumizi ya curl hapo juu, unatumia ombi la POST kuanzisha chombo kwa kutumia mzigo wa zana na vigezo vyake. Tumia mbinu inayokufaa zaidi. Zana za CLI kwa ujumla huwa za haraka kutumia na hutoa uwezo wa kuandikwa kwa scripts ambayo inaweza kuwa muhimu katika mazingira ya CI/CD.

### Kupima kwa Vitengo

Unda vipimo vya vitengo kwa zana na rasilimali zako ili kuhakikisha zinafanya kazi kama inavyotarajiwa. Hapa kuna mfano wa msimbo wa kupima.

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

- Inatumia mfumo wa pytest ambao hukuruhusu kuunda vipimo kama kazi na kutumia taarifa za assert.
- Inaunda Seva ya MCP yenye zana mbili tofauti.
- Inatumia taarifa ya `assert` kukagua kuwa hali fulani zimetimizwa.

Angalia faili kamili [hapa](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Kwa kuzingatia faili hapo juu, unaweza kupima seva yako mwenyewe ili kuhakikisha uwezo unaundwa kama inavyopaswa.

SDK zote kuu zina sehemu za kupima zinazofanana hivyo unaweza kurekebisha kwa muda wako uliouchagua.

## Sampuli 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Rasilimali za Ziada

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Nini Kifuatavyo

- Ifuatayo: [Uwekaji](/03-GettingStarted/08-deployment/README.md)

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya kutafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuelewana. Hati asilia katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo chenye mamlaka. Kwa habari muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatuwajibiki kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.