<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "67ecbca6a060477ded3e13ddbeba64f7",
<<<<<<< HEAD
  "translation_date": "2025-08-18T22:39:25+00:00",
=======
  "translation_date": "2025-08-18T17:59:00+00:00",
>>>>>>> origin/main
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "sl"
}
-->
# Zagon tega primera

<<<<<<< HEAD
Tukaj je opisano, kako zagnati klasični HTTP strežnik in odjemalca za pretakanje ter MCP strežnik in odjemalca za pretakanje z uporabo Pythona.
=======
Tukaj je opis, kako zagnati klasični HTTP strežniški in odjemalski tok ter MCP strežniški in odjemalski tok z uporabo Pythona.
>>>>>>> origin/main

### Pregled

- Nastavili boste MCP strežnik, ki med obdelavo elementov pošilja obvestila o napredku odjemalcu.
<<<<<<< HEAD
- Odjemalec bo vsako obvestilo prikazal v realnem času.
=======
- Odjemalec bo prikazoval vsako obvestilo v realnem času.
>>>>>>> origin/main
- Ta vodič zajema predpogoje, nastavitev, zagon in odpravljanje težav.

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
   pip install "mcp[cli]" fastapi requests
   ```

### Datoteke

- **Strežnik:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Odjemalec:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

<<<<<<< HEAD
### Zagon klasičnega HTTP strežnika za pretakanje

1. Pojdite v mapo z rešitvijo:
=======
### Zagon klasičnega HTTP strežniškega toka

1. Pomaknite se v mapo z rešitvijo:
>>>>>>> origin/main

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

<<<<<<< HEAD
2. Zaženite klasični HTTP strežnik za pretakanje:
=======
2. Zaženite klasični HTTP strežniški tok:
>>>>>>> origin/main

   ```pwsh
   python server.py
   ```

3. Strežnik se bo zagnal in prikazal:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

<<<<<<< HEAD
### Zagon klasičnega HTTP odjemalca za pretakanje
=======
### Zagon klasičnega HTTP odjemalskega toka
>>>>>>> origin/main

1. Odprite nov terminal (aktivirajte isto virtualno okolje in mapo):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

<<<<<<< HEAD
2. Videli boste zaporedno natisnjena sporočila:
=======
2. Videli boste zaporedno natisnjena sporočila toka:
>>>>>>> origin/main

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

<<<<<<< HEAD
### Zagon MCP strežnika za pretakanje

1. Pojdite v mapo z rešitvijo:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Zaženite MCP strežnik z uporabo transporta "streamable-http":
=======
### Zagon MCP strežniškega toka

1. Pomaknite se v mapo z rešitvijo:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Zaženite MCP strežnik z uporabo transporta streamable-http:
>>>>>>> origin/main
   ```pwsh
   python server.py mcp
   ```
3. Strežnik se bo zagnal in prikazal:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

<<<<<<< HEAD
### Zagon MCP odjemalca za pretakanje
=======
### Zagon MCP odjemalskega toka
>>>>>>> origin/main

1. Odprite nov terminal (aktivirajte isto virtualno okolje in mapo):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Videli boste obvestila, natisnjena v realnem času, ko strežnik obdeluje vsak element:
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
2. **Definirajte orodje, ki obdeluje seznam in pošilja obvestila z uporabo `ctx.info()` ali `ctx.log()`.**
3. **Zaženite strežnik z `transport="streamable-http"`.**
4. **Implementirajte odjemalca z obdelovalcem sporočil za prikaz obvestil ob njihovem prihodu.**

### Pregled kode
<<<<<<< HEAD
- Strežnik uporablja asinhrone funkcije in MCP kontekst za pošiljanje posodobitev o napredku.
=======
- Strežnik uporablja asinhrone funkcije in MCP kontekst za pošiljanje posodobitev napredka.
>>>>>>> origin/main
- Odjemalec implementira asinhroni obdelovalec sporočil za tiskanje obvestil in končnega rezultata.

### Nasveti in odpravljanje težav

- Uporabljajte `async/await` za neblokirajoče operacije.
- Vedno obravnavajte izjeme tako na strežniku kot na odjemalcu za večjo zanesljivost.
- Testirajte z več odjemalci, da opazujete posodobitve v realnem času.
- Če naletite na napake, preverite svojo različico Pythona in zagotovite, da so vse odvisnosti nameščene.

<<<<<<< HEAD
**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovni prevod s strani človeškega prevajalca. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.
=======
**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo strokovno človeško prevajanje. Ne prevzemamo odgovornosti za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.
>>>>>>> origin/main
