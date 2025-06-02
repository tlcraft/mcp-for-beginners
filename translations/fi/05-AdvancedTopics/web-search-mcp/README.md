<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T19:13:15+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "fi"
}
-->
# Lesson: Web-hakupalvelimen MCP:n rakentaminen

Tässä luvussa näytetään, miten rakennetaan käytännön AI-agentti, joka integroituu ulkoisiin API:hin, käsittelee erilaisia tietotyyppejä, hoitaa virhetilanteet ja koordinoi useita työkaluja – kaikki tuotantovalmiissa muodossa. Näet:

- **Integraation ulkoisten API:iden kanssa, jotka vaativat todennuksen**
- **Erilaisten tietotyyppien käsittelyn useista rajapinnoista**
- **Vankat virheenkäsittely- ja lokitusstrategiat**
- **Monityökalujen orkestroinnin yhdessä palvelimessa**

Lopuksi sinulla on käytännön kokemusta malleista ja parhaista käytännöistä, jotka ovat olennaisia edistyneissä AI- ja LLM-pohjaisissa sovelluksissa.

## Johdanto

Tässä oppitunnissa opit rakentamaan kehittyneen MCP-palvelimen ja -asiakkaan, joka laajentaa LLM:n kykyjä reaaliaikaisella verkkodatan haulla SerpAPI:n avulla. Tämä on tärkeä taito dynaamisten AI-agenttien kehittämiseen, jotka pystyvät hakemaan ajantasaista tietoa verkosta.

## Oppimistavoitteet

Oppitunnin lopuksi osaat:

- Integroida ulkoisia API:ita (kuten SerpAPI) turvallisesti MCP-palvelimeen
- Toteuttaa useita työkaluja verkko-, uutis-, tuotetutkimukseen ja kysymys-vastaus-toimintoihin
- Jäsentää ja muotoilla rakenteellista dataa LLM:n käyttöön sopivaksi
- Käsitellä virheitä ja hallita API-kutsujen määrärajoituksia tehokkaasti
- Rakentaa ja testata sekä automatisoituja että vuorovaikutteisia MCP-asiakkaita

## Web Search MCP Server

Tässä osiossa esitellään Web Search MCP Serverin arkkitehtuuri ja ominaisuudet. Näet, miten FastMCP ja SerpAPI toimivat yhdessä laajentaen LLM:n kykyjä reaaliaikaisella verkkodatalla.

### Yleiskuvaus

Tässä toteutuksessa on neljä työkalua, jotka osoittavat MCP:n kyvyn käsitellä monipuolisia, ulkoisiin API:hin perustuvia tehtäviä turvallisesti ja tehokkaasti:

- **general_search**: Laajoihin verkkohakuihin
- **news_search**: Viimeaikaisiin uutisotsikoihin
- **product_search**: Verkkokauppatietoihin
- **qna**: Kysymys-vastaus-pätkiin

### Ominaisuudet
- **Koodiesimerkit**: Sisältää kielikohtaiset koodilohkot Pythonille (ja helposti laajennettavissa muihin kieliin) selkeyttä tuovilla laajennettavilla osioilla

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

Ennen asiakkaan käynnistämistä on hyödyllistä ymmärtää, mitä palvelin tekee. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Alla on lyhyt esimerkki siitä, miten palvelin määrittelee ja rekisteröi työkalun:

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

- **Ulkoisen API:n integraatio**: Näyttää, miten API-avaimia ja ulkoisia pyyntöjä käsitellään turvallisesti
- **Rakenteellisen datan jäsentäminen**: Kuvaa, miten API-vastaukset muunnetaan LLM:lle sopiviksi
- **Virheenkäsittely**: Vankka virheiden käsittely ja asianmukainen lokitus
- **Vuorovaikutteinen asiakas**: Sisältää automatisoituja testejä ja vuorovaikutteisen tilan testaukseen
- **Kontekstinhallinta**: Hyödyntää MCP Contextia lokitukseen ja pyyntöjen seurantaan

## Esivaatimukset

Ennen aloittamista varmista, että ympäristösi on oikein asetettu seuraamalla näitä ohjeita. Näin varmistat, että kaikki riippuvuudet on asennettu ja API-avaimesi on konfiguroitu oikein sujuvaa kehitystä ja testausta varten.

- Python 3.8 tai uudempi
- SerpAPI API-avain (Rekisteröidy osoitteessa [SerpAPI](https://serpapi.com/) – ilmainen taso saatavilla)

## Asennus

Aloita seuraamalla näitä vaiheita ympäristösi määrittämiseksi:

1. Asenna riippuvuudet käyttäen uv:ta (suositeltu) tai pip:iä:

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

Web Search MCP Server on keskeinen komponentti, joka tarjoaa työkaluja verkko-, uutis-, tuotetutkimukseen ja kysymys-vastaus-toimintoihin integroimalla SerpAPI:n. Se käsittelee saapuvat pyynnöt, hallitsee API-kutsut, jäsentää vastaukset ja palauttaa rakenteelliset tulokset asiakkaalle.

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

Suorita automatisoidut testit (tämä käynnistää palvelimen automaattisesti):

```bash
python client.py
```

Tai aja vuorovaikutteisessa tilassa:

```bash
python client.py --interactive
```

### Testaus eri menetelmillä

Työkaluja voi testata ja käyttää monin eri tavoin tarpeidesi ja työnkulun mukaan.

#### Oman testiskriptin kirjoittaminen MCP Python SDK:lla
Voit myös rakentaa omia testiskriptejä MCP Python SDK:n avulla:

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

Tässä yhteydessä "testiskripti" tarkoittaa omaa Python-ohjelmaa, jolla toimit MCP-palvelimen asiakkaana. Sen sijaan, että kyse olisi muodollisesta yksikkötestistä, skripti antaa sinun ohjelmallisesti yhdistää palvelimeen, kutsua mitä tahansa sen työkaluista valitsemillasi parametreilla ja tarkastella tuloksia. Tämä on hyödyllistä:

- Työkalukutsujen prototypointiin ja kokeiluun
- Palvelimen vasteen validointiin eri syötteillä
- Toistuvien työkalukutsujen automatisointiin
- Oman työnkulun tai integraation rakentamiseen MCP-palvelimen päälle

Voit käyttää testiskriptejä nopeasti kokeillaksesi uusia hakuja, selvittääksesi työkalun toimintaa tai aloittaaksesi kehittyneemmän automaation. Alla esimerkki MCP Python SDK:n käytöstä skriptin luomiseen:

## Työkalujen kuvaukset

Palvelimen tarjoamia työkaluja voi käyttää erilaisten hakujen ja kyselyiden tekemiseen. Jokainen työkalu on kuvattu alla parametreineen ja esimerkkikäyttöineen.

Tässä osiossa kerrotaan yksityiskohtaisesti jokaisesta käytettävissä olevasta työkalusta ja niiden parametreista.

### general_search

Suorittaa yleisen verkkohakukyselyn ja palauttaa muotoillut tulokset.

**Näin kutsut tätä työkalua:**

Voit kutsua `general_search`-työkalua omasta skriptistäsi MCP Python SDK:n avulla tai vuorovaikutteisesti Inspectorin tai interaktiivisen asiakastilan kautta. Tässä esimerkki SDK:n käytöstä:

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

Hakee viimeaikaisia uutisartikkeleita hakukyselyn perusteella.

**Näin kutsut tätä työkalua:**

Voit kutsua `news_search`-työkalua omasta skriptistäsi MCP Python SDK:n avulla tai vuorovaikutteisesti Inspectorin tai interaktiivisen asiakastilan kautta. Tässä esimerkki SDK:n käytöstä:

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

Hakee tuotteita, jotka vastaavat hakukyselyä.

**Näin kutsut tätä työkalua:**

Voit kutsua `product_search`-työkalua omasta skriptistäsi MCP Python SDK:n avulla tai vuorovaikutteisesti Inspectorin tai interaktiivisen asiakastilan kautta. Tässä esimerkki SDK:n käytöstä:

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

**Näin kutsut tätä työkalua:**

Voit kutsua `qna`-työkalua omasta skriptistäsi MCP Python SDK:n avulla tai vuorovaikutteisesti Inspectorin tai interaktiivisen asiakastilan kautta. Tässä esimerkki SDK:n käytöstä:

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
- `question` (merkkijono): Kysymys, johon etsit vastausta

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

Ennen rakentamista tässä on muutamia tärkeitä edistyneitä käsitteitä, jotka esiintyvät koko luvun ajan. Niiden ymmärtäminen auttaa sinua pysymään mukana, vaikka ne olisivat sinulle uusia:

- **Monityökalujen orkestrointi**: Tämä tarkoittaa useiden erilaisten työkalujen (kuten verkkohaku, uutishaku, tuotetutkimus ja kysymys-vastaus) ajamista samassa MCP-palvelimessa. Se mahdollistaa palvelimen käsittelevän monipuolisia tehtäviä yhden sijaan.
- **API-kutsujen määrärajoitusten hallinta**: Monet ulkoiset API:t (kuten SerpAPI) rajoittavat, kuinka monta pyyntöä voit tehdä tietyssä ajassa. Hyvä koodi tarkistaa nämä rajat ja käsittelee ne sulavasti, jotta sovelluksesi ei kaadu rajojen ylittyessä.
- **Rakenteellisen datan jäsentäminen**: API-vastaukset ovat usein monimutkaisia ja sisäkkäisiä. Tämä käsite tarkoittaa näiden vastausten muuntamista selkeiksi, helposti käytettäviksi muodoiksi, jotka sopivat LLM:lle tai muille ohjelmille.
- **Virheiden palautuminen**: Joskus tapahtuu virheitä – verkko voi pettää tai API ei palauta odotettua. Virheiden palautuminen tarkoittaa, että koodisi osaa käsitellä nämä ongelmat ja antaa hyödyllistä palautetta kaatumisen sijaan.
- **Parametrien validointi**: Tämä tarkoittaa kaikkien työkalujen syötteiden tarkistamista oikeiksi ja turvallisiksi käyttää. Siihen kuuluu oletusarvojen asettaminen ja tyyppien varmistaminen, mikä auttaa estämään virheitä ja sekaannuksia.

Tämä osio auttaa sinua diagnosoimaan ja ratkaisemaan yleisiä ongelmia, joita voit kohdata työskennellessäsi Web Search MCP Serverin kanssa. Jos kohtaat virheitä tai odottamatonta käyttäytymistä, tämä vianmääritysosio tarjoaa ratkaisuja yleisimpiin ongelmiin. Käy nämä vinkit läpi ennen lisäavun hakemista – ne usein korjaavat ongelmat nopeasti.

## Vianmääritys

Työskennellessäsi Web Search MCP Serverin kanssa saatat toisinaan kohdata ongelmia – tämä on normaalia, kun kehität ulkoisten API:iden ja uusien työkalujen kanssa. Tämä osio tarjoaa käytännön ratkaisuja yleisimpiin ongelmiin, jotta pääset nopeasti takaisin raiteille. Jos kohtaat virheen, aloita tästä: alla olevat vinkit käsittelevät eniten käyttäjien kohtaamia ongelmia ja voivat usein ratkaista ongelmasi ilman lisäapua.

### Yleiset ongelmat

Alla on joitakin yleisimpiä käyttäjien kohtaamia ongelmia, selitykset ja ohjeet niiden ratkaisemiseksi:

1. **SERPAPI_KEY puuttuu .env-tiedostosta**
   - Jos näet virheen `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env`-tiedosto tarvittaessa. Jos avain on oikea mutta virhe jatkuu, tarkista, onko ilmainen tasosi kulunut loppuun.

### Debug-tila

Oletuksena sovellus kirjaa vain tärkeimmät tiedot. Jos haluat nähdä enemmän yksityiskohtia tapahtumista (esim. monimutkaisten ongelmien diagnosointiin), voit ottaa DEBUG-tilan käyttöön. Tämä näyttää paljon enemmän tietoa sovelluksen jokaisesta vaiheesta.

**Esimerkki: Normaali tuloste**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Esimerkki: DEBUG-tuloste**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Huomaa, että DEBUG-tila sisältää lisärivejä HTTP-pyynnöistä, vastauksista ja muista sisäisistä tiedoista. Tämä voi olla erittäin hyödyllistä vianmäärityksessä.

Ota DEBUG-tila käyttöön asettamalla lokitustaso DEBUG:ksi `client.py` or `server.py`-tiedoston alussa:

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
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai virhetulkinnoista.