<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:31:32+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "fi"
}
-->
# Model Context Protocol (MCP) Python -toteutus

Tämä repositorio sisältää Python-toteutuksen Model Context Protocolille (MCP), joka näyttää, miten luodaan sekä palvelin- että asiakasohjelma, jotka kommunikoivat MCP-standardin mukaisesti.

## Yleiskatsaus

MCP-toteutus koostuu kahdesta pääkomponentista:

1. **MCP Server (`server.py`)** – Palvelin, joka tarjoaa:
   - **Tools**: Etäkäytettävät funktiot
   - **Resources**: Haettavat tiedot
   - **Prompts**: Mallipohjat kehotteiden luomiseen kielimalleille

2. **MCP Client (`client.py`)** – Asiakasohjelma, joka yhdistyy palvelimeen ja hyödyntää sen toimintoja

## Ominaisuudet

Tämä toteutus havainnollistaa useita keskeisiä MCP-ominaisuuksia:

### Tools
- `completion` – Tuottaa tekstin täydennyksiä tekoälymalleista (simuloitu)
- `add` – Yksinkertainen laskin, joka laskee kahden luvun summan

### Resources
- `models://` – Palauttaa tietoa käytettävissä olevista tekoälymalleista
- `greeting://{name}` – Palauttaa henkilökohtaisen tervehdyksen annetulle nimelle

### Prompts
- `review_code` – Luo kehotepohjan koodin tarkistusta varten

## Asennus

Käyttääksesi tätä MCP-toteutusta, asenna tarvittavat paketit:

```powershell
pip install mcp-server mcp-client
```

## Palvelimen ja asiakkaan käynnistäminen

### Palvelimen käynnistäminen

Aja palvelin yhdessä komentorivissä:

```powershell
python server.py
```

Palvelin voidaan myös käynnistää kehitystilassa MCP CLI:llä:

```powershell
mcp dev server.py
```

Tai asentaa Claude Desktopiin (jos saatavilla):

```powershell
mcp install server.py
```

### Asiakkaan käynnistäminen

Aja asiakas toisessa komentorivissä:

```powershell
python client.py
```

Tämä yhdistää palvelimeen ja näyttää kaikki käytettävissä olevat ominaisuudet.

### Asiakkaan käyttö

Asiakas (`client.py`) esittelee kaikki MCP:n toiminnot:

```powershell
python client.py
```

Tämä yhdistää palvelimeen ja käyttää kaikkia ominaisuuksia, mukaan lukien työkalut, resurssit ja kehotteet. Tuloste näyttää:

1. Laskintyökalun tuloksen (5 + 7 = 12)
2. Täydennystyökalun vastauksen kysymykseen "What is the meaning of life?"
3. Luettelon käytettävissä olevista tekoälymalleista
4. Henkilökohtaisen tervehdyksen nimelle "MCP Explorer"
5. Koodin tarkistuksen kehotepohjan

## Toteutuksen yksityiskohdat

Palvelin on toteutettu `FastMCP`-API:lla, joka tarjoaa korkean tason abstraktioita MCP-palveluiden määrittelyyn. Tässä on yksinkertaistettu esimerkki työkalujen määrittelystä:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

Asiakas käyttää MCP-asiakas kirjasto yhdistääkseen ja kutsuakseen palvelinta:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Lisätietoja

Lisätietoja MCP:stä löytyy osoitteesta: https://modelcontextprotocol.io/

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.