<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:22:38+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "sw"
}
-->
# Lesson: Kujenga Server ya Utafutaji Mtandao wa MCP

Sura hii inaonyesha jinsi ya kujenga wakala halisi wa AI unaounganisha na API za nje, kushughulikia aina mbalimbali za data, kusimamia makosa, na kuendesha zana nyingi—yote kwa muundo unaotumika katika uzalishaji. Utaona:

- **Ushirikiano na API za nje zinazohitaji uthibitishaji**
- **Kushughulikia aina mbalimbali za data kutoka kwa vyanzo vingi**
- **Mbinu thabiti za kushughulikia makosa na kuandika kumbukumbu**
- **Uendeshaji wa zana nyingi katika server moja**

Mwisho wa somo, utakuwa na uzoefu wa vitendo na mifumo bora inayohitajika kwa matumizi ya AI ya hali ya juu na programu zinazotumia LLM.

## Utangulizi

Katika somo hili, utajifunza jinsi ya kujenga server na mteja wa MCP wa hali ya juu ambao huongeza uwezo wa LLM kwa data ya mtandao kwa wakati halisi kwa kutumia SerpAPI. Hii ni ujuzi muhimu kwa kuunda mawakala wa AI yanayoweza kupata taarifa za hivi karibuni mtandaoni.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kuunganisha API za nje (kama SerpAPI) kwa usalama kwenye server ya MCP
- Kutekeleza zana nyingi kwa ajili ya utafutaji mtandao, habari, bidhaa, na maswali-jawabu
- Kuchambua na kuandaa data iliyopangwa kwa matumizi ya LLM
- Kushughulikia makosa na kusimamia viwango vya maombi kwa ufanisi
- Kujenga na kujaribu wateja wa MCP wa moja kwa moja na wa mwingiliano

## Server ya Utafutaji Mtandao ya MCP

Sehemu hii inaonyesha usanifu na sifa za Server ya Utafutaji Mtandao ya MCP. Utaona jinsi FastMCP na SerpAPI vinavyotumika pamoja kuongeza uwezo wa LLM kwa data ya mtandao kwa wakati halisi.

### Muhtasari

Utekelezaji huu una zana nne zinazothibitisha uwezo wa MCP kushughulikia kazi mbalimbali zinazotegemea API za nje kwa usalama na ufanisi:

- **general_search**: Kwa matokeo mapana ya mtandao
- **news_search**: Kwa vichwa vya habari vya hivi karibuni
- **product_search**: Kwa data za e-commerce
- **qna**: Kwa vipande vya maswali na majibu

### Sifa
- **Mifano ya Msimbo**: Inajumuisha sehemu za msimbo maalum kwa lugha ya Python (na rahisi kuongeza lugha nyingine) kwa kutumia sehemu zinazoweza kufichwa ili kufafanua vizuri

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

Kabla ya kuendesha mteja, ni muhimu kuelewa kile server inachofanya. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Hapa kuna mfano mfupi wa jinsi server inavyofafanua na kusajili zana:

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

- **Ushirikiano na API za Nje**: Inaonyesha jinsi ya kushughulikia funguo za API na maombi ya nje kwa usalama
- **Uchambuzi wa Data Iliyo Pangiliwa**: Inaonyesha jinsi ya kubadilisha majibu ya API kuwa muundo unaofaa kwa LLM
- **Kushughulikia Makosa**: Kushughulikia makosa kwa nguvu pamoja na kuandika kumbukumbu ipasavyo
- **Mteja wa Mwingiliano**: Inajumuisha majaribio ya moja kwa moja na hali ya mwingiliano kwa ajili ya majaribio
- **Usimamizi wa Muktadha**: Inatumia MCP Context kwa ajili ya kuandika kumbukumbu na kufuatilia maombi

## Mahitaji ya Awali

Kabla ya kuanza, hakikisha mazingira yako yamewekwa ipasavyo kwa kufuata hatua hizi. Hii itahakikisha kwamba tegemezi zote zimewekwa na funguo zako za API zimepangwa kwa usahihi kwa maendeleo na majaribio bila matatizo.

- Python 3.8 au zaidi
- Funguo ya SerpAPI (Jisajili kwenye [SerpAPI](https://serpapi.com/) - kiwango cha bure kinapatikana)

## Ufungaji

Ili kuanza, fuata hatua hizi kuweka mazingira yako:

1. Sakinisha tegemezi kwa kutumia uv (inapendekezwa) au pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Tengeneza faili `.env` kwenye mizizi ya mradi na funguo yako ya SerpAPI:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Matumizi

Server ya Utafutaji Mtandao ya MCP ni sehemu kuu inayotoa zana za utafutaji mtandao, habari, bidhaa, na maswali-jawabu kwa kuunganishwa na SerpAPI. Inashughulikia maombi yanayoingia, kusimamia simu za API, kuchambua majibu, na kurudisha matokeo yaliyopangwa kwa mteja.

Unaweza kupitia utekelezaji kamili katika [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Kuendesha Server

Kuanzisha server ya MCP, tumia amri ifuatayo:

```bash
python server.py
```

Server itaendesha kama server ya MCP inayotumia stdio ambayo mteja anaweza kuunganishwa moja kwa moja.

### Hali za Mteja

Mteja (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Kuendesha Mteja

Kuendesha majaribio ya moja kwa moja (hii itaanzisha server moja kwa moja):

```bash
python client.py
```

Au endesha katika hali ya mwingiliano:

```bash
python client.py --interactive
```

### Kujaribu kwa Njia Mbalimbali

Kuna njia kadhaa za kujaribu na kuingiliana na zana zinazotolewa na server, kulingana na mahitaji na mtiririko wako wa kazi.

#### Kuandika Skripti za Jaribio Maalum kwa MCP Python SDK
Unaweza pia kujenga skripti zako za majaribio kwa kutumia MCP Python SDK:

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

Katika muktadha huu, "skripti ya jaribio" inamaanisha programu maalum ya Python unayoandika ili itumike kama mteja wa server ya MCP. Badala ya kuwa jaribio rasmi la kitengo, skripti hii inakuwezesha kuunganishwa na server, kuitisha zana yoyote na vigezo unavyotaka, na kuchambua matokeo. Njia hii ni muhimu kwa:
- Kuanzisha na kujaribu kuitisha zana
- Kuhakiki jinsi server inavyotenda kwa pembejeo tofauti
- Kuendesha mfululizo wa kuitisha zana kiotomatiki
- Kujenga mtiririko wako wa kazi au ushirikiano juu ya server ya MCP

Unaweza kutumia skripti za jaribio kujaribu haraka maswali mapya, kutatua tabia ya zana, au hata kama msingi wa otomatiki zaidi. Hapa chini kuna mfano wa jinsi ya kutumia MCP Python SDK kuunda skripti kama hiyo:

## Maelezo ya Zana

Unaweza kutumia zana zifuatazo zinazotolewa na server kufanya aina mbalimbali za utafutaji na maswali. Kila zana imeelezewa hapa chini pamoja na vigezo na mfano wa matumizi.

Sehemu hii inatoa maelezo kuhusu kila zana inayopatikana na vigezo vyake.

### general_search

Hufanya utafutaji wa mtandao kwa jumla na kurudisha matokeo yaliyopangwa.

**Jinsi ya kuitisha zana hii:**

Unaweza kuitisha `general_search` kutoka kwenye skripti yako kwa kutumia MCP Python SDK, au kuingiliana nayo kwa kutumia Inspector au hali ya mwingiliano ya mteja. Hapa kuna mfano wa msimbo kwa kutumia SDK:

<details>
<summary>Mfano wa Python</summary>

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

Vinginevyo, katika hali ya mwingiliano, chagua `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (kamba): Swali la utafutaji

**Mfano wa Ombi:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Hufanya utafutaji wa makala za habari za hivi karibuni zinazohusiana na swali.

**Jinsi ya kuitisha zana hii:**

Unaweza kuitisha `news_search` kutoka kwenye skripti yako kwa kutumia MCP Python SDK, au kuingiliana nayo kwa kutumia Inspector au hali ya mwingiliano ya mteja. Hapa kuna mfano wa msimbo kwa kutumia SDK:

<details>
<summary>Mfano wa Python</summary>

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

Vinginevyo, katika hali ya mwingiliano, chagua `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (kamba): Swali la utafutaji

**Mfano wa Ombi:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Hufanya utafutaji wa bidhaa zinazolingana na swali.

**Jinsi ya kuitisha zana hii:**

Unaweza kuitisha `product_search` kutoka kwenye skripti yako kwa kutumia MCP Python SDK, au kuingiliana nayo kwa kutumia Inspector au hali ya mwingiliano ya mteja. Hapa kuna mfano wa msimbo kwa kutumia SDK:

<details>
<summary>Mfano wa Python</summary>

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

Vinginevyo, katika hali ya mwingiliano, chagua `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (kamba): Swali la utafutaji wa bidhaa

**Mfano wa Ombi:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Hupata majibu ya moja kwa moja kwa maswali kutoka kwa injini za utafutaji.

**Jinsi ya kuitisha zana hii:**

Unaweza kuitisha `qna` kutoka kwenye skripti yako kwa kutumia MCP Python SDK, au kuingiliana nayo kwa kutumia Inspector au hali ya mwingiliano ya mteja. Hapa kuna mfano wa msimbo kwa kutumia SDK:

<details>
<summary>Mfano wa Python</summary>

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

Vinginevyo, katika hali ya mwingiliano, chagua `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (kamba): Swali unalotaka kupata jibu

**Mfano wa Ombi:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Maelezo ya Msimbo

Sehemu hii inatoa vipande vya msimbo na marejeleo ya utekelezaji wa server na mteja.

<details>
<summary>Python</summary>

Tazama [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) kwa maelezo kamili ya utekelezaji.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Misingi ya Juu katika Somo Hili

Kabla ya kuanza kujenga, hapa kuna baadhi ya dhana muhimu za hali ya juu zitakazojitokeza katika sura hii. Kuelewa hizi kutakusaidia kufuatilia kwa urahisi, hata kama ni mpya kwako:

- **Uendeshaji wa Zana Nyingi**: Hii inamaanisha kuendesha zana tofauti kadhaa (kama utafutaji mtandao, utafutaji habari, utafutaji bidhaa, na maswali-jawabu) ndani ya server moja ya MCP. Inaruhusu server yako kushughulikia kazi mbalimbali, siyo moja tu.
- **Kushughulikia Viwango vya Maombi ya API**: API nyingi za nje (kama SerpAPI) hupunguza idadi ya maombi unayoweza kutuma kwa muda fulani. Msimbo mzuri unahakikisha kukagua viwango hivi na kuzishughulikia kwa staha, ili app yako isivunjike ukiwa umefikia kikomo.
- **Uchambuzi wa Data Iliyo Pangiliwa**: Majibu ya API mara nyingi ni magumu na yenye muundo wa ndani. Dhana hii ni kuhusu kubadilisha majibu hayo kuwa muundo safi, rahisi kutumia na rafiki kwa LLM au programu nyingine.
- **Urejeshaji wa Makosa**: Wakati mwingine mambo hayendi sawa—labda mtandao umevunjika, au API hairejeshi kile unachotarajia. Urejeshaji wa makosa unamaanisha msimbo wako unaweza kushughulikia matatizo haya na bado kutoa maoni yenye maana, badala ya kuanguka.
- **Uhakiki wa Vigezo**: Hii ni kuhusu kuhakikisha kwamba pembejeo zote kwa zana zako ni sahihi na salama kutumia. Inajumuisha kuweka thamani za msingi na kuhakikisha aina za data ni sahihi, ambayo husaidia kuzuia hitilafu na mkanganyiko.

Sehemu hii itakusaidia kugundua na kutatua matatizo ya kawaida unayoweza kukutana nayo unapotumia Server ya Utafutaji Mtandao ya MCP. Ukikumbana na makosa au tabia isiyotarajiwa, sehemu hii ya kutatua matatizo inatoa suluhisho kwa matatizo yanayojitokeza mara kwa mara. Pitia vidokezo hivi kabla ya kutafuta msaada zaidi—mara nyingi huondoa matatizo haraka.

## Kutatua Matatizo

Unapofanya kazi na Server ya Utafutaji Mtandao ya MCP, huenda ukakutana na matatizo mara kwa mara—hii ni kawaida wakati wa kuendeleza kwa kutumia API za nje na zana mpya. Sehemu hii inatoa suluhisho za vitendo kwa matatizo yanayojitokeza mara kwa mara, ili urudi kwenye kazi haraka. Ukikumbana na kosa, anza hapa: vidokezo hapa chini vinashughulikia matatizo yanayokumba watumiaji wengi na mara nyingi vinaweza kutatua tatizo lako bila msaada zaidi.

### Matatizo ya Kawaida

Hapa chini ni baadhi ya matatizo yanayojitokeza mara kwa mara kwa watumiaji, pamoja na maelezo wazi na hatua za kuyatatua:

1. **SERPAPI_KEY Haipo katika faili .env**
   - Ikiwa unaona kosa `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env`, hakikisha umeunda faili `.env` kama inavyoelezwa. Ikiwa funguo yako ni sahihi lakini bado unapata kosa hili, angalia kama kiwango chako cha bure kimeisha.

### Hali ya Debug

Kwa kawaida, app inaandika kumbukumbu za habari muhimu tu. Ikiwa unataka kuona maelezo zaidi kuhusu kinachoendelea (kwa mfano, kutatua matatizo magumu), unaweza kuwasha hali ya DEBUG. Hii itaonyesha mengi zaidi kuhusu kila hatua app inayoichukua.

**Mfano: Matokeo ya Kawaida**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Mfano: Matokeo ya DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Angalia jinsi hali ya DEBUG inajumuisha mistari ya ziada kuhusu maombi ya HTTP, majibu, na maelezo mengine ya ndani. Hii inaweza kusaidia sana wakati wa kutatua matatizo.

Ili kuwasha hali ya DEBUG, weka kiwango cha kuandika kumbukumbu kuwa DEBUG juu ya `client.py` or `server.py`:

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

## Kinachofuata

- [6. Michango ya Jamii](../../06-CommunityContributions/README.md)

**Kasi ya Majaribio**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo halali. Kwa taarifa muhimu, tafsiri ya kitaalamu inayotolewa na binadamu inashauriwa. Hatubebwi jukumu kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.