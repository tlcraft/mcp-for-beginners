<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:01:28+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "it"
}
-->
# Esecuzione di questo esempio

Ecco come eseguire il server e il client di streaming HTTP classico, così come il server e il client di streaming MCP utilizzando Python.

### Panoramica

- Configurerai un server MCP che invia notifiche di avanzamento al client mentre elabora gli elementi.
- Il client mostrerà ogni notifica in tempo reale.
- Questa guida copre i prerequisiti, la configurazione, l’esecuzione e la risoluzione dei problemi.

### Prerequisiti

- Python 3.9 o superiore
- Il pacchetto Python `mcp` (installabile con `pip install mcp`)

### Installazione e Configurazione

1. Clona il repository o scarica i file della soluzione.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Crea e attiva un ambiente virtuale (consigliato):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Installa le dipendenze necessarie:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### File

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Esecuzione del server di streaming HTTP classico

1. Vai nella cartella della soluzione:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Avvia il server di streaming HTTP classico:

   ```pwsh
   python server.py
   ```

3. Il server partirà e mostrerà:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Esecuzione del client di streaming HTTP classico

1. Apri un nuovo terminale (attiva lo stesso ambiente virtuale e la stessa cartella):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Vedrai i messaggi in streaming stampati uno dopo l’altro:

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

### Esecuzione del server di streaming MCP

1. Vai nella cartella della soluzione:  
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```  
2. Avvia il server MCP con il trasporto streamable-http:  
   ```pwsh
   python server.py mcp
   ```  
3. Il server partirà e mostrerà:  
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Esecuzione del client di streaming MCP

1. Apri un nuovo terminale (attiva lo stesso ambiente virtuale e la stessa cartella):  
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```  
2. Vedrai le notifiche stampate in tempo reale mentre il server elabora ogni elemento:  
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

### Passaggi chiave nell’implementazione

1. **Crea il server MCP usando FastMCP.**  
2. **Definisci uno strumento che elabora una lista e invia notifiche usando `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` per operazioni non bloccanti.**  
- Gestisci sempre le eccezioni sia nel server che nel client per garantire robustezza.  
- Testa con più client per osservare gli aggiornamenti in tempo reale.  
- Se incontri errori, verifica la versione di Python e assicurati che tutte le dipendenze siano installate.

**Dichiarazione di esclusione di responsabilità**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di considerare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali incomprensioni o interpretazioni errate derivanti dall’uso di questa traduzione.