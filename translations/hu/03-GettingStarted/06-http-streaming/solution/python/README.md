<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:21:52+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

Így futtathatod a klasszikus HTTP streaming szervert és klienst, valamint az MCP streaming szervert és klienst Python használatával.

### Áttekintés

- Beállítasz egy MCP szervert, amely feldolgozás közben értesítéseket küld a kliensnek.
- A kliens valós időben megjeleníti az értesítéseket.
- Ez az útmutató a követelményeket, beállítást, futtatást és hibakeresést tárgyalja.

### Előfeltételek

- Python 3.9 vagy újabb
- Az `mcp` Python csomag (telepíthető a `pip install mcp` paranccsal)

### Telepítés és beállítás

1. Klónozd a repót vagy töltsd le a megoldás fájljait.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Hozz létre és aktiválj egy virtuális környezetet (ajánlott):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Telepítsd a szükséges függőségeket:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Fájlok

- **Szerver:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Kliens:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### A klasszikus HTTP streaming szerver futtatása

1. Navigálj a megoldás könyvtárába:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Indítsd el a klasszikus HTTP streaming szervert:

   ```pwsh
   python server.py
   ```

3. A szerver elindul és megjeleníti:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### A klasszikus HTTP streaming kliens futtatása

1. Nyiss egy új terminált (aktiváld ugyanazt a virtuális környezetet és könyvtárat):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. A folyamatosan érkező üzeneteket sorban látni fogod:

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

### Az MCP streaming szerver futtatása

1. Navigálj a megoldás könyvtárába:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Indítsd el az MCP szervert a streamable-http transzporttal:
   ```pwsh
   python server.py mcp
   ```
3. A szerver elindul és megjeleníti:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Az MCP streaming kliens futtatása

1. Nyiss egy új terminált (aktiváld ugyanazt a virtuális környezetet és könyvtárat):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Valós időben látni fogod az értesítéseket, ahogy a szerver feldolgozza az elemeket:
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

### Fontos megvalósítási lépések

1. **Hozd létre az MCP szervert FastMCP segítségével.**
2. **Határozz meg egy eszközt, amely egy listát dolgoz fel és értesítéseket küld `ctx.info()` vagy `ctx.log()` használatával.**
3. **Futtasd a szervert `transport="streamable-http"` beállítással.**
4. **Valósíts meg egy klienst, amely egy üzenetkezelővel jeleníti meg az értesítéseket, amint megérkeznek.**

### Kód áttekintése
- A szerver aszinkron függvényeket és az MCP kontextust használja a folyamat állapotának küldésére.
- A kliens egy aszinkron üzenetkezelőt valósít meg, amely kiírja az értesítéseket és a végső eredményt.

### Tippek és hibakeresés

- Használj `async/await` a nem blokkoló műveletekhez.
- Mind a szerveren, mind a kliensen kezelj kivételeket a stabilitás érdekében.
- Tesztelj több klienssel a valós idejű frissítések megfigyeléséhez.
- Ha hibákba ütközöl, ellenőrizd a Python verziódat és győződj meg róla, hogy minden függőség telepítve van.

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.