<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:04:06+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "sk"
}
-->
# Spustenie tohto príkladu

Tu je návod, ako spustiť klasický HTTP streaming server a klienta, ako aj MCP streaming server a klienta pomocou Pythonu.

### Prehľad

- Nastavíte MCP server, ktorý počas spracovania položiek vysiela notifikácie o priebehu klientovi.
- Klient bude zobrazovať každú notifikáciu v reálnom čase.
- Tento návod pokrýva požiadavky, nastavenie, spustenie a riešenie problémov.

### Požiadavky

- Python 3.9 alebo novší
- Balík `mcp` pre Python (inštalácia pomocou `pip install mcp`)

### Inštalácia a nastavenie

1. Naklonujte repozitár alebo stiahnite súbory riešenia.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Vytvorte a aktivujte virtuálne prostredie (odporúčané):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Nainštalujte potrebné závislosti:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Súbory

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Klient:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Spustenie klasického HTTP streaming servera

1. Prejdite do adresára riešenia:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Spustite klasický HTTP streaming server:

   ```pwsh
   python server.py
   ```

3. Server sa spustí a zobrazí:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Spustenie klasického HTTP streaming klienta

1. Otvorte nový terminál (aktivujte rovnaké virtuálne prostredie a adresár):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Mali by sa zobrazovať postupne vysielané správy:

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

### Spustenie MCP streaming servera

1. Prejdite do adresára riešenia:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Spustite MCP server s transportom streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Server sa spustí a zobrazí:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Spustenie MCP streaming klienta

1. Otvorte nový terminál (aktivujte rovnaké virtuálne prostredie a adresár):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Mali by sa zobrazovať notifikácie v reálnom čase, keď server spracováva jednotlivé položky:
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

### Kľúčové kroky implementácie

1. **Vytvorte MCP server pomocou FastMCP.**
2. **Definujte nástroj, ktorý spracuje zoznam a posiela notifikácie pomocou `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` pre neblokujúce operácie.**
- Vždy ošetrujte výnimky na strane servera aj klienta pre spoľahlivosť.
- Testujte s viacerými klientmi, aby ste videli aktualizácie v reálnom čase.
- Ak narazíte na chyby, skontrolujte verziu Pythonu a uistite sa, že všetky závislosti sú nainštalované.

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím berte na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.