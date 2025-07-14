<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:23:00+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "sl"
}
-->
# Zagon tega primera

Tukaj je opisano, kako zagnati klasični HTTP streaming strežnik in odjemalca ter MCP streaming strežnik in odjemalca z uporabo Pythona.

### Pregled

- Nastavili boste MCP strežnik, ki stranki pošilja obvestila o napredku med obdelavo elementov.
- Odjemalec bo v realnem času prikazoval vsako obvestilo.
- Ta vodič zajema predpogoje, namestitev, zagon in odpravljanje težav.

### Predpogoji

- Python 3.9 ali novejši
- Python paket `mcp` (namestite z `pip install mcp`)

### Namestitev in nastavitev

1. Klonirajte repozitorij ali prenesite datoteke rešitve.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Ustvarite in aktivirajte virtualno okolje (priporočeno):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Namestite potrebne odvisnosti:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Datoteke

- **Strežnik:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Odjemalec:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Zagon klasičnega HTTP streaming strežnika

1. Pomaknite se v imenik rešitve:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Zaženite klasični HTTP streaming strežnik:

   ```pwsh
   python server.py
   ```

3. Strežnik se bo zagnal in prikazal:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Zagon klasičnega HTTP streaming odjemalca

1. Odprite nov terminal (aktivirajte isto virtualno okolje in imenik):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Videli boste zaporedno izpisana sporočila:

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

### Zagon MCP streaming strežnika

1. Pomaknite se v imenik rešitve:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Zaženite MCP strežnik s transportom streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Strežnik se bo zagnal in prikazal:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Zagon MCP streaming odjemalca

1. Odprite nov terminal (aktivirajte isto virtualno okolje in imenik):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. V realnem času boste videli obvestila, ko strežnik obdela vsak element:
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

### Ključni koraki implementacije

1. **Ustvarite MCP strežnik z uporabo FastMCP.**
2. **Določite orodje, ki obdela seznam in pošilja obvestila z `ctx.info()` ali `ctx.log()`.**
3. **Zaženite strežnik z `transport="streamable-http"`.**
4. **Implementirajte odjemalca z upravljalcem sporočil, ki prikazuje obvestila takoj, ko prispejo.**

### Pregled kode
- Strežnik uporablja asinhrone funkcije in MCP kontekst za pošiljanje posodobitev napredka.
- Odjemalec implementira asinhroni upravljalec sporočil za izpis obvestil in končnega rezultata.

### Nasveti in odpravljanje težav

- Uporabljajte `async/await` za neblokirajoče operacije.
- Vedno obravnavajte izjeme tako na strežniku kot na odjemalcu za večjo zanesljivost.
- Preizkusite z več odjemalci, da opazujete posodobitve v realnem času.
- Če naletite na napake, preverite različico Pythona in zagotovite, da so vse odvisnosti nameščene.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.