<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:22:07+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "tl"
}
-->
# Lesson: Pagbuo ng Web Search MCP Server

Ipinapakita sa kabanatang ito kung paano bumuo ng isang tunay na AI agent na nakakabit sa mga external API, humahawak ng iba't ibang uri ng data, nagmamanage ng mga error, at nagsasaayos ng maraming tools—lahat sa isang production-ready na format. Makikita mo ang:

- **Integrasyon sa mga external API na nangangailangan ng authentication**
- **Paghawak ng iba't ibang uri ng data mula sa maraming endpoints**
- **Matatag na error handling at mga estratehiya sa pag-log**
- **Pagsasabay-sabay ng maraming tools sa iisang server**

Sa katapusan, magkakaroon ka ng praktikal na karanasan sa mga pattern at best practices na mahalaga para sa mga advanced na AI at LLM-powered na aplikasyon.

## Panimula

Sa araling ito, matututuhan mo kung paano bumuo ng advanced na MCP server at client na nagpapalawak ng kakayahan ng LLM gamit ang real-time na web data gamit ang SerpAPI. Isa itong kritikal na kasanayan para makabuo ng mga dynamic na AI agent na kayang kumuha ng pinakabagong impormasyon mula sa web.

## Mga Layunin ng Pagkatuto

Sa katapusan ng araling ito, magagawa mong:

- I-integrate nang ligtas ang mga external API (tulad ng SerpAPI) sa MCP server
- Magpatupad ng maraming tools para sa web, balita, paghahanap ng produkto, at Q&A
- I-parse at i-format ang structured data para sa paggamit ng LLM
- Mag-handle ng mga error at pamahalaan nang epektibo ang API rate limits
- Bumuo at mag-test ng parehong automated at interactive na MCP clients

## Web Search MCP Server

Ipinapakilala sa seksyong ito ang arkitektura at mga tampok ng Web Search MCP Server. Makikita mo kung paano pinagsasama ang FastMCP at SerpAPI upang palawakin ang kakayahan ng LLM gamit ang real-time na web data.

### Pangkalahatang-ideya

Ang implementasyong ito ay may apat na tools na nagpapakita ng kakayahan ng MCP na ligtas at mahusay na humawak ng iba't ibang gawain na pinapagana ng external API:

- **general_search**: Para sa malawakang resulta sa web
- **news_search**: Para sa mga pinakabagong balita
- **product_search**: Para sa datos ng e-commerce
- **qna**: Para sa mga snippet ng tanong at sagot

### Mga Tampok
- **Mga Halimbawa ng Code**: May mga language-specific na code blocks para sa Python (at madaling mapalawak sa ibang mga wika) gamit ang collapsible sections para sa kalinawan

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

Narito ang isang maikling halimbawa kung paano dine-define at nire-register ng server ang isang tool:

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

- **Integrasyon ng External API**: Ipinapakita ang ligtas na paghawak ng API keys at mga external na request
- **Pag-parse ng Structured Data**: Ipinapakita kung paano i-transform ang mga tugon mula sa API sa mga format na madaling gamitin ng LLM
- **Pag-handle ng Error**: Matatag na pag-handle ng error na may angkop na pag-log
- **Interactive Client**: May kasama parehong automated tests at interactive mode para sa pagsubok
- **Pamamahala ng Context**: Ginagamit ang MCP Context para sa pag-log at pagsubaybay ng mga request

## Mga Kinakailangan

Bago ka magsimula, siguraduhing maayos ang pagkaka-setup ng iyong kapaligiran sa pamamagitan ng pagsunod sa mga hakbang na ito. Titiyakin nito na lahat ng dependencies ay naka-install at ang iyong API keys ay na-configure nang tama para sa maayos na development at testing.

- Python 3.8 pataas
- SerpAPI API Key (Mag-sign up sa [SerpAPI](https://serpapi.com/) - may libreng tier)

## Pag-install

Para makapagsimula, sundin ang mga hakbang na ito para i-setup ang iyong kapaligiran:

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

Ang Web Search MCP Server ang pangunahing bahagi na naglalantad ng mga tools para sa web, balita, paghahanap ng produkto, at Q&A sa pamamagitan ng integrasyon sa SerpAPI. Pinangangasiwaan nito ang mga papasok na request, nagmamanage ng mga tawag sa API, nagpa-parse ng mga tugon, at nagbabalik ng mga naka-istrukturang resulta sa client.

Maaari mong suriin ang buong implementasyon sa [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Pagpapatakbo ng Server

Para simulan ang MCP server, gamitin ang sumusunod na utos:

```bash
python server.py
```

Tatakbo ang server bilang isang stdio-based MCP server na direktang makakonekta ang client.

### Mga Mode ng Client

Ang client (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Pagpapatakbo ng Client

Para patakbuhin ang automated tests (kasama na dito ang awtomatikong pagsisimula ng server):

```bash
python client.py
```

O patakbuhin sa interactive mode:

```bash
python client.py --interactive
```

### Pagsubok gamit ang Iba't ibang Paraan

Maraming paraan para subukan at makipag-interact sa mga tools na ibinibigay ng server, depende sa iyong pangangailangan at workflow.

#### Pagsusulat ng Custom Test Scripts gamit ang MCP Python SDK
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

Sa kontekstong ito, ang "test script" ay tumutukoy sa custom na Python program na iyong isinusulat bilang client para sa MCP server. Hindi ito pormal na unit test, kundi isang script na nagpapahintulot sa iyo na programmatically kumonekta sa server, tawagan ang alinmang tool nito gamit ang mga parameter na gusto mo, at suriin ang mga resulta. Maganda itong paraan para sa:

- Prototyping at eksperimento sa mga tawag sa tool
- Pag-validate kung paano tumutugon ang server sa iba't ibang inputs
- Pag-automate ng paulit-ulit na pag-invoke ng tools
- Pagbuo ng sarili mong workflows o integrasyon sa ibabaw ng MCP server

Maaari mong gamitin ang test scripts para mabilis na subukan ang mga bagong query, i-debug ang kilos ng mga tool, o bilang panimulang punto para sa mas advanced na automation. Narito ang halimbawa kung paano gamitin ang MCP Python SDK para gumawa ng ganitong script:

## Paglalarawan ng mga Tool

Maaari mong gamitin ang mga sumusunod na tools na ibinibigay ng server para magsagawa ng iba't ibang uri ng paghahanap at query. Bawat tool ay inilalarawan sa ibaba kasama ang mga parameter at halimbawa ng paggamit.

Ang seksyong ito ay nagbibigay ng detalye tungkol sa bawat magagamit na tool at ang kanilang mga parameter.

### general_search

Nagsasagawa ng pangkalahatang web search at nagbabalik ng mga naka-format na resulta.

**Paano tawagan ang tool na ito:**

Maaari mong tawagan ang `general_search` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o interactive client mode. Narito ang halimbawa ng code gamit ang SDK:

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

Naghahanap ng mga pinakabagong balita na may kaugnayan sa isang query.

**Paano tawagan ang tool na ito:**

Maaari mong tawagan ang `news_search` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o interactive client mode. Narito ang halimbawa ng code gamit ang SDK:

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

Naghahanap ng mga produkto na tumutugma sa isang query.

**Paano tawagan ang tool na ito:**

Maaari mong tawagan ang `product_search` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o interactive client mode. Narito ang halimbawa ng code gamit ang SDK:

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

Maaari mong tawagan ang `qna` mula sa sarili mong script gamit ang MCP Python SDK, o interactive gamit ang Inspector o interactive client mode. Narito ang halimbawa ng code gamit ang SDK:

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
- `question` (string): Ang tanong na hahanapan ng sagot

**Halimbawa ng Request:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Detalye ng Code

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

Bago ka magsimula sa pagbuo, narito ang ilang mahahalagang advanced na konsepto na lalabas sa buong kabanatang ito. Ang pag-unawa sa mga ito ay makakatulong sa iyong pagsunod, kahit bago ka pa sa mga ito:

- **Multi-tool Orchestration**: Ibig sabihin nito ay pagpapatakbo ng iba't ibang tools (tulad ng web search, news search, product search, at Q&A) sa loob ng isang MCP server. Pinapayagan nitong hawakan ng server ang iba’t ibang gawain, hindi lang isa.
- **Pag-handle ng API Rate Limit**: Maraming external API (tulad ng SerpAPI) ang may limitasyon kung ilang request ang maaari mong gawin sa isang takdang panahon. Mahusay na code ang nagche-check sa mga limitasyong ito at maayos na humahawak sa mga ito, para hindi mag-crash ang app kung maabot ang limit.
- **Pag-parse ng Structured Data**: Madalas na komplikado at nested ang mga tugon ng API. Ang konseptong ito ay tungkol sa pag-convert ng mga tugon na iyon sa malinis at madaling gamitin na mga format na friendly sa LLM o iba pang programa.
- **Pag-recover sa Error**: Minsan may mga problema—maaaring magka-network failure, o hindi ang inaasahang sagot ang ibalik ng API. Ang pag-recover sa error ay ibig sabihin na kaya ng iyong code na hawakan ang mga problemang ito at magbigay pa rin ng kapaki-pakinabang na feedback, imbes na mag-crash.
- **Pag-validate ng Parameter**: Ito ay tungkol sa pagsigurong tama at ligtas gamitin ang lahat ng inputs sa iyong mga tools. Kasama dito ang pagtatakda ng default values at pagsigurong tama ang mga uri ng data, na tumutulong maiwasan ang bugs at kalituhan.

Ang seksyong ito ay tutulong sa iyo na matukoy at maresolba ang mga karaniwang isyu na maaaring maranasan habang ginagamit ang Web Search MCP Server. Kung makaranas ka ng error o hindi inaasahang kilos habang nagtatrabaho sa Web Search MCP Server, nagbibigay ang troubleshooting section na ito ng mga solusyon sa mga pinakakaraniwang problema. Basahin muna ang mga tip na ito bago humingi ng karagdagang tulong—madalas itong nakakatulong agad na maresolba ang problema.

## Pag-troubleshoot

Kapag nagtatrabaho sa Web Search MCP Server, maaaring paminsan-minsan kang makaranas ng mga isyu—normal ito kapag nagde-develop gamit ang mga external API at bagong tools. Nagbibigay ang seksyong ito ng mga praktikal na solusyon sa mga pinakakaraniwang problema para mabilis kang makabalik sa tamang landas. Kapag may error, simulan dito: tinutugunan ng mga tip sa ibaba ang mga isyung madalas kaharapin ng mga user at madalas naayos ang problema nang hindi na kailangan ng karagdagang tulong.

### Mga Karaniwang Isyu

Narito ang ilan sa mga madalas na problema na nararanasan ng mga user, kasama ang malinaw na paliwanag at mga hakbang para maresolba:

1. **Kulang ang SERPAPI_KEY sa .env file**
   - Kung makita mo ang error na `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `, siguraduhing meron kang `.env` file kung kinakailangan. Kung tama ang iyong key pero lumalabas pa rin ang error, tingnan kung naubos na ang quota ng iyong free tier.

### Debug Mode

Sa default, naglo-log lang ang app ng mga importanteng impormasyon. Kung gusto mong makita ang mas detalyadong nangyayari (halimbawa, para ma-diagnose ang mga mahihirap na isyu), maaari mong i-enable ang DEBUG mode. Ipapakita nito ang mas marami pang detalye sa bawat hakbang na ginagawa ng app.

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

Mapapansin mo na sa DEBUG mode, may mga dagdag na linya tungkol sa mga HTTP request, response, at iba pang internal na detalye. Malaking tulong ito sa pag-troubleshoot.

Para i-enable ang DEBUG mode, itakda ang logging level sa DEBUG sa taas ng iyong `client.py` or `server.py`:

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

**Pagsasalin ng Teks to Tagalog:**

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o kamalian. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.