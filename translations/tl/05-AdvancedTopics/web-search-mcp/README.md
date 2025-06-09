<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T19:23:30+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "tl"
}
-->
# Lesson: Pagtayo ng Web Search MCP Server

Ipinapakita ng kabanatang ito kung paano gumawa ng isang totoong AI agent na nakakabit sa mga external na API, kayang mag-handle ng iba't ibang uri ng data, may mahusay na pag-manage ng errors, at kayang magpatakbo ng maraming tools—lahat ito ay nasa production-ready na format. Makikita mo dito:

- **Pagsasama ng external APIs na nangangailangan ng authentication**
- **Pag-handle ng iba't ibang uri ng data mula sa maraming endpoints**
- **Matatag na error handling at logging strategies**
- **Pag-orchestrate ng maraming tools sa iisang server**

Sa katapusan, magkakaroon ka ng praktikal na karanasan sa mga pattern at best practices na mahalaga para sa advanced AI at LLM-powered na mga aplikasyon.

## Panimula

Sa araling ito, matututuhan mo kung paano bumuo ng advanced MCP server at client na nagpapalawak ng kakayahan ng LLM gamit ang real-time na web data gamit ang SerpAPI. Mahalaga ito para makagawa ng dynamic na AI agents na nakakakuha ng pinakabagong impormasyon mula sa web.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Isama nang ligtas ang mga external API (tulad ng SerpAPI) sa MCP server
- Magpatupad ng maraming tools para sa web, balita, paghahanap ng produkto, at Q&A
- I-parse at i-format ang structured data para sa LLM
- Epektibong mag-handle ng errors at mag-manage ng API rate limits
- Bumuo at mag-test ng automated at interactive na MCP clients

## Web Search MCP Server

Ipinapakilala ng seksyong ito ang arkitektura at mga tampok ng Web Search MCP Server. Makikita mo kung paano pinagsama ang FastMCP at SerpAPI para palawakin ang kakayahan ng LLM gamit ang real-time na web data.

### Pangkalahatang Ideya

Ang implementasyong ito ay may apat na tools na nagpapakita ng kakayahan ng MCP na mag-handle ng iba't ibang external API-driven na gawain nang ligtas at epektibo:

- **general_search**: Para sa malawak na resulta sa web
- **news_search**: Para sa mga pinakabagong balita
- **product_search**: Para sa datos ng e-commerce
- **qna**: Para sa mga tanong at sagot

### Mga Tampok
- **Mga Halimbawa ng Code**: May mga language-specific na code blocks para sa Python (at madaling i-extend sa ibang wika) gamit ang collapsible sections para sa kalinawan

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

Bago patakbuhin ang client, makakatulong na maintindihan kung ano ang ginagawa ng server. Tingnan ang [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Narito ang maikling halimbawa kung paano nagde-define at nagrerehistro ng tool ang server:

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

- **Pagsasama ng External API**: Ipinapakita ang ligtas na paghawak ng API keys at external requests
- **Pag-parse ng Structured Data**: Paano i-transform ang API responses para maging friendly sa LLM
- **Pag-handle ng Error**: Matatag na error handling na may tamang logging
- **Interactive Client**: May automated tests at interactive mode para sa testing
- **Context Management**: Ginagamit ang MCP Context para sa logging at pagsubaybay ng mga requests

## Mga Kinakailangan

Bago ka magsimula, siguraduhing maayos ang setup ng iyong environment sa pamamagitan ng pagsunod sa mga hakbang na ito. Titiyakin nito na lahat ng dependencies ay naka-install at ang iyong API keys ay naka-configure nang tama para sa maayos na development at testing.

- Python 3.8 pataas
- SerpAPI API Key (Mag-sign up sa [SerpAPI](https://serpapi.com/) - may libreng tier)

## Pag-install

Para makapagsimula, sundin ang mga hakbang na ito para ma-setup ang iyong environment:

1. I-install ang mga dependencies gamit ang uv (inirerekomenda) o pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Gumawa ng `.env` file sa root ng proyekto na may iyong SerpAPI key:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Paggamit

Ang Web Search MCP Server ang pangunahing bahagi na nag-eexpose ng mga tools para sa web, balita, paghahanap ng produkto, at Q&A sa pamamagitan ng pagsasama sa SerpAPI. Pinangangasiwaan nito ang mga papasok na requests, API calls, pag-parse ng mga sagot, at pagbabalik ng naka-structured na resulta sa client.

Maaari mong tingnan ang buong implementasyon sa [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Pagsisimula ng Server

Para patakbuhin ang MCP server, gamitin ang sumusunod na utos:

```bash
python server.py
```

Tatakbo ang server bilang stdio-based MCP server na direktang makakonekta ang client.

### Mga Mode ng Client

Ang client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Pagsisimula ng Client

Para patakbuhin ang automated tests (kasama na dito ang awtomatikong pagsisimula ng server):

```bash
python client.py
```

O gamitin ang interactive mode:

```bash
python client.py --interactive
```

### Pagsubok gamit ang Iba't Ibang Paraan

May ilang paraan para subukan at makipag-interact sa mga tools na ibinibigay ng server, depende sa iyong pangangailangan at workflow.

#### Pagsulat ng Custom Test Scripts gamit ang MCP Python SDK
Pwede ka ring gumawa ng sarili mong test scripts gamit ang MCP Python SDK:

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

Sa kontekstong ito, ang "test script" ay custom Python program na isinusulat mo para maging client ng MCP server. Hindi ito pormal na unit test, kundi script na nagpapahintulot na programmatically kumonekta sa server, tawagin ang alinmang tool na gusto mo gamit ang mga parameters na pipiliin mo, at suriin ang resulta. Mainam ito para sa:
- Prototyping at pag-eeksperimento sa mga tawag sa tool
- Pag-validate kung paano tumutugon ang server sa iba't ibang inputs
- Pag-automate ng paulit-ulit na paggamit ng mga tool
- Paggawa ng sarili mong workflows o integrasyon sa ibabaw ng MCP server

Magagamit mo ang test scripts para mabilis na subukan ang mga bagong query, mag-debug ng pag-uugali ng tool, o bilang panimulang punto para sa mas advanced na automation. Narito ang halimbawa kung paano gamitin ang MCP Python SDK para gumawa ng ganitong script:

## Paglalarawan ng mga Tool

Pwede mong gamitin ang mga sumusunod na tools na ibinibigay ng server para magsagawa ng iba't ibang uri ng paghahanap at query. Bawat tool ay inilalarawan dito kasama ang mga parameters at halimbawa ng paggamit.

Ipinapakita ng seksyong ito ang detalye tungkol sa bawat tool at ang mga parameters nito.

### general_search

Gumagawa ng pangkalahatang web search at nagbabalik ng naka-format na resulta.

**Paano tawagin ang tool na ito:**

Pwede mong tawagin ang `general_search` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o ang interactive client mode. Narito ang halimbawa gamit ang SDK:

<details>
<summary>Halimbawa sa Python</summary>

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

Bilang alternatibo, sa interactive mode, piliin ang `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Ang query sa paghahanap

**Halimbawa ng Request:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Naghahanap ng mga pinakabagong balita na may kaugnayan sa query.

**Paano tawagin ang tool na ito:**

Pwede mong tawagin ang `news_search` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o ang interactive client mode. Narito ang halimbawa gamit ang SDK:

<details>
<summary>Halimbawa sa Python</summary>

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

Bilang alternatibo, sa interactive mode, piliin ang `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Ang query sa paghahanap

**Halimbawa ng Request:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Naghahanap ng mga produkto na tumutugma sa query.

**Paano tawagin ang tool na ito:**

Pwede mong tawagin ang `product_search` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o ang interactive client mode. Narito ang halimbawa gamit ang SDK:

<details>
<summary>Halimbawa sa Python</summary>

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

Bilang alternatibo, sa interactive mode, piliin ang `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Ang query para sa paghahanap ng produkto

**Halimbawa ng Request:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Kumuha ng direktang sagot sa mga tanong mula sa mga search engine.

**Paano tawagin ang tool na ito:**

Pwede mong tawagin ang `qna` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o ang interactive client mode. Narito ang halimbawa gamit ang SDK:

<details>
<summary>Halimbawa sa Python</summary>

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

Bilang alternatibo, sa interactive mode, piliin ang `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Ang tanong na nais hanapan ng sagot

**Halimbawa ng Request:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Mga Detalye ng Code

Nagbibigay ang seksyong ito ng mga code snippet at reference para sa implementasyon ng server at client.

<details>
<summary>Python</summary>

Tingnan ang [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) para sa buong detalye ng implementasyon.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Mga Advanced na Konsepto sa Araling Ito

Bago ka magsimula sa paggawa, narito ang ilang mahahalagang advanced na konsepto na lilitaw sa buong kabanatang ito. Ang pag-unawa sa mga ito ay makakatulong sa iyo na masundan ang mga paliwanag, kahit bago ka pa lamang sa mga ito:

- **Multi-tool Orchestration**: Ibig sabihin nito ay pagpapatakbo ng maraming iba't ibang tools (tulad ng web search, news search, product search, at Q&A) sa loob ng isang MCP server. Pinapayagan nito ang iyong server na mag-handle ng iba't ibang gawain, hindi lang isa.
- **API Rate Limit Handling**: Maraming external API (tulad ng SerpAPI) ang may limit kung ilang requests ang pwede mong gawin sa loob ng takdang oras. Magandang code ang nagche-check sa mga limit na ito at maayos itong hinahandle para hindi mag-crash ang app kung maabot ang limit.
- **Structured Data Parsing**: Madalas na komplikado at nested ang mga sagot mula sa API. Ang konseptong ito ay tungkol sa pag-transform ng mga sagot na iyon sa malinis at madaling gamitin na format na friendly sa LLMs o iba pang programa.
- **Error Recovery**: Minsan may mga problema—maaaring bumagsak ang network, o hindi angkop ang sagot ng API. Ang error recovery ay ang kakayahan ng code na harapin ang mga problemang ito at magbigay pa rin ng kapaki-pakinabang na feedback, imbes na mag-crash.
- **Parameter Validation**: Ito ay tungkol sa pagtiyak na tama at ligtas gamitin ang lahat ng inputs sa iyong mga tools. Kasama dito ang pagtatakda ng default values at pagsigurong tama ang mga uri, na nakakatulong maiwasan ang bugs at kalituhan.

Ang seksyong ito ay makakatulong sa iyo na mag-diagnose at mag-ayos ng mga karaniwang problema na maaaring maranasan habang ginagamit ang Web Search MCP Server. Kung makaranas ka ng error o hindi inaasahang pag-uugali habang ginagamit ang Web Search MCP Server, nagbibigay ang troubleshooting section ng mga solusyon sa mga pinaka-karaniwang isyu. Suriin muna ang mga tips na ito bago humingi ng karagdagang tulong—madalas, dito mabilis maresolba ang problema.

## Pag-troubleshoot

Kapag nagtatrabaho sa Web Search MCP Server, paminsan-minsan ay maaaring makaranas ka ng mga problema—normal ito kapag nagde-develop gamit ang external APIs at bagong mga tools. Nagbibigay ang seksyong ito ng praktikal na solusyon sa mga pinaka-karaniwang problema, para mabilis kang makabalik sa trabaho. Kung makakita ka ng error, simulan dito: tinatalakay ng mga tip sa ibaba ang mga isyung madalas maranasan ng mga user at madalas ay nakakatulong ito para malutas ang problema nang hindi na kailangan ng karagdagang tulong.

### Mga Karaniwang Isyu

Narito ang ilan sa mga madalas na problema na nararanasan ng mga user, kasama ang malinaw na paliwanag at mga hakbang para ayusin ito:

1. **Walang SERPAPI_KEY sa .env file**
   - Kung makita mo ang error na `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` file kung kinakailangan. Kung tama ang iyong key pero patuloy ang error, tingnan kung naubos na ang quota ng iyong free tier.

### Debug Mode

Sa default, naglo-log lang ang app ng mga importanteng impormasyon. Kung gusto mong makita ang mas detalyadong impormasyon tungkol sa mga nangyayari (halimbawa, para ma-diagnose ang mga mahihirap na isyu), pwede mong i-enable ang DEBUG mode. Ipapakita nito ang mas maraming detalye sa bawat hakbang ng app.

**Halimbawa: Normal na Output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Halimbawa: DEBUG Output**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Mapapansin na ang DEBUG mode ay may dagdag na linya tungkol sa HTTP requests, responses, at iba pang internal na detalye. Napaka-kapaki-pakinabang ito para sa pag-troubleshoot.

Para i-enable ang DEBUG mode, itakda ang logging level sa DEBUG sa itaas ng iyong `client.py` or `server.py`:

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

## Ano ang susunod

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat aming pinagsisikapang maging tumpak ang pagsasalin, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.