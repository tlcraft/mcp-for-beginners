<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:02:49+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "fi"
}
-->
# Tämän esimerkin suorittaminen

Suositellaan `uv` asentamista, mutta se ei ole pakollista, katso [ohjeet](https://docs.astral.sh/uv/#highlights)

## -0- Luo virtuaalinen ympäristö

```bash
python -m venv venv
```

## -1- Aktivoi virtuaalinen ympäristö

```bash
venv\Scrips\activate
```

## -2- Asenna riippuvuudet

```bash
pip install "mcp[cli]"
```

## -3- Suorita esimerkki

```bash
python client.py
```

Sinun pitäisi nähdä tulos, joka on samanlainen kuin:

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
READING RESOURCE
                    INFO     Processing request of type ReadResourceRequest                                                                            server.py:534
CALL TOOL
                    INFO     Processing request of type CallToolRequest                                                                                server.py:534
[TextContent(type='text', text='8', annotations=None)]
```

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä AI-käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomaa, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää auktoriteettina. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.