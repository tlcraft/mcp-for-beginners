<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:52:13+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "pa"
}
-->
# Lesson: Building a Web Search MCP Server

ਇਸ ਅਧਿਆਇ ਵਿੱਚ ਦਿਖਾਇਆ ਗਿਆ ਹੈ ਕਿ ਕਿਵੇਂ ਇੱਕ ਅਸਲੀ ਦੁਨੀਆ ਦਾ AI ਏਜੰਟ ਬਣਾਇਆ ਜਾਵੇ ਜੋ ਬਾਹਰੀ APIs ਨਾਲ ਜੁੜਦਾ ਹੈ, ਵੱਖ-ਵੱਖ ਡਾਟਾ ਕਿਸਮਾਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ, ਗਲਤੀਆਂ ਨੂੰ ਮੈਨੇਜ ਕਰਦਾ ਹੈ, ਅਤੇ ਕਈ ਟੂਲਾਂ ਨੂੰ ਇੱਕਠੇ ਚਲਾਉਂਦਾ ਹੈ—ਸਭ ਕੁਝ ਇੱਕ ਪ੍ਰੋਡਕਸ਼ਨ-ਤਿਆਰ ਫਾਰਮੈਟ ਵਿੱਚ। ਤੁਸੀਂ ਵੇਖੋਗੇ:

- **ਪ੍ਰਮਾਣਿਕਤਾ ਦੀ ਲੋੜ ਵਾਲੇ ਬਾਹਰੀ APIs ਨਾਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ**
- **ਕਈ ਐਂਡਪੌਇੰਟਾਂ ਤੋਂ ਵੱਖ-ਵੱਖ ਡਾਟਾ ਕਿਸਮਾਂ ਨੂੰ ਸੰਭਾਲਣਾ**
- **ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲਣ ਅਤੇ ਲੌਗਿੰਗ ਰਣਨੀਤੀਆਂ**
- **ਇੱਕ ਸਿੰਗਲ ਸਰਵਰ ਵਿੱਚ ਕਈ ਟੂਲਾਂ ਦੀ ਸੰਚਾਲਨਾ**

ਅੰਤ ਤੱਕ, ਤੁਹਾਡੇ ਕੋਲ ਅਜਿਹੇ ਪੈਟਰਨ ਅਤੇ ਬਿਹਤਰ ਅਭਿਆਸਾਂ ਦਾ ਅਮਲੀ ਤਜਰਬਾ ਹੋਵੇਗਾ ਜੋ ਉੱਚ ਦਰਜੇ ਦੇ AI ਅਤੇ LLM-ਚਲਿਤ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਜਰੂਰੀ ਹਨ।

## ਪਰਿਚਯ

ਇਸ ਪਾਠ ਵਿੱਚ, ਤੁਸੀਂ ਸਿੱਖੋਗੇ ਕਿ ਕਿਵੇਂ ਇੱਕ ਅਡਵਾਂਸ MCP ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਬਣਾਇਆ ਜਾਵੇ ਜੋ SerpAPI ਦੀ ਵਰਤੋਂ ਨਾਲ LLM ਦੀਆਂ ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਵੈੱਬ ਡਾਟਾ ਨਾਲ ਵਧਾਉਂਦਾ ਹੈ। ਇਹ ਇੱਕ ਮਹੱਤਵਪੂਰਨ ਹੁਨਰ ਹੈ ਜੋ ਡਾਇਨਾਮਿਕ AI ਏਜੰਟ ਵਿਕਸਿਤ ਕਰਨ ਲਈ ਜਰੂਰੀ ਹੈ ਜੋ ਵੈੱਬ ਤੋਂ ਅਪ-ਟੂ-ਡੇਟ ਜਾਣਕਾਰੀ ਪ੍ਰਾਪਤ ਕਰ ਸਕਦੇ ਹਨ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੇ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਵਿੱਚ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- ਬਾਹਰੀ APIs (ਜਿਵੇਂ ਕਿ SerpAPI) ਨੂੰ MCP ਸਰਵਰ ਵਿੱਚ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਜੋੜਨਾ
- ਵੈੱਬ, ਖ਼ਬਰਾਂ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ ਪ੍ਰਸ਼ਨ-ਉੱਤਰ ਲਈ ਕਈ ਟੂਲ ਲਾਗੂ ਕਰਨਾ
- LLM ਲਈ ਸੰਰਚਿਤ ਡਾਟਾ ਨੂੰ ਪਾਰਸ ਅਤੇ ਫਾਰਮੈਟ ਕਰਨਾ
- ਗਲਤੀਆਂ ਨੂੰ ਸੰਭਾਲਣਾ ਅਤੇ API ਦੀਆਂ ਰੇਟ ਸੀਮਾਵਾਂ ਨੂੰ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਤਰੀਕੇ ਨਾਲ ਮੈਨੇਜ ਕਰਨਾ
- ਦੋਹਾਂ ਆਟੋਮੇਟਿਕ ਅਤੇ ਇੰਟਰਐਕਟਿਵ MCP ਕਲਾਇੰਟ ਬਣਾਉਣਾ ਅਤੇ ਟੈਸਟ ਕਰਨਾ

## ਵੈੱਬ ਸਰਚ MCP ਸਰਵਰ

ਇਸ ਹਿੱਸੇ ਵਿੱਚ ਵੈੱਬ ਸਰਚ MCP ਸਰਵਰ ਦੀ ਆਰਕੀਟੈਕਚਰ ਅਤੇ ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਦਾ ਪਰਿਚਯ ਕਰਵਾਇਆ ਗਿਆ ਹੈ। ਤੁਸੀਂ ਵੇਖੋਗੇ ਕਿ ਕਿਵੇਂ FastMCP ਅਤੇ SerpAPI ਨੂੰ ਇੱਕਠੇ ਵਰਤ ਕੇ LLM ਦੀਆਂ ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਵੈੱਬ ਡਾਟਾ ਨਾਲ ਵਧਾਇਆ ਜਾਂਦਾ ਹੈ।

### ਓਵਰਵਿਊ

ਇਸ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਵਿੱਚ ਚਾਰ ਟੂਲ ਹਨ ਜੋ MCP ਦੀ ਸਮਰੱਥਾ ਨੂੰ ਦਰਸਾਉਂਦੇ ਹਨ ਕਿ ਇਹ ਕਿਵੇਂ ਵੱਖ-ਵੱਖ, ਬਾਹਰੀ API-ਚਲਿਤ ਕੰਮਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਅਤੇ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲ ਸਕਦਾ ਹੈ:

- **general_search**: ਵਿਆਪਕ ਵੈੱਬ ਨਤੀਜੇ ਲਈ
- **news_search**: ਤਾਜ਼ਾ ਸਿਰਲੇਖਾਂ ਲਈ
- **product_search**: ਈ-ਕਾਮਰਸ ਡਾਟਾ ਲਈ
- **qna**: ਸਵਾਲ-ਜਵਾਬ ਸਨਿੱਪੇਟਸ ਲਈ

### ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ
- **ਕੋਡ ਉਦਾਹਰਨਾਂ**: ਭਾਸ਼ਾ-ਵਿਸ਼ੇਸ਼ ਕੋਡ ਬਲਾਕਾਂ ਨੂੰ ਸ਼ਾਮਿਲ ਕਰਦਾ ਹੈ ਜਿਵੇਂ ਕਿ Python (ਅਤੇ ਆਸਾਨੀ ਨਾਲ ਹੋਰ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਵਧਾਇਆ ਜਾ ਸਕਦਾ ਹੈ) ਜੋ ਸਪਸ਼ਟਤਾ ਲਈ ਕਾਲੈਪਸਿਬਲ ਸੈਕਸ਼ਨਾਂ ਵਿੱਚ ਹਨ

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

ਕਲਾਇੰਟ ਚਲਾਉਣ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਸਮਝਣਾ ਲਾਭਦਾਇਕ ਹੈ ਕਿ ਸਰਵਰ ਕੀ ਕਰਦਾ ਹੈ। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)।

ਇੱਥੇ ਇੱਕ ਛੋਟਾ ਉਦਾਹਰਨ ਹੈ ਕਿ ਕਿਵੇਂ ਸਰਵਰ ਇੱਕ ਟੂਲ ਨੂੰ ਡਿਫਾਈਨ ਅਤੇ ਰਜਿਸਟਰ ਕਰਦਾ ਹੈ:

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

- **ਬਾਹਰੀ API ਇੰਟੀਗ੍ਰੇਸ਼ਨ**: API ਕੁੰਜੀਆਂ ਅਤੇ ਬਾਹਰੀ ਬੇਨਤੀਆਂ ਦੀ ਸੁਰੱਖਿਅਤ ਹੈਂਡਲਿੰਗ ਦਿਖਾਉਂਦਾ ਹੈ
- **ਸੰਰਚਿਤ ਡਾਟਾ ਪਾਰਸਿੰਗ**: API ਜਵਾਬਾਂ ਨੂੰ LLM-ਫ੍ਰੈਂਡਲੀ ਫਾਰਮੈਟ ਵਿੱਚ ਬਦਲਣ ਦਾ ਤਰੀਕਾ ਦਿਖਾਉਂਦਾ ਹੈ
- **ਗਲਤੀ ਸੰਭਾਲਣ**: ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲਣ ਅਤੇ ਉਚਿਤ ਲੌਗਿੰਗ
- **ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ**: ਆਟੋਮੇਟਿਕ ਟੈਸਟ ਅਤੇ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਦੋਹਾਂ ਸ਼ਾਮਿਲ ਹਨ
- **ਕੰਟੈਕਸਟ ਮੈਨੇਜਮੈਂਟ**: MCP Context ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਲੌਗਿੰਗ ਅਤੇ ਬੇਨਤੀਆਂ ਦੀ ਟ੍ਰੈਕਿੰਗ ਲਈ

## ਪਹਿਲਾਂ ਦੀਆਂ ਲੋੜਾਂ

ਸ਼ੁਰੂ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਹਾਡਾ ਮਾਹੌਲ ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਸੈੱਟ ਹੈ। ਇਹ ਸਾਰੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰਨ ਅਤੇ ਤੁਹਾਡੇ API ਕੁੰਜੀਆਂ ਨੂੰ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਕੰਫਿਗਰ ਕਰਨ ਵਿੱਚ ਮਦਦ ਕਰੇਗਾ ਤਾਂ ਜੋ ਵਿਕਾਸ ਅਤੇ ਟੈਸਟਿੰਗ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਹੋ ਸਕੇ।

- Python 3.8 ਜਾਂ ਉਸ ਤੋਂ ਉਪਰ
- SerpAPI API ਕੁੰਜੀ (ਸਾਈਨ ਅਪ ਕਰੋ [SerpAPI](https://serpapi.com/) 'ਤੇ - ਮੁਫ਼ਤ ਟੀਅਰ ਉਪਲਬਧ)

## ਇੰਸਟਾਲੇਸ਼ਨ

ਆਰੰਭ ਕਰਨ ਲਈ, ਆਪਣੇ ਮਾਹੌਲ ਨੂੰ ਸੈੱਟ ਕਰਨ ਲਈ ਇਹ ਕਦਮ ਫੋਲੋ ਕਰੋ:

1. uv (ਸਿਫਾਰਸ਼ੀ) ਜਾਂ pip ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. ਪ੍ਰੋਜੈਕਟ ਰੂਟ ਵਿੱਚ `.env` ਫਾਇਲ ਬਣਾਓ ਅਤੇ ਆਪਣੀ SerpAPI ਕੁੰਜੀ ਸ਼ਾਮਿਲ ਕਰੋ:

```
SERPAPI_KEY=your_serpapi_key_here
```

## ਵਰਤੋਂ

ਵੈੱਬ ਸਰਚ MCP ਸਰਵਰ ਮੁੱਖ ਭਾਗ ਹੈ ਜੋ ਵੈੱਬ, ਖ਼ਬਰਾਂ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ ਪ੍ਰਸ਼ਨ-ਉੱਤਰ ਲਈ ਟੂਲ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ SerpAPI ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰਕੇ। ਇਹ ਆਉਣ ਵਾਲੀਆਂ ਬੇਨਤੀਆਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ, API ਕਾਲਾਂ ਨੂੰ ਮੈਨੇਜ ਕਰਦਾ ਹੈ, ਜਵਾਬਾਂ ਨੂੰ ਪਾਰਸ ਕਰਦਾ ਹੈ, ਅਤੇ ਗ੍ਰਾਹਕ ਨੂੰ ਸੰਰਚਿਤ ਨਤੀਜੇ ਵਾਪਸ ਕਰਦਾ ਹੈ।

ਤੁਸੀਂ ਪੂਰੀ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਨੂੰ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ਵਿੱਚ ਵੇਖ ਸਕਦੇ ਹੋ।

### ਸਰਵਰ ਚਲਾਉਣਾ

MCP ਸਰਵਰ ਸ਼ੁਰੂ ਕਰਨ ਲਈ, ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਵਰਤੋ:

```bash
python server.py
```

ਸਰਵਰ stdio-ਆਧਾਰਿਤ MCP ਸਰਵਰ ਵਜੋਂ ਚੱਲੇਗਾ ਜਿਸ ਨਾਲ ਕਲਾਇੰਟ ਸਿੱਧਾ ਜੁੜ ਸਕਦਾ ਹੈ।

### ਕਲਾਇੰਟ ਮੋਡ

ਕਲਾਇੰਟ (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)।

### ਕਲਾਇੰਟ ਚਲਾਉਣਾ

ਆਟੋਮੇਟਿਕ ਟੈਸਟ ਚਲਾਉਣ ਲਈ (ਇਸ ਨਾਲ ਸਰਵਰ ਆਪਣੇ ਆਪ ਸ਼ੁਰੂ ਹੋ ਜਾਵੇਗਾ):

```bash
python client.py
```

ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ ਚਲਾਓ:

```bash
python client.py --interactive
```

### ਵੱਖ-ਵੱਖ ਤਰੀਕਿਆਂ ਨਾਲ ਟੈਸਟਿੰਗ

ਸਰਵਰ ਵੱਲੋਂ ਦਿੱਤੇ ਟੂਲਾਂ ਨਾਲ ਟੈਸਟ ਕਰਨ ਅਤੇ ਇੰਟਰਐਕਟ ਕਰਨ ਦੇ ਕਈ ਤਰੀਕੇ ਹਨ, ਜੋ ਤੁਹਾਡੇ ਜ਼ਰੂਰਤਾਂ ਅਤੇ ਕੰਮ ਦੇ ਤਰੀਕੇ 'ਤੇ ਨਿਰਭਰ ਕਰਦੇ ਹਨ।

#### MCP Python SDK ਨਾਲ ਕਸਟਮ ਟੈਸਟ ਸਕ੍ਰਿਪਟ ਲਿਖਣਾ

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ ਟੈਸਟ ਸਕ੍ਰਿਪਟ ਵੀ ਬਣਾ ਸਕਦੇ ਹੋ:

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

ਇਸ ਸੰਦਰਭ ਵਿੱਚ, "ਟੈਸਟ ਸਕ੍ਰਿਪਟ" ਦਾ ਮਤਲਬ ਹੈ ਇੱਕ ਕਸਟਮ Python ਪ੍ਰੋਗਰਾਮ ਜੋ ਤੁਸੀਂ MCP ਸਰਵਰ ਲਈ ਕਲਾਇੰਟ ਵਜੋਂ ਲਿਖਦੇ ਹੋ। ਇਹ ਇੱਕ ਰਸਮੀ ਯੂਨਿਟ ਟੈਸਟ ਨਹੀਂ ਹੈ, ਪਰ ਇਹ ਸਕ੍ਰਿਪਟ ਤੁਹਾਨੂੰ ਸਰਵਰ ਨਾਲ ਪ੍ਰੋਗਰਾਮੈਟਿਕ ਤਰੀਕੇ ਨਾਲ ਜੁੜਨ, ਕਿਸੇ ਵੀ ਟੂਲ ਨੂੰ ਚਲਾਉਣ ਅਤੇ ਨਤੀਜੇ ਦੇਖਣ ਦੀ ਆਜ਼ਾਦੀ ਦਿੰਦੀ ਹੈ। ਇਹ ਤਰੀਕਾ ਲਾਭਦਾਇਕ ਹੈ:

- ਟੂਲ ਕਾਲਾਂ ਦਾ ਪ੍ਰੋਟੋਟਾਈਪ ਬਣਾਉਣ ਅਤੇ ਪ੍ਰਯੋਗ ਕਰਨ ਲਈ
- ਵੱਖ-ਵੱਖ ਇਨਪੁਟਸ 'ਤੇ ਸਰਵਰ ਦੇ ਜਵਾਬ ਨੂੰ ਵੈਰੀਫਾਈ ਕਰਨ ਲਈ
- ਟੂਲਾਂ ਦੀ ਵਾਰ-ਵਾਰ ਕਾਲ ਆਟੋਮੇਟ ਕਰਨ ਲਈ
- ਆਪਣੇ ਕੰਮ ਦੇ ਪ੍ਰਵਾਹ ਜਾਂ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਬਨਾਉਣ ਲਈ

ਤੁਸੀਂ ਟੈਸਟ ਸਕ੍ਰਿਪਟਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਨਵੇਂ ਕਵੈਰੀਜ਼ ਨੂੰ ਤੇਜ਼ੀ ਨਾਲ ਆਜ਼ਮਾ ਸਕਦੇ ਹੋ, ਟੂਲਾਂ ਦੇ ਵਿਹਾਰ ਨੂੰ ਡਿਬੱਗ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇਹਨਾਂ ਨੂੰ ਵਧੇਰੇ ਅਡਵਾਂਸ ਆਟੋਮੇਸ਼ਨ ਲਈ ਬੇਸ ਵਜੋਂ ਵਰਤ ਸਕਦੇ ਹੋ। ਹੇਠਾਂ MCP Python SDK ਨਾਲ ਅਜਿਹਾ ਸਕ੍ਰਿਪਟ ਬਣਾਉਣ ਦਾ ਉਦਾਹਰਨ ਦਿੱਤਾ ਗਿਆ ਹੈ:

## ਟੂਲ ਵੇਰਵੇ

ਸਰਵਰ ਵੱਲੋਂ ਦਿੱਤੇ ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਤੁਸੀਂ ਵੱਖ-ਵੱਖ ਕਿਸਮ ਦੀਆਂ ਖੋਜਾਂ ਅਤੇ ਪੁੱਛਗਿੱਛਾਂ ਕਰ ਸਕਦੇ ਹੋ। ਹਰ ਟੂਲ ਆਪਣੇ ਪੈਰਾਮੀਟਰਾਂ ਅਤੇ ਉਦਾਹਰਨ ਵਰਤੋਂ ਨਾਲ ਹੇਠਾਂ ਵਿਆਖਿਆਤ ਹੈ।

ਇਸ ਹਿੱਸੇ ਵਿੱਚ ਹਰ ਉਪਲਬਧ ਟੂਲ ਅਤੇ ਉਸਦੇ ਪੈਰਾਮੀਟਰਾਂ ਬਾਰੇ ਵੇਰਵਾ ਦਿੱਤਾ ਗਿਆ ਹੈ।

### general_search

ਇਹ ਆਮ ਵੈੱਬ ਖੋਜ ਕਰਦਾ ਹੈ ਅਤੇ ਫਾਰਮੈਟ ਕੀਤੇ ਨਤੀਜੇ ਵਾਪਸ ਕਰਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ `general_search` ਨੂੰ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਵਿੱਚ ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਦੀ ਵਰਤੋਂ ਕਰਕੇ। SDK ਨਾਲ ਕੋਡ ਉਦਾਹਰਨ ਇੱਥੇ ਹੈ:

<details>
<summary>Python Example</summary>

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ, `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): ਖੋਜ ਪੁੱਛਗਿੱਛ

**ਉਦਾਹਰਨ ਬੇਨਤੀ:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

ਇਹ ਖੋਜਦਾ ਹੈ ਤਾਜ਼ਾ ਖ਼ਬਰਾਂ ਦੇ ਲੇਖ ਜੋ ਕਿਸੇ ਪੁੱਛਗਿੱਛ ਨਾਲ ਸਬੰਧਤ ਹਨ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ `news_search` ਨੂੰ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਵਿੱਚ ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਦੀ ਵਰਤੋਂ ਕਰਕੇ। SDK ਨਾਲ ਕੋਡ ਉਦਾਹਰਨ ਇੱਥੇ ਹੈ:

<details>
<summary>Python Example</summary>

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ, `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): ਖੋਜ ਪੁੱਛਗਿੱਛ

**ਉਦਾਹਰਨ ਬੇਨਤੀ:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

ਇਹ ਉਤਪਾਦਾਂ ਦੀ ਖੋਜ ਕਰਦਾ ਹੈ ਜੋ ਕਿਸੇ ਪੁੱਛਗਿੱਛ ਨਾਲ ਮੇਲ ਖਾਂਦੇ ਹਨ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ `product_search` ਨੂੰ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਵਿੱਚ ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਦੀ ਵਰਤੋਂ ਕਰਕੇ। SDK ਨਾਲ ਕੋਡ ਉਦਾਹਰਨ ਇੱਥੇ ਹੈ:

<details>
<summary>Python Example</summary>

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ, `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): ਉਤਪਾਦ ਖੋਜ ਪੁੱਛਗਿੱਛ

**ਉਦਾਹਰਨ ਬੇਨਤੀ:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

ਖੋਜ ਇੰਜਣਾਂ ਤੋਂ ਸਵਾਲਾਂ ਦੇ ਸਿੱਧੇ ਜਵਾਬ ਪ੍ਰਾਪਤ ਕਰਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ `qna` ਨੂੰ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਵਿੱਚ ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਦੀ ਵਰਤੋਂ ਕਰਕੇ। SDK ਨਾਲ ਕੋਡ ਉਦਾਹਰਨ ਇੱਥੇ ਹੈ:

<details>
<summary>Python Example</summary>

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ, `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): ਜਵਾਬ ਲੱਭਣ ਲਈ ਸਵਾਲ

**ਉਦਾਹਰਨ ਬੇਨਤੀ:**

```json
{
  "question": "what is artificial intelligence"
}
```

## ਕੋਡ ਵੇਰਵੇ

ਇਸ ਹਿੱਸੇ ਵਿੱਚ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਕੋਡ ਸਨਿੱਪੇਟ ਅਤੇ ਰੈਫਰੰਸ ਦਿੱਤੇ ਗਏ ਹਨ।

<details>
<summary>Python</summary>

ਪੂਰੀ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਵੇਖਣ ਲਈ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) ਨੂੰ ਦੇਖੋ।

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## ਇਸ ਪਾਠ ਵਿੱਚ ਅਡਵਾਂਸ ਸੰਕਲਪ

ਬਣਾਉਣ ਤੋਂ ਪਹਿਲਾਂ, ਇੱਥੇ ਕੁਝ ਮਹੱਤਵਪੂਰਨ ਅਡਵਾਂਸ ਸੰਕਲਪ ਹਨ ਜੋ ਇਸ ਅਧਿਆਇ ਵਿੱਚ ਵੱਖ-ਵੱਖ ਥਾਵਾਂ ਤੇ ਆਉਣਗੇ। ਇਹਨਾਂ ਨੂੰ ਸਮਝਣਾ ਤੁਹਾਨੂੰ ਅੱਗੇ ਚੱਲ ਕੇ ਮਦਦ ਕਰੇਗਾ, ਖਾਸ ਕਰਕੇ ਜੇ ਤੁਸੀਂ ਨਵੇਂ ਹੋ:

- **ਮਲਟੀ-ਟੂਲ ਸੰਚਾਲਨਾ**: ਇਸਦਾ ਮਤਲਬ ਹੈ ਕਿ ਕਈ ਵੱਖ-ਵੱਖ ਟੂਲ (ਜਿਵੇਂ ਵੈੱਬ ਸਰਚ, ਖ਼ਬਰਾਂ ਦੀ ਖੋਜ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ ਪ੍ਰਸ਼ਨ-ਉੱਤਰ) ਨੂੰ ਇੱਕ MCP ਸਰਵਰ ਵਿੱਚ ਚਲਾਉਣਾ। ਇਹ ਤੁਹਾਡੇ ਸਰਵਰ ਨੂੰ ਕਈ ਕਿਸਮ ਦੇ ਕੰਮ ਕਰਨ ਦੀ ਸਮਰੱਥਾ ਦਿੰਦਾ ਹੈ, ਸਿਰਫ ਇੱਕ ਨਹੀਂ।
- **API ਰੇਟ ਲਿਮਿਟ ਸੰਭਾਲਣਾ**: ਬਹੁਤ ਸਾਰੇ ਬਾਹਰੀ APIs (ਜਿਵੇਂ SerpAPI) ਇਹ ਸੀਮਤ ਕਰਦੇ ਹਨ ਕਿ ਤੁਸੀਂ ਇੱਕ ਨਿਸ਼ਚਿਤ ਸਮੇਂ ਵਿੱਚ ਕਿੰਨੀ ਬੇਨਤੀਆਂ ਕਰ ਸਕਦੇ ਹੋ। ਵਧੀਆ ਕੋਡ ਇਹ ਸੀਮਾਵਾਂ ਦੀ ਜਾਂਚ ਕਰਦਾ ਹੈ ਅਤੇ ਉਨ੍ਹਾਂ ਨੂੰ ਸੁਚੱਜੇ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲਦਾ ਹੈ, ਤਾਂ ਜੋ ਜੇ ਤੁਸੀਂ ਸੀਮਾ ਪਾਰ ਕਰ ਜਾਓ ਤਾਂ ਐਪ ਤੂਟੇ ਨਾ।
- **ਸੰਰਚਿਤ ਡਾਟਾ ਪਾਰਸਿੰਗ**: API ਜਵਾਬ ਅਕਸਰ ਜਟਿਲ ਅਤੇ ਨੇਸਟਡ ਹੁੰਦੇ ਹਨ। ਇਹ ਸੰਕਲਪ ਉਹਨਾਂ ਜਵਾਬਾਂ ਨੂੰ ਸਾਫ, ਆਸਾਨ-ਵਰਤੋਂ ਵਾਲੇ ਫਾਰਮੈਟ ਵਿੱਚ ਬਦਲਣ ਬਾਰੇ ਹੈ ਜੋ LLM ਜਾਂ ਹੋਰ ਪ੍ਰੋਗਰਾਮਾਂ ਲਈ ਅਨੁਕੂਲ ਹੁੰਦੇ ਹਨ।
- **ਗਲਤੀ ਮੁੜ-ਪ੍ਰਾਪਤੀ**: ਕਦੇ-

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਆਟੋਮੈਟਿਕ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਹੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਅਧਿਕਾਰਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫ਼ਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਪਜਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਵਰਣਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।