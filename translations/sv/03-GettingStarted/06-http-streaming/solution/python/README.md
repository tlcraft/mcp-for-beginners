<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:20:12+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "sv"
}
-->
# Köra detta exempel

Så här kör du den klassiska HTTP-streamingservern och klienten, samt MCP-streamingservern och klienten med Python.

### Översikt

- Du kommer att sätta upp en MCP-server som strömmar progressnotiser till klienten medan den bearbetar objekt.
- Klienten visar varje notis i realtid.
- Denna guide täcker förutsättningar, installation, körning och felsökning.

### Förutsättningar

- Python 3.9 eller nyare
- Pythonpaketet `mcp` (installera med `pip install mcp`)

### Installation & Uppstart

1. Klona repot eller ladda ner lösningsfilerna.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Skapa och aktivera en virtuell miljö (rekommenderas):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Installera nödvändiga beroenden:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Filer

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Klient:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Köra den klassiska HTTP-streamingservern

1. Gå till lösningsmappen:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Starta den klassiska HTTP-streamingservern:

   ```pwsh
   python server.py
   ```

3. Servern startar och visar:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Köra den klassiska HTTP-streamingklienten

1. Öppna en ny terminal (aktivera samma virtuella miljö och mapp):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Du bör se strömmade meddelanden skrivas ut i följd:

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

### Köra MCP-streamingservern

1. Gå till lösningsmappen:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Starta MCP-servern med transporten streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Servern startar och visar:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Köra MCP-streamingklienten

1. Öppna en ny terminal (aktivera samma virtuella miljö och mapp):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Du bör se notiser skrivas ut i realtid medan servern bearbetar varje objekt:
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

### Viktiga implementeringssteg

1. **Skapa MCP-servern med FastMCP.**
2. **Definiera ett verktyg som bearbetar en lista och skickar notiser med `ctx.info()` eller `ctx.log()`.**
3. **Kör servern med `transport="streamable-http"`.**
4. **Implementera en klient med en meddelandehanterare som visar notiser när de kommer.**

### Genomgång av koden
- Servern använder asynkrona funktioner och MCP-konteksten för att skicka progressuppdateringar.
- Klienten implementerar en asynkron meddelandehanterare som skriver ut notiser och slutresultatet.

### Tips & Felsökning

- Använd `async/await` för icke-blockerande operationer.
- Hantera alltid undantag i både server och klient för stabilitet.
- Testa med flera klienter för att se realtidsuppdateringar.
- Om du stöter på fel, kontrollera din Python-version och att alla beroenden är installerade.

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.