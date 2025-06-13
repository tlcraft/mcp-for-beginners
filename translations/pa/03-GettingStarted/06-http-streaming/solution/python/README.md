<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:01:02+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਨਮੂਨੇ ਨੂੰ ਚਲਾਉਣਾ

ਇੱਥੇ ਦਿੱਤਾ ਗਿਆ ਹੈ ਕਿ ਕਿਵੇਂ ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਨੂੰ, ਨਾਲ ਹੀ MCP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਨੂੰ Python ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਚਲਾਇਆ ਜਾ ਸਕਦਾ ਹੈ।

### ਝਲਕ

- ਤੁਸੀਂ ਇੱਕ MCP ਸਰਵਰ ਸੈੱਟਅਪ ਕਰੋਗੇ ਜੋ ਆਈਟਮਾਂ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰਦੇ ਸਮੇਂ ਪ੍ਰਗਤੀ ਸੂਚਨਾਵਾਂ ਕਲਾਇੰਟ ਨੂੰ ਸਟ੍ਰੀਮ ਕਰਦਾ ਹੈ।
- ਕਲਾਇੰਟ ਹਰ ਸੂਚਨਾ ਨੂੰ ਅਸਲੀ ਸਮੇਂ ਵਿੱਚ ਦਿਖਾਏਗਾ।
- ਇਹ ਗਾਈਡ ਪਹਿਲਾਂ ਦੀਆਂ ਲੋੜਾਂ, ਸੈੱਟਅਪ, ਚਲਾਉਣਾ ਅਤੇ ਸਮੱਸਿਆ ਹੱਲ ਕਰਨ ਬਾਰੇ ਹੈ।

### ਪਹਿਲਾਂ ਦੀਆਂ ਲੋੜਾਂ

- Python 3.9 ਜਾਂ ਇਸ ਤੋਂ ਨਵਾਂ ਵਰਜਨ
- `mcp` Python ਪੈਕੇਜ (ਇੰਸਟਾਲ ਕਰਨ ਲਈ `pip install mcp` ਵਰਤੋ)

### ਇੰਸਟਾਲੇਸ਼ਨ ਅਤੇ ਸੈੱਟਅਪ

1. ਰਿਪੋਜ਼ਟਰੀ ਕਲੋਨ ਕਰੋ ਜਾਂ ਸਾਲੂਸ਼ਨ ਫਾਈਲਾਂ ਡਾਊਨਲੋਡ ਕਰੋ।

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **ਇੱਕ ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਬਣਾਓ ਅਤੇ ਐਕਟੀਵੇਟ ਕਰੋ (ਸਿਫਾਰਸ਼ੀ):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **ਲੋੜੀਂਦੇ ਡਿਪੈਂਡੇਨਸੀਜ਼ ਇੰਸਟਾਲ ਕਰੋ:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### ਫਾਈਲਾਂ

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਚਲਾਉਣਾ

1. ਸਾਲੂਸ਼ਨ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਜਾਓ:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਸ਼ੁਰੂ ਕਰੋ:

   ```pwsh
   python server.py
   ```

3. ਸਰਵਰ ਚਲਣ ਲੱਗੇਗਾ ਅਤੇ ਇਹ ਦਰਸਾਏਗਾ:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਕਲਾਇੰਟ ਚਲਾਉਣਾ

1. ਨਵਾਂ ਟਰਮੀਨਲ ਖੋਲ੍ਹੋ (ਉਹੀ ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਅਤੇ ਡਾਇਰੈਕਟਰੀ ਐਕਟੀਵੇਟ ਕਰੋ):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. ਤੁਸੀਂ ਸਟ੍ਰੀਮ ਕੀਤੀਆਂ ਗਈਆਂ ਮੈਸੇਜਾਂ ਨੂੰ ਕ੍ਰਮਵਾਰ ਪ੍ਰਿੰਟ ਹੁੰਦੇ ਵੇਖੋਗੇ:

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

1. ਸਾਲੂਸ਼ਨ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਜਾਓ:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. streamable-http ਟਰਾਂਸਪੋਰਟ ਨਾਲ MCP ਸਰਵਰ ਸ਼ੁਰੂ ਕਰੋ:
   ```pwsh
   python server.py mcp
   ```
3. ਸਰਵਰ ਚਲਣ ਲੱਗੇਗਾ ਅਤੇ ਇਹ ਦਰਸਾਏਗਾ:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP ਸਟ੍ਰੀਮਿੰਗ ਕਲਾਇੰਟ ਚਲਾਉਣਾ

1. ਨਵਾਂ ਟਰਮੀਨਲ ਖੋਲ੍ਹੋ (ਉਹੀ ਵਰਚੁਅਲ ਵਾਤਾਵਰਣ ਅਤੇ ਡਾਇਰੈਕਟਰੀ ਐਕਟੀਵੇਟ ਕਰੋ):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. ਤੁਸੀਂ ਅਸਲੀ ਸਮੇਂ ਵਿੱਚ ਸੂਚਨਾਵਾਂ ਪ੍ਰਿੰਟ ਹੁੰਦੀਆਂ ਵੇਖੋਗੇ ਜਿਵੇਂ ਸਰਵਰ ਹਰ ਆਈਟਮ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰਦਾ ਹੈ:
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

### ਮੁੱਖ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਕਦਮ

1. **FastMCP ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰ ਬਣਾਓ।**
2. **ਇੱਕ ਟੂਲ ਪਰਿਭਾਸ਼ਿਤ ਕਰੋ ਜੋ ਲਿਸਟ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰਦਾ ਹੈ ਅਤੇ `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸੂਚਨਾਵਾਂ ਭੇਜਦਾ ਹੈ, ਤਾਂ ਜੋ ਨਾਨ-ਬਲਾਕਿੰਗ ਆਪਰੇਸ਼ਨ ਹੋ ਸਕਣ।**
- ਹਮੇਸ਼ਾਂ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਦੋਹਾਂ ਵਿੱਚ ਐਕਸਪਸ਼ਨ ਨੂੰ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਹੈਂਡਲ ਕਰੋ ਤਾਂ ਜੋ ਮਜ਼ਬੂਤੀ ਬਣੀ ਰਹੇ।
- ਅਸਲੀ ਸਮੇਂ ਅਪਡੇਟ ਦੇਖਣ ਲਈ ਕਈ ਕਲਾਇੰਟਾਂ ਨਾਲ ਟੈਸਟ ਕਰੋ।
- ਜੇ ਕੋਈ ਗਲਤੀ ਆਏ, ਤਾਂ ਆਪਣਾ Python ਵਰਜਨ ਚੈੱਕ ਕਰੋ ਅਤੇ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਸਾਰੀਆਂ ਡਿਪੈਂਡੇਨਸੀਜ਼ ਇੰਸਟਾਲ ਹਨ।

**ਅਸਵੀਕਾਰੋ ਕਿਹਾ ਗਿਆ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਹੀਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਅਧਿਕਾਰਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।