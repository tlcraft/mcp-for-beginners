<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:42:04+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "pa"
}
-->
## ਟੈਸਟਿੰਗ ਅਤੇ ਡਿਬੱਗਿੰਗ

ਆਪਣੇ MCP ਸਰਵਰ ਦੀ ਜਾਂਚ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ, ਡਿਬੱਗਿੰਗ ਲਈ ਉਪਲਬਧ ਟੂਲ ਅਤੇ ਵਧੀਆ ਅਭਿਆਸਾਂ ਨੂੰ ਸਮਝਣਾ ਮਹੱਤਵਪੂਰਨ ਹੈ। ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਟੈਸਟਿੰਗ ਯਕੀਨੀ ਬਣਾਉਂਦੀ ਹੈ ਕਿ ਤੁਹਾਡਾ ਸਰਵਰ ਉਮੀਦ ਦੇ ਅਨੁਸਾਰ ਵਿਹਾਰ ਕਰਦਾ ਹੈ ਅਤੇ ਤੁਹਾਨੂੰ ਸਮੱਸਿਆਵਾਂ ਦੀ ਪਛਾਣ ਅਤੇ ਹੱਲ ਕਰਨ ਵਿੱਚ ਤੇਜ਼ੀ ਨਾਲ ਸਹਾਇਤਾ ਕਰਦਾ ਹੈ। ਹੇਠਾਂ ਦਿੱਤਾ ਸੈਕਸ਼ਨ ਤੁਹਾਡੇ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਦੀ ਵੈਧਤਾ ਦੀ ਜਾਂਚ ਕਰਨ ਲਈ ਸਿਫਾਰਸ਼ੀਕ੍ਰਿਤ ਪਹੁੰਚਾਂ ਦੀ ਰੂਪਰੇਖਾ ਦਿੰਦਾ ਹੈ।

## ਝਲਕ

ਇਹ ਪਾਠ ਸਹੀ ਟੈਸਟਿੰਗ ਪਹੁੰਚ ਅਤੇ ਸਭ ਤੋਂ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਟੈਸਟਿੰਗ ਟੂਲ ਦੀ ਚੋਣ ਕਰਨ ਦੇ ਤਰੀਕੇ ਨੂੰ ਕਵਰ ਕਰਦਾ ਹੈ।

## ਸਿਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਇਸ ਯੋਗ ਹੋਵੋਗੇ:

- ਟੈਸਟਿੰਗ ਲਈ ਵੱਖ-ਵੱਖ ਪਹੁੰਚਾਂ ਦਾ ਵੇਰਵਾ ਦਿਓ।
- ਆਪਣੇ ਕੋਡ ਨੂੰ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਢੰਗ ਨਾਲ ਜਾਂਚਣ ਲਈ ਵੱਖ-ਵੱਖ ਟੂਲ ਵਰਤੋ।

## MCP ਸਰਵਰਾਂ ਦੀ ਜਾਂਚ

MCP ਤੁਹਾਡੇ ਸਰਵਰਾਂ ਦੀ ਜਾਂਚ ਅਤੇ ਡਿਬੱਗ ਕਰਨ ਵਿੱਚ ਸਹਾਇਤਾ ਕਰਨ ਲਈ ਟੂਲ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ:

- **MCP ਇੰਸਪੈਕਟਰ**: ਇੱਕ ਕਮਾਂਡ ਲਾਈਨ ਟੂਲ ਜੋ CLI ਟੂਲ ਅਤੇ ਵਿਜ਼ੂਅਲ ਟੂਲ ਦੋਵੇਂ ਵਜੋਂ ਚਲਾਇਆ ਜਾ ਸਕਦਾ ਹੈ।
- **ਮੈਨੂਅਲ ਟੈਸਟਿੰਗ**: ਤੁਸੀਂ curl ਵਰਗੇ ਟੂਲ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਵੈੱਬ ਰਿਕਵੈਸਟ ਚਲਾ ਸਕਦੇ ਹੋ, ਪਰ ਕੋਈ ਵੀ ਟੂਲ ਜੋ HTTP ਚਲਾਉਣ ਦੇ ਯੋਗ ਹੈ ਉਹ ਕਰੇਗਾ।
- **ਯੂਨਿਟ ਟੈਸਟਿੰਗ**: ਇਹ ਤੁਹਾਡੇ ਪਸੰਦੀਦਾ ਟੈਸਟਿੰਗ ਫਰੇਮਵਰਕ ਨੂੰ ਵਰਤ ਕੇ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਦੋਵਾਂ ਦੇ ਫੀਚਰਾਂ ਦੀ ਜਾਂਚ ਕਰਨ ਲਈ ਸੰਭਵ ਹੈ।

### MCP ਇੰਸਪੈਕਟਰ ਦੀ ਵਰਤੋਂ

ਅਸੀਂ ਪਿਛਲੇ ਪਾਠਾਂ ਵਿੱਚ ਇਸ ਟੂਲ ਦੀ ਵਰਤੋਂ ਦੀ ਵਰਣਨਾ ਕੀਤੀ ਹੈ ਪਰ ਆਓ ਇਸ ਬਾਰੇ ਉੱਚ-ਸਤ੍ਹਾ 'ਤੇ ਕੁਝ ਗੱਲ ਕਰੀਏ। ਇਹ ਇੱਕ ਟੂਲ ਹੈ ਜੋ Node.js ਵਿੱਚ ਬਣਾਇਆ ਗਿਆ ਹੈ ਅਤੇ ਤੁਸੀਂ `npx` ਐਕਜ਼ੀਕਿਊਟੇਬਲ ਨੂੰ ਕਾਲ ਕਰਕੇ ਇਸ ਦੀ ਵਰਤੋਂ ਕਰ ਸਕਦੇ ਹੋ ਜੋ ਟੂਲ ਨੂੰ ਅਸਥਾਈ ਤੌਰ 'ਤੇ ਡਾਊਨਲੋਡ ਅਤੇ ਇੰਸਟਾਲ ਕਰੇਗਾ ਅਤੇ ਤੁਹਾਡੀ ਬੇਨਤੀ ਚਲਾਉਣ ਦੇ ਬਾਅਦ ਆਪਣੇ ਆਪ ਨੂੰ ਸਾਫ ਕਰੇਗਾ।

[MCP ਇੰਸਪੈਕਟਰ](https://github.com/modelcontextprotocol/inspector) ਤੁਹਾਡੀ ਮਦਦ ਕਰਦਾ ਹੈ:

- **ਸਰਵਰ ਸਮਰੱਥਾਵਾਂ ਦੀ ਖੋਜ**: ਉਪਲਬਧ ਸਰੋਤਾਂ, ਟੂਲਾਂ ਅਤੇ ਪ੍ਰੋੰਪਟਾਂ ਦੀ ਸਵੈਚਾਲਕ ਪਛਾਣ ਕਰੋ
- **ਟੂਲ ਐਗਜ਼ੀਕਿਊਸ਼ਨ ਦੀ ਜਾਂਚ**: ਵੱਖ-ਵੱਖ ਪੈਰਾਮੀਟਰਾਂ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ ਅਤੇ ਰੀਅਲ-ਟਾਈਮ ਵਿੱਚ ਜਵਾਬ ਦੇਖੋ
- **ਸਰਵਰ ਮੈਟਾਡੇਟਾ ਵੇਖੋ**: ਸਰਵਰ ਦੀ ਜਾਣਕਾਰੀ, ਸਕੀਮਾਂ ਅਤੇ ਸੰਰਚਨਾਵਾਂ ਦੀ ਜਾਂਚ ਕਰੋ

ਟੂਲ ਦਾ ਇੱਕ ਆਮ ਚਾਲ ਇਸ ਤਰ੍ਹਾਂ ਦਿਖਦਾ ਹੈ:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

ਉਪਰੋਕਤ ਕਮਾਂਡ ਇੱਕ MCP ਅਤੇ ਇਸਦਾ ਵਿਜ਼ੂਅਲ ਇੰਟਰਫੇਸ ਸ਼ੁਰੂ ਕਰਦਾ ਹੈ ਅਤੇ ਤੁਹਾਡੇ ਬ੍ਰਾਊਜ਼ਰ ਵਿੱਚ ਇੱਕ ਸਥਾਨਕ ਵੈੱਬ ਇੰਟਰਫੇਸ ਲਾਂਚ ਕਰਦਾ ਹੈ। ਤੁਸੀਂ ਆਪਣੇ ਰਜਿਸਟਰਡ MCP ਸਰਵਰਾਂ, ਉਨ੍ਹਾਂ ਦੇ ਉਪਲਬਧ ਟੂਲਾਂ, ਸਰੋਤਾਂ ਅਤੇ ਪ੍ਰੋੰਪਟਾਂ ਨੂੰ ਦਿਖਾਉਂਦਾ ਡੈਸ਼ਬੋਰਡ ਦੇਖਣ ਦੀ ਉਮੀਦ ਕਰ ਸਕਦੇ ਹੋ। ਇੰਟਰਫੇਸ ਤੁਹਾਨੂੰ ਇੰਟਰੈਕਟਿਵ ਟੂਲ ਐਗਜ਼ੀਕਿਊਸ਼ਨ ਦੀ ਜਾਂਚ ਕਰਨ, ਸਰਵਰ ਮੈਟਾਡੇਟਾ ਦੀ ਜਾਂਚ ਕਰਨ, ਅਤੇ ਰੀਅਲ-ਟਾਈਮ ਜਵਾਬਾਂ ਦੇਖਣ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਤੁਹਾਡੇ MCP ਸਰਵਰ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਦੀ ਵੈਧਤਾ ਅਤੇ ਡਿਬੱਗ ਕਰਨਾ ਆਸਾਨ ਹੋ ਜਾਂਦਾ ਹੈ।

ਇਹ ਇਸ ਤਰ੍ਹਾਂ ਦਿਖ ਸਕਦਾ ਹੈ: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.pa.png)

ਤੁਸੀਂ ਇਸ ਟੂਲ ਨੂੰ CLI ਮੋਡ ਵਿੱਚ ਵੀ ਚਲਾ ਸਕਦੇ ਹੋ ਜਿਸਦੇ ਮਾਮਲੇ ਵਿੱਚ ਤੁਸੀਂ `--cli` ਐਟ੍ਰਿਬਿਊਟ ਜੋੜਦੇ ਹੋ। "CLI" ਮੋਡ ਵਿੱਚ ਟੂਲ ਚਲਾਉਣ ਦਾ ਇੱਕ ਉਦਾਹਰਨ ਜੋ ਸਰਵਰ 'ਤੇ ਸਾਰੇ ਟੂਲਾਂ ਦੀ ਸੂਚੀ ਦਿੰਦਾ ਹੈ:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### ਮੈਨੂਅਲ ਟੈਸਟਿੰਗ

ਸਰਵਰ ਸਮਰੱਥਾਵਾਂ ਦੀ ਜਾਂਚ ਕਰਨ ਲਈ ਇੰਸਪੈਕਟਰ ਟੂਲ ਚਲਾਉਣ ਤੋਂ ਇਲਾਵਾ, ਇੱਕ ਹੋਰ ਸਮਾਨ ਪਹੁੰਚ HTTP ਵਰਤਣ ਦੇ ਯੋਗ ਕਲਾਇੰਟ ਨੂੰ ਚਲਾਉਣਾ ਹੈ ਜਿਵੇਂ ਕਿ curl।

curl ਨਾਲ, ਤੁਸੀਂ HTTP ਬੇਨਤੀਆਂ ਵਰਤ ਕੇ MCP ਸਰਵਰਾਂ ਦੀ ਸਿੱਧੀ ਜਾਂਚ ਕਰ ਸਕਦੇ ਹੋ:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

ਜਿਵੇਂ ਕਿ ਤੁਸੀਂ ਉਪਰੋਕਤ curl ਦੀ ਵਰਤੋਂ ਤੋਂ ਦੇਖ ਸਕਦੇ ਹੋ, ਤੁਸੀਂ ਟੂਲ ਦੇ ਨਾਮ ਅਤੇ ਇਸਦੇ ਪੈਰਾਮੀਟਰਾਂ ਦੇ ਸਮੱਗਰੀ ਦੇ ਨਾਲ POST ਬੇਨਤੀ ਦੀ ਵਰਤੋਂ ਕਰਦੇ ਹੋ। ਉਹ ਪਹੁੰਚ ਵਰਤੋ ਜੋ ਤੁਹਾਨੂੰ ਸਭ ਤੋਂ ਵਧੀਆ ਲੱਗਦੀ ਹੈ। CLI ਟੂਲਾਂ ਆਮ ਤੌਰ 'ਤੇ ਵਰਤਣ ਵਿੱਚ ਤੇਜ਼ ਹੁੰਦੇ ਹਨ ਅਤੇ ਇਹਨਾਂ ਨੂੰ ਸਕ੍ਰਿਪਟ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ ਜੋ CI/CD ਵਾਤਾਵਰਣ ਵਿੱਚ ਲਾਭਦਾਇਕ ਹੋ ਸਕਦਾ ਹੈ।

### ਯੂਨਿਟ ਟੈਸਟਿੰਗ

ਆਪਣੇ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਲਈ ਯੂਨਿਟ ਟੈਸਟ ਬਣਾਓ ਤਾਂ ਜੋ ਇਹ ਯਕੀਨੀ ਬਣਾਇਆ ਜਾ ਸਕੇ ਕਿ ਇਹ ਉਮੀਦ ਦੇ ਅਨੁਸਾਰ ਕੰਮ ਕਰਦੇ ਹਨ। ਇੱਥੇ ਕੁਝ ਉਦਾਹਰਨ ਟੈਸਟਿੰਗ ਕੋਡ ਹੈ।

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

ਪ੍ਰਦਾਨ ਕੀਤਾ ਕੋਡ ਇਹ ਕਰਦਾ ਹੈ:

- pytest ਫਰੇਮਵਰਕ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਜੋ ਤੁਹਾਨੂੰ ਫੰਕਸ਼ਨਾਂ ਵਜੋਂ ਟੈਸਟ ਬਣਾਉਣ ਅਤੇ assert ਬਿਆਨ ਦੀ ਵਰਤੋਂ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।
- ਦੋ ਵੱਖ-ਵੱਖ ਟੂਲਾਂ ਨਾਲ ਇੱਕ MCP ਸਰਵਰ ਬਣਾਉਂਦਾ ਹੈ।
- ਯਕੀਨੀ ਬਣਾਉਣ ਲਈ `assert` ਬਿਆਨ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਕਿ ਕੁਝ ਸ਼ਰਤਾਂ ਪੂਰੀਆਂ ਹੋਈਆਂ ਹਨ।

[ਪੂਰਾ ਫਾਈਲ ਇੱਥੇ ਵੇਖੋ](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

ਉਪਰੋਕਤ ਫਾਈਲ ਦੇ ਨਾਲ, ਤੁਸੀਂ ਆਪਣਾ ਸਰਵਰ ਜਾਂਚ ਸਕਦੇ ਹੋ ਤਾਂ ਜੋ ਇਹ ਯਕੀਨੀ ਬਣਾਇਆ ਜਾ ਸਕੇ ਕਿ ਸਮਰੱਥਾਵਾਂ ਜਿਵੇਂ ਕਿ ਉਹ ਬਣਾਈਆਂ ਜਾਣੀਆਂ ਚਾਹੀਦੀਆਂ ਹਨ।

ਸਭ ਵੱਡੇ SDK ਵਿੱਚ ਇਸੇ ਤਰ੍ਹਾਂ ਦੀਆਂ ਟੈਸਟਿੰਗ ਸੈਕਸ਼ਨਾਂ ਹੁੰਦੀਆਂ ਹਨ ਤਾਂ ਕਿ ਤੁਸੀਂ ਆਪਣੇ ਚੁਣੇ ਗਏ ਰਨਟਾਈਮ ਦੇ ਅਨੁਸਾਰ ਸਮਰੱਥਾ ਬਦਲ ਸਕੋ।

## ਨਮੂਨੇ

- [Java ਕੈਲਕੂਲੇਟਰ](../samples/java/calculator/README.md)
- [.Net ਕੈਲਕੂਲੇਟਰ](../../../../03-GettingStarted/samples/csharp)
- [JavaScript ਕੈਲਕੂਲੇਟਰ](../samples/javascript/README.md)
- [TypeScript ਕੈਲਕੂਲੇਟਰ](../samples/typescript/README.md)
- [Python ਕੈਲਕੂਲੇਟਰ](../../../../03-GettingStarted/samples/python) 

## ਵਾਧੂ ਸਰੋਤ

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## ਅਗਲਾ ਕੀ ਹੈ

- ਅਗਲਾ: [ਤਾਇਨਾਤੀ](03-GettingStarted/08-deployment/README.md)

**ਅਸਵੀਕਾਰਤਾਂ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀ ਹੋਣ ਦਾ ਯਤਨ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਦਿਓ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸੁਨਿਸ਼ਚਿਤਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਇਸ ਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਤ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਪਜਣ ਵਾਲੇ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਦੇ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।