<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:09:34+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "fi"
}
-->
## Testaus ja virheenkorjaus

Ennen kuin aloitat MCP-palvelimesi testaamisen, on tärkeää ymmärtää käytettävissä olevat työkalut ja parhaat käytännöt virheenkorjaukseen. Tehokas testaus varmistaa, että palvelimesi toimii odotetusti ja auttaa sinua tunnistamaan ja ratkaisemaan ongelmat nopeasti. Seuraavassa osiossa esitellään suositeltuja menetelmiä MCP-toteutuksesi validoimiseksi.

## Yleiskatsaus

Tässä oppitunnissa käsitellään, miten valita oikea testausmenetelmä ja tehokkain testausväline.

## Oppimistavoitteet

Oppitunnin lopuksi osaat:

- Kuvailla erilaisia testausmenetelmiä.
- Käyttää erilaisia työkaluja koodisi tehokkaaseen testaamiseen.

## MCP-palvelimien testaus

MCP tarjoaa työkaluja, jotka auttavat sinua testaamaan ja virheenkorjaamaan palvelimiasi:

- **MCP Inspector**: Komentorivityökalu, jota voi käyttää sekä CLI-työkaluna että visuaalisena työkaluna.
- **Manuaalinen testaus**: Voit käyttää esimerkiksi curl-työkalua verkkopyyntöjen suorittamiseen, mutta mikä tahansa HTTP-pyyntöjä tukeva työkalu kelpaa.
- **Yksikkötestaus**: Voit käyttää suosikkitestikehystäsi testataksesi sekä palvelimen että asiakkaan toiminnallisuuksia.

### MCP Inspectorin käyttö

Olemme kuvanneet tämän työkalun käyttöä aiemmissa oppitunneissa, mutta käydään siitä lyhyesti läpi. Työkalu on rakennettu Node.js:llä, ja voit käyttää sitä kutsumalla `npx`-suoritettavaa tiedostoa, joka lataa ja asentaa työkalun väliaikaisesti ja siivoaa itsensä käytön jälkeen.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) auttaa sinua:

- **Palvelimen ominaisuuksien tunnistamisessa**: Havaitsee automaattisesti käytettävissä olevat resurssit, työkalut ja kehotteet
- **Työkalujen suorittamisen testaamisessa**: Kokeilee erilaisia parametreja ja näyttää vastaukset reaaliajassa
- **Palvelimen metadatan tarkastelussa**: Tutkii palvelimen tietoja, skeemoja ja asetuksia

Tyypillinen työkalun käynnistys näyttää tältä:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Yllä oleva komento käynnistää MCP:n ja sen visuaalisen käyttöliittymän sekä avaa paikallisen verkkokäyttöliittymän selaimessasi. Näet hallintapaneelin, joka näyttää rekisteröidyt MCP-palvelimesi, niiden käytettävissä olevat työkalut, resurssit ja kehotteet. Käyttöliittymän avulla voit testata työkalujen suoritusta vuorovaikutteisesti, tarkastella palvelimen metatietoja ja nähdä vastaukset reaaliajassa, mikä helpottaa MCP-palvelintoteutustesi validointia ja virheenkorjausta.

Näin se voi näyttää: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fi.png)

Voit myös käyttää tätä työkalua CLI-tilassa lisäämällä `--cli`-attribuutin. Tässä esimerkki työkalun ajamisesta "CLI"-tilassa, joka listaa kaikki palvelimen työkalut:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuaalinen testaus

Inspector-työkalun käytön lisäksi toinen vastaava lähestymistapa on käyttää HTTP-pyyntöjä tukevaa asiakasta, kuten curlia.

Curlilla voit testata MCP-palvelimia suoraan HTTP-pyyntöjen avulla:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Kuten yllä olevasta curl-esimerkistä näkyy, käytät POST-pyyntöä kutsuaksesi työkalua, jonka kuormana on työkalun nimi ja sen parametrit. Valitse sinulle parhaiten sopiva tapa. Komentorivityökalut ovat yleensä nopeampia käyttää ja niitä on helppo skriptata, mikä voi olla hyödyllistä CI/CD-ympäristössä.

### Yksikkötestaus

Luo yksikkötestejä työkaluillesi ja resursseillesi varmistaaksesi, että ne toimivat odotetusti. Tässä on esimerkki testauskoodista.

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

Edellinen koodi tekee seuraavaa:

- Hyödyntää pytest-kehystä, jonka avulla voit luoda testejä funktioina ja käyttää assert-lauseita.
- Luo MCP-palvelimen, jossa on kaksi erilaista työkalua.
- Käyttää `assert`-lausetta tarkistaakseen, että tietyt ehdot täyttyvät.

Tutustu [kokonaan tiedostoon täällä](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Tämän tiedoston avulla voit testata omaa palvelintasi varmistaaksesi, että ominaisuudet luodaan oikein.

Kaikilla tärkeimmillä SDK:illa on vastaavat testausosiot, joten voit sovittaa ne valitsemaasi ajonaikaiseen ympäristöön.

## Esimerkit

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Lisäresurssit

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Mitä seuraavaksi

- Seuraava: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ota huomioon, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on katsottava auktoriteettiseksi lähteeksi. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnasta.