<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:22:51+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "hr"
}
-->
# Pokretanje ovog primjera

Evo kako pokrenuti klasični HTTP streaming server i klijent, kao i MCP streaming server i klijent koristeći Python.

### Pregled

- Postavit ćete MCP server koji šalje obavijesti o napretku klijentu dok obrađuje stavke.
- Klijent će prikazivati svaku obavijest u stvarnom vremenu.
- Ovaj vodič obuhvaća preduvjete, postavljanje, pokretanje i rješavanje problema.

### Preduvjeti

- Python 3.9 ili noviji
- `mcp` Python paket (instalirajte s `pip install mcp`)

### Instalacija i postavljanje

1. Klonirajte repozitorij ili preuzmite datoteke rješenja.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Kreirajte i aktivirajte virtualno okruženje (preporučeno):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Instalirajte potrebne ovisnosti:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Datoteke

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Klijent:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Pokretanje klasičnog HTTP streaming servera

1. Idite u direktorij rješenja:

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

1. Otvorite novi terminal (aktivirajte isto virtualno okruženje i direktorij):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Trebali biste vidjeti poruke koje se ispisuju redom:

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

1. Idite u direktorij rješenja:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Pokrenite MCP server s transportom streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Server će se pokrenuti i prikazati:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Pokretanje MCP streaming klijenta

1. Otvorite novi terminal (aktivirajte isto virtualno okruženje i direktorij):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Trebali biste vidjeti obavijesti ispisane u stvarnom vremenu dok server obrađuje svaku stavku:
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
2. **Definirajte alat koji obrađuje listu i šalje obavijesti koristeći `ctx.info()` ili `ctx.log()`.**
3. **Pokrenite server s `transport="streamable-http"`.**
4. **Implementirajte klijenta s handlerom poruka koji prikazuje obavijesti čim stignu.**

### Pregled koda
- Server koristi async funkcije i MCP kontekst za slanje ažuriranja napretka.
- Klijent implementira async handler poruka za ispis obavijesti i konačnog rezultata.

### Savjeti i rješavanje problema

- Koristite `async/await` za neblokirajuće operacije.
- Uvijek hvatajte iznimke i na serveru i na klijentu radi stabilnosti.
- Testirajte s više klijenata kako biste vidjeli ažuriranja u stvarnom vremenu.
- Ako naiđete na greške, provjerite verziju Pythona i jesu li sve ovisnosti instalirane.

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.