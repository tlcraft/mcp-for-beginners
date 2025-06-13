<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:02:28+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "no"
}
-->
# Kjøre dette eksempelet

Slik kjører du den klassiske HTTP streaming-serveren og klienten, samt MCP streaming-serveren og klienten ved hjelp av Python.

### Oversikt

- Du setter opp en MCP-server som sender fremdriftsvarsler til klienten mens den behandler elementer.
- Klienten viser hver varsling i sanntid.
- Denne guiden dekker forutsetninger, oppsett, kjøring og feilsøking.

### Forutsetninger

- Python 3.9 eller nyere
- Pakken `mcp` for Python (installer med `pip install mcp`)

### Installasjon og oppsett

1. Klon repositoriet eller last ned løsningsfilene.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Opprett og aktiver et virtuelt miljø (anbefalt):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Installer nødvendige avhengigheter:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Filer

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Klient:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Kjøre den klassiske HTTP streaming-serveren

1. Gå til løsningsmappen:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Start den klassiske HTTP streaming-serveren:

   ```pwsh
   python server.py
   ```

3. Serveren starter og viser:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Kjøre den klassiske HTTP streaming-klienten

1. Åpne et nytt terminalvindu (aktiver samme virtuelle miljø og mappe):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Du vil se strømmede meldinger skrevet ut fortløpende:

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

### Kjøre MCP streaming-serveren

1. Gå til løsningsmappen:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Start MCP-serveren med streamable-http transport:
   ```pwsh
   python server.py mcp
   ```
3. Serveren starter og viser:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Kjøre MCP streaming-klienten

1. Åpne et nytt terminalvindu (aktiver samme virtuelle miljø og mappe):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Du vil se varsler skrevet ut i sanntid mens serveren behandler hvert element:
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

### Viktige implementeringstrinn

1. **Opprett MCP-serveren med FastMCP.**
2. **Definer et verktøy som behandler en liste og sender varsler ved hjelp av `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` for ikke-blokkerende operasjoner.**
- Håndter alltid unntak i både server og klient for robusthet.
- Test med flere klienter for å se sanntidsoppdateringer.
- Hvis du får feil, sjekk Python-versjonen og at alle avhengigheter er installert.

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på det opprinnelige språket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår fra bruk av denne oversettelsen.