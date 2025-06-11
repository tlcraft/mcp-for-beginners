<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T16:12:40+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "sw"
}
-->
# Somo: Kujenga Web Search MCP Server

Sura hii inaonyesha jinsi ya kujenga wakala halisi wa AI anayejumuisha APIs za nje, kushughulikia aina mbalimbali za data, kusimamia makosa, na kuendesha zana nyingi—yote haya kwa muundo unaotumika kwenye uzalishaji. Utajifunza:

- **Ushirikiano na APIs za nje zinazohitaji uthibitishaji**
- **Kushughulikia aina mbalimbali za data kutoka vyanzo vingi**
- **Mbinu imara za kushughulikia makosa na kurekodi matukio**
- **Uendeshaji wa zana nyingi katika server moja**

Mwisho wa somo hili, utakuwa na uzoefu wa vitendo na mifumo bora muhimu kwa programu za AI na LLM zilizoimarishwa.

## Utangulizi

Katika somo hili, utajifunza jinsi ya kujenga MCP server na mteja wa hali ya juu unaoongeza uwezo wa LLM kwa kutumia data ya mtandao kwa wakati halisi kupitia SerpAPI. Hii ni ujuzi muhimu kwa kuunda mawakala wa AI wenye uwezo wa kupata taarifa za hivi punde kutoka mtandao.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kuunganisha APIs za nje (kama SerpAPI) kwa usalama katika MCP server
- Kutekeleza zana nyingi za utafutaji wa mtandao, habari, bidhaa, na maswali/jawabu
- Kuchambua na kuunda data iliyopangwa kwa matumizi ya LLM
- Kushughulikia makosa na kusimamia mipaka ya maombi ya API kwa ufanisi
- Kujenga na kujaribu mteja wa MCP wa moja kwa moja na wa mwingiliano

## Web Search MCP Server

Sehemu hii inaelezea usanifu na vipengele vya Web Search MCP Server. Utaona jinsi FastMCP na SerpAPI vinavyotumika pamoja kuongeza uwezo wa LLM kwa data ya mtandao kwa wakati halisi.

### Muhtasari

Utekelezaji huu una zana nne zinazothibitisha uwezo wa MCP kushughulikia kazi mbalimbali zinazotegemea APIs za nje kwa usalama na ufanisi:

- **general_search**: Kwa matokeo ya jumla ya mtandao
- **news_search**: Kwa vichwa vya habari vya hivi karibuni
- **product_search**: Kwa data ya e-commerce
- **qna**: Kwa vipande vya maswali na majibu

### Vipengele
- **Mifano ya Msimbo**: Inajumuisha sehemu za msimbo maalum kwa Python (na rahisi kupanuliwa kwa lugha nyingine) kwa kutumia sehemu zinazoweza kufichwa kwa uwazi

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

Kabla ya kuendesha mteja, ni vyema kuelewa kinachofanywa na server. Angalia [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

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

- **Ushirikiano wa API za Nje**: Inaonyesha jinsi ya kushughulikia kwa usalama funguo za API na maombi ya nje
- **Uchambuzi wa Data Iliyo Pangiliwa**: Inaonyesha jinsi ya kubadilisha majibu ya API kuwa muundo unaofaa kwa LLM
- **Kushughulikia Makosa**: Kushughulikia makosa kwa ufanisi na kurekodi matukio ipasavyo
- **Mteja wa Mwingiliano**: Inajumuisha majaribio ya moja kwa moja na hali ya mwingiliano kwa majaribio
- **Usimamizi wa Muktadha**: Inatumia MCP Context kwa ajili ya kurekodi na kufuatilia maombi

## Mahitaji ya Awali

Kabla ya kuanza, hakikisha mazingira yako yamewekwa ipasavyo kwa kufuata hatua hizi. Hii itahakikisha utegemezi wote umewekwa na funguo zako za API zimesanidiwa vizuri kwa maendeleo na majaribio bila matatizo.

- Python 3.8 au zaidi
- Funguo ya SerpAPI API (Jisajili kwa [SerpAPI](https://serpapi.com/) - kiwango cha bure kinapatikana)

## Usanidi

Ili kuanza, fuata hatua hizi kuweka mazingira yako:

1. Sakinisha utegemezi kwa kutumia uv (inapendekezwa) au pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Tengeneza faili `.env` kwenye mzizi wa mradi na funguo yako ya SerpAPI:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Matumizi

Web Search MCP Server ni sehemu kuu inayotoa zana za utafutaji wa mtandao, habari, bidhaa, na maswali/jawabu kwa kuunganisha na SerpAPI. Inashughulikia maombi yanayoingia, kusimamia simu za API, kuchambua majibu, na kurudisha matokeo yaliyopangwa kwa mteja.

Unaweza kupitia utekelezaji kamili kwenye [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Kuendesha Server

Kuanza MCP server, tumia amri ifuatayo:

```bash
python server.py
```

Server itaendesha kama MCP server inayotumia stdio ambayo mteja anaweza kuunganishwa moja kwa moja.

### Hali za Mteja

Mteja (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Kuendesha Mteja

Kuendesha majaribio ya moja kwa moja (hii itaanza server moja kwa moja):

```bash
python client.py
```

Au endesha katika hali ya mwingiliano:

```bash
python client.py --interactive
```

### Kujaribu kwa Njia Mbali Mbali

Kuna njia kadhaa za kujaribu na kuingiliana na zana zinazotolewa na server, kulingana na mahitaji yako na mtiririko wa kazi.

#### Kuandika Skripti za Jaribio Maalum kwa MCP Python SDK
Pia unaweza kujenga skripti zako za majaribio kwa kutumia MCP Python SDK:

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

Katika muktadha huu, "skripti ya jaribio" inamaanisha programu maalum ya Python unayoandika ili itumike kama mteja kwa MCP server. Badala ya kuwa jaribio rasmi la kitengo, skripti hii inakuwezesha kuunganishwa na server, kuita zana yoyote na vigezo unavyotaka, na kuchambua matokeo. Njia hii ni muhimu kwa:
- Kufanya majaribio na kujaribu miito ya zana
- Kuthibitisha jinsi server inavyotenda kwa pembejeo tofauti
- Kuendesha miito ya zana kwa urudia
- Kujenga mtiririko wa kazi au uunganisho wa juu zaidi juu ya MCP server

Unaweza kutumia skripti za jaribio kujaribu haraka maswali mapya, kutatua matatizo ya zana, au kama msingi wa uendeshaji wa hali ya juu zaidi. Hapa chini kuna mfano wa jinsi ya kutumia MCP Python SDK kuunda skripti kama hiyo:

## Maelezo ya Zana

Unaweza kutumia zana zifuatazo zinazotolewa na server kutekeleza aina tofauti za utafutaji na maswali. Kila zana imeelezewa hapa chini na vigezo vyake pamoja na mfano wa matumizi.

Sehemu hii inatoa maelezo kuhusu kila zana iliyopo na vigezo vyake.

### general_search

Hufanya utafutaji wa jumla mtandaoni na kurudisha matokeo yaliyopangwa.

**Jinsi ya kuita zana hii:**

Unaweza kuita `general_search` kutoka kwenye skripti yako kwa kutumia MCP Python SDK, au kwa mwingiliano kwa kutumia Inspector au hali ya mwingiliano ya mteja. Hapa kuna mfano wa msimbo kwa kutumia SDK:

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

**Jinsi ya kuita zana hii:**

Unaweza kuita `news_search` kutoka kwenye skripti yako kwa kutumia MCP Python SDK, au kwa mwingiliano kwa kutumia Inspector au hali ya mwingiliano ya mteja. Hapa kuna mfano wa msimbo kwa kutumia SDK:

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

**Jinsi ya kuita zana hii:**

Unaweza kuita `product_search` kutoka kwenye skripti yako kwa kutumia MCP Python SDK, au kwa mwingiliano kwa kutumia Inspector au hali ya mwingiliano ya mteja. Hapa kuna mfano wa msimbo kwa kutumia SDK:

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

**Jinsi ya kuita zana hii:**

Unaweza kuita `qna` kutoka kwenye skripti yako kwa kutumia MCP Python SDK, au kwa mwingiliano kwa kutumia Inspector au hali ya mwingiliano ya mteja. Hapa kuna mfano wa msimbo kwa kutumia SDK:

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
- `question` (kamba): Swali la kupata jibu

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

Angalia [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) kwa maelezo kamili ya utekelezaji.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Mifumo ya Juu Katika Somo Hili

Kabla ya kuanza kujenga, hapa kuna baadhi ya dhana muhimu za juu zitakazojitokeza katika sura hii. Kuelewa hizi kutakusaidia kufuatilia kwa urahisi, hata kama ni mara yako ya kwanza:

- **Uendeshaji wa Zana Nyingi**: Hii ina maana ya kuendesha zana tofauti kadhaa (kama utafutaji wa mtandao, habari, bidhaa, na maswali/jawabu) ndani ya MCP server moja. Inamruhusu server kushughulikia kazi mbalimbali, siyo moja tu.
- **Kushughulikia Mipaka ya Muda ya API**: APIs nyingi za nje (kama SerpAPI) zinaweka kikomo cha idadi ya maombi unaweza kufanya kwa muda fulani. Msimbo mzuri huchunguza mipaka hii na kushughulikia kwa ustadi, ili app yako isivunjike ikiwa ukifikia kikomo.
- **Uchambuzi wa Data Iliyo Pangiliwa**: Majibu ya API mara nyingi ni magumu na yamepangwa kwa kina. Dhana hii ni kuhusu kubadilisha majibu hayo kuwa muundo safi na rahisi kutumia, unaofaa kwa LLM au programu nyingine.
- **Urejeshaji wa Makosa**: Wakati mwingine mambo yanakwenda mrama—labda mtandao unashindwa, au API haisemi kile unachotarajia. Urejeshaji wa makosa unamaanisha msimbo wako unaweza kushughulikia matatizo haya na bado kutoa mrejesho mzuri, badala ya kuanguka.
- **Uhakiki wa Vigezo**: Hii ni kuhusu kuhakikisha kwamba pembejeo zote kwa zana zako ni sahihi na salama kutumia. Inajumuisha kuweka thamani za msingi na kuhakikisha aina ni sahihi, ambayo husaidia kuzuia hitilafu na mkanganyiko.

Sehemu hii itakusaidia kugundua na kutatua matatizo ya kawaida unayoweza kukutana nayo unapotumia Web Search MCP Server. Ikiwa utakumbana na makosa au tabia zisizotarajiwa unapotumia Web Search MCP Server, sehemu hii ya utatuzi inatoa suluhisho za matatizo yanayoonekana zaidi. Pitia vidokezo hivi kabla ya kutafuta msaada zaidi—mara nyingi hutatua matatizo haraka.

## Utatuzi wa Matatizo

Unapofanya kazi na Web Search MCP Server, mara nyingine unaweza kukumbana na matatizo—hii ni kawaida unapotumia APIs za nje na zana mpya. Sehemu hii inatoa suluhisho za vitendo kwa matatizo yanayoonekana mara kwa mara, ili urudi kwenye njia haraka. Ukikumbana na kosa, anza hapa: vidokezo hapa chini vinashughulikia matatizo ambayo watumiaji wengi hukumbana navyo na mara nyingi vinaweza kutatua tatizo lako bila msaada zaidi.

### Matatizo ya Kawaida

Hapa chini ni baadhi ya matatizo yanayojitokeza mara kwa mara kwa watumiaji, pamoja na maelezo wazi na hatua za kuyatatua:

1. **SERPAPI_KEY haipo katika faili .env**
   - Ikiwa unaona kosa `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env`, hakikisha umeunda faili `.env` kama inavyohitajika. Ikiwa funguo yako ni sahihi lakini bado unakumbana na kosa hili, angalia kama kiwango chako cha bure kimeisha.

### Hali ya Ufuatiliaji wa Makosa (Debug Mode)

Kwa kawaida, app inarekodi tu taarifa muhimu. Ikiwa unataka kuona maelezo zaidi kuhusu kinachoendelea (kwa mfano, kutambua matatizo magumu), unaweza kuwasha hali ya DEBUG. Hii itaonyesha zaidi kuhusu kila hatua app inachukua.

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

Angalia jinsi hali ya DEBUG inajumuisha mistari ya ziada kuhusu maombi ya HTTP, majibu, na maelezo mengine ya ndani. Hii inaweza kusaidia sana katika utatuzi wa matatizo.

Ili kuwasha hali ya DEBUG, weka kiwango cha kurekodi matukio (logging level) kuwa DEBUG juu ya `client.py` or `server.py`:

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

## Nini Kifuatacho

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Tangazo la Kukataa**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuwa sahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati asilia katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha kuaminika. Kwa taarifa muhimu, tafsiri ya kitaalamu na ya binadamu inashauriwa. Hatuna wajibu wowote kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.