<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:01:47+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του δείγματος

Εδώ θα δείτε πώς να εκτελέσετε τον κλασικό HTTP streaming server και client, καθώς και τον MCP streaming server και client χρησιμοποιώντας Python.

### Επισκόπηση

- Θα ρυθμίσετε έναν MCP server που στέλνει ειδοποιήσεις προόδου στον client καθώς επεξεργάζεται αντικείμενα.
- Ο client θα εμφανίζει κάθε ειδοποίηση σε πραγματικό χρόνο.
- Ο οδηγός καλύπτει τις προαπαιτήσεις, τη ρύθμιση, την εκτέλεση και την αντιμετώπιση προβλημάτων.

### Προαπαιτήσεις

- Python 3.9 ή νεότερη έκδοση
- Το πακέτο `mcp` για Python (εγκατάσταση με `pip install mcp`)

### Εγκατάσταση & Ρύθμιση

1. Κλωνοποιήστε το αποθετήριο ή κατεβάστε τα αρχεία της λύσης.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Δημιουργήστε και ενεργοποιήστε ένα virtual environment (συνιστάται):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Εγκαταστήστε τις απαραίτητες εξαρτήσεις:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Αρχεία

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Εκτέλεση του Κλασικού HTTP Streaming Server

1. Μεταβείτε στον φάκελο της λύσης:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Εκκινήστε τον κλασικό HTTP streaming server:

   ```pwsh
   python server.py
   ```

3. Ο server θα ξεκινήσει και θα εμφανίσει:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Εκτέλεση του Κλασικού HTTP Streaming Client

1. Ανοίξτε ένα νέο τερματικό (ενεργοποιήστε το ίδιο virtual environment και φάκελο):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Θα δείτε τα μηνύματα να εμφανίζονται διαδοχικά σε streaming:

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

### Εκτέλεση του MCP Streaming Server

1. Μεταβείτε στον φάκελο της λύσης:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Εκκινήστε τον MCP server με το streamable-http transport:
   ```pwsh
   python server.py mcp
   ```
3. Ο server θα ξεκινήσει και θα εμφανίσει:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Εκτέλεση του MCP Streaming Client

1. Ανοίξτε ένα νέο τερματικό (ενεργοποιήστε το ίδιο virtual environment και φάκελο):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Θα δείτε τις ειδοποιήσεις να εμφανίζονται σε πραγματικό χρόνο καθώς ο server επεξεργάζεται κάθε αντικείμενο:
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

### Κύρια Βήματα Υλοποίησης

1. **Δημιουργήστε τον MCP server χρησιμοποιώντας το FastMCP.**
2. **Ορίστε ένα εργαλείο που επεξεργάζεται μια λίστα και στέλνει ειδοποιήσεις χρησιμοποιώντας `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` για ασύγχρονες λειτουργίες χωρίς μπλοκάρισμα.**
- Φροντίστε να χειρίζεστε πάντα τις εξαιρέσεις τόσο στον server όσο και στον client για αξιοπιστία.
- Δοκιμάστε με πολλούς clients για να δείτε ενημερώσεις σε πραγματικό χρόνο.
- Αν αντιμετωπίσετε σφάλματα, ελέγξτε την έκδοση της Python και βεβαιωθείτε ότι όλες οι εξαρτήσεις είναι εγκατεστημένες.

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης με τεχνητή νοημοσύνη [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται η επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.