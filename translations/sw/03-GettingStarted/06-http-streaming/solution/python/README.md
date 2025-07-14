<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:21:43+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

Hapa kuna jinsi ya kuendesha seva ya kawaida ya HTTP streaming na mteja, pamoja na seva na mteja wa MCP streaming kwa kutumia Python.

### Muhtasari

- Utaanzisha seva ya MCP inayotuma taarifa za maendeleo kwa mteja wakati inashughulikia vitu.
- Mteja ataonyesha kila taarifa kwa wakati halisi.
- Mwongozo huu unahusu mahitaji ya awali, usanidi, kuendesha, na utatuzi wa matatizo.

### Mahitaji ya Awali

- Python 3.9 au toleo jipya zaidi
- Kifurushi cha Python `mcp` (weka kwa kutumia `pip install mcp`)

### Usanidi na Ufungaji

1. Nakili hifadhidata au pakua faili za suluhisho.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Tengeneza na wezesha mazingira ya virtual (inapendekezwa):**

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

- **Seva:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Mteja:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Kuendesha Seva ya Kawaida ya HTTP Streaming

1. Nenda kwenye saraka ya suluhisho:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Anzisha seva ya kawaida ya HTTP streaming:

   ```pwsh
   python server.py
   ```

3. Seva itaanza na kuonyesha:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Kuendesha Mteja wa Kawaida wa HTTP Streaming

1. Fungua terminal mpya (wezeshaji mazingira ya virtual na saraka ile ile):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Unapaswa kuona ujumbe unaotiririka ukichapishwa mfululizo:

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

### Kuendesha Seva ya MCP Streaming

1. Nenda kwenye saraka ya suluhisho:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Anzisha seva ya MCP kwa kutumia usafirishaji wa streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Seva itaanza na kuonyesha:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Kuendesha Mteja wa MCP Streaming

1. Fungua terminal mpya (wezeshaji mazingira ya virtual na saraka ile ile):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Unapaswa kuona taarifa zikichapishwa kwa wakati halisi wakati seva inashughulikia kila kipengee:
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

1. **Tengeneza seva ya MCP kwa kutumia FastMCP.**
2. **Fafanua chombo kinachoshughulikia orodha na kutuma taarifa kwa kutumia `ctx.info()` au `ctx.log()`.**
3. **Endesha seva kwa kutumia `transport="streamable-http"`.**
4. **Tekeleza mteja mwenye mshughulikiaji wa ujumbe kuonyesha taarifa zinapofika.**

### Maelezo ya Msimbo
- Seva hutumia kazi za async na muktadha wa MCP kutuma taarifa za maendeleo.
- Mteja hutekeleza mshughulikiaji wa ujumbe wa async kuchapisha taarifa na matokeo ya mwisho.

### Vidokezo na Utatuzi wa Matatizo

- Tumia `async/await` kwa shughuli zisizozuia.
- Daima shughulikia makosa katika seva na mteja kwa ajili ya uimara.
- Jaribu na wateja wengi kuona masasisho ya wakati halisi.
- Ikiwa unakutana na makosa, hakikisha toleo la Python ni sahihi na utegemezi wote umewekwa.

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.