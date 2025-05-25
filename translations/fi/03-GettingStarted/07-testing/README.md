<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:44:55+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "fi"
}
-->
## Testaus ja virheiden korjaaminen

Ennen kuin alat testata MCP-palvelintasi, on tärkeää ymmärtää käytettävissä olevat työkalut ja parhaat käytännöt virheiden korjaamiseen. Tehokas testaus varmistaa, että palvelimesi toimii odotetusti, ja auttaa sinua nopeasti tunnistamaan ja ratkaisemaan ongelmia. Seuraava osio esittelee suositeltuja lähestymistapoja MCP-toteutuksesi validointiin.

## Yleiskatsaus

Tässä oppitunnissa käsitellään oikean testauslähestymistavan valintaa ja tehokkaimpia testausvälineitä.

## Oppimistavoitteet

Oppitunnin lopussa pystyt:

- Kuvailemaan erilaisia testauslähestymistapoja.
- Käyttämään eri työkaluja koodisi tehokkaaseen testaukseen.

## MCP-palvelimien testaus

MCP tarjoaa työkaluja, jotka auttavat sinua testaamaan ja korjaamaan palvelimiasi:

- **MCP Inspector**: Komentorivityökalu, jota voidaan käyttää sekä CLI-työkaluna että visuaalisena työkaluna.
- **Manuaalinen testaus**: Voit käyttää työkalua kuten curl web-pyyntöjen suorittamiseen, mutta mikä tahansa HTTP:tä tukevat työkalu käy.
- **Yksikkötestaus**: Voit käyttää suosikkitestauskehystäsi palvelimen ja asiakkaan ominaisuuksien testaamiseen.

### MCP Inspectorin käyttö

Olemme kuvanneet tämän työkalun käyttöä aiemmissa oppitunneissa, mutta keskustellaan siitä hieman yleisellä tasolla. Se on Node.js:ssä rakennettu työkalu, jota voit käyttää kutsumalla `npx` -suoritettavaa tiedostoa, joka lataa ja asentaa työkalun väliaikaisesti ja puhdistaa itsensä, kun se on suorittanut pyyntösi.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) auttaa sinua:

- **Palvelimen ominaisuuksien löytämisessä**: Tunnistaa automaattisesti saatavilla olevat resurssit, työkalut ja kehotteet
- **Työkalujen suorittamisen testauksessa**: Kokeile eri parametreja ja näe vastaukset reaaliajassa
- **Palvelimen metatietojen tarkastelussa**: Tutki palvelimen tietoja, kaavioita ja asetuksia

Tyypillinen työkalun suoritus näyttää tältä:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Yllä oleva komento käynnistää MCP:n ja sen visuaalisen käyttöliittymän ja avaa paikallisen web-käyttöliittymän selaimessasi. Voit odottaa näkeväsi hallintapaneelin, jossa näkyvät rekisteröidyt MCP-palvelimesi, niiden saatavilla olevat työkalut, resurssit ja kehotteet. Käyttöliittymän avulla voit interaktiivisesti testata työkalujen suorittamista, tarkastella palvelimen metatietoja ja nähdä reaaliaikaisia vastauksia, mikä helpottaa MCP-palvelimen toteutusten validointia ja virheenkorjausta.

Tältä se voi näyttää: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.fi.png)

Voit myös suorittaa tämän työkalun CLI-tilassa, jolloin lisäät `--cli` -attribuutin. Tässä esimerkki työkalun suorittamisesta "CLI"-tilassa, joka luettelee kaikki palvelimen työkalut:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuaalinen testaus

Inspector-työkalun suorittamisen lisäksi palvelimen ominaisuuksien testaamiseksi toinen vastaava lähestymistapa on suorittaa asiakas, joka pystyy käyttämään HTTP:tä, kuten esimerkiksi curl.

Curlilla voit testata MCP-palvelimia suoraan HTTP-pyynnöillä:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Kuten yllä olevasta curlin käytöstä näet, käytät POST-pyyntöä työkalun kutsumiseen hyötykuormalla, joka koostuu työkalun nimestä ja sen parametreista. Käytä lähestymistapaa, joka sopii sinulle parhaiten. Yleisesti ottaen CLI-työkalut ovat nopeampia käyttää ja sopivat hyvin skriptattaviksi, mikä voi olla hyödyllistä CI/CD-ympäristössä.

### Yksikkötestaus

Luo yksikkötestejä työkaluillesi ja resursseille varmistaaksesi, että ne toimivat odotetusti. Tässä esimerkki testauskoodista.

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

Edellä oleva koodi tekee seuraavaa:

- Hyödyntää pytest-kehystä, jonka avulla voit luoda testejä funktioina ja käyttää assert-lauseita.
- Luo MCP-palvelimen kahdella eri työkalulla.
- Käyttää `assert`-lausetta tarkistaakseen, että tietyt ehdot täyttyvät.

Tutustu [täydelliseen tiedostoon täällä](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Edellä mainitun tiedoston avulla voit testata omaa palvelintasi varmistaaksesi, että ominaisuudet luodaan kuten niiden pitäisi.

Kaikilla suurimmilla SDK:illa on vastaavat testausosiot, joten voit mukauttaa valitsemasi ajonaikaisen ympäristön mukaan.

## Esimerkit

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Lisäresurssit

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Mitä seuraavaksi

- Seuraavaksi: [Käyttöönotto](/03-GettingStarted/08-deployment/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälyn käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää auktoritatiivisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.