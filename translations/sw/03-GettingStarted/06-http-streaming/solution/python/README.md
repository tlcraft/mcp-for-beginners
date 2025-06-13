<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:03:37+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "sw"
}
-->
# Kuendesha mfano huu

Hapa kuna jinsi ya kuendesha server na client wa classic HTTP streaming, pamoja na server na client wa MCP streaming kwa kutumia Python.

### Muhtasari

- Utaunda server ya MCP inayotuma arifa za maendeleo kwa client wakati inashughulikia vitu.
- Client itaonyesha kila arifa kwa wakati halisi.
- Mwongozo huu unajumuisha mahitaji, usanidi, kuendesha, na utatuzi wa matatizo.

### Mahitaji

- Python 3.9 au toleo jipya zaidi
- Kifurushi cha Python `mcp` (weka kwa kutumia `pip install mcp`)

### Usanidi & Ufungaji

1. Nakili repository au pakua faili za suluhisho.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Tengeneza na wezesha virtual environment (inapendekezwa):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Sakinisha utegemezi unaohitajika:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Faili

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Kuendesha Classic HTTP Streaming Server

1. Nenda kwenye saraka ya suluhisho:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Anzisha classic HTTP streaming server:

   ```pwsh
   python server.py
   ```

3. Server itaanzishwa na kuonyesha:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Kuendesha Classic HTTP Streaming Client

1. Fungua terminal mpya (wezeshaji virtual environment na saraka sawa):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Utapata ujumbe uliotumwa ukiandikwa mfululizo:

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

### Kuendesha MCP Streaming Server

1. Nenda kwenye saraka ya suluhisho:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Anzisha MCP server kwa kutumia usafirishaji wa streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Server itaanzishwa na kuonyesha:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Kuendesha MCP Streaming Client

1. Fungua terminal mpya (wezeshaji virtual environment na saraka sawa):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Utapata arifa zikichapishwa kwa wakati halisi wakati server inashughulikia kila kipengee:
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

### Hatua Muhimu za Utekelezaji

1. **Tengeneza MCP server ukitumia FastMCP.**
2. **Fafanua zana inayoshughulikia orodha na kutuma arifa kwa kutumia `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` kwa operesheni zisizozuia.
- Daima shughulikia makosa katika server na client kwa ajili ya uimara.
- Jaribu na wateja wengi kuona masasisho ya wakati halisi.
- Ukikumbana na makosa, hakikisha toleo la Python ni sahihi na utegemezi wote umewekwa.

**Kiasi cha majibu**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuwa sahihi, tafadhali fahamu kuwa tafsiri za moja kwa moja zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatuna dhamana kwa maelewano au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.