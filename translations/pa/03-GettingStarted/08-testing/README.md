<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:07:14+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "pa"
}
-->
## ਟੈਸਟਿੰਗ ਅਤੇ ਡੀਬੱਗਿੰਗ

ਆਪਣੇ MCP ਸਰਵਰ ਦੀ ਟੈਸਟਿੰਗ ਸ਼ੁਰੂ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ, ਉਪਲਬਧ ਟੂਲਾਂ ਅਤੇ ਡੀਬੱਗਿੰਗ ਲਈ ਸਭ ਤੋਂ ਵਧੀਆ ਅਭਿਆਸਾਂ ਨੂੰ ਸਮਝਣਾ ਜ਼ਰੂਰੀ ਹੈ। ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਟੈਸਟਿੰਗ ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦੀ ਹੈ ਕਿ ਤੁਹਾਡਾ ਸਰਵਰ ਉਮੀਦ ਅਨੁਸਾਰ ਕੰਮ ਕਰਦਾ ਹੈ ਅਤੇ ਤੁਹਾਨੂੰ ਸਮੱਸਿਆਵਾਂ ਨੂੰ ਤੇਜ਼ੀ ਨਾਲ ਪਛਾਣਨ ਅਤੇ ਹੱਲ ਕਰਨ ਵਿੱਚ ਮਦਦ ਕਰਦੀ ਹੈ। ਹੇਠਾਂ ਦਿੱਤਾ ਗਿਆ ਭਾਗ ਤੁਹਾਡੇ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਦੀ ਪੁਸ਼ਟੀ ਲਈ ਸਿਫਾਰਸ਼ੀਤ ਤਰੀਕਿਆਂ ਨੂੰ ਦਰਸਾਉਂਦਾ ਹੈ।

## ਜਾਇਜ਼ਾ

ਇਹ ਪਾਠ ਸਹੀ ਟੈਸਟਿੰਗ ਪਹੁੰਚ ਚੁਣਨ ਅਤੇ ਸਭ ਤੋਂ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਟੈਸਟਿੰਗ ਟੂਲ ਦੀ ਵਰਤੋਂ ਕਰਨ ਬਾਰੇ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- ਟੈਸਟਿੰਗ ਲਈ ਵੱਖ-ਵੱਖ ਪਹੁੰਚਾਂ ਦਾ ਵਰਣਨ ਕਰਨ ਲਈ।
- ਆਪਣੇ ਕੋਡ ਦੀ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਟੈਸਟਿੰਗ ਲਈ ਵੱਖ-ਵੱਖ ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰਨ ਲਈ।

## MCP ਸਰਵਰਾਂ ਦੀ ਟੈਸਟਿੰਗ

MCP ਤੁਹਾਡੇ ਸਰਵਰਾਂ ਦੀ ਟੈਸਟਿੰਗ ਅਤੇ ਡੀਬੱਗਿੰਗ ਵਿੱਚ ਮਦਦ ਕਰਨ ਲਈ ਟੂਲ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ:

- **MCP Inspector**: ਇੱਕ ਕਮਾਂਡ ਲਾਈਨ ਟੂਲ ਜੋ CLI ਅਤੇ ਵਿਜ਼ੂਅਲ ਦੋਹਾਂ ਤਰੀਕਿਆਂ ਨਾਲ ਚਲਾਇਆ ਜਾ ਸਕਦਾ ਹੈ।
- **ਮੈਨੁਅਲ ਟੈਸਟਿੰਗ**: ਤੁਸੀਂ curl ਵਰਗਾ ਟੂਲ ਵਰਤ ਸਕਦੇ ਹੋ ਵੈੱਬ ਰਿਕਵੇਸਟਾਂ ਚਲਾਉਣ ਲਈ, ਪਰ ਕੋਈ ਵੀ HTTP ਚਲਾਉਣ ਵਾਲਾ ਟੂਲ ਕਾਫ਼ੀ ਹੈ।
- **ਯੂਨਿਟ ਟੈਸਟਿੰਗ**: ਤੁਸੀਂ ਆਪਣੇ ਮਨਪਸੰਦ ਟੈਸਟਿੰਗ ਫਰੇਮਵਰਕ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਦੋਹਾਂ ਦੀਆਂ ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਦੀ ਜਾਂਚ ਕਰ ਸਕਦੇ ਹੋ।

### MCP Inspector ਦੀ ਵਰਤੋਂ

ਅਸੀਂ ਪਹਿਲਾਂ ਦੇ ਪਾਠਾਂ ਵਿੱਚ ਇਸ ਟੂਲ ਦੀ ਵਰਤੋਂ ਬਾਰੇ ਦੱਸਿਆ ਹੈ ਪਰ ਆਓ ਇਸ ਬਾਰੇ ਥੋੜ੍ਹਾ ਜਿਹਾ ਉੱਚ ਸਤਰ ਤੇ ਗੱਲ ਕਰੀਏ। ਇਹ ਇੱਕ Node.js ਵਿੱਚ ਬਣਿਆ ਟੂਲ ਹੈ ਅਤੇ ਤੁਸੀਂ ਇਸਨੂੰ `npx` ਐਗਜ਼ਿਕਿਊਟੇਬਲ ਕਾਲ ਕਰਕੇ ਵਰਤ ਸਕਦੇ ਹੋ ਜੋ ਟੂਲ ਨੂੰ ਅਸਥਾਈ ਤੌਰ ਤੇ ਡਾਊਨਲੋਡ ਅਤੇ ਇੰਸਟਾਲ ਕਰੇਗਾ ਅਤੇ ਤੁਹਾਡੇ ਰਿਕਵੇਸਟ ਦੇ ਚਲਾਉਣ ਤੋਂ ਬਾਅਦ ਆਪਣੇ ਆਪ ਨੂੰ ਸਾਫ਼ ਕਰ ਦੇਵੇਗਾ।

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) ਤੁਹਾਡੇ ਲਈ ਇਹ ਕਰਦਾ ਹੈ:

- **ਸਰਵਰ ਦੀਆਂ ਸਮਰੱਥਾਵਾਂ ਦੀ ਖੋਜ ਕਰੋ**: ਉਪਲਬਧ ਸਰੋਤਾਂ, ਟੂਲਾਂ ਅਤੇ ਪ੍ਰਾਂਪਟਾਂ ਨੂੰ ਆਪਣੇ ਆਪ ਪਛਾਣੋ
- **ਟੂਲ ਚਲਾਉਣ ਦੀ ਟੈਸਟਿੰਗ ਕਰੋ**: ਵੱਖ-ਵੱਖ ਪੈਰਾਮੀਟਰ ਅਜ਼ਮਾਓ ਅਤੇ ਜਵਾਬ ਤੁਰੰਤ ਵੇਖੋ
- **ਸਰਵਰ ਮੈਟਾ ਡੇਟਾ ਵੇਖੋ**: ਸਰਵਰ ਦੀ ਜਾਣਕਾਰੀ, ਸਕੀਮਾਂ ਅਤੇ ਸੰਰਚਨਾਵਾਂ ਦੀ ਜਾਂਚ ਕਰੋ

ਇਸ ਟੂਲ ਦੀ ਆਮ ਚਾਲ ਇਸ ਤਰ੍ਹਾਂ ਹੁੰਦੀ ਹੈ:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

ਉਪਰ ਦਿੱਤਾ ਕਮਾਂਡ ਇੱਕ MCP ਅਤੇ ਇਸ ਦੀ ਵਿਜ਼ੂਅਲ ਇੰਟਰਫੇਸ ਸ਼ੁਰੂ ਕਰਦਾ ਹੈ ਅਤੇ ਤੁਹਾਡੇ ਬ੍ਰਾਉਜ਼ਰ ਵਿੱਚ ਇੱਕ ਲੋਕਲ ਵੈੱਬ ਇੰਟਰਫੇਸ ਖੋਲ੍ਹਦਾ ਹੈ। ਤੁਸੀਂ ਆਪਣੀ ਰਜਿਸਟਰ ਕੀਤੀ MCP ਸਰਵਰਾਂ, ਉਨ੍ਹਾਂ ਦੇ ਉਪਲਬਧ ਟੂਲਾਂ, ਸਰੋਤਾਂ ਅਤੇ ਪ੍ਰਾਂਪਟਾਂ ਵਾਲਾ ਡੈਸ਼ਬੋਰਡ ਵੇਖ ਸਕਦੇ ਹੋ। ਇਹ ਇੰਟਰਫੇਸ ਤੁਹਾਨੂੰ ਇੰਟਰਐਕਟਿਵ ਤਰੀਕੇ ਨਾਲ ਟੂਲ ਚਲਾਉਣ ਦੀ ਟੈਸਟਿੰਗ ਕਰਨ, ਸਰਵਰ ਮੈਟਾ ਡੇਟਾ ਦੀ ਜਾਂਚ ਕਰਨ ਅਤੇ ਰੀਅਲ-ਟਾਈਮ ਜਵਾਬ ਵੇਖਣ ਦੀ ਆਸਾਨੀ ਦਿੰਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਤੁਹਾਡੇ MCP ਸਰਵਰ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਦੀ ਪੁਸ਼ਟੀ ਅਤੇ ਡੀਬੱਗਿੰਗ ਸੌਖੀ ਹੋ ਜਾਂਦੀ ਹੈ।

ਇਸ ਤਰ੍ਹਾਂ ਲੱਗ ਸਕਦਾ ਹੈ: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pa.png)

ਤੁਸੀਂ ਇਸ ਟੂਲ ਨੂੰ CLI ਮੋਡ ਵਿੱਚ ਵੀ ਚਲਾ ਸਕਦੇ ਹੋ ਜਿਸ ਲਈ ਤੁਸੀਂ `--cli` ਐਟਰਿਬਿਊਟ ਜੋੜਦੇ ਹੋ। ਹੇਠਾਂ CLI ਮੋਡ ਵਿੱਚ ਟੂਲ ਚਲਾਉਣ ਦਾ ਉਦਾਹਰਨ ਦਿੱਤਾ ਹੈ ਜੋ ਸਰਵਰ 'ਤੇ ਸਾਰੇ ਟੂਲਾਂ ਦੀ ਸੂਚੀ ਦਿਖਾਉਂਦਾ ਹੈ:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### ਮੈਨੁਅਲ ਟੈਸਟਿੰਗ

ਸਰਵਰ ਸਮਰੱਥਾਵਾਂ ਦੀ ਟੈਸਟਿੰਗ ਲਈ inspector ਟੂਲ ਚਲਾਉਣ ਤੋਂ ਇਲਾਵਾ, ਇੱਕ ਹੋਰ ਮਿਲਦੀ ਜੁਲਦੀ ਪਹੁੰਚ HTTP ਵਰਤ ਸਕਣ ਵਾਲੇ ਕਲਾਇੰਟ ਨੂੰ ਚਲਾਉਣਾ ਹੈ ਜਿਵੇਂ ਕਿ curl।

curl ਦੀ ਵਰਤੋਂ ਨਾਲ, ਤੁਸੀਂ MCP ਸਰਵਰਾਂ ਨੂੰ ਸਿੱਧਾ HTTP ਰਿਕਵੇਸਟਾਂ ਰਾਹੀਂ ਟੈਸਟ ਕਰ ਸਕਦੇ ਹੋ:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

ਉਪਰ curl ਦੀ ਵਰਤੋਂ ਤੋਂ ਤੁਸੀਂ ਵੇਖ ਸਕਦੇ ਹੋ ਕਿ ਤੁਸੀਂ POST ਰਿਕਵੇਸਟ ਦੀ ਵਰਤੋਂ ਕਰਦੇ ਹੋ ਇੱਕ ਟੂਲ ਨੂੰ ਕਾਲ ਕਰਨ ਲਈ ਜਿਸ ਵਿੱਚ ਟੂਲ ਦਾ ਨਾਮ ਅਤੇ ਇਸਦੇ ਪੈਰਾਮੀਟਰਾਂ ਵਾਲਾ ਪੇਲੋਡ ਹੁੰਦਾ ਹੈ। ਉਹ ਪਹੁੰਚ ਵਰਤੋ ਜੋ ਤੁਹਾਡੇ ਲਈ ਸਭ ਤੋਂ ਵਧੀਆ ਹੈ। CLI ਟੂਲ ਆਮ ਤੌਰ 'ਤੇ ਤੇਜ਼ ਹੁੰਦੇ ਹਨ ਅਤੇ ਇਨ੍ਹਾਂ ਨੂੰ ਸਕ੍ਰਿਪਟ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ ਜੋ CI/CD ਮਾਹੌਲ ਵਿੱਚ ਲਾਭਦਾਇਕ ਹੈ।

### ਯੂਨਿਟ ਟੈਸਟਿੰਗ

ਆਪਣੇ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਲਈ ਯੂਨਿਟ ਟੈਸਟ ਬਣਾਓ ਤਾਂ ਜੋ ਇਹ ਯਕੀਨੀ ਬਣਾਇਆ ਜਾ ਸਕੇ ਕਿ ਇਹ ਉਮੀਦ ਅਨੁਸਾਰ ਕੰਮ ਕਰਦੇ ਹਨ। ਹੇਠਾਂ ਕੁਝ ਉਦਾਹਰਣ ਟੈਸਟਿੰਗ ਕੋਡ ਦਿੱਤਾ ਗਿਆ ਹੈ।

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

ਉਪਰ ਦਿੱਤਾ ਕੋਡ ਇਹ ਕਰਦਾ ਹੈ:

- pytest ਫਰੇਮਵਰਕ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ ਜੋ ਤੁਹਾਨੂੰ ਫੰਕਸ਼ਨ ਵਜੋਂ ਟੈਸਟ ਬਣਾਉਣ ਅਤੇ assert ਬਿਆਨਾਂ ਦੀ ਵਰਤੋਂ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।
- ਦੋ ਵੱਖ-ਵੱਖ ਟੂਲਾਂ ਨਾਲ ਇੱਕ MCP ਸਰਵਰ ਬਣਾਉਂਦਾ ਹੈ।
- ਕੁਝ ਸ਼ਰਤਾਂ ਦੀ ਪੁਸ਼ਟੀ ਕਰਨ ਲਈ `assert` ਬਿਆਨ ਵਰਤਦਾ ਹੈ।

[ਪੂਰਾ ਫਾਇਲ ਇੱਥੇ ਦੇਖੋ](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

ਉਪਰੋਕਤ ਫਾਇਲ ਦੇ ਆਧਾਰ 'ਤੇ, ਤੁਸੀਂ ਆਪਣੇ ਸਰਵਰ ਦੀ ਟੈਸਟਿੰਗ ਕਰ ਸਕਦੇ ਹੋ ਤਾਂ ਜੋ ਇਹ ਯਕੀਨੀ ਬਣਾਇਆ ਜਾ ਸਕੇ ਕਿ ਸਮਰੱਥਾਵਾਂ ਠੀਕ ਤਰ੍ਹਾਂ ਬਣਾਈਆਂ ਗਈਆਂ ਹਨ।

ਸਾਰੇ ਮੁੱਖ SDKs ਵਿੱਚ ਇਸੇ ਤਰ੍ਹਾਂ ਟੈਸਟਿੰਗ ਭਾਗ ਹੁੰਦੇ ਹਨ ਤਾਂ ਤੁਸੀਂ ਆਪਣੇ ਚੁਣੇ ਹੋਏ ਰਨਟਾਈਮ ਅਨੁਸਾਰ ਅਨੁਕੂਲਿਤ ਕਰ ਸਕਦੇ ਹੋ।

## ਨਮੂਨੇ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## ਵਾਧੂ ਸਰੋਤ

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## ਅਗਲਾ ਕੀ ਹੈ

- ਅਗਲਾ: [Deployment](/03-GettingStarted/09-deployment/README.md)

**ਅਸਵੀਕਾਰੋਤਾ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਣਸਹੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਅਧਿਕਾਰਕ ਸਰੋਤ ਵਜੋਂ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉੱਪਜਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।