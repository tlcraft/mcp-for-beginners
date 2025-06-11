<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:54:46+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "fi"
}
-->
# Lesson: Web-hakum MCP-palvelimen rakentaminen

Tässä luvussa näytetään, miten rakennetaan käytännön AI-agentti, joka yhdistyy ulkoisiin API:hin, käsittelee erilaisia tietotyyppejä, hallitsee virheitä ja koordinoi useita työkaluja – kaikki tuotantovalmiissa muodossa. Näet:

- **Yhdistäminen ulkoisiin API:hin, jotka vaativat autentikoinnin**
- **Erilaisten tietotyyppien käsittely useista rajapinnoista**
- **Vankka virheenkäsittely ja lokitusstrategiat**
- **Monityökalujen orkestrointi yhdessä palvelimessa**

Lopuksi sinulla on käytännön kokemusta kaavoista ja parhaista käytännöistä, jotka ovat olennaisia edistyneille AI- ja LLM-pohjaisille sovelluksille.

## Johdanto

Tässä oppitunnissa opit rakentamaan kehittyneen MCP-palvelimen ja -asiakkaan, joka laajentaa LLM:n kykyjä reaaliaikaisella web-datalla SerpAPI:n avulla. Tämä on tärkeä taito dynaamisten AI-agenttien kehittämiseen, jotka pystyvät hakemaan ajantasaisia tietoja verkosta.

## Oppimistavoitteet

Oppitunnin lopussa osaat:

- Yhdistää ulkoisia API:ita (kuten SerpAPI) turvallisesti MCP-palvelimeen
- Toteuttaa useita työkaluja web-, uutis-, tuotehaulle ja kysymys-vastaus -toimintoihin
- Jäsentää ja muotoilla rakenteellista dataa LLM:n käyttöön sopivaksi
- Käsitellä virheitä ja hallita API-kutsujen rajoituksia tehokkaasti
- Rakentaa ja testata sekä automatisoituja että interaktiivisia MCP-asiakkaita

## Web-hakum MCP-palvelin

Tässä osassa esitellään Web-hakum MCP-palvelimen arkkitehtuuri ja ominaisuudet. Näet, miten FastMCP ja SerpAPI toimivat yhdessä laajentaen LLM:n kykyjä reaaliaikaisella web-datalla.

### Yleiskatsaus

Tämä toteutus sisältää neljä työkalua, jotka osoittavat MCP:n kyvyn käsitellä monipuolisia, ulkoisiin API:hin perustuvia tehtäviä turvallisesti ja tehokkaasti:

- **general_search**: Laajat web-hakutulokset
- **news_search**: Viimeaikaiset uutisotsikot
- **product_search**: Verkkokauppatiedot
- **qna**: Kysymys-vastaus -katkelmat

### Ominaisuudet
- **Koodiesimerkit**: Sisältää kielikohtaisia koodilohkoja Pythonille (helposti laajennettavissa muille kielille) selkeyttäviä laajennettavia osioita käyttäen

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

Ennen kuin ajat asiakasta, on hyödyllistä ymmärtää, mitä palvelin tekee. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Tässä on lyhyt esimerkki siitä, miten palvelin määrittelee ja rekisteröi työkalun:

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

- **Ulkoisten API:iden yhdistäminen**: Näyttää, miten API-avaimia ja ulkoisia pyyntöjä käsitellään turvallisesti
- **Rakenteellisen datan jäsentäminen**: Kuvaa, miten API-vastaukset muunnetaan LLM:lle sopiviksi
- **Virheenkäsittely**: Vankka virheenkäsittely asianmukaisella lokituksella
- **Interaktiivinen asiakas**: Sisältää sekä automatisoidut testit että interaktiivisen tilan testaukseen
- **Kontekstinhallinta**: Hyödyntää MCP Contextia lokitukseen ja pyyntöjen seurantaan

## Esivaatimukset

Ennen aloittamista varmista, että ympäristösi on oikein asetettu seuraavien ohjeiden mukaisesti. Tämä varmistaa, että kaikki riippuvuudet on asennettu ja API-avaimesi ovat oikein konfiguroituja sujuvaa kehitystä ja testausta varten.

- Python 3.8 tai uudempi
- SerpAPI API-avain (rekisteröidy osoitteessa [SerpAPI](https://serpapi.com/) – ilmainen taso saatavilla)

## Asennus

Aloittaaksesi seuraa näitä ohjeita ympäristön pystyttämiseksi:

1. Asenna riippuvuudet käyttäen uv (suositeltu) tai pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Luo `.env`-tiedosto projektin juureen ja lisää SerpAPI-avaimesi:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Käyttö

Web-hakum MCP-palvelin on ydinosa, joka tarjoaa työkaluja web-, uutis-, tuotehakuun ja kysymys-vastaus -toimintoihin yhdistämällä SerpAPI:n. Se käsittelee saapuvat pyynnöt, hallitsee API-kutsut, jäsentää vastaukset ja palauttaa rakenteelliset tulokset asiakkaalle.

Voit tarkastella koko toteutusta [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Palvelimen käynnistäminen

Käynnistääksesi MCP-palvelimen käytä seuraavaa komentoa:

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

Aja automatisoidut testit (käynnistää palvelimen automaattisesti):

```bash
python client.py
```

Tai aja interaktiivisessa tilassa:

```bash
python client.py --interactive
```

### Testaus eri menetelmillä

Työkaluja voi testata ja käyttää eri tavoin tarpeidesi ja työnkulun mukaan.

#### Oman testiskriptin kirjoittaminen MCP Python SDK:lla
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

Tässä yhteydessä "testiskripti" tarkoittaa omaa Python-ohjelmaa, jolla toimit MCP-palvelimen asiakkaana. Se ei ole virallinen yksikkötesti, vaan skripti, jolla voit ohjelmallisesti yhdistää palvelimeen, kutsua sen työkaluja haluamillasi parametreilla ja tarkastella tuloksia. Tämä on hyödyllistä:

- Työkalukutsujen prototypointiin ja kokeiluun
- Palvelimen vastausten validointiin eri syötteillä
- Toistuvien työkalukutsujen automatisointiin
- Oman työnkulun tai integraatioiden rakentamiseen MCP-palvelimen päälle

Testiskriptit ovat nopea tapa kokeilla uusia kyselyjä, debugata työkalujen toimintaa tai aloittaa kehittyneempi automaatio. Alla esimerkki MCP Python SDK:n käytöstä tällaisen skriptin luomiseen:

## Työkalujen kuvaukset

Voit käyttää palvelimen tarjoamia työkaluja erilaisiin haku- ja kyselytarkoituksiin. Jokainen työkalu on kuvattu alla parametreineen ja esimerkkikäyttöineen.

Tässä osiossa kerrotaan yksityiskohtaisesti jokaisesta saatavilla olevasta työkalusta ja niiden parametreista.

### general_search

Suorittaa yleisen web-haun ja palauttaa muotoillut tulokset.

**Työkalun kutsuminen:**

Voit kutsua `general_search`-työkalua omasta skriptistä MCP Python SDK:lla tai interaktiivisesti Inspectorilla tai interaktiivisella asiakastilalla. Tässä esimerkki SDK:n käytöstä:

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

Hakee viimeaikaisia uutisartikkeleita liittyen kyselyyn.

**Työkalun kutsuminen:**

Voit kutsua `news_search`-työkalua omasta skriptistä MCP Python SDK:lla tai interaktiivisesti Inspectorilla tai interaktiivisella asiakastilalla. Tässä esimerkki SDK:n käytöstä:

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

**Työkalun kutsuminen:**

Voit kutsua `product_search`-työkalua omasta skriptistä MCP Python SDK:lla tai interaktiivisesti Inspectorilla tai interaktiivisella asiakastilalla. Tässä esimerkki SDK:n käytöstä:

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

Voit kutsua `qna`-työkalua omasta skriptistä MCP Python SDK:lla tai interaktiivisesti Inspectorilla tai interaktiivisella asiakastilalla. Tässä esimerkki SDK:n käytöstä:

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
- `question` (merkkijono): Kysymys, johon haetaan vastaus

**Esimerkkipyyntö:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Koodin yksityiskohdat

Tässä osassa on koodikatkelmia ja viitteitä palvelimen ja asiakkaan toteutuksiin.

<details>
<summary>Python</summary>

Katso koko toteutus [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Tämän oppitunnin edistyneet käsitteet

Ennen rakentamisen aloittamista tässä on joitakin tärkeitä edistyneitä käsitteitä, jotka toistuvat koko luvun ajan. Niiden ymmärtäminen auttaa seuraamaan sisältöä, vaikka ne olisivat sinulle uusia:

- **Monityökalujen orkestrointi**: Tämä tarkoittaa useiden eri työkalujen (kuten web-haku, uutishaku, tuotehaku ja kysymys-vastaus) ajamista yhdessä MCP-palvelimessa. Näin palvelimesi pystyy hoitamaan monenlaisia tehtäviä, ei vain yhtä.
- **API-kutsujen rajoitusten hallinta**: Monet ulkoiset API:t (kuten SerpAPI) rajoittavat pyyntöjen määrää tietyssä ajassa. Hyvä koodi tarkistaa nämä rajat ja käsittelee ne sujuvasti, jotta sovelluksesi ei kaadu, vaikka raja tulisikin vastaan.
- **Rakenteellisen datan jäsentäminen**: API-vastaukset ovat usein monimutkaisia ja sisäkkäisiä. Tämä käsite tarkoittaa niiden muuntamista puhtaiksi ja helposti käytettäviksi muodoiksi, jotka sopivat LLM:lle tai muille ohjelmille.
- **Virheiden palautuminen**: Joskus tapahtuu virheitä – esimerkiksi verkko ei toimi tai API ei palauta odotettua. Virheiden palautuminen tarkoittaa, että koodisi pystyy käsittelemään nämä ongelmat ja antamaan hyödyllistä palautetta sen sijaan, että kaatuisi.
- **Parametrien validointi**: Tämä tarkoittaa, että tarkistetaan kaikkien työkalujen syötteiden oikeellisuus ja turvallisuus. Siihen kuuluu oletusarvojen asettaminen ja tyyppien varmistaminen, mikä auttaa estämään virheitä ja sekaannuksia.

Tämä osio auttaa sinua diagnosoimaan ja ratkaisemaan yleisiä ongelmia, joita voi ilmetä työskennellessäsi Web-hakum MCP-palvelimen kanssa. Jos kohtaat virheitä tai odottamatonta käyttäytymistä, tämä vianetsintäosio tarjoaa ratkaisuja yleisimpiin ongelmiin. Käy nämä vinkit läpi ennen lisäavun hakemista – ne usein korjaavat ongelmat nopeasti.

## Vianetsintä

Työskennellessäsi Web-hakum MCP-palvelimen kanssa saatat toisinaan kohdata ongelmia – tämä on normaalia ulkoisten API:iden ja uusien työkalujen kanssa työskennellessä. Tämä osio tarjoaa käytännön ratkaisuja yleisimpiin ongelmiin, jotta pääset nopeasti takaisin raiteille. Jos kohtaat virheen, aloita tästä: alla olevat vinkit käsittelevät eniten käyttäjien kohtaamia ongelmia ja voivat usein ratkaista ongelmasi ilman lisäapua.

### Yleisimmät ongelmat

Alla on listattu yleisimpiä ongelmia, joita käyttäjät kohtaavat, sekä selkeät selitykset ja ohjeet niiden ratkaisemiseksi:

1. **SERPAPI_KEY puuttuu .env-tiedostosta**
   - Jos näet virheen `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `, luo `.env`-tiedosto tarvittaessa. Jos avain on oikein mutta virhe jatkuu, tarkista, onko ilmainen käyttötasosi loppunut.

### Debug-tila

Oletuksena sovellus lokittaa vain tärkeät tiedot. Jos haluat nähdä yksityiskohtaisempaa tietoa tapahtumista (esimerkiksi vaikeiden ongelmien diagnosointiin), voit ottaa DEBUG-tilan käyttöön. Tämä näyttää paljon enemmän sovelluksen jokaisesta vaiheesta.

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

Huomaa, että DEBUG-tila sisältää lisärivejä HTTP-pyynnöistä, vastauksista ja muista sisäisistä yksityiskohdista. Tämä voi olla erittäin hyödyllistä vianetsinnässä.

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

- [5.10 Reaaliaikainen suoratoisto](../mcp-realtimestreaming/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ole hyvä ja huomioi, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai virhetulkinnoista.