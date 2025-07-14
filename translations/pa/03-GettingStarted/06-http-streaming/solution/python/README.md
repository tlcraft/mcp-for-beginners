<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:18:57+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਨਮੂਨੇ ਨੂੰ ਚਲਾਉਣਾ

ਇੱਥੇ ਦੱਸਿਆ ਗਿਆ ਹੈ ਕਿ ਕਿਵੇਂ ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਨੂੰ ਚਲਾਇਆ ਜਾਵੇ, ਨਾਲ ਹੀ MCP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਨੂੰ Python ਦੀ ਵਰਤੋਂ ਨਾਲ ਚਲਾਉਣਾ ਹੈ।

### ਝਲਕ

- ਤੁਸੀਂ ਇੱਕ MCP ਸਰਵਰ ਸੈੱਟਅਪ ਕਰੋਗੇ ਜੋ ਆਈਟਮਾਂ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰਦਿਆਂ ਕਲਾਇੰਟ ਨੂੰ ਪ੍ਰਗਤੀ ਸੂਚਨਾਵਾਂ ਸਟ੍ਰੀਮ ਕਰਦਾ ਹੈ।
- ਕਲਾਇੰਟ ਹਰ ਸੂਚਨਾ ਨੂੰ ਰੀਅਲ ਟਾਈਮ ਵਿੱਚ ਦਿਖਾਏਗਾ।
- ਇਹ ਗਾਈਡ ਲੋੜੀਂਦੇ ਸਾਧਨ, ਸੈੱਟਅਪ, ਚਲਾਉਣ ਅਤੇ ਸਮੱਸਿਆ ਹੱਲ ਕਰਨ ਬਾਰੇ ਹੈ।

### ਲੋੜੀਂਦੇ ਸਾਧਨ

- Python 3.9 ਜਾਂ ਨਵਾਂ ਵਰਜਨ
- `mcp` Python ਪੈਕੇਜ (ਇਸਨੂੰ `pip install mcp` ਨਾਲ ਇੰਸਟਾਲ ਕਰੋ)

### ਇੰਸਟਾਲੇਸ਼ਨ ਅਤੇ ਸੈੱਟਅਪ

1. ਰਿਪੋਜ਼ਿਟਰੀ ਕਲੋਨ ਕਰੋ ਜਾਂ ਸੌਲਿਊਸ਼ਨ ਫਾਈਲਾਂ ਡਾਊਨਲੋਡ ਕਰੋ।

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **ਇੱਕ ਵਰਚੁਅਲ ਇਨਵਾਇਰਨਮੈਂਟ ਬਣਾਓ ਅਤੇ ਐਕਟੀਵੇਟ ਕਰੋ (ਸਿਫਾਰਸ਼ੀ):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **ਲੋੜੀਂਦੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### ਫਾਈਲਾਂ

- **ਸਰਵਰ:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **ਕਲਾਇੰਟ:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਚਲਾਉਣਾ

1. ਸੌਲਿਊਸ਼ਨ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਜਾਓ:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਸ਼ੁਰੂ ਕਰੋ:

   ```pwsh
   python server.py
   ```

3. ਸਰਵਰ ਸ਼ੁਰੂ ਹੋ ਕੇ ਇਹ ਦਿਖਾਏਗਾ:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਕਲਾਇੰਟ ਚਲਾਉਣਾ

1. ਨਵਾਂ ਟਰਮੀਨਲ ਖੋਲ੍ਹੋ (ਉਹੀ ਵਰਚੁਅਲ ਇਨਵਾਇਰਨਮੈਂਟ ਅਤੇ ਡਾਇਰੈਕਟਰੀ ਐਕਟੀਵੇਟ ਕਰੋ):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. ਤੁਹਾਨੂੰ ਲਗਾਤਾਰ ਸਟ੍ਰੀਮ ਕੀਤੀਆਂ ਗਈਆਂ ਸੁਨੇਹੇ ਪ੍ਰਿੰਟ ਹੋ ਰਹੀਆਂ ਦਿਖਾਈ ਦੇਣਗੀਆਂ:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### MCP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਚਲਾਉਣਾ

1. ਸੌਲਿਊਸ਼ਨ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਜਾਓ:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. streamable-http ਟ੍ਰਾਂਸਪੋਰਟ ਨਾਲ MCP ਸਰਵਰ ਸ਼ੁਰੂ ਕਰੋ:
   ```pwsh
   python server.py mcp
   ```
3. ਸਰਵਰ ਸ਼ੁਰੂ ਹੋ ਕੇ ਇਹ ਦਿਖਾਏਗਾ:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP ਸਟ੍ਰੀਮਿੰਗ ਕਲਾਇੰਟ ਚਲਾਉਣਾ

1. ਨਵਾਂ ਟਰਮੀਨਲ ਖੋਲ੍ਹੋ (ਉਹੀ ਵਰਚੁਅਲ ਇਨਵਾਇਰਨਮੈਂਟ ਅਤੇ ਡਾਇਰੈਕਟਰੀ ਐਕਟੀਵੇਟ ਕਰੋ):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. ਜਿਵੇਂ ਸਰਵਰ ਹਰ ਆਈਟਮ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰਦਾ ਹੈ, ਤੁਹਾਨੂੰ ਸੂਚਨਾਵਾਂ ਰੀਅਲ ਟਾਈਮ ਵਿੱਚ ਪ੍ਰਿੰਟ ਹੋ ਰਹੀਆਂ ਦਿਖਾਈ ਦੇਣਗੀਆਂ:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### ਮੁੱਖ ਲਾਗੂ ਕਰਨ ਦੇ ਕਦਮ

1. **FastMCP ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰ ਬਣਾਓ।**
2. **ਇੱਕ ਟੂਲ ਡਿਫਾਈਨ ਕਰੋ ਜੋ ਲਿਸਟ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰਦਾ ਹੈ ਅਤੇ `ctx.info()` ਜਾਂ `ctx.log()` ਨਾਲ ਸੂਚਨਾਵਾਂ ਭੇਜਦਾ ਹੈ।**
3. **ਸਰਵਰ ਨੂੰ `transport="streamable-http"` ਨਾਲ ਚਲਾਓ।**
4. **ਇੱਕ ਕਲਾਇੰਟ ਲਾਗੂ ਕਰੋ ਜੋ ਸੁਨੇਹੇ ਦੇ ਹੈਂਡਲਰ ਰਾਹੀਂ ਆਉਣ ਵਾਲੀਆਂ ਸੂਚਨਾਵਾਂ ਨੂੰ ਦਿਖਾਏ।**

### ਕੋਡ ਦੀ ਸਮਝ

- ਸਰਵਰ async ਫੰਕਸ਼ਨਾਂ ਅਤੇ MCP ਸੰਦਰਭ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪ੍ਰਗਤੀ ਅੱਪਡੇਟ ਭੇਜਦਾ ਹੈ।
- ਕਲਾਇੰਟ async ਸੁਨੇਹਾ ਹੈਂਡਲਰ ਲਾਗੂ ਕਰਦਾ ਹੈ ਜੋ ਸੂਚਨਾਵਾਂ ਅਤੇ ਅੰਤਿਮ ਨਤੀਜੇ ਨੂੰ ਪ੍ਰਿੰਟ ਕਰਦਾ ਹੈ।

### ਸੁਝਾਅ ਅਤੇ ਸਮੱਸਿਆ ਹੱਲ

- ਨਾਨ-ਬਲਾਕਿੰਗ ਓਪਰੇਸ਼ਨਾਂ ਲਈ `async/await` ਦੀ ਵਰਤੋਂ ਕਰੋ।
- ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਦੋਹਾਂ ਵਿੱਚ ਐਕਸਪਸ਼ਨਜ਼ ਦਾ ਧਿਆਨ ਰੱਖੋ ਤਾਂ ਜੋ ਮਜ਼ਬੂਤੀ ਬਣੀ ਰਹੇ।
- ਰੀਅਲ ਟਾਈਮ ਅੱਪਡੇਟ ਦੇਖਣ ਲਈ ਕਈ ਕਲਾਇੰਟਾਂ ਨਾਲ ਟੈਸਟ ਕਰੋ।
- ਜੇ ਕੋਈ ਗਲਤੀ ਆਵੇ, ਤਾਂ ਆਪਣੇ Python ਵਰਜਨ ਨੂੰ ਚੈੱਕ ਕਰੋ ਅਤੇ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਸਾਰੀਆਂ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਇੰਸਟਾਲ ਹਨ।

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।