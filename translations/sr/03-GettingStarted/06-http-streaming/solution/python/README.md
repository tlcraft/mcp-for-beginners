<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:04:37+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "sr"
}
-->
# Pokretanje ovog primera

Evo kako pokrenuti klasični HTTP streaming server i klijenta, kao i MCP streaming server i klijenta koristeći Python.

### Pregled

- Postavićete MCP server koji šalje notifikacije o napretku klijentu dok obrađuje stavke.
- Klijent će prikazivati svaku notifikaciju u realnom vremenu.
- Ovaj vodič pokriva preduslove, podešavanje, pokretanje i rešavanje problema.

### Preduslovi

- Python 3.9 ili noviji
- `mcp` Python paket (instalirajte pomoću `pip install mcp`)

### Instalacija i podešavanje

1. Klonirajte repozitorijum ili preuzmite fajlove rešenja.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Kreirajte i aktivirajte virtuelno okruženje (preporučeno):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Instalirajte potrebne zavisnosti:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Fajlovi

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Klijent:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Pokretanje klasičnog HTTP streaming servera

1. Idite u direktorijum sa rešenjem:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Pokrenite klasični HTTP streaming server:

   ```pwsh
   python server.py
   ```

3. Server će se pokrenuti i prikazati:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Pokretanje klasičnog HTTP streaming klijenta

1. Otvorite novi terminal (aktivirajte isto virtuelno okruženje i direktorijum):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Trebalo bi da vidite poruke koje se strimuju i štampaju redom:

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

### Pokretanje MCP streaming servera

1. Idite u direktorijum sa rešenjem:  
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```  
2. Pokrenite MCP server sa streamable-http transportom:  
   ```pwsh
   python server.py mcp
   ```  
3. Server će se pokrenuti i prikazati:  
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Pokretanje MCP streaming klijenta

1. Otvorite novi terminal (aktivirajte isto virtuelno okruženje i direktorijum):  
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```  
2. Trebalo bi da vidite notifikacije koje se štampaju u realnom vremenu dok server obrađuje svaku stavku:  
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

### Ključni koraci implementacije

1. **Kreirajte MCP server koristeći FastMCP.**  
2. **Definišite alat koji obrađuje listu i šalje notifikacije koristeći `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` za neblokirajuće operacije.**  
- Uvek obrađujte izuzetke i na serveru i na klijentu radi stabilnosti.  
- Testirajte sa više klijenata da biste videli ažuriranja u realnom vremenu.  
- Ako naiđete na greške, proverite verziju Pythona i uverite se da su sve zavisnosti instalirane.

**Ограничење одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати коначним и званичним извором. За критичне информације препоручује се професионални превод од стране стручног човека. Нисмо одговорни за било какве неспоразуме или погрешна тумачења настала употребом овог превода.