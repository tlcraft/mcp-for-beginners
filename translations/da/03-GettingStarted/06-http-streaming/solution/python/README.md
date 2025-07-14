<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:20:23+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "da"
}
-->
# Kørsel af dette eksempel

Her er hvordan du kører den klassiske HTTP streaming server og klient, samt MCP streaming server og klient ved hjælp af Python.

### Oversigt

- Du opsætter en MCP server, der streamer statusmeddelelser til klienten, mens den behandler elementer.
- Klienten viser hver meddelelse i realtid.
- Denne vejledning dækker forudsætninger, opsætning, kørsel og fejlfinding.

### Forudsætninger

- Python 3.9 eller nyere
- `mcp` Python-pakken (installer med `pip install mcp`)

### Installation & Opsætning

1. Klon repository eller download løsningsfilerne.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Opret og aktiver et virtuelt miljø (anbefales):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Installer nødvendige afhængigheder:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Filer

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Klient:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Kørsel af den klassiske HTTP streaming server

1. Gå til løsningsmappen:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Start den klassiske HTTP streaming server:

   ```pwsh
   python server.py
   ```

3. Serveren starter og viser:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Kørsel af den klassiske HTTP streaming klient

1. Åbn et nyt terminalvindue (aktiver samme virtuelle miljø og mappe):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Du vil se streamede beskeder blive vist sekventielt:

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

### Kørsel af MCP streaming server

1. Gå til løsningsmappen:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Start MCP serveren med streamable-http transport:
   ```pwsh
   python server.py mcp
   ```
3. Serveren starter og viser:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Kørsel af MCP streaming klient

1. Åbn et nyt terminalvindue (aktiver samme virtuelle miljø og mappe):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Du vil se notifikationer blive vist i realtid, mens serveren behandler hvert element:
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

### Vigtige implementeringstrin

1. **Opret MCP serveren med FastMCP.**
2. **Definer et værktøj, der behandler en liste og sender notifikationer med `ctx.info()` eller `ctx.log()`.**
3. **Kør serveren med `transport="streamable-http"`.**
4. **Implementer en klient med en beskedhandler, der viser notifikationer, efterhånden som de modtages.**

### Gennemgang af koden
- Serveren bruger async-funktioner og MCP konteksten til at sende statusopdateringer.
- Klienten implementerer en async beskedhandler, der printer notifikationer og det endelige resultat.

### Tips & Fejlfinding

- Brug `async/await` for ikke-blokerende operationer.
- Håndter altid undtagelser i både server og klient for stabilitet.
- Test med flere klienter for at se opdateringer i realtid.
- Hvis du støder på fejl, tjek din Python-version og sørg for, at alle afhængigheder er installeret.

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.