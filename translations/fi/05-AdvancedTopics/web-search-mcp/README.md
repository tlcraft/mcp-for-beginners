<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:18:32+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "fi"
}
-->
# Lesson: Web-hakupalvelimen MCP-palvelimen rakentaminen

Tässä luvussa näytetään, miten rakennetaan käytännön tekoälyagentti, joka yhdistyy ulkoisiin API-rajapintoihin, käsittelee monipuolisia tietotyyppejä, hallitsee virheitä ja ohjaa useita työkaluja – kaikki tuotantovalmiissa muodossa. Näet:

- **Yhdistäminen ulkoisiin API:hin, jotka vaativat todennuksen**
- **Monipuolisten tietotyyppien käsittely useista rajapinnoista**
- **Vankka virheenkäsittely ja lokitusstrategiat**
- **Usean työkalun hallinta yhdessä palvelimessa**

Lopuksi sinulla on käytännön kokemusta kuvioista ja parhaista käytännöistä, jotka ovat olennaisia kehittyneissä tekoäly- ja LLM-pohjaisissa sovelluksissa.

## Johdanto

Tässä oppitunnissa opit rakentamaan kehittyneen MCP-palvelimen ja -asiakkaan, joka laajentaa LLM:n kykyjä reaaliaikaisella verkkodatalla SerpAPI:n avulla. Tämä on tärkeä taito dynaamisten tekoälyagenttien kehittämisessä, jotka voivat hakea ajantasaisia tietoja verkosta.

## Oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Integroida ulkoisia API:ja (kuten SerpAPI) turvallisesti MCP-palvelimeen
- Toteuttaa useita työkaluja verkko-, uutis-, tuotehaulle ja kysymys-vastaus-toiminnolle
- Jäsentää ja muotoilla strukturoitua dataa LLM:n käyttöön
- Käsitellä virheitä ja hallita API-kutsujen rajoituksia tehokkaasti
- Rakentaa ja testata sekä automatisoituja että interaktiivisia MCP-asiakkaita

## Web-hakupalvelimen MCP-palvelin

Tässä osiossa esitellään Web Search MCP Serverin arkkitehtuuri ja ominaisuudet. Näet, miten FastMCP ja SerpAPI toimivat yhdessä laajentaen LLM:n kykyjä reaaliaikaisella verkkodatalla.

### Yleiskatsaus

Tämä toteutus sisältää neljä työkalua, jotka osoittavat MCP:n kyvyn käsitellä monipuolisia, ulkoisiin API:hin perustuvia tehtäviä turvallisesti ja tehokkaasti:

- **general_search**: Laajat verkkohakutulokset
- **news_search**: Viimeaikaiset uutisotsikot
- **product_search**: Verkkokaupan tuotetiedot
- **qna**: Kysymys-vastaus-pätkät

### Ominaisuudet
- **Koodiesimerkit**: Sisältää kielikohtaisia koodilohkoja Pythonille (ja helposti laajennettavissa muihin kieliin) selkeyttä varten taitettavissa osioissa

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

Ennen kuin ajat asiakasta, on hyödyllistä ymmärtää, mitä palvelin tekee. Katso [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Tässä lyhyt esimerkki siitä, miten palvelin määrittelee ja rekisteröi työkalun:

<details>  
<summary>Python Server</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **Ulkoisen API:n integrointi**: Näyttää, miten API-avaimia ja ulkoisia pyyntöjä käsitellään turvallisesti
- **Strukturoidun datan jäsentäminen**: Kuvaa, miten API-vastaukset muunnetaan LLM:lle sopivaan muotoon
- **Virheenkäsittely**: Vankka virheiden hallinta ja asianmukainen lokitus
- **Interaktiivinen asiakas**: Sisältää automatisoidut testit ja interaktiivisen tilan testaukseen
- **Kontekstinhallinta**: Käyttää MCP Contextia lokitukseen ja pyyntöjen seurantaan

## Esivaatimukset

Ennen aloittamista varmista, että ympäristösi on asetettu oikein seuraamalla näitä ohjeita. Tämä varmistaa, että kaikki riippuvuudet on asennettu ja API-avaimet on konfiguroitu sujuvaa kehitystä ja testausta varten.

- Python 3.8 tai uudempi
- SerpAPI API-avain (Rekisteröidy osoitteessa [SerpAPI](https://serpapi.com/) – ilmainen taso saatavilla)

## Asennus

Aloita seuraavasti ympäristösi määrittäminen:

1. Asenna riippuvuudet käyttäen uv (suositeltu) tai pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Luo projektin juureen `.env`-tiedosto, johon lisäät SerpAPI-avaimesi:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Käyttö

Web Search MCP Server on keskeinen komponentti, joka tarjoaa työkaluja verkko-, uutis-, tuotehakuun ja kysymys-vastaus-toimintoihin yhdistämällä SerpAPI:n. Se käsittelee saapuvat pyynnöt, hallinnoi API-kutsuja, jäsentää vastaukset ja palauttaa rakenteelliset tulokset asiakkaalle.

Voit tarkastella koko toteutusta tiedostossa [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Palvelimen käynnistäminen

Käynnistä MCP-palvelin seuraavalla komennolla:

```bash
python server.py
```

Palvelin toimii stdio-pohjaisena MCP-palvelimena, johon asiakas voi yhdistää suoraan.

### Asiakastilat

Asiakas (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Asiakkaan käynnistäminen

Suorita automatisoidut testit (käynnistää palvelimen automaattisesti):

```bash
python client.py
```

Tai aja interaktiivisessa tilassa:

```bash
python client.py --interactive
```

### Testaus eri tavoilla

Työkaluja voi testata ja käyttää eri tavoin tarpeidesi ja työnkulkujesi mukaan.

#### Omien testiskriptien kirjoittaminen MCP Python SDK:lla
Voit myös rakentaa omia testiskriptejä MCP Python SDK:lla:

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

Tässä yhteydessä "testiskripti" tarkoittaa omaa Python-ohjelmaa, jolla toimitaan MCP-palvelimen asiakkaana. Sen sijaan, että kyseessä olisi virallinen yksikkötesti, skripti mahdollistaa ohjelmallisen yhteyden palvelimeen, työkalujen kutsumisen halutuilla parametreilla ja tulosten tarkastelun. Tämä lähestymistapa on hyödyllinen:

- Työkalukutsujen prototypointiin ja kokeiluun
- Palvelimen vastausten validointiin eri syötteillä
- Toistuvien kutsujen automatisointiin
- Omien työnkulkujen tai integraatioiden rakentamiseen MCP-palvelimen päälle

Testiskriptit sopivat uusien kyselyjen nopeaan kokeiluun, työkalun toiminnan virheenkorjaukseen tai lähtökohdaksi kehittyneempään automaatioon. Alla on esimerkki MCP Python SDK:n käytöstä tällaisen skriptin luomiseksi:

## Työkalujen kuvaukset

Palvelimen tarjoamia työkaluja voi käyttää erilaisten hakujen ja kyselyiden tekemiseen. Jokainen työkalu on kuvattu alla sen parametrien ja esimerkkikäytön kanssa.

Tässä osiossa on tietoa jokaisesta käytettävissä olevasta työkalusta ja niiden parametreista.

### general_search

Suorittaa yleisen verkkohaku ja palauttaa muotoillut tulokset.

**Työkalun kutsuminen:**

Voit kutsua `general_search`-työkalua omasta skriptistä MCP Python SDK:lla tai interaktiivisesti Inspectorissa tai interaktiivisessa asiakastilassa. Tässä esimerkki SDK:n käytöstä:

<details>
<summary>Python-esimerkki</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

Vaihtoehtoisesti interaktiivisessa tilassa valitse `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (merkkijono): Hakukysely

**Esimerkkipyyntö:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Hakee viimeisimpiä uutisartikkeleita liittyen kyselyyn.

**Työkalun kutsuminen:**

Voit kutsua `news_search`-työkalua omasta skriptistä MCP Python SDK:lla tai interaktiivisesti Inspectorissa tai interaktiivisessa asiakastilassa. Tässä esimerkki SDK:n käytöstä:

<details>
<summary>Python-esimerkki</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

Vaihtoehtoisesti interaktiivisessa tilassa valitse `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (merkkijono): Hakukysely

**Esimerkkipyyntö:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Hakee tuotteita, jotka vastaavat kyselyä.

**Työkalun kutsuminen:**

Voit kutsua `product_search`-työkalua omasta skriptistä MCP Python SDK:lla tai interaktiivisesti Inspectorissa tai interaktiivisessa asiakastilassa. Tässä esimerkki SDK:n käytöstä:

<details>
<summary>Python-esimerkki</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

Vaihtoehtoisesti interaktiivisessa tilassa valitse `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (merkkijono): Tuotehakukysely

**Esimerkkipyyntö:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Hakee suoria vastauksia kysymyksiin hakukoneista.

**Työkalun kutsuminen:**

Voit kutsua `qna`-työkalua omasta skriptistä MCP Python SDK:lla tai interaktiivisesti Inspectorissa tai interaktiivisessa asiakastilassa. Tässä esimerkki SDK:n käytöstä:

<details>
<summary>Python-esimerkki</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

Vaihtoehtoisesti interaktiivisessa tilassa valitse `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (merkkijono): Kysymys, johon etsitään vastausta

**Esimerkkipyyntö:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Koodin yksityiskohdat

Tässä osiossa on koodikatkelmia ja viittauksia palvelimen ja asiakkaan toteutuksiin.

<details>
<summary>Python</summary>

Katso koko toteutus tiedostosta [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Edistyneet käsitteet tässä oppitunnissa

Ennen rakentamista tässä muutamia tärkeitä edistyneitä käsitteitä, joita esiintyy läpi luvun. Niiden ymmärtäminen auttaa seuraamaan sisältöä, vaikka ne olisivatkin uusia:

- **Usean työkalun orkestrointi**: Tämä tarkoittaa useiden eri työkalujen (kuten verkkohaku, uutishaku, tuotehaku ja kysymys-vastaus) ajamista yhdessä MCP-palvelimessa. Se mahdollistaa palvelimen hoitaa monipuolisia tehtäviä, ei vain yhtä.
- **API-kutsujen rajoitusten hallinta**: Monet ulkoiset API:t (kuten SerpAPI) rajoittavat, kuinka monta pyyntöä voi tehdä tietyssä ajassa. Hyvä koodi tarkistaa nämä rajat ja käsittelee ne sujuvasti, jotta sovellus ei kaadu rajaan törmätessään.
- **Strukturoidun datan jäsentäminen**: API-vastaukset ovat usein monimutkaisia ja sisäkkäisiä. Tämä käsite tarkoittaa, että vastaukset muutetaan selkeiksi, helposti käytettäviksi muodoiksi, jotka sopivat LLM:lle tai muille ohjelmille.
- **Virheiden palauttaminen**: Joskus tapahtuu virheitä – esimerkiksi verkko pettää tai API ei palauta odotettua. Virheiden palauttaminen tarkoittaa, että koodi osaa käsitellä nämä ongelmat ja antaa hyödyllistä palautetta sen sijaan, että kaatuisi.
- **Parametrien validointi**: Tämä tarkoittaa, että tarkistetaan, että kaikki työkalujen syötteet ovat oikein ja turvallisia käyttää. Sisältää oletusarvojen asettamisen ja tyyppien varmistamisen, mikä auttaa ehkäisemään virheitä ja sekaannuksia.

Tämä osio auttaa diagnosoimaan ja ratkaisemaan yleisiä ongelmia, joita voit kohdata työskennellessäsi Web Search MCP Serverin kanssa. Jos kohtaat virheitä tai odottamatonta käyttäytymistä, tämä vianmääritysosio tarjoaa ratkaisuja yleisimpiin ongelmiin. Tutustu näihin vinkkeihin ennen lisäavun hakemista – ne usein ratkaisevat ongelmat nopeasti.

## Vianmääritys

Työskennellessäsi Web Search MCP Serverin kanssa saatat toisinaan kohdata ongelmia – tämä on normaalia ulkoisten API:en ja uusien työkalujen kanssa työskennellessä. Tämä osio tarjoaa käytännön ratkaisuja yleisimpiin ongelmiin, jotta pääset nopeasti takaisin työskentelyyn. Jos kohtaat virheen, aloita tästä: alla olevat vinkit käsittelevät yleisimpiä käyttäjien kohtaamia ongelmia ja voivat usein ratkaista ongelmasi ilman lisäapua.

### Yleisimmät ongelmat

Alla on joitakin yleisimpiä ongelmia, joita käyttäjät kohtaavat, selkeine selityksineen ja ratkaisuohjeineen:

1. **SERPAPI_KEY puuttuu .env-tiedostosta**
   - Jos näet virheen `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``, varmista, että sinulla on `.env`-tiedosto. Jos avain on oikein, mutta virhe jatkuu, tarkista onko ilmainen tasosi loppunut.

### Debug-tila

Oletuksena sovellus lokittaa vain tärkeät tiedot. Jos haluat nähdä enemmän tietoja tapahtumista (esim. vaikeiden ongelmien diagnosointiin), voit ottaa DEBUG-tilan käyttöön. Tämä näyttää paljon enemmän tietoa sovelluksen jokaisesta vaiheesta.

**Esimerkki: Normaali tulostus**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Esimerkki: DEBUG-tulostus**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Huomaa, että DEBUG-tila sisältää lisärivejä HTTP-pyynnöistä, vastauksista ja muista sisäisistä yksityiskohdista. Tämä voi olla erittäin hyödyllistä vianmäärityksessä.

Ota DEBUG-tila käyttöön asettamalla lokitustaso DEBUG:ksi `client.py` or `server.py`-tiedoston yläosassa:

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## Mitä seuraavaksi

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää auktoritatiivisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.