<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:04:16+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

Iată cum să rulezi serverul și clientul clasic HTTP streaming, precum și serverul și clientul MCP streaming folosind Python.

### Prezentare generală

- Vei configura un server MCP care transmite notificări de progres către client pe măsură ce procesează elementele.
- Clientul va afișa fiecare notificare în timp real.
- Acest ghid acoperă cerințele, configurarea, rularea și depanarea.

### Cerințe

- Python 3.9 sau o versiune mai nouă
- Pachetul Python `mcp` (instalează cu `pip install mcp`)

### Instalare și configurare

1. Clonează repository-ul sau descarcă fișierele soluției.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Creează și activează un mediu virtual (recomandat):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Instalează dependențele necesare:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Fișiere

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Rularea serverului clasic HTTP Streaming

1. Navighează în directorul soluției:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Pornește serverul clasic HTTP streaming:

   ```pwsh
   python server.py
   ```

3. Serverul va porni și va afișa:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Rularea clientului clasic HTTP Streaming

1. Deschide un terminal nou (activează același mediu virtual și director):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Ar trebui să vezi mesajele transmise afișate secvențial:

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

### Rularea serverului MCP Streaming

1. Navighează în directorul soluției:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Pornește serverul MCP cu transportul streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Serverul va porni și va afișa:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Rularea clientului MCP Streaming

1. Deschide un terminal nou (activează același mediu virtual și director):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Ar trebui să vezi notificările afișate în timp real pe măsură ce serverul procesează fiecare element:
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

### Pași cheie de implementare

1. **Creează serverul MCP folosind FastMCP.**
2. **Definește un tool care procesează o listă și trimite notificări folosind `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` pentru operațiuni non-blocante.**
- Gestionează întotdeauna excepțiile atât pe server, cât și pe client pentru robustețe.
- Testează cu mai mulți clienți pentru a observa actualizările în timp real.
- Dacă întâmpini erori, verifică versiunea de Python și asigură-te că toate dependențele sunt instalate.

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere automată AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să țineți cont că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un traducător uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.