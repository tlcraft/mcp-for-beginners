<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:21:35+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng sample na ito

Narito kung paano patakbuhin ang klasikong HTTP streaming server at client, pati na rin ang MCP streaming server at client gamit ang Python.

### Pangkalahatang-ideya

- Magse-set up ka ng MCP server na mag-stream ng mga notification ng progreso sa client habang pinoproseso nito ang mga item.
- Ipapakita ng client ang bawat notification nang real time.
- Saklaw ng gabay na ito ang mga kinakailangan, setup, pagpapatakbo, at pag-troubleshoot.

### Mga Kinakailangan

- Python 3.9 o mas bago
- Ang `mcp` Python package (i-install gamit ang `pip install mcp`)

### Pag-install at Setup

1. I-clone ang repositoryo o i-download ang mga solution files.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Gumawa at i-activate ang virtual environment (inirerekomenda):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **I-install ang mga kinakailangang dependencies:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Mga File

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Pagpapatakbo ng Klasikong HTTP Streaming Server

1. Pumunta sa solution directory:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Simulan ang klasikong HTTP streaming server:

   ```pwsh
   python server.py
   ```

3. Magsisimula ang server at ipapakita:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Pagpapatakbo ng Klasikong HTTP Streaming Client

1. Magbukas ng bagong terminal (i-activate ang parehong virtual environment at directory):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Makikita mo ang mga streamed messages na naka-print nang sunud-sunod:

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

### Pagpapatakbo ng MCP Streaming Server

1. Pumunta sa solution directory:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Simulan ang MCP server gamit ang streamable-http transport:
   ```pwsh
   python server.py mcp
   ```
3. Magsisimula ang server at ipapakita:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Pagpapatakbo ng MCP Streaming Client

1. Magbukas ng bagong terminal (i-activate ang parehong virtual environment at directory):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Makikita mo ang mga notification na naka-print nang real time habang pinoproseso ng server ang bawat item:
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

### Pangunahing Hakbang sa Implementasyon

1. **Gumawa ng MCP server gamit ang FastMCP.**
2. **Mag-define ng tool na nagpoproseso ng listahan at nagpapadala ng mga notification gamit ang `ctx.info()` o `ctx.log()`.**
3. **Patakbuhin ang server gamit ang `transport="streamable-http"`.**
4. **Mag-implement ng client na may message handler para ipakita ang mga notification habang dumarating.**

### Pagsusuri ng Code
- Gumagamit ang server ng async functions at MCP context para magpadala ng mga update sa progreso.
- Nag-implement ang client ng async message handler para i-print ang mga notification at ang panghuling resulta.

### Mga Tip at Pag-troubleshoot

- Gamitin ang `async/await` para sa mga non-blocking na operasyon.
- Laging i-handle ang mga exceptions sa parehong server at client para sa mas matibay na sistema.
- Subukan gamit ang maraming client para makita ang mga real-time na update.
- Kung makaranas ng mga error, suriin ang bersyon ng Python at tiyaking naka-install lahat ng dependencies.

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.