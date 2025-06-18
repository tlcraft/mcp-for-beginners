<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:12:15+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "el"
}
-->
# HTTPS Streaming με το Πρωτόκολλο Model Context (MCP)

Αυτό το κεφάλαιο προσφέρει έναν ολοκληρωμένο οδηγό για την υλοποίηση ασφαλούς, επεκτάσιμου και σε πραγματικό χρόνο streaming με το Πρωτόκολλο Model Context (MCP) χρησιμοποιώντας HTTPS. Καλύπτει τα κίνητρα για streaming, τους διαθέσιμους μηχανισμούς μεταφοράς, πώς να υλοποιήσετε streamable HTTP στο MCP, βέλτιστες πρακτικές ασφάλειας, τη μετάβαση από SSE και πρακτικές οδηγίες για την κατασκευή των δικών σας streaming εφαρμογών MCP.

## Μηχανισμοί Μεταφοράς και Streaming στο MCP

Αυτή η ενότητα εξετάζει τους διαφορετικούς μηχανισμούς μεταφοράς που είναι διαθέσιμοι στο MCP και τον ρόλο τους στην ενεργοποίηση δυνατοτήτων streaming για επικοινωνία σε πραγματικό χρόνο μεταξύ πελατών και διακομιστών.

### Τι είναι ένας Μηχανισμός Μεταφοράς;

Ένας μηχανισμός μεταφοράς ορίζει τον τρόπο με τον οποίο ανταλλάσσονται τα δεδομένα μεταξύ πελάτη και διακομιστή. Το MCP υποστηρίζει πολλούς τύπους μεταφοράς ώστε να καλύπτει διαφορετικά περιβάλλοντα και απαιτήσεις:

- **stdio**: Πρότυπη είσοδος/έξοδος, κατάλληλο για τοπικά εργαλεία και εργαλεία CLI. Απλό αλλά όχι κατάλληλο για web ή cloud.
- **SSE (Server-Sent Events)**: Επιτρέπει στους διακομιστές να στέλνουν ενημερώσεις σε πραγματικό χρόνο στους πελάτες μέσω HTTP. Κατάλληλο για web UI, αλλά περιορισμένο σε κλιμάκωση και ευελιξία.
- **Streamable HTTP**: Σύγχρονος μεταφορικός μηχανισμός βασισμένος σε HTTP, που υποστηρίζει ειδοποιήσεις και καλύτερη κλιμάκωση. Συνιστάται για τις περισσότερες παραγωγικές και cloud περιπτώσεις.

### Πίνακας Σύγκρισης

Δείτε τον παρακάτω πίνακα σύγκρισης για να κατανοήσετε τις διαφορές μεταξύ αυτών των μηχανισμών μεταφοράς:

| Μεταφορά         | Ενημερώσεις σε Πραγματικό Χρόνο | Streaming | Κλιμάκωση | Περίπτωση Χρήσης         |
|------------------|---------------------------------|-----------|-----------|-------------------------|
| stdio            | Όχι                             | Όχι       | Χαμηλή    | Τοπικά εργαλεία CLI      |
| SSE              | Ναι                             | Ναι       | Μέτρια    | Web, ενημερώσεις σε πραγματικό χρόνο |
| Streamable HTTP  | Ναι                             | Ναι       | Υψηλή     | Cloud, πολλοί πελάτες    |

> **Tip:** Η σωστή επιλογή μεταφοράς επηρεάζει την απόδοση, την κλιμάκωση και την εμπειρία χρήστη. Το **Streamable HTTP** προτείνεται για σύγχρονες, επεκτάσιμες και έτοιμες για cloud εφαρμογές.

Σημειώστε τους μηχανισμούς stdio και SSE που παρουσιάστηκαν στα προηγούμενα κεφάλαια και πώς το streamable HTTP είναι ο μηχανισμός που καλύπτεται σε αυτό το κεφάλαιο.

## Streaming: Έννοιες και Κίνητρα

Η κατανόηση των βασικών εννοιών και των κινήτρων πίσω από το streaming είναι απαραίτητη για την υλοποίηση αποτελεσματικών συστημάτων επικοινωνίας σε πραγματικό χρόνο.

**Streaming** είναι μια τεχνική στον προγραμματισμό δικτύων που επιτρέπει την αποστολή και λήψη δεδομένων σε μικρά, διαχειρίσιμα κομμάτια ή ως ακολουθία γεγονότων, αντί να περιμένει να είναι έτοιμη ολόκληρη η απάντηση. Αυτό είναι ιδιαίτερα χρήσιμο για:

- Μεγάλα αρχεία ή σύνολα δεδομένων.
- Ενημερώσεις σε πραγματικό χρόνο (π.χ. chat, μπάρες προόδου).
- Μακροχρόνιους υπολογισμούς όπου θέλετε να κρατάτε τον χρήστη ενήμερο.

Ακολουθούν βασικά σημεία που πρέπει να γνωρίζετε για το streaming σε γενικές γραμμές:

- Τα δεδομένα παραδίδονται σταδιακά, όχι όλα μαζί.
- Ο πελάτης μπορεί να επεξεργαστεί τα δεδομένα καθώς φτάνουν.
- Μειώνει την αντιληπτή καθυστέρηση και βελτιώνει την εμπειρία χρήστη.

### Γιατί να χρησιμοποιήσετε streaming;

Οι λόγοι για τη χρήση του streaming είναι οι εξής:

- Οι χρήστες λαμβάνουν άμεση ανατροφοδότηση, όχι μόνο στο τέλος.
- Διευκολύνει εφαρμογές σε πραγματικό χρόνο και ανταποκρινόμενα UI.
- Αποτελεσματικότερη χρήση δικτύου και υπολογιστικών πόρων.

### Απλό Παράδειγμα: HTTP Streaming Server & Client

Εδώ ένα απλό παράδειγμα για το πώς μπορεί να υλοποιηθεί το streaming:

<details>
<summary>Python</summary>

**Διακομιστής (Python, με FastAPI και StreamingResponse):**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**Πελάτης (Python, με requests):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

Αυτό το παράδειγμα δείχνει έναν διακομιστή που στέλνει μια σειρά από μηνύματα στον πελάτη καθώς γίνονται διαθέσιμα, αντί να περιμένει όλα τα μηνύματα να είναι έτοιμα.

**Πώς λειτουργεί:**
- Ο διακομιστής αποδίδει κάθε μήνυμα μόλις είναι έτοιμο.
- Ο πελάτης λαμβάνει και εμφανίζει κάθε κομμάτι μόλις φτάσει.

**Απαιτήσεις:**
- Ο διακομιστής πρέπει να χρησιμοποιεί streaming response (π.χ. `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) αντί για επιλογή streaming μέσω MCP.

- **Για απλές ανάγκες streaming:** Το κλασικό HTTP streaming είναι πιο απλό στην υλοποίηση και επαρκές για βασικές ανάγκες.

- **Για σύνθετες, διαδραστικές εφαρμογές:** Το MCP streaming παρέχει πιο δομημένη προσέγγιση με πλουσιότερα metadata και διαχωρισμό μεταξύ ειδοποιήσεων και τελικών αποτελεσμάτων.

- **Για εφαρμογές AI:** Το σύστημα ειδοποιήσεων του MCP είναι ιδιαίτερα χρήσιμο για μακροχρόνιες εργασίες AI όπου θέλετε να κρατάτε τους χρήστες ενήμερους για την πρόοδο.

## Streaming στο MCP

Ωραία, έχετε δει μερικές συστάσεις και συγκρίσεις μέχρι στιγμής για τη διαφορά ανάμεσα στο κλασικό streaming και το streaming στο MCP. Ας δούμε λεπτομερώς πώς ακριβώς μπορείτε να αξιοποιήσετε το streaming στο MCP.

Η κατανόηση του πώς λειτουργεί το streaming μέσα στο πλαίσιο του MCP είναι απαραίτητη για την κατασκευή ανταποκρινόμενων εφαρμογών που παρέχουν ανατροφοδότηση σε πραγματικό χρόνο στους χρήστες κατά τη διάρκεια μακροχρόνιων διεργασιών.

Στο MCP, το streaming δεν αφορά την αποστολή της κύριας απάντησης σε κομμάτια, αλλά την αποστολή **ειδοποιήσεων** στον πελάτη ενώ ένα εργαλείο επεξεργάζεται ένα αίτημα. Αυτές οι ειδοποιήσεις μπορεί να περιλαμβάνουν ενημερώσεις προόδου, αρχεία καταγραφής ή άλλα γεγονότα.

### Πώς λειτουργεί

Το κύριο αποτέλεσμα εξακολουθεί να αποστέλλεται ως μία ενιαία απάντηση. Ωστόσο, ειδοποιήσεις μπορούν να αποστέλλονται ως ξεχωριστά μηνύματα κατά τη διάρκεια της επεξεργασίας και έτσι ενημερώνουν τον πελάτη σε πραγματικό χρόνο. Ο πελάτης πρέπει να μπορεί να διαχειρίζεται και να εμφανίζει αυτές τις ειδοποιήσεις.

## Τι είναι μια Ειδοποίηση;

Αναφέραμε "Ειδοποίηση", τι σημαίνει αυτό στο πλαίσιο του MCP;

Μια ειδοποίηση είναι ένα μήνυμα που στέλνεται από τον διακομιστή στον πελάτη για να ενημερώσει σχετικά με την πρόοδο, την κατάσταση ή άλλα γεγονότα κατά τη διάρκεια μιας μακροχρόνιας διεργασίας. Οι ειδοποιήσεις βελτιώνουν τη διαφάνεια και την εμπειρία χρήστη.

Για παράδειγμα, ένας πελάτης πρέπει να στείλει μια ειδοποίηση μόλις ολοκληρωθεί το αρχικό handshake με τον διακομιστή.

Μια ειδοποίηση μοιάζει ως εξής σε μορφή JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Οι ειδοποιήσεις ανήκουν σε ένα θέμα στο MCP που αναφέρεται ως ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

Για να λειτουργήσει η καταγραφή, ο διακομιστής πρέπει να την ενεργοποιήσει ως λειτουργία/δυνατότητα ως εξής:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Ανάλογα με το SDK που χρησιμοποιείται, η καταγραφή μπορεί να είναι ενεργοποιημένη από προεπιλογή ή μπορεί να χρειαστεί να την ενεργοποιήσετε ρητά στη ρύθμιση του διακομιστή σας.

Υπάρχουν διάφοροι τύποι ειδοποιήσεων:

| Επίπεδο    | Περιγραφή                      | Παράδειγμα Χρήσης             |
|------------|-------------------------------|------------------------------|
| debug      | Λεπτομερής πληροφόρηση αποσφαλμάτωσης | Σημεία εισόδου/εξόδου λειτουργιών |
| info       | Γενικά ενημερωτικά μηνύματα   | Ενημερώσεις προόδου λειτουργίας |
| notice     | Κανονικά αλλά σημαντικά γεγονότα | Αλλαγές ρυθμίσεων            |
| warning    | Προειδοποιητικές καταστάσεις  | Χρήση αποσυρμένων λειτουργιών |
| error      | Καταστάσεις σφάλματος         | Αποτυχίες λειτουργίας        |
| critical   | Κρίσιμες καταστάσεις          | Αποτυχίες συστατικών συστήματος |
| alert      | Απαιτείται άμεση ενέργεια     | Ανίχνευση διαφθοράς δεδομένων |
| emergency  | Το σύστημα είναι μη λειτουργικό | Πλήρης αποτυχία συστήματος   |

## Υλοποίηση Ειδοποιήσεων στο MCP

Για να υλοποιήσετε ειδοποιήσεις στο MCP, πρέπει να ρυθμίσετε τόσο τον διακομιστή όσο και τον πελάτη να χειρίζονται ενημερώσεις σε πραγματικό χρόνο. Αυτό επιτρέπει στην εφαρμογή σας να παρέχει άμεση ανατροφοδότηση στους χρήστες κατά τη διάρκεια μακροχρόνιων διεργασιών.

### Πλευρά Διακομιστή: Αποστολή Ειδοποιήσεων

Ας ξεκινήσουμε με την πλευρά του διακομιστή. Στο MCP, ορίζετε εργαλεία που μπορούν να στέλνουν ειδοποιήσεις ενώ επεξεργάζονται αιτήματα. Ο διακομιστής χρησιμοποιεί το αντικείμενο context (συνήθως `ctx`) για να στέλνει μηνύματα στον πελάτη.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

Στο προηγούμενο παράδειγμα, το `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` μεταφορικό μέσο:

```python
mcp.run(transport="streamable-http")
```

</details>

### Πλευρά Πελάτη: Λήψη Ειδοποιήσεων

Ο πελάτης πρέπει να υλοποιήσει έναν χειριστή μηνυμάτων για να επεξεργάζεται και να εμφανίζει τις ειδοποιήσεις καθώς φτάνουν.

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

Στον προηγούμενο κώδικα, το `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) και ο πελάτης σας υλοποιεί έναν χειριστή μηνυμάτων για την επεξεργασία ειδοποιήσεων.

## Ειδοποιήσεις Προόδου & Σενάρια

Αυτή η ενότητα εξηγεί την έννοια των ειδοποιήσεων προόδου στο MCP, γιατί είναι σημαντικές και πώς να τις υλοποιήσετε χρησιμοποιώντας το Streamable HTTP. Θα βρείτε επίσης μια πρακτική άσκηση για να εμβαθύνετε την κατανόησή σας.

Οι ειδοποιήσεις προόδου είναι μηνύματα σε πραγματικό χρόνο που αποστέλλονται από τον διακομιστή στον πελάτη κατά τη διάρκεια μακροχρόνιων διεργασιών. Αντί να περιμένει ο πελάτης να ολοκληρωθεί όλη η διαδικασία, ο διακομιστής τον ενημερώνει συνεχώς για την τρέχουσα κατάσταση. Αυτό βελτιώνει τη διαφάνεια, την εμπειρία χρήστη και διευκολύνει την αποσφαλμάτωση.

**Παράδειγμα:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Γιατί να χρησιμοποιήσετε ειδοποιήσεις προόδου;

Οι ειδοποιήσεις προόδου είναι απαραίτητες για διάφορους λόγους:

- **Καλύτερη εμπειρία χρήστη:** Οι χρήστες βλέπουν ενημερώσεις καθώς προχωρά η εργασία, όχι μόνο στο τέλος.
- **Ανατροφοδότηση σε πραγματικό χρόνο:** Οι πελάτες μπορούν να εμφανίζουν μπάρες προόδου ή αρχεία καταγραφής, κάνοντας την εφαρμογή πιο ανταποκρινόμενη.
- **Ευκολότερη αποσφαλμάτωση και παρακολούθηση:** Οι προγραμματιστές και οι χρήστες μπορούν να δουν πού μπορεί να υπάρχει καθυστέρηση ή πρόβλημα.

### Πώς να υλοποιήσετε ειδοποιήσεις προόδου

Δείτε πώς μπορείτε να υλοποιήσετε ειδοποιήσεις προόδου στο MCP:

- **Στον διακομιστή:** Χρησιμοποιήστε `ctx.info()` or `ctx.log()` για να στείλετε ειδοποιήσεις καθώς επεξεργάζεται κάθε στοιχείο. Αυτό στέλνει μήνυμα στον πελάτη πριν είναι έτοιμο το κύριο αποτέλεσμα.
- **Στον πελάτη:** Υλοποιήστε έναν χειριστή μηνυμάτων που ακούει και εμφανίζει τις ειδοποιήσεις καθώς φτάνουν. Αυτός ο χειριστής διαχωρίζει τις ειδοποιήσεις από το τελικό αποτέλεσμα.

**Παράδειγμα Διακομιστή:**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**Παράδειγμα Πελάτη:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## Ζητήματα Ασφαλείας

Κατά την υλοποίηση διακομιστών MCP με HTTP-based μεταφορές, η ασφάλεια γίνεται κορυφαία προτεραιότητα που απαιτεί προσεκτική αντιμετώπιση πολλαπλών επιθέσεων και μηχανισμών προστασίας.

### Επισκόπηση

Η ασφάλεια είναι κρίσιμη όταν εκθέτετε διακομιστές MCP μέσω HTTP. Το Streamable HTTP εισάγει νέες επιφάνειες επίθεσης και απαιτεί προσεκτική ρύθμιση.

### Κύρια Σημεία
- **Επικύρωση Επικεφαλίδας Origin**: Πάντα επικυρώνετε το `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` αντί για πελάτη SSE.
3. **Υλοποιήστε έναν χειριστή μηνυμάτων** στον πελάτη για την επεξεργασία ειδοποιήσεων.
4. **Δοκιμάστε τη συμβατότητα** με υπάρχοντα εργαλεία και ροές εργασίας.

### Διατήρηση Συμβατότητας

Συνιστάται να διατηρήσετε τη συμβατότητα με υπάρχοντες πελάτες SSE κατά τη διαδικασία μετανάστευσης. Ορισμένες στρατηγικές:

- Μπορείτε να υποστηρίξετε τόσο SSE όσο και Streamable HTTP εκτελώντας και τους δύο μηχανισμούς σε διαφορετικά endpoints.
- Μεταφέρετε σταδιακά τους πελάτες στο νέο μηχανισμό.

### Προκλήσεις

Βεβαιωθείτε ότι αντιμετωπίζετε τις παρακάτω προκλήσεις κατά τη μετανάστευση:

- Ενημέρωση όλων των πελατών.
- Διαχείριση διαφορών στην παράδοση ειδοποιήσεων.

### Άσκηση: Δημιουργήστε τη Δική σας Streaming Εφαρμογή MCP

**Σενάριο:**
Δημιουργήστε έναν MCP διακομιστή και πελάτη όπου ο διακομιστής επεξεργάζεται μια λίστα αντικειμένων (π.χ. αρχεία ή έ

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική μετάφραση από άνθρωπο. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.