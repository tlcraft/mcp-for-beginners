<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:23:44+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "pa"
}
-->
# Lesson: Building a Web Search MCP Server

ਇਸ ਅਧਿਆਇ ਵਿੱਚ ਤੁਸੀਂ ਵੇਖੋਗੇ ਕਿ ਕਿਵੇਂ ਇੱਕ ਅਸਲ ਦੁਨੀਆ ਦਾ AI ਏਜੰਟ ਬਣਾਇਆ ਜਾ ਸਕਦਾ ਹੈ ਜੋ ਬਾਹਰੀ APIs ਨਾਲ ਇੰਟੀਗਰੇਟ ਕਰਦਾ ਹੈ, ਵੱਖ-ਵੱਖ ਡਾਟਾ ਕਿਸਮਾਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ, ਗਲਤੀਆਂ ਨੂੰ ਮੈਨੇਜ ਕਰਦਾ ਹੈ ਅਤੇ ਕਈ ਟੂਲਜ਼ ਨੂੰ ਇਕੱਠੇ ਚਲਾਉਂਦਾ ਹੈ—ਸਭ ਕੁਝ ਪ੍ਰੋਡਕਸ਼ਨ-ਤਿਆਰ ਫਾਰਮੈਟ ਵਿੱਚ। ਤੁਸੀਂ ਸਿੱਖੋਗੇ:

- **ਪ੍ਰਮਾਣਿਕਤਾ ਵਾਲੇ ਬਾਹਰੀ APIs ਨਾਲ ਇੰਟੀਗਰੇਸ਼ਨ**
- **ਕਈ ਸਰੋਤਾਂ ਤੋਂ ਵੱਖ-ਵੱਖ ਡਾਟਾ ਕਿਸਮਾਂ ਨੂੰ ਸੰਭਾਲਣਾ**
- **ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲਣ ਅਤੇ ਲਾਗਿੰਗ ਰਣਨੀਤੀਆਂ**
- **ਇੱਕ ਸਰਵਰ ਵਿੱਚ ਕਈ ਟੂਲਜ਼ ਦਾ ਸਹਿਯੋਗ**

ਅਖੀਰ ਵਿੱਚ, ਤੁਹਾਡੇ ਕੋਲ ਅਜਿਹੇ ਪੈਟਰਨ ਅਤੇ ਵਧੀਆ ਅਮਲਾਂ ਦਾ ਅਨੁਭਵ ਹੋਵੇਗਾ ਜੋ ਅੱਗੇ ਵਧੇ ਹੋਏ AI ਅਤੇ LLM-ਚਲਿਤ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਜਰੂਰੀ ਹਨ।

## ਪਰਿਚਯ

ਇਸ ਪਾਠ ਵਿੱਚ, ਤੁਸੀਂ ਸਿੱਖੋਗੇ ਕਿ ਕਿਵੇਂ ਇੱਕ ਅਡਵਾਂਸ MCP ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਬਣਾਇਆ ਜਾਵੇ ਜੋ SerpAPI ਦੀ ਵਰਤੋਂ ਕਰਕੇ LLM ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਵੈੱਬ ਡਾਟਾ ਨਾਲ ਵਧਾਉਂਦਾ ਹੈ। ਇਹ ਉਹ ਮਹੱਤਵਪੂਰਨ ਹੁਨਰ ਹੈ ਜੋ ਡਾਇਨਾਮਿਕ AI ਏਜੰਟ ਬਣਾਉਣ ਲਈ ਲੋੜੀਂਦਾ ਹੈ ਜੋ ਵੈੱਬ ਤੋਂ ਤਾਜ਼ਾ ਜਾਣਕਾਰੀ ਪ੍ਰਾਪਤ ਕਰ ਸਕਦੇ ਹਨ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- MCP ਸਰਵਰ ਵਿੱਚ ਬਾਹਰੀ APIs (ਜਿਵੇਂ SerpAPI) ਨੂੰ ਸੁਰੱਖਿਅਤ ਢੰਗ ਨਾਲ ਇੰਟੀਗਰੇਟ ਕਰਨਾ
- ਵੈੱਬ, ਖ਼ਬਰਾਂ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ ਸਵਾਲ-ਜਵਾਬ ਲਈ ਕਈ ਟੂਲਜ਼ ਲਾਗੂ ਕਰਨਾ
- LLM ਲਈ ਸੰਰਚਿਤ ਡਾਟਾ ਪਾਰਸ ਅਤੇ ਫਾਰਮੈਟ ਕਰਨਾ
- ਗਲਤੀਆਂ ਨੂੰ ਸੰਭਾਲਣਾ ਅਤੇ API ਦੀ ਰੇਟ ਲਿਮਿਟ ਨੂੰ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਤਰੀਕੇ ਨਾਲ ਮੈਨੇਜ ਕਰਨਾ
- ਦੋਹਾਂ ਆਟੋਮੈਟਿਕ ਅਤੇ ਇੰਟਰਐਕਟਿਵ MCP ਕਲਾਇੰਟ ਬਣਾਉਣਾ ਅਤੇ ਟੈਸਟ ਕਰਨਾ

## ਵੈੱਬ ਸર્ચ MCP ਸਰਵਰ

ਇਸ ਹਿੱਸੇ ਵਿੱਚ ਵੈੱਬ ਸર્ચ MCP ਸਰਵਰ ਦੀ ਆਰਕੀਟੈਕਚਰ ਅਤੇ ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਬਾਰੇ ਜਾਣਕਾਰੀ ਦਿੱਤੀ ਗਈ ਹੈ। ਤੁਸੀਂ ਵੇਖੋਗੇ ਕਿ ਕਿਵੇਂ FastMCP ਅਤੇ SerpAPI ਨੂੰ ਮਿਲਾ ਕੇ LLM ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਵੈੱਬ ਡਾਟਾ ਨਾਲ ਵਧਾਇਆ ਜਾਂਦਾ ਹੈ।

### ਓਵਰਵਿਊ

ਇਹ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਚਾਰ ਟੂਲਜ਼ ਸ਼ਾਮਲ ਕਰਦੀ ਹੈ ਜੋ MCP ਦੀ ਸਮਰੱਥਾ ਨੂੰ ਸੁਰੱਖਿਅਤ ਅਤੇ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਤਰੀਕੇ ਨਾਲ ਵੱਖ-ਵੱਖ ਬਾਹਰੀ API ਕੰਮਾਂ ਨੂੰ ਸੰਭਾਲਣ ਦਿਖਾਉਂਦੇ ਹਨ:

- **general_search**: ਵਿਆਪਕ ਵੈੱਬ ਨਤੀਜੇ ਲਈ
- **news_search**: ਤਾਜ਼ਾ ਸਿਰਲੇਖਾਂ ਲਈ
- **product_search**: ਈ-ਕਾਮਰਸ ਡਾਟਾ ਲਈ
- **qna**: ਸਵਾਲ-ਜਵਾਬ ਸਨਿੱਪੇਟਸ ਲਈ

### ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ
- **ਕੋਡ ਉਦਾਹਰਣ**: Python ਲਈ ਭਾਸ਼ਾ-ਵਿਸ਼ੇਸ਼ ਕੋਡ ਬਲਾਕਾਂ ਸਮੇਤ (ਅਸਾਨੀ ਨਾਲ ਹੋਰ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਵੀ ਵਧਾਇਆ ਜਾ ਸਕਦਾ ਹੈ) ਜੋ ਸਪਸ਼ਟਤਾ ਲਈ ਕਾਲੈਪਸਿਬਲ ਸੈਕਸ਼ਨ ਵਿੱਚ ਹਨ

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

ਕਲਾਇੰਟ ਚਲਾਉਣ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਜਾਣਨਾ ਫਾਇਦਾਮੰਦ ਹੈ ਕਿ ਸਰਵਰ ਕੀ ਕਰਦਾ ਹੈ। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)।

ਇੱਥੇ ਇੱਕ ਛੋਟਾ ਉਦਾਹਰਣ ਹੈ ਕਿ ਕਿਵੇਂ ਸਰਵਰ ਇੱਕ ਟੂਲ ਨੂੰ ਡਿਫਾਈਨ ਅਤੇ ਰਜਿਸਟਰ ਕਰਦਾ ਹੈ:

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

- **ਬਾਹਰੀ API ਇੰਟੀਗਰੇਸ਼ਨ**: API ਕੀਜ਼ ਅਤੇ ਬਾਹਰੀ ਬੇਨਤੀਆਂ ਦੀ ਸੁਰੱਖਿਅਤ ਸੰਭਾਲ ਦਿਖਾਉਂਦਾ ਹੈ
- **ਸੰਰਚਿਤ ਡਾਟਾ ਪਾਰਸਿੰਗ**: API ਜਵਾਬਾਂ ਨੂੰ LLM-ਮਿੱਤਰ ਫਾਰਮੈਟ ਵਿੱਚ ਬਦਲਣ ਦਾ ਤਰੀਕਾ ਦਿਖਾਉਂਦਾ ਹੈ
- **ਗਲਤੀ ਸੰਭਾਲਣ**: ਉਚਿਤ ਲਾਗਿੰਗ ਨਾਲ ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲਣ
- **ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ**: ਆਟੋਮੈਟਿਕ ਟੈਸਟਾਂ ਅਤੇ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਦੋਹਾਂ ਸ਼ਾਮਲ ਹਨ
- **ਕਾਂਟੈਕਸਟ ਮੈਨੇਜਮੈਂਟ**: MCP Context ਦਾ ਲਾਗਿੰਗ ਅਤੇ ਬੇਨਤੀ ਟ੍ਰੈਕਿੰਗ ਲਈ ਵਰਤੋਂ

## ਪਹਿਲਾਂ ਤੋਂ ਲੋੜੀਂਦਾ

ਸ਼ੁਰੂ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਹਾਡਾ ਵਾਤਾਵਰਣ ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਸੈੱਟ ਹੈ। ਇਹ ਸਾਰੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਨੂੰ ਇੰਸਟਾਲ ਕਰਨ ਅਤੇ ਤੁਹਾਡੇ API ਕੀਜ਼ ਨੂੰ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਕਨਫਿਗਰ ਕਰਨ ਵਿੱਚ ਮਦਦ ਕਰੇਗਾ।

- Python 3.8 ਜਾਂ ਇਸ ਤੋਂ ਉੱਚਾ
- SerpAPI API Key (ਸਾਈਨ ਅਪ ਕਰੋ [SerpAPI](https://serpapi.com/) ਤੇ - ਮੁਫ਼ਤ ਟੀਅਰ ਉਪਲਬਧ)

## ਇੰਸਟਾਲੇਸ਼ਨ

ਆਪਣਾ ਵਾਤਾਵਰਣ ਸੈੱਟ ਕਰਨ ਲਈ ਹੇਠਾਂ ਦਿੱਤੇ ਕਦਮਾਂ ਦੀ ਪਾਲਣਾ ਕਰੋ:

1. uv (ਸਿਫਾਰਸ਼ੀ) ਜਾਂ pip ਨਾਲ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. ਪ੍ਰੋਜੈਕਟ ਰੂਟ ਵਿੱਚ `.env` ਫਾਈਲ ਬਣਾਓ ਅਤੇ ਆਪਣਾ SerpAPI ਕੀ ਦਰਜ ਕਰੋ:

```
SERPAPI_KEY=your_serpapi_key_here
```

## ਵਰਤੋਂ

ਵੈੱਬ ਸર્ચ MCP ਸਰਵਰ ਉਹ ਮੁੱਖ ਹਿੱਸਾ ਹੈ ਜੋ SerpAPI ਨਾਲ ਇੰਟੀਗਰੇਟ ਕਰਕੇ ਵੈੱਬ, ਖ਼ਬਰਾਂ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ ਸਵਾਲ-ਜਵਾਬ ਲਈ ਟੂਲਜ਼ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ। ਇਹ ਆਉਣ ਵਾਲੀਆਂ ਬੇਨਤੀਆਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ, API ਕਾਲਾਂ ਨੂੰ ਮੈਨੇਜ ਕਰਦਾ ਹੈ, ਜਵਾਬ ਪਾਰਸ ਕਰਦਾ ਹੈ ਅਤੇ ਸੰਰਚਿਤ ਨਤੀਜੇ ਕਲਾਇੰਟ ਨੂੰ ਵਾਪਸ ਕਰਦਾ ਹੈ।

ਤੁਸੀਂ ਪੂਰੀ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਨੂੰ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ਵਿੱਚ ਦੇਖ ਸਕਦੇ ਹੋ।

### ਸਰਵਰ ਚਲਾਉਣਾ

MCP ਸਰਵਰ ਸ਼ੁਰੂ ਕਰਨ ਲਈ, ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਵਰਤੋਂ:

```bash
python server.py
```

ਸਰਵਰ stdio-ਅਧਾਰਿਤ MCP ਸਰਵਰ ਵਜੋਂ ਚੱਲੇਗਾ ਜਿਸ ਨਾਲ ਕਲਾਇੰਟ ਸਿੱਧਾ ਜੁੜ ਸਕਦਾ ਹੈ।

### ਕਲਾਇੰਟ ਮੋਡ

ਕਲਾਇੰਟ (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)।

### ਕਲਾਇੰਟ ਚਲਾਉਣਾ

ਆਟੋਮੈਟਿਕ ਟੈਸਟ ਚਲਾਉਣ ਲਈ (ਇਹ ਸਰਵਰ ਨੂੰ ਆਪਣੇ ਆਪ ਸ਼ੁਰੂ ਕਰੇਗਾ):

```bash
python client.py
```

ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ ਚਲਾਓ:

```bash
python client.py --interactive
```

### ਵੱਖ-ਵੱਖ ਤਰੀਕਿਆਂ ਨਾਲ ਟੈਸਟ ਕਰਨਾ

ਤੁਹਾਡੇ ਲੋੜਾਂ ਅਤੇ ਵਰਕਫਲੋਅ ਦੇ ਅਨੁਸਾਰ ਸਰਵਰ ਵੱਲੋਂ ਦਿੱਤੇ ਗਏ ਟੂਲਜ਼ ਨਾਲ ਟੈਸਟ ਅਤੇ ਇੰਟਰਐਕਟ ਕਰਨ ਦੇ ਕਈ ਤਰੀਕੇ ਹਨ।

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

ਇਸ ਸੰਦਰਭ ਵਿੱਚ, "ਟੈਸਟ ਸਕ੍ਰਿਪਟ" ਦਾ ਮਤਲਬ ਹੈ ਇੱਕ ਕਸਟਮ Python ਪ੍ਰੋਗਰਾਮ ਜੋ ਤੁਸੀਂ MCP ਸਰਵਰ ਲਈ ਕਲਾਇੰਟ ਵਜੋਂ ਲਿਖਦੇ ਹੋ। ਇਹ ਕੋਈ ਰਸਮੀ ਯੂਨਿਟ ਟੈਸਟ ਨਹੀਂ ਹੈ, ਬਲਕਿ ਇਹ ਤੁਹਾਨੂੰ ਸਰਵਰ ਨਾਲ ਪ੍ਰੋਗਰਾਮੈਟਿਕ ਤਰੀਕੇ ਨਾਲ ਜੁੜਨ, ਆਪਣੇ ਚੁਣੇ ਹੋਏ ਪੈਰਾਮੀਟਰਾਂ ਨਾਲ ਕਿਸੇ ਵੀ ਟੂਲ ਨੂੰ ਕਾਲ ਕਰਨ ਅਤੇ ਨਤੀਜਿਆਂ ਦੀ ਜਾਂਚ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਇਹ ਤਰੀਕਾ ਉਪਯੋਗੀ ਹੈ:

- ਟੂਲ ਕਾਲਾਂ ਦੇ ਪ੍ਰੋਟੋਟਾਈਪ ਅਤੇ ਪ੍ਰਯੋਗ ਲਈ
- ਵੱਖ-ਵੱਖ ਇਨਪੁਟਾਂ 'ਤੇ ਸਰਵਰ ਦੀ ਪ੍ਰਤੀਕਿਰਿਆ ਦੀ ਪੁਸ਼ਟੀ ਕਰਨ ਲਈ
- ਟੂਲ ਕਾਲਾਂ ਨੂੰ ਆਟੋਮੈਟਿਕ ਕਰਨ ਲਈ
- MCP ਸਰਵਰ ਉੱਤੇ ਆਪਣੇ ਵਰਕਫਲੋ ਜਾਂ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਬਣਾਉਣ ਲਈ

ਤੁਸੀਂ ਟੈਸਟ ਸਕ੍ਰਿਪਟਾਂ ਦੀ ਵਰਤੋਂ ਨਵੇਂ ਕੁਇਰੀਜ਼ ਤੇਜ਼ੀ ਨਾਲ ਟੈਸਟ ਕਰਨ, ਟੂਲ ਦੇ ਵਰਤਾਵ ਨੂੰ ਡੀਬੱਗ ਕਰਨ ਜਾਂ ਹੋਰ ਅੱਗੇ ਵਧੇ ਆਟੋਮੇਸ਼ਨ ਲਈ ਸ਼ੁਰੂਆਤੀ ਬਿੰਦੂ ਵਜੋਂ ਕਰ ਸਕਦੇ ਹੋ। ਹੇਠਾਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਇੱਕ ਐਸਾ ਸਕ੍ਰਿਪਟ ਬਣਾਉਣ ਦਾ ਉਦਾਹਰਣ ਦਿੱਤਾ ਗਿਆ ਹੈ:

## ਟੂਲ ਵੇਰਵੇ

ਤੁਸੀਂ ਸਰਵਰ ਵੱਲੋਂ ਦਿੱਤੇ ਗਏ ਹੇਠਾਂ ਦਿੱਤੇ ਟੂਲਜ਼ ਦੀ ਵਰਤੋਂ ਵੱਖ-ਵੱਖ ਕਿਸਮ ਦੀਆਂ ਖੋਜਾਂ ਅਤੇ ਕੁਇਰੀਜ਼ ਕਰਨ ਲਈ ਕਰ ਸਕਦੇ ਹੋ। ਹਰ ਟੂਲ ਦੇ ਪੈਰਾਮੀਟਰ ਅਤੇ ਉਦਾਹਰਣ ਵਰਤੋਂ ਹੇਠਾਂ ਦਿੱਤੇ ਗਏ ਹਨ।

ਇਸ ਹਿੱਸੇ ਵਿੱਚ ਹਰ ਉਪਲਬਧ ਟੂਲ ਅਤੇ ਉਹਨਾਂ ਦੇ ਪੈਰਾਮੀਟਰਾਂ ਦੀ ਜਾਣਕਾਰੀ ਦਿੱਤੀ ਗਈ ਹੈ।

### general_search

ਇਹ ਟੂਲ ਇੱਕ ਆਮ ਵੈੱਬ ਖੋਜ ਕਰਦਾ ਹੈ ਅਤੇ ਫਾਰਮੈਟ ਕੀਤੇ ਨਤੀਜੇ ਵਾਪਸ ਕਰਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ `general_search` ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਵਰਤ ਕੇ। ਹੇਠਾਂ SDK ਦੀ ਵਰਤੋਂ ਨਾਲ ਕੋਡ ਉਦਾਹਰਣ ਹੈ:

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): ਖੋਜ ਕੁਇਰੀ ਚੁਣੋ

**ਉਦਾਹਰਣ ਬੇਨਤੀ:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

ਇਹ ਖੋਜ ਤਾਜ਼ਾ ਖ਼ਬਰਾਂ ਨਾਲ ਸੰਬੰਧਿਤ ਲੇਖ ਲੱਭਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ `news_search` ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਵਰਤ ਕੇ। ਹੇਠਾਂ SDK ਦੀ ਵਰਤੋਂ ਨਾਲ ਕੋਡ ਉਦਾਹਰਣ ਹੈ:

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): ਖੋਜ ਕੁਇਰੀ ਚੁਣੋ

**ਉਦਾਹਰਣ ਬੇਨਤੀ:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

ਇਹ ਕੁਇਰੀ ਨਾਲ ਮੇਲ ਖਾਂਦੇ ਉਤਪਾਦ ਲੱਭਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ `product_search` ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਵਰਤ ਕੇ। ਹੇਠਾਂ SDK ਦੀ ਵਰਤੋਂ ਨਾਲ ਕੋਡ ਉਦਾਹਰਣ ਹੈ:

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): ਉਤਪਾਦ ਖੋਜ ਕੁਇਰੀ ਚੁਣੋ

**ਉਦਾਹਰਣ ਬੇਨਤੀ:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

ਸਰਚ ਇੰਜਣਾਂ ਤੋਂ ਸਵਾਲਾਂ ਦੇ ਸਿੱਧੇ ਜਵਾਬ ਲੈਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ `qna` ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਵਰਤ ਕੇ। ਹੇਠਾਂ SDK ਦੀ ਵਰਤੋਂ ਨਾਲ ਕੋਡ ਉਦਾਹਰਣ ਹੈ:

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): ਜਵਾਬ ਲਈ ਸਵਾਲ ਚੁਣੋ

**ਉਦਾਹਰਣ ਬੇਨਤੀ:**

```json
{
  "question": "what is artificial intelligence"
}
```

## ਕੋਡ ਵੇਰਵੇ

ਇਸ ਹਿੱਸੇ ਵਿੱਚ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਕੋਡ ਟੁਕੜੇ ਅਤੇ ਰੈਫਰੈਂਸ ਦਿੱਤੇ ਗਏ ਹਨ।

<details>
<summary>Python</summary>

ਪੂਰੀ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਵੇਰਵੇ ਲਈ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) ਵੇਖੋ।

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## ਇਸ ਪਾਠ ਵਿੱਚ ਅਗਲੇ ਪੱਧਰ ਦੇ ਸੰਕਲਪ

ਬਣਾਉਣ ਤੋਂ ਪਹਿਲਾਂ, ਇੱਥੇ ਕੁਝ ਮਹੱਤਵਪੂਰਨ ਅਗਲੇ ਪੱਧਰ ਦੇ ਸੰਕਲਪ ਹਨ ਜੋ ਇਸ ਅਧਿਆਇ ਵਿੱਚ ਵੱਖ-ਵੱਖ ਜਗ੍ਹਾਂ ਆਉਣਗੇ। ਇਹ ਸਮਝਣਾ ਤੁਹਾਨੂੰ ਸਹਾਇਤਾ ਕਰੇਗਾ, ਭਾਵੇਂ ਤੁਸੀਂ ਨਵੇਂ ਹੋ:

- **ਕਈ ਟੂਲਜ਼ ਦਾ ਸਹਿਯੋਗ**: ਇਸਦਾ ਮਤਲਬ ਹੈ ਕਿ ਇੱਕ MCP ਸਰਵਰ ਵਿੱਚ ਵੱਖ-ਵੱਖ ਟੂਲਜ਼ (ਜਿਵੇਂ ਵੈੱਬ ਸર્ચ, ਖ਼ਬਰਾਂ ਦੀ ਖੋਜ, ਉਤਪਾਦ ਖੋਜ, ਅਤੇ ਸਵਾਲ-ਜਵਾਬ) ਚਲਾਏ ਜਾਂਦੇ ਹਨ। ਇਸ ਨਾਲ ਤੁਹਾਡਾ ਸਰਵਰ ਕਈ ਕਿਸਮ ਦੇ ਕੰਮ ਕਰ ਸਕਦਾ ਹੈ, ਸਿਰਫ ਇੱਕ ਨਹੀਂ।
- **API ਰੇਟ ਲਿਮਿਟ ਸੰਭਾਲਣਾ**: ਬਹੁਤ ਸਾਰੇ ਬਾਹਰੀ APIs (ਜਿਵੇਂ SerpAPI) ਇਹ ਸੀਮਤ ਕਰਦੇ ਹਨ ਕਿ ਤੁਸੀਂ ਇੱਕ ਨਿਰਧਾਰਿਤ ਸਮੇਂ ਵਿੱਚ ਕਿੰਨੀ ਬੇਨਤੀਆਂ ਕਰ ਸਕਦੇ ਹੋ। ਵਧੀਆ ਕੋਡ ਇਹ ਲਿਮਿਟਾਂ ਚੈੱਕ ਕਰਦਾ ਹੈ ਅਤੇ ਜਦੋਂ ਲਿਮਿਟ ਪੂਰੀ ਹੋ ਜਾਵੇ ਤਾਂ ਸਹਿਯੋਗੀ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲਦਾ ਹੈ, ਤਾਂ ਜੋ ਤੁਹਾਡੀ ਐਪ ਟੁੱਟੇ ਨਾ।
- **ਸੰਰਚਿਤ ਡਾਟਾ ਪਾਰਸਿੰਗ**: API ਜਵਾਬ ਆਮ ਤੌਰ 'ਤੇ ਜਟਿਲ ਅਤੇ ਘੁੰਮਾਫਿਰੇ ਹੋ ਸਕਦੇ ਹਨ। ਇਹ ਸੰਕਲਪ ਉਹਨਾਂ ਜਵਾਬਾਂ ਨੂੰ ਸਾਫ਼, ਵਰਤਣ ਯੋਗ ਫਾਰਮੈਟ ਵਿੱਚ ਬਦਲਣ ਬਾਰੇ ਹੈ ਜੋ LLMs ਜਾਂ ਹੋਰ ਪ੍ਰੋਗਰਾਮਾਂ ਲਈ ਅਨੁਕੂਲ ਹੋਵੇ।
- **ਗਲਤੀ ਮੁਕਾਬਲਾ**: ਕਈ ਵਾਰ ਕੁਝ ਗਲਤ ਹੋ ਜਾਂਦਾ ਹੈ—ਜਿਵੇਂ ਨੈੱਟਵਰਕ ਫੇਲ ਹੋਣਾ ਜਾਂ API ਉਮੀਦ ਮੁਤਾਬਕ ਜਵਾਬ ਨਾ ਦੇਣਾ। ਗਲਤੀ ਮੁਕਾਬਲਾ ਮਤਲਬ ਹੈ ਕਿ ਤੁਹਾਡਾ ਕੋਡ ਇਨ੍ਹਾਂ ਸਮੱਸਿਆਵਾਂ ਨੂੰ ਸੰਭਾਲ ਸਕਦਾ ਹੈ ਅਤੇ ਫਿਰ ਵੀ ਲਾਭਦਾਇਕ ਫੀਡਬ

**ਅਸਵੀਕਾਰੋਪਣੀ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਜਾਣੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰੱਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੇ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।