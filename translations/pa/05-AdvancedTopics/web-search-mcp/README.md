<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-07-14T03:33:08+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "pa"
}
-->
# ਪਾਠ: ਵੈੱਬ ਖੋਜ MCP ਸਰਵਰ ਬਣਾਉਣਾ

ਇਸ ਅਧਿਆਇ ਵਿੱਚ ਦਿਖਾਇਆ ਗਿਆ ਹੈ ਕਿ ਕਿਵੇਂ ਇੱਕ ਅਸਲੀ ਦੁਨੀਆ ਦਾ AI ਏਜੰਟ ਬਣਾਇਆ ਜਾਵੇ ਜੋ ਬਾਹਰੀ APIs ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰਦਾ ਹੈ, ਵੱਖ-ਵੱਖ ਡਾਟਾ ਕਿਸਮਾਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ, ਗਲਤੀਆਂ ਨੂੰ ਮੈਨੇਜ ਕਰਦਾ ਹੈ ਅਤੇ ਕਈ ਟੂਲਾਂ ਨੂੰ ਇੱਕਠੇ ਚਲਾਉਂਦਾ ਹੈ—ਸਭ ਕੁਝ ਪ੍ਰੋਡਕਸ਼ਨ-ਤਿਆਰ ਫਾਰਮੈਟ ਵਿੱਚ। ਤੁਸੀਂ ਵੇਖੋਗੇ:

- **ਪ੍ਰਮਾਣਿਕਤਾ ਦੀ ਲੋੜ ਵਾਲੇ ਬਾਹਰੀ APIs ਨਾਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ**
- **ਕਈ ਐਂਡਪੌਇੰਟਾਂ ਤੋਂ ਵੱਖ-ਵੱਖ ਡਾਟਾ ਕਿਸਮਾਂ ਨੂੰ ਸੰਭਾਲਣਾ**
- **ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲਣ ਅਤੇ ਲੌਗਿੰਗ ਰਣਨੀਤੀਆਂ**
- **ਇੱਕ ਹੀ ਸਰਵਰ ਵਿੱਚ ਕਈ ਟੂਲਾਂ ਦੀ ਸਹਿਯੋਗੀ ਕਾਰਗੁਜ਼ਾਰੀ**

ਅੰਤ ਤੱਕ, ਤੁਹਾਡੇ ਕੋਲ ਉਹ ਅਮਲੀ ਤਜਰਬਾ ਹੋਵੇਗਾ ਜੋ ਉੱਚ-ਪੱਧਰੀ AI ਅਤੇ LLM-ਚਲਿਤ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਜਰੂਰੀ ਪੈਟਰਨ ਅਤੇ ਸਰਵੋਤਮ ਅਭਿਆਸਾਂ ਨਾਲ ਭਰਪੂਰ ਹੋਵੇਗਾ।

## ਪਰਿਚਯ

ਇਸ ਪਾਠ ਵਿੱਚ, ਤੁਸੀਂ ਸਿੱਖੋਗੇ ਕਿ ਕਿਵੇਂ ਇੱਕ ਅਡਵਾਂਸ MCP ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਬਣਾਇਆ ਜਾਵੇ ਜੋ SerpAPI ਦੀ ਵਰਤੋਂ ਕਰਕੇ LLM ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਵੈੱਬ ਡਾਟਾ ਨਾਲ ਵਧਾਉਂਦਾ ਹੈ। ਇਹ ਇੱਕ ਮਹੱਤਵਪੂਰਨ ਹੁਨਰ ਹੈ ਜੋ ਡਾਇਨਾਮਿਕ AI ਏਜੰਟਾਂ ਨੂੰ ਵਿਕਸਿਤ ਕਰਨ ਲਈ ਜਰੂਰੀ ਹੈ ਜੋ ਵੈੱਬ ਤੋਂ ਤਾਜ਼ਾ ਜਾਣਕਾਰੀ ਪ੍ਰਾਪਤ ਕਰ ਸਕਦੇ ਹਨ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੇ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- ਬਾਹਰੀ APIs (ਜਿਵੇਂ SerpAPI) ਨੂੰ MCP ਸਰਵਰ ਵਿੱਚ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਜੋੜਨਾ
- ਵੈੱਬ, ਖ਼ਬਰਾਂ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ ਪ੍ਰਸ਼ਨ-ਉੱਤਰ ਲਈ ਕਈ ਟੂਲਾਂ ਲਾਗੂ ਕਰਨਾ
- LLM ਲਈ ਸੰਰਚਿਤ ਡਾਟਾ ਨੂੰ ਪਾਰਸ ਅਤੇ ਫਾਰਮੈਟ ਕਰਨਾ
- ਗਲਤੀਆਂ ਨੂੰ ਸੰਭਾਲਣਾ ਅਤੇ API ਰੇਟ ਲਿਮਿਟਾਂ ਨੂੰ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਤਰੀਕੇ ਨਾਲ ਮੈਨੇਜ ਕਰਨਾ
- ਦੋਹਾਂ ਆਟੋਮੇਟਿਕ ਅਤੇ ਇੰਟਰਐਕਟਿਵ MCP ਕਲਾਇੰਟਾਂ ਨੂੰ ਬਣਾਉਣਾ ਅਤੇ ਟੈਸਟ ਕਰਨਾ

## ਵੈੱਬ ਖੋਜ MCP ਸਰਵਰ

ਇਸ ਭਾਗ ਵਿੱਚ ਵੈੱਬ ਖੋਜ MCP ਸਰਵਰ ਦੀ ਆਰਕੀਟੈਕਚਰ ਅਤੇ ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਦਾ ਪਰਿਚਯ ਦਿੱਤਾ ਗਿਆ ਹੈ। ਤੁਸੀਂ ਵੇਖੋਗੇ ਕਿ ਕਿਵੇਂ FastMCP ਅਤੇ SerpAPI ਨੂੰ ਮਿਲਾ ਕੇ LLM ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਵੈੱਬ ਡਾਟਾ ਨਾਲ ਵਧਾਇਆ ਜਾਂਦਾ ਹੈ।

### ਓਵਰਵਿਊ

ਇਸ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਵਿੱਚ ਚਾਰ ਟੂਲ ਹਨ ਜੋ MCP ਦੀ ਸਮਰੱਥਾ ਨੂੰ ਦਰਸਾਉਂਦੇ ਹਨ ਕਿ ਕਿਵੇਂ ਇਹ ਵੱਖ-ਵੱਖ, ਬਾਹਰੀ API-ਚਲਿਤ ਕੰਮਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਅਤੇ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਤਰੀਕੇ ਨਾਲ ਸੰਭਾਲ ਸਕਦਾ ਹੈ:

- **general_search**: ਵਿਆਪਕ ਵੈੱਬ ਨਤੀਜੇ ਲਈ
- **news_search**: ਤਾਜ਼ਾ ਸਿਰਲੇਖਾਂ ਲਈ
- **product_search**: ਈ-ਕਾਮਰਸ ਡਾਟਾ ਲਈ
- **qna**: ਪ੍ਰਸ਼ਨ-ਉੱਤਰ ਟੁਕੜੇ ਲਈ

### ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ
- **ਕੋਡ ਉਦਾਹਰਨਾਂ**: ਪਾਇਥਨ ਲਈ ਭਾਸ਼ਾ-ਵਿਸ਼ੇਸ਼ ਕੋਡ ਬਲਾਕ ਸ਼ਾਮਲ ਹਨ (ਅਤੇ ਆਸਾਨੀ ਨਾਲ ਹੋਰ ਭਾਸ਼ਾਵਾਂ ਵਿੱਚ ਵਧਾਏ ਜਾ ਸਕਦੇ ਹਨ) ਜੋ ਸਪਸ਼ਟਤਾ ਲਈ ਕਾਲੈਪਸਿਬਲ ਸੈਕਸ਼ਨਾਂ ਵਿੱਚ ਹਨ

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

ਕਲਾਇੰਟ ਚਲਾਉਣ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਸਮਝਣਾ ਲਾਭਦਾਇਕ ਹੈ ਕਿ ਸਰਵਰ ਕੀ ਕਰਦਾ ਹੈ। [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ਫਾਇਲ MCP ਸਰਵਰ ਨੂੰ ਲਾਗੂ ਕਰਦੀ ਹੈ, ਜੋ ਵੈੱਬ, ਖ਼ਬਰਾਂ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ ਪ੍ਰਸ਼ਨ-ਉੱਤਰ ਲਈ ਟੂਲਾਂ ਨੂੰ SerpAPI ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰਕੇ ਉਪਲਬਧ ਕਰਵਾਉਂਦੀ ਹੈ। ਇਹ ਆਉਣ ਵਾਲੀਆਂ ਬੇਨਤੀਆਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ, API ਕਾਲਾਂ ਨੂੰ ਮੈਨੇਜ ਕਰਦਾ ਹੈ, ਜਵਾਬਾਂ ਨੂੰ ਪਾਰਸ ਕਰਦਾ ਹੈ ਅਤੇ ਕਲਾਇੰਟ ਨੂੰ ਸੰਰਚਿਤ ਨਤੀਜੇ ਵਾਪਸ ਕਰਦਾ ਹੈ।

ਤੁਸੀਂ ਪੂਰੀ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਨੂੰ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ਵਿੱਚ ਵੇਖ ਸਕਦੇ ਹੋ।

ਇੱਥੇ ਇੱਕ ਛੋਟਾ ਉਦਾਹਰਨ ਹੈ ਕਿ ਸਰਵਰ ਕਿਵੇਂ ਇੱਕ ਟੂਲ ਨੂੰ ਪਰਿਭਾਸ਼ਿਤ ਅਤੇ ਰਜਿਸਟਰ ਕਰਦਾ ਹੈ:

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

- **ਬਾਹਰੀ API ਇੰਟੀਗ੍ਰੇਸ਼ਨ**: API ਕੁੰਜੀਆਂ ਅਤੇ ਬਾਹਰੀ ਬੇਨਤੀਆਂ ਦੀ ਸੁਰੱਖਿਅਤ ਸੰਭਾਲ ਦਿਖਾਉਂਦਾ ਹੈ
- **ਸੰਰਚਿਤ ਡਾਟਾ ਪਾਰਸਿੰਗ**: API ਜਵਾਬਾਂ ਨੂੰ LLM-ਮਿੱਤਰ ਫਾਰਮੈਟ ਵਿੱਚ ਬਦਲਣ ਦਾ ਤਰੀਕਾ ਦਿਖਾਉਂਦਾ ਹੈ
- **ਗਲਤੀ ਸੰਭਾਲਣਾ**: ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲਣ ਅਤੇ ਉਚਿਤ ਲੌਗਿੰਗ
- **ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ**: ਆਟੋਮੇਟਿਕ ਟੈਸਟਾਂ ਅਤੇ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਦੋਹਾਂ ਸ਼ਾਮਲ ਹਨ
- **ਸੰਦਰਭ ਪ੍ਰਬੰਧਨ**: MCP Context ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਲੌਗਿੰਗ ਅਤੇ ਬੇਨਤੀਆਂ ਦੀ ਟ੍ਰੈਕਿੰਗ

## ਲੋੜੀਂਦੇ ਸਾਧਨ

ਸ਼ੁਰੂ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਹਾਡਾ ਵਾਤਾਵਰਣ ਠੀਕ ਤਰ੍ਹਾਂ ਸੈੱਟ ਹੈ। ਇਹ ਯਕੀਨੀ ਬਣਾਏਗਾ ਕਿ ਸਾਰੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਹਨ ਅਤੇ ਤੁਹਾਡੇ API ਕੁੰਜੀਆਂ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਕਨਫਿਗਰ ਕੀਤੀਆਂ ਗਈਆਂ ਹਨ ਤਾਂ ਜੋ ਵਿਕਾਸ ਅਤੇ ਟੈਸਟਿੰਗ ਬਿਨਾਂ ਰੁਕਾਵਟ ਹੋਵੇ।

- Python 3.8 ਜਾਂ ਉੱਪਰ
- SerpAPI API ਕੁੰਜੀ (ਸਾਈਨ ਅਪ ਕਰੋ [SerpAPI](https://serpapi.com/) ਤੇ - ਮੁਫ਼ਤ ਟੀਅਰ ਉਪਲਬਧ)

## ਇੰਸਟਾਲੇਸ਼ਨ

ਆਪਣਾ ਵਾਤਾਵਰਣ ਸੈੱਟ ਕਰਨ ਲਈ ਹੇਠਾਂ ਦਿੱਤੇ ਕਦਮਾਂ ਦੀ ਪਾਲਣਾ ਕਰੋ:

1. uv (ਸਿਫਾਰਸ਼ੀ) ਜਾਂ pip ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. ਪ੍ਰੋਜੈਕਟ ਰੂਟ ਵਿੱਚ `.env` ਫਾਇਲ ਬਣਾਓ ਅਤੇ ਆਪਣੀ SerpAPI ਕੁੰਜੀ ਸ਼ਾਮਲ ਕਰੋ:

```
SERPAPI_KEY=your_serpapi_key_here
```

## ਵਰਤੋਂ

ਵੈੱਬ ਖੋਜ MCP ਸਰਵਰ ਮੁੱਖ ਹਿੱਸਾ ਹੈ ਜੋ ਵੈੱਬ, ਖ਼ਬਰਾਂ, ਉਤਪਾਦ ਖੋਜ ਅਤੇ ਪ੍ਰਸ਼ਨ-ਉੱਤਰ ਲਈ ਟੂਲਾਂ ਨੂੰ SerpAPI ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰਕੇ ਉਪਲਬਧ ਕਰਵਾਉਂਦਾ ਹੈ। ਇਹ ਆਉਣ ਵਾਲੀਆਂ ਬੇਨਤੀਆਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ, API ਕਾਲਾਂ ਨੂੰ ਮੈਨੇਜ ਕਰਦਾ ਹੈ, ਜਵਾਬਾਂ ਨੂੰ ਪਾਰਸ ਕਰਦਾ ਹੈ ਅਤੇ ਕਲਾਇੰਟ ਨੂੰ ਸੰਰਚਿਤ ਨਤੀਜੇ ਵਾਪਸ ਕਰਦਾ ਹੈ।

ਤੁਸੀਂ ਪੂਰੀ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਨੂੰ [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) ਵਿੱਚ ਵੇਖ ਸਕਦੇ ਹੋ।

### ਸਰਵਰ ਚਲਾਉਣਾ

MCP ਸਰਵਰ ਸ਼ੁਰੂ ਕਰਨ ਲਈ, ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਵਰਤੋ:

```bash
python server.py
```

ਸਰਵਰ ਇੱਕ stdio-ਅਧਾਰਿਤ MCP ਸਰਵਰ ਵਜੋਂ ਚੱਲੇਗਾ ਜਿਸ ਨਾਲ ਕਲਾਇੰਟ ਸਿੱਧਾ ਜੁੜ ਸਕਦਾ ਹੈ।

### ਕਲਾਇੰਟ ਮੋਡ

ਕਲਾਇੰਟ (`client.py`) MCP ਸਰਵਰ ਨਾਲ ਇੰਟਰਐਕਟ ਕਰਨ ਲਈ ਦੋ ਮੋਡ ਸਹਾਇਤਾ ਕਰਦਾ ਹੈ:

- **ਨਾਰਮਲ ਮੋਡ**: ਸਾਰੇ ਟੂਲਾਂ ਨੂੰ ਵਰਤ ਕੇ ਆਟੋਮੇਟਿਕ ਟੈਸਟ ਚਲਾਉਂਦਾ ਹੈ ਅਤੇ ਉਨ੍ਹਾਂ ਦੇ ਜਵਾਬਾਂ ਦੀ ਜਾਂਚ ਕਰਦਾ ਹੈ। ਇਹ ਤੇਜ਼ੀ ਨਾਲ ਜਾਂਚ ਕਰਨ ਲਈ ਲਾਭਦਾਇਕ ਹੈ ਕਿ ਸਰਵਰ ਅਤੇ ਟੂਲ ਸਹੀ ਤਰ੍ਹਾਂ ਕੰਮ ਕਰ ਰਹੇ ਹਨ।
- **ਇੰਟਰਐਕਟਿਵ ਮੋਡ**: ਇੱਕ ਮੀਨੂ-ਚਲਿਤ ਇੰਟਰਫੇਸ ਸ਼ੁਰੂ ਕਰਦਾ ਹੈ ਜਿੱਥੇ ਤੁਸੀਂ ਹੱਥੋਂ-ਹੱਥ ਟੂਲ ਚੁਣ ਸਕਦੇ ਹੋ, ਕਸਟਮ ਪ੍ਰਸ਼ਨ ਦਰਜ ਕਰ ਸਕਦੇ ਹੋ ਅਤੇ ਨਤੀਜੇ ਤੁਰੰਤ ਵੇਖ ਸਕਦੇ ਹੋ। ਇਹ ਸਰਵਰ ਦੀ ਸਮਰੱਥਾ ਨੂੰ ਖੋਜਣ ਅਤੇ ਵੱਖ-ਵੱਖ ਇਨਪੁੱਟਾਂ ਨਾਲ ਪ੍ਰਯੋਗ ਕਰਨ ਲਈ ਬਹੁਤ ਵਧੀਆ ਹੈ।

ਤੁਸੀਂ ਪੂਰੀ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਨੂੰ [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) ਵਿੱਚ ਵੇਖ ਸਕਦੇ ਹੋ।

### ਕਲਾਇੰਟ ਚਲਾਉਣਾ

ਆਟੋਮੇਟਿਕ ਟੈਸਟ ਚਲਾਉਣ ਲਈ (ਇਸ ਨਾਲ ਸਰਵਰ ਆਪਣੇ ਆਪ ਸ਼ੁਰੂ ਹੋ ਜਾਵੇਗਾ):

```bash
python client.py
```

ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ ਚਲਾਉਣ ਲਈ:

```bash
python client.py --interactive
```

### ਵੱਖ-ਵੱਖ ਤਰੀਕਿਆਂ ਨਾਲ ਟੈਸਟਿੰਗ

ਸਰਵਰ ਵੱਲੋਂ ਦਿੱਤੇ ਗਏ ਟੂਲਾਂ ਨਾਲ ਟੈਸਟ ਕਰਨ ਅਤੇ ਇੰਟਰਐਕਟ ਕਰਨ ਦੇ ਕਈ ਤਰੀਕੇ ਹਨ, ਜੋ ਤੁਹਾਡੇ ਜ਼ਰੂਰਤਾਂ ਅਤੇ ਕੰਮ ਦੇ ਤਰੀਕੇ 'ਤੇ ਨਿਰਭਰ ਕਰਦੇ ਹਨ।

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

ਇਸ ਸੰਦਰਭ ਵਿੱਚ, "ਟੈਸਟ ਸਕ੍ਰਿਪਟ" ਦਾ ਮਤਲਬ ਹੈ ਇੱਕ ਕਸਟਮ ਪਾਇਥਨ ਪ੍ਰੋਗਰਾਮ ਜੋ ਤੁਸੀਂ MCP ਸਰਵਰ ਲਈ ਕਲਾਇੰਟ ਵਜੋਂ ਲਿਖਦੇ ਹੋ। ਇਹ ਇੱਕ ਰਸਮੀ ਯੂਨਿਟ ਟੈਸਟ ਨਹੀਂ ਹੁੰਦਾ, ਪਰ ਇਹ ਤੁਹਾਨੂੰ ਪ੍ਰੋਗਰਾਮੈਟਿਕ ਤਰੀਕੇ ਨਾਲ ਸਰਵਰ ਨਾਲ ਜੁੜਨ, ਕਿਸੇ ਵੀ ਟੂਲ ਨੂੰ ਆਪਣੀਆਂ ਪੈਰਾਮੀਟਰਾਂ ਨਾਲ ਕਾਲ ਕਰਨ ਅਤੇ ਨਤੀਜੇ ਦੇਖਣ ਦੀ ਆਜ਼ਾਦੀ ਦਿੰਦਾ ਹੈ। ਇਹ ਤਰੀਕਾ ਲਾਭਦਾਇਕ ਹੈ:

- ਟੂਲ ਕਾਲਾਂ ਦੀ ਪ੍ਰੋਟੋਟਾਈਪਿੰਗ ਅਤੇ ਪ੍ਰਯੋਗ ਕਰਨ ਲਈ
- ਵੱਖ-ਵੱਖ ਇਨਪੁੱਟਾਂ 'ਤੇ ਸਰਵਰ ਦੇ ਜਵਾਬ ਦੀ ਜਾਂਚ ਕਰਨ ਲਈ
- ਟੂਲਾਂ ਦੀ ਦੁਹਰਾਈ ਹੋਈ ਕਾਲਾਂ ਨੂੰ ਆਟੋਮੇਟ ਕਰਨ ਲਈ
- MCP ਸਰਵਰ ਦੇ ਉੱਪਰ ਆਪਣੇ ਕੰਮ ਦੇ ਪ੍ਰਵਾਹ ਜਾਂ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਬਣਾਉਣ ਲਈ

ਤੁਸੀਂ ਟੈਸਟ ਸਕ੍ਰਿਪਟਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਨਵੇਂ ਪ੍ਰਸ਼ਨਾਂ ਨੂੰ ਤੇਜ਼ੀ ਨਾਲ ਅਜ਼ਮਾ ਸਕਦੇ ਹੋ, ਟੂਲ ਦੇ ਵਿਹਾਰ ਨੂੰ ਡੀਬੱਗ ਕਰ ਸਕਦੇ ਹੋ ਜਾਂ ਹੋਰ ਅਡਵਾਂਸ ਆਟੋਮੇਸ਼ਨ ਲਈ ਸ਼ੁਰੂਆਤ ਕਰ ਸਕਦੇ ਹੋ। ਹੇਠਾਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਇੱਕ ਸਕ੍ਰਿਪਟ ਬਣਾਉਣ ਦਾ ਉਦਾਹਰਨ ਦਿੱਤਾ ਗਿਆ ਹੈ:

## ਟੂਲ ਵੇਰਵੇ

ਤੁਸੀਂ ਸਰਵਰ ਵੱਲੋਂ ਦਿੱਤੇ ਗਏ ਹੇਠਾਂ ਦਿੱਤੇ ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਵੱਖ-ਵੱਖ ਕਿਸਮ ਦੀਆਂ ਖੋਜਾਂ ਅਤੇ ਪ੍ਰਸ਼ਨਾਂ ਲਈ ਕਰ ਸਕਦੇ ਹੋ। ਹਰ ਟੂਲ ਨੂੰ ਉਸਦੇ ਪੈਰਾਮੀਟਰਾਂ ਅਤੇ ਉਦਾਹਰਨ ਵਰਤੋਂ ਨਾਲ ਵੇਰਵਾ ਦਿੱਤਾ ਗਿਆ ਹੈ।

ਇਸ ਭਾਗ ਵਿੱਚ ਹਰ ਉਪਲਬਧ ਟੂਲ ਅਤੇ ਉਹਨਾਂ ਦੇ ਪੈਰਾਮੀਟਰਾਂ ਬਾਰੇ ਜਾਣਕਾਰੀ ਦਿੱਤੀ ਗਈ ਹੈ।

### general_search

ਇਹ ਇੱਕ ਆਮ ਵੈੱਬ ਖੋਜ ਕਰਦਾ ਹੈ ਅਤੇ ਫਾਰਮੈਟ ਕੀਤੇ ਨਤੀਜੇ ਵਾਪਸ ਕਰਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ `general_search` ਨੂੰ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਦੀ ਵਰਤੋਂ ਕਰਕੇ। ਹੇਠਾਂ SDK ਦੀ ਵਰਤੋਂ ਨਾਲ ਕੋਡ ਉਦਾਹਰਨ ਦਿੱਤੀ ਗਈ ਹੈ:

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ, ਮੀਨੂ ਤੋਂ `general_search` ਚੁਣੋ ਅਤੇ ਜਦੋਂ ਪੁੱਛਿਆ ਜਾਵੇ ਤਾਂ ਆਪਣਾ ਪ੍ਰਸ਼ਨ ਦਰਜ ਕਰੋ।

**ਪੈਰਾਮੀਟਰ:**
- `query` (string): ਖੋਜ ਪ੍ਰਸ਼ਨ

**ਉਦਾਹਰਨ ਬੇਨਤੀ:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

ਇਹ ਕਿਸੇ ਪ੍ਰਸ਼ਨ ਨਾਲ ਸੰਬੰਧਿਤ ਤਾਜ਼ਾ ਖ਼ਬਰਾਂ ਦੀ ਖੋਜ ਕਰਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ `news_search` ਨੂੰ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਦੀ ਵਰਤੋਂ ਕਰਕੇ। ਹੇਠਾਂ SDK ਦੀ ਵਰਤੋਂ ਨਾਲ ਕੋਡ ਉਦਾਹਰਨ ਦਿੱਤੀ ਗਈ ਹੈ:

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ, ਮੀਨੂ ਤੋਂ `news_search` ਚੁਣੋ ਅਤੇ ਜਦੋਂ ਪੁੱਛਿਆ ਜਾਵੇ ਤਾਂ ਆਪਣਾ ਪ੍ਰਸ਼ਨ ਦਰਜ ਕਰੋ।

**ਪੈਰਾਮੀਟਰ:**
- `query` (string): ਖੋਜ ਪ੍ਰਸ਼ਨ

**ਉਦਾਹਰਨ ਬੇਨਤੀ:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

ਇਹ ਕਿਸੇ ਪ੍ਰਸ਼ਨ ਨਾਲ ਮਿਲਦੇ ਜੁਲਦੇ ਉਤਪਾਦਾਂ ਦੀ ਖੋਜ ਕਰਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ `product_search` ਨੂੰ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਦੀ ਵਰਤੋਂ ਕਰਕੇ। ਹੇਠਾਂ SDK ਦੀ ਵਰਤੋਂ ਨਾਲ ਕੋਡ ਉਦਾਹਰਨ ਦਿੱਤੀ ਗਈ ਹੈ:

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ, ਮੀਨੂ ਤੋਂ `product_search` ਚੁਣੋ ਅਤੇ ਜਦੋਂ ਪੁੱਛਿਆ ਜਾਵੇ ਤਾਂ ਆਪਣਾ ਪ੍ਰਸ਼ਨ ਦਰਜ ਕਰੋ।

**ਪੈਰਾਮੀਟਰ:**
- `query` (string): ਉਤਪਾਦ ਖੋਜ ਪ੍ਰਸ਼ਨ

**ਉਦਾਹਰਨ ਬੇਨਤੀ:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

ਇਹ ਖੋਜ ਇੰਜਣਾਂ ਤੋਂ ਸਿੱਧੇ ਪ੍ਰਸ਼ਨਾਂ ਦੇ ਜਵਾਬ ਲੈਦਾ ਹੈ।

**ਇਸ ਟੂਲ ਨੂੰ ਕਿਵੇਂ ਕਾਲ ਕਰਨਾ ਹੈ:**

ਤੁਸੀਂ MCP Python SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ `qna` ਨੂੰ ਆਪਣੇ ਸਕ੍ਰਿਪਟ ਤੋਂ ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ, ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ Inspector ਜਾਂ ਇੰਟਰਐਕਟਿਵ ਕਲਾਇੰਟ ਮੋਡ ਦੀ ਵਰਤੋਂ ਕਰਕੇ। ਹੇਠਾਂ SDK ਦੀ ਵਰਤੋਂ ਨਾਲ ਕੋਡ ਉਦਾਹਰਨ ਦਿੱਤੀ ਗਈ ਹੈ:

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

ਵਿਕਲਪਕ ਤੌਰ 'ਤੇ, ਇੰਟਰਐਕਟਿਵ ਮੋਡ ਵਿੱਚ, ਮੀਨੂ ਤੋਂ `qna` ਚੁਣੋ ਅਤੇ ਜਦੋਂ ਪੁੱਛਿਆ ਜਾਵੇ ਤਾਂ ਆਪਣਾ ਪ੍ਰਸ਼ਨ ਦਰਜ ਕਰੋ।

**ਪੈਰਾਮੀਟਰ:

<summary>ਪਾਇਥਨ</summary>

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

## ਅਗਲਾ ਕੀ ਹੈ

- [5.10 ਰੀਅਲ ਟਾਈਮ ਸਟ੍ਰੀਮਿੰਗ](../mcp-realtimestreaming/README.md)

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।