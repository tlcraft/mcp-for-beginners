<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:20:49+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "nl"
}
-->
# Dit voorbeeld uitvoeren

Hier lees je hoe je de klassieke HTTP streaming server en client, evenals de MCP streaming server en client, kunt draaien met Python.

### Overzicht

- Je zet een MCP-server op die voortgangsnotificaties naar de client streamt terwijl deze items verwerkt.
- De client toont elke notificatie in realtime.
- Deze gids behandelt de vereisten, installatie, uitvoering en probleemoplossing.

### Vereisten

- Python 3.9 of nieuwer
- Het `mcp` Python-pakket (te installeren met `pip install mcp`)

### Installatie & Setup

1. Clone de repository of download de oplossingbestanden.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Maak en activeer een virtuele omgeving (aanbevolen):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Installeer de benodigde dependencies:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Bestanden

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### De klassieke HTTP streaming server draaien

1. Navigeer naar de map met de oplossing:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Start de klassieke HTTP streaming server:

   ```pwsh
   python server.py
   ```

3. De server start en toont:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### De klassieke HTTP streaming client draaien

1. Open een nieuwe terminal (activeer dezelfde virtuele omgeving en map):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Je ziet de gestreamde berichten achter elkaar verschijnen:

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

### De MCP streaming server draaien

1. Navigeer naar de map met de oplossing:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Start de MCP-server met de streamable-http transport:
   ```pwsh
   python server.py mcp
   ```
3. De server start en toont:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### De MCP streaming client draaien

1. Open een nieuwe terminal (activeer dezelfde virtuele omgeving en map):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Je ziet notificaties in realtime verschijnen terwijl de server elk item verwerkt:
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

### Belangrijkste implementatiestappen

1. **Maak de MCP-server aan met FastMCP.**
2. **Definieer een tool die een lijst verwerkt en notificaties verstuurt met `ctx.info()` of `ctx.log()`.**
3. **Draai de server met `transport="streamable-http"`.**
4. **Implementeer een client met een message handler die notificaties toont zodra ze binnenkomen.**

### Code-uitleg
- De server gebruikt async functies en de MCP context om voortgangsupdates te versturen.
- De client implementeert een async message handler om notificaties en het eindresultaat te printen.

### Tips & probleemoplossing

- Gebruik `async/await` voor niet-blokkerende operaties.
- Zorg dat je altijd exceptions afvangt in zowel server als client voor stabiliteit.
- Test met meerdere clients om realtime updates te zien.
- Kom je fouten tegen? Controleer je Python-versie en of alle dependencies geïnstalleerd zijn.

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.