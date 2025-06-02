<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:11:05+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "pa"
}
-->
# Lesson: Building a Web Search MCP Server

ਇਸ ਅਧਿਆਇ ਵਿੱਚ ਦਿਖਾਇਆ ਗਿਆ ਹੈ ਕਿ ਕਿਵੇਂ ਇੱਕ ਅਸਲੀ ਦੁਨੀਆ ਦਾ AI ਏਜੰਟ ਬਣਾਇਆ ਜਾਵੇ ਜੋ ਬਾਹਰੀ APIs ਨਾਲ ਇੰਟਿਗ੍ਰੇਟ ਕਰਦਾ ਹੈ, ਵੱਖ-ਵੱਖ ਡਾਟਾ ਕਿਸਮਾਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ, ਗਲਤੀਆਂ ਦਾ ਪ੍ਰਬੰਧ ਕਰਦਾ ਹੈ, ਅਤੇ ਕਈ ਟੂਲਜ਼ ਨੂੰ ਇਕੱਠੇ ਚਲਾਉਂਦਾ ਹੈ—ਸਭ ਕੁਝ ਪ੍ਰੋਡਕਸ਼ਨ-ਤਿਆਰ ਫਾਰਮੈਟ ਵਿੱਚ। ਤੁਸੀਂ ਵੇਖੋਗੇ:

- **ਆਥੈਂਟੀਕੇਸ਼ਨ ਦੀ ਲੋੜ ਵਾਲੇ ਬਾਹਰੀ APIs ਨਾਲ ਇੰਟਿਗ੍ਰੇਸ਼ਨ**
- **ਕਈ ਐਂਡਪੌਇੰਟ ਤੋਂ ਵੱਖ-ਵੱਖ ਡਾਟਾ ਕਿਸਮਾਂ ਨੂੰ ਸੰਭਾਲਣਾ**
- **ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲਣ ਅਤੇ ਲੌਗਿੰਗ ਤਰੀਕੇ**
- **ਇੱਕ ਸਰਵਰ ਵਿੱਚ ਕਈ ਟੂਲਜ਼ ਦਾ ਸੰਗਠਨ**

ਅਖੀਰ ਵਿੱਚ, ਤੁਹਾਨੂੰ ਉਹ ਅਮਲੀ ਤਜਰਬਾ ਮਿਲੇਗਾ ਜੋ ਉੱਚ-ਪੱਧਰੀ AI ਅਤੇ LLM-ਚਲਿਤ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਜਰੂਰੀ ਪੈਟਰਨ ਅਤੇ ਸਰਵੋਤਮ ਅਭਿਆਸਾਂ ਨਾਲ ਭਰਪੂਰ ਹੈ।

## ਪਰਿਚਯ

ਇਸ ਪਾਠ ਵਿੱਚ, ਤੁਸੀਂ ਸਿੱਖੋਗੇ ਕਿ ਕਿਵੇਂ ਇੱਕ ਅਡਵਾਂਸ MCP ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਬਣਾਇਆ ਜਾਵੇ ਜੋ SerpAPI ਦੀ ਵਰਤੋਂ ਕਰਕੇ LLM ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਵੈੱਬ ਡਾਟਾ ਨਾਲ ਵਧਾਉਂਦਾ ਹੈ। ਇਹ ਉਹ ਮਹੱਤਵਪੂਰਨ ਹੁਨਰ ਹੈ ਜੋ ਡਾਇਨਾਮਿਕ AI ਏਜੰਟ ਬਣਾਉਣ ਲਈ ਲਾਜ਼ਮੀ ਹੈ ਜੋ ਵੈੱਬ ਤੋਂ ਤਾਜ਼ਾ ਜਾਣਕਾਰੀ ਪ੍ਰਾਪਤ ਕਰ ਸਕਦੇ ਹਨ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- MCP ਸਰਵਰ ਵਿੱਚ ਬਾਹਰੀ APIs (ਜਿਵੇਂ SerpAPI) ਨੂੰ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਜੋੜਨਾ
- ਵੈੱਬ, ਖ਼ਬਰਾਂ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ Q&A ਲਈ ਕਈ ਟੂਲਜ਼ ਲਾਗੂ ਕਰਨਾ
- LLM ਲਈ ਸੰਰਚਿਤ ਡਾਟਾ ਨੂੰ ਪਾਰਸ ਅਤੇ ਫਾਰਮੈਟ ਕਰਨਾ
- ਗਲਤੀਆਂ ਨੂੰ ਸੰਭਾਲਣਾ ਅਤੇ API ਰੇਟ ਸੀਮਾਵਾਂ ਦਾ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਪ੍ਰਬੰਧ ਕਰਨਾ
- ਦੋਹਾਂ ਆਟੋਮੈਟਿਕ ਅਤੇ ਇੰਟਰਐਕਟਿਵ MCP ਕਲਾਇੰਟਾਂ ਨੂੰ ਬਣਾਉਣਾ ਅਤੇ ਟੈਸਟ ਕਰਨਾ

## Web Search MCP Server

ਇਹ ਹਿੱਸਾ ਵੈੱਬ ਸਰਚ MCP ਸਰਵਰ ਦੀ ਆਰਕੀਟੈਕਚਰ ਅਤੇ ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਨੂੰ ਜਾਣੂ ਕਰਵਾਉਂਦਾ ਹੈ। ਤੁਸੀਂ ਵੇਖੋਗੇ ਕਿ FastMCP ਅਤੇ SerpAPI ਕਿਵੇਂ ਮਿਲ ਕੇ LLM ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਵੈੱਬ ਡਾਟਾ ਨਾਲ ਵਧਾਉਂਦੇ ਹਨ।

### ਓਵਰਵਿਊ

ਇਸ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਵਿੱਚ ਚਾਰ ਟੂਲ ਹਨ ਜੋ MCP ਦੀ ਯੋਗਤਾ ਨੂੰ ਦਰਸਾਉਂਦੇ ਹਨ ਕਿ ਕਿਵੇਂ ਇਹ ਵੱਖ-ਵੱਖ ਬਾਹਰੀ API-ਚਲਿਤ ਕੰਮਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਅਤੇ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲ ਸਕਦਾ ਹੈ:

- **general_search**: ਵਿਆਪਕ ਵੈੱਬ ਨਤੀਜੇ ਲਈ
- **news_search**: ਤਾਜ਼ਾ ਸਿਰਲੇਖਾਂ ਲਈ
- **product_search**: ਈ-ਕਾਮਰਸ ਡਾਟਾ ਲਈ
- **qna**: ਸਵਾਲ-ਜਵਾਬ ਟੁਕੜੇ ਲਈ

### ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ
- **ਕੋਡ ਉਦਾਹਰਨਾਂ**: Python ਲਈ ਭਾਸ਼ਾ-ਖਾਸ ਕੋਡ ਬਲਾਕਾਂ ਸਮੇਤ (ਅਤੇ ਆਸਾਨੀ ਨਾਲ ਹੋਰ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਵਧਾਏ ਜਾ ਸਕਦੇ ਹਨ) ਜੋ ਸਪਸ਼ਟਤਾ ਲਈ ਢਿੱਲੇ-ਢਾਲੇ ਸੈਕਸ਼ਨਾਂ ਵਿੱਚ ਹਨ

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

ਕਲਾਇੰਟ ਚਲਾਉਣ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਸਮਝਣਾ ਫਾਇਦਿਆਂ ਵਾਲਾ ਹੈ ਕਿ ਸਰਵਰ ਕੀ ਕਰਦਾ ਹੈ। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)।

ਇੱਥੇ ਇੱਕ ਛੋਟਾ ਉਦਾਹਰਨ ਹੈ ਕਿ ਸਰਵਰ ਕਿਸ ਤਰ੍ਹਾਂ ਇੱਕ ਟੂਲ ਨੂੰ ਪਰਿਭਾਸ਼ਿਤ ਅਤੇ ਰਜਿਸਟਰ ਕਰਦਾ ਹੈ:

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

- **ਬਾਹਰੀ API ਇੰਟਿਗ੍ਰੇਸ਼ਨ**: API ਕੁੰਜੀਆਂ ਅਤੇ ਬਾਹਰੀ ਬੇਨਤੀਆਂ ਦੀ ਸੁਰੱਖਿਅਤ ਸੰਭਾਲ ਦਿਖਾਉਂਦਾ ਹੈ
- **ਸੰਰਚਿਤ ਡਾਟਾ ਪਾਰਸਿੰਗ**: API ਜਵਾਬਾਂ ਨੂੰ LLM-ਮਿੱਤਰ ਫਾਰਮੈਟਾਂ ਵਿੱਚ ਬਦਲਣ ਦਾ ਤਰੀਕਾ ਦਿਖਾਉਂਦਾ ਹੈ
- **ਗਲਤੀ ਸੰਭਾਲਣਾ**: ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲਣ ਅਤੇ ਉਚਿਤ ਲੌਗਿੰਗ
- **ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ**: ਆਟੋਮੈਟਿਕ ਟੈਸਟਾਂ ਅਤੇ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਦੋਹਾਂ ਸ਼ਾਮਲ
- **ਸੰਦਰਭ ਪ੍ਰਬੰਧਨ**: MCP Context ਦੀ ਵਰਤੋਂ ਲੌਗਿੰਗ ਅਤੇ ਬੇਨਤੀਆਂ ਦੀ ਟ੍ਰੈਕਿੰਗ ਲਈ

## ਪਹਿਲਾਂ ਦੀਆਂ ਜ਼ਰੂਰਤਾਂ

ਸ਼ੁਰੂ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਹਾਡਾ ਵਾਤਾਵਰਣ ਠੀਕ ਤਰ੍ਹਾਂ ਸੈੱਟ ਹੈ। ਇਹ ਸੁਨਿਸ਼ਚਿਤ ਕਰੇਗਾ ਕਿ ਸਾਰੇ ਡਿਪੈਂਡੇੰਸੀਜ਼ ਇੰਸਟਾਲ ਹਨ ਅਤੇ ਤੁਹਾਡੇ API ਕੁੰਜੀਆਂ ਸਹੀ ਤਰ੍ਹਾਂ ਸੰਰਚਿਤ ਹਨ ਤਾਂ ਜੋ ਵਿਕਾਸ ਅਤੇ ਟੈਸਟਿੰਗ ਵਿੱਚ ਕੋਈ ਰੁਕਾਵਟ ਨਾ ਆਵੇ।

- Python 3.8 ਜਾਂ ਉਸ ਤੋਂ ਉੱਪਰ
- SerpAPI API Key (ਸਾਈਨ ਅਪ ਕਰੋ [SerpAPI](https://serpapi.com/) ਤੇ - ਮੁਫ਼ਤ ਟੀਅਰ ਉਪਲਬਧ)

## ਇੰਸਟਾਲੇਸ਼ਨ

ਸ਼ੁਰੂ ਕਰਨ ਲਈ, ਆਪਣਾ ਵਾਤਾਵਰਣ ਸੈੱਟ ਕਰਨ ਲਈ ਹੇਠਾਂ ਦਿੱਤੇ ਕਦਮਾਂ ਦੀ ਪਾਲਣਾ ਕਰੋ:

1. uv (ਸਿਫਾਰਸ਼ੀ) ਜਾਂ pip ਦੀ ਵਰਤੋਂ ਨਾਲ ਡਿਪੈਂਡੇੰਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. ਪ੍ਰੋਜੈਕਟ ਰੂਟ ਵਿੱਚ `.env` ਫਾਇਲ ਬਣਾਓ ਅਤੇ ਆਪਣਾ SerpAPI ਕੁੰਜੀ ਸ਼ਾਮਲ ਕਰੋ:

```
SERPAPI_KEY=your_serpapi_key_here
```

## ਵਰਤੋਂ

Web Search MCP Server ਮੁੱਖ ਹਿੱਸਾ ਹੈ ਜੋ ਵੈੱਬ, ਖ਼ਬਰਾਂ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ Q&A ਲਈ ਟੂਲਜ਼ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ SerpAPI ਨਾਲ ਇੰਟਿਗ੍ਰੇਟ ਕਰਕੇ। ਇਹ ਆਉਣ ਵਾਲੀਆਂ ਬੇਨਤੀਆਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ, API ਕਾਲਾਂ ਦਾ ਪ੍ਰਬੰਧ ਕਰਦਾ ਹੈ, ਜਵਾਬ ਪਾਰਸ ਕਰਦਾ ਹੈ, ਅਤੇ ਗਾਹਕ ਨੂੰ ਸੰਰਚਿਤ ਨਤੀਜੇ ਵਾਪਸ ਭੇਜਦਾ ਹੈ।

ਤੁਸੀਂ ਪੂਰੀ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ਵਿੱਚ ਵੇਖ ਸਕਦੇ ਹੋ।

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

ਆਟੋਮੈਟਿਕ ਟੈਸਟ ਚਲਾਉਣ ਲਈ (ਇਹ ਆਪਣੇ ਆਪ ਸਰਵਰ ਵੀ ਸ਼ੁਰੂ ਕਰੇਗਾ):

```bash
python client.py
```

ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ ਚਲਾਓ:

```bash
python client.py --interactive
```

### ਵੱਖ-ਵੱਖ ਤਰੀਕਿਆਂ ਨਾਲ ਟੈਸਟਿੰਗ

ਸਰਵਰ ਵੱਲੋਂ ਪ੍ਰਦਾਨ ਕੀਤੇ ਟੂਲਜ਼ ਨਾਲ ਟੈਸਟ ਕਰਨ ਅਤੇ ਇੰਟਰਐਕਟ ਕਰਨ ਦੇ ਕਈ ਤਰੀਕੇ ਹਨ, ਜੋ ਤੁਹਾਡੇ ਲੋੜਾਂ ਅਤੇ ਵਰਕਫਲੋਅ 'ਤੇ ਨਿਰਭਰ ਕਰਦੇ ਹਨ।

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

ਇਸ ਸੰਦਰਭ ਵਿੱਚ, "ਟੈਸਟ ਸਕ੍ਰਿਪਟ" ਦਾ ਮਤਲਬ ਹੈ ਇੱਕ ਕਸਟਮ Python ਪ੍ਰੋਗਰਾਮ ਜੋ ਤੁਸੀਂ MCP ਸਰਵਰ ਲਈ ਕਲਾਇੰਟ ਵਜੋਂ ਲਿਖਦੇ ਹੋ। ਇਹ ਕੋਈ ਅਧਿਕਾਰਿਕ ਯੂਨਿਟ ਟੈਸਟ ਨਹੀਂ ਹੁੰਦਾ, ਪਰ ਇਹ ਤੁਹਾਨੂੰ ਸਰਵਰ ਨਾਲ ਪ੍ਰੋਗਰਾਮੈਟਿਕ ਤੌਰ 'ਤੇ ਜੁੜਨ, ਆਪਣੇ ਚੁਣੇ ਹੋਏ ਪੈਰਾਮੀਟਰਾਂ ਨਾਲ ਕਿਸੇ ਵੀ ਟੂਲ ਨੂੰ ਕਾਲ ਕਰਨ ਅਤੇ ਨਤੀਜਿਆਂ ਦੀ ਜਾਂਚ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਇਹ ਤਰੀਕਾ ਲਾਭਦਾਇਕ ਹੈ:

- ਟੂਲ ਕਾਲਾਂ ਦੀ ਪ੍ਰੋਟੋਟਾਈਪਿੰਗ ਅਤੇ ਪਰਖ ਕਰਨ ਲਈ
- ਵੱਖ-ਵੱਖ ਇਨਪੁੱਟਾਂ 'ਤੇ ਸਰਵਰ ਦੇ ਜਵਾਬ ਦੀ ਪੁਸ਼ਟੀ ਕਰਨ ਲਈ
- ਦੁਹਰਾਈ ਜਾਣ ਵਾਲੀਆਂ ਟੂਲ ਕਾਲਾਂ ਨੂੰ ਆਟੋਮੇਟ ਕਰਨ ਲਈ
- MCP ਸਰਵਰ ਦੇ ਉੱਪਰ ਆਪਣੇ ਵਰਕਫਲੋਅ ਜਾਂ ਇੰਟਿਗ੍ਰੇਸ਼ਨਾਂ ਨੂੰ ਬਣਾਉਣ ਲਈ

ਤੁਸੀਂ ਟੈਸਟ ਸਕ੍ਰਿਪਟਾਂ ਦੀ ਵਰਤੋਂ ਨਵੇਂ ਕਵੈਰੀਜ਼ ਨੂੰ ਤੇਜ਼ੀ ਨਾਲ ਅਜ਼ਮਾਉਣ, ਟੂਲ ਵਿਹਾਰ ਨੂੰ ਡਿਬੱਗ ਕਰਨ ਜਾਂ ਹੋਰ ਉੱਚ ਪੱਧਰੀ ਆਟੋਮੇਸ਼ਨ ਲਈ ਸ਼ੁਰੂਆਤੀ ਬਿੰਦੂ ਵਜੋਂ ਕਰ ਸਕਦੇ ਹੋ। ਹੇਠਾਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਨਾਲ ਇੱਕ ਸਕ੍ਰਿਪਟ ਬਣਾਉਣ ਦਾ ਉਦਾਹਰਨ ਦਿੱਤਾ ਗਿਆ ਹੈ:

## ਟੂਲ ਵਰਣਨ

ਤੁਸੀਂ ਸਰਵਰ ਵੱਲੋਂ ਪ੍ਰਦਾਨ ਕੀਤੇ ਹੇਠਾਂ ਦਿੱਤੇ ਟੂਲਜ਼ ਦੀ ਵਰਤੋਂ ਵੱਖ-ਵੱਖ ਕਿਸਮ ਦੀਆਂ ਖੋਜਾਂ ਅਤੇ ਪੁੱਛਗਿੱਛਾਂ ਕਰਨ ਲਈ ਕਰ ਸਕਦੇ ਹੋ। ਹਰ ਟੂਲ ਦੇ ਪੈਰਾਮੀਟਰ ਅਤੇ ਉਦਾਹਰਨ ਵਰਤੋਂ ਹੇਠਾਂ ਦਿੱਤੇ ਗਏ ਹਨ।

ਇਹ ਹਿੱਸਾ ਹਰ ਉਪਲਬਧ ਟੂਲ ਅਤੇ ਉਨ੍ਹਾਂ ਦੇ ਪੈਰਾਮੀਟਰਾਂ ਦੀ ਜਾਣਕਾਰੀ ਦਿੰਦਾ ਹੈ।

### general_search

ਇੱਕ ਆਮ ਵੈੱਬ ਖੋਜ ਕਰਦਾ ਹੈ ਅਤੇ ਫਾਰਮੈਟ ਕੀਤੇ ਨਤੀਜੇ ਵਾਪਸ ਕਰਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ `general_search` ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਵਿੱਚ। ਹੇਠਾਂ SDK ਵਰਤੋਂ ਦਾ ਕੋਡ ਉਦਾਹਰਨ ਹੈ:

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

ਕਿਸੇ ਪੁੱਛਗਿੱਛ ਨਾਲ ਸਬੰਧਤ ਤਾਜ਼ਾ ਖ਼ਬਰਾਂ ਲੱਭਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ `news_search` ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਵਿੱਚ। ਹੇਠਾਂ SDK ਵਰਤੋਂ ਦਾ ਕੋਡ ਉਦਾਹਰਨ ਹੈ:

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

ਕਿਸੇ ਪੁੱਛਗਿੱਛ ਨਾਲ ਮੇਲ ਖਾਂਦੇ ਉਤਪਾਦ ਲੱਭਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ `product_search` ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਵਿੱਚ। ਹੇਠਾਂ SDK ਵਰਤੋਂ ਦਾ ਕੋਡ ਉਦਾਹਰਨ ਹੈ:

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

ਖੋਜ ਇੰਜਣਾਂ ਤੋਂ ਸਵਾਲਾਂ ਦੇ ਸਿੱਧੇ ਜਵਾਬ ਲੈਂਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ `qna` ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਵਿੱਚ। ਹੇਠਾਂ SDK ਵਰਤੋਂ ਦਾ ਕੋਡ ਉਦਾਹਰਨ ਹੈ:

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

ਇਹ ਹਿੱਸਾ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਲਈ ਕੋਡ ਸਨਿੱਪੇਟ ਅਤੇ ਸੰਦਰਭ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ।

<details>
<summary>Python</summary>

ਪੂਰੀ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਵੇਖਣ ਲਈ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) ਨੂੰ ਵੇਖੋ।

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## ਇਸ ਪਾਠ ਵਿੱਚ ਅਡਵਾਂਸ ਧਾਰਣਾਵਾਂ

ਬਣਾਉਣ ਸ਼ੁਰੂ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ, ਇੱਥੇ ਕੁਝ ਅਹੰਕਾਰਪੂਰਕ ਅਡਵਾਂਸ ਧਾਰਣਾਵਾਂ ਹਨ ਜੋ ਇਸ ਅਧਿਆਇ ਵਿੱਚ ਵਿਆਪਕ ਤੌਰ 'ਤੇ ਆਉਣਗੀਆਂ। ਇਹ ਸਮਝਣਾ ਤੁਹਾਨੂੰ ਅੱਗੇ ਨਾਲ ਚੱਲਣ ਵਿੱਚ ਮਦਦ ਕਰੇਗਾ, ਭਾਵੇਂ ਤੁਸੀਂ ਨਵੇਂ ਹੋ:

- **ਮਲਟੀ-ਟੂਲ ਸੰਗਠਨ**: ਇਸਦਾ ਮਤਲਬ ਹੈ ਕਿ ਕਈ ਵੱਖ-ਵੱਖ ਟੂਲਜ਼ (ਜਿਵੇਂ ਵੈੱਬ ਖੋਜ, ਖ਼ਬਰਾਂ ਖੋਜ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ Q&A) ਨੂੰ ਇੱਕ ਹੀ MCP ਸਰਵਰ ਵਿੱਚ ਚਲਾਇਆ ਜਾਵੇ। ਇਹ ਤੁਹਾਡੇ ਸਰਵਰ ਨੂੰ ਕਈ ਕਿਸਮਾਂ ਦੇ ਕੰਮ ਕਰਨ ਯੋਗ ਬਣਾਉਂਦਾ ਹੈ, ਸਿਰਫ ਇੱਕ ਹੀ ਨਹੀਂ।
- **API ਰੇਟ ਲਿਮਿਟ ਸੰਭਾਲਣਾ**: ਬਹੁਤ ਸਾਰੇ ਬਾਹਰੀ APIs (ਜਿਵੇਂ SerpAPI) ਇਹ ਸੀਮਿਤ ਕਰਦੇ ਹਨ ਕਿ ਤੁਸੀਂ ਇੱਕ ਨਿਰਧਾਰਤ ਸਮੇਂ ਵਿੱਚ ਕਿੰਨੀ ਬੇਨਤੀਆਂ ਕਰ ਸਕਦੇ ਹੋ। ਵਧੀਆ ਕੋਡ ਇਹ ਸੀਮਾਵਾਂ ਚੈੱਕ ਕਰਦਾ ਹੈ ਅਤੇ ਉਨ੍ਹਾਂ ਨੂੰ ਸਮਝਦਾਰੀ ਨਾਲ ਸੰਭਾਲਦਾ ਹੈ, ਤਾਂ ਜੋ ਤੁਹਾਡੀ ਐਪ ਟੁੱਟੇ ਨਾ ਜੇਕਰ ਤੁਸੀਂ ਸੀਮਾ ਤੱਕ ਪਹੁੰਚ ਜਾਓ।
- **ਸੰਰਚਿਤ ਡਾਟਾ ਪਾਰਸਿੰਗ**: API ਜਵਾਬ ਅਕਸਰ ਜਟਿਲ ਅਤੇ ਘੁੰਮਾਫਿਰ ਵਾਲੇ ਹੁੰਦੇ ਹਨ। ਇਹ ਧਾਰਣਾ ਉਹਨਾਂ ਜਵਾਬਾਂ ਨੂੰ ਸਾਫ਼, ਆਸਾਨ-ਵਰਤੋਂ ਵਾਲੇ ਫਾਰਮੈਟਾਂ ਵਿੱਚ ਬਦਲਣ ਬਾਰੇ ਹੈ ਜੋ LLM ਜਾਂ ਹੋਰ ਪ੍ਰੋਗਰਾਮਾਂ ਲਈ ਮਿੱਤਰ ਹਨ।
- **ਗਲਤੀ ਸਹੀ ਕਰਨ ਦੀ ਯੋਜਨਾ**: ਕਈ ਵਾਰੀ ਕੁਝ ਗਲਤ ਹੋ ਜਾਂਦਾ ਹੈ—ਜਿਵੇਂ ਨੈੱਟਵਰਕ ਫੇਲ ਹੋਣਾ ਜਾਂ API ਉਹ ਨਹੀਂ ਦਿੰਦਾ ਜੋ ਤੁਸੀਂ ਉਮੀਦ ਕਰਦੇ ਹੋ। ਗਲਤੀ ਸਹੀ ਕਰਨ ਦਾ ਮਤ

**ਅਸਵੀਕਾਰੋक्ति**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਇਸ ਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫ਼ਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਨਾਲ ਪੈਦ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।