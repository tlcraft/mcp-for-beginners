<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:48:53+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "sl"
}
-->
## Testiranje in odpravljanje napak

Preden začnete testirati vaš MCP strežnik, je pomembno razumeti razpoložljiva orodja in najboljše prakse za odpravljanje napak. Učinkovito testiranje zagotavlja, da se vaš strežnik obnaša po pričakovanjih in vam pomaga hitro prepoznati ter rešiti težave. Naslednji razdelek opisuje priporočene pristope za validacijo vaše MCP implementacije.

## Pregled

Ta lekcija pokriva, kako izbrati pravi pristop k testiranju in najučinkovitejše orodje za testiranje.

## Cilji učenja

Na koncu te lekcije boste sposobni:

- Opisati različne pristope k testiranju.
- Uporabiti različna orodja za učinkovito testiranje vaše kode.

## Testiranje MCP strežnikov

MCP ponuja orodja, ki vam pomagajo testirati in odpravljati napake na vaših strežnikih:

- **MCP Inspector**: Orodje za ukazno vrstico, ki se lahko uporablja tako kot CLI orodje kot vizualno orodje.
- **Ročno testiranje**: Lahko uporabite orodje, kot je curl, za izvajanje spletnih zahtevkov, vendar bo ustrezalo vsako orodje, ki je sposobno izvajati HTTP.
- **Enotno testiranje**: Možno je uporabiti vaš najljubši testni okvir za testiranje funkcij strežnika in klienta.

### Uporaba MCP Inspectorja

Uporabo tega orodja smo opisali v prejšnjih lekcijah, vendar se pogovorimo o tem na splošno. Gre za orodje, zgrajeno v Node.js, in ga lahko uporabite tako, da pokličete `npx` izvršljivo datoteko, ki bo začasno prenesla in namestila samo orodje ter se sama očistila, ko bo končala z izvajanjem vaše zahteve.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) vam pomaga:

- **Odkriti zmogljivosti strežnika**: Samodejno zazna razpoložljive vire, orodja in pozive
- **Testiranje izvajanja orodij**: Preizkusite različne parametre in si oglejte odzive v realnem času
- **Pregled metapodatkov strežnika**: Preučite informacije o strežniku, sheme in konfiguracije

Tipičen zagon orodja izgleda takole:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Zgornji ukaz zažene MCP in njegovo vizualno vmesnik ter odpre lokalni spletni vmesnik v vašem brskalniku. Pričakujete lahko, da boste videli nadzorno ploščo, ki prikazuje vaše registrirane MCP strežnike, njihove razpoložljive alate, vire in pozive. Vmesnik vam omogoča interaktivno testiranje izvajanja orodij, pregledovanje metapodatkov strežnika in ogled odzivov v realnem času, kar olajša validacijo in odpravljanje napak vaših MCP implementacij strežnikov.

Tako lahko izgleda: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.sl.png)

To orodje lahko zaženete tudi v CLI načinu, pri čemer dodate atribut `--cli`. Tukaj je primer zagona orodja v "CLI" načinu, ki navaja vsa orodja na strežniku:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Ročno testiranje

Poleg zagona orodja za inšpektor za testiranje zmogljivosti strežnika je podoben pristop zagnati klienta, ki je sposoben uporabljati HTTP, kot na primer curl.

S curlom lahko neposredno testirate MCP strežnike z uporabo HTTP zahtevkov:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Kot lahko vidite iz zgornje uporabe curla, uporabite zahtevo POST za izvedbo orodja z uporabo vsebine, ki vsebuje ime orodja in njegove parametre. Uporabite pristop, ki vam najbolj ustreza. CLI orodja so na splošno hitrejša za uporabo in se lahko skriptirajo, kar je lahko uporabno v okolju CI/CD.

### Enotno testiranje

Ustvarite enotne teste za vaša orodja in vire, da zagotovite, da delujejo po pričakovanjih. Tukaj je nekaj primerov testne kode.

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

Predhodna koda naredi naslednje:

- Izkoristi okvir pytest, ki vam omogoča ustvarjanje testov kot funkcij in uporabo assert stavkov.
- Ustvari MCP strežnik z dvema različnima orodjema.
- Uporabi `assert` stavek, da preveri, ali so določeni pogoji izpolnjeni.

Oglejte si [celotno datoteko tukaj](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Glede na zgornjo datoteko lahko testirate svoj strežnik, da zagotovite, da se zmogljivosti ustvarijo, kot bi morale.

Vse večje SDK-ji imajo podobne testne razdelke, zato se lahko prilagodite izbranemu okolju izvajanja.

## Primeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python) 

## Dodatni viri

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Kaj sledi

- Naslednje: [Namestitev](/03-GettingStarted/08-deployment/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve AI za prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v svojem maternem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije se priporoča profesionalni človeški prevod. Ne odgovarjamo za morebitne nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.