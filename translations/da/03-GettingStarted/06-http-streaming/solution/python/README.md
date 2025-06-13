<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:02:20+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "da"
}
-->
# Kør dette eksempel

Her er, hvordan du kører den klassiske HTTP streaming-server og klient samt MCP streaming-server og klient ved hjælp af Python.

### Oversigt

- Du opsætter en MCP-server, der streamer statusmeddelelser til klienten, mens den behandler elementer.
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

1. **Opret og aktivér et virtuelt miljø (anbefales):**

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

### Kørsel af den klassiske HTTP streaming-server

1. Gå til løsningsmappen:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Start den klassiske HTTP streaming-server:

   ```pwsh
   python server.py
   ```

3. Serveren starter og viser:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Kørsel af den klassiske HTTP streaming-klient

1. Åbn en ny terminal (aktivér samme virtuelle miljø og mappe):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Du skulle nu se streamede beskeder blive vist løbende:

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

### Kørsel af MCP streaming-serveren

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

### Kørsel af MCP streaming-klienten

1. Åbn en ny terminal (aktivér samme virtuelle miljø og mappe):  
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```  
2. Du skulle se notifikationer blive vist i realtid, mens serveren behandler hvert element:  
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

1. **Opret MCP-serveren med FastMCP.**  
2. **Definér et værktøj, der behandler en liste og sender notifikationer ved hjælp af `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` for ikke-blokerende operationer.**  
- Håndtér altid undtagelser både i server og klient for robusthed.  
- Test med flere klienter for at se opdateringer i realtid.  
- Hvis du støder på fejl, tjek din Python-version og sørg for, at alle afhængigheder er installeret.

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets modersmål bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.