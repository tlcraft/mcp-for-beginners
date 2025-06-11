<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T16:09:52+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "tl"
}
-->
# Lesson: Pagtatayo ng Web Search MCP Server

Ipinapakita sa kabanatang ito kung paano bumuo ng isang tunay na AI agent na nakakabit sa mga external na API, humahandle ng iba't ibang uri ng data, nagma-manage ng mga error, at nag-oorganisa ng maraming tools—lahat sa isang production-ready na format. Makikita mo ang:

- **Pagsasama ng mga external API na nangangailangan ng authentication**
- **Pag-handle ng iba't ibang uri ng data mula sa maraming endpoints**
- **Matibay na paghawak ng error at mga estratehiya sa pag-log**
- **Multi-tool orchestration sa iisang server**

Sa pagtatapos, magkakaroon ka ng praktikal na karanasan sa mga pattern at best practices na mahalaga para sa mga advanced na AI at LLM-powered na aplikasyon.

## Panimula

Sa araling ito, matututuhan mo kung paano bumuo ng advanced na MCP server at client na nagpapalawak ng kakayahan ng LLM gamit ang real-time na web data gamit ang SerpAPI. Isang mahalagang kasanayan ito para makagawa ng dynamic na AI agents na makaka-access ng pinakabagong impormasyon mula sa web.

## Mga Layunin sa Pagkatuto

Pagkatapos ng araling ito, magagawa mong:

- Isama nang ligtas ang mga external API (tulad ng SerpAPI) sa isang MCP server
- Magpatupad ng maraming tools para sa web, balita, paghahanap ng produkto, at Q&A
- I-parse at i-format ang structured data para sa paggamit ng LLM
- Mag-handle ng mga error at pamahalaan nang epektibo ang mga limitasyon sa API rate
- Bumuo at mag-test ng parehong automated at interactive MCP clients

## Web Search MCP Server

Ipinapakilala sa seksyong ito ang arkitektura at mga tampok ng Web Search MCP Server. Makikita mo kung paano pinagsasama ang FastMCP at SerpAPI para palawakin ang kakayahan ng LLM gamit ang real-time na web data.

### Pangkalahatang-ideya

Ang implementasyong ito ay may apat na tools na nagpapakita ng kakayahan ng MCP na ligtas at mahusay na humandle ng iba't ibang gawain na pinapatakbo ng mga external API:

- **general_search**: Para sa malawakang resulta sa web
- **news_search**: Para sa mga pinakabagong balita
- **product_search**: Para sa data ng e-commerce
- **qna**: Para sa mga sagot sa mga tanong

### Mga Tampok
- **Mga Halimbawa ng Code**: Kasama ang mga language-specific na code blocks para sa Python (at madaling mapalawak sa ibang mga wika) gamit ang collapsible sections para sa kalinawan

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

Bago patakbuhin ang client, makabubuting maintindihan kung ano ang ginagawa ng server. Ang [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Narito ang maikling halimbawa kung paano nagde-define at nagrerehistro ang server ng isang tool:

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

- **Pagsasama ng External API**: Ipinapakita kung paano ligtas na hinahandle ang mga API key at mga external na request
- **Pag-parse ng Structured Data**: Ipinapakita kung paano i-transform ang mga sagot ng API sa mga format na madaling gamitin ng LLM
- **Pag-handle ng Error**: Matibay na paghawak ng error na may angkop na pag-log
- **Interactive Client**: Kasama ang automated tests at interactive mode para sa testing
- **Pamamahala ng Konteksto**: Ginagamit ang MCP Context para sa pag-log at pagsubaybay ng mga request

## Mga Kinakailangan

Bago magsimula, siguraduhing maayos ang setup ng iyong environment sa pamamagitan ng pagsunod sa mga hakbang na ito. Titiyakin nito na naka-install ang lahat ng dependencies at naka-configure nang tama ang iyong mga API key para sa maayos na development at testing.

- Python 3.8 o mas mataas pa
- SerpAPI API Key (Mag-sign up sa [SerpAPI](https://serpapi.com/) - may libreng tier)

## Pag-install

Para makapagsimula, sundin ang mga hakbang na ito para i-setup ang iyong environment:

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

Ang Web Search MCP Server ang pangunahing bahagi na nag-eexpose ng mga tools para sa web, balita, paghahanap ng produkto, at Q&A sa pamamagitan ng pagsasama sa SerpAPI. Hinahandle nito ang mga papasok na request, pinamamahalaan ang mga tawag sa API, ini-parse ang mga sagot, at ibinabalik ang mga naka-istrukturang resulta sa client.

Maaari mong tingnan ang buong implementasyon sa [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Pagsisimula ng Server

Para simulan ang MCP server, gamitin ang sumusunod na utos:

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

O patakbuhin sa interactive mode:

```bash
python client.py --interactive
```

### Pagsusuri gamit ang Iba't ibang Paraan

May ilang paraan para subukan at makipag-interact sa mga tools na ibinibigay ng server, depende sa iyong pangangailangan at workflow.

#### Pagsulat ng Custom Test Scripts gamit ang MCP Python SDK
Maaari ka ring gumawa ng sarili mong test scripts gamit ang MCP Python SDK:

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

Sa kontekstong ito, ang "test script" ay isang custom na Python program na sinusulat mo para maging client ng MCP server. Sa halip na isang pormal na unit test, pinapayagan ka nitong programmatically kumonekta sa server, tawagan ang alinmang tool nito gamit ang mga parameter na pipiliin mo, at suriin ang mga resulta. Kapaki-pakinabang ito para sa:

- Prototyping at pag-eeksperimento sa mga tawag ng tool
- Pag-validate kung paano tumutugon ang server sa iba't ibang input
- Pag-automate ng paulit-ulit na paggamit ng tool
- Paggawa ng sariling workflows o integrasyon sa ibabaw ng MCP server

Magagamit mo ang mga test script para mabilis na subukan ang mga bagong query, i-debug ang pag-uugali ng tool, o bilang panimulang punto para sa mas advanced na automation. Narito ang halimbawa kung paano gamitin ang MCP Python SDK para gumawa ng ganitong script:

## Paglalarawan ng mga Tool

Maaari mong gamitin ang mga sumusunod na tools na ibinibigay ng server para magsagawa ng iba't ibang uri ng paghahanap at query. Bawat tool ay inilalarawan sa ibaba kasama ang mga parameter nito at halimbawa ng paggamit.

Seksiyong ito ay nagbibigay ng detalye tungkol sa bawat tool na available at ang mga parameter nito.

### general_search

Nagsasagawa ng pangkalahatang paghahanap sa web at nagbabalik ng mga naka-format na resulta.

**Paano tawagan ang tool na ito:**

Maaari mong tawagan ang `general_search` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o ang interactive client mode. Narito ang halimbawa ng code gamit ang SDK:

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

Naghahanap ng mga pinakabagong artikulo ng balita na may kaugnayan sa query.

**Paano tawagan ang tool na ito:**

Maaari mong tawagan ang `news_search` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o ang interactive client mode. Narito ang halimbawa ng code gamit ang SDK:

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

Naghahanap ng mga produktong tumutugma sa query.

**Paano tawagan ang tool na ito:**

Maaari mong tawagan ang `product_search` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o ang interactive client mode. Narito ang halimbawa ng code gamit ang SDK:

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

**Paano tawagan ang tool na ito:**

Maaari mong tawagan ang `qna` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o ang interactive client mode. Narito ang halimbawa ng code gamit ang SDK:

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
- `question` (string): Ang tanong na nais sagutin

**Halimbawa ng Request:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Detalye ng Code

Seksiyong ito ay nagbibigay ng mga snippet ng code at mga reference para sa implementasyon ng server at client.

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

Bago ka magsimula sa paggawa, narito ang ilang mahahalagang advanced na konsepto na lilitaw sa buong kabanatang ito. Ang pag-unawa sa mga ito ay makakatulong sa iyo na masundan ang aralin, kahit bago ka pa lang dito:

- **Multi-tool Orchestration**: Ibig sabihin nito ay pagpapatakbo ng iba't ibang tools (tulad ng web search, news search, product search, at Q&A) sa iisang MCP server. Pinapayagan nitong hawakan ng server ang iba't ibang uri ng gawain, hindi lang isa.
- **Pag-handle ng API Rate Limit**: Maraming external API (tulad ng SerpAPI) ang nililimitahan kung ilang requests ang pwede mong gawin sa loob ng isang takdang oras. Magandang code ang nagche-check sa mga limitasyong ito at maayos na humahandle kapag naabot ang limit para hindi mag-crash ang app mo.
- **Pag-parse ng Structured Data**: Madalas kumplikado at nested ang mga sagot mula sa API. Ang konseptong ito ay tungkol sa pag-convert ng mga sagot na ito sa malinis at madaling gamitin na format para sa LLM o ibang programa.
- **Pag-recover mula sa Error**: Minsan may mga problema—maaaring pumalya ang network, o hindi inaasahan ang sagot ng API. Ang pag-recover mula sa error ay nangangahulugan na kaya ng code mong harapin ang mga problemang ito at magbigay pa rin ng kapaki-pakinabang na feedback, sa halip na mag-crash.
- **Pag-validate ng Parameter**: Tungkol ito sa pagsigurong tama at ligtas gamitin ang lahat ng input sa iyong mga tools. Kasama dito ang pagtatakda ng default values at pagsigurong tama ang mga uri, na tumutulong maiwasan ang bugs at kalituhan.

Seksiyong ito ay tutulong sa iyo na ma-diagnose at maresolba ang mga karaniwang problema na maaaring maranasan habang nagtatrabaho sa Web Search MCP Server. Kung makaranas ka ng error o hindi inaasahang pag-uugali habang ginagamit ang Web Search MCP Server, ang seksyong ito sa troubleshooting ay nagbibigay ng mga solusyon sa mga pinakakaraniwang isyu. Suriin muna ang mga tips na ito bago humingi ng karagdagang tulong—madalas itong nakakatulong para mabilis na maresolba ang problema.

## Troubleshooting

Kapag nagtatrabaho sa Web Search MCP Server, maaaring paminsan-minsan kang makaranas ng mga isyu—normal ito kapag nagde-develop gamit ang mga external API at bagong tools. Nagbibigay ang seksyong ito ng praktikal na mga solusyon sa mga pinakakaraniwang problema, para makabalik ka agad sa tamang daan. Kung makakita ka ng error, simulan dito: tinatalakay ng mga tips sa ibaba ang mga isyung madalas maranasan ng mga user at kadalasang nakakatulong para maresolba ang problema nang hindi na kailangan ng dagdag na tulong.

### Mga Karaniwang Isyu

Narito ang ilan sa mga madalas na problema na nararanasan ng mga user, kasama ang malinaw na paliwanag at mga hakbang para maresolba ito:

1. **Walang SERPAPI_KEY sa .env file**
   - Kung makita mo ang error na `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` file kung kinakailangan. Kung tama ang iyong key pero patuloy ang error, tingnan kung naubos na ang quota ng iyong libreng tier.

### Debug Mode

Sa default, naglo-log lang ang app ng mga mahahalagang impormasyon. Kung gusto mong makita ang mas detalyadong nangyayari (halimbawa, para ma-diagnose ang mga komplikadong isyu), maaari mong i-enable ang DEBUG mode. Ipapakita nito ang mas maraming detalye sa bawat hakbang na ginagawa ng app.

**Halimbawa: Normal Output**
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

Mapapansin na sa DEBUG mode, may dagdag na mga linya tungkol sa HTTP requests, mga sagot, at iba pang internal na detalye. Malaking tulong ito sa troubleshooting.

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

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakitandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o kamalian. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.